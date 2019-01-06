Imports Access.Comunes.Comun
Imports Access.Comunes
Imports Access

Namespace Comunes.Comun
    Public Class ClsToolsAccTextBoxAdvanced

        Public Shared DAO As DataAccessCls = DataAccessCls.DevuelveInstancia

#Region "Enumeraciones"
        'Enum para conocer el tipo de metacatálogo para el AccTextBoxAdvanced
        Public Enum TipoMetacatalogo
            TipoArticulo = 0
            LineaArticulo
            Articulo
            Proveedores
            Almacen
            Cliente
            Marca
            Empleado
            Plaza
            Sucursal
            LineaProducto
            Producto
            ClavesCodigosBarra
            TipoProducto
            UnidadProducto
            ProveedoresContabilidad
        End Enum
#End Region

#Region "Valida AccTextBoxAdvanced y Obten Clase"
        ' <summary>
        ' Función para validar si el elemento tecleado en un AccTextBoxAdvanced es Válido
        ' </summary>
        ' <param name="prmATX">AccTextBoxAdvanced a validar</param>
        ' <returns>Regresa True en caso de validar correctamente y False en caso contrario</returns>
        ' <remarks></remarks>
        Public Shared Function ValidaElemento(ByRef prmATX As AccTextBoxAdvanced, Optional ByVal prmMuestraMensajeCodigoInvalido As Boolean = True) As Boolean
            If prmATX.Text.Trim = "" Then Return True
            If prmATX.ValidayObtenDescripcion.Trim = "" Then
                If prmMuestraMensajeCodigoInvalido Then MensajeCodigoInvalido()
                prmATX.Text = ""
                Return False
            End If
            Return True
        End Function
        Public Shared Function EsUnicoElemento(ByRef prmATX As AccTextBoxAdvanced) As Boolean
            Return ClsTools.FGValidaUnicoElemento_en_ATXMultiple(prmATX.Text.Trim)
        End Function

        Public Shared Function DevuelveElementosSeleccionados(ByRef prmATX As AccTextBoxAdvanced) As String
            If prmATX.Text.Trim = "" Then Return ""
            Dim vElementos As String = ""
            For Each vStr In prmATX.Text.Trim.Split(",")
                vElementos &= vStr.Trim & ","
            Next
            If Not vElementos.Trim = "" Then vElementos.Substring(0, vElementos.Length - 1)
            Return vElementos
        End Function

        ' <summary>
        ' Función para obtener una clase de acuerdo al valor del AccTextBoxAdvanced
        ' </summary>
        ' <param name="prmATX">AccTextBoxAdvanced del que se tomará el valor para obtener la clase</param>
        ' <param name="prmTipoObten">Tipo de obtén a realizar para obtener la clase</param>
        ' <returns>Regresa un objeto del tipo que se le haya indicado</returns>
        ' <remarks></remarks>
        Public Shared Function ObtenObjeto(ByRef prmATX As AccTextBoxAdvanced, ByVal prmTipoObten As TipoMetacatalogo) As Object
            If prmATX.Text.Trim = "" Then Return Nothing
            Select Case prmTipoObten
                ' ''Case TipoMetacatalogo.TipoProducto
                ' ''    Return Catalogos.FabricaCatalogos.ObtenTipoProducto(prmATX.Text.Trim)
                ' ''Case TipoMetacatalogo.Producto
                ' ''    Return Catalogos.FabricaCatalogos.ObtenProducto(prmATX.Text.Trim)
                ' ''Case TipoMetacatalogo.ClavesCodigosBarra
                ' ''    Return Catalogos.FabricaCatalogos.ObtenCodigoProduccion(prmATX.Text.Trim)
                ' ''Case TipoMetacatalogo.LineaProducto
                ' ''    Return Catalogos.FabricaCatalogos.ObtenLineaProducto(prmATX.Text.Trim)
                ' ''Case TipoMetacatalogo.TipoArticulo
                ' ''    Return Catalogos.FabricaCatalogos.ObtenTipoArticulo(prmATX.Text.Trim)
                ' ''Case TipoMetacatalogo.LineaArticulo
                ' ''    Return Catalogos.FabricaCatalogos.ObtenLinea(prmATX.Text.Trim)
                ' ''Case TipoMetacatalogo.Articulo
                ' ''    Return Catalogos.FabricaCatalogos.ObtenArticulo(prmATX.Text.Trim)
                ' ''Case TipoMetacatalogo.Proveedores
                ' ''    Return Catalogos.FabricaCatalogos.ObtenProveedor(prmATX.Text.Trim)
                ' ''Case TipoMetacatalogo.ProveedoresContabilidad
                ' ''    Return Catalogos.FabricaCatalogos.ObtenProveedor(prmATX.Text.Trim)
                ' ''Case TipoMetacatalogo.Almacen
                ' ''    Return Catalogos.FabricaCatalogos.ObtenAlmacen(prmATX.Text.Trim)
                ' ''Case TipoMetacatalogo.Cliente
                ' ''    Return Catalogos.FabricaCatalogos.ObtenCliente(prmATX.Text.Trim)
                ' ''Case TipoMetacatalogo.Plaza
                ' ''    Return Catalogos.FabricaCatalogos.ObtenPlaza(prmATX.Text.Trim)
                ' ''Case TipoMetacatalogo.Marca
                ' ''    Return Catalogos.FabricaCatalogos.ObtenMarca(prmATX.Text.Trim)
                ' ''Case TipoMetacatalogo.Empleado
                ' ''    Return Catalogos.FabricaCatalogos.ObtenEmpleado(prmATX.Text.Trim)
                ' ''Case TipoMetacatalogo.Sucursal
                ' ''    Return Catalogos.FabricaCatalogos.ObtenSucursal(prmATX.Text.Trim)
                Case Else
                    Return Nothing
            End Select
        End Function

        ' <summary>
        ' Muestra mensaje indicando que el código no existe
        ' </summary>
        ' <remarks></remarks>
        Public Shared Sub MensajeCodigoInvalido()
            ClsTools.MuestraMensajeSistFact(ClsTools.GlobalSistemaCodigoNoExiste, Windows.Forms.MessageBoxIcon.Exclamation)
        End Sub

#End Region

#Region "Crea Metacatálogos"
        ' <summary>
        ' Crea el catálogo para asignarlo a un AccTextBoxAdvanced
        ' </summary>
        ' <param name="prmATX">AccTextBoxAdvanced al que se asignará el catálogo creado</param>
        ' <param name="prmMetacatalogo">Tipo de catálogo a crear</param>
        ' <remarks></remarks>
        Public Shared Sub CreaMetacatalogo(ByRef prmATX As AccTextBoxAdvanced, ByVal prmMetacatalogo As TipoMetacatalogo)
            prmATX.CatalogoBase = DevuelveCatalogo(prmMetacatalogo)
        End Sub
        ' <summary>
        ' Devuelve un catálogo
        ' </summary>
        ' <param name="prmMetacatalogo">Tipo de catálogo a crear</param>
        ' <returns></returns>
        ' <remarks></remarks>
        Private Shared Function DevuelveCatalogo(ByVal prmMetacatalogo As TipoMetacatalogo) As Catalogo
            Select Case prmMetacatalogo
                Case TipoMetacatalogo.UnidadProducto
                    Return New Catalogo(New MetaCatalogo("TIPOSUNIDADESPRODUCTOS"))
                Case TipoMetacatalogo.TipoProducto
                    Return New Catalogo(New MetaCatalogo("TIPOSPRODUCTOS"))
                Case TipoMetacatalogo.LineaProducto
                    Return New Catalogo(New MetaCatalogo("LINEASPRODUCTOS"))
                Case TipoMetacatalogo.ClavesCodigosBarra
                    Return New Catalogo(New MetaCatalogo("CODIGOSPRODUCCION"))
                Case TipoMetacatalogo.Producto
                    Return New Catalogo(New MetaCatalogo("PRODUCTOS"))
                Case TipoMetacatalogo.TipoArticulo
                    Return New Catalogo(New MetaCatalogo("TIPOSARTICULOS"))
                Case TipoMetacatalogo.LineaArticulo
                    Return New Catalogo(New MetaCatalogo("LINEAS"))
                Case TipoMetacatalogo.Articulo
                    Return New Catalogo(New MetaCatalogo("ARTICULOS"))
                Case TipoMetacatalogo.Proveedores
                    Return New Catalogo(New MetaCatalogo("PROVEEDORES"))
                Case TipoMetacatalogo.ProveedoresContabilidad
                    Return New Catalogo(New MetaCatalogo("CTL_Proveedores"))
                Case TipoMetacatalogo.Almacen
                    Return New Catalogo(New MetaCatalogo("ALMACENES"))
                Case TipoMetacatalogo.Cliente
                    Return New Catalogo(New MetaCatalogo("CLIENTES"))
                Case TipoMetacatalogo.Empleado
                    Return New Catalogo(New MetaCatalogo("EMPLEADOS"))
                Case TipoMetacatalogo.Marca
                    Return New Catalogo(New MetaCatalogo("MARCAS"))
                Case TipoMetacatalogo.Plaza
                    Return New Catalogo(New MetaCatalogo("PLAZAS"))
                Case TipoMetacatalogo.Sucursal
                    Return New Catalogo(New MetaCatalogo("SUCURSALES"))
                Case Else
                    Return Nothing
            End Select
        End Function
#End Region


        ' ''Public Shared Function ObtenAlmacenINI() As Catalogos.ClsAlmacen
        ' ''    Return Catalogos.FabricaCatalogos.ObtenAlmacen(DAO.ParametrosTerminal.ParametroAlmacen.Valor)
        ' ''End Function

    End Class
End Namespace