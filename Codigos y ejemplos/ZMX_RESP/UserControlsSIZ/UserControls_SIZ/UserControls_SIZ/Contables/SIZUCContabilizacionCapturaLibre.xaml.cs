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
    /// Interaction logic for SIZUCContabilizacionCapturaLibre.xaml
    /// </summary>
    public partial class SIZUCContabilizacionCapturaLibre : UserControl
    {
        public SIZUCContabilizacionCapturaLibre()
        {
            InitializeComponent();
            btnEliminar.MouseUp += BtnEliminar_MouseUp;
            txtCapturaEncriptado.GotFocus += txtCapturaEncriptado_GotFocus;
            txtCapturaEncriptado.LostFocus += txtCapturaEncriptado_LostFocus;
            txtCapturaEncriptado.TextChanged += txtCapturaEncriptado_TextChanged;
            txtCapturaEncriptado.PreviewTextInput += txtCapturaEncriptado_PreviewTextInput;
        }
        public void SetColor(Brush colorBase)
        {
            btnEliminar.IconoColor = colorBase;
        }
        private void txtCapturaEncriptado_LostFocus(object sender, RoutedEventArgs e)
        {
            if (SIZUC_Actualizar != null) SIZUC_Actualizar();
        }

        private void txtCapturaEncriptado_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (txtCapturaEncriptado.Text.Length >= CaracteresFaltantes)
            {
                e.Handled = true;
            }

        }

        private void txtCapturaEncriptado_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        public int CaracteresFaltantes { get; set; }
        private void txtCapturaEncriptado_GotFocus(object sender, RoutedEventArgs e)
        {
            txtCapturaEncriptado.SelectionStart = 0;
            txtCapturaEncriptado.SelectionLength = txtCapturaEncriptado.Text.Length;
        }

        //eventos
        public delegate void _SIZUC_EliminarElemento(SIZUCContabilizacionCapturaLibre objeto);
        public event _SIZUC_EliminarElemento SIZUC_EliminarElemento;
        public delegate void _SIZUC_Actualizar();
        public event _SIZUC_Actualizar SIZUC_Actualizar;
        

        private void BtnEliminar_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (SIZUC_EliminarElemento != null)
            {
                SIZUC_EliminarElemento(this);
            }
        }

        public Boolean BotonEliminarVisible { get { return btnEliminar.Visibility == Visibility.Visible; } set { if (value) { btnEliminar.Visibility = Visibility.Visible; txtCapturaEncriptado.IsEnabled = true; txtCapturaEncriptado.IsReadOnly = false; txtCapturaEncriptado.Background = Brushes.White; } else { btnEliminar.Visibility = Visibility.Collapsed; txtCapturaEncriptado.IsEnabled = false; txtCapturaEncriptado.IsReadOnly = true; txtCapturaEncriptado.Background = Brushes.Transparent; } } }

        public int LongitudCuentaContableAnterior { get; set; }
        //propiedades
        public String Captura { get { return txtCapturaEncriptado.Text; } set { txtCapturaEncriptado.Text = value; if (SIZUC_Actualizar != null) SIZUC_Actualizar(); } }
        public SIZUCContabilizacionCapturaSeparador Separador { get; set; }
    }
}
