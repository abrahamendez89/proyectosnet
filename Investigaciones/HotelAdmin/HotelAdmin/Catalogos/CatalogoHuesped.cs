using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dominio;

namespace HotelAdmin.Catalogos
{
    public partial class CatalogoHuesped : Form
    {
        public CatalogoHuesped()
        {
            InitializeComponent();
            txt_buscadorHuesped.Tipo = typeof(_HuespedCliente);
            txt_buscadorHuesped.resultadosBusqueda += txt_buscadorHuesped_resultadosBusqueda;
        }

        void txt_buscadorHuesped_resultadosBusqueda(List<Herramientas.ORM.ObjetoBase> resultados)
        {
            
        }

    }
}
