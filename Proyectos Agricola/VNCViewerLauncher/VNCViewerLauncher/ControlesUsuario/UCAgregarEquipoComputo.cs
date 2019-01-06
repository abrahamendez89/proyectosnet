using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VNCViewerLauncher.ControlesUsuario
{
    public partial class UCAgregarEquipoComputo : UserControl
    {

        public delegate void Click();
        public event Click click;

        public UCAgregarEquipoComputo()
        {
            InitializeComponent();

            lbl_equipo.MouseEnter += UCEquipoComputo_MouseEnter;
            pb_icono.MouseEnter += UCEquipoComputo_MouseEnter;


            lbl_equipo.MouseLeave += UCEquipoComputo_MouseLeave;
            pb_icono.MouseLeave += UCEquipoComputo_MouseLeave;

            pb_icono.MouseClick += UCAgregarEquipoComputo_MouseClick;
            lbl_equipo.MouseClick += UCAgregarEquipoComputo_MouseClick;
            
        }

        private void UCEquipoComputo_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.Orange;
        }

        private void UCEquipoComputo_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        private void UCAgregarEquipoComputo_MouseClick(object sender, MouseEventArgs e)
        {
            click();
        }

    }
}
