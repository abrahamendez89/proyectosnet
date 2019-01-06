using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ionic.Zip;

namespace Herramientas.Archivos
{
    public class Zip
    {
        public static void ComprimirArchivosEnZip(List<String> archivos, String rutaArchivoZip)
        {
            ZipFile zip = new ZipFile();
            zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression;
            foreach (String archivo in archivos)
                zip.AddFile(archivo,@"\");

            zip.Save(rutaArchivoZip);  
        }
        public static void ComprimirDirectorioEnZip(String directorio, String rutaArchivoZip)
        {
            ZipFile zip = new ZipFile();
            zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression;
            zip.AddDirectory(directorio);
            zip.Save(rutaArchivoZip);
        }
    }
}
