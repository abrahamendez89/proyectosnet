Imports Herramientas.Archivos
Imports Herramientas.Forms
Public Class AdjuntarXMLAPolizas
    Private dbAcceso As Herramientas.SQL.SQLServer
    Private dtEmpresas As New DataTable
    Private dtTiposPolizas As New DataTable
    Private dtTiposPolizasFAC_XML As New DataTable
    Private dtPolizasConsulta As New DataTable
    Private dtNominasEmpresa As New DataTable
    Private bdEmpresaPolizasSeleccionada As String
    Private bdEmpresaPolizasFAC_XMLSeleccionada As String
    Private bdEmpresaNominaSeleccionada As String
    Private dtResultadoSemanaNomina As New DataTable
    Private nRFCEmisor As Integer
    Private nRFCEmisorFAC_XML As Integer
    Private xmlTemp As String

    'Identificadores de fuentes:
    '1.- ENCPOLIZAS y DETPOLIZAS (BD)
    '2.- FAC_XMLFACTURAS_TIMBRES (EMPRESAS)
    '3.- FAC_ENCFACTURAS (cfactura) y documentos_electronicos(folio)


    'identificadores de nomina
    '1.- sueldos y salarios
    '2.- aguinaldos
    '3.- vacaciones
    '4.- liquidaciones

    Private Sub AdjuntarXMLAPolizas_Load(sender As Object, e As EventArgs) Handles Me.Load
        dbAcceso = New Herramientas.SQL.SQLServer()
        dbAcceso.ConfigurarConexion(frmPrincipal.Servidor, frmPrincipal.BD, frmPrincipal.Usuario, frmPrincipal.Contra)
        CargarDatosCombos()
        dgv_polizas.Font = Label1.Font
        dgv_nomina.Font = Label1.Font
        dgv_polizasCargosFAC_XML.Font = Label1.Font
        btn_AsignarPolizaSemana.Enabled = False
        Herramientas.Forms.Validaciones.TextboxSoloNumerosEnteros(txt_semana)
        txt_totalPoliza.Text = Herramientas.Conversiones.Formatos.DoubleAMoneda(0)
        txt_totalXML.Text = Herramientas.Conversiones.Formatos.DoubleAMoneda(0)
        'configurando grid d enomina
        Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_nomina, "NFactura", 120)
        Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_nomina, "Tipo", 115)
        Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_nomina, "Clave Empleado", 50)
        Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_nomina, "RFC Empleado", 120)
        Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_nomina, "Fecha timbrado", 100)
        Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_nomina, "Importe", 100)
        Herramientas.Forms.DataGridViewConf.AgregarColumna(dgv_nomina, "XML", 300)
    End Sub
    Private Function CargarDatosCombos()
        'cargando comobo de meses
        For index = 1 To 12
            cmb_mes.Items.Add(index.ToString("00"))
            cmb_mesFAC_XML.Items.Add(index.ToString("00"))
        Next
        'cargando combo de ejercicio
        For index = DateTime.Now.Year - 5 To DateTime.Now.Year
            cmb_Ejercicio.Items.Add(index.ToString("0000"))
            cmb_EjercicioFAC_XML.Items.Add(index.ToString("0000"))
        Next

        'trayendo las empresas
        dtEmpresas = dbAcceso.EjecutarConsulta("select  emi.crfc, cnt.CEMPRESA, CBASEDDATOS, RFCEmisor from empresas..EMPRESAS_CNT cnt inner join empresas..FAC_EMISORES emi on cnt.RFCEmisor = emi.nRFCEmisor where RFCEmisor Is Not null order by RFCEmisor")

        For Each dr As DataRow In dtEmpresas.Rows
            cmb_empresasPolizas.Items.Add(dr("CEMPRESA"))
            cmb_empresasNomina.Items.Add(dr("CEMPRESA"))
            cmb_empresasPolizasFAC_XML.Items.Add(dr("CEMPRESA"))
        Next
        'poniendo las temporadas
        Dim anterior As String = (DateTime.Now.Year - 2).ToString().Substring(2, 2) & "-" & (DateTime.Now.Year - 1).ToString().Substring(2, 2)
        Dim actual As String = (DateTime.Now.Year - 1).ToString().Substring(2, 2) & "-" & (DateTime.Now.Year).ToString().Substring(2, 2)
        Dim siguiente As String = (DateTime.Now.Year).ToString().Substring(2, 2) & "-" & (DateTime.Now.Year + 1).ToString().Substring(2, 2)

        cmb_temporadas.Items.Add(anterior)
        cmb_temporadas.Items.Add(actual)
        cmb_temporadas.Items.Add(siguiente)
    End Function

    Private Sub cmb_empresasPolizas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_empresasPolizas.SelectedIndexChanged
        'trayendo los tipos de polias

        bdEmpresaPolizasSeleccionada = dtEmpresas.Rows(cmb_empresasPolizas.SelectedIndex)("CBASEDDATOS")
        dtTiposPolizas = dbAcceso.EjecutarConsulta("select CTIPOPOLIZA, CDESCRIP from " & bdEmpresaPolizasSeleccionada & "..TIPOSPOLIZAS")
        cmb_tipoPolizas.Items.Clear()

        nRFCEmisor = dtEmpresas(cmb_empresasPolizas.SelectedIndex)("RFCEmisor")

        For Each dr As DataRow In dtTiposPolizas.Rows
            cmb_tipoPolizas.Items.Add(dr("CTIPOPOLIZA") & " - " & dr("CDESCRIP"))
        Next
    End Sub

    

    Private Sub btn_consultar_semana_Click(sender As Object, e As EventArgs) Handles btn_consultar_semana.Click

        If cmb_empresasNomina.SelectedItem Is Nothing Or cmb_nomina.SelectedItem Is Nothing Or cmb_temporadas.SelectedItem Is Nothing Or txt_semana.Text.Trim().Equals("") Then
            Herramientas.Forms.Mensajes.Exclamacion("Seleccione las opciones para consultar la nómina.")
            Return
        End If

        Dim clave As String
        clave = cmb_temporadas.SelectedItem.ToString().Replace("-", "") & dtNominasEmpresa(cmb_nomina.SelectedIndex)("CCVE_NOMINA") & Convert.ToDouble(txt_semana.Text.Trim()).ToString("00")

        'Dim queryChequeo As String = "select top 1 cPoliza from EMPRESAS..FAC_XML where nOrigenDatos = 2 and left(cFactura, 8) = '" & clave & "'"

        'Dim check As DataTable = dbAcceso.EjecutarConsulta(queryChequeo)

        'If check.Rows.Count > 0 Then
        '    Herramientas.Forms.Mensajes.Exclamacion("Esta semana ya tiene la póliza '" & check.Rows(0)(0).ToString() & "' registrada, para cambiar la póliza, primero debe cancelar la asignación de la póliza.")
        '    Return
        'End If


        Dim query As String = "SELECT nfactura as [NFactura], case when right(nfactura, 1) = '1' then 'Sueldos y salarios' when right(nfactura, 1) = '2' then 'Aguinaldos' when right(nfactura, 1) = '3' then 'Vacaciones' when right(nfactura, 1) = '4' then 'Liquidaciones' end as [Tipo], LEFT(CCVE_EMPL,5) AS [Clave Empleado],crfcEmpleado AS [RFC Empleado], dfecha as [Fecha timbrado], nimporte as [Importe]" +
                                ", cContenidoXML as [XML] " +
                                "FROM EMPRESAS..FAC_XMLFACTURAS_TIMBRES fa " +
                                "WHERE CCVE_TEMPORADA = @temporada AND CCVE_NOMINA = @nomina and ccve_semana = @semana and "

        Dim usoFiltro As Boolean = False
        Dim filtros As String = ""

        If chb_sueldos.Checked Then
            usoFiltro = True
            filtros += " or right(nfactura, 1) = '1' "
        End If
        If chb_aguinaldos.Checked Then
            usoFiltro = True
            filtros += " or right(nfactura, 1) = '2' "
        End If
        If chb_vacaciones.Checked Then
            usoFiltro = True
            filtros += " or right(nfactura, 1) = '3' "
        End If
        If chb_liquidaciones.Checked Then
            usoFiltro = True
            filtros += " or right(nfactura, 1) = '4' "
        End If

        If Not usoFiltro Then
            Herramientas.Forms.Mensajes.Advertencia("Debe usar un filtro para obtener los timbres.")
            Return
        End If

        filtros = filtros.Substring(4, filtros.Length - 4 - 1)

        query += "(" + filtros + ")"

        query += " order by CCVE_EMPL"

        Dim parametros As New List(Of Object)
        parametros.Add(cmb_temporadas.SelectedItem.ToString())
        parametros.Add(dtNominasEmpresa(cmb_nomina.SelectedIndex)("CCVE_NOMINA"))
        parametros.Add(Convert.ToDouble(txt_semana.Text.Trim()).ToString("00"))

        dtResultadoSemanaNomina = dbAcceso.EjecutarConsulta(query, parametros)

        Dim totalNomina As Double = 0

        dgv_nomina.Rows.Clear()
        For Each dr As DataRow In dtResultadoSemanaNomina.Rows

            Dim xml As New XML()
            xml.XMLContenido = dr("XML")
            Dim importeNeto As Double = Convert.ToDouble(xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Comprobante", "subtotal"))
            totalNomina += importeNeto
            dgv_nomina.Rows.Add(dr("NFactura"), dr("Tipo"), dr("Clave Empleado"), dr("RFC Empleado"), Herramientas.Conversiones.Formatos.DateTimeAFechaCorta(Convert.ToDateTime(dr("Fecha timbrado"))), Herramientas.Conversiones.Formatos.DoubleAMoneda(importeNeto), dr("XML"))

        Next


       
        'CalcularTotalNomina()

        txt_totalXML.Text = Herramientas.Conversiones.Formatos.DoubleAMoneda(totalNomina)

        'dgv_nomina.DataSource = dtResultadoSemanaNomina

        

        dgv_nomina.Refresh()

        Herramientas.Forms.DataGridViewConf.DesactivarOrdenamientoTodasColumnasDataGridView(dgv_nomina)

    End Sub

    Private Function CalcularTotalNomina()
        Dim totalNomina As Double = 0
        If dtResultadoSemanaNomina.Rows.Count > 0 Then
            For Each dr As DataRow In dtResultadoSemanaNomina.Rows
                totalNomina = totalNomina + dr("Importe")
            Next
        End If
        txt_totalXML.Text = Herramientas.Conversiones.Formatos.DoubleAMoneda(totalNomina)
    End Function

    Private Sub cmb_empresasNomina_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_empresasNomina.SelectedIndexChanged
        bdEmpresaNominaSeleccionada = dtEmpresas.Rows(cmb_empresasNomina.SelectedIndex)("CBASEDDATOS")
        dtNominasEmpresa = dbAcceso.EjecutarConsulta("select CCVE_NOMINA, CDESCRIP from " & bdEmpresaNominaSeleccionada & "..CTL_NOMINAS")
        cmb_nomina.Items.Clear()
        For Each dr As DataRow In dtNominasEmpresa.Rows
            cmb_nomina.Items.Add(dr("CDESCRIP"))
        Next
    End Sub

    Private Sub dgv_polizas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_polizas.CellClick

    End Sub

    
    Private Sub btn_consultar_polizas_Click(sender As Object, e As EventArgs) Handles btn_consultar_polizas.Click
        If Not ChecarCombosPolizas() Then
            Herramientas.Forms.Mensajes.Exclamacion("Seleccione las opciones para consultar las pólizas.")
            Return
        End If

        Dim query As String = ""
        query += "select pol.CPOLIZA as [Póliza], DFECHA as [Fecha], sum(det.NCARGO) as [Importe], (select count(*) from empresas..FAC_XML x where x.cPoliza = pol.CPOLIZA and x.nRFCEmisor = " & dtEmpresas(cmb_empresasPolizas.SelectedIndex)("RFCEmisor") & " and x.sFormaPago is null and x.cEstatus = 'A') as [XML Adjuntos], pol.CDESCONCEPTO as [Concepto], CNOMBENEFICIARIO as [Beneficiario] "
        query += "from " + bdEmpresaPolizasSeleccionada + "..ENCPOLIZAS pol join " + bdEmpresaPolizasSeleccionada + "..DETPOLIZAS det on pol.COFICINA = det.COFICINA and pol.CPOLIZA = det.CPOLIZA where left(pol.CPOLIZA,8) = '" & dtTiposPolizas(cmb_tipoPolizas.SelectedIndex)("CTIPOPOLIZA") & cmb_Ejercicio.SelectedItem.ToString() & cmb_mes.SelectedItem.ToString() & "' and CSTATUS = 'A' "

        If chb_conXML.Checked Then
            query += "and exists (select 1 from EMPRESAS..FAC_XML fac where fac.cPoliza = pol.CPOLIZA and fac.nRFCEmisor = " & dtEmpresas(cmb_empresasPolizas.SelectedIndex)("RFCEmisor") & ") "
        End If

        If chb_sinXML.Checked Then
            query += "and not exists (select 1 from EMPRESAS..FAC_XML fac where fac.cPoliza = pol.CPOLIZA and fac.nRFCEmisor = " & dtEmpresas(cmb_empresasPolizas.SelectedIndex)("RFCEmisor") & ") "
        End If

        query += "group by pol.cpoliza, pol.dfecha, pol.CDESCONCEPTO, CNOMBENEFICIARIO "

        query += "order by pol.CPOLIZA asc"

        dtPolizasConsulta = dbAcceso.EjecutarConsulta(query)

        dgv_polizas.DataSource = dtPolizasConsulta
        dgv_polizas.Refresh()

        Herramientas.Forms.DataGridViewConf.DesactivarOrdenamientoTodasColumnasDataGridView(dgv_polizas)

        btn_AsignarPolizaSemana.Enabled = True

    End Sub
    Private Function ChecarCombosPolizas() As Boolean
        If cmb_empresasPolizas.SelectedItem Is Nothing Or cmb_tipoPolizas.SelectedItem Is Nothing Or cmb_Ejercicio.SelectedItem Is Nothing Or cmb_mes.SelectedItem Is Nothing Then
            Return False
        End If
        Return True
    End Function
    Private Sub btn_agregarPoliza_Click(sender As Object, e As EventArgs) Handles btn_agregarPoliza.Click

        If tc_tabs.SelectedIndex = 0 Then
            cmb_polizasSeleccionadas.Items.Clear()
        End If
        If dgv_polizas.SelectedRows.Count > 0 AndAlso dgv_polizas.SelectedRows(0).Index >= 0 Then
            cmb_polizasSeleccionadas.Items.Add(dtPolizasConsulta(dgv_polizas.SelectedRows(0).Index)("Póliza") & " | " & dtPolizasConsulta(dgv_polizas.SelectedRows(0).Index)("Importe"))
        End If
        CalcularTotalPolizas()
    End Sub
    Private Function CalcularTotalPolizas()
        Dim total As Double
        total = 0
        If cmb_polizasSeleccionadas.Items.Count > 0 Then
            For Each item As String In cmb_polizasSeleccionadas.Items
                total += Convert.ToDouble(item.ToString().Split("|")(1))
            Next
        End If
        txt_totalPoliza.Text = Herramientas.Conversiones.Formatos.DoubleAMoneda(total)
    End Function

    Private Sub btn_quitarPoliza_Click(sender As Object, e As EventArgs) Handles btn_quitarPoliza.Click

        If cmb_polizasSeleccionadas.Items.Count > 0 AndAlso cmb_polizasSeleccionadas.SelectedIndex >= 0 Then
            cmb_polizasSeleccionadas.Items.RemoveAt(cmb_polizasSeleccionadas.SelectedIndex)
        End If
        CalcularTotalPolizas()
    End Sub

    Private Sub btn_AsignarPolizaSemana_Click(sender As Object, e As EventArgs) Handles btn_AsignarPolizaSemana.Click

        Try
            If cmb_polizasSeleccionadas.Items.Count = 0 Then
                Herramientas.Forms.Mensajes.Exclamacion("Debe seleccionar la póliza a la que se hará la asignación.")
                Return
            End If
            If Not (txt_totalPoliza.Text.Trim().Equals(txt_totalXML.Text.Trim())) Then
                If Not Herramientas.Forms.Mensajes.PreguntaAdvertenciaSIoNO("El importe total en XML no coincide con el importe total de la(s) Póliza(s) seleccionadas, ¿Desea continuar?") Then
                    Return
                End If
            End If
            If tc_tabs.SelectedIndex = 0 Then
                'guardando el timbrado de nomina

                If dtResultadoSemanaNomina.Rows.Count = 0 Then
                    Herramientas.Forms.Mensajes.Exclamacion("Antes de hacer la asignación debe consultar la semana de la nómina.")
                    Return
                End If

                dbAcceso.IniciarTransaccion()
                Dim cpoliza As String
                cpoliza = cmb_polizasSeleccionadas.Items(0).ToString().Split("|")(0).Trim()

                For Each dr In dtResultadoSemanaNomina.Rows
                    Dim queryInsert As String
                    queryInsert = "insert empresas..fac_xml (nRFCEmisor, cRFCReceptor, cContenidoXML, cFactura, cPoliza, cEstatus, nOrigenDatos) values(@nRFCEmisor, @cRFCReceptor, @cContenidoXML, @cFactura, @cPoliza, @cEstatus, @nOrigenDatos)"

                    Dim valores As New List(Of Object)
                    valores.Add(nRFCEmisor)
                    valores.Add(dr("RFC Empleado"))
                    valores.Add(dr("XML"))
                    valores.Add(dr("NFactura"))
                    valores.Add(cpoliza)
                    valores.Add("A")
                    valores.Add(2)
                    dbAcceso.EjecutarConsulta(queryInsert, valores)

                Next
                dbAcceso.TerminarTransaccion()
                Herramientas.Forms.Mensajes.Informacion("Guardado con éxito.")
            ElseIf tc_tabs.SelectedIndex = 1 Then
                'guardando para las facturas de ingresos
                If facturasXML.Count = 0 Then
                    Herramientas.Forms.Mensajes.Exclamacion("Debe agregar los XML de las facturas a registrar.")
                    Return
                End If
                dbAcceso.IniciarTransaccion()
                For Each item As String In cmb_polizasSeleccionadas.Items
                    Dim cpoliza As String = item.Split("|")(0).Trim()
                    For Each xmlStr In facturasXML
                        Dim queryInsert As String
                        queryInsert = "insert empresas..fac_xml (nRFCEmisor, cRFCReceptor, cContenidoXML, cFactura, cPoliza, cEstatus, nOrigenDatos) values(@nRFCEmisor, @cRFCReceptor, @cContenidoXML, @cFactura, @cPoliza, @cEstatus, @nOrigenDatos)"

                        Dim xml As New XML
                        xml.XMLContenido = xmlStr


                        Dim valores As New List(Of Object)
                        valores.Add(nRFCEmisor)
                        valores.Add(xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Receptor", "rfc"))
                        valores.Add(xmlStr)
                        valores.Add(xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Comprobante", "folio"))
                        valores.Add(cpoliza)
                        valores.Add("A")
                        valores.Add(1)
                        dbAcceso.EjecutarConsulta(queryInsert, valores)
                    Next
                Next
                dbAcceso.TerminarTransaccion()
                cmb_xmlAgregados.Items.Clear()
                facturasXML.Clear()
                Herramientas.Forms.Mensajes.Informacion("Guardado con éxito.")
                CalcularTotalIngresosXML()
            ElseIf tc_tabs.SelectedIndex = 2 Then
                'esta seleccionado para registrar polizas de abonos a polizas de cargo
                'obteniendo los datos para iniciar el emparejamiento

                If cmb_polizasFAC_XML.Items.Count = 0 Then
                    Herramientas.Forms.Mensajes.Advertencia("Debe seleccionar alguna póliza de cargo.")
                    Return
                End If

                Dim idPolizaCargo As String = cmb_polizasFAC_XML.Items(0).ToString().Split("|")(0)
                Dim dt As DataTable = dbAcceso.EjecutarConsulta("SELECT  nRFCEmisor, cRFCReceptor, cFactura FROM empresas..fac_xml where id = " & idPolizaCargo)
                If nRFCEmisor <> Convert.ToInt32(dt.Rows(0)("nRFCEmisor").ToString()) Then
                    If Not Herramientas.Forms.Mensajes.PreguntaAdvertenciaSIoNO("Las empresas no coinciden, ¿desea continuar?.") Then
                        Return
                    End If
                End If

                Dim rfcReceptor As String = dt.Rows(0)("cRFCReceptor").ToString()
                Dim cfactura As String = dt.Rows(0)("cFactura").ToString()

                'aqui insertamos las polizas de abono que se vayan a relacionar
                dbAcceso.IniciarTransaccion()
                For Each item As String In cmb_polizasSeleccionadas.Items
                    Dim cpoliza As String = item.Split("|")(0).Trim()

                    Dim queryInsert As String
                    queryInsert = "insert empresas..fac_xml (nRFCEmisor, cRFCReceptor, cContenidoXML, cFactura, cPoliza, cEstatus, nOrigenDatos) values(@nRFCEmisor, @cRFCReceptor, @cContenidoXML, @cFactura, @cPoliza, @cEstatus, @nOrigenDatos)"

                    Dim valores As New List(Of Object)
                    valores.Add(nRFCEmisor)
                    valores.Add(rfcReceptor)
                    valores.Add("")
                    valores.Add(cfactura)
                    valores.Add(cpoliza)
                    valores.Add("A")
                    valores.Add(1)
                    dbAcceso.EjecutarConsulta(queryInsert, valores)

                Next
                dbAcceso.TerminarTransaccion()


            End If
            LimpiarControles()
            btn_consultar_polizas_Click(Nothing, Nothing)

        Catch ex As Exception
            dbAcceso.DeshacerTransaccion()
            Herramientas.Forms.Mensajes.Error(ex.Message)
        End Try
    End Sub
    Private Function LimpiarControles()
        dgv_nomina.DataSource = Nothing
        dgv_nomina.Refresh()
        txt_semana.Text = ""
        cmb_polizasSeleccionadas.Items.Clear()
        cmb_polizasFAC_XML.Items.Clear()
        btn_consultarPolizasFAC_XML_Click(Nothing, Nothing)
        CalcularTotalPolizasFAC_XML()
        CalcularTotalPolizas()
    End Function


    Private Sub txt_semana_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_semana.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            btn_consultar_semana_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub btn_buscarXML_Click(sender As Object, e As EventArgs) Handles btn_buscarXML.Click
        Dim filtro = New List(Of String)
        Dim filtro2 = New List(Of String)
        filtro.Add("xml")
        filtro2.Add("Archivo de XML")
        txt_rutaArchivoXML.Text = Herramientas.Archivos.Dialogos.BuscarArchivo(filtro2, filtro)

        If Not txt_rutaArchivoXML.Text Is Nothing And Not txt_rutaArchivoXML.Text.Trim().Equals("") Then
            xmlTemp = Herramientas.Archivos.Archivo.LeerArchivoTexto(txt_rutaArchivoXML.Text)

            wb.Navigate(txt_rutaArchivoXML.Text)
            Dim xml As New XML(txt_rutaArchivoXML.Text)

            txt_ImporteXML.Text = Herramientas.Conversiones.Formatos.DoubleAMoneda(Convert.ToDouble(xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Comprobante", "total")))
            txt_folioXML.Text = xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Comprobante", "folio")
            txt_RFCEmisorXML.Text = xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Emisor", "rfc")
            txt_descEmisor.Text = xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Emisor", "nombre")
            txt_RFCReceptorXML.Text = xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Receptor", "rfc")
            txt_descReceptor.Text = xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Receptor", "nombre")

            txt_FechaEMISION.Text = Herramientas.Conversiones.Formatos.DateTimeAFechaCortaConMesTextoAbreviado(Convert.ToDateTime(xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Comprobante", "fecha")))
            txt_UUIDXML.Text = xml.ObtenerValorDePropiedad_NODO_XML("tfd", "TimbreFiscalDigital", "UUID")

        Else
            LimpiarControlesIngresos()
        End If

    End Sub
    Private Function LimpiarControlesIngresos()
        wb.DocumentText = ""
        txt_rutaArchivoXML.Text = ""
        xmlTemp = Nothing
        txt_folioXML.Text = ""
        txt_ImporteXML.Text = ""
        txt_RFCEmisorXML.Text = ""
        txt_RFCReceptorXML.Text = ""
        txt_descEmisor.Text = ""
        txt_descReceptor.Text = ""
        txt_UUIDXML.Text = ""
        txt_FechaEMISION.Text = ""
    End Function
    Private facturasXML As New List(Of String)
    Private Sub btn_agregarXMLCombo_Click(sender As Object, e As EventArgs) Handles btn_agregarXMLCombo.Click

        If xmlTemp Is Nothing Then
            Herramientas.Forms.Mensajes.Exclamacion("Debe buscar un XML primero")
            Return
        End If

        Dim xml As New XML()
        xml.XMLContenido = xmlTemp
        Dim importe As String = Herramientas.Conversiones.Formatos.DoubleAMoneda(Convert.ToDouble(xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Comprobante", "total")))
        Dim folio As String = xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Comprobante", "folio")
        Dim uuid As String = xml.ObtenerValorDePropiedad_NODO_XML("tfd", "TimbreFiscalDigital", "UUID")

        If folio Is Nothing Then
            folio = "SIN FOLIO"
        End If

        cmb_xmlAgregados.Items.Add(uuid & " | Folio: " & folio & " | " & Herramientas.Conversiones.Formatos.DoubleAMoneda(importe))
        facturasXML.Add(xmlTemp)

        CalcularTotalIngresosXML()
        LimpiarControlesIngresos()
    End Sub

    Private Sub btn_QuitarXMLCombo_Click(sender As Object, e As EventArgs) Handles btn_QuitarXMLCombo.Click
        If Not cmb_xmlAgregados.SelectedItem Is Nothing Then
            facturasXML.RemoveAt(cmb_xmlAgregados.SelectedIndex)
            cmb_xmlAgregados.Items.RemoveAt(cmb_xmlAgregados.SelectedIndex)
            CalcularTotalIngresosXML()
        End If
    End Sub

    Private Function CalcularTotalIngresosXML()
        Dim suma As Double = 0
        For Each item In cmb_xmlAgregados.Items
            Dim importe As Double = Herramientas.Conversiones.Formatos.StringFormatoDineroADouble(item.ToString().Split("|")(2).Trim())
            suma = suma + importe

        Next
        txt_totalXML.Text = Herramientas.Conversiones.Formatos.DoubleAMoneda(suma)
    End Function

    Private Sub tc_tabs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tc_tabs.SelectedIndexChanged
        If tc_tabs.SelectedIndex = 0 Then
            CalcularTotalNomina()
        ElseIf tc_tabs.SelectedIndex = 1 Then
            CalcularTotalIngresosXML()
        End If
    End Sub

    Private Sub dgv_polizas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_polizas.CellDoubleClick
        If dgv_polizas.SelectedRows.Count > 0 Then
            Dim poliza As String = dtPolizasConsulta(dgv_polizas.SelectedRows(0).Index)("Póliza")
            Dim montoTotal As String = dtPolizasConsulta(dgv_polizas.SelectedRows(0).Index)("Importe")

            Dim ban As Boolean = True
            If tc_tabs.SelectedIndex = 0 Then
                ban = False
            End If

            Dim verXMLDEPOliza As New VerXMLAdjuntosDePoliza(poliza, dtEmpresas(cmb_empresasPolizas.SelectedIndex)("RFCEmisor").ToString(), montoTotal, True, ban)
            verXMLDEPOliza.ShowDialog()
            btn_consultar_polizas_Click(Nothing, Nothing)


        End If
    End Sub


    Private Sub chb_conXML_CheckedChanged(sender As Object, e As EventArgs) Handles chb_conXML.CheckedChanged
        If chb_conXML.Checked Then
            chb_sinXML.Checked = False
        End If
    End Sub

    Private Sub chb_sinXML_CheckedChanged(sender As Object, e As EventArgs) Handles chb_sinXML.CheckedChanged

        If chb_sinXML.Checked Then
            chb_conXML.Checked = False
        End If
    End Sub

    Private Sub btn_consultarPolizasFAC_XML_Click(sender As Object, e As EventArgs) Handles btn_consultarPolizasFAC_XML.Click

        If cmb_tipoPolizasFAC_XML.SelectedIndex = -1 Then

            Herramientas.Forms.Mensajes.Advertencia("Debe seleccionar un tipo de póliza antes.")
            Return

        End If

        Dim query As String = ""
        query += "select ID as [ID], cRFCReceptor as [RFC Receptor], cFactura as [Factura], cPoliza as [Póliza Cargo], ltrim(rtrim(cContenidoXML)) as [XML] from EMPRESAS..FAC_XML x "
        query += "where left(x.cPoliza, 8) = '" & dtTiposPolizasFAC_XML(cmb_tipoPolizasFAC_XML.SelectedIndex)("CTIPOPOLIZA") & cmb_EjercicioFAC_XML.SelectedItem.ToString() & cmb_mesFAC_XML.SelectedItem.ToString() & "' and x.sFormaPago is null and x.nRFCEmisor = " & nRFCEmisorFAC_XML & " and x.cEstatus = 'A'"

        dgv_polizasCargosFAC_XML.DataSource = dbAcceso.EjecutarConsulta(query)


        Herramientas.Forms.DataGridViewConf.CambiarWidhtDeColumnaDataGridView(dgv_polizasCargosFAC_XML, "ID", 40)
        Herramientas.Forms.DataGridViewConf.CambiarWidhtDeColumnaDataGridView(dgv_polizasCargosFAC_XML, "RFC Receptor", 120)
        Herramientas.Forms.DataGridViewConf.CambiarWidhtDeColumnaDataGridView(dgv_polizasCargosFAC_XML, "Factura", 120)
        Herramientas.Forms.DataGridViewConf.CambiarWidhtDeColumnaDataGridView(dgv_polizasCargosFAC_XML, "Póliza Cargo", 120)
        Herramientas.Forms.DataGridViewConf.CambiarWidhtDeColumnaDataGridView(dgv_polizasCargosFAC_XML, "XML", 300)

        Herramientas.Forms.DataGridViewConf.DesactivarOrdenamientoTodasColumnasDataGridView(dgv_polizasCargosFAC_XML)
        dgv_polizasCargosFAC_XML.Refresh()
        btn_AsignarPolizaSemana.Enabled = True

    End Sub

    Private Sub cmb_empresasPolizasFAC_XML_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_empresasPolizasFAC_XML.SelectedIndexChanged
        'trayendo los tipos de polias

        bdEmpresaPolizasFAC_XMLSeleccionada = dtEmpresas.Rows(cmb_empresasPolizasFAC_XML.SelectedIndex)("CBASEDDATOS")
        dtTiposPolizasFAC_XML = dbAcceso.EjecutarConsulta("select CTIPOPOLIZA, CDESCRIP from " & bdEmpresaPolizasFAC_XMLSeleccionada & "..TIPOSPOLIZAS")
        cmb_tipoPolizasFAC_XML.Items.Clear()

        nRFCEmisorFAC_XML = dtEmpresas(cmb_empresasPolizasFAC_XML.SelectedIndex)("RFCEmisor")

        For Each dr As DataRow In dtTiposPolizasFAC_XML.Rows
            cmb_tipoPolizasFAC_XML.Items.Add(dr("CTIPOPOLIZA") & " - " & dr("CDESCRIP"))
        Next
    End Sub

    Private Sub dgv_nomina_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_nomina.CellDoubleClick
        If dgv_nomina.SelectedRows.Count > 0 Then

            Dim indice As Integer = dgv_nomina.SelectedRows(0).Index
            Dim visor As New VisorXML(Herramientas.Forms.DataGridViewConf.ObtenerValorCelda(dgv_nomina, indice, "XML"))
            visor.ShowDialog()
        

        End If
    End Sub

    Private Sub btn_agregarPolizaFAC_XML_Click(sender As Object, e As EventArgs) Handles btn_agregarPolizaFAC_XML.Click

        If dgv_polizasCargosFAC_XML.SelectedRows.Count > 0 AndAlso dgv_polizasCargosFAC_XML.SelectedRows(0).Index >= 0 AndAlso cmb_polizasFAC_XML.Items.Count = 0 Then

            Dim sXML As String = Herramientas.Forms.DataGridViewConf.ObtenerValorCelda(dgv_polizasCargosFAC_XML, dgv_polizasCargosFAC_XML.SelectedRows(0).Index, "XML")

            Dim xml As New XML
            xml.XMLContenido = sXML

            Dim monto As Double = Convert.ToDouble(xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Comprobante", "total"))

            cmb_polizasFAC_XML.Items.Add(Herramientas.Forms.DataGridViewConf.ObtenerValorCelda(dgv_polizasCargosFAC_XML, dgv_polizasCargosFAC_XML.SelectedRows(0).Index, "ID") & " | " & Herramientas.Forms.DataGridViewConf.ObtenerValorCelda(dgv_polizasCargosFAC_XML, dgv_polizasCargosFAC_XML.SelectedRows(0).Index, "Póliza Cargo") & " | " & monto)
        End If
        CalcularTotalPolizasFAC_XML()
    End Sub

    Private Sub btn_quitarPolizaFAC_XML_Click(sender As Object, e As EventArgs) Handles btn_quitarPolizaFAC_XML.Click
        If cmb_polizasFAC_XML.Items.Count > 0 AndAlso cmb_polizasFAC_XML.SelectedIndex >= 0 Then
            cmb_polizasFAC_XML.Items.RemoveAt(cmb_polizasFAC_XML.SelectedIndex)
        End If
        CalcularTotalPolizasFAC_XML()
    End Sub
    Private Sub CalcularTotalPolizasFAC_XML()
        Dim total As Double
        total = 0
        If cmb_polizasFAC_XML.Items.Count > 0 Then
            For Each item As String In cmb_polizasFAC_XML.Items
                total += Convert.ToDouble(item.ToString().Split("|")(2))
            Next
        End If
        txt_totalXML.Text = Herramientas.Conversiones.Formatos.DoubleAMoneda(total)
    End Sub

    Private Sub dgv_polizasCargosFAC_XML_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_polizasCargosFAC_XML.CellDoubleClick
        If dgv_polizasCargosFAC_XML.SelectedRows.Count > 0 Then
            If e.ColumnIndex = 4 Then
                Dim indice As Integer = dgv_polizasCargosFAC_XML.SelectedRows(0).Index
                Dim visor As New VisorXML(Herramientas.Forms.DataGridViewConf.ObtenerValorCelda(dgv_polizasCargosFAC_XML, indice, "XML"))
                visor.ShowDialog()
            Else

                Dim sXML As String = Herramientas.Forms.DataGridViewConf.ObtenerValorCelda(dgv_polizasCargosFAC_XML, dgv_polizasCargosFAC_XML.SelectedRows(0).Index, "XML")

                Dim xml As New XML
                xml.XMLContenido = sXML

                Dim poliza As String = Herramientas.Forms.DataGridViewConf.ObtenerValorCelda(dgv_polizasCargosFAC_XML, dgv_polizasCargosFAC_XML.SelectedRows(0).Index, "Póliza Cargo")
                Dim monto As Double = Convert.ToDouble(xml.ObtenerValorDePropiedad_NODO_XML("cfdi", "Comprobante", "total"))

                Dim verXMLDEPOliza As New VerXMLAdjuntosDePoliza(poliza, nRFCEmisorFAC_XML, monto, False, False)
                verXMLDEPOliza.ShowDialog()
            End If
        End If
    End Sub
End Class