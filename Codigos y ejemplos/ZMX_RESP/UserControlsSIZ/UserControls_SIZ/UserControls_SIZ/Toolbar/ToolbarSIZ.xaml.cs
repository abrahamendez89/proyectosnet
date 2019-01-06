using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UserControlsSIZ.Utilerias;

namespace UserControlsSIZ.Toolbar
{
    /// <summary>
    /// Interaction logic for ToolbarSIZ.xaml
    /// </summary>
    public partial class ToolbarSIZ : UserControl
    {
        public ToolbarSIZ()
        {
            InitializeComponent();
        }

        public enum TipoToolbar
        {
            Buzon = 1,
            Catalogo = 2,
            Transaccion = 3,
            Autorizacion = 4,
            Bitacora = 5,
            Consulta = 6,
            Detalle = 7,
            ReImpresion = 9,
            Ejecutar = 10
        }
        public enum Ambientes
        {
            Desarrollo = 0,
            Pruebas = 1,
            PreProduccion = 2,
            Produccion = 3
        }
        #region propiedades gráficas
        private Color toolbarColorBase;
        public Color ToolbarColorBase { get { return toolbarColorBase; } set { SetColor(value); toolbarColorBase = value; } }

        private double diametro;
        public double DiametroPxBotones { get { return diametro; } set { diametro = value; CambiarDiametros(value); } }

        private void CambiarDiametros(double valor)
        {
            foreach (ToolbarBtn btnToolbar in stpOperacionales.Children)
            {
                btnToolbar.DiametroPx = valor;
            }
            foreach (ToolbarBtn btnToolbar in stpSistema.Children)
            {
                btnToolbar.DiametroPx = valor;
            }
            foreach (ToolbarBtn btnToolbar in stpNavegacion.Children)
            {
                btnToolbar.DiametroPx = valor;
            }
        }

        private double toolbarFontSize;
        public double ToolbarFontSize { get { return toolbarFontSize; } set { setFontSize(value); toolbarFontSize = value; } }

        private void setFontSize(double valor)
        {
            foreach (ToolbarBtn btnToolbar in stpOperacionales.Children)
            {
                btnToolbar.ToolbarBtnFontSize = valor;
            }
            foreach (ToolbarBtn btnToolbar in stpSistema.Children)
            {
                btnToolbar.ToolbarBtnFontSize = valor;
            }
            foreach (ToolbarBtn btnToolbar in stpNavegacion.Children)
            {
                btnToolbar.ToolbarBtnFontSize = valor;
            }
        }

        private void SetColor(Color color)
        {
            foreach(ToolbarBtn btnToolbar in stpOperacionales.Children)
            {
                btnToolbar.BtnColor = color;
            }
            foreach (ToolbarBtn btnToolbar in stpSistema.Children)
            {
                btnToolbar.BtnColor = color;
            }
            foreach (ToolbarBtn btnToolbar in stpNavegacion.Children)
            {
                btnToolbar.BtnColor = color;
            }

            BrushConverter bc = new BrushConverter();
            rtgLinea.Fill = new SolidColorBrush(color);
            txtGrupoEmpresa.Foreground = new SolidColorBrush( Colores.AclararColor(color, 20));
            txtPantallaNombre.Foreground = new SolidColorBrush(Colores.OscurecerColor(color, 70));
        }
        #endregion

        public String Empresa_Grupo { get { return txtGrupoEmpresa.Text; } set { txtGrupoEmpresa.Text = value; } }
        public String NombrePantalla { get { return txtPantallaNombre.Text; } set { txtPantallaNombre.Text = value; } }

        private TipoToolbar toolbarZMXTipo;
        public TipoToolbar ToolbarZMXTipo
        {
            get { return toolbarZMXTipo; }
            set {



                toolbarZMXTipo = value;

                //switch (value)
                //{
                //    case TipoToolbar.Buzon:

                }
        }

    }
}
