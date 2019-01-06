Imports Access.Comunes.Comun
Imports Access.Comunes
Imports Access

Namespace Comunes.Comun
    Public Class ClsVariablesGlobales
#Region "VARIABLES GLOBALES POR PLAZA"
        ' ''Private Shared atrPlaza As Catalogos.ClsPlaza
        ' ''Public Shared Property Plaza() As Catalogos.ClsPlaza
        ' ''    Get
        ' ''        Return atrPlaza
        ' ''    End Get
        ' ''    Set(ByVal value As Catalogos.ClsPlaza)
        ' ''        atrPlaza = value
        ' ''    End Set
        ' ''End Property

#End Region
#Region "FILTRAR REGISTROS DE PRODUCCION - DISTRIBUCION"
        Private Shared atrDiasHaciaAtrasPermitidosParaVerRegistrosEnAyudaRapida As Integer
        Private Shared atrFechaRegistroJulianaMinimaPermitida As Integer

        Public Shared Property DiasPermitidosParaVerRegistrosEnAyudaRapida() As Integer
            Get
                Return atrDiasHaciaAtrasPermitidosParaVerRegistrosEnAyudaRapida
            End Get
            Set(ByVal value As Integer)
                atrDiasHaciaAtrasPermitidosParaVerRegistrosEnAyudaRapida = value
                Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
                atrFechaRegistroJulianaMinimaPermitida = DAO.NumeroJuliano(DAO.RegresaFechaDelSistema) - DiasPermitidosParaVerRegistrosEnAyudaRapida
            End Set
        End Property

        Public Shared ReadOnly Property FechaRegistroJulianaMinimaPermitida() As Integer
            Get
                Return atrFechaRegistroJulianaMinimaPermitida
            End Get
        End Property

        Public Shared ReadOnly Property FiltroFechaRegistroJulianaMinimaPermitida() As String
            Get
                Return "dbo.ADSUM_NumeroJuliano(dFecha_Registro) >= " & FechaRegistroJulianaMinimaPermitida
            End Get
        End Property
#End Region
#Region "TURNOS Y APERTURAS"
        ' ''Private Shared atrApertura As Caja.Apertura
        ' ''Private Shared atrAperturaAlmacen As Caja.clsApertura
        ' ''Private Shared atrEmpleadoLogin As Catalogos.ClsEmpleado
        ' ''Private Shared atrTurno As Catalogos.ClsTurno
        Private Shared atrTipoSucursal As Boolean = True

        Public Shared Property TipoSucursal() As Boolean
            Get
                Return atrTipoSucursal
            End Get
            Set(ByVal value As Boolean)
                atrTipoSucursal = value
            End Set
        End Property

        ' ''Public Shared Property Apertura() As Caja.Apertura
        ' ''    Get
        ' ''        If atrApertura Is Nothing Then

        ' ''        End If
        ' ''        Return atrApertura
        ' ''    End Get
        ' ''    Set(ByVal value As Caja.Apertura)
        ' ''        atrApertura = value
        ' ''    End Set
        ' ''End Property

        ' ''Public Shared Property AperturaAlmacen() As Caja.clsApertura
        ' ''    Get
        ' ''        If atrAperturaAlmacen Is Nothing Then

        ' ''        End If
        ' ''        Return atrAperturaAlmacen
        ' ''    End Get
        ' ''    Set(ByVal value As Caja.clsApertura)
        ' ''        atrAperturaAlmacen = value
        ' ''    End Set
        ' ''End Property

        ' ''Public Shared Property EmpleadoLogin() As Catalogos.ClsEmpleado
        ' ''    Get
        ' ''        Return atrEmpleadoLogin
        ' ''    End Get
        ' ''    Set(ByVal value As Catalogos.ClsEmpleado)
        ' ''        atrEmpleadoLogin = value
        ' ''    End Set
        ' ''End Property

        ' ''Public Shared ReadOnly Property TieneApertura() As Boolean
        ' ''    Get
        ' ''        If TipoSucursal Then
        ' ''            Return Not atrApertura Is Nothing
        ' ''        Else
        ' ''            Return Not atrAperturaAlmacen Is Nothing
        ' ''        End If

        ' ''    End Get
        ' ''End Property

        ' ''Public Shared ReadOnly Property FechaApertura() As Date
        ' ''    Get
        ' ''        If TipoSucursal Then
        ' ''            Return atrApertura.Fecha
        ' ''        Else
        ' ''            Return atrAperturaAlmacen.FechaInicialTurno
        ' ''        End If
        ' ''    End Get
        ' ''End Property

        ' ''Public Shared Function ValidaAperturaTurno(Optional ByRef prmForma As AccessForm = Nothing, Optional ByVal prmFechaMovimientoJuliana As Integer = 0, Optional ByVal prmRefresca As Boolean = True) As Boolean
        ' ''    Dim prmAlmacen As Catalogos.ClsAlmacen = ClsToolsAccTextBoxAdvanced.ObtenAlmacenINI
        ' ''    Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''    Dim vcParametro As String, vObjCaja As Caja.ClsCaja

        ' ''    If prmRefresca Then
        ' ''        If prmAlmacen Is Nothing Then Return False

        ' ''        If prmAlmacen.TipoAlmacen <> DAO.ParametroAdministradoObtener("CTL", "TIPOALMACEN_ALMACENSUCURSAL") Then
        ' ''            Select Case prmAlmacen.TipoAlmacen
        ' ''                Case Catalogos.ClsAlmacen.TiposAlmacen.Distribucion
        ' ''                    vcParametro = "VALIDA_APERTURATURNO_DISTRIBUCION"

        ' ''                Case Catalogos.ClsAlmacen.TiposAlmacen.Produccion
        ' ''                    vcParametro = "VALIDA_APERTURATURNO_PRODUCCION"

        ' ''            End Select

        ' ''            If DAO.ParametroAdministradoObtener("PRMSUC", vcParametro) = 0 Then Return True

        ' ''            TipoSucursal = False
        ' ''            Produccion.FabricaProduccion.RefrescaAperturaAlmacen(prmAlmacen)
        ' ''            If AperturaAlmacen IsNot Nothing Then
        ' ''                atrTurno = AperturaAlmacen.Turno
        ' ''            End If
        ' ''        Else
        ' ''            'Return True 'De momento no se valida para las tipo sucursal
        ' ''            TipoSucursal = True
        ' ''            vObjCaja = Dominio.Catalogos.FabricaCatalogos.ObtenCaja(prmAlmacen.Sucursal.Folio, Comunes.Comun.ClsTools.FgParametroObtieneValor(Comunes.Comun.ClsTools.PrmIni_CajaDefaultMovimiento))
        ' ''            Produccion.FabricaProduccion.RefrescaApertura(prmAlmacen.Sucursal, vObjCaja)
        ' ''        End If
        ' ''    End If

        ' ''    If Not TieneApertura Then
        ' ''        If Not prmForma Is Nothing Then prmForma.Close()
        ' ''        Comunes.Comun.ClsTools.MuestraMensajeSistFact("No se cuenta con una apertura abierta,verifique", Windows.Forms.MessageBoxIcon.Exclamation)
        ' ''        Return False
        ' ''    End If
        ' ''    'Si no es del tipo sucursal validar la fecha del movimiento
        ' ''    If Not TipoSucursal Then
        ' ''        If prmFechaMovimientoJuliana <> 0 Then
        ' ''            If Not (prmFechaMovimientoJuliana >= Comunes.Comun.ClsTools.NumeroJuliano(AperturaAlmacen.FechaInicialTurno) AndAlso _
        ' ''            prmFechaMovimientoJuliana <= Comunes.Comun.ClsTools.NumeroJuliano(AperturaAlmacen.FechaFinalTurno)) Then
        ' ''                Comunes.Comun.ClsTools.MuestraMensajeSistFact("La fecha del movimiento no pertenece al rango de la apertura abierta,no puede ser aplicada", Windows.Forms.MessageBoxIcon.Exclamation)
        ' ''                Return False
        ' ''            End If
        ' ''        End If
        ' ''    Else
        ' ''        If prmFechaMovimientoJuliana <> 0 Then
        ' ''            If Not (prmFechaMovimientoJuliana >= Comunes.Comun.ClsTools.NumeroJuliano(Apertura.Fecha) AndAlso _
        ' ''            prmFechaMovimientoJuliana <= Comunes.Comun.ClsTools.NumeroJuliano(Apertura.Fecha)) Then
        ' ''                Comunes.Comun.ClsTools.MuestraMensajeSistFact("La fecha del movimiento no pertenece al rango de la apertura abierta,no puede ser aplicada", Windows.Forms.MessageBoxIcon.Exclamation)
        ' ''                Return False
        ' ''            End If
        ' ''        End If
        ' ''    End If
        ' ''    If atrTurno Is Nothing Then
        ' ''        If Not prmForma Is Nothing Then prmForma.Close()
        ' ''        Comunes.Comun.ClsTools.MuestraMensajeSistFact("No se ha configurado un turno default para el almacén", Windows.Forms.MessageBoxIcon.Exclamation)
        ' ''        Return False
        ' ''    End If
        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Property Turno() As Catalogos.ClsTurno
        ' ''    Get
        ' ''        Return atrTurno
        ' ''    End Get
        ' ''    Set(ByVal value As Catalogos.ClsTurno)
        ' ''        atrTurno = value
        ' ''    End Set
        ' ''End Property

        ' ''Public Shared Sub LlenaDatosTurno(ByRef prmLblFolio As System.Windows.Forms.Label, ByRef prmLblDescripcion As System.Windows.Forms.Label)
        ' ''    prmLblFolio.Text = ""
        ' ''    prmLblDescripcion.Text = ""
        ' ''    If TieneApertura Then
        ' ''        If TipoSucursal Then
        ' ''            prmLblFolio.Text = Format(atrApertura.Turno.Folio, "000")
        ' ''            prmLblDescripcion.Text = atrApertura.Turno.Descripcion.Trim.ToUpper
        ' ''        Else
        ' ''            prmLblFolio.Text = Format(atrAperturaAlmacen.Turno.Folio, "000")
        ' ''            prmLblDescripcion.Text = atrAperturaAlmacen.Turno.Descripcion.Trim.ToUpper
        ' ''        End If

        ' ''        Return
        ' ''    End If
        ' ''    If Not atrTurno Is Nothing Then
        ' ''        prmLblFolio.Text = Format(atrTurno.Folio, "000")
        ' ''        prmLblDescripcion.Text = atrTurno.Descripcion.Trim.ToUpper
        ' ''        Return
        ' ''    End If
        ' ''End Sub

        ' ''Public Shared Function ValidaAperturaTurnoAntesGuardar(Optional ByVal prmFechaMovimientoJuliano As Integer = 0) As Boolean
        ' ''    Dim prmAlmacen As Catalogos.ClsAlmacen = ClsToolsAccTextBoxAdvanced.ObtenAlmacenINI
        ' ''    Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''    Dim vcParametro As String, vObjCaja As Caja.ClsCaja

        ' ''    If prmAlmacen Is Nothing Then Return False
        ' ''    If prmAlmacen.TipoAlmacen <> DAO.ParametroAdministradoObtener("CTL", "TIPOALMACEN_ALMACENSUCURSAL") Then
        ' ''        Select Case prmAlmacen.TipoAlmacen
        ' ''            Case Catalogos.ClsAlmacen.TiposAlmacen.Distribucion
        ' ''                vcParametro = "VALIDA_APERTURATURNO_DISTRIBUCION"

        ' ''            Case Catalogos.ClsAlmacen.TiposAlmacen.Produccion
        ' ''                vcParametro = "VALIDA_APERTURATURNO_PRODUCCION"

        ' ''        End Select
        ' ''        If DAO.ParametroAdministradoObtener("PRMSUC", vcParametro) = 0 Then Return True

        ' ''        TipoSucursal = False
        ' ''        Produccion.FabricaProduccion.RefrescaAperturaAlmacen(prmAlmacen)
        ' ''    Else
        ' ''        'Return True 'De momento no valida a sucursales
        ' ''        TipoSucursal = True
        ' ''        vObjCaja = Dominio.Catalogos.FabricaCatalogos.ObtenCaja(prmAlmacen.Sucursal.Folio, Comunes.Comun.ClsTools.FgParametroObtieneValor(Comunes.Comun.ClsTools.PrmIni_CajaDefaultMovimiento))
        ' ''        Produccion.FabricaProduccion.RefrescaApertura(prmAlmacen.Sucursal, vObjCaja)
        ' ''    End If

        ' ''    'Validamos que tenga apertura o turno, según el almacén.
        ' ''    Return ValidaAperturaTurno(, prmFechaMovimientoJuliano, False)
        ' ''End Function
#End Region
#Region "MANTENIMIENTO DE EXISTENCIAS"
        ' ''Private Shared atrAlmacenMantenimientoEnCurso As Catalogos.ClsAlmacen

        ' ''Public Shared Property AlmacenMantenimientoEnCurso() As Catalogos.ClsAlmacen
        ' ''    Get
        ' ''        Return atrAlmacenMantenimientoEnCurso
        ' ''    End Get
        ' ''    Set(ByVal value As Catalogos.ClsAlmacen)
        ' ''        atrAlmacenMantenimientoEnCurso = value
        ' ''    End Set
        ' ''End Property

        ' ''Public Shared Function ActualizaMantenimientoEnCursoParaAlmacen(ByVal prmActivaMantenimientoEnCurso As Boolean) As Boolean
        ' ''    If atrAlmacenMantenimientoEnCurso Is Nothing Then Return True
        ' ''    Return atrAlmacenMantenimientoEnCurso.ActualizaMantenimientoEnCurso(prmActivaMantenimientoEnCurso)
        ' ''End Function
#End Region
#Region "FOLIOS PARA REPORTES (CONFIGURADOR REPORTES)"
        Public Shared FolioReporte_ListadoDocumentosProduccion As Int32
        Public Shared FolioReportePedidosEspeciales As Int32
        Public Shared FolioReporte_ListadoMovimientosAlmacenProduccion As Int32
        Public Shared FolioReporte_ProductosCompuestosAfectanInventario As Int32
        Public Shared FolioReporte_ConcentradoSuministrosSucursal As Int32
        Public Shared FolioReporte_ConciliacionMovimientosTraspasos As Int32
        Public Shared FolioReporte_ConcentradoExistenciasVentas As Int32
#End Region
#Region "ARMADO FOLIO CODIGOS SERIALES"
        Public Shared NumeroJulianoParaArmadoCodigoSerial As Int32
#End Region

        Public Shared FolioAlmacenProduccion As Int32 = 0
        Private Shared atrAreasProduccionDistribucion As String = ""

        Public Shared Property AreasProduccionDistribucion() As String
            Get
                If atrAreasProduccionDistribucion.Trim = "" Then Return "0"
                Return atrAreasProduccionDistribucion.Trim
            End Get
            Set(ByVal value As String)
                atrAreasProduccionDistribucion = value
            End Set
        End Property
        Public Sub New()
            Dim DAO As DataAccessCls

            DAO = DataAccessCls.DevuelveInstancia
            DAO.ParametroAdministradoAgregar("PRMSUC", "VALIDA_APERTURATURNO_PRODUCCION", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro administrado para validar si existe apertura de turno en Producción", "1")
            DAO.ParametroAdministradoAgregar("PRMSUC", "VALIDA_APERTURATURNO_DISTRIBUCION", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro administrado para validar si existe apertura de turno en Distribución", "1")
        End Sub
    End Class
End Namespace