using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herramientas.ORM;

namespace Dominio.Modulos.General
{
    public class _gen_EquivalenciaEntreUnidadesMedidas: ObjetoBase
    {
        private _gen_UnidadDeMedida _oo_medida1;
        private double _do_cantidad;
        private _gen_UnidadDeMedida _oo_medida2;

        public _gen_UnidadDeMedida Oo_medida1
        {
            get { return _oo_medida1; }
            set { _oo_medida1 = value; }
        }
        public double Do_cantidad
        {
            get { return _do_cantidad; }
            set { _do_cantidad = value; }
        }
        public _gen_UnidadDeMedida Oo_medida2
        {
            get { return _oo_medida2; }
            set { _oo_medida2 = value; }
        }
    }
}
