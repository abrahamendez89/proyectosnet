using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace rompeClave
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Clipboard.SetText("asdsadasdasd");

            var proc = Process.GetProcessesByName("Sin titulo: Bloc de notas").FirstOrDefault();
            if (proc != null && proc.MainWindowHandle != IntPtr.Zero)
            {
                SetForegroundWindow(proc.MainWindowHandle);
                SendKeys.SendWait("asdasd");
                SendKeys.SendWait("{ENTER}");
                //   Clipboard.GetText();
            }
        }
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        public static void Start()
        {
            IntPtr zero = IntPtr.Zero;
            for (int i = 0; (i < 60) && (zero == IntPtr.Zero); i++)
            {
                Thread.Sleep(500);
                zero = FindWindow(null, "Sin titulo: Bloc de notas");
            }
            if (zero != IntPtr.Zero)
            {
                SetForegroundWindow(zero);
                SendKeys.SendWait("{TAB}");
                SendKeys.SendWait("{TAB}");
                SendKeys.SendWait("{ENTER}");
                SendKeys.Flush();
            }
        }

        public static String EjecutaShell(String linea)
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


                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit();

                mensajeError = process.StandardError.ReadToEnd();

                if (!mensajeError.Trim().Equals(""))
                    throw new Exception(mensajeError);

                return process.StandardOutput.ReadToEnd();

            }
            catch { return ""; }
        }
    }
}
