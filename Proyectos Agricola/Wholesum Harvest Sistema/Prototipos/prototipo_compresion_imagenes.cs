using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Prototipos
{
    public partial class prototipo_compresion_imagenes : Form
    {
        public prototipo_compresion_imagenes()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //ComprimirImagen(@"D:\fondo-abstracto-negro.jpg", @"D:\fondo-abstracto-negro-comprimido.jpg", 10);
            //ComprimirArchivo(@"D:\fondo-abstracto-negro.jpg", @"D:\archivo.zip");
            //Bitmap bitmap = new Bitmap(@"D:\fondo-abstracto-negro.jpg");
            Bitmap bitmap = new Bitmap(@"D:\grafica.png");
            byte[] data;
            ImageFormat wf = bitmap.RawFormat;
            if (wf.Guid == new Guid("b96b3caf-0728-11d3-9d7b-0000f81ef32e"))
            {
                using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
                {
                    bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                    data = stream.ToArray();
                }
            }
            else if (wf.Guid == new Guid("B96B3CAE-0728-11D3-9D7B-0000F81EF32E"))
            {
                using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
                {
                    bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    data = stream.ToArray();
                }
            }
            else
            {
            }
            using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
            {
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                data = stream.ToArray();
            }
            //return data;
        }
        static public Boolean DescromprimirZip(string ArchivoZip, string RutaGuardar)
        {
            try
            {
                using (ZipFile zip = ZipFile.Read(ArchivoZip))
                {
                    zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression;
                    
                    zip.ExtractAll(RutaGuardar);
                    zip.Dispose();

                }

                return true;
            }
            catch
            {
                return false;

            }

        }
        static public Boolean ComprimirArchivo(string archivo, string RutaGuardar)
        {
            try
            {
                using (ZipFile zip = new ZipFile())
                {
                    zip.AddFile(archivo);
                    zip.Save(RutaGuardar);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        static public Boolean ComprimirListaDeArchivos(string RutaDeArchivos, string RutaGuardar)
        {
            try
            {
                String[] NombreArchivos = Directory.GetFiles(RutaDeArchivos, "*.jp*");

                using (ZipFile zip = new ZipFile())
                {
                    zip.AddFiles(NombreArchivos, "");
                    zip.Save(RutaGuardar);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        //static public Boolean ComprimirFolder(string Ruta, string Nombre)
        //{

        //    try
        //    {
        //        using (ZipFile zip = new ZipFile())
        //        {
        //            zip.AddDirectory(Ruta);

        //            zip.Save(HttpContext.Current.Server.MapPath("temp/" + Nombre + ".zip"));

        //        }

        //        return true;
        //    }
        //    catch
        //    {
        //        return false;

        //    }

        //}





        public static byte[] BitmapTOBitArray(Bitmap bitmap)
        {
            byte[] data;

            using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
            {
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.MemoryBmp);
                data = stream.ToArray();
            }
            return data;
        }

        public static Bitmap BitArrayTOBitmap(byte[] array)
        {
            //Image.FromStream(new System.IO.MemoryStream(array));

            return (Bitmap)Bitmap.FromStream(new System.IO.MemoryStream(array));
        }








        static void ComprimirImagen(string inputFile, string ouputfile, long compression)
        {

            Image image = Image.FromFile(inputFile);


            EncoderParameters eps = new EncoderParameters(1);
            eps.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, compression);


            string mimetype = GetMimeType(new System.IO.FileInfo(inputFile).Extension);
            ImageCodecInfo ici = GetEncoderInfo(mimetype);

            image.Save(ouputfile, ici, eps);

        }

        static string GetMimeType(string ext)
        {
            //    CodecName FilenameExtension FormatDescription MimeType 
            //    .BMP;*.DIB;*.RLE BMP ==> image/bmp 
            //    .JPG;*.JPEG;*.JPE;*.JFIF JPEG ==> image/jpeg 
            //    *.GIF GIF ==> image/gif 
            //    *.TIF;*.TIFF TIFF ==> image/tiff 
            //    *.PNG PNG ==> image/png 
            switch (ext.ToLower())
            {
                case ".bmp":
                case ".dib":
                case ".rle":
                    return "image/bmp";

                case ".jpg":
                case ".jpeg":
                case ".jpe":
                case ".fif":
                    return "image/jpeg";

                case "gif":
                    return "image/gif";
                case ".tif":
                case ".tiff":
                    return "image/tiff";
                case "png":
                    return "image/png";
                default:
                    return "image/jpeg";
            }
        }

        static ImageCodecInfo GetEncoderInfo(string mimeType)
        {

            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();

            ImageCodecInfo encoder = (from enc in encoders
                                      where enc.MimeType == mimeType
                                      select enc).First();
            return encoder;

        }
    }
}
