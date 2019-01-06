//using AccesoDatos.Mapeo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dominio;
using System.Drawing;
using Herramientas.ORM;

namespace Dominio.Sistema
{
    public class _sis_Formulario: ObjetoBase
    {
        private String _sTituloFormulario;
        private String _sReferenciaFormulario;
        private String _sDescripcion;
        private Boolean _bPermiteMultiples;
        private _sis_ImagenAsociada _imagenAsociada;

        public String SDescripcion
        {
            get { return _sDescripcion; }
            set { _sDescripcion = value; }
        }
        public _sis_ImagenAsociada ImagenAsociada
        {
            get { return GetAtributoRelacionado<_sis_ImagenAsociada>("_imagenAsociada"); }
            set { SetAtributoRelacionado("_imagenAsociada", value); }
        }

        public Boolean BPermiteMultiples
        {
            get { return _bPermiteMultiples; }
            set { _bPermiteMultiples = value; }
        }
        public String STituloFormulario
        {
            get { return _sTituloFormulario; }
            set { _sTituloFormulario = value; }
        }
        public String SReferenciaFormulario
        {
            get { return _sReferenciaFormulario; }
            set { _sReferenciaFormulario = value; }
        }

        #region Consultas usadas
        public static readonly String consultaTodos = "select * from _sis_Formulario";
        public static readonly String consultaPorTitulo = "select * from _sis_Formulario where _sTituloFormulario = @_sTituloFormulario";
        #endregion
    }
}
