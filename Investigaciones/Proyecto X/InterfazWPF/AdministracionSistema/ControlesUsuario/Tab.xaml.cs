
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using InterfazWPF.AdministracionSistema;

namespace InterfazWPF
{
	/// <summary>
	/// Lógica de interacción para Tab.xaml
	/// </summary>
	public partial class Tab : UserControl
	{
        public delegate void Click(int actualTab);
        public event Click click;

        public delegate void Cerrado(int tabCerrado);
        public event Cerrado cerrado;

        public System.Windows.Media.Brush Fill { get { return rtg_dos.Fill; } set { rtg_dos.Fill = value; } }

        public int actualTab;
		public Tab()
		{
			this.InitializeComponent();

            img_cerrar.Source = HerramientasWindow.BitmapAImageSource(new Bitmap(@"Imagenes\Iconos\Sistema\CerrarTab.png")); 

            img_cerrar.MouseDown += img_cerrar_MouseDown;

            rtg_dos.MouseDown += click_control;
            txt_tituloTab.MouseDown += click_control;
            img_icono.MouseDown += click_control;

		}

        void click_control(object sender, MouseButtonEventArgs e)
        {
            if (e.MiddleButton == MouseButtonState.Pressed)
                cerrado(actualTab);
            else if (e.LeftButton == MouseButtonState.Pressed)
                click(actualTab);
        }

        void img_cerrar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            cerrado(actualTab);
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //click(actualTab);
        }


        public void Activar()
        {
            Storyboard evento = (Storyboard)this.FindResource("Activar");
            evento.Begin();
        }
        public void Desactivar()
        {
            Storyboard evento = (Storyboard)this.FindResource("Desactivar");
            evento.Begin();
        }
	}
}