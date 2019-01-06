using System;
using System.Collections.Generic;
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

namespace Karaoke
{
	/// <summary>
	/// Lógica de interacción para textBoxRedondeado.xaml
	/// </summary>
	public partial class textBoxRedondeado : UserControl
	{
        public delegate void EjecutarBusqueda(String busqueda);
        public event EjecutarBusqueda ejecutarBusqueda;
        public String Text { get { return txt_busqueda.Text; } set { txt_busqueda.Text = value; } }
		public textBoxRedondeado()
		{
			this.InitializeComponent();
            this.MouseDown += textBoxRedondeado_MouseDown;
            txt_busqueda.KeyDown += txt_busqueda_KeyDown;
            txt_busqueda.MouseDown += txt_busqueda_MouseDown;
            txt_busqueda.IsEnabled = false;
		}

        void textBoxRedondeado_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SetFocus();
        }

        void txt_busqueda_MouseDown(object sender, MouseButtonEventArgs e)
        {
        }
        public void SetFocus()
        {
            txt_busqueda.IsEnabled = true;
            txt_busqueda.Focus();
        }
        void txt_busqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                 Dispatcher.Invoke(new Action(() =>
            {
                ejecutarBusqueda(txt_busqueda.Text);
                txt_busqueda.IsEnabled = false;
            }));
            }
        }

        void txt_busqueda_ejecutarBusqueda(string busqueda)
        {
            Dispatcher.Invoke(new Action(() =>
            {
                Buscar(busqueda);
                txt_busqueda.Text = "";
            }));
        }
        public void AgregarLetra(char letra)
        {
            txt_busqueda.Text += letra;
        }
        public void BorrarLetra()
        {
            txt_busqueda.Text = txt_busqueda.Text.Substring(0, txt_busqueda.Text.Length - 1);
        }
        public void Enter()
        {
            Buscar(txt_busqueda.Text.Trim());
            txt_busqueda.Text = "";
        }

        private void Buscar(string p)
        {
            ejecutarBusqueda(txt_busqueda.Text);
        }
        public void BorrarTodo()
        {
            txt_busqueda.Text = "";
        }
	}
}