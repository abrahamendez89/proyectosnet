using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class _ClaseA:ObjetoBase
    {
        private String _st_atributo1;

        public String St_atributo1
        {
            get { return _st_atributo1; }
            set { _st_atributo1 = value; }
        }
        private int _in_atributo2;

        public int In_atributo2
        {
            get { return _in_atributo2; }
            set { _in_atributo2 = value; }
        }
        private _ClaseB _oo_classB;

        public _ClaseB Oo_classB
        {
            get { return _oo_classB; }
            set { _oo_classB = value; }
        }

    }
}
