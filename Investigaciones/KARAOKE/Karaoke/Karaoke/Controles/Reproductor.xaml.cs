//using Google.GData.Client;
//using Google.GData.YouTube;
//using Google.YouTube;
using Herramientas.Archivos;
using Herramientas.WPF;
using Karaoke.Clases;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// 
    /// Lógica de interacción para Reproductor.xaml
    /// </summary>
    public partial class Reproductor : UserControl
    {
        public delegate void TerminoLaReproduccionActual(Boolean fueSaltado);
        public event TerminoLaReproduccionActual terminoLaReproduccionActual;

        public delegate void MovioMouseSobreReproductor();
        public event MovioMouseSobreReproductor movioMouseSobreReproductor;

        public delegate void MaximizarYa();
        public event MaximizarYa maximizarYa;

        public String URL { get; set; }
        public Boolean ConservarVideosYoutube { get; set; }
        Variable var;
        public Reproductor()
        {
            try
            {
                InitializeComponent();
                activeXMediaPlayer.uiMode = "none";
                activeXMediaPlayer.enableContextMenu = false;
                activeXMediaPlayer.MouseMoveEvent += activeXMediaPlayer_MouseMoveEvent;
                activeXMediaPlayer.PlayStateChange += activeXMediaPlayer_PlayStateChange;
                activeXMediaPlayer.settings.volume = 100;
                activeXMediaPlayer.MediaError += activeXMediaPlayer_MediaError;
                activeXMediaPlayer.settings.autoStart = true;
                var = Compartidos.ObtenerVariablesConfiguracion();
                minim = true;
                PrimeraVezMaximizado = false;

                pb_transcurrido.Value = 0;
                txt_nombreElemento.Text = "";
            }
            catch { }
        }

        void activeXMediaPlayer_MediaError(object sender, AxWMPLib._WMPOCXEvents_MediaErrorEvent e)
        {
            BorrarReproduccionActual();
            terminoLaReproduccionActual(true);
        }
        public void GuardarReproduccionActual()
        {
            Variable var = Compartidos.ObtenerVariablesConfiguracion();

            var.GuardarValorVariable("REPRODUCCION_ACTUAL_TITULO", elementoReproduciendo.Titulo);
            var.GuardarValorVariable("REPRODUCCION_ACTUAL_URL", elementoReproduciendo.URL);
            var.GuardarValorVariable("REPRODUCCION_ACTUAL_TIPO", elementoReproduciendo.TipoElemento.ToString());
            var.ActualizarArchivo();
        }
        public void BorrarReproduccionActual()
        {
            Variable var = Compartidos.ObtenerVariablesConfiguracion();

            var.GuardarValorVariable("REPRODUCCION_ACTUAL_TITULO", "");
            var.GuardarValorVariable("REPRODUCCION_ACTUAL_URL", "");
            var.GuardarValorVariable("REPRODUCCION_ACTUAL_TIPO", "");
            var.ActualizarArchivo();
        }
        public void CargarUltimaReproduccion()
        {
            Variable var = Compartidos.ObtenerVariablesConfiguracion();

            elementoReproduciendo = new ElementoMultimedia();

            elementoReproduciendo.Titulo = var.ObtenerValorVariable<String>("REPRODUCCION_ACTUAL_TITULO");

            if (elementoReproduciendo.Titulo == null || elementoReproduciendo.Titulo.Equals("")) return;

            elementoReproduciendo.URL = var.ObtenerValorVariable<String>("REPRODUCCION_ACTUAL_URL");
            String tipo = var.ObtenerValorVariable<String>("REPRODUCCION_ACTUAL_TIPO");
            if (tipo.Equals("Karaoke"))
                elementoReproduciendo.TipoElemento = ElementoMultimedia.TipoElementoMultimedia.Karaoke;
            else if (tipo.Equals("Musica"))
                elementoReproduciendo.TipoElemento = ElementoMultimedia.TipoElementoMultimedia.Musica;
            else if (tipo.Equals("Video"))
                elementoReproduciendo.TipoElemento = ElementoMultimedia.TipoElementoMultimedia.Video;

        }
        private Boolean TerminoReproduccion = false;
        void activeXMediaPlayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (activeXMediaPlayer.playState == WMPLib.WMPPlayState.wmppsMediaEnded)// || activeXMediaPlayer.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                //if (!TerminoReproduccion)
                //{
                    BorrarReproduccionActual();
                    terminoLaReproduccionActual(false);
                //    TerminoReproduccion = true;
                //}
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


        public Boolean HayElementoCargado()
        {
            if (elementoReproduciendo != null)
                return true;
            return false;
        }

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

        }
        public void Limpiar()
        {
            txt_nombreElemento.Text = "";
            pb_transcurrido.Value = 0;
        }
        public void ReproducirElementoCargado()
        {
            Reproducir(elementoReproduciendo);
        }
        public void Reproducir(ElementoMultimedia elemento)
        {
            UnaVezReproducirNuevo = true;
            TerminoReproduccion = false;
            activeXMediaPlayer.Ctlcontrols.stop();

            if (elemento.TipoElemento == ElementoMultimedia.TipoElementoMultimedia.Karaoke && elemento.Titulo != null && !elemento.Titulo.Equals(""))
            {
                String usarPreparacionKaraoke = var.ObtenerValorVariable<String>("UsarPreparacionKaraoke");
                if (usarPreparacionKaraoke != null && usarPreparacionKaraoke.ToLower().Equals("si"))
                {

                    Dispatcher.Invoke(new Action(() =>
                    {
                        maximizarYa();
                        Stop();
                        PreparacionKaraoke p = new PreparacionKaraoke(elemento.Titulo);
                        p.WindowStyle = Principal.InstanciaEstatica.WindowStyle;
                        p.ShowDialog();

                    }));
                }
            }

            elementoReproduciendo = elemento;
            URL = elemento.URL;
            Play();
            if (elementoReproduciendo.TipoElemento != ElementoMultimedia.TipoElementoMultimedia.Calificador)
            {
                txt_nombreElemento.Text = elemento.Titulo;
                GuardarReproduccionActual();
            }
        }
        public void Stop()
        {
            if (EstaReproduciendo())
                activeXMediaPlayer.Ctlcontrols.stop();
            BorrarReproduccionActual();
        }
        Thread tMonitoreo;
        Boolean UnaVezReproducirNuevo = true;
        private void Play()
        {
            try
            {
                activeXMediaPlayer.URL = URL;

                if (elementoReproduciendo.TipoElemento != ElementoMultimedia.TipoElementoMultimedia.Calificador)
                {
                    txt_nombreElemento.Text = elementoReproduciendo.Titulo;
                }
                activeXMediaPlayer.Ctlcontrols.play();
                activeXMediaPlayer.stretchToFit = true;

                //if (tMonitoreo != null && tMonitoreo.ThreadState != ThreadState.Stopped) tMonitoreo.Abort();
                if (tMonitoreo == null)
                {
                    tMonitoreo = new Thread(ActualizarEstatusMedia);
                    tMonitoreo.Start();
                }
            }
            catch
            {
                if (UnaVezReproducirNuevo)
                {
                    UnaVezReproducirNuevo = false;
                    activeXMediaPlayer.Ctlcontrols.stop();
                    Play();
                    
                }
            }
        }
        public void FullScreen(Boolean Valor)
        {
            if (activeXMediaPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                activeXMediaPlayer.stretchToFit = Valor;
            }
        }

        public void Pausar()
        {
            if (activeXMediaPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                activeXMediaPlayer.Ctlcontrols.pause();
            }
        }

        public void Continuar()
        {
            if (activeXMediaPlayer.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                activeXMediaPlayer.Ctlcontrols.play();
            }
        }

        private void ActualizarEstatusMedia()
        {
            int segundosBuffering = 0;
            int playingSinReproducir = 0;
            double porcentajeValorAnterior = 0.0;
            while (true)
            {
                String nombre = "";
                Dispatcher.Invoke(new Action(() =>
               {
                   nombre = activeXMediaPlayer.playState.ToString();
                   txt_estatus.Text = nombre;
               }));
                Dispatcher.Invoke(new Action(() =>
                {
                    try
                    {
                        try
                        {
                            if (activeXMediaPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
                            {
                                segundosBuffering = 0;
                                //if (playingSinReproducir == 5)
                                //{
                                //    activeXMediaPlayer.Ctlcontrols.stop();
                                //    activeXMediaPlayer.URL = URL;
                                //    activeXMediaPlayer.Ctlcontrols.play();
                                //    playingSinReproducir = 0;
                                //    porcentajeValor = 0;
                                //}
                                //if (pb_transcurrido.Value == porcentajeValor)
                                //{
                                //    playingSinReproducir++;
                                //}
                                //else
                                //{
                                //    playingSinReproducir = 0;
                                //}
                                //porcentajeValor = pb_transcurrido.Value;
                            }
                            else if (activeXMediaPlayer.playState == WMPLib.WMPPlayState.wmppsReady)
                            {
                                activeXMediaPlayer.Ctlcontrols.play();
                                if (segundosBuffering == 5)
                                {
                                    BorrarReproduccionActual();
                                    terminoLaReproduccionActual(true);
                                    segundosBuffering = 0;
                                }
                                segundosBuffering++;
                            }
                            else if (activeXMediaPlayer.playState == WMPLib.WMPPlayState.wmppsTransitioning)
                            {
                                activeXMediaPlayer.Ctlcontrols.stop();
                                activeXMediaPlayer.URL = URL;
                                activeXMediaPlayer.Ctlcontrols.play();
                            }
                            else if (activeXMediaPlayer.playState == WMPLib.WMPPlayState.wmppsBuffering)
                            {
                                if (segundosBuffering == 5)
                                {
                                    activeXMediaPlayer.Ctlcontrols.stop();
                                    activeXMediaPlayer.URL = URL;
                                    activeXMediaPlayer.Ctlcontrols.play();
                                    segundosBuffering = 0;
                                }
                                segundosBuffering++;
                            }
                        }
                        catch { }
                        if (elementoReproduciendo.TipoElemento != ElementoMultimedia.TipoElementoMultimedia.Calificador)
                        {
                            try
                            {
                                pb_transcurrido.Value = (activeXMediaPlayer.Ctlcontrols.currentPosition * 100) / activeXMediaPlayer.Ctlcontrols.currentItem.duration;
                                if (activeXMediaPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying && porcentajeValorAnterior == pb_transcurrido.Value)
                                {
                                    activeXMediaPlayer.Ctlcontrols.stop();
                                    activeXMediaPlayer.URL = URL;
                                    activeXMediaPlayer.Ctlcontrols.play();
                                }
                                
                            }
                            catch
                            {
                                pb_transcurrido.Value = 0;
                            }
                        }
                    }
                    catch { }
                }));
                Thread.Sleep(1000);
                
                Dispatcher.Invoke(new Action(() =>
                {
                    porcentajeValorAnterior = pb_transcurrido.Value;
                }));
            }
        }

        public Boolean EstaReproduciendo()
        {
            try
            {
                String estatus = activeXMediaPlayer.playState.ToString();
                try
                {
                    if (activeXMediaPlayer.playState == WMPLib.WMPPlayState.wmppsReady)
                    {
                        activeXMediaPlayer.Ctlcontrols.play();
                    }
                }
                catch { }
                if (activeXMediaPlayer.playState != WMPLib.WMPPlayState.wmppsMediaEnded && activeXMediaPlayer.playState != WMPLib.WMPPlayState.wmppsStopped && activeXMediaPlayer.playState != WMPLib.WMPPlayState.wmppsUndefined)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }

    }
}
