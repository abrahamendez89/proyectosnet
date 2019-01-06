<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCamposCalculados_1
    Inherits System.Windows.Forms.Form

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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.atxFormula = New AccTextBoxAdvanced
        Me.btnAgregarUno = New System.Windows.Forms.Button
        Me.btnParDer = New System.Windows.Forms.Button
        Me.btnParIzq = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.btnDividir = New System.Windows.Forms.Button
        Me.btnMultiplicar = New System.Windows.Forms.Button
        Me.btnResta = New System.Windows.Forms.Button
        Me.LblCampo = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnTodosAtras = New System.Windows.Forms.Button
        Me.btnSuma = New System.Windows.Forms.Button
        Me.BtnTodos = New System.Windows.Forms.Button
        Me.LbxCol = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.atxFormula)
        Me.GroupBox1.Controls.Add(Me.btnAgregarUno)
        Me.GroupBox1.Controls.Add(Me.btnParDer)
        Me.GroupBox1.Controls.Add(Me.btnParIzq)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.CheckBox2)
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Controls.Add(Me.btnDividir)
        Me.GroupBox1.Controls.Add(Me.btnMultiplicar)
        Me.GroupBox1.Controls.Add(Me.btnResta)
        Me.GroupBox1.Controls.Add(Me.LblCampo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnTodosAtras)
        Me.GroupBox1.Controls.Add(Me.btnSuma)
        Me.GroupBox1.Controls.Add(Me.BtnTodos)
        Me.GroupBox1.Controls.Add(Me.LbxCol)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(424, 233)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'atxFormula
        '
        Me.atxFormula.BlancoEsValorInvalido = True
        Me.atxFormula.CadenaDescripcionNoValida = "Codigo no existe"
        Me.atxFormula.CaracterValorNuevo = Global.Microsoft.VisualBasic.ChrW(0)
        Me.atxFormula.CatalogoBase = Nothing
        Me.atxFormula.CatalogoPrincipal = False
        Me.atxFormula.ColorDesactivado = System.Drawing.Color.Empty
        Me.atxFormula.ControlDestinoDescripcion = Nothing
        Me.atxFormula.DescripcionElementoInvalido = "Codigo no existe"
        Me.atxFormula.EnPantalla = False
        Me.atxFormula.FiltroExtendido = ""
        Me.atxFormula.LanzarMensajeError = False
        Me.atxFormula.Location = New System.Drawing.Point(209, 44)
        Me.atxFormula.Multiline = True
        Me.atxFormula.Multiple = False
        Me.atxFormula.Name = "atxFormula"
        Me.atxFormula.PermiteAvanceElementoInvalido = True
        Me.atxFormula.PermiteAyudaRapida = True
        Me.atxFormula.PermiteSoloCapturarAlfanumericos = True
        Me.atxFormula.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.atxFormula.Size = New System.Drawing.Size(203, 102)
        Me.atxFormula.TabIndex = 4
        Me.atxFormula.TeclaAyuda = System.Windows.Forms.Keys.F1
        Me.atxFormula.TituloMensaje = "Sistema Integral Panama"
        Me.atxFormula.ValorValido = False
        '
        'btnAgregarUno
        '
        Me.btnAgregarUno.Location = New System.Drawing.Point(208, 153)
        Me.btnAgregarUno.Name = "btnAgregarUno"
        Me.btnAgregarUno.Size = New System.Drawing.Size(54, 23)
        Me.btnAgregarUno.TabIndex = 5
        Me.btnAgregarUno.Text = ">"
        Me.btnAgregarUno.UseVisualStyleBackColor = True
        '
        'btnParDer
        '
        Me.btnParDer.Location = New System.Drawing.Point(-328, 153)
        Me.btnParDer.Name = "btnParDer"
        Me.btnParDer.Size = New System.Drawing.Size(54, 23)
        Me.btnParDer.TabIndex = 7
        Me.btnParDer.Text = ")"
        Me.btnParDer.UseVisualStyleBackColor = True
        '
        'btnParIzq
        '
        Me.btnParIzq.Location = New System.Drawing.Point(-328, 177)
        Me.btnParIzq.Name = "btnParIzq"
        Me.btnParIzq.Size = New System.Drawing.Size(54, 23)
        Me.btnParIzq.TabIndex = 12
        Me.btnParIzq.Text = "("
        Me.btnParIzq.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(196, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Formula"
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBox2.Location = New System.Drawing.Point(263, 399)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(29, 17)
        Me.CheckBox2.TabIndex = 32
        Me.CheckBox2.Text = ")"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(238, 399)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(29, 17)
        Me.CheckBox1.TabIndex = 31
        Me.CheckBox1.Text = "("
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'btnDividir
        '
        Me.btnDividir.Location = New System.Drawing.Point(268, 177)
        Me.btnDividir.Name = "btnDividir"
        Me.btnDividir.Size = New System.Drawing.Size(54, 23)
        Me.btnDividir.TabIndex = 9
        Me.btnDividir.Text = "/"
        Me.btnDividir.UseVisualStyleBackColor = True
        '
        'btnMultiplicar
        '
        Me.btnMultiplicar.Location = New System.Drawing.Point(268, 153)
        Me.btnMultiplicar.Name = "btnMultiplicar"
        Me.btnMultiplicar.Size = New System.Drawing.Size(54, 23)
        Me.btnMultiplicar.TabIndex = 8
        Me.btnMultiplicar.Text = "*"
        Me.btnMultiplicar.UseVisualStyleBackColor = True
        '
        'btnResta
        '
        Me.btnResta.Location = New System.Drawing.Point(208, 201)
        Me.btnResta.Name = "btnResta"
        Me.btnResta.Size = New System.Drawing.Size(54, 23)
        Me.btnResta.TabIndex = 7
        Me.btnResta.Text = "-"
        Me.btnResta.UseVisualStyleBackColor = True
        '
        'LblCampo
        '
        Me.LblCampo.AutoSize = True
        Me.LblCampo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCampo.Location = New System.Drawing.Point(105, 11)
        Me.LblCampo.Name = "LblCampo"
        Me.LblCampo.Size = New System.Drawing.Size(0, 13)
        Me.LblCampo.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Campo calculado:"
        '
        'btnTodosAtras
        '
        Me.btnTodosAtras.Location = New System.Drawing.Point(268, 201)
        Me.btnTodosAtras.Name = "btnTodosAtras"
        Me.btnTodosAtras.Size = New System.Drawing.Size(54, 23)
        Me.btnTodosAtras.TabIndex = 10
        Me.btnTodosAtras.Text = "C"
        Me.btnTodosAtras.UseVisualStyleBackColor = True
        '
        'btnSuma
        '
        Me.btnSuma.Location = New System.Drawing.Point(208, 177)
        Me.btnSuma.Name = "btnSuma"
        Me.btnSuma.Size = New System.Drawing.Size(54, 23)
        Me.btnSuma.TabIndex = 6
        Me.btnSuma.Text = "+"
        Me.btnSuma.UseVisualStyleBackColor = True
        '
        'BtnTodos
        '
        Me.BtnTodos.Enabled = False
        Me.BtnTodos.Location = New System.Drawing.Point(471, 160)
        Me.BtnTodos.Name = "BtnTodos"
        Me.BtnTodos.Size = New System.Drawing.Size(54, 23)
        Me.BtnTodos.TabIndex = 22
        Me.BtnTodos.Text = ">>"
        Me.BtnTodos.UseVisualStyleBackColor = True
        Me.BtnTodos.Visible = False
        '
        'LbxCol
        '
        Me.LbxCol.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.LbxCol.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.LbxCol.Location = New System.Drawing.Point(9, 44)
        Me.LbxCol.Name = "LbxCol"
        Me.LbxCol.Size = New System.Drawing.Size(193, 181)
        Me.LbxCol.TabIndex = 2
        Me.LbxCol.UseCompatibleStateImageBehavior = False
        Me.LbxCol.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Width = 160
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(352, 241)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(271, 241)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'frmCamposCalculados_1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(435, 270)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Name = "frmCamposCalculados_1"
        Me.Text = "Campos calculados"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents atxFormula As AccTextBoxAdvanced
    Friend WithEvents btnAgregarUno As System.Windows.Forms.Button
    Friend WithEvents btnParDer As System.Windows.Forms.Button
    Friend WithEvents btnParIzq As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents btnDividir As System.Windows.Forms.Button
    Friend WithEvents btnMultiplicar As System.Windows.Forms.Button
    Friend WithEvents btnResta As System.Windows.Forms.Button
    Public WithEvents LblCampo As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnTodosAtras As System.Windows.Forms.Button
    Friend WithEvents btnSuma As System.Windows.Forms.Button
    Friend WithEvents BtnTodos As System.Windows.Forms.Button
    Public WithEvents LbxCol As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
End Class
