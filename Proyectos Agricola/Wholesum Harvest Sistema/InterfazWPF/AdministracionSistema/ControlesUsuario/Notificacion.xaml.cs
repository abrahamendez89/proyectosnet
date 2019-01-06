using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using InterfazWPF.AdministracionSistema;
using System.Windows.Threading;

namespace InterfazWPF
{
    /// <summary>
    /// Lógica de interacción para Notificacion.xaml
    /// </summary>
    public partial class Notificacion : Window
    {
        private Storyboard Entrada;
        private Storyboard Salida;
        private DispatcherTimer dispatcherTimer = new DispatcherTimer();
        private int segundosAMostrar;
        private Delegate delegadoMasInformacion;
        private Delegate delegadoCerrado;
        public delegate void SeCerroNotificacion(int posicion);
        public event SeCerroNotificacion seCerroNotificacion;
        private int posicion;
        private Boolean cerrarDespuesDeMasInformacion;
        private Boolean EjecutarDelegadoCerradoDespuesDeSegundosTranscurridos;
        public Notificacion(String titulo, String mensaje, Bitmap imagen, int segundosAMostrar, int posicion, Delegate delegadoMasInformacion, Delegate delegadoCerrado, Boolean cerrarDespuesDeMasInformacion, Boolean EjecutarDelegadoCerradoDespuesDeSegundosTranscurridos)
        {
            this.InitializeComponent();

            this.EjecutarDelegadoCerradoDespuesDeSegundosTranscurridos = EjecutarDelegadoCerradoDespuesDeSegundosTranscurridos;
            txt_titulo.Text = titulo;
            txt_mensaje.Text = mensaje;
            this.posicion = posicion;
            if (segundosAMostrar <= 0)
            {
                img_cerrar.Source = HerramientasWindow.BitmapAImageSource(new Bitmap(@"Imagenes\Iconos\Sistema\CerrarTab.png"));
                img_cerrar_Copy.Source = img_cerrar.Source;
                
            }
            img_imagen.Source = HerramientasWindow.BitmapAImageSource(imagen);
            this.segundosAMostrar = segundosAMostrar;
            Entrada = (Storyboard)this.FindResource("OnLoaded1");
            Entrada.Completed += Entrada_Completed;
            Entrada.Begin();
            Closed += Notificacion_Closed;

            this.cerrarDespuesDeMasInformacion = cerrarDespuesDeMasInformacion;
            
            txt_masInformacion.Visibility = System.Windows.Visibility.Hidden;
            if (delegadoMasInformacion != null)
            {
                this.delegadoMasInformacion = delegadoMasInformacion;
                txt_masInformacion.Visibility = System.Windows.Visibility.Visible;
            }
            if (delegadoCerrado != null)
            {
                this.delegadoCerrado = delegadoCerrado;
            }
        }


        void img_cerrar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (delegadoCerrado != null)
                    delegadoCerrado.DynamicInvoke();
                Close();
            }
            catch { }
        }

        void Notificacion_Closed(object sender, EventArgs e)
        {
            seCerroNotificacion(posicion);
        }

        void Entrada_Completed(object sender, EventArgs e)
        {
            if (segundosAMostrar > 0)
            {
                dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
                dispatcherTimer.Interval = new TimeSpan(0, 0, segundosAMostrar);
                dispatcherTimer.Start();
            }
            else
            {
                img_cerrar.MouseDown += img_cerrar_MouseDown;
                txt_masInformacion.MouseDown += txt_masInformacion_MouseDown;
            }
        }

        void txt_masInformacion_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (delegadoMasInformacion != null)
                    delegadoMasInformacion.DynamicInvoke();
                if (cerrarDespuesDeMasInformacion)
                {
                    if (delegadoCerrado != null)
                        delegadoCerrado.DynamicInvoke();
                    Close();
                }
            }
            catch { }
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                Salida = (Storyboard)this.FindResource("Salida");
                Salida.Completed += Salida_Completed;
                Salida.Begin();
                
            }
            catch { }
        }

        void Salida_Completed(object sender, EventArgs e)
        {
            Close();
            if (EjecutarDelegadoCerradoDespuesDeSegundosTranscurridos)
            {
                if (delegadoCerrado != null)
                    delegadoCerrado.DynamicInvoke();
            }
        }
    }
}