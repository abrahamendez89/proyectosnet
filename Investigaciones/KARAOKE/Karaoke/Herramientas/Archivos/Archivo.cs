using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Herramientas.Archivos
{
    public class Archivo
    {
        public static String LeerArchivoTexto(String rutaArchivo)
        {
            string[] lines = System.IO.File.ReadAllLines(rutaArchivo);
            String retorno = "";
            foreach (string line in lines)
            {
                retorno += line + "\n";
            }
            return retorno;
        }
    }
}
