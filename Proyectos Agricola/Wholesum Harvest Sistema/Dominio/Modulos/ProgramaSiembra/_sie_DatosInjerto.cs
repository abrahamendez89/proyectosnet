using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio.Modulos.Siembra
{
    public class _sie_DatosInjerto:ObjetoBase
    {
        private _sie_VariedadSemilla _oo_VariedadRaiz;
        private _sie_VariedadSemilla _oo_VariedadProductiva;

        public _sie_VariedadSemilla Oo_VariedadRaiz
        {
            get { return CargarAtributoRelacionado<_sie_VariedadSemilla>("_oo_VariedadRaiz"); }
            set { setAtributoRelacionado("_oo_VariedadRaiz",value); }
        }
   
        public _sie_VariedadSemilla Oo_VariedadProductiva
        {
            get { return CargarAtributoRelacionado<_sie_VariedadSemilla>("_oo_VariedadProductiva"); }
            set { setAtributoRelacionado("_oo_VariedadProductiva", value); }
        }
    }
}
