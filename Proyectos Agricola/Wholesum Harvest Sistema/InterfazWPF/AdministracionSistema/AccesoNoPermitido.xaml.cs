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
using Dominio;
using Herramientas.ORM;

namespace InterfazWPF.AdministracionSistema
{
    /// <summary>
    /// Lógica de interacción para AccesoNoPermitido.xaml
    /// </summary>
    public partial class AccesoNoPermitido : Window
    {
        ManejadorDB manejador;
        _sis_LimiteAccesosFallidosAlcanzado limiteAlcanzado;
        public AccesoNoPermitido()
        {
            try
            {
                InitializeComponent();
                manejador = new ManejadorDB();
                limiteAlcanzado = manejador.Cargar<_sis_LimiteAccesosFallidosAlcanzado>(_sis_LimiteAccesosFallidosAlcanzado.ConsultaAccesosFallidosNoVerificados);

                if (limiteAlcanzado == null)
                    return;

                txt_nombreEquipo.Text = limiteAlcanzado.AccesosFallidos[0].SNombreEquipo;
                txt_ip.Text = limiteAlcanzado.AccesosFallidos[0].SIPEquipo;
                txt_sesionWindows.Text = limiteAlcanzado.AccesosFallidos[0].SUsuarioWindows;
                txt_ipInternet.Text = limiteAlcanzado.AccesosFallidos[0].SIpInternet;

                foreach (_sis_AccesoFallido accesoFallido in limiteAlcanzado.AccesosFallidos)
                {
                    lb_intentosRegistrados.Items.Add("Usuario: '" + accesoFallido.SUsuarioRegistrado + "' | Contraseña: '" + accesoFallido.SContrasenaRegistrada + "'");
                }

                img_capturaWebcam.Source = HerramientasWindow.BitmapAImageSource(limiteAlcanzado.FotoWebCam.Imagen);
                img_capturaEscritorio.Source = HerramientasWindow.BitmapAImageSource(limiteAlcanzado.FotoPantalla.Imagen);
                this.Title += " el " + limiteAlcanzado.DtFechaCreacion.ToString("F");

                Closed += AccesoNoPermitido_Closed;
            }
            catch (Exception ex)
            {
                HerramientasWindow.MensajeError(ex,ex.Message,"Error");
            }
        }

        void AccesoNoPermitido_Closed(object sender, EventArgs e)
        {
            try
            {
                limiteAlcanzado.EsModificado = true;
                limiteAlcanzado.BFueVerificadaNotificacion = true;

                manejador.Guardar(limiteAlcanzado);
            }
            catch (Exception ex)
            {
                HerramientasWindow.MensajeError(ex, ex.Message, "Error");
            }
        }

        private void img_capturaWebcam_MouseDown(object sender, MouseButtonEventArgs e)
        {
            HerramientasWindow.MostrarImagenEnVisor(img_capturaWebcam.Source);
        }

        private void img_capturaEscritorio_MouseDown(object sender, MouseButtonEventArgs e)
        {
            HerramientasWindow.MostrarImagenEnVisor(img_capturaEscritorio.Source);
        }
    }
}
