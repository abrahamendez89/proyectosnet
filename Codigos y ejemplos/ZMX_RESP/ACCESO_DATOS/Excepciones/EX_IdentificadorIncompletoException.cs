using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCESO_DATOS.Excepciones
{
    public class EX_IdentificadorIncompletoException : Exception
    {
        public EX_IdentificadorIncompletoException(Object objeto, String mensaje, String propiedadError): base(mensaje)
        {
            this.Objeto = objeto;
            this.Mensaje = mensaje;
            this.PropiedadError = propiedadError;
        }
        public Object Objeto { get; set; }
        public String Mensaje { get; set; }
        public String PropiedadError { get; set; }
    }
}

