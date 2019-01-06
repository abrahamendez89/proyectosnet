using DPFP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using Checador.ChecadorRemoto;
using System.ServiceModel;
using System.Threading;
using Herramientas.Archivos;
using Herramientas.SQL;
using Herramientas.Mail;
using Herramientas.Conversiones;
using Herramientas.Net;


namespace Checador
{
    public partial class Form1 : Form, DPFP.Capture.EventHandler
    {
        Variable var;
        Variable varServidor;
        SQLServer sql;
        private String ccve_nomina;
        private String ccve_temporada;
        private String bdTrabajadores;
        private String ServidorBD;
        private String idChecador;
        private String idHorario;
        private int tamSegmento;

        private Bitmap encontradoSinImagen;
        private Bitmap noEncontrado;
        private Bitmap SinImagen;
        private Bitmap buscando;
        private Bitmap huellaIncorrecta;
        private Bitmap conectar;

        private int segundosBorrado = 10;
        String emails;
        Thread hiloQuitarImagen;
        Thread hiloActualizarHora;
        Thread hiloMensajes;
        Thread hiloCircular;

        Thread hiloConsultaMinuto;
        String WService;
        String Metodo;

        Boolean modoDebug = false;
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;


            //WebService ws = new WebService("http://www.ipswitch.com/netapps/geolocation/iplocate.asmx", "TestResponseTime");
            ////ws.AgregarParametroConValor("", "");
            //ws.Ejecutar(true);

            try
            {
                var = new Variable(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\ConfiguracionChecadorLocal.ini");
                varServidor = new Variable(@"dataServidor.ini");

                

                ServidorBD = varServidor.ObtenerValorVariable<String>("ServerBD");
                WService = varServidor.ObtenerValorVariable<String>("WebService");
                Metodo = varServidor.ObtenerValorVariable<String>("Webmetodo");

                ccve_nomina = var.ObtenerValorVariable<String>("ccve_nomina");
                ccve_temporada = var.ObtenerValorVariable<String>("ccve_temporada");
                bdTrabajadores = var.ObtenerValorVariable<String>("baseDatos");
                idChecador = var.ObtenerValorVariable<String>("idChecador");
                idHorario = var.ObtenerValorVariable<String>("idHorario");
                tamSegmento = var.ObtenerValorVariable<int>("tamSegmento");
                if (tamSegmento == 0)
                    tamSegmento = 50;
                emails = varServidor.ObtenerValorVariable<String>("emails");
                sql = new SQLServer(@"data source = " + ServidorBD + "; initial catalog = " + bdTrabajadores + "; user id = sa; password = 1@TCE123");

                var.GuardarValorVariable("ccve_nomina", ccve_nomina);
                var.GuardarValorVariable("ccve_temporada", ccve_temporada);
                var.GuardarValorVariable("baseDatos", bdTrabajadores);
                var.GuardarValorVariable("idChecador", idChecador);
                var.GuardarValorVariable("idHorario", idHorario);
                var.GuardarValorVariable("tamSegmento", tamSegmento.ToString());

                txt_nomina.Text = ccve_nomina;
                txt_temporada.Text = ccve_temporada;
                txt_bd.Text = bdTrabajadores;
                txt_id.Text = idChecador;


                encontradoSinImagen = new Bitmap(@"Imagenes\IdentificadoSinFoto.png");
                noEncontrado = new Bitmap(@"Imagenes\noIdentificado.png");
                SinImagen = new Bitmap(@"Imagenes\SinImagen.png");
                buscando = new Bitmap(@"Imagenes\buscando.png");
                huellaIncorrecta = new Bitmap(@"Imagenes\huellaIncorrecta.png");
                conectar = new Bitmap(@"Imagenes\conectar.png");

                pb_fotoEmpleado.Image = SinImagen;
                txt_empleado.Text = "";

                hiloQuitarImagen = new Thread(borrarImagen);
                hiloQuitarImagen.Start();

                this.FormClosed += Form1_FormClosed;
                this.VisibleChanged += Form1_VisibleChanged;

                hiloActualizarHora = new Thread(ActualizarHora);
                hiloActualizarHora.Start();


                CargarMensajes();

                hiloMensajes = new Thread(MostrarMensajes);
                hiloMensajes.Start();
                hiloCircular = new Thread(RotarMensaje);
                hiloCircular.Start();

                hiloConsultaMinuto = new Thread(ConsultasMinuto);
                hiloConsultaMinuto.Start();

                txt_fecha.Text = String.Format("{0:D}", DateTime.Now).ToUpper();

                Init();
                Start();

                ValidarHuella(null, true);

                
                this.TopMost = !modoDebug;
                if (modoDebug) FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;

                EmailFormatos.EnviarMailInformacion("Checador " + idChecador + " iniciado correctamente.","Checador", emails, null);

            }
            catch (Exception ex)
            {
                Thread t = new Thread(EnviarMail);
                String empleado = "Error al abrir la aplicación. - ";
                t.Start(empleado + "Error: " + ex.Message);
            }
        }
        private void ConsultasMinuto()
        {
            while (true)
            {
                Thread.Sleep(60000 * 5);
                try
                {
                    ValidarHuella(null, true);
                }
                catch
                {
                }
            }
        }
        Boolean cargandoMensajes = false;
        private void CargarMensajes()
        {
            try
            {
                indiceMensajes = 0;
                cargandoMensajes = true;
                String linea = "";
                mensajesAMostrar.Clear();
                try
                {
                    String query = @"select ccve_empl, cnombre+' '+CAPE_PATERNO+' '+CAPE_MATERNO as nombre,   convert(datetime,DFEC_NACIMIENTO)
                                  from " + bdTrabajadores + @"..ctl_trabajadores 
                                  where ccve_temporada = '" + ccve_temporada + @"' and ccve_nomina = '" + ccve_nomina + @"'
                                  and month(convert(datetime,DFEC_NACIMIENTO)) = month(@fecha) and day(convert(datetime,DFEC_NACIMIENTO)) = day(@fecha2) and CSTATUS = 'A'";
                                  //and CCVE_EMPL in (
                                  //select CCVE_EMPL from " + bdTrabajadores + @"..NOM_REAL 
                                  //where ccve_temporada = '" + ccve_temporada + @"' and ccve_nomina = '" + ccve_nomina + @"' 
                                  //and datediff(day,convert(datetime,DFECHA_INI),getdate()) <= 30
                                  //)";
                    DateTime dtime = DateTime.Now;//new DateTime(2014,1,13);
                    DataTable dtCumples = sql.EjecutarConsulta(query, new List<object> { dtime, dtime });

                    if (dtCumples.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtCumples.Rows)
                            mensajesAMostrar.Add("FELICIDADES " + dr["nombre"].ToString() + " POR TU CUMPLEAÑOS!!");
                    }
                }
                catch { }
                System.IO.StreamReader file = new System.IO.StreamReader(@"Mensajes.txt");
                while ((linea = file.ReadLine()) != null)
                {
                    if(!linea.Trim().Equals(""))
                        mensajesAMostrar.Add(linea.ToUpper());
                }
                file.Close();
                cargandoMensajes = false;
            }
            catch (Exception ex)
            {
                EnviarMail(ex);
            }
        }
        int indiceMensajes = 0;
        List<String> mensajesAMostrar = new List<string>();
        String mensajeActualAMostrar = "";
        private void MostrarMensajes()
        {
            while (true)
            {
                if (!cargandoMensajes)
                {
                    int cantidad = mensajesAMostrar.Count;
                    for (indiceMensajes = 0; indiceMensajes < cantidad; indiceMensajes++)
                    {
                        if (!cargandoMensajes)
                        {
                            mensajeActualAMostrar = mensajesAMostrar[indiceMensajes];
                            int totalLetras = txt_mensaje.Width / 6;
                            espaciado = "  ";
                            if (mensajeActualAMostrar.Length < totalLetras - 1)
                            {
                                int tamActual = mensajesAMostrar[indiceMensajes].Length;
                                for (int j = tamActual; j < totalLetras; j++)
                                {
                                    espaciado += " ";
                                }
                            }
                            texto = mensajeActualAMostrar;
                            tituloConEspaciado = texto + espaciado;
                            Thread.Sleep(30000);
                        }
                    }
                }
            }
        }
        String texto;
        String espaciado = "";
        String tituloConEspaciado;
        private void RotarMensaje()
        {
            int i = 0;
            while (true)
            {
                if (!cargandoMensajes)
                {
                    if (texto != null && !texto.Trim().Equals(""))
                    {
                        Thread.Sleep(120);
                        i++;
                        if (i >= tituloConEspaciado.Length)
                            i = 1;
                        int restante = i;

                        texto = tituloConEspaciado.Substring(i, tituloConEspaciado.Length - i);
                        texto += tituloConEspaciado.Substring(0, restante);
                        txt_mensaje.Text = texto;
                    }
                }
            }
        }
        void Form1_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                pnl_contenido.Location = new Point((Width - pnl_contenido.Width) / 2 - 10, (Height - pnl_contenido.Height) / 2 - 10);
                
                //for (int i = 0; i < mensajesAMostrar.Count; i++)
                //{
                    
                //}
            }
        }
        private DPFP.Capture.Capture Capturer;
        protected void Start()
        {
            String mensaje = "";
            if (null != Capturer)
            {
                try
                {
                    Capturer.StartCapture();
                    mensaje = "Using the fingerprint reader, scan your fingerprint.";
                }
                catch
                {
                    mensaje = "Can't initiate capture!";
                }
            }
        }

        protected void Stop()
        {
            String mensaje = "";
            if (null != Capturer)
            {
                try
                {
                    Capturer.StopCapture();
                }
                catch
                {
                    mensaje = "Can't terminate capture!";
                }
            }
        }
        protected virtual void Init()
        {
            String mensaje = "";
            try
            {
                Capturer = new DPFP.Capture.Capture();				// Create a capture operation.

                if (null != Capturer)
                    Capturer.EventHandler = this;					// Subscribe for capturing events.
                else
                    mensaje = "Can't initiate capture operation!";
            }
            catch
            {
                MessageBox.Show("Can't initiate capture operation!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                ////hiloQuitarImagen.Abort();
                ////hiloActualizarHora.Abort();
                ////hiloCircular.Abort();
                ////hiloMensajes.Abort();
                if (hiloQuitarImagen != null && hiloQuitarImagen.ThreadState != ThreadState.Stopped) hiloQuitarImagen.Abort();
                if (hiloActualizarHora != null && hiloActualizarHora.ThreadState != ThreadState.Stopped) hiloActualizarHora.Abort();
                if (hiloCircular != null && hiloCircular.ThreadState != ThreadState.Stopped) hiloCircular.Abort();
                if (hiloMensajes != null && hiloMensajes.ThreadState != ThreadState.Stopped) hiloMensajes.Abort();
                if (hiloConsultaMinuto != null && hiloConsultaMinuto.ThreadState != ThreadState.Stopped) hiloConsultaMinuto.Abort(); 
                EmailFormatos.EnviarMailInformacion("Checador " + idChecador + " cerrado correctamente.", "Checador", emails,null);
            }
            catch { }
        }
        int tiempoTranscurrido;

        private void ActualizarHora()
        {
            while (true)
            {

                if (p == null && !modoDebug)
                {
                    this.Activate();
                    BringToFront();
                }
                txt_hora.Text = DateTime.Now.ToString("h:mm:ss tt");
                Thread.Sleep(1000);
            }
        }
        private Boolean EvitarBorrado;
        private void borrarImagen()
        {
            while (true)
            {
                Thread.Sleep(1000);
                if (tiempoTranscurrido == segundosBorrado && !EvitarBorrado)
                {
                    pb_fotoEmpleado.Image = SinImagen;
                    txt_empleado.Text = "";
                    pb_huella.Image = null;
                }
                if (tiempoTranscurrido <= segundosBorrado)
                    tiempoTranscurrido++;


            }
        }
        Boolean modoPrueba;
        private void ValidarHuella(Byte[] bytes, Boolean SoloAbrirConexion)
        {
            String[] valores = null;
            try
            {
                if (!SoloAbrirConexion)
                {
                    tiempoTranscurrido = 0;
                    pb_fotoEmpleado.Image = buscando;
                    txt_empleado.Text = "BUSCANDO EMPLEADO ESPERE...";
                }
                //ChecadorSoapClient checador = new ChecadorSoapClient();
                //Converter.BitArrayTOBitmap(null);
                String tam = "50";
                if (tamSegmento != 0)
                    tam = tamSegmento.ToString();

                String huellaString = "";

                if(bytes != null)
                    huellaString = Herramientas.Conversiones.Converter.ByteArrayToString(bytes);
                String pruebasString = "false";
                if (modoPrueba) pruebasString = "true";

                WebService ws = new WebService(WService, Metodo);
                ws.AgregarParametroConValor("featureSet", huellaString);
                ws.AgregarParametroConValor("ccve_nomina", ccve_nomina);
                ws.AgregarParametroConValor("ccve_temporada", ccve_temporada);
                ws.AgregarParametroConValor("bdNomina", bdTrabajadores);
                ws.AgregarParametroConValor("idChecador", idChecador);
                ws.AgregarParametroConValor("tamSegmentos", tamSegmento.ToString());
                ws.AgregarParametroConValor("idHorario", "0");
                ws.AgregarParametroConValor("esUnaPrueba", pruebasString);
                ws.AgregarParametroConValor("ServerBD", ServidorBD);
                ws.Ejecutar(false);
                String[] arrayString = ws.ResultadoArreglo;




                //ArrayOfString arrayString = null; // checador.ChecarEmpleadoPorHuella(bytes, ccve_nomina, ccve_temporada, bdTrabajadores, idChecador, tam, idHorario, modoPrueba, ServidorBD);
                 
                tiempoTranscurrido = 0;
                if (bytes == null)
                    return;

                if (arrayString != null)
                {
                    valores = (String[])arrayString.ToArray();
                    if (valores[2] != null)
                    {
                        try
                        {
                            pb_fotoEmpleado.Image = Imagenes.BitArrayTOBitmap(Converter.StringToByteArray(valores[2]));
                        }
                        catch { pb_fotoEmpleado.Image = encontradoSinImagen; }
                    }
                    else
                    {
                        pb_fotoEmpleado.Image = encontradoSinImagen;
                    }
                    txt_empleado.Text = valores[0] + " - " + valores[1];


                }
                else
                {
                    pb_fotoEmpleado.Image = noEncontrado;
                    txt_empleado.Text = "EMPLEADO NO ENCONTRADO";
                }
            }
            catch (Exception ex)
            {
                Thread t = new Thread(EnviarMail);
                String empleado = "";
                if (valores != null && valores[0] != null && valores[1] != null)
                    empleado = "Empleado: " + valores[0] + " - " + valores[1] + " --- ";
                t.Start(empleado + "Error: " + ex.Message);
                pb_fotoEmpleado.Image = noEncontrado;
                txt_empleado.Text = "EMPLEADO NO ENCONTRADO";
            }
        }
        private void EnviarMail(Object excepcion)
        {
            try
            {
                Mail m = new Mail();
                m.Asunto = "Checador";
                m.EmailDestino = emails;
                m.ContenidoHTML = @"<h1>Se ha generado un error con el checador @id.</h1>

                <p><em>Detalles del error:</em></p>

                <blockquote>
                <p>@Error</p>
                </blockquote>

                <p>Favor de no responder a este correo.</p>".Replace("@id", idChecador).Replace("@Error", excepcion.ToString());

                m.EnviarCorreo(Mail.Prioridad.Alta);
            }
            catch { }
        }
        public void OnComplete(object Capture, string ReaderSerialNumber, Sample Sample)
        {
            try
            {
                chequeoDedo.Abort();
            }
            catch { }
            ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification);
        }

        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {

        }
        private void MensajeColocarDedoCorrectamente()
        {
            pb_fotoEmpleado.Image = null;
            txt_empleado.Text = "";
            Thread.Sleep(1000);
            pb_fotoEmpleado.Image = huellaIncorrecta;
            txt_empleado.Text = "¡¡ COLOQUE BIEN SU DEDO EN EL LECTOR !!";
        }
        Thread chequeoDedo;
        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {
            tiempoTranscurrido = 0;
            chequeoDedo = new Thread(MensajeColocarDedoCorrectamente);
            chequeoDedo.Start();
        }

        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {
            tiempoTranscurrido = 0;
            pb_fotoEmpleado.Image = SinImagen;
            txt_empleado.Text = "";
            EvitarBorrado = false;
            Start();
        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {
            tiempoTranscurrido = segundosBorrado * 2;
            pb_fotoEmpleado.Image = conectar;
            txt_empleado.Text = "CONECTA NUEVAMENTE EL LECTOR";
            EvitarBorrado = true;
        }

        public void OnSampleQuality(object Capture, string ReaderSerialNumber, DPFP.Capture.CaptureFeedback CaptureFeedback)
        {
        }
        protected void ExtractFeatures(DPFP.Sample Sample, DPFP.Processing.DataPurpose Purpose)
        {
            DPFP.Processing.FeatureExtraction Extractor = new DPFP.Processing.FeatureExtraction();	// Create a feature extractor
            DPFP.Capture.CaptureFeedback feedback = DPFP.Capture.CaptureFeedback.None;
            DPFP.FeatureSet features = new DPFP.FeatureSet();
            Extractor.CreateFeatureSet(Sample, Purpose, ref feedback, ref features);			// TODO: return features as a result?
            Thread t = new Thread(MostrarHuellaDigital);
            t.Start(Sample);
            if (feedback == DPFP.Capture.CaptureFeedback.Good)
                ValidarHuella(features.Bytes, false);
            else
                txt_empleado.Text = "Coloque bien el dedo";
        }
        protected Bitmap ConvertSampleToBitmap(DPFP.Sample Sample)
        {
            DPFP.Capture.SampleConversion Convertor = new DPFP.Capture.SampleConversion();	// Create a sample convertor.
            Bitmap bitmap = null;												            // TODO: the size doesn't matter
            Convertor.ConvertToPicture(Sample, ref bitmap);									// TODO: return bitmap as a result
            return bitmap;
        }

        private void MostrarHuellaDigital(Object obj)
        {
            Sample sam = (Sample)obj;
            DrawPicture(ConvertSampleToBitmap(sam));
        }

        private void DrawPicture(Bitmap bitmap)
        {
            pb_huella.Image = new Bitmap(bitmap, pb_huella.Size);
        }
        PedirContrasena p;
        private void pb_cerrar_MouseClick(object sender, MouseEventArgs e)
        {
            p = new PedirContrasena();
            p.ShowDialog();
            if (p.AccesoPermitido)
                Close();
        }

        private void pb_huella_DoubleClick(object sender, EventArgs e)
        {

        }

        private void pb_huella_Click(object sender, EventArgs e)
        {
            modoPrueba = !modoPrueba;
            lbl_modoPrueba.Visible = modoPrueba;


            modoDebug = !modoDebug;
            this.TopMost = modoDebug;
            if (modoDebug) FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            else FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

        }

        private void pb_logoEmpresa_Click(object sender, EventArgs e)
        {
            CargarMensajes();
        }
    }
}
