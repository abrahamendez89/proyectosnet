//------------------------------------------------------------------
// <copyright company="Microsoft">
//     Copyright (c) Microsoft.  All rights reserved.
// </copyright>
//------------------------------------------------------------------
namespace ReportesTest
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">True si los recursos administrados se deben eliminar; en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por Windows Form Designer

        /// <summary>
        /// Se requiere el método para la compatibilidad con Designer: no modifique
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.wholesum_bdDataSet = new ReportesTest.wholesum_bdDataSet();
            this._ps_EspacioFisicoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._ps_EspacioFisicoTableAdapter = new ReportesTest.wholesum_bdDataSetTableAdapters._ps_EspacioFisicoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.wholesum_bdDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._ps_EspacioFisicoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this._ps_EspacioFisicoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ReportesTest.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(682, 386);
            this.reportViewer1.TabIndex = 0;
            // 
            // wholesum_bdDataSet
            // 
            this.wholesum_bdDataSet.DataSetName = "wholesum_bdDataSet";
            this.wholesum_bdDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // _ps_EspacioFisicoBindingSource
            // 
            this._ps_EspacioFisicoBindingSource.DataMember = "_ps_EspacioFisico";
            this._ps_EspacioFisicoBindingSource.DataSource = this.wholesum_bdDataSet;
            // 
            // _ps_EspacioFisicoTableAdapter
            // 
            this._ps_EspacioFisicoTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 386);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.wholesum_bdDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._ps_EspacioFisicoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource _ps_EspacioFisicoBindingSource;
        private wholesum_bdDataSet wholesum_bdDataSet;
        private wholesum_bdDataSetTableAdapters._ps_EspacioFisicoTableAdapter _ps_EspacioFisicoTableAdapter;
    }
}

