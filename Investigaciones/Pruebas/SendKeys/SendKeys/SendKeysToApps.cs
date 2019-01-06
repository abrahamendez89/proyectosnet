using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Utilerias.Utilerias;

namespace SendKeys
{
    public partial class SendKeysToApps : Form
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public SendKeysToApps()
        {
            InitializeComponent();
            //rbManual.Checked = true;
            //cboWindows.Visible = false;
            //txtTitle.Text = "Sin título: Bloc de notas";
            //this.VisibleChanged += SendKeysToApps_VisibleChanged;
            CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += SendKeysToApps_FormClosing;
            this.txt_cantidadCaracteres.KeyPress += txt_cantidadCaracteres_KeyPress;
            this.txt_tiempoRetardo.KeyPress += txt_cantidadCaracteres_KeyPress;
        }

        void txt_cantidadCaracteres_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        void SendKeysToApps_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Process proceso in Process.GetProcesses())
            {

                if (proceso.ProcessName.ToLower().Equals("sendkeys"))
                {

                    proceso.Kill();

                }

            }
            Application.Exit();
        }

        void SendKeysToApps_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {

            }
        }


        private void SendKeysToApps_Load(object sender, EventArgs e)
        {
            //Getting windows titles of all top level application
            RefreshWindows();
            lb_comandosTeclas.Items.Add("{SECUENCIA}");
            lb_comandosTeclas.Items.Add("{ENTER}");
            //Adding capital alphbets in the 'All Keys' listbox
            for (int i = 65; i < 91; i++)
            {
                lb_comandosTeclas.Items.Add(Convert.ToChar(i).ToString());
            }

            //Adding all SendKeys class supported keys in the 'All Keys' listbox
            lb_comandosTeclas.Items.Add("{BS}");
            lb_comandosTeclas.Items.Add("{BREAK}");
            lb_comandosTeclas.Items.Add("{CAPSLOCK}");
            lb_comandosTeclas.Items.Add("{DEL}");
            lb_comandosTeclas.Items.Add("{DOWN}");
            lb_comandosTeclas.Items.Add("{END}");

            lb_comandosTeclas.Items.Add("{ESC}");
            lb_comandosTeclas.Items.Add("{HELP}");
            lb_comandosTeclas.Items.Add("{HOME}");
            lb_comandosTeclas.Items.Add("{INSERT}");
            lb_comandosTeclas.Items.Add("{LEFT}");
            lb_comandosTeclas.Items.Add("{NUMLOCK}");
            lb_comandosTeclas.Items.Add("PGDN}");
            lb_comandosTeclas.Items.Add("{PGUP}");
            lb_comandosTeclas.Items.Add("{PRTSC}");
            lb_comandosTeclas.Items.Add("{RIGHT}");
            lb_comandosTeclas.Items.Add("{SCROLLLOCK}");
            lb_comandosTeclas.Items.Add("{SPACE}");
            lb_comandosTeclas.Items.Add("{TAB}");
            lb_comandosTeclas.Items.Add("{UP}");
            lb_comandosTeclas.Items.Add("{F1}");
            lb_comandosTeclas.Items.Add("{F2}");
            lb_comandosTeclas.Items.Add("{F3}");
            lb_comandosTeclas.Items.Add("{F4}");
            lb_comandosTeclas.Items.Add("{F5}");
            lb_comandosTeclas.Items.Add("{F6}");
            lb_comandosTeclas.Items.Add("{F7}");
            lb_comandosTeclas.Items.Add("{F8}");
            lb_comandosTeclas.Items.Add("{F9}");
            lb_comandosTeclas.Items.Add("{F10}");
            lb_comandosTeclas.Items.Add("{F11}");
            lb_comandosTeclas.Items.Add("{F12}");
            lb_comandosTeclas.Items.Add("{F13}");
            lb_comandosTeclas.Items.Add("{F14}");
            lb_comandosTeclas.Items.Add("{F15}");
            lb_comandosTeclas.Items.Add("{F16}");
            lb_comandosTeclas.Items.Add("{ADD}");
            lb_comandosTeclas.Items.Add("{SUBTRACT}");
            lb_comandosTeclas.Items.Add("{MULTIPLY}");
            lb_comandosTeclas.Items.Add("{DIVIDE}");

            lb_comandosTeclas.Items.Add("SHIFT (+)");
            lb_comandosTeclas.Items.Add("CTRL (^)");
            lb_comandosTeclas.Items.Add("ALT (%)");

            //Adding number keys in the 'All Keys' listbox
            for (int i = 0; i < 10; i++)
                lb_comandosTeclas.Items.Add(Convert.ToString(i));

        }

        /// <summary>
        /// Closing the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDone_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Refresh the combobox list with all the top level windows running on desktop.
        /// </summary>
        private void RefreshWindows()
        {
            cboWindows.Items.Clear();
            GetTaskWindows();



        }

        /// <summary>
        /// Allows combobox and textbox switching on selection of Auto and Manual.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OptionSelection(object sender, EventArgs e)
        {
            if (rbAuto.Checked == true)
            {
                cboWindows.Visible = true;
                txtTitle.Text = cboWindows.Text;
                txtTitle.Visible = false;
            }
            else
            {
                cboWindows.Visible = false;
                txtTitle.Text = cboWindows.Text;
                txtTitle.Visible = true;
            }
        }

        /// <summary>
        /// Add selected keys from 'All Keys' listbox to 'Keys to Send' listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            lb_acciones2.Items.Add(lb_comandosTeclas.SelectedItem.ToString());
        }

        /// <summary>
        /// Refill the combobox with the currently running top level windows applications.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkRefresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RefreshWindows();
        }
        /// <summary>
        /// Get all the top level visible windows
        /// </summary>
        private void GetTaskWindows()
        {
            // Get the desktopwindow handle
            int nDeshWndHandle = NativeWin32.GetDesktopWindow();
            // Get the first child window
            int nChildHandle = NativeWin32.GetWindow(nDeshWndHandle, NativeWin32.GW_CHILD);

            while (nChildHandle != 0)
            {
                //If the child window is this (SendKeys) application then ignore it.
                if (nChildHandle == this.Handle.ToInt32())
                {
                    nChildHandle = NativeWin32.GetWindow(nChildHandle, NativeWin32.GW_HWNDNEXT);
                }

                // Get only visible windows
                if (NativeWin32.IsWindowVisible(nChildHandle) != 0)
                {
                    StringBuilder sbTitle = new StringBuilder(1024);
                    // Read the Title bar text on the windows to put in combobox
                    NativeWin32.GetWindowText(nChildHandle, sbTitle, sbTitle.Capacity);
                    String sWinTitle = sbTitle.ToString();
                    {
                        if (sWinTitle.Length > 0)
                        {
                            cboWindows.Items.Add(sWinTitle);
                        }
                    }
                }
                // Look for the next child.
                nChildHandle = NativeWin32.GetWindow(nChildHandle, NativeWin32.GW_HWNDNEXT);
            }
        }
        private char obtenSiguiente(char actual)
        {
            int caracter = (int)actual + 1;
            if (caracter == 58)
            {
                caracter = 65;
            }
            if (caracter == 91)
            {
                caracter = 97;
            }
            if (caracter == 123)
            {
                caracter = 123;
            }
            return (char)(caracter);
        }
        int contadorErrores = 0;
        private void EnviarTeclaOComando(String teclaComando)
        {
            try
            {
                int iHandle = NativeWin32.FindWindow(null, txtTitle.Text);
                //if (iHandle == 0)
                //{
                //    EmailFormatos.EnviarMailInformacion("Código encontrado es: " + armada, "ENCONTRADO!!", "abrahamendez89@hotmail.com", null);
                //    Mensajes.Informacion("Código encontrado es: " + armada, "ENCONTRADO!");
                //}
                //else
                //{
                    NativeWin32.SetForegroundWindow(iHandle);
                    if(!teclaComando.Contains("{"))
                        txt_probando.Text = teclaComando;
                    System.Windows.Forms.SendKeys.SendWait(teclaComando);
                    contadorErrores = 0;
                //}
            }
            catch 
            {
                if (contadorErrores == 3)
                {
                    EmailFormatos.EnviarMailInformacion("Código encontrado es: " + armada, "ENCONTRADO!!", "abrahamendez89@hotmail.com", null);
                    Mensajes.Informacion("Código encontrado es: " + armada, "ENCONTRADO!");
                }
                contadorErrores++;
            }
        }
        String armada = "";
        private void Ejecutar()
        {
            Boolean ultimo = false;
            int cantidadCaraceres = Convert.ToInt32(txt_cantidadCaracteres.Text);


            //for (int c = 0; c < cantidadCaraceres; c++)
            armada += "0";
            int totalCiclos = (int)Math.Pow(62, cantidadCaraceres);
            char[] formada = armada.ToCharArray();
            for (int w = 0; w < totalCiclos; w++)
            {
                for (int i = 0; i < 62; i++)
                {
                    foreach (String item in lb_acciones2.Items)
                    {
                        if (item.Equals("{SECUENCIA}"))
                        {
                            EnviarTeclaOComando(armada);
                        }
                        else if (item.StartsWith("<"))
                        {
                            Thread.Sleep(Convert.ToInt32(item.Replace("<", "")));
                        }
                        else if (item.StartsWith(">"))
                        {
                            EjecutaShell(item.Replace(">", ""));
                        }
                        else
                            EnviarTeclaOComando(item.ToString());
                    }
                    formada[0] = obtenSiguiente(formada[0]);

                    if (formada[0] == '{')
                    {
                        break;
                    }
                    armada = "";

                    for (int k = 0; k < formada.Length; k++)
                        armada += formada[k];

                    //formada = armada.ToCharArray();

                }
                if (ultimo)
                    return;
                formada = armada.ToCharArray();
                for (int k = 0; k < formada.Length; k++)
                {
                    if (formada[k] == 'z')
                    {
                        if (k == cantidadCaraceres - 1)
                        {
                            ultimo = true;
                            break;
                        }
                        formada[k] = '0';
                        armada = "";
                        for (int l = 0; l < formada.Length; l++)
                            armada += formada[l];

                        if (formada.Length < cantidadCaraceres)
                        {
                            try
                            {
                                formada[k + 1] = obtenSiguiente(formada[k + 1]);
                            }
                            catch 
                            {
                                armada += "0";
                                formada = armada.ToCharArray();
                            }
                        }
                        else
                        {
                            formada[cantidadCaraceres - 1] = obtenSiguiente(formada[cantidadCaraceres-1]);
                        }

                        armada = "";
                        for (int l = 0; l < formada.Length; l++)
                            armada += formada[l];

                        //try
                        //{
                        //    formada[k + 1] = obtenSiguiente(formada[k + 1]);
                        //}
                        //catch { }

                        
                        //if (k == armada.Length - 1)
                        //{
                        //    if (k == cantidadCaraceres - 1)
                        //    {
                        //        ultimo = true;
                        //        continue;
                        //    }
                        //    else if (k < cantidadCaraceres - 1)
                        //    {
                        //        armada += "0";
                        //    }
                        //    else
                        //    {
                        //        return;
                        //    }

                        //}
                    }
                }

                formada = armada.ToCharArray();
                //EjecutaShell("test.wmt");
                //armada += (char)48;
            }

        }
        Thread t;
        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_cantidadCaracteres.Text.Trim().Equals(""))
            {
                Mensajes.Error("Especifica el número de caracteres.", "Error");
                return;
            }
            if (lb_acciones2.Items.Count == 0)
            {
                Mensajes.Error("Especifica las actividades.", "Error");
                return;
            }
            if (cboWindows.SelectedItem == null)
            {
                Mensajes.Error("Especifica la ventana a atacar.", "Error");
                return;
            }
            if (t == null)
            {
                if (Mensajes.PreguntaSIoNOAdvertencia("Una vez iniciado el proceso, el equipo actual quedará bloqueado al estar insertando las claves. ¿desea continuar?", "ATENCION!!!"))
                {
                    t = new Thread(Ejecutar);
                    t.Start();
                }
            }
            else
            {
                if (t.ThreadState != System.Threading.ThreadState.Stopped)
                {
                    t.Abort();
                    t = null;
                }
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lb_acciones2.Items.Add("<" + txt_tiempoRetardo.Text.Trim());
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lb_acciones2.Items.Add(">" + txt_cmd.Text.Trim());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                lb_acciones2.Items.Remove(lb_acciones2.SelectedItem);
            }
            catch { }
        }
    }
}