// Type: Sistema.FrmCambioDePassword
// Assembly: DataAccess, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C415D2F-B423-4DB8-8067-FB9CD8A174EC
// Assembly location: C:\Users\abrahamm\Documents\Visual Studio 2012\Projects2\Facturacion\Timbrado Nomina\TimbradoNomina\bin\Debug\DataAccess.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Sistema
{
  public class FrmCambioDePassword : Form
  {
    private DataAccessCls DAO = DataAccessCls.DevuelveInstancia();
    private PictureBox pictureBox1;
    public TextBox TxtPassWord;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private Button BtnCancelar;
    private Button BtnAceptar;
    public TextBox TxtPassworNuevo;
    public TextBox TxtPasswordNuevoConfirmacion;
    private ComboBox cboUsuarios;
    private Bitmap bitImagen;
    private Container components;

    public FrmCambioDePassword()
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FrmCambioDePassword));
      this.pictureBox1 = new PictureBox();
      this.TxtPassWord = new TextBox();
      this.label1 = new Label();
      this.label2 = new Label();
      this.cboUsuarios = new ComboBox();
      this.TxtPassworNuevo = new TextBox();
      this.label3 = new Label();
      this.TxtPasswordNuevoConfirmacion = new TextBox();
      this.label4 = new Label();
      this.BtnCancelar = new Button();
      this.BtnAceptar = new Button();
      this.SuspendLayout();
      this.pictureBox1.Image = (Image) componentResourceManager.GetObject("pictureBox1.Image");
      this.pictureBox1.Location = new Point(8, 17);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(148, 134);
      this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 11;
      this.pictureBox1.TabStop = false;
      this.TxtPassWord.Font = new Font("Trebuchet MS", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.TxtPassWord.Location = new Point(274, 53);
      this.TxtPassWord.Name = "TxtPassWord";
      this.TxtPassWord.PasswordChar = '*';
      this.TxtPassWord.Size = new Size(262, 21);
      this.TxtPassWord.TabIndex = 1;
      this.TxtPassWord.DoubleClick += new EventHandler(this.TxtPassWord_DoubleClick);
      this.TxtPassWord.TextChanged += new EventHandler(this.TxtPassWord_TextChanged);
      this.label1.Font = new Font("Trebuchet MS", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.Location = new Point(170, 53);
      this.label1.Name = "label1";
      this.label1.Size = new Size(102, 13);
      this.label1.TabIndex = 14;
      this.label1.Text = "Password Actual:";
      this.label2.Font = new Font("Trebuchet MS", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.Location = new Point(170, 30);
      this.label2.Name = "label2";
      this.label2.Size = new Size(60, 13);
      this.label2.TabIndex = 12;
      this.label2.Text = "Usuario:";
      this.cboUsuarios.Font = new Font("Trebuchet MS", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cboUsuarios.Location = new Point(274, 25);
      this.cboUsuarios.Name = "cboUsuarios";
      this.cboUsuarios.Size = new Size(262, 26);
      this.cboUsuarios.TabIndex = 0;
      this.TxtPassworNuevo.Font = new Font("Trebuchet MS", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.TxtPassworNuevo.Location = new Point(274, 76);
      this.TxtPassworNuevo.Name = "TxtPassworNuevo";
      this.TxtPassworNuevo.PasswordChar = '*';
      this.TxtPassworNuevo.Size = new Size(262, 21);
      this.TxtPassworNuevo.TabIndex = 2;
      this.TxtPassworNuevo.DoubleClick += new EventHandler(this.TxtPassworNuevo_DoubleClick);
      this.TxtPassworNuevo.TextChanged += new EventHandler(this.TxtPassworNuevo_TextChanged);
      this.label3.Font = new Font("Trebuchet MS", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label3.Location = new Point(170, 76);
      this.label3.Name = "label3";
      this.label3.Size = new Size(102, 13);
      this.label3.TabIndex = 17;
      this.label3.Text = "Password Nuevo:";
      this.TxtPasswordNuevoConfirmacion.Font = new Font("Trebuchet MS", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.TxtPasswordNuevoConfirmacion.Location = new Point(274, 100);
      this.TxtPasswordNuevoConfirmacion.Name = "TxtPasswordNuevoConfirmacion";
      this.TxtPasswordNuevoConfirmacion.PasswordChar = '*';
      this.TxtPasswordNuevoConfirmacion.Size = new Size(262, 21);
      this.TxtPasswordNuevoConfirmacion.TabIndex = 3;
      this.TxtPasswordNuevoConfirmacion.DoubleClick += new EventHandler(this.TxtPasswordNuevoConfirmacion_DoubleClick);
      this.TxtPasswordNuevoConfirmacion.TextChanged += new EventHandler(this.TxtPasswordNuevoConfirmacion_TextChanged);
      this.label4.Font = new Font("Trebuchet MS", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label4.Location = new Point(170, 100);
      this.label4.Name = "label4";
      this.label4.Size = new Size(102, 13);
      this.label4.TabIndex = 19;
      this.label4.Text = "Password Nuevo:";
      this.BtnCancelar.DialogResult = DialogResult.Cancel;
      this.BtnCancelar.Font = new Font("Trebuchet MS", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.BtnCancelar.Location = new Point(418, 150);
      this.BtnCancelar.Name = "BtnCancelar";
      this.BtnCancelar.Size = new Size(113, 24);
      this.BtnCancelar.TabIndex = 5;
      this.BtnCancelar.Text = "&Cancelar";
      this.BtnCancelar.Click += new EventHandler(this.BtnCancelar_Click);
      this.BtnAceptar.Font = new Font("Trebuchet MS", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.BtnAceptar.Location = new Point(298, 150);
      this.BtnAceptar.Name = "BtnAceptar";
      this.BtnAceptar.Size = new Size(113, 24);
      this.BtnAceptar.TabIndex = 4;
      this.BtnAceptar.Text = "&Aceptar";
      this.BtnAceptar.Click += new EventHandler(this.BtnAceptar_Click);
      this.AutoScaleBaseSize = new Size(5, 13);
      this.BackColor = Color.White;
      this.ClientSize = new Size(544, 192);
      this.ControlBox = false;
      this.Controls.Add((Control) this.BtnCancelar);
      this.Controls.Add((Control) this.BtnAceptar);
      this.Controls.Add((Control) this.TxtPasswordNuevoConfirmacion);
      this.Controls.Add((Control) this.TxtPassworNuevo);
      this.Controls.Add((Control) this.TxtPassWord);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.cboUsuarios);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.pictureBox1);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FrmCambioDePassword";
      this.StartPosition = FormStartPosition.CenterScreen;
      this.TopMost = true;
      this.Load += new EventHandler(this.FrmCambioDePassword_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private void FrmCambioDePassword_Load(object sender, EventArgs e)
    {
      this.DAO = DataAccessCls.DevuelveInstancia();
      if (!this.DAO.RegresaConsultaSQL("Select cLogin From Usuarios where cLogin<>'SA'", (ListControl) this.cboUsuarios))
      {
        int num = (int) MessageBox.Show("Error Al Intentar Llenar El Listado De Usuarios", "Error..", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      if (this.cboUsuarios.FindString(this.DAO.GetLoginUsuario()) < 0)
        return;
      this.cboUsuarios.SelectedIndex = this.cboUsuarios.FindString(this.DAO.GetLoginUsuario());
    }

    private void BtnAceptar_Click(object sender, EventArgs e)
    {
      if (this.TxtPassworNuevo.Text != this.TxtPasswordNuevoConfirmacion.Text)
      {
        int num = (int) MessageBox.Show("El Password De Confirmación No Coincide, Verifique", "Atención...", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        this.TxtPasswordNuevoConfirmacion.Text = "";
        this.TxtPassworNuevo.Text = "";
      }
      else
      {
        if (!this.DAO.DAO_CambiaPassword(this.cboUsuarios.Text, this.TxtPassWord.Text, this.TxtPassworNuevo.Text))
          return;
        this.DialogResult = DialogResult.OK;
      }
    }

    private void BtnCancelar_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
    }

    private void TxtPassWord_TextChanged(object sender, EventArgs e)
    {
    }

    private void TxtPassWord_DoubleClick(object sender, EventArgs e)
    {
    }

    private void TxtPassworNuevo_TextChanged(object sender, EventArgs e)
    {
    }

    private void TxtPassworNuevo_DoubleClick(object sender, EventArgs e)
    {
    }

    private void TxtPasswordNuevoConfirmacion_TextChanged(object sender, EventArgs e)
    {
    }

    private void TxtPasswordNuevoConfirmacion_DoubleClick(object sender, EventArgs e)
    {
    }
  }
}
