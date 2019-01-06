using Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HotelAdmin
{
    public partial class Login : Form
    {
        public _Usuario UsuarioLogueado { get; set; }
        public Login()
        {
            InitializeComponent();
            UsuarioLogueado = new _Usuario();
            UsuarioLogueado.St_permisosModulos = "Configuraciones|Catálogos|Sistema";
            pb_foto.Image = Herramientas.WebCam.Foto.ObtenerFotoDeWebCam();

            List<Bitmap> fotosPantallas = Herramientas.WindowsControl.Pantalla.ObtenerFotoPantallasConCursor();
            int c = 0;
            foreach (Bitmap bmp in fotosPantallas)
            {
                Herramientas.Archivos.Imagenes.GuardarImagenEnArchivo("", "imagen_" + c, bmp, Herramientas.Archivos.Imagenes.Formato.JPEG);
                c++;
            }

        }

        private void btn_Entrar_Click(object sender, EventArgs e)
        {
            UsuarioLogueado = Principal.usuarioCtrl.LoginUsuario(txt_usuario.Text.Trim(), txt_contrasena.Text);
            if (UsuarioLogueado == null)
                Herramientas.Forms.Mensajes.Exclamacion("Usuario o contraseña invalidos");
            else
                Hide();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            UsuarioLogueado = null;
            Hide();
        }

        private void btn_olvideContra_Click(object sender, EventArgs e)
        {
            //enviar correo a los admin
        }
    }
}
