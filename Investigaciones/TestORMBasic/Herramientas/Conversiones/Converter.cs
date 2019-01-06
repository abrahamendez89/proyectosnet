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

        public static byte[] BitmapTOBitArray(Bitmap bitmap)
        {
            byte[] data;
            ImageFormat wf = bitmap.RawFormat;
            if (wf.Guid == new Guid("b96b3caf-0728-11d3-9d7b-0000f81ef32e")) //es una png
            {
                using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
                {
                    bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                    data = stream.ToArray();
                }
            }
            else // if (wf.Guid == new Guid("B96B3CAE-0728-11D3-9D7B-0000F81EF32E")) // es una jpeg
            {
                using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
                {
                    bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    data = stream.ToArray();
                }
            }
            return data;
        }

        public static Bitmap BitArrayTOBitmap(byte[] array)
        {
            //Image.FromStream(new System.IO.MemoryStream(array));

            return (Bitmap)Bitmap.FromStream(new System.IO.MemoryStream(array));
        }
        
    }
}
