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
using System.Windows.Shapes;

namespace Karaoke.Configuracion
{
    /// <summary>
    /// Lógica de interacción para SeleccionarTecla.xaml
    /// </summary>
    public partial class SeleccionarTecla : Window
    {
        public Key TeclaSeleccionada { get; set; }
        public SeleccionarTecla()
        {
            InitializeComponent();
            this.KeyDown += SeleccionarTecla_KeyDown;
            this.Closing += SeleccionarTecla_Closing;
            btn_aceptar.Click += btn_aceptar_Click;
        }

        void btn_aceptar_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        void SeleccionarTecla_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
        }

        void SeleccionarTecla_KeyDown(object sender, KeyEventArgs e)
        {
            txt_tecla.Text = e.Key.ToString();
            TeclaSeleccionada = e.Key;
            KeyConverter k = new KeyConverter();
            Key mykey = (Key)k.ConvertFromString(txt_tecla.Text);

        }
    }
}
