using Dominio;
using Dominio.Modulos.ProgramaSiembra;
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
using Dominio.Modulos.General;
using InterfazWPF.AdministracionSistema;
namespace InterfazWPF.Modulos.ProgramaSiembra
{
    /// <summary>
    /// Lógica de interacción para win_ps_ConfiguracionDeVariedadesYTransplantes.xaml
    /// </summary>
    public partial class win_ps_ConfiguracionDeVariedadesYTransplantes : Window
    {
        public win_ps_ConfiguracionDeVariedadesYTransplantes()
        {
            InitializeComponent();
            btn_Iniciartest.MouseDown += Boton_MouseDown_1;
            btn_Agregarlinea.MouseDown += btn_Agregarlinea_MouseDown;
        }

        void btn_Agregarlinea_MouseDown(object sender, MouseButtonEventArgs e)
        {
            contenedorActividadesTEST.ModoRelacion = true;
        }

        private void Boton_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            contenedorActividadesTEST.AgregarElementoActividad(new ElementoActividad());
        }
    }
}
