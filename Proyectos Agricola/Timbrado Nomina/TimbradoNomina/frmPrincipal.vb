Imports Sistema.Comunes.Comun.ClsTools
Imports Sistema.DataAccessCls

Public Class frmPrincipal
    Public Shared Servidor As String
    Public Shared BD As String
    Public Shared Usuario As String
    Public Shared Contra As String

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        End
    End Sub

    Private Sub frmPrincipal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            CheckForIllegalCrossThreadCalls = False
            If DAO Is Nothing Then
                End
            End If

            inicializa()
            Me.Location = Screen.PrimaryScreen.WorkingArea.Location
            Me.Size = Screen.PrimaryScreen.WorkingArea.Size

            Application.CurrentCulture = New System.Globalization.CultureInfo("es-MX")
            HabilitaBotones(True, True, True, True, True, True)

            Dim frm2 As New FrmEmpresas

            If Not frm2.ShowDialog = Windows.Forms.DialogResult.OK Then
                End
            End If


            CambianombreBD(DAO.GetNombreBaseDeDatos)

            Me.Text = "    Sistema de Timbrado de Nómina"
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ProductosToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductosToolStripMenuItem1.Click
        Dim frm2 As New FrmM1502001()
        CargarForma(frm2)
    End Sub

    Private Sub TrabajadoresSinTimbrarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TrabajadoresSinTimbrarToolStripMenuItem.Click
        Dim frm As New ConsultaFaltantesPorTimbrar()
        CargarForma(frm)
    End Sub

    Private Sub ComprobanteDeTimbradoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComprobanteDeTimbradoToolStripMenuItem.Click
        Dim frm As New ReporteComprobanteTimbrado()
        CargarForma(frm)
    End Sub

    Private Sub CancelaciónDeSemanaTimbradaToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub CargarArchivosXMLDesdeCarpetaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CargarArchivosXMLDesdeCarpetaToolStripMenuItem.Click
        Dim frm As New CargarXMLDeCarpeta()
        CargarForma(frm)
    End Sub

    Private Sub DescargarXMLDeInternetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DescargarXMLDeInternetToolStripMenuItem.Click
        Dim frm As New DescargarXMLDeInternet()
        CargarForma(frm)
    End Sub

    Private Sub DescargarXMLDeAcuseDeInternetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DescargarXMLDeAcuseDeInternetToolStripMenuItem.Click
        Dim frm As New DescargarAcusesFaltantes()
        CargarForma(frm)
    End Sub

    Private Sub AduntarXMLAPólizasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AduntarXMLAPólizasToolStripMenuItem.Click
        Dim frm As New AdjuntarXMLAPolizas()
        CargarForma(frm)
    End Sub
End Class
