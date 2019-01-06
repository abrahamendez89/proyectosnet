using Herramientas.Forms;
using Herramientas.WPF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace VNCViewerLauncher
{
    public partial class AgregarEquipoAntes : Form
    {
        public String NombreEquipo { get; set; }
        public String IPEquipo { get; set; }
        public Dictionary<String,String> Equipos { get; set; }
        public AgregarEquipoAntes()
        {
            InitializeComponent();
            this.VisibleChanged += AgregarEquipo_VisibleChanged;
        }

        void AgregarEquipo_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                if (NombreEquipo != null && IPEquipo != null)
                {
                    txt_IP.Text = IPEquipo;
                    txt_nombreEquipo.Text = NombreEquipo;
                }
            }
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            if (txt_nombreEquipo.Text.Trim().Equals(""))
            {
                Mensajes.Exclamacion("Debe asignar un nombre de equipo.");
                return;
            }
            if (txt_IP.Text.Trim().Equals(""))
            {
                Mensajes.Exclamacion("Debe asignar una ip de equipo.");
                return;
            }
            //if (!IsValidIp(txt_IP.Text.Trim()))
            //{
            //    Mensajes.Exclamacion("La IP asignada no cumple con el formato correcto.");
            //    return;
            //}
            if (Equipos != null && Equipos.ContainsKey(txt_IP.Text.Trim()))
            {
                Mensajes.Exclamacion("La IP asignada ya fue registrada anteriormente.");
                return;
            }
            NombreEquipo = txt_nombreEquipo.Text.Trim();
            IPEquipo = txt_IP.Text.Trim();
            Hide();
        }
        public bool IsValidIp(string addr)
        {
            IPAddress ip;
            bool valid = !string.IsNullOrEmpty(addr) && IPAddress.TryParse(addr, out ip);
            return valid;
        }
    }
}
