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

namespace UserControlsSIZ.Contables
{
    /// <summary>
    /// Interaction logic for SIZUCContabilizacionCapturaCuenta.xaml
    /// </summary>
    public partial class SIZUCContabilizacionCapturaCuenta : UserControl
    {
        //eventos
        public delegate String _SIZUC_BuscarCuentaContable(SIZUCContabilizacionCapturaCuenta objeto);
        public event _SIZUC_BuscarCuentaContable SIZUC_BuscarCuentaContable;
        public delegate void _SIZUC_EliminarElemento(SIZUCContabilizacionCapturaCuenta objeto);
        public event _SIZUC_EliminarElemento SIZUC_EliminarElemento;
        public delegate void _SIZUC_Actualizar();
        public event _SIZUC_Actualizar SIZUC_Actualizar;

        public SIZUCContabilizacionCapturaCuenta()
        {
            InitializeComponent();
            btnBuscar.MouseUp += BtnBuscar_MouseUp;
            btnEliminar.MouseUp += BtnEliminar_MouseUp;
        }

        private void BtnEliminar_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (SIZUC_EliminarElemento != null)
            {
                SIZUC_EliminarElemento(this);
            }
        }

        public void SetColor(Brush colorBase)
        {
            btnBuscar.IconoColor = colorBase;
            btnEliminar.IconoColor = colorBase;
        }
        public String CuentaNombre { get; set; }

        public int CaracteresFaltantes { get; set; }

        public Boolean BotonEliminarVisible { get { return btnEliminar.Visibility == Visibility.Visible; } set { if (value) { btnEliminar.Visibility = Visibility.Visible; btnBuscar.Visibility = Visibility.Visible; } else { btnEliminar.Visibility = Visibility.Collapsed; btnBuscar.Visibility = Visibility.Collapsed; } } }

        private void BtnBuscar_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if(SIZUC_BuscarCuentaContable != null)
            {
                String cuentacontable = SIZUC_BuscarCuentaContable(this);
                this.txtCapturaEncriptado.Text = cuentacontable;
                this.CuentaContable = cuentacontable;
                if (SIZUC_Actualizar != null) SIZUC_Actualizar();
            }
        }
        public int LongitudCuentaContableAnterior { get; set; }
        //propiedades
        public String CuentaContable { get { return txtCapturaEncriptado.Text; } set
            {

                txtCapturaEncriptado.Text = value.Split('|')[0];
                try
                {
                    txtNombre.Text = value.Split('|')[1];
                    CuentaNombre = txtNombre.Text;
                }
                catch
                {

                }
                if (SIZUC_Actualizar != null) SIZUC_Actualizar();
            } }
        public SIZUCContabilizacionCapturaSeparador Separador { get; set; }


    }
}
