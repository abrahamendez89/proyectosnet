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
using EstructuraContable;
using Herramientas.Archivos;
using Herramientas.Forms;

namespace ContabilidadElectronica.Formularios
{
    public partial class BalanzaComprobacion : Form
    {
        iSQL sql;
        public BalanzaComprobacion()
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

            txt_anio.Text = DateTime.Now.Year.ToString();

            cmb_mes.SelectedIndex = DateTime.Now.Month - 1;

        }
        DataTable dt;
        private void btn_mostrarBalanza_Click(object sender, EventArgs e)
        {
            dgv_balanza.Rows.Clear();
            if (cmb_mes.SelectedIndex < 0)
            {
                Mensajes.Exclamacion("Debe seleccionar un mes antes de generar la balanza.");
                return;
            }
            if (cmb_tipoEnvio.SelectedIndex < 0)
            {
                Mensajes.Exclamacion("Debe seleccionar un tipo de envío antes");
                return;
            }

            int mes = cmb_mes.SelectedIndex + 1;
            String cadenaCargoMenosAbono = "";
            String cadenaAbonoMenosCargo = "";

            String cadenaCargoMenosAbonoMas1 = "";
            String cadenaAbonoMenosCargoMas1 = "";

            for (int i = 1; i < mes; i++)
            {
                String digitoMes = i.ToString("D2");
                cadenaCargoMenosAbono += "+(ncargo##-nabono##)".Replace("##", digitoMes);
                cadenaAbonoMenosCargo += "+(nabono##-ncargo##)".Replace("##", digitoMes);
            }

            //cadenaCargoMenosAbono = cadenaCargoMenosAbono.Substring(0, cadenaCargoMenosAbono.Length - 1);
            //cadenaAbonoMenosCargo = cadenaAbonoMenosCargo.Substring(0, cadenaAbonoMenosCargo.Length - 1);

            for (int i = 1; i <= mes; i++)
            {
                String digitoMes = i.ToString("D2");
                cadenaCargoMenosAbonoMas1 += "+(ncargo##-nabono##)".Replace("##", digitoMes);
                cadenaAbonoMenosCargoMas1 += "+(nabono##-ncargo##)".Replace("##", digitoMes);
            }

            //cadenaCargoMenosAbonoMas1 = cadenaCargoMenosAbonoMas1.Substring(0, cadenaCargoMenosAbonoMas1.Length - 1);
            //cadenaAbonoMenosCargoMas1 = cadenaAbonoMenosCargoMas1.Substring(0, cadenaAbonoMenosCargoMas1.Length - 1);



            String query = @"select case when C.NNIVELMOVTOS = 1 then SUBSTRING(C.ccuenta_cnt,1,10) else SUBSTRING(C.ccuenta_cnt,1,10)+'-'+SUBSTRING(C.ccuenta_cnt,11,10) end  as cuentaContable,		
									   --C.ccta_padre,
									  case 
									     when el.codigoAgrupadorSat is null then 
										   coalesce( 
										      (select
												 CONVERT(DECIMAL(10,2),incod.codigoAgrupadorSAT) AS codAgrup 
											  from ELEC_CATALOGO_CUENTAS_INTERNAS_CON_SAT incod 
											  where incod.codigoCuentaInterna = C.CCTA_PADRE)
											  
										   ,'-1') 
										 else 
										  CONVERT(DECIMAL(10,2),el.codigoAgrupadorSAT) 
									   end as codigoAgrupadorSAT,
                                       C.cdescrip,
                                       NSaldoAnt=isnull((case when cnaturaleza = 'D' then nSaldosIni" + cadenaCargoMenosAbono + @" WHEN CNaturaleza='A' THEN nSaldosIni" + cadenaAbonoMenosCargo + @" ELSE 0 end),0),
                                       ncARGO= isnull(ncargo" + (cmb_mes.SelectedIndex + 1).ToString("D2") + @",0), 
                                       naBONO= isnull(nabono" + (cmb_mes.SelectedIndex + 1).ToString("D2") + @",0),
                                       NSaldoFin=isnull((case when cnaturaleza = 'D' then nSaldosIni" + cadenaCargoMenosAbonoMas1 + @" WHEN CNaturaleza='A' THEN nSaldosIni" + cadenaAbonoMenosCargoMas1 + @" else 0 end),0)
                                From Cuentas_CNT C(nolock)

                                left JOIN Saldos_Ccosto S(nolock) ON S.CCUENTA_CNT = C.CCUENTA_CNT and S.nEjercicio = @Ejercicio and S.coficina LIKE '0000'
								left join ELEC_CATALOGO_CUENTAS_INTERNAS_CON_SAT el(nolock) on C.CCUENTA_CNT = el.codigoCuentaInterna
                                Where 
                                C.ccuenta_cnt like '____________________000000000000000000000000000000' 
                                and C.ccuenta_cnt <> '00000000000000000000000000000000000000000000000000' 
                                --AND (RIGHT(C.ccuenta_cnt,40)<>REPLICATE('0',40)) --OR C.CACEPTA ='S') 
                                order by C.cCuenta_cnt";

            dt = sql.EjecutarConsulta(query, new List<object>() { DateTime.Now.Year });

            txt_cuentasCargadas.Text = dt.Rows.Count.ToString();

            int cuentasSinAgrupador = 0;

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["codigoAgrupadorSAT"].ToString().Equals("-1.00"))
                    cuentasSinAgrupador++;
                dgv_balanza.Rows.Add(dr["cuentaContable"], dr["codigoAgrupadorSAT"].ToString().Replace(".00", ""), dr["cdescrip"], dr["NSaldoAnt"], dr["ncARGO"], dr["naBONO"], dr["NSaldoFin"]);
            }
            txt_cuentasSinAgrupador.Text = cuentasSinAgrupador.ToString();
            txt_cuentasConAgrupador.Text = (dt.Rows.Count - cuentasSinAgrupador).ToString();


            foreach (DataGridViewRow dgvr in dgv_balanza.Rows)
            {

                if (dgvr.Cells[1].Value.ToString().Equals("-1"))
                {
                    dgvr.Cells[1].Style.BackColor = Color.Red;
                    dgvr.Cells[1].Style.ForeColor = Color.White;
                    cuentasSinAgrupador++;
                }
            }
            dgv_balanza.Refresh();
        }

        private void btn_generarXML_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txt_cuentasSinAgrupador.Text) > 0 && !Mensajes.PreguntaAdvertenciaSIoNO("Se ha detectado que hay cuentas sin configurar en la balanza, si continúa con la operación, se omitiran todas las cuentas que no hayan estado configuradas. ¿Desea continuar?"))
            {
                return;
            }

            Balanza balanza = new Balanza();
            balanza.RFC = Principal.RFCEmpresaSeleccionada;
            balanza.Ano = Convert.ToInt32(txt_anio.Text);
            balanza.TipoEnvio = "" + cmb_tipoEnvio.SelectedItem.ToString().ToArray()[0];
            balanza.TotalCuentas = Convert.ToInt32(txt_cuentasConAgrupador.Text);
            balanza.Version = 1.1;
            balanza.FechaModBal = DateTime.Now;
            balanza.Mes = cmb_mes.SelectedIndex + 1;
            balanza.Cuentas = new List<BalanzaCuenta>();
            foreach (DataRow dr in dt.Rows)
            {
                if (!dr["codigoAgrupadorSAT"].ToString().Equals("-1.00"))
                {
                    BalanzaCuenta cuenta = new BalanzaCuenta();
                    cuenta.NumCuenta = dr["cuentaContable"].ToString();
                    cuenta.SaldoInicial = Convert.ToDouble(dr["NSaldoAnt"]);
                    cuenta.Debe = Convert.ToDouble(dr["ncARGO"]);
                    cuenta.Haber = Convert.ToDouble(dr["naBONO"]);
                    cuenta.SaldoFinal = Convert.ToDouble(dr["NSaldoFin"]);
                    balanza.Cuentas.Add(cuenta);
                }
            }

            String xml = balanza.ObtenerXMLString();

            String rutaArchivo = Herramientas.Archivos.Dialogos.BuscarCarpeta(null);


            if (rutaArchivo == null)
                return;

            String nombreArchivo = rutaArchivo + @"\" + Principal.RFCEmpresaSeleccionada + "" + txt_anio.Text + "" + (cmb_mes.SelectedIndex + 1).ToString("D2") + "" + "B" + cmb_tipoEnvio.SelectedItem.ToString().ToArray()[0] + ".xml";

            Archivo.GuardarArchivoDeTexto(nombreArchivo, xml);

            Zip.ComprimirArchivosEnZip(new List<string>() { nombreArchivo }, nombreArchivo.Replace(".xml", ".zip"));
            Archivo.EliminarArchivo(nombreArchivo);

            Mensajes.Informacion("Se ha generado el archivo XML.");
            //Mensajes.Informacion(xml);
        }

        private void btn_exportarExcel_Click(object sender, EventArgs e)
        {
            DataObject dataObj = dgv_balanza.GetClipboardContent();
            Clipboard.SetDataObject(dataObj, true);

            String ruta = Herramientas.Archivos.Dialogos.GuardarArchivoRuta(new List<string>() { "Archivo de excel" }, new List<string>() { "xls" }, "");

            if (ruta != null)
            {
                lbl_exportandoExcel.Visible = true;
                pb_progresoExport.Visible = true;
                ExcelAPI excel = new ExcelAPI();
                excel.mostrarProgresoConversion += excel_mostrarProgresoConversion;
                excel.terminoConversion += excel_terminoConversion;
                excel.ConvertirDataGridViewAExcel(ruta, dgv_balanza,Color.Orange, Color.Black);
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
