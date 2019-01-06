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
    public partial class BuscadorXML : Form
    {
        iSQL sql;
        DataTable dtResultados;
        public DataRow DataRowSeleccionado { get; set; }
        public BuscadorXML(String rfcEmisor, String rfcReceptor, List<String> uuidFacturasOmitidas, DateTime fechaPoliza)
        {
            InitializeComponent();
            sql = Login.sql;

            String query = @"select xmls.cFolioFacturaProveedor, xmls.uuid, xmls.dFechaEmision, xmls.cRFCEmisor, xmls.CRFCReceptor, xmls.cImporteTotal, xmls.sXMLContenido  
                            from empresas..FAC_XMLFACTURAS_PROVEEDORES xmls 
                            where cRFCEmisor = @cRFCEmisor and CRFCReceptor = @CRFCReceptor and dFechaEmision >= @dFechaEmision
                            ";

            List<Object> valores = new List<object>();
            valores.Add(rfcEmisor);
            valores.Add(rfcReceptor);
            valores.Add(fechaPoliza.AddMonths(-1));

            dtResultados = sql.EjecutarConsulta(query, valores);


            foreach (DataRow dr in dtResultados.Rows)
            {
                dgv_xmlFacturas.Rows.Add(String.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(dr["dFechaEmision"])), dr["cRFCEmisor"], dr["CRFCReceptor"],dr["cFolioFacturaProveedor"].ToString().PadLeft(15,'0'), String.Format("{0:#,###.0000}", dr["cImporteTotal"]), dr["sXMLContenido"]);
            }


        }

        private void dgv_xmlFacturas_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                String xml = dgv_xmlFacturas[e.ColumnIndex, e.RowIndex].Value.ToString();
                if (!xml.Equals(""))
                {
                    VisorXML visor = new VisorXML(xml);
                    visor.Show();
                }
            }
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                DataRowSeleccionado = dtResultados.Rows[dgv_xmlFacturas.SelectedRows[0].Index];
            }
            catch
            {
                
            }
            Hide();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Hide();
        }


    }
}
