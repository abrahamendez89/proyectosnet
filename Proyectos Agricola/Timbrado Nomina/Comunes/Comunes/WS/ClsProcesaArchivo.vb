Imports Access.Comunes.Comun
Imports System.Windows.Forms
Imports System.IO
Imports Access
Namespace Comunes.Comun.WS
    Public Class ClsProcesaArchivo

#Region "Declaraciones"
        Public Shared DAO As DataAccessCls
        Private Shared atrMuestraMensajes As Boolean
        Private Shared gFrmWait As frmStatus
#End Region

#Region "Constructores"
        Public Sub New(ByVal prmEsWebService As Boolean)
            If prmEsWebService Then
                DAO = DataAccessCls.DevuelveInstancia("ADSUMADK")
            Else
                DAO = DataAccessCls.DevuelveInstancia
            End If
            'DAO.ParametroAdministradoAgregar("WS", "NOMBRE_COMPLEMENTO_TABLAS_ENVIO_WEBSERVICE", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parámetro para saber lo que se le tiene que concatenar al nombre de la tabla, ejemplo: INV_Pedidos, quedaría INV_Pedidos_Conciliacion", "_CONCILIACION")
            'DAO.ParametroAdministradoAgregar("WS", "NOMBRE_CAMPO_ORIGEN_TABLAS_ENVIO_WEBSERVICE", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parámetro para saber como se llama el campo al que se envió la información, ejemplo: nPlazaEnviada ... se usa en el conciliador", "nPlazaEnviada")
            'atrcPlazaEnvia = DAO.ParametroAdministradoObtener("WS", "NOMBRE_CAMPO_ORIGEN_TABLAS_ENVIO_WEBSERVICE")
            'atrnPlazaEnvia = 2
        End Sub
#End Region

#Region "Funciones y Procedimientos"

        Private Shared Sub PlMensajeEstatusMostrar(ByVal prmMensaje As String)
            If Not atrMuestraMensajes Then Exit Sub
            If gFrmWait Is Nothing Then gFrmWait = New frmStatus
            gFrmWait.Show(prmMensaje.Trim)
        End Sub
        Private Shared Sub PlMensajeEstatusOcultar()
            If Not atrMuestraMensajes Then Exit Sub
            If gFrmWait Is Nothing Then gFrmWait = New frmStatus
            gFrmWait.Visible = False
        End Sub
        Private Shared Sub PlMensajeMostrar(ByVal prmMensaje As String, ByVal prmIcono As System.Windows.Forms.MessageBoxIcon)
            If Not atrMuestraMensajes Then Exit Sub
            MessageBox.Show(prmMensaje.Trim, Comun.ClsTools.GlobalSistemaCaption, MessageBoxButtons.OK, prmIcono)
        End Sub


        Public Shared Sub ProcesaArchivos(Optional ByVal prmMuestraMensajes As Boolean = False, Optional ByRef prmLog As EventLog = Nothing, Optional ByRef prmDevuelveMensaje As String = "", Optional ByVal prmEjecutaPorWebService As Boolean = False)
            'Antes de procesar archivos, actualizamos los catálogos configurados, para tener la certeza de que tenemos todo lo necesario para procesar el archivo
            Try
                Dim vObjWSActualizaCatalogos As New WS.ClsActualizaCatalogos(prmMuestraMensajes)
                vObjWSActualizaCatalogos.Log = prmLog
                vObjWSActualizaCatalogos.MuestraMensajeConfirmacionUsuario = False
                If vObjWSActualizaCatalogos.ValidaPlazaActualizaCatalogos Then
                    ' ''vObjWSActualizaCatalogos.ActualizaCatalogos()
                End If
            Catch ex As Exception

            End Try


            Dim DAO As DataAccessCls

            Dim vcSQL As String
            Dim vDt_ArchivosProcesar As New DataTable
            '            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            If prmEjecutaPorWebService Then
                DAO = DataAccessCls.DevuelveInstancia("ADSUMADK")
            Else
                DAO = DataAccessCls.DevuelveInstancia
            End If

            atrMuestraMensajes = prmMuestraMensajes

            vcSQL = "Select cNombreArchivo From CTL_AdministracionArchivosWS(NoLock) Where bProcesado = 0 Order By nOrden Asc"

            PlMensajeEstatusMostrar("Obteniendo Archivos a Procesar")

            DAO.RegresaConsultaSQL(vcSQL, vDt_ArchivosProcesar)

            PlMensajeEstatusOcultar()

            If Not vDt_ArchivosProcesar Is Nothing Then
                If vDt_ArchivosProcesar.Rows.Count > 0 Then
                    For Each Dr As DataRow In vDt_ArchivosProcesar.Rows
                        Try
                            If Not GrabaDatosProcesaArchivos(Dr("cNombreArchivo"), prmLog, prmDevuelveMensaje, prmEjecutaPorWebService) Then
                                Continue For
                            End If
                        Catch ex As Exception
                            If DAO.TieneTransaccionAbierta Then DAO.DeshaceTransaccion()
                            PlMensajeMostrar(ex.Message.ToString, MessageBoxIcon.Error)
                            PlMensajeEstatusOcultar()
                            If Not prmLog Is Nothing Then
                                ClsTools.GrabaMensajeLog(prmLog, "Error ClsProcesaArchivo : " & ClsTools.IfNull(Dr("cNombreArchivo"), "") & " " & DAO.RegresaFechaDelSistema & " " & ex.Source & " " & ex.Message.ToString, EventLogEntryType.Error)
                                prmDevuelveMensaje &= ex.Message.ToString
                            End If
                        End Try
                    Next
                    PlMensajeMostrar("Fin del Proceso", MessageBoxIcon.Information)

                    prmDevuelveMensaje &= "Fin del Proceso"

                    Return
                End If
                PlMensajeMostrar("No hay archivos pendientes de procesar", MessageBoxIcon.Information)
                prmDevuelveMensaje = "No hay archivos pendientes de procesar"
                Return
            End If
            Return
        End Sub

        Public Shared Sub ProcesaArchivos(ByVal vcPath As String, Optional ByVal prmMuestraMensajes As Boolean = False)
            Dim vcSQL As String
            Dim vDt_ArchivosProcesar As New DataTable
            Dim vcBuzonEnvio As String = DAO.ParametroAdministradoObtener("WS", "ENV_Directorio_Buzon_Envio")
            '            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia

            DAO = DataAccessCls.DevuelveInstancia
            atrMuestraMensajes = prmMuestraMensajes

            For Each Archivo As String In My.Computer.FileSystem.GetFiles( _
                                            vcPath, _
                                            FileIO.SearchOption.SearchTopLevelOnly, _
                                            "*.zip")


                Dim vnSucursal As Integer = 0
                Dim vcArreglo As String()
                Dim vcArchivo As String = ""

                vcArreglo = Archivo.Split("_")
                vnSucursal = vcArreglo(4)
                vcArchivo = IO.Path.GetFileName(Archivo)

                If flInsertaArchivosManuales(vcArchivo, vnSucursal) Then
                    If Not IO.Directory.Exists(vcBuzonEnvio) Then
                        IO.Directory.CreateDirectory(vcBuzonEnvio)
                    End If
                    IO.File.Copy(Archivo, vcBuzonEnvio & IO.Path.GetFileName(Archivo), True)
                End If
            Next

            vcSQL = "Select cNombreArchivo From CTL_AdministracionArchivosWS(NoLock) Where bProcesado = 0 And bGeneradoSinLinea = 1 Order By nOrden Asc"

            PlMensajeEstatusMostrar("Obteniendo Archivos a Procesar")

            DAO.RegresaConsultaSQL(vcSQL, vDt_ArchivosProcesar)

            PlMensajeEstatusOcultar()

            If Not vDt_ArchivosProcesar Is Nothing Then
                If vDt_ArchivosProcesar.Rows.Count > 0 Then
                    For Each Dr As DataRow In vDt_ArchivosProcesar.Rows
                        Try
                            If Not GrabaDatosProcesaArchivos(Dr("cNombreArchivo")) Then
                                Continue For
                            End If
                        Catch ex As Exception
                            If DAO.TieneTransaccionAbierta Then DAO.DeshaceTransaccion()
                            PlMensajeMostrar(ex.Message.ToString, MessageBoxIcon.Error)
                            PlMensajeEstatusOcultar()

                        End Try
                    Next
                    PlMensajeMostrar("Fin del Proceso", MessageBoxIcon.Information)
                End If
            End If
        End Sub

        Private Shared Function GrabaDatosProcesaArchivos(ByVal prmNombreArchivo As String, Optional ByRef prmLog As EventLog = Nothing, Optional ByRef prmDevuelveMensaje As String = "", Optional ByVal prmEjecutaPorWebService As Boolean = False) As Boolean
            Try
                Dim DAO As DataAccessCls

                If prmEjecutaPorWebService Then
                    DAO = DataAccessCls.DevuelveInstancia("ADSUMADK")
                Else
                    DAO = DataAccessCls.DevuelveInstancia
                End If

                Dim vcActualizaFechaExistencias As String = "0"
                'Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia()

                'DAO.ParametroAdministradoAgregar("WS", "TABLAS_NO_DESACTIVAR_TRIGGERS_EN_INTEGRACION", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parámetro para saber que tablas no desactivarán sus triggers en la integración de info.", "PRO_EXISTENCIAS")
                'Dim vcTablasNoDesactivarTriggers As String = DAO.ParametroAdministradoObtener("WS", "TABLAS_NO_DESACTIVAR_TRIGGERS_EN_INTEGRACION")

                Dim vObjMiCript As New Adsum.Criptografo.Rijndael
                Dim vcNombreArchivoTemp As String = prmNombreArchivo
                Dim vcNombreArchivoConRutaZip As String
                Dim vcNombreArchivoConRutaTemporal As String
                Dim vcDirectorioTrabajo As String
                Dim vcRutaArchivosDescomprimidos As String
                Dim vcBuzonEnvio As String = DAO.ParametroAdministradoObtener("WS", "ENV_Directorio_Buzon_Envio")
                Dim vcMensajeError As String = ""
                Dim vDsDatos As New DataSet
                Dim vcFiltro As String = ""
                Dim vcRuta As String = ""
                Dim vdFechaInicio As DateTime
                Dim vbTodoCorrecto As Boolean = True

                Dim vDt_InformacionWeb As New DataTable
                Dim vObjZip As New Adsum.ZipUtil
                Dim vDsDatosXml As New DataSet



                ''Nombres de archivo de trabajo
                vcNombreArchivoConRutaZip = vcBuzonEnvio & prmNombreArchivo
                vcNombreArchivoConRutaTemporal = vcBuzonEnvio & vcNombreArchivoTemp
                vcDirectorioTrabajo = vcBuzonEnvio & "Temp"
                vcRutaArchivosDescomprimidos = vcDirectorioTrabajo & "\{0}"




                DAO.EnviarMensajesAPantalla = False
                DAO.TiempoDeEspera_Segundos = 3000

                ''Desencriptamos el archivo
                vdFechaInicio = DAO.RegresaFechaDelSistema

                ''Descomprimimos el archivo
                Try
                    vdFechaInicio = DAO.RegresaFechaDelSistema
                    PlMensajeEstatusMostrar("Descomprimiendo Archivo")
                    If Not IO.Directory.Exists(vcDirectorioTrabajo) Then
                        IO.Directory.CreateDirectory(vcDirectorioTrabajo)
                    End If
                    vObjZip.Descomprimir(vcDirectorioTrabajo, vcNombreArchivoConRutaTemporal, True, False)
                Catch ex As Exception
                    If DAO.TieneTransaccionAbierta Then DAO.DeshaceTransaccion()
                    Try
                        If Not prmLog Is Nothing Then
                            ClsTools.GrabaMensajeLog(prmLog, "Error ClsProcesaArchivo : " & DAO.RegresaFechaDelSistema & " " & ex.Source & " " & ex.Message.ToString, EventLogEntryType.Error)
                        End If
                        DAO.EjecutaComandoSQL(String.Format("UPDATE CTL_AdministracionArchivosWS SET bProcesado=1,bError = 1,bActFechaExistencia = " & vcActualizaFechaExistencias & " WHERE cNombreArchivo IN ('{0}')", prmNombreArchivo))
                        PlMensajeEstatusOcultar()
                        PlMensajeMostrar("Error al procesar el Archivo " & prmNombreArchivo, MessageBoxIcon.Error)
                        prmDevuelveMensaje &= "Error al procesar el Archivo " & prmNombreArchivo & vbCr
                        PlMensajeEstatusOcultar()
                        System.IO.Directory.Delete(vcDirectorioTrabajo, True)
                        vDsDatos.Dispose()
                        vDsDatos = Nothing
                        GC.Collect()
                        GC.GetTotalMemory(False)
                        GC.WaitForPendingFinalizers()
                    Catch
                    End Try
                    'GuardaBitacora(vdFechaInicio, DAO.RegresaFechaDelSistema, 0, "Descomprimiendo archivo ", ex.ToString, 0)

                    Return False
                End Try
                PlMensajeEstatusOcultar()


                ''Tomamos el tiempo de inicio de cargado de dataset, para su medicion y posible mejora
                Dim vdInicioCargadoDataSet As DateTime = DAO.RegresaFechaDelSistema

                vcRuta = String.Format(vcRutaArchivosDescomprimidos, DAO.ParametroAdministradoObtener("WS", "NOMBRE_TABLACONTROL_XML_WEBSERVICE") & ".XML")
                vDsDatosXml.ReadXml(vcRuta)

                For Each vDrowTrabajo As DataRow In vDsDatosXml.Tables(0).Select("", "nOrden Asc")
                    vbTodoCorrecto = True
                    vcRuta = String.Format(vcRutaArchivosDescomprimidos, vDrowTrabajo("cXml"))
                    Try
                        vdFechaInicio = DAO.RegresaFechaDelSistema
                        vcMensajeError = ""

                        If vDsDatos Is Nothing Then vDsDatos = New DataSet
                        PlMensajeEstatusMostrar("Creando Dataset Principal")
                        vDsDatos.ReadXml(vcRuta)
                        PlMensajeEstatusOcultar()
                        ''Se deshabilita el ajuste de zona horaria
                        ''porque aun está en fase de pruebas por ADSUM
                        ''L.I. Aldo Manuel Sánz Castro 06/03/2009
                        'vDsDatos = ClsTools.AjustarDSZonaHoraria(vDsDatos)

                        PlMensajeEstatusMostrar("Abriendo Transaccion")

                        If Not DAO.AbreTransaccion Then
                            If DAO.TieneTransaccionAbierta Then DAO.DeshaceTransaccion()
                            Try
                                If Not prmLog Is Nothing Then
                                    ClsTools.GrabaMensajeLog(prmLog, "Error ClsProcesaArchivo : " & DAO.RegresaFechaDelSistema & " Error al abrir transaccion en el Archivo " & prmNombreArchivo, EventLogEntryType.Error)
                                End If

                                DAO.EjecutaComandoSQL(String.Format("UPDATE CTL_AdministracionArchivosWS SET bProcesado=1,bError = 1,bActFechaExistencia = " & vcActualizaFechaExistencias & "  WHERE cNombreArchivo IN ('{0}')", prmNombreArchivo))
                                PlMensajeEstatusOcultar()
                                PlMensajeMostrar("Error al abrir transaccion en el Archivo " & prmNombreArchivo, MessageBoxIcon.Error)
                                prmDevuelveMensaje &= "Error al abrir transaccion en el Archivo " & prmNombreArchivo & vbCr
                                PlMensajeEstatusOcultar()
                                System.IO.Directory.Delete(vcDirectorioTrabajo, True)
                                vDsDatos.Dispose()
                                vDsDatos = Nothing
                                GC.Collect()
                                GC.GetTotalMemory(False)
                                GC.WaitForPendingFinalizers()
                            Catch
                            End Try
                            vdFechaInicio = DAO.RegresaFechaDelSistema
                            'GuardaBitacora(vdFechaInicio, vdFechaInicio, 0, "Abriendo Transaccion", DAO.UltimoMensajeEnviado, 0)
                            Return False
                        End If
                        PlMensajeEstatusOcultar()

                        If vDsDatos.Tables.Count.Equals(0) Then
                            ''En caso de que el archivo no contenga tablas
                            If DAO.TieneTransaccionAbierta Then DAO.DeshaceTransaccion()
                            Try
                                If Not prmLog Is Nothing Then
                                    ClsTools.GrabaMensajeLog(prmLog, "Error ClsProcesaArchivo : " & DAO.RegresaFechaDelSistema & " El archivo no cuenta con ninguna tabla " & prmNombreArchivo, EventLogEntryType.Error)
                                End If
                                DAO.EjecutaComandoSQL(String.Format("UPDATE CTL_AdministracionArchivosWS SET bProcesado=1,bError = 1,bActFechaExistencia = " & vcActualizaFechaExistencias & "  WHERE cNombreArchivo IN ('{0}')", prmNombreArchivo))
                                PlMensajeEstatusOcultar()
                                PlMensajeMostrar("El Archivo no cuenta con ninguna tabla", MessageBoxIcon.Error)
                                prmDevuelveMensaje &= "El Archivo " & prmNombreArchivo & " no cuenta con ninguna tabla " & vbCr
                                PlMensajeEstatusOcultar()
                                System.IO.Directory.Delete(vcDirectorioTrabajo, True)
                                vDsDatos.Dispose()
                                vDsDatos = Nothing
                                GC.Collect()
                                GC.GetTotalMemory(False)
                                GC.WaitForPendingFinalizers()
                            Catch
                            End Try
                            vdFechaInicio = DAO.RegresaFechaDelSistema
                            'GuardaBitacora(vdFechaInicio, vdFechaInicio, 0, "Inicio Guardado", "El Archivo no contiene ninguna tabla", 0)
                            Return False
                        End If

                        ''Empezamos a insertar los datos en base al orden dado por la tabla vDt_InformacionWeb
                        vdInicioCargadoDataSet = DAO.RegresaFechaDelSistema
                        vDt_InformacionWeb.Clear()
                        Comunes.Comun.ClsTools.copiaRows(vDsDatos.Tables("miDtControl").Select(""), vDt_InformacionWeb, vDsDatos.Tables("miDtControl").Columns)

                        For Each miRow As DataRow In vDt_InformacionWeb.Rows
                            Dim vcNombreTabla As String = miRow("cNombreTabla").ToString()

                            If ExisteTablaEnDataSet(vDsDatos, vcNombreTabla) Then
                                PlMensajeEstatusOcultar()
                                PlMensajeEstatusMostrar("Procesando Tabla " & vcNombreTabla)
                                'DAO.RegresaEsquemaDeDatos("Select * From " & vcNombreTabla & "(NoLock) Where 1 = 0", vDt_Insertar)
                                'Comunes.Comun.ClsTools.copiaRows(vDsDatos.Tables(vcNombreTabla).Select(""), vDt_Insertar, vDsDatos.Tables(vcNombreTabla).Columns)
                                'vDt_Insertar.TableName = vcNombreTabla
                                If vcNombreTabla.Trim.ToUpper = "PRO_EXISTENCIAS".Trim.ToUpper Then
                                    vcActualizaFechaExistencias = "1"
                                End If

                                If Not DAO.EjecutaComandoSQL("EXEC UTL_HabilitaDeshabilitaTodoslosTriggerstabla '" & vcNombreTabla & "',-1") Then
                                    If DAO.TieneTransaccionAbierta Then DAO.DeshaceTransaccion()
                                    Try
                                        If Not prmLog Is Nothing Then
                                            ClsTools.GrabaMensajeLog(prmLog, "Error ClsProcesaArchivo : " & DAO.RegresaFechaDelSistema & " Error al deshabilitar los triggers ", EventLogEntryType.Error)
                                        End If
                                        DAO.EjecutaComandoSQL(String.Format("UPDATE CTL_AdministracionArchivosWS SET bProcesado=1,bError = 1,bActFechaExistencia = " & vcActualizaFechaExistencias & "  WHERE cNombreArchivo IN ('{0}')", prmNombreArchivo))
                                        PlMensajeEstatusOcultar()
                                        PlMensajeMostrar("Error al deshabilitar los triggers ", MessageBoxIcon.Error)
                                        prmDevuelveMensaje &= "Error al deshabilitar los triggers de la tabla " & vcNombreTabla & vbCr
                                        PlMensajeEstatusOcultar()
                                        System.IO.Directory.Delete(vcDirectorioTrabajo, True)
                                        vDsDatos.Dispose()
                                        vDsDatos = Nothing
                                        GC.Collect()
                                        GC.GetTotalMemory(False)
                                        GC.WaitForPendingFinalizers()
                                    Catch
                                    End Try
                                    vdFechaInicio = DAO.RegresaFechaDelSistema
                                    'GuardaBitacora(vdFechaInicio, vdFechaInicio, 0, "Deshabilitando Triggers", DAO.UltimoMensajeEnviado, 0)
                                    vbTodoCorrecto = False
                                    Exit For
                                End If

                                If Not vDsDatos.Tables(vcNombreTabla) Is Nothing Then
                                    If Not vDsDatos.Tables(vcNombreTabla).Rows.Count = 0 Then

                                        Comunes.Comun.WS.ClsConciliadorWS.RegresaPrimaryKeys(vDsDatos.Tables(vcNombreTabla))

                                        If Comunes.Comun.ClsTools.IfNull(miRow("bEliminarDatos"), False) Then
                                            If Not DAO.EjecutaComandoSQL(miRow("cSQLDelete")) Then
                                                If DAO.TieneTransaccionAbierta Then DAO.DeshaceTransaccion()
                                                DAO.EjecutaComandoSQL("EXEC UTL_HabilitaDeshabilitaTodoslosTriggerstabla '" & vcNombreTabla & "',1")
                                                Try
                                                    If Not prmLog Is Nothing Then
                                                        ClsTools.GrabaMensajeLog(prmLog, "Error ClsProcesaArchivo : " & DAO.RegresaFechaDelSistema & " Error al eliminar datos de la tabla " & vcNombreTabla, EventLogEntryType.Error)
                                                    End If
                                                    vDsDatos.Dispose()
                                                    vDsDatos = Nothing
                                                    GC.Collect()
                                                    GC.GetTotalMemory(False)
                                                    GC.WaitForPendingFinalizers()
                                                    DAO.EjecutaComandoSQL(String.Format("UPDATE CTL_AdministracionArchivosWS SET bProcesado=1,bError = 1,bActFechaExistencia = " & vcActualizaFechaExistencias & "  WHERE cNombreArchivo IN ('{0}')", prmNombreArchivo))
                                                    PlMensajeEstatusOcultar()
                                                    PlMensajeMostrar("Error al eliminar datos de la tabla " & vcNombreTabla, MessageBoxIcon.Error)
                                                    prmDevuelveMensaje &= "Error al eliminar datos de la tabla " & vcNombreTabla & vbCr
                                                    PlMensajeEstatusOcultar()
                                                    System.IO.Directory.Delete(vcDirectorioTrabajo, True)
                                                Catch
                                                End Try
                                                vbTodoCorrecto = False
                                                Exit For
                                            End If
                                        End If
                                        Try

                                            vcFiltro = Comunes.Comun.ClsContenedor.CreaFiltroWS(vDsDatos.Tables(vcNombreTabla))

                                            If Not vcFiltro = "" Then vcFiltro = " Where " & vcFiltro

                                            If Not ClsConciliadorWS.InsertaYActualizaTablaDeBD(vDsDatos.Tables(vcNombreTabla), vcFiltro) Then
                                                If DAO.TieneTransaccionAbierta Then DAO.DeshaceTransaccion()
                                                DAO.EjecutaComandoSQL("EXEC UTL_HabilitaDeshabilitaTodoslosTriggerstabla '" & vcNombreTabla & "',1")
                                                Try
                                                    If Not prmLog Is Nothing Then
                                                        ClsTools.GrabaMensajeLog(prmLog, "Error ClsProcesaArchivo : " & DAO.RegresaFechaDelSistema & " Error al guardar datos en la tabla " & vcNombreTabla, EventLogEntryType.Error)
                                                    End If
                                                    vDsDatos.Dispose()
                                                    vDsDatos = Nothing
                                                    GC.Collect()
                                                    GC.GetTotalMemory(False)
                                                    GC.WaitForPendingFinalizers()
                                                    DAO.EjecutaComandoSQL(String.Format("UPDATE CTL_AdministracionArchivosWS SET bProcesado=1,bError = 1,bActFechaExistencia = " & vcActualizaFechaExistencias & "  WHERE cNombreArchivo IN ('{0}')", prmNombreArchivo))
                                                    PlMensajeEstatusOcultar()
                                                    PlMensajeMostrar("Error al guardar datos de la tabla " & vcNombreTabla, MessageBoxIcon.Error)
                                                    prmDevuelveMensaje &= "Error al guardar datos de la tabla " & vcNombreTabla & vbCr
                                                    PlMensajeEstatusOcultar()
                                                    System.IO.Directory.Delete(vcDirectorioTrabajo, True)
                                                Catch
                                                End Try
                                                vbTodoCorrecto = False
                                                Exit For
                                            End If
                                        Catch ex As Exception
                                            If DAO.TieneTransaccionAbierta Then DAO.DeshaceTransaccion()
                                            If Not prmLog Is Nothing Then
                                                ClsTools.GrabaMensajeLog(prmLog, "Error ClsProcesaArchivo : " & DAO.RegresaFechaDelSistema & " " & ex.Source & " " & ex.Message.ToString, EventLogEntryType.Error)
                                            End If
                                            Try
                                                vDsDatos.Dispose()
                                                vDsDatos = Nothing
                                                GC.Collect()
                                                GC.GetTotalMemory(False)
                                                GC.WaitForPendingFinalizers()
                                                DAO.EjecutaComandoSQL(String.Format("UPDATE CTL_AdministracionArchivosWS SET bProcesado=1,bError = 1,bActFechaExistencia = " & vcActualizaFechaExistencias & "  WHERE cNombreArchivo IN ('{0}')", prmNombreArchivo))
                                                PlMensajeEstatusOcultar()
                                                PlMensajeMostrar("Error al guardar datos de la tabla " & vcNombreTabla, MessageBoxIcon.Error)
                                                prmDevuelveMensaje &= "Error al guardar datos de la tabla " & vcNombreTabla & vbCr
                                                PlMensajeEstatusOcultar()
                                                System.IO.Directory.Delete(vcDirectorioTrabajo, True)
                                            Catch
                                            End Try
                                            vbTodoCorrecto = False
                                        End Try
                                    End If
                                End If

                                vdFechaInicio = DAO.RegresaFechaDelSistema
                                If Not DAO.EjecutaComandoSQL("EXEC UTL_HabilitaDeshabilitaTodoslosTriggerstabla '" & vcNombreTabla & "',1") Then
                                    If DAO.TieneTransaccionAbierta Then DAO.DeshaceTransaccion()
                                    vdFechaInicio = DAO.RegresaFechaDelSistema
                                    Try
                                        If Not prmLog Is Nothing Then
                                            ClsTools.GrabaMensajeLog(prmLog, "Error ClsProcesaArchivo : " & DAO.RegresaFechaDelSistema & " Error al habilitar los triggers", EventLogEntryType.Error)
                                        End If
                                        vDsDatos.Dispose()
                                        vDsDatos = Nothing
                                        GC.Collect()
                                        GC.GetTotalMemory(False)
                                        GC.WaitForPendingFinalizers()
                                        DAO.EjecutaComandoSQL(String.Format("UPDATE CTL_AdministracionArchivosWS SET bProcesado=1,bError = 1,bActFechaExistencia = " & vcActualizaFechaExistencias & "  WHERE cNombreArchivo IN ('{0}')", prmNombreArchivo))
                                        PlMensajeEstatusOcultar()
                                        PlMensajeMostrar("Error al habilitar los triggers de la tabla " & vcNombreTabla, MessageBoxIcon.Error)
                                        prmDevuelveMensaje &= "Error al habilitar los triggers de la tabla " & vcNombreTabla & vbCr
                                        PlMensajeEstatusOcultar()
                                        System.IO.Directory.Delete(vcDirectorioTrabajo, True)
                                    Catch
                                    End Try
                                    'GuardaBitacora(vdFechaInicio, vdFechaInicio, 0, "Deshabilitando Triggers", DAO.UltimoMensajeEnviado, 0)
                                    vbTodoCorrecto = False
                                    Exit For
                                End If

                                Try

                                    ''Guardamos el tiempo de proceso de cada tabla
                                    'If Not GuardaBitacora(vdFechaInicio, DAO.RegresaFechaDelSistema, 1, "Guardado de Tabla", String.Format("Tabla Guardada - {0} Ok", vcNombreTabla), TamanoDatatable(vDt_Insertar)) Then
                                    ' If DAO.TieneTransaccionAbierta Then DAO.DeshaceTransaccion()
                                    ' Return False
                                    'End If

                                Catch ex As Exception
                                    If DAO.TieneTransaccionAbierta Then DAO.DeshaceTransaccion()
                                    'GuardaBitacora(vdFechaInicio, DAO.RegresaFechaDelSistema, 0, "GrabaDatosDepurado", String.Format("Error en Tabla - {0} : {1}", vcNombreTabla, ex.Message), 0)
                                    If Not prmLog Is Nothing Then
                                        ClsTools.GrabaMensajeLog(prmLog, "Error ClsProcesaArchivo : " & DAO.RegresaFechaDelSistema & " " & ex.Source & " " & ex.Message.ToString, EventLogEntryType.Error)
                                    End If
                                    If DAO.TieneTransaccionAbierta Then DAO.DeshaceTransaccion()
                                    Try
                                        vDsDatos.Dispose()
                                        vDsDatos = Nothing
                                        GC.Collect()
                                        GC.GetTotalMemory(False)
                                        GC.WaitForPendingFinalizers()
                                        DAO.EjecutaComandoSQL(String.Format("UPDATE CTL_AdministracionArchivosWS SET bProcesado=1,bError = 1,bActFechaExistencia = " & vcActualizaFechaExistencias & "  WHERE cNombreArchivo IN ('{0}')", prmNombreArchivo))
                                        PlMensajeEstatusOcultar()
                                        PlMensajeMostrar("Error al deshacer la transaccion", MessageBoxIcon.Error)
                                        PlMensajeEstatusOcultar()
                                        System.IO.Directory.Delete(vcDirectorioTrabajo, True)
                                    Catch
                                    End Try
                                    vbTodoCorrecto = False
                                    Exit For
                                End Try

                                ''Eliminamos la tabla del dataset y liberamos recursos
                                Try
                                    'vDsDatos.Tables.Remove(vDt_Insertar)
                                    GC.Collect()
                                    GC.GetTotalMemory(False)
                                    GC.WaitForPendingFinalizers()


                                Catch ex As Exception
                                    If DAO.TieneTransaccionAbierta Then DAO.DeshaceTransaccion()
                                    If Not prmLog Is Nothing Then
                                        ClsTools.GrabaMensajeLog(prmLog, "Error ClsProcesaArchivo : " & DAO.RegresaFechaDelSistema & " " & ex.Source & " " & ex.Message.ToString, EventLogEntryType.Error)
                                    End If
                                    If DAO.TieneTransaccionAbierta Then DAO.DeshaceTransaccion()
                                    Try
                                        vDsDatos.Dispose()
                                        vDsDatos = Nothing
                                        GC.Collect()
                                        GC.GetTotalMemory(False)
                                        GC.WaitForPendingFinalizers()
                                        DAO.EjecutaComandoSQL(String.Format("UPDATE CTL_AdministracionArchivosWS SET bProcesado=1,bError = 1,bActFechaExistencia = " & vcActualizaFechaExistencias & "  WHERE cNombreArchivo IN ('{0}')", prmNombreArchivo))
                                        PlMensajeEstatusOcultar()
                                        PlMensajeMostrar("Error al liberar la memoria ", MessageBoxIcon.Error)
                                        prmDevuelveMensaje &= "Error al liberar la memoria " & vbCr
                                        PlMensajeEstatusOcultar()
                                        System.IO.Directory.Delete(vcDirectorioTrabajo, True)
                                    Catch
                                    End Try
                                    'GuardaBitacora(vdFechaInicio, DAO.RegresaFechaDelSistema, 0, "Eliminando la tabla del dataset y liberando recursos", String.Format("Error al eliminar la Tabla Temporal #{0}, Error: {1}", vcNombreTabla, ex.ToString), 0)

                                    vbTodoCorrecto = False
                                    Exit For
                                End Try
                            Else

                                If Comunes.Comun.ClsTools.IfNull(miRow("bEliminarDatos"), False) Then
                                    If Not DAO.EjecutaComandoSQL(miRow("cSQLDelete")) Then
                                        If DAO.TieneTransaccionAbierta Then DAO.DeshaceTransaccion()
                                        DAO.EjecutaComandoSQL("EXEC UTL_HabilitaDeshabilitaTodoslosTriggerstabla '" & vcNombreTabla & "',1")
                                        Try
                                            If Not prmLog Is Nothing Then
                                                ClsTools.GrabaMensajeLog(prmLog, "Error ClsProcesaArchivo : " & DAO.RegresaFechaDelSistema & " Error al eliminar datos de la tabla " & vcNombreTabla, EventLogEntryType.Error)
                                            End If
                                            vDsDatos.Dispose()
                                            vDsDatos = Nothing
                                            GC.Collect()
                                            GC.GetTotalMemory(False)
                                            GC.WaitForPendingFinalizers()
                                            DAO.EjecutaComandoSQL(String.Format("UPDATE CTL_AdministracionArchivosWS SET bProcesado=1,bError = 1,bActFechaExistencia = " & vcActualizaFechaExistencias & "  WHERE cNombreArchivo IN ('{0}')", prmNombreArchivo))
                                            PlMensajeEstatusOcultar()
                                            PlMensajeMostrar("Error al eliminar datos de la tabla " & vcNombreTabla, MessageBoxIcon.Error)
                                            prmDevuelveMensaje &= "Error al eliminar datos de la tabla " & vcNombreTabla & vbCr
                                            PlMensajeEstatusOcultar()
                                            System.IO.Directory.Delete(vcDirectorioTrabajo, True)
                                        Catch
                                        End Try
                                        vbTodoCorrecto = False
                                        Exit For
                                    End If
                                End If
                            End If
                        Next

                        ''Eliminamos los recursos del dataset
                        vDsDatos.Dispose()
                        vDsDatos = Nothing
                        GC.Collect()
                        GC.GetTotalMemory(False)
                        GC.WaitForPendingFinalizers()


                        'If Not GuardaBitacora(vdInicioCargadoDataSet, DAO.RegresaFechaDelSistema, 1, "Fin Guardado de Datos", "OK", 0) Then
                        ' If DAO.TieneTransaccionAbierta Then DAO.DeshaceTransaccion()
                        'Return False
                        'End If

                        If vbTodoCorrecto Then
                            If Not DAO.CierraTransaccion() Then
                                vdFechaInicio = DAO.RegresaFechaDelSistema
                                Try
                                    vDsDatos.Dispose()
                                    vDsDatos = Nothing
                                    GC.Collect()
                                    GC.GetTotalMemory(False)
                                    GC.WaitForPendingFinalizers()
                                    If Not prmLog Is Nothing Then
                                        ClsTools.GrabaMensajeLog(prmLog, "Error al cerrar la transacción", EventLogEntryType.Error)
                                    End If
                                    DAO.EjecutaComandoSQL(String.Format("UPDATE CTL_AdministracionArchivosWS SET bProcesado=1,bError = 1,bActFechaExistencia = " & vcActualizaFechaExistencias & "  WHERE cNombreArchivo IN ('{0}')", prmNombreArchivo))
                                    PlMensajeEstatusOcultar()
                                    PlMensajeMostrar("Error al cerrar la transaccion", MessageBoxIcon.Error)
                                    PlMensajeEstatusOcultar()
                                    System.IO.Directory.Delete(vcDirectorioTrabajo, True)
                                Catch
                                End Try
                                ' GuardaBitacora(vdFechaInicio, vdFechaInicio, 0, "Cerrando Transaccion", DAO.UltimoMensajeEnviado, 0)

                                Return False
                            End If
                        End If

                    Catch ex As Exception
                        If Not prmLog Is Nothing Then
                            ClsTools.GrabaMensajeLog(prmLog, "Error ClsProcesaArchivo : " & DAO.RegresaFechaDelSistema & " " & ex.Source & " " & ex.Message.ToString, EventLogEntryType.Error)
                        End If
                        If DAO.TieneTransaccionAbierta Then DAO.DeshaceTransaccion()
                        Try
                            vDsDatos.Dispose()
                            vDsDatos = Nothing
                            GC.Collect()
                            GC.GetTotalMemory(False)
                            GC.WaitForPendingFinalizers()
                            DAO.EjecutaComandoSQL(String.Format("UPDATE CTL_AdministracionArchivosWS SET bProcesado=1,bError = 1,bActFechaExistencia = " & vcActualizaFechaExistencias & "  WHERE cNombreArchivo IN ('{0}')", prmNombreArchivo))
                            vcMensajeError = ex.Message
                            PlMensajeEstatusOcultar()
                            PlMensajeMostrar(vcMensajeError, MessageBoxIcon.Error)
                            PlMensajeEstatusOcultar()
                            System.IO.Directory.Delete(vcDirectorioTrabajo, True)
                        Catch
                        End Try
                        Return False
                    End Try
                    'GuardaBitacora(vdFechaInicio, DAO.RegresaFechaDelSistema, vcMensajeError.Equals(""), String.Format("Cargando Dataset - {0}", miEntry.Name), vcMensajeError, miEntry.Size)
                    If Not vcMensajeError.Equals("") Then
                        If DAO.TieneTransaccionAbierta Then DAO.DeshaceTransaccion()
                        Try
                            vDsDatos.Dispose()
                            vDsDatos = Nothing
                            GC.Collect()
                            GC.GetTotalMemory(False)
                            GC.WaitForPendingFinalizers()
                            If Not prmLog Is Nothing Then
                                ClsTools.GrabaMensajeLog(prmLog, "NOT vcMensajeError.Equals("")", EventLogEntryType.Error)
                            End If
                            DAO.EjecutaComandoSQL(String.Format("UPDATE CTL_AdministracionArchivosWS SET bProcesado=1,bError = 1,bActFechaExistencia = " & vcActualizaFechaExistencias & "  WHERE cNombreArchivo IN ('{0}')", prmNombreArchivo))
                            vcMensajeError = vcMensajeError
                            PlMensajeEstatusOcultar()
                            PlMensajeMostrar(vcMensajeError, MessageBoxIcon.Error)
                            PlMensajeEstatusOcultar()
                            prmDevuelveMensaje &= vcMensajeError & vbCr
                            System.IO.Directory.Delete(vcDirectorioTrabajo, True)
                        Catch
                        End Try
                        Return False
                    End If
                Next

                ''Leemos todos los archivos del zip descomprimirdo en un dataset
                'For Each miEntry As ICSharpCode.SharpZipLib.Zip.ZipEntry In vObjEntries

                'Next

                PlMensajeEstatusMostrar("Actualizando Archivo Procesado")

                If Not DAO.EjecutaComandoSQL(String.Format("UPDATE CTL_AdministracionArchivosWS SET bProcesado=1,bActFechaExistencia = " & vcActualizaFechaExistencias & "  WHERE cNombreArchivo IN ('{0}')", prmNombreArchivo)) Then
                    If DAO.TieneTransaccionAbierta Then DAO.DeshaceTransaccion()
                    If Not prmLog Is Nothing Then
                        ClsTools.GrabaMensajeLog(prmLog, "Error ClsProcesaArchivo : Actualizando archivo Procesado " & DAO.RegresaFechaDelSistema, EventLogEntryType.Error)
                    End If
                    Try
                        vDsDatos.Dispose()
                        vDsDatos = Nothing
                        GC.Collect()
                        GC.GetTotalMemory(False)
                        GC.WaitForPendingFinalizers()
                        DAO.EjecutaComandoSQL(String.Format("UPDATE CTL_AdministracionArchivosWS SET bProcesado=1,bError = 1,bActFechaExistencia = " & vcActualizaFechaExistencias & "  WHERE cNombreArchivo IN ('{0}')", prmNombreArchivo))
                        System.IO.Directory.Delete(vcDirectorioTrabajo, True)
                    Catch
                    End Try
                    PlMensajeEstatusOcultar()
                    Return False
                End If

                PlMensajeEstatusOcultar()
                PlMensajeEstatusMostrar("Eliminando directorio Temporal")
                ''Eliminamos el directorio temporal
                Try
                    vdFechaInicio = DAO.RegresaFechaDelSistema
                    System.IO.Directory.Delete(vcDirectorioTrabajo, True)
                Catch ex As Exception
                    'GuardaBitacora(vdFechaInicio, DAO.RegresaFechaDelSistema, 0, "Borrando Carpeta de Trabajo", ex.Message, 0)
                    PlMensajeEstatusOcultar()
                    Return False
                End Try
                PlMensajeEstatusOcultar()

                ''Guardamos el fin del cargado
                'If Not GuardaBitacora(vdFechaInicio, DAO.RegresaFechaDelSistema, 1, "Fin Cargado Dataset", "OK", 0) Then
                ' If DAO.TieneTransaccionAbierta Then DAO.DeshaceTransaccion()
                'Return False
                'End If

                Return True

            Catch ex As Exception
                If DAO.TieneTransaccionAbierta Then DAO.DeshaceTransaccion()
                PlMensajeMostrar(ex.Message.ToString, MessageBoxIcon.Error)
                PlMensajeEstatusOcultar()
                If Not prmLog Is Nothing Then
                    ClsTools.GrabaMensajeLog(prmLog, "Error ClsProcesaArchivo : " & DAO.RegresaFechaDelSistema & " " & ex.Source & " " & ex.Message.ToString, EventLogEntryType.Error)
                End If
                prmDevuelveMensaje &= ex.ToString & vbCr
                Return False
            End Try

        End Function

        Private Shared Function FlTablaPermiteDesactivarTriggers(ByVal prmNombreTabla As String, ByVal prmTablasNoPermitenDesactivarTrigger As String) As Boolean
            For Each vcTabla As String In prmTablasNoPermitenDesactivarTrigger.Trim.Split(",")
                If prmNombreTabla.Trim.ToUpper = vcTabla.Trim.ToUpper Then
                    Return False
                End If
            Next
            Return True
        End Function

        Private Shared Function GuardaBitacora(ByVal dFechaInicio As Date, ByVal dFechaFin As Date, ByVal bCorrecto As Integer, ByVal cProceso As String, ByVal cDescripcion As String, ByVal nTamBytes As Integer) As Boolean
            DAO = DataAccessCls.DevuelveInstancia
            'Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            WriteLine(cProceso & ", " & cDescripcion)

            Dim miSQLText As String = String.Format("SET DATEFORMAT YMD INSERT DEM_Bitacora_WebService(nid,bOrigenSucursal, nCanalDistribucion, dFechaInicio, dFechaFin, bCorrecto, cProceso, cDescripcion, nTamBytes) SELECT {0} ,{1} ,{2} ,'{3}' ,'{4}' ,{5} ,LEFT('{6}' ,100) ,'{7}' ,{8}" _
                                                    , "(SELECT ISNULL(MAX(nid),0)+1 FROM DEM_Bitacora_WebService(NOLOCK) WHERE borigensucursal = 0)" _
                                                    , Format(dFechaInicio, "yyyy/MM/dd HH:mm:ss") _
                                                    , Format(dFechaFin, "yyyy/MM/dd HH:mm:ss") _
                                                    , bCorrecto, cProceso, cDescripcion, nTamBytes)
            Return DAO.EjecutaComandoSQL(miSQLText)
        End Function

        Private Shared Function ExisteTablaEnDataSet(ByVal prmDsContendor As DataSet, ByVal prmNombreTabla As String) As Boolean
            For Each miTabla As DataTable In prmDsContendor.Tables
                If miTabla.TableName.Equals(prmNombreTabla) Then
                    Return True
                End If
            Next
            Return False
        End Function

        Private Shared Function TamanoDatatable(ByVal prmTabla As DataTable) As Integer
            Dim vnTamaño As Integer = 0
            For Each vrow As DataRow In prmTabla.Rows
                For Each vele As Object In vrow.ItemArray
                    If Not vele Is DBNull.Value Then
                        vnTamaño += Len(vele)
                    End If
                Next
            Next
            Return vnTamaño
        End Function

        Private Shared Function flInsertaArchivosManuales(ByVal prmArchivo As String, ByVal prmSucursal As Integer) As Boolean

            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vcCampos As String = "cNombreArchivo,bProcesado,bError,nOrden,bGeneradoSinLinea,nSucursal"
            Dim vcValores As String = "'" & prmArchivo.Trim & "',0,0,0,1," & prmSucursal
            Dim vcINSERT As String = "INSERT CTL_AdministracionArchivosWS ( " & vcCampos & " ) " & vbCr
            vcINSERT &= " VALUES ( " & vcValores & " )"
            Return DAO.EjecutaComandoSQL(vcINSERT)
        End Function

#End Region
    End Class
End Namespace


