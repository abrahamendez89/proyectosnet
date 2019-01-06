using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herramientas.ORM;

namespace Dominio.Modulos.ProgramaSiembra
{
    public class _ps_DatosInjerto:ObjetoBase
    {
        #region atributos privados
        private _ps_VariedadSemilla _oo_VariedadRaiz;
        private _ps_VariedadSemilla _oo_VariedadProductiva;
        #endregion

        #region propiedades publicas
        public _ps_VariedadSemilla Oo_VariedadRaiz
        {
            get { return GetAtributoRelacionado<_ps_VariedadSemilla>("_oo_VariedadRaiz"); }
            set { SetAtributoRelacionado("_oo_VariedadRaiz", value); }
        }
        public _ps_VariedadSemilla Oo_VariedadProductiva
        {
            get { return GetAtributoRelacionado<_ps_VariedadSemilla>("_oo_VariedadProductiva"); }
            set { SetAtributoRelacionado("_oo_VariedadProductiva", value); }
        }
        #endregion

        #region consultas
        #endregion
    }
}
