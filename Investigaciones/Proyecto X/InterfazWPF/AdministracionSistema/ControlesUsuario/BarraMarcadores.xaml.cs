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

namespace InterfazWPF
{
	/// <summary>
	/// Lógica de interacción para BarraMarcadores.xaml
	/// </summary>
	public partial class BarraMarcadores : UserControl
	{
		public BarraMarcadores()
		{
			this.InitializeComponent();
		}


        public void AgregarElementoMarcador(ElementoMarcador elemento)
        {
            pnl_elementos.Children.Add(elemento);
        }


	}
}