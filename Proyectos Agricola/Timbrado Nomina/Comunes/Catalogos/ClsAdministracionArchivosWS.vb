Imports Access
Namespace Comunes.Comun.WS
    Public Class ClsAdministracionArchivosWS
        Inherits Comunes.Comun.ClsContenedor

        Private atrNombreArchivo As String

        Public Property NombreArchivo() As String
            Get
                Return atrNombreArchivo
            End Get
            Set(ByVal value As String)
                atrNombreArchivo = value
            End Set
        End Property

        Public Sub New()
            Me.NombreTabla = FabricaWS.vcNombreTablaAdministracionArchivos
            Me.ObtenerTabla = AddressOf ObtenTabla
        End Sub

        Public Function ObtenTabla() As DataTable
            Return FabricaWS.ObtenAdministracionArchivos(Me)
        End Function

        Public Overrides Function Guardar(Optional ByVal PorClases As Boolean = True, Optional ByVal Directo As Boolean = False, Optional ByVal WebServices As Boolean = False) As Boolean
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Return MyBase.Guardar(False, True)
        End Function

        Public Shared Function GuardaArchivos(ByVal prmArchivo As String, ByVal prmPlazaEnvio As Int32, Optional ByVal prmGeneradoSinLinea As Boolean = 0) As Boolean
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vcCampos As String = "cNombreArchivo,bEnviado,nPlazaEnvio,bGeneradoSinLinea"
            Dim vcValores As String = "'" & prmArchivo.Trim & "',0," & prmPlazaEnvio & "," & IIf(prmGeneradoSinLinea, 1, 0)
            Dim vcINSERT As String = "INSERT CTL_AdministracionArchivosEnviosWS ( " & vcCampos & " ) " & vbCr
            vcINSERT &= " VALUES ( " & vcValores & " )"
            Return DAO.EjecutaComandoSQL(vcINSERT)
        End Function
        Public Shared Function ActualizaTamañoArchivo(ByVal prmArchivo As String, ByVal prmTamañoArchivo As Decimal) As Boolean
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vcUPDATE As String = "UPDATE CTL_AdministracionArchivosEnviosWS SET nTamañoArchivoMB = " & prmTamañoArchivo & vbCr
            vcUPDATE &= " WHERE cNombreArchivo = '" & prmArchivo.Trim & "'"
            Return DAO.EjecutaComandoSQL(vcUPDATE)
        End Function
        Public Shared Function ActualizaEnviado(ByVal prmNombreArchivo As String, ByVal prmEnviado As Boolean) As Boolean
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vcSQL As String = ""
            If Not ExisteArchivo(prmNombreArchivo.Trim) Then Return False
            vcSQL = "UPDATE CTL_AdministracionArchivosEnviosWS SET bEnviado = " & IIf(prmEnviado, 1, 0)
            vcSQL &= " WHERE cNombreArchivo = '" & prmNombreArchivo & "'"
            Return DAO.EjecutaComandoSQL(vcSQL)
        End Function

        Private Shared Function ExisteArchivo(ByVal prmNombreArchivo As String) As Boolean
            If prmNombreArchivo.Trim = "" Then Return False
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Return DAO.ExistenDatosEnConsultaSQL("SELECT * FROM CTL_AdministracionArchivosEnviosWS (NOLOCK) WHERE cNombreArchivo = '" & prmNombreArchivo & "'")
        End Function
    End Class
End Namespace
