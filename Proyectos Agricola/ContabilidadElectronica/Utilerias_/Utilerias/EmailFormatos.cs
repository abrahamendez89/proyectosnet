using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Utilerias.Utilerias;

namespace Utilerias.Utilerias
{
    public class EmailFormatos
    {
        public static void EnviarMailError(String mensaje, String asunto, Exception ex, String emails, List<Adjunto> adjuntos)
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
                <p><em>Detalles del error:</em></p>
                <blockquote>
                <p><b>@Mensaje</b></p>
                </blockquote>
                <blockquote>
                <p><b>@Error</b></p>
                </blockquote>

                <p>Favor de no responder a este correo.</p>".Replace("@Error", ex.ToString()).Replace("@Mensaje", mensaje);

                Thread tread = new Thread(Hilo);
                tread.Start(m);
            }
            catch { }
        }
        public static void EnviarMailInformacion(String mensaje,String asunto, String emails, List<Adjunto> adjuntos)
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
            catch { }
        }
        private static void Hilo(Object mail)
        {
            Mail m = (Mail)mail;
            m.EnviarCorreo(Mail.Prioridad.Alta);
        }
    }
}
