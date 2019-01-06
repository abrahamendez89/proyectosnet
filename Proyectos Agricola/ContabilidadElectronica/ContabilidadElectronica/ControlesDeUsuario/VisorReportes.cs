using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ContabilidadElectronica.ControlesDeUsuario
{
    public partial class VisorReportes : Form
    {
        public VisorReportes()
        {
            InitializeComponent();
        }

        private void VisorReportes_Load(object sender, EventArgs e)
        {

            this.rp.RefreshReport();
        }
    }
}
