using Herramientas.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class _MantenimientoHabitacion : ObjetoBase
    {
        private _TipoManttoHabitacion _oo_tipoMantenimientoAplicado;
        private double _do_CostoMantenimiento;
        private _Habitacion _oo_habitacionAplicado;

        public _TipoManttoHabitacion Oo_tipoMantenimientoAplicado
        {
            get { return GetAtributoRelacionado<_TipoManttoHabitacion>("_oo_tipoMantenimientoAplicado"); }
            set { SetAtributoRelacionado("_oo_tipoMantenimientoAplicado", value); }
        }
        
        public double Do_CostoMantenimiento
        {
            get { return _do_CostoMantenimiento; }
            set { _do_CostoMantenimiento = value; }
        }
        
        public _Habitacion Oo_habitacionAplicado
        {
            get { return GetAtributoRelacionado<_Habitacion>("_oo_habitacionAplicado"); }
            set { SetAtributoRelacionado("_oo_habitacionAplicado", value); }
        }
    }
}
