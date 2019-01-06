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

namespace UserControlsSIZ.Maps
{
    /// <summary>
    /// Interaction logic for ZMXUC_MapaResultadosBusqueda.xaml
    /// </summary>
    public partial class ZMXUC_MapaResultadosBusqueda : UserControl
    {
        public ZMXUC_MapaResultadosBusqueda()
        {
            InitializeComponent();
        }

        public void ZMX_AgregarElementoBusqueda(ZMXUC_MapaElementoBusqueda elemento)
        {
            stpElementosBusqueda.Children.Add(elemento);
        }

        public void ZMX_Limpiar()
        {
            stpElementosBusqueda.Children.Clear();
        }

    }
}
