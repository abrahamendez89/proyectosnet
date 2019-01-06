Imports Access
Imports Sistema.Comunes.Comun
Imports Sistema.Comunes
'Imports ADSUM




Namespace Comunes.Comun

    Public Class Fabrica


        Private Shared atrServidoresAmigos As Hashtable

        Private Shared atrImagenes As Catalogo



        Public Shared Function ObtenGenerico(ByVal prmValor As String, ByVal prmContenedor As Hashtable, ByVal prmCatalogo As Catalogo, ByVal prmDelegadoCreacion As Catalogo.ObtenerObjetoCatalogoEventHandler, Optional ByVal TIEMPO_REAL As Boolean = False) As Object
            If prmContenedor Is Nothing Then prmContenedor = New Hashtable
            Dim vObject As Object
            If Not TIEMPO_REAL Then
                vObject = prmContenedor(prmValor.Trim)
                If Not vObject Is Nothing Then Return vObject
            End If

            Dim vRow As DataRow = prmCatalogo.ObtenElementoRow(prmValor.Trim)
            If Not vRow Is Nothing Then
                vObject = prmDelegadoCreacion(vRow)
            End If
            If Not vObject Is Nothing AndAlso prmContenedor(prmValor.Trim) Is Nothing Then prmContenedor.Add(prmValor.Trim, vObject)
            Return vObject
        End Function


        Public Shared Function ObtenImpresoraConfigurada_TamañoCartaCondensada() As ImpresionReportes.ImpresionReportes.Cls_Imp_ImpresoraConfigurada
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vImpresoraAux As ImpresionReportes.ImpresionReportes.cls_Imp_Impresora = ImpresionReportes.ImpresionReportes.Cls_Imp_Fabrica.ObtenImpresora(DAO.ParametroAdministradoObtener("IMP", "ImpresoraDefaultImpresionDirecta"))
            Dim vTipoEmulacion As ImpresionReportes.ImpresionReportes.Cls_Imp_TipoDeEmulacion = ImpresionReportes.ImpresionReportes.Cls_Imp_Fabrica.ObtenTipoDeEmulacion(DAO.ParametroAdministradoObtener("IMP", "IMP_TipoDeEmulacion_Epson"))
            Dim vTamañoDeHoja As ImpresionReportes.ImpresionReportes.Cls_Imp_TamañoHoja = ImpresionReportes.ImpresionReportes.Cls_Imp_Fabrica.ObtenTamañoHoja(DAO.ParametroAdministradoObtener("IMP", "IMP_TamañosHoja_Carta"))
            Dim vTamañoDeCaracter As ImpresionReportes.ImpresionReportes.Cls_Imp_TamañoCaracter = ImpresionReportes.ImpresionReportes.Cls_Imp_Fabrica.ObtenTamañoCaracter(DAO.ParametroAdministradoObtener("IMP", "IMP_TamañosCaracter_17CPI"))
            Dim vTamañoDeLinia As ImpresionReportes.ImpresionReportes.Cls_Imp_TamañoLinea = ImpresionReportes.ImpresionReportes.Cls_Imp_Fabrica.ObtenTamañoLinea(DAO.ParametroAdministradoObtener("IMP", "IMP_TamañosLinea_6LPI"))
            'nTipoEmulacion nTamanoHoja nTamanoCaracter nTamanoLinea cCaracterControlTamanoCaracter                     cCaracterControlTamanoLinea                        nTotalCaracteresXLinea nTotalLineasXHoja
            '3              1           1               1            10                                                                                                    80                    63
            Dim vCaracteresDeControlDeTamaño As ImpresionReportes.ImpresionReportes.Cls_Imp_CaracteresDeControlDeTamaño = ImpresionReportes.ImpresionReportes.Cls_Imp_Fabrica.ObtenCaracteresDeControlDeTamaño(vTipoEmulacion, vTamañoDeHoja, vTamañoDeCaracter, vTamañoDeLinia)

            ObtenImpresoraConfigurada_TamañoCartaCondensada = New ImpresionReportes.ImpresionReportes.Cls_Imp_ImpresoraConfigurada(vImpresoraAux, vCaracteresDeControlDeTamaño)
        End Function


#Region "   PRODUCTOS   "


#End Region

        'IMAGENES
        'No se llevara un contendor de imagenes por el espacio utilizado en memoria
        'Public Shared Function ObtenImagen(ByVal prmServicio As Integer) As Productos.ClsServicio
        '    If atrCatalogoServicios Is Nothing Then atrCatalogoServicios = New Catalogo(New MetaCatalogo("SERVICIOS"))
        '    Dim vObject As Object = ObtenGenerico(prmServicio.ToString, atrServiciosInMemory, atrCatalogoServicios, New Catalogo.ObtenerObjetoCatalogoEventHandler(AddressOf ObtenServicio))

        '    Return IIf(vObject Is Nothing, Nothing, CType(vObject, Productos.ClsServicio))
        'End Function

        Public Shared Function ObtenImagen(ByVal prmImagen As Integer) As ClsImagen
            If atrImagenes Is Nothing Then atrImagenes = New Catalogo(New MetaCatalogo("IMAGENES"))
            Dim vObject As DataRow = atrImagenes.ObtenElementoRow(prmImagen.ToString)

            Return IIf(vObject Is Nothing, Nothing, CType(ObtenImagen(vObject), ClsImagen))
        End Function

        Public Shared Function ObtenImagen(ByVal prmRow As DataRow) As Object
            Dim vImagen As New ClsImagen(prmRow("nImagen"), prmRow("cDescripcion"), CType(prmRow("iImagen"), Byte()))
            vImagen.Activo = prmRow("bActivo")
            vImagen.CargaDatosRegistro(prmRow)
            Return vImagen
        End Function


        ' ''Public Shared Function ServidorAmigo(ByVal prmNombreServidor As String) As ClsServidorAmigo
        ' ''    prmNombreServidor = prmNombreServidor.Trim
        ' ''    If atrServidoresAmigos Is Nothing Then atrServidoresAmigos = New Hashtable
        ' ''    ServidorAmigo = atrServidoresAmigos(prmNombreServidor)
        ' ''    If ServidorAmigo Is Nothing Then
        ' ''        Dim vSql As String = "SELECT * FROM ADSUM_ServidoresAmigos(NOLOCK) WHERE cServidorAmigo = '" & prmNombreServidor & "'"
        ' ''        Dim vTabla As New DataTable
        ' ''        Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''        If DAO.RegresaConsultaSQL(vSql, vTabla) Then
        ' ''            Dim vRow As DataRow = vTabla.Rows(0)
        ' ''            ServidorAmigo = New ClsServidorAmigo
        ' ''            ServidorAmigo.ServidorAmigo = vRow("cServidorAmigo")
        ' ''            ServidorAmigo.Servidor = vRow("cServidor")
        ' ''            ServidorAmigo.BaseDeDatos = vRow("cBaseDeDatos")
        ' ''            ServidorAmigo.Login = vRow("cLogin")
        ' ''            ServidorAmigo.PassWord = vRow("cPassWord")
        ' ''        End If
        ' ''    End If

        ' ''End Function

#Region "Empleados"
        'Public Shared Function ObtenEmpleadoLoggeoSistema(Optional ByVal prmLogin As String = "") As Dominio.Catalogos.ClsEmpleado
        '    Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        '    Dim vlClsEmpleado As Dominio.Catalogos.ClsEmpleado
        '    Dim vlSql As String

        '    If prmLogin = "" Then
        '        prmLogin = DAO.GetLoginUsuario
        '    End If

        '    vlSql = "Select nPersonal From Adsum_Usuarios Where cLogin='" & prmLogin & "'"
        '    vlSql = DAO.RegresaDatoSQL(vlSql)
        '    vlClsEmpleado = Dominio.Catalogos.FabricaCatalogos.ObtenEmpleado(Val(vlSql), True)

        '    Return vlClsEmpleado
        'End Function
#End Region


    End Class

End Namespace