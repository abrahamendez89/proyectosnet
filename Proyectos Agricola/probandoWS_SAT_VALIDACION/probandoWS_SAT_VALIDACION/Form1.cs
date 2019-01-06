using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using probandoWS_SAT_VALIDACION.Validador;

namespace probandoWS_SAT_VALIDACION
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Validador.ConsultaCFDIServiceClient con = new ConsultaCFDIServiceClient();

            /*
             * Parámetros: expresionImpresa, 
             * Cadena que contiene los parámetros de consulta: 
             * re = rfc Emisor, 
             * rr = RFC Receptor y 
             * id= UUDI, la cadena puede variar dependiendo del lenguaje, en el caso de C# la cadena a enviar es:
             */

            String cadena = "?re=" + txt_rfcEmisor.Text + "&rr=" + txt_rfcReceptor.Text + "&tt=" + txt_total.Text + "&id=" + txt_uuid.Text;
            Acuse acuse = con.Consulta(cadena);
            txt_estatus.Text = acuse.Estado;
        }
    }
}
