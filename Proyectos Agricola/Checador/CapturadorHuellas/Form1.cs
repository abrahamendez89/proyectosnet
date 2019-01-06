using DPFP;
using DPFP.Verification;
using Herramientas.Archivos;
using Herramientas.Forms;
using Herramientas.SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CapturadorHuellas
{
    public partial class Form1 : Form, DPFP.Capture.EventHandler
    {
        DBAcceso dbAcceso;
        Variable var;
        private DPFP.Capture.Capture Capturer;
        DPFP.Processing.Enrollment Enroller;
        String ccve_nomina;
        String ccve_temporada;
        String bdTrabajadores;
        String Server;
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Enroller = new DPFP.Processing.Enrollment();
            try
            {
                var = new Variable(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\ConfiguracionChecadorLocal.ini");
                Variable varServer = new Variable("Parametros.ini");

                Server = varServer.ObtenerValorVariable<String>("ServidorConexion");
                dbAcceso = new DBAcceso(@"data source = "+Server+"; initial catalog = imagenes; user id = sa; password = 1@TCE123");
                ccve_nomina = var.ObtenerValorVariable<String>("ccve_nomina");
                ccve_temporada = var.ObtenerValorVariable<String>("ccve_temporada");
                bdTrabajadores = var.ObtenerValorVariable<String>("baseDatos");

                txt_nomina.Text = ccve_nomina;
                txt_temporada.Text = ccve_temporada;
                txt_bd.Text = bdTrabajadores;

            }
            catch { }
            this.FormClosed += Form1_FormClosed;
            txt_claveBusqueda.Focus();
        }
        
        void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            var.GuardarValorVariable("ccve_nomina", txt_nomina.Text.Trim());
            var.GuardarValorVariable("ccve_temporada", txt_temporada.Text.Trim());
            var.GuardarValorVariable("baseDatos", txt_bd.Text.Trim());
        }
        protected virtual void Init()
        {
            try
            {
                Capturer = new DPFP.Capture.Capture();				// Create a capture operation.

                if (null != Capturer)
                    Capturer.EventHandler = this;					// Subscribe for capturing events.
                else
                    MostrarMensaje("Can't initiate capture operation!");
            }
            catch
            {
                MessageBox.Show("Can't initiate capture operation!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        protected void Start()
        {
            if (null != Capturer)
            {
                try
                {
                    Capturer.StartCapture();
                    MostrarMensaje("Lectura iniciada, coloque su dedo.");
                }
                catch
                {
                    MostrarMensaje("Can't initiate capture!");
                }
            }
        }
        #region EventHandler Members:

        public void OnComplete(object Capture, string ReaderSerialNumber, DPFP.Sample Sample)
        {
            MostrarMensaje("Se ha capturado la huella correctamente..");
           // MostrarMensaje("Scan the same fingerprint again.");
            Process(Sample);
            if(esProbar)
                ValidarHuella(Sample, DPFP.Processing.DataPurpose.Verification);
            else
                ValidarHuella(Sample, DPFP.Processing.DataPurpose.Enrollment);
        }

        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
            //MostrarMensaje("The finger was removed from the fingerprint reader.");
        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {
            //MostrarMensaje("The fingerprint reader was touched.");
        }

        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {
            //MostrarMensaje("The fingerprint reader was connected.");
        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {
            //MostrarMensaje("The fingerprint reader was disconnected.");
        }

        public void OnSampleQuality(object Capture, string ReaderSerialNumber, DPFP.Capture.CaptureFeedback CaptureFeedback)
        {
            if (CaptureFeedback == DPFP.Capture.CaptureFeedback.Good)
                MostrarMensaje("La calidad de la huella es buena.");
            else
                MostrarMensaje("La calidad de la huella es mala.");
        }
        #endregion
        protected void MostrarMensaje(string mensaje)
        {
            //lb_mensajes.Items.Add(mensaje);
            //lb_mensajes.SelectedIndex = lb_mensajes.Items.Count - 1;

            txt_mensaje.Text = mensaje;
        }
        protected Bitmap ConvertSampleToBitmap(DPFP.Sample Sample)
        {
            DPFP.Capture.SampleConversion Convertor = new DPFP.Capture.SampleConversion();	// Create a sample convertor.
            Bitmap bitmap = null;												            // TODO: the size doesn't matter
            Convertor.ConvertToPicture(Sample, ref bitmap);									// TODO: return bitmap as a result
            return bitmap;
        }
        protected virtual void Process(DPFP.Sample Sample)
        {
            // Draw fingerprint sample image.
            DrawPicture(ConvertSampleToBitmap(Sample));
            
        }
        FeatureSet patronEntrada;
        Template templateRegistrado;
        protected void ValidarHuella(DPFP.Sample Sample, DPFP.Processing.DataPurpose Purpose)
        {
            DPFP.Processing.FeatureExtraction Extractor = new DPFP.Processing.FeatureExtraction();	// Create a feature extractor
            DPFP.Capture.CaptureFeedback feedback = DPFP.Capture.CaptureFeedback.None;
            DPFP.FeatureSet features = new DPFP.FeatureSet();
            Extractor.CreateFeatureSet(Sample, Purpose, ref feedback, ref features);
            patronEntrada = features;
            if (feedback == DPFP.Capture.CaptureFeedback.Good)
            {
                if (Purpose == DPFP.Processing.DataPurpose.Enrollment)
                {
                     // new DPFP.FeatureSet(new MemoryStream(bytes));
                    //Stop();
                    try
                    {
                        Enroller.AddFeatures(features);
                        //Enroller.AddFeatures(features);
                        //Enroller.AddFeatures(features);
                        //Enroller.AddFeatures(features);
                    }
                    catch { MostrarMensaje("Falló la captura, intente nuevamente."); return; }

                    switch (Enroller.TemplateStatus)
                    {
                        case DPFP.Processing.Enrollment.Status.Ready:
                            MostrarMensaje("La captura ha concluido.");
                            templateRegistrado = Enroller.Template;
                            Stop();
                            btn_iniciarCaptura.Text = "Capturar";
                            btn_probar.Enabled = true;
                            btn_iniciarCaptura.Enabled = false;
                            break;

                        case DPFP.Processing.Enrollment.Status.Failed:
                            Enroller.Clear();
                            MostrarMensaje("La captura fallo, intente nuevamente.");
                            Stop();
                            Start();
                            break;
                    }

                    //templateRegistrado = Enroller.Template;
                    //Stop();
                    //MostrarMensaje("Captura finalizada");
                }
                else if (Purpose == DPFP.Processing.DataPurpose.Verification)
                {
                    MemoryStream ms = new MemoryStream(features.Bytes);
                    DPFP.Verification.Verification ver = new DPFP.Verification.Verification();
                    DPFP.Verification.Verification.Result res = new DPFP.Verification.Verification.Result();
                    //Template template;
                    try
                    {
                        //template = new Template(ms);
                        ver.Verify(patronEntrada, templateRegistrado, ref res);
                        if (res.Verified)
                        {
                            MostrarMensaje("Se detectó correctamente.");
                            btn_guardarHuella.Enabled = true;
                            btn_probar.Text = "Probar";
                            esProbar = false;
                            Stop();
                            btn_probar.Enabled = false;
                            btn_iniciarCaptura.Enabled = true;
                        }
                        else
                            MostrarMensaje("La huella no coincide.");
                    }
                    catch { MostrarMensaje("ERROR AL VERIFICAR!!");}
                    //esProbar = false;
                    //Stop();
                }
            }
        }
        
        private void DrawPicture(Bitmap bitmap)
        {
            pb_huella.Image = new Bitmap(bitmap, pb_huella.Size);	
        }
        protected void Stop()
        {
            if (null != Capturer)
            {
                try
                {
                    Capturer.StopCapture();
                }
                catch
                {
                    MostrarMensaje("No se puede terminar la captura!");
                }
            }
        }

        private void btn_iniciarCaptura_Click(object sender, EventArgs e)
        {
            if (btn_iniciarCaptura.Text.Equals("Capturar"))
            {
                Init();
                Start();
                if (Enroller != null)
                    Enroller.Clear();
                templateRegistrado = null;
                btn_iniciarCaptura.Text = "Cancelar captura";
                btn_guardarHuella.Enabled = false;
            }
            else
            {
                reset();
            }
        }
        Boolean esProbar = false;
        private void btn_probar_Click(object sender, EventArgs e)
        {
            if (btn_probar.Text.Equals("Probar"))
            {
                esProbar = true;
                Start();
                btn_probar.Text = "Detener prueba";
                btn_iniciarCaptura.Enabled = false;
            }
            else
            {
                btn_probar.Text = "Probar";
                esProbar = false;
                Stop();
                btn_iniciarCaptura.Enabled = true;
                btn_probar.Enabled = false;
            }
        }
        private void BuscarNombreConPanel()
        {
            DataTable dt = dbAcceso.EjecutarConsulta("select ccve_empl, cnombre+' '+CAPE_PATERNO+' '+CAPE_MATERNO as nombre from " + txt_bd.Text.Trim() + "..ctl_trabajadores where ccve_temporada = '" + txt_temporada.Text.Trim() + "' and CCVE_NOMINA = '" + txt_nomina.Text.Trim() + "' and (cnombre+' '+CAPE_PATERNO+' '+CAPE_MATERNO like '%" + txt_claveBusqueda.Text.Trim() + "%' or ccve_empl like '%" + txt_claveBusqueda.Text.Trim() + "%')");
           lb_empleados.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                lb_empleados.Items.Add(dr["ccve_empl"] + " | " + dr["nombre"]);
            }

            lb_empleados.Focus();
            if (lb_empleados.Items.Count > 0)
            {
                lb_empleados.SelectedIndex = 0;
            }
        }
        private void txt_claveBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F1)
            {
                pnl_busqueda.Visible = true;
                if (!txt_claveBusqueda.Text.Trim().Equals(""))
                    BuscarNombreConPanel();
            }
            else if (e.KeyData == Keys.Enter)
            {
                if (pnl_busqueda.Visible)
                {
                    BuscarNombreConPanel();
                }
                else
                {
                    DataTable dt = dbAcceso.EjecutarConsulta("select ccve_empl, cnombre+' '+CAPE_PATERNO+' '+CAPE_MATERNO as nombre from " + txt_bd.Text.Trim() + "..ctl_trabajadores where ccve_temporada = '" + txt_temporada.Text.Trim() + "' and CCVE_NOMINA = '" + txt_nomina.Text.Trim() + "' and (ccve_empl like '%" + txt_claveBusqueda.Text.Trim() + "%')");
                    lb_empleados.Items.Clear();
                    if (dt.Rows.Count > 0)
                    {
                        txt_nombreEmpleado.Text = dt.Rows[0]["nombre"].ToString();
                        txt_claveBusqueda.Text = dt.Rows[0]["ccve_empl"].ToString();
                        
                        reset();
                    }
                }
            }
            else if (e.KeyData == Keys.Escape)
            {
                pnl_busqueda.Visible = false;
                lb_empleados.Items.Clear();
            }
        }
        private void reset()
        {
            Stop();
            btn_iniciarCaptura.Text = "Capturar";
            btn_probar.Text = "Probar";
            btn_guardarHuella.Text = "Guardar";
            btn_iniciarCaptura.Enabled = true;
            btn_probar.Enabled = false;
            btn_guardarHuella.Enabled = false;
            lb_empleados.Items.Clear();
            pb_huella.Image = null;
            
            MostrarMensaje("");
        }
        private void lb_empleados_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                pnl_busqueda.Visible = false;
                lb_empleados.Items.Clear();
            }
            else if (e.KeyData == Keys.Enter)
            {
                if (lb_empleados.SelectedIndex != -1)
                {
                    pnl_busqueda.Visible = false;


                    String seleccionado = lb_empleados.SelectedItem.ToString();
                    String[] splited = seleccionado.Split('|');
                    txt_claveBusqueda.Text = splited[0].Trim();
                    txt_nombreEmpleado.Text = splited[1].Trim();
                    reset();
                    
                }
            }
            else if (e.KeyData == Keys.Back)
            {
                txt_claveBusqueda.Focus();
            }
        }

        private void btn_guardarHuella_Click(object sender, EventArgs e)
        {
            try
            {
                List<Object> parametros = new List<object>();

                DataTable dt = dbAcceso.EjecutarConsulta("select * from imagenes..ctl_trab_imagenes where ccve_temporada = '" + txt_temporada.Text.Trim() + "' and CCVE_NOMINA = '" + txt_nomina.Text.Trim() + "' and ccve_empl = '" + txt_claveBusqueda.Text.Trim() + "'");
               
                if (dt.Rows.Count == 0)
                {
                    int numeroInicio = Convert.ToInt32(txt_temporada.Text.Trim().Substring(0, 2));
                    String temporadaAnterior = (numeroInicio - 1) + "-" + numeroInicio;
                    //importando los datos
                    String queryInsert = "insert imagenes..ctl_trab_Imagenes(ccve_temporada, ccve_nomina, ccve_empl) values ('" + txt_temporada.Text.Trim() + "', '" + txt_nomina.Text.Trim() + "', '" + txt_claveBusqueda.Text.Trim() + "')";
                    dbAcceso.EjecutarConsulta(queryInsert);
                    //actualizando su foto
                    String queryUpdateFoto = @"update IMAGENES..CTL_TRAB_IMAGENES
                                              set CIMAGEN = (select CIMAGEN from imagenes..ctl_trab_Imagenes where ccve_temporada = '"+temporadaAnterior+@"' and CCVE_NOMINA = '" + txt_nomina.Text.Trim() + @"' and CCVE_EMPL = '" + txt_claveBusqueda.Text.Trim() + @"' and CIMAGEN is not null)
                                              where CCVE_EMPL = '" + txt_claveBusqueda.Text.Trim() + "'";
                    dbAcceso.EjecutarConsulta(queryUpdateFoto);
                }

                String query = "update imagenes..ctl_trab_imagenes set CHUELLADIGITAL = @CHUELLADIGITAL where ccve_temporada = '" + txt_temporada.Text.Trim() + "' and CCVE_NOMINA = '" + txt_nomina.Text.Trim() + "' and ccve_empl = '" + txt_claveBusqueda.Text.Trim() + "'";

                parametros.Add(templateRegistrado.Bytes);
                dbAcceso.EjecutarConsulta(query, parametros);
                Mensajes.Informacion("La huella se guardó con éxito.");
                btn_guardarHuella.Enabled = false;
                btn_probar.Enabled = false;
                btn_iniciarCaptura.Enabled = false;
                templateRegistrado = null;
                pb_huella.Image = null;
                txt_mensaje.Text = "";
                Enroller.Clear();
                txt_nombreEmpleado.Text = "";
                txt_claveBusqueda.Text = "";
                Stop();
            }
            catch (Exception ex)
            {
                Mensajes.Error(ex.Message);
            }
        }
    }
}
