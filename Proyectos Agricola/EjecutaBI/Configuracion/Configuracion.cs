using EjecutaBIConsola;
using Herramientas.Archivos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Configuracion
{
    public partial class Configuracion : Form
    {
        List<Proceso> Procesos = new List<Proceso>();
        Variable varProcesos;
        Variable varConexiones;
        String EMAILS = "";
        //SQLServer
        String SQLSERVER_BD = "";
        String SQLSERVER_Servidor = "";
        String SQLSERVER_Usuario = "";
        String SQLSERVER_Contra = "";
        //Firebird
        String FIREBIRD_RUTABD = "";
        String FIREBIRD_Servidor = "";
        String FIREBIRD_Usuario = "";
        String FIREBIRD_Contra = "";

        public Configuracion()
        {
            InitializeComponent();
            CargarVariables();
            CargarProcesosProgramados();
            MostrarProcesosGrid();
            LlenarCombosHora();
        }
        private void LlenarCombosHora()
        {
            cmb_Hora.Items.Clear();
            cmb_minuto.Items.Clear();

            for (int i = 0; i < 24; i++)
                cmb_Hora.Items.Add(Herramientas.Conversiones.Formatos.IntANDigitos(i, 2));
            for (int i = 0; i < 60; i++)
                cmb_minuto.Items.Add(Herramientas.Conversiones.Formatos.IntANDigitos(i, 2));
        }
        private void CargarVariables()
        {
            varConexiones = new Variable("Conexiones.config");
            varProcesos = new Variable("Procesos.config");
            EMAILS = varConexiones.ObtenerValorVariable<String>("EMAILS");

            SQLSERVER_BD = varConexiones.ObtenerValorVariable<String>("SQLSERVER_BD");
            SQLSERVER_Servidor = varConexiones.ObtenerValorVariable<String>("SQLSERVER_Servidor");
            SQLSERVER_Usuario = varConexiones.ObtenerValorVariable<String>("SQLSERVER_Usuario");
            SQLSERVER_Contra = varConexiones.ObtenerValorVariable<String>("SQLSERVER_Contra");

            FIREBIRD_RUTABD = varConexiones.ObtenerValorVariable<String>("FIREBIRD_RUTABD");
            FIREBIRD_Servidor = varConexiones.ObtenerValorVariable<String>("FIREBIRD_Servidor");
            FIREBIRD_Usuario = varConexiones.ObtenerValorVariable<String>("FIREBIRD_Usuario");
            FIREBIRD_Contra = varConexiones.ObtenerValorVariable<String>("FIREBIRD_Contra");

        }
        private void MostrarProcesosGrid()
        {
            dgv_procesos.Rows.Clear();
            foreach (Proceso proceso in Procesos)
            {

                String tipo = "";
                if (proceso.TipoEjecucion == Proceso.Tipo.EsExcel)
                    tipo = "Excel";
                else if (proceso.TipoEjecucion == Proceso.Tipo.EsScript)
                    tipo = "Script";

                String sql = "";
                if (proceso.TipoServidor == Proceso.Servidor.Firebird)
                    sql = "Firebird";
                else if (proceso.TipoServidor == Proceso.Servidor.SQLServer)
                    sql = "SQL Server";

                dgv_procesos.Rows.Add(proceso.Nombre, Herramientas.Conversiones.Formatos.IntANDigitos(proceso.Hora, 2) + ":" + Herramientas.Conversiones.Formatos.IntANDigitos(proceso.Minuto, 2), proceso.Ruta, tipo, sql);
            }
        }
        private void CargarProcesosProgramados()
        {
            CargarVariables();

            Procesos.Clear();
            int numeroProcesos = varProcesos.ObtenerValorVariable<int>("PROCESOS_TOTAL");

            for (int i = 0; i < numeroProcesos; i++)
            {
                Proceso proceso = new Proceso();
                //cargando las variables del archivo
                String servidor = varProcesos.ObtenerValorVariable<String>("PROCESOS_" + i + "_SERVIDOR");
                int Hora = varProcesos.ObtenerValorVariable<int>("PROCESOS_" + i + "_HORA");
                int Minuto = varProcesos.ObtenerValorVariable<int>("PROCESOS_" + i + "_MINUTO");
                String Ruta = varProcesos.ObtenerValorVariable<String>("PROCESOS_" + i + "_RUTA");
                String Tipo = varProcesos.ObtenerValorVariable<String>("PROCESOS_" + i + "_TIPO");
                String nombre = varProcesos.ObtenerValorVariable<String>("PROCESOS_" + i + "_NOMBRE");
                Boolean esActivo = varProcesos.ObtenerValorVariable<Boolean>("PROCESOS_" + i + "_ACTIVO");
                //asignando los valores
                if (servidor.ToUpper().Equals("SQL SERVER"))
                {
                    proceso.TipoServidor = Proceso.Servidor.SQLServer;
                }
                if (servidor.ToUpper().Equals("FIREBIRD"))
                {
                    proceso.TipoServidor = Proceso.Servidor.Firebird;
                }
                if (Tipo.ToUpper().Equals("EXCEL"))
                {
                    proceso.TipoEjecucion = Proceso.Tipo.EsExcel;
                }
                if (Tipo.ToUpper().Equals("SCRIPT"))
                {
                    proceso.TipoEjecucion = Proceso.Tipo.EsScript;
                }
                proceso.Nombre = nombre;
                proceso.Hora = Hora;
                proceso.Minuto = Minuto;
                proceso.Ruta = Ruta;
                proceso.EstaActivo = esActivo;
                //agregando el proceso al listado
                Procesos.Add(proceso);

            }

        }

        private void cmb_tipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_tipo.SelectedIndex == 0)
            {
                lbl_servidor.Visible = true;
                cmb_Servidor.Visible = true;
            }
            else
            {
                lbl_servidor.Visible = false;
                cmb_Servidor.Visible = false;
            }
        }
        Proceso procesoActual;
        private void GuardarProcesos()
        {
            varProcesos.GuardarValorVariable("PROCESOS_TOTAL", Procesos.Count);
            for (int i = 0; i < Procesos.Count; i++)
            {
                Proceso proceso = Procesos[i];


                String servidor = "";
                if (proceso.TipoServidor == Proceso.Servidor.Firebird)
                    servidor = "firebird";
                else if (proceso.TipoServidor == Proceso.Servidor.SQLServer)
                    servidor = "sql server";
                String tipo = "";
                if (proceso.TipoEjecucion == Proceso.Tipo.EsExcel)
                    tipo = "excel";
                else if (proceso.TipoEjecucion == Proceso.Tipo.EsScript)
                    tipo = "script";

                if (proceso.TipoEjecucion == Proceso.Tipo.EsExcel)
                    servidor = "";


                varProcesos.GuardarValorVariable("PROCESOS_" + i + "_NOMBRE", proceso.Nombre);
                varProcesos.GuardarValorVariable("PROCESOS_" + i + "_RUTA", proceso.Ruta);
                varProcesos.GuardarValorVariable("PROCESOS_" + i + "_HORA", proceso.Hora);
                varProcesos.GuardarValorVariable("PROCESOS_" + i + "_MINUTO", proceso.Minuto);
                varProcesos.GuardarValorVariable("PROCESOS_" + i + "_TIPO", tipo);
                varProcesos.GuardarValorVariable("PROCESOS_" + i + "_SERVIDOR", servidor);
                varProcesos.GuardarValorVariable("PROCESOS_" + i + "_ACTIVO", proceso.EstaActivo);
            }
            varProcesos.ActualizarArchivo();
        }

        private void dgv_procesos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                procesoActual = Procesos[e.RowIndex];
                txt_nombreProceso.Text = procesoActual.Nombre;
                txt_ruta.Text = procesoActual.Ruta;
                cmb_Hora.SelectedItem = Herramientas.Conversiones.Formatos.IntANDigitos(procesoActual.Hora, 2);
                cmb_minuto.SelectedItem = Herramientas.Conversiones.Formatos.IntANDigitos(procesoActual.Minuto, 2);
                if (procesoActual.TipoEjecucion == Proceso.Tipo.EsExcel)
                {
                    cmb_tipo.SelectedItem = "Excel";
                    cmb_Servidor.SelectedIndex = -1;
                }
                else if (procesoActual.TipoEjecucion == Proceso.Tipo.EsScript)
                {
                    cmb_tipo.SelectedItem = "Script";
                    if (procesoActual.TipoServidor == Proceso.Servidor.Firebird)
                    {
                        cmb_Servidor.SelectedItem = "Firebird";
                    }
                    else if (procesoActual.TipoServidor == Proceso.Servidor.SQLServer)
                    {
                        cmb_Servidor.SelectedItem = "SQL Server";
                    }
                }
                chb_estaActivo.Checked = procesoActual.EstaActivo;
            }
        }
        private Boolean Validar()
        {

            

            if (txt_nombreProceso.Text.Trim().Equals(""))
            {
                Herramientas.Forms.Mensajes.Exclamacion("Es necesario asignar el nombre.");
                return false;
            }
            if (txt_ruta.Text.Trim().Equals(""))
            {
                Herramientas.Forms.Mensajes.Exclamacion("Es necesario asignar la ruta.");
                return false;
            }
            if (cmb_Hora.SelectedIndex < 0 || cmb_minuto.SelectedIndex < 0)
            {
                Herramientas.Forms.Mensajes.Exclamacion("Es necesario configurar la hora de ejecución.");
                return false;
            }
            if (cmb_tipo.SelectedIndex < 0)
            {
                Herramientas.Forms.Mensajes.Exclamacion("Es necesario configurar el tipo de configuración.");
                return false;
            }
            if (cmb_tipo.SelectedItem.Equals("Script") && cmb_Servidor.SelectedIndex < 0)
            {
                Herramientas.Forms.Mensajes.Exclamacion("Es necesario configurar el tipo de servidor.");
                return false;
            }
            return true;
        }
        private void btn_Guardar_Click(object sender, EventArgs e)
        {

            if (Validar())
            {
                if (procesoActual == null)
                {
                    foreach (Proceso proceso in Procesos)
                    {
                        if (proceso.Nombre.ToLower().Trim().Equals(txt_nombreProceso.Text.Trim().ToLower()))
                        {
                            Herramientas.Forms.Mensajes.Exclamacion("El nombre ya fue asignado antes.");
                            return;
                        }
                    }
                    procesoActual = new Proceso();
                    Procesos.Add(procesoActual);
                }
                //asignando los valores
                procesoActual.Nombre = txt_nombreProceso.Text;
                procesoActual.Ruta = txt_ruta.Text;
                procesoActual.Hora = Convert.ToInt32(cmb_Hora.SelectedItem);
                procesoActual.Minuto = Convert.ToInt32(cmb_minuto.SelectedItem);
                if (cmb_tipo.SelectedItem.Equals("Excel"))
                {
                    procesoActual.TipoEjecucion = Proceso.Tipo.EsExcel;
                }
                else if (cmb_tipo.SelectedItem.Equals("Script"))
                {
                    procesoActual.TipoEjecucion = Proceso.Tipo.EsScript;
                }
                if (cmb_Servidor.SelectedItem.Equals("Firebird"))
                {
                    procesoActual.TipoServidor = Proceso.Servidor.Firebird;
                }
                else if (cmb_Servidor.SelectedItem.Equals("SQL Server"))
                {
                    procesoActual.TipoServidor = Proceso.Servidor.SQLServer;
                }
                procesoActual.EstaActivo = chb_estaActivo.Checked;

                GuardarProcesos();
                CargarProcesosProgramados();
                MostrarProcesosGrid();
                LimpiarControles();
            }
        }
        private void LimpiarControles()
        {
            txt_nombreProceso.Text = "";
            txt_ruta.Text = "";
            cmb_Hora.SelectedIndex = -1;
            cmb_minuto.SelectedIndex = -1;
            cmb_tipo.SelectedIndex = -1;
            cmb_Servidor.SelectedIndex = -1;
            chb_estaActivo.Checked = false;

            cmb_Servidor.Visible = false;
            lbl_servidor.Visible = false;
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            procesoActual = null;
            LimpiarControles();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (Herramientas.Forms.Mensajes.PreguntaAdvertenciaSIoNO("¿Está seguro de realizar la eliminación?"))
            {
                Procesos.Remove(procesoActual);
                GuardarProcesos();
                CargarProcesosProgramados();
                LimpiarControles();
                MostrarProcesosGrid();
            }
        }
    }
}
