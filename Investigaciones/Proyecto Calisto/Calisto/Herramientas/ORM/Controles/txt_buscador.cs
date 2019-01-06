using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Herramientas.ORM;

namespace Herramientas.ORM.Controles
{
    public partial class txt_buscador: UserControl
    {
        public Boolean PermiteMultipleSeleccion { get; set; }

        public delegate void ResultadosBusqueda(List<ObjetoBase> resultados);
        public event ResultadosBusqueda resultadosBusqueda;
        public txt_buscador()
        {
            InitializeComponent();
            txt.KeyDown += txt_KeyDown;
        }
        public Type Tipo { get; set; }
        public void AgregarColumnaMostrar(String columnaAlias)
        {

        }
        void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                BuscadorCatalogo buscador = new BuscadorCatalogo(Tipo.GetType(), PermiteMultipleSeleccion);
                buscador.ShowDialog();
                if (resultadosBusqueda != null)
                {
                    resultadosBusqueda(buscador.ObtenerSeleccionados(Tipo.GetType()));
                }
                else
                {
                    Herramientas.Forms.Mensajes.Error("Por favor configure el evento resultadosBusqueda de este buscador.");
                }
            }
        }

    }
}
