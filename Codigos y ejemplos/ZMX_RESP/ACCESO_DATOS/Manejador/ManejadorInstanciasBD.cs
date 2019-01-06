using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using ACCESO_DATOS.Anotaciones.Clase;
using ACCESO_DATOS.Conexiones;
using ACCESO_DATOS.Control;
using ACCESO_DATOS.Mapeo.Interfaces;
using ACCESO_DATOS.SuperClase;
using System.Diagnostics;

namespace ACCESO_DATOS.Manejador
{
    public class ManejadorInstanciasBD
    {
        public enum Ambiente
        {
            Debug = 0,
            Desarrollo = 1,
            Pruebas = 2,
            Preproduccion = 3,
            Produccion = 4,
            NoDefinido = 99
        }

        public static int ZMX_Ambiente { get; set; }

        public static Ambiente ZMX_AmbienteAPI { get; set; }
        public static String ZMX_Usuario { get; set; }

        private IClienteBD cliente;
        private static ClienteConfig.ClientesBD clienteElegido;
        private static IMapeoInsert mapeoInsert;
        private static IMapeoSelect mapeoSelect;
        private static IMapeoUpdate mapeoUpdate;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static String cadenaConexion;

        public static void ZMX_SetClienteConexion(ClienteConfig.ClientesBD clienteElegido, IMapeoInsert mapeoInsert, IMapeoSelect mapeoSelect, IMapeoUpdate mapeoUpdate, String cadenaConexion)
        {
            ManejadorInstanciasBD.clienteElegido = clienteElegido;
            ManejadorInstanciasBD.mapeoInsert = mapeoInsert;
            ManejadorInstanciasBD.mapeoSelect = mapeoSelect;
            ManejadorInstanciasBD.mapeoUpdate = mapeoUpdate;
            ManejadorInstanciasBD.cadenaConexion = cadenaConexion;
        }
        public IMapeoSelect GetMapeoSelect()
        {
            return ManejadorInstanciasBD.mapeoSelect;
        }
        public IMapeoInsert GetMapeoInsert()
        {
            return ManejadorInstanciasBD.mapeoInsert;
        }
        public IMapeoUpdate GetMapeoUpdate()
        {
            return ManejadorInstanciasBD.mapeoUpdate;
        }
        public T ZMX_ConsultarUnico<T>(String query) where T : CLASE_BASE
        {
            try
            {
                if (cliente == null)
                    throw new Exception("Es necesario abrir la conexión antes.");
                DataTable dt = cliente.EjecutarSelect(query);
                if (dt.Rows.Count > 0)
                {
                    T obj = mapeoSelect.ConvertirAObjeto<T>(dt.Rows[0]);
                    return obj;
                }
                else
                {
                    return default(T);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T ZMX_ConsultarUnico<T>(String query, Dictionary<String, Object> parametros) where T : CLASE_BASE
        {
            try
            {
                if (cliente == null)
                    throw new Exception("Es necesario abrir la conexión antes.");
                DataTable dt = cliente.EjecutarSelect(query, parametros);
                if (dt.Rows.Count > 0)
                {
                    T obj = mapeoSelect.ConvertirAObjeto<T>(dt.Rows[0]);
                    return obj;
                }
                else
                {
                    return default(T);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<T> ZMX_ConsultarListado<T>(String query) where T : CLASE_BASE
        {
            try
            {
                if (cliente == null)
                    throw new Exception("Es necesario abrir la conexión antes.");
                DataTable dt = cliente.EjecutarSelect(query);
                List<T> lsta = mapeoSelect.ConvertirAListaObjeto<T>(dt);
                return lsta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<T> ZMX_ConsultarListado<T>(String query, Dictionary<String, Object> parametros) where T : CLASE_BASE
        {
            try
            {
                if (cliente == null)
                    throw new Exception("Es necesario abrir la conexión antes.");
                DataTable dt = cliente.EjecutarSelect(query, parametros);
                List<T> lsta = mapeoSelect.ConvertirAListaObjeto<T>(dt);
                return lsta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void CrearID<T>(T obj) where T : CLASE_BASE
        {
            try
            {
                String idParcial = GeneracionID.CrearIDFormadoParcial<T>(obj);

                if(idParcial.Equals(""))
                {
                    //si el idParcial es vacio, entonces la tabla no lo requiere ya que podría ser un detalle
                    //solo se concluye el algoritmo
                    return;
                }

                ANC_IDFormado atributoID = typeof(T).GetCustomAttribute<ANC_IDFormado>(true);

                //se valida que solo sea un ID, sin q se componga de otras columnas
                if (typeof(T).GetCustomAttributes<ANC_IDFormadoParte>(true).ToList().Count == 0)
                {
                    //si no trae partes, se genera un consecutivo
                    String queryObtenSiguienteFolio = Estructura.ObtenConsecutivo<T>();
                    DataTable dtValor = cliente.EjecutarSelect(queryObtenSiguienteFolio);
                    if (dtValor.Rows.Count > 0 && dtValor.Rows[0][0] != DBNull.Value)
                    {
                        Int64 valor = Convert.ToInt64(dtValor.Rows[0][0]);
                        idParcial += valor;
                    }
                    else
                    {
                        Int64 valor = 1;
                        idParcial += valor;
                    }
                }
                else
                {
                    ANC_IDFormadoParte atributoConsecutivo = typeof(T).GetCustomAttributes<ANC_IDFormadoParte>(true).ToList().Where(x => x.EsConsecutivo).FirstOrDefault();
                    //si el atributo consecutivo es null, el id queda hasta este punto y se asigna
                    if (atributoConsecutivo == null)
                    {
                        obj.GetType().GetProperty(atributoID.Propiedad, BindingFlags.Instance | BindingFlags.Public).SetValue(obj, Convert.ToInt64(idParcial));
                        return;
                    }
                    String queryObtenSiguienteFolio = Estructura.ObtenConsecutivo<T>(idParcial);
                    DataTable dtValor = cliente.EjecutarSelect(queryObtenSiguienteFolio);

                    if (dtValor.Rows.Count > 0 && dtValor.Rows[0][0] != DBNull.Value)
                    {
                        Int64 valor = Convert.ToInt64(dtValor.Rows[0][0]);
                        idParcial += valor.ToString(GeneracionID.CrearFormatoToString(atributoConsecutivo.Digitos));
                    }
                    else
                    {
                        Int64 valor = 1;
                        idParcial += valor.ToString(GeneracionID.CrearFormatoToString(atributoConsecutivo.Digitos));
                    }
                }
                obj.GetType().GetProperty(atributoID.Propiedad, BindingFlags.Instance | BindingFlags.Public).SetValue(obj, Convert.ToInt64(idParcial));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public T ZMX_Guardar<T>(T obj) where T : CLASE_BASE
        {
            try
            {
                //antes de guardar, se validan los datos con los validadores
                ValidacionesPrevioEnvioBD.ValidaNullables<T>(obj);
                ValidacionesPrevioEnvioBD.ValidaPrecisionNumerica<T>(obj);
                ValidacionesPrevioEnvioBD.ValidaStrings<T>(obj);
                ValidacionesPrevioEnvioBD.ValidaTieneLlavePrimariaCorrecta<T>(obj);


                if (((CLASE_BASE)obj).ULTIMA_ACT == 0)
                {
                    //es un registro nuevo, por lo que se inserta como nuevo
                    ((CLASE_BASE)obj).ULTIMA_ACT = 1;
                    ((CLASE_BASE)obj).USUARIO_CREACION = ZMX_Usuario;
                    ((CLASE_BASE)obj).USUREG = ZMX_Usuario;
                    ((CLASE_BASE)obj).FECHA_CREACION = DateTime.Now;
                    ((CLASE_BASE)obj).FECHA_MODIFICACION = DateTime.Now;
                    //aqui debemos verificar si la clase tiene un id formado por formula y lo asignamos
                    CrearID<T>(obj);

                    String queryInsert = mapeoInsert.Convertir<T>(obj);

                    if (Estructura.ContienePropiedadesByteArray<T>())
                    {
                        Dictionary<String, Object> parametrosByteArray = Estructura.ObtenerDiccionarioPropiedadesByteArray<T>(obj);
                        int afectados = cliente.EjecutarInsert(queryInsert, parametrosByteArray);
                    }
                    else
                    {
                        int afectados = cliente.EjecutarInsert(queryInsert);
                    }

                    String queryPorId = mapeoSelect.ObtenerQueryConsultaPorIdentificador<T>(obj);
                    DataTable dt = cliente.EjecutarSelect(queryPorId);
                    obj = mapeoSelect.ConvertirAObjeto<T>(dt.Rows[0]);
                }
                else
                {
                    //es una modificacion, se actualiza las versiones
                    //es un registro nuevo, por lo que se inserta como nuevo
                    ((CLASE_BASE)obj).ULTIMA_ACT++;
                    Concurrencia.ValidaVersionConcurrencia<T>(obj, cliente);
                    ((CLASE_BASE)obj).USUREG = ZMX_Usuario;
                    ((CLASE_BASE)obj).FECHA_MODIFICACION = DateTime.Now;
                    ((CLASE_BASE)obj).ES_NUEVO = false;
                    //guardamos el objeto con un update
                    String queryUpdate = mapeoUpdate.Convertir<T>(obj);

                    if (Estructura.ContienePropiedadesByteArray<T>())
                    {
                        Dictionary<String, Object> parametrosByteArray = Estructura.ObtenerDiccionarioPropiedadesByteArray<T>(obj);
                        int afectados = cliente.EjecutarUpdate(queryUpdate, parametrosByteArray);
                    }
                    else
                    {
                        int afectados = cliente.EjecutarUpdate(queryUpdate);
                        if(afectados == 0)
                        {
                            throw new Exception("El objeto que se intenta guardar tuvo cambios en los valores que componen su identificación (Llave primaria, indices únicos, etc), por lo que no se pudo actualizar, favor de realizar la correción lógica necesaria. \n\nQuery update:\n\n"+ queryUpdate+"\n\nPara guardar este objeto como uno nuevo, cambia el valor de ULTIMA_ACT a 0.");
                        }
                    }
                    String queryPorId = mapeoSelect.ObtenerQueryConsultaPorIdentificador<T>(obj);
                    DataTable dt = cliente.EjecutarSelect(queryPorId);
                    obj = mapeoSelect.ConvertirAObjeto<T>(dt.Rows[0]);
                }

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ZMX_EjecutarSelectQuery(String query)
        {
            return cliente.EjecutarSelect(query);
        }
        public DataTable ZMX_EjecutarSelectQuery(String query, Dictionary<String, Object> parametros)
        {
            return cliente.EjecutarSelect(query, parametros);
        }
        public int ZMX_EjecutarQuery(String query)
        {
            return cliente.EjecutaInsertUpdate(query);
        }
        public List<T> ZMX_Guardar<T>(List<T> lista) where T : CLASE_BASE
        {
            try
            {
                if (cliente == null)
                    throw new Exception("Es necesario abrir la conexión antes.");
                //antes de guardar, se validan los datos con los validadores
                foreach (T obj in lista)
                {
                    ValidacionesPrevioEnvioBD.ValidaNullables<T>(obj);
                    ValidacionesPrevioEnvioBD.ValidaPrecisionNumerica<T>(obj);
                    ValidacionesPrevioEnvioBD.ValidaStrings<T>(obj);
                    ValidacionesPrevioEnvioBD.ValidaTieneLlavePrimariaCorrecta<T>(obj);
                }

                List<T> objetosTotales = new List<T>();
                List<T> objetosUpdate = new List<T>();
                List<T> objetosInsert = new List<T>();
                List<T> retorno = new List<T>();
                foreach (T obj in lista)
                {

                    retorno.Add(ZMX_Guardar<T>(obj));

                    //////<NOTA>SE POSPONE FUNCIONALIDAD POR INVESTIGACION</NOTA>
                    //////if (((CLASE_BASE)obj).ULTIMA_ACT == 0)
                    //////{
                    //////    ////es un registro nuevo, por lo que se inserta como nuevo y de forma individual (por la generacion de los consecutivos)
                    //////    T ob = ZMX_Guardar<T>(obj);
                    //////    objetosInsert.Add(ob);
                    //////    objetosTotales.Add(ob);
                    //////}
                    //////else
                    //////{
                    //////    //es una modificacion, se actualiza las versiones
                    //////    //es un registro nuevo, por lo que se inserta como nuevo
                    //////    ((CLASE_BASE)obj).ULTIMA_ACT++;
                    //////    Concurrencia.ValidaVersionConcurrencia<T>(obj, cliente);
                    //////    ((CLASE_BASE)obj).USUREG = ZMX_Usuario;
                    //////    ((CLASE_BASE)obj).FECHA_MODIFICACION = DateTime.Now;
                    //////    ((CLASE_BASE)obj).ES_NUEVO = false;

                    //////    objetosUpdate.Add(obj);
                    //////    objetosTotales.Add(obj);
                    //////}
                }

                //guardamos el listado de objetos por lotes (solamente los update, los nuevos se insertan uno por uno 
                //debido al consecutivo
                /// <NOTA> por investigación se pospone esta funcionalidad, por el momento solo se actualizaran de forma individual</NOTA>
                //////String instruccionSQL = "BEGIN\r\n @SQL END;";
                //////String instrucciones = "";
                //////Dictionary<String, Object> parametrosByteArrayTotales = new Dictionary<string, Object>();
                //////int indice = 0;
                //////foreach (T obj in objetosUpdate)
                //////{
                //////    //se verifica que si el objeto trae propiedades de byte[]
                //////    if (Estructura.ContienePropiedadesByteArray<T>())
                //////    {
                //////        Dictionary<String, Object> parametrosByteArray = Estructura.ObtenerDiccionarioPropiedadesByteArray<T>(obj);
                //////        String instruccion = mapeoUpdate.Convertir<T>(obj) + "; ";
                //////        foreach (String llave in parametrosByteArray.Keys)
                //////        {
                //////            //se hacen transformaciones de las llaves, para poder sustituir los parametros donde van correctamente.
                //////            String llaveNueva = llave + "_" + indice;
                //////            //se agrega la llave transformada al array general con su valor
                //////            parametrosByteArrayTotales.Add(llaveNueva, parametrosByteArray[llave]);
                //////            //se hace la transformacion del parametro en el query para que correspondan con la transformacion.
                //////            instruccion = instruccion.Replace(llave, llaveNueva);
                //////        }
                //////        //finalmente se concatena la instruccion
                //////        instrucciones += instruccion;
                //////        //se incrementa el indice en 1 para que este listo para el proximo objeto
                //////        indice++;
                //////    }
                //////    else
                //////    {
                //////        instrucciones += mapeoUpdate.Convertir<T>(obj) + "; \r\n";
                //////    }
                //////}
                //////if (objetosUpdate.Count > 0)
                //////{
                //////    //si hay objetos a actualizar, se ejecuta la instruccion
                //////    instruccionSQL = instruccionSQL.Replace("@SQL", instrucciones);
                //////    //se actualizan los objetos
                //////    cliente.EjecutarUpdate(instruccionSQL, parametrosByteArrayTotales);
                //////}
                ////////se vuelven a consultar los registros con los datos ya actualizados.
                //////String querysPorID = "SELECT * FROM " + Estructura.ObtenNombreTabla<T>() + " WHERE (@CONDICIONES)";
                //////String condiciones = "";
                //////foreach (T obj in objetosTotales)
                //////{
                //////    condiciones += "(" + Estructura.ObtenCondicionBusquedaWhere<T>(obj) + ") OR ";
                //////}
                //////condiciones = condiciones.Substring(0, condiciones.Length - 4);
                //////querysPorID = querysPorID.Replace("@CONDICIONES", condiciones);
                //////DataTable dt = cliente.EjecutarSelect(querysPorID);
                //////lista = mapeoSelect.ConvertirAListaObjeto<T>(dt);
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ZMX_AbrirConexion()
        {
            try
            {
                if (cliente == null)
                {
                    if (clienteElegido == ClienteConfig.ClientesBD.Oracle)
                    {
                        cliente = new ClienteBDOracle();
                        cliente.AsignarCadenaConexion(cadenaConexion);
                    }
                }
                cliente.AbrirConexion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ZMX_CerrarConexion()
        {
            try
            {
                if (cliente == null)
                {
                    return;
                    //throw new Exception("Es necesario abrir la conexión antes.");
                }
                cliente.CerrarConexion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ZMX_IniciarTransaccion()
        {
            try
            {
                if (cliente == null)
                {
                    throw new Exception("Es necesario abrir la conexión antes.");
                }
                cliente.IniciarTransaccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ZMX_TerminarTransaccion()
        {
            try
            {
                if (cliente == null)
                {
                    throw new Exception("Es necesario abrir la conexión antes.");
                }
                cliente.TerminarTransaccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ZMX_DeshacerTransaccion()
        {
            try
            {
                if (cliente == null)
                {
                    return;
                    //throw new Exception("Es necesario abrir la conexión antes.");
                }
                cliente.DeshacerTransaccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
