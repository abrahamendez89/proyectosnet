Imports System.Threading
Imports Herramientas.Forms
Public Class DescargarXMLDeInternet
    Private dbAcceso As Herramientas.SQL.SQLServer
    Private Sub CancelacionTimbrado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            'cancelar timbre de nomina

            'Dim wsTEst As New CFD.ClsCFDI32
            'wsTEst.CancelaFacturaElectronica("14150140040002")


            'obtener xml de los timbres de nomina

            'Dim test As New CFD.ClsFD
            'Dim achito As String = test.RecuperaXML("13140127040061", "EC551D5E-F00A-4A6B-88B7-890A8DA12033", "ANV040509TA4")
            'Dim achito As String = test.RecuperaXML("PRO120417EBA", "5U%9nahGx@HFt$", "5C0EB743-60E9-484A-A8DC-92D5A1A07675", "ANV040509TA4")

            dbAcceso = New Herramientas.SQL.SQLServer()
            dbAcceso.ConfigurarConexion(frmPrincipal.Servidor, frmPrincipal.BD, frmPrincipal.Usuario, frmPrincipal.Contra)

            Dim anterior As String = (DateTime.Now.Year - 2).ToString().Substring(2, 2) & "-" & (DateTime.Now.Year - 1).ToString().Substring(2, 2)
            Dim actual As String = (DateTime.Now.Year - 1).ToString().Substring(2, 2) & "-" & (DateTime.Now.Year).ToString().Substring(2, 2)
            Dim siguiente As String = (DateTime.Now.Year).ToString().Substring(2, 2) & "-" & (DateTime.Now.Year + 1).ToString().Substring(2, 2)

            cmb_temporadas.Items.Add(anterior)
            cmb_temporadas.Items.Add(actual)
            cmb_temporadas.Items.Add(siguiente)

            Herramientas.Forms.Validaciones.TextboxSoloNumerosEnteros(txt_semana)

        Catch ex As Exception

        End Try





    End Sub
    Dim rfcEmisor As Integer = 0
    Private Sub btn_consultar_Click(sender As Object, e As EventArgs) Handles btn_consultar.Click
        dgv_resultados.Rows.Clear()
        txt_semana.Text = Convert.ToInt32(txt_semana.Text).ToString("00")
        If cmb_temporadas.SelectedIndex = -1 Then
            Herramientas.Forms.Mensajes.Advertencia("Debe seleccionar una temporada")
        End If
        If cmb_nomina.SelectedIndex = -1 Then
            Herramientas.Forms.Mensajes.Advertencia("Debe seleccionar una nómina")
        End If

        Dim query As String = "SELECT fa.nfactura, LEFT(fa.CCVE_EMPL,5) AS cCveEmpl,cRazonSocialCliente AS cNombre, UUID, tim.cContenidoXML " +
                            ",emi.cRFC, emi.nRFCEmisor, fa.cRFCCliente, fa.CCVE_TEMPORADA, fa.CCVE_NOMINA, fa.CSEMANA, fa.DFECHATIMBRADO, fa.NIMPORTE " +
                            "FROM EMPRESAS..FAC_ENCFACTURASCFDINOM fa " +
                            "left join EMPRESAS..FAC_XMLFACTURAS_TIMBRES tim on fa.nFactura = tim.nFactura " +
                            "inner join empresas..FAC_EMISORES emi on fa.nRFCEmisor = emi.nRFCEmisor " +
                            "WHERE fa.CCVE_TEMPORADA = @temporada AND fa.CCVE_NOMINA = @nomina and csemana = @semana " +
                            "order by CSEMANA, cCveEmpl"
        Dim parametros As New List(Of Object)
        parametros.Add(cmb_temporadas.SelectedItem.ToString())
        parametros.Add(String.Format("{0:00}", (cmb_nomina.SelectedIndex + 1)))

        If txt_semana.Text.Trim.Equals("") Then
            query = query.Replace("and csemana = @semana", "")
        Else
            parametros.Add(String.Format("{0:00}", Convert.ToInt32(txt_semana.Text)))
        End If

        Dim dtResultado As DataTable = dbAcceso.EjecutarConsulta(query, parametros)



        Dim contadorSinTimbrar As Integer = 0
        Dim contadorNoDescargado As Integer = 0

        For Each dr As DataRow In dtResultado.Rows
            Dim estatus As String = ""
            Dim colorFondo As Color = Color.White
            Dim colorFuente As Color = Color.Black
            If dr("UUID").ToString.Equals("") Then
                estatus = "Sin timbrar"
                colorFondo = Color.Red
                colorFuente = Color.White
                contadorSinTimbrar = contadorSinTimbrar + 1
            ElseIf dr("cContenidoXML").ToString.Equals("") Then
                estatus = "XML no descargado"
                colorFondo = Color.Orange
                colorFuente = Color.White
                contadorNoDescargado = contadorNoDescargado + 1
            Else
                estatus = "En el servidor"
                colorFondo = Color.Green
                colorFuente = Color.White

            End If

            rfcEmisor = Convert.ToInt32(dr("nRFCEmisor"))

            dgv_resultados.Rows.Add(dr("nfactura"), dr("NIMPORTE"), dr("cCveEmpl"), dr("cNombre"), estatus, dr("UUID"), dr("cContenidoXML"), dr("cRFC"), dr("cRFCCliente"), dr("CCVE_TEMPORADA"), dr("CCVE_NOMINA"), dr("CSEMANA"), dr("DFECHATIMBRADO"))

            dgv_resultados.Rows(dgv_resultados.Rows.Count - 1).Cells(4).Style.BackColor = colorFondo
            dgv_resultados.Rows(dgv_resultados.Rows.Count - 1).Cells(4).Style.ForeColor = colorFuente

        Next

        txt_correctos.Text = dgv_resultados.Rows.Count - contadorNoDescargado - contadorSinTimbrar
        txt_sinDescargar.Text = contadorNoDescargado
        txt_sinTimbrar.Text = contadorSinTimbrar

        dgv_resultados.Refresh()
    End Sub
    Private hProcesoDescargar As Thread
    Private Sub ProcesoDescargar()
        Try
            Dim test As New CFD.ClsFD

            For Each dr As DataGridViewRow In dgv_resultados.Rows

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
    Private Sub btn_descargar_Click(sender As Object, e As EventArgs) Handles btn_descargar.Click
        hProcesoDescargar = New Thread(AddressOf ProcesoDescargar)
        hProcesoDescargar.Start()

    End Sub

    Private Sub dgv_resultados_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_resultados.CellDoubleClick
        If e.ColumnIndex = 6 And e.RowIndex >= 0 Then
            Dim visor As New VisorXML(dgv_resultados.Rows(e.RowIndex).Cells(6).Value)
            visor.Show()
        End If
    End Sub
End Class