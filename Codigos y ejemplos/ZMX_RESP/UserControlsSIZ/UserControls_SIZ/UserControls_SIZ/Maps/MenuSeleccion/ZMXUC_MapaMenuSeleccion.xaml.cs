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
using Microsoft.Maps.MapControl.WPF;

namespace UserControlsSIZ.Maps.MenuSeleccion
{
    /// <summary>
    /// Interaction logic for ZMXUC_MapaMenuSeleccion.xaml
    /// </summary>
    public partial class ZMXUC_MapaMenuSeleccion : UserControl
    {
        public delegate void _ZMX_SeSeleccionoLocalidad(ZMXUC_MapaMenuSeleccion mms, object localidad);
        public event _ZMX_SeSeleccionoLocalidad ZMX_SeSeleccionoLocalidad;

        public Location ZMX_Location { get; set; }

        public ZMXUC_MapaMenuSeleccion()
        {
            InitializeComponent();
        }

        private void ZMX_Limpiar()
        {
            stpElementos.Children.Clear();
        }

        public void ZMX_AgregarLocalidad(object localidadObj, String nombreLocalidad)
        {            
            ZMXUC_MapaElementoSeleccion mes = new ZMXUC_MapaElementoSeleccion();
            mes.ZMX_ObjetoLocalidad = localidadObj;
            mes.ZMX_Titulo = nombreLocalidad;
            mes.ZMX_Click += Mes_ZMX_Click;
            stpElementos.Children.Add(mes);
        }

        private void Mes_ZMX_Click(ZMXUC_MapaElementoSeleccion elemento)
        {
            if(ZMX_SeSeleccionoLocalidad != null)
            {
                ZMX_SeSeleccionoLocalidad(this, elemento.ZMX_ObjetoLocalidad);
            }
        }
    }
}
