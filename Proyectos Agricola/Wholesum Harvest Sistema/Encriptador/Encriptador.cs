using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Encriptador.Cifrado;

namespace Encriptador
{
    public partial class Encriptador : Form
    {
        public Encriptador()
        {
            InitializeComponent();
        }

        private void btn_encriptar_Click(object sender, EventArgs e)
        {
            //if (cmb_tipoCifrado.SelectedItem == null) { MessageBox.Show("Seleccione un tipo de cifrado."); return; }
            //if (cmb_tipoCifrado.SelectedItem.ToString().Equals("AES"))
            //{
            //    txt_encriptado.Text = CifradoAES.EncriptarTexto(txt_original.Text);
            //}
            //else if (cmb_tipoCifrado.SelectedItem.ToString().Equals("MD5"))
            //{
                txt_encriptado.Text = CifradoMD5.EncriptarTexto(txt_original.Text);
            //}
        }

        private void cmb_tipoCifrado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
