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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Karaoke.Controles
{
    /// <summary>
    /// Lógica de interacción para ControladoresTouch.xaml
    /// </summary>
    public partial class ControladoresTouch : UserControl
    {
        public delegate void Click(BotonTouch boton);
        public event Click click;

        public delegate void ReiniciarFechaLogo();
        public event ReiniciarFechaLogo reiniciarFechaLogo;

        public delegate void EjecutarBusqueda(String busqueda);
        public event EjecutarBusqueda ejecutarBusqueda;
        public String Text { get { return txt_buscador.Text; } set { txt_buscador.Text = value; } }

        public Bitmap LogoEmpresa { 
            set         
            {
                try
                {
                    rtg_Logo.Fill = new ImageBrush(Herramientas.WPF.Convertir.BitmapToImageSource(value));
                }
                catch
                {
                }
            } }

        public ModalidadTeclado ModalidadActual { get; set; }

        Storyboard aparece;
        Storyboard desaparece;

        public enum ModalidadTeclado
        {
            Principal = 0,
            Reproductor = 1,
            Teclado = 2,
            Categorias = 3,
            PlayList = 4
        }
        String fondo;
        String teclado;
        String abajo;
        String multimedia;
        String izquierda;
        String seleccionar;
        String derecha;
        String categorias;
        String arriba;
        String playList;

        String borrar;
        String play;
        String pausa;
        String adelantar;
        String enter;
        String borrarLetra;
        String espacioBlanco;
        String borrarTodo;

        public void CargarImagenes()
        {
            fondo = @"Imagenes\menu_fondo.png";
            teclado = @"Imagenes\menu_teclado.png";
            abajo = @"Imagenes\menu_abajo.png";
            multimedia = @"Imagenes\menu_controlesMultimedia.png";
            izquierda = @"Imagenes\menu_izquierda.png";
            seleccionar = @"Imagenes\menu_seleccionar.png";
            derecha = @"Imagenes\menu_derecha.png";
            categorias = @"Imagenes\menu_categorias.png";
            arriba = @"Imagenes\menu_arriba.png";
            playList = @"Imagenes\menu_playlist.png";

            borrar = @"Imagenes\menu_borrar.png";
            play = @"Imagenes\menu_play.png";
            pausa = @"Imagenes\menu_pausa.png";
            adelantar = @"Imagenes\menu_adelantar.png";

            enter = @"Imagenes\menu_enter.png";
            borrarLetra = @"Imagenes\menu_borrarLetra.png";
            espacioBlanco = @"Imagenes\menu_espacioBlanco.png";
            borrarTodo = @"Imagenes\menu_borrarTodo.png";
        }

        public void ApareceLogo()
        {
            Dispatcher.Invoke(new Action(() =>
            {
                if (rtg_Logo.Visibility == System.Windows.Visibility.Hidden)
                    aparece.Begin();

            }));
            
        }
        public void DespareceLogo()
        {
            Dispatcher.Invoke(new Action(() =>
            {
                if (rtg_Logo.Visibility == System.Windows.Visibility.Visible)
                    desaparece.Begin();
                reiniciarFechaLogo();
            }));
            
        }
        public ControladoresTouch()
        {

            InitializeComponent();
            try
            {
                CargarImagenes();
                btn_1.click += btn_1_click;
                btn_2.click += btn_1_click;
                btn_3.click += btn_1_click;
                btn_4.click += btn_1_click;
                btn_5.click += btn_1_click;
                btn_6.click += btn_1_click;
                btn_7.click += btn_1_click;
                btn_8.click += btn_1_click;
                btn_9.click += btn_1_click;

                btn_1.Tag = "1";
                btn_2.Tag = "2";
                btn_3.Tag = "3";
                btn_4.Tag = "4";
                btn_5.Tag = "5";
                btn_6.Tag = "6";
                btn_7.Tag = "7";
                btn_8.Tag = "8";
                btn_9.Tag = "9";



                ModalidadActual = ModalidadTeclado.Principal;
                SetModalidad(ModalidadTeclado.Principal);

                txt_buscador.ejecutarBusqueda += txt_buscador_ejecutarBusqueda;

            }
            catch { }
            rtg_Logo.MouseDown += img_logo_MouseDown;
            aparece = (Storyboard)this.FindResource("apareceLogo");
            desaparece = (Storyboard)this.FindResource("desapareceLogo");
        }

        void img_logo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DespareceLogo();
        }

        void txt_buscador_ejecutarBusqueda(string busqueda)
        {
            ejecutarBusqueda(busqueda);
        }

        public Boolean VisibleTextBox { get { return txt_buscador.Visibility != System.Windows.Visibility.Hidden; } set { if (value) { txt_buscador.Visibility = System.Windows.Visibility.Visible; } else { txt_buscador.Visibility = System.Windows.Visibility.Hidden; } } }
        public void BorrarTodo()
        {
            txt_buscador.BorrarTodo();
        }
        public void Enter()
        {
            txt_buscador.Enter();
        }
        public void BorrarLetra()
        {
            txt_buscador.BorrarLetra();
        }
        public void AgregarLetra(char letra)
        {
            txt_buscador.AgregarLetra(letra);
        }

        void btn_1_click(BotonTouch boton)
        {
            if (click != null) click(boton);
        }
        public String ObtenerAccionActual(String indice)
        {
            if (indice.Equals("1"))
                return btn_1.Indice;
            if (indice.Equals("2"))
                return btn_2.Indice;
            if (indice.Equals("3"))
                return btn_3.Indice;
            if (indice.Equals("4"))
                return btn_4.Indice;
            if (indice.Equals("5"))
                return btn_5.Indice;
            if (indice.Equals("6"))
                return btn_6.Indice;
            if (indice.Equals("7"))
                return btn_7.Indice;
            if (indice.Equals("8"))
                return btn_8.Indice;
            if (indice.Equals("9"))
                return btn_9.Indice;
            return indice;
        }
        public void EjecutarEvento(String indice)
        {
            if (indice.Equals("")) return;
            foreach (BotonTouch btn in botones.Children)
            {
                if (btn.Indice.ToString().Equals(indice))
                {
                    btn.EjecutarEvento();
                    break;
                }
            }
        }
        public void SetModalidad(ModalidadTeclado modalidad)
        {
            ModalidadActual = modalidad;
            btn_5.SetLetra(' ');
            if (modalidad == ModalidadTeclado.Principal)
            {
                txt_buscador.Visibility = System.Windows.Visibility.Hidden;
                btn_1.Imagen = Herramientas.WPF.Utilidades.ArchivoAImageSource(teclado);
                btn_2.Imagen = Herramientas.WPF.Utilidades.ArchivoAImageSource(abajo);
                btn_3.Imagen = Herramientas.WPF.Utilidades.ArchivoAImageSource(multimedia);
                btn_4.Imagen = Herramientas.WPF.Utilidades.ArchivoAImageSource(izquierda);
                btn_5.Imagen = Herramientas.WPF.Utilidades.ArchivoAImageSource(seleccionar);
                btn_6.Imagen = Herramientas.WPF.Utilidades.ArchivoAImageSource(derecha);
                btn_7.Imagen = Herramientas.WPF.Utilidades.ArchivoAImageSource(categorias);
                btn_8.Imagen = Herramientas.WPF.Utilidades.ArchivoAImageSource(arriba);
                btn_9.Imagen = Herramientas.WPF.Utilidades.ArchivoAImageSource(playList);

                btn_1.Indice = "teclado";
                btn_2.Indice = "abajo";
                btn_3.Indice = "multimedia";
                btn_4.Indice = "izquierda";
                btn_5.Indice = "seleccionar";
                btn_6.Indice = "derecha";
                btn_7.Indice = "categorias";
                btn_8.Indice = "arriba";
                btn_9.Indice = "playList";
            }
            else if (modalidad == ModalidadTeclado.PlayList)
            {
                btn_1.Imagen = Herramientas.WPF.Utilidades.ArchivoAImageSource(fondo);
                btn_2.Imagen = Herramientas.WPF.Utilidades.ArchivoAImageSource(abajo);
                btn_3.Imagen = Herramientas.WPF.Utilidades.ArchivoAImageSource(borrar);
                btn_4.Imagen = Herramientas.WPF.Utilidades.ArchivoAImageSource(fondo);
                btn_5.Imagen = Herramientas.WPF.Utilidades.ArchivoAImageSource(seleccionar);
                btn_6.Imagen = Herramientas.WPF.Utilidades.ArchivoAImageSource(fondo);
                btn_7.Imagen = Herramientas.WPF.Utilidades.ArchivoAImageSource(fondo);
                btn_8.Imagen = Herramientas.WPF.Utilidades.ArchivoAImageSource(arriba);
                btn_9.Imagen = Herramientas.WPF.Utilidades.ArchivoAImageSource(playList);

                btn_1.Indice = "";
                btn_2.Indice = "abajo";
                btn_3.Indice = "borrar";
                btn_4.Indice = "";
                btn_5.Indice = "seleccionar";
                btn_6.Indice = "";
                btn_7.Indice = "";
                btn_8.Indice = "arriba";
                btn_9.Indice = "playList";
            }
            else if (modalidad == ModalidadTeclado.Reproductor)
            {
                btn_1.Imagen = Herramientas.WPF.Utilidades.ArchivoAImageSource(fondo);
                btn_2.Imagen = Herramientas.WPF.Utilidades.ArchivoAImageSource(fondo);
                btn_3.Imagen = Herramientas.WPF.Utilidades.ArchivoAImageSource(multimedia);
                btn_4.Imagen = Herramientas.WPF.Utilidades.ArchivoAImageSource(play);
                btn_5.Imagen = Herramientas.WPF.Utilidades.ArchivoAImageSource(pausa);
                btn_6.Imagen = Herramientas.WPF.Utilidades.ArchivoAImageSource(adelantar);
                btn_7.Imagen = Herramientas.WPF.Utilidades.ArchivoAImageSource(fondo);
                btn_8.Imagen = Herramientas.WPF.Utilidades.ArchivoAImageSource(fondo);
                btn_9.Imagen = Herramientas.WPF.Utilidades.ArchivoAImageSource(fondo);

                btn_1.Indice = "";
                btn_2.Indice = "";
                btn_3.Indice = "multimedia";
                btn_4.Indice = "play";
                btn_5.Indice = "pausa";
                btn_6.Indice = "adelantar";
                btn_7.Indice = "";
                btn_8.Indice = "";
                btn_9.Indice = "";
            }
            else if (modalidad == ModalidadTeclado.Categorias)
            {
                btn_1.Imagen = Herramientas.WPF.Utilidades.ArchivoAImageSource(fondo);
                btn_2.Imagen = Herramientas.WPF.Utilidades.ArchivoAImageSource(abajo);
                btn_3.Imagen = Herramientas.WPF.Utilidades.ArchivoAImageSource(fondo);
                btn_4.Imagen = Herramientas.WPF.Utilidades.ArchivoAImageSource(fondo);
                btn_5.Imagen = Herramientas.WPF.Utilidades.ArchivoAImageSource(seleccionar);
                btn_6.Imagen = Herramientas.WPF.Utilidades.ArchivoAImageSource(fondo);
                btn_7.Imagen = Herramientas.WPF.Utilidades.ArchivoAImageSource(categorias);
                btn_8.Imagen = Herramientas.WPF.Utilidades.ArchivoAImageSource(arriba);
                btn_9.Imagen = Herramientas.WPF.Utilidades.ArchivoAImageSource(fondo);

                btn_1.Indice = "";
                btn_2.Indice = "abajo";
                btn_3.Indice = "";
                btn_4.Indice = "";
                btn_5.Indice = "seleccionar";
                btn_6.Indice = "";
                btn_7.Indice = "categorias";
                btn_8.Indice = "arriba";
                btn_9.Indice = "";
            }
            else if (modalidad == ModalidadTeclado.Teclado)
            {
                btn_1.Imagen = Herramientas.WPF.Utilidades.ArchivoAImageSource(teclado);
                btn_2.Imagen = Herramientas.WPF.Utilidades.ArchivoAImageSource(borrarLetra);
                btn_3.Imagen = Herramientas.WPF.Utilidades.ArchivoAImageSource(enter);
                btn_4.Imagen = Herramientas.WPF.Utilidades.ArchivoAImageSource(izquierda);
                //
                btn_5.Imagen = Herramientas.WPF.Utilidades.ArchivoAImageSource(fondo);
                btn_5.SetLetra('A');
                LetraActual = 'A';
                //
                btn_6.Imagen = Herramientas.WPF.Utilidades.ArchivoAImageSource(derecha);
                btn_7.Imagen = Herramientas.WPF.Utilidades.ArchivoAImageSource(borrarTodo);
                btn_8.Imagen = Herramientas.WPF.Utilidades.ArchivoAImageSource(fondo);
                btn_9.Imagen = Herramientas.WPF.Utilidades.ArchivoAImageSource(espacioBlanco);

                btn_1.Indice = "teclado";
                btn_2.Indice = "borrarLetra";
                btn_3.Indice = "enter";
                btn_4.Indice = "izquierda";
                btn_5.Indice = "letra";
                btn_6.Indice = "derecha";
                btn_7.Indice = "borrarTodo";
                btn_8.Indice = "";
                btn_9.Indice = "espacioBlanco";
            }
        }
        List<char> letrasUsadas = new List<char>() { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'Ñ', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public char LetraActual { get; set; }
        public void LetraAnterior()
        {
            int indiceLetra = letrasUsadas.IndexOf(btn_5.LetraActual);

            if (indiceLetra > 0)
            {
                indiceLetra--;
                char letra = (char)letrasUsadas[indiceLetra];
                LetraActual = letra;
                btn_5.SetLetra(letra);
            }
        }
        public void SiguienteLetra()
        {
            int indiceLetra = letrasUsadas.IndexOf(btn_5.LetraActual);

            if (indiceLetra < letrasUsadas.Count - 1)
            {
                indiceLetra++;
                char letra = (char)letrasUsadas[indiceLetra];
                LetraActual = letra;
                btn_5.SetLetra(letra);
            }

        }
    }
}
