using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CompresorImagenes.Archivos
{
    public class Log
    {
        public static String UbicacionArchivo = "";
        public static void EscribirLog(String evento)
        {
            StreamWriter log;
            if (UbicacionArchivo.Trim().Equals("")) UbicacionArchivo = "log.txt";
            if (!File.Exists(UbicacionArchivo))
            {
                log = new StreamWriter(UbicacionArchivo);
            }
            else
            {
                log = File.AppendText(UbicacionArchivo);
            }
            log.WriteLine(String.Format("{0:u}", DateTime.Now)+": "+evento);
            log.Close();
        }
    }
}
