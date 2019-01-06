using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Herramientas.Conversiones
{
    public class Converter
    {
        public static Object ParseType(Object Value, Type type)
        {
            Object ConvertedValue = null;
            ConvertedValue = Convert.ChangeType(Value, type);
            return ConvertedValue;
        }

        public static byte[] ObjectToArray(object obj)
        {
            MemoryStream memoryStream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(memoryStream, obj);
            return memoryStream.ToArray();
        }
        public static object ArrayToObject(byte[] array)
        {
            MemoryStream memoryStream = new MemoryStream(array);
            BinaryFormatter formatter = new BinaryFormatter();
            return formatter.Deserialize(memoryStream);
        }

        

        
        public static Bitmap ComprimirImagen(Bitmap imagenAComprimir, int ancho, int alto, ImageFormat formato)
        {
            if (imagenAComprimir == null) return null;
            Bitmap imagenConvertida = (Bitmap)((System.Drawing.Image)imagenAComprimir.GetThumbnailImage(ancho, alto, delegate { return false; }, System.IntPtr.Zero));
            MemoryStream ms = new MemoryStream();

            imagenConvertida.Save(ms, formato);
            Bitmap bm = (Bitmap)Bitmap.FromStream(ms);
            //ms.Close();
            //ms.Dispose();

            return bm;
            //return imagenConvertida;
        }

        public static String ByteArrayToString(byte[] array)
        {
            return System.Text.Encoding.UTF8.GetString(array, 0, array.Length);
        }
        public static byte[] StringToByteArray(String cadena)
        {
            return System.Text.Encoding.UTF8.GetBytes(cadena); 
        }
    }
}
