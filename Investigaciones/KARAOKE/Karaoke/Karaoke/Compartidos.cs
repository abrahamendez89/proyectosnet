using Herramientas.Archivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karaoke
{
    public class Compartidos
    {
        static Variable configuracion;
        static Variable contenido;
        static Variable masReproducidosKaraoke;
        static Variable masReproducidosVideos;
        static Variable masReproducidosMusica;
        static Variable listaReproduccion;
        public static Variable ObtenerVariablesConfiguracion()
        {
            if (configuracion == null)
            {
                configuracion = new Variable("datac");
            }
            configuracion.LeerArchivo();
            return configuracion;
        }
        public static Variable ObtenerVariablesContenido()
        {
            if (contenido == null)
            {
                contenido = new Variable("data");
            }
            contenido.LeerArchivo();
            return contenido;
        }
        public static Variable ObtenerVariablesTopKaraoke()
        {
            if (masReproducidosKaraoke == null)
            {
                masReproducidosKaraoke = new Variable("datak");
            }
            masReproducidosKaraoke.LeerArchivo();
            return masReproducidosKaraoke;
        }
        public static Variable ObtenerVariablesTopVideos()
        {
            if (masReproducidosVideos == null)
            {
                masReproducidosVideos = new Variable("datav");
            }
            masReproducidosVideos.LeerArchivo();
            return masReproducidosVideos;
        }
        public static Variable ObtenerVariablesTopMusica()
        {
            if (masReproducidosMusica == null)
            {
                masReproducidosMusica = new Variable("datam");
            }
            masReproducidosMusica.LeerArchivo();
            return masReproducidosMusica;
        }
        public static Variable ObtenerVariablesListaReproduccion()
        {
            if (listaReproduccion == null)
            {
                listaReproduccion = new Variable("datal");
            }
            listaReproduccion.LeerArchivo();
            return listaReproduccion;
        }
    }
}
