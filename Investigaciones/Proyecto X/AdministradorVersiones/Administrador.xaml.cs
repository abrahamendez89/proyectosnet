using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Dominio;
using Dominio.Sistema;
using Herramientas.Archivos;
using Herramientas.Cifrado;
using InterfazWPF.AdministracionSistema;
using Ionic.Zip;
using Herramientas.ORM;
using Herramientas.SQL;

namespace AdministradorVersiones
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class Administrador : Window
    {
        private ManejadorDB manejador;
        private Variable variableCONN; 
        private String ConexionGenerica = "data source = @servidorInstancia; initial catalog = @bd; user id = @usuario; password = @contraseña;";
        
        public Administrador()
        {
            InitializeComponent();
            CargarDatosConexion();
        }
        private void CargarDatosConexion()
        {
            try
            {
                variableCONN = new Variable("conn.conf");
                String servidorInstancia = CifradoMD5.DesencriptarTexto(variableCONN.ObtenerValorVariable<String>("ServidorInstancia"));
                String baseDatos = CifradoMD5.DesencriptarTexto(variableCONN.ObtenerValorVariable<String>("BaseDeDatos"));
                String usuario = CifradoMD5.DesencriptarTexto(variableCONN.ObtenerValorVariable<String>("Usuario"));
                String contraseña = CifradoMD5.DesencriptarTexto(variableCONN.ObtenerValorVariable<String>("Contraseña"));

                txt_bd.Text = baseDatos;
                txt_contrasena.Password = contraseña;
                txt_servidor.Text = servidorInstancia;
                txt_usuario.Text = usuario;

            }
            catch (Exception ex)
            {
                HerramientasWindow.MensajeErrorSimple(ex.Message, "Error");
            }
        }
        private void CargarDatos()
        {
            DataTable dt = manejador.EjecutarConsulta("select id, _sCambiosEnLaVersion, _bEsVersionLiberada, dtFechaCreacion from _sis_VersionesDeSistema order by id desc");
            dt.Columns[0].ColumnName = "Número de versión";
            dt.Columns[1].ColumnName = "Cambios en la versión";
            dt.Columns[2].ColumnName = "Estado de la versión(check = liberada)";
            dt.Columns[3].ColumnName = "Fecha publicación";
            dgr_versiones.ItemsSource = dt.DefaultView;

            //limpiando datos
            txt_cambiosVersion.IsEnabled = true;
            txt_cambiosVersion.Text = "";
            txt_rutaArchivo.Text = "";
            btn_cargarArchivo.Content = "Cargar";

        }
        private void btn_conectar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String conexion = ConexionGenerica.Replace("@servidorInstancia", txt_servidor.Text).Replace("@bd", txt_bd.Text).Replace("@usuario", txt_usuario.Text).Replace("@contraseña", txt_contrasena.Password);
                SQLServer sql = new SQLServer();
                sql.ConfigurarConexion(conexion);

                manejador = new ManejadorDB(sql);
                HerramientasWindow.Mensaje("Conexión establecida.", "Mensaje");
                CargarDatos();
            }
            catch (Exception ex)
            {
                HerramientasWindow.MensajeErrorSimple(ex.Message, "Error");
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            variableCONN.GuardarValorVariable("ServidorInstancia", CifradoMD5.EncriptarTexto(txt_servidor.Text));
            variableCONN.GuardarValorVariable("BaseDeDatos", CifradoMD5.EncriptarTexto(txt_bd.Text));
            variableCONN.GuardarValorVariable("Usuario", CifradoMD5.EncriptarTexto(txt_usuario.Text));
            variableCONN.GuardarValorVariable("Contraseña", CifradoMD5.EncriptarTexto(txt_contrasena.Password));
            variableCONN.ActualizarArchivo();
            System.Windows.Application.Current.Shutdown();
        }
        private string ruta;
        private void btn_cargarArchivo_Click(object sender, RoutedEventArgs e)
        {
            if (btn_cargarArchivo.Content.Equals("Cargar"))
            {
                FolderBrowserDialog ofd = new FolderBrowserDialog();
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ruta = ofd.SelectedPath;
                    txt_rutaArchivo.Text = ofd.SelectedPath;
                }
            }
            else
            {
                FolderBrowserDialog ofd = new FolderBrowserDialog();
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    DataTable dt = manejador.EjecutarConsulta("select id, _oArchivoDeVersion from _sis_VersionesDeSistema where id = @id", new List<object>() { idVersionSeleccionada });

                    byte[] data = (byte[])dt.Rows[0]["_oArchivoDeVersion"];
                    System.IO.File.WriteAllBytes(ofd.SelectedPath + @"\version_" + idVersionSeleccionada + ".zip", data);
                    //System.IO.File.WriteAllBytes(ofd.SelectedPath + @"\version_" + versionSeleccionada.Id + ".zip", (byte[])versionSeleccionada.OArchivoDeVersion);
                    HerramientasWindow.Mensaje("Se guardó el archivo 'version_" + idVersionSeleccionada + ".zip' en la ruta: '" + ofd.SelectedPath + "'", "Descarga exitosa");
                }
                
            }
        }

        private void btn_guardarVersion_Click(object sender, RoutedEventArgs e)
        {
            if (manejador == null) { HerramientasWindow.MensajeErrorSimple("Debe conectarse a una base de datos.", "Error"); return; }
            
            
            
            if (btn_cargarArchivo.Content.ToString().Equals("Cargar"))
            {
                if (versionSeleccionada == null) versionSeleccionada = manejador.CrearObjeto<_sis_VersionesDeSistema>();
                versionSeleccionada.EsModificado = true;
                Object objetoZip = CargarZIPComoObject(ruta);
                versionSeleccionada.OArchivoDeVersion = objetoZip;
                versionSeleccionada.SCambiosEnLaVersion = txt_cambiosVersion.Text;

                versionSeleccionada.BEsVersionLiberada = (bool)chb_liberarVersion.IsChecked;
                manejador.Guardar(versionSeleccionada);
                versionSeleccionada = null;
            }
            else
            {
                //solo se actualiza los datos de la version
                manejador.EjecutarConsulta("update _sis_VersionesDeSistema set _bEsVersionLiberada = @_bEsVersionLiberada where id = @id", new List<object>() { (Boolean)chb_liberarVersion.IsChecked, idVersionSeleccionada });
            }
            CargarDatos();
        }
        public byte[] CargarZIPComoObject(String ruta)
        {
            String nombreArchivoTemporal = "temp" + DateTime.Now.ToString("yyMMddHHmmss")+".zip" ;
            ZipFile zip = new ZipFile();
            zip.AddDirectory(ruta);
            zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression;
            zip.Save(ruta + @"\" + nombreArchivoTemporal);
            byte[] objetoZip = System.IO.File.ReadAllBytes(ruta + @"\" + nombreArchivoTemporal);
            System.IO.File.Delete(ruta + @"\" + nombreArchivoTemporal);
            return objetoZip;
        }
        _sis_VersionesDeSistema versionSeleccionada;
        long idVersionSeleccionada = -1;
        private void dgr_versiones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView row = (DataRowView)((System.Windows.Controls.DataGrid)sender).SelectedItem;
            if (row == null) return;
            long id = (long)row.Row[0];

            idVersionSeleccionada = id;

            DataTable dt = manejador.EjecutarConsulta("select id, _sCambiosEnLaVersion, _bEsVersionLiberada, dtFechaCreacion from _sis_VersionesDeSistema where id = @id", new List<object>() { id });
            txt_cambiosVersion.Text = dt.Rows[0]["_sCambiosEnLaVersion"].ToString();
            chb_liberarVersion.IsChecked = Convert.ToBoolean(dt.Rows[0]["_bEsVersionLiberada"]);
            txt_rutaArchivo.Text = "Fecha de publicación de la actualización: " + Convert.ToDateTime(dt.Rows[0]["dtFechaCreacion"]).ToString("G");
            txt_cambiosVersion.IsEnabled = false;
            btn_cargarArchivo.Content = "Descargar";


            //versionSeleccionada = manejador.Cargar<_sis_VersionesDeSistema>(_sis_VersionesDeSistema.ConsultaPorID, new List<object>() { id });

            //txt_cambiosVersion.Text = versionSeleccionada.SCambiosEnLaVersion;
            //txt_cambiosVersion.IsEnabled = false;
            ////btn_cargarArchivo.IsEnabled = false;
            //txt_rutaArchivo.Text = "ARCHIVO DE " + String.Format("{0:0.##}",(((byte[])versionSeleccionada.OArchivoDeVersion).Length / 1024.0 / 1024.0)) + " Megabytes.";
            //chb_liberarVersion.IsChecked = versionSeleccionada.BEsVersionLiberada;
            //btn_cargarArchivo.Content = "Descargar";

        }

        private void btn_NuevoVersion_Click(object sender, RoutedEventArgs e)
        {
            txt_cambiosVersion.Text = "";
            chb_liberarVersion.IsChecked = false;
            txt_rutaArchivo.Text = "";
            btn_cargarArchivo.Content = "Cargar";
            idVersionSeleccionada = -1;
            versionSeleccionada = null;
        }

    }
}
