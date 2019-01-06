using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneDrive
{
    public partial class frm_drive : Form
    {

        String Token = "";
        static readonly string[] SizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
        public frm_drive()
        {
            InitializeComponent();

        }
        private void GetInfo()
        {
            Peticion nueva = new Peticion();
            nueva.Metodo = "GET";
            nueva.Token = Token;
            nueva.UrlPeticion = "/Drive";
            dynamic drive = nueva.HacerPeticion();
            lbl_usuario.Text = "Usuario :" + drive.owner.user.displayName;
            lbl_espacio.Text = "Espacio :" + SizeSuffix(Convert.ToInt64(drive.quota.total));
            lbl_disponible.Text = "Disponible :" + SizeSuffix(Convert.ToInt64(drive.quota.remaining));
            lbl_userID.Text = "ID Usuario:" + drive.owner.user.id;

        }
        private String ObtenerSesionParaArchivoGrande(String nombreArchivo, String carpetaID)
        {
            Peticion nueva = new Peticion();
            nueva.Metodo = "POST";
            nueva.Token = this.Token;
            nueva.ContentType1 = "application/json";
            nueva.UrlPeticion = "/drive/items/{parent_item_id}:/{filename}:/upload.createSession".Replace("{parent_item_id}", carpetaID).Replace("{filename}", nombreArchivo);
            String jsonTemp = "{\"item\": {\"@name.conflictBehavior\": \"rename\",\"name\": \"@NombreArchivoSubirGrande\"}}".Replace("@NombreArchivoSubirGrande", nombreArchivo);
            nueva.ByteDATA = System.Text.Encoding.ASCII.GetBytes(jsonTemp);
            dynamic drive = nueva.HacerPeticion();
            return drive.uploadUrl;

        }
        private void SubirFragmentoDeArchivoGrande(byte[] fragmento, String urlSession, long indiceDesde, long totalBytes)
        {
            Peticion nueva = new Peticion();
            nueva.Metodo = "PUT";
            nueva.Token = Token;
            //nueva.ContentType1 = "application/octet-stream";
            nueva.ByteDATA = fragmento;

            dynamic drive = nueva.HacerPeticion(urlSession, indiceDesde, totalBytes);

        }
        private void frm_drive_Load(object sender, EventArgs e)
        {
            Token = frm_login.Token;
            GetInfo();
        }

        private String CrearCarpeta(String nombreCarpeta)
        {
            Peticion nueva = new Peticion();
            nueva.Metodo = "POST";
            nueva.Token = Token;
            nueva.ContentType1 = "application/json";
            nueva.UrlPeticion = "/drive/root/children";
            String jsonTemp = "{\"name\": \"@folderCrear\", \"folder\": { },\"@name.conflictBehavior\": \"rename\"}".Replace("@folderCrear", nombreCarpeta);
            nueva.ByteDATA = System.Text.Encoding.ASCII.GetBytes(jsonTemp);
            dynamic drive = nueva.HacerPeticion();
            return drive.id;

        }
        private void BuscarCarpeta(String carpetaCrear)
        {
            String id = "";
            Peticion nueva = new Peticion();
            nueva.Metodo = "GET";
            nueva.Token = Token;
            nueva.ContentType1 = "application/json";
            nueva.UrlPeticion = "/drive/root/children/" + carpetaCrear;

            try
            {
                dynamic drive = nueva.HacerPeticion();
                id = drive.id;
            }
            catch { }


            if (id.Equals(""))
            {
                lbl_SessionID.Text = CrearCarpeta(carpetaCrear);
            }
            else
                lbl_SessionID.Text = id;

        }
        private void SubirArchivo(String rutaArchivo, String FolderID)
        {
            Peticion nueva = new Peticion();
            nueva.Metodo = "PUT";
            nueva.Token = Token;
            nueva.ContentType1 = "application/octet-stream";
            nueva.ByteDATA = File.ReadAllBytes(rutaArchivo);
            nueva.UrlPeticion = "/drive/items/" + FolderID + "/children/@nombreArchivo/content".Replace("@nombreArchivo", Herramientas.Archivos.Archivo.ObtenerNombreArchivo(rutaArchivo));

            dynamic drive = nueva.HacerPeticion();
        }
        private void SubirArchivo(String nombreArchivo, byte[] bytesArchivo, String FolderID)
        {
            Peticion nueva = new Peticion();
            nueva.Metodo = "PUT";
            nueva.Token = Token;
            nueva.ContentType1 = "application/octet-stream";
            nueva.ByteDATA = bytesArchivo;
            nueva.UrlPeticion = "/drive/items/" + FolderID + "/children/@nombreArchivo/content".Replace("@nombreArchivo", nombreArchivo);

            dynamic drive = nueva.HacerPeticion();
        }
        private string SizeSuffix(Int64 value)
        {
            if (value < 0) { return "-" + SizeSuffix(-value); }
            if (value == 0) { return "0.0 bytes"; }

            int mag = (int)Math.Log(value, 1024);
            decimal adjustedSize = (decimal)value / (1L << (mag * 10));

            return string.Format("{0:n1} {1}", adjustedSize, SizeSuffixes[mag]);
        }

        private void SubirArchivoPorFragmentos(String rutaArchivo, String FolderID)
        {
            long longitudFragmento = 5 * 1024 * 1024;
            String nombreArchivo = Herramientas.Archivos.Archivo.ObtenerNombreArchivo(rutaArchivo);

            byte[] archivoBytes = File.ReadAllBytes(rutaArchivo);

            if (archivoBytes.Length > longitudFragmento)
            {
                String urlSession = ObtenerSesionParaArchivoGrande(nombreArchivo, FolderID);
                for (long i = 0; i < archivoBytes.Length; i++)
                {
                    byte[] fragmento = null;
                    if (archivoBytes.Length - i > longitudFragmento)
                        fragmento = new byte[longitudFragmento];
                    else
                    {
                        fragmento = new byte[archivoBytes.Length - i];
                        longitudFragmento = archivoBytes.Length - i;
                    }
                    int indice = 0;
                    for (; indice < longitudFragmento; indice++)
                    {
                        if (i == archivoBytes.Length)
                            break;
                        fragmento[indice] = archivoBytes[i];
                        i++;
                    }
                    SubirFragmentoDeArchivoGrande(fragmento, urlSession, i - longitudFragmento, archivoBytes.Length);
                    i--;
                }
            }
            else
            {
                SubirArchivo(nombreArchivo, archivoBytes, FolderID);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txt_nombreCarpeta.Text.Trim().Equals(""))
            {
                Herramientas.Forms.Mensajes.Informacion("Escriba un nombre de carpeta");
                return;
            }
            else
            {
                BuscarCarpeta(txt_nombreCarpeta.Text);
            }
            String rutaARchivo = Herramientas.Archivos.Dialogos.BuscarArchivo(null, null);

            if (rutaARchivo != null)
            {
                //SubirArchivo(rutaARchivo, lbl_SessionID.Text);

                SubirArchivoPorFragmentos(rutaARchivo, lbl_SessionID.Text);
            }


        }


    }
}
