using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCESO_DATOS.Anotaciones.Propiedad
{
    [System.AttributeUsage(System.AttributeTargets.Property, Inherited = true)]
    public class ANP_PrecisionNumerica : System.Attribute
    {
        public int Enteros { get; set; }
        public int Decimales { get; set; }
        public double NumeroMaximo { get; set; }
        public double NumeroMinimo { get; set; }
    }
}
