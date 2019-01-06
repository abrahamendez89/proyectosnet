using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ORM.SQL;
using System.Data;
using System.Reflection;
using System.Collections;
using Herramientas.Archivos;


namespace ORM
{
    public class ObjetoBase : IDisposable
    {
        #region atributos de administracion del objeto
        protected DBAcceso dbAcceso;
        protected ManejadorDB manejador;
        //public DBAcceso DBAccesoOBJ { get { return dbAcceso; } set { dbAcceso = value; } }
        //public ManejadorDB Manejador { get { return manejador; } set { manejador = value; } }
        protected List<String> AtributosCargadosPorPropiedad = new List<string>();
        protected List<String> AtributosCargadosPorPropiedadCopia = new List<string>();
        public static String UsuarioLogueado;
        #endregion

        #region Asignacion de valores de control de base de datos
        public void SetDBAcceso(DBAcceso dbAcceso)
        {
            this.dbAcceso = dbAcceso;
        }
        public DBAcceso GetDBAcceso()
        {
            return this.dbAcceso;
        }
        public void SetManejadorDB(ManejadorDB manejador)
        {
            this.manejador = manejador;
        }
        public ManejadorDB GetManejadorDB()
        {
            return this.manejador;
        }
        #endregion


        #region atributos basicos heredados
        protected long id;
        protected Boolean estaDeshabilitado;
        protected Boolean esModificado;
        public Boolean EsModificado 
        { 
            get { return esModificado; } 
            set 
            {
                if (esModificado == value)
                {
                    return;
                }
                esModificado = value;
                if (value) 
                    AgregarObjetoModificadoAManejador(); 
            } 
        }
        protected DateTime dtFechaCreacion;
        protected DateTime dtFechaModificacion;
        protected String sUsuarioCreacion;
        protected String sUsuarioModificacion;
        protected String sUsuarioResponsable;
        #endregion

        #region propiedades
        public Boolean EstaDeshabilitado
        {
            get { return estaDeshabilitado; }
            set { estaDeshabilitado = value; }
        }
        public String SUsuarioResponsable
        {
            get { return ObjetoBase.UsuarioLogueado; }
            set { ObjetoBase.UsuarioLogueado = value; }
        }
        public DateTime DtFechaCreacion
        {
            get { return dtFechaCreacion; }
        }

        public DateTime DtFechaModificacion
        {
            set { dtFechaModificacion = value; }
            get { return dtFechaModificacion; }
        }

        public String SUsuarioCreacion
        {
            get { return sUsuarioCreacion; }
        }


        public String SUsuarioModificacion
        {
            set { sUsuarioModificacion = value; }
        }

        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        #endregion
        #region agregado de objetos modificados a manejador
        private void AgregarObjetoModificadoAManejador()
        {
            if (manejador != null)
                manejador.AgregarObjetoModificado(this);
        }
        #endregion
        #region manejo de cache
        public void RestaurarUltimaCache()
        {
            if (AtributosCargadosPorPropiedadCopia.Count == 0) return;
            AtributosCargadosPorPropiedad.Clear();
            foreach (String atributo in AtributosCargadosPorPropiedadCopia)
                AtributosCargadosPorPropiedad.Add(atributo);
        }
        public void EliminarCache()
        {
            AtributosCargadosPorPropiedadCopia.Clear();
            foreach (String atributo in AtributosCargadosPorPropiedad)
                AtributosCargadosPorPropiedadCopia.Add(atributo);
            AtributosCargadosPorPropiedad.Clear();
        }
        #endregion
        #region metodo heredado para guardar
        public long Guardar()
        {
            try
            {
                Type tipo = this.GetType();
                if (id < 0)
                    return -1;
                if (this.esModificado)
                {
                    FieldInfo[] atributos = tipo.GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                    String consulta = "";
                    List<Object> valores = new List<object>();
                    //actualizando datos de auditoria
                    if (id == 0)
                    {
                        dtFechaCreacion = manejador.ObtenerFechaHoraServidor();
                        sUsuarioCreacion = ObjetoBase.UsuarioLogueado;
                    }
                    dtFechaModificacion = manejador.ObtenerFechaHoraServidor();
                    sUsuarioModificacion = ObjetoBase.UsuarioLogueado;

                    //-----------------------------
                    if (id != 0)
                    {
                        consulta = "update " + tipo.Name + " set ";
                        foreach (FieldInfo atributo in atributos)
                        {
                            if (atributo.Name.Equals("dtFechaCreacion") || atributo.Name.Equals("dtFechaModificacion") || atributo.Name.Equals("sUsuarioCreacion") || atributo.Name.Equals("sUsuarioModificacion") || atributo.Name.Equals("estaDeshabilitado"))
                            {
                                
                            }
                            else if (!atributo.Name.StartsWith("_") || atributo.FieldType.Name.Contains("List") || atributo.FieldType.Name.StartsWith("_"))
                                //|| atributo.Name.Equals("dtFechaCreacion") || atributo.Name.Equals("dtFechaModificacion") || atributo.Name.Equals("sUsuarioCreacion") || atributo.Name.Equals("sUsuarioModificacion"))
                                continue; // se ignoran las listas de objetos relacionados y los objetos relacionados
                            Object valorAtributo = atributo.GetValue(this);
                            if (valorAtributo != null)
                            {
                                consulta += atributo.Name + " = @" + atributo.Name + ", ";
                                valores.Add(valorAtributo);
                            }
                            else
                            {
                                consulta += atributo.Name + " = NULL, ";
                            }
                        }
                        consulta = consulta.Substring(0, consulta.Length - 2);
                        consulta += " where id = @id; select @id;";
                        valores.Add(id);
                    }
                    else
                    {
                        consulta = "insert " + tipo.Name + "(";
                        foreach (FieldInfo atributo in atributos)
                        {
                            if (atributo.Name.Equals("dtFechaCreacion") || atributo.Name.Equals("dtFechaModificacion") || atributo.Name.Equals("sUsuarioCreacion") || atributo.Name.Equals("sUsuarioModificacion") || atributo.Name.Equals("estaDeshabilitado"))
                            {
                            }
                            else if (!atributo.Name.StartsWith("_") || atributo.FieldType.Name.Contains("List") || atributo.FieldType.Name.StartsWith("_"))
                                //|| atributo.Name.Equals("dtFechaCreacion") || atributo.Name.Equals("dtFechaModificacion") || atributo.Name.Equals("sUsuarioCreacion") || atributo.Name.Equals("sUsuarioModificacion"))
                                continue; // se ignoran las listas de objetos relacionados y los objetos relacionados
                            consulta += atributo.Name + ", ";
                        }
                        consulta = consulta.Substring(0, consulta.Length - 2);
                        consulta += ") values(";
                        foreach (FieldInfo atributo in atributos)
                        {
                            if (atributo.Name.Equals("dtFechaCreacion") || atributo.Name.Equals("dtFechaModificacion") || atributo.Name.Equals("sUsuarioCreacion") || atributo.Name.Equals("sUsuarioModificacion") || atributo.Name.Equals("estaDeshabilitado"))
                            {
                            }
                            else if (!atributo.Name.StartsWith("_") || atributo.FieldType.Name.Contains("List") || atributo.FieldType.Name.StartsWith("_"))
                                continue; // se ignoran las listas de objetos relacionados y los objetos relacionados
                            Object valorAtributo = atributo.GetValue(this);
                            if (valorAtributo != null)
                            {
                                consulta += "@" + atributo.Name + ", ";
                                valores.Add(valorAtributo);
                            }
                            else
                            {
                                consulta += "NULL, ";
                            }
                        }
                        consulta = consulta.Substring(0, consulta.Length - 2);
                        consulta += "); select IDENT_CURRENT ('" + tipo.Name + "');";
                    }

                    DataTable dt = dbAcceso.EjecutarConsulta(consulta, valores);
                    id = Convert.ToInt64(dt.Rows[0][0]);
                    //Log.EscribirLog(consulta);
                }
                if (AtributosCargadosPorPropiedad.Count > 0)
                {
                    String consulta2 = "update " + tipo.Name + " set ";
                    List<Object> valores2 = new List<object>();
                    List<String> temp = new List<string>();
                    temp.AddRange(AtributosCargadosPorPropiedad);
                    Boolean guardoRElaciondo = false;
                    foreach (String atributo in temp)
                    {
                        FieldInfo atrib = tipo.GetField(atributo, BindingFlags.Instance | BindingFlags.NonPublic);
                        if (atrib.FieldType.Name.StartsWith("_"))//si entra entonces es un objeto relacionado y se tiene q considerar
                        {

                            FieldInfo campo = this.GetType().GetField(atributo, BindingFlags.NonPublic | BindingFlags.Instance);
                            ObjetoBase objRel = (ObjetoBase)campo.GetValue(this);
                            if (esModificado)
                            {
                                if (objRel != null)
                                {
                                    AtributosCargadosPorPropiedad.Remove(atributo);
                                    long idRel = objRel.id;
                                    if (objRel.esModificado)
                                    {
                                        objRel.SetDBAcceso(dbAcceso);
                                        objRel.manejador = manejador;
                                        idRel = objRel.Guardar();
                                    }
                                    if (idRel != 0)
                                    {
                                        guardoRElaciondo = true;
                                        consulta2 += atributo + " = @" + atributo + ", ";
                                        valores2.Add(idRel);
                                    }
                                }
                                else
                                {
                                    guardoRElaciondo = true;
                                    AtributosCargadosPorPropiedad.Remove(atributo);
                                    consulta2 += atributo + " = NULL, ";
                                }
                            }
                            else
                                AtributosCargadosPorPropiedad.Remove(atributo);
                        }
                    }
                    if (guardoRElaciondo)
                    {
                        consulta2 = consulta2.Substring(0, consulta2.Length - 2);
                        consulta2 += " where id = @id";
                        valores2.Add(id);
                        dbAcceso.EjecutarConsulta(consulta2, valores2);
                        //Log.EscribirLog(consulta2);
                    }
                }
                this.esModificado = false;

                if (AtributosCargadosPorPropiedad.Count > 0)
                {

                    List<Object> valores2 = new List<object>();
                    List<String> temp = new List<string>();
                    temp.AddRange(AtributosCargadosPorPropiedad);
                    foreach (String atributo in temp)
                    {
                        FieldInfo atrib = tipo.GetField(atributo, BindingFlags.Instance | BindingFlags.NonPublic);
                        if (atrib.FieldType.Name.Contains("List"))//si entra entonces es una lista relacionada y se tiene q considerar
                        {
                            AtributosCargadosPorPropiedad.Remove(atributo);

                            String nombreTabla = tipo.Name + "_X_" + atrib.FieldType.GetGenericArguments()[0].Name + "_" + atrib.Name;
                            String eliminacionConsulta = "delete " + nombreTabla + " where _contenedor = @id";
                            dbAcceso.EjecutarConsulta(eliminacionConsulta, new List<object>() { id });
                            //Log.EscribirLog(eliminacionConsulta);
                            IList listaObjetos = (IList)atrib.GetValue(this);
                            if (listaObjetos != null)
                            {
                                foreach (ObjetoBase objBaseLista in listaObjetos)
                                {
                                    long idTempLista = objBaseLista.id;
                                    if (objBaseLista.esModificado)
                                    {
                                        objBaseLista.SetDBAcceso(this.dbAcceso);
                                        objBaseLista.SetManejadorDB(manejador);
                                        idTempLista = objBaseLista.Guardar();
                                    }
                                    String consultaAgregadoRelacionado = "insert " + nombreTabla + " (_contenedor,_contenido,_fecha) values(@_contenedor, @_contenido, @_fecha);";
                                    dbAcceso.EjecutarConsulta(consultaAgregadoRelacionado, new List<object>() { id, idTempLista, DateTime.Now });
                                    //Log.EscribirLog(consultaAgregadoRelacionado);
                                }
                            }
                        }
                    }
                }
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
        #region borrado permanente de objeto
        public Boolean BorrarObjetoPermanentemente()
        {
            try
            {
                Type type = this.GetType();
                FieldInfo idf = type.GetField("id", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                if (id == 0)
                {
                    return true;
                }
                try
                {
                    String query = @"SELECT fk.name AS FK,
                                OBJECT_NAME(fk.parent_object_id) AS TableName,
                                COL_NAME(fc.parent_object_id,fc.parent_column_id) AS ColumnName,
                                OBJECT_NAME (fk.referenced_object_id) AS ReferenceTableName,
                                COL_NAME(fc.referenced_object_id, fc.referenced_column_id) AS ReferenceColumnName
                            FROM sys.foreign_keys AS fk
                            INNER JOIN sys.foreign_key_columns AS fc ON fk.OBJECT_ID = fc.constraint_object_id
                            where OBJECT_NAME (fk.referenced_object_id) = '" + type.Name + "'";

                    DataTable dt = dbAcceso.EjecutarConsulta(query);

                    foreach (DataRow dr in dt.Rows)
                    {
                        String nombreTabla = dr["TableName"].ToString();
                        String nombreCampo = dr["ColumnName"].ToString();
                        if (nombreTabla.ToUpper().Contains("_X__"))
                        {
                            String queryDelete = "delete " + nombreTabla + " where " + nombreCampo + " = @id";
                            dbAcceso.EjecutarConsulta(queryDelete, new List<object>() { id });
                        }
                        else
                        {
                            String queryDelete = "update " + nombreTabla + " set " + nombreCampo + " = null where " + nombreCampo + " = @id";
                            dbAcceso.EjecutarConsulta(queryDelete, new List<object>() { id });
                        }
                    }
                    String queryBorrarObjeto = "delete " + type.Name + " where id = @id";
                    dbAcceso.EjecutarConsulta(queryBorrarObjeto, new List<object>() { id });
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion
        #region cargar propiedades del objeto actual
        public T CargarPorID<T>(long id)
        {
            String consulta = "select * from " + typeof(T).Name + " where id = @id";
            //DataTable dtObjeto = DBAccesoOBJ.EjecutarConsulta(consulta, new List<Object>() { id });
            //T r = dbAcceso.MapearDataTableAObjecto<T>(dtObjeto)[0];

            T r = manejador.Cargar<T>(consulta, new List<object>() { id });

            return default(T);
        }
        public void setAtributoRelacionado(String nombreAtributo, Object valor)
        {
            FieldInfo atributoRel = this.GetType().GetField(nombreAtributo, BindingFlags.Instance | BindingFlags.NonPublic);
            if (!AtributosCargadosPorPropiedad.Contains(nombreAtributo))
                AtributosCargadosPorPropiedad.Add(nombreAtributo);
            atributoRel.SetValue(this, valor);
        }
        public T CargarAtributoRelacionado<T>(String nombreObjeto)
        {
            try
            {
                FieldInfo atributoRel = this.GetType().GetField(nombreObjeto, BindingFlags.Instance | BindingFlags.NonPublic);
                if (!AtributosCargadosPorPropiedad.Contains(nombreObjeto))
                    AtributosCargadosPorPropiedad.Add(nombreObjeto);
                else
                    return (T)atributoRel.GetValue(this);
                if (id == 0)
                    return default(T);

                T relacionado = default(T);
                String consulta = "select d.* from " + this.GetType().Name + " c inner join " + typeof(T).Name + " d on c." + nombreObjeto + " = d.id where c.id = @id";
                //DataTable resultado = DBAccesoOBJ.EjecutarConsulta(consulta, new List<Object>() { id });

                relacionado = manejador.Cargar<T>(consulta, new List<object>() { id });

                //if (resultado.Rows.Count > 0)
                //{
                //    relacionado = dbAcceso.MapearDataTableAObjecto<T>(resultado)[0];
                //}

                atributoRel.SetValue(this, relacionado);
                return relacionado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void SetListaRelacionados(String nombreAtributoLista, Object valor)
        {
            FieldInfo atributoRel = this.GetType().GetField(nombreAtributoLista, BindingFlags.Instance | BindingFlags.NonPublic);
            if (!AtributosCargadosPorPropiedad.Contains(nombreAtributoLista))
                AtributosCargadosPorPropiedad.Add(nombreAtributoLista);
            atributoRel.SetValue(this, valor);
        }

        public List<TipoObjectoLista> CargarListaRelacionados<TipoObjectoLista>(String nombreAtributoLista)
        {
            try
            {
                FieldInfo atributoRel = this.GetType().GetField(nombreAtributoLista, BindingFlags.Instance | BindingFlags.NonPublic);
                if (!AtributosCargadosPorPropiedad.Contains(nombreAtributoLista))
                    AtributosCargadosPorPropiedad.Add(nombreAtributoLista);
                else
                    return (List<TipoObjectoLista>)atributoRel.GetValue(this);
                if (id == 0)
                    return null;
                String nombreTabla = this.GetType().Name + "_X_" + typeof(TipoObjectoLista).Name + "_" + nombreAtributoLista;

                String consulta = "select b.* from " + this.GetType().Name + " a inner join " + nombreTabla + " rt on a.id = rt._contenedor inner join " + typeof(TipoObjectoLista).Name + " b on rt._contenido = b.id where a.id = @id order by rt._fecha asc"; // + idsRest;

                //DataTable dt2 = dbAcceso.EjecutarConsulta(consulta, new List<object>() { id });

                //List<TipoObjectoLista> relacionados = dbAcceso.MapearDataTableAObjecto<TipoObjectoLista>(dt2);
                List<TipoObjectoLista> relacionados = null;
                try
                {
                    relacionados = manejador.CargarLista<TipoObjectoLista>(consulta, new List<object>() { id });
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("_fecha"))
                    {
                        String agregarFecha = "alter table " + nombreTabla + " add _fecha datetime null";
                        manejador.EjecutarConsulta(agregarFecha);
                        relacionados = manejador.CargarLista<TipoObjectoLista>(consulta, new List<object>() { id });
                    }
                }
                atributoRel.SetValue(this, relacionados);

                return relacionados;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        //agregar un elemento a lista
        public void AgregadoRapidoAListaRelacionada(ObjetoBase objeto, String nombreLista)
        {
            try
            {
                Type tipo = this.GetType();
                String nombreTablaRelacion = tipo.Name + "_X_" + objeto.GetType().Name + "_" + nombreLista;
                objeto.dbAcceso = this.dbAcceso;
                long idObjetoLista = objeto.Guardar();
                String query = "insert into " + nombreTablaRelacion + "(_Contenedor, _Contenido) values (@_Contenedor, @_Contenido)";
                dbAcceso.EjecutarConsulta(query, new List<object>() { id, idObjetoLista });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #region creacion de copia
        public T CrearCopia<T>()
        {
            Type tipo = this.GetType();
            FieldInfo[] atributos = tipo.GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            var copia = tipo
                     .GetConstructor(Type.EmptyTypes)
                     .Invoke(null);

            foreach (FieldInfo atributo in atributos)
            {
                Object value = atributo.GetValue(this);
                atributo.SetValue(copia, value);
            }
            return (T)copia;
        }
        #endregion
        #region dispose de objeto
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Liberar recursos manejados
               
                Type tipo = this.GetType();
                FieldInfo[] atributos = tipo.GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

                foreach (FieldInfo atributo in atributos)
                {
                    if (atributo.FieldType.Name.Contains("List"))
                    {
                        IList lista = (IList)atributo.GetValue(this);
                        if (lista != null)
                            lista.Clear();
                        atributo.SetValue(this, null);
                    }
                    else if (atributo.FieldType.Name.StartsWith("_"))
                    {
                        ObjetoBase objB = (ObjetoBase)atributo.GetValue(this);
                        if (objB != null)
                            atributo.SetValue(this, null);
                    }
                    else
                    {
                        atributo.SetValue(this, null);
                    }
                }

            }
            dbAcceso = null;
            manejador = null;
            AtributosCargadosPorPropiedad.Clear();
            AtributosCargadosPorPropiedad = null;
            AtributosCargadosPorPropiedadCopia.Clear();
            AtributosCargadosPorPropiedadCopia = null;
            this.id = -1;
        }
        ~ObjetoBase()
        {
            Dispose(false);
        }
        #endregion
    }
}
