using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicaNegocios
{
    public class LogicaNegociosBase
    {

        public delegate Boolean EnviarMensaje(Exception exception, String mensaje, String titulo, MensajeException.TipoMensaje tipoMensaje);
        public event EnviarMensaje enviarMensaje;
        public delegate Boolean EnviarNotificacion(String mensaje, String titulo, MensajeException.TipoMensaje tipoMensaje);
        public event EnviarNotificacion enviarNotificacion;

        protected Boolean MT_EnviarMensaje(Exception exception, String mensaje, String titulo, MensajeException.TipoMensaje tipoMensaje)
        {
            if(this.enviarMensaje != null)
                return this.enviarMensaje(exception,mensaje, titulo, tipoMensaje);
            return false;
        }
        protected Boolean MT_EnviarMensaje(String mensaje, String titulo, MensajeException.TipoMensaje tipoMensaje)
        {
            if (this.enviarMensaje != null)
                return this.enviarMensaje(null, mensaje, titulo, tipoMensaje);
            return false;
        }
    }
}
