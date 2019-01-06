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

namespace InterfazWPF
{
	/// <summary>
	/// Lógica de interacción para ElementoOpcionVentanaEmergente.xaml
	/// </summary>
	public partial class ElementoOpcionVentanaEmergente : UserControl
	{
        public delegate void ClickEvento(String metodo, Type tipo);
        public event ClickEvento clickEvento;
		public ElementoOpcionVentanaEmergente()
		{
			this.InitializeComponent();
            //img_icono.MouseDown += img_icono_MouseDown;
            this.MouseDown += img_icono_MouseDown;
		}

        void img_icono_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (clickEvento != null)
                clickEvento(Metodo, Tipo);
        }
        public Bitmap Imagen { get { return HerramientasWindow.ImageSourceABitmap(img_icono.Source, System.Drawing.Imaging.ImageFormat.Png); } set { img_icono.Source = HerramientasWindow.BitmapAImageSource(value); img_iconoReflejo.Source = HerramientasWindow.BitmapAImageSource(value); } }
        public String Titulo { get { return txt_titulo.Text; } set { txt_titulo.Text = value; } }
        public Type Tipo { get; set; }
        public String Metodo { get; set; }
	}
}