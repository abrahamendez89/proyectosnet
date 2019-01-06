// Type: Sistema.FrmVisorDeListasAvanzado
// Assembly: DataAccess, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C415D2F-B423-4DB8-8067-FB9CD8A174EC
// Assembly location: C:\Users\abrahamm\Documents\Visual Studio 2012\Projects2\Facturacion\Timbrado Nomina\TimbradoNomina\bin\Debug\DataAccess.dll

using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema
{
  public class FrmVisorDeListasAvanzado : Form
  {
    private DataAccessCls DAO = DataAccessCls.DevuelveInstancia();
    public string consultaSQL = "";
    public string eleccionDeUsuario = "*";
    public int CantidadElementos = -1;
    public bool seAbortoSeleccion = true;
    public string nombresFisicoDeColumnas = "";
    public string columnaDefault = "";
    public string consultaSQLComplementaria = "";
    public string camposRelacionados = "";
    public string seleccionesActuales = "";
    public string separador = "";
    private DataTable miConsulta = new DataTable();
    private string filtroUsuario = "";
    private string filtroConsulta = "";
    private bool esColumnaSeleccionadoraNumerica = true;
    private const int vAnchoColumna = 19;
    private Label label1;
    private ComboBox CboColumnas;
    private Label label2;
    private TextBox TxtFiltro;
    private Button Btn_Buscar;
    public ListView listView1;
    private Container components;
    public bool requiereFiltroObligatoriamente;
    public bool multiseleccionActivada;
    public bool regresaAsteriscoAnteSeleccionCompleta;
    public bool indicarAsteristoAlPrincipioEnSeleccionCompleta;
    private string[] arCamposRelacionados;
    private DateTimePicker dtFiltroInicial;
    private DateTimePicker dtFiltroFinal;
    private ComboBox CboSiNo;
    private string[] arCamposFisicos;
    private Label ReferenciaRapida;
    private bool tablaDeDatosLlena;

    public FrmVisorDeListasAvanzado()
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FrmVisorDeListasAvanzado));
      this.label1 = new Label();
      this.CboColumnas = new ComboBox();
      this.label2 = new Label();
      this.dtFiltroInicial = new DateTimePicker();
      this.TxtFiltro = new TextBox();
      this.Btn_Buscar = new Button();
      this.listView1 = new ListView();
      this.CboSiNo = new ComboBox();
      this.dtFiltroFinal = new DateTimePicker();
      this.ReferenciaRapida = new Label();
      this.SuspendLayout();
      this.label1.Location = new Point(7, 14);
      this.label1.Name = "label1";
      this.label1.Size = new Size(96, 16);
      this.label1.TabIndex = 0;
      this.label1.Text = "Opciones";
      this.CboColumnas.DropDownStyle = ComboBoxStyle.DropDownList;
      this.CboColumnas.Location = new Point(7, 38);
      this.CboColumnas.Name = "CboColumnas";
      this.CboColumnas.Size = new Size(225, 21);
      this.CboColumnas.TabIndex = 6;
      this.CboColumnas.SelectedIndexChanged += new EventHandler(this.CboColumnas_SelectedIndexChanged);
      this.CboColumnas.Click += new EventHandler(this.CboColumnas_Click);
      this.label2.Location = new Point(236, 14);
      this.label2.Name = "label2";
      this.label2.Size = new Size(96, 16);
      this.label2.TabIndex = 2;
      this.label2.Text = "Buscar";
      this.dtFiltroInicial.Format = DateTimePickerFormat.Custom;
      this.dtFiltroInicial.Location = new Point(232, 38);
      this.dtFiltroInicial.Name = "dtFiltroInicial";
      this.dtFiltroInicial.ShowCheckBox = true;
      this.dtFiltroInicial.Size = new Size(100, 20);
      this.dtFiltroInicial.TabIndex = 2;
      this.TxtFiltro.Location = new Point(232, 38);
      this.TxtFiltro.Name = "TxtFiltro";
      this.TxtFiltro.Size = new Size(339, 20);
      this.TxtFiltro.TabIndex = 1;
      this.TxtFiltro.TextChanged += new EventHandler(this.TxtFiltro_TextChanged);
      this.Btn_Buscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Btn_Buscar.Location = new Point(585, 38);
      this.Btn_Buscar.Name = "Btn_Buscar";
      this.Btn_Buscar.Size = new Size(50, 20);
      this.Btn_Buscar.TabIndex = 5;
      this.Btn_Buscar.Text = "Buscar";
      this.Btn_Buscar.Click += new EventHandler(this.Btn_Buscar_Click);
      this.listView1.AllowColumnReorder = true;
      this.listView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.listView1.BackColor = Color.White;
      this.listView1.CheckBoxes = true;
      this.listView1.Font = new Font("Trebuchet MS", 8f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.listView1.FullRowSelect = true;
      this.listView1.Location = new Point(7, 72);
      this.listView1.Name = "listView1";
      this.listView1.Size = new Size(629, 416);
      this.listView1.TabIndex = 0;
      this.listView1.TabStop = false;
      this.listView1.UseCompatibleStateImageBehavior = false;
      this.listView1.SelectedIndexChanged += new EventHandler(this.listView1_SelectedIndexChanged);
      this.listView1.DoubleClick += new EventHandler(this.listView1_DoubleClick);
      this.listView1.ItemCheck += new ItemCheckEventHandler(this.listView1_ItemCheck);
      this.listView1.ColumnClick += new ColumnClickEventHandler(this.listView1_ColumnClick);
      this.listView1.Click += new EventHandler(this.listView1_Click);
      this.CboSiNo.Location = new Point(232, 38);
      this.CboSiNo.Name = "CboSiNo";
      this.CboSiNo.Size = new Size(120, 21);
      this.CboSiNo.TabIndex = 4;
      this.dtFiltroFinal.Format = DateTimePickerFormat.Custom;
      this.dtFiltroFinal.Location = new Point(347, 38);
      this.dtFiltroFinal.Name = "dtFiltroFinal";
      this.dtFiltroFinal.Size = new Size(92, 20);
      this.dtFiltroFinal.TabIndex = 3;
      this.ReferenciaRapida.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.ReferenciaRapida.BackColor = Color.Black;
      this.ReferenciaRapida.ForeColor = Color.White;
      this.ReferenciaRapida.Location = new Point(0, 496);
      this.ReferenciaRapida.Name = "ReferenciaRapida";
      this.ReferenciaRapida.Size = new Size(656, 16);
      this.ReferenciaRapida.TabIndex = 34;
      this.ReferenciaRapida.Text = "   <F10> Aceptar <Esc> Salir         <Alt><T> Selecciona Todo    <Alt><L> Limpia Selección     <Alt><I>Invierte Selección";
      this.AutoScaleBaseSize = new Size(5, 13);
      this.BackColor = Color.WhiteSmoke;
      this.ClientSize = new Size(648, 510);
      this.Controls.Add((Control) this.ReferenciaRapida);
      this.Controls.Add((Control) this.dtFiltroFinal);
      this.Controls.Add((Control) this.CboSiNo);
      this.Controls.Add((Control) this.listView1);
      this.Controls.Add((Control) this.Btn_Buscar);
      this.Controls.Add((Control) this.TxtFiltro);
      this.Controls.Add((Control) this.dtFiltroInicial);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.CboColumnas);
      this.Controls.Add((Control) this.label1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.KeyPreview = true;
      this.Name = "FrmVisorDeListasAvanzado";
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Búsqueda";
      this.TopMost = true;
      this.Load += new EventHandler(this.FrmVisorDeListasAvanzado_Load);
      this.KeyDown += new KeyEventHandler(this.FrmVisorDeListasAvanzado_KeyDown);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private void FrmVisorDeListasAvanzado_KeyDown(object Sender, KeyEventArgs kea)
    {
      switch (kea.KeyCode)
      {
        case Keys.Return:
          if (!this.multiseleccionActivada && this.listView1.Focused)
          {
            if (this.listView1.SelectedItems.Count > 0)
            {
              this.seAbortoSeleccion = false;
              this.eleccionDeUsuario = this.listView1.SelectedItems[0].Text;
              this.DialogResult = DialogResult.OK;
              kea.Handled = true;
              break;
            }
            else
            {
              SendKeys.Send("{TAB}");
              break;
            }
          }
          else if (!this.listView1.Focused && !this.CboColumnas.Focused)
          {
            this.Btn_Buscar_Click((object) this.Btn_Buscar, new EventArgs());
            break;
          }
          else
          {
            SendKeys.Send("{TAB}");
            break;
          }
        case Keys.Escape:
          this.seAbortoSeleccion = true;
          this.DialogResult = DialogResult.Cancel;
          break;
        case Keys.F10:
          if (this.multiseleccionActivada)
          {
            if (this.listView1.CheckedItems.Count == 0)
            {
              int num = (int) MessageBox.Show("Debe de seleccionar al menos un elemento de la lista", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
              break;
            }
            else
            {
              this.eleccionDeUsuario = DataAccessCls.DevuelveInstancia().RegresaEleccionesDeUsuario(ref this.listView1, DataAccessCls.TipoDeValorDeUnListControl.ValueMember, this.separador, this.regresaAsteriscoAnteSeleccionCompleta, this.CantidadElementos);
              if (this.eleccionDeUsuario.Length > 8000)
              {
                int num = (int) MessageBox.Show("Selección Demasiado Grande", "Aviso...", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                break;
              }
              else
              {
                if (this.indicarAsteristoAlPrincipioEnSeleccionCompleta && this.listView1.CheckedItems.Count == this.listView1.Items.Count && this.filtroConsulta.Trim() == "")
                  this.eleccionDeUsuario = "*" + this.eleccionDeUsuario;
                this.seAbortoSeleccion = false;
                this.DialogResult = DialogResult.OK;
                kea.Handled = true;
                break;
              }
            }
          }
          else
            break;
      }
      if (!kea.Alt)
        return;
      if (kea.KeyCode == Keys.I)
        this.InvertirSeleccion();
      if (kea.KeyCode == Keys.T)
        this.SeleccionCompleta();
      if (kea.KeyCode != Keys.L)
        return;
      this.LimpiarSeleccion();
    }

    private void FrmVisorDeListasAvanzado_Load(object sender, EventArgs e)
    {
      if (this.consultaSQL.Trim() == "")
      {
        int num1 = (int) MessageBox.Show("Se requiere un query para poder operar esta forma...", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else if (this.consultaSQLComplementaria.Trim() == "" && this.camposRelacionados.Trim() != "" || this.consultaSQLComplementaria.Trim() != "" && this.camposRelacionados.Trim() == "")
      {
        int num2 = (int) MessageBox.Show("Los atributos [consultaSQLComplementaria] y [camposRelacionados] son complementarios y deben llevar valor ambos o estar vacios ambos, verifique su programación ", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else
      {
        if (this.CantidadElementos == -1)
          this.CantidadElementos = (int) this.DAO.RegresaDatoSQL("select count(*) from " + this.consultaSQL.Substring(this.consultaSQL.ToUpper().IndexOf("FROM") + 5));
        this.DAO.RegresaConsultaSQL("Select 'Si', 1 Union Select 'No',0", this.CboSiNo, DataAccessCls.TipoElementoAdicionalDeLista.Seleccione);
        DataSet miDataSet1 = new DataSet();
        if (this.consultaSQLComplementaria.Trim() != "")
          this.DAO.RegresaEsquemaDeDatos(this.consultaSQLComplementaria, ref miDataSet1, "Columnas");
        else
          this.DAO.RegresaEsquemaDeDatos(this.consultaSQL, ref miDataSet1, "Columnas");
        DataTable dataTable = new DataTable();
        dataTable.Columns.Add("Nombre", System.Type.GetType("System.String"));
        dataTable.Columns.Add("Tipo", System.Type.GetType("System.String"));
        dataTable.Columns.Add("NombreFisico", System.Type.GetType("System.String"));
        this.listView1.View = View.Details;
        this.listView1.Items.Clear();
        this.listView1.LabelEdit = false;
        this.listView1.GridLines = true;
        this.listView1.FullRowSelect = true;
        foreach (DataColumn dataColumn in (InternalDataCollectionBase) miDataSet1.Tables["Columnas"].Columns)
        {
          DataRow row = dataTable.NewRow();
          dataTable.Rows.Add(row);
          row["Nombre"] = (object) dataColumn.ColumnName;
          row["Tipo"] = (object) dataColumn.DataType.ToString();
        }
        this.CboColumnas.DataSource = (object) dataTable;
        this.CboColumnas.ValueMember = "Tipo";
        this.CboColumnas.DisplayMember = "Nombre";
        if (this.columnaDefault.Trim() != "")
        {
          bool flag = false;
          for (int index = 0; index < this.CboColumnas.Items.Count; ++index)
          {
            this.CboColumnas.SelectedIndex = index;
            if (this.CboColumnas.Text.ToUpper().Trim() == this.columnaDefault.ToUpper().Trim())
            {
              flag = true;
              break;
            }
          }
          if (!flag)
            this.CboColumnas.SelectedIndex = 0;
        }
        DataSet miDataSet2 = new DataSet();
        this.DAO.RegresaEsquemaDeDatos(this.consultaSQL, ref miDataSet2, "Columnas");
        DataColumn dataColumn1 = miDataSet2.Tables["Columnas"].Columns[miDataSet2.Tables["Columnas"].Columns.Count - 1];
        this.esColumnaSeleccionadoraNumerica = dataColumn1.DataType.ToString().Contains("Int") || dataColumn1.DataType.ToString() == "System.Decimal";
        switch (dataColumn1.DataType.ToString())
        {
          case "System.Decimal":
            this.listView1.Columns.Add(dataColumn1.Caption, -2, HorizontalAlignment.Right);
            break;
          case "System.DateTime":
            this.listView1.Columns.Add(dataColumn1.Caption, -2, HorizontalAlignment.Center);
            break;
          default:
            this.listView1.Columns.Add(dataColumn1.Caption, -2, HorizontalAlignment.Left);
            break;
        }
        for (int index = 0; index < miDataSet2.Tables["Columnas"].Columns.Count - 1; ++index)
        {
          DataColumn dataColumn2 = miDataSet2.Tables["Columnas"].Columns[index];
          switch (dataColumn2.DataType.ToString())
          {
            case "System.Decimal":
              this.listView1.Columns.Add(dataColumn2.Caption, -2, HorizontalAlignment.Right);
              break;
            case "System.DateTime":
              this.listView1.Columns.Add(dataColumn2.Caption, -2, HorizontalAlignment.Center);
              break;
            default:
              this.listView1.Columns.Add(dataColumn2.Caption, -2, HorizontalAlignment.Left);
              break;
          }
        }
        if (this.multiseleccionActivada)
        {
          this.listView1.CheckBoxes = true;
          this.listView1.MultiSelect = true;
          this.ReferenciaRapida.Visible = true;
        }
        else
        {
          this.listView1.CheckBoxes = false;
          this.ReferenciaRapida.Text = "<Doble><Click> Seleccionar   <Enter>Seleccionar  <Esc>Salir Sin Seleccionar";
        }
        char[] chArray = ",".ToCharArray();
        if (this.nombresFisicoDeColumnas.Trim() != "")
        {
          this.nombresFisicoDeColumnas = this.nombresFisicoDeColumnas.Replace("[", "");
          this.nombresFisicoDeColumnas = this.nombresFisicoDeColumnas.Replace("]", "");
          this.arCamposFisicos = this.nombresFisicoDeColumnas.Split(chArray);
        }
        if (this.camposRelacionados.Trim() != "")
          this.arCamposRelacionados = this.camposRelacionados.Split(chArray);
        if (this.requiereFiltroObligatoriamente)
        {
          this.ConfiguraAnchoDeColumnas();
          this.CboColumnas.Focus();
          SendKeys.Send("+{TAB}");
          SendKeys.Send("{TAB}");
        }
        else
        {
          this.DAO.RegresaConsultaSQL(this.consultaSQL, ref this.miConsulta);
          this.tablaDeDatosLlena = true;
          int index1 = 0;
          foreach (DataRow dataRow in (InternalDataCollectionBase) this.miConsulta.Rows)
          {
            string text1;
            switch (this.miConsulta.Columns[this.miConsulta.Columns.Count - 1].DataType.ToString())
            {
              case "System.DateTime":
              case "System.Date":
                text1 = dataRow[this.miConsulta.Columns.Count - 1] == DBNull.Value ? "1900/01/01" : Convert.ToDateTime(dataRow[this.miConsulta.Columns.Count - 1]).ToShortDateString();
                break;
              case "System.Boolean":
              case "System.Short":
              case "System.Long":
              case "System.Integer":
              case "System.Int16":
              case "System.Int32":
              case "System.Int64":
              case "System.Double":
              case "System.Float":
              case "System.Single":
              case "System.Byte":
              case "System.Decimal":
                int length1 = this.miConsulta.Columns[this.miConsulta.Columns.Count - 1].MaxLength;
                if (length1 <= 0)
                  length1 = 19;
                string str1 = "                                                                                                    " + (dataRow[this.miConsulta.Columns.Count - 1] == DBNull.Value ? "0" : dataRow[this.miConsulta.Columns.Count - 1].ToString()).Trim();
                text1 = str1.Substring(str1.Length - length1, length1);
                break;
              case "System.String":
                text1 = dataRow[this.miConsulta.Columns.Count - 1] == DBNull.Value ? "" : dataRow[this.miConsulta.Columns.Count - 1].ToString();
                break;
              default:
                text1 = dataRow[this.miConsulta.Columns.Count - 1].ToString() + " No Considerado****";
                break;
            }
            this.listView1.Items.Add(text1);
            for (int index2 = 0; index2 < this.miConsulta.Columns.Count - 1; ++index2)
            {
              string text2;
              switch (this.miConsulta.Columns[index2].DataType.ToString().ToLower())
              {
                case "system.datetime":
                case "system.date":
                  text2 = dataRow[index2] == DBNull.Value ? "1900/01/01" : Convert.ToDateTime(dataRow[index2]).ToShortDateString();
                  break;
                case "system.boolean":
                case "system.short":
                case "system.long":
                case "system.integer":
                case "system.int16":
                case "system.int32":
                case "system.int64":
                case "system.double":
                case "system.float":
                case "system.single":
                case "system.byte":
                case "system.decimal":
                  int length2 = this.miConsulta.Columns[this.miConsulta.Columns.Count - 1].MaxLength;
                  if (length2 <= 0)
                    length2 = 19;
                  string str2 = "                                                                                                    " + (dataRow[index2] == DBNull.Value ? "0" : dataRow[index2].ToString()).Trim();
                  text2 = str2.Substring(str2.Length - length2, length2);
                  break;
                case "system.string":
                  text2 = dataRow[index2] == DBNull.Value ? "" : dataRow[index2].ToString();
                  break;
                default:
                  text2 = dataRow[index2].ToString() + " No Considerado****";
                  break;
              }
              this.listView1.Items[index1].SubItems.Add(text2);
            }
            ++index1;
          }
          this.ConfiguraAnchoDeColumnas();
          if (this.multiseleccionActivada)
            this.MarcaElementosPreseleccionados();
          if (this.listView1.Items.Count >= 0)
          {
            this.listView1.TabStop = true;
            SendKeys.Send("{DOWN}");
            SendKeys.Send("{LEFT}");
            SendKeys.Send("{UP}");
          }
          else
          {
            this.CboColumnas.Focus();
            SendKeys.Send("{TAB}");
          }
        }
      }
    }

    private void CboColumnas_SelectedIndexChanged(object sender, EventArgs e)
    {
      switch (this.CboColumnas.SelectedValue.ToString())
      {
        case "System.DateTime":
          this.TxtFiltro.Visible = false;
          this.dtFiltroInicial.Visible = true;
          this.dtFiltroFinal.Visible = true;
          this.CboSiNo.Visible = false;
          break;
        case "System.Boolean":
          this.TxtFiltro.Visible = false;
          this.dtFiltroInicial.Visible = false;
          this.dtFiltroFinal.Visible = false;
          this.CboSiNo.Visible = true;
          break;
        case "System.String":
        case "System.Short":
        case "System.Long":
        case "System.Integer":
        case "System.Int16":
        case "System.Int32":
        case "System.Int64":
        case "System.Double":
        case "System.Float":
        case "System.Single":
        case "System.Byte":
        case "System.Decimal":
          this.TxtFiltro.Visible = true;
          this.dtFiltroInicial.Visible = false;
          this.dtFiltroFinal.Visible = false;
          this.CboSiNo.Visible = false;
          break;
      }
      this.TxtFiltro.Text = "";
    }

    private void CboColumnas_Click(object sender, EventArgs e)
    {
    }

    private void ConfiguraAnchoDeColumnas()
    {
      for (int index = 0; index < this.listView1.Columns.Count; ++index)
        this.listView1.Columns[index].Width = -2;
    }

    private void Btn_Buscar_Click(object sender, EventArgs e)
    {
      string str1 = !(this.nombresFisicoDeColumnas.Trim() != "") ? this.CboColumnas.Text.Trim() : this.arCamposFisicos[this.CboColumnas.SelectedIndex];
      switch (this.CboColumnas.SelectedValue.ToString())
      {
        case "System.DateTime":
          this.filtroUsuario = this.CboColumnas.Text + " >=  #" + this.dtFiltroInicial.Value.Year.ToString() + "/" + this.dtFiltroInicial.Value.Month.ToString() + "/" + this.dtFiltroInicial.Value.Day.ToString() + "# AND " + this.CboColumnas.Text + "<= #" + this.dtFiltroInicial.Value.Year.ToString() + "/" + this.dtFiltroInicial.Value.Month.ToString() + "/" + this.dtFiltroInicial.Value.Day.ToString() + "#";
          long num1 = this.DAO.NumeroJuliano(this.dtFiltroInicial.Value);
          long num2 = this.DAO.NumeroJuliano(this.dtFiltroFinal.Value) + 1L;
          this.filtroConsulta = "([" + str1.Trim() + "]>=dbo.ADSUM_FechaJuliana(" + num1.ToString() + ") and [" + str1.Trim() + "]< dbo.ADSUM_FechaJuliana(" + num2.ToString() + ") )";
          break;
        case "System.Boolean":
          this.filtroUsuario = this.CboColumnas.Text + " = " + this.CboSiNo.SelectedValue.ToString();
          this.filtroConsulta = "[" + str1.Trim() + "] = " + this.CboSiNo.SelectedValue.ToString();
          break;
        case "System.String":
          if (this.TxtFiltro.Text.IndexOf("'") >= 0 || this.TxtFiltro.Text.IndexOf("--") >= 0)
          {
            int num3 = (int) MessageBox.Show("Existen algunos carácteres invalidos. Intente de Nuevo", "Aviso...");
            this.TxtFiltro.Text = "";
            this.TxtFiltro.Focus();
            return;
          }
          else if (this.TxtFiltro.Text.Replace("%", "").Trim() == "" && this.requiereFiltroObligatoriamente)
          {
            int num3 = (int) MessageBox.Show("Se Debe de Alimentar Un Criterio Forzozamente. Intente de Nuevo", "Aviso...");
            return;
          }
          else
          {
            this.filtroUsuario = this.CboColumnas.Text + " LIKE '%" + this.TxtFiltro.Text.Replace(" ", "%") + "%'";
            this.filtroConsulta = "[" + str1.Trim() + "] LIKE '%" + this.TxtFiltro.Text.Replace(" ", "%") + "%'";
            break;
          }
        case "System.Short":
        case "System.Long":
        case "System.Integer":
        case "System.Int16":
        case "System.Int32":
        case "System.Int64":
        case "System.Double":
        case "System.Float":
        case "System.Single":
        case "System.Byte":
        case "System.Decimal":
          if (Information.IsNumeric((object) this.TxtFiltro.Text))
          {
            this.filtroUsuario = this.CboColumnas.Text + " =" + this.TxtFiltro.Text.Trim();
            this.filtroConsulta = "[" + str1.Trim() + "] =" + this.TxtFiltro.Text.Trim();
            break;
          }
          else if (this.TxtFiltro.Text.Trim() == "")
          {
            if (this.requiereFiltroObligatoriamente)
            {
              int num3 = (int) MessageBox.Show("Se debe de alimentar un criterio forzozamente. Intente de nuevo", "Aviso...");
              return;
            }
            else
            {
              this.filtroUsuario = this.CboColumnas.Text + " =" + this.CboColumnas.Text;
              this.filtroConsulta = "[" + str1.Trim() + "] =" + str1;
              break;
            }
          }
          else
          {
            int num3 = (int) MessageBox.Show("Este campo solo permite datos numéricos. Intente de Nuevo", "Aviso...");
            this.TxtFiltro.Text = "";
            this.TxtFiltro.Focus();
            return;
          }
      }
      if (this.multiseleccionActivada)
      {
        foreach (ListViewItem listViewItem in this.listView1.Items)
        {
          if (!listViewItem.Checked)
            listViewItem.Remove();
        }
      }
      else
        this.listView1.Items.Clear();
      int count = this.listView1.Items.Count;
      this.DAO.RegresaConsultaSQL(this.QueryConFiltros(this.filtroConsulta), ref this.miConsulta);
      this.tablaDeDatosLlena = true;
      foreach (DataRow dataRow in (InternalDataCollectionBase) this.miConsulta.Rows)
      {
        string text1;
        switch (this.miConsulta.Columns[this.miConsulta.Columns.Count - 1].DataType.ToString())
        {
          case "System.DateTime":
          case "System.Date":
            text1 = dataRow[this.miConsulta.Columns.Count - 1] == DBNull.Value ? "1900/01/01" : Convert.ToDateTime(dataRow[this.miConsulta.Columns.Count - 1]).ToShortDateString();
            break;
          case "System.Boolean":
          case "System.Short":
          case "System.Long":
          case "System.Integer":
          case "System.Int16":
          case "System.Int32":
          case "System.Int64":
          case "System.Double":
          case "System.Float":
          case "System.Single":
          case "System.Byte":
          case "System.Decimal":
            int length1 = this.miConsulta.Columns[this.miConsulta.Columns.Count - 1].MaxLength;
            if (length1 <= 0)
              length1 = 19;
            string str2 = "                                                                                                    " + (dataRow[this.miConsulta.Columns.Count - 1] == DBNull.Value ? "0" : dataRow[this.miConsulta.Columns.Count - 1].ToString()).Trim();
            text1 = str2.Substring(str2.Length - length1, length1);
            break;
          case "System.String":
            text1 = dataRow[this.miConsulta.Columns.Count - 1] == DBNull.Value ? "" : dataRow[this.miConsulta.Columns.Count - 1].ToString();
            break;
          default:
            text1 = dataRow[this.miConsulta.Columns.Count - 1].ToString() + " No Considerado****";
            break;
        }
        this.listView1.Items.Add(text1);
        for (int index = 0; index < this.miConsulta.Columns.Count - 1; ++index)
        {
          string text2;
          switch (this.miConsulta.Columns[index].DataType.ToString())
          {
            case "System.DateTime":
            case "System.Date":
              text2 = dataRow[index] == DBNull.Value ? "1900/01/01" : Convert.ToDateTime(dataRow[index]).ToShortDateString();
              break;
            case "System.Boolean":
            case "System.Short":
            case "System.Long":
            case "System.Integer":
            case "System.Int16":
            case "System.Int32":
            case "System.Int64":
            case "System.Double":
            case "System.Float":
            case "System.Single":
            case "System.Byte":
            case "System.Decimal":
              int length2 = this.miConsulta.Columns[this.miConsulta.Columns.Count - 1].MaxLength;
              if (length2 <= 0)
                length2 = 19;
              string str3 = "                                                                                                    " + (dataRow[index] == DBNull.Value ? "0" : dataRow[index].ToString()).Trim();
              text2 = str3.Substring(str3.Length - length2, length2);
              break;
            case "System.String":
              text2 = dataRow[index] == DBNull.Value ? "" : dataRow[index].ToString();
              break;
            default:
              text2 = dataRow[index].ToString() + " No Considerado****";
              break;
          }
          this.listView1.Items[count].SubItems.Add(text2);
        }
        ++count;
      }
      Application.DoEvents();
      this.ConfiguraAnchoDeColumnas();
      if (this.listView1.Items.Count > 0)
      {
        this.listView1.TabStop = true;
        this.listView1.Focus();
        SendKeys.Send("{DOWN}");
        SendKeys.Send("{LEFT}");
        SendKeys.Send("{UP}");
      }
      else
      {
        Application.DoEvents();
        this.CboColumnas.Focus();
        SendKeys.Send("{TAB}");
      }
    }

    private void listView1_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void listView1_DoubleClick(object sender, EventArgs e)
    {
      if (this.multiseleccionActivada)
        return;
      this.eleccionDeUsuario = this.listView1.SelectedItems[0].Text;
      this.DialogResult = DialogResult.OK;
    }

    private void TxtFiltro_TextChanged(object sender, EventArgs e)
    {
    }

    private string QueryConFiltros(string filtroSql)
    {
      string str1 = this.consultaSQL.ToUpper().IndexOf("WHERE", 0) != -1 ? " And " : " Where ";
      string str2;
      if (this.consultaSQLComplementaria.Trim() == "")
      {
        str2 = this.consultaSQL + str1 + filtroSql;
      }
      else
      {
        string str3 = this.arCamposRelacionados[0].Substring(0, this.arCamposRelacionados[0].IndexOf("=", 0));
        string str4 = " Select " + this.arCamposRelacionados[0].Substring(this.arCamposRelacionados[0].IndexOf("=", 0) + 1) + " " + this.consultaSQLComplementaria.Substring(this.consultaSQLComplementaria.ToUpper().IndexOf("FROM ", 0));
        string str5 = this.consultaSQL + str1 + str3 + " In (";
        string str6 = this.consultaSQLComplementaria.ToUpper().IndexOf("WHERE", 0) != -1 ? " And " : " Where ";
        str2 = str5 + str4 + str6 + filtroSql + ")";
      }
      return str2;
    }

    private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
    {
      this.listView1.ListViewItemSorter = (IComparer) new ListViewItemComparer(e.Column);
      this.listView1.Sort();
    }

    private void InvertirSeleccion()
    {
      if (!this.multiseleccionActivada)
        return;
      for (int index = 0; index < this.listView1.Items.Count; ++index)
        this.listView1.Items[index].Checked = !this.listView1.Items[index].Checked;
    }

    private void SeleccionCompleta()
    {
      if (!this.multiseleccionActivada)
        return;
      for (int index = 0; index < this.listView1.Items.Count; ++index)
        this.listView1.Items[index].Checked = true;
    }

    private void LimpiarSeleccion()
    {
      if (!this.multiseleccionActivada)
        return;
      for (int index = 0; index < this.listView1.Items.Count; ++index)
        this.listView1.Items[index].Checked = false;
    }

    private void MarcaElementosPreseleccionados()
    {
      if (!this.multiseleccionActivada)
        return;
      if (this.seleccionesActuales == "*")
      {
        this.SeleccionCompleta();
      }
      else
      {
        foreach (string InputStr in this.seleccionesActuales.Split(this.separador.ToCharArray()))
        {
          for (int index = 0; index < this.listView1.Items.Count; ++index)
          {
            if (this.esColumnaSeleccionadoraNumerica)
            {
              if (Conversion.Val(InputStr) == Conversion.Val(this.listView1.Items[index].Text))
                this.listView1.Items[index].Checked = true;
            }
            else if (this.listView1.Items[index].Text.Trim() == InputStr.Trim())
              this.listView1.Items[index].Checked = true;
          }
        }
      }
    }

    private void MarcaDesmarcaRenglonListView(int renglon, bool marcar)
    {
      this.listView1.Items[renglon].Checked = marcar;
    }

    private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
    {
    }

    private void listView1_Click(object sender, EventArgs e)
    {
    }
  }
}
