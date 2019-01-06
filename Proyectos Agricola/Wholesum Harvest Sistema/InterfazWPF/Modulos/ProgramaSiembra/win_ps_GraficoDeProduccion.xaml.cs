using Dominio;
using Dominio.Modulos.ProgramaSiembra;
using InterfazWPF.AdministracionSistema;
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
using Herramientas.ORM;

namespace InterfazWPF.Modulos.ProgramaSiembra
{
    /// <summary>
    /// Lógica de interacción para win_ps_GraficoDeProduccion.xaml
    /// </summary>
    public partial class win_ps_GraficoDeProduccion : Window
    {
        ManejadorDB manejador = new ManejadorDB();
        public win_ps_GraficoDeProduccion()
        {
            InitializeComponent();


            _ps_EspacioFisico cardenal = manejador.Cargar<_ps_EspacioFisico>(_ps_EspacioFisico.ConsultaPorNombre, new List<object>() { "Cardenal" });
            GenerarMapa(cardenal);
            DibujarEspacio(cardenal);

            
        }

        private void DibujarEspacio(_ps_EspacioFisico espacio)
        {
            Dibujar(espacio);

            if(espacio.ll_Espacios_fisicos_dentro != null)
            foreach (_ps_EspacioFisico espacioDentro in espacio.ll_Espacios_fisicos_dentro)
            {
                DibujarEspacio(espacioDentro);
            }
        }
        double pixelesEnY;
        double pixelesEnX;
        double latitudMenor;
        double latitudMayor ;
        double longitudMenor ;
        double longitudMayor;
        System.Drawing.Bitmap checks;
        int factorEscala = 5;
        private void GenerarMapa(_ps_EspacioFisico espacio)
        {
            List<String> coordenadas = new List<string>();

            if (espacio.St_CoordenadasEspaciales == null) return;

            coordenadas = espacio.St_CoordenadasEspaciales.Split('|').ToList<String>();

            List<double> latitudes = new List<double>();
            List<double> longitudes = new List<double>();

            foreach (String coordenada in coordenadas)
            {
                latitudes.Add(Convert.ToDouble(coordenada.Split(',')[0]));
                longitudes.Add(Convert.ToDouble(coordenada.Split(',')[1]));
            }

            longitudes.Sort();
            latitudes.Sort();

            latitudMenor = latitudes[0];
            latitudMayor = latitudes[latitudes.Count - 1];
            longitudMenor = longitudes[0];
            longitudMayor = longitudes[longitudes.Count - 1];

            pixelesEnY = (latitudMayor - latitudMenor) * 500000;

            pixelesEnX = (longitudMayor - longitudMenor) * 500000;

            List<String> pixeles = new List<string>();

            foreach (String coordenada in coordenadas)
            {
                double latitud = Convert.ToDouble(coordenada.Split(',')[0]);
                double longitud = Convert.ToDouble(coordenada.Split(',')[1]);

                double pixelY = (latitud - latitudMenor) * 500000;
                double pixelX = (longitud - longitudMenor) * 500000;
                pixeles.Add((int)pixelY / factorEscala + ", " + (int)pixelX / factorEscala);

            }
            pixelesEnX = pixelesEnX / factorEscala + 10;
            pixelesEnY = pixelesEnY / factorEscala + 10;
            checks = new System.Drawing.Bitmap((int)pixelesEnX, (int)pixelesEnY);
            for (int i = 0; i < (int)pixelesEnX; i++)
            {
                for (int j = 0; j < (int)pixelesEnY; j++)
                {
                    checks.SetPixel(i, j, System.Drawing.Color.White);
                }
            }
        }
        private void Dibujar(_ps_EspacioFisico espacio)
        {
            List<String> coordenadas = new List<string>();
            if (espacio.St_CoordenadasEspaciales == null) return;
            coordenadas = espacio.St_CoordenadasEspaciales.Split('|').ToList<String>();
            List<String> pixeles = new List<string>();
            foreach (String coordenada in coordenadas)
            {
                double latitud = Convert.ToDouble(coordenada.Split(',')[0]);
                double longitud = Convert.ToDouble(coordenada.Split(',')[1]);

                double pixelY = (latitud - latitudMenor) * 500000;
                double pixelX = (longitud - longitudMenor) * 500000;
                pixeles.Add((int)pixelY / factorEscala + ", " + (int)pixelX / factorEscala);

            }
            foreach (String pixel in pixeles)
            {
                int pixelX = Convert.ToInt32(pixel.Split(',')[0]);
                int pixelY = Convert.ToInt32(pixel.Split(',')[1]);
                checks.SetPixel(pixelY, checks.Height - 1 - pixelX, System.Drawing.Color.Black);
            }
            Graphics g = Graphics.FromImage(checks);
            for (int i = 0; i < pixeles.Count - 1; i++)
                g.DrawLine(Pens.Black, new System.Drawing.Point(Convert.ToInt32(pixeles[i].Split(',')[1]), checks.Height - 1 - Convert.ToInt32(pixeles[i].Split(',')[0])), new System.Drawing.Point(Convert.ToInt32(pixeles[i + 1].Split(',')[1]), checks.Height - 1 - Convert.ToInt32(pixeles[i + 1].Split(',')[0])));

            g.DrawLine(Pens.Black, new System.Drawing.Point(Convert.ToInt32(pixeles[pixeles.Count - 1].Split(',')[1]), checks.Height - 1 - Convert.ToInt32(pixeles[pixeles.Count - 1].Split(',')[0])), new System.Drawing.Point(Convert.ToInt32(pixeles[0].Split(',')[1]), checks.Height - 1 - Convert.ToInt32(pixeles[0].Split(',')[0])));
            String drawString = espacio.st_Nombre_espacio;
            EscribirTexto(g, espacio.st_Nombre_espacio, new System.Drawing.Point(Convert.ToInt32(pixeles[0].Split(',')[1]), checks.Height - 1 - Convert.ToInt32(pixeles[0].Split(',')[0])));
            EscribirTexto(g, "HA: "+espacio.do_Numero_hectareas, new System.Drawing.Point(Convert.ToInt32(pixeles[0].Split(',')[1]),10+ checks.Height - 1 - Convert.ToInt32(pixeles[0].Split(',')[0])));
            g.Flush();
            img_test.Source = Herramientas.WPF.Utilidades.BitmapAImageSource(checks);
        }

        private void EscribirTexto(Graphics g, String texto, System.Drawing.Point punto)
        {
            Font drawFont = new Font("Arial", 9);
            SolidBrush drawBrush = new SolidBrush(System.Drawing.Color.Red);
            g.DrawString(texto, drawFont, drawBrush, punto);
        }

        private void img_test_MouseDown(object sender, MouseButtonEventArgs e)
        {
            VisorImagenes visor = new VisorImagenes(HerramientasWindow.ImageSourceABitmap(img_test.Source));
            visor.Show();
            checks.Save(@"C:\Users\Abrahamm.WHOLESUM\Desktop\Nueva carpeta\archivo.jpg");
        }
    }
}
