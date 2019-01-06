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
    public partial class ContenedorSaldosAlDiaCuentas : UserControl
    {
        public ContenedorSaldosAlDiaCuentas()
        {
            InitializeComponent();
            pnl_cuentas.Controls.Clear();
        }
        public void CargarCuentas(List<_Cuenta> cuentas)
        {
            pnl_cuentas.Controls.Clear();
            if (cuentas != null)
                foreach (_Cuenta cuenta in cuentas)
                {
                    SaldoAlDiaCuenta sac = new SaldoAlDiaCuenta();
                    sac.AsignarCuenta(cuenta);
                    pnl_cuentas.Controls.Add(sac);
                }
        }
    }
}
