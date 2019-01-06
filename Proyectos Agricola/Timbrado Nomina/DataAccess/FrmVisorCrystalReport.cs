// Type: Sistema.FrmVisorCrystalReport
// Assembly: DataAccess, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C415D2F-B423-4DB8-8067-FB9CD8A174EC
// Assembly location: C:\Users\abrahamm\Documents\Visual Studio 2012\Projects2\Facturacion\Timbrado Nomina\TimbradoNomina\bin\Debug\DataAccess.dll

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Sistema
{
  public class FrmVisorCrystalReport : Form
  {
    public ReportDocument reporteCrystal;
    public CrystalReportViewer crystalReportViewer1;
    private Container components;
    private Icon bitIcon;

    public FrmVisorCrystalReport()
    {
      this.InitializeComponent();
      if (!File.Exists("C:/Access/logo.ico"))
        return;
      this.bitIcon = new Icon("C:/Access/logo.ico");
      this.Icon = this.bitIcon;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FrmVisorCrystalReport));
      this.crystalReportViewer1 = new CrystalReportViewer();
      this.SuspendLayout();
      this.crystalReportViewer1.ActiveViewIndex = -1;
      this.crystalReportViewer1.BorderStyle = BorderStyle.FixedSingle;
      this.crystalReportViewer1.Dock = DockStyle.Fill;
      this.crystalReportViewer1.Location = new Point(0, 0);
      this.crystalReportViewer1.Name = "crystalReportViewer1";
      this.crystalReportViewer1.SelectionFormula = "";
      this.crystalReportViewer1.Size = new Size(736, 446);
      this.crystalReportViewer1.TabIndex = 0;
      this.crystalReportViewer1.ViewTimeSelectionFormula = "";
      this.crystalReportViewer1.Load += new EventHandler(this.crystalReportViewer1_Load);
      this.AutoScaleBaseSize = new Size(5, 13);
      this.ClientSize = new Size(736, 446);
      this.Controls.Add((Control) this.crystalReportViewer1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = "FrmVisorCrystalReport";
      this.ShowInTaskbar = false;
      this.WindowState = FormWindowState.Maximized;
      this.Load += new EventHandler(this.FrmVisorCrystalReport_Load);
      this.ResumeLayout(false);
    }

    private void FrmVisorCrystalReport_Load(object sender, EventArgs e)
    {
      this.crystalReportViewer1.DisplayGroupTree = false;
      this.crystalReportViewer1.ReportSource = (object) this.reporteCrystal;
      this.crystalReportViewer1.Visible = true;
    }

    private void crystalReportViewer1_Load(object sender, EventArgs e)
    {
    }
  }
}
