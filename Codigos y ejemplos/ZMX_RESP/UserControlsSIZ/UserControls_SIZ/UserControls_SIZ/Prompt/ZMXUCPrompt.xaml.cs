using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;
using UserControlsSIZ.Utilerias;

namespace UserControlsSIZ.Prompt
{
    /// <summary>
    /// Interaction logic for Prompt.xaml
    /// </summary>
    public partial class ZMXUCPrompt : UserControl
    {
        public delegate DataTable _ZMX_EjecutarConsulta(String codigoBuscar);
        public event _ZMX_EjecutarConsulta ZMX_EjecutarConsulta;

        public delegate void _ZMX_ValorCambiadoRow(DataRow drSeleccionado);
        public event _ZMX_ValorCambiadoRow ZMX_ValorCambiadoRow;

        public delegate void _ZMX_ActivarSiguienteControl(ZMXUCPrompt prompt);
        public event _ZMX_ActivarSiguienteControl ZMX_ActivarSiguienteControl;

        public delegate void _ZMX_ActivarAnteriorControl(ZMXUCPrompt prompt);
        public event _ZMX_ActivarAnteriorControl ZMX_ActivarAnteriorControl;

        public delegate void _ZMX_CambioValorRequerido(ZMXUCPrompt prompt, Boolean esRequerido);
        public event _ZMX_CambioValorRequerido ZMX_CambioValorRequerido;

        public delegate void _ZMX_SeLimpioControl(ZMXUCPrompt prompt);
        public event _ZMX_SeLimpioControl ZMX_SeLimpioControl;

        private String zmx_id = "";
        private Boolean zmx_EsRequerido;

        public Boolean ZMX_ControlBloqueadoPorSecuencia { get; set; }
        public Boolean ZMX_EsRequerido
        {
            get { return zmx_EsRequerido; }
            set
            {
                zmx_EsRequerido = value;
                if (ZMX_CambioValorRequerido != null)
                    ZMX_CambioValorRequerido(this, zmx_EsRequerido);
            }
        }
        public String ZMX_ID { get { return zmx_id; } set { zmx_id = value; ZMX_EjecutoBusqueda = true; } }
        public String ZMX_CODIGO { get { return txtCodigo.Text; } set { txtCodigo.Text = value; } }
        public String ZMX_DESCRIPCION { get { return txtDescripcion.Text; } set { txtDescripcion.Text = value; } }
        public Boolean ZMX_EjecutoBusqueda { get; set; }
        public String ZMX_TituloPrompt { get; set; }
        public double ZMX_Width { get { return grdContenedor.ColumnDefinitions[0].Width.Value; } set { grdContenedor.ColumnDefinitions[0].Width = new GridLength(value); } }
        public String ZMX_MensajeNoExiste { get; set; }
        public String ZMX_PathEstatusId { get; set; }
        public String ZMX_MensajeInactivo { get; set; }

        public ZMXUCPrompt()
        {
            InitializeComponent();

            txtCodigo.TextChanged += TxtCodigo_TextChanged;
            txtCodigo.LostFocus += TxtCodigo_LostFocus;
            txtCodigo.KeyDown += TxtCodigo_KeyDown;
            txtCodigo.KeyUp += TxtCodigo_KeyUp;

            ZMX_EsRequerido = false;
            ZMX_MarcarRequerido = false;
        }



        private Brush ColorBrush;

        private Boolean zmx_soloLectura;
        public Boolean ZMX_SoloLectura
        {
            get { return zmx_soloLectura; }
            set
            {
                zmx_soloLectura = value;
                txtCodigo.IsEnabled = !zmx_soloLectura;
                if (!zmx_soloLectura)
                    btnBuscar.BtnColor = Colores.ConvertirBrushAColor(ColorBrush);
                btnBuscar.ToolbarBtnEstaHabilitado = !zmx_soloLectura;

            }
        }
        private void TxtCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.Delete || e.Key == Key.Back) && string.IsNullOrEmpty(txtCodigo.Text) && ZMX_SeLimpioControl != null)
                ZMX_SeLimpioControl(this);
        }
        private void TxtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab && (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift)))
            {
                if (ZMX_ActivarAnteriorControl != null)
                {
                    e.Handled = true;
                    ZMX_ActivarAnteriorControl(this);
                }
            }
            else if (e.Key == Key.Enter || e.Key == Key.Tab)
            {
                String codigoBuscado = txtCodigo.Text;

                if (string.IsNullOrEmpty(codigoBuscado))
                {
                    e.Handled = true;
                    if (ZMX_ActivarSiguienteControl != null)
                        ZMX_ActivarSiguienteControl(this);
                    return;
                }

                DataRow drSeleccionado = BuscarPorCodigo();
                if (e.Key == Key.Tab)
                    e.Handled = true;
                if (!string.IsNullOrEmpty(codigoBuscado))
                {
                    ZMX_ValidarNoExiste(drSeleccionado);
                    ZMX_ValidarInactivo(drSeleccionado);
                }

                if (ZMX_ValorCambiadoRow != null && drSeleccionado != null)
                    ZMX_ValorCambiadoRow(drSeleccionado);

                txtCodigo.SelectionStart = txtCodigo.Text.Length;

            }
            else if (e.Key == Key.F5)
            {
                ToolbarBtn_toolbarBtnClick(null);
            }
            else
            {
                ZMX_EjecutoBusqueda = false;
            }


        }
        public void ZMX_ValidarInactivo(DataRow drSeleccionado)
        {
            if (drSeleccionado != null && string.IsNullOrEmpty(ZMX_MensajeInactivo) && string.IsNullOrEmpty(ZMX_PathEstatusId))
            {
                try
                {
                    if (ZMX_PathEstatusId != null)
                        Convert.ToInt32(drSeleccionado[ZMX_PathEstatusId]);
                }
                catch
                {
                    throw new Exception("La columna 'ZMX_PathEstatusId' no se encuentra en la consulta.");
                }
                if (ZMX_PathEstatusId != null && Convert.ToInt32(drSeleccionado[ZMX_PathEstatusId]) == 2)
                {
                    ZMXUC_MessageBoxERP.Show(ZMX_MensajeInactivo, "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
        public void ZMX_ValidarNoExiste(DataRow drSeleccionado)
        {
            if (!string.IsNullOrEmpty(ZMX_MensajeNoExiste))
            {
                if (drSeleccionado == null)
                {
                    ZMXUC_MessageBoxERP.Show(ZMX_MensajeNoExiste, "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
        private void TxtCodigo_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!ZMX_EjecutoBusqueda && !txtCodigo.Text.Equals(""))
            {
                DataRow drSeleccionado = BuscarPorCodigo();
                if (ZMX_ValorCambiadoRow != null && drSeleccionado != null)
                {
                    ZMX_ValorCambiadoRow(drSeleccionado);
                }
            }
        }
        //public void ZMX_ActivarRequeridoInicial()
        //{
        //    //txtCodigo.BorderBrush = Brushes.Red;
        //    //txtCodigo.BorderThickness = new Thickness(1.1);
        //}
        //public void ZMX_ActivarRequerido()
        //{
        //    //txtCodigo.BorderBrush = Brushes.Red;
        //    //txtCodigo.BorderThickness = new Thickness(1.1);
        //}

        public Boolean ZMX_MarcarRequerido
        {
            get { return ZMX_EsRequerido; }
            set
            {
                if (value)
                    ZMX_EsRequerido = value;

                if (value && !string.IsNullOrEmpty(zmx_id))
                    return;

                if (value) { rtgMarcoRojo.Visibility = Visibility.Visible; txtAsterisco.Visibility = Visibility.Visible; }
                else { rtgMarcoRojo.Visibility = Visibility.Hidden; txtAsterisco.Visibility = Visibility.Hidden; }
            }
        }
        public Boolean ZMX_MarcarRequeridoInicial
        {
            get { return ZMX_EsRequerido; }
            set
            {
                if (value)
                    ZMX_EsRequerido = value;

                if (value && !string.IsNullOrEmpty(zmx_id))
                    return;

                if (value) { rtgMarcoRojo.Visibility = Visibility.Hidden; txtAsterisco.Visibility = Visibility.Visible; }
                else { rtgMarcoRojo.Visibility = Visibility.Hidden; txtAsterisco.Visibility = Visibility.Hidden; }
            }
        }
        public Boolean ZMX_SetTemplateRequerido
        {
            set
            {
                if (value) { rtgMarcoRojo.Visibility = Visibility.Visible; txtAsterisco.Visibility = Visibility.Visible; }
                else { rtgMarcoRojo.Visibility = Visibility.Hidden; txtAsterisco.Visibility = Visibility.Hidden; }
            }
        }
        public Boolean ZMX_SetTemplateRequeridoInicial
        {
            set
            {
                if (value) { rtgMarcoRojo.Visibility = Visibility.Hidden; txtAsterisco.Visibility = Visibility.Visible; }
                else { rtgMarcoRojo.Visibility = Visibility.Hidden; txtAsterisco.Visibility = Visibility.Hidden; }
            }
        }
        public void ZMX_Reestablecer()
        {
            //txtCodigo.BorderBrush = Brushes.Black;
            //txtCodigo.BorderThickness = new Thickness(1);
        }
        Color colorBtn;
        public void SetColor(Brush colorBrush)
        {
            if (colorBrush == null) return;
            ColorBrush = colorBrush;
            colorBtn = Colores.ConvertirBrushAColor(colorBrush);
            rtgMarcoNegro.Stroke = colorBrush;
            txtDescripcion.BorderBrush = colorBrush;
            if (!ZMX_SoloLectura)
                btnBuscar.BtnColor = Colores.ConvertirBrushAColor(colorBrush);
        }
        public T ZMX_ConvertirDataRowToObject<T>(DataRow dr)
        {
            Type tipo = typeof(T);
            PropertyInfo[] atributos = tipo.GetProperties(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            var objRetorno = tipo
                     .GetConstructor(Type.EmptyTypes)
                     .Invoke(null);

            foreach (PropertyInfo propiedad in atributos)
            {
                object valor = null;
                try
                {
                    valor = dr[propiedad.Name];
                }
                catch { }
                if(valor == DBNull.Value)
                {
                    continue;
                }
                if (valor != null)
                {
                    if (propiedad.PropertyType == typeof(Boolean) || propiedad.PropertyType == typeof(Boolean?))
                        propiedad.SetValue(objRetorno, Convert.ToInt32(valor) == 1);
                    else if (propiedad.PropertyType == typeof(DateTime) || propiedad.PropertyType == typeof(DateTime?))
                    {
                        DateTime dt = Convert.ToDateTime(valor);
                        propiedad.SetValue(objRetorno, dt);
                    }
                    else if (propiedad.PropertyType == typeof(short) || propiedad.PropertyType == typeof(short?))
                        propiedad.SetValue(objRetorno, Convert.ToInt16(valor));
                    else if (propiedad.PropertyType == typeof(int) || propiedad.PropertyType == typeof(int?))
                        propiedad.SetValue(objRetorno, Convert.ToInt32(valor));
                    else if (propiedad.PropertyType == typeof(long) || propiedad.PropertyType == typeof(long?))
                        propiedad.SetValue(objRetorno, Convert.ToInt64(valor));
                    else if (propiedad.PropertyType == typeof(decimal) || propiedad.PropertyType == typeof(decimal?))
                        propiedad.SetValue(objRetorno, Convert.ToDecimal(valor));
                    else
                        propiedad.SetValue(objRetorno, valor);
                }
            }
            return (T)objRetorno;
        }
        private DataRow BuscarPorCodigo()
        {
            String codigo = txtCodigo.Text;
            ZMX_ID = "";
            ZMX_CODIGO = "";
            ZMX_DESCRIPCION = "";

            if (codigo == null || codigo == string.Empty)
            {
                ToolbarBtn_toolbarBtnClick(null);
                return null;
            }

            if (ZMX_EjecutarConsulta != null)
            {
                DataTable dt = ZMX_EjecutarConsulta(codigo);

                if (dt == null)
                    throw new Exception("La consulta regresa el valor null, favor de definir la consulta en el evento 'ZMX_EjecutarConsulta'.");
                else if (dt.Rows.Count > 1)
                    throw new Exception("La consulta por código regresa más de un resultado, favor de verificar.");
                else if (dt.Rows.Count == 0)
                    return null;
                else if (dt.Rows.Count == 1)
                    return dt.Rows[0];

            }
            else
                throw new Exception("Es necesario suscribirse al evento 'ZMX_EjecutarConsulta' para realizar consultas, favor de verificar.");

            return null;
        }
        private void TxtCodigo_TextChanged(object sender, TextChangedEventArgs e)
        {
            ZMX_ID = "";
            ZMX_DESCRIPCION = "";
            ZMX_EjecutoBusqueda = false;


        }

        public void ZMX_Focus()
        {
            txtCodigo.Focus();
        }
        public void ZMX_ActivarSiguiente()
        {
            if (ZMX_ActivarSiguienteControl != null)
                ZMX_ActivarSiguienteControl(this);
        }
        public void ZMX_Limpiar()
        {
            ZMX_ID = "";
            ZMX_CODIGO = "";
            ZMX_DESCRIPCION = "";
            ZMX_EjecutoBusqueda = false;
        }

        RadWindow rw;
        private void ToolbarBtn_toolbarBtnClick(Toolbar.ToolbarBtn boton)
        {
            if (ZMX_ControlBloqueadoPorSecuencia)
                return;
            DataTable dt = new DataTable();

            String codigo = txtCodigo.Text;

            if (ZMX_EjecutarConsulta != null)
            {
                dt = ZMX_EjecutarConsulta(null);
            }

            ZMXUCPromptVisor visor = new ZMXUCPromptVisor();
            visor.ZMX_PromptGenerico = this;
            visor.ZMX_SeleccionoRow += Visor_ZMX_SeleccionoRow;
            visor.SetDataTable(dt, columnasMostrar);


            Window.GetWindow(this).IsEnabled = false;

            rw = new RadWindow();
            rw.Owner = Window.GetWindow(this);
            rw.Header = this.ZMX_TituloPrompt;
            rw.HideMinimizeButton = true;
            rw.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            rw.VerticalAlignment = VerticalAlignment.Stretch;
            rw.HorizontalAlignment = HorizontalAlignment.Stretch;

            Frame fr = new Frame();
            fr.VerticalAlignment = VerticalAlignment.Stretch;
            fr.HorizontalAlignment = HorizontalAlignment.Stretch;
            fr.Content = visor;
            rw.Content = fr;
            rw.Height = 600;
            rw.Width = 650;
            rw.Show();
            rw.Closed += Rw_Closed;
        }

        private void Rw_Closed(object sender, WindowClosedEventArgs e)
        {
            Window.GetWindow(this).IsEnabled = true;

        }

        public void ZMX_CerrarPopupVisorPrompt()
        {
            if (rw != null)
            {
                Window.GetWindow(this).IsEnabled = true;
                rw.Close();
            }
        }
        Dictionary<String, String> columnasMostrar = new Dictionary<string, string>();
        public void ZMX_AgregarColumnaMostrarEnVisor(String columnaDT, String etiqueta)
        {
            ZMX_AgregarColumnaMostrarEnVisor(columnaDT, etiqueta, 0);
        }
        public void ZMX_AgregarColumnaMostrarEnVisor(String columnaDT, String etiqueta, double ancho)
        {
            if (!columnasMostrar.ContainsKey(columnaDT))
            {
                columnasMostrar.Add(columnaDT, etiqueta + "|" + ancho);
            }
            else
            {
                columnasMostrar[columnaDT] = etiqueta + "|" + ancho;
            }
        }
        private void Visor_ZMX_SeleccionoRow(DataRow drSeleccionado)
        {
            if (ZMX_ValorCambiadoRow != null)
                ZMX_ValorCambiadoRow(drSeleccionado);
        }
        public TextBox ZMX_GetTextboxCodigo()
        {
            return txtCodigo;
        }

        public void ZMX_AbrirPrompt()
        {
            ToolbarBtn_toolbarBtnClick(btnBuscar);
        }
    }
}
