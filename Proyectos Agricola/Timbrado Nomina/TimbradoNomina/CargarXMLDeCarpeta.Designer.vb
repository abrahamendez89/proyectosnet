<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CargarXMLDeCarpeta
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
        Me.txt_carpeta = New System.Windows.Forms.TextBox()
        Me.btn_buscar = New System.Windows.Forms.Button()
        Me.dgv_xml = New System.Windows.Forms.DataGridView()
        Me.chb_incluirSubCarpetas = New System.Windows.Forms.CheckBox()
        Me.RUTA_ARCHIVO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.XML_CONTENIDO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgv_xml, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblToolTip
        '
        Me.lblToolTip.Size = New System.Drawing.Size(19, 25)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 14)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Carpeta:"
        '
        'txt_carpeta
        '
        Me.txt_carpeta.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_carpeta.Location = New System.Drawing.Point(71, 22)
        Me.txt_carpeta.Name = "txt_carpeta"
        Me.txt_carpeta.Size = New System.Drawing.Size(556, 22)
        Me.txt_carpeta.TabIndex = 3
        '
        'btn_buscar
        '
        Me.btn_buscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_buscar.Location = New System.Drawing.Point(766, 21)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(82, 23)
        Me.btn_buscar.TabIndex = 4
        Me.btn_buscar.Text = "Buscar"
        Me.btn_buscar.UseVisualStyleBackColor = True
        '
        'dgv_xml
        '
        Me.dgv_xml.AllowUserToAddRows = False
        Me.dgv_xml.AllowUserToDeleteRows = False
        Me.dgv_xml.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_xml.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_xml.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RUTA_ARCHIVO, Me.XML_CONTENIDO})
        Me.dgv_xml.Location = New System.Drawing.Point(12, 59)
        Me.dgv_xml.Name = "dgv_xml"
        Me.dgv_xml.ReadOnly = True
        Me.dgv_xml.Size = New System.Drawing.Size(834, 344)
        Me.dgv_xml.TabIndex = 5
        '
        'chb_incluirSubCarpetas
        '
        Me.chb_incluirSubCarpetas.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chb_incluirSubCarpetas.AutoSize = True
        Me.chb_incluirSubCarpetas.Location = New System.Drawing.Point(633, 24)
        Me.chb_incluirSubCarpetas.Name = "chb_incluirSubCarpetas"
        Me.chb_incluirSubCarpetas.Size = New System.Drawing.Size(127, 18)
        Me.chb_incluirSubCarpetas.TabIndex = 6
        Me.chb_incluirSubCarpetas.Text = "Incluir subcarpetas"
        Me.chb_incluirSubCarpetas.UseVisualStyleBackColor = True
        '
        'RUTA_ARCHIVO
        '
        Me.RUTA_ARCHIVO.HeaderText = "RUTA ARCHIVO"
        Me.RUTA_ARCHIVO.Name = "RUTA_ARCHIVO"
        Me.RUTA_ARCHIVO.ReadOnly = True
        Me.RUTA_ARCHIVO.Width = 250
        '
        'XML_CONTENIDO
        '
        Me.XML_CONTENIDO.HeaderText = "XML CONTENIDO"
        Me.XML_CONTENIDO.Name = "XML_CONTENIDO"
        Me.XML_CONTENIDO.ReadOnly = True
        Me.XML_CONTENIDO.Width = 350
        '
        'CargarXMLDeCarpeta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(860, 432)
        Me.Controls.Add(Me.chb_incluirSubCarpetas)
        Me.Controls.Add(Me.dgv_xml)
        Me.Controls.Add(Me.btn_buscar)
        Me.Controls.Add(Me.txt_carpeta)
        Me.Controls.Add(Me.Label1)
        Me.Name = "CargarXMLDeCarpeta"
        Me.ReferenciaRapidaVisible = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CargarXMLDeCarpeta"
        Me.Controls.SetChildIndex(Me.lblToolTip, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txt_carpeta, 0)
        Me.Controls.SetChildIndex(Me.btn_buscar, 0)
        Me.Controls.SetChildIndex(Me.dgv_xml, 0)
        Me.Controls.SetChildIndex(Me.chb_incluirSubCarpetas, 0)
        CType(Me.dgv_xml, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_carpeta As System.Windows.Forms.TextBox
    Friend WithEvents btn_buscar As System.Windows.Forms.Button
    Friend WithEvents dgv_xml As System.Windows.Forms.DataGridView
    Friend WithEvents chb_incluirSubCarpetas As System.Windows.Forms.CheckBox
    Friend WithEvents RUTA_ARCHIVO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents XML_CONTENIDO As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
