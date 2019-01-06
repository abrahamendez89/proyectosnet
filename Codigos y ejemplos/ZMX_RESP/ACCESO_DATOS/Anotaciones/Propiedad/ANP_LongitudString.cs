using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCESO_DATOS.Anotaciones.Propiedad
{
    [System.AttributeUsage(System.AttributeTargets.Property, Inherited = true)]
    public class ANP_LongitudString : System.Attribute
    {
        public int Minima { get; set; }
        public int Maxima { get; set; }
    }
}
