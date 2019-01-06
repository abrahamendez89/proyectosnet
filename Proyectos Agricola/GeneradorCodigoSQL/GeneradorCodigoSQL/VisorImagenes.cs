using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GeneradorCodigoSQL
{
    public partial class VisorImagenes : Form
    {
        Bitmap imagen;
        public VisorImagenes(Bitmap imagen)
        {
            InitializeComponent();
            pb_imagen.Image = imagen;
            this.imagen = imagen;
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sfd.Title = "Guardar como";
            sfd.Filter = "Imagen PNG (*.png)|*.png";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                String ruta = sfd.FileName;
                imagen.Save(ruta);
            }
        }
    }
}
