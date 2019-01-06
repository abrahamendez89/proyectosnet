Imports Access
Public Class FrmCamposCalculados

    Public Reporte As Comunes.Comun.ClsReportes
    Public Dt As New DataTable

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim i As Integer
        LbxSel.Items.Clear()
        For i = 0 To LbxCol.Items.Count - 1 Step 1
            LbxSel.Items.Add(LbxCol.Items(i).Text)
        Next i
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim i As Integer
        Dim bYaEncontro As Boolean
        For i = 0 To LbxCol.SelectedItems.Count - 1 Step 1
            If LbxSel.Items.Count = 0 Then
                LbxSel.Items.Add(IIf(CheckBox1.Checked, "(", "") & LbxCol.SelectedItems.Item(i).Text & IIf(CheckBox2.Checked, ")", ""))
                LbxSel.Items(LbxSel.Items.Count - 1).SubItems.Add("+")
            Else
                For j As Integer = 0 To LbxSel.Items.Count - 1 Step 1
                    If LbxCol.SelectedItems.Item(i).Text = LbxSel.Items(j).Text Then
                        bYaEncontro = True
                    End If
                Next j
                If bYaEncontro = False Then
                    LbxSel.Items.Add(IIf(CheckBox1.Checked, "(", "") & LbxCol.SelectedItems.Item(i).Text & IIf(CheckBox2.Checked, ")", ""))
                    LbxSel.Items(LbxSel.Items.Count - 1).SubItems.Add("+")
                End If
            End If
        Next i
        RefrecaFormula()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        LbxSel.Items.Clear()
        RefrecaFormula()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim i As Integer
        Dim t As Integer = LbxSel.SelectedItems.Count - 1
        For i = t To 0 Step -1
            LbxSel.SelectedItems.Item(i).Remove()
        Next i
        LbxSel.Refresh()
        RefrecaFormula()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Me.Close()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If Reporte.Folio <> 0 Then
            Dt = Comunes.Comun.FabricaReportes.ObtenCampoCalculado(Reporte.Folio, LblCampo.Text)
            Dt.Rows.Clear()
            For Each vitem As System.Windows.Forms.ListViewItem In LbxSel.Items
                Dim dr As DataRow = Dt.NewRow
                dr("nreporte") = Reporte.Folio
                dr("ccampo") = LblCampo.Text
                dr("ccampoorigen") = vitem.Text
                dr("coperador") = vitem.SubItems(1).Text
                Dt.Rows.Add(dr)
            Next
            Dt.TableName = "ADSUM_ReporteExpressCalculados"
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            DAO.AbreTransaccion()
            Comunes.Comun.FabricaReportes.BorraCampoCalculado(Reporte.Folio, LblCampo.Text)
            If Tool.InsertaYActualizaTablaDeBD(Dt) Then
                Windows.Forms.MessageBox.Show("Campos Guardados con Exito", Comunes.Comun.ClsTools.GlobalSistemaCaption, Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Information)
                DAO.CierraTransaccion()
                Me.Close()
            End If
            If DAO.TieneTransaccionAbierta Then
                DAO.DeshaceTransaccion()
            End If
        End If
    End Sub

    Public Sub Refrescar()
        If Reporte.Folio <> 0 Then
            Dt.Rows.Clear()
            Dt = Comunes.Comun.FabricaReportes.ObtenCampoCalculado(Reporte.Folio, LblCampo.Text)
            LbxSel.Items.Clear()
            For Each vrow As DataRow In Dt.Rows
                LbxSel.Items.Add(vrow("ccampoorigen"))
            Next
        End If
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim i As Integer
        Dim bYaEncontro As Boolean
        For i = 0 To LbxCol.SelectedItems.Count - 1 Step 1
            If LbxSel.Items.Count = 0 Then
                LbxSel.Items.Add(IIf(CheckBox1.Checked, "(", "") & LbxCol.SelectedItems.Item(i).Text & IIf(CheckBox2.Checked, ")", ""))
                LbxSel.Items(LbxSel.Items.Count - 1).SubItems.Add("*")
            Else
                For j As Integer = 0 To LbxSel.Items.Count - 1 Step 1
                    If LbxCol.SelectedItems.Item(i).Text = LbxSel.Items(j).Text Then
                        bYaEncontro = True
                    End If
                Next j
                If bYaEncontro = False Then
                    LbxSel.Items.Add(IIf(CheckBox1.Checked, "(", "") & LbxCol.SelectedItems.Item(i).Text & IIf(CheckBox2.Checked, ")", ""))
                    LbxSel.Items(LbxSel.Items.Count - 1).SubItems.Add("*")
                End If
            End If
        Next i
        RefrecaFormula()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim i As Integer
        Dim bYaEncontro As Boolean
        For i = 0 To LbxCol.SelectedItems.Count - 1 Step 1
            If LbxSel.Items.Count = 0 Then
                LbxSel.Items.Add(IIf(CheckBox1.Checked, "(", "") & LbxCol.SelectedItems.Item(i).Text & IIf(CheckBox2.Checked, ")", ""))
                LbxSel.Items(LbxSel.Items.Count - 1).SubItems.Add("-")
            Else
                For j As Integer = 0 To LbxSel.Items.Count - 1 Step 1
                    If LbxCol.SelectedItems.Item(i).Text = LbxSel.Items(j).Text Then
                        bYaEncontro = True
                    End If
                Next j
                If bYaEncontro = False Then
                    LbxSel.Items.Add(IIf(CheckBox1.Checked, "(", "") & LbxCol.SelectedItems.Item(i).Text & IIf(CheckBox2.Checked, ")", ""))
                    LbxSel.Items(LbxSel.Items.Count - 1).SubItems.Add("-")
                End If
            End If
        Next i
        RefrecaFormula()
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim i As Integer
        Dim bYaEncontro As Boolean
        For i = 0 To LbxCol.SelectedItems.Count - 1 Step 1
            If LbxSel.Items.Count = 0 Then
                LbxSel.Items.Add(IIf(CheckBox1.Checked, "(", "") & LbxCol.SelectedItems.Item(i).Text & IIf(CheckBox2.Checked, ")", ""))
                LbxSel.Items(LbxSel.Items.Count - 1).SubItems.Add("/")
            Else
                For j As Integer = 0 To LbxSel.Items.Count - 1 Step 1
                    If LbxCol.SelectedItems.Item(i).Text = LbxSel.Items(j).Text Then
                        bYaEncontro = True
                    End If
                Next j
                If bYaEncontro = False Then
                    LbxSel.Items.Add(IIf(CheckBox1.Checked, "(", "") & LbxCol.SelectedItems.Item(i).Text & IIf(CheckBox2.Checked, ")", ""))
                    LbxSel.Items(LbxSel.Items.Count - 1).SubItems.Add("/")
                End If
            End If
        Next i
        RefrecaFormula()
    End Sub

    Private Sub RefrecaFormula()
        Dim res As String = ""
        For i As Integer = 0 To LbxSel.Items.Count - 1
            res &= LbxSel.Items(i).Text & LbxSel.Items(i).SubItems(1).Text
        Next

        If CheckBox2.Checked Or (LbxSel.Items.Count > 0 AndAlso LbxSel.Items(LbxSel.Items.Count - 1).Text.Substring(LbxSel.Items(LbxSel.Items.Count - 1).Text.Length - 1, 1) = ")") Then
            res = res.Substring(0, res.Length - 1)
        End If

        Label2.Text = "Formula: " & res
    End Sub
End Class