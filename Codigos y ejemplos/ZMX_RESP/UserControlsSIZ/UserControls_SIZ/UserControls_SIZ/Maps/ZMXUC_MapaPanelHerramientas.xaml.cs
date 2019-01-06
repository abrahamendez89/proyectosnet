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
using UserControlsSIZ.Toolbar;

namespace UserControlsSIZ.Maps
{
    /// <summary>
    /// Interaction logic for ZMXUC_MapaPanelHerramientas.xaml
    /// </summary>
    public partial class ZMXUC_MapaPanelHerramientas : UserControl
    {
        public delegate void _ZMX_ClickAceptar(ToolbarBtn btn);
        public event _ZMX_ClickAceptar ZMX_ClickAceptar;

        public delegate void _ZMX_ClickLimpiar(ToolbarBtn btn);
        public event _ZMX_ClickLimpiar ZMX_ClickLimpiar;

        public String ZMX_Coordenadas { get { return txtCoordenadas.Text; } set { txtCoordenadas.Text = value; } }

        public ZMXUC_MapaPanelHerramientas()
        {
            InitializeComponent();
        }

        private void btnAceptar_toolbarBtnClick(Toolbar.ToolbarBtn boton)
        {
            if (ZMX_ClickAceptar != null)
                ZMX_ClickAceptar(boton);
        }

        private void btnLimpiar_toolbarBtnClick(Toolbar.ToolbarBtn boton)
        {
            if (ZMX_ClickLimpiar != null)
                ZMX_ClickLimpiar(boton);
        }
    }
}
