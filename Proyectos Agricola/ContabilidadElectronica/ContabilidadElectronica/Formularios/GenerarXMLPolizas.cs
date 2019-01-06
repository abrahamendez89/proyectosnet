using EstructuraContable;
using Herramientas.Archivos;
using Herramientas.Conversiones;
using Herramientas.Forms;
using Herramientas.SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace ContabilidadElectronica.Formularios
{
    public partial class GenerarXMLPolizas : Form
    {
        iSQL sql;
        private String xmlPrincipalPolizas;
        private String xmlAuxiliarCuentas;
        private String xmlAuxiliarPolizas;
        List<String> abreviaturasTipoSolicitud = new List<string>();
        public GenerarXMLPolizas()
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


                for (int inicial = DateTime.Now.Year - 5; inicial <= DateTime.Now.Year; inicial++)
                {
                    cmb_anios.Items.Add(inicial);
                }


                cmb_anios.SelectedIndex = cmb_anios.Items.Count - 1;

                cmb_mes.SelectedIndex = DateTime.Now.Month - 1;
                ll_xmlPolizas.Tag = "";
                ll_xmlAuxiliarFolios.Tag = "";
                ll_xmlAuxiliarCuentas.Tag = "";


                cmb_tipoSolicitud.Items.Add("Acto de Fiscalización (AF)");
                abreviaturasTipoSolicitud.Add("AF");
                cmb_tipoSolicitud.Items.Add("Fiscalización Compulsa (FC)");
                abreviaturasTipoSolicitud.Add("FC");
                cmb_tipoSolicitud.Items.Add("Devolución (DE)");
                abreviaturasTipoSolicitud.Add("DE");
                cmb_tipoSolicitud.Items.Add("Compensación (CO)");
                abreviaturasTipoSolicitud.Add("CO");

                InicializarGrids();
                ContarPolizasColores();

                Herramientas.Forms.Validaciones.TextboxSoloNumerosEnteros(txt_desde);
                Herramientas.Forms.Validaciones.TextboxSoloNumerosEnteros(txt_hasta);

            }
            catch { }
            //String xmlTEst = GenerarXMLReporteAuxiliarFolios();

            //Herramientas.Archivos.Archivo.GuardarArchivoDeTexto(@"D:\Proyectos\ContabilidadElectronica\ContabilidadElectronica\bin\Debug\auxiliares.xml", xmlTEst);

        }
        private void CorregirPolizasCanceladas()
        {
            try
            {
                String queryCantidad = @"select id from (
		                                    select fac.id, fac.cFactura, fac.cPoliza, fac.nOrigenDatos
		                                    , sFormaPago
		                                    , case when fac.sFormaPago is not null then -- paridad
			                                    (select nparidad from MOVTOS_BAN ban where ban.CPOLIZA = fac.cPoliza and ban.CTIPOMOV = 'A' and ban.CSTATUS = 'A' and ban.CAPLICACION = 'S' )
		                                      else
			                                    (select nparidad from MOVTOS_CXP cxp where isnull(cxp.CPOLIZA, cxp.cpoliza_gastos) = fac.cPoliza and cxp.CFACTURA = fac.cFactura and cxp.CTIPOMOV = 'C' and cxp.CSTATUS = 'A' and cxp.CAPLICADO = 'S' )
		                                      end as [TipoCambioCROP]
		                                    , case when fac.sFormaPago is not null then --moneda
			                                    (select  mon.cMonedaSAT from MOVTOS_BAN ban inner join MONEDAS mon on ban.CMONEDA = mon.CMONEDA where ban.CPOLIZA = fac.cPoliza and ban.CTIPOMOV = 'A' and ban.CSTATUS = 'A' and ban.CAPLICACION = 'S' )
		                                      else
			                                    (select mon.cMonedaSAT from MOVTOS_CXP cxp inner join MONEDAS mon on cxp.CMONEDA = mon.CMONEDA where isnull(cxp.CPOLIZA, cxp.cpoliza_gastos) = fac.cPoliza and cxp.cFactura = fac.cFactura and cxp.CTIPOMOV = 'C' and cxp.CSTATUS = 'A' and cxp.CAPLICADO = 'S')
		                                      end as [MonedaSATCROP]
		                                    , case when fac.sFormaPago is not null then --moneda
			                                    (select  ban.CSTATUS from MOVTOS_BAN ban where ban.CPOLIZA = fac.cPoliza and ban.CTIPOMOV = 'A')
		                                      else
			                                    (select cxp.CSTATUS from MOVTOS_CXP cxp where isnull(cxp.CPOLIZA, cxp.cpoliza_gastos) = fac.cPoliza and cxp.cFactura = fac.cFactura and cxp.CTIPOMOV = 'C')
		                                      end as [cEstatus]
		                                    from empresas..FAC_XML fac 
		                                    where nRFCEmisor = " + Principal.NRFCEmisor + @" and cEstatus = 'A' and nOrigenDatos <> 2  and convert(int, SUBSTRING(cpoliza,9,4)) >= "+rangoInferior+@" and convert(int, SUBSTRING(cpoliza,9,4)) <= "+rangoSuperior+@"
	                                    ) as tabla where TipoCambioCROP is null";

                DataTable dt = sql.EjecutarConsulta(queryCantidad);

                if (dt.Rows.Count > 0)
                {

                    String queryUpdate = @"update empresas..FAC_XML set cEstatus = 'C' where id in(
	                                    select id from (
		                                    select fac.id, fac.cFactura, fac.cPoliza, fac.nOrigenDatos
		                                    , sFormaPago
		                                    , case when fac.sFormaPago is not null then -- paridad
			                                    (select nparidad from MOVTOS_BAN ban where ban.CPOLIZA = fac.cPoliza and ban.CTIPOMOV = 'A' and ban.CSTATUS = 'A' and ban.CAPLICACION = 'S' )
		                                      else
			                                    (select nparidad from MOVTOS_CXP cxp where isnull(cxp.CPOLIZA, cxp.cpoliza_gastos) = fac.cPoliza and cxp.CFACTURA = fac.cFactura and cxp.CTIPOMOV = 'C' and cxp.CSTATUS = 'A' and cxp.CAPLICADO = 'S' )
		                                      end as [TipoCambioCROP]
		                                    , case when fac.sFormaPago is not null then --moneda
			                                    (select  mon.cMonedaSAT from MOVTOS_BAN ban inner join MONEDAS mon on ban.CMONEDA = mon.CMONEDA where ban.CPOLIZA = fac.cPoliza and ban.CTIPOMOV = 'A' and ban.CSTATUS = 'A' and ban.CAPLICACION = 'S' )
		                                      else
			                                    (select mon.cMonedaSAT from MOVTOS_CXP cxp inner join MONEDAS mon on cxp.CMONEDA = mon.CMONEDA where isnull(cxp.CPOLIZA, cxp.cpoliza_gastos) = fac.cPoliza and cxp.cFactura = fac.cFactura and cxp.CTIPOMOV = 'C' and cxp.CSTATUS = 'A' and cxp.CAPLICADO = 'S')
		                                      end as [MonedaSATCROP]
		                                    , case when fac.sFormaPago is not null then --moneda
			                                    (select  ban.CSTATUS from MOVTOS_BAN ban where ban.CPOLIZA = fac.cPoliza and ban.CTIPOMOV = 'A')
		                                      else
			                                    (select cxp.CSTATUS from MOVTOS_CXP cxp where isnull(cxp.CPOLIZA, cxp.cpoliza_gastos) = fac.cPoliza and cxp.cFactura = fac.cFactura and cxp.CTIPOMOV = 'C')
		                                      end as [cEstatus]
		                                    from empresas..FAC_XML fac 
		                                    where nRFCEmisor = " + Principal.NRFCEmisor + @" and cEstatus = 'A' and nOrigenDatos <> 2 and convert(int, SUBSTRING(cpoliza,9,4)) >= " + rangoInferior + @" and convert(int, SUBSTRING(cpoliza,9,4)) <= " + rangoSuperior + @"
	                                    ) as tabla where TipoCambioCROP is null
                                    )";
                    sql.IniciarTransaccion();
                    sql.EjecutarConsulta(queryUpdate);
                    sql.TerminarTransaccion();
                    Herramientas.Forms.Mensajes.Informacion("Se corrigieron " + dt.Rows.Count + " pólizas canceladas.");
                }
            }
            catch (Exception ex)
            {
                sql.DeshacerTransaccion();
                Herramientas.Forms.Mensajes.Error("Ocurrió un error al corregir pólizas canceladas, por favor cierre el formulario y vuelva a abrir.");
            }
        }
        private void InicializarGrids()
        {
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_polizas, "Póliza", 110);
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_polizas, "Fecha", 100);
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_polizas, "Concepto", 300);
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_polizas, "Cargo", 110);
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_polizas, "Abono", 110);
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_polizas, "NO. Facturas", 40);
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_polizas, "SubTotal XML", 110);
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_polizas, "Total XML", 110);
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_polizas, "Total + impuestos trasladados XML", 110);
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_polizas, "Total + impuestos retenidos XML", 110);
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_polizas, "Metodo Pago", 110);
        }
        private void ConfigurarGridDetalleACuentasContables()
        {
            Herramientas.Forms.DataGridViewConf.EliminarColumnas(dgv_detalle);
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_detalle, "Póliza", 85);
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_detalle, "Cuenta Contable", 325);
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_detalle, "Descripción Cuenta", 150);
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_detalle, "Concepto", 330);
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_detalle, "Cargo (Debe)", 120);
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_detalle, "Abono (Haber)", 120);
        }
        private void ConfigurarGridDetalleAXMLRelacionados()
        {
            Herramientas.Forms.DataGridViewConf.EliminarColumnas(dgv_detalle);
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_detalle, "ID", 40);
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_detalle, "RFC Receptor", 120);
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_detalle, "Factura", 120);
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_detalle, "Monto SubTotal", 110);
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_detalle, "Monto Total", 110);
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_detalle, "Concepto", 220);
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_detalle, "XML", 60);
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_detalle, "UUID", 230);
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_detalle, "Moneda xml", 60);
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_detalle, "Tipo de cambio xml", 70);

            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_detalle, "Forma pago", 120);
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_detalle, "Cuenta origen", 120);
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_detalle, "Banco origen", 120);
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_detalle, "Fecha", 120);
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_detalle, "Beneficiario", 120);
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_detalle, "RFC Tercero", 120);
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_detalle, "Monto", 120);
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_detalle, "Moneda", 60);
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_detalle, "Tipo de cambio", 70);
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_detalle, "Cuenta destino Transferencia", 120);
            Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_detalle, "Banco destino Transferencia", 120);
        }
        private void CargarXML()
        {
            try
            {

                rowsTotales.Clear();
                //Polizas con soporte XML
                //String query = "select  distinct  cPoliza, ID, cContenidoXML, cRFCReceptor, cFactura from empresas..fac_xml where nRFCEmisor = " + Principal.NRFCEmisor + "  and cEstatus = 'A' and substring(cPoliza,3,6) = '" + cmb_anios.SelectedItem.ToString() + "" + (cmb_mes.SelectedIndex + 1).ToString("D2") + "' and cContenidoXML <> ''";
                String query = @"
                            select 
                            * 
                            , (select distinct f.sFormaPago from EMPRESAS..FAC_XML f where f.cPoliza = x.Poliza and f.nRFCEmisor = " + Principal.NRFCEmisor + @" and f.cEstatus = 'A' and f.sFormaPago is not null) as [MetodoPago]
                            from (
                                select distinct
                                fac.cPoliza as [Poliza]
                                ,enc.DFECHA as [Fecha]
                                ,enc.CDESCONCEPTO as [Concepto]
                                ,(
                                select sum(det.NCARGO) as importe from ENCPOLIZAS enc 
                                join detpolizas det on enc.cpoliza = det.cpoliza and enc.coficina = det.coficina
                                where enc.CPOLIZA = fac.cPoliza
                                group by enc.CPOLIZA, enc.CDESCONCEPTO
                                ) as [Cargo]
                                ,(
                                select sum(det.NABONO) as importe from ENCPOLIZAS enc 
                                join detpolizas det on enc.cpoliza = det.cpoliza and enc.coficina = det.coficina
                                where enc.CPOLIZA = fac.cPoliza
                                group by enc.CPOLIZA, enc.CDESCONCEPTO
                                ) as [Abono]
                                ,Count(*) as [NO. Facturas]
                                ,fac.cEstatusRevision [EstatusRevision]
                                from empresas..FAC_XML as fac
                                inner join ENCPOLIZAS enc on fac.cPoliza = enc.CPOLIZA
                                where fac.nRFCEmisor = " + Principal.NRFCEmisor + @"  and fac.cEstatus = 'A' and substring(fac.cPoliza,3,6) = '" + cmb_anios.SelectedItem.ToString() + "" + (cmb_mes.SelectedIndex + 1).ToString("D2") + @"' and enc.CSTATUS = 'A'
                                and convert(int, SUBSTRING(fac.cpoliza,9,4)) >= " + rangoInferior + @" and convert(int, SUBSTRING(fac.cpoliza,9,4)) <= " + rangoSuperior + @"
                                group by fac.cPoliza , enc.DFECHA, enc.CDESCONCEPTO, fac.cEstatusRevision
                            ) x   
                            order by x.Poliza
                            ";
                DataTable dt = sql.EjecutarConsulta(query);
                //polizas sin soporte XML
                String query2 = @"
                            select distinct
                            enc.cPoliza as [Poliza]
                            ,enc.DFECHA as [Fecha]
                            ,enc.CDESCONCEPTO as [Concepto]
                            ,(
                            select sum(det.NCARGO) as importe from ENCPOLIZAS enc1 
                            join detpolizas det on enc1.cpoliza = det.cpoliza and enc1.coficina = det.coficina
                            where enc1.CPOLIZA = enc.cPoliza
                            group by enc.CPOLIZA, enc.CDESCONCEPTO
                            ) as [Cargo]
                            ,(
                            select sum(det.NABONO) as importe from ENCPOLIZAS enc1 
                            join detpolizas det on enc1.cpoliza = det.cpoliza and enc1.coficina = det.coficina
                            where enc1.CPOLIZA = enc.cPoliza
                            group by enc.CPOLIZA, enc.CDESCONCEPTO
                            ) as [Abono]
                            ,0 as [NO. Facturas]
                            ,'GRIS' [EstatusRevision]
                            , 'NA' as [MetodoPago]
                            from ENCPOLIZAS enc
                            where substring(enc.cPoliza,3,6) = '" + cmb_anios.SelectedItem.ToString() + "" + (cmb_mes.SelectedIndex + 1).ToString("D2") + @"' and enc.CSTATUS = 'A'
                            and convert(int, SUBSTRING(enc.cpoliza,9,4)) >= " + rangoInferior + @" and convert(int, SUBSTRING(enc.cpoliza,9,4)) <= " + rangoSuperior + @"
                            and enc.CPOLIZA not in
                            (
	                            select distinct
	                            fac.cPoliza as [Poliza]
	                            from empresas..FAC_XML as fac
	                            inner join ENCPOLIZAS enc on fac.cPoliza = enc.CPOLIZA
	                            where fac.nRFCEmisor = " + Principal.NRFCEmisor + @"  and fac.cEstatus = 'A' and substring(fac.cPoliza,3,6) = '" + cmb_anios.SelectedItem.ToString() + "" + (cmb_mes.SelectedIndex + 1).ToString("D2") + @"' and enc.CSTATUS = 'A'
                                and convert(int, SUBSTRING(fac.cpoliza,9,4)) >= " + rangoInferior + @" and convert(int, SUBSTRING(fac.cpoliza,9,4)) <= " + rangoSuperior + @"
                            )
                            group by enc.cPoliza , enc.DFECHA, enc.CDESCONCEPTO
                            order by enc.cPoliza

                            ";
                DataTable dt2 = sql.EjecutarConsulta(query2);

                dt.Merge(dt2);


                txt_totalPolizas.Text = (dt.Rows.Count).ToString();
                //obteniendo los datos restantes
                dgv_polizas.Rows.Clear();
                dgv_detalle.Rows.Clear();
                double totalCargos = 0;
                double totalAbonos = 0;
                double totalEnXML = 0;
                int indice = 0;

                int conteoPosiblesIncorrectos = 0;
                String polizaAnterior = "";

                List<String> polizasGuardar = new List<string>();
                List<Color> polizasColoresGuardar = new List<Color>();

                foreach (DataRow dr in dt.Rows)
                {
                    double cargo = 0;
                    double abono = 0;
                    try
                    {
                        cargo = Convert.ToDouble(dr["Cargo"]);
                        abono = Convert.ToDouble(dr["Abono"]);
                    }
                    catch
                    {
                        continue;
                    }
                    String EstatusRevision = dr["EstatusRevision"].ToString();
                    totalCargos += cargo;
                    totalAbonos += abono;
                    String MetodoPago = "NA";
                    if (!dr["MetodoPago"].ToString().Equals(""))
                    {
                        MetodoPago = dr["MetodoPago"].ToString();
                    }
                    //checando el tipo de poliza
                    if (EstatusRevision.Equals("GRIS"))
                    {
                        try
                        {
                            dgv_polizas.Rows.Add(dr["Poliza"], Herramientas.Conversiones.Formatos.DateTimeAFechaCorta(Convert.ToDateTime(dr["Fecha"])), dr["Concepto"], Herramientas.Conversiones.Formatos.DoubleAMoneda(cargo), Herramientas.Conversiones.Formatos.DoubleAMoneda(abono), dr["NO. Facturas"], Herramientas.Conversiones.Formatos.DoubleAMoneda(0), Herramientas.Conversiones.Formatos.DoubleAMoneda(0), Herramientas.Conversiones.Formatos.DoubleAMoneda(0), Herramientas.Conversiones.Formatos.DoubleAMoneda(0), MetodoPago);
                            rowsTotales.Add(dgv_polizas.Rows[dgv_polizas.Rows.Count - 1]);
                            Herramientas.Forms.DataGridViewConf.CambiarColorCelda(dgv_polizas, Color.Gray, Color.White, indice, "Póliza");
                            indice++;
                        }
                        catch
                        {
                        }
                        continue;
                    }

                    //para polizas que tienen XML
                    String totales = ObtenerTotalEnXML(dr["Poliza"].ToString());
                    double subtotalXML = Convert.ToDouble(totales.Split('|')[0]);
                    double totalXML = Convert.ToDouble(totales.Split('|')[1]);
                    double totalConImpuestosTrasladadosXML = Convert.ToDouble(totales.Split('|')[2]);
                    double totalConImpuestosRetenidosXML = Convert.ToDouble(totales.Split('|')[3]);
                    totalEnXML += totalXML;



                    if (polizaAnterior.Equals(dr["Poliza"].ToString()))
                    {
                        //reseteamos el color de la poliza nuevamente por que se agrego un xml nuevo y se necesita evaluar de nuevo
                        try
                        {
                            String queryUpdate = "update empresas..fac_xml set cEstatusRevision = NULL where cPoliza = '" + polizaAnterior + "' and nRFCEmisor = " + Principal.NRFCEmisor + " and cEstatus = 'A'";
                            sql.IniciarTransaccion();
                            sql.EjecutarConsulta(queryUpdate);
                            sql.TerminarTransaccion();
                        }
                        catch (Exception ex)
                        {
                            sql.DeshacerTransaccion();
                            throw ex;
                        }
                        CargarXML();
                        return;
                    }

                    polizaAnterior = dr["Poliza"].ToString();

                    Boolean posibleincorrecto = false;


                    if (cargo != abono)
                    {
                        posibleincorrecto = true;
                    }
                    if ((int)cargo != (int)totalXML)
                    {
                        posibleincorrecto = true;
                    }
                    if ((int)cargo == (int)totalConImpuestosTrasladadosXML)
                    {
                        posibleincorrecto = false;
                    }


                    dgv_polizas.Rows.Add(dr["Poliza"], Herramientas.Conversiones.Formatos.DateTimeAFechaCorta(Convert.ToDateTime(dr["Fecha"])), dr["Concepto"], Herramientas.Conversiones.Formatos.DoubleAMoneda(cargo), Herramientas.Conversiones.Formatos.DoubleAMoneda(abono), dr["NO. Facturas"], Herramientas.Conversiones.Formatos.DoubleAMoneda(subtotalXML), Herramientas.Conversiones.Formatos.DoubleAMoneda(totalXML), Herramientas.Conversiones.Formatos.DoubleAMoneda(totalConImpuestosTrasladadosXML), Herramientas.Conversiones.Formatos.DoubleAMoneda(totalConImpuestosRetenidosXML), MetodoPago);
                    //buscando color guardado anteriormente
                    Color colorDefault = Color.White;
                    Color colorTexto = Color.Black;
                    if (EstatusRevision.Equals("ROJO"))
                    {
                        colorDefault = Color.Red;
                        colorTexto = Color.White;
                    }
                    else if (EstatusRevision.Equals("AMARILLO"))
                    {
                        colorDefault = Color.Yellow;
                        colorTexto = Color.Black;
                    }
                    else if (EstatusRevision.Equals("VERDE"))
                    {
                        colorDefault = Color.Green;
                        colorTexto = Color.White;
                    }


                    Herramientas.Forms.DataGridViewConf.CambiarColorCelda(dgv_polizas, colorDefault, colorTexto, indice, "Póliza");
                    rowsTotales.Add(dgv_polizas.Rows[dgv_polizas.Rows.Count - 1]);
                    //evaluando solo si la fila no ha sido evaluada anteriormente = white
                    if (colorDefault != Color.Green)
                    {
                        if (posibleincorrecto)
                        {
                            Herramientas.Forms.DataGridViewConf.CambiarColorCelda(dgv_polizas, Color.Red, Color.White, indice, "Póliza");
                        }
                        if ((int)cargo == (int)totalConImpuestosTrasladadosXML)
                        {
                            Herramientas.Forms.DataGridViewConf.CambiarColorCelda(dgv_polizas, Color.Yellow, Color.Black, indice, "Póliza");

                        }
                        if ((int)cargo == (int)totalConImpuestosRetenidosXML)
                        {
                            Herramientas.Forms.DataGridViewConf.CambiarColorCelda(dgv_polizas, Color.Yellow, Color.Black, indice, "Póliza");

                        }
                        if ((int)cargo == (int)subtotalXML || (int)cargo == (int)totalXML)
                        {
                            Herramientas.Forms.DataGridViewConf.CambiarColorCelda(dgv_polizas, Color.Green, Color.White, indice, "Póliza");

                        }
                    }


                    if (Herramientas.Forms.DataGridViewConf.ObtenerColorFondoCelda(dgv_polizas, dgv_polizas.Rows.Count - 1, "Póliza") == Color.Red)
                    {
                        conteoPosiblesIncorrectos++;
                    }
                    indice++;

                    polizasGuardar.Add(dr["Poliza"].ToString());
                    polizasColoresGuardar.Add(Herramientas.Forms.DataGridViewConf.ObtenerColorFondoCelda(dgv_polizas, dgv_polizas.Rows.Count - 1, "Póliza"));

                }
                txt_totalCargos.Text = Herramientas.Conversiones.Formatos.DoubleAMoneda(totalCargos);
                txt_totalAbonos.Text = Herramientas.Conversiones.Formatos.DoubleAMoneda(totalAbonos);
                txt_totalEnXML.Text = Herramientas.Conversiones.Formatos.DoubleAMoneda(totalEnXML);

                //xmlPrincipal = GenerarXMLDePolizas();

                ContarPolizasColores();
                GuardarEstatusColoresPolizas(polizasGuardar, polizasColoresGuardar);

                if (conteoPosiblesIncorrectos > 0)
                    Herramientas.Forms.Mensajes.Advertencia("Existen " + conteoPosiblesIncorrectos + " pólizas con posibles errores, FAVOR DE VERIFICAR.");



            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private int rangoInferior = -1;
        private int rangoSuperior = -1;
        private void btn_cargarXML_Click(object sender, EventArgs e)
        {
            if (txt_desde.Text.Trim().Equals("") || txt_hasta.Text.Trim().Equals(""))
            {
                Herramientas.Forms.Mensajes.Exclamacion("Por favor asigne el rango de pólizas para esta empresa y lugar (desde 1 hasta 9999).");
                return;
            }

            rangoInferior = Convert.ToInt32(txt_desde.Text.Trim());
            rangoSuperior = Convert.ToInt32(txt_hasta.Text.Trim());

            if (rangoSuperior < rangoInferior)
            {
                Herramientas.Forms.Mensajes.Exclamacion("El rango es incorrecto.");
                return;
            }

            CorregirPolizasCanceladas();
            CargarXML();
            BorrarObjetosParaXML();
        }

        private void BorrarObjetosParaXML()
        {
            polizaContenedor = null;
            reporteAuxContendor = null;
            cuentasAuxContenedor = null;
            xmlAuxiliarCuentas = "";
            xmlAuxiliarPolizas = "";
            xmlPrincipalPolizas = "";
            ll_xmlAuxiliarCuentas.Tag = "";
            ll_xmlAuxiliarFolios.Tag = "";
            ll_xmlPolizas.Tag = "";
        }
        PolizaContenedor polizaContenedor;
        ReportePolizasAux reporteAuxContendor;
        AuxiliarCuentas cuentasAuxContenedor;
        private String GenerarXMLDePolizas()
        {

            String xmlResultado = "";
            try
            {
                MostrarFiltrados(Color.White);

                //creando el contenedor de polizas
                polizaContenedor = new PolizaContenedor();
                polizaContenedor.Ano = Convert.ToInt32(cmb_anios.SelectedItem.ToString());
                polizaContenedor.Mes = cmb_mes.SelectedIndex + 1;
                polizaContenedor.Version = 1.1;  //ultima version de generacion de polizas.
                polizaContenedor.NumOrden = txt_numeroOrden.Text.Trim(); // "ASD6985555/98";
                polizaContenedor.TipoSolicitud = abreviaturasTipoSolicitud[cmb_tipoSolicitud.SelectedIndex];
                polizaContenedor.RFC = Principal.RFCEmpresaSeleccionada;
                polizaContenedor.NumTramite = txt_numeroTramite.Text.Trim(); // "0000000001";
                polizaContenedor.Polizas = new List<Poliza>();
                //creando reporte auxiliar de folios
                reporteAuxContendor = new ReportePolizasAux();
                reporteAuxContendor.Anio = Convert.ToInt32(cmb_anios.SelectedItem.ToString());
                reporteAuxContendor.Mes = cmb_mes.SelectedIndex + 1;
                reporteAuxContendor.NumOrden = txt_numeroOrden.Text.Trim(); // "ASD6985555/98";
                reporteAuxContendor.NumTramite = txt_numeroTramite.Text.Trim(); // "0000000001";
                reporteAuxContendor.RFC = Principal.RFCEmpresaSeleccionada;
                reporteAuxContendor.TipoSolicitud = abreviaturasTipoSolicitud[cmb_tipoSolicitud.SelectedIndex];
                reporteAuxContendor.Version = 1.2;
                reporteAuxContendor.DetalleAuxiliarFolios = new List<ReportePolizasAuxDetalle>();


                for (int fila = 0; fila < dgv_polizas.Rows.Count; fila++)
                {
                    Color colorCelda = Herramientas.Forms.DataGridViewConf.ObtenerColorFondoCelda(dgv_polizas, fila, "Póliza");

                    if (colorCelda != Color.Green && colorCelda != Color.Gray)
                        continue;

                    if (colorCelda == Color.Gray)
                    {
                    }

                    Poliza poliza = new Poliza();
                    poliza.NumeroPoliza = Herramientas.Forms.DataGridViewConf.ObtenerValorCelda(dgv_polizas, fila, "Póliza");
                    poliza.Fecha = Convert.ToDateTime(Herramientas.Forms.DataGridViewConf.ObtenerValorCelda(dgv_polizas, fila, "Fecha"));
                    poliza.Concepto = Herramientas.Forms.DataGridViewConf.ObtenerValorCelda(dgv_polizas, fila, "Concepto");
                    poliza.Transacciones = new List<Transaccion>();
                    //detalle de las polizas para reporte auxiliar de folios
                    ReportePolizasAuxDetalle detPol = new ReportePolizasAuxDetalle();
                    detPol.NumUnIdenPol = poliza.NumeroPoliza;
                    detPol.Fecha = poliza.Fecha;
                    
                    detPol.ComprobantesNacionales = new List<ComprobanteNacionalRepPol>();

                    //obteniendo las cuentas contables afectadas
                    DataTable dtCuentas = ObtenerCuentasAfectadas(poliza.NumeroPoliza);

                    foreach (DataRow dr in dtCuentas.Rows)
                    {
                        Transaccion tr = new Transaccion();
                        tr.DesCta = dr["CDESCRIP"].ToString();
                        tr.Concepto = dr["CDESCONCEPTO"].ToString();
                        tr.Debe = Convert.ToDouble(dr["NCARGO"].ToString());
                        tr.Haber = Convert.ToDouble(dr["NABONO"].ToString());
                        tr.NumeroCuenta = dr["CCUENTA_CNT"].ToString();
                        poliza.Transacciones.Add(tr);

                    }

                    //obteniendo los xml relacionados y guardandolos para relacionarlos con las cuentas
                    DataTable dtXML = ObtenerXMLRelacionados(poliza.NumeroPoliza);
                    //listado de arreglos para guardar los objetos
                    List<Transferencia> transferenciasEncontradas = new List<Transferencia>();
                    List<Cheque> chequesEncontrados = new List<Cheque>();
                    List<ComprobanteNacional> comprobantesNacEncontrados = new List<ComprobanteNacional>();
                    //creando los objetos
                    //comprobantes encontrados de nomina son de origen 2
                    double montoTotalXMLOrigen2 = 0;
                    double montoSubTotalXMLOrigen2 = 0;
                    List<ComprobanteNacional> comprobantesNacEncontradosOrigen2 = new List<ComprobanteNacional>();
                    foreach (DataRow dr in dtXML.Rows)
                    {
                        if (dr["sFormaPago"].Equals("TRANSFERENCIA"))
                        {
                            //fue una transferencia

                            Transferencia tr = new Transferencia();

                            Boolean bancoDestNacionalidad = false;
                            try
                            {
                                bancoDestNacionalidad = Convert.ToBoolean(dr["BancoDestinoNacionalidad"].ToString());
                            }
                            catch
                            {
                            }

                            Boolean bancoOriNacionalidad = false;
                            try
                            {
                                bancoOriNacionalidad = Convert.ToBoolean(dr["BancoOrigenNacionalidad"].ToString());
                            }
                            catch
                            {
                            }

                            if (bancoDestNacionalidad)
                                tr.BancoDestinoNal = dr["Banco Destino"].ToString();
                            else
                                tr.BancoDestinoExt = dr["Banco Destino"].ToString();

                            if (bancoOriNacionalidad)
                                tr.BancoOrigenNal = dr["Banco Origen"].ToString();
                            else
                                tr.BancoOrigenExt = dr["Banco Origen"].ToString();

                            tr.Beneficiario = dr["Beneficiario"].ToString();
                            tr.CuentaDestino = dr["Cuenta Destino"].ToString();
                            tr.CuentaOrigen = dr["Cuenta Origen"].ToString();
                            tr.Fecha = Convert.ToDateTime(dr["Fecha"].ToString());
                            tr.Monto = Convert.ToDouble(dr["Monto"].ToString());
                            tr.TipoCambio = Convert.ToDouble(dr["TipoCambioCROP"].ToString());
                            tr.RFC = dr["RFC Tercero"].ToString();
                            //checando si trae el xml

                            if (!dr["cContenidoXML"].ToString().Equals(""))
                            {
                                XML xml = new XML();
                                xml.XMLContenido = dr["cContenidoXML"].ToString();

                                double tipoCambio = 1;
                                try
                                {
                                    //tipoCambio = Convert.ToDouble(xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Comprobante", "TipoCambio"));
                                    tipoCambio = Convert.ToDouble(dr["TipoCambioCROP"].ToString());
                                }
                                catch
                                {
                                }

                                //String moneda = xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Comprobante", "Moneda");
                                String moneda = dr["MonedaSATCROP"].ToString();
                                double montoTotal = Convert.ToDouble(xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Comprobante", "total"));
                                String uuid = xml.ObtenerValorDePropiedad_NODO_XML("tfd", "TimbreFiscalDigital", "uuid");

                                ComprobanteNacional cr = new ComprobanteNacional();
                                cr.Moneda = moneda;
                                cr.MontoTotal = montoTotal;
                                cr.RFC = dr["cRFCReceptor"].ToString();
                                cr.TipCamb = tipoCambio;
                                cr.UUID_CFDI = uuid;
                                

                                comprobantesNacEncontrados.Add(cr);
                            }
                            Boolean encontrado = false;
                            foreach (Transferencia tran in transferenciasEncontradas)
                            {
                                if (tran.Monto == tr.Monto && tran.Fecha == tr.Fecha && tran.RFC == tr.RFC)
                                {
                                    encontrado = true;
                                    break;
                                }
                            }
                            if (!encontrado)
                                transferenciasEncontradas.Add(tr);

                        }
                        else if (dr["sFormaPago"].Equals("CHEQUE"))
                        {
                            //fue un cheque
                            Cheque ch = new Cheque();

                            Boolean bancoOriNacionalidad = false;
                            try
                            {
                                bancoOriNacionalidad = Convert.ToBoolean(dr["BancoOrigenNacionalidad"].ToString());
                            }
                            catch
                            {
                            }


                            if (bancoOriNacionalidad)
                                ch.BancoEmisNal = dr["Banco Origen"].ToString();
                            else
                                ch.BancoEmisExt = dr["Banco Origen"].ToString();

                            ch.Beneficiario = dr["Beneficiario"].ToString();
                            ch.CuentaOrigen = dr["Cuenta Origen"].ToString();
                            ch.Fecha = Convert.ToDateTime(dr["Fecha"].ToString());
                            ch.Monto = Convert.ToDouble(dr["Monto"].ToString());
                            ch.RFC = dr["RFC Tercero"].ToString();
                            ch.NumeroChequeEmitido = dr["No. Cheque"].ToString();
                            ch.TipoCambio = Convert.ToDouble(dr["TipoCambioCROP"].ToString());


                            if (!dr["cContenidoXML"].ToString().Equals(""))
                            {
                                XML xml = new XML();
                                xml.XMLContenido = dr["cContenidoXML"].ToString();

                                double tipoCambio = 1;
                                try
                                {
                                    //tipoCambio = Convert.ToDouble(xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Comprobante", "TipoCambio"));
                                    tipoCambio = Convert.ToDouble(dr["TipoCambioCROP"].ToString());
                                }
                                catch
                                {
                                }
                                //String moneda = xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Comprobante", "Moneda");
                                String moneda = dr["MonedaSATCROP"].ToString();
                                double montoTotal = Convert.ToDouble(xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Comprobante", "total"));
                                String uuid = xml.ObtenerValorDePropiedad_NODO_XML("tfd", "TimbreFiscalDigital", "uuid");

                                ComprobanteNacional cr = new ComprobanteNacional();
                                cr.Moneda = moneda;
                                cr.MontoTotal = montoTotal;
                                cr.RFC = dr["cRFCReceptor"].ToString();
                                cr.TipCamb = tipoCambio;
                                cr.UUID_CFDI = uuid;

                                comprobantesNacEncontrados.Add(cr);
                            }

                            Boolean encontrado = false;
                            foreach (Cheque tran in chequesEncontrados)
                            {
                                if (tran.Monto == ch.Monto && tran.Fecha == ch.Fecha && tran.RFC == ch.RFC)
                                {
                                    encontrado = true;
                                    break;
                                }
                            }
                            if (!encontrado)
                                chequesEncontrados.Add(ch);
                        }
                        else
                        {
                            //solo tomar el xml

                            XML xml = new XML();
                            xml.XMLContenido = dr["cContenidoXML"].ToString();
                            double tipoCambio = 1;
                            try
                            {
                                //tipoCambio = Convert.ToDouble(xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Comprobante", "TipoCambio"));
                                tipoCambio = Convert.ToDouble(dr["TipoCambioCROP"].ToString());
                            }
                            catch
                            {
                            }
                            //String moneda = xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Comprobante", "Moneda");
                            String moneda = dr["MonedaSATCROP"].ToString();
                            double montoTotal = Convert.ToDouble(xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Comprobante", "total"));
                            double montoSubTotal = Convert.ToDouble(xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Comprobante", "subtotal"));
                            double montoImpuestosTrasladados = 0;
                            double montoImpuestosRetenidos = 0;
                            try
                            {
                                montoImpuestosTrasladados = Convert.ToDouble(xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Impuestos", "totalImpuestosTrasladados"));
                            }
                            catch
                            {
                            }
                            try
                            {
                                montoImpuestosRetenidos = Convert.ToDouble(xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Impuestos", "totalImpuestosRetenidos"));
                            }
                            catch
                            {
                            }
                            String uuid = xml.ObtenerValorDePropiedad_NODO_XML("tfd", "TimbreFiscalDigital", "uuid");

                            ComprobanteNacional cr = new ComprobanteNacional();
                            cr.Moneda = moneda;
                            cr.MontoTotal = montoTotal;
                            cr.MontoSubTotal = montoSubTotal;
                            cr.ImpuestosTrasladados = montoImpuestosTrasladados;
                            cr.ImpuestosRetenidos = montoImpuestosRetenidos;
                            cr.RFC = dr["cRFCReceptor"].ToString();
                            cr.TipCamb = tipoCambio;
                            cr.UUID_CFDI = uuid;

                            if (dr["nOrigenDatos"].ToString().Equals("2"))
                            {
                                montoTotalXMLOrigen2 += cr.MontoTotal;
                                montoSubTotalXMLOrigen2 += cr.MontoSubTotal;
                                comprobantesNacEncontradosOrigen2.Add(cr);
                            }
                            else
                                comprobantesNacEncontrados.Add(cr);

                        }
                    }

                    //relacionando los comprobantes con las cuentas
                    //if (poliza.NumeroPoliza.Equals("PD2015100001"))
                    //{
                    //    int nada = 0;
                    //}

                    foreach (Transaccion tr in poliza.Transacciones)
                    {
                        if (tr.ComprobantesNacionales == null) tr.ComprobantesNacionales = new List<ComprobanteNacional>();
                        if (tr.Transferencias == null) tr.Transferencias = new List<Transferencia>();
                        if (tr.Cheques == null) tr.Cheques = new List<Cheque>();
                        foreach (ComprobanteNacional cr in comprobantesNacEncontrados)
                        {
                            //if ((int)tr.Haber == (int)cr.MontoTotal || (int)tr.Debe == (int)cr.MontoTotal || (int)tr.Debe == (int)cr.MontoSubTotal || (int)tr.Debe == (int)cr.ImpuestosTrasladados)
                            //{
                            //    tr.ComprobantesNacionales.Add(cr);
                            //}
                            tr.ComprobantesNacionales.Add(cr);

                            ComprobanteNacionalRepPol rp = new ComprobanteNacionalRepPol();
                            rp.MetPagoAux = "";
                            rp.Moneda = cr.Moneda;
                            rp.MontoTotal = cr.MontoTotal;
                            rp.RFC = cr.RFC;
                            rp.TipCamb = cr.TipCamb;
                            rp.UUID_CFDI = cr.UUID_CFDI;
                            Boolean yaSeAgregoAntes = false;
                            foreach (ComprobanteNacionalRepPol comp in detPol.ComprobantesNacionales)
                            {
                                if (comp.UUID_CFDI.Equals(rp.UUID_CFDI))
                                {
                                    yaSeAgregoAntes = true;
                                    break;
                                }
                            }
                            if (!yaSeAgregoAntes)
                                detPol.ComprobantesNacionales.Add(rp);

                        }
                        if (comprobantesNacEncontradosOrigen2.Count > 0)
                        {
                            //if (colorCelda == Color.Green)
                            //{
                            //    tr.ComprobantesNacionales.AddRange(comprobantesNacEncontradosOrigen2);
                            //    comprobantesNacEncontradosOrigen2.Clear();
                            //}
                            tr.ComprobantesNacionales.AddRange(comprobantesNacEncontradosOrigen2);

                            foreach (ComprobanteNacional cr in comprobantesNacEncontradosOrigen2)
                            {
                                ComprobanteNacionalRepPol rp = new ComprobanteNacionalRepPol();
                                rp.MetPagoAux = "";
                                rp.Moneda = cr.Moneda;
                                rp.MontoTotal = cr.MontoTotal;
                                rp.RFC = cr.RFC;
                                rp.TipCamb = cr.TipCamb;
                                rp.UUID_CFDI = cr.UUID_CFDI;
                                Boolean yaSeAgregoAntes = false;
                                foreach (ComprobanteNacionalRepPol comp in detPol.ComprobantesNacionales)
                                {
                                    if (comp.UUID_CFDI.Equals(rp.UUID_CFDI))
                                    {
                                        yaSeAgregoAntes = true;
                                        break;
                                    }
                                }
                                if (!yaSeAgregoAntes)
                                    detPol.ComprobantesNacionales.Add(rp);
                            }

                        }
                        foreach (Transferencia tra in transferenciasEncontradas)
                        {
                            //if (tr.Haber == tra.Monto)
                            //{
                            
                            tr.Transferencias.Add(tra);
                            //}
                        }
                        foreach (Cheque ch in chequesEncontrados)
                        {
                            //if (tr.Haber == ch.Monto)
                            //{
                            tr.Cheques.Add(ch);
                            //}
                        }
                    }
                    if (polizaContenedor.Polizas == null) polizaContenedor.Polizas = new List<Poliza>();
                    polizaContenedor.Polizas.Add(poliza);
                    reporteAuxContendor.DetalleAuxiliarFolios.Add(detPol);
                }

                xmlResultado = polizaContenedor.ObtenerXMLString();

                ll_xmlPolizas.Tag = Principal.RFCEmpresaSeleccionada + "" + cmb_anios.SelectedItem.ToString() + "" + (cmb_mes.SelectedIndex + 1).ToString("D2") + "" + "PL.xml";



                Herramientas.Forms.Mensajes.Informacion("Se generó correctamente el archivo xml de pólizas: " + ll_xmlPolizas.Tag.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return xmlResultado;
        }


        private String crearXMLSchema()
        {
            #region codigo
            PolizaContenedor polizaContenedor = new PolizaContenedor();
            polizaContenedor.Ano = Convert.ToInt32(cmb_anios.SelectedItem.ToString());
            polizaContenedor.Mes = cmb_mes.SelectedIndex + 1;
            polizaContenedor.Version = 1.1;
            polizaContenedor.NumOrden = "ASD6985555/98";
            polizaContenedor.TipoSolicitud = abreviaturasTipoSolicitud[cmb_tipoSolicitud.SelectedIndex];
            polizaContenedor.RFC = Principal.RFCEmpresaSeleccionada;
            polizaContenedor.NumTramite = "0000000001";
            polizaContenedor.Polizas = new List<Poliza>();

            for (int i = 0; i < 5; i++)
            {
                Poliza poliza = new Poliza();
                poliza.NumeroPoliza = "PZ" + i.ToString("00000");
                poliza.Fecha = DateTime.Now;
                poliza.Concepto = "un concepto de ejemplo " + i;
                poliza.Transacciones = new List<Transaccion>();

                for (int j = 0; j < 2; j++)
                {
                    Random r = new Random();

                    Transaccion trans = new Transaccion();
                    trans.Debe = 50;
                    trans.Haber = 100;
                    trans.NumeroCuenta = r.Next(1, 25000).ToString("00000");
                    trans.DesCta = "una descripcion de cuenta " + j;
                    trans.Concepto = "un concepto " + j;
                    trans.ComprobantesNacionales = new List<ComprobanteNacional>();
                    trans.ComprobantesExtranjeros = new List<ComprobanteExtranjero>();
                    trans.ComprobantesNacionalesOtros = new List<ComprobanteNacionalOtros>();
                    trans.Cheques = new List<Cheque>();
                    trans.Transferencias = new List<Transferencia>();

                    ComprobanteNacional compNal = new ComprobanteNacional();
                    compNal.Moneda = "MXN";
                    compNal.MontoTotal = 500;
                    compNal.RFC = "AACA670219C52";
                    compNal.TipCamb = 1;
                    compNal.UUID_CFDI = "6E96C83C-367E-4AA0-9E00-6D09B973CB6C";
                    trans.ComprobantesNacionales.Add(compNal);

                    ComprobanteExtranjero comExt = new ComprobanteExtranjero();
                    comExt.Moneda = "MXN";
                    comExt.MontoTotal = 100;
                    comExt.NumFactExt = "asdasdasd";
                    comExt.TaxID = "10";
                    comExt.TipCamb = 17;
                    trans.ComprobantesExtranjeros.Add(comExt);

                    ComprobanteNacionalOtros comNacOtros = new ComprobanteNacionalOtros();
                    comNacOtros.CFD_CBB_NumFol = 1;
                    comNacOtros.CFD_CBB_Serie = "ABCDEFG";
                    comNacOtros.Moneda = "USD";
                    comNacOtros.MontoTotal = 250.10;
                    comNacOtros.RFC = "AACA670219C52";
                    comNacOtros.TipCamb = 17;
                    trans.ComprobantesNacionalesOtros.Add(comNacOtros);

                    Transferencia tra = new Transferencia();
                    tra.BancoDestinoNal = "002";
                    tra.BancoOrigenNal = "006";
                    tra.Beneficiario = "una persona x o la agricola";
                    tra.CuentaDestino = "3131321131231";
                    tra.CuentaOrigen = "45465465465465465";
                    tra.Fecha = DateTime.Now;
                    tra.Monto = 200;
                    tra.RFC = "AACA670219C52";
                    trans.Transferencias.Add(tra);

                    Cheque che = new Cheque();
                    che.BancoEmisNal = "006";
                    che.Beneficiario = "un beneficiario";
                    che.CuentaOrigen = "123456";
                    che.Fecha = DateTime.Now;
                    che.Monto = 1000;
                    che.NumeroChequeEmitido = "123134564";
                    che.RFC = "AACA670219C52";
                    trans.Cheques.Add(che);

                    poliza.Transacciones.Add(trans);
                }
                polizaContenedor.Polizas.Add(poliza);
            }
            return polizaContenedor.ObtenerXMLString();
            #endregion
        }
        private Boolean Validar()
        {
            if (!btn_filtroAmarillo.Text.Equals("0") || !btn_filtroRojo.Text.Equals("0"))
            {
                Herramientas.Forms.Mensajes.Exclamacion("Es necesario revisar TODAS las pólizas en Amarillo y Rojo y pasarlas a color VERDE.");
                return false;
            }


            if (cmb_tipoSolicitud.SelectedIndex == -1)
            {
                Herramientas.Forms.Mensajes.Exclamacion("Seleccione un tipo de solicitud.");
                return false;
            }
            return true;
        }
        private void btn_generarXML_Click(object sender, EventArgs e)
        {
            if (!Validar())
                return;

            Herramientas.Forms.Mensajes.Advertencia("El proceso dura unos minutos y solamente considerará las pólizas marcadas en color VERDE, recuerda revisar siempre las pólizas que estén en otro color, presiona ACEPTAR para continuar.");
            xmlPrincipalPolizas = GenerarXMLDePolizas();



        }

        private void ll_xmlPolizas_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MostrarXML_LL(xmlPrincipalPolizas, ll_xmlPolizas);
        }
        private void TestNodosXML(String xml)
        {
            //extrayendo el xml

            string temp = Path.GetTempPath() + Herramientas.Conversiones.Formatos.DateTimeAFechaLOGArchivo(DateTime.Now) + ".xml";

            Herramientas.Archivos.Archivo.GuardarArchivoDeTexto(temp, xml);

            //Create an xml reader;
            XmlDocument _xmlDocument = new XmlDocument();
            _xmlDocument.Load(temp);
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
                foreach (XmlNode xTransaccion in xPoliza.SelectNodes("//PLZ:Transaccion", xmlnsManager))
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
                    //recorriendo cada Comprobante nacional Otro
                    foreach (XmlNode xCompNalOtr in xTransaccion.SelectNodes("//PLZ:CompNalOtr", xmlnsManager))
                    {
                        //atributos CompNal

                        List<String> atCompNalOtr = new List<string>();
                        foreach (XmlAttribute atributo in xCompNalOtr.Attributes)
                        {
                            atCompNalOtr.Add(atributo.Name + "=" + atributo.Value);
                        }
                    }
                    //recorriendo cada Comprobante nacional Otro
                    foreach (XmlNode xCompExt in xTransaccion.SelectNodes("//PLZ:CompExt", xmlnsManager))
                    {
                        //atributos CompNal

                        List<String> atCompExt = new List<string>();
                        foreach (XmlAttribute atributo in xCompExt.Attributes)
                        {
                            atCompExt.Add(atributo.Name + "=" + atributo.Value);
                        }
                    }
                    //recorriendo cada Comprobante nacional Otro
                    foreach (XmlNode xCheque in xTransaccion.SelectNodes("//PLZ:Cheque", xmlnsManager))
                    {
                        //atributos CompNal

                        List<String> atCheque = new List<string>();
                        foreach (XmlAttribute atributo in xCheque.Attributes)
                        {
                            atCheque.Add(atributo.Name + "=" + atributo.Value);
                        }
                    }
                    //recorriendo cada Comprobante nacional Otro
                    foreach (XmlNode xTransferencia in xTransaccion.SelectNodes("//PLZ:Transferencia", xmlnsManager))
                    {
                        //atributos CompNal

                        List<String> atTransferencia = new List<string>();
                        foreach (XmlAttribute atributo in xTransferencia.Attributes)
                        {
                            atTransferencia.Add(atributo.Name + "=" + atributo.Value);
                        }
                    }
                    //recorriendo cada Comprobante nacional Otro
                    foreach (XmlNode xOtrMetodoPago in xTransaccion.SelectNodes("//PLZ:OtrMetodoPago", xmlnsManager))
                    {
                        //atributos CompNal

                        List<String> atOtrMetodoPago = new List<string>();
                        foreach (XmlAttribute atributo in xOtrMetodoPago.Attributes)
                        {
                            atOtrMetodoPago.Add(atributo.Name + "=" + atributo.Value);
                        }
                    }
                }
            }
        }
        private void ll_xmlAuxiliarFolios_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MostrarXML_LL(xmlAuxiliarPolizas, ll_xmlAuxiliarFolios);
        }

        private void ll_xmlAuxiliarCuentas_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MostrarXML_LL(xmlAuxiliarCuentas, ll_xmlAuxiliarCuentas);
        }
        private void MostrarXML_LL(String xml, LinkLabel ll)
        {
            if (ll.Tag.ToString().Equals("") || xml == null || xml.Equals(""))
            {
                Herramientas.Forms.Mensajes.Exclamacion("Debe generar primero el xml.");
                return;
            }
            if (Herramientas.Forms.Mensajes.PreguntaAdvertenciaSIoNO("SI = Ver XML  |  NO = Guardar XML"))
            {
                MostrarXML(xml);
            }
            else
            {
                // se genera la ruta para el guardado del xml
                String ruta = Herramientas.Archivos.Dialogos.BuscarCarpeta(null);
                if (ruta != null && !ruta.Equals(""))
                {
                    // se pregunta si es archivo final o no
                    if (Herramientas.Forms.Mensajes.PreguntaAdvertenciaSIoNO("¿Deseas crear los archivos finales?, si seleccionas NO, generas un temporal con el nombre del server."))
                        ruta += "\\" + ll.Tag.ToString();
                    else
                        ruta += "\\" + Principal.Server + "-" + ll.Tag.ToString();
                    Herramientas.Archivos.Archivo.GuardarArchivoDeTexto(ruta, xml);
                    Herramientas.Forms.Mensajes.Informacion("Archivo guardado exitosamente en: " + ruta);
                }
            }
        }
        private DataTable ObtenerCuentasAfectadas(String poliza)
        {
            String query = @"select cpoliza, SUBSTRING(det.ccuenta_cnt,1,10)+'-'+SUBSTRING(det.ccuenta_cnt,11,10)+'-'+SUBSTRING(det.ccuenta_cnt,21,10)+'-'+SUBSTRING(det.ccuenta_cnt,31,10)+'-'+SUBSTRING(det.ccuenta_cnt,41,10) as CCUENTA_CNT,
            cnt.CDESCRIP, CDESCONCEPTO, NCARGO, NABONO 
            from DETPOLIZAS det 
            inner join CUENTAS_CNT cnt on det.CCUENTA_CNT = cnt.CCUENTA_CNT


            where CPOLIZA = '" + poliza + "'";

            DataTable dt = sql.EjecutarConsulta(query);
            return dt;
        }
        private void MostrarCuentasAfectadas(String poliza)
        {

            DataTable dt = ObtenerCuentasAfectadas(poliza);

            ConfigurarGridDetalleACuentasContables();
            dgv_detalle.Rows.Clear();
            double totalCargo = 0;
            double totalAbono = 0;
            foreach (DataRow dr in dt.Rows)
            {
                double cargo = Convert.ToDouble(dr["NCARGO"]);
                double abono = Convert.ToDouble(dr["NABONO"]);
                totalCargo += cargo;
                totalAbono += abono;
                dgv_detalle.Rows.Add(dr["cpoliza"], dr["CCUENTA_CNT"], dr["CDESCRIP"], dr["CDESCONCEPTO"], Herramientas.Conversiones.Formatos.DoubleAMoneda(cargo), Herramientas.Conversiones.Formatos.DoubleAMoneda(abono));

            }
            dgv_detalle.Rows.Add("", "", "", "TOTALES:", Herramientas.Conversiones.Formatos.DoubleAMoneda(totalCargo), Herramientas.Conversiones.Formatos.DoubleAMoneda(totalAbono));


        }

        private String ObtenerTotalEnXML(String poliza)
        {
            DataTable dt = ObtenerXMLRelacionados(poliza);

            double sumaTotal = 0;
            double sumaSubtotal = 0;
            double sumaImpuestosTrasladados = 0;
            double sumaImpuestosRetenidos = 0;
            foreach (DataRow dr in dt.Rows)
            {
                String montoTotal = "";
                String montoSubtotal = "";
                if (!dr["cContenidoXML"].ToString().Equals(""))
                {
                    XML xml = new XML();
                    xml.XMLContenido = dr["cContenidoXML"].ToString();
                    double tipoCambio = 1;
                    try
                    {
                        //aqui se saca del xml
                        //tipoCambio = Convert.ToDouble(xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Comprobante", "TipoCambio"));
                        //aqui se saca del crop
                        tipoCambio = Convert.ToDouble(dr["TipoCambioCROP"]);
                    }
                    catch
                    {
                    }
                    if (tipoCambio == 0) tipoCambio = 1;

                    double total = Convert.ToDouble(xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Comprobante", "total"));
                    sumaTotal += total * tipoCambio;
                    double subtotal = Convert.ToDouble(xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Comprobante", "subtotal"));
                    sumaSubtotal += subtotal * tipoCambio;
                    try
                    {
                        double impuestos = Convert.ToDouble(xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Impuestos", "totalImpuestosTrasladados"));
                        sumaImpuestosTrasladados += impuestos * tipoCambio;
                    }
                    catch
                    {
                    }
                    try
                    {
                        double impuestos = Convert.ToDouble(xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Impuestos", "totalImpuestosRetenidos"));
                        sumaImpuestosRetenidos += impuestos * tipoCambio;
                    }
                    catch
                    {
                    }
                }

            }

            return sumaSubtotal + "|" + sumaTotal + "|" + (sumaTotal + sumaImpuestosTrasladados) + "|" + (sumaTotal + sumaImpuestosRetenidos);

            //if (true) //sumaTotal >= sumaSubtotal)
            //{
            //    if (sumarImpuestos)
            //        sumaTotal += sumaImpuestos;
            //    return sumaTotal;
            //}
            //else
            //{
            //    if (sumarImpuestos)
            //        sumaSubtotal += sumaImpuestos;
            //    return sumaSubtotal;
            //}

        }
        //Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_detalle, "RFC Receptor", 120);
        //    Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_detalle, "Factura", 120);
        //    Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_detalle, "Monto SubTotal", 110);
        //    Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_detalle, "Monto Total", 110);
        //    Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_detalle, "Concepto", 350);
        //    Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_detalle, "XML", 120);
        private DataTable ObtenerXMLRelacionados(String poliza)
        {
            string query = @"select tabla.*, ele1.EsBancoNacional as [BancoOrigenNacionalidad], ele2.EsBancoNacional as [BancoDestinoNacionalidad] from (
                                select ID, cRFCReceptor, cContenidoXML, fac.cFactura, fac.cPoliza, nOrigenDatos
                                , sFormaPago
                                , case when fpTrans_CuentaOrigen is not null then
                                fpTrans_CuentaOrigen else fpCHEQ_CuentaOrigen end as [Cuenta Origen]
                                , case when fpTRANS_BancoOrigenNacional is not null then
                                fpTRANS_BancoOrigenNacional else fpCHEQ_BancoEmisionNacional end as [Banco Origen]
                                , case when fpTRANS_Fecha is not null then
                                fpTRANS_Fecha else fpCHEQ_Fecha end as [Fecha]
                                , case when fpTRANS_Beneficiario is not null then
                                fpTRANS_Beneficiario else fpCHEQ_Beneficiario end as [Beneficiario]
                                , case when fpTRANS_RFCTercero is not null then
                                fpTRANS_RFCTercero else fpCHEQ_RFCTercero end as [RFC Tercero]
                                , case when fpTRANS_Monto is not null then
                                fpTRANS_Monto else fpCHEQ_Monto end as [Monto]
                                , case when fpTRANS_Moneda is not null then
                                fpTRANS_Moneda else fpCHEQ_Moneda end as [Moneda]
                                , case when fpTRANS_TipoCambio is not null then
                                fpTRANS_TipoCambio else fpCHEQ_TipCambio end as [Tipo cambio]
                                , fpTRANS_CuentaDestino as [Cuenta Destino]
                                , fpTRANS_BancoDestinoNacional as [Banco Destino]
                                , fpCHEQ_NumCheque as [No. Cheque]
                                , case 
                                  when fac.nOrigenDatos = 2 then
	                                1
                                  when fac.sFormaPago is not null then
	                                (select nparidad from MOVTOS_BAN ban where ban.CPOLIZA = fac.cPoliza and ban.CTIPOMOV = 'A' and ban.CSTATUS = 'A' and ban.CAPLICACION = 'S' )
                                  when fac.sFormaPago is null then
	                                (select nparidad from MOVTOS_CXP cxp where isnull(cxp.CPOLIZA, cxp.cpoliza_gastos) = fac.cPoliza and cxp.CFACTURA = fac.cFactura and cxp.CTIPOMOV = 'C' and cxp.CSTATUS = 'A' and cxp.CAPLICADO = 'S' )
  
                                  end as [TipoCambioCROP]
                                , case 
                                  when fac.nOrigenDatos = 2 then
	                                'MXN'
                                  when fac.sFormaPago is not null then --moneda
	                                (select  mon.cMonedaSAT from MOVTOS_BAN ban inner join MONEDAS mon on ban.CMONEDA = mon.CMONEDA where ban.CPOLIZA = fac.cPoliza and ban.CTIPOMOV = 'A' and ban.CSTATUS = 'A' and ban.CAPLICACION = 'S' )
                                  when fac.sFormaPago is null then
	                                (select mon.cMonedaSAT from MOVTOS_CXP cxp inner join MONEDAS mon on cxp.CMONEDA = mon.CMONEDA where isnull(cxp.CPOLIZA, cxp.cpoliza_gastos) = fac.cPoliza and cxp.cFactura = fac.cFactura and cxp.CTIPOMOV = 'C' and cxp.CSTATUS = 'A' and cxp.CAPLICADO = 'S')
  
                                  end 
                                  as [MonedaSATCROP]
                                from empresas..FAC_XML fac 
                                 where fac.cPoliza = '" + poliza + "' and nRFCEmisor = " + Principal.NRFCEmisor + @" and cEstatus = 'A'
                                 and convert(int, SUBSTRING(fac.cpoliza,9,4)) >= " + rangoInferior + @" and convert(int, SUBSTRING(fac.cpoliza,9,4)) <= " + rangoSuperior + @"
                                ) as tabla
                                left join empresas..ELEC_CATALOGO_BANCOS ele1 on tabla.[Banco Origen] = ele1.CodigoBanco
                                left join empresas..ELEC_CATALOGO_BANCOS ele2 on tabla.[Banco Destino] = ele2.CodigoBanco";

            DataTable dt = sql.EjecutarConsulta(query);

            return dt;
        }
        private void MostrarXMLRelacionados(String poliza)
        {
            //String query = "select cRFCReceptor, cContenidoXML, cFactura, cPoliza from empresas..FAC_XML where cPoliza = '"+poliza+"' and nRFCEmisor = "+Principal.NRFCEmisor+" and cEstatus = 'A'";

            DataTable dt = ObtenerXMLRelacionados(poliza);

            ConfigurarGridDetalleAXMLRelacionados();
            dgv_detalle.Rows.Clear();
            double sumaTotal = 0;
            double sumaSubtotal = 0;
            foreach (DataRow dr in dt.Rows)
            {
                String montoTotal = "";
                String montoSubtotal = "";
                String concepto = "";
                String uuid = "";
                double tipoCambio = 0;
                String moneda = "";
                if (!dr["cContenidoXML"].ToString().Equals(""))
                {
                    XML xml = new XML();
                    xml.XMLContenido = dr["cContenidoXML"].ToString();

                    //tipoCambio = Convert.ToDouble(xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Comprobante", "TipoCambio"));
                    tipoCambio = Convert.ToDouble(dr["TipoCambioCROP"].ToString());
                    //moneda = xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Comprobante", "Moneda");
                    moneda = dr["MonedaSATCROP"].ToString();

                    if (tipoCambio == 0) tipoCambio = 1;

                    double total = Convert.ToDouble(xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Comprobante", "total"));
                    montoTotal = Herramientas.Conversiones.Formatos.DoubleAMoneda(total * tipoCambio);
                    sumaTotal += total * tipoCambio;
                    double subtotal = Convert.ToDouble(xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Comprobante", "subtotal"));
                    montoSubtotal = Herramientas.Conversiones.Formatos.DoubleAMoneda(subtotal * tipoCambio);
                    sumaSubtotal += subtotal * tipoCambio;
                    concepto = xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Concepto", "descripcion");
                    uuid = xml.ObtenerValorDePropiedad_NODO_XML("tfd", "TimbreFiscalDigital", "uuid");
                }

                double monto = 0;
                try
                {
                    monto = Convert.ToDouble(dr["Monto"]);
                }
                catch
                {
                }
                dgv_detalle.Rows.Add(dr["ID"], dr["cRFCReceptor"], dr["cFactura"], montoSubtotal, montoTotal, concepto, dr["cContenidoXML"], uuid, moneda, tipoCambio.ToString("0.0000"),
                    dr["sFormaPago"], dr["Cuenta Origen"], dr["Banco Origen"], dr["Fecha"], dr["Beneficiario"], dr["RFC Tercero"], Herramientas.Conversiones.Formatos.DoubleAMoneda(monto), moneda, tipoCambio.ToString("0.0000"), dr["Cuenta Destino"], dr["Banco Destino"]);

            }
            dgv_detalle.Rows.Add("", "", "TOTALES:", Herramientas.Conversiones.Formatos.DoubleAMoneda(sumaSubtotal), Herramientas.Conversiones.Formatos.DoubleAMoneda(sumaTotal), "", "", "", "", "",
                    "", "", "", "", "", "", "", "", "", "", "");
        }

        private void MostrarXML(String xml)
        {
            VisorXML visor = new VisorXML(xml);
            visor.Show();
        }

        private void btn_cuentasAfectadas_Click(object sender, EventArgs e)
        {
            if (dgv_polizas.SelectedRows.Count >= 1)
            {
                String poliza = Herramientas.Forms.DataGridViewConf.ObtenerValorCelda(dgv_polizas, dgv_polizas.SelectedRows[0].Index, "Póliza");
                txt_polizaSeleccionada.Text = poliza;
                MostrarCuentasAfectadas(poliza);
                dgv_detalle.ContextMenuStrip = null;
            }
        }

        private void btn_xmlRelacionados_Click(object sender, EventArgs e)
        {
            if (dgv_polizas.SelectedRows.Count >= 1)
            {
                String poliza = Herramientas.Forms.DataGridViewConf.ObtenerValorCelda(dgv_polizas, dgv_polizas.SelectedRows[0].Index, "Póliza");
                txt_polizaSeleccionada.Text = poliza;
                MostrarXMLRelacionados(poliza);
                dgv_detalle.ContextMenuStrip = this.cm_opcionesFacturas;
            }
        }

        private void dgv_detalle_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    String xml = Herramientas.Forms.DataGridViewConf.ObtenerValorCelda(dgv_detalle, e.RowIndex, "XML");
                    if (!xml.Equals(""))
                        MostrarXML(xml);
                }
                catch
                {
                }
            }
        }


        private void btn_polizasSinXML_Click(object sender, EventArgs e)
        {
            List<String> polizasSinXML = new List<string>();

            for (int i = 0; i < dgv_polizas.Rows.Count; i++)
            {
                String montoXML = Herramientas.Forms.DataGridViewConf.ObtenerValorCelda(dgv_polizas, i, "Total XML");
                string poliza = Herramientas.Forms.DataGridViewConf.ObtenerValorCelda(dgv_polizas, i, "Póliza");
                if (montoXML.Equals("$0.00"))
                {
                    polizasSinXML.Add(poliza);
                }

            }

            if (polizasSinXML.Count > 0)
            {
                PolizasSinXML pol = new PolizasSinXML(sql, cmb_anios.SelectedItem.ToString() + "" + (cmb_mes.SelectedIndex + 1).ToString("D2"), polizasSinXML);
                //pol.FormClosed += pol_FormClosed;
                pol.Show();
            }
            else
            {
                Herramientas.Forms.Mensajes.Exclamacion("No hay xml sin pólizas, verifica los errores con sus movimientos contables.");
            }
        }

        void pol_FormClosed(object sender, FormClosedEventArgs e)
        {
            btn_cargarXML_Click(null, null);
        }

        private void btn_anexarXML_Click(object sender, EventArgs e)
        {
            if (dgv_detalle.SelectedRows.Count > 0)
            {
                string id = "";
                try
                {
                    id = Herramientas.Forms.DataGridViewConf.ObtenerValorCelda(dgv_detalle, dgv_detalle.SelectedRows[0].Index, "ID");

                    String xml = "";

                    xml = Herramientas.Forms.DataGridViewConf.ObtenerValorCelda(dgv_detalle, dgv_detalle.SelectedRows[0].Index, "XML");

                    if (!xml.Trim().Equals(""))
                    {
                        if (!Herramientas.Forms.Mensajes.PreguntaAdvertenciaSIoNO("Ya cuenta con un XML, ¿Desea reemplazarlo?"))
                        {
                            return;
                        }
                    }

                    string rutaArchivo = Herramientas.Archivos.Dialogos.BuscarArchivo(new List<string>() { "Archivo XML" }, new List<string>() { "xml" });

                    if (rutaArchivo != null && !rutaArchivo.Trim().Equals(""))
                    {
                        try
                        {
                            xml = Herramientas.Archivos.Archivo.LeerArchivoTexto(rutaArchivo);

                            String queryUpdate = "update empresas..fac_xml set cContenidoXML = '" + xml + "' where ID = " + id;
                            sql.IniciarTransaccion();
                            sql.EjecutarConsulta(queryUpdate);
                            sql.TerminarTransaccion();

                            Herramientas.Forms.Mensajes.Informacion("XML anexado correctamente");

                            btn_xmlRelacionados_Click(null, null);

                        }
                        catch (Exception ex)
                        {
                            Herramientas.Forms.Mensajes.Error("Ocurrio un error: " + ex.Message);
                        }

                    }
                }
                catch
                {
                }
            }
        }
        private void GuardarEstatusColoresPolizas(List<String> polizasGuardar, List<Color> coloresPolizas)
        {
            try
            {
                sql.IniciarTransaccion();
                for (int i = 0; i < polizasGuardar.Count; i++)
                {
                    String poliza = polizasGuardar[i];
                    Color color = coloresPolizas[i];
                    String colors = "";
                    if (color == Color.Red)
                        colors = "ROJO";
                    else if (color == Color.Yellow)
                        colors = "AMARILLO";
                    else if (color == Color.Green)
                        colors = "VERDE";

                    String queryUpdate = "update empresas..fac_xml set cEstatusRevision = '" + colors + "' where cPoliza = '" + poliza + "' and nRFCEmisor = " + Principal.NRFCEmisor + " and cEstatus = 'A'";

                    sql.EjecutarConsulta(queryUpdate);

                }
                sql.TerminarTransaccion();
            }
            catch (Exception ex)
            {
                Herramientas.Forms.Mensajes.Error("Error: " + ex.Message);
                sql.DeshacerTransaccion();
            }
        }

        private void cambiarAVERDEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CambiarColorPoliza(Color.Green);
        }

        private void cambiarAROJOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CambiarColorPoliza(Color.Red);
        }
        private void CambiarColorPoliza(Color color)
        {

            if (dgv_polizas.SelectedRows.Count > 0)
            {
                if (Herramientas.Forms.Mensajes.PreguntaAdvertenciaSIoNO("¿Deseas cambiar el color a " + dgv_polizas.SelectedRows.Count + " pólizas?"))
                {
                    List<String> polizas = new List<string>();
                    List<Color> colores = new List<Color>();
                    foreach (DataGridViewRow dgvr in dgv_polizas.SelectedRows)
                    {
                        Color colorTexto = Color.White;
                        if (color == Color.Yellow)
                            colorTexto = Color.Black;

                        Color colorAnterior = Herramientas.Forms.DataGridViewConf.ObtenerColorFondoCelda(dgv_polizas, dgvr.Index, "Póliza");

                        if (colorAnterior == Color.Gray)
                        {
                            Herramientas.Forms.Mensajes.Exclamacion("Las pólizas en Gris no pueden cambiar a Verde.");
                            continue;
                        }

                        Herramientas.Forms.DataGridViewConf.CambiarColorCelda(dgv_polizas, color, colorTexto, dgvr.Index, "Póliza");
                        polizas.Add(Herramientas.Forms.DataGridViewConf.ObtenerValorCelda(dgv_polizas, dgvr.Index, "Póliza"));
                        colores.Add(color);
                    }
                    GuardarEstatusColoresPolizas(polizas, colores);
                }
            }
            MostrarFiltrados(colorFiltroActual);
        }

        private void cambiarAAmarilloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CambiarColorPoliza(Color.Yellow);
        }

        private void btn_filtroRojo_Click(object sender, EventArgs e)
        {
            MostrarFiltrados(Color.Red);
        }

        private void btn_filtroAmarillo_Click(object sender, EventArgs e)
        {
            MostrarFiltrados(Color.Yellow);
        }

        private void btn_filtroVerde_Click(object sender, EventArgs e)
        {
            MostrarFiltrados(Color.Green);
        }
        private void btn_filtroGRIS_Click(object sender, EventArgs e)
        {
            MostrarFiltrados(Color.Gray);
        }
        Color colorFiltroActual = Color.Green;
        List<DataGridViewRow> rowsTotales = new List<DataGridViewRow>();
        private void MostrarFiltrados(Color colorFiltro)
        {
            txt_polizaSeleccionada.Text = "";
            dgv_polizas.Rows.Clear();
            dgv_detalle.Rows.Clear();
            colorFiltroActual = colorFiltro;
            foreach (DataGridViewRow dgr in rowsTotales)
            {
                if (dgr.Cells[0].Style.BackColor == colorFiltro || colorFiltro == Color.White)
                {
                    dgv_polizas.Rows.Add(dgr);
                }
            }
            ContarPolizasColores();
        }

        private void btn_todos_Click(object sender, EventArgs e)
        {
            MostrarFiltrados(Color.White);
        }
        private void ContarPolizasColores()
        {
            int conteoRojo = 0;
            int conteoAmarillo = 0;
            int conteoVerde = 0;
            int conteoGris = 0;
            txt_totalPolizas.Text = rowsTotales.Count.ToString();
            foreach (DataGridViewRow dgr in rowsTotales)
            {
                if (dgr.Cells[0].Style.BackColor == Color.Red)
                {
                    conteoRojo++;
                }
                if (dgr.Cells[0].Style.BackColor == Color.Yellow)
                {
                    conteoAmarillo++;
                }
                if (dgr.Cells[0].Style.BackColor == Color.Green)
                {
                    conteoVerde++;
                }
                if (dgr.Cells[0].Style.BackColor == Color.Gray)
                {
                    conteoGris++;
                }
            }
            btn_filtroRojo.Text = conteoRojo.ToString();
            btn_filtroAmarillo.Text = conteoAmarillo.ToString();
            btn_filtroVerde.Text = conteoVerde.ToString();
            btn_filtroGRIS.Text = conteoGris.ToString();
            CalcularTotales();
        }
        private void CalcularTotales()
        {
            double totalesCargo = 0;
            double totalesAbono = 0;
            double totalesXML = 0;
            for (int i = 0; i < dgv_polizas.Rows.Count; i++)
            {
                double totalCargoPoliza = Formatos.StringFormatoDineroADouble(Herramientas.Forms.DataGridViewConf.ObtenerValorCelda(dgv_polizas, i, "Cargo"));
                double totalAbonoPoliza = Formatos.StringFormatoDineroADouble(Herramientas.Forms.DataGridViewConf.ObtenerValorCelda(dgv_polizas, i, "Abono"));
                double totalXMLPoliza = Formatos.StringFormatoDineroADouble(Herramientas.Forms.DataGridViewConf.ObtenerValorCelda(dgv_polizas, i, "Total XML"));

                totalesCargo += totalCargoPoliza;
                totalesAbono += totalAbonoPoliza;
                totalesXML += totalXMLPoliza;

            }

            txt_totalAbonos.Text = Herramientas.Conversiones.Formatos.DoubleAMoneda(totalesAbono);
            txt_totalCargos.Text = Herramientas.Conversiones.Formatos.DoubleAMoneda(totalesCargo);
            txt_totalEnXML.Text = Herramientas.Conversiones.Formatos.DoubleAMoneda(totalesXML);

        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dgv_detalle.SelectedRows.Count > 0)
            {
                String rfc = Herramientas.Forms.DataGridViewConf.ObtenerValorCelda(dgv_detalle, dgv_detalle.SelectedRows[0].Index, "RFC Receptor");
                if (rfc != null && !rfc.Trim().Equals(""))
                {
                    Clipboard.SetText(rfc.Trim());
                    Herramientas.Forms.Mensajes.Informacion("RFC copiado correctamente: '" + rfc + "'.");
                }
                else
                {
                    Herramientas.Forms.Mensajes.Exclamacion("Seleccione la fila donde se encuentra el RFC del XML.");
                }
            }
            else
            {
                Herramientas.Forms.Mensajes.Exclamacion("Seleccione la fila donde se encuentra el RFC del XML.");
            }
        }

        private void copiarPólizaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv_polizas.SelectedRows.Count > 0)
            {
                String poliza = Herramientas.Forms.DataGridViewConf.ObtenerValorCelda(dgv_polizas, dgv_polizas.SelectedRows[0].Index, "Póliza");
                if (poliza != null && !poliza.Trim().Equals(""))
                {
                    Clipboard.SetText(poliza.Trim());
                    Herramientas.Forms.Mensajes.Informacion("Póliza copiada correctamente: '" + poliza + "'.");
                }
                else
                {
                    Herramientas.Forms.Mensajes.Exclamacion("Seleccione la fila donde se encuentra la póliza.");
                }
            }
            else
            {
                Herramientas.Forms.Mensajes.Exclamacion("Seleccione la fila donde se encuentra la póliza.");
            }
        }

        private void btn_unirConotroXML_Click(object sender, EventArgs e)
        {
            if (ll_xmlPolizas.Text.Trim().Equals(""))
            {
                Herramientas.Forms.Mensajes.Error("Debe Generar el XML antes de unirlo con otro.");
                return;
            }
            String ruta = Herramientas.Archivos.Dialogos.BuscarArchivo(new List<string>() { "Archivo XML" }, new List<String>() { "xml" });
            if (ruta != null && !ruta.Equals(""))
            {
                XML x = new XML(ruta);

                String RFC = x.ObtenerValorDePropiedad_NODO_XML("PLZ", "Polizas", "RFC");
                String Mes = x.ObtenerValorDePropiedad_NODO_XML("PLZ", "Polizas", "Mes");
                String Anio = x.ObtenerValorDePropiedad_NODO_XML("PLZ", "Polizas", "Anio");
                String TipoSolicitud = x.ObtenerValorDePropiedad_NODO_XML("PLZ", "Polizas", "TipoSolicitud");
                String NumOrden = x.ObtenerValorDePropiedad_NODO_XML("PLZ", "Polizas", "NumOrden");
                String NumTramite = x.ObtenerValorDePropiedad_NODO_XML("PLZ", "Polizas", "NumTramite");
                //validando los datos

                if (!RFC.Equals(polizaContenedor.RFC))
                {
                    Herramientas.Forms.Mensajes.Error("El RFC del XML que seleccionaste no coincide con el de la empresa que estas trabajando actualmente.");
                    return;
                }
                if (!Mes.Equals(polizaContenedor.Mes.ToString("00")))
                {
                    Herramientas.Forms.Mensajes.Error("El Mes del XML que seleccionaste no coincide con el de la empresa que estas trabajando actualmente.");
                    return;
                }
                if (!Anio.Equals(polizaContenedor.Ano.ToString()))
                {
                    Herramientas.Forms.Mensajes.Error("El Año del XML que seleccionaste no coincide con el de la empresa que estas trabajando actualmente.");
                    return;
                }
                if (!TipoSolicitud.Equals(polizaContenedor.TipoSolicitud))
                {
                    Herramientas.Forms.Mensajes.Error("El Tipo de Solicitud del XML que seleccionaste no coincide con el de la empresa que estas trabajando actualmente.");
                    return;
                }
                if (TipoSolicitud.Equals("AF") || TipoSolicitud.Equals("FC"))
                {
                    if (!NumOrden.Equals(polizaContenedor.NumOrden))
                    {
                        Herramientas.Forms.Mensajes.Error("El Numero de Orden del XML que seleccionaste no coincide con el de la empresa que estas trabajando actualmente.");
                        return;
                    }
                }
                if (TipoSolicitud.Equals("DE") || TipoSolicitud.Equals("CO"))
                {
                    if (!NumTramite.Equals(polizaContenedor.NumTramite))
                    {
                        Herramientas.Forms.Mensajes.Error("El Numero de Tramite del XML que seleccionaste no coincide con el de la empresa que estas trabajando actualmente.");
                        return;
                    }
                }

                List<String> nodos = x.ObtenerNodos_XML("PLZ", "Polizas");

                xmlPrincipalPolizas = xmlPrincipalPolizas.Replace("</PLZ:Polizas>", "");
                String nuevas = "";
                foreach (String poliza in nodos)
                {
                    nuevas += poliza;
                }

                nuevas = nuevas.Replace("xmlns:PLZ=\"http://www.sat.gob.mx/esquemas/ContabilidadE/1_1/PolizasPeriodo\"", "");
                xmlPrincipalPolizas += nuevas;
                xmlPrincipalPolizas += "</PLZ:Polizas>";

                Herramientas.Forms.Mensajes.Informacion("XML Unidos Correctamente, Verifica las pólizas agregdas al final del XML.");

            }
        }

        private void btn_generarExcel_Click(object sender, EventArgs e)
        {
            String ruta = Herramientas.Archivos.Dialogos.BuscarCarpeta(null);

            if (ruta != null && !ruta.Equals(""))
            {
                String nombreArchivo = Principal.RFCEmpresaSeleccionada + "" + cmb_anios.SelectedItem.ToString() + "" + (cmb_mes.SelectedIndex + 1).ToString("D2") + "" + "PL.pdf";
                nombreArchivo = Principal.Server + " - " + nombreArchivo;
                PDF.ExportarDataGridViewToPDF(new List<DataGridView>() { dgv_polizas }, ruta + "\\" + nombreArchivo, new List<String>() { "Pólizas Registradas de " + Principal.NombreEmpresaSeleccionada + " para XML.", "Periodo " + cmb_anios.SelectedItem.ToString() + " del mes de " + cmb_mes.SelectedItem.ToString() }, true, new List<string>() { "Pólizas registradas para XML:" });
            }
        }
        //xml de auxiliares de cuentas
        private String GenerarXMLReporteAuxiliarCuentas()
        {
            try
            {
                // auxiliar de cuentas
                cuentasAuxContenedor = new AuxiliarCuentas();
                cuentasAuxContenedor.Anio = Convert.ToInt32(cmb_anios.SelectedItem.ToString());
                cuentasAuxContenedor.Mes = cmb_mes.SelectedIndex + 1;
                cuentasAuxContenedor.NumOrden = txt_numeroOrden.Text.Trim(); // "ASD6985555/98";
                cuentasAuxContenedor.NumTramite = txt_numeroTramite.Text.Trim(); // "0000000001";
                cuentasAuxContenedor.RFC = Principal.RFCEmpresaSeleccionada;
                cuentasAuxContenedor.TipoSolicitud = abreviaturasTipoSolicitud[cmb_tipoSolicitud.SelectedIndex];
                cuentasAuxContenedor.Version = 1.1;
                cuentasAuxContenedor.DetalleCuentas = new List<AuxiliarCuentasCuenta>();

                String query = @"
                            declare @fechaFinMesSeleccionado as datetime = '2015-07-31'
                            declare @fechaSaldo as datetime = '2015-06-30'
                            declare @cuenta as varchar(max) = ''
                            select SUBSTRING(det.ccuenta_cnt,1,10)+'-'+SUBSTRING(det.ccuenta_cnt,11,10)+'-'+SUBSTRING(det.ccuenta_cnt,21,10)+'-'+SUBSTRING(det.ccuenta_cnt,31,10)+'-'+SUBSTRING(det.ccuenta_cnt,41,10) as CCUENTA_CNTs
                            -- cnt.CNATURALEZA,
                            , cnt.CDESCRIP,
                            sum(case when convert(char(10), enc.DFECHA, 121) <= convert(char(10),@fechaSaldo,121) then det.NCARGO else 0 end) - sum(case when convert(char(10), enc.DFECHA, 121) <= convert(char(10),@fechaSaldo,121) then det.NABONO else 0 end) as [Saldo Inicial],
                            sum(case when year(enc.dfecha) = year(@fechaFinMesSeleccionado) and month(enc.dfecha) = MONTH(@fechaFinMesSeleccionado) then det.NCARGO else 0 end) as [Cargo del mes], 
                            sum(case when year(enc.dfecha) = year(@fechaFinMesSeleccionado) and month(enc.dfecha) = MONTH(@fechaFinMesSeleccionado) then det.NABONO else 0 end) as [Abono del mes],
                            case when cnt.CNATURALEZA = 'A' then
	                            (sum(case when convert(char(10), enc.DFECHA, 121) <= convert(char(10),@fechaSaldo,121) then det.NCARGO else 0 end) - sum(case when convert(char(10), enc.DFECHA, 121) <= convert(char(10),@fechaSaldo,121) then det.NABONO else 0 end))
	                            - (sum(case when year(enc.dfecha) = year(@fechaFinMesSeleccionado) and month(enc.dfecha) = MONTH(@fechaFinMesSeleccionado) then det.NCARGO else 0 end))
	                            + sum(case when year(enc.dfecha) = year(@fechaFinMesSeleccionado) and month(enc.dfecha) = MONTH(@fechaFinMesSeleccionado) then det.NABONO else 0 end)
                            else
	                            (sum(case when convert(char(10), enc.DFECHA, 121) <= convert(char(10),@fechaSaldo,121) then det.NCARGO else 0 end) - sum(case when convert(char(10), enc.DFECHA, 121) <= convert(char(10),@fechaSaldo,121) then det.NABONO else 0 end))
	                            + (sum(case when year(enc.dfecha) = year(@fechaFinMesSeleccionado) and month(enc.dfecha) = MONTH(@fechaFinMesSeleccionado) then det.NCARGO else 0 end))
	                            - sum(case when year(enc.dfecha) = year(@fechaFinMesSeleccionado) and month(enc.dfecha) = MONTH(@fechaFinMesSeleccionado) then det.NABONO else 0 end)
                            end as [Saldo fin]
                            from CUENTAS_CNT cnt 
                            left join detpolizas det on cnt.CCUENTA_CNT = det.CCUENTA_CNT 
                            left join ENCPOLIZAS enc on det.CPOLIZA = enc.CPOLIZA and det.COFICINA = enc.COFICINA
                            
                            where convert(char(10), enc.DFECHA, 121) <= @fechaFinMesSeleccionado  and enc.CSTATUS = 'A' and det.coficina = '0001'
                            and convert(int, SUBSTRING(enc.cpoliza,9,4)) >= " + rangoInferior + @" and convert(int, SUBSTRING(enc.cpoliza,9,4)) <= " + rangoSuperior + @"
                            --and cnt.ccuenta_cnt = @cuenta
                            group by det.CCUENTA_CNT, cnt.CDESCRIP, cnt.cnaturaleza
                            order by CCUENTA_CNTs";
                DataTable dt = sql.EjecutarConsulta(query);

                cuentasAuxContenedor.DetalleCuentas = new List<AuxiliarCuentasCuenta>();

                foreach (DataRow dr in dt.Rows)
                {
                    String cnt = dr["CCUENTA_CNTs"].ToString();
                    String queryDetalle = @"declare @fechaFinMesSeleccionado as datetime = '2015-07-31'
                                        select cnt.CCUENTA_CNT, enc.DFECHA, enc.CPOLIZA, enc.CDESCONCEPTO, det.NCARGO as [Debe], det.NABONO as [Haber]
                                        from CUENTAS_CNT cnt 
                                        left join detpolizas det on cnt.CCUENTA_CNT = det.CCUENTA_CNT 
                                        left join ENCPOLIZAS enc on det.CPOLIZA = enc.CPOLIZA and det.COFICINA = enc.COFICINA
                                        where year(enc.dfecha) = year(@fechaFinMesSeleccionado) and month(enc.dfecha) = MONTH(@fechaFinMesSeleccionado)  and enc.CSTATUS = 'A' and det.coficina = '0001'
                                        and convert(int, SUBSTRING(enc.cpoliza,9,4)) >= " + rangoInferior + @" and convert(int, SUBSTRING(enc.cpoliza,9,4)) <= " + rangoSuperior + @"
                                        and cnt.ccuenta_cnt = '" + cnt.Replace("-", "") + @"'
                                        --group by cnt.CCUENTA_CNT, cnt.CNATURALEZA
                                        order by cnt.CCUENTA_CNT";

                    AuxiliarCuentasCuenta cuenta = new AuxiliarCuentasCuenta();
                    cuenta.DetalleCuentas = new List<AuxiliarCuentasCuentaDetalle>();
                    cuenta.DesCta = dr["CDESCRIP"].ToString();
                    cuenta.NumCta = cnt;
                    cuenta.SaldoIni = Convert.ToDouble(dr["Saldo Inicial"].ToString());
                    cuenta.SaldoFin = Convert.ToDouble(dr["Saldo fin"].ToString());

                    DataTable dtDetallePolizas = sql.EjecutarConsulta(queryDetalle);

                    foreach (DataRow drd in dtDetallePolizas.Rows)
                    {
                        AuxiliarCuentasCuentaDetalle det = new AuxiliarCuentasCuentaDetalle();
                        det.Concepto = drd["CDESCONCEPTO"].ToString();
                        det.Debe = Convert.ToDouble(drd["Debe"].ToString());
                        det.Haber = Convert.ToDouble(drd["Haber"].ToString());
                        det.Fecha = Convert.ToDateTime(drd["DFECHA"]);
                        det.NumUnIdenPol = drd["CPOLIZA"].ToString();
                        cuenta.DetalleCuentas.Add(det);
                    }

                    cuentasAuxContenedor.DetalleCuentas.Add(cuenta);

                }
                ll_xmlAuxiliarCuentas.Tag = Principal.RFCEmpresaSeleccionada + "" + cmb_anios.SelectedItem.ToString() + "" + (cmb_mes.SelectedIndex + 1).ToString("D2") + "" + "XC.xml";

                return cuentasAuxContenedor.ObtenerXMLString();
            }
            catch (Exception ex)
            {
                Herramientas.Forms.Mensajes.Error("Ocurrió un error al generar el XML 'Reporte Auxliar cuentas': " + ex.Message);
                throw ex;
            }
        }
        //xml de auxiliares de folios (polizas)
        private String GenerarXMLAuxiliarPolizas_ReporteAuxiliarFolios()
        {
            try
            {
                ll_xmlAuxiliarFolios.Tag = Principal.RFCEmpresaSeleccionada + "" + cmb_anios.SelectedItem.ToString() + "" + (cmb_mes.SelectedIndex + 1).ToString("D2") + "" + "XF.xml";
                return reporteAuxContendor.ObtenerXMLString();
            }
            catch (Exception ex)
            {
                Herramientas.Forms.Mensajes.Error("Ocurrió un error al generar el XML 'Reporte Auxliar folios': " + ex.Message);
                throw ex;
            }
        }

        private void btn_generarXMLAuxiliarFolios_Click(object sender, EventArgs e)
        {
            if (!Validar())
                return;
            if (xmlPrincipalPolizas == null || xmlPrincipalPolizas.Equals(""))
            {
                Herramientas.Forms.Mensajes.Exclamacion("Debe generar antes el XML de Pólizas para poder generar este xml.");
                return;
            }
            xmlAuxiliarPolizas = GenerarXMLAuxiliarPolizas_ReporteAuxiliarFolios();
            Herramientas.Forms.Mensajes.Informacion("XML Generado Correctamente.");
        }

        private void btn_GenerarAuxiliarCuentas_Click(object sender, EventArgs e)
        {
            if (!Validar())
                return;
            btn_GenerarAuxiliarCuentas.Enabled = false;
            Thread tEjecutarHiloXML = new Thread(EjecutarHiloXMLGenerado);
            tEjecutarHiloXML.IsBackground = true;
            tEjecutarHiloXML.Start();
        }
        private void EjecutarHiloXMLGenerado()
        {
            xmlAuxiliarCuentas = GenerarXMLReporteAuxiliarCuentas();
            Herramientas.Forms.Mensajes.Informacion("XML Generado Correctamente.");
            btn_GenerarAuxiliarCuentas.Enabled = true;
        }
        private void btn_unirAuxiliarFolios_Click(object sender, EventArgs e)
        {

        }

        private void btn_unirAuxiliarCuentas_Click(object sender, EventArgs e)
        {

        }

        
    }
}
