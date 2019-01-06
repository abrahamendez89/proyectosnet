using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ORM.SQL;
using System.Data;
using System.Reflection;
using Herramientas.Archivos;
using Herramientas.Cifrado;
using System.Collections;
using System.Threading;
using Herramientas.Conversiones;
using ORM.Memoria;

namespace ORM.SQL
{
    class PaqueteGuardado
    {
        public ObjetoBase ObjetoBaseGuardar { get; set; }
        public String Identificador { get; set; }
    }
    public class ManejadorDB
    {
        private String ConexionGenerica = "data source = @servidorInstancia; initial catalog = @bd; user id = @usuario; password = @contraseña; Connection Lifetime=60;";
        public String ConexionDefault;
        public List<String> ConexionesDisponibles = new List<String>();
        private Variable variablesCONN = new Variable("conn.conf");
        private DBAcceso dbAcceso;
        public Boolean UsarAlmacenObjetos { get; set; }
        private List<ObjetoBase> objetosModificados = new List<ObjetoBase>();
        private List<ObjetoBase> objetosNuevos = new List<ObjetoBase>();

        //delegados asincronos
        public delegate void GuardadoTerminado(String identificador, String resultado, long id);
        public event GuardadoTerminado guardadoTerminado;
        public delegate void GuardadoError(Exception ex);
        public event GuardadoError guardadoError;
        //-------------------------

        public ManejadorDB(String cadenaConexion)
        {
            try
            {
                CargarConexiones();
                dbAcceso = new DBAcceso(cadenaConexion);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public T CrearObjeto<T>()
        {
            var obj = typeof(T)
                     .GetConstructor(Type.EmptyTypes)
                     .Invoke(null);

            ObjetoBase objBase = (ObjetoBase)obj;

            objBase.SetDBAcceso(this.dbAcceso);
            objBase.SetManejadorDB(this);
            

            return (T)obj;

        }
        private Boolean existeObjetoModificado(ObjetoBase objAgregado)
        {
            foreach (ObjetoBase obj in objetosModificados)
            {
                Type t = obj.GetType();
                Type t2 = objAgregado.GetType();

                if (t == t2 && objAgregado.Id == obj.Id)
                    return true;
            }
            return false;
        }
        public void AgregarObjetoModificado(ObjetoBase objetoBase)
        {
            if (objetoBase.Id <0)
            {
                return;
            }
            else if (objetoBase.Id == 0)
            {
                if (!objetosNuevos.Contains(objetoBase))
                {
                    objetosNuevos.Add(objetoBase);
                }
            }
            else if (!existeObjetoModificado(objetoBase)) 
            {
                objetosModificados.Add(objetoBase);
            }
        }
        private void guardarObjetosModificadosAsincrono(Object obj)
        {
            try
            {
                GuardarObjetosModificados();
                if (guardadoTerminado == null)
                    throw new Exception("Se requiere implementar el evento 'GuardadoTerminado' para mostrar resultados del manejador.");
                guardadoTerminado(obj.ToString(), "Guardado Exitoso.", 0);

            }
            catch (Exception ex) 
            { 
                if(guardadoError == null)
                    throw new Exception("Se requiere implementar el evento 'GuardadoError' para mostrar resultados de errores asincronos del manejador.");
                guardadoError(ex);
            }
        }
        public void GuardarObjetosModificadosAsincrono(String identificador)
        {
            hiloAsincronoTodos = new Thread(guardarObjetosModificadosAsincrono);
            hiloAsincronoTodos.Start(identificador);
        }
        Thread hiloAsincronoTodos;
        public void GuardarObjetosModificados()
        {
            try
            {
                //primero se guardan los objetos modificados
                foreach (ObjetoBase objetoBase in objetosModificados)
                {
                    if (objetoBase.Id >= 0)
                    {
                        objetoBase.SetDBAcceso(this.dbAcceso);
                        objetoBase.SUsuarioResponsable = ObjetoBase.UsuarioLogueado;
                        objetoBase.Guardar();
                    }
                }
                objetosModificados.Clear();
                //despues se guardan los objetos nuevos
                foreach (ObjetoBase objetoBase in objetosNuevos)
                {
                    if (objetoBase.Id >= 0)
                    {
                        objetoBase.SetDBAcceso(this.dbAcceso);
                        objetoBase.SUsuarioResponsable = ObjetoBase.UsuarioLogueado;
                        objetoBase.Guardar();
                    }

                }
                objetosNuevos.Clear();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        private void CargarConexiones()
        {
            String servidorInstancia = CifradoMD5.DesencriptarTexto(variablesCONN.ObtenerValorVariable<String>("ServidorInstancia"));
            String baseDatos = CifradoMD5.DesencriptarTexto(variablesCONN.ObtenerValorVariable<String>("BaseDeDatos"));
            String usuario = CifradoMD5.DesencriptarTexto(variablesCONN.ObtenerValorVariable<String>("Usuario"));
            String contraseña = CifradoMD5.DesencriptarTexto(variablesCONN.ObtenerValorVariable<String>("Contraseña"));

            ConexionDefault = ConexionGenerica.Replace("@servidorInstancia", servidorInstancia).Replace("@bd", baseDatos).Replace("@usuario", usuario).Replace("@contraseña", contraseña);

        }
        public ManejadorDB()
        {
            try
            {
                CargarConexiones();
                dbAcceso = new DBAcceso(ConexionDefault);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public void IniciarTransaccion()
        {
            dbAcceso.IniciarTransaccion();
        }
        public void DeshacerTransaccion()
        {
            dbAcceso.DeshacerTransaccion();
        }
        public void TerminarTransaccion()
        {
            dbAcceso.TerminarTransaccion();
        }
        public DataTable EjecutarConsulta(String consulta)
        {
            try
            {
                return EjecutarConsulta(consulta, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public DataTable EjecutarConsulta(String consulta, List<Object> valores)
        {
            try
            {
                return dbAcceso.EjecutarConsulta(consulta, valores);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void guardarAsincrono(Object objBase)
        {
            PaqueteGuardado p = (PaqueteGuardado)objBase;
            try
            {
                AlmacenObjetos.GuardarObjeto(p.ObjetoBaseGuardar);

                p.ObjetoBaseGuardar.SetDBAcceso(this.dbAcceso);
                p.ObjetoBaseGuardar.SUsuarioResponsable = ObjetoBase.UsuarioLogueado;
                long idHilo = p.ObjetoBaseGuardar.Guardar();

                if (guardadoTerminado == null)
                    throw new Exception("Se requiere implementar el evento 'GuardadoTerminado'.");
                else
                {
                    guardadoTerminado(p.Identificador,"Guardado exitoso.", idHilo);
                }


            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
                guardadoTerminado(p.Identificador,"Error: "+ex.Message, -1);
            }
        }
        Thread asincrono;
        public void GuardarAsincrono(String identificador, ObjetoBase objBase)
        {
            PaqueteGuardado p = new PaqueteGuardado();
            p.ObjetoBaseGuardar = objBase;
            p.Identificador = identificador;
            asincrono = new Thread(guardarAsincrono);
            asincrono.Start((Object)p);
        }
        public DateTime ObtenerFechaHoraServidor()
        {
            try
            {
                String query = "select getdate() as fechaHoraServidor";
                DataTable dt = EjecutarConsulta(query);
                DateTime fechaHoraActual = (DateTime)Converter.ParseType(dt.Rows[0]["fechaHoraServidor"], typeof(DateTime));
                return fechaHoraActual;
            }
            catch
            {
                return DateTime.Now;
            }
        }
        public long Guardar(ObjetoBase objBase)
        {
            try
            {
                objBase.SetManejadorDB(this);
                AlmacenObjetos.GuardarObjeto(objBase);
                
                objBase.SetDBAcceso(this.dbAcceso);
                objBase.SUsuarioResponsable = ObjetoBase.UsuarioLogueado;
                return objBase.Guardar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public T Cargar<T>(String consulta)
        {
            try
            {
                return Cargar<T>(consulta, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public T Cargar<T>(String consulta, List<Object> valores)
        {
            try
            {
                DataTable resultado;
                var retorno = default(T);
                //resultado = this.dbAcceso.EjecutarConsulta(consulta, valores);
                //if (resultado.Rows.Count > 0)
                //    retorno = dbAcceso.MapearDataTableAObjecto<T>(resultado)[0];

                List<T> resLista = CargarLista<T>(consulta, valores);

                if (resLista != null && resLista.Count > 0)
                    retorno = resLista[0];

                return retorno;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        private String ModificarConsultaParaAlmacen(String consulta)
        {
            if (consulta.Contains(".* ") || consulta.Contains(" * "))
            {
                return consulta.Replace("*", "id");
            }

            return consulta;
        }
        public List<ObjetoBase> Cargar(Type tipo, String consulta, List<Object> valores)
        {
            //--------------------------------------------------------------------------------------
            //--------------------------------------------------------------------------------------
            //AQUI SE TIENE Q BUSCAR LA SEPARACION DE BUSQUEDAS ENTRE ALMACEN DE OBJETOS Y BASE DE DATOS
            //--------------------------------------------------------------------------------------
            //--------------------------------------------------------------------------------------
            try
            {
                DataTable resultado = null;
                List<ObjetoBase> retorno = null;


                //la consulta se cambia, para q solamente traiga IDS de la base de datos.
                String consultaIDS = ModificarConsultaParaAlmacen(consulta);
                Boolean TrajoIDS = false;
                // se intenta usar la consulta modificada
                if (UsarAlmacenObjetos)
                {
                    try
                    {
                        //se traen los ids de los objetos y se marca la variable de control
                        resultado = this.dbAcceso.EjecutarConsulta(consultaIDS, valores);
                        TrajoIDS = true;
                    }
                    catch
                    {
                        //si ocurrio un error, y se debio a que la consulta estaba mal modificada, entonces
                        //se usa la consulta original.

                        resultado = this.dbAcceso.EjecutarConsulta(consulta, valores);

                    }
                }
                if (TrajoIDS)
                {
                    retorno = new List<ObjetoBase>();
                    List<long> idsRestantes = new List<long>();
                    ObjetoBase objetoTemp = null;
                    foreach (DataRow dr in resultado.Rows)
                    {
                        long idT = Convert.ToInt64(dr["id"]);
                        objetoTemp = AlmacenObjetos.ObtenerObjeto(tipo, idT);
                        if (objetoTemp != null)
                        {
                            objetoTemp.SetManejadorDB(this);
                            retorno.Add(objetoTemp);
                            //Log.EscribirLog("ALMACEN: RETORNADO [tipo: "+tipo.Name+", id: "+idT+"].");
                        }
                        else
                        {
                            idsRestantes.Add(idT);
                            retorno.Add(null);
                        }

                    }
                    if(idsRestantes.Count > 0)
                    {
                        String stridsRestantes = "";
                        foreach (long idR in idsRestantes)
                        {
                            stridsRestantes += "("+idR + "), ";
                        }
                        stridsRestantes = stridsRestantes.Substring(0, stridsRestantes.Length - 2);
                        //String consultaIdStr = "select * from " + tipo.Name + " where id in " + stridsRestantes;

                        String consultaIdStr = @"select tabla.* from "+tipo.Name+@" as tabla
                                                inner join (values "+stridsRestantes+@") as Valores(id) 
                                                on tabla.id = Valores.id;";

                        DataTable resultado2 = dbAcceso.EjecutarConsulta(consultaIdStr); // id = @id", new List<object>() { idT });

                        if (resultado2.Rows.Count > 0)
                        {
                            IList retorTemp = dbAcceso.MapearDataTableAObjecto(tipo, resultado2);
                            int i = 0;
                            foreach (ObjetoBase o in retorTemp)
                            {
                                o.SetManejadorDB(this);
                                AlmacenObjetos.GuardarObjeto(o);

                                for (; i < retorno.Count; i++)
                                {
                                    if (retorno[i] == null)
                                    {
                                        retorno[i] = o;
                                        break;
                                    }
                                }

                                //retorno.Add(o);
                                //Log.EscribirLog("ALMACEN: AGREGADO [tipo: " + tipo.Name + ", id: " + idT + "].");
                            }
                        }
                    }
                }
                else
                {
                    resultado = this.dbAcceso.EjecutarConsulta(consulta, valores);
                    //Log.EscribirLog("ALMACEN: ERROR Fallo al convertir la consulta.");
                    if (resultado.Rows.Count > 0)
                    {
                        retorno = dbAcceso.MapearDataTableAObjecto(tipo, resultado).Cast<ObjetoBase>().ToList();
                        foreach (ObjetoBase o in retorno)
                        {
                            o.SetManejadorDB(this);
                            AlmacenObjetos.GuardarObjeto(o);
                        }
                    }
                }
                //resultado = this.dbAcceso.EjecutarConsulta(consulta, valores);

                //if (resultado.Rows.Count > 0)
                //{
                //    retorno = dbAcceso.MapearDataTableAObjecto(tipo, resultado);
                //    foreach (ObjetoBase o in retorno)
                //    {
                //        AlmacenObjetos.GuardarObjeto(o);
                //    }
                //}

                if (retorno == null)
                    return null;
                return retorno.Cast<ObjetoBase>().ToList();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public List<T> CargarLista<T>(String consulta)
        {
            try
            {
                return CargarLista<T>(consulta, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public List<T> CargarLista<T>(String consulta, List<Object> valores)
        {
            try
            {
                List<ObjetoBase> listaResultado = Cargar(typeof(T), consulta, valores);

                List<T> listaT = null;

                if (listaResultado != null)
                    listaT = (listaResultado as IEnumerable<ObjetoBase>).Cast<T>().ToList();
                return listaT;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
