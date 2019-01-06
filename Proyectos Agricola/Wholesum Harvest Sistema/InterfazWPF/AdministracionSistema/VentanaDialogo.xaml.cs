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
using LogicaNegocios;
using Herramientas.Archivos;

namespace InterfazWPF.AdministracionSistema
{
    /// <summary>
    /// Lógica de interacción para VentanaDialogo.xaml
    /// </summary>
    public partial class VentanaDialogo : Window
    {
        public enum VentanaDialogoBoton
	    {
	        Aceptar = 0,
            Cancelar = 1,
            Si = 2,
            No = 3
	    }
        public enum VentanaDialogoTipoVentana
        {
            Pregunta = 0,
            Mensaje = 1,
            Advertencia = 2,
            Error = 3,
            Informacion = 4,
            PreguntaAdvertencia = 5,
            AdvertenciaAlta = 6,
            ErrorSimple = 7
        }
        public VentanaDialogo()
        {
            InitializeComponent();
            this.KeyDown += VentanaDialogo_KeyDown;

            //this.Top = Principal.GetPantallaSistema().Bounds.Top;
            //this.Left = Principal.GetPantallaSistema().Bounds.Left;

            this.Topmost = true;
        }

        void VentanaDialogo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btn_botonAceptar_MouseDown(null, null);
            }
            else if (e.Key == Key.Escape)
            {
                btn_botonCancelar_MouseDown(null, null);
            }
        }
        private int botonRespuesta;
        public VentanaDialogoBoton Mostrar(MensajeException mensaje)
        {
            if (mensaje.EsError)
            {
                return Mostrar(null, mensaje.Mensaje, "Error", VentanaDialogoTipoVentana.Error);
            }
            else
            {
                VentanaDialogoTipoVentana tipoventana = VentanaDialogoTipoVentana.Error;
                if (mensaje.Tipo == MensajeException.TipoMensaje.Advertencia)
                    tipoventana = VentanaDialogoTipoVentana.Advertencia;
                else if (mensaje.Tipo == MensajeException.TipoMensaje.AdvertenciaAlta)
                    tipoventana = VentanaDialogoTipoVentana.AdvertenciaAlta;
                else if (mensaje.Tipo == MensajeException.TipoMensaje.ErrorSimple)
                    tipoventana = VentanaDialogoTipoVentana.ErrorSimple;
                else if (mensaje.Tipo == MensajeException.TipoMensaje.Informacion)
                    tipoventana = VentanaDialogoTipoVentana.Informacion;
                else if (mensaje.Tipo == MensajeException.TipoMensaje.Mensaje)
                    tipoventana = VentanaDialogoTipoVentana.Mensaje;
                else if (mensaje.Tipo == MensajeException.TipoMensaje.Pregunta)
                    tipoventana = VentanaDialogoTipoVentana.Pregunta;
                else if (mensaje.Tipo == MensajeException.TipoMensaje.PreguntaAdvertencia)
                    tipoventana = VentanaDialogoTipoVentana.PreguntaAdvertencia;

                return Mostrar(null, mensaje.Mensaje, "Mensaje", tipoventana);
            }
        }
        private Exception exception;
        public VentanaDialogoBoton Mostrar(Exception exception, String mensaje, String titulo, VentanaDialogoTipoVentana tipoVentana)
        {
            try
            {
                txt_Mensaje.Text = mensaje;
                Title = titulo;
                btn_botonCancelar.Visibility = System.Windows.Visibility.Hidden;
                btn_botonEnviarSoporte.Visibility = System.Windows.Visibility.Hidden;

                if (tipoVentana == VentanaDialogoTipoVentana.Advertencia)
                {
                    img_Imagen.Source = HerramientasWindow.BitmapAImageSource(new Bitmap(@"Imagenes\Iconos\Sistema\Dialogos\advertencia.png"));
                }
                else if (tipoVentana == VentanaDialogoTipoVentana.AdvertenciaAlta)
                {
                    img_Imagen.Source = HerramientasWindow.BitmapAImageSource(new Bitmap(@"Imagenes\Iconos\Sistema\Dialogos\advertencia3.png"));
                }
                else if (tipoVentana == VentanaDialogoTipoVentana.Error)
                {
                    if (exception != null)
                    {
                        this.exception = exception;
                        Log.EscribirLog("Exception name: " + exception.GetType().Name + " - Message: " + exception.Message + " - StackTrace: " + exception.StackTrace);
                    }
                    else
                        Log.EscribirLog("Exception: " + mensaje);
                    btn_botonEnviarSoporte.Visibility = System.Windows.Visibility.Visible;
                    img_Imagen.Source = HerramientasWindow.BitmapAImageSource(new Bitmap(@"Imagenes\Iconos\Sistema\Dialogos\error.png"));
                }
                else if (tipoVentana == VentanaDialogoTipoVentana.Informacion)
                {
                    img_Imagen.Source = HerramientasWindow.BitmapAImageSource(new Bitmap(@"Imagenes\Iconos\Sistema\Dialogos\informacion.png"));
                }
                else if (tipoVentana == VentanaDialogoTipoVentana.Mensaje)
                {
                    img_Imagen.Source = HerramientasWindow.BitmapAImageSource(new Bitmap(@"Imagenes\Iconos\Sistema\Dialogos\mensaje.png"));
                }
                else if (tipoVentana == VentanaDialogoTipoVentana.Pregunta)
                {
                    btn_botonAceptar.Text = "Si";
                    btn_botonCancelar.Text = "No";
                    btn_botonCancelar.Visibility = System.Windows.Visibility.Visible;
                    img_Imagen.Source = HerramientasWindow.BitmapAImageSource(new Bitmap(@"Imagenes\Iconos\Sistema\Dialogos\pregunta.png"));
                }
                else if (tipoVentana == VentanaDialogoTipoVentana.PreguntaAdvertencia)
                {
                    btn_botonAceptar.Text = "Si";
                    btn_botonCancelar.Text = "No";
                    btn_botonCancelar.Visibility = System.Windows.Visibility.Visible;
                    img_Imagen.Source = HerramientasWindow.BitmapAImageSource(new Bitmap(@"Imagenes\Iconos\Sistema\Dialogos\advertencia2.png"));
                }
                else if (tipoVentana == VentanaDialogoTipoVentana.ErrorSimple)
                {
                    img_Imagen.Source = HerramientasWindow.BitmapAImageSource(new Bitmap(@"Imagenes\Iconos\Sistema\Dialogos\error.png"));
                }
                try
                {
                    this.Icon = img_Imagen.Source;
                    ShowDialog();
                }
                catch (System.Windows.Media.Animation.AnimationException anim) { }
                VentanaDialogoBoton respuesta = VentanaDialogoBoton.Cancelar;
                if (botonRespuesta == 0)
                {
                    if (tipoVentana == VentanaDialogoTipoVentana.Pregunta || tipoVentana == VentanaDialogoTipoVentana.PreguntaAdvertencia)
                        respuesta = VentanaDialogoBoton.No;
                    else
                        respuesta = VentanaDialogoBoton.Cancelar;
                }
                else if (botonRespuesta == 1)
                {
                    if (tipoVentana == VentanaDialogoTipoVentana.Pregunta || tipoVentana == VentanaDialogoTipoVentana.PreguntaAdvertencia)
                        respuesta = VentanaDialogoBoton.Si;
                    else
                        respuesta = VentanaDialogoBoton.Aceptar;
                }
                return respuesta;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return VentanaDialogoBoton.Cancelar;
            }
        }

        private void btn_botonAceptar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            botonRespuesta = 1;
            Hide();
        }

        private void btn_botonCancelar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            botonRespuesta = 0;
            Hide();
        }

        private void btn_botonEnviarSoporte_MouseDown(object sender, MouseButtonEventArgs e)
        {
            botonRespuesta = -1;
           
            EnviarSoporte enviar = new EnviarSoporte();
            enviar.yaTomoFoto += enviar_yaTomoFoto;
            enviar.Excepcion = this.exception;
            enviar.DescripcionError = txt_Mensaje.Text;
            enviar.ShowDialog();
        }

        void enviar_yaTomoFoto()
        {
            this.Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
