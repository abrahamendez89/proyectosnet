using Herramientas.Forms;
using Herramientas.WPF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Checador
{
    public partial class PedirContrasena : Form
    {
        public Boolean AccesoPermitido { get; set; }
        public PedirContrasena()
        {
            InitializeComponent();
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            if (txt_contra.Text.Trim().Equals("wh2012"))
            {
                AccesoPermitido = true;
                Close();
            }
            else
            {
                Mensajes.Informacion("Contraseña incorrecta, contacte al administrador.");
            }
        }

        private void txt_contra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btn_aceptar_Click(null, null);
            }
        }
    }
}
