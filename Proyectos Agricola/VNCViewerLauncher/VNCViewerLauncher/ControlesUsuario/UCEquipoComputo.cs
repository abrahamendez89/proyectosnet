using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dominio;

namespace VNCViewerLauncher.ControlesUsuario
{
    public partial class UCEquipoComputo : UserControl
    {
        private _Equipo equipo;
        public _Equipo Equipo { get { return equipo; } set { this.equipo = value; CargarEquipo(); } }

        public delegate void EventoRealVNC(UCEquipoComputo equipo);
        public event EventoRealVNC eventoRealVNC;

        public delegate void EventoUltraVNC(UCEquipoComputo equipo);
        public event EventoUltraVNC eventoUltraVNC;

        public delegate void EventoEditar(UCEquipoComputo equipo);
        public event EventoRealVNC eventoEditar;

        public delegate void EventoEliminar(UCEquipoComputo equipo);
        public event EventoEliminar eventoEliminar;

        private void CargarEquipo()
        {
            lbl_equipo.Text = equipo.St_NombreEquipoDescripcion;
            lbl_rutaEquipo.Text = equipo.St_IPONombreEquipo;
            txt_descripcion.Text = equipo.St_Descripcion;
        }
        public UCEquipoComputo(_Equipo equipo)
        {
            InitializeComponent();

            this.Equipo = equipo;

            lbl_equipo.MouseEnter += UCEquipoComputo_MouseEnter;
            lbl_rutaEquipo.MouseEnter += UCEquipoComputo_MouseEnter;
            pb_icono.MouseEnter += UCEquipoComputo_MouseEnter;
            pb_eliminar.MouseEnter += UCEquipoComputo_MouseEnter;
            pb_editar.MouseEnter += UCEquipoComputo_MouseEnter;
            pb_realvnc.MouseEnter += UCEquipoComputo_MouseEnter;
            pb_ultravnc.MouseEnter += UCEquipoComputo_MouseEnter;
            txt_descripcion.MouseEnter += UCEquipoComputo_MouseEnter;


            lbl_equipo.MouseLeave += UCEquipoComputo_MouseLeave;
            lbl_rutaEquipo.MouseLeave += UCEquipoComputo_MouseLeave;
            pb_icono.MouseLeave += UCEquipoComputo_MouseLeave;
            pb_eliminar.MouseLeave += UCEquipoComputo_MouseLeave;
            pb_editar.MouseLeave += UCEquipoComputo_MouseLeave;
            pb_realvnc.MouseLeave += UCEquipoComputo_MouseLeave;
            pb_ultravnc.MouseLeave += UCEquipoComputo_MouseLeave;
            txt_descripcion.MouseLeave += UCEquipoComputo_MouseLeave;
            
        }

        private void UCEquipoComputo_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.Orange;
            txt_descripcion.BackColor = this.BackColor;
        }

        private void UCEquipoComputo_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            txt_descripcion.BackColor = this.BackColor;
        }

        private void pb_editar_Click(object sender, EventArgs e)
        {
            eventoEditar(this);
        }

        private void pb_conectar_Click(object sender, EventArgs e)
        {
            eventoRealVNC(this);
        }

        private void pb_eliminar_Click(object sender, EventArgs e)
        {
            eventoEliminar(this);
        }

        private void pb_ultravnc_Click(object sender, EventArgs e)
        {
            eventoUltraVNC(this);
        }
    }
}
