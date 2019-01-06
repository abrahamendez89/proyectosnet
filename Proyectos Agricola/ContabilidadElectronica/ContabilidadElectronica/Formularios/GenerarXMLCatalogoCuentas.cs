using Herramientas.Archivos;
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

namespace ContabilidadElectronica.Formularios
{
    public partial class GenerarXMLCatalogoCuentas : Form
    {
        iSQL sql;
        public GenerarXMLCatalogoCuentas()
        {
            InitializeComponent();
            try
            {
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

                txt_anio.Text = DateTime.Now.Year.ToString();

                cmb_mes.SelectedIndex = DateTime.Now.Month - 1;
                CargarCuentasContablesInternas();
            }
            catch { }
        }
        DataTable dtResultado;
        private void CargarCuentasContablesInternas()
        {
            dgv_cuentasContables.Rows.Clear();
            String query = @"select case when C.NNIVELMOVTOS = 1 then SUBSTRING(C.ccuenta_cnt,1,10) else SUBSTRING(C.ccuenta_cnt,1,10)+'-'+SUBSTRING(C.ccuenta_cnt,11,10) end  as cuentaContable,		
									   --C.ccta_padre,
									  case 
									     when el.codigoAgrupadorSat is null then 
										   coalesce( 
										      (select
												 CONVERT(DECIMAL(10,2),incod.codigoAgrupadorSAT) AS codAgrup 
											  from ELEC_CATALOGO_CUENTAS_INTERNAS_CON_SAT incod 
											  where incod.codigoCuentaInterna = C.CCTA_PADRE)
											  
										   ,-1) 
										 else 
										    CONVERT(DECIMAL(10,2),el.codigoAgrupadorSAT) 
									   end as codigoAgrupadorSAT,
                                       C.cdescrip,
									   C.FecReg,
                                       C.CNATURALEZA,
									   C.NNIVELMOVTOS,
									   SUBSTRING(C.ccuenta_cnt,1,10) as subCuentaDe
                                       
                                from Cuentas_CNT C(nolock)
								left join ELEC_CATALOGO_CUENTAS_INTERNAS_CON_SAT el(nolock) on C.CCUENTA_CNT = el.codigoCuentaInterna
                                Where 
                                C.ccuenta_cnt like '____________________000000000000000000000000000000' 
                                and C.ccuenta_cnt <> '00000000000000000000000000000000000000000000000000' 
                                order by C.cCuenta_cnt";

            dtResultado = sql.EjecutarConsulta(query);

            foreach (DataRow dr in dtResultado.Rows)
            {
                dgv_cuentasContables.Rows.Add(dr["cuentaContable"], dr["codigoAgrupadorSAT"].ToString().Replace(".00",""), dr["cdescrip"], dr["FecReg"]);
            }
            dgv_cuentasContables.Refresh();

            MostrarCuentasAgregadasDespuesDeFecha();
            txt_cuentasCargadas.Text = dtResultado.Rows.Count.ToString();

        }
        DateTime fechaUltimaGeneracion;
        private void MostrarCuentasAgregadasDespuesDeFecha()
        {
            String query = @"select top 1 fechaGeneracion from ELEC_GENERACION_CATALOGO_PARA_SAT
                                order by fechaGeneracion desc";

            DataTable dt = sql.EjecutarConsulta(query);

            if (dt.Rows.Count > 0)
            {
                fechaUltimaGeneracion = Convert.ToDateTime(dt.Rows[0]["fechaGeneracion"]);
            }
            int cuentasNuevas = 0;
            int cuentasSinAgrupador = 0;
            foreach (DataGridViewRow dgvr in dgv_cuentasContables.Rows)
            {
                dgvr.Cells[3].Style.ForeColor = Color.White;
                if (dgvr.Cells[1].Value.ToString().Equals("-1"))
                {
                    dgvr.Cells[1].Style.BackColor = Color.Red;
                    dgvr.Cells[1].Style.ForeColor = Color.White;
                    cuentasSinAgrupador++;
                }
                if (Convert.ToDateTime(dgvr.Cells[3].Value.ToString()) > fechaUltimaGeneracion)
                {
                    dgvr.Cells[3].Style.BackColor = Color.Orange;
                    cuentasNuevas++;
                }
                else
                {
                    dgvr.Cells[3].Style.BackColor = Color.Green;
                }
            }

            txt_cuentasNuevas.Text = cuentasNuevas.ToString();
            txt_cuentasSinAgrupador.Text = cuentasSinAgrupador.ToString();
            txt_cuentasRegistradas.Text = (dtResultado.Rows.Count - cuentasNuevas).ToString();
        }

        private void btn_generarXML_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(txt_cuentasSinAgrupador.Text) > 0 && !Mensajes.PreguntaAdvertenciaSIoNO("Se han detectado cuentas sin agrupador, si continúa se omitirán dichas cuentas. ¿Desea continuar?"))
            {
                return;
            }


            EstructuraContable.Catalogo ctl = new EstructuraContable.Catalogo();
            ctl.Version = 1.1;
            ctl.RFC = Principal.RFCEmpresaSeleccionada;
            ctl.TotalCuentas = Convert.ToInt32(txt_cuentasCargadas.Text);
            ctl.Mes = cmb_mes.SelectedIndex + 1;
            ctl.Ano = DateTime.Now.Year;
            ctl.Cuentas = new List<EstructuraContable.CatalogoCuenta>();
            
            foreach (DataRow dr in dtResultado.Rows)
            {
                EstructuraContable.CatalogoCuenta cuenta = new EstructuraContable.CatalogoCuenta();
                cuenta.CodAgrup = dr["codigoAgrupadorSAT"].ToString().Replace(".00","");
                if (cuenta.CodAgrup.Equals("-1"))
                    continue;
                cuenta.Descripcion = dr["cdescrip"].ToString();
                cuenta.Naturaleza = Convert.ToChar(dr["CNATURALEZA"]);
                cuenta.Nivel = Convert.ToInt32(dr["NNIVELMOVTOS"]);
                cuenta.NumCuenta = dr["cuentaContable"].ToString();
                cuenta.SubCtaDe = dr["subCuentaDe"].ToString();

                ctl.Cuentas.Add(cuenta);
            }

            String xml = ctl.ObtenerXMLString();

            String rutaArchivo = Herramientas.Archivos.Dialogos.BuscarCarpeta(null);

            if (rutaArchivo == null)
                return;

            String nombreArchivo = rutaArchivo + @"\" + Principal.RFCEmpresaSeleccionada + "" + txt_anio.Text + "" + (cmb_mes.SelectedIndex + 1).ToString("D2") + "" + "CT.xml";

            Archivo.GuardarArchivoDeTexto(nombreArchivo, xml);


            Zip.ComprimirArchivosEnZip(new List<string>() { nombreArchivo }, nombreArchivo.Replace(".xml",".zip"));
            Archivo.EliminarArchivo(nombreArchivo);

            String query = @"insert ELEC_GENERACION_CATALOGO_PARA_SAT(fechaGeneracion, anioEjercicio, mesEjercicio, nombreArchivoGenerado, totalCuentas, contenidoXML) values(@fechaGeneracion, @anioEjercicio, @mesEjercicio, @nombreArchivoGenerado, @totalCuentas, @contenidoXML)";
            List<Object> valores = new List<object>();
            valores.Add(DateTime.Now);
            valores.Add(DateTime.Now.Year);
            valores.Add(DateTime.Now.Month);
            valores.Add(Principal.RFCEmpresaSeleccionada + "" + DateTime.Now.Year + "" + (DateTime.Now.Month).ToString("D2") + "" + "CT.xml");
            valores.Add(ctl.Cuentas.Count);
            valores.Add(xml);

            sql.EjecutarConsulta(query, valores);

            Mensajes.Informacion("Se guardo el archivo correctamente.");

        }

        private void btn_cargarCatalogo_Click(object sender, EventArgs e)
        {
            CargarCuentasContablesInternas();
        }

        private void btn_exportarExcel_Click(object sender, EventArgs e)
        {
            String ruta = Herramientas.Archivos.Dialogos.GuardarArchivoRuta(new List<string>() { "Archivo de excel" }, new List<string>() { "xls" }, "");

            if (ruta != null)
            {
                lbl_exportandoExcel.Visible = true;
                pb_progresoExport.Visible = true;
                ExcelAPI excel = new ExcelAPI();
                excel.mostrarProgresoConversion += excel_mostrarProgresoConversion;
                excel.terminoConversion += excel_terminoConversion;
                excel.ConvertirDataGridViewAExcel(ruta, dgv_cuentasContables, Color.Orange, Color.Black);
            }
        }

        void excel_terminoConversion(string rutaGuardado)
        {
            lbl_exportandoExcel.Visible = false;
            pb_progresoExport.Visible = false;
            Mensajes.Informacion("Se guardo el archivo en la siguiente ruta: " + rutaGuardado);
        }

        void excel_mostrarProgresoConversion(double progresoPorcentaje)
        {
            pb_progresoExport.Value = (int)progresoPorcentaje;
        }
    }
}
