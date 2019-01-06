using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using InterfazWPF.AdministracionSistema;
using System.Reflection;
using System.Runtime.Remoting;
using Dominio.Sistema;
using Herramientas.ORM;

namespace InterfazWPF
{
    /// <summary>
    /// Lógica de interacción para BuscadorCatalogoVentana.xaml
    /// </summary>
    public partial class BuscadorCatalogoVentana : Window
    {
        public delegate void ClickAceptar(List<ObjetoBase> objetosLista);
        public event ClickAceptar clickAceptar;

        public delegate void ClickCancelar();
        public event ClickCancelar clickCancelar;

        Boolean AceptaMultipleSeleccion;
        Boolean AceptaBusquedaDeshabilitados;
        Type tipoObjetoCatalogo;
        String Query;

        ManejadorDB manejador;

        Boolean SeConfiguro;
        Boolean SeAgregaronCampos;

        String rutaCatalogo;
        Boolean estaAutorizado;

        private Assembly assem = Assembly.GetExecutingAssembly();

        public String PalabraBusqueda { get { return txt_palabraBusqueda.Text; } set { txt_palabraBusqueda.Text = value; } }

        public void AsignarCatalogoParaAltas(String rutaCatalogo)
        {
            //this.estaAutorizado = estaAutorizado;
            this.rutaCatalogo = rutaCatalogo;
            if (this.rutaCatalogo == null)
                btn_AccesoCatalogo.Visibility = System.Windows.Visibility.Hidden;
            //if (estaAutorizado)
            //    btn_AccesoCatalogo.Visibility = System.Windows.Visibility.Visible;
            //else
            //    btn_AccesoCatalogo.Visibility = System.Windows.Visibility.Hidden;


        }

        void btn_AccesoCatalogo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ObjectHandle obj = null;
            Window window;
            if (this.rutaCatalogo == null)
            {
                return;
            }
            else if (this.rutaCatalogo.Equals(""))
            {
                HerramientasWindow.MensajeErrorSimple("Error de configuración, se requiere definir el formulario del catálogo.", "Error");
                return;
            }
            try
            {
                //obj = AppDomain.CurrentDomain.CreateInstance(assem.FullName, formulario.SReferenciaFormulario);
                obj = Activator.CreateInstance(assem.FullName, this.rutaCatalogo);
                window = (Window)obj.Unwrap();
            }
            catch { HerramientasWindow.MensajeErrorSimple("La referencia registrada en la configuración del sistema para este formulario es incorrecta. Verificar", "Error al cargar el formulario"); return; }
            //window.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            //window.ShowDialog();

            //FormularioEmergenteConTools fom = new FormularioEmergenteConTools(window);
            //fom.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            //HerramientasWindow.MostrarVentanaDialogo(fom, true);

            HerramientasWindow.MostrarVentanaEmergenteConTools(window, false);

            Buscar(txt_palabraBusqueda.Text);
        }

        public void AsignarManejadorDB(ManejadorDB manejador)
        {
            this.manejador = manejador;
        }

        public void ConfigurarBusqueda(Type tipoObjetoCatalogo, String campoBusquedaDefault, String campoEtiqueta, Boolean aceptaMultipleSeleccion, Boolean aceptaBusquedaDeshabilitados)
        {
            AceptaMultipleSeleccion = aceptaMultipleSeleccion;
            AceptaBusquedaDeshabilitados = aceptaBusquedaDeshabilitados;
            if (aceptaMultipleSeleccion)
            {
                chb_SeleccionMultiple.Visibility = System.Windows.Visibility.Visible;

            }
            chb_SeleccionMultiple.IsChecked = aceptaMultipleSeleccion;
            if (aceptaBusquedaDeshabilitados)
                chb_IncluirDeshabilitados.Visibility = System.Windows.Visibility.Visible;
            this.tipoObjetoCatalogo = tipoObjetoCatalogo;
            SeConfiguro = true;

        }
        public void ConfigurarBusqueda(Type tipoObjetoCatalogo, String query, Boolean aceptaMultipleSeleccion, Boolean aceptaBusquedaDeshabilitados)
        {
            this.Query = query;
            this.AceptaMultipleSeleccion = aceptaMultipleSeleccion;
            this.AceptaBusquedaDeshabilitados = aceptaBusquedaDeshabilitados;
            if (aceptaMultipleSeleccion)
            {
                chb_SeleccionMultiple.Visibility = System.Windows.Visibility.Visible;
            }
            chb_SeleccionMultiple.IsChecked = aceptaMultipleSeleccion;
            if (aceptaBusquedaDeshabilitados)
                chb_IncluirDeshabilitados.Visibility = System.Windows.Visibility.Visible;
            this.tipoObjetoCatalogo = tipoObjetoCatalogo;
            SeConfiguro = true;

        }
        public void AgregarCampoAMostrarConAlias(String nombreCampoConAlias)
        {
            CamposConAlias.Add(nombreCampoConAlias);
            SeAgregaronCampos = true;
        }
        private void InicializarEventos()
        {
            //txt_palabraBusqueda.KeyDown += txt_palabraBusqueda_KeyDown;
            IsVisibleChanged += BuscadorCatalogoVentana_IsVisibleChanged;
            txt_palabraBusqueda.txt_Algo.KeyDown += txt_palabraBusqueda_KeyDown;
            txt_palabraBusqueda.txt_Algo.PreviewKeyDown += txt_Algo_PreviewKeyDown;
            Closing += Window_Closing;
            dgr_GridResultadosBusqueda.MouseDoubleClick += dgr_GridResultadosBusqueda_MouseDoubleClick;
            dgr_GridResultadosBusqueda.PreviewKeyDown += dgr_GridResultadosBusqueda_PreviewKeyDown;
            btn_AccesoCatalogo.MouseDown += btn_AccesoCatalogo_MouseDown;
            chb_SeleccionMultiple.Checked += chb_SeleccionMultiple_Checked;
            chb_SeleccionMultiple.Unchecked += chb_SeleccionMultiple_Unchecked;

            chb_IncluirDeshabilitados.Checked += chb_IncluirDeshabilitados_Checked;
            chb_IncluirDeshabilitados.Unchecked += chb_IncluirDeshabilitados_Unchecked;
        }

        void dgr_GridResultadosBusqueda_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Aceptar();
                seleccionandoElemento = false;
            }
        }

        void dgr_GridResultadosBusqueda_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Aceptar();
            }
        }

        void BuscadorCatalogoVentana_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((Boolean)e.NewValue)
            {
                txt_palabraBusqueda.txt_Algo.Focus();
                txt_palabraBusqueda.txt_Algo.SelectionStart = txt_palabraBusqueda.txt_Algo.Text.Length;
                Buscar(txt_palabraBusqueda.Text);
                if (seleccionandoElemento)
                    Aceptar();
            }
        }

        void txt_Algo_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
            {
                subirBajarIndex(-1);
            }
            else if (e.Key == Key.Down)
            {
                subirBajarIndex(1);
            }
        }
        public void subirBajarIndex(int valor)
        {
            seleccionandoElemento = true;
            int rowActual = dgr_GridResultadosBusqueda.SelectedIndex;
            rowActual += valor;
            if (rowActual == -1)
                rowActual = cantidadRows - 1;
            else if (rowActual == cantidadRows)
                rowActual = 0;

            dgr_GridResultadosBusqueda.SelectedIndex = rowActual;

        }
        Boolean seleccionandoElemento = false;
        void txt_palabraBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (rutaCatalogo != null)
            {
                if (!SeConfiguro || !SeAgregaronCampos || manejador == null)
                {
                    HerramientasWindow.MensajeErrorSimple("El buscador requiere de configuración. Verificar Código.", "Error en buscador");
                    return;
                }
            }

            if (e.Key == Key.Enter)
            {
                if (seleccionandoElemento)
                {
                    Aceptar();
                    seleccionandoElemento = false;
                }
                else
                {
                    Buscar(txt_palabraBusqueda.Text.Trim());
                }
            }
            else if (e.Key == Key.Up)
            {
                subirBajarIndex(-1);
            }
            else if (e.Key == Key.Down)
            {
                subirBajarIndex(1);
            }
            else if (e.Key == Key.Escape)
            {
                Cancelar();
            }
            else
            {
                seleccionandoElemento = false;
            }

        }

        public BuscadorCatalogoVentana()
        {
            this.InitializeComponent();
            InicializarEventos();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            _sis_Usuario usuarioActual = HerramientasWindow.ObtenerUsuarioLogueado();

            if (usuarioActual.RolSistema.BPuedeAccederCatalogoRapido || usuarioActual.BPuedeAccederCatalogoRapido)
                btn_AccesoCatalogo.Visibility = System.Windows.Visibility.Visible;
            else
                btn_AccesoCatalogo.Visibility = System.Windows.Visibility.Hidden;

        }
        void chb_SeleccionMultiple_Unchecked(object sender, RoutedEventArgs e)
        {
            dgr_GridResultadosBusqueda.SelectionMode = DataGridSelectionMode.Single;
        }

        void chb_SeleccionMultiple_Checked(object sender, RoutedEventArgs e)
        {
            dgr_GridResultadosBusqueda.SelectionMode = DataGridSelectionMode.Extended;
        }
        private void chb_IncluirDeshabilitados_Checked(object sender, RoutedEventArgs e)
        {
            Buscar(txt_palabraBusqueda.Text);
        }

        private void chb_IncluirDeshabilitados_Unchecked(object sender, RoutedEventArgs e)
        {
            Buscar(txt_palabraBusqueda.Text);
        }

        private void btn_aceptar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Aceptar();
        }
        private void Aceptar()
        {
            if (clickAceptar != null)
                clickAceptar(ObtenerSeleccionados());
            //else
            //    HerramientasWindow.MensajeErrorSimple("Requiere asignarse el evento clickAceptar. Verificar código.", "Error");
            //ReestablecerControl();
            //Visibility = System.Windows.Visibility.Hidden;

            Close();
        }
        private void Cancelar()
        {
            if (clickCancelar != null)
                clickCancelar();
            //else
            //    HerramientasWindow.MensajeErrorSimple("Requiere asignarse el evento clickCancelar. Verificar código.", "Error");

            //ReestablecerControl();
            //Visibility = System.Windows.Visibility.Hidden;

            Close();
        }
        private void btn_cancelar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Cancelar();
        }
        //String textoTemporal = "";
        int cantidadRows = 0;
        public String CrearQuery(String texto)
        {
            Boolean incluirDeshabilitados = this.AceptaBusquedaDeshabilitados;
            CamposConAliasTemp.Clear();
            List<String> aliasInnerJoins = new List<string>();


            String campos = "";
            String query = "select a.ID, * from " + tipoObjetoCatalogo.Name + " a ^innerJoins where ";
            if (incluirDeshabilitados)
            {
                campos += " case when a.EstaDeshabilitado is null then 'NO' when a.EstaDeshabilitado = 'True' then 'SI' when a.EstaDeshabilitado = 'False' then 'NO' end as [Está deshabilitado], ";
            }
            char AliasConsecutivo = 'a';
            Boolean hayInners = false;
            List<int> omitidos = new List<int>();
            List<String> CamposNuevosInners = new List<String>();
            List<Type> TiposCamposNuevosInners = new List<Type>();
            String inners = "";
            for (int x = 0; x < CamposConAlias.Count; x++ )
            {
                String columnaAlias = CamposConAlias[x];
                String campoCompuesto = ObtenerCampo(columnaAlias);
                String campoAlias = ObtenerAlias(columnaAlias);
                if (campoCompuesto.Contains("."))
                {
                    hayInners = true;
                    String[] camposCompuestos = campoCompuesto.Split('.');


                    Type tipoParaInner = tipoObjetoCatalogo.GetField(camposCompuestos[0], System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).FieldType;
                    AliasConsecutivo++;
                    inners += " left join " + tipoParaInner.Name + " " + AliasConsecutivo + " on " + "a." + camposCompuestos[0] + " = " + AliasConsecutivo + ".id";
                    CamposNuevosInners.Add(AliasConsecutivo+"."+camposCompuestos[1] + "|" + campoAlias);

                    Type tipoCampo = tipoParaInner.GetField(camposCompuestos[1], System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).FieldType;

                    TiposCamposNuevosInners.Add(tipoCampo);
                    CamposConAliasTemp.Add(AliasConsecutivo + "." + camposCompuestos[1] + "|" + campoAlias);

                    omitidos.Add(x);
                }
            }
            // si hubo campos compuestos, se elimina la variable
            if (!hayInners)
            {
                query = query.Replace("^innerJoins", "");
            }

            for (int x = 0; x < CamposConAlias.Count; x++)
            {
                if (omitidos.Contains(x))
                    continue;
                String columnaAlias = CamposConAlias[x];
                CamposConAliasTemp.Add(columnaAlias);
                campos += ObtenerCampo(columnaAlias) + ", ";
            }
            //campos inners en el query
            for (int x = 0; x < CamposNuevosInners.Count; x++)
            {
                String columnaAlias = CamposNuevosInners[x];
                campos += ObtenerCampo(columnaAlias) + " as [" + ObtenerCampo(columnaAlias) + "], ";
            }

            campos = campos.Substring(0, campos.Length - 2);
            query = query.Replace("*", campos);
            query = query.Replace("^innerJoins", inners);

            if (incluirDeshabilitados)
            {
                query += " (a.estaDeshabilitado = 'False' or a.EstaDeshabilitado is null or a.estaDeshabilitado = 'True')";
            }
            else
            {
                query += " (a.estaDeshabilitado = 'False' or a.EstaDeshabilitado is null)";
            }

            if(CamposNuevosInners.Count >0)
                query += " and (";

            for (int x = 0; x < CamposNuevosInners.Count; x++)
            {
                if (TiposCamposNuevosInners[x] == typeof(String))
                {
                    query += " " + ObtenerCampo(CamposNuevosInners[x]) + " like '%" + texto.Trim() + "%' or";
                }
                if (TiposCamposNuevosInners[x] == typeof(Int32) || TiposCamposNuevosInners[x] == typeof(Int64))
                {
                    try
                    {
                        long convertido = Convert.ToInt64(texto);
                        query += " " + ObtenerCampo(CamposNuevosInners[x]) + " = " + texto.Trim() + " or";
                    }
                    catch { }
                }
                if (TiposCamposNuevosInners[x] == typeof(DateTime))
                {
                    try
                    {
                        DateTime date = Convert.ToDateTime(texto);
                        query += " " + ObtenerCampo(CamposNuevosInners[x]) + " = '" + texto.Trim() + "' or";
                    }
                    catch { }
                }
            }
            if (CamposNuevosInners.Count == 0)
                query += " and (";
            
            try
            {
                long codigo = Convert.ToInt64(texto.Trim());
                query += " a.id = " + codigo + " or";
            }
            catch { }
            for(int x = 0; x < CamposConAlias.Count; x++)
            {
                String columnaAlias = CamposConAlias[x];
                if (omitidos.Contains(x))
                    continue;
                if (obtenerTipoCampoPorNombre(ObtenerCampo(columnaAlias)) == typeof(String))
                {
                    query += " a." + ObtenerCampo(columnaAlias) + " like '%" + texto.Trim() + "%' or";
                }
                if (obtenerTipoCampoPorNombre(ObtenerCampo(columnaAlias)) == typeof(Int32) || obtenerTipoCampoPorNombre(ObtenerCampo(columnaAlias)) == typeof(Int64))
                {
                    try
                    {
                        long convertido = Convert.ToInt64(texto);
                        query += " a." + ObtenerCampo(columnaAlias) + " = " + texto.Trim() + " or";
                    }
                    catch { }
                }
                if (obtenerTipoCampoPorNombre(ObtenerCampo(columnaAlias)) == typeof(DateTime))
                {
                    try
                    {
                        DateTime date = Convert.ToDateTime(texto);
                        query += " a." + ObtenerCampo(columnaAlias) + " = '" + texto.Trim() + "' or";
                    }
                    catch { }
                }
            }
            if (query.EndsWith(" or"))
                query = query.Substring(0, query.Length - 2);

            if (query.EndsWith("and ("))
                query = query.Substring(0, query.Length - 5);
            else
                query += ")";
            return query;
        }
        public void Buscar(String texto)
        {
            try
            {
                //textoTemporal = texto;
                String query = "";
                if (Query != null)
                    query = this.Query;
                else
                    query = CrearQuery(texto);

                DataTable resultado = manejador.EjecutarConsulta(query); //aqui mandar parametros
                if (resultado.Rows.Count == 1)
                    seleccionandoElemento = true;
                if (PalabraBusqueda.Trim().Equals(""))
                    seleccionandoElemento = false;
                foreach (DataColumn columnaPro in resultado.Columns)
                {
                    columnaPro.ReadOnly = true;
                    columnaPro.ColumnName = BuscarYObtenerAlias(columnaPro.ColumnName);
                }
                dgr_GridResultadosBusqueda.ItemsSource = resultado.DefaultView;

                if (resultado.Rows.Count > 0)
                {
                    dgr_GridResultadosBusqueda.SelectedIndex = 0;
                    cantidadRows = resultado.Rows.Count;
                }
            }
            catch (Exception ex)
            {
                HerramientasWindow.MensajeError(ex, "Ocurrió un error en el buscador[BuscadorCatalogoPopup.Buscar], descripción del error: " + ex.Message, "Error en buscador");
            }
        }
        DataTable Estructura;
        public List<ObjetoBase> ObtenerSeleccionados()
        {
            List<ObjetoBase> objetosSeleccionados = null;
            if (dgr_GridResultadosBusqueda.SelectedItems.Count > 0)
                objetosSeleccionados = new List<ObjetoBase>();
            foreach (DataRowView drv in dgr_GridResultadosBusqueda.SelectedItems)
            {
                long id = (long)drv.Row[0];
                //AlmacenObjetos.BorrarAlmacen();
                ObjetoBase objeto = manejador.Cargar(tipoObjetoCatalogo, "select * from " + tipoObjetoCatalogo.Name + " where id = @id", new List<object>() { id })[0];
                objetosSeleccionados.Add(objeto);

            }
            return objetosSeleccionados;
        }
        private DataTable ObtenerDataTableDeObjeto()
        {
            Estructura = new DataTable();
            FieldInfo[] atributos = tipoObjetoCatalogo.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            foreach (FieldInfo atributo in atributos)
            {
                if (atributo.Name.StartsWith("_") && !atributo.FieldType.Name.Contains("List") && !atributo.FieldType.Name.StartsWith("_"))
                {
                    Estructura.Columns.Add(atributo.Name);
                    //cmb_atributos.Items.Add(atributo.Name);
                }
            }
            //cmb_atributos.Items.Add("Todos");
            return Estructura;
        }
        private void ReestablecerControl()
        {
            dgr_GridResultadosBusqueda.ItemsSource = null;
            chb_IncluirDeshabilitados.IsChecked = false;
            chb_SeleccionMultiple.IsChecked = false;

        }
        List<String> CamposConAlias = new List<string>();
        List<String> CamposConAliasTemp = new List<string>();
        private String ObtenerAlias(String campoConAlias)
        {
            String[] datos = campoConAlias.Split('|');
            return datos[1];
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
        private String BuscarYObtenerAlias(String campo)
        {
            foreach (String campoConAlias in CamposConAliasTemp)
            {
                if (ObtenerCampo(campoConAlias).Equals(campo))//el problema es q si lo contiene pero no exactamente
                {
                    return ObtenerAlias(campoConAlias);
                }
            }
            return campo;
        }
        private String ObtenerCampo(String campoConAlias)
        {
            String[] datos = campoConAlias.Split('|');
            return datos[0];
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //e.Cancel = true;
        }


    }
}