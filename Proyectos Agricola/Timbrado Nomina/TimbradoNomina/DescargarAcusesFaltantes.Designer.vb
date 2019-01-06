<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DescargarAcusesFaltantes
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
        Me.btn_iniciar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_cargar = New System.Windows.Forms.Button()
        Me.dgv_resultados = New System.Windows.Forms.DataGridView()
        Me.CLAVE_FACTURA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMPORTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UUID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RFC_EMISOR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RFC_RECEPTOR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHA_CANCELACION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ACUSE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgv_resultados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblToolTip
        '
        Me.lblToolTip.Size = New System.Drawing.Size(19, 25)
        '
        'btn_iniciar
        '
        Me.btn_iniciar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_iniciar.Location = New System.Drawing.Point(723, 381)
        Me.btn_iniciar.Name = "btn_iniciar"
        Me.btn_iniciar.Size = New System.Drawing.Size(145, 25)
        Me.btn_iniciar.TabIndex = 1
        Me.btn_iniciar.Text = "Iniciar"
        Me.btn_iniciar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(358, 14)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Listado de uuid que estan registrados y no tienen xml de acuse."
        '
        'btn_cargar
        '
        Me.btn_cargar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_cargar.Location = New System.Drawing.Point(723, 9)
        Me.btn_cargar.Name = "btn_cargar"
        Me.btn_cargar.Size = New System.Drawing.Size(145, 25)
        Me.btn_cargar.TabIndex = 3
        Me.btn_cargar.Text = "Cargar"
        Me.btn_cargar.UseVisualStyleBackColor = True
        '
        'dgv_resultados
        '
        Me.dgv_resultados.AllowUserToAddRows = False
        Me.dgv_resultados.AllowUserToDeleteRows = False
        Me.dgv_resultados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_resultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_resultados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CLAVE_FACTURA, Me.IMPORTE, Me.UUID, Me.RFC_EMISOR, Me.RFC_RECEPTOR, Me.FECHA_CANCELACION, Me.ACUSE})
        Me.dgv_resultados.Location = New System.Drawing.Point(19, 41)
        Me.dgv_resultados.Name = "dgv_resultados"
        Me.dgv_resultados.ReadOnly = True
        Me.dgv_resultados.Size = New System.Drawing.Size(849, 334)
        Me.dgv_resultados.TabIndex = 18
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
        'UUID
        '
        Me.UUID.HeaderText = "UUID"
        Me.UUID.Name = "UUID"
        Me.UUID.ReadOnly = True
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
        'FECHA_CANCELACION
        '
        Me.FECHA_CANCELACION.HeaderText = "FECHA CANCELACION"
        Me.FECHA_CANCELACION.Name = "FECHA_CANCELACION"
        Me.FECHA_CANCELACION.ReadOnly = True
        '
        'ACUSE
        '
        Me.ACUSE.HeaderText = "ACUSE"
        Me.ACUSE.Name = "ACUSE"
        Me.ACUSE.ReadOnly = True
        '
        'DescargarAcusesFaltantes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(882, 415)
        Me.Controls.Add(Me.dgv_resultados)
        Me.Controls.Add(Me.btn_cargar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_iniciar)
        Me.Name = "DescargarAcusesFaltantes"
        Me.ReferenciaRapidaVisible = True
        Me.Text = "DescargarAcusesFaltantes"
        Me.Controls.SetChildIndex(Me.btn_iniciar, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.btn_cargar, 0)
        Me.Controls.SetChildIndex(Me.dgv_resultados, 0)
        Me.Controls.SetChildIndex(Me.lblToolTip, 0)
        CType(Me.dgv_resultados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_iniciar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_cargar As System.Windows.Forms.Button
    Friend WithEvents dgv_resultados As System.Windows.Forms.DataGridView
    Friend WithEvents CLAVE_FACTURA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMPORTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UUID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RFC_EMISOR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RFC_RECEPTOR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHA_CANCELACION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ACUSE As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
