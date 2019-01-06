using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Herramientas.Web;
using Herramientas.SMS;

namespace OneDrive
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            //AfilnetSMSService sms = new AfilnetSMSService("abrahamendez89@hotmail.com", "");
            //if (sms.EnviarSMSPOST("52", "6677517809", "6671944875", "Este es un mensaje enviado desde .NET"))
            //    Herramientas.Forms.Mensajes.Informacion("Envio correcto.");
            //else
            //    Herramientas.Forms.Mensajes.Error(sms.DetallesError);


            //String rutaImagen = @"C:\Users\Abrahamm.WHOLESUM\Pictures\nomina.jpg";

            //Bitmap bmp = new Bitmap(rutaImagen);
            //String base64 = Herramientas.Archivos.Imagenes.BitmapAStringBase64(bmp);
            //Bitmap bmp2 = Herramientas.Archivos.Imagenes.StringBase64ABitmap(base64);

            //String archivo = Herramientas.Archivos.Dialogos.BuscarArchivo(null, null);
            //String base64 = Herramientas.Archivos.Archivo.ArchivoAStringBase64(archivo);
            //Herramientas.Archivos.Archivo.GuardarArchivoDeTexto(Environment.CurrentDirectory+@"\prueba.txt", base64);

            String base64 = Herramientas.Archivos.Archivo.LeerArchivoTexto(Environment.CurrentDirectory + @"\prueba.txt");
            byte[] archivo = Herramientas.Archivos.Archivo.StringBase64ToByteArray(base64);
            Herramientas.Archivos.Archivo.GuardarArchivoDeByteArray(Environment.CurrentDirectory + @"\convertido.rar", archivo);
        }

        private void btn_subir_Click(object sender, EventArgs e)
        {
            if (!txt_usuario.Text.Equals("") && !txt_contra.Text.Equals("") && !txt_rutaArchivo.Text.Equals("") && !txt_Carpeta.Text.Equals(""))
            {
                //OneDriveAPI od = new OneDriveAPI(txt_usuario.Text.Trim(), txt_contra.Text);
                //od.error += db_error;
                //od.envioTerminado += db_envioTerminado;
                //od.porcentajeEnviado += od_porcentajeEnviado;
                //od.SubirArchivoACarpeta(txt_rutaArchivo.Text.Trim(), txt_Carpeta.Text.Trim());

                DropBoxAPI db = new DropBoxAPI(txt_usuario.Text.Trim(), txt_contra.Text);
                db.error += db_error;
                db.envioTerminado += db_envioTerminado;
                db.porcentajeEnviado += od_porcentajeEnviado;
                db.SubirArchivoACarpeta(txt_rutaArchivo.Text.Trim(), txt_Carpeta.Text.Trim());

            }
        }

        void db_envioTerminado(string rutaArchivo)
        {
            MessageBox.Show("Envio terminado.");
        }

        void db_error(string rutaArchivo, Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message);
        }
        void od_porcentajeEnviado(double porcentaje)
        {
            pb_progreso.Value = (int)porcentaje;
        }

        private String ObtenerArchivo()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dialog.Multiselect = false;
            dialog.Title = "Seleccione un archivo.";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return dialog.FileName;
            }
            return null;
        }
        private void btn_buscar_Click(object sender, EventArgs e)
        {
            txt_rutaArchivo.Text = ObtenerArchivo();

        }
    }
}
