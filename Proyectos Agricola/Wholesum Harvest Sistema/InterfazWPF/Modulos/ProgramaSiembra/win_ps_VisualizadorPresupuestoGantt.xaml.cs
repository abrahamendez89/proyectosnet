using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GanttView;
using Telerik.Windows.Controls.Scheduling;
using LogicaNegocios.ProgramaSiembra;
using LogicaNegocios.ProgramaSiembra.Clases;
using InterfazWPF.AdministracionSistema;
using Dominio;
using Herramientas.ORM;
using Dominio.Modulos.General;

namespace InterfazWPF.Modulos.ProgramaSiembra
{
    /// <summary>
    /// Lógica de interacción para win_ps_VisualizadorPresupuesto.xaml
    /// </summary>
    public partial class win_ps_VisualizadorPresupuestoGantt : Window
    {
        ObservableCollection<GanttTask> tasks;
        ManejadorDB manejador;
        public win_ps_VisualizadorPresupuestoGantt()
        {
            InitializeComponent();

            manejador = new ManejadorDB();
            StyleManager.SetTheme(xGanttView, new Windows8Theme());
                        
            tasks = new ObservableCollection<GanttTask>();

            _gen_Temporada temporada = manejador.Cargar<_gen_Temporada>(_gen_Temporada.ConsultaPorID, new List<object>() { 1 });


            Presupuesto presupuesto = ps_ln_Presupuesto.ObtenerPresupuestoManoObra(temporada, Convert.ToDouble(HerramientasWindow.ObtenerValorVariable(manejador, "SALARIO_DIARIO")));

            xGanttView.VisibleRange = new VisibleRange(presupuesto.FechaMenor.AddDays(-7), presupuesto.FechaMayor.AddDays(7));
            xGanttView.PixelLength = new TimeSpan(0, 6, 0, 0);
            foreach (EspacioFisico espacioFisico in presupuesto.Espacios)
            {
                GanttTask Espacio = new GanttTask(espacioFisico.FechaMenor, espacioFisico.FechaMayor); //DateTime.Now, DateTime.Now.AddDays(10), "Siembra de calabaza.");
                Espacio.Title = espacioFisico.Espacio.st_Nombre_espacio;
                foreach (PerfilActividad perfilActividad in espacioFisico.Perfiles)
                {
                    GanttTask perfil = new GanttTask(perfilActividad.FechaMenor, perfilActividad.FechaMayor); //DateTime.Now, DateTime.Now.AddDays(10), "Siembra de calabaza.");
                    perfil.Title = perfilActividad.Perfil.St_NombrePerfil;

                    foreach (Actividad actividad in perfilActividad.Actividades)
                    {

                        GanttTask act = new GanttTask();
                        act.Title = actividad.ActividadDominio.In_idCrop+ " - "+ actividad.ActividadDominio.St_Nombre;
                        act.Start = actividad.Fechas[0];
                        act.End = actividad.Fechas[actividad.Fechas.Count - 1];
                        //act.AddDependency(perfil, DependencyType.FinishStart);

                        perfil.Children.Add(act);

                    }
                    //tasks.Add(perfil);
                    Espacio.Children.Add(perfil);
                }
                tasks.Add(Espacio);
            }

            //GanttTask t1 = new GanttTask(DateTime.Now, DateTime.Now.AddDays(10), "Siembra de calabaza.");

            //GanttTask t11 = new GanttTask();
            //t11.Title = "Siembra";
            //t11.Start = t1.Start;
            //t11.Duration = new TimeSpan(5, 0, 0, 0);
            //t11.PropertyChanged += t12_PropertyChanged;
            //GanttTask t12 = new GanttTask();
            //t12.Start = t11.End;
            //t12.Title = "Planteo";
            //t12.Duration = new TimeSpan(8, 0, 0, 0);
            //t12.PropertyChanged += t12_PropertyChanged;
            //t12.AddDependency(t11, DependencyType.FinishStart);

            //t1.Children.Add(t11);
            //t1.Children.Add(t12);

            //tasks.Add(t1);

            xGanttView.TasksSource = tasks;
        }

        void t12_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            GanttTask gt = (GanttTask)sender;

            foreach (Dependency task in gt.Dependencies)
            {
                task.FromTask.End = gt.Start;

            }

            GanttTask tsk = ObtenerPadre(gt);
            if (tsk != null)
            {
                if (gt.End > tsk.End)
                {
                    tsk.End = gt.End;
                }
            }
        }

        private GanttTask ObtenerPadre(GanttTask child)
        {
            foreach (GanttTask task in tasks)
            {
                if (task.Children.Contains(child))
                    return task;
            }
            return null;
        }

        private void xGanttView_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            
        }
    }
}
