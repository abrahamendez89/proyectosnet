using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace InterfazWPF.AdministracionSistema
{
    /// <summary>
    /// Lógica de interacción para VisorImagenes.xaml
    /// </summary>
    public partial class VisorImagenes : Window
    {
        Bitmap imagen;
        public VisorImagenes(Bitmap imagen)
        {
            InitializeComponent();

            img_imagenVisor.Source = BitmapAImageSource(imagen);
            this.imagen = imagen;
        }
        public static ImageSource BitmapAImageSource(Bitmap imagen)
        {
            if (imagen == null) return null;
            return BitmapToImageSource(imagen);
        }
        private static BitmapSource BitmapToImageSource(Bitmap source)
        {
            if (source == null) return null;
            return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(source.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
        }
        public static ImageSource BitmapAImageSource(String rutaImagen)
        {
            try
            {
                Bitmap imagen = new Bitmap(rutaImagen);
                if (imagen == null) return null;
                return BitmapToImageSource(imagen);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private void Boton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Archivos de imagen|*.png;*.jpg;*.jpeg;*.bmp|Todos los archivos|*.*";
            sfd.FileName = "imagen_" + DateTime.Now.ToString("yyyyMMdd_HHmm")+".jpg";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK && imagen != null)
            {
                imagen.Save(sfd.FileName);
            }
        }
    }
}
