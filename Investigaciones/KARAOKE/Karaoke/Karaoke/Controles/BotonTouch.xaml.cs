using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Karaoke.Controles
{
    /// <summary>
    /// Lógica de interacción para BotonTouch.xaml
    /// </summary>
    public partial class BotonTouch : UserControl
    {
        public delegate void Click(BotonTouch boton);
        public event Click click;

        public String Indice { get; set; }
        public ImageSource Imagen { get { return img_imagen.Source; } set { img_imagen.Source = value; } }

        public String Etiqueta { get { return txt_TeclaAsignada.Text; } set { txt_TeclaAsignada.Text = value; } }

        public BotonTouch()
        {
            InitializeComponent();
            this.MouseDown += BotonTouch_MouseDown;
            txt_TeclaAsignada.Text = "";
        }

        void BotonTouch_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(click != null)click(this);
        }

        public void EjecutarEvento()
        {
            Storyboard evento = (Storyboard)this.FindResource("Mousedown");
            evento.Begin();
        }
        public char LetraActual { get; set; }
        public void SetLetra(char Letra)
        {
            LetraActual = Letra;
            txt_letra.Text = ""+Letra;
        }
        
    }
}
