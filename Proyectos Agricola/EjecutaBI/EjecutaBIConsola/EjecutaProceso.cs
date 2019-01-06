using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Herramientas.Archivos;
using System.Threading;
using Herramientas.SQL;
using Herramientas.Mail;
using System.IO;
using Herramientas.Forms.ExcelElements;
using Herramientas.Forms;

namespace EjecutaBIConsola
{
    public class EjecutaProceso
    {
        Variable varProcesos;
        Variable varConexiones;
        String separador = "----------------------------------------------------------------------------";
        String EMAILS = "";
        //SQLServer
        String SQLSERVER_BD = "";
        String SQLSERVER_Servidor = "";
        String SQLSERVER_Usuario = "";
        String SQLSERVER_Contra = "";
        //Firebird
        String FIREBIRD_RUTABD = "";
        String FIREBIRD_Servidor = "";
        String FIREBIRD_Usuario = "";
        String FIREBIRD_Contra = "";

        List<Proceso> Procesos = new List<Proceso>();
        List<Proceso> ProcesosEnEjecucion = new List<Proceso>();
        Thread HiloMonitoreo;

        private void CargarVariables()
        {
            varConexiones = new Variable("Conexiones.config");
            varProcesos = new Variable("Procesos.config");
            EMAILS = varConexiones.ObtenerValorVariable<String>("EMAILS");

            SQLSERVER_BD = varConexiones.ObtenerValorVariable<String>("SQLSERVER_BD");
            SQLSERVER_Servidor = varConexiones.ObtenerValorVariable<String>("SQLSERVER_Servidor");
            SQLSERVER_Usuario = varConexiones.ObtenerValorVariable<String>("SQLSERVER_Usuario");
            SQLSERVER_Contra = varConexiones.ObtenerValorVariable<String>("SQLSERVER_Contra");

            FIREBIRD_RUTABD = varConexiones.ObtenerValorVariable<String>("FIREBIRD_RUTABD");
            FIREBIRD_Servidor = varConexiones.ObtenerValorVariable<String>("FIREBIRD_Servidor");
            FIREBIRD_Usuario = varConexiones.ObtenerValorVariable<String>("FIREBIRD_Usuario");
            FIREBIRD_Contra = varConexiones.ObtenerValorVariable<String>("FIREBIRD_Contra");

        }
        public void IniciarMonitoreo()
        {
            CargarVariables();
            Herramientas.Mail.EmailFormatos.EnviarMailInformacion("Se ha iniciado el monitoreo de Ejecuta BI.", "Ejecuta BI", EMAILS, null);

            HiloMonitoreo = new Thread(Monitoreo);
            HiloMonitoreo.Start();

        }
        private void CargarProcesosProgramados()
        {
            CargarVariables();

            Procesos.Clear();
            int numeroProcesos = varProcesos.ObtenerValorVariable<int>("PROCESOS_TOTAL");

            for (int i = 0; i < numeroProcesos; i++)
            {
                Proceso proceso = new Proceso();
                //cargando las variables del archivo
                String servidor = varProcesos.ObtenerValorVariable<String>("PROCESOS_" + i + "_SERVIDOR");
                int Hora = varProcesos.ObtenerValorVariable<int>("PROCESOS_" + i + "_HORA");
                int Minuto = varProcesos.ObtenerValorVariable<int>("PROCESOS_" + i + "_MINUTO");
                String Ruta = varProcesos.ObtenerValorVariable<String>("PROCESOS_" + i + "_RUTA");
                String Tipo = varProcesos.ObtenerValorVariable<String>("PROCESOS_" + i + "_TIPO");
                String nombre = varProcesos.ObtenerValorVariable<String>("PROCESOS_" + i + "_NOMBRE");
                Boolean esActivo = varProcesos.ObtenerValorVariable<Boolean>("PROCESOS_" + i + "_ACTIVO");
                //asignando los valores
                if (servidor.ToUpper().Equals("SQL SERVER"))
                {
                    proceso.TipoServidor = Proceso.Servidor.SQLServer;
                }
                if (servidor.ToUpper().Equals("FIREBIRD"))
                {
                    proceso.TipoServidor = Proceso.Servidor.Firebird;
                }
                if (Tipo.ToUpper().Equals("EXCEL"))
                {
                    proceso.TipoEjecucion = Proceso.Tipo.EsExcel;
                }
                if (Tipo.ToUpper().Equals("SCRIPT"))
                {
                    proceso.TipoEjecucion = Proceso.Tipo.EsScript;
                }
                proceso.Nombre = nombre;
                proceso.Hora = Hora;
                proceso.Minuto = Minuto;
                proceso.Ruta = Ruta;
                proceso.EstaActivo = esActivo;
                //agregando el proceso al listado
                Procesos.Add(proceso);

            }

        }

        private void Monitoreo()
        {
            try
            {
                while (true)
                {
                    MostrarMensaje(null, "El monitoreo se encuentra activo.");
                    CargarProcesosProgramados();

                    foreach (Proceso proceso in Procesos)
                    {
                        int horaActual = DateTime.Now.Hour;
                        int minutoActual = DateTime.Now.Minute;

                        if (proceso.Hora == horaActual && proceso.Minuto == minutoActual && !SeEncuentra(proceso) && proceso.EstaActivo)
                        {
                            proceso.SeEstaEjecutando = true;
                            Thread HiloProceso = new Thread(EjecutaProcesoIndividual);
                            HiloProceso.Start(proceso);
                        }
                    }
                    Thread.Sleep(60000);
                }
            }
            catch (Exception ex)
            {
                Herramientas.Mail.EmailFormatos.EnviarMailError(ex.Message, "Error en EjecutaBI", "Ocurrío un error al ejecutar el monitoreo de procesos.", ex, EMAILS, null);
            }
        }

        public Boolean SeEncuentra(Proceso proceso)
        {
            foreach (Proceso procesTemp in ProcesosEnEjecucion)
            {
                if (procesTemp.Nombre.Equals(proceso.Nombre))
                    return true;
            }
            return false;
        }

        public void EjecutaProcesoIndividual(Object oProceso)
        {
            List<String> logAGuardar = new List<string>(); 
            Proceso proceso = (Proceso)oProceso;
            EjecutaProcesoIndividual(logAGuardar, proceso);
        }
        public Proceso BuscarProceso(String nombre)
        {
            foreach (Proceso procesTemp in Procesos)
            {
                if (procesTemp.Nombre.Equals(nombre))
                    return procesTemp;
            }
            return null;
        }
        public void EjecutaProcesoIndividual(List<String> logAGuardar, Proceso proceso)
        {
            
            int numeroErrores = 0;
            
            ProcesosEnEjecucion.Add(proceso);

            DateTime tiempoInicioProceso = DateTime.MinValue;
            DateTime tiempoFinProceso = DateTime.MinValue;
            try
            {
                MostrarMensajeCorreoSinHoraLOG(logAGuardar, "Iniciado el proceso '" + proceso.Nombre + "' con fecha: " + Herramientas.Conversiones.Formatos.DateTimeAFechaLarga(DateTime.Now));
                tiempoInicioProceso = DateTime.Now;
                if (proceso.TipoEjecucion == Proceso.Tipo.EsScript)
                {
                    //para archivos de tipo script
                    ISQL sql = null;
                    try
                    {
                        if (proceso.TipoServidor == Proceso.Servidor.Firebird)
                        {
                            sql = new Firebird();
                            sql.ConfigurarConexion(FIREBIRD_Servidor, FIREBIRD_RUTABD, FIREBIRD_Usuario, FIREBIRD_Contra);
                        }
                        else if (proceso.TipoServidor == Proceso.Servidor.SQLServer)
                        {
                            sql = new SQL();
                            sql.ConfigurarConexion(SQLSERVER_Servidor, SQLSERVER_BD, SQLSERVER_Usuario, SQLSERVER_Contra);
                        }
                    }
                    catch (Exception ex)
                    {
                        MostrarMensaje(logAGuardar, "Error al configurar el servidor de base de datos, verificar datos.");
                        sql = null;
                    }
                    List<String> Comandos = new List<string>();
                    MostrarMensajeSinHoraLOG(logAGuardar, "");
                    MostrarMensajeSinHoraLOG(logAGuardar, separador);
                    MostrarMensaje(logAGuardar, "Limpiando código de comentarios...");
                    String archivo = Archivo.LeerArchivoTexto(proceso.Ruta);
                    archivo = archivo.Replace("\nGo\n", "\nGO\n").Replace("\ngo\n", "\nGO\n").Replace("\ngO\n", "\nGO\n");
                    archivo = archivo.Replace("\nGo", "\nGO\n").Replace("\ngo", "\nGO\n").Replace("\ngO", "\nGO\n");
                    Comandos = archivo.Split(new string[] { "\nGO\n" }, StringSplitOptions.None).ToList<String>();

                    EliminarComentariosDeCodigo(Comandos);

                    MostrarMensaje(logAGuardar, "Abriendo conexión a base de datos...");
                    if (sql != null)
                        sql.AbrirConexion();
                    MostrarMensajeSinHoraLOG(logAGuardar, separador);
                    foreach (String comando in Comandos)
                    {
                        Boolean error = false;
                        if (comando.Replace("\n", "").Trim().Equals(""))
                            continue;

                        DateTime fechaInicio = DateTime.MinValue;
                        DateTime fechaFin = DateTime.MinValue;
                        double Minutosduracion = 0;
                        MostrarMensaje(logAGuardar, "Ejecutando: ");
                        String comandoLog = comando.Trim().Replace("\n", " ");
                        if (comandoLog.Length > 50)
                            MostrarMensaje(logAGuardar, comandoLog.Substring(0, 50) + "...");
                        else
                            MostrarMensaje(logAGuardar, comandoLog.Substring(0, comandoLog.Length) + "...");

                        String resultado = "Realizado correctamente.";
                        if (comando.Trim().StartsWith("##") || comando.Trim().ToUpper().StartsWith("CMD"))
                        {
                            String shell = comando.Replace("##", "").Replace("CMD", "");
                            fechaInicio = DateTime.Now;
                            //MostrarMensaje(logAGuardar, "Inicio: " + Herramientas.Conversiones.Formatos.DateTimeAFechaLarga(fechaInicio));

                            String resultadoT = Herramientas.Shell.EjecutadorComandos.EjecutaComando(shell);
                            fechaFin = DateTime.Now;
                            if (!resultadoT.Trim().Equals(""))
                            {
                                numeroErrores++;
                                error = true;
                                resultado = resultadoT;
                            }
                        }
                        else if (comando.Trim().StartsWith("%%") || comando.Trim().ToUpper().StartsWith("BAT"))
                        {
                            String ruta = comando.Replace("%%", "").Replace("BAT", "");
                            fechaInicio = DateTime.Now;
                            //MostrarMensaje(logAGuardar, "Inicio: " + Herramientas.Conversiones.Formatos.DateTimeAFechaLarga(fechaInicio));

                            String resultadoT = Herramientas.Shell.EjecutadorComandos.EjecutarArchivoBAT(ruta);
                            fechaFin = DateTime.Now;
                            if (!resultadoT.Trim().Equals(""))
                            {
                                numeroErrores++;
                                error = true;
                                resultado = resultadoT;
                            }
                        }
                        else if (comando.Trim().StartsWith("&&") || comando.Trim().ToUpper().StartsWith("SCRIPT"))
                        {
                            String nombre = comando.Replace("&&", "").Replace("SCRIPT", "").Trim();
                            fechaInicio = DateTime.Now;
                            Proceso Script = BuscarProceso(nombre);
                            String resultadoT = "";
                            if (Script != null)
                            {
                                Thread tProceso = new Thread(EjecutaProcesoIndividual);
                                tProceso.Start(Script);
                            }
                            else
                            {
                                resultadoT = "Script no encontrado. Verificar configuraciones.";
                            }
                            fechaFin = DateTime.Now;
                            if (!resultadoT.Trim().Equals(""))
                            {
                                numeroErrores++;
                                error = true;
                                resultado = resultadoT;
                            }
                        }
                        else if (comando.Trim().StartsWith("$$") || comando.Trim().ToUpper().StartsWith("IMPORT_EXCEL"))
                        {
                            String rutaExcel = comando.Trim().Replace("$$", "").Replace("IMPORT_EXCEL", "").Replace("\n", "").Trim();
                            fechaInicio = DateTime.Now;
                            //MostrarMensaje(logAGuardar, "Inicio: " + Herramientas.Conversiones.Formatos.DateTimeAFechaLarga(fechaInicio));
                            String resultadoT = "";
                            try
                            {
                                List<String> archivos = new List<string>();
                                if (!rutaExcel.Trim().ToLower().EndsWith(".xlsx"))
                                {
                                    archivos.AddRange(Herramientas.Archivos.Archivo.ObtenerRutasArchivoDeDirectorio(rutaExcel, new List<string>() { "xlsx" }, true));
                                }
                                else
                                {
                                    archivos.Add(rutaExcel);
                                }
                                foreach (String ruta in archivos)
                                {
                                    try
                                    {
                                        MostrarMensaje(logAGuardar, "Intentando importar: " + ruta);
                                        ExcelArchivo data = ExcelAPI.ObtenerDataDeArchivoExcel(ruta);
                                        if (sql != null)
                                            sql.CrearEInsertarArchivoDataExcel(data);
                                        MostrarMensaje(logAGuardar, "Importado con éxito: " + ruta);
                                    }
                                    catch (Exception ex)
                                    {
                                        MostrarMensaje(logAGuardar, "Error al importar: " + ruta +", Error: "+ex.Message);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                numeroErrores++;
                                resultadoT = ex.Message;
                                error = true;
                            }
                            fechaFin = DateTime.Now;
                            if (!resultadoT.Trim().Equals(""))
                                resultado = resultadoT;
                        }
                        else
                        {
                            if (!comando.Replace("\n", "").Trim().Equals(""))
                            {
                                if (!comando.Replace("\n", "").Trim().EndsWith("*/"))
                                {
                                    try
                                    {
                                        fechaInicio = DateTime.Now;
                                        //MostrarMensaje(logAGuardar, "Inicio: " + Herramientas.Conversiones.Formatos.DateTimeAFechaLOG(fechaInicio));
                                        if (sql != null)
                                            sql.EjecutarConsulta(comando);
                                        fechaFin = DateTime.Now;
                                    }
                                    catch (Exception ex)
                                    {
                                        resultado = ex.Message;
                                        numeroErrores++;
                                        error = true;
                                    }
                                }
                            }
                        }

                        TimeSpan diferencia = fechaFin - fechaInicio;

                        if (fechaFin != DateTime.MinValue)
                        {
                            //MostrarMensaje(logAGuardar, "Fin: " + Herramientas.Conversiones.Formatos.DateTimeAFechaLOG(fechaFin));
                            MostrarMensaje(logAGuardar, "Duración(Minutos): " + Herramientas.Conversiones.Formatos.RedondearANDecimales(diferencia.TotalMinutes, 4));
                        }
                        if (error)
                            MostrarMensaje(logAGuardar, "Error: " + resultado.Replace("\n", " "));
                        else
                            MostrarMensaje(logAGuardar, "Resultado: " + resultado.Replace("\n", " "));
                        MostrarMensajeSinHoraLOG(logAGuardar, separador);
                    }
                    MostrarMensajeSinHoraLOG(logAGuardar, "");
                    if (numeroErrores == 0)
                    {
                        MostrarMensajeSinHoraLOG(logAGuardar, "Proceso terminado con éxito.");
                    }
                    else
                    {
                        MostrarMensajeSinHoraLOG(logAGuardar, "Proceso terminado con " + numeroErrores + " errores.");
                    }
                    if (sql != null)
                        sql.CerrarConexion();
                    tiempoFinProceso = DateTime.Now;
                }
                else if (proceso.TipoEjecucion == Proceso.Tipo.EsExcel)
                {
                    //para archivos de excel
                }
                TimeSpan duracionTotal = tiempoFinProceso - tiempoInicioProceso;

                MostrarMensajeSinHoraLOG(logAGuardar, "Inicio: " + Herramientas.Conversiones.Formatos.DateTimeAFechaLOG(tiempoInicioProceso));
                MostrarMensajeSinHoraLOG(logAGuardar, "Fin:    " + Herramientas.Conversiones.Formatos.DateTimeAFechaLOG(tiempoFinProceso));
                MostrarMensajeSinHoraLOG(logAGuardar, "Duración(Minutos): " + Herramientas.Conversiones.Formatos.RedondearANDecimales(duracionTotal.TotalMinutes, 4));
                GuardarLogYEnviarPorCorreo(proceso.Nombre, logAGuardar);

                ProcesosEnEjecucion.Remove(proceso);

            }
            catch (Exception ex)
            {
                MostrarError(logAGuardar, ex);
                GuardarLogYEnviarPorCorreo(proceso.Nombre, logAGuardar);
                ProcesosEnEjecucion.Remove(proceso);
            }
        }
        private void GuardarLogYEnviarPorCorreo(String nombreProceso, List<String> log)
        {
            try
            {
                String archivoTexto = "";

                foreach (String linea in log)
                {
                    archivoTexto += linea + Environment.NewLine;
                }
                String rutaArchivo = @"LOG\" + nombreProceso + "_" + Herramientas.Conversiones.Formatos.DateTimeAFechaLOGArchivo(DateTime.Now) + ".txt";
                Herramientas.Archivos.Archivo.GuardarArchivoDeTexto(rutaArchivo, archivoTexto);

                Adjunto adj = new Adjunto();
                adj.NombreArchivo = nombreProceso + "_" + Herramientas.Conversiones.Formatos.DateTimeAFechaLOGArchivo(DateTime.Now) + ".txt";
                adj.Tipo = Adjunto.TipoAdjunto.PDF;
                adj.Stream = Adjunto.ArchitoAMemoryStream(rutaArchivo);

                Herramientas.Mail.EmailFormatos.EnviarMailInformacion("Proceso '" + nombreProceso + "' terminado.", "Ejecuta BI", EMAILS, new List<Adjunto>() { adj });

            }
            catch (Exception ex)
            {
                MostrarError(null, ex);
            }
        }
        private void MostrarMensajeSinHoraLOG(List<String> log, String mensaje)
        {
            String Formateado = mensaje;
            if (log != null)
                log.Add(Formateado);
            Console.WriteLine(Formateado);
        }
        private void MostrarMensaje(List<String> log, String mensaje)
        {
            String Formateado = Herramientas.Conversiones.Formatos.DateTimeAFechaLOG(DateTime.Now) + ": " + mensaje;
            if (log != null)
                log.Add(Formateado);
            Console.WriteLine(Formateado);
        }
        private void MostrarError(List<String> log, Exception exception)
        {
            String Formateado = Herramientas.Conversiones.Formatos.DateTimeAFechaLOG(DateTime.Now) + ": " + exception.Message;
            if (log != null)
                log.Add(Formateado);
            Console.WriteLine(Formateado);
            Herramientas.Mail.EmailFormatos.EnviarMailError(exception.Message, "Error en Ejecuta BI", exception.Message, exception, EMAILS, null);
        }
        private void MostrarMensajeCorreo(List<String> log, String Mensaje)
        {
            String Formateado = Herramientas.Conversiones.Formatos.DateTimeAFechaLOG(DateTime.Now) + ": " + Mensaje;
            if (log != null)
                log.Add(Formateado);
            Console.WriteLine();
            Herramientas.Mail.EmailFormatos.EnviarMailInformacion(Mensaje, "Ejecuta BI", EMAILS, null);
        }
        private void MostrarMensajeCorreoSinHoraLOG(List<String> log, String Mensaje)
        {
            String Formateado = Mensaje;
            if (log != null)
                log.Add(Formateado);
            Console.WriteLine(Formateado);
            Herramientas.Mail.EmailFormatos.EnviarMailInformacion(Mensaje, "Ejecuta BI", EMAILS, null);
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
        private void EliminarComentariosDeCodigo(List<String> comandosArreglo)
        {
            for (int i = 0; i < comandosArreglo.Count; i++)
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
                comandosArreglo[i] = EliminaComentarioSimple(comandosArreglo[i]);
            }
        }
    }
}
