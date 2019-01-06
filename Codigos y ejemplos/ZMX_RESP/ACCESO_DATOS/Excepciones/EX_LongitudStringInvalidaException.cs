using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCESO_DATOS.Excepciones
{
    public class EX_LongitudStringInvalidaException:Exception
    {
        public EX_LongitudStringInvalidaException(Object objeto, String mensaje, String propiedadError, String propiedadValor, int longitudMaxima, int longitudMinima): base(mensaje)
        {
            this.Objeto = objeto;
            this.Mensaje = mensaje;
            this.PropiedadError = propiedadError;
            this.PropiedadValor = propiedadValor;
            this.LongitudMaxima = longitudMaxima;
            this.LongitudMinima = longitudMinima;
        }
        public Object Objeto { get; set; }
        public String Mensaje { get; set; }
        public String PropiedadError { get; set; }
        public String PropiedadValor { get; set; }
        public int LongitudMaxima { get; set; }
        public int LongitudMinima { get; set; }
    }
}

