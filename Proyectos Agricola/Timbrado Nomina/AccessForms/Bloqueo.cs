// Type: Sistema.Bloqueo
// Assembly: AccessForms, Version=1.0.4545.30908, Culture=neutral, PublicKeyToken=null
// MVID: 5901ABF0-835C-413E-A9D3-42261792F241
// Assembly location: C:\Users\abrahamm\Documents\Visual Studio 2012\Projects2\Facturacion\Timbrado Nomina\TimbradoNomina\bin\Debug\AccessForms.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Sistema
{
  internal class Bloqueo : AccessForm
  {
    private IContainer components;
    private Label label1;
    private PictureBox pictureBox1;
    private GroupBox grpElementos;
    private bool estoyCerrando;
    private Bitmap bitImagen;

    public Bloqueo()
    {
      this.InitializeComponent();
      if (!File.Exists("C:/Adsum/logo.gif"))
        return;
      this.bitImagen = new Bitmap("C:/Adsum/logo.gif");
      this.pictureBox1.Image = (Image) this.bitImagen;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Bloqueo));
      this.label1 = new Label();
      this.pictureBox1 = new PictureBox();
      this.grpElementos = new GroupBox();
      this.grpElementos.SuspendLayout();
      this.SuspendLayout();
      this.label1.Font = new Font("Microsoft Sans Serif", 21.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.Location = new Point(157, 34);
      this.label1.Name = "label1";
      this.label1.Size = new Size(366, 151);
      this.label1.TabIndex = 2;
      this.label1.Text = "La aplicación ha sido bloqueada por inactividad";
      this.label1.TextAlign = ContentAlignment.MiddleCenter;
      this.pictureBox1.Image = (Image) componentResourceManager.GetObject("pictureBox1.Image");
      this.pictureBox1.Location = new Point(15, 34);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(136, 104);
      this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 13;
      this.pictureBox1.TabStop = false;
      this.grpElementos.BackgroundImageLayout = ImageLayout.None;
      this.grpElementos.Controls.Add((Control) this.pictureBox1);
      this.grpElementos.Controls.Add((Control) this.label1);
      this.grpElementos.Location = new Point(27, 63);
      this.grpElementos.Name = "grpElementos";
      this.grpElementos.Size = new Size(534, 194);
      this.grpElementos.TabIndex = 14;
      this.grpElementos.TabStop = false;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(573, 325);
      this.Controls.Add((Control) this.grpElementos);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = "Bloqueo";
      this.ReferenciaRapidaVisible = true;
      this.ShowInTaskbar = false;
      this.Text = "Bloqueo";
      this.WindowState = FormWindowState.Maximized;
      this.Controls.SetChildIndex((Control) this.lblToolTip, 0);
      this.Controls.SetChildIndex((Control) this.grpElementos, 0);
      this.grpElementos.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    protected override void OnLoad(EventArgs e)
    {
      if (File.Exists("C:/Adsum/logo.gif"))
      {
        this.bitImagen = new Bitmap("C:/Adsum/logo.gif");
        this.pictureBox1.Image = (Image) this.bitImagen;
      }
      this.ReferenciaRapida = "<F10>Desbloquear";
      this.WindowState = FormWindowState.Maximized;
      base.OnLoad(e);
    }

    protected override void OnSizeChanged(EventArgs e)
    {
      this.MinimumSize = new Size(this.Size.Width, this.Size.Height);
      base.OnSizeChanged(e);
    }

    protected override void OnResize(EventArgs e)
    {
      base.OnResize(e);
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
      if (e.KeyCode == Keys.F10)
        this.DoLogin();
      base.OnKeyDown(e);
    }

    protected override void OnClosing(CancelEventArgs e)
    {
      if (!this.estoyCerrando)
        e.Cancel = true;
      base.OnClosing(e);
    }

    private void DoLogin()
    {
      if (!DataAccessCls.DevuelveInstancia().AccesoDeUsuarioActual())
        return;
      this.estoyCerrando = true;
      this.Close();
    }
  }
}
