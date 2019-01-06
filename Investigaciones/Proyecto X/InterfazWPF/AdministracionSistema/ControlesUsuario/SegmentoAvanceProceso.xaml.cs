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
	/// Lógica de interacción para SegmentoAvanceProceso.xaml
	/// </summary>
	public partial class SegmentoAvanceProceso : UserControl
	{
		public SegmentoAvanceProceso()
		{
			this.InitializeComponent();
            txt_nombreProceso.Visibility = System.Windows.Visibility.Hidden;
		}
        public String NombreProceso { get { return txt_nombreProceso.Text; } set { txt_nombreProceso.Text = value; ToolTip = value; } }
        public void MostrarTitulo()
        {
            txt_nombreProceso.Visibility = System.Windows.Visibility.Visible;
        }
        public void OcultarTitulo()
        {
            txt_nombreProceso.Visibility = System.Windows.Visibility.Hidden;
        }
	}
}