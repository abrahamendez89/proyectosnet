<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultaFaltantesPorTimbrar
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_semana = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmb_nomina = New System.Windows.Forms.ComboBox()
        Me.dgv_resultados = New System.Windows.Forms.DataGridView()
        Me.CLAVE_FACTURA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CLAVE_EMPLEADO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOMBRE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SEMANA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RFC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LONGITUD_RFC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btn_consultar = New System.Windows.Forms.Button()
        Me.cmb_temporadas = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.dgv_resultados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblToolTip
        '
        Me.lblToolTip.Size = New System.Drawing.Size(19, 25)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Temporada:"
        '
        'txt_semana
        '
        Me.txt_semana.Location = New System.Drawing.Point(285, 6)
        Me.txt_semana.Name = "txt_semana"
        Me.txt_semana.Size = New System.Drawing.Size(81, 22)
        Me.txt_semana.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(220, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 14)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Semana:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(373, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 14)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Nómina:"
        '
        'cmb_nomina
        '
        Me.cmb_nomina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_nomina.FormattingEnabled = True
        Me.cmb_nomina.Items.AddRange(New Object() {"Natura Culiacán", "Natura Imuris", "Tecnica Culiacán", "Tecnica Imuris"})
        Me.cmb_nomina.Location = New System.Drawing.Point(434, 6)
        Me.cmb_nomina.Name = "cmb_nomina"
        Me.cmb_nomina.Size = New System.Drawing.Size(261, 22)
        Me.cmb_nomina.TabIndex = 6
        '
        'dgv_resultados
        '
        Me.dgv_resultados.AllowUserToAddRows = False
        Me.dgv_resultados.AllowUserToDeleteRows = False
        Me.dgv_resultados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_resultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_resultados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CLAVE_FACTURA, Me.CLAVE_EMPLEADO, Me.NOMBRE, Me.SEMANA, Me.RFC, Me.LONGITUD_RFC})
        Me.dgv_resultados.Location = New System.Drawing.Point(14, 34)
        Me.dgv_resultados.Name = "dgv_resultados"
        Me.dgv_resultados.ReadOnly = True
        Me.dgv_resultados.Size = New System.Drawing.Size(917, 270)
        Me.dgv_resultados.TabIndex = 7
        '
        'CLAVE_FACTURA
        '
        Me.CLAVE_FACTURA.HeaderText = "CLAVE FACTURA"
        Me.CLAVE_FACTURA.Name = "CLAVE_FACTURA"
        Me.CLAVE_FACTURA.ReadOnly = True
        Me.CLAVE_FACTURA.Width = 180
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
        'SEMANA
        '
        Me.SEMANA.HeaderText = "SEMANA"
        Me.SEMANA.Name = "SEMANA"
        Me.SEMANA.ReadOnly = True
        Me.SEMANA.Width = 40
        '
        'RFC
        '
        Me.RFC.HeaderText = "RFC"
        Me.RFC.Name = "RFC"
        Me.RFC.ReadOnly = True
        Me.RFC.Width = 150
        '
        'LONGITUD_RFC
        '
        Me.LONGITUD_RFC.HeaderText = "LONGITUD RFC"
        Me.LONGITUD_RFC.Name = "LONGITUD_RFC"
        Me.LONGITUD_RFC.ReadOnly = True
        Me.LONGITUD_RFC.Width = 50
        '
        'btn_consultar
        '
        Me.btn_consultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_consultar.Location = New System.Drawing.Point(833, 4)
        Me.btn_consultar.Name = "btn_consultar"
        Me.btn_consultar.Size = New System.Drawing.Size(98, 25)
        Me.btn_consultar.TabIndex = 8
        Me.btn_consultar.Text = "Consultar"
        Me.btn_consultar.UseVisualStyleBackColor = True
        '
        'cmb_temporadas
        '
        Me.cmb_temporadas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_temporadas.FormattingEnabled = True
        Me.cmb_temporadas.Location = New System.Drawing.Point(87, 7)
        Me.cmb_temporadas.Name = "cmb_temporadas"
        Me.cmb_temporadas.Size = New System.Drawing.Size(127, 22)
        Me.cmb_temporadas.TabIndex = 9
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(757, 310)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(174, 23)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Exportar a excel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ConsultaFaltantesPorTimbrar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(933, 365)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cmb_temporadas)
        Me.Controls.Add(Me.btn_consultar)
        Me.Controls.Add(Me.dgv_resultados)
        Me.Controls.Add(Me.cmb_nomina)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_semana)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "ConsultaFaltantesPorTimbrar"
        Me.ReferenciaRapidaVisible = True
        Me.Text = "ConsultaFaltantesPorTimbrar"
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.txt_semana, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.cmb_nomina, 0)
        Me.Controls.SetChildIndex(Me.dgv_resultados, 0)
        Me.Controls.SetChildIndex(Me.btn_consultar, 0)
        Me.Controls.SetChildIndex(Me.lblToolTip, 0)
        Me.Controls.SetChildIndex(Me.cmb_temporadas, 0)
        Me.Controls.SetChildIndex(Me.Button1, 0)
        CType(Me.dgv_resultados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_semana As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmb_nomina As System.Windows.Forms.ComboBox
    Friend WithEvents dgv_resultados As System.Windows.Forms.DataGridView
    Friend WithEvents btn_consultar As System.Windows.Forms.Button
    Friend WithEvents CLAVE_FACTURA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CLAVE_EMPLEADO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBRE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SEMANA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RFC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LONGITUD_RFC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmb_temporadas As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
