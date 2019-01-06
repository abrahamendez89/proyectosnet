<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VerXMLAdjuntosDePoliza
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
        Me.dgv_xml = New System.Windows.Forms.DataGridView()
        Me.UUID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RFC_EMISOR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RFC_RECEPTOR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FOLIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHA_EMISION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MONTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.XML = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_poliza = New System.Windows.Forms.TextBox()
        Me.txt_montoTotalCargo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn_eliminarAsignacion = New System.Windows.Forms.Button()
        Me.txt_montoTotalXML = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btn_cancelarTodas = New System.Windows.Forms.Button()
        CType(Me.dgv_xml, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblToolTip
        '
        Me.lblToolTip.Size = New System.Drawing.Size(19, 25)
        '
        'dgv_xml
        '
        Me.dgv_xml.AllowUserToAddRows = False
        Me.dgv_xml.AllowUserToDeleteRows = False
        Me.dgv_xml.AllowUserToOrderColumns = True
        Me.dgv_xml.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_xml.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_xml.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.UUID, Me.RFC_EMISOR, Me.RFC_RECEPTOR, Me.FOLIO, Me.FECHA_EMISION, Me.MONTO, Me.XML})
        Me.dgv_xml.Location = New System.Drawing.Point(3, 38)
        Me.dgv_xml.MultiSelect = False
        Me.dgv_xml.Name = "dgv_xml"
        Me.dgv_xml.ReadOnly = True
        Me.dgv_xml.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_xml.Size = New System.Drawing.Size(914, 238)
        Me.dgv_xml.TabIndex = 2
        '
        'UUID
        '
        Me.UUID.HeaderText = "UUID"
        Me.UUID.Name = "UUID"
        Me.UUID.ReadOnly = True
        Me.UUID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'RFC_EMISOR
        '
        Me.RFC_EMISOR.HeaderText = "RFC Emisor"
        Me.RFC_EMISOR.Name = "RFC_EMISOR"
        Me.RFC_EMISOR.ReadOnly = True
        Me.RFC_EMISOR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'RFC_RECEPTOR
        '
        Me.RFC_RECEPTOR.HeaderText = "RFC Receptor"
        Me.RFC_RECEPTOR.Name = "RFC_RECEPTOR"
        Me.RFC_RECEPTOR.ReadOnly = True
        Me.RFC_RECEPTOR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'FOLIO
        '
        Me.FOLIO.HeaderText = "Folio"
        Me.FOLIO.Name = "FOLIO"
        Me.FOLIO.ReadOnly = True
        Me.FOLIO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'FECHA_EMISION
        '
        Me.FECHA_EMISION.HeaderText = "Fecha emisión"
        Me.FECHA_EMISION.Name = "FECHA_EMISION"
        Me.FECHA_EMISION.ReadOnly = True
        Me.FECHA_EMISION.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'MONTO
        '
        Me.MONTO.HeaderText = "Monto"
        Me.MONTO.Name = "MONTO"
        Me.MONTO.ReadOnly = True
        Me.MONTO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'XML
        '
        Me.XML.HeaderText = "XML"
        Me.XML.Name = "XML"
        Me.XML.ReadOnly = True
        Me.XML.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(38, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 14)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Póliza:"
        '
        'txt_poliza
        '
        Me.txt_poliza.Location = New System.Drawing.Point(86, 8)
        Me.txt_poliza.Name = "txt_poliza"
        Me.txt_poliza.ReadOnly = True
        Me.txt_poliza.Size = New System.Drawing.Size(168, 22)
        Me.txt_poliza.TabIndex = 4
        '
        'txt_montoTotalCargo
        '
        Me.txt_montoTotalCargo.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_montoTotalCargo.Location = New System.Drawing.Point(428, 4)
        Me.txt_montoTotalCargo.Name = "txt_montoTotalCargo"
        Me.txt_montoTotalCargo.ReadOnly = True
        Me.txt_montoTotalCargo.Size = New System.Drawing.Size(168, 27)
        Me.txt_montoTotalCargo.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(273, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(153, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Monto total del cargo:"
        '
        'btn_eliminarAsignacion
        '
        Me.btn_eliminarAsignacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_eliminarAsignacion.Location = New System.Drawing.Point(569, 280)
        Me.btn_eliminarAsignacion.Name = "btn_eliminarAsignacion"
        Me.btn_eliminarAsignacion.Size = New System.Drawing.Size(347, 23)
        Me.btn_eliminarAsignacion.TabIndex = 7
        Me.btn_eliminarAsignacion.Text = "Eliminar asignación de XML Seleccionado a esta póliza"
        Me.btn_eliminarAsignacion.UseVisualStyleBackColor = True
        '
        'txt_montoTotalXML
        '
        Me.txt_montoTotalXML.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_montoTotalXML.Location = New System.Drawing.Point(744, 4)
        Me.txt_montoTotalXML.Name = "txt_montoTotalXML"
        Me.txt_montoTotalXML.ReadOnly = True
        Me.txt_montoTotalXML.Size = New System.Drawing.Size(168, 27)
        Me.txt_montoTotalXML.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(602, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(140, 16)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Monto total en XML:"
        '
        'btn_cancelarTodas
        '
        Me.btn_cancelarTodas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_cancelarTodas.Location = New System.Drawing.Point(3, 280)
        Me.btn_cancelarTodas.Name = "btn_cancelarTodas"
        Me.btn_cancelarTodas.Size = New System.Drawing.Size(307, 23)
        Me.btn_cancelarTodas.TabIndex = 10
        Me.btn_cancelarTodas.Text = "Eliminar asignación de todos los XML a esta póliza"
        Me.btn_cancelarTodas.UseVisualStyleBackColor = True
        '
        'VerXMLAdjuntosDePoliza
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(917, 326)
        Me.Controls.Add(Me.btn_cancelarTodas)
        Me.Controls.Add(Me.txt_montoTotalXML)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btn_eliminarAsignacion)
        Me.Controls.Add(Me.txt_montoTotalCargo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_poliza)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgv_xml)
        Me.Name = "VerXMLAdjuntosDePoliza"
        Me.ReferenciaRapidaVisible = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ver xml adjuntados a la póliza"
        Me.Controls.SetChildIndex(Me.lblToolTip, 0)
        Me.Controls.SetChildIndex(Me.dgv_xml, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txt_poliza, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.txt_montoTotalCargo, 0)
        Me.Controls.SetChildIndex(Me.btn_eliminarAsignacion, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txt_montoTotalXML, 0)
        Me.Controls.SetChildIndex(Me.btn_cancelarTodas, 0)
        CType(Me.dgv_xml, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv_xml As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_poliza As System.Windows.Forms.TextBox
    Friend WithEvents txt_montoTotalCargo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_eliminarAsignacion As System.Windows.Forms.Button
    Friend WithEvents UUID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RFC_EMISOR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RFC_RECEPTOR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FOLIO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHA_EMISION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MONTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents XML As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txt_montoTotalXML As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btn_cancelarTodas As System.Windows.Forms.Button
End Class
