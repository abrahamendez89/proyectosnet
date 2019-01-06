using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;

namespace Herramientas.Mail
{
    public class Gmail
    {
        public enum Prioridad
        {
            Baja = 0,
            Normal = 1,
            Alta = 2
        }
        private List<Adjunto> archivosAdjuntos = new List<Adjunto>();
        public String EmailDestino { get; set; }
        public String NombreAMostrar { get; set; }
        public String Asunto { get; set; }
        public String ContenidoHTML { get; set; }
        public String EmailUsar { get; set; }
        public String ContrasenaUsar { get; set; }

        public List<Adjunto> ArchivosAdjuntos { get { return archivosAdjuntos; } set { archivosAdjuntos = value; } }

        public void AgregarArchivoAdjunto(String ruta, String nombreArchivo)
        {
            Adjunto adj = new Adjunto();
            adj.Stream = Herramientas.Archivos.Archivo.ArchivoAMemoryStream(ruta);
            adj.NombreArchivo = nombreArchivo;
            archivosAdjuntos.Add(adj);
        }
        public void AgregarBitmapAdjunto(Bitmap bitmap, String nombreArchivo)
        {
            Adjunto adj = new Adjunto();
            adj.Stream = bitmapToStream(bitmap);
            adj.NombreArchivo = nombreArchivo;
            archivosAdjuntos.Add(adj);
        }
        private MemoryStream bitmapToStream(Bitmap bitmap)
        {
            ImageConverter ic = new ImageConverter();
            Byte[] ba = (Byte[])ic.ConvertTo(bitmap, typeof(Byte[]));
            MemoryStream stream = new MemoryStream(ba);

            return stream;
        }
        public void EnviarCorreo(Prioridad prioridad)
        {
            MailMessage mail = new MailMessage();
            String[] emails = EmailDestino.Split(';');
            foreach (String email in emails)
                if (!email.Trim().Equals(""))
                    mail.To.Add(email);
            if (archivosAdjuntos != null)
            {
                foreach (Adjunto adjunto in archivosAdjuntos)
                {
                    Attachment data = new Attachment(adjunto.Stream, MediaTypeNames.Application.Octet);
                    ContentDisposition disposition = data.ContentDisposition;
                    disposition.FileName = adjunto.NombreArchivo;
                    mail.Attachments.Add(data);
                }
            }
            String emailUsar = EmailUsar;
            mail.From = new MailAddress(emailUsar, NombreAMostrar, System.Text.Encoding.UTF8);
            mail.Subject = Asunto;
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = ContenidoHTML;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            if(prioridad == Prioridad.Alta)
                mail.Priority = MailPriority.High;
            else if (prioridad == Prioridad.Normal)
                mail.Priority = MailPriority.Normal;
            else if (prioridad == Prioridad.Baja)
                mail.Priority = MailPriority.Low;

            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(emailUsar, ContrasenaUsar);
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
