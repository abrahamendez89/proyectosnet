Imports Access
Imports System.Data
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.IO


Namespace Comunes.Comun.ArchivoPlano

    Public MustInherit Class ClsArchivoPlanoBase


        'Define el formato en campos para leer el archivo
        Public MustOverride Function getFormatoTabla_O_TablaEscritura() As DataTable
        'Define la secuencia de caracteres que definen el termino del renglon
        Public MustOverride Function getTerminadorRenglon() As String
        'Define la secuencia de caracteres para identificar los campos numericos
        Public MustOverride Function getCaracterControlCamposNumericos() As String
        'Define la secuencia de caracteres para identificar los campos string
        Public MustOverride Function getCaracterControlCamposAlphaNumericos() As String

        'Define el caracter que separa los campos
        Public MustOverride Function getCaracterSeparadorCampos() As String
        'Define la ruta de la cual se leera el archivo plano de la workabout
        Public MustOverride Function getUbicacionArchivo() As String

        Protected Overridable Function UtilizaNumeroCaracteresFijo() As Boolean
            Return False
        End Function


        Protected DAO As DataAccessCls
        Protected vSql As String
        Protected vTabla As DataTable

        Public Sub New()
            DAO = DataAccessCls.DevuelveInstancia
            vSql = ""
            vTabla = Nothing
        End Sub




        Public Function ExisteArchivo() As Boolean
            Return ExisteArchivo(getUbicacionArchivo())
        End Function

        Public Function ExisteArchivo(ByVal prmUbicacionEscrituraArchivo As String) As Boolean
            Return File.Exists(prmUbicacionEscrituraArchivo)
        End Function

        Protected Overridable Function EscribirArchivo(ByVal prmNombreArchivo As String) As Boolean

            ''Dim misParametros As Comunes.Comun.Parametros.clsParametrosArchivoPlano = Comun.ClsTools.CargaParametrosWA()
            'Dim misParametros As Comunes.Comun.Parametros.clsParametrosArchivoPlano = Comun.ClsTools.CargaParametrosWA()
            'Dim miArchivoSinExtension As String = misParametros.getParametroRutaEjecutables & prmNombreArchivo

            'If EscribirArchivo(miArchivoSinExtension & ".ODB", True, True) Then
            '    Return EscribirArchivo(miArchivoSinExtension & ".LAB", True, False)
            'End If
            Return False
        End Function

        'Escribe el archivo en la ubicacion definida por el parametro
        Protected Overridable Function EscribirArchivo(ByVal prmUbicacionEscrituraArchivo As String, ByVal ELIMINAR_ARCHIVO_EXISTENTE As Boolean, Optional ByVal ODB As Boolean = True) As Boolean
            Dim vWritter As StreamWriter
            Try
                If File.Exists(prmUbicacionEscrituraArchivo) Then
                    If Not ELIMINAR_ARCHIVO_EXISTENTE Then Return False
                    File.Delete(prmUbicacionEscrituraArchivo)
                End If

                vWritter = New StreamWriter(prmUbicacionEscrituraArchivo)
                vWritter.NewLine = getTerminadorRenglon()
                If ODB Then
                    Return EscribirArchivo(vWritter)
                Else
                    Return EscribirArchivoLab(vWritter)
                End If

            Catch ex As Exception
                If Not vWritter Is Nothing Then vWritter.Close()
                MessageBox.Show("Error de WorkAbout: " & ex.Message, "WorkAbout", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try
        End Function

        Protected Overridable Function EscribirArchivoDefiniendoExtension(ByVal prmNombreArchivo As String, ByVal prmExtensionArchivo As String) As Boolean
            'Dim misParametros As Comunes.Comun.Parametros.clsParametrosArchivoPlano = Comun.ClsTools.CargaParametrosWA()
            'Dim miArchivoSinExtension As String = misParametros.getParametroRutaEjecutables & prmNombreArchivo

            'If EscribirArchivo(miArchivoSinExtension & prmExtensionArchivo, True, True) Then
            '    Return EscribirArchivo(miArchivoSinExtension & ".LAB", True, False)
            'End If
            Return False
        End Function

        Protected Overridable Function EscribirArchivoLab(ByVal prmStreamWriter As StreamWriter) As Boolean
            Dim vTabla As DataTable = getFormatoTabla_O_TablaEscritura()
            If vTabla Is Nothing Then Return False

            Try
                For Each miColumna As DataColumn In vTabla.Columns
                    prmStreamWriter.WriteLine(miColumna.ColumnName)
                Next

                prmStreamWriter.Close()
                Return True
            Catch Ex As IO.IOException
                If Not prmStreamWriter Is Nothing Then prmStreamWriter.Close()
                MessageBox.Show("Error de WorkAbout: " & Ex.Message, "WorkAbout", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try
        End Function

        Protected Overridable Function EscribirArchivo(ByVal prmStreamWriter As StreamWriter) As Boolean
            Dim vTabla As DataTable = getFormatoTabla_O_TablaEscritura()
            If vTabla Is Nothing Then Return False

            Try
                Dim vLinea As String
                For Each vRow As DataRow In vTabla.Rows
                    vLinea = ""
                    For Each vColumn As DataColumn In vTabla.Columns
                        Dim vSecuenciaSeparador As String = IIf(EsStringColumna(vColumn), getCaracterControlCamposAlphaNumericos, getCaracterControlCamposNumericos)
                        Dim vUbicacion As EUbicacionesDeCaracteresControl = EUbicacionesDeCaracteresControl.InicioYFin
                        If vLinea <> "" Then
                            vLinea += getCaracterSeparadorCampos()
                        End If
                        vLinea += AgregaDelimitadores(CStr(vRow(vColumn.ColumnName)).Trim, vSecuenciaSeparador, vUbicacion)
                    Next
                    prmStreamWriter.WriteLine(vLinea)
                Next

                prmStreamWriter.Close()
                Return True
            Catch Ex As IO.IOException
                If Not prmStreamWriter Is Nothing Then prmStreamWriter.Close()
                MessageBox.Show("Error de WorkAbout: " & Ex.Message, "WorkAbout", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try
        End Function

        Public Shared Function ValidaArchivosYDirectorios() As Boolean
            'Dim misParametros As Comunes.Comun.Parametros.clsParametrosArchivoPlano = Comun.ClsTools.CargaParametrosWA()
            'Dim miRuta As String = misParametros.getParametroRutaEjecutables
            'If Not Directory.Exists(miRuta) Then
            '    MessageBox.Show("La ruta '" & miRuta & "' no existe, consulte al administrador del sistema", Comunes.Comun.ClsTools.GlobalSistemaCaption, MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    Return False
            'End If

            'If Not File.Exists(miRuta & "RCOM.EXE") Then
            '    MessageBox.Show("La archivo '" & miRuta & "RCOM.EXE" & "' no existe, consulte al administrador del sistema", Comunes.Comun.ClsTools.GlobalSistemaCaption, MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    Return False
            'End If

            'If Not File.Exists(miRuta & "Text2Dbf.EXE") Then
            '    MessageBox.Show("La archivo '" & miRuta & "Text2Dbf.EXE" & "' no existe, consulte al administrador del sistema", Comunes.Comun.ClsTools.GlobalSistemaCaption, MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    Return False
            'End If

            Return True
        End Function

        Public Shared Function ValidaDirectorio(ByVal prmRuta As String) As Boolean

            If Not Directory.Exists(prmRuta) Then
                MessageBox.Show("La ruta '" & prmRuta & "' no existe, consulte al administrador del sistema", Comunes.Comun.ClsTools.GlobalSistemaCaption, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            Return True
        End Function

        Public Overridable Function EscribirArchivo(ByVal prmRutaArchivoEnWorkAbout As String, ByVal prmNombreArchivo As String, Optional ByVal ELIMINAR_ARCHIVO_EXISTENTE As Boolean = True) As Boolean

            'If Not ValidaArchivosYDirectorios() Then
            '    Return False
            'End If

            'If Not EscribirArchivo(prmNombreArchivo) Then Return False
            ''Ejecutamos el exe que convierte el texto plano a un archivo de dbf especial de workabout
            'Dim misParametros As Comunes.Comun.Parametros.clsParametrosArchivoPlano = Comun.ClsTools.CargaParametrosWA()
            'Dim miRuta As String = misParametros.getParametroRutaEjecutables
            'Dim miInstruccion As String
            'Dim miBatEjecucion As String
            'Dim miBatInstrucciones As String
            'Dim miBatCreaDBF As String
            ' ''miInstruccion &= miRuta & "Text2Dbf -Q@ -D, -L" & miRuta & prmNombreArchivo & ".LAB -O" & miRuta & prmNombreArchivo & ".DBF " & miRuta & prmNombreArchivo & ".ODB"
            'Dim miUnidad As String = Dominio.WorkAbout.ClsWorkAboutBase.UnidadLibre()
            'Try
            '    'Creamos el archivo dbf workabout
            '    ''Shell(miInstruccion, AppWinStyle.NormalFocus, True)
            '    miInstruccion = "NET USE " & miUnidad & ": " & Dominio.WorkAbout.ClsWorkAboutBase.QuitarDiagonalAlFinal(miRuta) & vbCrLf
            '    miInstruccion &= miUnidad & ":\Text2Dbf -Q@ -D, -L" & miUnidad & ":\" & prmNombreArchivo & ".LAB -O" & miUnidad & ":\" & prmNombreArchivo & ".DBF " & miUnidad & ":\" & prmNombreArchivo & ".ODB" & vbCrLf
            '    miInstruccion &= "NET USE " & miUnidad & ": /d" & vbCrLf
            '    miBatCreaDBF = CreaArchivoConNombre(Comun.ClsTools.ParamtetrosSucursal.RutaArchivosTemporales(), "CREADBF", miInstruccion, ".BAT")
            '    If miBatCreaDBF = "" Then Return False
            '    If Not WorkAbout.ClsWorkAboutBase.DesImpersonaliza() Then Return Nothing
            '    Shell(miBatCreaDBF, AppWinStyle.NormalFocus, True)

            '    miInstruccion = "DEL " & prmRutaArchivoEnWorkAbout & prmNombreArchivo & ".*" & vbCrLf
            '    miInstruccion &= "COPY " & miUnidad & ":\" & prmNombreArchivo & ".DBF " & prmRutaArchivoEnWorkAbout & vbCrLf
            '    'Creamos el bat de instruccion a ejecutar en la workabout

            '    miBatInstrucciones = CreaArchivoConNombre(Comun.ClsTools.ParamtetrosSucursal.RutaArchivosTemporales(), "CODE", miInstruccion, ".BAT")
            '    If miBatInstrucciones = "" Then Return False
            '    miInstruccion = "NET USE " & miUnidad & ": " & Dominio.WorkAbout.ClsWorkAboutBase.QuitarDiagonalAlFinal(miRuta) & vbCrLf
            '    miInstruccion &= miUnidad & ":\RCOM /P" & misParametros.ParametroPuerto.Valor & " /C /W+ /A " & miBatInstrucciones & vbCrLf
            '    miInstruccion &= "NET USE " & miUnidad & ": /d" & vbCrLf
            '    ''miInstruccion = miRuta & "RCOM /P" & misParametros.ParametroPuerto.Valor & " /C /W+ /A " & miBatInstrucciones
            '    'Creamos el bat que se conectara con la workabout y ejecutara el bat de instrucciones
            '    miBatEjecucion = CreaArchivoConNombre(Comun.ClsTools.ParamtetrosSucursal.RutaArchivosTemporales(), "EXEC", miInstruccion, ".BAT")
            '    If miBatEjecucion = "" Then Return False
            '    'Este flush es para que deseche la cola de mensajes y evitar el problema de el cambio de pantalla activa
            '    SendKeys.Flush()
            '    'Ejecutamos el bat de conexion
            '    If Not WorkAbout.ClsWorkAboutBase.DesImpersonaliza() Then Return Nothing
            '    Shell(miBatEjecucion, AppWinStyle.NormalFocus, True)
            '    'Eliminamos los archivos de trabajo
            '    Tool.EsperarHastaEncontrarArchivo(miBatCreaDBF)
            '    Tool.EsperarHastaEncontrarArchivo(miBatInstrucciones)
            '    Tool.EsperarHastaEncontrarArchivo(miBatEjecucion)
            '    File.Delete(miBatCreaDBF)
            '    File.Delete(miBatInstrucciones)
            '    File.Delete(miBatEjecucion)
            Return True
            'Catch ex As Exception
            '    'MessageBox.Show("Error al intentar subir a la WorkAbout :" & ex.Message, Comunes.Comun.ClsTools.GlobalSistemaCaption, MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End Try
            Return False
        End Function


        Public Overridable Function EscribirArchivoCaracteresFijo(ByVal prmStreamWriter As StreamWriter) As Boolean
            Dim vTabla As DataTable = getFormatoTabla_O_TablaEscritura()
            If vTabla Is Nothing Then Return False

            Try
                Dim vLinea As String = ""
                For Each vRow As DataRow In vTabla.Rows
                    For Each vColumn As DataColumn In vTabla.Columns
                        vLinea += vRow(vColumn)
                    Next
                Next

                prmStreamWriter.Write(vLinea)
                prmStreamWriter.Close()
                Return True
            Catch Ex As IO.IOException
                MessageBox.Show("Error de WorkAbout: " & Ex.Message, "WorkAbout", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try
        End Function

        'Lee el archivo desde la ubicacion especificada por la clase
        Public Overridable Function LeerArchivo() As DataTable
            If UtilizaNumeroCaracteresFijo() Then
                Return LeerArchivo(getUbicacionArchivo)
            Else
                Return LeerArchivo(getUbicacionArchivo)
            End If

        End Function

        Public Shared Function PonerDiagonalAlFinal(ByVal prmRuta As String) As String
            PonerDiagonalAlFinal = prmRuta & IIf(prmRuta.EndsWith("\"), "", "\")
        End Function

        Public Shared Function QuitarDiagonalAlFinal(ByVal prmRuta As String) As String
            QuitarDiagonalAlFinal = prmRuta
            If prmRuta.EndsWith("\") Then
                QuitarDiagonalAlFinal = Left(prmRuta, prmRuta.Length - 1)
            End If
        End Function

        Public Shared Function UnidadLibre() As String
            ''empezamos a buscar las unidad libres
            '', la inicial sera la G para no interferir en las utilizadas por fox
            Dim miUnidad As Integer = Asc("G")
            While System.IO.Directory.Exists(Chr(miUnidad) & ":\")
                miUnidad += 1
            End While
            UnidadLibre = Chr(miUnidad)
        End Function

        'Descarga archivo de la workabot importacion
        Public Overridable Function LeerArchivoNueva(ByVal prmNombreArchivo As String, ByVal prmRutaDentroWorkAbout As String) As DataTable

            'If Not ValidaArchivosYDirectorios() Then
            '    Return Nothing
            'End If
            ''Ejecutamos el exe que convierte el texto plano a un archivo de dbf especial de workabout
            'Dim misParametros As Comunes.Comun.Parametros.clsParametrosArchivoPlano = Comun.ClsTools.CargaParametrosWA()
            'Dim miRuta As String = misParametros.getParametroRutaEjecutables

            'Dim miInstruccion As String
            'Dim miBatEjecucion As String
            'Dim miBatInstrucciones As String
            'Dim miUnidad As String = Dominio.WorkAbout.ClsWorkAboutBase.UnidadLibre()

            'Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia

            'Try



            '    'Correr la baja de embarques
            '    miInstruccion = "NET USE " & miUnidad & ": " & Dominio.WorkAbout.ClsWorkAboutBase.QuitarDiagonalAlFinal(miRuta) & vbCrLf

            '    ''Con ruta 
            '    miInstruccion &= miUnidad & ":\CarDescWa " & DAO.GetRutaArchivoIni & " BajaImp " & miUnidad & ":\" & prmNombreArchivo & ".ODB" & vbCrLf

            '    miInstruccion &= "NET USE " & miUnidad & ": /d" & vbCrLf
            '    'Creamos el bat que se conectara con la workabout y ejecutara el bat de instrucciones
            '    miBatEjecucion = CreaArchivoConNombre(Comun.ClsTools.ParamtetrosSucursal.RutaArchivosTemporales(), "EXEC", miInstruccion, ".BAT")
            '    If miBatEjecucion = "" Then Return Nothing
            '    'Ejecutamos el bat de conexion
            '    If Not WorkAbout.ClsWorkAboutBase.DesImpersonaliza() Then Return Nothing

            '    Shell(miBatEjecucion, AppWinStyle.NormalFocus, True)

            '    Tool.EsperarHastaEncontrarArchivo(miBatEjecucion)
            '    File.Delete(miBatEjecucion)

            '    LeerArchivoNueva = LeerArchivo(miRuta & prmNombreArchivo & ".ODB")

            '    File.Delete(miRuta & prmNombreArchivo & ".ODB")
            '    Return LeerArchivoNueva
            'Catch ex As Exception
            '    MessageBox.Show("Error al intentar bajar desde WorkAbout :" & ex.Message, Comunes.Comun.ClsTools.GlobalSistemaCaption, MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End Try
            Return Nothing
        End Function

        'Descarga archivo de la workabot fisico
        Public Overridable Function LeerArchivoInvNueva(ByVal prmNombreArchivo As String, ByVal prmRutaDentroWorkAbout As String) As DataTable

            'If Not ValidaArchivosYDirectorios() Then
            '    Return Nothing
            'End If
            ''Ejecutamos el exe que convierte el texto plano a un archivo de dbf especial de workabout
            'Dim misParametros As Comunes.Comun.Parametros.clsParametrosArchivoPlano = Comun.ClsTools.CargaParametrosWA()
            'Dim miRuta As String = misParametros.getParametroRutaEjecutables
            'Dim miInstruccion As String
            'Dim miBatEjecucion As String
            'Dim miBatInstrucciones As String
            'Dim miUnidad As String = Dominio.WorkAbout.ClsWorkAboutBase.UnidadLibre()

            'Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia


            'Try



            '    'Correr la baja de embarques
            '    miInstruccion = "NET USE " & miUnidad & ": " & Dominio.WorkAbout.ClsWorkAboutBase.QuitarDiagonalAlFinal(miRuta) & vbCrLf
            '    ''Con ruta 
            '    miInstruccion &= miUnidad & ":\CarDescWa " & DAO.GetRutaArchivoIni & " BAJAINV2 " & miUnidad & ":\" & prmNombreArchivo & ".ODB" & vbCrLf

            '    miInstruccion &= "NET USE " & miUnidad & ": /d" & vbCrLf
            '    'Creamos el bat que se conectara con la workabout y ejecutara el bat de instrucciones
            '    miBatEjecucion = CreaArchivoConNombre(Comun.ClsTools.ParamtetrosSucursal.RutaArchivosTemporales(), "EXEC", miInstruccion, ".BAT")
            '    If miBatEjecucion = "" Then Return Nothing
            '    'Ejecutamos el bat de conexion
            '    If Not WorkAbout.ClsWorkAboutBase.DesImpersonaliza() Then Return Nothing

            '    Shell(miBatEjecucion, AppWinStyle.NormalFocus, True)

            '    Tool.EsperarHastaEncontrarArchivo(miBatEjecucion)
            '    File.Delete(miBatEjecucion)

            '    LeerArchivoInvNueva = LeerArchivo(miRuta & prmNombreArchivo & ".ODB")

            '    File.Delete(miRuta & prmNombreArchivo & ".ODB")
            '    Return LeerArchivoInvNueva
            'Catch ex As Exception
            '    MessageBox.Show("Error al intentar bajar desde WorkAbout :" & ex.Message, Comunes.Comun.ClsTools.GlobalSistemaCaption, MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End Try
            Return Nothing
        End Function


        'Descarga y Conviente el archivo de la workabot a un archivo plano
        Public Overridable Function LeerArchivo(ByVal prmNombreArchivo As String, ByVal prmRutaDentroWorkAbout As String) As DataTable
            If Not ValidaArchivosYDirectorios() Then
                Return Nothing
            End If
            ''Ejecutamos el exe que convierte el texto plano a un archivo de dbf especial de workabout
            'Dim misParametros As Comunes.Comun.Parametros.clsParametrosArchivoPlano = Comun.ClsTools.CargaParametrosWA()
            'Dim miRuta As String = misParametros.getParametroRutaEjecutables

            'Dim miInstruccion As String
            'Dim miBatEjecucion As String
            'Dim miBatInstrucciones As String
            'Dim miUnidad As String = Dominio.WorkAbout.ClsWorkAboutBase.UnidadLibre()
            'Try
            '    miInstruccion = "COPY " & prmRutaDentroWorkAbout & prmNombreArchivo & ".DBF " & miUnidad & ":\" & prmNombreArchivo & ".DBF" & vbCrLf
            '    'Creamos el bat de instruccion a ejecutar en la workabout
            '    miBatInstrucciones = CreaArchivoConNombre(Comun.ClsTools.ParamtetrosSucursal.RutaArchivosTemporales(), "CODE", miInstruccion, ".BAT")
            '    If miBatInstrucciones = "" Then Return Nothing
            '    miInstruccion = "NET USE " & miUnidad & ": " & Dominio.WorkAbout.ClsWorkAboutBase.QuitarDiagonalAlFinal(miRuta) & vbCrLf
            '    miInstruccion &= miUnidad & ":\RCOM /P" & misParametros.ParametroPuerto.Valor & " /C /W+ /A " & miBatInstrucciones & vbCrLf
            '    miInstruccion &= miUnidad & ":\" & "DBCONV " & miUnidad & ":\" & prmNombreArchivo & ".DBF -m -o" & miUnidad & ":\" & prmNombreArchivo & ".ODB" & vbCrLf
            '    miInstruccion &= "NET USE " & miUnidad & ": /d" & vbCrLf
            '    'miInstruccion = miRuta & "RCOM /P" & misParametros.ParametroPuerto.Valor & " /C /W+ /A " & miBatInstrucciones
            '    'Creamos el bat que se conectara con la workabout y ejecutara el bat de instrucciones
            '    miBatEjecucion = CreaArchivoConNombre(Comun.ClsTools.ParamtetrosSucursal.RutaArchivosTemporales(), "EXEC", miInstruccion, ".BAT")
            '    If miBatEjecucion = "" Then Return Nothing
            '    'Ejecutamos el bat de conexion
            '    If Not WorkAbout.ClsWorkAboutBase.DesImpersonaliza() Then Return Nothing

            '    Shell(miBatEjecucion, AppWinStyle.NormalFocus, True)
            '    'Eliminamos los archivos de trabajo
            '    'miInstruccion = miRuta & "DBCONV " & miRuta & prmNombreArchivo & ".DBF -m -o" & miRuta & prmNombreArchivo & ".ODB"
            '    'Shell(miInstruccion, AppWinStyle.NormalFocus, True)
            '    Tool.EsperarHastaEncontrarArchivo(miBatInstrucciones)
            '    Tool.EsperarHastaEncontrarArchivo(miBatEjecucion)
            '    File.Delete(miBatInstrucciones)
            '    File.Delete(miBatEjecucion)
            '    LeerArchivo = LeerArchivo(miRuta & prmNombreArchivo & ".ODB")
            '    File.Delete(miRuta & prmNombreArchivo & ".ODB")
            '    File.Delete(miRuta & prmNombreArchivo & ".DBF")
            'Return LeerArchivo
            'Catch ex As Exception
            '    MessageBox.Show("Error al intentar bajar desde WorkAbout :" & ex.Message, Comunes.Comun.ClsTools.GlobalSistemaCaption, MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End Try
            Return Nothing
        End Function

        'Lee el archivo desde la ubicacion especificada por el parametro
        Public Overridable Function LeerArchivo(ByVal prmUbicacionLecturaArchivo As String) As DataTable

            Try
                Dim vReader As New StreamReader(prmUbicacionLecturaArchivo)

                LeerArchivo = getFormatoTabla_O_TablaEscritura()
                If LeerArchivo Is Nothing Then Return Nothing


                Dim vLinea As String = vReader.ReadLine
                While Not vReader.EndOfStream
                    If Not vLinea Is Nothing AndAlso vLinea <> "" Then
                        Dim vRow As DataRow = LeerArchivo.NewRow
                        Dim vCampos() As String = vLinea.Split(getCaracterSeparadorCampos())
                        'If vCampos.Length > 8 Then
                        '    Console.Write("")
                        'End If
                        For x As Integer = 0 To vCampos.Length - 1
                            vRow(x) = DevuelveValorEnBaseTipo(LeerArchivo, vCampos(x), x)
                        Next
                        LeerArchivo.Rows.Add(vRow)
                    End If
                    vLinea = vReader.ReadLine
                End While

                vReader.Close()
                Return LeerArchivo
            Catch ex As Exception
                MessageBox.Show("Error al leer archivo plano: " & ex.Message, "WorkAbout", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return Nothing
            End Try
        End Function


        Public Overridable Function DameListadoArchivosEnDirectorio(ByVal prmRuta As String, ByVal prmExtension As String) As DataTable

            Try
                Dim vReader As New StreamReader(prmExtension)


                Dim vLinea As String = vReader.ReadLine
                While Not vLinea Is Nothing AndAlso vLinea <> ""
                    Dim vRow As DataRow = LeerArchivo.NewRow
                    Dim vCampos() As String = vLinea.Split(getCaracterSeparadorCampos())
                    For x As Integer = 0 To vCampos.Length - 1
                        vRow(x) = DevuelveValorEnBaseTipo(LeerArchivo, vCampos(x), x)
                    Next
                    LeerArchivo.Rows.Add(vRow)
                    vLinea = vReader.ReadLine
                End While

                vReader.Close()
                Return LeerArchivo()
            Catch ex As Exception
                MessageBox.Show("Error al leer archivo plano: " & ex.Message, "WorkAbout", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return Nothing
            End Try

        End Function


        'Lee el archivo desde la ubicacion especificada por el parametro
        Public Overridable Function LeerArchivoFijo(ByVal prmUbicacionLecturaArchivo As String) As DataTable
            Try
                Dim vReader As New StreamReader(prmUbicacionLecturaArchivo)

                LeerArchivoFijo = getFormatoTabla_O_TablaEscritura()
                If LeerArchivoFijo Is Nothing Then Return Nothing


                Dim miBuffer As String = vReader.ReadToEnd
                Dim miApuntador As Integer = 0
                Dim miRow As DataRow = Nothing
                While miApuntador < miBuffer.Length
                    miRow = LeerArchivoFijo.NewRow
                    For Each vColumn As DataColumn In LeerArchivoFijo.Columns
                        If Not (miApuntador + vColumn.MaxLength > miBuffer.Length) Then
                            miRow(vColumn) = miBuffer.Substring(miApuntador, vColumn.MaxLength)
                            miApuntador += vColumn.MaxLength
                        End If
                    Next
                    LeerArchivoFijo.Rows.Add(miRow)
                End While

                vReader.Close()
            Catch ex As Exception
                MessageBox.Show("Error de WorkAbout: " & ex.Message, "WorkAbout", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return Nothing
            End Try

        End Function

        Public Function DevuelveValorEnBaseTipo(ByVal prmTabla As DataTable, ByVal prmValor As String, ByVal prmIndex As Integer) As Object
            Dim vColumn As DataColumn = prmTabla.Columns(prmIndex)

            Select Case vColumn.DataType.Name
                Case "DateTime"
                    Return CType(prmValor, DateTime)
                Case "Boolean"
                    Return CType(prmValor, Boolean)
                Case "Byte"
                    Return CType(Comunes.Comun.ClsTools.IfVacio(prmValor, 0), Byte)
                Case "Int16"
                    Return CType(Comunes.Comun.ClsTools.IfVacio(prmValor, 0), Int16)
                Case "Int32"
                    Return CType(Comunes.Comun.ClsTools.IfVacio(prmValor, 0), Int32)
                Case "Int64"
                    Return CType(Comunes.Comun.ClsTools.IfVacio(prmValor, 0), Int64)
                Case "Decimal"
                    Return CType(Comunes.Comun.ClsTools.IfVacio(prmValor, 0), Decimal)
                Case "Single"
                    Return CType(Comunes.Comun.ClsTools.IfVacio(prmValor, 0), Single)
                Case "Double"
                    Return CType(Comunes.Comun.ClsTools.IfVacio(prmValor, 0), Double)

                Case Else
                    Return prmValor
            End Select
        End Function

        Public Function EsStringColumna(ByVal prmColumna As DataColumn) As Boolean
            Return prmColumna.DataType.Name = "String" OrElse _
                    prmColumna.DataType.Name = "DateTime" OrElse _
                    prmColumna.DataType.Name = "Object"
        End Function

        Public Function AgregaDelimitadores(ByVal prmValor As String, ByVal prmSecuenciaDelimitadora As String, ByVal prmUbicacion As EUbicacionesDeCaracteresControl) As String
            Select Case prmUbicacion
                Case EUbicacionesDeCaracteresControl.Inicio
                    Return prmSecuenciaDelimitadora & prmValor
                Case EUbicacionesDeCaracteresControl.Fin
                    Return prmValor & prmSecuenciaDelimitadora
                Case EUbicacionesDeCaracteresControl.InicioYFin
                    Return prmSecuenciaDelimitadora & prmValor & prmSecuenciaDelimitadora
                Case Else
                    Return ""
            End Select
        End Function

        Public Shared Function CreaArchivoConNombreDinamico(ByVal prmRuta As String, ByVal prmNombreArchivo As String, ByVal prmTexto As String, ByVal prmExtension As String) As String
            CreaArchivoConNombreDinamico = ""
            prmRuta &= IIf(prmRuta.EndsWith("\"), "", "\")
            prmExtension = IIf(prmExtension.StartsWith("."), "", ".") & prmExtension
            Dim miNombre As String = prmNombreArchivo & CStr(CLng(Microsoft.VisualBasic.Timer * 10000000))
            Return CreaArchivoConNombreDinamico(prmRuta, miNombre, prmTexto, prmExtension)

        End Function

        Public Shared Function CreaArchivoConNombre(ByVal prmRuta As String, ByVal prmNombreArchivo As String, ByVal prmTexto As String, ByVal prmExtension As String) As String
            CreaArchivoConNombre = ""
            prmRuta &= IIf(prmRuta.EndsWith("\"), "", "\")
            prmExtension = IIf(prmExtension.StartsWith("."), "", ".") & prmExtension
            Dim miNombre As String = prmNombreArchivo '& CStr(CLng(Microsoft.VisualBasic.Timer * 10000000))
            Dim miWriter As StreamWriter
            miNombre = prmRuta & miNombre & prmExtension
            Try
                If File.Exists(miNombre) Then
                    File.Delete(miNombre)
                End If

                If Not Directory.Exists(prmRuta) Then
                    Directory.CreateDirectory(prmRuta)
                End If

                If Directory.Exists(prmRuta) Then
                    miWriter = New StreamWriter(miNombre)
                    miWriter.Write(prmTexto)
                    miWriter.Close()
                    CreaArchivoConNombre = miNombre
                Else
                    CreaArchivoConNombre = ""
                End If

            Catch ex As Exception
                'MessageBox.Show("Error al crear el archivo " & miNombre & " :" & ex.Message, Comunes.Comun.ClsTools.GlobalSistemaCaption, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Function

        Public Shared Function DesImpersonaliza() As Boolean
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            If DAO.TieneTransaccionAbierta Then DAO.DeshaceTransaccion()
            'MessageBox.Show("Error al tratar de descargar de la WorkAbout, consulte al administrador del sistema", Comunes.Comun.ClsTools.GlobalSistemaCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
            'Este flush es para que deseche la cola de mensajes y evitar el problema de el cambio de pantalla activa
            SendKeys.Flush()
            Return True
        End Function

    End Class

    Public Enum EUbicacionesDeCaracteresControl
        Inicio = 1
        Fin = 2
        InicioYFin = 3
    End Enum

End Namespace

