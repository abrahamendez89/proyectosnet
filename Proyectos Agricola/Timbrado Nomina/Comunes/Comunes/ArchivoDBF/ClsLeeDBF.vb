Imports System.Windows.Forms
Namespace Comunes.Comun.DBF
    Public Class ClsLeeDBF

#Region "Atributos"
        Private atrExtension As String = ""
        Private atrNombreArchivo As String = ""
        Private atrDirectoryName As String = ""
        Private atrFullPathArchivoOriginal As String = ""
        Private atrFullPathArchivoDBF As String = ""
        Private atrNombreArchivoOriginal As String = ""
        Private atrNombreArchivoOriginalSinExt As String = ""
        Private atrNombreArchivoDBF As String = ""
        Private atrNombreArchivoDBFSinExt As String = ""
        Private atrArchivoOriginalEsDBF As Boolean = False
        Private atrArchivosDeDirectorio() As String
        Private atrEsLeerTodoDirectorio As Boolean = False
        Private blnExisteDirectorio As Boolean = True
        Private blnExisteArchivo As Boolean = True
        Private atrMensajeError As String = ""
        Private atrMuestraMensajeError As Boolean = False
#End Region

#Region "constructor"
        'Este constructor se usará para cuando se quiera leer un archivo en especifico
        Public Sub New(ByVal prmRutaArchivo As String, ByVal prmExtension As String, ByVal prmNombreArchivo As String)
            blnExisteDirectorio = IO.Directory.Exists(IO.Path.GetDirectoryName(prmRutaArchivo.Trim))
            blnExisteArchivo = IO.File.Exists(prmRutaArchivo.Trim)
            atrExtension = prmExtension
            atrNombreArchivo = prmNombreArchivo
            atrEsLeerTodoDirectorio = False
            If blnExisteDirectorio AndAlso blnExisteArchivo Then
                'Configura los Atributos para Archivo original
                ConfiguraAtributosArchivoOriginal(prmRutaArchivo)
                'Configura los Atributos para Archivo DBF
                ConfiguraAtributosArchivoDBF(prmRutaArchivo)
            End If
            If Not blnExisteDirectorio Then atrMensajeError = "El directorio no existe"
            If Not blnExisteArchivo Then atrMensajeError = "El archivo no existe"
        End Sub
        'Este constructor se usará para cuando se quiera leer todos los archivos de un directorio
        Public Sub New(ByVal prmDirectorio As String, ByVal prmFiltroArchivos() As String, ByVal prmExtension As String, ByVal prmNombreArchivo As String)
            blnExisteDirectorio = IO.Directory.Exists(prmDirectorio.Trim)
            blnExisteArchivo = IO.File.Exists(prmDirectorio.Trim & prmNombreArchivo.Trim & "." & prmExtension.Trim)
            atrExtension = prmExtension
            atrNombreArchivo = prmNombreArchivo
            atrEsLeerTodoDirectorio = True
            atrDirectoryName = prmDirectorio
            atrArchivosDeDirectorio = prmFiltroArchivos
            If blnExisteDirectorio AndAlso blnExisteArchivo Then
                If prmFiltroArchivos Is Nothing OrElse prmFiltroArchivos.Length = 0 Then
                    If prmNombreArchivo.Trim = "" AndAlso prmExtension.Trim = "" Then
                        atrArchivosDeDirectorio = IO.Directory.GetFiles(atrDirectoryName)
                    Else
                        Dim vstr(0) As String
                        vstr(0) = prmDirectorio.Trim & prmNombreArchivo.Trim & "." & prmExtension.Trim
                        atrArchivosDeDirectorio = vstr
                    End If

                Else
                    atrArchivosDeDirectorio = prmFiltroArchivos
                End If
            End If
            If Not blnExisteDirectorio Then atrMensajeError = "El directorio no existe"
            If Not blnExisteArchivo Then atrMensajeError = "El archivo no existe"
        End Sub
#End Region

#Region "Propiedades"
        Public Property MostrarMensajeError() As Boolean
            Get
                Return atrMuestraMensajeError
            End Get
            Set(ByVal value As Boolean)
                atrMuestraMensajeError = value
            End Set
        End Property
        Public ReadOnly Property MensajeError() As String
            Get
                Return atrMensajeError
            End Get
        End Property

        Public ReadOnly Property RutaDBF() As String
            Get
                Return atrFullPathArchivoDBF
            End Get
        End Property
        Public ReadOnly Property RutaArchivoOriginal() As String
            Get
                Return atrFullPathArchivoOriginal
            End Get
        End Property
        Public ReadOnly Property NombreDirectorio() As String
            Get
                Return atrDirectoryName
            End Get
        End Property
        Public ReadOnly Property NombreArchivoOriginalSinExtension() As String
            Get
                Return atrNombreArchivoOriginalSinExt
            End Get
        End Property
        Public ReadOnly Property NombreArchivoDBFSinExtension() As String
            Get
                Return atrNombreArchivoDBFSinExt
            End Get
        End Property
        Public ReadOnly Property NombreArchivoOriginal() As String
            Get
                Return atrNombreArchivoOriginal
            End Get
        End Property
        Public ReadOnly Property NombreArchivoDBF() As String
            Get
                Return atrNombreArchivoDBF
            End Get
        End Property
        Public ReadOnly Property ArchivosDeDirectorio() As String()
            Get
                Return atrArchivosDeDirectorio
            End Get
        End Property
#End Region

#Region "Procedimientos y Funciones  -  PRIVADOS"
        Private Sub ConfiguraAtributosArchivoOriginal(ByVal prmRutaArchivo As String)
            'Obtiene la ruta completa y Nombre del directorio, del archivo a leer
            atrFullPathArchivoOriginal = prmRutaArchivo.Trim
            atrDirectoryName = IO.Path.GetDirectoryName(atrFullPathArchivoOriginal) & "\"
            'Obtiene el nombre del archivo original, con y sin extension
            atrNombreArchivoOriginal = System.IO.Path.GetFileName(prmRutaArchivo.Trim)
            atrNombreArchivoOriginalSinExt = System.IO.Path.GetFileNameWithoutExtension(prmRutaArchivo.Trim)
        End Sub

        Private Sub ConfiguraAtributosArchivoDBF(ByVal prmRutaArchivo As String)
            atrArchivoOriginalEsDBF = True
            'Se asume que el archivo es un DBF y se asigna el mismo nombre, con y sin extensión
            atrNombreArchivoDBF = atrNombreArchivoOriginal
            atrNombreArchivoDBFSinExt = atrNombreArchivoOriginalSinExt
            'Si el archivo no tiene extensión .DBF... se forma el nombre del archivo ya con extensión .DBF
            If Not System.IO.Path.GetExtension(prmRutaArchivo).ToUpper = ".DBF" Then
                atrNombreArchivoDBF = IO.Path.GetFileNameWithoutExtension(prmRutaArchivo) & IO.Path.GetExtension(prmRutaArchivo)
                atrNombreArchivoDBFSinExt = atrNombreArchivoDBF.Replace(".", "")
                atrNombreArchivoDBF = atrNombreArchivoDBFSinExt & ".DBF"
                atrArchivoOriginalEsDBF = False
            End If
            atrFullPathArchivoDBF = atrDirectoryName & atrNombreArchivoDBF
        End Sub

        Private Sub CreaDBF_De_ArchivoOriginal(ByVal prmRutaArchivoOriginal As String, ByVal prmRutaArchivoDBF As String)
            'Si ya existe un DBF con ese nombre lo elimina
            If IO.File.Exists(prmRutaArchivoDBF) Then
                IO.File.Delete(prmRutaArchivoDBF)
            End If
            'Copia el archivo original, a la ruta donde debe quedar el archivo.DBF
            IO.File.Copy(prmRutaArchivoOriginal, prmRutaArchivoDBF)
        End Sub

        Private Sub BorraDBF(ByVal prmRutaArchivoDBF As String)
            'Si existe el DBF, lo eliminará
            If IO.File.Exists(prmRutaArchivoDBF) Then
                IO.File.Delete(prmRutaArchivoDBF)
            End If
        End Sub

        Private Function RegresaTabla(ByVal prmNombreDBF As String, Optional ByRef prmArchivosConError As String = "", Optional ByVal prmMuestraMensaje As Boolean = True) As DataTable
            Dim strConexion As String = ""
            strConexion = "Provider =Microsoft.Jet.OLEDB.4.0; Data Source = " & atrDirectoryName & "; Extended Properties= dBASE IV;"
            Dim cnn As New OleDb.OleDbConnection(strConexion)
            Try
                If cnn.State = ConnectionState.Closed Then cnn.Open()
                Dim da As New OleDb.OleDbDataAdapter("SELECT * FROM " & prmNombreDBF, cnn)
                Dim dt As New DataTable
                da.Fill(dt)
                If cnn.State = ConnectionState.Open Then cnn.Close()
                Return dt
            Catch ex As Exception
                If prmMuestraMensaje Then
                    MessageBox.Show("El archivo " & NombreArchivoOriginal & " está dañado", "Error al leer archivo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

                prmArchivosConError &= NombreArchivoOriginal & vbCr
                Return Nothing
            End Try
        End Function
#End Region

#Region "Procedimientos y Funciones -  PUBLICAS"
        Public Function ObtenTabla(Optional ByRef prmArchivos As String = "", Optional ByVal prmMuestraMensaje As Boolean = True) As DataTable
            If MuestraMensajeError() Then Return Nothing
            Dim dt As New DataTable
            If Not atrArchivoOriginalEsDBF Then
                CreaDBF_De_ArchivoOriginal(atrFullPathArchivoOriginal, atrFullPathArchivoDBF)
            End If
            dt = RegresaTabla(atrNombreArchivoDBF, prmArchivos, prmMuestraMensaje)
            If Not atrArchivoOriginalEsDBF Then
                BorraDBF(atrFullPathArchivoDBF)
            End If
            Return dt
        End Function
        Public Function ObtenDataSet() As DataSet
            If MuestraMensajeError() Then Return Nothing
            Dim ds As New DataSet
            Dim dt As DataTable
            For Each vRutaArchivo As String In atrArchivosDeDirectorio
                'Configura los Atributos para Archivo original
                ConfiguraAtributosArchivoOriginal(vRutaArchivo)
                'Configura los Atributos para Archivo DBF
                ConfiguraAtributosArchivoDBF(vRutaArchivo)
                If Not atrArchivoOriginalEsDBF Then CreaDBF_De_ArchivoOriginal(atrFullPathArchivoOriginal, atrFullPathArchivoDBF)
                dt = RegresaTabla(atrNombreArchivoDBF)
                If Not dt Is Nothing Then
                    dt.TableName = atrNombreArchivoDBFSinExt
                    ds.Tables.Add(dt)
                End If
                If Not atrArchivoOriginalEsDBF Then BorraDBF(atrFullPathArchivoDBF)
                dt = New DataTable
            Next
            Return ds
        End Function
        Public Function ObtenListaArchivos() As DataTable
            If MuestraMensajeError() Then Return Nothing
            If atrArchivosDeDirectorio Is Nothing Then atrArchivosDeDirectorio = IO.Directory.GetFiles(atrDirectoryName)
            Dim dt As New DataTable
            Dim dr As DataRow
            dt.Columns.Add("cRutaArchivo", GetType(String))
            dt.Columns.Add("cNombreArchivo", GetType(String))

            For Each vstr As String In atrArchivosDeDirectorio
                If Not atrExtension.Trim = "" Then
                    If Not IO.Path.GetExtension(vstr).Trim.ToUpper = "." & atrExtension.Trim.ToUpper Then
                        Continue For
                    End If
                End If
                If Not atrNombreArchivo.Trim = "" Then
                    If Not IO.Path.GetFileNameWithoutExtension(vstr).Trim.ToUpper = atrNombreArchivo.Trim.ToUpper Then
                        Continue For
                    End If
                End If
                dr = dt.NewRow
                dr("cRutaArchivo") = vstr.Trim
                dr("cNombreArchivo") = IO.Path.GetFileName(vstr.Trim).Trim
                dt.Rows.Add(dr)
            Next
            Return dt
        End Function
        Public Function MuestraMensajeError() As Boolean
            blnExisteDirectorio = IO.Directory.Exists(atrDirectoryName)
            blnExisteArchivo = IO.File.Exists(atrDirectoryName & atrNombreArchivo & "." & atrExtension)
            If Not blnExisteDirectorio Then atrMensajeError = "El directorio no existe"
            If Not blnExisteArchivo Then atrMensajeError = "El archivo no existe"
            If Not atrMensajeError.Trim = "" Then
                If atrMuestraMensajeError Then ClsTools.MuestraMensajeSistFact(atrMensajeError, MessageBoxIcon.Information)
                Return True
            End If
            Return False
        End Function
#End Region

    End Class
End Namespace
