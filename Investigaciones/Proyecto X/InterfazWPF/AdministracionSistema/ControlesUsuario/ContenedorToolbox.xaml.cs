
using System;
using System.Linq;
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

namespace InterfazWPF
{
	/// <summary>
	/// Lógica de interacción para ContenedorToolbox.xaml
	/// </summary>
	public partial class ContenedorToolbox : UserControl
	{
        public delegate void ClickEvent(String titulo, Bitmap imagen);
        public event ClickEvent clickOpcionSistema;

        public delegate void ClickEvent2(Type tipo, String titulo, String metodo);
        public event ClickEvent2 clickOpcionVentana;

		public ContenedorToolbox()
		{
			this.InitializeComponent();
		}
        List<ElementoToolBox> elementosToolBox = new List<ElementoToolBox>();
        List<ElementoSistema> elementosOpciones = new List<ElementoSistema>();

        public void AgregarToolBox(ElementoToolBox elemento)
        {
            elemento.clickEvent += elemento_clickEvent;
            elemento.enviarTitulo += elemento_enviarTitulo;
            elementosToolBox.Add(elemento);
        }

        void elemento_clickEvent(Type tipo, string titulo, string metodo)
        {
            clickOpcionVentana(tipo,titulo, metodo);
        }

        void elemento_clickEvent(string titulo, Bitmap imagen)
        {
            clickOpcionSistema(titulo, imagen);
        }


        public void AgregarElementoSistema(ElementoSistema elemento)
        {
            elemento.clickEvent += elemento_clickEvent;
            elemento.enviarTitulo += elemento_enviarTitulo;
            elementosOpciones.Add(elemento);
        }

        void elemento_enviarTitulo(string titulo)
        {
            if (titulo.Equals(""))
            {
                txt_seleccionadoSistema.Visibility = System.Windows.Visibility.Hidden;
                txt_seleccionadoOpciones.Visibility = System.Windows.Visibility.Hidden;
            }
            else
            {
                txt_seleccionadoSistema.Visibility = System.Windows.Visibility.Visible;
                txt_seleccionadoOpciones.Visibility = System.Windows.Visibility.Visible;
            }
            txt_seleccionadoSistema.Text = titulo;
            txt_seleccionadoOpciones.Text = titulo;
        }
        public void BorrarElementos()
        {
            elementosToolBox.Clear();
            elementosOpciones.Clear();
            pnl_elementos.Children.Clear();
        }
        public void DibujarElementos()
        {
            elementosToolBox = (from t in elementosToolBox orderby t.Titulo ascending select t).ToList<ElementoToolBox>();
            
            pnl_elementos.Children.Clear();
            foreach (UIElement elemento in elementosToolBox)
            {
                pnl_elementos.Children.Add(elemento);
            }
            foreach (UIElement elemento in elementosOpciones)
            {
                pnl_elementos.Children.Add(elemento);
            }
        }

	}
}