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
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using VNCViewerLauncher.ControlesUsuario;

namespace VNCViewerLauncher
{
    public partial class Principal : Form
    {
        iSQL sql;
        ManejadorDB manejador;

        List<_Grupo> gruposRegistrados;
        _Grupo grupoSeleccionado;
        UCGrupo ucgrupoSeleccionado;
        Variable var;
        Thread tSoporte;
        String server;
        String bd;
        String user;
        String pass;
        public Principal()
        {
            InitializeComponent();
            lbl_seleccionado.Text = "";
            this.FormClosing += Principal_FormClosing;
            CheckForIllegalCrossThreadCalls = false;
            this.VisibleChanged += Principal_VisibleChanged;
            this.pnl_equiposEnGrupo.Resize += pnl_equiposEnGrupo_Resize;

            try
            {
                var = new Variable("config.conf");

                server = var.ObtenerValorVariable<String>("SERVER");
                bd = var.ObtenerValorVariable<String>("BD");
                user = var.ObtenerValorVariable<String>("USUARIO");
                pass = var.ObtenerValorVariable<String>("CONTRASEÑA");

                sql = new SQLServer();
                sql.ConfigurarConexion(server, bd, user, pass);

                //sql = new SQLite();
                //sql.ConfigurarConexion("data.db", false);

                manejador = new ManejadorDB(sql);


                CargarGrupos();

                CambiarWidthGrupos();
                pictureBox1_Click(null, null);
                ActualizarEquiposConectados(manejador);


                //tSoporte = new Thread(MonitoreoSoporte);
                //tSoporte.IsBackground = true;
                //tSoporte.Start();

                //Thread tEquipos = new Thread(EquiposConectados);
                //tEquipos.IsBackground = true;
                //tEquipos.Start();
            }
            catch (Exception ex)
            {
                Herramientas.Forms.Mensajes.Error(ex.Message);
            }
        }

        void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
        private void ActualizarEquiposConectados(ManejadorDB mane)
        {
            try
            {
                try
                {
                    dgv_equiposConectados.Rows.Clear();
                }
                catch
                {
                }
                DataTable solicitudes = mane.EjecutarConsulta("select id as [ID], _NombreEquipo as [Nombre equipo], _ip as [IP], _UsuarioLogin as [Usuario Logueado], _NombreReferencia as [Nombre de Referencia], _Anotaciones as [Notas] from _EquipoEstatus where DATEDIFF(ss, dtFechaModificacion, GETDATE()) < 15 and (_NombreReferencia like '%" + txt_filtroEquiposConectados.Text + "%' or _NombreEquipo like '%" + txt_filtroEquiposConectados.Text + "%' or _UsuarioLogin like '%" + txt_filtroEquiposConectados.Text + "%')");
                dgv_equiposConectados.DataSource = solicitudes;
                dgv_equiposConectados.Refresh();
                txt_filtroEquiposConectados.Text = "";
            }
            catch
            {

            }
        }
        
        private void dgv_soporte_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }
        void pnl_equiposEnGrupo_Resize(object sender, EventArgs e)
        {
            foreach (Control ctrl in pnl_equiposEnGrupo.Controls)
            {
                ctrl.Width = CalcularWeightEquipos(252);
            }
        }
        private int CalcularWeightEquipos(int width)
        {
            double ancho = 30;

            double anchoNeto = ((double)pnl_equiposEnGrupo.Width - ancho);

            double caben = (anchoNeto - ancho) / (double)width;

            double restante = (anchoNeto * 0.98) - ((double)width * (int)caben);


            int widthMod = (int)(width + (((restante) / (int)caben)));

            if (widthMod * (int)caben < (anchoNeto))

                return widthMod; //(int)((((double)pnl_equiposEnGrupo.Width - ancho) / caben));
            return width;
        }
        void Principal_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                Acceso acceso = new Acceso();
                acceso.ShowDialog();

                if (!acceso.Aprobado)
                    Application.Exit();

                acceso.Close();
            }
        }

        private void CargarGrupos()
        {
            gruposRegistrados = manejador.CargarLista<_Grupo>("select * from _Grupo");
            pnl_grupos.Controls.Clear();
            if (gruposRegistrados != null)
            {
                foreach (_Grupo grp in gruposRegistrados)
                {
                    UCGrupo grupo = new UCGrupo(grp);
                    grupo.SeSelecciono += grupo_SeSelecciono;
                    grupo.eventoEditar += grupo_eventoEditar;
                    grupo.eventoEliminar += grupo_eventoEliminar;
                    pnl_grupos.Controls.Add(grupo);
                }
            }
            UCAgregarGrupo agregarGrupo = new UCAgregarGrupo();
            agregarGrupo.click += agregarGrupo_click;
            pnl_grupos.Controls.Add(agregarGrupo);
        }

        void grupo_eventoEliminar(UCGrupo grupo)
        {
            Dialogo dia = new Dialogo("¿Desea eliminar el grupo '" + grupo.Grupo.St_NombreGrupo + "' con " + grupo.Grupo.EquiposEnGrupo + " equipos registrados?", "Eliminar grupo");
            dia.ShowDialog();
            if (dia.Respuesta)
            {
                String query = "delete from _Grupo where id = " + grupo.Grupo.Id;
                String queryRel = "delete from _Grupo_X__Equipo__ll_equiposEnGrupo where _contenedor = " + grupo.Grupo.Id;
                String queryElimEquipos = "delete from _Equipo where id in(select _contenido from _Grupo_X__Equipo__ll_equiposEnGrupo where _contenedor = " + grupo.Grupo.Id + ")";

                manejador.IniciarTransaccion();

                manejador.EjecutarConsulta(queryElimEquipos);
                manejador.EjecutarConsulta(queryRel);
                manejador.EjecutarConsulta(query);
                txt_busqueda.Text = "";
                manejador.TerminarTransaccion();
                CargarGrupos();
            }
            dia.Close();
        }

        void grupo_eventoEditar(UCGrupo grupo)
        {
            AgregarGrupo agr = new AgregarGrupo();
            agr.GrupoCreado = grupo.Grupo;
            agr.Text = "Modificar grupo";
            agr.ShowDialog();

            if (agr.GuardarCambios)
            {
                manejador.Guardar(grupo.Grupo);
                CargarGrupos();
                txt_busqueda.Text = "";
            }
            agr.Close();
        }

        void agregarGrupo_click()
        {
            AgregarGrupo agr = new AgregarGrupo();
            agr.ShowDialog();

            _Grupo grupo = agr.GrupoCreado;

            if (grupo != null && agr.GuardarCambios)
            {
                if (gruposRegistrados == null) gruposRegistrados = new List<_Grupo>();
                gruposRegistrados.Add(grupo);
                manejador.Guardar(grupo);

                pnl_equiposEnGrupo.Controls.Clear();
                txt_busqueda.Text = "";
                CargarGrupos();
            }
            agr.Close();

        }

        private void CargarEquiposDeGrupoSeleccionado(List<_Equipo> equipos)
        {
            

            pnl_equiposEnGrupo.Controls.Clear();
            if (equipos != null)
            {
                foreach (_Equipo equip in equipos)
                {
                    

                    UCEquipoComputo equipo = new UCEquipoComputo(equip);
                    equipo.eventoRealVNC += equipo_eventoRealVNC;
                    equipo.eventoUltraVNC += equipo_eventoUltraVNC;
                    equipo.eventoEditar += equipo_eventoEditar;
                    equipo.eventoEliminar += equipo_eventoEliminar;

                    equipo.Width = CalcularWeightEquipos(252);

                    pnl_equiposEnGrupo.Controls.Add(equipo);
                }
            }
            UCAgregarEquipoComputo agregarEquipo = new UCAgregarEquipoComputo();
            agregarEquipo.click += agregarEquipo_click;
            agregarEquipo.Width = CalcularWeightEquipos(252);

            pnl_equiposEnGrupo.Controls.Add(agregarEquipo);

        }

        void equipo_eventoUltraVNC(UCEquipoComputo equipo)
        {
            VNC(equipo.Equipo, "ultravnc");
        }

        void equipo_eventoRealVNC(UCEquipoComputo equipo)
        {
            VNC(equipo.Equipo, "realvnc");
        }

        void agregarEquipo_click()
        {
            AgregarEquipo agr = new AgregarEquipo();
            agr.ShowDialog();
            _Equipo equipo = agr.Equipo;

            if (equipo != null && agr.GuardarCambios)
            {
                //try
                //{
                if (this.grupoSeleccionado.Ll_equiposEnGrupo == null) this.grupoSeleccionado.Ll_equiposEnGrupo = new List<_Equipo>();
                this.grupoSeleccionado.Ll_equiposEnGrupo.Add(equipo);
                this.grupoSeleccionado.EsModificado = true;
                equipo.EsModificado = true;
                manejador.IniciarTransaccion();
                manejador.Guardar(this.grupoSeleccionado);
                //manejador.Guardar(equipo);
                manejador.TerminarTransaccion();
                this.grupoSeleccionado.EliminarCache();
                this.ucgrupoSeleccionado.ActualizarConteo();
                CargarEquiposDeGrupoSeleccionado(this.grupoSeleccionado.Ll_equiposEnGrupo);
                txt_busqueda.Text = "";
                //}
                //catch (Exception ex)
                //{
                //    manejador.DeshacerTransaccion();
                //    Dialogo d = new Dialogo("Error: " + ex.Message, "Error al guardar");
                //    d.ShowDialog();
                //}
            }
            agr.Close();
        }

        void equipo_eventoEliminar(UCEquipoComputo equipo)
        {
            Dialogo dia = new Dialogo("¿Desea eliminar el equipo '" + equipo.Equipo.St_NombreEquipoDescripcion + "' con dirección '" + equipo.Equipo.St_IPONombreEquipo + "'?", "Eliminar grupo");
            dia.ShowDialog();
            if (dia.Respuesta)
            {
                try
                {
                    String query = "delete from _Equipo where id = " + equipo.Equipo.Id;
                    String queryRel = "delete from _Grupo_X__Equipo__ll_equiposEnGrupo where _contenido = " + equipo.Equipo.Id;

                    manejador.AbrirConexion();
                    manejador.IniciarTransaccion();

                    manejador.EjecutarConsulta(queryRel);
                    manejador.EjecutarConsulta(query);

                    manejador.TerminarTransaccion();

                    this.grupoSeleccionado.EliminarCache();
                    this.ucgrupoSeleccionado.ActualizarConteo();
                    CargarEquiposDeGrupoSeleccionado(this.grupoSeleccionado.Ll_equiposEnGrupo);
                    txt_busqueda.Text = "";
                }
                catch (Exception ex)
                {
                    Dialogo d = new Dialogo("Error: " + ex.Message, "Error al guardar");
                    d.ShowDialog();
                }
            }
            dia.Close();
        }

        void equipo_eventoEditar(UCEquipoComputo equipo)
        {
            AgregarEquipo agr = new AgregarEquipo();
            agr.Equipo = equipo.Equipo;
            agr.Text = "Modificar equipo";
            agr.ShowDialog();

            if (agr.GuardarCambios)
            {
                manejador.Guardar(equipo.Equipo);
                this.grupoSeleccionado.EliminarCache();
                CargarEquiposDeGrupoSeleccionado(this.grupoSeleccionado.Ll_equiposEnGrupo);
                txt_busqueda.Text = "";
            }
            agr.Close();
        }

        private void VNC(_Equipo equipo, String vnc)
        {
            try
            {
                ProcessStartInfo info = new ProcessStartInfo();
                info.UseShellExecute = true;

                if (vnc.Equals("ultravnc"))
                {
                    info.FileName = "ultravnc.exe";
                    info.Arguments = "-server " + equipo.St_IPONombreEquipo + " -autoscaling -shared -normalcursor -quality 9 -password " + equipo.St_contraVNC;
                }
                else if (vnc.Equals("realvnc"))
                {
                    info.FileName = "realvnc.exe";
                    info.Arguments = equipo.St_IPONombreEquipo;
                }

                Process.Start(info);
                //EmailFormatos.EnviarMailInformacion("Se está intentando una conexión del equipo '" + Environment.MachineName + "' con el Usuario '"+ Environment.UserName+"' hacia el equipo '" + equiposConNombre[ip] + "' mediante VNC.", "VNC Viewer Launcher",var2.ObtenerValorVariable<String>("EMAILS"),null);
            }
            catch
            {
                //Mensajes.Error("No se encontró el ejecutable de RealVNC portable. No se encuentra el archivo 'realvnc.exe'");
            }
        }


        private void CambiarColorSeleccionado(UCGrupo grupo)
        {
            foreach (Control ctrl in pnl_grupos.Controls)
            {
                if (ctrl.GetType() == typeof(UCGrupo))
                {
                    UCGrupo grp = (UCGrupo)ctrl;
                    if (grp != grupo)
                    {
                        grp.Seleccionado = false;
                    }
                }
            }
        }
        void grupo_SeSelecciono(UCGrupo grupo)
        {
            this.ucgrupoSeleccionado = grupo;
            this.grupoSeleccionado = grupo.Grupo;
            txt_busqueda.Text = "";
            CambiarColorSeleccionado(grupo);
            CargarEquiposDeGrupoSeleccionado(grupo.Grupo.Ll_equiposEnGrupo);
        }

        private void Principal_Resize(object sender, EventArgs e)
        {
            CambiarWidthGrupos();
        }

        private void CambiarWidthGrupos()
        {
            foreach (Control ctrl in pnl_grupos.Controls)
            {
                ctrl.Width = pnl_grupos.Width - 30;
            }
        }

        private void txt_busqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Buscar();
            }
        }

        private void Buscar()
        {
            if (grupoSeleccionado == null)
                return;
            String palabraBusqueda = txt_busqueda.Text;
            String query = @"select e.* from _Grupo_X__Equipo__ll_equiposEnGrupo rel inner join _Equipo e
                                on rel._contenido = e.id
                                where rel._contenedor = " + grupoSeleccionado.Id + " and (e._st_Descripcion like '%" + palabraBusqueda + "%' or e._st_NombreEquipoDescripcion like '%" + palabraBusqueda + "%' or e._st_IPONombreEquipo like '%" + palabraBusqueda + "%')";

            List<_Equipo> equipos = manejador.CargarLista<_Equipo>(query);

            CargarEquiposDeGrupoSeleccionado(equipos);

        }

        private void pb_eliminar_MouseClick(object sender, MouseEventArgs e)
        {
            Buscar();
        }

        private void pb_realvnc_Click(object sender, EventArgs e)
        {
            try
            {
                String ruta = cmb_conexiones.SelectedItem.ToString();

                String vnc = "realvnc";
                ProcessStartInfo info = new ProcessStartInfo();
                info.UseShellExecute = true;

                if (vnc.Equals("ultravnc"))
                {
                    info.FileName = "ultravnc.exe";
                    info.Arguments = "-server " + ruta + " -autoscaling -shared -normalcursor -quality 9";
                }
                else if (vnc.Equals("realvnc"))
                {
                    info.FileName = "realvnc.exe";
                    info.Arguments = ruta;
                }

                Process.Start(info);
            }
            catch
            {
            }
        }

        private void pb_ultravnc_Click(object sender, EventArgs e)
        {
            try
            {
                String ruta = cmb_conexiones.SelectedItem.ToString();

                String vnc = "ultravnc";
                ProcessStartInfo info = new ProcessStartInfo();
                info.UseShellExecute = true;

                if (vnc.Equals("ultravnc"))
                {
                    info.FileName = "ultravnc.exe";
                    info.Arguments = "-server " + ruta + " -autoscaling -autoreconnect -shared -normalcursor -quality 9";
                }
                else if (vnc.Equals("realvnc"))
                {
                    info.FileName = "realvnc.exe";
                    info.Arguments = ruta;
                }

                Process.Start(info);
            }
            catch
            {

            }
        }

        private void dgv_soporte_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                cmb_conexiones.Items.Clear();

                cmb_conexiones.Items.Add(dgv_soporte.Rows[e.RowIndex].Cells[1].Value.ToString());
                cmb_conexiones.Items.Add(dgv_soporte.Rows[e.RowIndex].Cells[2].Value.ToString());
                lbl_seleccionado.Text = dgv_soporte.Rows[e.RowIndex].Cells[0].Value.ToString() + " | "+dgv_soporte.Rows[e.RowIndex].Cells[5].Value.ToString();

            }
        }

        private void btn_guardarSolucion_Click(object sender, EventArgs e)
        {
            if (lbl_seleccionado.Text.Trim().Equals(""))
            {
                Herramientas.Forms.Mensajes.Exclamacion("Seleccione un equipo antes de guardar");
                return;
            }
            if (txt_solucion.Text.Trim().Equals(""))
            {
                Herramientas.Forms.Mensajes.Exclamacion("Para referencias futuras por favor proporcione una solución.");
                return;
            }
            try
            {
                String query = "update _SolicitudSoporte set _ResultadoDeSoporte = @_ResultadoDeSoporte, _Atendido = @_Atendido, _AtendidoPor = @_AtendidoPor where id = @id";

                List<object> valores = new List<object>();
                valores.Add(txt_solucion.Text.Trim());
                valores.Add(true);
                valores.Add(Environment.UserName);
                valores.Add(lbl_seleccionado.Text.Split('|')[0].Trim());

                manejador.EjecutarConsulta(query, valores);
                Herramientas.Forms.Mensajes.Informacion("Guardado con éxito.");
                txt_solucion.Text = "";
                lbl_seleccionado.Text = "";
                pictureBox1_Click(null, null);
                

            }
            catch (Exception ex)
            {
                Herramientas.Forms.Mensajes.Error(ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            cmb_conexiones.Items.Clear();
            DataTable solicitudes = manejador.EjecutarConsulta("select id as [ID], _NombreEquipo as [Nombre equipo], _ip as [IP], _ComentarioInicial as [Descripción del error], _HoraSolicitud [Hora solicitud], _UsuarioWindows as [Usuario Windows] from _SolicitudSoporte where _Atendido = 'False'");
            dgv_soporte.DataSource = solicitudes;
            dgv_soporte.Refresh();
        }

        private void dgv_equiposConectados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                String id = dgv_equiposConectados.Rows[e.RowIndex].Cells[0].Value.ToString().ToString();
                VerEquipo ve = new VerEquipo(id, dgv_equiposConectados.Rows[e.RowIndex].Cells[1].Value.ToString().ToString());
                ve.FormClosed += ve_FormClosed;
                ve.Show();
            }
        }

        void ve_FormClosed(object sender, FormClosedEventArgs e)
        {
            ActualizarEquiposConectados(manejador);
        }

        private void pb_actualizarConectados_Click(object sender, EventArgs e)
        {
            ActualizarEquiposConectados(manejador);
        }

        private void btn_notificacion_Click(object sender, EventArgs e)
        {
            if (txt_mensaje.Text.Equals(""))
            {
                Herramientas.Forms.Mensajes.Exclamacion("Escribe un mensaje primero.");
                return;
            }
            EnviarMensaje("T:" + txt_mensaje.Text);
            txt_mensaje.Text = "";
        }

        private void btn_mensaje_Click(object sender, EventArgs e)
        {
            if (txt_mensaje.Text.Equals(""))
            {
                Herramientas.Forms.Mensajes.Exclamacion("Escribe un mensaje primero.");
                return;
            }
            EnviarMensaje("V:" + txt_mensaje.Text);
            txt_mensaje.Text = "";
        }
        private void EnviarMensaje(String mensaje)
        {
            manejador.EjecutarConsulta("update _EquipoEstatus set _tempmensaje = '" + mensaje + "' where DATEDIFF(ss, dtFechaModificacion, GETDATE()) < 15 ");
        }

        private void pb_BuscarConFiltroEquiposConectados_Click(object sender, EventArgs e)
        {
            ActualizarEquiposConectados(manejador);
        }

        private void txt_filtroEquiposConectados_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ActualizarEquiposConectados(manejador);
            }
        }
        

    }
}
