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
using System.Windows.Shapes;

namespace Karaoke
{
    /// <summary>
    /// Lógica de interacción para PreparacionKaraoke.xaml
    /// </summary>
    public partial class PreparacionKaraoke : Window
    {
        public PreparacionKaraoke(String titulo)
        {
            InitializeComponent();
            img_micro.Source = Herramientas.WPF.Utilidades.ArchivoAImageSource(@"Imagenes\presentador_microfono.png");
            txt_nombreKaraoke.Text = titulo.ToUpper();
            Thread t = new Thread(ConteoAtras);
            t.Start();

            if (!Principal.caduc)
            {
                try
                {
                    img_logo.Fill = new ImageBrush(Herramientas.WPF.Convertir.BitmapToImageSource(Principal.LogoNegocio));
                }
                catch
                {
                }
            }

        }

        private void ConteoAtras()
        {
            int conteo = 5;

            try
            {
                conteo = Compartidos.ObtenerVariablesConfiguracion().ObtenerValorVariable<Int32>("SegundosPreparacionKaraoke");
            }
            catch
            {}
            
            for (int i = conteo; i > 0; i--)
            {
                Dispatcher.Invoke(new Action(() =>
                { 
                    txt_conteoAtras.Text = i.ToString();
                }));
                Thread.Sleep(1000);
            }
            Dispatcher.Invoke(new Action(() =>
            {
                Close();
            }));

        }
    }
}
