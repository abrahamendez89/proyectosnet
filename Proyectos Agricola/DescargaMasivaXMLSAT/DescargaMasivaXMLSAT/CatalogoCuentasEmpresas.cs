using Dominio;
using Herramientas.ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DescargaMasivaXMLSAT
{
    public partial class CatalogoCuentasEmpresas : Form
    {
        ManejadorDB manejador;
        List<_CuentaEmpresa> empresasCuentas;
        _CuentaEmpresa empresaSeleccionada;
        public CatalogoCuentasEmpresas(ManejadorDB manejador)
        {
            InitializeComponent();
            this.manejador = manejador;
            CargarLista();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (empresaSeleccionada == null) empresaSeleccionada = new _CuentaEmpresa();
            empresaSeleccionada.NombreEmpresa = txt_Nombre.Text;
            empresaSeleccionada.Usuario = txt_Usuario.Text;
            empresaSeleccionada.Contrasena = txt_contra.Text;
            empresaSeleccionada.EstaDeshabilitado = !chb_Activo.Checked;
            empresaSeleccionada.EsModificado = true;
            manejador.Guardar(empresaSeleccionada);
            CargarLista();
            Limpiar();
            Herramientas.Forms.Mensajes.Informacion("Se guardo correctamente.");
        }
        private void Limpiar()
        {
            txt_Nombre.Text = "";
            txt_contra.Text = "";
            txt_Usuario.Text = "";
            chb_Activo.Checked = false;
            empresaSeleccionada = null;
            cmb_empresas.SelectedItem = null;
        }
        private void CargarLista()
        {
            empresasCuentas = manejador.CargarLista<_CuentaEmpresa>("select * from _CuentaEmpresa");
            cmb_empresas.Items.Clear();
            foreach (_CuentaEmpresa empresa in empresasCuentas)
            {
                cmb_empresas.Items.Add(empresa.NombreEmpresa);
            }

        }
        private void CargarSeleccionada()
        {
            txt_Nombre.Text = empresaSeleccionada.NombreEmpresa;
            txt_contra.Text = empresaSeleccionada.Contrasena;
            txt_Usuario.Text = empresaSeleccionada.Usuario;
            chb_Activo.Checked = !empresaSeleccionada.EstaDeshabilitado;
        }

        private void cmb_empresas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_empresas.SelectedItem != null)
            {
                empresaSeleccionada = empresasCuentas[cmb_empresas.SelectedIndex];
                CargarSeleccionada();
            }
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
