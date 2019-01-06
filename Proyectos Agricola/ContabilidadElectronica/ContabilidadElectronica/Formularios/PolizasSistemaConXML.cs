using Herramientas.SQL;
using Herramientas.WPF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Herramientas.Archivos;
using Herramientas.Forms;

namespace ContabilidadElectronica.Formularios
{
    public partial class PolizasSistemaConXML : Form
    {
        iSQL sql;
        public PolizasSistemaConXML()
        {
            InitializeComponent();
            dtp_hasta.MinDate = dtp_desde.Value;
            sql = Login.sql;
            dtp_desde.ValueChanged += dtp_desde_ValueChanged;
            dtp_desde.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtp_hasta.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month+1, 1).AddDays(-1);


            dtp_desde.Format = DateTimePickerFormat.Custom;
            dtp_desde.CustomFormat = "dd-MM-yyyy";

            dtp_hasta.Format = DateTimePickerFormat.Custom;
            dtp_hasta.CustomFormat = dtp_desde.CustomFormat;

            dgv_polizas.CellContentDoubleClick += dgv_polizas_CellContentDoubleClick;
        }

        void dgv_polizas_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                String xml = dgv_polizas[e.ColumnIndex, e.RowIndex].Value.ToString();
                if (!xml.Equals(""))
                {
                    VisorXML visor = new VisorXML(xml);
                    visor.Show();
                }
            }
        }

        void dtp_desde_ValueChanged(object sender, EventArgs e)
        {
            dtp_hasta.MinDate = dtp_desde.Value;
            dtp_hasta.Value = new DateTime(dtp_desde.Value.Year, dtp_desde.Value.Month + 1, 1).AddDays(-1);
        }
        DataTable dtPolizas;
        String mensaje;
        Thread tEstatus;
        private void EventoEstatus()
        {
            while (tConsulta.IsAlive)
            {
                lbl_estatus.Text = mensaje + ".";
                Thread.Sleep(200);
                lbl_estatus.Text = mensaje + "..";
                Thread.Sleep(200);
                lbl_estatus.Text = mensaje + "...";
                Thread.Sleep(200);
            }
            lbl_estatus.Text = "";
        }
        Thread tConsulta;
        private void EventoConsulta()
        {
            try
            {
                btn_cargarPolizas.Enabled = false;
                String query = @"select cxp.DFECHA, ltrim(rtrim(replace(prov.crfc,'-',''))) as crfc
                            ,prov.CDESCRIP, cxp.CFACTURA, cxp.NIMPORTE, cxp.CCHEQUE
                            , ISNULL(cxp.cpoliza,BAN.CPOLIZA) as cPoliza, ep.CDESCONCEPTO
                            , xmls.UUID, xmls.sXMLContenido
                            --,mon.CDESPLU, ban.CBANCO, ctlBan.CDESCRIP
                            from MOVTOS_CXP cxp 
                            inner join proveedores prov on cxp.CPROVEEDOR = prov.CPROVEEDOR
                            inner join MONEDAS mon on cxp.CMONEDA = mon.CMONEDA
                            left join MOVTOS_BAN ban on cxp.CPOLIZA = ban.CPOLIZA or cxp.CCHEQUE = ban.CREFERENCIA 
                            left join encpolizas ep on (cxp.coficina = ep.coficina and cxp.cpoliza = ep.cpoliza ) or ep.CPOLIZA=ban.creferencia or ep.CPOLIZA=ban.cpoliza
                            left join BANCOS ctlBan on ban.CBANCO = ctlBan.CBANCO
                            left join CUENTAS_BAN cntBan on ban.CBANCO = cntBan.CBANCO AND BAN.CCTA_BAN=CNTBAN.CCTA_BAN
                            --
                            left join empresas..FAC_XMLFACTURAS_PROVEEDORES xmls on cast(cxp.cfactura as varchar(max)) = cast(right('000000000000000' + xmls.cFolioFacturaProveedor, 15) as varchar(max)) and ltrim(rtrim(replace(prov.crfc,'-',''))) = xmls.cRFCEmisor and cxp.NIMPORTE = xmls.cImporteTotal
                            where cxp.dfecha >= @fechaDesde and cxp.dfecha <= @fechaHasta and cxp.CSTATUS = 'A' and cxp.CTIPOMOV = 'C' and (xmls.CRFCReceptor = @rfcReceptor or xmls.CRFCReceptor is null)
                            order by cxp.DFECHA asc";

                List<Object> parametros = new List<object>();
                parametros.Add(dtp_desde.Value);
                parametros.Add(dtp_hasta.Value);
                parametros.Add(Principal.RFCEmpresaSeleccionada);

                dtPolizas = sql.EjecutarConsulta(query, parametros);
                //btn_validar.Visible = true;
                if (dtPolizas.Rows.Count > 0)
                {
                    btn_cargarPolizas.Visible = false;
                    btn_cargarPolizas.Enabled = true;
                    Mensajes.Informacion("Se encontraron " + dtPolizas.Rows.Count + " pólizas registradas.");
                }
                else
                {
                    btn_cargarPolizas.Enabled = true;
                    Mensajes.Informacion("No se encontraron pólizas registradas.");
                }
            }
            catch (Exception ex)
            {
                btn_cargarPolizas.Enabled = true;
                Mensajes.Error(ex.Message);
            }
        }
        private void btn_cargarPolizas_Click(object sender, EventArgs e)
        {
            dgv_polizas.Rows.Clear();
            mensaje = "Consultando";
            tConsulta = new Thread(EventoConsulta);
            tConsulta.Start();
            tEstatus = new Thread(EventoEstatus);
            tEstatus.Start();

        }

        private void btn_validar_Click(object sender, EventArgs e)
        {
            foreach (DataRow dr in dtPolizas.Rows)
            {
                String fecha = "";
                if (!dr["sXMLContenido"].ToString().Equals(""))
                {
                    XML xml = new Herramientas.Archivos.XML();
                    xml.XMLContenido = dr["sXMLContenido"].ToString();
                    fecha = xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Comprobante", "fecha");
                }
                if(!fecha.Equals(""))
                    fecha = String.Format("{0:dd/MM/yyyy hh:mm:ss tt}", Convert.ToDateTime(fecha));
                dgv_polizas.Rows.Add(false,String.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(dr["DFECHA"])), dr["cPoliza"], dr["CFACTURA"], dr["crfc"], dr["CDESCRIP"], String.Format("{0:#,###.0000}", dr["NIMPORTE"]), dr["CDESCONCEPTO"], dr["UUID"], dr["sXMLContenido"], fecha);
                dgv_polizas.Rows[dgv_polizas.Rows.Count - 1].Cells[2].Style.ForeColor = Color.White;
                if (dgv_polizas.Rows[dgv_polizas.Rows.Count - 1].Cells[8].Value.ToString().Equals(""))
                {
                    dgv_polizas.Rows[dgv_polizas.Rows.Count - 1].Cells[2].Style.BackColor = Color.Red;
                }
                else
                {
                    dgv_polizas.Rows[dgv_polizas.Rows.Count - 1].Cells[2].Style.BackColor = Color.Green;
                }
            }
            btn_cargarPolizas.Visible = true;
        }

        private void dgv_polizas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F1)
            {
                String rfcEmisor = dgv_polizas.Rows[dgv_polizas.SelectedRows[0].Index].Cells[4].Value.ToString();
                String rfcReceptor = Principal.RFCEmpresaSeleccionada;//dgv_polizas.Rows[dgv_polizas.SelectedRows[0].Index].Cells[2].Value.ToString();
                String fechaEmision = dgv_polizas.Rows[dgv_polizas.SelectedRows[0].Index].Cells[1].Value.ToString();

                BuscadorXML buscador = new BuscadorXML(rfcEmisor, rfcReceptor, null, Convert.ToDateTime(fechaEmision));
                buscador.ShowDialog();

                DataRow drSeleeccionado = buscador.DataRowSeleccionado;
                buscador.Close();


                if (drSeleeccionado != null)
                {
                    dgv_polizas.Rows[dgv_polizas.SelectedRows[0].Index].Cells[2].Style.BackColor = Color.Blue;

                    dgv_polizas.Rows[dgv_polizas.SelectedRows[0].Index].Cells[8].Value = drSeleeccionado["uuid"].ToString();
                    dgv_polizas.Rows[dgv_polizas.SelectedRows[0].Index].Cells[9].Value = drSeleeccionado["sXMLContenido"].ToString();
                    dgv_polizas.Rows[dgv_polizas.SelectedRows[0].Index].Cells[10].Value = drSeleeccionado["dFechaEmision"].ToString();
                }


            }
            else if (e.KeyData == Keys.Delete)
            {
                dgv_polizas.Rows[dgv_polizas.SelectedRows[0].Index].Cells[2].Style.BackColor = Color.Red;

                dgv_polizas.Rows[dgv_polizas.SelectedRows[0].Index].Cells[8].Value = "";
                dgv_polizas.Rows[dgv_polizas.SelectedRows[0].Index].Cells[9].Value = "";
                dgv_polizas.Rows[dgv_polizas.SelectedRows[0].Index].Cells[10].Value = "";
            }
            else if (e.KeyData == Keys.Space)
            {
                dgv_polizas.Rows[dgv_polizas.SelectedRows[0].Index].Cells[0].Value = !Convert.ToBoolean(dgv_polizas.Rows[dgv_polizas.SelectedRows[0].Index].Cells[0].Value);
            }
        }

        private void btn_exportarExcel_Click(object sender, EventArgs e)
        {
            //String ruta = Herramientas.WPF.Utilidades.BuscarCarpeta(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            //ruta += @"\"+DateTime.Now.ToString("yyyyMMdd_HHmmss")+".xls";

            String ruta = Herramientas.Archivos.Dialogos.GuardarArchivoRuta(new List<string>() { "Archivo de excel" }, new List<string>() { "xls" }, "");

            if (ruta != null)
            {
                //Herramientas.Forms.ExcelAPI.ConvertirDataGridViewAExcel(ruta, dgv_polizas);
                //Mensajes.Informacion("Se guardo el archivo en la siguiente ruta: " + ruta);
            }
        }
    }
}
