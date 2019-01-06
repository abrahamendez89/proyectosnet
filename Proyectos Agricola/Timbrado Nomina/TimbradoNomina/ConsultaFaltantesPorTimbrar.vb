Public Class ConsultaFaltantesPorTimbrar
    Private dbAcceso As Herramientas.SQL.SQLServer
    Private Sub btn_consultar_Click(sender As Object, e As EventArgs) Handles btn_consultar.Click

        If cmb_temporadas.SelectedIndex = -1 Then
            Herramientas.Forms.Mensajes.Advertencia("Debe seleccionar una temporada")
        End If
        If cmb_nomina.SelectedIndex = -1 Then
            Herramientas.Forms.Mensajes.Advertencia("Debe seleccionar una nómina")
        End If

        Dim query As String = "SELECT nfactura, LEFT(CCVE_EMPL,5) AS cCveEmpl,cRazonSocialCliente AS cNombre,CSEMANA " +
                                ",cRFCCliente, len(cRFCCliente) As CaracteresRFC " +
                                "FROM EMPRESAS..FAC_ENCFACTURASCFDINOM fa " +
                                "WHERE CCVE_TEMPORADA = @temporada AND CCVE_NOMINA = @nomina and UUID is null and csemana = @semana order by CSEMANA, cCveEmpl"

        Dim parametros As New List(Of Object)
        parametros.Add(cmb_temporadas.SelectedItem.ToString())
        parametros.Add(String.Format("{0:00}", (cmb_nomina.SelectedIndex + 1)))

        If txt_semana.Text.Trim.Equals("") Then
            query = query.Replace("and csemana = @semana", "")
        Else
            parametros.Add(String.Format("{0:00}", Convert.ToInt32(txt_semana.Text)))
        End If

        Dim dtResultado As DataTable = dbAcceso.EjecutarConsulta(query, parametros)


        For Each dr As DataRow In dtResultado.Rows
            dgv_resultados.Rows.Add(dr("nfactura"), dr("cCveEmpl"), dr("cNombre"), dr("CSEMANA"), dr("cRFCCliente"), dr("CaracteresRFC"))
        Next

        dgv_resultados.Refresh()

    End Sub

    Private Sub ConsultaFaltantesPorTimbrar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dbAcceso = New Herramientas.SQL.SQLServer()
        dbAcceso.ConfigurarConexion(frmPrincipal.Servidor, frmPrincipal.BD, frmPrincipal.Usuario, frmPrincipal.Contra)

        Dim anterior As String = (DateTime.Now.Year - 2).ToString().Substring(2, 2) & "-" & (DateTime.Now.Year - 1).ToString().Substring(2, 2)
        Dim actual As String = (DateTime.Now.Year - 1).ToString().Substring(2, 2) & "-" & (DateTime.Now.Year).ToString().Substring(2, 2)
        Dim siguiente As String = (DateTime.Now.Year).ToString().Substring(2, 2) & "-" & (DateTime.Now.Year + 1).ToString().Substring(2, 2)

        cmb_temporadas.Items.Add(anterior)
        cmb_temporadas.Items.Add(actual)
        cmb_temporadas.Items.Add(siguiente)

        Herramientas.Forms.Validaciones.TextboxSoloNumerosEnteros(txt_semana)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim descripciones As New List(Of String)
        descripciones.Add("Archivo Excel")
        Dim extensiones As New List(Of String)
        extensiones.Add("xls")
        Dim nombreArchivo As String = ""
        Dim ruta As String = Herramientas.Archivos.Dialogos.GuardarArchivoRuta(descripciones, extensiones, "")
        If ruta <> Nothing Then
            Dim ex As New Herramientas.Forms.ExcelAPI
            ex.ConvertirDataGridViewAExcel(ruta, dgv_resultados, Color.Orange, Color.Black)
        End If


    End Sub
End Class