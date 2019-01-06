using Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VNCViewerLauncher
{
    public partial class AgregarEquipo : Form
    {
        public Boolean GuardarCambios { get; set; }
        private _Equipo equipo;
        public _Equipo Equipo { get { return equipo; } set { this.equipo = value; CargarDatos(); } }

        public AgregarEquipo()
        {
            InitializeComponent();
        }

        private void CargarDatos()
        {
            txt_descripcion.Text = equipo.St_Descripcion;
            txt_nombre.Text = equipo.St_NombreEquipoDescripcion;
            txt_ruta.Text = equipo.St_IPONombreEquipo;
            txt_passVNC.Text = equipo.St_contraVNC;
        }

        private void pb_icono_Click(object sender, EventArgs e)
        {
            if (equipo == null) equipo = new _Equipo();
            equipo.EsModificado = true;
            equipo.St_NombreEquipoDescripcion = txt_nombre.Text.Trim();
            equipo.St_IPONombreEquipo = txt_ruta.Text.Trim();
            equipo.St_Descripcion = txt_descripcion.Text.Trim();
            equipo.St_contraVNC = txt_passVNC.Text;
            this.GuardarCambios = true;
            this.Hide();
        }


        private void pb_cancelar_Click_1(object sender, EventArgs e)
        {
            this.GuardarCambios = false;
            this.Hide();
        }

    }
}
