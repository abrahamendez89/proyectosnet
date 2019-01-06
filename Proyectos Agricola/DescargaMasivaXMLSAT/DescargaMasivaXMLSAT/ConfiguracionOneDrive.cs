using Herramientas.Archivos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DescargaMasivaXMLSAT
{
    public partial class ConfiguracionOneDrive : Form
    {
        Variable var;
        public ConfiguracionOneDrive()
        {
            InitializeComponent();
            var = new Variable("configuracion.conf");
            txt_cuenta.Text = var.ObtenerValorVariable<String>("CUENTA_ONEDRIVE");
            txt_contra.Text = Herramientas.Cifrado.CifradoMD5.DesencriptarTexto(var.ObtenerValorVariable<String>("CONTRASEÑA_ONEDRIVE"));
            txt_ruta.Text = var.ObtenerValorVariable<String>("RUTA_ONEDRIVE");
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            var.GuardarValorVariable("CUENTA_ONEDRIVE", txt_cuenta.Text.Trim());
            var.GuardarValorVariable("CONTRASEÑA_ONEDRIVE",Herramientas.Cifrado.CifradoMD5.EncriptarTexto(txt_contra.Text.Trim()));
            var.GuardarValorVariable("RUTA_ONEDRIVE", txt_ruta.Text.Trim());
            var.ActualizarArchivo();
            Herramientas.Forms.Mensajes.Informacion("Configuración realizada con éxito.");
        }


    }
}
