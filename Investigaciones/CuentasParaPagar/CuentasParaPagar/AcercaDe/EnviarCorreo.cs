using Herramientas.Mail;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CuentasParaPagar.AcercaDe
{
    public partial class EnviarCorreo : Form
    {
        public EnviarCorreo()
        {
            InitializeComponent();
            //cic.control.cuentas
            //cic.control.cuentas1
            cmb_asunto.Items.Add("Para felicitar");
            cmb_asunto.Items.Add("Para reportar un error");
            cmb_asunto.Items.Add("Para enviarte mi idea");
            cmb_asunto.Items.Add("Para saludar");
            cmb_asunto.Items.Add("Para contactarte y charlar");
        }

        private void btn_enviar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txt_email.Text.Trim().Equals("") && !Validaciones.EsEmailValido(txt_email.Text.Trim()))
                {
                    Herramientas.Forms.Mensajes.Exclamacion("Oye, si vas a escribir tu Email, por favor verifica que sea válido!");
                    return;
                }
                if (txt_correo.Text.Trim().Equals(""))
                {
                    Herramientas.Forms.Mensajes.Exclamacion("Para enviar un correo, antes debes escribirlo!");
                    return;
                }
                if (cmb_asunto.SelectedItem == null)
                {
                    Herramientas.Forms.Mensajes.Exclamacion("Me gustaría saber el asunto por el que envías este correo!");
                    return;
                }
                if (txt_nombre.Text.Trim().Equals(""))
                {
                    Herramientas.Forms.Mensajes.Exclamacion("Por favor, dime como te llamas");
                    return;
                }

                Gmail gmail = new Gmail();
                gmail.EmailUsar = "cic.control.cuentas@gmail.com";
                gmail.ContrasenaUsar = "cic.control.cuentas1";
                gmail.EmailDestino = gmail.EmailUsar + "; " + txt_email.Text.Trim();
                gmail.ContenidoHTML = txt_correo.Text;
                gmail.Asunto = cmb_asunto.SelectedItem.ToString();
                gmail.NombreAMostrar = txt_nombre.Text.Trim();
                gmail.EnviarCorreo(Gmail.Prioridad.Normal);

                Herramientas.Forms.Mensajes.Informacion("El correo ha sido enviado exitosamente.");
                Close();
            }
            catch (Exception ex)
            {
                Herramientas.Forms.Mensajes.Error(ex.Message);
            }
        }
    }
}
