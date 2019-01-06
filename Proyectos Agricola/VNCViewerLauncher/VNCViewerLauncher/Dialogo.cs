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
    public partial class Dialogo : Form
    {
        public Boolean Respuesta { get; set; }

        public Dialogo(String dialogo, String titulo)
        {
            InitializeComponent();
            txt_dialogo.Text = dialogo;
            this.Text = titulo;
            pb_iconoAceptar.Select();
        }

        private void pb_icono_Click(object sender, EventArgs e)
        {
            this.Respuesta = true;
            this.Hide();
        }

        private void pb_cancelar_Click(object sender, EventArgs e)
        {
            this.Respuesta = false;
            this.Hide();
        }

        private void txt_dialogo_TextChanged(object sender, EventArgs e)
        {

        }

        private void Dialogo_Load(object sender, EventArgs e)
        {

        }

    }
}
