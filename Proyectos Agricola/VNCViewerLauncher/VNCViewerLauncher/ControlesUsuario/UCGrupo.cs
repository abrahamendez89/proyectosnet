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
    public partial class UCGrupo : UserControl
    {
        private _Grupo grupo;
        private Boolean seleccionado;
        public _Grupo Grupo { get { return grupo; } set { grupo = value; CargarGrupo(); } }
        public Boolean Seleccionado { get { return seleccionado; } set { seleccionado = value; CambiarColorSeleccionado(); } }

        public delegate void seSelecciono(UCGrupo grupo);
        public event seSelecciono SeSelecciono;

        public delegate void EventoEditar(UCGrupo grupo);
        public event EventoEditar eventoEditar;

        public delegate void EventoEliminar(UCGrupo grupo);
        public event EventoEliminar eventoEliminar;

        public UCGrupo(_Grupo grupo)
        {
            InitializeComponent();
            this.Grupo = grupo;
            pb_icono.MouseEnter += UCGrupo_MouseEnter;
            lbl_nombreGrupo.MouseEnter += UCGrupo_MouseEnter;
            lbl_detalles.MouseEnter += UCGrupo_MouseEnter;
            pb_editar.MouseEnter += UCGrupo_MouseEnter;
            pb_eliminar.MouseEnter += UCGrupo_MouseEnter;

            pb_icono.MouseLeave += UCGrupo_MouseLeave;
            lbl_nombreGrupo.MouseLeave += UCGrupo_MouseLeave;
            lbl_detalles.MouseLeave += UCGrupo_MouseLeave;
            pb_editar.MouseLeave += UCGrupo_MouseLeave;
            pb_eliminar.MouseLeave += UCGrupo_MouseLeave;

            pb_icono.MouseClick += UCGrupo_MouseClick;
            lbl_nombreGrupo.MouseClick += UCGrupo_MouseClick;
            lbl_detalles.MouseClick += UCGrupo_MouseClick;
        }

        private void CargarGrupo()
        {
            lbl_nombreGrupo.Text = this.Grupo.St_NombreGrupo;

            ActualizarConteo();

        }

        private void UCGrupo_MouseEnter(object sender, EventArgs e)
        {
            if (!Seleccionado)
                this.BackColor = Color.Yellow;
        }

        private void UCGrupo_MouseLeave(object sender, EventArgs e)
        {
            if (!Seleccionado)
                this.BackColor = Color.White;
        }

        private void CambiarColorSeleccionado()
        {
            if (seleccionado)
            {
                this.BackColor = Color.Orange;
            }
            else
            {
                this.BackColor = Color.White;
            }
            
        }

        public void ActualizarConteo()
        {
            int cantidad = 0;
            if (grupo.Ll_equiposEnGrupo != null)
                cantidad = grupo.Ll_equiposEnGrupo.Count;

            lbl_detalles.Text = cantidad + " equipos registrados.";
        }

        private void UCGrupo_MouseClick(object sender, MouseEventArgs e)
        {
            Seleccionado = true;
            CambiarColorSeleccionado();
            SeSelecciono(this);
        }

        private void pb_editar_Click(object sender, EventArgs e)
        {
            eventoEditar(this);
        }

        private void pb_eliminar_Click(object sender, EventArgs e)
        {
            eventoEliminar(this);
        }

    }
}
