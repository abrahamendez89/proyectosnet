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
    public partial class TextboxNormal : UserControl
    {
        public delegate void KeyEvent(object sender, KeyEventArgs e);
        public event KeyEvent keyEvent;

        public int SelectionStart { get { return txt_Algo.SelectionStart; } set { txt_Algo.SelectionStart = value; } }
        public int SelectionLength { get { return txt_Algo.SelectionLength; } set { txt_Algo.SelectionLength = value; } }
        public Boolean SoloLectura { get { return txt_Algo.IsReadOnly; } set { txt_Algo.IsReadOnly = value; } }
        public enum Tipo
        {
            conEspacios = 0,
            sinEspacios
        }
        public String Text { get { return txt_Algo.Text; } set { txt_Algo.Text = value; } }
        public delegate void textChanged(object sender, TextChangedEventArgs e);
        public event textChanged TextChanged;
        void txt_Algo_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextChanged != null)
                TextChanged(sender, e);
        }
        public Tipo TipoTextBox { get; set; }
        public TextboxNormal()
        {
            InitializeComponent();
            this.GotFocus += TextboxSoloNumeroDecimal_GotFocus;
            txt_Algo.TextChanged += txt_Algo_TextChanged;
            
        }
        void TextboxSoloNumeroDecimal_GotFocus(object sender, RoutedEventArgs e)
        {
            txt_Algo.Focus();
        }
        public Boolean Focs()
        {
            return txt_Algo.Focus();
        }
        public TextBox TextBoxInterior { get { return txt_Algo; } }
        private void txt_Algo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (keyEvent != null) 
                    keyEvent(sender, e);
            }
            catch (NullReferenceException nrf) { }
        }

        private void txt_Algo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            //if (ascci >= 48 && ascci <= 57)
            //    e.Handled = false;
            //else
            //    e.Handled = true;
        }

        private void txt_Algo_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (this.TipoTextBox == Tipo.sinEspacios)
            {
                if (e.Key == Key.Space)
                    e.Handled = true;
            }
            else if (e.Key == Key.Tab)
            {
                this.Focus();
            }
        }
    }
}
