using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herramientas.ORM;

namespace Dominio.Sistema
{
    public class _sis_EquiposRegistrados:ObjetoBase
    {
        private String _sNombreEquipo;
        private String _sUltimaIPConexion;
        private _sis_Usuario _UltimoUsuarioConexion;
        private Boolean _bEstaConectado;
        private Boolean _bEstaBloqueado;
        private String _sUltimaIPInternet;

        public String SUltimaIPInternet
        {
            get { return _sUltimaIPInternet; }
            set { _sUltimaIPInternet = value; }
        }

        public String SNombreEquipo
        {
            get { return _sNombreEquipo; }
            set { _sNombreEquipo = value; }
        }
        
        public String SUltimaIPConexion
        {
            get { return _sUltimaIPConexion; }
            set { _sUltimaIPConexion = value; }
        }
        
        public _sis_Usuario UltimoUsuarioConexion
        {
            get { return  GetAtributoRelacionado<_sis_Usuario>("_UltimoUsuarioConexion"); }
            set { SetAtributoRelacionado("_UltimoUsuarioConexion",value); }
        }
        
        public Boolean BEstaConectado
        {
            get { return _bEstaConectado; }
            set { _bEstaConectado = value; }
        }
        
        public Boolean BEstaBloqueado
        {
            get { return _bEstaBloqueado; }
            set { _bEstaBloqueado = value; }
        }

        #region consultas
        public static readonly String ConsultaPorNombreEquipo = "select * from _sis_EquiposRegistrados where _sNombreEquipo = @_sNombreEquipo";
        #endregion
    }
}
