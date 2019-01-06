using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Dominio.Sistema;
using System.Drawing;
using Dominio;
using Herramientas.ORM;

namespace InterfazWPF.AdministracionSistema
{
    /// <summary>
    /// Lógica de interacción para ConfiguracionUsuario.xaml
    /// </summary>
    public partial class ConfiguracionUsuario : Window
    {
        private Boolean seCargoFoto;
        private _sis_Usuario usuario;
        private ManejadorDB manejador;
        public ConfiguracionUsuario(_sis_Usuario usuario)
        {
            InitializeComponent();
            try
            {
                manejador = new ManejadorDB();
                this.usuario = usuario;
                this.usuario.EliminarCache();
                Bitmap foto = new Bitmap(@"Imagenes\Iconos\Sistema\usuario.png");
                if (usuario.ImagenAsociada != null && usuario.ImagenAsociada.Imagen != null)
                    foto = usuario.ImagenAsociada.Imagen;
                img_fotoUsuario.Source = HerramientasWindow.BitmapAImageSource(foto);
                lbl_cuentaUsuario.Content = usuario.Cuenta;
                txt_nombre.Text = usuario.SNombreCompleto;
            }
            catch (Exception ex)
            {
                HerramientasWindow.MensajeError(ex,ex.Message, "Error");
            }
        }

        private void btn_aceptar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if ((Boolean)chb_cambiarContrase.IsChecked)
                {
                    if (HerramientasWindow.EncriptarConAES(txt_contraAnterior.Password).Equals(usuario.Contrasena))
                    {
                        if (txt_contraNueva.Password.Equals(txt_contraConfirmacion.Password))
                        {
                            usuario.Contrasena = HerramientasWindow.EncriptarConAES(txt_contraNueva.Password);
                        }
                        else
                        {
                            HerramientasWindow.MensajeErrorSimple("La contraseña nueva y su confirmación no son iguales.", "contraseña incorrecta");
                            return;
                        }
                    }
                    else
                    {
                        HerramientasWindow.MensajeErrorSimple("La contraseña anterior es incorrecta.", "contraseña incorrecta");
                        return;
                    }
                }
                usuario.SNombreCompleto = txt_nombre.Text;
                if (seCargoFoto)
                {
                    usuario.ImagenAsociada.EsModificado = true;
                    usuario.ImagenAsociada.Imagen = HerramientasWindow.ComprimirImagen(HerramientasWindow.ImageSourceABitmap(img_fotoUsuario.Source, System.Drawing.Imaging.ImageFormat.Jpeg), 128, 128, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                usuario.EsModificado = true;
               
                manejador.Guardar(usuario);
                HerramientasWindow.MensajeInformacion("Se guardó correctamente la cuenta de usuario.", "Guardado exitoso");
                Close();
            }
            catch (Exception ex)
            {
                HerramientasWindow.MensajeError(ex,ex.Message, "Error");
            }
            
        }

        private void img_fotoUsuario_MouseDown(object sender, MouseButtonEventArgs e)
        {

            Bitmap foto = new Bitmap(@"Imagenes\Iconos\Sistema\usuario.png");

            BitmapSource nuevaFoto = HerramientasWindow.CargarImagenDeArchivosABitmapSource();

            if (nuevaFoto != null)
            {
                img_fotoUsuario.Source = nuevaFoto;
                seCargoFoto = true;
            }
            else if(usuario.ImagenAsociada == null || usuario.ImagenAsociada.Imagen == null)
            {
                img_fotoUsuario.Source = HerramientasWindow.BitmapAImageSource(foto);
                seCargoFoto = false;
            }

        }

        private void chb_cambiarContrase_Checked(object sender, RoutedEventArgs e)
        {
            txt_contraAnterior.IsEnabled = true;
            txt_contraNueva.IsEnabled = true;
            txt_contraConfirmacion.IsEnabled = true;
        }

        private void chb_cambiarContrase_Unchecked(object sender, RoutedEventArgs e)
        {
            txt_contraAnterior.IsEnabled = false;
            txt_contraNueva.IsEnabled = false;
            txt_contraConfirmacion.IsEnabled = false;
        }

        private void btn_cancelar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
