using Dominio;
using System;
using System.Collections.Generic;
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
using InterfazWPF.AdministracionSistema;
using System.Reflection;
using Dominio.Sistema;
using Herramientas.ORM;

namespace InterfazWPF
{
    /// <summary>
    /// Lógica de interacción para TextboxBusquedaCatalogo.xaml
    /// </summary>
    public partial class TextboxBusquedaCatalogo : UserControl
    {
        ManejadorDB manejador;

        public delegate void MostrarResultado(List<ObjetoBase> listaObjetos);
        public event MostrarResultado mostrarResultado;
        Storyboard popupOcultar;
        Storyboard popupMostrar;
        Storyboard SobreBoton;
        Storyboard SalirBoton;

        Type tipoObjetoCatalogo;
        //Boolean AceptaMultipleSeleccion;
        //Boolean AceptaBusquedaDeshabilitados;
        String campoBusquedaDefault;
        //Type tipoObjetoBusqueda;

        Boolean seConfiguroBuscador;
        Boolean seConfiguroCampos;
        String campoEtiqueta;
        String Query;


        String rutaCatalogo;
        Boolean estaAutorizado;

        Boolean aceptaMultipleSeleccion;
        Boolean aceptaBusquedaDeshabilitados;
        List<String> camposConAlias = new List<string>();

        BuscadorCatalogoVentana buscadorCatalogoPopup;// = new BuscadorCatalogoVentana();

        


        //private static int IndiceSuperior = 99;

        //public String Etiqueta { set { txt_Etiqueta.Text = value; if (value.Trim().Equals("")) { if(ListaObjetos != null) ListaObjetos.Clear(); } } }
        public TextBox TextBoxInterior { get { return txt_Algo; } }
        public List<ObjetoBase> ListaObjetos { get; set; }
        public TextboxBusquedaCatalogo()
        {
            this.InitializeComponent();
            try
            {

                inicializarEventos();
                ListaObjetos = new List<ObjetoBase>();
                _sis_Usuario usuarioActual = HerramientasWindow.ObtenerUsuarioLogueado();
                txt_Algo.TextChanged += txt_Algo_TextChanged;
                AccesoRapido.seCerroCatalogo += AccesoRapido_seCerroCatalogo;
                if (!usuarioActual.RolSistema.BPuedeAccederCatalogoRapido && !usuarioActual.BPuedeAccederCatalogoRapido)
                {
                    AccesoRapido.Visibility = System.Windows.Visibility.Hidden;
                    txt_Etiqueta.Margin = new Thickness(7, 0, 25, 0);
                    txt_Algo.Margin = new Thickness(7, 0, 25, 0);
                }
            }
            catch
            {

            }
        }
        public T GetObjetoAsignado<T>()
        {
            if (ListaObjetos.Count == 0)
                return default(T);
            else
            {
                return (T)Convert.ChangeType(ListaObjetos[0], typeof(T));
            }
        }
        public ObjetoBase GetObjetoAsignado()
        {
            if (ListaObjetos.Count == 0)
                return null;
            else
            {
                return ListaObjetos[0];
            }
        }
        public delegate void textChanged(object sender, TextChangedEventArgs e);
        public event textChanged TextChanged;
        void txt_Algo_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextChanged != null)
                TextChanged(sender, e);
        }

        void AccesoRapido_seCerroCatalogo()
        {
            if (mostrarResultado != null)
            {
                if (ListaObjetos != null && ListaObjetos.Count > 0)
                    mostrarResultado(ListaObjetos);
                else
                    mostrarResultado(null);
            }
        }
        public void Limpiar()
        {
            txt_Etiqueta.Text = "";
            if (ListaObjetos != null)
                ListaObjetos.Clear(); 
        }
        public void SetObjetoAsignado(ObjetoBase objeto, String etiqueta)
        {
            txt_Etiqueta.Text = etiqueta;
            if (etiqueta.Trim().Equals("") || objeto == null)
            {
                if (ListaObjetos != null)
                    ListaObjetos.Clear();
            }
            else
            {
                ListaObjetos.Clear();
                ListaObjetos.Add(objeto);
            }
        }
        public void AsignarCatalogoParaAltas(String rutaCatalogo)
        {
            this.estaAutorizado = estaAutorizado;
            this.rutaCatalogo = rutaCatalogo;

            //buscadorCatalogoPopup.AsignarCatalogoParaAltas(rutaCatalogo);
        }
        public void AsignarManejadorDB(ManejadorDB manejador)
        {
            this.manejador = manejador;
            //buscadorCatalogoPopup.AsignarManejadorDB(manejador);
        }

        public void ConfigurarBusqueda(Type tipoObjetoCatalogo, String campoBusquedaDefault, String campoEtiqueta, Boolean aceptaMultipleSeleccion, Boolean aceptaBusquedaDeshabilitados)
        {
            this.tipoObjetoCatalogo = tipoObjetoCatalogo;
            this.campoBusquedaDefault = campoBusquedaDefault;
            this.campoEtiqueta = campoEtiqueta;
            this.aceptaBusquedaDeshabilitados = aceptaBusquedaDeshabilitados;
            this.aceptaMultipleSeleccion = aceptaMultipleSeleccion;
            if (aceptaMultipleSeleccion)
            {
                AccesoRapido.Visibility = System.Windows.Visibility.Hidden;
                txt_Etiqueta.Margin = new Thickness(7, 0, 25, 0);
                txt_Algo.Margin = new Thickness(7, 0, 25, 0);
            }
            else
            {
                AccesoRapido.Configurar(this.manejador, this.rutaCatalogo);
                AccesoRapido.asignarObjetoCatalogo += AccesoRapido_asignarObjetoCatalogo;
            }
            //buscadorCatalogoPopup.ConfigurarBusqueda(tipoObjetoCatalogo, campoBusquedaDefault, campoEtiqueta, aceptaMultipleSeleccion, aceptaBusquedaDeshabilitados);
        }

        ObjetoBase AccesoRapido_asignarObjetoCatalogo()
        {
            if (ListaObjetos.Count == 1)
                return ListaObjetos[0];
            else
                return null;
        }
        public void ConfigurarBusqueda(Type tipoObjetoCatalogo, String query, Boolean aceptaMultipleSeleccion, Boolean aceptaBusquedaDeshabilitados)
        {
            this.Query = query;
            this.aceptaBusquedaDeshabilitados = aceptaBusquedaDeshabilitados;
            this.aceptaMultipleSeleccion = aceptaMultipleSeleccion;
            if (aceptaMultipleSeleccion)
            {
                AccesoRapido.Visibility = System.Windows.Visibility.Hidden;
                txt_Etiqueta.Margin = new Thickness(7, 0, 25, 0);
                txt_Algo.Margin = new Thickness(7, 0, 25, 0);
            }
            else
            {
                AccesoRapido.Configurar(this.manejador, this.rutaCatalogo);
                AccesoRapido.asignarObjetoCatalogo += AccesoRapido_asignarObjetoCatalogo;
            }
            //buscadorCatalogoPopup.ConfigurarBusqueda(tipoObjetoCatalogo, campoBusquedaDefault, campoEtiqueta, aceptaMultipleSeleccion, aceptaBusquedaDeshabilitados);
        }
        public void AgregarCampoAMostrarConAlias(String nombreCampoConAlias)
        {
            camposConAlias.Add(nombreCampoConAlias);
            //buscadorCatalogoPopup.AgregarCampoAMostrarConAlias(nombreCampoConAlias);
        }

        void txt_Etiqueta_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            txt_Etiqueta.Visibility = System.Windows.Visibility.Collapsed;
            txt_Algo.Text = "";
            txt_Algo.Focus();
        }

        //public void ConfigurarControl(ManejadorDB manejador, Type tipoObjetoABuscar, String campoBusquedaDefault, Type tipoCampoBusquedaDefault, String campoEtiqueta, Boolean AceptaMultipleSeleccion, Boolean AceptaBusquedaDeshabilitados)
        //{
        //    seConfiguroBuscador = true;
        //    this.manejador = manejador;
        //    this.tipoObjetoABuscar = tipoObjetoABuscar;
        //    this.AceptaBusquedaDeshabilitados = AceptaBusquedaDeshabilitados;
        //    this.AceptaMultipleSeleccion = AceptaMultipleSeleccion;
        //    this.campoDefault = campoBusquedaDefault;
        //    this.tipoObjetoBusqueda = tipoCampoBusquedaDefault;
        //    this.campoEtiqueta = campoEtiqueta;
        //    inicializarEventos();

        //}
        //public void AgregarCampoConAliasAMostrar(String campo)
        //{
        //    seConfiguroCampos = true;
        //    buscadorCatalogoPopup.AgregarCampoConAliasAMostrar(campo);
        //}
        private void inicializarEventos()
        {
            img_busqueda.MouseDown += img_busqueda_MouseDown;
            img_busqueda.MouseEnter += img_busqueda_MouseEnter;
            img_busqueda.MouseLeave += img_busqueda_MouseLeave;
            txt_Etiqueta.PreviewMouseDown += txt_Etiqueta_PreviewMouseDown;
            txt_Algo.LostFocus += txt_Algo_LostFocus;

            txt_Algo.KeyDown += txt_Algo_KeyDown;

            //popupOcultar = (Storyboard)this.FindResource("OcultarPopup");
            //popupMostrar = (Storyboard)this.FindResource("MostrarPopup");
            SobreBoton = (Storyboard)this.FindResource("SobreBoton");
            SalirBoton = (Storyboard)this.FindResource("SalirBoton");

            //buscadorCatalogoPopup.clickAceptar += buscadorCatalogoPopup_clickAceptar;
        }

        void buscadorCatalogoPopup_clickAceptar(List<ObjetoBase> objetosLista)
        {
            MostrarResultados(objetosLista);
        }
        public void MostrarResultados(List<ObjetoBase> listaObjetos)
        {
            if (listaObjetos == null) return;
            txt_Etiqueta.Text = "";

            if (listaObjetos.Count == 1 && !aceptaMultipleSeleccion)
            {
                FieldInfo fieldEtiqueta = listaObjetos[0].GetType().GetField(campoEtiqueta, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                object etiqueta = fieldEtiqueta.GetValue(listaObjetos[0]);
                if(etiqueta != null)
                    txt_Etiqueta.Text += etiqueta.ToString();
            }
            else
                txt_Etiqueta.Text = "*";

            //if (listaObjetos.Count > 0)
            //{
            //    FieldInfo fieldEtiqueta = listaObjetos[0].GetType().GetField(campoEtiqueta, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            //    foreach (ObjetoBase objeto in listaObjetos)
            //    {
            //        txt_Etiqueta.Text += fieldEtiqueta.GetValue(objeto).ToString() +",";
            //    }
            //    txt_Etiqueta.Text = txt_Etiqueta.Text.Substring(0, txt_Etiqueta.Text.Length - 1);
            //}
            this.ListaObjetos = listaObjetos;
            if (mostrarResultado != null)
                mostrarResultado(listaObjetos);
            MostrarEtiqueta();
        }
        void txt_Algo_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.rutaCatalogo != null)
            {
                if (manejador == null || campoBusquedaDefault.Equals("") || campoEtiqueta.Equals("") || tipoObjetoCatalogo == null)
                {
                    HerramientasWindow.MensajeErrorSimple("El buscador requiere de configuración, Verificar código.", "Error");
                    return;
                }
                if (camposConAlias.Count == 0)
                {
                    HerramientasWindow.MensajeErrorSimple("Se requiere configurar campos, Verificar código.", "Error");
                    return;
                }
                if (e.Key == Key.Enter)
                {
                    String query = "select * from " + tipoObjetoCatalogo.Name + " where  (estaDeshabilitado = 'False' or EstaDeshabilitado is null) " + obtenerCondicion();
                    List<ObjetoBase> resultados = manejador.Cargar(tipoObjetoCatalogo, query , new List<object>() { });

                    if (resultados != null && resultados.Count == 1 && !txt_Algo.Text.Trim().Equals(""))
                    {
                        MostrarResultados(resultados);

                    }
                    else
                    {
                        MostrarPopup();
                    }
                    MostrarEtiqueta();

                }
                else if (e.Key == Key.F1)
                {
                    MostrarPopup();
                }
            }
            else
            {
                if (e.Key == Key.Enter || e.Key == Key.F1)
                {
                    MostrarPopup();
                }
            }

        }
        private void MostrarEtiqueta()
        {
            txt_Etiqueta.Visibility = System.Windows.Visibility.Visible;
            txt_Etiqueta.Focus();
            txt_Algo.Text = "";
        }
        private Type obtenerTipoCampoPorNombre(String nombreCampo)
        {
            FieldInfo atributoField = tipoObjetoCatalogo.GetField(nombreCampo, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public);
            if (atributoField != null)
            {
                return atributoField.FieldType;
            }
            return null;
        }
        private String obtenerCondicion()
        {
            String condicion = "and (";
            foreach (String campoConAlias in camposConAlias)
            {
                String campo = campoConAlias.Split('|')[0].Trim();
                if (campo.Contains("."))
                    continue;
                if (obtenerTipoCampoPorNombre(campo) == typeof(String))
                {
                    condicion += " " + campo + " like '%" + txt_Algo.Text.Trim() + "%'";
                }
                if (obtenerTipoCampoPorNombre(campo) == typeof(Int32) || obtenerTipoCampoPorNombre(campo) == typeof(Int64))
                {
                    try
                    {
                        long convertido = Convert.ToInt64(txt_Algo.Text.Trim());
                        condicion += " " + campo + " = " + txt_Algo.Text.Trim() + "";
                    }
                    catch { continue; }
                }
                if (obtenerTipoCampoPorNombre(campo) == typeof(DateTime))
                {
                    try
                    {
                        DateTime date = Convert.ToDateTime(txt_Algo.Text.Trim());
                        condicion += " " + campo + " = '" + txt_Algo.Text.Trim() + "'";
                    }
                    catch { continue; }
                }
                if((obtenerTipoCampoPorNombre(campo) == null))
                    continue;
                condicion += " or ";
            }
            if (condicion.EndsWith(" or "))
                condicion = condicion.Substring(0, condicion.Length - 4);
            condicion += ")";
            if (condicion.Equals("and ()"))
                condicion = "";
            return condicion;
        }

        void txt_Algo_LostFocus(object sender, RoutedEventArgs e)
        {
            MostrarEtiqueta();
        }

        private Boolean estaEnSeleccionGrid;
        //void txt_Algo_PreviewKeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == Key.Up)
        //    {
        //        buscadorCatalogoPopup.subirBajarIndex(-1);
        //        estaEnSeleccionGrid = true;
        //    }
        //    else if (e.Key == Key.Down)
        //    {
        //        buscadorCatalogoPopup.subirBajarIndex(1);
        //        estaEnSeleccionGrid = true;
        //    }
        //}

        void img_busqueda_MouseLeave(object sender, MouseEventArgs e)
        {
            //if (buscadorCatalogoPopup.Visibility != System.Windows.Visibility.Visible)
            SalirBoton.Begin();
        }

        void img_busqueda_MouseEnter(object sender, MouseEventArgs e)
        {
            //if (buscadorCatalogoPopup.Visibility != System.Windows.Visibility.Visible)
            SobreBoton.Begin();
        }


        //void buscadorCatalogoPopup_clickCancelar()
        //{
        //    popupOcultar.Begin();

        //}

        //void popupOcultar_Completed(object sender, EventArgs e)
        //{
        //    buscadorCatalogoPopup.Visibility = System.Windows.Visibility.Collapsed;
        //}

        //void buscadorCatalogoPopup_clickAceptar()
        //{
        //    popupOcultar.Begin();
        //    if (mostrarResultado != null)
        //    {
        //        List<ObjetoBase> resultado = buscadorCatalogoPopup.ObtenerSeleccionados();
        //        EscribirEnTextboxEtiqueta(resultado);
        //        mostrarResultado(resultado);

        //        //mostrarResultado(buscadorCatalogoPopup.ObtenerSeleccionados());
        //        //txt_Algo.Text = "";
        //    }
        //}

        void img_busqueda_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (this.rutaCatalogo == null)
            {
                HerramientasWindow.MensajeError(new Exception("El buscador requiere la ruta de catálogo ["+this.Name+"]."), "El buscador requiere de configuración, Verificar código.", "Error");
                return;
            }
            if (this.rutaCatalogo != null)
            {
                if (manejador == null)
                {
                    HerramientasWindow.MensajeError(new Exception("El buscador requiere asignar un manejador [" + this.Name + "]."), "El buscador requiere de configuración, Verificar código.", "Error");
                    return;
                }
                if (campoBusquedaDefault.Equals(""))
                {
                    HerramientasWindow.MensajeError(new Exception("El buscador requiere un campo default [" + this.Name + "]."), "El buscador requiere de configuración, Verificar código.", "Error");
                    return;
                }
                if (campoEtiqueta.Equals(""))
                {
                    HerramientasWindow.MensajeError(new Exception("El buscador requiere el campo etiqueta [" + this.Name + "]."), "El buscador requiere de configuración, Verificar código.", "Error");
                    return;
                }
                if (tipoObjetoCatalogo == null)
                {
                    HerramientasWindow.MensajeError(new Exception("El buscador requiere el tipo de objeto [" + this.Name + "]."), "El buscador requiere de configuración, Verificar código.", "Error");
                    return;
                }
                if (camposConAlias.Count == 0)
                {
                    HerramientasWindow.MensajeError(new Exception("El buscador requiere como minímo un campo alias [" + this.Name + "]."), "Se requiere configurar campos, Verificar código.", "Error");
                    return;
                }
            }
            MostrarPopup();

        }
        List<ObjetoBase> lista;
        String busquedaAnterior = "";

        //private void txt_Algo_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == Key.Enter && (!seConfiguroBuscador || !seConfiguroCampos))
        //    {
        //        HerramientasWindow.MensajeError("El buscador requiere de configuración, Verificar código.", "Error");
        //        return;
        //    }
        //    if (e.Key != Key.Enter)
        //    {
        //        estaEnSeleccionGrid = false;
        //    }
        //    if (busquedaAnterior.Equals(txt_Algo.Text.Trim()) && !txt_Algo.Text.Trim().Equals(""))
        //    {
        //        estaEnSeleccionGrid = true;
        //    }
        //    if (e.Key == Key.Enter && !estaEnSeleccionGrid)
        //    {

        //        if (buscadorCatalogoPopup.Visibility == System.Windows.Visibility.Visible)
        //        {
        //            buscadorCatalogoPopup.Buscar(txt_Algo.Text.Trim());
        //            busquedaAnterior = txt_Algo.Text.Trim();
        //        }
        //        else
        //        {
        //            String query = "select * from " + tipoObjetoABuscar.Name + " where (estaDeshabilitado = 0 or EstaDeshabilitado is null)";
        //            List<Object> valores = null;
        //            List<ObjetoBase> resultado = null;
        //            try
        //            {
        //                Object valor = Convert.ChangeType(txt_Algo.Text.Trim(), tipoObjetoBusqueda);
        //                query += " and " + campoDefault + " = @" + campoDefault;
        //                valores = new List<object>();
        //                valores.Add(valor);
        //                resultado = manejador.Cargar(tipoObjetoABuscar, query, valores);
        //            }
        //            catch { }
        //            if (resultado != null && resultado.Count > 0)
        //            {
        //                EscribirEnTextboxEtiqueta(resultado);
        //                mostrarResultado(resultado);
        //            }
        //            else if (HerramientasWindow.MensajeSIoNO("No se encontró ningún resultado. ¿Desea utilizar la ayuda?", "Valores no devueltos"))
        //            {
        //                MostrarPopup();
        //            }
        //        }

        //    }
        //    else if (e.Key == Key.Enter && estaEnSeleccionGrid)
        //    {
        //        buscadorCatalogoPopup.SeleccionarElemento();
        //        estaEnSeleccionGrid = false;
        //        busquedaAnterior = "";
        //    }
        //    else if (e.Key == Key.Escape)
        //    {
        //        OcultarPopup();
        //    }
        //    else if (e.Key == Key.F1)
        //    {
        //        MostrarPopup();
        //    }

        //}

        //private void EscribirEnTextboxEtiqueta(List<ObjetoBase> resultado)
        //{
        //    txt_Etiqueta.Text = "";
        //    if (resultado.Count == 1)
        //    {
        //        FieldInfo CampoEtiqueta = resultado[0].GetType().GetField(campoEtiqueta, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
        //        txt_Etiqueta.Text += CampoEtiqueta.GetValue(resultado[0]).ToString();
        //    }
        //    else
        //    {
        //        txt_Etiqueta.Text = "Multiples elementos";
        //    }

        //    //foreach (ObjetoBase objetoEnLista in resultado)
        //    //{
        //    //    FieldInfo CampoEtiqueta = objetoEnLista.GetType().GetField(campoEtiqueta, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
        //    //    txt_Etiqueta.Text += CampoEtiqueta.GetValue(objetoEnLista).ToString() + ", ";
        //    //}


        //    txt_Etiqueta.Visibility = System.Windows.Visibility.Visible;
        //    //txt_Etiqueta.Text = txt_Etiqueta.Text.Substring(0, txt_Etiqueta.Text.Length - 2);
        //    txt_Etiqueta.ToolTip = txt_Etiqueta.Text;
        //    txt_Etiqueta.Focus();
        //    txt_Algo.Text = "";
        //}

        private void MostrarPopup()
        {
            try
            {
                buscadorCatalogoPopup = new BuscadorCatalogoVentana();

                buscadorCatalogoPopup.AsignarCatalogoParaAltas(rutaCatalogo);
                buscadorCatalogoPopup.AsignarManejadorDB(manejador);
                if (rutaCatalogo != null)
                {
                    buscadorCatalogoPopup.ConfigurarBusqueda(tipoObjetoCatalogo, campoBusquedaDefault, campoEtiqueta, aceptaMultipleSeleccion, aceptaBusquedaDeshabilitados);
                    foreach (String campoConAlias in camposConAlias)
                    {
                        buscadorCatalogoPopup.AgregarCampoAMostrarConAlias(campoConAlias);
                    }
                }
                else
                    buscadorCatalogoPopup.ConfigurarBusqueda(tipoObjetoCatalogo, Query, aceptaMultipleSeleccion, aceptaBusquedaDeshabilitados);

                buscadorCatalogoPopup.clickAceptar += buscadorCatalogoPopup_clickAceptar;

                buscadorCatalogoPopup.PalabraBusqueda = txt_Algo.Text;

                HerramientasWindow.MostrarVentanaDialogo(buscadorCatalogoPopup, false);
                //buscadorCatalogoPopup.ShowDialog();
            }
            catch (Exception ex)
            {
                HerramientasWindow.MensajeError(ex, ex.Message, "Error en buscador catálogos");
            }
        }

        private void OcultarPopup()
        {

        }

    }
}