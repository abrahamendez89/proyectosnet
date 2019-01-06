Imports Access.Comunes.Comun
Imports System.Windows.Forms
Imports System.IO
Imports System.Web.HttpServerUtility
Imports System.Web
Imports Access

Namespace Comunes.Comun.WS.Sucursal

    Public Class ClsPeticionSucursalCoporativo

        Private atrAlmacenSucursal As Int32
        Private atrContextoInformacion As String
        Private atrMuestraMensajes As Boolean
        Private atrProcesoCorrecto As Boolean = False

        Public ReadOnly Property ProcesoCorrecto() As Boolean
            Get
                Return atrProcesoCorrecto
            End Get
        End Property

        Public Sub MuestraMensajeInformacionRecibidaProcesada()
            Comunes.Comun.ClsTools.MuestraMensajeSistFact("Información recibida y procesada con éxito", MessageBoxIcon.Information)
        End Sub
        Public Sub MuestraMensajeInformacionNoRecibida()
            Select Case atrProcesoCorrecto
                Case True
                    Comunes.Comun.ClsTools.MuestraMensajeSistFact("No hay información", MessageBoxIcon.Information)
                Case False
                    Comunes.Comun.ClsTools.MuestraMensajeSistFact("Información no recibida", MessageBoxIcon.Exclamation)
            End Select
        End Sub

        Public Sub New(ByVal prmAlmacenSucursal As Int32, ByVal prmContextoInformacion As String, ByVal prmMuestraMensajes As Boolean)
            atrAlmacenSucursal = prmAlmacenSucursal
            atrContextoInformacion = prmContextoInformacion
            atrMuestraMensajes = prmMuestraMensajes
        End Sub

        ' ''Public Function SolicitaProcesaInformacion() As Boolean
        ' ''    Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''    Dim vDtUrl As New DataTable
        ' ''    DAO.RegresaConsultaSQL("SELECT TOP 1 * FROM CTL_PlazasEnviarInformacionWS (NOLOCK) WHERE bActivo = 1", vDtUrl)
        ' ''    If vDtUrl Is Nothing OrElse vDtUrl.Rows.Count = 0 Then
        ' ''        ClsTools.MuestraMensajeSistFact("No se ha configurado la dirección del ws panamá corporativo", MessageBoxIcon.Exclamation)
        ' ''        Return False
        ' ''    End If

        ' ''    Dim vcUrl As String = vDtUrl.Rows(0)("cUrl")

        ' ''    Dim wsRecepcion As New WSRecepcionArchivo.RecepcionArchivo
        ' ''    wsRecepcion.Timeout = 1000000
        ' ''    wsRecepcion.Url = vcUrl.Trim
        ' ''    Dim arch As Byte()
        ' ''    atrProcesoCorrecto = False
        ' ''    arch = wsRecepcion.RegresaInformacionParaSucursal(atrAlmacenSucursal, atrContextoInformacion, atrProcesoCorrecto)

        ' ''    If arch Is Nothing Then
        ' ''        ' ClsTools.MuestraMensajeSistFact("La información no ha sido recibida", MessageBoxIcon.Exclamation)
        ' ''        Return False
        ' ''    End If


        ' ''    Dim vObjProcesa As New Comunes.Comun.WS.Sucursal.ClsObtenInformacionParaSucursal(True)
        ' ''    Return vObjProcesa.ProcesaArchivo(arch)
        ' ''End Function

        Public Function ProcesaInformacionManual(ByVal vcPath As String, Optional ByVal prmMuestraMensajes As Boolean = False)
            Dim arch As Byte()
            arch = IO.File.ReadAllBytes(vcPath)

            If arch Is Nothing Then
                'ClsTools.MuestraMensajeSistFact("La información no ha sido recibida", MessageBoxIcon.Exclamation)
                Return False
            End If

            Dim vObjProcesa As New Comunes.Comun.WS.Sucursal.ClsObtenInformacionParaSucursal(True)
            Return vObjProcesa.ProcesaArchivo(arch)

            Return True
        End Function

    End Class

End Namespace