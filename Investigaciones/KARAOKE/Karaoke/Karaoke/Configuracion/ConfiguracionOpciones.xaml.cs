using Herramientas.Archivos;
using Herramientas.Forms;
using Herramientas.WPF;
using Karaoke.Clases;
using Karaoke.Controles;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
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
using System.Windows.Threading;

namespace Karaoke.Configuracion
{
    /// <summary>
    /// Lógica de interacción para Configuracion.xaml
    /// </summary>
    public partial class ConfiguracionOpciones : Window
    {
        IdentificadorLicencia lic = null;
        List<String> teclas = new List<string>();
        public ConfiguracionOpciones()
        {
            InitializeComponent();
            controlesTouch.click += controlesTouch_click;
            if (Principal.InstanciaEstatica != null)
                WindowStyle = Principal.InstanciaEstatica.WindowStyle;
            try
            {
                CargarCarpetasKaraoke();
                CargarCarpetasMusica();
                CargarCarpetasVideos();

                for (int i = 0; i < 9; i++)
                    teclas.Add("");
                Variable var = Compartidos.ObtenerVariablesConfiguracion();
                var.LeerArchivo();
                String r = var.ObtenerValorVariable<String>("AutoActualizarContenido");

                if (r != null && r.ToLower().Equals("si"))
                {
                    chb_actualizacionAutomatica.IsChecked = true;
                }
                else
                    chb_actualizacionAutomatica.IsChecked = false;

                String pantComp = var.ObtenerValorVariable<String>("IniciarEnPantallaCompleta");
                if (pantComp != null && pantComp.ToLower().Equals("si"))
                {
                    chb_iniciarPantallaCompleto.IsChecked = true;
                }
                else
                    chb_iniciarPantallaCompleto.IsChecked = false;

                //String descargarContenidoYT = var.ObtenerValorVariable<String>("DescargarContenidoYoutube");
                //if (descargarContenidoYT != null && descargarContenidoYT.ToLower().Equals("si"))
                //{
                //    chb_descargarYoutube.IsChecked = true;
                //}
                //else
                //    chb_descargarYoutube.IsChecked = false;

                //----------------
                String usarPreparacionKaraoke = var.ObtenerValorVariable<String>("UsarPreparacionKaraoke");
                if (usarPreparacionKaraoke != null && usarPreparacionKaraoke.ToLower().Equals("si"))
                {
                    chb_usarPreparacionKaraoke.IsChecked = true;
                }
                else
                    chb_usarPreparacionKaraoke.IsChecked = false;
                //-------------

                //txt_carpetaYoutube.Text = var.ObtenerValorVariable<String>("RutaGuardadoYoutube");

                CargarTeclas();
                ActualizarTeclasPantalla();

                cmb_segundos.Items.Add("5 segundos");
                cmb_segundos.Items.Add("10 segundos");
                cmb_segundos.Items.Add("15 segundos");
                cmb_segundos.Items.Add("20 segundos");
                cmb_segundos.Items.Add("25 segundos");

                cmb_segundos.SelectedItem = var.ObtenerValorVariable<String>("SegundosFullScreenReproductor") + " segundos";
                for (int i = 1; i <= 5; i++)
                    cmb_filasInterfaz.Items.Add(i);
                for (int i = 3; i <= 8; i++)
                    cmb_columnasInterfaz.Items.Add(i);
                //-----------------

                cmb_filasInterfaz.SelectedItem = var.ObtenerValorVariable<int>("FilasInterfaz");
                cmb_columnasInterfaz.SelectedItem = var.ObtenerValorVariable<int>("ColumnasInterfaz");

                cmb_segundosPreparación.Items.Add("3 segundos");
                cmb_segundosPreparación.Items.Add("5 segundos");
                cmb_segundosPreparación.Items.Add("8 segundos");
                cmb_segundosPreparación.Items.Add("10 segundos");
                cmb_segundosPreparación.Items.Add("15 segundos");

                cmb_segundosPreparación.SelectedItem = var.ObtenerValorVariable<String>("SegundosPreparacionKaraoke") + " segundos";

                controlesTouch.VisibleTextBox = false;

                String teclaMoneda = var.ObtenerValorVariable<String>("TeclaMoneda");
                btn_teclaMoneda.Content = teclaMoneda;
                btn_teclaMoneda.Click += btn_teclaMoneda_Click;


                String usarModoCreditos = var.ObtenerValorVariable<String>("UsarModoCreditos");
                if (usarModoCreditos != null && usarModoCreditos.ToLower().Equals("si"))
                {
                    chb_usarModoCreditos.IsChecked = true;
                }
                else
                    chb_usarModoCreditos.IsChecked = false;
                
                String habilitarAleatorio = var.ObtenerValorVariable<String>("HabilitarAleatorio");
                if (habilitarAleatorio != null && habilitarAleatorio.ToLower().Equals("si"))
                {
                    chb_habilitarAleatorio.IsChecked = true;
                }
                else
                    chb_habilitarAleatorio.IsChecked = false;
                String iniciarAutomaticamente = var.ObtenerValorVariable<String>("IniciarAutomaticamente");
                if (iniciarAutomaticamente != null && iniciarAutomaticamente.ToLower().Equals("si"))
                {
                    chb_inciiarAutomaticamente.IsChecked = true;
                }
                else
                    chb_inciiarAutomaticamente.IsChecked = false;

                var.GuardarValorVariable("MensajeModoCreditoMoneda", txt_mensajeMonedas.Text);

                txt_mensajeMonedas.Text = Compartidos.ObtenerVariablesConfiguracion().ObtenerValorVariable<String>("MensajeModoCreditoMoneda");

                for (int i = 1; i <=10; i++)
                    cmb_pulsaciones.Items.Add(i);

                cmb_pulsaciones.SelectedItem = var.ObtenerValorVariable<int>("PulsacionesMonedas");

                txt_mensajePromocion.Text = Compartidos.ObtenerVariablesConfiguracion().ObtenerValorVariable<String>("MensajeNegocio");
                String logoS = Compartidos.ObtenerVariablesConfiguracion().ObtenerValorVariable<String>("LogotipoNegocio");
                if (logoS != null && !logoS.Equals(""))
                    img_logotipo.Source = Herramientas.WPF.Convertir.BitmapToImageSource(Herramientas.Archivos.Imagenes.StringBase64ABitmap(logoS));


                txt_codigoUnicoLicencia.Text = Principal.Licencia();

                String decifrado = Herramientas.Cifrado.CifradoAES.DesencriptarTexto(txt_codigoUnicoLicencia.Text);
                lic = Herramientas.Web.JSON.ConvertirJSONAObjeto<IdentificadorLicencia>(decifrado);

                cmb_pistasAleatorias.Items.Add(1);
                cmb_pistasAleatorias.Items.Add(2);
                cmb_pistasAleatorias.Items.Add(3);
                cmb_pistasAleatorias.Items.Add(4);                
                cmb_pistasAleatorias.Items.Add(5);
                cmb_pistasAleatorias.Items.Add(10);
                cmb_pistasAleatorias.Items.Add(15);
                cmb_pistasAleatorias.Items.Add(20);
                cmb_pistasAleatorias.Items.Add(25);
                cmb_pistasAleatorias.Items.Add(30);
                cmb_pistasAleatorias.Items.Add(35);
                cmb_pistasAleatorias.Items.Add(40);
                cmb_pistasAleatorias.Items.Add(45);
                cmb_pistasAleatorias.Items.Add(50);

                cmb_pistasAleatorias.SelectedItem = var.ObtenerValorVariable<int>("PistasAleatorias");

                if (lic.FechaFIN == DateTime.MinValue.AddDays(1))
                {
                    //no ha comprado licencia, esta en modo prueba
                    txt_estatusLicencia.Text = "SOLO PRUEBAS DE 15 MINUTOS";
                    txt_estatusLicencia.Background = new SolidColorBrush(Colors.Orange);
                    txt_estatusLicencia.Foreground = new SolidColorBrush(Colors.Black);
                }
                else
                {
                    if (lic.FechaFIN < DateTime.Now)
                    {
                        txt_estatusLicencia.Text = "LICENCIA VENCIDA";
                        txt_estatusLicencia.Background = new SolidColorBrush(Colors.Red);
                        txt_estatusLicencia.Foreground = new SolidColorBrush(Colors.White);
                    }
                    else
                    {
                        txt_estatusLicencia.Text = "VIGENTE HASTA " + Herramientas.Conversiones.Formatos.DateTimeAFechaCortaConMesTexto(lic.FechaFIN);
                        txt_estatusLicencia.Background = new SolidColorBrush(Colors.Green);
                        txt_estatusLicencia.Foreground = new SolidColorBrush(Colors.White);
                    }
                }

            }
            catch { }
        }

        void btn_teclaMoneda_Click(object sender, RoutedEventArgs e)
        {
            SeleccionarTecla sel = new SeleccionarTecla();
            sel.ShowDialog();
            btn_teclaMoneda.Content = sel.TeclaSeleccionada.ToString();
            sel.Close();
            //ActualizarTeclasPantalla();
        }
        private void ActualizarTeclasPantalla()
        {
            controlesTouch.btn_1.Etiqueta = teclas[0];
            controlesTouch.btn_2.Etiqueta = teclas[1];
            controlesTouch.btn_3.Etiqueta = teclas[2];
            controlesTouch.btn_4.Etiqueta = teclas[3];
            controlesTouch.btn_5.Etiqueta = teclas[4];
            controlesTouch.btn_6.Etiqueta = teclas[5];
            controlesTouch.btn_7.Etiqueta = teclas[6];
            controlesTouch.btn_8.Etiqueta = teclas[7];
            controlesTouch.btn_9.Etiqueta = teclas[8];
        }
        private void CargarTeclas()
        {
            Variable var = Compartidos.ObtenerVariablesConfiguracion();
            var.LeerArchivo();
            teclas.Clear();
            for (int i = 1; i <= 9; i++)
            {
                try
                {
                    String valor = var.ObtenerValorVariable<String>("TECLA_" + i);
                    KeyConverter k = new KeyConverter();
                    Key mykey = Key.Zoom;
                    if (valor != null && valor.Trim().Equals(""))
                    {
                        mykey = (Key)k.ConvertFromString("NumPad" + i);
                    }
                    else
                    {
                        mykey = (Key)k.ConvertFromString(valor);
                    }
                    teclas.Add(mykey.ToString());
                }
                catch { }
            }
        }
        private void CargarCarpetasKaraoke()
        {
            Variable var = Compartidos.ObtenerVariablesConfiguracion();
            int totalCVideos = var.ObtenerValorVariable<int>("KARAOKE_CARPETAS");
            for (int i = 0; i < totalCVideos; i++)
                lb_karaokeLista.Items.Add(var.ObtenerValorVariable<String>("KARAOKE_CARPETAS_" + i));
        }
        private void CargarCarpetasMusica()
        {
            Variable var = Compartidos.ObtenerVariablesConfiguracion();
            int totalCVideos = var.ObtenerValorVariable<int>("MUSICA_CARPETAS");
            for (int i = 0; i < totalCVideos; i++)
                lb_musicaLista.Items.Add(var.ObtenerValorVariable<String>("MUSICA_CARPETAS_" + i));
        }
        private void CargarCarpetasVideos()
        {
            Variable var = Compartidos.ObtenerVariablesConfiguracion();
            int totalCVideos = var.ObtenerValorVariable<int>("VIDEOS_CARPETAS");
            for (int i = 0; i < totalCVideos; i++)
                lb_videosLista.Items.Add(var.ObtenerValorVariable<String>("VIDEOS_CARPETAS_" + i));
        }
        private void btn_AccesosGuardar_Click(object sender, RoutedEventArgs e)
        {
            Variable var = Compartidos.ObtenerVariablesConfiguracion();
            int indice = 1;
            foreach (String tecla in teclas)
            {
                var.GuardarValorVariable("TECLA_" + indice, tecla);
                indice++;
            }
            var.ActualizarArchivo();
            Mensajes.Informacion("Se ha guardado la nueva configuracion de teclas con éxito.");
        }
        void controlesTouch_click(BotonTouch boton)
        {
            SeleccionarTecla sel = new SeleccionarTecla();
            sel.ShowDialog();
            teclas[Convert.ToInt32(boton.Tag) - 1] = sel.TeclaSeleccionada.ToString();
            sel.Close();
            //ActualizarTeclasPantalla();
            boton.Etiqueta = sel.TeclaSeleccionada.ToString();
        }

        private void btn_karaokeBuscar_Click(object sender, RoutedEventArgs e)
        {
            txt_karaokeCarpeta.Text = Herramientas.Archivos.Dialogos.BuscarCarpeta(null);
        }

        private void btn_karaokeAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (txt_karaokeCarpeta.Text.Trim().Equals(""))
            {
                Mensajes.Informacion("Elija una carpeta a agregar.");
                return;
            }
            String formato = "K=" + txt_karaokeCarpeta.Text.Trim();
            if ((Boolean)chb_karaokeIncluir.IsChecked)
                formato += " (Incluir subcarpetas)";
            if (!txt_karaokeGrupo.Text.Trim().Equals(""))
                formato += " | " + txt_karaokeGrupo.Text.Trim();
            lb_karaokeLista.Items.Add(formato);

            chb_karaokeIncluir.IsChecked = false;
            txt_karaokeCarpeta.Text = "";
            txt_karaokeGrupo.Text = "";
        }

        private void btn_karaokeEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (lb_karaokeLista.SelectedItem != null)
                lb_karaokeLista.Items.Remove(lb_karaokeLista.SelectedItem);
        }

        private void btn_musicaBuscar_Click(object sender, RoutedEventArgs e)
        {
            txt_musicaCarpeta.Text = Herramientas.Archivos.Dialogos.BuscarCarpeta(null);
        }

        private void btn_musicaAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (txt_musicaCarpeta.Text.Trim().Equals(""))
            {
                Mensajes.Informacion("Elija una carpeta a agregar.");
                return;
            }
            String formato = "M=" + txt_musicaCarpeta.Text.Trim();
            if ((Boolean)chb_musicaIncluir.IsChecked)
                formato += " (Incluir subcarpetas)";
            if (!txt_musicaGrupo.Text.Trim().Equals(""))
                formato += " | " + txt_musicaGrupo.Text.Trim();
            lb_musicaLista.Items.Add(formato);

            chb_musicaIncluir.IsChecked = false;
            txt_musicaCarpeta.Text = "";
            txt_musicaGrupo.Text = "";
        }

        private void btn_musicaEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (lb_musicaLista.SelectedItem != null)
                lb_musicaLista.Items.Remove(lb_musicaLista.SelectedItem);
        }

        private void btn_videosBuscar_Click(object sender, RoutedEventArgs e)
        {
            txt_videosCarpeta.Text = Herramientas.Archivos.Dialogos.BuscarCarpeta(null);
        }

        private void btn_videosAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (txt_videosCarpeta.Text.Trim().Equals(""))
            {
                Mensajes.Informacion("Elija una carpeta a agregar.");
                return;
            }
            String formato = "V=" + txt_videosCarpeta.Text.Trim();
            if ((Boolean)chb_videosIncluir.IsChecked)
                formato += " (Incluir subcarpetas)";
            if (!txt_videosGrupo.Text.Trim().Equals(""))
                formato += " | " + txt_videosGrupo.Text.Trim();

            lb_videosLista.Items.Add(formato);

            chb_videosIncluir.IsChecked = false;
            txt_videosCarpeta.Text = "";
            txt_videosGrupo.Text = "";
        }

        private void btn_videosEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (lb_videosLista.SelectedItem != null)
                lb_videosLista.Items.Remove(lb_videosLista.SelectedItem);
        }

        private void btn_videosGuardar_Click(object sender, RoutedEventArgs e)
        {
            Variable var = Compartidos.ObtenerVariablesConfiguracion();

            var.GuardarValorVariable("VIDEOS_CARPETAS", lb_videosLista.Items.Count.ToString());
            int indice = 0;
            foreach (String elemento in lb_videosLista.Items)
            {
                var.GuardarValorVariable("VIDEOS_CARPETAS_" + indice, elemento);
                indice++;
            }
            var.ActualizarArchivo();
            Mensajes.Informacion("Se han guardado los elementos con éxito. NO OLVIDES GENERAR NUEVAMENTE EL CONTENIDO DESPUES DE UNA MODIFICACION.");
        }

        private void btn_musicaGuardar_Click(object sender, RoutedEventArgs e)
        {
            Variable var = Compartidos.ObtenerVariablesConfiguracion();

            var.GuardarValorVariable("MUSICA_CARPETAS", lb_musicaLista.Items.Count.ToString());
            int indice = 0;
            foreach (String elemento in lb_musicaLista.Items)
            {
                var.GuardarValorVariable("MUSICA_CARPETAS_" + indice, elemento);
                indice++;
            }
            var.ActualizarArchivo();
            Mensajes.Informacion("Se han guardado los elementos con éxito. NO OLVIDES GENERAR NUEVAMENTE EL CONTENIDO DESPUES DE UNA MODIFICACION.");
        }

        private void btn_karaokeGuardar_Click(object sender, RoutedEventArgs e)
        {
            Variable var = Compartidos.ObtenerVariablesConfiguracion();

            var.GuardarValorVariable("KARAOKE_CARPETAS", lb_karaokeLista.Items.Count.ToString());
            int indice = 0;
            foreach (String elemento in lb_karaokeLista.Items)
            {
                var.GuardarValorVariable("KARAOKE_CARPETAS_" + indice, elemento);
                indice++;
            }
            var.ActualizarArchivo();
            Mensajes.Informacion("Se han guardado los elementos con éxito. NO OLVIDES GENERAR NUEVAMENTE EL CONTENIDO DESPUES DE UNA MODIFICACION.");
        }

        private void MostrarPorcentaje(double porcentaje)
        {
        }

        private void MostrarMensaje(String mensaje)
        {
            Dispatcher.Invoke(new Action(() =>
            {
                txt_generando.Text = mensaje;
            }));
        }

        private void btn_iniciarGeneracion_Click(object sender, RoutedEventArgs e)
        {
            ProcesoArchivos proceso = new ProcesoArchivos();
            proceso.mostrarMensaje += proceso_mostrarMensaje;
            proceso.mostrarPorcentaje += proceso_mostrarPorcentaje;
            proceso.terminoCargado += proceso_terminoCargado;

            Thread t = new Thread(proceso.ProcesoPrincipalMain);
            t.Start();
        }

        void proceso_terminoCargado()
        {
            Dispatcher.Invoke(new Action(() =>
            {
                Mensajes.Informacion("Generación terminada con éxito, por favor reinicia el programa para verificar los cambios.");
            }));
        }

        void proceso_mostrarPorcentaje(double porcentaje)
        {
            Dispatcher.Invoke(new Action(() =>
            {
                pb_progreso.Value = porcentaje;
            }));
        }

        void proceso_mostrarMensaje(string mensaje)
        {
            Dispatcher.Invoke(new Action(() =>
            {
                txt_generando.Text = mensaje;
            }));
        }

        private void chb_actualizacionAutomatica_Checked(object sender, RoutedEventArgs e)
        {
            Variable var = Compartidos.ObtenerVariablesConfiguracion();
            var.LeerArchivo();
            var.GuardarValorVariable("AutoActualizarContenido", "si");
            var.ActualizarArchivo();
        }

        private void chb_actualizacionAutomatica_Unchecked(object sender, RoutedEventArgs e)
        {
            Variable var = Compartidos.ObtenerVariablesConfiguracion();
            var.LeerArchivo();
            var.GuardarValorVariable("AutoActualizarContenido", "no");
            var.ActualizarArchivo();
        }

        private void chb_iniciarPantallaCompleto_Checked(object sender, RoutedEventArgs e)
        {
            Variable var = Compartidos.ObtenerVariablesConfiguracion();
            var.LeerArchivo();
            var.GuardarValorVariable("IniciarEnPantallaCompleta", "si");
            var.ActualizarArchivo();
        }

        private void chb_iniciarPantallaCompleto_Unchecked(object sender, RoutedEventArgs e)
        {
            Variable var = Compartidos.ObtenerVariablesConfiguracion();
            var.LeerArchivo();
            var.GuardarValorVariable("IniciarEnPantallaCompleta", "no");
            var.ActualizarArchivo();
        }

        private void btn_guardarOpcionesInterfazGrafica_Click(object sender, RoutedEventArgs e)
        {
            object segundos = cmb_segundos.SelectedItem;
            if (segundos != null)
            {
                String numero = segundos.ToString().Replace(" segundos", "");
                Variable var = Compartidos.ObtenerVariablesConfiguracion();
                var.LeerArchivo();
                var.GuardarValorVariable("SegundosFullScreenReproductor", numero);
                var.GuardarValorVariable("FilasInterfaz", cmb_filasInterfaz.SelectedItem.ToString());
                var.GuardarValorVariable("ColumnasInterfaz", cmb_columnasInterfaz.SelectedItem.ToString());
                var.GuardarValorVariable("MensajeNegocio", txt_mensajePromocion.Text);
                var.ActualizarArchivo();
            }
            Mensajes.Informacion("Guardado correctamente.");
        }

        private void chb_descargarYoutube_Checked(object sender, RoutedEventArgs e)
        {
            Variable var = Compartidos.ObtenerVariablesConfiguracion();
            var.LeerArchivo();
            var.GuardarValorVariable("DescargarContenidoYoutube", "si");
            var.ActualizarArchivo();
        }

        private void chb_descargarYoutube_Unchecked(object sender, RoutedEventArgs e)
        {
            Variable var = Compartidos.ObtenerVariablesConfiguracion();
            var.LeerArchivo();
            var.GuardarValorVariable("DescargarContenidoYoutube", "no");
            var.ActualizarArchivo();
        }

        private void btn_guardarYoutube_Click(object sender, RoutedEventArgs e)
        {
            Variable var = Compartidos.ObtenerVariablesConfiguracion();
            var.LeerArchivo();
            //var.GuardarValorVariable("RutaGuardadoYoutube", txt_carpetaYoutube.Text);
            var.ActualizarArchivo();

            Mensajes.Informacion("Guardado exitoso");
        }

        private void btn_cerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btn_buscarYoutube_Click(object sender, RoutedEventArgs e)
        {
            //txt_carpetaYoutube.Text = Herramientas.WPF.Utilidades.BuscarCarpeta();
        }

        private void btn_guardarPreparacion_Click(object sender, RoutedEventArgs e)
        {
            object segundos = cmb_segundosPreparación.SelectedItem;
            if (segundos != null)
            {
                String numero = segundos.ToString().Replace(" segundos", "");
                Variable var = Compartidos.ObtenerVariablesConfiguracion();
                var.LeerArchivo();
                var.GuardarValorVariable("SegundosPreparacionKaraoke", numero);
                var.ActualizarArchivo();
            }
            Mensajes.Informacion("Guardado correctamente.");
        }

        private void chb_usarPreparacionKaraoke_Checked(object sender, RoutedEventArgs e)
        {
            Variable var = Compartidos.ObtenerVariablesConfiguracion();
            var.LeerArchivo();
            var.GuardarValorVariable("UsarPreparacionKaraoke", "si");
            var.ActualizarArchivo();
        }

        private void chb_usarPreparacionKaraoke_Unchecked(object sender, RoutedEventArgs e)
        {
            Variable var = Compartidos.ObtenerVariablesConfiguracion();
            var.LeerArchivo();
            var.GuardarValorVariable("UsarPreparacionKaraoke", "no");
            var.ActualizarArchivo();
        }

        private void btn_guardarModoCreditos_Click(object sender, RoutedEventArgs e)
        {
            Variable var = Compartidos.ObtenerVariablesConfiguracion();
            var.LeerArchivo();
            var.GuardarValorVariable("TeclaMoneda", btn_teclaMoneda.Content.ToString());
            String valor = "no";
            if ((Boolean)chb_usarModoCreditos.IsChecked)
            {
                valor = "si";
            }
            var.GuardarValorVariable("UsarModoCreditos", valor);
            var.GuardarValorVariable("MensajeModoCreditoMoneda", txt_mensajeMonedas.Text);
            var.GuardarValorVariable("PulsacionesMonedas", cmb_pulsaciones.SelectedItem.ToString());
            var.ActualizarArchivo();

            Mensajes.Informacion("Guardado correctamente.");

        }

        private void btn_copiarKey_Click(object sender, RoutedEventArgs e)
        {
            String carpeta = Herramientas.Archivos.Dialogos.BuscarCarpeta(null);

            if (carpeta != null)
            {
                carpeta += "\\" + Herramientas.Sys.PCInfo.ObtenerMarca() + " " + Herramientas.Sys.PCInfo.ObtenerModelo() + " - " + Environment.MachineName + ".key";
                Herramientas.Archivos.Archivo.GuardarArchivoDeTexto(carpeta, txt_codigoUnicoLicencia.Text);
                Herramientas.Forms.Mensajes.Informacion("Exportada archivo KEY en: " + carpeta + ".");
            }

            Clipboard.SetDataObject(txt_codigoUnicoLicencia.Text);
            Herramientas.Forms.Mensajes.Informacion("Código copiado al portapapeles con éxito.");
        }

        private void btn_buscarLicencia_Click(object sender, RoutedEventArgs e)
        {
            String archivo = Herramientas.Archivos.Dialogos.BuscarArchivo(new List<string>() { "Archivo Licencia" }, new List<string>() { "karalicence" });

            if (archivo != null && !archivo.Equals(""))
            {
                String cifrado = Herramientas.Archivos.Archivo.LeerArchivoTexto(archivo);
                String decifrado = Herramientas.Cifrado.CifradoAES.DesencriptarTexto(cifrado);
                IdentificadorLicencia lic2 = Herramientas.Web.JSON.ConvertirJSONAObjeto<IdentificadorLicencia>(decifrado);

                if (lic2.IDLicencia == lic.IDLicencia && lic2.IDTarjetaMADRE == lic.IDTarjetaMADRE
                    && lic2.MAC == lic.MAC)
                {
                    if (DateTime.Now < lic2.FechaPago)
                    {
                        Herramientas.Forms.Mensajes.Advertencia("La fecha del equipo es incorrecta, ajusta la fecha para aplicar la licencia.");
                        return;
                    }

                    lic.FechaFIN = lic2.FechaFIN;
                    lic.FechaPago = lic2.FechaPago;

                    String json = Herramientas.Web.JSON.ConvertirObjetoAJSON<IdentificadorLicencia>(lic);
                    String cifrado2 = Herramientas.Cifrado.CifradoAES.EncriptarTexto(json);

                    Herramientas.Archivos.Archivo.GuardarArchivoDeTexto(Environment.CurrentDirectory + "\\log5net.dll", cifrado2);

                    Herramientas.Forms.Mensajes.Informacion("Licencia aplicada correctamente, reinicia el programa para verificar los cambios.");

                }
                else
                {
                    Herramientas.Forms.Mensajes.Exclamacion("La licencia que desea aplicar no corresponde a este equipo.");
                }
            }
        }

        private void btn_agregarLogotipo_Click(object sender, RoutedEventArgs e)
        {
            String ruta = Herramientas.Archivos.Dialogos.BuscarArchivoDeImagen();
            Variable var = Compartidos.ObtenerVariablesConfiguracion();
            var.LeerArchivo();
            if (ruta != null && !ruta.Equals(""))
            {
                Bitmap logo = new Bitmap(ruta);
                var.GuardarValorVariable("LogotipoNegocio", Herramientas.Archivos.Imagenes.BitmapAStringBase64(logo));
                img_logotipo.Source = Herramientas.WPF.Convertir.BitmapToImageSource(logo);
            }

            var.ActualizarArchivo();


        }

        private void btn_guardarMasPopularesAleatorios_Click(object sender, RoutedEventArgs e)
        {
            Variable var = Compartidos.ObtenerVariablesConfiguracion();
            var.LeerArchivo();
            if(cmb_pistasAleatorias.SelectedIndex >= 0)
            {
                var.GuardarValorVariable("PistasAleatorias", cmb_pistasAleatorias.SelectedItem.ToString());
            }
            String valor = "no";
            if ((Boolean)chb_habilitarAleatorio.IsChecked)
            {
                valor = "si";
            }
            var.GuardarValorVariable("HabilitarAleatorio", valor);
            var.ActualizarArchivo();

            Mensajes.Informacion("Guardado correctamente.");
        }

        private void btn_borrarHistorialMasPopulares_Click(object sender, RoutedEventArgs e)
        {
            if (Herramientas.Forms.Mensajes.PreguntaAdvertenciaSIoNO("Si inicia el proceso de borrado de historial no podrá revertirlo, ¿Desea continuar?"))
            {
                Variable vm = Compartidos.ObtenerVariablesTopMusica();
                vm.BorrarVariables();
                vm.ActualizarArchivo();
                Variable vv = Compartidos.ObtenerVariablesTopVideos();
                vv.BorrarVariables();
                vv.ActualizarArchivo();
                Variable vk = Compartidos.ObtenerVariablesTopKaraoke();
                vk.BorrarVariables();
                vk.ActualizarArchivo();
                Mensajes.Informacion("Guardado correctamente.");
            }
        }
        private void RegisterInStartup(bool isChecked)
        {
            try
            {
                RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                Variable var = Compartidos.ObtenerVariablesConfiguracion();
                var.LeerArchivo();
                if (isChecked)
                {
                    string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                    UriBuilder uri = new UriBuilder(codeBase);
                    string path = Uri.UnescapeDataString(uri.Path);
                    registryKey.SetValue("ClienteSoporte", path);
                    var.GuardarValorVariable("IniciarAutomaticamente","si");
                }
                else
                {
                    registryKey.DeleteValue("ClienteSoporte");
                    var.GuardarValorVariable("IniciarAutomaticamente", "no");
                }
                var.ActualizarArchivo();
                //Mensajes.Informacion("Guardado correctamente.");
            }
            catch
            {
                //Mensajes.Error("Error al guardar la configuración.");
            }
        }
        private void chb_inciiarAutomaticamente_Checked(object sender, RoutedEventArgs e)
        {
            RegisterInStartup(true);
        }

        private void chb_inciiarAutomaticamente_Unchecked(object sender, RoutedEventArgs e)
        {
            RegisterInStartup(false);
        }
    }
}
