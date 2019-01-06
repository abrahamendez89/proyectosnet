using Dominio;
using Herramientas.Archivos;
using Herramientas.Forms;
using Herramientas.ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DescargaMasivaXMLSAT
{
    public partial class XMLEnBD : Form
    {
        ManejadorDB manejador;
        _CuentaEmpresa empresa;
        DataTable dtResultado;
        Boolean esRecibido = false;
        public XMLEnBD(ManejadorDB manejador, _CuentaEmpresa empresa)
        {
            InitializeComponent();
            this.manejador = manejador;
            this.empresa = empresa;
            cmb_rfc.Sorted = true;
        }

        private void btn_emitidos_Click(object sender, EventArgs e)
        {
            if (descargandoTodos)
            {
                Herramientas.Forms.Mensajes.Exclamacion("Esta descargando los XML, espere un momento.");
                return;
            }
            esRecibido = false;
            dgv_consulta.Rows.Clear();
            cmb_rfc.Items.Clear();
            if (cmb_rfc.Text != null && !cmb_rfc.Text.Equals(""))
            {
                String query = "select * from _XMLCFDI where _st_RFCEmisor = @rfcEmisor and _st_RFCReceptor = @rfcFiltro and _dt_FechaEmisionFactura between @fechaDesde and @fechaHasta order by _dt_FechaEmisionFactura desc";
                dtResultado = manejador.EjecutarConsulta(query, new List<object>() { empresa.Usuario, cmb_rfc.Text.ToString(), new DateTime(dtp_Desde.Value.Year, dtp_Desde.Value.Month, dtp_Desde.Value.Day, 0, 0, 0), new DateTime(dtp_Hasta.Value.Year, dtp_Hasta.Value.Month, dtp_Hasta.Value.Day, 23, 59, 59) });
            }
            else
            {
                String query = "select * from _XMLCFDI where _st_RFCEmisor = @rfcEmisor and _dt_FechaEmisionFactura between @fechaDesde and @fechaHasta order by _dt_FechaEmisionFactura desc";
                dtResultado = manejador.EjecutarConsulta(query, new List<object>() { empresa.Usuario, new DateTime(dtp_Desde.Value.Year, dtp_Desde.Value.Month, dtp_Desde.Value.Day, 0, 0, 0), new DateTime(dtp_Hasta.Value.Year, dtp_Hasta.Value.Month, dtp_Hasta.Value.Day, 23, 59, 59) });
            }
            Boolean alternado = false;
            int indice = 0;
            foreach (DataRow dr in dtResultado.Rows)
            {
                String nombreArchivoTEMP = Environment.CurrentDirectory + "\\" + "tmp_" + Herramientas.Conversiones.Formatos.DateTimeAFechaLOGArchivo(DateTime.Now) + ".xml";

                Herramientas.Archivos.Archivo.GuardarArchivoDeTexto(nombreArchivoTEMP, dr["_st_ContenidoXML"].ToString());

                XML xml = new XML(nombreArchivoTEMP);

                String nombre = xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Receptor", "nombre");

                String folio = xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Comprobante", "folio");

                if (nombre == null) nombre = "Sin nombre registrado";
                if (folio == null) folio = "Sin folio";

                dgv_consulta.Rows.Add(Herramientas.Conversiones.Formatos.DateTimeAFechaCortaConMesTextoAbreviado(Convert.ToDateTime(dr["_dt_FechaEmisionFactura"])), dr["_st_RFCReceptor"], nombre, Herramientas.Conversiones.Formatos.DoubleAMonedaANDecimales(Convert.ToDouble(dr["_do_Monto"]), 2), folio, dr["_st_UUID"]);
                if (!cmb_rfc.Items.Contains(dr["_st_RFCReceptor"].ToString()))
                {
                    cmb_rfc.Items.Add(dr["_st_RFCReceptor"].ToString());
                }
                Herramientas.Archivos.Archivo.EliminarArchivo(nombreArchivoTEMP);

                if (alternado)
                {
                    dgv_consulta.Rows[indice].DefaultCellStyle.BackColor = Color.LightBlue;
                }
                alternado = !alternado;
                indice++;
            }
        }
        private void OrdenarRFC()
        {

        }
        private void btn_recibidos_Click(object sender, EventArgs e)
        {
            if (descargandoTodos)
            {
                Herramientas.Forms.Mensajes.Exclamacion("Esta descargando los XML, espere un momento.");
                return;
            }
            esRecibido = true;
            dgv_consulta.Rows.Clear();
            cmb_rfc.Items.Clear();
            if (cmb_rfc.Text != null && !cmb_rfc.Text.Equals(""))
            {
                String query = "select * from _XMLCFDI where _st_RFCReceptor = @rfcEmisor and _st_RFCEmisor = @rfcFiltro and _dt_FechaEmisionFactura between @fechaDesde and @fechaHasta order by _dt_FechaEmisionFactura desc";
                dtResultado = manejador.EjecutarConsulta(query, new List<object>() { empresa.Usuario, cmb_rfc.Text.ToString(), new DateTime(dtp_Desde.Value.Year, dtp_Desde.Value.Month, dtp_Desde.Value.Day, 0, 0, 0), new DateTime(dtp_Hasta.Value.Year, dtp_Hasta.Value.Month, dtp_Hasta.Value.Day, 23, 59, 59) });
            }
            else
            {
                String query = "select * from _XMLCFDI where _st_RFCReceptor = @rfcEmisor and _dt_FechaEmisionFactura between @fechaDesde and @fechaHasta order by _dt_FechaEmisionFactura desc";
                dtResultado = manejador.EjecutarConsulta(query, new List<object>() { empresa.Usuario, new DateTime(dtp_Desde.Value.Year, dtp_Desde.Value.Month, dtp_Desde.Value.Day, 0, 0, 0), new DateTime(dtp_Hasta.Value.Year, dtp_Hasta.Value.Month, dtp_Hasta.Value.Day, 23, 59, 59) });
            }
            Boolean alternado = false;
            int indice = 0;
            foreach (DataRow dr in dtResultado.Rows)
            {
                String nombreArchivoTEMP = Environment.CurrentDirectory + "\\" + "tmp_" + Herramientas.Conversiones.Formatos.DateTimeAFechaLOGArchivo(DateTime.Now) + ".xml";

                Herramientas.Archivos.Archivo.GuardarArchivoDeTexto(nombreArchivoTEMP, dr["_st_ContenidoXML"].ToString());

                XML xml = new XML(nombreArchivoTEMP);

                String nombre = xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Emisor", "nombre");

                String folio = xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Comprobante", "folio");

                if (nombre == null) nombre = "Sin nombre registrado";
                if (folio == null) folio = "Sin folio";

                dgv_consulta.Rows.Add(Herramientas.Conversiones.Formatos.DateTimeAFechaCortaConMesTextoAbreviado(Convert.ToDateTime(dr["_dt_FechaEmisionFactura"])), dr["_st_RFCEmisor"], nombre, Herramientas.Conversiones.Formatos.DoubleAMonedaANDecimales(Convert.ToDouble(dr["_do_Monto"]), 2), folio, dr["_st_UUID"]);
                if (!cmb_rfc.Items.Contains(dr["_st_RFCEmisor"].ToString()))
                {
                    cmb_rfc.Items.Add(dr["_st_RFCEmisor"].ToString());
                }
                Herramientas.Archivos.Archivo.EliminarArchivo(nombreArchivoTEMP);

                if (alternado)
                {
                    dgv_consulta.Rows[indice].DefaultCellStyle.BackColor = Color.LightBlue;
                }
                alternado = !alternado;
                indice++;
            }
        }
        String nombreArchivoTEMP;
        private void dgv_consulta_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex == -1)
                return;

            nombreArchivoTEMP = Environment.CurrentDirectory + "\\" + "tmp_" + Herramientas.Conversiones.Formatos.DateTimeAFechaLOGArchivo(DateTime.Now) + ".xml";

            Herramientas.Archivos.Archivo.GuardarArchivoDeTexto(nombreArchivoTEMP, dtResultado.Rows[e.RowIndex]["_st_ContenidoXML"].ToString());

            wb.Navigate(nombreArchivoTEMP);
        }

        private void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            Herramientas.Archivos.Archivo.EliminarArchivo(nombreArchivoTEMP);
        }

        private void btn_exportarExcel_Click(object sender, EventArgs e)
        {
            String nombreArchivo = empresa.Usuario + "_DESDE_" + Herramientas.Conversiones.Formatos.DateTimeAFechaCortaConMesTextoAbreviado(dtp_Desde.Value) + "_HASTA_" + Herramientas.Conversiones.Formatos.DateTimeAFechaCortaConMesTextoAbreviado(dtp_Hasta.Value) + ".xls";

            String ruta = Herramientas.Archivos.Dialogos.GuardarArchivoRuta(new List<string>() { "Archivo de excel." }, new List<string>() { "xls" }, nombreArchivo);

            if (ruta != null)
            {
                ExcelAPI excel = new ExcelAPI();
                excel.ConvertirDataGridViewAExcel(ruta, dgv_consulta, Color.Orange, Color.White);
                excel.terminoConversion += excel_terminoConversion;
            }
        }

        void excel_terminoConversion(string rutaGuardado)
        {
            Herramientas.Forms.Mensajes.Informacion("Archivo guardado con exito en " + rutaGuardado);
        }

        private void btn_descargarXML_Click(object sender, EventArgs e)
        {

            if (dgv_consulta.SelectedRows.Count == 0)
                return;

            String nombreArchivo = empresa.Usuario + "_" + dgv_consulta.SelectedRows[0].Cells[1].Value.ToString() + "_" + dgv_consulta.SelectedRows[0].Cells[4].Value.ToString() + "_" + dgv_consulta.SelectedRows[0].Cells[3].Value.ToString().Replace("$", "").Replace(",", "") + ".xml";

            String ruta = Herramientas.Archivos.Dialogos.GuardarArchivoRuta(new List<string>() { "Archivo XML." }, new List<string>() { "xml" }, nombreArchivo);

            if (ruta != null)
            {
                Herramientas.Archivos.Archivo.GuardarArchivoDeTexto(ruta, dtResultado.Rows[dgv_consulta.SelectedRows[0].Index]["_st_ContenidoXML"].ToString());
                Herramientas.Forms.Mensajes.Informacion("Archivo guardado con exito en " + ruta);
            }
        }

        private void btn_descargarTodosXML_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(ProcesoDescarga);
            t.Start();
        }
        private Boolean descargandoTodos = false;
        private void ProcesoDescarga()
        {
            descargandoTodos = true;
            int i = 0;
            foreach (DataRow dr in dtResultado.Rows)
            {
                String urlTemp = Environment.CurrentDirectory + "\\TEMP\\T" + Herramientas.Conversiones.Formatos.DateTimeAFechaLOGArchivo(DateTime.Now) + ".xml";
                String archivo = dr["_st_ContenidoXML"].ToString();
                Herramientas.Archivos.Archivo.GuardarArchivoDeTexto(urlTemp, archivo);

                XML xml = new XML(urlTemp);


                String folioFactura = xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Comprobante", "folio");
                String total = xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Comprobante", "total");
                String fecha = xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Comprobante", "fecha");
                String UUID = xml.ObtenerValorDePropiedad_NODO_XML("tfd", "TimbreFiscalDigital", "UUID");

                if (UUID == null)
                {
                    int indice = archivo.ToUpper().IndexOf("UUID");
                    indice += 6;
                    UUID = archivo.Substring(indice, 32 + 4);
                }

                //DataTable dt = manejador.EjecutarConsulta("select id from _XMLCFDI where _st_uuid = '" + UUID + "'");



                String rfcEmisor = xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Emisor", "rfc");
                String rfcReceptor = xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Receptor", "rfc");
                DateTime fechaC = Convert.ToDateTime(fecha);
                String complemento = "";


                String rfcDestino = "";


                if (rfcEmisor.ToUpper().Trim().Equals(empresa.Usuario.ToUpper().Trim()))
                    esRecibido = false;
                else if (rfcReceptor.ToUpper().Trim().Equals(empresa.Usuario.ToUpper().Trim()))
                    esRecibido = true;

                if (esRecibido)
                {
                    String nombreEmpresaEmisora = xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Emisor", "nombre");
                    if (nombreEmpresaEmisora == null) nombreEmpresaEmisora = "SIN_NOMBRE";
                    nombreEmpresaEmisora = nombreEmpresaEmisora.Replace("\\", "").Replace("/", "").Replace(":", "").Replace("*", "").Replace("\"", "").Replace("?", "").Replace("<", "").Replace(">", "").Replace("|", "").Trim();
                    rfcDestino = nombreEmpresaEmisora + "-" + xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Emisor", "rfc");
                    complemento = "RECIBIDAS";
                }
                else
                {
                    String nombreEmpresaEmisora = xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Receptor", "nombre");
                    if (nombreEmpresaEmisora == null) nombreEmpresaEmisora = "SIN_NOMBRE";
                    rfcDestino = nombreEmpresaEmisora + "-" + xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Receptor", "rfc");
                    nombreEmpresaEmisora = nombreEmpresaEmisora.Replace("\\", "").Replace("/", "").Replace(":", "").Replace("*", "").Replace("\"", "").Replace("?", "").Replace("<", "").Replace(">", "").Replace("|", "").Trim();
                    complemento = "EMITIDAS";
                }

                if (folioFactura == null) folioFactura = "SIN_FOLIO";

                String rutaClasificada = Environment.CurrentDirectory + "\\" + "CLASIFICADOS\\" + empresa.Usuario + "\\" + complemento + "\\" + rfcDestino + "\\" + fechaC.Year + "\\" + Herramientas.Conversiones.Formatos.DatetimeANombreMesLargo(fechaC).ToUpper() + "\\";
                Herramientas.Archivos.Archivo.CrearCarpetaSiNoExiste(rutaClasificada);
                String rutaClasificado = rutaClasificada + Herramientas.Conversiones.Formatos.DateTimeAFechaLOGArchivo(fechaC) + "_" + folioFactura + "_" + total + ".xml";
                try
                {
                    rutaClasificado = rutaClasificado.Trim().Replace("  ", " ");
                    if (!Herramientas.Archivos.Archivo.ExisteArchivo(rutaClasificado))
                        Herramientas.Archivos.Archivo.GuardarArchivoDeTexto(rutaClasificado, archivo, false);
                    Herramientas.Archivos.Archivo.EliminarArchivo(urlTemp);
                }
                catch
                {
                    try
                    {
                        //lbl_tarea.Text = "Falló al guardar el archivo: " + urlTemp;
                    }
                    catch { }
                    //Thread.Sleep(2000);
                }
                i++;
                pb_progreso.Value = (i * 100) / dtResultado.Rows.Count;
            }
            Herramientas.Forms.Mensajes.Informacion("El proceso terminó satisfactoriamente.");
            pb_progreso.Value = 0;
            descargandoTodos = false;
        }
    }
}
