using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herramientas.ORM;

namespace Dominio.Modulos.ProgramaSiembra
{
    public class _ps_ContenedorDetalle:ObjetoBase
    {
        #region atributos privados
        private _ps_Contenedor _oo_ContenedorUtilizar;
        private _ps_Substrato _oo_SubstratoUtilizar;

        
        #endregion

        #region propiedades publicas
        public _ps_Contenedor Oo_ContenedorUtilizar
        {
            get { return GetAtributoRelacionado<_ps_Contenedor>("_oo_ContenedorUtilizar"); }
            set { SetAtributoRelacionado("_oo_ContenedorUtilizar", value); }
        }
        public _ps_Substrato Oo_SubstratoUtilizar
        {
            get { return GetAtributoRelacionado<_ps_Substrato>("_oo_SubstratoUtilizar"); }
            set { SetAtributoRelacionado("_oo_SubstratoUtilizar", value); }
        }
        #endregion

        #region consultas
        #endregion
    }
}
