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
    public partial class SolicitarContrasena : Form
    {
        public Boolean EsValido { get; set; }
        public SolicitarContrasena()
        {
            InitializeComponent();
        }

        private void btn_entrar_Click(object sender, EventArgs e)
        {
            String contra = DateTime.Now.Day.ToString("00") + DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00");
            EsValido = txt_contrasena.Text.Equals(contra);
            Hide();
        }

        private void txt_contrasena_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btn_entrar_Click(null, null);
            }
        }
    }
}
