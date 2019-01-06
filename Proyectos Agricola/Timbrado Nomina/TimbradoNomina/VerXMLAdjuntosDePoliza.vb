Imports Herramientas.Archivos
Imports Herramientas.Forms
Public Class VerXMLAdjuntosDePoliza
    Private sql As Herramientas.SQL.SQLServer
    Dim dtDatos As DataTable

    Dim cpoliza As String
    Dim nRFCEmisor As String
    Dim usarTotal As Boolean


    'Identificadores de fuentes:
    '1.- ENCPOLIZAS y DETPOLIZAS (BD)
    '2.- FAC_XMLFACTURAS_TIMBRES (EMPRESAS)
    '3.- FAC_ENCFACTURAS (cfactura) y documentos_electronicos(folio)


    Public Sub New(ByVal cpoliza As String, ByVal nRFCEmisor As String, ByRef montoTotal As String, ByRef verSoloXML As Double, ByRef usarTotal As Boolean)
        InitializeComponent()
        sql = New Herramientas.SQL.SQLServer()
        sql.ConfigurarConexion(frmPrincipal.Servidor, frmPrincipal.BD, frmPrincipal.Usuario, frmPrincipal.Contra)

        Me.usarTotal = usarTotal

        Me.cpoliza = cpoliza
        Me.nRFCEmisor = nRFCEmisor

        txt_poliza.Text = cpoliza
        txt_montoTotalCargo.Text = Herramientas.Conversiones.Formatos.DoubleAMoneda(Convert.ToDouble(montoTotal))
        If verSoloXML Then
            CargarDatosXML()
        Else
            CargarDatosPolizas()
        End If
    End Sub
    Public Sub CargarDatosPolizas()
        Dim query As String = "select ID, cRFCReceptor, cFactura, cPoliza From EMPRESAS..FAC_XML where cPoliza = '" & cpoliza & "' and nRFCEmisor = " & nRFCEmisor & " and cEstatus = 'A'"
        dgv_xml.Rows.Clear()
        dtDatos = sql.EjecutarConsulta(query)
        For Each dr In dtDatos.Rows
            
            Dim importeTotal As String
            Dim folio As String = dr("cFactura").ToString()
            Dim RFCEmisor As String = ""
            Dim NombreEmisor As String = ""
            Dim RFCReceptor As String = dr("cRFCReceptor").ToString()
            Dim NombreReceptor As String = ""

            Dim fechaEmision As String
            Dim UUID As String
            dgv_xml.Rows.Add(UUID, RFCEmisor, RFCReceptor, folio, fechaEmision, importeTotal, "")
        Next


        dgv_xml.Refresh()
    End Sub
    Public Sub CargarDatosXML()
        Dim query As String = "select ID, cContenidoXML From EMPRESAS..FAC_XML where cPoliza = '" & cpoliza & "' and nRFCEmisor = " & nRFCEmisor & " and sFormaPago is null and cEstatus = 'A'"
        dgv_xml.Rows.Clear()
        dtDatos = sql.EjecutarConsulta(query)
        Dim montoTotalEnXML As Double = 0
        For Each dr In dtDatos.Rows
            Dim Sxml As String = dr("cContenidoXML").ToString()
            Dim xml As New XML()
            xml.XMLContenido = Sxml
            Dim dato As String = "subtotal"
            If Me.usarTotal Then
                dato = "total"
            End If

            ' verificando el monto mayor para usarlo

            Dim total As Double = Convert.ToDouble(xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Comprobante", "total"))
            Dim subtotal As Double = Convert.ToDouble(xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Comprobante", "subtotal"))
            Dim importeTotal As String ' = Herramientas.Conversiones.Formatos.DoubleAMoneda(Convert.ToDouble(xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Comprobante", dato)))

            If (total > subtotal) Then
                importeTotal = Herramientas.Conversiones.Formatos.DoubleAMoneda(total)
            Else
                importeTotal = Herramientas.Conversiones.Formatos.DoubleAMoneda(subtotal)
            End If


            Dim folio As String = xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Comprobante", "folio")
            Dim RFCEmisor As String = xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Emisor", "rfc")
            Dim NombreEmisor As String = xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Emisor", "nombre")
            Dim RFCReceptor As String = xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Receptor", "rfc")
            Dim NombreReceptor As String = xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Receptor", "nombre")


            montoTotalEnXML = montoTotalEnXML + Herramientas.Conversiones.Formatos.StringFormatoDineroADouble(importeTotal)


            Dim fechaEmision As String = Herramientas.Conversiones.Formatos.DateTimeAFechaCortaConMesTextoAbreviado(Convert.ToDateTime(xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Comprobante", "fecha")))
            Dim UUID As String = xml.ObtenerValorDePropiedad_NODO_XML("tfd", "TimbreFiscalDigital", "UUID")
            dgv_xml.Rows.Add(UUID, RFCEmisor, RFCReceptor, folio, fechaEmision, importeTotal, Sxml)
        Next

        txt_montoTotalXML.Text = Herramientas.Conversiones.Formatos.DoubleAMoneda(montoTotalEnXML)

        dgv_xml.Refresh()
    End Sub

    Private Sub btn_eliminarAsignacion_Click(sender As Object, e As EventArgs) Handles btn_eliminarAsignacion.Click
        Try

            If dgv_xml.SelectedRows.Count > 0 Then
                If Herramientas.Forms.Mensajes.PreguntaAdvertenciaSIoNO("Si elimina la relación tendrá que subir el XML e iniciar el proceso de asignación nuevamente, ¿Desea continuar con la eliminación?") Then

                    Dim indice As Integer = dgv_xml.SelectedRows(0).Index

                    Dim id As String = dtDatos.Rows(indice)("ID")

                    Dim query As String = "delete from empresas..fac_xml where id = " & id

                    sql.EjecutarConsulta(query)

                    Herramientas.Forms.Mensajes.Informacion("Se eliminó el registro correctamente.")

                    CargarDatosXML()

                End If
            End If
        Catch ex As Exception
            Herramientas.Forms.Mensajes.Error("Error: " & ex.Message)
        End Try
    End Sub


    Private Sub dgv_xml_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_xml.CellDoubleClick
        If dgv_xml.SelectedRows.Count > 0 Then
            Dim indice As Integer = dgv_xml.SelectedRows(0).Index
            Try
                Dim visor As New VisorXML(dtDatos.Rows(indice)("cContenidoXML"))
                visor.ShowDialog()
            Catch
            End Try
        End If
    End Sub

    Private Sub btn_cancelarTodas_Click(sender As Object, e As EventArgs) Handles btn_cancelarTodas.Click

        If Not Herramientas.Forms.Mensajes.PreguntaAdvertenciaSIoNO("Si elimina la relación tendrá que subir los XML e iniciar el proceso de asignación nuevamente, ¿Desea quitar la asignación de todos los XML?") Then
            Return
        End If
        Try
            sql.IniciarTransaccion()
            For Each dr In dtDatos.Rows
                Dim id As String = dr("ID")
                Dim query As String = "delete from empresas..fac_xml where id = " & id
                sql.EjecutarConsulta(query)

            Next
            sql.TerminarTransaccion()
            Herramientas.Forms.Mensajes.Informacion("Se eliminó el registro correctamente.")
            CargarDatosXML()
        Catch ex As Exception
            sql.DeshacerTransaccion()
            Herramientas.Forms.Mensajes.Error(ex.Message)
        End Try

    End Sub
End Class

