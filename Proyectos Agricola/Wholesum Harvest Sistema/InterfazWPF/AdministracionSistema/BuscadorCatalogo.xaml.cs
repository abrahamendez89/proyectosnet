using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
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

namespace InterfazWPF.AdministracionSistema
{
    /// <summary>
    /// Lógica de interacción para BuscadorCatalogo.xaml
    /// </summary>
    public partial class BuscadorCatalogo : Window
    {
        Type tipoObjetoABuscar;
        ManejadorDB manejador = new ManejadorDB();
        Boolean seAcepto = false;
        public BuscadorCatalogo(Type tipo)
        {
            InitializeComponent();
            Inicializar(tipo, false);
        }
        public BuscadorCatalogo(Type tipo, Boolean permiteMultipleSeleccion)
        {
            InitializeComponent();
            Inicializar(tipo, permiteMultipleSeleccion);
        }

        private void Inicializar(Type tipo, Boolean permiteMultipleSeleccion)
        {
            this.tipoObjetoABuscar = tipo;
            ObtenerDataTableDeObjeto();
            if (permiteMultipleSeleccion)
                chb_MasDeUno.Visibility = System.Windows.Visibility.Visible;
            else
                chb_MasDeUno.Visibility = System.Windows.Visibility.Hidden;
        }

        DataTable Estructura;
        public List<T> ObtenerSeleccionados<T>()
        {
            List<T> objetosSeleccionados = null;
            if (seAcepto)
            {
                objetosSeleccionados = new List<T>();
                foreach (DataRowView drv in dgr_InformacionObjetos.SelectedItems)
                {
                    long id = (long)drv.Row[0];
                    T objeto = manejador.Cargar<T>("select * from " + tipoObjetoABuscar.Name + " where id = @id", new List<object>() { id });
                    objetosSeleccionados.Add(objeto);

                }
            }
            return objetosSeleccionados;
        }
        private DataTable ObtenerDataTableDeObjeto()
        {
            Estructura = new DataTable();
            FieldInfo[] atributos = tipoObjetoABuscar.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            foreach (FieldInfo atributo in atributos)
            {
                if (atributo.Name.StartsWith("_"))
                {
                    Estructura.Columns.Add(atributo.Name);
                    cmb_atributos.Items.Add(atributo.Name);
                }   
            }

            cmb_atributos.Items.Add("Todos");
            

            return Estructura;
        }

        private void TextboxNormal_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Buscar();   
            }
        }
        private void Buscar()
        {
            String campos = "";
            String query = "select id,* from " + tipoObjetoABuscar.Name + " where ";
            if ((Boolean)chb_mostrarDeshabilitados.IsChecked)
            {
                campos += "estaDeshabilitado, ";
            }
            foreach (DataColumn columna in Estructura.Columns)
            {
                campos += columna.ColumnName + ", ";
            }
            
            campos = campos.Substring(0, campos.Length - 2);
            query = query.Replace("*", campos);
            if (cmb_atributos.SelectedIndex == -1 || cmb_atributos.SelectedItem.ToString().Equals("Todos"))
            {
                foreach (DataColumn columna in Estructura.Columns)
                {
                    if (columna.ColumnName.StartsWith("_st_"))
                        query += columna + " like '%" + txt_busqueda.Text.Trim() + "%' or";
                    if (columna.ColumnName.StartsWith("_in_") || columna.ColumnName.StartsWith("_lo_"))
                        query += columna + " = " + txt_busqueda.Text.Trim() + " or";
                    if (columna.ColumnName.StartsWith("_dt_"))
                        query += columna + " = '" + txt_busqueda.Text.Trim() + "' or";
                }
                query = query.Substring(0, query.Length - 2);
            }
            else
            {
                query += cmb_atributos.SelectedItem.ToString() + " like '%" + txt_busqueda.Text.Trim() + "%'";
            }

            if ((Boolean)chb_mostrarDeshabilitados.IsChecked)
            {
                 query += " and (estaDeshabilitado = 0 or EstaDeshabilitado is null or estaDeshabilitado = '1')";
            }
            else
            {
                query += " and (estaDeshabilitado = 0 or EstaDeshabilitado is null)";
            }

            DataTable resultado = manejador.EjecutarConsulta(query);

            foreach (DataColumn columnaPro in resultado.Columns)
            {
                columnaPro.ReadOnly = true;
            }
            dgr_InformacionObjetos.ItemsSource = resultado.DefaultView;
        }
        private void chb_MasDeUno_Checked(object sender, RoutedEventArgs e)
        {
            dgr_InformacionObjetos.SelectionMode = DataGridSelectionMode.Extended;
        }

        private void chb_MasDeUno_Unchecked(object sender, RoutedEventArgs e)
        {
            dgr_InformacionObjetos.SelectionMode = DataGridSelectionMode.Single;
        }

        private void btn_seleccionar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            seAcepto = true;
            Close();
        }

        private void btn_Cancelar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            seAcepto = false;
            Close();
        }

        private void btn_Buscar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Buscar();
        }


    }
}
