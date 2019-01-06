using ACCESO_DATOS.Manejador;
using System;
using System.Collections.Generic;
using System.Linq;
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
using ACCESO_DATOS.Mapeo.Oracle;
using ACCESO_DATOS.Conexiones;
using System.Data;
using GeneradorEntidades.Modelo;
using System.Collections.ObjectModel;

namespace GeneradorEntidades
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ManejadorInstanciasBD mibd = new ManejadorInstanciasBD();

        String qry = string.Empty;
        String saltoLinea = " \n ";
        string tabla = string.Empty;
        DataTable dt = new DataTable();
        ObservableCollection<propiedad_base> propiedadeslist = new ObservableCollection<propiedad_base>();

        String claseGen = string.Empty;
        String propiedadesGen = string.Empty;
        String indicesGen = string.Empty;

        public MainWindow()
        {
            InitializeComponent();
            String cadenaConexion = @"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.0.81)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)));User Id=ERPZMX_REF;Password=ERPZMX_REF;";
            ManejadorInstanciasBD.ZMX_Usuario = "jguerrerok@zucarmex.com";
            ManejadorInstanciasBD.ZMX_SetClienteConexion(ClienteConfig.ClientesBD.Oracle, new OracleMapeoInsert(), new OracleMapeoSelect(), new OracleMapeoUpdate(), cadenaConexion);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            propiedadeslist = new ObservableCollection<propiedad_base>();
            if (txtTabla.Text != string.Empty && txtTabla.Text != null)
            {
                dgTabla.ItemsSource = null;
                dgTabla.Items.Refresh();

                rtbClaseResult.Document.Blocks.Clear();

                tabla = txtTabla.Text.ToUpper();
                txtTabla.Text = tabla;

                qry =
                    "select "
                  + " TABLE_NAME, COLUMN_NAME, DATA_TYPE, DATA_LENGTH, DATA_PRECISION, DATA_SCALE, NULLABLE, COLUMN_ID "
                  + " from all_tab_columns "
                  + " where owner = 'ERPZMX_REF' "
                  + " and table_name = '@tabla' ";

                qry = qry.Replace("@tabla", tabla);

                mibd.ZMX_AbrirConexion();
                dt = mibd.ZMX_EjecutarSelectQuery(qry);
                mibd.ZMX_CerrarConexion();

                if (dt != null && dt.Rows.Count > 0)
                {
                    dgTabla.ItemsSource = dt.AsDataView();
                    dgTabla.Items.Refresh();
                }
                else
                {
                    MessageBox.Show("Tabla no existe ");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Favor de ingresar un nombre de tabla");
                txtTabla.Focus();
                return;
            }
        }

        private void btnGenerar_Click(object sender, RoutedEventArgs e)
        {
            claseGen = string.Empty;
            propiedadesGen = string.Empty;


            rtbClaseResult.Document.Blocks.Clear();
            claseGen = String.Empty;
            indicesGen = string.Empty;
            propiedadesGen = string.Empty;

            procesarDataView();
            obtieneIndices();
            claseGen += "[ANC_Tabla(Nombre = \"" + tabla + "\")] ";
            claseGen += saltoLinea;
            claseGen += indicesGen;
            claseGen += saltoLinea;

            claseGen += "public class @tabla : CLASE_BASE " + saltoLinea + " { " + saltoLinea + " @propiedades " + saltoLinea + " } ";
            claseGen = claseGen.Replace("@tabla", tabla);
            claseGen = claseGen.Replace("@propiedades", GeneraPropiedades());

            rtbClaseResult.AppendText(claseGen);
        }

        public void obtieneIndices()
        {
            DataTable dtidx = new DataTable();
            ObservableCollection<indice_base> indiceList = new ObservableCollection<indice_base>();

            qry = " SELECT idx.index_name, idx.COLUMN_NAME, col.data_type "
            + " FROM all_ind_columns idx "
            + " LEFT JOIN all_tab_columns col on idx.table_owner = col.owner and idx.table_name = col.table_name and idx.COLUMN_NAME = col.COLUMN_NAME "
            + " WHERE idx.table_name = '@tabla' "
            + " AND idx.table_owner = 'ERPZMX_REF' ";            

            qry = qry.Replace("@tabla", tabla);

            mibd.ZMX_AbrirConexion();
            dtidx = mibd.ZMX_EjecutarSelectQuery(qry);
            mibd.ZMX_CerrarConexion();

            foreach (var item in dtidx.AsDataView())
            {
                DataRowView row = (DataRowView)item;
                indice_base obj = new indice_base();

                obj.Columna = row["COLUMN_NAME"].ToString();
                obj.Nombre = row["INDEX_NAME"].ToString();
                obj.Tipo = row["DATA_TYPE"].ToString();
                indiceList.Add(obj);
            }

            generaIndices(indiceList);
        }

        public void generaIndices(ObservableCollection<indice_base> lista)
        {
            string AnotacionIndice = string.Empty;
            string AnotacionIndiceFormado = string.Empty;

            foreach (var item in lista)
            {
                AnotacionIndice = string.Empty;
               
                if (item.Nombre.StartsWith("PK") && item.Tipo == "NUMBER")
                {                
                    AnotacionIndiceFormado = string.Empty;
                    AnotacionIndiceFormado += " [ANC_IDFormado(Columna = \"@columna\", Propiedad = \"@columna\")]";
                    AnotacionIndiceFormado = AnotacionIndiceFormado.Replace("@columna", item.Columna);
                    AnotacionIndiceFormado += saltoLinea;
                }

                AnotacionIndice += "  [ANC_Identificador(Columna = \"@columna\", Propiedad = \"@columna\")]";
                AnotacionIndice = AnotacionIndice.Replace("@columna", item.Columna);
                AnotacionIndice += saltoLinea;

                indicesGen += AnotacionIndice;
            }
            indicesGen += AnotacionIndiceFormado;
        }

        public void procesarDataView()
        {
            propiedadeslist = new ObservableCollection<propiedad_base>();

            foreach (var item in dgTabla.Items)
            {
                propiedad_base obj = new propiedad_base();
                DataRowView row = (DataRowView)item;

                if (row["COLUMN_NAME"].ToString() != "USUREG"
                     && row["COLUMN_NAME"].ToString() != "FECHA_CREACION"
                      && row["COLUMN_NAME"].ToString() != "USUARIO_CREACION"
                       && row["COLUMN_NAME"].ToString() != "FECHA_MODIFICACION"
                        && row["COLUMN_NAME"].ToString() != "ULTIMA_ACT")
                {


                    obj.columna = row["COLUMN_NAME"].ToString();
                    obj.tipo = row["DATA_TYPE"].ToString();
                    obj.longitud = Convert.ToInt32(row["DATA_LENGTH"].ToString());

                    int precision = Convert.ToInt32(row["DATA_PRECISION"].ToString() != "" ? row["DATA_PRECISION"].ToString() : "0");
                    obj.precision = precision;

                    int decimales = Convert.ToInt32(row["DATA_SCALE"].ToString() != "" ? row["DATA_SCALE"].ToString() : "0");
                    obj.decimales = decimales;

                    obj.nullable = row["NULLABLE"].ToString() == "Y" ? true : false;
                    propiedadeslist.Add(obj);
                }
            }
        }

        public string GeneraPropiedades()
        {
            string propiedad = string.Empty;

            string AnotacionConfig = string.Empty;
            string AnotacionStringMax = string.Empty;
            string AnotacionDecimalPrecision = string.Empty;
            string AnotacionNumberPrecision = string.Empty;
            string AnotacionColumna = string.Empty;

            String DeclaracionString = string.Empty;
            String DeclaracionInt64 = string.Empty;
            String DeclaracionDecimal = string.Empty;
            String DeclaracionBoolean = string.Empty;
            String DeclaracionDate = string.Empty;
            String DeclaracionBlob = string.Empty;

            foreach (var item in propiedadeslist)
            {
                AnotacionConfig = " [ANP_Configuracion(Nullable = @valor)]";
                AnotacionColumna = "[ANP_Columna(Columna = \"@columna\")]";
                AnotacionStringMax = " [ANP_LongitudString(Maxima = @valor)]";
                AnotacionDecimalPrecision = " [ANP_PrecisionNumerica(Enteros = @enteros, Decimales = @decimales)]";
                AnotacionNumberPrecision = " [ANP_PrecisionNumerica(Enteros = @enteros)]";

                DeclaracionString = " public String @columna { get; set; } ";
                DeclaracionInt64 = " public Int64? @columna { get; set; }";
                DeclaracionDecimal = " public Decimal? @columna { get; set; }";
                DeclaracionBoolean = " public Boolean? @columna { get; set; }";
                DeclaracionDate = " public DateTime? @columna { get; set; }";
                DeclaracionBlob = " public Byte[] @columna { get; set; }";


                switch (item.tipo)
                {

                    #region NCLOB 
                    case "NCLOB":
                        {
                            propiedad = string.Empty;

                            propiedad += AnotacionConfig.Replace("@valor", item.nullable.ToString().ToLower());
                            propiedad += saltoLinea;
                            propiedad += AnotacionStringMax.Replace("@valor", item.longitud.ToString());
                            propiedad += saltoLinea;
                            propiedad += AnotacionColumna.Replace("@columna", item.columna.ToString());
                            propiedad += saltoLinea;
                            propiedad += DeclaracionString.Replace("@columna", item.columna.ToString());
                            propiedadesGen += saltoLinea;
                            propiedadesGen += propiedad;
                            propiedadesGen += saltoLinea;

                        }
                        break;

                    #endregion

                    #region CHAR                   
                    case "CHAR":
                        {
                            propiedad = string.Empty;

                            propiedad += AnotacionConfig.Replace("@valor", item.nullable.ToString().ToLower());
                            propiedad += saltoLinea;
                            propiedad += AnotacionStringMax.Replace("@valor", item.longitud.ToString());
                            propiedad += saltoLinea;
                            propiedad += AnotacionColumna.Replace("@columna", item.columna.ToString());
                            propiedad += saltoLinea;
                            propiedad += DeclaracionString.Replace("@columna", item.columna.ToString());
                            propiedadesGen += saltoLinea;
                            propiedadesGen += propiedad;
                            propiedadesGen += saltoLinea;

                        }
                        break;
                    #endregion

                    #region VARCHAR
                    case "VARCHAR2":
                        {
                            propiedad = string.Empty;

                            propiedad += AnotacionConfig.Replace("@valor", item.nullable.ToString().ToLower());
                            propiedad += saltoLinea;
                            propiedad += AnotacionStringMax.Replace("@valor", item.longitud.ToString());
                            propiedad += saltoLinea;
                            propiedad += AnotacionColumna.Replace("@columna", item.columna.ToString());
                            propiedad += saltoLinea;
                            propiedad += DeclaracionString.Replace("@columna", item.columna.ToString());
                            propiedadesGen += saltoLinea;
                            propiedadesGen += propiedad;
                            propiedadesGen += saltoLinea;

                        }
                        break;

                    #endregion

                    #region NUMBER

                    case "NUMBER":
                        {
                            propiedad = string.Empty;

                            propiedad += AnotacionConfig.Replace("@valor", item.nullable.ToString().ToLower());
                            propiedad += saltoLinea;
                            if (item.precision > 0 && item.decimales > 0)
                            {
                                AnotacionDecimalPrecision = AnotacionDecimalPrecision.Replace("@decimales", item.decimales.ToString());
                                AnotacionDecimalPrecision = AnotacionDecimalPrecision.Replace("@enteros", (item.precision - item.decimales).ToString());
                                propiedad += AnotacionDecimalPrecision;
                                propiedad += saltoLinea;
                                propiedad += AnotacionColumna.Replace("@columna", item.columna.ToString());
                                propiedad += saltoLinea;
                                propiedad += DeclaracionDecimal.Replace("@columna", item.columna.ToString());
                                propiedadesGen += saltoLinea;
                                propiedadesGen += propiedad;
                                propiedadesGen += saltoLinea;
                            }
                            else if (item.precision == 1 && item.decimales == 0)
                            {
                                // SECCION PARA CONTEMPLAR BOOLEANS EN ORACLE

                                propiedad += AnotacionColumna.Replace("@columna", item.columna.ToString());
                                propiedad += saltoLinea;
                                propiedad += DeclaracionBoolean.Replace("@columna", item.columna.ToString());
                                propiedadesGen += saltoLinea;
                                propiedadesGen += propiedad;
                                propiedadesGen += saltoLinea;
                            }
                            else
                            {
                                propiedad += AnotacionNumberPrecision.Replace("@enteros", item.precision.ToString());
                                propiedad += saltoLinea;
                                propiedad += AnotacionColumna.Replace("@columna", item.columna.ToString());
                                propiedad += saltoLinea;
                                propiedad += DeclaracionInt64.Replace("@columna", item.columna.ToString());
                                propiedadesGen += saltoLinea;
                                propiedadesGen += propiedad;
                                propiedadesGen += saltoLinea;
                            }
                        }
                        break;
                    #endregion                   

                    #region BLOB
                    case "BLOB":
                        {
                            propiedad = string.Empty;
                            propiedad += AnotacionConfig.Replace("@valor", item.nullable.ToString().ToLower());
                            propiedad += saltoLinea;
                            propiedad += AnotacionColumna.Replace("@columna", item.columna.ToString());
                            propiedad += saltoLinea;
                            propiedad += DeclaracionBlob.Replace("@columna", item.columna.ToString());
                            propiedadesGen += saltoLinea;
                            propiedadesGen += propiedad;
                            propiedadesGen += saltoLinea;
                        }
                        break;
                    #endregion

                    #region DATE
                    case "DATE":
                        {
                            propiedad = string.Empty;
                            propiedad += AnotacionConfig.Replace("@valor", item.nullable.ToString().ToLower());
                            propiedad += saltoLinea;
                            propiedad += AnotacionColumna.Replace("@columna", item.columna.ToString());
                            propiedad += saltoLinea;
                            propiedad += DeclaracionDate.Replace("@columna", item.columna.ToString());
                            propiedadesGen += saltoLinea;
                            propiedadesGen += propiedad;
                            propiedadesGen += saltoLinea;
                        }
                        break;
                        #endregion

                }
            }


            return propiedadesGen;
        }

    }
}
