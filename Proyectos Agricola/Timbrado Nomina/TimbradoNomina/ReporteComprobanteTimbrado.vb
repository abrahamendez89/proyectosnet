Public Class ReporteComprobanteTimbrado
    Private dbAcceso As Herramientas.SQL.SQLServer

    Private Sub ReporteComprobanteTimbrado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dbAcceso = New Herramientas.SQL.SQLServer()
        dbAcceso.ConfigurarConexion(frmPrincipal.Servidor, frmPrincipal.BD, frmPrincipal.Usuario, frmPrincipal.Contra)

        Dim anterior As String = (DateTime.Now.Year - 2).ToString().Substring(2, 2) & "-" & (DateTime.Now.Year - 1).ToString().Substring(2, 2)
        Dim actual As String = (DateTime.Now.Year - 1).ToString().Substring(2, 2) & "-" & (DateTime.Now.Year).ToString().Substring(2, 2)
        Dim siguiente As String = (DateTime.Now.Year).ToString().Substring(2, 2) & "-" & (DateTime.Now.Year + 1).ToString().Substring(2, 2)

        cmb_temporadas.Items.Add(anterior)
        cmb_temporadas.Items.Add(actual)
        cmb_temporadas.Items.Add(siguiente)


        bdSeleccionadas.Add("natura")
        bdSeleccionadas.Add("natura")
        bdSeleccionadas.Add("nomina_tecnica")
        bdSeleccionadas.Add("nomina_tecnica")


        Herramientas.Forms.Validaciones.TextboxSoloNumerosEnteros(txt_semana)
    End Sub
    Private temporadaTexto As String
    Private semanaTexto As String
    Private nominaTexto As String
    Private nominaNumero As String
    Private nominaIndice As Int32
    Private bdSeleccionadas As New List(Of String)


    Private Sub btn_consultar_Click(sender As Object, e As EventArgs) Handles btn_consultar.Click
        'obteniendo empleados timbrados.
        If cmb_temporadas.SelectedIndex = -1 Then
            Herramientas.Forms.Mensajes.Advertencia("Debe seleccionar una temporada")
        End If
        If cmb_nomina.SelectedIndex = -1 Then
            Herramientas.Forms.Mensajes.Advertencia("Debe seleccionar una nómina")
        End If
        semanaTexto = Convert.ToInt32(txt_semana.Text).ToString("00")
        txt_semana.Text = semanaTexto
        dgv_resultados.Rows.Clear()
        Dim totalImportes2 As Double
        Dim totalImportes As Double
        dgv_faltantes.Rows.Clear()
        Dim query As String = "SELECT nfactura, LEFT(CCVE_EMPL,6) AS cCveEmpl,cRazonSocialCliente AS cNombre,CSEMANA " +
                                ",nimporte, uuid " +
                                "FROM EMPRESAS..FAC_ENCFACTURASCFDINOM fa " +
                                "WHERE CCVE_TEMPORADA = @temporada AND CCVE_NOMINA = @nomina and csemana = @semana order by CSEMANA, cCveEmpl"

        Dim parametros As New List(Of Object)
        parametros.Add(cmb_temporadas.SelectedItem.ToString())
        temporadaTexto = cmb_temporadas.SelectedItem.ToString()
        nominaNumero = String.Format("{0:00}", (cmb_nomina.SelectedIndex + 1))

        nominaIndice = cmb_nomina.SelectedIndex

        parametros.Add(nominaNumero)
        semanaTexto = txt_semana.Text
        nominaTexto = cmb_nomina.SelectedItem.ToString()


        If txt_semana.Text.Trim.Equals("") Then
            query = query.Replace("and csemana = @semana", "")
        Else
            parametros.Add(String.Format("{0:00}", Convert.ToInt32(txt_semana.Text)))
        End If

        Dim dtResultado As DataTable = dbAcceso.EjecutarConsulta(query, parametros)


        For Each dr As DataRow In dtResultado.Rows
            If dr("uuid").ToString() <> "" Then
                dgv_resultados.Rows.Add(dr("nfactura"), dr("cCveEmpl"), dr("cNombre"), dr("CSEMANA"), Convert.ToDouble(dr("nimporte")).ToString("C"), dr("uuid"))
                totalImportes += Convert.ToDouble(dr("nimporte"))
            Else
                dgv_faltantes.Rows.Add(dr("nfactura"), dr("cCveEmpl"), dr("cNombre"), dr("CSEMANA"), Convert.ToDouble(dr("nimporte")).ToString("C"))
                totalImportes2 += Convert.ToDouble(dr("nimporte"))
            End If

        Next
        dgv_resultados.Rows.Add("Empleados: ", dgv_resultados.Rows.Count.ToString(), "", "Total", Herramientas.WPF.Utilidades.RedondearANDecimales(totalImportes, 2).ToString("C"), "")
        dgv_resultados.Refresh()
        dgv_faltantes.Rows.Add("Empleados: ", dgv_faltantes.Rows.Count.ToString(), "", "Total", Herramientas.WPF.Utilidades.RedondearANDecimales(totalImportes2, 2).ToString("C"), "")
        dgv_faltantes.Refresh()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim descripciones As New List(Of String)
        descripciones.Add("Archivo PDF")
        Dim extensiones As New List(Of String)
        extensiones.Add("pdf")
        Dim nombreArchivo As String = ""
        semanaTexto = Convert.ToInt32(semanaTexto).ToString("00")
        txt_semana.Text = semanaTexto
        'obteniendo fechas de la semana 
        Dim semanaFechas As New DataTable
        Dim parametros As New List(Of Object)
        parametros.Add(temporadaTexto)
        parametros.Add(nominaNumero)
        parametros.Add(semanaTexto)

        Dim query As String = "SELECT dfec_ini, dfec_fin FROM " & bdSeleccionadas(nominaIndice) & "..CTL_Semanas where ccve_temporada = @temporada and ccve_nomina = @nomina and csemana = @semana"
        semanaFechas = dbAcceso.EjecutarConsulta(query, parametros)

        Dim titulos As New List(Of String)
        titulos.Add("COMPROBANTE DE TIMBRADO DE LA TEMPORADA " & temporadaTexto & " DE LA SEMANA " & semanaTexto)
        titulos.Add("DE " & String.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(semanaFechas.Rows(0)("dfec_ini"))) & " A " & String.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(semanaFechas.Rows(0)("dfec_fin"))))
        titulos.Add("NOMINA " & nominaTexto.ToUpper() & "  ")


        Dim listaGrids As New List(Of DataGridView)
        listaGrids.Add(dgv_resultados)
        listaGrids.Add(dgv_faltantes)

        Dim listaTitulos As New List(Of String)
        listaTitulos.Add("Trabajadores timbrados")
        listaTitulos.Add("Trabajadores faltantes de timbrar")

        Dim nombreArchivoPDF As String = "TEMPORADA_" & temporadaTexto & "_" & nominaTexto.ToUpper() & "_SEMANA_" & semanaTexto


        Dim ruta As String = Herramientas.Archivos.Dialogos.GuardarArchivoRuta(descripciones, extensiones, nombreArchivoPDF)
        If ruta <> Nothing Then
            Herramientas.Archivos.PDF.ExportarDataGridViewToPDF(listaGrids, ruta, titulos, True, listaTitulos)
        End If
    End Sub
End Class