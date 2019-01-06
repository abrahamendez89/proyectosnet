using Herramientas.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;

namespace Herramientas.Archivos
{
    public class Imagenes
    {
        public enum Formato
        {
            JPEG,
            PNG
        }
        public static Bitmap CargarBitmapDeURL(string url)
        {
            HttpWebRequest wreq;
            HttpWebResponse wresp;
            Stream mystream;
            Bitmap bmp;

            bmp = null;
            mystream = null;
            wresp = null;
            try
            {
                wreq = (HttpWebRequest)WebRequest.Create(url);
                wreq.AllowWriteStreamBuffering = true;
                try
                {
                    wresp = (HttpWebResponse)wreq.GetResponse();

                    if ((mystream = wresp.GetResponseStream()) != null)
                        bmp = new Bitmap(mystream);
                }
                catch
                {
                    return null;
                }
            }
            finally
            {
                if (mystream != null)
                    mystream.Close();

                if (wresp != null)
                    wresp.Close();
            }
            return (bmp);
        }
        public static void GuardarImagenEnArchivo(String carpetaGuardado, String nombreArchivoSinExtension,Bitmap imagen, Formato formato)
        {
            try
            {
                if (formato == Formato.JPEG)
                {
                    imagen.Save(carpetaGuardado + nombreArchivoSinExtension + ".jpeg", ImageFormat.Jpeg);
                }
                else if (formato == Formato.PNG)
                {
                    imagen.Save(carpetaGuardado + nombreArchivoSinExtension + ".png", ImageFormat.Png);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Bitmap ObtenerFotoPantallaPrincipal()
        {
            Bitmap bmpScreenshot = new Bitmap(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics gfxScreenshot = Graphics.FromImage(bmpScreenshot);
            gfxScreenshot.CopyFromScreen(System.Windows.Forms.Screen.PrimaryScreen.Bounds.X, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Y, 0, 0, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
            return bmpScreenshot;
        }
        public static List<Bitmap> ObtenerFotoPantallas()
        {
            List<Bitmap> fotosPantallas = new List<Bitmap>();
            foreach (System.Windows.Forms.Screen screen in System.Windows.Forms.Screen.AllScreens)
            {
                Bitmap bmpScreenshot = new Bitmap(screen.Bounds.Width, screen.Bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                Graphics gfxScreenshot = Graphics.FromImage(bmpScreenshot);
                gfxScreenshot.CopyFromScreen(screen.Bounds.X, screen.Bounds.Y, 0, 0, screen.Bounds.Size, CopyPixelOperation.SourceCopy);
                fotosPantallas.Add(bmpScreenshot);
            }
            return fotosPantallas;
        }
        public static Bitmap ObtenerFotoPantallaPrincipalConCursor()
        {
            var bitmap = new Bitmap(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(System.Windows.Forms.Screen.PrimaryScreen.Bounds.X, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Y, 0, 0, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);

                User32.CURSORINFO cursorInfo;
                cursorInfo.cbSize = Marshal.SizeOf(typeof(User32.CURSORINFO));

                if (User32.GetCursorInfo(out cursorInfo))
                {
                    // if the cursor is showing draw it on the screen shot
                    if (cursorInfo.flags == User32.CURSOR_SHOWING)
                    {
                        // we need to get hotspot so we can draw the cursor in the correct position
                        var iconPointer = User32.CopyIcon(cursorInfo.hCursor);
                        User32.ICONINFO iconInfo;
                        int iconX, iconY;

                        if (User32.GetIconInfo(iconPointer, out iconInfo))
                        {
                            // calculate the correct position of the cursor
                            iconX = cursorInfo.ptScreenPos.x - ((int)iconInfo.xHotspot);
                            iconY = cursorInfo.ptScreenPos.y - ((int)iconInfo.yHotspot);

                            // draw the cursor icon on top of the captured screen image
                            User32.DrawIcon(g.GetHdc(), iconX, iconY, cursorInfo.hCursor);

                            // release the handle created by call to g.GetHdc()
                            g.ReleaseHdc();
                        }
                    }
                }
            }
            return bitmap;
        }
        public static List<Bitmap> ObtenerFotoPantallasConCursor()
        {
            List<Bitmap> fotosPantallas = new List<Bitmap>();
            foreach (System.Windows.Forms.Screen screen in System.Windows.Forms.Screen.AllScreens)
            {
                var bitmap = new Bitmap(screen.Bounds.Width, screen.Bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(screen.Bounds.X, screen.Bounds.Y, 0, 0, screen.Bounds.Size, CopyPixelOperation.SourceCopy);

                    User32.CURSORINFO cursorInfo;
                    cursorInfo.cbSize = Marshal.SizeOf(typeof(User32.CURSORINFO));

                    if (User32.GetCursorInfo(out cursorInfo))
                    {
                        // if the cursor is showing draw it on the screen shot
                        if (cursorInfo.flags == User32.CURSOR_SHOWING)
                        {
                            // we need to get hotspot so we can draw the cursor in the correct position
                            var iconPointer = User32.CopyIcon(cursorInfo.hCursor);
                            User32.ICONINFO iconInfo;
                            int iconX, iconY;

                            if (User32.GetIconInfo(iconPointer, out iconInfo))
                            {
                                // calculate the correct position of the cursor
                                iconX = cursorInfo.ptScreenPos.x - ((int)iconInfo.xHotspot);
                                iconY = cursorInfo.ptScreenPos.y - ((int)iconInfo.yHotspot);

                                // draw the cursor icon on top of the captured screen image
                                User32.DrawIcon(g.GetHdc(), iconX, iconY, cursorInfo.hCursor);

                                // release the handle created by call to g.GetHdc()
                                g.ReleaseHdc();
                            }
                        }
                    }
                }
                fotosPantallas.Add(bitmap);
            }
            return fotosPantallas;
        }
        public static Bitmap ComprimirImagen(Bitmap imagenAComprimir, int ancho, int alto, ImageFormat formato)
        {
            if (imagenAComprimir == null) return null;
            Bitmap imagenConvertida = (Bitmap)((System.Drawing.Image)imagenAComprimir.GetThumbnailImage(ancho, alto, delegate { return false; }, System.IntPtr.Zero));
            MemoryStream ms = new MemoryStream();

            imagenConvertida.Save(ms, formato);

            return (Bitmap)Bitmap.FromStream(ms);
            //return imagenConvertida;
        }
        //Conversiones a base64
        public static Bitmap BitArrayTOBitmap(byte[] array)
        {
            //Image.FromStream(new System.IO.MemoryStream(array));

            return (Bitmap)Bitmap.FromStream(new System.IO.MemoryStream(array));
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
        public static byte[] StringToByteArray(String cadena)
        {
            return Convert.FromBase64String(cadena);
        }
        public static String ByteArrayToString(byte[] byteArray)
        {
            return Convert.ToBase64String(byteArray);
        }
        public static String BitmapAStringBase64(Bitmap bitmap)
        {
            if (bitmap != null)
                return ByteArrayToString(BitmapTOBitArray(bitmap));
            else
                return null;
        }
        public static Bitmap StringBase64ABitmap(String textoBitmap)
        {
            if (textoBitmap != null)
                return BitArrayTOBitmap(StringToByteArray(textoBitmap));
            else
                return null;
        }
    }
}
