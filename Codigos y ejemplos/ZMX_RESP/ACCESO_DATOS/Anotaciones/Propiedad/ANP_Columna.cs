using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCESO_DATOS.Anotaciones.Propiedad
{
    [System.AttributeUsage(System.AttributeTargets.Property, Inherited = true)]
    public class ANP_Columna : System.Attribute
    {
        public String Columna { get; set; }
    }
}
