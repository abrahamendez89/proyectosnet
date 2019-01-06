
Imports Sistema.Comunes.Comun.ClsTools
Imports Access

Namespace Comunes.Comun.WS.ConfiguracionSucursal
    Public Class ClsConfiguracionSucursalWS

        Private atrConfiguracionCorrecta As Boolean = False

        'PROCESA ARCHIVOS
        Private atrProcesaArchivos As Boolean = False
        Private atrEmpiezaAtuomaticamenteProcesaArchivos As Boolean = False
        Private atrHoraInicioProcesaArchivos As Int32 = 0
        Private atrMinutosFrecuenciaProcesaArchivos As Int32 = 0

        'ENVIO DE EXISTENCIAS
        Private atrEjecutaEnvioExistencias As Boolean = False
        Private atrEmpiezaAtuomaticamenteEnvioExistencias As Boolean = False
        Private atrHoraInicioEnvioExistencias As Int32 = 0
        Private atrMinutosFrecuenciaEnvioExistencias As Int32 = 0
        Private atrcContextoIntegraExistencias As String = ""
        Private atrnContextoIntegraExistencias As Int32 = 0

        'ENVIO DE VENTAS
        Private atrEjecutaEnvioVentas As Boolean = False
        Private atrHoraInicioEnviaVentas As Int32 = 0
        Private atrHoraFinEnviaVentas As Int32 = 0
        Private atrMinutosFrecuenciaEnviaVentas As Int32 = 0
        Private atrcContextoIntegraVentas As String = ""
        Private atrnContextoIntegraVentas As Int32 = 0

        'ENVIO INFORMACION GENERAL
        Private atrEjecutaEnviaInformacionGeneral As Boolean = False
        Private atrHoraInicioEnviaInformacionGeneral As Int32
        Private atrHoraFinEnviaInformacionGeneral As Int32
        Private atrMinutosFrecuenciaEnviaInformacionGeneral As Int32 = 0
        Private atrcContextoIntegraInformacionGeneral As String = ""
        Private atrnContextoIntegraInformacionGeneral As Int32 = 0

        'ACTUALIZACION DE CATÁLOGOS
        Private atrEjecutaActualizacionCatalogos As Boolean = False
        Private atrHoraInicioActualizacionCatalogos As Int32 = 0

        'ENVIO DE MOVIMIENTOS DE TRASPASOS
        Private atrEjecutaEnvioMovimientosTraspasos As Boolean = False
        Private atrEmpiezaAtuomaticamenteEnvioMovimientosTraspasos As Boolean = False
        Private atrHoraInicioEnvioMovimientosTraspasos As Int32 = 0
        Private atrMinutosFrecuenciaEnvioMovimientosTraspasos As Int32 = 0
        Private atrcContextoIntegraMovimientosTraspasos As String = ""
        Private atrnContextoIntegraMovimientosTraspasos As Int32 = 0

        Public Sub New(ByRef prmLog As EventLog, ByRef DAO As DataAccessCls)

            Dim vDt As New DataTable
            If Not prmLog Is Nothing Then
                GrabaMensajeLog(prmLog, "Obteniendo configuración del demonio " & DAO.GetNombreBaseDeDatos & "    " & DAO.GetNombreServidor, EventLogEntryType.Information)
            End If
            DAO.RegresaConsultaSQL("SELECT TOP 1 * FROM WS_Configuracion_Sucursal (NOLOCK)", vDt)
            If vDt Is Nothing OrElse vDt.Rows.Count = 0 Then
                If Not prmLog Is Nothing Then
                    GrabaMensajeLog(prmLog, "No hay información sobre la configuración del demonio", EventLogEntryType.Information)
                End If
                atrConfiguracionCorrecta = False
                Return
            End If
            Dim dr As DataRow
            dr = vDt.Rows(0)
            atrProcesaArchivos = False
            atrEmpiezaAtuomaticamenteProcesaArchivos = False
            atrHoraInicioProcesaArchivos = 20
            atrMinutosFrecuenciaProcesaArchivos = 50
            'ENVIO EXISTENCIA
            atrEjecutaEnvioExistencias = IfNull(dr("bEnviaExistencias"), False)
            atrEmpiezaAtuomaticamenteEnvioExistencias = IfNull(dr("bEmpiezaAtuomaticamenteEnviaExistencias"), False)
            atrHoraInicioEnvioExistencias = IfNull(dr("nHoraInicioEnviaExistencias"), 1)
            atrMinutosFrecuenciaEnvioExistencias = IfNull(dr("nMinutosFrecuenciaEnviaExistencias"), 5)
            atrnContextoIntegraExistencias = IfNull(dr("nContextoExistencias"), 0)
            atrcContextoIntegraExistencias = DAO.RegresaDatoSQL("SELECT cDescripcion FROM CTL_ContextosEnviarWS (NOLOCK) WHERE nContexto = " & IfNull(dr("nContextoExistencias"), 0))
            'ENVIO VENTAS
            atrEjecutaEnvioVentas = IfNull(dr("bEnviaVentas"), False)
            atrHoraInicioEnviaVentas = IfNull(dr("nHoraInicioEnviaVentas"), 24)
            atrHoraFinEnviaVentas = IfNull(dr("nHoraFinEnviaVentas"), 1)
            atrMinutosFrecuenciaEnviaVentas = IfNull(dr("nMinutosFrecuenciaEnviaVentas"), 5)
            atrnContextoIntegraVentas = IfNull(dr("nContextoVentas"), 0)
            atrcContextoIntegraVentas = DAO.RegresaDatoSQL("SELECT cDescripcion FROM CTL_ContextosEnviarWS (NOLOCK) WHERE nContexto = " & IfNull(dr("nContextoVentas"), 0))
            'ENVIO GENERAL
            atrEjecutaEnviaInformacionGeneral = IfNull(dr("bEnviaInformacionGeneral"), False)
            atrHoraInicioEnviaInformacionGeneral = IfNull(dr("nHoraInicioEnviaInformacionGeneral"), 24)
            atrHoraFinEnviaInformacionGeneral = IfNull(dr("nHoraFinEnviaInformacionGeneral"), 1)
            atrMinutosFrecuenciaEnviaInformacionGeneral = IfNull(dr("nMinutosEnviaInformacionGeneral"), 5)
            atrnContextoIntegraInformacionGeneral = IfNull(dr("nContextoGeneral"), 0)
            atrcContextoIntegraInformacionGeneral = DAO.RegresaDatoSQL("SELECT cDescripcion FROM CTL_ContextosEnviarWS (NOLOCK) WHERE nContexto = " & IfNull(dr("nContextoGeneral"), 0))
            'ACTUALIZA CATÁLOGOS
            atrEjecutaActualizacionCatalogos = IfNull(dr("bActualizaCatalogos"), False)
            atrHoraInicioActualizacionCatalogos = IfNull(dr("nHoraInicioActualizaCatalogos"), 22)
            'ENVIO MOVIMIENTOS DE ALMACÉN
            atrEjecutaEnvioMovimientosTraspasos = IfNull(dr("bEnviaMovimientosAlmacen"), False)
            atrEmpiezaAtuomaticamenteEnvioMovimientosTraspasos = IfNull(dr("bEmpiezaAutomaticamenteEnviaMovimientosAlmacen"), False)
            atrHoraInicioEnvioMovimientosTraspasos = IfNull(dr("nHoraInicioEnviaMovimientosAlmacen"), 1)
            atrMinutosFrecuenciaEnvioMovimientosTraspasos = IfNull(dr("nMinutosFrecuenciaEnviaMovimientosAlmacen"), 5)
            atrnContextoIntegraMovimientosTraspasos = IfNull(dr("nContextoMovimientosAlmacen"), 0)
            atrcContextoIntegraMovimientosTraspasos = DAO.RegresaDatoSQL("SELECT cDescripcion FROM CTL_ContextosEnviarWS (NOLOCK) WHERE nContexto = " & IfNull(dr("nContextoMovimientosAlmacen"), 0))

            If atrEjecutaEnvioExistencias AndAlso (atrcContextoIntegraExistencias.Trim = "" OrElse atrnContextoIntegraExistencias = 0) Then
                If Not prmLog Is Nothing Then
                    GrabaMensajeLog(prmLog, "El demonio permite enviar existencias pero no se le ha especificado un contexto", EventLogEntryType.Error)
                End If
                atrConfiguracionCorrecta = False
                Return
            End If

            If atrEjecutaEnvioVentas AndAlso (atrcContextoIntegraVentas.Trim = "" OrElse atrnContextoIntegraVentas = 0) Then
                If Not prmLog Is Nothing Then
                    GrabaMensajeLog(prmLog, "El demonio permite enviar ventas pero no se le ha especificado un contexto", EventLogEntryType.Error)
                End If
                atrConfiguracionCorrecta = False
                Return
            End If
            If atrEjecutaEnviaInformacionGeneral AndAlso (atrcContextoIntegraInformacionGeneral.Trim = "" OrElse atrnContextoIntegraInformacionGeneral = 0) Then
                If Not prmLog Is Nothing Then
                    GrabaMensajeLog(prmLog, "El demonio permite enviar información general pero no se le ha especificado un contexto", EventLogEntryType.Error)
                End If
                atrConfiguracionCorrecta = False
                Return
            End If
            If atrEjecutaEnvioMovimientosTraspasos AndAlso (atrcContextoIntegraMovimientosTraspasos.Trim = "" OrElse atrnContextoIntegraMovimientosTraspasos = 0) Then
                If Not prmLog Is Nothing Then
                    GrabaMensajeLog(prmLog, "El demonio permite enviar información de movimientos de almacén pero no se le ha especificado un contexto", EventLogEntryType.Error)
                End If
                atrConfiguracionCorrecta = False
                Return
            End If
            atrConfiguracionCorrecta = True
        End Sub

        Public ReadOnly Property ConfiguracionCorrecta() As Boolean
            Get
                Return atrConfiguracionCorrecta

            End Get
        End Property

#Region "PROPIEDADES - PROCESA ARCHIVOS"
        Public ReadOnly Property ProcesaArchivos() As Boolean
            Get
                Return atrProcesaArchivos
            End Get
        End Property
        Public ReadOnly Property EmpiezaAutomaticamenteProcesaArchivos() As Boolean
            Get
                Return atrEmpiezaAtuomaticamenteProcesaArchivos
            End Get
        End Property
        Public ReadOnly Property HoraInicioProcesaArchivos() As Int32
            Get
                Return atrHoraInicioProcesaArchivos
            End Get
        End Property
        Public ReadOnly Property FrecuenciaMinutosProcesaArchivos() As Int32
            Get
                Return atrMinutosFrecuenciaProcesaArchivos
            End Get
        End Property
#End Region
#Region "PROPIEDADES - ENVIA EXISTENCIAS"
        Public ReadOnly Property EnviaExistencias() As Boolean
            Get
                Return atrEjecutaEnvioExistencias
            End Get
        End Property
        Public ReadOnly Property EmpiezaAutomaticamenteEnvioExistencias() As Boolean
            Get
                Return atrEmpiezaAtuomaticamenteEnvioExistencias
            End Get
        End Property
        Public ReadOnly Property HoraInicioEnvioExistencias() As Int32
            Get
                Return atrHoraInicioEnvioExistencias
            End Get
        End Property
        Public ReadOnly Property FrecuenciaMinutosEnvioExistencias() As Int32
            Get
                Return atrMinutosFrecuenciaEnvioExistencias
            End Get
        End Property
        Public ReadOnly Property ContextoEnvioExistencias_c() As String
            Get
                Return atrcContextoIntegraExistencias
            End Get
        End Property
        Public ReadOnly Property ContextoEnvioExistencias_n() As Int32
            Get
                Return atrnContextoIntegraExistencias
            End Get
        End Property
#End Region
#Region "PROPIEDADES - ENVIA VENTAS"
        Public ReadOnly Property EnviaVentas() As Boolean
            Get
                Return atrEjecutaEnvioVentas
            End Get
        End Property
        Public ReadOnly Property HoraInicioEnvioVentas() As Int32
            Get
                Return atrHoraInicioEnviaVentas
            End Get
        End Property
        Public ReadOnly Property HoraFinEnvioVentas() As Int32
            Get
                Return atrHoraFinEnviaVentas
            End Get
        End Property
        Public ReadOnly Property FrecuenciaMinutosEnvioVentas() As Int32
            Get
                Return atrMinutosFrecuenciaEnviaVentas
            End Get
        End Property
        Public ReadOnly Property ContextoEnvioVentas_c() As String
            Get
                Return atrcContextoIntegraVentas
            End Get
        End Property
        Public ReadOnly Property ContextoEnvioVentas_n() As Int32
            Get
                Return atrnContextoIntegraVentas
            End Get
        End Property
#End Region
#Region "PROPIEDADES - ENVIA INFORMACION GENERAL"
        Public ReadOnly Property EnviaInformacionGeneral() As Boolean
            Get
                Return atrEjecutaEnviaInformacionGeneral
            End Get
        End Property
        Public ReadOnly Property HoraInicioEnvioInformacionGeneral() As Int32
            Get
                Return atrHoraInicioEnviaInformacionGeneral
            End Get
        End Property
        Public ReadOnly Property HoraFinEnvioInformacionGeneral() As Int32
            Get
                Return atrHoraFinEnviaInformacionGeneral
            End Get
        End Property
        Public ReadOnly Property FrecuenciaMinutosEnvioInformacionGeneral() As Int32
            Get
                Return atrMinutosFrecuenciaEnviaInformacionGeneral
            End Get
        End Property
        Public ReadOnly Property ContextoEnvioInformacionGeneral_c() As String
            Get
                Return atrcContextoIntegraInformacionGeneral
            End Get
        End Property
        Public ReadOnly Property ContextoEnvioInformacionGeneral_n() As Int32
            Get
                Return atrnContextoIntegraInformacionGeneral
            End Get
        End Property
#End Region
#Region "PROPIEDADES - ACTUALIZA CATALOGOS"
        Public Property ActualizaCatalogos() As Boolean
            Get
                Return atrEjecutaActualizacionCatalogos
            End Get
            Set(ByVal value As Boolean)
                atrEjecutaActualizacionCatalogos = value
            End Set
        End Property
        Public ReadOnly Property HoraInicioActualizaCatalogos() As Int32
            Get
                Return atrHoraInicioActualizacionCatalogos
            End Get
        End Property
#End Region
#Region "PROPIEDADES - ENVIA MOVIMIENTOS DE TRASPASOS"
        Public ReadOnly Property EnviaMovimientosTraspasos() As Boolean
            Get
                Return atrEjecutaEnvioMovimientosTraspasos
            End Get
        End Property
        Public ReadOnly Property EmpiezaAutomaticamenteEnvioMovimientosTraspasos() As Boolean
            Get
                Return atrEmpiezaAtuomaticamenteEnvioMovimientosTraspasos
            End Get
        End Property
        Public ReadOnly Property HoraInicioEnvioMovimientosTraspasos() As Int32
            Get
                Return atrHoraInicioEnvioMovimientosTraspasos
            End Get
        End Property
        Public ReadOnly Property FrecuenciaMinutosEnvioMovimientosTraspasos() As Int32
            Get
                Return atrMinutosFrecuenciaEnvioMovimientosTraspasos
            End Get
        End Property
        Public ReadOnly Property ContextoEnvioMovimientosTraspasos_c() As String
            Get
                Return atrcContextoIntegraMovimientosTraspasos
            End Get
        End Property
        Public ReadOnly Property ContextoEnvioMovimientosTraspasos_n() As Int32
            Get
                Return atrnContextoIntegraMovimientosTraspasos
            End Get
        End Property
#End Region

        ' ''Public Shared Function ActualizaEstatusDemonioSucursal(ByRef prmDAO As DataAccessCls, ByVal prmAlmacen As Int32, ByVal prmEncendido As Boolean) As Boolean
        ' ''    If Not prmDAO Is Nothing Then
        ' ''        prmDAO.EnviarMensajesAPantalla = False
        ' ''    End If
        ' ''    Dim WSRecepcion As WSRecepcionArchivo.RecepcionArchivo
        ' ''    WSRecepcion = WS.ClsConciliadorWS.DevuelveWSRecepcionArchivo(prmDAO)
        ' ''    Return WSRecepcion.GuardaBitacoraDemonioSucursal(prmAlmacen, prmEncendido)
        ' ''End Function

    End Class

End Namespace