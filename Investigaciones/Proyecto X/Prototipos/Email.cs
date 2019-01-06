using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Herramientas.Mail;
using System.IO;
using System.Drawing.Imaging;

namespace Prototipos
{
    public partial class Email : Form
    {
        public Email()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Mail m = new Mail();
                m.EmailDestino = txt_enviarA.Text;
                m.NombreAMostrar = txt_nombreMostrar.Text;
                m.Asunto = txt_Asunto.Text;
                m.ContenidoHTML = txt_contenido.Text;
                m.AgregarArchivoAdjunto(@"c:\GTA_Los_Simpsons-1.jpg", "GTA_Los_Simpsons-1.jpg");
                m.AgregarArchivoAdjunto(@"c:\Reporte.cs", "Reporte.cs");
                m.EnviarCorreo(Mail.Prioridad.Normal);
                MessageBox.Show("Correo enviado.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
