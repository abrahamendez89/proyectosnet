using System;
using System.Collections.Generic;
using System.Data;
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
using UserControlsSIZ.Contables;

namespace TestControls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    class Localidades
    {
        public String LOCALIDAD_NOMBRE { get; set; }
        public String MUNICIPIO_NOMBRE { get; set; }
        public String ESTADO_NOMBRE { get; set; }
        public String PAIS_NOMBRE { get; set; }
        public String LOCALIDAD_COORDENADAS { get; set; }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //txtArmarExpresion.SIZUC_BuscarCuentaContable += TxtArmarExpresion_SIZUC_BuscarCuentaContable;
            //txtArmarExpresion.SIZUC_BuscarVariableContable += TxtArmarExpresion_SIZUC_BuscarVariableContable;

            this.SizeChanged += MainWindow_SizeChanged;
            Test t = new Test();
            grdCaptura.DataContext = t;

            mapa.ZMX_BuscarLocalidades += Mapa_ZMX_BuscarLocalidades;

            //txtArmarExpresion.MascaraCuentaContable = "###-####-#####";


            //txtArmarExpresion.SIZUC_CambioExpresion += TxtArmarExpresion_SIZUC_CambioExpresion;


            SIZUCContabilizacion.SetMascaraContable("###-####-#####");

            //txtArmarExpresion.ExpresionFormada = "100-AAA[10&4]";


            prompt.SetColor(Brushes.Blue);

            prompt.ZMX_AgregarColumnaMostrarEnVisor("CODIGO", "Código");
            prompt.ZMX_AgregarColumnaMostrarEnVisor("DESCRIPCION", "Descripción");

            prompt.ZMX_SoloLectura = true;

            Color color = UserControlsSIZ.Utilerias.Colores.AclararColor(UserControlsSIZ.Utilerias.Colores.ConvertirBrushAColor((SolidColorBrush)(new BrushConverter().ConvertFrom("#FF4B84D6"))),25);

            //mapa.SetColor(UserControlsSIZ.Utilerias.Colores.ConvertirColorABrush(color));

            mapa.SetColor(Brushes.DarkGreen);

        }

        private List<object> Mapa_ZMX_BuscarLocalidades(UserControlsSIZ.Maps.ZMXUC_Mapa mapa, String criterioBusqueda)
        {
            List<Localidades> localidades = new List<Localidades>();
            Localidades lo1 = new Localidades();
            lo1.LOCALIDAD_NOMBRE = "CULIACAN";
            lo1.MUNICIPIO_NOMBRE = "CULIACAN";
            lo1.ESTADO_NOMBRE = "SINALOA";
            lo1.PAIS_NOMBRE = "MEXICO";
            lo1.LOCALIDAD_COORDENADAS = "24.799443,-107.394056";
            localidades.Add(lo1);
            //OTRO
            Localidades lo2 = new Localidades();
            lo2.LOCALIDAD_NOMBRE = "MOCHIS";
            lo2.MUNICIPIO_NOMBRE = "MOCHIS";
            lo2.ESTADO_NOMBRE = "SINALOA";
            lo2.PAIS_NOMBRE = "MEXICO";
            lo2.LOCALIDAD_COORDENADAS = "25.806341,-108.994657";
            localidades.Add(lo2);

            Localidades lo3 = new Localidades();
            lo3.LOCALIDAD_NOMBRE = "HERMOSILLO";
            lo3.MUNICIPIO_NOMBRE = "HERMOSILLO";
            lo3.ESTADO_NOMBRE = "SINALOA";
            lo3.PAIS_NOMBRE = "MEXICO";
            lo3.LOCALIDAD_COORDENADAS = "29.115631,-110.981455";
            localidades.Add(lo3);

            localidades = localidades.Where(x => x.LOCALIDAD_NOMBRE.ToUpper().Contains(criterioBusqueda.ToUpper())).ToList();

            List<object> lista = new List<object>();
            localidades.ForEach(x=> lista.Add(x));

            return lista;
        }

        private void TxtArmarExpresion_SIZUC_CambioExpresion(SIZUCContabilizacion objeto, String expresion)
        {
            //txtArmarExpresion.ExpresionFormada = expresion;
        }

        private string TxtArmarExpresion_SIZUC_BuscarVariableContable(UserControlsSIZ.Contables.SIZUCContabilizacion objeto)
        {
            return "ZONA_EXPRESION";
        }

        private string TxtArmarExpresion_SIZUC_BuscarCuentaContable(UserControlsSIZ.Contables.SIZUCContabilizacion objeto)
        {
            return "100";
        }

        private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //btn.DiametroPx = this.Height * 0.2;
            //btn2.DiametroPx = this.Height * 0.2;
            //btn3.DiametroPx = this.Height * 0.2;
        }

        private void btn_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        public class Test
        {
            private String texto;
            public String TEXTO { get { return texto; } set { texto = value; } }
        }

        private DataTable prompt_ZMX_EjecutarConsulta(string codigoBuscar)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("CODIGO");
            dt.Columns.Add("DESCRIPCION");

            dt.Rows.Add("1", "1", "UNO");
            dt.Rows.Add("2", "2", "DOS");
            dt.Rows.Add("3", "3", "TRES");
            dt.Rows.Add("4", "4", "CUATRO");


            if (codigoBuscar == null)
                return dt;
            else
            {
                DataTable dt2 = new DataTable();
                dt2.Columns.Add("ID");
                dt2.Columns.Add("CODIGO");
                dt2.Columns.Add("DESCRIPCION");
                try
                {
                    dt2.ImportRow(dt.Select("CODIGO = " + codigoBuscar)[0]);
                }
                catch { }

                return dt2;
            }

        }

        private void prompt_ZMX_ValorCambiadoRow(DataRow drSeleccionado)
        {
            prompt.ZMX_CerrarPopupVisorPrompt();


            if (drSeleccionado != null)
            {

                prompt.ZMX_ID = drSeleccionado["ID"].ToString();
                prompt.ZMX_CODIGO = drSeleccionado["CODIGO"].ToString();
                prompt.ZMX_DESCRIPCION = drSeleccionado["DESCRIPCION"].ToString();

            }
        }

        private void prompt_ZMX_ValorCambiadoObj(object objSeleccionado)
        {

        }

        private void mapa_ZMX_SeleccionoUbicacion(UserControlsSIZ.Maps.ZMXUC_Mapa mapa, string locacion)
        {

        }
    }
}
