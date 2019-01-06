using Karaoke.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Karaoke.Controles
{
    /// <summary>
    /// Lógica de interacción para ReproductorMediaElement.xaml
    /// </summary>
    public partial class ReproductorMediaElement : UserControl
    {
        public delegate void TerminoLaReproduccionActual();
        public event TerminoLaReproduccionActual terminoLaReproduccionActual;

        public delegate void MovioMouseSobreReproductor();
        public event MovioMouseSobreReproductor movioMouseSobreReproductor;

        public delegate void MaximizarYa();
        public event MaximizarYa maximizarYa;

        public enum Modo
        {
            YouTube = 0,
            WindowsMediaPlayer = 1
        }
        public Modo Modalidad { get; set; }
        public String URL { get; set; }
        public Boolean ConservarVideosYoutube { get; set; }
        public ReproductorMediaElement()
        {
            InitializeComponent();
            //activeXMediaPlayer.uiMode = "none";
            //activeXMediaPlayer.enableContextMenu = false;
            //activeXMediaPlayer.MouseMoveEvent += activeXMediaPlayer_MouseMoveEvent;
            //activeXMediaPlayer.settings.volume = 100;

            mediaElement.Volume = 100;
            mediaElement.MouseMove += mediaElement_MouseMove;
            mediaElement.LoadedBehavior = MediaState.Manual;

            mediaElement.MediaEnded += mediaElement_MediaEnded;


            minim = true;
            PrimeraVezMaximizado = false;

            pb_transcurrido.Value = 0;
            txt_nombreElemento.Text = "";
        }

        void mediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            if(terminoLaReproduccionActual != null)
                terminoLaReproduccionActual();
            Limpiar();
        }

        void mediaElement_MouseMove(object sender, MouseEventArgs e)
        {
            if (movioMouseSobreReproductor != null)
            {
                movioMouseSobreReproductor();
                PrimeraVezMaximizado = false;
            }
        }
        int YAnterior;
        int XAnterior;
        private Boolean minim;
        private Boolean PrimeraVezMaximizado;
        public Boolean Minimizo
        {
            get
            {
                return minim;
            }
            set
            {
                minim = value;
                YAnterior = 0;
                XAnterior = 0;
                PrimeraVezMaximizado = !value;
            }
        }
        public ElementoMultimedia ElementoReproduciendo { get { return elementoReproduciendo; } }
        ElementoMultimedia elementoReproduciendo;
        void activeXMediaPlayer_MouseMoveEvent(object sender, AxWMPLib._WMPOCXEvents_MouseMoveEvent e)
        {
            if (minim)
            {
                PrimeraVezMaximizado = false;
                YAnterior = 0;
                XAnterior = 0;
                return;
            }
            if (!PrimeraVezMaximizado)
            {
                PrimeraVezMaximizado = true;
                YAnterior = e.fY;
                XAnterior = e.fX;
                return;
            }
            if ((YAnterior != 0 && YAnterior != e.fY) || (XAnterior != 0 && XAnterior != e.fX))
            {
                if (movioMouseSobreReproductor != null)
                {
                    movioMouseSobreReproductor();
                    PrimeraVezMaximizado = false;
                }

            }
            YAnterior = e.fY;
            XAnterior = e.fX;



            //if (Minimizo)
            //{
            //    YAnterior = e.fY;
            //    XAnterior = e.fX;
            //    Minimizo = false;
            //}
            //if ((YAnterior != 0 && YAnterior != e.fY) || (XAnterior != 0 && XAnterior != e.fX))
            //{
            //    if (movioMouseSobreReproductor != null) movioMouseSobreReproductor();
            //    Minimizo = true;
            //}
            //YAnterior = e.fY;
            //XAnterior = e.fX;

        }
        public void Ocultar()
        {
        }

        public void Limpiar()
        {
            txt_nombreElemento.Text = "";
            pb_transcurrido.Value = 0;
        }

        public void Reproducir(ElementoMultimedia elemento)
        {
            mediaElement.Stop();
            //if ( elemento.TipoElemento == ElementoMultimedia.TipoElementoMultimedia.Karaoke && elemento.Titulo != null && !elemento.Titulo.Equals(""))
            //{
            //    Dispatcher.Invoke(new Action(() =>
            //    {
            //        maximizarYa();
            //        Stop();
            //        PreparacionKaraoke p = new PreparacionKaraoke(elemento.Titulo);
            //        p.WindowStyle = Principal.InstanciaEstatica.WindowStyle;
            //        p.ShowDialog();

            //    }));

            //}

            elementoReproduciendo = elemento;
            Modalidad = Modo.WindowsMediaPlayer;
            URL = elemento.URL;
            Play();
            txt_nombreElemento.Text = elemento.Titulo;
        }
        public void Stop()
        {
            //hostWinForms.Visibility = System.Windows.Visibility.Hidden;
            if (EstaReproduciendo())
                mediaElement.Stop();
        }
        Boolean Reproduciendo;
        public void VerificandoEstadoWMP()
        {
            while (true)
            {
                TimeSpan pos1 = new TimeSpan();
                TimeSpan pos2 = new TimeSpan();
                Dispatcher.Invoke(new Action(() =>
                {
                    pos1 = mediaElement.Position;
                }));
                System.Threading.Thread.Sleep(1);
                Dispatcher.Invoke(new Action(() =>
                {
                    pos2 = mediaElement.Position;
                }));

                Reproduciendo = pos2 != pos1;
            }

            //try
            //{
            //    Reproduciendo = true;
            //    String status = "";
            //    Thread.Sleep(2000);
            //    int conteoBuffering = 0;
            //    double segundosReproduciendo = 0;
            //    double duracionTotal = mediaElement.NaturalDuration.TimeSpan.TotalSeconds;

            //    while (Reproduciendo)
            //    {
            //        Reproduciendo = false;
                    
            //        if (Reproduciendo && !activeXMediaPlayer.stretchToFit)
            //            activeXMediaPlayer.stretchToFit = true;
            //        Thread.Sleep(1000);
            //        segundosReproduciendo++;
            //    }
            //    if (segundosReproduciendo >= duracionTotal-5)
            //        terminoLaReproduccionActual();
            //}
            //catch { }
        }
        public void FullScreen(Boolean Valor)
        {
            //if (activeXMediaPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
            //{
            //    activeXMediaPlayer.stretchToFit = Valor;
            //}
        }

        public void Pausar()
        {
            mediaElement.Pause();
        }

        public void Continuar()
        {
            mediaElement.Play();
        }

        public Boolean EstaReproduciendo()
        {
            if (Reproduciendo)
            {
                Dispatcher.Invoke(new Action(() =>
                {
                    try
                    {
                        pb_transcurrido.Value = (mediaElement.Position.TotalSeconds * 100) / mediaElement.NaturalDuration.TimeSpan.TotalSeconds;
                    }
                    catch { }
                }));
            }
            return Reproduciendo;
        }
        Thread tMonitoreo;
        private void Play()
        {
                try
                {
                    mediaElement.Source = new Uri(URL, UriKind.Absolute);
                    mediaElement.Play();
                    if (tMonitoreo != null && tMonitoreo.ThreadState != ThreadState.Stopped) tMonitoreo.Abort();
                    tMonitoreo = new Thread(VerificandoEstadoWMP);
                    tMonitoreo.Start();
                }
                catch
                {
                    Play();
                }
        }
    }
}
