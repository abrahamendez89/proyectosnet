using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace Utilerias.Utilerias
{
    public class Variable
    {
        //private String rutaArchivo;
        //private Dictionary<String, String> diccionario = new Dictionary<string, string>();
        //public Variable(String rutaArchivo)
        //{
        //    this.rutaArchivo = rutaArchivo;
        //    LeerArchivo();
        //}
        //public DataTable ObtenerDataTableConVariablesYValores()
        //{
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("Variable");
        //    dt.Columns.Add("Valor");

        //    foreach (String key in diccionario.Keys)
        //    {
        //        DataRow dr = dt.NewRow();
        //        dr["Variable"] = key;
        //        dr["Valor"] = diccionario[key];
        //        dt.Rows.Add(dr);
        //    }

        //    return dt;
        //}
        //public void LeerArchivo()
        //{
        //    StreamReader objReader = null;
        //    diccionario.Clear();
        //    try
        //    {
        //        objReader = new StreamReader(rutaArchivo);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    string sLine = "";

        //    while (sLine != null)
        //    {
        //        sLine = objReader.ReadLine();
        //        if (sLine != null)
        //        {
        //            if (!sLine.StartsWith(@"//") && sLine.Contains(" = "))
        //            {
        //                String[] variable = obtenerValoresSeparados(sLine);
        //                if (!diccionario.ContainsKey(variable[0]))
        //                {
        //                    diccionario.Add(variable[0].Trim(), variable[1].Trim());
        //                }
                        
        //            }
        //        }
        //    }
        //    objReader.Close();
        //}
        //private String[] obtenerValoresSeparados(String linea)
        //{
        //    String[] retorno = new string[2];
        //    Boolean terminoVariable = false;
        //    for (int i = 0; i < linea.Length; i++)
        //    {
        //        if (linea[i] == '=' && !terminoVariable)
        //        {
        //            terminoVariable = true;
        //            continue;
        //        }

        //        if(!terminoVariable)
        //            retorno[0] += linea[i];
        //        else
        //            retorno[1] += linea[i];
        //    }
        //    retorno[0] = retorno[0].Trim();
        //    retorno[1] = retorno[1].Trim();
        //    return retorno;
        //}
        //public T ObtenerValorVariable<T>(String variable)
        //{
        //    if (diccionario.ContainsKey(variable))
        //    {
        //        try
        //        {
        //            return (T)Convert.ChangeType(diccionario[variable], typeof(T));
        //        }
        //        catch (Exception ex)
        //        {
        //            return default(T);
        //        }
        //    }
        //    else
        //        return default(T);
        //}
        //public void ActualizarArchivo()
        //{
        //    StreamWriter sw = new StreamWriter(rutaArchivo);

        //    foreach (String variable in diccionario.Keys)
        //    {
        //        sw.WriteLine(variable+" = "+diccionario[variable]);
        //    }
        //    sw.Close();
        //}
        //public void BorrarVariables()
        //{
        //    diccionario.Clear();
        //    StreamWriter sw = new StreamWriter(rutaArchivo);
        //    sw.Close();
        //}
        //public void GuardarValorVariable(String variable, String valor)
        //{
        //    LeerArchivo();
        //    if (diccionario.ContainsKey(variable))
        //    {
        //        diccionario[variable] = valor;
        //    }
        //    else
        //    {
        //        diccionario.Add(variable, valor);
        //    }
        //    ActualizarArchivo();
        //}
        private String rutaArchivo;
        private Dictionary<String, String> diccionario = new Dictionary<string, string>();
        public Variable(String rutaArchivo)
        {
            this.rutaArchivo = rutaArchivo;
            LeerArchivo();
        }
        public DataTable ObtenerDataTableConVariablesYValores()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Variable");
            dt.Columns.Add("Valor");

            foreach (String key in diccionario.Keys)
            {
                DataRow dr = dt.NewRow();
                dr["Variable"] = key;
                dr["Valor"] = diccionario[key];
                dt.Rows.Add(dr);
            }

            return dt;
        }
        public void LeerArchivo()
        {
            StreamReader objReader = null;
            diccionario.Clear();
            try
            {
                objReader = new StreamReader(rutaArchivo);
            }
            catch (Exception ex)
            {
                StreamWriter sw = new StreamWriter(rutaArchivo);
                sw.WriteLine("");
                sw.Flush();
                sw.Close();
                objReader = new StreamReader(rutaArchivo);
                //throw new Exception(ex.Message);
            }
            string sLine = "";

            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null)
                {
                    if (!sLine.StartsWith(@"//") && sLine.Contains(" = "))
                    {
                        String[] variable = obtenerValoresSeparados(sLine);
                        if (!diccionario.ContainsKey(variable[0]))
                        {
                            diccionario.Add(variable[0].Trim(), variable[1].Trim());
                        }

                    }
                }
            }
            objReader.Close();
        }
        private String[] obtenerValoresSeparados(String linea)
        {
            String[] retorno = new string[2];
            Boolean terminoVariable = false;
            for (int i = 0; i < linea.Length; i++)
            {
                if (linea[i] == '=' && !terminoVariable)
                {
                    terminoVariable = true;
                    continue;
                }

                if (!terminoVariable)
                    retorno[0] += linea[i];
                else
                    retorno[1] += linea[i];
            }
            retorno[0] = retorno[0].Trim();
            retorno[1] = retorno[1].Trim();
            return retorno;
        }
        public T ObtenerValorVariable<T>(String variable)
        {
            if (diccionario.ContainsKey(variable))
            {
                try
                {
                    return (T)Convert.ChangeType(diccionario[variable], typeof(T));
                }
                catch (Exception ex)
                {
                    return default(T);
                }
            }
            else
            {
                diccionario.Add(variable, "");
                ActualizarArchivo();
                return default(T);
            }

        }
        public void ActualizarArchivo()
        {
            StreamWriter sw = new StreamWriter(rutaArchivo);

            foreach (String variable in diccionario.Keys)
            {
                sw.WriteLine(variable + " = " + diccionario[variable]);
            }
            sw.Close();
        }
        public void BorrarVariables()
        {
            diccionario.Clear();
            StreamWriter sw = new StreamWriter(rutaArchivo);
            sw.Close();
        }
        public void GuardarValorVariable(String variable, String valor)
        {
            LeerArchivo();
            if (diccionario.ContainsKey(variable))
            {
                diccionario[variable] = valor;
            }
            else
            {
                diccionario.Add(variable, valor);
            }
            ActualizarArchivo();
        }

    }
}
