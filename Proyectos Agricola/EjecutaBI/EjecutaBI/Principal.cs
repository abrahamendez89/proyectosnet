using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace EjecutaBI
{
    public partial class Principal : Form
    {
        Variable var_centralizado;
        Variable var_personalizado;
        Mail m = new Mail();
        String emails = "";
        String SQLSERVER_BD = "";
        String SQLSERVER_Servidor = "";
        String SQLSERVER_Usuario = "";
        String SQLSERVER_Contra = "";

        String FIREBIRD_RUTABD = "";
        String FIREBIRD_Servidor = "";
        String FIREBIRD_Usuario = "";
        String FIREBIRD_Contra = "";


        ProcesoArchivo procesoActualArchivo;

        List<ProcesoArchivo> procesosArchivos = new List<ProcesoArchivo>();

        //ISQLManager sqlManager;
        Thread Hilo_MonitoreoHorario;
        Thread Hilo_ActualizacionPantalla;
        Thread Hilo_ActualizaSystemTray;

        public Principal()
        {
            InitializeComponent();
            var_centralizado = new Variable("program.config");
            var_personalizado = new Variable(Environment.GetEnvironmentVariable("USERPROFILE") + @"\documents\configuracion_local_bi.temp");
            CargarVariables();
            ConfigurarHoras();
            CargarProcesos();
            Hilo_MonitoreoHorario = new Thread(MonitoreoTiempo);
            Hilo_MonitoreoHorario.Start();

            Hilo_ActualizacionPantalla = new Thread(ActualizacionPantalla);
            Hilo_ActualizacionPantalla.Start();

            lbl_mensaje.Text = "";
            CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += Principal_FormClosing;

            timer1.Interval = 10;
            timer1.Tick += timer1_Tick;
            timer1.Start();

            //foreach(String nombre in cmb_proceso_procesosRegistrados.Items)
            //    itemEnEjecucion.DropDownItems.Add(nombre);

            Hilo_ActualizaSystemTray = new Thread(ActualizaSystemTrayProcesos);
            Hilo_ActualizaSystemTray.Start();





        }
        private void ActualizaSystemTrayProcesos()
        {
            while (true)
            {
                for(int i = 0; i < itemEnEjecucion.DropDownItems.Count; i++)
                {
                    ProcesoArchivo proc = procesosArchivos[i];
                    if (proc.EstaEjecutandose)
                        itemEnEjecucion.DropDownItems[i].Text = proc.NombreProceso + ": " + proc.PorcentajeCompletado+"%";
                    else
                        itemEnEjecucion.DropDownItems[i].Text = proc.NombreProceso;
                }
                Thread.Sleep(2000);
            }
        }
        void timer1_Tick(object sender, EventArgs e)
        {
            if (AbrirEnSystemTray)
                MinimizarASystemTray();
            timer1.Stop();
        }
        private String ObtenerNombreArchivoLog()
        {
            return "LOG_"+Environment.MachineName+"_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
        }
        Boolean AbrirEnSystemTray = false;
        private void CargarVariables()
        {
            AbrirEnSystemTray = ConvierteStringABool(var_personalizado.ObtenerValorVariable<String>("ABRIR_ENSYSTEMTRAY"));
            SQLSERVER_BD = var_centralizado.ObtenerValorVariable<String>("SQLSERVER_BASEDATOS");
            SQLSERVER_Servidor = var_centralizado.ObtenerValorVariable<String>("SQLSERVER_SERVIDOR");
            SQLSERVER_Usuario = var_centralizado.ObtenerValorVariable<String>("SQLSERVER_USUARIO");
            SQLSERVER_Contra = var_centralizado.ObtenerValorVariable<String>("SQLSERVER_CONTRA");
            txt_proceso_correoNotificaciones.Text = var_personalizado.ObtenerValorVariable<String>("EMAILS_USUARIO");
            chb_proceso_EnviarNotificaciones.Checked = ConvierteStringABool(var_personalizado.ObtenerValorVariable<String>("ENVIAR_EMAILS"));
            if (chb_proceso_EnviarNotificaciones.Checked)
                emails = var_personalizado.ObtenerValorVariable<String>("EMAILS_USUARIO") + ";" + var_centralizado.ObtenerValorVariable<String>("EMAILS_SOPORTE");
            else
                emails = var_centralizado.ObtenerValorVariable<String>("EMAILS_SOPORTE");

            FIREBIRD_RUTABD = var_centralizado.ObtenerValorVariable<String>("FIREBIRD_RUTA_BD");
            FIREBIRD_Servidor = var_centralizado.ObtenerValorVariable<String>("FIREBIRD_SERVIDOR");
            FIREBIRD_Usuario = var_centralizado.ObtenerValorVariable<String>("FIREBIRD_USUARIO");
            FIREBIRD_Contra = var_centralizado.ObtenerValorVariable<String>("FIREBIRD_CONTRA");
        }
        private void MonitoreoTiempo()
        {
            while (true)
            {
                Thread.Sleep(5000);
                
                if (chb_detenerMonitoreo.Checked) continue;
                foreach (ProcesoArchivo proc in procesosArchivos)
                {
                    if (!proc.EstaEjecutandose && ConvierteStringABool(proc.EstaAgendado))
                    {
                        if (!proc.HoraEjecucion.Trim().Equals(""))
                        {
                            String horaEjec = proc.HoraEjecucion.Trim().Replace(" ", "");
                            String horaActual = DateTime.Now.ToString("HH:mm");
                            if (horaEjec.Equals(horaActual))
                            {
                                proc.HiloProceso = new Thread(EjecutarContenido);
                                proc.HiloProceso.Start(proc);
                                proc.EstaEjecutandose = true;
                            }
                        }
                    }
                }
            }
        }
        private void ConfigurarHoras()
        {
            for (int i = 0; i < 24; i++)
                cmb_proceso_hora.Items.Add(i.ToString("00"));
            for (int i = 0; i < 60; i++)
                cmb_proceso_minutos.Items.Add(i.ToString("00"));
        }
        private void CargarProcesos()
        {
            int numeroProcesos = var_personalizado.ObtenerValorVariable<int>("TOTAL_PROCESOS");

            for (int i = 0; i < numeroProcesos; i++)
            {
                ProcesoArchivo proc = new ProcesoArchivo();
                proc.RutaArchivo = var_personalizado.ObtenerValorVariable<String>("PROCESOS_" + (i + 1) + "_RUTA_ARCHIVO");
                if (!proc.RutaArchivo.Trim().Equals(""))
                    proc.NombreArchivo = Path.GetFileName(proc.RutaArchivo);
                proc.HoraEjecucion = var_personalizado.ObtenerValorVariable<String>("PROCESOS_" + (i + 1) + "_HORA_EJECUCION");
                proc.TipoServidor = var_personalizado.ObtenerValorVariable<String>("PROCESOS_" + (i + 1) + "_TIPO_SERVIDOR");
                proc.NombreProceso = var_personalizado.ObtenerValorVariable<String>("PROCESOS_" + (i + 1) + "_NOMBRE_PROCESO");
                proc.EstaAgendado = var_personalizado.ObtenerValorVariable<String>("PROCESOS_" + (i + 1) + "_ESTA_AGENDADO");
                procesosArchivos.Add(proc);
            }
            CargarProcesosEnCombo();
        }
        private void GuardarVariables()
        {
            try
            {
                var_centralizado.GuardarValorVariable("SQLSERVER_SERVIDOR", var_centralizado.ObtenerValorVariable<String>("SQLSERVER_SERVIDOR"));
                var_centralizado.GuardarValorVariable("SQLSERVER_BASEDATOS", var_centralizado.ObtenerValorVariable<String>("SQLSERVER_BASEDATOS"));
                var_centralizado.GuardarValorVariable("SQLSERVER_USUARIO", var_centralizado.ObtenerValorVariable<String>("SQLSERVER_USUARIO"));
                var_centralizado.GuardarValorVariable("SQLSERVER_CONTRA", var_centralizado.ObtenerValorVariable<String>("SQLSERVER_CONTRA"));
                var_centralizado.GuardarValorVariable("FIREBIRD_RUTA_BD", var_centralizado.ObtenerValorVariable<String>("FIREBIRD_RUTA_BD"));
                var_centralizado.GuardarValorVariable("FIREBIRD_SERVIDOR", var_centralizado.ObtenerValorVariable<String>("FIREBIRD_SERVIDOR"));
                var_centralizado.GuardarValorVariable("FIREBIRD_USUARIO", var_centralizado.ObtenerValorVariable<String>("FIREBIRD_USUARIO"));
                var_centralizado.GuardarValorVariable("FIREBIRD_CONTRA", var_centralizado.ObtenerValorVariable<String>("FIREBIRD_CONTRA"));

                var_personalizado.GuardarValorVariable("EMAILS_USUARIO", var_centralizado.ObtenerValorVariable<String>("EMAILS_USUARIO"));
                var_centralizado.GuardarValorVariable("EMAILS_SOPORTE", var_centralizado.ObtenerValorVariable<String>("EMAILS_SOPORTE"));
                var_personalizado.GuardarValorVariable("ABRIR_ENSYSTEMTRAY", ConvierteBoolAString(AbrirEnSystemTray));
            }
            catch (Exception ex)
            {
                String correo = @"<h2>Resultado</h2>

                                <p>La ejecución de '" + nombreArchivo + @"' se interrumpio por un error antes de iniciar.</p>
                                
                                <h2>Detalles del error</h2>

                                <p>" + ex.Message + @".</p>

                                <h2>Otros datos</h2>

                                <ul>
	                                <li>Fecha del evento: " + DateTime.Now.ToString("yyy-MM-dd HH:mm:ss") + @"</li>
                                </ul>";
                m.EnviarCorreo(emails, "Ejecución de " + nombreArchivo, "Error en el proceso de ejecución de " + nombreArchivo + ".", correo, null, null);
                MessageBox.Show(ex.Message);
            }
        }
        private String EliminaComentarioSimple(String query)
        {

            if (query.Contains("--"))
            {
                String ConsultaSinComentario = "";

                String consulta = query;
                Boolean encontroComentario = false;
                for (int j = 0; j < consulta.Length; j++)
                {
                    if (consulta[j] == '-' && consulta[j + 1] == '-')
                    {
                        j += 2;
                        encontroComentario = true;
                    }
                    if (consulta[j] == '\n')
                    {
                        //j += 1;
                        encontroComentario = false;
                    }

                    if (!encontroComentario)
                        ConsultaSinComentario += consulta[j];

                }
                return ConsultaSinComentario;
            }
            return query;
        }

        private void EliminaComentariosMultiLinea(String[] comandosArreglo)
        {
            for (int i = 0; i < comandosArreglo.Length; i++)
            {
                if (comandosArreglo[i].Contains("/*"))
                {
                    String ConsultaSinComentario = "";

                    String consulta = comandosArreglo[i];
                    Boolean encontroComentario = false;
                    for (int j = 0; j < consulta.Length; j++)
                    {
                        if (consulta[j] == '/' && consulta[j + 1] == '*')
                        {
                            encontroComentario = true;
                        }
                        if (consulta[j] == '*' && consulta[j + 1] == '/')
                        {
                            j += 2;
                            encontroComentario = false;
                        }

                        if (!encontroComentario)
                            ConsultaSinComentario += consulta[j];

                    }

                    comandosArreglo[i] = ConsultaSinComentario;
                }
            }
        }
        private String EjecutaShell(String linea)
        {
            String mensajeError = "";
            try
            {
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Verb = "runas";
                startInfo.Arguments = "/c " + linea;
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardError = true;
                startInfo.UseShellExecute = false;


                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit();

                mensajeError = process.StandardError.ReadToEnd();

                if (!mensajeError.Trim().Equals(""))
                    throw new Exception(mensajeError);

                return process.StandardOutput.ReadToEnd();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " CMD: " + mensajeError);
            }

            //MessageBox.Show(process.StandardError.ReadLine());
            //MessageBox.Show(process.StandardOutput.ReadLine());

        }
        private Boolean HayEjecuciones()
        {
            foreach (ProcesoArchivo proc in procesosArchivos)
            {
                if (proc.EstaEjecutandose)
                    return true;
            }
            return false;
        }
        void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {

            MinimizarASystemTray();
            e.Cancel = true;

            //Boolean hayEjecuciones = HayEjecuciones();
            //if (hayEjecuciones)
            //{
            //    //MessageBox.Show("No es posible cerrar la aplicación debido hay que hay procesos ejecutandose.");
            //    MinimizarASystemTray();
            //    e.Cancel = true;
            //    return;
            //}


            //try
            //{
            //    System.Environment.Exit(0);
            //}
            //catch { }

        }
        Boolean evitarCerrar = false;
        String nombreArchivo = "";
        private void btn_buscarArchivo_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Archivo SQL (*.sql)|*.SQL";
            dialog.InitialDirectory = @"%USERPROFILE%\Desktop";
            dialog.Title = "Seleccione el archivo SQL de BI.";
            if (dialog.ShowDialog() == DialogResult.OK)
            {

                txt_proceso_archivo.Text = dialog.FileName;
                //CargarArchivo(dialog.FileName);

                //var_personalizado.GuardarValorVariable("RUTAARCHIVO", dialog.FileName);
            }
        }
        //String contenido = "";
        //String[] contenidoEjecucion;
        //Mail m = new Mail();
        //int pasosTotales = 0;
        private void CargarArchivo(String archivo, ProcesoArchivo actual)
        {
            //nombreArchivo = Path.GetFileName(archivo);
            String line = "";
            String contenido = "";
            System.IO.StreamReader file = new System.IO.StreamReader(archivo);
            while ((line = file.ReadLine()) != null)
            {
                if(!line.StartsWith("--PASO "))
                    contenido += line + "\n";
            }

            file.Close();

            contenido = contenido.Replace("\nGo\n", "\nGO\n").Replace("\ngo\n", "\nGO\n").Replace("\ngO\n", "\nGO\n");

            

            actual.ContenidoEjecucion = contenido.Split(new string[] { "\nGo\n" }, StringSplitOptions.None);
            if (actual.ContenidoEjecucion.Length == 1)
                actual.ContenidoEjecucion = contenido.Split(new string[] { "\nGO\n" }, StringSplitOptions.None);
            if (actual.ContenidoEjecucion.Length == 1)
                actual.ContenidoEjecucion = contenido.Split(new string[] { "\ngo\n" }, StringSplitOptions.None);
            if (actual.ContenidoEjecucion.Length == 1)
                actual.ContenidoEjecucion = contenido.Split(new string[] { "\ngO\n" }, StringSplitOptions.None);


            //////String archivoModificado = "";
            //////int total = actual.ContenidoEjecucion.Length;
            //////if (contenido.Trim().EndsWith("GO"))
            //////    total -= 1;
            
            //////for (int i = 0; i < total; i++)
            //////{
            //////    archivoModificado += "--PASO "+(i+1)+":\n"+actual.ContenidoEjecucion[i] + "\nGO\n";
            //////}
            //////archivoModificado = archivoModificado.Trim().Substring(0, archivoModificado.Trim().Length-4);
            //////archivoModificado = archivoModificado.Replace("\n", Environment.NewLine);

            //////StreamWriter writer = new StreamWriter(archivo, false, Encoding.Default);
            //////writer.Write(archivoModificado);
                   


            actual.PasosTotales = actual.ContenidoEjecucion.Length - 1;
        }
        Thread t;
        private void btn_ejecutarProceso_Click(object sender, EventArgs e)
        {

            if (txt_proceso_archivo.Text.Trim().Equals(""))
            {
                MessageBox.Show("Se debe seleccionar un archivo SQL primeramente.");
                return;
            }
            if (evitarCerrar)
            {
                MessageBox.Show("Esta corriendo el proceso actualmente.");
                return;
            }
            lbl_mensaje.Visible = true;
            pb_progreso.Visible = true;
            pb_progreso.Value = 0;
            t = new Thread(EjecutarContenido);
            t.Start();
            btn_cancelar.Enabled = true;
        }




        //int valorPro;
        //String consultaSinComentarioSimple = "";
        //int pasoActual = 0;
        //String fechaInicio = "";
        private void ActualizarPAnt()
        {
            try
            {
                Invoke((MethodInvoker)delegate
                {

                    if (procesoActualArchivo != null && (procesoActualArchivo.EstaEjecutandose && procesoActualArchivo.FechaError == DateTime.MinValue && procesoActualArchivo.FechaCancelacion == DateTime.MinValue))
                    {
                        lb_ejecucion.Items.Clear();
                        pb_progreso.Visible = true;
                        lbl_mensaje.Visible = true;
                        btn_cancelar.Enabled = true;
                        lb_ejecucion.Items.AddRange(procesoActualArchivo.LOG.ToArray());
                        pb_progreso.Value = procesoActualArchivo.PorcentajeCompletado;
                        lbl_mensaje.Text = "Ejecutando paso " + procesoActualArchivo.PasoActual + " de " + procesoActualArchivo.PasosTotales + "    (" + procesoActualArchivo.PorcentajeCompletado + "%)...";

                        lb_ejecucion.SelectedIndex = lb_ejecucion.Items.Count - 1;
                    }
                    else
                    {
                        lb_ejecucion.Items.Clear();
                        pb_progreso.Visible = false;
                        lbl_mensaje.Visible = false;
                        btn_cancelar.Enabled = false;
                    }
                });
            }
            catch { }
        }
        private void ActualizacionPantalla()
        {
            while (true)
            {
                if (!chb_detenerMonitoreo.Checked)
                {
                    ActualizarPAnt();
                }
                Thread.Sleep(5000);
            }
        }
        private void CargarConexion(ProcesoArchivo proc)
        {
            try
            {


                if (proc.TipoServidor == null || proc.TipoServidor.Trim().Equals("") || proc.TipoServidor.Trim().ToUpper().Equals("SQLSERVER"))
                {
                    String cadenaConexion = "data source = @servidor; initial catalog = @baseDatos; user id = @usuario; password = @contra";
                    String cadenaConvertida = cadenaConexion.Replace("@servidor", SQLSERVER_Servidor).Replace("@baseDatos", SQLSERVER_BD).Replace("@usuario", SQLSERVER_Usuario).Replace("@contra", SQLSERVER_Contra);

                    proc.SqlManager = new SQL(cadenaConvertida);
                }
                else if (proc.TipoServidor.Trim().ToUpper().Equals("FIREBIRD"))
                {
                    string cadenaConexion = @"User=@usuario; Password=@contra; Database=@rutaBaseDatosFB; DataSource=@servidorFB;
                                            Port=3050; Dialect=3; Charset=UTF8; Pooling=true; ServerType=0;";

                    String cadenaConvertida = cadenaConexion.Replace("@rutaBaseDatosFB", FIREBIRD_RUTABD).Replace("@servidorFB", FIREBIRD_Servidor).Replace("@usuario", FIREBIRD_Usuario).Replace("@contra", FIREBIRD_Contra); ;
                    proc.SqlManager = new Firebird(cadenaConvertida);
                }


            }
            catch (Exception ex)
            {
                String correo = @"<h2>Resultado</h2>

                                <p>La ejecución de '" + nombreArchivo + @"' se interrumpio por un error antes de iniciar.</p>
                                
                                <h2>Detalles del error</h2>

                                <p>" + ex.Message + @".</p>

                                <h2>Otros datos</h2>

                                <ul>
	                                <li>Fecha del evento: " + DateTime.Now.ToString("yyy-MM-dd HH:mm:ss") + @"</li>
                                </ul>";
                m.EnviarCorreo(emails, "Ejecución de " + nombreArchivo, "Error en el proceso de ejecución de '" + nombreArchivo + "'.", correo, null, null);
                MessageBox.Show(ex.Message);
            }
        }

        private void EjecutarContenido(Object procesoArchivo)
        {

            ProcesoArchivo procesoArch = (ProcesoArchivo)procesoArchivo;
            procesoArch.LOG = new List<string>();
            procesoArch.ListBoxControl = new ListBox();
            //procesoArch.Resultados = new List<string>();
            CargarConexion(procesoArch);
            String ejecucionT = "";
            DateTime InicioPaso = DateTime.Now;
            procesoArch.EstaEjecutandose = true;

            try
            {
                CargarArchivo(procesoArch.RutaArchivo, procesoArch);
                EliminaComentariosMultiLinea(procesoArch.ContenidoEjecucion);
                procesoArch.Resultados = new string[procesoArch.ContenidoEjecucion.Length];
                //btn_cancelar.Enabled = true;
                //evitarCerrar = true;

                nombreArchivo = procesoArch.NombreProceso;
                procesoArch.FechaInicio = DateTime.Now;
                String fechaInicio = procesoArch.FechaInicio.ToString("yyy-MM-dd HH:mm:ss");


                lb_ejecucion.Items.Clear();
                String correo = @"<h2>Notificación</h2>

                                <p>La ejecución de '" + nombreArchivo + @"' ha iniciado correctamente por el equipo '"+Environment.MachineName+@"' con sesión de Windows '"+Environment.UserName+@"'.</p>

                                <h2>Otros datos</h2>

                                <ul>
	                                <li>Fecha inicio: " + fechaInicio + @"</li>
                                </ul>";

                m.EnviarCorreo(emails, "Ejecución de " + nombreArchivo, "Inició el proceso de '" + nombreArchivo + "'.", correo, null, null);
                procesoArch.SqlManager.AbrirConexion();

                procesoArch.AgregarLog("------ Se inició el proceso a las " + fechaInicio + " ------");
                procesoArch.PasoActual = 0;
                //sqlManager.IniciarTransaccion();
                foreach (String ejecucion in procesoArch.ContenidoEjecucion)
                {
                    procesoArch.PasoActual++;
                    if (!ejecucion.Trim().Equals(""))
                    {

                        ejecucionT = ejecucion;
                        //lbl_mensaje.Text = "Ejecutando paso " + procesoArch.PasoActual + " de " + pasosTotales + "...";


                        String[] comentario = ejecucion.Split('\n');

                        String mensajeLb = "";
                        String consultaFin = "";
                        foreach (String s in comentario)
                            if (s.Trim().StartsWith("--"))
                            {
                                mensajeLb = s.Trim();
                                break;
                            }
                        foreach (String s in comentario)
                            if (!s.Trim().StartsWith("--"))
                            {
                                consultaFin += s + " ";
                            }

                        //lb_ejecucion.Items.Add(DateTime.Now.ToString("yyy-MM-dd HH:mm:ss") + ": [Paso " + procesoArch.PasoActual + "]: " + mensajeLb);
                        String consultaSinComentarioSimple = EliminaComentarioSimple(ejecucion);
                        Boolean AgregoLog = false;
                        if (consultaSinComentarioSimple.Trim().StartsWith("##"))
                        {
                            if (mensajeLb.Trim().Equals(""))
                                mensajeLb = "  Shell sin comentario...";

                            procesoArch.AgregarLog(DateTime.Now.ToString("yyy-MM-dd HH:mm:ss") + ": [Paso " + procesoArch.PasoActual + "]: " + mensajeLb);
                            AgregoLog = true;
                            consultaSinComentarioSimple = consultaSinComentarioSimple.Replace("\n", "");
                            String shell = consultaSinComentarioSimple.Substring(2, consultaSinComentarioSimple.Length - 2).Trim();
                            InicioPaso = DateTime.Now;
                            String resultado = EjecutaShell(shell);
                            DateTime FinPaso = DateTime.Now;
                            TimeSpan diferencia = FinPaso - InicioPaso;
                            String duracion2 = diferencia.Hours.ToString("00") + ":" + diferencia.Minutes.ToString("00");
                            procesoArch.Resultados[procesoArch.PasoActual - 1] = GeneraResultado(resultado, InicioPaso, FinPaso);
                            procesoArch.AgregarALogEnPosicion(procesoArch.LOG.Count - 1, " | Duración: " + duracion2);
                        }
                        else
                        {
                            if (mensajeLb.Trim().Equals(""))
                                mensajeLb = "  Consulta sin comentario...";

                            procesoArch.AgregarLog(DateTime.Now.ToString("yyy-MM-dd HH:mm:ss") + ": [Paso " + procesoArch.PasoActual + "]: " + mensajeLb);
                            AgregoLog = true;
                            String consultaPre = ejecucion.Replace("\n", " ");
                            try
                            {
                                System.GC.Collect();
                                //String consultaSinComentarioSimple = EliminaComentarioSimple(ejecucion);
                                if (!consultaSinComentarioSimple.Replace("\n", "").Trim().Equals(""))
                                    if (!consultaSinComentarioSimple.Replace("\n", "").Trim().EndsWith("*/"))
                                    {
                                        InicioPaso = DateTime.Now;
                                        procesoArch.SqlManager.EjecutarConsulta(consultaSinComentarioSimple);
                                        DateTime FinPaso = DateTime.Now;

                                        TimeSpan diferencia = FinPaso - InicioPaso;
                                        String duracion2 = diferencia.Hours.ToString("00") + ":" + diferencia.Minutes.ToString("00");

                                        procesoArch.Resultados[procesoArch.PasoActual - 1] = GeneraResultado("Exitoso", InicioPaso, FinPaso);
                                    }
                            }
                            catch (Exception ex2)
                            {
                                if (ex2.Message.Contains("not found"))
                                {
                                    DateTime FinPaso = DateTime.Now;
                                    procesoArch.Resultados[procesoArch.PasoActual - 1] = GeneraResultado("ERROR MANEJABLE: "+ex2.Message, InicioPaso, FinPaso);
                                }
                                else
                                {
                                    throw new Exception(ex2.Message);
                                }
                            }
                            procesoArch.PorcentajeCompletado = Convert.ToInt32(Convert.ToDouble(procesoArch.PasoActual) / Convert.ToDouble(procesoArch.PasosTotales) * 100.0); ;

                        }
                        if (!AgregoLog)
                            procesoArch.AgregarLog(DateTime.Now.ToString("yyy-MM-dd HH:mm:ss") + ": [Paso " + procesoArch.PasoActual + "]: El comando no es ejecutable por que es un comentario.");

                    }
                    else
                    {
                        procesoArch.AgregarLog(DateTime.Now.ToString("yyy-MM-dd HH:mm:ss") + ": [Paso " + procesoArch.PasoActual + "]: No hay comando para ejecutar.");
                        procesoArch.Resultados[procesoArch.PasoActual - 1] = "";
                    }
                }
                //sqlManager.TerminarTransaccion();
                procesoArch.SqlManager.CerrarConexion();
                btn_cancelar.Enabled = false;
                procesoArch.EstaEjecutandose = false;
                DateTime FechaTermino = DateTime.Now;
                String fechaFin = FechaTermino.ToString("yyy-MM-dd HH:mm:ss");
                procesoArch.AgregarLog("------ Concluyó el proceso a las " + fechaFin + " ------");
                //MessageBox.Show("Se concluyó la ejecución del proceso de " + nombreArchivo + ".");

                String correo2 = @"<h2>Resultado</h2>

                                <p>La ejecución de '" + nombreArchivo + @"' se realizó correctamente.</p>

                                <h2>Otros datos</h2>

                                <ul>
	                                <li>Fecha inicio: " + fechaInicio + @"</li>
	                                <li>Fecha fin:    " + fechaFin + @"</li>
                                </ul>";


                TimeSpan diferenciaTotal = FechaTermino - InicioPaso;
                String duracionTotal = diferenciaTotal.Hours.ToString("00") + ":" + diferenciaTotal.Minutes.ToString("00") + ":" + diferenciaTotal.Seconds.ToString("00"); ;
                procesoArch.Resultados[procesoArch.PasoActual - 1] += "\nEl proceso finalizó con éxito a las " + FechaTermino.ToString("HH:mm:ss") + " con una duración de " + duracionTotal + "...";

                List<Stream> archivos = new List<Stream>();
                archivos.Add(FormarArchivoLOG(procesoArch));
                List<String> nombres = new List<String>();
                nombres.Add(ObtenerNombreArchivoLog());
                m.EnviarCorreo(emails, "Ejecución de " + nombreArchivo, "Concluyó el proceso de '" + nombreArchivo + "' satisfactoriamente.", correo2, archivos, nombres);
                procesoArch.AgregarLog(DateTime.Now.ToString("yyy-MM-dd HH:mm:ss") + ": Se envió un correo con los detalles a " + emails + ".");
                EnviarMensajePorSystemTray("El proceso terminó de forma exitosa, doble click para ver detalles.");
                evitarCerrar = false;
                lbl_mensaje.Text = "Terminado";
            }
            catch (Exception ex)
            {
                evitarCerrar = false;
                btn_cancelar.Enabled = false;
                procesoArch.FechaError = DateTime.Now;
                DateTime FinPaso = procesoArch.FechaError;
                procesoArch.EstaEjecutandose = false;
                if (procesoArch.PasoActual == 0)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                procesoArch.Resultados[procesoArch.PasoActual - 1] = GeneraResultado("ERROR: " + ex.Message, InicioPaso, FinPaso);
                String correo = @"<h2>Resultado</h2>

                                <p>La ejecución de '" + nombreArchivo + @"' se interrumpio por un error.</p>
                                
                                <h2>Detalles del error</h2>

                                <p>" + ex.Message + @".</p>

                                <h2>Otros datos</h2>

                                <ul>
	                                <li>Fecha inicio: " + procesoArch.FechaInicio.ToString("yyy-MM-dd HH:mm:ss") + @"</li>
	                                <li>Fecha Error:  " + procesoArch.FechaError.ToString("yyy-MM-dd HH:mm:ss") + @"</li>
                                </ul>";

                TimeSpan diferenciaTotal = FinPaso - InicioPaso;
                String duracionTotal = diferenciaTotal.Hours.ToString("00") + ":" + diferenciaTotal.Minutes.ToString("00") + ":" + diferenciaTotal.Seconds.ToString("00"); 

                procesoArch.Resultados[procesoArch.PasoActual - 1] += "\nEl programa finalizó por un error a las " + FinPaso.ToString("HH:mm:ss")+" con una duración total de "+duracionTotal+"...";
                List<Stream> archivos = new List<Stream>();
                archivos.Add(FormarArchivoLOG(procesoArch));
                List<String> nombres = new List<String>();
                nombres.Add(ObtenerNombreArchivoLog());
                m.EnviarCorreo(emails, "Ejecución de " + nombreArchivo, "Error en el proceso de ejecución de '" + nombreArchivo + "'.", correo, archivos, nombres);
                procesoArch.AgregarLog(DateTime.Now.ToString("yyy-MM-dd HH:mm:ss") + ": Error: " + ex.Message);
                procesoArch.AgregarLog("Se envió un correo con los detalles a " + emails);
                EnviarMensajePorSystemTray("El proceso terminó con errores, doble click para ver detalles.");
            }
        }
        private String GeneraResultado(String resultado, DateTime inicio, DateTime fin)
        {
            TimeSpan diferencia = fin - inicio;
            String duracion = diferencia.Hours.ToString("00") + ":" + diferencia.Minutes.ToString("00") + ":" + diferencia.Seconds.ToString("00") + "." + diferencia.Milliseconds.ToString("000") + " - *HORA INICIO: " + inicio.ToString("HH:mm:ss") + " - *HORA FIN: " + fin.ToString("HH:mm:ss");

            String resultadoTemp = "\n*RESULTADO: " + resultado.Replace("\n", " ") + "\n*DURACIÓN: " + duracion + "";
            return resultadoTemp;
        }
        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult dialogo = MessageBox.Show("¿Está seguro de cancelar el proceso?", "ATENCION!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dialogo == System.Windows.Forms.DialogResult.Yes)
            {
                procesoActualArchivo.FechaCancelacion = DateTime.Now;
                String correo = @"<h2>Resultado</h2>

                                <p>La ejecución de '" + nombreArchivo + @"' fue cancelada por el usuario.</p>

                                <h2>Último paso ejecutado correctamente</h2>

                                <p> Paso " + procesoActualArchivo.PasoActual + @".</p>

                                <h2>Otros datos</h2>

                                <ul>
                                    <li>Fecha de inicio:      " + procesoActualArchivo.FechaInicio.ToString("yyy-MM-dd HH:mm:ss") + @"</li>
	                                <li>Fecha de cancelación: " + procesoActualArchivo.FechaCancelacion.ToString("yyy-MM-dd HH:mm:ss") + @"</li>
                                </ul>";

                TimeSpan diferenciaTotal = procesoActualArchivo.FechaCancelacion - procesoActualArchivo.FechaInicio;
                String duracionTotal = diferenciaTotal.Hours.ToString("00") + ":" + diferenciaTotal.Minutes.ToString("00") + ":" + diferenciaTotal.Seconds.ToString("00"); 

                procesoActualArchivo.Resultados[procesoActualArchivo.PasoActual - 1] += "\nProceso cancelado por el usuario a las " + procesoActualArchivo.FechaCancelacion.ToString("HH:mm:ss") + " con una duración total de "+duracionTotal+"...";
                List<Stream> archivos = new List<Stream>();
                archivos.Add(FormarArchivoLOG(procesoActualArchivo));
                List<String> nombres = new List<String>();
                nombres.Add(ObtenerNombreArchivoLog());
                m.EnviarCorreo(emails, "Ejecución de " + nombreArchivo, "Cancelación de proceso de ejecución de '" + nombreArchivo + "'.", correo, archivos, nombres);
                procesoActualArchivo.EstaEjecutandose = false;
                limpiar();

            }
        }
        private void limpiar()
        {
            //some_thread.Abort();
            lb_ejecucion.Items.Clear();
            lbl_mensaje.Text = "";
            btn_cancelar.Enabled = false;
            evitarCerrar = false;
            lbl_mensaje.Text = "";
            pb_progreso.Value = 0;
        }
        private Stream FormarArchivoLOG(ProcesoArchivo proc)
        {
            StringBuilder archivo = new StringBuilder();
            int truncado = 150;
            for (int i = 0; i < proc.PasoActual; i++)
            {
                String comando = "";
                if (proc.ContenidoEjecucion[i].Length > truncado)
                    comando = proc.ContenidoEjecucion[i].Substring(0, truncado);
                else
                    comando = proc.ContenidoEjecucion[i];
                comando = comando.Replace("\n", " ").Trim() + "..." + proc.Resultados[i];
                archivo.Append("--------- PASO " + (i + 1) + ":--------------------------------------------------------------------------" + Environment.NewLine);
                archivo.AppendLine(("*INSTRUCCIÓN: " + comando).Replace("\n", Environment.NewLine).Replace("\t", "  ") + Environment.NewLine);
                //archivo.Append(Environment.NewLine);
                //archivo.Append(Environment.NewLine);
                //archivo.Append("---------------------------------------------------------------------------------------------------" + Environment.NewLine);
            }

            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(archivo);
            writer.Flush();
            stream.Position = 0;
            String path = Directory.GetCurrentDirectory() + @"\LOG\"+Environment.MachineName+@"\";
            if (!Directory.Exists(path))
            {
                DirectoryInfo di = Directory.CreateDirectory(path);
            }

            FileStream fileStream = new FileStream(path + ObtenerNombreArchivoLog(), FileMode.CreateNew, FileAccess.Write);
            
            stream.CopyTo(fileStream);
            fileStream.Dispose();
            stream.Position = 0;
            return stream;
        }
        private void lb_ejecucion_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lb_ejecucion.SelectedIndex != -1 && procesoActualArchivo != null)
            {
                String pasoSeleccionado = lb_ejecucion.SelectedItem.ToString();
                String numero = "";
                for (int i = 27; i < pasoSeleccionado.Length; i++)
                {

                    if (pasoSeleccionado[i] == ']')
                        break;
                    numero += pasoSeleccionado[i];
                }
                int num = -1;
                try
                {
                    num = Convert.ToInt32(numero);
                }
                catch { return; }
                String codigoEjecutado = procesoActualArchivo.ContenidoEjecucion[num - 1];
                CodigoEjecutado ce = new CodigoEjecutado(codigoEjecutado);
                ce.Show();
            }
        }


        private void chb_proceso_Agendado_CheckedChanged(object sender, EventArgs e)
        {
            cmb_proceso_hora.Enabled = chb_proceso_Agendado.Checked;
            cmb_proceso_minutos.Enabled = chb_proceso_Agendado.Checked;
        }
        private void CargarProcesosEnCombo()
        {
            cmb_proceso_procesosRegistrados.Items.Clear();
            cmb_procesosEjecucion.Items.Clear();
            itemEnEjecucion.DropDownItems.Clear();
            foreach (ProcesoArchivo proc in procesosArchivos)
            {
                cmb_proceso_procesosRegistrados.Items.Add(proc.NombreProceso);
                cmb_procesosEjecucion.Items.Add(proc.NombreProceso);
                itemEnEjecucion.DropDownItems.Add(proc.NombreProceso);
            }
        }
        private void btn_proceso_agregar_Click(object sender, EventArgs e)
        {
            procesosArchivos.Add(new ProcesoArchivo() { NombreProceso = "<Nuevo>" });
            itemEnEjecucion.DropDownItems.Add("<Nuevo>");
            CargarProcesosEnCombo();
            cmb_proceso_procesosRegistrados.SelectedIndex = cmb_proceso_procesosRegistrados.Items.Count - 1;
        }
        private Boolean ConvierteStringABool(String valor)
        {
            if (valor == null)
                return false;
            if (valor.Trim().ToUpper().Equals("SI"))
                return true;
            else
                return false;
        }
        private String ConvierteBoolAString(Boolean valor)
        {
            if (valor)
                return "SI";
            else
                return "NO";
        }
        private void GuardarProcesosAArchivo()
        {
            int i = 1;
            foreach (ProcesoArchivo proc in procesosArchivos)
            {
                var_personalizado.GuardarValorVariable("PROCESOS_" + i + "_RUTA_ARCHIVO", proc.RutaArchivo);
                var_personalizado.GuardarValorVariable("PROCESOS_" + i + "_HORA_EJECUCION", proc.HoraEjecucion);
                var_personalizado.GuardarValorVariable("PROCESOS_" + i + "_TIPO_SERVIDOR", proc.TipoServidor);
                var_personalizado.GuardarValorVariable("PROCESOS_" + i + "_ESTA_AGENDADO", proc.EstaAgendado);
                var_personalizado.GuardarValorVariable("PROCESOS_" + i + "_NOMBRE_PROCESO", proc.NombreProceso);
                i++;
            }
            var_personalizado.GuardarValorVariable("TOTAL_PROCESOS", (i - 1).ToString());
            MessageBox.Show("Se guardó correctamente.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void cmb_proceso_procesosRegistrados_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProcesoArchivo proc = procesosArchivos[cmb_proceso_procesosRegistrados.SelectedIndex];
            txt_proceso_archivo.Text = proc.RutaArchivo;
            txt_proceso_nombre.Text = proc.NombreProceso;
            chb_proceso_Agendado.Checked = ConvierteStringABool(proc.EstaAgendado);
            if (proc.HoraEjecucion != null && !proc.HoraEjecucion.Trim().Equals(""))
            {
                cmb_proceso_hora.SelectedItem = (proc.HoraEjecucion.Split(':'))[0].Trim();
                cmb_proceso_minutos.SelectedItem = (proc.HoraEjecucion.Split(':'))[1].Trim();
            }
            cmb_proceso_tipoServer.SelectedItem = proc.TipoServidor;
        }

        private void btn_proceso_actualizar_Click(object sender, EventArgs e)
        {
            String hora = "";
            if (chb_proceso_Agendado.Checked && (cmb_proceso_hora.SelectedItem == null || cmb_proceso_minutos.SelectedItem == null))
            {
                MessageBox.Show("Debe seleccionar una hora para agendar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                hora = cmb_proceso_hora.SelectedItem.ToString() + ":" + cmb_proceso_minutos.SelectedItem.ToString();
            }

            ProcesoArchivo proc = procesosArchivos[cmb_proceso_procesosRegistrados.SelectedIndex];
            proc.RutaArchivo = txt_proceso_archivo.Text;
            proc.NombreProceso = txt_proceso_nombre.Text;
            proc.EstaAgendado = ConvierteBoolAString(chb_proceso_Agendado.Checked);
            proc.HoraEjecucion = hora;
            proc.TipoServidor = cmb_proceso_tipoServer.SelectedItem.ToString();
            CargarProcesosEnCombo();
            cmb_proceso_procesosRegistrados.SelectedItem = proc.NombreProceso;
        }

        private void btn_proceso_guardar_Click(object sender, EventArgs e)
        {
            GuardarProcesosAArchivo();

            var_personalizado.GuardarValorVariable("EMAILS_USUARIO", txt_proceso_correoNotificaciones.Text.Trim());
            var_personalizado.GuardarValorVariable("ENVIAR_EMAILS", ConvierteBoolAString(chb_proceso_EnviarNotificaciones.Checked));
            CargarVariables();
        }

        private void cmb_procesosEjecucion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_procesosEjecucion.SelectedIndex != -1)
            {
                if (procesosArchivos.Count > 0)
                {
                    procesoActualArchivo = procesosArchivos[cmb_procesosEjecucion.SelectedIndex];
                }
            }
        }

        private void btn_ejecutarProceso_Click_1(object sender, EventArgs e)
        {
            if (cmb_procesosEjecucion.SelectedIndex != -1)
            {
                if (procesosArchivos.Count > 0 && !procesosArchivos[cmb_procesosEjecucion.SelectedIndex].EstaEjecutandose)
                {
                    procesosArchivos[cmb_procesosEjecucion.SelectedIndex].HiloProceso = new Thread(EjecutarContenido);
                    procesosArchivos[cmb_procesosEjecucion.SelectedIndex].HiloProceso.Start(procesosArchivos[cmb_procesosEjecucion.SelectedIndex]);
                    procesosArchivos[cmb_procesosEjecucion.SelectedIndex].EstaEjecutandose = true;
                }
                else
                {
                    MessageBox.Show("El proceso " + procesosArchivos[cmb_procesosEjecucion.SelectedIndex].NombreProceso + " ya se encuentra ejecutandose.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btn_actualizarLog_Click(object sender, EventArgs e)
        {
            ActualizarPAnt();
        }
        private void EnviarMensajePorSystemTray(String mensaje)
        {
            if (notify.Visible)
            {
                notify.BalloonTipText = mensaje;
                notify.BalloonTipTitle = "Ejecuta BI";
                notify.ShowBalloonTip(4000);
            }
        }
        private void MinimizarASystemTray()
        {
            Hide();
            notify.Visible = true;
            notify.BalloonTipText = "La lista de procesos continuará con su ejecución normal, con doble click restauras la ventana.";
            notify.BalloonTipTitle = "Ejecuta BI";
            notify.ShowBalloonTip(4000);
        }

        private void notify_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            notify.Visible = false;
        }

        private void itemCerrarPrograma_Click(object sender, EventArgs e)
        {
            Boolean hayEjecuciones = HayEjecuciones();
            if (hayEjecuciones)
            {
                MessageBox.Show("No es posible cerrar la aplicación debido hay que hay procesos ejecutandose, debe cancelar dichos procesos antes.","Atención!",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }
            else
            {
                System.Environment.Exit(0);
            }
        }

        private void itemAbrirPrograma_Click(object sender, EventArgs e)
        {
            this.Show();
            notify.Visible = false;
        }


    }
}
