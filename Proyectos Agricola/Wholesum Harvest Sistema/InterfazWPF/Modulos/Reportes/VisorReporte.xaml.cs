using CrystalDecisions.CrystalReports.Engine;
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

namespace InterfazWPF.Modulos.Reportes
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class VisorReporte : Window
    {
        public VisorReporte(ReportClass reporte)
        {
            InitializeComponent();
            //reporteCrystal.ParameterFields.Add("", CrystalDecisions.Shared.ParameterValueKind.StringParameter, CrystalDecisions.Shared.DiscreteOrRangeKind.DiscreteValue);
            rpt_visor.ViewerCore.ReportSource = reporte;
            //rpt_visor.ViewerCore.RefreshReport();

            WindowState = System.Windows.WindowState.Maximized;
        }
    }
}
