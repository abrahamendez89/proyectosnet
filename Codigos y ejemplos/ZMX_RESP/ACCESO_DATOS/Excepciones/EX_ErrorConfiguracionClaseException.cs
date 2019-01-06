using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCESO_DATOS.Excepciones
{
    public class EX_ErrorConfiguracionClaseException : Exception
    {
        public EX_ErrorConfiguracionClaseException(Object objeto, String mensaje, String propiedadError, String anotacionInvalida): base(mensaje)
        {
            this.Objeto = objeto;
            this.Mensaje = mensaje;
            this.PropiedadError = propiedadError;
            this.AnotacionInvalida = anotacionInvalida;
        }
        public Object Objeto { get; set; }
        public String Mensaje { get; set; }
        public String PropiedadError { get; set; }
        public String AnotacionInvalida { get; set; }
    }
}

