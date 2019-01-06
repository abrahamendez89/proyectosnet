using CompresorImagenes.Archivos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CompresorImagenes
{
    public partial class ConvertidorArchivos : Form
    {
        Variable var;
        SQLServer sql;
        public ConvertidorArchivos()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            var = new Variable("data.conf");
            CargarDatosDeArchivo();
            this.FormClosed += Form1_FormClosed;
            btn_ejecutar.Click += btn_ejecutar_Click;
            btn_test.Click += btn_test_Click;
            btn_seleccionar.Click += btn_seleccionar_Click;

            pb_de.Click += pb_de_Click;
            pb_hacia.Click += pb_hacia_Click;
        }

        List<String> archivos = new List<string>();
        private void cargarArchivos()
        {
            archivos.Clear();
            if (txt_directorio.Text.Trim().Equals(""))
            {
                return;
            }
            System.IO.DriveInfo di = new System.IO.DriveInfo(txt_directorio.Text);


            archivos.AddRange(System.IO.Directory.GetFiles(txt_directorio.Text, "*.jpg"));
            archivos.AddRange(System.IO.Directory.GetFiles(txt_directorio.Text, "*.jpeg"));
            archivos.AddRange(System.IO.Directory.GetFiles(txt_directorio.Text, "*.png"));
            Random rnd = new Random();
            fotoMuestra = (Bitmap)Bitmap.FromFile(archivos[rnd.Next(0, archivos.Count - 1)]);

        }
        void btn_seleccionar_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
                txt_directorio.Text = fbd.SelectedPath;
           
        }
        Bitmap fotoMuestra;
        private void cargarImagenes()
        {
            if (archivos.Count == 0)
            {
                MensajeInformacion("Primero debes elegir un directorio y cargar los archivos con el boton de cargar archivos.");
                return;
            }
            foreach (String archivo in archivos)
            {
                //Bitmap foto = (Bitmap)Bitmap.FromFile(archivo);
                //fotos.Add(foto);
                //nombresArchivos.Add(Path.GetFileName(archivo));
                ConvertirImagenSingle(archivo);
                lb_resultados.Items.Add("Comprimiendo " + archivo + "...");
                lb_resultados.SelectedIndex = lb_resultados.Items.Count - 1;
            }
            MensajeInformacion("Terminó el proceso de compresión de imagenes.");
        }
        void pb_hacia_Click(object sender, EventArgs e)
        {
            VisorImagenes visor = new VisorImagenes((Bitmap)pb_hacia.Image);
            visor.ShowDialog();
        }

        void pb_de_Click(object sender, EventArgs e)
        {
            VisorImagenes visor = new VisorImagenes((Bitmap)pb_de.Image);
            visor.ShowDialog();
        }
        int wNuevo = 0;
        int hNuevo = 0;
        void btn_test_Click(object sender, EventArgs e)
        {
            try
            {
                if (fotoMuestra == null)
                {
                    MensajeInformacion("Primero seleccione una ruta de fotos.");
                    return;
                }
                byte[] photo = imageToByteArray(fotoMuestra); // (byte[])data.Rows[0][txt_campoImagen.Text.Trim()];
                MemoryStream ms = new MemoryStream(photo);
                Bitmap bm = new Bitmap(ms);
                ms.Close();
                pb_de.Image = bm;
                lbl_tamDe.Text = (photo.Length / 1024d / 1024d).ToString("0.##") + " MB";

                int factor = 1;
                int resolucionMeta = Convert.ToInt32(txt_ancho.Text.Trim());
                wNuevo = bm.Width / factor;
                hNuevo = bm.Height / factor;
                while (wNuevo > resolucionMeta)
                {
                    wNuevo = bm.Width / factor;
                    hNuevo = bm.Height / factor;

                    factor++;
                }

                Bitmap transformada = ComprimirImagen(bm, wNuevo, hNuevo, ImageFormat.Jpeg);
                Byte[] bytesTransformada = imageToByteArray(transformada);
                pb_hacia.Image = transformada;
                lbl_tamA.Text = (bytesTransformada.Length / 1024d / 1024d).ToString("0.##") + " MB";
                //MensajeInformacion("Se encontraron " + archivos.Count + " registros y se selecciono el primero para la vista previa.");
            }
            catch (Exception ex)
            {
                MensajeError(ex.Message);
            }
        }

        private List<Bitmap> ObtenerImagenes()
        {
            return null;
        }
        void btn_ejecutar_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(cargarImagenes);
            t.Start();
        }

        private void MensajeInformacion(String mensaje)
        {
            MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lb_resultados.Items.Add("Información: " + mensaje);
        }
        private void MensajeError(String mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            lb_resultados.Items.Add("Error: " + mensaje);
        }
        void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            GuardarDatosAArchivo();
        }
        private void CargarDatosDeArchivo()
        {
            txt_directorio.Text = var.ObtenerValorVariable<String>("txt_directorio");
            txt_ancho.Text = var.ObtenerValorVariable<String>("txt_ancho");
            //cargarImagenes();
        }
        private void GuardarDatosAArchivo()
        {
            var.GuardarValorVariable("txt_directorio", txt_directorio.Text);
            var.GuardarValorVariable("txt_ancho", txt_ancho.Text);
        }
        private void ConvertirImagenSingle(String rutaFoto)
        {
            String carpetaComprimidos = txt_directorio.Text.Trim() + "\\COMPRIMIDOS\\";
            if (!Directory.Exists(carpetaComprimidos))
            {
                Directory.CreateDirectory(carpetaComprimidos);
            }
            Bitmap foto = new Bitmap(rutaFoto);
            byte[] photo = imageToByteArray(foto);// (byte[])dr[txt_campoImagen.Text.Trim()];
            MemoryStream ms = new MemoryStream(photo);
            Bitmap bm = new Bitmap(ms);
            ms.Close();
            ms.Dispose();

            int factor = 1;
            int resolucionMeta = Convert.ToInt32(txt_ancho.Text.Trim());
            wNuevo = bm.Width / factor;
            hNuevo = bm.Height / factor;
            while (wNuevo > resolucionMeta)
            {
                wNuevo = bm.Width / factor;
                hNuevo = bm.Height / factor;

                factor++;
            }


            Bitmap transformada = ComprimirImagen(bm, wNuevo, hNuevo, ImageFormat.Jpeg);

            Byte[] bytesTransformada = imageToByteArray(transformada);

            //transformada.Save(txt_directorio.Text.Trim()+"\\COMPRIMIDOS\\"+nombresArchivos[i]);




            String ruta = txt_directorio.Text.Trim() + "\\COMPRIMIDOS\\" + Path.GetFileName(rutaFoto);
            File.WriteAllBytes(ruta, bytesTransformada);
            foto.Dispose();
            transformada.Dispose();
        }

        public Bitmap CreateBitmapDeepCopy(Bitmap source)
        {
            Bitmap result;
            using (MemoryStream stream = new MemoryStream())
            {
                source.Save(stream, ImageFormat.Jpeg);
                stream.Seek(0, SeekOrigin.Begin);
                result = new Bitmap(stream);
            }
            return result;
        }
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] bt = ms.ToArray();
            //ms.Close();
            //ms.Dispose();
            return bt;
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

        private void btn_cargarImagenes_Click(object sender, EventArgs e)
        {
            if (!txt_directorio.Text.Equals(""))
            {
                cargarArchivos();
                MensajeInformacion("Se cargaron los archivos.");
            }
            pb_de.Image = fotoMuestra;
        }


    }
}
