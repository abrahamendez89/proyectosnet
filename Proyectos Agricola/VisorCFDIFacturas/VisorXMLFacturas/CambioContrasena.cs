using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VisorXMLFacturas
{
    public partial class CambioContrasena : Form
    {
        public String ContrasenaNueva { get; set; }
        public CambioContrasena()
        {
            InitializeComponent();
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            if (txt_contra1.Text.Equals(txt_contra2.Text))
            {
                ContrasenaNueva = txt_contra1.Text;
                Hide();
            }
        }
    }
}
