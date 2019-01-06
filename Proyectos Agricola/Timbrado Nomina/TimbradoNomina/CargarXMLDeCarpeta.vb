Public Class CargarXMLDeCarpeta

    Private Sub btn_buscar_Click(sender As Object, e As EventArgs) Handles btn_buscar.Click
        txt_carpeta.Text = Herramientas.Archivos.Dialogos.BuscarCarpeta(Nothing)

        Dim extensionesFiltros As New List(Of String)
        extensionesFiltros.Add("xml")

        Dim archivosXML As New List(Of String)
        archivosXML = Herramientas.WPF.Utilidades.ObtenerRutasArchivoDeDirectorio(txt_carpeta.Text, extensionesFiltros, chb_incluirSubCarpetas.Checked)

        For i As Int32 = 0 To 40
            dgv_xml.Rows.Add(archivosXML(i), Herramientas.Archivos.Archivo.LeerArchivoTexto(archivosXML(i)))
        Next


    End Sub
End Class