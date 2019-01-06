using System;
using System.Collections.Generic;
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
using Dominio.Sistema;
using Dominio;
using Herramientas.Mail;
using System.Threading;
using System.ComponentModel;
using Herramientas.ORM;

namespace InterfazWPF.AdministracionSistema
{
    /// <summary>
    /// Lógica de interacción para EnviarSoporte.xaml
    /// </summary>
    public partial class EnviarSoporte : Window
    {
        ManejadorDB manejador = new ManejadorDB();
        Bitmap fotoPantalla;
        DateTime horaEvento;
        public String DescripcionError { get; set; }

        String IPLAN;
        String IPInternet;
        String UsuarioLogueadoCuenta;
        String UsuarioLogueadoEmail;

        public delegate void YaTomoFoto();
        public event YaTomoFoto yaTomoFoto;

        public EnviarSoporte()
        {
            InitializeComponent();
            txt_comentarios.KeyDown += txt_comentarios_KeyDown;
            horaEvento = DateTime.Now;
            fotoPantalla = HerramientasWindow.ComprimirImagen(HerramientasWindow.ObtenerFotoPantalla(this), 1000, 600, System.Drawing.Imaging.ImageFormat.Jpeg);
            this.Icon = HerramientasWindow.BitmapAImageSource(new Bitmap(@"Imagenes\Iconos\Sistema\soporte.png"));
            img_fotoPantalla.Source = HerramientasWindow.BitmapAImageSource(fotoPantalla);

           

            txt_comentarios.Focus();
            this.Title += " - Usuario: " + Principal.usuario.SNombreCompleto;

            IPLAN = Principal.ipLocal;
            IPInternet = Principal.ipInternet;
            UsuarioLogueadoCuenta = Principal.usuario.Cuenta;
            UsuarioLogueadoEmail = Principal.usuario.SEmail;

            EmailFormatos.errorEnviarCorreo += EmailFormatos_errorEnviarCorreo;
            EmailFormatos.correoEnviado += EmailFormatos_correoEnviado;

            this.IsVisibleChanged += EnviarSoporte_IsVisibleChanged;

        }

        void EnviarSoporte_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.Visibility == System.Windows.Visibility.Visible)
            {
                if (yaTomoFoto != null)
                    yaTomoFoto();
            }
        }
        Boolean CorreoEnviado = false;
        void EmailFormatos_correoEnviado()
        {
            Dispatcher.Invoke(new Action(() =>
            {
                if (!CorreoEnviado)
                {
                    HerramientasWindow.MostrarNotificacion("El correo fue enviado exitosamente.", "Correo enviado");
                    if (Principal.usuario.SEmail != null && !Principal.usuario.SEmail.Trim().Equals(""))
                        EmailFormatos.EnviarMailInformacion("El equipo de soporte ha recibido tu error. Pronto se comunicarán contigo para conocer mayores detalles.", "Error notificado con exito", Principal.usuario.SEmail, new List<Adjunto>() { new Adjunto() { NombreArchivo = "foto.jpg", Stream = Herramientas.WPF.Utilidades.BitmapToStream(fotoPantalla) } });
                    CorreoEnviado = true;
                }
            }));
        }

        void EmailFormatos_errorEnviarCorreo(string mensajeError)
        {
            Dispatcher.Invoke(new Action(() =>
            {
                HerramientasWindow.MostrarNotificacion("Error: " + mensajeError, "Error al enviar el correo");
            }));
        }

        void txt_comentarios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btn_enviar_MouseDown(null, null);
            }
        }
        private void enviarCorreo()
        {
            List<_sis_Usuario> usuariosSoporte = manejador.CargarLista<_sis_Usuario>(_sis_Usuario.consultaPorUsuariosSoporte);
            manejador.CerrarConexion();
            String emails = "";
            if (usuariosSoporte == null)
            {
                return;
            }
            foreach (_sis_Usuario usuario in usuariosSoporte)
            {
                emails += usuario.SEmail + "; ";
            }
            emails = emails.Substring(0, emails.Length - 2);

            String correo = "";
            String detallesTecnicos = "";
            Dispatcher.Invoke(new Action(() =>
               {
                    correo = txt_comentarios.Text.Trim();
             detallesTecnicos = @"<ul>
	            <li>IP(LAN|WAN): " + IPLAN + "|" + IPInternet + @"</li>
	            <li>Usuario: " + UsuarioLogueadoCuenta + @"</li>
	            <li>Hora del evento: " + horaEvento.ToString("yyyy-MM-dd HH:mm:ss") + @"</li>
                <li>Correo del usuario: " + UsuarioLogueadoEmail + @"</li>
            </ul>";
               }));
            

            try
            {
                CorreoEnviado = false;
                EmailFormatos.EnviarMailError(correo, "Error en el sistema", detallesTecnicos, Excepcion, emails, new List<Adjunto>() { new Adjunto() { NombreArchivo = "foto.jpg", Stream = Herramientas.WPF.Utilidades.BitmapToStream(fotoPantalla)}});

                Dispatcher.Invoke(new Action(() =>
                {
                    HerramientasWindow.MostrarNotificacion("Enviando correo...","Enviando");
                }));
            }
            catch (Exception ex)
            {
                Dispatcher.Invoke(new Action(() =>
                {
                    HerramientasWindow.MostrarNotificacion("Error: " + ex.Message, "Error al enviar el correo");
                }));
            }

        }
        public Exception Excepcion { get; set; }
        private void btn_enviar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (txt_comentarios.Text.Trim().Equals(""))
            {
                HerramientasWindow.MensajeInformacion("Proporcione comentarios que apoyen al equipo de soporte por favor.", "Soporte");
                return;
            }
            Enviar();
            Close();
        }

        private void Enviar()
        {
            //bw_enviarCorreo.RunWorkerAsync();

            //Thread tEnviar = new Thread(enviarCorreo);
            //tEnviar.Start();

            enviarCorreo();

        }

    }
}
