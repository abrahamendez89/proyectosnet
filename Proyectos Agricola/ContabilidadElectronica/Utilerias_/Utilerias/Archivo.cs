using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilerias.Utilerias
{
    public class Archivo
    {
        public static String CargarArchivo(String ruta)
        {
            System.IO.StreamReader myFile = new System.IO.StreamReader(ruta);
            string myString = myFile.ReadToEnd();
            myFile.Close();

            return myString;
        }
    }
}
