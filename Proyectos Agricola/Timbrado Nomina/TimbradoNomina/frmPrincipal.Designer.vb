<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrincipal
    Inherits Sistema.AccMain
    'Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrincipal))
        Me.CatálogosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProductosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.CatálogosToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProductosToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CargarArchivosXMLDesdeCarpetaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DescargarXMLDeInternetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DescargarXMLDeAcuseDeInternetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TrabajadoresSinTimbrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComprobanteDeTimbradoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ParámetrosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GeneralesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AduntarXMLAPólizasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.statPlaza, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.statSucursal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.statAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.statVersion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.statusTipoArticulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'CatálogosToolStripMenuItem
        '
        Me.CatálogosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProductosToolStripMenuItem})
        Me.CatálogosToolStripMenuItem.Name = "CatálogosToolStripMenuItem"
        Me.CatálogosToolStripMenuItem.Size = New System.Drawing.Size(67, 20)
        Me.CatálogosToolStripMenuItem.Text = "Catálogos"
        '
        'ProductosToolStripMenuItem
        '
        Me.ProductosToolStripMenuItem.Name = "ProductosToolStripMenuItem"
        Me.ProductosToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.ProductosToolStripMenuItem.Text = "Productos"
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CatálogosToolStripMenuItem1, Me.ReportesToolStripMenuItem, Me.ParámetrosToolStripMenuItem})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 72)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(794, 24)
        Me.MenuStrip2.TabIndex = 10
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'CatálogosToolStripMenuItem1
        '
        Me.CatálogosToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProductosToolStripMenuItem1, Me.CargarArchivosXMLDesdeCarpetaToolStripMenuItem, Me.DescargarXMLDeInternetToolStripMenuItem, Me.DescargarXMLDeAcuseDeInternetToolStripMenuItem, Me.AduntarXMLAPólizasToolStripMenuItem})
        Me.CatálogosToolStripMenuItem1.Name = "CatálogosToolStripMenuItem1"
        Me.CatálogosToolStripMenuItem1.Size = New System.Drawing.Size(66, 20)
        Me.CatálogosToolStripMenuItem1.Text = "&Procesos"
        '
        'ProductosToolStripMenuItem1
        '
        Me.ProductosToolStripMenuItem1.Name = "ProductosToolStripMenuItem1"
        Me.ProductosToolStripMenuItem1.Size = New System.Drawing.Size(284, 22)
        Me.ProductosToolStripMenuItem1.Text = "&Timbrado / Cancelación timbres"
        '
        'CargarArchivosXMLDesdeCarpetaToolStripMenuItem
        '
        Me.CargarArchivosXMLDesdeCarpetaToolStripMenuItem.Name = "CargarArchivosXMLDesdeCarpetaToolStripMenuItem"
        Me.CargarArchivosXMLDesdeCarpetaToolStripMenuItem.Size = New System.Drawing.Size(284, 22)
        Me.CargarArchivosXMLDesdeCarpetaToolStripMenuItem.Text = "Cargar archivos XML desde carpeta"
        '
        'DescargarXMLDeInternetToolStripMenuItem
        '
        Me.DescargarXMLDeInternetToolStripMenuItem.Name = "DescargarXMLDeInternetToolStripMenuItem"
        Me.DescargarXMLDeInternetToolStripMenuItem.Size = New System.Drawing.Size(284, 22)
        Me.DescargarXMLDeInternetToolStripMenuItem.Text = "Descargar XML de Timbrado de Internet"
        '
        'DescargarXMLDeAcuseDeInternetToolStripMenuItem
        '
        Me.DescargarXMLDeAcuseDeInternetToolStripMenuItem.Name = "DescargarXMLDeAcuseDeInternetToolStripMenuItem"
        Me.DescargarXMLDeAcuseDeInternetToolStripMenuItem.Size = New System.Drawing.Size(284, 22)
        Me.DescargarXMLDeAcuseDeInternetToolStripMenuItem.Text = "Descargar XML de Acuse de internet"
        '
        'ReportesToolStripMenuItem
        '
        Me.ReportesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TrabajadoresSinTimbrarToolStripMenuItem, Me.ComprobanteDeTimbradoToolStripMenuItem})
        Me.ReportesToolStripMenuItem.Name = "ReportesToolStripMenuItem"
        Me.ReportesToolStripMenuItem.Size = New System.Drawing.Size(65, 20)
        Me.ReportesToolStripMenuItem.Text = "Reportes"
        '
        'TrabajadoresSinTimbrarToolStripMenuItem
        '
        Me.TrabajadoresSinTimbrarToolStripMenuItem.Name = "TrabajadoresSinTimbrarToolStripMenuItem"
        Me.TrabajadoresSinTimbrarToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.TrabajadoresSinTimbrarToolStripMenuItem.Text = "Trabajadores sin Timbrar"
        '
        'ComprobanteDeTimbradoToolStripMenuItem
        '
        Me.ComprobanteDeTimbradoToolStripMenuItem.Name = "ComprobanteDeTimbradoToolStripMenuItem"
        Me.ComprobanteDeTimbradoToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.ComprobanteDeTimbradoToolStripMenuItem.Text = "Comprobante de timbrado"
        '
        'ParámetrosToolStripMenuItem
        '
        Me.ParámetrosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GeneralesToolStripMenuItem})
        Me.ParámetrosToolStripMenuItem.Name = "ParámetrosToolStripMenuItem"
        Me.ParámetrosToolStripMenuItem.Size = New System.Drawing.Size(79, 20)
        Me.ParámetrosToolStripMenuItem.Text = "&Parámetros"
        '
        'GeneralesToolStripMenuItem
        '
        Me.GeneralesToolStripMenuItem.Name = "GeneralesToolStripMenuItem"
        Me.GeneralesToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
        Me.GeneralesToolStripMenuItem.Text = "&Generales"
        '
        'AduntarXMLAPólizasToolStripMenuItem
        '
        Me.AduntarXMLAPólizasToolStripMenuItem.Name = "AduntarXMLAPólizasToolStripMenuItem"
        Me.AduntarXMLAPólizasToolStripMenuItem.Size = New System.Drawing.Size(284, 22)
        Me.AduntarXMLAPólizasToolStripMenuItem.Text = "Aduntar XML a Pólizas"
        '
        'frmPrincipal
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(794, 575)
        Me.Controls.Add(Me.MenuStrip2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip2
        Me.Name = "frmPrincipal"
        Me.Text = ""
        Me.Controls.SetChildIndex(Me.MenuStrip2, 0)
        CType(Me.statPlaza, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.statSucursal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.statAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.statVersion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.statusTipoArticulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents CatálogosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProductosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents MenuStrip2 As System.Windows.Forms.MenuStrip
    Friend WithEvents CatálogosToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProductosToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ParámetrosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GeneralesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TrabajadoresSinTimbrarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ComprobanteDeTimbradoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CargarArchivosXMLDesdeCarpetaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DescargarXMLDeInternetToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DescargarXMLDeAcuseDeInternetToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AduntarXMLAPólizasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
