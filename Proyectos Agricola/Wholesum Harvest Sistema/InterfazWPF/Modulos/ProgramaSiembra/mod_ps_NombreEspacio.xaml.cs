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
using Dominio.Modulos.ProgramaSiembra;

namespace InterfazWPF.Modulos.ProgramaSiembra
{
    /// <summary>
    /// Lógica de interacción para win_ps_NombreEspacio.xaml
    /// </summary>
    public partial class mod_ps_NombreEspacio : Window
    {
        _ps_EspacioFisico espacio;
        public Boolean SeAcepto { get; set; }
        public mod_ps_NombreEspacio(_ps_EspacioFisico espacio)
        {
            InitializeComponent();
            this.espacio = espacio;
            txt_NombreEspacio.Text = espacio.st_Nombre_espacio;
            chb_EsEspacioFinal.IsChecked = espacio.Bo_esEspacioFinal;
            espacio.EsModificado = true;
        }

        private void btn_Cancelar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void btn_Aceptar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            espacio.st_Nombre_espacio = txt_NombreEspacio.Text.Trim();
            espacio.Bo_esEspacioFinal = (Boolean)chb_EsEspacioFinal.IsChecked;
            SeAcepto = true;
            Close();
        }
    }
}
