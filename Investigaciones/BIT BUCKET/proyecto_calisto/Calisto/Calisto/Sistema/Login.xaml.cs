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
using Controladores.Sistema;
using Dominio.Sistema;

namespace Calisto.Sistema
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        LoginController loginController = new LoginController();
        LicenciaController licenciaController = new LicenciaController();
        public Login()
        {
            InitializeComponent();
            EventosInterfaz();

        }

        private void EventosInterfaz()
        {
            //btn_iniciar.Click += btn_iniciar_Click;
        }

        void btn_iniciar_Click(object sender, RoutedEventArgs e)
        {
            if (loginController.Iniciar(txt_usuario.Text, txt_contrasena.Password) && licenciaController.ValidarLicencia())
            {
                Principal p = new Principal();
                p.Closed += p_Closed;
                p.Show();
                this.Hide();
            }
        }

        void p_Closed(object sender, EventArgs e)
        {
            Close();
        }
    }
}
