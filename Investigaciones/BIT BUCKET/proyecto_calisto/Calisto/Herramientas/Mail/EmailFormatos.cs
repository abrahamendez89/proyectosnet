using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Herramientas.Mail
{
    public class EmailFormatos
    {
        public delegate void ErrorEnviarCorreo(String mensajeError);
        public static event ErrorEnviarCorreo errorEnviarCorreo;

        public delegate void CorreoEnviado();
        public static event CorreoEnviado correoEnviado;

        public static void EnviarMailError(String mensaje, String asunto, String detallesTecnicos, Exception ex, String emails, List<Adjunto> adjuntos)
        {
            try
            {
                if (emails.Trim().Equals("")) return;
                Mail m = new Mail();
                m.Asunto = asunto;
                m.EmailDestino = emails;
                m.ArchivosAdjuntos = adjuntos;
                m.ContenidoHTML = @"<b><FONT FACE=""arial"" SIZE=3 COLOR=red>Se ha generado un error.</FONT></b>
                <p ALIGN=center><IMG SRC=""http://esh30.esoft.com.mx/Sistema/include/Archivos/33/37/Imagenes/PI333720118105552528.png"" WIDTH=200 HEIGHT=140></p>
                <p><em>Mensaje del error:</em></p>
                <blockquote>
                <p><b>@Mensaje</b></p>
                </blockquote>";
                if (ex != null)
                {
                    m.ContenidoHTML += @"<p><em>Detalles de la exception:</em></p>
                <blockquote>
                <p><b>@Error</b></p>
                </blockquote>
                <p><em>Detalles de la StackTrace:</em></p>
                <blockquote>
                <p><b>@stack</b></p>
                </blockquote>";
                    if (ex.StackTrace != null)
                        m.ContenidoHTML = m.ContenidoHTML.Replace("@Error", ex.Message.ToString()).Replace("@stack", ex.StackTrace.ToString());
                    else
                        m.ContenidoHTML = m.ContenidoHTML.Replace("@Error", ex.Message.ToString()).Replace("@stack", "Sin detalles.");
                }

                m.ContenidoHTML += @"<p><em>Detalles técnicos:</em></p>
                <blockquote>
                <p><b>@detTecnicos</b></p>
                </blockquote>

                <p>Favor de no responder a este correo.</p>";

                m.ContenidoHTML = m.ContenidoHTML.Replace("@Mensaje", mensaje).Replace("@detTecnicos", detallesTecnicos);

                Thread tread = new Thread(Hilo);
                tread.Start(m);
            }
            catch (Exception ex2)
            {
                throw new Exception(ex2.Message);
            }
        }
        public static void EnviarMailAtencion(String mensaje, String asunto, String detallesTecnicos, Exception ex, String emails, List<Adjunto> adjuntos)
        {
            try
            {
                if (emails.Trim().Equals("")) return;
                Mail m = new Mail();
                m.Asunto = asunto;
                m.EmailDestino = emails;
                m.ArchivosAdjuntos = adjuntos;
                m.ContenidoHTML = @"<b><FONT FACE=""arial"" SIZE=3 COLOR=red>Favor de atender este correo.</FONT></b>
                <p ALIGN=center><IMG SRC=""http://esh30.esoft.com.mx/Sistema/include/Archivos/33/37/Imagenes/PI333720118105552528.png"" WIDTH=200 HEIGHT=140></p>
                <p><em>Mensaje del error:</em></p>
                <blockquote>
                <p><b>@Mensaje</b></p>
                </blockquote>";
                if (ex != null)
                {
                    m.ContenidoHTML += @"<p><em>Detalles de la exception:</em></p>
                <blockquote>
                <p><b>@Error</b></p>
                </blockquote>
                <p><em>Detalles de la StackTrace:</em></p>
                <blockquote>
                <p><b>@stack</b></p>
                </blockquote>";

                    m.ContenidoHTML = m.ContenidoHTML.Replace("@Error", ex.Message.ToString()).Replace("@stack", ex.StackTrace.ToString());
                }

                m.ContenidoHTML += @"<p><em>Detalles técnicos:</em></p>
                <blockquote>
                <p><b>@detTecnicos</b></p>
                </blockquote>

                <p>Favor de no responder a este correo.</p>";

                m.ContenidoHTML = m.ContenidoHTML.Replace("@Mensaje", mensaje).Replace("@detTecnicos", detallesTecnicos);

                Thread tread = new Thread(Hilo);
                tread.Start(m);
            }
            catch (Exception ex2) { throw new Exception(ex2.Message); }
        }
        public static void EnviarMailInformacion(String mensaje, String asunto, String emails, List<Adjunto> adjuntos)
        {
            try
            {
                if (emails.Trim().Equals("")) return;
                Mail m = new Mail();
                m.Asunto = asunto;
                m.EmailDestino = emails;
                m.ArchivosAdjuntos = adjuntos;
                m.ContenidoHTML = @"<b><FONT FACE=""arial"" SIZE=3 COLOR=black>Correo informativo</FONT></b>
                <p ALIGN=center><IMG SRC=""http://esh30.esoft.com.mx/Sistema/include/Archivos/33/37/Imagenes/PI333720118105552528.png"" WIDTH=200 HEIGHT=140></p>
                <p><em>Detalles del mensaje:</em></p>
                <blockquote>
                <p><b>@Mensaje</b></p>
                </blockquote>

                <p>Favor de no responder a este correo.</p>".Replace("@Mensaje", mensaje);

                Thread tread = new Thread(Hilo);

                tread.Start(m);
            }
            catch (Exception ex2) { throw new Exception(ex2.Message); }
        }
        private static void Hilo(Object mail)
        {
            try
            {
                Mail m = (Mail)mail;
                m.EnviarCorreo(Mail.Prioridad.Alta);
                if (correoEnviado != null) correoEnviado();
            }
            catch (Exception ex)
            {
                if (errorEnviarCorreo != null) errorEnviarCorreo(ex.Message);
            }
        }
    }
}
