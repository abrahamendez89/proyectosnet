using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCESO_DATOS.Anotaciones.Clase
{
    [System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class ANC_IDFormadoParte : System.Attribute
    {
        public short Orden { get; set; }
        public short Digitos { get; set; }
        public String Propiedad { get; set; }
        public String Columna { get; set; }
        public Boolean EsConsecutivo { get; set; }
    }
}
