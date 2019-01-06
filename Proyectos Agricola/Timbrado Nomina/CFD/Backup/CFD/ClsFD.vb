Imports Sistema.DataAccessCls
Imports System.Xml
Imports System.IO
Imports System.Collections
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports QRCodeLib


Public Class ClsFD

#Region "Constructor"
    Public Sub New()
        'Public Sub New(ByVal prmFactura As String, ByVal prmUsuario As String, ByVal prmPassword As String)
        MyBase.New()
        'atrFactura = prmFactura
        'atrUsuario = prmUsuario
        'atrPassword = prmPassword
    End Sub
#End Region

#Region "Atributos"
    Private atrDAO As New Sistema.DataAccessCls
    Dim Respuesta As New WSFD.ArrayOfString
    Dim aUUIDCancelados As New WSFD.ArrayOfString
    Private dt As DataTable
    Private da As SqlDataAdapter
    Private fila As Integer

    Private atrFechatimbrado As Date
    Private atrUUID As String
    Private atrCertificadoSat As String
    Private atrSelloSat As String
    Private atrSello As String
    Private atrFechaCancelacion As Date
    Private atrCertificado As String

    Private atrPasswordCancelacion As String
    Private atrCertificadoCancelacion As String
    Private atrRfcEmisor As String


#End Region

#Region "Propiedades"
    Public Property DAO() As Sistema.DataAccessCls
        Get
            Return atrDAO
        End Get
        Set(ByVal value As Sistema.DataAccessCls)
            atrDAO = value
        End Set
    End Property

    Public ReadOnly Property UUID() As String
        Get
            Return atrUUID
        End Get
    End Property

    Public ReadOnly Property Fechatimbrado() As Date
        Get
            Return atrFechatimbrado
        End Get
    End Property

    Public ReadOnly Property CertificadoSat() As String
        Get
            Return atrCertificadoSat
        End Get
    End Property

    Public ReadOnly Property Certificado() As String
        Get
            Return atrCertificado
        End Get
    End Property


    Public ReadOnly Property SelloSat() As String
        Get
            Return atrSelloSat
        End Get
    End Property


#End Region

#Region "Metodos"
    Public Sub Connect(ByRef prmDAO As Sistema.DataAccessCls)
        atrDAO = prmDAO
    End Sub

    Public Function Timbra(ByVal prmRutaXML As String, ByVal prmID As String, ByVal prmDestinoXML As String, _
                           ByVal prmDestinoAcuseXML As String, ByVal prmRutaBidimensional As String, ByVal vcUsuarioWS As String, _
                           ByVal vcPasswordWS As String, ByVal prmRFCEmisor As String, _
                           ByVal prmRFCReceptor As String, ByVal prmTotal As Decimal, ByVal prmCadenaOriginal As String, ByVal prmNombreID As String) As String

        Dim ServicioFD As New WSFD.WS_FD_TFDSoapClient
        Dim vcCadenaXML As String
        Dim objReader As New StreamReader(prmRutaXML)
        Dim sLine As String = ""
        Dim arrText As New ArrayList()
        Dim vcResultXML As String
        Dim vcResultActualiza As String


        Timbra = ""
        Try
            vcCadenaXML = ""
            Do
                sLine = objReader.ReadLine()
                If Not sLine Is Nothing Then
                    vcCadenaXML += sLine & vbCrLf
                End If
            Loop Until sLine Is Nothing
            objReader.Close()


            Respuesta = ServicioFD.TimbrarCFD(vcUsuarioWS, vcPasswordWS, vcCadenaXML, prmID)



            ' en cado de que el timbrado haya sido con exito
            If Respuesta(0).ToString = "" And Respuesta(1).ToString = "" And Respuesta(2).ToString = "" Then

                If File.Exists(prmDestinoXML & "\" & prmNombreID & ".xml") Then
                    Kill(prmDestinoXML & "\" & prmNombreID & ".xml")
                End If

                Dim swxml As New System.IO.StreamWriter(prmDestinoXML & "\" & prmNombreID & ".xml", True)
                swxml.WriteLine(Respuesta(3))
                swxml.Close()


                vcResultXML = ExtraeXML(prmDestinoXML & "\" & prmNombreID & ".xml")

                If vcResultXML <> "" Then
                    Return vcResultXML
                End If


                Respuesta = ServicioFD.ObtenerAcuseEnvio(vcUsuarioWS, vcPasswordWS, atrUUID, prmRFCEmisor)


                If Strings.UCase(Respuesta(0).ToString) = "TRUE" And Respuesta(1).ToString = "" And Respuesta(2).ToString = "" Then

                    If File.Exists(prmDestinoAcuseXML & "\" & prmNombreID & ".xml") Then
                        Kill(prmDestinoAcuseXML & "\" & prmNombreID & ".xml")
                    End If

                    Dim swxmlacuse As New System.IO.StreamWriter(prmDestinoAcuseXML & "\" & prmNombreID & ".xml", True)
                    swxmlacuse.WriteLine(Respuesta(3))
                    swxmlacuse.Close()
                End If

                vcResultActualiza = flActualizaTimbrado(prmID, prmRutaBidimensional, prmRFCEmisor, prmRFCReceptor, prmTotal, prmCadenaOriginal)
                Return vcResultActualiza
            Else

                Dim vcResultado As String

                vcResultado = ""

                For i = 0 To Respuesta.Count - 1
                    vcResultado = vcResultado & "|" & Respuesta(i)
                Next

                Return vcResultado
            End If
        Catch ex As Exception
            Return ex.Message.ToString
        End Try
    End Function

    Public Function Cancela(ByVal prmID As Long) As String

        Dim ServicioFD As New WSFD.WS_FD_TFDSoapClient
        Dim vlUUIDCancelacion As String
        Dim vObjCabecera As New Access.DatosCab
        Dim vcResultado As String

        Cancela = ""
        vcResultado = ""

        vObjCabecera = Access.FabricaDatosCFDI32.ObtenDatosEncabezado(prmID)

        If vObjCabecera Is Nothing Then
            Cancela = "No se encontro esa clave, favor de verificar"
            Exit Function
        End If

        vlUUIDCancelacion = vObjCabecera.EFUUID

        aUUIDCancelados.Clear()

        aUUIDCancelados.Add(vlUUIDCancelacion)


        If vlUUIDCancelacion <> "" Then
            Respuesta = ServicioFD.CancelarCFDI(vObjCabecera.UsuarioWS, vObjCabecera.PasswordWS, vObjCabecera.RFC, aUUIDCancelados, vObjCabecera.SelloCancelacion, vObjCabecera.PassCancelacion)            

            ' en caso de que el timbrado haya sido con exito

            For i = 0 To Respuesta.Count - 1
                If Respuesta(i) <> "" Then
                    If Strings.InStr(UCase(Respuesta(i)), UCase("UUID Cancelado")) <> 0 Or Strings.InStr(UCase(Respuesta(i)), UCase("Previamente Cancelado")) <> 0 Then
                        Dim swxmlacuse As New System.IO.StreamWriter(vObjCabecera.AcuseCancelacion & "\" & prmID & ".xml", True)
                        swxmlacuse.WriteLine(Respuesta(i + 1))
                        swxmlacuse.Close()
                        ExtraeXMLCancelacion(vObjCabecera.AcuseCancelacion & "\" & prmID & ".xml")
                        vcResultado = ActualizaFechaCancelacion(prmID)
                        Return vcResultado
                    End If
                End If
                vcResultado = vcResultado & "|" & Respuesta(i)
            Next
            Return vcResultado & "|" & vObjCabecera.EFUUID

        Else
            Return "No existe la Factura para su cancelación "
        End If


    End Function

    Public Function TimbresLibres(ByVal prmUsuario As String, ByVal prmPassword As String) As Integer

        Dim ServicioFD As New WSFD.WS_FD_TFDSoapClient
        Respuesta = ServicioFD.ConsultarCreditos(prmUsuario, prmPassword)

        If Not Respuesta Is Nothing Then
            If Respuesta.Count = 3 Then
                Return Respuesta(2)
            End If
        End If

    End Function

    Public Function RecuperaXML(ByVal prmFactura As String, ByVal prmRFC As String) As Boolean

        Dim ServicioFD As New WSFD.WS_FD_TFDSoapClient
        Dim vcUsuarioWS As String
        Dim vcPasswordWS As String

        vcUsuarioWS = DAO.RegresaDatoSQL("SELECT CUSUARIOWS FROM FE_CERTIFICADOS")
        vcPasswordWS = DAO.RegresaDatoSQL("SELECT CPASSWORDWS FROM FE_CERTIFICADOS")

        Respuesta = ServicioFD.ObtenerXML(vcUsuarioWS, vcPasswordWS, prmFactura, prmRFC)


    End Function

    Public Function RecuperaAcuseTimbrado(ByVal prmFactura As String, ByVal prmRFC As String) As Boolean

        Dim ServicioFD As New WSFD.WS_FD_TFDSoapClient
        Dim vcUsuarioWS As String
        Dim vcPasswordWS As String

        vcUsuarioWS = DAO.RegresaDatoSQL("SELECT CUSUARIOWS FROM FE_CERTIFICADOS")
        vcPasswordWS = DAO.RegresaDatoSQL("SELECT CPASSWORDWS FROM FE_CERTIFICADOS")

        Respuesta = ServicioFD.ObtenerAcuseEnvio(vcUsuarioWS, vcPasswordWS, prmFactura, prmRFC)

    End Function

    Public Function RecuperaAcuseCancelacion(ByVal prmFactura As String, ByVal prmRFC As String) As Boolean

        Dim ServicioFD As New WSFD.WS_FD_TFDSoapClient
        Dim vcUsuarioWS As String
        Dim vcPasswordWS As String

        vcUsuarioWS = DAO.RegresaDatoSQL("SELECT CUSUARIOWS FROM FE_CERTIFICADOS")
        vcPasswordWS = DAO.RegresaDatoSQL("SELECT CPASSWORDWS FROM FE_CERTIFICADOS")

        Respuesta = ServicioFD.ObtenerAcuseCancelacion(vcUsuarioWS, vcPasswordWS, prmFactura, prmRFC)

    End Function

    Public Function CreaBidimensional() As String

        Try

            Dim ObjCodigoBidimensional As New Bidimensional

            Dim vcCadena As String
            If File.Exists("C:\BIDI.JPG") Then
                Kill("C:\BIDI.JPG")
            End If

            vcCadena = "ENRIQUE ALONSO CORRAL AGUILAR"

            If Not ObjCodigoBidimensional.CreaBidimensional(vcCadena, "C:\BIDI.JPG", "Byte", 4, 7, "M", "Jpeg") Then
                Return "Ha ocurrido un error al generar el codigo Bidimensional"
            End If
            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function


#End Region

#Region "Funciones Privadas"
    Private Function ExtraeXML(ByVal prmDestinoXml As String) As String

        Dim objReaderXML As New StreamReader(prmDestinoXml)
        Dim sLineXML As String = ""
        Dim arrTextXML As New ArrayList()
        Dim vlPosicion As Integer
        Dim vlPosicion2 As Integer

        Try
            Do
                sLineXML = objReaderXML.ReadLine()
                If Not sLineXML Is Nothing Then
                    vlPosicion = InStr(sLineXML, "FechaTimbrado")
                    atrFechatimbrado = Mid(sLineXML, vlPosicion + 15, 19)

                    vlPosicion = InStr(sLineXML, "sello=")
                    atrSello = Mid(sLineXML, vlPosicion + 7, InStr(Mid(sLineXML, vlPosicion + 6), "xsi") - 4)

                    vlPosicion = InStr(sLineXML, "noCertificado=")
                    atrCertificado = Mid(sLineXML, vlPosicion + 15, 20)

                    vlPosicion = InStr(sLineXML, "UUID=")
                    atrUUID = Mid(sLineXML, vlPosicion + 6, 36)

                    vlPosicion = InStr(sLineXML, "noCertificadoSAT=")
                    atrCertificadoSat = Mid(sLineXML, vlPosicion + 18, 20)

                    vlPosicion = InStr(sLineXML, "selloSAT=")
                    vlPosicion2 = InStr(sLineXML, "version=" & """1.0""" & " xsi:schemaLocation")

                    atrSelloSat = Mid(sLineXML, vlPosicion + 10, 171)


                End If
            Loop Until sLineXML Is Nothing
            objReaderXML.Close()

            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Private Function ExtraeXMLCancelacion(ByVal prmDestinoXml As String) As Boolean

        ExtraeXMLCancelacion = True

        Dim objReaderXML As New StreamReader(prmDestinoXml)
        Dim sLineXML As String = ""
        Dim arrTextXML As New ArrayList()
        Dim vlPosicion As Integer

        Do
            sLineXML = objReaderXML.ReadLine()
            If Not sLineXML Is Nothing Then
                vlPosicion = InStr(sLineXML, "Fecha")
                If vlPosicion > 0 Then
                    atrFechaCancelacion = Mid(sLineXML, vlPosicion + 7, 19)
                End If
            End If
        Loop Until sLineXML Is Nothing
        objReaderXML.Close()

    End Function


    Private Function ActualizaFechaCancelacion(ByVal prmID As Long) As String
        Dim cb As New SqlCommandBuilder(da)

        atrDAO = Sistema.DataAccessCls.DevuelveInstancia()
        'Dim sCnn As String = "Data Source=" & DAO.GetNombreServidor & ";Initial Catalog=" & DAO.GetNombreBaseDeDatos & ";User ID=" & DAO.GetLoginUsuario & ";Password=" & DAO.GetPassUsuario & ";"
        Dim sCnn As String = "Data Source=" & atrDAO.GetNombreServidor & ";Initial Catalog=" & atrDAO.GetNombreBaseDeDatos & ";User ID=" & atrDAO.GetLoginUsuario & ";Password=" & atrDAO.GetPassUsuario & ";"
        'Dim sCnn As String = "Data Source=ENRIQUEPC\SQL2008;Initial Catalog=EMPAQUE;User ID=sa;Password=prima2011;"

        Dim cnn As New SqlConnection(sCnn)

        ' La cadena de selección
        Dim sSel As String = "SELECT * FROM FAC_CFDI WHERE NFACTURA = " & prmID
        '
        ' Comprobar si hay algún error
        Try
            ' Crear un nuevo objeto del tipo DataAdapter
            da = New SqlDataAdapter(sSel, sCnn)
            ' Crear los comandos de insertar, actualizar y eliminar
            cb = New SqlCommandBuilder(da)
            ' Como hay campos con caracteres especiales,
            ' al usarlos incluirlos entre corchetes.
            cb.QuotePrefix = "["
            cb.QuoteSuffix = "]"
            ' Asignar los comandos al DataAdapter
            ' (se supone que lo hace automáticamente, pero...)
            da.UpdateCommand = cb.GetUpdateCommand
            da.InsertCommand = cb.GetInsertCommand
            da.DeleteCommand = cb.GetDeleteCommand
            '
            ' Esta base de datos usa el ID con valores automáticos
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey
            '
            dt = New DataTable
            ' Llenar la tabla con los datos indicados
            da.Fill(dt)
            '

            ' Y mostrar el primer registro
            If dt.Rows.Count > 0 Then
                Dim dr As DataRow
                dr = dt.Rows(0)
                dr("DFECHACANCELACION") = atrFechaCancelacion
                da.Update(dt)
                dt.AcceptChanges()
            Else
                fila = -1
            End If
            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try

    End Function

    Private Function flActualizaTimbrado(ByVal prmID As String, ByVal prmRutaBidimensional As String, _
                                         ByVal prmRFCEmisor As String, ByVal prmRFCReceptor As String, ByVal prmTotal As Decimal, _
                                         ByVal prmCadenaOriginal As String) As String

        Dim cb As New SqlCommandBuilder(da)
        Dim ObjCodigoBidimensional As New Bidimensional
        Dim vbCreoImagen As Boolean

        Try

            atrDAO = Sistema.DataAccessCls.DevuelveInstancia()
            'Dim sCnn As String = "Data Source=" & DAO.GetNombreServidor & ";Initial Catalog=" & DAO.GetNombreBaseDeDatos & ";User ID=" & DAO.GetLoginUsuario & ";Password=" & DAO.GetPassUsuario & ";"
            Dim sCnn As String = "Data Source=" & atrDAO.GetNombreServidor & ";Initial Catalog=" & atrDAO.GetNombreBaseDeDatos & ";User ID=" & atrDAO.GetLoginUsuario & ";Password=" & atrDAO.GetPassUsuario & ";"
            'Dim sCnn As String = "Data Source=ENRIQUEPC\SQL2008;Initial Catalog=EMPAQUE;User ID=sa;Password=prima2011;"

            Dim cnn As New SqlConnection(sCnn)
            Dim vlCadena As String

            ' La cadena de selección
            Dim sSel As String = "SELECT * FROM FAC_CFDI WHERE nFactura = " & prmID
            '
            ' Comprobar si hay algún error



            vlCadena = "?re="
            vlCadena += prmRFCEmisor
            vlCadena += "&rr="
            vlCadena += prmRFCReceptor
            vlCadena += "&tt="
            vlCadena += Format(prmTotal, "000000###.00")
            vlCadena += "&id="
            vlCadena += UUID

            vbCreoImagen = True
            Try
                If Not ObjCodigoBidimensional.CreaBidimensional(vlCadena, prmRutaBidimensional & "\" & prmID & ".jpg", "Byte", 4, 7, "M", "Jpeg") Then
                    vbCreoImagen = False
                    Return "Ha ocurrido un error al generar el codigo Bidimensional"
                End If
            Catch ex As Exception
                Return "ERROR al crear la imagen:" & vbCrLf & ex.Message
            End Try


            ' Crear un nuevo objeto del tipo DataAdapter
            da = New SqlDataAdapter(sSel, sCnn)
            ' Crear los comandos de insertar, actualizar y eliminar
            cb = New SqlCommandBuilder(da)
            ' Como hay campos con caracteres especiales,
            ' al usarlos incluirlos entre corchetes.
            cb.QuotePrefix = "["
            cb.QuoteSuffix = "]"
            ' Asignar los comandos al DataAdapter
            ' (se supone que lo hace automáticamente, pero...)
            da.UpdateCommand = cb.GetUpdateCommand
            da.InsertCommand = cb.GetInsertCommand
            da.DeleteCommand = cb.GetDeleteCommand
            '
            ' Esta base de datos usa el ID con valores automáticos
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey
            '
            dt = New DataTable
            ' Llenar la tabla con los datos indicados
            da.Fill(dt)
            '

            ' Y mostrar el primer registro
            If dt.Rows.Count = 0 Then
                Dim dr As DataRow
                dr = dt.NewRow
                'dt.Rows.Add(dr)
                If vbCreoImagen Then
                    'Dim dr As DataRow = dt.Rows(fila)
                    Dim ruta As New FileStream(prmRutaBidimensional & "\" & prmID & ".JPG", FileMode.OpenOrCreate, FileAccess.Read)
                    Dim binario(ruta.Length) As Byte
                    ruta.Read(binario, 0, ruta.Length)
                    ruta.Close()
                    dr("CBB") = binario

                End If

                dr("nFactura") = prmID
                dr("CSELLO") = atrSello
                dr("CCADENA") = prmCadenaOriginal
                dr("UUID") = UUID
                dr("DFECHATIMBRADO") = Fechatimbrado
                dr("CCERTIFICADOSAT") = CertificadoSat
                dr("CSELLOSAT") = SelloSat
                dr("CCERTIFICADO") = Certificado

                dt.Rows.Add(dr)
                da.Update(dt)
                dt.AcceptChanges()
            Else
                fila = -1
            End If
            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try

    End Function

#End Region

End Class

