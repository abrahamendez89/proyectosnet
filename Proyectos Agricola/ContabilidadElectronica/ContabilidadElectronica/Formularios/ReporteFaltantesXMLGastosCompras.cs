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
    public partial class ReporteFaltantesXMLGastosCompras : Form
    {
        private iSQL sql;
        public ReporteFaltantesXMLGastosCompras()
        {
            InitializeComponent();
            sql = Login.sql;
            cmb_mes.Items.Add("Enero");
            cmb_mes.Items.Add("Febrero");
            cmb_mes.Items.Add("Marzo");
            cmb_mes.Items.Add("Abril");
            cmb_mes.Items.Add("Mayo");
            cmb_mes.Items.Add("Junio");
            cmb_mes.Items.Add("Julio");
            cmb_mes.Items.Add("Agosto");
            cmb_mes.Items.Add("Septiembre");
            cmb_mes.Items.Add("Octubre");
            cmb_mes.Items.Add("Noviembre");
            cmb_mes.Items.Add("Diciembre");

            int mesActual = DateTime.Now.Month;


            for (int inicial = DateTime.Now.Year - 5; inicial <= DateTime.Now.Year; inicial++)
            {
                cmb_anios.Items.Add(inicial);
            }


            cmb_anios.SelectedIndex = cmb_anios.Items.Count - 1;

            cmb_mes.SelectedIndex = DateTime.Now.Month - 1;
            InicializarGrid();
        }

        private void InicializarGrid()
        {
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_facturas, "Póliza", 110);
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_facturas, "Factura", 110);
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_facturas, "Proveedor", 60);
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_facturas, "Descripción Proveedor", 300);
            //Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_facturas, "Observaciones", 100);
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_facturas, "Fecha", 100);
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_facturas, "Importe", 100);
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_facturas, "Tipo", 40);
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_facturas, "Costeado", 40);
        }

        private void btn_consultar_Click(object sender, EventArgs e)
        {
            if (cmb_anios.SelectedItem == null)
            {
                Herramientas.Forms.Mensajes.Error("Por favor selecciona un año.");
                return;
            }
            if (cmb_mes.SelectedItem == null)
            {
                Herramientas.Forms.Mensajes.Error("Por favor selecciona un mes.");
                return;
            }

            String anio = cmb_anios.SelectedItem.ToString();
            String mes = (cmb_mes.SelectedIndex + 1).ToString("D2");
            String primerDia = "01";
            String ultimoDia = new DateTime(Convert.ToInt32(anio), (cmb_mes.SelectedIndex + 1), 1).AddMonths(1).AddDays(-1).Day.ToString("00");

            String query = @"select 
	                        --*,
	                        isnull(cpoliza, (select top 1 CPOLIZA from MOVTOS_BAN ban where --ban.CDESCONCEPTO like '%'+cfacturaSinCeros+'%' and 
                                    ban.CAPLICACION = 'S' and ban.CSTATUS = 'A' and ban.CREFERENCIA = tabla.CCHEQUE)) as cpoliza
	                        , tabla.CFACTURA
	                        , tabla.CPROVEEDOR
	                        , tabla.cDescripProveedor
	                        , tabla.cObservaciones
	                        , tabla.dfecha
	                        , tabla.nimporte
	                        , tabla.CTIPOCOMPRA
                            , tabla.bclasificado
                        from (
                        SELECT distinct 
		                        isnull(m.CPOLIZA, cpoliza_gastos) as cpoliza,
		                        cfactura,
		                        CASE
                              WHEN cfactura = substring(cfactura, patindex('%[^0]%',cfactura), 10) 
                               THEN '0'
                              ELSE substring(cfactura, patindex('%[^0]%',cfactura), 10) 
                              END as cfacturaSinCeros ,
		                        cproveedor, 
                               (SELECT cdescrip 
                                FROM proveedores (nolock) 
                                WHERE cproveedor = m.cproveedor) AS cDescripProveedor, 
                               cobservaciones, 
                                dfecha AS dfecha, 
		                        m.nimporte * m.nparidad AS nimporte,
		                        case when m.ctipocompra = 'C' then 'Compra' else 'Gasto' end as ctipoCompra,
		                        m.CCHEQUE,
                                case when m.bclasificado = 1 then 'Si' else 'No' end as bclasificado
                        FROM   movtos_cxp m(nolock) 
                        left JOIN movtos_cxp_desglose d(nolock) ON d.nmovto_cxp = m.nmovto_cxp AND d.ctipocompra = m.ctipocompra AND d.nrenglon = m.nrenglon
                                                                AND d.csucursal = m.csucursal AND d.ctipomov = m.ctipomov
                        left JOIN CTL_ConceptosGastos C ON D.nConceptoGasto =C.nConceptoGasto and (nConcepto <>0 and nConcepto is not null) and (nDetalle <>0 and nDetalle is not null)
                        WHERE  m.ctipomov = 'C' 
                               --AND m.ctipocompra = 'G' 
	                           AND m.cstatus = 'A' AND m.caplicado = 'S'
                         and convert(char(10),m.DFECHA,121) BETWEEN '"+anio+"-"+mes+@"-01' and '"+anio+"-"+mes+"-"+ultimoDia+@"' 
                         --and m.BCLASIFICADO = 0
                         and not exists (select 1 from EMPRESAS..FAC_XML x where x.cFactura = m.CFACTURA and x.CPOLIZA = isnull(m.CPOLIZA, m.cpoliza_gastos) and x.sFormaPago is null)

                        ) as tabla
                        Order By tabla.cpoliza, tabla.CPROVEEDOR ASC 
                        ";
            dgv_facturas.Rows.Clear();
            DataTable dt = sql.EjecutarConsulta(query);

            foreach (DataRow dr in dt.Rows)
            {
                dgv_facturas.Rows.Add(dr["cpoliza"].ToString(), dr["CFACTURA"].ToString(), dr["CPROVEEDOR"].ToString(), dr["cDescripProveedor"].ToString()//, dr["cObservaciones"].ToString()
                    , Herramientas.Conversiones.Formatos.DateTimeAFechaCorta(Convert.ToDateTime(dr["dfecha"].ToString())), Herramientas.Conversiones.Formatos.DoubleAMoneda(Convert.ToDouble(dr["nimporte"].ToString())), dr["CTIPOCOMPRA"].ToString(), dr["bclasificado"].ToString());

            }

        }

        private void btn_generarPDF_Click(object sender, EventArgs e)
        {
            String ruta = Herramientas.Archivos.Dialogos.BuscarCarpeta(null);

            if (ruta != null && !ruta.Equals(""))
            {
                String nombreArchivo = Principal.RFCEmpresaSeleccionada + "_" + cmb_anios.SelectedItem.ToString() + "_" + (cmb_mes.SelectedIndex + 1).ToString("D2") + "_FALTANES_DE_XML.pdf";
                nombreArchivo = Principal.Server + " - " + nombreArchivo;
                PDF.ExportarDataGridViewToPDF(new List<DataGridView>() { dgv_facturas }, ruta + "\\" + nombreArchivo, new List<String>() { "Facturas de " + Principal.NombreEmpresaSeleccionada + " que faltan de XML.", "Periodo " + cmb_anios.SelectedItem.ToString() + " del mes de " + cmb_mes.SelectedItem.ToString() }, true, new List<string>() { "Facturas sin XML:" });
                Herramientas.Forms.Mensajes.Informacion("Se exportó correctamente en la ruta: " + ruta + "\\" + nombreArchivo);
            }
        }

        private void btn_generarExcel_Click(object sender, EventArgs e)
        {
            String ruta = Herramientas.Archivos.Dialogos.BuscarCarpeta(null);

            if (ruta != null && !ruta.Equals(""))
            {
                String nombreArchivo = Principal.RFCEmpresaSeleccionada + "_" + cmb_anios.SelectedItem.ToString() + "_" + (cmb_mes.SelectedIndex + 1).ToString("D2") + "_FALTANES_DE_XML.xls";
                nombreArchivo = Principal.Server + " - " + nombreArchivo;
                ExcelAPI ex = new ExcelAPI();
                ex.terminoConversion += ex_terminoConversion;
                ex.ConvertirDataGridViewAExcel(ruta + "\\" + nombreArchivo, dgv_facturas, Color.Orange, Color.White);
            }
        }

        void ex_terminoConversion(string rutaGuardado)
        {
            Herramientas.Forms.Mensajes.Informacion("Se exportó correctamente en la ruta: " + rutaGuardado);
        }
    }
}
