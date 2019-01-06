using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class _ClaseB:ObjetoBase
    {
        private String _st_atributo1;

        public String St_atributo1
        {
            get { return _st_atributo1; }
            set { _st_atributo1 = value; }
        }
        private _ClaseA _oo_classA;

        public _ClaseA Oo_classA
        {
            get { return _oo_classA; }//CargarAtributoRelacionado<_ClaseA>("_oo_classA"); }
            set { _oo_classA= value;}//setAtributoRelacionado("_oo_classA", value); }
        }
        private List<_ClaseA> _ll_classALista;

        public List<_ClaseA> Ll_classALista
        {
            get { return _ll_classALista; }//CargarListaRelacionados<_ClaseA>("_ll_classALista"); }
            set { _ll_classALista = value; }// SetListaRelacionados("_ll_classALista",value); }
        }
    }
}
