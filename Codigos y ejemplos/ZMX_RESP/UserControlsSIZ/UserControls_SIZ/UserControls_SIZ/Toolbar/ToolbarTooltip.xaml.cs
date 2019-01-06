using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UserControlsSIZ.Toolbar
{
    /// <summary>
    /// Interaction logic for ToolbarTooltip.xaml
    /// </summary>
    public partial class ToolbarTooltip : UserControl
    {
        public ToolbarTooltip()
        {
            InitializeComponent();
            this.SizeChanged += ToolbarTooltip_SizeChanged;


            Text = "Este es un tooltip \ncon saltos de linea.";

        }

        private void ToolbarTooltip_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            rtgFondo.RadiusX = this.ActualHeight * 0.2;
            rtgFondo.RadiusY = this.ActualHeight * 0.2;
        }
        public String Text { get { return txtMensaje.Text; } set { txtMensaje.Text = value; this.Margin = new Thickness(this.ActualWidth * 0.4 * -1, 5, 15, 5); } }

        public Brush StrokeTooltip { get { return rtgFondo.Stroke; } set { rtgFondo.Stroke = value; rtgTriangulo.Fill = value; rtgTriangulo.Stroke = value; } }

    }
}
