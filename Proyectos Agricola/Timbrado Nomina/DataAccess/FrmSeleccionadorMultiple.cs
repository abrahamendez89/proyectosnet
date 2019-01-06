// Type: Sistema.FrmSeleccionadorMultiple
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
  public class FrmSeleccionadorMultiple : Form
  {
    public string eleccionDeUsuario = "";
    public string seleccionesActuales = "";
    public string separador = "";
    private Label lblPagina;
    public CheckedListBox ChkListBox;
    private Button BtnCancelar;
    private Button BtnAceptar;
    public bool regresaAsteriscoAnteSeleccionCompleta;
    private Button Btn_Ninguno;
    private Button Btn_Todos;
    private Button Btn_Invertir;
    private Icon bitIcon;
    private Container components;

    public FrmSeleccionadorMultiple()
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FrmSeleccionadorMultiple));
      this.lblPagina = new Label();
      this.ChkListBox = new CheckedListBox();
      this.BtnCancelar = new Button();
      this.BtnAceptar = new Button();
      this.Btn_Ninguno = new Button();
      this.Btn_Todos = new Button();
      this.Btn_Invertir = new Button();
      this.SuspendLayout();
      this.lblPagina.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.lblPagina.BackColor = Color.WhiteSmoke;
      this.lblPagina.Font = new Font("Trebuchet MS", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblPagina.Location = new Point(-6, 345);
      this.lblPagina.Name = "lblPagina";
      this.lblPagina.Size = new Size(694, 19);
      this.lblPagina.TabIndex = 1;
      this.lblPagina.Text = "www.Access.com.mx";
      this.lblPagina.TextAlign = ContentAlignment.MiddleCenter;
      this.lblPagina.Click += new EventHandler(this.lblPagina_Click);
      this.ChkListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.ChkListBox.Location = new Point(0, 0);
      this.ChkListBox.MultiColumn = true;
      this.ChkListBox.Name = "ChkListBox";
      this.ChkListBox.Size = new Size(696, 319);
      this.ChkListBox.TabIndex = 2;
      this.ChkListBox.SelectedIndexChanged += new EventHandler(this.ChkListBox_SelectedIndexChanged);
      this.BtnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.BtnCancelar.DialogResult = DialogResult.Cancel;
      this.BtnCancelar.Font = new Font("Trebuchet MS", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.BtnCancelar.Location = new Point(567, 322);
      this.BtnCancelar.Name = "BtnCancelar";
      this.BtnCancelar.Size = new Size(113, 24);
      this.BtnCancelar.TabIndex = 26;
      this.BtnCancelar.Text = "&Cancelar";
      this.BtnCancelar.Click += new EventHandler(this.BtnCancelar_Click);
      this.BtnAceptar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.BtnAceptar.Font = new Font("Trebuchet MS", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.BtnAceptar.Location = new Point(447, 322);
      this.BtnAceptar.Name = "BtnAceptar";
      this.BtnAceptar.Size = new Size(113, 24);
      this.BtnAceptar.TabIndex = 25;
      this.BtnAceptar.Text = "&Aceptar";
      this.BtnAceptar.Click += new EventHandler(this.BtnAceptar_Click);
      this.Btn_Ninguno.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Btn_Ninguno.Font = new Font("Trebuchet MS", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Btn_Ninguno.Location = new Point(128, 322);
      this.Btn_Ninguno.Name = "Btn_Ninguno";
      this.Btn_Ninguno.Size = new Size(113, 24);
      this.Btn_Ninguno.TabIndex = 28;
      this.Btn_Ninguno.Text = "&Ninguno";
      this.Btn_Ninguno.Click += new EventHandler(this.Btn_Ninguno_Click);
      this.Btn_Todos.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Btn_Todos.Font = new Font("Trebuchet MS", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Btn_Todos.Location = new Point(8, 322);
      this.Btn_Todos.Name = "Btn_Todos";
      this.Btn_Todos.Size = new Size(113, 24);
      this.Btn_Todos.TabIndex = 27;
      this.Btn_Todos.Text = "&Todos";
      this.Btn_Todos.Click += new EventHandler(this.Btn_Todos_Click);
      this.Btn_Invertir.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Btn_Invertir.Font = new Font("Trebuchet MS", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Btn_Invertir.Location = new Point(248, 322);
      this.Btn_Invertir.Name = "Btn_Invertir";
      this.Btn_Invertir.Size = new Size(113, 24);
      this.Btn_Invertir.TabIndex = 29;
      this.Btn_Invertir.Text = "&Invertir";
      this.Btn_Invertir.Click += new EventHandler(this.Btn_Invertir_Click);
      this.AutoScaleBaseSize = new Size(5, 13);
      this.BackColor = Color.WhiteSmoke;
      this.ClientSize = new Size(688, 366);
      this.Controls.Add((Control) this.Btn_Invertir);
      this.Controls.Add((Control) this.Btn_Ninguno);
      this.Controls.Add((Control) this.Btn_Todos);
      this.Controls.Add((Control) this.BtnCancelar);
      this.Controls.Add((Control) this.BtnAceptar);
      this.Controls.Add((Control) this.ChkListBox);
      this.Controls.Add((Control) this.lblPagina);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MinimizeBox = false;
      this.Name = "FrmSeleccionadorMultiple";
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.TopMost = true;
      this.Load += new EventHandler(this.FrmSeleccionadorMultiple_Load);
      this.ResumeLayout(false);
    }

    private void lblPagina_Click(object sender, EventArgs e)
    {
    }

    private void BtnAceptar_Click(object sender, EventArgs e)
    {
      this.eleccionDeUsuario = DataAccessCls.DevuelveInstancia().RegresaEleccionesDeUsuario(ref this.ChkListBox, DataAccessCls.TipoDeValorDeUnListControl.ValueMember, this.separador, this.regresaAsteriscoAnteSeleccionCompleta);
      this.DialogResult = DialogResult.OK;
    }

    private void BtnCancelar_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
    }

    private void FrmSeleccionadorMultiple_Load(object sender, EventArgs e)
    {
      if (this.seleccionesActuales == "*")
      {
        for (int index = 0; index < this.ChkListBox.Items.Count; ++index)
        {
          this.ChkListBox.SetSelected(index, true);
          this.ChkListBox.SetItemCheckState(index, CheckState.Checked);
        }
      }
      else
      {
        foreach (string str in this.seleccionesActuales.Split(this.separador.ToCharArray()))
        {
          for (int index = 0; index <= this.ChkListBox.Items.Count - 1; ++index)
          {
            this.ChkListBox.SetSelected(index, true);
            if (this.ChkListBox.SelectedValue.ToString() == str)
              this.ChkListBox.SetItemCheckState(index, CheckState.Checked);
          }
        }
      }
      if (this.ChkListBox.Items.Count > 0)
        this.ChkListBox.SetSelected(0, true);
      this.ChkListBox.ColumnWidth = (int) this.ChkListBox.CreateGraphics().MeasureString("00000000000000000000000000000000000000000000000000", this.ChkListBox.Font).Width;
      if (this.ChkListBox.Enabled)
        return;
      this.Btn_Invertir.Visible = false;
      this.Btn_Ninguno.Visible = false;
      this.Btn_Todos.Visible = false;
      this.BtnCancelar.Visible = false;
      this.BtnAceptar.Left = this.BtnCancelar.Left;
    }

    private void ChkListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void Btn_Todos_Click(object sender, EventArgs e)
    {
      for (int index = 0; index < this.ChkListBox.Items.Count; ++index)
        this.ChkListBox.SetItemCheckState(index, CheckState.Checked);
    }

    private void Btn_Ninguno_Click(object sender, EventArgs e)
    {
      for (int index = 0; index < this.ChkListBox.Items.Count; ++index)
        this.ChkListBox.SetItemCheckState(index, CheckState.Unchecked);
    }

    private void Btn_Invertir_Click(object sender, EventArgs e)
    {
      for (int index = 0; index < this.ChkListBox.Items.Count; ++index)
      {
        this.ChkListBox.SetSelected(index, true);
        if (this.ChkListBox.GetItemCheckState(index) == CheckState.Checked)
          this.ChkListBox.SetItemCheckState(index, CheckState.Unchecked);
        else
          this.ChkListBox.SetItemCheckState(index, CheckState.Checked);
      }
    }
  }
}
