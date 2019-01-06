Imports System.Windows.Forms
Imports Sistema.Comunes.Comun
Imports Sistema.Comunes.Comun.ClsTools

Public Class frmCamposCalculados_1

#Region "Declaraciones"
    Public Reporte As Comunes.Comun.ClsReportes
    Public Dt As New DataTable
    'Public ObjReporte As ClsReportes
    Private bSigno As Boolean
    Private bCampo As Boolean
    Private bParentesisDer As Boolean
    Private bParentesisIzq As Boolean
#End Region

#Region "Constructores"
    Public Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Public Sub New(ByRef prmTabla As DataTable, ByVal prmReporte As Comunes.Comun.ClsReportes)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Dt = prmTabla
        Reporte = prmReporte
    End Sub
#End Region

#Region "Procedimientos"

    Private Sub plCargarDatos()
        If Dt.Rows.Count > 0 Then
            Dim row As DataRow()
            row = Dt.Select("cCampo='" & LblCampo.Text.Trim & "'")
            If row.Length > 0 Then
                atxFormula.Text = IIf(row(0)("cFormula") Is DBNull.Value, "", row(0)("cFormula"))
            End If
        End If
        'Dim dtCampoCalculado As New DataTable
        'Dim cFormula As Object
        'If Reporte Is Nothing Then Return
        'dtCampoCalculado = FabricaReportes.ObtenCampoCalculado(Reporte.Folio, LblCampo.Text.Trim)
        'If dtCampoCalculado.Rows.Count > 0 Then
        '    cFormula = dtCampoCalculado.Rows(0)("cFormula")
        '    If cFormula Is DBNull.Value Then
        '        atxFormula.Text = dtCampoCalculado.Rows(0)("cFormula")
        '    End If
        'End If
    End Sub

#End Region

#Region "Eventos"

    Private Sub FrmCamposCalculados_1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        bSigno = True
        bCampo = False
        bParentesisIzq = False
        bParentesisDer = True
        plCargarDatos()
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
    End Sub

    Private Sub btnAgregarUno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarUno.Click
        If LbxCol.SelectedItems.Count = 0 Then Return
        If LbxCol.SelectedItems.Count > 1 Then
            MessageBox.Show("Sólo debe seleccionar un campo a la vez", ClsTools.GlobalSistemaCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            If bCampo Then Return
            atxFormula.Text &= "[" + LbxCol.SelectedItems.Item(0).Text & "]"
            bSigno = False
            bCampo = True
            bParentesisIzq = False
            bParentesisDer = False
        End If
    End Sub

    Private Sub btnSuma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSuma.Click
        If bSigno Then Return
        atxFormula.Text &= " + "
        bSigno = True
        bCampo = False
    End Sub

    Private Sub btnResta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResta.Click
        If bSigno Then Return
        atxFormula.Text &= " - "
        bSigno = True
        bCampo = False
    End Sub

    Private Sub btnMultiplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMultiplicar.Click
        If bSigno Then Return
        atxFormula.Text &= " * "
        bSigno = True
        bCampo = False
    End Sub

    Private Sub btnDividir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDividir.Click
        If bSigno Then Return
        atxFormula.Text &= " / "
        bSigno = True
        bCampo = False
    End Sub

    'Private Sub btnParIzq_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnParIzq.Click
    '    If atxFormula.Text.Trim = "" Then
    '        atxFormula.Text &= " ( "
    '        bParentesisIzq = True
    '        bParentesisDer = True
    '    Else
    '        If (Not bCampo And bSigno) Or (Not bCampo And Not bSigno And bParentesisIzq) Then
    '            atxFormula.Text &= " ( "
    '            bSigno = False
    '            bParentesisIzq = True
    '            bCampo = False
    '        End If
    '    End If
    'End Sub

    'Private Sub btnParDer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnParDer.Click
    '    If atxFormula.Text.Trim = "" Then Return
    '    If bCampo Or bSigno Or bParentesisDer Then
    '        atxFormula.Text &= " ) "
    '    End If
    '    bSigno = False
    '    bCampo = True
    '    bParentesisDer = True
    'End Sub

    Private Sub btnUnoAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnTodosAtras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTodosAtras.Click
        atxFormula.Text = ""
        bSigno = True
        bCampo = False
        bParentesisIzq = False
        bParentesisDer = False
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Dt.Rows.Count = 0 Then
            With Dt
                .Rows.Add(.NewRow)
                .Rows(Dt.Rows.Count - 1)("ccampo") = LblCampo.Text.Trim
                .Rows(Dt.Rows.Count - 1)("cFormula") = atxFormula.Text.Trim
            End With
        Else
            Dim row As DataRow()
            row = Dt.Select("cCampo='" & LblCampo.Text.Trim & "'")
            If row.Length > 0 Then
                row(0)("cFormula") = atxFormula.Text.Trim
            Else
                With Dt
                    .Rows.Add(.NewRow)
                    .Rows(Dt.Rows.Count - 1)("ccampo") = LblCampo.Text.Trim
                    .Rows(Dt.Rows.Count - 1)("cFormula") = atxFormula.Text.Trim
                End With
            End If
        End If
        Dt.AcceptChanges()
        Me.Close()
    End Sub

    Private Sub atxFormula_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles atxFormula.KeyDown
        e.Handled = True
    End Sub

    Private Sub atxFormula_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles atxFormula.KeyPress
        e.Handled = True
    End Sub

#End Region

End Class