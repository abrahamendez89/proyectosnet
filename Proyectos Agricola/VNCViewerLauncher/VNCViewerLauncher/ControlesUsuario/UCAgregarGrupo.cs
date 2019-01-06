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
    public partial class UCAgregarGrupo : UserControl
    {

        public delegate void Click();
        public event Click click;

        public UCAgregarGrupo()
        {
            InitializeComponent();
            pb_icono.MouseEnter += UCGrupo_MouseEnter;
            lbl_nombreGrupo.MouseEnter += UCGrupo_MouseEnter;
            

            pb_icono.MouseLeave += UCGrupo_MouseLeave;
            lbl_nombreGrupo.MouseLeave += UCGrupo_MouseLeave;
           

            pb_icono.MouseClick += UCGrupo_MouseClick;
            lbl_nombreGrupo.MouseClick += UCGrupo_MouseClick;
           
        }

        private void UCGrupo_MouseEnter(object sender, EventArgs e)
        {
                this.BackColor = Color.Yellow;
        }

        private void UCGrupo_MouseLeave(object sender, EventArgs e)
        {
                this.BackColor = Color.White;
        }

        

        private void UCGrupo_MouseClick(object sender, MouseEventArgs e)
        {
            click();
        }

    }
}
