using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace VisorXMLFacturas
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
            if (args.Length > 0)
            {
                AllocConsole();

                if (args[0].Equals("/help"))
                {
                    Console.WriteLine("Parametros esperados: Responsable Ruta XML con espacios.");
                    Console.WriteLine(@"Ejemplo: Juan c:\carpeta 1\archivo.xml");
                    Console.ReadLine();
                    return;
                }


                Console.WriteLine("Procesando a través de linea de comandos.");
                try
                {
                    String ruta = "";
                    for(int i = 1; i < args.Length; i++)
                        ruta += args[i] + " ";
                    Console.WriteLine("Factura: "+ruta);
                    ProcesamientoCFDI.ProcesarXML(args[0].Replace("_"," "), ruta);
                    Console.WriteLine("Generado correctamente.");
                    Console.ReadLine();
                    return;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    Console.WriteLine("Parametros esperados: Responsable Ruta XML con espacios.");
                    Console.WriteLine(@"Ejemplo: Juan_Perez c:\carpeta 1\archivo.xml");
                    Console.ReadLine();
                }
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Login());
            }
        }
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
    }
}
