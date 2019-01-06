using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCESO_DATOS.Anotaciones.Propiedad
{
    [System.AttributeUsage(System.AttributeTargets.Property, Inherited = true)]
    public class ANP_Configuracion : System.Attribute
    {
        public Boolean Nullable { get; set; }
        public Object ValorDefault { get; set; }
    }
}
