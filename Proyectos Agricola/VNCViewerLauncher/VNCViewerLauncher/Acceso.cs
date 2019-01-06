using Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VNCViewerLauncher
{
    public partial class Acceso : Form
    {
        public Boolean Aprobado { get; set; }

        public Acceso()
        {
            InitializeComponent();
            txt_pass.KeyPress += txt_pass_KeyPress;
        }

        void txt_pass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                pb_icono_Click(null, null);
            }
        }

        private void pb_icono_Click(object sender, EventArgs e)
        {
            String passDinamico = DateTime.Now.Day.ToString("00") + DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00");

            if (passDinamico.Equals(txt_pass.Text))
            {
                Aprobado = true;
                this.Hide();
            }
            else
            {
                Dialogo d = new Dialogo("Contraseña incorrecta.", "Incorrecto");
                d.ShowDialog();
                return;
            }
            
        }


        private void pb_cancelar_Click_1(object sender, EventArgs e)
        {
            Aprobado = false;
            this.Hide();
        }

    }
}
