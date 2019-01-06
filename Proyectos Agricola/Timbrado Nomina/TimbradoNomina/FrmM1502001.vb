
Imports Sistema.Comunes.Comun.ClsTools
Imports Sistema.Comunes.Catalogos
Imports Sistema.Comunes.Catalogos.FabricaCatalogos
Imports Sistema.Comunes.Registros
Imports Sistema.Comunes.Registros.EscribanoRegistros
Imports Sistema.Comunes.Registros.FabricaRegistros
Imports Sistema.Comunes.Comun
Imports CFD
Imports Ini
Imports System.Net.Mail
Imports System.Net.Security
Imports System.Security.Cryptography.X509Certificates
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Collections.Generic
Imports System.Threading





Public Class FrmM1502001

#Region "Declaraciones"
    Private gDT_Archivos As DataTable


    Private gcCorreoElectronicoEmisor As String
    Private gcPasswordEmisor As String
    Private gcServidorSMTP As String
    Private gnPuertoSMTP As Integer
    Private gcCorreoElectronicoContacto As String


    Private gnCopias As Integer
    Private gFrmWait As New frmStatus

    Private gcRutaPDF As String
    Private gcRutaArchivoRPT As String

    Private gcRutaGlobalPDF As String
    Private gcRutaGlobalXML As String
    Private gcRutaArchivoXML As String
    Private gcRutaPrincipalXML As String = ""

    Private CatSemanas As New Catalogo(New MetaCatalogo("SEMANAS"))


    Private gArchivoIni As New Ini.IniFileController

    Private vcNomina As String = ""


#End Region

#Region "Funciones"

    Private Sub plActualizaFechasSemana()

        pgEstableceFechas(CboTemporada.SelectedValue, vcNomina, TxtSemana.Text, TxtFechaIni, TxtFechaFin)

        TxtFechaPago.Value = TxtFechaFin.Value.AddDays(3)

    End Sub
    Dim lista As New List(Of String)
    Dim valores As New List(Of String)
    Dim listaTipoTimbre As New List(Of String)
    Dim valoresTipoTimbre As New List(Of String)
    Private Sub LlenaCombos()

        lista.Add("Natura Culiacán")
        valores.Add("01")
        lista.Add("Natura Imuris")
        valores.Add("02")
        lista.Add("Administrativo Culiacán")
        valores.Add("03")
        lista.Add("Administrativo Imuris")
        valores.Add("04")


        listaTipoTimbre.Add("Semanal")
        valoresTipoTimbre.Add("")
        listaTipoTimbre.Add("Vacaciones")
        valoresTipoTimbre.Add("")
        listaTipoTimbre.Add("Aguinaldo")
        valoresTipoTimbre.Add("")
        listaTipoTimbre.Add("Liquidacion")
        valoresTipoTimbre.Add("")


        For Each a As String In lista
            cmb_Nomina.Items.Add(a)
        Next
        For Each a As String In listaTipoTimbre
            cmb_tipoTimbre.Items.Add(a)
        Next


    End Sub
    Private Sub cmb_Nomina_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_Nomina.SelectedIndexChanged

    End Sub

    Private Sub cmb_tipoTimbre_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_tipoTimbre.SelectedIndexChanged

    End Sub
    Private Sub PlConfiguraCatalogos()


        TxtSemana.CatalogoBase = CatSemanas

        CatSemanas.FiltroExtendido = "TEMPORADA = '" & CboTemporada.SelectedValue & "' AND CCVE_NOMINA = '" & vcNomina & "'"
    End Sub

    Private Sub plCreaPDF(ByVal prmId As String)

        Dim oRpt = New ReportDocument
        Dim Proc As New System.Diagnostics.Process

        Try

            oRpt.Load(gcRutaArchivoRPT)

            LoginCR(oRpt, DAO.GetNombreServidor, DAO.GetNombreBaseDeDatos, DAO.GetLoginUsuario, DAO.GetPassUsuario)

            AgregarParametro("@cId", prmId, oRpt)

            Dim oStrem As New System.IO.MemoryStream
            oStrem = CType(oRpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat), System.IO.MemoryStream)

            If System.IO.File.Exists(gcRutaPDF & "\" & prmId & ".pdf") Then
                Kill(gcRutaPDF & "\" & prmId & ".pdf")
            End If

            gcRutaGlobalPDF = gcRutaPDF & "\" & prmId & ".pdf"

            'Si lo deseamos escribimos el pdf a disco.
            Dim ArchivoPDF As New System.IO.FileStream(gcRutaPDF & "\" & prmId & ".pdf", IO.FileMode.Create)
            ArchivoPDF.Write(oStrem.ToArray, 0, oStrem.ToArray.Length)
            ArchivoPDF.Flush()
            ArchivoPDF.Close()



        Catch ex As Exception
            MuestraMensajeSistFact(ex.Message, MessageBoxIcon.Information)

        End Try

    End Sub

    Friend Sub AgregarParametro(ByVal sNomCampo As String, ByVal xValCampo As String, ByRef oRpt As ReportDocument)


        Dim xGrupoValor As CrystalDecisions.Shared.ParameterValues

        Dim xValor As CrystalDecisions.Shared.ParameterDiscreteValue

        xGrupoValor = New CrystalDecisions.Shared.ParameterValues

        xValor = New CrystalDecisions.Shared.ParameterDiscreteValue

        xValor.Value = xValCampo

        xGrupoValor.Add(xValor)

        oRpt.DataDefinition.ParameterFields(sNomCampo).ApplyCurrentValues(xGrupoValor)

    End Sub

    Public Function LoginCR(ByVal cr As ReportDocument, ByVal sServidor As String, ByVal sBaseDatos As String, ByVal sUsuario As String, ByVal sPwd As String) As Boolean

        Dim oInfo As New ConnectionInfo

        Dim subObj As SubreportObject

        Dim obj As ReportObject

        oInfo.ServerName = sServidor

        oInfo.DatabaseName = sBaseDatos

        oInfo.UserID = sUsuario

        oInfo.Password = sPwd

        If Not AplicarCR(cr, oInfo) Then

            Return False

        End If

        For Each obj In cr.ReportDefinition.ReportObjects

            If obj.Kind = ReportObjectKind.SubreportObject Then

                subObj = obj

                If (Not AplicarCR(cr.OpenSubreport(subObj.SubreportName), oInfo)) Then

                    Return False

                End If

            End If

        Next obj

        Return True

    End Function


    Private Function AplicarCR(ByVal cr As ReportDocument, ByVal oInfo As ConnectionInfo) As Boolean

        Dim tInfo As TableLogOnInfo

        Dim tbl As Table

        'A cada tabla se le aplica logon info



        For Each tbl In cr.Database.Tables

            tInfo = tbl.LogOnInfo

            tInfo.ConnectionInfo = oInfo

            tbl.ApplyLogOnInfo(tInfo)

            'Verificar si el LOGIN fue correcto

            If tbl.TestConnectivity() Then

                'Cambiar Ubicación

                If tbl.Location.IndexOf(".") > 0 Then

                    tbl.Location = tbl.Location.Substring(tbl.Location.LastIndexOf(". ") + 1)

                Else

                    tbl.Location = tbl.Location

                End If
            Else

                Return False

            End If

        Next tbl

        Return True

    End Function



    Private Function flValidaDatos() As Boolean

        If FgValidaControlesObligatoriosAlGrabar(Me) Then
            Return True
        Else
            Return False
        End If

    End Function


#End Region



#Region "Procedimientos"
    Private Sub CargaParametrosGenerales()


        Dim nSerie As Integer = DatosEmpresaStatic.nSerie
        Dim rfcEmisor As Integer = DatosEmpresaStatic.rfcEmisor

        gArchivoIni.OpenINIFile(fgObtenParametroFE("RUTAINI", nSerie, rfcEmisor))


        gcRutaPDF = fgObtenParametroFE("RUTAPDF", nSerie, rfcEmisor)
        gcRutaArchivoRPT = fgObtenParametroFE("RUTAARCHIVORPTFACT", nSerie, rfcEmisor)

        gcCorreoElectronicoEmisor = fgObtenParametroFE("CORREOEMISOR", nSerie, rfcEmisor)
        gcPasswordEmisor = fgObtenParametroFE("PASSKEY", nSerie, rfcEmisor)
        gcServidorSMTP = fgObtenParametroFE("SERVIDORSMTP", nSerie, rfcEmisor)
        gnPuertoSMTP = IIf(fgObtenParametroFE("PUERTOSMTP", nSerie, rfcEmisor) = "", 0, fgObtenParametroFE("PUERTOSMTP", nSerie, rfcEmisor))
        gcCorreoElectronicoContacto = fgObtenParametroFE("CORREOCONTACTO", nSerie, rfcEmisor)
        gcRutaArchivoXML = fgObtenParametroFE("DESTINOXML", nSerie, rfcEmisor)
        gcRutaPrincipalXML = fgObtenParametroFE("DESTINOXML", nSerie, rfcEmisor)


        gArchivoIni.CloseINIFile()

    End Sub

    Private Sub PlLimpiarControles(Optional ByVal prmBan As Boolean = True)

        If gDT_Archivos IsNot Nothing Then
            gDT_Archivos.Rows.Clear()
        End If

        TxtFechaPago.Value = DAO.RegresaFechaDelSistema

    End Sub



    'Configurar los XtraGrids al cargar la pantalla
    Private Sub PlConfiguraGrid()
        'Crear los DataTables

        gDT_Archivos = DSFacturaElectronica.Tables("DtArchivos")
        'Configurar las fuente de datos del XtraGrid

        GrdFacturaElectronica.DataSource = gDT_Archivos
        GrdFacturaElectronica.Refresh()
        'Crear los Manejadores para el XtraGrid

        MxGrdArchivos = New DriverXtraGrid(GrdFacturaElectronica)
        'Definir el estilo para el XtraGrid
        With MxGrdArchivos
            .Estilo = DriverXtraGrid.Estilos.Captura
            .AgregarRenglonAutomatico = True
            .EliminacionDeRenglonesActivada = True
            .TituloMessageBox = GlobalSistemaCaption
            .NoLanzarErrorEnCasoDeError = True
        End With

    End Sub


    Private Function FlMarcarSeleccion(ByRef prmDataTable As DataTable, ByRef prmGridView As Object, ByRef prmColumna As Object, Optional ByRef prmRow As DataRowView = Nothing) As Boolean
        Dim vbBand As Boolean
        Dim vRows() As DataRow

        vRows = prmDataTable.Select("")

        'For Each vRow As DataRow In vRows
        '    vRow("bSeleccion") = False
        '    prmDataTable.AcceptChanges()
        'Next


        If prmRow Is Nothing Then
            prmRow = prmGridView.GetRow(prmGridView.FocusedRowHandle)
        End If

        If Not prmRow Is Nothing Then
            If Not prmRow(prmColumna.FIELDNAME) Is DBNull.Value Then
                prmRow(prmColumna.FIELDNAME) = Not prmRow(prmColumna.FIELDNAME)
            Else
                prmRow(prmColumna.FIELDNAME) = True
            End If
            'Para modificar valores del Anticipo a aplicar
            prmDataTable.AcceptChanges()
            vbBand = True
        End If
        Return vbBand
    End Function



#End Region

#Region "Eventos"

    Private Sub FrmM1502001_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        dbAcceso = New Herramientas.SQL.SQLServer()
        dbAcceso.ConfigurarConexion(frmPrincipal.Servidor, frmPrincipal.BD, frmPrincipal.Usuario, frmPrincipal.Contra)

        DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = True
        PgLlenaComboTiposDato("25", CboTipoPago, False)

        PgLlenaComboGeneral("CCVE_TEMPORADA", "CNOMBRE", "CTL_TEMPORADAS", CboTemporada)
        vcNomina = "03"
        CboTemporada.SelectedValue = fgObtenParametroNomina("CCVE_TEMPORADA")
        TxtSemana.Text = fgObtenParametroNomina("CSEMANA")
        DAO = DataAccessCls.DevuelveInstancia
        PlLimpiarControles()
        CargaParametrosGenerales()
        PlConfiguraGrid()
        HabilitarBotones()
        OptAdmin.Checked = True

        PlConfiguraCatalogos()
        plActualizaFechasSemana()
        LlenaCombos()

        TimbresRestantes()

        'Dim bdAnterior As String = DAO.GetNombreBaseDeDatos()
        'DAO.SetNombreBaseDeDatos("EMPRESAS")
        'CatSemanas = New Catalogo(New MetaCatalogo("SEMANAS"))
        'DAO.SetNombreBaseDeDatos(bdAnterior)

    End Sub


    Private Sub BtnFact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTimbrar.Click


        pb_progreso.Value = 0

        hProcesoPrincipal = New Thread(AddressOf EjecutarProceso)
        hProcesoPrincipal.Start("Timbrar")

        'EjecutarProceso(TipoOperacion.Timbrar)

    End Sub
    Public Enum TipoOperacion
        Timbrar
        Cancelar
    End Enum
    Private hProcesoPrincipal As Thread
    Private Function CrearPDF(ByVal nFActura As String, ByVal nRFCEmisor As String, ByVal rutaArchivos As String) As String
        Dim gcRutaArchivoPDF As String = rutaArchivos & "\" & nRFCEmisor & "_" & nFActura & ".pdf"

        Dim oRpt = New ReportDocument
        Dim Proc As New System.Diagnostics.Process
        Try

            oRpt.Load("Reportes\RPTCFDINOM.rpt")
            LoginCR(oRpt, DAO.GetNombreServidor, "EMPRESAS", DAO.GetLoginUsuario, DAO.GetPassUsuario)
            AgregarParametro("@prmFactura", nFActura, oRpt)


            'oRpt.SetParameterValue("pmnfactura", nFActura, "rptcfdinom_detalle_percepciones.rpt")
            'oRpt.SetParameterValue("@prmFactura", nFActura, "rptcfdinom_detalle_percepciones.rpt")

            'oRpt.SetParameterValue("pmnfactura", nFActura, "rptcfdinom_detalle_deducciones.rpt")
            'oRpt.SetParameterValue("@prmFactura", nFActura, "rptcfdinom_detalle_deducciones.rpt")


            'Dim mySubReportObject As CrystalDecisions.CrystalReports.Engine.SubreportObject
            'Dim mySubRepDoc As New CrystalDecisions.CrystalReports.Engine.ReportDocument

            'For index = 0 To oRpt.ReportDefinition.Sections.Count - 1
            '    For counter = 0 To oRpt.ReportDefinition.Sections(index).ReportObjects.Count - 1
            '        With oRpt.ReportDefinition.Sections(index)
            '            If .ReportObjects(counter).Kind = ReportObjectKind.SubreportObject Then
            '                mySubReportObject = CType(.ReportObjects(counter), CrystalDecisions.CrystalReports.Engine.SubreportObject)
            '                mySubRepDoc = mySubReportObject.OpenSubreport(mySubReportObject.SubreportName)

            '                mySubRepDoc.SetParameterValue(0, nFActura)
            '                mySubRepDoc.SetParameterValue(1, nFActura)

            '            End If
            '        End With
            '    Next
            'Next



            '--------------------------------------------

            'AgregarParametro("@nRFCEmisor", atrRFCEmisor, oRpt)
            'AgregarParametro("@cSerie", gObjRegistro.SERIE.Trim, oRpt)
            'AgregarParametro("@nFolio", gObjRegistro.FACTURA, oRpt)
            Dim oStrem As New System.IO.MemoryStream
            oStrem = CType(oRpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat), System.IO.MemoryStream)

            'If gObjRegistro.SERIE.Trim = "" Then
            '    gcRutaArchivoPDF = gcRutaPDF & "\" & gcRFCEmisor & "_" & gObjRegistro.FACTURA & ".pdf"
            'Else
            '    gcRutaArchivoPDF = gcRutaPDF & "\" & gcRFCEmisor & "_" & gObjRegistro.SERIE & "" & gObjRegistro.FACTURA & ".pdf"
            'End If

            If System.IO.File.Exists(gcRutaArchivoPDF) Then
                Kill(gcRutaArchivoPDF)
            End If

            'Si lo deseamos escribimos el pdf a disco.
            Dim ArchivoPDF As New System.IO.FileStream(gcRutaArchivoPDF, IO.FileMode.Create)
            ArchivoPDF.Write(oStrem.ToArray, 0, oStrem.ToArray.Length)
            ArchivoPDF.Flush()
            ArchivoPDF.Close()

            'abrir el archivo de pdf
            'If System.IO.File.Exists(gcRutaArchivoPDF) Then
            '    Proc.StartInfo.FileName = gcRutaArchivoPDF
            '    Proc.Start()
            'End If

            Return "Enviado a: " & gcRutaArchivoPDF
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Private Sub EjecutarProceso(ByVal tipoOperacion As String)
        DeshabilitarPantalla()

        Try
            'gFrmWait.Show("Comprobando si hay Internet")
            Dim velocidad As Double = Herramientas.Net.Internet.ObtenerVelocidadInternet
            If velocidad = 0 Then
                Herramientas.Forms.Mensajes.Error("No hay conexión a internet")
                HabilitarPantalla()
                Exit Sub
            End If

            If tipoOperacion.Equals("Timbrar") Then
                Dim vObjNomina As New ClsCFDI32
                Dim vcRespuesta As String = ""
                Dim vRows() As DataRow
                Dim vnErroresTotal As Integer = 0
                Dim vnErroresConsecutivos As Integer = 0
                Dim vcRutaXML As String = gcRutaPrincipalXML


                vcRutaXML = UCase(gcRutaPrincipalXML)

                If Not Directory.Exists(vcRutaXML) Then
                    Directory.CreateDirectory(vcRutaXML)
                End If

                vcRutaXML = UCase(gcRutaPrincipalXML & "\" & TxtFechaFin.Value.Year)

                If Not Directory.Exists(vcRutaXML) Then
                    Directory.CreateDirectory(vcRutaXML)
                End If


                vcRutaXML = UCase(gcRutaPrincipalXML & "\" & TxtFechaFin.Value.Year & "\" & IIf(OptAdmin.Checked = True, "ADMVA", IIf(OptCampo.Checked = True, "CAMPO", "EMPAQUE")))

                If Not Directory.Exists(vcRutaXML) Then
                    Directory.CreateDirectory(vcRutaXML)
                End If

                vcRutaXML = UCase(gcRutaPrincipalXML & "\" & TxtFechaFin.Value.Year & "\" & IIf(OptAdmin.Checked = True, "ADMVA", IIf(OptCampo.Checked = True, "CAMPO", "EMPAQUE")) & "\" & fgPonceros(TxtSemana.Text, 2) & " DEL " & fgFechaMediana(TxtFechaIni.Value) & " AL " & fgFechaMediana(TxtFechaFin.Value))

                If Not Directory.Exists(vcRutaXML) Then
                    Directory.CreateDirectory(vcRutaXML)
                End If

                Dim contadorTRabajadores As Integer = 0

                vRows = gDT_Archivos.Select("bSeleccion = 1")


                Dim nrfcEmisor As Integer = 0
                'dbAcceso.EjecutarConsulta("select * from empresas..fac_emisores where cRFC = '" + +"'")



                Dim contador As Integer = 1
                For Each vRow As DataRow In vRows

                    'If Not fgTimbradoPrevio(vRow("nFactura"), vRow("nFolio")) Then
                    If vRow("uuid").ToString().Equals("") Then
                        vRow("cExitoError") = "Validando CURP y RFC..."
                        If fgValidaCURP(vRow("nFactura")) Then
                            If (fgValidaRFC(vRow("nFactura"))) Then
                                'DAO.AbreTransaccion()

                                vRow("cExitoError") = "<<            Timbrando...          >>"

                                'gFrmWait.Show("Timbrando...")

                                vObjNomina.AsignaConexion(DAO)
                                vcRespuesta = vObjNomina.GeneraFacturaElectronica(vRow("nFactura"), DatosEmpresaStatic.rfcEmisor, True)
                                TimbresRestantes()
                                'vcRespuesta = "testeando..."

                                gFrmWait.Visible = False

                                If vcRespuesta <> "" Then
                                    vnErroresTotal += 1
                                    vnErroresConsecutivos += 1
                                    vRow("cExitoError") = vcRespuesta
                                    'DAO.DeshaceTransaccion()
                                Else

                                    'gFrmWait.Show("Actualizando datos...")

                                    If Not ActualizaDatosTimbrado(vRow("nFactura")) Then
                                        vnErroresTotal += 1
                                        vnErroresConsecutivos += 1
                                        'DAO.DeshaceTransaccion()
                                        vRow("cExitoError") = "Error al actualizar los datos de timbrado."
                                    Else
                                        vnErroresConsecutivos = 0
                                        contadorTRabajadores = contadorTRabajadores + 1
                                        vRow("cExitoError") = "Timbrado Exitoso!"
                                        vRow("uuid") = "UUDI CARGADO"
                                        'DAO.CierraTransaccion()
                                    End If

                                    'gFrmWait.Visible = False
                                End If

                                gDT_Archivos.AcceptChanges()
                                GrdFacturaElectronica.DataSource = gDT_Archivos
                                GrdFacturaElectronica.Refresh()
                            Else
                                vRow("cExitoError") = "ERROR: El RFC no tiene la longitud correcta."
                            End If
                        Else
                            vRow("cExitoError") = "ERROR: La CURP no tiene la longitud correcta."
                        End If


                    End If

                    If vnErroresConsecutivos = 5 Or vnErroresTotal = 10 Then
                        MuestraMensajeSistFact("Han ocurrido muchos errores continunos, favor de verificar", MessageBoxIcon.Information)
                        HabilitarPantalla()
                        Exit For
                    End If

                    pb_progreso.Value = 100 * contador / vRows.Count
                    contador = contador + 1
                Next
                'enviar aqui a PDF
                Herramientas.Forms.Mensajes.Informacion("El proceso ha sido ejecutado y se timbraron " & contadorTRabajadores & " trabajadores!")
            ElseIf tipoOperacion.Equals("Cancelar") Then
                Dim vRows() As DataRow
                vRows = gDT_Archivos.Select("bSeleccion = 1")
                Dim contador As Integer = 1
                Dim wsTEst As New CFD.ClsCFDI32



                Dim huboErrores As Boolean = False
                For Each vRow As DataRow In vRows
                    '-----------------
                    Try
                        vRow("cExitoError") = "<<            Cancelando...          >>"
                        Dim nFactura As String = vRow("nFactura").ToString()
                        Dim uuid As String = vRow("uuid").ToString()
                        'nFactura = nFactura.Substring(0, nFactura.Length - 1)
                        If Not uuid.Equals("") Then
                            Dim resultado As String() = wsTEst.CancelaFacturaElectronica(nFactura)
                            vRow("cExitoError") = resultado(0)

                            TimbresRestantes()

                            'aqui verificar un error de conexión y cancelar la eliminacion 
                            'de los registros

                            If resultado(1).Trim().Equals("") Then
                                vRow("cExitoError") += " - No se eliminaron los registros."
                                huboErrores = True
                                Continue For
                            End If

                            Dim resCanc As String = ProcesoCancelacion(nFactura, resultado(1))
                            If resCanc.Equals("") Then
                                vRow("cExitoError") = "Timbre cancelado exitosamente."
                            Else
                                vRow("cExitoError") = "Cancelado en SAT, pero ocurrió un error al eliminar los registros: " + resCanc
                                huboErrores = True
                            End If
                        Else
                            Dim resCanc As String = ProcesoCancelacion(nFactura, "")
                            If resCanc.Equals("") Then
                                vRow("cExitoError") = "Cancelación exitosa, aún no se había timbrado."
                            Else
                                vRow("cExitoError") = "Ocurrió un error al eliminar los registros: " + resCanc
                                huboErrores = True
                            End If
                        End If

                    Catch ex As Exception
                        vRow("cExitoError") = "Error: " + ex.Message
                        huboErrores = True
                    End Try

                    '-----------------
                    pb_progreso.Value = 100 * contador / vRows.Count
                    contador = contador + 1
                Next

                Dim mensajeFinal As String = "Se han realizado las cancelaciones de forma exitosa."

                If (huboErrores) Then
                    mensajeFinal = "Se terminó el proceso de timbrado con algunos errores."

                End If
                Herramientas.Forms.Mensajes.Informacion(mensajeFinal)
            ElseIf tipoOperacion.StartsWith("APDF") Then
                Dim vRows() As DataRow
                vRows = gDT_Archivos.Select("bSeleccion = 1")
                Dim contador As Integer = 1
                Dim wsTEst As New CFD.ClsCFDI32
                Dim huboErrores As Boolean = False
                For Each vRow As DataRow In vRows
                    '-----------------
                    Try
                        vRow("cExitoError") = "<<            Enviando a PDF...          >>"
                        Dim nFactura As String = vRow("nFactura").ToString()
                        'nFactura = nFactura.Substring(0, nFactura.Length - 1)
                        If Not vRow("uuid").ToString().Equals("") Then
                            vRow("cExitoError") = CrearPDF(vRow("nFactura").ToString(), vRow("cRFCEmisor").ToString(), tipoOperacion.Split(New Char() {"|"c})(1))
                        Else
                            vRow("cExitoError") = "No se encuentra timbrado aún."
                        End If

                    Catch ex As Exception
                        vRow("cExitoError") = "Error: " + ex.Message
                        huboErrores = True
                    End Try

                    '-----------------
                    pb_progreso.Value = 100 * contador / vRows.Count
                    contador = contador + 1
                Next

                Dim mensajeFinal As String = "Se han realizado las cancelaciones de forma exitosa."

                If (huboErrores) Then
                    mensajeFinal = "Se terminó el proceso de timbrado con algunos errores."

                End If

                Herramientas.Forms.Mensajes.Informacion(mensajeFinal)
            End If
        Catch ex As Exception
            Herramientas.Forms.Mensajes.Error(ex.Message)
        End Try
        HabilitarPantalla()
    End Sub

    Private Sub TimbresRestantes()
        Try
            Dim wsTEst As New CFD.ClsCFDI32
            txt_timbresRestantes.Text = wsTEst.TimbresLibres(DatosEmpresaStatic.CRFC)
        Catch
        End Try
    End Sub
    Private Function ProcesoCancelacion(ByVal nFactura As String, ByVal acuseXML As String) As String
        Try
            'agregando log de cancelado
            dbAcceso.IniciarTransaccion()

            Dim parametros As New List(Of Object)
            parametros.Add(acuseXML)

            Dim queryLog As String = ""
            queryLog &= "insert empresas..fac_cfdinomina_cancelaciones "
            queryLog &= "select enc.nFactura, emi.cRFC, enc.nRFCEmisor, enc.nFolio, enc.nSerie, enc.NIMPORTE, case when enc.UUID is null then '' else enc.UUID end as UUID, case when enc.DFECHATIMBRADO is null then CAST('1900-01-01' AS DATETIME2) else enc.DFECHATIMBRADO end as DFECHATIMBRADO, enc.cRFCCliente, enc.CCVE_EMPL, case when tim.cContenidoXML is null then '' else tim.cContenidoXML end as cContenidoXML, GETDATE() as dFechaCancelacion, @acuse from empresas..FAC_ENCFACTURASCFDINOM enc "
            queryLog &= "inner join empresas..FAC_DETFACTURASCFDINOM det on enc.nFactura = det.nFactura "
            queryLog &= "inner join empresas..FAC_EMISORES emi on enc.nRFCEmisor = emi.nRFCEmisor "
            queryLog &= "left join empresas..FAC_XMLFACTURAS_TIMBRES tim on enc.nFactura = tim.nFactura "
            queryLog &= "where enc.nFactura = '" & nFactura & "' "
            dbAcceso.EjecutarConsulta(queryLog, parametros)
            'eliminando los registros generados en diferentes tablas de operaciones
            'dbAcceso.EjecutarConsulta(queryLog)
            dbAcceso.EjecutarConsulta("delete  empresas..FAC_ENCFACTURASCFDINOM where nFactura = '" & nFactura & "'")
            dbAcceso.EjecutarConsulta("delete  empresas..FAC_DETFACTURASCFDINOM where nFactura = '" & nFactura & "'")
            dbAcceso.EjecutarConsulta("delete  empresas..FAC_DEDUCCIONESCFDINOM where nFactura = '" & nFactura & "'")
            dbAcceso.EjecutarConsulta("delete  empresas..FAC_ENCABEZADOCFDINOM where nFactura = '" & nFactura & "'")
            dbAcceso.EjecutarConsulta("delete  empresas..FAC_RETENCIONESCFDINOM  where nFactura = '" & nFactura & "'")
            dbAcceso.EjecutarConsulta("delete  empresas..FAC_RETENCIONES  where nFactura = '" & nFactura & "'")
            dbAcceso.EjecutarConsulta("delete  empresas..FAC_PERCEPCIONESCFDINOM  where nFactura = '" & nFactura & "'")
            dbAcceso.EjecutarConsulta("delete  empresas..FAC_DEDUCCIONESCFDINOM where nFactura = '" & nFactura & "'")
            dbAcceso.EjecutarConsulta("delete  empresas..FAC_CFDINOMINA where nfactura like '" & nFactura & "%' ")
            dbAcceso.EjecutarConsulta("delete  empresas..FAC_XMLFACTURAS_TIMBRES where nFactura = '" & nFactura & "'")
            dbAcceso.TerminarTransaccion()
            Return ""
        Catch ex As Exception
            dbAcceso.DeshacerTransaccion()
            Return ex.Message
        End Try
    End Function
    Public Sub HabilitarPantalla()
        btn_cancelarTimbre.Enabled = True
        btn_rfc.Enabled = True
        btn_numDiasCorregir.Enabled = True
        BtnTimbrar.Enabled = True
        BtnConsultar.Enabled = True
        btn_EnviarPDF.Enabled = True
        btn_marcarTodos.Enabled = True
        btn_DesmarcarTodos.Enabled = True
    End Sub

    Public Sub DeshabilitarPantalla()
        btn_cancelarTimbre.Enabled = False
        btn_rfc.Enabled = False
        btn_numDiasCorregir.Enabled = False
        BtnTimbrar.Enabled = False
        BtnConsultar.Enabled = False
        btn_EnviarPDF.Enabled = False
        btn_marcarTodos.Enabled = False
        btn_DesmarcarTodos.Enabled = False
    End Sub

    Public Shared Function ActualizaRFC(ByVal prmID As Long)
        'funcion q actualiza los rfc q dieron error.

        Dim vlSQL As String
        Dim DT As New DataTable
        Dim DAO As Sistema.DataAccessCls = DataAccessCls.DevuelveInstancia

        Try

            vlSQL = ""

            DAO.RegresaConsultaSQL(vlSQL, DT)

        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function
    Public Shared Function ActualizaDatosTimbrado(ByVal prmID As Long) As Boolean

        Dim vParam(1) As Object
        Dim vlSQL As String
        Dim DS As New DataSet
        Dim DAO As Sistema.DataAccessCls = DataAccessCls.DevuelveInstancia
        Dim bdAnterior As String
        bdAnterior = DAO.GetNombreBaseDeDatos
        Try
            DAO.SetNombreBaseDeDatos("EMPRESAS")
            vParam(0) = prmID
            vParam(1) = DatosEmpresaStatic.rfcEmisor

            vlSQL = "Sp_MTTOFAC_ENC_ACTUALIZADATOSTIMBRADONOMINA"

            If Not DAO.RegresaConsultaSQL(vlSQL, DS, vParam) Then
                DAO.SetNombreBaseDeDatos(bdAnterior)
                Return False
            End If

        Catch ex As Exception
            DAO.SetNombreBaseDeDatos(bdAnterior)
            Return False
        End Try
        DAO.SetNombreBaseDeDatos(bdAnterior)
        Return True

    End Function


    Public Shared Function fgTimbradoPrevio(ByVal prmID As Long, ByVal prmNFolio As Long) As Boolean


        Dim vlSQL As String
        Dim DT As New DataTable
        Dim DAO As Sistema.DataAccessCls = DataAccessCls.DevuelveInstancia

        Try

            'vlSQL = "SELECT * FROM EMPRESAS..FAC_ENCFACTURASCFDINOM(NOLOCK) WHERE RTRIM(LTRIM(CONVERT(VARCHAR(20),nFactura)))+RTRIM(LTRIM(CONVERT(VARCHAR(20),nRFCEmisor))) = " & prmID & " AND UUID IS NULL"

            Dim prmIDString As String = prmID.ToString()
            prmIDString = prmIDString.Substring(0, prmIDString.Length - 1)

            vlSQL = "select uuid from empresas..FAC_ENCFACTURASCFDINOM where nFactura = '" & prmIDString & "' and nFolio = " & prmNFolio & " and uuid is null"

            'vlSQL = "SELECT * FROM EMPRESAS..FAC_CFDINOMINA where id = " & prmID


            DAO.RegresaConsultaSQL(vlSQL, DT)

            If DT.Rows.Count > 0 Then
                Return False
            End If
            Return True

        Catch ex As Exception
            Return True
        End Try

        Return True

    End Function


    Public Shared Function fgValidaCURP(ByVal prmID As Long) As Boolean


        Dim vlSQL As String
        Dim DT As New DataTable
        Dim DAO As Sistema.DataAccessCls = DataAccessCls.DevuelveInstancia

        Try

            Dim prmIDString As String = prmID.ToString()
            'prmIDString = prmIDString.Substring(0, prmIDString.Length - 1)

            vlSQL = "SELECT FE.*"
            vlSQL = vlSQL & vbCrLf & "FROM EMPRESAS..FAC_ENCFACTURASCFDINOM FE(NOLOCK) "
            vlSQL = vlSQL & vbCrLf & "JOIN EMPRESAS..FAC_ENCABEZADOCFDINOM FN(NOLOCK) ON FN.NFACTURA = FE.NFACTURA"
            vlSQL = vlSQL & vbCrLf & "WHERE FE.nFactura = " & prmIDString & " AND FE.UUID IS NULL"
            vlSQL = vlSQL & vbCrLf & "AND LEN(COALESCE(FN.CURP,'')) = 18"

            DAO.RegresaConsultaSQL(vlSQL, DT)

            If Not DT Is Nothing AndAlso DT.Rows.Count > 0 Then
                Return True
            End If
            Return False

        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function
    Public Shared Function fgValidaRFC(ByVal prmID As Long) As Boolean


        Dim vlSQL As String
        Dim DT As New DataTable
        Dim DAO As Sistema.DataAccessCls = DataAccessCls.DevuelveInstancia

        Try

            Dim prmIDString As String = prmID.ToString()
            'prmIDString = prmIDString.Substring(0, prmIDString.Length - 1)

            vlSQL = "SELECT FE.*"
            vlSQL = vlSQL & vbCrLf & "FROM EMPRESAS..FAC_ENCFACTURASCFDINOM FE(NOLOCK) "
            vlSQL = vlSQL & vbCrLf & "JOIN EMPRESAS..FAC_ENCABEZADOCFDINOM FN(NOLOCK) ON FN.NFACTURA = FE.NFACTURA"
            vlSQL = vlSQL & vbCrLf & "WHERE FE.nFactura = " & prmIDString & " AND FE.UUID IS NULL"
            vlSQL = vlSQL & vbCrLf & "AND LEN(COALESCE(ltrim(rtrim(FE.cRFCCliente)),'')) = 13"

            DAO.RegresaConsultaSQL(vlSQL, DT)

            If Not DT Is Nothing AndAlso DT.Rows.Count > 0 Then
                Return True
            End If
            Return False

        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function

    Private Sub HabilitarBotones()
        Nuevo = True
        Eliminar = True
        Guardar = True
        Imprimir = True
        Configurar = True
        Ejecutar = True
    End Sub



    Protected Overrides Sub ClickBotonEjecutar()


        If OptEmpaque.Checked Or OptAdmImuris.Checked Then
            plProcesaAdmin()
        Else
            plProcesaEven()
        End If

        gDT_Archivos = fgRegresaDatosNomina(CboTemporada.SelectedValue, TxtSemana.Text, vcNomina)

        GrdFacturaElectronica.DataSource = gDT_Archivos
        GrdFacturaElectronica.Refresh()

    End Sub



    Private Sub plProcesaAdmin()
        If Not fgProcesaDatosNominaAdm(CboTemporada.SelectedValue, TxtSemana.Text, vcNomina, TxtFechaPago.Value) Then
            MuestraMensajeSistFact("Ocurrio un error al procesar la información, favor de verificar", MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub plProcesaEven()
        If Not fgProcesaDatosNominaEve(CboTemporada.SelectedValue, TxtSemana.Text, vcNomina, TxtFechaPago.Value) Then
            MuestraMensajeSistFact("Ocurrio un error al procesar la información, favor de verificar", MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub ChkFacturar_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkFacturar.CheckedChanged

        Dim vDRowSeleecion As DataRowView
        Dim vbBand As Boolean



        vDRowSeleecion = GrvFactElectronica.GetRow(GrvFactElectronica.FocusedRowHandle)
        If Not (vDRowSeleecion Is Nothing) Then
            vbBand = FlMarcarSeleccion(gDT_Archivos, GrvFactElectronica, ColSeleccion, vDRowSeleecion)
        End If

    End Sub
    Private nominaTexto As String
    Private Sub OptAdmin_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptAdmin.CheckedChanged
        If OptAdmin.Checked Then
            nominaTexto = OptAdmin.Text
            vcNomina = "01"
            PlConfiguraCatalogos()
            plActualizaFechasSemana()
        End If
    End Sub

    Private Sub OptCampo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptCampo.CheckedChanged
        If OptCampo.Checked Then
            nominaTexto = OptCampo.Text
            vcNomina = "02"
            PlConfiguraCatalogos()
            plActualizaFechasSemana()
        End If
    End Sub

    Private Sub OptEmpaque_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptEmpaque.CheckedChanged
        If OptEmpaque.Checked Then
            nominaTexto = OptEmpaque.Text
            vcNomina = "03"
            PlConfiguraCatalogos()
            plActualizaFechasSemana()
        End If
    End Sub
    Private Sub OptAdmImuris_CheckedChanged(sender As Object, e As EventArgs) Handles OptAdmImuris.CheckedChanged
        If OptAdmImuris.Checked Then
            nominaTexto = OptAdmImuris.Text
            vcNomina = "04"
            PlConfiguraCatalogos()
            plActualizaFechasSemana()
        End If
    End Sub

    Private Sub TxtSemana_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtSemana.Validating
        plActualizaFechasSemana()
    End Sub

    Private Sub BtnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConsultar.Click

        'If cmb_Nomina.SelectedIndex <> -1 And cmb_tipoTimbre.SelectedIndex <> -1 Then
        'vcNomina = cmb_Nomina.SelectedIndex
        PlConfiguraCatalogos()
        plActualizaFechasSemana()


        gDT_Archivos = fgRegresaDatosNomina(CboTemporada.SelectedValue, TxtSemana.Text, vcNomina)

        GrdFacturaElectronica.DataSource = gDT_Archivos
        GrdFacturaElectronica.Refresh()
        'Else
        'MsgBox("Seleccione una nómina y un tipo de timbrado.")
        'End If

    End Sub

#End Region

    Private Sub btn_rfc_Click(sender As Object, e As EventArgs) Handles btn_rfc.Click
        Try
            Dim semana As String = TxtSemana.Text
            Dim temporada As String = CboTemporada.SelectedValue



            Dim query As String
            query = "update f set f.cRFCCliente = UPPER(ltrim(rtrim(c.CRFC)))"
            query += vbCrLf & "FROM EMPRESAS..FAC_ENCFACTURASCFDINOM F"
            query += vbCrLf & "join " & DAO.GetNombreBaseDeDatos() & "..CTL_TRABAJADORES C ON left(F.NFACTURA,14)=REPLACE(C.CCVE_TEMPORADA,'-','')+C.CCVE_NOMINA+'" & semana & "'+C.CCVE_EMPL"
            query += vbCrLf & "WHERE C.CCVE_TEMPORADA = '" & temporada & "' and C.CCVE_NOMINA = '" & vcNomina & "'"

            Dim DT As New DataTable


            DAO.RegresaConsultaSQL(query, DT)

            Dim query2 As String
            query2 = "update f set f.CURP = UPPER(ltrim(rtrim(c.CCURP)))"
            query2 += vbCrLf & "FROM EMPRESAS..FAC_ENCABEZADOCFDINOM F"
            query2 += vbCrLf & "join " & DAO.GetNombreBaseDeDatos() & "..CTL_TRABAJADORES C ON left(F.NFACTURA,14)=REPLACE(C.CCVE_TEMPORADA,'-','')+C.CCVE_NOMINA+'" & semana & "'+C.CCVE_EMPL"
            query2 += vbCrLf & "WHERE C.CCVE_TEMPORADA = '" & temporada & "' and C.CCVE_NOMINA = '" & vcNomina & "'"

            Dim DT2 As New DataTable

            DAO.RegresaConsultaSQL(query2, DT2)

            MessageBox.Show("RFC y CURP Actualizados con Exito!!")
        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim listaNombres As New List(Of String)
        listaNombres.Add("Archivo PDF")
        Dim listaExtensiones As New List(Of String)
        listaExtensiones.Add("pdf")

        'Dim ruta As String = Herramientas.WPF.Utilidades.GuardarArchivoRuta(listaNombres, listaExtensiones)
        'If ruta <> Nothing Then

        '    'Dim view As DevExpress.XtraGrid.Views.Base.BaseView = GrdFacturaElectronica.MainView

        '    'Dim data As DevExpress.XtraGrid.Views.Grid.GridView = CType(view, DevExpress.XtraGrid.Views.Grid.GridView)


        '    'data.OptionsPrint.ExpandAllDetails = True
        '    'data.ExportToPdf(ruta)

        '    ''GrdFacturaElectronica.ExportToPdf(ruta)
        '    'Herramientas.WPF.Mensajes.Informacion("Exportación exitosa.")
        'End If
    End Sub

    Private Sub btn_guardarAPDF_Click(sender As Object, e As EventArgs)


        For Each dr As DataRow In gDT_Archivos.Rows
            dgv_datos.Rows.Add(dr(0).ToString(), dr(1).ToString(), dr(3).ToString())
        Next

        Dim descripciones As New List(Of String)
        descripciones.Add("Archivo PDF")
        Dim extensiones As New List(Of String)
        extensiones.Add("pdf")
        Dim nombreArchivo As String = "Temporada " + CboTemporada.SelectedValue.ToString + " " + nominaTexto + " semana " + TxtSemana.Text + ".pdf"
        Dim ruta As String = Herramientas.Archivos.Dialogos.GuardarArchivoRuta(descripciones, extensiones, nombreArchivo)
        If ruta <> Nothing Then
            Dim encabezados As New List(Of String)
            encabezados.Add("Resultados de timbrado de la semana " & TxtSemana.Text.Trim() & " de " & nominaTexto)
            encabezados.Add("Fecha: " + String.Format("{0:F}", DateTime.Now))

            'Herramientas.Archivos.PDF.ExportarDataGridViewToPDF(dgv_datos, ruta, encabezados, True)
        End If

    End Sub
    Private dbAcceso As Herramientas.SQL.SQLServer
    Private Sub btn_numDiasCorregir_Click(sender As Object, e As EventArgs) Handles btn_numDiasCorregir.Click
        Try
            Dim querySelect As String = "select count(*) from empresas..FAC_ENCABEZADOCFDINOM where nFactura like '" & CboTemporada.SelectedValue.ToString.Replace("-", "").Trim() & vcNomina & TxtSemana.Text & "%' and NumDiasPagados = 0"
            Dim dtRows As DataTable = dbAcceso.EjecutarConsulta(querySelect)

            Dim nRows As Integer = Convert.ToInt32(dtRows.Rows(0)(0).ToString)

            If nRows > 0 Then
                Dim queryUpdate As String = "update empresas..FAC_ENCABEZADOCFDINOM set NumDiasPagados = 1 where nFactura like '" & CboTemporada.SelectedValue.ToString.Replace("-", "").Trim() & vcNomina & TxtSemana.Text & "%' and NumDiasPagados = 0"
                dbAcceso.EjecutarConsulta(queryUpdate)
                Herramientas.Forms.Mensajes.Informacion("Problema corregido con éxito, vuelva a CONSULTAR y de ahí TIMBRAR, Se corrigieron " & nRows.ToString & ".")
            Else
                Herramientas.Forms.Mensajes.Informacion("No existen trabajadores con días trabajados en 0, el proceso no se ejecutó.")
            End If


        Catch ex As Exception
            Herramientas.Forms.Mensajes.Error("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub btn_cancelarTimbre_Click(sender As Object, e As EventArgs) Handles btn_cancelarTimbre.Click
        If Herramientas.Forms.Mensajes.PreguntaAdvertenciaSIoNO("¿Desea cancelar los timbres seleccionados?") And Herramientas.Forms.Mensajes.PreguntaAdvertenciaSIoNO("Una vez iniciara la operación no podrá cancelarla. ¿Desea continuar con la cancelación de los timbres seleccionados?") Then
            pb_progreso.Value = 0
            hProcesoPrincipal = New Thread(AddressOf EjecutarProceso)
            hProcesoPrincipal.Start("Cancelar")

        End If
    End Sub

    Private Sub btn_corregir_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btn_EnviarPDF_Click(sender As Object, e As EventArgs) Handles btn_EnviarPDF.Click

        Dim rutaArchivos As String = Herramientas.Archivos.Dialogos.BuscarCarpeta(Nothing)

        If rutaArchivos Is Nothing Then
            Herramientas.Forms.Mensajes.Error("Debe seleccionar una carpeta donde se guardarán los PDF.")
            Return
        End If

        pb_progreso.Value = 0
        hProcesoPrincipal = New Thread(AddressOf EjecutarProceso)
        hProcesoPrincipal.Start("APDF|" & rutaArchivos)
    End Sub

    Private Sub btn_marcarTodos_Click(sender As Object, e As EventArgs) Handles btn_marcarTodos.Click
        For Each vRow As DataRow In gDT_Archivos.Rows
            vRow("bSeleccion") = True
        Next
    End Sub

    Private Sub btn_DesmarcarTodos_Click(sender As Object, e As EventArgs) Handles btn_DesmarcarTodos.Click
        For Each vRow As DataRow In gDT_Archivos.Rows
            vRow("bSeleccion") = False
        Next
    End Sub

    Private Sub btn_recuperarAcuses_Click(sender As Object, e As EventArgs) Handles btn_recuperarAcuses.Click

    End Sub
End Class