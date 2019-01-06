using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ContabilidadElectronica.Formularios
{
    public partial class ElegirTipoCatalogo : Form
    {
        public String CatalogoElegido { get; set; }
        public ElegirTipoCatalogo()
        {
            InitializeComponent();
        }
        

        private void btn_cuentas_Click(object sender, EventArgs e)
        {
            CatalogoElegido = "cuentas";
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CatalogoElegido = "bancos";
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CatalogoElegido = "monedas";
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CatalogoElegido = "formasPago";
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
