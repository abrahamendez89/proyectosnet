Imports Sistema
Imports System.IO
Imports System.Xml
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Xml.Serialization
Imports System.Net
Imports System.Security.Cryptography.X509Certificates
Imports System.Net.Security
Imports System.IO.Compression
Imports Microsoft.CSharp
Imports System.Security.Cryptography
Imports System.Text




Public Class ClsCFDI32


#Region "Declaraciones"
    Private atrConexion As DataAccessCls
#End Region

#Region "Métodos Públicos"

    Public Function TimbresLibres(ByVal prmRFCEmisor As Integer) As Integer

        Dim DAO As Sistema.DataAccessCls = Sistema.DataAccessCls.DevuelveInstancia
        Dim vcUsuario As String = ""
        Dim vcPassword As String = ""
        Dim vcSQL As String
        Dim vObjTimbra As New ClsFD
        Dim DT As New DataTable

        Try
            vcSQL = "SELECT * FROM FAC_EMISORES(NOLOCK) WHERE NRFCEMISOR = " & prmRFCEmisor

            DAO.RegresaConsultaSQL(vcSQL, DT)

            If Not DT Is Nothing AndAlso DT.Rows.Count > 0 Then

                vcUsuario = IIf(DT.Rows(0)("CUSUARIOWS") Is DBNull.Value, "", DT.Rows(0)("CUSUARIOWS"))
                vcPassword = IIf(DT.Rows(0)("CPASSWS") Is DBNull.Value, "", DT.Rows(0)("CPASSWS"))

            End If

            DT = Nothing

            If vcUsuario = "" Or vcPassword = "" Then
                Return 0
            Else
                Return vObjTimbra.TimbresLibres(vcUsuario, vcPassword)
            End If
        Catch ex As Exception
            Return 0
        End Try

    End Function

    Public Function AsignaConexion(ByVal prmConexion As DataAccessCls) As String
        Try
            atrConexion = prmConexion
            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Shared Function GetCadenaOriginal(ByVal xmlDoc As String, ByVal fileXSLT As String) As String
        Dim strCadenaOriginal As String = ""
        Dim newFile = Path.GetTempFileName()

        Try
            Dim Xsl = New Xml.Xsl.XslCompiledTransform()

            Xsl.Load(fileXSLT)
            Xsl.Transform(xmlDoc, newFile)
            Xsl = Nothing

            Dim sr = New IO.StreamReader(newFile)
            strCadenaOriginal = sr.ReadToEnd
            sr.Close()

            'Eliminamos el archivo Temporal
            System.IO.File.Delete(newFile)

            fileXSLT = Nothing
            newFile = Nothing
            Xsl = Nothing
            sr.Dispose()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try


        Return strCadenaOriginal
    End Function

    Public Function GeneraFacturaElectronica(ByVal prmID As Long) As String
        Try
            GeneraFacturaElectronica = True

            Dim vObjCabecera As New Access.DatosCab
            Dim DTDetalle As New DataTable
            Dim DTImpuestosTrasladados As New DataTable
            Dim DTImpuestosRetenidos As New DataTable
            Dim DTCabeceroNomina As New DataTable

            Dim DTPercepciones As New DataTable
            Dim DTDeducciones As New DataTable

            Dim vcTimbrado As String

            Dim vcXMLTemporal As String = ""
            Dim vcXMLTemporal2 As String = ""

            Dim vcRutaEstiloCadenaOriginal32 As String = ""
            Dim vcNombreID As String = ""

            vObjCabecera = Access.FabricaDatosCFDI32.ObtenDatosEncabezado(prmID)
            DTDetalle = Access.FabricaDatosCFDI32.ObtenDatosDetalle(prmID)

            DTImpuestosTrasladados = Access.FabricaDatosCFDI32.ObtenDatosImpuestosTrasladados(prmID)
            DTImpuestosRetenidos = Access.FabricaDatosCFDI32.ObtenDatosImpuestosRetenidos(prmID)

            DTCabeceroNomina = Access.FabricaDatosCFDI32.ObtenDatosCabeceroNomina(prmID)

            DTPercepciones = Access.FabricaDatosCFDI32.ObtenDatosPercepcionesNomina(prmID)
            DTDeducciones = Access.FabricaDatosCFDI32.ObtenDatosDeduccionesNomina(prmID)



            If vObjCabecera Is Nothing Then
                Return "No se obtuvieron los valores de encabezado"
            End If

            If DTCabeceroNomina Is Nothing Then
                Return "No se obtuvieron los valores de encabezado de nomina"
            End If

            If DTCabeceroNomina.Rows.Count = 0 Then
                Return "No se obtuvieron los valores de encabezado de nomina"
            End If



            Dim cfd As New V32.Comprobante()

            cfd.version = "3.2"

            If vObjCabecera.EFSERIE.Trim <> "" Then
                cfd.serie = vObjCabecera.EFSERIE.Trim     'Opcional
            End If

            cfd.folio = vObjCabecera.EFFACTURA 'Opcional
            cfd.fecha = Convert.ToDateTime(vObjCabecera.EFFECHA.ToString("yyyy-MM-ddThh:mm:ss"))

            cfd.formaDePago = vObjCabecera.EFFORMADEPAGO

            'Lectura del certificado de sello digital
            Dim cCert As New X509Certificate()
            Dim strSerial As String = String.Empty
            cCert = X509Certificate.CreateFromCertFile(vObjCabecera.RutaCert)

            Dim i As Integer
            Dim sn As String = cCert.GetSerialNumberString()
            For i = 0 To sn.Length - 1
                If i Mod 2 <> 0 Then
                    strSerial = strSerial & sn.Substring(i, 1)
                End If
            Next i

            cfd.noCertificado = strSerial
            cfd.certificado = Convert.ToBase64String(cCert.GetRawCertData())

            cfd.condicionesDePago = vObjCabecera.EFCONDICIONDEPAGO  'Opcional
            cfd.subTotal = vObjCabecera.EFSUBTOTALDD

            'Para que se muestre el descueto debe asignar
            'El siguiente atributo como verdadero

            If vObjCabecera.EFDESCUENTO <> 0 Then
                cfd.descuentoSpecified = True
                cfd.descuento = vObjCabecera.EFDESCUENTO  'Opcional
                cfd.motivoDescuento = "Descuentos de Nomina" 'Opcional
            End If



            cfd.TipoCambio = vObjCabecera.EFPARIDAD  'Opcional
            cfd.Moneda = vObjCabecera.EFMONEDA  'Opcional

            cfd.total = Convert.ToDecimal(vObjCabecera.EFIMPORTE)


            cfd.tipoDeComprobante = IIf(vObjCabecera.EFTIPOCOMPROBANTE = "ingreso", V32.ComprobanteTipoDeComprobante.ingreso, V32.ComprobanteTipoDeComprobante.egreso)

            cfd.metodoDePago = vObjCabecera.EFMETODOPAGO
            cfd.NumCtaPago = vObjCabecera.EFCUENTA

            cfd.LugarExpedicion = vObjCabecera.EFLUGAREXPEDICION

            'Datos del Emisor
            Dim Emisor As New V32.ComprobanteEmisor()
            Emisor.rfc = vObjCabecera.RFC
            Emisor.nombre = vObjCabecera.RazonSocial   'Este dato es opcional

            'Domicilio Fiscal
            Dim domicilioEmisor As New V32.t_UbicacionFiscal()
            domicilioEmisor.calle = vObjCabecera.Calle
            domicilioEmisor.codigoPostal = vObjCabecera.CP
            domicilioEmisor.colonia = vObjCabecera.Colonia
            domicilioEmisor.estado = vObjCabecera.Estado
            domicilioEmisor.localidad = vObjCabecera.Localidad
            domicilioEmisor.municipio = vObjCabecera.Municipio
            domicilioEmisor.noExterior = vObjCabecera.NumExt

            If vObjCabecera.NumInt.Trim <> "" Then
                domicilioEmisor.noInterior = vObjCabecera.NumInt
            End If

            domicilioEmisor.pais = vObjCabecera.Pais

            ''Expedido En (Aplica cuando se trata de una sucursal)
            'Dim expedidoEn As New Access.t_Ubicacion()
            'expedidoEn.calle = "Ferrocarrileros"
            'expedidoEn.codigoPostal = "54190"
            'expedidoEn.colonia = "La Angostura"
            'expedidoEn.estado = "Coahuila"
            'expedidoEn.localidad = "México"
            'expedidoEn.municipio = "Monclova"
            'expedidoEn.noExterior = "509"
            'expedidoEn.noInterior = "3"
            'expedidoEn.pais = "México"


            'Asignar el expedidoEn
            'Emisor.ExpedidoEn = expedidoEn

            'Asignar el domicilio al emisor
            Emisor.DomicilioFiscal = domicilioEmisor

            'Puede ser consultado en el portal del sat
            'Es obligatorio y debe tener al menos 1
            Dim regimenFiscal1 As New V32.ComprobanteEmisorRegimenFiscal()
            regimenFiscal1.Regimen = vObjCabecera.EFREGIMEN

            'Asignar el regimen fiscal dentro del emisor
            Emisor.RegimenFiscal = New V32.ComprobanteEmisorRegimenFiscal() {regimenFiscal1}
            'Asignar el emisor al CFD
            cfd.Emisor = Emisor

            'Crear receptor del comprobante
            Dim Receptor As New V32.ComprobanteReceptor()
            Receptor.rfc = vObjCabecera.CLIENTERFC
            Receptor.nombre = vObjCabecera.CLIENTENOMBRE

            'Crear domicilio del receptor
            Dim domicilioReceptor As New V32.t_Ubicacion()
            domicilioReceptor.calle = vObjCabecera.CLIENTEDIRECCION
            domicilioReceptor.codigoPostal = vObjCabecera.CLIENTECP
            domicilioReceptor.colonia = vObjCabecera.CLIENTECOLONIA
            domicilioReceptor.estado = vObjCabecera.CLIENTEESTADO
            domicilioReceptor.localidad = vObjCabecera.CLIENTECIUDAD
            domicilioReceptor.municipio = vObjCabecera.CLIENTECIUDAD
            domicilioReceptor.noExterior = vObjCabecera.CLIENTENUMEXT

            If vObjCabecera.CLIENTENUMINT <> "" Then
                domicilioReceptor.noInterior = vObjCabecera.CLIENTENUMINT
            End If

            domicilioReceptor.pais = vObjCabecera.CLIENTEPAIS

            'Asignar el domiclio al receptor
            Receptor.Domicilio = domicilioReceptor

            'Asignar el Receptor al CFD
            cfd.Receptor = Receptor



            If Not DTDetalle Is Nothing Then
                Dim vRow As DataRow
                Dim vldetalle As Integer

                vldetalle = 0

                Dim Concepto1 As New V32.ComprobanteConcepto()
                Dim Concepto2 As New V32.ComprobanteConcepto()
                Dim Concepto3 As New V32.ComprobanteConcepto()
                Dim Concepto4 As New V32.ComprobanteConcepto()
                Dim Concepto5 As New V32.ComprobanteConcepto()
                Dim Concepto6 As New V32.ComprobanteConcepto()
                Dim Concepto7 As New V32.ComprobanteConcepto()
                Dim Concepto8 As New V32.ComprobanteConcepto()
                Dim Concepto9 As New V32.ComprobanteConcepto()
                Dim Concepto10 As New V32.ComprobanteConcepto()
                Dim Concepto11 As New V32.ComprobanteConcepto()
                Dim Concepto12 As New V32.ComprobanteConcepto()
                Dim Concepto13 As New V32.ComprobanteConcepto()
                Dim Concepto14 As New V32.ComprobanteConcepto()
                Dim Concepto15 As New V32.ComprobanteConcepto()
                Dim Concepto16 As New V32.ComprobanteConcepto()
                Dim Concepto17 As New V32.ComprobanteConcepto()
                Dim Concepto18 As New V32.ComprobanteConcepto()
                Dim Concepto19 As New V32.ComprobanteConcepto()
                Dim Concepto20 As New V32.ComprobanteConcepto()

                Dim Concepto21 As New V32.ComprobanteConcepto()
                Dim Concepto22 As New V32.ComprobanteConcepto()
                Dim Concepto23 As New V32.ComprobanteConcepto()
                Dim Concepto24 As New V32.ComprobanteConcepto()
                Dim Concepto25 As New V32.ComprobanteConcepto()
                Dim Concepto26 As New V32.ComprobanteConcepto()
                Dim Concepto27 As New V32.ComprobanteConcepto()
                Dim Concepto28 As New V32.ComprobanteConcepto()
                Dim Concepto29 As New V32.ComprobanteConcepto()
                Dim Concepto30 As New V32.ComprobanteConcepto()

                For Each vRow In DTDetalle.Rows

                    'Crear los conceptos del comprobante

                    vldetalle += 1



                    Select Case vldetalle
                        Case 1
                            AsignaValoresConceptos(Concepto1, vRow)
                        Case 2
                            AsignaValoresConceptos(Concepto2, vRow)
                        Case 3
                            AsignaValoresConceptos(Concepto3, vRow)
                        Case 4
                            AsignaValoresConceptos(Concepto4, vRow)
                        Case 5
                            AsignaValoresConceptos(Concepto5, vRow)
                        Case 6
                            AsignaValoresConceptos(Concepto6, vRow)
                        Case 7
                            AsignaValoresConceptos(Concepto7, vRow)
                        Case 8
                            AsignaValoresConceptos(Concepto8, vRow)
                        Case 9
                            AsignaValoresConceptos(Concepto9, vRow)
                        Case 10
                            AsignaValoresConceptos(Concepto10, vRow)
                        Case 11
                            AsignaValoresConceptos(Concepto11, vRow)
                        Case 12
                            AsignaValoresConceptos(Concepto12, vRow)
                        Case 13
                            AsignaValoresConceptos(Concepto13, vRow)
                        Case 14
                            AsignaValoresConceptos(Concepto14, vRow)
                        Case 15
                            AsignaValoresConceptos(Concepto15, vRow)
                        Case 16
                            AsignaValoresConceptos(Concepto16, vRow)
                        Case 17
                            AsignaValoresConceptos(Concepto17, vRow)
                        Case 18
                            AsignaValoresConceptos(Concepto18, vRow)
                        Case 19
                            AsignaValoresConceptos(Concepto19, vRow)
                        Case 20
                            AsignaValoresConceptos(Concepto20, vRow)
                        Case 21
                            AsignaValoresConceptos(Concepto21, vRow)
                        Case 22
                            AsignaValoresConceptos(Concepto22, vRow)
                        Case 23
                            AsignaValoresConceptos(Concepto23, vRow)
                        Case 24
                            AsignaValoresConceptos(Concepto24, vRow)
                        Case 25
                            AsignaValoresConceptos(Concepto25, vRow)
                        Case 26
                            AsignaValoresConceptos(Concepto26, vRow)
                        Case 27
                            AsignaValoresConceptos(Concepto27, vRow)
                        Case 28
                            AsignaValoresConceptos(Concepto28, vRow)
                        Case 29
                            AsignaValoresConceptos(Concepto29, vRow)
                        Case 30
                            AsignaValoresConceptos(Concepto30, vRow)
                    End Select
                Next

                Select Case vldetalle
                    Case 1
                        cfd.Conceptos = New V32.ComprobanteConcepto() {Concepto1}
                    Case 2
                        cfd.Conceptos = New V32.ComprobanteConcepto() {Concepto1, Concepto2}
                    Case 3
                        cfd.Conceptos = New V32.ComprobanteConcepto() {Concepto1, Concepto2, Concepto3}
                    Case 4
                        cfd.Conceptos = New V32.ComprobanteConcepto() {Concepto1, Concepto2, Concepto3, Concepto4}
                    Case 5
                        cfd.Conceptos = New V32.ComprobanteConcepto() {Concepto1, Concepto2, Concepto3, Concepto4, Concepto5}
                    Case 6
                        cfd.Conceptos = New V32.ComprobanteConcepto() {Concepto1, Concepto2, Concepto3, Concepto4, Concepto5, _
                                                                          Concepto6}
                    Case 7
                        cfd.Conceptos = New V32.ComprobanteConcepto() {Concepto1, Concepto2, Concepto3, Concepto4, Concepto5, _
                                                                          Concepto6, Concepto7}
                    Case 8
                        cfd.Conceptos = New V32.ComprobanteConcepto() {Concepto1, Concepto2, Concepto3, Concepto4, Concepto5, _
                                                                          Concepto6, Concepto7, Concepto8}
                    Case 9
                        cfd.Conceptos = New V32.ComprobanteConcepto() {Concepto1, Concepto2, Concepto3, Concepto4, Concepto5, _
                                                                          Concepto6, Concepto7, Concepto8, Concepto9}
                    Case 10
                        cfd.Conceptos = New V32.ComprobanteConcepto() {Concepto1, Concepto2, Concepto3, Concepto4, Concepto5, _
                                                                          Concepto6, Concepto7, Concepto8, Concepto9, Concepto10}
                    Case 11
                        cfd.Conceptos = New V32.ComprobanteConcepto() {Concepto1, Concepto2, Concepto3, Concepto4, Concepto5, _
                                                                          Concepto6, Concepto7, Concepto8, Concepto9, Concepto10, _
                                                                          Concepto11}
                    Case 12
                        cfd.Conceptos = New V32.ComprobanteConcepto() {Concepto1, Concepto2, Concepto3, Concepto4, Concepto5, _
                                                                          Concepto6, Concepto7, Concepto8, Concepto9, Concepto10, _
                                                                          Concepto11, Concepto12}
                    Case 13
                        cfd.Conceptos = New V32.ComprobanteConcepto() {Concepto1, Concepto2, Concepto3, Concepto4, Concepto5, _
                                                                          Concepto6, Concepto7, Concepto8, Concepto9, Concepto10, _
                                                                          Concepto11, Concepto12, Concepto13}
                    Case 14
                        cfd.Conceptos = New V32.ComprobanteConcepto() {Concepto1, Concepto2, Concepto3, Concepto4, Concepto5, _
                                                                          Concepto6, Concepto7, Concepto8, Concepto9, Concepto10, _
                                                                          Concepto11, Concepto12, Concepto13, Concepto14}
                    Case 15
                        cfd.Conceptos = New V32.ComprobanteConcepto() {Concepto1, Concepto2, Concepto3, Concepto4, Concepto5, _
                                                                          Concepto6, Concepto7, Concepto8, Concepto9, Concepto10, _
                                                                          Concepto11, Concepto12, Concepto13, Concepto14, Concepto15}
                    Case 16
                        cfd.Conceptos = New V32.ComprobanteConcepto() {Concepto1, Concepto2, Concepto3, Concepto4, Concepto5, _
                                                                          Concepto6, Concepto7, Concepto8, Concepto9, Concepto10, _
                                                                          Concepto11, Concepto12, Concepto13, Concepto14, Concepto15, _
                                                                          Concepto16}
                    Case 17
                        cfd.Conceptos = New V32.ComprobanteConcepto() {Concepto1, Concepto2, Concepto3, Concepto4, Concepto5, _
                                                                          Concepto6, Concepto7, Concepto8, Concepto9, Concepto10, _
                                                                          Concepto11, Concepto12, Concepto13, Concepto14, Concepto15, _
                                                                          Concepto16, Concepto17}
                    Case 18
                        cfd.Conceptos = New V32.ComprobanteConcepto() {Concepto1, Concepto2, Concepto3, Concepto4, Concepto5, _
                                                                          Concepto6, Concepto7, Concepto8, Concepto9, Concepto10, _
                                                                          Concepto11, Concepto12, Concepto13, Concepto14, Concepto15, _
                                                                          Concepto16, Concepto17, Concepto18}
                    Case 19
                        cfd.Conceptos = New V32.ComprobanteConcepto() {Concepto1, Concepto2, Concepto3, Concepto4, Concepto5, _
                                                                          Concepto6, Concepto7, Concepto8, Concepto9, Concepto10, _
                                                                          Concepto11, Concepto12, Concepto13, Concepto14, Concepto15, _
                                                                          Concepto16, Concepto17, Concepto18, Concepto19}
                    Case 20
                        cfd.Conceptos = New V32.ComprobanteConcepto() {Concepto1, Concepto2, Concepto3, Concepto4, Concepto5, _
                                                                          Concepto6, Concepto7, Concepto8, Concepto9, Concepto10, _
                                                                          Concepto11, Concepto12, Concepto13, Concepto14, Concepto15, _
                                                                          Concepto16, Concepto17, Concepto18, Concepto19, Concepto20}
                    Case 21
                        cfd.Conceptos = New V32.ComprobanteConcepto() {Concepto1, Concepto2, Concepto3, Concepto4, Concepto5, _
                                                                          Concepto6, Concepto7, Concepto8, Concepto9, Concepto10, _
                                                                          Concepto11, Concepto12, Concepto13, Concepto14, Concepto15, _
                                                                          Concepto16, Concepto17, Concepto18, Concepto19, Concepto20, _
                                                                          Concepto21}
                    Case 22
                        cfd.Conceptos = New V32.ComprobanteConcepto() {Concepto1, Concepto2, Concepto3, Concepto4, Concepto5, _
                                                                          Concepto6, Concepto7, Concepto8, Concepto9, Concepto10, _
                                                                          Concepto11, Concepto12, Concepto13, Concepto14, Concepto15, _
                                                                          Concepto16, Concepto17, Concepto18, Concepto19, Concepto20, _
                                                                          Concepto21, Concepto22}
                    Case 23
                        cfd.Conceptos = New V32.ComprobanteConcepto() {Concepto1, Concepto2, Concepto3, Concepto4, Concepto5, _
                                                                          Concepto6, Concepto7, Concepto8, Concepto9, Concepto10, _
                                                                          Concepto11, Concepto12, Concepto13, Concepto14, Concepto15, _
                                                                          Concepto16, Concepto17, Concepto18, Concepto19, Concepto20, _
                                                                          Concepto21, Concepto22, Concepto23}
                    Case 24
                        cfd.Conceptos = New V32.ComprobanteConcepto() {Concepto1, Concepto2, Concepto3, Concepto4, Concepto5, _
                                                                          Concepto6, Concepto7, Concepto8, Concepto9, Concepto10, _
                                                                          Concepto11, Concepto12, Concepto13, Concepto14, Concepto15, _
                                                                          Concepto16, Concepto17, Concepto18, Concepto19, Concepto20, _
                                                                          Concepto21, Concepto22, Concepto23, Concepto24}
                    Case 25
                        cfd.Conceptos = New V32.ComprobanteConcepto() {Concepto1, Concepto2, Concepto3, Concepto4, Concepto5, _
                                                                          Concepto6, Concepto7, Concepto8, Concepto9, Concepto10, _
                                                                          Concepto11, Concepto12, Concepto13, Concepto14, Concepto15, _
                                                                          Concepto16, Concepto17, Concepto18, Concepto19, Concepto20, _
                                                                          Concepto21, Concepto22, Concepto23, Concepto24, Concepto25}
                    Case 26
                        cfd.Conceptos = New V32.ComprobanteConcepto() {Concepto1, Concepto2, Concepto3, Concepto4, Concepto5, _
                                                                          Concepto6, Concepto7, Concepto8, Concepto9, Concepto10, _
                                                                          Concepto11, Concepto12, Concepto13, Concepto14, Concepto15, _
                                                                          Concepto16, Concepto17, Concepto18, Concepto19, Concepto20, _
                                                                          Concepto21, Concepto22, Concepto23, Concepto24, Concepto25, _
                                                                          Concepto26}
                    Case 27
                        cfd.Conceptos = New V32.ComprobanteConcepto() {Concepto1, Concepto2, Concepto3, Concepto4, Concepto5, _
                                                                          Concepto6, Concepto7, Concepto8, Concepto9, Concepto10, _
                                                                          Concepto11, Concepto12, Concepto13, Concepto14, Concepto15, _
                                                                          Concepto16, Concepto17, Concepto18, Concepto19, Concepto20, _
                                                                          Concepto21, Concepto22, Concepto23, Concepto24, Concepto25, _
                                                                          Concepto26, Concepto27}
                    Case 28
                        cfd.Conceptos = New V32.ComprobanteConcepto() {Concepto1, Concepto2, Concepto3, Concepto4, Concepto5, _
                                                                          Concepto6, Concepto7, Concepto8, Concepto9, Concepto10, _
                                                                          Concepto11, Concepto12, Concepto13, Concepto14, Concepto15, _
                                                                          Concepto16, Concepto17, Concepto18, Concepto19, Concepto20, _
                                                                          Concepto21, Concepto22, Concepto23, Concepto24, Concepto25, _
                                                                          Concepto26, Concepto27, Concepto28}
                    Case 29
                        cfd.Conceptos = New V32.ComprobanteConcepto() {Concepto1, Concepto2, Concepto3, Concepto4, Concepto5, _
                                                                          Concepto6, Concepto7, Concepto8, Concepto9, Concepto10, _
                                                                          Concepto11, Concepto12, Concepto13, Concepto14, Concepto15, _
                                                                          Concepto16, Concepto17, Concepto18, Concepto19, Concepto20, _
                                                                          Concepto21, Concepto22, Concepto23, Concepto24, Concepto25, _
                                                                          Concepto26, Concepto27, Concepto28, Concepto29}
                    Case 30
                        cfd.Conceptos = New V32.ComprobanteConcepto() {Concepto1, Concepto2, Concepto3, Concepto4, Concepto5, _
                                                                          Concepto6, Concepto7, Concepto8, Concepto9, Concepto10, _
                                                                          Concepto11, Concepto12, Concepto13, Concepto14, Concepto15, _
                                                                          Concepto16, Concepto17, Concepto18, Concepto19, Concepto20, _
                                                                          Concepto21, Concepto22, Concepto23, Concepto24, Concepto25, _
                                                                          Concepto26, Concepto27, Concepto28, Concepto29, Concepto30}

                End Select
            End If


            Dim impuestos As New V32.ComprobanteImpuestos()

            If Not DTImpuestosTrasladados Is Nothing Then

                Dim vRow As DataRow

                Dim vldetalle As Integer
                Dim vnImpuestosTrasladados As Decimal

                vldetalle = 0
                vnImpuestosTrasladados = 0


                Dim ImpuestoTrasladadoIVA1 As New V32.ComprobanteImpuestosTraslado()
                Dim ImpuestoTrasladadoIVA2 As New V32.ComprobanteImpuestosTraslado()
                Dim ImpuestoTrasladadoIVA3 As New V32.ComprobanteImpuestosTraslado()
                Dim ImpuestoTrasladadoIVA4 As New V32.ComprobanteImpuestosTraslado()
                Dim ImpuestoTrasladadoIVA5 As New V32.ComprobanteImpuestosTraslado()
                Dim ImpuestoTrasladadoIVA6 As New V32.ComprobanteImpuestosTraslado()
                Dim ImpuestoTrasladadoIVA7 As New V32.ComprobanteImpuestosTraslado()
                Dim ImpuestoTrasladadoIVA8 As New V32.ComprobanteImpuestosTraslado()
                Dim ImpuestoTrasladadoIVA9 As New V32.ComprobanteImpuestosTraslado()
                Dim ImpuestoTrasladadoIVA10 As New V32.ComprobanteImpuestosTraslado()


                For Each vRow In DTImpuestosTrasladados.Rows

                    vldetalle += 1

                    'Crear impuestos

                    Select Case vldetalle
                        Case 1
                            AsignaValoresImpuestosTraslados(ImpuestoTrasladadoIVA1, vRow)
                        Case 2
                            AsignaValoresImpuestosTraslados(ImpuestoTrasladadoIVA2, vRow)
                        Case 3
                            AsignaValoresImpuestosTraslados(ImpuestoTrasladadoIVA3, vRow)
                        Case 4
                            AsignaValoresImpuestosTraslados(ImpuestoTrasladadoIVA4, vRow)
                        Case 5
                            AsignaValoresImpuestosTraslados(ImpuestoTrasladadoIVA5, vRow)
                        Case 6
                            AsignaValoresImpuestosTraslados(ImpuestoTrasladadoIVA6, vRow)
                        Case 7
                            AsignaValoresImpuestosTraslados(ImpuestoTrasladadoIVA7, vRow)
                        Case 8
                            AsignaValoresImpuestosTraslados(ImpuestoTrasladadoIVA8, vRow)
                        Case 9
                            AsignaValoresImpuestosTraslados(ImpuestoTrasladadoIVA9, vRow)
                        Case 10
                            AsignaValoresImpuestosTraslados(ImpuestoTrasladadoIVA10, vRow)
                    End Select



                    vnImpuestosTrasladados = vnImpuestosTrasladados + vRow("DIIMPORTE")

                Next

                'Asignamos los impuestos



                Select Case vldetalle
                    Case 1
                        impuestos.Traslados = New V32.ComprobanteImpuestosTraslado() {ImpuestoTrasladadoIVA1}
                    Case 2
                        impuestos.Traslados = New V32.ComprobanteImpuestosTraslado() {ImpuestoTrasladadoIVA1, ImpuestoTrasladadoIVA2}
                    Case 3
                        impuestos.Traslados = New V32.ComprobanteImpuestosTraslado() {ImpuestoTrasladadoIVA1, ImpuestoTrasladadoIVA2, _
                                                                                         ImpuestoTrasladadoIVA3}
                    Case 4
                        impuestos.Traslados = New V32.ComprobanteImpuestosTraslado() {ImpuestoTrasladadoIVA1, ImpuestoTrasladadoIVA2, _
                                                                                         ImpuestoTrasladadoIVA3, ImpuestoTrasladadoIVA4}
                    Case 5
                        impuestos.Traslados = New V32.ComprobanteImpuestosTraslado() {ImpuestoTrasladadoIVA1, ImpuestoTrasladadoIVA2, _
                                                                                         ImpuestoTrasladadoIVA3, ImpuestoTrasladadoIVA4, _
                                                                                         ImpuestoTrasladadoIVA5}
                    Case 6
                        impuestos.Traslados = New V32.ComprobanteImpuestosTraslado() {ImpuestoTrasladadoIVA1, ImpuestoTrasladadoIVA2, _
                                                                                         ImpuestoTrasladadoIVA3, ImpuestoTrasladadoIVA4, _
                                                                                         ImpuestoTrasladadoIVA5, ImpuestoTrasladadoIVA6}
                    Case 7
                        impuestos.Traslados = New V32.ComprobanteImpuestosTraslado() {ImpuestoTrasladadoIVA1, ImpuestoTrasladadoIVA2, _
                                                                                         ImpuestoTrasladadoIVA3, ImpuestoTrasladadoIVA4, _
                                                                                         ImpuestoTrasladadoIVA5, ImpuestoTrasladadoIVA6, _
                                                                                         ImpuestoTrasladadoIVA7}
                    Case 8
                        impuestos.Traslados = New V32.ComprobanteImpuestosTraslado() {ImpuestoTrasladadoIVA1, ImpuestoTrasladadoIVA2, _
                                                                                         ImpuestoTrasladadoIVA3, ImpuestoTrasladadoIVA4, _
                                                                                         ImpuestoTrasladadoIVA5, ImpuestoTrasladadoIVA6, _
                                                                                         ImpuestoTrasladadoIVA7, ImpuestoTrasladadoIVA8}
                    Case 9
                        impuestos.Traslados = New V32.ComprobanteImpuestosTraslado() {ImpuestoTrasladadoIVA1, ImpuestoTrasladadoIVA2, _
                                                                                         ImpuestoTrasladadoIVA3, ImpuestoTrasladadoIVA4, _
                                                                                         ImpuestoTrasladadoIVA5, ImpuestoTrasladadoIVA6, _
                                                                                         ImpuestoTrasladadoIVA7, ImpuestoTrasladadoIVA8, _
                                                                                         ImpuestoTrasladadoIVA9}
                    Case 10
                        impuestos.Traslados = New V32.ComprobanteImpuestosTraslado() {ImpuestoTrasladadoIVA1, ImpuestoTrasladadoIVA2, _
                                                                                         ImpuestoTrasladadoIVA3, ImpuestoTrasladadoIVA4, _
                                                                                         ImpuestoTrasladadoIVA5, ImpuestoTrasladadoIVA6, _
                                                                                         ImpuestoTrasladadoIVA7, ImpuestoTrasladadoIVA8, _
                                                                                         ImpuestoTrasladadoIVA9, ImpuestoTrasladadoIVA10}
                End Select

                impuestos.totalImpuestosTrasladados = vnImpuestosTrasladados
                impuestos.totalImpuestosTrasladadosSpecified = True

            End If


            ' Aqui meto los impuestos Retenidos

            If Not DTImpuestosRetenidos Is Nothing Then

                Dim vRow As DataRow

                Dim vldetalle As Integer
                Dim vnImpuestosRetenidos As Decimal

                vldetalle = 0
                vnImpuestosRetenidos = 0

                Dim ImpuestoRetenidoIVA1 As New V32.ComprobanteImpuestosRetencion()
                Dim ImpuestoRetenidoIVA2 As New V32.ComprobanteImpuestosRetencion()
                Dim ImpuestoRetenidoIVA3 As New V32.ComprobanteImpuestosRetencion()
                Dim ImpuestoRetenidoIVA4 As New V32.ComprobanteImpuestosRetencion()
                Dim ImpuestoRetenidoIVA5 As New V32.ComprobanteImpuestosRetencion()
                Dim ImpuestoRetenidoIVA6 As New V32.ComprobanteImpuestosRetencion()
                Dim ImpuestoRetenidoIVA7 As New V32.ComprobanteImpuestosRetencion()
                Dim ImpuestoRetenidoIVA8 As New V32.ComprobanteImpuestosRetencion()
                Dim ImpuestoRetenidoIVA9 As New V32.ComprobanteImpuestosRetencion()
                Dim ImpuestoRetenidoIVA10 As New V32.ComprobanteImpuestosRetencion()


                For Each vRow In DTImpuestosRetenidos.Rows

                    vldetalle += 1

                    'Crear impuestos

                    Select Case vldetalle
                        Case 1
                            AsignaValoresImpuestosRetenidos(ImpuestoRetenidoIVA1, vRow)
                        Case 2
                            AsignaValoresImpuestosRetenidos(ImpuestoRetenidoIVA2, vRow)
                        Case 3
                            AsignaValoresImpuestosRetenidos(ImpuestoRetenidoIVA3, vRow)
                        Case 4
                            AsignaValoresImpuestosRetenidos(ImpuestoRetenidoIVA4, vRow)
                        Case 5
                            AsignaValoresImpuestosRetenidos(ImpuestoRetenidoIVA5, vRow)
                        Case 6
                            AsignaValoresImpuestosRetenidos(ImpuestoRetenidoIVA6, vRow)
                        Case 7
                            AsignaValoresImpuestosRetenidos(ImpuestoRetenidoIVA7, vRow)
                        Case 8
                            AsignaValoresImpuestosRetenidos(ImpuestoRetenidoIVA8, vRow)
                        Case 9
                            AsignaValoresImpuestosRetenidos(ImpuestoRetenidoIVA9, vRow)
                        Case 10
                            AsignaValoresImpuestosRetenidos(ImpuestoRetenidoIVA10, vRow)
                    End Select



                    vnImpuestosRetenidos = vnImpuestosRetenidos + vRow("DIIMPORTE")

                Next

                'Asignamos los impuestos


                Select Case vldetalle
                    Case 1
                        impuestos.Retenciones = New V32.ComprobanteImpuestosRetencion() {ImpuestoRetenidoIVA1}
                    Case 2
                        impuestos.Retenciones = New V32.ComprobanteImpuestosRetencion() {ImpuestoRetenidoIVA1, ImpuestoRetenidoIVA2}
                    Case 3
                        impuestos.Retenciones = New V32.ComprobanteImpuestosRetencion() {ImpuestoRetenidoIVA1, ImpuestoRetenidoIVA2, _
                                                                                         ImpuestoRetenidoIVA3}
                    Case 4
                        impuestos.Retenciones = New V32.ComprobanteImpuestosRetencion() {ImpuestoRetenidoIVA1, ImpuestoRetenidoIVA2, _
                                                                                         ImpuestoRetenidoIVA3, ImpuestoRetenidoIVA4}
                    Case 5
                        impuestos.Retenciones = New V32.ComprobanteImpuestosRetencion() {ImpuestoRetenidoIVA1, ImpuestoRetenidoIVA2, _
                                                                                         ImpuestoRetenidoIVA3, ImpuestoRetenidoIVA4, _
                                                                                         ImpuestoRetenidoIVA5}
                    Case 6
                        impuestos.Retenciones = New V32.ComprobanteImpuestosRetencion() {ImpuestoRetenidoIVA1, ImpuestoRetenidoIVA2, _
                                                                                         ImpuestoRetenidoIVA3, ImpuestoRetenidoIVA4, _
                                                                                         ImpuestoRetenidoIVA5, ImpuestoRetenidoIVA6}
                    Case 7
                        impuestos.Retenciones = New V32.ComprobanteImpuestosRetencion() {ImpuestoRetenidoIVA1, ImpuestoRetenidoIVA2, _
                                                                                         ImpuestoRetenidoIVA3, ImpuestoRetenidoIVA4, _
                                                                                         ImpuestoRetenidoIVA5, ImpuestoRetenidoIVA6, _
                                                                                         ImpuestoRetenidoIVA7}
                    Case 8
                        impuestos.Retenciones = New V32.ComprobanteImpuestosRetencion() {ImpuestoRetenidoIVA1, ImpuestoRetenidoIVA2, _
                                                                                         ImpuestoRetenidoIVA3, ImpuestoRetenidoIVA4, _
                                                                                         ImpuestoRetenidoIVA5, ImpuestoRetenidoIVA6, _
                                                                                         ImpuestoRetenidoIVA7, ImpuestoRetenidoIVA8}
                    Case 9
                        impuestos.Retenciones = New V32.ComprobanteImpuestosRetencion() {ImpuestoRetenidoIVA1, ImpuestoRetenidoIVA2, _
                                                                                         ImpuestoRetenidoIVA3, ImpuestoRetenidoIVA4, _
                                                                                         ImpuestoRetenidoIVA5, ImpuestoRetenidoIVA6, _
                                                                                         ImpuestoRetenidoIVA7, ImpuestoRetenidoIVA8, _
                                                                                         ImpuestoRetenidoIVA9}
                    Case 10
                        impuestos.Retenciones = New V32.ComprobanteImpuestosRetencion() {ImpuestoRetenidoIVA1, ImpuestoRetenidoIVA2, _
                                                                                         ImpuestoRetenidoIVA3, ImpuestoRetenidoIVA4, _
                                                                                         ImpuestoRetenidoIVA5, ImpuestoRetenidoIVA6, _
                                                                                         ImpuestoRetenidoIVA7, ImpuestoRetenidoIVA8, _
                                                                                         ImpuestoRetenidoIVA9, ImpuestoRetenidoIVA10}
                End Select

                impuestos.totalImpuestosRetenidos = vnImpuestosRetenidos

                impuestos.totalImpuestosTrasladadosSpecified = True


            End If

            cfd.Impuestos = impuestos




            If Not Directory.Exists(vObjCabecera.RutaXml) Then
                Directory.CreateDirectory(vObjCabecera.RutaXml)
            End If

            vcXMLTemporal = vObjCabecera.RutaXml & "\" & vObjCabecera.RFC & "_" & vObjCabecera.EFSERIE.Trim & vObjCabecera.EFFACTURA & "_temp.xml"
            vcXMLTemporal2 = vObjCabecera.RutaXml & "\" & vObjCabecera.RFC & "_" & vObjCabecera.EFSERIE.Trim & vObjCabecera.EFFACTURA & "_temp2.xml"

            If File.Exists(vcXMLTemporal) Then
                Kill(vcXMLTemporal)
            End If



            cfd.sello = ""

            cfd.SaveToFile(vcXMLTemporal, System.Text.Encoding.UTF8)



            Dim AttNomina As XmlAttribute
            Dim ObjNomina As New V32.Nomina
            Dim ObjCreaXMLNomina As New ClsCreaXML
            Dim CFDI As New XmlDocument()
            Dim ElementoComprobante As Xml.XmlNode
            Dim AttPercepciones As XmlAttribute
            Dim AttDeducciones As XmlAttribute

            If File.Exists(vcXMLTemporal2) Then
                Kill(vcXMLTemporal2)
            End If

            CFDI.Load(vcXMLTemporal)

            ElementoComprobante = CFDI.DocumentElement()

            vcRutaEstiloCadenaOriginal32 = DTCabeceroNomina.Rows(0)("RUTAUTILERIACADENAORIGINAL")


            '' Anexamos todos los parametros para el nodo de 'Nomina' del complemento de nomina

            Dim Nomina As XmlNode = CFDI.CreateElement("nomina", "Nomina", "http://www.sat.gob.mx/nomina")

            If Not DTCabeceroNomina.Rows(0)("VERSION") Is DBNull.Value AndAlso DTCabeceroNomina.Rows(0)("VERSION").ToString.Trim <> "" Then
                AttNomina = CFDI.CreateAttribute("Version")
                AttNomina.Value = DTCabeceroNomina.Rows(0)("VERSION").ToString.Trim
                Nomina.Attributes.Append(AttNomina)
            End If

            If Not DTCabeceroNomina.Rows(0)("REGISTROPATRONAL") Is DBNull.Value AndAlso DTCabeceroNomina.Rows(0)("REGISTROPATRONAL").ToString.Trim <> "" Then
                AttNomina = CFDI.CreateAttribute("RegistroPatronal")
                AttNomina.Value = DTCabeceroNomina.Rows(0)("REGISTROPATRONAL").ToString.Trim
                Nomina.Attributes.Append(AttNomina)
            End If


            If Not DTCabeceroNomina.Rows(0)("NUMEMPLEADO") Is DBNull.Value AndAlso DTCabeceroNomina.Rows(0)("NUMEMPLEADO").ToString.Trim <> "" Then
                AttNomina = CFDI.CreateAttribute("NumEmpleado")
                AttNomina.Value = DTCabeceroNomina.Rows(0)("NUMEMPLEADO").ToString.Trim
                Nomina.Attributes.Append(AttNomina)
            End If


            If Not DTCabeceroNomina.Rows(0)("CURP") Is DBNull.Value AndAlso DTCabeceroNomina.Rows(0)("CURP").ToString.Trim <> "" Then
                AttNomina = CFDI.CreateAttribute("CURP")
                AttNomina.Value = DTCabeceroNomina.Rows(0)("CURP").ToString.Trim
                Nomina.Attributes.Append(AttNomina)
            End If


            If Not DTCabeceroNomina.Rows(0)("TIPOREGIMEN") Is DBNull.Value AndAlso DTCabeceroNomina.Rows(0)("TIPOREGIMEN").ToString.Trim <> "" Then
                AttNomina = CFDI.CreateAttribute("TipoRegimen")
                AttNomina.Value = DTCabeceroNomina.Rows(0)("TIPOREGIMEN").ToString.Trim
                Nomina.Attributes.Append(AttNomina)
            End If

            If Not DTCabeceroNomina.Rows(0)("NUMSEGURIDADSOCIAL") Is DBNull.Value AndAlso DTCabeceroNomina.Rows(0)("NUMSEGURIDADSOCIAL").ToString.Trim <> "" Then
                AttNomina = CFDI.CreateAttribute("NumSeguridadSocial")
                AttNomina.Value = DTCabeceroNomina.Rows(0)("NUMSEGURIDADSOCIAL").ToString.Trim
                Nomina.Attributes.Append(AttNomina)
            End If

            If Not DTCabeceroNomina.Rows(0)("FECHAPAGO") Is DBNull.Value AndAlso DTCabeceroNomina.Rows(0)("FECHAPAGO") <> "" Then
                AttNomina = CFDI.CreateAttribute("FechaPago")
                ObjNomina.FechaPago = DTCabeceroNomina.Rows(0)("FECHAPAGO")
                AttNomina.Value = ObjNomina.FechaPago.ToString("yyyy-MM-dd")
                Nomina.Attributes.Append(AttNomina)
            End If

            If Not DTCabeceroNomina.Rows(0)("FECHAINICIALPAGO") Is DBNull.Value AndAlso DTCabeceroNomina.Rows(0)("FECHAINICIALPAGO") <> "" Then
                AttNomina = CFDI.CreateAttribute("FechaInicialPago")
                ObjNomina.FechaInicialPago = DTCabeceroNomina.Rows(0)("FECHAINICIALPAGO")
                AttNomina.Value = ObjNomina.FechaInicialPago.ToString("yyyy-MM-dd")
                Nomina.Attributes.Append(AttNomina)
            End If

            If Not DTCabeceroNomina.Rows(0)("FECHAFINALPAGO") Is DBNull.Value AndAlso DTCabeceroNomina.Rows(0)("FECHAFINALPAGO") <> "" Then
                AttNomina = CFDI.CreateAttribute("FechaFinalPago")
                ObjNomina.FechaFinalPago = DTCabeceroNomina.Rows(0)("FECHAFINALPAGO")
                AttNomina.Value = ObjNomina.FechaFinalPago.ToString("yyyy-MM-dd")
                Nomina.Attributes.Append(AttNomina)
            End If


            If Not DTCabeceroNomina.Rows(0)("NUMDIASPAGADOS") Is DBNull.Value AndAlso DTCabeceroNomina.Rows(0)("NUMDIASPAGADOS") > 0 Then
                AttNomina = CFDI.CreateAttribute("NumDiasPagados")
                AttNomina.Value = DTCabeceroNomina.Rows(0)("NUMDIASPAGADOS")
                Nomina.Attributes.Append(AttNomina)
            End If

            If Not DTCabeceroNomina.Rows(0)("DEPARTAMENTO") Is DBNull.Value AndAlso DTCabeceroNomina.Rows(0)("DEPARTAMENTO").ToString.Trim <> "" Then
                AttNomina = CFDI.CreateAttribute("Departamento")
                AttNomina.Value = DTCabeceroNomina.Rows(0)("DEPARTAMENTO").ToString.Trim
                Nomina.Attributes.Append(AttNomina)
            End If

            If Not DTCabeceroNomina.Rows(0)("CLABE") Is DBNull.Value AndAlso DTCabeceroNomina.Rows(0)("CLABE").ToString.Trim <> "" Then
                AttNomina = CFDI.CreateAttribute("CLABE")
                AttNomina.Value = DTCabeceroNomina.Rows(0)("CLABE").ToString.Trim
                Nomina.Attributes.Append(AttNomina)
            End If

            If Not DTCabeceroNomina.Rows(0)("BANCO") Is DBNull.Value AndAlso DTCabeceroNomina.Rows(0)("BANCO").ToString.Trim <> "" Then
                AttNomina = CFDI.CreateAttribute("Banco")
                AttNomina.Value = DTCabeceroNomina.Rows(0)("BANCO").ToString.Trim
                Nomina.Attributes.Append(AttNomina)
            End If

            If Not DTCabeceroNomina.Rows(0)("FECHAINICIORELLABORAL") Is DBNull.Value AndAlso DTCabeceroNomina.Rows(0)("FECHAINICIORELLABORAL") <> "" Then
                AttNomina = CFDI.CreateAttribute("FechaInicioRelLaboral")
                ObjNomina.FechaInicioRelLaboral = DTCabeceroNomina.Rows(0)("FECHAINICIORELLABORAL")
                AttNomina.Value = ObjNomina.FechaInicioRelLaboral.ToString("yyyy-MM-dd")
                Nomina.Attributes.Append(AttNomina)
            End If

            If Not DTCabeceroNomina.Rows(0)("ANTIGUEDAD") Is DBNull.Value AndAlso DTCabeceroNomina.Rows(0)("ANTIGUEDAD").ToString.Trim <> "" Then
                AttNomina = CFDI.CreateAttribute("Antiguedad")
                AttNomina.Value = DTCabeceroNomina.Rows(0)("ANTIGUEDAD").ToString.Trim
                Nomina.Attributes.Append(AttNomina)
            End If

            If Not DTCabeceroNomina.Rows(0)("PUESTO") Is DBNull.Value AndAlso DTCabeceroNomina.Rows(0)("PUESTO").ToString.Trim <> "" Then
                AttNomina = CFDI.CreateAttribute("Puesto")
                AttNomina.Value = DTCabeceroNomina.Rows(0)("PUESTO").ToString.Trim
                Nomina.Attributes.Append(AttNomina)
            End If

            If Not DTCabeceroNomina.Rows(0)("TIPOCONTRATO") Is DBNull.Value AndAlso DTCabeceroNomina.Rows(0)("TIPOCONTRATO").ToString.Trim <> "" Then
                AttNomina = CFDI.CreateAttribute("TipoContrato")
                AttNomina.Value = DTCabeceroNomina.Rows(0)("TIPOCONTRATO").ToString.Trim
                Nomina.Attributes.Append(AttNomina)
            End If

            If Not DTCabeceroNomina.Rows(0)("TIPOJORNADA") Is DBNull.Value AndAlso DTCabeceroNomina.Rows(0)("TIPOJORNADA") <> "" Then
                AttNomina = CFDI.CreateAttribute("TipoJornada")
                AttNomina.Value = DTCabeceroNomina.Rows(0)("TIPOJORNADA")
                Nomina.Attributes.Append(AttNomina)
            End If

            If Not DTCabeceroNomina.Rows(0)("PERIODICIDADPAGO") Is DBNull.Value AndAlso DTCabeceroNomina.Rows(0)("PERIODICIDADPAGO") <> "" Then
                AttNomina = CFDI.CreateAttribute("PeriodicidadPago")
                AttNomina.Value = DTCabeceroNomina.Rows(0)("PERIODICIDADPAGO")
                Nomina.Attributes.Append(AttNomina)
            End If

            If Not DTCabeceroNomina.Rows(0)("SALARIOBASECOTAPOR") Is DBNull.Value AndAlso DTCabeceroNomina.Rows(0)("SALARIOBASECOTAPOR") <> "" Then
                AttNomina = CFDI.CreateAttribute("SalarioBaseCotApor")
                AttNomina.Value = DTCabeceroNomina.Rows(0)("SALARIOBASECOTAPOR")
                Nomina.Attributes.Append(AttNomina)
            End If

            If Not DTCabeceroNomina.Rows(0)("RIESGOPUESTO") Is DBNull.Value AndAlso DTCabeceroNomina.Rows(0)("RIESGOPUESTO") <> "" Then
                AttNomina = CFDI.CreateAttribute("RiesgoPuesto")
                AttNomina.Value = DTCabeceroNomina.Rows(0)("RIESGOPUESTO")
                Nomina.Attributes.Append(AttNomina)
            End If

            If Not DTCabeceroNomina.Rows(0)("SALARIODIARIOINTEGRADO") Is DBNull.Value AndAlso DTCabeceroNomina.Rows(0)("SALARIODIARIOINTEGRADO") <> "" Then
                AttNomina = CFDI.CreateAttribute("SalarioDiarioIntegrado")
                AttNomina.Value = DTCabeceroNomina.Rows(0)("SALARIODIARIOINTEGRADO")
                Nomina.Attributes.Append(AttNomina)
            End If

            'ObjNomina.AntiguedadSpecified = False
            'ObjNomina.FechaInicioRelLaboralSpecified = False
            'ObjNomina.RiesgoPuestoSpecified = False
            'ObjNomina.SalarioBaseCotAporSpecified = False
            'ObjNomina.SalarioDiarioIntegradoSpecified = False


            ' Crea el Nodo de Percepciones

            Dim vnTotalExentoPercepciones As Decimal = 0
            Dim vnTotalGravadoPercepciones As Decimal = 0

            Dim Percepciones As XmlNode = CFDI.CreateElement("nomina", "Percepciones", "http://www.sat.gob.mx/nomina")



            For Each vRowPercep As DataRow In DTPercepciones.Rows

                vnTotalExentoPercepciones += vRowPercep("IMPORTEEXENTO")
                vnTotalGravadoPercepciones += vRowPercep("IMPORTEGRAVADO")

            Next


            AttPercepciones = CFDI.CreateAttribute("TotalGravado")
            AttPercepciones.Value = vnTotalGravadoPercepciones
            Percepciones.Attributes.Append(AttPercepciones)

            AttPercepciones = CFDI.CreateAttribute("TotalExento")
            AttPercepciones.Value = vnTotalExentoPercepciones
            Percepciones.Attributes.Append(AttPercepciones)


            For Each vRowPercep As DataRow In DTPercepciones.Rows

                Dim Percepcion As XmlNode = CFDI.CreateElement("nomina", "Percepcion", "http://www.sat.gob.mx/nomina")
                AsignaValoresPercepcionesComplementoNomina(CFDI, vRowPercep, Percepcion)

                ' Anexa el nodo de Percepcion al de Percepciones
                Percepciones.AppendChild(Percepcion)

            Next

            If DTPercepciones.Rows.Count > 0 Then
                ' Anexa el nodo de Percepciones al de Nomina
                Nomina.AppendChild(Percepciones)
            End If


            Dim vnTotalExentoDeducciones As Decimal = 0
            Dim vnTotalGravadoDeducciones As Decimal = 0



            ' Crea el Nodo de Percepciones
            Dim Deducciones As XmlNode = CFDI.CreateElement("nomina", "Deducciones", "http://www.sat.gob.mx/nomina")


            For Each vRowDeduc As DataRow In DTDeducciones.Rows

                vnTotalExentoDeducciones += vRowDeduc("IMPORTEEXENTO")
                vnTotalGravadoDeducciones += vRowDeduc("IMPORTEGRAVADO")

            Next

            AttDeducciones = CFDI.CreateAttribute("TotalGravado")
            AttDeducciones.Value = vnTotalGravadoDeducciones
            Deducciones.Attributes.Append(AttDeducciones)

            AttDeducciones = CFDI.CreateAttribute("TotalExento")
            AttDeducciones.Value = vnTotalExentoDeducciones
            Deducciones.Attributes.Append(AttDeducciones)

            For Each vRowDeduc As DataRow In DTDeducciones.Rows

                Dim Deduccion As XmlNode = CFDI.CreateElement("nomina", "Deduccion", "http://www.sat.gob.mx/nomina")

                AsignaValoresDeduccionesComplementoNomina(CFDI, vRowDeduc, Deduccion)

                ' Anexa el nodo de Percepcion al de Percepciones
                Deducciones.AppendChild(Deduccion)

            Next

            If DTDeducciones.Rows.Count > 0 Then
                Nomina.AppendChild(Deducciones)
            End If

            ' Anexa el nodo de Percepciones al de Nomina


            Dim Complemento As XmlNode = CFDI.CreateElement("cfdi", "Complemento", "http://www.sat.gob.mx/cfd/3")

            ' Anexa el nodo de Nomina a la raiz
            Complemento.AppendChild(Nomina)

            ' Anexa el nodo de Complemento a la raiz
            ElementoComprobante.AppendChild(Complemento)

            Dim AttSello As XmlAttribute
            Dim vcSello As String
            Dim otrasRutinas As New V32.OtrasRutinas()
            Dim cadenaOriginal As String = ""


            CFDI.Save(vcXMLTemporal2)

            cadenaOriginal = GetCadenaOriginal(vcXMLTemporal2, vcRutaEstiloCadenaOriginal32)

            vcSello = otrasRutinas.GenerarSelloDigital(vObjCabecera.RutaKey, vObjCabecera.PassKey, cadenaOriginal)

            CFDI.Load(vcXMLTemporal2)

            ElementoComprobante = CFDI.DocumentElement()

            AttSello = ElementoComprobante.Attributes.ItemOf("sello")
            AttSello.Value = vcSello
            ElementoComprobante.Attributes.SetNamedItem(AttSello)


            If File.Exists(vObjCabecera.RutaXml & "\" & vObjCabecera.RFC & "_" & vObjCabecera.EFSERIE.Trim & vObjCabecera.EFFACTURA & ".xml") Then
                Kill(vObjCabecera.RutaXml & "\" & vObjCabecera.RFC & "_" & vObjCabecera.EFSERIE.Trim & vObjCabecera.EFFACTURA & ".xml")
            End If

            CFDI.Save(vObjCabecera.RutaXml & "\" & vObjCabecera.RFC & "_" & vObjCabecera.EFSERIE.Trim & vObjCabecera.EFFACTURA & ".xml")

            vcNombreID = vObjCabecera.RFC & "_" & vObjCabecera.EFSERIE.Trim & vObjCabecera.EFFACTURA.Trim

            Dim vObjTimbra As New ClsFD

            vObjTimbra.Connect(atrConexion)

            vcTimbrado = vObjTimbra.Timbra(vObjCabecera.RutaXml & "\" & vObjCabecera.RFC & "_" & vObjCabecera.EFSERIE.Trim & vObjCabecera.EFFACTURA & ".xml", prmID, vObjCabecera.DestinoXml, _
                              vObjCabecera.DestinoAcuseXml, vObjCabecera.RutaBidimensional, vObjCabecera.UsuarioWS, _
                              vObjCabecera.PasswordWS, vObjCabecera.RFC, vObjCabecera.CLIENTERFC, vObjCabecera.EFIMPORTE, cadenaOriginal, vcNombreID)


            Return vcTimbrado

        Catch ex As Exception
            Return ex.Message
        End Try
    End Function




    Public Function CancelaFacturaElectronica(ByVal prmID As String) As String
        Dim vcResultado As String
        Dim vObjTimbra As New ClsFD

        CancelaFacturaElectronica = ""

        Try
            vcResultado = vObjTimbra.Cancela(prmID)
        Catch ex As Exception
            vcResultado = ex.Message
        End Try

        CancelaFacturaElectronica = vcResultado

    End Function

#End Region

#Region "Métodos Privados"
    Private Function AsignaValoresConceptos(ByRef prmConcepto As V32.ComprobanteConcepto, ByVal vRow As DataRow) As String
        Try
            prmConcepto.descripcion = IIf(vRow("DFCONCEPTO") Is DBNull.Value, "", vRow("DFCONCEPTO"))
            prmConcepto.cantidad = IIf(vRow("DFCANTIDAD") Is DBNull.Value, 0, vRow("DFCANTIDAD"))
            prmConcepto.valorUnitario = IIf(vRow("DFPRECIO") Is DBNull.Value, 0, vRow("DFPRECIO"))
            prmConcepto.importe = IIf(vRow("DFSUBTOTALDD") Is DBNull.Value, 0, vRow("DFSUBTOTALDD"))
            prmConcepto.unidad = IIf(vRow("DFDESCUNIDAD") Is DBNull.Value, "", vRow("DFDESCUNIDAD"))
            prmConcepto.noIdentificacion = IIf(vRow("DFCLAVEARTICULO") Is DBNull.Value, "", IIf(vRow("DFCLAVEARTICULO") <> "0", vRow("DFCLAVEARTICULO"), 0))

            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Private Function AsignaValoresImpuestos(ByRef prmImpuesto As V32.ComprobanteImpuestosTraslado, ByVal vRow As DataRow) As String

        Try
            prmImpuesto.importe = vRow("DIIMPORTE")
            prmImpuesto.impuesto = IIf(vRow("DIIMPUESTO") = "IVA", V32.ComprobanteImpuestosTrasladoImpuesto.IVA, V32.ComprobanteImpuestosTrasladoImpuesto.IEPS)
            prmImpuesto.tasa = vRow("DITASA")
            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Private Sub AsignaValoresImpuestosTraslados(ByRef prmImpuesto As V32.ComprobanteImpuestosTraslado, ByVal vRow As DataRow)

        prmImpuesto.importe = vRow("DIIMPORTE")
        prmImpuesto.impuesto = IIf(vRow("DIIMPUESTO") = "IVA", V32.ComprobanteImpuestosTrasladoImpuesto.IVA, V32.ComprobanteImpuestosTrasladoImpuesto.IEPS)
        prmImpuesto.tasa = vRow("DITASA")

    End Sub

    Private Sub AsignaValoresImpuestosRetenidos(ByRef prmImpuesto As V32.ComprobanteImpuestosRetencion, ByVal vRow As DataRow)

        prmImpuesto.importe = vRow("DIIMPORTE")
        prmImpuesto.impuesto = IIf(vRow("DIIMPUESTO") = "IVA", V32.ComprobanteImpuestosRetencionImpuesto.IVA, V32.ComprobanteImpuestosRetencionImpuesto.ISR)

    End Sub


    Private Sub AsignaValoresPercepcionesComplementoNomina(ByRef prmCFDI As XmlDocument, ByVal vRow As DataRow, ByRef prmPercepcion As XmlNode)


        Dim AttPercepciones As XmlAttribute

        AttPercepciones = prmCFDI.CreateAttribute("Clave")
        AttPercepciones.Value = vRow("CLAVE")
        prmPercepcion.Attributes.Append(AttPercepciones)

        AttPercepciones = prmCFDI.CreateAttribute("Concepto")
        AttPercepciones.Value = vRow("CONCEPTO")
        prmPercepcion.Attributes.Append(AttPercepciones)

        AttPercepciones = prmCFDI.CreateAttribute("ImporteExento")
        AttPercepciones.Value = vRow("IMPORTEEXENTO")
        prmPercepcion.Attributes.Append(AttPercepciones)

        AttPercepciones = prmCFDI.CreateAttribute("ImporteGravado")
        AttPercepciones.Value = vRow("IMPORTEGRAVADO")
        prmPercepcion.Attributes.Append(AttPercepciones)

        AttPercepciones = prmCFDI.CreateAttribute("TipoPercepcion")
        AttPercepciones.Value = vRow("TIPOPERCEPCION")
        prmPercepcion.Attributes.Append(AttPercepciones)

    End Sub

    Private Sub AsignaValoresDeduccionesComplementoNomina(ByRef prmCFDI As XmlDocument, ByVal vRow As DataRow, ByRef prmDeduccion As XmlNode)


        Dim AttDeducciones As XmlAttribute

        AttDeducciones = prmCFDI.CreateAttribute("Clave")
        AttDeducciones.Value = vRow("CLAVE")
        prmDeduccion.Attributes.Append(AttDeducciones)

        AttDeducciones = prmCFDI.CreateAttribute("Concepto")
        AttDeducciones.Value = vRow("CONCEPTO")
        prmDeduccion.Attributes.Append(AttDeducciones)

        AttDeducciones = prmCFDI.CreateAttribute("ImporteExento")
        AttDeducciones.Value = vRow("IMPORTEEXENTO")
        prmDeduccion.Attributes.Append(AttDeducciones)

        AttDeducciones = prmCFDI.CreateAttribute("ImporteGravado")
        AttDeducciones.Value = vRow("IMPORTEGRAVADO")
        prmDeduccion.Attributes.Append(AttDeducciones)

        AttDeducciones = prmCFDI.CreateAttribute("TipoDeduccion")
        AttDeducciones.Value = vRow("TIPODEDUCCION")
        prmDeduccion.Attributes.Append(AttDeducciones)

    End Sub







#End Region

#Region "Propiedades"
    Private ReadOnly Property DAO() As Sistema.DataAccessCls
        Get
            Return atrConexion
        End Get
    End Property
#End Region

#Region "Constructor"
    Public Sub New()
        MyBase.New()
    End Sub

#End Region

End Class
