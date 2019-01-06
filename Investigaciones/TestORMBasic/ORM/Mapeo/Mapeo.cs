using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using ORM.SQL;
using System.Collections;

namespace ORM.Mapeo
{
    public class Mapeo
    {
        public DBAcceso dbacceso;
        public Mapeo(DBAcceso dbacceso)
        {
            this.dbacceso = dbacceso;
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
                    if (!atributo.Name.Equals("id"))
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
                        campo.SetValue(obj, null);
                    }

                }
                FieldInfo acceso = obj.GetType().GetField("dbAcceso", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                acceso.SetValue(obj, dbacceso);
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
