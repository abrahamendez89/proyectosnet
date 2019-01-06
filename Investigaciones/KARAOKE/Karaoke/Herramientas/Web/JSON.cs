using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Herramientas.Web
{
    public class JSON
    {
        Object objetoAConvertir;
        int niveles;
        public JSON(Object objetoAConvertir, int niveles)
        {
            this.objetoAConvertir = objetoAConvertir;
            this.niveles = niveles;
        }

        public String ObtenerJSON()
        {
            String cadena = "{";
            Type tipo = objetoAConvertir.GetType();
            if (tipo.Name.StartsWith("List"))
            {
                cadena += "\n\"lista\": \n[";
                IList lista = (IList)objetoAConvertir;
                foreach (object objetoLista in lista)
                {
                    cadena += "\n{\n";
                    cadena = Convertir(objetoLista, 0, cadena);
                    cadena = cadena.Substring(0, cadena.Length - 1);
                    cadena += "\n},";
                }
                cadena = cadena.Substring(0, cadena.Length - 1);
                cadena += "\n]\n";
            }
            else
            {
                cadena = Convertir(this.objetoAConvertir, 0, cadena);
                cadena = cadena.Substring(0, cadena.Length - 1);
            }
            cadena += "\n}";
            return cadena;
        }
        private String Convertir(Object objeto, int nivelActual, String cadenaActual)
        {

            if (nivelActual == niveles + 1)
                return cadenaActual;

            Type tipo = objeto.GetType();

            FieldInfo[] atributos = tipo.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            nivelActual++;
            for (int i = 0; i < atributos.Length; i++)
            {
                FieldInfo atributo = atributos[i];
                Object valor = atributo.GetValue(objeto);

                if (atributo.Name.StartsWith("_") && valor != null)
                {
                    //es una tributo valido y ahora se obtiene el tipo de atributo
                    if (atributo.FieldType.Name.StartsWith("_"))
                    {
                        cadenaActual += ObtenerIdentacion(nivelActual) + "\"" + atributo.Name + "\" : \n";
                        nivelActual++;
                        cadenaActual += ObtenerIdentacion(nivelActual) + "{";
                        cadenaActual = Convertir(valor, nivelActual, cadenaActual);
                        cadenaActual = cadenaActual.Substring(0, cadenaActual.Length - 1);
                        cadenaActual += ObtenerIdentacion(nivelActual) + "\n";
                        cadenaActual += ObtenerIdentacion(nivelActual) + "},";
                        nivelActual--;
                    }
                    else if (atributo.FieldType.Name.StartsWith("List"))
                    {
                        //el atributo es de tipo lista por lo tanto se considera como una lista de objetos de dominio

                        IList lista = (IList)valor;
                        cadenaActual += "\n";
                        cadenaActual += ObtenerIdentacion(nivelActual) + "\"" + atributo.Name + "\" : \n";
                        cadenaActual += ObtenerIdentacion(nivelActual) + "[";
                        Boolean paso = false;
                        foreach (object objetoLista in lista)
                        {
                            cadenaActual += "\n";
                            nivelActual++;
                            cadenaActual += ObtenerIdentacion(nivelActual) + "{";
                            cadenaActual = Convertir(objetoLista, nivelActual, cadenaActual);
                            cadenaActual = cadenaActual.Substring(0, cadenaActual.Length - 1);
                            cadenaActual += "\n";
                            cadenaActual += ObtenerIdentacion(nivelActual) + "},";
                            nivelActual--;
                            paso = true;

                        }
                        if (paso) cadenaActual = cadenaActual.Substring(0, cadenaActual.Length - 1);
                        cadenaActual += "\n";
                        cadenaActual += ObtenerIdentacion(nivelActual) + "],";
                    }
                    else
                    {
                        //el atributo es del objeto en curso, por lo tanto se obtiene su tipo de atributo.
                        if (atributo.FieldType == typeof(String))
                        {

                            cadenaActual += "\n";
                            cadenaActual += ObtenerIdentacion(nivelActual) + "\"" + atributo.Name + "\" : \"" + valor.ToString() + "\",";
                        }
                        else if (atributo.FieldType == typeof(Int32) || atributo.FieldType == typeof(double) || atributo.FieldType == typeof(Int64))
                        {
                            cadenaActual += "\n";
                            cadenaActual += ObtenerIdentacion(nivelActual) + "\"" + atributo.Name + "\" : " + valor.ToString() + ",";
                        }
                        else if (atributo.FieldType == typeof(Bitmap))
                        {
                            cadenaActual += "\n";
                            cadenaActual += ObtenerIdentacion(nivelActual) + "\"" + atributo.Name + "\" : \"" + ConvertirBitmapAStringBase64((Bitmap)valor) + "\",";
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
            return cadenaActual;

        }

        private String ObtenerIdentacion(int nivel)
        {
            String identacionSencilla = "\t";
            String resultado = "";
            for (int i = 0; i < nivel; i++)
            {
                resultado += identacionSencilla;
            }
            return resultado;
        }

        private string ConvertirBitmapAStringBase64(Bitmap imagen)
        {
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            imagen.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] imageBytes = stream.ToArray();

            string base64String = Convert.ToBase64String(imageBytes);
            return base64String;
        }
    }
}
