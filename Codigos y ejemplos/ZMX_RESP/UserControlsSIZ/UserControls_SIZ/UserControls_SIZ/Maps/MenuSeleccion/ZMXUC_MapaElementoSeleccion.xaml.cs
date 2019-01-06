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

namespace UserControlsSIZ.Maps.MenuSeleccion
{
    /// <summary>
    /// Interaction logic for ZMXUC_MapaElementoSeleccion.xaml
    /// </summary>
    public partial class ZMXUC_MapaElementoSeleccion : UserControl
    {
        public delegate void _ZMX_Click(ZMXUC_MapaElementoSeleccion elemento);
        public event _ZMX_Click ZMX_Click;

        public ZMXUC_MapaElementoSeleccion()
        {
            InitializeComponent();
            this.MouseUp += ZMXUC_MapaElementoSeleccion_MouseUp;
        }

        private void ZMXUC_MapaElementoSeleccion_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if(ZMX_Click != null)
            {
                ZMX_Click(this);
            }
        }

        public object ZMX_ObjetoLocalidad { get; set; }
        public String ZMX_Titulo { get { return txtTitulo.Text; } set { txtTitulo.Text = value; } }

    }
}
