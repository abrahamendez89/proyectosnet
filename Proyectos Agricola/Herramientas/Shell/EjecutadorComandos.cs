using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Herramientas.Shell
{
    public class EjecutadorComandos
    {
        public static String EjecutarArchivoBAT(String ruta)
        {
            String mensajeRetorno = "";
            try
            {
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo("cmd.exe", "/c "+ruta.Trim());
                startInfo.WindowStyle = ProcessWindowStyle.Normal;
                //startInfo.FileName = ruta;
                //startInfo.Verb = "runas";
                //startInfo.Arguments = "/c " + linea;
                //startInfo.RedirectStandardOutput = true;
                //startInfo.RedirectStandardError = true;
                //startInfo.UseShellExecute = false;
                startInfo.CreateNoWindow = true;

                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit();

                //String mensajeError = process.StandardError.ReadToEnd();
                //String mensajeResultado = process.StandardOutput.ReadToEnd();
                //if (!mensajeError.Trim().Equals(""))
                //{
                //    mensajeRetorno  = "ERROR: "+ mensajeError;
                //    return mensajeRetorno;
                //}
                //if (!mensajeResultado.Trim().Equals(""))
                //{
                //    mensajeRetorno = mensajeResultado;
                //    return mensajeRetorno;
                //}
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static String EjecutaComando(String linea)
        {
            String mensajeError = "";
            try
            {
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Verb = "runas";
                startInfo.Arguments = "/c " + linea;
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardError = true;
                startInfo.UseShellExecute = false;
                startInfo.CreateNoWindow = true;

                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit();

                mensajeError = process.StandardError.ReadToEnd();

                if (!mensajeError.Trim().Equals(""))
                {
                    //throw new Exception(mensajeError);
                    return mensajeError;
                }

                return ""; // process.StandardOutput.ReadToEnd();

            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message + " CMD: " + mensajeError);
                return ex.Message;
            }
        }
    }
}
