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
using Telerik.Windows.Controls;
using UserControlsSIZ.Utilerias;

namespace UserControlsSIZ.Prompt
{
    /// <summary>
    /// Interaction logic for PromptVisor.xaml
    /// </summary>
    public partial class ZMXUCPromptVisor : UserControl
    {

        public delegate void _ZMX_SeleccionoRow(DataRow drSelecionado);
        public event _ZMX_SeleccionoRow ZMX_SeleccionoRow;

        public ZMXUCPrompt ZMX_PromptGenerico { get; set; }

        public ZMXUCPromptVisor()
        {
            InitializeComponent();
            txtFiltro.Focus();
        }

        Dictionary<String, String> columnasMostrar = new Dictionary<string, string>();
        
        public void SetDataTable(DataTable dt, Dictionary<String, String> columnasMostrar)
        {
            foreach (String key in columnasMostrar.Keys)
            {
                GridViewDataColumn gvc = new GridViewDataColumn();
                gvc.Header = columnasMostrar[key].Split('|')[0];
                double ancho = Convert.ToDouble(columnasMostrar[key].Split('|')[1]);
                if (ancho != 0)
                    gvc.Width = ancho;
                gvc.DataMemberBinding = new Binding(key);

                rgvElementos.Columns.Add(gvc);
            }


            rgvElementos.ItemsSource = dt;
            rgvElementos.Items.Refresh();

        }

        private void RadGridView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (rgvElementos.SelectedItem != null)
            {
                //validando lo de cuentas contables
                if(ZMX_ModoCuentaContable)
                {
                    DataRow drCuenta = (DataRow)rgvElementos.SelectedItem;

                    if(string.IsNullOrEmpty(ZMX_ContabilidadEstatusIDPath))
                    {
                        throw new Exception("Es necesario indicar 'ZMX_ContabilidadEstatusIDPath' en el prompt de cuentas contables.");
                    }

                    if (string.IsNullOrEmpty(ZMX_ContabilidadCuentaRegistroPath))
                    {
                        throw new Exception("Es necesario indicar 'ZMX_ContabilidadCuentaRegistroPath' en el prompt de cuentas contables.");
                    }
                    int estatusID = 0;
                    Boolean cuentaRegistro = false;
                    try
                    {
                        estatusID = Convert.ToInt32(drCuenta[ZMX_ContabilidadEstatusIDPath]);
                    }
                    catch
                    {
                        throw new Exception("El path 'ZMX_ContabilidadEstatusIDPath' con valor '"+ ZMX_ContabilidadEstatusIDPath + "' no se encuentra en el resultado de la consulta.");
                    }
                    try
                    {
                        cuentaRegistro = Convert.ToBoolean(drCuenta[ZMX_ContabilidadCuentaRegistroPath]);
                    }
                    catch
                    {
                        throw new Exception("El path 'ZMX_ContabilidadCuentaRegistroPath' con valor '" + ZMX_ContabilidadCuentaRegistroPath + "' no se encuentra en el resultado de la consulta.");
                    }
                    
                    if(estatusID == 2)
                    {
                        ZMXUC_MessageBoxERP.Show("Cuenta contable Inactiva.", "", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                    if (!cuentaRegistro)
                    {
                        ZMXUC_MessageBoxERP.Show("Cuenta contable no es de registro.", "", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                }
                else
                {
                    //se aplican validaciones para catalogos genericos de acuerdo a las banderas
                    DataRow drSeleccionado = (DataRow)rgvElementos.SelectedItem;
                    ZMX_PromptGenerico.ZMX_ValidarInactivo(drSeleccionado);
                    ZMX_PromptGenerico.ZMX_ValidarNoExiste(drSeleccionado);

                }
                //termina validacion de cuentas contables
                if (ZMX_SeleccionoRow != null)
                {
                    ZMX_SeleccionoRow((DataRow)rgvElementos.SelectedItem);
                }
            }
        }
        

        public String ZMX_ContabilidadEstatusIDPath { get; set; }
        public String ZMX_ContabilidadCuentaRegistroPath { get; set; }
        public Boolean ZMX_ModoCuentaContable { get; set; }
    }
}

