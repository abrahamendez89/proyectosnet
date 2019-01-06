using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Herramientas.WPF
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
    }
}
