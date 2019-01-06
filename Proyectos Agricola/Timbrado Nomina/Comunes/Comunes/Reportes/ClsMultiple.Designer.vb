<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ClsMultiple
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.AccTextBoxAdvanced1 = New AccTextBoxAdvanced
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Fecha"
        '
        'Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Location = New System.Drawing.Point(194, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(307, 20)
        Me.Label2.TabIndex = 11
        '
        'AccTextBoxAdvanced1
        '
        Me.AccTextBoxAdvanced1.BlancoEsValorInvalido = False
        Me.AccTextBoxAdvanced1.CadenaDescripcionNoValida = Nothing
        Me.AccTextBoxAdvanced1.CaracterValorNuevo = Global.Microsoft.VisualBasic.ChrW(0)
        Me.AccTextBoxAdvanced1.CatalogoBase = Nothing
        Me.AccTextBoxAdvanced1.CatalogoPrincipal = False
        Me.AccTextBoxAdvanced1.ColorDesactivado = System.Drawing.Color.Empty
        Me.AccTextBoxAdvanced1.ControlDestinoDescripcion = Nothing
        Me.AccTextBoxAdvanced1.DescripcionElementoInvalido = Nothing
        Me.AccTextBoxAdvanced1.EnPantalla = False
        Me.AccTextBoxAdvanced1.FiltroExtendido = ""
        Me.AccTextBoxAdvanced1.LanzarMensajeError = False
        Me.AccTextBoxAdvanced1.Location = New System.Drawing.Point(91, 1)
        Me.AccTextBoxAdvanced1.MaxLength = 250
        Me.AccTextBoxAdvanced1.Multiple = True
        Me.AccTextBoxAdvanced1.Name = "AccTextBoxAdvanced1"
        Me.AccTextBoxAdvanced1.PermiteAvanceElementoInvalido = False
        Me.AccTextBoxAdvanced1.PermiteAyudaRapida = True
        Me.AccTextBoxAdvanced1.PermiteSoloCapturarAlfanumericos = True
        Me.AccTextBoxAdvanced1.Size = New System.Drawing.Size(101, 20)
        Me.AccTextBoxAdvanced1.TabIndex = 12
        Me.AccTextBoxAdvanced1.TeclaAyuda = System.Windows.Forms.Keys.F1
        Me.AccTextBoxAdvanced1.TituloMensaje = Nothing
        Me.AccTextBoxAdvanced1.ValorValido = False
        '
        'CheckBox2
        '
        Me.CheckBox2.Location = New System.Drawing.Point(549, 4)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(189, 17)
        Me.CheckBox2.TabIndex = 15
        Me.CheckBox2.Text = "Usar Clasif."
        Me.CheckBox2.UseVisualStyleBackColor = True
        Me.CheckBox2.Visible = False
        '
        'CheckBox1
        '
        Me.CheckBox1.Location = New System.Drawing.Point(504, 4)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(91, 17)
        Me.CheckBox1.TabIndex = 14
        Me.CheckBox1.Text = "Excluir"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'ClsMultiple
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.AccTextBoxAdvanced1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "ClsMultiple"
        Me.Size = New System.Drawing.Size(827, 24)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents AccTextBoxAdvanced1 As AccTextBoxAdvanced
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox

End Class
