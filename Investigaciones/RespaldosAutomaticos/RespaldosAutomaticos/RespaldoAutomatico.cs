using Dominio;
using Herramientas.Archivos;
using Herramientas.ORM;
using Herramientas.SQL;
using Herramientas.Web;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace RespaldosAutomaticos
{
    public partial class RespaldoAutomatico : Form
    {
        iSQL sql;
        ManejadorDB manejador;
        WebBrowser wb;
        _CuentaNube cuenta;
        List<_DirectoriosRespaldar> rutas;
        public RespaldoAutomatico()
        {
            InitializeComponent();
            this.FormClosing += RespaldoAutomatico_FormClosing;
            pb_agregarRuta.MouseClick += pb_agregarRuta_MouseClick;
            pb_quitarRuta.MouseClick += pb_quitarRuta_MouseClick;
            pb_guardar.MouseClick += pb_guardar_MouseClick;
            lb_rutas.MouseDoubleClick += lb_rutas_MouseDoubleClick;

            sql = new SQLite();
            sql.ConfigurarConexion("data.db", false);
            manejador = new ManejadorDB(sql);
            wb = new WebBrowser();
            CargarHoras();
            CargarCuenta();
            CargarDirectorios();


            Thread tMonitoreo = new Thread(MonitoreoHoras);
            tMonitoreo.SetApartmentState(ApartmentState.STA);
            tMonitoreo.IsBackground = true;
            tMonitoreo.Start();
            //tMonitoreo.Join();
        }

        void lb_rutas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lb_rutas.SelectedItem != null)
            {
                CargarRuta(rutas[lb_rutas.SelectedIndex]);
            }
        }
        private void CargarRuta(_DirectoriosRespaldar dir)
        {
            cmb_hora.SelectedItem = dir.HoraProgramada.ToString("00");
            cmb_minuto.SelectedItem = dir.MinutoProgramado.ToString("00");
            txt_carpetaDestino.Text = dir.CarpetaDestinoEnServicio;
            chb_lunes.Checked = dir.EnLunes;
            chb_martes.Checked = dir.EnMartes;
            chb_miercoles.Checked = dir.EnMiercoles;
            chb_jueves.Checked = dir.EnJueves;
            chb_viernes.Checked = dir.EnViernes;
            chb_sabado.Checked = dir.EnSabado;
            chb_domingo.Checked = dir.EnDomingo;
        }
        void pb_guardar_MouseClick(object sender, MouseEventArgs e)
        {
            if (lb_rutas.SelectedItem != null)
            {
                GuardarRuta(rutas[lb_rutas.SelectedIndex], lb_rutas.SelectedItem.ToString());
            }
        }

        private void MonitoreoHoras(object obj)
        {
            while (true)
            {
                List<_DirectoriosRespaldar> rutas = manejador.CargarLista<_DirectoriosRespaldar>("select * from _DirectoriosRespaldar");
                if (rutas != null)
                {
                    foreach (_DirectoriosRespaldar dir in rutas)
                    {
                        if (dir.HoraProgramada == DateTime.Now.Hour && dir.MinutoProgramado == DateTime.Now.Minute)
                        {
                            String rutaZip = dir.Ruta + "\\" + Herramientas.Archivos.Archivo.ObtenerNombreCarpetaDeDirectorio(dir.Ruta) + "_" + Herramientas.Conversiones.Formatos.DateTimeAFechaLOGArchivo(DateTime.Now) + ".zip";
                            Zip.ComprimirDirectorioEnZip(dir.Ruta, rutaZip);


                            OneDriveAPI one = new OneDriveAPI(cuenta.Cuenta, cuenta.Contra);
                            one.error += one_error;
                            one.envioTerminado += one_envioTerminado;
                            one.porcentajeEnviado += one_porcentajeEnviado;
                            one.SubirArchivoACarpetaHilo(rutaZip, dir.CarpetaDestinoEnServicio);
                        }
                    }
                }

                Thread.Sleep(30000);
            }
        }

        void one_porcentajeEnviado(double porcentaje)
        {

        }

        void one_envioTerminado(string rutaArchivo)
        {

        }

        void one_error(string rutaArchivo, Exception ex)
        {

        }

        private void CargarHoras()
        {
            for (int i = 0; i < 24; i++)
                cmb_hora.Items.Add(i.ToString("00"));

            for (int i = 0; i < 60; i++)
                cmb_minuto.Items.Add(i.ToString("00"));
        }

        void pb_quitarRuta_MouseClick(object sender, MouseEventArgs e)
        {
            if (lb_rutas.SelectedItem != null)
            {
                string query = "delete from _DirectoriosRespaldar where id = @id";
                List<object> valores = new List<object>();
                valores.Add(rutas[lb_rutas.SelectedIndex].Id);
                manejador.EjecutarConsulta(query, valores);
                CargarDirectorios();
            }
        }

        void pb_agregarRuta_MouseClick(object sender, MouseEventArgs e)
        {
            String ruta = Herramientas.Archivos.Dialogos.BuscarCarpeta(Environment.GetFolderPath(Environment.SpecialFolder.MyComputer));
            if (ruta != "")
            {
                GuardarRuta(null, ruta);
            }
        }

        private void GuardarRuta(_DirectoriosRespaldar dir, String ruta)
        {
            if (dir == null) dir = new _DirectoriosRespaldar();
            dir.EsModificado = true;
            dir.Ruta = ruta;
            dir.HoraProgramada = Convert.ToInt32(cmb_hora.SelectedItem.ToString());
            dir.MinutoProgramado = Convert.ToInt32(cmb_minuto.SelectedItem.ToString());
            dir.CarpetaDestinoEnServicio = txt_carpetaDestino.Text.Trim();
            dir.EnLunes = chb_lunes.Checked;
            dir.EnMartes = chb_martes.Checked;
            dir.EnMiercoles = chb_miercoles.Checked;
            dir.EnJueves = chb_jueves.Checked;
            dir.EnViernes = chb_viernes.Checked;
            dir.EnSabado = chb_sabado.Checked;
            dir.EnDomingo = chb_domingo.Checked;
            manejador.Guardar(dir);
            CargarDirectorios();
        }

        void RespaldoAutomatico_FormClosing(object sender, FormClosingEventArgs e)
        {
            GuardarCuenta();
        }

        private void CargarDirectorios()
        {
            lb_rutas.Items.Clear();
            rutas = manejador.CargarLista<_DirectoriosRespaldar>("select * from _DirectoriosRespaldar");
            if (rutas != null)
            {
                foreach (_DirectoriosRespaldar dir in rutas)
                {
                    lb_rutas.Items.Add(dir.Ruta);
                }
            }

        }
        private void GuardarCuenta()
        {
            try
            {
                if (!txt_usuario.Text.Trim().Equals("") && !txt_contra.Text.Trim().Equals(""))
                {
                    if (cuenta == null) cuenta = new _CuentaNube();
                    cuenta.EsModificado = true;
                    cuenta.Cuenta = txt_usuario.Text;
                    cuenta.Contra = txt_contra.Text;
                    manejador.Guardar(cuenta);
                }
            }
            catch (Exception ex)
            {
                Herramientas.Forms.Mensajes.Error(ex.Message);
            }
        }
        private void CargarCuenta()
        {
            cuenta = manejador.Cargar<_CuentaNube>("select * from _CuentaNube");
            if (cuenta != null)
            {
                txt_usuario.Text = cuenta.Cuenta;
                txt_contra.Text = cuenta.Contra;
            }
        }
    }
}
