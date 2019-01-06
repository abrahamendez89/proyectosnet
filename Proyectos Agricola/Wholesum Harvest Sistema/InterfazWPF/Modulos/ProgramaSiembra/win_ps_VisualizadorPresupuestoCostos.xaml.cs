using LogicaNegocios.ProgramaSiembra.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Telerik.Windows.Controls.Charting;
using LogicaNegocios.ProgramaSiembra;
using Dominio;
using InterfazWPF.AdministracionSistema;
using System.Reflection.Emit;
using System.Reflection;
using Herramientas.ORM;
using Dominio.Modulos.General;

namespace InterfazWPF.Modulos.ProgramaSiembra
{
    /// <summary>
    /// Lógica de interacción para win_ps_VisualizadorPresupuestoCostos.xaml
    /// </summary>
    public partial class win_ps_VisualizadorPresupuestoCostos : Window
    {
        ManejadorDB manejador;
        Presupuesto presupuesto;
        public win_ps_VisualizadorPresupuestoCostos()
        {
            InitializeComponent();
            //radChart.SamplingSettings.SamplingFunction = ChartSamplingFunction.Average;
            //radChart.SamplingSettings.SamplingThreshold = 100;
            manejador = new ManejadorDB();
            radChart.DefaultView.ChartArea.AxisX.LabelRotationAngle = -90;
            radChart.DefaultView.ChartArea.AxisX.LabelStep = 1;
            radChart.DefaultView.ChartArea.ItemWidthPercent = 10;
            radChart.DefaultView.ChartArea.ZoomScrollSettingsX.ScrollMode = ScrollMode.ScrollAndZoom;
            radChart.DefaultView.ChartArea.AxisX.Title = "Semana";
            radChart.DefaultView.ChartArea.AxisY.Title = "Cantidad";

            CrearModelosVacios();
            _gen_Temporada temporada = manejador.Cargar<_gen_Temporada>(_gen_Temporada.ConsultaPorID, new List<object>() { 1 });

            presupuesto = ps_ln_Presupuesto.ObtenerPresupuestoManoObra(temporada, Convert.ToDouble(HerramientasWindow.ObtenerValorVariable(manejador, "SALARIO_DIARIO")));

            cmb_espacios.Items.Add("Todos");
            foreach (EspacioFisico espacio in presupuesto.Espacios)
            {
                cmb_espacios.Items.Add(espacio.Espacio.st_Nombre_espacio);
            }

            cmb_filtro.Items.Add("Costos de actividades");
            cmb_filtro.Items.Add("Jornales necesarios");

            cmb_filtro.SelectionChanged += cmb_filtro_SelectionChanged;

            btn_mostrarEspacio.MouseUp += btn_mostrarEspacio_MouseUp;




        }
        void cmb_filtro_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            radChart.SeriesMappings.Clear();
            radChart.UpdateLayout();
            this.radChart.ItemsSource = null;
        }

        void btn_mostrarEspacio_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (cmb_espacios.SelectedIndex >= 1)
            {
                if (cmb_filtro.SelectedIndex == 0)
                {
                    AgregarGrafica(presupuesto.Espacios[cmb_espacios.SelectedIndex - 1].Espacio.st_Nombre_espacio, presupuesto.Espacios[cmb_espacios.SelectedIndex - 1].SumatoriaCostosPorSemanaActividades);
                }
                else if (cmb_filtro.SelectedIndex == 1)
                {
                    AgregarGrafica(presupuesto.Espacios[cmb_espacios.SelectedIndex - 1].Espacio.st_Nombre_espacio, presupuesto.Espacios[cmb_espacios.SelectedIndex - 1].SumatoriaJornalesPorSemana);
                }
            }
            else if (cmb_espacios.SelectedIndex == 0)
            {
                if (cmb_filtro.SelectedIndex == 0)
                {
                    AgregarGrafica("Totales", presupuesto.CostoTotalPorSemanaActividades);
                }
                else if (cmb_filtro.SelectedIndex == 1)
                {
                    AgregarGrafica("Totales", presupuesto.JornalesTotalesPorSemanaActividades);
                }
            }
        }
        private void AgregarGrafica(String nombre, Double[] cantidades)
        {
            
            int indice = radChart.SeriesMappings.Count;

            if (indice == 10)
            {
                HerramientasWindow.MensajeInformacion("Solo se pueden graficar 10 espacios a la vez.", "Atención!");
                return;
            }

            SeriesMapping serie = new SeriesMapping();
            serie.LegendLabel = nombre;
            serie.SeriesDefinition = new SplineSeriesDefinition();
            serie.ItemMappings.Add(new ItemMapping("C" + indice, DataPointMember.YValue));
            serie.ItemMappings.Add(new ItemMapping("Semana", DataPointMember.XValue));
           
            this.radChart.ItemsSource = this.CreateData(indice, cantidades);

            radChart.SeriesMappings.Add(serie);

            this.radChart.UpdateLayout();
        }
        List<ModeloGrafica> modelos = new List<ModeloGrafica>();
        private void CrearModelosVacios()
        {
            for (int i = 0; i < 52; i++)
            {
                ModeloGrafica modelo = new ModeloGrafica();
                modelo.Semana = i;
                modelo.C0 = 0;
                modelo.C1 = 0;
                modelo.C2 = 0;
                modelo.C3 = 0;
                modelo.C4 = 0;
                modelo.C5 = 0;
                modelo.C6 = 0;
                modelo.C7 = 0;
                modelo.C8 = 0;
                modelo.C9 = 0;

                modelos.Add(modelo);
            }
        }
        private List<ModeloGrafica> CreateData(int indice, Double[] montos)
        {
            List<DateTime> fechasSemanasInicio = new List<DateTime>();
            List<DateTime> fechasSemanasFin = new List<DateTime>();
            List<Double> Sumas = new List<Double>();
            List<int> trabajadores = new List<int>();

            for (int i = 0; i < 52; i++)
            {
                ModeloGrafica modelo = modelos[i];
                //modelo.Semana = i;

                if (indice == 0) modelo.C0 = montos[i];
                if (indice == 1) modelo.C1 = montos[i];
                if (indice == 2) modelo.C2 = montos[i];
                if (indice == 3) modelo.C3 = montos[i];
                if (indice == 4) modelo.C4 = montos[i];
                if (indice == 5) modelo.C5 = montos[i];
                if (indice == 6) modelo.C6 = montos[i];
                if (indice == 7) modelo.C7 = montos[i];
                if (indice == 8) modelo.C8 = montos[i];
                if (indice == 9) modelo.C9 = montos[i];

            }
            return modelos;
        }
    }
    public class ModeloGrafica
    {
        public double C0 { get; set; }
        public double C1 { get; set; }
        public double C2 { get; set; }
        public double C3 { get; set; }
        public double C4 { get; set; }
        public double C5 { get; set; }
        public double C6 { get; set; }
        public double C7 { get; set; }
        public double C8 { get; set; }
        public double C9 { get; set; }

        //public double Cantidad { get; set; }

        public int Semana { get; set; }
    }
}
