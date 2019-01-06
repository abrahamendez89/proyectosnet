using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herramientas.ORM;

namespace Dominio.Modulos.General
{
    public class _gen_MaterialVariableEspecifico:ObjetoBase
    {
        #region atributos privados
        private _gen_Material _oo_MaterialVariable;
        private _gen_Material _oo_MaterialEspecifico;
        #endregion
        #region propiedades publicas
        public _gen_Material Oo_MaterialVariable
        {
            get { return GetAtributoRelacionado<_gen_Material>("_oo_MaterialVariable"); }
            set { SetAtributoRelacionado("_oo_MaterialVariable",value); }
        }
        public _gen_Material Oo_MaterialEspecifico
        {
            get { return GetAtributoRelacionado<_gen_Material>("_oo_MaterialEspecifico"); }
            set { SetAtributoRelacionado("_oo_MaterialEspecifico", value); }
        }
        #endregion
        #region consultas publicas
        #endregion
    }
}
