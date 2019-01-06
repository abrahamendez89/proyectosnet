
Imports System.Data.SqlClient
Imports System.Data
Imports System.Windows.Forms
Imports Sistema.Comunes.Comun.ClsTools
Imports Sistema.Comunes.Comun

Namespace Comunes.Comun
    ' <summary>
    ' Esta clase define los metodos basicos de las clases que maneja la empresa
    ' </summary>
    Public MustInherit Class ClsBaseComun2

        Private atrFolio As Long
        Private atrDescripcion As String
        Protected atrActivo As Boolean
        Private atrRegistroAlta As ClsDatosComunesRegistro
        Private atrRegistroCancelacion As ClsDatosComunesRegistro
        Private atrRegistroUltimaModificacion As ClsDatosComunesRegistro

        Protected atrReintentaGuardarCuandoFolioNuevoYaExista As Boolean = False

        Public Property ReintentaGuardarCuandoFolioNuevoYaExista() As Boolean
            Get
                Return atrReintentaGuardarCuandoFolioNuevoYaExista
            End Get
            Set(ByVal value As Boolean)
                atrReintentaGuardarCuandoFolioNuevoYaExista = value
            End Set
        End Property

        'Atributos Comunes protegidos para utilizar en la programacion de las clases hijas
        Public atrAccion As EAccionesBD
        Public DAO As DataAccessCls
        Public atrAdapter As New SqlDataAdapter
        Public atrTabla As New DataTable
        Public atrRow As DataRow
        Public atrSql As String
        Public atrNombreCampos As String
        Public atrNombreTabla As String
        Public atrCriterioTabla As String
        Public atrGrabarLocal As Boolean = True
        Public atrDS As DataSet
        Public atrCampoFolio As String

        Protected atrValidaCorporativoProduccion As Boolean = False

        Protected atrErrorCatalogos As String = ""


        Private atrSoloPideFolioAlCorporativo As Boolean = False


        Public Delegate Function ObtenerRowEventHandler(ByRef Row As DataRow, ByVal Clase As Object) As DataRow
        Public ObtenerRow As ObtenerRowEventHandler

        Public Delegate Function GuadarPersozalizadoEventHandler() As Boolean
        Public GuardarPerzonalizadoevent As GuadarPersozalizadoEventHandler

        Public Delegate Function EsCorporativoEventHandler() As Boolean
        Public EsCorporativo As EsCorporativoEventHandler

        Public Delegate Function EsCorporativoProduccionEventHandler() As Boolean
        Public EsCorporativoProduccion As EsCorporativoProduccionEventHandler

        Dim ABRIO As Boolean

        Public Function GuardarPerzonalizado() As Boolean
            Return GuardarPerzonalizadoevent.Invoke()
        End Function

        Protected Function OnObtenerRow(ByRef Row As DataRow) As DataRow
            ObtenerRow = getRow()

            If ObtenerRow Is Nothing Then
                Return Nothing
            End If
            If Not Row Is Nothing Then
                OnObtenerRow = ObtenerRow.Invoke(Row, Me)
            Else
                Return Nothing
            End If

        End Function

        Public ReadOnly Property ErrorCatalogos() As String
            Get
                Return atrErrorCatalogos
            End Get
        End Property

        Public Property ValidaSiEsAlmacenCorporativoProduccion() As Boolean
            Get
                Return atrValidaCorporativoProduccion
            End Get
            Set(ByVal value As Boolean)
                atrValidaCorporativoProduccion = value
            End Set
        End Property

        Public Property Folio() As Long
            Get
                Return atrFolio
            End Get
            Set(ByVal Value As Long)
                atrFolio = Value
            End Set
        End Property


        Public MustOverride Function getNombreFolioAdministrado() As String

        Public MustOverride Function getRow() As ObtenerRowEventHandler

        Public MustOverride Function FormatoFolio() As String



        Public Property Activo() As Boolean
            Get
                Return atrActivo
            End Get
            Set(ByVal Value As Boolean)
                atrActivo = Value
            End Set
        End Property

        Public Property RegistroAlta() As ClsDatosComunesRegistro
            Get
                Return atrRegistroAlta
            End Get
            Set(ByVal Value As ClsDatosComunesRegistro)
                atrRegistroAlta = Value
            End Set
        End Property

        Public Property RegistroCancelacion() As ClsDatosComunesRegistro
            Get
                Return atrRegistroCancelacion
            End Get
            Set(ByVal Value As ClsDatosComunesRegistro)
                atrRegistroCancelacion = Value
            End Set
        End Property

        Public Property RegistroUltimaModificacion() As ClsDatosComunesRegistro
            Get
                Return atrRegistroUltimaModificacion
            End Get
            Set(ByVal Value As ClsDatosComunesRegistro)
                atrRegistroUltimaModificacion = Value
            End Set
        End Property

        Public Property Descripcion() As String
            Get
                Return atrDescripcion
            End Get
            Set(ByVal Value As String)
                atrDescripcion = Value
            End Set
        End Property

        Public Function DescripcionConMinusculasPrimeraLetraMayusculas() As String
            Return StrConv(atrDescripcion, VbStrConv.ProperCase)
        End Function

        Public Overridable Function Guardar() As Boolean
            Return True
        End Function

        Public Overridable Function GuardarBase() As Boolean

            'Metodo:    Guardar
            'Que hace?  Metodo base el cual prepara los objetos necesarios para guardar los datos en la bd
            '           ademas de que define la accion que se tomara y en caso de ser un nuevo registro obtiene el consecutivo de este
            'Elaboro:   David Adan Velazquez Sanchez

            If DAO Is Nothing Then
                DAO = DataAccessCls.DevuelveInstancia
            End If

            If Not DAO.TieneTransaccionAbierta Then
                MessageBox.Show("Es necesaria una transacción abierta para operaciones de Base de Datos y Folios Administrados", "Error al Guardar el objeto", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            atrAdapter = New SqlDataAdapter
            atrTabla = New DataTable
            atrSql = ""

            Try
                If EsCorporativo.Invoke Then
                    atrGrabarLocal = True
                Else
                    atrGrabarLocal = False
                    'Si la clase permite validar si es corporativo producción (esto es para la generación de etiquetas).
                    If ValidaSiEsAlmacenCorporativoProduccion Then
                        If EsCorporativoProduccion.Invoke Then
                            atrGrabarLocal = True
                        End If
                    End If
                    '
                End If
            Catch ex As Exception
                atrGrabarLocal = True
            End Try

            If atrFolio = 0 Then
                atrAccion = EAccionesBD.Insertar

                If atrGrabarLocal Then
                    atrFolio = DAO.FolioAdministradoSiguiente(getNombreFolioAdministrado())
                End If



                If Not DAO.TieneTransaccionAbierta Then Return False
            Else
                If Activo Then
                    atrAccion = EAccionesBD.Modificar
                Else
                    atrAccion = EAccionesBD.Eliminar
                End If
            End If

            Return True
        End Function

        Public Sub New(ByVal prmFolio As Long, ByVal prmDescripcion As String)
            Me.New(prmFolio, prmDescripcion, True)
        End Sub

        Public Sub New(ByVal prmFolio As Long, ByVal prmDescripcion As String, ByVal prmActivo As Boolean)
            atrFolio = prmFolio
            atrDescripcion = prmDescripcion.ToString
            atrActivo = prmActivo
        End Sub

        Public Sub New(ByVal prmFolio As Long)
            Me.New(prmFolio, "")
        End Sub

        Public Sub New()
            atrFolio = 0
            atrDescripcion = ""
            atrActivo = True
            Try
                If Not EsCorporativo Is Nothing Then
                    If Not EsCorporativo.Invoke Then
                        atrGrabarLocal = False
                    End If
                End If
            Catch ex As Exception
                atrGrabarLocal = True
            End Try
            If atrDS Is Nothing Then
                atrDS = New DataSet
            End If
        End Sub

        Public Function getNuevosDatosRegistros() As ClsDatosComunesRegistro

            'Metodo:    getNuevosDatosRegistros
            'Que hace?  Devuelve una instancia de ClsDatosComunesRegistro con los datos de la conexion y maquina acual
            '           para dejar huella en el sistema
            'Elaboro:   David Adan Velazquez Sanchez

            If DAO Is Nothing Then
                DAO = DataAccessCls.DevuelveInstancia
            End If
            'Se acortaron los caracteres a guardar en los datos de registro para ahorrar espacio en la base de datos
            getNuevosDatosRegistros = New ClsDatosComunesRegistro
            getNuevosDatosRegistros.Usuario = Microsoft.VisualBasic.Left(DAO.GetLoginUsuario, 15)
            getNuevosDatosRegistros.Fecha = DAO.RegresaFechaDelSistema
            'getNuevosDatosRegistros.Maquina = Microsoft.VisualBasic.Left(ClsTools.getNombreDeMaquina, 15)
            getNuevosDatosRegistros.Maquina = Microsoft.VisualBasic.Left(ClsTools.getNombreDeMaquina, 15)
        End Function

        Public Function setRowAccion(Optional ByVal prmOmiteValidacionInsertarRegistroExistente As Boolean = False) As Boolean
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            'Metodo:    setRowAccion

            'Que hace?  Prepara el row con el cual se trabajara para insertar o actualizar segun sea el caso
            '           y decide si se continuara con el proceso
            'Elaboro:   David Adan Velazquez Sanchez


            If Not DAO.LlenaTablaDeDatos(atrSql, atrAdapter, atrTabla) Then
                Return False
            End If

            If atrTabla.Rows.Count = 0 Then
                If atrAccion = EAccionesBD.Modificar OrElse atrAccion = EAccionesBD.Eliminar Then
                    DAO.DeshaceTransaccion()
                    MessageBox.Show("Registro no existente para " & atrAccion.ToString, getNombreFolioAdministrado, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return False
                Else
                    atrRow = atrTabla.NewRow()
                    atrTabla.Rows.Add(atrRow)
                End If
            Else
                If atrAccion = EAccionesBD.Insertar Then
                    'LIC. Jesús Fernando Zamora Angulo
                    'Fecha: 14-08-2010
                    'Si prmOmiteValidacionInsertarRegistroExistente es True... entonces se limpia la tabla y se agrega un registro en blanco
                    'Para intentar obtener nuevamente el folio.
                    If Not prmOmiteValidacionInsertarRegistroExistente Then
                        DAO.DeshaceTransaccion()
                        MessageBox.Show("Registro Existente para Insertar", getNombreFolioAdministrado() + Me.GetType.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Return False
                    Else
                        atrTabla.Rows.Clear()
                        atrRow = atrTabla.NewRow
                        atrTabla.Rows.Add(atrRow)
                    End If
                Else
                    atrRow = atrTabla.Rows(0)
                End If
            End If

            Return True
        End Function

        Public Shared Sub LLenaDatosRegistroComun(ByVal prmRow As DataRow, ByVal atrAccion As EAccionesBD)
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim atrRegistroAlta As New ClsDatosComunesRegistro(DAO.GetLoginUsuario, DAO.RegresaFechaDelSistema, ClsTools.getNombreDeMaquina)
            Dim atrRegistroCancelacion As New ClsDatosComunesRegistro(DAO.GetLoginUsuario, DAO.RegresaFechaDelSistema, ClsTools.getNombreDeMaquina)
            Dim atrRegistroUltimaModificacion As New ClsDatosComunesRegistro(DAO.GetLoginUsuario, DAO.RegresaFechaDelSistema, ClsTools.getNombreDeMaquina)
            If atrAccion = EAccionesBD.Insertar Then
                prmRow("cUsuario_Registro") = atrRegistroAlta.Usuario
                prmRow("dFecha_Registro") = atrRegistroAlta.Fecha
                prmRow("cMaquina_Registro") = atrRegistroAlta.Maquina
            End If

            If atrAccion = EAccionesBD.Modificar Then
                prmRow("cUsuario_UltimaModificacion") = atrRegistroUltimaModificacion.Usuario
                prmRow("dFecha_UltimaModificacion") = atrRegistroUltimaModificacion.Fecha
                prmRow("cMaquina_UltimaModificacion") = atrRegistroUltimaModificacion.Maquina
            End If

            If atrAccion = EAccionesBD.Eliminar Then
                prmRow("cUsuario_Eliminacion") = atrRegistroCancelacion.Usuario
                prmRow("dFecha_Eliminacion") = atrRegistroCancelacion.Fecha
                prmRow("cMaquina_Eliminacion") = atrRegistroCancelacion.Maquina

            End If
        End Sub

        Public Sub LLenaDatosRegistroComun(ByVal prmRow As DataRow)

            'Metodo:    LLenaDatosRegistroComun
            'Que hace?  Alimenta los datos de registro para una estructura de tabla comunes
            'Parametros:prmRow.- instancia de un DataRow el cual proviene de la tabla la cual se actualizara
            '           en este objeto se llenan los datos de registro comunes para dejar huella
            'Elaboro:   David Adan Velazquez Sanchez

            LLenaDatosRegistroComun(prmRow, atrAccion)

            'If atrAccion = EAccionesBD.Insertar Then
            '    If atrRegistroAlta Is Nothing Then
            '        atrRegistroAlta = getNuevosDatosRegistros()
            '    End If
            '    prmRow("cUsuario_Registro") = atrRegistroAlta.Usuario
            '    prmRow("dFecha_Registro") = atrRegistroAlta.Fecha
            '    prmRow("cMaquina_Registro") = atrRegistroAlta.Maquina
            'End If

            'If atrAccion = EAccionesBD.Modificar Then
            '    If RegistroUltimaModificacion Is Nothing OrElse Not atrRegistroUltimaModificacion.InstanciaCorrecta Then
            '        RegistroUltimaModificacion = getNuevosDatosRegistros()
            '    End If

            '    prmRow("cUsuario_UltimaModificacion") = atrRegistroUltimaModificacion.Usuario
            '    prmRow("dFecha_UltimaModificacion") = atrRegistroUltimaModificacion.Fecha
            '    prmRow("cMaquina_UltimaModificacion") = atrRegistroUltimaModificacion.Maquina
            'End If

            'If atrAccion = EAccionesBD.Eliminar Then
            '    If RegistroCancelacion Is Nothing OrElse Not atrRegistroCancelacion.InstanciaCorrecta Then
            '        RegistroCancelacion = getNuevosDatosRegistros()
            '    End If
            '    prmRow("cUsuario_Eliminacion") = atrRegistroCancelacion.Usuario
            '    prmRow("dFecha_Eliminacion") = atrRegistroCancelacion.Fecha
            '    prmRow("cMaquina_Eliminacion") = atrRegistroCancelacion.Maquina

            'End If
        End Sub

        Public Function GuardarGenerico(Optional ByVal registro As Boolean = False, Optional ByVal prmEnviaWS As Boolean = True) As Boolean
            'Metodo:    GuardarGenerico
            'Que hace?  Graba los datos en la tabla dependiendo del tipo de aacion que se tomara
            'Elaboro:   David Adan Velazquez Sanchez

            Dim vTablaTmp As DataTable
            GuardarGenerico = True
            DAO = DataAccessCls.DevuelveInstancia()

            If atrGrabarLocal Then
                If atrAccion = EAccionesBD.Insertar Then
                    vTablaTmp = atrTabla.GetChanges(DataRowState.Added)
                    If Not vTablaTmp Is Nothing Then
                        If DAO.InsertaDatosDeTablaSql(atrAdapter, vTablaTmp) Then
                            GuardarGenerico = True
                        Else
                            Return False
                        End If

                    End If
                End If

                If atrAccion = EAccionesBD.Modificar OrElse atrAccion = EAccionesBD.Eliminar Then
                    vTablaTmp = atrTabla.GetChanges(DataRowState.Modified)
                    If Not vTablaTmp Is Nothing Then
                        If DAO.ActualizaDatosDeTablaSql(atrAdapter, vTablaTmp) Then
                            GuardarGenerico = True
                        Else
                            Return False
                        End If
                    End If
                    vTablaTmp = atrTabla.GetChanges(DataRowState.Deleted)
                    If Not vTablaTmp Is Nothing Then
                        If DAO.EliminaDatosDeTablaSql(atrAdapter, vTablaTmp) Then
                            GuardarGenerico = True
                        Else
                            Return False
                        End If
                    End If
                End If
                Try
                    If Me.EsCorporativo.Invoke And Not registro Then
                        If prmEnviaWS Then
                            ReplicaPlazas()
                        Else
                            atrDS = New DataSet
                            If Not registro Then
                                If atrDS.Tables.Count = 0 Then
                                    Dim dt As New DataTable
                                    dt.Columns.Add("Catalogo", GetType(String))
                                    dt.Columns.Add("FolioAdministrado", GetType(String))
                                    dt.Columns.Add("CampoFolio", GetType(String))
                                    atrDS.Tables.Add(dt)
                                End If


                                Dim dr As DataRow = atrDS.Tables(0).NewRow
                                dr("Catalogo") = atrTabla.TableName
                                dr("FolioAdministrado") = Me.getNombreFolioAdministrado
                                dr("CampoFolio") = atrCampoFolio
                                atrDS.Tables(0).Rows.Add(dr)

                                AgregaTablaDS(atrTabla)
                            End If
                        End If
                    End If
                Catch
                End Try
            Else
                atrDS = New DataSet
                If Not registro Then
                    If atrDS.Tables.Count = 0 Then
                        Dim dt As New DataTable
                        dt.Columns.Add("Catalogo", GetType(String))
                        dt.Columns.Add("FolioAdministrado", GetType(String))
                        dt.Columns.Add("CampoFolio", GetType(String))
                        atrDS.Tables.Add(dt)
                    End If


                    Dim dr As DataRow = atrDS.Tables(0).NewRow
                    dr("Catalogo") = atrTabla.TableName
                    dr("FolioAdministrado") = Me.getNombreFolioAdministrado
                    dr("CampoFolio") = atrCampoFolio
                    atrDS.Tables(0).Rows.Add(dr)

                    AgregaTablaDS(atrTabla)
                End If
            End If
            Return True
        End Function


        Public Sub AgregaTablaDS(ByVal prmDT As DataTable)
            Dim NombreTabla As String = ""
            If atrDS Is Nothing Then
                atrDS = New DataSet
            End If
            For Each tabla As DataTable In atrDS.Tables
                If tabla.TableName = prmDT.TableName Then
                    NombreTabla = tabla.TableName
                End If
            Next
            If NombreTabla = "" Then
                'atrTabla.TableName = atrTabla.TableName
                atrDS.Tables.Add(prmDT)
                'CXC_Adaptadores.Add(vAdaptador)
            Else
                Dim vDataRow As DataRow = prmDT.Rows(0)
                atrTabla.BeginLoadData()
                atrDS.Tables(NombreTabla).LoadDataRow(vDataRow.ItemArray, False)
                atrTabla.EndLoadData()
            End If
        End Sub

        Public Sub ReplicaPlazas()
            atrDS = New DataSet
            If atrDS.Tables.Count = 0 Then
                Dim dt As New DataTable
                dt.Columns.Add("Catalogo", GetType(String))
                dt.Columns.Add("FolioAdministrado", GetType(String))
                dt.Columns.Add("CampoFolio", GetType(String))
                atrDS.Tables.Add(dt)
            End If
            Dim dr As DataRow = atrDS.Tables(0).NewRow
            dr("Catalogo") = atrTabla.TableName
            atrDS.Tables(0).Rows.Add(dr)
            Dim dtcopi As New DataTable
            ClsTools.copiaRows(atrTabla.Select(""), dtcopi, atrTabla.Columns)
            dtcopi.PrimaryKey = atrTabla.PrimaryKey
            dtcopi.TableName = atrTabla.TableName
            atrDS.Tables.Add(dtcopi)

            Dim dtplazas As New DataTable

            DAO.RegresaConsultaSQL("SELECT curlcatalogos FROM WS_PlazaURL (NOLOCK)", dtplazas)
            For Each vrow As DataRow In dtplazas.Rows
                EnviarWs(vrow("curlcatalogos"), True, , , , , True)
            Next
        End Sub

        Public Function AgregaTablaControl(ByRef prmDs As DataSet) As Boolean
            If prmDs Is Nothing Then Return False
            If prmDs.Tables.Count = 0 Then
                Dim dt As New DataTable
                dt.Columns.Add("Catalogo", GetType(String))
                dt.Columns.Add("FolioAdministrado", GetType(String))
                dt.Columns.Add("CampoFolio", GetType(String))
                dt.Columns.Add("cSqlDelete", GetType(String))
                prmDs.Tables.Add(dt)
            End If
            Return True
        End Function

        Public Function ConfiguraDataTableEnviar(ByRef prmDt As DataTable, ByVal prmNombreTabla As String) As Boolean
            If prmDt Is Nothing OrElse prmNombreTabla.Trim = "" Then Return False
            prmDt.TableName = prmNombreTabla.Trim
            Comun.WS.ClsConciliadorWS.RegresaPrimaryKeys(prmDt)
        End Function
        Public Function ReplicaInformacion(ByVal prmEsCorporativo As Boolean, ByRef prmDt As DataTable, ByVal prmCampoLlave As String) As Boolean
            '"nConceptoFlujo"
            Dim miDs As New DataSet

            Dim vcDelete As String = ""
            If prmDt.Rows.Count > 0 Then
                vcDelete = prmDt.Rows(0)(prmCampoLlave)
            End If

            If Not vcDelete.Trim = "" Then
                vcDelete = "DELETE FROM " & prmDt.TableName & " WHERE " & prmCampoLlave & " IN (" & vcDelete.Trim & ")"
            End If

            If Not Me.AgregaTablaControl(miDs) Then Return False

            Dim dr As DataRow = miDs.Tables(0).NewRow
            dr("Catalogo") = prmDt.TableName
            dr("CampoFolio") = prmCampoLlave
            dr("cSqlDelete") = vcDelete.Trim
            miDs.Tables(0).Rows.Add(dr)
            miDs.Tables.Add(prmDt)

            Dim vbResult As Boolean = False

            If Not prmEsCorporativo Then
                vbResult = EnviarWsDataSet(miDs, DAO.ParametroAdministradoObtener("PRM", "WSCORPORATIVO") & DAO.ParametroAdministradoObtener("PRM", "WSCATALOGOS"))
            Else
                Dim dtplazas As New DataTable
                DAO.RegresaConsultaSQL("SELECT curlcatalogos FROM WS_PlazaURL (NOLOCK)", dtplazas)
                For Each vrow As DataRow In dtplazas.Rows
                    vbResult = EnviarWsDataSet(miDs, vrow("curlcatalogos"))
                Next
            End If

            Return vbResult

        End Function

        Public Function EnviarWsDataSet(ByRef prmDs As DataSet, ByVal prmURL As String) As Boolean
            DAO = DataAccessCls.DevuelveInstancia
            Dim wait As New frmStatus
            If prmDs Is Nothing Then
                Return True
            End If
            Dim atrerror As String = ""
            wait.Show("Enviando informacion al Central y Sincronizando Plazas")

            ' ''Dim ws As New WSBaseComun.catalogos
            ' ''ws.Url = prmURL

            ' ''Try
            ' ''    Dim vDT_Url As New DataTable
            ' ''    vDT_Url.TableName = "PLAZA"
            ' ''    vDT_Url.Columns.Add("nPlaza", GetType(Integer))
            ' ''    vDT_Url.Rows.Add(vDT_Url.NewRow)
            ' ''    vDT_Url.Rows(0)("nPlaza") = DAO.ParametroAdministradoObtener("PRMSUC", "PLAZA")
            ' ''    prmDs.Tables.Add(vDT_Url)

            ' ''    If Comunes.Comun.ClsTools.fgExisteLineaWebService(ws.Url, "SELECT GETDATE()") Then
            ' ''        prmDs = ClsTools.deserializaDS(ws.Guardar(ClsTools.SerializaDS(prmDs), atrerror))
            ' ''        If Not prmDs Is Nothing Then
            ' ''            prmDs.Tables.Remove("PLAZA")
            ' ''        End If
            ' ''    End If
            ' ''    wait.Close()
            ' ''Catch ex As Exception
            ' ''    wait.Close()
            ' ''    Return False
            ' ''End Try

            Return True
        End Function

        Public Function EnviarWs(ByVal prmURL As String, Optional ByVal EsCatalogo As Boolean = True, Optional ByVal prmWS As Object = Nothing, Optional ByVal UsaFolioLogico As Boolean = False, Optional ByVal NombreCampoLogico As String = "", Optional ByVal NombreFolioLogico As String = "", Optional ByVal prmGrabaLocal As Boolean = True) As Boolean
            DAO = DataAccessCls.DevuelveInstancia
            Dim wait As New frmStatus
            If atrDS Is Nothing Then
                Return True
            End If
            Dim atrerror As String = ""
            wait.Show("Enviando informacion al Central y Sincronizando Plazas")
            If EsCatalogo Then
                ' ''Dim ws As New WSBaseComun.catalogos

                ' ''ws.Url = prmURL


                ' ''Try
                ' ''    'Return False 'Se comentaria temporalmente, ya que no está disponible el servicio... y el tiempo de espera es muy alto...
                ' ''    If UsaFolioLogico Then
                ' ''        atrerror = NombreCampoLogico & "&" & NombreFolioLogico
                ' ''    End If


                ' ''    ' Dim btCatalogo As Byte() = ClsTools.SerializaDS(atrDS)
                ' ''    Dim vDT_Url As New DataTable

                ' ''    vDT_Url.TableName = "PLAZA"
                ' ''    vDT_Url.Columns.Add("nPlaza", GetType(Integer))
                ' ''    vDT_Url.Rows.Add(vDT_Url.NewRow)
                ' ''    vDT_Url.Rows(0)("nPlaza") = DAO.ParametroAdministradoObtener("PRMSUC", "PLAZA")

                ' ''    atrDS.Tables.Add(vDT_Url)

                ' ''    '  If EnviarWs Then
                ' ''    If Comunes.Comun.ClsTools.fgExisteLineaWebService(ws.Url, "SELECT GETDATE()") Then
                ' ''        atrDS = ClsTools.deserializaDS(ws.Guardar(ClsTools.SerializaDS(atrDS), atrerror))
                ' ''        If Not atrDS Is Nothing Then
                ' ''            atrDS.Tables.Remove("PLAZA")
                ' ''        Else
                ' ''            atrErrorCatalogos = GlobalSistemaLineaCorporativoNO
                ' ''        End If
                ' ''    Else
                ' ''        If prmGrabaLocal Then
                ' ''            atrErrorCatalogos = GlobalSistemaLineaCorporativoNO
                ' ''        Else
                ' ''            atrErrorCatalogos = GlobalSistemaLineaCorporativoNO
                ' ''            wait.Close()
                ' ''            Return False
                ' ''        End If
                ' ''    End If
                ' ''    'End If

                ' ''    'If dtCat Is DBNull.Value Then

                ' ''    '    Return False
                ' ''    'End If
                ' ''    wait.Close()

                ' ''    'If Not ws.GuardarCatalogo(atrDS, atrerror) Then
                ' ''    '    wait.Close()
                ' ''    '    Return False
                ' ''    'End If

                ' ''Catch ex As Exception
                ' ''    wait.Close()
                ' ''    Return False
                ' ''End Try
            Else
                prmWS.Url = prmURL
                Try
                    If Not prmWS.Guardar(ClsTools.SerializaDS(atrDS), atrerror) Then
                        Return False
                        wait.Close()
                    End If
                Catch ex As Exception
                    Return False
                    wait.Close()
                End Try
            End If
            If EsCatalogo And Not prmGrabaLocal Then
                Me.Folio = CLng(atrDS.Tables(1).Rows(atrDS.Tables(1).Rows.Count - 1)(atrCampoFolio))
            End If
            'Else
            'Dim cod As String = ""
            'For Each vrow As DataRow In atrDS.Tables(0).Rows
            '    cod &= vrow(atrCampoFolio) & ","
            'Next
            'If cod.Trim <> "" Then
            '    cod = cod.Substring(0, cod.Length - 1)
            '    If Not DAO.EjecutaComandoSQL("update " & atrDS.Tables(0).TableName & " set bEnviadoCorporativo=1 where " & atrCampoFolio & " in(" & cod & ");") Then
            '        If DAO.TieneTransaccionAbierta Then DAO.DeshaceTransaccion()
            '        wait.Close()
            '        Return False
            '    End If
            'End If
            ' End If
            If Not prmGrabaLocal Then
                For i As Integer = 1 To atrDS.Tables.Count - 1
                    If atrDS.Tables(i).TableName.Trim = "PLAZA" Then
                        Continue For
                    End If
                    Dim filtro As String

                    If atrAccion = EAccionesBD.Insertar Then
                        filtro = " where 1=0"
                    Else
                        filtro = " where " & ClsContenedor.CreaFiltro(atrDS.Tables(i))
                    End If

                    If filtro = " where " Then
                        filtro = ""
                    End If
                    If Not Tool.InsertaYActualizaTablaDeBD(atrDS.Tables(i), filtro) Then
                        wait.Close()
                        Return False
                    End If
                Next
            End If

            wait.Close()
            Return True
        End Function

        'Public Shared Function deserializaDS(ByVal datos() As Byte) As DataSet
        '    Dim ds As DataSet

        '    If Not datos Is Nothing Then
        '        ds = New DataSet
        '        Dim ms As New System.IO.MemoryStream(datos)
        '        ds.ReadXml(ms)
        '    End If

        '    Return ds
        'End Function
        'Public Shared Function SerializaDS(ByRef ds As DataSet) As Byte()
        '    If Not ds Is Nothing Then
        '        Dim ms As New System.IO.MemoryStream
        '        ds.WriteXml(ms, XmlWriteMode.WriteSchema)
        '        Return ms.ToArray
        '    Else
        '        Return Nothing
        '    End If

        ' End Function
        Public Function EnviarWs() As Boolean
            DAO = DataAccessCls.DevuelveInstancia
            If atrGrabarLocal Then
                Return True
            End If
            If EnviarWs(DAO.ParametroAdministradoObtener("PRM", "WSCORPORATIVO") & DAO.ParametroAdministradoObtener("PRM", "WSCATALOGOS"), , , , , , atrGrabarLocal) Then
                Return True
            Else
                Return False
            End If
        End Function


        Public Sub CargaDatosRegistro(ByVal prmRow As DataRow)
            'Metodo:    CargaDatosRegistro
            'Que hace?  Carga los datos de registro existentes en el row
            '           la estructura de registro debe de ser la base
            'Elaboro:   David Adan Velazquez Sanchez
            Try
                atrRegistroAlta = New ClsDatosComunesRegistro(prmRow("cUsuario_Registro"), prmRow("dFecha_Registro"), prmRow("cMaquina_Registro"))
                atrRegistroUltimaModificacion = New ClsDatosComunesRegistro(ClsTools.IfNull(prmRow("cUsuario_UltimaModificacion"), ""), ClsTools.IfNull(prmRow("dFecha_UltimaModificacion"), ClsTools.FechaNulla), ClsTools.IfNull(prmRow("cMaquina_UltimaModificacion"), ""), Not prmRow("cUsuario_UltimaModificacion") Is DBNull.Value)
                atrRegistroCancelacion = New ClsDatosComunesRegistro(ClsTools.IfNull(prmRow("cUsuario_Eliminacion"), ""), ClsTools.IfNull(prmRow("dFecha_Eliminacion"), ClsTools.FechaNulla), ClsTools.IfNull(prmRow("cMaquina_Eliminacion"), ""), Not prmRow("cUsuario_Eliminacion") Is DBNull.Value)
            Catch
            End Try
        End Sub

        Public Function ExistenDatosRelacionados(ByVal prmNombreTabla As String, ByVal prmValor As String) As Boolean
            'Metodo:    Busca Datos Relacionados
            'Que hace?  con el nombre de la tabla se busca  las relaciones existentes
            '           y si existe el valor dado en las tablas relacionadas 

            Dim vlsql As String
            Dim dt As New DataTable
            DAO = DataAccessCls.DevuelveInstancia()
            vlsql = "exec ADSUM_ValidaIntegridadEnTablasDependientes " & "'" & prmNombreTabla & "','" & prmValor & "'"
            DAO.RegresaConsultaSQL(vlsql, dt)
            If Not dt Is Nothing AndAlso dt.Rows.Count = 1 Then
                If dt.Rows(0)("cNombreTabla") = "CTL_ArticulosPresentaciones" Then
                    Return False
                End If
            End If
            Return dt.Rows.Count > 0
            'Return DAO.ExistenDatosEnConsultaSQL(vlsql)

        End Function


        Public Function ExistenDatosRelacionados(ByVal prmrow As DataRow) As Boolean
            If prmrow Is Nothing Then
                Return False
            End If
            If prmrow.Table.PrimaryKey.Length = 0 Then
                Return False
            End If
            Dim armasql As String = ""
            For Each vcol As DataColumn In prmrow.Table.PrimaryKey
                armasql &= vcol.ColumnName & "=" & prmrow(vcol.ColumnName) & " and "
            Next
            armasql = armasql.Substring(0, armasql.Length - 5)

            Return ExistenDatosRelacionados(prmrow.Table.TableName, armasql)
        End Function

        Public Overridable Function GuardarNuevo(Optional ByVal escontenedor As Boolean = False, Optional ByVal CampoyFolioLogico As String = "", Optional ByVal Registro As Boolean = False, Optional ByVal prmEnviaWS As Boolean = True, Optional ByVal prmSoloPideFolioCorporativo As Boolean = False) As Boolean
            If DAO Is Nothing Then
                DAO = DataAccessCls.DevuelveInstancia
            End If

            atrSoloPideFolioAlCorporativo = prmSoloPideFolioCorporativo

            If Not DAO.TieneTransaccionAbierta Then
                ABRIO = True
                DAO.AbreTransaccion()
            End If

            If Not GuardarBase() Then
                If ABRIO Then
                    DAO.DeshaceTransaccion()
                End If
                Return False
            End If

            Dim dttemp As New DataTable
            atrSql = "select " & atrNombreCampos & " from " & atrNombreTabla & "(nolock)"
            DAO.RegresaEsquemaDeDatos(atrSql & " where 1=0", dttemp)

            atrRow = OnObtenerRow(dttemp.NewRow)

            atrSql = atrSql & " where "

            For Each vcol As DataColumn In dttemp.PrimaryKey
                atrSql &= vcol.ColumnName & "=" & ClsTools.IfNull(atrRow(vcol.ColumnName), 0) & " and "
            Next

            atrSql = atrSql.Substring(0, atrSql.Length - 5)


            'atrSql = atrSql & " where " & dttemp.PrimaryKey(0).ColumnName & "=" & atrFolio

            'LIC. Jesús Fernando Zamora Angulo
            'Fecha: 14-08-2010
            'Variable para saber si se reintentará guardar, en caso de querer insertar un registro nuevo que ya exista
            '(Para el caso en que dos o mas usuarios guarden al mismo tiempo y les de el mismo folio.)
            'La finalidad es de que si el folio ya existe, obtengan nuevamente el folio.
            Dim vbReintentaGuardarCuandoFolioNuevoYaExista As Boolean = (escontenedor AndAlso Registro)
            If vbReintentaGuardarCuandoFolioNuevoYaExista Then
                vbReintentaGuardarCuandoFolioNuevoYaExista = ReintentaGuardarCuandoFolioNuevoYaExista
            End If


            If Not setRowAccion(vbReintentaGuardarCuandoFolioNuevoYaExista) Then
                If ABRIO Then
                    DAO.DeshaceTransaccion()
                End If
                Return False
            End If


            OnObtenerRow(atrRow)

            atrTabla.TableName = atrNombreTabla

            If atrAccion = EAccionesBD.Insertar And CampoyFolioLogico.Trim <> "" And atrGrabarLocal Then
                Dim camposfolios() As String = CampoyFolioLogico.Split("&")
                atrRow(camposfolios(0)) = DAO.FolioAdministradoSiguiente(camposfolios(1))
            End If


            'LIC. Jesús Fernando Zamora Angulo
            'Fecha: 14-08-2010
            '************** VALIDAMOS QUE EL REGISTRO QUE VAYAMOS A INSERTAR NO EXISTA EN LA TABLA *********************
            'En caso de existir, se obtiene nuevamente el folio administrado.
            If vbReintentaGuardarCuandoFolioNuevoYaExista Then
                If atrAccion = EAccionesBD.Insertar AndAlso atrGrabarLocal Then
                    Dim vbContinuaCiclo As Boolean = DAO.ExistenDatosEnConsultaSQL(atrSql)
                    While vbContinuaCiclo
                        'Obtenemos folio nuevo
                        atrFolio = DAO.FolioAdministradoSiguiente(getNombreFolioAdministrado())

                        'Obtenemos el esquema de datos de la tabla 
                        Dim vdttemp As New DataTable
                        atrSql = "select " & atrNombreCampos & " from " & atrNombreTabla & "(nolock)"
                        DAO.RegresaEsquemaDeDatos(atrSql & " where 1=0", vdttemp)

                        'Obtenemos un nuevo row con la estructura de la tabla
                        atrRow = OnObtenerRow(vdttemp.NewRow)

                        atrSql = atrSql & " where "

                        For Each vcol As DataColumn In vdttemp.PrimaryKey
                            atrSql &= vcol.ColumnName & "=" & ClsTools.IfNull(atrRow(vcol.ColumnName), 0) & " and "
                        Next

                        atrSql = atrSql.Substring(0, atrSql.Length - 5)

                        'Se llena la tabla atrTabla con el Sql armado (atrSQL)
                        atrTabla = New DataTable

                        If Not setRowAccion() Then
                            If ABRIO Then
                                DAO.DeshaceTransaccion()
                            End If
                            Return False
                        End If

                        'Se llena el row con los datos del objeto a guardar
                        OnObtenerRow(atrRow)

                        atrTabla.TableName = atrNombreTabla

                        'Validamos que el registro a insertar no exista
                        'En caso de no existir nos salimos del ciclo y guardamos
                        'En caso de existir, volvemos a obtener folio....
                        If Not DAO.ExistenDatosEnConsultaSQL(atrSql) Then
                            vbContinuaCiclo = False
                            Exit While
                        End If
                    End While
                End If
            End If
            '***********************************************************************************************************************************

            If Not GuardarGenerico(Registro, prmEnviaWS) Then
                If ABRIO Then
                    DAO.DeshaceTransaccion()
                End If
                Return False
            End If

            If Not atrGrabarLocal And Not escontenedor Then
                If Not EnviarWs() Then
                    If ABRIO Then
                        DAO.DeshaceTransaccion()
                    End If
                    Return False
                End If
            End If

            If ABRIO Then
                DAO.CierraTransaccion()
            End If

            Return True

        End Function


        Public Overrides Function ToString() As String
            Return atrDescripcion
        End Function


    End Class ' ClsBaseComun

End Namespace ' Logical Model