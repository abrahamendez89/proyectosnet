using Herramientas.Archivos;
using Herramientas.Forms;
using Herramientas.SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ContabilidadElectronica.Formularios
{
    public partial class PolizasSinXML : Form
    {
        String periodo;
        iSQL sql;
        List<String> polizas;
        public PolizasSinXML(iSQL sql, String periodo, List<String> polizas)
        {
            InitializeComponent();
            this.sql = sql;
            this.periodo = periodo;
            this.polizas = polizas;
            InicializarGrid();
            CargarPolizasSinXML();
            txt_encontrados.Text = "0/" + dgv_polizasSinXML.Rows.Count;
        }
        private void InicializarGrid()
        {
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_polizasSinXML, "ID", 50);
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_polizasSinXML, "RFC Tercero", 120);
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_polizasSinXML, "XML", 150);
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_polizasSinXML, "Factura", 120);
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_polizasSinXML, "Póliza", 120);
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_polizasSinXML, "Tipo pago", 180);
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_polizasSinXML, "Importe", 100);
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_polizasSinXML, "Importe total xml", 100);
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_polizasSinXML, "Importe subtotal xml", 100);
        }
        private void CargarPolizasSinXML()
        {
            String polizasStr = " and cpoliza in (";
            foreach (String poliza in polizas)
            {
                polizasStr += "'" + poliza + "', ";
            }
            polizasStr = polizasStr.Substring(0, polizasStr.Length - 2);
            polizasStr += ")";

            String query = @"select  ID, cRFCReceptor, cContenidoXML, cFactura, cPoliza, sFormaPago 
                            ,case when fpTRANS_Monto is null then fpCHEQ_Monto else fpTRANS_Monto end as monto
                            from empresas..fac_xml 
                            where nRFCEmisor = " + Principal.NRFCEmisor + "  and cEstatus = 'A' and substring(cPoliza,3,6) = '" + periodo + "' and cContenidoXML = ''";
            if (polizas.Count > 0)
            {
                query += polizasStr;
            }
            query += " order by cpoliza, cFactura";
            DataTable dt = sql.EjecutarConsulta(query);
            dgv_polizasSinXML.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                dgv_polizasSinXML.Rows.Add(dr["ID"], dr["cRFCReceptor"], dr["cContenidoXML"], dr["cFactura"], dr["cPoliza"], dr["sFormaPago"], Herramientas.Conversiones.Formatos.DoubleAMoneda(Convert.ToDouble(dr["monto"])));
            }
        }
        private void btn_BuscarXML_Click(object sender, EventArgs e)
        {
            int contadorEncontrados = 0;
            for (int i = 0; i < dgv_polizasSinXML.Rows.Count; i++)
            {
                String factura = Herramientas.Forms.DataGridViewConf.ObtenerValorCelda(dgv_polizasSinXML, i, "Factura");
                String rfcReceptor = Herramientas.Forms.DataGridViewConf.ObtenerValorCelda(dgv_polizasSinXML, i, "RFC Tercero");
                String id = Herramientas.Forms.DataGridViewConf.ObtenerValorCelda(dgv_polizasSinXML, i, "ID");
                string query = "select cContenidoXML from empresas..fac_xml where nRFCEmisor = " + Principal.NRFCEmisor + "  and cEstatus = 'A'  and cFactura = '" + factura + "' and cRFCReceptor = '" + rfcReceptor + "' and cContenidoXML <> ''";

                DataTable dt = sql.EjecutarConsulta(query);

                if (dt.Rows.Count == 1)
                {
                    String xml = dt.Rows[0]["cContenidoXML"].ToString();
                    if (!xml.Equals(""))
                    {

                        XML xmlo = new XML();
                        xmlo.XMLContenido = xml;

                        double total = Convert.ToDouble(xmlo.ObtenerValorDePropiedad_NODO_XML("cfdi", "Comprobante", "total"));
                        double subtotal = Convert.ToDouble(xmlo.ObtenerValorDePropiedad_NODO_XML("cfdi", "Comprobante", "subtotal"));
                        
                        Herramientas.Forms.DataGridViewConf.AsignarValorCelda(dgv_polizasSinXML, i, "XML", xml);
                        Herramientas.Forms.DataGridViewConf.AsignarValorCelda(dgv_polizasSinXML, i, "Importe total xml", Herramientas.Conversiones.Formatos.DoubleAMoneda(total));
                        Herramientas.Forms.DataGridViewConf.AsignarValorCelda(dgv_polizasSinXML, i, "Importe subtotal xml", Herramientas.Conversiones.Formatos.DoubleAMoneda(subtotal));
                        
                        contadorEncontrados++;
                    }
                }
                else if (dt.Rows.Count > 1)
                {

                }
            }
            Herramientas.Forms.Mensajes.Informacion("Se encontraron " + contadorEncontrados + " xml para asignar.");
            if (contadorEncontrados > 0)
                Herramientas.Forms.Mensajes.Advertencia("Por favor REVICE que los XML encontrados sean los correctos.");
            txt_encontrados.Text = contadorEncontrados + "/" + dgv_polizasSinXML.Rows.Count;
        }

        private void dgv_polizasSinXML_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_polizasSinXML.SelectedRows.Count > 0)
            {

                String xml = Herramientas.Forms.DataGridViewConf.ObtenerValorCelda(dgv_polizasSinXML, dgv_polizasSinXML.SelectedRows[0].Index, "XML");
                if (!xml.Trim().Equals(""))
                {
                    VisorXML visor = new VisorXML(xml);
                    visor.Show();
                }
            }

        }

        private void btn_cargarPolizas_Click(object sender, EventArgs e)
        {
            CargarPolizasSinXML();
        }

        private void btn_asignarXML_Click(object sender, EventArgs e)
        {
            if (Herramientas.Forms.Mensajes.PreguntaAdvertenciaSIoNO("Al iniciar el proceso, se asignarán los XML a las pólizas, este proceso NO SE PUEDE REVERTIR, ¿Desea continuar?"))
            {
                for (int i = 0; i < dgv_polizasSinXML.Rows.Count; i++)
                {
                    String id = Herramientas.Forms.DataGridViewConf.ObtenerValorCelda(dgv_polizasSinXML, i, "ID");
                    String xml = Herramientas.Forms.DataGridViewConf.ObtenerValorCelda(dgv_polizasSinXML, i, "XML");

                    if (!xml.Trim().Equals(""))
                    {
                        try
                        {
                            String queryUpdate = "update empresas..fac_xml set cContenidoXML = '" + xml + "' where ID = " + id;
                            sql.IniciarTransaccion();
                            sql.EjecutarConsulta(queryUpdate);
                            sql.TerminarTransaccion();
                        }
                        catch
                        {
                            sql.DeshacerTransaccion();
                        }
                    }
                }
                Herramientas.Forms.Mensajes.Informacion("Se asignaron los XML, favor de recargar las pólizas en la pantalla anterior.");
            }
        }

        private void btn_generarExcel_Click(object sender, EventArgs e)
        {
            String ruta = Herramientas.Archivos.Dialogos.BuscarCarpeta(null);

            if (ruta != null && !ruta.Equals(""))
            {
                ruta += "\\"+Principal.RFCEmpresaSeleccionada+"_POLIZAS_SIN_XML_PERIODO_" + this.periodo + ".xls";
                //Herramientas.Forms.Mensajes.Informacion("El proceso durará un momento, espere..");
                ExcelAPI ex = new ExcelAPI();
                ex.terminoConversion += ex_terminoConversion;
                ex.ConvertirDataGridViewAExcel(ruta, dgv_polizasSinXML, Color.Yellow, Color.Black);
            }
        }

        void ex_terminoConversion(string rutaGuardado)
        {
            Herramientas.Forms.Mensajes.Informacion("Se generó el excel de forma exitosa en :" + rutaGuardado);
        }
    }
}
