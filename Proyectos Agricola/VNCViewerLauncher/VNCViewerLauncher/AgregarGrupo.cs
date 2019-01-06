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
    public partial class AgregarGrupo : Form
    {
        public Boolean GuardarCambios { get; set; }
        private _Grupo grupo;
        public _Grupo GrupoCreado { get { return grupo; } set { this.grupo = value; CargarDatos(); } }

        public AgregarGrupo()
        {
            InitializeComponent();
        }

        private void CargarDatos()
        {
            txt_nombreGrupo.Text = GrupoCreado.St_NombreGrupo;
        }

        private void pb_icono_Click(object sender, EventArgs e)
        {
            if (grupo == null) grupo = new _Grupo();
            grupo.EsModificado = true;
            grupo.St_NombreGrupo = txt_nombreGrupo.Text.Trim();
            this.GuardarCambios = true;
            this.Hide();
        }

        private void pb_cancelar_Click(object sender, EventArgs e)
        {
            this.GuardarCambios = false;
            this.Hide();
        }

    }
}
