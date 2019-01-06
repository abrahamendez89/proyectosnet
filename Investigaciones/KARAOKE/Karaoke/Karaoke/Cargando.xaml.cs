using Herramientas.Archivos;
using Herramientas.Forms;
using Herramientas.WPF;
using Karaoke.Clases;
using Karaoke.Configuracion;
using Karaoke.Controles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
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
using System.Windows.Shapes;

namespace Karaoke
{
    /// <summary>
    /// Lógica de interacción para Cargando.xaml
    /// </summary>
    public partial class Cargando : Window
    {
        List<Agrupador> agrupadoresPrincipales;// = new List<Agrupador>();
        Bitmap disco;
        BackgroundWorker worker = new BackgroundWorker();
        public Cargando()
        {
            InitializeComponent();
            try
            {
                mediaElement.Source = new Uri(@"file://" + Environment.CurrentDirectory + @"\Imagenes\cargando.gif");
                mediaElement.LoadedBehavior = MediaState.Manual;
                mediaElement.Stretch = Stretch.Fill;
                mediaElement.MediaEnded += mediaElement_MediaEnded;
                mediaElement.Play();

                disco = new Bitmap(@"Imagenes\cd_estandar.png");

                //YouTubeDownloader yt = new YouTubeDownloader();
                //yt.mostrarProgreso += yt_mostrarProgreso;
                //yt.DescargarAudio("https://www.youtube.com/watch?v=mQWOAjSffHI", "Descargas Youtube audio");

                worker.DoWork += worker_DoWork;
                worker.RunWorkerCompleted += worker_RunWorkerCompleted;
                worker.RunWorkerAsync();
             }
            catch
            {
                Mensajes.Error("Ocurrio un error al cargar los archivos multimedia, verificar rutas.");
            }
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            new Principal(agrupadoresPrincipales).Show();
            this.Hide();
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Variable var = Compartidos.ObtenerVariablesConfiguracion();
            var.LeerArchivo();
            String r = var.ObtenerValorVariable<String>("AutoActualizarContenido");

            if (r != null && r.ToLower().Equals("si"))
            {
                ProcesoArchivos p = new ProcesoArchivos();
                p.mostrarMensaje += p_mostrarMensaje;
                p.mostrarPorcentaje += p_mostrarPorcentaje;
                p.ProcesoPrincipalMain();
            }
            IniciarCargado();
        }

        void p_mostrarPorcentaje(double porcentaje)
        {
        }

        void p_mostrarMensaje(string mensaje)
        {
            MostrarMensaje(mensaje);
        }
        private void MostrarMensaje(String mensaje)
        {
            Dispatcher.Invoke(new Action(() =>
            {
                txt_texto.Text = mensaje;
            }));
        }
        private void IniciarCargado()
        {
                agrupadoresPrincipales = new List<Agrupador>();
                MostrarMensaje("Cargando karaoke...");
                Agrupador karaoke = CargarContenido("KARAOKE", ElementoMultimedia.TipoElementoMultimedia.Karaoke);
                if (karaoke.AgrupadoresHijos.Count > 0)
                {
                    karaoke.ImagenTexto = @"Imagenes\categoria_karaoke.png";
                    karaoke.NombreAgrupador = "KARAOKE";
                    agrupadoresPrincipales.Add(karaoke);
                }
                MostrarMensaje("Cargando música...");
                Agrupador musica = CargarContenido("MUSICA", ElementoMultimedia.TipoElementoMultimedia.Musica);
                if (musica.AgrupadoresHijos.Count > 0)
                {
                    musica.ImagenTexto = @"Imagenes\categoria_musica.png";
                    musica.NombreAgrupador = "MUSICA";
                    agrupadoresPrincipales.Add(musica);
                }
                MostrarMensaje("Cargando videos...");
                Agrupador videos = CargarContenido("VIDEOS", ElementoMultimedia.TipoElementoMultimedia.Video);
                if (videos.AgrupadoresHijos.Count > 0)
                {
                    videos.ImagenTexto = @"Imagenes\categoria_video.png";
                    videos.NombreAgrupador = "VIDEOS";
                    agrupadoresPrincipales.Add(videos);
                }

                //////MostrarMensaje("Comprobando conexión a internet...");
                //////double velocidadInternet = Herramientas.Net.Internet.ObtenerVelocidadInternet();
                //////String mensajeInternet = "Velocidad actual: " + velocidadInternet + " Mbps, ";
                //////if (velocidadInternet > 0 && velocidadInternet < 0.5)
                //////    mensajeInternet += " conexión insuficiente...";
                //////else if (velocidadInternet == 0)
                //////    mensajeInternet = "No hay conexión a internet...";
                //////MostrarMensaje(mensajeInternet);
                //////Thread.Sleep(1500);
                //////if (velocidadInternet > 0.5)
                //////{
                //////    MostrarMensaje("Agregando acceso a YouTube...");
                //////    Agrupador youtube = CargarContenido("YOUTUBE", ElementoMultimedia.TipoElementoMultimedia.YouTube);
                //////    agrupadoresPrincipales.Add(youtube);
                //////}


                //agrupadoresPrincipales[0].ImagenTexto = @"Imagenes\categoria_karaoke.png";
                //agrupadoresPrincipales[0].NombreAgrupador = "KARAOKE";
                //agrupadoresPrincipales[1].ImagenTexto = @"Imagenes\categoria_musica.png";
                //agrupadoresPrincipales[1].NombreAgrupador = "MUSICA";
                //agrupadoresPrincipales[2].ImagenTexto = @"Imagenes\categoria_video.png";
                //agrupadoresPrincipales[2].NombreAgrupador = "VIDEOS";
        }

        void mediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            mediaElement.Position = new TimeSpan(0, 0, 1);
            mediaElement.Play();
        }
        private Agrupador CargarContenido(String nombre, ElementoMultimedia.TipoElementoMultimedia tipo)
        {
            Agrupador principalAgrupador = new Agrupador();
            principalAgrupador.AgrupadoresHijos = new List<Agrupador>();
            try
            {
                if (tipo == ElementoMultimedia.TipoElementoMultimedia.YouTube)
                {
                    Agrupador agrupadorYoutube = new Agrupador();
                    agrupadorYoutube.NombreAgrupador = "YOUTUBE";
                    agrupadorYoutube.ImagenTexto = @"Imagenes\categoria_youtube.png";

                    agrupadorYoutube.AgrupadoresHijos = new List<Agrupador>();
                    Agrupador vidY = new Agrupador();
                    vidY.NombreAgrupador = "VIDEOS YOUTUBE";
                    Agrupador muY = new Agrupador();
                    muY.NombreAgrupador = "MUSICA YOUTUBE";
                    Agrupador karY = new Agrupador();
                    karY.NombreAgrupador = "KARAOKE YOUTUBE";

                    vidY.Siguiente = muY;
                    muY.Siguiente = karY;

                    agrupadorYoutube.AgrupadoresHijos.Add(vidY);
                    agrupadorYoutube.AgrupadoresHijos.Add(muY);
                    agrupadorYoutube.AgrupadoresHijos.Add(karY);

                    return agrupadorYoutube;
                }
                Variable var = Compartidos.ObtenerVariablesContenido();
                var.LeerArchivo();
                principalAgrupador.NombreAgrupador = nombre;

                int gruposKaraoke = var.ObtenerValorVariable<int>(nombre + "_GRUPOS");
                

                for (int i = 0; i < gruposKaraoke; i++)
                {
                    String nombreGrupo = var.ObtenerValorVariable<String>(nombre + "_GRUPOS_" + i);
                    Agrupador grupo = new Agrupador();
                    grupo.NombreAgrupador = nombreGrupo;
                    grupo.AgrupadorPadre = principalAgrupador;
                    grupo.AgrupadoresHijos = new List<Agrupador>();

                    int agrupadores = var.ObtenerValorVariable<int>(nombre + "_GRUPOS_" + i + "_AGRUPADORES");

                    Agrupador anterior = null;

                    for (int j = 0; j < agrupadores; j++)
                    {
                        String nombreAgrupador = var.ObtenerValorVariable<String>(nombre + "_GRUPOS_" + i + "_AGRUPADORES_" + j);
                        Bitmap imagenAgrupador = null;
                        String rutaImagen = var.ObtenerValorVariable<String>(nombre + "_GRUPOS_" + i + "_AGRUPADORES_" + j + "_IMAGEN");
                        try
                        {
                            imagenAgrupador = new Bitmap(rutaImagen);
                        }
                        catch
                        {
                            imagenAgrupador = disco;
                        }
                        int numeroPistas = var.ObtenerValorVariable<int>(nombre + "_GRUPOS_" + i + "_AGRUPADORES_" + j + "_PISTAS");
                        Agrupador agrupador = new Agrupador();
                        agrupador.NombreAgrupador = nombreAgrupador.ToUpper();
                        //agrupador.Imagen = (ImageSource)Herramientas.WPF.Utilidades.FileTOImageSource(rutaImagen); //Herramientas.WPF.Utilidades.BitmapAImageSource(imagenAgrupador);
                        agrupador.AgrupadorPadre = grupo;
                        agrupador.ImagenTexto = rutaImagen;
                        agrupador.ElementosMultimedia = new List<ElementoMultimedia>();
                        agrupador.Codigo = j + 1;
                        if (anterior != null)
                            anterior.Siguiente = agrupador;
                        for (int k = 0; k < numeroPistas; k++)
                        {
                            String pista = var.ObtenerValorVariable<String>(nombre + "_GRUPOS_" + i + "_AGRUPADORES_" + j + "_PISTA_" + k);
                            ElementoMultimedia elemento = new ElementoMultimedia();
                            elemento.AgrupadorContiene = agrupador;
                            elemento.Titulo = System.IO.Path.GetFileNameWithoutExtension(pista).ToUpper();
                            elemento.URL = pista;
                            elemento.TipoElemento = tipo;
                            elemento.Codigo = k + 1;
                            agrupador.ElementosMultimedia.Add(elemento);
                        }
                        agrupador.Anterior = anterior;
                        anterior = agrupador;

                        grupo.AgrupadoresHijos.Add(agrupador);
                    }
                    grupo.AgrupadoresHijos[0].Anterior = grupo.AgrupadoresHijos[grupo.AgrupadoresHijos.Count - 1];
                    grupo.AgrupadoresHijos[grupo.AgrupadoresHijos.Count - 1].Siguiente = grupo.AgrupadoresHijos[0];

                    principalAgrupador.AgrupadoresHijos.Add(grupo);
                }
                //corrigiendo ultimos y primeros
                //foreach (Agrupador grupo in principalAgrupador.AgrupadoresHijos)
                //{
                //    grupo.AgrupadoresHijos[0].Anterior = null;
                //    grupo.AgrupadoresHijos[grupo.AgrupadoresHijos.Count - 1].Siguiente = null;
                //}
            }
            catch
            {
            }
            return principalAgrupador;
        }
    }
}
