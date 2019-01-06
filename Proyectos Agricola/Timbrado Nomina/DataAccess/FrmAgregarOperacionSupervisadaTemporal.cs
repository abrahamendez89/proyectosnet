// Type: Sistema.FrmAgregarOperacionSupervisadaTemporal
// Assembly: DataAccess, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C415D2F-B423-4DB8-8067-FB9CD8A174EC
// Assembly location: C:\Users\abrahamm\Documents\Visual Studio 2012\Projects2\Facturacion\Timbrado Nomina\TimbradoNomina\bin\Debug\DataAccess.dll

using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Sistema
{
  internal class FrmAgregarOperacionSupervisadaTemporal : Form
  {
    private const string MensajeAutorizacionesDisponibles = "{0} Autorizaciones Disponibles";
    private IContainer components;
    private PictureBox pictureBox1;
    public TextBox TxtPassWord;
    public TextBox TxtUsuario;
    private Label label1;
    private Label label2;
    public TextBox TxtPasswordTemporal;
    private Label label3;
    private Button BtnCancelar;
    private Button BtnAceptar;
    private Label lblPasswordsDisponibles;
    private Button btnMostrar;
    private DataAccessCls DAO;
    private string SQLText;
    private Bitmap bitImagen;

    public FrmAgregarOperacionSupervisadaTemporal()
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FrmAgregarOperacionSupervisadaTemporal));
      this.pictureBox1 = new PictureBox();
      this.TxtPassWord = new TextBox();
      this.TxtUsuario = new TextBox();
      this.label1 = new Label();
      this.label2 = new Label();
      this.TxtPasswordTemporal = new TextBox();
      this.label3 = new Label();
      this.BtnCancelar = new Button();
      this.BtnAceptar = new Button();
      this.lblPasswordsDisponibles = new Label();
      this.btnMostrar = new Button();
      this.SuspendLayout();
      this.pictureBox1.Image = (Image) componentResourceManager.GetObject("pictureBox1.Image");
      this.pictureBox1.Location = new Point(12, 23);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(136, 104);
      this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 34;
      this.pictureBox1.TabStop = false;
      this.TxtPassWord.Font = new Font("Trebuchet MS", 13f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.TxtPassWord.Location = new Point(266, 62);
      this.TxtPassWord.Name = "TxtPassWord";
      this.TxtPassWord.PasswordChar = '*';
      this.TxtPassWord.Size = new Size(345, 28);
      this.TxtPassWord.TabIndex = 1;
      this.TxtUsuario.Font = new Font("Trebuchet MS", 13f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.TxtUsuario.Location = new Point(266, 28);
      this.TxtUsuario.Name = "TxtUsuario";
      this.TxtUsuario.Size = new Size(345, 28);
      this.TxtUsuario.TabIndex = 0;
      this.label1.Font = new Font("Trebuchet MS", 13f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.Location = new Point(158, 28);
      this.label1.Name = "label1";
      this.label1.Size = new Size(103, 23);
      this.label1.TabIndex = 37;
      this.label1.Text = "Usuario:";
      this.label1.TextAlign = ContentAlignment.MiddleRight;
      this.label2.Font = new Font("Trebuchet MS", 13f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.Location = new Point(158, 62);
      this.label2.Name = "label2";
      this.label2.Size = new Size(102, 23);
      this.label2.TabIndex = 38;
      this.label2.Text = "Password:";
      this.label2.TextAlign = ContentAlignment.MiddleRight;
      this.TxtPasswordTemporal.Font = new Font("Trebuchet MS", 13f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.TxtPasswordTemporal.Location = new Point(266, 99);
      this.TxtPasswordTemporal.MaxLength = 40;
      this.TxtPasswordTemporal.Name = "TxtPasswordTemporal";
      this.TxtPasswordTemporal.PasswordChar = '*';
      this.TxtPasswordTemporal.Size = new Size(345, 28);
      this.TxtPasswordTemporal.TabIndex = 2;
      this.label3.Font = new Font("Trebuchet MS", 13f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label3.Location = new Point(158, 99);
      this.label3.Name = "label3";
      this.label3.Size = new Size(102, 23);
      this.label3.TabIndex = 40;
      this.label3.Text = "Temporal:";
      this.label3.TextAlign = ContentAlignment.MiddleRight;
      this.BtnCancelar.DialogResult = DialogResult.Cancel;
      this.BtnCancelar.Font = new Font("Trebuchet MS", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.BtnCancelar.Location = new Point(385, 141);
      this.BtnCancelar.Name = "BtnCancelar";
      this.BtnCancelar.Size = new Size(113, 24);
      this.BtnCancelar.TabIndex = 4;
      this.BtnCancelar.Text = "&Cancelar";
      this.BtnCancelar.Click += new EventHandler(this.BtnCancelar_Click);
      this.BtnAceptar.Font = new Font("Trebuchet MS", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.BtnAceptar.Location = new Point(265, 141);
      this.BtnAceptar.Name = "BtnAceptar";
      this.BtnAceptar.Size = new Size(113, 24);
      this.BtnAceptar.TabIndex = 3;
      this.BtnAceptar.Text = "&Aceptar";
      this.BtnAceptar.Click += new EventHandler(this.BtnAceptar_Click);
      this.lblPasswordsDisponibles.Font = new Font("Trebuchet MS", 13f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblPasswordsDisponibles.Location = new Point(12, 142);
      this.lblPasswordsDisponibles.Name = "lblPasswordsDisponibles";
      this.lblPasswordsDisponibles.Size = new Size(248, 23);
      this.lblPasswordsDisponibles.TabIndex = 43;
      this.lblPasswordsDisponibles.TextAlign = ContentAlignment.MiddleRight;
      this.btnMostrar.Font = new Font("Trebuchet MS", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnMostrar.Location = new Point(498, 141);
      this.btnMostrar.Name = "btnMostrar";
      this.btnMostrar.Size = new Size(113, 24);
      this.btnMostrar.TabIndex = 44;
      this.btnMostrar.Text = "&Mostar Activas";
      this.btnMostrar.Click += new EventHandler(this.btnMostrar_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(623, 177);
      this.Controls.Add((Control) this.btnMostrar);
      this.Controls.Add((Control) this.lblPasswordsDisponibles);
      this.Controls.Add((Control) this.BtnCancelar);
      this.Controls.Add((Control) this.BtnAceptar);
      this.Controls.Add((Control) this.TxtPasswordTemporal);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.TxtPassWord);
      this.Controls.Add((Control) this.TxtUsuario);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.pictureBox1);
      this.KeyPreview = true;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FrmAgregarOperacionSupervisadaTemporal";
      this.ShowIcon = false;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Agregar Aurorización Temporal";
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    protected override void OnLoad(EventArgs e)
    {
      this.DAO = DataAccessCls.DevuelveInstancia();
      this.Limpiar();
      base.OnLoad(e);
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
      switch (e.KeyCode)
      {
        case Keys.Return:
          SendKeys.Send("{TAB}");
          break;
        case Keys.Escape:
          SendKeys.Send("+{TAB}");
          break;
      }
      base.OnKeyDown(e);
    }

    private void Limpiar()
    {
      this.TxtUsuario.Text = "";
      this.TxtPassWord.Text = "";
      this.TxtPasswordTemporal.Text = "";
      this.ConfiguraUsuarioActivo();
      this.TxtPassWord.Focus();
    }

    private void setOperacionesDisponibles()
    {
      this.SQLText = "SELECT ISNULL(COUNT(1) ,0) FROM OperacionesSupervisadas_Temporales(NOLOCK) WHERE bAplicado = 0 AND cUsuario_Registro = '{0}'";
      this.SQLText = string.Format(this.SQLText, (object) this.TxtUsuario.Text.Trim());
      this.lblPasswordsDisponibles.Text = string.Format("{0} Autorizaciones Disponibles", this.DAO.RegresaDatoSQL(this.SQLText));
    }

    private void ConfiguraUsuarioActivo()
    {
      this.TxtUsuario.Text = this.DAO.GetLoginUsuario();
      this.TxtUsuario.Enabled = false;
      this.setOperacionesDisponibles();
    }

    private void BtnCancelar_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private bool ValidaGuardar()
    {
      if (!(this.TxtPasswordTemporal.Text.Trim() == ""))
        return true;
      int num = (int) MessageBox.Show("Falta proporcionar un password temporal", "Access", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      this.TxtPasswordTemporal.Focus();
      return false;
    }

    private void BtnAceptar_Click(object sender, EventArgs e)
    {
      if (!this.ValidaGuardar() || !this.DAO.ValidaUsuarioYPassword(this.TxtUsuario.Text, this.TxtPassWord.Text))
        return;
      this.SQLText = "INSERT OperacionesSupervisadas_Temporales (cPassword ,cUsuario_Registro ,dFecha_Registro ,cMaquina_Registro) VALUES('{0}' ,'{1}' ,GETDATE() ,HOST_NAME())";
      this.SQLText = string.Format(this.SQLText, (object) this.TxtPasswordTemporal.Text.Trim(), (object) this.TxtUsuario.Text.Trim());
      if (!this.DAO.EjecutaComandoSQL(this.SQLText))
        return;
      int num = (int) MessageBox.Show("La autorización temporal se ha guardado con éxito", "Access", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      this.Limpiar();
    }

    private void btnMostrar_Click(object sender, EventArgs e)
    {
      if (!this.DAO.ValidaUsuarioYPassword(this.TxtUsuario.Text, this.TxtPassWord.Text))
        return;
      string consultaSQL = string.Format("SELECT cPassword AS Password ,dFecha_Registro AS Fecha ,cMaquina_Registro AS Maquina FROM OperacionesSupervisadas_Temporales(NOLOCK) WHERE bAplicado = 0 AND cUsuario_Registro = '{0}'", (object) this.TxtUsuario.Text.Trim());
      DataTable miDataTable = new DataTable();
      if (!this.DAO.RegresaConsultaSQL(consultaSQL, ref miDataTable))
        return;
      foreach (DataRow dataRow in (InternalDataCollectionBase) miDataTable.Rows)
        dataRow["Password"] = (object) dataRow["Password"].ToString();
      this.DAO.RegresaEleccionDeUsuarioSobreDataTable(miDataTable);
    }
  }
}
