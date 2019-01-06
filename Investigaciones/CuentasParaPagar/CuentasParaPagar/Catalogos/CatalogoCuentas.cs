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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuentasParaPagar.Catalogos
{
    public partial class CatalogoCuentas : Form
    {
        iSQL sql;
        ManejadorDB manejador;
        List<_Cuenta> cuentas;
        _Cuenta CuentaSeleccionada;
        public CatalogoCuentas(iSQL sql)
        {
            InitializeComponent();
            this.sql = sql;
            manejador = new ManejadorDB(this.sql);
            CargarCuentas();


            //eventos

            Herramientas.Forms.Validaciones.TextboxSoloNumerosDecimales(txt_saldo, 2);
            Herramientas.Forms.Validaciones.TextboxSoloNumerosEnteros(txt_diaCorte);
            Herramientas.Forms.Validaciones.TextboxSoloNumerosEnteros(txt_diasParaPago);
            Herramientas.Forms.Validaciones.TextboxSoloNumerosDecimales(txt_PorcentajeInteres, 2);


        }
        private void CargarCuentas()
        {
            cuentas = manejador.CargarLista<_Cuenta>("select * from _Cuenta");
            cmb_cuentas.Items.Clear();
            if (cuentas != null)
                foreach (_Cuenta cuenta in cuentas)
                {
                    int movimientos = 0;
                    if (cuenta.Ll_Movimientos != null)
                        movimientos = cuenta.Ll_Movimientos.Count;
                    String texto = "";
                    if (cuenta.EstaDeshabilitado) texto = " [ Desactivada ]";
                    cmb_cuentas.Items.Add(cuenta.St_NombreCuenta +texto);
                }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (CuentaSeleccionada == null) CuentaSeleccionada = new _Cuenta();
                CuentaSeleccionada.EsModificado = true;

                CuentaSeleccionada.St_NombreCuenta = txt_nombre.Text;
                if (!chb_esDeAhorro.Checked)
                {
                    CuentaSeleccionada.In_DiaCorte = Convert.ToInt32(txt_diaCorte.Text);
                    CuentaSeleccionada.In_DiasParaPago = Convert.ToInt32(txt_diasParaPago.Text);
                    CuentaSeleccionada.Do_PorcentajeInteresMensual = Convert.ToDouble(txt_PorcentajeInteres.Text);
                }
                CuentaSeleccionada.EstaDeshabilitado = !chb_Activo.Checked;
                CuentaSeleccionada.Bm_Imagen = (Bitmap)pb_imagen.Image;
                CuentaSeleccionada.Do_saldo = Convert.ToDouble(txt_saldo.Text);
                CuentaSeleccionada.Bo_EsDeAhorro = chb_esDeAhorro.Checked;
                manejador.IniciarTransaccion();
                manejador.Guardar(CuentaSeleccionada);
                manejador.TerminarTransaccion();
                CargarCuentas();
                Herramientas.Forms.Mensajes.Informacion("Guardado con éxito.");

                CuentaSeleccionada = null;
                LimpiarControles();
            }
            catch (Exception ex)
            {
                manejador.DeshacerTransaccion();
                Herramientas.Forms.Mensajes.Error(ex.Message);
            }
        }

        private void LimpiarControles()
        {
            txt_nombre.Text = "";
            txt_diaCorte.Text = "";
            txt_diasParaPago.Text = "";
            txt_PorcentajeInteres.Text = "";
            pb_imagen.Image = null;
            chb_Activo.Checked = false;
            txt_saldo.Text = "";
            chb_esDeAhorro.Checked = false;

        }
        private void CargarCuentaSeleccionada()
        {
            if (CuentaSeleccionada == null) return;
            txt_nombre.Text = CuentaSeleccionada.St_NombreCuenta;
            if (!CuentaSeleccionada.Bo_EsDeAhorro)
            {
                txt_diaCorte.Text = CuentaSeleccionada.In_DiaCorte.ToString();
                txt_diasParaPago.Text = CuentaSeleccionada.In_DiasParaPago.ToString();
                txt_PorcentajeInteres.Text = CuentaSeleccionada.Do_PorcentajeInteresMensual.ToString();
            }
            pb_imagen.Image = CuentaSeleccionada.Bm_Imagen;
            chb_Activo.Checked = !CuentaSeleccionada.EstaDeshabilitado;
            txt_saldo.Text = CuentaSeleccionada.Do_saldo.ToString();
            chb_esDeAhorro.Checked = CuentaSeleccionada.Bo_EsDeAhorro;
        }
        private void pb_imagen_Click(object sender, EventArgs e)
        {
            String bitmap = Herramientas.Archivos.Dialogos.BuscarArchivoDeImagen();
            if (bitmap != null)
            {
                Bitmap imagen = new Bitmap(bitmap);
                pb_imagen.Image = imagen;
            }
        }
        private void cmb_cuentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_cuentas.SelectedIndex >= 0)
            {
                CuentaSeleccionada = cuentas[cmb_cuentas.SelectedIndex];
                CargarCuentaSeleccionada();
            }

        }

        private void chb_esDeAhorro_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_esDeAhorro.Checked)
            {
                txt_diaCorte.Text = "";
                txt_diasParaPago.Text = "";
                txt_PorcentajeInteres.Text = "";


                txt_diaCorte.Enabled = false;
                txt_diasParaPago.Enabled = false;
                txt_PorcentajeInteres.Enabled = false;

            }
            else
            {
                txt_diaCorte.Enabled = true;
                txt_diasParaPago.Enabled = true;
                txt_PorcentajeInteres.Enabled = true;
            }
        }
    }
}
