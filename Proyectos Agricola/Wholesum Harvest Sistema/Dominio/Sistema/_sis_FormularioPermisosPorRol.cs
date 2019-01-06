using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herramientas.ORM;

namespace Dominio.Sistema
{
    [Serializable]
    public class _sis_FormularioPermisosPorRol :ObjetoBase
    {
        private _sis_Formulario _formulario;
        private String _metodosPermisos;

        public String MetodosPermisos
        {
            get { return _metodosPermisos; }
            set { _metodosPermisos = value; }
        }

        public _sis_Formulario Formulario
        {
            get { return GetAtributoRelacionado<_sis_Formulario>("_formulario"); }
            set { SetAtributoRelacionado("_formulario",value); }
        }

        public static readonly String ConsultaPorID = "select * from _sis_FormularioPermisosPorRol where id = @id";
        public static readonly String ConsultaTodos = "select * from _sis_FormularioPermisosPorRol";

    }
}
