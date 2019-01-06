using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ContabilidadElectronica.ControlesDeUsuario
{
    public partial class BotonConImagen : UserControl
    {
        Color colorDefault;
        public Image Imagen { get { return pb_imagen.Image; } set { pb_imagen.Image = value; } }
        public String Texto { get { return txt_titulo.Text; } set { txt_titulo.Text = value; } }
        public delegate void CustomClick(BotonConImagen boton);
        public event CustomClick customClick;
        public BotonConImagen()
        {
            InitializeComponent();
            this.MouseEnter += BotonConImagen_MouseEnter;
            this.MouseLeave += BotonConImagen_MouseLeave;
            txt_titulo.MouseEnter += BotonConImagen_MouseEnter;
            txt_titulo.MouseLeave += BotonConImagen_MouseLeave;
            pb_imagen.MouseEnter += BotonConImagen_MouseEnter;
            pb_imagen.MouseLeave += BotonConImagen_MouseLeave;
            panelFondo.MouseEnter += BotonConImagen_MouseEnter;
            panelFondo.MouseLeave += BotonConImagen_MouseLeave;

            this.MouseClick += BotonConImagen_MouseClick;
            pb_imagen.MouseClick += BotonConImagen_MouseClick;
            txt_titulo.MouseClick += BotonConImagen_MouseClick;
            panelFondo.MouseClick += BotonConImagen_MouseClick;
            colorDefault = this.BackColor;
            txt_titulo.BackColor = this.BackColor;
        }

        void BotonConImagen_MouseClick(object sender, MouseEventArgs e)
        {
            if (customClick != null)
                customClick(this);
        }

        void BotonConImagen_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = colorDefault;
            txt_titulo.BackColor = this.BackColor;
            txt_titulo.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
        }

        void BotonConImagen_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.LightBlue;
            txt_titulo.BackColor = this.BackColor;
            txt_titulo.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
        }

        private void txt_titulo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
