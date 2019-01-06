
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Dominio.Sistema;
using Dominio;
using Herramientas.Archivos;
using System.IO;
using System.Xml;
using System.Windows.Markup;
using System.Data;
using AForge.Video.DirectShow;
using AForge.Video;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Media.Animation;
using LogicaNegocios.Sistema;
using System.Text.RegularExpressions;
using Herramientas.Mail;
using Herramientas.ORM;
using Herramientas.ORM.Memoria;
using Herramientas.SQL;

namespace InterfazWPF.AdministracionSistema
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private ManejadorDB manejador;
        private ManejadorDB manejadorPrincipal;
        private Variable variablesData;
        private Variable variablesConn;

        public static Login Instancia;

        public Boolean ModoBloqueo { get; set; }
        public _sis_Usuario UsuarioBloqueo { get; set; }
        private String ipLocal;
        private String ipInternet;
        private List<_sis_AccesoFallido> accesosFallidos = new List<_sis_AccesoFallido>();
        private _sis_Usuario usuario;
        private int conteoRegistrosLimite;
        private sis_ln_Login lnLogin;
        private String servidorInstancia;
        private String BaseDatos;
        private String archivoSQLite = @"C:\Users\Abrahamm.WHOLESUM\Desktop\ProgramaSiembra.db";

        public static String DatosConexion = "";

        public static System.Windows.Forms.Screen GetPantallaSistema()
        {
            System.Windows.Forms.Screen PantallaSistema = System.Windows.Forms.Screen.FromHandle(
            new System.Windows.Interop.WindowInteropHelper(Login.Instancia).Handle);
            return PantallaSistema;
        }
        private void CargarValoresVariablesLocales()
        {
            variablesData = new Variable("data.conf");
            variablesConn = new Variable("conn.conf");
            txt_usuario.Text = variablesData.ObtenerValorVariable<String>("ultimo_usuario");
            int versionActual = variablesData.ObtenerValorVariable<int>("version_actual");
            servidorInstancia = HerramientasWindow.DesencriptarConMD5(variablesConn.ObtenerValorVariable<String>("ServidorInstancia"));
            BaseDatos = HerramientasWindow.DesencriptarConMD5(variablesConn.ObtenerValorVariable<String>("BaseDeDatos"));
            lbl_version.Content = "Versión: " + versionActual;
        }
        public void CargarCaracteristicasVisuales()
        {
            try
            {
                img_imagenConfiguracion.Source = HerramientasWindow.BitmapAImageSource(new Bitmap(@"Imagenes\Iconos\Sistema\ConfiguracionLogin.png"));
                img_imagenDatosServidor.Source = HerramientasWindow.BitmapAImageSource(new Bitmap(@"Imagenes\Iconos\Sistema\conexion.png"));
                img_imagenConfiguracionReflejo.Source = img_imagenConfiguracion.Source;
                img_imagenDatosServidorReflejo.Source = img_imagenDatosServidor.Source;
                this.Icon = HerramientasWindow.BitmapAImageSource(new Bitmap(@"Imagenes\Iconos\Sistema\Sistema.png"));
                ActualizarTooltipRed();

            }
            catch { }

        }
        private void ActualizarTooltipRed()
        {
            if (ManejadorDB.TipoSQLDefault == typeof(SQLServer))
                img_imagenDatosServidor.ToolTip = "Serv.\\Inst.: \t" + servidorInstancia + "\nBase de datos: \t" + BaseDatos + "\nIP(LAN|WAN): \t" + ipLocal + "|" + ipInternet;
            else if (ManejadorDB.TipoSQLDefault == typeof(SQLite))
                img_imagenDatosServidor.ToolTip = "Archivo SQLite: \t" + archivoSQLite + "\nIP(LAN|WAN): \t" + ipLocal + "|" + ipInternet;

            DatosConexion = img_imagenDatosServidor.ToolTip.ToString();
        }
        _sis_DatosSistema datosSistema;
        private void cargarCaracteristicasVisualesDeServidor()
        {
            if (manejador != null)
            {
                datosSistema = manejador.Cargar<_sis_DatosSistema>(_sis_DatosSistema.ConsultaTodos);
                if (datosSistema != null)
                {
                    ImageBrush ib = new ImageBrush();
                    if (datosSistema.BImagenIcono != null)
                        this.Icon = HerramientasWindow.BitmapAImageSource(datosSistema.BImagenIcono);
                    if (datosSistema.BImagenFondoLogin != null)
                    {
                        ib.ImageSource = HerramientasWindow.BitmapAImageSource(datosSistema.BImagenFondoLogin);
                        rtg_imagenFondo.Fill = ib;
                        rtg_imagenFondo.Opacity = 100;
                    }

                }
            }
        }
        public Login()
        {
            try
            {
                InitializeComponent();



                //AlmacenObjetos.TiempoExistenciaCache(0);

                Login.Instancia = this;

                Thread tBuscarIPInternet = new Thread(ObtenerIPInternetHilo);
                tBuscarIPInternet.Start();

                CargarValoresVariablesLocales();
                //cadena de conexion y configuracion para SQL
                ManejadorDB.TipoSQLDefault = typeof(SQLServer);
                ManejadorDB.CadenaConexionDefault = "data source = @SERVIDOR; initial catalog = @BASEDATOS; user id = @USUARIO; password = @CONTRASENA";
                ManejadorDB.CadenaConexionDefault = ManejadorDB.CadenaConexionDefault.Replace("@SERVIDOR", servidorInstancia);
                ManejadorDB.CadenaConexionDefault = ManejadorDB.CadenaConexionDefault.Replace("@BASEDATOS", BaseDatos);
                ManejadorDB.CadenaConexionDefault = ManejadorDB.CadenaConexionDefault.Replace("@USUARIO", "sa");
                ManejadorDB.CadenaConexionDefault = ManejadorDB.CadenaConexionDefault.Replace("@CONTRASENA", "1@TCE123");
                
                //cadena de conexion y configuracion para SQLite
                //ManejadorDB.TipoSQLDefault = typeof(SQLite);
                //ManejadorDB.CadenaConexionDefault = "Data Source=@archivoBD;Version=3;New=@esNuevo;Compress=True; DateTimeFormat=CurrentCulture;";
                //ManejadorDB.CadenaConexionDefault = ManejadorDB.CadenaConexionDefault.Replace("@archivoBD", archivoSQLite);
                //ManejadorDB.CadenaConexionDefault = ManejadorDB.CadenaConexionDefault.Replace("@esNuevo", "False");



                

                CargarCaracteristicasVisuales();



                ipLocal = HerramientasWindow.ObtenerIPLocal();
                lbl_mensaje.Opacity = 0;
                txt_contraseña.keyEvent += txt_contraseña_keyEvent;
                txt_usuario.keyEvent += txt_usuario_keyEvent;

                lnLogin = new sis_ln_Login();
                Closing += Login_Closing;

                lnLogin.enviarMensaje += HerramientasWindow.MensajeLogicaNegocios;
                if (manejador == null)
                    manejador = new ManejadorDB();
                if (manejadorPrincipal == null)
                    manejadorPrincipal = new ManejadorDB();
                cargarCaracteristicasVisualesDeServidor();
                if (datosSistema != null)
                    AlmacenObjetos.TiempoExistenciaCache(datosSistema.ISegundosParaAlmacenObjetos);

                //HerramientasWindow.GuardarValorVariableGlobal(manejador, "SALARIO_DIARIO", "80");



//                DataTable dt = manejador.EjecutarConsulta(@"select a.ID,  case when a.EstaDeshabilitado = 0 then 'NO' when a.EstaDeshabilitado is null then 'NO' when a.EstaDeshabilitado = 1 then 'SI' end as [Está deshabilitado], _st_Nombre_cultivo 
//                                                            from _gen_Cultivo a  
//                                                            where  (a.estaDeshabilitado = @valorFalse or a.EstaDeshabilitado is null or a.estaDeshabilitado = @valorTrue)  and ( a._st_Nombre_cultivo like '%%' )", new List<object>() {false, true });


                //select a.ID,  case when a.EstaDeshabilitado is null then 'NO' when a.EstaDeshabilitado = 'True' then 'SI' when a.EstaDeshabilitado = 'False' then 'NO' end as [Está deshabilitado], _st_Nombre_cultivo 
                //from _gen_Cultivo a  
                //where  (a.estaDeshabilitado = 'False' or a.EstaDeshabilitado is null or a.estaDeshabilitado = 'True')  and ( a._st_Nombre_cultivo like '%%' )




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al iniciar Sistema");
            }
        }

        void Login_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            AlmacenObjetos.CerrarAlmacen();
        }
        private void ObtenerIPInternetHilo()
        {
            ipInternet = HerramientasWindow.ObtenerIPInternet();
            Dispatcher.Invoke(new Action(() =>
            {
                ActualizarTooltipRed();
            }));
        }

        bool lnLogin_enviarMensaje(string mensaje, string titulo, LogicaNegocios.MensajeException.TipoMensaje tipoMensaje)
        {
            lbl_mensaje.Content = mensaje;
            MostrarMensaje();
            return true;
        }

        void txt_usuario_keyEvent(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                txt_contraseña.Focs();
                txt_contraseña.Text = "";
            }
        }

        void txt_contraseña_keyEvent(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                btn_iniciar_MouseDown(null, null);
            }
        }
        Principal p = null;

        private void btn_iniciar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                lnLogin.VerificarExistenciaDeUsuarioAdmin();
                usuario = lnLogin.ValidarAcceso(txt_usuario.Text.Trim(), txt_contraseña.Text.Trim());

                if (usuario != null)
                {
                    if (ModoBloqueo)
                    {
                        if (UsuarioBloqueo.Cuenta.Equals(usuario.Cuenta) && UsuarioBloqueo.Contrasena.Equals(HerramientasWindow.EncriptarConAES(txt_contraseña.Text)))
                        {
                            p.ReiniciarAutobloqueo();
                        }
                        else
                        {

                            HerramientasWindow.Mensaje("Verificar datos de acceso para el usuario que bloqueó el sistema.", "Verificar datos");
                            AgregarLoginFallido();
                            txt_contraseña.Text = "";
                            return;
                        }
                    }

                    if (usuario.Contrasena != null && !usuario.Contrasena.Equals(HerramientasWindow.EncriptarConAES(txt_contraseña.Text)))
                    {

                        MostrarMensaje();//HerramientasWindow.Mensaje("Usuario o contraseña invalidos.", "Verificar datos");
                        AgregarLoginFallido();
                        txt_contraseña.Text = "";
                        return;
                    }

                    if (datosSistema != null && datosSistema.BUsarProteccionDeCuentasEnLogin && !ModoBloqueo && usuario.BEstaConectadoAlSistema)
                    {
                        if (usuario.EsAdministradorDeSistema || (usuario.RolSistema != null && usuario.RolSistema.EsAdministradorDeSistema))
                        {
                            usuario.SMensajeDeIntentoDeConexionEnOtroEquipo = "Se realizó una conexión desde el equipo '" + Environment.MachineName + "' con tu usuario y contraseña correctos, esta conexión se cerrará.";
                            usuario.EsModificado = true;
                            manejador.Guardar(usuario);
                            HerramientasWindow.Mensaje("Se detectó que la cuenta estaba iniciada en otro equipo. Se iniciará la conexión en cuanto se haya finalizado la sesión encontrada despues de dar clic en aceptar. \nContinuar...", "Cuenta iniciada previamente");


                            while (true)
                            {
                                usuario = manejador.Cargar<_sis_Usuario>(_sis_Usuario.consultaPorID, new List<Object>() { usuario.Id });
                                if (usuario.SMensajeDeIntentoDeConexionEnOtroEquipo != null && !usuario.SMensajeDeIntentoDeConexionEnOtroEquipo.Equals(""))
                                {
                                    //HerramientasWindow.Mensaje("Aún no se ha cerrado la conexión en el otro equipo, por favor vuelva a intentar.", "Cuenta iniciada previamente");
                                    Thread.Sleep(500);
                                }
                                else
                                {
                                    break;
                                }
                            }

                            //return;
                        }
                        else
                        {
                            usuario.SMensajeDeIntentoDeConexionEnOtroEquipo = "Se intentó una conexión desde el equipo '" + Environment.MachineName + "' con tu usuario y contraseña correctos, verificar conexión.";
                            usuario.EsModificado = true;
                            manejador.Guardar(usuario);
                            HerramientasWindow.Mensaje("Actualmente la cuenta se encuentra iniciada en otro equipo, se ha enviado un mensaje de aviso a la cuenta.", "Cuenta iniciada previamente");
                            return;
                        }
                    }

                    if (!usuario.Cuenta.Equals("administrador") && usuario.BEstaDesactivado)
                    {
                        HerramientasWindow.Mensaje("Actualmente tu cuenta está desactivada, favor de contactar con el administrador de Sistemas.", "Cuenta desactivada");
                        return;
                    }

                    _sis_EquiposRegistrados equipoRegistrado = manejador.Cargar<_sis_EquiposRegistrados>(_sis_EquiposRegistrados.ConsultaPorNombreEquipo, new List<object>() { Environment.MachineName });
                    if (equipoRegistrado != null && equipoRegistrado.BEstaBloqueado && !usuario.EsAdministradorDeSistema)
                    {
                        HerramientasWindow.MensajeAdvertenciaAlta("El equipo actual se encuentra bloqueado, favor de contactar al administrador del Sistema.", "Equipo bloqueado");
                        return;
                    }
                    variablesData.GuardarValorVariable("ultimo_usuario", txt_usuario.Text);
                    variablesData.ActualizarArchivo();

                    accesosFallidos.Clear();
                    if (p == null)
                    {
                        p = new Principal(usuario, manejadorPrincipal);
                        p.seCerroSistema += p_seCerroSistema;
                    }

                    Hide();
                    ActualizarEquipoRegistrado();
                    //Thread actualizarEquipoRegistrado = new Thread(ActualizarEquipoRegistrado);
                    //actualizarEquipoRegistrado.Start();

                    usuario.BEstaConectadoAlSistema = true;
                    usuario.EsModificado = true;
                    manejador.Guardar(usuario);

                    p.Show();
                    cargarCaracteristicasVisualesDeServidor();

                }
                else
                {
                    //MostrarMensaje();
                    AgregarLoginFallido();
                    txt_contraseña.Text = "";
                    if (conteoRegistrosLimite > 2)
                    {
                        HerramientasWindow.MensajeAdvertenciaAlta("El equipo se bloqueará, favor de contactar al administrador.", "Equipo bloqueado");
                    }
                }
            }
            catch (Exception ex)
            {
                HerramientasWindow.MensajeError(ex, "Error: " + ex.Message, "Error");
            }
        }

        void p_seCerroSistema(Principal.RazonCierre razon)
        {
            try
            {
                if (razon == Principal.RazonCierre.TerminoSistema)
                {
                    return;
                }
                else if (razon == Principal.RazonCierre.CerroSesion)
                {
                    p = null;
                    ModoBloqueo = false;
                    UsuarioBloqueo = null;

                }
                else if (razon == Principal.RazonCierre.BloqueoSesion)
                {
                    ModoBloqueo = true;
                    UsuarioBloqueo = Principal.usuario;
                    p.EstaEnBloqueo = false;
                }
                OcultarMensaje();
                txt_contraseña.Text = "";
                txt_usuario.Focs();
                txt_usuario.SelectionStart = 0;
                txt_usuario.SelectionLength = txt_usuario.Text.Length;
                //if (p != null && p.EstaEnBloqueo)
                //{
                //    HerramientasWindow.MensajeInformacion("El sistema se encuentra bloqueado, ingrese nuevamente.", "Bloqueo de sistema");
                //}
                Show();
            }
            catch (Exception ex)
            {
            }
        }


        //private void btn_iniciar_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    try
        //    {
        //        lnLogin.VerificarExistenciaDeUsuarioAdmin();
        //        usuario = lnLogin.ValidarAcceso(txt_usuario.Text.Trim(), txt_contraseña.Text.Trim());
        //        if (usuario != null)
        //        {
        //            if (ModoBloqueo)
        //            {
        //                if (UsuarioBloqueo.Cuenta.Equals(usuario.Cuenta) && UsuarioBloqueo.Contrasena.Equals(HerramientasWindow.EncriptarConAES(txt_contraseña.Text)))
        //                {
        //                    p.ReiniciarAutobloqueo();
        //                }
        //                else
        //                {

        //                    HerramientasWindow.Mensaje("Verificar datos de acceso para el usuario que bloqueó el sistema.", "Verificar datos");
        //                    AgregarLoginFallido();
        //                    txt_contraseña.Text = "";
        //                    return;
        //                }
        //            }

        //            if (usuario.Contrasena != null && !usuario.Contrasena.Equals(HerramientasWindow.EncriptarConAES(txt_contraseña.Text)))
        //            {

        //                MostrarMensaje();//HerramientasWindow.Mensaje("Usuario o contraseña invalidos.", "Verificar datos");
        //                AgregarLoginFallido();
        //                txt_contraseña.Text = "";
        //                return;
        //            }

        //            if (!usuario.Cuenta.Equals("administrador") && usuario.BEstaDesactivado)
        //            {
        //                HerramientasWindow.Mensaje("Actualmente tu cuenta está desactivada, favor de contactar con el administrador de Sistemas.", "Cuenta desactivada");
        //                return;
        //            }

        //            _sis_EquiposRegistrados equipoRegistrado = manejador.Cargar<_sis_EquiposRegistrados>(_sis_EquiposRegistrados.ConsultaPorNombreEquipo, new List<object>() { Environment.MachineName });
        //            if (equipoRegistrado != null && equipoRegistrado.BEstaBloqueado && !usuario.EsAdministradorDeSistema)
        //            {
        //                HerramientasWindow.MensajeAdvertenciaAlta("El equipo actual se encuentra bloqueado, favor de contactar al administrador del Sistema.", "Equipo bloqueado");
        //                return;
        //            }
        //            variablesData.GuardarValorVariable("ultimo_usuario", txt_usuario.Text);


        //            accesosFallidos.Clear();
        //            if (p == null)
        //                p = new Principal(usuario, manejador);

        //            Hide();
        //            //ActualizarEquipoRegistrado();
        //            Thread actualizarEquipoRegistrado = new Thread(ActualizarEquipoRegistrado);
        //            actualizarEquipoRegistrado.Start();

        //            p.ShowDialog();
        //            cargarCaracteristicasVisualesDeServidor();
        //            if (!p.EstaEnBloqueo)
        //            {
        //                p = null;
        //                ModoBloqueo = false;
        //                UsuarioBloqueo = null;
        //            }
        //            else
        //            {
        //                ModoBloqueo = true;
        //                UsuarioBloqueo = Principal.usuario;

        //            }
        //            OcultarMensaje();
        //            txt_contraseña.Text = "";
        //            txt_usuario.Focs();
        //            txt_usuario.SelectionStart = 0;
        //            txt_usuario.SelectionLength = txt_usuario.Text.Length;
        //            //if (p != null && p.EstaEnBloqueo)
        //            //{
        //            //    HerramientasWindow.MensajeInformacion("El sistema se encuentra bloqueado, ingrese nuevamente.", "Bloqueo de sistema");
        //            //}
        //            Show();
        //        }
        //        else
        //        {
        //            //MostrarMensaje();
        //            AgregarLoginFallido();
        //            txt_contraseña.Text = "";
        //            if (conteoRegistrosLimite > 2)
        //            {
        //                HerramientasWindow.MensajeAdvertenciaAlta("El equipo se bloqueará, favor de contactar al administrador.", "Equipo bloqueado");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        HerramientasWindow.MensajeError(ex,"Error: " + ex.Message, "Error");
        //    }
        //}

        public void MostrarMensaje()
        {
            Storyboard temblar = (Storyboard)this.FindResource("temblarMensaje");
            temblar.Begin();
        }
        public void OcultarMensaje()
        {
            Storyboard temblar = (Storyboard)this.FindResource("ocultarMensaje");
            temblar.Begin();
        }

        private void ActualizarEquipoRegistrado()
        {
            try
            {
                ManejadorDB manejadorOtro = new ManejadorDB();
                manejadorOtro.UsarAlmacenObjetos = false;
                _sis_EquiposRegistrados equipoRegistrado = manejadorOtro.Cargar<_sis_EquiposRegistrados>(_sis_EquiposRegistrados.ConsultaPorNombreEquipo, new List<object>() { Environment.MachineName });
                if (equipoRegistrado == null) equipoRegistrado = new _sis_EquiposRegistrados();
                equipoRegistrado.Manejador = manejadorOtro;
                equipoRegistrado.SUltimaIPInternet = ipInternet;
                equipoRegistrado.SNombreEquipo = Environment.MachineName;
                equipoRegistrado.SUltimaIPConexion = ipLocal;
                equipoRegistrado.UltimoUsuarioConexion = usuario;
                equipoRegistrado.BEstaBloqueado = false;
                equipoRegistrado.BEstaConectado = true;
                equipoRegistrado.EsModificado = true;
                manejadorOtro.Guardar(equipoRegistrado);
            }
            catch (Exception ex)
            {
                Dispatcher.Invoke(new Action(() =>
                {
                    HerramientasWindow.MensajeError(ex, "Error: " + ex.Message, "Error al actualizar la información del equipo.");
                }));
            }
        }
        private void AgregarLoginFallido()
        {
            try
            {
                _sis_AccesoFallido acceso = manejador.CrearObjeto<_sis_AccesoFallido>();
                acceso.SIPEquipo = ipLocal;
                acceso.SIpInternet = ipInternet;
                acceso.SNombreEquipo = Environment.MachineName;
                acceso.SUsuarioWindows = Environment.UserName;
                acceso.SUsuarioRegistrado = txt_usuario.Text;
                acceso.SContrasenaRegistrada = txt_contraseña.Text;
                acceso.EsModificado = true;
                manejador.Guardar(acceso);

                accesosFallidos.Add(acceso);

                if (accesosFallidos.Count > 2)
                {
                    Bitmap fotoUsuario = HerramientasWindow.ObtenerFotoDeWebCam();
                    _sis_LimiteAccesosFallidosAlcanzado limite = manejador.CrearObjeto<_sis_LimiteAccesosFallidosAlcanzado>();

                    limite.AccesosFallidos = accesosFallidos;
                    limite.FotoPantalla = manejador.CrearObjeto<_sis_ImagenAsociada>();
                    limite.FotoPantalla.EsModificado = true;
                    limite.FotoPantalla.Imagen = HerramientasWindow.ComprimirImagen(HerramientasWindow.ObtenerFotoPantalla(this), 1000, 600, System.Drawing.Imaging.ImageFormat.Jpeg);
                    limite.FotoWebCam = manejador.CrearObjeto<_sis_ImagenAsociada>();
                    limite.FotoWebCam.EsModificado = true;
                    limite.FotoWebCam.Imagen = HerramientasWindow.ComprimirImagen(fotoUsuario, 600, 400, System.Drawing.Imaging.ImageFormat.Jpeg);
                    limite.EsModificado = true;
                    Bitmap emailFotoPantalla = limite.FotoPantalla.Imagen;
                    Bitmap emailFotoWebcam = limite.FotoWebCam.Imagen;
                    manejador.Guardar(limite);
                    accesosFallidos.Clear();

                    List<_sis_Usuario> usuariosAdmins = manejador.CargarLista<_sis_Usuario>(_sis_Usuario.consultaPorUsuariosAdministradores);
                    String emails = "";
                    foreach (_sis_Usuario us in usuariosAdmins)
                    {
                        if (!us.SEmail.Trim().Equals(""))
                            emails += us.SEmail + "; ";
                    }
                    if(!emails.Trim().Equals(""))
                        emails = emails.Substring(0, emails.Length - 2);
                    if (!emails.Trim().Equals(""))
                    {
                        String detallesTecnicos = @"<p><strong>Detalles t&eacute;cnicos:</strong></p>

                    <ul>
	                    <li>IP(LAN|WAN): " + ipLocal + "|" + ipInternet + @"</li>
	                    <li>Nombre equipo: " + acceso.SNombreEquipo + @"</li>
	                    <li>Hora del evento: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + @"</li>
	                    <li>Sesión Windows: " + acceso.SUsuarioWindows + @"</li>
                        <li>Usuario registrado: " + acceso.SUsuarioRegistrado + @"</li>
                    </ul>";

                        String mensaje = @"
                    <h2><strong>Detecci&oacute;n de intruso en el sistema.</strong></h2>

                    <blockquote>
                    <p><em>Verificar archivos adjuntos.</em></p>
                    </blockquote>
                    ";
                        Adjunto adj1 = null;
                        Adjunto adj2 = null;
                        if (emailFotoPantalla != null)
                        {
                            adj1 = new Adjunto();
                            adj1.NombreArchivo = "fotoPantalla.jpg";
                            adj1.Stream = Herramientas.WPF.Utilidades.BitmapToStream(emailFotoPantalla);
                        }
                        if (emailFotoWebcam != null)
                        {
                            adj2 = new Adjunto();
                            adj2.NombreArchivo = "fotoWebcam.jpg";
                            adj2.Stream = Herramientas.WPF.Utilidades.BitmapToStream(emailFotoWebcam);
                        }
                        List<Adjunto> adjuntos = new List<Adjunto>();
                        adjuntos.Add(adj1);
                        adjuntos.Add(adj2);
                        try
                        {
                            EmailFormatos.EnviarMailAtencion(mensaje, "Intento de acceso no permitido detectado", detallesTecnicos, null, emails, adjuntos);
                        }
                        catch { }
                    }
                    fotoUsuario = null;
                    conteoRegistrosLimite++;

                    if (conteoRegistrosLimite == 2)
                    {
                        _sis_EquiposRegistrados equipoRegistrado = manejador.Cargar<_sis_EquiposRegistrados>(_sis_EquiposRegistrados.ConsultaPorNombreEquipo, new List<object>() { Environment.MachineName });
                        if (equipoRegistrado == null) equipoRegistrado = manejador.CrearObjeto<_sis_EquiposRegistrados>();

                        equipoRegistrado.SNombreEquipo = Environment.MachineName;
                        equipoRegistrado.SUltimaIPConexion = ipLocal;
                        equipoRegistrado.UltimoUsuarioConexion = usuario;
                        equipoRegistrado.BEstaBloqueado = true;
                        equipoRegistrado.BEstaConectado = false;
                        equipoRegistrado.EsModificado = true;
                        manejador.Guardar(equipoRegistrado);
                        HerramientasWindow.MensajeAdvertencia("Por seguridad se ha bloqueado el equipo. Favor de contactar al administrador del Sistema.", "Bloqueo de seguridad");
                    }
                }
            }
            catch (Exception ex)
            {
                HerramientasWindow.MensajeError(ex, "Error: " + ex.Message, "Error");
            }
        }

        private void btn_cancelar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ModoBloqueo)
                HerramientasWindow.Mensaje("Actualmente se encuentra bloquedo el sistema por el usuario: \n-" + UsuarioBloqueo.Cuenta, "Mensaje");
            else
                System.Windows.Application.Current.Shutdown();
        }

        private void img_imagenConfiguracion_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AlmacenObjetos.BorrarAlmacen();
            ConfiguraciónEnLogin conf = new ConfiguraciónEnLogin();
            conf.ShowDialog();
            try
            {
                CargarValoresVariablesLocales();
                CargarCaracteristicasVisuales();
                lnLogin = new sis_ln_Login();
                lnLogin.enviarMensaje += HerramientasWindow.MensajeLogicaNegocios;
                manejador = new ManejadorDB();
                cargarCaracteristicasVisualesDeServidor();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al iniciar Sistema");
            }
        }


        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (IsVisible)
            {
                txt_usuario.Focs();
                txt_usuario.SelectionStart = 0;
                txt_usuario.SelectionLength = txt_usuario.Text.Length;
            }
        }

    }
}
