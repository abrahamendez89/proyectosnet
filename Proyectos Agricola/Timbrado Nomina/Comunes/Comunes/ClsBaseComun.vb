
Imports System.Data.SqlClient
Imports System.Data
Imports System.Windows.Forms

Namespace Comunes.Comun
    ' <summary>
    ' Esta clase define los metodos basicos de las clases que maneja la empresa
    ' </summary>
    Public MustInherit Class ClsBaseComun

        Private atrFolio As Long
        Private atrDescripcion As String
        Protected atrActivo As Boolean
        Private atrRegistroAlta As ClsDatosComunesRegistro
        Private atrRegistroCancelacion As ClsDatosComunesRegistro
        Private atrRegistroUltimaModificacion As ClsDatosComunesRegistro

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

        Public Delegate Function ObtenerRowEventHandler(ByRef Row As DataRow, ByVal Clase As Object) As DataRow
        Public ObtenerRow As ObtenerRowEventHandler

        Public Delegate Function GuadarPersozalizadoEventHandler() As Boolean
        Public GuardarPerzonalizadoevent As GuadarPersozalizadoEventHandler


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

            If atrFolio = 0 Then
                atrAccion = EAccionesBD.Insertar

                atrFolio = DAO.FolioAdministradoSiguiente(getNombreFolioAdministrado())

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

        Public Function setRowAccion() As Boolean
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
                    DAO.DeshaceTransaccion()
                    MessageBox.Show("Registro Existente para Insertar", getNombreFolioAdministrado() + Me.GetType.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return False
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

            If atrAccion = EAccionesBD.Insertar Then
                If atrRegistroAlta Is Nothing Then
                    atrRegistroAlta = getNuevosDatosRegistros()
                End If
                prmRow("cUsuario_Registro") = atrRegistroAlta.Usuario
                prmRow("dFecha_Registro") = atrRegistroAlta.Fecha
                prmRow("cMaquina_Registro") = atrRegistroAlta.Maquina
            End If

            If atrAccion = EAccionesBD.Modificar Then
                If RegistroUltimaModificacion Is Nothing OrElse Not atrRegistroUltimaModificacion.InstanciaCorrecta Then
                    RegistroUltimaModificacion = getNuevosDatosRegistros()
                End If

                prmRow("cUsuario_UltimaModificacion") = atrRegistroUltimaModificacion.Usuario
                prmRow("dFecha_UltimaModificacion") = atrRegistroUltimaModificacion.Fecha
                prmRow("cMaquina_UltimaModificacion") = atrRegistroUltimaModificacion.Maquina
            End If

            If atrAccion = EAccionesBD.Eliminar Then
                If RegistroCancelacion Is Nothing OrElse Not atrRegistroCancelacion.InstanciaCorrecta Then
                    RegistroCancelacion = getNuevosDatosRegistros()
                End If
                prmRow("cUsuario_Eliminacion") = atrRegistroCancelacion.Usuario
                prmRow("dFecha_Eliminacion") = atrRegistroCancelacion.Fecha
                prmRow("cMaquina_Eliminacion") = atrRegistroCancelacion.Maquina

            End If
        End Sub

        Public Function GuardarGenerico() As Boolean
            'Metodo:    GuardarGenerico
            'Que hace?  Graba los datos en la tabla dependiendo del tipo de aacion que se tomara
            'Elaboro:   David Adan Velazquez Sanchez

            Dim vTablaTmp As DataTable
            GuardarGenerico = True
            DAO = DataAccessCls.DevuelveInstancia()

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

            DAO = DataAccessCls.DevuelveInstancia()
            vlsql = "exec ADSUM_ValidaIntegridadEnTablasDependientes " & "'" & prmNombreTabla & "','" & prmValor & "'"
            Return DAO.ExistenDatosEnConsultaSQL(vlsql)

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

        Public Overridable Function GuardarNuevo() As Boolean
            If DAO Is Nothing Then
                DAO = DataAccessCls.DevuelveInstancia
            End If
            Dim ABRIO As Boolean
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
                atrSql &= vcol.ColumnName & "=" & atrRow(vcol.ColumnName) & " and "
            Next

            atrSql = atrSql.Substring(0, atrSql.Length - 5)



            'atrSql = atrSql & " where " & dttemp.PrimaryKey(0).ColumnName & "=" & atrFolio

            If Not setRowAccion() Then
                If ABRIO Then
                    DAO.DeshaceTransaccion()
                End If
                Return False
            End If


            OnObtenerRow(atrRow)

            atrTabla.TableName = atrNombreTabla

            If Not GuardarGenerico() Then
                If ABRIO Then
                    DAO.DeshaceTransaccion()
                End If
                Return False
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