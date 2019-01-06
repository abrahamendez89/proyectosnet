using Herramientas.ORM;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class _Cuenta:ObjetoBase
    {
        private String _st_NombreCuenta;
        private Bitmap _bm_Imagen;
        private List<_MovimientoCuenta> _ll_Movimientos;
        private int _in_DiasParaPago;
        private int _in_DiaCorte;
        private Double _do_PorcentajeInteresMensual;
        private double _do_saldo;
        private List<_MovimientoCuenta> _ll_MovimientosSimulados;
        private Boolean _bo_EsDeAhorro;

        public Boolean Bo_EsDeAhorro
        {
            get { return _bo_EsDeAhorro; }
            set { _bo_EsDeAhorro = value; }
        }

        public List<_MovimientoCuenta> Ll_MovimientosSimulados
        {
            get { return GetListaRelacionados<_MovimientoCuenta>("_ll_MovimientosSimulados"); }
            set { SetListaRelacionados("_ll_MovimientosSimulados", value); }
        }

        public double Do_saldo
        {
            get { return _do_saldo; }
            set { _do_saldo = value; }
        }

        public int In_DiasParaPago
        {
            get { return _in_DiasParaPago; }
            set { _in_DiasParaPago = value; }
        }
        
        public int In_DiaCorte
        {
            get { return _in_DiaCorte; }
            set { _in_DiaCorte = value; }
        }
       

        public Double Do_PorcentajeInteresMensual
        {
            get { return _do_PorcentajeInteresMensual; }
            set { _do_PorcentajeInteresMensual = value; }
        }

        public String St_NombreCuenta
        {
            get { return _st_NombreCuenta; }
            set { _st_NombreCuenta = value; }
        }
        public Bitmap Bm_Imagen
        {
            get { return _bm_Imagen; }
            set { _bm_Imagen = value; }
        }
        public List<_MovimientoCuenta> Ll_Movimientos
        {
            get { return GetListaRelacionados<_MovimientoCuenta>("_ll_Movimientos"); }
            set { SetListaRelacionados("_ll_Movimientos", value); }
        }
    }
}
