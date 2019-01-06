Public Class FrmVisorCrystal
    Public reporteCrystal As CrystalDecisions.CrystalReports.Engine.ReportDocument


    Private Sub FrmVisorCrystal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CrystalReportViewer1.DisplayGroupTree = False
        CrystalReportViewer1.ReportSource = reporteCrystal
        CrystalReportViewer1.Visible = True
    End Sub
End Class