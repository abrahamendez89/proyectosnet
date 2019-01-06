using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCESO_DATOS.Anotaciones.Clase
{
    [System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class ANC_Identificador : System.Attribute
    {
        public String Propiedad { get; set; }
        public String Columna { get; set; }
    }
}
