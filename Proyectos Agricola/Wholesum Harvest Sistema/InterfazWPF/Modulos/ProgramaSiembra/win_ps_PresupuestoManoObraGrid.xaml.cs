using Dominio;
using InterfazWPF.AdministracionSistema;
using LogicaNegocios.ProgramaSiembra;
using LogicaNegocios.ProgramaSiembra.Clases;
using System;
using System.Collections.Generic;
using System.Data;
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
using Herramientas.ORM;
using Dominio.Modulos.General;

namespace InterfazWPF.Modulos.ProgramaSiembra
{
    /// <summary>
    /// Lógica de interacción para win_ps_PresupuestoManoObraGrid.xaml
    /// </summary>
    /// 
    public partial class win_ps_PresupuestoManoObraGrid : Window
    {
        DataTable tablaDatos;
        ManejadorDB manejador;
        Presupuesto presupuesto;
        public win_ps_PresupuestoManoObraGrid()
        {
            InitializeComponent();
            manejador = new ManejadorDB();
            //CargarDatos();

        }
        private void CargarDatos()
        {
            _gen_Temporada temporada = manejador.Cargar<_gen_Temporada>(_gen_Temporada.ConsultaPorID, new List<object>() { 1 });

            presupuesto = ps_ln_Presupuesto.ObtenerPresupuestoManoObra(temporada, Convert.ToDouble(HerramientasWindow.ObtenerValorVariable(manejador, "SALARIO_DIARIO")));
            tablaDatos = CrearEstructuraTabla();
        }
        private DataTable InsertarValoresCostos(DataTable tablaDatos, Presupuesto presupuesto)
        {
            foreach (EspacioFisico espacio in presupuesto.Espacios)
            {
                foreach (PerfilActividad perfil in espacio.Perfiles)
                {
                    foreach (Actividad actividad in perfil.Actividades)
                    {
                        String[] datos = new string[56];

                        datos[0] = espacio.Espacio.st_Nombre_espacio;
                        datos[1] = perfil.Perfil.St_NombrePerfil;
                        datos[2] = actividad.ActividadDominio.In_idCrop + " - " + actividad.ActividadDominio.St_Nombre;

                        for (int i = 0; i < 52; i++)
                        {
                            datos[i + 3] = Herramientas.Conversiones.Formatos.DoubleRedondearANDecimalesString(actividad.GastoPorSemana[i], 2);
                        }

                        datos[55] = Herramientas.Conversiones.Formatos.DoubleRedondearANDecimalesString(actividad.CostoTotalTemporada, 2);

                        tablaDatos.Rows.Add(datos);

                    }
                }
            }
            return tablaDatos;
        }
        private DataTable InsertarValoresJornales(DataTable tablaDatos, Presupuesto presupuesto)
        {
            foreach (EspacioFisico espacio in presupuesto.Espacios)
            {
                foreach (PerfilActividad perfil in espacio.Perfiles)
                {
                    foreach (Actividad actividad in perfil.Actividades)
                    {
                        String[] datos = new string[56];

                        datos[0] = espacio.Espacio.st_Nombre_espacio;
                        datos[1] = perfil.Perfil.St_NombrePerfil;
                        datos[2] = actividad.ActividadDominio.In_idCrop + " - " + actividad.ActividadDominio.St_Nombre;

                        for (int i = 0; i < 52; i++)
                        {
                            datos[i + 3] = Herramientas.Conversiones.Formatos.DoubleRedondearANDecimalesString(actividad.JornalesPorSemana[i], 2);
                        }

                        datos[55] = Herramientas.Conversiones.Formatos.DoubleRedondearANDecimalesString(actividad.JornalesTotalTemporada, 2);

                        tablaDatos.Rows.Add(datos);

                    }
                }
            }
            return tablaDatos;
        }
        private DataTable CrearEstructuraTabla()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(CrearColumna("Espacio", typeof(String)));
            dt.Columns.Add(CrearColumna("Perfil", typeof(String)));
            dt.Columns.Add(CrearColumna("Actividad", typeof(String)));

            for (int i = 0; i < 52; i++)
                dt.Columns.Add(CrearColumna("Semana " + (i + 1), typeof(String)));

            dt.Columns.Add(CrearColumna("Total", typeof(String)));

            return dt;
        }

        private DataColumn CrearColumna(String nombre, Type tipo)
        {
            DataColumn c = new DataColumn();
            c.Caption = nombre;
            c.DataType = tipo;
            c.ReadOnly = false;
            c.MaxLength = 10000;
            c.ColumnName = nombre;
            return c;
        }

        private void btn_exportarExcel_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Herramientas.Forms.ExcelAPI excel = new Herramientas.Forms.ExcelAPI();
            String ruta = Herramientas.Archivos.Dialogos.GuardarArchivoRuta(new List<string>() { "Archivo de excel" }, new List<string>() { "xls" },"Presupuesto_Mano_de_obra_" + Herramientas.Conversiones.Formatos.DateTimeAFechaLOGArchivo(DateTime.Now) + ".xls");
            excel.ConvertirDataTableAExcel(ruta, tablaDatos);
            excel.terminoConversion += excel_terminoConversion;
        }

        void excel_terminoConversion(string rutaGuardado)
        {
            Dispatcher.Invoke(new Action(() =>
            {
                HerramientasWindow.MostrarNotificacion("Exportación terminada.", "Excel");
            }));
        }

        private void btn_cargar_MouseUp(object sender, MouseButtonEventArgs e)
        {
            CargarDatos();
            tablaDatos = InsertarValoresCostos(tablaDatos, presupuesto);
            dgv_totalesTemporada.ItemsSource = tablaDatos.AsDataView();
            dgv_totalesTemporada.IsReadOnly = true;
        }

        private void btn_cargar_jornales_MouseUp(object sender, MouseButtonEventArgs e)
        {
            CargarDatos();
            tablaDatos = InsertarValoresJornales(tablaDatos, presupuesto);
            dgv_totalesTemporada.ItemsSource = tablaDatos.AsDataView();
            dgv_totalesTemporada.IsReadOnly = true;
        }

    }
}
