using Herramientas.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class _SolicitudSoporte:ObjetoBase
    {
        private String _NombreEquipo;
        private String _ip;
        private String _ComentarioInicial;
        private DateTime _HoraSolicitud;
        private String _UsuarioWindows;
        private String _ResultadoDeSoporte;
        private Boolean _Atendido;
        private String _AtendidoPor;

        public String NombreEquipo
        {
            get { return _NombreEquipo; }
            set { _NombreEquipo = value; }
        }
        
        public String Ip
        {
            get { return _ip; }
            set { _ip = value; }
        }
        
        public DateTime HoraSolicitud
        {
            get { return _HoraSolicitud; }
            set { _HoraSolicitud = value; }
        }
        

        public String ComentarioInicial
        {
            get { return _ComentarioInicial; }
            set { _ComentarioInicial = value; }
        }
        
        public String UsuarioWindows
        {
            get { return _UsuarioWindows; }
            set { _UsuarioWindows = value; }
        }
        
        public String ResultadoDeSoporte
        {
            get { return _ResultadoDeSoporte; }
            set { _ResultadoDeSoporte = value; }
        }
        
        public Boolean Atendido
        {
            get { return _Atendido; }
            set { _Atendido = value; }
        }
        
        public String AtendidoPor
        {
            get { return _AtendidoPor; }
            set { _AtendidoPor = value; }
        }
    }
}
