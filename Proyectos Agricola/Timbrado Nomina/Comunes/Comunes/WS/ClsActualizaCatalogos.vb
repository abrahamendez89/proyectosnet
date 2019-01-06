Imports System.Windows.Forms
Imports Access
Imports ADSUM

Namespace Comunes.Comun.WS
    Public Class ClsActualizaCatalogos


#Region "Declaraciones"
        Private DAO As DataAccessCls
        Private atrnPlazaSistema As Int32 = 0
        Private atrMuestraMensajes As Boolean = False
        Private gFrmWait As frmStatus
        Private atrLog As EventLog
        Private atrMuestraMensajeConfirmacion As Boolean = True
        Private atrContextosActualizar As String = "COM,INV"
#End Region

#Region "Constructores"
        Public Sub New(ByVal prmMostrarMensajes As Boolean)
            If Not prmMostrarMensajes Then
                DAO = DataAccessCls.DevuelveInstancia("ADSUMADK")
            Else
                DAO = DataAccessCls.DevuelveInstancia
            End If
            DAO.ParametroAdministradoAgregar("PRMSUC", "ClsActualizaCatalogos_PLAZA_ACTUALIZA_CATALOGOS", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para saber si la plaza actualizará sus catálogos solicitando la información al Corporativo", 1)
            DAO.ParametroAdministradoAgregar("PRMSUC", "ClsActualizaCatalogos_NUMERO_ULTIMOS_DIAS_MODIFICACION_PARA_ACTUALIZAR", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para saber cuantos días hacia atrás de la fecha actual se quitarán para tomar los datos de los catálogos, en base a los datos comunes", 1)
            atrnPlazaSistema = DAO.ParametroAdministradoObtener("PRMSUC", "PLAZA")
            atrMuestraMensajes = prmMostrarMensajes
            gFrmWait = New frmStatus
        End Sub
#End Region

#Region "Propiedades Privadas"
        Public Property ContextosActualizar() As String
            Get
                Return atrContextosActualizar
            End Get
            Set(ByVal value As String)
                atrContextosActualizar = value
            End Set
        End Property
        Public ReadOnly Property ValidaPlazaActualizaCatalogos() As Boolean
            Get
                Return FlValidaPermisoActualizarCatalogos()
            End Get
        End Property
#End Region
#Region "Propiedades Públicas"
        Public Property Log() As EventLog
            Get
                Return atrLog
            End Get
            Set(ByVal value As EventLog)
                atrLog = value
            End Set
        End Property
        Public Property MuestraMensajeConfirmacionUsuario() As Boolean
            Get
                Return atrMuestraMensajeConfirmacion
            End Get
            Set(ByVal value As Boolean)
                atrMuestraMensajeConfirmacion = value
            End Set
        End Property
#End Region

#Region "Funciones y Procedimientos"
#Region "Funciones"
        Private Function FlValidaPermisoActualizarCatalogos() As Boolean
            Return DAO.ParametroAdministradoObtener("PRMSUC", "ClsActualizaCatalogos_PLAZA_ACTUALIZA_CATALOGOS") = 1
        End Function
        ' ''Public Function ActualizaCatalogos() As Boolean
        ' ''    Try
        ' ''        PlMensajeEstatusMostrar("Configurando WS")

        ' ''        Dim DAO As DataAccessCls
        ' ''        If Not atrMuestraMensajes Then
        ' ''            DAO = DataAccessCls.DevuelveInstancia("ADSUMADK")
        ' ''        Else
        ' ''            DAO = DataAccessCls.DevuelveInstancia
        ' ''        End If

        ' ''        Dim vArregloByte As Byte()

        ' ''        Dim wsSincronizaCatalogos As WSBaseComun.catalogos
        ' ''        wsSincronizaCatalogos = New WSBaseComun.catalogos
        ' ''        wsSincronizaCatalogos.Url = DAO.ParametroAdministradoObtener("PRM", "WSCORPORATIVO") & DAO.ParametroAdministradoObtener("PRM", "WSCATALOGOS") 'DAO.ParametroAdministradoObtener("WS", "SERVIDOR_WS_EMPRESA_" & atrMiEmpresa) & DAO.ParametroAdministradoObtener("WS", "WS_SincronizacionCatalogos")
        ' ''        PlMensajeEstatusOcultar()

        ' ''        PlMensajeEstatusMostrar("Obteniendo catálogos a actualizar")
        ' ''        vArregloByte = wsSincronizaCatalogos.RegresaInformacionCatalogos_A_Actualizar_Bytes(atrContextosActualizar)
        ' ''        PlMensajeEstatusOcultar()

        ' ''        Dim vcRutaArchivosTemporales As String = ""
        ' ''        Dim vDsTablasActualizar As New DataSet

        ' ''        If vArregloByte.Length = 0 Then
        ' ''            PlMensajeMostrar("No hay información de catálogos para actualizar", Windows.Forms.MessageBoxIcon.Information)
        ' ''            Return True
        ' ''        End If


        ' ''        DAO.ParametroAdministradoAgregar("PRMSUC", "RUTA_ARCHIVOSTEMPORALES", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Ruta Temporal", "c:\Adsum")
        ' ''        vcRutaArchivosTemporales = DAO.ParametroAdministradoObtener("PRMSUC", "RUTA_ARCHIVOSTEMPORALES")

        ' ''        PlMensajeEstatusMostrar("Generando archivo para actualizar")
        ' ''        vDsTablasActualizar = FlGeneraArchivo(vcRutaArchivosTemporales, "dsCatalogos", vArregloByte)
        ' ''        PlMensajeEstatusOcultar()

        ' ''        If vDsTablasActualizar Is Nothing Then Return False

        ' ''        If Not FlActualizaCatalogos(vDsTablasActualizar) Then
        ' ''            Return False
        ' ''        End If

        ' ''        PlMensajeMostrar("Catálogos Actualizados correctamente", MessageBoxIcon.Information)
        ' ''        Return True
        ' ''    Catch ex As Exception
        ' ''        PlMensajeMostrar(ex.Message.ToString, MessageBoxIcon.Error)
        ' ''        PlMensajeEstatusOcultar()
        ' ''        If Not Log Is Nothing Then
        ' ''            Log.WriteEntry("Error ClsActualizaCatalogos : " & DAO.RegresaFechaDelSistema & " " & ex.Source & " " & ex.Message.ToString, EventLogEntryType.Error)
        ' ''        End If
        ' ''        Return False
        ' ''    End Try
        ' ''End Function
        Private Function FlActualizaCatalogos(ByRef prmDsCatalogos As DataSet) As Boolean
            Try
                If prmDsCatalogos Is Nothing OrElse prmDsCatalogos.Tables.Count = 0 Then Return False
                If prmDsCatalogos.Tables("TablaControl") Is Nothing Then Return False

                If Not DAO.TieneTransaccionAbierta Then
                    DAO.AbreTransaccion()
                End If

                Dim vcNombreCatalogo As String = ""
                Dim vcFiltro As String = ""
                For Each dr As DataRow In prmDsCatalogos.Tables("TablaControl").Select("", "nOrden")
                    vcNombreCatalogo = dr("cNombreTabla")

                    If prmDsCatalogos.Tables(vcNombreCatalogo) Is Nothing OrElse prmDsCatalogos.Tables(vcNombreCatalogo).Rows.Count = 0 Then
                        Continue For
                    End If

                    PlMensajeEstatusMostrar("Actualizando " & vcNombreCatalogo)

                    Comunes.Comun.WS.ClsConciliadorWS.RegresaPrimaryKeys(prmDsCatalogos.Tables(vcNombreCatalogo))
                    vcFiltro = Comunes.Comun.ClsContenedor.CreaFiltroWS(prmDsCatalogos.Tables(vcNombreCatalogo))
                    If Not vcFiltro = "" Then vcFiltro = " Where " & vcFiltro

                    If Not Comunes.Comun.WS.ClsConciliadorWS.InsertaYActualizaTablaDeBD(prmDsCatalogos.Tables(vcNombreCatalogo), "") Then
                        If DAO.TieneTransaccionAbierta Then
                            DAO.DeshaceTransaccion()
                        End If
                        PlMensajeEstatusOcultar()
                        PlMensajeMostrar("Error al actualizar la tabla " & vcNombreCatalogo, Windows.Forms.MessageBoxIcon.Exclamation)
                        Return False
                    End If
                    PlMensajeEstatusOcultar()
                Next

                If DAO.TieneTransaccionAbierta Then
                    DAO.CierraTransaccion()
                End If

                Return True
            Catch ex As Exception
                If DAO.TieneTransaccionAbierta Then DAO.DeshaceTransaccion()
                PlMensajeMostrar(ex.Message.ToString, MessageBoxIcon.Error)
                PlMensajeEstatusOcultar()
                If Not Log Is Nothing Then
                    Log.WriteEntry("Error ClsActualizaCatalogos : " & DAO.RegresaFechaDelSistema & " " & ex.Source & " " & ex.Message.ToString, EventLogEntryType.Error)
                End If
                Return False
            End Try

        End Function
        Private Function FlGeneraArchivo(ByVal prmRuta As String, ByVal prmNombre As String, ByRef prmArchivoBytes As Byte()) As DataSet
            'se deserealiza el archivo de byte y los convertimos en un dataset ... 2 lineas

            Dim vFsrWriter As System.IO.FileStream
            Dim miInfo As System.IO.DirectoryInfo

            Dim miZip As ZipUtil
            Dim misEntries() As ICSharpCode.SharpZipLib.Zip.ZipEntry

            Dim vDsActualizaciones As DataSet

            Dim vcNombreArchivoRuta As String
            Dim vcNombreCarpetaTemporal As String

            Try
                vcNombreArchivoRuta = prmRuta & prmNombre & New Random().Next(1000000).ToString & ".zip"
                vcNombreCarpetaTemporal = "c:\adsum\DescompresionCatalogos" & New Random().Next(1000000).ToString

                vFsrWriter = New System.IO.FileStream(vcNombreArchivoRuta, System.IO.FileMode.Create)
                vFsrWriter.Write(prmArchivoBytes, 0, prmArchivoBytes.Length)
                vFsrWriter.Close()

                miInfo = System.IO.Directory.CreateDirectory(vcNombreCarpetaTemporal)

                If miInfo.Exists Then
                    miZip = New ZipUtil

                    misEntries = miZip.Contenido(vcNombreArchivoRuta)
                    miZip.Descomprimir(vcNombreCarpetaTemporal, vcNombreArchivoRuta, True, False)

                    vDsActualizaciones = New DataSet

                    'Recorremos para cargar los esquemas
                    For Each miEntry As ICSharpCode.SharpZipLib.Zip.ZipEntry In misEntries
                        If miEntry.Name.IndexOf("Schema") >= 0 Then
                            vDsActualizaciones.ReadXmlSchema(vcNombreCarpetaTemporal & "\" & System.IO.Path.GetFileName(miEntry.Name))
                        End If
                    Next

                    'Recorremos para llenar los datos
                    For Each miEntry As ICSharpCode.SharpZipLib.Zip.ZipEntry In misEntries
                        If miEntry.Name.IndexOf("Schema") < 0 Then
                            vDsActualizaciones.ReadXml(vcNombreCarpetaTemporal & "\" & System.IO.Path.GetFileName(miEntry.Name), XmlReadMode.IgnoreSchema)
                        End If
                    Next

                    System.IO.Directory.Delete(miInfo.FullName, True)
                End If

                FlGeneraArchivo = vDsActualizaciones

            Catch ex As Exception
                PlMensajeMostrar(ex.Message.ToString, MessageBoxIcon.Error)
                PlMensajeEstatusOcultar()
                If Not Log Is Nothing Then
                    Log.WriteEntry("Error ClsActualizaCatalogos : " & DAO.RegresaFechaDelSistema & " " & ex.Source & " " & ex.Message.ToString, EventLogEntryType.Error)
                End If
                FlGeneraArchivo = Nothing
            End Try
        End Function
#End Region
#Region "Procedimientos"
#Region "Muestra Mensajes"
        Private Sub PlMensajeEstatusMostrar(ByVal prmMensaje As String)
            If Not atrMuestraMensajes Then Exit Sub
            If gFrmWait Is Nothing Then gFrmWait = New frmStatus
            gFrmWait.Show(prmMensaje.Trim)
        End Sub
        Private Sub PlMensajeEstatusOcultar()
            If Not atrMuestraMensajes Then Exit Sub
            If gFrmWait Is Nothing Then gFrmWait = New frmStatus
            gFrmWait.Visible = False
        End Sub
        Private Sub PlMensajeMostrar(ByVal prmMensaje As String, ByVal prmIcono As System.Windows.Forms.MessageBoxIcon)
            If Not atrMuestraMensajes Then Exit Sub
            If Not atrMuestraMensajeConfirmacion Then Exit Sub
            MessageBox.Show(prmMensaje.Trim, Comun.ClsTools.GlobalSistemaCaption, MessageBoxButtons.OK, prmIcono)
        End Sub
#End Region
#End Region
#End Region

    End Class

End Namespace