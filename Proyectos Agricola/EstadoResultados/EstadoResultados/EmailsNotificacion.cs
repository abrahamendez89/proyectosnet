using Herramientas.Archivos;
using Herramientas.WPF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EstadoResultados
{
    public partial class EmailsNotificacion : Form
    {
        Variable vars;
        public EmailsNotificacion()
        {
            InitializeComponent();
            vars = new Variable("data");
            txt_emails.Text = vars.ObtenerValorVariable<String>("EMAILS_USUARIO");
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                vars.GuardarValorVariable("EMAILS_USUARIO", txt_emails.Text.Trim());
                Mensajes.Informacion("Se ha guardado los emails correctamente.");
            }
            catch(Exception ex)
            {
                Mensajes.Error("Error al intentar guardar: "+ex.Message);
            }
        }
    }
}
