using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace EjecutaBI
{
    public class Mail
    {
        public void EnviarCorreo(String emailDestino, String nombreAMostrar, String asunto, String contenido, List<System.IO.Stream> adjuntos, List<String> NombresAdjuntos)
        {
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            String[] emails = emailDestino.Split(';');
            foreach (String email in emails)
            {
                if(!email.Equals(""))
                    mail.To.Add(email);
            }

            if (mail.To.Count == 0)
                return;

            if(adjuntos != null)
            for(int i = 0; i < adjuntos.Count; i++)
                mail.Attachments.Add(new Attachment(adjuntos[i], NombresAdjuntos[i]));



            mail.From = new MailAddress("wholesumharvestautomatico@gmail.com", nombreAMostrar, System.Text.Encoding.UTF8);
            mail.Subject = asunto;
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = contenido;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("wholesumharvestautomatico@gmail.com", "1@TCE123");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
