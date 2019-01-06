// Type: Sistema.FrmAutorizacionLocalDeOperacionSupervisada
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
  public class FrmAutorizacionLocalDeOperacionSupervisada : Form
  {
    private DataAccessCls DAO = DataAccessCls.DevuelveInstancia();
    public ComboBox CboSupervisor;
    private Label label1;
    private Label label2;
    private TextBox TxtPassWord;
    public string operacionSupervisada;
    public string observacion;
    private bool solicitudRemotaActiva;
    private long operacionSupervisadaRemota;
    private short intentos;
    private Button BtnCancelar;
    private Button BtnAceptar;
    private TextBox TxtDescripcion;
    private Button BtnAutorizacionRemota;
    private Timer timer1;
    private TextBox TxtObservacion;
    private Label label3;
    private Label label4;
    private PictureBox pictureBox1;
    private CheckBox chkAutorizacionTemporal;
    private TextBox TXTPasswordTemporal;
    private Label label5;
    private IContainer components;
    private Bitmap bitImagen;

    public FrmAutorizacionLocalDeOperacionSupervisada()
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FrmAutorizacionLocalDeOperacionSupervisada));
      this.CboSupervisor = new ComboBox();
      this.label1 = new Label();
      this.label2 = new Label();
      this.TxtPassWord = new TextBox();
      this.BtnCancelar = new Button();
      this.BtnAceptar = new Button();
      this.TxtDescripcion = new TextBox();
      this.BtnAutorizacionRemota = new Button();
      this.timer1 = new Timer(this.components);
      this.TxtObservacion = new TextBox();
      this.label3 = new Label();
      this.label4 = new Label();
      this.pictureBox1 = new PictureBox();
      this.chkAutorizacionTemporal = new CheckBox();
      this.TXTPasswordTemporal = new TextBox();
      this.label5 = new Label();
      this.SuspendLayout();
      this.CboSupervisor.DropDownStyle = ComboBoxStyle.DropDownList;
      this.CboSupervisor.Font = new Font("Trebuchet MS", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.CboSupervisor.Location = new Point(336, 24);
      this.CboSupervisor.Name = "CboSupervisor";
      this.CboSupervisor.Size = new Size(277, 26);
      this.CboSupervisor.TabIndex = 0;
      this.CboSupervisor.SelectedIndexChanged += new EventHandler(this.CboSupervisor_SelectedIndexChanged);
      this.label1.Font = new Font("Trebuchet MS", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.Location = new Point(248, 24);
      this.label1.Name = "label1";
      this.label1.Size = new Size(72, 23);
      this.label1.TabIndex = 5;
      this.label1.Text = "Supervisor:";
      this.label2.Font = new Font("Trebuchet MS", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.Location = new Point(248, 56);
      this.label2.Name = "label2";
      this.label2.Size = new Size(72, 23);
      this.label2.TabIndex = 4;
      this.label2.Text = "Password:";
      this.TxtPassWord.Font = new Font("Trebuchet MS", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.TxtPassWord.Location = new Point(336, 56);
      this.TxtPassWord.Name = "TxtPassWord";
      this.TxtPassWord.PasswordChar = '*';
      this.TxtPassWord.Size = new Size(277, 21);
      this.TxtPassWord.TabIndex = 1;
      this.BtnCancelar.DialogResult = DialogResult.Cancel;
      this.BtnCancelar.Font = new Font("Trebuchet MS", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.BtnCancelar.Location = new Point(498, 156);
      this.BtnCancelar.Name = "BtnCancelar";
      this.BtnCancelar.Size = new Size(113, 24);
      this.BtnCancelar.TabIndex = 5;
      this.BtnCancelar.TabStop = false;
      this.BtnCancelar.Text = "&Cancelar";
      this.BtnCancelar.Click += new EventHandler(this.BtnCancelar_Click);
      this.BtnAceptar.Font = new Font("Trebuchet MS", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.BtnAceptar.Location = new Point(378, 156);
      this.BtnAceptar.Name = "BtnAceptar";
      this.BtnAceptar.Size = new Size(113, 24);
      this.BtnAceptar.TabIndex = 4;
      this.BtnAceptar.Text = "&Aceptar";
      this.BtnAceptar.Click += new EventHandler(this.BtnAceptar_Click);
      this.TxtDescripcion.Location = new Point(12, 329);
      this.TxtDescripcion.Multiline = true;
      this.TxtDescripcion.Name = "TxtDescripcion";
      this.TxtDescripcion.Size = new Size(604, 93);
      this.TxtDescripcion.TabIndex = 28;
      this.TxtDescripcion.TabStop = false;
      this.BtnAutorizacionRemota.Font = new Font("Trebuchet MS", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.BtnAutorizacionRemota.Location = new Point(242, 156);
      this.BtnAutorizacionRemota.Name = "BtnAutorizacionRemota";
      this.BtnAutorizacionRemota.Size = new Size(136, 24);
      this.BtnAutorizacionRemota.TabIndex = 6;
      this.BtnAutorizacionRemota.TabStop = false;
      this.BtnAutorizacionRemota.Text = "Autorización &Remota";
      this.BtnAutorizacionRemota.Click += new EventHandler(this.BtnAutorizacionRemota_Click);
      this.timer1.Enabled = true;
      this.timer1.Interval = 2000;
      this.timer1.Tick += new EventHandler(this.timer1_Tick);
      this.TxtObservacion.Location = new Point(12, 209);
      this.TxtObservacion.Multiline = true;
      this.TxtObservacion.Name = "TxtObservacion";
      this.TxtObservacion.Size = new Size(604, 93);
      this.TxtObservacion.TabIndex = 30;
      this.TxtObservacion.TabStop = false;
      this.label3.Font = new Font("Trebuchet MS", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label3.Location = new Point(13, 187);
      this.label3.Name = "label3";
      this.label3.Size = new Size(81, 23);
      this.label3.TabIndex = 31;
      this.label3.Text = "Observación";
      this.label4.Font = new Font("Trebuchet MS", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label4.Location = new Point(13, 313);
      this.label4.Name = "label4";
      this.label4.Size = new Size(87, 23);
      this.label4.TabIndex = 32;
      this.label4.Text = "Descripción";
      this.label4.Click += new EventHandler(this.label4_Click);
      this.pictureBox1.Image = (Image) componentResourceManager.GetObject("pictureBox1.Image");
      this.pictureBox1.Location = new Point(24, 16);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(136, 104);
      this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 33;
      this.pictureBox1.TabStop = false;
      this.chkAutorizacionTemporal.AutoSize = true;
      this.chkAutorizacionTemporal.Location = new Point(336, 84);
      this.chkAutorizacionTemporal.Name = "chkAutorizacionTemporal";
      this.chkAutorizacionTemporal.Size = new Size(139, 20);
      this.chkAutorizacionTemporal.TabIndex = 2;
      this.chkAutorizacionTemporal.Text = "Autorización Temporal";
      this.chkAutorizacionTemporal.UseVisualStyleBackColor = true;
      this.chkAutorizacionTemporal.CheckedChanged += new EventHandler(this.chkAutorizacionTemporal_CheckedChanged);
      this.TXTPasswordTemporal.Enabled = false;
      this.TXTPasswordTemporal.Font = new Font("Trebuchet MS", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.TXTPasswordTemporal.Location = new Point(334, 110);
      this.TXTPasswordTemporal.MaxLength = 40;
      this.TXTPasswordTemporal.Name = "TXTPasswordTemporal";
      this.TXTPasswordTemporal.PasswordChar = '*';
      this.TXTPasswordTemporal.Size = new Size(277, 21);
      this.TXTPasswordTemporal.TabIndex = 3;
      this.label5.Font = new Font("Trebuchet MS", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label5.Location = new Point(246, 110);
      this.label5.Name = "label5";
      this.label5.Size = new Size(72, 23);
      this.label5.TabIndex = 36;
      this.label5.Text = "Temporal:";
      this.AutoScaleBaseSize = new Size(5, 13);
      this.BackColor = Color.White;
      this.ClientSize = new Size(626, 434);
      this.Controls.Add((Control) this.TXTPasswordTemporal);
      this.Controls.Add((Control) this.label5);
      this.Controls.Add((Control) this.chkAutorizacionTemporal);
      this.Controls.Add((Control) this.pictureBox1);
      this.Controls.Add((Control) this.TxtDescripcion);
      this.Controls.Add((Control) this.TxtObservacion);
      this.Controls.Add((Control) this.TxtPassWord);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.BtnAutorizacionRemota);
      this.Controls.Add((Control) this.BtnCancelar);
      this.Controls.Add((Control) this.BtnAceptar);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.CboSupervisor);
      this.Font = new Font("Trebuchet MS", 7.8f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.KeyPreview = true;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FrmAutorizacionLocalDeOperacionSupervisada";
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.TopMost = true;
      this.Load += new EventHandler(this.FrmAutorizacionLocalDeOperacionSupervisada_Load);
      this.Closing += new CancelEventHandler(this.FrmAutorizacionLocalDeOperacionSupervisada_Closing);
      this.KeyDown += new KeyEventHandler(this.FrmAutorizacionLocalDeOperacionSupervisada_KeyDown);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private void FrmAutorizacionLocalDeOperacionSupervisada_Load(object sender, EventArgs e)
    {
      this.DAO = DataAccessCls.DevuelveInstancia();
      string str = "select au.cNombre, os.cSupervisor from OperacionesSupervisadas_Supervisores as os join Usuarios as au on (os.cSupervisor=au.cLogin) Where os.cOperacionSupervisada='" + this.operacionSupervisada + "'";
      if (!this.DAO.ExistenDatosEnConsultaSQL(str))
      {
        int num = (int) MessageBox.Show("No Existen Supervisores Definidos Para Esta Operación Supervisada. Contacte Al Administrador Del Sistema..", "Error..", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        this.BtnAceptar.Enabled = false;
        this.BtnAutorizacionRemota.Enabled = false;
        this.CboSupervisor.Enabled = false;
        this.TxtPassWord.Enabled = false;
      }
      if (!this.DAO.RegresaConsultaSQL(str, (ListControl) this.CboSupervisor))
      {
        int num1 = (int) MessageBox.Show("Error Al Intentar Llenar El Listado De Supervisores", "Error..", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      if (this.CboSupervisor.FindString(this.DAO.GetLoginUsuario()) >= 0)
        this.CboSupervisor.SelectedIndex = this.CboSupervisor.FindString(this.DAO.GetLoginUsuario());
      this.TxtDescripcion.Text = this.DAO.RegresaDatoSQL("Select cDescripcion from OperacionesSupervisadas where cOperacionSupervisada='" + this.operacionSupervisada + "'").ToString();
      this.TxtObservacion.Text = this.observacion;
      this.CboSupervisor.Focus();
    }

    private void FrmAutorizacionLocalDeOperacionSupervisada_KeyDown(object sender, KeyEventArgs e)
    {
      switch (e.KeyCode)
      {
        case Keys.Return:
          SendKeys.Send("{tab}");
          break;
        case Keys.Escape:
          SendKeys.Send("+{tab}");
          break;
      }
    }

    private void BtnAceptar_Click(object sender, EventArgs e)
    {
      ++this.intentos;
      if (!this.chkAutorizacionTemporal.Checked)
      {
        if (this.DAO.ValidaUsuarioYPassword(this.CboSupervisor.SelectedValue.ToString(), this.TxtPassWord.Text))
        {
          this.DialogResult = DialogResult.OK;
          return;
        }
      }
      else if (this.DAO.OperacionSupervisadaTemporalUtilizar(this.CboSupervisor.SelectedValue.ToString(), this.TXTPasswordTemporal.Text.Trim(), this.TxtDescripcion.Text, this.TxtObservacion.Text))
      {
        this.DialogResult = DialogResult.OK;
        return;
      }
      if ((int) this.intentos != 3)
        return;
      this.DialogResult = DialogResult.Cancel;
    }

    private void BtnCancelar_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
    }

    private void BtnAutorizacionRemota_Click(object sender, EventArgs e)
    {
      if (!this.solicitudRemotaActiva)
      {
        this.Cursor = Cursors.WaitCursor;
        this.operacionSupervisadaRemota = !this.DAO.GetConexionUtilizandoActiveDirectory() ? this.DAO.OperacionSupervisadaSolicitaAprobacionRemota(this.operacionSupervisada, this.CboSupervisor.SelectedValue.ToString(), this.observacion) : this.DAO.OperacionSupervisadaSolicitaAprobacionRemota(this.operacionSupervisada, this.CboSupervisor.Text, this.observacion);
        if (this.operacionSupervisadaRemota == 0L)
          this.Cursor = Cursors.Default;
        this.BtnAutorizacionRemota.Text = "Cancelar Solicitud";
        this.solicitudRemotaActiva = true;
      }
      else
      {
        this.DAO.OperacionSupervisadaCancelaSolicitudRemota(this.operacionSupervisadaRemota);
        this.BtnAutorizacionRemota.Text = "Autorización Remota";
        this.Cursor = Cursors.Default;
        this.solicitudRemotaActiva = false;
      }
    }

    private void FrmAutorizacionLocalDeOperacionSupervisada_Closing(object sender, CancelEventArgs e)
    {
      if (!this.solicitudRemotaActiva)
        return;
      this.DAO.OperacionSupervisadaCancelaSolicitudRemota(this.operacionSupervisadaRemota);
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      if (!this.solicitudRemotaActiva || !this.DAO.ExistenDatosEnConsultaSQL("Select * from OperacionesSupervisadas_Remotas  where nOperacionSupervisadaRemota=" + this.operacionSupervisadaRemota.ToString() + " And bOperacionSupervisadaRemotaAutorizada=1"))
        return;
      this.Cursor = Cursors.Default;
      this.DialogResult = DialogResult.OK;
    }

    private void CboSupervisor_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void label4_Click(object sender, EventArgs e)
    {
    }

    private void chkAutorizacionTemporal_CheckedChanged(object sender, EventArgs e)
    {
      this.TXTPasswordTemporal.Enabled = this.chkAutorizacionTemporal.Checked;
    }
  }
}
