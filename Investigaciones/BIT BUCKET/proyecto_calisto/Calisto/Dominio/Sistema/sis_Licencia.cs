using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio.Sistema
{
    public class sis_Licencia
    {
        public String NombreEmpresa { get; set; }
        public String RFC { get; set; }
        public String Telefono { get; set; }
        public DateTime Vigencia { get; set; }
        public long IDLicencia { get; set; }
        public String PaqueteComprado { get; set; }
        public List<String> ModulosPermitidos { get; set; }
    }
}
