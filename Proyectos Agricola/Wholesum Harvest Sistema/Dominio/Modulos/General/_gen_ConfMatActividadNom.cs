using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herramientas.ORM;

namespace Dominio.Modulos.General
{
    public class _gen_ConfMatActividadNom:ObjetoBase
    {
        #region atributos privados
        private _gen_Material _oo_MaterialAUsar;
        private _gen_Formula _oo_FormulaCalculoMaterial;
        #endregion
        #region propiedades publicas
        public _gen_Formula Oo_FormulaCalculoMaterial
        {
            get { return GetAtributoRelacionado<_gen_Formula>("_oo_FormulaCalculoMaterial"); }
            set { SetAtributoRelacionado("_oo_FormulaCalculoMaterial", value); }
        }
        public _gen_Material Oo_MaterialAUsar
        {
            get { return GetAtributoRelacionado<_gen_Material>("_oo_MaterialAUsar"); }
            set { SetAtributoRelacionado("_oo_MaterialAUsar",value); }
        }
        #endregion
    }
}
