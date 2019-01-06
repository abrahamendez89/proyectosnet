using InterfazWPF.Modulos.ControlesUsuarioGenerales;
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
	/// Lógica de interacción para ElementoActividad.xaml
	/// </summary>
	public partial class ElementoActividad : UserControl
	{
        //public LineaConectorActividades LineaLogica { get; set; }
        private List<LineaConectorActividades> lineasLogicas = new List<LineaConectorActividades>();
        public Point Ubicacion { get; set; }
        public Size Size { get { return new Size(Width, Height); } set { Width = value.Width; Height = value.Height; } }
        public ElementoActividad()
		{
			this.InitializeComponent();
		}
        public void AgregarRelacion(LineaConectorActividades lineaLogica)
        {
            lineasLogicas.Add(lineaLogica);
        }
        public void ActualizarLineasVisuales()
        {
            foreach (LineaConectorActividades lineaLogica in lineasLogicas)
            {
                lineaLogica.ActualizarLinea();
            }
        }
	}
}