using Dominio;
using Herramientas.ORM;
using Herramientas.SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CuentasParaPagar.Consultas
{
    public partial class HistorialDeMovimientos : Form
    {
        iSQL sql;
        ManejadorDB manejador;
        List<_Cuenta> cuentas;
        _Cuenta CuentaSeleccionada;

        Dictionary<long, double> tiposMovimientosSumatorias = new Dictionary<long, double>();
        public HistorialDeMovimientos(iSQL sql, _Cuenta cuentaSeleccionada)
        {
            InitializeComponent();
            cmb_cuentas.SelectedIndexChanged += cmb_cuentas_SelectedIndexChanged;
            this.sql = sql;
            manejador = new ManejadorDB(this.sql);
            CargarCuentas();
            dtp_fechaMinima.MaxDate = DateTime.Now;
            dtp_fechaMinima.Value = DateTime.Now.AddMonths(-3);

            this.CuentaSeleccionada = cuentaSeleccionada;

            if (CuentaSeleccionada != null)
            {
                cmb_cuentas.SelectedItem = CuentaSeleccionada.St_NombreCuenta;
            }
        }
        private void CargarCuentas()
        {
            cuentas = manejador.CargarLista<_Cuenta>("select * from _Cuenta where estaDeshabilitado = 'False'");
            cmb_cuentas.Items.Clear();
            if (cuentas != null)
                foreach (_Cuenta cuenta in cuentas)
                {
                    int movimientos = 0;
                    if (cuenta.Ll_Movimientos != null)
                        movimientos = cuenta.Ll_Movimientos.Count;
                    cmb_cuentas.Items.Add(cuenta.St_NombreCuenta);
                }
        }

        private void cmb_cuentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_cuentas.SelectedIndex >= 0)
            {
                CuentaSeleccionada = cuentas[cmb_cuentas.SelectedIndex];
                CargarCuentaSeleccionada();
                CargarHistorialDeCuenta();
            }
        }
        private void CargarCuentaSeleccionada()
        {
            if (CuentaSeleccionada == null) return;
            pb_imagen.Image = CuentaSeleccionada.Bm_Imagen;
            txt_saldoAlDia.Text = Herramientas.Conversiones.Formatos.DoubleAMonedaANDecimales(CuentaSeleccionada.Do_saldo, 2);
        }

        private void CargarHistorialDeCuenta()
        {
            dgv_historialMovimientos.Rows.Clear();
            tiposMovimientosSumatorias.Clear();
            chart.Titles.Clear();
            chart.Series.Clear();

            if (CuentaSeleccionada.Ll_Movimientos != null)
            {

                CuentaSeleccionada.Ll_Movimientos = CuentaSeleccionada.Ll_Movimientos.OrderByDescending(x => x.Dt_fechaAplicacion).ToList<_MovimientoCuenta>();
                double multiplicadorCuenta = 1;
                if (CuentaSeleccionada.Bo_EsDeAhorro)
                    multiplicadorCuenta = -1;
                foreach (_MovimientoCuenta movimiento in CuentaSeleccionada.Ll_Movimientos)
                {
                    if (new DateTime(movimiento.Dt_fechaAplicacion.Year, movimiento.Dt_fechaAplicacion.Month, movimiento.Dt_fechaAplicacion.Day) >= new DateTime(dtp_fechaMinima.Value.Year, dtp_fechaMinima.Value.Month, dtp_fechaMinima.Value.Day) && new DateTime(movimiento.Dt_fechaAplicacion.Year, movimiento.Dt_fechaAplicacion.Month, movimiento.Dt_fechaAplicacion.Day) <= DateTime.Now)
                    {
                        dgv_historialMovimientos.Rows.Add(Herramientas.Conversiones.Formatos.DateTimeAFechaCortaConMesTextoAbreviado(movimiento.Dt_fechaAplicacion), Herramientas.Conversiones.Formatos.DateTimeAFechaCortaConMesTextoAbreviado(movimiento.Dt_fecha), movimiento.Oo_TipoMovimiento.St_Nombre, Herramientas.Conversiones.Formatos.DoubleAMonedaANDecimales(movimiento.Do_Importe, 2), Herramientas.Conversiones.Formatos.DoubleAMonedaANDecimales(movimiento.Do_Saldo, 2), movimiento.St_detalleMovimiento);
                        if (movimiento.Oo_TipoMovimiento.Do_MultiplicadorSigno == -1)
                        {
                            dgv_historialMovimientos.Rows[dgv_historialMovimientos.Rows.Count - 1].Cells[3].Style.BackColor = Color.LightGreen;
                            dgv_historialMovimientos.Rows[dgv_historialMovimientos.Rows.Count - 1].Cells[3].Style.ForeColor = Color.Black;
                        }
                        else
                        {
                            dgv_historialMovimientos.Rows[dgv_historialMovimientos.Rows.Count - 1].Cells[3].Style.BackColor = Color.Salmon;
                            dgv_historialMovimientos.Rows[dgv_historialMovimientos.Rows.Count - 1].Cells[3].Style.ForeColor = Color.White;
                        }

                        if (tiposMovimientosSumatorias.ContainsKey(movimiento.Oo_TipoMovimiento.Id))
                            tiposMovimientosSumatorias[movimiento.Oo_TipoMovimiento.Id] += movimiento.Do_Importe;
                        else
                            tiposMovimientosSumatorias.Add(movimiento.Oo_TipoMovimiento.Id, movimiento.Do_Importe);

                    }
                }
            }
            CargarGrafica();
        }

        private void btn_verHistorial_Click(object sender, EventArgs e)
        {
            CargarHistorialDeCuenta();
        }

        private void dtp_fechaMinima_ValueChanged(object sender, EventArgs e)
        {
            if (cmb_cuentas.SelectedItem != null)
                CargarHistorialDeCuenta();
        }

        //grafica aqui
        private void CargarGrafica()
        {
            if (tiposMovimientosSumatorias.Keys.Count > 0)
                chart.Titles.Add("Resumen de movimientos desde " + Herramientas.Conversiones.Formatos.DateTimeAFechaCortaConMesTexto(dtp_fechaMinima.Value));
            else
                chart.Titles.Add("No hay movimientos para la gráfica.");
            foreach (long idTipoMov in tiposMovimientosSumatorias.Keys)
            {
                _TipoMovimiento tipoMov = manejador.Cargar<_TipoMovimiento>("select * from _TipoMovimiento where estaDeshabilitado = 'False' and id = @id", new List<object>() { idTipoMov });
                Series series = chart.Series.Add(tipoMov.St_Nombre + " - " + Herramientas.Conversiones.Formatos.DoubleAMonedaANDecimales(tiposMovimientosSumatorias[idTipoMov], 2));
                series.Points.Add(tiposMovimientosSumatorias[idTipoMov]);
            }
        }
    }
}
