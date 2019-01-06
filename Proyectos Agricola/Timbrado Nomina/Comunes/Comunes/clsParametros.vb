Imports Access
Namespace Comunes.Comun
    Public Class ClsParametro
        Private atrDescripcion As String

        Public Shared DAO As DataAccessCls
        Private Enum Cdt_OrigenDeParametro
            ArchivoIni = 1
            Query = 2
            ValorPreDefinido = 3
        End Enum
        ' <summary>
        ' 1= Valor Predefinido
        ' 2= Resultado de Un query Tipo Regresa Dato
        ' 3= Entrada del Archivo Ini
        ' </summary>
        Private atrOrigenDeParametro As Cdt_OrigenDeParametro
        Private atrParametroIni As ClsParametroIni
        Private atrParametroQuery As ClsParametroQuery
        Private atrParametroValorPredefinido As ClsParametroValorPredefinido
        Public m_ClsParametroIni As ClsParametroIni
        Public m_ClsParametroQuery As ClsParametroQuery
        Public m_ClsParametroValorPredefinido As ClsParametroValorPredefinido

        ' 
        ' <param name="prmDescripcion"></param>
        ' <param name="prmParametro"></param>
        Public Sub New(ByVal prmDescripcion As String, ByVal prmParametro As ClsParametroIni)
            atrDescripcion = prmDescripcion
            atrParametroIni = prmParametro
            atrOrigenDeParametro = Cdt_OrigenDeParametro.ArchivoIni
        End Sub

        ' 
        ' <param name="prmDescripcion"></param>
        ' <param name="ormParametro"></param>
        Public Sub New(ByVal prmDescripcion As String, ByVal prmParametro As ClsParametroQuery)
            atrDescripcion = prmDescripcion
            atrParametroQuery = prmParametro
            atrOrigenDeParametro = Cdt_OrigenDeParametro.Query
        End Sub

        ' 
        ' <param name="prmDescripcion"></param>
        ' <param name="prmParametro"></param>
        Public Sub New(ByVal prmDescripcion As String, ByVal prmParametro As ClsParametroValorPredefinido)
            atrDescripcion = prmDescripcion
            atrParametroValorPredefinido = prmParametro
            atrOrigenDeParametro = Cdt_OrigenDeParametro.ValorPreDefinido
        End Sub

        Public Function Valor() As Object
            Select Case atrOrigenDeParametro
                Case Cdt_OrigenDeParametro.ArchivoIni
                    Return atrParametroIni.Valor()
                Case Cdt_OrigenDeParametro.Query
                    Return atrParametroQuery.Valor()
                Case Cdt_OrigenDeParametro.ValorPreDefinido
                    Return atrParametroValorPredefinido.Valor()
                Case Else
                    Return Nothing
            End Select
        End Function

    End Class ' ClsParametro

    Public Class ClsParametroIni


        Private atrRutaIni As String
        Private atrLlaveIni As String
        Private atrCalcularEnTiempoReal As Boolean
        Private atrValor As String
        Private atrValorAsignado As Boolean
        Public Shared DAO As DataAccessCls

        ' 
        ' <param name="prmRutaIni"></param>
        ' <param name="prmLlaveIni"></param>
        ' <param name="prmCalcularEnTiempoReal"></param>
        Public Sub New(ByVal prmLlaveIni As String, ByVal prmCalcularEnTiempoReal As Boolean)
            atrLlaveIni = prmLlaveIni
            atrCalcularEnTiempoReal = prmCalcularEnTiempoReal
        End Sub

        Public Function Valor() As String
            If Not atrValorAsignado Or atrCalcularEnTiempoReal Then 'Obtiene el valor y lo regresa

                DAO = DataAccessCls.DevuelveInstancia
                atrRutaIni = DAO.GetRutaArchivoIni
                Dim archivoIni As New Ini.IniFileController
                archivoIni.OpenINIFile(atrRutaIni)
                atrValor = archivoIni.GetEntry(atrLlaveIni)
                atrValorAsignado = True
            End If
            Return atrValor
        End Function
    End Class ' ClsParametroIni

    Public Class ClsParametroQuery
        Private atrQueryRegresaDato As String
        Private atrCalcularEnTiempoReal As Boolean
        Private atrValor As Object
        Private atrValorAsignado As Boolean
        Public Shared DAO As DataAccessCls

        ' 
        ' <param name="prmQueryRegresaDato"></param>
        ' <param name="prmCalcularEnTiempoReal"></param>
        Public Sub New(ByVal prmQueryRegresaDato As String, ByVal prmCalcularEnTiempoReal As Boolean)
            atrQueryRegresaDato = prmQueryRegresaDato
            atrCalcularEnTiempoReal = prmCalcularEnTiempoReal
            atrValorAsignado = False
        End Sub

        Public Function Valor() As Object
            If Not atrValorAsignado Or atrCalcularEnTiempoReal Then 'Obtiene el valor y lo regresa

                DAO = DataAccessCls.DevuelveInstancia
                atrValor = DAO.RegresaDatoSQL(atrQueryRegresaDato)
                atrValorAsignado = True
            End If
            Return atrValor
        End Function


    End Class ' ClsParametroQuery


    Public Class ClsParametroValorPredefinido


        ' <summary>
        ' 1- Cadena
        ' 2- Numerico
        ' 3-  fecha
        ' </summary>
        Private Enum CDT_tipoValor As Integer
            Cadena = 1
            Numerico = 2
            Fecha = 3
        End Enum
        Private atrTipoValor As CDT_tipoValor
        Private atrValorCadena As String
        Private atrValorNumerico As Double
        Private atrValorFecha As Date

        ' 
        ' <param name="prmValor"></param>
        Public Sub New(ByVal prmValor As String)
            atrTipoValor = CDT_tipoValor.Cadena
            atrValorCadena = prmValor
        End Sub

        ' 
        ' <param name="prmValor"></param>
        Public Sub New(ByVal prmValor As Double)
            atrTipoValor = CDT_tipoValor.Numerico
            atrValorNumerico = prmValor
        End Sub

        ' 
        ' <param name="prmValor"></param>
        Public Sub New(ByVal prmValor As Date)
            atrTipoValor = CDT_tipoValor.Cadena
            atrValorFecha = prmValor
        End Sub

        Public Function Valor() As Object
            Select Case atrTipoValor
                Case CDT_tipoValor.Cadena
                    Return atrValorCadena
                Case CDT_tipoValor.Numerico
                    Return atrValorNumerico
                Case CDT_tipoValor.Fecha
                    Return atrValorFecha
            End Select
        End Function


    End Class ' ClsParametroValorPredefinido

End Namespace
