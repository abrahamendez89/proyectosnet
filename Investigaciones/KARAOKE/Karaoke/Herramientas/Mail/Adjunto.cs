using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Herramientas.Mail
{
    public class Adjunto
    {
        public System.IO.MemoryStream Stream { get; set; }
        public String NombreArchivo { get; set; }
    }
}
