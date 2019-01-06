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
    public partial class SaldoAlDiaCuenta : UserControl
    {
        public SaldoAlDiaCuenta()
        {
            InitializeComponent();
            this.MouseEnter += SaldoAlDiaCuenta_MouseEnter;
            pb_imagen.MouseEnter += SaldoAlDiaCuenta_MouseEnter;
            lbl_saldo.MouseEnter += SaldoAlDiaCuenta_MouseEnter;
            lbl_nombreCuenta.MouseEnter += SaldoAlDiaCuenta_MouseEnter;


            this.MouseLeave += SaldoAlDiaCuenta_MouseLeave;
            pb_imagen.MouseLeave += SaldoAlDiaCuenta_MouseLeave;
            lbl_saldo.MouseLeave += SaldoAlDiaCuenta_MouseLeave;
            lbl_nombreCuenta.MouseLeave += SaldoAlDiaCuenta_MouseLeave;

            this.MouseClick += SaldoAlDiaCuenta_MouseClick;
            pb_imagen.MouseClick += SaldoAlDiaCuenta_MouseClick;
            lbl_saldo.MouseClick += SaldoAlDiaCuenta_MouseClick;
            lbl_nombreCuenta.MouseClick += SaldoAlDiaCuenta_MouseClick;

            colorFondo = this.BackColor;
        }
        Color colorFondo;
        void SaldoAlDiaCuenta_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.LightBlue;
        }

        void SaldoAlDiaCuenta_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = colorFondo;
        }

        void SaldoAlDiaCuenta_MouseClick(object sender, MouseEventArgs e)
        {
            HistorialDeMovimientos fut = new HistorialDeMovimientos(cuenta.SQL, cuenta);
            fut.ShowDialog();
        }
        _Cuenta cuenta;
        public void AsignarCuenta(_Cuenta cuenta)
        {
            this.cuenta = cuenta;
            pb_imagen.Image = cuenta.Bm_Imagen;
            lbl_nombreCuenta.Text = cuenta.St_NombreCuenta;
            lbl_saldo.Text = Herramientas.Conversiones.Formatos.DoubleAMonedaANDecimales(cuenta.Do_saldo, 2);
        }
    }
}
