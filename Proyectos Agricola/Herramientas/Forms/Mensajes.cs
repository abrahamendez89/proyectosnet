using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Herramientas.Forms
{
    public class Mensajes
    {
        public static void Informacion(String mensaje)
        {
            MessageBox.Show(mensaje,"Información", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public static void Error(String mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public static void Exclamacion(String mensaje)
        {
            MessageBox.Show(mensaje, "Atención!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }
        public static void Advertencia(String mensaje)
        {
            MessageBox.Show(mensaje, "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        public static Boolean PreguntaAdvertenciaSIoNO(String pregunta)
        {
            if (MessageBox.Show(pregunta, "Atención!!!", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                return true;
            else
                return false;
        }
    }
}
