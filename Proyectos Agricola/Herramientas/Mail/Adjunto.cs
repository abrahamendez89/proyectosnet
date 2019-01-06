using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Herramientas.Mail
{
    public class Adjunto
    {
        public enum TipoAdjunto
        {
            IMAGEN = 0,
            Zip = 1,
            PDF = 2,
            TXT = 3,
            OTRO
        }
        public System.IO.MemoryStream Stream { get; set; }
        public String NombreArchivo { get; set; }
        public TipoAdjunto Tipo { get; set; }

        public static MemoryStream ArchitoAMemoryStream(String dir)
        {
            return Herramientas.Archivos.Archivo.ArchivoAMemoryStream(dir);
        }
    }
}
