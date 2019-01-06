using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Herramientas.SQL;
using Herramientas.Forms;

namespace ContabilidadElectronica.Formularios
{
    public partial class LigadoXMLConPolizas : Form
    {
        iSQL sql;
        public LigadoXMLConPolizas()
        {
            InitializeComponent();
            sql = Login.sql;
        }

        private void btn_cargar_Click(object sender, EventArgs e)
        {
            DataTable dt = sql.EjecutarConsulta("select * from empresas..FAC_XMLFACTURAS_PROVEEDORES where CRFCReceptor = @rfcReceptor and dFechaEmision >= @dFechaDesde and dFechaEmision <= @dFechaHasta", new List<object>() { Principal.RFCEmpresaSeleccionada, dtp_desde.Value, dtp_hasta.Value });

            foreach (DataRow dr in dt.Rows)
            {
                dgv_xmlEnBD.Rows.Add(dr["cRFCEmisor"], dr["cFolioFacturaProveedor"], dr["UUID"], dr["dFechaEmision"], dr["cImporteTotal"], dr["sXMLContenido"], "", "");
                dgv_xmlEnBD.Rows[dgv_xmlEnBD.Rows.Count - 1].Cells[7].Style.ForeColor = Color.White;
                
                if (dgv_xmlEnBD.Rows[dgv_xmlEnBD.Rows.Count - 1].Cells[7].Value.ToString().Equals(""))
                {
                    dgv_xmlEnBD.Rows[dgv_xmlEnBD.Rows.Count - 1].Cells[7].Style.BackColor = Color.Red;
                    dgv_xmlEnBD.Rows[dgv_xmlEnBD.Rows.Count - 1].Cells[7].Value = "Sin póliza ligada";
                }
                else
                {
                    dgv_xmlEnBD.Rows[dgv_xmlEnBD.Rows.Count - 1].Cells[7].Style.BackColor = Color.Green;
                    dgv_xmlEnBD.Rows[dgv_xmlEnBD.Rows.Count - 1].Cells[7].Value = "Con póliza registrada en el servidor";
                }
            }
            dgv_xmlEnBD.Refresh();
        }

        private void dgv_xmlEnBD_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                String xml = dgv_xmlEnBD[e.ColumnIndex, e.RowIndex].Value.ToString();
                if (!xml.Equals(""))
                {
                    VisorXML visor = new VisorXML(xml);
                    visor.Show();
                }
            }
        }
    }
}
