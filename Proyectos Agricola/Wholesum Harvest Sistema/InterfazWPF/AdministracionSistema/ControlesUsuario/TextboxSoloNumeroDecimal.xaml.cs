using System;
using System.Collections.Generic;
using System.Linq;
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

namespace InterfazWPF.AdministracionSistema.ControlesUsuario
{
    /// <summary>
    /// Lógica de interacción para TextboxSoloNumero.xaml
    /// </summary>
    public partial class TextboxSoloNumeroDecimal : UserControl
    {
        public String Text { get { return txt_Algo.Text; } set { txt_Algo.Text = value; } }
        public Boolean SoloLectura { get { return txt_Algo.IsReadOnly; } set { txt_Algo.IsReadOnly = value; } }
        public TextboxSoloNumeroDecimal()
        {
            InitializeComponent();
            this.GotFocus += TextboxSoloNumeroDecimal_GotFocus;
            txt_Algo.TextChanged += txt_Algo_TextChanged;
        }
        public delegate void textChanged(object sender, TextChangedEventArgs e);
        public event textChanged TextChanged;
        void txt_Algo_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextChanged != null)
                TextChanged(sender, e);
        }
        void TextboxSoloNumeroDecimal_GotFocus(object sender, RoutedEventArgs e)
        {
            txt_Algo.Focus();
        }
        public double ValorDouble
        {
            get
            {
                try
                {
                    double valor = Convert.ToDouble(txt_Algo.Text);
                    return valor;
                }
                catch { return 0; }
            }
            set
            {
                txt_Algo.Text = value.ToString();
            }
        }
        public float ValorFloat
        {
            get
            {
                try
                {
                    float valor = (float)Convert.ToDouble(txt_Algo.Text);
                    return valor;
                }
                catch { return 0; }
            }
            set
            {
                txt_Algo.Text = value.ToString();
            }
        }

        public TextBox TextBoxInterior { get { return txt_Algo; } }
        private void txt_Algo_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void txt_Algo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci >= 48 && ascci <= 57)
                e.Handled = false;
            else if (ascci == 46 && !txt_Algo.Text.Contains('.'))
                e.Handled = false;
            else if (ascci == 45 && !txt_Algo.Text.Contains('-') && txt_Algo.SelectionStart == 0)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txt_Algo_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //HerramientasWindow.Mensaje(e.Key.ToString(),"asd");
            if (e.Key >= Key.D0 && e.Key <= Key.D9)
            {
                e.Handled = false;
            }
            else if (e.Key == Key.OemMinus)
            {
                e.Handled = false;
            }
            else if (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
            {
                e.Handled = false;
            }
            else if (e.Key == Key.Back || e.Key == Key.Delete)
            {
                e.Handled = false;
            }
            else if (e.Key == Key.Down || e.Key == Key.Up || e.Key == Key.Left || e.Key == Key.Right)
            {
                e.Handled = false;
            }
            else if ((e.Key == Key.OemPeriod || e.Key == Key.Decimal) && !txt_Algo.Text.Contains('.'))
            {
                if (txt_Algo.Text.Length == 0)
                {
                    txt_Algo.SelectionStart = 0;
                    txt_Algo.SelectionLength = 0;
                    txt_Algo.Text = "0.";
                    e.Handled = true;
                    txt_Algo.SelectionStart = 2;
                    txt_Algo.SelectionLength = 0;
                }
                else
                    e.Handled = false;
            }
            else if (e.Key == Key.Tab)
            {
                this.Focus();
            }
            else e.Handled = true;
        }
    }
}
