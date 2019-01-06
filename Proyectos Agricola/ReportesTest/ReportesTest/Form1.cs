//------------------------------------------------------------------
// <copyright company="Microsoft">
//     Copyright (c) Microsoft.  All rights reserved.
// </copyright>
//------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReportesTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'wholesum_bdDataSet._ps_EspacioFisico' Puede moverla o quitarla según sea necesario.
            this._ps_EspacioFisicoTableAdapter.Fill(this.wholesum_bdDataSet._ps_EspacioFisico);
            this.reportViewer1.RefreshReport();
        }
    }
}