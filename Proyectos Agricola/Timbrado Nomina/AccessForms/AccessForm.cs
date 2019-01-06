// Type: Sistema.AccessForm
// Assembly: AccessForms, Version=1.0.4545.30908, Culture=neutral, PublicKeyToken=null
// MVID: 5901ABF0-835C-413E-A9D3-42261792F241
// Assembly location: C:\Users\abrahamm\Documents\Visual Studio 2012\Projects2\Facturacion\Timbrado Nomina\TimbradoNomina\bin\Debug\AccessForms.dll

using ControlesUsuario;
using Sistema.Complementos;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace Sistema
{
  public class AccessForm : Form
  {
    private bool atrAplicarFuenteSecundaria = true;
    private Label lblMensaje;
    private ToolTip toolTip;
    public Label lblToolTip;
    private IContainer components;
    private Icon bitIcono;
    private bool atrGuardar;
    private bool atrEliminar;
    private bool atrEjecutar;
    private bool atrNuevo;
    private bool atrImprimir;
    private bool atrConfigurar;
    protected DataAccessCls DAO;
    internal AccMain atrFormPadre;
    internal ClsToolbarClassMannager atrToolBarButtons;
    internal bool bExistenCambios;
    private Font atrFuenteSecundaria;
    private bool bValidarCambios;
    private bool bEventosAgregados;

    public bool Guardar
    {
      get
      {
        return this.atrGuardar;
      }
      set
      {
        this.atrGuardar = value;
      }
    }

    public bool Borrar
    {
      get
      {
        return this.atrEliminar;
      }
      set
      {
        this.atrEliminar = value;
      }
    }

    public bool Nuevo
    {
      get
      {
        return this.atrNuevo;
      }
      set
      {
        this.atrNuevo = value;
      }
    }

    public bool Eliminar
    {
      get
      {
        return this.atrEliminar;
      }
      set
      {
        this.atrEliminar = value;
      }
    }

    public bool Imprimir
    {
      get
      {
        return this.atrImprimir;
      }
      set
      {
        this.atrImprimir = value;
      }
    }

    public bool Configurar
    {
      get
      {
        return this.atrConfigurar;
      }
      set
      {
        this.atrConfigurar = value;
      }
    }

    public bool Ejecutar
    {
      get
      {
        return this.atrEjecutar;
      }
      set
      {
        this.atrEjecutar = value;
      }
    }

    public AccMain AccMainForm
    {
      get
      {
        return this.atrFormPadre;
      }
    }

    public ClsToolbarClassMannager ToolBarButtons
    {
      get
      {
        return this.atrToolBarButtons;
      }
    }

    [Description("Obtiene o establece el texto que se desplegara en el mensajero ubicado en la parte inferior de la forma.")]
    [Category("Diseño")]
    public string ReferenciaRapida
    {
      get
      {
        return this.lblMensaje.Text;
      }
      set
      {
        this.lblMensaje.Text = value;
      }
    }

    [Description("Determina si la referencia rapida sera visible.")]
    [Category("Diseño")]
    public bool ReferenciaRapidaVisible
    {
      get
      {
        return this.lblMensaje.Visible;
      }
      set
      {
        this.lblMensaje.Visible = value;
      }
    }

    [Category("Configuración")]
    [Description("Determina si se validara cualquier cambio realizado en los controles de la forma al abandonar la pantalla.")]
    public bool ValidarCambios
    {
      get
      {
        return this.bValidarCambios;
      }
      set
      {
        this.bValidarCambios = value;
      }
    }

    [Category("Configuración")]
    [Description("Determian si existen cambios en los controles del formulario.")]
    public bool ExistenCambios
    {
      get
      {
        return this.bExistenCambios;
      }
      set
      {
        this.bExistenCambios = value;
      }
    }

    [Category("Configuración")]
    [Description("Propiedad para establecer si la fuente(establecida en propiedad Fuente) será aplicada en los controles dentro del formulario.")]
    public bool AplicarFuenteSecundaria
    {
      get
      {
        return this.atrAplicarFuenteSecundaria;
      }
      set
      {
        if (value)
          this.Font = new Font("Tahoma", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
        else
          this.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
        this.atrAplicarFuenteSecundaria = value;
      }
    }

    [Description("Propiedad para establecer el tipo de fuente utilizado en los controles dentro del formulario.")]
    [Category("Configuración")]
    public Font FuenteSecundaria
    {
      get
      {
        return this.atrFuenteSecundaria;
      }
      set
      {
        if (this.atrAplicarFuenteSecundaria)
          this.Font = this.atrFuenteSecundaria;
        this.atrFuenteSecundaria = value;
      }
    }

    public event CancelEventHandler ClosingWithChanges;

    public AccessForm()
    {
      this.InitializeComponent();
      this.InicializaVariables();
      this.AplicarFuenteSecundaria = true;
      this.FuenteSecundaria = new Font("Tahoma", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Font = this.FuenteSecundaria;
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (AccessForm));
      this.lblMensaje = new Label();
      this.toolTip = new ToolTip(this.components);
      this.lblToolTip = new Label();
      this.SuspendLayout();
      this.lblMensaje.BackColor = Color.DimGray;
      this.lblMensaje.Dock = DockStyle.Bottom;
      this.lblMensaje.Font = new Font("Tahoma", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblMensaje.ForeColor = Color.White;
      this.lblMensaje.Location = new Point(0, 555);
      this.lblMensaje.Name = "lblMensaje";
      this.lblMensaje.Size = new Size(792, 18);
      this.lblMensaje.TabIndex = 0;
      this.lblMensaje.TextAlign = ContentAlignment.MiddleLeft;
      this.lblToolTip.BackColor = Color.Transparent;
      this.lblToolTip.Location = new Point(0, 0);
      this.lblToolTip.Name = "lblToolTip";
      this.lblToolTip.Size = new Size(16, 23);
      this.lblToolTip.TabIndex = 1;
      this.AutoScaleBaseSize = new Size(6, 15);
      this.BackColor = Color.Gainsboro;
      this.BackgroundImageLayout = ImageLayout.Stretch;
      this.ClientSize = new Size(792, 573);
      this.Controls.Add((Control) this.lblToolTip);
      this.Controls.Add((Control) this.lblMensaje);
      this.Font = new Font("Tahoma", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.KeyPreview = true;
      this.Name = "AccessForm";
      this.Text = "AccessForm";
      this.Load += new EventHandler(this.AccessForm_Load);
      this.ResumeLayout(false);
    }

    protected virtual void ClickBotonNuevo()
    {
    }

    protected virtual void ClickBotonGuardar()
    {
    }

    protected virtual void ClickBotonBorrar()
    {
    }

    protected virtual void ClickBotonImprimir()
    {
    }

    protected virtual void ClickBotonEjecutar()
    {
    }

    protected virtual void ClickBotonConfigurar()
    {
    }

    protected internal virtual bool ValidacionShow()
    {
      return true;
    }

    public virtual void InicializaConRow(DataRow drRow)
    {
    }

    protected override void OnLoad(EventArgs e)
    {
      this.KeyDown += new KeyEventHandler(this.AccessForm_KeyDown);
      this.VisibleChanged += new EventHandler(this.AccessForm_VisibleChanged);
      if (AccMain.GetMainMenu() != null)
        this.MouseMove += new MouseEventHandler(AccMain.GetMainMenu().Elements_MouseMove);
      base.OnLoad(e);
    }

    protected override void OnActivated(EventArgs e)
    {
        if (atrFormPadre != null)
        {
            this.atrFormPadre.HabilitaBotones(this.Nuevo, this.Guardar, this.Borrar, this.Imprimir, this.Ejecutar, this.Configurar);
            
        }
        base.OnActivated(e);
    }

    protected override void OnEnter(EventArgs e)
    {
      this.ActivaConfiguracionBotones();
      base.OnEnter(e);
    }

    protected override void OnLeave(EventArgs e)
    {
      if (this.atrToolBarButtons == null)
        return;
      this.EnciendeBotonesBase();
      base.OnLeave(e);
    }

    protected override void OnClosed(EventArgs e)
    {
      if (this.atrToolBarButtons == null)
        return;
      this.EnciendeBotonesBase();
      base.OnClosed(e);
    }

    protected override void OnClosing(CancelEventArgs e)
    {
      this.OnClosingWithChanges(e);
      if (e.Cancel)
        return;
      base.OnClosing(e);
    }

    protected virtual void OnClosingWithChanges(CancelEventArgs e)
    {
      if (!this.bValidarCambios || !this.bExistenCambios || this.ClosingWithChanges == null)
        return;
      this.ClosingWithChanges((object) this, e);
    }

    private void AccessForm_VisibleChanged(object sender, EventArgs e)
    {
      if (this.bEventosAgregados)
        return;
      this.EventoTextChanged_SelectedIndexChanged_CheckedChanged_DataRowChagedDeleted_Agregar(this.Controls, new EventHandler(this.ControlesTextChanged));
      this.bEventosAgregados = true;
    }

    public void AccessForm_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Return)
        this.SelectNextControl(this.ActiveControl, true, true, true, true);
      if (e.KeyCode == Keys.Escape)
      {
        if (this.ActiveControl != null && this.ActiveControl.GetType() == typeof (AccTextBoxAdvanced))
        {
          AccTextBoxAdvanced accTextBoxAdvanced = (AccTextBoxAdvanced) this.ActiveControl;
        }
        SendKeys.Send("+{TAB}");
      }
      if (!e.Control || this.atrToolBarButtons == null)
        return;
      if (e.KeyCode == Keys.G && this.atrToolBarButtons.Guardar)
        this.ClickBotonGuardar();
      if (e.KeyCode == Keys.U && this.atrToolBarButtons.Nuevo)
        this.ClickBotonNuevo();
      if (e.KeyCode == Keys.B && this.atrToolBarButtons.Borrar)
        this.ClickBotonBorrar();
      if (e.KeyCode == Keys.E && this.atrToolBarButtons.Ejecutar)
        this.ClickBotonEjecutar();
      if (e.KeyCode != Keys.I || !this.atrToolBarButtons.Imprimir)
        return;
      this.ClickBotonImprimir();
    }

    private void ATBManager_ToolbarButton_Click(object sender, Botones e)
    {
      if (this.MdiParent == null || this.MdiParent.ActiveMdiChild == null || this.MdiParent.ActiveMdiChild != this)
        return;
      if (e == Botones.Nuevo && this.atrToolBarButtons.Nuevo)
        this.ClickBotonNuevo();
      if (e == Botones.Guardar && this.atrToolBarButtons.Guardar)
        this.ClickBotonGuardar();
      if (e == Botones.Eliminar && this.atrToolBarButtons.Borrar)
        this.ClickBotonBorrar();
      if (e == Botones.Imprimir && this.atrToolBarButtons.Imprimir)
        this.ClickBotonImprimir();
      if (e == Botones.Ejecutar && this.atrToolBarButtons.Ejecutar)
        this.ClickBotonEjecutar();
      if (e != Botones.Configurar || !this.atrToolBarButtons.Herramientas)
        return;
      this.ClickBotonConfigurar();
    }

    private void EnciendeBotonesBase()
    {
    }

    public void ActivaConfiguracionBotones()
    {
      if (this.atrToolBarButtons == null)
        return;
      this.EnciendeBotonesBase();
    }

    public void PierdeFoco(EventArgs e)
    {
      this.OnLostFocus(e);
    }

    public void AgarraFoco(EventArgs e)
    {
      this.OnGotFocus(e);
    }

    private void InicializaVariables()
    {
      this.bExistenCambios = false;
      this.bValidarCambios = false;
      this.bEventosAgregados = false;
    }

    public virtual void EventoTextChanged_SelectedIndexChanged_CheckedChanged_DataRowChagedDeleted_Agregar(Control.ControlCollection coleccion, EventHandler delegado)
    {
      if (coleccion == null)
        return;
      foreach (Control control in (ArrangedElementCollection) coleccion)
      {
        this.EventoTextChanged_SelectedIndexChanged_CheckedChanged_DataRowChagedDeleted_Agregar(control.Controls, delegado);
        if (control.GetType() == typeof (CheckBox))
          ((CheckBox) control).CheckedChanged += delegado;
        if (control.GetType() == typeof (RadioButton))
          ((RadioButton) control).CheckedChanged += delegado;
        if (control.GetType() == typeof (ComboBox))
          ((ComboBox) control).SelectedIndexChanged += delegado;
        control.TextChanged += delegado;
      }
    }

    public virtual void EventoTextChanged_SelectedIndexChanged_CheckedChanged_DataRowChagedDeleted_Remover(Control.ControlCollection coleccion, EventHandler delegado)
    {
      if (coleccion == null)
        return;
      foreach (Control control in (ArrangedElementCollection) coleccion)
      {
        this.EventoTextChanged_SelectedIndexChanged_CheckedChanged_DataRowChagedDeleted_Remover(control.Controls, delegado);
        if (control.GetType() == typeof (CheckBox))
          ((CheckBox) control).CheckedChanged -= delegado;
        if (control.GetType() == typeof (RadioButton))
          ((RadioButton) control).CheckedChanged -= delegado;
        if (control.GetType() == typeof (ComboBox))
          ((ComboBox) control).SelectedIndexChanged -= delegado;
        control.TextChanged -= delegado;
      }
    }

    private void ControlesTextChanged(object sender, EventArgs e)
    {
      this.bExistenCambios = true;
    }

    internal virtual void Inicializa(AccMain Menu)
    {
      this.atrFormPadre = Menu;
      this.atrToolBarButtons = new ClsToolbarClassMannager(this.atrFormPadre.ATBManager);
      this.atrFormPadre.ATBManager.ToolbarButton_Click += new Toolbar.ToolbarButton_ClickEventHandler(this.ATBManager_ToolbarButton_Click);
      this.toolTip.SetToolTip((Control) this.lblToolTip, this.Name);
    }

    public virtual void LimpiaForma(TabControl contenedor)
    {
      foreach (Control control in contenedor.TabPages)
        this.LimpiaControl(control);
    }

    public virtual void LimpiaForma(TabPage contenedor)
    {
      this.LimpiaContenedor((Control) contenedor);
    }

    public virtual void LimpiaForma(Form contenedor)
    {
      this.LimpiaContenedor((Control) contenedor);
    }

    public virtual void LimpiaForma(AccessForm contenedor)
    {
      this.LimpiaContenedor((Control) contenedor);
    }

    public virtual void LimpiaForma(GroupBox contenedor)
    {
      this.LimpiaContenedor((Control) contenedor);
    }

    public virtual void LimpiaForma(CheckedListBox contenedor)
    {
      for (int index = 0; index < contenedor.Items.Count; ++index)
        contenedor.SetItemChecked(index, false);
    }

    public virtual void LimpiaForma()
    {
      this.LimpiaForma(this);
      this.bExistenCambios = false;
    }

    public virtual void LimpiaContenedor(Control contenedor)
    {
      foreach (Control control in (ArrangedElementCollection) contenedor.Controls)
        this.LimpiaControl(control);
    }

    public virtual void LimpiaControl(Control control)
    {
      DataAccessCls dataAccessCls = DataAccessCls.DevuelveInstancia();
      if (control.GetType() == typeof (GroupBox))
        this.LimpiaForma((GroupBox) control);
      if (control.GetType() == typeof (TabControl))
        this.LimpiaForma((TabControl) control);
      if (control.GetType() == typeof (ComboBox) || control.GetType() == typeof (TextBox) || control.GetType() == typeof (AccTextBoxAdvanced))
        control.Text = "";
      if (control.GetType() == typeof (AccTextBoxAdvanced))
        ((AccTextBoxAdvanced) control).SetTextBoxValue("");
      if (control.GetType() == typeof (CheckBox))
        ((CheckBox) control).Checked = false;
      if (control.GetType() == typeof (RadioButton))
        ((RadioButton) control).Checked = false;
      if (control.GetType() == typeof (DateTimePicker))
        ((DateTimePicker) control).Value = dataAccessCls.RegresaFechaDelSistema();
      if (control.GetType() != typeof (CheckedListBox))
        return;
      this.LimpiaForma((CheckedListBox) control);
    }

    private void AccessForm_Load(object sender, EventArgs e)
    {
      int num = this.IsMdiChild ? 1 : 0;
    }
  }
}
