using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using ICSharpCode.SharpZipLib.Zip;
using System.Diagnostics;

namespace Aplicacion
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class Actualizacion : Window
    {
        private DBAcceso dbAcceso;
        private Variable variableCONN;
        private Variable variableDATA;
        private String ConexionGenerica = "data source = @servidorInstancia; initial catalog = @bd; user id = @usuario; password = @contraseña;";
        private int versionActual;
        private Boolean EstaEnModoPruebas = false;
        private Boolean HuboError = false;
        Storyboard girar;
        public Actualizacion()
        {
            InitializeComponent();
            variableCONN = new Variable("conn.conf");
            variableDATA = new Variable("data.conf");
            CargarDatosServidor();
            girar = (Storyboard)this.Resources["esferas"];
            girar.RepeatBehavior = new RepeatBehavior(100);
            BeginStoryboard(girar);

            img_cerrar.MouseDown += img_cerrar_MouseDown;
            img_cerrar.Visibility = System.Windows.Visibility.Hidden;
            img_cerrar_reflejo.Visibility = System.Windows.Visibility.Hidden;

            EstaEnModoPruebas = variableDATA.ObtenerValorVariable<Boolean>("esta_en_modo_pruebas");


            Thread t = new Thread(proceso);
            t.Start();
        }

        void img_cerrar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
        private void proceso()
        {
            CerrarSistema();
            Thread.Sleep(1000);
            if (HayActualizacion())
            {
                if (Actualizar())
                {
                    if (!HuboError)
                    {
                        AbrirSistema();
                    }
                    else
                    {
                        Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => Cursor = null));
                        Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => this.txt_mensaje.Content = "Error al iniciar, ver error en la cruz."));
                    }
                }
            }
            else
            {
                if (!HuboError)
                {
                    Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => this.txt_mensaje.Content = "El sistema se encuentra actualizado."));
                    Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => this.Title = this.txt_mensaje.Content.ToString()));
                    Thread.Sleep(1300);

                    AbrirSistema();
                }
                else
                {
                    
                    Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => Cursor = null));
                    Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => this.txt_mensaje.Content = "Error al iniciar, ver error en la cruz."));
                }
            }
        }
        private Boolean Actualizar()
        {
            try
            {
                dbAcceso.AbrirConexion();

                String query = "";
                if (EstaEnModoPruebas)
                    query = "select id from _sis_VersionesDeSistema where id > @versionActual order by id asc";
                else
                    query = "select id from _sis_VersionesDeSistema where _bEsVersionLiberada = 1 and id > @versionActual order by id asc";

                DataTable dt = dbAcceso.EjecutarConsulta(query, new List<object>() { versionActual });
                if (dt.Rows.Count > 0)
                {
                    //se actualiza a versiones superiores
                    foreach (DataRow dr in dt.Rows)
                    {
                        Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => this.txt_mensaje.Content = "Actualizando a la versión " + dr[0].ToString() + "..."));
                        Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => this.Title = this.txt_mensaje.Content.ToString()));
                        DataTable zip = dbAcceso.EjecutarConsulta("select id, _oArchivoDeVersion from _sis_VersionesDeSistema where id = @id", new List<object>() { Convert.ToInt32(dr[0]) });
                        Object objZip = (Object)zip.Rows[0]["_oArchivoDeVersion"];
                        actualizarVersion(objZip, zip.Rows[0]["id"].ToString());
                    }
                }
                else
                {
                    //se baja actualizacion
                    String queryDownID = "";
                    String queryDown = "";
                    if (EstaEnModoPruebas)
                    {
                        queryDownID = "select top 1 id from _sis_VersionesDeSistema order by id desc";
                        queryDown = "select top 1 id, _oArchivoDeVersion from _sis_VersionesDeSistema order by id desc";
                    }
                    else
                    {
                        queryDownID = "select top 1 id from _sis_VersionesDeSistema where _bEsVersionLiberada = 1 order by id desc";
                        queryDown = "select top 1 id, _oArchivoDeVersion from _sis_VersionesDeSistema where _bEsVersionLiberada = 1 order by id desc";
                    }
                    DataTable dtDownID = dbAcceso.EjecutarConsulta(queryDownID);
                    Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => this.txt_mensaje.Content = "Regresando a la versión " + dtDownID.Rows[0]["id"].ToString() + "..."));
                    Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => this.Title = this.txt_mensaje.Content.ToString()));
                    DataTable dtDown = dbAcceso.EjecutarConsulta(queryDown);
                    Object objZip = (Object)dtDown.Rows[0]["_oArchivoDeVersion"];
                    actualizarVersion(objZip, dtDown.Rows[0]["id"].ToString());
                }
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => this.txt_mensaje.Content = "Se actualizó correctamente."));
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => this.Title = this.txt_mensaje.Content.ToString()));
                Thread.Sleep(1300);
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => this.txt_mensaje.Content = "Iniciando sistema..."));
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => this.Title = this.txt_mensaje.Content.ToString()));
                Thread.Sleep(1300);
                return true;
            }
            catch (Exception ex)
            {
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => this.txt_mensaje.Content = "Ocurrio un error, verificar con Sistemas."));
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => this.Title = this.txt_mensaje.Content.ToString()));
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => this.txt_mensaje.ToolTip = ex.Message));
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => img_cerrar.Visibility = System.Windows.Visibility.Visible));
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => img_cerrar_reflejo.Visibility = System.Windows.Visibility.Visible));
                HuboError = true;
                img_cerrar.ToolTip = ex.Message;
                return false;
            }
        }
        private void actualizarVersion(Object objZip, string Version)
        {
            try
            {
                System.IO.File.WriteAllBytes(Environment.CurrentDirectory + @"\Update.zip", (byte[])(objZip));

                FastZip fZip = new FastZip();
                fZip.ExtractZip(Environment.CurrentDirectory + @"\Update.zip", Environment.CurrentDirectory + @"\", FastZip.Overwrite.Always, null, null, null, false);

                System.IO.File.Delete(Environment.CurrentDirectory + @"\Update.zip");
                variableDATA.GuardarValorVariable("version_actual", Version);
                Thread.Sleep(400);
            }
            catch (Exception ex)
            {
                HuboError = true;
                img_cerrar.ToolTip = ex.Message;
                throw new Exception(ex.Message);

            }
        }
        private Boolean HayActualizacion()
        {
            try
            {
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => this.Title = "Buscando actualizaciones..."));

                String query = "";
                if (EstaEnModoPruebas)
                    query = "select top 1 id from _sis_VersionesDeSistema order by id desc";
                else
                    query = "select top 1 id from _sis_VersionesDeSistema where _bEsVersionLiberada = 1 order by id desc";


                String queryConsulta = query;//"select top 1 id from _sis_VersionesDeSistema where _bEsVersionLiberada = 1 order by id desc";
                dbAcceso.AbrirConexion();
                DataTable resultado = dbAcceso.EjecutarConsulta(queryConsulta);
                dbAcceso.CerrarConexion();

                if (resultado.Rows.Count > 0)
                {
                    int versionServidor = Convert.ToInt32(resultado.Rows[0][0]);
                    versionActual = variableDATA.ObtenerValorVariable<int>("version_actual");
                    if (versionActual != versionServidor)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Dispatcher.Invoke(new Action(() =>
                   {
                       MessageBox.Show("Error: No fue posible buscar la actualización debido a problemas de conexión.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                       img_cerrar.Visibility = System.Windows.Visibility.Visible;
                       img_cerrar_reflejo.Visibility = System.Windows.Visibility.Visible;
                       img_cerrar.ToolTip = "No fue posible buscar la actualización debido a problemas de conexión.";
                   }));
                HuboError = true;
                return false;
            }
        }
        private void CargarDatosServidor()
        {
            String servidorInstancia = CifradoMD5.DesencriptarTexto(variableCONN.ObtenerValorVariable<String>("ServidorInstancia"));
            String baseDatos = CifradoMD5.DesencriptarTexto(variableCONN.ObtenerValorVariable<String>("BaseDeDatos"));
            String usuario = CifradoMD5.DesencriptarTexto(variableCONN.ObtenerValorVariable<String>("Usuario"));
            String contraseña = CifradoMD5.DesencriptarTexto(variableCONN.ObtenerValorVariable<String>("Contraseña"));

            try
            {
                String conexion = ConexionGenerica.Replace("@servidorInstancia", servidorInstancia).Replace("@bd", baseDatos).Replace("@usuario", usuario).Replace("@contraseña", contraseña);
                dbAcceso = new DBAcceso(conexion);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                img_cerrar.Visibility = System.Windows.Visibility.Visible;
                img_cerrar.ToolTip = ex.Message;
                img_cerrar_reflejo.Visibility = System.Windows.Visibility.Visible;
                HuboError = true;
            }
        }
        private void CerrarSistema()
        {
            try
            {
                //System.Diagnostics.Process p = new System.Diagnostics.Process();
                //p.StartInfo.FileName = Environment.CurrentDirectory + @"\Vistas.exe";
                //p.StartInfo.WorkingDirectory = Environment.CurrentDirectory + @"\";
                //p.Kill();


                Process[] pArray = Process.GetProcessesByName("vistas");
                if (pArray.Length > 0)
                {
                    pArray[0].Kill();
                }

            }
            catch { }
        }
        private void AbrirSistema()
        {
            try
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = Environment.CurrentDirectory + @"\Vistas.exe";
                p.StartInfo.WorkingDirectory = Environment.CurrentDirectory + @"\";
                p.Start();
                p.Dispose();
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => this.Close()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => this.Close()));
                HuboError = true;
                img_cerrar.ToolTip = ex.Message;
            }
        }
    }
}
