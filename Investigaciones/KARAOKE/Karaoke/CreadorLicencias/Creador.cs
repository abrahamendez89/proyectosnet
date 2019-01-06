using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Karaoke.Clases;

namespace CreadorLicencias
{
    public partial class Creador : Form
    {
        IdentificadorLicencia lic;
        public Creador()
        {
            InitializeComponent();
            dtp_FechaPago.Value = DateTime.Now;
            dtp_fecCaducidad.MinDate = DateTime.MinValue;
            dtp_fecCaducidad.MaxDate = DateTime.MaxValue;

            dtp_FechaPago.MinDate = DateTime.MinValue;
            dtp_FechaPago.MaxDate = DateTime.MaxValue;

            dtp_FecPrimeraVez.MinDate = DateTime.MinValue;
            dtp_FecPrimeraVez.MaxDate = DateTime.MaxValue;

            Herramientas.Forms.Validaciones.TextboxSoloNumerosEnteros(txt_idLicencia);
            Herramientas.Forms.Validaciones.TextboxSoloNumerosEnteros(txt_meses);
            txt_meses.Text = "0";
        }
        private void CargarDatosLicencia()
        {
            if (lic.IDLicencia == -1)
            {
                txt_idLicencia.ReadOnly = false;
            }
            txt_mac.Text = lic.MAC;
            txt_nombreEquipo.Text = lic.NombreEquipo;
            txt_usuarioWindows.Text = lic.UsuarioWindows;
            txt_versionWindows.Text = lic.VersionWindows;
            txt_idTarjetaMadre.Text = lic.IDTarjetaMADRE;
            try
            {
                dtp_FecPrimeraVez.Value = lic.FechaPrimeraVez;
            }
            catch
            {
                dtp_FecPrimeraVez.Value = dtp_FecPrimeraVez.MinDate;
            }
            try
            {
                dtp_fecCaducidad.Value = lic.FechaFIN;
            }
            catch
            {
                dtp_fecCaducidad.Value = dtp_FecPrimeraVez.MinDate;
            }
            txt_idLicencia.Text = lic.IDLicencia.ToString();
            try
            {
                dtp_FechaPago.Value = lic.FechaPago;
            }
            catch
            {
                dtp_FechaPago.Value = dtp_FecPrimeraVez.MinDate;
            }
        }
        private void ModificarLicencia()
        {
            lic.FechaFIN = dtp_fecCaducidad.Value;
            lic.FechaPago = DateTime.Now;
            lic.IDLicencia = Convert.ToInt32(txt_idLicencia.Text);
        }
        private void btn_buscar_Click(object sender, EventArgs e)
        {
            String archivo = Herramientas.Archivos.Dialogos.BuscarArchivo(new List<string>() { "Archivo key" }, new List<string>() { "key" });

            if (archivo != null && !archivo.Equals(""))
            {
                txt_rutaLicencia.Text = Herramientas.Archivos.Archivo.ObtenerNombreArchivo(archivo);

                String cifrado = Herramientas.Archivos.Archivo.LeerArchivoTexto(archivo);
                String decifrado = Herramientas.Cifrado.CifradoAES.DesencriptarTexto(cifrado);
                lic = Herramientas.Web.JSON.ConvertirJSONAObjeto<IdentificadorLicencia>(decifrado);

                CargarDatosLicencia();


            }
        }

        private void btn_generarLicencia_Click(object sender, EventArgs e)
        {
            if (lic == null)
            {
                Herramientas.Forms.Mensajes.Advertencia("Necesitas cargar un archivo key primero.");
                return;
            }

            ModificarLicencia();

            String carpeta = Herramientas.Archivos.Dialogos.BuscarCarpeta(null);

            if (carpeta != null && !carpeta.Equals(""))
            {

                String json = Herramientas.Web.JSON.ConvertirObjetoAJSON<IdentificadorLicencia>(lic);
                String cifrado2 = Herramientas.Cifrado.CifradoAES.EncriptarTexto(json);
                String ruta = carpeta + "\\" + txt_rutaLicencia.Text.Replace("key", "karalicence");
                Herramientas.Archivos.Archivo.GuardarArchivoDeTexto(ruta, cifrado2);

                Herramientas.Forms.Mensajes.Informacion("Licencia generada correctamente en: " + ruta + " .");
            }
        }

        private void btn_actualizarFechaPAgo_Click(object sender, EventArgs e)
        {
            dtp_FechaPago.Value = DateTime.Now;
        }

        private void btn_sumarMeses_Click(object sender, EventArgs e)
        {
            if (txt_meses.Text.Trim().Equals(""))
            {
                Herramientas.Forms.Mensajes.Advertencia("Debe asignar los meses a sumar a la licencia.");
                return;
            }
            dtp_fecCaducidad.Value = dtp_FechaPago.Value;
            dtp_fecCaducidad.Value = dtp_fecCaducidad.Value.AddMonths(Convert.ToInt32(txt_meses.Text));
        }


    }
}
