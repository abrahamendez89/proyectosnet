// Type: Sistema.FrmVisorDeListas
// Assembly: DataAccess, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C415D2F-B423-4DB8-8067-FB9CD8A174EC
// Assembly location: C:\Users\abrahamm\Documents\Visual Studio 2012\Projects2\Facturacion\Timbrado Nomina\TimbradoNomina\bin\Debug\DataAccess.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema
{
  public class FrmVisorDeListas : Form
  {
    public string eleccionDeUsuario = "*";
    public ListView miListView;
    private Label lblPagina;
    private Container components;

    public FrmVisorDeListas()
    {
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.miListView = new ListView();
      this.lblPagina = new Label();
      this.SuspendLayout();
      this.miListView.BackColor = Color.White;
      this.miListView.Dock = DockStyle.Top;
      this.miListView.Font = new Font("Trebuchet MS", 8f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.miListView.FullRowSelect = true;
      this.miListView.Location = new Point(0, 0);
      this.miListView.MultiSelect = false;
      this.miListView.Name = "miListView";
      this.miListView.Size = new Size(536, 312);
      this.miListView.TabIndex = 0;
      this.miListView.UseCompatibleStateImageBehavior = false;
      this.miListView.SelectedIndexChanged += new EventHandler(this.miListView_SelectedIndexChanged);
      this.miListView.DoubleClick += new EventHandler(this.miListView_DoubleClick);
      this.miListView.ColumnClick += new ColumnClickEventHandler(this.miListView_ColumnClick);
      this.lblPagina.Dock = DockStyle.Bottom;
      this.lblPagina.Font = new Font("Trebuchet MS", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblPagina.Location = new Point(0, 320);
      this.lblPagina.Name = "lblPagina";
      this.lblPagina.Size = new Size(536, 16);
      this.lblPagina.TabIndex = 0;
      this.lblPagina.TextAlign = ContentAlignment.MiddleCenter;
      this.lblPagina.DoubleClick += new EventHandler(this.lblPagina_DoubleClick);
      this.lblPagina.Click += new EventHandler(this.lblPagina_Click);
      this.AutoScaleBaseSize = new Size(5, 13);
      this.BackColor = Color.Lavender;
      this.ClientSize = new Size(536, 336);
      this.ControlBox = false;
      this.Controls.Add((Control) this.lblPagina);
      this.Controls.Add((Control) this.miListView);
      this.KeyPreview = true;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FrmVisorDeListas";
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.TopMost = true;
      this.Load += new EventHandler(this.FrmVisorDeListas_Load_1);
      this.KeyDown += new KeyEventHandler(this.FrmVisorDeListas_KeyDown);
      this.ResumeLayout(false);
    }

    private void FrmVisorDeListas_KeyDown(object Sender, KeyEventArgs kea)
    {
      switch (kea.KeyCode)
      {
        case Keys.Return:
          if (this.miListView.SelectedItems.Count > 0)
          {
            this.eleccionDeUsuario = this.miListView.SelectedItems[0].SubItems[this.miListView.SelectedItems[0].SubItems.Count - 1].Text;
            this.DialogResult = DialogResult.OK;
            break;
          }
          else
          {
            int num = (int) MessageBox.Show("Debe de Seleccionar Un Elemento de La Lista", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            break;
          }
        case Keys.Escape:
          this.DialogResult = DialogResult.Cancel;
          break;
      }
    }

    private void miListView_DoubleClick(object sender, EventArgs e)
    {
      this.eleccionDeUsuario = this.miListView.SelectedItems[0].SubItems[this.miListView.SelectedItems[0].SubItems.Count - 1].Text;
      this.DialogResult = DialogResult.OK;
    }

    private void FrmVisorDeListas_Load(object sender, EventArgs e)
    {
    }

    private void miListView_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void lblPagina_Click(object sender, EventArgs e)
    {
    }

    private void lblPagina_DoubleClick(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
    }

    private void FrmVisorDeListas_Load_1(object sender, EventArgs e)
    {
    }

    private void miListView_ColumnClick(object sender, ColumnClickEventArgs e)
    {
      this.miListView.ListViewItemSorter = (IComparer) new ListViewItemComparer(e.Column);
      this.miListView.Sort();
    }
  }
}
