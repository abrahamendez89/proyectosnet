using CuentasParaPagar.Operaciones;
using Dominio;
using Herramientas.Forms;
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

namespace CuentasParaPagar.Consultas
{
    public partial class ProyeccionFutura : Form
    {
        iSQL sql;
        ManejadorDB manejador;
        List<_Cuenta> cuentas;
        _Cuenta CuentaSeleccionada;

        public ProyeccionFutura(iSQL sql, _Cuenta cuentaSeleccionada)
        {
            InitializeComponent();
            cmb_cuentas.SelectedIndexChanged += cmb_cuentas_SelectedIndexChanged;
            this.sql = sql;
            manejador = new ManejadorDB(this.sql);
            manejador.UsarAlmacenObjetos = false;
            CargarCuentas();
            dtp_fechaHasta.MinDate = DateTime.Now;
            dtp_fechaHasta.Value = DateTime.Now.AddMonths(3);

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
                CuentaSeleccionada.EliminarCache();
                CargarCuentaSeleccionada();
                GenerarProyeccion(CuentaSeleccionada);
            }
        }
        List<_MovimientoCuenta> movimientosSimuladosTemp = new List<_MovimientoCuenta>();
        private void GenerarProyeccion(_Cuenta CuentaSeleccionada)
        {
            CuentaSeleccionada.EliminarCache();
            movimientosSimuladosTemp.Clear();
            if (CuentaSeleccionada == null)
            {
                Herramientas.Forms.Mensajes.Advertencia("Debe seleccionar una cuenta antes");
                return;
            }
            dgv_proyeccion.Rows.Clear();

            //if (CuentaSeleccionada.Ll_MovimientosSimulados != null)
            //    foreach (_MovimientoCuenta movimientoSimulado in CuentaSeleccionada.Ll_MovimientosSimulados)
            //        movimientoSimulado.Dt_fecha = DateTime.Now;

            List<_MovimientoCuenta> movimientos = new List<_MovimientoCuenta>();
            if (!CuentaSeleccionada.Bo_EsDeAhorro)
                movimientos = GeneraMovimientoDeIntereses(CuentaSeleccionada.In_DiaCorte, CuentaSeleccionada.In_DiasParaPago);
            if (CuentaSeleccionada.Ll_Movimientos != null)
                movimientos.AddRange(CuentaSeleccionada.Ll_Movimientos);
            if (CuentaSeleccionada.Ll_MovimientosSimulados != null)
                movimientos.AddRange(CuentaSeleccionada.Ll_MovimientosSimulados);

            foreach (_MovimientoCuenta movimiento in movimientos)
                movimiento.Dt_fechaAplicacion = new DateTime(movimiento.Dt_fechaAplicacion.Year, movimiento.Dt_fechaAplicacion.Month, movimiento.Dt_fechaAplicacion.Day);

            List<_MovimientoCuenta> movimientosOrdenados = movimientos.OrderBy(x => x.Dt_fechaAplicacion).ThenBy(x => x.Dt_fecha).ToList<_MovimientoCuenta>();

            double saldoActual = CuentaSeleccionada.Do_saldo;

            foreach (_MovimientoCuenta movimiento in movimientosOrdenados)
            {
                if (new DateTime(movimiento.Dt_fechaAplicacion.Year, movimiento.Dt_fechaAplicacion.Month, movimiento.Dt_fechaAplicacion.Day) >= new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day) && new DateTime(movimiento.Dt_fechaAplicacion.Year, movimiento.Dt_fechaAplicacion.Month, movimiento.Dt_fechaAplicacion.Day) <= new DateTime(dtp_fechaHasta.Value.Year, dtp_fechaHasta.Value.Month, dtp_fechaHasta.Value.Day).AddHours(24))
                {
                    if (movimiento.Bo_EsSimulado)
                        movimiento.Do_Saldo = 0;
                    double multiplicadorCuenta = 1;
                    if (CuentaSeleccionada.Bo_EsDeAhorro)
                        multiplicadorCuenta = -1;
                    //si el movimiento es de interes mensual, entonces se agrega una fila con el monto a pagar antes de los intereses
                    if (movimiento.Oo_TipoMovimiento.St_Nombre.Equals("(Simulado) - Intereses Mensuales"))
                    {
                        dgv_proyeccion.Rows.Add(Herramientas.Conversiones.Formatos.DateTimeAFechaCortaConMesTextoAbreviado(movimiento.Dt_fechaAplicacion), "", "   ## FECHA LIMITE DE PAGO ##", "", Herramientas.Conversiones.Formatos.DoubleAMonedaANDecimales(saldoActual, 2), "Importe a pagar en la fecha limite de la cuenta.");
                        movimientosSimuladosTemp.Add(null);
                        for (int i = 0; i < dgv_proyeccion.Rows[dgv_proyeccion.Rows.Count - 1].Cells.Count; i++)
                        {
                            dgv_proyeccion.Rows[dgv_proyeccion.Rows.Count - 1].Cells[i].Style.BackColor = Color.LightBlue;
                            dgv_proyeccion.Rows[dgv_proyeccion.Rows.Count - 1].Cells[i].Style.ForeColor = Color.Black;
                        }

                    }
                    // si el tipo de movimiento es de intereses se calculan los intereses
                    if (!CuentaSeleccionada.Bo_EsDeAhorro && movimiento.Oo_TipoMovimiento.St_Nombre.Equals("(Simulado) - Intereses Mensuales") && saldoActual > 0)
                    {
                        double calculoIntereses = saldoActual * (CuentaSeleccionada.Do_PorcentajeInteresMensual / 100);
                        movimiento.Do_Importe = calculoIntereses;
                        movimiento.Do_Importe = movimiento.Do_Importe * 1.16;
                    }
                    //se calcula el saldo del movimiento solo si su fecha de aplicacion es mayor a hoy
                    if (movimiento.Dt_fechaAplicacion >= new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day) && movimiento.Do_Saldo == 0 && !movimiento.Bo_EstaAplicadoAlSaldo)
                    {
                        saldoActual = saldoActual + movimiento.Do_Importe * movimiento.Oo_TipoMovimiento.Do_MultiplicadorSigno * multiplicadorCuenta;
                        movimiento.Do_Saldo = saldoActual;
                    }
                    //se le pone el prefijo simulado a los movimientos simulados
                    if (movimiento.Bo_EsSimulado)
                    {
                        if (!movimiento.Oo_TipoMovimiento.St_Nombre.Contains("(Simulado) - "))
                            movimiento.Oo_TipoMovimiento.St_Nombre = "(Simulado) - " + movimiento.Oo_TipoMovimiento.St_Nombre;
                    }
                    dgv_proyeccion.Rows.Add(Herramientas.Conversiones.Formatos.DateTimeAFechaCortaConMesTextoAbreviado(movimiento.Dt_fechaAplicacion), Herramientas.Conversiones.Formatos.DateTimeAFechaCortaConMesTextoAbreviado(movimiento.Dt_fecha), movimiento.Oo_TipoMovimiento.St_Nombre, Herramientas.Conversiones.Formatos.DoubleAMonedaANDecimales(movimiento.Do_Importe, 2), Herramientas.Conversiones.Formatos.DoubleAMonedaANDecimales(movimiento.Do_Saldo, 2), movimiento.St_detalleMovimiento);
                    //coloreando los tipos de movimiento
                    if (movimiento.Oo_TipoMovimiento.Do_MultiplicadorSigno == -1)
                    {
                        dgv_proyeccion.Rows[dgv_proyeccion.Rows.Count - 1].Cells[3].Style.BackColor = Color.LightGreen;
                        dgv_proyeccion.Rows[dgv_proyeccion.Rows.Count - 1].Cells[3].Style.ForeColor = Color.Black;
                    }
                    else
                    {
                        dgv_proyeccion.Rows[dgv_proyeccion.Rows.Count - 1].Cells[3].Style.BackColor = Color.Salmon;
                        dgv_proyeccion.Rows[dgv_proyeccion.Rows.Count - 1].Cells[3].Style.ForeColor = Color.White;
                    }
                    //coloreando un movimiento simulado
                    if (movimiento.Bo_EsSimulado)
                    {
                        dgv_proyeccion.Rows[dgv_proyeccion.Rows.Count - 1].Cells[2].Style.BackColor = Color.LightGray;
                        dgv_proyeccion.Rows[dgv_proyeccion.Rows.Count - 1].Cells[2].Style.ForeColor = Color.Black;
                        movimientosSimuladosTemp.Add(movimiento);
                    }
                    else
                        movimientosSimuladosTemp.Add(movimiento); //probando eliminando movimientos
                }
            }
        }

        private List<_MovimientoCuenta> GeneraMovimientoDeIntereses(int diaCorte, int diasPago)
        {

            List<_MovimientoCuenta> retorno = new List<_MovimientoCuenta>();

            _TipoMovimiento tipoInteres = null; // manejador.Cargar<_TipoMovimiento>("select * from _TipoMovimiento where estaDeshabilitado = 'False' and _st_Nombre = 'Intereses Mensuales'");
            if (tipoInteres == null) tipoInteres = new _TipoMovimiento();
            //tipoInteres.EsModificado = true;

            tipoInteres.St_Nombre = "(Simulado) - Intereses Mensuales";
            tipoInteres.St_Tipo = "S";
            tipoInteres.Do_MultiplicadorSigno = 1;


            //manejador.Guardar(tipoInteres);

            //agregando movimientos de intereses;


            TimeSpan resta = dtp_fechaHasta.Value - DateTime.Now;
            int diasTotales = Herramientas.Conversiones.Formatos.DoubleRedondeoAEnteroArriba(resta.TotalDays);

            DateTime fechaPartida = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            DateTime proximaFechaPago = CalcularProximaFechaPago(fechaPartida, diaCorte, diasPago);

            for (int i = 0; i < diasTotales; i++)
            {
                DateTime fechaRecorrido = fechaPartida.AddDays(1 * i);

                if (fechaRecorrido == proximaFechaPago)
                {
                    _MovimientoCuenta movimientoIntereses = new _MovimientoCuenta();
                    movimientoIntereses.Do_Importe = 0;
                    movimientoIntereses.Oo_TipoMovimiento = tipoInteres;
                    movimientoIntereses.Dt_fecha = proximaFechaPago;
                    movimientoIntereses.Dt_fechaAplicacion = proximaFechaPago;
                    movimientoIntereses.Bo_EsSimulado = true;
                    retorno.Add(movimientoIntereses);
                    //calculando la proxima fecha

                    proximaFechaPago = CalcularProximaFechaPago(proximaFechaPago, diaCorte, diasPago);


                }


            }
            return retorno;
        }

        public static DateTime CalcularProximaFechaPago(DateTime fechaBase, int diaDeCorte, int diasPago)
        {
            DateTime proximaFechaPago = fechaBase;
            DateTime fechaPartida = proximaFechaPago;

            if (proximaFechaPago.Day >= diaDeCorte)
            {
                int sumaDias = proximaFechaPago.Day - diaDeCorte;

                if (sumaDias < diasPago)
                {

                    sumaDias = diasPago - sumaDias;

                    proximaFechaPago = proximaFechaPago.AddDays(sumaDias);
                }
                else
                {
                    proximaFechaPago = proximaFechaPago.AddMonths(1);
                    proximaFechaPago = proximaFechaPago.AddDays(diasPago - sumaDias);
                }
            }
            //else if (
            //{
            //    int diasRestantes = diasPago - (diaDeCorte - proximaFechaPago.Day);
            //    proximaFechaPago = proximaFechaPago.AddDays(diasRestantes);
            //}
            else
            {
                DateTime dt = new DateTime(proximaFechaPago.AddMonths(-1).Year, proximaFechaPago.AddMonths(-1).Month, diaDeCorte).AddDays(diasPago);

                if (dt <= proximaFechaPago)
                {
                    dt = CalcularProximaFechaPago(new DateTime(proximaFechaPago.Year, proximaFechaPago.Month, diaDeCorte), diaDeCorte, diasPago);
                }

                proximaFechaPago = dt;
            }

            return proximaFechaPago;
        }

        private void CargarCuentaSeleccionada()
        {
            if (CuentaSeleccionada == null) return;
            pb_imagen.Image = CuentaSeleccionada.Bm_Imagen;
            txt_saldoAlDia.Text = Herramientas.Conversiones.Formatos.DoubleAMonedaANDecimales(CuentaSeleccionada.Do_saldo, 2);
        }

        private void btn_generar_Click(object sender, EventArgs e)
        {
            GenerarProyeccion(CuentaSeleccionada);
        }
        private void btn_AgregarPagoSimulado_Click(object sender, EventArgs e)
        {
            try
            {
                if (CuentaSeleccionada == null)
                {
                    Herramientas.Forms.Mensajes.Exclamacion("Seleccione una cuenta primero!");
                    return;
                }

                RegistrarMovimiento reg = new RegistrarMovimiento(sql, true, CuentaSeleccionada);
                reg.ShowDialog();

                if (CuentaSeleccionada.Ll_MovimientosSimulados == null) CuentaSeleccionada.Ll_MovimientosSimulados = new List<_MovimientoCuenta>();
                CuentaSeleccionada.Ll_MovimientosSimulados.AddRange(reg.MovimientosSimulados);

                reg.Close();

                if (CuentaSeleccionada.Ll_MovimientosSimulados != null)
                {
                    foreach (_MovimientoCuenta movimientoSimulado in CuentaSeleccionada.Ll_MovimientosSimulados)
                        movimientoSimulado.Do_Saldo = 0;
                }

                CuentaSeleccionada.EsModificado = true;
                manejador.IniciarTransaccion();
                manejador.Guardar(CuentaSeleccionada);
                manejador.TerminarTransaccion();
                GenerarProyeccion(CuentaSeleccionada);
            }
            catch (Exception ex)
            {
                manejador.DeshacerTransaccion();
                Herramientas.Forms.Mensajes.Error(ex.Message);
            }
        }

        private void btn_BorrarPagosSimulados_Click(object sender, EventArgs e)
        {


            try
            {
                if (CuentaSeleccionada == null)
                {
                    Herramientas.Forms.Mensajes.Exclamacion("Seleccione una cuenta primero!");
                    return;
                }
                if (!Herramientas.Forms.Mensajes.PreguntaAdvertenciaSIoNO("¿Está seguro que desea eliminar TODOS los movimientos simulados?"))
                {
                    return;
                }

                manejador.IniciarTransaccion();
                if (CuentaSeleccionada.Ll_MovimientosSimulados != null)
                {

                    foreach (_MovimientoCuenta movimientoAborrarConParejas in CuentaSeleccionada.Ll_MovimientosSimulados)
                    {
                        if (movimientoAborrarConParejas.Oo_MovimientoPareja != null)
                        {
                            BorrarMovimientoPareja(movimientoAborrarConParejas);
                        }
                    }
                    CuentaSeleccionada.Ll_MovimientosSimulados.Clear();

                }
                CuentaSeleccionada.EsModificado = true;
                manejador.Guardar(CuentaSeleccionada);
                manejador.TerminarTransaccion();
                GenerarProyeccion(CuentaSeleccionada);
                Herramientas.Forms.Mensajes.Informacion("Movimientos eliminados con éxito.");
            }
            catch (Exception ex)
            {
                manejador.DeshacerTransaccion();
                Herramientas.Forms.Mensajes.Error(ex.Message);
            }
        }

        private void BorrarMovimientoPareja(_MovimientoCuenta movimiento)
        {
            _Cuenta cuentaAfectada = movimiento.Oo_MovimientoPareja.Oo_Cuenta;
            if (cuentaAfectada != null && cuentaAfectada.Ll_MovimientosSimulados != null)
                for (int i = 0; i < cuentaAfectada.Ll_MovimientosSimulados.Count; i++)
                {
                    if (cuentaAfectada.Ll_MovimientosSimulados[i].Id == movimiento.Oo_MovimientoPareja.Id)
                    {
                        cuentaAfectada.Ll_MovimientosSimulados.RemoveAt(i);
                        cuentaAfectada.EsModificado = true;
                        manejador.Guardar(cuentaAfectada);
                        return;
                    }
                }
            if (cuentaAfectada != null && cuentaAfectada.Ll_Movimientos != null)
                for (int i = 0; i < cuentaAfectada.Ll_Movimientos.Count; i++)
                {
                    if (cuentaAfectada.Ll_Movimientos[i].Id == movimiento.Oo_MovimientoPareja.Id)
                    {
                        cuentaAfectada.Ll_Movimientos.RemoveAt(i);
                        cuentaAfectada.EsModificado = true;
                        manejador.Guardar(cuentaAfectada);
                        return;
                    }
                }
        }

        private void btn_borrarMovimientoSimulado_Click(object sender, EventArgs e)
        {
            if (CuentaSeleccionada == null)
            {
                Herramientas.Forms.Mensajes.Exclamacion("Seleccione una cuenta primero!");
                return;
            }
            if (!Herramientas.Forms.Mensajes.PreguntaAdvertenciaSIoNO("¿Está seguro que desea eliminar el movimiento seleccionado?"))
            {
                return;
            }
            int filaSeleccionada = dgv_proyeccion.CurrentRow.Index;
            _MovimientoCuenta movimientoE = movimientosSimuladosTemp[filaSeleccionada];
            if (movimientoE != null && !movimientoE.Bo_EsSimulado)
            {
                if (!Herramientas.Forms.Mensajes.PreguntaAdvertenciaSIoNO("El movimiento que desea eliminar no es simulado, ¿desea continuar?"))
                {
                    return;
                }
            }
            if (dgv_proyeccion.CurrentRow.Index >= 0)
            {

                if (movimientoE != null)
                {
                    
                    if (!movimientoE.Bo_EsSimulado && new DateTime(movimientoE.Dt_fechaAplicacion.Year, movimientoE.Dt_fechaAplicacion.Month, movimientoE.Dt_fechaAplicacion.Day) <= new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day))
                    {
                        Herramientas.Forms.Mensajes.Exclamacion("No es posible eliminar el movimiento que seleccionó porque ya fue aplicado al saldo.");
                        return;
                    }
                    try
                    {
                        manejador.IniciarTransaccion();
                        if (movimientoE.Oo_MovimientoPareja != null)
                            BorrarMovimientoPareja(movimientoE);

                        if (CuentaSeleccionada.Ll_MovimientosSimulados != null)
                            CuentaSeleccionada.Ll_MovimientosSimulados.Remove(movimientoE);
                        if (CuentaSeleccionada.Ll_Movimientos != null)
                            CuentaSeleccionada.Ll_Movimientos.Remove(movimientoE);

                        CuentaSeleccionada.EsModificado = true;
                        manejador.Guardar(CuentaSeleccionada);
                        manejador.TerminarTransaccion();
                        Herramientas.Forms.Mensajes.Informacion("Movimiento eliminado con éxito");
                        GenerarProyeccion(CuentaSeleccionada);
                    }
                    catch (Exception ex)
                    {
                        Herramientas.Forms.Mensajes.Error(ex.Message);
                    }
                }
                else
                {
                    Herramientas.Forms.Mensajes.Exclamacion("No es posible eliminar el movimiento que seleccionó.");
                }

            }
            else
            {
                Herramientas.Forms.Mensajes.Exclamacion("Seleccione el movimiento a eliminar");
            }
        }

        private void dtp_fechaHasta_ValueChanged(object sender, EventArgs e)
        {
            if (cmb_cuentas.SelectedItem != null)
                GenerarProyeccion(CuentaSeleccionada);
        }

        private void btn_enviarAExcel_Click(object sender, EventArgs e)
        {
            String ruta = Herramientas.Archivos.Dialogos.GuardarArchivoRuta(new List<string>() { "Archivo de Excel" }, new List<string>() { "xls" }, "PROYECCION_" + CuentaSeleccionada .St_NombreCuenta.ToUpper().Replace(" ","_")+ "_" + Herramientas.Conversiones.Formatos.DateTimeAFechaLOGArchivo(DateTime.Now) + ".xls");
            if (ruta != null)
            {
                ExcelAPI excel = new ExcelAPI();
                excel.ConvertirDataGridViewAExcel(ruta, dgv_proyeccion, Color.LightYellow, Color.Black);
                excel.terminoConversion += excel_terminoConversion;

            }
        }

        void excel_terminoConversion(string rutaGuardado)
        {
            Herramientas.Forms.Mensajes.Informacion("El archivo se guardo correctamente en la ruta: " + rutaGuardado);
        }
    }
}
