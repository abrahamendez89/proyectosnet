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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InterfazWPF.AdministracionSistema.ControlesUsuario
{
    /// <summary>
    /// Lógica de interacción para TextBoxBusqueda.xaml
    /// </summary>
    public partial class TextBoxBusqueda : UserControl
    {
        public TextBoxBusqueda()
        {
            InitializeComponent();
            this.MouseLeave += TextBoxBusqueda_MouseLeave;
            this.txt_Algo.MouseEnter += txt_Algo_MouseEnter;
        }
        Boolean variable = false;
        void txt_Algo_MouseEnter(object sender, MouseEventArgs e)
        {
            
            Storyboard evento = (Storyboard)this.FindResource("Aparecer");
            evento.Begin();
            variable = true;
        }

        void TextBoxBusqueda_MouseLeave(object sender, MouseEventArgs e)
        {
            txt_Algo.Text = "";
            if (variable)
            {
                Storyboard evento = (Storyboard)this.FindResource("Desaparecer");
                evento.Begin();
                variable = false;
            }
        }
    }
}
