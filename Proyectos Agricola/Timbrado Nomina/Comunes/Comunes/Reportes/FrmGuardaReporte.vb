Imports System.Windows.Forms

Public Class FrmGuardaReporte

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If txtNombre.Text.Trim = "" Then
            MessageBox.Show(Comunes.Comun.ClsTools.GlobalSistemaErrorFaltanCampos & vbCrLf & "Nombre Reporte", Comunes.Comun.ClsTools.GlobalSistemaCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtNombre.Focus()
            Exit Sub
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class

