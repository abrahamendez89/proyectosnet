using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dominio;
using Herramientas.ORM;

namespace CuentasParaPagar.ControlesDeUsuario
{
    public partial class MovimientosEnUnDia : UserControl
    {
        public Boolean HayMovimientos { get; set; }
        private Color ColorDefault;
        private _Cuenta Cuenta;
        ManejadorDB manejador;

        public delegate void ActualizarSaldosEvento();
        public event ActualizarSaldosEvento actualizarSaldosEvento;

        public MovimientosEnUnDia()
        {
            InitializeComponent();
            this.ColorDefault = this.BackColor;
            this.MouseEnter += MovimientosEnUnDia_MouseEnter;
            this.MouseLeave += MovimientosEnUnDia_MouseLeave;
            lbl_fecha.MouseEnter += MovimientosEnUnDia_MouseEnter;
            pnl_movimientos.MouseEnter += MovimientosEnUnDia_MouseEnter;
            pnl_movimientos.MouseLeave += MovimientosEnUnDia_MouseLeave;
            pb_imagen.MouseLeave += MovimientosEnUnDia_MouseLeave;
            pb_imagen.MouseEnter += MovimientosEnUnDia_MouseEnter;
            lbl_fecha.MouseLeave += MovimientosEnUnDia_MouseLeave;
        }

        void MovimientosEnUnDia_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.LightBlue;
            pnl_movimientos.BackColor = Color.LightBlue;
            foreach (Control control in pnl_movimientos.Controls)
                control.BackColor = Color.LightBlue;
        }

        void MovimientosEnUnDia_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = ColorDefault;
            pnl_movimientos.BackColor = ColorDefault;
            foreach (Control control in pnl_movimientos.Controls)
                control.BackColor = ColorDefault;
        }

        public void CargarMovimientos(_Cuenta cuenta, DateTime Dia, List<_MovimientoCuenta> movimientos)
        {
            Cuenta = cuenta;
            manejador = Cuenta.Manejador;
            lbl_fecha.Text = Herramientas.Conversiones.Formatos.DateTimeAFechaCalendario(Dia);
            pnl_movimientos.Controls.Clear();
            foreach (_MovimientoCuenta movimiento in movimientos)
            {
                HayMovimientos = true;
                Label txt = new Label();
                txt.Cursor = Cursors.Hand;
                txt.Font = this.Font; // new Font("Times New Roman", 8);
                //txt.Enabled = false;
                txt.BackColor = pnl_movimientos.BackColor;
                //txt.BorderStyle = System.Windows.Forms.BorderStyle.None;
                txt.Tag = movimiento;
                double multiplicador = 1;
                if (cuenta.Bo_EsDeAhorro)
                    multiplicador = -1;
                double importe = movimiento.Do_Importe * movimiento.Oo_TipoMovimiento.Do_MultiplicadorSigno * multiplicador;

                if (movimiento.Oo_TipoMovimiento.Do_MultiplicadorSigno > 0)
                    movimiento.ColorMovimiento1 = Color.Red;
                else if (movimiento.Oo_TipoMovimiento.Do_MultiplicadorSigno < 0)
                    movimiento.ColorMovimiento1 = Color.Green;

                txt.Text = movimiento.Oo_TipoMovimiento.St_Nombre + " (" + Herramientas.Conversiones.Formatos.DoubleAMonedaANDecimales(importe, 2) + ")";
                txt.MouseEnter += txt_MouseEnter;
                txt.MouseEnter += MovimientosEnUnDia_MouseEnter;
                txt.MouseLeave += txt_MouseLeave;
                txt.MouseDown += txt_MouseDown;
                txt.MouseUp += txt_MouseUp;
                txt.MouseLeave += MovimientosEnUnDia_MouseLeave;
                txt.Width = txt.Text.Length * 7;
                txt.ForeColor = movimiento.ColorMovimiento1;
                txt.Height = 15;
                pnl_movimientos.Controls.Add(txt);
            }
            if (!HayMovimientos)
            {
                pnl_movimientos.Visible = false;
            }
        }

        void txt_MouseUp(object sender, MouseEventArgs e)
        {
            Label txt = (Label)sender;
            _MovimientoCuenta movimiento = (_MovimientoCuenta)txt.Tag;
            txt.ForeColor = movimiento.ColorMovimiento1;
            if (!movimiento.Bo_EstaAplicadoAlSaldo && movimiento.Bo_EsSimulado)
            {
                //Herramientas.Forms.Mensajes.Informacion("El saldo es igual a 0");
                CambiarMovimiento(movimiento);
            }
        }
        private void BorrarMovimientoDeListado(List<_MovimientoCuenta> movimientos, _MovimientoCuenta movimientoBorrar)
        {
            for (int i = 0; i < movimientos.Count; i++)
            {
                if (movimientos[i].Id == movimientoBorrar.Id)
                {
                    movimientos.RemoveAt(i);
                    break;
                }
            }
        }
        private void CambiarMovimiento(_MovimientoCuenta movimiento)
        {
            try
            {
                if (new DateTime(movimiento.Dt_fechaAplicacion.Year, movimiento.Dt_fechaAplicacion.Month, movimiento.Dt_fechaAplicacion.Day) != new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day))
                {
                    if (Herramientas.Forms.Mensajes.PreguntaAdvertenciaSIoNO("El movimiento simulado esta programado para una fecha posterior, ¿desea cambiar su fecha de aplicación para el dia de hoy?"))
                    {
                        movimiento.Dt_fechaAplicacion = DateTime.Now;
                    }
                    else
                        return;
                }

                if (!Herramientas.Forms.Mensajes.PreguntaAdvertenciaSIoNO("¿Desea aplicar el movimiento simulado como movimiento real?"))
                {
                    return;
                }

                BorrarMovimientoDeListado(Cuenta.Ll_MovimientosSimulados, movimiento);

                double multiplicador = 1;
                if (Cuenta.Bo_EsDeAhorro)
                    multiplicador = -1;
                double importe = movimiento.Do_Importe * movimiento.Oo_TipoMovimiento.Do_MultiplicadorSigno * multiplicador;
                Cuenta.Do_saldo = Cuenta.Do_saldo + importe;
                movimiento.Do_Saldo = Cuenta.Do_saldo;
                Cuenta.Ll_Movimientos.Add(movimiento);
                movimiento.Bo_EsSimulado = false;
                movimiento.EsModificado = true;
                movimiento.Bo_EstaAplicadoAlSaldo = true;
                Cuenta.EsModificado = true;

                _Cuenta cuentaAsociada = null;
                if (movimiento.Oo_MovimientoPareja != null)
                {
                    cuentaAsociada = movimiento.Oo_MovimientoPareja.Oo_Cuenta;
                    BorrarMovimientoDeListado(cuentaAsociada.Ll_MovimientosSimulados, movimiento.Oo_MovimientoPareja);

                    double multiplicador2 = 1;
                    if (cuentaAsociada.Bo_EsDeAhorro)
                        multiplicador2 = -1;
                    double importe2 = movimiento.Oo_MovimientoPareja.Do_Importe * movimiento.Oo_MovimientoPareja.Oo_TipoMovimiento.Do_MultiplicadorSigno * multiplicador2;
                    cuentaAsociada.Do_saldo = cuentaAsociada.Do_saldo + importe2;
                    movimiento.Oo_MovimientoPareja.Do_Saldo = cuentaAsociada.Do_saldo;
                    movimiento.Oo_MovimientoPareja.Bo_EsSimulado = false;
                    movimiento.Oo_MovimientoPareja.Bo_EstaAplicadoAlSaldo = true;
                    cuentaAsociada.Ll_Movimientos.Add(movimiento.Oo_MovimientoPareja);

                    cuentaAsociada.EsModificado = true;
                    movimiento.Oo_MovimientoPareja.EsModificado = true;

                }



                manejador.IniciarTransaccion();
                if (cuentaAsociada != null) manejador.Guardar(cuentaAsociada);
                manejador.Guardar(Cuenta);
                manejador.TerminarTransaccion();
                actualizarSaldosEvento();
                Herramientas.Forms.Mensajes.Informacion("Movimiento aplicado con éxito.");
            }
            catch (Exception ex)
            {
                manejador.DeshacerTransaccion();
                Herramientas.Forms.Mensajes.Error(ex.Message);
            }

        }

        void txt_MouseDown(object sender, MouseEventArgs e)
        {
            Label txt = (Label)sender;
            txt.ForeColor = Color.White;
        }
        void txt_MouseLeave(object sender, EventArgs e)
        {
            Label txt = (Label)sender;
            _MovimientoCuenta movimiento = (_MovimientoCuenta)txt.Tag;
            txt.ForeColor = movimiento.ColorMovimiento1;
        }

        void txt_MouseEnter(object sender, EventArgs e)
        {
            Label txt = (Label)sender;
            txt.ForeColor = Color.Blue;
            _MovimientoCuenta movimiento = (_MovimientoCuenta)txt.Tag;
            toolTip1.SetToolTip(txt, movimiento.St_detalleMovimiento);
        }
    }
}
