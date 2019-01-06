using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herramientas.SQL;
using System.Data;
using System.Reflection;
using Herramientas.Archivos;
using Herramientas.Cifrado;
using System.Collections;
using System.Threading;
using System.Windows.Threading;
using Herramientas.Conversiones;
using Herramientas.ORM.Memoria;
using Herramientas.ORM.Mapeo;

namespace Herramientas.ORM
{
    class PaqueteGuardado
    {
        public ObjetoBase ObjetoBaseGuardar { get; set; }
        public String Identificador { get; set; }
    }
    public class ManejadorDB
    {
        //private String ConexionGenerica = "data source = @servidorInstancia; initial catalog = @bd; user id = @usuario; password = @contraseña; Connection Lifetime=60;";
        //public String ConexionDefault;
        public List<String> ConexionesDisponibles = new List<String>();
        //private Variable variablesCONN = new Variable("conn.conf");
        private iSQL sql;
        private iSQL sqlInterno;
        public Boolean UsarAlmacenObjetos { get; set; }
        private List<ObjetoBase> objetosModificados = new List<ObjetoBase>();
        private List<ObjetoBase> objetosNuevos = new List<ObjetoBase>();
        private MapeoObjeto mapeo;
        //delegados asincronos
        public delegate void GuardadoTerminado(String identificador, String resultado, long id);
        public event GuardadoTerminado guardadoTerminado;
        public delegate void GuardadoError(Exception ex);
        public event GuardadoError guardadoError;
        public delegate void ErrorConexion(Exception ex);
        public event ErrorConexion errorConexion;
        public static Type TipoSQLDefault;
        public static String CadenaConexionDefault;
        //-------------------------
        public static void SetSQLDefault(Type tipoSQL, String cadenaConexion)
        {
            ManejadorDB.TipoSQLDefault = tipoSQL;
            ManejadorDB.CadenaConexionDefault = cadenaConexion;
        }
        public void CerrarConexion()
        {
            sql.CerrarConexion();
        }
        public void AbrirConexion()
        {
            sql.AbrirConexion();
        }
        public ManejadorDB()
        {
            sql = (iSQL)ManejadorDB.TipoSQLDefault
                     .GetConstructor(Type.EmptyTypes)
                     .Invoke(null);
            sql.ConfigurarConexion(ManejadorDB.CadenaConexionDefault);

            mapeo = new MapeoObjeto(sql);
            sqlInterno = sql.ObtenerNuevaInstancia(sql.ObtenerCadenaConexion());
        }
        public ManejadorDB(iSQL sqlConexion)
        {
            try
            {
                sql = sqlConexion;
                mapeo = new MapeoObjeto(sqlConexion);
                sqlInterno = sqlConexion.ObtenerNuevaInstancia(sqlConexion.ObtenerCadenaConexion());
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public T CrearObjeto<T>()
        {
            var obj = typeof(T)
                     .GetConstructor(Type.EmptyTypes)
                     .Invoke(null);

            ObjetoBase objBase = (ObjetoBase)obj;

            objBase.SQL = this.sql;
            objBase.Manejador = this;


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
            if (objetoBase.Id < 0)
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
                if (guardadoError == null)
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
                        objetoBase.SQL = this.sql;
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
                        objetoBase.SQL = this.sql;
                        objetoBase.SUsuarioResponsable = ObjetoBase.UsuarioLogueado;
                        objetoBase.Guardar();
                    }

                }
                objetosNuevos.Clear();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public void IniciarTransaccion()
        {
            sql.IniciarTransaccion();
        }
        public void DeshacerTransaccion()
        {
            sql.DeshacerTransaccion();
        }
        public void TerminarTransaccion()
        {
            sql.TerminarTransaccion();
        }
        public DataTable EjecutarConsulta(String consulta)
        {
            try
            {
                return EjecutarConsulta(consulta, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable EjecutarConsulta(String consulta, List<Object> valores)
        {
            try
            {
                return sql.EjecutarConsulta(consulta, valores);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void guardarAsincrono(Object objBase)
        {
            PaqueteGuardado p = (PaqueteGuardado)objBase;
            try
            {
                AlmacenObjetos.GuardarObjeto(p.ObjetoBaseGuardar);

                p.ObjetoBaseGuardar.SQL = this.sql;
                p.ObjetoBaseGuardar.SUsuarioResponsable = ObjetoBase.UsuarioLogueado;
                long idHilo = p.ObjetoBaseGuardar.Guardar();

                //if (guardadoTerminado == null)
                //    throw new Exception("Se requiere implementar el evento 'GuardadoTerminado'.");
                if (guardadoTerminado != null)
                {
                    guardadoTerminado(p.Identificador, "Guardado exitoso.", idHilo);
                }


            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
                if (guardadoTerminado != null)
                    guardadoTerminado(p.Identificador, "Error: " + ex.Message, -1);
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
                DateTime fechaHoraActual = sqlInterno.QueryParaObtenerLaHoraDelServer();
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
                objBase.Manejador = this;
                if (UsarAlmacenObjetos)
                    AlmacenObjetos.GuardarObjeto(objBase);

                objBase.SQL = this.sql;
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
                //UsarAlmacenObjetos = false; //deshabilitamos el almacen de objetos
                // se intenta usar la consulta modificada
                if (UsarAlmacenObjetos)
                {
                    try
                    {
                        //se traen los ids de los objetos y se marca la variable de control
                        resultado = this.sql.EjecutarConsulta(consultaIDS, valores);
                        TrajoIDS = true;
                    }
                    catch
                    {
                        //si ocurrio un error, y se debio a que la consulta estaba mal modificada, entonces
                        //se usa la consulta original.

                        resultado = this.sql.EjecutarConsulta(consulta, valores);

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
                            retorno.Add(objetoTemp);
                            //Log.EscribirLog("ALMACEN: RETORNADO [tipo: "+tipo.Name+", id: "+idT+"].");
                        }
                        else
                        {
                            idsRestantes.Add(idT);
                            retorno.Add(null);
                        }

                    }
                    if (idsRestantes.Count > 0)
                    {
                        String stridsRestantes = "";
                        //foreach (long idR in idsRestantes)
                        //{
                        //    stridsRestantes += "(" + idR + "), ";
                        //}

                        stridsRestantes = "(";
                        foreach (long idr in idsRestantes)
                        {
                            stridsRestantes += idr + ", ";
                        }

                        stridsRestantes = stridsRestantes.Substring(0, stridsRestantes.Length - 2);

                        stridsRestantes += ")";

//                        String consultaIdStr = @"select tabla.* from " + tipo.Name + @" as tabla
//                                                inner join (values " + stridsRestantes + @") as Valores(id) 
//                                                on tabla.id = Valores.id;";


                        String consultaIdStr = "Select * from " + tipo.Name + " where id in " + stridsRestantes;

                        DataTable resultado2 = sql.EjecutarConsulta(consultaIdStr); // id = @id", new List<object>() { idT });

                        if (resultado2.Rows.Count > 0)
                        {
                            IList retorTemp = mapeo.MapearDataTableAObjecto(tipo, resultado2);
                            int i = 0;
                            foreach (ObjetoBase o in retorTemp)
                            {
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
                    resultado = this.sql.EjecutarConsulta(consulta, valores);
                    //Log.EscribirLog("ALMACEN: ERROR Fallo al convertir la consulta.");
                    if (resultado.Rows.Count > 0)
                    {
                        retorno = mapeo.MapearDataTableAObjecto(tipo, resultado).Cast<ObjetoBase>().ToList();
                        foreach (ObjetoBase o in retorno)
                        {
                            o.Manejador = this;
                            AlmacenObjetos.GuardarObjeto(o);
                        }
                    }
                }

                if (retorno != null)
                {
                    foreach (ObjetoBase objBase in retorno)
                    {
                        objBase.Manejador = this;
                        objBase.SQL = sql;
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
