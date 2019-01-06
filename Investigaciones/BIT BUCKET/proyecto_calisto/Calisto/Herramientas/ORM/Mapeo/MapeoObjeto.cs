using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Collections;
using Herramientas.SQL;
using Finisar.SQLite;
using System.Drawing;

namespace Herramientas.ORM.Mapeo
{
    public class MapeoObjeto
    {
        public iSQL sql;
        public MapeoObjeto(iSQL sql)
        {
            this.sql = sql;
        }
        private IList createGenericList(Type typeInList)
        {
            var genericListType = typeof(List<>).MakeGenericType(new[] { typeInList });
            return (IList)Activator.CreateInstance(genericListType);
        }
        public IList MapearDataTableAObjecto(Type tipo, DataTable dt)
        {
            FieldInfo[] atributos = tipo.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            IList listaT = createGenericList(tipo);

            foreach (DataRow dr in dt.Rows)
            {
                var obj = tipo
                     .GetConstructor(Type.EmptyTypes)
                     .Invoke(null);
                for (int j = 0; j < atributos.Length; j++)
                {
                    FieldInfo atributo = atributos[j];
                    if (!atributo.Name.Equals("id") && !atributo.Name.Equals("dtFechaCreacion") && !atributo.Name.Equals("dtFechaModificacion") && !atributo.Name.Equals("sUsuarioCreacion") && !atributo.Name.Equals("sUsuarioModificacion") && !atributo.Name.Equals("estaDeshabilitado"))
                    {
                        if (!atributo.Name.StartsWith("_") || atributo.FieldType.Name.Contains("List") || atributo.FieldType.Name.StartsWith("_"))
                            continue; // se ignoran las listas de objetos relacionados y los objetos relacionados
                    }
                    FieldInfo campo = obj.GetType().GetField(atributo.Name, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);

                    try
                    {
                        if (dr[atributo.Name] != DBNull.Value)
                        {
                            if (dr[atributo.Name].GetType() == typeof(byte[])) // atributos del tipo object (imagenes, archivos, huellas, etc)
                                campo.SetValue(obj, ArrayToObject((byte[])dr[atributo.Name]));
                            else
                                campo.SetValue(obj, ParseType(dr[atributo.Name], campo.FieldType));
                        }
                    }
                    catch (Exception ae)
                    {
                        if (atributo.FieldType == typeof(Bitmap))
                        {
                            campo.SetValue(obj, new Bitmap(new MemoryStream((byte[])dr[atributo.Name])));
                        }
                        else
                            campo.SetValue(obj, null);
                    }

                }
                //FieldInfo acceso = obj.GetType().GetField("sql", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                //acceso.SetValue(obj, sql);

                ((ObjetoBase)obj).SQL = sql;

                listaT.Add(obj);
            }
            return listaT;
        }

        public List<T> MapearDataTableAObjecto<T>(DataTable dt)
        {
            Type tipo = typeof(T);
            return (List<T>)MapearDataTableAObjecto(tipo, dt);
        }
        public Object ParseType(Object Value, Type type)
        {
            Object ConvertedValue = null;
            ConvertedValue = Convert.ChangeType(Value, type);
            return ConvertedValue;
        }

        public object ArrayToObject(byte[] array)
        {
            MemoryStream memoryStream = new MemoryStream(array);
            BinaryFormatter formatter = new BinaryFormatter();
            return formatter.Deserialize(memoryStream);
        }

        public byte[] ObjectToByteArray(Object obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, obj);
            return ms.ToArray();
        }
    }
}
