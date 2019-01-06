
' ''Imports Adsum.Dominio.Catalogos.Productos
' ''Imports Adsum.Dominio.Catalogos.Bancos
' ''Imports Adsum.Dominio.Catalogos.CuentasPorPagar
' ''Imports Adsum.Dominio.Catalogos.Contabilidad
' ''Imports Adsum.Dominio.Catalogos.Distribucion
' ''Imports Comunes.Comunes.Comun.Bancos
Imports Sistema.Comunes.Catalogos
Imports Sistema.Comunes.Comun
Imports Sistema

Namespace Comunes.Catalogos
    Public Class EscribanoCatalogos
        Inherits Escribano


        Shared DAO As DataAccessCls = DataAccessCls.DevuelveInstancia

        ' ''Public Shared Function InicializarBDCodigosProveedor(ByVal prmarticulo As ClsArticulo) As Boolean
        ' ''    If Not DAO.EjecutaComandoSQL("delete from CTL_ProveedoresArticulos_Conciliacion where narticulo = " & prmarticulo.Folio) Then
        ' ''        Return False
        ' ''    End If
        ' ''    Return DAO.EjecutaComandoSQL("delete from CTL_ProveedoresArticulos where narticulo=" & prmarticulo.Folio)
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmclsmotivos As clsmotivos) As Boolean
        ' ''    prmclsmotivos.atrNombreCampos = "nMotivo ,cDescripcion ,bActivo ,cUsuario_Registro ,dFecha_Registro" & vbCr
        ' ''    prmclsmotivos.atrNombreCampos &= " ,cMaquina_Registro ,cUsuario_UltimaModificacion ,dFecha_UltimaModificacion ,cMaquina_UltimaModificacion" & vbCr
        ' ''    prmclsmotivos.atrNombreCampos &= " ,cUsuario_Eliminacion ,dFecha_Eliminacion ,cMaquina_Eliminacion" & vbCr

        ' ''    prmclsmotivos.atrNombreTabla = "ctl_motivos"

        ' ''    If Not prmclsmotivos.GuardarNuevo(, , , False) Then
        ' ''        Return False
        ' ''    End If

        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmContexto As WS.ClsContextosEnviar) As Boolean
        ' ''    prmContexto.atrNombreCampos = "nContexto,cDescripcion,bActivo,cUsuario_Registro ,dFecha_Registro" & vbCr
        ' ''    prmContexto.atrNombreCampos &= " ,cMaquina_Registro ,cUsuario_UltimaModificacion ,dFecha_UltimaModificacion ,cMaquina_UltimaModificacion" & vbCr
        ' ''    prmContexto.atrNombreCampos &= " ,cUsuario_Eliminacion ,dFecha_Eliminacion ,cMaquina_Eliminacion" & vbCr
        ' ''    prmContexto.atrNombreTabla = "CTL_ContextosEnviarWS"

        ' ''    If Not prmContexto.GuardarNuevo() Then
        ' ''        Return False
        ' ''    End If

        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function ActualizaAlmacenControlador(ByVal prmAlmacen As Catalogos.ClsAlmacen) As Boolean
        ' ''    Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''    Dim vSql As String = ""
        ' ''    vSql = "UPDATE CTL_Almacenes SET nAlmacenControlador = nAlmacen WHERE nAlmacen = " & prmAlmacen.Folio
        ' ''    Return DAO.EjecutaComandoSQL(vSql)
        ' ''End Function


        ' ''Public Shared Function Guardar(ByVal prmCausa As Caja.ClsCausa) As Boolean
        ' ''    prmCausa.atrNombreCampos = "nCausa ,cDescripcion , nTipoCausa ,bActivo ,cUsuario_Registro ,dFecha_Registro," & vbCr
        ' ''    prmCausa.atrNombreCampos &= "cMaquina_Registro ,cUsuario_UltimaModificacion ,dFecha_UltimaModificacion ,cMaquina_UltimaModificacion," & vbCr
        ' ''    prmCausa.atrNombreCampos &= "cUsuario_Eliminacion ,dFecha_Eliminacion ,cMaquina_Eliminacion" & vbCr

        ' ''    prmCausa.atrNombreTabla = "CTL_Causas"

        ' ''    Return prmCausa.GuardarNuevo

        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmRFC As Caja.ClsRFC) As Boolean
        ' ''    prmRFC.atrNombreCampos = "nRFC ,cRFC , bActivo ,cUsuario_Registro ,dFecha_Registro," & vbCr
        ' ''    prmRFC.atrNombreCampos &= "cMaquina_Registro ,cUsuario_UltimaModificacion ,dFecha_UltimaModificacion ,cMaquina_UltimaModificacion," & vbCr
        ' ''    prmRFC.atrNombreCampos &= "cUsuario_Eliminacion ,dFecha_Eliminacion ,cMaquina_Eliminacion" & vbCr

        ' ''    prmRFC.atrNombreTabla = "CTL_RFC"

        ' ''    If Not prmRFC.GuardarNuevo Then
        ' ''        Return False
        ' ''    End If

        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmRazonSocial As Caja.ClsRazonSocial) As Boolean
        ' ''    prmRazonSocial.atrNombreCampos = "nRazonSocial,nRFC,cDescripcion,cDependencia, cDireccion,nEstado,nMunicipio,nCiudad,nColonia,nCliente,bActivo ,cUsuario_Registro ,dFecha_Registro," & vbCr
        ' ''    prmRazonSocial.atrNombreCampos &= "cMaquina_Registro ,cUsuario_UltimaModificacion ,dFecha_UltimaModificacion ,cMaquina_UltimaModificacion," & vbCr
        ' ''    prmRazonSocial.atrNombreCampos &= "cUsuario_Eliminacion ,dFecha_Eliminacion ,cMaquina_Eliminacion" & vbCr

        ' ''    prmRazonSocial.atrNombreTabla = "CTL_RazonesSociales"

        ' ''    If Not prmRazonSocial.GuardarNuevo Then
        ' ''        Return False
        ' ''    End If

        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmTipoDocumento As Caja.ClsTipoDocumento) As Boolean
        ' ''    prmTipoDocumento.atrNombreCampos = "nTipoDocumentoCaja,cDescripcion,nTipoEfecto,nMoneda,nTipoAccion,"
        ' ''    prmTipoDocumento.atrNombreCampos &= "bRequiereBanco,bRequiereReferencia,bDepositable,bRequiereDistribucion,bDiferencia,bAplicaCorte,bActivo,"
        ' ''    prmTipoDocumento.atrNombreCampos &= "cUsuario_Registro,dFecha_Registro,cMaquina_Registro,"
        ' ''    prmTipoDocumento.atrNombreCampos &= "cUsuario_UltimaModificacion,dFecha_UltimaModificacion,cMaquina_UltimaModificacion,"
        ' ''    prmTipoDocumento.atrNombreCampos &= "cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion"
        ' ''    prmTipoDocumento.atrNombreTabla = "CJA_Tipos_Documentos"

        ' ''    Return prmTipoDocumento.GuardarNuevo
        ' ''End Function

        ' ''Public Shared Function ObtenFolioProveedoresCuentasBancarias(ByVal prmProveedor As Integer) As Integer
        ' ''    Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia

        ' ''    Return DAO.RegresaDatoSQL("select isnull(max(nCuentaBancaria),0)+1 from CTL_ProveedoresCuentasBancarias(NOLOCK) where nProveedor=" & prmProveedor)
        ' ''End Function

        ' ''Public Shared Function ObtenFolioProveedoresObservaciones(ByVal prmProveedor As Integer) As Integer
        ' ''    Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia

        ' ''    Return DAO.RegresaDatoSQL("select isnull(max(nObservacion),0)+1 from CTL_ProveedoresObservaciones(NOLOCK) where nProveedor=" & prmProveedor)
        ' ''End Function

        ' ''Public Shared Function ObtenFolioProveedoresProntosPagos(ByVal prmProveedor As Integer) As Integer
        ' ''    Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''    Return DAO.RegresaDatoSQL("select isnull(max(nProntoPago),0)+1 from CTL_ProveedoresProntosPagos(NOLOCK) where nProveedor=" & prmProveedor)
        ' ''End Function

        ' ''Public Shared Function ObtenFolioProveedoresContactos(ByVal prmProveedor As Integer) As Integer
        ' ''    Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''    Return DAO.RegresaDatoSQL("select isnull(max(nProveedorContacto),0)+1 from CTL_ProveedoresContactos(NOLOCK) where nProveedor=" & prmProveedor)
        ' ''End Function

        ' ''Public Shared Function ObtenFolioProyectosDetalle(ByVal prmProyecto As Integer) As Integer
        ' ''    Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''    Return DAO.RegresaDatoSQL("Select IsNull(Max(nProyectoConsecutivo),0)+1 From CTL_ProyectosDetalle(NOLOCK) Where nProyecto = " & prmProyecto)
        ' ''End Function

        ' ''Public Shared Function ObtenFolioProveedoresCuentasContables(ByVal prmProveedor As Integer) As Integer
        ' ''    Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''    Return DAO.RegresaDatoSQL("Select IsNull(Max(nProveedorCuentaCnt),0)+1 From CTL_ProveedoresCuentasContables(NOLOCK) Where nProveedor=" & prmProveedor)
        ' ''End Function

        Public Shared Function Guardar(ByVal prmEmpleado As ClsEmpleado) As Boolean

            'Dim ABRIO As Boolean
            'If Not DAO.TieneTransaccionAbierta Then
            '    ABRIO = True
            '    DAO.AbreTransaccion()
            'End If
            'If Not prmEmpleado.GuardarBase Then
            '    Return False
            'End If
            prmEmpleado.atrNombreCampos = "nEmpleado,cNombre,cApellidoPaterno,cApellidoMaterno,cCodigoAux,cPais,nColonia,cDireccion,cTelefonoCelular,cTelefonoCasa,dFechaIngreso,dFechaNacimiento,nPuesto,nTurno,nSucursal,nArea,cTipoArticulo,cCodigoGafete,bActivo,"
            prmEmpleado.atrNombreCampos &= "dFecha_Registro,cMaquina_Registro,cUsuario_Registro,"
            prmEmpleado.atrNombreCampos &= "cUsuario_UltimaModificacion, dFecha_UltimaModificacion, cMaquina_UltimaModificacion,"
            prmEmpleado.atrNombreCampos &= "cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion"
            prmEmpleado.atrNombreTabla = "CTL_Empleados"

            If Not prmEmpleado.GuardarNuevo Then
                Return False
            End If

            'If Not prmEmpleado.setRowAccion Then
            '    Return False
            'End If

            'prmEmpleado.atrRow("nEmpleado") = prmEmpleado.Folio
            'prmEmpleado.atrRow("cDescripcion") = prmEmpleado.Descripcion
            'prmEmpleado.atrRow("bActivo") = prmEmpleado.Activo

            'prmEmpleado.LLenaDatosRegistroComun(prmEmpleado.atrRow)

            'If Not prmEmpleado.GuardarGenerico Then
            '    Return False
            'End If

            'If ABRIO Then
            '    DAO.CierraTransaccion()
            'End If

            Return True
        End Function

        ' ''Public Shared Function Guardar(ByVal prmInvolucrado As ClsInvolucrado) As Boolean

        ' ''    prmInvolucrado.atrNombreCampos = "nInvolucrado,cNombre,cAbreviatura,cContacto,cDomicilio,cTelefonos,cTipoInvolucrado,nInvolucradoRelacionado,cLetra,nPlaza,bActivo,dFecha_Registro,cMaquina_Registro,cUsuario_Registro,cUsuario_UltimaModificacion, dFecha_UltimaModificacion, cMaquina_UltimaModificacion,cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion"
        ' ''    prmInvolucrado.atrNombreTabla = "CTL_Involucrados"

        ' ''    If Not prmInvolucrado.GuardarNuevo() Then
        ' ''        Return False
        ' ''    End If

        ' ''    'Dim ABRIO As Boolean
        ' ''    'If Not DAO.TieneTransaccionAbierta Then
        ' ''    '    ABRIO = True
        ' ''    '    DAO.AbreTransaccion()
        ' ''    'End If
        ' ''    'If Not prmInvolucrado.GuardarBase Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'prmInvolucrado.atrSql = "SELECT nInvolucrado,cNombre,cAbreviatura,cContacto,cDomicilio,cTelefonos,cTipoInvolucrado,nInvolucradoRelacionado,cLetra,nPlaza,bActivo," & vbCr
        ' ''    'prmInvolucrado.atrSql &= "dFecha_Registro,cMaquina_Registro,cUsuario_Registro," & vbCr
        ' ''    'prmInvolucrado.atrSql &= "cUsuario_UltimaModificacion, dFecha_UltimaModificacion, cMaquina_UltimaModificacion, " & vbCr
        ' ''    'prmInvolucrado.atrSql &= "cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion" & vbCr
        ' ''    'prmInvolucrado.atrSql &= "FROM CTL_Involucrados(NOLOCK) " & vbCr
        ' ''    'prmInvolucrado.atrSql &= "WHERE nInvolucrado = " & prmInvolucrado.Folio

        ' ''    'If Not prmInvolucrado.setRowAccion Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'prmInvolucrado.atrRow("nInvolucrado") = prmInvolucrado.Folio
        ' ''    'prmInvolucrado.atrRow("cNombre") = prmInvolucrado.Descripcion
        ' ''    'prmInvolucrado.atrRow("cAbreviatura") = prmInvolucrado.Abreviatura
        ' ''    'prmInvolucrado.atrRow("cContacto") = prmInvolucrado.Contacto
        ' ''    'prmInvolucrado.atrRow("cDomicilio") = prmInvolucrado.Domicilio
        ' ''    'prmInvolucrado.atrRow("cTelefonos") = prmInvolucrado.Telefonos
        ' ''    'prmInvolucrado.atrRow("cTipoInvolucrado") = prmInvolucrado.TipoInvolucrado
        ' ''    'prmInvolucrado.atrRow("cLetra") = prmInvolucrado.Letra
        ' ''    'If Not prmInvolucrado.InvolucradoRelacionado Is Nothing Then
        ' ''    '    prmInvolucrado.atrRow("nInvolucradoRelacionado") = prmInvolucrado.InvolucradoRelacionado.Folio
        ' ''    'Else
        ' ''    '    prmInvolucrado.atrRow("nInvolucradoRelacionado") = DBNull.Value
        ' ''    'End If

        ' ''    'prmInvolucrado.atrRow("nPlaza") = prmInvolucrado.Plaza.Folio
        ' ''    'prmInvolucrado.atrRow("bActivo") = prmInvolucrado.Activo

        ' ''    'prmInvolucrado.LLenaDatosRegistroComun(prmInvolucrado.atrRow)

        ' ''    'If Not prmInvolucrado.GuardarGenerico Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'If ABRIO Then
        ' ''    '    DAO.CierraTransaccion()
        ' ''    'End If

        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmInvolucrado As ClsInvolucradoProducto) As Boolean

        ' ''    prmInvolucrado.atrNombreCampos = "nInvolucrado,cNombre,cAbreviatura,cContacto,cDomicilio,cTelefonos,cTipoInvolucrado,nInvolucradoRelacionado,cLetra,nPlaza,bActivo,dFecha_Registro,cMaquina_Registro,cUsuario_Registro,cUsuario_UltimaModificacion, dFecha_UltimaModificacion, cMaquina_UltimaModificacion,cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion"
        ' ''    prmInvolucrado.atrNombreTabla = "CTL_InvolucradosProductos"

        ' ''    prmInvolucrado.ValidaSiEsAlmacenCorporativoProduccion = True
        ' ''    If Not prmInvolucrado.GuardarNuevo() Then
        ' ''        Return False
        ' ''    End If


        ' ''    Return True
        ' ''End Function

        Public Shared Function Guardar(ByVal prmParidad As ClsParidad, Optional ByVal Historico As Boolean = False) As Boolean

            'Dim ABRIO As Boolean
            'If Not DAO.TieneTransaccionAbierta Then
            '    ABRIO = True
            '    DAO.AbreTransaccion()
            'End If
            If Not Historico Then
                prmParidad.atrNombreCampos = "nParidad,nMoneda,dFecha,nPrecioDeCompra,nPrecioDeVenta,bActivo,dFecha_Registro,cMaquina_Registro,cUsuario_Registro,cUsuario_UltimaModificacion, dFecha_UltimaModificacion, cMaquina_UltimaModificacion,cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion"
                prmParidad.atrNombreTabla = "CTL_Paridades"
                If Not prmParidad.GuardarNuevo Then
                    Return False
                End If
                'If Not prmParidad.GuardarBase() Then
                '    Return False
                'End If

                'prmParidad.atrSql = "SELECT nParidad,nMoneda,dFecha,nPrecioDeCompra,nPrecioDeVenta,bActivo," & vbCr
                'prmParidad.atrSql &= "dFecha_Registro,cMaquina_Registro,cUsuario_Registro," & vbCr
                'prmParidad.atrSql &= "cUsuario_UltimaModificacion, dFecha_UltimaModificacion, cMaquina_UltimaModificacion, " & vbCr
                'prmParidad.atrSql &= "cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion" & vbCr
                'prmParidad.atrSql &= "FROM CTL_Paridades(NOLOCK) " & vbCr
                'prmParidad.atrSql &= "WHERE nParidad = " & prmParidad.Folio & vbCr
                'prmParidad.atrSql &= "AND nMoneda = " & prmParidad.Moneda.Folio


                'If Not prmParidad.setRowAccion Then
                '    Return False
                'End If

                'prmParidad.atrRow("nParidad") = prmParidad.Folio
                'prmParidad.atrRow("nMoneda") = prmParidad.Moneda.Folio
                'prmParidad.atrRow("dFecha") = prmParidad.Fecha
                'prmParidad.atrRow("nPrecioDeCompra") = prmParidad.PrecioDeCompra
                'prmParidad.atrRow("nPrecioDeVenta") = prmParidad.PrecioDeVenta
                ''prmParidad.atrRow("nDiasVigencia") = prmParidad.DiasVigencia
                'prmParidad.atrRow("bActivo") = prmParidad.Activo

                'prmParidad.LLenaDatosRegistroComun(prmParidad.atrRow)

                'If Not prmParidad.GuardarGenerico Then
                '    Return False
                'End If
            End If
            If Historico Then
                If Not prmParidad.ParidadesHistorico.Guardar Then
                    Return False
                End If
            End If

            'If ABRIO Then
            '    DAO.CierraTransaccion()
            'End If

            Return True
        End Function

        ' ''Public Shared Function Guardar(ByVal prmZona As ClsZona) As Boolean
        ' ''    prmZona.atrNombreCampos = "nZona,cDescripcion,nCostoEntrega,bActivo,dFecha_Registro,cMaquina_Registro,cUsuario_Registro,cUsuario_UltimaModificacion, dFecha_UltimaModificacion, cMaquina_UltimaModificacion,cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion"
        ' ''    prmZona.atrNombreTabla = "CTL_Zonas"
        ' ''    If Not prmZona.GuardarNuevo Then
        ' ''        Return False
        ' ''    End If
        ' ''    'Dim ABRIO As Boolean  
        ' ''    'If Not DAO.TieneTransaccionAbierta Then 
        ' ''    '    ABRIO = True
        ' ''    '    DAO.AbreTransaccion()
        ' ''    'End If
        ' ''    'If Not prmZona.GuardarBase Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'prmZona.atrSql = "SELECT nZona,cDescripcion,bActivo," & vbCr
        ' ''    'prmZona.atrSql &= "dFecha_Registro,cMaquina_Registro,cUsuario_Registro," & vbCr
        ' ''    'prmZona.atrSql &= "cUsuario_UltimaModificacion, dFecha_UltimaModificacion, cMaquina_UltimaModificacion, " & vbCr
        ' ''    'prmZona.atrSql &= "cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion" & vbCr
        ' ''    'prmZona.atrSql &= "FROM CTL_Zonas(NOLOCK) " & vbCr
        ' ''    'prmZona.atrSql &= "WHERE nZona = " & prmZona.Folio

        ' ''    'If Not prmZona.setRowAccion Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'prmZona.atrRow("nZona") = prmZona.Folio
        ' ''    'prmZona.atrRow("cDescripcion") = prmZona.Descripcion
        ' ''    'prmZona.atrRow("bActivo") = prmZona.Activo

        ' ''    'prmZona.LLenaDatosRegistroComun(prmZona.atrRow)

        ' ''    'If Not prmZona.GuardarGenerico Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'If ABRIO Then
        ' ''    '    DAO.CierraTransaccion()
        ' ''    'End If

        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmCaja As Caja.ClsCaja) As Boolean
        ' ''    prmCaja.atrNombreCampos = "nCaja,cDescripcion,nSucursal,bActivo,dFecha_Registro,cMaquina_Registro,cUsuario_Registro,cUsuario_UltimaModificacion, dFecha_UltimaModificacion, cMaquina_UltimaModificacion,cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion"
        ' ''    prmCaja.atrNombreTabla = "CAJ_Cajas"

        ' ''    Return prmCaja.GuardarNuevo
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmDenominacion As Caja.ClsDenominacion) As Boolean
        ' ''    prmDenominacion.atrNombreCampos = "nDenominacion,cDescripcion,nMonedaBase,nValor,bBillete,bActivo,dFecha_Registro,cMaquina_Registro,cUsuario_Registro,cUsuario_UltimaModificacion, dFecha_UltimaModificacion, cMaquina_UltimaModificacion,cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion"
        ' ''    prmDenominacion.atrNombreTabla = "CAJ_Denominaciones"

        ' ''    Return prmDenominacion.GuardarNuevo
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmBanco As ClsBanco) As Boolean
        ' ''    prmBanco.atrNombreCampos = "nBanco,cDescripcion,bActivo,dFecha_Registro,cMaquina_Registro,cUsuario_Registro,cUsuario_UltimaModificacion, dFecha_UltimaModificacion, cMaquina_UltimaModificacion,cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion"
        ' ''    prmBanco.atrNombreTabla = "CTL_Bancos"

        ' ''    If Not prmBanco.GuardarNuevo Then
        ' ''        Return False
        ' ''    End If
        ' ''    'Dim ABRIO As Boolean
        ' ''    'If Not DAO.TieneTransaccionAbierta Then
        ' ''    '    ABRIO = True
        ' ''    '    DAO.AbreTransaccion()
        ' ''    'End If
        ' ''    'If Not prmBanco.GuardarBase Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'prmBanco.atrSql = "SELECT nBanco,cDescripcion,bActivo," & vbCr
        ' ''    'prmBanco.atrSql &= "dFecha_Registro,cMaquina_Registro,cUsuario_Registro," & vbCr
        ' ''    'prmBanco.atrSql &= "cUsuario_UltimaModificacion, dFecha_UltimaModificacion, cMaquina_UltimaModificacion, " & vbCr
        ' ''    'prmBanco.atrSql &= "cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion" & vbCr
        ' ''    'prmBanco.atrSql &= "FROM CTL_Bancos(NOLOCK) " & vbCr
        ' ''    'prmBanco.atrSql &= "WHERE nBanco = " & prmBanco.Folio

        ' ''    'If Not prmBanco.setRowAccion Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'prmBanco.atrRow("nBanco") = prmBanco.Folio
        ' ''    'prmBanco.atrRow("cDescripcion") = prmBanco.Descripcion
        ' ''    'prmBanco.atrRow("bActivo") = prmBanco.Activo

        ' ''    'prmBanco.LLenaDatosRegistroComun(prmBanco.atrRow)

        ' ''    'If Not prmBanco.GuardarGenerico Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'If ABRIO Then
        ' ''    '    DAO.CierraTransaccion()
        ' ''    'End If

        ' ''    Return True
        ' ''End Function


        ' ''Public Shared Function Guardar(ByVal prmColonia As ClsColonia) As Boolean
        ' ''    prmColonia.atrNombreCampos = "nIDColonia,nIDCiudad,nColonia,cDescripcion,cCodigoPostal,nZona,bActivo,dFecha_Registro,cMaquina_Registro,cUsuario_Registro,cUsuario_UltimaModificacion, dFecha_UltimaModificacion, cMaquina_UltimaModificacion,cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion,bForaneo"
        ' ''    prmColonia.atrNombreTabla = "CTL_Colonias"

        ' ''    If Not prmColonia.GuardarNuevo() Then '(True, "nIDColonia&" & prmColonia.getNombreFolioAdministradoLogico) Then
        ' ''        Return False
        ' ''    End If

        ' ''    'If Not prmColonia.atrGrabarLocal Then
        ' ''    '    If Not prmColonia.EnviarWs(DAO.ParametroAdministradoObtener("PRM", "WSCORPORATIVO") & DAO.ParametroAdministradoObtener("PRM", "WSCATALOGOS"), True, Nothing, True, "nIDColonia", prmColonia.getNombreFolioAdministradoLogico) Then
        ' ''    '        Return False
        ' ''    '    End If
        ' ''    'End If

        ' ''    'Dim ABRIO As Boolean
        ' ''    'If Not DAO.TieneTransaccionAbierta Then
        ' ''    '    ABRIO = True
        ' ''    '    DAO.AbreTransaccion()
        ' ''    'End If
        ' ''    'If Not prmColonia.GuardarBase Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'prmColonia.atrSql = "SELECT nIDColonia,nIDCiudad,nColonia,cDescripcion,cCodigoPostal,nZona,bActivo," & vbCr
        ' ''    'prmColonia.atrSql &= "dFecha_Registro,cMaquina_Registro,cUsuario_Registro," & vbCr
        ' ''    'prmColonia.atrSql &= "cUsuario_UltimaModificacion, dFecha_UltimaModificacion, cMaquina_UltimaModificacion, " & vbCr
        ' ''    'prmColonia.atrSql &= "cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion" & vbCr
        ' ''    'prmColonia.atrSql &= "FROM CTL_Colonias(NOLOCK) " & vbCr
        ' ''    'prmColonia.atrSql &= "WHERE nColonia = " & prmColonia.Folio

        ' ''    'If Not prmColonia.setRowAccion Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'If prmColonia.atrAccion = EAccionesBD.Insertar Then
        ' ''    '    prmColonia.atrRow("nIDColonia") = prmColonia.DAO.FolioAdministradoSiguiente("CTL_Colonias_logico")
        ' ''    'Else
        ' ''    '    prmColonia.atrRow("nIDColonia") = prmColonia.FolioLogico
        ' ''    'End If

        ' ''    'prmColonia.atrRow("nIDCiudad") = prmColonia.Ciudad.FolioLogico
        ' ''    'prmColonia.atrRow("nColonia") = prmColonia.Folio
        ' ''    'prmColonia.atrRow("cDescripcion") = prmColonia.Descripcion
        ' ''    'prmColonia.atrRow("cCodigoPostal") = prmColonia.CodigoPostal
        ' ''    'prmColonia.atrRow("nZona") = prmColonia.Zona.Folio
        ' ''    'prmColonia.atrRow("bActivo") = prmColonia.Activo

        ' ''    'prmColonia.LLenaDatosRegistroComun(prmColonia.atrRow)

        ' ''    'If Not prmColonia.GuardarGenerico Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'If ABRIO Then
        ' ''    '    DAO.CierraTransaccion()
        ' ''    'End If

        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmCiudad As ClsCiudad) As Boolean
        ' ''    prmCiudad.atrNombreCampos = "nIDCiudad,nIDMunicipio,bfrontera,nCiudad,cDescripcion,bActivo,dFecha_Registro,cMaquina_Registro,cUsuario_Registro,cUsuario_UltimaModificacion, dFecha_UltimaModificacion, cMaquina_UltimaModificacion,cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion"
        ' ''    prmCiudad.atrNombreTabla = "CTL_Ciudades"

        ' ''    If Not prmCiudad.GuardarNuevo() Then   '(True, "nIDCiudad&" & prmCiudad.getNombreFolioAdministrado) Then
        ' ''        Return False
        ' ''    End If

        ' ''    'If Not prmCiudad.atrGrabarLocal Then
        ' ''    '    If Not prmCiudad.EnviarWs(DAO.ParametroAdministradoObtener("PRM", "WSCORPORATIVO") & DAO.ParametroAdministradoObtener("PRM", "WSCATALOGOS"), True, Nothing, True, "nIDCiudad", prmCiudad.getNombreFolioAdministrado) Then
        ' ''    '        Return False
        ' ''    '    End If
        ' ''    'End If
        ' ''    'Dim ABRIO As Boolean
        ' ''    'If Not DAO.TieneTransaccionAbierta Then
        ' ''    '    ABRIO = True
        ' ''    '    DAO.AbreTransaccion()
        ' ''    'End If
        ' ''    'If Not prmCiudad.GuardarBase Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'prmCiudad.atrSql = "SELECT nIDCiudad,nIDMunicipio,bfrontera,nCiudad,cDescripcion,bActivo," & vbCr
        ' ''    'prmCiudad.atrSql &= "dFecha_Registro,cMaquina_Registro,cUsuario_Registro," & vbCr
        ' ''    'prmCiudad.atrSql &= "cUsuario_UltimaModificacion, dFecha_UltimaModificacion, cMaquina_UltimaModificacion, " & vbCr
        ' ''    'prmCiudad.atrSql &= "cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion" & vbCr
        ' ''    'prmCiudad.atrSql &= "FROM CTL_Ciudades(NOLOCK) " & vbCr
        ' ''    'prmCiudad.atrSql &= "WHERE nCiudad = " & prmCiudad.Folio

        ' ''    'If Not prmCiudad.setRowAccion Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'If prmCiudad.atrAccion = EAccionesBD.Insertar Then
        ' ''    '    prmCiudad.atrRow("nIDCiudad") = prmCiudad.DAO.FolioAdministradoSiguiente("CTL_Ciudades_logico")
        ' ''    'Else
        ' ''    '    prmCiudad.atrRow("nIDCiudad") = prmCiudad.FolioLogico
        ' ''    'End If

        ' ''    'prmCiudad.atrRow("nIDMunicipio") = prmCiudad.Municipio.Folio
        ' ''    'prmCiudad.atrRow("nCiudad") = prmCiudad.Folio
        ' ''    'prmCiudad.atrRow("cDescripcion") = prmCiudad.Descripcion
        ' ''    'prmCiudad.atrRow("bFrontera") = prmCiudad.Frontera
        ' ''    'prmCiudad.atrRow("bActivo") = prmCiudad.Activo

        ' ''    'prmCiudad.LLenaDatosRegistroComun(prmCiudad.atrRow)

        ' ''    'If Not prmCiudad.GuardarGenerico Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'If ABRIO Then
        ' ''    '    DAO.CierraTransaccion()
        ' ''    'End If

        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmMunicipio As ClsMunicipio) As Boolean
        ' ''    prmMunicipio.atrNombreCampos = "nIDMunicipio,nIDEstado,nMunicipio,cDescripcion,bActivo,cUsuario_Registro,dFecha_Registro,cMaquina_Registro,cUsuario_UltimaModificacion, dFecha_UltimaModificacion, cMaquina_UltimaModificacion,cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion"
        ' ''    prmMunicipio.atrNombreTabla = "CTL_Municipios"

        ' ''    If Not prmMunicipio.GuardarNuevo() Then
        ' ''        Return False
        ' ''    End If


        ' ''    'If Not prmMunicipio.GuardarNuevo(True, "nIDMunicipio&" & prmMunicipio.getNombreFolioAdministradoLogico) Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'If Not prmMunicipio.atrGrabarLocal Then
        ' ''    '    If Not prmMunicipio.EnviarWs(DAO.ParametroAdministradoObtener("PRM", "WSCORPORATIVO") & DAO.ParametroAdministradoObtener("PRM", "WSCATALOGOS"), True, Nothing, True, "nIDMunicipio", prmMunicipio.getNombreFolioAdministradoLogico) Then
        ' ''    '        Return False
        ' ''    '    End If
        ' ''    'End If
        ' ''    'Dim ABRIO As Boolean
        ' ''    'If Not DAO.TieneTransaccionAbierta Then
        ' ''    '    ABRIO = True
        ' ''    '    DAO.AbreTransaccion()
        ' ''    'End If

        ' ''    'If Not prmMunicipio.GuardarBase Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'prmMunicipio.atrSql = "SELECT nIDMunicipio,nIDEstado,nMunicipio,cDescripcion,bActivo," & vbCr
        ' ''    'prmMunicipio.atrSql &= "dFecha_Registro,cMaquina_Registro,cUsuario_Registro," & vbCr
        ' ''    'prmMunicipio.atrSql &= "cUsuario_UltimaModificacion, dFecha_UltimaModificacion, cMaquina_UltimaModificacion, " & vbCr
        ' ''    'prmMunicipio.atrSql &= "cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion" & vbCr
        ' ''    'prmMunicipio.atrSql &= "FROM CTL_Municipios(NOLOCK) " & vbCr
        ' ''    'prmMunicipio.atrSql &= "WHERE nMunicipio = " & prmMunicipio.Folio

        ' ''    'If Not prmMunicipio.setRowAccion Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'If prmMunicipio.atrAccion = EAccionesBD.Insertar Then
        ' ''    '    prmMunicipio.atrRow("nIDMunicipio") = prmMunicipio.DAO.FolioAdministradoSiguiente("CTL_Municipios_logico")
        ' ''    'Else
        ' ''    '    prmMunicipio.atrRow("nIDMunicipio") = prmMunicipio.FolioLogico
        ' ''    'End If

        ' ''    'prmMunicipio.atrRow("nIDEstado") = prmMunicipio.Estado.Folio
        ' ''    'prmMunicipio.atrRow("nMunicipio") = prmMunicipio.Folio
        ' ''    'prmMunicipio.atrRow("cDescripcion") = prmMunicipio.Descripcion
        ' ''    'prmMunicipio.atrRow("bActivo") = prmMunicipio.Activo

        ' ''    'prmMunicipio.LLenaDatosRegistroComun(prmMunicipio.atrRow)

        ' ''    'If Not prmMunicipio.GuardarGenerico Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'If ABRIO Then
        ' ''    '    DAO.CierraTransaccion()
        ' ''    'End If

        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmEstado As ClsEstado) As Boolean

        ' ''    prmEstado.atrNombreCampos = "nIDEstado,cDescripcion,bActivo,cUsuario_Registro,dFecha_Registro,cMaquina_Registro,cUsuario_UltimaModificacion,dFecha_UltimaModificacion,cMaquina_UltimaModificacion,CUSUARIO_ELIMINACION,DFECHA_ELIMINACION,CMAQUINA_ELIMINACION"
        ' ''    prmEstado.atrNombreTabla = "CTL_Estados"

        ' ''    If Not prmEstado.GuardarNuevo() Then
        ' ''        Return False
        ' ''    End If

        ' ''    'Dim ABRIO As Boolean
        ' ''    'If Not DAO.TieneTransaccionAbierta Then
        ' ''    '    ABRIO = True
        ' ''    '    DAO.AbreTransaccion()
        ' ''    'End If
        ' ''    'If Not prmEstado.GuardarBase Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'prmEstado.atrSql = "SELECT nIDEstado,cDescripcion,bActivo," & vbCr
        ' ''    'prmEstado.atrSql &= "dFecha_Registro,cMaquina_Registro,cUsuario_Registro," & vbCr
        ' ''    'prmEstado.atrSql &= "cUsuario_UltimaModificacion, dFecha_UltimaModificacion, cMaquina_UltimaModificacion, " & vbCr
        ' ''    'prmEstado.atrSql &= "cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion" & vbCr
        ' ''    'prmEstado.atrSql &= "FROM CTL_Estados(NOLOCK) " & vbCr
        ' ''    'prmEstado.atrSql &= "WHERE nIDEstado = " & prmEstado.Folio

        ' ''    'If Not prmEstado.setRowAccion Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'prmEstado.atrRow("nIDEstado") = prmEstado.Folio
        ' ''    'prmEstado.atrRow("cDescripcion") = prmEstado.Descripcion
        ' ''    'prmEstado.atrRow("bActivo") = prmEstado.Activo

        ' ''    'prmEstado.LLenaDatosRegistroComun(prmEstado.atrRow)

        ' ''    'If Not prmEstado.GuardarGenerico Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'If ABRIO Then
        ' ''    '    DAO.CierraTransaccion()
        ' ''    'End If

        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmProveedor As Dominio.Catalogos.Proveedores.ClsProveedor) As Boolean
        ' ''    Dim prmEnviaWS As Boolean = False
        ' ''    Dim vlbAbrio As Boolean

        ' ''    If Not DAO.TieneTransaccionAbierta Then
        ' ''        vlbAbrio = True
        ' ''        DAO.AbreTransaccion()
        ' ''    End If
        ' ''    prmProveedor.atrNombreCampos = "nProveedor, cNombreFiscal,nTipoProveedor, cNombreCorto, cNombreComercial, cRFC, cCalle, cCURP, nColonia,cCodigoPostal,cPais,cNotas,nDiasPago,nDiasEntrega,nFechaAplicacionPago,nPorcentajeAnticipo,bActivo,cUsuario_Registro,dFecha_Registro,cMaquina_Registro,cUsuario_UltimaModificacion,dFecha_UltimaModificacion,cMaquina_UltimaModificacion,CUSUARIO_ELIMINACION,DFECHA_ELIMINACION,CMAQUINA_ELIMINACION,nImpuestos,nGrupoProveedor,nConceptoFlujo,bPolizaAcumulada,nPlazaRegistro,cFiscalNombre,cFiscalApellidoPaterno,cFiscalApellidoMaterno,cFiscalEstado,cFiscalDelegacion,cFiscalLocalidad,cFiscalColonia,cFiscalCalle,cFiscalCodigoPostal,cFiscalTelefono,cFiscalNumeroExterior,cFiscalNumeroInterior,cFiscalRazonSocial,cFiscalIDFiscal,cFiscalNombreExtranjero,cFiscalPaisResidencia,cFiscalNacionalidad,nFiscalTipoProveedor"
        ' ''    prmProveedor.atrNombreTabla = "CTL_Proveedores"

        ' ''    If Not prmProveedor.GuardarNuevo(True, , , prmEnviaWS) Then
        ' ''        Return False
        ' ''    End If

        ' ''    If prmProveedor.atrAccion = EAccionesBD.Insertar Then
        ' ''        prmProveedor.ProveedoresProntosPagos.ValorPrimaryKey = "nProveedor=" & prmProveedor.Folio
        ' ''        prmProveedor.ProveedoresObservaciones.ValorPrimaryKey = "nProveedor=" & prmProveedor.Folio
        ' ''        prmProveedor.ProveedoresCuentasBancarias.ValorPrimaryKey = "nProveedor=" & prmProveedor.Folio
        ' ''        prmProveedor.ProveedoresContactos.ValorPrimaryKey = "nProveedor=" & prmProveedor.Folio
        ' ''        prmProveedor.ProveedoresArticulos.ValorPrimaryKey = "nProveedor=" & prmProveedor.Folio
        ' ''        'prmProveedor.ProveedoresCuentasContables.ValorPrimaryKey = "nProveedor=" & prmProveedor.Folio
        ' ''    End If

        ' ''    If Not DAO.TieneTransaccionAbierta Then
        ' ''        vlbAbrio = True
        ' ''        DAO.AbreTransaccion()
        ' ''    End If

        ' ''    If Not prmProveedor.ProveedoresCuentasBancarias.TablaDiseño Is Nothing Then
        ' ''        For Each vRow As DataRow In prmProveedor.ProveedoresCuentasBancarias.TablaDiseño.Select
        ' ''            vRow("nProveedor") = prmProveedor.Folio
        ' ''        Next
        ' ''    End If

        ' ''    If Not prmProveedor.ProveedoresArticulos.TablaDiseño Is Nothing Then
        ' ''        For Each vrow As DataRow In prmProveedor.ProveedoresArticulos.TablaDiseño.Select
        ' ''            vrow("nProveedor") = prmProveedor.Folio
        ' ''        Next
        ' ''    End If

        ' ''    If Not prmProveedor.ProveedoresContactos.TablaDiseño Is Nothing Then
        ' ''        For Each vRow As DataRow In prmProveedor.ProveedoresContactos.TablaDiseño.Select
        ' ''            vRow("nProveedor") = prmProveedor.Folio
        ' ''        Next
        ' ''    End If

        ' ''    If Not prmProveedor.ProveedoresProntosPagos.TablaDiseño Is Nothing Then
        ' ''        For Each vRow As DataRow In prmProveedor.ProveedoresProntosPagos.TablaDiseño.Select
        ' ''            vRow("nProveedor") = prmProveedor.Folio
        ' ''        Next
        ' ''    End If

        ' ''    'If Not prmProveedor.ProveedoresCuentasContables.TablaDiseño Is Nothing Then
        ' ''    '    For Each vRow As DataRow In prmProveedor.ProveedoresCuentasContables.TablaDiseño.Select
        ' ''    '        vRow("nProveedor") = prmProveedor.Folio
        ' ''    '    Next
        ' ''    'End If

        ' ''    'Guardamos datos de los contenedores

        ' ''    If prmProveedor.Activo Then
        ' ''        If Not prmProveedor.ProveedoresArticulos.TablaDiseño Is Nothing Then
        ' ''            If prmProveedor.ProveedoresArticulos.TablaDiseño.Rows.Count > 0 Then
        ' ''                Dim temp As New DataTable
        ' ''                ClsTools.copiaRows(prmProveedor.ProveedoresArticulos.TablaDiseño.Select(""), temp, prmProveedor.ProveedoresArticulos.TablaDiseño.Columns)
        ' ''                prmProveedor.ProveedoresArticulos.TablaDiseño = temp
        ' ''            End If
        ' ''        End If

        ' ''        prmProveedor.ProveedoresArticulos.ClasePadre = prmProveedor
        ' ''        If Not Guardar(prmProveedor.ProveedoresArticulos, prmProveedor.Folio) Then
        ' ''            Return False
        ' ''        End If

        ' ''        prmProveedor.ProveedoresContactos.ClasePadre = prmProveedor
        ' ''        If Not Guardar(prmProveedor.ProveedoresContactos, prmProveedor.Folio) Then
        ' ''            Return False
        ' ''        End If

        ' ''        prmProveedor.ProveedoresProntosPagos.ClasePadre = prmProveedor
        ' ''        If Not Guardar(prmProveedor.ProveedoresProntosPagos, prmProveedor.Folio) Then
        ' ''            Return False
        ' ''        End If

        ' ''        'prmProveedor.ProveedoresCuentasContables.ClasePadre = prmProveedor
        ' ''        'If Not Guardar(prmProveedor.ProveedoresCuentasContables, prmProveedor.Folio) Then
        ' ''        '    Return False
        ' ''        'End If

        ' ''        If Not prmProveedor.Observacion Is Nothing Then
        ' ''            prmProveedor.Observacion.Guardar()
        ' ''        End If

        ' ''        If Not Guardar(prmProveedor.ProveedoresCuentasBancarias, prmProveedor.Folio) Then
        ' ''            Return False
        ' ''        End If

        ' ''    End If

        ' ''    If Not prmProveedor.atrGrabarLocal Then
        ' ''        If Not prmProveedor.EnviarWs() Then
        ' ''            Return False
        ' ''        End If
        ' ''    End If


        ' ''    If vlbAbrio Then
        ' ''        DAO.CierraTransaccion()
        ' ''    End If

        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal PrmProveedorObservacion As Proveedores.ClsProveedorObservaciones) As Boolean
        ' ''    PrmProveedorObservacion.atrNombreCampos = "nObservacion,nProveedor,dFecha,cObservacion,CUSUARIO_REGISTRO,DFECHA_REGISTRO,CMAQUINA_REGISTRO,CUSUARIO_ULTIMAMODIFICACION,DFECHA_ULTIMAMODIFICACION,CMAQUINA_ULTIMAMODIFICACION,CUSUARIO_ELIMINACION,DFECHA_ELIMINACION,CMAQUINA_ELIMINACION,"
        ' ''    PrmProveedorObservacion.atrNombreTabla = "CTL_ProveedoresObservaciones"

        ' ''    If Not PrmProveedorObservacion.GuardarNuevo Then
        ' ''        Return False
        ' ''    End If
        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmProveedorObservaciones As Proveedores.ClsContieneProveedorObservaciones, ByVal PrmProveedor As Integer) As Boolean
        ' ''    Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''    Dim sdaProveedoresObservaciones As New SqlClient.SqlDataAdapter
        ' ''    Dim dttProveedoresObservaciones As New DataTable
        ' ''    Dim vSql As String
        ' ''    Dim vlCont As Integer

        ' ''    vSql = "DELETE CTL_ProveedoresObservaciones" & vbCr
        ' ''    vSql &= "WHERE nProveedor= " & PrmProveedor
        ' ''    If Not DAO.EjecutaComandoSQL(vSql) Then Return False

        ' ''    If prmProveedorObservaciones.ArregloDT.Rows.Count = 0 Then
        ' ''        Return True
        ' ''    End If

        ' ''    vSql = "SELECT nObservacion,nProveedor,dFecha,cObservacion" & vbCr
        ' ''    vSql &= "FROM CTL_ProveedoresObservaciones(NOLOCK)" & vbCr
        ' ''    vSql &= "WHERE 1=0"

        ' ''    DAO.LlenaTablaDeDatos(vSql, sdaProveedoresObservaciones, dttProveedoresObservaciones)

        ' ''    For Each vRow As DataRow In prmProveedorObservaciones.ArregloDT.Rows
        ' ''        If vRow("nObservacion") = 0 Then
        ' ''            vlCont = IIf(vlCont = 0, ObtenFolioProveedoresObservaciones(PrmProveedor), vlCont + 1)
        ' ''            vRow("nObservacion") = vlCont
        ' ''        End If
        ' ''    Next

        ' ''    prmProveedorObservaciones.gbEsCatalogo = True
        ' ''    If Not prmProveedorObservaciones.Guardar(False) Then
        ' ''        Return False
        ' ''    End If

        ' ''    prmProveedorObservaciones.ArregloDT.AcceptChanges()

        ' ''    Return True

        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmProveedorObservacion As Proveedores.ClsProveedorBitacoraObservaciones) As Boolean
        ' ''    prmProveedorObservacion.atrNombreCampos = "nObservacion,nProveedor,dFecha,cObservacion"
        ' ''    prmProveedorObservacion.atrNombreTabla = "CTL_ProveedoresObservaciones"

        ' ''    If Not prmProveedorObservacion.GuardarNuevo Then
        ' ''        Return False
        ' ''    End If
        ' ''    'Dim ABRIO As Boolean
        ' ''    'If Not DAO.TieneTransaccionAbierta Then
        ' ''    '    ABRIO = True
        ' ''    '    DAO.AbreTransaccion()
        ' ''    'End If
        ' ''    'If Not prmProveedorObservacion.GuardarBase Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'prmProveedorObservacion.atrSql = "SELECT nObservacion,nProveedor,dFecha,cObservacion" & vbCr
        ' ''    'prmProveedorObservacion.atrSql &= "FROM CTL_ProveedoresObservaciones (NOLOCK)" & vbCr
        ' ''    'prmProveedorObservacion.atrSql &= "WHERE nObservacion = " & prmProveedorObservacion.Folio & vbCr
        ' ''    'prmProveedorObservacion.atrSql &= "AND nProveedor = " & prmProveedorObservacion.Proveedor

        ' ''    'If Not prmProveedorObservacion.setRowAccion Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'prmProveedorObservacion.atrRow("nObservacion") = prmProveedorObservacion.Folio
        ' ''    'prmProveedorObservacion.atrRow("nProveedor") = prmProveedorObservacion.Proveedor
        ' ''    'prmProveedorObservacion.atrRow("dFecha") = prmProveedorObservacion.Fecha
        ' ''    'prmProveedorObservacion.atrRow("cObservacion") = prmProveedorObservacion.Observacion


        ' ''    'If Not prmProveedorObservacion.GuardarGenerico Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'If ABRIO Then
        ' ''    '    DAO.CierraTransaccion()
        ' ''    'End If

        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmProveedorCuentasBancarias As Proveedores.ClsContieneProveedorCuentasBancarias, ByVal PrmProveedor As Integer) As Boolean
        ' ''    Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''    Dim sdaProveedoresCuentasBancarias As New SqlClient.SqlDataAdapter
        ' ''    Dim dttProveedoresCuentasBancarias As New DataTable
        ' ''    Dim ObjProveedorCuentasBancarias As New DataTable
        ' ''    Dim vlCont As Integer
        ' ''    Dim vSql As String

        ' ''    'If Not prmProveedorCuentasBancarias.BorrarVerificandoDependencias Then
        ' ''    '    Return False
        ' ''    'End If





        ' ''    If Not prmProveedorCuentasBancarias.TablaDiseño Is Nothing Then
        ' ''        If prmProveedorCuentasBancarias.TablaDiseño.Rows.Count = 0 Then
        ' ''            vSql = "UPDATE CTL_ProveedoresCuentasBancarias" & vbCr
        ' ''            vSql &= "SET bActivo=0" & vbCr
        ' ''            vSql &= "WHERE nProveedor= " & PrmProveedor
        ' ''            If Not DAO.EjecutaComandoSQL(vSql) Then Return False
        ' ''            Return True
        ' ''        End If
        ' ''    End If

        ' ''    vSql = "SELECT nCuentaBancaria,nProveedor,nBanco,cSucursal,cCuenta,cCLABE,cObservaciones,bActivo" & vbCr
        ' ''    vSql &= "FROM CTL_ProveedoresCuentasBancarias(NOLOCK)" & vbCr
        ' ''    vSql &= "WHERE 1=0 "

        ' ''    'DAO.LlenaTablaDeDatos(vSql, sdaProveedoresCuentasBancarias, dttProveedoresCuentasBancarias)

        ' ''    'For Each vRow As DataRow In prmProveedorCuentasBancarias.ArregloDT.Rows
        ' ''    '    If vRow("nProntoPago") Is DBNull.Value Then
        ' ''    '        vRow("nProntoPago") = 0
        ' ''    '    End If

        ' ''    '    If vRow("nProntoPago") = 0 Then
        ' ''    '        vlCont = IIf(vlCont = 0, ObtenFolioProveedoresProntosPagos(PrmProveedor), vlCont + 1)
        ' ''    '        vRow("nProntoPago") = vlCont
        ' ''    '    End If
        ' ''    'Next


        ' ''    'If prmProveedorCuentasBancarias.TablaDiseño.Columns.Count = 8 Then
        ' ''    '    prmProveedorCuentasBancarias.TablaDiseño.Columns.Remove("cCuentaBancaria")
        ' ''    '    prmProveedorCuentasBancarias.TablaDiseño.AcceptChanges()
        ' ''    'End If

        ' ''    If prmProveedorCuentasBancarias.ArregloDataTable.Columns.Count = 9 Then
        ' ''        prmProveedorCuentasBancarias.ArregloDataTable.Columns.Remove("cbanco")
        ' ''        prmProveedorCuentasBancarias.ArregloDataTable.AcceptChanges()
        ' ''    End If
        ' ''    If Not prmProveedorCuentasBancarias.TablaDiseño Is Nothing Then
        ' ''        If prmProveedorCuentasBancarias.TablaDiseño.Columns.Count = 9 Then
        ' ''            prmProveedorCuentasBancarias.TablaDiseño.Columns.Remove("cBanco")
        ' ''            prmProveedorCuentasBancarias.TablaDiseño.AcceptChanges()
        ' ''        End If
        ' ''    End If

        ' ''    prmProveedorCuentasBancarias.gbEsCatalogo = True
        ' ''    If Not prmProveedorCuentasBancarias.Guardar(False) Then
        ' ''        Return False
        ' ''    End If

        ' ''    prmProveedorCuentasBancarias.ArregloDT.AcceptChanges()

        ' ''    Return True

        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmProveedorContactos As Proveedores.ClsContieneProveedorContactos, ByVal PrmProveedor As Integer) As Boolean
        ' ''    Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''    Dim sdaProveedoresContactos As New SqlClient.SqlDataAdapter
        ' ''    Dim dttProveedoresContactos As New DataTable
        ' ''    Dim vSql As String
        ' ''    Dim vlCont As Integer


        ' ''    If Not prmProveedorContactos.TablaDiseño Is Nothing Then
        ' ''        If prmProveedorContactos.TablaDiseño.Rows.Count = 0 Then
        ' ''            vSql = "UPDATE CTL_ProveedoresContactos" & vbCr
        ' ''            vSql &= "SET bActivo=0" & vbCr
        ' ''            vSql &= "WHERE nProveedor= " & PrmProveedor
        ' ''            If Not DAO.EjecutaComandoSQL(vSql) Then Return False
        ' ''            Return True
        ' ''        End If
        ' ''    End If

        ' ''    vSql = "SELECT nProveedorContacto,nProveedor,cContacto,cPuesto,cTelefonoCelular,cTelefonoOficina,cTelefonoFax,cCorreoElectronico,bactivo" & vbCr
        ' ''    vSql &= "FROM CTL_ProveedoresContactos(NOLOCK)" & vbCr
        ' ''    vSql &= "WHERE 1=0"
        ' ''    DAO.LlenaTablaDeDatos(vSql, sdaProveedoresContactos, dttProveedoresContactos)

        ' ''    'For Each vRow As DataRow In prmProveedorContactos.ArregloDT.Rows
        ' ''    '    If vRow("nProveedorContacto") Is DBNull.Value OrElse vRow("nProveedorContacto") = 0 Then
        ' ''    'vlCont = IIf(vlCont = 0, ObtenFolioProveedoresContactos(PrmProveedor), vlCont + 1)
        ' ''    '        vRow("nProveedorContacto") = vlCont
        ' ''    '    End If
        ' ''    'Next


        ' ''    'If Not prmProveedorContactos.BorrarVerificandoDependencias Then Return False


        ' ''    prmProveedorContactos.gbEsCatalogo = True
        ' ''    If Not prmProveedorContactos.Guardar(False, False, Not prmProveedorContactos.ClasePadre.atrGrabarLocal) Then
        ' ''        Return False
        ' ''    End If

        ' ''    prmProveedorContactos.ArregloDT.AcceptChanges()

        ' ''    Return True
        ' ''End Function


        ' ''Public Shared Function Guardar(ByVal prmProveedorProntosPagos As Proveedores.ClsContieneProveedorProntosPagos, ByVal PrmProveedor As Integer) As Boolean
        ' ''    Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''    Dim sdaProveedoresProntosPagos As New SqlClient.SqlDataAdapter
        ' ''    Dim dttProveedoresProntosPagos As New DataTable
        ' ''    Dim vSql As String
        ' ''    Dim vlCont As Integer


        ' ''    'If Not prmProveedorProntosPagos.BorrarVerificandoDependencias Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    '

        ' ''    '
        ' ''    If Not prmProveedorProntosPagos.TablaDiseño Is Nothing Then
        ' ''        If prmProveedorProntosPagos.TablaDiseño.Rows.Count = 0 Then
        ' ''            vSql = "UPDATE CTL_ProveedoresProntosPagos" & vbCr
        ' ''            vSql &= "SET bActivo=0" & vbCr
        ' ''            vSql &= "WHERE nProveedor= " & PrmProveedor
        ' ''            If Not DAO.EjecutaComandoSQL(vSql) Then Return False
        ' ''            Return True
        ' ''        End If
        ' ''    End If

        ' ''    vSql = "SELECT nProntoPago,nProveedor,dFecha,nDescuento,nDias,nContacto,bactivo" & vbCr
        ' ''    vSql &= "FROM CTL_ProveedoresProntosPagos(NOLOCK)" & vbCr
        ' ''    vSql &= "WHERE 1=0"

        ' ''    'DAO.LlenaTablaDeDatos(vSql, sdaProveedoresProntosPagos, dttProveedoresProntosPagos)

        ' ''    'For Each vRow As DataRow In prmProveedorProntosPagos.ArregloDT.Rows
        ' ''    '    If vRow("nProntoPago") Is DBNull.Value Then
        ' ''    '        vRow("nProntoPago") = 0
        ' ''    '    End If

        ' ''    '    If vRow("nProntoPago") = 0 Then
        ' ''    '        vlCont = IIf(vlCont = 0, ObtenFolioProveedoresProntosPagos(PrmProveedor), vlCont + 1)
        ' ''    '        vRow("nProntoPago") = vlCont
        ' ''    '    End If
        ' ''    'Next


        ' ''    If prmProveedorProntosPagos.ArregloDataTable.Columns.Count = 8 Then
        ' ''        prmProveedorProntosPagos.ArregloDataTable.Columns.Remove("ccontacto")
        ' ''        prmProveedorProntosPagos.ArregloDataTable.AcceptChanges()
        ' ''    End If
        ' ''    If Not prmProveedorProntosPagos.TablaDiseño Is Nothing Then
        ' ''        If prmProveedorProntosPagos.TablaDiseño.Columns.Count = 8 Then
        ' ''            prmProveedorProntosPagos.TablaDiseño.Columns.Remove("cContacto")
        ' ''            prmProveedorProntosPagos.TablaDiseño.AcceptChanges()
        ' ''        End If
        ' ''    End If

        ' ''    prmProveedorProntosPagos.gbEsCatalogo = True
        ' ''    If Not prmProveedorProntosPagos.Guardar() Then
        ' ''        Return False
        ' ''    End If

        ' ''    prmProveedorProntosPagos.ArregloDT.AcceptChanges()

        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmProveedorArticulos As Proveedores.ClsContieneProveedorArticulos, ByVal PrmProveedor As Integer) As Boolean
        ' ''    Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''    Dim sdaProveedoresArticulos As New SqlClient.SqlDataAdapter
        ' ''    Dim dttProveedoresArticulos As New DataTable
        ' ''    Dim vSql As String
        ' ''    Dim vlCont As Integer

        ' ''    If Not prmProveedorArticulos.TablaDiseño Is Nothing Then
        ' ''        If prmProveedorArticulos.TablaDiseño.Rows.Count = 0 Then
        ' ''            vSql = "UPDATE CTL_ProveedoresArticulos" & vbCr
        ' ''            vSql &= "SET bActivo=0" & vbCr
        ' ''            vSql &= "WHERE nProveedor= " & PrmProveedor
        ' ''            If Not DAO.EjecutaComandoSQL(vSql) Then Return False
        ' ''            Return True
        ' ''        End If
        ' ''    End If

        ' ''    vSql = "SELECT nProveedor,nPlaza,nArticulo,nPresentacion,nMarca,cCodigoProveedor,bActivo,nPrecioLista " & vbCr
        ' ''    vSql &= "FROM CTL_ProveedoresArticulos(NOLOCK)" & vbCr
        ' ''    vSql &= "WHERE 1=0"
        ' ''    DAO.LlenaTablaDeDatos(vSql, sdaProveedoresArticulos, dttProveedoresArticulos)

        ' ''    If Not prmProveedorArticulos.TablaDiseño Is Nothing Then
        ' ''        If prmProveedorArticulos.TablaDiseño.Columns.Count = 17 Then
        ' ''            prmProveedorArticulos.TablaDiseño.Columns.Remove("cCodigo")
        ' ''            prmProveedorArticulos.TablaDiseño.Columns.Remove("cArticulo")
        ' ''            prmProveedorArticulos.TablaDiseño.Columns.Remove("cMarca")
        ' ''            prmProveedorArticulos.TablaDiseño.Columns.Remove("cPresentacion")
        ' ''            prmProveedorArticulos.TablaDiseño.Columns.Remove("oArticulo")
        ' ''            prmProveedorArticulos.TablaDiseño.Columns.Remove("oPresentacion")
        ' ''            prmProveedorArticulos.TablaDiseño.Columns.Remove("oMarca")
        ' ''            prmProveedorArticulos.TablaDiseño.Columns.Remove("oPlaza")
        ' ''            prmProveedorArticulos.TablaDiseño.Columns.Remove("cPlaza")
        ' ''        End If
        ' ''    End If

        ' ''    prmProveedorArticulos.gbEsCatalogo = True
        ' ''    If Not prmProveedorArticulos.Guardar() Then
        ' ''        Return False
        ' ''    End If

        ' ''    prmProveedorArticulos.ArregloDT.AcceptChanges()

        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmProveedorClasificadores As Proveedores.ClsContieneProveedorClasificadores, ByVal PrmProveedor As Integer) As Boolean
        ' ''    Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''    Dim sdaProveedoresClasificadores As New SqlClient.SqlDataAdapter
        ' ''    Dim dttProveedoresClasificadores As New DataTable
        ' ''    Dim vSql As String

        ' ''    vSql = "DELETE CTL_ProveedoresClasificadores" & vbCr
        ' ''    vSql &= "WHERE nProveedor= " & PrmProveedor
        ' ''    If Not DAO.EjecutaComandoSQL(vSql) Then Return False

        ' ''    If prmProveedorClasificadores.ArregloDT.Rows.Count = 0 Then
        ' ''        Return True
        ' ''    End If


        ' ''    vSql = "SELECT nClasificador,nProveedor,cValor" & vbCr
        ' ''    vSql &= "FROM CTL_ProveedoresArticulos(NOLOCK)" & vbCr
        ' ''    vSql &= "WHERE 1=0"
        ' ''    DAO.LlenaTablaDeDatos(vSql, sdaProveedoresClasificadores, dttProveedoresClasificadores)

        ' ''    For Each vRow As DataRow In prmProveedorClasificadores.ArregloDT.Rows
        ' ''        If vRow("nClasificador") = 0 Then
        ' ''            vRow("nClasificador") = DAO.FolioAdministradoSiguiente(prmProveedorClasificadores.getNombreFolioAdministrado)
        ' ''        End If
        ' ''    Next

        ' ''    prmProveedorClasificadores.gbEsCatalogo = True
        ' ''    If Not prmProveedorClasificadores.Guardar(False) Then
        ' ''        Return False
        ' ''    End If

        ' ''    prmProveedorClasificadores.ArregloDT.AcceptChanges()

        ' ''    Return True
        ' ''End Function


        ' ''Public Shared Function Guardar(ByVal prmProveedorCuentasContables As Proveedores.ClsContieneProveedorCuentasContables, ByVal PrmProveedor As Integer) As Boolean
        ' ''    Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''    Dim sdaProveedoresCuentasContables As New SqlClient.SqlDataAdapter
        ' ''    Dim dttProveedoresCuentasContables As New DataTable
        ' ''    Dim vSql As String
        ' ''    Dim vlCont As Integer

        ' ''    vSql = "SELECT nProveedorCuentaCnt,nProveedor,nPlaza,nCuentaCnt" & vbCr
        ' ''    vSql &= "FROM CTL_ProveedoresCuentasContables(NOLOCK)" & vbCr
        ' ''    vSql &= "WHERE 1=0"
        ' ''    DAO.LlenaTablaDeDatos(vSql, sdaProveedoresCuentasContables, dttProveedoresCuentasContables)

        ' ''    'For Each vRow As DataRow In prmProveedorContactos.ArregloDT.Rows
        ' ''    '    If vRow("nProveedorContacto") Is DBNull.Value OrElse vRow("nProveedorContacto") = 0 Then
        ' ''    'vlCont = IIf(vlCont = 0, ObtenFolioProveedoresContactos(PrmProveedor), vlCont + 1)
        ' ''    '        vRow("nProveedorContacto") = vlCont
        ' ''    '    End If
        ' ''    'Next


        ' ''    'If Not prmProveedorContactos.BorrarVerificandoDependencias Then Return False


        ' ''    prmProveedorCuentasContables.gbEsCatalogo = True
        ' ''    If Not prmProveedorCuentasContables.Guardar(False, False, Not prmProveedorCuentasContables.ClasePadre.atrGrabarLocal) Then
        ' ''        Return False
        ' ''    End If

        ' ''    prmProveedorCuentasContables.ArregloDT.AcceptChanges()

        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmCliente As Distribucion.ClsClientes) As Boolean
        ' ''    prmCliente.atrNombreCampos = "nCliente,cNombreFiscal,cNombreComercial,cNombreCorto,cRFC,cCurp,nPlaza,bExcentoDomicilio,cObservaciones,cPais,nEstado,nMunicipio,nCiudad,nColonia,cDomicilio,cCorreoElectronico,cContacto,cRFCSecundario,cTelefonoUno,cTelefonoDos,cTelefonoFax,bActivo,cUsuario_Registro,dFecha_Registro,cMaquina_Registro,cUsuario_UltimaModificacion,dFecha_UltimaModificacion,cMaquina_UltimaModificacion,cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion,bClienteEspecial"
        ' ''    prmCliente.atrNombreTabla = "CTL_CLIENTES"

        ' ''    prmCliente.ValidaSiEsAlmacenCorporativoProduccion = True
        ' ''    If Not prmCliente.GuardarNuevo(True) Then
        ' ''        Return False
        ' ''    End If

        ' ''    If Not prmCliente.atrGrabarLocal Then
        ' ''        If Not prmCliente.EnviarWs() Then
        ' ''            Return False
        ' ''        End If
        ' ''    End If
        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmProducto As ClsProducto) As Boolean
        ' ''    prmProducto.atrNombreCampos = "nProducto,cCodigo,cCodigoCorto,cDescripcion,cNombreCorto,cIdentificador,"
        ' ''    prmProducto.atrNombreCampos &= "nLinea,nTipoProducto,nUnidad,bIncluirInventarioDia,bInventariar,bEmpacable,"
        ' ''    prmProducto.atrNombreCampos &= "bEsSecuenciado,nImpuesto,nCajetes,nMoldes,bActivo,"
        ' ''    prmProducto.atrNombreCampos &= "nGrupo,nTamanio,bSeRebana,bProductoRebanado,nProductoRebanado,"
        ' ''    prmProducto.atrNombreCampos &= "nCantidadRebanadas,bManejaColor,bUnidadCosteo,bProductoFinal,"
        ' ''    prmProducto.atrNombreCampos &= "nPorcentajeVuelta1,nPorcentajeVuelta2,nPorcentajeVuelta3,nPorcentajeVuelta4,cTipoVenta,bModificaPrecio,cTipoVentaCambioPrecio,"
        ' ''    prmProducto.atrNombreCampos &= "cUsuario_Registro,dFecha_Registro,cMaquina_Registro,"
        ' ''    prmProducto.atrNombreCampos &= "cUsuario_UltimaModificacion,dFecha_UltimaModificacion,cMaquina_UltimaModificacion,"
        ' ''    prmProducto.atrNombreCampos &= "cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion"

        ' ''    prmProducto.atrNombreTabla = "CTL_PRODUCTOS"
        ' ''    prmProducto.ValidaSiEsAlmacenCorporativoProduccion = True
        ' ''    If Not prmProducto.GuardarNuevo(True) Then
        ' ''        Return False
        ' ''    End If
        ' ''    'prmArticulo.DTPresentaciones.ClasePadre = prmArticulo
        ' ''    'prmArticulo.DTCodigosProveedor.ClasePadre = prmArticulo
        ' ''    'prmArticulo.DTImpuestos.ClasePadre = prmArticulo
        ' ''    'prmArticulo.DTPrecios.ClasePadre = prmArticulo
        ' ''    'prmArticulo.DTPresentaciones.ClasePadre = prmArticulo
        ' ''    'prmArticulo.DTUbicaciones.ClasePadre = prmArticulo
        ' ''    'For Each vrow As DataRow In prmArticulo.DTPresentaciones.TablaDiseño.Rows
        ' ''    '    vrow("narticulo") = prmArticulo.Folio
        ' ''    '    vrow("bactivo") = True
        ' ''    'Next

        ' ''    'For Each vrow As DataRow In prmArticulo.DTImpuestos.TablaDiseño.Rows
        ' ''    '    vrow("narticulo") = prmArticulo.Folio
        ' ''    '    vrow("bactivo") = True
        ' ''    'Next

        ' ''    'If prmArticulo.DTImpuestos.TablaDiseño.Columns.Count = 5 Then
        ' ''    '    prmArticulo.DTImpuestos.TablaDiseño.Columns.Remove("cDescripcion")
        ' ''    '    prmArticulo.DTImpuestos.TablaDiseño.Columns.Remove("nPorcentaje")
        ' ''    'End If

        ' ''    'If Not prmArticulo.DTPresentaciones.TablaDiseño.Columns("cPresentacionConversion") Is Nothing Then
        ' ''    '    prmArticulo.DTPresentaciones.TablaDiseño.Columns.Remove("cPresentacionConversion")
        ' ''    'End If

        ' ''    'If Not prmArticulo.DTPresentaciones.ArregloDataTable.Columns("cPresentacionConversion") Is Nothing Then
        ' ''    '    prmArticulo.DTPresentaciones.ArregloDataTable.Columns.Remove("cPresentacionConversion")
        ' ''    'End If

        ' ''    'If Not prmArticulo.DTPresentaciones.Guardar Then
        ' ''    '    Return False
        ' ''    'End If


        ' ''    'For Each dr As DataRow In prmArticulo.DTImpuestos.ArregloDataTable.Rows
        ' ''    '    dr("nArticulo") = prmArticulo.Folio
        ' ''    'Next

        ' ''    'If Not prmArticulo.DTImpuestos.Guardar Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'If Not prmArticulo.DTCodigosProveedor Is Nothing Then
        ' ''    '    If Not prmArticulo.DTCodigosProveedor.Guardar Then
        ' ''    '        Return False
        ' ''    '    End If
        ' ''    'End If

        ' ''    'If Not prmArticulo.DTUbicaciones.Guardar Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    If Not prmProducto.atrGrabarLocal Then
        ' ''        If Not prmProducto.EnviarWs() Then
        ' ''            Return False
        ' ''        End If
        ' ''    End If
        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function ActualizaEstatusCodigoBarraSerial(ByVal prmCodigosBarra As String, ByVal prmEstatus As Int32, ByVal prmFiltroPadre As String) As Boolean
        ' ''    Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''    Dim vcSQL As String = "UPDATE CTL_ProductosCodigosBarra SET nEstatus = {0} " & vbCr

        ' ''    vcSQL &= " WHERE nCodigoBarra IN ({1}) "
        ' ''    vcSQL = String.Format(vcSQL, prmEstatus, prmCodigosBarra)
        ' ''    If Not prmFiltroPadre.Trim = "" Then
        ' ''        vcSQL &= " AND " & prmFiltroPadre.Trim
        ' ''    End If
        ' ''    Return DAO.EjecutaComandoSQL(vcSQL)
        ' ''End Function

        ' ''Public Shared Function AsignaPadreCodigosBarraSerial(ByVal prmCodigosBarra As String, ByVal prmMovimientoAlmacen As Long) As Boolean
        ' ''    Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''    Dim vcSQL As String = "UPDATE CTL_ProductosCodigosBarra SET nMovimientoAlmacen = {0} " & vbCr

        ' ''    vcSQL &= " WHERE nCodigoBarra IN ({1}) "
        ' ''    vcSQL = String.Format(vcSQL, prmMovimientoAlmacen, prmCodigosBarra)
        ' ''    Return DAO.EjecutaComandoSQL(vcSQL)
        ' ''End Function

        ' ''Public Shared Function QuitaPadreCodigosBarraSerial(ByVal prmCodigosBarra As String, ByVal prmMovimientoAlmacen As Long) As Boolean
        ' ''    Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''    Dim vcSQL As String = "UPDATE CTL_ProductosCodigosBarra SET nMovimientoAlmacen = NULL " & vbCr
        ' ''    vcSQL &= " WHERE nCodigoBarra IN ({0}) AND nMovimientoAlmacen = " & prmMovimientoAlmacen
        ' ''    vcSQL = String.Format(vcSQL, prmCodigosBarra)
        ' ''    Return DAO.EjecutaComandoSQL(vcSQL)
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmCodigoBarra As ClsProductosCodigosBarra) As Boolean
        ' ''    prmCodigoBarra.atrNombreCampos = "nCodigoBarra,nAlmacen,nProducto,nColor,cCodigoBarra,nCodigoBarra2,bActivo,nEstatus,nProgramacion,nOrigen,nMovimientoAlmacen"
        ' ''    prmCodigoBarra.atrNombreCampos &= " ,cUsuario_Registro, dFecha_Registro, cMaquina_Registro ,cUsuario_UltimaModificacion ,dFecha_UltimaModificacion ,cMaquina_UltimaModificacion" & vbCr
        ' ''    prmCodigoBarra.atrNombreCampos &= " ,cUsuario_Eliminacion ,dFecha_Eliminacion ,cMaquina_Eliminacion" & vbCr
        ' ''    prmCodigoBarra.atrNombreTabla = "CTL_ProductosCodigosBarra"

        ' ''    If Not prmCodigoBarra.GuardarNuevo(True) Then
        ' ''        Return False
        ' ''    End If

        ' ''    If Not prmCodigoBarra.atrGrabarLocal Then
        ' ''        If Not prmCodigoBarra.EnviarWs() Then
        ' ''            Return False
        ' ''        End If
        ' ''    End If
        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmArticulo As ClsArticulo) As Boolean
        ' ''    Dim prmEnviaWS As Boolean = False

        ' ''    prmArticulo.atrNombreCampos = "NARTICULO,CCODIGO,CDESCRIPCION,NTIPOARTICULO,cNombreCorto,nlinea,nunidad,bcambiamarca,BTARA,NMARCA,BDRENADO,BINVENTARIAR,NORDEN,BACTIVO,CUSUARIO_REGISTRO,DFECHA_REGISTRO,CMAQUINA_REGISTRO,CUSUARIO_ULTIMAMODIFICACION,DFECHA_ULTIMAMODIFICACION,CMAQUINA_ULTIMAMODIFICACION,CUSUARIO_ELIMINACION,DFECHA_ELIMINACION,CMAQUINA_ELIMINACION,bEsMuestra"
        ' ''    prmArticulo.atrNombreTabla = "CTL_ARTICULOS"

        ' ''    If Not prmArticulo.GuardarNuevo(True, , , prmEnviaWS) Then
        ' ''        Return False
        ' ''    End If

        ' ''    prmArticulo.DTPresentaciones.ClasePadre = prmArticulo
        ' ''    prmArticulo.DTCodigosProveedor.ClasePadre = prmArticulo
        ' ''    prmArticulo.DTImpuestos.ClasePadre = prmArticulo
        ' ''    prmArticulo.DTPrecios.ClasePadre = prmArticulo
        ' ''    prmArticulo.DTPresentaciones.ClasePadre = prmArticulo
        ' ''    prmArticulo.DTUbicaciones.ClasePadre = prmArticulo

        ' ''    If Not prmArticulo.EsCancelarArticulo Then
        ' ''        For Each vrow As DataRow In prmArticulo.DTPresentaciones.TablaDiseño.Rows
        ' ''            vrow("narticulo") = prmArticulo.Folio
        ' ''            vrow("bactivo") = True
        ' ''            '  vrow("cDescripcion") = vrow("cDescripcion") & " " & vrow("nEquivalencia")
        ' ''        Next

        ' ''        For Each vrow As DataRow In prmArticulo.DTImpuestos.TablaDiseño.Rows
        ' ''            vrow("narticulo") = prmArticulo.Folio
        ' ''            vrow("bactivo") = True
        ' ''        Next

        ' ''        If prmArticulo.DTImpuestos.TablaDiseño.Columns.Count = 5 Then
        ' ''            prmArticulo.DTImpuestos.TablaDiseño.Columns.Remove("cDescripcion")
        ' ''            prmArticulo.DTImpuestos.TablaDiseño.Columns.Remove("nPorcentaje")
        ' ''        End If

        ' ''        If Not prmArticulo.DTPresentaciones.TablaDiseño.Columns("cPresentacionConversion") Is Nothing Then
        ' ''            prmArticulo.DTPresentaciones.TablaDiseño.Columns.Remove("cPresentacionConversion")
        ' ''        End If

        ' ''        If Not prmArticulo.DTPresentaciones.ArregloDataTable.Columns("cPresentacionConversion") Is Nothing Then
        ' ''            prmArticulo.DTPresentaciones.ArregloDataTable.Columns.Remove("cPresentacionConversion")
        ' ''        End If

        ' ''        If Not prmArticulo.DTPresentaciones.TablaDiseño.Columns("iImagen") Is Nothing Then
        ' ''            prmArticulo.DTPresentaciones.TablaDiseño.Columns.Remove("iImagen")
        ' ''        End If
        ' ''        If Not prmArticulo.DTPresentaciones.TablaDiseño.Columns("ImagenBitMap") Is Nothing Then
        ' ''            prmArticulo.DTPresentaciones.TablaDiseño.Columns.Remove("ImagenBitMap")
        ' ''        End If


        ' ''        If Not prmArticulo.DTPresentaciones.Guardar Then
        ' ''            Return False
        ' ''        End If


        ' ''        For Each dr As DataRow In prmArticulo.DTImpuestos.ArregloDataTable.Rows
        ' ''            dr("nArticulo") = prmArticulo.Folio
        ' ''        Next

        ' ''        If Not prmArticulo.DTImpuestos.Guardar Then
        ' ''            Return False
        ' ''        End If

        ' ''        If Not prmArticulo.DTCodigosProveedor Is Nothing Then
        ' ''            If Not prmArticulo.DTCodigosProveedor.Guardar Then
        ' ''                Return False
        ' ''            End If
        ' ''        End If

        ' ''        prmArticulo.DTUbicaciones.SincronizaArregloConArray()

        ' ''        If Not prmArticulo.DTUbicaciones.ArregloDataTable.Columns("cDescripcion") Is Nothing Then
        ' ''            prmArticulo.DTUbicaciones.ArregloDataTable.Columns.Remove("cDescripcion")
        ' ''        End If

        ' ''        If Not prmArticulo.DTUbicaciones.Guardar Then
        ' ''            Return False
        ' ''        End If
        ' ''    End If


        ' ''    If Not prmArticulo.atrGrabarLocal Then
        ' ''        If Not prmArticulo.EnviarWs() Then
        ' ''            Return False
        ' ''        End If
        ' ''    Else
        ' ''        '' Al Grabar Local, necesito enviar el WS a todas las plazas 

        ' ''        Dim dtplazas As New DataTable

        ' ''        Try
        ' ''            DAO.RegresaConsultaSQL("SELECT curlcatalogos FROM WS_PlazaURL (NOLOCK)", dtplazas)
        ' ''            For Each vrow As DataRow In dtplazas.Rows
        ' ''                If Not prmArticulo.EnviarWs(vrow("curlcatalogos"), True, , , , , True) Then
        ' ''                    Return False
        ' ''                End If
        ' ''            Next
        ' ''        Catch ex As Exception

        ' ''        End Try
        ' ''    End If

        ' ''    'If Not Tool.InsertaYActualizaTablaDeBD(prmArticulo.DTClasificadores) Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'If Not Tool.InsertaYActualizaTablaDeBD(prmArticulo.DTCodigosProveedor) Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'If Not Tool.InsertaYActualizaTablaDeBD(prmArticulo.DTImpuestos) Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'If Not Tool.InsertaYActualizaTablaDeBD(prmArticulo.DTPresentaciones) Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'If Not Tool.InsertaYActualizaTablaDeBD(prmArticulo.DTUbicaciones) Then
        ' ''    '    Return False
        ' ''    'End If
        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmArea As ClsArea) As Boolean
        ' ''    prmArea.atrNombreCampos = "nArea,cDescripcion,ndepartamento,bActivo,dFecha_Registro,cMaquina_Registro,cUsuario_Registro,cUsuario_UltimaModificacion, dFecha_UltimaModificacion, cMaquina_UltimaModificacion,cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion"
        ' ''    prmArea.atrNombreTabla = "CTL_Areas"

        ' ''    If Not prmArea.GuardarNuevo Then
        ' ''        Return False
        ' ''    End If
        ' ''    'Dim ABRIO As Boolean
        ' ''    'If Not DAO.TieneTransaccionAbierta Then
        ' ''    '    ABRIO = True
        ' ''    '    DAO.AbreTransaccion()
        ' ''    'End If
        ' ''    'If Not prmArea.GuardarBase Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'prmArea.atrSql = "SELECT nArea,cDescripcion,ndepartamento,bActivo," & vbCr
        ' ''    'prmArea.atrSql &= "dFecha_Registro,cMaquina_Registro,cUsuario_Registro," & vbCr
        ' ''    'prmArea.atrSql &= "cUsuario_UltimaModificacion, dFecha_UltimaModificacion, cMaquina_UltimaModificacion, " & vbCr
        ' ''    'prmArea.atrSql &= "cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion" & vbCr
        ' ''    'prmArea.atrSql &= "FROM CTL_Areas(NOLOCK) " & vbCr
        ' ''    'prmArea.atrSql &= "WHERE nArea = " & prmArea.Folio

        ' ''    'If Not prmArea.setRowAccion Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'prmArea.atrRow("nArea") = prmArea.Folio
        ' ''    'prmArea.atrRow("cDescripcion") = prmArea.Descripcion
        ' ''    'prmArea.atrRow("nDepartamento") = prmArea.Departamento.Folio
        ' ''    'prmArea.atrRow("bActivo") = prmArea.Activo

        ' ''    'prmArea.LLenaDatosRegistroComun(prmArea.atrRow)

        ' ''    'If Not prmArea.GuardarGenerico Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'If ABRIO Then
        ' ''    '    DAO.CierraTransaccion()
        ' ''    'End If

        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmPuesto As ClsPuesto) As Boolean
        ' ''    prmPuesto.atrNombreCampos = "nPuesto,cDescripcion,bActivo,dFecha_Registro,cMaquina_Registro,cUsuario_Registro,cUsuario_UltimaModificacion, dFecha_UltimaModificacion, cMaquina_UltimaModificacion,cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion"
        ' ''    prmPuesto.atrNombreTabla = "CTL_Puestos"

        ' ''    If Not prmPuesto.GuardarNuevo Then
        ' ''        Return False
        ' ''    End If
        ' ''    'Dim ABRIO As Boolean
        ' ''    'If Not DAO.TieneTransaccionAbierta Then
        ' ''    '    ABRIO = True
        ' ''    '    DAO.AbreTransaccion()
        ' ''    'End If
        ' ''    'If Not prmPuesto.GuardarBase Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'prmPuesto.atrSql = "SELECT nPuesto,cDescripcion,bActivo," & vbCr
        ' ''    'prmPuesto.atrSql &= "dFecha_Registro,cMaquina_Registro,cUsuario_Registro," & vbCr
        ' ''    'prmPuesto.atrSql &= "cUsuario_UltimaModificacion, dFecha_UltimaModificacion, cMaquina_UltimaModificacion, " & vbCr
        ' ''    'prmPuesto.atrSql &= "cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion" & vbCr
        ' ''    'prmPuesto.atrSql &= "FROM CTL_Puestos(NOLOCK) " & vbCr
        ' ''    'prmPuesto.atrSql &= "WHERE nPuesto = " & prmPuesto.Folio

        ' ''    'If Not prmPuesto.setRowAccion Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'prmPuesto.atrRow("nPuesto") = prmPuesto.Folio
        ' ''    'prmPuesto.atrRow("cDescripcion") = prmPuesto.Descripcion
        ' ''    'prmPuesto.atrRow("bActivo") = prmPuesto.Activo

        ' ''    'prmPuesto.LLenaDatosRegistroComun(prmPuesto.atrRow)

        ' ''    'If Not prmPuesto.GuardarGenerico Then

        ' ''    '    Return False
        ' ''    'End If

        ' ''    'If ABRIO Then
        ' ''    '    DAO.CierraTransaccion()
        ' ''    'End If

        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmTurno As ClsTurno) As Boolean
        ' ''    prmTurno.atrNombreCampos = "nTurno,cDescripcion,bActivo,dFecha_Registro,cMaquina_Registro,cUsuario_Registro,cUsuario_UltimaModificacion, dFecha_UltimaModificacion, cMaquina_UltimaModificacion,cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion"
        ' ''    prmTurno.atrNombreTabla = "CTL_Turnos"

        ' ''    If Not prmTurno.GuardarNuevo Then
        ' ''        Return False
        ' ''    End If

        ' ''    'Dim ABRIO As Boolean
        ' ''    'If Not DAO.TieneTransaccionAbierta Then
        ' ''    '    ABRIO = True
        ' ''    '    DAO.AbreTransaccion()
        ' ''    'End If
        ' ''    'If Not prmTurno.GuardarBase Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'prmTurno.atrSql = "SELECT nTurno,cDescripcion,bActivo," & vbCr
        ' ''    'prmTurno.atrSql &= "dFecha_Registro,cMaquina_Registro,cUsuario_Registro," & vbCr
        ' ''    'prmTurno.atrSql &= "cUsuario_UltimaModificacion, dFecha_UltimaModificacion, cMaquina_UltimaModificacion, " & vbCr
        ' ''    'prmTurno.atrSql &= "cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion" & vbCr
        ' ''    'prmTurno.atrSql &= "FROM CTL_Turnos(NOLOCK) " & vbCr
        ' ''    'prmTurno.atrSql &= "WHERE nTurno = " & prmTurno.Folio

        ' ''    'If Not prmTurno.setRowAccion Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'prmTurno.atrRow("nTurno") = prmTurno.Folio
        ' ''    'prmTurno.atrRow("cDescripcion") = prmTurno.Descripcion
        ' ''    'prmTurno.atrRow("bActivo") = prmTurno.Activo

        ' ''    'prmTurno.LLenaDatosRegistroComun(prmTurno.atrRow)

        ' ''    'If Not prmTurno.GuardarGenerico Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'If ABRIO Then
        ' ''    '    DAO.CierraTransaccion()
        ' ''    'End If

        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmDepartamento As ClsDepartamento) As Boolean
        ' ''    prmDepartamento.atrNombreCampos = "nDepartamento,cDescripcion,bActivo,dFecha_Registro,cMaquina_Registro,cUsuario_Registro,cUsuario_UltimaModificacion, dFecha_UltimaModificacion, cMaquina_UltimaModificacion,cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion"
        ' ''    prmDepartamento.atrNombreTabla = "CTL_Departamentos"

        ' ''    If Not prmDepartamento.GuardarNuevo Then
        ' ''        Return False
        ' ''    End If
        ' ''    'Dim ABRIO As Boolean
        ' ''    'If Not DAO.TieneTransaccionAbierta Then
        ' ''    '    ABRIO = True
        ' ''    '    DAO.AbreTransaccion()
        ' ''    'End If
        ' ''    'If Not prmDepartamento.GuardarBase Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'prmDepartamento.atrSql = "SELECT nDepartamento,cDescripcion,bActivo," & vbCr
        ' ''    'prmDepartamento.atrSql &= "dFecha_Registro,cMaquina_Registro,cUsuario_Registro," & vbCr
        ' ''    'prmDepartamento.atrSql &= "cUsuario_UltimaModificacion, dFecha_UltimaModificacion, cMaquina_UltimaModificacion, " & vbCr
        ' ''    'prmDepartamento.atrSql &= "cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion" & vbCr
        ' ''    'prmDepartamento.atrSql &= "FROM CTL_Departamentos(NOLOCK) " & vbCr
        ' ''    'prmDepartamento.atrSql &= "WHERE nDepartamento = " & prmDepartamento.Folio

        ' ''    'If Not prmDepartamento.setRowAccion Then
        ' ''    '    Return False
        ' ''    'End If


        ' ''    'prmDepartamento.atrRow("nDepartamento") = prmDepartamento.Folio
        ' ''    'prmDepartamento.atrRow("cDescripcion") = prmDepartamento.Descripcion
        ' ''    'prmDepartamento.atrRow("bActivo") = prmDepartamento.Activo

        ' ''    'prmDepartamento.LLenaDatosRegistroComun(prmDepartamento.atrRow)

        ' ''    'If Not prmDepartamento.GuardarGenerico Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'If ABRIO Then
        ' ''    '    DAO.CierraTransaccion()
        ' ''    'End If

        ' ''    Return True
        ' ''End Function


        ' ''Public Shared Function Guardar(ByVal prmRegion As ClsRegion) As Boolean

        ' ''    prmRegion.atrNombreCampos = "NREGION,CDESCRIPCION,BACTIVO,CUSUARIO_REGISTRO,DFECHA_REGISTRO,CMAQUINA_REGISTRO,CUSUARIO_ULTIMAMODIFICACION,DFECHA_ULTIMAMODIFICACION,CMAQUINA_ULTIMAMODIFICACION,CUSUARIO_ELIMINACION,DFECHA_ELIMINACION,CMAQUINA_ELIMINACION"
        ' ''    prmRegion.atrNombreTabla = "CTL_REGIONES"

        ' ''    If Not prmRegion.GuardarNuevo Then
        ' ''        Return False
        ' ''    End If
        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmPlaza As ClsPlaza) As Boolean

        ' ''    prmPlaza.atrNombreCampos = "NPLAZA,CDESCRIPCION,NREGION,BACTIVO,CUSUARIO_REGISTRO,DFECHA_REGISTRO,CMAQUINA_REGISTRO,CUSUARIO_ULTIMAMODIFICACION,DFECHA_ULTIMAMODIFICACION,CMAQUINA_ULTIMAMODIFICACION,CUSUARIO_ELIMINACION,DFECHA_ELIMINACION,CMAQUINA_ELIMINACION"
        ' ''    prmPlaza.atrNombreTabla = "CTL_PLAZAS"

        ' ''    If Not prmPlaza.GuardarNuevo Then
        ' ''        Return False
        ' ''    End If
        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmTipoProducto As ClsTipoProducto) As Boolean

        ' ''    prmTipoProducto.atrNombreCampos = "nTipoProducto,cDescripcion,bActivo,CUSUARIO_REGISTRO,DFECHA_REGISTRO,CMAQUINA_REGISTRO,CUSUARIO_ULTIMAMODIFICACION,DFECHA_ULTIMAMODIFICACION,CMAQUINA_ULTIMAMODIFICACION,CUSUARIO_ELIMINACION,DFECHA_ELIMINACION,CMAQUINA_ELIMINACION"
        ' ''    prmTipoProducto.atrNombreTabla = "CTL_TiposProductos"

        ' ''    prmTipoProducto.ValidaSiEsAlmacenCorporativoProduccion = True
        ' ''    If Not prmTipoProducto.GuardarNuevo Then
        ' ''        Return False
        ' ''    End If
        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmVehiculo As ClsVehiculos) As Boolean

        ' ''    prmVehiculo.atrNombreCampos = "nVehiculo,cDescripcion,cPlacas,nTipoVehiculo,bActivo,CUSUARIO_REGISTRO,DFECHA_REGISTRO,CMAQUINA_REGISTRO,CUSUARIO_ULTIMAMODIFICACION,DFECHA_ULTIMAMODIFICACION,CMAQUINA_ULTIMAMODIFICACION,CUSUARIO_ELIMINACION,DFECHA_ELIMINACION,CMAQUINA_ELIMINACION"
        ' ''    prmVehiculo.atrNombreTabla = "CTL_Vehiculos"
        ' ''    prmVehiculo.ValidaSiEsAlmacenCorporativoProduccion = True
        ' ''    If Not prmVehiculo.GuardarNuevo Then
        ' ''        Return False
        ' ''    End If
        ' ''    Return True
        ' ''End Function



        ' ''Public Shared Function Guardar(ByVal prmTipoArticulo As ClsTipoArticulo) As Boolean

        ' ''    prmTipoArticulo.atrNombreCampos = "nTipoArticulo,cDescripcion,bActivo,CUSUARIO_REGISTRO,DFECHA_REGISTRO,CMAQUINA_REGISTRO,CUSUARIO_ULTIMAMODIFICACION,DFECHA_ULTIMAMODIFICACION,CMAQUINA_ULTIMAMODIFICACION,CUSUARIO_ELIMINACION,DFECHA_ELIMINACION,CMAQUINA_ELIMINACION"
        ' ''    prmTipoArticulo.atrNombreTabla = "CTL_TiposArticulos"

        ' ''    If Not prmTipoArticulo.GuardarNuevo Then
        ' ''        Return False
        ' ''    End If
        ' ''    Return True

        ' ''    'Dim ABRIO As Boolean
        ' ''    'If Not DAO.TieneTransaccionAbierta Then
        ' ''    '    ABRIO = True
        ' ''    '    DAO.AbreTransaccion()
        ' ''    'End If
        ' ''    'If Not prmTipoArticulo.GuardarBase Then
        ' ''    '    Return False
        ' ''    'End If



        ' ''    'prmTipoArticulo.atrSql = "SELECT nTipoArticulo,cDescripcion,bActivo," & vbCr
        ' ''    'prmTipoArticulo.atrSql &= "cUsuario_Registro,dFecha_Registro,cMaquina_Registro," & vbCr
        ' ''    'prmTipoArticulo.atrSql &= "cUsuario_UltimaModificacion,dFecha_UltimaModificacion,cMaquina_UltimaModificacion," & vbCr
        ' ''    'prmTipoArticulo.atrSql &= "cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion" & vbCr
        ' ''    'prmTipoArticulo.atrSql &= "FROM CTL_TiposArticulos(NOLOCK) " & vbCr
        ' ''    'prmTipoArticulo.atrSql &= "WHERE nTipoArticulo = " & prmTipoArticulo.Folio

        ' ''    'If Not prmTipoArticulo.setRowAccion Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'prmTipoArticulo.atrRow("nTipoArticulo") = prmTipoArticulo.Folio
        ' ''    'prmTipoArticulo.atrRow("cDescripcion") = prmTipoArticulo.Descripcion
        ' ''    'prmTipoArticulo.atrRow("bActivo") = prmTipoArticulo.Activo
        ' ''    'prmTipoArticulo.LLenaDatosRegistroComun(prmTipoArticulo.atrRow)

        ' ''    'If Not prmTipoArticulo.GuardarGenerico Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'If ABRIO Then
        ' ''    '    DAO.CierraTransaccion()
        ' ''    'End If

        ' ''    'Return True
        ' ''End Function

        Public Shared Function Guardar(ByVal prmTiposDatos As ClsTiposDatos) As Boolean

            prmTiposDatos.atrNombreCampos = "nTipoDato,cLlave,cValor,nValor"
            prmTiposDatos.atrNombreTabla = "ADSUM_TiposDatos"

            If Not prmTiposDatos.GuardarNuevo Then
                Return False
            End If
            Return True
        End Function

        Public Shared Function Guardar(ByVal prmTiposDatos As ClsClientes) As Boolean

            prmTiposDatos.atrNombreCampos = "nRFCEmisor,nCliente,cRFC,cRazonSocial,cCalle,cNumeroInterior,cNumeroExterior,cColonia,cLocalidad,cMunicipio,cEstado,cPais,cCodigoPostal,cCorreoElectronico,cMetodoPago,cCuentaBan"
            prmTiposDatos.atrNombreTabla = "FAC_RECEPTORES"

            If Not prmTiposDatos.GuardarNuevo Then
                Return False
            End If
            Return True
        End Function


        Public Shared Function Guardar(ByVal prmTiposDatos As ClsProducto) As Boolean

            prmTiposDatos.atrNombreCampos = "NCONCEPTO,CDESCRIPCION,NRFCEMISOR,NPRECIO,NIMPUESTO"
            prmTiposDatos.atrNombreTabla = "FAC_CONCEPTOS"

            If Not prmTiposDatos.GuardarNuevo Then
                Return False
            End If
            Return True
        End Function

        ' ''Public Shared Function Guardar(ByVal prmControl As ClsControlMuestrasCaptura) As Boolean

        ' ''    prmControl.atrNombreCampos = "nArticulo,nMarca,nPresentacion,dFechaRecepcion,dFechaCaducidad,nEstatus,BACTIVO,CUSUARIO_REGISTRO,DFECHA_REGISTRO,CMAQUINA_REGISTRO,CUSUARIO_ULTIMAMODIFICACION,DFECHA_ULTIMAMODIFICACION,CMAQUINA_ULTIMAMODIFICACION,CUSUARIO_ELIMINACION,DFECHA_ELIMINACION,CMAQUINA_ELIMINACION"
        ' ''    prmControl.atrNombreTabla = "CTL_ControlDeMuestras"

        ' ''    If Not prmControl.GuardarNuevo Then
        ' ''        Return False
        ' ''    End If
        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmControl As ClsControlDeMuestrasCapturaDetalles) As Boolean

        ' ''    prmControl.atrNombreCampos = "nIdDetalle,nArticulo,nMarca,nPresentacion,dFecha,cObservación,BACTIVO,CUSUARIO_REGISTRO,DFECHA_REGISTRO,CMAQUINA_REGISTRO,CUSUARIO_ULTIMAMODIFICACION,DFECHA_ULTIMAMODIFICACION,CMAQUINA_ULTIMAMODIFICACION,CUSUARIO_ELIMINACION,DFECHA_ELIMINACION,CMAQUINA_ELIMINACION"
        ' ''    prmControl.atrNombreTabla = "CTL_ControlMuestrasDetalles"

        ' ''    If Not prmControl.GuardarNuevo Then
        ' ''        Return False
        ' ''    End If
        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmLinea As ClsLineaProducto) As Boolean

        ' ''    prmLinea.atrNombreCampos = "nLinea,cDescripcion,cAbreviatura,bManejaNivelCOmponente,bManejaNivelProductoTerminado,bActivo,"
        ' ''    prmLinea.atrNombreCampos &= "CUSUARIO_REGISTRO,DFECHA_REGISTRO,CMAQUINA_REGISTRO,"
        ' ''    prmLinea.atrNombreCampos &= "CUSUARIO_ULTIMAMODIFICACION,DFECHA_ULTIMAMODIFICACION,CMAQUINA_ULTIMAMODIFICACION,"
        ' ''    prmLinea.atrNombreCampos &= "CUSUARIO_ELIMINACION,DFECHA_ELIMINACION,CMAQUINA_ELIMINACION"
        ' ''    prmLinea.atrNombreTabla = "CTL_LINEASPRODUCTOS"
        ' ''    prmLinea.ValidaSiEsAlmacenCorporativoProduccion = True
        ' ''    If Not prmLinea.GuardarNuevo Then
        ' ''        Return False
        ' ''    End If
        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmTipo As ClsTipoAlmacenConsumo) As Boolean

        ' ''    prmTipo.atrNombreCampos = "nTipoAlmacenConsumo,cDescripcion,bActivo,CUSUARIO_REGISTRO,DFECHA_REGISTRO,CMAQUINA_REGISTRO,CUSUARIO_ULTIMAMODIFICACION,DFECHA_ULTIMAMODIFICACION,CMAQUINA_ULTIMAMODIFICACION,CUSUARIO_ELIMINACION,DFECHA_ELIMINACION,CMAQUINA_ELIMINACION"
        ' ''    prmTipo.atrNombreTabla = "CTL_TiposAlmacenConsumo"

        ' ''    If Not prmTipo.GuardarNuevo Then
        ' ''        Return False
        ' ''    End If
        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmCodigoProduccion As ClsCodigoProduccion) As Boolean
        ' ''    prmCodigoProduccion.atrNombreCampos = "nCodigo,cDescripcion,bActivo,CUSUARIO_REGISTRO,DFECHA_REGISTRO,CMAQUINA_REGISTRO,CUSUARIO_ULTIMAMODIFICACION,DFECHA_ULTIMAMODIFICACION,CMAQUINA_ULTIMAMODIFICACION,CUSUARIO_ELIMINACION,DFECHA_ELIMINACION,CMAQUINA_ELIMINACION"
        ' ''    prmCodigoProduccion.atrNombreTabla = "CTL_CodigosProduccion"

        ' ''    If Not prmCodigoProduccion.GuardarNuevo Then
        ' ''        Return False
        ' ''    End If
        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmLinea As ClsLinea) As Boolean

        ' ''    prmLinea.atrNombreCampos = "NLINEA,CDESCRIPCION,CABREVIATURA,nTipoArticulo,NTIPOLINEA,NCUENTA1,NCUENTA2,NORDEN,nFlujo1,nFlujo2,nFlujo3,BACTIVO,bLineaDeActivos,CUSUARIO_REGISTRO,DFECHA_REGISTRO,CMAQUINA_REGISTRO,CUSUARIO_ULTIMAMODIFICACION,DFECHA_ULTIMAMODIFICACION,CMAQUINA_ULTIMAMODIFICACION,CUSUARIO_ELIMINACION,DFECHA_ELIMINACION,CMAQUINA_ELIMINACION"
        ' ''    prmLinea.atrNombreTabla = "CTL_LINEAS"

        ' ''    If Not prmLinea.GuardarNuevo Then
        ' ''        Return False
        ' ''    End If
        ' ''    Return True

        ' ''    'If Not prmLinea.GuardarBase Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'prmLinea.atrSql = "SELECT NLINEA,CDESCRIPCION,CTIPOLINEA,CCUENTA1,CCUENTA2,BACTIVO,"
        ' ''    'prmLinea.atrSql &= "CUSUARIO_REGISTRO,DFECHA_REGISTRO,CMAQUINA_REGISTRO,"
        ' ''    'prmLinea.atrSql &= "CUSUARIO_ULTIMAMODIFICACION,DFECHA_ULTIMAMODIFICACION,CMAQUINA_ULTIMAMODIFICACION,"
        ' ''    'prmLinea.atrSql &= "CUSUARIO_ELIMINACION,DFECHA_ELIMINACION,CMAQUINA_ELIMINACION FROM CTL_LINEAS(NOLOCK) "
        ' ''    'prmLinea.atrSql &= "WHERE NLINEA = " & prmLinea.Folio

        ' ''    'If Not prmLinea.setRowAccion Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'prmLinea.atrRow("NLINEA") = prmLinea.Folio
        ' ''    'prmLinea.atrRow("CDESCRIPCION") = prmLinea.Descripcion
        ' ''    'prmLinea.atrRow("CTIPOLINEA") = prmLinea.TipoLinea
        ' ''    'prmLinea.atrRow("CCUENTA1") = prmLinea.Cuenta1
        ' ''    'prmLinea.atrRow("CCUENTA2") = prmLinea.Cuenta2
        ' ''    'prmLinea.atrRow("BACTIVO") = prmLinea.Activo
        ' ''    'prmLinea.LLenaDatosRegistroComun(prmLinea.atrRow)

        ' ''    'If Not prmLinea.GuardarGenerico Then
        ' ''    '    Return False
        ' ''    'End If


        ' ''End Function


        ' ''Public Shared Function Guardar(ByVal prmUnidad As ClsUnidad) As Boolean
        ' ''    prmUnidad.atrNombreCampos = "NUNIDAD,CDESCRIPCION,CABREVIATURA,ntipoUnidad,BACTIVO,CUSUARIO_REGISTRO,DFECHA_REGISTRO,CMAQUINA_REGISTRO,CUSUARIO_ULTIMAMODIFICACION,DFECHA_ULTIMAMODIFICACION,CMAQUINA_ULTIMAMODIFICACION,CUSUARIO_ELIMINACION,DFECHA_ELIMINACION,CMAQUINA_ELIMINACION"
        ' ''    prmUnidad.atrNombreTabla = "CTL_UNIDADES"

        ' ''    If Not prmUnidad.GuardarNuevo Then
        ' ''        Return False
        ' ''    End If
        ' ''    'Dim ABRIO As Boolean
        ' ''    'If Not DAO.TieneTransaccionAbierta Then
        ' ''    '    ABRIO = True
        ' ''    '    DAO.AbreTransaccion()
        ' ''    'End If
        ' ''    'If Not prmUnidad.GuardarBase Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'prmUnidad.atrSql = "SELECT NUNIDAD,CDESCRIPCION,CABREVIATURA,ntipoUnidad,BACTIVO,"
        ' ''    'prmUnidad.atrSql &= "CUSUARIO_REGISTRO,DFECHA_REGISTRO,CMAQUINA_REGISTRO,"
        ' ''    'prmUnidad.atrSql &= "CUSUARIO_ULTIMAMODIFICACION,DFECHA_ULTIMAMODIFICACION,CMAQUINA_ULTIMAMODIFICACION,"
        ' ''    'prmUnidad.atrSql &= "CUSUARIO_ELIMINACION,DFECHA_ELIMINACION,CMAQUINA_ELIMINACION FROM CTL_UNIDADES(NOLOCK) "
        ' ''    'prmUnidad.atrSql &= "WHERE NUNIDAD = " & prmUnidad.Folio

        ' ''    'If Not prmUnidad.setRowAccion Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'prmUnidad.atrRow("NUNIDAD") = prmUnidad.Folio
        ' ''    'prmUnidad.atrRow("CDESCRIPCION") = prmUnidad.Descripcion
        ' ''    'prmUnidad.atrRow("CABREVIATURA") = prmUnidad.Abreviatura
        ' ''    'prmUnidad.atrRow("ntipoUnidad") = prmUnidad.TipoUnidad
        ' ''    'prmUnidad.atrRow("BACTIVO") = prmUnidad.Activo
        ' ''    'prmUnidad.LLenaDatosRegistroComun(prmUnidad.atrRow)

        ' ''    'If Not prmUnidad.GuardarGenerico Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'If ABRIO Then
        ' ''    '    DAO.CierraTransaccion()
        ' ''    'End If

        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmImpuesto As ClsImpuesto) As Boolean
        ' ''    prmImpuesto.atrNombreCampos = "NIMPUESTOS,CDESCRIPCION,BIVA,BFRONTERA,NPORCENTAJE,nIdentificadorContable,BACTIVO,CUSUARIO_REGISTRO,DFECHA_REGISTRO,CMAQUINA_REGISTRO,CUSUARIO_ULTIMAMODIFICACION,DFECHA_ULTIMAMODIFICACION,CMAQUINA_ULTIMAMODIFICACION,CUSUARIO_ELIMINACION,DFECHA_ELIMINACION,CMAQUINA_ELIMINACION"
        ' ''    prmImpuesto.atrNombreTabla = "CTL_IMPUESTOS"

        ' ''    If Not prmImpuesto.GuardarNuevo Then
        ' ''        Return False
        ' ''    End If
        ' ''    'Dim ABRIO As Boolean
        ' ''    'If Not DAO.TieneTransaccionAbierta Then
        ' ''    '    ABRIO = True
        ' ''    '    DAO.AbreTransaccion()
        ' ''    'End If
        ' ''    'If Not prmImpuesto.GuardarBase Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'prmImpuesto.atrSql = "SELECT NIMPUESTOS,CDESCRIPCION,BIVA,BFRONTERA,NPORCENTAJE,BACTIVO,"
        ' ''    'prmImpuesto.atrSql &= "CUSUARIO_REGISTRO,DFECHA_REGISTRO,CMAQUINA_REGISTRO,"
        ' ''    'prmImpuesto.atrSql &= "CUSUARIO_ULTIMAMODIFICACION,DFECHA_ULTIMAMODIFICACION,CMAQUINA_ULTIMAMODIFICACION,"
        ' ''    'prmImpuesto.atrSql &= "CUSUARIO_ELIMINACION,DFECHA_ELIMINACION,CMAQUINA_ELIMINACION FROM CTL_IMPUESTOS(NOLOCK) "
        ' ''    'prmImpuesto.atrSql &= "WHERE NIMPUESTOS = " & prmImpuesto.Folio

        ' ''    'If Not prmImpuesto.setRowAccion Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'prmImpuesto.atrRow("NIMPUESTOS") = prmImpuesto.Folio
        ' ''    'prmImpuesto.atrRow("CDESCRIPCION") = prmImpuesto.Descripcion
        ' ''    'prmImpuesto.atrRow("NPORCENTAJE") = prmImpuesto.Porcentaje
        ' ''    'prmImpuesto.atrRow("BIVA") = prmImpuesto.IVA
        ' ''    'prmImpuesto.atrRow("BFRONTERA") = prmImpuesto.Frontera
        ' ''    'prmImpuesto.atrRow("BACTIVO") = prmImpuesto.Activo
        ' ''    'prmImpuesto.LLenaDatosRegistroComun(prmImpuesto.atrRow)

        ' ''    'If Not prmImpuesto.GuardarGenerico Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'If ABRIO Then
        ' ''    '    DAO.CierraTransaccion()
        ' ''    'End If

        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmMarca As ClsMarca) As Boolean
        ' ''    prmMarca.atrNombreCampos = "NMARCA,CDESCRIPCION,BACTIVO,CUSUARIO_REGISTRO,DFECHA_REGISTRO,CMAQUINA_REGISTRO,CUSUARIO_ULTIMAMODIFICACION,DFECHA_ULTIMAMODIFICACION,CMAQUINA_ULTIMAMODIFICACION,CUSUARIO_ELIMINACION,DFECHA_ELIMINACION,CMAQUINA_ELIMINACION"
        ' ''    prmMarca.atrNombreTabla = "CTL_MARCAS"

        ' ''    If Not prmMarca.GuardarNuevo Then
        ' ''        Return False
        ' ''    End If
        ' ''    'Dim ABRIO As Boolean
        ' ''    'If Not DAO.TieneTransaccionAbierta Then
        ' ''    '    ABRIO = True
        ' ''    '    DAO.AbreTransaccion()
        ' ''    'End If
        ' ''    'If Not prmMarca.GuardarBase Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'prmMarca.atrSql = "SELECT NMARCA,CDESCRIPCION,BACTIVO,"
        ' ''    'prmMarca.atrSql &= "CUSUARIO_REGISTRO,DFECHA_REGISTRO,CMAQUINA_REGISTRO,"
        ' ''    'prmMarca.atrSql &= "CUSUARIO_ULTIMAMODIFICACION,DFECHA_ULTIMAMODIFICACION,CMAQUINA_ULTIMAMODIFICACION,"
        ' ''    'prmMarca.atrSql &= "CUSUARIO_ELIMINACION,DFECHA_ELIMINACION,CMAQUINA_ELIMINACION FROM CTL_MARCAS(NOLOCK) "
        ' ''    'prmMarca.atrSql &= "WHERE NMARCA = " & prmMarca.Folio

        ' ''    'If Not prmMarca.setRowAccion Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'prmMarca.atrRow("NMARCA") = prmMarca.Folio
        ' ''    'prmMarca.atrRow("CDESCRIPCION") = prmMarca.Descripcion
        ' ''    'prmMarca.atrRow("BACTIVO") = prmMarca.Activo
        ' ''    'prmMarca.LLenaDatosRegistroComun(prmMarca.atrRow)

        ' ''    'If Not prmMarca.GuardarGenerico Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'If ABRIO Then
        ' ''    '    DAO.CierraTransaccion()
        ' ''    'End If

        ' ''    Return True
        ' ''End Function

        ' ''Private Shared Function ActualizaDescripcionPresentacion_CTL_ArticulosPresentaciones(ByVal prmPresentacion As Catalogos.ClsPresentaciones) As Boolean
        ' ''    If prmPresentacion Is Nothing Then Return False
        ' ''    Dim vSQLTEXT As String = "UPDATE AP"

        ' ''    vSQLTEXT &= " SET AP.cDescripcion = P.cDescripcion + ' ' + cast(AP.nEquivalencia as varchar) " & vbCr
        ' ''    vSQLTEXT &= " FROM CTL_ArticulosPresentaciones AP (NOLOCK) " & vbCr
        ' ''    vSQLTEXT &= " INNER JOIN CTL_Presentaciones P (NOLOCK) " & vbCr
        ' ''    vSQLTEXT &= " ON AP.nPresentacionCatalogo = P.nPresentacion " & vbCr
        ' ''    vSQLTEXT &= " WHERE AP.nPresentacionCatalogo = " & prmPresentacion.Folio
        ' ''    Return DAO.EjecutaComandoSQL(vSQLTEXT)
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmPresentacion As ClsPresentaciones) As Boolean
        ' ''    prmPresentacion.atrNombreCampos = "NPRESENTACION,CDESCRIPCION,BACTIVO,CUSUARIO_REGISTRO,DFECHA_REGISTRO,CMAQUINA_REGISTRO,CUSUARIO_ULTIMAMODIFICACION,DFECHA_ULTIMAMODIFICACION,CMAQUINA_ULTIMAMODIFICACION,CUSUARIO_ELIMINACION,DFECHA_ELIMINACION,CMAQUINA_ELIMINACION"
        ' ''    prmPresentacion.atrNombreTabla = "CTL_Presentaciones"

        ' ''    If Not prmPresentacion.GuardarNuevo Then
        ' ''        Return False
        ' ''    End If
        ' ''    If Not ActualizaDescripcionPresentacion_CTL_ArticulosPresentaciones(prmPresentacion) Then
        ' ''        Return False
        ' ''    End If

        ' ''    Return True
        ' ''End Function


        ' ''Public Shared Function Guardar(ByVal prmMovimientos As ClsMovimiento) As Boolean
        ' ''    Dim ABRIO As Boolean
        ' ''    If Not DAO.TieneTransaccionAbierta Then
        ' ''        ABRIO = True
        ' ''        DAO.AbreTransaccion()
        ' ''    End If
        ' ''    If Not prmMovimientos.GuardarBase Then
        ' ''        Return False
        ' ''    End If

        ' ''    prmMovimientos.atrSql = "SELECT NMOVIMIENTO,CDESCRIPCION,NTIPOMOVIMIENTO,BACTIVO,"
        ' ''    prmMovimientos.atrSql &= "CUSUARIO_REGISTRO,DFECHA_REGISTRO,CMAQUINA_REGISTRO,"
        ' ''    prmMovimientos.atrSql &= "CUSUARIO_ULTIMAMODIFICACION,DFECHA_ULTIMAMODIFICACION,CMAQUINA_ULTIMAMODIFICACION,"
        ' ''    prmMovimientos.atrSql &= "CUSUARIO_ELIMINACION,DFECHA_ELIMINACION,CMAQUINA_ELIMINACION FROM CTL_MOVIMIENTOS(NOLOCK) "
        ' ''    prmMovimientos.atrSql &= "WHERE NMOVIMIENTO = " & prmMovimientos.Folio

        ' ''    If Not prmMovimientos.setRowAccion Then
        ' ''        Return False
        ' ''    End If

        ' ''    prmMovimientos.atrRow("NMOVIMIENTO") = prmMovimientos.Folio
        ' ''    prmMovimientos.atrRow("CDESCRIPCION") = prmMovimientos.Descripcion
        ' ''    prmMovimientos.atrRow("NTIPOMOVIMIENTO") = prmMovimientos.TipoMovimiento
        ' ''    prmMovimientos.atrRow("BACTIVO") = prmMovimientos.Activo
        ' ''    prmMovimientos.LLenaDatosRegistroComun(prmMovimientos.atrRow)

        ' ''    If Not prmMovimientos.GuardarGenerico Then
        ' ''        Return False
        ' ''    End If

        ' ''    If ABRIO Then
        ' ''        DAO.CierraTransaccion()
        ' ''    End If

        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmPaqueteria As ClsPaqueteria) As Boolean
        ' ''    prmPaqueteria.atrNombreCampos = "NPAQUETERIA,CDESCRIPCION,BACTIVO,CUSUARIO_REGISTRO,DFECHA_REGISTRO,CMAQUINA_REGISTRO,CUSUARIO_ULTIMAMODIFICACION,DFECHA_ULTIMAMODIFICACION,CMAQUINA_ULTIMAMODIFICACION,CUSUARIO_ELIMINACION,DFECHA_ELIMINACION,CMAQUINA_ELIMINACION"
        ' ''    prmPaqueteria.atrNombreTabla = "CTL_PAQUETERIAS"

        ' ''    If Not prmPaqueteria.GuardarNuevo Then
        ' ''        Return False
        ' ''    End If
        ' ''    'Dim ABRIO As Boolean
        ' ''    'If Not DAO.TieneTransaccionAbierta Then
        ' ''    '    ABRIO = True
        ' ''    '    DAO.AbreTransaccion()
        ' ''    'End If
        ' ''    'If Not prmPaqueteria.GuardarBase Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'prmPaqueteria.atrSql = "SELECT NPAQUETERIA,CDESCRIPCION,BACTIVO,"
        ' ''    'prmPaqueteria.atrSql &= "CUSUARIO_REGISTRO,DFECHA_REGISTRO,CMAQUINA_REGISTRO,"
        ' ''    'prmPaqueteria.atrSql &= "CUSUARIO_ULTIMAMODIFICACION,DFECHA_ULTIMAMODIFICACION,CMAQUINA_ULTIMAMODIFICACION,"
        ' ''    'prmPaqueteria.atrSql &= "CUSUARIO_ELIMINACION,DFECHA_ELIMINACION,CMAQUINA_ELIMINACION FROM CTL_PAQUETERIAS(NOLOCK) "
        ' ''    'prmPaqueteria.atrSql &= "WHERE NPAQUETERIA = " & prmPaqueteria.Folio

        ' ''    'If Not prmPaqueteria.setRowAccion Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'prmPaqueteria.atrRow("NPAQUETERIA") = prmPaqueteria.Folio
        ' ''    'prmPaqueteria.atrRow("CDESCRIPCION") = prmPaqueteria.Descripcion
        ' ''    'prmPaqueteria.atrRow("BACTIVO") = prmPaqueteria.Activo
        ' ''    'prmPaqueteria.LLenaDatosRegistroComun(prmPaqueteria.atrRow)

        ' ''    'If Not prmPaqueteria.GuardarGenerico Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'If ABRIO Then
        ' ''    '    DAO.CierraTransaccion()
        ' ''    'End If

        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmSucursal As ClsSucursal) As Boolean
        ' ''    prmSucursal.atrNombreCampos = "nSucursal,cDescripcion,nPlaza,cAbreviatura,nOrdenListado,CDireccion,cPais,nColonia,nTipoSucursal,bManejaAlmacen,cTelefono1,BACTIVO,CUSUARIO_REGISTRO,DFECHA_REGISTRO,CMAQUINA_REGISTRO,CUSUARIO_ULTIMAMODIFICACION,DFECHA_ULTIMAMODIFICACION,CMAQUINA_ULTIMAMODIFICACION,CUSUARIO_ELIMINACION,DFECHA_ELIMINACION,CMAQUINA_ELIMINACION,"
        ' ''    prmSucursal.atrNombreCampos &= "cTelefono2,cICQ,cSKYPE,cCuenta1,cCuenta2,cCuenta3,cCuenta4,nSupervisor1,nSupervisor2,cNotas,nCuentaCnt"
        ' ''    prmSucursal.atrNombreTabla = "CTL_SUCURSALES"

        ' ''    If DAO.RegresaDatoSQL("select nordenlistado from CTL_SUCURSALES where nordenlistado=" & prmSucursal.OrdenListado & " and nsucursal <>" & prmSucursal.Folio) = prmSucursal.OrdenListado Then
        ' ''        If Not DAO.EjecutaComandoSQL("update  CTL_SUCURSALES set nordenlistado=nordenlistado+1 where nsucursal<>" & prmSucursal.Folio & " and nordenlistado>=" & prmSucursal.OrdenListado) Then
        ' ''            If DAO.TieneTransaccionAbierta Then
        ' ''                DAO.DeshaceTransaccion()
        ' ''            End If
        ' ''            Return False
        ' ''        End If
        ' ''    End If

        ' ''    If Not prmSucursal.GuardarNuevo Then
        ' ''        If DAO.TieneTransaccionAbierta Then
        ' ''            DAO.DeshaceTransaccion()
        ' ''        End If
        ' ''        Return False
        ' ''    End If

        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmAlmacen As ClsAlmacen) As Boolean
        ' ''    'Dim ABRIO As Boolean
        ' ''    'If Not DAO.TieneTransaccionAbierta Then
        ' ''    '    ABRIO = True
        ' ''    '    DAO.AbreTransaccion()
        ' ''    'End If
        ' ''    'If Not prmAlmacen.GuardarBase Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    prmAlmacen.atrNombreCampos = "NALMACEN,CABREVIATURA,CDESCRIPCION,NTIPOALMACEN,BESCORPORATIVO,BMANEJADIRECCION,"
        ' ''    prmAlmacen.atrNombreCampos &= "bMantenimientoEnCurso, BPROGRAMAPRODUCCION, NPLAZA, NSUCURSAL, CDIRECCION,"
        ' ''    prmAlmacen.atrNombreCampos &= "NCOLONIA, CPAIS, CCUENTA, NINVOLUCRADO, NRESPONSABLE, NALMACENVINCULADO,"
        ' ''    prmAlmacen.atrNombreCampos &= "BACTIVO, NALMACENCONTROLADOR, nCuentaCnt, bEsCorporativoProduccion, "
        ' ''    prmAlmacen.atrNombreCampos &= "CUSUARIO_REGISTRO,DFECHA_REGISTRO,CMAQUINA_REGISTRO,"
        ' ''    prmAlmacen.atrNombreCampos &= "CUSUARIO_ULTIMAMODIFICACION,DFECHA_ULTIMAMODIFICACION,CMAQUINA_ULTIMAMODIFICACION,"
        ' ''    prmAlmacen.atrNombreCampos &= "CUSUARIO_ELIMINACION,DFECHA_ELIMINACION,CMAQUINA_ELIMINACION,BESPECIALES,NORDENLISTADO"
        ' ''    prmAlmacen.atrNombreTabla = "CTL_ALMACENES"

        ' ''    If DAO.RegresaDatoSQL("select nordenlistado from CTL_Almacenes  where nordenlistado=" & prmAlmacen.OrdenListado & " and nsucursal <>" & prmAlmacen.Folio) = prmAlmacen.OrdenListado Then
        ' ''        If Not DAO.EjecutaComandoSQL("update  CTL_Almacenes set nordenlistado=nordenlistado+1 where nAlmacen<>" & prmAlmacen.Folio & " and nordenlistado>=" & prmAlmacen.OrdenListado) Then
        ' ''            If DAO.TieneTransaccionAbierta Then
        ' ''                DAO.DeshaceTransaccion()
        ' ''            End If
        ' ''            Return False
        ' ''        End If
        ' ''    End If

        ' ''    If Not prmAlmacen.GuardarNuevo Then
        ' ''        Return False
        ' ''    End If

        ' ''    'If Not prmAlmacen.setRowAccion Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'prmAlmacen.atrRow("NALMACEN") = prmAlmacen.Folio
        ' ''    'prmAlmacen.atrRow("CDESCRIPCION") = prmAlmacen.Descripcion
        ' ''    'prmAlmacen.atrRow("BPRINCIPAL") = prmAlmacen.Principal
        ' ''    'prmAlmacen.atrRow("BMANEJADIRECCION") = prmAlmacen.ManejaUbicacion
        ' ''    'prmAlmacen.atrRow("NPLAZA") = prmAlmacen.Plaza
        ' ''    'prmAlmacen.atrRow("NSUCURSAL") = prmAlmacen.Sucursal
        ' ''    'prmAlmacen.atrRow("CDIRECCION") = prmAlmacen.Direccion
        ' ''    'prmAlmacen.atrRow("CCODIGOPOSTAL") = prmAlmacen.CodigoPostal
        ' ''    'prmAlmacen.atrRow("CCIUDAD") = prmAlmacen.Ciudad
        ' ''    'prmAlmacen.atrRow("NESTADO") = prmAlmacen.Estado
        ' ''    'prmAlmacen.atrRow("CPAIS") = prmAlmacen.Pais
        ' ''    'prmAlmacen.atrRow("CCUENTA") = prmAlmacen.Cuenta
        ' ''    'prmAlmacen.atrRow("CRESPONSABLE") = prmAlmacen.Responsable
        ' ''    'prmAlmacen.atrRow("BACTIVO") = prmAlmacen.Activo
        ' ''    'prmAlmacen.LLenaDatosRegistroComun(prmAlmacen.atrRow)

        ' ''    'If Not prmAlmacen.GuardarGenerico Then
        ' ''    '    Return False
        ' ''    'End If

        ' ''    'If ABRIO Then
        ' ''    '    DAO.CierraTransaccion()
        ' ''    'End If

        ' ''    Return True
        ' ''End Function

        Public Shared Function Guardar(ByVal prmMoneda As ClsMoneda) As Boolean
            prmMoneda.atrNombreCampos = "NMONEDA,CDESCRIPCION,CSIGNO,BBASE,BACTIVO,CUSUARIO_REGISTRO,DFECHA_REGISTRO,CMAQUINA_REGISTRO,CUSUARIO_ULTIMAMODIFICACION,DFECHA_ULTIMAMODIFICACION,CMAQUINA_ULTIMAMODIFICACION,CUSUARIO_ELIMINACION,DFECHA_ELIMINACION,CMAQUINA_ELIMINACION"
            prmMoneda.atrNombreTabla = "CTL_MONEDAS"

            If Not prmMoneda.GuardarNuevo Then
                Return False
            End If
            'Dim ABRIO As Boolean
            'If Not DAO.TieneTransaccionAbierta Then
            '    ABRIO = True
            '    DAO.AbreTransaccion()
            'End If
            'If Not prmMoneda.GuardarBase Then
            '    Return False
            'End If

            'prmMoneda.atrSql = "SELECT NMONEDA,CDESCRIPCION,CSIGNO,BBASE,BACTIVO,"
            'prmMoneda.atrSql &= "CUSUARIO_REGISTRO,DFECHA_REGISTRO,CMAQUINA_REGISTRO,"
            'prmMoneda.atrSql &= "CUSUARIO_ULTIMAMODIFICACION,DFECHA_ULTIMAMODIFICACION,CMAQUINA_ULTIMAMODIFICACION,"
            'prmMoneda.atrSql &= "CUSUARIO_ELIMINACION,DFECHA_ELIMINACION,CMAQUINA_ELIMINACION FROM CTL_MONEDAS(NOLOCK) "
            'prmMoneda.atrSql &= "WHERE NMONEDA = " & prmMoneda.Folio

            'If Not prmMoneda.setRowAccion Then
            '    Return False
            'End If

            'prmMoneda.atrRow("NMONEDA") = prmMoneda.Folio
            'prmMoneda.atrRow("CDESCRIPCION") = prmMoneda.Descripcion
            'prmMoneda.atrRow("CSIGNO") = prmMoneda.Signo
            'prmMoneda.atrRow("BBASE") = prmMoneda.MonedaBase
            'prmMoneda.atrRow("BACTIVO") = prmMoneda.Activo
            'prmMoneda.LLenaDatosRegistroComun(prmMoneda.atrRow)

            'If Not prmMoneda.GuardarGenerico Then
            '    Return False
            'End If

            'If ABRIO Then
            '    DAO.CierraTransaccion()
            'End If

            Return True
        End Function

        ' ''Public Shared Function Guardar(ByVal prmFlujo As ClsFlujoEfectivo) As Boolean
        ' ''    prmFlujo.atrNombreCampos = "nFlujo,cNivel,nFlujoPadre,cDescripcion,cTipoFlujo,bAceptaMovimientos,bActivo,"
        ' ''    prmFlujo.atrNombreCampos &= "cUsuario_Registro,dFecha_Registro,cMaquina_Registro,cUsuario_UltimaModificacion,dFecha_UltimaModificacion,"
        ' ''    prmFlujo.atrNombreCampos &= "cMaquina_UltimaModificacion,cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion"
        ' ''    prmFlujo.atrNombreTabla = "CTL_FlujosEfectivo"

        ' ''    If Not prmFlujo.GuardarNuevo Then
        ' ''        Return False
        ' ''    End If
        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmCuentaBancaria As ClsCuentaBancaria) As Boolean
        ' ''    prmCuentaBancaria.atrNombreCampos = "nBanco,nCuentaBancaria,cNumCuenta,cDescripcion,nMoneda,nSucursal,"
        ' ''    prmCuentaBancaria.atrNombreCampos &= "nImpresora,nGrupoCuentaBancaria,cDocumento,bParaTransferencia,"
        ' ''    prmCuentaBancaria.atrNombreCampos &= "cEmailBanco,bActivo,nConsecutivo,nCuentaCnt,nCuentaCntComplementaria,"
        ' ''    prmCuentaBancaria.atrNombreCampos &= "cContacto,cTelefonoOficinaContacto,cTelefonoCelularContacto,bCapturaFlujos,bConciliaIntegracion,"
        ' ''    prmCuentaBancaria.atrNombreCampos &= "cUsuario_Registro, dFecha_Registro, cMaquina_Registro, cUsuario_UltimaModificacion,"
        ' ''    prmCuentaBancaria.atrNombreCampos &= "dFecha_UltimaModificacion,cMaquina_UltimaModificacion,cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion"
        ' ''    prmCuentaBancaria.atrNombreTabla = "CTL_CuentasBancarias"

        ' ''    If Not prmCuentaBancaria.GuardarNuevo Then
        ' ''        Return False
        ' ''    End If
        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmBeneficiario As ClsBeneficiario) As Boolean
        ' ''    prmBeneficiario.atrNombreCampos = "nBeneficiario,cDescripcion,bActivo,cUsuario_Registro,dFecha_Registro,cMaquina_Registro,"
        ' ''    prmBeneficiario.atrNombreCampos &= "cUsuario_UltimaModificacion,dFecha_UltimaModificacion,cMaquina_UltimaModificacion,"
        ' ''    prmBeneficiario.atrNombreCampos &= "cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion"
        ' ''    prmBeneficiario.atrNombreTabla = "CTL_Beneficiarios"

        ' ''    If Not prmBeneficiario.GuardarNuevo Then
        ' ''        Return False
        ' ''    End If
        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmSolicitante As ClsSolicitante) As Boolean
        ' ''    prmSolicitante.atrNombreCampos = "nSolicitante,cDescripcion,bActivo,cUsuario_Registro,dFecha_Registro,cMaquina_Registro,"
        ' ''    prmSolicitante.atrNombreCampos &= "cUsuario_UltimaModificacion,dFecha_UltimaModificacion,cMaquina_UltimaModificacion,"
        ' ''    prmSolicitante.atrNombreCampos &= "cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion"
        ' ''    prmSolicitante.atrNombreTabla = "CTL_Solicitantes"

        ' ''    If Not prmSolicitante.GuardarNuevo Then
        ' ''        Return False
        ' ''    End If
        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmProyecto As ClsProyecto) As Boolean
        ' ''    prmProyecto.atrNombreCampos = "nProyecto,nPlaza,cDescripcion,nPresupuesto,bConVigencia,dFechaInicial,dFechaFinal,cEncargado,"
        ' ''    prmProyecto.atrNombreCampos &= "nNivel1,nNivel2,bActivo,cUsuario_Registro,dFecha_Registro,dFechaAplicacion,cMaquina_Registro,cUsuario_UltimaModificacion,"
        ' ''    prmProyecto.atrNombreCampos &= "dFecha_UltimaModificacion,cMaquina_UltimaModificacion,cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion"
        ' ''    prmProyecto.atrNombreTabla = "CTL_Proyectos"

        ' ''    If Not prmProyecto.GuardarNuevo Then
        ' ''        Return False
        ' ''    End If
        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmProyecto As ClsConceptosCxp) As Boolean
        ' ''    prmProyecto.atrNombreCampos = "nTipoMovimiento,cDescripcion,cTipo,bEspecial,cAbreviatura,bActivo,cUsuario_Registro,"
        ' ''    prmProyecto.atrNombreCampos &= "dFecha_Registro,cMaquina_Registro,cUsuario_UltimaModificacion,dFecha_UltimaModificacion,"
        ' ''    prmProyecto.atrNombreCampos &= "cMaquina_UltimaModificacion,cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion"
        ' ''    prmProyecto.atrNombreTabla = "CXP_TiposMovimientos"

        ' ''    If Not prmProyecto.GuardarNuevo Then
        ' ''        Return False
        ' ''    End If
        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmProyecto As ClsConceptosCheque) As Boolean
        ' ''    prmProyecto.atrNombreCampos = "nConceptoCheque,cDescripcion,bActivo,cAbreviatura,bEspecial,"
        ' ''    prmProyecto.atrNombreCampos &= "cUsuario_Registro,dFecha_Registro,cMaquina_Registro,cUsuario_UltimaModificacion,"
        ' ''    prmProyecto.atrNombreCampos &= "dFecha_UltimaModificacion,cMaquina_UltimaModificacion,"
        ' ''    prmProyecto.atrNombreCampos &= "cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion"
        ' ''    prmProyecto.atrNombreTabla = "CTL_ConceptosCheques"

        ' ''    If Not prmProyecto.GuardarNuevo Then
        ' ''        Return False
        ' ''    End If
        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmProyecto As ClsConceptoFlujo) As Boolean
        ' ''    prmProyecto.atrNombreCampos = "nConceptoFlujo,cDescripcion,nEfecto,bActivo,cUsuario_Registro,"
        ' ''    prmProyecto.atrNombreCampos &= "dFecha_Registro,cMaquina_Registro,cUsuario_UltimaModificacion,dFecha_UltimaModificacion,"
        ' ''    prmProyecto.atrNombreCampos &= "cMaquina_UltimaModificacion,cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion"
        ' ''    prmProyecto.atrNombreTabla = "CTL_ConceptosFlujos"

        ' ''    'prmComprasGastos.GuardarNuevo( False, "",  True)
        ' ''    'If Not prmProyecto.GuardarNuevo(False, "", False, False) Then
        ' ''    '    Return False
        ' ''    'End If
        ' ''    If Not prmProyecto.GuardarNuevo Then
        ' ''        Return False
        ' ''    End If
        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmTipoPoliza As ClsTiposPoliza) As Boolean
        ' ''    prmTipoPoliza.atrNombreCampos = "nTipoPoliza,cDescripcion,bConImporte,bConReferencia,bConBeneficiario,bPermitePolizasDescuadradas,"
        ' ''    prmTipoPoliza.atrNombreCampos &= "bValidarReferencias,bEsPolizaSaldosInciales,cIdentificadorContpaq,bActivo,nConfiguracion,cAbreviatura,cUsuario_Registro,dFecha_Registro,cMaquina_Registro,cUsuario_UltimaModificacion,"
        ' ''    prmTipoPoliza.atrNombreCampos &= "dFecha_UltimaModificacion,cMaquina_UltimaModificacion,cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion"
        ' ''    prmTipoPoliza.atrNombreTabla = "CTL_TiposPolizas"

        ' ''    If Not prmTipoPoliza.GuardarNuevo Then
        ' ''        Return False
        ' ''    End If
        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmGrupoCuentaBancarias As ClsGrupoCuentaBancaria) As Boolean
        ' ''    prmGrupoCuentaBancarias.atrNombreCampos = "nGrupoCuentaBancaria,cDescripcion,bActivo,cUsuario_Registro,dFecha_Registro,"
        ' ''    prmGrupoCuentaBancarias.atrNombreCampos &= "cMaquina_Registro,cUsuario_UltimaModificacion,dFecha_UltimaModificacion,"
        ' ''    prmGrupoCuentaBancarias.atrNombreCampos &= "cMaquina_UltimaModificacion,cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion"
        ' ''    prmGrupoCuentaBancarias.atrNombreTabla = "CTL_GruposCuentasBancarias"

        ' ''    If Not prmGrupoCuentaBancarias.GuardarNuevo Then
        ' ''        Return False
        ' ''    End If
        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmMovimientoBancario As ClsMovimientoBancario) As Boolean
        ' ''    prmMovimientoBancario.atrNombreCampos = "nTipoMovimiento,nEfecto,cDescripcion,nTipoPoliza,bAfectaLibro,bSujetoaConciliacion,"
        ' ''    prmMovimientoBancario.atrNombreCampos &= "bGeneraPolizaEnLinea,bNoseContabiliza,bActivo,nTipoRegistro,cUsuario_Registro,dFecha_Registro,"
        ' ''    prmMovimientoBancario.atrNombreCampos &= "cMaquina_Registro,cUsuario_UltimaModificacion,dFecha_UltimaModificacion,"
        ' ''    prmMovimientoBancario.atrNombreCampos &= "cMaquina_UltimaModificacion,cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion"
        ' ''    prmMovimientoBancario.atrNombreTabla = "BAN_TiposMovimientos"

        ' ''    If Not prmMovimientoBancario.GuardarNuevo Then
        ' ''        Return False
        ' ''    End If
        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmGrupoProveedores As ClsGrupoProveedor) As Boolean
        ' ''    prmGrupoProveedores.atrNombreCampos = "nGrupoProveedor,cDescripcion,bActivo,"
        ' ''    prmGrupoProveedores.atrNombreCampos &= "cUsuario_Registro,dFecha_Registro,cMaquina_Registro,cUsuario_UltimaModificacion,dFecha_UltimaModificacion,"
        ' ''    prmGrupoProveedores.atrNombreCampos &= "cMaquina_UltimaModificacion,cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion"
        ' ''    prmGrupoProveedores.atrNombreTabla = "CTL_GruposProveedores"

        ' ''    If Not prmGrupoProveedores.GuardarNuevo Then
        ' ''        Return False
        ' ''    End If
        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmOficina As ClsOficina) As Boolean
        ' ''    prmOficina.atrNombreCampos = "nOficina,cDescripcion,bActivo,cUsuario_Registro,dFecha_Registro,cMaquina_Registro,"
        ' ''    prmOficina.atrNombreCampos &= "cUsuario_UltimaModificacion,dFecha_UltimaModificacion,cMaquina_UltimaModificacion,"
        ' ''    prmOficina.atrNombreCampos &= "cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion"
        ' ''    prmOficina.atrNombreTabla = "CTL_Oficinas"

        ' ''    If Not prmOficina.GuardarNuevo Then
        ' ''        Return False
        ' ''    End If
        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmCentroDeCosto As ClsCentroDeCosto) As Boolean
        ' ''    prmCentroDeCosto.atrNombreCampos = "nCentroCosto,cDescripcion,bActivo,cUsuario_Registro,dFecha_Registro,cMaquina_Registro,"
        ' ''    prmCentroDeCosto.atrNombreCampos &= "cUsuario_UltimaModificacion,dFecha_UltimaModificacion,cMaquina_UltimaModificacion,"
        ' ''    prmCentroDeCosto.atrNombreCampos &= "cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion"
        ' ''    prmCentroDeCosto.atrNombreTabla = "CTL_Centroscosto"

        ' ''    If Not prmCentroDeCosto.GuardarNuevo Then
        ' ''        Return False
        ' ''    End If
        ' ''    Return True
        ' ''End Function

        '' ''Public Shared Function Guardar(ByVal prmCatalogoDeGrupos As ClsCatalogoDeGrupos) As Boolean
        '' ''    prmCatalogoDeGrupos.atrNombreCampos = "nGrupoContable,cDescripcion,nTipoCuenta,nNaturaleza,bActivo,cUsuario_Registro,dFecha_Registro,cMaquina_Registro,cUsuario_UltimaModificacion,dFecha_UltimaModificacion,cMaquina_UltimaModificacion,cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion"
        '' ''    prmCatalogoDeGrupos.atrNombreTabla = "CTL_GruposContables"

        '' ''    If Not prmCatalogoDeGrupos.GuardarNuevo Then
        '' ''        Return False
        '' ''    End If
        '' ''    Return True
        '' ''End Function
        ' ''Public Shared Function Guardar(ByVal prmRuta As ClsRuta) As Boolean
        ' ''    prmRuta.atrNombreCampos = "nRuta,nPlaza,cDescripcion,bActivo,dFecha_Registro,cMaquina_Registro,cUsuario_Registro,cUsuario_UltimaModificacion, dFecha_UltimaModificacion, cMaquina_UltimaModificacion,cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion"
        ' ''    prmRuta.atrNombreTabla = "CTL_Rutas"

        ' ''    If Not prmRuta.GuardarNuevo Then
        ' ''        Return False
        ' ''    End If

        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmEjercicios As ClsEjercicio) As Boolean
        ' ''    prmEjercicios.atrNombreCampos = "nEjercicio,bActivo,dFecha_Registro,cMaquina_Registro,cUsuario_Registro,cUsuario_UltimaModificacion, dFecha_UltimaModificacion, cMaquina_UltimaModificacion,cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion"
        ' ''    prmEjercicios.atrNombreTabla = "CTL_Ejercicios"
        ' ''    If Not prmEjercicios.GuardarNuevo Then
        ' ''        Return False
        ' ''    End If
        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmCuentaCnt As ClsCuentaCnt) As Boolean
        ' ''    prmCuentaCnt.atrNombreCampos = "nCuentaCnt,cDescripcion,nNivelPadre,nGrupoContable,nNaturaleza,nNivel1,nNivel2,nNivel3,nNivel4,nNivel5,nNivel,"
        ' ''    prmCuentaCnt.atrNombreCampos &= "cCuentaCnt,bAfecta,bCentroCosto,nOrden,bActivo,cUsuario_Registro,dFecha_Registro,cMaquina_Registro,"
        ' ''    prmCuentaCnt.atrNombreCampos &= "cUsuario_UltimaModificacion,dFecha_UltimaModificacion,cMaquina_UltimaModificacion,"
        ' ''    prmCuentaCnt.atrNombreCampos &= "cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion"
        ' ''    prmCuentaCnt.atrNombreTabla = "CNT_Cuentas"

        ' ''    If Not prmCuentaCnt.GuardarNuevo() Then
        ' ''        Return False
        ' ''    End If
        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmCuentaCnt As ClsGrupoContable) As Boolean
        ' ''    prmCuentaCnt.atrNombreCampos = "nGrupoContable,cDescripcion,nTipoCuenta,nNaturaleza,"
        ' ''    prmCuentaCnt.atrNombreCampos &= "bActivo,cUsuario_Registro,dFecha_Registro,cMaquina_Registro,cUsuario_UltimaModificacion,"
        ' ''    prmCuentaCnt.atrNombreCampos &= "dFecha_UltimaModificacion,cMaquina_UltimaModificacion,cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion"
        ' ''    prmCuentaCnt.atrNombreTabla = "CTL_GruposContables"

        ' ''    If Not prmCuentaCnt.GuardarNuevo Then
        ' ''        Return False
        ' ''    End If
        ' ''    Return True
        ' ''End Function

        Public Shared Function Guardar(ByVal prmConfiguracion As ClsConfiguracionEdoCtaBan) As Boolean
            prmConfiguracion.atrNombreCampos = "nConsecutivo,cDescripcion,nLineaIniciaDetalle,bIngresoPorPosicion,nPosIniIngreso,nPosFinIngreso,"
            prmConfiguracion.atrNombreCampos &= "cSeparadorIngreso,nPosicionIngresoConSeparador,cValorIdentificaComoIngreso,bDiferenteDeIngreso,"
            prmConfiguracion.atrNombreCampos &= "bEgresoPorPosicion,nPosIniEgreso,nPosFinEgreso,cSeparadorEgreso,nPosicionEgresoConSeparador,"
            prmConfiguracion.atrNombreCampos &= "cValorIdentificaComoEgreso,bDiferenteDeEgreso,bEsFechaPorPosicionIngreso,nPosIniFechaIngreso,"
            prmConfiguracion.atrNombreCampos &= "nPosFinFechaIngreso,cSeparadorFechaIngreso,nPosicionFechaIngresoConSeparador,cFormatoFechaIngreso,"
            prmConfiguracion.atrNombreCampos &= "bFormatoFechaEspanolIngreso,bEsFechaPorPosicionEgreso,nPosIniFechaEgreso,nPosFinFechaEgreso,"
            prmConfiguracion.atrNombreCampos &= "cSeparadorFechaEgreso,nPosicionFechaEgresoConSeparador,cFormatoFechaEgreso,bFormatoFechaEspanolEgreso,"
            prmConfiguracion.atrNombreCampos &= "bObservacionIngresoPorPosicion,nPosIniObservacionIngreso,nPosFinObservacionIngreso,cSeparadorObservacionIngreso,"
            prmConfiguracion.atrNombreCampos &= "nPosicionObservacionIngreso,bObservacionEgresoPorPosicion,nPosIniObservacionEgreso,nPosFinObservacionEgreso,"
            prmConfiguracion.atrNombreCampos &= "cSeparadorObservacionEgreso,nPosicionObservacionEgreso,bReferenciaIngresoPorPosicion,nPosIniReferenciaIngreso,"
            prmConfiguracion.atrNombreCampos &= "nPosFinReferenciaIngreso,cSeparadorReferenciaIngreso,nPosicionReferenciaIngreso,bReferenciaEgresoPorPosicion,"
            prmConfiguracion.atrNombreCampos &= "nPosIniReferenciaEgreso,nPosFinReferenciaEgreso,cSeparadorReferenciaEgreso,nPosicionReferenciaEgreso,"
            prmConfiguracion.atrNombreCampos &= "bImporteIngresoPorPosicion,nPosIniImporteIngreso,nPosFinImporteIngreso,cSeparadorImporteIngreso,"
            prmConfiguracion.atrNombreCampos &= "nPosicionImporteIngreso,bSinPuntoDecimalImporteIngreso,nPosicionesDecimalImporteIngreso,"
            prmConfiguracion.atrNombreCampos &= "bImporteEgresoPorPosicion,nPosIniImporteEgreso,nPosFinImporteEgreso,cSeparadorImporteEgreso,"
            prmConfiguracion.atrNombreCampos &= "nPosicionImporteEgreso,bSinPuntoDecimalImporteEgreso,nPosicionesDecimalImporteEgreso,"
            prmConfiguracion.atrNombreCampos &= "bClaveIngresoPorPosicion,nPosIniClaveIngreso,nPosFinClaveIngreso,cSeparadorClaveIngreso,nPosicionClaveIngreso,"
            prmConfiguracion.atrNombreCampos &= "bClaveEgresoPorPosicion,nPosIniClaveEgreso,nPosFinClaveEgreso,cSeparadorClaveEgreso,nPosicionClaveEgreso,"
            prmConfiguracion.atrNombreCampos &= "bActivo,dFechaCancelacion,cUsuario_Registro,dFecha_Registro,cMaquina_Registro,cUsuario_UltimaModificacion,"
            prmConfiguracion.atrNombreCampos &= "dFecha_UltimaModificacion,cMaquina_UltimaModificacion,cUsuario_Eliminacion,dFecha_Eliminacion,"
            prmConfiguracion.atrNombreCampos &= "cMaquina_Eliminacion"
            prmConfiguracion.atrNombreTabla = "BAN_ConfiguracionesEdoCtaBancaria"

            If Not prmConfiguracion.GuardarNuevo Then
                Return False
            End If
            Return True
        End Function

        ' ''Public Shared Function Guardar(ByVal prmParametroCnt As ClsParametroCnt) As Boolean
        ' ''    prmParametroCnt.atrNombreCampos = "nPlaza,nDigNiv1,nDigNiv2,nDigNiv3,nDigNiv4,nDigNiv5,bActivo,cSeparadorContpaq,"
        ' ''    prmParametroCnt.atrNombreCampos &= "cUsuario_Registro,dFecha_Registro,cMaquina_Registro,cUsuario_UltimaModificacion,"
        ' ''    prmParametroCnt.atrNombreCampos &= "dFecha_UltimaModificacion,cMaquina_UltimaModificacion,cUsuario_Eliminacion,"
        ' ''    prmParametroCnt.atrNombreCampos &= "dFecha_Eliminacion,cMaquina_Eliminacion"
        ' ''    prmParametroCnt.atrNombreTabla = "ADSUM_ParametrosContabilidad"

        ' ''    If Not prmParametroCnt.GuardarNuevo Then
        ' ''        Return False
        ' ''    End If
        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmConceptoGasto As ClsConceptoGasto) As Boolean
        ' ''    prmConceptoGasto.atrNombreCampos = "nConceptoGasto,cDescripcion,bActivo,cUsuario_Registro,dFecha_Registro,nConceptoFlujo,"
        ' ''    prmConceptoGasto.atrNombreCampos &= "bClaseRetencionIVA,nTipoRetencionIVA,bClaseRetencionISR,nTipoRetencionISR,bTipoGasto,bConceptoDeActivos,"
        ' ''    prmConceptoGasto.atrNombreCampos &= "cMaquina_Registro,cUsuario_UltimaModificacion,dFecha_UltimaModificacion,"
        ' ''    prmConceptoGasto.atrNombreCampos &= "cMaquina_UltimaModificacion,cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion"
        ' ''    prmConceptoGasto.atrNombreTabla = "CTL_ConceptosGastos"

        ' ''    If Not prmConceptoGasto.GuardarNuevo Then
        ' ''        Return False
        ' ''    End If
        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal ConfiguracionTiposPolizas As ClsConfiguracionTiposPolizas) As Boolean
        ' ''    ConfiguracionTiposPolizas.atrNombreCampos = "nConfiguracion,cDescripcion,bActivo,cUsuario_Registro,dFecha_Registro,"
        ' ''    ConfiguracionTiposPolizas.atrNombreCampos &= "cMaquina_Registro,cUsuario_UltimaModificacion,dFecha_UltimaModificacion,"
        ' ''    ConfiguracionTiposPolizas.atrNombreCampos &= "cMaquina_UltimaModificacion,cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion"
        ' ''    ConfiguracionTiposPolizas.atrNombreTabla = "CNT_ConfiguracionTiposPolizas"

        ' ''    If Not ConfiguracionTiposPolizas.GuardarNuevo Then
        ' ''        Return False
        ' ''    End If
        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function ActivaCancelaClasificador(ByVal prmClasificador As Integer, Optional ByVal prmActiva As Boolean = True) As Boolean
        ' ''    Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''    Dim vSql As String = ""

        ' ''    vSql = "UPDATE ADSUM_Clasificadores SET bActivo = " & IIf(prmActiva, 1, 0) & " WHERE nClasificador = " & prmClasificador
        ' ''    Return DAO.EjecutaComandoSQL(vSql)
        ' ''End Function

        ' ''Public Shared Function ClasificadorActivo(ByVal prmClasificador As Integer) As Boolean
        ' ''    Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''    Dim DT As New DataTable
        ' ''    Dim vSql As String = ""

        ' ''    vSql = "SELECT bActivo FROM ADSUM_Clasificadores(NoLock) WHERE nClasificador = " & prmClasificador

        ' ''    DAO.RegresaConsultaSQL(vSql, DT)

        ' ''    If DT Is Nothing OrElse DT.Rows.Count = 0 Then Return False

        ' ''    Return DT.Rows(0).Item(0)
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmProveedor As ClsProveedoresBancos) As Boolean
        ' ''    prmProveedor.atrNombreCampos = "nProveedor,cNombreFiscal,cNombreComercial,cRFC,bActivo,bPolizaAcumulada,nPlazaRegistro,"
        ' ''    prmProveedor.atrNombreCampos &= "cUsuario_Registro,dFecha_Registro,cMaquina_Registro,cUsuario_UltimaModificacion,"
        ' ''    prmProveedor.atrNombreCampos &= "dFecha_UltimaModificacion,cMaquina_UltimaModificacion,cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion"
        ' ''    prmProveedor.atrNombreTabla = "CTL_Proveedores"

        ' ''    Return prmProveedor.GuardarNuevo()
        ' ''End Function

        ' ''Public Shared Function Guardar(ByVal prmCliente As ClsClientesBancos) As Boolean
        ' ''    prmCliente.atrNombreCampos = "nCliente,cNombreFiscal,cNombreComercial,cRFC,bActivo,nPlaza,"
        ' ''    prmCliente.atrNombreCampos &= "cUsuario_Registro,dFecha_Registro,cMaquina_Registro,cUsuario_UltimaModificacion,"
        ' ''    prmCliente.atrNombreCampos &= "dFecha_UltimaModificacion,cMaquina_UltimaModificacion,cUsuario_Eliminacion,dFecha_Eliminacion,cMaquina_Eliminacion"
        ' ''    prmCliente.atrNombreTabla = "CTL_Clientes"

        ' ''    If Not prmCliente.GuardarNuevo() Then
        ' ''        Return False
        ' ''    End If

        ' ''    Return True
        ' ''End Function

        Public Shared Function Guardar(ByVal prmTIpoPermiso As Catalogos.ClsTipoPermiso) As Boolean

            prmTIpoPermiso.atrNombreCampos = "nTipoPermiso,cDescripcion,cSqlCatalogo,cCampoPrimario,cCampoDescripcionPrimario,bActivo,CUSUARIO_REGISTRO,DFECHA_REGISTRO,CMAQUINA_REGISTRO,CUSUARIO_ULTIMAMODIFICACION,DFECHA_ULTIMAMODIFICACION,CMAQUINA_ULTIMAMODIFICACION,CUSUARIO_ELIMINACION,DFECHA_ELIMINACION,CMAQUINA_ELIMINACION"
            prmTIpoPermiso.atrNombreTabla = "CTL_TiposPermisosSistema"

            If Not prmTIpoPermiso.GuardarNuevo Then
                Return False
            End If
            Return True
        End Function

        ' ''Public Shared Function ActualizaMantenimientoEnCurso(ByVal prmAlmacen As Catalogos.ClsAlmacen, ByVal prmActivarMantenimiento As Boolean) As Boolean
        ' ''    If prmAlmacen Is Nothing Then Return False
        ' ''    Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''    Dim vcSQL As String = "UPDATE CTL_Almacenes SET bMantenimientoEnCurso = " & IIf(prmActivarMantenimiento, 1, 0) & " WHERE nAlmacen = " & prmAlmacen.Folio
        ' ''    Return DAO.EjecutaComandoSQL(vcSQL)
        ' ''End Function
    End Class
End Namespace
