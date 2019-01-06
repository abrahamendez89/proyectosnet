using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herramientas.ORM;

namespace Dominio.Sistema
{
    public class _sis_AccesoFallido:ObjetoBase
    {
        private String _sUsuarioRegistrado;
        private String _sContrasenaRegistrada;
        private String _sNombreEquipo;
        private String _sIPEquipo;
        private String _sUsuarioWindows;
        private String _sIpInternet;

        public String SIpInternet
        {
            get { return _sIpInternet; }
            set { _sIpInternet = value; }
        }

        public String SUsuarioRegistrado
        {
            get { return _sUsuarioRegistrado; }
            set { _sUsuarioRegistrado = value; }
        }
        
        public String SContrasenaRegistrada
        {
            get { return _sContrasenaRegistrada; }
            set { _sContrasenaRegistrada = value; }
        }
        
        public String SNombreEquipo
        {
            get { return _sNombreEquipo; }
            set { _sNombreEquipo = value; }
        }
        
        public String SIPEquipo
        {
            get { return _sIPEquipo; }
            set { _sIPEquipo = value; }
        }
        
        public String SUsuarioWindows
        {
            get { return _sUsuarioWindows; }
            set { _sUsuarioWindows = value; }
        }
    }
}
