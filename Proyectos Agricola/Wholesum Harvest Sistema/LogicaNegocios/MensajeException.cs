using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicaNegocios
{
    public class MensajeException: Exception
    {
        private Boolean esError;
        private String mensaje;
        private String referencia;
        private TipoMensaje tipoMensaje;
        public enum TipoMensaje
        {
            Pregunta = 0,
            Mensaje = 1,
            Advertencia = 2,
            Error = 3,
            Informacion = 4,
            PreguntaAdvertencia = 5,
            AdvertenciaAlta = 6,
            ErrorSimple = 7
        }


        public MensajeException(Exception exception, String referencia)
            : base(exception.Message)
        {
            this.esError = true;
            this.mensaje = exception.Message;
            this.referencia = referencia;
        }
        public MensajeException(String mensaje, TipoMensaje tipoMensaje)
            : base(mensaje)
        {
            this.mensaje = mensaje;
            this.tipoMensaje = tipoMensaje;
        }
        public Boolean EsError { get { return esError; } }
        public TipoMensaje Tipo { get { return tipoMensaje; } }
        public String Mensaje
        {
            get
            {
                if (esError)
                {
                    return "Error: " + mensaje + " [" + referencia + "]";
                }
                else
                {
                    return mensaje;
                }
            }
        }
    }
}
