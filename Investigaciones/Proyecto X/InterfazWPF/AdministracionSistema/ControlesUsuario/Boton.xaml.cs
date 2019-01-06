using System;
using System.Collections.Generic;
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
using System.Drawing;

namespace InterfazWPF
{
	/// <summary>
	/// Lógica de interacción para Boton.xaml
	/// </summary>
	public partial class Boton : UserControl
	{
		public String Text
		{
			get
			{
				return this.txt_nombre.Text;
			}
			set
			{
				this.txt_nombre.Text = value;
			}
		}
        public ImageSource Icono { get { return img_icono.Source; } set { img_icono.Source = value; mostrarIcono(); } }
        private int top = 2;
        private void mostrarIcono()
        {
            img_icono.Visibility = System.Windows.Visibility.Visible;
            txt_nombre.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            txt_nombre.Margin = new Thickness(img_icono.Width+8, top, 0, 0);
        }
        private void ocultarIcono()
        {
            img_icono.Visibility = System.Windows.Visibility.Hidden;
            txt_nombre.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            txt_nombre.Margin = new Thickness(0, top, 0, 0);
        }
		public Boolean Habilitado
		{
			get
			{
                
				return this.IsEnabled;
			}
			set
			{
                String animacion = "";
                if (value)
                    animacion = "HabilitarAnimacion";
                else
                    animacion = "DeshabilitarAnimacion";
                Storyboard mouseEnter = (Storyboard)this.FindResource(animacion);
                mouseEnter.Begin();
                this.IsEnabled = value;
			}
		}
		public Boton()
		{
			this.InitializeComponent();
            this.MouseEnter += Boton_MouseEnter;
            this.MouseLeave += Boton_MouseLeave;
            ocultarIcono();
		}

        void Boton_MouseLeave(object sender, MouseEventArgs e)
        {
            Storyboard mouseEnter = (Storyboard)this.FindResource("OnMouseLeave1");
            mouseEnter.Begin();
        }

        void Boton_MouseEnter(object sender, MouseEventArgs e)
        {
            Storyboard mouseEnter = (Storyboard)this.FindResource("OnMouseEnter1");
            mouseEnter.Begin();
        }


	}
}