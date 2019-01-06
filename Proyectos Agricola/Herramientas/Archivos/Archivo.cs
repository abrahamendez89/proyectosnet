using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Herramientas.Archivos
{
    public class Archivo
    {
        public static String LeerArchivoTexto(String rutaArchivo)
        {
            if (!ExisteArchivo(rutaArchivo))
                return null;
            string[] lines = System.IO.File.ReadAllLines(rutaArchivo);
            String retorno = "";
            foreach (string line in lines)
            {
                retorno += line + "\n";
            }
            return retorno.Trim();
        }
        public static byte[] CargarArchivoAByteArray(String rutaArchivo)
        {
            return File.ReadAllBytes(rutaArchivo);
        }
        public static byte[] StringBase64ToByteArray(String cadena)
        {
            return Convert.FromBase64String(cadena);
        }
        public static String ArchivoAStringBase64(String rutaArchivo)
        {
            byte[] archivoBytes = CargarArchivoAByteArray(rutaArchivo);

            if (archivoBytes != null)
                return ByteArrayToStringBase64(archivoBytes);
            else
                return null;
        }
        public static byte[] StringBase64ABitmap(String stringBase64)
        {
            if (stringBase64 != null)
                return StringBase64ToByteArray(stringBase64);
            else
                return null;
        }
        public static String ByteArrayToStringBase64(byte[] byteArray)
        {
            return Convert.ToBase64String(byteArray);
        }
        public static void CopiarArchivo(String rutaArchivo, String rutaCopia)
        {
            try
            {
                System.IO.File.Copy(rutaArchivo, rutaCopia, true);
            }
            catch (Exception ex)
            {
                throw new Exception("Falló al copiar el archivo.", ex);
            }
        }
        public static List<String> ObtenerRutasArchivoDeDirectorio(String directorio, List<String> extensionesFiltro, Boolean recursivo)
        {
            if (!recursivo)
            {
                List<string> archivos = new List<string>();
                foreach (String extension in extensionesFiltro)
                    archivos.AddRange(Directory.GetFiles(directorio, "*.*", SearchOption.TopDirectoryOnly).Where(s => s.EndsWith(extension) && !Path.GetFileName(s).StartsWith("~$")).ToList());
                for (int i = 0; i < archivos.Count; i++)
                    archivos[i] = archivos[i].Trim();
                return archivos;
            }
            else
            {
                return recorridoRecursivo(directorio, extensionesFiltro);
            }
        }
        private static List<String> recorridoRecursivo(String directorio, List<String> extensionesFiltro)
        {
            List<String> archivos = new List<string>();
            List<String> carpetas = new List<string>();
            carpetas.AddRange(Directory.GetDirectories(directorio));

            foreach (String extension in extensionesFiltro)
                archivos.AddRange(Directory.GetFiles(directorio, "*.*", SearchOption.TopDirectoryOnly).Where(s => s.EndsWith(extension) && !Path.GetFileName(s).StartsWith("~$")).ToList());

            foreach (String carpeta in carpetas)
                archivos.AddRange(recorridoRecursivo(carpeta, extensionesFiltro));
            return archivos;
        }
        public static void GuardarArchivoDeTexto(String rutaArchivo, String contenido, Boolean SobreEscribir)
        {
            try
            {
                String carpeta = System.IO.Path.GetDirectoryName(rutaArchivo);
                CrearCarpetaSiNoExiste(carpeta);

                if (ExisteArchivo(rutaArchivo))
                {
                    if (SobreEscribir)
                    {
                        EliminarArchivo(rutaArchivo);
                        System.IO.File.WriteAllText(rutaArchivo, contenido);
                    }
                }
                else
                {
                    System.IO.File.WriteAllText(rutaArchivo, contenido);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void GuardarArchivoDeByteArray(String rutaArchivo, byte[] contenido, Boolean SobreEscribir)
        {
            try
            {
                String carpeta = System.IO.Path.GetDirectoryName(rutaArchivo);
                CrearCarpetaSiNoExiste(carpeta);

                if (ExisteArchivo(rutaArchivo))
                {
                    if (SobreEscribir)
                    {
                        EliminarArchivo(rutaArchivo);
                        System.IO.File.WriteAllBytes(rutaArchivo, contenido);
                    }
                }
                else
                {
                    System.IO.File.WriteAllBytes(rutaArchivo, contenido);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Boolean ExisteArchivo(String ruta)
        {
            return System.IO.File.Exists(ruta);
        }
        public static Boolean ExisteCarpeta(String ruta)
        {
            return System.IO.Directory.Exists(ruta);
        }
        public static void GuardarArchivoDeTexto(String rutaArchivo, String contenido)
        {
            GuardarArchivoDeTexto(rutaArchivo, contenido, true);
        }
        public static void GuardarArchivoDeByteArray(String rutaArchivo, byte[] contenido)
        {
            GuardarArchivoDeByteArray(rutaArchivo, contenido, true);
        }
        public static void EliminarArchivo(String rutaArchivo)
        {
            File.Delete(rutaArchivo);
        }
        public static MemoryStream ArchivoAMemoryStream(String dir)
        {
            System.IO.MemoryStream data = new System.IO.MemoryStream();
            System.IO.Stream str = File.OpenRead(dir);

            str.CopyTo(data);
            data.Seek(0, SeekOrigin.Begin);
            byte[] buf = new byte[data.Length];
            data.Read(buf, 0, buf.Length);
            data.Position = 0;
            return data;
        }

        public static void CrearCarpetaSiNoExiste(String ruta)
        {
            if (!ExisteCarpeta(ruta))
                System.IO.Directory.CreateDirectory(ruta);
        }
        public static String ObtenerNombreArchivo(String ruta)
        {
            return Path.GetFileName(ruta);
        }
        public static String ObtenerNombreCarpetaDeArchivo(String ruta)
        {
            return Path.GetDirectoryName(ruta);
        }
        public static String ObtenerNombreCarpetaDeDirectorio(String ruta)
        {
            return new System.IO.DirectoryInfo(ruta).Name;
        }
        public static String ObtenerSoloNombreCarpetaDeArchivo(String ruta)
        {
            String rutaC = ObtenerNombreCarpetaDeArchivo(ruta);
            String nombreCarpeta = rutaC.Replace(Path.GetDirectoryName(rutaC) + Path.DirectorySeparatorChar, "");
            return nombreCarpeta;
        }
        public static MemoryStream CargarArchivoAMemoria(String rutaArchivo)
        {
            try
            {
                return new MemoryStream(System.IO.File.ReadAllBytes(rutaArchivo));
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar el archivo a memoria.", ex);
            }
        }
    }
}
