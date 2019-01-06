using ContabilidadElectronica.Formularios;
using Herramientas;
using Herramientas.Forms;
using Herramientas.SQL;
using Herramientas.WPF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ContabilidadElectronica
{
    public partial class Principal : Form
    {
        iSQL sql;
        public static String EmpresaSeleccionada;
        public static String RFCEmpresaSeleccionada;
        public static String NombreEmpresaSeleccionada;
        public static int NRFCEmisor;
        public static String Server;
        public Principal(String server)
        {
            InitializeComponent();
            sql = Login.sql;
            CheckForIllegalCrossThreadCalls = false;
            tp_forms.TabPages.Clear();
            this.WindowState = FormWindowState.Maximized;
            tp_forms.Visible = false;
            pb_cerrarTab.Visible = false;
            pb_cerrarTab.MouseClick += pb_cerrarTab_MouseClick;
            cmb_Empresas.SelectedIndexChanged += cmb_Empresas_SelectedIndexChanged;

            this.Text += "SERVER: " + server;
            Server = server;
            EventosElementosMenu();
            CargarEmpresas();

            //String ruta = @"D:\XML\XML EMITIDOS";

            //String query = "select nFactura, nRFCEmisor, sXMLContenido from empresas..FAC_XMLFACTURAS";

            //DataTable dt = db.EjecutarConsulta(query);

            //foreach (DataRow dr in dt.Rows)
            //{
            //    Herramientas.Archivos.Archivo.GuardarArchivoDeTexto(ruta + @"\" + dr[0].ToString() + dr[1].ToString() + ".xml", dr[2].ToString());
            //}


        }
        #region manejo de las empresas

        void cmb_Empresas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_Empresas.SelectedIndex < 0) return;
            sql.AsignarBD(bdEmpresas[cmb_Empresas.SelectedIndex]);
            RFCEmpresaSeleccionada = RFCEmpresas[cmb_Empresas.SelectedIndex];
            NRFCEmisor = NRFCEmisores[cmb_Empresas.SelectedIndex];
            NombreEmpresaSeleccionada = cmb_Empresas.SelectedItem.ToString();
            if (sql.Reconectar())
            {
                EmpresaSeleccionada = sql.ObtenerBD();
                Mensajes.Informacion("Se conectó correctamente a '" + cmb_Empresas.SelectedItem.ToString().ToLower() + "' (" + sql.ObtenerBD() + ")");
            }
        }
        List<String> bdEmpresas = new List<string>();
        List<String> RFCEmpresas = new List<string>();
        List<int> NRFCEmisores = new List<int>();
        private void CargarEmpresas()
        {
            cmb_Empresas.Items.Clear();
            RFCEmpresas.Clear();
            DataTable dt = sql.EjecutarConsulta("select cEmpresa,CBASEDDATOS, RFCEmisor, CRFC from Empresas..empresas_cnt order by cempresa asc");
            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    NRFCEmisores.Add(Convert.ToInt32(dr["RFCEmisor"].ToString()));
                    cmb_Empresas.Items.Add(dr["cEmpresa"]);
                    bdEmpresas.Add(dr["CBASEDDATOS"].ToString());
                    RFCEmpresas.Add(dr["CRFC"].ToString());
                }
                catch
                {
                    //NRFCEmisores.Add(-1);
                }
            }
        }
        #endregion
        #region Eventos para los elementos del menu
        private void EventosElementosMenu()
        {
            eCatalogo.doubleClickCustom += eCatalogo_doubleClickCustom;
            //eCarga.doubleClickCustom += eCarga_doubleClickCustom;
            //ePolizas.doubleClickCustom += ePolizas_doubleClickCustom;
            eGeneracionXMLCatalogoCuentas.doubleClickCustom += eGeneracionXMLCatalogoCuentas_doubleClickCustom;
            eCatalogoBancos.doubleClickCustom += eCatalogoBancos_doubleClickCustom;
            eCatalogoFormasPago.doubleClickCustom += eCatalogoFormasPago_doubleClickCustom;
            eCatalogoMonedas.doubleClickCustom += eCatalogoMonedas_doubleClickCustom;
            eGeneracionXMLPolizas.doubleClickCustom += eGeneracionXMLPolizas_doubleClickCustom;
            eUnirXMLPolizas.doubleClickCustom += eUnirXMLPolizas_doubleClickCustom;
            eReporteFacturasSinXML.doubleClickCustom += eReporteFacturasSinXML_doubleClickCustom;
            eVisorXML345.doubleClickCustom += eVisorXML345_doubleClickCustom;
        }

        void eVisorXML345_doubleClickCustom(string titulo)
        {
            AgregarFormulario(new VisorXML345(), titulo);
        }

        void eReporteFacturasSinXML_doubleClickCustom(string titulo)
        {
            AgregarFormulario(new ReporteFaltantesXMLGastosCompras(), titulo);
        }

        void eUnirXMLPolizas_doubleClickCustom(string titulo)
        {
            AgregarFormulario(new UnionXMLPolizas(), titulo);
        }

        void eGeneracionXMLPolizas_doubleClickCustom(string titulo)
        {
            AgregarFormulario(new GenerarXMLPolizas(), titulo);
        }

        void eCatalogoMonedas_doubleClickCustom(string titulo)
        {
            AgregarFormulario(new CatalogoMonedas(), titulo);
        }

        void eCatalogoFormasPago_doubleClickCustom(string titulo)
        {
            AgregarFormulario(new CatalogoFormasPago(), titulo);
        }

        void eCatalogoBancos_doubleClickCustom(string titulo)
        {
            AgregarFormulario(new CatalogoBancos(), titulo);
        }

        void eGeneracionXMLCatalogoCuentas_doubleClickCustom(string titulo)
        {
            AgregarFormulario(new GenerarXMLCatalogoCuentas(), titulo);
        }

        void ePolizas_doubleClickCustom(String titulo)
        {
            AgregarFormulario(new LigadoXMLConPolizas(), titulo);
        }

        void eCarga_doubleClickCustom(String titulo)
        {
            AgregarFormulario(new CargarXMLABD(), titulo);
        }
        void eCatalogo_doubleClickCustom(String titulo)
        {
            String tabla = "";
            int numeroHoja = 0;

            List<String> columnasConsulta = new List<string>();
            List<String> columnasDescripcion = new List<string>();

            ElegirTipoCatalogo el = new ElegirTipoCatalogo();
            el.ShowDialog();
            if (el.CatalogoElegido == null)
                return;
            String eleccion = el.CatalogoElegido;
            el.Close();
            if (eleccion.Equals("cuentas"))
            {
                tabla = "ELEC_CATALOGO_SAT";
                numeroHoja = 1;
                columnasConsulta.Add("nivel");
                columnasConsulta.Add("codAgrupador");
                columnasConsulta.Add("descripcionCuenta");

                columnasDescripcion.Add("Nivel");
                columnasDescripcion.Add("Código Agrupador");
                columnasDescripcion.Add("Descripción de la cuenta y/o subcuenta");
            }
            else if (eleccion.Equals("bancos"))
            {
                tabla = "ELEC_CATALOGO_BANCOS";
                numeroHoja = 2;
                columnasConsulta.Add("CodigoBanco");
                columnasConsulta.Add("DescripcionCorta");
                columnasConsulta.Add("DescripcionLarga");

                columnasDescripcion.Add("Código de banco");
                columnasDescripcion.Add("Descripción corta");
                columnasDescripcion.Add("Descripción larga");
            }
            else if (eleccion.Equals("monedas"))
            {
                tabla = "ELEC_CATALOGO_MONEDAS";
                numeroHoja = 3;
                columnasConsulta.Add("codigoMoneda");
                columnasConsulta.Add("descripcionMoneda");

                columnasDescripcion.Add("Código de moneda");
                columnasDescripcion.Add("Descripción de moneda");
            }
            else if (eleccion.Equals("formasPago"))
            {
                tabla = "ELEC_CATALOGO_FORMAPAGO";
                numeroHoja = 4;
                columnasConsulta.Add("codigoFormaPago");
                columnasConsulta.Add("descripcionFormaPago");

                columnasDescripcion.Add("Código de forma de pago");
                columnasDescripcion.Add("Descripción de forma de pago");
            }

            AgregarFormulario(new CargarCatalogoSatDeExcel(tabla, numeroHoja, columnasConsulta, columnasDescripcion), titulo);

        }
        private void eLigadoCuentas_doubleClickCustom(String titulo)
        {
            AgregarFormulario(new LigadoCuentasSATConCuentasEmpresa(), titulo);
        }
        private void eBalanzaComprobacion_doubleClickCustom(String titulo)
        {
            AgregarFormulario(new BalanzaComprobacion(), titulo);
        }
        #endregion
        #region manejo de formularios en el tabcontrol
        void pb_cerrarTab_MouseClick(object sender, MouseEventArgs e)
        {
            CerrarFormularioActual();
        }
        List<String> tabsNames = new List<string>();
        private void AgregarFormulario(Form formulario, String titulo)
        {
            formulario.Text = titulo;
            if (cmb_Empresas.SelectedIndex == -1)
            {
                Mensajes.Exclamacion("Debe seleccionar primero una empresa.");
                return;
            }
            try
            {

                if (tabsNames.Contains(formulario.Text))
                    return;
            }
            catch { }

            TabPage tp = new TabPage(formulario.Text);
            tabsNames.Add(formulario.Text);

            foreach (String nombreTab in tabsNames)
            {

            }


            Boolean maximizado = false;
            if (formulario.WindowState == FormWindowState.Maximized)
                maximizado = true;

            tp_forms.Visible = true;
            pb_cerrarTab.Visible = true;
            Panel contenedor = new Panel();

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.StartPosition = FormStartPosition.CenterParent;
            tp.AutoScroll = true;


            contenedor.Location = new Point((tp_forms.Size.Width - formulario.Size.Width) / 2, (tp_forms.Size.Height - formulario.Size.Height) / 2);

            tp.Size = new Size(tp_forms.Size.Width - 25, tp_forms.Size.Height - 30);

            contenedor.Size = formulario.Size;

            if (maximizado)
            {
                contenedor.Location = new Point(0, 0);
                contenedor.Size = tp.Size;
                formulario.Size = tp.Size;
            }

            contenedor.Controls.Add(formulario);
            tp.Controls.Add(contenedor);
            tp_forms.TabPages.Add(tp);
            formulario.Show(); //debe ir siempre al final para q los controles se activen
        }
        private void CerrarFormularioActual()
        {
            TabPage tp = tp_forms.SelectedTab;
            tabsNames.RemoveAt(tp_forms.SelectedIndex);
            tp_forms.TabPages.Remove(tp);



            if (tp_forms.TabPages.Count == 0)
            {
                tp_forms.Visible = false;
                pb_cerrarTab.Visible = false;
            }
        }
        #endregion
    }
}
