using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GeneradorCodigoSQL
{
    public partial class NombreBD : Form
    {
        public NombreBD()
        {
            InitializeComponent();
        }
        public String nombreDB { get { return txt_nombreBD.Text.Trim(); } set { txt_nombreBD.Text = value; } }
        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            //nombreDB = txt_nombreBD.Text.Trim();
            Visible = false;
        }
    }
}
