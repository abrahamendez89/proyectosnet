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
using Karaoke.Configuracion;

namespace Configuracion
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class Entrada : Window
    {
        public Entrada()
        {
            InitializeComponent();

            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            Width = 10;
            Height = 10;

            this.Activated += Entrada_Activated;

        }

        void Entrada_Activated(object sender, EventArgs e)
        {
            this.Visibility = System.Windows.Visibility.Hidden;
            ConfiguracionOpciones conf = new ConfiguracionOpciones();
            conf.ShowDialog();
            Close();
        }
    }
}
