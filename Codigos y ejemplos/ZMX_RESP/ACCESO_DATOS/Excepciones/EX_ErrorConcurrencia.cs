using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCESO_DATOS.Excepciones
{
    public class EX_ErrorConcurrencia : Exception
    {
        public EX_ErrorConcurrencia(Object objeto, String mensaje, String propiedadError, Int64 valorActual, Int64 valorBD): base(mensaje)
        {
            this.Objeto = objeto;
            this.Mensaje = mensaje;
            this.PropiedadError = propiedadError;
            this.ValorActual = valorActual;
            this.ValorBD = valorBD;
        }
        public Object Objeto { get; set; }
        public String Mensaje { get; set; }
        public String PropiedadError { get; set; }
        public Int64 ValorActual { get; set; }
        public Int64 ValorBD { get; set; }
    }
}

