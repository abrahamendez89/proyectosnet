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

namespace UserControlsSIZ.Captura
{
    /// <summary>
    /// Interaction logic for ZMXUCCapturaEncriptada.xaml
    /// </summary>
    public partial class ZMXUCCapturaEncriptada : UserControl
    {

        public delegate string _ZMX_DesencriptarContenido(String contenidoEncriptado);
        public event _ZMX_DesencriptarContenido ZMX_DesencriptarContenido;

        public delegate string _ZMX_EncriptarContenido(String contenido);
        public event _ZMX_EncriptarContenido ZMX_EncriptarContenido;


        public ZMXUCCapturaEncriptada()
        {
            InitializeComponent();
            txtCapturaDesencriptado.GotFocus += TxtCaptura_GotFocus;
            this.MouseDown += UserControl_MouseDown;
            this.LostFocus += ZMXUCCapturaEncriptada_LostFocus;
            txtCapturaEncriptado.PasswordChanged += TxtCaptura_PasswordChanged;
            txtCapturaDesencriptado.Visibility = Visibility.Visible;
            txtCapturaEncriptado.Visibility = Visibility.Hidden;
        }

        private void TxtCaptura_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (txtCapturaEncriptado.Password.Equals(""))
            {
                txtCapturaEncriptado.Background = new SolidColorBrush(Colors.Transparent);
            }
            else
            {
                txtCapturaEncriptado.Background = new SolidColorBrush(Colors.White);
            }
        }
        
        private void ZMXUCCapturaEncriptada_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtCapturaEncriptado.Password.Equals(""))
                txtCapturaEncriptado.Visibility = Visibility.Hidden;

            rectangle.StrokeThickness = 0.5;
            //rectangle.Stroke = new SolidColorBrush(colorBase);
        }

        private void TxtCaptura_GotFocus(object sender, RoutedEventArgs e)
        {
            UserControl_MouseDown(null, null);
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (mostrarEncriptado)
                return;

            if(estaEncriptado)
            {
                txtCapturaEncriptado.Visibility = Visibility.Visible;
                txtCapturaDesencriptado.Visibility = Visibility.Hidden;
                txtCapturaEncriptado.Focus();
            }
            else
            {
                txtCapturaEncriptado.Visibility = Visibility.Hidden;
                txtCapturaDesencriptado.Visibility = Visibility.Visible;
                txtCapturaDesencriptado.Focus();
            }
            
            rectangle.StrokeThickness = 0.7;
            //rectangle.Stroke = new SolidColorBrush(colorResalte);

            //if (txtCaptura.Password.Equals(""))
            //{
            //    txtCaptura.Background = new SolidColorBrush(Colors.Transparent);
            //}
            //else
            //{
            //    txtCaptura.Background = new SolidColorBrush(Colors.White);
            //}

        }
        
        public void SetColor(Brush color)
        {
            ico.IconoColor = color;
        }

        private Boolean estaEncriptado = false;

        public Iconos.IconAwesomeSIZ.AwesomeIcons IconoMostrarEncriptado { get { return ico.Icono; } set { ico.Icono = value; } }

        public String PlaceHolder { get { return txtPlaceHolder.Text; } set { txtPlaceHolder.Text = value; } }
        public String Valor { get { return txtCapturaDesencriptado.Text; }
            set
            {
                txtCapturaEncriptado.Password = value;
                txtCapturaDesencriptado.Text = value;
                
                if (estaEncriptado && ZMX_EncriptarContenido != null)
                    SetValor(ZMX_EncriptarContenido(txtCapturaDesencriptado.Text));

            }
        }

        private void SetValor(string valor)
        {
            txtCapturaEncriptado.Password = valor;
            txtCapturaDesencriptado.Text = valor;
        }

        public Boolean EstaEncriptado { get { return estaEncriptado; } set
            {
                mostrarEncriptado = false;
                estaEncriptado = value;
                if(estaEncriptado)
                {
                    txtCapturaEncriptado.Visibility = Visibility.Visible;
                    txtCapturaDesencriptado.Visibility = Visibility.Hidden;

                    if (ZMX_EncriptarContenido != null)
                        SetValor(ZMX_EncriptarContenido(txtCapturaDesencriptado.Text));
                    ico.Icono = UserControlsSIZ.Iconos.IconAwesomeSIZ.AwesomeIcons.fa_lock;
                }
                else
                {
                    txtCapturaEncriptado.Visibility = Visibility.Hidden;
                    txtCapturaDesencriptado.Visibility = Visibility.Visible;

                    if (ZMX_DesencriptarContenido != null)
                        SetValor(ZMX_DesencriptarContenido(txtCapturaDesencriptado.Text));
                    ico.Icono = UserControlsSIZ.Iconos.IconAwesomeSIZ.AwesomeIcons.fa_unlock;
                }
            } }
        private Boolean mostrarEncriptado = false;

        private String ValorEncriptadoTemp;

        private void ico_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mostrarEncriptado = true;
            txtCapturaEncriptado.Visibility = Visibility.Hidden;
            txtCapturaDesencriptado.Visibility = Visibility.Visible;
            ico.Icono = UserControlsSIZ.Iconos.IconAwesomeSIZ.AwesomeIcons.fa_unlock;
            if (estaEncriptado && ZMX_DesencriptarContenido != null)
            {
                ValorEncriptadoTemp = txtCapturaEncriptado.Password;
                SetValor(ZMX_DesencriptarContenido(txtCapturaEncriptado.Password));
            }
        }

        private void ico_MouseLeave(object sender, MouseEventArgs e)
        {
            if (estaEncriptado && mostrarEncriptado)
            {
                mostrarEncriptado = false;
                txtCapturaEncriptado.Visibility = Visibility.Visible;
                txtCapturaDesencriptado.Visibility = Visibility.Hidden;
                ico.Icono = UserControlsSIZ.Iconos.IconAwesomeSIZ.AwesomeIcons.fa_lock;
                SetValor(ValorEncriptadoTemp);
            }
        }

        private void ico_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (estaEncriptado && mostrarEncriptado)
            {
                mostrarEncriptado = false;
                txtCapturaEncriptado.Visibility = Visibility.Visible;
                txtCapturaDesencriptado.Visibility = Visibility.Hidden;
                ico.Icono = UserControlsSIZ.Iconos.IconAwesomeSIZ.AwesomeIcons.fa_lock;
                SetValor(ValorEncriptadoTemp);
            }
        }
    }
}
