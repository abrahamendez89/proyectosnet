
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
	/// Lógica de interacción para ElementoSistema.xaml
	/// </summary>
	public partial class ElementoSistema : UserControl
	{
        public delegate void ClickEvent(String titulo, Bitmap imagen);
        public event ClickEvent clickEvent;

        public delegate void EnviarTitulo(String titulo);
        public event EnviarTitulo enviarTitulo;
        private String titulo;
        private Bitmap imagen;
        public Bitmap Imagen { get { return imagen; } set { imagen = value; img_imagen.Source = HerramientasWindow.BitmapAImageSource(value); img_imagen_Resplandor.Source = HerramientasWindow.BitmapAImageSource(value); SetColorResplandor(); } }
        public String Titulo { get { return titulo; } set { titulo = value; } }
        public ElementoSistema()
		{
			this.InitializeComponent();
            img_imagen.MouseUp += img_imagen_MouseDown;
            img_imagen.MouseEnter += img_imagen_MouseEnter;
            img_imagen.MouseLeave += img_imagen_MouseLeave;            
		}
        private void SetColorResplandor()
        {
            if (Imagen == null) return;
            System.Drawing.Color pixelColor = Imagen.GetPixel(Imagen.Height / 2, Imagen.Width / 2);
            
            img_imagen_Resplandor.Effect =
            new DropShadowEffect
            {
                Color = new System.Windows.Media.Color() { A = pixelColor.A, R = pixelColor.R, G = pixelColor.G, B = pixelColor.B },
                Direction = 315,
                ShadowDepth = 0,
                Opacity = 100,
                BlurRadius = 10,
                RenderingBias = RenderingBias.Performance
            };
        }
        void img_imagen_MouseLeave(object sender, MouseEventArgs e)
        {
            enviarTitulo("");
        }

        void img_imagen_MouseEnter(object sender, MouseEventArgs e)
        {
            enviarTitulo(titulo);
        }

        void img_imagen_MouseDown(object sender, MouseButtonEventArgs e)
        {
            clickEvent(Titulo, Imagen);
        }
	}
}