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

namespace CuentasParaPagar.Operaciones
{
    public partial class RegistrarMovimiento : Form
    {
        iSQL sql;
        ManejadorDB manejador;
        List<_Cuenta> cuentas;
        _Cuenta CuentaSeleccionada;
        List<_TipoMovimiento> tiposMovimientos;

        Boolean EsSimulacion;

        public List<_MovimientoCuenta> MovimientosSimulados = new List<_MovimientoCuenta>();

        public RegistrarMovimiento(iSQL sql, Boolean esSimulacion, _Cuenta cuentaSeleccionada)
        {
            InitializeComponent();
            this.sql = sql;
            EsSimulacion = esSimulacion;
            manejador = new ManejadorDB(this.sql);
            CargarCuentas();
            if (esSimulacion)
            {
                cmb_cuentas.Enabled = false;
                this.CuentaSeleccionada = cuentaSeleccionada;
                CargarCuentaSeleccionada();
            }
            CargarTiposMovimientos();
            dtp_fecha.Value = DateTime.Now;
            //dtp_fecha.MinDate = DateTime.Now;
            txt_cadaDias.Enabled = false;
            txt_cantidad.Enabled = false;
            chb_cadaMes.Enabled = false;

            //eventos de textbox
            Herramientas.Forms.Validaciones.TextboxSoloNumerosEnteros(txt_cadaDias);
            Herramientas.Forms.Validaciones.TextboxSoloNumerosEnteros(txt_cantidad);
            Herramientas.Forms.Validaciones.TextboxSoloNumerosDecimales(txt_importe, 2);

            cmb_CuentasAAfectar.SelectedIndexChanged += cmb_CuentasAAfectar_SelectedIndexChanged;
        }

        void cmb_CuentasAAfectar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_CuentasAAfectar.SelectedIndex >= 0)
            {
                if (CuentaSeleccionada.Id == cuentas[cmb_CuentasAAfectar.SelectedIndex].Id)
                {
                    Herramientas.Forms.Mensajes.Exclamacion("No puedes afectar con otro movimiento a la misma cuenta, selecciona otra cuenta.");
                    cmb_CuentasAAfectar.SelectedItem = null;
                }
            }
        }

        private void CargarTiposMovimientos()
        {
            tiposMovimientos = manejador.CargarLista<_TipoMovimiento>("select * from _TipoMovimiento where estaDeshabilitado = 'False'");
            cmb_tipoMovimiento.Items.Clear();
            cmb_TiposdeMovimiento.Items.Clear();
            if (tiposMovimientos != null)
                foreach (_TipoMovimiento tipo in tiposMovimientos)
                {
                    cmb_tipoMovimiento.Items.Add(tipo.St_Nombre);
                    cmb_TiposdeMovimiento.Items.Add(tipo.St_Nombre);
                }
        }
        private void CargarCuentas()
        {
            cuentas = manejador.CargarLista<_Cuenta>("select * from _Cuenta where estaDeshabilitado = 'False'");
            cmb_cuentas.Items.Clear();
            if (cuentas != null && !EsSimulacion)
                foreach (_Cuenta cuenta in cuentas)
                {
                    int movimientos = 0;
                    if (cuenta.Ll_Movimientos != null)
                        movimientos = cuenta.Ll_Movimientos.Count;
                    cmb_cuentas.Items.Add(cuenta.St_NombreCuenta);
                }
        }
        private void Limpiar()
        {
            txt_cadaDias.Text = "";
            txt_cantidad.Text = "";
            txt_detalleMovimiento.Text = "";
            txt_importe.Text = "";
            dtp_fecha.Value = DateTime.Now;
            cmb_tipoMovimiento.SelectedItem = null;
            chb_cadaMes.Checked = false;
            chb_varios.Checked = false;
            cmb_CuentasAAfectar.SelectedItem = null;
            cmb_TiposdeMovimiento.SelectedItem = null;
        }
        private void btn_registrar_Click(object sender, EventArgs e)
        {



            RegistrarMovimientoEnCuenta(CuentaSeleccionada);

        }

        private void RegistrarMovimientoEnCuenta(_Cuenta Cuenta)
        {
            try
            {
                //validaciones
                String labelCuentasTrans = "[@fuente->@destino] ";
                if (Cuenta == null)
                {
                    Herramientas.Forms.Mensajes.Advertencia("Seleccione una cuenta.");
                    return;
                }
                if (cmb_tipoMovimiento.SelectedItem == null)
                {
                    Herramientas.Forms.Mensajes.Advertencia("Seleccione un tipo de movimiento");
                    return;
                }
                if (chb_varios.Checked && txt_cantidad.Text.Trim().Equals(""))
                {
                    Herramientas.Forms.Mensajes.Advertencia("Seleccione una cantidad de movimientos.");
                    return;
                }
                if (chb_varios.Checked && !chb_cadaMes.Checked && txt_cadaDias.Text.Trim().Equals(""))
                {
                    Herramientas.Forms.Mensajes.Advertencia("Seleccione una frecuencia para los movimientos.");
                    return;
                }
                if (txt_importe.Text.Trim().Equals(""))
                {
                    Herramientas.Forms.Mensajes.Advertencia("Introduzca un importe para el movimiento.");
                    return;
                }
                if (!EsSimulacion && Cuenta == null)
                {
                    Herramientas.Forms.Mensajes.Advertencia("Seleccione una cuenta");
                    return;
                }
                //checando si se hara un movimiento a otra cuenta
                _Cuenta cuentaAAfectar = null;
                _TipoMovimiento tipoMovimientoCuentaAAfectar = null;
                if (cmb_CuentasAAfectar.SelectedIndex >= 0)
                {
                    cuentaAAfectar = cuentas[cmb_CuentasAAfectar.SelectedIndex];
                    if (cmb_TiposdeMovimiento.SelectedItem == null)
                    {
                        Herramientas.Forms.Mensajes.Exclamacion("Debes seleccionar el tipo de movimiento para la cuenta a afectar.");
                        return;
                    }
                    tipoMovimientoCuentaAAfectar = tiposMovimientos[cmb_TiposdeMovimiento.SelectedIndex];

                    if (tiposMovimientos[cmb_tipoMovimiento.SelectedIndex].Do_MultiplicadorSigno == tiposMovimientos[cmb_TiposdeMovimiento.SelectedIndex].Do_MultiplicadorSigno)
                    {
                        Herramientas.Forms.Mensajes.Exclamacion("Debes seleccionar movimientos de cuenta que sean opuestos.");
                        return;
                    }

                }
                //se crea el movimiento
                _MovimientoCuenta movimiento = new _MovimientoCuenta();
                movimiento.EsModificado = true;
                movimiento.Oo_TipoMovimiento = tiposMovimientos[cmb_tipoMovimiento.SelectedIndex];
                double importe = Convert.ToDouble(txt_importe.Text);
                String pre = "";




                //se determina el sentido de la operacion
                if (cuentaAAfectar != null)
                {
                    if ((movimiento.Oo_TipoMovimiento.Do_MultiplicadorSigno) == 1)
                    {
                        labelCuentasTrans = labelCuentasTrans.Replace("@fuente", Cuenta.St_NombreCuenta).Replace("@destino", cuentaAAfectar.St_NombreCuenta);
                    }
                    else
                    {
                        labelCuentasTrans = labelCuentasTrans.Replace("@fuente", cuentaAAfectar.St_NombreCuenta).Replace("@destino", Cuenta.St_NombreCuenta);
                    }
                    if (!txt_detalleMovimiento.Text.Trim().Equals(""))
                        labelCuentasTrans += " | " + txt_detalleMovimiento.Text;
                }
                else
                    labelCuentasTrans = "";
                //se calcula el importe y se agrega el prefijo de los pagos
                movimiento.St_detalleMovimiento = labelCuentasTrans;
                if (chb_varios.Checked)
                {
                    pre = " de " + txt_cantidad.Text;
                    if (!txt_detalleMovimiento.Text.Trim().Equals(""))
                        pre += " | ";
                    else
                        pre += " | " + movimiento.Oo_TipoMovimiento.St_Nombre;
                    //si se divide en multiples pagos, se divide entre el numero de pagos, si no el importe se repite
                    if (movimiento.Oo_TipoMovimiento.Bo_SeDivideEnMultiplesPagos)
                        importe = importe / Convert.ToDouble(txt_cantidad.Text);
                    //se agrega el pago numero 1 de varios
                    movimiento.St_detalleMovimiento += "1" + pre;
                }
                else if (labelCuentasTrans.Equals(""))
                    movimiento.St_detalleMovimiento = movimiento.Oo_TipoMovimiento.St_Nombre;
                //se agrega la bandera para saber si es movimiento simulado
                movimiento.Bo_EsSimulado = EsSimulacion;
                movimiento.Do_Importe = importe;
                movimiento.Dt_fecha = dtp_fecha.Value;
                //se determina la fecha de aplicacion, si es de ahorro es inmediato, sino se calcula las fechas de corte y pago
                if (Cuenta.Bo_EsDeAhorro || movimiento.Oo_TipoMovimiento.Bo_SeAplicaInmediato)
                    movimiento.Dt_fechaAplicacion = movimiento.Dt_fecha;
                else
                    movimiento.Dt_fechaAplicacion = DeterminarFechaAplicacion(Cuenta.In_DiaCorte, movimiento);
                if (!txt_detalleMovimiento.Text.Trim().Equals("") && labelCuentasTrans.Equals(""))
                    movimiento.St_detalleMovimiento += " | " + txt_detalleMovimiento.Text;

                //se crea el movimiento relacionado si se da el caso
                _MovimientoCuenta movimientoRelacionado = null;
                if (cuentaAAfectar != null)
                {
                    movimientoRelacionado = new _MovimientoCuenta();
                    movimientoRelacionado.EsModificado = true;
                    movimientoRelacionado.Bo_EsSimulado = EsSimulacion;
                    movimientoRelacionado.St_detalleMovimiento = movimiento.St_detalleMovimiento;
                    movimientoRelacionado.Do_Importe = movimiento.Do_Importe;
                    movimientoRelacionado.Oo_TipoMovimiento = tipoMovimientoCuentaAAfectar;
                    movimientoRelacionado.Dt_fecha = movimiento.Dt_fecha;
                    if (cuentaAAfectar.Bo_EsDeAhorro || movimientoRelacionado.Oo_TipoMovimiento.Bo_SeAplicaInmediato)
                        movimientoRelacionado.Dt_fechaAplicacion = movimientoRelacionado.Dt_fecha;
                    else
                        movimientoRelacionado.Dt_fechaAplicacion = DeterminarFechaAplicacion(cuentaAAfectar.In_DiaCorte, movimientoRelacionado);
                    movimientoRelacionado.Oo_Cuenta = cuentaAAfectar;
                    movimientoRelacionado.Oo_MovimientoPareja = movimiento;
                    movimiento.Oo_MovimientoPareja = movimientoRelacionado;

                    if (cuentaAAfectar.Ll_Movimientos == null) cuentaAAfectar.Ll_Movimientos = new List<_MovimientoCuenta>();
                    if (cuentaAAfectar.Ll_MovimientosSimulados == null) cuentaAAfectar.Ll_MovimientosSimulados = new List<_MovimientoCuenta>();
                    cuentaAAfectar.EsModificado = true;
                }

                //si no es una simulacion y el movimiento es antes o igual a hoy, se calcula el saldo de la cuenta
                double saldoCuentaAnterior = Cuenta.Do_saldo;
                //se obtiene el factor para saber el sentido de los movimientos
                double multiplicadorCuenta = 1;
                if (Cuenta.Bo_EsDeAhorro)
                    multiplicadorCuenta = -1;
                if (!EsSimulacion && movimiento.Dt_fechaAplicacion <= DateTime.Now)
                {
                    movimiento.Bo_EstaAplicadoAlSaldo = true;
                    //el multiplicador determina si el dinero entra o sale dependiendo si es credito o ahorro
                    movimiento.Do_Saldo = Cuenta.Do_saldo + (movimiento.Do_Importe * movimiento.Oo_TipoMovimiento.Do_MultiplicadorSigno * multiplicadorCuenta);
                    //si la cuenta es de ahorro y deseas retirar mas del saldo, se manda el error
                    if (Cuenta.Bo_EsDeAhorro && movimiento.Do_Saldo < 0)
                    {
                        Herramientas.Forms.Mensajes.Exclamacion("No cuenta con saldo suficiente en la cuenta para realizar el registro.");
                        return;
                    }
                    else
                        Cuenta.Do_saldo = movimiento.Do_Saldo;

                }
                //calcular en saldo 
                if (cuentaAAfectar != null)
                {

                    if (!EsSimulacion && movimientoRelacionado.Dt_fechaAplicacion <= DateTime.Now)
                    {
                        double multiplicadorCuentaAsociada = 1;
                        if (cuentaAAfectar.Bo_EsDeAhorro)
                            multiplicadorCuentaAsociada = -1;
                        movimientoRelacionado.Bo_EstaAplicadoAlSaldo = true;
                        movimientoRelacionado.Do_Saldo = cuentaAAfectar.Do_saldo + (movimientoRelacionado.Do_Importe * movimientoRelacionado.Oo_TipoMovimiento.Do_MultiplicadorSigno * multiplicadorCuentaAsociada);
                        //lo mismo para la cuenta relacionada
                        if (cuentaAAfectar.Bo_EsDeAhorro && movimientoRelacionado.Do_Saldo < 0)
                        {
                            Cuenta.Do_saldo = saldoCuentaAnterior;
                            Herramientas.Forms.Mensajes.Exclamacion("No cuenta con saldo suficiente en la cuenta para realizar el registro.");
                            return;
                        }
                        else
                            cuentaAAfectar.Do_saldo = movimientoRelacionado.Do_Saldo;

                    }

                }



                if (Cuenta.Ll_Movimientos == null) Cuenta.Ll_Movimientos = new List<_MovimientoCuenta>();
                movimiento.Oo_Cuenta = Cuenta;
                //si no es simulacion se actualiza para guardar los movimientos
                if (!EsSimulacion)
                {
                    Cuenta.EsModificado = true;
                    Cuenta.Ll_Movimientos.Add(movimiento);
                    if (cuentaAAfectar != null) cuentaAAfectar.Ll_Movimientos.Add(movimientoRelacionado);
                }
                else
                {
                    //si es simulacion, solo se agrega el movimiento a los movimientos simulados
                    MovimientosSimulados.Add(movimiento);
                    if (cuentaAAfectar != null) cuentaAAfectar.Ll_MovimientosSimulados.Add(movimientoRelacionado);
                }

                //en esta seccion se agregan los movimientos pendientes de los varios anteriores
                if (chb_varios.Checked)
                {
                    int cantidad = Convert.ToInt32(txt_cantidad.Text);
                    cantidad--; //restamos el que ya se agrego
                    int frecuencia = 0;
                    if (!chb_cadaMes.Checked)
                        frecuencia = Convert.ToInt32(txt_cadaDias.Text);

                    for (int i = 1; i <= cantidad; i++)
                    {
                        _MovimientoCuenta movimientoFuturo = new _MovimientoCuenta();
                        movimientoFuturo.EsModificado = true;
                        movimientoFuturo.Bo_EsSimulado = EsSimulacion;
                        movimientoFuturo.Do_Importe = importe;
                        movimientoFuturo.St_detalleMovimiento = labelCuentasTrans + (i + 1) + pre + txt_detalleMovimiento.Text;
                        movimientoFuturo.Oo_Cuenta = Cuenta;
                        movimientoFuturo.Bo_EstaAplicadoAlSaldo = false;
                        //se crea el movimento relacionado si se da el caso
                        _MovimientoCuenta movimientoFuturoRelacionado = null;
                        if (cuentaAAfectar != null)
                        {
                            movimientoFuturoRelacionado = new _MovimientoCuenta();
                            movimientoFuturoRelacionado.EsModificado = true;
                            movimientoFuturoRelacionado.Bo_EsSimulado = EsSimulacion;
                            movimientoFuturoRelacionado.Do_Importe = importe;
                            movimientoFuturoRelacionado.St_detalleMovimiento = movimientoFuturo.St_detalleMovimiento;
                            movimientoFuturoRelacionado.Oo_Cuenta = cuentaAAfectar;
                            movimientoFuturoRelacionado.Oo_MovimientoPareja = movimientoFuturo;
                            movimientoFuturo.Oo_MovimientoPareja = movimientoFuturoRelacionado;
                            movimientoFuturoRelacionado.Bo_EstaAplicadoAlSaldo = false;
                        }

                        //se determina la proxima fecha ya sea un mes o dias
                        if (chb_cadaMes.Checked)
                            movimientoFuturo.Dt_fecha = dtp_fecha.Value.AddMonths(1 * i);
                        else
                            movimientoFuturo.Dt_fecha = dtp_fecha.Value.AddDays(frecuencia * i);

                        //se le asigna el tipo de movimiento
                        movimientoFuturo.Oo_TipoMovimiento = tiposMovimientos[cmb_tipoMovimiento.SelectedIndex];

                        //si es cuenta de ahorro, la fecha es inmediata y si no se calcula como anteriormente se hizo
                        if (Cuenta.Bo_EsDeAhorro || movimientoFuturo.Oo_TipoMovimiento.Bo_SeAplicaInmediato)
                            movimientoFuturo.Dt_fechaAplicacion = movimientoFuturo.Dt_fecha;
                        else
                            movimientoFuturo.Dt_fechaAplicacion = DeterminarFechaAplicacion(Cuenta.In_DiaCorte, movimientoFuturo);
                        //se determina la fecha del movimiento relacionado futuro
                        if (cuentaAAfectar != null)
                        {
                            movimientoFuturoRelacionado.Dt_fecha = movimientoFuturo.Dt_fecha;
                            movimientoFuturoRelacionado.Oo_TipoMovimiento = movimientoRelacionado.Oo_TipoMovimiento;
                            if (cuentaAAfectar.Bo_EsDeAhorro || movimientoFuturoRelacionado.Oo_TipoMovimiento.Bo_SeAplicaInmediato)
                                movimientoFuturoRelacionado.Dt_fechaAplicacion = movimientoFuturoRelacionado.Dt_fecha;
                            else
                                movimientoFuturoRelacionado.Dt_fechaAplicacion = DeterminarFechaAplicacion(cuentaAAfectar.In_DiaCorte, movimientoFuturoRelacionado);
                        }
                        
                        //si no es una simulacion, se agrega a los movimientos normales, si si entonces a los movimientos simulados
                        if (!EsSimulacion)
                        {
                            
                            Cuenta.Ll_Movimientos.Add(movimientoFuturo);
                            if (cuentaAAfectar != null) cuentaAAfectar.Ll_Movimientos.Add(movimientoFuturoRelacionado);
                        }
                        else
                        {
                            MovimientosSimulados.Add(movimientoFuturo);
                            if (cuentaAAfectar != null) cuentaAAfectar.Ll_MovimientosSimulados.Add(movimientoFuturoRelacionado);
                        }
                    }

                }
                //la cuenta se guarda
                manejador.IniciarTransaccion();
                manejador.Guardar(Cuenta);
                if (cuentaAAfectar != null) manejador.Guardar(cuentaAAfectar);
                manejador.TerminarTransaccion();

                CargarCuentasAAfectar();

                if (!EsSimulacion)
                {

                    Limpiar();
                    Herramientas.Forms.Mensajes.Informacion("Guardado con éxito.");
                    CargarCuentaSeleccionada();

                }
                else
                {
                    Hide();
                }
            }
            catch (Exception ex)
            {
                manejador.DeshacerTransaccion();
                Herramientas.Forms.Mensajes.Error(ex.Message);
            }
        }

        private DateTime DeterminarFechaAplicacion(int diaCorte, _MovimientoCuenta movimiento)
        {
            DateTime fechaAplicacion = DateTime.Now;

            if (movimiento.Oo_TipoMovimiento.St_Tipo.Equals("S"))
            {
                //determinando la fecha de aplicacion para las compras o gastos en la fecha de corte

                diaCorte = CuentaSeleccionada.In_DiaCorte;

                int diasDespuesDeCorte = movimiento.Dt_fecha.Day - diaCorte;

                if (diasDespuesDeCorte >= 0)
                {
                    //esta dentro del periodo muerto, por lo tanto se aplica hasta la proxima fecha de corte
                    fechaAplicacion = movimiento.Dt_fecha.AddMonths(1);
                    //le resto los dias sobrantes para que quede en la fecha de corte
                    fechaAplicacion = fechaAplicacion.AddDays(diasDespuesDeCorte * -1);
                }
                else
                {
                    fechaAplicacion = movimiento.Dt_fecha.AddDays(diasDespuesDeCorte * -1);
                }

                fechaAplicacion = new DateTime(fechaAplicacion.Year, fechaAplicacion.Month, fechaAplicacion.Day);


            }
            else
            {
                fechaAplicacion = movimiento.Dt_fecha;
            }

            return fechaAplicacion;
        }
        private void cmb_cuentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_cuentas.SelectedIndex >= 0)
            {
                CuentaSeleccionada = cuentas[cmb_cuentas.SelectedIndex];
                CargarCuentaSeleccionada();
            }
        }
        private void CargarCuentaSeleccionada()
        {
            if (CuentaSeleccionada == null) return;
            pb_imagen.Image = CuentaSeleccionada.Bm_Imagen;
            txt_saldoAlDia.Text = Herramientas.Conversiones.Formatos.DoubleAMonedaANDecimales(CuentaSeleccionada.Do_saldo, 2);

            CargarCuentasAAfectar();

        }
        private void CargarCuentasAAfectar()
        {
            //cargando cuentas faltantes
            cmb_CuentasAAfectar.Items.Clear();
            if (cuentas != null)
                foreach (_Cuenta cuenta in cuentas)
                {
                    cmb_CuentasAAfectar.Items.Add(cuenta.St_NombreCuenta + " (" + Herramientas.Conversiones.Formatos.DoubleAMonedaANDecimales(cuenta.Do_saldo, 2) + ")");
                }
        }
        private void chb_varios_CheckedChanged(object sender, EventArgs e)
        {
            txt_cadaDias.Enabled = chb_varios.Checked;
            txt_cantidad.Enabled = chb_varios.Checked;
            chb_cadaMes.Enabled = chb_varios.Checked;
        }

        private void chb_cadaMes_CheckedChanged(object sender, EventArgs e)
        {
            txt_cadaDias.Enabled = !chb_cadaMes.Checked;
        }

        private void cmb_tipoMovimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_tipoMovimiento.SelectedIndex >= 0)
            {
                if (tiposMovimientos[cmb_tipoMovimiento.SelectedIndex].Bo_SeDivideEnMultiplesPagos)
                {
                    chb_varios.Checked = true;
                    chb_varios.Enabled = false;
                }
                else
                {
                    chb_varios.Checked = false;
                    chb_varios.Enabled = true;
                }
            }
        }
    }
}
