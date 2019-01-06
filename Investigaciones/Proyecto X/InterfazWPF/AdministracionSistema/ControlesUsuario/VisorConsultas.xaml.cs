using Dominio;
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

namespace InterfazWPF.AdministracionSistema.ControlesUsuario
{
    /// <summary>
    /// Lógica de interacción para VisorConsultas.xaml
    /// </summary>
    public partial class VisorConsultas : Window
    {
        public VisorConsultas()
        {
            InitializeComponent();
            
        }
        public void MostrarConsulta(String titulo, DataTable dtConsulta)
        {
            this.Title = titulo;
            dgv_data.ItemsSource = dtConsulta.AsDataView();
            dgv_data.IsReadOnly = true;
        }
    }
}
