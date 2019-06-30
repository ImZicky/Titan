using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Titan.Models
{
    public class ClienteEntity: BaseModel
    {
        public ClienteEntity()
        {
        }

        public ClienteEntity(int xmin, int xmax, int ymin, int ymax, DateTime dtIns, Cor cor, LojaEntity loja)
        {
            Xmin = xmin;
            Xmax = xmax;
            Ymin = ymin;
            Ymax = ymax;
            DtIns = dtIns;
            Cor = cor;
            Loja = loja;
        }

        public int Xmin { get; set; }
        public int Xmax { get; set; }
        public int Ymin { get; set; }
        public int Ymax { get; set; }
        public DateTime DtIns { get; set; }

        public Cor Cor { get; set; } //MOSTRAR PRA O PESSOAL 'MUDANÇA'

        public LojaEntity Loja { get; set; } // PERGUNTAR SE PODE FAZER DESSE JEITO COM LOJAENTITY AO INVEZ DE INT





    }
}
