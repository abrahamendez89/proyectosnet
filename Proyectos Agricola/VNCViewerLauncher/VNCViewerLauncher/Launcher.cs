using Herramientas.Archivos;
using Herramientas.Forms;
using Herramientas.Mail;
using Herramientas.WPF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace VNCViewerLauncher
{
    public partial class Launcher : Form
    {

        Dictionary<String, String> equiposConNombre = new Dictionary<string, string>();

        Variable var = new Variable("data");
        Variable var2 = new Variable("datac");
        public Launcher()
        {
            InitializeComponent();
            ConfigurarCosas();
            CargarEquipos();

            RefrescarEquiposLista();

            this.FormClosed += Launcher_FormClosed;
        }

        void Launcher_FormClosed(object sender, FormClosedEventArgs e)
        {
            var.BorrarVariables();
            var.GuardarValorVariable("TotalEquipos", equiposConNombre.Count.ToString());

            int i = 0;
            foreach (String key in equiposConNombre.Keys)
            {
                var.GuardarValorVariable("ip_" + i, key);
                var.GuardarValorVariable("nombre_" + i, equiposConNombre[key]);
                i++;
            }
            var.ActualizarArchivo();
        }
        private void CargarEquipos()
        {
            int numeroEquipos = var.ObtenerValorVariable<int>("TotalEquipos");
            for (int i = 0; i < numeroEquipos; i++)
            {
                try
                {
                    if (var.ObtenerValorVariable<String>("ip_" + i) != null)
                    {
                        equiposConNombre.Add(var.ObtenerValorVariable<String>("ip_" + i), var.ObtenerValorVariable<String>("nombre_" + i));
                    }
                }
                catch { }
            }
            RefrescarEquiposLista();
        }
        private void RefrescarEquiposLista()
        {
            lv_iconos.Items.Clear();
            List<String> ordenados = equiposConNombre.Keys.ToList();
            ordenados.Sort();
            foreach (String key in ordenados)
            {
                ListViewItem lvitem = new ListViewItem();
                lvitem.ImageKey = "pc";
                lvitem.Text = equiposConNombre[key] + @" (" + key + ")";
                lvitem.ToolTipText = key;
                lv_iconos.Items.Add(lvitem);

            }
        }
        private void ConfigurarCosas()
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(50, 50);
            imgList.Images.Add("pc", new Bitmap("pc.png"));
            lv_iconos.LargeImageList = imgList;
            lv_iconos.TileSize = new Size(200, 200);
            lv_iconos.MultiSelect = false;
            lv_iconos.MouseDoubleClick += lv_iconos_MouseDoubleClick;

            ContextMenu cm = new ContextMenu();
            cm.MenuItems.Add(new MenuItem("Ejecutar VNC Viewer", new EventHandler(Evento)));
            cm.MenuItems.Add(new MenuItem("Eliminar equipo", new EventHandler(Evento)));
            cm.MenuItems.Add(new MenuItem("Modificar equipo", new EventHandler(Evento)));
            cm.MenuItems.Add(new MenuItem("Abrir con escritorio remoto", new EventHandler(Evento)));

            lv_iconos.ContextMenu = cm;
        }

        void lv_iconos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            foreach (ListViewItem lb in lv_iconos.SelectedItems)
            {
                EjecutarVNCViewerConIP(lb.ToolTipText);
            }
        }
        private void Evento(object sender, EventArgs e)
        {
            MenuItem mi = (MenuItem)sender;
            if (mi.Text.Equals("Ejecutar VNC Viewer"))
            {
                foreach (ListViewItem lb in lv_iconos.SelectedItems)
                {
                    EjecutarVNCViewerConIP(lb.ToolTipText);
                }
            }
            else if (mi.Text.Equals("Eliminar equipo"))
            {
                foreach (ListViewItem lb in lv_iconos.SelectedItems)
                {
                    equiposConNombre.Remove(lb.ToolTipText);
                    RefrescarEquiposLista();
                }
            }
            else if (mi.Text.Equals("Abrir con escritorio remoto"))
            {
                foreach (ListViewItem lb in lv_iconos.SelectedItems)
                {
                    EjecutaShell("mstsc.exe /v:" + lb.ToolTipText);
                }
            }
            else if (mi.Text.Equals("Modificar equipo"))
            {
                foreach (ListViewItem lb in lv_iconos.SelectedItems)
                {
                    AgregarEquipoAntes ae = new AgregarEquipoAntes();
                    ae.Equipos = this.equiposConNombre;
                    ae.IPEquipo = lb.ToolTipText;
                    ae.NombreEquipo = equiposConNombre[lb.ToolTipText];
                    equiposConNombre.Remove(lb.ToolTipText);
                    ae.ShowDialog();
                    if (ae.NombreEquipo != null && ae.IPEquipo != null && !ae.NombreEquipo.Trim().Equals("") && !ae.IPEquipo.Trim().Equals(""))
                    {
                        equiposConNombre.Add(ae.IPEquipo, ae.NombreEquipo);
                    }
                    ae.Close();
                    RefrescarEquiposLista();
                }
            }
        }
        private void AgregarItem(String nombrePC)
        {
            ListViewItem lvitem = new ListViewItem("una pc con nombre grande");
            lvitem.ImageKey = "pc";
            lv_iconos.Items.Add(lvitem);

        }

        private void EjecutarVNCViewerConIP(String ip)
        {
            try
            {
                ProcessStartInfo info = new ProcessStartInfo();
                info.UseShellExecute = true;
                info.FileName = "realvnc.exe";
                //info.WorkingDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ProgramFiles) + @"\RealVNC\VNC Viewer\";
                info.Arguments = ip;
                Process.Start(info);
                EmailFormatos.EnviarMailInformacion("Se está intentando una conexión del equipo '" + Environment.MachineName + "' con el Usuario '"+ Environment.UserName+"' hacia el equipo '" + equiposConNombre[ip] + "' mediante VNC.", "VNC Viewer Launcher",var2.ObtenerValorVariable<String>("EMAILS"),null);
            }
            catch
            {
                Mensajes.Error("No se encontró el ejecutable de RealVNC portable. No se encuentra el archivo 'realvnc.exe'");
            }
        }

        private static string GetMachineNameFromIPAddress(string ipAdress)
        {
            string machineName = string.Empty;
            try
            {
                IPHostEntry hostEntry = Dns.GetHostEntry(ipAdress);

                machineName = hostEntry.HostName;
            }
            catch (Exception ex)
            {
                // Machine not found...
            }
            return machineName;
        }

        private String EjecutaShell(String linea)
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " CMD: " + mensajeError);
            }

            //MessageBox.Show(process.StandardError.ReadLine());
            //MessageBox.Show(process.StandardOutput.ReadLine());

        }

        private void btn_AgregarPC_Click(object sender, EventArgs e)
        {
            AgregarEquipoAntes ae = new AgregarEquipoAntes();
            ae.ShowDialog();
            if (ae.NombreEquipo != null && ae.IPEquipo != null && !ae.NombreEquipo.Trim().Equals("") && !ae.IPEquipo.Trim().Equals(""))
            {
                equiposConNombre.Add(ae.IPEquipo, ae.NombreEquipo);
            }
            ae.Close();
            RefrescarEquiposLista();
        }

        private void txt_filtro_KeyDown(object sender, KeyEventArgs e)
        {
            
            lv_iconos.Clear();
            List<String> ordenados = equiposConNombre.Keys.ToList();
            ordenados.Sort();
            foreach (String key in ordenados)
            {
                String nombre = equiposConNombre[key] + @" (" + key + ")";
                if (nombre.ToLower().Contains(txt_filtro.Text.ToLower()))
                {
                    ListViewItem lvitem = new ListViewItem();
                    lvitem.ImageKey = "pc";
                    lvitem.Text = equiposConNombre[key] + @" (" + key + ")";
                    lvitem.ToolTipText = key;
                    lv_iconos.Items.Add(lvitem);
                }

            }


        }

    }
}
