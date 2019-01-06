using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karaoke.Clases
{
    public class IdentificadorLicencia
    {
        public String MAC { get; set; }
        public String NombreEquipo { get; set; }
        public String UsuarioWindows { get; set; }
        public String VersionWindows { get; set; }
        public String IDTarjetaMADRE { get; set; }
        public DateTime FechaPrimeraVez { get; set; }
        public DateTime FechaFIN { get; set; }
        public int IDLicencia { get; set; }
        public DateTime FechaPago { get; set; }
    }
}
