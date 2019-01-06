using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Herramientas.WPF
{
    public class Utilidades
    {
        public static double RedondearANDecimales(double numero, int numeroDecimales)
        {
            decimal redondeado = decimal.Round((decimal)numero, numeroDecimales);
            return (double)redondeado;
        }
        public static void AgregarColumnaConBindingADataGridView(System.Windows.Controls.DataGrid dgv, String header, String binding)
        {
            System.Windows.Controls.DataGridTextColumn textColumn = new DataGridTextColumn();
            textColumn.Header = header;
            textColumn.CanUserSort = false;
            textColumn.Binding = new System.Windows.Data.Binding(binding);
            dgv.Columns.Add(textColumn);
        }
        public static int ObtenerRowSeleccionadoDataGrid(object sender , MouseButtonEventArgs e)
        {
            DependencyObject dep = (DependencyObject)e.OriginalSource;

            // iteratively traverse the visual tree
            while ((dep != null) && !(dep is System.Windows.Controls.DataGridCell) && !(dep is DataGridColumnHeader))
            {
                dep = VisualTreeHelper.GetParent(dep);
            }

            if (dep == null)
                return -1;

            if (dep is DataGridColumnHeader)
            {
                DataGridColumnHeader columnHeader = dep as DataGridColumnHeader;
                // do something
            }

            if (dep is System.Windows.Controls.DataGridCell)
            {
                System.Windows.Controls.DataGridCell cell = dep as System.Windows.Controls.DataGridCell;
                while ((dep != null) && !(dep is DataGridRow))
                {
                    dep = VisualTreeHelper.GetParent(dep);
                }

                DataGridRow row = dep as DataGridRow;

                return FindRowIndex(row);
            }
            else
                return -1;
        }
        private static int FindRowIndex(DataGridRow row)
        {
            System.Windows.Controls.DataGrid dataGrid =
                ItemsControl.ItemsControlFromItemContainer(row)
                as System.Windows.Controls.DataGrid;

            int index = dataGrid.ItemContainerGenerator.
                IndexFromContainer(row);

            return index;
        }
        public static BitmapImage FileTOImageSource(String archivo)
        {
            BitmapImage src = new BitmapImage();
            src.BeginInit();
            src.UriSource = new Uri(archivo, UriKind.Relative);
            src.EndInit();
            return src;
        }
        public static MemoryStream BitmapToStream(Bitmap bitmap)
        {
            ImageConverter ic = new ImageConverter();
            Byte[] ba = (Byte[])ic.ConvertTo(bitmap, typeof(Byte[]));
            MemoryStream stream = new MemoryStream(ba);

            return stream;
        }
        public static MemoryStream FileToStream(String dir)
        {
            System.IO.MemoryStream data = new System.IO.MemoryStream();
            System.IO.Stream str = File.OpenRead(dir);

            str.CopyTo(data);
            data.Seek(0, SeekOrigin.Begin);
            byte[] buf = new byte[data.Length];
            data.Read(buf, 0, buf.Length);
            data.Position = 0;
            return data;
        }
        public static String EjecutaShell(String linea)
        {
            String mensajeError = "";
            try
            {
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Verb = "runas";
                startInfo.Arguments = "/c " + linea;
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardError = true;
                startInfo.UseShellExecute = false;
                startInfo.CreateNoWindow = true;

                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit();

                mensajeError = process.StandardError.ReadToEnd();

                if (!mensajeError.Trim().Equals(""))
                {
                    //throw new Exception(mensajeError);
                    return mensajeError;
                }

                return process.StandardOutput.ReadToEnd();

            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message + " CMD: " + mensajeError);
                return ex.Message;
            }
        }
        public static List<String> ObtenerRutasArchivoDeDirectorio(String directorio, List<String> extensionesFiltro, Boolean recursivo)
        {
            if (!recursivo)
            {
                List<string> archivos = new List<string>();
                foreach (String extension in extensionesFiltro)
                    archivos.AddRange(Directory.GetFiles(directorio, "*.*", SearchOption.TopDirectoryOnly).Where(s => s.EndsWith(extension)).ToList());
                return archivos;
            }
            else
            {
                return recorridoRecursivo(directorio, extensionesFiltro);
            }
        }
        private static List<String> recorridoRecursivo(String directorio, List<String> extensionesFiltro)
        {
            List<String> archivos = new List<string>();
            List<String> carpetas = new List<string>();
            carpetas.AddRange(Directory.GetDirectories(directorio));

            foreach (String extension in extensionesFiltro)
                archivos.AddRange(Directory.GetFiles(directorio, "*.*", SearchOption.TopDirectoryOnly).Where(s => s.EndsWith(extension)).ToList());

            foreach (String carpeta in carpetas)
                archivos.AddRange(recorridoRecursivo(carpeta, extensionesFiltro));
            return archivos;
        }
        public static Bitmap CargarImagenDeArchivosABitmap()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos de imagen|*.png;*.jpg;*.jpeg;*.bmp";
            Bitmap imagen = null;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imagen = new Bitmap(ofd.FileName);
            }
            return imagen;
        }
        public static List<String> BuscarArchivos(List<String> DescripcionesFiltro, List<String> extensionesFiltro)
        {
            String filtros = "";
            for (int i = 0; i < DescripcionesFiltro.Count; i++)
            {
                filtros += DescripcionesFiltro[i] + "(*." + extensionesFiltro[i] + ")|*." + extensionesFiltro[i] + "|";
            }

            filtros = filtros.Substring(0, filtros.Length - 1);

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = filtros;
            ofd.Multiselect = false;
            ofd.Title = "Seleccione un archivo";
            List<String> archivos = null;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                archivos = ofd.FileNames.ToList();
            }
            return archivos;
        }
        //public static String BuscarArchivo(List<String> DescripcionesFiltro, List<String> extensionesFiltro)
        //{
        //    String filtros="";
        //    for (int i = 0; i < DescripcionesFiltro.Count; i++)
        //    {
        //        filtros += DescripcionesFiltro[i]+"(*."+extensionesFiltro[i]+")|*."+extensionesFiltro[i]+"|";
        //    }

        //    filtros = filtros.Substring(0, filtros.Length - 1);

        //    OpenFileDialog ofd = new OpenFileDialog();
        //    ofd.Filter = filtros;
        //    ofd.Multiselect = false;
        //    ofd.Title = "Seleccione un archivo";
        //    String archivo = null;
        //    if (ofd.ShowDialog() == DialogResult.OK)
        //    {
        //        archivo = ofd.FileName;
        //    }
        //    return archivo;
        //}
        //public static String GuardarArchivoRuta(List<String> DescripcionesFiltro, List<String> extensionesFiltro, String nombreArchivoDefault)
        //{
        //    String filtros = "";
        //    for (int i = 0; i < DescripcionesFiltro.Count; i++)
        //    {
        //        filtros += DescripcionesFiltro[i] + "(*." + extensionesFiltro[i] + ")|*." + extensionesFiltro[i] + "|";
        //    }

        //    filtros = filtros.Substring(0, filtros.Length - 1);
        //    SaveFileDialog ofd = new SaveFileDialog();
        //    ofd.Filter = filtros;
        //    ofd.FileName = nombreArchivoDefault;
        //    ofd.Title = "Guardar archivo";
        //    String archivo = null;
        //    if (ofd.ShowDialog() == DialogResult.OK)
        //    {
        //        archivo = ofd.FileName;
        //    }
        //    return archivo;
        //}
        //public static String BuscarCarpeta(String directorioInicial)
        //{
        //    FolderBrowserDialog ofd = new FolderBrowserDialog();
        //    if (directorioInicial != null)
        //        ofd.SelectedPath = directorioInicial;
        //    ofd.ShowNewFolderButton = false;
        //    String retorno = null;
        //    if (ofd.ShowDialog() == DialogResult.OK)
        //    {
        //        retorno = ofd.SelectedPath;
        //    }
        //    return retorno;
        //}
        public static BitmapImage CargarImagenURLABitmapImage(String url)
        {
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri(url, UriKind.RelativeOrAbsolute);
            bi3.CacheOption = BitmapCacheOption.OnLoad;
            bi3.EndInit();
            return bi3;
        }
        //public static Bitmap CargarBitmapDeURL(string url)
        //{
        //    HttpWebRequest wreq;
        //    HttpWebResponse wresp;
        //    Stream mystream;
        //    Bitmap bmp;

        //    bmp = null;
        //    mystream = null;
        //    wresp = null;
        //    try
        //    {
        //        wreq = (HttpWebRequest)WebRequest.Create(url);
        //        wreq.AllowWriteStreamBuffering = true;
        //        try
        //        {
        //            wresp = (HttpWebResponse)wreq.GetResponse();

        //            if ((mystream = wresp.GetResponseStream()) != null)
        //                bmp = new Bitmap(mystream);
        //        }
        //        catch
        //        {
        //            return null;
        //        }
        //    }
        //    finally
        //    {
        //        if (mystream != null)
        //            mystream.Close();

        //        if (wresp != null)
        //            wresp.Close();
        //    }
        //    return (bmp);
        //}
        //public static Bitmap ObtenerFotoPantalla()
        //{
        //    Bitmap bmpScreenshot = new Bitmap(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        //    Graphics gfxScreenshot = Graphics.FromImage(bmpScreenshot);
        //    gfxScreenshot.CopyFromScreen(System.Windows.Forms.Screen.PrimaryScreen.Bounds.X, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Y, 0, 0, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
        //    return bmpScreenshot;
        //}
        private static BitmapSource BitmapToImageSource(Bitmap source)
        {
            if (source == null) return null;
            try
            {
                return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(source.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
            }
            catch
            {
                return null;
            }
        }
        public static BitmapSource CargarImagenDeArchivosABitmapSource()
        {
            return BitmapToImageSource(CargarImagenDeArchivosABitmap());
        }
        public static void AgregarEventoCambiarImagen(System.Windows.Controls.Image controlImage)
        {
            controlImage.MouseDown += controlImage_MouseDown;
            controlImage.DataContext = false;
            controlImage.ToolTip = "Click izquierdo para cambiar | Click derecho para borrar";
            if (controlImage.Source == null)
                AsignarFondoBlancoImage(controlImage);
        }
        public static void AsignarFondoBlancoImage(System.Windows.Controls.Image controlImage)
        {
            var b = new Bitmap(1, 1);
            b.SetPixel(0, 0, System.Drawing.Color.White);
            controlImage.Source = BitmapToImageSource(b);
        }
        public enum FormatoImagen
        {
            JPEG = 0,
            PNG = 1
        }
        public static Bitmap ObtenerBitmapDeImageControl(System.Windows.Controls.Image controlImage, FormatoImagen formato)
        {
            if (!(Boolean)controlImage.DataContext)
                return null;

            if (formato == FormatoImagen.JPEG)
            {
                return ImageSourceABitmap(controlImage.Source, ImageFormat.Jpeg);
            }
            else if (formato == FormatoImagen.PNG)
            {
                return ImageSourceABitmap(controlImage.Source, ImageFormat.Png);
            }
            return null;

        }
        static void controlImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Controls.Image controlImagen = (System.Windows.Controls.Image)sender;
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                BitmapSource imagen = CargarImagenDeArchivosABitmapSource();
                if (imagen != null)
                {
                    controlImagen.Source = imagen;
                    controlImagen.DataContext = true;
                }
            }
            else if (e.RightButton == MouseButtonState.Pressed)
            {
                AsignarFondoBlancoImage(controlImagen);
                controlImagen.DataContext = false;
            }

        }
        public static ImageSource BitmapAImageSource(Bitmap imagen)
        {

            if (imagen == null) return null;
            return BitmapToImageSource(imagen);
        }
        public static ImageSource ArchivoAImageSource(String archivo)
        {
            Bitmap imagen = null;
            try
            {
                imagen = new Bitmap(archivo);
            }
            catch
            {
                return null;
            }

            if (imagen == null) return null;
            return BitmapToImageSource(imagen);
        }
        public static Bitmap ImageSourceABitmap(ImageSource imagen)
        {

            if (imagen == null) return null;

            MemoryStream ms = new MemoryStream();
            var encoder = new System.Windows.Media.Imaging.PngBitmapEncoder();
            encoder.Frames.Add(System.Windows.Media.Imaging.BitmapFrame.Create(imagen as System.Windows.Media.Imaging.BitmapSource));
            encoder.Save(ms);
            ms.Flush();

            return (Bitmap)Bitmap.FromStream(ms);
        }
        public static Bitmap ImageSourceABitmap(ImageSource imagen, ImageFormat formato)
        {

            if (imagen == null) return null;

            MemoryStream ms = new MemoryStream();
            var encoder = new System.Windows.Media.Imaging.PngBitmapEncoder();
            encoder.Frames.Add(System.Windows.Media.Imaging.BitmapFrame.Create(imagen as System.Windows.Media.Imaging.BitmapSource));
            encoder.Save(ms);
            ms.Flush();

            Bitmap imagenConvertida = (Bitmap)System.Drawing.Image.FromStream(ms);

            MemoryStream ms2 = new MemoryStream();

            imagenConvertida.Save(ms2, formato);

            return (Bitmap)Bitmap.FromStream(ms);
        }
        //public static Bitmap ComprimirImagen(Bitmap imagenAComprimir, int ancho, int alto, ImageFormat formato)
        //{
        //    if (imagenAComprimir == null) return null;
        //    Bitmap imagenConvertida = (Bitmap)((System.Drawing.Image)imagenAComprimir.GetThumbnailImage(ancho, alto, delegate { return false; }, System.IntPtr.Zero));
        //    MemoryStream ms = new MemoryStream();

        //    imagenConvertida.Save(ms, formato);

        //    return (Bitmap)Bitmap.FromStream(ms);
        //    //return imagenConvertida;
        //}
        public static void MostrarImagenEnVisor(Bitmap imagen)
        {
            //VisorImagenes visor = new VisorImagenes(imagen);
            //visor.ShowDialog();
        }
        public static void MostrarImagenEnVisor(ImageSource imagen)
        {
            MostrarImagenEnVisor(ImageSourceABitmap(imagen, System.Drawing.Imaging.ImageFormat.Jpeg));
        }
    }
}
