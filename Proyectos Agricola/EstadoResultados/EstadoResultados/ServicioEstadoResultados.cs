using Herramientas.Archivos;
using Herramientas.Mail;
using Herramientas.SQL;
using Herramientas.WPF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace EstadoResultados
{
    public partial class ServicioEstadoResultados : Form
    {
        Boolean estaEjecutandose;
        Thread ejecutaProceso;
        EjecutarServicioEstadoResultados ej;
        public ServicioEstadoResultados()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += ServicioEstadoResultados_FormClosing;
            
        }
        private void AgregarMensaje(String mensaje)
        {
            lb_logActividades.Items.Add(DateTime.Now.ToString("yyyyMMdd-HH:mm:ss")+": "+mensaje);
            lb_logActividades.SelectedIndex = lb_logActividades.Items.Count - 1;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (!estaEjecutandose)
            {
                estaEjecutandose = true;
                ej = new EjecutarServicioEstadoResultados();
                ej.mostrarEstatus += ej_mostrarEstatus;
                ej.mostrarMensaje += ej_mostrarMensaje;
                ej.mostrarPorcentaje += ej_mostrarPorcentaje;
                ej.terminoProceso += ej_terminoProceso;
                ejecutaProceso = new Thread(ej.IniciarProceso);
                ejecutaProceso.Start();
                btn_ejecutarManual.Text = "Detener proceso";
            }
            else
            {
                if ((Mensajes.PreguntaAdvertenciaSIoNO("¿Esta seguro que desea cerrar la aplicación?\nSe detendrá el proceso de monitoreo y puede que no se actualice el cubo de estado de resultados.")))
                {
                    TerminarHilos();
                    pb_progreso.Value = 0;
                    lb_logActividades.Items.Clear();
                    txt_estatus.Text = "En espera";
                    estaEjecutandose = false;
                    cerrar = true;
                    btn_ejecutarManual.Text = "Ejecutar proceso";
                }
            }
        }

        void ej_terminoProceso()
        {
            ej = null;
            Mensajes.Informacion("Termino el proceso");
        }

        void ej_mostrarPorcentaje(double porcentaje)
        {
            pb_progreso.Value = (int)porcentaje;
        }

        void ej_mostrarMensaje(string mensaje)
        {
            lb_logActividades.Items.Add(mensaje);
        }

        void ej_mostrarEstatus(string estatus)
        {
            txt_estatus.Text = estatus;
        }
        Boolean cerrar;
        private void ServicioEstadoResultados_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (estaEjecutandose)
            {
                    Mensajes.Exclamacion("No es posible cerrar el formulario debido a que se está ejecutando el proceso.");
                e.Cancel = true;
                return;
            }
        }
        public void TerminarHilos()
        {
            try
            {
                if (ejecutaProceso != null && ejecutaProceso.ThreadState != ThreadState.Stopped) ejecutaProceso.Abort();
            }
            catch { }
        }
        

    }
}
