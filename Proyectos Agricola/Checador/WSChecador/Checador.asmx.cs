using DPFP;
using Herramientas.Archivos;
using Herramientas.Conversiones;
using Herramientas.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Web;
using System.Web.Services;

namespace WSChecador
{
    /// <summary>
    /// Descripción breve de Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Checador : System.Web.Services.WebService
    {
        DataTable dt;
        DPFP.Verification.Verification ver;
        DPFP.Verification.Verification.Result res;
        FeatureSet patronEntrada;
        String codigoEmpleado = "";
        List<Thread> Hilos = new List<Thread>();
        List<int> indiceInicial = new List<int>();
        List<int> indiceFinal = new List<int>();


        String ccve_nomina;
        String ccve_temporada;
        String bdNomina;
        String idChecador;
        String idHorario;

        [WebMethod]
        public String[] ChecarEmpleadoPorHuella(String featureSet, String ccve_nomina, String ccve_temporada, String bdNomina, String idChecador, String tamSegmentos, String idHorario, String esPrueba, String ServerBD)
        {
            Boolean esUnaPrueba = true;

            if (Application["dbAcceso" + idChecador] == null)
            {
                //Herramientas.Mail.EmailFormatos.EnviarMailInformacion("prueba exitosa parte 1: "+idChecador, "WS Checador", "abrahamm@wholesumharvest.com; alfredor@wholesumharvest.com; carlos.colio@wholesumharvest.com; said.villa@wholesumharvest.com", null);
                Application["dbAcceso" + idChecador] = new SQLServer(@"data source = " + ServerBD + "; initial catalog = " + bdNomina + "; user id = sa; password = 1@TCE123");
            }
            if (Application["dbAccesoReg" + idChecador] == null)
            {
                //Herramientas.Mail.EmailFormatos.EnviarMailInformacion("Se inició una nueva conexión con la BD para el checador: " + idChecador, "WS Checador", "abrahamm@wholesumharvest.com; alfredor@wholesumharvest.com; carlos.colio@wholesumharvest.com; said.villa@wholesumharvest.com", null);
                Application["dbAccesoReg" + idChecador] = new SQLServer(@"data source = " + ServerBD + "; initial catalog = " + bdNomina + "; user id = sa; password = 1@TCE123");
            }
            this.ccve_nomina = ccve_nomina;
            this.ccve_temporada = ccve_temporada;
            this.bdNomina = bdNomina;
            this.idChecador = idChecador;
            this.idHorario = idHorario;

            SQLServer sql = (SQLServer)Application["dbAcceso" + idChecador];

            String query = "select CCVE_EMPL, CHUELLADIGITAL from imagenes..CTL_TRAB_IMAGENES where CCVE_NOMINA  = '" + ccve_nomina + "' and CCVE_TEMPORADA = '" + ccve_temporada + "' and CHUELLADIGITAL is not null order by CCVE_EMPL";

            byte[] bytes = Herramientas.Conversiones.Converter.StringToByteArray(featureSet);

            if (bytes == null)
            {
                return null;
            }
            sql.AbrirConexion();
            patronEntrada = new DPFP.FeatureSet(new MemoryStream(bytes));
            Boolean sinChecar = true;
            int intentosChecado = 0;
            while (sinChecar)
            {
                try
                {
                    dt = sql.EjecutarConsulta(query);
                    sinChecar = false;
                }
                catch (Exception ex)
                {
                    intentosChecado++;
                    if (intentosChecado == 3)
                    {
                        throw new Exception("Ha ocurrido un error al intentar realizar el checado del empleado. Detalles: " + ex.Message);
                    }
                    Thread.Sleep(300);
                }
            }
            
            ver = new DPFP.Verification.Verification();
            res = new DPFP.Verification.Verification.Result();

            int numeroSegmentos = dt.Rows.Count / Convert.ToInt32(tamSegmentos);

            //if (Convert.ToInt32(tamSegmentos) >= dt.Rows.Count)
            //{
            //    numeroSegmentos = 1;

            //    Hilos.Add(new Thread(Buscar));
            //    indiceInicial.Add(0);
            //    indiceFinal.Add(dt.Rows.Count - 1);
            //}
            //else
            //{
            //    int tamSegmento = dt.Rows.Count / numeroSegmentos;
            //    for (int i = 0; i < numeroSegmentos - 1; i++)
            //    {
            //        Hilos.Add(new Thread(Buscar));
            //        indiceInicial.Add(i * tamSegmento);
            //        indiceFinal.Add((i * tamSegmento) + tamSegmento - 1);
            //    }
            //    Hilos.Add(new Thread(Buscar));
            //    indiceInicial.Add(indiceFinal[indiceInicial.Count - 1]);
            //    indiceFinal.Add(dt.Rows.Count - 1);
            //}
            //for (int i = 0; i < numeroSegmentos; i++)
            //    Hilos[i].Start(i);

            Hilos.Add(new Thread(Buscar));
            indiceInicial.Add(0);
            indiceFinal.Add(dt.Rows.Count - 1);

            for (int i = 0; i < Hilos.Count; i++)
                Hilos[i].Start(i);

            while (HayHilosCorriendo())
            {

                if (!codigoEmpleado.Equals(""))
                {
                    String query2 = "select tra.ccve_empl, tra.CNOMBRE+' '+tra.CAPE_PATERNO+' '+tra.CAPE_MATERNO as nombre, ima.cimagen as imagen from " + bdNomina + "..CTL_TRABAJADORES tra inner join imagenes..CTL_TRAB_IMAGENES ima on tra.CCVE_EMPL = ima.CCVE_EMPL and tra.CCVE_NOMINA = ima.CCVE_NOMINA and tra.CCVE_TEMPORADA = ima.CCVE_TEMPORADA where tra.CCVE_NOMINA  = '" + ccve_nomina + "' and tra.CCVE_TEMPORADA = '" + ccve_temporada + "' and tra.CCVE_EMPL = '" + codigoEmpleado + "'";
                    DataTable dt2 = sql.EjecutarConsulta(query2);
                    try
                    {
                        TerminarHilos();
                    }
                    catch { }
                    String[] valores = new String[3];
                    valores[0] = dt2.Rows[0]["ccve_empl"].ToString();
                    valores[1] = dt2.Rows[0]["nombre"].ToString();
                    if (dt2.Rows[0]["imagen"] != DBNull.Value)
                    {
                        try
                        {
                            Bitmap imagen = Imagenes.BitArrayTOBitmap((byte[])dt2.Rows[0]["imagen"]);

                            Bitmap imagenComprimida = Converter.ComprimirImagen(imagen, 250, 200, System.Drawing.Imaging.ImageFormat.Jpeg);
                            String strOriginal = Converter.ByteArrayToString(Imagenes.BitmapTOBitArray(imagenComprimida));
                            valores[2] = strOriginal;
                        }
                        catch
                        {
                            valores[2] = null;
                        }
                    }
                    if (!esUnaPrueba)
                    {
                        Thread t = new Thread(RealizarRegistro);
                        t.Start();
                    }
                    sql.CerrarConexion();
                    return valores;
                }
            }
            sql.CerrarConexion();
            return null;
        }
        private void RealizarRegistro()
        {
            String query = "exec " + bdNomina + "..SPREGISTRAASISTENCIA '" + ccve_temporada + "','" + ccve_nomina + "','" + codigoEmpleado + "',0," + idHorario + "," + idChecador + "";
            SQLServer sql = (SQLServer)Application["dbAccesoReg" + idChecador];
            sql.AbrirConexion();
            Boolean sinChecar = true;
            int intentosChecado = 0;
            while (sinChecar)
            {
                try
                {
                    sql.EjecutarConsulta(query);
                    sinChecar = false;
                }
                catch (Exception ex)
                {
                    intentosChecado++;
                    if (intentosChecado == 3)
                    {
                        throw new Exception("Ha ocurrido un error al intentar realizar el registro de checado del empleado. Detalles: " + ex.Message);
                    }
                    Thread.Sleep(300);
                }
            }
            sql.CerrarConexion();
        }
        private Boolean HayHilosCorriendo()
        {
            foreach (Thread t in Hilos)
            {
                if (t.ThreadState == ThreadState.Running)
                    return true;
            }
            return false;
        }
        private void TerminarHilos()
        {
            foreach (Thread t in Hilos)
            {
                if (t.ThreadState == ThreadState.Running)
                    t.Abort();
            }
        }
        private void Buscar(Object indiceHilo)
        {
            int iInicial = indiceInicial[(int)indiceHilo];
            int iFinal = indiceFinal[(int)indiceHilo];


            for (int i = iInicial; i <= iFinal; i++)
            {
                if (dt.Rows[i]["CHUELLADIGITAL"] == DBNull.Value)
                    continue;
                byte[] huella = (Byte[])dt.Rows[i]["CHUELLADIGITAL"];

                MemoryStream ms = new MemoryStream(huella);

                Template template;
                try
                {
                    template = new Template(ms);
                    ver.Verify(patronEntrada, template, ref res);
                }
                catch { continue; }


                if (res.Verified)
                {
                    codigoEmpleado = dt.Rows[i]["CCVE_EMPL"].ToString();
                    break; // success
                }
            }
        }






        [WebMethod]
        public String[] HolaMundo(String nombre)
        {
            String[] hola = new string[3];
            hola[0] = "Hola mundo " + nombre;
            hola[1] = "Hola mundo " + nombre;
            hola[2] = "Hola mundo " + nombre;
            return hola;
        }
    }
}