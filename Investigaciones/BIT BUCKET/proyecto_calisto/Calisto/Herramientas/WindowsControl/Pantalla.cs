using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Herramientas.WindowsControl
{
    public class Pantalla
    {
        public static Bitmap ObtenerFotoPantallaPrincipal()
        {
            Bitmap foto = null;
            try
            {
                foto = Herramientas.Archivos.Imagenes.ObtenerFotoPantallaPrincipal();
            }
            catch
            {
                foto = null;
            }
            return foto;
        }
        public static Bitmap ObtenerFotoPantallaPrincipalConCursor()
        {
            Bitmap foto = null;
            try
            {
                foto = Herramientas.Archivos.Imagenes.ObtenerFotoPantallaPrincipalConCursor();
            }
            catch
            {
                foto = null;
            }
            return foto;
        }
        public static List<Bitmap> ObtenerFotoPantallas()
        {
            try
            {
                return Herramientas.Archivos.Imagenes.ObtenerFotoPantallas();
            }
            catch
            {
                return null;
            }
        }
        public static List<Bitmap> ObtenerFotoPantallasConCursor()
        {
            try
            {
                return Herramientas.Archivos.Imagenes.ObtenerFotoPantallasConCursor();
            }
            catch
            {
                return null;
            }
        }
    }
}
