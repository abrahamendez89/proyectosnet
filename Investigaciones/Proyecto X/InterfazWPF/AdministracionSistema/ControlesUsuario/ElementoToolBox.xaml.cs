
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using InterfazWPF.AdministracionSistema;
using System.Windows.Media.Effects;

namespace InterfazWPF
{
    /// <summary>
    /// Lógica de interacción para ElementoToolBox.xaml
    /// </summary>
    public partial class ElementoToolBox : UserControl
    {
        public delegate void ClickEvent(Type tipo, String titulo, String metodo);
        public event ClickEvent clickEvent;

        public delegate void EnviarTitulo(String titulo);
        public event EnviarTitulo enviarTitulo;

        public String Metodo { get; set; }
        public Type Tipo { get; set; }
        public ImageSource Imagen { get { return img_imagen.Source; } set { img_imagen.Source = value; img_imagen_Resplandor.Source = value;  SetColorResplandor(); }  }
        private String titulo;
        public String Titulo { get { return titulo; } set { titulo = value; } }
        public ElementoToolBox()
        {
            this.InitializeComponent();
            img_imagen.MouseUp += img_imagen_MouseDown;
            img_imagen.MouseEnter += img_imagen_MouseEnter;
            img_imagen.MouseLeave += img_imagen_MouseLeave;
        }

        private void SetColorResplandor()
        {
            if (Imagen == null) return;
            Bitmap bitmapT = HerramientasWindow.ImageSourceABitmap(Imagen);
            System.Drawing.Color pixelColor = bitmapT.GetPixel(bitmapT.Height/2, bitmapT.Width/2);

            img_imagen_Resplandor.Effect = 
            new DropShadowEffect
            {
                Color = new System.Windows.Media.Color(){A = pixelColor.A, R = pixelColor.R, G = pixelColor.G, B = pixelColor.B},
                Direction = 315,
                ShadowDepth = 0,
                Opacity = 100,
                BlurRadius = 10,
                RenderingBias = RenderingBias.Performance
            };
        }

        void img_imagen_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (clickEvent != null)
                clickEvent(Tipo, Titulo, Metodo);
        }

        void img_imagen_MouseLeave(object sender, MouseEventArgs e)
        {
            if (enviarTitulo != null)
                enviarTitulo("");
        }

        void img_imagen_MouseEnter(object sender, MouseEventArgs e)
        {
            if (enviarTitulo != null)
                enviarTitulo(titulo);
        }

    }
}