using Herramientas.Archivos;
using Herramientas.Mail;
using Herramientas.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace EstadoResultados
{
    public class EjecutarServicioEstadoResultados
    {
        DBAcceso dbAcceso;
        DBAcceso dbAccesoHilo;
        Variable vars;
        String emails;
        Boolean ContinuarEjecutando = true;
        //sql
        Firebird firebird;
        Boolean usaFirebird;
        //
        public delegate void MostrarMensaje(String mensaje);
        public event MostrarMensaje mostrarMensaje;
        public delegate void MostrarEstatus(String estatus);
        public event MostrarEstatus mostrarEstatus;
        public delegate void MostrarPorcentaje(double porcentaje);
        public event MostrarPorcentaje mostrarPorcentaje;
        public delegate void TerminoProceso();
        public event TerminoProceso terminoProceso;

        public EjecutarServicioEstadoResultados()
        {
            dbAcceso = DBAcceso.ObtenerInstancia();
            dbAccesoHilo = new DBAcceso(dbAcceso.CadenaConexion);
            //CargarConceptosBD();
            vars = new Variable("data");

            
        }
        public void IniciarProceso()
        {
            logActividades.Clear();
            CargarVariables();
            CargarBaseDatos();
            CargarConceptosBD();
        }
        private void CargarVariables()
        {
            vars.LeerArchivo();
            emails = vars.ObtenerValorVariable<String>("EMAILS") + "; " + vars.ObtenerValorVariable<String>("EMAILS_USUARIO");

            MostrarEstatusIn("En espera");
        }
        List<String> logActividades = new List<string>();
        private List<Adjunto> ObtenerAdjuntos()
        {
            System.IO.Directory.CreateDirectory("LOG");
            String archivoTexto = "";
            String nombreArchivo = @"LOG\LOG_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
            using (StreamWriter w = File.AppendText(nombreArchivo))
            {
                foreach (String linea in logActividades)
                {
                    archivoTexto = linea.ToString();
                    w.WriteLine(archivoTexto);
                }
            }

            MemoryStream ms = new MemoryStream(ReadFile(nombreArchivo));

            Adjunto adjunto = new Adjunto();
            adjunto.NombreArchivo = nombreArchivo;
            adjunto.Stream = ms;

            return new List<Adjunto> { adjunto };
        }
        public static byte[] ReadFile(string filePath)
        {
            byte[] buffer;
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            try
            {
                int length = (int)fileStream.Length;  // get file length
                buffer = new byte[length];            // create buffer
                int count;                            // actual number of bytes read
                int sum = 0;                          // total number of bytes read

                // read until Read method returns 0 (end of the stream has been reached)
                while ((count = fileStream.Read(buffer, sum, length - sum)) > 0)
                    sum += count;  // sum is a buffer offset for next reading
            }
            finally
            {
                fileStream.Close();
            }
            return buffer;
        }
        private void CargarBaseDatos()
        {
            try
            {
                String respuesta = vars.ObtenerValorVariable<String>("UsaFireBird");

                if (respuesta.Trim().ToUpper().Equals("SI"))
                {
                    usaFirebird = true;

                    String baseDatosFirebird = vars.ObtenerValorVariable<String>("baseDatosFirebird");
                    String dataSourceFirebird = vars.ObtenerValorVariable<String>("dataSourceFirebird");

                    firebird = new Firebird();
                    if (baseDatosFirebird != null && dataSourceFirebird != null && !baseDatosFirebird.Trim().Equals("") && !dataSourceFirebird.Trim().Equals(""))
                    {
                        firebird.ConfigurarConexion(baseDatosFirebird, dataSourceFirebird);
                    }
                }

                //String servidorCrop = vars.ObtenerValorVariable<String>("servidorCrop");
                //String usuarioCrop = vars.ObtenerValorVariable<String>("usuarioCrop");
                //String ContraseñaCrop = vars.ObtenerValorVariable<String>("ContraseñaCrop");
                //String baseDatosCrop = "EstadoResultados";

                //firebird = new Firebird();
                //if (!servidorCrop.Trim().Equals("") && !usuarioCrop.Trim().Equals("") && !ContraseñaCrop.Trim().Equals("") && !baseDatosCrop.Trim().Equals(""))
                //{
                //    sql.ConfigurarConexion(servidorCrop, baseDatosCrop, usuarioCrop, ContraseñaCrop);
                //}

            }
            catch (Exception ex)
            {
                EmailFormatos.EnviarMailError(ex.Message, "Error Estado de resultados", ex.StackTrace, ex, emails, ObtenerAdjuntos());
                terminoProceso();
            }
        }
        private void MostrarEstatusIn(String estatus)
        {
            if (mostrarEstatus != null)
                mostrarEstatus(estatus);
        }
        private void MostrarMensajesIn(String mensaje)
        {
            if (mostrarMensaje != null)
                mostrarMensaje(mensaje);
            logActividades.Add(mensaje);
        }
        private void MostrarPorcentajeIn(double porcentaje)
        {
            if (mostrarPorcentaje != null)
                mostrarPorcentaje(porcentaje);
        }
        private void AgregarMensaje(String mensaje)
        {
            MostrarMensajesIn(mensaje);
        }
        int contador = 0;
        int totalProcesos = 0;
        DataTable dt;
        List<int> idsRecorridos = new List<int>();
        List<ConceptoEstadoFinanciero> conceptos = new List<ConceptoEstadoFinanciero>();
        private void CargarConceptosBD()
        {
            try
            {
                MostrarEstatusIn("En ejecución");

                MostrarPorcentajeIn(0);

                EmailFormatos.EnviarMailInformacion("Se ha iniciado el proceso de ejecución del estado de resultados de forma automática en el servidor.", "Estado de resultados", emails, null);
                contador = 1;
                totalProcesos = 0;
                AgregarMensaje("Iniciando actualización de conceptos...");
                dt = dbAcceso.EjecutarConsulta("select est.id, est.nombre_concepto, det.esIndirecto, det.query_origen from CuentasEstadoResultados est inner join CuentasEstadoResultadosDetalle det on est.id = det.id_cuentaEstadoRes");
                //TreeNode tnPrincipal = tv_conceptosEstadoResultados.Nodes[0];
                foreach (DataRow dr in dt.Rows)
                {
                    SeCanceloProceso();
                    if (idsRecorridos.Contains(Convert.ToInt32(dr["id"])))
                    {
                        continue;
                    }
                    ConceptoEstadoFinanciero cPadre = new ConceptoEstadoFinanciero();
                    cPadre.ID = Convert.ToInt32(dr["id"]);
                    cPadre.NombreConcepto = dr["nombre_concepto"].ToString();
                    cPadre.EsIndirecto = Convert.ToBoolean(dr["esIndirecto"]);
                    cPadre.Query = dr["query_origen"].ToString();
                    CargarConceptosRecursivo(cPadre);
                    conceptos.Add(cPadre);
                }
                totalProcesos = conceptos.Count + 5;
                AvanzarProcesos();
                EjecutarConceptosHilo();
            }
            catch (Exception ex)
            {
                AgregarMensaje("Ocurrio un error al ejecutar el proceso, verificar con sistemas. Detalles: " + ex.Message);
                //Mensajes.Error("Ocurrio un error al ejecutar el proceso, verificar con sistemas. Detalles: " + ex.Message,"Error");
                EmailFormatos.EnviarMailError("Error al ejecutar el proceso.", "Estado de resultados", ex.Message, ex, emails, ObtenerAdjuntos());
                
                terminoProceso();
            }
        }
        private void AvanzarProcesos()
        {
            if (contador > totalProcesos) return;
            MostrarPorcentajeIn((100 * contador) / totalProcesos);
            contador++;
        }
        private void EjecutarConceptosHilo()
        {
            try
            {
                AvanzarProcesos();
                AgregarMensaje("Eliminando fuente de datos concentrada...");
                AvanzarProcesos();
                dbAccesoHilo.EjecutarConsulta("delete Tb_Estado_Resultados");
                AvanzarProcesos();
                AgregarMensaje("Iniciando ejecución de conceptos...");
                foreach (ConceptoEstadoFinanciero cTemp in conceptos)
                {
                    SeCanceloProceso();
                    AvanzarProcesos();
                    AgregarMensaje("Ejecutando " + cTemp.NombreConcepto + "...");
                    cTemp.Query = cTemp.Query.Replace("@CONCEPTO", cTemp.ID.ToString());

                    if (cTemp.Query != null && !cTemp.Query.Trim().Equals(""))
                    {
                        if (usaFirebird)
                        {
                            DataTable dt = firebird.EjecutarConsulta(cTemp.Query);//"select Cast('2015-01-01' as date),'12345','12345','123',15,'14-1501000000','0000','0000','1',1.50,3.50 from new_table");
                            foreach (DataRow dr in dt.Rows)
                            {
                                String insertTemp = @"INSERT INTO Tb_Estado_Resultados (Fecha,Lote,Valvula,Cultivo,Concepto,Empleado,Proceso,Operacion,Directo_Indirecto,Importe,Importe_Presupuesto) VALUES(@1,@2 ,@3 ,@4 ,@5 ,@6 ,@7 ,@8,@9,@10,@11);";
                                List<Object> valores = new List<object>();
                                for (int i = 0; i < dt.Columns.Count; i++)
                                {
                                    valores.Add(dr[i]);
                                }
                                dbAccesoHilo.EjecutarConsulta(insertTemp, valores);
                            }
                        }
                        else
                        {
                            dbAccesoHilo.EjecutarConsulta(cTemp.Query);
                        }
                    }
                    //Thread.Sleep(400);
                }

                //actualizar fuente de hechos
                AvanzarProcesos();
                AgregarMensaje("Actualizando Fuentes de estados de resultados, actualizacion de hechos y publicación de cubo (BI)...");
                dbAccesoHilo.EjecutarConsulta("exec Sp_Ejecuta_Script_Estado_Resultados");

                //AvanzarProcesos();
                //AgregarMensaje("Creando cubos y publicando (BI)...");
                //dbAccesoHilo.EjecutarConsulta("exec ");

                AgregarMensaje("Se ha terminado el proceso de ejecución del estado de resultados.");
                EmailFormatos.EnviarMailInformacion("Se ha terminado el proceso de ejecución del estado de resultados.", "Estado de resultados", emails, ObtenerAdjuntos());
                MostrarEstatusIn("En espera");
                terminoProceso();
            }
            catch (Exception ex)
            {
                AgregarMensaje("Ocurrio un error al ejecutar el proceso, verificar con sistemas. Detalles del error: " + ex.Message);
                EmailFormatos.EnviarMailError("Error al ejecutar el proceso.", "Estado de resultados", ex.Message, ex, emails, ObtenerAdjuntos());
                MostrarEstatusIn("Ocurrió Error");
                terminoProceso();
            }
        }
        private void SeCanceloProceso()
        {
            if (!ContinuarEjecutando)
            {
                EmailFormatos.EnviarMailInformacion("Se canceló el proceso de generación de estado de resultados.", "Cancelación estado resultados", emails, ObtenerAdjuntos());
                terminoProceso();
                return;
            }
        }
        private void CargarConceptosRecursivo(ConceptoEstadoFinanciero cPadre)
        {
            if (idsRecorridos.Contains(cPadre.ID))
            {
                return;
            }
            idsRecorridos.Add(cPadre.ID);
            DataTable dtDet = dbAcceso.EjecutarConsulta("select id_cuentaEstadoRes from CuentasEstadoResultadosDetalle where id_cuentaPadre = @id", new List<object> { cPadre.ID });

            foreach (DataRow drDet in dtDet.Rows)
            {
                int idHijo = Convert.ToInt32(drDet["id_cuentaEstadoRes"]);

                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    SeCanceloProceso();
                    DataRow dr = dt.Rows[j];
                    if (Convert.ToInt32(dr["id"]) == idHijo)
                    {
                        ConceptoEstadoFinanciero cHijo = new ConceptoEstadoFinanciero();
                        cHijo.ID = Convert.ToInt32(dr["id"]);
                        cHijo.NombreConcepto = dr["nombre_concepto"].ToString();
                        cHijo.EsIndirecto = Convert.ToBoolean(dr["esIndirecto"]);
                        cHijo.Query = dr["query_origen"].ToString();
                        if (cPadre.ConceptosHijos == null) cPadre.ConceptosHijos = new List<ConceptoEstadoFinanciero>();
                        cPadre.ConceptosHijos.Add(cHijo);
                        //idsRecorridos.Add(cHijo.ID);
                        conceptos.Add(cHijo);
                        CargarConceptosRecursivo(cHijo);
                        break;
                    }
                }
            }
        }
    }
}
