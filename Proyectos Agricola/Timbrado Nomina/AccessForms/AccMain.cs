// Type: Sistema.AccMain
// Assembly: AccessForms, Version=1.0.4545.30908, Culture=neutral, PublicKeyToken=null
// MVID: 5901ABF0-835C-413E-A9D3-42261792F241
// Assembly location: C:\Users\abrahamm\Documents\Visual Studio 2012\Projects2\Facturacion\Timbrado Nomina\TimbradoNomina\bin\Debug\AccessForms.dll

using ControlesUsuario;
using DevExpress.XtraBars.Docking;
using Ini;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Sistema
{
  public class AccMain : Form
  {
    private const int tiempoEsperaSegundosBloqueoAplicacion_Base = 60;
    internal const string TituloMsgBox = "Sistema De Facturación Electrónica";
    private IniFileController archivoIni;
    internal ToolStrip AccToolBar;
    internal Toolbar ATBManager;
    internal DockManager DCKManager;
    internal StatusBarPanel statEstado;
    internal StatusBarPanel statServidor;
    internal StatusBarPanel statBaseDatos;
    internal StatusBarPanel statUsuario;
    internal StatusBarPanel statFecha;
    internal StatusBarPanel statHora;
    internal StatusBar statusBar;
    private Timer Timer;
    internal ImageList ILIconosNavegador;
    private int tiempoEsperaSegundosBloqueoAplicacion;
    private int segundosFaltantesParaBloqueoAplicacion;
    private Bloqueo bloqueoPantalla;
    public bool bloqueoPantallaActivo;
    public StatusBarPanel statPlaza;
    public StatusBarPanel statSucursal;
    public StatusBarPanel statAlmacen;
    public StatusBarPanel statVersion;
    public StatusBarPanel statusTipoArticulo;
    private IContainer components;
    private Bitmap bitImagen;
    private Icon bitIcon;
    private DateTime atrFecha;
    private string atrContextoPrimario;
    private string atrNombreCustomMenu;
    private AccessForm atrFormaAnterior;
    private static AccMain atrMenuPrincipal;
    protected DataAccessCls DAO;

    public int TiempoEsperaBloqueo
    {
      get
      {
        return this.tiempoEsperaSegundosBloqueoAplicacion;
      }
      set
      {
        this.tiempoEsperaSegundosBloqueoAplicacion = value;
      }
    }

    public AccMain()
    {
        try
        {
            this.InitializeComponent();
            this.LoadForm();
            if (!File.Exists("C:/access/bytes.ico"))
                return;
            this.bitIcon = new Icon("C:/access/bytes.ico");
            this.Icon = this.bitIcon;
        }
        catch
        {
        }
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (AccMain));
      this.statusBar = new StatusBar();
      this.statEstado = new StatusBarPanel();
      this.statServidor = new StatusBarPanel();
      this.statBaseDatos = new StatusBarPanel();
      this.statUsuario = new StatusBarPanel();
      this.statFecha = new StatusBarPanel();
      this.statHora = new StatusBarPanel();
      this.statPlaza = new StatusBarPanel();
      this.statSucursal = new StatusBarPanel();
      this.statAlmacen = new StatusBarPanel();
      this.statVersion = new StatusBarPanel();
      this.statusTipoArticulo = new StatusBarPanel();
      this.Timer = new Timer(this.components);
      this.ILIconosNavegador = new ImageList(this.components);
      this.ATBManager = new Toolbar();
      this.statEstado.BeginInit();
      this.statServidor.BeginInit();
      this.statBaseDatos.BeginInit();
      this.statUsuario.BeginInit();
      this.statFecha.BeginInit();
      this.statHora.BeginInit();
      this.statPlaza.BeginInit();
      this.statSucursal.BeginInit();
      this.statAlmacen.BeginInit();
      this.statVersion.BeginInit();
      this.statusTipoArticulo.BeginInit();
      this.SuspendLayout();
      this.statusBar.Location = new Point(0, 439);
      this.statusBar.Name = "statusBar";
      this.statusBar.Panels.AddRange(new StatusBarPanel[11]
      {
        this.statEstado,
        this.statServidor,
        this.statBaseDatos,
        this.statUsuario,
        this.statFecha,
        this.statHora,
        this.statPlaza,
        this.statSucursal,
        this.statAlmacen,
        this.statVersion,
        this.statusTipoArticulo
      });
      this.statusBar.ShowPanels = true;
      this.statusBar.Size = new Size(718, 21);
      this.statusBar.TabIndex = 4;
      this.statusBar.Text = " BarraStatus";
      this.statEstado.AutoSize = StatusBarPanelAutoSize.Spring;
      this.statEstado.Name = "statEstado";
      this.statEstado.Width = 128;
      this.statServidor.AutoSize = StatusBarPanelAutoSize.Contents;
      this.statServidor.Icon = (Icon) componentResourceManager.GetObject("statServidor.Icon");
      this.statServidor.Name = "statServidor";
      this.statServidor.Text = "Servidor";
      this.statServidor.Width = 77;
      this.statBaseDatos.AutoSize = StatusBarPanelAutoSize.Contents;
      this.statBaseDatos.Icon = (Icon) componentResourceManager.GetObject("statBaseDatos.Icon");
      this.statBaseDatos.Name = "statBaseDatos";
      this.statBaseDatos.Text = "Base De Datos";
      this.statBaseDatos.Width = 111;
      this.statUsuario.AutoSize = StatusBarPanelAutoSize.Contents;
      this.statUsuario.Icon = (Icon) componentResourceManager.GetObject("statUsuario.Icon");
      this.statUsuario.Name = "statUsuario";
      this.statUsuario.Text = "Usuario";
      this.statUsuario.Width = 74;
      this.statFecha.AutoSize = StatusBarPanelAutoSize.Contents;
      this.statFecha.Icon = (Icon) componentResourceManager.GetObject("statFecha.Icon");
      this.statFecha.Name = "statFecha";
      this.statFecha.Text = "Fecha Servidor";
      this.statFecha.Width = 112;
      this.statHora.AutoSize = StatusBarPanelAutoSize.Contents;
      this.statHora.Icon = (Icon) componentResourceManager.GetObject("statHora.Icon");
      this.statHora.Name = "statHora";
      this.statHora.Text = "Hora";
      this.statHora.Width = 60;
      this.statPlaza.AutoSize = StatusBarPanelAutoSize.Contents;
      this.statPlaza.Name = "statPlaza";
      this.statPlaza.Width = 10;
      this.statSucursal.AutoSize = StatusBarPanelAutoSize.Contents;
      this.statSucursal.Name = "statSucursal";
      this.statSucursal.Width = 10;
      this.statAlmacen.AutoSize = StatusBarPanelAutoSize.Contents;
      this.statAlmacen.Name = "statAlmacen";
      this.statAlmacen.Width = 10;
      this.statVersion.AutoSize = StatusBarPanelAutoSize.Contents;
      this.statVersion.Name = "statVersion";
      this.statVersion.Width = 10;
      this.statusTipoArticulo.Name = "statusTipoArticulo";
      this.ILIconosNavegador.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("ILIconosNavegador.ImageStream");
      this.ILIconosNavegador.TransparentColor = Color.Transparent;
      this.ILIconosNavegador.Images.SetKeyName(0, "");
      this.ILIconosNavegador.Images.SetKeyName(1, "");
      this.ILIconosNavegador.Images.SetKeyName(2, "");
      this.ILIconosNavegador.Images.SetKeyName(3, "");
      this.ILIconosNavegador.Images.SetKeyName(4, "");
      this.ILIconosNavegador.Images.SetKeyName(5, "");
      this.ILIconosNavegador.Images.SetKeyName(6, "");
      this.ILIconosNavegador.Images.SetKeyName(7, "");
      this.ILIconosNavegador.Images.SetKeyName(8, "");
      this.ILIconosNavegador.Images.SetKeyName(9, "");
      this.ILIconosNavegador.Images.SetKeyName(10, "");
      this.ILIconosNavegador.Images.SetKeyName(11, "");
      this.ILIconosNavegador.Images.SetKeyName(12, "");
      this.ILIconosNavegador.Images.SetKeyName(13, "");
      this.ILIconosNavegador.Images.SetKeyName(14, "");
      this.ILIconosNavegador.Images.SetKeyName(15, "");
      this.ILIconosNavegador.Images.SetKeyName(16, "");
      this.ILIconosNavegador.Images.SetKeyName(17, "");
      this.ILIconosNavegador.Images.SetKeyName(18, "");
      this.ILIconosNavegador.Images.SetKeyName(19, "");
      this.ILIconosNavegador.Images.SetKeyName(20, "");
      this.ILIconosNavegador.Images.SetKeyName(21, "");
      this.ILIconosNavegador.Images.SetKeyName(22, "");
      this.ILIconosNavegador.Images.SetKeyName(23, "");
      this.ILIconosNavegador.Images.SetKeyName(24, "");
      this.ILIconosNavegador.Images.SetKeyName(25, "");
      this.ILIconosNavegador.Images.SetKeyName(26, "");
      this.ILIconosNavegador.Images.SetKeyName(27, "");
      this.ILIconosNavegador.Images.SetKeyName(28, "");
      this.ILIconosNavegador.Images.SetKeyName(29, "");
      this.ILIconosNavegador.Images.SetKeyName(30, "");
      this.ATBManager.BackColor = Color.SteelBlue;
      this.ATBManager.Configurar = false;
      this.ATBManager.Dock = DockStyle.Top;
      this.ATBManager.Ejecutar = false;
      this.ATBManager.Eliminar = false;
      this.ATBManager.Guardar = false;
      this.ATBManager.Imprimir = false;
      this.ATBManager.Location = new Point(0, 0);
      this.ATBManager.Name = "ATBManager";
      this.ATBManager.Nuevo = false;
      this.ATBManager.Padding = new Padding(0, 1, 0, 0);
      this.ATBManager.Size = new Size(718, 72);
      this.ATBManager.TabIndex = 8;
      this.ATBManager.Load += new EventHandler(this.toolbar1_Load);
      this.AutoScaleBaseSize = new Size(5, 13);
      this.BackColor = SystemColors.AppWorkspace;
      this.BackgroundImage = (Image) componentResourceManager.GetObject("$this.BackgroundImage");
      this.BackgroundImageLayout = ImageLayout.Stretch;
      this.ClientSize = new Size(718, 460);
      this.Controls.Add((Control) this.ATBManager);
      this.Controls.Add((Control) this.statusBar);
      this.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.IsMdiContainer = true;
      this.KeyPreview = true;
      this.Name = "AccMain";
      this.StartPosition = FormStartPosition.Manual;
      this.Text = "   AccMain";
      this.WindowState = FormWindowState.Maximized;
      this.Load += new EventHandler(this.CustomMenuForm_Load);
      this.statEstado.EndInit();
      this.statServidor.EndInit();
      this.statBaseDatos.EndInit();
      this.statUsuario.EndInit();
      this.statFecha.EndInit();
      this.statHora.EndInit();
      this.statPlaza.EndInit();
      this.statSucursal.EndInit();
      this.statAlmacen.EndInit();
      this.statVersion.EndInit();
      this.statusTipoArticulo.EndInit();
      this.ResumeLayout(false);
    }

    protected virtual void LoadForm()
    {
      this.DAO = DataAccessCls.DevuelveInstancia();
      if (this.DAO == null)
        return;
      this.ConfiguraParametrosBloqueo();
      this.ConfiguraEstatusInicial();
      this.ConfiguraToolBar();
      AccMain.atrMenuPrincipal = this;
    }

    public void GetConfiguracionBloqueoTerminal()
    {
      this.bloqueoPantallaActivo = false;
      if (((object) this.archivoIni.GetEntry("BLOQUEO_INACTIVIDAD")).ToString().Trim() != "")
      {
        try
        {
          if (((object) this.archivoIni.GetEntry("BLOQUEO_INACTIVIDAD")).ToString().Trim() == "SI")
            this.bloqueoPantallaActivo = true;
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show("Error al tomar parámetro de terminal(Bloqueo inactividad)", "Sistema De Facturación Electrónica", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          return;
        }
      }
      if (((object) this.archivoIni.GetEntry("TIEMPO_INACTIVIDAD")).ToString().Trim() != "")
      {
        try
        {
          this.tiempoEsperaSegundosBloqueoAplicacion = int.Parse(this.archivoIni.GetEntry("TIEMPO_INACTIVIDAD"));
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show("Error al tomar parámetro de terminal(tiempo de espera)", "Sistema De Facturación Electrónica", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          return;
        }
      }
      this.ReiniciaContadorBloqueo();
    }

    private void ConfiguraParametrosBloqueo()
    {
      this.archivoIni = new IniFileController();
      this.archivoIni.OpenINIFile(this.DAO.GetRutaArchivoIni());
      this.GetConfiguracionBloqueoTerminal();
    }

    public static AccMain GetMainMenu()
    {
      return AccMain.atrMenuPrincipal;
    }

    private void EjecutaBloqueo()
    {
      if (this.segundosFaltantesParaBloqueoAplicacion > 0 || this.bloqueoPantalla != null)
        return;
      this.DoBloqueo();
    }

    private void DoBloqueo()
    {
      this.bloqueoPantalla = new Bloqueo();
      int num = (int) this.bloqueoPantalla.ShowDialog((IWin32Window) this);
      this.bloqueoPantalla.Dispose();
      this.bloqueoPantalla = (Bloqueo) null;
      this.ReiniciaContadorBloqueo();
    }

    public void ReiniciaContadorBloqueo()
    {
      this.segundosFaltantesParaBloqueoAplicacion = this.tiempoEsperaSegundosBloqueoAplicacion;
    }

    public void Elements_MouseMove(object sender, MouseEventArgs e)
    {
      this.ReiniciaContadorBloqueo();
    }

    protected override void OnGotFocus(EventArgs e)
    {
      this.ReiniciaContadorBloqueo();
        base.OnGotFocus(e);
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
      this.ReiniciaContadorBloqueo();
      if (e.Control && e.KeyCode == Keys.N && (e.Control && e.Alt) && e.KeyCode == Keys.Space)
      {
        this.segundosFaltantesParaBloqueoAplicacion = 0;
        this.EjecutaBloqueo();
      }
      base.OnKeyDown(e);
    }

    public void RefrescaNombreFormaActiva(EventArgs e)
    {
      string str = "";
      if (this.Text.IndexOf("[") < 0)
        this.atrNombreCustomMenu = this.Text;
      this.Text = this.atrNombreCustomMenu + str;
    }

    private void XTBManager_SelectedPageChanged(object sender, EventArgs e)
    {
      this.RefrescaNombreFormaActiva(e);
    }

    private void ConfiguraToolBar()
    {
      this.ATBManager.ToolbarButton_Click += new Toolbar.ToolbarButton_ClickEventHandler(this.ATBManager_ToolbarButton_Click);
    }

    private void ATBManager_ToolbarButton_Click(object sender, Botones e)
    {
      if (e != Botones.Configurar)
        return;
      ArrayList arrayList = new ArrayList();
      foreach (DockPanel dockPanel in (CollectionBase) this.DCKManager.HiddenPanels)
        arrayList.Add((object) dockPanel);
      foreach (DockPanel dockPanel in arrayList.ToArray(typeof (DockPanel)))
      {
        dockPanel.Visibility = DockVisibility.AutoHide;
        dockPanel.HideImmediately();
      }
    }

    public virtual void EliminaImg()
    {
      if (this.ILIconosNavegador.Images.Count <= 0)
        return;
      this.ILIconosNavegador.Images.RemoveAt(0);
      this.EliminaImg();
    }

    public virtual void CargaIconoPrincipal(string prmrutaIconoPrincipal)
    {
      object[] objArray = new object[30];
      int num = 0;
      int index1 = 0;
      foreach (Image image in this.ILIconosNavegador.Images)
      {
        if (num != 0)
        {
          objArray.SetValue((object) image, index1);
          ++index1;
        }
        ++num;
      }
      this.EliminaImg();
      this.ILIconosNavegador.Images.Add(Image.FromFile(prmrutaIconoPrincipal));
      foreach (Image image in objArray)
        this.ILIconosNavegador.Images.Add(image);
      int index2 = 0;
      for (int index3 = 0; index3 < this.ILIconosNavegador.Images.Count - 1; ++index3)
      {
        this.ILIconosNavegador.Images.SetKeyName(index2, "");
        ++index2;
      }
    }

    public virtual void MensajeEstado()
    {
      this.MensajeEstado("");
    }

    public virtual void MensajeEstado(string sEstado)
    {
      if (sEstado == "")
      {
        this.statEstado.Text = " Listo ";
        Cursor.Current = Cursors.Default;
      }
      else
      {
        this.statEstado.Text = sEstado;
        Cursor.Current = Cursors.WaitCursor;
      }
    }

    private bool ActivaForma(AccessForm CicloForm)
    {
      foreach (AccessForm accessForm in this.MdiChildren)
      {
        if (accessForm.GetType() == CicloForm.GetType())
        {
          accessForm.Activate();
          return true;
        }
      }
      return false;
    }

    public void CargarForma(AccessForm miForma)
    {
      if (!miForma.ValidacionShow())
        return;
      miForma.MdiParent = (Form) this;
      miForma.Inicializa(this);
      ((Control) miForma).Show();
    }

    private void ReNombraTablas(DataSet dsDatos)
    {
      dsDatos.Tables[0].TableName = "ADSUM_Usuarios";
      dsDatos.Tables[1].TableName = "ADSUM_Contextos";
      dsDatos.Tables[2].TableName = "ADSUM_Navegador";
      dsDatos.Tables[3].TableName = "ADSUM_Formas";
      dsDatos.Tables[4].TableName = "Adsum_Usuarios_X_Perfil";
      dsDatos.Tables[5].TableName = "Adsum_Perfiles";
      dsDatos.Tables[6].TableName = "ADSUM_Derechos_X_Perfil";
    }

    private void ConfiguraEstatusInicial()
    {
      this.atrFecha = this.DAO.RegresaFechaDelSistema();
      this.statServidor.Text = this.DAO.GetNombreServidor();
      this.statUsuario.Text = this.DAO.GetLoginUsuario();
      this.statBaseDatos.Text = this.DAO.GetNombreBaseDeDatos();
      this.statFecha.Text = this.atrFecha.ToShortDateString();
      this.statHora.Text = this.atrFecha.ToShortTimeString();
      this.Timer.Tick += new EventHandler(this.Timer_Tick);
      this.Timer.Interval = 1000;
      this.Timer.Enabled = true;
      this.Timer.Start();
      this.MensajeEstado();
      Application.DoEvents();
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
      this.atrFecha = this.atrFecha.AddMilliseconds(1000.0);
      this.statHora.Text = this.atrFecha.ToShortTimeString();
      if (this.bloqueoPantallaActivo)
        this.EjecutaBloqueo();
      --this.segundosFaltantesParaBloqueoAplicacion;
    }

    private void CreaArquitectura()
    {
      StringBuilder stringBuilder = new StringBuilder();
      if (!this.DAO.ExistenDatosEnConsultaSQL("SELECT 1 FROM SYSOBJECTS(NOLOCK) WHERE NAME = 'ADSUM_CargaNavegador' AND xType = 'P'"))
      {
        stringBuilder.Append("\t\tCREATE PROC\t\tADSUM_CargaNavegador\t(\t @cLogin\t\t\tVARCHAR(100)");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\t\t\t\t\t\t\t\t\t\t\t\t,@cContextos\t\tVARCHAR(1000)");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\t\t\t\t\t\t\t\t\t\t\t) AS");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\t/******************************************************************");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\tSistema\t\t\t:");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\tMódulo\t\t\t:Arquitectura");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\tProcedimiento\t:ADSUM_CargaNavegador");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\tFecha\t\t\t:31 de Julio del 2007");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\tDesarrolló\t\t:Lic. David Adan Velazquez Sanchez");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\tQue Hace?\t\t:Obtiene una serie de tablas para la carga del navegador");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\tParametros\t\t:@cLogin.- Login el cual accesa a la aplicacion");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\t\t\t\t\t @cContextos.- Contextos separados por coma que se cargaran");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\t\t\t\t\t\tEj. 'M01,M02'");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\tRegresa\t\t\t:La sig serie de consultas:");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\t\t\t\t\t1)Usuarios");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\t\t\t\t\t2)Contextos");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\t\t\t\t\t3)Navegador");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\t\t\t\t\t4)Formas");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\t\t\t\t\t5)Perfiles a los que pertenece el usuario");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\t\t\t\t\t6)Perfiles");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\t\t\t\t\t7)Derechos por perfil");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\t*******************************************************************/");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\tSET NOCOUNT ON");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\tDECLARE @nIcon\tSMALLINT");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\t--Insertamos el parametro administrado del icono en construccion");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\tIF NOT EXISTS (SELECT 1 FROM ADSUM_ParametrosAdministrados(NOLOCK) WHERE cParametroAdministrado = 'ICO_BAJOCONSTRUCCION')");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\t\tINSERT ADSUM_ParametrosAdministrados(cContexto ,cParametroAdministrado ,nTipo ,cDescripcion ,cValor)");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\t\tVALUES ('ARQ' ,'ICO_BAJOCONSTRUCCION' ,1 ,'Indice del Icono que se mostrara en el navegador de elementos bajo construccion' ,29)");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\tSELECT @nIcon = dbo.ADSUM_ParametroAdministrado_Numerico( 'ICO_BAJOCONSTRUCCION' )");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\t--1)Usuarios");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\tSELECT * FROM ADSUM_Usuarios(NOLOCK) WHERE cLogin = @cLogin");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\t--Obtenemos los contexto");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\tSELECT C.* INTO #Contextos FROM ADSUM_Contextos AS C(NOLOCK) ");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\tINNER JOIN dbo.ADSUM_StringEnRows(@cContextos) AS A ON (C.cContexto = A.cValor)");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\t--2)Contextos");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\tSELECT * FROM #Contextos");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\t--Obtenemos el navegador");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\tSELECT N.* INTO #Navegador FROM ADSUM_Navegador AS N(NOLOCK)");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\tINNER JOIN #Contextos AS C ON (N.cContexto = C.cContexto AND N.cEstatus_Rama <> 'C')");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\t--Actualizamos el icono de los elementos con estatus 'B'");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\tUPDATE #Navegador ");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\t\tSET  nIcono_Normal = @nIcon");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\t\t\t,nIcono_Seleccionado = @nIcon");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\t\t\t,nIcono_Expandido = @nIcon");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\tWHERE cEstatus_Rama = 'B'");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\t--3)Navegador");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\tSELECT * FROM #Navegador");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\t--4)Formas");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\tSELECT DISTINCT F.* FROM #Navegador AS N");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\tINNER JOIN ADSUM_Formas AS F(NOLOCK) ON (N.cForma = F.cForma)");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\t--Obtenemos los derechos por perfil");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\tSELECT * INTO #Derechos FROM Adsum_Usuarios_X_Perfil (NOLOCK) WHERE cLogin = @cLogin");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\t--5)Perfiles a los que pertenece el usuario");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\tSELECT * FROM #Derechos");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\t--6)Perfiles");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\tSELECT P.* FROM Adsum_Perfiles AS P(NOLOCK)");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\tINNER JOIN #Derechos AS D ON (P.nPerfil = D.nPerfil)");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\t--7)Derechos por perfil");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\tSELECT DP.* FROM ADSUM_Derechos_X_Perfil AS DP(NOLOCK)");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\tINNER JOIN #Derechos AS D ON (DP.nPerfil = D.nPerfil)");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\tWHERE EXISTS\t(\tSELECT 1 FROM #Navegador AS N");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\t\t\t\t\t\tWHERE DP.nRama = N.nRama");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\t\t\t\t\t)");
        stringBuilder.Append('\r');
        stringBuilder.Append("\t\tSET NOCOUNT OFF");
        stringBuilder.Append('\r');
      }
      string comandoSQL = ((object) stringBuilder).ToString();
      if (comandoSQL == "" || !this.DAO.AbreTransaccion())
        return;
      if (!this.DAO.EjecutaComandoSQL(comandoSQL))
      {
        if (!this.DAO.TieneTransaccionAbierta())
          return;
        this.DAO.DeshaceTransaccion();
      }
      else
        this.DAO.CierraTransaccion();
    }

    private void CustomMenuForm_Load(object sender, EventArgs e)
    {
    }

    public void CambianombreBD(string prmBaseDatos)
    {
      this.statBaseDatos.Text = prmBaseDatos;
    }

    public void HabilitaBotones(bool prmNuevo, bool prmGuardar, bool prmEliminar, bool prmImprimir, bool prmEjecutar, bool prmConfigurar)
    {
      this.ATBManager.Nuevo = prmNuevo;
      this.ATBManager.Guardar = prmGuardar;
      this.ATBManager.Eliminar = prmEliminar;
      this.ATBManager.Imprimir = prmImprimir;
      this.ATBManager.Ejecutar = prmEjecutar;
      this.ATBManager.Configurar = prmConfigurar;
    }

    private void BtnPrinter_Click(object sender, EventArgs e)
    {
    }

    private void toolbar1_Load(object sender, EventArgs e)
    {
    }
  }
}
