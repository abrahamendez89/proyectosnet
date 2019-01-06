using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Dominio.Sistema;
using Dominio.Modulos.ProgramaSiembra;

namespace Prototipos
{
    public partial class prot_croquis : Form
    {
        public prot_croquis()
        {
            InitializeComponent();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            prot_DetalleDeTabla p = new prot_DetalleDeTabla();
            p.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ManejadorDB manejador = new ManejadorDB();


            _ps_EspacioFisico espacioFisico = new _ps_EspacioFisico();
            espacioFisico.EsModificado = true;
            //espacioFisico.SNombreEspacio = "Sinaloa";

            manejador.Guardar(espacioFisico);


        }
    }
}
