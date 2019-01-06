Imports Access.Comunes.Comun
Imports System.Windows.Forms
Imports System.IO
Imports System.Web.HttpServerUtility
Imports System.Web
Imports Access
Imports ADSUM

Namespace Comunes.Comun.WS.Sucursal
    Public Class ClsObtenInformacionParaSucursal

        Private atrAlmacenSucursal As Int32
        Private atrContextoInformacion As String
        Private atrMuestraMensajes As Boolean
        Private gFrmWait As frmStatus

        Public Sub New(ByVal prmAlmacenSucursal As Int32, ByVal prmContextoInformacion As String, ByVal prmMuestraMensajes As Boolean)
            atrAlmacenSucursal = prmAlmacenSucursal
            atrContextoInformacion = prmContextoInformacion
            atrMuestraMensajes = prmMuestraMensajes
        End Sub

        'Constructor para procesar archivos
        Public Sub New(ByVal prmMuestraMensajes As Boolean)
            atrMuestraMensajes = prmMuestraMensajes
        End Sub

        Public Function RegresaArchivoZIP(ByRef prmProcesoCorrecto As Boolean) As Byte()
            Dim con As New Comunes.Comun.WS.ClsConciliadorWS(atrContextoInformacion, 0, atrMuestraMensajes)
            con.Almacen_de_Sucursal = atrAlmacenSucursal
            Return con.ObtenInformacion_para_Sucursal(prmProcesoCorrecto)
        End Function
        Public Function GeneraArchivoZIP(ByVal prmRuta As String, ByRef prmProcesoCorrecto As Boolean) As Boolean
            Dim con As New Comunes.Comun.WS.ClsConciliadorWS(atrContextoInformacion, 0, atrMuestraMensajes)
            con.Almacen_de_Sucursal = atrAlmacenSucursal
            con.RutaGenerarArchivoManual = prmRuta
            con.ObtenInformacion_para_Sucursal(prmProcesoCorrecto)
            Return prmProcesoCorrecto
        End Function


        Public Function ProcesaArchivo(ByRef prmArchivoProcesarZIP As Byte()) As Boolean
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia

            'Antes de procesar archivos, actualizamos los catálogos configurados, para tener la certeza de que tenemos todo lo necesario para procesar el archivo
            'Dim vObjWSActualizaCatalogos As New WS.ClsActualizaCatalogos(atrMuestraMensajes)
            'vObjWSActualizaCatalogos.Log = Nothing
            'vObjWSActualizaCatalogos.ContextosActualizar = "PTL"
            'vObjWSActualizaCatalogos.MuestraMensajeConfirmacionUsuario = False
            'If vObjWSActualizaCatalogos.ValidaPlazaActualizaCatalogos Then
            '    vObjWSActualizaCatalogos.ActualizaCatalogos()
            'End If

            If prmArchivoProcesarZIP Is Nothing Then
                PlMensajeMostrar("Archivo inexistente para procesar", MessageBoxIcon.Information)
                Return False
            End If

            If Not GrabaDatosArchivo(prmArchivoProcesarZIP) Then
                Return False
            End If

            Return True
        End Function
        Private Function GrabaDatosArchivo(ByVal prmArchivo As Byte()) As Boolean
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia

            If prmArchivo Is Nothing Then
                PlMensajeMostrar("Archivo inexistente para procesar", MessageBoxIcon.Exclamation)
                Return False
            End If

            Dim vcRutaEnviar As String = DAO.ParametroAdministradoObtener("WS", "NOMBRE_RUTA_ARCHIVOSENVIAR_WEBSERVICE") '& (New Random().Next(100000000)).ToString()

            'Creamos el directorio por si no existe
            '2.- Creamos el directorio donde se almacenarán los archivos XML
            If IO.Directory.Exists(vcRutaEnviar) Then
                IO.Directory.Delete(vcRutaEnviar, True)
            End If
            Dim miInfoEnviar As System.IO.DirectoryInfo
            miInfoEnviar = System.IO.Directory.CreateDirectory(vcRutaEnviar)

            If Not miInfoEnviar.Exists() Then miInfoEnviar.Create()
            If Not miInfoEnviar.Exists Then Return Nothing
            '
            Dim ruta As String = vcRutaEnviar
            Dim archivo As New FileStream(ruta & "\recibido.zip", FileMode.Create)
            archivo.Write(prmArchivo, 0, prmArchivo.Length)
            archivo.Close()
            Dim miInfo As DirectoryInfo = Directory.CreateDirectory(ruta & "\recibidotemp")

            If Not miInfo.Exists Then
                PlMensajeMostrar("No se encuentra el directorio de trabajo", MessageBoxIcon.Exclamation)
                Return False
            End If

            PlMensajeEstatusMostrar("Descomprimiendo información")
            If miInfo.Exists Then
                Dim miZip As ZipUtil = New ZipUtil
                'Dim misEntries() As ICSharpCode.SharpZipLib.Zip.ZipEntry = miZip.Contenido(ruta & "\recibido.zip")
                miZip.Descomprimir(ruta & "\recibidotemp", ruta & "\recibido.zip", True, False)
            End If
            PlMensajeEstatusOcultar()


            If Not DAO.TieneTransaccionAbierta Then
                DAO.AbreTransaccion()
            End If

            Dim vcNombreTabla As String = ""

            Try
                Dim vDsDatosXML As New DataSet
                Dim vDsDatos As DataSet
                Dim vDt_InformacionWeb As New DataTable
                Dim vcFiltro As String = ""
                Dim vcRuta As String = ""

                vcRuta = ruta & "\recibidotemp\" & DAO.ParametroAdministradoObtener("WS", "NOMBRE_TABLACONTROL_XML_WEBSERVICE") & ".XML"

                PlMensajeEstatusMostrar("Obteniendo tabla control")
                vDsDatosXML.ReadXml(vcRuta)
                PlMensajeEstatusOcultar()

                For Each vDrowTrabajo As DataRow In vDsDatosXML.Tables(0).Select("", "nOrden Asc")
                    vcRuta = ruta & "\recibidotemp\" & vDrowTrabajo("cXml")
                    If vDsDatos Is Nothing Then vDsDatos = New DataSet

                    PlMensajeEstatusMostrar("Obteniendo información a procesar")
                    vDsDatos.ReadXml(vcRuta)
                    PlMensajeEstatusOcultar()

                    vDt_InformacionWeb.Clear()
                    Comunes.Comun.ClsTools.copiaRows(vDsDatos.Tables("miDtControl").Select(""), vDt_InformacionWeb, vDsDatos.Tables("miDtControl").Columns)

                    For Each miRow As DataRow In vDt_InformacionWeb.Rows
                        vcNombreTabla = miRow("cNombreTabla").ToString()

                        If vDsDatos.Tables(vcNombreTabla) Is Nothing Then Continue For
                        If vDsDatos.Tables(vcNombreTabla).Rows.Count = 0 Then Continue For

                        PlMensajeEstatusMostrar("Procesando tabla: " & vcNombreTabla)
                        DAO.EjecutaComandoSQL("EXEC UTL_HabilitaDeshabilitaTodoslosTriggerstabla '" & vcNombreTabla & "',-1")

                        If Comunes.Comun.ClsTools.IfNull(miRow("bEliminarDatos"), False) Then
                            If Not DAO.EjecutaComandoSQL(miRow("cSQLDelete")) Then
                                If DAO.TieneTransaccionAbierta Then DAO.DeshaceTransaccion()
                                ManejaError(vDsDatos, vcRutaEnviar, vcNombreTabla)
                                Return False
                            End If
                        End If

                        Comunes.Comun.WS.ClsConciliadorWS.RegresaPrimaryKeys(vDsDatos.Tables(vcNombreTabla))

                        vcFiltro = Comunes.Comun.ClsContenedor.CreaFiltroWS(vDsDatos.Tables(vcNombreTabla))
                        If Not vcFiltro = "" Then vcFiltro = " Where " & vcFiltro

                        If Not ClsConciliadorWS.InsertaYActualizaTablaDeBD(vDsDatos.Tables(vcNombreTabla), vcFiltro) Then
                            If DAO.TieneTransaccionAbierta Then DAO.DeshaceTransaccion()
                            ManejaError(vDsDatos, vcRutaEnviar, vcNombreTabla)
                            Return False
                        End If

                        DAO.EjecutaComandoSQL("EXEC UTL_HabilitaDeshabilitaTodoslosTriggerstabla '" & vcNombreTabla & "',1")
                    Next
                Next

                System.IO.Directory.Delete(vcRutaEnviar, True)
                PlMensajeEstatusOcultar()
            Catch ex As Exception
                If DAO.TieneTransaccionAbierta Then DAO.DeshaceTransaccion()
                PlMensajeMostrar(ex.Message.ToString, MessageBoxIcon.Error)
                ManejaError(Nothing, vcRutaEnviar, vcNombreTabla)
                Return False
            End Try


            If DAO.TieneTransaccionAbierta Then DAO.CierraTransaccion()

            Return True

        End Function
        Private Sub ManejaError(ByRef prmDsDatos As DataSet, ByVal prmRutaEnviar As String, ByVal prmNombreTabla As String)
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            If DAO.TieneTransaccionAbierta Then DAO.DeshaceTransaccion()
            DAO.EjecutaComandoSQL("EXEC UTL_HabilitaDeshabilitaTodoslosTriggerstabla '" & prmNombreTabla & "',1")
            If Not prmDsDatos Is Nothing Then
                prmDsDatos.Dispose()
                prmDsDatos = Nothing
            End If
            GC.Collect()
            GC.GetTotalMemory(False)
            GC.WaitForPendingFinalizers()
            System.IO.Directory.Delete(prmRutaEnviar, True)
            PlMensajeEstatusOcultar()
        End Sub
#Region "Mensajes"
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
            MessageBox.Show(prmMensaje.Trim, Comun.ClsTools.GlobalSistemaCaption, MessageBoxButtons.OK, prmIcono)
        End Sub
#End Region
    End Class

End Namespace