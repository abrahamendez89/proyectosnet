using Dominio;
using Herramientas.Archivos;
using Herramientas.ORM;
using Herramientas.SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Input;
using WindowsInput;

namespace VNCViewerLauncher
{
    public partial class VerEquipo : Form
    {
        String id;
        Variable var;
        Thread tActualizar;
        Thread tActualizarMouse;
        ManejadorDB manejador;
        iSQL sql;
        List<_Grupo> grupos;
        _EquipoEstatus equipo;
        String resolucion = "";
        public VerEquipo(String idEquipoConectado, String nombre)
        {
            InitializeComponent();
            this.FormClosing += VerEquipo_FormClosing;
            id = idEquipoConectado;
            var = new Variable("config.conf");
            Text = nombre;

            sql = ConectarAServer(sql);
            manejador = new ManejadorDB(sql);

            equipo = manejador.Cargar<_EquipoEstatus>("select * from _EquipoEstatus where id = " + id);
            txt_nombreEquipo.Text = equipo.NombreEquipo;
            txt_ip.Text = equipo.IP;
            txt_mac.Text = equipo.MAC;
            txt_modelo.Text = equipo.Modelo;
            txt_marca.Text = equipo.Marca;
            txt_versionWindows.Text = equipo.VersionWindows;
            txt_usuarioLogueado.Text = equipo.UsuarioLogin;

            txt_adminWindows.Text = equipo.UsuarioAdminWindows;
            txt_passWindows.Text = equipo.PassAdminWindows;
            txt_passvnc.Text = equipo.PassVNC;
            txt_NombreReferencia.Text = equipo.NombreReferencia;
            txt_Anotaciones.Text = equipo.Anotaciones;
            FormClosing += VerEquipo_FormClosing;
            

            this.KeyDown += VerEquipo_KeyDown;       

            pc_preview.Image = equipo.ImagenPreview;
            pc_preview.MouseDown += pc_preview_MouseDown;
            pc_preview.MouseUp += pc_preview_MouseUp;
            pc_preview.MouseMove += pc_preview_MouseMove;
            pc_preview.PreviewKeyDown += pc_preview_PreviewKeyDown;
            pc_preview.MouseClick += pc_preview_MouseClick;
            pc_preview.LostFocus += pc_preview_LostFocus;

            if (equipo.NombreReferencia != null)
                Text += "(" + equipo.NombreReferencia + ")";


            grupos = manejador.CargarLista<_Grupo>("select * from _Grupo");
            if (grupos != null)
                foreach (_Grupo grupo in grupos)
                {
                    cmb_grupo.Items.Add(grupo.St_NombreGrupo);
                }
            if (equipo.GrupoPertenece != null)
                cmb_grupo.SelectedItem = equipo.GrupoPertenece.St_NombreGrupo;


            tActualizar = new Thread(Actualizar);
            tActualizar.IsBackground = true;
            tActualizar.Start();

            tActualizarMouse = new Thread(ActualizarMouse);
            tActualizarMouse.IsBackground = true;
            tActualizarMouse.Start();

        }

        void pc_preview_LostFocus(object sender, EventArgs e)
        {
            KeyPreview = false;
        }

        void pc_preview_MouseClick(object sender, MouseEventArgs e)
        {
            if (chb_HabilitarManejoRemoto.Checked)
            {
                KeyPreview = true;
                pc_preview.Focus();
            }
        }

        void VerEquipo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (chb_HabilitarManejoRemoto.Checked)
                {
                    String keys = ConvertirKeysAString((int)e.KeyCode);
                    manejador.EjecutarConsulta("update _EquipoEstatus set _ComandoTeclado = '" + keys + "' where id = " + id);

                }
            }
            catch
            {
            }
        }

        private void ActualizarMouse()
        {
            try
            {
                SQLServer sqlI = null;
                while (true)
                {
                    try
                    {
                        sqlI = (SQLServer)ConectarAServer(sqlI);
                        break;
                    }
                    catch
                    {
                    }
                }

                ManejadorDB man = new ManejadorDB(sqlI);
                while (true)
                {
                    try
                    {
                        if (chb_HabilitarManejoRemoto.Checked)
                        {
                            String coordenadas = "";
                            double widthRemoto = Convert.ToInt32(resolucion.Split(',')[0]);
                            double heightRemoto = Convert.ToInt32(resolucion.Split(',')[1]);

                            double widhtImagen = pc_preview.Width;
                            double heightImagen = pc_preview.Height;

                            double xTraducido = 0;
                            double yTraducido = 0;

                            xTraducido = widthRemoto * ((xAnterior * Convert.ToDouble(1)) / widhtImagen);
                            yTraducido = heightRemoto * ((yAnterior * Convert.ToDouble(1)) / heightImagen);

                            coordenadas = xTraducido.ToString("0") + ", " + yTraducido.ToString("0");
                            man.EjecutarConsulta("update _EquipoEstatus set _CoordenadasCursorEnviadas = '" + coordenadas + "' where id = " + id);
                        }

                    }
                    catch
                    {
                    }

                    Thread.Sleep(50);
                }
            }
            catch
            {
            }
        }

        void pc_preview_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        void pc_preview_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                String accion = "";
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    accion = "LU";
                }
                else if (e.Button == System.Windows.Forms.MouseButtons.Middle)
                {
                    accion = "MU";
                }
                else if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    accion = "RU";
                }
                manejador.EjecutarConsulta("update _EquipoEstatus set _AccionClick = '" + accion + "' where id = " + id);
            }
            catch
            {
            }
        }

        void pc_preview_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                String accion = "";
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    accion = "LD";
                }
                else if (e.Button == System.Windows.Forms.MouseButtons.Middle)
                {
                    accion = "MD";
                }
                else if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    accion = "RD";
                }
                manejador.EjecutarConsulta("update _EquipoEstatus set _AccionClick = '" + accion + "' where id = " + id);
            }
            catch
            {
            }
        }
        int xAnterior;
        int yAnterior;
        void pc_preview_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (resolucion != null && chb_HabilitarManejoRemoto.Checked)
                {
                    xAnterior = e.X;
                    yAnterior = e.Y;
                }
            }
            catch
            {
            }
        }


        void VerEquipo_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                try
                {
                    manejador.EjecutarConsulta("update _EquipoEstatus set _AccesoRemotoActivado = 'False', _ComandoTeclado = Null, _ModificadorAcceso = Null, _CombinacionEspecialTeclas = Null where id = " + id);
                }
                catch
                {
                }

                tActualizar.Abort();
                tActualizarMouse.Abort();
            }
            catch
            {
            }
        }
        private iSQL ConectarAServer(iSQL sqlT)
        {

            String server = var.ObtenerValorVariable<String>("SERVER");
            String bd = var.ObtenerValorVariable<String>("BD");
            String user = var.ObtenerValorVariable<String>("USUARIO");
            String pass = var.ObtenerValorVariable<String>("CONTRASEÑA");
            sqlT = new SQLServer();
            sqlT.ConfigurarConexion(server, bd, user, pass);
            return sqlT;
        }
        private ManejadorDB ObtenerManejador()
        {
            SQLServer sqlI = null;
            while (true)
            {
                try
                {
                    sqlI = (SQLServer)ConectarAServer(sqlI);
                    break;
                }
                catch
                {
                    Thread.Sleep(500);
                }
            }
            return new ManejadorDB(sqlI);
        }
        private void Actualizar(object obj)
        {
            while (true)
            {
                try
                {

                    ManejadorDB man = ObtenerManejador();
                    Boolean remotoActivado = false;
                    while (true)
                    {
                        try
                        {
                            //_EquipoEstatus eq = man.Cargar<_EquipoEstatus>("select * from _EquipoEstatus where id = " + id);

                            DataTable datos = man.EjecutarConsulta("select _AccesoRemotoActivado,_PorcentajeMemoriaRAMUsada,_PorcentajeHDUsados, _CoordenadasCursorCliente ,_ResolucionMonitorPrimario, _ImagenPreview from _EquipoEstatus where id = " + id);


                            txt_RAM.Text = Convert.ToDouble(datos.Rows[0]["_PorcentajeMemoriaRAMUsada"]).ToString("#.00") + "%";
                            resolucion = datos.Rows[0]["_ResolucionMonitorPrimario"].ToString(); //eq.ResolucionMonitorPrimario;
                            List<String> discos = datos.Rows[0]["_PorcentajeHDUsados"].ToString().Split('|').ToList<String>();
                            txt_discos.Text = "";
                            remotoActivado = (Boolean)datos.Rows[0]["_AccesoRemotoActivado"];
                            foreach (String disco in discos)
                                txt_discos.Text += disco.Trim() + Environment.NewLine;

                            Bitmap imagen = new Bitmap(new MemoryStream((byte[])datos.Rows[0]["_ImagenPreview"])); // (Bitmap)ArrayToObject((byte[])datos.Rows[0]["_ImagenPreview"]);

                            if (remotoActivado)
                                pc_preview.Image = DibujarPunto(datos.Rows[0]["_CoordenadasCursorCliente"].ToString(), imagen, Color.Blue);
                            else
                                pc_preview.Image = DibujarPunto(datos.Rows[0]["_CoordenadasCursorCliente"].ToString(), imagen, Color.Yellow);

                            //Application.DoEvents();

                            //pc_preview.Image = eq.ImagenPreview;
                        }
                        catch
                        {
                        }
                        if (remotoActivado)
                            Thread.Sleep(50);
                        else
                            Thread.Sleep(1000);

                    }
                }
                catch
                {
                    Thread.Sleep(500);
                }
            }
        }
        public object ArrayToObject(byte[] array)
        {
            MemoryStream memoryStream = new MemoryStream(array);
            BinaryFormatter formatter = new BinaryFormatter();
            return formatter.Deserialize(memoryStream);
        }
        Boolean alternado = false;
        private Image DibujarPunto(string p, Bitmap bitmap, Color colorAlternado)
        {
            int size = 12;
            String coordenadas = p;
            Color contorno = Color.Black;
            Color relleno = Color.White;
            if (alternado)
            {
                relleno = colorAlternado;
            }
            else
            {
                relleno = Color.Red;
            }
            alternado = !alternado;
            using (Graphics grf = Graphics.FromImage(bitmap))
            {
                using (Brush brsh = new SolidBrush(relleno))
                {
                    grf.FillEllipse(brsh, Convert.ToInt32(coordenadas.Split(',')[0].ToString().Trim()), Convert.ToInt32(coordenadas.Split(',')[1].ToString().Trim()), size, size);
                }
                using (Pen brsh = new Pen(contorno))
                {
                    grf.DrawEllipse(brsh, Convert.ToInt32(coordenadas.Split(',')[0].ToString().Trim()), Convert.ToInt32(coordenadas.Split(',')[1].ToString().Trim()), size, size);
                }
            }
            return bitmap;
        }

        private void EnviarMensaje(String mensaje)
        {

            SQLServer sqlI = null;
            while (true)
            {
                try
                {
                    sqlI = (SQLServer)ConectarAServer(sqlI);
                    break;
                }
                catch
                {
                }
            }

            ManejadorDB man = new ManejadorDB(sqlI);
            man.EjecutarConsulta("update _EquipoEstatus set _tempmensaje = '" + mensaje + "' where id = " + id);
        }
        
        private void btn_guardarCambios_Click(object sender, EventArgs e)
        {
            try
            {
                equipo.UsuarioAdminWindows = txt_adminWindows.Text;
                equipo.PassAdminWindows = txt_passWindows.Text;
                equipo.PassVNC = txt_passvnc.Text;
                equipo.NombreReferencia = txt_NombreReferencia.Text;
                equipo.Anotaciones = txt_Anotaciones.Text;
                if (cmb_grupo.SelectedItem != null)
                    equipo.GrupoPertenece = grupos[cmb_grupo.SelectedIndex];
                equipo.EsModificado = true;
                manejador.Guardar(equipo);
                Herramientas.Forms.Mensajes.Informacion("Guardado exitoso.");
            }
            catch (Exception ex)
            {
                Herramientas.Forms.Mensajes.Error("Error: " + ex.Message);
            }
        }
        private void VNC(String vnc, String ip, String password)
        {
            try
            {
                if (Herramientas.Forms.Mensajes.PreguntaAdvertenciaSIoNO("¿Estás seguro de querer acceder a este equipo remotamente?"))
                {
                    ProcessStartInfo info = new ProcessStartInfo();
                    info.UseShellExecute = true;
                    if (vnc.Equals("ultravnc"))
                    {
                        info.FileName = "ultravnc.exe";
                        info.Arguments = "-server " + ip + " -autoscaling -shared -normalcursor -quality 9 -password " + password;
                    }
                    else if (vnc.Equals("realvnc"))
                    {
                        info.FileName = "realvnc.exe";
                        info.Arguments = ip;
                    }
                    else if (vnc.Equals("rdesktop"))
                    {
                        Process rdcProcess = new Process();
                        rdcProcess.StartInfo.FileName = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\cmdkey.exe");
                        if (!txt_passWindows.Text.Trim().Equals(""))
                            rdcProcess.StartInfo.Arguments = "/generic:TERMSRV/" + txt_ip.Text + " /user:" + txt_ip.Text + "\\" + txt_adminWindows.Text + " /pass:" + txt_passWindows.Text;
                        else
                            rdcProcess.StartInfo.Arguments = "/generic:TERMSRV/" + txt_ip.Text + " /user:" + txt_ip.Text + "\\" + txt_adminWindows.Text;
                        rdcProcess.Start();

                        rdcProcess.StartInfo.FileName = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\mstsc.exe");
                        rdcProcess.StartInfo.Arguments = "/v " + txt_ip.Text; // ip or name of computer to connect
                        rdcProcess.Start();
                    }

                    Process.Start(info);
                }
                //EmailFormatos.EnviarMailInformacion("Se está intentando una conexión del equipo '" + Environment.MachineName + "' con el Usuario '"+ Environment.UserName+"' hacia el equipo '" + equiposConNombre[ip] + "' mediante VNC.", "VNC Viewer Launcher",var2.ObtenerValorVariable<String>("EMAILS"),null);
            }
            catch
            {
                //Mensajes.Error("No se encontró el ejecutable de RealVNC portable. No se encuentra el archivo 'realvnc.exe'");
            }
        }
        
        private void pb_ultravnc_Click(object sender, EventArgs e)
        {
            VNC("ultravnc", txt_ip.Text, txt_passvnc.Text);
        }

        private void pb_realvnc_Click(object sender, EventArgs e)
        {
            VNC("realvnc", txt_ip.Text, txt_passvnc.Text);
        }

        private void pb_remote_Click(object sender, EventArgs e)
        {
            VNC("rdesktop", txt_ip.Text, txt_passvnc.Text);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (txt_mensaje.Text.Equals(""))
            {
                Herramientas.Forms.Mensajes.Exclamacion("Escribe un mensaje primero.");
                return;
            }
            EnviarMensaje("T:" + txt_mensaje.Text);
            txt_mensaje.Text = "";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (txt_mensaje.Text.Equals(""))
            {
                Herramientas.Forms.Mensajes.Exclamacion("Escribe un mensaje primero.");
                return;
            }
            EnviarMensaje("V:" + txt_mensaje.Text);
            txt_mensaje.Text = "";
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (!pc_preview.Visible)
            {
                pc_preview.Visible = true;
                chb_HabilitarManejoRemoto.Visible = true;
                this.WindowState = FormWindowState.Maximized;
                this.Size = new Size(1084, 721);
                lbl_tituloImagen.Visible = true;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                this.MaximizeBox = true;
            }
            else
            {
                pc_preview.Visible = false;
                chb_HabilitarManejoRemoto.Visible = false;
                this.WindowState = FormWindowState.Normal;
                this.Size = new Size(353, 721);
                lbl_tituloImagen.Visible = false;

                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                this.MaximizeBox = false;
            }
            CenterToScreen();
        }



        private String ConvertirKeysAString(int keyInt)
        {
            //int keyInt = (int)e.KeyCode;
            Keys keyKeys = (Keys)keyInt;

            System.Windows.Input.Key kW = (System.Windows.Input.Key)Enum.Parse(typeof(System.Windows.Input.Key), keyKeys.ToString());
            VirtualKeyCode CodeOfKeyToEmulate = (VirtualKeyCode)KeyInterop.VirtualKeyFromKey(kW);
            String keyString = CodeOfKeyToEmulate.ToString();

            return keyString;
        }

        private void chb_HabilitarManejoRemoto_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                String boleano = "";
                if (chb_HabilitarManejoRemoto.Checked)
                {
                    boleano = "True";
                    pc_preview.Focus();
                }
                else
                    boleano = "False";
                manejador.EjecutarConsulta("update _EquipoEstatus set _AccesoRemotoActivado = '" + boleano + "' , _ComandoTeclado = Null, _ModificadorAcceso = Null, _CombinacionEspecialTeclas = Null where id = " + id);
            }
            catch
            {
            }
        }

        private void btn_ctrl_alt_supr_Click(object sender, EventArgs e)
        {
            EnviarCombinacionEspecial(1);
            
            ////InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.LWIN, VirtualKeyCode.VK_R); // funciona!!!
            ////InputSimulator.SimulateTextEntry("taskmgr");
            ////Thread.Sleep(500);
            ////InputSimulator.SimulateKeyPress(VirtualKeyCode.RETURN);


           ////InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.MENU, VirtualKeyCode.F4); // funciona!!!

            InputSimulator.SimulateModifiedKeyStroke(new[] { VirtualKeyCode.CONTROL, VirtualKeyCode.MENU}, VirtualKeyCode.SUBTRACT ); // funciona!!!

        }

        private void btn_alt_f4_Click(object sender, EventArgs e)
        { 
            EnviarCombinacionEspecial(2);
        }

        private void EnviarCombinacionEspecial(int combinacion)
        {
            try
            {
                /*combinaciones especiales
                
                 * 1= ctrl+alt+supr
                 * 2= alt+f4
                 * 3= windows + L
                 * 4= windows + R

                 */
                if (chb_HabilitarManejoRemoto.Checked)
                {
                    manejador.EjecutarConsulta("update _EquipoEstatus set _CombinacionEspecialTeclas = '" + combinacion + "' where id = " + id);
                }
            }
            catch
            {
            }
        }

        private void chb_ctrl_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_ctrl.Checked)
                EnviarTeclaModificadora(1);
            else
                EnviarTeclaModificadora(0);
            chb_alt.Checked = false;
            chb_shift.Checked = false;
        }

        private void chb_alt_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_alt.Checked)
                EnviarTeclaModificadora(2);
            else
                EnviarTeclaModificadora(0);

            chb_ctrl.Checked = false;
            chb_shift.Checked = false;
        }

        private void chb_shift_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_shift.Checked)
                EnviarTeclaModificadora(3);
            else
                EnviarTeclaModificadora(0);
            chb_alt.Checked = false;
            chb_ctrl.Checked = false;
        }
        private void EnviarTeclaModificadora(int teclaModificadora)
        {
            try
            {
                /*combinaciones especiales
                
                 * 1= control
                 * 2= alt
                 * 3= shift

                 */
                if (chb_HabilitarManejoRemoto.Checked)
                {
                    if (teclaModificadora != 0)
                        manejador.EjecutarConsulta("update _EquipoEstatus set _ModificadorAcceso = '" + teclaModificadora + "' where id = " + id);
                    else
                        manejador.EjecutarConsulta("update _EquipoEstatus set _ModificadorAcceso = NULL where id = " + id);

                }
            }
            catch
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EnviarCombinacionEspecial(4);
        }
    }
}
