
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dominio;
using Herramientas.ORM;

namespace Dominio.Sistema
{
    public class _sis_Rol:ObjetoBase
    {
        private String _sDescripcion;
        private String _sNombre;
        private List<_sis_Contenedor> _contenedores;
        private _sis_ImagenAsociada _imagenAsociada;
        private Boolean _bEsAdministradorDeSistema;
        private Boolean _bPuedeAccederCatalogoRapido;

        public Boolean BPuedeAccederCatalogoRapido
        {
            get { return _bPuedeAccederCatalogoRapido; }
            set { _bPuedeAccederCatalogoRapido = value; }
        }

        public Boolean EsAdministradorDeSistema
        {
            get { return _bEsAdministradorDeSistema; }
            set { _bEsAdministradorDeSistema = value; }
        }
        public _sis_ImagenAsociada ImagenAsociada
        {
            get { return GetAtributoRelacionado<_sis_ImagenAsociada>("_imagenAsociada"); }
            set { SetAtributoRelacionado("_imagenAsociada", value); }
        }
        public List<_sis_Contenedor> Contenedores
        {
            get 
            {
                _contenedores = GetListaRelacionados< _sis_Contenedor>("_contenedores");
                return _contenedores;
            }
            set 
            {
                SetListaRelacionados("_contenedores", value);
            }
        }
        public String Nombre
        {
            get { return _sNombre; }
            set { _sNombre = value; }
        }
        public String Descripcion
        {
            get { return _sDescripcion; }
            set { _sDescripcion = value; }
        }
        #region consultas
        public static readonly String ConsultaTodos = "select * from _sis_Rol";
        public static readonly String ConsultaPorNombre = "select * from _sis_Rol where _sNombre = @_sNombre";
        #endregion
    }
}
