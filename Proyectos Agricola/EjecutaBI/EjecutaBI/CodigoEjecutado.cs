using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EjecutaBI
{
    public partial class CodigoEjecutado : Form
    {
        public CodigoEjecutado(String codigo)
        {
            InitializeComponent();
            txt_codigo.Text = codigo;
        }
    }
}
