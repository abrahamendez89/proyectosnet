using Dominio.Modulos.General;
using Herramientas.ORM;
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

namespace InterfazWPF.Modulos.ProgramaSiembra
{
    /// <summary>
    /// Lógica de interacción para win_ps_PresupuestoMaterialesGrid.xaml
    /// </summary>
    public partial class win_ps_PresupuestoMaterialesGrid : Window
    {
        DataTable tablaDatos;
        Presupuesto presupuesto;
        ManejadorDB manejador;
        public win_ps_PresupuestoMaterialesGrid()
        {
            InitializeComponent();
            //CargarDatos();
            manejador = new ManejadorDB();
        }
        private void CargarDatos()
        {
            try
            {
                _gen_Temporada temporada = manejador.Cargar<_gen_Temporada>(_gen_Temporada.ConsultaPorID, new List<object>() { 1 });
                presupuesto = ps_ln_Presupuesto.ObtenerPresupuestoMateriales(temporada);
                //Presupuesto presupuestoAct = ps_ln_Presupuesto.ObtenerPresupuestoManoObra(new DateTime(2015, 7, 2));
                tablaDatos = CrearEstructuraTabla();
                HerramientasWindow.MensajeInformacion("Se calcularon los importes y cantidades correctamente.", "Correcto");
            }
            catch (Exception ex)
            {
                HerramientasWindow.MensajeError(ex, ex.Message, "Error");

            }
        }
        private DataTable InsertarValoresImportes(DataTable tablaDatos, Presupuesto presupuesto)
        {
            foreach (EspacioFisico espacio in presupuesto.Espacios)
            {
                foreach (PerfilActividad perfil in espacio.Perfiles)
                {
                    foreach (Material actividad in perfil.Materiales)
                    {
                        String[] datos = new string[57];

                        datos[0] = espacio.Espacio.st_Nombre_espacio;
                        datos[1] = perfil.Perfil.St_NombrePerfil;
                        datos[2] = actividad.MaterialDominio.In_CodigoCrop + " - " + actividad.MaterialDominio.St_Descripcion;
                        datos[3] = actividad.MaterialDominio.Oo_UnidadMedida.St_Nombre;

                        for (int i = 0; i < 52; i++)
                        {
                            datos[i + 4] = Herramientas.Conversiones.Formatos.DoubleRedondearANDecimalesString(actividad.GastoPorSemana[i], 2);
                        }

                        datos[56] = Herramientas.Conversiones.Formatos.DoubleRedondearANDecimalesString(actividad.CostoTotalTemporada, 2);

                        tablaDatos.Rows.Add(datos);

                    }
                }
            }
            return tablaDatos;
        }
        private DataTable InsertarValoresCantidades(DataTable tablaDatos, Presupuesto presupuesto)
        {
            foreach (EspacioFisico espacio in presupuesto.Espacios)
            {
                foreach (PerfilActividad perfil in espacio.Perfiles)
                {
                    foreach (Material actividad in perfil.Materiales)
                    {
                        String[] datos = new string[57];

                        datos[0] = espacio.Espacio.st_Nombre_espacio;
                        datos[1] = perfil.Perfil.St_NombrePerfil;
                        datos[2] = actividad.MaterialDominio.In_CodigoCrop + " - " + actividad.MaterialDominio.St_Descripcion;
                        datos[3] = actividad.MaterialDominio.Oo_UnidadMedida.St_Nombre;

                        for (int i = 0; i < 52; i++)
                        {
                            datos[i + 4] = Herramientas.Conversiones.Formatos.DoubleRedondearANDecimalesString(actividad.UnidadesPorSemana[i], 2);
                        }

                        datos[56] = Herramientas.Conversiones.Formatos.DoubleRedondearANDecimalesString(actividad.UnidadesTotalestemporada, 2);

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
            dt.Columns.Add(CrearColumna("Material", typeof(String)));
            dt.Columns.Add(CrearColumna("Unidad", typeof(String)));

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
            String ruta = Herramientas.Archivos.Dialogos.GuardarArchivoRuta(new List<string>() { "Archivo de excel" }, new List<string>() { "xls" }, "Presupuesto_Materiales_"+Herramientas.Conversiones.Formatos.DateTimeAFechaLOGArchivo(DateTime.Now) + ".xls");
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

        private void btn_CargarDatos_MouseUp(object sender, MouseButtonEventArgs e)
        {
            CargarDatos();
        }

        private void btn_verCantidades_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (presupuesto == null)
                CargarDatos();
            tablaDatos = CrearEstructuraTabla();
            tablaDatos = InsertarValoresCantidades(tablaDatos, presupuesto);
            dgv_datos.ItemsSource = tablaDatos.AsDataView();
            dgv_datos.IsReadOnly = true;
        }

        private void btn_verImportes_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (presupuesto == null)
                CargarDatos();
            tablaDatos = CrearEstructuraTabla();
            tablaDatos = InsertarValoresImportes(tablaDatos, presupuesto);
            dgv_datos.ItemsSource = tablaDatos.AsDataView();
            dgv_datos.IsReadOnly = true;
        }
    }
}
