using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Herramientas;
using System.Xml;
using Herramientas.Archivos;
using System.Threading;
using Herramientas.SQL;
using Herramientas.WPF;
using Herramientas.Forms;

namespace ContabilidadElectronica.Formularios
{
    public partial class CargarXMLABD : Form
    {
        iSQL sql;
        Variable var;
        public CargarXMLABD()
        {
            InitializeComponent();
            sql = Login.sql;
            var = new Variable("Parametros.ini");
            btn_SubirAlServidor.Enabled = false;
            dgv_Archivos.CellContentDoubleClick += dgv_Archivos_CellContentDoubleClick;
            txt_directorio.Text = var.ObtenerValorVariable<String>("rutaArchivosXML");
        }

        void dgv_Archivos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                String xml = dgv_Archivos[e.ColumnIndex, e.RowIndex].Value.ToString();
                if (!xml.Equals(""))
                {
                    VisorXML visor = new VisorXML(xml);
                    visor.Show();
                }
            }
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            String directorioInicial = null;
            if (!txt_directorio.Text.Trim().Equals(""))
                directorioInicial = txt_directorio.Text.Trim();
            String directorio = Herramientas.Archivos.Dialogos.BuscarCarpeta(directorioInicial);
            if (directorio != null)
            {
                txt_directorio.Text = directorio;
                var.GuardarValorVariable("rutaArchivosXML", directorio);
                var.ActualizarArchivo();
            }
        }

        private void btn_cargarXML_Click(object sender, EventArgs e)
        {
            //Thread t = new Thread(ProcesoHilo);
            //t.Start();
            ProcesoHilo();
            btn_SubirAlServidor.Enabled = false;
            pb_avance.Value = 0;
        }

        private void ProcesoHilo()
        {
            dgv_Archivos.Rows.Clear();
            List<String> archivos = Herramientas.WPF.Utilidades.ObtenerRutasArchivoDeDirectorio(txt_directorio.Text.Trim(), new List<string>() { ".xml" }, true);
            txt_total.Text = archivos.Count.ToString();
            foreach (String archivo in archivos)
            {


                XML xml = new XML(archivo);
                String uuid = "";
                try
                {
                    uuid = xml.ObtenerValorDePropiedad_NODO_XML("tfd", "TimbreFiscalDigital", "UUID");
                }
                catch { }
                String rfcEmisor = xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Emisor", "rfc");
                String folio = xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Comprobante", "folio");
                String fecha = xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Comprobante", "fecha");
                String monto = xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Comprobante", "total");
                String rfcReceptor = xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Receptor", "rfc");
                //String estatusSAT = CFDI.ObtenerEstatusCFDI(rfcEmisor, rfcReceptor, Convert.ToDouble(monto), uuid);

                String estatusCfdi = "";

                if (VerificarCapturado(rfcEmisor, rfcReceptor, Convert.ToDouble(monto), uuid))
                {
                    estatusCfdi = "En el servidor";
                }
                else
                {
                    estatusCfdi = "Sin subir";
                }

                //lock (dgv_Archivos)
                //{
                dgv_Archivos.Rows.Add(archivo, xml.ContenidoTexto, uuid, folio, estatusCfdi, "", rfcEmisor, rfcReceptor, monto, fecha);
                //}
                dgv_Archivos.Rows[dgv_Archivos.Rows.Count - 1].Cells[4].Style.ForeColor = Color.White;
                if (!dgv_Archivos.Rows[dgv_Archivos.Rows.Count - 1].Cells[4].Value.ToString().Equals("En el servidor"))
                {
                    dgv_Archivos.Rows[dgv_Archivos.Rows.Count - 1].Cells[4].Style.BackColor = Color.Red;
                }
                else
                {
                    dgv_Archivos.Rows[dgv_Archivos.Rows.Count - 1].Cells[4].Style.BackColor = Color.Green;
                }
            }
        }
        private void ValidarEstatusSAT()
        {
            int contador = 1;
            for (int i = 0; i < dgv_Archivos.Rows.Count; i++)
            {
                DataGridViewCell rfcEmisor = dgv_Archivos.Rows[i].Cells[6];
                DataGridViewCell rfcReceptor = dgv_Archivos.Rows[i].Cells[7];
                DataGridViewCell monto = dgv_Archivos.Rows[i].Cells[8];
                DataGridViewCell UUID = dgv_Archivos.Rows[i].Cells[2];
                dgv_Archivos.Rows[i].Cells[5].Value = CFDI.ObtenerEstatusCFDI((String)rfcEmisor.Value, (String)rfcReceptor.Value, Convert.ToDouble((String)monto.Value), (String)UUID.Value);
                dgv_Archivos.Rows[i].Cells[5].Style.ForeColor = Color.White;
                if (!dgv_Archivos.Rows[i].Cells[5].Value.ToString().Equals("Vigente"))
                {
                    dgv_Archivos.Rows[i].Cells[5].Style.BackColor = Color.Red;
                }
                else
                {
                    dgv_Archivos.Rows[i].Cells[5].Style.BackColor = Color.Green;
                }
                pb_avance.Value = contador * 100 / dgv_Archivos.Rows.Count;
                contador++;
            }
            btn_SubirAlServidor.Enabled = true;
        }
        private Boolean VerificarCapturado(String rfcEmisor, String rfcReceptor, double importeTotal, String uuid)
        {
            String query = @"select uuid from empresas..FAC_XMLFACTURAS_PROVEEDORES
                              where cRFCEmisor = @cRFCEmisor and
                              CRFCReceptor = @CRFCReceptor and
                              cImporteTotal = @cImporteTotal and
                              UUID = @UUID";
            List<Object> parametros = new List<object>();
            parametros.Add(rfcEmisor);
            parametros.Add(rfcReceptor);
            parametros.Add(importeTotal);
            parametros.Add(uuid);

            DataTable dt = sql.EjecutarConsulta(query, parametros);

            if (dt.Rows.Count > 0)
                return true;
            else
                return false;

        }
        private void btn_SubirAlServidor_Click(object sender, EventArgs e)
        {
            pb_avance.Value = 0;
            Thread Subiendo = new Thread(SubirAServidor);
            Subiendo.Start();
        }

        private void SubirAServidor()
        {
            int contador = 1;
            for (int i = 0; i < dgv_Archivos.Rows.Count; i++)
            {
                if (dgv_Archivos.Rows[i].Cells[4].Value.ToString().Equals("En el servidor"))
                {
                    pb_avance.Value = contador * 100 / dgv_Archivos.Rows.Count;
                    contador++;
                    continue;
                }
                if (dgv_Archivos.Rows[i].Cells[5].Value.ToString().Equals("Vigente"))
                {
                    DataGridViewCell rfcEmisor = dgv_Archivos.Rows[i].Cells[6];
                    DataGridViewCell rfcReceptor = dgv_Archivos.Rows[i].Cells[7];
                    DataGridViewCell monto = dgv_Archivos.Rows[i].Cells[8];
                    DataGridViewCell UUID = dgv_Archivos.Rows[i].Cells[2];
                    DataGridViewCell FechaEmision = dgv_Archivos.Rows[i].Cells[9];
                    DataGridViewCell folioFactura = dgv_Archivos.Rows[i].Cells[3];
                    DataGridViewCell xml = dgv_Archivos.Rows[i].Cells[1];

                    String query = @"insert into empresas..FAC_XMLFACTURAS_PROVEEDORES 
                                (cRFCEmisor, CRFCReceptor, cImporteTotal, dFechaEmision, cFolioFacturaProveedor, UUID, sXMLContenido) 
                                values
                                (@cRFCEmisor, @CRFCReceptor, @cImporteTotal, @dFechaEmision, @cFolioFacturaProveedor, @UUID, @sXMLContenido)";

                    List<object> parametros = new List<object>();

                    parametros.Add((String)rfcEmisor.Value);
                    parametros.Add((String)rfcReceptor.Value);
                    parametros.Add(Convert.ToDouble((String)monto.Value));
                    parametros.Add(Convert.ToDateTime((String)FechaEmision.Value));
                    parametros.Add((String)folioFactura.Value);
                    parametros.Add((String)UUID.Value);
                    parametros.Add((String)xml.Value);
                    dgv_Archivos.Rows[i].Cells[4].Style.ForeColor = Color.White;
                    try
                    {
                        sql.EjecutarConsulta(query, parametros);
                        dgv_Archivos.Rows[i].Cells[4].Style.BackColor = Color.Green;
                        dgv_Archivos.Rows[i].Cells[4].Value = "En el servidor";

                    }
                    catch (Exception ex)
                    {
                        dgv_Archivos.Rows[i].Cells[4].Style.BackColor = Color.Red;
                        dgv_Archivos.Rows[i].Cells[4].Value = ex.Message;
                    }
                }
                else
                {
                    dgv_Archivos.Rows[i].Cells[4].Style.BackColor = Color.Red;
                    dgv_Archivos.Rows[i].Cells[4].Value = "La factura no se subió al servidor debido a que se encuentra con estatus: " + dgv_Archivos.Rows[i].Cells[5].Value.ToString();
                }

                //actualizando progress bar

                pb_avance.Value = contador * 100 / dgv_Archivos.Rows.Count;
                contador++;

            }
            Mensajes.Informacion("Ha concluido el proceso de subir Facturas CFDI al servidor.");
        }

        private void btn_validar_Click(object sender, EventArgs e)
        {
            Thread validar = new Thread(ValidarEstatusSAT);
            validar.Start();

        }

    }
}
