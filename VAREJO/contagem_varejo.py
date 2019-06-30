import time
import cv2
import numpy as np
import imutils
import requests
import datetime
from imutils.video import VideoStream
from skimage.measure import compare_ssim
import sys
import pandas as pd

def sendCounter(qnt_entrou, qnt_saiu, url = 'http://www.titanhackathon.com.br/Contador/SetDadosContador'):
    now = datetime.datetime.now()
    date_string = now.strftime('%Y-%m-%dT%H:%M:%S.000Z')
    
    json= {
	"localId":1,
	"qtdEntrou": qnt_entrou,
	"qtdSaiu": qnt_saiu,
	"dtIns":date_string
    }

    r = requests.post(url, json=json)
    return r.text, r.status_code

def sendCoordenates(Xmin, Xmax, Ymin, Ymax, Secao, cor, url = 'http://www.mititanhackathonleniobus.com.br/Contador/SetDadosContador'):
    now = datetime.datetime.now()
    date_string = now.strftime('%Y-%m-%dT%H:%M:%S.000Z')
    
    json= {
    "LojaId": 1,
    "SecaoId": Secao,
	"Xmin": Xmin,
	"Xmax": Xmax,
    "Ymin": Ymin,
    "Ymax": Ymax,
	"DtIns": date_string,
	"Camiseta": cor
    }

    r = requests.post(url, json=json)
    return r.text, r.status_code

def findCoordenates(img1, img2):
    manchas = 0
    coordenadas = []

    img1_gray = cv2.cvtColor(img1, cv2.COLOR_BGR2GRAY)
    img2_gray = cv2.cvtColor(img2, cv2.COLOR_BGR2GRAY)

    score, diff = compare_ssim(img1_gray, img2_gray, full=True)##gasta mto tempo 0.88s
    diff = (diff * 255).astype("uint8")##gasta um pouco de tempo 0.016
    # print("SSIM: {}".format(score))

    thresh = cv2.threshold(diff, 0, 255,cv2.THRESH_BINARY_INV | cv2.THRESH_OTSU)[1]
    cnts = cv2.findContours(thresh, cv2.RETR_EXTERNAL,cv2.CHAIN_APPROX_SIMPLE)
    cnts = imutils.grab_contours(cnts)

    for c in cnts:
        (x, y, w, h) = cv2.boundingRect(c)
        
        if abs(w*h) > 13000:
            if show_camera:
                cv2.rectangle(img2, (x, y), (x + w, y + h), (0, 0, 255), 2)
                cv2.circle(img2, (int(x+w/2),int(y+h/2)), 5, (255, 0, 0), -1)

            if y+h/2 > 250: 
                manchas += 1
            coordenadas.append({'Xmin':int(x),'Xmax':int(x+h), 'Ymin':int(y), "Ymax":int(y+w),'qtdPessoas': max(1, round(abs(w*h)/8000))})
    
    # cv2.line(img2, (1250, 0), (1250, 1000), (0,255,0), 5)
    if show_camera:
        displayImage = np.asarray( img2 )
        cv2.imshow( 'Background subtraction', displayImage )

    if manchas != 0:
        return manchas, coordenadas
    else:
        return -1, [{'x':-1, 'y':-1}]

show_camera = False
show_frames = False
if len(sys.argv) > 1:
    if "camera" in sys.argv:
        show_camera = True
    if "frames" in sys.argv:
        show_frames = True

# vs = VideoStream(usePiCamera=False, resolution=(272, 208)).start()
# vs = cv2.VideoCapture('./2019-06-29_21-11-59.mp4')
vs = cv2.VideoCapture('./cut.mp4')
time.sleep(0.5)

img_fundo = cv2.imread('fundo.jpg')
img_fundo = cv2.resize(img_fundo, (1280,720), interpolation = cv2.INTER_AREA)

# img_fundo = vs.read()
print("--CONTAGEM INICIADA--")

linha_meio = 1250

frames = 0
start_time = time.time()

lista_pessoas = []
lista_coordenadas = []

contagem = 0

while True:
    ret, screenshot = vs.read()
    screenshot = cv2.resize(screenshot, (1280,720), interpolation = cv2.INTER_AREA)
    manchas, coordenadas = findCoordenates(img_fundo, screenshot)

    if show_frames:
        frames += 1
        if time.time()-start_time >= 1:
            print("FRAMES: {}".format(frames))
            start_time = time.time()
            frames = 0

    if show_camera and (cv2.waitKey( 5 ) & 0xFF == ord( 'q' )):
        # fps.stop()
        break

    now = datetime.datetime.now()
    date_string = now.strftime('%Y-%m-%dT%H:%M:%S.000Z')
    if contagem == 9:
        lista_pessoas.append([date_string, manchas])

    if manchas > 0:
        print("Pessoas: {}".format(manchas))
        for i in range(len(coordenadas)):
            Xmin, Xmax, Ymin, Ymax = coordenadas[i]['Xmin'], coordenadas[i]['Xmax'], coordenadas[i]['Ymin'], coordenadas[i]['Ymax']
            if (Xmin+Xmax)/2 < linha_meio:
                if contagem == 9:
                    lista_coordenadas.append([date_string, 1, 1, Xmin, Xmax, Ymin, Ymax, "255,255,255"])
                # realiza requisição post para endpoint de armazenamento
                # sendCoordenates(Xmin, Xmax, Ymin, Ymax, 1, [255,255,255])
            else:
                if contagem==9:
                    lista_coordenadas.append([date_string, 1, 2, Xmin, Xmax, Ymin, Ymax, "255,255,255"])
                # realiza requisição post para endpoint de armazenamento
                # sendCoordenates(Xmin, Xmax, Ymin, Ymax, 2, [255,255,255])
    else:
        print("Pessoas: {}".format(0))

    contagem +=1
    if contagem >= 10:
        contagem = 0

df_pessoas = pd.DataFrame(lista_pessoas, columns = ['DATA', 'QNT_PESSOAS'])
df_coordenadas = pd.DataFrame(lista_coordenadas, columns = ['DATA', 'IDLOJA', 'SECAO','XMIN', 'XMAX', 'YMIN', 'YMAX', 'COR'])

df_pessoas.to_csv('contagem_pessoas.csv', header=True)
df_coordenadas.to_csv('coordenadas.csv', header=True)

cv2.destroyAllWindows()
# vs.stop()
vs.release()