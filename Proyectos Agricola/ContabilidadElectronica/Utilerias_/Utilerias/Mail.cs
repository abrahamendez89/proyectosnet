﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;

namespace Utilerias.Utilerias
{
    public class Mail
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
        public List<Adjunto> ArchivosAdjuntos { get { return archivosAdjuntos; } set { archivosAdjuntos = value; } }
        public void AgregarArchivoAdjunto(String ruta, String nombreArchivo)
        {
            Adjunto adj = new Adjunto();
            adj.Stream = fileToStream(ruta);
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
        private MemoryStream fileToStream(String dir)
        {
            System.IO.MemoryStream data = new System.IO.MemoryStream();
            System.IO.Stream str = File.OpenRead(dir);

            str.CopyTo(data);
            data.Seek(0, SeekOrigin.Begin);
            byte[] buf = new byte[data.Length];
            data.Read(buf, 0, buf.Length);
            data.Position = 0;
            return data;
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
            String noReply = "noreply@wholesumharvest.com";
            //"wholesumharvestautomatico@gmail.com"
            mail.From = new MailAddress(noReply, NombreAMostrar, System.Text.Encoding.UTF8);
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
            client.Credentials = new System.Net.NetworkCredential(noReply, "Wholesum2014");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            try
            {
                client.Send(mail);
                if(archivosAdjuntos != null)
                foreach (Adjunto ad in archivosAdjuntos)
                    ad.Stream.Close();
            }
            catch (Exception ex)
            {
                Mensajes.Error("Error al enviar el correo. Detalles: " + ex.Message, "Error");
            }
        }
    }
}
