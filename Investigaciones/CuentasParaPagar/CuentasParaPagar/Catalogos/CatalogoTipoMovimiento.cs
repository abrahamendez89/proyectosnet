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

namespace CuentasParaPagar.Catalogos
{
    public partial class CatalogoTipoMovimiento : Form
    {
        iSQL sql;
        ManejadorDB manejador;
        List<_TipoMovimiento> tiposMovimientos;
        _TipoMovimiento tipoSeleccionado;
        public CatalogoTipoMovimiento(iSQL sql)
        {
            InitializeComponent();
            this.sql = sql;
            manejador = new ManejadorDB(this.sql);
            CargarTipos();
            cmb_TiposMovimientos.SelectedIndexChanged += cmb_TiposMovimientos_SelectedIndexChanged;
        }

        void cmb_TiposMovimientos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_TiposMovimientos.SelectedIndex >= 0)
            {
                tipoSeleccionado = tiposMovimientos[cmb_TiposMovimientos.SelectedIndex];
                CargarTipoSeleccionado();
            }
        }

        private void CargarTipoSeleccionado()
        {
            if (tipoSeleccionado != null)
            {
                txt_nombre.Text = tipoSeleccionado.St_Nombre;

                if (tipoSeleccionado.St_Tipo.Equals("E"))
                {
                    chb_entrada.Checked = true;
                    chb_salida.Checked = false;
                }
                else if (tipoSeleccionado.St_Tipo.Equals("S"))
                {
                    chb_entrada.Checked = false;
                    chb_salida.Checked = true;
                }

                chb_EstaActivo.Checked = !tipoSeleccionado.EstaDeshabilitado;
                chb_esDividido.Checked = tipoSeleccionado.Bo_SeDivideEnMultiplesPagos;
                chb_aplicaInmediato.Checked = tipoSeleccionado.Bo_SeAplicaInmediato;
            }
        }

        private void CargarTipos()
        {
            tiposMovimientos = manejador.CargarLista<_TipoMovimiento>("select * from _TipoMovimiento");
            cmb_TiposMovimientos.Items.Clear();
            if (tiposMovimientos != null)
                foreach (_TipoMovimiento tipo in tiposMovimientos)
                {
                    String estado = "";
                    if (tipo.EstaDeshabilitado)
                        estado = " [Desactivado]";
                    cmb_TiposMovimientos.Items.Add(tipo.St_Nombre + estado);
                }
        }

        private void chb_entrada_CheckedChanged(object sender, EventArgs e)
        {
            chb_salida.Checked = !chb_entrada.Checked;
        }

        private void chb_salida_CheckedChanged(object sender, EventArgs e)
        {
            chb_entrada.Checked = !chb_salida.Checked;
        }
        private void Limpiar()
        {
            txt_nombre.Text = "";
            chb_entrada.Checked = false;
            chb_salida.Checked = false;
            tipoSeleccionado = null;
            chb_EstaActivo.Checked = false;
            chb_esDividido.Checked = false;
            chb_aplicaInmediato.Checked = false;
        }
        private void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (tipoSeleccionado != null && tipoSeleccionado.St_Nombre.Equals("Intereses Mensuales"))
                {
                    Herramientas.Forms.Mensajes.Exclamacion("Este movimiento no se puede modificar");
                    return;
                }

                if (tipoSeleccionado == null) tipoSeleccionado = new _TipoMovimiento();
                tipoSeleccionado.EsModificado = true;

                tipoSeleccionado.St_Nombre = txt_nombre.Text;
                if (chb_entrada.Checked)
                {
                    tipoSeleccionado.St_Tipo = "E";
                    tipoSeleccionado.Do_MultiplicadorSigno = -1;
                }
                if (chb_salida.Checked)
                {
                    tipoSeleccionado.St_Tipo = "S";
                    tipoSeleccionado.Do_MultiplicadorSigno = 1;
                }

                tipoSeleccionado.EstaDeshabilitado = !chb_EstaActivo.Checked;
                tipoSeleccionado.Bo_SeDivideEnMultiplesPagos = chb_esDividido.Checked;
                tipoSeleccionado.Bo_SeAplicaInmediato = chb_aplicaInmediato.Checked;
                
                manejador.Guardar(tipoSeleccionado);
                Limpiar();
                CargarTipos();
                Herramientas.Forms.Mensajes.Informacion("Guardado con éxito");
            }
            catch (Exception ex)
            {
                Herramientas.Forms.Mensajes.Error(ex.Message);
            }
        }
    }
}
