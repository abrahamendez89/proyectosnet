using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Herramientas.WPF;
using Herramientas.Forms;

namespace ContabilidadElectronica.ControlesDeUsuario
{
    public partial class ElementoMenu : UserControl
    {
        public delegate void DoubleClickCustom(String titulo);
        public event DoubleClickCustom doubleClickCustom;
        public ElementoMenu()
        {
            InitializeComponent();
            this.MouseEnter += ElementoMenu_MouseEnter;
            this.MouseLeave += ElementoMenu_MouseLeave;
            pb_Imagen.MouseEnter += ElementoMenu_MouseEnter;
            pb_Imagen.MouseLeave += ElementoMenu_MouseLeave;
           
            lbl_titulo.MouseEnter += ElementoMenu_MouseEnter;
            lbl_titulo.MouseLeave += ElementoMenu_MouseLeave;

            //lbl_titulo.DoubleClick += ElementoMenu_DoubleClick;
            //pb_Imagen.DoubleClick += ElementoMenu_DoubleClick;
            //this.DoubleClick += ElementoMenu_DoubleClick;

            lbl_titulo.MouseClick += lbl_titulo_MouseClick;
            pb_Imagen.MouseClick += lbl_titulo_MouseClick;
            this.MouseClick += lbl_titulo_MouseClick;

        }

        void lbl_titulo_MouseClick(object sender, MouseEventArgs e)
        {
            if (doubleClickCustom != null)
                doubleClickCustom(textoOriginal);
            else
                Mensajes.Advertencia("Es necesario configurar la referencia del menú.");
        }

        void ElementoMenu_DoubleClick(object sender, EventArgs e)
        {
            if (doubleClickCustom != null)
                doubleClickCustom(textoOriginal);
            else
                Mensajes.Advertencia("Es necesario configurar la referencia del menú.");
        }

        void ElementoMenu_MouseLeave(object sender, EventArgs e)
        {
            lbl_titulo.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
            this.BackColor = Color.White;
            if (circular != null)
            {
                circular.Abort();
                lbl_titulo.Text = textoOriginal;
            }
        }

        void ElementoMenu_MouseEnter(object sender, EventArgs e)
        {
            lbl_titulo.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
            this.BackColor = Color.WhiteSmoke;
            if (textoOriginal.Length > 12)
            {
                circular = new Thread(CicularTexto);
                circular.Start();
            }
        }
        public Image Imagen { get { return pb_Imagen.Image; } set { pb_Imagen.Image = value; } }
        public String Titulo { get { return lbl_titulo.Text; } set { lbl_titulo.Text = value; tituloConEspaciado = lbl_titulo.Text + espaciado; textoOriginal = lbl_titulo.Text; } }
        Thread circular;
        String texto;
        String espaciado = "          ";
        String tituloConEspaciado;
        String textoOriginal;
        private void CicularTexto()
        {
            int i = 0;
            while (true)
            {
                try
                {
                    Thread.Sleep(100);
                    i++;
                    if (i >= tituloConEspaciado.Length)
                        i = 1;
                    int restante = i;

                    texto = tituloConEspaciado.Substring(i, tituloConEspaciado.Length - i);
                    texto += tituloConEspaciado.Substring(0, restante);
                    lbl_titulo.Text = texto;
                }
                catch
                {
                }
            }
        }
    }
}
