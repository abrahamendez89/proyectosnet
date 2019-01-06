using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Herramientas.ORM;

namespace Dominio.Sistema
{
    public class _sis_Contenedor: ObjetoBase
    {

        private String _sTitulo;
        private List<_sis_FormularioPermisosPorRol> _formulariosPermisos;
        private List<_sis_Contenedor> _contenedores;
        private _sis_ImagenAsociada _imagenAsociada;

        public _sis_ImagenAsociada ImagenAsociada
        {
            get {return GetAtributoRelacionado<_sis_ImagenAsociada>("_imagenAsociada");}
            set {SetAtributoRelacionado("_imagenAsociada", value);}
        }
        public List<_sis_Contenedor> Contenedores
        {
            get { _contenedores = GetListaRelacionados< _sis_Contenedor>("_contenedores"); return _contenedores; }
            set { SetListaRelacionados("_contenedores", value); }
        }
        public String STitulo
        {
            get { return _sTitulo; }
            set { _sTitulo = value; }
        }
        public List<_sis_FormularioPermisosPorRol> FormulariosPermisos
        {
            get{return GetListaRelacionados<_sis_FormularioPermisosPorRol>("_formulariosPermisos");}
            set{SetListaRelacionados("_formulariosPermisos", value);}
        }
        #region Consultas usadas
        public static readonly String consultaTodos = "select * from _sis_Contenedor";
        public static readonly String consultaPorID = "select * from _sis_Contenedor where id = @id";
        #endregion
    }
}
