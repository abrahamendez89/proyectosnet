// Type: Sistema.FrmAutorizacionRemotaDeOperacionSupervisada
// Assembly: DataAccess, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C415D2F-B423-4DB8-8067-FB9CD8A174EC
// Assembly location: C:\Users\abrahamm\Documents\Visual Studio 2012\Projects2\Facturacion\Timbrado Nomina\TimbradoNomina\bin\Debug\DataAccess.dll

using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Sistema
{
  public class FrmAutorizacionRemotaDeOperacionSupervisada : Form
  {
    private DataAccessCls DAO = DataAccessCls.DevuelveInstancia();
    public TextBox TxtPassWord;
    private Label label1;
    private Label label2;
    private Container components;
    private ComboBox CboSupervisores;
    private Button Btn_Autorizar;
    private Label label3;
    private Label label4;
    private Label label5;
    private Label label6;
    private Label label7;
    private Label label8;
    private Label label9;
    private Label label10;
    private TextBox TxtSolicitud_cObservacion;
    private TextBox TxtcDescripcion;
    public TextBox TxtSolicitud_cLogin;
    public TextBox TxtSolicitud_dFecha;
    public TextBox TxtSolicitud_cComputadora;
    public TextBox TxtcOperacionSupervisada;
    private CheckedListBox checkedListBox1;
    private Icon bitIcon;

    public FrmAutorizacionRemotaDeOperacionSupervisada()
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FrmAutorizacionRemotaDeOperacionSupervisada));
      this.CboSupervisores = new ComboBox();
      this.TxtPassWord = new TextBox();
      this.label1 = new Label();
      this.label2 = new Label();
      this.Btn_Autorizar = new Button();
      this.label3 = new Label();
      this.label4 = new Label();
      this.label5 = new Label();
      this.label6 = new Label();
      this.label7 = new Label();
      this.TxtSolicitud_cObservacion = new TextBox();
      this.label8 = new Label();
      this.label9 = new Label();
      this.TxtcDescripcion = new TextBox();
      this.label10 = new Label();
      this.TxtSolicitud_cLogin = new TextBox();
      this.TxtSolicitud_dFecha = new TextBox();
      this.TxtSolicitud_cComputadora = new TextBox();
      this.TxtcOperacionSupervisada = new TextBox();
      this.checkedListBox1 = new CheckedListBox();
      this.SuspendLayout();
      this.CboSupervisores.DropDownStyle = ComboBoxStyle.DropDownList;
      this.CboSupervisores.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.CboSupervisores.Location = new Point(86, 13);
      this.CboSupervisores.Name = "CboSupervisores";
      this.CboSupervisores.Size = new Size(241, 23);
      this.CboSupervisores.TabIndex = 20;
      this.CboSupervisores.SelectedIndexChanged += new EventHandler(this.CboSupervisores_SelectedIndexChanged);
      this.TxtPassWord.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.TxtPassWord.Font = new Font("Trebuchet MS", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.TxtPassWord.Location = new Point(275, 465);
      this.TxtPassWord.Name = "TxtPassWord";
      this.TxtPassWord.PasswordChar = '*';
      this.TxtPassWord.Size = new Size(152, 21);
      this.TxtPassWord.TabIndex = 19;
      this.label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.label1.Font = new Font("Trebuchet MS", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.Location = new Point(202, 468);
      this.label1.Name = "label1";
      this.label1.Size = new Size(62, 13);
      this.label1.TabIndex = 18;
      this.label1.Text = "Password:";
      this.label2.Font = new Font("Trebuchet MS", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label2.Location = new Point(15, 16);
      this.label2.Name = "label2";
      this.label2.Size = new Size(64, 13);
      this.label2.TabIndex = 17;
      this.label2.Text = "Supervisor:";
      this.Btn_Autorizar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.Btn_Autorizar.Location = new Point(440, 466);
      this.Btn_Autorizar.Name = "Btn_Autorizar";
      this.Btn_Autorizar.Size = new Size(208, 24);
      this.Btn_Autorizar.TabIndex = 23;
      this.Btn_Autorizar.Text = "Autorizar Operaciones Seleccionadas";
      this.Btn_Autorizar.Click += new EventHandler(this.Btn_Autorizar_Click);
      this.label3.Font = new Font("Trebuchet MS", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label3.Location = new Point(10, 53);
      this.label3.Name = "label3";
      this.label3.Size = new Size(229, 13);
      this.label3.TabIndex = 24;
      this.label3.Text = "Solicitudes Pendientes de Autorizar";
      this.label3.Click += new EventHandler(this.label3_Click);
      this.label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.label4.Location = new Point(16, 311);
      this.label4.Name = "label4";
      this.label4.Size = new Size(48, 16);
      this.label4.TabIndex = 25;
      this.label4.Text = "Solicitó:";
      this.label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.label5.Location = new Point(288, 309);
      this.label5.Name = "label5";
      this.label5.Size = new Size(48, 16);
      this.label5.TabIndex = 26;
      this.label5.Text = "Fecha:";
      this.label6.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.label6.Location = new Point(456, 309);
      this.label6.Name = "label6";
      this.label6.Size = new Size(80, 16);
      this.label6.TabIndex = 27;
      this.label6.Text = "Computadora:";
      this.label7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.label7.Location = new Point(14, 351);
      this.label7.Name = "label7";
      this.label7.Size = new Size(80, 16);
      this.label7.TabIndex = 28;
      this.label7.Text = "Observación:";
      this.TxtSolicitud_cObservacion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.TxtSolicitud_cObservacion.BackColor = Color.WhiteSmoke;
      this.TxtSolicitud_cObservacion.Location = new Point(14, 369);
      this.TxtSolicitud_cObservacion.Multiline = true;
      this.TxtSolicitud_cObservacion.Name = "TxtSolicitud_cObservacion";
      this.TxtSolicitud_cObservacion.Size = new Size(634, 87);
      this.TxtSolicitud_cObservacion.TabIndex = 29;
      this.TxtSolicitud_cObservacion.TabStop = false;
      this.label8.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.label8.Location = new Point(11, 219);
      this.label8.Name = "label8";
      this.label8.Size = new Size(128, 16);
      this.label8.TabIndex = 30;
      this.label8.Text = "Operación Supervisada:";
      this.label9.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.label9.Location = new Point(13, 239);
      this.label9.Name = "label9";
      this.label9.Size = new Size(80, 16);
      this.label9.TabIndex = 31;
      this.label9.Text = "Descripción:";
      this.TxtcDescripcion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.TxtcDescripcion.BackColor = Color.WhiteSmoke;
      this.TxtcDescripcion.Location = new Point(86, 239);
      this.TxtcDescripcion.Multiline = true;
      this.TxtcDescripcion.Name = "TxtcDescripcion";
      this.TxtcDescripcion.Size = new Size(562, 56);
      this.TxtcDescripcion.TabIndex = 32;
      this.TxtcDescripcion.TabStop = false;
      this.label10.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.label10.BackColor = Color.Black;
      this.label10.ForeColor = Color.White;
      this.label10.Location = new Point(0, 497);
      this.label10.Name = "label10";
      this.label10.Size = new Size(656, 16);
      this.label10.TabIndex = 33;
      this.label10.Text = "1. Seleccione El Supervisor, 2.Marque las Operaciones Que Desea Autorizar, 3.Teclee Su PassWord y 4.Presione El Botón ";
      this.TxtSolicitud_cLogin.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.TxtSolicitud_cLogin.BackColor = Color.WhiteSmoke;
      this.TxtSolicitud_cLogin.Font = new Font("Trebuchet MS", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.TxtSolicitud_cLogin.Location = new Point(16, 325);
      this.TxtSolicitud_cLogin.Name = "TxtSolicitud_cLogin";
      this.TxtSolicitud_cLogin.Size = new Size(272, 21);
      this.TxtSolicitud_cLogin.TabIndex = 34;
      this.TxtSolicitud_cLogin.TabStop = false;
      this.TxtSolicitud_dFecha.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.TxtSolicitud_dFecha.BackColor = Color.WhiteSmoke;
      this.TxtSolicitud_dFecha.Font = new Font("Trebuchet MS", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.TxtSolicitud_dFecha.Location = new Point(288, 325);
      this.TxtSolicitud_dFecha.Name = "TxtSolicitud_dFecha";
      this.TxtSolicitud_dFecha.Size = new Size(168, 21);
      this.TxtSolicitud_dFecha.TabIndex = 35;
      this.TxtSolicitud_dFecha.TabStop = false;
      this.TxtSolicitud_cComputadora.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.TxtSolicitud_cComputadora.BackColor = Color.WhiteSmoke;
      this.TxtSolicitud_cComputadora.Font = new Font("Trebuchet MS", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.TxtSolicitud_cComputadora.Location = new Point(456, 325);
      this.TxtSolicitud_cComputadora.Name = "TxtSolicitud_cComputadora";
      this.TxtSolicitud_cComputadora.Size = new Size(192, 21);
      this.TxtSolicitud_cComputadora.TabIndex = 36;
      this.TxtSolicitud_cComputadora.TabStop = false;
      this.TxtcOperacionSupervisada.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.TxtcOperacionSupervisada.BackColor = Color.WhiteSmoke;
      this.TxtcOperacionSupervisada.Font = new Font("Trebuchet MS", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.TxtcOperacionSupervisada.Location = new Point(136, 216);
      this.TxtcOperacionSupervisada.Name = "TxtcOperacionSupervisada";
      this.TxtcOperacionSupervisada.Size = new Size(512, 21);
      this.TxtcOperacionSupervisada.TabIndex = 37;
      this.TxtcOperacionSupervisada.TabStop = false;
      this.TxtcOperacionSupervisada.TextChanged += new EventHandler(this.TxtcOperacionSupervisada_TextChanged);
      this.checkedListBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.checkedListBox1.Location = new Point(16, 72);
      this.checkedListBox1.Name = "checkedListBox1";
      this.checkedListBox1.Size = new Size(640, 124);
      this.checkedListBox1.TabIndex = 38;
      this.AutoScaleBaseSize = new Size(5, 13);
      this.BackColor = Color.White;
      this.ClientSize = new Size(656, 518);
      this.Controls.Add((Control) this.checkedListBox1);
      this.Controls.Add((Control) this.TxtcOperacionSupervisada);
      this.Controls.Add((Control) this.TxtSolicitud_cComputadora);
      this.Controls.Add((Control) this.TxtSolicitud_dFecha);
      this.Controls.Add((Control) this.TxtSolicitud_cLogin);
      this.Controls.Add((Control) this.TxtcDescripcion);
      this.Controls.Add((Control) this.TxtSolicitud_cObservacion);
      this.Controls.Add((Control) this.TxtPassWord);
      this.Controls.Add((Control) this.label10);
      this.Controls.Add((Control) this.label9);
      this.Controls.Add((Control) this.label8);
      this.Controls.Add((Control) this.label7);
      this.Controls.Add((Control) this.label6);
      this.Controls.Add((Control) this.label5);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.Btn_Autorizar);
      this.Controls.Add((Control) this.CboSupervisores);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.label2);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = "FrmAutorizacionRemotaDeOperacionSupervisada";
      this.Load += new EventHandler(this.FrmAutorizacionRemotaDeOperacionSupervisada_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private void FrmAutorizacionRemotaDeOperacionSupervisada_Load(object sender, EventArgs e)
    {
      this.DAO = DataAccessCls.DevuelveInstancia();
      this.DAO.RegresaConsultaSQL("select distinct au.cNombre, os.cSupervisor from OperacionesSupervisadas_Supervisores as os(NoLock) join usuarios as au (NoLock) on(os.cSupervisor=au.cLogin) order by au.cNombre", (ListControl) this.CboSupervisores);
      if (this.CboSupervisores.FindString(this.DAO.GetLoginUsuario()) < 0)
        return;
      this.CboSupervisores.SelectedIndex = this.CboSupervisores.FindString(this.DAO.GetLoginUsuario());
    }

    private void CboSupervisores_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.DAO.RegresaConsultaSQL(!this.DAO.GetConexionUtilizandoActiveDirectory() ? "select  Solicitud_cLogin +': '+ cOperacionSupervisada + ' ' +convert(char(10),Solicitud_dFecha,121) + ' ' + Solicitud_cObservacion as cDescrip, nOperacionSupervisadaRemota as NOSR from OperacionesSupervisadas_Remotas where Autorizacion_cLogin='" + this.CboSupervisores.SelectedValue + "' and bOperacionSupervisadaRemotaActiva=1 and bOperacionSupervisadaRemotaAutorizada=0" : "select  Solicitud_cLogin +': '+ cOperacionSupervisada + ' ' +convert(char(10),Solicitud_dFecha,121) + ' ' + Solicitud_cObservacion as cDescrip, nOperacionSupervisadaRemota as NOSR from OperacionesSupervisadas_Remotas where Autorizacion_cLogin='" + this.CboSupervisores.Text + "' and bOperacionSupervisadaRemotaActiva=1 and bOperacionSupervisadaRemotaAutorizada=0", (ListControl) this.checkedListBox1);
    }

    private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      SqlDataReader miDataReader = (SqlDataReader) null;
      this.DAO.RegresaConsultaSQL("select opr.cOperacionSupervisada, op.cDescripcion, opr.Solicitud_cLogin, opr.Solicitud_dFecha, opr.Solicitud_cComputadora, opr.Solicitud_cObservacion  from OperacionesSupervisadas_Remotas as opr join OperacionesSupervisadas as op on (opr.cOperacionSupervisada=op.cOperacionSupervisada)" + "\tWhere opr.nOperacionSupervisadaRemota=" + this.checkedListBox1.SelectedValue.ToString(), ref miDataReader);
      while (miDataReader.Read())
      {
        this.TxtcOperacionSupervisada.Text = miDataReader["cOperacionSupervisada"].ToString();
        this.TxtcDescripcion.Text = miDataReader["cDescripcion"].ToString();
        this.TxtSolicitud_cLogin.Text = miDataReader["Solicitud_cLogin"].ToString();
        this.TxtSolicitud_cComputadora.Text = miDataReader["Solicitud_cComputadora"].ToString();
        this.TxtSolicitud_dFecha.Text = miDataReader["Solicitud_dFecha"].ToString();
        this.TxtSolicitud_cObservacion.Text = miDataReader["Solicitud_cObservacion"].ToString();
      }
      miDataReader.Close();
    }

    private void Btn_Autorizar_Click(object sender, EventArgs e)
    {
      if (this.DAO.ValidaUsuarioYPassword(this.CboSupervisores.SelectedValue.ToString(), this.TxtPassWord.Text))
      {
        foreach (int index in this.checkedListBox1.CheckedIndices)
        {
          this.checkedListBox1.SetSelected(index, true);
          this.DAO.EjecutaComandoSQL(!this.DAO.GetConexionUtilizandoActiveDirectory() ? "Update OperacionesSupervisadas_Remotas Set Autorizacion_cLogin='" + this.CboSupervisores.SelectedValue + "', Autorizacion_dFecha=getdate(), Autorizacion_cComputadora=Host_Name(), bOperacionSupervisadaRemotaAutorizada=1" + " Where nOperacionSupervisadaRemota=" + this.checkedListBox1.SelectedValue.ToString() : "Update OperacionesSupervisadas_Remotas Set Autorizacion_cLogin='" + this.CboSupervisores.Text + "', Autorizacion_dFecha=getdate(), Autorizacion_cComputadora=Host_Name(), bOperacionSupervisadaRemotaAutorizada=1" + " Where nOperacionSupervisadaRemota=" + this.checkedListBox1.SelectedValue.ToString());
        }
        this.TxtcDescripcion.Text = "";
        this.TxtcOperacionSupervisada.Text = "";
        this.TxtPassWord.Text = "";
        this.TxtSolicitud_cComputadora.Text = "";
        this.TxtSolicitud_cLogin.Text = "";
        this.TxtSolicitud_cObservacion.Text = "";
        this.TxtSolicitud_dFecha.Text = "";
        this.DAO.RegresaConsultaSQL("select  Solicitud_cLogin +': '+ cOperacionSupervisada + ' ' +convert(char(10),Solicitud_dFecha,121) + ' ' + Solicitud_cObservacion, nOperacionSupervisadaRemota as NOSR from OperacionesSupervisadas_Remotas where Autorizacion_cLogin='" + this.CboSupervisores.Text + "' and bOperacionSupervisadaRemotaActiva=1 and bOperacionSupervisadaRemotaAutorizada=0", (ListControl) this.checkedListBox1);
      }
      else
      {
        int num = (int) MessageBox.Show("Password Incorrecto, Verifique", "Verifique..", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    private void label3_Click(object sender, EventArgs e)
    {
    }

    private void TxtcOperacionSupervisada_TextChanged(object sender, EventArgs e)
    {
    }
  }
}
