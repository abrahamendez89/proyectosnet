using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
using Herramientas.Archivos;

namespace InterfazWPF.AdministracionSistema
{
    /// <summary>
    /// Lógica de interacción para ConfiguraciónEnLogin.xaml
    /// </summary>
    public partial class ConfiguraciónEnLogin : Window
    {
        Variable variablesCONN;
        Variable variablesDATA;
        public ConfiguraciónEnLogin()
        {
            InitializeComponent();
            this.Icon = HerramientasWindow.BitmapAImageSource(new Bitmap(@"Imagenes\Iconos\Sistema\configuracionLogin.png"));
            
            variablesCONN = new Variable("conn.conf");
            variablesDATA = new Variable("data.conf");

            CargarDatosServidor();
            CargarVariables();
        }
        private void CargarVariables()
        {
            dgr_variables.ItemsSource = variablesDATA.ObtenerDataTableConVariablesYValores().DefaultView;
        }
        private void GuardarVariables()
        {
            DataTable dt = HerramientasWindow.DataGridtoDataTable(dgr_variables);
            variablesDATA.BorrarVariables();

            foreach (DataRow dr in dt.Rows)
            {
                if (dr[0].ToString().Trim().Equals("") || dr[1].ToString().Trim().Equals("")) continue;
                variablesDATA.GuardarValorVariable(dr[0].ToString(), dr[1].ToString());
            }
            variablesDATA.ActualizarArchivo();
            HerramientasWindow.MensajeInformacion("Se guardaron los datos correctamente.","Guardado exitoso");
        }
        private void CargarDatosServidor()
        {
            txt_servidorInstancia.Text = HerramientasWindow.DesencriptarConMD5(variablesCONN.ObtenerValorVariable<String>("ServidorInstancia"));
            txt_baseDatos.Text = HerramientasWindow.DesencriptarConMD5(variablesCONN.ObtenerValorVariable<String>("BaseDeDatos"));
            txt_usuario.Text = HerramientasWindow.DesencriptarConMD5(variablesCONN.ObtenerValorVariable<String>("Usuario"));
            txt_Contraseña.Password = HerramientasWindow.DesencriptarConMD5(variablesCONN.ObtenerValorVariable<String>("Contraseña"));
        }
        private void GuardarDatosServidor()
        {
            variablesCONN.GuardarValorVariable("ServidorInstancia",HerramientasWindow.EncriptarConMD5(txt_servidorInstancia.Text));
            variablesCONN.GuardarValorVariable("BaseDeDatos", HerramientasWindow.EncriptarConMD5(txt_baseDatos.Text));
            variablesCONN.GuardarValorVariable("Usuario", HerramientasWindow.EncriptarConMD5(txt_usuario.Text));
            variablesCONN.GuardarValorVariable("Contraseña", HerramientasWindow.EncriptarConMD5(txt_Contraseña.Password));
            variablesCONN.ActualizarArchivo();
            HerramientasWindow.MensajeInformacion("Se guardaron los datos correctamente.", "Guardado exitoso");
        }
        private void Boton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            String contraGenerada = DateTime.Now.Month.ToString().PadLeft(2, '0') + "" + DateTime.Now.Day.ToString().PadLeft(2, '0') + "" + DateTime.Now.Hour.ToString().PadLeft(2, '0') + "" + DateTime.Now.Minute.ToString().PadLeft(2, '0');
            if (txt_contrasena.Password.Equals(contraGenerada))
            {
                Height = 294.363;
                Width = 403.758;
                tc_tabControl.Visibility = System.Windows.Visibility.Visible;
                btn_accesar.Visibility = System.Windows.Visibility.Hidden;
                txt_contrasena.Visibility = System.Windows.Visibility.Hidden;
                CenterWindowOnScreen();
            }
            else
            {
                HerramientasWindow.MensajeErrorSimple("Contraseña inválida.", "Error en autenticación");
            }
        }
        private void CenterWindowOnScreen()
        {
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }
        private void txt_contrasena_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Boton_MouseDown(null, null);
            }
            else if (e.Key == Key.Escape)
            {
                Close();
            }
        }

        private void btn_guardarDatosServidor_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GuardarDatosServidor();
        }

        private void btn_guardarData_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GuardarVariables();
        }
    }
}
