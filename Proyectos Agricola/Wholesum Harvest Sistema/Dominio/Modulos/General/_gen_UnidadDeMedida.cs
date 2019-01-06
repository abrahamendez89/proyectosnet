using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herramientas.ORM;

namespace Dominio.Modulos.General
{
    public class _gen_UnidadDeMedida:ObjetoBase
    {
        #region Atributos privados
        private String _st_Nombre;
        private _gen_CategoriaUnidadMedida _oo_Categoria;
        #endregion
        #region Propiedades publicas
        public _gen_CategoriaUnidadMedida Oo_Categoria
        {
            get { return GetAtributoRelacionado<_gen_CategoriaUnidadMedida>("_oo_Categoria"); }
            set { SetAtributoRelacionado("_oo_Categoria", value); }
        }
        public String St_Nombre
        {
            get { return _st_Nombre; }
            set { _st_Nombre = value; }
        }
        #endregion
        #region Consultas publicas
        #endregion
    }
}
