using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using InterfazWPF.AdministracionSistema;
using System.Data;
using Dominio;
using System.Reflection;

namespace InterfazWPF
{
    /// <summary>
    /// Lógica de interacción para BuscadorCatalogoPopup.xaml
    /// </summary>
    public partial class BuscadorCatalogoPopup : UserControl
    {
        public delegate void ClickAceptar();
        public event ClickAceptar clickAceptar;

        public delegate void ClickCancelar();
        public event ClickCancelar clickCancelar;

        Boolean AceptaMultipleSeleccion;
        Boolean AceptaBusquedaDeshabilitados;
        Type tipoObjetoABuscar;
        
        ManejadorDB manejador;

        public BuscadorCatalogoPopup()
        {
            this.InitializeComponent();
            this.KeyDown += BuscadorCatalogoPopup_KeyDown;
            chb_SeleccionMultiple.Checked += chb_SeleccionMultiple_Checked;
            chb_SeleccionMultiple.Unchecked += chb_SeleccionMultiple_Unchecked;
            
            dgr_GridResultadosBusqueda.KeyDown += dgr_GridResultadosBusqueda_KeyDown;
        }

        void chb_SeleccionMultiple_Unchecked(object sender, RoutedEventArgs e)
        {
            dgr_GridResultadosBusqueda.SelectionMode = DataGridSelectionMode.Single;
        }

        void chb_SeleccionMultiple_Checked(object sender, RoutedEventArgs e)
        {
            dgr_GridResultadosBusqueda.SelectionMode = DataGridSelectionMode.Extended;
        }


        public void subirBajarIndex(int valor)
        {
            int rowActual = dgr_GridResultadosBusqueda.SelectedIndex;
            rowActual += valor;
            if (rowActual == -1)
                rowActual = cantidadRows-1;
            else if (rowActual == cantidadRows)
                rowActual = 0;

            dgr_GridResultadosBusqueda.SelectedIndex = rowActual;

        }

        List<String> CamposConAlias = new List<string>();
        public void AgregarCampoConAliasAMostrar(String campo)
        {
            CamposConAlias.Add(campo);
        }
        private String ObtenerCampo(String campoConAlias)
        {
            String[] datos = campoConAlias.Split('|');
            return datos[0];
        }
        private String ObtenerAlias(String campoConAlias)
        {
            String[] datos = campoConAlias.Split('|');
            return datos[1];
        }
        private String BuscarYObtenerAlias(String campo)
        {
            foreach (String campoConAlias in CamposConAlias)
            {
                if (campoConAlias.Contains(campo))
                {
                    return ObtenerAlias(campoConAlias);
                }
            }
            return campo;
        }

        public void SeleccionarElemento()
        {
            clickAceptar();
        }
        void dgr_GridResultadosBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                clickAceptar();
            }
        }

        void BuscadorCatalogoPopup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                clickCancelar();
            }
        }

        public void ConfigurarBuscador(ManejadorDB manejador, Type tipoObjetoABuscar, Boolean AceptaMultipleSeleccion, Boolean AceptaBusquedaDeshabilitados)
        {
            this.manejador = manejador;
            this.AceptaBusquedaDeshabilitados = AceptaBusquedaDeshabilitados;
            this.AceptaMultipleSeleccion = AceptaMultipleSeleccion;
            this.tipoObjetoABuscar = tipoObjetoABuscar;

            if (AceptaBusquedaDeshabilitados)
                chb_IncluirDeshabilitados.Visibility = System.Windows.Visibility.Visible;
            if (AceptaMultipleSeleccion)
                chb_SeleccionMultiple.Visibility = System.Windows.Visibility.Visible;
            ObtenerDataTableDeObjeto();
        }
        String textoTemporal = "";
        int cantidadRows = 0;
        public void Buscar(String texto)
        {
            //try
            //{
                textoTemporal = texto;
                String campos = "";
                String query = "select id, * from " + tipoObjetoABuscar.Name + " where ";
                if ((Boolean)chb_IncluirDeshabilitados.IsChecked)
                {
                    campos += " case isNULL(EstaDeshabilitado,0) when 1 then 'SI' when 0 then 'NO' end as Esta_Deshabilitado, ";
                }
                foreach (String columnaAlias in CamposConAlias)
                {
                    campos += ObtenerCampo(columnaAlias) + ", ";
                }

                campos = campos.Substring(0, campos.Length - 2);
                query = query.Replace("*", campos);

                if ((Boolean)chb_IncluirDeshabilitados.IsChecked)
                {
                    query += " (estaDeshabilitado = 0 or EstaDeshabilitado is null or estaDeshabilitado = '1')";
                }
                else
                {
                    query += " (estaDeshabilitado = 0 or EstaDeshabilitado is null)";
                }

                query += " and (";
                try
                {
                    long codigo = Convert.ToInt64(texto.Trim());
                    query += " id = " + codigo + " or";
                }
                catch { }
                foreach (String columnaAlias in CamposConAlias)
                {
                    if (ObtenerCampo(columnaAlias).StartsWith("_st_"))
                    {
                        query += " "+ObtenerCampo(columnaAlias) + " like '%" + texto.Trim() + "%' or";
                    }
                    if (ObtenerCampo(columnaAlias).StartsWith("_in_") || ObtenerCampo(columnaAlias).StartsWith("_lo_"))
                    {
                        try
                        {
                            long convertido = Convert.ToInt64(texto);
                            query += " " + ObtenerCampo(columnaAlias) + " = " + texto.Trim() + " or";
                        }
                        catch { }
                    }
                    if (ObtenerCampo(columnaAlias).StartsWith("_dt_"))
                    {
                        try
                        {
                            DateTime date = Convert.ToDateTime(texto);
                            query += " " + ObtenerCampo(columnaAlias) + " = '" + texto.Trim() + "' or";
                        }
                        catch { }
                    }
                }
                if(query.EndsWith(" or"))
                    query = query.Substring(0, query.Length - 2);

                if (query.EndsWith("and ("))
                    query = query.Substring(0, query.Length - 5);
                else
                    query += ")";

                DataTable resultado = manejador.EjecutarConsulta(query);

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
            //}
            //catch (Exception ex)
            //{
            //    HerramientasWindow.MensajeError("Ocurrió un error en el buscador[BuscadorCatalogoPopup.Buscar], descripción del error: " + ex.Message, "Error en buscador");
            //}
        }

        private void ReestablecerControl()
        {
            dgr_GridResultadosBusqueda.ItemsSource = null;
            chb_IncluirDeshabilitados.IsChecked = false;
            chb_SeleccionMultiple.IsChecked = false;
            
        }

        private void btn_aceptar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
            clickAceptar();
            ReestablecerControl();
        }

        private void btn_cancelar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            clickCancelar();
            ReestablecerControl();
        }

        private void image1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            clickCancelar();
            ReestablecerControl();
        }

        DataTable Estructura;
        public List<ObjetoBase> ObtenerSeleccionados()
        {
            List<ObjetoBase> objetosSeleccionados = null;
            if(dgr_GridResultadosBusqueda.SelectedItems.Count > 0)
                objetosSeleccionados = new List<ObjetoBase>();
            foreach (DataRowView drv in dgr_GridResultadosBusqueda.SelectedItems)
            {
                long id = (long)drv.Row[0];
                ObjetoBase objeto = manejador.Cargar(tipoObjetoABuscar,"select * from " + tipoObjetoABuscar.Name + " where id = @id", new List<object>() { id })[0];
                objetosSeleccionados.Add(objeto);

            }
            return objetosSeleccionados;
        }
        private DataTable ObtenerDataTableDeObjeto()
        {
            Estructura = new DataTable();
            FieldInfo[] atributos = tipoObjetoABuscar.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
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

        private void chb_IncluirDeshabilitados_Checked(object sender, RoutedEventArgs e)
        {
            Buscar(textoTemporal);
        }

        private void chb_IncluirDeshabilitados_Unchecked(object sender, RoutedEventArgs e)
        {
            Buscar(textoTemporal);
        }
    }
}