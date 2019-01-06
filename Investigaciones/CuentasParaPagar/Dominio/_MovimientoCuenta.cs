using Herramientas.ORM;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class _MovimientoCuenta:ObjetoBase
    {
        private _Cuenta _oo_Cuenta;
        private double _do_Importe;
        private double _do_Saldo;
        private DateTime _dt_fecha;
        private _TipoMovimiento _oo_TipoMovimiento;
        private DateTime _dt_fechaAplicacion;
        private String _st_detalleMovimiento;
        private Boolean _bo_EsSimulado;
        private _MovimientoCuenta _oo_MovimientoPareja;
        private Boolean _bo_EstaAplicadoAlSaldo;
        private Color ColorMovimiento;

        public Boolean Bo_EstaAplicadoAlSaldo
        {
            get { return _bo_EstaAplicadoAlSaldo; }
            set { _bo_EstaAplicadoAlSaldo = value; }
        }

        public Color ColorMovimiento1
        {
            get { return ColorMovimiento; }
            set { ColorMovimiento = value; }
        }

        public _MovimientoCuenta Oo_MovimientoPareja
        {
            get { return GetAtributoRelacionado<_MovimientoCuenta>("_oo_MovimientoPareja"); }
            set { SetAtributoRelacionado("_oo_MovimientoPareja", value); }
        }

        public Boolean Bo_EsSimulado
        {
            get { return _bo_EsSimulado; }
            set { _bo_EsSimulado = value; }
        }


        public String St_detalleMovimiento
        {
            get { return _st_detalleMovimiento; }
            set { _st_detalleMovimiento = value; }
        }
        public DateTime Dt_fechaAplicacion
        {
            get { return _dt_fechaAplicacion; }
            set { _dt_fechaAplicacion = value; }
        }

        public DateTime Dt_fecha
        {
            get { return _dt_fecha; }
            set { _dt_fecha = value; }
        }
        public double Do_Saldo
        {
            get { return _do_Saldo; }
            set { _do_Saldo = value; }
        }
        public _TipoMovimiento Oo_TipoMovimiento
        {
            get { return GetAtributoRelacionado<_TipoMovimiento>("_oo_TipoMovimiento"); }
            set { SetAtributoRelacionado("_oo_TipoMovimiento", value); }
        }

        public _Cuenta Oo_Cuenta
        {
            get { return GetAtributoRelacionado<_Cuenta>("_oo_Cuenta"); }
            set { SetAtributoRelacionado("_oo_Cuenta",value); }
        }
        

        public double Do_Importe
        {
            get { return _do_Importe; }
            set { _do_Importe = value; }
        }
    }
}
