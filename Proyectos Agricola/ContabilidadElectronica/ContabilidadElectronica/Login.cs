using EstructuraContable;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using Herramientas;
using Herramientas.Archivos;
using Herramientas.SQL;
using Herramientas.Forms;

namespace ContabilidadElectronica
{
    public partial class Login : Form
    {
        //private String conexionSQLGenerica = "data source = @servidor; initial catalog = @bd; user id = @usuario; password = @contra";
        private Variable vars;
        
        public static iSQL sql;

        Dictionary<String, String> servers = new Dictionary<string, string>();

        public Login()
        {
            InitializeComponent();

            //TestNodosXML();

            //TestGenerarExcelConAgrupadores();


            //ImportarExcel();
            //CuentasPadre();

            //PolizaContenedor con = new PolizaContenedor();
            //con.Ano = 2015;
            //con.Mes = 10;
            //con.NumOrden = "adad";
            //con.RFC = "aSDAFASd";
            //con.Polizas = new List<Poliza>();
            //con.Polizas.Add(new Poliza() { Concepto = "concepto", Fecha = DateTime.Now, NumeroPoliza = "asd" });

            //String json = Herramientas.Web.JSON.ConvertirObjetoAJSON<PolizaContenedor>(con);

            //PolizaContenedor con2 = Herramientas.Web.JSON.ConvertirJSONAObjeto<PolizaContenedor>(json);

            //Herramientas.Archivos.Archivo.GuardarArchivoDeTexto(@"C:\Users\Abrahamm.WHOLESUM\Desktop\prueba.xml", text);

            CheckForIllegalCrossThreadCalls = false;
            try
            {
                vars = new Variable("Parametros.ini");

                String serv = vars.ObtenerValorVariable<String>("servers");

                foreach (String str in serv.Split(',').ToList<String>())
                {
                    servers.Add(str.Split('|')[0], vars.ObtenerValorVariable<String>(str.Split('|')[1]));
                    cmb_server.Items.Add(str.Split('|')[0]);
                }
                
                txt_usuario.Text = vars.ObtenerValorVariable<String>("ultimoLogin");
                try
                {
                    cmb_server.SelectedItem = vars.ObtenerValorVariable<String>("ultimoServer");
                }
                catch
                {
                }

                Herramientas.Forms.Eventos.AsignarEventoEnterAFocus(txt_usuario, txt_contra);
                Eventos.AsignarEventoEnterAFocus(txt_contra, btn_entrar);
                Eventos.AsignarEventoEnterAFocus(btn_entrar, txt_usuario);
                txt_contra.KeyDown += txt_contra_KeyDown;
                CargarTemplates();
            }
            catch (Exception ex)
            {
                Mensajes.Error("Error al cargar parametros: " + ex.Message);
            }
        }

        private void TestGenerarExcelConAgrupadores()
        {
            ExcelAPI ex = new ExcelAPI();
            ex.terminoConversion += ex_terminoConversion;


            DataTable dt = new DataTable();
            DataColumn dc1 = new DataColumn();
            dc1.ColumnName = "_NivelGrupo";
            dt.Columns.Add(dc1);
            DataColumn dc2 = new DataColumn();
            dc2.ColumnName = "Dato";
            dt.Columns.Add(dc2);

            dt.Rows.Add("1", "A");
            dt.Rows.Add("2", "A21");
            dt.Rows.Add("2", "A22");
            dt.Rows.Add("3", "A31");
            dt.Rows.Add("3", "A32");
            dt.Rows.Add("3", "A33");
            dt.Rows.Add("3", "A34");
            dt.Rows.Add("4", "A41");
            dt.Rows.Add("4", "A42");
            dt.Rows.Add("4", "A43");

            dt.Rows.Add("1", "B");
            dt.Rows.Add("2", "B21");
            dt.Rows.Add("2", "B22");

            ex.ConvertirDataTableAExcel(Herramientas.Archivos.Dialogos.BuscarCarpeta(null)+"\\archivoTestGrupos.xls", dt);
        }

        void ex_terminoConversion(string rutaGuardado)
        {
            Herramientas.Forms.Mensajes.Informacion("Termino");
        }

        private void TestNodosXML()
        {
            //Create an xml reader;
            XmlDocument _xmlDocument = new XmlDocument();
            _xmlDocument.Load(@"C:\Users\Abrahamm.WHOLESUM\Desktop\Culiacan-ANV040509TA4201510PL.xml");
            XmlNamespaceManager xmlnsManager = new XmlNamespaceManager(_xmlDocument.NameTable);
            xmlnsManager.AddNamespace("PLZ", "http://www.sat.gob.mx/esquemas/ContabilidadE/1_1/PolizasPeriodo");
           
            //Select the element with in the xml you wish to extract;
            //XmlNodeList _nodeList = _xmlDocument.SelectNodes("//PLZ:Polizas/PLZ:Poliza[@NumUnIdenPol='PG2015100012']/PLZ:Transaccion", xmlnsManager);

            XmlNodeList _nodeList = _xmlDocument.SelectNodes("//PLZ:Polizas/PLZ:Poliza", xmlnsManager);
            //recorriendo cada poliza
            foreach (XmlNode xPoliza in _nodeList)
            {
                //atributos poliza
                List<String> atPoliza = new List<string>();
                foreach (XmlAttribute atributo in xPoliza.Attributes)
                {
                    atPoliza.Add(atributo.Name + "=" + atributo.Value);
                }
                //recorriendo cada transaccion por poliza
                foreach (XmlNode xTransaccion in xPoliza.SelectNodes("//PLZ:Transaccion",xmlnsManager))
                {
                    //atributos transaccion
                    List<String> atTransaccion = new List<string>();
                    foreach (XmlAttribute atributo in xTransaccion.Attributes)
                    {
                        atTransaccion.Add(atributo.Name + "=" + atributo.Value);
                    }
                    //recorriendo cada Comprobante nacional
                    foreach (XmlNode xCompNal in xTransaccion.SelectNodes("//PLZ:CompNal", xmlnsManager))
                    {
                        //atributos CompNal

                        List<String> atCompNal = new List<string>();
                        foreach (XmlAttribute atributo in xCompNal.Attributes)
                        {
                            atCompNal.Add(atributo.Name + "=" + atributo.Value);
                        }
                    }
                }
            }
        }

        private void CuentasPadre()
        {
            SQLServer s = new SQLServer();
            s.ConfigurarConexion("192.168.1.10\\crop", "CRISP_CATALOGOS", "sa", "CRISP123");

            DataTable dt = s.EjecutarConsulta("select CCUENTA_CNT from cuentas_cnt");

            foreach (DataRow dr in dt.Rows)
            {
                String cuenta = dr["CCUENTA_CNT"].ToString();
                String[] partes = new string[5];

                partes[0] = cuenta.Substring(0, 10);
                partes[1] = cuenta.Substring(10, 10);
                partes[2] = cuenta.Substring(20, 10);
                partes[3] = cuenta.Substring(30, 10);
                partes[4] = cuenta.Substring(40, 10);

                String nuevaCuentaPadre = "";

                for (int i = 0; i < partes.Length; i++)
                {
                    if (Convert.ToInt32(partes[i]) != 0)
                    {
                        nuevaCuentaPadre += partes[i];


                    }
                    else
                    {
                        if (i > 1)
                        {
                            nuevaCuentaPadre = nuevaCuentaPadre.Substring(0, nuevaCuentaPadre.Length - 10);
                        }

                        for (int j = nuevaCuentaPadre.Length; j < 50; j++)
                            nuevaCuentaPadre += "0";
                        break;
                    }
                }
                if (nuevaCuentaPadre.Length != 50)
                    return;
                String queryUpdate = "update cuentas_cnt set CCTA_PADRE = '"+nuevaCuentaPadre+"' where ccuenta_cnt = '"+cuenta+"'";
                s.EjecutarConsulta(queryUpdate);
            }

        }

        private void ImportarExcel()
        {
            SQLServer s = new SQLServer();
            s.ConfigurarConexion("192.168.1.10\\crop", "CRISP_CATALOGOS", "sa", "CRISP123");

            Herramientas.Forms.ExcelElements.ExcelArchivo ex = Herramientas.Forms.ExcelElements.ExcelArchivo.ObtenerDataDeArchivoExcel(@"C:\Users\Abrahamm.WHOLESUM\Desktop\cuentasgr.xlsx");
            s.CrearEInsertarArchivoDataExcel(ex);
        }

        void txt_contra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                ValidarLogin();
            }
        }


        private void ValidarLogin()
        {
            try
            {
                if (txt_usuario.Text.Trim().Equals("") || txt_contra.Text.Trim().Equals(""))
                {
                    Mensajes.Advertencia("Debe proporcionar un usuario y contraseña para continuar.");
                    return;
                }
                if (cmb_server.SelectedItem == null)
                {
                    Mensajes.Advertencia("Debe seleccionar el server.");
                    return;
                }
                try
                {

                    sql = new SQLServer();
                    sql.ConfigurarConexion(servers.Values.ElementAt(cmb_server.SelectedIndex), "master", txt_usuario.Text.Trim(), txt_contra.Text.Trim());
                    sql.AbrirConexion();
                    vars.GuardarValorVariable("ultimoLogin", txt_usuario.Text.Trim());
                    vars.GuardarValorVariable("ultimoServer", cmb_server.SelectedItem.ToString());
                    vars.ActualizarArchivo();
                    //DBAcceso.Usuario = txt_usuario.Text.Trim();
                    //DBAcceso.Contrasena = txt_contra.Text.Trim();
                    Principal p = null;
                    Hide();
                    while (true)
                    {
                        try
                        {
                            if(p == null)
                                p = new Principal(servers.Keys.ElementAt(cmb_server.SelectedIndex));
                            p.ShowDialog();
                            break;
                        }
                        catch (Exception ex)
                        {
                            Mensajes.Error(ex.Message);
                        }
                    }
                   
                    Close();
                }
                catch (Exception ex)
                {
                    if (ex.Message.ToLower().Contains("login"))
                        Mensajes.Exclamacion("Usuario o contraseña incorrectos.");
                    else
                        Mensajes.Exclamacion("Error: " + ex.Message);
                    txt_contra.Text = "";

                    txt_contra.Focus();
                }
            }
            catch
            {
                Close();
            }
        }
        private void CargarTemplates()
        {
            try
            {
                Balanza.Formato = Archivo.LeerArchivoTexto(@"Formatos\BalanzaBase.txt");
                BalanzaCuenta.Formato = Archivo.LeerArchivoTexto(@"Formatos\BalanzaCuentasBase.txt");

                Catalogo.Formato = Archivo.LeerArchivoTexto(@"Formatos\CatalogoBase.txt");
                CatalogoCuenta.Formato = Archivo.LeerArchivoTexto(@"Formatos\CatalogoCuentasBase.txt");

                PolizaContenedor.Formato = Archivo.LeerArchivoTexto(@"Formatos\PolizasBase.txt");
                Poliza.Formato = Archivo.LeerArchivoTexto(@"Formatos\PolizasPolizaBase.txt");
                Transaccion.Formato = Archivo.LeerArchivoTexto(@"Formatos\PolizasPolizaTransaccionBase.txt");
                Transferencia.Formato = Archivo.LeerArchivoTexto(@"Formatos\PolizasPolizaTransaccionTransferenciaBase.txt");
                Cheque.Formato = Archivo.LeerArchivoTexto(@"Formatos\PolizasPolizaTransaccionChequeBase.txt");
                ComprobanteNacional.Formato = Archivo.LeerArchivoTexto(@"Formatos\PolizasPolizaTransaccionComprobanteNacionalBase.txt");
                ComprobanteExtranjero.Formato = Archivo.LeerArchivoTexto(@"Formatos\PolizasPolizaTransaccionComprobanteExtranjeroBase.txt");
                ComprobanteNacionalOtros.Formato = Archivo.LeerArchivoTexto(@"Formatos\PolizasPolizaTransaccionComprobanteNacionalOtroBase.txt");

                ReportePolizasAux.Formato = Archivo.LeerArchivoTexto(@"Formatos\ReportePolizasAuxiliaresBase.txt");
                ReportePolizasAuxDetalle.Formato = Archivo.LeerArchivoTexto(@"Formatos\ReportePolizasAuxiliaresDetalleBase.txt");
                ComprobanteExtranjeroRepPol.Formato = Archivo.LeerArchivoTexto(@"Formatos\ReportePolizasAuxiliaresDetalleComprobanteExtranjeroBase.txt");
                ComprobanteNacionalRepPol.Formato = Archivo.LeerArchivoTexto(@"Formatos\ReportePolizasAuxiliaresDetalleComprobanteNacionalBase.txt");
                ComprobanteNacionalOtrosRepPol.Formato = Archivo.LeerArchivoTexto(@"Formatos\ReportePolizasAuxiliaresDetalleComprobanteNacionalOtroBase.txt");

                AuxiliarCuentas.Formato = Archivo.LeerArchivoTexto(@"Formatos\AuxiliarCuentasBase.txt");
                AuxiliarCuentasCuenta.Formato = Archivo.LeerArchivoTexto(@"Formatos\AuxiliarCuentasCuentaBase.txt");
                AuxiliarCuentasCuentaDetalle.Formato = Archivo.LeerArchivoTexto(@"Formatos\AuxiliarCuentasCuentaDetalleBase.txt");

            }
            catch (Exception ex)
            {
                Mensajes.Error("Error al cargar los formatos: " + ex.Message);
            }
        }
        private void btn_entrar_Click(object sender, EventArgs e)
        {
            ValidarLogin();

            CargarTemplates();
            
        }


        
        public static XmlNode[] TextToNodeArray(string text)
        {
            XmlDocument doc = new XmlDocument();
            return new XmlNode[1] {
                  doc.CreateTextNode(text)};
        }
        public string StreamToString(Stream stream)
        {
            stream.Position = 0;
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
