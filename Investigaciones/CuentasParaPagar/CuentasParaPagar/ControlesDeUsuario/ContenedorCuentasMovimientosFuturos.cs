using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dominio;

namespace CuentasParaPagar.ControlesDeUsuario
{
    public partial class ContenedorCuentasMovimientosFuturos : UserControl
    {
        public delegate void ActualizarSaldosEvento();
        public event ActualizarSaldosEvento actualizarSaldosEvento;

        public ContenedorCuentasMovimientosFuturos()
        {
            InitializeComponent();
            this.Resize += ContenedorCuentasMovimientosFuturos_Resize;
        }

        public void CargarCuentas(List<_Cuenta> cuentas)
        {
            pnl_cuentas.Controls.Clear();
            if (cuentas != null)
            {
                foreach (_Cuenta cuenta in cuentas)
                {
                    MovimientosFuturosDeCuenta movimientos = new MovimientosFuturosDeCuenta();
                    movimientos.actualizarSaldosEvento += movimientos_actualizarSaldosEvento;
                    movimientos.CargarCuenta(cuenta);
                    if (movimientos.HayMovimientos)
                        pnl_cuentas.Controls.Add(movimientos);
                }
            }
        }

        void movimientos_actualizarSaldosEvento()
        {
            actualizarSaldosEvento();
        }

        void ContenedorCuentasMovimientosFuturos_Resize(object sender, EventArgs e)
        {
            AjustarTama();
        }
        public void AjustarTama()
        {
            foreach (Control control in pnl_cuentas.Controls)
            {
                control.Width = pnl_cuentas.Width - 25;
            }
        }
    }
}
