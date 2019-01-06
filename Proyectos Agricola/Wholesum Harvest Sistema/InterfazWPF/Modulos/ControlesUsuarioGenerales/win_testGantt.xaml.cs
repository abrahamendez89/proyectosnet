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

namespace InterfazWPF.Modulos.ControlesUsuarioGenerales
{
    /// <summary>
    /// Lógica de interacción para win_testGantt.xaml
    /// </summary>
    public partial class win_testGantt : Window
    {
        ObservableCollection<GanttTask> tasks;
        public win_testGantt()
        {
            InitializeComponent();
            StyleManager.ApplicationTheme = new TransparentTheme();
            StyleManager.SetTheme(xGanttView, new TransparentTheme());

            //StyleManager.ApplicationTheme = new VistaTheme();


            StyleManager.SetTheme(xGanttView, new VistaTheme());

            var d = DateTime.Today;
            xGanttView.VisibleRange = new VisibleRange(d, d.AddMonths(2));
            xGanttView.PixelLength = new TimeSpan(1, 0, 0, 0);

            

            tasks = new ObservableCollection<GanttTask>();


            GanttTask t1 = new GanttTask(DateTime.Now, DateTime.Now.AddDays(10), "Siembra de calabaza.");

            GanttTask t11 = new GanttTask();
            t11.Title = "Siembra";
            t11.Start = t1.Start;
            t11.Duration = new TimeSpan(5, 0, 0, 0);
            t11.PropertyChanged += t12_PropertyChanged;
            GanttTask t12 = new GanttTask();
            t12.Start = t11.End;
            t12.Title = "Planteo";
            t12.Duration = new TimeSpan(8, 0, 0, 0);
            t12.PropertyChanged += t12_PropertyChanged;
            t12.AddDependency(t11, DependencyType.FinishStart);

            t1.Children.Add(t11);
            t1.Children.Add(t12);

            tasks.Add(t1);

            xGanttView.TasksSource = tasks;
            xGanttView.PixelLength = new TimeSpan(0, 1, 0, 0);
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

    }
}
