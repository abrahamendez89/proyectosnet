using Karaoke.Clases;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Lógica de interacción para Calificador.xaml
    /// </summary>
    public partial class Calificador : Window
    {
        public delegate void ContinuarReproduciendo();
        public event ContinuarReproduciendo continuarReproduciendo;
        Thread t;
        public Calificador()
        {
            InitializeComponent();
            CargarCalificadores();
            this.WindowState = System.Windows.WindowState.Maximized;
            reproductor.Visibility = System.Windows.Visibility.Visible;
            this.txt_calificacion.MouseDown += txt_calificacion_MouseDown;
            reproductor.terminoLaReproduccionActual += reproductor_terminoLaReproduccionActual;
            this.IsVisibleChanged += Calificador_IsVisibleChanged;
            CargarCalificadores();
            Calificar();
        }

        void Calificador_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //if (this.Visibility == System.Windows.Visibility.Visible)
            //    Calificar();
        }
        List<CalificadorMedia> calificadoresLista = new List<CalificadorMedia>();
        private void CargarCalificadores()
        {
            calificadoresLista.Clear();
            List<string> calificadores = Directory.GetFiles(@"Calificador", "*.*", SearchOption.TopDirectoryOnly).Where(s => s.EndsWith(".mp4") || s.EndsWith(".avi") || s.EndsWith(".flv") || s.EndsWith(".mp3")).ToList();

            foreach (String calificador in calificadores)
            {
                String nombreArchivo = System.IO.Path.GetFileNameWithoutExtension(calificador);

                if (nombreArchivo.Contains("$"))
                {
                    try
                    {
                        String[] separacion1 = nombreArchivo.Split('$');
                        String mensaje = separacion1[1];
                        String[] separacion2 = separacion1[0].Split('-');
                        int rangoInterior = Convert.ToInt32(separacion2[0]);
                        int rangoExterior = Convert.ToInt32(separacion2[1]);

                        CalificadorMedia cal = new CalificadorMedia();
                        cal.Mensaje = mensaje;
                        cal.RangoMenor = rangoInterior;
                        cal.RangoMayor = rangoExterior;
                        cal.RutaArchivo = calificador;
                        calificadoresLista.Add(cal);
                    }
                    catch { }
                }
            }

        }
        void txt_calificacion_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Calificar();
        }
        private void Calificar()
        {
            calificando = false;
            txt_mensaje.Text = "";


            ElementoMultimedia elem = new ElementoMultimedia();
            elem.URL = @"Calificador\redoble.mp4";
            elem.TipoElemento = ElementoMultimedia.TipoElementoMultimedia.Calificador;
            reproductor.Reproducir(elem);

            t = new Thread(CambiarNumero);
            t.Start();
        }
        private void CambiarNumero()
        {
            double segundos = 0;
            Random rnd = new Random();
            while (true)
            {
                Dispatcher.Invoke(new Action(() =>
                {
                    txt_calificacion.Text = rnd.Next(0, 100).ToString();
                }));
                Thread.Sleep(100);
                //segundos += 0.1;
                //if (segundos >= 6)
                //{
                //    calificando = false;
                //    reproductor_terminoLaReproduccionActual();
                //    break;
                //}
            }
        }
        Boolean calificando = false;
        void reproductor_terminoLaReproduccionActual(Boolean fueSaltado)
        {
            if (calificando)
            {

                Dispatcher.Invoke(new Action(() =>
                {
                    calificando = false;
                    Close();
                }));
            }
            else
            {

                while (true)
                {
                    try
                    {
                        t.Abort();
                        break;
                    }
                    catch
                    {
                    }
                }
                calificando = true;
                int calificacion = 0;
                Dispatcher.Invoke(new Action(() =>
               {
                   calificacion = Convert.ToInt32(txt_calificacion.Text);
               }));
                ElementoMultimedia elemento = new ElementoMultimedia();
                elemento.TipoElemento = ElementoMultimedia.TipoElementoMultimedia.Calificador;
                String mensaje = "";


                foreach (CalificadorMedia cal in calificadoresLista)
                {
                    if (calificacion >= cal.RangoMenor && calificacion <= cal.RangoMayor)
                    {
                        elemento.URL = cal.RutaArchivo;
                        mensaje = cal.Mensaje;
                        break;
                    }
                }
                tiempoCalificacion = new Thread(Salir);
                reproductor.Reproducir(elemento);
                Dispatcher.Invoke(new Action(() =>
                {

                    txt_mensaje.Text = mensaje;

                }));
                //tiempoCalificacion.Start();
            }
        }
        Thread tiempoCalificacion;
        private void Salir()
        {
            Thread.Sleep(5000);
            Dispatcher.Invoke(new Action(() =>
            {
                Visibility = System.Windows.Visibility.Hidden;
                continuarReproduciendo();
            }));
        }
    }

    class CalificadorMedia
    {
        public int RangoMenor { get; set; }
        public int RangoMayor { get; set; }
        public String Mensaje { get; set; }
        public String RutaArchivo { get; set; }
    }
}
