Imports Sistema.Comunes.Comun
Imports Sistema.Comunes.Comun.ClsTools
Imports Sistema.Comunes
Imports Access

Namespace Comunes.Catalogos
    Public Class FabricaCatalogos
        Inherits Comunes.Comun.Fabrica

        Private Shared atrTiposDatosinmemory As Hashtable
        Private Shared atrLineasinmemory As Hashtable
        Private Shared atrImpuestoinmemory As Hashtable
        Private Shared atrMarcasinmemory As Hashtable
        Private Shared atrPresentacioninmemory As Hashtable
        Private Shared atrUnidadesinmemory As Hashtable
        Private Shared atrMovimientosinmemory As Hashtable
        Private Shared atrPaqueteriasinmemory As Hashtable
        Private Shared atrAlmacenesinmemory As Hashtable
        Private Shared atrMonedasinmemory As Hashtable
        Private Shared atrTiposArticulosinmemory As Hashtable
        Private Shared atrRegionesinmemory As Hashtable
        Private Shared atrPlazasinmemory As Hashtable
        Private Shared atrSucursalesinmemory As Hashtable
        Private Shared atrPuestosinmemory As Hashtable
        Private Shared atrTurnosinmemory As Hashtable
        Private Shared atrDepartamentosinmemory As Hashtable
        Private Shared atrAreasinmemory As Hashtable
        Private Shared atrInvolucradosinmemory As Hashtable
        Private Shared atrEmpleadosinmemory As Hashtable
        Private Shared atrEstadosinmemory As Hashtable
        Private Shared atrCiudadsinmemory As Hashtable
        Private Shared atrColoniasinmemory As Hashtable
        Private Shared atrMunicipiosinmemory As Hashtable
        Private Shared atrBancosinmemory As Hashtable
        Private Shared atrAlmacenesPrincipalesinmemory As Hashtable
        Private Shared atrZonasinmemory As Hashtable
        Private Shared atrParidadesinmemory As Hashtable
        Private Shared atrFlujosEfectivoinmemory As Hashtable
        Private Shared atrBeneficiariosinmemory As Hashtable
        Private Shared atrConceptosGastoinmemory As Hashtable
        Private Shared atrConfiguracionTipoPolizainmemory As Hashtable
        Private Shared atrProveedoresinmemory As Hashtable
        Private Shared atrClientesinmemory As Hashtable

        Private Shared atrTiposProductosInMemory As Hashtable
        Private Shared atrLineasProductosInMemory As Hashtable
        Private Shared atrInvolucradoProductoInMemory As Hashtable
        Private Shared atrVehiculosInMemory As Hashtable
        Private Shared atrProyectosinmemory As Hashtable
        Private Shared atrTiposAlmacenConsumoInMemory As Hashtable
        Private Shared atrConceptosChequeinmemory As Hashtable
        Private Shared atrTiposPolizainmemory As Hashtable
        Private Shared atrGrupoCuentaBancariainmemory As Hashtable
        Private Shared atrCuentaBancariainmemory As Hashtable
        Private Shared atrMovimientoBancarioinmemory As Hashtable
        Private Shared atrGrupoProveedorinmemory As Hashtable
        Private Shared atrOficinainmemory As Hashtable
        Private Shared atrConceptosFlujoinmemory As Hashtable
        Private Shared atrSolicitantesinmemory As Hashtable
        Private Shared atrGrupoContableinmemory As Hashtable
        Private Shared atrConfiguracionEdoCtaBan As Hashtable

        Private Shared atrTipoDatoInMemory As Hashtable

        Private Shared atrCatalogoTiposDatos As Catalogo
        Private Shared atrCatalogoLineas As Catalogo
        Private Shared atrCatalogoImpuesto As Catalogo
        Private Shared atrCatalogoMarcas As Catalogo
        Private Shared atrCatalogoPresentacion As Catalogo
        Private Shared atrCatalogoUnidades As Catalogo
        Private Shared atrCatalogoMovimientos As Catalogo
        Private Shared atrCatalogoPaqueterias As Catalogo
        Private Shared atrCatalogoAlmacenes As Catalogo
        Private Shared atrCatalogoMonedas As Catalogo
        Private Shared atrCatalogoProveedores As Catalogo
        Private Shared atrCatalogoTiposArticulos As Catalogo
        Private Shared atrCatalogoRegiones As Catalogo
        Private Shared atrCatalogoPlazas As Catalogo
        Private Shared atrCatalogoSucursales As Catalogo
        Private Shared atrCatalogoPuestos As Catalogo
        Private Shared atrCatalogoTurno As Catalogo
        Private Shared atrCatalogoDepartamento As Catalogo
        Private Shared atrCatalogoArea As Catalogo
        Private Shared atrCatalogoInvolucrado As Catalogo
        Private Shared atrCatalogoEmpleado As Catalogo
        Private Shared atrCatalogoCliente As Catalogo
        Private Shared atrCatalogoEstado As Catalogo
        Private Shared atrCatalogoMunicipio As Catalogo
        Private Shared atrCatalogoCiudad As Catalogo
        Private Shared atrCatalogoColonia As Catalogo
        Private Shared atrCatalogoBanco As Catalogo
        Private Shared atrCatalogoAlmacenesPrincipales As Catalogo
        Private Shared atrCatalogoZona As Catalogo
        Private Shared atrCatalogoParidad As Catalogo

        Private Shared atrCatalogoRFC As Catalogo
        Private Shared atrRFCInMemory As Hashtable
        Private Shared atrCatalogoRazonSocial As Catalogo
        Private Shared atrRazonSocialInMemory As Hashtable

        Private Shared atrCatalogoInvolucradoProducto As Catalogo
        Private Shared atrCatalogoTiposProductos As Catalogo
        Private Shared atrCatalogoLineasProductos As Catalogo
        Private Shared atrCatalogoTiposAlmacenConsumo As Catalogo
        Private Shared atrCatalogoVehiculos As Catalogo
        Private Shared atrCatalogoTipoDato As Catalogo
        Private Shared atrmotivosinmemory As Hashtable
        Private Shared atrCatalogomotivos As Catalogo
        Private Shared atrCatalogoFlujosEfectivo As Catalogo
        Private Shared atrCatalogoBeneficiarios As Catalogo
        Private Shared atrCatalogoProyectos As Catalogo
        Private Shared atrCatalogoCodigoProduccion As Catalogo
        Private Shared atrCodigoProduccionInMemory As Hashtable
        Private Shared atrCatalogoConceptosCxp As Catalogo
        Private Shared atrCatalogoConceptosCheque As Catalogo
        Private Shared atrCatalogoTiposPoliza As Catalogo
        Private Shared atrCatalogoGrupoCuentaBancaria As Catalogo
        Private Shared atrCatalogoCuentaBancaria As Catalogo
        Private Shared atrCatalogoMovimientoBancario As Catalogo
        Private Shared atrCatalogoGrupoProveedor As Catalogo
        Private Shared atrCatalogoOficina As Catalogo
        Private Shared atrCatalogoCentroDeCosto As Catalogo
        Private Shared atrCatalogoDeGrupos As Catalogo
        Private Shared atrCatalogoConceptosFlujo As Catalogo
        Private Shared atrCatalogoConfiguracionEdoCtaBan As Catalogo
        Private Shared atrCatalogoSolicitante As Catalogo
        Private Shared atrCatalogoConceptosGasto As Catalogo
        Private Shared atrCatalogoConfiguracionTipoPoliza As Catalogo
        Private Shared atrCatalogoGrupoContable As Catalogo
        Private Shared atrCatalogoProveedoresBancos As Catalogo
        Private Shared atrCatalogoClientesBancos As Catalogo

        Public Shared vNombreTablaTiposArticulos As String = "CTL_TiposArticulos"
        Public Shared vNombreTablaTiposDatos As String = "ADSUM_TiposDatos"
        Public Shared vNombreTablaParidades As String = "CTL_Paridades"
        Public Shared vNombreTablaPresentaciones As String = "CTL_ArticulosPresentaciones"
        Public Shared vNombreTablaImpuestos As String = "CTL_ArticulosImpuestos"
        Public Shared vNombreTablaCodigosProveedor As String = "CTL_ProveedoresArticulos"
        Public Shared vNombreTablaProveedorProntosPagos As String = "CTL_ProveedoresProntosPagos"
        Public Shared vNombreTablaProveedorBitacoraObservaciones As String = "CTL_ProveedoresBitacoraObservaciones"
        Public Shared vNombreTablaArticuloUbicacion As String = "CTL_ArticulosUbicaciones"
        Public Shared vNombreTablaFlujosEfectivo As String = "CTL_FlujosEfectivo"
        Public Shared vNombreDetalleConceptoFlujos As String = "CTL_ConceptosFlujosDetalle"
        Public Shared vNombreDetalleProyectos As String = "CTL_ProyectosDetalle"
        Public Shared vNombreTablaProveedoresCuentasContables As String = "CTL_ProveedoresCuentasContables"
        Public Shared vNombreDetalleConfiguracionPolizas As String = "CNT_ConfiguracionTiposPolizasDetalle"
        Public Shared vNombreDetalleBeneficiarios As String = "CTL_BeneficiariosDetalle"
        Public Shared vNombreDetalleConceptosGastos As String = "CTL_ConceptosGastosDetalle"
        Public Shared vNombreDetalleProveedores As String = "CTL_ProveedoresCuentasContables"
        Public Shared vNombreDetalleClientes As String = "CTL_ClientesCuentasContables"

' ''        Public Shared Function ObtenDescripcionPresentacionCatalogo(ByVal prmPresentacion As Int32) As String
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Return DAO.RegresaDatoSQL("SELECT isnull(cDescripcion,'') FROM CTL_Presentaciones (NOLOCK) WHERE nPresentacion = " & prmPresentacion)
' ''        End Function

' ''        Public Shared Function ObtenDescripcionTiposArticulos(ByVal prmTiposArticulos As String) As String
' ''            If prmTiposArticulos.Trim = "" Then Return ""
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim vSQL As String = ""
' ''            Dim dt As New DataTable
' ''            vSQL = "SELECT nTipoArticulo,cDescripcion FROM CTL_TiposArticulos TA (NOLOCK) " & vbCr
' ''            vSQL &= " WHERE TA.nTipoArticulo IN (" & prmTiposArticulos.Trim & ")"
' ''            DAO.RegresaConsultaSQL(vSQL, dt)
' ''            vSQL = ""
' ''            For Each dr As DataRow In dt.Rows
' ''                vSQL &= dr("cDescripcion") & ", "
' ''            Next
' ''            If Not vSQL.Trim = "" Then
' ''                vSQL = vSQL.Trim.Substring(0, vSQL.Trim.Length - 1)
' ''            End If
' ''            Return vSQL.Trim.ToUpper
' ''        End Function

' ''        Public Shared Function VerificaRfcProveedor(ByVal prmRfc As String, Optional ByVal prmProveedorExcluye As Integer = 0) As DataTable
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim vDt_Datos As New DataTable
' ''            Dim vcSql As String = ""

' ''            vcSql = "SELECT nProveedor,cNombreFiscal FROM CTL_Proveedores(NOLOCK) WHERE REPLACE(cRFC,'-','')= '" & Replace(prmRfc, "-", "") & "'"
' ''            vcSql &= vbCr & " AND nPlazaRegistro=" & DAO.ParametroAdministradoObtener("PRMSUC", "PLAZA")
' ''            If prmProveedorExcluye > 0 Then
' ''                vcSql &= vbCr & " AND nProveedor<>" & prmProveedorExcluye
' ''            End If
' ''            DAO.RegresaConsultaSQL(vcSql, vDt_Datos)

' ''            Return vDt_Datos
' ''        End Function

' ''        Public Shared Function VerificaRfcCliente(ByVal prmRfc As String, Optional ByVal prmClienteExcluye As Integer = 0) As DataTable
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim vDt_Datos As New DataTable
' ''            Dim vcSql As String = ""

' ''            vcSql = "SELECT nCliente,cNombreFiscal FROM CTL_Clientes(NOLOCK) WHERE REPLACE(cRFC,'-','')= '" & Replace(prmRfc, "-", "") & "'"
' ''            vcSql &= vbCr & " AND nPlaza=" & DAO.ParametroAdministradoObtener("PRMSUC", "PLAZA")
' ''            If prmClienteExcluye > 0 Then
' ''                vcSql &= vbCr & " AND nCliente<>" & prmClienteExcluye
' ''            End If
' ''            DAO.RegresaConsultaSQL(vcSql, vDt_Datos)

' ''            Return vDt_Datos
' ''        End Function

' ''        Public Shared Function VerificaCiudad(ByVal prmCiudad As Integer) As DataTable
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim dt As New DataTable
' ''            Dim vSql As String = ""
' ''            vSql = "SELECT * FROM CTL_Ciudades(NOLOCK) WHERE nidCiudad = " & prmCiudad
' ''            DAO.RegresaConsultaSQL(vSql, dt)
' ''            Return dt
' ''        End Function

' ''        Public Shared Function VerificaColonia(ByVal prmColonia As Integer) As DataTable
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim dt As New DataTable
' ''            Dim vSql As String = ""
' ''            vSql = "SELECT * FROM CTL_Colonias(NOLOCK) WHERE nColonia = " & prmColonia
' ''            DAO.RegresaConsultaSQL(vSql, dt)
' ''            Return dt
' ''        End Function

' ''        Public Shared Function ObtenPlazas(Optional ByVal prmActivo As Boolean = True) As DataTable
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim dt As New DataTable
' ''            Dim vSql As String = ""
' ''            vSql = "SELECT * FROM CTL_PLAZAS (NOLOCK) WHERE bActivo = " & IIf(prmActivo, 1, 0)
' ''            DAO.RegresaConsultaSQL(vSql, dt)
' ''            Return dt
' ''        End Function

' ''        Public Shared Function ObtenAlmacenesControladores(ByVal prmAlmacen As Catalogos.ClsAlmacen) As String
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim dt As New DataTable
' ''            Dim vSql As String = ""
' ''            vSql = "select * From ctl_almacenes (NOLOCK) WHERE nAlmacenControlador = " & prmAlmacen.Folio
' ''            DAO.RegresaConsultaSQL(vSql, dt)

' ''            Dim vAlmacenes As String = ""
' ''            For Each dr As DataRow In dt.Rows
' ''                vAlmacenes &= dr("nAlmacen") & ","
' ''            Next

' ''            If Not vAlmacenes.Trim = "" Then
' ''                vAlmacenes = vAlmacenes.Substring(0, vAlmacenes.Length - 1)
' ''            End If

' ''            Return vAlmacenes

' ''        End Function

' ''        Public Shared Function ValidaTipoDeAlmacenParaConcentradoExixstencias(ByVal Tipoalmacen As Integer) As DataTable
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim dt As New DataTable
        ' ''            Dim vsql As String = ""

        ' ''            vsql = "Select cValor From ADSUM_TiposDatos (Nolock) where cLlave = 'CTL_ALMACENES_TIPOALMACEN' and not nValor=1 And nValor =" & Tipoalmacen

        ' ''            DAO.RegresaConsultaSQL(vsql, dt)

        ' ''            Return dt
        ' ''        End Function

        ' ''        Public Shared Function ValidaTipoDeSucursalParaConcentradoExixstencias(ByVal TipoSucursal As Integer) As DataTable
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim dt As New DataTable
        ' ''            Dim vsql As String = ""

        ' ''            vsql = "Select cValor From ADSUM_TiposDatos (Nolock) where cLlave = 'CTL_SUCURSALES_TIPOSUCURSAL'  And nValor =" & TipoSucursal

        ' ''            DAO.RegresaConsultaSQL(vsql, dt)

        ' ''            Return dt
        ' ''        End Function

        ' ''        Public Shared Function ObtenSucursalesyAlmacenes(ByVal Columnas As Data.DataColumnCollection) As DataSet
        ' ''            Dim ds As New DataSet
        ' ''            Dim dtsuc As New DataTable
        ' ''            Dim dtalm As New DataTable

        ' ''            ds.Tables.Add(dtsuc)
        ' ''            ds.Tables.Add(dtalm)

        ' ''            dtsuc.Columns.Add("nSucursal", GetType(Integer))
        ' ''            dtsuc.Columns.Add("cSucursal", GetType(String))

        ' ''            dtalm.Columns.Add("nSucursal", GetType(Integer))
        ' ''            dtalm.Columns.Add("nAlmacen", GetType(Integer))
        ' ''            dtalm.Columns.Add("cAlmacen", GetType(String))

        ' ''            Dim ssuc As String = ""
        ' ''            Dim salm As String = ""
        ' ''            For Each vcol As DataColumn In Columnas
        ' ''                If vcol.ColumnName.Substring(0, 3).ToUpper = "SUC" Then
        ' ''                    Dim psuc As Integer = InStr(4, vcol.ColumnName, "_")
        ' ''                    Dim suc As Integer = vcol.ColumnName.Substring(4, psuc - 3)
        ' ''                    Dim alm As Integer = vcol.ColumnName.Substring(psuc, InStr(psuc + 1, vcol.ColumnName, "_") - (psuc + 1))

        ' ''                    ssuc &= suc & ","
        ' ''                    salm &= alm & ","
        ' ''                End If
        ' ''            Next
        ' ''            If salm.Trim <> "" Then
        ' ''                ssuc = ssuc.Substring(0, ssuc.Length - 1)
        ' ''                salm = salm.Substring(0, salm.Length - 1)
        ' ''                Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''                DAO.RegresaConsultaSQL("select nsucursal,cdescripcion as csucursal from ctl_sucursales where nsucursal in(" & ssuc & ")", dtsuc)
        ' ''                DAO.RegresaConsultaSQL("select nsucursal,nalmacen, cdescripcion as calmacen from ctl_almacenes where nalmacen in(" & salm & ")", dtalm)
        ' ''            End If
        ' ''            Return ds
        ' ''        End Function

        ' ''        Public Shared Function ObtenUbicaciones(ByVal prmArticulo As ClsArticulo) As DataTable
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim dt As New DataTable
        ' ''            Dim vsql As String = ""


        ' ''            vsql = "select a.nalmacen,a.cdescripcion, " & prmArticulo.Folio & " as narticulo, isnull(b.cubicacion,'') as cubicacion "
        ' ''            vsql &= " from vw_AlmacenesPlazas(nolock) a "
        ' ''            vsql &= " left join ctl_articulosubicaciones(nolock) b on a.nalmacen=b.nalmacen  and b.narticulo=" & prmArticulo.Folio '& " and a.plaza=" & ObtenAlmacen(DAO.ParametrosTerminal.ParametroAlmacen.Valor).Plaza.Folio
        ' ''            vsql &= " where bManejaDireccion = 1   and a.plaza=" & ObtenAlmacen(DAO.ParametrosTerminal.ParametroAlmacen.Valor).Plaza.Folio


        ' ''            DAO.RegresaConsultaSQL(vsql, dt)

        ' ''            Return dt
        ' ''        End Function

        ' ''        Public Shared Function ObtenUbicacion(ByRef prmrow As DataRow, ByVal prmobj As ClsUbicacion) As DataRow
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            If prmobj Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If

        ' ''            prmrow("narticulo") = prmobj.Articulo.Folio
        ' ''            prmrow("nalmacen") = prmobj.Almacen.Folio
        ' ''            prmrow("cubicacion") = prmobj.Ubicacion

        ' ''            Return prmrow

        ' ''        End Function

        ' ''        Public Shared Function ObtenUbicacion(ByVal prmrow As DataRow) As ClsUbicacion
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If

        ' ''            Dim ret As New ClsUbicacion
        ' ''            ret.Articulo = ObtenArticulo(prmrow("narticulo"))
        ' ''            ret.Almacen = ObtenAlmacen(prmrow("nalmacen"))
        ' ''            ret.Ubicacion = prmrow("cubicacion")

        ' ''            Return ret

        ' ''        End Function

        ' ''        Public Shared Function ObtenPrecios(ByVal Articulo As ClsArticulo) As DataTable
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim dt As New DataTable
        ' ''            Dim vsql As String = ""

        ' ''            vsql = "SELECT  PRO.nProveedor as nProveedor,PRO.cNombreFiscal as cProveedor,b.nFletePartida as nFlete,b.nCantidadMovimiento as nCantidad,e.cdescripcion as cpresentacion,cg.bProveedorPagaFlete as ProveedorPagaFlete,a.dFecha as dFecha,d.cdescripcion as cplaza,b.ncostounitario,b.nfletepartida,(b.ncostounitario + (b.nfletepartida / b.nCantidadMovimiento)) * b.nCantidadMovimiento as ncostototal,a.cReferencia,ATD.cValor As cTipoDocumento,cg.cObservaciones As cObservacionCabecero,cgd.cObservacion As cObservacionDetalle,Case When b.nIva = 0 Then Null Else b.nIva End As nIva FROM  INV_MovimientosAlmacen (NOLOCK) a "
        ' ''            vsql &= " inner join INV_MovimientosAlmacenDetalle (NOLOCK) b on a.nMovimientoAlmacen=b.nMovimientoAlmacen and a.ntipomovimiento=" & DAO.ParametroAdministradoObtener("PRM_INV", "TIPOMOVIMIENTO_ENTRADASCOMPRA") & " and narticulo=" & Articulo.Folio
        ' ''            vsql &= " inner join ctl_almacenes (nolock) c on a.nalmacenmovimiento=c.nalmacen "
        ' ''            vsql &= " inner join COM_Compras_Relacion_Inventarios (nolock) cri on cri.nMovimientoAlmacen=b.nMovimientoAlmacen  "
        ' ''            vsql &= " inner join COM_Compras_Gastos (nolock) cg on cg.nMovimientoCompra=cri.nMovimientoCompra  "
        ' ''            vsql &= " inner join COM_Compras_GastosDetalle (nolock) cgd on cg.nMovimientoCompra=cgd.nMovimientoCompra  "
        ' ''            vsql &= " inner Join ADSUM_TiposDatos ATD(NoLock) On ATD.cLlave = 'COM_TIPODOCUMENTO' And ATD.nValor = cg.nTipoDocumento  "
        ' ''            vsql &= " inner join CTL_Proveedores (nolock) PRO on PRO.nProveedor=cg.nProveedor"

        ' ''            vsql &= " left join ctl_plazas (nolock) d on c.nplaza=d.nplaza "
        ' ''            vsql &= " inner join ctl_articulospresentaciones (nolock) e on b.narticulo=e.narticulo and b.npresentacion=e.npresentacion "

        ' ''            vsql &= " where dbo.Adsum_Numerojuliano(a.dFecha) >= " & Articulo.FechaPreciosInicio & " and dbo.Adsum_Numerojuliano(a.dFecha)<= " & Articulo.FechaPreciosFin

        ' ''            vsql &= " Group by e.cdescripcion,PRO.nProveedor,PRO.cNombreFiscal, b.nFletePartida,b.nCantidadMovimiento,cg.bProveedorPagaFlete,a.dFecha,d.cdescripcion,b.ncostounitario,b.nfletepartida,a.creferencia,ATD.cValor,b.nIva,cg.cObservaciones,cgd.cObservacion"
        ' ''            DAO.RegresaConsultaSQL(vsql, dt)

        ' ''            Return dt

        ' ''        End Function

        ' ''        Public Shared Function ExisteOrdenSucursal(ByVal prmOrden As Integer, ByVal prmSucursal As Integer) As Boolean
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            If DAO.RegresaDatoSQL("select nordenlistado from CTL_SUCURSALES where nordenlistado=" & prmOrden & " and nsucursal<>" & prmSucursal) = prmOrden Then
        ' ''                Return True
        ' ''            End If
        ' ''            Return False
        ' ''        End Function

        ' ''        Public Shared Function ExisteOrdenAlmacen(ByVal prmOrden As Integer, ByVal prmAlmacen As Integer) As Boolean
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            If DAO.RegresaDatoSQL("select nordenlistado from CTL_Almacenes where nordenlistado=" & prmOrden & " and nAlmacen<>" & prmAlmacen) = prmOrden Then
        ' ''                Return True
        ' ''            End If
        ' ''            Return False
        ' ''        End Function

        ' ''        Public Shared Function ObtenAlmacenesUbicacion(ByVal prmPlaza As Catalogos.ClsPlaza) As DataTable
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim DT_Almacenes As New DataTable

        ' ''            If DAO.RegresaConsultaSQL("Select * From CTL_Almacenes (NOLOCK) Where nPlaza = " & prmPlaza.Folio & " And bManejaDireccion = 1 And bActivo = 1", DT_Almacenes) Then
        ' ''                If DT_Almacenes.Rows.Count > 0 Then
        ' ''                    Return DT_Almacenes
        ' ''                End If
        ' ''            End If
        ' ''            Return Nothing
        ' ''        End Function

        ' ''        Public Shared Function ObtenIva(ByVal prmarticulo As ClsArticulo, ByVal prmFrontera As Boolean) As ClsImpuesto
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim dt As New DataTable

        ' ''            DAO.RegresaConsultaSQL("select CTL_Impuestos.* from CTL_Impuestos(NOLOCK) INNER JOIN CTL_ArticulosImpuestos(nolock) on CTL_Impuestos.nImpuestos = CTL_ArticulosImpuestos.nImpuesto where CTL_Impuestos.bactivo = 1 And CTL_Impuestos.biva = 1 And CTL_Impuestos.bfrontera = " & IIf(prmFrontera, 1, 0) & " and CTL_ArticulosImpuestos.narticulo=" & prmarticulo.Folio & " and CTL_ArticulosImpuestos.bactivo=1", dt)

        ' ''            If dt.Rows.Count = 0 Then
        ' ''                Return Nothing
        ' ''            Else
        ' ''                Return ObtenImpuesto(dt.Rows(0))
        ' ''            End If

        ' ''        End Function

        ' ''        Public Shared Function ObtenMotivos() As DataTable
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim dt As New DataTable
        ' ''            Dim vSql As String
        ' ''            vSql = "SELECT * FROM CTL_MOTIVOS (NOLOCK)" & vbCr
        ' ''            vSql &= " WHERE bActivo = 1"
        ' ''            DAO.RegresaConsultaSQL(vSql, dt)
        ' ''            Return dt
        ' ''        End Function

        ' ''        Public Shared Function Obtenmotivos(ByVal prmnMotivo As Integer, Optional ByVal tiempo_real As Boolean = False) As clsmotivos
        ' ''            If atrCatalogomotivos Is Nothing Then atrCatalogomotivos = New Catalogo(New MetaCatalogo("motivos"))

        ' ''            Dim vobject As Object = ObtenGenerico(prmnMotivo.ToString, atrmotivosinMemory, atrCatalogomotivos, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf Obtenmotivos), tiempo_real)

        ' ''            Return IIf(vobject Is Nothing, Nothing, CType(vobject, clsmotivos))

        ' ''        End Function

        ' ''        Public Shared Function Obtenmotivos(ByVal prmrow As DataRow) As clsmotivos
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            Dim ret As New clsmotivos(prmrow("nMotivo"))

        ' ''            ret.Motivo = prmrow("nMotivo")

        ' ''            ret.Descripcion = prmRow("cDescripcion")
        ' ''            ret.Activo = prmrow("bActivo")
        ' ''            ret.CargaDatosRegistro(prmrow)
        ' ''            Return ret


        ' ''        End Function

        ' ''        Public Shared Function Obtenmotivos(ByRef prmrow As DataRow, ByVal prmObj As clsmotivos) As DataRow
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            If prmObj Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            prmrow("nMotivo") = prmobj.folio            
        ' ''            prmrow("cDescripcion") = prmobj.Descripcion
        ' ''            prmrow("bActivo") = prmobj.Activo
        ' ''            prmObj.LLenaDatosRegistroComun(prmrow)
        ' ''            Return prmRow
        ' ''        End Function

        ' ''        Public Shared Function ObtenFolioPresentaciones(ByVal prmArticulo As Integer) As Integer
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Return DAO.RegresaDatoSQL("select isnull(max(npresentacion),0)+1 from CTL_ArticulosPresentaciones(NOLOCK) where nArticulo=" & prmArticulo)  ' DAO.FolioAdministradoSiguiente(getNombreFolioAdministrado())
        ' ''        End Function

        ' ''        Public Shared Function ObtenInvolucradoProducto(ByVal prmInvolucrado As Integer, Optional ByVal tiempo_real As Boolean = False) As ClsInvolucradoProducto
        ' ''            If atrCatalogoInvolucradoProducto Is Nothing Then atrCatalogoInvolucradoProducto = New Catalogo(New MetaCatalogo("INVOLUCRADOSPRODUCTOS"))
        ' ''            Dim vobject As Object = ObtenGenerico(prmInvolucrado.ToString, atrInvolucradoProductoInMemory, atrCatalogoInvolucradoProducto, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenInvolucradoProducto), tiempo_real)
        ' ''            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsInvolucradoProducto))
        ' ''        End Function

        ' ''        Public Shared Function ObtenInvolucradoProducto(ByRef prmrow As DataRow, ByVal prmInvolucrado As ClsInvolucradoProducto) As DataRow
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            If prmInvolucrado Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If

        ' ''            prmrow("nInvolucrado") = prmInvolucrado.Folio
        ' ''            prmrow("cNombre") = prmInvolucrado.Descripcion
        ' ''            prmrow("cAbreviatura") = prmInvolucrado.Abreviatura
        ' ''            prmrow("bActivo") = prmInvolucrado.Activo
        ' ''            prmrow("cContacto") = prmInvolucrado.Contacto
        ' ''            prmrow("cDomicilio") = prmInvolucrado.Domicilio
        ' ''            prmrow("cTelefonos") = prmInvolucrado.Telefonos
        ' ''            prmrow("cTipoInvolucrado") = prmInvolucrado.TipoInvolucrado
        ' ''            prmrow("cLetra") = prmInvolucrado.Letra
        ' ''            prmrow("nPlaza") = prmInvolucrado.Plaza.Folio

        ' ''            If Not prmInvolucrado.InvolucradoRelacionado Is Nothing Then
        ' ''                prmrow("nInvolucradoRelacionado") = prmInvolucrado.InvolucradoRelacionado.Folio
        ' ''            End If

        ' ''            prmInvolucrado.LLenaDatosRegistroComun(prmrow)

        ' ''            Return prmrow
        ' ''        End Function

        ' ''        Public Shared Function ObtenInvolucradoProducto(ByVal prmrow As DataRow) As ClsInvolucradoProducto
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If

        ' ''            Dim ret As New ClsInvolucradoProducto(prmrow("nInvolucrado"))

        ' ''            ret.Descripcion = prmrow("cNombre")
        ' ''            ret.Abreviatura = prmrow("cAbreviatura")
        ' ''            ret.Contacto = prmrow("cContacto")
        ' ''            ret.Domicilio = prmrow("cDomicilio")
        ' ''            ret.Telefonos = prmrow("cTelefonos")
        ' ''            ret.TipoInvolucrado = prmrow("cTipoInvolucrado")
        ' ''            ret.Letra = prmrow("cLetra")

        ' ''            If Not prmrow("nInvolucradoRelacionado") Is DBNull.Value Then
        ' ''                ret.InvolucradoRelacionado = FabricaCatalogos.ObtenInvolucradoRelacionadoProducto(prmrow("nInvolucradoRelacionado"))
        ' ''            End If

        ' ''            If Not prmrow("nPlaza") Is DBNull.Value Then
        ' ''                ret.Plaza = FabricaCatalogos.ObtenPlaza(prmrow("nPlaza"))
        ' ''            End If

        ' ''            ret.Activo = prmrow("bActivo")

        ' ''            ret.CargaDatosRegistro(prmrow)

        ' ''            Return ret
        ' ''        End Function

        ' ''        Public Shared Function ObtenInvolucradoRelacionadoProducto(ByVal prmInvolucradoRelacionado As Integer) As ClsInvolucradoProducto
        ' ''            Dim ret As New ClsInvolucradoProducto(prmInvolucradoRelacionado)

        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim dtTrabajo As New DataTable
        ' ''            Dim res As New ClsInvolucrado
        ' ''            Dim vlsql As String

        ' ''            vlsql = "SELECT * FROM CTL_InvolucradosProductos(NOLOCK)" & vbCr
        ' ''            vlsql &= "WHERE nInvolucrado=" & prmInvolucradoRelacionado & vbCr
        ' ''            'vlsql &= "AND bActivo=1"

        ' ''            DAO.RegresaConsultaSQL(vlsql, dtTrabajo)

        ' ''            For Each vRow As DataRow In dtTrabajo.Rows
        ' ''                ret.Descripcion = vRow("cNombre")
        ' ''                ret.Abreviatura = vRow("cAbreviatura")
        ' ''                ret.Contacto = vRow("cContacto")
        ' ''                ret.Domicilio = vRow("cDomicilio")
        ' ''                ret.Telefonos = vRow("cTelefonos")
        ' ''                ret.TipoInvolucrado = vRow("cTipoInvolucrado")
        ' ''                ret.Letra = vRow("cLetra")
        ' ''                ret.Activo = vRow("bActivo")

        ' ''                ret.CargaDatosRegistro(vRow)
        ' ''            Next

        ' ''            Return ret
        ' ''        End Function

        ' ''        Public Shared Function ActualizaInvolucradosRelacionado(ByVal prmInvolucrado As Catalogos.ClsInvolucrado) As Boolean
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim vSql As String = ""
        ' ''            vSql = "UPDATE CTL_Involucrados SET nInvolucradoRelacionado =" & prmInvolucrado.Folio & " WHERE nInvolucrado = " & prmInvolucrado.Folio
        ' ''            Return DAO.EjecutaComandoSQL(vSql)
        ' ''        End Function

        ' ''        Public Shared Function ObtenInvolucrado(ByVal prmInvolucrado As Integer, Optional ByVal tiempo_real As Boolean = False) As ClsInvolucrado
        ' ''            If atrCatalogoInvolucrado Is Nothing Then atrCatalogoInvolucrado = New Catalogo(New MetaCatalogo("INVOLUCRADOS"))
        ' ''            Dim vobject As Object = ObtenGenerico(prmInvolucrado.ToString, atrInvolucradosinmemory, atrCatalogoInvolucrado, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenInvolucrado), tiempo_real)
        ' ''            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsInvolucrado))
        ' ''        End Function

        ' ''        Public Shared Function ObtenBanco(ByVal prmBanco As Integer, Optional ByVal tiempo_real As Boolean = False) As ClsBanco
        ' ''            If atrCatalogoBanco Is Nothing Then atrCatalogoBanco = New Catalogo(New MetaCatalogo("BANCOS"))
        ' ''            Dim vobject As Object = ObtenGenerico(prmBanco.ToString, atrBancosinmemory, atrCatalogoBanco, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenBanco), tiempo_real)
        ' ''            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsBanco))
        ' ''        End Function

        ' ''        Public Shared Function ObtenUnidades(ByVal prmCombo As System.Windows.Forms.ComboBox) As Boolean
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim dt As New DataTable
        ' ''            DAO.RegresaConsultaSQL("select * from CTL_Unidades(NOLOCK) where bactivo=1", dt)

        ' ''            prmCombo.Items.Clear()
        ' ''            For Each vrow As DataRow In dt.Rows
        ' ''                prmCombo.Items.Add(ObtenUnidad(vrow))
        ' ''            Next
        ' ''            Return True
        ' ''        End Function

        ' ''        'Public Shared Function ObtenInvolucrado(ByVal PrmnInvolucrado As Integer) As ClsInvolucrado
        ' ''        '    Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''        '    Dim dtTrabajo As New DataTable
        ' ''        '    Dim res As New ClsInvolucrado
        ' ''        '    Dim vlsql As String

        ' ''        '    vlsql = "SELECT * FROM CTL_Involucrados(NOLOCK)" & vbCr
        ' ''        '    vlsql &= "WHERE nInvolucrado=" & PrmnInvolucrado & vbCr

        ' ''        '    DAO.RegresaConsultaSQL(vlsql, dtTrabajo)


        ' ''        '    For Each vRow As DataRow In dtTrabajo.Rows
        ' ''        '        ret.Descripcion = prmrow("cNombre")
        ' ''        '        ret.Contacto = prmrow("cContacto")
        ' ''        '        ret.Domicilio = prmrow("cDomicilio")
        ' ''        '        ret.Telefonos = prmrow("cTelefonos")

        ' ''        '        If Not prmrow("nInvolucradoRelacionado") Is DBNull.Value Then
        ' ''        '            ret.InvolucradoRelacionado = FabricaCatalogos.ObtenInvolucrado(prmrow("nInvolucradoRelacionado"), True)
        ' ''        '        End If

        ' ''        '        ret.Activo = prmrow("bActivo")

        ' ''        '        ret.CargaDatosRegistro(prmrow)


        ' ''        '    Next
        ' ''        'End Function

        ' ''        Public Shared Function ObtenZona(ByVal prmZona As Integer, Optional ByVal tiempo_real As Boolean = False) As ClsZona
        ' ''            If atrCatalogoZona Is Nothing Then atrCatalogoZona = New Catalogo(New MetaCatalogo("ZONAS"))
        ' ''            Dim vobject As Object = ObtenGenerico(prmZona.ToString, atrZonasinmemory, atrCatalogoZona, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenZona), tiempo_real)
        ' ''            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsZona))
        ' ''        End Function

        ' ''        Public Shared Function ObtenColonia(ByVal prmColonia As Long, Optional ByVal tiempo_real As Boolean = False) As ClsColonia
        ' ''            If atrCatalogoColonia Is Nothing Then atrCatalogoColonia = New Catalogo(New MetaCatalogo("COLONIAS"))
        ' ''            Dim vobject As Object = ObtenGenerico(prmColonia.ToString, atrColoniasinmemory, atrCatalogoColonia, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenColonia), tiempo_real)
        ' ''            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsColonia))
        ' ''        End Function

        ' ''        Public Shared Function ObtenCiudad(ByVal prmCiudad As Long, Optional ByVal tiempo_real As Boolean = False) As ClsCiudad
        ' ''            If atrCatalogoCiudad Is Nothing Then atrCatalogoCiudad = New Catalogo(New MetaCatalogo("CIUDADES"))
        ' ''            Dim vobject As Object = ObtenGenerico(prmCiudad.ToString, atrCiudadsinmemory, atrCatalogoCiudad, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenCiudad), tiempo_real)
        ' ''            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsCiudad))
        ' ''        End Function

        ' ''        Public Shared Function ObtenMunicipio(ByVal prmMunicipio As Long, Optional ByVal tiempo_real As Boolean = False) As ClsMunicipio
        ' ''            If atrCatalogoMunicipio Is Nothing Then atrCatalogoMunicipio = New Catalogo(New MetaCatalogo("MUNICIPIOS"))
        ' ''            Dim vobject As Object = ObtenGenerico(prmMunicipio.ToString, atrMunicipiosinmemory, atrCatalogoMunicipio, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenMunicipio), tiempo_real)
        ' ''            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsMunicipio))
        ' ''        End Function

        ' ''        Public Shared Function ObtenEstado(ByVal prmEstado As Long, Optional ByVal tiempo_real As Boolean = False) As ClsEstado
        ' ''            If atrCatalogoEstado Is Nothing Then atrCatalogoEstado = New Catalogo(New MetaCatalogo("ESTADOS"))
        ' ''            Dim vobject As Object = ObtenGenerico(prmEstado.ToString, atrEstadosinmemory, atrCatalogoEstado, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenEstado), tiempo_real)
        ' ''            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsEstado))
        ' ''        End Function

        ' ''        Public Shared Function ObtenArea(ByVal prmArea As Integer, Optional ByVal tiempo_real As Boolean = False) As ClsArea
        ' ''            If atrCatalogoArea Is Nothing Then atrCatalogoArea = New Catalogo(New MetaCatalogo("AREAS"))
        ' ''            Dim vobject As Object = ObtenGenerico(prmArea.ToString, atrAreasinmemory, atrCatalogoArea, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenArea), tiempo_real)
        ' ''            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsArea))
        ' ''        End Function

        ' ''        'Public Shared Function ObtenInvolucrado(ByVal prmInvolucrado As Integer, Optional ByVal tiempo_real As Boolean = False) As ClsInvolucrado
        ' ''        '    If atrCatalogoInvolucrado Is Nothing Then atrCatalogoInvolucrado = New Catalogo(New MetaCatalogo("INVOLUCRADOS"))
        ' ''        '    Dim vobject As Object = ObtenGenerico(prmInvolucrado.ToString, atrInvolucradosinmemory, atrCatalogoInvolucrado, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenInvolucrado), tiempo_real)
        ' ''        '    Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsInvolucrado))
        ' ''        'End Function
        ' ''        Public Shared Function ObtenUsuarioRegistro(ByVal prmEmpleado As Catalogos.ClsEmpleado) As String
        ' ''            If prmEmpleado Is Nothing Then
        ' ''                Return ""
        ' ''            End If
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim dt As New DataTable
        ' ''            Dim vSql As String = "SELECT * FROM ADSUM_Usuarios (NOLOCK)" & vbCr
        ' ''            vSql &= "WHERE nPersonal = " & prmEmpleado.Folio
        ' ''            DAO.RegresaConsultaSQL(vSql, dt)
        ' ''            If Not dt Is Nothing Then
        ' ''                If dt.Rows.Count > 0 Then
        ' ''                    Return dt.Rows(0)("cLogin")
        ' ''                End If
        ' ''            End If
        ' ''            Return ""
        ' ''        End Function

        ' ''        Public Shared Function ValidaUsuario(ByVal prmUsuario As String) As Boolean
        ' ''            If prmUsuario Is Nothing OrElse prmUsuario.Trim = "" Then Return False
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Return DAO.ExistenDatosEnConsultaSQL("SELECT * FROM Adsum_Usuarios_X_Perfil(NOLOCK)  WHERE cLogin = '" & prmUsuario & "'")
        ' ''        End Function

        Public Shared Function ObtenEmpleado(ByVal prmEmpleado As Integer, Optional ByVal tiempo_real As Boolean = False) As ClsEmpleado
            If atrCatalogoEmpleado Is Nothing Then atrCatalogoEmpleado = New Catalogo(New MetaCatalogo("EMPLEADOS"))
            Dim vobject As Object = ObtenGenerico(prmEmpleado.ToString, atrEmpleadosinmemory, atrCatalogoEmpleado, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenEmpleado), tiempo_real)
            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsEmpleado))
        End Function

        ' ''        Public Shared Function ObtenDepartamento(ByVal prmDepartamento As Integer, Optional ByVal tiempo_real As Boolean = False) As ClsDepartamento
        ' ''            If atrCatalogoDepartamento Is Nothing Then atrCatalogoDepartamento = New Catalogo(New MetaCatalogo("DEPARTAMENTOS"))
        ' ''            Dim vobject As Object = ObtenGenerico(prmDepartamento.ToString, atrDepartamentosinmemory, atrCatalogoDepartamento, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenDepartamento), tiempo_real)
        ' ''            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsDepartamento))
        ' ''        End Function

        ' ''        Public Shared Function ObtenTurno(ByVal prmTurno As Integer, Optional ByVal tiempo_real As Boolean = False) As ClsTurno
        ' ''            If atrCatalogoTurno Is Nothing Then atrCatalogoTurno = New Catalogo(New MetaCatalogo("TURNOS"))
        ' ''            Dim vobject As Object = ObtenGenerico(prmTurno.ToString, atrTurnosinmemory, atrCatalogoTurno, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenTurno), tiempo_real)
        ' ''            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsTurno))
        ' ''        End Function

        ' ''        Public Shared Function ObtenPuesto(ByVal prmPuestos As Integer, Optional ByVal tiempo_real As Boolean = False) As ClsPuesto
        ' ''            If atrCatalogoPuestos Is Nothing Then atrCatalogoPuestos = New Catalogo(New MetaCatalogo("PUESTOS"))
        ' ''            Dim vobject As Object = ObtenGenerico(prmPuestos.ToString, atrPuestosinmemory, atrCatalogoPuestos, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenPuesto), tiempo_real)
        ' ''            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsPuesto))
        ' ''        End Function

        ' ''        Public Shared Function ObtenPlaza(ByVal prmPlaza As Integer, Optional ByVal tiempo_real As Boolean = False) As ClsPlaza
        ' ''            If atrCatalogoPlazas Is Nothing Then atrCatalogoPlazas = New Catalogo(New MetaCatalogo("PLAZAS"))
        ' ''            Dim vobject As Object = ObtenGenerico(prmPlaza.ToString, atrPlazasinmemory, atrCatalogoPlazas, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenPlaza), tiempo_real)
        ' ''            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsPlaza))
        ' ''        End Function

        ' ''        Public Shared Function ObtenPlaza() As DataTable
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim dt As New DataTable

        ' ''            DAO.RegresaConsultaSQL("SELECT * FROM CTL_Plazas (NOLOCK)", dt)

        ' ''            Return dt

        ' ''        End Function

        ' ''        Public Shared Function ObtenMarcas(ByRef prmCombo As DevExpress.XtraEditors.Repository.RepositoryItemComboBox) As Boolean
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim dtmarcas As New DataTable
        ' ''            DAO.RegresaConsultaSQL("select * from CTL_Marcas(NOLOCK) where bactivo=1", dtmarcas)
        ' ''            prmCombo.Items.Clear()

        ' ''            Dim ObjSeleccione As New Catalogos.ClsMarca(0)
        ' ''            ObjSeleccione.Descripcion = "<<SELECCIONE>>"
        ' ''            prmCombo.Items.Add(ObjSeleccione)

        ' ''            For Each vrow As DataRow In dtmarcas.Rows
        ' ''                prmCombo.Items.Add(ObtenMarca(vrow))
        ' ''            Next
        ' ''            Return True
        ' ''        End Function

        ' ''        Public Shared Function ObtenMarcas(ByVal PrmArticulo As Integer, ByRef prmCombo As DevExpress.XtraEditors.Repository.RepositoryItemComboBox, ByRef PrmMarcas As DataTable) As Boolean
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim vlsql As String

        ' ''            'En caso de que bCambiaMarca=1 regresamos todas las marcar, caso contrario solo la marca de articulo
        ' ''            vlsql = "SELECT * FROM CTL_Marcas M(NOLOCK)" & vbCr
        ' ''            vlsql &= "INNER JOIN CTL_Articulos A(NOLOCK) ON ((M.nMarca=A.nMarca and A.bCambiaMarca=0) or A.bCambiaMarca=1)" & vbCr
        ' ''            vlsql &= "WHERE M.bActivo=1 and A.nArticulo=" & PrmArticulo

        ' ''            PrmMarcas = New DataTable

        ' ''            DAO.RegresaConsultaSQL(vlsql, PrmMarcas)

        ' ''            prmCombo.Items.Clear()
        ' ''            For Each vrow As DataRow In PrmMarcas.Rows
        ' ''                prmCombo.Items.Add(ObtenMarca(vrow))
        ' ''            Next
        ' ''            Return True
        ' ''        End Function

        ' ''        Public Shared Function ObtenTiposPolizasCombo(ByRef prmCombo As System.Windows.Forms.ComboBox) As Boolean
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            'If DAO.RegresaConsultaSQL("Select cDescripcion,nTipoPoliza From CTL_TiposPolizas(NoLock) Where bActivo = 1", prmCombo, DataAccessCls.TipoElementoAdicionalDeLista.Seleccione) Then
        ' ''            If DAO.RegresaConsultaSQL("Select cDescripcion,nTipoPoliza From CTL_TiposPolizas(NoLock) Where bActivo = 1", prmCombo) Then
        ' ''                Return True
        ' ''            End If
        ' ''            Return False
        ' ''        End Function

        Public Shared Function ObtenContenedorParidades(ByVal prmMoneda As Integer, ByVal prmFechaInicio As Date, ByVal prmFechaFin As Date) As DataTable
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim dtParidad As New DataTable
            Dim vlsql As String

            vlsql = "SELECT * FROM CTL_Paridades(NOLOCK) WHERE 1=0"

            DAO.RegresaEsquemaDeDatos(vlsql, dtParidad)

            vlsql = "SELECT * FROM CTL_Paridades(NOLOCK)" & vbCr
            vlsql &= "WHERE nMoneda=" & prmMoneda & vbCr
            vlsql &= "AND dbo.ADSUM_NumeroJuliano(dFecha) BETWEEN " & ClsTools.NumeroJuliano(prmFechaInicio) & vbCr
            vlsql &= "AND " & ClsTools.NumeroJuliano(prmFechaFin)

            DAO.RegresaConsultaSQL(vlsql, dtParidad)
            If dtParidad.Rows.Count = 0 Then
                Return Nothing
            Else
                dtParidad.TableName = "CTL_Paridades"
                Return dtParidad
            End If

        End Function

        ' ''        Public Shared Function ObtenZona(ByVal prmrow As DataRow) As ClsZona
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            Dim ret As New ClsZona(prmrow("nZona"))

        ' ''            ret.Folio = prmrow("nZona")
        ' ''            ret.Descripcion = prmrow("cDescripcion")
        ' ''            ret.Activo = prmrow("bActivo")
        ' ''            If Not prmrow("nCostoEntrega") Is DBNull.Value Then
        ' ''                ret.CostoEntrega = prmrow("nCostoEntrega")
        ' ''            End If
        ' ''            ret.CargaDatosRegistro(prmrow)

        ' ''            Return ret
        ' ''        End Function

        ' ''        Public Shared Function ObtenZona(ByRef prmrow As DataRow, ByVal prmobj As ClsZona) As DataRow
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            If prmobj Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If

        ' ''            prmrow("NZONA") = prmobj.Folio
        ' ''            prmrow("CDESCRIPCION") = prmobj.Descripcion
        ' ''            prmrow("BACTIVO") = prmobj.Activo

        ' ''            If Not prmobj.CostoEntrega Is DBNull.Value Then
        ' ''                prmrow("NCOSTOENTREGA") = prmobj.CostoEntrega
        ' ''            End If
        ' ''            prmobj.LLenaDatosRegistroComun(prmrow)

        ' ''            Return prmrow
        ' ''        End Function

        ' ''        Public Shared Function ObtenBanco(ByVal prmrow As DataRow) As ClsBanco
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            Dim ret As New ClsBanco(prmrow("nBanco"))
        ' ''            ret.Descripcion = prmrow("cDescripcion")
        ' ''            ret.Activo = prmrow("bActivo")
        ' ''            ret.CargaDatosRegistro(prmrow)

        ' ''            Return ret
        ' ''        End Function

        ' ''        Public Shared Function ObtenBanco(ByRef prmrow As DataRow, ByVal prmobj As ClsBanco) As DataRow
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            If prmobj Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            prmrow("nBanco") = prmobj.Folio
        ' ''            prmrow("cDescripcion") = prmobj.Descripcion
        ' ''            prmrow("bActivo") = prmobj.Activo

        ' ''            prmobj.LLenaDatosRegistroComun(prmrow)

        ' ''            Return prmrow
        ' ''        End Function

        ' ''        Public Shared Function ObtenInvolucrado(ByVal prmrow As DataRow) As ClsInvolucrado
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If

        ' ''            Dim ret As New ClsInvolucrado(prmrow("nInvolucrado"))

        ' ''            ret.Descripcion = prmrow("cNombre")
        ' ''            ret.Abreviatura = prmrow("cAbreviatura")
        ' ''            ret.Contacto = prmrow("cContacto")
        ' ''            ret.Domicilio = prmrow("cDomicilio")
        ' ''            ret.Telefonos = prmrow("cTelefonos")
        ' ''            ret.TipoInvolucrado = prmrow("cTipoInvolucrado")
        ' ''            ret.Letra = prmrow("cLetra")

        ' ''            If Not prmrow("nInvolucradoRelacionado") Is DBNull.Value Then
        ' ''                ret.InvolucradoRelacionado = FabricaCatalogos.ObtenInvolucradoRelacionado(prmrow("nInvolucradoRelacionado"))
        ' ''            End If

        ' ''            If Not prmrow("nPlaza") Is DBNull.Value Then
        ' ''                ret.Plaza = FabricaCatalogos.ObtenPlaza(prmrow("nPlaza"))
        ' ''            End If

        ' ''            ret.Activo = prmrow("bActivo")

        ' ''            ret.CargaDatosRegistro(prmrow)

        ' ''            Return ret
        ' ''        End Function

        ' ''        Public Shared Function ObtenInvolucradoRelacionado(ByVal prmInvolucradoRelacionado As Integer) As ClsInvolucrado
        ' ''            Dim ret As New ClsInvolucrado(prmInvolucradoRelacionado)

        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim dtTrabajo As New DataTable
        ' ''            Dim res As New ClsInvolucrado
        ' ''            Dim vlsql As String

        ' ''            vlsql = "SELECT * FROM CTL_Involucrados(NOLOCK)" & vbCr
        ' ''            vlsql &= "WHERE nInvolucrado=" & prmInvolucradoRelacionado & vbCr
        ' ''            'vlsql &= "AND bActivo=1"

        ' ''            DAO.RegresaConsultaSQL(vlsql, dtTrabajo)

        ' ''            For Each vRow As DataRow In dtTrabajo.Rows
        ' ''                ret.Descripcion = vRow("cNombre")
        ' ''                ret.Abreviatura = vRow("cAbreviatura")
        ' ''                ret.Contacto = vRow("cContacto")
        ' ''                ret.Domicilio = vRow("cDomicilio")
        ' ''                ret.Telefonos = vRow("cTelefonos")
        ' ''                ret.TipoInvolucrado = vRow("cTipoInvolucrado")
        ' ''                ret.Letra = vRow("cLetra")
        ' ''                ret.Activo = vRow("bActivo")

        ' ''                ret.CargaDatosRegistro(vRow)
        ' ''            Next

        ' ''            Return ret
        ' ''        End Function

        Public Shared Function ObtenPrecioDeCompraActual(ByVal prmnMoneda As Byte) As Decimal
            Dim objParidad As ClsParidad

            objParidad = FabricaCatalogos.ObtenParidad(prmnMoneda, Comunes.Comun.ClsTools.FechaDelSistema, True)

            If objParidad Is Nothing Then
                Return 0
            Else
                Return objParidad.PrecioDeCompra
            End If

        End Function

        Public Shared Function ObtenParidad(ByVal prmnMoneda As Integer, ByVal prmdFecha As DateTime, ByVal prmbConsiderarDiasVigencia As Boolean) As ClsParidad
            Dim dtTrabajo As New DataTable
            Dim vlsql As String
            Dim ret As ClsParidad
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia

            If Not prmbConsiderarDiasVigencia Then
                Return ObtenParidad(prmnMoneda, prmdFecha)
            End If

            vlsql = "SELECT * FROM CTL_Paridades(NOLOCK)" & vbCr
            vlsql &= "WHERE nMoneda=" & prmnMoneda & vbCr
            vlsql &= "AND " & ClsTools.NumeroJuliano(prmdFecha) & " BETWEEN dbo.ADSUM_NumeroJuliano(dFecha)  " & vbCr
            vlsql &= "AND dbo.ADSUM_NumeroJuliano(dFecha)"
            vlsql &= "AND bActivo=1 "

            DAO.RegresaConsultaSQL(vlsql, dtTrabajo)

            For Each vRow As DataRow In dtTrabajo.Rows
                ret = New ClsParidad
                ret.Moneda = ObtenMoneda(prmnMoneda)
                ret.Fecha = vRow("dFecha")
                ret.PrecioDeCompra = vRow("nPrecioDeCompra")
                ret.PrecioDeVenta = vRow("nPrecioDeVenta")
                'ret.DiasVigencia = vRow("nDiasVigencia")
                ret.Folio = vRow("nParidad")
                ret.Activo = vRow("bActivo")
                ret.CargaDatosRegistro(vRow)
            Next

            Return ret
        End Function

        Public Shared Function ObtenParidad(ByVal prmnMoneda As Integer, ByVal prmdFecha As DateTime) As ClsParidad
            Dim dtTrabajo As New DataTable
            Dim vlsql As String
            Dim ret As ClsParidad
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia

            vlsql = "SELECT * FROM CTL_Paridades(NOLOCK)" & vbCr
            vlsql &= "WHERE nMoneda=" & prmnMoneda & vbCr
            vlsql &= "AND dbo.ADSUM_NumeroJuliano(dFecha) = " & ClsTools.NumeroJuliano(prmdFecha) & vbCr
            vlsql &= "AND bActivo=1 "

            DAO.RegresaConsultaSQL(vlsql, dtTrabajo)

            For Each vRow As DataRow In dtTrabajo.Rows
                ret = New ClsParidad
                ret.Moneda = ObtenMoneda(prmnMoneda)
                ret.Fecha = vRow("dFecha")
                ret.PrecioDeCompra = vRow("nPrecioDeCompra")
                ret.PrecioDeVenta = vRow("nPrecioDeVenta")
                'ret.DiasVigencia = vRow("nDiasVigencia")
                ret.Folio = vRow("nParidad")
                ret.Activo = vRow("bActivo")

                ret.CargaDatosRegistro(vRow)
            Next

            Return ret
        End Function

        Public Shared Function ObtenParidad(ByVal prmnMoneda As Integer, ByVal prmnParidad As Integer) As ClsParidad
            Dim dtTrabajo As New DataTable
            Dim vlsql As String
            Dim ret As ClsParidad
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia

            vlsql = "SELECT * FROM CTL_Paridades(NOLOCK)" & vbCr
            vlsql &= "WHERE nMoneda=" & prmnMoneda & vbCr
            vlsql &= "AND nParidad=" & prmnParidad & vbCr
            vlsql &= "AND bActivo=1"

            DAO.RegresaConsultaSQL(vlsql, dtTrabajo)

            For Each vRow As DataRow In dtTrabajo.Rows
                ret = New ClsParidad
                ret.Moneda = ObtenMoneda(prmnMoneda)
                ret.Fecha = vRow("dFecha")
                ret.PrecioDeCompra = vRow("nPrecioDeCompra")
                ret.PrecioDeVenta = vRow("nPrecioDeVenta")
                'ret.DiasVigencia = vRow("nDiasVigencia")
                ret.Folio = vRow("nParidad")
                ret.Activo = vRow("bActivo")

                ret.CargaDatosRegistro(vRow)
            Next

            Return ret
        End Function

        Public Shared Function ObtenParidad(ByRef prmrow As DataRow, ByVal prmParidad As ClsParidad) As DataRow
            If prmrow Is Nothing Then
                Return Nothing
            End If

            prmrow("nParidad") = prmParidad.Folio

            prmrow("nMoneda") = prmParidad.Moneda.Folio

            prmrow("dFecha") = prmParidad.Fecha
            prmrow("nPrecioDeCompra") = prmParidad.PrecioDeCompra
            prmrow("nPrecioDeVenta") = prmParidad.PrecioDeVenta
            prmrow("nDiasVigencia") = prmParidad.DiasVigencia

            prmrow("bActivo") = prmParidad.Activo

            prmParidad.LLenaDatosRegistroComun(prmrow)

            Return prmrow
        End Function

        Public Shared Function ObtenCliente(ByVal prmCliente As Integer, ByVal prmRFCEmisor As Integer) As ClsClientes
            Dim dtTrabajo As New DataTable
            Dim vlsql As String
            Dim ret As ClsClientes
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia

            vlsql = "SELECT * FROM FAC_RECEPTORES(NOLOCK)" & vbCr
            vlsql &= "WHERE NCLIENTE = " & prmCliente & " AND NRFCEMISOR = " & prmRFCEmisor & vbCr

            DAO.RegresaConsultaSQL(vlsql, dtTrabajo)

            For Each vRow As DataRow In dtTrabajo.Rows
                ret = New ClsClientes
                ret.RFCEmisor = vRow("NRFCEMISOR")
                ret.Descripcion = IIf(vRow("CRAZONSOCIAL") Is DBNull.Value, "", vRow("CRAZONSOCIAL"))
                ret.Folio = IIf(vRow("NCLIENTE") Is DBNull.Value, 0, vRow("NCLIENTE"))
                ret.Calle = IIf(vRow("CCALLE") Is DBNull.Value, "", vRow("CCALLE"))
                ret.RFC = IIf(vRow("CRFC") Is DBNull.Value, "", vRow("CRFC"))
                ret.CodigoPostal = IIf(vRow("CCODIGOPOSTAL") Is DBNull.Value, "", vRow("CCODIGOPOSTAL"))

                ret.NoExt = IIf(vRow("CNUMEROEXTERIOR") Is DBNull.Value, "", vRow("CNUMEROEXTERIOR"))
                ret.NoInt = IIf(vRow("CNUMEROINTERIOR") Is DBNull.Value, "", vRow("CNUMEROINTERIOR"))
                ret.Colonia = IIf(vRow("CCOLONIA") Is DBNull.Value, "", vRow("CCOLONIA"))
                ret.Localidad = IIf(vRow("CLOCALIDAD") Is DBNull.Value, "", vRow("CLOCALIDAD"))
                ret.Ciudad = IIf(vRow("CMUNICIPIO") Is DBNull.Value, "", vRow("CMUNICIPIO"))
                ret.Estado = IIf(vRow("CESTADO") Is DBNull.Value, "", vRow("CESTADO"))
                ret.Pais = IIf(vRow("CPAIS") Is DBNull.Value, "", vRow("CPAIS"))
                ret.CuentaBan = IIf(vRow("CCUENTABAN") Is DBNull.Value, "", vRow("CCUENTABAN"))
                ret.Email = IIf(vRow("CCORREOELECTRONICO") Is DBNull.Value, "", vRow("CCORREOELECTRONICO"))
                ret.MetodoPago = vRow("CMETODOPAGO")

            Next

            Return ret
        End Function

        Public Shared Function ObtenCliente(ByRef prmrow As DataRow, ByVal prmCliente As ClsClientes) As DataRow
            If prmrow Is Nothing Then
                Return Nothing
            End If
            prmrow("nCliente") = prmCliente.Folio
            prmrow("NRFCEMISOR") = prmCliente.RFCEmisor
            prmrow("CRAZONSOCIAL") = prmCliente.Descripcion
            prmrow("CCALLE") = prmCliente.Calle
            prmrow("CNUMEROEXTERIOR") = prmCliente.NoExt
            prmrow("CNUMEROINTERIOR") = prmCliente.NoInt
            prmrow("CCOLONIA") = prmCliente.Colonia
            prmrow("CLOCALIDAD") = prmCliente.Localidad
            prmrow("CMUNICIPIO") = prmCliente.Ciudad
            prmrow("CESTADO") = prmCliente.Estado
            prmrow("CPAIS") = prmCliente.Pais
            prmrow("CRFC") = prmCliente.RFC
            prmrow("CCUENTABAN") = prmCliente.CuentaBan
            prmrow("CCODIGOPOSTAL") = prmCliente.CodigoPostal
            prmrow("CCORREOELECTRONICO") = prmCliente.Email
            prmrow("CMETODOPAGO") = prmCliente.MetodoPago

            Return prmrow
        End Function


        Public Shared Function ObtenProducto(ByRef prmrow As DataRow, ByVal prmProducto As ClsProducto) As DataRow
            If prmrow Is Nothing Then
                Return Nothing
            End If

            prmrow("nConcepto") = prmProducto.Folio
            prmrow("cDescripcion") = prmProducto.Descripcion
            prmrow("NPRECIO") = prmProducto.Precio
            prmrow("NIMPUESTO") = prmProducto.TasaIVA
            prmrow("NRFCEMISOR") = prmProducto.RFCEmisor

            Return prmrow
        End Function

        Public Shared Function ObtenProducto(ByVal prmcProducto As Integer, ByVal prmRFCEMISOR As Integer) As ClsProducto
            Dim dtTrabajo As New DataTable
            Dim vlsql As String
            Dim ret As ClsProducto
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia

            vlsql = "SELECT * FROM FAC_CONCEPTOS(NOLOCK)" & vbCr
            vlsql &= "WHERE NCONCEPTO = " & prmcProducto & "AND NRFCEMISOR = " & prmRFCEMISOR & vbCr

            DAO.RegresaConsultaSQL(vlsql, dtTrabajo)

            For Each vRow As DataRow In dtTrabajo.Rows
                ret = New ClsProducto
                ret.Folio = vRow("NCONCEPTO")
                ret.RFCEmisor = vRow("NRFCEMISOR")
                ret.Descripcion = vRow("cDescripcion")
                ret.Precio = vRow("NPRECIO")
                ret.TasaIVA = vRow("NIMPUESTO")
            Next
            Return ret
        End Function


        ' ''        Public Shared Function ObtenArea(ByVal prmrow As DataRow) As ClsArea
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            Dim ret As New ClsArea(prmrow("nArea"))
        ' ''            ret.Descripcion = prmrow("cDescripcion")
        ' ''            ret.Departamento = ObtenDepartamento(CInt(prmrow("ndepartamento")))
        ' ''            ret.Activo = prmrow("bActivo")
        ' ''            ret.CargaDatosRegistro(prmrow)

        ' ''            Return ret
        ' ''        End Function


        ' ''        Public Shared Function ObtenArea(ByRef prmrow As DataRow, ByVal prmobj As ClsArea) As DataRow
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            If prmobj Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            prmrow("nArea") = prmobj.Folio
        ' ''            prmrow("cDescripcion") = prmobj.Descripcion
        ' ''            prmrow("nDepartamento") = prmobj.Departamento.Folio
        ' ''            prmrow("bActivo") = prmobj.Activo

        ' ''            prmobj.LLenaDatosRegistroComun(prmrow)
        ' ''            Return prmrow
        ' ''        End Function

        Public Shared Function ObtenEmpleado(ByVal prmrow As DataRow) As ClsEmpleado
            If prmrow Is Nothing Then
                Return Nothing
            End If
            Dim ret As New ClsEmpleado(prmrow("nEmpleado"))
            ret.Nombre = prmrow("CNombre")
            ret.ApellidoPaterno = prmrow("cApellidoPaterno")
            ret.ApellidoMaterno = prmrow("cApellidoMaterno")
            If Not prmrow("cCodigoAux") Is DBNull.Value Then
                ret.CodigoAux = prmrow("cCodigoAux")
            Else
                ret.CodigoAux = ""
            End If
            ret.Pais = prmrow("cPais")
            ret.Colonia = CInt(prmrow("ncolonia"))
            ret.Direccion = prmrow("cdireccion")
            If Not prmrow("cTelefonoCelular") Is DBNull.Value Then
                ret.TelefonoCelular = prmrow("cTelefonoCelular")
            Else
                ret.TelefonoCelular = ""
            End If
            If Not prmrow("cTelefonoCasa") Is DBNull.Value Then
                ret.TelefonoCasa = prmrow("cTelefonoCasa")
            Else
                ret.TelefonoCasa = ""
            End If
            ret.FechaIngreso = prmrow("dFechaIngreso")
            ret.FechaNacimiento = prmrow("dfechanacimiento")
            ret.Puesto = CInt(prmrow("npuesto"))
            ret.Turno = CInt(prmrow("nturno"))
            ret.Sucursal = CInt(IfNull(prmrow("nsucursal"), 0))
            ret.Area = CInt(prmrow("narea"))
            ret.TipoArticulo = IfNull(prmrow("cTipoArticulo"), "")
            ret.CodigoGafete = prmrow("cCodigoGafete")
            ret.Activo = prmrow("bActivo")
            ret.CargaDatosRegistro(prmrow)

            Return ret

        End Function

        Public Shared Function ObtenEmpleado(ByRef prmrow As DataRow, ByVal prmEmpleado As ClsEmpleado) As DataRow
            If prmrow Is Nothing Then
                Return Nothing
            End If
            If prmEmpleado Is Nothing Then
                Return Nothing
            End If

            prmrow("nEmpleado") = prmEmpleado.Folio
            prmrow("CNombre") = prmEmpleado.Nombre
            prmrow("cApellidoPaterno") = prmEmpleado.ApellidoPaterno
            prmrow("cApellidoMaterno") = prmEmpleado.ApellidoMaterno
            prmrow("cCodigoAux") = prmEmpleado.CodigoAux
            prmrow("cPais") = prmEmpleado.Pais
            prmrow("ncolonia") = prmEmpleado.Colonia
            prmrow("cdireccion") = prmEmpleado.Direccion
            prmrow("cTelefonoCelular") = prmEmpleado.TelefonoCelular
            prmrow("cTelefonoCasa") = prmEmpleado.TelefonoCasa
            prmrow("dFechaIngreso") = prmEmpleado.FechaIngreso
            prmrow("dfechanacimiento") = prmEmpleado.FechaNacimiento
            prmrow("npuesto") = prmEmpleado.Puesto
            prmrow("nturno") = prmEmpleado.Turno
            prmrow("nsucursal") = prmEmpleado.Sucursal
            prmrow("narea") = prmEmpleado.Area
            prmrow("cTipoArticulo") = prmEmpleado.TipoArticulo
            prmrow("cCodigoGafete") = prmEmpleado.CodigoGafete

            prmrow("bActivo") = prmEmpleado.Activo

            prmEmpleado.LLenaDatosRegistroComun(prmrow)

            Return prmrow
        End Function

        Public Shared Function fgSiguienteCliente() As String

            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vcSQL As String

            vcSQL = "SELECT COALESCE(MAX(CCVE_CLIENTE),0)+1 FROM CTL_CLIENTES(NOLOCK)"

            Return Strings.Right(Strings.StrDup(6, "0") & DAO.RegresaDatoSQL(vcSQL), 6)

        End Function


        ' ''        Public Shared Function ObtenDepartamento(ByVal prmrow As DataRow) As ClsDepartamento
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            Dim ret As New ClsDepartamento(prmrow("nDepartamento"))
        ' ''            ret.Descripcion = prmrow("cDescripcion")
        ' ''            ret.Activo = prmrow("bActivo")
        ' ''            ret.CargaDatosRegistro(prmrow)

        ' ''            Return ret
        ' ''        End Function

        ' ''        Public Shared Function ObtenDepartamento(ByRef prmrow As DataRow, ByVal prmobj As ClsDepartamento) As DataRow
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            If prmobj Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            prmrow("nDepartamento") = prmobj.Folio
        ' ''            prmrow("cDescripcion") = prmobj.Descripcion
        ' ''            prmrow("bActivo") = prmobj.Activo

        ' ''            prmobj.LLenaDatosRegistroComun(prmrow)

        ' ''            Return prmrow
        ' ''        End Function

        ' ''        Public Shared Function ObtenTurno(ByVal prmrow As DataRow) As ClsTurno
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            Dim ret As New ClsTurno(prmrow("nTurno"))
        ' ''            ret.Descripcion = prmrow("cDescripcion")
        ' ''            ret.Activo = prmrow("bActivo")
        ' ''            ret.CargaDatosRegistro(prmrow)

        ' ''            Return ret
        ' ''        End Function

        ' ''        Public Shared Function ObtenTurno(ByRef prmrow As DataRow, ByVal prmobj As ClsTurno) As DataRow
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            If prmobj Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            prmrow("nTurno") = prmobj.Folio
        ' ''            prmrow("cDescripcion") = prmobj.Descripcion
        ' ''            prmrow("bActivo") = prmobj.Activo

        ' ''            prmobj.LLenaDatosRegistroComun(prmrow)
        ' ''            Return prmrow
        ' ''        End Function

        ' ''        Public Shared Function ObtenEstado(ByRef prmrow As DataRow, ByVal prmObj As ClsEstado) As DataRow

        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If

        ' ''            If prmObj Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If

        ' ''            prmrow("nIDEstado") = prmObj.Folio
        ' ''            prmrow("cDescripcion") = prmObj.Descripcion
        ' ''            prmrow("bActivo") = prmObj.Activo

        ' ''            prmObj.LLenaDatosRegistroComun(prmrow)
        ' ''            Return prmrow

        ' ''        End Function

        ' ''        Public Shared Function ObtenEstado(ByVal prmrow As DataRow) As ClsEstado

        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If

        ' ''            Dim ret As New ClsEstado(prmrow("nIDEstado"))
        ' ''            ret.Descripcion = prmrow("cDescripcion")
        ' ''            ret.Activo = prmrow("bActivo")
        ' ''            ret.CargaDatosRegistro(prmrow)

        ' ''            Return ret
        ' ''        End Function

        ' ''        Public Shared Function ObtenMunicipio(ByVal prmrow As DataRow) As ClsMunicipio
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If

        ' ''            Dim ret As New ClsMunicipio(prmrow("nIDMunicipio"))
        ' ''            ret.Folio = prmrow("nIDMunicipio")
        ' ''            ret.FolioLogico = prmrow("nMunicipio")
        ' ''            ret.Descripcion = prmrow("cDescripcion")
        ' ''            ret.Estado = ObtenEstado(prmrow("nIDEstado"))
        ' ''            ret.Activo = prmrow("bActivo")
        ' ''            ret.CargaDatosRegistro(prmrow)

        ' ''            Return ret
        ' ''        End Function

        ' ''        Public Shared Function ObtenMunicipio(ByRef prmrow As DataRow, ByVal prmobj As ClsMunicipio) As DataRow
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            If prmobj Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If

        ' ''            prmrow("nIDMunicipio") = prmobj.Folio
        ' ''            prmrow("nMunicipio") = prmobj.FolioLogico
        ' ''            prmrow("cDescripcion") = prmobj.Descripcion
        ' ''            prmrow("nIDEstado") = prmobj.Estado.Folio
        ' ''            prmrow("bActivo") = prmobj.Activo
        ' ''            prmobj.LLenaDatosRegistroComun(prmrow)

        ' ''            Return prmrow
        ' ''        End Function

        ' ''        Public Shared Function ObtenCiudad(ByVal prmrow As DataRow) As ClsCiudad
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If

        ' ''            Dim ret As New ClsCiudad(prmrow("nIDCiudad"))
        ' ''            ret.Folio = prmrow("nIDCiudad")            
        ' ''            ret.FolioLogico = prmrow("nCiudad")        
        ' ''            ret.Descripcion = prmrow("cDescripcion")
        ' ''            ret.Municipio = ObtenMunicipio(prmrow("nIDMunicipio"))
        ' ''            If Not prmrow("bFrontera") Is DBNull.Value Then
        ' ''                ret.Frontera = prmrow("bFrontera")
        ' ''            End If
        ' ''            ret.Activo = prmrow("bActivo")
        ' ''            ret.CargaDatosRegistro(prmrow)

        ' ''            Return ret
        ' ''        End Function

        ' ''        Public Shared Function ObtenCiudad(ByRef prmrow As DataRow, ByVal prmobj As ClsCiudad) As DataRow
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            If prmobj Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If

        ' ''            prmrow("nIDCiudad") = prmobj.Folio
        ' ''            prmrow("nCiudad") = prmobj.FolioLogico
        ' ''            '  prmrow("nIDCiudad") = prmobj.IDCiudad
        ' ''            prmrow("nIDMunicipio") = prmobj.Municipio.Folio
        ' ''            prmrow("cDescripcion") = prmobj.Descripcion
        ' ''            prmrow("bFrontera") = prmobj.Frontera
        ' ''            prmrow("bActivo") = prmobj.Activo
        ' ''            prmobj.LLenaDatosRegistroComun(prmrow)
        ' ''            Return prmrow
        ' ''        End Function

        ' ''        Public Shared Function ObtenColonia(ByVal prmrow As DataRow) As ClsColonia
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            Dim ret As New ClsColonia(prmrow("nIDColonia"))

        ' ''            ret.Folio = prmrow("nIDColonia")
        ' ''            ret.FolioLogico = prmrow("nColonia")
        ' ''            ret.Descripcion = prmrow("cDescripcion")
        ' ''            ret.Ciudad = ObtenCiudad(prmrow("nIDCiudad"))
        ' ''            ret.CodigoPostal = prmrow("cCodigoPostal")
        ' ''            ret.Zona = ObtenZona(prmrow("nZona"))
        ' ''            ret.Activo = prmrow("bActivo")
        ' ''            ret.Foraneo = prmrow("bForaneo")
        ' ''            ret.CargaDatosRegistro(prmrow)

        ' ''            Return ret
        ' ''        End Function


        ' ''        Public Shared Function ObtenColonia(ByRef prmrow As DataRow, ByVal prmobj As ClsColonia) As DataRow
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            If prmobj Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            prmrow("nColonia") = prmobj.FolioLogico
        ' ''            prmrow("nIDColonia") = prmobj.Folio
        ' ''            'If prmobj.Folio = 0 Then
        ' ''            '    prmrow("nIDColonia") = prmobj.FolioLogico
        ' ''            'End If
        ' ''            prmrow("cDescripcion") = prmobj.Descripcion
        ' ''            prmrow("nIDCiudad") = prmobj.Ciudad.Folio
        ' ''            prmrow("cCodigoPostal") = prmobj.CodigoPostal
        ' ''            prmrow("nZona") = prmobj.Zona.Folio
        ' ''            prmrow("bActivo") = prmobj.Activo
        ' ''            prmrow("bForaneo") = prmobj.Foraneo
        ' ''            prmobj.LLenaDatosRegistroComun(prmrow)
        ' ''            Return prmrow
        ' ''        End Function

        ' ''        Public Shared Function ObtenPuesto(ByVal prmrow As DataRow) As ClsPuesto
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            Dim ret As New ClsPuesto(prmrow("nPuesto"))
        ' ''            ret.Descripcion = prmrow("cDescripcion")
        ' ''            ret.Activo = prmrow("bActivo")
        ' ''            ret.CargaDatosRegistro(prmrow)

        ' ''            Return ret
        ' ''        End Function

        ' ''        Public Shared Function ObtenPuesto(ByRef prmrow As DataRow, ByVal prmobj As ClsPuesto) As DataRow
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            If prmobj Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            prmrow("nPuesto") = prmobj.Folio
        ' ''            prmrow("cDescripcion") = prmobj.Descripcion
        ' ''            prmrow("bActivo") = prmobj.Activo

        ' ''            prmobj.LLenaDatosRegistroComun(prmrow)
        ' ''            Return prmrow
        ' ''        End Function

        ' ''        Public Shared Function ObtenPlaza(ByVal prmrow As DataRow) As ClsPlaza
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            Dim ret As New ClsPlaza(prmrow("nPlaza"))
        ' ''            ret.Descripcion = prmrow("cDescripcion")
        ' ''            ret.Region = ObtenRegion(CInt(prmrow("nregion")))
        ' ''            ret.Activo = prmrow("bActivo")
        ' ''            ret.CargaDatosRegistro(prmrow)

        ' ''            Return ret


        ' ''        End Function

        ' ''        Public Shared Function ObtenPlaza(ByRef prmrow As DataRow, ByVal prmPlaza As ClsPlaza) As DataRow
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            If prmPlaza Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            prmrow("nPlaza") = prmPlaza.Folio()
        ' ''            prmrow("cDescripcion") = prmPlaza.Descripcion
        ' ''            prmrow("nRegion") = prmPlaza.Region.Folio
        ' ''            prmrow("bActivo") = prmPlaza.Activo
        ' ''            prmPlaza.LLenaDatosRegistroComun(prmrow)
        ' ''            Return prmrow
        ' ''        End Function

        ' ''        Public Shared Function ObtenRegion(ByVal prmRegion As Integer, Optional ByVal tiempo_real As Boolean = False) As ClsRegion
        ' ''            If atrCatalogoRegiones Is Nothing Then atrCatalogoRegiones = New Catalogo(New MetaCatalogo("REGIONES"))
        ' ''            Dim vobject As Object = ObtenGenerico(prmRegion.ToString, atrRegionesinmemory, atrCatalogoRegiones, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenRegion), tiempo_real)
        ' ''            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsRegion))
        ' ''        End Function

        ' ''        Public Shared Function ObtenRegion(ByVal prmrow As DataRow) As ClsRegion
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            Dim ret As New ClsRegion(prmrow("nRegion"))
        ' ''            ret.Descripcion = prmrow("cDescripcion")
        ' ''            ret.Activo = prmrow("bActivo")
        ' ''            ret.CargaDatosRegistro(prmrow)

        ' ''            Return ret

        ' ''        End Function

        ' ''        Public Shared Function ObtenInvolucrado(ByRef prmrow As DataRow, ByVal prmInvolucrado As ClsInvolucrado) As DataRow
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            If prmInvolucrado Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If

        ' ''            prmrow("nInvolucrado") = prmInvolucrado.Folio
        ' ''            prmrow("cNombre") = prmInvolucrado.Descripcion
        ' ''            prmrow("cAbreviatura") = prmInvolucrado.Abreviatura
        ' ''            prmrow("bActivo") = prmInvolucrado.Activo
        ' ''            prmrow("cContacto") = prmInvolucrado.Contacto
        ' ''            prmrow("cDomicilio") = prmInvolucrado.Domicilio
        ' ''            prmrow("cTelefonos") = prmInvolucrado.Telefonos
        ' ''            prmrow("cTipoInvolucrado") = prmInvolucrado.TipoInvolucrado
        ' ''            prmrow("cLetra") = prmInvolucrado.Letra
        ' ''            prmrow("nPlaza") = prmInvolucrado.Plaza.Folio

        ' ''            If Not prmInvolucrado.InvolucradoRelacionado Is Nothing Then
        ' ''                prmrow("nInvolucradoRelacionado") = prmInvolucrado.InvolucradoRelacionado.Folio
        ' ''            End If

        ' ''            prmInvolucrado.LLenaDatosRegistroComun(prmrow)

        ' ''            Return prmrow
        ' ''        End Function

        ' ''        Public Shared Function ObtenRegion(ByRef prmrow As DataRow, ByVal prmRegion As ClsRegion) As DataRow
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            If prmRegion Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            prmrow("nRegion") = prmRegion.Folio()
        ' ''            prmrow("cDescripcion") = prmRegion.Descripcion
        ' ''            prmrow("bActivo") = prmRegion.Activo
        ' ''            prmRegion.LLenaDatosRegistroComun(prmrow)
        ' ''            Return prmrow
        ' ''        End Function


        ' ''        Public Shared Function ObtenVehiculo(ByVal prmVehiculo As Integer, Optional ByVal tiempo_real As Boolean = False) As ClsVehiculos
        ' ''            If atrCatalogoVehiculos Is Nothing Then atrCatalogoVehiculos = New Catalogo(New MetaCatalogo("VEHICULOS"))
        ' ''            Dim vobject As Object = ObtenGenerico(prmVehiculo.ToString, atrVehiculosInMemory, atrCatalogoVehiculos, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenVehiculo), tiempo_real)
        ' ''            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsVehiculos))
        ' ''        End Function

        ' ''        Public Shared Function ObtenVehiculo(ByVal prmrow As DataRow) As ClsVehiculos
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            Dim ret As New ClsVehiculos(prmrow("nVehiculo"))
        ' ''            ret.Descripcion = prmrow("cDescripcion")
        ' ''            ret.Placas = Dominio.Comun.ClsTools.IfNull(prmrow("cPlacas"), "")
        ' ''            ret.TipoVehiculo = prmrow("nTipoVehiculo")
        ' ''            ret.Activo = prmrow("bActivo")
        ' ''            ret.CargaDatosRegistro(prmrow)
        ' ''            Return ret
        ' ''        End Function
        ' ''        Public Shared Function ObtenVehiculo(ByRef prmrow As DataRow, ByVal prmVehiculo As ClsVehiculos) As DataRow
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            If prmVehiculo Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            prmrow("nVehiculo") = prmVehiculo.Folio
        ' ''            prmrow("cDescripcion") = prmVehiculo.Descripcion
        ' ''            prmrow("cPlacas") = prmVehiculo.Placas
        ' ''            prmrow("nTipoVehiculo") = prmVehiculo.TipoVehiculo
        ' ''            prmrow("bActivo") = prmVehiculo.Activo
        ' ''            prmVehiculo.LLenaDatosRegistroComun(prmrow)
        ' ''            Return prmrow
        ' ''        End Function


        ' ''        Public Shared Function ObtenTipoProducto(ByVal prmTipoProducto As Integer, Optional ByVal tiempo_real As Boolean = False) As ClsTipoProducto
        ' ''            If atrCatalogoTiposProductos Is Nothing Then atrCatalogoTiposProductos = New Catalogo(New MetaCatalogo("TIPOSPRODUCTOS"))
        ' ''            Dim vobject As Object = ObtenGenerico(prmTipoProducto.ToString, atrTiposProductosInMemory, atrCatalogoTiposProductos, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenTipoProducto), tiempo_real)
        ' ''            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsTipoProducto))
        ' ''        End Function

        ' ''        Public Shared Function ObtenTipoProducto(ByVal prmrow As DataRow) As ClsTipoProducto
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            Dim ret As New ClsTipoProducto(prmrow("nTipoProducto"))
        ' ''            ret.Descripcion = prmrow("cDescripcion")
        ' ''            ret.Activo = prmrow("bActivo")
        ' ''            ret.CargaDatosRegistro(prmrow)
        ' ''            Return ret
        ' ''        End Function
        ' ''        Public Shared Function ObtenTipoProducto(ByRef prmrow As DataRow, ByVal prmTipoProducto As ClsTipoProducto) As DataRow
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            If prmTipoProducto Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            prmrow("nTipoProducto") = prmTipoProducto.Folio
        ' ''            prmrow("cDescripcion") = prmTipoProducto.Descripcion
        ' ''            prmrow("bActivo") = prmTipoProducto.Activo
        ' ''            prmTipoProducto.LLenaDatosRegistroComun(prmrow)
        ' ''            Return prmrow
        ' ''        End Function




        ' ''        Public Shared Function ObtenTipoDato(ByVal prmTipoDato As Integer, Optional ByVal tiempo_real As Boolean = False) As ClsTiposDatos
        ' ''            If atrCatalogoTipoDato Is Nothing Then atrCatalogoTipoDato = New Catalogo(New MetaCatalogo("TIPOS_DATOS"))
        ' ''            Dim vobject As Object = ObtenGenerico(prmTipoDato.ToString, atrTipoDatoInMemory, atrCatalogoTipoDato, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenTipoDato), tiempo_real)
        ' ''            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsTipoProducto))
        ' ''        End Function

        ' ''        Public Shared Function ObtenTipoDato(ByVal prmrow As DataRow) As ClsTiposDatos
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            Dim ret As New ClsTiposDatos(prmrow("nTipoDato"))
        ' ''            ret.Llave = prmrow("cLlave")
        ' ''            ret.ValorDescripcion = prmrow("cValor")
        ' ''            ret.Valor = prmrow("nValor")
        ' ''            ' ret.CargaDatosRegistro(prmrow)
        ' ''            Return ret
        ' ''        End Function
        ' ''        Public Shared Function ObtenTipoDato(ByRef prmrow As DataRow, ByVal prmTipoDato As ClsTiposDatos) As DataRow
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            If prmTipoDato Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            prmrow("nTipoDato") = prmTipoDato.Folio
        ' ''            prmrow("cLlave") = prmTipoDato.Llave
        ' ''            prmrow("cValor") = prmTipoDato.ValorDescripcion
        ' ''            prmrow("nValor") = prmTipoDato.Valor
        ' ''            '           prmTipoProducto.LLenaDatosRegistroComun(prmrow)
        ' ''            Return prmrow
        ' ''        End Function

        ' ''        Public Shared Function ObtenTipoArticulo(ByVal prmTipoArticulo As Integer, Optional ByVal tiempo_real As Boolean = False) As ClsTipoArticulo
        ' ''            If atrCatalogoTiposArticulos Is Nothing Then atrCatalogoTiposArticulos = New Catalogo(New MetaCatalogo("TIPOS_ARTICULOS"))
        ' ''            Dim vobject As Object = ObtenGenerico(prmTipoArticulo.ToString, atrTiposArticulosinmemory, atrCatalogoTiposArticulos, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenTipoArticulo), tiempo_real)
        ' ''            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsTipoArticulo))
        ' ''        End Function

        ' ''        Public Shared Sub PgLlenaComboTipoArticuloComboBox(ByRef prmCombo As System.Windows.Forms.ComboBox, Optional ByVal objEmpleado As ClsEmpleado = Nothing)
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim Vlsql As String
        ' ''            Dim dt As New DataTable

        ' ''            Vlsql = "SELECT UPPER(cDescripcion) AS cDescripcion,nTipoArticulo" & vbCr
        ' ''            Vlsql &= "FROM  Ctl_TiposArticulos(NOLOCK)" & vbCr
        ' ''            Vlsql &= "WHERE bActivo=1" & vbCr
        ' ''            If Not objEmpleado Is Nothing Then
        ' ''                Vlsql &= "AND nTipoArticulo IN (" & objEmpleado.TipoArticulo & ")"
        ' ''            End If

        ' ''            DAO.RegresaConsultaSQL(Vlsql, dt)

        ' ''            prmCombo.Items.Clear()
        ' ''            Dim Obj As New Dominio.Catalogos.ClsTipoArticulo(0)
        ' ''            Obj.Descripcion = "<<SELECCIONE>>"
        ' ''            Obj.Folio = 0
        ' ''            prmCombo.Items.Add(Obj)


        ' ''            For Each dr As DataRow In dt.Rows
        ' ''                Obj = New ClsTipoArticulo(dr("nTipoArticulo"))
        ' ''                Obj.Descripcion = dr("cDescripcion")
        ' ''                prmCombo.Items.Add(Obj)
        ' ''            Next

        ' ''        End Sub

        ' ''        Public Shared Function ObtenTipoArticulo(ByVal prmrow As DataRow) As ClsTipoArticulo
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            Dim ret As New ClsTipoArticulo(prmrow("nTipoArticulo"))
        ' ''            ret.Descripcion = prmrow("cDescripcion")
        ' ''            ret.Activo = prmrow("bActivo")
        ' ''            ret.CargaDatosRegistro(prmrow)

        ' ''            Return ret

        ' ''        End Function

        ' ''        Public Shared Function ObtenTipoArticulo(ByRef prmrow As DataRow, ByVal prmTipoArticulo As ClsTipoArticulo) As DataRow
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            If prmTipoArticulo Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            prmrow("nTipoArticulo") = prmTipoArticulo.Folio
        ' ''            prmrow("cDescripcion") = prmTipoArticulo.Descripcion
        ' ''            prmrow("bActivo") = prmTipoArticulo.Activo
        ' ''            prmTipoArticulo.LLenaDatosRegistroComun(prmrow)
        ' ''            Return prmrow
        ' ''        End Function

        ' ''        Public Shared Function TipoMovimientoTieneMovimientosDeAlmacen(ByVal prmTipoMovimiento As Inventarios.ClsTipoMovimiento) As Boolean
        ' ''            If prmTipoMovimiento Is Nothing Then
        ' ''                Return False
        ' ''            End If
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim dtMovimientos As New DataTable
        ' ''            If DAO.RegresaConsultaSQL("Select top 1 * From INV_MovimientosAlmacen (NOLOCK) Where nTipoMovimiento = " & prmTipoMovimiento.Folio, dtMovimientos) Then
        ' ''                If dtMovimientos.Rows.Count > 0 Then
        ' ''                    Return True
        ' ''                End If
        ' ''            End If
        ' ''            Return False
        ' ''        End Function

        ' ''        Public Shared Function ObtenContenedorImpuestos(ByVal prmarticulo As ClsArticulo) As DataTable
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim dtCodigos As New DataTable
        ' ''            DAO.RegresaEsquemaDeDatos("select * from ctl_ArticulosImpuestos (NOLOCK) WHERE 1=0", dtCodigos)
        ' ''            DAO.RegresaConsultaSQL("select * from ctl_ArticulosImpuestos (NOLOCK) where narticulo=" & prmarticulo.Folio, dtCodigos)

        ' ''            Return dtCodigos

        ' ''        End Function

        ' ''        Public Shared Function ObtenArticuloImpuesto(ByVal prmArticulo As Integer, ByVal prmImpuesto As Integer) As ClsArticuloImpuesto
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim dtImpuesto As New DataTable
        ' ''            DAO.RegresaEsquemaDeDatos("select * from ctl_ArticulosImpuestos (NOLOCK) WHERE 1=0", dtImpuesto)
        ' ''            DAO.RegresaConsultaSQL("select * from ctl_ArticulosImpuestos (NOLOCK) where narticulo=" & prmArticulo & " and nimpuesto=" & prmImpuesto, dtImpuesto)
        ' ''            Return ObtenArticuloImpuesto(dtImpuesto.Rows(0))

        ' ''        End Function

        ' ''        Public Shared Function ObtenArticuloImpuesto(ByVal prmrow As DataRow) As ClsArticuloImpuesto
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            Dim ret As New ClsArticuloImpuesto
        ' ''            'ret.Folio = prmrow("nArticulo")
        ' ''            ret.Articulo = New ClsArticulo(prmrow("narticulo"))
        ' ''            ret.Impuesto = New ClsImpuesto(prmrow("nimpuesto"))
        ' ''            ret.Activo = prmrow("bActivo")
        ' ''            Try
        ' ''                ret.CargaDatosRegistro(prmrow)
        ' ''            Catch
        ' ''            End Try
        ' ''            Return ret

        ' ''        End Function

        ' ''        Public Shared Function ObtenArticuloImpuesto(ByRef prmrow As DataRow, ByVal prmArticuloImpuesto As ClsArticuloImpuesto) As DataRow
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            prmrow("narticulo") = prmArticuloImpuesto.Articulo.Folio
        ' ''            prmrow("nimpuesto") = prmArticuloImpuesto.Impuesto.Folio
        ' ''            prmrow("bActivo") = prmArticuloImpuesto.Activo
        ' ''            If prmArticuloImpuesto.atrAccion = 0 Then
        ' ''                If prmArticuloImpuesto.Activo Then
        ' ''                    prmArticuloImpuesto.atrAccion = Comun.EAccionesBD.Insertar
        ' ''                Else
        ' ''                    prmArticuloImpuesto.atrAccion = Comun.EAccionesBD.Eliminar
        ' ''                End If
        ' ''            End If
        ' ''            Try
        ' ''                prmArticuloImpuesto.LLenaDatosRegistroComun(prmrow)
        ' ''            Catch
        ' ''            End Try
        ' ''            Return prmrow

        ' ''        End Function

        ' ''        Public Shared Function ObtenContenedorCodigosProveedor(ByVal PrmArticulo As ClsArticulo) As DataTable
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim dtCodigos As New DataTable

        ' ''            DAO.RegresaEsquemaDeDatos("SELECT * FROM CTL_ProveedoresArticulos(NOLOCK) WHERE 1=0", dtCodigos)

        ' ''            DAO.RegresaConsultaSQL("SELECT * FROM CTL_ProveedoresArticulos(NOLOCK) WHERE nArticulo=" & PrmArticulo.Folio, dtCodigos)

        ' ''            Return dtCodigos
        ' ''        End Function

        ' ''        Public Shared Function ObtenContenedorCodigosProveedor(ByVal PrmProveedor As Proveedores.ClsProveedor, ByVal prmPlaza As ClsPlaza) As DataTable
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim dtCodigos As New DataTable
        ' ''            Dim vSql As String = ""
        ' ''            Dim vSqlFiltro As String = ""

        ' ''            vSql = "SELECT * FROM CTL_ProveedoresArticulos(NOLOCK)" & vbCr

        ' ''            If Not PrmProveedor Is Nothing Then
        ' ''                vSqlFiltro = "nProveedor = " & PrmProveedor.Folio & " And " & vbCr
        ' ''            End If
        ' ''            If Not prmPlaza Is Nothing Then
        ' ''                vSqlFiltro = "nPlaza = " & prmPlaza.Folio & " And " & vbCr
        ' ''            End If

        ' ''            DAO.RegresaEsquemaDeDatos(vSql & " WHERE 1=0", dtCodigos)

        ' ''            If vSqlFiltro.Trim <> "" Then
        ' ''                vSqlFiltro = vSqlFiltro.Substring(0, vSqlFiltro.Length - 5)
        ' ''                vSqlFiltro = " Where " & vSqlFiltro
        ' ''                vSql = vSql & vSqlFiltro
        ' ''            End If



        ' ''            DAO.RegresaConsultaSQL(vSql, dtCodigos)

        ' ''            Return dtCodigos
        ' ''        End Function

        ' ''        Public Shared Function ObtenContenedorCodigosProveedorTablasMasivo(ByVal PrmProveedor As Proveedores.ClsProveedor, ByVal prmPlaza As ClsPlaza) As DataSet
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim dtDatos As New DataSet
        ' ''            Dim vSql As String = ""
        ' ''            Dim vSqlFiltro As String = ""

        ' ''            'vSql = "SELECT * FROM CTL_ProveedoresArticulos(NOLOCK)" & vbCr

        ' ''            'If Not PrmProveedor Is Nothing Then
        ' ''            '    vSqlFiltro = "nProveedor = " & PrmProveedor.Folio & " And " & vbCr
        ' ''            'End If
        ' ''            'If Not prmPlaza Is Nothing Then
        ' ''            '    vSqlFiltro = "nPlaza = " & prmPlaza.Folio & " And " & vbCr
        ' ''            'End If

        ' ''            'DAO.RegresaEsquemaDeDatos(vSql & " WHERE 1=0", da)

        ' ''            'If vSqlFiltro.Trim <> "" Then
        ' ''            '    vSqlFiltro = vSqlFiltro.Substring(0, vSqlFiltro.Length - 5)
        ' ''            '    vSqlFiltro = " Where " & vSqlFiltro
        ' ''            '    vSql = vSql & vSqlFiltro
        ' ''            'End If 


        ' ''            'DAO.RegresaConsultaSQL(vSql, dtCodigos)

        ' ''            Return dtDatos
        ' ''        End Function


        ' ''        Public Shared Function ObtenCodigoProveedor(ByVal prmProveedor As Integer, ByVal prmArticulo As Integer) As Proveedores.ClsProveedorArticulos
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim dtPresentacion As New DataTable

        ' ''            DAO.RegresaConsultaSQL("SELECT  * FROM CTL_ProveedoresArticulos(NOLOCK) where nProveedor=" & prmProveedor & " and nArticulo=" & prmArticulo, dtPresentacion)

        ' ''            If dtPresentacion.Rows.Count = 0 Then
        ' ''                Return Nothing
        ' ''            Else
        ' ''                Return ObtenCodigoProveedor(dtPresentacion.Rows(0))
        ' ''            End If
        ' ''        End Function

        ' ''        Public Shared Function ObtenCodigoProveedor(ByVal prmrow As DataRow) As Proveedores.ClsProveedorArticulos
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            Dim ret As New Proveedores.ClsProveedorArticulos()
        ' ''            ret.Folio = prmrow("nArticulo")
        ' ''            ret.Articulo = New ClsArticulo(prmrow("narticulo"))
        ' ''            ret.Presentacion = New ClsPresentacion(prmrow("npresentacion"))
        ' ''            ret.Proveedor = New Proveedores.ClsProveedor()
        ' ''            ret.Proveedor.Folio = prmrow("nproveedor")
        ' ''            ret.CodigoProveedor = prmrow("ccodigoproveedor")
        ' ''            ret.Marca = ObtenMarca(CInt(prmrow("nmarca")))
        ' ''            ret.Activo = prmrow("bactivo")
        ' ''            ret.Plaza = ObtenPlaza(CInt(prmrow("nPlaza")))
        ' ''            ret.CargaDatosRegistro(prmrow)
        ' ''            Return ret

        ' ''        End Function

        ' ''        Public Shared Function ObtenCodigoProveedor(ByRef prmrow As DataRow, ByVal prmPresentacion As Proveedores.ClsProveedorArticulos) As DataRow
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            prmrow("narticulo") = prmPresentacion.Articulo.Folio
        ' ''            prmrow("npresentacion") = prmPresentacion.Presentacion.Folio
        ' ''            prmrow("nproveedor") = prmPresentacion.Proveedor.Folio
        ' ''            prmrow("ccodigoproveedor") = prmPresentacion.CodigoProveedor
        ' ''            prmrow("nmarca") = prmPresentacion.Marca.Folio
        ' ''            prmrow("bactivo") = prmPresentacion.Activo
        ' ''            prmrow("nPlaza") = prmPresentacion.Plaza.Folio
        ' ''            prmPresentacion.LLenaDatosRegistroComun(prmrow)
        ' ''            Return prmrow

        ' ''            Return prmrow
        ' ''        End Function



        ' ''        Public Shared Function ObtenContenedorPresentacion(ByVal prmarticulo As ClsArticulo) As DataTable
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim dtPresentacion As New DataTable
        ' ''            'DAO.RegresaEsquemaDeDatos("select a.*, b.cDescripcion as cPresentacionConversion from ctl_articulospresentaciones(NOLOCK) a LEFT JOIN ctl_articulospresentaciones(NOLOCK) b ON a.nPresentacionConversion = b.nPresentacion where 1=0", dtPresentacion)
        ' ''            DAO.RegresaConsultaSQL("select a.*,b.cDescripcion as cPresentacionConversion from ctl_articulospresentaciones(NOLOCK) a LEFT JOIN ctl_articulospresentaciones(NOLOCK) b ON a.narticulo=b.narticulo And a.nPresentacionConversion = b.nPresentacion where a.narticulo=" & prmarticulo.Folio & " AND a.bActivo = 1", dtPresentacion)
        ' ''            'If dtPresentacion.Rows.Count = 0 Then
        ' ''            '    Return Nothing
        ' ''            'Else
        ' ''            Dim keys(1) As DataColumn
        ' ''            keys(0) = dtPresentacion.Columns(0)
        ' ''            keys(1) = dtPresentacion.Columns(1)
        ' ''            dtPresentacion.PrimaryKey = keys
        ' ''            dtPresentacion.TableName = "ctl_articulospresentaciones"
        ' ''            Return dtPresentacion
        ' ''            'End If
        ' ''        End Function

        ' ''        Public Shared Function ObtenPresentacion(ByVal prmArticulo As Integer, ByVal prmPresentacion As Integer) As ClsPresentacion
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim dtPresentacion As New DataTable
        ' ''            DAO.RegresaConsultaSQL("select * from ctl_articulospresentaciones(NOLOCK) where narticulo=" & prmArticulo & " and npresentacion=" & prmPresentacion, dtPresentacion)
        ' ''            If dtPresentacion.Rows.Count = 0 Then
        ' ''                Return Nothing
        ' ''            Else
        ' ''                Return ObtenPresentacion(dtPresentacion.Rows(0))
        ' ''            End If
        ' ''        End Function

        ' ''        Public Shared Function ObtenEquivalenciaPresentacion(ByVal prmArticulo As Int32, ByVal prmPresentacion As Int16) As Decimal
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim vSQL As String = ""
        ' ''            vSQL = "SELECT nEquivalencia FROM CTL_ArticulosPresentaciones (NOLOCK) " & vbCr
        ' ''            vSQL &= " WHERE nArticulo = " & prmArticulo & " AND nPresentacion = " & prmPresentacion
        ' ''            Return DAO.RegresaDatoSQL(vSQL)
        ' ''        End Function
        ' ''        Public Shared Function ObtenArticuloPresentacion(ByVal prmArticulo As String, ByVal prmPresentacion As Integer) As ClsPresentacion
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim dtPresentacion As New DataTable
        ' ''            Dim vSQL As String = "select AP.* from CTL_Articulos A (NOLOCK) " & vbCr
        ' ''            vSQL &= " INNER JOIN CTL_ArticulosPresentaciones AP (NOLOCK) " & vbCr
        ' ''            vSQL &= " ON A.nArticulo = AP.nArticulo " & vbCr
        ' ''            vSQL &= " WHERE A.cCodigo = '" & prmArticulo & "' AND AP.nPresentacion = " & prmPresentacion
        ' ''            DAO.RegresaConsultaSQL(vSQL, dtPresentacion)
        ' ''            If dtPresentacion.Rows.Count = 0 Then
        ' ''                Return Nothing
        ' ''            Else
        ' ''                Return ObtenPresentacion(dtPresentacion.Rows(0))
        ' ''            End If
        ' ''        End Function

        ' ''        Public Shared Function ObtenExtensionArchivoDBFParaAlmacen(ByVal prmDestino As Int32) As String
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Return DAO.RegresaDatoSQL("SELECT isnull(cExtension,'') FROM CTL_ExtensionesArchivosPedidosDBF (NOLOCK)  WHERE nDestino = " & prmDestino)
        ' ''        End Function

        ' ''        Public Shared Function ObtenClaveClienteArchivoDBFParaAlmacen(ByVal prmDestino As Int32) As String
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Return DAO.RegresaDatoSQL("SELECT isnull(cClave,'') FROM CTL_ExtensionesArchivosPedidosDBF (NOLOCK)  WHERE nDestino = " & prmDestino)
        ' ''        End Function

        ' ''        Public Shared Function ObtenNombreDeArchivoDBFParaAlmacen(ByVal prmDestino As Int32) As String

        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Return DAO.RegresaDatoSQL("SELECT isnull(cNombreArchivo,'') FROM CTL_ExtensionesArchivosPedidosDBF (NOLOCK) WHERE nDestino = " & prmDestino)
        ' ''        End Function

        ' ''        Public Shared Function ObtenNombreDeArchivoPedidoSucDBF(ByVal prmDestino As Int32) As String
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Return DAO.RegresaDatoSQL("SELECT isnull(cNombreArchivoPedido,'') FROM CTL_ExtensionesArchivosPedidosDBF (NOLOCK) WHERE nDestino = " & prmDestino)
        ' ''        End Function

        ' ''        Public Shared Function ObtenNombreDeArchivoDevolucionesSucDBF(ByVal prmDestino As Int32) As String
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Return DAO.RegresaDatoSQL("SELECT isnull(cNombreArchivoDevoluciones,'') FROM CTL_ExtensionesArchivosPedidosDBF (NOLOCK) WHERE nDestino = " & prmDestino)
        ' ''        End Function

        ' ''        Public Shared Function ObtenNombreDeArchivoInventariosSucDBF(ByVal prmDestino As Int32) As String
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Return DAO.RegresaDatoSQL("SELECT isnull(cNombreArchivoExistencias,'') FROM CTL_ExtensionesArchivosPedidosDBF (NOLOCK) WHERE nDestino = " & prmDestino)
        ' ''        End Function

        ' ''        Public Shared Function ObtenPresentacionesConversion(ByVal prmArticulo As Integer, ByRef prmCombo As System.Windows.Forms.ComboBox) As Boolean
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            If DAO.RegresaConsultaSQL("Select cDescripcion, nPresentacion from ctl_articulospresentaciones(NOLOCK) Where nArticulo = " & prmArticulo & " And not nPresentacionConversion is Null And bActivo = 1", prmCombo, DataAccessCls.TipoElementoAdicionalDeLista.Seleccione) Then
        ' ''                Return True
        ' ''            End If
        ' ''            Return False
        ' ''        End Function

        ' ''        Public Shared Function ObtenPresentacion(ByVal prmrow As DataRow) As ClsPresentacion
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            Dim ret As New ClsPresentacion(prmrow("npresentacion"))
        ' ''            ret.Articulo = ObtenArticulo(CInt(prmrow("narticulo")))
        ' ''            ret.Descripcion = IfNull(prmrow("cDescripcion"), "")
        ' ''            ret.Equivalencia = prmrow("nEquivalencia")
        ' ''            ret.Drenado = IfNull(prmrow("nDrenado"), 0)
        ' ''            If Not prmrow("nPresentacionCatalogo") Is DBNull.Value Then
        ' ''                ret.PresentacionCatalogo = Catalogos.FabricaCatalogos.ObtenPresentacionArticulos(prmrow("nPresentacionCatalogo"))
        ' ''            End If
        ' ''            If Not prmrow("bactivo") Is DBNull.Value Then
        ' ''                ret.Activo = prmrow("bactivo")
        ' ''            End If
        ' ''            If Not prmrow("nPresentacionConversion") Is DBNull.Value Then
        ' ''                ret.PresentacionConversion = ObtenPresentacion(prmrow("nArticulo"), prmrow("nPresentacionConversion"))
        ' ''            End If
        ' ''            ret.CargaDatosRegistro(prmrow)
        ' ''            Return ret

        ' ''        End Function

        ' ''        Public Shared Function ObtenPresentacionesEnGridComboBox(ByVal articulo As Integer, Optional ByVal combo As DevExpress.XtraEditors.Repository.RepositoryItemComboBox = Nothing) As ArrayList
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim SQLText As String = "SELECT cDescripcion ,nEquivalencia ,nPresentacion FROM CTL_ArticulosPresentaciones(NOLOCK) WHERE bActivo = 1 AND nArticulo = " & articulo.ToString & " ORDER BY nEquivalencia"
        ' ''            Dim dtPresentaciones As New DataTable
        ' ''            If Not DAO.RegresaConsultaSQL(SQLText, dtPresentaciones) Then Return Nothing
        ' ''            Dim miArray As New ArrayList
        ' ''            If Not combo Is Nothing Then
        ' ''                combo.Items.Clear()
        ' ''            End If
        ' ''            For Each drRow As DataRow In dtPresentaciones.Rows
        ' ''                Dim miPresentacion As New ClsPresentacion(drRow("nPresentacion"))
        ' ''                miPresentacion.Descripcion = drRow("cDescripcion")
        ' ''                miPresentacion.Equivalencia = drRow("nEquivalencia")
        ' ''                miArray.Add(miPresentacion)

        ' ''                If Not combo Is Nothing Then
        ' ''                    combo.Items.Add(miPresentacion)
        ' ''                End If
        ' ''            Next

        ' ''            ''En caso de solo contar con una presentacion, seleccionamos esta
        ' ''            If dtPresentaciones.Rows.Count = 1 AndAlso Not combo Is Nothing Then
        ' ''                ''pendiente
        ' ''            End If

        ' ''            Return miArray
        ' ''        End Function

        ' ''        Public Shared Function ObtenPresentacion(ByRef prmrow As DataRow, ByVal prmPresentacion As ClsPresentacion) As DataRow
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            prmrow("npresentacion") = prmPresentacion.Folio
        ' ''            prmrow("narticulo") = prmPresentacion.Articulo.Folio
        ' ''            prmrow("cDescripcion") = prmPresentacion.Descripcion
        ' ''            prmrow("nEquivalencia") = prmPresentacion.Equivalencia
        ' ''            prmrow("nDrenado") = prmPresentacion.Drenado
        ' ''            If Not prmPresentacion.PresentacionCatalogo Is Nothing Then
        ' ''                prmrow("nPresentacionCatalogo") = prmPresentacion.PresentacionCatalogo.Folio
        ' ''            Else
        ' ''                prmrow("nPresentacionCatalogo") = 0
        ' ''            End If
        ' ''            prmrow("bactivo") = prmPresentacion.Activo
        ' ''            If Not prmPresentacion.PresentacionConversion Is Nothing Then
        ' ''                prmrow("nPresentacionConversion") = prmPresentacion.PresentacionConversion.Folio
        ' ''                prmrow("nEquivalenciaConversion") = prmPresentacion.PresentacionConversion.Equivalencia
        ' ''            End If
        ' ''            ' prmPresentacion.LLenaDatosRegistroComun(prmrow)
        ' ''            Return prmrow


        ' ''            Return prmrow
        ' ''        End Function
        ' ''        Public Shared Function ObtenCliente(ByVal prmCliente As Integer) As Dominio.Catalogos.Distribucion.ClsClientes
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim dtCliente As New DataTable
        ' ''            DAO.RegresaConsultaSQL("Select * FROM CTL_Clientes (NOLOCK) WHERE nCliente = " & prmCliente, dtCliente)
        ' ''            If dtCliente.Rows.Count = 0 Then
        ' ''                Return Nothing
        ' ''            Else
        ' ''                Return ObtenCliente(dtCliente.Rows(0))
        ' ''            End If
        ' ''        End Function
        ' ''        Public Shared Function ObtenCliente(ByVal prmTelefono As String, ByVal prmBand As Int32) As Dominio.Catalogos.Distribucion.ClsClientes
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim dtCliente As New DataTable
        ' ''            DAO.RegresaConsultaSQL("Select * FROM CTL_Clientes (NOLOCK) WHERE WHERE cTelefonoUno = '" & prmTelefono & "' or cTelefonoDos='" & prmTelefono & "'or cTelefonoFax='" & prmTelefono & "'", dtCliente)
        ' ''            If dtCliente.Rows.Count = 0 Then
        ' ''                Return Nothing
        ' ''            Else
        ' ''                Return ObtenCliente(dtCliente.Rows(0))
        ' ''            End If
        ' ''        End Function
        ' ''        'Select * FROM CTL_Clientes (NOLOCK) WHERE cTelefonoUno = 'prmTelefono' or cTelefonoDos='prmTelefono'or cTelefonoFax='prmTelefono'
        ' ''        'Public Shared Function ObtenCliente(ByVal prmCliente As String) As Dominio.Catalogos.Distribucion.ClsClientes
        ' ''        '    Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''        '    Dim dtCliente As New DataTable
        ' ''        '    DAO.RegresaConsultaSQL("Select * FROM CTL_Clientes (NOLOCK) WHERE cCodigo = '" & prmCliente & "'", dtCliente)
        ' ''        '    If dtCliente.Rows.Count = 0 Then
        ' ''        '        Return Nothing
        ' ''        '    Else
        ' ''        '        Return ObtenCliente(dtCliente.Rows(0))
        ' ''        '    End If
        ' ''        'End Function
        ' ''        Public Shared Function ObtenCliente(ByVal prmrow As DataRow) As Distribucion.ClsClientes
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            Dim ret As New Distribucion.ClsClientes(prmrow("nCliente"))
        ' ''            ret.Observaciones = IfNull(prmrow("cObservaciones"), "")
        ' ''            ret.Curp = IfNull(prmrow("cCurp"), "")
        ' ''            ret.Plaza = Catalogos.FabricaCatalogos.ObtenPlaza(prmrow("nPlaza"))
        ' ''            ret.ExcentoDomicilio = IfNull(prmrow("bExcentoDomicilio"), False)
        ' ''            ret.NombreFiscal = prmrow("cNombreFiscal")
        ' ''            ret.NombreComercial = prmrow("cNombreComercial")
        ' ''            ret.NombreCorto = IfNull(prmrow("cNombreCorto"), "")
        ' ''            ret.RFC = IfNull(prmrow("cRFC"), "")
        ' ''            ret.Pais = IfNull(prmrow("cPais"), "")
        ' ''            ret.Estado = Catalogos.FabricaCatalogos.ObtenEstado(IfNull(prmrow("nEstado"), 0))
        ' ''            ret.Municipio = Catalogos.FabricaCatalogos.ObtenMunicipio(IfNull(prmrow("nMunicipio"), 0))
        ' ''            ret.Ciudad = Catalogos.FabricaCatalogos.ObtenCiudad(IfNull(prmrow("nCiudad"), 0))
        ' ''            ret.Colonia = Catalogos.FabricaCatalogos.ObtenColonia(IfNull(prmrow("nColonia"), 0))
        ' ''            ret.Domicilio = IfNull(prmrow("cDomicilio"), "")
        ' ''            ret.CorreoElectronico = IfNull(prmrow("cCorreoElectronico"), "")
        ' ''            ret.Contacto = IfNull(prmrow("cContacto"), "")
        ' ''            ret.RFCSecundario = IfNull(prmrow("cRFCSecundario"), "")
        ' ''            ret.TelefonoUno = IfNull(prmrow("cTelefonoUno"), "")
        ' ''            ret.TelefonoDos = IfNull(prmrow("cTelefonoDos"), "")
        ' ''            ret.TelefonoFax = IfNull(prmrow("cTelefonoFax"), "")
        ' ''            ret.ClienteEspecial = IfNull(prmrow("bClienteEspecial"), False)
        ' ''            ret.LLenaDatosRegistroComun(prmrow)
        ' ''            ret.Activo = prmrow("bactivo")
        ' ''            Return ret
        ' ''        End Function
        ' ''        Public Shared Function ObtenCliente(ByRef prmrow As DataRow, ByVal prmCliente As Distribucion.ClsClientes) As DataRow
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            If prmCliente Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If

        ' ''            prmrow("nCliente") = prmCliente.Folio
        ' ''            prmrow("cCurp") = prmCliente.Curp
        ' ''            prmrow("cObservaciones") = prmCliente.Observaciones
        ' ''            prmrow("bExcentoDomicilio") = prmCliente.ExcentoDomicilio
        ' ''            prmrow("nPlaza") = prmCliente.Plaza.Folio
        ' ''            prmrow("cNombreFiscal") = prmCliente.NombreFiscal
        ' ''            prmrow("cNombreComercial") = prmCliente.NombreComercial
        ' ''            prmrow("cNombreCorto") = prmCliente.NombreCorto
        ' ''            prmrow("cRFC") = prmCliente.RFC
        ' ''            prmrow("cPais") = prmCliente.Pais
        ' ''            prmrow("nEstado") = prmCliente.Estado.Folio
        ' ''            prmrow("nMunicipio") = prmCliente.Municipio.Folio
        ' ''            prmrow("nCiudad") = prmCliente.Ciudad.Folio
        ' ''            prmrow("nColonia") = prmCliente.Colonia.Folio
        ' ''            prmrow("cDomicilio") = prmCliente.Domicilio
        ' ''            prmrow("cCorreoElectronico") = prmCliente.CorreoElectronico
        ' ''            prmrow("cContacto") = prmCliente.Contacto
        ' ''            prmrow("cRFCSecundario") = prmCliente.RFCSecundario
        ' ''            prmrow("cTelefonoUno") = prmCliente.TelefonoUno
        ' ''            prmrow("cTelefonoDos") = prmCliente.TelefonoDos
        ' ''            prmrow("cTelefonoFax") = prmCliente.TelefonoFax
        ' ''            prmrow("bClienteEspecial") = prmCliente.ClienteEspecial
        ' ''            prmrow("bactivo") = prmCliente.Activo
        ' ''            prmCliente.LLenaDatosRegistroComun(prmrow)

        ' ''            Return prmrow
        ' ''        End Function

        ' ''        Public Shared Function ObtenProducto_ControlCapturaProductos(ByVal prmProducto As String, Optional ByVal prmFiltro As String = "", Optional ByVal prmOrigenDatos As String = "CTL_Productos") As ClsProducto
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim ds As New DataSet
        ' ''            Dim param(2) As Object
        ' ''            param(0) = prmOrigenDatos.Trim
        ' ''            param(1) = prmProducto
        ' ''            param(2) = prmFiltro.Trim
        ' ''            DAO.RegresaConsultaSQL("SP_PRO_ConsultaProducto", ds, param)
        ' ''            If ds Is Nothing Then Return Nothing
        ' ''            For Each dt As DataTable In ds.Tables
        ' ''                If dt.Rows.Count > 0 Then
        ' ''                    Return ObtenProducto(dt.Rows(0))
        ' ''                End If
        ' ''            Next
        ' ''            Return Nothing
        ' ''        End Function
        ' ''        Public Shared Function ObtenProducto(ByVal prmProducto As Integer) As ClsProducto
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim dtProducto As New DataTable
        ' ''            DAO.RegresaConsultaSQL("Select * FROM CTL_Productos (NOLOCK) WHERE nProducto = " & prmProducto, dtProducto)
        ' ''            If dtProducto.Rows.Count = 0 Then
        ' ''                Return Nothing
        ' ''            Else
        ' ''                Return ObtenProducto(dtProducto.Rows(0))
        ' ''            End If
        ' ''        End Function
        ' ''        Public Shared Function ObtenProductoRebanado(ByVal prmProducto As Integer) As ClsProducto
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim dtProducto As New DataTable
        ' ''            Dim vcSQL As String = "Select REB.* FROM CTL_Productos P (NOLOCK) " & vbCr
        ' ''            vcSQL &= "INNER JOIN CTL_Productos REB (NOLOCK) ON P.nProductoRebanado = REB.nProducto " & vbCr
        ' ''            vcSQL &= "WHERE P.nProducto = " & prmProducto
        ' ''            DAO.RegresaConsultaSQL(vcSQL, dtProducto)
        ' ''            If dtProducto.Rows.Count = 0 Then
        ' ''                Return Nothing
        ' ''            Else
        ' ''                Return ObtenProducto(dtProducto.Rows(0))
        ' ''            End If
        ' ''        End Function

        ' ''        Public Shared Function ObtenProducto(ByVal prmProducto As String) As ClsProducto
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim dtProducto As New DataTable

        ' ''            DAO.RegresaConsultaSQL("Select * FROM CTL_Productos (NOLOCK) WHERE cCodigo = '" & prmProducto & "'", dtProducto)
        ' ''            If dtProducto.Rows.Count = 0 Then
        ' ''                Return Nothing
        ' ''            Else
        ' ''                Return ObtenProducto(dtProducto.Rows(0))
        ' ''            End If
        ' ''        End Function

        ' ''        Public Shared Function ObtenProducto(ByVal prmrow As DataRow) As ClsProducto
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            Dim ret As New ClsProducto(prmrow("nProducto"))
        ' ''            ret.Codigo = prmrow("cCodigo")
        ' ''            ret.Descripcion = prmrow("cDescripcion")
        ' ''            ret.NombreCorto = prmrow("cNombreCorto")
        ' ''            ret.Identificador = prmrow("cIdentificador")
        ' ''            ret.CodigoCorto = IfNull(prmrow("cCodigoCorto"), "")
        ' ''            ret.Linea = Catalogos.FabricaCatalogos.ObtenLineaProducto(prmrow("nLinea"))
        ' ''            ret.TipoArticulo = Catalogos.FabricaCatalogos.ObtenTipoProducto(prmrow("nTipoProducto"))
        ' ''            ret.Unidad = prmrow("nUnidad")
        ' ''            ret.Inventariar = prmrow("bInventariar")
        ' ''            ret.Empacable = IfNull(prmrow("bEmpacable"), False)
        ' ''            ret.IncluirInventarioDelDia = IfNull(prmrow("bIncluirInventarioDia"), False)
        ' ''            ret.SeRebana = IfNull(prmrow("bSeRebana"), False)
        ' ''            ret.Impuesto = Dominio.Comun.ClsTools.IfNull(prmrow("nImpuesto"), 0)
        ' ''            ret.Cajetes = prmrow("nCajetes")
        ' ''            ret.Moldes = prmrow("nMoldes")
        ' ''            ret.ManejaColor = ClsTools.IfNull(prmrow("bManejaColor"), False)
        ' ''            ret.Secuenciado = ClsTools.IfNull(prmrow("bEsSecuenciado"), 0)
        ' ''            ret.Activo = prmrow("bactivo")
        ' ''            ret.Grupo = IfNull(prmrow("nGrupo"), 0)
        ' ''            ret.EsProductoRebanado = IfNull(prmrow("bProductoRebanado"), False)
        ' ''            ret.Tamaño = IfNull(prmrow("nTamanio"), 0)
        ' ''            ret.CantidadRebanadas = IfNull(prmrow("nCantidadRebanadas"), 0)
        ' ''            If prmrow("nProductoRebanado") IsNot DBNull.Value Then
        ' ''                ret.ProductoRebanado = Catalogos.FabricaCatalogos.ObtenProducto(prmrow("nProductoRebanado"))
        ' ''            End If
        ' ''            ret.UnidadCosteo = IfNull(prmrow("bUnidadCosteo"), False)

        ' ''            ret.PorcentajeVuelta1 = IfNull(prmrow("nPorcentajeVuelta1"), 0)
        ' ''            ret.PorcentajeVuelta2 = IfNull(prmrow("nPorcentajeVuelta2"), 0)
        ' ''            ret.PorcentajeVuelta3 = IfNull(prmrow("nPorcentajeVuelta3"), 0)
        ' ''            ret.PorcentajeVuelta4 = IfNull(prmrow("nPorcentajeVuelta4"), 0)
        ' ''            ret.EsProductoFinal = IfNull(prmrow("bProductoFinal"), False)
        ' ''            ret.TipoVenta = IfNull(prmrow("cTipoVenta"), "")
        ' ''            ret.PermiteCambioPrecio = IfNull(prmrow("bModificaPrecio"), False)
        ' ''            ret.ModificaPrecioTipoVenta = IfNull(prmrow("cTipoVentaCambioPrecio"), "")

        ' ''            Return ret
        ' ''        End Function

        ' ''        Public Shared Function ObtenProducto(ByRef prmrow As DataRow, ByVal prmProducto As ClsProducto) As DataRow
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            If prmProducto Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If

        ' ''            prmrow("nProducto") = prmProducto.Folio
        ' ''            prmrow("cCodigo") = prmProducto.Codigo
        ' ''            prmrow("bIncluirInventarioDia") = prmProducto.IncluirInventarioDelDia
        ' ''            prmrow("cCodigoCorto") = prmProducto.CodigoCorto
        ' ''            prmrow("cDescripcion") = prmProducto.Descripcion
        ' ''            prmrow("cNombreCorto") = prmProducto.NombreCorto
        ' ''            prmrow("cIdentificador") = prmProducto.Identificador
        ' ''            prmrow("nLinea") = prmProducto.Linea.Folio
        ' ''            prmrow("nTipoProducto") = prmProducto.TipoArticulo.Folio
        ' ''            prmrow("nUnidad") = prmProducto.Unidad
        ' ''            prmrow("bInventariar") = prmProducto.Inventariar
        ' ''            prmrow("bEmpacable") = prmProducto.Empacable
        ' ''            prmrow("nImpuesto") = prmProducto.Impuesto
        ' ''            prmrow("bManejaColor") = prmProducto.ManejaColor
        ' ''            prmrow("bEsSecuenciado") = prmProducto.Secuenciado
        ' ''            prmrow("nCajetes") = prmProducto.Cajetes
        ' ''            prmrow("nMoldes") = prmProducto.Moldes
        ' ''            prmrow("bactivo") = prmProducto.Activo
        ' ''            prmrow("nGrupo") = prmProducto.Grupo
        ' ''            prmrow("nTamanio") = prmProducto.Tamaño
        ' ''            prmrow("bSeRebana") = prmProducto.SeRebana
        ' ''            prmrow("bProductoRebanado") = prmProducto.EsProductoRebanado
        ' ''            If Not prmProducto.ProductoRebanado Is Nothing Then
        ' ''                prmrow("nProductoRebanado") = prmProducto.ProductoRebanado.Folio
        ' ''            Else
        ' ''                prmrow("nProductoRebanado") = DBNull.Value
        ' ''            End If
        ' ''            prmrow("nCantidadRebanadas") = prmProducto.CantidadRebanadas
        ' ''            prmrow("bUnidadCosteo") = prmProducto.UnidadCosteo
        ' ''            prmProducto.LLenaDatosRegistroComun(prmrow)
        ' ''            If prmProducto.PorcentajeVuelta1 = 0 Then
        ' ''                prmrow("nPorcentajeVuelta1") = DBNull.Value
        ' ''            Else
        ' ''                prmrow("nPorcentajeVuelta1") = prmProducto.PorcentajeVuelta1
        ' ''            End If
        ' ''            If prmProducto.PorcentajeVuelta2 = 0 Then
        ' ''                prmrow("nPorcentajeVuelta2") = DBNull.Value
        ' ''            Else
        ' ''                prmrow("nPorcentajeVuelta2") = prmProducto.PorcentajeVuelta2
        ' ''            End If
        ' ''            If prmProducto.PorcentajeVuelta3 = 0 Then
        ' ''                prmrow("nPorcentajeVuelta3") = DBNull.Value
        ' ''            Else
        ' ''                prmrow("nPorcentajeVuelta3") = prmProducto.PorcentajeVuelta3
        ' ''            End If
        ' ''            If prmProducto.PorcentajeVuelta4 = 0 Then
        ' ''                prmrow("nPorcentajeVuelta4") = DBNull.Value
        ' ''            Else
        ' ''                prmrow("nPorcentajeVuelta4") = prmProducto.PorcentajeVuelta4
        ' ''            End If
        ' ''            prmrow("bProductoFinal") = prmProducto.EsProductoFinal
        ' ''            prmrow("cTipoVenta") = prmProducto.TipoVenta.Trim
        ' ''            prmrow("bModificaPrecio") = prmProducto.PermiteCambioPrecio
        ' ''            prmrow("cTipoVentaCambioPrecio") = prmProducto.ModificaPrecioTipoVenta.Trim

        ' ''            Return prmrow
        ' ''        End Function

        ' ''        Public Shared Function ObtenProductoCodigoBarra(ByVal prmID As Long) As ClsProductosCodigosBarra
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim dtCodigoBarra As New DataTable
        ' ''            DAO.RegresaConsultaSQL("SELECT * FROM CTL_ProductosCodigosBarra (NOLOCK) WHERE nCodigoBarra = " & prmID, dtCodigoBarra)
        ' ''            If dtCodigoBarra.Rows.Count = 0 Then
        ' ''                Return Nothing
        ' ''                Else
        ' ''                Return ObtenProductoCodigoBarra(dtCodigoBarra.Rows(0))
        ' ''            End If
        ' ''        End Function

        ' ''        Public Shared Function ObtenProductoCodigoBarra(ByVal prmrow As DataRow) As ClsProductosCodigosBarra
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            Dim ret As New ClsProductosCodigosBarra(prmrow("nCOdigoBarra"), prmrow("nOrigen"))
        ' ''            ret.Almacen = Catalogos.FabricaCatalogos.ObtenAlmacen(prmrow("nAlmacen"))
        ' ''            ret.Producto = Catalogos.FabricaCatalogos.ObtenProducto(prmrow("nProducto"))
        ' ''            ret.Codigo = prmrow("nColor")
        ' ''            ret.CodigoBarra_2 = prmrow("nCodigoBarra2")
        ' ''            ret.CodigoBarra_C = ClsTools.IfNull(prmrow("cCodigoBarra"), "")
        ' ''            ret.Activo = prmrow("bactivo")
        ' ''            ret.Programacion = ClsTools.IfNull(prmrow("nProgramacion"), 0)
        ' ''            ret.Estatus = prmrow("nEstatus")
        ' ''            ret.CargaDatosRegistro(prmrow)
        ' ''            Return ret
        ' ''        End Function

        ' ''        Public Shared Function ObtenProductoCodigoBarra(ByRef prmrow As DataRow, ByVal prmCodigoBarra As ClsProductosCodigosBarra) As DataRow
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            If prmCodigoBarra Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            prmrow("nCodigoBarra") = prmCodigoBarra.ID
        ' ''            prmrow("nAlmacen") = prmCodigoBarra.Almacen.Folio
        ' ''            prmrow("nProducto") = prmCodigoBarra.Producto.Folio
        ' ''            prmrow("nColor") = prmCodigoBarra.Codigo
        ' ''            prmrow("cCodigoBarra") = prmCodigoBarra.CodigoBarra_C
        ' ''            prmrow("bActivo") = prmCodigoBarra.Activo
        ' ''            prmrow("nProgramacion") = prmCodigoBarra.Programacion
        ' ''            prmrow("nOrigen") = prmCodigoBarra.OrigenEtiqueta
        ' ''            prmrow("nEstatus") = prmCodigoBarra.Estatus
        ' ''            prmrow("nCodigoBarra2") = prmCodigoBarra.CodigoBarra_2
        ' ''            prmCodigoBarra.LLenaDatosRegistroComun(prmrow)
        ' ''            Return prmrow
        ' ''        End Function

        ' ''        Public Shared Function ObtenArticulo(ByVal prmArticulo As Integer) As ClsArticulo
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim dtArticulo As New DataTable
        ' ''            DAO.RegresaConsultaSQL("select * from ctl_articulos (NOLOCK) where narticulo='" & prmArticulo & "'", dtArticulo)
        ' ''            If dtArticulo.Rows.Count = 0 Then
        ' ''                Return Nothing
        ' ''            Else
        ' ''                Return ObtenArticulo(dtArticulo.Rows(0))
        ' ''            End If
        ' ''        End Function

        ' ''        Public Shared Function ObtenArticulo(ByVal prmArticulo As String) As ClsArticulo
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim dtArticulo As New DataTable
        ' ''            DAO.RegresaConsultaSQL("select * from ctl_articulos (NOLOCK) where ccodigo='" & prmArticulo & "'", dtArticulo)
        ' ''            If dtArticulo.Rows.Count = 0 Then
        ' ''                Return Nothing
        ' ''            Else
        ' ''                Return ObtenArticulo(dtArticulo.Rows(0))
        ' ''            End If
        ' ''        End Function

        ' ''        Public Shared Function ObtenArticulo(ByVal prmrow As DataRow) As ClsArticulo
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If

        ' ''            Dim ret As New ClsArticulo(prmrow("narticulo"))
        ' ''            ret.Codigo = prmrow("cCodigo")
        ' ''            ret.Descripcion = prmrow("cDescripcion")
        ' ''            ret.NombreCorto = prmrow("cNombreCorto")
        ' ''            ret.Linea = ObtenLinea(prmrow("nlinea"))
        ' ''            ret.Marca = ObtenMarca(prmrow("nmarca"))
        ' ''            ret.TipoArticulo = ObtenTipoArticulo(prmrow("ntipoarticulo"))
        ' ''            ret.Unidad = ObtenUnidad(prmrow("nunidad"))
        ' ''            ret.CambiaMarca = prmrow("bCambiaMarca")
        ' ''            ret.Inventariar = prmrow("bInventariar")
        ' ''            ret.Drenado = prmrow("bDrenado")
        ' ''            ret.Tara = prmrow("bTara")
        ' ''            ret.Activo = prmrow("bactivo")
        ' ''            ret.EsMuestra = prmrow("bEsMuestra")
        ' ''            If prmrow("nOrden") Is DBNull.Value Then
        ' ''                ret.Orden = 0
        ' ''            Else
        ' ''                ret.Orden = prmrow("nOrden")
        ' ''            End If

        ' ''            Return ret
        ' ''        End Function

        ' ''        Public Shared Function ObtenArticulo(ByRef prmrow As DataRow, ByVal prmArticulo As ClsArticulo) As DataRow
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            If prmArticulo Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If

        ' ''            prmrow("narticulo") = prmArticulo.Folio
        ' ''            prmrow("cCodigo") = prmArticulo.Codigo
        ' ''            prmrow("cDescripcion") = prmArticulo.Descripcion
        ' ''            prmrow("cNombreCorto") = prmArticulo.NombreCorto
        ' ''            prmrow("nlinea") = prmArticulo.Linea.Folio
        ' ''            prmrow("nmarca") = prmArticulo.Marca.Folio
        ' ''            prmrow("ntipoarticulo") = prmArticulo.TipoArticulo.Folio
        ' ''            prmrow("nunidad") = prmArticulo.Unidad.Folio
        ' ''            prmrow("bCambiaMarca") = prmArticulo.CambiaMarca
        ' ''            prmrow("bInventariar") = prmArticulo.Inventariar
        ' ''            prmrow("bDrenado") = prmArticulo.Drenado
        ' ''            prmrow("bTara") = prmArticulo.Tara
        ' ''            prmrow("bactivo") = prmArticulo.Activo
        ' ''            prmrow("bEsMuestra") = prmArticulo.EsMuestra
        ' ''            prmrow("nOrden") = prmArticulo.Orden
        ' ''            prmArticulo.LLenaDatosRegistroComun(prmrow)

        ' ''            Return prmrow
        ' ''        End Function

        ' ''        Public Shared Function ExisteMonedaBase(ByVal prmMoneda As Integer) As Boolean
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Return DAO.ExistenDatosEnConsultaSQL("Select * from ctl_monedas where nmoneda <>" & prmMoneda & " and bbase=1")
        ' ''        End Function

        ' ''        Public Shared Function RefreshContainers(ByVal prmProveedor As Proveedores.ClsProveedor) As DataSet
        ' ''            Dim vSql As String
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim vTablas As New DataSet

        ' ''            vSql = "SELECT * FROM CTL_ProveedoresArticulos (NOLOCK)" & vbCr
        ' ''            vSql &= "WHERE nProveedor = " & prmProveedor.Folio.ToString & vbCr

        ' ''            vSql &= "SELECT * FROM CTL_ProveedoresCuentasBancarias (NOLOCK)" & vbCr
        ' ''            vSql &= "WHERE nProveedor = " & prmProveedor.Folio.ToString & vbCr

        ' ''            vSql &= "SELECT * FROM CTL_ProveedoresProntosPagos (NOLOCK)" & vbCr
        ' ''            vSql &= "WHERE nProveedor = " & prmProveedor.Folio.ToString & vbCr

        ' ''            vSql &= "SELECT * FROM CTL_ProveedoresContactos (NOLOCK)" & vbCr
        ' ''            vSql &= "WHERE nProveedor = " & prmProveedor.Folio.ToString & vbCr

        ' ''            vSql &= "SELECT * FROM CTL_ProveedoresBitacoraObservaciones (NOLOCK)" & vbCr
        ' ''            vSql &= "WHERE nProveedor = " & prmProveedor.Folio.ToString & vbCr

        ' ''            vSql &= "SELECT * FROM CTL_ProveedoresClasificadores (NOLOCK)" & vbCr
        ' ''            vSql &= "WHERE nProveedor = " & prmProveedor.Folio.ToString & vbCr

        ' ''            vSql &= "SELECT * FROM COM_ProveedoresNegociaciones (NOLOCK)" & vbCr
        ' ''            vSql &= "WHERE nProveedor = " & prmProveedor.Folio.ToString & vbCr

        ' ''            vSql &= "SELECT * FROM COM_ProveedoresNegociacionesDetalle (NOLOCK)" & vbCr
        ' ''            vSql &= "WHERE nNegociacion in (SELECT Distinct nNegociacion FROM COM_ProveedoresNegociaciones (NOLOCK) WHERE nProveedor = " & prmProveedor.Folio.ToString & ")" & vbCr

        ' ''            'crear  Store Procedure para obten Masivo
        ' ''            DAO.RegresaConsultaSQL(vSql, vTablas)

        ' ''            Return vTablas
        ' ''        End Function

        ' ''        Public Shared Function Refresh(ByVal prmProveedorArticulos As Proveedores.ClsContieneProveedorArticulos, ByVal prmProveedor As Integer) As DataTable
        ' ''            Dim vSql As String
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim vTabla As New DataTable

        ' ''            vSql = "SELECT * FROM CTL_ProveedoresArticulos (NOLOCK)" & vbCr
        ' ''            vSql &= "WHERE nProveedor = " & prmProveedor.ToString & vbCr

        ' ''            DAO.RegresaConsultaSQL(vSql, vTabla)

        ' ''            Return vTabla
        ' ''        End Function

        ' ''        Public Shared Function Refresh(ByVal prmProveedorObservaciones As Proveedores.ClsContieneProveedorObservaciones, ByVal prmProveedor As Proveedores.ClsProveedor) As DataTable
        ' ''            Dim vSql As String
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim vTabla As New DataTable
        ' ''            Dim dFechaInicio As Date
        ' ''            Dim dFechaFin As Date

        ' ''            If prmProveedor.FechaFinObservaciones = Nothing Then
        ' ''                dFechaInicio = ClsTools.FechaDelSistema
        ' ''                dFechaFin = dFechaInicio
        ' ''            Else
        ' ''                dFechaInicio = prmProveedor.FechaInicioObservaciones
        ' ''                dFechaFin = prmProveedor.FechaFinObservaciones
        ' ''            End If

        ' ''            'Realizamos Consulta de las observaciones con proveedores, 
        ' ''            'tanto de la bitacora de observaciones como de las obs de movimientos de inventario a nivel articulo
        ' ''            '************************************
        ' ''            vSql = "SELECT E.dFechaDocumento as dFecha,E.cDocumento as nFolio,D.cObservacionProveedor as cObservacion,D.nArticulo,A.cNombreCorto,D.nPresentacion,P.cDescripcion,D.nCantidadRecibida  as nCantidad " & vbCr
        ' ''            vSql &= "FROM COM_Compras_Gastos E(NOLOCK) " & vbCr
        ' ''            vSql &= "INNER JOIN COM_Compras_GastosDetalle D(NOLOCK) ON (E.nMovimientoCompra=D.nMovimientoCompra)" & vbCr
        ' ''            vSql &= "INNER JOIN CTL_ArticulosPresentaciones P(NOLOCK) ON (D.nArticulo = P.nArticulo AND P.nPresentacion=D.nPresentacion)" & vbCr
        ' ''            vSql &= "INNER JOIN CTL_Articulos A(NOLOCK) ON (A.nArticulo=D.nArticulo)" & vbCr
        ' ''            vSql &= "WHERE D.cObservacionProveedor is not null and ltrim(D.cObservacionProveedor)<>'' and e.nProveedor =" & prmProveedor.Folio.ToString & vbCr
        ' ''            vSql &= "AND dbo.ADSUM_NumeroJuliano(E.dFechaDocumento) BETWEEN " & ClsTools.NumeroJuliano(dFechaInicio) & " AND " & ClsTools.NumeroJuliano(dFechaFin) & vbCrLf
        ' ''            vSql &= "UNION" & vbCr
        ' ''            vSql &= "SELECT Convert(varchar(10),dFecha,121) as dFecha,'' AS nFolio,cObservacion as cObservacion,'' AS nArticulo,'' AS cNombreCorto,'' AS nPresentacion,'' AS cDescripcion,0 AS nCantidad  " & vbCr
        ' ''            vSql &= "FROM CTL_ProveedoresObservaciones BO(NOLOCK) WHERE BO.nProveedor=" & prmProveedor.Folio.ToString & vbCr
        ' ''            vSql &= "AND dbo.ADSUM_NumeroJuliano(BO.dFecha) BETWEEN " & ClsTools.NumeroJuliano(dFechaInicio) & " AND " & ClsTools.NumeroJuliano(dFechaFin)

        ' ''            DAO.RegresaConsultaSQL(vSql, vTabla)

        ' ''            Return vTabla
        ' ''        End Function

        ' ''        Public Shared Function Refresh(ByVal prmProveedorCuentasBancarias As Proveedores.ClsContieneProveedorCuentasBancarias, ByVal prmProveedor As Integer) As DataTable
        ' ''            Dim vSql As String
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim vTabla As New DataTable

        ' ''            vSql = "SELECT p.*,b.cDescripcion AS cBanco FROM CTL_ProveedoresCuentasBancarias p(NOLOCK) inner join CTL_Bancos b ON p.nBanco = b.nBanco" & vbCr
        ' ''            DAO.RegresaEsquemaDeDatos(vSql & " where 1=0", vTabla)
        ' ''            vSql &= "WHERE p.nProveedor = " & prmProveedor.ToString & vbCr
        ' ''            DAO.RegresaConsultaSQL(vSql, vTabla)

        ' ''            Return vTabla
        ' ''        End Function

        ' ''        Public Shared Function Refresh(ByVal prmProveedorProntoPago As Proveedores.ClsContieneProveedorProntosPagos, ByVal prmProveedor As Integer) As DataTable
        ' ''            Dim vSql As String
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim vTabla As New DataTable

        ' ''            vSql = "SELECT A.*,b.ccontacto as cContacto FROM CTL_ProveedoresProntosPagos A (NOLOCK) inner join CTL_ProveedoresContactos(nolock) B on a.ncontacto=b.nproveedorcontacto and a.nproveedor=b.nproveedor " & vbCr
        ' ''            vSql &= "WHERE A.nProveedor = " & prmProveedor.ToString & vbCr
        ' ''            DAO.RegresaEsquemaDeDatos(vSql, vTabla)
        ' ''            DAO.RegresaConsultaSQL(vSql, vTabla)

        ' ''            Return vTabla
        ' ''        End Function

        ' ''        Public Shared Function Refresh(ByVal prmProveedorProveedoresContactos As Proveedores.ClsContieneProveedorContactos, ByVal prmProveedor As Integer) As DataTable
        ' ''            Dim vSql As String
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim vTabla As New DataTable

        ' ''            vSql = "SELECT * FROM CTL_ProveedoresContactos (NOLOCK)" & vbCr
        ' ''            vSql &= "WHERE nProveedor = " & prmProveedor.ToString & vbCr
        ' ''            DAO.RegresaEsquemaDeDatos(vSql, vTabla)

        ' ''            DAO.RegresaConsultaSQL(vSql, vTabla)

        ' ''            Return vTabla
        ' ''        End Function

        ' ''        Public Shared Function Refresh(ByVal prmProveedorProveedoresCuentasContables As Proveedores.ClsContieneProveedorCuentasContables, ByVal prmProveedor As Integer) As DataTable
        ' ''            Dim vSql As String
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim vTabla As New DataTable

        ' ''            vSql = "SELECT * FROM CTL_ProveedoresCuentasContables (NOLOCK)" & vbCr
        ' ''            vSql &= "WHERE nProveedor = " & prmProveedor.ToString & " And bActivo = 1 " & vbCr
        ' ''            DAO.RegresaEsquemaDeDatos(vSql, vTabla)

        ' ''            DAO.RegresaConsultaSQL(vSql, vTabla)

        ' ''            Return vTabla
        ' ''        End Function

        ' ''        Public Shared Function Refresh(ByVal prmProveedorProveedoresClasificadores As Proveedores.ClsContieneProveedorClasificadores, ByVal prmProveedor As Integer) As DataTable
        ' ''            Dim vSql As String
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim vTabla As New DataTable

        ' ''            vSql = "SELECT * FROM CTL_ProveedoresClasificadores (NOLOCK)" & vbCr
        ' ''            vSql &= "WHERE nProveedor = " & prmProveedor.ToString & vbCr

        ' ''            DAO.RegresaConsultaSQL(vSql, vTabla)

        ' ''            Return vTabla
        ' ''        End Function

        ' ''        Public Shared Function Refresh(ByVal prmProveedorProveedoresNegociaciones As Proveedores.ClsContieneProveedorNegociaciones, ByVal prmProveedor As Integer) As DataTable
        ' ''            Dim vSql As String
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim vTabla As New DataTable

        ' ''            vSql = "SELECT * FROM COM_ProveedoresNegociaciones (NOLOCK)" & vbCr
        ' ''            vSql &= "WHERE nProveedor = " & prmProveedor.ToString & vbCr

        ' ''            DAO.RegresaConsultaSQL(vSql, vTabla)

        ' ''            Return vTabla
        ' ''        End Function

        ' ''        Public Shared Function Refresh(ByVal prmProveedorProveedoresNegociacionesDetalle As Proveedores.ClsProveedorNegociacionesDetalle) As DataTable
        ' ''            Dim vSql As String
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim vTabla As New DataTable

        ' ''            vSql = "SELECT * FROM COM_ProveedoresNegociacionesDetalle (NOLOCK)" & vbCr
        ' ''            vSql &= "WHERE nNegociacion= " & prmProveedorProveedoresNegociacionesDetalle.Folio.ToString & vbCr

        ' ''            DAO.RegresaConsultaSQL(vSql, vTabla)

        ' ''            Return vTabla
        ' ''        End Function

        ' ''#Region "Proveedores"

        ' ''#End Region

        ' ''        Public Shared Function ObtenProveedor(ByVal prmnProveedor As Integer, ByVal prmnContacto As Integer) As Dominio.Catalogos.Proveedores.ClsProveedorContactos
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim dt As New DataTable
        ' ''            Dim vlsql As String
        ' ''            vlsql = "select * from CTL_ProveedoresContactos(NOLOCK)" & vbCr
        ' ''            vlsql &= " where nProveedor = " & prmnProveedor & vbCr
        ' ''            vlsql &= " and nProveedorContacto = " & prmnContacto & vbCr

        ' ''            DAO.RegresaConsultaSQL(vlsql, dt)
        ' ''            If dt.Rows.Count = 0 Then
        ' ''                Return Nothing
        ' ''            Else
        ' ''                Return ObtenProveedorContacto(dt.Rows(0))
        ' ''            End If
        ' ''        End Function

        ' ''        Public Shared Function ObtenProveedorEnMemoria(ByVal prmnProveedor As Integer, ByVal prmDataSet As DataSet) As Dominio.Catalogos.Proveedores.ClsProveedorContactos
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim dt As New DataTable
        ' ''            Dim vlsql As String

        ' ''            'vlsql = "select * from CTL_ProveedoresContactos(NOLOCK)" & vbCr
        ' ''            'vlsql &= " where nProveedor = " & prmnProveedor & vbCr
        ' ''            'vlsql &= " and nProveedorContacto = " & prmnContacto & vbCr

        ' ''            'DAO.RegresaConsultaSQL(vlsql, dt)
        ' ''            'If dt.Rows.Count = 0 Then
        ' ''            '    Return Nothing
        ' ''            'Else
        ' ''            '    Return ObtenProveedorContacto(dt.Rows(0))
        ' ''            'End If
        ' ''        End Function



        ' ''        Public Shared Function ObtenProveedorContacto(ByRef prmrow As DataRow, ByVal prmProveedorContacto As Dominio.Catalogos.Proveedores.ClsProveedorContactos) As DataRow
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            If prmProveedorContacto Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If


        ' ''            prmrow("nProveedorContacto") = prmProveedorContacto.Folio
        ' ''            prmrow("nProveedor") = prmProveedorContacto.Proveedor
        ' ''            'prmrow("cDescripcion") = prmProveedorContacto.Descripcion
        ' ''            prmrow("cContacto") = prmProveedorContacto.Contacto
        ' ''            prmrow("cPuesto") = prmProveedorContacto.Puesto
        ' ''            prmrow("cTelefonoCelular") = prmProveedorContacto.TelefonoCelular
        ' ''            prmrow("cTelefonoOficina") = prmProveedorContacto.TelefonoOficina
        ' ''            prmrow("cTelefonoFax") = prmProveedorContacto.TelefonoFax
        ' ''            prmrow("cCorreoElectronico") = prmProveedorContacto.CorreoElectronico
        ' ''            prmrow("bActivo") = prmProveedorContacto.Activo
        ' ''            Return prmrow
        ' ''        End Function


        ' ''        Public Shared Function ObtenProveedorContacto(ByVal prmrow As DataRow) As Dominio.Catalogos.Proveedores.ClsProveedorContactos
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If

        ' ''            Dim ret As New Dominio.Catalogos.Proveedores.ClsProveedorContactos()

        ' ''            ret.Folio = Dominio.Comun.ClsTools.IfNull(prmrow("nProveedorContacto"), 0)
        ' ''            ret.Proveedor = prmrow("nProveedor")
        ' ''            'ret.Descripcion = prmrow("cDescripcion")
        ' ''            ret.Contacto = prmrow("cContacto")
        ' ''            ret.Puesto = prmrow("cPuesto")
        ' ''            If prmrow("cTelefonoCelular") Is DBNull.Value Then
        ' ''                ret.TelefonoCelular = ""
        ' ''            Else
        ' ''                ret.TelefonoCelular = prmrow("cTelefonoCelular")
        ' ''            End If
        ' ''            If prmrow("cTelefonoOficina") Is DBNull.Value Then
        ' ''                ret.TelefonoOficina = ""
        ' ''            Else
        ' ''                ret.TelefonoOficina = prmrow("cTelefonoOficina")
        ' ''            End If
        ' ''            If prmrow("cTelefonoFax") Is DBNull.Value Then
        ' ''                ret.TelefonoFax = ""
        ' ''            Else
        ' ''                ret.TelefonoFax = prmrow("cTelefonoFax")
        ' ''            End If
        ' ''            If prmrow("cCorreoElectronico") Is DBNull.Value Then
        ' ''                ret.CorreoElectronico = ""
        ' ''            Else
        ' ''                ret.CorreoElectronico = prmrow("cCorreoElectronico")
        ' ''            End If
        ' ''            If prmrow("bActivo") Is DBNull.Value Then
        ' ''                ret.Activo = True
        ' ''            Else
        ' ''                ret.Activo = prmrow("bActivo")
        ' ''            End If
        ' ''            ret.CargaDatosRegistro(prmrow)
        ' ''            Return ret
        ' ''        End Function

        ' ''        Public Shared Function ObtenProveedorCuentaCnt(ByRef prmrow As DataRow, ByVal prmProveedorCuentaCnt As Dominio.Catalogos.Proveedores.ClsProveedorCuentasContables) As DataRow
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            If prmProveedorCuentaCnt Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            prmrow("nProveedorCuentaCnt") = prmProveedorCuentaCnt.Folio
        ' ''            prmrow("nProveedor") = prmProveedorCuentaCnt.Proveedor
        ' ''            prmrow("nPlaza") = prmProveedorCuentaCnt.Plaza.Folio
        ' ''            prmrow("bActivo") = prmProveedorCuentaCnt.Activo
        ' ''            If prmProveedorCuentaCnt.CuentaCnt Is Nothing Then
        ' ''                prmrow("nCuentaCnt") = DBNull.Value
        ' ''            Else
        ' ''                prmrow("nCuentaCnt") = prmProveedorCuentaCnt.CuentaCnt.Folio
        ' ''            End If

        ' ''            Return prmrow
        ' ''        End Function


        ' ''        Public Shared Function ObtenProveedorCuentaCnt(ByVal prmrow As DataRow) As Dominio.Catalogos.Proveedores.ClsProveedorCuentasContables
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If

        ' ''            Dim ret As New Dominio.Catalogos.Proveedores.ClsProveedorCuentasContables()

        ' ''            ret.Folio = Dominio.Comun.ClsTools.IfNull(prmrow("nProveedorCuentaCnt"), 0)
        ' ''            ret.Proveedor = prmrow("nProveedor")
        ' ''            If prmrow("nPlaza") Is DBNull.Value Then
        ' ''                ret.Plaza = Nothing
        ' ''            Else
        ' ''                ret.Plaza = ObtenPlaza(prmrow("nPlaza"))
        ' ''            End If

        ' ''            If prmrow("nCuentaCnt") Is DBNull.Value Then
        ' ''                ret.CuentaCnt = Nothing
        ' ''            Else
        ' ''                ret.CuentaCnt = ObtenCuentaCnt(prmrow("nCuentaCnt"))
        ' ''            End If

        ' ''            If prmrow("bActivo") Is DBNull.Value Then
        ' ''                ret.Activo = False
        ' ''            Else
        ' ''                ret.Activo = prmrow("bActivo")
        ' ''            End If
        ' ''            Return ret
        ' ''        End Function


        ' ''        Public Shared Function ObtenProveedorObservacion(ByRef prmrow As DataRow, ByVal prmObservacion As Object) As DataRow
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            If prmObservacion Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            prmrow("nObservacion") = prmObservacion.Folio
        ' ''            prmrow("nProveedor") = prmObservacion.Proveedor
        ' ''            prmrow("dFecha") = prmObservacion.Fecha
        ' ''            prmrow("cObservacion") = prmObservacion.Observacion
        ' ''            Return prmrow
        ' ''        End Function


        ' ''        Public Shared Function ObtenProveedorContacto(ByVal prmnProveedor As Integer, ByVal prmnContacto As Integer) As Dominio.Catalogos.Proveedores.ClsProveedorContactos
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim ret As Dominio.Catalogos.Proveedores.ClsProveedorContactos
        ' ''            Dim vlsql As String
        ' ''            Dim dtTrabajo As New DataTable

        ' ''            vlsql = "SELECT * FROM CTL_ProveedoresContactos(NOLOCK)" & vbCr
        ' ''            vlsql &= "WHERE nProveedor=" & prmnProveedor & vbCr
        ' ''            vlsql &= "AND nProveedorContacto=" & prmnContacto

        ' ''            DAO.RegresaConsultaSQL(vlsql, dtTrabajo)

        ' ''            For Each vRow As DataRow In dtTrabajo.Rows
        ' ''                ret = New Dominio.Catalogos.Proveedores.ClsProveedorContactos
        ' ''                ret.Folio = vRow("nProveedorContacto")
        ' ''                ret.Proveedor = vRow("nProveedor")
        ' ''                ret.Contacto = vRow("cContacto")
        ' ''                ret.Puesto = vRow("cPuesto")
        ' ''                ret.TelefonoCelular = IIf(vRow("cTelefonoCelular") Is DBNull.Value, "", vRow("cTelefonoCelular"))
        ' ''                ret.TelefonoOficina = IIf(vRow("cTelefonoOficina") Is DBNull.Value, "", vRow("cTelefonoOficina"))
        ' ''                ret.TelefonoFax = IIf(vRow("cTelefonoFax") Is DBNull.Value, "", vRow("cTelefonoFax"))
        ' ''                ret.CorreoElectronico = IIf(vRow("cCorreoElectronico") Is DBNull.Value, "", vRow("cCorreoElectronico"))
        ' ''            Next

        ' ''            Return ret
        ' ''        End Function

        ' ''        Public Shared Function ObtenProveedorProntoPago(ByVal prmrow As DataRow) As Proveedores.ClsProveedorProntosPagos
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            Dim objtrabajo As New Proveedores.ClsProveedorProntosPagos
        ' ''            objtrabajo.Folio = prmrow("nProntoPago")
        ' ''            objtrabajo.Proveedor = prmrow("nProveedor")
        ' ''            objtrabajo.Fecha = prmrow("dFecha")
        ' ''            objtrabajo.Descuento = prmrow("nDescuento")
        ' ''            objtrabajo.Dias = prmrow("nDias")
        ' ''            objtrabajo.Contacto = ObtenProveedorContacto(CInt(prmrow("nproveedor")), CInt(prmrow("nContacto")))
        ' ''            objtrabajo.Activo = prmrow("bactivo")
        ' ''            Return objtrabajo
        ' ''        End Function

        ' ''        Public Shared Function ObtenProveedorProntoPago(ByRef prmrow As DataRow, ByVal prmProveedorProntoPago As Dominio.Catalogos.Proveedores.ClsProveedorProntosPagos) As DataRow
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            If prmProveedorProntoPago Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If

        ' ''            prmrow("nProntoPago") = prmProveedorProntoPago.Folio
        ' ''            prmrow("nProveedor") = prmProveedorProntoPago.Proveedor
        ' ''            prmrow("dFecha") = prmProveedorProntoPago.Fecha
        ' ''            prmrow("nDescuento") = prmProveedorProntoPago.Descuento
        ' ''            prmrow("nDias") = prmProveedorProntoPago.Dias
        ' ''            prmrow("nContacto") = prmProveedorProntoPago.Contacto.Folio
        ' ''            prmrow("bactivo") = prmProveedorProntoPago.Activo


        ' ''            Return prmrow
        ' ''        End Function

        ' ''        Public Shared Function ObtenProveedoresArticulos(ByRef prmrow As DataRow, ByVal prmProveedoresArticulos As Proveedores.ClsProveedorArticulos) As DataRow
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            If prmProveedoresArticulos Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If

        ' ''            prmrow("nProveedor") = prmProveedoresArticulos.Proveedor.Folio
        ' ''            prmrow("nArticulo") = prmProveedoresArticulos.Articulo.Folio
        ' ''            prmrow("nPresentacion") = prmProveedoresArticulos.Presentacion.Folio
        ' ''            prmrow("nMarca") = prmProveedoresArticulos.Marca.Folio
        ' ''            prmrow("cCodigoProveedor") = prmProveedoresArticulos.CodigoProveedor
        ' ''            prmrow("nPrecioLista") = prmProveedoresArticulos.PrecioLista
        ' ''            prmrow("nPlaza") = prmProveedoresArticulos.Plaza.Folio
        ' ''            prmrow("bactivo") = prmProveedoresArticulos.Activo


        ' ''            Return prmrow
        ' ''        End Function

        ' ''        Public Shared Function ObtenProveedoresArticulos(ByVal prmProveedor As Integer) As DataTable
        ' ''            Dim vSql As String
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim vTabla As New DataTable

        ' ''            vSql = "SELECT * FROM CTL_Proveedores(NOLOCK)" & vbCr
        ' ''            vSql &= "WHERE nProveedor = " & prmProveedor.ToString & vbCr
        ' ''            DAO.RegresaConsultaSQL(vSql, vTabla)
        ' ''            Return vTabla

        ' ''        End Function

        ' ''        Public Shared Function ObtenProveedoresArticulos(ByVal prmrow As DataRow) As Proveedores.ClsProveedorArticulos
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If

        ' ''            Dim ret As New Proveedores.ClsProveedorArticulos()

        ' ''            ret.Proveedor = ObtenProveedor(CInt(prmrow("nproveedor")))
        ' ''            ret.Articulo = ObtenArticulo(CInt(prmrow("nArticulo")))
        ' ''            ret.Presentacion = ObtenPresentacion(CInt(prmrow("nArticulo")), CInt(prmrow("nPresentacion")))
        ' ''            ret.Marca = ObtenMarca(CInt(prmrow("nMarca")))
        ' ''            ret.CodigoProveedor = prmrow("cCodigoProveedor")
        ' ''            ret.PrecioLista = ClsTools.IfNull(prmrow("nPrecioLista"), 0)
        ' ''            ret.Plaza = ObtenPlaza(CInt(prmrow("nPlaza")))
        ' ''            ret.Activo = prmrow("bactivo")
        ' ''            Return ret
        ' ''        End Function

        ' ''        Public Shared Function ObtenProveedoresArticulosMasivo(ByVal prmrow As DataRow, ByVal prmTablasMasivo As DataSet) As Proveedores.ClsProveedorArticulos
        ' ''            'Este método realiza la consulta en memoria sobre un dataset que contiene los registros necesarios para instanciar los objetos

        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If

        ' ''            Dim ret As New Proveedores.ClsProveedorArticulos()

        ' ''            'ret.Proveedor = ObtenProveedor(CInt(prmrow("nproveedor")))
        ' ''            'ret.Articulo = ObtenArticuloEnMemoria(CInt(prmrow("nArticulo")))
        ' ''            'ret.Presentacion = ObtenPresentacionEnMemoria(CInt(prmrow("nArticulo")), CInt(prmrow("nPresentacion")))
        ' ''            'ret.Marca = ObtenMarcaEnMemoria(CInt(prmrow("nMarca")))
        ' ''            'ret.CodigoProveedor = prmrow("cCodigoProveedor")
        ' ''            'ret.PrecioLista = ClsTools.IfNull(prmrow("nPrecioLista"), 0)
        ' ''            'ret.Plaza = ObtenPlazaEnMemoria(CInt(prmrow("nPlaza")))
        ' ''            'ret.Activo = prmrow("bactivo")
        ' ''            Return ret
        ' ''        End Function


        ' ''        Public Shared Function ObtenProveedoresCuentaBancarias(ByVal prmrow As DataRow) As Proveedores.ClsProveedorCuentasBancarias
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If

        ' ''            Dim ret As New Proveedores.ClsProveedorCuentasBancarias()
        ' ''            ret.Folio = prmrow("nCuentaBancaria")
        ' ''            ret.Proveedor = prmrow("nproveedor")
        ' ''            ret.Banco = ObtenBanco(CInt(prmrow("nbanco")))
        ' ''            ret.Sucursal = prmrow("csucursal")
        ' ''            ret.Cuenta = prmrow("ccuenta")
        ' ''            ret.CLABE = prmrow("cCLABE")
        ' ''            If Not prmrow("cObservaciones") Is DBNull.Value Then
        ' ''                ret.Observaciones = prmrow("cObservaciones")
        ' ''            Else
        ' ''                ret.Observaciones = ""
        ' ''            End If
        ' ''            ret.Activo = prmrow("bactivo")
        ' ''            Return ret
        ' ''        End Function

        ' ''        'Public Shared Function ObtenProveedoresCuentaBancarias(ByRef prmrow As DataRow, ByVal prmCuentaBan As Proveedores.ClsProveedorCuentasBancarias) As DataRow
        ' ''        '    If prmrow Is Nothing Then
        ' ''        '        Return Nothing
        ' ''        '    End If
        ' ''        '    If prmCuentaBan Is Nothing Then
        ' ''        '        Return Nothing
        ' ''        '    End If

        ' ''        '    prmrow("nObservacion") = ret.Folio
        ' ''        '    prmrow("nproveedor") = ret.Proveedor
        ' ''        '    prmrow("dFecha") = ret.Fecha
        ' ''        '    prmrow("cObservacion") = ret.Observacion
        ' ''        '    Return prmrow
        ' ''        'End Function

        ' ''        Public Shared Function ObtenProveedoresObservaciones(ByVal prmrow As DataRow) As Proveedores.ClsProveedorObservaciones
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If

        ' ''            Dim ret As New Proveedores.ClsProveedorObservaciones()
        ' ''            ret.Folio = prmrow("nObservacion")
        ' ''            ret.Proveedor = prmrow("nproveedor")
        ' ''            ret.Fecha = prmrow("dFecha")
        ' ''            ret.Observacion = prmrow("cObservacion")
        ' ''            Return ret
        ' ''        End Function

        ' ''        Public Shared Function ObtenProveedoresCuentaBancarias(ByRef prmrow As DataRow, ByVal prmCuentaBan As Proveedores.ClsProveedorCuentasBancarias) As DataRow
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            If prmCuentaBan Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            prmrow("nCuentaBancaria") = prmCuentaBan.Folio
        ' ''            prmrow("nproveedor") = prmCuentaBan.Proveedor
        ' ''            prmrow("nbanco") = prmCuentaBan.Banco.Folio
        ' ''            prmrow("csucursal") = prmCuentaBan.Sucursal
        ' ''            prmrow("ccuenta") = prmCuentaBan.Cuenta
        ' ''            prmrow("cObservaciones") = prmCuentaBan.Observaciones
        ' ''            prmrow("bactivo") = prmCuentaBan.Activo

        ' ''            Return prmrow
        ' ''        End Function

        ' ''        Public Shared Function ObtenProveedor(ByRef prmrow As DataRow, ByVal prmobj As Proveedores.ClsProveedor) As DataRow
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            If prmobj Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            prmrow("nProveedor") = prmobj.Folio
        ' ''            prmrow("nTipoProveedor") = prmobj.TipoProveedor
        ' ''            prmrow("cNombreFiscal") = prmobj.NombreFiscal
        ' ''            prmrow("cNombreCorto") = prmobj.NombreCorto
        ' ''            prmrow("cNombreComercial") = prmobj.NombreComercial
        ' ''            prmrow("cRFC") = prmobj.RFC
        ' ''            prmrow("cCalle") = prmobj.Calle
        ' ''            prmrow("cCURP") = prmobj.CURP
        ' ''            prmrow("nColonia") = prmobj.Colonia.Folio
        ' ''            prmrow("cCodigoPostal") = prmobj.CodigoPostal
        ' ''            prmrow("cPais") = prmobj.Pais
        ' ''            prmrow("cNotas") = prmobj.Notas
        ' ''            prmrow("nDiasPago") = prmobj.DiasPago
        ' ''            prmrow("nDiasEntrega") = prmobj.DiasEntrega
        ' ''            prmrow("nFechaAplicacionPago") = prmobj.FechaAplicacionPago
        ' ''            prmrow("nPorcentajeAnticipo") = prmobj.PorcentajeAnticipo
        ' ''            prmrow("nPlazaRegistro") = prmobj.PlazaRegistro.Folio
        ' ''            'Datos Fiscales
        ' ''            prmrow("cFiscalNombre") = prmobj.FiscalNombre
        ' ''            prmrow("cFiscalApellidoPaterno") = prmobj.FiscalApellidoPaterno
        ' ''            prmrow("cFiscalApellidoMaterno") = prmobj.FiscalApellidoMaterno
        ' ''            prmrow("cFiscalEstado") = prmobj.FiscalEstado
        ' ''            prmrow("cFiscalDelegacion") = prmobj.FiscalDelegacion
        ' ''            prmrow("cFiscalLocalidad") = prmobj.FiscalLocalidad
        ' ''            prmrow("cFiscalColonia") = prmobj.FiscalColonia
        ' ''            prmrow("cFiscalCalle") = prmobj.FiscalCalle
        ' ''            prmrow("cFiscalCodigoPostal") = prmobj.FiscalCodigoPostal
        ' ''            prmrow("cFiscalTelefono") = prmobj.FiscalTelefono
        ' ''            prmrow("cFiscalNumeroExterior") = prmobj.FiscalNumeroExterior
        ' ''            prmrow("cFiscalNumeroInterior") = prmobj.FiscalNumeroInterior
        ' ''            prmrow("cFiscalRazonSocial") = prmobj.FiscalRazonSocial
        ' ''            prmrow("cFiscalIDFiscal") = prmobj.FiscalIDFiscal
        ' ''            prmrow("cFiscalNombreExtranjero") = prmobj.FiscalNombreExtranjero
        ' ''            prmrow("cFiscalPaisResidencia") = prmobj.FiscalPaisResidencia
        ' ''            prmrow("cFiscalNacionalidad") = prmobj.FiscalNacionalidad
        ' ''            prmrow("nFiscalTipoProveedor") = prmobj.FiscalTipoProveedor


        ' ''            prmrow("bActivo") = prmobj.Activo


        ' ''            If prmobj.Impuesto Is Nothing Then
        ' ''                prmrow("nImpuestos") = DBNull.Value
        ' ''            Else
        ' ''                prmrow("nImpuestos") = prmobj.Impuesto.Folio
        ' ''            End If

        ' ''            If prmobj.ConceptoFlujo Is Nothing Then
        ' ''                prmrow("nConceptoFlujo") = DBNull.Value
        ' ''            Else
        ' ''                prmrow("nConceptoFlujo") = prmobj.ConceptoFlujo.Folio
        ' ''            End If

        ' ''            prmrow("bPolizaAcumulada") = prmobj.PolizaAcumulada

        ' ''            prmobj.LLenaDatosRegistroComun(prmrow)

        ' ''            Return prmrow
        ' ''        End Function

        ' ''        Public Shared Function ObtenProveedor(ByVal prmProveedor As Integer, Optional ByVal PrmCargaCompleta As Boolean = False) As Dominio.Catalogos.Proveedores.ClsProveedor
        ' ''            Dim vSql As String
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim vTabla As New DataTable

        ' ''            ObtenProveedor = New Catalogos.Proveedores.ClsProveedor

        ' ''            vSql = "SELECT * FROM CTL_Proveedores(NOLOCK)" & vbCr
        ' ''            vSql &= "WHERE nProveedor = " & prmProveedor.ToString & vbCr
        ' ''            DAO.RegresaConsultaSQL(vSql, vTabla)

        ' ''            If vTabla.Rows.Count > 0 Then
        ' ''                ObtenProveedor.atrRow = vTabla.Rows(0)
        ' ''                ObtenProveedor.Folio = ObtenProveedor.atrRow("nProveedor")
        ' ''                ObtenProveedor.NombreFiscal = ObtenProveedor.atrRow("cNombreFiscal")

        ' ''                If ObtenProveedor.atrRow("cNombreCorto") Is DBNull.Value Then
        ' ''                    ObtenProveedor.NombreCorto = ""
        ' ''                Else
        ' ''                    ObtenProveedor.NombreCorto = ObtenProveedor.atrRow("cNombreCorto")
        ' ''                End If

        ' ''                ObtenProveedor.NombreComercial = ObtenProveedor.atrRow("cNombreComercial")
        ' ''                ObtenProveedor.RFC = ObtenProveedor.atrRow("cRFC")
        ' ''                ObtenProveedor.Calle = ClsTools.IfNull(ObtenProveedor.atrRow("cCalle"), "")
        ' ''                ObtenProveedor.CURP = ClsTools.IfNull(ObtenProveedor.atrRow("cCURP"), "")
        ' ''                If Not ObtenProveedor.atrRow("nColonia") Is DBNull.Value Then
        ' ''                    ObtenProveedor.Colonia = ObtenColonia(ObtenProveedor.atrRow("nColonia"))
        ' ''                End If
        ' ''                ObtenProveedor.CodigoPostal = ClsTools.IfNull(ObtenProveedor.atrRow("cCodigoPostal"), "")
        ' ''                ObtenProveedor.Pais = ClsTools.IfNull(ObtenProveedor.atrRow("cPais"), "")

        ' ''                If vTabla.Rows(0).Item("nImpuestos") Is DBNull.Value Then
        ' ''                    ObtenProveedor.Impuesto = Nothing
        ' ''                Else
        ' ''                    ObtenProveedor.Impuesto = ObtenImpuesto(vTabla.Rows(0).Item("nImpuestos"))
        ' ''                End If
        ' ''                ObtenProveedor.PlazaRegistro = Catalogos.FabricaCatalogos.ObtenPlaza(ObtenProveedor.atrRow("nPlazaRegistro"))
        ' ''                ObtenProveedor.Notas = IfNull(ObtenProveedor.atrRow("cNotas"), "")
        ' ''                ObtenProveedor.DiasPago = ClsTools.IfNull(ObtenProveedor.atrRow("nDiasPago"), 0)
        ' ''                ObtenProveedor.DiasEntrega = ClsTools.IfNull(ObtenProveedor.atrRow("nDiasEntrega"), 0)
        ' ''                ObtenProveedor.FechaAplicacionPago = IfNull(ObtenProveedor.atrRow("nFechaAplicacionPago"), 0)
        ' ''                ObtenProveedor.PorcentajeAnticipo = IfNull(ObtenProveedor.atrRow("nPorcentajeAnticipo"), 0)
        ' ''                ObtenProveedor.Activo = ObtenProveedor.atrRow("bActivo")
        ' ''                ObtenProveedor.TipoProveedor = IfNull(ObtenProveedor.atrRow("nTipoProveedor"), 0)

        ' ''                'Obten los Datos Fiscales
        ' ''                ObtenProveedor.FiscalNombre = IfNull(ObtenProveedor.atrRow("cFiscalNombre"), "")
        ' ''                ObtenProveedor.FiscalApellidoPaterno = IfNull(ObtenProveedor.atrRow("cFiscalApellidoPaterno"), "")
        ' ''                ObtenProveedor.FiscalApellidoMaterno = IfNull(ObtenProveedor.atrRow("cFiscalApellidoMaterno"), "")
        ' ''                ObtenProveedor.FiscalEstado = IfNull(ObtenProveedor.atrRow("cFiscalEstado"), "")
        ' ''                ObtenProveedor.FiscalDelegacion = IfNull(ObtenProveedor.atrRow("cFiscalDelegacion"), "")
        ' ''                ObtenProveedor.FiscalLocalidad = IfNull(ObtenProveedor.atrRow("cFiscalLocalidad"), "")
        ' ''                ObtenProveedor.FiscalColonia = IfNull(ObtenProveedor.atrRow("cFiscalColonia"), "")
        ' ''                ObtenProveedor.FiscalCalle = IfNull(ObtenProveedor.atrRow("cFiscalCalle"), "")
        ' ''                ObtenProveedor.FiscalCodigoPostal = IfNull(ObtenProveedor.atrRow("cFiscalCodigoPostal"), "")
        ' ''                ObtenProveedor.FiscalTelefono = IfNull(ObtenProveedor.atrRow("cFiscalTelefono"), "")
        ' ''                ObtenProveedor.FiscalNumeroExterior = IfNull(ObtenProveedor.atrRow("cFiscalNumeroExterior"), "")
        ' ''                ObtenProveedor.FiscalNumeroInterior = IfNull(ObtenProveedor.atrRow("cFiscalNumeroInterior"), "")
        ' ''                ObtenProveedor.FiscalRazonSocial = IfNull(ObtenProveedor.atrRow("cFiscalRazonSocial"), "")
        ' ''                ObtenProveedor.FiscalIDFiscal = IfNull(ObtenProveedor.atrRow("cFiscalIDFiscal"), "")
        ' ''                ObtenProveedor.FiscalNombreExtranjero = IfNull(ObtenProveedor.atrRow("cFiscalNombreExtranjero"), "")
        ' ''                ObtenProveedor.FiscalPaisResidencia = IfNull(ObtenProveedor.atrRow("cFiscalPaisResidencia"), "")
        ' ''                ObtenProveedor.FiscalNacionalidad = IfNull(ObtenProveedor.atrRow("cFiscalNacionalidad"), "")
        ' ''                ObtenProveedor.FiscalTipoProveedor = IfNull(ObtenProveedor.atrRow("nFiscalTipoProveedor"), 0)

        ' ''                '


        ' ''                ObtenProveedor.ProveedoresProntosPagos.ValorPrimaryKey = "nProveedor=" & ObtenProveedor.Folio
        ' ''                ObtenProveedor.ProveedoresObservaciones.ValorPrimaryKey = "nProveedor=" & ObtenProveedor.Folio
        ' ''                ObtenProveedor.ProveedoresCuentasBancarias.ValorPrimaryKey = "nProveedor=" & ObtenProveedor.Folio
        ' ''                ObtenProveedor.ProveedoresContactos.ValorPrimaryKey = "nProveedor=" & ObtenProveedor.Folio
        ' ''                ObtenProveedor.ProveedoresArticulos.ValorPrimaryKey = "nProveedor=" & ObtenProveedor.Folio


        ' ''                If ObtenProveedor.atrRow("nConceptoFlujo") Is DBNull.Value Then
        ' ''                    ObtenProveedor.ConceptoFlujo = Nothing
        ' ''                Else
        ' ''                    ObtenProveedor.ConceptoFlujo = ObtenConceptoFlujo(ObtenProveedor.atrRow("nConceptoFlujo"))
        ' ''                End If

        ' ''                If ObtenProveedor.atrRow("bPolizaAcumulada") Is DBNull.Value Then
        ' ''                    ObtenProveedor.PolizaAcumulada = False
        ' ''                Else
        ' ''                    ObtenProveedor.PolizaAcumulada = ObtenProveedor.atrRow("bPolizaAcumulada")
        ' ''                End If

        ' ''                ObtenProveedor.CargaDatosRegistro(ObtenProveedor.atrRow)

        ' ''                If PrmCargaCompleta Then
        ' ''                    ObtenProveedor.RefreshContainers()
        ' ''                End If

        ' ''            Else
        ' ''                Return Nothing
        ' ''            End If

        ' ''            Return ObtenProveedor
        ' ''        End Function

        ' ''        Public Shared Function ObtenTiposLinea(ByVal PrmLlave As String, ByVal PrmValores As String) As DataTable
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim vSql As String = ""
        ' ''            Dim dt As New DataTable

        ' ''            vSql = "SELECT * FROM ADSUM_TiposDatos (nolock) WHERE cLlave = '" & PrmLlave & "' AND nValor NOT IN (" & PrmValores & ")"
        ' ''            DAO.RegresaConsultaSQL(vSql, dt)

        ' ''            Return dt
        ' ''        End Function

        Public Shared Function ObtenerTiposDatos(ByVal PrmLlave As String) As DataTable
            Dim vlsql As String
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim DtRes As New DataTable

            vlsql = "SELECT nValor,cValor,nTipoDato,cLlave FROM ADSUM_TiposDatos(NOLOCK)"
            vlsql &= "WHERE  cLlave='" & PrmLlave & "'"

            DAO.RegresaConsultaSQL(vlsql, DtRes)

            Return DtRes
        End Function

        ' ''        Public Shared Function ObtenerMeses(ByVal PrmLlave As String) As DataTable
        ' ''            Dim vlsql As String
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim DtRes As New DataTable

        ' ''            vlsql = "SELECT nValor,cValor,nTipoDato,cLlave FROM ADSUM_TiposDatos(NOLOCK)"
        ' ''            vlsql &= "WHERE  cLlave='" & PrmLlave & "' order by nValor asc"

        ' ''            DAO.RegresaConsultaSQL(vlsql, DtRes)

        ' ''            Return DtRes
        ' ''        End Function
        ' ''        Public Shared Function ObtenerTiposDatosPorDescripcion(ByVal PrmLlave As String, ByVal PrmcValor As String) As Object
        ' ''            Dim vlsql As String
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim DtRes As New DataTable

        ' ''            vlsql = "SELECT nValor FROM ADSUM_TiposDatos(NOLOCK)"
        ' ''            vlsql &= "WHERE  cLlave='" & PrmLlave & "' and cValor='" & PrmcValor & "'"
        ' ''            DAO.RegresaConsultaSQL(vlsql, DtRes)
        ' ''            Return DtRes.Rows.Item(0).Item(0)

        ' ''        End Function


        Public Shared Function ObtenTiposDatos(ByVal prmTiposDatos As Integer, Optional ByVal tiempo_real As Boolean = False) As ClsTiposDatos
            If atrCatalogoTiposDatos Is Nothing Then atrCatalogoTiposDatos = New Catalogo(New MetaCatalogo("TIPOS_DATOS"))
            Dim vobject As Object = ObtenGenerico(prmTiposDatos.ToString, atrTiposDatosinmemory, atrCatalogoTiposDatos, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenTiposDatos), tiempo_real)
            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsTiposDatos))
            Return New ClsTiposDatos
        End Function


        Public Shared Function ObtenTiposDatos(ByVal prmrow As DataRow) As ClsTiposDatos
            If prmrow Is Nothing Then
                Return Nothing
            End If

            Dim ret As New ClsTiposDatos(prmrow("nTipoDato"))

            ' ret.TipoDato = prmrow("nTipoDato")
            ret.Llave = prmrow("cLlave")
            ret.Valor = prmrow("nValor")
            ret.ValorDescripcion = prmrow("cValor")

            '    ret.Folio = prmrow("nTipoDato")
            ' ret.TipoDato = prmrow("nTipoDato")


            Return ret

        End Function


        Public Shared Function ObtenTiposDatos(ByRef prmRow As DataRow, ByVal prmTiposDatos As Object) As DataRow
            If prmRow Is Nothing Then
                Return Nothing
            End If
            If prmTiposDatos Is Nothing Then
                Return Nothing
            End If

            'Dim vrmTiposDatos As ClsLinea = CType(prmTiposDatos, ClsTiposDatos)

            prmRow("nTipoDato") = prmTiposDatos.Folio
            prmRow("cLlave") = prmTiposDatos.Llave
            prmRow("cValor") = prmTiposDatos.ValorDescripcion
            prmRow("nValor") = prmTiposDatos.Valor

            Return prmRow
        End Function


        ' ''        Public Shared Function ObtenCodigoProduccion(ByVal prmCodigoProduccion As Integer, Optional ByVal tiempo_real As Boolean = False) As ClsCodigoProduccion
        ' ''            Return ObtenCodigoProduccionn(prmCodigoProduccion)

        ' ''            prmCodigoProduccion = IIf(prmCodigoProduccion = 0, 7, prmCodigoProduccion)
        ' ''            If atrCatalogoCodigoProduccion Is Nothing Then atrCatalogoCodigoProduccion = New Catalogo(New MetaCatalogo("CODIGOSPRODUCCION"))
        ' ''            Dim vobject As Object = ObtenGenerico(prmCodigoProduccion.ToString, atrCodigoProduccionInMemory, atrCatalogoCodigoProduccion, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenCodigoProduccion), tiempo_real)
        ' ''            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsCodigoProduccion))
        ' ''        End Function

        ' ''        Public Shared Function ObtenCodigoProduccionn(ByVal prmCodigoProduccion As Integer) As ClsCodigoProduccion
        ' ''            'Cuando el codigo es 0, se envia un 7
        ' ''            If prmCodigoProduccion = 0 Then prmCodigoProduccion = 7
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim vcSQL As String = "SELECT * FROM CTL_CodigosProduccion (NOLOCK) WHERE nCodigo = " & prmCodigoProduccion
        ' ''            Dim vDt As New DataTable
        ' ''            DAO.RegresaConsultaSQL(vcSQL, vDt)
        ' ''            If vDt Is Nothing OrElse vDt.Rows.Count = 0 Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            Return ObtenCodigoProduccion(vDt.Rows(0))
        ' ''        End Function
        ' ''        Public Shared Function ObtenCodigoProduccion(ByVal prmrow As DataRow) As ClsCodigoProduccion
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            Dim ret As New ClsCodigoProduccion(prmrow("nCodigo"))
        ' ''            ret.Descripcion = prmrow("cDescripcion")
        ' ''            ret.Activo = prmrow("bactivo")
        ' ''            ret.CargaDatosRegistro(prmrow)
        ' ''            Return ret
        ' ''        End Function

        ' ''        Public Shared Function ObtenCodigoProduccion(ByRef prmRow As DataRow, ByVal prmCodigoProduccion As Object) As DataRow
        ' ''            If prmRow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            If prmCodigoProduccion Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            Dim ret As ClsTipoAlmacenConsumo = CType(prmCodigoProduccion, ClsTipoAlmacenConsumo)
        ' ''            prmRow("nCodigo") = prmCodigoProduccion.Folio
        ' ''            prmRow("cDescripcion") = prmCodigoProduccion.Descripcion
        ' ''            prmRow("bActivo") = prmCodigoProduccion.Activo
        ' ''            prmCodigoProduccion.LLenaDatosRegistroComun(prmRow)
        ' ''            Return prmRow
        ' ''        End Function

        ' ''        Public Shared Function ObtenTipoAlmacenConsumo(ByVal prmTipoAlmacenConsumo As Integer, Optional ByVal tiempo_real As Boolean = False) As ClsTipoAlmacenConsumo
        ' ''            If atrCatalogoTiposAlmacenConsumo Is Nothing Then atrCatalogoTiposAlmacenConsumo = New Catalogo(New MetaCatalogo("TIPOSALMACENCONSUMO"))
        ' ''            Dim vobject As Object = ObtenGenerico(prmTipoAlmacenConsumo.ToString, atrTiposAlmacenConsumoInMemory, atrCatalogoTiposAlmacenConsumo, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenTipoAlmacenConsumo), tiempo_real)
        ' ''            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsTipoAlmacenConsumo))
        ' ''        End Function

        ' ''        Public Shared Function ObtenTipoAlmacenConsumo(ByVal prmrow As DataRow) As ClsTipoAlmacenConsumo
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            Dim ret As New ClsTipoAlmacenConsumo(prmrow("nTipoAlmacenConsumo"))
        ' ''            ret.Descripcion = prmrow("cDescripcion")
        ' ''            ret.Activo = prmrow("bactivo")
        ' ''            ret.CargaDatosRegistro(prmrow)
        ' ''            Return ret
        ' ''        End Function

        ' ''        Public Shared Function ObtenTipoAlmacenConsumo(ByRef prmRow As DataRow, ByVal prmTipo As Object) As DataRow
        ' ''            If prmRow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            If prmTipo Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            Dim ret As ClsTipoAlmacenConsumo = CType(prmTipo, ClsTipoAlmacenConsumo)
        ' ''            prmRow("nTipoAlmacenConsumo") = prmTipo.Folio
        ' ''            prmRow("cDescripcion") = prmTipo.Descripcion
        ' ''            prmRow("bActivo") = prmTipo.Activo
        ' ''            prmTipo.LLenaDatosRegistroComun(prmRow)
        ' ''            Return prmRow
        ' ''        End Function


        ' ''        'Public Shared Function ObtenLineaProducto(ByVal prmLinea As Integer, Optional ByVal tiempo_real As Boolean = False) As ClsLineaProducto
        ' ''        '    If atrCatalogoLineasProductos Is Nothing Then atrCatalogoLineasProductos = New Catalogo(New MetaCatalogo("LINEASPRODUCTOS"))
        ' ''        '    Dim vobject As Object = ObtenGenerico(prmLinea.ToString, atrLineasProductosInMemory, atrCatalogoLineasProductos, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenLineaProducto), tiempo_real)
        ' ''        '    Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsLineaProducto))
        ' ''        'End Function
        ' ''        Public Shared Function ObtenLineaProducto(ByVal prmLinea As Integer, Optional ByVal tiempo_real As Boolean = False) As ClsLineaProducto
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim vcSQL As String = "SELECT * FROM CTL_LineasProductos (NOLOCK) WHERE nLinea = " & prmLinea
        ' ''            Dim vDt As New DataTable
        ' ''            DAO.RegresaConsultaSQL(vcSQL, vDt)
        ' ''            If vDt Is Nothing OrElse vDt.Rows.Count = 0 Then Return Nothing
        ' ''            Return ObtenLineaProducto(vDt.Rows(0))
        ' ''        End Function

        ' ''        Public Shared Function ObtenLineaProducto(ByVal prmrow As DataRow) As ClsLineaProducto
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            Dim ret As New ClsLineaProducto(prmrow("nLinea"))

        ' ''            ret.Descripcion = prmrow("cDescripcion")
        ' ''            ret.Abreviatura = prmrow("cAbreviatura")
        ' ''            ret.ProgramaProduccionNivelComponente = IfNull(prmrow("bManejaNivelCOmponente"), False)
        ' ''            ret.ProgramaProduccionNivelProductoTerminado = IfNull(prmrow("bManejaNivelProductoTerminado"), False)
        ' ''            ret.Activo = prmrow("bactivo")

        ' ''            ret.CargaDatosRegistro(prmrow)

        ' ''            Return ret
        ' ''        End Function

        ' ''        Public Shared Function ObtenLineaProducto(ByRef prmRow As DataRow, ByVal prmLinea As Object) As DataRow
        ' ''            If prmRow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            If prmLinea Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            Dim vrmlinea As ClsLineaProducto = CType(prmLinea, ClsLineaProducto)

        ' ''            prmRow("nLinea") = prmLinea.Folio
        ' ''            prmRow("cDescripcion") = prmLinea.Descripcion
        ' ''            prmRow("cAbreviatura") = vrmlinea.Abreviatura
        ' ''            prmRow("bActivo") = prmLinea.Activo
        ' ''            prmRow("bManejaNivelCOmponente") = CType(prmLinea, ClsLineaProducto).ProgramaProduccionNivelComponente
        ' ''            prmRow("bManejaNivelProductoTerminado") = CType(prmLinea, ClsLineaProducto).ProgramaProduccionNivelProductoTerminado
        ' ''            prmLinea.LLenaDatosRegistroComun(prmRow)

        ' ''            Return prmRow
        ' ''        End Function

        ' ''        Public Shared Function ObtenLinea(ByVal prmLinea As Integer, Optional ByVal tiempo_real As Boolean = False) As ClsLinea
        ' ''            If atrCatalogoLineas Is Nothing Then atrCatalogoLineas = New Catalogo(New MetaCatalogo("LINEAS"))
        ' ''            Dim vobject As Object = ObtenGenerico(prmLinea.ToString, atrLineasinmemory, atrCatalogoLineas, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenLinea), tiempo_real)
        ' ''            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsLinea))
        ' ''            Return New ClsLinea
        ' ''        End Function

        ' ''        Public Shared Function Obtenlinea(ByVal prmrow As DataRow) As ClsLinea
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If

        ' ''            Dim ret As New ClsLinea(prmrow("nlinea"))
        ' ''            ret.Descripcion = prmrow("cdescripcion")
        ' ''            ret.Abreviatura = prmrow("cAbreviatura")
        ' ''            ret.TipoLinea = prmrow("ntipolinea")
        ' ''            ret.TipoArticulo = Catalogos.FabricaCatalogos.ObtenTipoArticulo(prmrow("nTipoArticulo"))

        ' ''            If prmrow("nCuenta1") Is DBNull.Value Then
        ' ''                ret.Cuenta1 = Nothing
        ' ''            Else
        ' ''                ret.Cuenta1 = ObtenCuentaCnt(prmrow("nCuenta1"))
        ' ''            End If

        ' ''            If prmrow("nCuenta2") Is DBNull.Value Then
        ' ''                ret.Cuenta2 = Nothing
        ' ''            Else
        ' ''                ret.Cuenta2 = ObtenCuentaCnt(prmrow("nCuenta2"))
        ' ''            End If

        ' ''            If prmrow("nOrden") Is DBNull.Value Then
        ' ''                ret.Orden = 0
        ' ''            Else
        ' ''                ret.Orden = prmrow("nOrden")
        ' ''            End If

        ' ''            If prmrow("nFlujo1") Is DBNull.Value Then
        ' ''                ret.Flujo1 = Nothing
        ' ''            Else
        ' ''                ret.Flujo1 = ObtenFlujoEfectivo(prmrow("nFlujo1"))
        ' ''            End If

        ' ''            If prmrow("nFlujo2") Is DBNull.Value Then
        ' ''                ret.Flujo2 = Nothing
        ' ''            Else
        ' ''                ret.Flujo2 = ObtenFlujoEfectivo(prmrow("nFlujo2"), False, True)
        ' ''            End If

        ' ''            If prmrow("nFlujo3") Is DBNull.Value Then
        ' ''                ret.Flujo3 = Nothing
        ' ''            Else
        ' ''                ret.Flujo3 = ObtenFlujoEfectivo(prmrow("nFlujo3"), False, True)
        ' ''            End If

        ' ''            ret.Activo = prmrow("bactivo")

        ' ''            If prmrow("bLineaDeActivos") Is DBNull.Value Then
        ' ''                ret.LineadeActivos = False
        ' ''            Else
        ' ''                ret.LineadeActivos = prmrow("bLineaDeActivos")
        ' ''            End If

        ' ''            ret.CargaDatosRegistro(prmrow)

        ' ''            Return ret

        ' ''        End Function

        ' ''        Public Shared Function ObtenLinea(ByRef prmRow As DataRow, ByVal prmLinea As Object) As DataRow
        ' ''            If prmRow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            If prmLinea Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            Dim vrmlinea As ClsLinea = CType(prmLinea, ClsLinea)
        ' ''            prmRow("NLINEA") = prmLinea.Folio
        ' ''            prmRow("CDESCRIPCION") = prmLinea.Descripcion
        ' ''            prmRow("cAbreviatura") = vrmlinea.Abreviatura
        ' ''            prmRow("NTIPOLINEA") = prmLinea.TipoLinea
        ' ''            prmRow("nTipoArticulo") = vrmlinea.TipoArticulo.Folio
        ' ''            If vrmlinea.Cuenta1 Is Nothing Then
        ' ''                prmRow("NCUENTA1") = DBNull.Value
        ' ''            Else
        ' ''                prmRow("NCUENTA1") = vrmlinea.Cuenta1.Folio
        ' ''            End If

        ' ''            If vrmlinea.Cuenta2 Is Nothing Then
        ' ''                prmRow("NCUENTA2") = DBNull.Value
        ' ''            Else
        ' ''                prmRow("NCUENTA2") = vrmlinea.Cuenta2.Folio
        ' ''            End If

        ' ''            prmRow("nOrden") = vrmlinea.Orden

        ' ''            If vrmlinea.Flujo1 Is Nothing Then
        ' ''                prmRow("nFlujo1") = DBNull.Value
        ' ''            Else
        ' ''                prmRow("nFlujo1") = vrmlinea.Flujo1.Folio
        ' ''            End If

        ' ''            If vrmlinea.Flujo2 Is Nothing Then
        ' ''                prmRow("nFlujo2") = DBNull.Value
        ' ''            Else
        ' ''                prmRow("nFlujo2") = vrmlinea.Flujo2.Folio
        ' ''            End If

        ' ''            If vrmlinea.Flujo3 Is Nothing Then
        ' ''                prmRow("nFlujo3") = DBNull.Value
        ' ''            Else
        ' ''                prmRow("nFlujo3") = vrmlinea.Flujo3.Folio
        ' ''            End If

        ' ''            prmRow("BACTIVO") = prmLinea.Activo
        ' ''            prmRow("bLineaDeActivos") = vrmlinea.LineadeActivos
        ' ''            prmLinea.LLenaDatosRegistroComun(prmRow)

        ' ''            Return prmRow
        ' ''        End Function

        ' ''        Public Shared Function ObtenImpuesto(ByVal prmImpuesto As Integer, Optional ByVal tiempo_real As Boolean = False) As ClsImpuesto
        ' ''            If atrCatalogoImpuesto Is Nothing Then atrCatalogoImpuesto = New Catalogo(New MetaCatalogo("IMPUESTOS"))
        ' ''            Dim vobject As Object = ObtenGenerico(prmImpuesto.ToString, atrImpuestoinmemory, atrCatalogoImpuesto, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenImpuesto), tiempo_real)
        ' ''            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsImpuesto))
        ' ''        End Function



        ' ''        Public Shared Function ObtenImpuesto(ByVal prmrow As DataRow) As ClsImpuesto
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If

        ' ''            Dim ret As New ClsImpuesto(prmrow("nImpuestos"))
        ' ''            ret.Descripcion = prmrow("cdescripcion")
        ' ''            ret.Porcentaje = prmrow("nporcentaje")
        ' ''            ret.IVA = prmrow("bIVA")
        ' ''            ret.Frontera = prmrow("bFrontera")
        ' ''            ret.Activo = prmrow("bactivo")

        ' ''            If prmrow("nIdentificadorContable") Is DBNull.Value Then
        ' ''                ret.IdentificadorContable = 0
        ' ''            Else
        ' ''                ret.IdentificadorContable = prmrow("nIdentificadorContable")
        ' ''            End If

        ' ''            ret.CargaDatosRegistro(prmrow)

        ' ''            Return ret

        ' ''        End Function

        ' ''        Public Shared Function ObtenImpuesto(ByRef prmrow As DataRow, ByVal prmImpuesto As ClsImpuesto) As DataRow
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If

        ' ''            If prmImpuesto Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            prmrow("nImpuestos") = prmImpuesto.Folio
        ' ''            prmrow("cdescripcion") = prmImpuesto.Descripcion
        ' ''            prmrow("nporcentaje") = prmImpuesto.Porcentaje
        ' ''            prmrow("bIVA") = prmImpuesto.IVA
        ' ''            prmrow("bFrontera") = prmImpuesto.Frontera
        ' ''            prmrow("bactivo") = prmImpuesto.Activo

        ' ''            If prmImpuesto.IdentificadorContable = 0 Then
        ' ''                prmrow("nIdentificadorContable") = DBNull.Value
        ' ''            Else
        ' ''                prmrow("nIdentificadorContable") = prmImpuesto.IdentificadorContable
        ' ''            End If

        ' ''            prmImpuesto.LLenaDatosRegistroComun(prmrow)

        ' ''            Return prmrow


        ' ''        End Function

        ' ''        Public Shared Function ValidaOrdenImpuesto(ByVal prmImpuesto As Integer, ByVal prmOrden As Integer) As Boolean
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim vSQL As String
        ' ''            Dim DT As New DataTable
        ' ''            Dim vBandera As Boolean

        ' ''            vSQL = "Select * From CTL_Impuestos(NoLock)"
        ' ''            vSQL &= vbCrLf & "Where bActivo = 1 And nImpuestos <> " & prmImpuesto & " And nOrden = " & prmOrden

        ' ''            vBandera = DAO.RegresaConsultaSQL(vSQL, DT)

        ' ''            If DT Is Nothing Then
        ' ''                Return False
        ' ''            End If

        ' ''            If DT.Rows.Count = 0 Then
        ' ''                Return False
        ' ''            End If

        ' ''            Return True
        ' ''        End Function

        ' ''        Public Shared Function RegresaOrdenImpuesto() As Integer
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim vSQL As String
        ' ''            Dim DT As New DataTable
        ' ''            Dim vBandera As Boolean

        ' ''            vSQL = "Select Coalesce(Max(nOrden),0)+1 As nOrden From CTL_Impuestos(NoLock)"
        ' ''            vSQL &= vbCrLf & "Where bActivo = 1"

        ' ''            vBandera = DAO.RegresaConsultaSQL(vSQL, DT)

        ' ''            If DT Is Nothing Then
        ' ''                Return 0
        ' ''            End If

        ' ''            If DT.Rows.Count = 0 Then
        ' ''                Return 0
        ' ''            End If

        ' ''            Return DT.Rows(0).Item("nOrden")
        ' ''        End Function


        ' ''        Public Shared Function ObtenMarca(ByVal prmMarca As Integer, Optional ByVal tiempo_real As Boolean = False) As ClsMarca
        ' ''            If atrCatalogoMarcas Is Nothing Then atrCatalogoMarcas = New Catalogo(New MetaCatalogo("MARCAS"))
        ' ''            Dim vobject As Object = ObtenGenerico(prmMarca.ToString, atrMarcasinmemory, atrCatalogoMarcas, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenMarca), tiempo_real)
        ' ''            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsMarca))
        ' ''        End Function

        ' ''        Public Shared Function ObtenMarcas(Optional ByVal bActivo As Boolean = True) As DataTable
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim dt As New DataTable
        ' ''            Dim vSql As String = "SELECT * FROM CTL_Marcas (NOLOCK)" & vbCr

        ' ''            If bActivo = True Then
        ' ''                vSql &= "WHERE bActivo = 1" & vbCr
        ' ''            Else
        ' ''                vSql &= "WHERE bActivo = 0" & vbCr
        ' ''            End If

        ' ''            DAO.RegresaConsultaSQL(vSql, dt)

        ' ''            Return dt

        ' ''        End Function

        ' ''        '  Public Shared 

        ' ''        Public Shared Function ObtenMarca(ByVal prmrow As DataRow) As ClsMarca
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If

        ' ''            Dim ret As New ClsMarca(prmrow("nMarca"))
        ' ''            ret.Descripcion = prmrow("cdescripcion")
        ' ''            ret.Activo = prmrow("bactivo")

        ' ''            ret.CargaDatosRegistro(prmrow)

        ' ''            Return ret

        ' ''        End Function

        ' ''        Public Shared Function ObtenMarca(ByRef prmrow As DataRow, ByVal prmobj As ClsMarca) As DataRow
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            If prmobj Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            prmrow("nMarca") = prmobj.Folio
        ' ''            prmrow("cdescripcion") = prmobj.Descripcion
        ' ''            prmrow("bactivo") = prmobj.Activo

        ' ''            prmobj.LLenaDatosRegistroComun(prmrow)


        ' ''            Return prmrow

        ' ''        End Function

        ' ''        '*****
        ' ''        Public Shared Function ValidaExistanTablasParaContextoEnviarWS(ByVal prmContexto As WS.ClsContextosEnviar) As Boolean
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim vDt As New DataTable
        ' ''            Dim vcSQL As String = "SELECT * FROM CTL_InformacionEnviarWS (NOLOCK) " & vbCr
        ' ''            vcSQL &= " WHERE bActivo = 1 and cContexto = '" & prmContexto.Descripcion.Trim & "'"
        ' ''            DAO.RegresaConsultaSQL(vcSQL, vDt)
        ' ''            If vDt Is Nothing OrElse vDt.Rows.Count = 0 Then Return False
        ' ''            Return True
        ' ''        End Function
        ' ''        Public Shared Function ObtenContextoEnviarWS(ByVal prmContexto As Int32) As WS.ClsContextosEnviar
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim dt As New DataTable
        ' ''            Dim vSql As String = "SELECT * FROM CTL_ContextosEnviarWS (NOLOCK)" & vbCr
        ' ''            vSql &= " WHERE nContexto = " & prmContexto
        ' ''            DAO.RegresaConsultaSQL(vSql, dt)
        ' ''            If dt Is Nothing OrElse dt.Rows.Count = 0 Then Return Nothing
        ' ''            Return ObtenContextoEnviarWS(dt.Rows(0))
        ' ''        End Function

        ' ''        '  Public Shared 

        ' ''        Public Shared Function ObtenContextoEnviarWS(ByVal prmrow As DataRow) As WS.ClsContextosEnviar
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            Dim ret As New WS.ClsContextosEnviar(prmrow("nContexto"))
        ' ''            ret.Descripcion = prmrow("cDescripcion")
        ' ''            ret.Activo = prmrow("bActivo")
        ' ''            ret.CargaDatosRegistro(prmrow)
        ' ''            Return ret
        ' ''        End Function

        ' ''        Public Shared Function ObtenContextoEnviarWS(ByRef prmrow As DataRow, ByVal prmobj As WS.ClsContextosEnviar) As DataRow
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            If prmobj Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            prmrow("nContexto") = prmobj.Folio
        ' ''            prmrow("cDescripcion") = prmobj.Descripcion
        ' ''            prmrow("bActivo") = prmobj.Activo
        ' ''            prmobj.LLenaDatosRegistroComun(prmrow)
        ' ''            Return prmrow
        ' ''        End Function
        ' ''        '*****

        ' ''        Public Shared Function ObtenPresentacionArticulos(ByVal prmPresentcacion As Integer, Optional ByVal tiempo_real As Boolean = False) As ClsPresentaciones
        ' ''            If atrCatalogoPresentacion Is Nothing Then atrCatalogoPresentacion = New Catalogo(New MetaCatalogo("PresentacionsArticulos"))
        ' ''            Dim vobject As Object = ObtenGenerico(prmPresentcacion.ToString, atrPresentacioninmemory, atrCatalogoPresentacion, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenPresentacionArticulos), tiempo_real)
        ' ''            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsPresentaciones))
        ' ''        End Function

        ' ''        Public Shared Function ObtenPresentacionArticulos(ByVal prmrow As DataRow) As ClsPresentaciones
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If

        ' ''            Dim ret As New ClsPresentaciones(prmrow("nPresentacion"))
        ' ''            ret.Descripcion = prmrow("cDescripcion")
        ' ''            ret.Activo = prmrow("bActivo")

        ' ''            ret.CargaDatosRegistro(prmrow)

        ' ''            Return ret

        ' ''        End Function

        ' ''        Public Shared Function ObtenPresentacionArticulos(ByRef prmrow As DataRow, ByVal prmobj As ClsPresentaciones) As DataRow
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            If prmobj Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            prmrow("nPresentacion") = prmobj.Folio
        ' ''            prmrow("cDescripcion") = prmobj.Descripcion
        ' ''            prmrow("bActivo") = prmobj.Activo

        ' ''            prmobj.LLenaDatosRegistroComun(prmrow)


        ' ''            Return prmrow

        ' ''        End Function
        ' ''        'Public Shared Sub PgLlenaComboPresentaciones(ByRef prmCombo As DevExpress.XtraEditors.Repository.RepositoryItemComboBox, ByRef prmArregloPresentaciones() As Object)
        ' ''        '    prmCombo.Items.Clear()
        ' ''        '    Dim ObjSeleccione As New Catalogos.ClsPresentacion(0)
        ' ''        '    ObjSeleccione.Descripcion = "<<SELECCIONE>>"
        ' ''        '    prmCombo.Items.Add(ObjSeleccione)
        ' ''        '    For Each vPresentacion As Catalogos.ClsPresentacion In prmArregloPresentaciones
        ' ''        '        If vPresentacion.Activo = True Then
        ' ''        '            prmCombo.Items.Add(vPresentacion)
        ' ''        '        End If
        ' ''        '    Next
        ' ''        'End Sub
        ' ''        Public Shared Function LlenaComboPresentacionesCatalogo(ByRef prmDataTable As DataTable, ByRef prmCombo As DevExpress.XtraEditors.Repository.RepositoryItemComboBox, Optional ByVal bActivo As Boolean = True) As Boolean
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            prmDataTable = New DataTable
        ' ''            Dim vSql As String = "SELECT nPresentacion,cDescripcion,bActivo FROM CTL_Presentaciones (NOLOCK) " & vbCr
        ' ''            If bActivo = True Then
        ' ''                vSql &= "WHERE bActivo = 1" & vbCr
        ' ''            Else
        ' ''                vSql &= "WHERE bActivo = 0" & vbCr
        ' ''            End If
        ' ''            vSql &= " ORDER BY cDescripcion"
        ' ''            DAO.RegresaConsultaSQL(vSql, prmDataTable)

        ' ''            prmCombo.Items.Clear()
        ' ''            Dim ObjSeleccione As New Catalogos.ClsPresentaciones
        ' ''            ObjSeleccione.Descripcion = "<<SELECCIONE>>"
        ' ''            prmCombo.Items.Add(ObjSeleccione)
        ' ''            For Each dr As DataRow In prmDataTable.Rows
        ' ''                If Not IfNull(dr("bActivo"), False) Then Continue For
        ' ''                ObjSeleccione = New ClsPresentaciones(dr("nPresentacion"))
        ' ''                ObjSeleccione.Folio = dr("nPresentacion")
        ' ''                ObjSeleccione.Descripcion = dr("cDescripcion")
        ' ''                ObjSeleccione.Activo = dr("bActivo")
        ' ''                prmCombo.Items.Add(ObjSeleccione)
        ' ''            Next



        ' ''            Return True
        ' ''        End Function

        ' ''        Public Shared Function ObtenUnidad(ByVal prmUnidad As Integer, Optional ByVal tiempo_real As Boolean = False) As ClsUnidad
        ' ''            If atrCatalogoUnidades Is Nothing Then atrCatalogoUnidades = New Catalogo(New MetaCatalogo("UNIDADES"))
        ' ''            Dim vobject As Object = ObtenGenerico(prmUnidad.ToString, atrUnidadesinmemory, atrCatalogoUnidades, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenUnidad), tiempo_real)
        ' ''            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsUnidad))
        ' ''        End Function



        ' ''        Public Shared Function ObtenUnidad(ByVal prmrow As DataRow) As ClsUnidad
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If

        ' ''            Dim ret As New ClsUnidad(prmrow("nUnidad"))
        ' ''            ret.Descripcion = prmrow("cdescripcion")
        ' ''            ret.Abreviatura = prmrow("cabreviatura")
        ' ''            ret.TipoUnidad = IIf(prmrow("ntipoUnidad") Is DBNull.Value, Nothing, prmrow("ntipoUnidad"))
        ' ''            ret.Activo = prmrow("bactivo")

        ' ''            ret.CargaDatosRegistro(prmrow)

        ' ''            Return ret

        ' ''        End Function


        ' ''        Public Shared Function ObtenUnidad(ByRef prmrow As DataRow, ByVal prmobj As ClsUnidad) As DataRow
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            If prmobj Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            prmrow("NUNIDAD") = prmobj.Folio
        ' ''            prmrow("CDESCRIPCION") = prmobj.Descripcion
        ' ''            prmrow("CABREVIATURA") = prmobj.Abreviatura
        ' ''            prmrow("ntipoUnidad") = prmobj.TipoUnidad
        ' ''            prmrow("BACTIVO") = prmobj.Activo
        ' ''            prmobj.LLenaDatosRegistroComun(prmrow)

        ' ''            Return prmrow
        ' ''        End Function

        ' ''        Public Shared Function ObtenMovimiento(ByVal prmMovimiento As Integer, Optional ByVal tiempo_real As Boolean = False) As ClsMovimiento
        ' ''            If atrCatalogoMovimientos Is Nothing Then atrCatalogoMovimientos = New Catalogo(New MetaCatalogo("MOVIMIENTOS"))
        ' ''            Dim vobject As Object = ObtenGenerico(prmMovimiento.ToString, atrMovimientosinmemory, atrCatalogoMovimientos, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenMovimiento), tiempo_real)
        ' ''            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsMovimiento))
        ' ''        End Function



        ' ''        Public Shared Function ObtenMovimiento(ByVal prmrow As DataRow) As ClsMovimiento
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If

        ' ''            Dim ret As New ClsMovimiento(prmrow("nMovimiento"))
        ' ''            ret.Descripcion = prmrow("cdescripcion")
        ' ''            ret.TipoMovimiento = prmrow("ntipomovimiento")
        ' ''            ret.Activo = prmrow("bactivo")

        ' ''            ret.CargaDatosRegistro(prmrow)

        ' ''            Return ret

        ' ''        End Function

        ' ''        Public Shared Function ObtenPaqueteria(ByVal prmPaqueteria As Integer, Optional ByVal tiempo_real As Boolean = False) As ClsPaqueteria
        ' ''            If atrCatalogoPaqueterias Is Nothing Then atrCatalogoPaqueterias = New Catalogo(New MetaCatalogo("PAQUETERIAS"))
        ' ''            Dim vobject As Object = ObtenGenerico(prmPaqueteria.ToString, atrPaqueteriasinmemory, atrCatalogoPaqueterias, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenPaqueteria), tiempo_real)
        ' ''            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsPaqueteria))
        ' ''        End Function



        ' ''        Public Shared Function ObtenPaqueteria(ByVal prmrow As DataRow) As ClsPaqueteria
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If

        ' ''            Dim ret As New ClsPaqueteria(prmrow("nPaqueteria"))
        ' ''            ret.Descripcion = prmrow("cdescripcion")
        ' ''            ret.Activo = prmrow("bactivo")

        ' ''            ret.CargaDatosRegistro(prmrow)

        ' ''            Return ret

        ' ''        End Function

        ' ''        Public Shared Function ObtenPaqueteria(ByRef prmrow As DataRow, ByVal prmobj As ClsPaqueteria) As DataRow
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            If prmobj Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            prmrow("NPAQUETERIA") = prmobj.Folio
        ' ''            prmrow("CDESCRIPCION") = prmobj.Descripcion
        ' ''            prmrow("BACTIVO") = prmobj.Activo
        ' ''            prmobj.LLenaDatosRegistroComun(prmrow)
        ' ''            Return prmrow
        ' ''        End Function

        ' ''        Public Shared Function ObtenTipoInvolucrado(ByVal prmnInvolucrado As Integer) As String
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim vsql As String = ""
        ' ''            Dim TipoInvolucrado As String = ""
        ' ''            Dim dt As New DataTable

        ' ''            vsql = "select cTipoInvolucrado from ctl_Involucrados INV (nolock) where nInvolucrado= " & prmnInvolucrado
        ' ''            DAO.RegresaConsultaSQL(vsql, dt)

        ' ''            If dt.Rows.Count > 0 Then
        ' ''                TipoInvolucrado = dt.Rows(0).Item(0)
        ' ''                Return TipoInvolucrado
        ' ''            Else
        ' ''                Return ""
        ' ''            End If
        ' ''        End Function

        ' ''        Public Shared Function ActualizaAlmacenControlador(ByVal prmAlmacen As Catalogos.ClsAlmacen) As Boolean
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim vSql As String = ""
        ' ''            vSql = "UPDATE CTL_Almacenes SET nAlmacenControlador = nAlmacen WHERE nAlmacen = " & prmAlmacen.Folio
        ' ''            Return DAO.EjecutaComandoSQL(vSql)
        ' ''        End Function

        ' ''        Public Shared Function ObtenAlmacen(ByVal prmAlmacen As Integer, Optional ByVal tiempo_real As Boolean = False) As ClsAlmacen
        ' ''            If atrCatalogoAlmacenes Is Nothing Then atrCatalogoAlmacenes = New Catalogo(New MetaCatalogo("ALMACENES"))
        ' ''            Dim vobject As Object = ObtenGenerico(prmAlmacen.ToString, atrAlmacenesinmemory, atrCatalogoAlmacenes, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenAlmacen), tiempo_real)
        ' ''            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsAlmacen))
        ' ''        End Function

        ' ''        Public Shared Function ObtenAlmacenPrincipal(ByVal prmPlaza As ClsPlaza, Optional ByVal tiempo_real As Boolean = False) As ClsAlmacen
        ' ''            If atrCatalogoAlmacenesPrincipales Is Nothing Then atrCatalogoAlmacenesPrincipales = New Catalogo(New MetaCatalogo("ALMACENPRINCIPAL"))
        ' ''            Dim vobject As Object = ObtenGenerico(prmPlaza.Folio.ToString, atrAlmacenesPrincipalesinmemory, atrCatalogoAlmacenesPrincipales, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenAlmacen), tiempo_real)
        ' ''            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsAlmacen))
        ' ''        End Function


        ' ''        Public Shared Function ObtenAlmacen(ByVal prmrow As DataRow) As ClsAlmacen
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If

        ' ''            Dim ret As New ClsAlmacen(prmrow("nAlmacen"))
        ' ''            ret.Descripcion = prmrow("cdescripcion")
        ' ''            ret.Abreviatura = prmrow("cabreviatura")
        ' ''            ret.Cuenta = prmrow("ccuenta")
        ' ''            ret.TipoAlmacen = prmrow("ntipoalmacen")
        ' ''            ret.ManejaUbicacion = prmrow("bmanejadireccion")
        ' ''            ret.ProgramaProduccion = IfNull(prmrow("bProgramaProduccion"), False)
        ' ''            ret.EsCorporativo = prmrow("bEsCorporativo")
        ' ''            If prmrow("bEspeciales") Is DBNull.Value Then
        ' ''                ret.ManejaEspeciales = Nothing
        ' ''            Else
        ' ''                ret.ManejaEspeciales = prmrow("bEspeciales")
        ' ''            End If
        ' ''            If prmrow("nplaza") Is DBNull.Value Then
        ' ''                ret.Plaza = Nothing
        ' ''            Else
        ' ''                ret.Plaza = ObtenPlaza(CInt(prmrow("nplaza")))
        ' ''            End If
        ' ''            If prmrow("nsucursal") Is DBNull.Value Then
        ' ''                ret.Sucursal = Nothing
        ' ''            Else
        ' ''                ret.Sucursal = ObtenSucursal(CInt(prmrow("nsucursal")))
        ' ''            End If
        ' ''            ret.Pais = prmrow("cpais")
        ' ''            ret.Direccion = prmrow("cdireccion")
        ' ''            ret.Colonia = ObtenColonia(CInt(prmrow("ncolonia")))
        ' ''            ret.Involucrado = prmrow("nInvolucrado")
        ' ''            If prmrow("nresponsable") Is DBNull.Value Then
        ' ''                ret.Responsable = Nothing
        ' ''            Else
        ' ''                ret.Responsable = ObtenEmpleado(CInt(prmrow("nresponsable")))
        ' ''            End If

        ' ''            If prmrow("nalmacenvinculado") Is DBNull.Value Then
        ' ''                ret.AlmacenVinculado = Nothing
        ' ''            Else
        ' ''                ret.AlmacenVinculado = ObtenAlmacen(CInt(prmrow("nalmacenvinculado")))
        ' ''            End If

        ' ''            If prmrow("nAlmacenControlador") Is DBNull.Value Then
        ' ''                ret.AlmacenVinculado = Nothing
        ' ''            Else
        ' ''                If prmrow("nAlmacenControlador") = ret.Folio Then
        ' ''                    ret.AlmacenControlador = ret
        ' ''                Else
        ' ''                    ret.AlmacenControlador = ObtenAlmacen(CInt(prmrow("nAlmacenControlador")))
        ' ''                End If

        ' ''            End If
        ' ''            If Not prmrow("nOrdenListado") Is DBNull.Value Then
        ' ''                ret.OrdenListado = prmrow("nOrdenListado")
        ' ''            Else
        ' ''                ret.OrdenListado = 0
        ' ''            End If

        ' ''            If prmrow("nCuentaCnt") Is DBNull.Value Then
        ' ''                ret.CuentaCnt = Nothing
        ' ''            Else
        ' ''                ret.CuentaCnt = ObtenCuentaCnt(prmrow("nCuentaCnt"))
        ' ''            End If
        ' ''            ret.EsCorporativoProduccion = IfNull(prmrow("bEsCorporativoProduccion"), 0)
        ' ''            ret.Activo = prmrow("BACTIVO")
        ' ''            ret.MantenimientoEnCurso = IfNull(prmrow("bMantenimientoEncurso"), False)
        ' ''            ret.CargaDatosRegistro(prmrow)

        ' ''            Return ret

        ' ''        End Function


        ' ''        Public Shared Function ObtenAlmacen(ByRef prmrow As DataRow, ByVal PrmAlmacen As ClsAlmacen) As DataRow
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If

        ' ''            If PrmAlmacen Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If

        ' ''            prmrow("nAlmacen") = PrmAlmacen.Folio
        ' ''            prmrow("cdescripcion") = PrmAlmacen.Descripcion
        ' ''            prmrow("cabreviatura") = PrmAlmacen.Abreviatura
        ' ''            prmrow("ccuenta") = PrmAlmacen.Cuenta
        ' ''            prmrow("ntipoalmacen") = PrmAlmacen.TipoAlmacen
        ' ''            prmrow("bmanejadireccion") = PrmAlmacen.ManejaUbicacion
        ' ''            prmrow("bProgramaProduccion") = PrmAlmacen.ProgramaProduccion
        ' ''            prmrow("bEsCorporativo") = PrmAlmacen.EsCorporativo
        ' ''            prmrow("bMantenimientoEnCurso") = PrmAlmacen.MantenimientoEnCurso
        ' ''            '  If PrmAlmacen.Plaza Is Nothing Then
        ' ''            'prmrow("bEspeciales") = DBNull.Value
        ' ''            ' Else
        ' ''            prmrow("bEspeciales") = PrmAlmacen.ManejaEspeciales
        ' ''            ' End If
        ' ''            If PrmAlmacen.Plaza Is Nothing Then
        ' ''                prmrow("nplaza") = DBNull.Value
        ' ''            Else
        ' ''                prmrow("nplaza") = PrmAlmacen.Plaza.Folio
        ' ''            End If
        ' ''            If PrmAlmacen.Sucursal Is Nothing Then
        ' ''                prmrow("nsucursal") = DBNull.Value
        ' ''            Else
        ' ''                prmrow("nsucursal") = PrmAlmacen.Sucursal.Folio
        ' ''            End If

        ' ''            prmrow("cpais") = PrmAlmacen.Pais
        ' ''            prmrow("cdireccion") = PrmAlmacen.Direccion
        ' ''            prmrow("ncolonia") = PrmAlmacen.Colonia.Folio
        ' ''            prmrow("nInvolucrado") = PrmAlmacen.Involucrado
        ' ''            If PrmAlmacen.Responsable Is Nothing Then
        ' ''                prmrow("nresponsable") = DBNull.Value
        ' ''            Else
        ' ''                prmrow("nresponsable") = PrmAlmacen.Responsable.Folio
        ' ''            End If

        ' ''            If PrmAlmacen.AlmacenVinculado Is Nothing Then
        ' ''                prmrow("nalmacenvinculado") = DBNull.Value
        ' ''            Else
        ' ''                prmrow("nalmacenvinculado") = PrmAlmacen.AlmacenVinculado.Folio
        ' ''            End If
        ' ''            If PrmAlmacen.AlmacenControlador Is Nothing Then
        ' ''                prmrow("nalmacencontrolador") = DBNull.Value
        ' ''            Else
        ' ''                prmrow("nalmacencontrolador") = PrmAlmacen.AlmacenControlador.Folio
        ' ''            End If
        ' ''            prmrow("nOrdenListado") = PrmAlmacen.OrdenListado
        ' ''            prmrow("BACTIVO") = PrmAlmacen.Activo

        ' ''            If PrmAlmacen.CuentaCnt Is Nothing Then
        ' ''                prmrow("nCuentaCnt") = DBNull.Value
        ' ''            Else
        ' ''                prmrow("nCuentaCnt") = PrmAlmacen.CuentaCnt.Folio
        ' ''            End If
        ' ''            prmrow("bEsCorporativoProduccion") = PrmAlmacen.EsCorporativoProduccion

        ' ''            PrmAlmacen.LLenaDatosRegistroComun(prmrow)

        ' ''            Return prmrow

        ' ''        End Function

        ' ''        Public Shared Function ObtenSucursal(ByVal prmSucursal As Integer, Optional ByVal tiempo_real As Boolean = False) As ClsSucursal
        ' ''            If atrCatalogoSucursales Is Nothing Then atrCatalogoSucursales = New Catalogo(New MetaCatalogo("SUCURSALES"))
        ' ''            Dim vobject As Object = ObtenGenerico(prmSucursal.ToString, atrSucursalesinmemory, atrCatalogoSucursales, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenSucursal), tiempo_real)
        ' ''            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsSucursal))
        ' ''        End Function

        ' ''        Public Shared Function ObtenSucursal() As DataTable
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim dt As New DataTable

        ' ''            DAO.RegresaConsultaSQL("SELECT * FROM CTL_Sucursales (NOLOCK)", dt)

        ' ''            Return dt
        ' ''        End Function


        ' ''        Public Shared Function ObtenSucursalPorTiposInvolucrados(ByVal prmTiposInvolucrados As String) As DataTable
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim dt As New DataTable
        ' ''            Dim vSql As String = "SELECT DISTINCT VW.*,Suc.cDescripcion,INV.cNombre FROM VW_SucursalesInvolucrados VW(NOLOCK)" & vbCr
        ' ''            vSql &= "LEFT JOIN CTL_SUCURSALES SUC (NOLOCK)" & vbCr
        ' ''            vSql &= "ON VW.nSucursal = SUC.nSucursal" & vbCr
        ' ''            vSql &= "INNER JOIN CTL_INVOLUCRADOS INV (NOLOCK)" & vbCr
        ' ''            vSql &= "ON VW.nInvolucrado = INV.nInvolucrado" & vbCr

        ' ''            If Not prmTiposInvolucrados.Trim = "" Then
        ' ''                vSql &= "WHERE VW.nInvolucrado IN (" & prmTiposInvolucrados.Trim & ")" & vbCr
        ' ''            End If
        ' ''            vSql &= "ORDER BY nOrdenListado,nSucursal,VW.nInvolucrado" & vbCr

        ' ''            'Dim vSql As String = "SELECT * FROM CTL_SUCURSALES SUC (NOLOCK)" & vbCr
        ' ''            'vSql &= "INNER JOIN CTL_ALMACENES ALM (NOLOCK)" & vbCr
        ' ''            'vSql &= "ON ALM.nSucursal = SUC.nSucursal" & vbCr
        ' ''            'vSql &= "INNER JOIN CTL_INVOLUCRADOS INV (NOLOCK)" & vbCr
        ' ''            'vSql &= "ON ALM.nInvolucrado = INV.nInvolucrado" & vbCr
        ' ''            'If Not prmTiposInvolucrados.Trim = "" Then
        ' ''            '    vSql &= "WHERE INV.nTipoInvolucrado IN (" & prmTiposInvolucrados.Trim & ")" & vbCr
        ' ''            'End If
        ' ''            'vSql &= "ORDER BY SUC.nSucursal" & vbCr

        ' ''            DAO.RegresaConsultaSQL(vSql, dt)
        ' ''            Return dt
        ' ''        End Function

        ' ''        Public Shared Function ObtenSucursal(ByVal prmrow As DataRow) As ClsSucursal
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If

        ' ''            Dim ret As New ClsSucursal(prmrow("nSucursal"))
        ' ''            ret.Descripcion = prmrow("cdescripcion")
        ' ''            ret.Plaza = ObtenPlaza(CInt(prmrow("nplaza")))
        ' ''            ret.Abreviatura = prmrow("cabreviatura")

        ' ''            If prmrow("nordenlistado") IsNot DBNull.Value Then
        ' ''                ret.OrdenListado = prmrow("nordenlistado")
        ' ''            Else
        ' ''                ret.OrdenListado = 0
        ' ''            End If

        ' ''            ret.Pais = prmrow("cPais")
        ' ''            ret.Colonia = ObtenColonia(CInt(prmrow("ncolonia")))
        ' ''            ret.Direccion = prmrow("cDireccion")
        ' ''            ret.TipoSucursal = prmrow("ntiposucursal")
        ' ''            ret.ManejaAlmacen = prmrow("bmanejaalmacen")
        ' ''            ret.Telefono1 = prmrow("ctelefono1")
        ' ''            ret.Telefono2 = prmrow("ctelefono2")
        ' ''            ret.ICQ = prmrow("cicq")
        ' ''            ret.Skype = prmrow("cskype")
        ' ''            ret.Cuenta1 = prmrow("ccuenta1")
        ' ''            ret.Cuenta2 = prmrow("ccuenta2")
        ' ''            ret.Cuenta3 = prmrow("ccuenta3")
        ' ''            ret.Cuenta4 = prmrow("ccuenta4")
        ' ''            If prmrow("nsupervisor1") Is DBNull.Value Then
        ' ''                ret.Supervisor1 = Nothing
        ' ''            Else
        ' ''                ret.Supervisor1 = ObtenEmpleado(CInt(prmrow("nsupervisor1")))
        ' ''            End If
        ' ''            If prmrow("nsupervisor2") Is DBNull.Value Then
        ' ''                ret.Supervisor2 = Nothing
        ' ''            Else
        ' ''                ret.Supervisor2 = ObtenEmpleado(CInt(prmrow("nsupervisor2")))
        ' ''            End If
        ' ''            ret.Notas = prmrow("cnotas")
        ' ''            ret.Activo = prmrow("bactivo")

        ' ''            If prmrow("nCuentaCnt") Is DBNull.Value Then
        ' ''                ret.CuentaCnt = Nothing
        ' ''            Else
        ' ''                ret.CuentaCnt = ObtenCuentaCnt(prmrow("nCuentaCnt"))
        ' ''            End If

        ' ''            ret.CargaDatosRegistro(prmrow)

        ' ''            Return ret

        ' ''        End Function

        ' ''        Public Shared Function ObtenSucursal(ByRef prmrow As DataRow, ByVal prmSucursal As ClsSucursal) As DataRow
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If

        ' ''            If prmSucursal Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If


        ' ''            prmrow("nSucursal") = prmSucursal.Folio
        ' ''            prmrow("cdescripcion") = prmSucursal.Descripcion
        ' ''            prmrow("nplaza") = prmSucursal.Plaza.Folio
        ' ''            prmrow("cabreviatura") = prmSucursal.Abreviatura
        ' ''            prmrow("nordenlistado") = prmSucursal.OrdenListado
        ' ''            prmrow("cPais") = prmSucursal.Pais
        ' ''            prmrow("ncolonia") = prmSucursal.Colonia.Folio
        ' ''            prmrow("cDireccion") = prmSucursal.Direccion
        ' ''            prmrow("ntiposucursal") = prmSucursal.TipoSucursal
        ' ''            prmrow("bmanejaalmacen") = prmSucursal.ManejaAlmacen
        ' ''            prmrow("ctelefono1") = prmSucursal.Telefono1
        ' ''            prmrow("ctelefono2") = prmSucursal.Telefono2
        ' ''            prmrow("cicq") = prmSucursal.ICQ
        ' ''            prmrow("cskype") = prmSucursal.Skype
        ' ''            prmrow("ccuenta1") = prmSucursal.Cuenta1
        ' ''            prmrow("ccuenta2") = prmSucursal.Cuenta2
        ' ''            prmrow("ccuenta3") = prmSucursal.Cuenta3
        ' ''            prmrow("ccuenta4") = prmSucursal.Cuenta4
        ' ''            If prmSucursal.Supervisor1 Is Nothing Then
        ' ''                prmrow("nsupervisor1") = DBNull.Value
        ' ''            Else
        ' ''                prmrow("nsupervisor1") = prmSucursal.Supervisor1.Folio
        ' ''            End If
        ' ''            If prmSucursal.Supervisor2 Is Nothing Then
        ' ''                prmrow("nsupervisor2") = DBNull.Value
        ' ''            Else
        ' ''                prmrow("nsupervisor2") = prmSucursal.Supervisor2.Folio
        ' ''            End If

        ' ''            If prmSucursal.CuentaCnt Is Nothing Then
        ' ''                prmrow("nCuentaCnt") = DBNull.Value
        ' ''            Else
        ' ''                prmrow("nCuentaCnt") = prmSucursal.CuentaCnt.Folio
        ' ''            End If

        ' ''            prmrow("cnotas") = prmSucursal.Notas

        ' ''            prmrow("bactivo") = prmSucursal.Activo

        ' ''            prmSucursal.LLenaDatosRegistroComun(prmrow)

        ' ''            Return prmrow

        ' ''        End Function


        Public Shared Function ObtenMoneda(ByVal prmMoneda As Integer, Optional ByVal tiempo_real As Boolean = False) As ClsMoneda
            If atrCatalogoMonedas Is Nothing Then atrCatalogoMonedas = New Catalogo(New MetaCatalogo("MONEDAS"))
            Dim vobject As Object = ObtenGenerico(prmMoneda.ToString, atrMonedasinmemory, atrCatalogoMonedas, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenMoneda), tiempo_real)
            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsMoneda))
        End Function


        Public Shared Function ObtenMoneda(ByVal prmClaveMoneda As String) As ClsMoneda

            Dim vcSQL As String
            Dim DT As New DataTable
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia

            vcSQL = "SELECT * FROM CTL_MONEDAS(NOLOCK) WHERE CCVE_MONEDA = '" & prmClaveMoneda & "'"

            DAO.RegresaConsultaSQL(vcSQL, DT)



            If Not DT Is Nothing AndAlso DT.Rows.Count > 0 Then

                Dim prmrow As DataRow

                prmrow = DT.Rows(0)

                Dim ret As New ClsMoneda()

                ret.Nombre = prmrow("CNOMBRE")
                ret.Nomenclatura = prmrow("CNOMENCLATURA")
                ret.AbreviaXml = prmrow("CABREVIAXML")
                ret.CveMoneda = prmrow("CCVE_MONEDA")

                Return ret

            Else
                Return Nothing
            End If


        End Function

        Public Shared Function ObtenMoneda(ByVal prmrow As DataRow) As ClsMoneda
            If prmrow Is Nothing Then
                Return Nothing
            End If

            Dim ret As New ClsMoneda(prmrow("nMoneda"))
            ret.Descripcion = prmrow("cdescripcion")
            ret.Signo = prmrow("cSigno")
            ret.MonedaBase = prmrow("bbase")
            ret.Activo = prmrow("bactivo")

            ret.CargaDatosRegistro(prmrow)

            Return ret

        End Function

        Public Shared Function ObtenMoneda(ByRef prmrow As DataRow, ByVal prmobj As ClsMoneda) As DataRow
            If prmrow Is Nothing Then
                Return Nothing
            End If
            If prmobj Is Nothing Then
                Return Nothing
            End If

            prmrow("nMoneda") = prmobj.Folio
            prmrow("cdescripcion") = prmobj.Descripcion
            prmrow("cSigno") = prmobj.Signo
            prmrow("bbase") = prmobj.MonedaBase
            prmrow("bactivo") = prmobj.Activo
            prmobj.LLenaDatosRegistroComun(prmrow)


            Return prmrow
        End Function

        ' ''        Public Shared Function ObtenContenedorProveedoresProntosPagos(ByVal prmProveedor As Integer) As DataTable 'ByVal prmProveedorProntoPago As Proveedores.ClsProveedorProntosPagos) As DataTable
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim dt As New DataTable
        ' ''            Dim vlsql As String

        ' ''            vlsql = "SELECT * FROM CTL_ProveedoresProntosPagos(NOLOCK) WHERE " & vbCr
        ' ''            'vlsql &= "WHERE nProntoPago = " & prmProveedorProntoPago.Folio & vbCr
        ' ''            'vlsql &= "AND nProveedor= " & prmProveedorProntoPago.Proveedor

        ' ''            DAO.RegresaEsquemaDeDatos(vlsql & " 1=0", dt)
        ' ''            DAO.RegresaConsultaSQL(vlsql & " nproveedor=" & prmProveedor, dt)

        ' ''            Return dt
        ' ''        End Function


        ' ''        Public Shared Function ExisteAlmacenPrincipal(ByVal prmPlaza As Integer,Optional ByVal prmAlmacen As String="") As Boolean
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            If prmAlmacen = "" Then
        ' ''                If DAO.RegresaDatoSQL("SELECT count(*) FROM CTL_Almacenes (NOLOCK) WHERE nTipoAlmacen=dbo.ADSUM_ParametroAdministrado_Numerico('TIPOALMACEN_ALMACENPRINCIPAL') and bActivo=1 and nPlaza=" & prmPlaza) = 1 Then
        ' ''                    Return True
        ' ''                End If
        ' ''            Else
        ' ''                If DAO.RegresaDatoSQL("SELECT count(*) FROM CTL_Almacenes (NOLOCK) WHERE nTipoAlmacen=dbo.ADSUM_ParametroAdministrado_Numerico('TIPOALMACEN_ALMACENPRINCIPAL') and bActivo=1 and nPlaza=" & prmPlaza & " and not nAlmacen=" & prmAlmacen.Trim) = 1 Then
        ' ''                    Return True
        ' ''                End If
        ' ''            End If
        ' ''            Return False
        ' ''        End Function

        ' ''        Public Shared Function AlmacenConMovimientos(ByVal prmAlmacen As Integer) As Boolean
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            If DAO.RegresaDatoSQL("select count(*) from INV_MovimientosAlmacen (nolock) where nAlmacenRegistro =" & prmAlmacen & " or nAlmacenMovimiento=" & prmAlmacen) > 0 Then
        ' ''                Return True
        ' ''            End If
        ' ''            Return False
        ' ''        End Function

        ' ''        Public Shared Function ObtenAlmacenes_Prod_Dis_Suc(ByVal prmPlaza As Integer) As String
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim vlsql As String
        ' ''            Dim DtRes As New DataTable
        ' ''            Dim vRes As String = ""

        ' ''            vlsql = "SELECT * FROM CTL_ALMACENES(NOLOCK)" & vbCr
        ' ''            vlsql &= "WHERE nTipoAlmacen IN (dbo.ADSUM_ParametroAdministrado_Numerico('TIPOALMACEN_ALMACENDISTRIBUCION'),dbo.ADSUM_ParametroAdministrado_Numerico('TIPOALMACEN_ALMACENPRODUCCION')" & vbCr
        ' ''            vlsql &= ",dbo.ADSUM_ParametroAdministrado_Numerico('TIPOALMACEN_ALMACENSUCURSAL'))" & vbCr
        ' ''            vlsql &= "AND nPlaza=" & prmPlaza.ToString
        ' ''            vlsql &= "and bEspeciales is null or bEspeciales=0"

        ' ''            If Not DAO.RegresaConsultaSQL(vlsql, DtRes) Then
        ' ''                Return ""
        ' ''            End If

        ' ''            If DtRes.Rows.Count > 0 Then
        ' ''                For Each vRow As DataRow In DtRes.Rows
        ' ''                    vRes &= vRow("nAlmacen") & ","
        ' ''                Next
        ' ''            End If

        ' ''            Return vRes.Substring(0, vRes.Length - 1)

        ' ''        End Function
        ' ''        Public Shared Function ObtenAlmacenesParaCrearSemaforos() As DataTable
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim vlsql As String
        ' ''            Dim DtRes As New DataTable

        ' ''            vlsql = "SELECT nAlmacen FROM CTL_ALMACENES(NOLOCK) "

        ' ''            If Not DAO.RegresaConsultaSQL(vlsql, DtRes) Then
        ' ''                Return Nothing
        ' ''            End If

        ' ''            Return DtRes
        ' ''        End Function
        ' ''        Public Shared Function ObtenCuentasContablesHijos(ByVal prmCuentaPadre As Long) As ClsCuentaCnt()
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim DT_Cuentas As New DataTable
        ' ''            Dim vCuentas() As Dominio.Catalogos.Contabilidad.ClsCuentaCnt
        ' ''            Dim DRow As Data.DataRow, vIndice As Integer
        ' ''            DAO.RegresaConsultaSQL("SELECT nCuentaCnt FROM CNT_Cuentas (NoLock) WHERE nNivelPadre = " & prmCuentaPadre, DT_Cuentas)
        ' ''            If DT_Cuentas Is Nothing OrElse DT_Cuentas.Rows.Count = 0 Then
        ' ''                Return Nothing
        ' ''            Else
        ' ''                ReDim vCuentas(DT_Cuentas.Rows.Count - 1)
        ' ''                vIndice = 0
        ' ''                For Each DRow In DT_Cuentas.Rows
        ' ''                    vCuentas(vIndice) = ObtenCuentaCnt(DRow("nCuentaCnt"))
        ' ''                    vIndice += 1
        ' ''                Next DRow
        ' ''                Return vCuentas
        ' ''            End If
        ' ''        End Function
        ' ''        Public Shared Function ObtenFlujoEfectivo(ByVal prmFlujo As Integer, Optional ByVal tiempo_real As Boolean = False, Optional ByVal prmFlujoHijo As Boolean = False) As ClsFlujoEfectivo
        ' ''            If prmFlujoHijo Then
        ' ''                atrCatalogoFlujosEfectivo = New Catalogo(New MetaCatalogo("FLUJOSEFECTIVO_HIJO"))
        ' ''            Else
        ' ''                atrCatalogoFlujosEfectivo = New Catalogo(New MetaCatalogo("FLUJOSEFECTIVO"))
        ' ''            End If

        ' ''            Dim vobject As Object = ObtenGenerico(prmFlujo.ToString, atrFlujosEfectivoinmemory, atrCatalogoFlujosEfectivo, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenFlujoEfectivo), tiempo_real)
        ' ''            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsFlujoEfectivo))
        ' ''            Return New ClsFlujoEfectivo
        ' ''        End Function

        ' ''        Public Shared Function ObtenFlujosEfectivoHijos(ByVal prmFlujoPadre As Integer) As ClsFlujoEfectivo()
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim dtFlujoEfectivo As New DataTable
        ' ''            Dim vFlujosHijos() As Dominio.Catalogos.Bancos.ClsFlujoEfectivo
        ' ''            Dim DRow As Data.DataRow, vIndice As Integer
        ' ''            DAO.RegresaConsultaSQL("Select * From CTL_FlujosEfectivo (NoLock) where nFlujoPadre = " & prmFlujoPadre, dtFlujoEfectivo)
        ' ''            If dtFlujoEfectivo.Rows.Count = 0 Then
        ' ''                Return Nothing
        ' ''            Else
        ' ''                ReDim vFlujosHijos(dtFlujoEfectivo.Rows.Count - 1)
        ' ''                vIndice = 0
        ' ''                For Each DRow In dtFlujoEfectivo.Rows
        ' ''                    vFlujosHijos(vIndice) = ObtenFlujoEfectivo(DRow)
        ' ''                    vIndice += 1
        ' ''                Next DRow
        ' ''                Return vFlujosHijos
        ' ''            End If
        ' ''        End Function

        ' ''        Public Shared Function ObtenQueryFlujosEfectivoHijos(ByVal prmFlujoPadre As Integer, ByVal prmEfecto As String, Optional ByVal prmMasivo As Boolean = False) As String
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim dtFlujoEfectivo As New DataTable
        ' ''            Dim dtFlujoEfectivoHijo As New DataTable
        ' ''            Dim vFlujosHijos() As Dominio.Catalogos.Bancos.ClsFlujoEfectivo
        ' ''            Dim DRow As Data.DataRow, vIndice As Integer
        ' ''            Dim vcQueryRegresa As String = ""

        ' ''            vcQueryRegresa = "Update CTL_FlujosEfectivo Set cTipoFlujo = '" & prmEfecto & "'"
        ' ''            vcQueryRegresa += vbCrLf & "Where nFlujo In ("
        ' ''            DAO.RegresaConsultaSQL("Select * From CTL_FlujosEfectivo (NoLock) where nFlujoPadre = " & prmFlujoPadre, dtFlujoEfectivo)
        ' ''            If Not dtFlujoEfectivo Is Nothing Then
        ' ''                If dtFlujoEfectivo.Rows.Count = 0 Then
        ' ''                    Return ""
        ' ''                Else
        ' ''                    For Each DRow In dtFlujoEfectivo.Rows
        ' ''                        vcQueryRegresa += DRow("nFlujo") & ","
        ' ''                        If prmMasivo Then
        ' ''                            DAO.RegresaConsultaSQL("Select * From CTL_FlujosEfectivo (NoLock) where nFlujoPadre = " & DRow("nFlujo"), dtFlujoEfectivoHijo)
        ' ''                            If Not dtFlujoEfectivoHijo Is Nothing Then
        ' ''                                For Each DRow2 In dtFlujoEfectivoHijo.Rows
        ' ''                                    vcQueryRegresa += DRow2("nFlujo") & ","
        ' ''                                Next DRow2
        ' ''                            End If
        ' ''                        End If
        ' ''                    Next DRow
        ' ''                    vcQueryRegresa = Mid(vcQueryRegresa, 1, vcQueryRegresa.Length - 1) & ")"
        ' ''                    Return vcQueryRegresa
        ' ''                End If
        ' ''            End If
        ' ''        End Function

        ' ''        Public Shared Function ObtenFlujoEfectivo(ByVal prmFlujoEfectivo As String, Optional ByVal prmFlujoPadre As Integer = 0, Optional ByVal prmValidaPadre As Boolean = False, Optional ByVal prmFiltro As String = "") As ClsFlujoEfectivo
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim dtFlujoEfectivo As New DataTable
        ' ''            Dim vSQL As String
        ' ''            vSQL = "Select * From CTL_FlujosEfectivo (NoLock) Where cNivel = '" & prmFlujoEfectivo & "' " & vbCr

        ' ''            If prmValidaPadre Then
        ' ''                vSQL &= " And nFlujoPadre Is Null " & vbCr
        ' ''            Else
        ' ''                If prmFlujoPadre > 0 Then
        ' ''                    vSQL &= " And nFlujoPadre = " & prmFlujoPadre & " " & vbCr
        ' ''                End If
        ' ''            End If

        ' ''            If Not prmFiltro.Trim = "" Then
        ' ''                vSQL &= " AND " & prmFiltro
        ' ''            End If

        ' ''            DAO.RegresaConsultaSQL(vSQL, dtFlujoEfectivo)
        ' ''            If dtFlujoEfectivo.Rows.Count = 0 Then
        ' ''                Return Nothing
        ' ''            Else
        ' ''                Return ObtenFlujoEfectivo(dtFlujoEfectivo.Rows(0))
        ' ''            End If
        ' ''        End Function

        ' ''        Public Shared Function ObtenFlujoEfectivoPadre(ByVal prmFlujoPadre As Integer) As ClsFlujoEfectivo
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim dtFlujoEfectivo As New DataTable
        ' ''            DAO.RegresaConsultaSQL("Select * From CTL_FlujosEfectivo (NoLock) Where nFlujo = " & prmFlujoPadre, dtFlujoEfectivo)
        ' ''            If dtFlujoEfectivo.Rows.Count = 0 Then
        ' ''                Return Nothing
        ' ''            Else
        ' ''                Return ObtenFlujoEfectivo(dtFlujoEfectivo.Rows(0))
        ' ''            End If
        ' ''        End Function

        ' ''        Public Shared Function ObtenFlujoEfectivo(ByVal prmrow As DataRow) As ClsFlujoEfectivo
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If

        ' ''            Dim ret As New ClsFlujoEfectivo(prmrow("nFlujo"))
        ' ''            ret.Descripcion = prmrow("cDescripcion")
        ' ''            ret.Nivel = prmrow("cNivel")
        ' ''            ret.FlujoPadre = ObtenFlujoEfectivoPadre(IIf(prmrow("nFlujoPadre") Is DBNull.Value, 0, prmrow("nFlujoPadre")))
        ' ''            ret.TipoFlujo = prmrow("cTipoFlujo")
        ' ''            ret.AceptaMovimientos = prmrow("bAceptaMovimientos")
        ' ''            ret.Activo = prmrow("bactivo")

        ' ''            ret.CargaDatosRegistro(prmrow)

        ' ''            Return ret

        ' ''        End Function

        ' ''        Public Shared Function ObtenFlujoEfectivo(ByRef prmRow As DataRow, ByVal prmFlujoEfectivo As Object) As DataRow
        ' ''            If prmRow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            If prmFlujoEfectivo Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            Dim vrmFlujo As ClsFlujoEfectivo = CType(prmFlujoEfectivo, ClsFlujoEfectivo)
        ' ''            Dim vlFolio As Integer
        ' ''            prmRow("nFlujo") = prmFlujoEfectivo.Folio
        ' ''            prmRow("cDescripcion") = prmFlujoEfectivo.Descripcion
        ' ''            prmRow("cNivel") = vrmFlujo.Nivel

        ' ''            If vrmFlujo.FlujoPadre Is Nothing Then
        ' ''                vlFolio = 0
        ' ''            Else
        ' ''                vlFolio = vrmFlujo.FlujoPadre.Folio
        ' ''            End If

        ' ''            prmRow("nFlujoPadre") = IIf(vlFolio = 0, DBNull.Value, vlFolio)
        ' ''            prmRow("cTipoFlujo") = vrmFlujo.TipoFlujo
        ' ''            prmRow("bAceptaMovimientos") = vrmFlujo.AceptaMovimientos
        ' ''            prmRow("bActivo") = prmFlujoEfectivo.Activo
        ' ''            prmFlujoEfectivo.LLenaDatosRegistroComun(prmRow)

        ' ''            Return prmRow
        ' ''        End Function

        ' ''        Public Shared Function ObtenBeneficiario(ByVal prmBeneficiario As Integer, Optional ByVal tiempo_real As Boolean = False) As ClsBeneficiario
        ' ''            If atrCatalogoBeneficiarios Is Nothing Then atrCatalogoBeneficiarios = New Catalogo(New MetaCatalogo("CTL_Beneficiarios"))
        ' ''            Dim vobject As Object = ObtenGenerico(prmBeneficiario.ToString, atrBeneficiariosinmemory, atrCatalogoBeneficiarios, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenBeneficiario), tiempo_real)
        ' ''            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsBeneficiario))
        ' ''        End Function

        ' ''        Public Shared Function ObtenBeneficiario(Optional ByVal bActivo As Boolean = True) As DataTable
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim dt As New DataTable
        ' ''            Dim vSql As String = "SELECT * FROM CTL_Beneficiarios (NOLOCK)" & vbCr

        ' ''            If bActivo = True Then
        ' ''                vSql &= "WHERE bActivo = 1" & vbCr
        ' ''            Else
        ' ''                vSql &= "WHERE bActivo = 0" & vbCr
        ' ''            End If

        ' ''            DAO.RegresaConsultaSQL(vSql, dt)

        ' ''            Return dt

        ' ''        End Function

        ' ''        Public Shared Function ObtenBeneficiario(ByVal prmrow As DataRow) As ClsBeneficiario
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If

        ' ''            Dim ret As New ClsBeneficiario()
        ' ''            ret.Folio = prmrow("nBeneficiario")
        ' ''            ret.Descripcion = prmrow("cDescripcion")
        ' ''            ret.Activo = prmrow("bActivo")

        ' ''            ret.CargaDatosRegistro(prmrow)

        ' ''            Return ret

        ' ''        End Function

        ' ''        Public Shared Function ObtenBeneficiario(ByRef prmrow As DataRow, ByVal prmobj As ClsBeneficiario) As DataRow
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            If prmobj Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            prmrow("nBeneficiario") = prmobj.Folio
        ' ''            prmrow("cDescripcion") = prmobj.Descripcion
        ' ''            prmrow("bActivo") = prmobj.Activo

        ' ''            prmobj.LLenaDatosRegistroComun(prmrow)

        ' ''            Return prmrow

        ' ''        End Function

        ' ''        Public Shared Function ObtenProveedorBancos(ByVal prmProveedor As Integer, Optional ByVal tiempo_real As Boolean = False) As ClsProveedoresBancos
        ' ''            If atrCatalogoProveedoresBancos Is Nothing Then atrCatalogoProveedoresBancos = New Catalogo(New MetaCatalogo("CTL_ProveedoresBancos"))
        ' ''            Dim vobject As Object = ObtenGenerico(prmProveedor.ToString, atrProveedoresinmemory, atrCatalogoProveedoresBancos, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenProveedorBancos), tiempo_real)
        ' ''            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsProveedoresBancos))
        ' ''        End Function

        ' ''        Public Shared Function ObtenProveedorBancos(Optional ByVal bActivo As Boolean = True) As DataTable
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim dt As New DataTable
        ' ''            Dim vSql As String = "SELECT * FROM CTL_Proveedores (NOLOCK)" & vbCr

        ' ''            If bActivo = True Then
        ' ''                vSql &= "WHERE bActivo = 1" & vbCr
        ' ''            Else
        ' ''                vSql &= "WHERE bActivo = 0" & vbCr
        ' ''            End If

        ' ''            DAO.RegresaConsultaSQL(vSql, dt)

        ' ''            Return dt

        ' ''        End Function

        ' ''        Public Shared Function ObtenProveedorBancos(ByVal prmrow As DataRow) As ClsProveedoresBancos
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If

        ' ''            Dim ret As New ClsProveedoresBancos()
        ' ''            ret.Folio = prmrow("nProveedor")
        ' ''            ret.NombreFiscal = prmrow("cNombreFiscal")
        ' ''            ret.NombreComercial = prmrow("cNombreComercial")
        ' ''            ret.RFC = prmrow("cRFC")

        ' ''            If prmrow("nPlazaRegistro") Is DBNull.Value Then
        ' ''                ret.PlazaRegistro = Nothing
        ' ''            Else
        ' ''                ret.PlazaRegistro = ObtenPlaza(prmrow("nPlazaRegistro"))
        ' ''            End If
        ' ''            ret.PolizaAcumulada = IfNull(prmrow("bPolizaAcumulada"), False)
        ' ''            ret.Activo = prmrow("bActivo")

        ' ''            ret.CargaDatosRegistro(prmrow)

        ' ''            Return ret

        ' ''        End Function

        ' ''        Public Shared Function ObtenProveedorBancos(ByRef prmrow As DataRow, ByVal prmobj As ClsProveedoresBancos) As DataRow
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            If prmobj Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            prmrow("nProveedor") = prmobj.Folio
        ' ''            prmrow("cNombreFiscal") = prmobj.NombreFiscal
        ' ''            prmrow("cNombreComercial") = prmobj.NombreComercial
        ' ''            prmrow("cRFC") = prmobj.RFC

        ' ''            If prmobj.PlazaRegistro Is Nothing Then
        ' ''                prmrow("nPlazaRegistro") = DBNull.Value
        ' ''            Else
        ' ''                prmrow("nPlazaRegistro") = prmobj.PlazaRegistro.Folio
        ' ''            End If
        ' ''            prmrow("bPolizaAcumulada") = prmobj.PolizaAcumulada
        ' ''            prmrow("bActivo") = prmobj.Activo

        ' ''            prmobj.LLenaDatosRegistroComun(prmrow)

        ' ''            Return prmrow

        ' ''        End Function


        ' ''        Public Shared Function ObtenSolicitante(ByVal prmSolicitante As Integer, Optional ByVal tiempo_real As Boolean = False) As ClsSolicitante
        ' ''            If atrCatalogoSolicitante Is Nothing Then atrCatalogoSolicitante = New Catalogo(New MetaCatalogo("CTL_Solicitantes"))
        ' ''            Dim vobject As Object = ObtenGenerico(prmSolicitante.ToString, atrSolicitantesinmemory, atrCatalogoSolicitante, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenSolicitante), tiempo_real)
        ' ''            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsSolicitante))
        ' ''        End Function

        ' ''        Public Shared Function ObtenSolicitante(Optional ByVal bActivo As Boolean = True) As DataTable
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim dt As New DataTable
        ' ''            Dim vSql As String = "SELECT * FROM CTL_Solicitantes (NOLOCK)" & vbCr

        ' ''            If bActivo = True Then
        ' ''                vSql &= "WHERE bActivo = 1" & vbCr
        ' ''            Else
        ' ''                vSql &= "WHERE bActivo = 0" & vbCr
        ' ''            End If

        ' ''            DAO.RegresaConsultaSQL(vSql, dt)

        ' ''            Return dt

        ' ''        End Function

        ' ''        Public Shared Function ObtenSolicitante(ByVal prmrow As DataRow) As ClsSolicitante
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If

        ' ''            Dim ret As New ClsSolicitante(prmrow("nSolicitante"))
        ' ''            ret.Descripcion = prmrow("cDescripcion")
        ' ''            ret.Activo = prmrow("bActivo")

        ' ''            ret.CargaDatosRegistro(prmrow)

        ' ''            Return ret

        ' ''        End Function

        ' ''        Public Shared Function ObtenSolicitante(ByRef prmrow As DataRow, ByVal prmobj As ClsSolicitante) As DataRow
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            If prmobj Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            prmrow("nSolicitante") = prmobj.Folio
        ' ''            prmrow("cDescripcion") = prmobj.Descripcion
        ' ''            prmrow("bActivo") = prmobj.Activo

        ' ''            prmobj.LLenaDatosRegistroComun(prmrow)

        ' ''            Return prmrow

        ' ''        End Function

        ' ''        Public Shared Function ObtenProyecto(ByVal prmProyecto As Integer, Optional ByVal tiempo_real As Boolean = False) As ClsProyecto
        ' ''            If atrCatalogoProyectos Is Nothing Then atrCatalogoProyectos = New Catalogo(New MetaCatalogo("PROYECTOS"))
        ' ''            Dim vobject As Object = ObtenGenerico(prmProyecto.ToString, atrProyectosinmemory, atrCatalogoProyectos, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenProyecto), tiempo_real)
        ' ''            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsProyecto))
        ' ''        End Function

        ' ''        Public Shared Function ObtenProyecto(Optional ByVal bActivo As Boolean = True) As DataTable
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim dt As New DataTable
        ' ''            Dim vSql As String = "SELECT * FROM CTL_Proyectos (NOLOCK)" & vbCr

        ' ''            If bActivo = True Then
        ' ''                vSql &= "WHERE bActivo = 1" & vbCr
        ' ''            Else
        ' ''                vSql &= "WHERE bActivo = 0" & vbCr
        ' ''            End If

        ' ''            DAO.RegresaConsultaSQL(vSql, dt)

        ' ''            Return dt

        ' ''        End Function

        ' ''        Public Shared Function ObtenProyecto(ByVal prmrow As DataRow) As ClsProyecto
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If

        ' ''            Dim ret As New ClsProyecto()
        ' ''            ret.Folio = prmrow("nProyecto")
        ' ''            ret.Plaza = ObtenPlaza(prmrow("nPlaza"))
        ' ''            ret.Descripcion = prmrow("cDescripcion")
        ' ''            ret.bConVigencia = prmrow("bConVigencia")
        ' ''            ret.dFechaInicial = prmrow("dFechaInicial")
        ' ''            ret.dFechaFinal = prmrow("dFechaFinal")
        ' ''            If prmrow("dFechaAplicacion") Is DBNull.Value Then
        ' ''                ret.FechaAplicacion = "1900-01-01"
        ' ''            Else
        ' ''                ret.FechaAplicacion = prmrow("dFechaAplicacion")
        ' ''            End If

        ' ''            ret.Presupuesto = prmrow("nPresupuesto")
        ' ''            ret.Activo = prmrow("bActivo")
        ' ''            ret.Encargado = prmrow("cEncargado")
        ' ''            ret.CargaDatosRegistro(prmrow)

        ' ''            If prmrow("nNivel1") Is DBNull.Value Then
        ' ''                ret.Nivel1 = Nothing
        ' ''            Else
        ' ''                ret.Nivel1 = ObtenFlujoEfectivo(prmrow("nNivel1"))
        ' ''            End If

        ' ''            If prmrow("nNivel2") Is DBNull.Value Then
        ' ''                ret.Nivel2 = Nothing
        ' ''            Else
        ' ''                ret.Nivel2 = ObtenFlujoEfectivo(prmrow("nNivel2"), , True)
        ' ''            End If

        ' ''            Return ret

        ' ''        End Function

        ' ''        Public Shared Function ObtenProyecto(ByRef prmrow As DataRow, ByVal prmobj As ClsProyecto) As DataRow
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            If prmobj Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            prmrow("nProyecto") = prmobj.Folio
        ' ''            prmrow("nPlaza") = prmobj.Plaza.Folio
        ' ''            prmrow("cDescripcion") = prmobj.Descripcion
        ' ''            prmrow("bConVigencia") = prmobj.bConVigencia
        ' ''            prmrow("dFechaInicial") = prmobj.dFechaInicial
        ' ''            prmrow("dFechaFinal") = prmobj.dFechaFinal
        ' ''            If prmobj.FechaAplicacion = "1900-01-01" Then
        ' ''                prmrow("dFechaAplicacion") = DBNull.Value
        ' ''            Else
        ' ''                prmrow("dFechaAplicacion") = prmobj.FechaAplicacion
        ' ''            End If

        ' ''            prmrow("nPresupuesto") = prmobj.Presupuesto
        ' ''            prmrow("bActivo") = prmobj.Activo
        ' ''            prmrow("cEncargado") = prmobj.Encargado

        ' ''            If prmobj.Nivel1 Is Nothing Then
        ' ''                prmrow("nNivel1") = DBNull.Value
        ' ''            Else
        ' ''                prmrow("nNivel1") = prmobj.Nivel1.Folio
        ' ''            End If

        ' ''            If prmobj.Nivel2 Is Nothing Then
        ' ''                prmrow("nNivel2") = DBNull.Value
        ' ''            Else
        ' ''                prmrow("nNivel2") = prmobj.Nivel2.Folio
        ' ''            End If

        ' ''            prmobj.LLenaDatosRegistroComun(prmrow)

        ' ''            Return prmrow

        ' ''        End Function


        ' ''        Public Shared Sub PgLlenaComboXtraGrid_TiposDatos(ByVal prmLlave As String, ByRef prmCombo As DevExpress.XtraEditors.Repository.RepositoryItemComboBox, Optional ByVal prmAgregarElementoSeleccione As Boolean = True)
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim Vlsql As String
        ' ''            Dim dt As New DataTable
        ' ''            Vlsql = "SELECT nTipoDato, cLlave, cValor,nValor" & vbCr
        ' ''            Vlsql &= "FROM ADSUM_TiposDatos(NOLOCK)" & vbCr
        ' ''            Vlsql &= "WHERE cLlave='" & prmLlave.Trim & "'"
        ' ''            DAO.RegresaConsultaSQL(Vlsql, dt)

        ' ''            prmCombo.Items.Clear()
        ' ''            Dim ObjSeleccione As New Dominio.Comun.ClsTiposDatos(0)
        ' ''            ObjSeleccione.Descripcion = "<<SELECCIONE>>"

        ' ''            If prmAgregarElementoSeleccione Then
        ' ''                prmCombo.Items.Add(ObjSeleccione)
        ' ''            End If

        ' ''            Dim Obj As Dominio.Comun.ClsTiposDatos
        ' ''            For Each dr As DataRow In dt.Rows
        ' ''                Obj = New Comun.ClsTiposDatos(dr("nTipoDato"))
        ' ''                Obj.Llave = dr("cLlave")
        ' ''                Obj.Descripcion = dr("cValor")
        ' ''                Obj.ValorDescripcion = dr("cValor")
        ' ''                Obj.Valor = dr("nValor")
        ' ''                Obj.TipoDato = dr("nTipoDato")
        ' ''                prmCombo.Items.Add(Obj)
        ' ''            Next

        ' ''        End Sub

        ' ''        Public Shared Function ObtenerEmpleadoTipoArticulo(ByVal prmEmpleado As ClsEmpleado) As DataTable
        ' ''            If prmEmpleado Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If

        ' ''            If prmEmpleado.TipoArticulo.ToString.Trim = "" Then
        ' ''                Return Nothing
        ' ''            End If

        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''            Dim Vlsql As String = ""
        ' ''            Dim objTipoArticulo As New ClsTipoArticulo            

        ' ''            Vlsql = "SELECT TA.*" & vbCr
        ' ''            Vlsql &= "FROM CTL_TiposArticulos TA(NOLOCK)" & vbCr
        ' ''            If Not prmEmpleado.TipoArticulo.ToString.Trim = "*" Then
        ' ''                Vlsql &= "WHERE nTipoArticulo in(" & prmEmpleado.TipoArticulo.ToString.Trim & ")"
        ' ''            End If

        ' ''            Dim dt As New DataTable
        ' ''            DAO.RegresaConsultaSQL(Vlsql, dt)
        ' ''            If dt.Rows.Count = 0 Then
        ' ''                Return Nothing
        ' ''            End If

        ' ''            Return dt
        ' ''        End Function

        ' ''        Public Shared Function ObtenerTipoArticulo(ByVal prmrow As DataRow) As Dominio.Catalogos.ClsTipoArticulo
        ' ''            If prmrow Is Nothing Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            Dim ret As New Dominio.Catalogos.ClsTipoArticulo

        ' ''            'ret.TipoDato = prmrow("nTipoDato")
        ' ''            'ret.Llave = prmrow("cLlave")
        ' ''            'ret.ValorDescripcion = prmrow("cValor")
        ' ''            'ret.Valor = prmrow("nValor")

        ' ''            Return ret
        ' ''        End Function

        ' ''        Public Shared Function ObtenerTipoDato(ByVal prmLlave As String, ByVal prmnValor As Integer) As Dominio.Comun.ClsTiposDatos
        ' ''            If prmLlave = "" Then
        ' ''                Return Nothing
        ' ''            End If
        ' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim Vlsql As String = ""
' ''            Vlsql = "SELECT nTipoDato, cLlave, cValor,nValor" & vbCr
' ''            Vlsql &= "FROM ADSUM_TiposDatos(NOLOCK)" & vbCr
' ''            Vlsql &= "WHERE cLlave='" & prmLlave.Trim & "' AND nValor = " & prmnValor

' ''            Dim dt As New DataTable
' ''            DAO.RegresaConsultaSQL(Vlsql, dt)
' ''            If dt.Rows.Count = 0 Then
' ''                Return Nothing
' ''            Else
' ''                Return ObtenerTipoDato(dt.Rows(0))
' ''            End If
' ''        End Function

' ''        Public Shared Function ObtenerTipoDato(ByVal prmrow As DataRow) As Dominio.Comun.ClsTiposDatos
' ''            If prmrow Is Nothing Then
' ''                Return Nothing
' ''            End If
' ''            Dim ret As New Dominio.Comun.ClsTiposDatos()
' ''            ret.TipoDato = prmrow("nTipoDato")
' ''            ret.Llave = prmrow("cLlave")
' ''            ret.ValorDescripcion = prmrow("cValor")
' ''            ret.Valor = prmrow("nValor")
' ''            Return ret
' ''        End Function

' ''        Public Shared Function ObtenConceptoCxp(ByVal prmConcepto As Integer, Optional ByVal tiempo_real As Boolean = False) As ClsConceptosCxp
' ''            If atrCatalogoConceptosCxp Is Nothing Then atrCatalogoConceptosCxp = New Catalogo(New MetaCatalogo("CXP_TiposMovimientos"))
' ''            Dim vobject As Object = ObtenGenerico(prmConcepto.ToString, atrBeneficiariosinmemory, atrCatalogoConceptosCxp, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenConceptoCxp), tiempo_real)
' ''            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsConceptosCxp))
' ''        End Function

' ''        Public Shared Function ObtenConceptoCxp(Optional ByVal bActivo As Boolean = True) As DataTable
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim dt As New DataTable
' ''            Dim vSql As String = "SELECT * FROM CXP_TiposMovimientos (NOLOCK)" & vbCr

' ''            If bActivo = True Then
' ''                vSql &= "WHERE bActivo = 1" & vbCr
' ''            Else
' ''                vSql &= "WHERE bActivo = 0" & vbCr
' ''            End If

' ''            DAO.RegresaConsultaSQL(vSql, dt)

' ''            Return dt

' ''        End Function

' ''        Public Shared Function ObtenConceptoCxp(ByVal prmrow As DataRow) As ClsConceptosCxp
' ''            If prmrow Is Nothing Then
' ''                Return Nothing
' ''            End If

' ''            Dim ret As New ClsConceptosCxp(prmrow("nTipoMovimiento"))
' ''            ret.Descripcion = prmrow("cDescripcion")
' ''            ret.Tipo = prmrow("cTipo")
' ''            ret.Especial = prmrow("bEspecial")
' ''            ret.Abreviatura = prmrow("cAbreviatura")
' ''            ret.Activo = prmrow("bActivo")

' ''            ret.CargaDatosRegistro(prmrow)

' ''            Return ret

' ''        End Function

' ''        Public Shared Function ObtenConceptoCxp(ByRef prmrow As DataRow, ByVal prmobj As ClsConceptosCxp) As DataRow
' ''            If prmrow Is Nothing Then
' ''                Return Nothing
' ''            End If
' ''            If prmobj Is Nothing Then
' ''                Return Nothing
' ''            End If
' ''            prmrow("nTipoMovimiento") = prmobj.Folio
' ''            prmrow("cDescripcion") = prmobj.Descripcion
' ''            prmrow("cTipo") = prmobj.Tipo
' ''            prmrow("cAbreviatura") = prmobj.Abreviatura
' ''            prmrow("bEspecial") = prmobj.Especial
' ''            prmrow("bActivo") = prmobj.Activo

' ''            prmobj.LLenaDatosRegistroComun(prmrow)

' ''            Return prmrow

' ''        End Function

' ''        ' ''Public Shared Function ObtenCaja(ByVal prmSucursal As Integer, ByVal prmCaja As Integer) As Caja.ClsCaja
' ''        ' ''    Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''        ' ''    Dim dt As New DataTable

' ''        ' ''    DAO.RegresaConsultaSQL("select * From CAJ_Cajas(NOLOCK) Where nCaja = " & prmCaja & " and nsucursal=" & prmSucursal, dt)

' ''        ' ''    If dt.Rows.Count > 0 Then
' ''        ' ''        Return ObtenCaja(dt.Rows(0))
' ''        ' ''    Else
' ''        ' ''        Return Nothing
' ''        ' ''    End If

' ''        ' ''End Function

' ''        ' ''Public Shared Function ObtenCaja(ByVal prmrow As DataRow) As Caja.ClsCaja
' ''        ' ''    If prmrow Is Nothing Then
' ''        ' ''        Return Nothing
' ''        ' ''    End If
' ''        ' ''    Dim ret As New Caja.ClsCaja(prmrow("ncaja"))
' ''        ' ''    ret.Descripcion = prmrow("cDescripcion")
' ''        ' ''    ret.Sucursal = ObtenSucursal(prmrow("nsucursal"))
' ''        ' ''    ret.Activo = prmrow("bactivo")
' ''        ' ''    ret.CargaDatosRegistro(prmrow)

' ''        ' ''    Return ret
' ''        ' ''End Function

' ''        ' ''Public Shared Function ObtenCaja(ByRef prmrow As DataRow, ByVal prmobj As Caja.ClsCaja) As DataRow
' ''        ' ''    If prmrow Is Nothing Then
' ''        ' ''        Return Nothing
' ''        ' ''    End If
' ''        ' ''    If prmobj Is Nothing Then
' ''        ' ''        Return Nothing
' ''        ' ''    End If
' ''        ' ''    prmrow("ncaja") = prmobj.Folio
' ''        ' ''    prmrow("cDescripcion") = prmobj.Descripcion
' ''        ' ''    prmrow("nsucursal") = prmobj.Sucursal.Folio
' ''        ' ''    prmrow("bActivo") = prmobj.Activo

' ''        ' ''    prmobj.LLenaDatosRegistroComun(prmrow)

' ''        ' ''    Return prmrow
' ''        ' ''End Function

' ''        Public Shared Function ObtenDenominacion(ByVal prmDenominacion As Integer) As Caja.ClsDenominacion
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim dt As New DataTable

' ''            DAO.RegresaConsultaSQL("select * From CAJ_Denominaciones(NOLOCK) Where nDenominacion = " & prmDenominacion, dt)

' ''            If dt.Rows.Count > 0 Then
' ''                Return ObtenDenominacion(dt.Rows(0))
' ''            Else
' ''                Return Nothing
' ''            End If

' ''        End Function

' ''        Public Shared Function ObtenDenominacion(ByVal prmrow As DataRow) As Caja.ClsDenominacion
' ''            If prmrow Is Nothing Then
' ''                Return Nothing
' ''            End If
' ''            Dim ret As New Caja.ClsDenominacion(prmrow("ndenominacion"))
' ''            ret.Descripcion = prmrow("cDescripcion")
' ''            ret.MonedaBase = ObtenMoneda(prmrow("nMonedaBase"))
' ''            ret.Valor = prmrow("nValor")
' ''            ret.Activo = prmrow("bactivo")
' ''            ret.Billete = prmrow("bBillete")
' ''            ret.CargaDatosRegistro(prmrow)

' ''            Return ret
' ''        End Function

' ''        Public Shared Function ObtenDenominacion(ByRef prmrow As DataRow, ByVal prmobj As Caja.ClsDenominacion) As DataRow
' ''            If prmrow Is Nothing Then
' ''                Return Nothing
' ''            End If
' ''            If prmobj Is Nothing Then
' ''                Return Nothing
' ''            End If
' ''            prmrow("nDenominacion") = prmobj.Folio
' ''            prmrow("cDescripcion") = prmobj.Descripcion
' ''            prmrow("nMonedaBase") = prmobj.MonedaBase.Folio
' ''            prmrow("nValor") = prmobj.Valor
' ''            prmrow("bActivo") = prmobj.Activo
' ''            prmrow("bBillete") = prmobj.Billete

' ''            prmobj.LLenaDatosRegistroComun(prmrow)

' ''            Return prmrow
' ''        End Function

' ''        Public Shared Function ObtenCausa(ByVal prmCausa As Integer) As Caja.ClsCausa
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim dt As New DataTable

' ''            DAO.RegresaConsultaSQL("SELECT * FROM CTL_Causas(NOLOCK) WHERE nCausa = " & prmCausa, dt)

' ''            If dt.Rows.Count > 0 Then
' ''                Return ObtenCausa(dt.Rows(0))
' ''            Else
' ''                Return Nothing
' ''            End If

' ''        End Function

' ''        Public Shared Function ObtenCausa(ByVal prmrow As DataRow) As Caja.ClsCausa
' ''            If prmrow Is Nothing Then
' ''                Return Nothing
' ''            End If
' ''            Dim ret As New Caja.ClsCausa(prmrow("ncausa"))
' ''            ret.Descripcion = prmrow("cDescripcion")
' ''            ret.TipoCausa = prmrow("nTipoCausa")
' ''            ret.Activo = prmrow("bactivo")
' ''            ret.CargaDatosRegistro(prmrow)

' ''            Return ret
' ''        End Function

' ''        Public Shared Function ObtenCausa(ByRef prmrow As DataRow, ByVal prmobj As Caja.ClsCausa) As DataRow
' ''            If prmrow Is Nothing Then
' ''                Return Nothing
' ''            End If
' ''            If prmobj Is Nothing Then
' ''                Return Nothing
' ''            End If
' ''            prmrow("nCausa") = prmobj.Folio
' ''            prmrow("cDescripcion") = prmobj.Descripcion
' ''            prmrow("nTipoCausa") = prmobj.TipoCausa
' ''            prmrow("bActivo") = prmobj.Activo

' ''            prmobj.LLenaDatosRegistroComun(prmrow)

' ''            Return prmrow
' ''        End Function

' ''        Public Shared Function ObtenTipoDocumento(ByVal prmTipoDocumento As Integer) As Caja.ClsTipoDocumento
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim dt As New DataTable

' ''            DAO.RegresaConsultaSQL("SELECT * FROM CJA_Tipos_Documentos (NOLOCK) WHERE nTipoDocumentoCaja = " & prmTipoDocumento, dt)

' ''            If dt.Rows.Count > 0 Then
' ''                Return ObtenTipoDocumento(dt.Rows(0))
' ''            Else
' ''                Return Nothing
' ''            End If

' ''        End Function

' ''        Public Shared Function ObtenTipoDocumento(ByVal prmrow As DataRow) As Caja.ClsTipoDocumento
' ''            If prmrow Is Nothing Then
' ''                Return Nothing
' ''            End If

' ''            Dim ret As New Caja.ClsTipoDocumento(prmrow("nTipoDocumentoCaja"))

' ''            ret.Descripcion = prmrow("cDescripcion")
' ''            ret.Activo = prmrow("bactivo")

' ''            ret.TipoEfecto = prmrow("nTipoEfecto")
' ''            ret.Moneda = prmrow("nMoneda")
' ''            If prmrow("nTipoAccion") Is DBNull.Value Then
' ''                ret.TipoAccion = 0
' ''            Else
' ''                ret.TipoAccion = prmrow("nTipoAccion")
' ''            End If
' ''            ret.RequiereBanco = prmrow("bRequiereBanco")
' ''            ret.RequiereReferencia = prmrow("bRequiereReferencia")
' ''            ret.Depositable = prmrow("bDepositable")
' ''            ret.RequiereDistribucion = prmrow("bRequiereDistribucion")
' ''            ret.Diferencia = prmrow("bDiferencia")
' ''            ret.AplicaCorte = prmrow("bAplicaCorte")
' ''            ret.CargaDatosRegistro(prmrow)
' ''            Return ret
' ''        End Function

' ''        Public Shared Function ObtenTipoDocumento(ByRef prmrow As DataRow, ByVal prmobj As Caja.ClsTipoDocumento) As DataRow
' ''            If prmrow Is Nothing Then
' ''                Return Nothing
' ''            End If
' ''            If prmobj Is Nothing Then
' ''                Return Nothing
' ''            End If
' ''            prmrow("nTipoDocumentoCaja") = prmobj.Folio
' ''            prmrow("cDescripcion") = prmobj.Descripcion
' ''            prmrow("nTipoEfecto") = prmobj.TipoEfecto
' ''            prmrow("nMoneda") = prmobj.Moneda
' ''            prmrow("nTipoAccion") = prmobj.TipoAccion
' ''            prmrow("bRequiereBanco") = prmobj.RequiereBanco
' ''            prmrow("bRequiereReferencia") = prmobj.RequiereReferencia
' ''            prmrow("bDepositable") = prmobj.Depositable
' ''            prmrow("bRequiereDistribucion") = prmobj.RequiereDistribucion
' ''            prmrow("bDiferencia") = prmobj.Diferencia
' ''            prmrow("bAplicaCorte") = prmobj.AplicaCorte
' ''            prmrow("bActivo") = prmobj.Activo

' ''            prmobj.LLenaDatosRegistroComun(prmrow)

' ''            Return prmrow
' ''        End Function

' ''        'Public Shared Function ObtenProyectoDetalle(ByVal prmrow As DataRow) As ClsProyectoDetalle
' ''        '    If prmrow Is Nothing Then
' ''        '        Return Nothing
' ''        '    End If

' ''        '    Dim ret As New ClsProyectoDetalle(New ClsProyecto(CLng(prmrow("nProyecto"))), prmrow("nProyectoConsecutivo"), prmrow("dFecha"), prmrow("nImporte"), prmrow("cObservaciones"), prmrow("cUsuario_Registro"))

' ''        '    ret.Fecha = prmrow("dFecha")
' ''        '    ret.Importe = prmrow("nImporte")
' ''        '    ret.Observaciones = prmrow("cObservaciones")
' ''        '    ret.Renglon = prmrow("nProyectoConsecutivo")
' ''        '    ret.Registro = prmrow("cUsuario_Registro")

' ''        '    Return ret
' ''        'End Function

' ''        'Public Shared Function ObtenProyectoDetalle(ByRef prmrow As DataRow, ByVal prmMov As ClsProyectoDetalle) As DataRow
' ''        '    If prmrow Is Nothing Then
' ''        '        Return Nothing
' ''        '    End If
' ''        '    If prmMov Is Nothing Then
' ''        '        Return Nothing
' ''        '    End If
' ''        '    prmrow("nProyecto") = prmMov.Proyecto
' ''        '    prmrow("nProyectoConsecutivo") = prmMov.Renglon
' ''        '    prmrow("dFecha") = prmMov.Fecha
' ''        '    prmrow("nImporte") = prmMov.Importe
' ''        '    prmrow("cObservaciones") = prmMov.Observaciones
' ''        '    prmrow("cUsuario_Registro") = prmMov.Registro

' ''        '    If Not prmMov.Renglon = 0 Then
' ''        '        prmrow("nProyectoConsecutivo") = prmMov.Renglon
' ''        '    End If

' ''        '    Return prmrow
' ''        'End Function

' ''        'Public Shared Function ObtenProyectoDetalle(ByRef prmProyecto As Long) As DataTable
' ''        '    Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''        '    Dim dt As New DataTable
' ''        '    DAO.RegresaEsquemaDeDatos("Select * From CTL_ProyectosDetalle(NoLock) Where 1=0", dt)
' ''        '    DAO.RegresaConsultaSQL("Select * From CTL_ProyectosDetalle(NoLock) Where nProyecto=" & prmProyecto, dt)

' ''        '    Return dt
' ''        'End Function

' ''        Public Shared Function ObtenConceptoCheque(ByVal prmConceptoCheque As Integer, Optional ByVal tiempo_real As Boolean = False) As ClsConceptosCheque
' ''            If atrCatalogoConceptosCheque Is Nothing Then atrCatalogoConceptosCheque = New Catalogo(New MetaCatalogo("CTL_ConceptosCheques"))
' ''            Dim vobject As Object = ObtenGenerico(prmConceptoCheque.ToString, atrConceptosChequeinmemory, atrCatalogoConceptosCheque, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenConceptoCheque), tiempo_real)
' ''            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsConceptosCheque))
' ''        End Function

' ''        Public Shared Function ObtenConceptoCheque(Optional ByVal bActivo As Boolean = True) As DataTable
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim dt As New DataTable
' ''            Dim vSql As String = "SELECT * FROM CTL_ConceptosCheques (NOLOCK)" & vbCr

' ''            If bActivo = True Then
' ''                vSql &= "WHERE bActivo = 1" & vbCr
' ''            Else
' ''                vSql &= "WHERE bActivo = 0" & vbCr
' ''            End If

' ''            DAO.RegresaConsultaSQL(vSql, dt)

' ''            Return dt

' ''        End Function

' ''        Public Shared Function ObtenConceptoCheque(ByVal prmrow As DataRow) As ClsConceptosCheque
' ''            If prmrow Is Nothing Then
' ''                Return Nothing
' ''            End If

' ''            Dim ret As New ClsConceptosCheque(prmrow("nConceptoCheque"))
' ''            ret.Descripcion = prmrow("cDescripcion")
' ''            ret.Activo = prmrow("bActivo")

' ''            ret.CargaDatosRegistro(prmrow)

' ''            Return ret

' ''        End Function

' ''        Public Shared Function ObtenConceptoCheque(ByRef prmrow As DataRow, ByVal prmobj As ClsConceptosCheque) As DataRow
' ''            If prmrow Is Nothing Then
' ''                Return Nothing
' ''            End If
' ''            If prmobj Is Nothing Then
' ''                Return Nothing
' ''            End If
' ''            prmrow("nConceptoCheque") = prmobj.Folio
' ''            prmrow("cDescripcion") = prmobj.Descripcion
' ''            prmrow("bActivo") = prmobj.Activo

' ''            prmobj.LLenaDatosRegistroComun(prmrow)

' ''            Return prmrow

' ''        End Function


' ''        Public Shared Function ObtenConceptoFlujo(ByVal prmConceptoFlujo As Integer, Optional ByVal tiempo_real As Boolean = False) As ClsConceptoFlujo
' ''            If atrCatalogoConceptosFlujo Is Nothing Then atrCatalogoConceptosFlujo = New Catalogo(New MetaCatalogo("CTL_ConceptosFlujos"))
' ''            Dim vobject As Object = ObtenGenerico(prmConceptoFlujo.ToString, atrConceptosFlujoinmemory, atrCatalogoConceptosFlujo, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenConceptoFlujo), tiempo_real)
' ''            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsConceptoFlujo))
' ''        End Function

' ''        Public Shared Function ObtenConceptoFlujo(Optional ByVal bActivo As Boolean = True) As DataTable
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim dt As New DataTable
' ''            Dim vSql As String = "SELECT * FROM CTL_ConceptosFlujos (NOLOCK)" & vbCr

' ''            If bActivo = True Then
' ''                vSql &= "WHERE bActivo = 1" & vbCr
' ''            Else
' ''                vSql &= "WHERE bActivo = 0" & vbCr
' ''            End If

' ''            DAO.RegresaConsultaSQL(vSql, dt)

' ''            Return dt

' ''        End Function

' ''        Public Shared Function ObtenConceptoFlujo(ByVal prmrow As DataRow) As ClsConceptoFlujo
' ''            If prmrow Is Nothing Then
' ''                Return Nothing
' ''            End If

' ''            Dim ret As New ClsConceptoFlujo()
' ''            ret.Folio = prmrow("nConceptoFlujo")
' ''            ret.Descripcion = prmrow("cDescripcion")
' ''            ret.Efecto = prmrow("nEfecto")
' ''            ret.Activo = prmrow("bActivo")

' ''            ret.CargaDatosRegistro(prmrow)

' ''            Return ret

' ''        End Function

' ''        Public Shared Function ObtenConceptoFlujo(ByRef prmrow As DataRow, ByVal prmobj As ClsConceptoFlujo) As DataRow
' ''            If prmrow Is Nothing Then
' ''                Return Nothing
' ''            End If
' ''            If prmobj Is Nothing Then
' ''                Return Nothing
' ''            End If
' ''            prmrow("nConceptoFlujo") = prmobj.Folio
' ''            prmrow("nEfecto") = prmobj.Efecto
' ''            prmrow("cDescripcion") = prmobj.Descripcion
' ''            prmrow("bActivo") = prmobj.Activo

' ''            prmobj.LLenaDatosRegistroComun(prmrow)

' ''            Return prmrow

' ''        End Function

' ''        Public Shared Function ObtenRFC(ByVal prmRFC As Integer, Optional ByVal tiempo_real As Boolean = False) As Caja.ClsRFC
' ''            If atrCatalogoRFC Is Nothing Then atrCatalogoRFC = New Catalogo(New MetaCatalogo("RFC"))
' ''            Dim vobject As Object = ObtenGenerico(prmRFC.ToString, atrRFCInMemory, atrCatalogoRFC, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenRFC), tiempo_real)
' ''            Return IIf(vobject Is Nothing, Nothing, CType(vobject, Caja.ClsRFC))
' ''        End Function

' ''        Public Shared Function ObtenRFC(ByVal prmrow As DataRow) As Caja.ClsRFC
' ''            If prmrow Is Nothing Then
' ''                Return Nothing
' ''            End If
' ''            Dim ret As New Caja.ClsRFC(prmrow("nRFC"))
' ''            ret.RFC = prmrow("cRFC")
' ''            ret.Activo = prmrow("bActivo")
' ''            ret.CargaDatosRegistro(prmrow)
' ''            Return ret
' ''        End Function

' ''        Public Shared Function ObtenRFC(ByRef prmrow As DataRow, ByVal prmRFC As Caja.ClsRFC) As DataRow
' ''            If prmrow Is Nothing Then
' ''                Return Nothing
' ''            End If
' ''            If prmRFC Is Nothing Then
' ''                Return Nothing
' ''            End If
' ''            prmrow("nRFC") = prmRFC.Folio
' ''            prmrow("cRFC") = prmRFC.RFC
' ''            prmrow("bActivo") = prmRFC.Activo
' ''            prmRFC.LLenaDatosRegistroComun(prmrow)
' ''            Return prmrow
' ''        End Function

' ''        Public Shared Function ObtenRazonSocial(ByVal prmRFC As Integer, Optional ByVal tiempo_real As Boolean = False) As Caja.ClsRazonSocial
' ''            If atrCatalogoRazonSocial Is Nothing Then atrCatalogoRazonSocial = New Catalogo(New MetaCatalogo("RAZONESSOCIALES"))
' ''            Dim vobject As Object = ObtenGenerico(prmRFC.ToString, atrRazonSocialInMemory, atrCatalogoRazonSocial, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenRazonSocial), tiempo_real)
' ''            Return IIf(vobject Is Nothing, Nothing, CType(vobject, Caja.ClsRazonSocial))
' ''        End Function

' ''        Public Shared Function ObtenRazonSocial(ByVal prmrow As DataRow) As Caja.ClsRazonSocial
' ''            If prmrow Is Nothing Then
' ''                Return Nothing
' ''            End If
' ''            Dim ret As New Caja.ClsRazonSocial(prmrow("nRazonSocial"))
' ''            ret.RFC = Catalogos.FabricaCatalogos.ObtenRFC(prmrow("nRFC"))
' ''            ret.Descripcion = prmrow("cDescripcion")
' ''            ret.Dependencia = ClsTools.IfNull(prmrow("cDependencia"), "")
' ''            ret.Direccion = prmrow("cDireccion")
' ''            ret.Estado = Catalogos.FabricaCatalogos.ObtenEstado(prmrow("nEstado"))
' ''            ret.Municipio = Catalogos.FabricaCatalogos.ObtenMunicipio(prmrow("nMunicipio"))
' ''            ret.Ciudad = Catalogos.FabricaCatalogos.ObtenCiudad(prmrow("nCiudad"))
' ''            ret.Colonia = Catalogos.FabricaCatalogos.ObtenColonia(prmrow("nColonia"))
' ''            If Not prmrow("nCliente") Is DBNull.Value Then
' ''                ret.Cliente = Catalogos.FabricaCatalogos.ObtenCliente(prmrow("nCliente"))
' ''            End If
' ''            ret.Activo = prmrow("bActivo")
' ''            ret.CargaDatosRegistro(prmrow)
' ''            Return ret
' ''        End Function

' ''        Public Shared Function ObtenRazonSocial(ByRef prmrow As DataRow, ByVal prmRazon As Caja.ClsRazonSocial) As DataRow
' ''            If prmrow Is Nothing Then
' ''                Return Nothing
' ''            End If
' ''            If prmRazon Is Nothing Then
' ''                Return Nothing
' ''            End If
' ''            prmrow("nRazonSocial") = prmRazon.Folio
' ''            prmrow("nRFC") = prmRazon.RFC.Folio
' ''            prmrow("cDescripcion") = prmRazon.Descripcion
' ''            prmrow("cDependencia") = prmRazon.Dependencia
' ''            prmrow("cDireccion") = prmRazon.Direccion
' ''            prmrow("nEstado") = prmRazon.Estado.Folio
' ''            prmrow("nMunicipio") = prmRazon.Municipio.Folio
' ''            prmrow("nCiudad") = prmRazon.Ciudad.Folio
' ''            prmrow("nColonia") = prmRazon.Colonia.Folio
' ''            If Not prmRazon.Cliente Is Nothing Then
' ''                prmrow("nCliente") = prmRazon.Cliente.Folio
' ''            End If
' ''            prmrow("bActivo") = prmRazon.Activo
' ''            prmRazon.LLenaDatosRegistroComun(prmrow)
' ''            Return prmrow
' ''        End Function

' ''        Public Shared Function ObtenTipoPoliza(ByVal prmTipoPolizas As Integer, Optional ByVal tiempo_real As Boolean = False) As ClsTiposPoliza
' ''            If atrCatalogoTiposPoliza Is Nothing Then atrCatalogoTiposPoliza = New Catalogo(New MetaCatalogo("CTL_TiposPolizas"))
' ''            Dim vobject As Object = ObtenGenerico(prmTipoPolizas.ToString, atrTiposPolizainmemory, atrCatalogoTiposPoliza, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenTipoPoliza), tiempo_real)
' ''            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsTiposPoliza))
' ''        End Function

' ''        Public Shared Function ObtenTipoPoliza(Optional ByVal bActivo As Boolean = True) As DataTable
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim dt As New DataTable
' ''            Dim vSql As String = "SELECT * FROM CTL_TiposPolizas (NOLOCK)" & vbCr

' ''            If bActivo Then
' ''                vSql &= "WHERE bActivo = 1" & vbCr
' ''            Else
' ''                vSql &= "WHERE bActivo = 0" & vbCr
' ''            End If

' ''            DAO.RegresaConsultaSQL(vSql, dt)

' ''            Return dt

' ''        End Function

' ''        Public Shared Function ObtenTipoPoliza(ByVal prmrow As DataRow) As ClsTiposPoliza
' ''            If prmrow Is Nothing Then
' ''                Return Nothing
' ''            End If

' ''            Dim ret As New ClsTiposPoliza(prmrow("nTipoPoliza"))
' ''            ret.Descripcion = prmrow("cDescripcion")
' ''            ret.Activo = prmrow("bActivo")

' ''            ret.ConReferencia = prmrow("bConReferencia")
' ''            ret.ConBeneficiario = prmrow("bConBeneficiario")
' ''            ret.ConImporte = prmrow("bConImporte")
' ''            ret.PermitePolizasDescuadradas = prmrow("bPermitePolizasDescuadradas")
' ''            ret.ValidarReferencias = prmrow("bValidarReferencias")
' ''            ret.IdentificadorContpaq = prmrow("cIdentificadorContpaq")
' ''            If prmrow("bEsPolizaSaldosInciales") Is DBNull.Value Then
' ''                ret.EsPolizaSaldosInciales = False
' ''            Else
' ''                ret.EsPolizaSaldosInciales = prmrow("bEsPolizaSaldosInciales")
' ''            End If
' ''            If prmrow("nConfiguracion") Is DBNull.Value Then
' ''                ret.Configuracion = Nothing
' ''            Else
' ''                ret.Configuracion = ObtenConfiguracionPolizas(prmrow("nConfiguracion"))
' ''            End If
' ''            If prmrow("cAbreviatura") Is DBNull.Value Then
' ''                ret.Abreviatura = ""
' ''            Else
' ''                ret.Abreviatura = prmrow("cAbreviatura")
' ''            End If

' ''            ret.CargaDatosRegistro(prmrow)

' ''            Return ret

' ''        End Function

' ''        Public Shared Function ObtenTipoPoliza(ByRef prmrow As DataRow, ByVal prmobj As ClsTiposPoliza) As DataRow
' ''            If prmrow Is Nothing Then
' ''                Return Nothing
' ''            End If
' ''            If prmobj Is Nothing Then
' ''                Return Nothing
' ''            End If
' ''            prmrow("nTipoPoliza") = prmobj.Folio
' ''            prmrow("cDescripcion") = prmobj.Descripcion
' ''            prmrow("bActivo") = prmobj.Activo
' ''            prmrow("bConReferencia") = prmobj.ConReferencia
' ''            prmrow("bConBeneficiario") = prmobj.ConBeneficiario
' ''            prmrow("bConImporte") = prmobj.ConImporte
' ''            prmrow("bPermitePolizasDescuadradas") = prmobj.PermitePolizasDescuadradas
' ''            prmrow("bValidarReferencias") = prmobj.ValidarReferencias
' ''            prmrow("cIdentificadorContpaq") = prmobj.IdentificadorContpaq
' ''            prmrow("bEsPolizaSaldosInciales") = prmobj.EsPolizaSaldosInciales

' ''            If prmobj.Configuracion Is Nothing Then
' ''                prmrow("nConfiguracion") = DBNull.Value
' ''            Else
' ''                prmrow("nConfiguracion") = prmobj.Configuracion.Folio
' ''            End If
' ''            If prmobj.Abreviatura = "" Then
' ''                prmrow("cAbreviatura") = DBNull.Value
' ''            Else
' ''                prmrow("cAbreviatura") = prmobj.Abreviatura
' ''            End If

' ''            prmobj.LLenaDatosRegistroComun(prmrow)

' ''            Return prmrow

' ''        End Function

' ''        Public Shared Function ObtenGrupoCuentaBancaria(ByVal prmGrupoCuentaBancaria As Integer, Optional ByVal tiempo_real As Boolean = False) As ClsGrupoCuentaBancaria
' ''            If atrCatalogoGrupoCuentaBancaria Is Nothing Then atrCatalogoGrupoCuentaBancaria = New Catalogo(New MetaCatalogo("CTL_GruposCuentasBancarias"))
' ''            Dim vobject As Object = ObtenGenerico(prmGrupoCuentaBancaria.ToString, atrGrupoCuentaBancariainmemory, atrCatalogoGrupoCuentaBancaria, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenGrupoCuentaBancaria), tiempo_real)
' ''            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsGrupoCuentaBancaria))
' ''        End Function

' ''        Public Shared Function ObtenGrupoCuentaBancaria(Optional ByVal bActivo As Boolean = True) As DataTable
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim dt As New DataTable
' ''            Dim vSql As String = "SELECT * FROM CTL_GruposCuentasBancarias (NOLOCK)" & vbCr

' ''            If bActivo = True Then
' ''                vSql &= "WHERE bActivo = 1" & vbCr
' ''            Else
' ''                vSql &= "WHERE bActivo = 0" & vbCr
' ''            End If

' ''            DAO.RegresaConsultaSQL(vSql, dt)

' ''            Return dt

' ''        End Function

' ''        Public Shared Function ObtenGrupoCuentaBancaria(ByVal prmrow As DataRow) As ClsGrupoCuentaBancaria
' ''            If prmrow Is Nothing Then
' ''                Return Nothing
' ''            End If

' ''            Dim ret As New ClsGrupoCuentaBancaria(prmrow("nGrupoCuentaBancaria"))
' ''            ret.Descripcion = prmrow("cDescripcion")
' ''            ret.Activo = prmrow("bActivo")

' ''            ret.CargaDatosRegistro(prmrow)

' ''            Return ret

' ''        End Function

' ''        Public Shared Function ObtenGrupoCuentaBancaria(ByRef prmrow As DataRow, ByVal prmobj As ClsGrupoCuentaBancaria) As DataRow
' ''            If prmrow Is Nothing Then
' ''                Return Nothing
' ''            End If
' ''            If prmobj Is Nothing Then
' ''                Return Nothing
' ''            End If
' ''            prmrow("nGrupoCuentaBancaria") = prmobj.Folio
' ''            prmrow("cDescripcion") = prmobj.Descripcion
' ''            prmrow("bActivo") = prmobj.Activo

' ''            prmobj.LLenaDatosRegistroComun(prmrow)

' ''            Return prmrow

' ''        End Function

' ''        Public Shared Function ObtenCuentaBancaria(ByVal prmCuentaBancaria As Integer, Optional ByVal tiempo_real As Boolean = False) As ClsCuentaBancaria
' ''            If atrCatalogoCuentaBancaria Is Nothing Then atrCatalogoCuentaBancaria = New Catalogo(New MetaCatalogo("CTL_CuentasBancarias"))
' ''            Dim vobject As Object = ObtenGenerico(prmCuentaBancaria.ToString, atrCuentaBancariainmemory, atrCatalogoCuentaBancaria, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenCuentaBancaria), tiempo_real)
' ''            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsCuentaBancaria))
' ''        End Function

' ''        Public Shared Function ObtenCuentaBancaria(Optional ByVal bActivo As Boolean = True) As DataTable
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim dt As New DataTable
' ''            Dim vSql As String = "SELECT * FROM CTL_CuentasBancarias (NOLOCK)" & vbCr

' ''            If bActivo = True Then
' ''                vSql &= "WHERE bActivo = 1" & vbCr
' ''            Else
' ''                vSql &= "WHERE bActivo = 0" & vbCr
' ''            End If

' ''            DAO.RegresaConsultaSQL(vSql, dt)

' ''            Return dt

' ''        End Function

' ''        Public Shared Function ObtenCuentaBancaria(ByVal prmrow As DataRow) As ClsCuentaBancaria
' ''            If prmrow Is Nothing Then
' ''                Return Nothing
' ''            End If

' ''            Dim ret As New ClsCuentaBancaria(prmrow("nCuentaBancaria"))
' ''            ret.Descripcion = prmrow("cDescripcion")
' ''            ret.Activo = prmrow("bActivo")
' ''            ret.NumCuenta = prmrow("cNumCuenta")

' ''            If prmrow("nCuentaCnt") Is DBNull.Value Then
' ''                ret.CuentaContable = Nothing
' ''            Else
' ''                ret.CuentaContable = ObtenCuentaCnt(prmrow("nCuentaCnt"))
' ''            End If

' ''            If prmrow("nCuentaCntComplementaria") Is DBNull.Value Then
' ''                ret.CuentaComplementaria = Nothing
' ''            Else
' ''                ret.CuentaComplementaria = ObtenCuentaCnt(prmrow("nCuentaCntComplementaria"))
' ''            End If

' ''            If prmrow("nImpresora") Is DBNull.Value Then
' ''                ret.Impresora = 0
' ''            Else
' ''                ret.Impresora = prmrow("nImpresora")
' ''            End If

' ''            If prmrow("cDocumento") Is DBNull.Value Then
' ''                ret.Documento = ""
' ''            Else
' ''                ret.Documento = prmrow("cDocumento")
' ''            End If

' ''            If prmrow("bParaTransferencia") Is DBNull.Value Then
' ''                ret.ParaTransferencia = False
' ''            Else
' ''                ret.ParaTransferencia = prmrow("bParaTransferencia")
' ''            End If

' ''            If prmrow("cEmailBanco") Is DBNull.Value Then
' ''                ret.EmailBanco = ""
' ''            Else
' ''                ret.EmailBanco = prmrow("cEmailBanco")
' ''            End If

' ''            If prmrow("nBanco") Is DBNull.Value Then
' ''                ret.Banco = Nothing
' ''            Else
' ''                ret.Banco = ObtenBanco(CInt(prmrow("nBanco")))
' ''            End If

' ''            If prmrow("nMoneda") Is DBNull.Value Then
' ''                ret.Moneda = Nothing
' ''            Else
' ''                ret.Moneda = ObtenMoneda(CInt(prmrow("nMoneda")))
' ''            End If

' ''            If prmrow("nSucursal") Is DBNull.Value Then
' ''                ret.Sucursal = Nothing
' ''            Else
' ''                ret.Sucursal = ObtenSucursal(CInt(prmrow("nSucursal")))
' ''            End If

' ''            If prmrow("nGrupoCuentaBancaria") Is DBNull.Value Then
' ''                ret.GrupoCuentaBancarias = Nothing
' ''            Else
' ''                ret.GrupoCuentaBancarias = ObtenGrupoCuentaBancaria(CInt(prmrow("nGrupoCuentaBancaria")))
' ''            End If

' ''            If prmrow("nConsecutivo") Is DBNull.Value Then
' ''                ret.Consecutivo = Nothing
' ''            Else
' ''                ret.Consecutivo = ObtenConfiguracionEdoCtaBan(prmrow("nConsecutivo"))
' ''            End If

' ''            If prmrow("cContacto") Is DBNull.Value Then
' ''                ret.Contacto = ""
' ''            Else
' ''                ret.Contacto = prmrow("cContacto")
' ''            End If

' ''            If prmrow("cTelefonoOficinaContacto") Is DBNull.Value Then
' ''                ret.TelefonoContactoOficina = ""
' ''            Else
' ''                ret.TelefonoContactoOficina = prmrow("cTelefonoOficinaContacto")
' ''            End If

' ''            If prmrow("cTelefonoCelularContacto") Is DBNull.Value Then
' ''                ret.TelefonoContactoCelular = ""
' ''            Else
' ''                ret.TelefonoContactoCelular = prmrow("cTelefonoCelularContacto")
' ''            End If

' ''            If prmrow("bCapturaFlujos") Is DBNull.Value Then
' ''                ret.CapturaFlujo = False
' ''            Else
' ''                ret.CapturaFlujo = prmrow("bCapturaFlujos")
' ''            End If

' ''            If prmrow("bConciliaIntegracion") Is DBNull.Value Then
' ''                ret.ConciliaIntegracion = False
' ''            Else
' ''                ret.ConciliaIntegracion = prmrow("bConciliaIntegracion")
' ''            End If

' ''            ret.CargaDatosRegistro(prmrow)

' ''            Return ret

' ''        End Function

' ''        Public Shared Function ObtenCuentaBancaria(ByRef prmrow As DataRow, ByVal prmobj As ClsCuentaBancaria) As DataRow
' ''            If prmrow Is Nothing Then
' ''                Return Nothing
' ''            End If
' ''            If prmobj Is Nothing Then
' ''                Return Nothing
' ''            End If
' ''            prmrow("nCuentaBancaria") = prmobj.Folio
' ''            prmrow("cDescripcion") = prmobj.Descripcion
' ''            prmrow("bActivo") = prmobj.Activo
' ''            prmrow("cNumCuenta") = prmobj.NumCuenta

' ''            prmrow("bConciliaIntegracion") = prmobj.ConciliaIntegracion

' ''            If prmobj.CuentaContable Is Nothing Then
' ''                prmrow("nCuentaCnt") = DBNull.Value
' ''            Else
' ''                prmrow("nCuentaCnt") = prmobj.CuentaContable.Folio
' ''            End If

' ''            If prmobj.CuentaComplementaria Is Nothing Then
' ''                prmrow("nCuentaCntComplementaria") = DBNull.Value
' ''            Else
' ''                prmrow("nCuentaCntComplementaria") = prmobj.CuentaComplementaria.Folio
' ''            End If

' ''            prmrow("nImpresora") = prmobj.Impresora
' ''            prmrow("cDocumento") = prmobj.Documento
' ''            prmrow("bParaTransferencia") = prmobj.ParaTransferencia
' ''            prmrow("cEmailBanco") = prmobj.EmailBanco

' ''            If prmobj.Banco Is Nothing Then
' ''                prmrow("nBanco") = DBNull.Value
' ''            Else
' ''                prmrow("nBanco") = prmobj.Banco.Folio
' ''            End If

' ''            If prmobj.Moneda Is Nothing Then
' ''                prmrow("nMoneda") = DBNull.Value
' ''            Else
' ''                prmrow("nMoneda") = prmobj.Moneda.Folio
' ''            End If

' ''            If prmobj.Sucursal Is Nothing Then
' ''                prmrow("nSucursal") = DBNull.Value
' ''            Else
' ''                prmrow("nSucursal") = prmobj.Sucursal.Folio
' ''            End If

' ''            If prmobj.GrupoCuentaBancarias Is Nothing Then
' ''                prmrow("nGrupoCuentaBancaria") = DBNull.Value
' ''            Else
' ''                prmrow("nGrupoCuentaBancaria") = prmobj.GrupoCuentaBancarias.Folio
' ''            End If

' ''            If prmobj.Consecutivo Is Nothing Then
' ''                prmrow("nConsecutivo") = DBNull.Value
' ''            Else
' ''                prmrow("nConsecutivo") = prmobj.Consecutivo.Folio
' ''            End If

' ''            If prmobj.Contacto = "" Then
' ''                prmrow("cContacto") = DBNull.Value
' ''            Else
' ''                prmrow("cContacto") = prmobj.Contacto
' ''            End If

' ''            If prmobj.TelefonoContactoOficina = "" Then
' ''                prmrow("cTelefonoOficinaContacto") = DBNull.Value
' ''            Else
' ''                prmrow("cTelefonoOficinaContacto") = prmobj.TelefonoContactoOficina
' ''            End If

' ''            If prmobj.TelefonoContactoCelular = "" Then
' ''                prmrow("cTelefonoCelularContacto") = DBNull.Value
' ''            Else
' ''                prmrow("cTelefonoCelularContacto") = prmobj.TelefonoContactoCelular
' ''            End If

' ''            prmrow("bCapturaFlujos") = prmobj.CapturaFlujo

' ''            prmobj.LLenaDatosRegistroComun(prmrow)

' ''            Return prmrow

' ''        End Function

' ''        Public Shared Function ObtenMovimientoBancario(ByVal prmMovimientoBancario As Integer, Optional ByVal tiempo_real As Boolean = False) As ClsMovimientoBancario
' ''            atrCatalogoMovimientoBancario = New Catalogo(New MetaCatalogo("BAN_TiposMovimientos"))
' ''            Dim vobject As Object = ObtenGenerico(prmMovimientoBancario.ToString, atrMovimientoBancarioinmemory, atrCatalogoMovimientoBancario, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenMovimientoBancario), tiempo_real)
' ''            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsMovimientoBancario))
' ''        End Function

' ''        Public Shared Function ObtenMovimientoBancarioGenerales(ByVal prmMovimientoBancario As Integer, Optional ByVal tiempo_real As Boolean = False) As ClsMovimientoBancario
' ''            atrCatalogoMovimientoBancario = New Catalogo(New MetaCatalogo("MovimientosGenerales_BAN"))
' ''            Dim vobject As Object = ObtenGenerico(prmMovimientoBancario.ToString, atrMovimientoBancarioinmemory, atrCatalogoMovimientoBancario, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenMovimientoBancario), tiempo_real)
' ''            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsMovimientoBancario))
' ''        End Function


' ''        Public Shared Function ObtenMovimientoBancario(Optional ByVal bActivo As Boolean = True) As DataTable
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim dt As New DataTable
' ''            Dim vSql As String = "SELECT * FROM BAN_TiposMovimientos (NOLOCK)" & vbCr

' ''            If bActivo = True Then
' ''                vSql &= "WHERE bActivo = 1" & vbCr
' ''            Else
' ''                vSql &= "WHERE bActivo = 0" & vbCr
' ''            End If

' ''            DAO.RegresaConsultaSQL(vSql, dt)

' ''            Return dt

' ''        End Function

' ''        Public Shared Function ObtenMovimientoBancario(ByVal prmrow As DataRow) As ClsMovimientoBancario
' ''            If prmrow Is Nothing Then
' ''                Return Nothing
' ''            End If

' ''            Dim ret As New ClsMovimientoBancario(prmrow("nTipoMovimiento"))
' ''            ret.Descripcion = prmrow("cDescripcion")
' ''            ret.Activo = prmrow("bActivo")
' ''            ret.Efecto = prmrow("nEfecto")

' ''            ret.AfectaLibro = prmrow("bAfectaLibro")
' ''            ret.SujetoaConciliacion = prmrow("bSujetoaConciliacion")
' ''            ret.GeneraPolizaEnLinea = prmrow("bGeneraPolizaEnLinea")
' ''            ret.NoseContabiliza = prmrow("bNoseContabiliza")
' ''            ret.TipoRegistro = prmrow("nTipoRegistro")

' ''            If prmrow("nTipoPoliza") Is DBNull.Value Then
' ''                ret.TipoPoliza = Nothing
' ''            Else
' ''                ret.TipoPoliza = ObtenTipoPoliza(CInt(prmrow("nTipoPoliza")))
' ''            End If

' ''            ret.CargaDatosRegistro(prmrow)

' ''            Return ret

' ''        End Function

' ''        Public Shared Function ObtenMovimientoBancario(ByRef prmrow As DataRow, ByVal prmobj As ClsMovimientoBancario) As DataRow
' ''            If prmrow Is Nothing Then
' ''                Return Nothing
' ''            End If
' ''            If prmobj Is Nothing Then
' ''                Return Nothing
' ''            End If
' ''            prmrow("nTipoMovimiento") = prmobj.Folio
' ''            prmrow("cDescripcion") = prmobj.Descripcion
' ''            prmrow("bActivo") = prmobj.Activo
' ''            prmrow("nEfecto") = prmobj.Efecto
' ''            prmrow("bAfectaLibro") = prmobj.AfectaLibro
' ''            prmrow("bSujetoaConciliacion") = prmobj.SujetoaConciliacion
' ''            prmrow("bGeneraPolizaEnLinea") = prmobj.GeneraPolizaEnLinea
' ''            prmrow("bNoseContabiliza") = prmobj.NoseContabiliza
' ''            prmrow("nTipoRegistro") = prmobj.TipoRegistro

' ''            If prmobj.TipoPoliza Is Nothing Then
' ''                prmrow("nTipoPoliza") = DBNull.Value
' ''            Else
' ''                prmrow("nTipoPoliza") = prmobj.TipoPoliza.Folio
' ''            End If

' ''            prmobj.LLenaDatosRegistroComun(prmrow)

' ''            Return prmrow

' ''        End Function


' ''        Public Shared Function ObtenGrupoProveedor(ByVal prmGrupoProveedor As Integer, Optional ByVal tiempo_real As Boolean = False) As ClsGrupoProveedor
' ''            If atrCatalogoGrupoProveedor Is Nothing Then atrCatalogoGrupoProveedor = New Catalogo(New MetaCatalogo("CTL_GruposProveedores"))
' ''            Dim vobject As Object = ObtenGenerico(prmGrupoProveedor.ToString, atrGrupoProveedorinmemory, atrCatalogoGrupoProveedor, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenGrupoProveedor), tiempo_real)
' ''            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsGrupoProveedor))
' ''        End Function

' ''        Public Shared Function ObtenGrupoProveedor(Optional ByVal bActivo As Boolean = True) As DataTable
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim dt As New DataTable
' ''            Dim vSql As String = "SELECT * FROM CTL_GruposProveedores (NOLOCK)" & vbCr

' ''            If bActivo = True Then
' ''                vSql &= "WHERE bActivo = 1" & vbCr
' ''            Else
' ''                vSql &= "WHERE bActivo = 0" & vbCr
' ''            End If

' ''            DAO.RegresaConsultaSQL(vSql, dt)

' ''            Return dt

' ''        End Function

' ''        Public Shared Function ObtenGrupoProveedor(ByVal prmrow As DataRow) As ClsGrupoProveedor
' ''            If prmrow Is Nothing Then
' ''                Return Nothing
' ''            End If

' ''            Dim ret As New ClsGrupoProveedor(prmrow("nGrupoProveedor"))
' ''            ret.Descripcion = prmrow("cDescripcion")
' ''            ret.Activo = prmrow("bActivo")

' ''            ret.CargaDatosRegistro(prmrow)

' ''            Return ret

' ''        End Function

' ''        Public Shared Function ObtenGrupoProveedor(ByRef prmrow As DataRow, ByVal prmobj As ClsGrupoProveedor) As DataRow
' ''            If prmrow Is Nothing Then
' ''                Return Nothing
' ''            End If
' ''            If prmobj Is Nothing Then
' ''                Return Nothing
' ''            End If
' ''            prmrow("nGrupoProveedor") = prmobj.Folio
' ''            prmrow("cDescripcion") = prmobj.Descripcion
' ''            prmrow("bActivo") = prmobj.Activo

' ''            prmobj.LLenaDatosRegistroComun(prmrow)

' ''            Return prmrow

' ''        End Function

' ''        Public Shared Function ObtenProyectoDetalle(ByVal prmProyecto As Integer) As DataTable
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim vSQL As String
' ''            Dim DT As New DataTable

' ''            'vSQL = "Select PD.dFecha,PD.nImporte,cUsuario_Registro,cObservaciones" & vbCrLf
' ''            vSQL = "Select dbo.ADSUM_FechaSinHora(PD.dFecha) As dFecha,Coalesce(Sum(PD.nImporte),0) As nImporte,AU.cNombre AS cUsuario_Registro,PD.cObservaciones,PD.nProyectoConsecutivo" & vbCrLf
' ''            vSQL &= "From CTL_ProyectosDetalle(NOLOCK) PD " & vbCrLf
' ''            vSQL &= "LEFT JOIN Adsum_Usuarios(NOLOCK) AU ON  PD.cUsuario_Registro=AU.cLogin" & vbCrLf
' ''            vSQL &= "Where PD.nProyecto = " & prmProyecto & vbCrLf
' ''            vSQL &= "Group By dbo.ADSUM_FechaSinHora(PD.dFecha),AU.cNombre,PD.cObservaciones,PD.nProyectoConsecutivo" & vbCrLf
' ''            vSQL &= "Order By PD.nProyectoConsecutivo"

' ''            DAO.RegresaConsultaSQL(vSQL, DT)

' ''            Return DT

' ''        End Function

' ''        Public Shared Function ObtenProyectoGlobalFlujos(ByVal prmProyecto As Integer) As DataTable
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim arg(0) As Object
' ''            Dim Ds As New DataSet

' ''            'Dim DT As New DataTable
' ''            'Dim vSQL As String
' ''            'vSQL = "Select F1.cNivel As cNivel1,F2.cNivel As cNivel2,F3.cNivel As cNivel3,Sum(PD.nImporte) As nImporte," & vbCrLf
' ''            'vSQL &= "F1.cDescripcion As cDescripcionN1,F2.cDescripcion As cDescripcionN2,F3.cDescripcion As cDescripcionN3" & vbCrLf
' ''            'vSQL &= "From CTL_ProyectosDetalle PD(NOLOCK)" & vbCrLf
' ''            'vSQL &= "Join CTL_FlujosEfectivo F1(NoLock) On F1.nFlujo = PD.nFlujo1" & vbCrLf
' ''            'vSQL &= "Left Join CTL_FlujosEfectivo F2(NoLock) On F2.nFlujo = PD.nFlujo2" & vbCrLf
' ''            'vSQL &= "Left Join CTL_FlujosEfectivo F3(NoLock) On F3.nFlujo = PD.nFlujo3" & vbCrLf
' ''            'vSQL &= "Where PD.nProyecto = " & prmProyecto & vbCrLf
' ''            'vSQL &= "Group By F1.cNivel,F2.cNivel,F3.cNivel,F1.cDescripcion,F2.cDescripcion,F3.cDescripcion" & vbCrLf
' ''            'DAO.RegresaConsultaSQL(vSQL, DT)
' ''            'Return DT

' ''            arg(0) = prmProyecto
' ''            DAO.RegresaConsultaSQL("SP_ObtenFlujosProyectoGlobal", Ds, arg)

' ''            Return Ds.Tables(0)
' ''        End Function

' ''        Public Shared Function ObtenOficina(ByVal prmOficina As Integer, Optional ByVal tiempo_real As Boolean = False) As ClsOficina
' ''            If atrCatalogoOficina Is Nothing Then atrCatalogoOficina = New Catalogo(New MetaCatalogo("CTL_Oficinas"))
' ''            Dim vobject As Object = ObtenGenerico(prmOficina.ToString, atrOficinainmemory, atrCatalogoOficina, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenOficina), tiempo_real)
' ''            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsOficina))
' ''        End Function

' ''        Public Shared Function ObtenOficina(Optional ByVal bActivo As Boolean = True) As DataTable
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim dt As New DataTable
' ''            Dim vSql As String = "SELECT * FROM CTL_Oficinas (NOLOCK)" & vbCr

' ''            If bActivo = True Then
' ''                vSql &= "WHERE bActivo = 1" & vbCr
' ''            Else
' ''                vSql &= "WHERE bActivo = 0" & vbCr
' ''            End If

' ''            DAO.RegresaConsultaSQL(vSql, dt)

' ''            Return dt

' ''        End Function

' ''        Public Shared Function ObtenOficina(ByVal prmrow As DataRow) As ClsOficina
' ''            If prmrow Is Nothing Then
' ''                Return Nothing
' ''            End If

' ''            Dim ret As New ClsOficina(prmrow("nOficina"))
' ''            ret.Descripcion = prmrow("cDescripcion")
' ''            ret.Activo = prmrow("bActivo")

' ''            ret.CargaDatosRegistro(prmrow)

' ''            Return ret

' ''        End Function

' ''        Public Shared Function ObtenOficina(ByRef prmrow As DataRow, ByVal prmobj As ClsOficina) As DataRow
' ''            If prmrow Is Nothing Then
' ''                Return Nothing
' ''            End If
' ''            If prmobj Is Nothing Then
' ''                Return Nothing
' ''            End If
' ''            prmrow("nOficina") = prmobj.Folio
' ''            prmrow("cDescripcion") = prmobj.Descripcion
' ''            prmrow("bActivo") = prmobj.Activo
' ''            prmobj.LLenaDatosRegistroComun(prmrow)

' ''            Return prmrow

' ''        End Function
' ''        Public Shared Function ObtenCentroDeCosto(ByVal prmCentroDeCosto As Integer, Optional ByVal tiempo_real As Boolean = False) As ClsCentroDeCosto
' ''            If atrCatalogoCentroDeCosto Is Nothing Then atrCatalogoCentroDeCosto = New Catalogo(New MetaCatalogo("CTL_Centroscosto"))
' ''            Dim vobject As Object = ObtenGenerico(prmCentroDeCosto.ToString, atrOficinainmemory, atrCatalogoCentroDeCosto, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenCentroDeCosto), tiempo_real)
' ''            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsCentroDeCosto))
' ''        End Function

' ''        'Public Shared Function ObtenCentroDeCosto( ByVal Optional prmnCentroCosto As Int32) As DataTable
' ''        '    Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''        '    Dim dt As New DataTable
' ''        '    Dim vSql As String = "SELECT * FROM CTL_Oficinas (NOLOCK)" & vbCr

' ''        '    If bActivo = True Then
' ''        '        vSql &= "WHERE bActivo = 1" & vbCr
' ''        '    Else
' ''        '        vSql &= "WHERE bActivo = 0" & vbCr
' ''        '    End If

' ''        '    DAO.RegresaConsultaSQL(vSql, dt)

' ''        '    Return dt

' ''        'End Function

' ''        Public Shared Function ObtenCentroDeCosto(ByVal prmrow As DataRow) As ClsCentroDeCosto
' ''            If prmrow Is Nothing Then
' ''                Return Nothing
' ''            End If

' ''            Dim ret As New ClsCentroDeCosto(prmrow("nCentroCosto"))
' ''            ret.Descripcion = prmrow("cDescripcion")
' ''            ret.Activo = prmrow("bActivo")

' ''            ret.CargaDatosRegistro(prmrow)

' ''            Return ret

' ''        End Function

' ''        Public Shared Function ObtenCentroDeCosto(ByRef prmrow As DataRow, ByVal prmobj As ClsCentroDeCosto) As DataRow
' ''            If prmrow Is Nothing Then
' ''                Return Nothing
' ''            End If
' ''            If prmobj Is Nothing Then
' ''                Return Nothing
' ''            End If
' ''            prmrow("nCentroCosto") = prmobj.Folio
' ''            prmrow("cDescripcion") = prmobj.Descripcion
' ''            prmrow("bActivo") = prmobj.Activo
' ''            prmobj.LLenaDatosRegistroComun(prmrow)

' ''            Return prmrow

' ''        End Function
' ''        'Public Shared Function ObtenCatalogosDeGrupos(ByVal prmCatalogoDeGrupos As Integer, Optional ByVal tiempo_real As Boolean = False) As ClsCatalogoDeGrupos
' ''        '    If atrCatalogoDeGrupos Is Nothing Then atrCatalogoDeGrupos = New Catalogo(New MetaCatalogo("CTL_GruposContables"))
' ''        '    Dim vobject As Object = ObtenGenerico(prmCatalogoDeGrupos.ToString, atrOficinainmemory, atrCatalogoDeGrupos, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenCatalogosDeGrupos), tiempo_real)
' ''        '    Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsCatalogoDeGrupos))
' ''        'End Function


' ''        'Public Shared Function ObtenCatalogosDeGrupos(ByVal prmrow As DataRow) As ClsCatalogoDeGrupos
' ''        '    If prmrow Is Nothing Then
' ''        '        Return Nothing
' ''        '    End If

' ''        '    Dim ret As New ClsCatalogoDeGrupos(prmrow("nCentroCosto"))
' ''        '    ret.Descripcion = prmrow("cDescripcion")
' ''        '    ret.TipoCuenta = prmrow("nTipoCuenta")
' ''        '    ret.Naturaleza = prmrow("nNaturaleza")
' ''        '    ret.Activo = prmrow("bActivo")


' ''        '    ret.CargaDatosRegistro(prmrow)

' ''        '    Return ret

' ''        'End Function

' ''        'Public Shared Function ObtenCatalogosDeGrupos(ByRef prmrow As DataRow, ByVal prmobj As ClsCatalogoDeGrupos) As DataRow
' ''        '    If prmrow Is Nothing Then
' ''        '        Return Nothing
' ''        '    End If
' ''        '    If prmobj Is Nothing Then
' ''        '        Return Nothing
' ''        '    End If

' ''        '    prmrow("nCentroCosto") = prmobj.Folio
' ''        '    prmrow("cDescripcion") = prmobj.Descripcion
' ''        '    prmrow("nTipoCuenta") = prmobj.TipoCuenta
' ''        '    prmrow("nNaturaleza") = prmobj.Naturaleza
' ''        '    prmrow("bActivo") = prmobj.Activo

' ''        '    prmobj.LLenaDatosRegistroComun(prmrow)

' ''        '    Return prmrow

' ''        'End Function
' ''        Public Shared Function ObtenRuta(ByRef prmrow As DataRow, ByVal prmobj As ClsRuta) As DataRow
' ''            If prmrow Is Nothing Then
' ''                Return Nothing
' ''            End If
' ''            If prmobj Is Nothing Then
' ''                Return Nothing
' ''            End If
' ''            prmrow("nRuta") = prmobj.Folio
' ''            prmrow("nPlaza") = prmobj.Plaza.Folio
' ''            prmrow("cDescripcion") = prmobj.Descripcion
' ''            prmrow("bActivo") = prmobj.Activo

' ''            prmobj.LLenaDatosRegistroComun(prmrow)
' ''            Return prmrow
' ''        End Function

' ''        Public Shared Function ObtenRuta(ByRef prmrow As DataRow) As ClsRuta
' ''            If prmrow Is Nothing Then
' ''                Return Nothing
' ''            End If
' ''            Dim ret As New ClsRuta(prmrow("nRuta"))
' ''            ret.Descripcion = prmrow("cDescripcion")
' ''            ret.Plaza = ObtenPlaza(prmrow("nPlaza"))
' ''            ret.Activo = prmrow("bactivo")
' ''            ret.CargaDatosRegistro(prmrow)
' ''            Return ret
' ''        End Function

' ''        Public Shared Function ObtenRuta(ByVal prmPlaza As Integer, ByVal prmruta As Integer) As ClsRuta
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim dt As New DataTable

' ''            DAO.RegresaConsultaSQL("select * From CTL_Rutas(NOLOCK) Where nRuta = " & prmruta & "and nPlaza=" & prmPlaza, dt)

' ''            If dt.Rows.Count > 0 Then
' ''                Return ObtenRuta(dt.Rows(0))
' ''            Else
' ''                Return Nothing
' ''            End If

' ''        End Function

' ''        Public Shared Sub PgLlenaComboMonedasComboBox(ByRef prmCombo As System.Windows.Forms.ComboBox)
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim vResultado As Boolean
' ''            Dim ObjMoneda As ClsMoneda

' ''            ObjMoneda = ObtenMoneda(DAO.ParametroAdministradoObtener("COM", "MonedaBase"))
' ''            vResultado = DAO.RegresaConsultaSQL("Select cDescripcion,nMoneda From CTL_Monedas(NoLock) Where bActivo = 1", prmCombo)
' ''            If Not ObjMoneda Is Nothing Then
' ''                prmCombo.SelectedValue = ObjMoneda.Folio
' ''            End If
' ''        End Sub
' ''        Public Shared Sub PgLlenaComboImpresoras(ByRef prmCombo As System.Windows.Forms.ComboBox)
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim vResultado As Boolean

' ''            vResultado = DAO.RegresaConsultaSQL("SELECT cDescripcion,nImpresora FROM IMP_Impresoras (NOLOCK)", prmCombo)
' ''            prmCombo.SelectedIndex = 0

' ''        End Sub
' ''        Public Shared Function fgRegresaParidadAunaFecha(ByVal prmMoneda As Integer, ByVal prmFecha As Date) As Decimal
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim ObjMoneda As New ClsMoneda
' ''            Dim ObjParidad As New ClsParidad


' ''            Dim vValor As Decimal
' ''            vValor = 0

' ''            ObjMoneda = ObtenMoneda(prmMoneda)

' ''            If ObjMoneda Is Nothing Then
' ''                Return 0
' ''            End If

' ''            If ObjMoneda.MonedaBase Then
' ''                vValor = 1
' ''            Else
' ''                ObjParidad = ObtenParidad(ObjMoneda.Folio, prmFecha)
' ''                If ObjParidad Is Nothing Then
' ''                    Return 0
' ''                End If
' ''                vValor = ObjParidad.PrecioDeCompra
' ''            End If
' ''            Return vValor
' ''        End Function

' ''        Public Shared Function fgFlujoEfectivoConHijos(ByVal prmFlujoEfectivo As Integer, Optional ByVal prmValida As Boolean = False) As Boolean
' ''            Dim vSQL As String
' ''            Dim DT As New DataTable
' ''            Dim vResultado As Boolean
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia


' ''            vSQL = "Select Top 1 * From CTL_FlujosEfectivo(NoLock)"
' ''            vSQL &= vbCrLf & "Where nFlujoPadre = " & prmFlujoEfectivo

' ''            If prmValida Then
' ''                vSQL &= vbCrLf & "And bActivo = 1"
' ''            End If

' ''            vResultado = DAO.RegresaConsultaSQL(vSQL, DT)

' ''            If DT Is Nothing Then Return False

' ''            If DT.Rows.Count = 0 Then Return False

' ''            Return True
' ''        End Function
' ''        Public Shared Function fgCuentaContableConHijos(ByVal prmCuentaContable As Long, Optional ByVal prmValida As Boolean = False) As Boolean
' ''            Dim vSQL As String
' ''            Dim DT As New DataTable
' ''            Dim vResultado As Boolean
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia

' ''            vSQL = "Select Top 1 * From CNT_Cuentas(NoLock)"
' ''            vSQL &= vbCrLf & "Where nNivelPadre = " & prmCuentaContable

' ''            If prmValida Then
' ''                vSQL &= vbCrLf & "And bActivo = 1"
' ''            End If

' ''            vResultado = DAO.RegresaConsultaSQL(vSQL, DT)

' ''            If DT Is Nothing OrElse DT.Rows.Count = 0 Then Return False

' ''            Return True
' ''        End Function
' ''        Public Shared Function fgCuentaContableConMovimientos(ByVal prmCuentaContable As Long) As Boolean
' ''            Dim vSQL As String
' ''            Dim DT As New DataTable
' ''            Dim vResultado As Boolean
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia

' ''            vSQL = "SELECT TOP 1 PD.nPoliza FROM CNT_Polizas(NoLock) P"
' ''            vSQL &= vbCrLf & "INNER JOIN CNT_PolizasDetalle(NoLock) PD ON P.nPoliza=PD.nPoliza"
' ''            vSQL &= vbCrLf & "WHERE PD.nCuentaCnt = " & prmCuentaContable
' ''            vSQL &= vbCrLf & "AND P.bActivo = 1"

' ''            vResultado = DAO.RegresaConsultaSQL(vSQL, DT)

' ''            If DT Is Nothing OrElse DT.Rows.Count = 0 Then Return False

' ''            Return True
' ''        End Function

' ''        Public Shared Function fgPresupuestoProyectoInicial(ByVal prmProyecto As Integer) As Decimal
' ''            Dim vSQL As String
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim DT As New DataTable
' ''            Dim vResultado As Boolean

' ''            vSQL = "Select Coalesce(D.nImporte,0) As nImporte"
' ''            vSQL &= vbCrLf & "From CTL_ProyectosDetalle D(NoLock)"
' ''            vSQL &= vbCrLf & "Join CTL_Proyectos P(NoLock) On D.nProyecto = P.nProyecto"
' ''            vSQL &= vbCrLf & "Where D.nProyecto = " & prmProyecto & " And D.nProyectoConsecutivo = 1"

' ''            vResultado = DAO.RegresaConsultaSQL(vSQL, DT)

' ''            If DT Is Nothing Then Return 0

' ''            If DT.Rows.Count = 0 Then Return 0

' ''            Return DT.Rows(0).Item(0)
' ''        End Function

' ''        Public Shared Function fgPresupuestoProyectoFinal(ByVal prmProyecto As Integer) As Decimal
' ''            Dim vSQL As String
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim DT As New DataTable
' ''            Dim vResultado As Boolean

' ''            vSQL = "Select Coalesce(Sum(D.nImporte),0) As nImporte"
' ''            vSQL &= vbCrLf & "From CTL_ProyectosDetalle D(NoLock)"
' ''            vSQL &= vbCrLf & "Join CTL_Proyectos P(NoLock) On D.nProyecto = P.nProyecto"
' ''            vSQL &= vbCrLf & "Where D.nProyecto = " & prmProyecto

' ''            vResultado = DAO.RegresaConsultaSQL(vSQL, DT)

' ''            If DT Is Nothing Then Return 0

' ''            If DT.Rows.Count = 0 Then Return 0

' ''            Return DT.Rows(0).Item(0)
' ''        End Function


' ''        Public Shared Function fgTotalChequesProyecto(ByVal prmProyecto As Integer) As Decimal
' ''            Dim vSQL As String
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim DT As New DataTable
' ''            Dim vResultado As Boolean

' ''            vSQL = "Select Coalesce(Sum(BD.nImporte*BAN.nParidad),0) As nImporte"
' ''            vSQL &= vbCrLf & "From BAN_Movimientos BAN(NoLock)"
' ''            vSQL &= vbCrLf & "Join BAN_MovimientosDetalle BD(NoLock) On BD.nMovimientoBancario = BAN.nMovimientoBancario"
' ''            vSQL &= vbCrLf & "Where BD.nProyecto = " & prmProyecto & " And BAN.bActivo = 1 And BAN.bAplicado = 1 And BAN.bEsCheque = 1"

' ''            vResultado = DAO.RegresaConsultaSQL(vSQL, DT)

' ''            If DT Is Nothing Then Return 0

' ''            If DT.Rows.Count = 0 Then Return 0

' ''            Return DT.Rows(0).Item(0)
' ''        End Function

' ''        Public Shared Function fgSaldoDeUnProyectoaUnaFecha(ByVal prmProyecto As Integer, ByVal prmFecha As Integer) As DataTable
' ''            Dim vSQL As String
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim DT As New DataTable
' ''            Dim vResultado As Boolean

' ''            vSQL = "Select Coalesce(Sum(D.nImporte),0) As nImporte"
' ''            vSQL &= vbCrLf & "From CTL_ProyectosDetalle D(NoLock)"
' ''            vSQL &= vbCrLf & "Join CTL_Proyectos P(NoLock) On D.nProyecto = P.nProyecto"
' ''            vSQL &= vbCrLf & "Where D.nProyecto = " & prmProyecto
' ''            vSQL &= vbCrLf & "And dbo.Adsum_NumeroJuliano(D.dFecha) <= " & prmFecha

' ''            vResultado = DAO.RegresaConsultaSQL(vSQL, DT)


' ''            Return DT

' ''        End Function

' ''        Public Shared Function fgMovtosBancariosProyecto(ByVal prmProyecto As Integer, ByVal prmFechaIncial As Integer, ByVal prmFechaFinal As Integer) As DataSet

' ''            Dim DS As New DataSet
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim vPresupuestoFinal As Decimal
' ''            Dim DT As New DataTable
' ''            Dim vDiaInicial As Long
' ''            Dim vDiaFinal As Long

' ''            vPresupuestoFinal = 0
' ''            vDiaFinal = 0
' ''            vDiaInicial = 0

' ''            If prmFechaIncial <> 0 Then
' ''                vDiaFinal = prmFechaFinal
' ''                vDiaInicial = prmFechaIncial
' ''            End If

' ''            DT = fgSaldoDeUnProyectoaUnaFecha(prmProyecto, prmFechaIncial)

' ''            If Not DT Is Nothing Then
' ''                If DT.Rows.Count > 0 Then
' ''                    vPresupuestoFinal = DT.Rows(0).Item(0)
' ''                End If
' ''            End If

' ''            Dim arg(4) As Object

' ''            arg(0) = prmProyecto
' ''            arg(1) = vPresupuestoFinal
' ''            arg(2) = vDiaInicial
' ''            arg(3) = vDiaFinal

' ''            DAO.RegresaConsultaSQL("BAN_DetalleMovtosBanProyecto", DS, arg)

' ''            DS.Tables.Add(DT)

' ''            If DS Is Nothing Then
' ''                Return Nothing
' ''            End If

' ''            If DS.Tables.Count = 0 Then
' ''                Return Nothing
' ''            End If

' ''            Return DS
' ''        End Function

' ''        Public Shared Function ObtenTiposAlmacenConsumo() As String
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim dt As New DataTable
' ''            DAO.RegresaConsultaSQL("SELECT nTipoAlmacenConsumo FROM mtcTiposAlmacenConsumo", dt)
' ''            Dim vTiposAlmacenes As String = ""
' ''            For Each dr As DataRow In dt.Rows
' ''                vTiposAlmacenes &= dr("nTipoAlmacenConsumo") & ","
' ''            Next
' ''            If Not vTiposAlmacenes.Trim = "" Then
' ''                vTiposAlmacenes = vTiposAlmacenes.Substring(0, vTiposAlmacenes.Length - 1)
' ''            End If
' ''            Return vTiposAlmacenes
' ''        End Function
' ''        Public Shared Function Obtenejercicio(ByRef prmrow As DataRow, ByVal prmobj As ClsEjercicio) As DataRow
' ''            If prmrow Is Nothing Then
' ''                Return Nothing
' ''            End If
' ''            If prmobj Is Nothing Then
' ''                Return Nothing
' ''            End If
' ''            'prmrow("nFolio") = prmobj.Folio
' ''            prmrow("nEjercicio") = prmobj.Ejercicio
' ''            prmrow("bActivo") = prmobj.Activo

' ''            prmobj.LLenaDatosRegistroComun(prmrow)
' ''            Return prmrow
' ''        End Function

' ''        Public Shared Function ObtenEjercicio(ByRef prmrow As DataRow) As ClsEjercicio
' ''            If prmrow Is Nothing Then
' ''                Return Nothing
' ''            End If
' ''            'Dim ret As New ClsEjercicio(prmrow("nFolio"))
' ''            Dim ret As New ClsEjercicio(prmrow("nEjercicio"))
' ''            ret.Ejercicio = prmrow("nEjercicio")
' ''            ret.Activo = prmrow("bActivo")
' ''            ret.CargaDatosRegistro(prmrow)
' ''            Return ret
' ''        End Function

' ''        Public Shared Function ObtenEjercicio(ByVal prmEjercicio As Integer) As ClsEjercicio
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim dt As New DataTable
' ''            DAO.RegresaConsultaSQL("SELECT * FROM CTL_Ejercicios(NOLOCK) WHERE nEjercicio = " & prmEjercicio, dt)
' ''            If dt.Rows.Count > 0 Then
' ''                Return ObtenEjercicio(dt.Rows(0))
' ''            Else
' ''                Return Nothing
' ''            End If
' ''        End Function
' ''        Public Shared Function fgObtenEjercicioMayor() As Integer
' ''            Dim vSQL As String
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim DT As New DataTable
' ''            Dim vResultado As Boolean

' ''            vSQL = "SELECT MAX(nEjercicio)as nEjercicio FROM CTL_Ejercicios (NOLOCK)"
' ''            vResultado = DAO.RegresaConsultaSQL(vSQL, DT)
' ''            If DT Is Nothing Then Return DAO.RegresaFechaDelSistema.Year

' ''            If DT.Rows.Count = 0 Then Return DAO.RegresaFechaDelSistema.Year
' ''            Return IfNull(DT.Rows(0).Item(0), DAO.RegresaFechaDelSistema.Year)

' ''        End Function



        Public Shared Function ObtenConfiguracionEdoCtaBan(ByVal prmConsecutivo As Integer, Optional ByVal tiempo_real As Boolean = False) As ClsConfiguracionEdoCtaBan
            If atrCatalogoConfiguracionEdoCtaBan Is Nothing Then atrCatalogoConfiguracionEdoCtaBan = New Catalogo(New MetaCatalogo("BAN_ConfiguracionesEdoCtaBancaria"))
            Dim vobject As Object = ObtenGenerico(prmConsecutivo.ToString, atrConfiguracionEdoCtaBan, atrCatalogoConfiguracionEdoCtaBan, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenConfiguracionEdoCtaBan), tiempo_real)
            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsConfiguracionEdoCtaBan))
        End Function

        Public Shared Function ObtenConfiguracionEdoCtaBan(Optional ByVal bActivo As Boolean = True) As DataTable
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim dt As New DataTable
            Dim vSql As String = "SELECT * FROM BAN_ConfiguracionesEdoCtaBancaria (NOLOCK)" & vbCr

            If bActivo = True Then
                vSql &= "WHERE bActivo = 1" & vbCr
            Else
                vSql &= "WHERE bActivo = 0" & vbCr
            End If

            DAO.RegresaConsultaSQL(vSql, dt)

            Return dt

        End Function

        Public Shared Function ObtenConfiguracionEdoCtaBan(ByVal prmrow As DataRow) As ClsConfiguracionEdoCtaBan
            If prmrow Is Nothing Then
                Return Nothing
            End If

            Dim ret As New ClsConfiguracionEdoCtaBan(prmrow("nConsecutivo"))
            ret.Descripcion = prmrow("cDescripcion")
            ret.Activo = prmrow("bActivo")

            ret.nLineaIniciaDetalle = prmrow("nLineaIniciaDetalle")

            ret.bIngresoPorPosicion = prmrow("bIngresoPorPosicion")

            If prmrow("nPosIniIngreso") Is DBNull.Value Then
                ret.nPosIniIngreso = 0
            Else
                ret.nPosIniIngreso = prmrow("nPosIniIngreso")
            End If

            If prmrow("nPosFinIngreso") Is DBNull.Value Then
                ret.nPosFinIngreso = 0
            Else
                ret.nPosFinIngreso = prmrow("nPosFinIngreso")
            End If

            If prmrow("cSeparadorIngreso") Is DBNull.Value Then
                ret.cSeparadorIngreso = ""
            Else
                ret.cSeparadorIngreso = prmrow("cSeparadorIngreso")
            End If


            If prmrow("nPosicionIngresoConSeparador") Is DBNull.Value Then
                ret.nPosicionIngresoConSeparador = 0
            Else
                ret.nPosicionIngresoConSeparador = prmrow("nPosicionIngresoConSeparador")
            End If


            If prmrow("cValorIdentificaComoIngreso") Is DBNull.Value Then
                ret.cValorIdentificaComoIngreso = ""
            Else
                ret.cValorIdentificaComoIngreso = prmrow("cValorIdentificaComoIngreso")
            End If

            If prmrow("bDiferenteDeIngreso") Is DBNull.Value Then
                ret.bDiferenteDeIngreso = False
            Else
                ret.bDiferenteDeIngreso = prmrow("bDiferenteDeIngreso")
            End If



            ret.bEgresoPorPosicion = prmrow("bEgresoPorPosicion")

            If prmrow("nPosIniEgreso") Is DBNull.Value Then
                ret.nPosIniEgreso = 0
            Else
                ret.nPosIniEgreso = prmrow("nPosIniEgreso")
            End If

            If prmrow("nPosFinEgreso") Is DBNull.Value Then
                ret.nPosFinEgreso = 0
            Else
                ret.nPosFinEgreso = prmrow("nPosFinEgreso")
            End If


            If prmrow("cSeparadorEgreso") Is DBNull.Value Then
                ret.cSeparadorEgreso = ""
            Else
                ret.cSeparadorEgreso = prmrow("cSeparadorEgreso")
            End If

            If prmrow("nPosicionEgresoConSeparador") Is DBNull.Value Then
                ret.nPosicionEgresoConSeparador = 0
            Else
                ret.nPosicionEgresoConSeparador = prmrow("nPosicionEgresoConSeparador")
            End If


            If prmrow("cValorIdentificaComoEgreso") Is DBNull.Value Then
                ret.cValorIdentificaComoEgreso = ""
            Else
                ret.cValorIdentificaComoEgreso = prmrow("cValorIdentificaComoEgreso")
            End If

            If prmrow("bDiferenteDeEgreso") Is DBNull.Value Then
                ret.bDiferenteDeEgreso = False
            Else
                ret.bDiferenteDeEgreso = prmrow("bDiferenteDeEgreso")
            End If

            ret.bEsFechaPorPosicionIngreso = prmrow("bEsFechaPorPosicionIngreso")

            If prmrow("nPosIniFechaIngreso") Is DBNull.Value Then
                ret.nPosIniFechaIngreso = 0
            Else
                ret.nPosIniFechaIngreso = prmrow("nPosIniFechaIngreso")
            End If

            If prmrow("nPosFinFechaIngreso") Is DBNull.Value Then
                ret.nPosFinFechaIngreso = 0
            Else
                ret.nPosFinFechaIngreso = prmrow("nPosFinFechaIngreso")
            End If

            If prmrow("cSeparadorFechaIngreso") Is DBNull.Value Then
                ret.cSeparadorFechaIngreso = ""
            Else
                ret.cSeparadorFechaIngreso = prmrow("cSeparadorFechaIngreso")
            End If

            If prmrow("nPosicionFechaIngresoConSeparador") Is DBNull.Value Then
                ret.nPosicionFechaIngresoConSeparador = 0
            Else
                ret.nPosicionFechaIngresoConSeparador = prmrow("nPosicionFechaIngresoConSeparador")
            End If

            ret.cFormatoFechaIngreso = prmrow("cFormatoFechaIngreso")
            ret.bFormatoFechaEspanolIngreso = prmrow("bFormatoFechaEspanolIngreso")

            ret.bEsFechaPorPosicionEgreso = prmrow("bEsFechaPorPosicionEgreso")

            If prmrow("nPosIniFechaEgreso") Is DBNull.Value Then
                ret.nPosIniFechaEgreso = 0
            Else
                ret.nPosIniFechaEgreso = prmrow("nPosIniFechaEgreso")
            End If

            If prmrow("nPosFinFechaEgreso") Is DBNull.Value Then
                ret.nPosFinFechaEgreso = 0
            Else
                ret.nPosFinFechaEgreso = prmrow("nPosFinFechaEgreso")
            End If

            If prmrow("cSeparadorFechaEgreso") Is DBNull.Value Then
                ret.cSeparadorFechaEgreso = ""
            Else
                ret.cSeparadorFechaEgreso = prmrow("cSeparadorFechaEgreso")
            End If

            If prmrow("nPosicionFechaEgresoConSeparador") Is DBNull.Value Then
                ret.nPosicionFechaEgresoConSeparador = 0
            Else
                ret.nPosicionFechaEgresoConSeparador = prmrow("nPosicionFechaEgresoConSeparador")
            End If

            ret.cFormatoFechaEgreso = prmrow("cFormatoFechaEgreso")
            ret.bFormatoFechaEspanolEgreso = prmrow("bFormatoFechaEspanolEgreso")

            ret.bObservacionIngresoPorPosicion = prmrow("bObservacionIngresoPorPosicion")

            If prmrow("nPosIniObservacionIngreso") Is DBNull.Value Then
                ret.nPosIniObservacionIngreso = 0
            Else
                ret.nPosIniObservacionIngreso = prmrow("nPosIniObservacionIngreso")
            End If

            If prmrow("nPosFinObservacionIngreso") Is DBNull.Value Then
                ret.nPosFinObservacionIngreso = 0
            Else
                ret.nPosFinObservacionIngreso = prmrow("nPosFinObservacionIngreso")
            End If

            If prmrow("cSeparadorObservacionIngreso") Is DBNull.Value Then
                ret.cSeparadorObservacionIngreso = ""
            Else
                ret.cSeparadorObservacionIngreso = prmrow("cSeparadorObservacionIngreso")
            End If

            If prmrow("nPosicionObservacionIngreso") Is DBNull.Value Then
                ret.nPosicionObservacionIngreso = 0
            Else
                ret.nPosicionObservacionIngreso = prmrow("nPosicionObservacionIngreso")
            End If

            ret.bObservacionEgresoPorPosicion = prmrow("bObservacionEgresoPorPosicion")

            If prmrow("nPosIniObservacionEgreso") Is DBNull.Value Then
                ret.nPosIniObservacionEgreso = 0
            Else
                ret.nPosIniObservacionEgreso = prmrow("nPosIniObservacionEgreso")
            End If

            If prmrow("nPosFinObservacionEgreso") Is DBNull.Value Then
                ret.nPosFinObservacionEgreso = 0
            Else
                ret.nPosFinObservacionEgreso = prmrow("nPosFinObservacionEgreso")
            End If

            If prmrow("cSeparadorObservacionEgreso") Is DBNull.Value Then
                ret.cSeparadorObservacionEgreso = ""
            Else
                ret.cSeparadorObservacionEgreso = prmrow("cSeparadorObservacionEgreso")
            End If

            If prmrow("nPosicionObservacionEgreso") Is DBNull.Value Then
                ret.nPosicionObservacionEgreso = 0
            Else
                ret.nPosicionObservacionEgreso = prmrow("nPosicionObservacionEgreso")
            End If

            ret.bReferenciaIngresoPorPosicion = prmrow("bReferenciaIngresoPorPosicion")

            If prmrow("nPosIniReferenciaIngreso") Is DBNull.Value Then
                ret.nPosIniReferenciaIngreso = 0
            Else
                ret.nPosIniReferenciaIngreso = prmrow("nPosIniReferenciaIngreso")
            End If

            If prmrow("nPosFinReferenciaIngreso") Is DBNull.Value Then
                ret.nPosFinReferenciaIngreso = 0
            Else
                ret.nPosFinReferenciaIngreso = prmrow("nPosFinReferenciaIngreso")
            End If

            If prmrow("cSeparadorReferenciaIngreso") Is DBNull.Value Then
                ret.cSeparadorReferenciaIngreso = ""
            Else
                ret.cSeparadorReferenciaIngreso = prmrow("cSeparadorReferenciaIngreso")
            End If

            If prmrow("nPosicionReferenciaIngreso") Is DBNull.Value Then
                ret.nPosicionReferenciaIngreso = 0
            Else
                ret.nPosicionReferenciaIngreso = prmrow("nPosicionReferenciaIngreso")
            End If

            ret.bReferenciaEgresoPorPosicion = prmrow("bReferenciaEgresoPorPosicion")


            If prmrow("nPosIniReferenciaEgreso") Is DBNull.Value Then
                ret.nPosIniReferenciaEgreso = 0
            Else
                ret.nPosIniReferenciaEgreso = prmrow("nPosIniReferenciaEgreso")
            End If

            If prmrow("nPosFinReferenciaEgreso") Is DBNull.Value Then
                ret.nPosFinReferenciaEgreso = 0
            Else
                ret.nPosFinReferenciaEgreso = prmrow("nPosFinReferenciaEgreso")
            End If

            If prmrow("cSeparadorReferenciaEgreso") Is DBNull.Value Then
                ret.cSeparadorReferenciaEgreso = ""
            Else
                ret.cSeparadorReferenciaEgreso = prmrow("cSeparadorReferenciaEgreso")
            End If

            If prmrow("nPosicionReferenciaEgreso") Is DBNull.Value Then
                ret.nPosicionReferenciaEgreso = 0
            Else
                ret.nPosicionReferenciaEgreso = prmrow("nPosicionReferenciaEgreso")
            End If

            ret.bImporteIngresoPorPosicion = prmrow("bImporteIngresoPorPosicion")

            If prmrow("nPosIniImporteIngreso") Is DBNull.Value Then
                ret.nPosIniImporteIngreso = 0
            Else
                ret.nPosIniImporteIngreso = prmrow("nPosIniImporteIngreso")
            End If

            If prmrow("nPosFinImporteIngreso") Is DBNull.Value Then
                ret.nPosFinImporteIngreso = 0
            Else
                ret.nPosFinImporteIngreso = prmrow("nPosFinImporteIngreso")
            End If

            If prmrow("cSeparadorImporteIngreso") Is DBNull.Value Then
                ret.cSeparadorImporteIngreso = ""
            Else
                ret.cSeparadorImporteIngreso = prmrow("cSeparadorImporteIngreso")
            End If

            If prmrow("nPosicionImporteIngreso") Is DBNull.Value Then
                ret.nPosicionImporteIngreso = 0
            Else
                ret.nPosicionImporteIngreso = prmrow("nPosicionImporteIngreso")
            End If

            ret.bSinPuntoDecimalImporteIngreso = prmrow("bSinPuntoDecimalImporteIngreso")

            If prmrow("nPosicionesDecimalImporteIngreso") Is DBNull.Value Then
                ret.nPosicionesDecimalImporteIngreso = 0
            Else
                ret.nPosicionesDecimalImporteIngreso = prmrow("nPosicionesDecimalImporteIngreso")
            End If

            ret.bImporteEgresoPorPosicion = prmrow("bImporteEgresoPorPosicion")


            If prmrow("nPosIniImporteEgreso") Is DBNull.Value Then
                ret.nPosIniImporteEgreso = 0
            Else
                ret.nPosIniImporteEgreso = prmrow("nPosIniImporteEgreso")
            End If

            If prmrow("nPosFinImporteEgreso") Is DBNull.Value Then
                ret.nPosFinImporteEgreso = 0
            Else
                ret.nPosFinImporteEgreso = prmrow("nPosFinImporteEgreso")
            End If

            If prmrow("cSeparadorImporteEgreso") Is DBNull.Value Then
                ret.cSeparadorImporteEgreso = ""
            Else
                ret.cSeparadorImporteEgreso = prmrow("cSeparadorImporteEgreso")
            End If

            If prmrow("nPosicionImporteEgreso") Is DBNull.Value Then
                ret.nPosicionImporteEgreso = 0
            Else
                ret.nPosicionImporteEgreso = prmrow("nPosicionImporteEgreso")
            End If

            ret.bSinPuntoDecimalImporteEgreso = prmrow("bSinPuntoDecimalImporteEgreso")

            If prmrow("nPosicionesDecimalImporteEgreso") Is DBNull.Value Then
                ret.nPosicionesDecimalImporteEgreso = 0
            Else
                ret.nPosicionesDecimalImporteEgreso = prmrow("nPosicionesDecimalImporteEgreso")
            End If



            If prmrow("bClaveIngresoPorPosicion") Is DBNull.Value Then
                ret.bClaveIngresoPorPosicion = False
            Else
                ret.bClaveIngresoPorPosicion = prmrow("bClaveIngresoPorPosicion")
            End If

            If prmrow("nPosIniClaveIngreso") Is DBNull.Value Then
                ret.nPosIniClaveIngreso = 0
            Else
                ret.nPosIniClaveIngreso = prmrow("nPosIniClaveIngreso")
            End If

            If prmrow("nPosFinClaveIngreso") Is DBNull.Value Then
                ret.nPosFinClaveIngreso = 0
            Else
                ret.nPosFinClaveIngreso = prmrow("nPosFinClaveIngreso")
            End If

            If prmrow("cSeparadorClaveIngreso") Is DBNull.Value Then
                ret.cSeparadorClaveIngreso = ""
            Else
                ret.cSeparadorClaveIngreso = prmrow("cSeparadorClaveIngreso")
            End If

            If prmrow("nPosicionClaveIngreso") Is DBNull.Value Then
                ret.nPosicionClaveIngreso = 0
            Else
                ret.nPosicionClaveIngreso = prmrow("nPosicionClaveIngreso")
            End If


            If prmrow("bClaveEgresoPorPosicion") Is DBNull.Value Then
                ret.bClaveEgresoPorPosicion = False
            Else
                ret.bClaveEgresoPorPosicion = prmrow("bClaveEgresoPorPosicion")
            End If

            If prmrow("nPosIniClaveEgreso") Is DBNull.Value Then
                ret.nPosIniClaveEgreso = 0
            Else
                ret.nPosIniClaveEgreso = prmrow("nPosIniClaveEgreso")
            End If

            If prmrow("nPosFinClaveEgreso") Is DBNull.Value Then
                ret.nPosFinClaveEgreso = 0
            Else
                ret.nPosFinClaveEgreso = prmrow("nPosFinClaveEgreso")
            End If

            If prmrow("cSeparadorClaveEgreso") Is DBNull.Value Then
                ret.cSeparadorClaveEgreso = ""
            Else
                ret.cSeparadorClaveEgreso = prmrow("cSeparadorClaveEgreso")
            End If

            If prmrow("nPosicionClaveEgreso") Is DBNull.Value Then
                ret.nPosicionClaveEgreso = 0
            Else
                ret.nPosicionClaveEgreso = prmrow("nPosicionClaveEgreso")
            End If

            ret.CargaDatosRegistro(prmrow)

            Return ret

        End Function

        Public Shared Function ObtenConfiguracionEdoCtaBan(ByRef prmrow As DataRow, ByVal prmobj As ClsConfiguracionEdoCtaBan) As DataRow
            If prmrow Is Nothing Then
                Return Nothing
            End If
            If prmobj Is Nothing Then
                Return Nothing
            End If

            prmrow("nConsecutivo") = prmobj.Folio
            prmrow("cDescripcion") = prmobj.Descripcion
            prmrow("bActivo") = prmobj.Activo
            prmrow("nLineaIniciaDetalle") = prmobj.nLineaIniciaDetalle


            prmrow("bIngresoPorPosicion") = prmobj.bIngresoPorPosicion

            If prmobj.nPosIniIngreso = 0 Then
                prmrow("nPosIniIngreso") = DBNull.Value
            Else
                prmrow("nPosIniIngreso") = prmobj.nPosIniIngreso
            End If

            If prmobj.nPosFinIngreso = 0 Then
                prmrow("nPosFinIngreso") = DBNull.Value
            Else
                prmrow("nPosFinIngreso") = prmobj.nPosFinIngreso
            End If

            If prmobj.cSeparadorIngreso = "" Then
                prmrow("cSeparadorIngreso") = DBNull.Value
            Else
                prmrow("cSeparadorIngreso") = prmobj.cSeparadorIngreso
            End If


            If prmobj.nPosicionIngresoConSeparador = 0 Then
                prmrow("nPosicionIngresoConSeparador") = DBNull.Value
            Else
                prmrow("nPosicionIngresoConSeparador") = prmobj.nPosicionIngresoConSeparador
            End If


            If prmobj.cValorIdentificaComoIngreso = "" Then
                prmrow("cValorIdentificaComoIngreso") = DBNull.Value
            Else
                prmrow("cValorIdentificaComoIngreso") = prmobj.cValorIdentificaComoIngreso
            End If

            If prmobj.bDiferenteDeIngreso = False Then
                prmrow("bDiferenteDeIngreso") = DBNull.Value
            Else
                prmrow("bDiferenteDeIngreso") = prmobj.bDiferenteDeIngreso
            End If



            prmrow("bEgresoPorPosicion") = prmobj.bEgresoPorPosicion

            If prmobj.nPosIniEgreso = 0 Then
                prmrow("nPosIniEgreso") = DBNull.Value
            Else
                prmrow("nPosIniEgreso") = prmobj.nPosIniEgreso
            End If

            If prmobj.nPosFinEgreso = 0 Then
                prmrow("nPosFinEgreso") = DBNull.Value
            Else
                prmrow("nPosFinEgreso") = prmobj.nPosFinEgreso
            End If


            If prmobj.cSeparadorEgreso = "" Then
                prmrow("cSeparadorEgreso") = DBNull.Value
            Else
                prmrow("cSeparadorEgreso") = prmobj.cSeparadorEgreso
            End If

            If prmobj.nPosicionEgresoConSeparador = 0 Then
                prmrow("nPosicionEgresoConSeparador") = DBNull.Value
            Else
                prmrow("nPosicionEgresoConSeparador") = prmobj.nPosicionEgresoConSeparador
            End If


            If prmobj.cValorIdentificaComoEgreso = "" Then
                prmrow("cValorIdentificaComoEgreso") = DBNull.Value
            Else
                prmrow("cValorIdentificaComoEgreso") = prmobj.cValorIdentificaComoEgreso
            End If

            If prmobj.bDiferenteDeEgreso = False Then
                prmrow("bDiferenteDeEgreso") = DBNull.Value
            Else
                prmrow("bDiferenteDeEgreso") = prmobj.bDiferenteDeEgreso
            End If

            prmrow("bEsFechaPorPosicionIngreso") = prmobj.bEsFechaPorPosicionIngreso

            If prmobj.nPosIniFechaIngreso = 0 Then
                prmrow("nPosIniFechaIngreso") = DBNull.Value
            Else
                prmrow("nPosIniFechaIngreso") = prmobj.nPosIniFechaIngreso
            End If

            If prmobj.nPosFinFechaIngreso = 0 Then
                prmrow("nPosFinFechaIngreso") = DBNull.Value
            Else
                prmrow("nPosFinFechaIngreso") = prmobj.nPosFinFechaIngreso
            End If

            If prmobj.cSeparadorFechaIngreso = "" Then
                prmrow("cSeparadorFechaIngreso") = DBNull.Value
            Else
                prmrow("cSeparadorFechaIngreso") = prmobj.cSeparadorFechaIngreso
            End If

            If prmobj.nPosicionFechaIngresoConSeparador = 0 Then
                prmrow("nPosicionFechaIngresoConSeparador") = DBNull.Value
            Else
                prmrow("nPosicionFechaIngresoConSeparador") = prmobj.nPosicionFechaIngresoConSeparador
            End If

            prmrow("bFormatoFechaEspanolIngreso") = prmobj.bFormatoFechaEspanolIngreso


            prmrow("cFormatoFechaIngreso") = prmobj.cFormatoFechaIngreso

            prmrow("bEsFechaPorPosicionEgreso") = prmobj.bEsFechaPorPosicionEgreso

            If prmobj.nPosIniFechaEgreso = 0 Then
                prmrow("nPosIniFechaEgreso") = DBNull.Value
            Else
                prmrow("nPosIniFechaEgreso") = prmobj.nPosIniFechaEgreso
            End If

            If prmobj.nPosFinFechaEgreso = 0 Then
                prmrow("nPosFinFechaEgreso") = DBNull.Value
            Else
                prmrow("nPosFinFechaEgreso") = prmobj.nPosFinFechaEgreso
            End If

            If prmobj.cSeparadorFechaEgreso = "" Then
                prmrow("cSeparadorFechaEgreso") = DBNull.Value
            Else
                prmrow("cSeparadorFechaEgreso") = prmobj.cSeparadorFechaEgreso
            End If

            If prmobj.nPosicionFechaEgresoConSeparador = 0 Then
                prmrow("nPosicionFechaEgresoConSeparador") = DBNull.Value
            Else
                prmrow("nPosicionFechaEgresoConSeparador") = prmobj.nPosicionFechaEgresoConSeparador
            End If

            prmrow("cFormatoFechaEgreso") = prmobj.cFormatoFechaEgreso

            prmrow("bFormatoFechaEspanolEgreso") = prmobj.bFormatoFechaEspanolEgreso

            prmrow("bObservacionIngresoPorPosicion") = prmobj.bObservacionIngresoPorPosicion

            If prmobj.nPosIniObservacionIngreso = 0 Then
                prmrow("nPosIniObservacionIngreso") = DBNull.Value
            Else
                prmrow("nPosIniObservacionIngreso") = prmobj.nPosIniObservacionIngreso
            End If

            If prmobj.nPosFinObservacionIngreso = 0 Then
                prmrow("nPosFinObservacionIngreso") = DBNull.Value
            Else
                prmrow("nPosFinObservacionIngreso") = prmobj.nPosFinObservacionIngreso
            End If

            If prmobj.cSeparadorObservacionIngreso = "" Then
                prmrow("cSeparadorObservacionIngreso") = DBNull.Value
            Else
                prmrow("cSeparadorObservacionIngreso") = prmobj.cSeparadorObservacionIngreso
            End If

            If prmobj.nPosicionObservacionIngreso = 0 Then
                prmrow("nPosicionObservacionIngreso") = DBNull.Value
            Else
                prmrow("nPosicionObservacionIngreso") = prmobj.nPosicionObservacionIngreso
            End If

            prmrow("bObservacionEgresoPorPosicion") = prmobj.bObservacionEgresoPorPosicion

            If prmobj.nPosIniObservacionEgreso = 0 Then
                prmrow("nPosIniObservacionEgreso") = DBNull.Value
            Else
                prmrow("nPosIniObservacionEgreso") = prmobj.nPosIniObservacionEgreso
            End If

            If prmobj.nPosFinObservacionEgreso = 0 Then
                prmrow("nPosFinObservacionEgreso") = DBNull.Value
            Else
                prmrow("nPosFinObservacionEgreso") = prmobj.nPosFinObservacionEgreso
            End If

            If prmobj.cSeparadorObservacionEgreso = "" Then
                prmrow("cSeparadorObservacionEgreso") = DBNull.Value
            Else
                prmrow("cSeparadorObservacionEgreso") = prmobj.cSeparadorObservacionEgreso
            End If

            If prmobj.nPosicionObservacionEgreso = 0 Then
                prmrow("nPosicionObservacionEgreso") = DBNull.Value
            Else
                prmrow("nPosicionObservacionEgreso") = prmobj.nPosicionObservacionEgreso
            End If

            prmrow("bReferenciaIngresoPorPosicion") = prmobj.bReferenciaIngresoPorPosicion

            If prmobj.nPosIniReferenciaIngreso = 0 Then
                prmrow("nPosIniReferenciaIngreso") = DBNull.Value
            Else
                prmrow("nPosIniReferenciaIngreso") = prmobj.nPosIniReferenciaIngreso
            End If

            If prmobj.nPosFinReferenciaIngreso = 0 Then
                prmrow("nPosFinReferenciaIngreso") = DBNull.Value
            Else
                prmrow("nPosFinReferenciaIngreso") = prmobj.nPosFinReferenciaIngreso
            End If

            If prmobj.cSeparadorReferenciaIngreso = "" Then
                prmrow("cSeparadorReferenciaIngreso") = DBNull.Value
            Else
                prmrow("cSeparadorReferenciaIngreso") = prmobj.cSeparadorReferenciaIngreso
            End If

            If prmobj.nPosicionReferenciaIngreso = 0 Then
                prmrow("nPosicionReferenciaIngreso") = DBNull.Value
            Else
                prmrow("nPosicionReferenciaIngreso") = prmobj.nPosicionReferenciaIngreso
            End If

            prmrow("bReferenciaEgresoPorPosicion") = prmobj.bReferenciaEgresoPorPosicion


            If prmobj.nPosIniReferenciaEgreso = 0 Then
                prmrow("nPosIniReferenciaEgreso") = DBNull.Value
            Else
                prmrow("nPosIniReferenciaEgreso") = prmobj.nPosIniReferenciaEgreso
            End If

            If prmobj.nPosFinReferenciaEgreso = 0 Then
                prmrow("nPosFinReferenciaEgreso") = DBNull.Value
            Else
                prmrow("nPosFinReferenciaEgreso") = prmobj.nPosFinReferenciaEgreso
            End If

            If prmobj.cSeparadorReferenciaEgreso = "" Then
                prmrow("cSeparadorReferenciaEgreso") = DBNull.Value
            Else
                prmrow("cSeparadorReferenciaEgreso") = prmobj.cSeparadorReferenciaEgreso
            End If

            If prmobj.nPosicionReferenciaEgreso = 0 Then
                prmrow("nPosicionReferenciaEgreso") = DBNull.Value
            Else
                prmrow("nPosicionReferenciaEgreso") = prmobj.nPosicionReferenciaEgreso
            End If

            prmrow("bImporteIngresoPorPosicion") = prmobj.bImporteIngresoPorPosicion

            If prmobj.nPosIniImporteIngreso = 0 Then
                prmrow("nPosIniImporteIngreso") = DBNull.Value
            Else
                prmrow("nPosIniImporteIngreso") = prmobj.nPosIniImporteIngreso
            End If

            If prmobj.nPosFinImporteIngreso = 0 Then
                prmrow("nPosFinImporteIngreso") = DBNull.Value
            Else
                prmrow("nPosFinImporteIngreso") = prmobj.nPosFinImporteIngreso
            End If

            If prmobj.cSeparadorImporteIngreso = "" Then
                prmrow("cSeparadorImporteIngreso") = DBNull.Value
            Else
                prmrow("cSeparadorImporteIngreso") = prmobj.cSeparadorImporteIngreso
            End If

            If prmobj.nPosicionImporteIngreso = 0 Then
                prmrow("nPosicionImporteIngreso") = DBNull.Value
            Else
                prmrow("nPosicionImporteIngreso") = prmobj.nPosicionImporteIngreso
            End If

            prmrow("bSinPuntoDecimalImporteIngreso") = prmobj.bSinPuntoDecimalImporteIngreso

            If prmobj.nPosicionesDecimalImporteIngreso = 0 Then
                prmrow("nPosicionesDecimalImporteIngreso") = DBNull.Value
            Else
                prmrow("nPosicionesDecimalImporteIngreso") = prmobj.nPosicionesDecimalImporteIngreso
            End If

            prmrow("bImporteEgresoPorPosicion") = prmobj.bImporteEgresoPorPosicion

            If prmobj.nPosIniImporteEgreso = 0 Then
                prmrow("nPosIniImporteEgreso") = DBNull.Value
            Else
                prmrow("nPosIniImporteEgreso") = prmobj.nPosIniImporteEgreso
            End If

            If prmobj.nPosFinImporteEgreso = 0 Then
                prmrow("nPosFinImporteEgreso") = DBNull.Value
            Else
                prmrow("nPosFinImporteEgreso") = prmobj.nPosFinImporteEgreso
            End If

            If prmobj.cSeparadorImporteEgreso = "" Then
                prmrow("cSeparadorImporteEgreso") = DBNull.Value
            Else
                prmrow("cSeparadorImporteEgreso") = prmobj.cSeparadorImporteEgreso
            End If

            If prmobj.nPosicionImporteEgreso = 0 Then
                prmrow("nPosicionImporteEgreso") = DBNull.Value
            Else
                prmrow("nPosicionImporteEgreso") = prmobj.nPosicionImporteEgreso
            End If

            prmrow("bSinPuntoDecimalImporteEgreso") = prmobj.bSinPuntoDecimalImporteEgreso

            If prmobj.nPosicionesDecimalImporteEgreso = 0 Then
                prmrow("nPosicionesDecimalImporteEgreso") = DBNull.Value

            Else
                prmrow("nPosicionesDecimalImporteEgreso") = prmobj.nPosicionesDecimalImporteEgreso
            End If



            If prmobj.bClaveIngresoPorPosicion = False Then
                prmrow("bClaveIngresoPorPosicion") = DBNull.Value
            Else
                prmrow("bClaveIngresoPorPosicion") = prmobj.bClaveIngresoPorPosicion
            End If

            If prmobj.nPosIniClaveIngreso = 0 Then
                prmrow("nPosIniClaveIngreso") = DBNull.Value
            Else
                prmrow("nPosIniClaveIngreso") = prmobj.nPosIniClaveIngreso
            End If

            If prmobj.nPosFinClaveIngreso = 0 Then
                prmrow("nPosFinClaveIngreso") = DBNull.Value
            Else
                prmrow("nPosFinClaveIngreso") = prmobj.nPosFinClaveIngreso
            End If

            If prmobj.cSeparadorClaveIngreso = "" Then
                prmrow("cSeparadorClaveIngreso") = DBNull.Value
            Else
                prmrow("cSeparadorClaveIngreso") = prmobj.cSeparadorClaveIngreso
            End If

            If prmobj.nPosicionClaveIngreso = 0 Then
                prmrow("nPosicionClaveIngreso") = DBNull.Value
            Else
                prmrow("nPosicionClaveIngreso") = prmobj.nPosicionClaveIngreso
            End If




            If prmobj.bClaveEgresoPorPosicion = False Then
                prmrow("bClaveEgresoPorPosicion") = DBNull.Value
            Else
                prmrow("bClaveEgresoPorPosicion") = prmobj.bClaveEgresoPorPosicion
            End If

            If prmobj.nPosIniClaveEgreso = 0 Then
                prmrow("nPosIniClaveEgreso") = DBNull.Value
            Else
                prmrow("nPosIniClaveEgreso") = prmobj.nPosIniClaveEgreso
            End If

            If prmobj.nPosFinClaveEgreso = 0 Then
                prmrow("nPosFinClaveEgreso") = DBNull.Value
            Else
                prmrow("nPosFinClaveEgreso") = prmobj.nPosFinClaveEgreso
            End If

            If prmobj.cSeparadorClaveEgreso = "" Then
                prmrow("cSeparadorClaveEgreso") = DBNull.Value
            Else
                prmrow("cSeparadorClaveEgreso") = prmobj.cSeparadorClaveEgreso
            End If

            If prmobj.nPosicionClaveEgreso = 0 Then
                prmrow("nPosicionClaveEgreso") = DBNull.Value
            Else
                prmrow("nPosicionClaveEgreso") = prmobj.nPosicionClaveEgreso
            End If

            prmobj.LLenaDatosRegistroComun(prmrow)

            Return prmrow

        End Function

' ''        Public Shared Function ObtenParametrosContabilidad(ByVal prmRow As DataRow) As ClsParametroCnt
' ''            If prmRow Is Nothing Then
' ''                Return Nothing
' ''            End If
' ''            Dim obj As New ClsParametroCnt

' ''            obj.Plaza = Catalogos.FabricaCatalogos.ObtenPlaza(prmRow("nPlaza"))
' ''            obj.Activo = prmRow("bActivo")
' ''            obj.DigNiv1 = prmRow("nDigNiv1")
' ''            obj.DigNiv2 = prmRow("nDigNiv2")
' ''            obj.DigNiv3 = prmRow("nDigNiv3")
' ''            obj.DigNiv4 = prmRow("nDigNiv4")
' ''            obj.DigNiv5 = prmRow("nDigNiv5")
' ''            obj.SeparadorContpaq = prmRow("cSeparadorContpaq")

' ''            obj.CargaDatosRegistro(prmRow)

' ''            Return obj
' ''        End Function

' ''        Public Shared Function ObtenParametrosContabilidad(ByRef prmrow As DataRow, ByVal prmParametrosCnt As ClsParametroCnt) As DataRow
' ''            If prmrow Is Nothing Then
' ''                Return Nothing
' ''            End If

' ''            prmrow("nPlaza") = prmParametrosCnt.Plaza.Folio
' ''            prmrow("bActivo") = prmParametrosCnt.Activo
' ''            prmrow("nDigNiv1") = prmParametrosCnt.DigNiv1
' ''            prmrow("nDigNiv2") = prmParametrosCnt.DigNiv2
' ''            prmrow("nDigNiv3") = prmParametrosCnt.DigNiv3
' ''            prmrow("nDigNiv4") = prmParametrosCnt.DigNiv4
' ''            prmrow("nDigNiv5") = prmParametrosCnt.DigNiv5
' ''            prmrow("cSeparadorContpaq") = prmParametrosCnt.SeparadorContpaq

' ''            prmParametrosCnt.LLenaDatosRegistroComun(prmrow)

' ''            Return prmrow
' ''        End Function


' ''        Public Shared Function ObtenParametrosContabilidad(ByVal prmPlaza As Integer) As ClsParametroCnt
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim dt As New DataTable
' ''            Dim vSql As String = ""

' ''            If prmPlaza = 0 Then
' ''                Return Nothing
' ''            End If

' ''            vSql = "SELECT * from ADSUM_ParametrosContabilidad(nolock) Where nPlaza = " & prmPlaza

' ''            DAO.RegresaConsultaSQL(vSql, dt)

' ''            If dt.Rows.Count = 0 Then
' ''                Return Nothing
' ''            Else
' ''                Return ObtenParametrosContabilidad(dt.Rows(0))
' ''            End If

' ''        End Function

' ''        Public Shared Function ObtenCuentaCnt(ByVal prmFolio As Long) As ClsCuentaCnt
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim dt As New DataTable
' ''            Dim ds As New DataSet
' ''            Dim vsql As String = "Select * From CNT_Cuentas (NOLOCK) where nCuentaCnt =" & prmFolio

' ''            DAO.RegresaEsquemaDeDatos(" Select * From CNT_Cuentas (NOLOCK) where 1=0", dt)

' ''            DAO.RegresaConsultaSQL(vsql, dt)


' ''            If dt.Rows.Count = 0 Then
' ''                Return Nothing
' ''            Else
' ''                Return ObtenCuentaCnt(dt.Rows(0))
' ''            End If

' ''        End Function

' ''        Public Shared Function ObtenCuentaCnt(ByVal prmNivel1 As Integer, ByVal prmNivel2 As Integer, ByVal prmNivel3 As Integer, ByVal prmNivel4 As Integer, ByVal prmNivel5 As Integer) As ClsCuentaCnt
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim DT As New DataTable
' ''            Dim vSQL As String

' ''            vSQL = "Select * From CNT_Cuentas (NOLOCK)"
' ''            vSQL &= vbCrLf & "Where nNivel1 = " & prmNivel1
' ''            vSQL &= vbCrLf & "And nNivel2 = " & prmNivel2
' ''            vSQL &= vbCrLf & "And nNivel3 = " & prmNivel3
' ''            vSQL &= vbCrLf & "And nNivel4 = " & prmNivel4
' ''            vSQL &= vbCrLf & "And nNivel5 = " & prmNivel5

' ''            DAO.RegresaEsquemaDeDatos(" Select * From CNT_Cuentas (NOLOCK) Where 1=0", DT)

' ''            DAO.RegresaConsultaSQL(vSQL, DT)

' ''            If DT.Rows.Count = 0 Then
' ''                Return Nothing
' ''            Else
' ''                Return ObtenCuentaCnt(DT.Rows(0))
' ''            End If

' ''        End Function

' ''        Public Shared Function ObtenCuentaCnt(ByVal prmrow As DataRow) As ClsCuentaCnt
' ''            If prmrow Is Nothing Then
' ''                Return Nothing
' ''            End If
' ''            Dim ret As New ClsCuentaCnt()

' ''            ret.Folio = prmrow("nCuentaCnt")
' ''            ret.Activo = prmrow("bActivo")
' ''            ret.Afecta = prmrow("bAfecta")
' ''            ret.Descripcion = prmrow("cDescripcion")

' ''            If prmrow("nNivel") Is DBNull.Value Then
' ''                ret.Nivel = 0
' ''            Else
' ''                ret.Nivel = prmrow("nNivel")
' ''            End If


' ''            If prmrow("nNivel1") Is DBNull.Value Then
' ''                ret.Nivel1 = 0
' ''            Else
' ''                ret.Nivel1 = prmrow("nNivel1")
' ''            End If

' ''            If prmrow("nNivel2") Is DBNull.Value Then
' ''                ret.Nivel2 = 0
' ''            Else
' ''                ret.Nivel2 = prmrow("nNivel2")
' ''            End If

' ''            If prmrow("nNivel3") Is DBNull.Value Then
' ''                ret.Nivel3 = 0
' ''            Else
' ''                ret.Nivel3 = prmrow("nNivel3")
' ''            End If

' ''            If prmrow("nNivel4") Is DBNull.Value Then
' ''                ret.Nivel4 = 0
' ''            Else
' ''                ret.Nivel4 = prmrow("nNivel4")
' ''            End If

' ''            If prmrow("nNivel5") Is DBNull.Value Then
' ''                ret.Nivel5 = 0
' ''            Else
' ''                ret.Nivel5 = prmrow("nNivel5")
' ''            End If

' ''            If prmrow("nNivelPadre") Is DBNull.Value Then
' ''                ret.nCuentaPadre = Nothing
' ''            Else
' ''                ret.nCuentaPadre = ObtenCuentaCnt(prmrow("nNivelPadre"))
' ''            End If
' ''            ret.cCuentaCnt = prmrow("cCuentaCnt")
' ''            If prmrow("nGrupoContable") Is DBNull.Value Then
' ''                ret.GrupoContable = Nothing
' ''            Else
' ''                ret.GrupoContable = ObtenGrupoContable(prmrow("nGrupoContable"))
' ''            End If
' ''            ret.Naturaleza = IfNull(prmrow("nNaturaleza"), 0)
' ''            ret.CentroCosto = IfNull(prmrow("bCentroCosto"), False)
' ''            ret.CentroCosto = IfNull(prmrow("nOrden"), 0)
' ''            ret.CargaNivelMaximo(prmrow)
' ''            ret.CargaDatosRegistro(prmrow)
' ''            Return ret
' ''        End Function

' ''        Public Shared Function ObtenCuentaCnt(ByRef prmrow As DataRow, ByVal prmobject As ClsCuentaCnt) As DataRow
' ''            If prmrow Is Nothing Then
' ''                Return Nothing
' ''            End If
' ''            If prmobject Is Nothing Then
' ''                Return Nothing
' ''            End If

' ''            prmrow("nCuentaCnt") = prmobject.Folio
' ''            prmrow("bActivo") = prmobject.Activo
' ''            prmrow("bAfecta") = prmobject.Afecta
' ''            prmrow("cDescripcion") = prmobject.Descripcion
' ''            prmrow("nNivel") = prmobject.Nivel
' ''            prmrow("nNivel1") = prmobject.Nivel1
' ''            prmrow("nNivel2") = prmobject.Nivel2
' ''            prmrow("nNivel3") = prmobject.Nivel3
' ''            prmrow("nNivel4") = prmobject.Nivel4
' ''            prmrow("nNivel5") = prmobject.Nivel5

' ''            If prmobject.nCuentaPadre Is Nothing Then
' ''                prmrow("nNivelPadre") = DBNull.Value
' ''            Else
' ''                prmrow("nNivelPadre") = prmobject.nCuentaPadre.Folio
' ''            End If
' ''            prmrow("cCuentaCnt") = prmobject.cCuentaCnt
' ''            If prmobject.GrupoContable Is Nothing Then
' ''                prmrow("nGrupoContable") = DBNull.Value
' ''            Else
' ''                prmrow("nGrupoContable") = prmobject.GrupoContable.Folio
' ''            End If
' ''            prmrow("nNaturaleza") = prmobject.Naturaleza
' ''            prmrow("bCentroCosto") = prmobject.CentroCosto
' ''            prmrow("nOrden") = prmobject.CentroCosto
' ''            prmobject.LLenaDatosRegistroComun(prmrow)
' ''            Return prmrow
' ''        End Function

' ''        Public Shared Function fgActualizaNivelesCnt() As Boolean

' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia

' ''            Return DAO.EjecutaComandoSQL("Exec CNT_ActualizaNivelesMaximo")
' ''        End Function

' ''        Public Shared Function ObtenDetalleConceptoFlujos(ByVal prmRow As DataRow) As ClsConceptoFlujoDetalle
' ''            If prmRow Is Nothing Then
' ''                Return Nothing
' ''            End If

' ''            Dim ret As New ClsConceptoFlujoDetalle

' ''            ret.ConceptoFlujo = prmRow("nConceptoFlujo")
' ''            ret.Porcentaje = prmRow("nPorcentaje")
' ''            ret.Renglon = prmRow("nRenglon")

' ''            If prmRow("nFlujo1") Is DBNull.Value Then
' ''                ret.Flujo1 = Nothing
' ''            Else
' ''                ret.Flujo1 = ObtenFlujoEfectivo(prmRow("nFlujo1"))
' ''            End If

' ''            If prmRow("nFlujo2") Is DBNull.Value Then
' ''                ret.Flujo2 = Nothing
' ''            Else
' ''                ret.Flujo2 = ObtenFlujoEfectivo(prmRow("nFlujo2"))
' ''            End If

' ''            Return ret
' ''        End Function

' ''        Public Shared Function ObtenDetalleConceptoFlujos(ByRef prmRow As DataRow, ByVal prmDetalles As ClsConceptoFlujoDetalle) As DataRow

' ''            If prmRow Is Nothing Then
' ''                Return Nothing
' ''            End If

' ''            prmRow("nConceptoFlujo") = prmDetalles.ConceptoFlujo
' ''            prmRow("nRenglon") = prmDetalles.Renglon
' ''            prmRow("nFlujo1") = prmDetalles.Flujo1.Folio

' ''            If prmDetalles.Flujo2 Is Nothing Then
' ''                prmRow("nFlujo2") = DBNull.Value
' ''            Else
' ''                prmRow("nFlujo2") = prmDetalles.Flujo2.Folio
' ''            End If

' ''            If prmDetalles.Flujo3 Is Nothing Then
' ''                prmRow("nFlujo3") = DBNull.Value
' ''            Else
' ''                prmRow("nFlujo3") = prmDetalles.Flujo3.Folio
' ''            End If


' ''            prmRow("nPorcentaje") = prmDetalles.Porcentaje

' ''            Return prmRow
' ''        End Function

' ''        Public Shared Function ObtenDetalleConceptoFlujos(ByVal prmConceptoFlujo As ClsConceptoFlujo) As DataTable
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim DT As New DataTable
' ''            Dim vSQL As String

' ''            vSQL = "Select * From CTL_ConceptosFlujosDetalle(NoLock) "
' ''            vSQL = vSQL & vbCrLf & "Where nConceptoFlujo = " & prmConceptoFlujo.Folio

' ''            DAO.RegresaEsquemaDeDatos("Select * From CTL_ConceptosFlujosDetalle(NoLock) Where 1 = 0", DT)
' ''            DT.TableName = vNombreDetalleConceptoFlujos
' ''            DAO.RegresaConsultaSQL(vSQL, DT)

' ''            Return DT
' ''        End Function

' ''        Public Shared Function fgObtenDetalleConceptoFlujo(ByVal prmConceptoFlujo As Integer) As DataTable
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim DT As New DataTable
' ''            Dim vSQL As String

' ''            vSQL = "Select F1.cNivel As cNivel1,F2.cNivel As cNivel2,F1.nFlujo As nNivel1,"
' ''            vSQL &= Chr(13) & "F1.cDescripcion As cDescripcionN1,F2.cDescripcion As cDescripcionN2,"
' ''            vSQL &= Chr(13) & "F2.nFlujo As nNivel2,D.nPorcentaje,F3.cNivel As cNivel3,F3.nFlujo As nNivel3,F3.cDescripcion As cDescripcionN3"
' ''            vSQL &= Chr(13) & "From CTL_ConceptosFlujosDetalle D(NOLOCK)"
' ''            vSQL &= Chr(13) & "Join CTL_FlujosEfectivo F1(NoLock) On F1.nFlujo = D.nFlujo1"
' ''            vSQL &= Chr(13) & "Left Join CTL_FlujosEfectivo F2(NoLock) On F2.nFlujo = D.nFlujo2"
' ''            vSQL &= Chr(13) & "Left Join CTL_FlujosEfectivo F3(NoLock) On F3.nFlujo = D.nFlujo3"
' ''            vSQL &= Chr(13) & "Where D.nConceptoFlujo = " & prmConceptoFlujo
' ''            vSQL &= Chr(13) & "Order By nRenglon"

' ''            DAO.RegresaConsultaSQL(vSQL, DT)

' ''            Return DT
' ''        End Function

' ''        'Public Shared Function ObtenCuentasContablesProveedor(ByVal prmRelacion As Proveedores.ClsProveedorCuentasContables) As DataTable
' ''        '    Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''        '    Dim dt As New DataTable
' ''        '    Dim vSql As String = ""
' ''        '    Dim vSqlFiltro As String = ""

' ''        '    If prmRelacion Is Nothing Then
' ''        '        Return Nothing
' ''        '    End If
' ''        '    DAO.RegresaEsquemaDeDatos("Select * From CTL_ProveedoresCuentasContables (NoLock) Where 1=0", dt)

' ''        '    vSqlFiltro = ""
' ''        '    vSql = "Select PCC.* From CTL_ProveedoresCuentasContables PCC (NoLock)" & vbCr

' ''        '    If Not prmRelacion.Proveedor Is Nothing Then
' ''        '        vSqlFiltro &= " PCC.nProveedor = " & prmRelacion.Proveedor.Folio
' ''        '    Else
' ''        '        vSqlFiltro &= " 1 = 0 " & vbCr
' ''        '    End If

' ''        '    If vSqlFiltro.Trim <> "" Then
' ''        '        vSqlFiltro = " Where " & vSqlFiltro
' ''        '    End If

' ''        '    vSql &= vSqlFiltro

' ''        '    DAO.RegresaConsultaSQL(vSql, dt)

' ''        '    If Not dt Is Nothing Then
' ''        '        Return dt
' ''        '    End If

' ''        '    Return Nothing
' ''        'End Function

' ''        Public Shared Function fgObtenPlazasProveedor() As DataTable
' ''            Dim DT As New DataTable
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim vSQL As String
' ''            Dim vResultado As Boolean

' ''            vSQL = "Select 0 As nProveedorCuentaCnt,0 As nProveedor,nPlaza,Convert(Varchar(200),'') As cDescripcionCuentaCnt,"
' ''            vSQL &= Chr(13) & "0 As nCuentaCnt,cDescripcion As cDescripcionPlaza,Convert(Bit,1) As bActivo"
' ''            vSQL &= Chr(13) & "From CTL_Plazas(NoLock)"
' ''            vSQL &= Chr(13) & "Where bActivo = 1"

' ''            vResultado = DAO.RegresaConsultaSQL(vSQL, DT)

' ''            Return DT
' ''        End Function

' ''        Public Shared Function fgObtenFolioLogicoSiguienteMunicipio(ByVal prmEstado As Integer) As Long
' ''            Dim vlsql As String
' ''            Dim DtResultado As New DataTable
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            vlsql = "SELECT MAX(nMunicipio) + 1 as nFolio FROM CTL_Municipios(NOLOCK)" & vbCr
' ''            vlsql &= "WHERE nIDEstado=" & prmEstado.ToString.Trim
' ''            DAO.RegresaConsultaSQL(vlsql, DtResultado)

' ''            If DtResultado.Rows.Count > 0 Then
' ''                Return CType(IIf(DtResultado.Rows(0).Item("nFolio") Is DBNull.Value, 0, DtResultado.Rows(0).Item("nFolio")), Long)
' ''            End If

' ''            Return 1
' ''        End Function
' ''        Public Shared Function fgObtenFolioLogicoSiguienteCiudad(ByVal prmMunicipio As Integer) As Long
' ''            Dim vlsql As String
' ''            Dim DtResultado As New DataTable
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            vlsql = "SELECT MAX(nCiudad) + 1 as nFolio FROM CTL_Ciudades(NOLOCK)" & vbCr
' ''            vlsql &= "WHERE nIDMunicipio=" & prmMunicipio.ToString.Trim
' ''            DAO.RegresaConsultaSQL(vlsql, DtResultado)

' ''            If DtResultado.Rows.Count > 0 Then
' ''                Return CType(IIf(DtResultado.Rows(0).Item("nFolio") Is DBNull.Value, 0, DtResultado.Rows(0).Item("nFolio")), Long)
' ''            End If

' ''            Return 1
' ''        End Function
' ''        Public Shared Function fgObtenFolioLogicoSiguienteColonia(ByVal prmCiudad As Integer) As Long
' ''            Dim vlsql As String
' ''            Dim DtResultado As New DataTable
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            vlsql = "SELECT MAX(nColonia) + 1 as nFolio FROM CTL_Colonias(NOLOCK)" & vbCr
' ''            vlsql &= "WHERE nIDCiudad=" & prmCiudad.ToString.Trim
' ''            DAO.RegresaConsultaSQL(vlsql, DtResultado)

' ''            If DtResultado.Rows.Count > 0 Then
' ''                Return CType(IIf(DtResultado.Rows(0).Item("nFolio") Is DBNull.Value, 0, DtResultado.Rows(0).Item("nFolio")), Long)
' ''            End If


' ''            Return 1
' ''        End Function
' ''        Public Shared Function fgVerificaMovimientosParcialesDeAlmacen(ByVal prmAlmacen As Catalogos.ClsAlmacen) As Boolean
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim vSql As String = ""
' ''            Dim DtResultado As New DataTable
' ''            vSql = "select Top 1 * from INV_MovimientosAlmacen(NOLOCK) WHERE nAlmacenMovimiento = " & prmAlmacen.Folio & " AND bAplicadoParcial=1"
' ''            DAO.RegresaConsultaSQL(vSql, DtResultado)
' ''            If DtResultado.Rows.Count > 0 Then
' ''                Return True
' ''            End If
' ''            Return False
' ''        End Function
' ''        Public Shared Function fgVerificaExistenciasEnAlmacen(ByVal prmAlmacen As Catalogos.ClsAlmacen) As Boolean
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim vSql As String = ""
' ''            Dim DtResultado As New DataTable
' ''            vSql = "SELECT top 1 * FROM INV_Existencias (NOLOCK) WHERE  nAlmacen=" & prmAlmacen.Folio & "and nExistencia<0 "
' ''            DAO.RegresaConsultaSQL(vSql, DtResultado)
' ''            If DtResultado.Rows.Count > 0 Then
' ''                Return True
' ''            End If
' ''            Return False
' ''        End Function
' ''        Public Shared Function fgVerificaAlmacenConsumo(ByVal prmAlmacen As Catalogos.ClsAlmacen) As Boolean
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim vSql As String = ""
' ''            Dim DtResultado As New DataTable
' ''            vSql = "SELECT top 1 * FROM PRO_AlmacenConsumo(NOLOCK) WHERE  nAlmacen=" & prmAlmacen.Folio
' ''            DAO.RegresaConsultaSQL(vSql, DtResultado)
' ''            If DtResultado.Rows.Count > 0 Then
' ''                Return True
' ''            End If
' ''            Return False
' ''        End Function
' ''        Public Shared Function fgVerificaAlmacenConMovimientos(ByVal prmAlmacen As Catalogos.ClsAlmacen) As Boolean
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim vSql As String = ""
' ''            Dim DtResultado As New DataTable
' ''            vSql = "SELECT top 1 * FROM INV_MovimientosAlmacen(NOLOCK)  WHERE  nAlmacenMovimiento=" & prmAlmacen.Folio
' ''            DAO.RegresaConsultaSQL(vSql, DtResultado)
' ''            If DtResultado.Rows.Count > 0 Then
' ''                Return True
' ''            End If

' ''            vSql = ""
' ''            DtResultado.Clear()

' ''            vSql = "SELECT top 1 * FROM PRO_MovimientosAlmacen(NOLOCK) WHERE  nAlmacenMovimiento=" & prmAlmacen.Folio
' ''            DAO.RegresaConsultaSQL(vSql, DtResultado)
' ''            If DtResultado.Rows.Count > 0 Then
' ''                Return True
' ''            End If


' ''            Return False
' ''        End Function

' ''        Public Shared Function ObtenConceptoGasto(ByVal prmConcepto As Integer, Optional ByVal tiempo_real As Boolean = False) As ClsConceptoGasto
' ''            If atrCatalogoConceptosGasto Is Nothing Then atrCatalogoConceptosGasto = New Catalogo(New MetaCatalogo("CTL_ConceptosGastos"))
' ''            Dim vobject As Object = ObtenGenerico(prmConcepto.ToString, atrConceptosGastoinmemory, atrCatalogoConceptosGasto, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenConceptoGasto), tiempo_real)
' ''            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsConceptoGasto))
' ''        End Function

' ''        Public Shared Function ObtenConceptoGasto(Optional ByVal bActivo As Boolean = True) As DataTable
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim dt As New DataTable
' ''            Dim vSql As String = "SELECT * FROM CTL_ConceptosGastos (NOLOCK)" & vbCr

' ''            If bActivo = True Then
' ''                vSql &= "WHERE bActivo = 1" & vbCr
' ''            Else
' ''                vSql &= "WHERE bActivo = 0" & vbCr
' ''            End If

' ''            DAO.RegresaConsultaSQL(vSql, dt)

' ''            Return dt

' ''        End Function

' ''        Public Shared Function ObtenConceptoGasto(ByVal prmrow As DataRow) As ClsConceptoGasto
' ''            If prmrow Is Nothing Then
' ''                Return Nothing
' ''            End If

' ''            Dim ret As New ClsConceptoGasto()
' ''            ret.Folio = prmrow("nConceptoGasto")
' ''            ret.Descripcion = prmrow("cDescripcion")
' ''            ret.Activo = prmrow("bActivo")
' ''            If prmrow("nConceptoFlujo") Is DBNull.Value Then
' ''                ret.ConceptoFlujo = Nothing
' ''            Else
' ''                ret.ConceptoFlujo = ObtenConceptoFlujo(prmrow("nConceptoFlujo"))
' ''            End If
' ''            If prmrow("bClaseRetencionIVA") Is DBNull.Value Then
' ''                ret.ClaseRetencionIVA = False
' ''            Else
' ''                ret.ClaseRetencionIVA = prmrow("bClaseRetencionIVA")
' ''            End If
' ''            If prmrow("nTipoRetencionIVA") Is DBNull.Value Then
' ''                ret.TipoRetencionIVA = 0
' ''            Else
' ''                ret.TipoRetencionIVA = prmrow("nTipoRetencionIVA")
' ''            End If

' ''            If prmrow("bClaseRetencionISR") Is DBNull.Value Then
' ''                ret.ClaseRetencionISR = False
' ''            Else
' ''                ret.ClaseRetencionISR = prmrow("bClaseRetencionISR")
' ''            End If
' ''            If prmrow("nTipoRetencionISR") Is DBNull.Value Then
' ''                ret.TipoRetencionISR = 0
' ''            Else
' ''                ret.TipoRetencionISR = prmrow("nTipoRetencionISR")
' ''            End If

' ''            If prmrow("bTipoGasto") Is DBNull.Value Then
' ''                ret.EsGasto = False
' ''            Else
' ''                ret.EsGasto = prmrow("bTipoGasto")
' ''            End If

' ''            If prmrow("bConceptoDeActivos") Is DBNull.Value Then
' ''                ret.ConceptoDeActivos = False
' ''            Else
' ''                ret.ConceptoDeActivos = prmrow("bConceptoDeActivos")
' ''            End If

' ''            ret.CargaDatosRegistro(prmrow)

' ''            Return ret

' ''        End Function

' ''        Public Shared Function ObtenConceptoGasto(ByRef prmrow As DataRow, ByVal prmobj As ClsConceptoGasto) As DataRow
' ''            If prmrow Is Nothing Then
' ''                Return Nothing
' ''            End If
' ''            If prmobj Is Nothing Then
' ''                Return Nothing
' ''            End If
' ''            prmrow("nConceptoGasto") = prmobj.Folio
' ''            prmrow("cDescripcion") = prmobj.Descripcion
' ''            prmrow("bActivo") = prmobj.Activo
' ''            If prmobj.ConceptoFlujo Is Nothing Then
' ''                prmrow("nConceptoFlujo") = DBNull.Value
' ''            Else
' ''                prmrow("nConceptoFlujo") = prmobj.ConceptoFlujo.Folio
' ''            End If

' ''            prmrow("bClaseRetencionIVA") = prmobj.ClaseRetencionIVA
' ''            If prmobj.TipoRetencionIVA = 0 Then
' ''                prmrow("nTipoRetencionIVA") = DBNull.Value
' ''            Else
' ''                prmrow("nTipoRetencionIVA") = prmobj.TipoRetencionIVA
' ''            End If

' ''            prmrow("bClaseRetencionISR") = prmobj.ClaseRetencionISR
' ''            If prmobj.TipoRetencionISR = 0 Then
' ''                prmrow("nTipoRetencionISR") = DBNull.Value
' ''            Else
' ''                prmrow("nTipoRetencionISR") = prmobj.TipoRetencionISR
' ''            End If

' ''            prmrow("bTipoGasto") = prmobj.EsGasto
' ''            prmrow("bConceptoDeActivos") = prmobj.ConceptoDeActivos

' ''            prmobj.LLenaDatosRegistroComun(prmrow)

' ''            Return prmrow

' ''        End Function

' ''        Public Shared Function ObtenConfiguracionPolizas(ByVal prmConfiguracionTipoPoliza As Integer, Optional ByVal tiempo_real As Boolean = False) As ClsConfiguracionTiposPolizas
' ''            If atrCatalogoConfiguracionTipoPoliza Is Nothing Then atrCatalogoConfiguracionTipoPoliza = New Catalogo(New MetaCatalogo("CNT_ConfiguracionTiposPolizas"))
' ''            Dim vobject As Object = ObtenGenerico(prmConfiguracionTipoPoliza.ToString, atrConfiguracionTipoPolizainmemory, atrCatalogoConfiguracionTipoPoliza, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenConfiguracionPolizas), tiempo_real)
' ''            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsConfiguracionTiposPolizas))
' ''        End Function

' ''        Public Shared Function ObtenConfiguracionPolizas(Optional ByVal bActivo As Boolean = True) As DataTable
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim dt As New DataTable
' ''            Dim vSql As String = "SELECT * FROM CNT_ConfiguracionTiposPolizas (NOLOCK)" & vbCr

' ''            If bActivo = True Then
' ''                vSql &= "WHERE bActivo = 1" & vbCr
' ''            Else
' ''                vSql &= "WHERE bActivo = 0" & vbCr
' ''            End If

' ''            DAO.RegresaConsultaSQL(vSql, dt)

' ''            Return dt

' ''        End Function

' ''        Public Shared Function ObtenConfiguracionPolizas(ByVal prmrow As DataRow) As ClsConfiguracionTiposPolizas
' ''            If prmrow Is Nothing Then
' ''                Return Nothing
' ''            End If

' ''            Dim ret As New ClsConfiguracionTiposPolizas()
' ''            ret.Folio = prmrow("nConfiguracion")
' ''            ret.Descripcion = prmrow("cDescripcion")
' ''            ret.Activo = prmrow("bActivo")

' ''            ret.CargaDatosRegistro(prmrow)

' ''            Return ret

' ''        End Function

' ''        Public Shared Function ObtenConfiguracionPolizas(ByRef prmrow As DataRow, ByVal prmobj As ClsConfiguracionTiposPolizas) As DataRow
' ''            If prmrow Is Nothing Then
' ''                Return Nothing
' ''            End If
' ''            If prmobj Is Nothing Then
' ''                Return Nothing
' ''            End If
' ''            prmrow("nConfiguracion") = prmobj.Folio
' ''            prmrow("cDescripcion") = prmobj.Descripcion
' ''            prmrow("bActivo") = prmobj.Activo

' ''            prmobj.LLenaDatosRegistroComun(prmrow)

' ''            Return prmrow

' ''        End Function

' ''        Public Shared Function ObtenDetalleConfiguracionPolizas(ByVal prmRow As DataRow) As ClsConfiguracionTiposPolizasDetalle
' ''            If prmRow Is Nothing Then
' ''                Return Nothing
' ''            End If

' ''            Dim ret As New ClsConfiguracionTiposPolizasDetalle

' ''            ret.Configuracion = prmRow("nConfiguracion")
' ''            ret.Cancelar = prmRow("bCancelar")
' ''            ret.ContraPoliza = prmRow("bContraPoliza")
' ''            ret.Renglon = prmRow("nOpcion")

' ''            Return ret
' ''        End Function

' ''        Public Shared Function ObtenDetalleConfiguracionPolizas(ByRef prmRow As DataRow, ByVal prmDetalles As ClsConfiguracionTiposPolizasDetalle) As DataRow

' ''            If prmRow Is Nothing Then
' ''                Return Nothing
' ''            End If

' ''            prmRow("nConfiguracion") = prmDetalles.Configuracion
' ''            prmRow("bCancelar") = prmDetalles.Cancelar
' ''            prmRow("bContraPoliza") = prmDetalles.ContraPoliza
' ''            prmRow("nOpcion") = prmDetalles.Renglon

' ''            Return prmRow
' ''        End Function

' ''        Public Shared Function ObtenDetalleConfiguracionPolizas(ByVal prmConfiguracionTipoPoliza As ClsConfiguracionTiposPolizas) As DataTable
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim DT As New DataTable
' ''            Dim vSQL As String

' ''            vSQL = "Select * From CNT_ConfiguracionTiposPolizasDetalle(NoLock) "
' ''            vSQL = vSQL & vbCrLf & "Where nConfiguracion = " & prmConfiguracionTipoPoliza.Folio

' ''            DAO.RegresaEsquemaDeDatos("Select * From CNT_ConfiguracionTiposPolizasDetalle(NoLock) Where 1 = 0", DT)
' ''            DT.TableName = vNombreDetalleConfiguracionPolizas
' ''            DAO.RegresaConsultaSQL(vSQL, DT)

' ''            Return DT
' ''        End Function

' ''        Public Shared Function LlenaDetalleConfiguracionCancelacionPolizas() As DataTable
' ''            Dim DT As New DataTable
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim vSQL As String
' ''            Dim vResultado As Boolean

' ''            vSQL = "Select nValor As nOpcion,Convert(bit,1) As bCancelar,Convert(bit,0) As bContraPoliza"
' ''            vSQL &= vbCrLf & "From ADSUM_TiposDatos"
' ''            vSQL &= vbCrLf & "Where cLlave = 'CNT_CancelacionPolizas'"

' ''            vResultado = DAO.RegresaConsultaSQL(vSQL, DT)

' ''            If DT Is Nothing Then Return Nothing
' ''            If DT.Rows.Count = 0 Then Return Nothing
' ''            Return DT
' ''        End Function


' ''        Public Shared Function ObtenDetalleProyectos(ByVal prmRow As DataRow) As ClsProyectoDetalle
' ''            If prmRow Is Nothing Then
' ''                Return Nothing
' ''            End If

' ''            Dim ret As New ClsProyectoDetalle

' ''            ret.Proyecto = prmRow("nProyecto")
' ''            ret.ProyectoConsecutivo = prmRow("nProyectoConsecutivo")

' ''            If prmRow("nFlujo1") Is DBNull.Value Then
' ''                ret.Flujo1 = Nothing
' ''            Else
' ''                ret.Flujo1 = ObtenFlujoEfectivo(prmRow("nFlujo1"))
' ''            End If

' ''            If prmRow("nFlujo2") Is DBNull.Value Then
' ''                ret.Flujo2 = Nothing
' ''            Else
' ''                ret.Flujo2 = ObtenFlujoEfectivo(prmRow("nFlujo2"))
' ''            End If

' ''            If prmRow("nFlujo3") Is DBNull.Value Then
' ''                ret.Flujo3 = Nothing
' ''            Else
' ''                ret.Flujo3 = ObtenFlujoEfectivo(prmRow("nFlujo3"))
' ''            End If

' ''            ret.Fecha = prmRow("dFecha")
' ''            ret.Importe = prmRow("nImporte")
' ''            ret.Observaciones = prmRow("cObservaciones")
' ''            If prmRow("cUsuario_Registro") Is DBNull.Value Then
' ''                ret.Usuario_Registro = ""
' ''            Else
' ''                ret.Usuario_Registro = prmRow("cUsuario_Registro")
' ''            End If

' ''            ret.Renglon = prmRow("nRenglon")
' ''            ret.RenglonConsecutivo = prmRow("nRenglonConsecutivo")

' ''            Return ret
' ''        End Function

' ''        Public Shared Function ObtenDetalleProyectos(ByRef prmRow As DataRow, ByVal prmDetalles As ClsProyectoDetalle) As DataRow

' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia

' ''            If prmRow Is Nothing Then
' ''                Return Nothing
' ''            End If

' ''            prmRow("nProyecto") = prmDetalles.Proyecto
' ''            prmRow("nProyectoConsecutivo") = prmDetalles.ProyectoConsecutivo


' ''            If prmDetalles.Flujo1 Is Nothing Then
' ''                prmRow("nFlujo1") = DBNull.Value
' ''            Else
' ''                prmRow("nFlujo1") = prmDetalles.Flujo1.Folio
' ''            End If

' ''            If prmDetalles.Flujo2 Is Nothing Then
' ''                prmRow("nFlujo2") = DBNull.Value
' ''            Else
' ''                prmRow("nFlujo2") = prmDetalles.Flujo2.Folio
' ''            End If

' ''            If prmDetalles.Flujo3 Is Nothing Then
' ''                prmRow("nFlujo3") = DBNull.Value
' ''            Else
' ''                prmRow("nFlujo3") = prmDetalles.Flujo3.Folio
' ''            End If

' ''            prmRow("dFecha") = prmDetalles.Fecha
' ''            prmRow("nImporte") = prmDetalles.Importe
' ''            prmRow("cObservaciones") = prmDetalles.Observaciones
' ''            If prmDetalles.Usuario_Registro = "" Then
' ''                prmRow("cUsuario_Registro") = DBNull.Value
' ''            Else
' ''                prmRow("cUsuario_Registro") = prmDetalles.Usuario_Registro
' ''            End If

' ''            prmRow("nRenglon") = prmDetalles.Renglon
' ''            prmRow("nRenglonConsecutivo") = prmDetalles.RenglonConsecutivo

' ''            Return prmRow
' ''        End Function

' ''        Public Shared Function ObtenDetalleProyectos(ByVal prmProyecto As ClsProyecto) As DataTable
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim DT As New DataTable
' ''            Dim vSQL As String

' ''            vSQL = "Select * From CTL_ProyectosDetalle(NoLock) "
' ''            vSQL = vSQL & vbCrLf & "Where nProyecto = " & prmProyecto.Folio

' ''            DAO.RegresaEsquemaDeDatos("Select * From CTL_ProyectosDetalle(NoLock) Where 1 = 0", DT)
' ''            DT.TableName = vNombreDetalleProyectos
' ''            DAO.RegresaConsultaSQL(vSQL, DT)

' ''            Return DT
' ''        End Function

' ''        Public Shared Function fgDetalleDeMovimientoProyecto(ByVal prmProyecto As Integer, ByVal prmProyectoConsecutivo As Long) As DataTable
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim DT As New DataTable
' ''            Dim vSQL As String

' ''            vSQL = "Select F1.cNivel As cNivel1,F2.cNivel As cNivel2,F3.cNivel As cNivel3,PD.nImporte,"
' ''            vSQL = vSQL & vbCrLf & "F1.cDescripcion As cDescripcionN1,F2.cDescripcion As cDescripcionN2,F3.cDescripcion As cDescripcionN3,"
' ''            vSQL = vSQL & vbCrLf & "F1.cDescripcion +'//'+ COALESCE(F2.cDescripcion,'')+'//' + COALESCE(F3.cDescripcion,'') As cDescripcion"
' ''            vSQL = vSQL & vbCrLf & "From CTL_ProyectosDetalle PD(NOLOCK)"
' ''            vSQL = vSQL & vbCrLf & "Join CTL_FlujosEfectivo F1(NoLock) On F1.nFlujo = PD.nFlujo1"
' ''            vSQL = vSQL & vbCrLf & "Left Join CTL_FlujosEfectivo F2(NoLock) On F2.nFlujo = PD.nFlujo2"
' ''            vSQL = vSQL & vbCrLf & "Left Join CTL_FlujosEfectivo F3(NoLock) On F3.nFlujo = PD.nFlujo3"
' ''            vSQL = vSQL & vbCrLf & "Where PD.nProyecto = " & prmProyecto & " And PD.nProyectoConsecutivo = " & prmProyectoConsecutivo

' ''            DAO.RegresaConsultaSQL(vSQL, DT)

' ''            Return DT
' ''        End Function

' ''        Public Shared Function fgObtenNivelDeFlujoYaExistente(ByVal prmValor As String, ByVal prmNivel2 As Boolean, Optional ByVal prmFlujo As Integer = 0) As String

' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim DT As New DataTable
' ''            Dim vSQL As String

' ''            vSQL = "Select Top 1 cDescripcion"
' ''            vSQL = vSQL & vbCrLf & "From CTL_FlujosEfectivo (NOLOCK)"
' ''            vSQL = vSQL & vbCrLf & "Where cNivel = '" & prmValor & "'"

' ''            If prmNivel2 Then
' ''                vSQL = vSQL & vbCrLf & "And nFlujoPadre In (Select nFlujo From CTL_FlujosEfectivo(NoLock) Where nFlujoPadre Is Null)"
' ''            Else
' ''                vSQL = vSQL & vbCrLf & "And nFlujoPadre In (Select nFlujo From CTL_FlujosEfectivo(NoLock) Where nFlujoPadre Is Not Null)"
' ''            End If

' ''            If prmFlujo <> 0 Then
' ''                vSQL = vSQL & vbCrLf & "And nFlujo <> " & prmFlujo
' ''            End If

' ''            DAO.RegresaConsultaSQL(vSQL, DT)

' ''            If DT Is Nothing Then Return ""

' ''            If DT.Rows.Count = 0 Then Return ""

' ''            Return DT.Rows(0).Item(0)
' ''        End Function

' ''        Public Shared Function fgObtenTablaFlujoYaExistente(ByVal prmValor As String, ByVal prmNivel2 As Boolean, ByVal prmFlujo As Integer) As DataTable

' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim DT As New DataTable
' ''            Dim vSQL As String

' ''            vSQL = "Select nFlujo"
' ''            vSQL = vSQL & vbCrLf & "From CTL_FlujosEfectivo (NOLOCK)"
' ''            vSQL = vSQL & vbCrLf & "Where cNivel = '" & prmValor & "'"

' ''            If prmNivel2 Then
' ''                vSQL = vSQL & vbCrLf & "And nFlujoPadre In (Select nFlujo From CTL_FlujosEfectivo(NoLock) Where nFlujoPadre Is Null)"
' ''            Else
' ''                vSQL = vSQL & vbCrLf & "And nFlujoPadre In (Select nFlujo From CTL_FlujosEfectivo(NoLock) Where nFlujoPadre Is Not Null)"
' ''            End If

' ''            If prmFlujo <> 0 Then
' ''                vSQL = vSQL & vbCrLf & "And nFlujo <> " & prmFlujo
' ''            End If

' ''            DAO.RegresaConsultaSQL(vSQL, DT)

' ''            If DT Is Nothing Then Return Nothing

' ''            If DT.Rows.Count = 0 Then Return Nothing

' ''            Return DT
' ''        End Function

' ''        Public Shared Function fgRegresaQueryObtenTablaFlujoYaExistente(ByVal prmValor As String, ByVal prmFlujo As Integer, Optional ByVal prmDescripcion As String = "") As String

' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim DT As New DataTable
' ''            Dim vSQL As String
' ''            Dim vcQuery As String = ""

' ''            vSQL = "Select nFlujo"
' ''            vSQL = vSQL & vbCrLf & "From CTL_FlujosEfectivo (NOLOCK)"
' ''            vSQL = vSQL & vbCrLf & "Where cNivel = '" & prmValor & "'"
' ''            vSQL = vSQL & vbCrLf & "And nFlujoPadre In (Select nFlujo From CTL_FlujosEfectivo(NoLock) Where nFlujoPadre Is Not Null"
' ''            vSQL = vSQL & vbCrLf & "                    And nFlujoPadre In (Select nFlujo From CTL_FlujosEfectivo(NoLock) Where cNivel = '" & DAO.ParametroAdministradoObtener("BAN", "BAN_FLUJOPROYECTODEFAULT") & "'))"


' ''            If prmFlujo <> 0 Then
' ''                vSQL = vSQL & vbCrLf & "And nFlujo <> " & prmFlujo
' ''            End If

' ''            DAO.RegresaConsultaSQL(vSQL, DT)

' ''            If DT Is Nothing Then Return ""

' ''            If DT.Rows.Count = 0 Then Return ""

' ''            vcQuery = "Update CTL_FlujosEfectivo Set cDescripcion = '" & prmDescripcion & "'"
' ''            vcQuery += vbCrLf & "Where nFlujo In ("

' ''            For Each DR As DataRow In DT.Rows
' ''                vcQuery += DR("nFlujo") & ","
' ''            Next

' ''            vcQuery = Mid(vcQuery, 1, vcQuery.Length - 1) & ")"
' ''            Return vcQuery
' ''        End Function

' ''        Public Shared Function fgObtenTablaFlujosClonar(ByVal prmPadre As Integer, Optional ByVal prmFlujo As String = "") As DataTable
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim DT As New DataTable
' ''            Dim vSQL As String
' ''            Dim vSplit() As String
' ''            If Not prmFlujo = "" AndAlso Not prmFlujo Is Nothing Then
' ''                vSplit = prmFlujo.Split(",")
' ''            End If
' ''            vSQL = "Select nFlujo,cNivel"
' ''            vSQL = vSQL & vbCrLf & "From CTL_FlujosEfectivo (NOLOCK)"
' ''            vSQL = vSQL & vbCrLf & "Where nFlujoPadre = " & prmPadre
' ''            If prmFlujo <> "" Then
' ''                vSQL = vSQL & " And cNivel In ("
' ''                For i As Integer = 0 To vSplit.Length - 1
' ''                    vSQL = vSQL & "'" & vSplit(i) & "'" & ","
' ''                Next
' ''                vSQL = Mid(vSQL, 1, vSQL.Length - 1)
' ''                vSQL = vSQL & ") "
' ''            End If


' ''            DAO.RegresaConsultaSQL(vSQL, DT)
' ''            If DT Is Nothing Then Return Nothing
' ''            If DT.Rows.Count = 0 Then Return Nothing
' ''            Return DT
' ''        End Function

' ''        Public Shared Function fgObtenFlujosVarios(ByVal prmText As String, ByVal prmFlujoPadre As Integer) As DataTable
' ''            Dim DS As New DataSet
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim arg(1) As Object
' ''            arg(0) = prmText
' ''            arg(1) = prmFlujoPadre
' ''            DAO.RegresaConsultaSQL("BAN_ObtenFlujosVarios", DS, arg)
' ''            If DS Is Nothing Then Return Nothing
' ''            If DS.Tables.Count = 0 Then Return Nothing
' ''            Return DS.Tables(0)
' ''        End Function

' ''        Public Shared Function ObtenGrupoContable(ByVal prmGrupoContable As Integer, Optional ByVal tiempo_real As Boolean = False) As ClsGrupoContable
' ''            If atrCatalogoGrupoContable Is Nothing Then atrCatalogoGrupoContable = New Catalogo(New MetaCatalogo("CTL_GruposContables"))
' ''            Dim vobject As Object = ObtenGenerico(prmGrupoContable.ToString, atrGrupoContableinmemory, atrCatalogoGrupoContable, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenGrupoContable), tiempo_real)
' ''            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsGrupoContable))
' ''        End Function

' ''        Public Shared Function ObtenGrupoContable(Optional ByVal bActivo As Boolean = True) As DataTable
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim dt As New DataTable
' ''            Dim vSql As String = "SELECT * FROM CTL_GruposContables (NOLOCK)" & vbCr

' ''            If bActivo = True Then
' ''                vSql &= "WHERE bActivo = 1" & vbCr
' ''            Else
' ''                vSql &= "WHERE bActivo = 0" & vbCr
' ''            End If

' ''            DAO.RegresaConsultaSQL(vSql, dt)

' ''            Return dt

' ''        End Function

' ''        Public Shared Function ObtenGrupoContable(ByVal prmrow As DataRow) As ClsGrupoContable
' ''            If prmrow Is Nothing Then
' ''                Return Nothing
' ''            End If
' ''            Dim ret As New ClsGrupoContable(prmrow("nGrupoContable"))
' ''            ret.Descripcion = prmrow("cDescripcion")
' ''            ret.Activo = prmrow("bActivo")
' ''            ret.TipoCuenta = prmrow("nTipoCuenta")
' ''            ret.Naturaleza = prmrow("nNaturaleza")
' ''            ret.CargaDatosRegistro(prmrow)
' ''            Return ret
' ''        End Function

' ''        Public Shared Function ObtenGrupoContable(ByRef prmrow As DataRow, ByVal prmobj As ClsGrupoContable) As DataRow
' ''            If prmrow Is Nothing Then
' ''                Return Nothing
' ''            End If
' ''            If prmobj Is Nothing Then
' ''                Return Nothing
' ''            End If
' ''            prmrow("nGrupoContable") = prmobj.Folio
' ''            prmrow("cDescripcion") = prmobj.Descripcion
' ''            prmrow("nTipoCuenta") = prmobj.TipoCuenta
' ''            prmrow("nNaturaleza") = prmobj.Naturaleza
' ''            prmrow("bActivo") = prmobj.Activo
' ''            prmobj.LLenaDatosRegistroComun(prmrow)
' ''            Return prmrow
' ''        End Function

' ''        Public Shared Function ObtenOrdenMaximo(ByVal prmTabla As String) As Integer
' ''            If prmTabla = "" Then Return 0
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim vSQL As String
' ''            vSQL = "Select Coalesce(Max(nOrden),0) From " & prmTabla & "(NoLock)"
' ''            Return DAO.RegresaDatoSQL(vSQL)
' ''        End Function


' ''        Protected Overrides Sub Finalize()
' ''            MyBase.Finalize()
' ''        End Sub


' ''        Public Shared Function ValidaNoExistaCodigoCorto(ByVal prmProducto As String, ByVal prmCodigoCorto As String) As Boolean
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim dt As New DataTable
' ''            Dim vcSQLTEXT As String = "SELECT nProducto,cCodigo FROM CTL_Productos (NOLOCK) " & vbCr
' ''            vcSQLTEXT &= " WHERE bActivo = 1 AND NOT cCodigo = '" & prmProducto & "'" & vbCr
' ''            vcSQLTEXT &= " AND cCodigoCorto = '" & prmCodigoCorto & "'" & vbCr
' ''            DAO.RegresaConsultaSQL(vcSQLTEXT, dt)
' ''            If dt Is Nothing OrElse dt.Rows.Count = 0 Then Return True
' ''            Return False
' ''        End Function

' ''        Public Shared Function ValidaNoExistaIdentificador(ByVal prmProducto As String, ByVal prmIdentificador As String) As Boolean
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim dt As New DataTable
' ''            Dim vcSQLTEXT As String = "SELECT nProducto,cCodigo FROM CTL_Productos (NOLOCK) " & vbCr
' ''            vcSQLTEXT &= " WHERE bActivo = 1 AND NOT cCodigo = '" & prmProducto & "'" & vbCr
' ''            vcSQLTEXT &= " AND cIdentificador = '" & prmIdentificador & "'" & vbCr
' ''            DAO.RegresaConsultaSQL(vcSQLTEXT, dt)
' ''            If dt Is Nothing OrElse dt.Rows.Count = 0 Then Return True
' ''            Return False
' ''        End Function

' ''        Public Shared Function fgProcesaQueryWS(ByVal prmQuery As String, ByRef prmError As String, ByVal prmADDA As DataAccessCls) As Boolean

' ''            Dim ws As New WsComun.Comun

' ''            If AlmacenControladorEsCorporativo() Then
' ''                Dim dtplazas As New DataTable
' ''                prmADDA.RegresaConsultaSQL("Select cUrlComun From WS_PlazaURL (NoLock)", dtplazas)
' ''                For Each vrow As DataRow In dtplazas.Rows
' ''                    ws.Url = vrow("cUrlComun")
' ''                    If Dominio.Comun.ClsTools.fgExisteLineaWebService(ws.Url, "Select GetDate()") Then
' ''                        If Not ws.EjecutaComandoSQL(prmQuery) Then
' ''                            prmError = GlobalSistemaLineaCorporativoNO
' ''                        End If
' ''                    Else
' ''                        prmError = GlobalSistemaLineaCorporativoNO
' ''                        Return False
' ''                    End If
' ''                Next
' ''            Else
' ''                ws.Url = prmADDA.ParametroAdministradoObtener("PRM", "WSCORPORATIVO") & prmADDA.ParametroAdministradoObtener("PRM", "WSCOMUN")
' ''                If Dominio.Comun.ClsTools.fgExisteLineaWebService(ws.Url, "Select GetDate()") Then
' ''                    Try
' ''                        ws.EjecutaComandoSQL(prmQuery)
' ''                    Catch ex As Exception
' ''                        prmError = GlobalSistemaLineaCorporativoNO
' ''                        Return False
' ''                    End Try
' ''                End If
' ''            End If

' ''            Return prmError = ""
' ''        End Function

' ''        Public Shared Function fgRegresaPlazasCatalogos() As DataTable
' ''            Dim DAO As DataAccessCls
' ''            Dim vDt_Plazas As DataTable

' ''            vDt_Plazas = New DataTable
' ''            DAO = DataAccessCls.DevuelveInstancia
' ''            DAO.RegresaConsultaSQL("Select cUrlCatalogos From WS_PlazaURL (NoLock)", vDt_Plazas)

' ''            Return vDt_Plazas
' ''        End Function

' ''        Public Shared Function FgQueryHeredaPresupuestoAFlujoHijo(ByVal PrmFlujoHijo As Integer, ByVal PrmEjercicio As Integer, ByVal prmNivel As Integer, ByVal DAO As DataAccessCls) As String
' ''            Return "SP_BAN_HeredaPresupuestoAFlujoHijo " & PrmFlujoHijo & "," & PrmEjercicio & "," & prmNivel & ",'" & DAO.GetLoginUsuario & "'"
' ''        End Function

' ''        Public Shared Function ObtenDetalleBeneficiarios(ByVal prmRow As DataRow) As ClsBeneficiarioDetalle
' ''            If prmRow Is Nothing Then
' ''                Return Nothing
' ''            End If

' ''            Dim ret As New ClsBeneficiarioDetalle

' ''            ret.Beneficiario = prmRow("nBeneficiario")
' ''            ret.Renglon = prmRow("nRenglon")

' ''            If prmRow("nCuentaCnt") Is DBNull.Value Then
' ''                ret.CuentaCnt = Nothing
' ''            Else
' ''                ret.CuentaCnt = ObtenCuentaCnt(prmRow("nCuentaCnt"))
' ''            End If

' ''            Return ret
' ''        End Function

' ''        Public Shared Function ObtenDetalleBeneficiarios(ByRef prmRow As DataRow, ByVal prmDetalles As ClsBeneficiarioDetalle) As DataRow

' ''            If prmRow Is Nothing Then
' ''                Return Nothing
' ''            End If

' ''            prmRow("nBeneficiario") = prmDetalles.Beneficiario
' ''            prmRow("nRenglon") = prmDetalles.Renglon

' ''            If prmDetalles.CuentaCnt Is Nothing Then
' ''                prmRow("nCuentaCnt") = DBNull.Value
' ''            Else
' ''                prmRow("nCuentaCnt") = prmDetalles.CuentaCnt.Folio
' ''            End If

' ''            Return prmRow
' ''        End Function

' ''        Public Shared Function ObtenDetalleBeneficiarios(ByVal prmBeneficiario As ClsBeneficiario) As DataTable
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim DT As New DataTable
' ''            Dim vSQL As String

' ''            vSQL = "Select * From CTL_BeneficiariosDetalle(NoLock) "
' ''            vSQL = vSQL & vbCrLf & "Where nBeneficiario = " & prmBeneficiario.Folio

' ''            DAO.RegresaEsquemaDeDatos("Select * From CTL_BeneficiariosDetalle(NoLock) Where 1 = 0", DT)
' ''            DT.TableName = vNombreDetalleBeneficiarios
' ''            DAO.RegresaConsultaSQL(vSQL, DT)

' ''            Return DT
' ''        End Function

' ''        Public Shared Function ObtenDetalleConceptosGastos(ByVal prmRow As DataRow) As ClsConceptoGastoDetalle
' ''            If prmRow Is Nothing Then
' ''                Return Nothing
' ''            End If

' ''            Dim ret As New ClsConceptoGastoDetalle

' ''            ret.ConceptoGasto = prmRow("nConceptoGasto")
' ''            ret.Renglon = prmRow("nRenglon")

' ''            If prmRow("nCuentaCnt") Is DBNull.Value Then
' ''                ret.CuentaCnt = Nothing
' ''            Else
' ''                ret.CuentaCnt = ObtenCuentaCnt(prmRow("nCuentaCnt"))
' ''            End If

' ''            Return ret
' ''        End Function

' ''        Public Shared Function ObtenDetalleConceptosGastos(ByRef prmRow As DataRow, ByVal prmDetalles As ClsConceptoGastoDetalle) As DataRow

' ''            If prmRow Is Nothing Then
' ''                Return Nothing
' ''            End If

' ''            prmRow("nConceptoGasto") = prmDetalles.ConceptoGasto
' ''            prmRow("nRenglon") = prmDetalles.Renglon

' ''            If prmDetalles.CuentaCnt Is Nothing Then
' ''                prmRow("nCuentaCnt") = DBNull.Value
' ''            Else
' ''                prmRow("nCuentaCnt") = prmDetalles.CuentaCnt.Folio
' ''            End If

' ''            Return prmRow
' ''        End Function

' ''        Public Shared Function ObtenDetalleConceptosGastos(ByVal prmConceptoGasto As ClsConceptoGasto) As DataTable
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim DT As New DataTable
' ''            Dim vSQL As String

' ''            vSQL = "Select * From CTL_ConceptosGastosDetalle(NoLock) "
' ''            vSQL = vSQL & vbCrLf & "Where nConceptoGasto = " & prmConceptoGasto.Folio

' ''            DAO.RegresaEsquemaDeDatos("Select * From CTL_ConceptosGastosDetalle(NoLock) Where 1 = 0", DT)
' ''            DT.TableName = vNombreDetalleConceptosGastos
' ''            DAO.RegresaConsultaSQL(vSQL, DT)

' ''            Return DT
' ''        End Function


' ''        Public Shared Function ObtenDetalleProveedoresBancos(ByVal prmRow As DataRow) As ClsProveedoresBancosDetalle
' ''            If prmRow Is Nothing Then
' ''                Return Nothing
' ''            End If

' ''            Dim ret As New ClsProveedoresBancosDetalle

' ''            ret.Proveedor = prmRow("nProveedor")
' ''            ret.Renglon = prmRow("nRenglon")

' ''            If prmRow("nCuentaCnt") Is DBNull.Value Then
' ''                ret.CuentaCnt = Nothing
' ''            Else
' ''                ret.CuentaCnt = ObtenCuentaCnt(prmRow("nCuentaCnt"))
' ''            End If

' ''            Return ret
' ''        End Function

' ''        Public Shared Function ObtenDetalleProveedoresBancos(ByRef prmRow As DataRow, ByVal prmDetalles As ClsProveedoresBancosDetalle) As DataRow

' ''            If prmRow Is Nothing Then
' ''                Return Nothing
' ''            End If

' ''            prmRow("nProveedor") = prmDetalles.Proveedor
' ''            prmRow("nRenglon") = prmDetalles.Renglon

' ''            If prmDetalles.CuentaCnt Is Nothing Then
' ''                prmRow("nCuentaCnt") = DBNull.Value
' ''            Else
' ''                prmRow("nCuentaCnt") = prmDetalles.CuentaCnt.Folio
' ''            End If

' ''            Return prmRow
' ''        End Function

' ''        Public Shared Function ObtenDetalleProveedoresBancos(ByVal prmProveedor As ClsProveedoresBancos) As DataTable
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim DT As New DataTable
' ''            Dim vSQL As String

' ''            vSQL = "Select * From CTL_ProveedoresCuentasContables(NoLock) "
' ''            vSQL = vSQL & vbCrLf & "Where nProveedor = " & prmProveedor.Folio

' ''            DAO.RegresaEsquemaDeDatos("Select * From CTL_ProveedoresCuentasContables(NoLock) Where 1 = 0", DT)
' ''            DT.TableName = vNombreDetalleProveedores
' ''            DAO.RegresaConsultaSQL(vSQL, DT)

' ''            Return DT
' ''        End Function

' ''        Public Shared Function ObtenDetalleClientesBancos(ByVal prmRow As DataRow) As ClsClientesBancosDetalle
' ''            If prmRow Is Nothing Then
' ''                Return Nothing
' ''            End If

' ''            Dim ret As New ClsClientesBancosDetalle

' ''            ret.Cliente = prmRow("nCliente")
' ''            ret.Renglon = prmRow("nRenglon")

' ''            If prmRow("nCuentaCnt") Is DBNull.Value Then
' ''                ret.CuentaCnt = Nothing
' ''            Else
' ''                ret.CuentaCnt = ObtenCuentaCnt(prmRow("nCuentaCnt"))
' ''            End If

' ''            Return ret
' ''        End Function

' ''        Public Shared Function ObtenDetalleClientesBancos(ByRef prmRow As DataRow, ByVal prmDetalles As ClsClientesBancosDetalle) As DataRow

' ''            If prmRow Is Nothing Then
' ''                Return Nothing
' ''            End If

' ''            prmRow("nCliente") = prmDetalles.Cliente
' ''            prmRow("nRenglon") = prmDetalles.Renglon

' ''            If prmDetalles.CuentaCnt Is Nothing Then
' ''                prmRow("nCuentaCnt") = DBNull.Value
' ''            Else
' ''                prmRow("nCuentaCnt") = prmDetalles.CuentaCnt.Folio
' ''            End If

' ''            Return prmRow
' ''        End Function

' ''        Public Shared Function ObtenDetalleClientesBancos(ByVal prmCliente As ClsClientesBancos) As DataTable
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim DT As New DataTable
' ''            Dim vSQL As String

' ''            vSQL = "Select * From CTL_ClientesCuentasContables(NoLock) "
' ''            vSQL = vSQL & vbCrLf & "Where nCliente = " & prmCliente.Folio

' ''            DAO.RegresaEsquemaDeDatos("Select * From CTL_ClientesCuentasContables(NoLock) Where 1 = 0", DT)
' ''            DT.TableName = vNombreDetalleClientes
' ''            DAO.RegresaConsultaSQL(vSQL, DT)

' ''            Return DT
' ''        End Function


' ''        Public Shared Function ObtenClienteBancos(ByVal prmCliente As Integer, Optional ByVal tiempo_real As Boolean = False) As ClsClientesBancos
' ''            If atrCatalogoClientesBancos Is Nothing Then atrCatalogoClientesBancos = New Catalogo(New MetaCatalogo("CTL_ClientesBancos"))
' ''            Dim vobject As Object = ObtenGenerico(prmCliente.ToString, atrClientesinmemory, atrCatalogoClientesBancos, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenClienteBancos), tiempo_real)
' ''            Return IIf(vobject Is Nothing, Nothing, CType(vobject, ClsClientesBancos))
' ''        End Function

' ''        Public Shared Function ObtenClienteBancos(Optional ByVal bActivo As Boolean = True) As DataTable
' ''            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
' ''            Dim dt As New DataTable
' ''            Dim vSql As String = "SELECT * FROM CTL_Clientes (NOLOCK)" & vbCr

' ''            If bActivo = True Then
' ''                vSql &= "WHERE bActivo = 1" & vbCr
' ''            Else
' ''                vSql &= "WHERE bActivo = 0" & vbCr
' ''            End If

' ''            DAO.RegresaConsultaSQL(vSql, dt)

' ''            Return dt

' ''        End Function

' ''        Public Shared Function ObtenClienteBancos(ByVal prmrow As DataRow) As ClsClientesBancos
' ''            If prmrow Is Nothing Then
' ''                Return Nothing
' ''            End If

' ''            Dim ret As New ClsClientesBancos()
' ''            ret.Folio = prmrow("nCliente")
' ''            ret.NombreFiscal = prmrow("cNombreFiscal")
' ''            ret.NombreComercial = prmrow("cNombreComercial")
' ''            If prmrow("cRFC") Is DBNull.Value Then
' ''                ret.RFC = ""
' ''            Else
' ''                ret.RFC = prmrow("cRFC")
' ''            End If


' ''            If prmrow("nPlaza") Is DBNull.Value Then
' ''                ret.PlazaRegistro = Nothing
' ''            Else
' ''                ret.PlazaRegistro = ObtenPlaza(prmrow("nPlaza"))
' ''            End If

' ''            ret.Activo = prmrow("bActivo")

' ''            ret.CargaDatosRegistro(prmrow)

' ''            Return ret

' ''        End Function

' ''        Public Shared Function ObtenClienteBancos(ByRef prmrow As DataRow, ByVal prmobj As ClsClientesBancos) As DataRow
' ''            If prmrow Is Nothing Then
' ''                Return Nothing
' ''            End If
' ''            If prmobj Is Nothing Then
' ''                Return Nothing
' ''            End If
' ''            prmrow("nCliente") = prmobj.Folio
' ''            prmrow("cNombreFiscal") = prmobj.NombreFiscal
' ''            prmrow("cNombreComercial") = prmobj.NombreComercial
' ''            prmrow("cRFC") = prmobj.RFC

' ''            If prmobj.PlazaRegistro Is Nothing Then
' ''                prmrow("nPlaza") = DBNull.Value
' ''            Else
' ''                prmrow("nPlaza") = prmobj.PlazaRegistro.Folio
' ''            End If

' ''            prmrow("bActivo") = prmobj.Activo

' ''            prmobj.LLenaDatosRegistroComun(prmrow)

' ''            Return prmrow

        ' ''        End Function



        Public Shared Function fgClaveProveedor(ByVal prmRFC As String, ByVal prmCodigoPostal As String, ByVal prmPais As String, ByVal prmEstado As String, _
                                                ByVal prmMunicipio As String, ByVal prmLocalidad As String, ByVal prmColonia As String, _
                                                ByVal prmNoExterior As String, ByVal prmCalle As String, ByVal prmNombre As String) As String



            Dim vParam(9) As Object
            Dim vlSQL As String
            Dim DS As New DataSet
            Dim DAO As Sistema.DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vcClave As String = ""

            Try

                vParam(0) = prmRFC
                vParam(1) = prmCodigoPostal
                vParam(2) = prmPais
                vParam(3) = prmEstado
                vParam(4) = prmMunicipio
                vParam(5) = prmLocalidad
                vParam(6) = prmColonia
                vParam(7) = prmNoExterior
                vParam(8) = prmCalle
                vParam(9) = prmNombre

                vlSQL = "SPPROVEEDORESFE"

                If Not DAO.RegresaConsultaSQL(vlSQL, DS, vParam) Then
                    Return ""
                End If

                If Not DS Is Nothing AndAlso DS.Tables.Count > 0 AndAlso DS.Tables(0).Rows.Count > 0 Then
                    vcClave = DS.Tables(0).Rows(0).Item(0)
                End If

            Catch ex As Exception
                Return ""
            End Try

            Return vcClave

        End Function


        Public Shared Function fgRegistraCxpFromXML(ByVal prmProveedor As String, ByVal prmMoneda As String, ByVal prmFecha As Date, ByVal prmSerie As String, _
                                                    ByVal prmFolio As String, ByVal prmParidad As Decimal, ByVal prmSubtotal As Decimal, ByVal prmImpuestos As Decimal, _
                                                    ByVal prmTotal As Decimal, ByVal prmDTConceptos As DataTable, ByVal prmDTTraslados As DataTable, _
                                                    ByVal prmRutaXML As String, ByVal prmRutaPDF As String, ByVal prmRFC As String) As Boolean

            Dim vParam(9) As Object
            Dim vlSQL As String
            Dim DS As New DataSet
            Dim DAO As Sistema.DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vcMoneda As String
            Dim vcFactura As String

            vcFactura = fgPonceros(prmSerie.Trim + prmFolio.Trim, 15)
            vcMoneda = fgRegresaMoneda(prmMoneda)

            If vcMoneda Is Nothing Then
                vcMoneda = "01"
            End If

            DAO.AbreTransaccion()
            Try

                vParam(0) = prmProveedor
                vParam(1) = vcMoneda
                vParam(2) = prmFecha
                vParam(3) = vcFactura
                vParam(4) = prmTotal
                vParam(5) = prmImpuestos
                vParam(6) = prmParidad
                vParam(7) = prmRutaXML
                vParam(8) = prmRutaPDF
                vParam(9) = prmRFC

                vlSQL = "SPINSERTAMOVTOCXPFRMXML"

                If Not DAO.RegresaConsultaSQL(vlSQL, DS, vParam) Then
                    If DAO.TieneTransaccionAbierta Then
                        DAO.DeshaceTransaccion()
                    End If
                    Return False
                End If

            Catch ex As Exception
                If DAO.TieneTransaccionAbierta Then
                    DAO.DeshaceTransaccion()
                    MuestraMensajeSistFact(ex.Message, MessageBoxIcon.Information)
                End If
                Return False
            End Try

            If DAO.TieneTransaccionAbierta Then
                DAO.CierraTransaccion()
            End If
            Return True


        End Function

        Public Shared Function fgRegresaMoneda(ByVal prmNombre As String) As String

            Dim vcSQL As String
            Dim DAO As Sistema.DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vcMoneda As String

            vcSQL = "SELECT * FROM CTL_MONEDAS(NOLOCK)"
            vcSQL = vcSQL & vbCrLf & "WHERE CABREVIAXML = '" & Strings.UCase(prmNombre) & "' OR UPPER(CNOMBRE) = '" & Strings.UCase(prmNombre) & "'"

            vcMoneda = DAO.RegresaDatoSQL(vcSQL)

            Return vcMoneda
        End Function

    End Class
End Namespace
