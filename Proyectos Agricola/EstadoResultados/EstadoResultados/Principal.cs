using Herramientas.Archivos;
using Herramientas.SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EstadoResultados
{
    public partial class Principal : Form
    {
        Variable var;
        DBAcceso dbAcceso;

        public static Boolean EstaEjecutandose;
        public static Boolean EsModoServidor;

        public Principal()
        {
            InitializeComponent();
            String rutaConf = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\EstadoResultados";
            var = new Variable(rutaConf);
            CheckForIllegalCrossThreadCalls = false;
            this.WindowState = FormWindowState.Maximized;
            notifyIcon.DoubleClick += notifyIcon_DoubleClick;
            EsModoServidor = AgendadoServicioEstadoResultados.ConvierteTextoABoolean(var.ObtenerValorVariable<String>("ModoServidor"));
        }
        private void CreaInstancia(Form form)
        {
            form.MdiParent = this;
            form.ShowIcon = false;
            if (form.WindowState != FormWindowState.Maximized)
                form.StartPosition = FormStartPosition.CenterScreen;
            else
                form.Size = new System.Drawing.Size(this.Size.Width-5, this.Size.Height-25);
            form.Show();
        }
        private void ligadoDeConceptosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreaInstancia(new CatálogoLigadoConceptos());
        }

        private void creaciónDeEstadoDeResultadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreaInstancia(new CatalogoEstadoResultados(true));
        }

        private void ejecutarConstrucciónDeFuentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            serv = new ServicioEstadoResultados();
            CreaInstancia(serv);
        }

        private void agendadoDeConstrucciónDeEstadoDeResultadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreaInstancia(new AgendadoServicioEstadoResultados());
        }

        private void emailsDeNotifiaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreaInstancia(new EmailsNotificacion());
        }

        private void catálogoBeneficiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreaInstancia(new CatalogoBeneficios());
        }
        ServicioEstadoResultados serv;
        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!EsModoServidor)
            {
                Application.Exit(); 
                return;
            }
            else
            {
                //es modo servidor y nadamas se minimiza
                e.Cancel = true;
                ShowInTaskbar = false;
                Visible = false;
                notifyIcon.Visible = true;
                notifyIcon.Text = "Estado de resultados";

                notifyIcon.BalloonTipText = "La aplicación sigue ejecutandose en segundo plano.";
                notifyIcon.BalloonTipTitle = "Estado de resultados";
                notifyIcon.ShowBalloonTip(500);
            }
        }
        void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            abrirProgramaToolStripMenuItem_Click_1(null, null);
        }

        private void abrirProgramaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Visible = true;
            ShowInTaskbar = true;
        }

        private void terminarEjecuciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (serv != null)
            {
                serv.TerminarHilos();
            }
            Application.Exit(); 
        }
    }
}
