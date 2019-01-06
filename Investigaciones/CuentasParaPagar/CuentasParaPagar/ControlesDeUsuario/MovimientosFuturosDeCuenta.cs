using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dominio;
using CuentasParaPagar.Consultas;

namespace CuentasParaPagar.ControlesDeUsuario
{
    public partial class MovimientosFuturosDeCuenta : UserControl
    {
        public Boolean HayMovimientos { get; set; }
        List<DateTime> dias = new List<DateTime>();

        public delegate void ActualizarSaldosEvento();
        public event ActualizarSaldosEvento actualizarSaldosEvento;

        public MovimientosFuturosDeCuenta()
        {
            InitializeComponent();

            for (int i = 0; i < 7; i++)
            {
                DateTime dia = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                dia = dia.AddDays(1 * i);
                dias.Add(dia);
            }
        }
        public void CargarCuenta(_Cuenta cuenta)
        {
            pb_imagen.Image = cuenta.Bm_Imagen;
            ll_nombreCuenta.Text = cuenta.St_NombreCuenta;
            ll_nombreCuenta.Tag = cuenta;
            pnl_dias.Controls.Clear();
            ll_nombreCuenta.Click += ll_nombreCuenta_Click;
            
            List<_MovimientoCuenta> movimientos = new List<_MovimientoCuenta>();

            foreach (DateTime dia in dias)
            {
                movimientos.Clear();
                MovimientosEnUnDia movDia = new MovimientosEnUnDia();
                if (cuenta.Ll_Movimientos != null)
                {
                    foreach (_MovimientoCuenta movimiento in cuenta.Ll_Movimientos)
                    {

                        if (new DateTime(movimiento.Dt_fechaAplicacion.Year, movimiento.Dt_fechaAplicacion.Month, movimiento.Dt_fechaAplicacion.Day) == dia)
                        {

                            movimientos.Add(movimiento);

                        }
                    }
                }
                if (cuenta.Ll_MovimientosSimulados != null)
                {
                    foreach (_MovimientoCuenta movimientoSimulado in cuenta.Ll_MovimientosSimulados)
                    {

                        if (new DateTime(movimientoSimulado.Dt_fechaAplicacion.Year, movimientoSimulado.Dt_fechaAplicacion.Month, movimientoSimulado.Dt_fechaAplicacion.Day) == dia)
                        {

                            movimientos.Add(movimientoSimulado);

                        }
                    }
                }
                movDia.actualizarSaldosEvento += movDia_actualizarSaldosEvento;
                movDia.CargarMovimientos(cuenta, dia, movimientos);
                if(movDia.HayMovimientos)
                    HayMovimientos = true;
                pnl_dias.Controls.Add(movDia);
            }
        }

        void movDia_actualizarSaldosEvento()
        {
            actualizarSaldosEvento();
        }

        void ll_nombreCuenta_Click(object sender, EventArgs e)
        {
            LinkLabel ll = (LinkLabel)sender;
            _Cuenta cuenta = (_Cuenta)ll.Tag;
            ProyeccionFutura proy = new ProyeccionFutura(cuenta.SQL, cuenta);
            proy.ShowDialog();
            actualizarSaldosEvento();
        }
    }
}
