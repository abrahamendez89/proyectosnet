Imports Access.Dominio.Catalogos
Imports Access.Comunes.Comun
Imports Access

Namespace Comunes.Comun.Permisos
    Public Class ClsManejadorPermisos
        Private Shared DAO As DataAccessCls

        'Datos sobre los permisos del usuario
        Private atrObjPermisos As ConfiguracionPermisos.ClsPermisoSistema
        'Validaciones
        Private atrCargoCorrectoATXPrincipal As Boolean = False
        Private atrCargoCorrectoSecundario As Boolean = False
        Private atrTipoConstructor As TC
        'ATX PRINCIPAL
        Private atrATXPrincipal As AccTextBoxAdvanced
        Private atrATXPrincipalTieneCampobActivo As Boolean = False
        'ATX SECUNDARIO

        Private atrPermiteModificarATXPrincipal As Boolean = False

        Private Enum TC
            Principal = 0
            Secundario = 1
        End Enum

        Public ReadOnly Property UsuarioTienePermisos() As Boolean
            Get
                Return FlUsuarioTienePermisos()
            End Get
        End Property
        Public ReadOnly Property PermiteModificarATXPrincipal() As Boolean
            Get
                If Not atrTipoConstructor = TC.Principal Then Return False
                If Not atrCargoCorrectoATXPrincipal Then Return False
                Return Not atrObjPermisos.BloqueaATX
            End Get
        End Property
        Public ReadOnly Property EsPermisoPrincipal() As Boolean
            Get
                Return atrTipoConstructor = TC.Principal
            End Get
        End Property

        Public Sub MuestraMensajeUsuarioSinPermisos()
            ClsTools.MuestraMensajeSistFact("El usuario no tiene permisos asignados", Windows.Forms.MessageBoxIcon.Information)
        End Sub

        Private Function FlUsuarioTienePermisos() As Boolean
            If atrObjPermisos Is Nothing Then Return False
            If atrObjPermisos.Permiso.Trim = "" Then Return False
            Return True
        End Function

        Public Sub New(ByVal prmTipoPermiso As Int32, ByVal prmUsuario As String, ByRef prmATXPrincipal As AccTextBoxAdvanced, ByVal prmTieneCampobActivo As Boolean)
            atrObjPermisos = ConfiguracionPermisos.FabricaPermisos.ObtenPermisosSistema(prmTipoPermiso, prmUsuario)
            atrATXPrincipal = prmATXPrincipal
            atrATXPrincipalTieneCampobActivo = prmTieneCampobActivo
            atrTipoConstructor = TC.Principal
            atrCargoCorrectoATXPrincipal = True
            If atrObjPermisos Is Nothing OrElse prmATXPrincipal Is Nothing _
            OrElse prmATXPrincipal.CatalogoBase Is Nothing Then atrCargoCorrectoATXPrincipal = False
            If Not atrCargoCorrectoATXPrincipal Then
                If Not prmATXPrincipal Is Nothing AndAlso Not prmATXPrincipal.CatalogoBase Is Nothing Then
                    prmATXPrincipal.CatalogoBase.FiltroExtendido = "1 = 0"
                End If
            End If
        End Sub
        Public Sub New(ByVal prmTipoPermiso As Int32, ByVal prmUsuario As String)
            atrObjPermisos = ConfiguracionPermisos.FabricaPermisos.ObtenPermisosSistema(prmTipoPermiso, prmUsuario)
            atrTipoConstructor = TC.Secundario
            atrCargoCorrectoSecundario = True
            If atrObjPermisos Is Nothing Then atrCargoCorrectoSecundario = False
        End Sub


        Private Function ConfiguraCatalogoPrincipal() As Boolean
            If atrATXPrincipal.CatalogoBase.FiltroExtendido Is Nothing Then atrATXPrincipal.CatalogoBase.FiltroExtendido = ""
            atrATXPrincipal.CatalogoBase.FiltroExtendido = FlRegresaFiltroExtendidoPrincipal(atrATXPrincipal.CatalogoBase.FiltroExtendido)
            Return True
        End Function
        Private Function FlRegresaFiltroExtendidoPrincipal(ByVal prmFiltroActual As String) As String
            Dim vcFiltro As String = prmFiltroActual.Trim
            If vcFiltro = Nothing Then vcFiltro = ""
            Dim vcbActivo As String = " 1 = 1 "
            If atrATXPrincipalTieneCampobActivo Then vcbActivo = " bActivo = 1 "
            If vcFiltro = "" Then
                vcFiltro = vcbActivo & " AND " & atrObjPermisos.TipoPermiso.CampoFiltrado.Trim & " IN (" & atrObjPermisos.Permiso & ") "
            Else
                vcFiltro &= " AND " & vcbActivo & " AND " & atrObjPermisos.TipoPermiso.CampoFiltrado.Trim & " IN (" & atrObjPermisos.Permiso & ") "
            End If
            Return vcFiltro
        End Function
        Private Function FlRegresaFiltroExtendidoSecundario(ByRef prmCatalogoBase As Catalogo, ByVal prmTienebActivo As Boolean) As String
            Dim vcFiltro As String = prmCatalogoBase.FiltroExtendido.Trim
            If vcFiltro = Nothing Then vcFiltro = ""
            Dim vcbActivo As String = " 1 = 1 "
            If prmTienebActivo Then vcbActivo = " bActivo = 1 "
            If vcFiltro = "" Then
                vcFiltro = vcbActivo & " AND " & atrObjPermisos.TipoPermiso.CampoFiltrado.Trim & " IN (" & atrObjPermisos.Permiso & ") "
            Else
                vcFiltro &= " AND " & vcbActivo & " AND " & atrObjPermisos.TipoPermiso.CampoFiltrado.Trim & " IN (" & atrObjPermisos.Permiso & ") "
            End If
            If Not atrATXPrincipal Is Nothing AndAlso Not atrATXPrincipal.Text.Trim = "" AndAlso Not atrATXPrincipal.Text.Trim = "*" Then
                vcFiltro &= " AND " & atrObjPermisos.TipoPermiso.CampoFiltrado.Trim & " IN (" & atrATXPrincipal.Text.Trim & ") "
            End If
            Return vcFiltro
        End Function

        Public Function InicializaATXPrincipal(Optional ByVal prmValidaBloqueo As Boolean = True, Optional ByVal prmValidaValorDefault As Boolean = True, Optional ByVal prmConfiguraFiltroExtendido As Boolean = True, Optional ByVal prmInicializaFiltroExtendido As Boolean = False) As Boolean
            If Not atrTipoConstructor = TC.Principal Then Return False
            If Not atrCargoCorrectoATXPrincipal Then Return False
            'atrATX.Text = Format(atrTipoArticulo.Folio, "000")
            'atrATX.ControlDestinoDescripcion.Text = atrTipoArticulo.Descripcion.ToUpper
            If prmValidaValorDefault Then
                If Not atrObjPermisos.ValorDefault = "" Then
                    atrATXPrincipal.SetTextBoxValue(atrObjPermisos.ValorDefault)
                End If
            End If
            If prmValidaBloqueo Then atrATXPrincipal.Enabled = Not atrObjPermisos.BloqueaATX
            If Not prmConfiguraFiltroExtendido Then Return True
            If prmInicializaFiltroExtendido Then atrATXPrincipal.CatalogoBase.FiltroExtendido = ""
            Return ConfiguraCatalogoPrincipal()
        End Function
        Public Function ValidaElementoEnATXPrincipal() As Boolean
            If Not atrTipoConstructor = TC.Principal Then Return False
            If Not atrCargoCorrectoATXPrincipal Then Return False
            If atrATXPrincipal Is Nothing OrElse atrATXPrincipal.CatalogoBase Is Nothing Then Return False
            If atrATXPrincipal.Text.Trim = "" Then Return True
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vcWHERE As String = " WHERE 1 = 1"
            Dim vcSQL As String = "SELECT 1 FROM " & atrATXPrincipal.CatalogoBase.MetaCatalogoBase.SqlVistaCatalogo & " (NOLOCK) " & vbCr
            If Not atrATXPrincipal.CatalogoBase.FiltroExtendido Is Nothing AndAlso Not atrATXPrincipal.CatalogoBase.FiltroExtendido = "" Then
                vcWHERE &= " AND " & atrATXPrincipal.CatalogoBase.FiltroExtendido.Trim & vbCr
            End If
            vcWHERE &= " AND " & atrATXPrincipal.CatalogoBase.MetaCatalogoBase.CampoPrimario & " = " & atrATXPrincipal.Text.Trim
            vcSQL &= vcWHERE
            If Not DAO.ExistenDatosEnConsultaSQL(vcSQL) Then
                atrATXPrincipal.SetTextBoxValue("")
                If Not atrATXPrincipal.ControlDestinoDescripcion Is Nothing Then atrATXPrincipal.ControlDestinoDescripcion.Text = ""
                Return False
            Else
                atrATXPrincipal.SetTextBoxValue(atrATXPrincipal.Text.Trim)
            End If
            Return True
        End Function
        Public Function ValidaTengaPermiso(ByVal prmValor As String) As Boolean
            If atrTipoConstructor = TC.Principal AndAlso Not atrCargoCorrectoATXPrincipal Then Return False
            If atrTipoConstructor = TC.Secundario AndAlso Not atrCargoCorrectoSecundario Then Return False
            If prmValor.Trim = "" Then Return False
            If atrObjPermisos.Permiso.Trim = "" Then Return False
            For Each vcStr As String In atrObjPermisos.Permiso.Trim.Split(",")
                If CInt(vcStr.Trim) = CInt(prmValor.Trim) Then
                    Return True
                End If
            Next
            Return False
        End Function
        Public Function ConfiguraCatalogoSecundario(ByRef prmCatalogoBase As Catalogo, Optional ByVal prmTienebActivo As Boolean = False, Optional ByVal prmInicializarFiltro As Boolean = False) As Boolean
            If prmCatalogoBase Is Nothing Then Return False
            Select Case atrTipoConstructor
                Case TC.Principal
                    If Not atrCargoCorrectoATXPrincipal Then
                        prmCatalogoBase.FiltroExtendido = " 1 = 0 "
                        Return False
                    End If
                Case TC.Secundario
                    If Not atrCargoCorrectoSecundario Then
                        prmCatalogoBase.FiltroExtendido = " 1 = 0 "
                        Return False
                    End If
            End Select
            If prmInicializarFiltro Then prmCatalogoBase.FiltroExtendido = ""
            If prmCatalogoBase.FiltroExtendido Is Nothing Then prmCatalogoBase.FiltroExtendido = ""
            prmCatalogoBase.FiltroExtendido = FlRegresaFiltroExtendidoSecundario(prmCatalogoBase, prmTienebActivo)
            Return True
        End Function

        Public Function ObtenValorDefault() As String
            If Not atrTipoConstructor = TC.Principal Then Return "0"
            If Not atrCargoCorrectoATXPrincipal Then Return "0"
            Return atrObjPermisos.ValorDefault
        End Function
        Public Function ObtenValoresPermitidosSobreATXPrincipal() As String
            If Not atrTipoConstructor = TC.Principal Then Return "0"
            If Not atrCargoCorrectoATXPrincipal Then Return "0"
            Return atrObjPermisos.Permiso.Trim
        End Function
        Public Function ObtenValoresPermiso() As String
            Return atrObjPermisos.Permiso.Trim
        End Function
        Public Function ObtenValoresPermitidosSobreCatalogoSecundario(ByRef prmCatalogoBase As Catalogo, ByVal prmCampoLlave As String, Optional ByVal prmTienebActivo As Boolean = False) As String
            If prmCatalogoBase Is Nothing Then Return ""
            Select Case atrTipoConstructor
                Case TC.Principal
                    If Not atrCargoCorrectoATXPrincipal Then Return "0"
                Case TC.Secundario
                    If Not atrCargoCorrectoSecundario Then Return "0"
            End Select


            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vcValores As String = ""
            Dim vDt As New DataTable
            'prmCatalogoBase.FiltroExtendido = ""
            'Dim vcFiltro As String = FlRegresaFiltroExtendidoSecundario(prmCatalogoBase, prmTienebActivo)
            Dim vcFiltro As String = FlRegresaFiltroExtendidoSecundario(prmCatalogoBase, prmTienebActivo)
            Dim vcSql As String = " SELECT " & prmCampoLlave & " FROM " & prmCatalogoBase.MetaCatalogoBase.SqlVistaCatalogo.Trim & " (NOLOCK) "
            vcSql &= " WHERE 1 = 1 "
            If Not vcFiltro.Trim = "" Then
                vcSql &= " AND " & vcFiltro.Trim
            End If
            DAO.RegresaConsultaSQL(vcSql, vDt)
            If vDt Is Nothing OrElse vDt.Rows.Count = 0 Then Return ""

            vcValores = ClsTools.RegresaValoresEnCadena(vDt, prmCampoLlave)
            Return vcValores
        End Function

        Public Shared Function ConfiguraFiltrosPermisosReporteador(ByRef prmATX As Object, ByRef prmRow As Object, ByRef prmDTPermisos As DataTable, ByVal prmValidatingPadre As Boolean, ByVal prmSugerirDefault As Boolean) As Boolean

            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            If prmRow Is Nothing Then Return False
            If prmATX.CatalogoBase Is Nothing Then Return False

            Dim vbFiltrarPermiso As Boolean = ClsTools.IfNull(prmRow("bFiltrarPermiso"), False)
            Dim vbEsPermiso As Boolean = ClsTools.IfNull(prmRow("bEsPermiso"), False)
            If Not vbFiltrarPermiso AndAlso Not vbEsPermiso Then Return False

            Dim mPermiso As ClsManejadorPermisos

            'VALIDAMOS SI YA SE CARGÒ EL PERMISO PARA NO VOLVERLO A OBTENER COMO NUEVO
            Dim vColRow() As DataRow
            vColRow = prmDTPermisos.Select("nTipoPermiso = " & prmRow("nTipoPermiso"))
            If vColRow.Length > 0 Then
                mPermiso = vColRow(0)("oPermiso")
            End If

            If mPermiso Is Nothing Then Return False

            'Si es Permiso (ES EL ATX PRINCIPAL)
            If vbEsPermiso Then
                'If mPermiso Is Nothing Then mPermiso = New ClsManejadorPermisos(prmRow("nTipoPermiso"), DAO.GetLoginUsuario.Trim, prmATX, False)
                If Not prmValidatingPadre Then
                    'SI NO ES VALIDATING LO INICIALIZA
                    mPermiso.InicializaATXPrincipal()
                    'ElseIf CType(prmATX, AccTextBoxAdvanced).Text.Trim = "" Then
                    '    'SI EL ATX ES VACIO, VALIDAMOS BLOQUEO Y VALOR DEFAULT
                    '    mPermiso.InicializaATXPrincipal(, , False)
                ElseIf prmSugerirDefault Then
                    'ES SUGERIR DEFAULT
                    'Si no tiene permiso sobre el valor dado en el batch lo inicializa por el valor default.
                    If Not mPermiso.ValidaTengaPermiso(prmATX.Text.Trim) Then
                        mPermiso.InicializaATXPrincipal(False, True, False, False)
                    End If
                End If

                mPermiso.ValidaElementoEnATXPrincipal()
                ''SI EL PERMISO NO ESTÀ EN EL prmDTPermisos, LO AGREGAMOS
                'If vColRow.Length = 0 Then
                '    Dim vDRowNew As DataRow
                '    vDRowNew = prmDTPermisos.NewRow
                '    vDRowNew("nTipoPermiso") = prmRow("nTipoPermiso")
                '    vDRowNew("oPermiso") = mPermiso
                '    prmDTPermisos.Rows.Add(vDRowNew)
                'End If
            Else
                'Es FiltrarPermiso (ES EL ATX SECUNDARIO)
                'If mPermiso Is Nothing Then mPermiso = New ClsManejadorPermisos(prmRow("nTipoPermiso"), DAO.GetLoginUsuario)
                mPermiso.ConfiguraCatalogoSecundario(prmATX.CatalogoBase, False, True)
                If prmValidatingPadre Then
                    Select Case prmRow("cTipoSeleccion")
                        Case "Sencillo"
                            CType(prmRow("obj"), ClsSencilla).ValidaElementoSecundarioPermisos()
                        Case "Multiple"
                            CType(prmRow("obj"), ClsMultiple).ValidaElementoSecundarioPermisos()
                    End Select
                End If
                ''SI EL PERMISO NO ESTÀ EN EL prmDTPermisos, LO AGREGAMOS
                'If vColRow.Length = 0 Then
                '    Dim vDRowNew As DataRow
                '    vDRowNew = prmDTPermisos.NewRow
                '    vDRowNew("nTipoPermiso") = prmRow("nTipoPermiso")
                '    vDRowNew("oPermiso") = mPermiso
                '    prmDTPermisos.Rows.Add(vDRowNew)
                'End If
            End If

            Return True
        End Function

        Public Shared Function ActualizaPermisoParaUsuario(ByVal prmQuitarPermiso As Boolean, ByVal prmTipoPermiso As Catalogos.ClsTipoPermiso, ByVal prmUsuario As String, ByVal prmValorPermiso As String) As Boolean
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vcSQL As String = ""
            If Not DAO.TieneTransaccionAbierta Then
                ClsTools.MuestraMensajeSistFact("Este método requiere de una transacción abierta...", Windows.Forms.MessageBoxIcon.Error)
                Return False
            End If
            If prmTipoPermiso Is Nothing OrElse prmUsuario.Trim = "" OrElse prmValorPermiso.Trim = "" Then Return False

            Dim vbEsInsertar As Boolean = Not DAO.ExistenDatosEnConsultaSQL("SELECT 1 FROM CTL_PermisosSistema (NOLOCK) WHERE nTipoPermiso = " & prmTipoPermiso.Folio & " AND cUsuario = '" & prmUsuario.Trim & "'")

            If vbEsInsertar Then
                If prmQuitarPermiso Then Return True
                vcSQL = "INSERT CTL_PermisosSistema (nTipoPermiso,cUsuario,cPermiso)"
                vcSQL = "VALUES (" & prmTipoPermiso.Folio & ",'" & prmUsuario.Trim & "','" & prmValorPermiso & "')"
                If Not DAO.EjecutaComandoSQL(vcSQL) Then Return False
            Else
                'Es Actualización
                Dim vbExistePermiso As Boolean = False
                Dim vcPermisosActuales As String = DAO.RegresaDatoSQL("SELECT cPermiso FROM CTL_PermisosSistema (NOLOCK) WHERE nTipoPermiso = " & prmTipoPermiso.Folio & " AND cUsuario = '" & prmUsuario.Trim & "'")
                Dim vcPermisosActualesSinValorPermiso As String = ""
                If Not vcPermisosActuales.Trim = "" Then
                    Select Case prmQuitarPermiso
                        Case False
                            'ES AGREGAR PERMISO AL USUARIO
                            For Each vStr As String In vcPermisosActuales.Trim.Split(",")
                                If vStr.Trim.ToUpper = prmValorPermiso.Trim.ToUpper Then
                                    vbExistePermiso = True
                                    Exit For
                                End If
                            Next
                            If vbExistePermiso Then Return True
                            vcPermisosActuales &= "," & prmValorPermiso.Trim.ToUpper
                        Case True
                            'ES QUITAR PERMISO
                            For Each vStr As String In vcPermisosActuales.Trim.Split(",")
                                If Not vStr.Trim = prmValorPermiso.Trim Then
                                    If vcPermisosActualesSinValorPermiso.Trim = "" Then
                                        vcPermisosActualesSinValorPermiso = vStr.Trim
                                    Else
                                        vcPermisosActualesSinValorPermiso &= "," & vStr.Trim
                                    End If
                                End If
                            Next
                    End Select

                Else
                    If prmQuitarPermiso Then Return True
                    vcPermisosActuales = prmValorPermiso.Trim.ToUpper
                End If

                If Not prmQuitarPermiso AndAlso vcPermisosActuales.Trim = "" Then Return False

                Select Case prmQuitarPermiso
                    Case False
                        'ES AGREGAR PERMISO
                        If Not DAO.EjecutaComandoSQL("UPDATE CTL_PermisosSistema SET cPermiso = '" & vcPermisosActuales.Trim & "' WHERE nTipoPermiso = " & prmTipoPermiso.Folio & " AND cUsuario = '" & prmUsuario.Trim & "'") Then Return False
                    Case True
                        'ES QUITAR PERMISO
                        If Not DAO.EjecutaComandoSQL("UPDATE CTL_PermisosSistema SET cPermiso = '" & vcPermisosActualesSinValorPermiso.Trim & "' WHERE nTipoPermiso = " & prmTipoPermiso.Folio & " AND cUsuario = '" & prmUsuario.Trim & "'") Then Return False
                End Select

            End If

            Return True
        End Function


    End Class
End Namespace
