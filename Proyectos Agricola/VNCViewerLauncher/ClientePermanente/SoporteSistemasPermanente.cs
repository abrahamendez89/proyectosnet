using Dominio;
using Herramientas.Archivos;
using Herramientas.ORM;
using Herramientas.SQL;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Input;
using WindowsInput;

namespace ClientePermanente
{
    public partial class SoporteSistemasPermanente : Form
    {
        //Variable var;
        //Variable varServer;
        public SoporteSistemasPermanente()
        {
            InitializeComponent();

            try
            {

                RegisterInStartup(true);
                CheckForIllegalCrossThreadCalls = false;
                lbl_status.Text = "";

                this.notifyIcon.Text = "";
                this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info; //Shows the info icon so the user doesn't thing there is an error.
                this.notifyIcon.BalloonTipText = "Con esta aplicación puedes solicitar soporte a sistemas, solo da doble click sobre el salvavidas y notificarás a sistemas que tienes un problema.";
                this.notifyIcon.BalloonTipTitle = "Soporte Sistemas";


                this.notifyIcon.Text = "Doble click para mostrar más información.";

                this.VisibleChanged += Ayuda_VisibleChanged;
                notifyIcon.MouseDoubleClick += notifyIcon_MouseDoubleClick;
                this.FormClosing += Ayuda_FormClosing;

                try
                {
                    double memoriaUso = Herramientas.Sys.PCInfo.ObtenerPorcentajeMemoriaRAMEnuso();
                }
                catch { }
                try
                {
                    List<String> info = Herramientas.Sys.PCInfo.ObtenerPorcentajeEspacioDisponibleEnDisco();
                }
                catch { }
                try
                {
                    mac = Herramientas.Sys.PCInfo.ObtenerMACAddress();
                }
                catch { }
                try
                {
                    win = Herramientas.Sys.PCInfo.ObtenerVersionWindows();
                }
                catch { }
                try
                {
                    marca = Herramientas.Sys.PCInfo.ObtenerMarca();
                }
                catch { }
                try
                {
                    modelo = Herramientas.Sys.PCInfo.ObtenerModelo();
                }
                catch { }
            }
            catch
            {
            }

            try
            {

                Thread tActualizar = new Thread(EnviarEstatus);
                tActualizar.IsBackground = true;
                tActualizar.Start();
            }
            catch
            {
            }
            try
            {
                Thread tActualizarTXT = new Thread(ActualizarTextBox);
                tActualizarTXT.IsBackground = true;
                tActualizarTXT.Start();
            }
            catch
            {
            }
            try
            {
                Thread tRecibirOrdenes = new Thread(RecibirOrdenes);
                tRecibirOrdenes.IsBackground = true;
                tRecibirOrdenes.Start();
            }
            catch
            {
            }
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;
        private const int MOUSEEVENTF_MIDDLEDOWN = 0x20;
        private const int MOUSEEVENTF_MIDDLEUP = 0x40;

        private void RecibirOrdenes(object obj)
        {
            while (true)
            {
                try
                {
                    ManejadorDB man = ObtenerManejador();

                    while (true)
                    {
                        _EquipoEstatus eq = null;
                        if (remotoActivado)
                        {
                            try
                            {
                                eq = man.Cargar<_EquipoEstatus>
                                (@"SELECT [id]
                              ,[dtFechaCreacion]
                              ,[dtFechaModificacion]
                              ,[sUsuarioCreacion]
                              ,[sUsuarioModificacion]
                              ,[estaDeshabilitado]
                              ,[_MAC]
                              ,[_NombreEquipo]
                              ,[_IP]
                              ,[_UsuarioLogin]
                              ,[_PorcentajeMemoriaRAMUsada]
                              ,[_PorcentajeHDUsados]
                              ,[_UsuarioAdminWindows]
                              ,[_PassAdminWindows]
                              ,[_PassVNC]
                              ,[_Marca]
                              ,[_Modelo]
                              ,[_VersionWindows]
                              ,Null as [_ImagenPreview]
                              ,[_PermisoParaEjecutarAplicacion]
                              ,[_TempMensaje]
                              ,[_GrupoPertenece]
                              ,[_NombreReferencia]
                              ,[_Anotaciones]
                              ,[_CoordenadasCursorEnviadas]
                              ,[_ResolucionMonitorPrimario] 

                              ,[_AccionClick]  
                              ,[_ComandoTeclado]   
                              ,[_AccesoRemotoActivado]
                              ,[_ModificadorAcceso]
                              ,[_CombinacionEspecialTeclas]
                          FROM [SoporteSistemas].[dbo].[_EquipoEstatus] where _MAC = @_MAC", new List<object>() { mac });
                                
                            }
                            catch
                            {
                            }
                            if (eq == null)
                            {
                                Thread.Sleep(1000);
                                continue;
                            }
                            if (eq.CoordenadasCursorEnviadas != null)
                            {
                                //aqui movemos el mouse
                                try
                                {
                                    String coordenadas = eq.CoordenadasCursorEnviadas;
                                    Cursor.Position = new Point(Convert.ToInt32(coordenadas.Split(',')[0].ToString().Trim()), Convert.ToInt32(coordenadas.Split(',')[1].ToString().Trim()));
                                }
                                catch
                                {
                                }
                            }
                            if (eq.ComandoTeclado != null)
                            {
                                try
                                {
                                    VirtualKeyCode key = (VirtualKeyCode)System.Enum.Parse(typeof(VirtualKeyCode), eq.ComandoTeclado);
                                    if (eq.ModificadorAcceso == null)
                                    {
                                        InputSimulator.SimulateKeyPress(key);
                                    }
                                    else
                                    {
                                        if (eq.ModificadorAcceso.Equals("1"))
                                            InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, key);
                                        else if (eq.ModificadorAcceso.Equals("2"))
                                            InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.MENU, key);
                                        else if (eq.ModificadorAcceso.Equals("3"))
                                            InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.SHIFT, key);
                                    }

                                }
                                catch
                                {
                                }
                            }
                            if (eq.CombinacionEspecialTeclas != null)
                            {
                                try
                                {

                                    if (eq.ModificadorAcceso.Equals("1"))
                                    {
                                        InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.LWIN, VirtualKeyCode.VK_R); // funciona!!!
                                        InputSimulator.SimulateTextEntry("taskmgr");
                                        Thread.Sleep(500);
                                        InputSimulator.SimulateKeyPress(VirtualKeyCode.RETURN);
                                    }
                                    else if (eq.ModificadorAcceso.Equals("2"))
                                        InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.MENU, VirtualKeyCode.F4);
                                    else if (eq.ModificadorAcceso.Equals("3"))
                                        InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.LWIN, VirtualKeyCode.VK_L);
                                    else if (eq.ModificadorAcceso.Equals("4"))
                                        InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.LWIN, VirtualKeyCode.VK_R);

                                }
                                catch
                                {
                                }
                            }
                            if (eq.AccionClick != null)
                            {
                                try
                                {
                                    int X = Cursor.Position.X;
                                    int Y = Cursor.Position.Y;
                                    if (eq.AccionClick.Equals("RD"))
                                        mouse_event((uint)MOUSEEVENTF_RIGHTDOWN, (uint)X, (uint)Y, (uint)0, (uint)0);
                                    if (eq.AccionClick.Equals("RU"))
                                        mouse_event((uint)MOUSEEVENTF_RIGHTUP, (uint)X, (uint)Y, (uint)0, (uint)0);
                                    if (eq.AccionClick.Equals("LD"))
                                        mouse_event((uint)MOUSEEVENTF_LEFTDOWN, (uint)X, (uint)Y, (uint)0, (uint)0);
                                    if (eq.AccionClick.Equals("LU"))
                                        mouse_event((uint)MOUSEEVENTF_LEFTUP, (uint)X, (uint)Y, (uint)0, (uint)0);
                                    if (eq.AccionClick.Equals("MD"))
                                        mouse_event((uint)MOUSEEVENTF_MIDDLEDOWN, (uint)X, (uint)Y, (uint)0, (uint)0);
                                    if (eq.AccionClick.Equals("MU"))
                                        mouse_event((uint)MOUSEEVENTF_MIDDLEUP, (uint)X, (uint)Y, (uint)0, (uint)0);
                                }
                                catch
                                {
                                }
                            }
                            if (eq.Id != 0 && (eq.AccionClick != null || eq.CoordenadasCursorEnviadas != null || eq.ComandoTeclado != null))
                            {
                                try
                                {
                                    List<object> parametros = new List<object>();

                                    String query = @"update _EquipoEstatus set 
                                                dtFechaModificacion = getdate()
                                                #CURSOR
                                                #ACCION_CLICK
                                                #COMANDO_TECLADO
                                                #COMBINACION_TECLAS
                                                where id = @id";

                                    if (eq.CoordenadasCursorEnviadas != null)
                                    {
                                        query = query.Replace("#CURSOR", ", _CoordenadasCursorEnviadas = @_CoordenadasCursorEnviadas");
                                        parametros.Add(null);
                                    }
                                    else
                                        query = query.Replace("#CURSOR", "");

                                    if (eq.AccionClick != null)
                                    {
                                        query = query.Replace("#ACCION_CLICK", ", _AccionClick = @_AccionClick");
                                        parametros.Add(null);
                                    }
                                    else
                                        query = query.Replace("#ACCION_CLICK", "");

                                    if (eq.ComandoTeclado != null)
                                    {
                                        query = query.Replace("#COMANDO_TECLADO", ", _ComandoTeclado = @_ComandoTeclado");
                                        parametros.Add(null);
                                    }
                                    else
                                        query = query.Replace("#COMANDO_TECLADO", "");

                                    if (eq.CombinacionEspecialTeclas != null)
                                    {
                                        query = query.Replace("#COMBINACION_TECLAS", ", _CombinacionEspecialTeclas = @_CombinacionEspecialTeclas");
                                        parametros.Add(null);
                                    }
                                    else
                                        query = query.Replace("#COMBINACION_TECLAS", "");

                                    parametros.Add(eq.Id);

                                    man.EjecutarConsulta(query, parametros);
                                    lbl_status.Text = "Información enviada correctamente.";
                                }
                                catch
                                {
                                    lbl_status.Text = "Error al enviar información al server...";
                                    try
                                    {
                                        man.CerrarConexion();
                                    }
                                    catch
                                    {
                                    }
                                    man = ObtenerManejador();
                                }
                            }
                        }
                        if (remotoActivado)
                            Thread.Sleep(10);
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
        private void RegisterInStartup(bool isChecked)
        {
            try
            {
                RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

                if (isChecked)
                {
                    registryKey.SetValue("ClienteSoporte", Application.ExecutablePath);
                }
                else
                {
                    registryKey.DeleteValue("ClienteSoporte");
                }
            }
            catch
            {
                lbl_status.Text = "Error al registrar la aplicación.";
            }


        }
        private void ActualizarTextBox()
        {
            while (true)
            {
                try
                {
                    if (IsExecutingApplication())
                    {
                        System.Diagnostics.Process.GetCurrentProcess().Kill();
                    }

                    txt_infoSoporte.Text = "";
                    txt_infoSoporte.Text += "NOMBRE EQUIPO: " + Environment.MachineName + Environment.NewLine;
                    txt_infoSoporte.Text += "USUARIO ADMIN: " + usuarioWindows + Environment.NewLine;
                    txt_infoSoporte.Text += "IP: " + Herramientas.Net.IPNet.ObtenerIPLocal() + Environment.NewLine;
                    txt_infoSoporte.Text += "MAC: " + Herramientas.Sys.PCInfo.ObtenerMACAddress() + Environment.NewLine;
                    txt_infoSoporte.Text += "RAM: " + Herramientas.Sys.PCInfo.ObtenerPorcentajeMemoriaRAMEnuso().ToString("#.00") + "%" + Environment.NewLine;
                    
                    txt_infoSoporte.Text += "DISCOS: " + Environment.NewLine;
                    mac = Herramientas.Sys.PCInfo.ObtenerMACAddress();
                    try
                    {
                        List<String> hds = Herramientas.Sys.PCInfo.ObtenerPorcentajeEspacioDisponibleEnDisco();
                        foreach (String hd in hds)
                        {
                            txt_infoSoporte.Text += hd + Environment.NewLine;
                        }
                    }
                    catch
                    {
                    }
                }
                catch
                {
                }
                Thread.Sleep(5000);
            }
        }
        String usuarioWindows = "";
        String passWindows = "";
        String passVNC = "";
        String mac = "";
        String win = "";
        String marca = "";
        String modelo = "";
        private iSQL ConectarAServer(iSQL sqlT)
        {
            String server = ConfigurationManager.AppSettings["SERVER"]; // varServer.ObtenerValorVariable<String>("SERVER");
            String bd = ConfigurationManager.AppSettings["BD"];//varServer.ObtenerValorVariable<String>("BD");
            String user = ConfigurationManager.AppSettings["USER"]; // varServer.ObtenerValorVariable<String>("USUARIO");
            String pass = ConfigurationManager.AppSettings["PASSWORD"]; // varServer.ObtenerValorVariable<String>("CONTRASEÑA");
            lbl_server.Text = "Server: " + server;

            sqlT = new SQLServer();
            sqlT.ConfigurarConexion(server, bd, user, pass);
            return sqlT;
        }
        private static bool IsExecutingApplication()
        {
            // Proceso actual
            Process currentProcess = Process.GetCurrentProcess();

            // Matriz de procesos
            Process[] processes = Process.GetProcesses();

            // Recorremos los procesos en ejecución
            foreach (Process p in processes)
            {
                if (p.Id != currentProcess.Id)
                {
                    if (p.ProcessName == currentProcess.ProcessName)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        Boolean remotoActivado = false;
        private ManejadorDB ObtenerManejador()
        {
            SQLServer sqlI = null;
            txt_solicitud.Enabled = false;
            btn_enviar.Enabled = false;
            while (true)
            {
                try
                {
                    txt_solicitud.Text = "Intentando conectar al server...";
                    sqlI = (SQLServer)ConectarAServer(sqlI);
                    break;
                }
                catch
                {
                    lbl_status.Text = "Falló al conectar al server...";

                    Thread.Sleep(500);
                }
            }
            txt_solicitud.Text = "";
            txt_solicitud.Enabled = true;
            btn_enviar.Enabled = true;
            return new ManejadorDB(sqlI);
        }

        private void EnviarEstatus(object obj)
        {
            while (true)
            {
                try
                {

                    ManejadorDB man = ObtenerManejador();

                    while (true)
                    {
                        try
                        {
                            if (mac == null)
                            {
                                Thread.Sleep(500);
                                continue;
                            }
                            _EquipoEstatus eq = man.Cargar<_EquipoEstatus>
                            (@"SELECT [id]
                              ,[dtFechaCreacion]
                              ,[dtFechaModificacion]
                              ,[sUsuarioCreacion]
                              ,[sUsuarioModificacion]
                              ,[estaDeshabilitado]
                              ,[_MAC]
                              ,[_NombreEquipo]
                              ,[_IP]
                              ,[_UsuarioLogin]
                              ,[_PorcentajeMemoriaRAMUsada]
                              ,[_PorcentajeHDUsados]
                              ,[_UsuarioAdminWindows]
                              ,[_PassAdminWindows]
                              ,[_PassVNC]
                              ,[_Marca]
                              ,[_Modelo]
                              ,[_VersionWindows]
                              ,Null as [_ImagenPreview]
                              ,[_PermisoParaEjecutarAplicacion]
                              ,[_TempMensaje]
                              ,[_GrupoPertenece]
                              ,[_NombreReferencia]
                              ,[_Anotaciones]
                              ,[_CoordenadasCursorEnviadas]
                              ,[_ResolucionMonitorPrimario] 
                              ,[_AccionClick]  
                              ,[_ComandoTeclado]  
                              ,[_AccesoRemotoActivado] 
                              ,[_ModificadorAcceso]
                              ,[_CombinacionEspecialTeclas]
                          FROM [SoporteSistemas].[dbo].[_EquipoEstatus] where _MAC = @_MAC", new List<object>() { mac });
                            if (eq == null) eq = new _EquipoEstatus();
                            if (eq.Id != 0 && !eq.PermisoParaEjecutarAplicacion)
                            {
                                System.Diagnostics.Process.GetCurrentProcess().Kill();
                            }
                            usuarioWindows = eq.UsuarioAdminWindows;
                            eq.EsModificado = true;
                            try
                            {
                                eq.PorcentajeMemoriaRAMUsada = Herramientas.Sys.PCInfo.ObtenerPorcentajeMemoriaRAMEnuso();
                                eq.IP = Herramientas.Net.IPNet.ObtenerIPLocal();
                                mac = Herramientas.Sys.PCInfo.ObtenerMACAddress();
                            }
                            catch
                            {
                            }
                            eq.MAC = mac;
                            eq.Marca = marca;
                            eq.Modelo = modelo;
                            eq.NombreEquipo = Environment.MachineName;
                            eq.UsuarioLogin = Environment.UserName;

                            remotoActivado = eq.AccesoRemotoActivado;

                            try
                            {
                                eq.ImagenPreview = Herramientas.Archivos.Imagenes.ObtenerFotoPantalla();
                            }
                            catch
                            {
                                eq.ImagenPreview = null;
                            }
                            //eq.PermisoParaEjecutarAplicacion = true;
                            String info = "";
                            try
                            {
                                List<String> hds = Herramientas.Sys.PCInfo.ObtenerPorcentajeEspacioDisponibleEnDisco();
                                
                                if (hds.Count > 0)
                                {
                                    foreach (String hd in hds)
                                        info += hd + " | ";
                                    info = info.Substring(0, info.Length - 3);
                                }
                            }
                            catch
                            {
                            }
                            eq.PorcentajeHDUsados = info;
                            eq.VersionWindows = win;
                            eq.EsModificado = true;
                            eq.ResolucionMonitorPrimario = Screen.PrimaryScreen.Bounds.Width + ", " + Screen.PrimaryScreen.Bounds.Height;
                            lbl_status.Text = "Enviando información al server...";
                            eq.CoordenadasCursorCliente = Cursor.Position.X + ", " + Cursor.Position.Y;
                            if (eq.TempMensaje != null)
                            {
                                Thread tMensaje = new Thread(MostrarMensaje);
                                tMensaje.IsBackground = true;
                                tMensaje.Start(eq.TempMensaje);
                                //eq.TempMensaje = null;
                            }
                            if (eq.CoordenadasCursorEnviadas != null)
                            {
                                try
                                {
                                    String coordenadas = eq.CoordenadasCursorEnviadas;
                                    Cursor.Position = new Point(Convert.ToInt32(coordenadas.Split(',')[0].ToString().Trim()), Convert.ToInt32(coordenadas.Split(',')[1].ToString().Trim()));
                                }
                                catch
                                {
                                }
                            }
                            if (eq.Id == 0)
                            {
                                eq.PermisoParaEjecutarAplicacion = true;
                                man.Guardar(eq);
                            }
                            else
                            {
                                List<object> parametros = new List<object>();

                                String query = @"update _EquipoEstatus set 
                                                dtFechaModificacion = getdate(), 
                                                _UsuarioLogin = @_usuarioLogin, 
                                                _PorcentajeMemoriaRAMUsada = @_PorcentajeMemoriaRAMUsada,
                                                _PorcentajeHDUsados = @_PorcentajeHDUsados,
                                                _ImagenPreview = @_ImagenPreview,
                                                _ResolucionMonitorPrimario = @_ResolucionMonitorPrimario,
                                                _CoordenadasCursorCliente = @_CoordenadasCursorCliente
                                                #MENSAJE
                                                #CURSOR
                                                where id = @id";
                                parametros.Add(eq.UsuarioLogin);
                                parametros.Add(eq.PorcentajeMemoriaRAMUsada);
                                parametros.Add(eq.PorcentajeHDUsados);
                                parametros.Add(eq.ImagenPreview);
                                parametros.Add(eq.ResolucionMonitorPrimario);
                                parametros.Add(eq.CoordenadasCursorCliente);
                                if (eq.TempMensaje != null)
                                {
                                    query = query.Replace("#MENSAJE", ", _TempMensaje = @_TempMensaje");
                                    parametros.Add(null);
                                }
                                else
                                    query = query.Replace("#MENSAJE", "");

                                if (eq.CoordenadasCursorEnviadas != null)
                                {
                                    query = query.Replace("#CURSOR", ", _CoordenadasCursorEnviadas = @_CoordenadasCursorEnviadas");
                                    parametros.Add(null);
                                }
                                else
                                    query = query.Replace("#CURSOR", "");

                                parametros.Add(eq.Id);

                                man.EjecutarConsulta(query, parametros);

                            }
                            lbl_status.Text = "Información enviada correctamente.";
                        }
                        catch
                        {
                            lbl_status.Text = "Error al enviar información al server...";
                            try
                            {
                                man.CerrarConexion();
                            }
                            catch
                            {
                            }
                            man = ObtenerManejador();
                        }
                        if (remotoActivado)
                            Thread.Sleep(50);
                        else
                            Thread.Sleep(1000);
                    }

                }
                catch
                {
                }
            }
        }

        private void MostrarMensaje(Object mensaje)
        {
            try
            {
                String msj = mensaje.ToString();
                if (msj.StartsWith("T:"))
                {
                    notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info; //Shows the info icon so the user doesn't thing there is an error.
                    notifyIcon.BalloonTipText = msj.Replace("T:", "");
                    notifyIcon.BalloonTipTitle = "Mensaje de Sistemas";
                    notifyIcon.Visible = true;
                    notifyIcon.ShowBalloonTip(10000);
                    this.notifyIcon.BalloonTipText = "Con esta aplicación puedes solicitar soporte a sistemas, solo da doble click sobre el salvavidas y notificarás a sistemas que tienes un problema.";
                    this.notifyIcon.BalloonTipTitle = "Soporte Sistemas";
                }
                else if (msj.StartsWith("V:"))
                {
                    MessageBox.Show(msj.Replace("V:", ""), "Mensaje de Sistemas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //MessageBox.Show(new Form() { TopMost = true }, msj.Replace("V:", ""), "Mensaje de Sistemas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
            }
        }

        void Ayuda_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Visible = false;
            MostrarTooltip();
        }

        void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            notifyIcon.Visible = false;
            this.Visible = true;
        }
        Boolean primeraVez = false;
        void Ayuda_VisibleChanged(object sender, EventArgs e)
        {
            if (!primeraVez && Visible)
            {
                primeraVez = true;
                MostrarTooltip();
                this.Visible = false;
            }
        }
        private void MostrarTooltip()
        {
            notifyIcon.Visible = true;
            notifyIcon.ShowBalloonTip(3000);
            this.ShowInTaskbar = false;
        }

        private void btn_enviar_Click(object sender, EventArgs e)
        {
            ManejadorDB manejador = null;
            try
            {
                SQLServer sqlI = null;
                sqlI = (SQLServer)ConectarAServer(sqlI);
                manejador = new ManejadorDB(sqlI);

            }
            catch
            {
                Herramientas.Forms.Mensajes.Error("Ocurrio un error al intenar conectar con el servidor.");
                return;
            }
            _SolicitudSoporte solicitud = new _SolicitudSoporte();
            solicitud.EsModificado = true;
            solicitud.ComentarioInicial = txt_solicitud.Text.Trim();
            solicitud.HoraSolicitud = DateTime.Now;
            solicitud.UsuarioWindows = Environment.UserName;
            solicitud.NombreEquipo = Environment.MachineName;
            solicitud.Ip = Herramientas.Net.IPNet.ObtenerIPLocal();

            List<_PersonalSoporte> personalSoporte = manejador.CargarLista<_PersonalSoporte>("select * from _PersonalSoporte");


            if (personalSoporte != null)
            {
                String correos = "";
                foreach (_PersonalSoporte personal in personalSoporte)
                {
                    correos += personal.Email + "; ";
                }
                correos = correos.Substring(0, correos.Length - 2);
                String mensaje = @"<h1>Usuario: @usuario</h1>

<p>Equipo: @equipo</p>

<p>IP: @ip</p>

<p>Mensaje: @mensaje</p>

<p>Favor de no responder a este correo.</p>".Replace("@usuario", solicitud.UsuarioWindows).Replace("@equipo", solicitud.NombreEquipo).Replace("@ip", solicitud.Ip).Replace("@mensaje", solicitud.ComentarioInicial);
                Herramientas.Mail.EmailFormatos.EnviarMailInformacion(mensaje, "Solicitud de soporte", correos, null);
            }

            try
            {
                //manejador.IniciarTransaccion();
                manejador.Guardar(solicitud);
                //manejador.TerminarTransaccion();
                Herramientas.Forms.Mensajes.Informacion("Mensaje enviado con éxito!!!");
                txt_solicitud.Text = "";
                Close();
            }
            catch (Exception ex)
            {
                manejador.DeshacerTransaccion();
                Herramientas.Forms.Mensajes.Error("Ocurrió un error al intentar enviar la solicitud: " + ex.Message);
            }
        }
    }
}
