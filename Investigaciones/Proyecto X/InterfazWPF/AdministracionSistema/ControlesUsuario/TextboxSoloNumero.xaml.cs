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
    public partial class TextboxSoloNumero : UserControl
    {
        public String Text { get { return txt_Algo.Text; } set { txt_Algo.Text = value; } }
        public Boolean SoloLectura { get { return txt_Algo.IsReadOnly; } set { txt_Algo.IsReadOnly = value; } }
        public TextboxSoloNumero()
        {
            InitializeComponent();
            txt_Algo.KeyDown +=txt_Algo_KeyDown;
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
        public int Valor { get { try { int valor = Convert.ToInt32(txt_Algo.Text); return valor; } catch { return 0; } } set { txt_Algo.Text = value.ToString(); } }
        public TextBox TextBoxInterior { get { return txt_Algo; } }
        private void txt_Algo_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Key >= Key.D0 && e.Key <= Key.D9)
            //{
            //    e.Handled = false;
            //}
            //else e.Handled = true;
        }

        private void txt_Algo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            //if (ascci >= 48 && ascci <= 57)
            //    e.Handled = false;
            //else
            //    e.Handled = true;
            if (ascci == 45 && !txt_Algo.Text.Contains('-') && txt_Algo.SelectionStart == 0)
                e.Handled = false;
        }

        private void txt_Algo_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9)
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
            else if (e.Key == Key.OemMinus)
            {
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
