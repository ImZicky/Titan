using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;

namespace Titan.Services
{
    public static class Email
    {
        public static void EnviaEmail(string mensagem)
        {
            string EmailOrigem = "contato@mileniobus.com.br";
            string SenhaOrigem = "";

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,

                Credentials = new System.Net.NetworkCredential(EmailOrigem, SenhaOrigem)
            };

            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate (object s,
            System.Security.Cryptography.X509Certificates.X509Certificate certificate,
            System.Security.Cryptography.X509Certificates.X509Chain chain,
            System.Net.Security.SslPolicyErrors sslPolicyErrors)
            {
                return true;
            };

            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

            MailMessage mail = new MailMessage
            {
                Subject = "Mensagem de um vendedor",

                From = new MailAddress(EmailOrigem, "Vendedor"),
                Body = "Olá! Uma nova mensagem de um vendedor.\n\nMensagem: \n" + mensagem
            };

            mail.To.Add(new MailAddress("marcelogando@gmail.com"));

            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = false;

            smtpClient.Send(mail);
        }
    }
}
