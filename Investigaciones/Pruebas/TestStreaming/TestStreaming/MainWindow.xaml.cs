using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Packaging;
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

namespace TestStreaming
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //MemoryStream packStream = new MemoryStream();
            //Package pack = Package.Open(packStream, FileMode.Create, FileAccess.ReadWrite);
            //Uri packUri = new Uri("bla:");
            //PackageStore.AddPackage(packUri, pack);
            //Uri packPartUri = new Uri("/MemoryResource", UriKind.Relative);
            //PackagePart packPart = pack.CreatePart(packPartUri, "Media/MemoryResource");
            //packPart.GetStream().Write(bytes, 0, bytes.Length);
            //var inMemoryUri = PackUriHelper.Create(packUri, packPart.Uri);






        }

        void yt_mostrarProgreso(YouTubeDownloader instancia, double progreso)
        {
            Dispatcher.Invoke(new Action(() =>
           {
               if (progreso > 10 && mediaElement.Source == null)
               {

               }
           }));
        }

        void yt_terminoDescarga(YouTubeDownloader instancia, string urlArchivo)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Thread t = new Thread(Descargar);
            t.Start();

        }

        private void Descargar()
        {
            YouTubeDownloader yt = new YouTubeDownloader();
            yt.terminoDescarga += yt_terminoDescarga;
            yt.mostrarProgreso += yt_mostrarProgreso;
            yt.getAbsoluteUri += yt_getAbsoluteUri;
            yt.DescargarVideo("https://www.youtube.com/watch?v=7aqHmNudKYg", "Descarga");
        }

        void yt_getAbsoluteUri(string url)
        {
            Dispatcher.Invoke(new Action(() =>
            {

                mediaElement.LoadedBehavior = MediaState.Manual;
                mediaElement.Source = new Uri(url, UriKind.Absolute);
                mediaElement.Play();
            }));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            mediaElement.Pause();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            mediaElement.Play();
        }

    }
}
