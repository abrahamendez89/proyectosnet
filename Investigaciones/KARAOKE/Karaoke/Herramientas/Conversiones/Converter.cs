using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
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

        public static string ComprimirString(string stringNormal)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(stringNormal);
            var memoryStream = new MemoryStream();
            using (var gZipStream = new GZipStream(memoryStream, CompressionMode.Compress, true))
            {
                gZipStream.Write(buffer, 0, buffer.Length);
            }

            memoryStream.Position = 0;

            var compressedData = new byte[memoryStream.Length];
            memoryStream.Read(compressedData, 0, compressedData.Length);

            var gZipBuffer = new byte[compressedData.Length + 4];
            Buffer.BlockCopy(compressedData, 0, gZipBuffer, 4, compressedData.Length);
            Buffer.BlockCopy(BitConverter.GetBytes(buffer.Length), 0, gZipBuffer, 0, 4);
            return Convert.ToBase64String(gZipBuffer);
        }
        public static string DescomprimirString(string stringComprimida)
        {
            byte[] gZipBuffer = Convert.FromBase64String(stringComprimida);
            using (var memoryStream = new MemoryStream())
            {
                int dataLength = BitConverter.ToInt32(gZipBuffer, 0);
                memoryStream.Write(gZipBuffer, 4, gZipBuffer.Length - 4);

                var buffer = new byte[dataLength];

                memoryStream.Position = 0;
                using (var gZipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
                {
                    gZipStream.Read(buffer, 0, buffer.Length);
                }

                return Encoding.UTF8.GetString(buffer);
            }
        }
        
    }
}
