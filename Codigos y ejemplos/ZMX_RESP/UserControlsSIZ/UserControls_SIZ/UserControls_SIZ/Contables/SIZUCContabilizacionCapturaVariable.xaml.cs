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
    /// Interaction logic for SIZUCContabilizacionCapturaVariable.xaml
    /// </summary>
    public partial class SIZUCContabilizacionCapturaVariable : UserControl
    {
        //eventos
        public delegate String _SIZUC_BuscarVariableContable(SIZUCContabilizacionCapturaVariable objeto);
        public event _SIZUC_BuscarVariableContable SIZUC_BuscarVariableContable;
        public delegate void _SIZUC_EliminarElemento(SIZUCContabilizacionCapturaVariable objeto);
        public event _SIZUC_EliminarElemento SIZUC_EliminarElemento;
        public delegate void _SIZUC_Actualizar();
        public event _SIZUC_Actualizar SIZUC_Actualizar;

        public SIZUCContabilizacionCapturaVariable()
        {
            InitializeComponent();
            btnBuscarVariable.MouseUp += BtnBuscarVariable_MouseUp;
            btnEliminarElemento.MouseUp += BtnEliminarElemento_MouseUp;

            //txtCapturaEncriptadoRangoInferior.LostFocus += txtCapturaEncriptadoRangoInferior_LostFocus;
            txtCapturaEncriptadoRangoInferior.GotFocus += txtCapturaEncriptadoRangoInferior_GotFocus;
            this.GotFocus += txtCapturaEncriptadoRangoInferior_GotFocus;
            txtCapturaEncriptadoRangoInferior.TextChanged += txtCapturaEncriptadoRangoInferior_TextChanged;
            txtCapturaEncriptadoRangoSuperior.TextChanged += txtCapturaEncriptadoRangoSuperior_TextChanged;
            txtCapturaEncriptadoRangoSuperior.LostFocus += txtCapturaEncriptadoRangoSuperior_LostFocus;
            txtCapturaEncriptadoRangoInferior.LostFocus += txtCapturaEncriptadoRangoInferior_LostFocus1;
        }
        public int CaracteresFaltantes { get; set; }
        private void txtCapturaEncriptadoRangoInferior_LostFocus1(object sender, RoutedEventArgs e)
        {
            try
            {
                int valorSuperior = Convert.ToInt32(txtCapturaEncriptadoRangoSuperior.Text);
                int valorInferior = Convert.ToInt32(txtCapturaEncriptadoRangoInferior.Text);

                if (valorSuperior < valorInferior)
                {
                    throw new Exception();
                }
                try
                {
                    if ((valorSuperior - valorInferior) > CaracteresFaltantes)
                    {
                        valorSuperior = valorInferior + CaracteresFaltantes;
                        txtCapturaEncriptadoRangoSuperior.Text = valorSuperior.ToString();
                    }
                }
                catch { }
                if (SIZUC_Actualizar != null) SIZUC_Actualizar();
            }
            catch
            {
                txtCapturaEncriptadoRangoSuperior.Text = txtCapturaEncriptadoRangoInferior.Text;

                if (SIZUC_Actualizar != null) SIZUC_Actualizar();
            }
        }
        public void SetColor(Brush colorBase)
        {
            btnBuscarVariable.IconoColor = colorBase;
            btnEliminarElemento.IconoColor = colorBase;
        }
        private void txtCapturaEncriptadoRangoSuperior_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                int valorSuperior = Convert.ToInt32(txtCapturaEncriptadoRangoSuperior.Text);
                int valorInferior = Convert.ToInt32(txtCapturaEncriptadoRangoInferior.Text);

                try
                {
                    if ((valorSuperior - valorInferior) > CaracteresFaltantes)
                    {
                        valorInferior = valorSuperior - CaracteresFaltantes;
                        txtCapturaEncriptadoRangoInferior.Text = valorInferior.ToString();
                    }
                }
                catch { }

                if (valorSuperior < valorInferior)
                {
                    throw new Exception();
                }
                if (SIZUC_Actualizar != null) SIZUC_Actualizar();
            }
            catch
            {
                txtCapturaEncriptadoRangoSuperior.Text = txtCapturaEncriptadoRangoInferior.Text;
                //txtCapturaEncriptadoRangoSuperior.Text = "0";

                txtCapturaEncriptadoRangoSuperior.SelectionStart = 0;
                txtCapturaEncriptadoRangoSuperior.SelectionLength = txtCapturaEncriptadoRangoSuperior.Text.Length;

                if (SIZUC_Actualizar != null) SIZUC_Actualizar();
            }
        }

        private void txtCapturaEncriptadoRangoSuperior_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (SIZUC_Actualizar != null) SIZUC_Actualizar();
                int valorSuperior = Convert.ToInt32(txtCapturaEncriptadoRangoSuperior.Text);
                

            }
            catch
            {
                //txtCapturaEncriptadoRangoSuperior.Text = txtCapturaEncriptadoRangoInferior.Text;
                txtCapturaEncriptadoRangoSuperior.Text = "0";

                txtCapturaEncriptadoRangoSuperior.SelectionStart = 0;
                txtCapturaEncriptadoRangoSuperior.SelectionLength = txtCapturaEncriptadoRangoSuperior.Text.Length;

                if (SIZUC_Actualizar != null) SIZUC_Actualizar();
            }
        }
        
        private void BtnEliminarElemento_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (SIZUC_EliminarElemento != null)
            {
                SIZUC_EliminarElemento(this);
            }
        }

        public Boolean BotonEliminarVisible { get { return btnEliminarElemento.Visibility == Visibility.Visible; } set { if (value) { btnEliminarElemento.Visibility = Visibility.Visible; txtCapturaEncriptadoRangoInferior.IsEnabled = true; txtCapturaEncriptadoRangoSuperior.IsEnabled = true;  txtCapturaEncriptadoRangoInferior.Background = Brushes.White; txtCapturaEncriptadoRangoSuperior.Background = Brushes.White; } else { btnEliminarElemento.Visibility = Visibility.Collapsed; txtCapturaEncriptadoRangoInferior.IsEnabled = false; txtCapturaEncriptadoRangoSuperior.IsEnabled = false; txtCapturaEncriptadoRangoInferior.Background = Brushes.Transparent; txtCapturaEncriptadoRangoSuperior.Background = Brushes.Transparent; } } }


        private void BtnBuscarVariable_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (SIZUC_BuscarVariableContable != null)
            {
                String variable = SIZUC_BuscarVariableContable(this);
                this.txtCapturaEncriptado.Text = variable;
                this.Variable = variable;
                if (SIZUC_Actualizar != null) SIZUC_Actualizar();
            }
        }

        private void txtCapturaEncriptadoRangoInferior_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtCapturaEncriptadoRangoInferior.SelectionLength == 0 && txtCapturaEncriptadoRangoInferior.Text.Length > 0)
            {
                txtCapturaEncriptadoRangoInferior.SelectionStart = 0;
                txtCapturaEncriptadoRangoInferior.SelectionLength = txtCapturaEncriptadoRangoInferior.Text.Length;
            }
        }

        private void txtCapturaEncriptadoRangoInferior_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (SIZUC_Actualizar != null) SIZUC_Actualizar();
                int valorInferior = Convert.ToInt32(txtCapturaEncriptadoRangoInferior.Text);
                
            }
            catch
            {
                txtCapturaEncriptadoRangoInferior.Text = "0";
                //txtCapturaEncriptadoRangoSuperior.Text = "0";

                txtCapturaEncriptadoRangoInferior.SelectionStart = 0;
                txtCapturaEncriptadoRangoInferior.SelectionLength = txtCapturaEncriptadoRangoInferior.Text.Length;

                if (SIZUC_Actualizar != null) SIZUC_Actualizar();
            }
        }

        //propiedades
        public int Longitud { get
            {
                int longitud = 0;
                int valorInferior = Convert.ToInt32(txtCapturaEncriptadoRangoInferior.Text);
                int valorSuperior = Convert.ToInt32(txtCapturaEncriptadoRangoSuperior.Text);
                longitud = valorSuperior - valorInferior + 1;
                if (longitud < 0)
                    longitud = 0;
                this.ToolTip = "Longitud = " + longitud;

                return longitud;
            } }
        public String Variable { get { return txtCapturaEncriptado.Text; } set { txtCapturaEncriptado.Text = value; txtCapturaEncriptadoRangoInferior.Focus(); if (SIZUC_Actualizar != null) SIZUC_Actualizar(); } }
        public SIZUCContabilizacionCapturaSeparador Separador { get; set; }
    }
}
