// Type: Sistema.FrmAccesoDeUsuario
// Assembly: DataAccess, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C415D2F-B423-4DB8-8067-FB9CD8A174EC
// Assembly location: C:\Users\abrahamm\Documents\Visual Studio 2012\Projects2\Facturacion\Timbrado Nomina\TimbradoNomina\bin\Debug\DataAccess.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Sistema
{
  public class FrmAccesoDeUsuario : Form
  {
    internal const byte VK_CAPITAL = (byte) 20;
    public DataAccessCls miAsistenteDeDatos;
    public string miNombreServidor;
    public string miNombreBaseDeDatos;
    public string miUsuarioLogin;
    public string miPassWord;
    public string miRutaArchivoIni;
    public bool miFuncionalidadTouchScreenActivada;
    public bool miSevidorAlternoActivado;
    public bool miMostrarUsuarioEncriptado;
    public bool miMostrarUltimoUsuario;
    public bool mostrarSoloUsuarioProporcionado;
    public TextBox TxtUsuario;
    private Label label2;
    public TextBox TxtPassWord;
    private Label label1;
    private Button BtnCancelar;
    private Button BtnAceptar;
    private Bitmap bitImagen;
    private PictureBox pictureBox1;
    private ToolTip toolTip1;
    private IContainer components;

    public FrmAccesoDeUsuario()
    {
      this.InitializeComponent();
      if (!File.Exists("C:/Access/logo.gif"))
        return;
      this.bitImagen = new Bitmap("C:/Access/logo.gif");
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
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FrmAccesoDeUsuario));
      this.TxtUsuario = new TextBox();
      this.label2 = new Label();
      this.TxtPassWord = new TextBox();
      this.label1 = new Label();
      this.BtnCancelar = new Button();
      this.BtnAceptar = new Button();
      this.pictureBox1 = new PictureBox();
      this.toolTip1 = new ToolTip(this.components);
      this.SuspendLayout();
      this.TxtUsuario.Font = new Font("Trebuchet MS", 13f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.TxtUsuario.Location = new Point(191, 24);
      this.TxtUsuario.Name = "TxtUsuario";
      this.TxtUsuario.Size = new Size(135, 28);
      this.TxtUsuario.TabIndex = 5;
      this.TxtUsuario.DoubleClick += new EventHandler(this.TxtUsuario_DoubleClick);
      this.TxtUsuario.TextChanged += new EventHandler(this.TxtUsuario_TextChanged);
      this.TxtUsuario.Click += new EventHandler(this.TxtUsuario_Click);
      this.label2.Font = new Font("Nyala", 13f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.Location = new Point(116, 80);
      this.label2.Name = "label2";
      this.label2.Size = new Size(102, 23);
      this.label2.TabIndex = 9;
      this.label2.Text = "Password:";
      this.TxtPassWord.Font = new Font("Trebuchet MS", 13f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.TxtPassWord.Location = new Point(191, 72);
      this.TxtPassWord.Name = "TxtPassWord";
      this.TxtPassWord.PasswordChar = '*';
      this.TxtPassWord.Size = new Size(135, 28);
      this.TxtPassWord.TabIndex = 7;
      this.TxtPassWord.DoubleClick += new EventHandler(this.TxtPassWord_DoubleClick);
      this.TxtPassWord.TextChanged += new EventHandler(this.TxtPassWord_TextChanged);
      this.TxtPassWord.Click += new EventHandler(this.TxtPassWord_Click);
      this.label1.Font = new Font("Nyala", 13f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.Location = new Point(116, 24);
      this.label1.Name = "label1";
      this.label1.Size = new Size(103, 23);
      this.label1.TabIndex = 8;
      this.label1.Text = "Usuario:";
      //this.BtnCancelar.DialogResult = DialogResult.Cancel;
      this.BtnCancelar.Font = new Font("Trebuchet MS", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.BtnCancelar.Location = new Point(213, 123);
      this.BtnCancelar.Name = "BtnCancelar";
      this.BtnCancelar.Size = new Size(113, 24);
      this.BtnCancelar.TabIndex = 24;
      this.BtnCancelar.Text = "&Cancelar";
      this.BtnCancelar.Click += new EventHandler(this.BtnCancelar_Click);
      this.BtnAceptar.Font = new Font("Trebuchet MS", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.BtnAceptar.Location = new Point(93, 123);
      this.BtnAceptar.Name = "BtnAceptar";
      this.BtnAceptar.Size = new Size(113, 24);
      this.BtnAceptar.TabIndex = 23;
      this.BtnAceptar.Text = "&Aceptar";
      this.BtnAceptar.Click += new EventHandler(this.BtnAceptar_Click);
      //this.pictureBox1.Image = (Image) componentResourceManager.GetObject("pictureBox1.Image");
      this.pictureBox1.Location = new Point(12, 24);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(93, 85);
      this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 37;
      this.pictureBox1.TabStop = false;
      this.AutoScaleBaseSize = new Size(5, 13);
      this.BackColor = Color.Gainsboro;
      this.ClientSize = new Size(338, 170);
      this.ControlBox = false;
      this.Controls.Add((Control) this.pictureBox1);
      this.Controls.Add((Control) this.BtnCancelar);
      this.Controls.Add((Control) this.BtnAceptar);
      this.Controls.Add((Control) this.TxtPassWord);
      this.Controls.Add((Control) this.TxtUsuario);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.label2);
      this.Font = new Font("Trebuchet MS", 7.8f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      //this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.KeyPreview = true;
      this.Name = "FrmAccesoDeUsuario";
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.TopMost = true;
      this.Load += new EventHandler(this.FrmAccesoDeUsuario_Load);
      this.KeyDown += new KeyEventHandler(this.FrmAccesoDeUsuario_KeyDown);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private void FrmAccesoDeUsuario_Load(object sender, EventArgs e)
    {
      this.miAsistenteDeDatos = new DataAccessCls();
      if (this.miMostrarUsuarioEncriptado)
        this.TxtUsuario.PasswordChar = "*".ToCharArray()[0];
      if (this.miMostrarUltimoUsuario)
        this.TxtUsuario.Text = this.miUsuarioLogin;
      else
        this.TxtUsuario.Text = "";
      if (this.mostrarSoloUsuarioProporcionado)
      {
        this.TxtUsuario.Text = this.miUsuarioLogin;
        this.TxtUsuario.Enabled = false;
        this.TxtPassWord.Focus();
      }
      this.TxtPassWord.Text = "";
      if (!this.miSevidorAlternoActivado)
        return;
      this.miAsistenteDeDatos.ServidorAlterno_Activar();
    }

    private void FrmAccesoDeUsuario_KeyDown(object sender, KeyEventArgs e)
    {
      switch (e.KeyCode)
      {
        case Keys.Return:
          SendKeys.Send("{tab}");
          break;
        case Keys.Capital:
          if (Control.IsKeyLocked(Keys.CapsLock))
              break;
          this.toolTip1.Show("Mayúsculas Activadas", (IWin32Window)this.TxtPassWord, 2000);
          break;
        case Keys.Escape:
          SendKeys.Send("+{tab}");
          break;
      }
    }

    private void BtnAceptar_Click(object sender, EventArgs e)
    {
      this.miUsuarioLogin = this.TxtUsuario.Text;
      this.miPassWord = this.TxtPassWord.Text;
      if (!this.miAsistenteDeDatos.AccesoDeUsuario(this.miNombreServidor, this.miNombreBaseDeDatos, this.miUsuarioLogin, this.miPassWord))
        return;
      this.miUsuarioLogin = this.TxtUsuario.Text;
      this.miPassWord = this.TxtPassWord.Text;
      this.miSevidorAlternoActivado = this.miAsistenteDeDatos.ServidoAlternoActivado;
      this.DialogResult = DialogResult.OK;
    }

    private void BtnCancelar_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
    }

    private void TxtUsuario_TextChanged(object sender, EventArgs e)
    {
    }

    private void TxtUsuario_DoubleClick(object sender, EventArgs e)
    {
    }

    private void TxtUsuario_Click(object sender, EventArgs e)
    {
    }

    private void TxtPassWord_TextChanged(object sender, EventArgs e)
    {
        if (!Control.IsKeyLocked(Keys.CapsLock))
        return;
      this.toolTip1.Show("Mayúsculas Activadas", (IWin32Window) this.TxtPassWord, 2000);
    }

    private void TxtPassWord_Click(object sender, EventArgs e)
    {
    }

    private void TxtPassWord_DoubleClick(object sender, EventArgs e)
    {
    }

    private void label10_Click(object sender, EventArgs e)
    {
    }

    private void pictureBox1_Click(object sender, EventArgs e)
    {
      if (this.Height < 216)
        this.Height = 216;
      else
        this.Height = 176;
    }
  }
}
