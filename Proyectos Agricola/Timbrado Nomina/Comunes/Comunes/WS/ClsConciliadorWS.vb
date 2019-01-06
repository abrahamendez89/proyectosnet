Imports Access.Comunes.Comun
Imports System.Windows.Forms
Imports System.IO
Imports System.Web.HttpServerUtility
Imports System.Web
Imports Access
Imports ADSUM

Namespace Comunes.Comun.WS
    Public Class ClsConciliadorWS

#Region "Declaraciones"
        Public DAO As DataAccessCls
        Private Const atrOrden As String = "nOrden"
        Private Const atrOrdenPadre As String = "nOrdenPadre"
        Private Const atrTabla As String = "cTableName"
        Private Const atrSqlComplemento As String = "cConsulta"
        Private Const atrSql As String = "cConsultaReal"
        Private Const atrCampoLlave As String = "cCampoLlave"
        Private Const atrCampoLlaveControl As String = "cCampoLlaveTablaControl"
        Private Const atrCampoConciliar As String = "cCampoConciliar"
        Private Const atrDeleteHijos As String = "cDeleteHijos"
        Private Const atrSqlUpdateCampoControl As String = "cUpdateCampoControl"
        Private Const atrEliminarDatos As String = "bEliminarDatos"
        Private atrcPlazaEnvia As String = ""
        Private atrnPlazaEnvia As Int32 = 0
        Private atrcUrlEnvioConciliacion As String = ""
        Private atrDescripcionPlazaEnviar As String = ""
        Private atrNombreArchivoGenerado As String = ""
        Private atrContextos As String = ""
        Private atrnContexto As Integer = 0
        'Variables para enviar archivos WS
        Private atrEsCorporativo As Boolean = False
        Private atrMuestraMensajes As Boolean = False
        '
        Private atrRutaGenerarArchivoManual As String = ""

        Private gFrmWait As frmStatus
        Private atrNombreTablaControlParaXML As String = ""

        Private atrLog As EventLog

        Private atrAlmacenSucursal As Int32
        Private atrActualizaFechaExistencia As Boolean = False

        Public Property Almacen_de_Sucursal() As Int32
            Get
                Return atrAlmacenSucursal
            End Get
            Set(ByVal value As Int32)
                atrAlmacenSucursal = value
            End Set
        End Property
        Public Property ActualizaFechaExistencia() As Boolean
            Get
                Return atrActualizaFechaExistencia
            End Get
            Set(ByVal value As Boolean)
                atrActualizaFechaExistencia = value
            End Set
        End Property
        Public Enum EnviaWS
            Querys = 0
        End Enum
#End Region

#Region "Constructores"
        Public Sub New(ByVal prmContextos As String, ByVal prmClaveContexto As Int32, ByVal prmMostrarMensajes As Boolean)
            If Not prmMostrarMensajes Then
                DAO = DataAccessCls.DevuelveInstancia("ADSUMADK")
            Else
                DAO = DataAccessCls.DevuelveInstancia
            End If

            atrMuestraMensajes = prmMostrarMensajes
            atrContextos = prmContextos.Trim
            atrnContexto = prmClaveContexto
            gFrmWait = New frmStatus
            DAO.ParametroAdministradoAgregar("WS", "NOMBRE_COMPLEMENTO_TABLAS_ENVIO_WEBSERVICE", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parámetro para saber lo que se le tiene que concatenar al nombre de la tabla, ejemplo: INV_Pedidos, quedaría INV_Pedidos_Conciliacion", "_CONCILIACION")
            DAO.ParametroAdministradoAgregar("WS", "NOMBRE_CAMPO_ORIGEN_TABLAS_ENVIO_WEBSERVICE", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parámetro para saber como se llama el campo al que se envió la información, ejemplo: nPlazaEnviada ... se usa en el conciliador", "nPlazaEnviada")
            DAO.ParametroAdministradoAgregar("WS", "NOMBRE_RUTA_ARCHIVOSENVIAR_WEBSERVICE", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parámetro para conocer la ruta donde se crearán los archivos a enviar al webservice", "C:\\PruebaWS\\Envia\Temp")
            DAO.ParametroAdministradoAgregar("WS", "NOMBRE_RUTA_ARCHIVOSENVIADOS_WEBSERVICE", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parámetro para conocer la ruta donde se guardarán los archivos enviados al webservice", "C:\\PruebaWS\\Envia\TempEnviados")
            DAO.ParametroAdministradoAgregar("WS", "ENV_Directorio_Buzon_Envio", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parámetro para conocer el directorio donde se almacenarán los archivos recibidos por el ws", "C:\Inetpub\wwwroot\WSPanama\Temp\")
            DAO.ParametroAdministradoAgregar("WS", "NOMBRE_TABLACONTROL_PARA_ARCHIVO_XML_WEBSERVICE", DataAccessCls.TipoDeParametroAdministrado.Caracter, "parámetro para saber el nombre de la tabla control que viene en cada archivo XML, para conocer todas las tablas que contiene el XML", "MiDtControl")
            DAO.ParametroAdministradoAgregar("WS", "NOMBRE_TABLACONTROL_XML_WEBSERVICE", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parámetro para conocer el nombre de la tabla que contiene todos los nombres de los archivos XML que viene en el .ZIP y el Orden de ejecución", "MiXMLControl")
            DAO.ParametroAdministradoAgregar("WS", "ES_CORPORATIVO_DEMONIO_CONCILIAENVIA", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para conocer si es corporativo donde se esté enviando información", 1)
            atrcPlazaEnvia = DAO.ParametroAdministradoObtener("WS", "NOMBRE_CAMPO_ORIGEN_TABLAS_ENVIO_WEBSERVICE")
            atrEsCorporativo = (DAO.ParametroAdministradoObtener("WS", "ES_CORPORATIVO_DEMONIO_CONCILIAENVIA") = 1)
        End Sub
#End Region

#Region "Propiedades Read-Only"
        Public ReadOnly Property Orden() As String
            Get
                Return atrOrden
            End Get
        End Property
        Public ReadOnly Property OrdenPadre() As String
            Get
                Return atrOrdenPadre
            End Get
        End Property
        Public ReadOnly Property Tabla() As String
            Get
                Return atrTabla
            End Get
        End Property
        Public ReadOnly Property SqlComplemento() As String
            Get
                Return atrSqlComplemento
            End Get
        End Property
        Public ReadOnly Property Sql() As String
            Get
                Return atrSql
            End Get
        End Property
        Public ReadOnly Property CampoLlave() As String
            Get
                Return atrCampoLlave
            End Get
        End Property
        Public ReadOnly Property CampoLlaveControl() As String
            Get
                Return atrCampoLlaveControl
            End Get
        End Property
        Public ReadOnly Property CampoConciliar() As String
            Get
                Return atrCampoConciliar
            End Get
        End Property
        Public ReadOnly Property SqlUpdateCampoControl() As String
            Get
                Return atrSqlUpdateCampoControl
            End Get
        End Property
        Public ReadOnly Property SqlDeleteHijos() As String
            Get
                Return atrDeleteHijos
            End Get
        End Property
        Public ReadOnly Property EliminarDatos() As String
            Get
                Return atrEliminarDatos
            End Get
        End Property
        Public ReadOnly Property PlazaEnvia_C() As String
            Get
                Return atrcPlazaEnvia
            End Get
        End Property
        Public ReadOnly Property PlazaEnvia_N() As String
            Get
                Return atrnPlazaEnvia
            End Get
        End Property
        Public ReadOnly Property Url() As String
            Get
                Return atrcUrlEnvioConciliacion
            End Get
        End Property
        Public ReadOnly Property DescripcionPlazaEnviar() As String
            Get
                Return atrDescripcionPlazaEnviar
            End Get
        End Property
        Public ReadOnly Property MensajePlazaEnviar() As String
            Get
                Return "Plaza a enviar: " & DescripcionPlazaEnviar & vbCr
            End Get
        End Property
        Public ReadOnly Property MensajePlazaConciliar() As String
            Get
                Return "Plaza a conciliar: " & DescripcionPlazaEnviar & vbCr
            End Get
        End Property
        Public ReadOnly Property NombreArchivoEnviado() As String
            Get
                Return atrNombreArchivoGenerado.Trim
            End Get
        End Property
        Public ReadOnly Property Corporativo() As Boolean
            Get
                Return atrEsCorporativo
            End Get
        End Property
#End Region
#Region "Propiedades Get and Set"
        Public Property Log() As EventLog
            Get
                Return atrLog
            End Get
            Set(ByVal value As EventLog)
                atrLog = value
            End Set
        End Property

        Public Property RutaGenerarArchivoManual() As String
            Get
                Return atrRutaGenerarArchivoManual
            End Get
            Set(ByVal value As String)
                atrRutaGenerarArchivoManual = value
            End Set
        End Property
#End Region

#Region "Funciones Públicas"
        ' ''Private Function Envia() As Boolean
        ' ''    Dim vcRutaEnviarGlobal As String = ""
        ' ''    Try
        ' ''        'Variable para almacenar el nombre del archivo generado, y pasarlo al Demonio para que lo escriba en el Log.
        ' ''        atrNombreArchivoGenerado = ""

        ' ''        Dim vcRutaEnviar As String = DAO.ParametroAdministradoObtener("WS", "NOMBRE_RUTA_ARCHIVOSENVIAR_WEBSERVICE") '& (New Random().Next(100000000)).ToString()
        ' ''        Dim vcRutaRespaldoEnviados As String = DAO.ParametroAdministradoObtener("WS", "NOMBRE_RUTA_ARCHIVOSENVIADOS_WEBSERVICE")
        ' ''        vcRutaEnviar &= New Random().Next(100000000).ToString()
        ' ''        'vcRutaRespaldoEnviados &= New Random().Next(100000000).ToString()

        ' ''        Dim vcNombreZip As String = ""
        ' ''        vcRutaEnviarGlobal = vcRutaEnviar

        ' ''        '1.-Obtenemos la relacion de tablas a conciliar y se forman los querys para cada una de ellas, los cuales se enviarán al WS.
        ' ''        Dim vDsTablasEnviarWS As New DataSet
        ' ''        Dim vSQL As New ArrayList
        ' ''        Dim TABLAS As New ArrayList

        ' ''        'Configura las tablas manejadas por el WS
        ' ''        PlMensajeEstatusMostrar(MensajePlazaEnviar & "Obteniendo Configuración de Tablas e Información")
        ' ''        If Not FlObtieneConfiguracionTablas(vDsTablasEnviarWS, vSQL, TABLAS) Then
        ' ''            PlMensajeEstatusOcultar()
        ' ''            Return False
        ' ''        End If
        ' ''        PlMensajeEstatusOcultar()


        ' ''        If vDsTablasEnviarWS Is Nothing OrElse vDsTablasEnviarWS.Tables.Count = 0 OrElse vDsTablasEnviarWS.Tables(0).Rows.Count = 0 Then
        ' ''            'Si el que envía es una sucursal y el contexto a enviar es EXISTENCIAS,
        ' ''            'se actualiza la fecha de ultimo envio en corporativo aunque no haya nada pendiente por enviar.
        ' ''            If Not atrAlmacenSucursal = 0 Then
        ' ''                If atrnContexto = DAO.ParametroAdministradoObtener("PRMSUC", "CONTEXTO_ENVIO_EXISTENCIAS") Then
        ' ''                    PlMensajeEstatusMostrar(MensajePlazaEnviar & "Act. Fecha Envío")
        ' ''                    Dim miWsActualizaFecha As WSRecepcionArchivo.RecepcionArchivo
        ' ''                    miWsActualizaFecha = DevuelveWSRecepcion()
        ' ''                    miWsActualizaFecha.ActualizaFechaExistencias(atrAlmacenSucursal)
        ' ''                    PlMensajeEstatusOcultar()
        ' ''                End If
        ' ''            End If
        ' ''            PlMensajeMostrar("No hay información para enviar", MessageBoxIcon.Information)
        ' ''            Return True
        ' ''        End If

        ' ''        '2.- Creamos el directorio donde se almacenarán los archivos XML
        ' ''        If IO.Directory.Exists(vcRutaEnviar) Then
        ' ''            IO.Directory.Delete(vcRutaEnviar, True)
        ' ''        End If
        ' ''        Dim miInfoEnviar As System.IO.DirectoryInfo
        ' ''        Dim miInfoEnviados As System.IO.DirectoryInfo
        ' ''        miInfoEnviar = System.IO.Directory.CreateDirectory(vcRutaEnviar)
        ' ''        miInfoEnviados = System.IO.Directory.CreateDirectory(vcRutaRespaldoEnviados)

        ' ''        If Not miInfoEnviar.Exists() Then miInfoEnviar.Create()
        ' ''        If Not miInfoEnviar.Exists Then Return False
        ' ''        If Not miInfoEnviados.Exists Then miInfoEnviados.Create()
        ' ''        If Not miInfoEnviados.Exists Then Return False

        ' ''        '2.-Generamos los archivos XML e insertamos en CTL_AdministracionArchivosWS 
        ' ''        PlMensajeEstatusMostrar(MensajePlazaEnviar & "Generando archivos XML " & vbCr & "para enviar a la plaza " & DescripcionPlazaEnviar)
        ' ''        If Not FlGeneraArchivosXMLEnviar(vcRutaEnviar & "\", vDsTablasEnviarWS, vSQL, TABLAS) Then
        ' ''            EliminaDirectorio(vcRutaEnviar)
        ' ''            PlMensajeEstatusOcultar()
        ' ''            Return False
        ' ''        End If
        ' ''        PlMensajeEstatusOcultar()

        ' ''        '3.-Zipeamos los archivos generados para enviarlos al WS
        ' ''        PlMensajeEstatusMostrar(MensajePlazaEnviar & "Comprimiendo Archivos")
        ' ''        Dim miZip As ZipUtil = New ZipUtil
        ' ''        vcNombreZip = FlRegresaNombreXMLEnviar()
        ' ''        'Si es vacío el nombre, existe error al generar el nombre del archivo
        ' ''        If vcNombreZip.Trim = "" Then
        ' ''            EliminaDirectorio(vcRutaEnviar)
        ' ''            PlMensajeEstatusOcultar()
        ' ''            Return False
        ' ''        End If
        ' ''        miZip.Comprimir(vcRutaEnviar, "*.XML", vcRutaEnviar & System.IO.Path.DirectorySeparatorChar & vcNombreZip, False)
        ' ''        PlMensajeEstatusOcultar()

        ' ''        If RutaGenerarArchivoManual <> "" Then
        ' ''            If Not IO.Directory.Exists(IO.Path.GetDirectoryName(RutaGenerarArchivoManual)) Then
        ' ''                IO.Directory.CreateDirectory(IO.Path.GetDirectoryName(RutaGenerarArchivoManual))
        ' ''            End If
        ' ''            IO.File.Copy(vcRutaEnviar & System.IO.Path.DirectorySeparatorChar & vcNombreZip, IO.Path.GetDirectoryName(RutaGenerarArchivoManual) & System.IO.Path.DirectorySeparatorChar & vcNombreZip, True)
        ' ''        End If

        ' ''        If RutaGenerarArchivoManual = "" Then
        ' ''            '4.-Enviamos el archivo .Zip al WS
        ' ''            PlMensajeEstatusMostrar(MensajePlazaEnviar & "Enviando Archivo")
        ' ''        End If

        ' ''        Dim wsRecepcion As WSRecepcionArchivo.RecepcionArchivo
        ' ''        Dim miArchivo() As Byte
        ' ''        wsRecepcion = DevuelveWSRecepcion()
        ' ''        miArchivo = IO.File.ReadAllBytes(vcRutaEnviar & "\" & vcNombreZip)

        ' ''        ''Calculamos el tamaño del archivo, para guardar su tamaño en la tabla de archivos enviados
        ' ''        Dim vnTamañoArchivo As Decimal = ClsTools.getSizeFileMB(miArchivo)
        ' ''        If Not DAO.TieneTransaccionAbierta Then DAO.AbreTransaccion()
        ' ''        If Not WS.ClsAdministracionArchivosWS.ActualizaTamañoArchivo(vcNombreZip, vnTamañoArchivo) Then
        ' ''            If DAO.TieneTransaccionAbierta Then DAO.DeshaceTransaccion()
        ' ''        End If
        ' ''        If DAO.TieneTransaccionAbierta Then DAO.CierraTransaccion()


        ' ''        Dim vbWSRecibioInformacion As Boolean = False
        ' ''        Dim vcError As String = ""


        ' ''        'Asigna el nombre del archivo generado para devolverlo al demonio.
        ' ''        atrNombreArchivoGenerado = vcNombreZip.Trim

        ' ''        If RutaGenerarArchivoManual = "" Then
        ' ''            If wsRecepcion.RecepcionArchivos(vcNombreZip, miArchivo, Almacen_de_Sucursal) Then
        ' ''                '                    If wsRecepcion.RecepcionArchivos(vcNombreZip, miArchivo, vcError) Then
        ' ''                vbWSRecibioInformacion = True
        ' ''                WS.ClsAdministracionArchivosWS.ActualizaEnviado(vcNombreZip.Trim, True)
        ' ''                System.IO.File.Copy(vcRutaEnviar & "\" & vcNombreZip, vcRutaRespaldoEnviados & "\" & vcNombreZip)
        ' ''            End If

        ' ''            '5.-Eliminamos el directorio temporal
        ' ''            EliminaDirectorio(vcRutaEnviar)
        ' ''            'System.IO.Directory.Delete(vcRutaEnviar, True)
        ' ''        End If

        ' ''        PlMensajeEstatusOcultar()

        ' ''        If RutaGenerarArchivoManual = "" Then
        ' ''            If vbWSRecibioInformacion Then
        ' ''                PlMensajeMostrar(MensajePlazaEnviar & "Datos enviados con éxito", MessageBoxIcon.Information)
        ' ''            Else
        ' ''                PlMensajeMostrar(MensajePlazaEnviar & "Los datos no se enviaron", MessageBoxIcon.Exclamation)
        ' ''                EliminaDirectorio(vcRutaEnviar)
        ' ''                Return False
        ' ''            End If
        ' ''        Else
        ' ''            PlMensajeMostrar(MensajePlazaEnviar & "Archivo " & IO.Path.GetDirectoryName(RutaGenerarArchivoManual) & System.IO.Path.DirectorySeparatorChar & vcNombreZip & " generado con éxito", MessageBoxIcon.Information)
        ' ''        End If

        ' ''        EliminaDirectorio(vcRutaEnviar)

        ' ''        Return True
        ' ''    Catch ex As Exception
        ' ''        EliminaDirectorio(vcRutaEnviarGlobal)
        ' ''        PlMensajeMostrar(ex.Message.ToString, MessageBoxIcon.Error)
        ' ''        PlMensajeEstatusOcultar()
        ' ''        If Not Log Is Nothing Then
        ' ''            ClsTools.GrabaMensajeLog(Log, "Error ClsConciliadorWS Envia: " & DAO.RegresaFechaDelSistema & " " & ex.Source & " " & ex.Message.ToString, EventLogEntryType.Error)
        ' ''        End If
        ' ''        Return False
        ' ''    End Try
        ' ''End Function
        Private Sub EliminaDirectorio(ByVal prmRuta As String)
            Try
                If System.IO.Directory.Exists(prmRuta) Then
                    System.IO.Directory.Delete(prmRuta, True)
                End If
            Catch ex As Exception

            End Try
        End Sub
        ' ''Private Function Concilia() As Boolean
        ' ''    Try

        ' ''        '**********CONCILIADOR**********
        ' ''        '1.-Obtenemos la relacion de tablas a conciliar y se forman los querys para cada una de ellas, los cuales se enviarán al WS.
        ' ''        '2.-Enviamos al WS los querys formados para que realize esas consultas y nos devuelva la información obtenida.
        ' ''        '3.-Ejecutamos los querys formados para obtener la información (LOCAL) y poder conciliarla contra lo que regresó el WS.
        ' ''        '4.-Conciliamos la información Local Contra la Recibida del WS.
        ' ''        '        Se comparan los registros padres y los registros hijos.
        ' ''        DAO = DataAccessCls.DevuelveInstancia

        ' ''        '1.-Obtenemos la relacion de tablas a conciliar y se forman los querys para cada una de ellas, los cuales se enviarán al WS.
        ' ''        Dim vDsTablasEnviarWS As New DataSet

        ' ''        Dim vSQL As New ArrayList
        ' ''        Dim TABLAS As New ArrayList

        ' ''        'Configura las tablas manejadas por el WS
        ' ''        PlMensajeEstatusMostrar(MensajePlazaConciliar & "Obteniendo Configuración de Tablas e Información")
        ' ''        If Not FlObtieneConfiguracionTablas(vDsTablasEnviarWS, vSQL, TABLAS) Then
        ' ''            PlMensajeEstatusOcultar()
        ' ''            Return False
        ' ''        End If

        ' ''        If vDsTablasEnviarWS Is Nothing OrElse vDsTablasEnviarWS.Tables.Count = 0 OrElse vDsTablasEnviarWS.Tables(0).Rows.Count = 0 Then
        ' ''            PlMensajeMostrar("No hay información para conciliar", MessageBoxIcon.Information)
        ' ''            'If Not Log Is Nothing Then
        ' ''            '    Log.WriteEntry("ClsConciliadorWS Concilia: No hay información para conciliar " & DAO.RegresaFechaDelSistema, EventLogEntryType.Information)
        ' ''            'End If
        ' ''            PlMensajeEstatusOcultar()
        ' ''            Return True
        ' ''        End If


        ' ''        '2.-Enviamos al WS los querys formados para que realize esas consultas y nos devuelva la información obtenida.
        ' ''        PlMensajeEstatusMostrar(MensajePlazaConciliar & "Solicitando información")
        ' ''        Dim wsRecepcion As WSRecepcionArchivo.RecepcionArchivo
        ' ''        wsRecepcion = DevuelveWSRecepcion()
        ' ''        Dim vDsActualizaciones As New DataSet
        ' ''        Dim arch As Byte()
        ' ''        arch = wsRecepcion.RegresarConsulta(vSQL.ToArray(Type.GetType("System.String")))
        ' ''        PlMensajeEstatusOcultar()



        ' ''        If Not arch Is Nothing Then
        ' ''            Dim vcRutaEnviar As String = DAO.ParametroAdministradoObtener("WS", "NOMBRE_RUTA_ARCHIVOSENVIAR_WEBSERVICE") '& (New Random().Next(100000000)).ToString()
        ' ''            Dim vcRutaRespaldoEnviados As String = DAO.ParametroAdministradoObtener("WS", "NOMBRE_RUTA_ARCHIVOSENVIADOS_WEBSERVICE")
        ' ''            vcRutaEnviar &= New Random().Next(100000000).ToString()
        ' ''            'vcRutaRespaldoEnviados &= New Random().Next(100000000).ToString()

        ' ''            'Creamos el directorio por si no existe
        ' ''            '2.- Creamos el directorio donde se almacenarán los archivos XML
        ' ''            If IO.Directory.Exists(vcRutaEnviar) Then
        ' ''                IO.Directory.Delete(vcRutaEnviar, True)
        ' ''            End If
        ' ''            Dim miInfoEnviar As System.IO.DirectoryInfo
        ' ''            Dim miInfoEnviados As System.IO.DirectoryInfo
        ' ''            miInfoEnviar = System.IO.Directory.CreateDirectory(vcRutaEnviar)
        ' ''            miInfoEnviados = System.IO.Directory.CreateDirectory(vcRutaRespaldoEnviados)

        ' ''            If Not miInfoEnviar.Exists() Then miInfoEnviar.Create()
        ' ''            If Not miInfoEnviar.Exists Then Return False
        ' ''            If Not miInfoEnviados.Exists Then miInfoEnviados.Create()
        ' ''            If Not miInfoEnviados.Exists Then Return False
        ' ''            '

        ' ''            PlMensajeEstatusMostrar(MensajePlazaConciliar & "Descomprimiendo la información recibida")
        ' ''            Dim ruta As String = vcRutaEnviar
        ' ''            Dim archivo As New FileStream(ruta & "\concilia.zip", FileMode.Create)
        ' ''            archivo.Write(arch, 0, arch.Length)
        ' ''            archivo.Close()
        ' ''            Dim miInfo As DirectoryInfo = Directory.CreateDirectory(ruta & "\conciliatemp")
        ' ''            If miInfo.Exists Then
        ' ''                Dim miZip As ZipUtil = New ZipUtil
        ' ''                Dim misEntries() As ICSharpCode.SharpZipLib.Zip.ZipEntry = miZip.Contenido(ruta & "\concilia.zip")
        ' ''                miZip.Descomprimir(ruta & "\conciliatemp", ruta & "\concilia.zip", True, False)
        ' ''                'Recorremos para llenar los datos
        ' ''                For Each miEntry As ICSharpCode.SharpZipLib.Zip.ZipEntry In misEntries
        ' ''                    vDsActualizaciones.ReadXml(ruta & "\conciliatemp" & "\" & System.IO.Path.GetFileName(miEntry.Name), XmlReadMode.ReadSchema)
        ' ''                    vDsActualizaciones.Tables(vDsActualizaciones.Tables.Count - 1).TableName = System.IO.Path.GetFileName(miEntry.Name).Replace(".xml", "")
        ' ''                Next
        ' ''                Directory.Delete(miInfo.FullName, True)
        ' ''            End If
        ' ''            PlMensajeEstatusOcultar()
        ' ''            EliminaDirectorio(vcRutaEnviar)
        ' ''        End If

        ' ''        If arch Is Nothing Then

        ' ''            PlMensajeMostrar(MensajePlazaConciliar & "La información no ha sido recibida", MessageBoxIcon.Exclamation)
        ' ''            'If Not Log Is Nothing Then
        ' ''            '    Log.WriteEntry("ClsConciliadorWS Concilia: La información no ha sido recibida" & DAO.RegresaFechaDelSistema, EventLogEntryType.Error)
        ' ''            'End If
        ' ''            Return True
        ' ''        End If


        ' ''        '3.-Ejecutamos los querys formados para obtener la información (LOCAL) y poder conciliarla contra lo que regresó el WS.
        ' ''        'Formamos el DataSet Local con la información enviada
        ' ''        PlMensajeEstatusMostrar(MensajePlazaConciliar & "Obteniendo información local para conciliar")
        ' ''        Dim vDsInfoLocal As New DataSet
        ' ''        vDsInfoLocal = FlObtieneDatosLocal(vSQL)
        ' ''        PlMensajeEstatusOcultar()

        ' ''        'Asignamos los nombres correctos a las tablas recibidas del WS
        ' ''        For Each dt As DataTable In vDsActualizaciones.Tables
        ' ''            Dim vcTabla As String = ""
        ' ''            Dim vnPosicion As Int32 = 0
        ' ''            vcTabla = dt.TableName
        ' ''            vnPosicion = InStr(vcTabla, " ")
        ' ''            vcTabla = vcTabla.Substring(0, vnPosicion)
        ' ''            dt.TableName = vcTabla.Trim
        ' ''        Next
        ' ''        'Asignamos los nombres correctos a las tablas locales 
        ' ''        For i As Int32 = 0 To vDsInfoLocal.Tables.Count - 1
        ' ''            vDsInfoLocal.Tables(i).TableName = TABLAS.Item(i)
        ' ''        Next

        ' ''        For Each table As DataTable In vDsInfoLocal.Tables
        ' ''            Comunes.Comun.WS.ClsConciliadorWS.RegresaPrimaryKeys(table)
        ' ''        Next
        ' ''        For Each table As DataTable In vDsActualizaciones.Tables
        ' ''            Comunes.Comun.WS.ClsConciliadorWS.RegresaPrimaryKeys(table)
        ' ''        Next

        ' ''        '4.-Conciliamos la información Local Contra la Recibida del WS.
        ' ''        Dim vbValidaCorrecto As Boolean = False
        ' ''        Dim vColRowPadreLocal() As DataRow
        ' ''        Dim vColRowHijo() As DataRow
        ' ''        Dim vcUpdate As String = ""
        ' ''        Dim vcTablaPadre As String = ""
        ' ''        Dim vTablasHijos As New ArrayList
        ' ''        Dim vCamposConciliarHijos As New ArrayList
        ' ''        Dim vcFiltro As String = ""
        ' ''        vSQL = New ArrayList


        ' ''        'Dim vnIndex As Int32 = 0
        ' ''        'For Each dr As DataRow In vDsTablasEnviarWS.Tables(0).Select("", "nOrden ASC")
        ' ''        '    vDsInfoLocal.Tables(vnIndex).TableName = dr("cTableName")
        ' ''        '    Comunes.Comun.WS.ClsConciliadorWS.RegresaPrimaryKeys(vDsInfoLocal.Tables(vnIndex))
        ' ''        '    vnIndex += 1
        ' ''        'Next

        ' ''        'Recorremos Todas las tablas 
        ' ''        For Each drTabla As DataRow In vDsTablasEnviarWS.Tables(EnviaWS.Querys).Select("NOT " & SqlComplemento & " IS NULL", Orden)
        ' ''            'Inicializa variables de nombre de tabla
        ' ''            vcTablaPadre = ""
        ' ''            vcTablaPadre = drTabla(Tabla)

        ' ''            vColRowHijo = vDsTablasEnviarWS.Tables(EnviaWS.Querys).Select(OrdenPadre & " = " & drTabla(Orden))

        ' ''            PlMensajeEstatusMostrar(MensajePlazaConciliar & "Conciliando información de " & vcTablaPadre.Trim)

        ' ''            'Recorremos todos los registros padres
        ' ''            For Each drPadreWS As DataRow In vDsActualizaciones.Tables(vcTablaPadre).Rows
        ' ''                'Validaciones del registro padre
        ' ''                vbValidaCorrecto = True
        ' ''                vcFiltro = FlRegresaFiltroSelect(drTabla(Sql), drPadreWS)
        ' ''                vColRowPadreLocal = vDsInfoLocal.Tables(vcTablaPadre).Select(vcFiltro)

        ' ''                If vColRowPadreLocal.Length = 0 Then Continue For

        ' ''                If Not FlValidaCamposPadre(vColRowPadreLocal(0), drPadreWS, drTabla(CampoConciliar)) Then Continue For

        ' ''                'Validaciones de los hijos
        ' ''                For Each drHijo As DataRow In vColRowHijo
        ' ''                    Dim vcTabla As String = drHijo(Tabla).ToString
        ' ''                    Dim vcOrdenamiento As String = ""
        ' ''                    If vDsInfoLocal.Tables(vcTabla).PrimaryKey.Length > 0 Then
        ' ''                        For Each dcol As DataColumn In vDsInfoLocal.Tables(vcTabla).PrimaryKey
        ' ''                            vcOrdenamiento &= dcol.ColumnName & ","
        ' ''                        Next
        ' ''                        If Not vcOrdenamiento.Trim = "" Then vcOrdenamiento = vcOrdenamiento.Trim.Substring(0, vcOrdenamiento.Trim.Length - 1)
        ' ''                    End If
        ' ''                    If Not FlValidaCamposHijo(vDsInfoLocal.Tables(vcTabla).Select(vcFiltro, vcOrdenamiento), vDsActualizaciones.Tables(vcTabla).Select(vcFiltro, vcOrdenamiento), drHijo) Then
        ' ''                        vbValidaCorrecto = False
        ' ''                    End If
        ' ''                Next

        ' ''                'Si no validó correctamente pasa al siguiente registro
        ' ''                If Not vbValidaCorrecto Then Continue For
        ' ''                'Forma la sentencia Update para actualizar su campo control
        ' ''                vSQL.Add(String.Format(drTabla(SqlUpdateCampoControl), FlRegresaWhereParaUpdateCampoControl(drPadreWS, drTabla(CampoLlaveControl))))
        ' ''            Next
        ' ''            PlMensajeEstatusOcultar()
        ' ''        Next

        ' ''        'If Not Log Is Nothing Then
        ' ''        '    Log.WriteEntry("ClsConciliadorWS Concilia: Total de Registros a actualizar como conciliados " & vSQL.Count & " " & DAO.RegresaFechaDelSistema, EventLogEntryType.Information)
        ' ''        'End If

        ' ''        If vSQL.Count > 0 Then
        ' ''            PlMensajeEstatusMostrar(MensajePlazaConciliar & "Marcando información conciliada")
        ' ''            For Each sInstruccion As String In vSQL
        ' ''                If Not DAO.EjecutaComandoSQL(sInstruccion) Then
        ' ''                    PlMensajeMostrar(MensajePlazaConciliar & "Error al marcar el registro..." & vbCr & sInstruccion, MessageBoxIcon.Error)
        ' ''                    PlMensajeEstatusOcultar()
        ' ''                    Return False
        ' ''                End If
        ' ''            Next
        ' ''            PlMensajeEstatusOcultar()
        ' ''        End If

        ' ''        Return True

        ' ''    Catch ex As Exception
        ' ''        PlMensajeMostrar(ex.Message.ToString, MessageBoxIcon.Error)
        ' ''        PlMensajeEstatusOcultar()
        ' ''        If Not Log Is Nothing Then
        ' ''            ClsTools.GrabaMensajeLog(Log, "Error ClsConciliadorWS Concilia: " & DAO.RegresaFechaDelSistema & " " & ex.Source & " " & ex.Message.ToString, EventLogEntryType.Error)
        ' ''        End If
        ' ''        Return False
        ' ''    End Try
        ' ''End Function
        ' ''Public Function EnviarInformación(Optional ByVal prmSoloConcilia As Boolean = False, Optional ByVal prmSoloEnvia As Boolean = False) As Boolean
        ' ''    Try


        ' ''        Dim vDtPlazasEnviar As New DataTable
        ' ''        DAO.RegresaConsultaSQL("SELECT * FROM CTL_PlazasEnviarInformacionWS (NOLOCK) WHERE bActivo = 1", vDtPlazasEnviar)
        ' ''        If vDtPlazasEnviar Is Nothing OrElse vDtPlazasEnviar.Rows.Count = 0 Then
        ' ''            PlMensajeMostrar("No hay plazas configuradas", MessageBoxIcon.Exclamation)
        ' ''            If Not Log Is Nothing Then
        ' ''                ClsTools.GrabaMensajeLog(Log, "Error ClsConciliadorWS EnviarInformacion: No hay plazas configuradas " & DAO.RegresaFechaDelSistema, EventLogEntryType.Error)
        ' ''            End If
        ' ''            Return False
        ' ''        End If


        ' ''        For Each dRow As DataRow In vDtPlazasEnviar.Rows
        ' ''            atrnPlazaEnvia = dRow("nPlaza")
        ' ''            atrcUrlEnvioConciliacion = dRow("cUrl")
        ' ''            atrDescripcionPlazaEnviar = DAO.RegresaDatoSQL("SELECT cDescripcion FROM CTL_Plazas (NOLOCK) WHERE nPlaza = " & atrnPlazaEnvia)
        ' ''            If atrDescripcionPlazaEnviar Is Nothing Then atrDescripcionPlazaEnviar = ""

        ' ''            If prmSoloEnvia Then
        ' ''                If Me.Envia Then
        ' ''                    Return True
        ' ''                End If
        ' ''                Return False
        ' ''            End If

        ' ''            If Me.Concilia Then
        ' ''                If prmSoloConcilia Then
        ' ''                    PlMensajeMostrar(MensajePlazaConciliar & "Los datos han sido conciliados", MessageBoxIcon.Information)
        ' ''                    Return True
        ' ''                End If
        ' ''                If Me.Envia() Then
        ' ''                    Return True
        ' ''                End If
        ' ''            End If
        ' ''        Next
        ' ''    Catch ex As Exception
        ' ''        PlMensajeMostrar(ex.Message.ToString, MessageBoxIcon.Error)
        ' ''        PlMensajeEstatusOcultar()
        ' ''        If Not Log Is Nothing Then
        ' ''            ClsTools.GrabaMensajeLog(Log, "Error ClsConciliadorWS: " & DAO.RegresaFechaDelSistema & " " & ex.Source & " " & ex.Message.ToString, EventLogEntryType.Error)
        ' ''        End If
        ' ''        Return False
        ' ''    End Try

        ' ''End Function
        Public Function ObtenInformacion_para_Sucursal(ByRef prmProcesoCorrecto As Boolean) As Byte()
            Dim vcRutaEnviarGlobal As String = ""
            Try
                prmProcesoCorrecto = False
                'Variable para almacenar el nombre del archivo generado, y pasarlo al Demonio para que lo escriba en el Log.
                atrNombreArchivoGenerado = ""

                Dim vcRutaEnviar As String = DAO.ParametroAdministradoObtener("WS", "NOMBRE_RUTA_ARCHIVOSENVIAR_WEBSERVICE") '& (New Random().Next(100000000)).ToString()
                Dim vcRutaRespaldoEnviados As String = DAO.ParametroAdministradoObtener("WS", "NOMBRE_RUTA_ARCHIVOSENVIADOS_WEBSERVICE")
                Dim vcNombreZip As String = ""

                vcRutaEnviar &= New Random().Next(100000000).ToString()
                'vcRutaRespaldoEnviados &= New Random().Next(100000000).ToString()

                vcRutaEnviarGlobal = vcRutaEnviar

                '1.-Obtenemos la relacion de tablas a conciliar y se forman los querys para cada una de ellas, los cuales se enviarán al WS.
                Dim vDsTablasEnviarWS As New DataSet
                Dim vSQL As New ArrayList
                Dim TABLAS As New ArrayList

                'Configura las tablas manejadas por el WS
                PlMensajeEstatusMostrar(MensajePlazaEnviar & "Obteniendo Configuración de Tablas e Información")
                If Not FlObtieneConfiguracionTablas_Sucursal(vDsTablasEnviarWS, vSQL, TABLAS) Then
                    PlMensajeEstatusOcultar()
                    Return Nothing
                End If
                PlMensajeEstatusOcultar()


                If vDsTablasEnviarWS Is Nothing OrElse vDsTablasEnviarWS.Tables.Count = 0 OrElse vDsTablasEnviarWS.Tables(0).Rows.Count = 0 Then
                    If Not vDsTablasEnviarWS Is Nothing Then
                        prmProcesoCorrecto = True
                    End If
                    PlMensajeMostrar("No hay información para enviar", MessageBoxIcon.Information)
                    Return Nothing
                End If

                '2.- Creamos el directorio donde se almacenarán los archivos XML
                If IO.Directory.Exists(vcRutaEnviar) Then
                    IO.Directory.Delete(vcRutaEnviar, True)
                End If

                Dim miInfoEnviar As System.IO.DirectoryInfo
                Dim miInfoEnviados As System.IO.DirectoryInfo
                miInfoEnviar = System.IO.Directory.CreateDirectory(vcRutaEnviar)
                miInfoEnviados = System.IO.Directory.CreateDirectory(vcRutaRespaldoEnviados)

                If Not miInfoEnviar.Exists() Then miInfoEnviar.Create()
                If Not miInfoEnviar.Exists Then Return Nothing
                If Not miInfoEnviados.Exists Then miInfoEnviados.Create()
                If Not miInfoEnviados.Exists Then Return Nothing

                '2.-Generamos los archivos XML e insertamos en CTL_AdministracionArchivosWS 
                PlMensajeEstatusMostrar(MensajePlazaEnviar & "Generando archivos XML " & vbCr & "para enviar a la plaza " & DescripcionPlazaEnviar)
                If Not FlGeneraArchivosXMLEnviar_Sucursal(vcRutaEnviar & "\", vDsTablasEnviarWS, vSQL, TABLAS, prmProcesoCorrecto) Then
                    EliminaDirectorio(vcRutaEnviar)
                    PlMensajeEstatusOcultar()
                    'prmProcesoCorrecto = True
                    Return Nothing
                End If
                PlMensajeEstatusOcultar()

                '3.-Zipeamos los archivos generados para enviarlos al WS
                PlMensajeEstatusMostrar(MensajePlazaEnviar & "Comprimiendo Archivos")
                Dim miZip As ZipUtil = New ZipUtil
                vcNombreZip = "INFORMACION.ZIP"

                If RutaGenerarArchivoManual <> "" Then
                    vcNombreZip = IO.Path.GetFileName(RutaGenerarArchivoManual) & "_MANUAL.ZIP"
                End If

                'Si es vacío el nombre, existe error al generar el nombre del archivo
                If vcNombreZip.Trim = "" Then
                    EliminaDirectorio(vcRutaEnviar)
                    PlMensajeEstatusOcultar()
                    Return Nothing
                End If
                miZip.Comprimir(vcRutaEnviar, "*.XML", vcRutaEnviar & System.IO.Path.DirectorySeparatorChar & vcNombreZip, False)
                PlMensajeEstatusOcultar()

                If Not RutaGenerarArchivoManual = "" Then
                    If Not IO.Directory.Exists(IO.Path.GetDirectoryName(RutaGenerarArchivoManual)) Then
                        IO.Directory.CreateDirectory(IO.Path.GetDirectoryName(RutaGenerarArchivoManual))
                    End If
                    IO.File.Copy(vcRutaEnviar & System.IO.Path.DirectorySeparatorChar & vcNombreZip, IO.Path.GetDirectoryName(RutaGenerarArchivoManual) & System.IO.Path.DirectorySeparatorChar & vcNombreZip, True)
                    prmProcesoCorrecto = True
                    PlMensajeMostrar(MensajePlazaEnviar & "Archivo " & IO.Path.GetDirectoryName(RutaGenerarArchivoManual) & System.IO.Path.DirectorySeparatorChar & vcNombreZip & " generado con éxito", MessageBoxIcon.Information)
                    Return Nothing
                End If

                Dim miArchivo() As Byte
                miArchivo = IO.File.ReadAllBytes(vcRutaEnviar & "\" & vcNombreZip)

                EliminaDirectorio(vcRutaEnviar)

                prmProcesoCorrecto = True
                Return miArchivo

            Catch ex As Exception
                'Try
                '    Dim intFileNo As Integer = FreeFile()
                '    FileOpen(intFileNo, "C:\Adsum\MiArchivo.TXT", OpenMode.Output)
                '    PrintLine(intFileNo, ex.Message.ToString)
                '    FileClose(intFileNo)
                'Catch exx As Exception

                'End Try
                EliminaDirectorio(vcRutaEnviarGlobal)
                PlMensajeMostrar(ex.Message.ToString, MessageBoxIcon.Error)
                PlMensajeEstatusOcultar()
                If Not Log Is Nothing Then
                    ClsTools.GrabaMensajeLog(Log, "Error ClsConciliadorWS Envia: " & DAO.RegresaFechaDelSistema & " " & ex.Source & " " & ex.Message.ToString, EventLogEntryType.Error)
                End If
                Return Nothing
            End Try
        End Function
#End Region

#Region "Funciones Privadas"
#Region "Envia Datos"
        Private Sub PlCreaTablaControlXML(ByRef prmDt As DataTable)
            prmDt.TableName = DAO.ParametroAdministradoObtener("WS", "NOMBRE_TABLACONTROL_XML_WEBSERVICE")
            prmDt.Columns.Add("cXML", GetType(String))
            prmDt.Columns.Add("nOrden", GetType(Integer))
        End Sub
        Private Sub FlAgregaArchivoTablaControlXML(ByRef prmDtControl As DataTable, ByVal prmNombreXML As String, ByVal prmOrden As Int32)
            Dim vDRow As DataRow
            vDRow = prmDtControl.NewRow
            vDRow("cXML") = prmNombreXML.Trim
            vDRow("nOrden") = prmOrden
            prmDtControl.Rows.Add(vDRow)
        End Sub
        Private Function FlAgregaTablaControl(ByRef prmDsInformacion As DataSet, ByVal prmDsTablasEnviarWS As DataSet) As Boolean
            Dim miDtControl As New DataTable
            miDtControl.TableName = atrNombreTablaControlParaXML.Trim
            miDtControl.Columns.Add("cNombreTabla", GetType(String))
            miDtControl.Columns.Add("bEliminarDatos", GetType(Boolean))
            miDtControl.Columns.Add("cSqlDelete", GetType(String))

            Dim vDRow As DataRow
            Dim vColRow() As DataRow
            For Each dt As DataTable In prmDsInformacion.Tables
                vDRow = miDtControl.NewRow
                vDRow("cNombreTabla") = dt.TableName
                vColRow = prmDsTablasEnviarWS.Tables(EnviaWS.Querys).Select(Tabla.Trim.ToUpper & " = '" & dt.TableName.Trim.ToUpper & "' AND NOT " & SqlDeleteHijos & " IS NULL")
                vDRow("bEliminarDatos") = False
                If vColRow.Length > 0 Then
                    vDRow("bEliminarDatos") = True
                    vDRow("cSqlDelete") = vColRow(0)(SqlDeleteHijos)
                End If
                miDtControl.Rows.Add(vDRow)
            Next
            If Not miDtControl.Rows.Count > 0 Then Return False
            prmDsInformacion.Tables.Add(miDtControl)
            Return True
        End Function
        Private Function FlGeneraArchivosXMLEnviar(ByVal prmRutaArchivos As String, ByVal prmDsTablasEnviarWS As DataSet, ByVal prmSQL As ArrayList, ByVal prmTABLAS As ArrayList) As Boolean
            Dim vnCount As Int32 = 0
            Dim vDs As DataSet
            Dim vcSql As String = ""
            Dim param(0) As Object
            Dim vNombresTablas As ArrayList
            Dim vDtControlXML As New DataTable
            Dim vnCountArchivos As Int32 = 1
            PlCreaTablaControlXML(vDtControlXML)

            atrNombreTablaControlParaXML = DAO.ParametroAdministradoObtener("WS", "NOMBRE_TABLACONTROL_PARA_ARCHIVO_XML_WEBSERVICE")

            For Each dr As DataRow In prmDsTablasEnviarWS.Tables(EnviaWS.Querys).Select("NOT " & SqlComplemento & " IS NULL", Orden)
                vNombresTablas = New ArrayList
                vDs = New DataSet
                vcSql = ""
                param(0) = Nothing
                vcSql = prmSQL(vnCount) & vbCr
                vNombresTablas.Add(prmTABLAS(vnCount))
                For Each drHijo As DataRow In prmDsTablasEnviarWS.Tables(EnviaWS.Querys).Select(OrdenPadre & " = " & dr(Orden))
                    vnCount += 1
                    vcSql &= prmSQL(vnCount) & vbCr
                    vNombresTablas.Add(prmTABLAS(vnCount))
                Next

                vnCount += 1
                param(0) = vcSql
                DAO.RegresaConsultaSQL("SP_WS_EjecutaConsulta", vDs, param)
                Dim i As Int32 = 0
                For Each dt As DataTable In vDs.Tables
                    dt.TableName = vNombresTablas(i)
                    RegresaPrimaryKeys(dt)
                    i += 1
                Next
                If Not FlAgregaTablaControl(vDs, prmDsTablasEnviarWS) Then Continue For
                If Not FlTieneDatosDataSet(vDs) Then Continue For
                Try
                    Dim vcXML As String = vNombresTablas(0).ToString & ".XML"
                    vDs.WriteXml(prmRutaArchivos & vcXML)
                    FlAgregaArchivoTablaControlXML(vDtControlXML, vcXML.Trim, vnCountArchivos)
                    vnCountArchivos += 1
                Catch ex As Exception
                    Continue For
                End Try
            Next

            Dim miDsControl As New DataSet
            miDsControl.Tables.Add(vDtControlXML)
            miDsControl.WriteXml(prmRutaArchivos & DAO.ParametroAdministradoObtener("WS", "NOMBRE_TABLACONTROL_XML_WEBSERVICE") & ".XML")

            Return True
        End Function
        Private Function FlGeneraArchivosXMLEnviar_Sucursal(ByVal prmRutaArchivos As String, ByVal prmDsTablasEnviarWS As DataSet, ByVal prmSQL As ArrayList, ByVal prmTABLAS As ArrayList, ByRef prmProcesoCorrecto As Boolean) As Boolean
            Dim vnCount As Int32 = 0
            Dim vDs As DataSet
            Dim vcSql As String = ""
            Dim param(0) As Object
            Dim vNombresTablas As ArrayList
            Dim vDtControlXML As New DataTable
            Dim vnCountArchivos As Int32 = 1
            PlCreaTablaControlXML(vDtControlXML)

            atrNombreTablaControlParaXML = DAO.ParametroAdministradoObtener("WS", "NOMBRE_TABLACONTROL_PARA_ARCHIVO_XML_WEBSERVICE")

            For Each dr As DataRow In prmDsTablasEnviarWS.Tables(EnviaWS.Querys).Select(OrdenPadre & " IS NULL", Orden)
                vNombresTablas = New ArrayList
                vDs = New DataSet
                vcSql = ""
                param(0) = Nothing
                vcSql = prmSQL(vnCount) & vbCr
                vNombresTablas.Add(prmTABLAS(vnCount))
                For Each drHijo As DataRow In prmDsTablasEnviarWS.Tables(EnviaWS.Querys).Select(OrdenPadre & " = " & dr(Orden))
                    vnCount += 1
                    vcSql &= prmSQL(vnCount) & vbCr
                    vNombresTablas.Add(prmTABLAS(vnCount))
                Next

                vnCount += 1
                param(0) = vcSql
                DAO.RegresaConsultaSQL("SP_WS_EjecutaConsulta", vDs, param)
                Dim i As Int32 = 0
                For Each dt As DataTable In vDs.Tables
                    dt.TableName = vNombresTablas(i)
                    RegresaPrimaryKeys(dt)
                    i += 1
                Next
                If Not FlAgregaTablaControl(vDs, prmDsTablasEnviarWS) Then Continue For
                If Not FlTieneDatosDataSet(vDs) Then Continue For
                Try
                    Dim vcXML As String = vNombresTablas(0).ToString & ".XML"
                    vDs.WriteXml(prmRutaArchivos & vcXML)
                    FlAgregaArchivoTablaControlXML(vDtControlXML, vcXML.Trim, vnCountArchivos)
                    vnCountArchivos += 1
                Catch ex As Exception
                    Continue For
                End Try
            Next

            Dim miDsControl As New DataSet
            miDsControl.Tables.Add(vDtControlXML)
            miDsControl.WriteXml(prmRutaArchivos & DAO.ParametroAdministradoObtener("WS", "NOMBRE_TABLACONTROL_XML_WEBSERVICE") & ".XML")

            Return True
        End Function
        Public Shared Function RegresaPrimaryKeys(ByRef prmDt As DataTable) As Boolean
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vDt As New DataTable

            DAO.RegresaEsquemaDeDatos("SELECT * FROM " & prmDt.TableName.Trim.ToUpper & " (NOLOCK) WHERE 1 = 0", vDt)

            Dim vCol(vDt.PrimaryKey.Length - 1) As DataColumn

            Dim i As Int32 = 0

            For Each dc As DataColumn In vDt.PrimaryKey
                vCol(i) = prmDt.Columns(dc.ColumnName)
                i += 1
            Next

            prmDt.PrimaryKey = vCol

            Return True
        End Function
        Public Shared Function RegresaPrimaryKeys(ByRef prmNombreTabla As String) As DataColumn()
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vDt As New DataTable
            Dim vcCamposLlave As String = ""
            DAO.RegresaEsquemaDeDatos("SELECT * FROM " & prmNombreTabla.Trim.ToUpper & " (NOLOCK) WHERE 1 = 0", vDt)

            Dim vCol(vDt.PrimaryKey.Length - 1) As DataColumn

            Dim i As Int32 = 0

            For Each dc As DataColumn In vDt.PrimaryKey
                vCol(i) = vDt.Columns(dc.ColumnName)
                i += 1
            Next

            Return vCol
        End Function
        Private Function FlTieneDatosDataSet(ByVal prmDs As DataSet) As Boolean
            For Each Tabla As DataTable In prmDs.Tables
                If Tabla.Rows.Count > 0 Then Return True
            Next
            Return False
        End Function
        ' ''Private Function FlRegresaNombreXMLEnviar() As String
        ' ''    Dim vcNombreFolioAdministrado As String = ""

        ' ''    Select Case Corporativo
        ' ''        Case True
        ' ''            vcNombreFolioAdministrado = "WS_ARCHIVOS_PLA_" & atrAlmacen.Plaza.Folio
        ' ''            DAO.FolioAdministradoAgregar(vcNombreFolioAdministrado, "Folio Administrado Corporativo")
        ' ''        Case False
        ' ''            Dim vObjAlm As Catalogos.ClsAlmacen
        ' ''            vObjAlm = Catalogos.FabricaCatalogos.ObtenAlmacen(DAO.ParametroAdministradoObtener("PRO", "ALMACENLOCAL"))
        ' ''            vcNombreFolioAdministrado = "WS_ARCHIVOS_ALM_" & vObjAlm.Folio 'ClsToolsAccTextBoxAdvanced.ObtenAlmacenINI.Folio
        ' ''            DAO.FolioAdministradoAgregar(vcNombreFolioAdministrado, "Folio Administrado Almacen")
        ' ''    End Select

        ' ''    If Not DAO.TieneTransaccionAbierta Then DAO.AbreTransaccion()
        ' ''    'Formamos el nombre del archivo
        ' ''    vcNombreFolioAdministrado &= "_" & DAO.FolioAdministradoSiguiente(vcNombreFolioAdministrado) & ".ZIP"

        ' ''    '' Validamos si es un archivo generado manualmente, para concatenar al nombre generado por el sistema
        ' ''    '' el nombre que el usuario desea agregarle al inicio
        ' ''    If RutaGenerarArchivoManual <> "" Then
        ' ''        vcNombreFolioAdministrado = IO.Path.GetFileName(RutaGenerarArchivoManual) & "_" & vcNombreFolioAdministrado
        ' ''    End If

        ' ''    'Insertamos el nombre en CTL_AdministracionArchivosWS
        ' ''    If Not WS.ClsAdministracionArchivosWS.GuardaArchivos(vcNombreFolioAdministrado, PlazaEnvia_N, Not RutaGenerarArchivoManual = "") Then
        ' ''        If DAO.TieneTransaccionAbierta Then DAO.DeshaceTransaccion()
        ' ''        Return ""
        ' ''    End If
        ' ''    If DAO.TieneTransaccionAbierta Then DAO.CierraTransaccion()
        ' ''    Return vcNombreFolioAdministrado
        ' ''End Function
#End Region
#Region "Conciliador"
        Private Function FlObtieneDatosLocal(ByVal prmSQL As ArrayList) As DataSet
            '¿Que Hace?: Obtiene los datos de manera local para Conciliar o Enviar al WS
            '   Parámetros:     prmSQL
            '     prmSQL:  
            Dim vDsInfoLocal As New DataSet
            Dim param(0) As Object
            Dim vcQuerys As String = ""

            For Each vcSql As String In prmSQL
                vcQuerys &= vcSql & vbCr
            Next
            param(0) = vcQuerys

            DAO.RegresaConsultaSQL("SP_WS_EjecutaConsulta", vDsInfoLocal, param)



            Return vDsInfoLocal
        End Function
        Private Function FlRegresaWhereParaUpdateCampoControl(ByVal prmRow As DataRow, ByVal prmCampoLlaveTablaControl As String) As String
            Dim vcWHERE As String = ""
            For Each vcCampo As String In prmCampoLlaveTablaControl.Split(",")
                vcWHERE &= vcCampo & " = " & prmRow(vcCampo) & " AND "
            Next
            'ES de corporativo a corporativo y se tiene que indicar en el update que plaza envió
            If Not PlazaEnvia_C.Trim = "" Then
                vcWHERE &= PlazaEnvia_C & " = " & PlazaEnvia_N & " AND "
            End If
            If Not vcWHERE.Trim = "" Then vcWHERE = vcWHERE.Trim.Substring(0, vcWHERE.Trim.Length - 3)
            Return vcWHERE
        End Function
        Private Function FlRegresaFiltroSelect(ByVal prmConsultaReal As String, ByVal prmRow As DataRow) As String
            Dim vDt As New DataTable
            prmConsultaReal = String.Format(prmConsultaReal, "1=0")
            DAO.RegresaEsquemaDeDatos(prmConsultaReal, vDt)

            Dim vcFiltro As String = ""
            For Each col As DataColumn In vDt.PrimaryKey
                vcFiltro &= col.ColumnName & " = " & prmRow(col.ColumnName) & " AND "
            Next
            vcFiltro = vcFiltro.Trim
            If vcFiltro.Trim = "" Then Return "1=0"
            vcFiltro = vcFiltro.Trim.Substring(0, vcFiltro.Trim.Length - 3)
            Return vcFiltro
        End Function
        Private Function FlValidaCamposPadre(ByRef prmRowLocal As DataRow, ByRef prmRowWS As DataRow, ByVal prmCamposValidar As String) As Boolean
            If prmCamposValidar.Trim = "" Then Return False
            Dim vbValidaTodosCampos As Boolean = (prmCamposValidar.Trim = "*")

            Select Case vbValidaTodosCampos
                Case True
                    For Each col As DataColumn In prmRowLocal.Table.Columns
                        If Not ClsTools.CompararColumnas(prmRowLocal(col.ColumnName), prmRowWS(col.ColumnName), col.DataType()) Then
                            Return False
                        End If

                    Next
                Case False
                    For Each vcCampo As String In prmCamposValidar.Trim.Split(",")
                        Dim cTipoCampo As System.Type
                        cTipoCampo = prmRowLocal.Table.Columns(vcCampo).DataType
                        If Not ClsTools.CompararColumnas(prmRowLocal(vcCampo), prmRowWS(vcCampo), cTipoCampo) Then Return False
                    Next
            End Select

            Return True
        End Function
        Private Function FlValidaCamposHijo(ByRef prmRowsLocal() As DataRow, ByRef prmRowsWS() As DataRow, ByVal prmRowTablaHijo As DataRow) As Boolean
            Dim vcCamposValidar As String = prmRowTablaHijo(CampoConciliar)
            If vcCamposValidar.Trim = "" Then Return False
            If Not prmRowsLocal.Length = prmRowsWS.Length Then Return False
            Dim vbValidaTodosCampos As Boolean = (vcCamposValidar.Trim = "*")

            Dim vnTotalRow As Int32 = prmRowsLocal.Length - 1
            Dim vDRow As DataRow

            'Valida Campos LLave de todo el detalle
            For i As Int32 = 0 To vnTotalRow
                If Not FlValidaCamposHijo(prmRowsLocal(i), prmRowsWS(i), prmRowTablaHijo(Sql)) Then Return False
            Next

            'Valida los campos a conciliar de todo el detalle
            For i As Int32 = 0 To vnTotalRow
                vDRow = prmRowsLocal(i)
                Select Case vbValidaTodosCampos
                    Case True
                        For Each col As DataColumn In vDRow.Table.Columns
                            If Not ClsTools.CompararColumnas(vDRow(col.ColumnName), prmRowsWS(i)(col.ColumnName), col.DataType) Then Return False
                        Next
                    Case False
                        For Each vcCampo As String In vcCamposValidar.Trim.Split(",")
                            Dim cTipoCampo As System.Type
                            cTipoCampo = vDRow.Table.Columns(vcCampo).DataType()
                            If Not ClsTools.CompararColumnas(vDRow(vcCampo), prmRowsLocal(i)(vcCampo), cTipoCampo) Then Return False
                        Next
                End Select
            Next

            Return True
        End Function
        Private Function FlValidaCamposHijo(ByVal prmRowLocal As DataRow, ByVal prmRowWS As DataRow, ByVal prmConsultaReal As String) As Boolean
            'Compara los campos llaves de los hijos
            Dim vDt As New DataTable
            prmConsultaReal = String.Format(prmConsultaReal, "1=0")
            DAO.RegresaEsquemaDeDatos(prmConsultaReal, vDt)
            For Each col As DataColumn In vDt.PrimaryKey
                If Not ClsTools.CompararColumnas(prmRowLocal(col.ColumnName), prmRowWS(col.ColumnName), col.DataType()) Then Return False
            Next
            Return True
        End Function
#End Region
#Region "Comunes"
        Public Shared Function FormateaFechaDeXML(ByVal prmFecha As String) As String
            Dim vnPosicionPunto As Int32 = 0
            prmFecha = prmFecha.Replace("T", " ")
            'vnPosicionPunto = InStr(prmFecha, ".")
            'If Not vnPosicionPunto = 0 Then
            '    prmFecha = prmFecha.Substring(0, vnPosicionPunto - 1)
            'End If
            prmFecha = prmFecha.Substring(0, 19)
            Return prmFecha
        End Function
        Private Function FlObtieneConfiguracionTablas(ByRef prmDsTablasEnviarWS As DataSet, ByRef prmSQL As ArrayList, ByRef prmTablas As ArrayList) As Boolean
            '¿Que Hace?:    Obtiene la configuración de las tablas que se enviarán o conciliarán en el WS, de la tabla CTL_InformacionEnviarWS
            'Parámetros:    prmDsTablasEnviarWS, prmSQL, prmTablas
            '       prmDsTablasEnviarWS:    DataSet para almacenar la configuración de todas las tablas a manejar
            '       prmSQL:                 ArrayList para almacenar todos los Select que se harán a la tabla complemento para obtener la información 
            '                               a enviar o conciliar
            '       prmTABLAS:              ArrayList para almacenar los nombres (ordenados) de todas las tablas involucradas.

            Dim param(2) As Object
            param(0) = atrContextos.Trim
            param(1) = atrnContexto
            param(2) = atrMuestraMensajes
            DAO.RegresaConsultaSQL("SP_WS_InformacionEnviarWS", prmDsTablasEnviarWS, param)

            'For Each dr As DataRow In prmDsTablasEnviarWS.Tables(0).Rows
            '    '' Agregamos un Not por confusion de no saber que hace esta instruccion
            '    If Not dr("nOrden") = 15 Then Continue For
            '    dr.Delete()
            'Next

            prmDsTablasEnviarWS.Tables(0).AcceptChanges()
            Dim vDtBorrar As New DataTable
            Dim vDrBorrar As DataRow
            vDtBorrar.Columns.Add("nOrden", GetType(Integer))

            Dim vcUniverso As String = ""
            'Recorre todos los registros padres
            For Each dr As DataRow In prmDsTablasEnviarWS.Tables(EnviaWS.Querys).Select("NOT " & SqlComplemento & " IS NULL", Orden)
                vcUniverso = ""
                'Obtenemos El universo de datos que se tomarán
                Dim vDt As New DataTable
                Dim vcSQL As String = dr(SqlComplemento) & " AND " & PlazaEnvia_C & " = " & PlazaEnvia_N
                'Si trae filtro...
                If Not prmDsTablasEnviarWS.Tables(EnviaWS.Querys).Columns("cSqlFiltro") Is Nothing Then
                    If Not ClsTools.IfNull(dr("cSqlFiltro"), "").ToString.Trim = "" Then
                        Dim vcFiltro As String = dr("cSqlFiltro")
                        vcFiltro = String.Format(vcFiltro, Almacen_de_Sucursal.ToString)
                        vcSQL &= " AND " & vcFiltro
                    End If
                End If
                DAO.RegresaConsultaSQL(vcSQL, vDt)
                vcUniverso = FlRegresaUniverso(vDt, dr(CampoLlaveControl))
                If vcUniverso.Trim = "" Then
                    vDrBorrar = vDtBorrar.NewRow
                    vDrBorrar("nOrden") = dr(Orden)
                    vDtBorrar.Rows.Add(vDrBorrar)
                    Continue For
                End If

                If ClsTools.IfNull(dr(EliminarDatos), False) Then
                    dr(SqlDeleteHijos) = String.Format(dr(SqlDeleteHijos), vcUniverso)
                Else
                    dr(SqlDeleteHijos) = DBNull.Value
                End If

                'Formamos los Querys que se enviarán al Web Service para conciliar
                prmSQL.Add(String.Format(dr(Sql), vcUniverso))
                prmTablas.Add(dr(Tabla))
                For Each drHijo As DataRow In prmDsTablasEnviarWS.Tables(EnviaWS.Querys).Select(OrdenPadre & " = " & dr(Orden))
                    prmTablas.Add(drHijo(Tabla))
                    prmSQL.Add(String.Format(drHijo(Sql), vcUniverso))
                    If ClsTools.IfNull(drHijo(EliminarDatos), False) Then
                        drHijo(SqlDeleteHijos) = String.Format(drHijo(SqlDeleteHijos), vcUniverso)
                    Else
                        drHijo(SqlDeleteHijos) = DBNull.Value
                    End If
                Next
            Next


            Dim vColRow() As DataRow
            For Each dr As DataRow In vDtBorrar.Rows
                vColRow = prmDsTablasEnviarWS.Tables(EnviaWS.Querys).Select(Orden & " = " & dr("nOrden"))
                For Each drPadre As DataRow In vColRow
                    For Each drHijo As DataRow In prmDsTablasEnviarWS.Tables(EnviaWS.Querys).Select(OrdenPadre & " = " & drPadre(Orden))
                        drHijo.Delete()
                    Next
                    drPadre.Delete()
                Next
            Next

            prmDsTablasEnviarWS.AcceptChanges()

            Return True
        End Function
        Private Function FlObtieneConfiguracionTablas_Sucursal(ByRef prmDsTablasEnviarWS As DataSet, ByRef prmSQL As ArrayList, ByRef prmTablas As ArrayList) As Boolean
            '¿Que Hace?:    Obtiene la configuración de las tablas que se enviarán o conciliarán en el WS, de la tabla CTL_InformacionEnviarWS
            'Parámetros:    prmDsTablasEnviarWS, prmSQL, prmTablas
            '       prmDsTablasEnviarWS:    DataSet para almacenar la configuración de todas las tablas a manejar
            '       prmSQL:                 ArrayList para almacenar todos los Select que se harán a la tabla complemento para obtener la información 
            '                               a enviar o conciliar
            '       prmTABLAS:              ArrayList para almacenar los nombres (ordenados) de todas las tablas involucradas.

            Dim param(1) As Object
            param(0) = atrContextos.Trim
            param(1) = atrnContexto
            DAO.RegresaConsultaSQL("SP_WS_InformacionEnviarWS_Sucursal", prmDsTablasEnviarWS, param)

            'For Each dr As DataRow In prmDsTablasEnviarWS.Tables(0).Rows
            '    '' Agregamos un Not por confusion de no saber que hace esta instruccion
            '    If Not dr("nOrden") = 15 Then Continue For
            '    dr.Delete()
            'Next

            prmDsTablasEnviarWS.Tables(0).AcceptChanges()
            Dim vDtBorrar As New DataTable
            Dim vDrBorrar As DataRow
            vDtBorrar.Columns.Add("nOrden", GetType(Integer))

            Dim vcUniverso As String = ""
            'Recorre todos los registros padres
            For Each dr As DataRow In prmDsTablasEnviarWS.Tables(EnviaWS.Querys).Select(OrdenPadre & " IS NULL ", Orden)
                vcUniverso = ""
                'Obtenemos El universo de datos que se tomarán
                Dim vDt As New DataTable
                Dim vcTempSql As String = dr(Sql)
                Dim vcFiltro As String = dr("cSqlFiltro")
                vcFiltro = String.Format(vcFiltro, Almacen_de_Sucursal.ToString)
                vcTempSql = String.Format(vcTempSql, vcFiltro)
                DAO.RegresaConsultaSQL(vcTempSql, vDt)
                'DAO.RegresaConsultaSQL(dr(SqlComplemento) & " AND " & PlazaEnvia_C & " = " & PlazaEnvia_N, vDt)
                vcUniverso = FlRegresaUniverso(vDt, dr(CampoLlave))
                If vcUniverso.Trim = "" Then
                    vDrBorrar = vDtBorrar.NewRow
                    vDrBorrar("nOrden") = dr(Orden)
                    vDtBorrar.Rows.Add(vDrBorrar)
                    Continue For
                End If

                If ClsTools.IfNull(dr(EliminarDatos), False) Then
                    dr(SqlDeleteHijos) = String.Format(dr(SqlDeleteHijos), vcUniverso)
                Else
                    dr(SqlDeleteHijos) = DBNull.Value
                End If

                'Formamos los Querys que se enviarán al Web Service para conciliar
                prmSQL.Add(String.Format(dr(Sql), vcUniverso))
                prmTablas.Add(dr(Tabla))
                For Each drHijo As DataRow In prmDsTablasEnviarWS.Tables(EnviaWS.Querys).Select(OrdenPadre & " = " & dr(Orden))
                    prmTablas.Add(drHijo(Tabla))
                    prmSQL.Add(String.Format(drHijo(Sql), vcUniverso))
                    If ClsTools.IfNull(drHijo(EliminarDatos), False) Then
                        drHijo(SqlDeleteHijos) = String.Format(drHijo(SqlDeleteHijos), vcUniverso)
                    Else
                        drHijo(SqlDeleteHijos) = DBNull.Value
                    End If
                Next
            Next


            Dim vColRow() As DataRow
            For Each dr As DataRow In vDtBorrar.Rows
                vColRow = prmDsTablasEnviarWS.Tables(EnviaWS.Querys).Select(Orden & " = " & dr("nOrden"))
                For Each drPadre As DataRow In vColRow
                    For Each drHijo As DataRow In prmDsTablasEnviarWS.Tables(EnviaWS.Querys).Select(OrdenPadre & " = " & drPadre(Orden))
                        drHijo.Delete()
                    Next
                    drPadre.Delete()
                Next
            Next

            prmDsTablasEnviarWS.AcceptChanges()

            Return True
        End Function
        ' ''Private Function DevuelveWSRecepcion() As WSRecepcionArchivo.RecepcionArchivo
        ' ''    Dim miWS As New WSRecepcionArchivo.RecepcionArchivo
        ' ''    miWS.Timeout = 1000000
        ' ''    miWS.Url = Url
        ' ''    Return miWS
        ' ''End Function

        ' ''Public Shared Function DevuelveWSRecepcionArchivo(Optional ByVal prmDAO As DataAccessCls = Nothing, Optional ByVal prmUrl As String = "", Optional ByVal prmTiempoEsperaSegundos As Int32 = 0) As WSRecepcionArchivo.RecepcionArchivo
        ' ''    Dim miWS As New WSRecepcionArchivo.RecepcionArchivo
        ' ''    miWS.Timeout = 1000000
        ' ''    If Not prmTiempoEsperaSegundos = 0 Then
        ' ''        miWS.Timeout = prmTiempoEsperaSegundos * 1000
        ' ''    End If
        ' ''    Dim DAO As DataAccessCls
        ' ''    If Not prmDAO Is Nothing Then
        ' ''        DAO = prmDAO
        ' ''    Else
        ' ''        DAO = DataAccessCls.DevuelveInstancia
        ' ''    End If
        ' ''    If prmUrl.Trim = "" Then
        ' ''        miWS.Url = DAO.RegresaDatoSQL("SELECT TOP 1 cUrl FROM CTL_PlazasEnviarInformacionWS (NOLOCK) where bActivo = 1")
        ' ''    Else
        ' ''        miWS.Url = prmUrl
        ' ''    End If
        ' ''    Return miWS
        ' ''End Function

        Public Shared Function ObtenInformacion(ByRef prmDAO As DataAccessCls, ByVal prmSQL As ArrayList) As Byte()
            Dim vFrmWait As New frmStatus
            vFrmWait.Show("Solicitando Información a Corporativo")
            'Dim wsRecepcion As WSRecepcionArchivo.RecepcionArchivo
            'wsRecepcion = DevuelveWSRecepcionArchivo(prmDAO)
            'Dim arch As Byte()
            'arch = wsRecepcion.RegresarConsulta(prmSQL.ToArray(Type.GetType("System.String")))
            vFrmWait.Visible = False
            vFrmWait.Dispose()
            vFrmWait = Nothing
            'Return arch
            Return Nothing
        End Function



        Private Function FlRegresaUniverso(ByVal prmDtUniverso As DataTable, ByVal prmCampoLlaveTablaControl As String) As String
            If prmCampoLlaveTablaControl.Trim = "" OrElse prmDtUniverso Is Nothing Then Return ""

            Dim vbLlaveMultiple As Boolean = Not InStr(prmCampoLlaveTablaControl, ",") = 0
            Dim vcUniverso As String = ""
            Dim vnCount As Int32 = 1
            Dim vbHayDatos As Boolean = False

            Select Case vbLlaveMultiple
                Case False
                    vcUniverso &= prmCampoLlaveTablaControl & " IN ( "
                    For Each drUniverso As DataRow In prmDtUniverso.Rows
                        vbHayDatos = True
                        vcUniverso &= drUniverso(prmCampoLlaveTablaControl).ToString.Trim & ","
                        If vnCount > 7 Then
                            vcUniverso &= vbCr
                            vnCount = 0
                        End If
                        vnCount += 1
                    Next
                    If Not vcUniverso.Trim = "" Then
                        vcUniverso = vcUniverso.Trim.Substring(0, vcUniverso.Trim.Length - 1)
                        vcUniverso &= " )"
                    End If
                Case True
                    Dim vArrayCampos() As String = prmCampoLlaveTablaControl.Split(",")
                    For Each drUniverso As DataRow In prmDtUniverso.Rows
                        vbHayDatos = True
                        vcUniverso &= "("
                        For Each vcCampo As String In vArrayCampos
                            vcUniverso &= vcCampo & " = " & drUniverso(vcCampo).ToString.Trim & " AND "
                        Next
                        vcUniverso = vcUniverso.Trim.Substring(0, vcUniverso.Trim.Length - 3)
                        vcUniverso &= ")"
                        vcUniverso &= " OR "
                        If vnCount > 2 Then
                            vcUniverso &= vbCr
                            vnCount = 0
                        End If
                        vnCount += 1
                    Next
                    If Not vcUniverso.Trim = "" Then vcUniverso = vcUniverso.Trim.Substring(0, vcUniverso.Trim.Length - 2)
            End Select

            If Not vbHayDatos Then vcUniverso = ""

            Return vcUniverso.Trim
        End Function
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
        'Public Shared Function CompararColumnas(ByVal Column1 As Object, ByVal Column2 As Object, ByVal Tipo As Type) As Boolean

        '    Dim sTipo As String
        '    Dim bconfirmacion As Boolean

        '    bconfirmacion = True

        '    If Not Column1 Is System.DBNull.Value And Not Column2 Is System.DBNull.Value Then

        '        'Se identifica de que tipo es la columna que se desa comparar, para hacer el cast correspondiente y la comparacion correspondiente
        '        Select Case Tipo.FullName()

        '            Case "System.String"
        '                If Column1.ToString() <> Column2.ToString() Then
        '                    bconfirmacion = False
        '                End If

        '            Case "System.Int64"
        '                If Convert.ToInt32(Column1) <> Convert.ToInt32(Column2) Then
        '                    bconfirmacion = False
        '                End If

        '            Case "System.Int32"
        '                If Convert.ToInt32(Column1) <> Convert.ToInt32(Column2) Then
        '                    bconfirmacion = False
        '                End If

        '            Case "System.Int16"
        '                If Convert.ToInt16(Column1) <> Convert.ToInt32(Column2) Then
        '                    bconfirmacion = False
        '                End If

        '            Case "System.Byte"
        '                If Convert.ToInt16(Column1) <> Convert.ToInt32(Column2) Then
        '                    bconfirmacion = False
        '                End If

        '            Case "System.Boolean"
        '                If Convert.ToBoolean(Column1) <> Convert.ToBoolean(Column2) Then
        '                    bconfirmacion = False
        '                End If

        '            Case "System.DateTime"
        '                If Comunes.Comun.ClsTools.NumeroJuliano(Convert.ToDateTime(Column1)) <> Comunes.Comun.ClsTools.NumeroJuliano(Convert.ToDateTime(Column2)) Then
        '                    bconfirmacion = False
        '                End If

        '            Case "System.Double"
        '                If Convert.ToDouble(Column1) <> Convert.ToDouble(Column2) Then
        '                    bconfirmacion = False
        '                End If

        '            Case "System.Decimal"
        '                If Convert.ToDecimal(Column1) <> Convert.ToDecimal(Column2) Then
        '                    bconfirmacion = False
        '                End If

        '        End Select

        '    Else

        '        If (Not Column1 Is System.DBNull.Value And Column2 Is System.DBNull.Value) Or (Column1 Is System.DBNull.Value And Not Column2 Is System.DBNull.Value) Then
        '            bconfirmacion = False
        '        End If

        '    End If

        '    CompararColumnas = bconfirmacion

        'End Function
#End Region

#Region "Prueba Inserta y Actualiza"
        Public Shared Function InsertaYActualizaTablaDeBD(ByRef prmTabla As DataTable, ByRef Filtro As String) As Boolean
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Try
                Dim ABRIO_TRAN As Boolean = False
                Dim vbResult As Boolean = True
                Dim vTabla As New DataTable
                Dim vAdapter As New System.Data.SqlClient.SqlDataAdapter()
                Dim vcNombresCampos As String = Tool.GetListaNombresDeCampos(prmTabla)
                Dim vSql As String = "SELECT " & vcNombresCampos & " FROM " & prmTabla.TableName & " (NOLOCK) WHERE 1 = 0"
                Dim vcSqlSelect As String = "SELECT " & vcNombresCampos & " FROM " & prmTabla.TableName & " (NOLOCK) "
                If Not Filtro.Trim = "" Then vcSqlSelect &= Filtro.Trim

                If Not DAO.RegresaEsquemaDeDatos(vSql, vTabla) Then Return False
                If Not DAO.TieneTransaccionAbierta Then
                    DAO.AbreTransaccion()
                    ABRIO_TRAN = True
                End If
                If Not DAO.LlenaTablaDeDatos(vcSqlSelect, vAdapter, vTabla) Then Return False
                If Not Tool.LLenaTablaConValoresDeOtra(prmTabla, vTabla) Then Return False

                'ClsTools.copiaRows(prmTabla.Select(""), vTabla, prmTabla.Columns)


                Dim vActualizaciones As DataTable
                vActualizaciones = vTabla.GetChanges(DataRowState.Modified)

                If Not vActualizaciones Is Nothing Then
                    If vActualizaciones.Rows.Count > 0 Then
                        vbResult = DAO.ActualizaDatosDeTablaSql(vAdapter, vActualizaciones)
                    End If
                End If

                If Not vbResult Then Return False

                Dim vInserciones As DataTable
                vInserciones = vTabla.GetChanges(DataRowState.Added)

                If Not vInserciones Is Nothing Then
                    If vInserciones.Rows.Count > 0 Then
                        vbResult = DAO.InsertaDatosDeTablaSql(vAdapter, vInserciones)
                    End If
                End If

                If vbResult Then
                    If ABRIO_TRAN Then
                        If DAO.TieneTransaccionAbierta Then DAO.CierraTransaccion()
                    End If
                End If

                Return vbResult

            Catch ex As Exception
                MessageBox.Show("Ocurrio el siguiente error en el proceso de actualizacion. " + ex.Message, "Tool", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If DAO.TieneTransaccionAbierta Then DAO.DeshaceTransaccion()
                Return False
            End Try
        End Function

        Public Shared Function ActualizaDatosDeTablaSql(ByRef miDataAdapter As System.Data.SqlClient.SqlDataAdapter, ByRef miDataTable As DataTable, Optional ByVal prmDAO As DataAccessCls = Nothing) As Boolean
            Try
                Dim vTablaActualizados As DataTable = miDataTable.GetChanges(System.Data.DataRowState.Modified)
                If (vTablaActualizados Is DBNull.Value Or vTablaActualizados.Rows.Count <> miDataTable.Rows.Count) Then
                    'DespliegaErrores("Existen Renglones Agregados ó Eliminados, utiliza el método DAO.InsertaDatosDeTabla, ó DAO.EliminaDatosDeTabla");
                    Return False
                End If

                Dim vCmdBuilder As System.Data.SqlClient.SqlCommandBuilder = New System.Data.SqlClient.SqlCommandBuilder(miDataAdapter)
                miDataAdapter.DeleteCommand = Nothing
                miDataAdapter.InsertCommand = Nothing
                miDataAdapter.UpdateCommand = vCmdBuilder.GetUpdateCommand()
                'If prmDAO.TieneTransaccionAbierta = True Then
                '    miDataAdapter.UpdateCommand.Transaction = prmDAO.AbreTransaccion
                'End If
                Try
                    miDataAdapter.Update(miDataTable)
                Catch ex As Exception
                    'conexionGlobalAbierta = false;
                    miDataAdapter.Update(miDataTable)
                End Try

            Catch ex As Exception
                'DespliegaErrores(misErrores)
                Return False
            End Try
        End Function


        'Public Shared Function LlenaTablaConValoresDeOtra(ByRef vTablaDatos As DataTable, ByRef vTablaDestino As DataTable) As Boolean
        '    Dim miMensaje As String = ""
        '    If vTablaDatos Is Nothing OrElse vTablaDestino Is Nothing Then Return False

        '    Try
        '        vTablaDestino.BeginLoadData()
        '        For Each vRow As DataRow In vTablaDatos.Rows
        '            vTablaDestino.LoadDataRow(vRow.ItemArray, False)
        '        Next
        '        vTablaDestino.EndLoadData()
        '        Return True
        '    Catch ex As ArgumentException
        '        miMensaje = "El numero de columnas de la tabla origen y destino no coinciden. Origen = " & vTablaDatos.Columns.Count.ToString() & _
        '        " - Destino = " + vTablaDestino.Columns.Count.ToString() + ". " + ex.Message
        '    Catch ex As InvalidCastException
        '        miMensaje = "El tipo de datos no coincide para una columna de las tablas involucradas. " & ex.Message
        '    Catch ex As ConstraintException
        '        miMensaje = "La Instruccion esta violando un constraint definido para la tabla. " & ex.Message
        '    Catch ex As NoNullAllowedException
        '        miMensaje = "La Columna no permite valores nulos." & ex.Message
        '    Finally
        '        Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        '        If Not miMensaje.Trim = "" Then
        '            MessageBox.Show(miMensaje, "Tool", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        End If
        '    End Try
        '    Return False
        'End Function

        'Public Shared Function GetListaNombresDeCampos(ByRef prmTabla As DataTable) As String
        '    Dim vListaCampos As String = ""
        '    If prmTabla Is Nothing Then Return ""
        '    For Each col As DataColumn In prmTabla.Columns
        '        If Not vListaCampos.Trim = "" Then
        '            vListaCampos &= " ," & col.ColumnName
        '        Else
        '            vListaCampos = col.ColumnName
        '        End If
        '    Next
        '    Return vListaCampos
        'End Function

        'Public Shared Function InsertaDatosDeTablaSql(ByRef miDataAdapter As System.Data.SqlClient.SqlDataAdapter, ByRef miDataTable As DataTable) As Boolean
        '    Try
        '        Dim vTablaAgregados As DataTable
        '        vTablaAgregados = miDataTable.GetChanges(DataRowState.Added)
        '        If vTablaAgregados Is Nothing OrElse Not vTablaAgregados.Rows.Count = miDataTable.Rows.Count Then
        '            ClsTools.MuestraMensajeSistFact("Existen Renglones No Agregados, utiliza el método DAO.ActualizaDatosDeTabla, ó DAO.EliminaDatosDeTabla", MessageBoxIcon.Error)
        '            Return False
        '        End If

        '        Dim vCmdBuilder As New System.Data.SqlClient.SqlCommandBuilder(miDataAdapter)
        '        miDataAdapter.UpdateCommand = Nothing
        '        miDataAdapter.DeleteCommand = Nothing
        '        miDataAdapter.InsertCommand = vCmdBuilder.GetInsertCommand

        '        miDataAdapter.Update(miDataTable)

        '        Return True
        '    Catch ex As Exception
        '        ClsTools.MuestraMensajeSistFact("Error", MessageBoxIcon.Error)
        '        Return False
        '    End Try
        'End Function


#End Region

    End Class
End Namespace