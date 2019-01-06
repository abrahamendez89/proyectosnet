<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DescargarXMLDeInternet
    Inherits Sistema.AccessForm

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
        Me.cmb_temporadas = New System.Windows.Forms.ComboBox()
        Me.btn_consultar = New System.Windows.Forms.Button()
        Me.cmb_nomina = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_semana = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgv_resultados = New System.Windows.Forms.DataGridView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_correctos = New System.Windows.Forms.TextBox()
        Me.txt_sinDescargar = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_sinTimbrar = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btn_descargar = New System.Windows.Forms.Button()
        Me.CLAVE_FACTURA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMPORTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CLAVE_EMPLEADO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOMBRE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ESTATUS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UUID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.XML = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RFC_EMISOR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RFC_RECEPTOR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TEMPORADA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOMINA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SEMANA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHA_TIMBRADO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgv_resultados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblToolTip
        '
        Me.lblToolTip.Size = New System.Drawing.Size(19, 25)
        '
        'cmb_temporadas
        '
        Me.cmb_temporadas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_temporadas.FormattingEnabled = True
        Me.cmb_temporadas.Location = New System.Drawing.Point(84, 12)
        Me.cmb_temporadas.Name = "cmb_temporadas"
        Me.cmb_temporadas.Size = New System.Drawing.Size(127, 22)
        Me.cmb_temporadas.TabIndex = 16
        '
        'btn_consultar
        '
        Me.btn_consultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_consultar.Location = New System.Drawing.Point(741, 9)
        Me.btn_consultar.Name = "btn_consultar"
        Me.btn_consultar.Size = New System.Drawing.Size(98, 25)
        Me.btn_consultar.TabIndex = 15
        Me.btn_consultar.Text = "Consultar"
        Me.btn_consultar.UseVisualStyleBackColor = True
        '
        'cmb_nomina
        '
        Me.cmb_nomina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_nomina.FormattingEnabled = True
        Me.cmb_nomina.Items.AddRange(New Object() {"Natura Culiacán", "Natura Imuris", "Tecnica Culiacán", "Tecnica Imuris"})
        Me.cmb_nomina.Location = New System.Drawing.Point(431, 11)
        Me.cmb_nomina.Name = "cmb_nomina"
        Me.cmb_nomina.Size = New System.Drawing.Size(261, 22)
        Me.cmb_nomina.TabIndex = 14
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(370, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 14)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Nómina:"
        '
        'txt_semana
        '
        Me.txt_semana.Location = New System.Drawing.Point(282, 11)
        Me.txt_semana.Name = "txt_semana"
        Me.txt_semana.Size = New System.Drawing.Size(81, 22)
        Me.txt_semana.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(217, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 14)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Semana:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 14)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Temporada:"
        '
        'dgv_resultados
        '
        Me.dgv_resultados.AllowUserToAddRows = False
        Me.dgv_resultados.AllowUserToDeleteRows = False
        Me.dgv_resultados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_resultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_resultados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CLAVE_FACTURA, Me.IMPORTE, Me.CLAVE_EMPLEADO, Me.NOMBRE, Me.ESTATUS, Me.UUID, Me.XML, Me.RFC_EMISOR, Me.RFC_RECEPTOR, Me.TEMPORADA, Me.NOMINA, Me.SEMANA, Me.FECHA_TIMBRADO})
        Me.dgv_resultados.Location = New System.Drawing.Point(12, 50)
        Me.dgv_resultados.Name = "dgv_resultados"
        Me.dgv_resultados.ReadOnly = True
        Me.dgv_resultados.Size = New System.Drawing.Size(827, 270)
        Me.dgv_resultados.TabIndex = 17
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 328)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 14)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Correctos:"
        '
        'txt_correctos
        '
        Me.txt_correctos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_correctos.Location = New System.Drawing.Point(81, 325)
        Me.txt_correctos.Name = "txt_correctos"
        Me.txt_correctos.ReadOnly = True
        Me.txt_correctos.Size = New System.Drawing.Size(44, 22)
        Me.txt_correctos.TabIndex = 19
        '
        'txt_sinDescargar
        '
        Me.txt_sinDescargar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_sinDescargar.Location = New System.Drawing.Point(240, 325)
        Me.txt_sinDescargar.Name = "txt_sinDescargar"
        Me.txt_sinDescargar.ReadOnly = True
        Me.txt_sinDescargar.Size = New System.Drawing.Size(44, 22)
        Me.txt_sinDescargar.TabIndex = 21
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(131, 328)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(107, 14)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "XML sin descargar:"
        '
        'txt_sinTimbrar
        '
        Me.txt_sinTimbrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_sinTimbrar.Location = New System.Drawing.Point(359, 325)
        Me.txt_sinTimbrar.Name = "txt_sinTimbrar"
        Me.txt_sinTimbrar.ReadOnly = True
        Me.txt_sinTimbrar.Size = New System.Drawing.Size(44, 22)
        Me.txt_sinTimbrar.TabIndex = 23
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(290, 328)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 14)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "Sin timbrar:"
        '
        'btn_descargar
        '
        Me.btn_descargar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_descargar.Location = New System.Drawing.Point(678, 328)
        Me.btn_descargar.Name = "btn_descargar"
        Me.btn_descargar.Size = New System.Drawing.Size(161, 23)
        Me.btn_descargar.TabIndex = 24
        Me.btn_descargar.Text = "Descargar faltantes"
        Me.btn_descargar.UseVisualStyleBackColor = True
        '
        'CLAVE_FACTURA
        '
        Me.CLAVE_FACTURA.HeaderText = "CLAVE FACTURA"
        Me.CLAVE_FACTURA.Name = "CLAVE_FACTURA"
        Me.CLAVE_FACTURA.ReadOnly = True
        Me.CLAVE_FACTURA.Width = 180
        '
        'IMPORTE
        '
        Me.IMPORTE.HeaderText = "IMPORTE"
        Me.IMPORTE.Name = "IMPORTE"
        Me.IMPORTE.ReadOnly = True
        '
        'CLAVE_EMPLEADO
        '
        Me.CLAVE_EMPLEADO.HeaderText = "CLAVE EMPLEADO"
        Me.CLAVE_EMPLEADO.Name = "CLAVE_EMPLEADO"
        Me.CLAVE_EMPLEADO.ReadOnly = True
        '
        'NOMBRE
        '
        Me.NOMBRE.HeaderText = "NOMBRE"
        Me.NOMBRE.Name = "NOMBRE"
        Me.NOMBRE.ReadOnly = True
        Me.NOMBRE.Width = 300
        '
        'ESTATUS
        '
        Me.ESTATUS.HeaderText = "ESTATUS"
        Me.ESTATUS.Name = "ESTATUS"
        Me.ESTATUS.ReadOnly = True
        Me.ESTATUS.Width = 230
        '
        'UUID
        '
        Me.UUID.HeaderText = "UUID"
        Me.UUID.Name = "UUID"
        Me.UUID.ReadOnly = True
        '
        'XML
        '
        Me.XML.HeaderText = "XML"
        Me.XML.Name = "XML"
        Me.XML.ReadOnly = True
        Me.XML.Width = 300
        '
        'RFC_EMISOR
        '
        Me.RFC_EMISOR.HeaderText = "RFC EMISOR"
        Me.RFC_EMISOR.Name = "RFC_EMISOR"
        Me.RFC_EMISOR.ReadOnly = True
        '
        'RFC_RECEPTOR
        '
        Me.RFC_RECEPTOR.HeaderText = "RFC RECEPTOR"
        Me.RFC_RECEPTOR.Name = "RFC_RECEPTOR"
        Me.RFC_RECEPTOR.ReadOnly = True
        '
        'TEMPORADA
        '
        Me.TEMPORADA.HeaderText = "TEMPORADA"
        Me.TEMPORADA.Name = "TEMPORADA"
        Me.TEMPORADA.ReadOnly = True
        '
        'NOMINA
        '
        Me.NOMINA.HeaderText = "NOMINA"
        Me.NOMINA.Name = "NOMINA"
        Me.NOMINA.ReadOnly = True
        '
        'SEMANA
        '
        Me.SEMANA.HeaderText = "SEMANA"
        Me.SEMANA.Name = "SEMANA"
        Me.SEMANA.ReadOnly = True
        '
        'FECHA_TIMBRADO
        '
        Me.FECHA_TIMBRADO.HeaderText = "FECHA TIMBRADO"
        Me.FECHA_TIMBRADO.Name = "FECHA_TIMBRADO"
        Me.FECHA_TIMBRADO.ReadOnly = True
        '
        'DescargarXMLDeInternet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(854, 375)
        Me.Controls.Add(Me.btn_descargar)
        Me.Controls.Add(Me.txt_sinTimbrar)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txt_sinDescargar)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt_correctos)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dgv_resultados)
        Me.Controls.Add(Me.cmb_temporadas)
        Me.Controls.Add(Me.btn_consultar)
        Me.Controls.Add(Me.cmb_nomina)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_semana)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "DescargarXMLDeInternet"
        Me.ReferenciaRapidaVisible = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Descargar XML de Internet"
        Me.Controls.SetChildIndex(Me.lblToolTip, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.txt_semana, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.cmb_nomina, 0)
        Me.Controls.SetChildIndex(Me.btn_consultar, 0)
        Me.Controls.SetChildIndex(Me.cmb_temporadas, 0)
        Me.Controls.SetChildIndex(Me.dgv_resultados, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.txt_correctos, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.txt_sinDescargar, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.txt_sinTimbrar, 0)
        Me.Controls.SetChildIndex(Me.btn_descargar, 0)
        CType(Me.dgv_resultados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmb_temporadas As System.Windows.Forms.ComboBox
    Friend WithEvents btn_consultar As System.Windows.Forms.Button
    Friend WithEvents cmb_nomina As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_semana As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgv_resultados As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_correctos As System.Windows.Forms.TextBox
    Friend WithEvents txt_sinDescargar As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_sinTimbrar As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btn_descargar As System.Windows.Forms.Button
    Friend WithEvents CLAVE_FACTURA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMPORTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CLAVE_EMPLEADO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBRE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ESTATUS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UUID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents XML As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RFC_EMISOR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RFC_RECEPTOR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TEMPORADA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMINA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SEMANA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHA_TIMBRADO As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
