using Microsoft.Maps.MapControl.WPF;
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
using UserControlsSIZ.Utilerias;

namespace UserControlsSIZ.Maps
{
    /// <summary>
    /// Interaction logic for ZMXUC_MapaPin.xaml
    /// </summary>
    public partial class ZMXUC_MapaPin : UserControl
    {

        public Location ZMX_Location { get; set; }

        public Brush ZMX_Color { get { return icono.IconoColor; }
            set
            {
                Brush clr = Colores.ConvertirColorABrush( Colores.OscurecerColor(Colores.ConvertirBrushAColor(value), 80));
                icono.IconoColor = clr;
            } }

        public Iconos.IconAwesomeSIZ.AwesomeIcons ZMX_Icono{ get { return icono.Icono; } set { icono.Icono = value; } }

        public double ZMX_Height { get { return this.Height; } set { icono.Height = value; icono.Width = value; Margin = new Thickness(-1,5,1,0); } }

        public ZMXUC_MapaPin()
        {
            InitializeComponent();
        }
    }
}
