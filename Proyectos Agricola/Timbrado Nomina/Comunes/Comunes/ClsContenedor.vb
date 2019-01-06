Namespace Comunes.Comun
    ' <summary>
    ' Por default esta clase contenedora, maneja solo su informaciòn en el datatable
    'Al accesar por primera vez alguno de los elementos del arreglo de objetos se procede a 
    'crear dicha colección(a partir de la informaciòn contenida en el datatable)
    'Esto se realiza de manera transparente para el programador
    ' </summary>
    Public Class ClsContenedor

        Protected atrArreglo As New ArrayList 'Arreglo de clases
        Protected atrArregloDT As New DataTable 'Datatable
        Protected atrbDatosCargadosDT As Boolean 'Esta bandera indica si los datos ya han sido cargados en el DT
        Protected atrbDatosCargadosArray As Boolean 'Esta bandera indica si los datos ya han sido cargados en el arreglo de objetos        

        Protected atrArregloDTBorrados As New DataTable

        '******02-Junio-09********
        'César Niebla:
        'Se agregó programación para contemplar obtenes masivos en contenedores (a implementar en donde sea necesario)
        'y evitar de esta forma se realicen excesivos accesos a BD 
        Protected atrTablasObtenMasivo As New DataSet
        Protected atrUtilizaTablasObtenMasivo As Boolean

        Public Delegate Function ObtenerObjetoEventHandler(ByVal Row As DataRow) As Object
        Public Delegate Function ObtenerObjetoMasivoEventHandler(ByVal Row As DataRow, ByVal vDataSet As DataSet) As Object

        Public Delegate Function ObtenerRowEventHandler(ByRef Row As DataRow, ByVal Clase As Object) As DataRow
        Public Delegate Function ObtenerTablaEventHandler() As DataTable

        Public ObtenerObjeto As ObtenerObjetoEventHandler
        Public ObtenerObjetoMasivo As ObtenerObjetoMasivoEventHandler
        Public ObtenerRow As ObtenerRowEventHandler
        Public ObtenerTabla As ObtenerTablaEventHandler
        Public gbEsCatalogo As Boolean = False

        Public NombreTabla As String = ""
        Public ValorPrimaryKey As String = ""
        Public TablaDiseño As DataTable
        Public NombreFolioControlado As String = ""
        Public ClasePadre As ClsBaseComun2

        Public Property UtilizaTablasObtenMasivo() As Boolean
            Get
                Return atrUtilizaTablasObtenMasivo
            End Get
            Set(ByVal value As Boolean)
                atrUtilizaTablasObtenMasivo = value
            End Set
        End Property

        Public Property ArregloDataTable() As DataTable
            Get
                If Not atrbDatosCargadosDT Then
                    CargaDatatable()
                End If
                Return atrArregloDT
            End Get
            Set(ByVal value As DataTable)
                atrArregloDT = value
            End Set
        End Property

        Public Property TablasObtenMasivo() As DataSet
            Get
                Return atrTablasObtenMasivo
            End Get
            Set(ByVal value As DataSet)
                atrTablasObtenMasivo = value
            End Set
        End Property

        Protected Function OnTabla() As DataTable
            If ObtenerTabla Is Nothing Then
                Return Nothing
            End If

            OnTabla = ObtenerTabla.Invoke()
        End Function


        Protected Function OnObtenerRow(ByRef Row As DataRow, ByVal clase As Object) As DataRow
            If ObtenerRow Is Nothing Then
                Return Nothing
            End If
            If Not Row Is Nothing AndAlso (Not clase Is Nothing) Then
                OnObtenerRow = ObtenerRow.Invoke(Row, clase)
            Else
                Return Nothing
            End If
        End Function


        Protected Function OnObtenerObjeto(ByVal Row As DataRow) As Object
            If (Not Me.ObtenerObjeto Is Nothing) Then
                OnObtenerObjeto = ObtenerObjeto.Invoke(Row)
            Else
                OnObtenerObjeto = Nothing
            End If
        End Function

        Private Sub InsertaElementoEnArray(ByRef PrmItem As DataRow)
            Me.atrArreglo.Add(ObtenerObjeto(PrmItem))
        End Sub

        Private Sub InsertaElementoEnArray(ByRef PrmItem As DataRow, ByRef PrmTablasObtenMasivo As DataSet)
            If Not atrUtilizaTablasObtenMasivo Then
                Me.atrArreglo.Add(ObtenerObjeto(PrmItem))
            Else
                Me.atrArreglo.Add(ObtenerObjetoMasivo(PrmItem, PrmTablasObtenMasivo))
            End If
        End Sub

        Private Sub InsertaElementoEnDatatable(ByRef PrmItem As Object)
            Me.atrArregloDT.Rows.Add(OnObtenerRow(atrArregloDT.NewRow, PrmItem))
        End Sub

        Private Sub InsertaElementoEnDatatableDiseño(ByRef PrmItem As Object)
            Me.TablaDiseño.Rows.Add(OnObtenerRow(atrArregloDT.NewRow, PrmItem))
        End Sub

        'Private Sub SincronizaArregloConDatatable()
        '    For Each vRow As DataRow In Me.ArregloDT.Rows
        '        InsertaElementoEnArray(vRow)
        '    Next

        '    Me.atrbDatosCargadosArray = True
        'End Sub

        '<summary>
        ' Evento que se dispara al darse un cambio de elemento.
        '</summary>
        'Public Event ObtenerObjetoCatalogo As ObtenerObjetoCatalogoEventHandler
        '10-06-08
        'SIP
        ' <summary>
        ' arreglo de objetos        
        ' </summary>
        Private Property Arreglo() As ArrayList
            Get
                Return atrArreglo
            End Get
            Set(ByVal value As ArrayList)
                atrArreglo = value
            End Set
        End Property

        ' <summary>
        ' Contenedor en datatable        
        ' </summary>
        Public Property ArregloDT() As DataTable
            Get
                Return atrArregloDT
            End Get
            Set(ByVal value As DataTable)
                atrArregloDT = value
            End Set
        End Property


        Public Sub New()
            atrArreglo = New ArrayList
            atrArregloDT = New DataTable
            atrArregloDTBorrados = New DataTable
            atrbDatosCargadosDT = False
            atrbDatosCargadosArray = False
        End Sub

        Public Sub New(ByVal prmNombreTabla As String)
            atrArreglo = New ArrayList
            atrArregloDT = New DataTable
            atrArregloDTBorrados = New DataTable
            atrbDatosCargadosDT = False
            atrbDatosCargadosArray = False
            NombreTabla = prmNombreTabla
        End Sub

        Public Sub SincronizaArregloConArray()
            If Not atrbDatosCargadosArray Then
                atrArreglo = New ArrayList
            End If
            If Not atrbDatosCargadosDT Then
                atrArregloDT = OnTabla()
                atrbDatosCargadosDT = True
            End If
            For Each vObj As Object In Me.Arreglo
                InsertaElementoEnDatatable(vObj)
            Next

            Me.atrbDatosCargadosArray = True
        End Sub

        Public Sub SincronizaArregloConDatatable()
            If Not atrbDatosCargadosDT Then
                atrArregloDT = OnTabla()
                atrbDatosCargadosDT = True
            End If

            If Not Me.ArregloDT Is Nothing Then
                For Each vRow As DataRow In Me.ArregloDT.Rows
                    If Not atrUtilizaTablasObtenMasivo Then
                        InsertaElementoEnArray(vRow)
                    Else
                        InsertaElementoEnArray(vRow, atrTablasObtenMasivo)
                    End If
                Next
            End If
            Me.atrbDatosCargadosArray = True
        End Sub

        Public ReadOnly Property Count() As Integer
            Get
                If atrArregloDT Is Nothing Then
                    atrArregloDT = New DataTable
                End If

                Return atrArregloDT.Rows.Count
            End Get
        End Property

        Public Function InicializarBD(Optional ByVal ColumnaExcepcion As String = "NRENGLON", Optional ByVal ColumnaLlave As String = "") As Boolean
            If ArregloDataTable.Rows.Count > 0 Then
                If atrArregloDT.PrimaryKey.Length > 0 Then
                    Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
                    Dim sql As String = "delete from " & atrArregloDT.TableName & " where "
                    Dim llave() As DataColumn = atrArregloDT.PrimaryKey
                    'For Each vrow As DataRow In atrArregloDTBorrados.Rows
                    Dim armasql As String = sql
                    If ColumnaLlave.Trim = "" Then
                        For Each vcol As DataColumn In llave
                            If vcol.ColumnName.ToUpper <> ColumnaExcepcion.ToUpper Then
                                armasql &= vcol.ColumnName & "=" & atrArregloDT.Rows(0)(vcol.ColumnName) & " and "
                            End If
                        Next
                        armasql = armasql.Substring(0, armasql.Length - 5)
                        'Next
                    Else
                        armasql &= atrArregloDT.Columns(ColumnaLlave).ColumnName & "=" & atrArregloDT.Rows(0)(atrArregloDT.Columns(ColumnaLlave).ColumnName)
                    End If
                    If Not DAO.EjecutaComandoSQL(armasql) Then
                        Return False
                    End If
                End If

            End If
            Return True
        End Function

        Public Sub Inicializar(Optional ByVal borrados As Boolean = True, Optional ByVal Cargados As Boolean = False)
            atrArreglo.Clear()
            If atrArregloDT.Columns.Count = 0 Then
                atrbDatosCargadosDT = False
            End If
            ArregloDataTable.Rows.Clear()
            If borrados Then
                atrArregloDTBorrados.Rows.Clear()
            End If
            atrbDatosCargadosDT = Cargados
            atrbDatosCargadosArray = Cargados
        End Sub

        Public Sub InicializaTablaDiseño()
            TablaDiseño = New DataTable
            ClsTools.copiaRows(ArregloDataTable.Select("1=0"), TablaDiseño, ArregloDataTable.Columns)
        End Sub

        Public Sub AgregarDiseño(ByVal prmObject As Object)
            If TablaDiseño Is Nothing Then
                InicializaTablaDiseño()
            End If
            TablaDiseño.Rows.Add(OnObtenerRow(TablaDiseño.NewRow, prmObject))
        End Sub

        Public Sub Agregar(ByVal prmObject As Object)
            If Not atrbDatosCargadosArray Then
                SincronizaArregloConArray()
            End If

            'Agrega al Array list
            'prmObject.GuardarBase()
            atrArreglo.Add(prmObject)
        End Sub

        Public Sub Agregar(ByVal prmRow As DataRow)
            'Agrega al Datatable
            atrArregloDT.Rows.Add(prmRow)
        End Sub

        Protected Function ObtenerAt(ByVal Index As Integer) As Object
            If Not Me.atrbDatosCargadosArray Then
                SincronizaArregloConDatatable()
            End If
            'Obtener del arraylist
            If Index >= 0 AndAlso Index < atrArreglo.Count Then
                Return atrArreglo(Index)
            End If
            Return Nothing
        End Function

        Protected Sub CargaDatatable()
            atrbDatosCargadosDT = True
            If Not OnTabla() Is Nothing Then
                atrArregloDT = OnTabla()
                If Not atrArregloDT Is Nothing Then
                    ClsTools.copiaRows(atrArregloDT.Select("1=0"), atrArregloDTBorrados, atrArregloDT.Columns)
                Else
                    atrbDatosCargadosDT = False

                End If
            ElseIf Not NombreTabla.Trim = "" Then
                Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
                DAO.RegresaEsquemaDeDatos("select * from " & NombreTabla & " where 1=0", atrArregloDT)
                DAO.RegresaConsultaSQL("select * from " & NombreTabla & " where " & ValorPrimaryKey, atrArregloDT)
                ClsTools.copiaRows(atrArregloDT.Select("1=0"), atrArregloDTBorrados, atrArregloDT.Columns)
            Else
                atrbDatosCargadosDT = False
            End If

        End Sub


        Protected Function ObtenerAt(ByVal Index As Long) As DataRow
            If atrArregloDT Is Nothing Then
                Return Nothing
            End If
            If atrArregloDT.Rows.Count = 0 Then
                CargaDatatable()
            End If
            'Obtener del Datatable
            If Index >= 0 AndAlso Index < atrArregloDT.Rows.Count Then
                Return atrArregloDT(Index)
            End If
            Return Nothing
        End Function

        Public Overridable Function Guardar(Optional ByVal PorClases As Boolean = True, Optional ByVal Directo As Boolean = False, Optional ByVal WebService As Boolean = False) As Boolean
            'If Not GuardarBorrados() Then
            '    Return False
            'End If
            Dim CampoFolio As String = NombreFolioControlado

            If Not TablaDiseño Is Nothing Then
                If Not MarcaActivosInactivos() Then
                    Return False
                End If
            End If
            If Not ClasePadre Is Nothing Then
                'If Not ClasePadre.atrGrabarLocal Then
                If Not ClasePadre.atrDS Is Nothing Then
                    If ClasePadre.atrDS.Tables.Count > 0 Then
                        Dim dr As DataRow = ClasePadre.atrDS.Tables(0).NewRow
                        dr("Catalogo") = NombreTabla
                        If atrArregloDT.Rows.Count > 0 Then
                            Dim vObjGeneral As Object
                            Try
                                vObjGeneral = ObtenerObjeto(atrArregloDT.Rows(0))
                            Catch ex As Exception
                                vObjGeneral = Nothing
                            End Try

                            If Not vObjGeneral Is Nothing Then
                                dr("FolioAdministrado") = ObtenerObjeto(atrArregloDT.Rows(0)).getNombreFolioAdministrado()
                            Else
                                dr("FolioAdministrado") = NombreTabla
                            End If

                        End If
                        dr("CampoFolio") = CampoFolio
                        ClasePadre.atrDS.Tables(0).Rows.Add(dr)
                    End If
                End If
                'End If
            End If

            If PorClases Then
                If atrArreglo.Count <> atrArregloDT.Rows.Count Then
                    If atrArreglo.Count < atrArregloDT.Rows.Count Then
                        atrbDatosCargadosArray = False
                        SincronizaArregloConDatatable()
                    End If
                End If
                For Each vBase As Object In atrArreglo.ToArray()
                    If Not vBase.Guardar Then
                        Return False
                    End If
                Next
            Else
                If NombreTabla.Trim = "" Then
                    Return False
                End If
                atrArregloDT.TableName = NombreTabla
                Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
                If Not Directo Then
                    If atrArreglo.Count <> atrArregloDT.Rows.Count Then
                        If atrArreglo.Count > atrArregloDT.Rows.Count Then
                            atrbDatosCargadosDT = False
                            SincronizaArregloConArray()
                        End If
                    End If
                Else
                    If Arreglo.Count > 0 Then
                        atrArregloDT.Rows.Clear()
                        SincronizaArregloConArray()
                    End If
                End If
                'Dim dttemp As New DataTable
                'DAO.RegresaEsquemaDeDatos("select * from " & NombreTabla & " where 1=0", dttemp)
                'ClsTools.copiaRows(atrArregloDT.Select(""), dttemp)

                If atrArregloDT.Rows.Count > 0 Then
                    atrArregloDT.TableName = NombreTabla
                    If Not WebService Then
                        Dim filtro As String = " where " & CreaFiltro(atrArregloDT)
                        If filtro = " where " Then filtro &= " 1 = 1 "
                        If Not Tool.InsertaYActualizaTablaDeBD(atrArregloDT, filtro) Then
                            Return False
                        End If
                        If gbEsCatalogo Then
                            Try
                                ClasePadre.atrDS.Tables.Add(atrArregloDT)
                            Catch EX As Exception
                                ClasePadre.atrDS.Tables.Remove(atrArregloDT)
                                ClasePadre.atrDS.Tables.Add(atrArregloDT)
                            End Try
                        End If
                    Else
                        If gbEsCatalogo Then
                            Try
                                ClasePadre.atrDS.Tables.Add(atrArregloDT)
                            Catch
                                If Not ClasePadre.atrDS Is Nothing Then
                                    ClasePadre.atrDS.Tables.Remove(atrArregloDT)
                                    ClasePadre.atrDS.Tables.Add(atrArregloDT)
                                End If
                            End Try
                        End If
                    End If
                End If
            End If
            Return True
        End Function


        Public Shared Function CreaFiltroWS(ByRef prmDt As DataTable, Optional ByVal CampoExclusion As String = "nRenglon") As String
            If prmDt.PrimaryKey Is Nothing OrElse prmDt.PrimaryKey.Length = 0 Then Return ""
            If prmDt.PrimaryKey.Length = 1 Then
                For Each col As DataColumn In prmDt.PrimaryKey
                    If col.ColumnName.Trim.ToUpper = CampoExclusion.Trim.ToUpper Then Return ""
                Next
            End If


            Dim vcRet As String = ""
            Dim vMiDtTemp As New DataTable
            Dim vcTemp As String = ""
            Dim vcTempDelete As String = ""
            Dim dr As DataRow
            Dim vColRow() As DataRow
            Dim vbHayDatos As Boolean = True

            Dim vColPrimaryKeys() As DataColumn = Comun.WS.ClsConciliadorWS.RegresaPrimaryKeys(prmDt.TableName)

            ClsTools.copiaRows(prmDt.Select(""), vMiDtTemp, prmDt.Columns)

            vbHayDatos = vMiDtTemp.Rows.Count > 0

            While vbHayDatos
                dr = vMiDtTemp.Rows(0)
                vcTemp = ""
                vcTempDelete = ""
                vcTemp &= "("
                vcTempDelete &= "("
                For Each col As DataColumn In vColPrimaryKeys
                    If col.ColumnName.Trim.ToUpper = CampoExclusion.Trim.ToUpper Then Continue For
                    Select Case col.DataType.FullName.ToUpper
                        Case "System.DateTime".ToUpper
                            vcTemp &= col.ColumnName.Trim & " =  cast('" & Comun.WS.ClsConciliadorWS.FormateaFechaDeXML(dr(col.ColumnName.Trim)) & "' as DateTime) AND "
                        Case Else
                            vcTemp &= col.ColumnName.Trim & " = '" & dr(col.ColumnName.Trim) & "' AND "
                    End Select
                    vcTempDelete &= col.ColumnName.Trim & " = '" & dr(col.ColumnName.Trim) & "' AND "
                Next
                vcTemp = vcTemp.Trim.Substring(0, vcTemp.Trim.Length - 3)
                vcTempDelete = vcTempDelete.Trim.Substring(0, vcTempDelete.Trim.Length - 3)
                vcTemp &= ") "
                vcTempDelete &= ") "

                vColRow = vMiDtTemp.Select(vcTempDelete)
                For Each miDr As DataRow In vColRow
                    miDr.Delete()
                Next
                vMiDtTemp.AcceptChanges()

                vcRet &= vcTemp & " OR "

                vbHayDatos = vMiDtTemp.Rows.Count > 0
            End While

            If Not vcRet.Trim = "" Then
                vcRet = vcRet.Trim.Substring(0, vcRet.Trim.Length - 2)
            End If


            Return vcRet
        End Function

        Public Shared Function CreaFiltro(Optional ByVal dt As DataTable = Nothing, Optional ByVal CampoExclusion As String = "NRENGLON") As String

            Dim ret As String = ""
            If dt.PrimaryKey.Length > 0 Then
                For Each drow As DataRow In dt.Rows
                    For Each vcol As DataColumn In dt.PrimaryKey
                        If vcol.ColumnName.ToUpper.Trim = CampoExclusion Then
                            Exit For
                        End If
                        Dim dtt As DataTable = ClsTools.SelectDistinct(dt.TableName, dt, vcol.ColumnName)
                        Dim key(0) As DataColumn
                        key(0) = dtt.Columns(0)
                        Try
                            dtt.PrimaryKey = key
                        Catch
                            dtt.PrimaryKey = Nothing
                        End Try
                        For Each vrow As DataRow In dtt.Select(vcol.ColumnName & "='" & drow(vcol.ColumnName) & "'")
                            Dim stemp As String = ArmaLlaveConsulta(vrow)
                            If stemp.Trim <> "" Then
                                ret &= stemp & " and "
                            End If

                        Next
                    Next
                    If ret.Trim <> "" Then
                        ret = ret.Substring(0, ret.Length - 5)
                    End If
                    ret &= " or "
                Next
                If ret.Trim <> "" Then
                    ret = ret.Substring(0, ret.Length - 4)
                End If
            Else
                ret = ""
            End If


            Return ret
        End Function

        Public Overridable Function GuardarBorrados() As Boolean
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim sql As String = "delete from " & atrArregloDT.TableName & " where "
            Dim llave() As DataColumn = atrArregloDT.PrimaryKey
            For Each vrow As DataRow In atrArregloDTBorrados.Rows
                Dim armasql As String = sql
                For Each vcol As DataColumn In llave
                    armasql &= vcol.ColumnName & "=" & vrow(vcol.ColumnName) & " and "
                Next
                armasql = armasql.Substring(0, armasql.Length - 5)
                If Not DAO.EjecutaComandoSQL(armasql) Then
                    Return False
                End If
            Next
            Return True
        End Function

        Public Overridable Function Remover(ByVal index As Integer) As Boolean
            Dim atrRow As DataRow
            'Se elimina de ambas estructuras
            atrRow = atrArregloDT.Rows.Item(index)

            '1.-ArrayList
            If ExistenDatosRelacionados(NombreTabla, ObtenerObjeto(atrRow).folio) Then
                Return False
            End If
            atrArreglo.RemoveAt(index)

            '2.-Datatable
            ClsTools.copiaRows(atrRow, atrArregloDTBorrados, atrArregloDT.Columns)
            atrArregloDT.Rows.RemoveAt(index)
            atrArregloDT.AcceptChanges()

            Return True
        End Function

        Public Function Items() As Object
            If Not Me.atrbDatosCargadosArray Then
                SincronizaArregloConDatatable()
            End If

            Return atrArreglo.ToArray  '.ToArray(GetType(Dominio.Catalogos.Proveedores.ClsProveedorArticulos))
        End Function

        Public Function ItemsDT() As DataRowCollection
            Return atrArregloDT.Rows
        End Function

        Public Function ExistenDatosRelacionados(ByVal prmNombreTabla As String, ByVal prmValor As String) As Boolean
            'Metodo:    Busca Datos Relacionados
            'Que hace?  con el nombre de la tabla se busca  las relaciones existentes
            '           y si existe el valor dado en las tablas relacionadas 

            Dim vlsql As String
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            DAO = DataAccessCls.DevuelveInstancia()
            vlsql = "exec ADSUM_ValidaIntegridadEnTablasDependientes " & "'" & prmNombreTabla & "','" & prmValor & "'"
            Return DAO.ExistenDatosEnConsultaSQL(vlsql)

            'True es que existen datos relacionados y no deberia borrarse
            'False es que si se puede borrar

        End Function

        Public Function ExistenDatosRelacionados(ByVal prmrow As DataRow, ByVal prmvalores As DataRow) As Boolean
            If prmrow.Table.PrimaryKey.Length = 0 Then
                Return False
            End If
            Dim armasql As String = ""
            For Each vcol As DataColumn In prmrow.Table.PrimaryKey
                armasql &= vcol.ColumnName & "=" & prmvalores(vcol.ColumnName) & " and a."
            Next
            armasql = armasql.Substring(0, armasql.Length - 7)

            Return ExistenDatosRelacionados(prmrow.Table.TableName, armasql)
        End Function

        Public Function ExistenDatosRelacionados(ByVal prmrow As DataRow) As Boolean
            'prmrow.Table.PrimaryKey 
            If prmrow.Table.PrimaryKey.Length = 0 Then
                Return False
            End If
            Dim armasql As String = ""
            For Each vcol As DataColumn In prmrow.Table.PrimaryKey
                armasql &= vcol.ColumnName & "=" & prmrow(vcol.ColumnName) & " and a."
            Next
            armasql = armasql.Substring(0, armasql.Length - 7)

            Return ExistenDatosRelacionados(prmrow.Table.TableName, armasql)
        End Function

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub

        Public Function BorrarVerificandoDependencias() As Boolean
            Dim DatosenSql As New DataTable
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            If Not OnTabla() Is Nothing Then
                DatosenSql = OnTabla()
            ElseIf Not NombreTabla.Trim = "" Then
                DAO.RegresaEsquemaDeDatos("select * from " & NombreTabla & " where 1=0", DatosenSql)
                DAO.RegresaConsultaSQL("select * from " & NombreTabla & " where " & ValorPrimaryKey, DatosenSql)
            Else
                Return False
            End If

            If DatosenSql.Rows.Count > 0 Then
                For Each vrow As DataRow In DatosenSql.Rows
                    If atrArregloDT.Select(ArmaLlaveConsulta(vrow)).Length = 0 Then
                        If Not ExistenDatosRelacionados(vrow) Then
                            If Not DAO.EjecutaComandoSQL("delete " & vrow.Table.TableName & " where " & ArmaLlaveConsulta(vrow)) Then
                                Return False
                            End If
                        End If
                    End If
                Next
            End If
            Return True
        End Function

        Public Shared Function ArmaLlaveConsulta(ByVal prmrow As DataRow, Optional ByVal prmrowvalores As DataRow = Nothing) As String
            If prmrow.Table.PrimaryKey.Length = 0 Then
                Return ""
            End If
            Dim armasql As String = ""
            Dim vrow As DataRow
            If prmrowvalores Is Nothing Then
                vrow = prmrow
            Else
                vrow = prmrowvalores
            End If
            For Each vcol As DataColumn In prmrow.Table.PrimaryKey
                armasql &= vcol.ColumnName & "='" & vrow(vcol.ColumnName) & "' and "
            Next
            armasql = armasql.Substring(0, armasql.Length - 5)
            Return armasql
        End Function

        Public Function MarcaActivosInactivos(Optional ByVal prmCampoActivo As String = "bactivo") As Boolean
            ' atrbDatosCargadosDT = False
            For Each vrow As DataRow In ArregloDataTable.Rows
                If TablaDiseño.Select(ArmaLlaveConsulta(vrow)).Length = 0 Then
                    vrow(prmCampoActivo) = False
                Else
                    vrow(prmCampoActivo) = True
                End If
            Next

            If Not ClasePadre Is Nothing Then
                If Not ClasePadre.atrGrabarLocal Then
                    If NombreFolioControlado.Trim <> "" Then
                        Dim cont As Integer = 0
                        For Each VROW As DataRow In TablaDiseño.Rows
                            If VROW(NombreFolioControlado) Is DBNull.Value Then
                                VROW(NombreFolioControlado) = cont
                                cont = cont - 1
                            End If
                        Next
                    End If
                    NombreFolioControlado = ""
                End If
            End If

            For Each vrow As DataRow In TablaDiseño.Rows 'Select(NombreFolioControlado & "=0")
                Dim tempobj As Object
                If NombreFolioControlado.Trim <> "" Then
                    If vrow(NombreFolioControlado) Is DBNull.Value OrElse vrow(NombreFolioControlado) = 0 Then
                        If vrow(NombreFolioControlado) Is DBNull.Value Then
                            vrow(NombreFolioControlado) = 0
                        End If
                        tempobj = ObtenerObjeto(vrow)
                        If Not tempobj.GuardarBase() Then
                            Return False
                        End If
                        ObtenerRow(vrow, tempobj)
                        ClsTools.copiaRows(vrow, atrArregloDT)
                    End If
                Else
                    If atrArregloDT.Rows.Count > 0 Then
                        Try
                            If atrArregloDT.Select(ArmaLlaveConsulta(atrArregloDT.Rows(0), vrow)).Length = 0 Then
                                'tempobj = ObtenerObjeto(vrow)
                                ClsTools.copiaRows(vrow, atrArregloDT)
                            End If
                        Catch
                            If atrArregloDT.PrimaryKey.Count > 0 Then
                                Dim vkey(atrArregloDT.PrimaryKey.Count - 1) As Object
                                For z As Integer = 0 To atrArregloDT.PrimaryKey.Count - 1
                                    vkey(z) = vrow(atrArregloDT.PrimaryKey(z).Caption)
                                Next
                                If Not atrArregloDT.Rows.Find(vkey) Is Nothing Then
                                    ClsTools.copiaRows(vrow, atrArregloDT)
                                End If
                            End If
                        End Try
                    Else
                        ClsTools.copiaRows(vrow, atrArregloDT)
                    End If
                    'ObtenerRow(vrow, tempobj)
                End If
                If atrArregloDT.Rows.Count > 0 Then
                    Try
                        If atrArregloDT.Select(ArmaLlaveConsulta(atrArregloDT.Rows(0), vrow)).Length > 0 Then
                            Dim vrow2 As DataRow = atrArregloDT.Select(ArmaLlaveConsulta(atrArregloDT.Rows(0), vrow))(0)
                            For i As Integer = 0 To vrow2.ItemArray.Length - 1
                                vrow2(i) = vrow(i)
                            Next
                        End If
                    Catch
                        If atrArregloDT.PrimaryKey.Count > 0 Then
                            Dim vkey(atrArregloDT.PrimaryKey.Count - 1) As Object
                            For z As Integer = 0 To atrArregloDT.PrimaryKey.Count - 1
                                vkey(z) = vrow(atrArregloDT.PrimaryKey(z).Caption)
                            Next
                            If Not atrArregloDT.Rows.Find(vkey) Is Nothing Then
                                Dim vrow2 As DataRow = atrArregloDT.Rows.Find(vkey)
                                For i As Integer = 0 To vrow.ItemArray.Length - 1
                                    vrow2(i) = vrow(i)
                                Next
                            End If
                        End If
                    End Try
                End If
            Next



            If atrArregloDT.Rows.Count = 0 Then
                ClsTools.copiaRows(TablaDiseño.Select(""), atrArregloDT)
            End If
            atrArregloDT.AcceptChanges()
            Return True
        End Function

    End Class ' Comunes.Comun

End Namespace