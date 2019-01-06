Imports System.Threading
Imports Herramientas.Forms
Public Class DescargarAcusesFaltantes
    Private dbAcceso As Herramientas.SQL.SQLServer
    Private Sub btn_iniciar_Click(sender As Object, e As EventArgs) Handles btn_iniciar.Click
        hProcesoDescargar = New Thread(AddressOf ProcesoDescargar)
        hProcesoDescargar.Start()
    End Sub

    Private Sub btn_cargar_Click(sender As Object, e As EventArgs) Handles btn_cargar.Click
        dgv_resultados.Rows.Clear()

        'Dim query As String = "SELECT fa.nfactura, LEFT(fa.CCVE_EMPL,5) AS cCveEmpl,cRazonSocialCliente AS cNombre, UUID, tim.cContenidoXML " +
        '                    ",emi.cRFC, emi.nRFCEmisor, fa.cRFCCliente, fa.CCVE_TEMPORADA, fa.CCVE_NOMINA, fa.CSEMANA, fa.DFECHATIMBRADO, fa.NIMPORTE " +
        '                    "FROM EMPRESAS..FAC_ENCFACTURASCFDINOM fa " +
        '                    "left join EMPRESAS..FAC_XMLFACTURAS_TIMBRES tim on fa.nFactura = tim.nFactura " +
        '                    "inner join empresas..FAC_EMISORES emi on fa.nRFCEmisor = emi.nRFCEmisor " +
        '                    "WHERE fa.CCVE_TEMPORADA = @temporada AND fa.CCVE_NOMINA = @nomina and csemana = @semana " +
        '                    "order by CSEMANA, cCveEmpl"

        Dim query As String = "SELECT " +
        "nFactura " +
        ",cRFCEmisor " +
        ",nImporte " +
        ",UUID " +
        ",cRFCEmpleado " +
        ",dFechaCancelacion " +
        ",AcuseXML " +
        "FROM empresas..FAC_CFDINOMINA_CANCELACIONES " +
        "where uuid <> '' " +
        "and (acusexml = '' or AcuseXML is null) " +
        "order by dFechaCancelacion desc"

        Dim parametros As New List(Of Object)
       

        Dim dtResultado As DataTable = dbAcceso.EjecutarConsulta(query, parametros)

        For Each dr As DataRow In dtResultado.Rows
            Dim estatus As String = ""
            Dim colorFondo As Color = Color.White
            Dim colorFuente As Color = Color.Black

            dgv_resultados.Rows.Add(dr("nfactura"), dr("nImporte"), dr("UUID"), dr("cRFCEmisor"), dr("cRFCEmpleado"), dr("dFechaCancelacion"), "")

            dgv_resultados.Rows(dgv_resultados.Rows.Count - 1).Cells(4).Style.BackColor = colorFondo
            dgv_resultados.Rows(dgv_resultados.Rows.Count - 1).Cells(4).Style.ForeColor = colorFuente

        Next

        dgv_resultados.Refresh()
    End Sub
    Private hProcesoDescargar As Thread
    Private Sub ProcesoDescargar()
        Try
            Dim test As New CFD.ClsFD

            For Each dr As DataGridViewRow In dgv_resultados.Rows
                Dim rfcEmisor As String = dr.Cells("cRFCEmisor").Value

                If dr.Cells(4).Value.ToString.Equals("XML no descargado") Then
                    Dim xmlTimbre As String = test.RecuperaXML(dr.Cells(0).Value, dr.Cells(5).Value, dr.Cells(7).Value)
                    'Dim achito As String = test.RecuperaXML("PRO120417EBA", "5U%9nahGx@HFt$", "5C0EB743-60E9-484A-A8DC-92D5A1A07675", "ANV040509TA4")
                    If xmlTimbre.Contains("Error: ") Then
                        xmlTimbre = xmlTimbre.Replace("Error: ", "")
                        dr.Cells(6).Value = xmlTimbre
                        dr.Cells(4).Style.BackColor = Color.Red
                        dr.Cells(4).Style.ForeColor = Color.White
                        dr.Cells(4).Value = "Error"
                    Else
                        dr.Cells(6).Value = xmlTimbre
                        dr.Cells(4).Style.BackColor = Color.Green
                        dr.Cells(4).Style.ForeColor = Color.White
                        dr.Cells(4).Value = "Descargado"

                        Dim queryGuardadoXML As String = "insert empresas..FAC_XMLFACTURAS_TIMBRES(nFactura, nRFCEmisor, cRFCEmpleado, ccve_temporada, ccve_nomina, ccve_semana, ccve_empl, dfecha, nImporte, cContenidoXML) values(@nFactura, @nRFCEmisor, @cRFCEmpleado, @ccve_temporada, @ccve_nomina, @ccve_semana, @ccve_empl, @dfecha, @nImporte, @cContenidoXML)"
                        Dim valores As New List(Of Object)
                        valores.Add(dr.Cells(0).Value)
                        valores.Add(rfcEmisor)
                        valores.Add(dr.Cells(8).Value)

                        valores.Add(dr.Cells(9).Value)
                        valores.Add(dr.Cells(10).Value)
                        valores.Add(dr.Cells(11).Value)
                        valores.Add(dr.Cells(2).Value)
                        valores.Add(dr.Cells(12).Value)
                        valores.Add(dr.Cells(1).Value)
                        valores.Add(dr.Cells(6).Value)

                        dbAcceso.EjecutarConsulta(queryGuardadoXML, valores)
                    End If
                End If
            Next
            Herramientas.Forms.Mensajes.Informacion("Terminó el proceso de descarga.")
        Catch ex As Exception
            Herramientas.Forms.Mensajes.Error(ex.Message)
        End Try
    End Sub

    Private Sub DescargarAcusesFaltantes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            dbAcceso = New Herramientas.SQL.SQLServer()
            dbAcceso.ConfigurarConexion(frmPrincipal.Servidor, frmPrincipal.BD, frmPrincipal.Usuario, frmPrincipal.Contra)


        Catch ex As Exception
            Herramientas.Forms.Mensajes.Error(ex.Message)
        End Try
    End Sub
End Class