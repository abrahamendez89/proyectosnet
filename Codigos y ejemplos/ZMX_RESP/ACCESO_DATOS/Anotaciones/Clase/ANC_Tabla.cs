using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCESO_DATOS.Anotaciones.Clase
{
    [System.AttributeUsage(System.AttributeTargets.Class, Inherited = true)]
    public class ANC_Tabla : System.Attribute
    {
        public String Nombre { get; set; }
    }
}
