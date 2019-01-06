Imports Sistema.DataAccessCls



Namespace Access
    Public Class FabricaDatosCFDI32

        Public Shared Function ObtenDatosEncabezado(ByVal prmID As Long) As DatosCab

            Dim ret As New DatosCab
            Dim DAO As Sistema.DataAccessCls = Sistema.DataAccessCls.DevuelveInstancia
            Dim vcSQL As String
            Dim DT As New DataTable
            Dim vRow As DataRow

            vcSQL = "SELECT * FROM VW_ENCABEZADOXMLCFDI32(NOLOCK)" & vbCrLf
            vcSQL = vcSQL & "WHERE ID = " & prmID

            DAO.RegresaConsultaSQL(vcSQL, DT)

            If Not DT Is Nothing AndAlso DT.Rows.Count > 0 Then

                vRow = DT.Rows(0)

                ret.ID = IIf(vRow("ID") Is DBNull.Value, "", vRow("ID"))
                ret.CLIENTECLAVE = IIf(vRow("CLIENTECLAVE") Is DBNull.Value, "", vRow("CLIENTECLAVE"))
                ret.CLIENTENOMBRE = IIf(vRow("CLIENTENOMBRE") Is DBNull.Value, "", vRow("CLIENTENOMBRE"))
                ret.CLIENTERFC = IIf(vRow("CLIENTERFC") Is DBNull.Value, "", vRow("CLIENTERFC"))
                ret.CLIENTEDIRECCION = IIf(vRow("CLIENTEDIRECCION") Is DBNull.Value, "", vRow("CLIENTEDIRECCION"))
                ret.CLIENTENUMEXT = IIf(vRow("CLIENTENUMEXT") Is DBNull.Value, "", vRow("CLIENTENUMEXT"))
                ret.CLIENTENUMINT = IIf(vRow("CLIENTENUMINT") Is DBNull.Value, "", vRow("CLIENTENUMINT"))
                ret.CLIENTECOLONIA = IIf(vRow("CLIENTECOLONIA") Is DBNull.Value, "", vRow("CLIENTECOLONIA"))
                ret.CLIENTECIUDAD = IIf(vRow("CLIENTECIUDAD") Is DBNull.Value, "", vRow("CLIENTECIUDAD"))
                ret.CLIENTEESTADO = IIf(vRow("CLIENTEESTADO") Is DBNull.Value, "", vRow("CLIENTEESTADO"))
                ret.CLIENTEPAIS = IIf(vRow("CLIENTEPAIS") Is DBNull.Value, "", vRow("CLIENTEPAIS"))
                ret.CLIENTEMAIL = IIf(vRow("CLIENTEEMAIL") Is DBNull.Value, "", vRow("CLIENTEEMAIL"))
                ret.CLIENTECP = IIf(vRow("CLIENTECP") Is DBNull.Value, "", vRow("CLIENTECP"))
                ret.CLIENTECUENTA = IIf(vRow("CLIENTECUENTA") Is DBNull.Value, "", vRow("CLIENTECUENTA"))
                ret.EFSERIE = IIf(vRow("EFSERIE") Is DBNull.Value, "", vRow("EFSERIE"))
                ret.EFFACTURA = IIf(vRow("EFCFACTURA") Is DBNull.Value, "", vRow("EFCFACTURA"))
                ret.EFFECHA = IIf(vRow("EFFECHA") Is DBNull.Value, "", vRow("EFFECHA"))
                ret.EFSUBTOTALAD = IIf(vRow("EFSUBTOTALAD") Is DBNull.Value, 0, vRow("EFSUBTOTALAD"))
                ret.EFDESCUENTO = IIf(vRow("EFDESCUENTO") Is DBNull.Value, 0, vRow("EFDESCUENTO"))
                ret.EFIMPUESTOS = IIf(vRow("EFIMPUESTOS") Is DBNull.Value, 0, vRow("EFIMPUESTOS"))
                ret.EFIVARETENIDO = IIf(vRow("EFIVARETENIDO") Is DBNull.Value, 0, vRow("EFIVARETENIDO"))
                ret.EFISRRETENIDO = IIf(vRow("EFISRRETENIDO") Is DBNull.Value, 0, vRow("EFISRRETENIDO"))
                ret.EFSUBTOTALDD = IIf(vRow("EFSUBTOTALDD") Is DBNull.Value, 0, vRow("EFSUBTOTALDD"))
                ret.EFFORMADEPAGO = IIf(vRow("EFSUBTOTALDD") Is DBNull.Value, 0, vRow("EFFORMADEPAGO"))
                ret.EFCONDICIONDEPAGO = IIf(vRow("EFCONDICIONDEPAGO") Is DBNull.Value, "", vRow("EFCONDICIONDEPAGO"))
                ret.EFMONEDA = IIf(vRow("EFMONEDA") Is DBNull.Value, "", vRow("EFMONEDA"))
                ret.EFPARIDAD = IIf(vRow("EFPARIDAD") Is DBNull.Value, 0, vRow("EFPARIDAD"))
                ret.EFDOCUMENTO = IIf(vRow("EFDOCUMENTO") Is DBNull.Value, 0, vRow("EFDOCUMENTO"))
                ret.EFMETODOPAGO = IIf(vRow("EFDOCUMENTO") Is DBNull.Value, 0, vRow("EFMETODOPAGO"))
                ret.EFCUENTA = IIf(vRow("EFCUENTA") Is DBNull.Value, 0, vRow("EFCUENTA"))
                ret.EFCERTIFICADO = IIf(vRow("EFCERTIFICADO") Is DBNull.Value, 0, vRow("EFCERTIFICADO"))
                ret.EFSELLO = IIf(vRow("EFSELLO") Is DBNull.Value, 0, vRow("EFSELLO"))
                ret.EFCADENA = IIf(vRow("EFCADENA") Is DBNull.Value, 0, vRow("EFCADENA"))
                ret.EFIMPLETRA = IIf(vRow("EFIMPLETRA") Is DBNull.Value, 0, vRow("EFIMPLETRA"))
                ret.EFUUID = IIf(vRow("EFUUID") Is DBNull.Value, 0, vRow("EFUUID"))
                ret.EFFECHATIMBRE = IIf(vRow("EFFECHATIMBRE") Is DBNull.Value, DAO.RegresaFechaDelSistema, vRow("EFFECHATIMBRE"))
                ret.EFSELLOSAT = IIf(vRow("EFSELLOSAT") Is DBNull.Value, "", vRow("EFSELLOSAT"))
                ret.EFREGIMEN = IIf(vRow("EFREGIMEN") Is DBNull.Value, "", vRow("EFREGIMEN"))
                ret.EFLUGAREXPEDICION = IIf(vRow("EFLUGAREXPEDICION") Is DBNull.Value, "", vRow("EFLUGAREXPEDICION"))
                ret.EFIMPORTE = IIf(vRow("EFIMPORTE") Is DBNull.Value, 0, vRow("EFIMPORTE"))
                ret.EFTIPOCOMPROBANTE = IIf(vRow("EFTIPOCOMPROBANTE") Is DBNull.Value, "", vRow("EFTIPOCOMPROBANTE"))



                ret.RFC = IIf(vRow("EMPRFC") Is DBNull.Value, "", vRow("EMPRFC"))
                ret.RazonSocial = IIf(vRow("EMPNOMBRE") Is DBNull.Value, "", vRow("EMPNOMBRE"))
                ret.Calle = IIf(vRow("EMPCALLE") Is DBNull.Value, "", vRow("EMPCALLE"))
                ret.CP = IIf(vRow("EMPCP") Is DBNull.Value, "", vRow("EMPCP"))
                ret.Colonia = IIf(vRow("EMPCOLONIA") Is DBNull.Value, "", vRow("EMPCOLONIA"))
                ret.Estado = IIf(vRow("EMPESTADO") Is DBNull.Value, "", vRow("EMPESTADO"))
                ret.Localidad = IIf(vRow("EMPLOCALIDAD") Is DBNull.Value, "", vRow("EMPLOCALIDAD"))
                ret.Municipio = IIf(vRow("EMPMUNICIPIO") Is DBNull.Value, "", vRow("EMPMUNICIPIO"))
                ret.NumExt = IIf(vRow("EMPNUMEXT") Is DBNull.Value, "", vRow("EMPNUMEXT"))
                ret.NumInt = IIf(vRow("EMPNUMINT") Is DBNull.Value, "", vRow("EMPNUMINT"))
                ret.Pais = IIf(vRow("EMPPAIS") Is DBNull.Value, "", vRow("EMPPAIS"))
                ret.RutaCert = IIf(vRow("EMPRUTACERT") Is DBNull.Value, "", vRow("EMPRUTACERT"))
                ret.RutaKey = IIf(vRow("EMPRUTAKEY") Is DBNull.Value, "", vRow("EMPRUTAKEY"))
                ret.RutaXml = IIf(vRow("EMPRUTAXML") Is DBNull.Value, "", vRow("EMPRUTAXML"))
                ret.PassKey = IIf(vRow("EMPPASSKEY") Is DBNull.Value, "", vRow("EMPPASSKEY"))

                ret.DestinoAcuseXml = IIf(vRow("EMPRUTAACUSEXML") Is DBNull.Value, "", vRow("EMPRUTAACUSEXML"))
                ret.DestinoXml = IIf(vRow("EMPRUTADESTXML") Is DBNull.Value, "", vRow("EMPRUTADESTXML"))
                ret.RutaBidimensional = IIf(vRow("EMPRUTABIDIMENSIONAL") Is DBNull.Value, "", vRow("EMPRUTABIDIMENSIONAL"))


                ret.UsuarioWS = IIf(vRow("EMPUSUWS") Is DBNull.Value, "", vRow("EMPUSUWS"))
                ret.PasswordWS = IIf(vRow("EMPPASSWS") Is DBNull.Value, "", vRow("EMPPASSWS"))
                ret.AcuseCancelacion = IIf(vRow("EMPRUTAACUSECANC") Is DBNull.Value, "", vRow("EMPRUTAACUSECANC"))

                ret.SelloCancelacion = IIf(vRow("EMPSELLOCANC") Is DBNull.Value, "", vRow("EMPSELLOCANC"))
                ret.PassCancelacion = IIf(vRow("EMPPASSCANC") Is DBNull.Value, "", vRow("EMPPASSCANC"))


            Else
                Return Nothing
            End If
            Return ret
        End Function

        Private Shared Function fgObtenParametroGeneral(ByVal prmClave As String) As String
            Dim DAO As Sistema.DataAccessCls = Sistema.DataAccessCls.DevuelveInstancia
            Dim vcSQL As String
            Dim DT As New DataTable

            fgObtenParametroGeneral = ""

            vcSQL = "SELECT CVALORPAR FROM FAC_PARAMETROS WHERE CCLAVEPAR = '" & prmClave & "'"

            DAO.RegresaConsultaSQL(vcSQL, DT)

            If Not DT Is Nothing AndAlso Not DT.Rows.Count = 0 Then
                fgObtenParametroGeneral = IIf(DT.Rows(0)("CVALORPAR") Is DBNull.Value, "", DT.Rows(0)("CVALORPAR"))
            End If
        End Function

        Public Shared Function ObtenDatosDetalle(ByVal prmID As String) As DataTable

            Dim DAO As Sistema.DataAccessCls = Sistema.DataAccessCls.DevuelveInstancia
            Dim vcSQL As String
            Dim DT As New DataTable

            vcSQL = "SELECT * FROM VW_DETALLECONCEPTOSXMLCFDI32(NOLOCK)" & vbCrLf
            vcSQL = vcSQL & "WHERE ID = " & prmID

            DAO.RegresaConsultaSQL(vcSQL, DT)

            Return DT
        End Function

        Public Shared Function ObtenDatosImpuestos(ByVal prmID As String) As DataTable

            Dim DAO As Sistema.DataAccessCls = Sistema.DataAccessCls.DevuelveInstancia
            Dim vcSQL As String
            Dim DT As New DataTable

            vcSQL = "SELECT * FROM VW_DETALLEIVAXMLCFDI32(NOLOCK)" & vbCrLf
            vcSQL = vcSQL & "WHERE ID = '" & prmID & "'"

            DAO.RegresaConsultaSQL(vcSQL, DT)

            Return DT
        End Function

        Public Shared Function ObtenDatosImpuestosTrasladados(ByVal prmID As String) As DataTable

            Dim vcSQL As String
            Dim DT As New DataTable
            Dim DAO As Sistema.DataAccessCls = Sistema.DataAccessCls.DevuelveInstancia


            vcSQL = "SELECT * FROM VW_DETALLEIVAXMLCFDI32(NOLOCK)" & vbCrLf
            vcSQL = vcSQL & "WHERE ID = " & prmID

            DAO.RegresaConsultaSQL(vcSQL, DT)

            Return DT

        End Function

        Public Shared Function ObtenDatosImpuestosRetenidos(ByVal prmID As String) As DataTable

            Dim vcSQL As String
            Dim DT As New DataTable
            Dim DAO As Sistema.DataAccessCls = Sistema.DataAccessCls.DevuelveInstancia


            vcSQL = "SELECT * FROM VW_DETALLERETXMLCFDI32(NOLOCK)" & vbCrLf
            vcSQL = vcSQL & "WHERE ID = " & prmID

            DAO.RegresaConsultaSQL(vcSQL, DT)

            Return DT
        End Function

        Public Shared Function ObtenDatosCabeceroNomina(ByVal prmID As String) As DataTable

            Dim vcSQL As String
            Dim DT As New DataTable
            Dim DAO As Sistema.DataAccessCls = Sistema.DataAccessCls.DevuelveInstancia


            vcSQL = "SELECT * FROM VW_CFDINOMINA_ENCABEZADO(NOLOCK)" & vbCrLf
            vcSQL = vcSQL & "WHERE ID = " & prmID

            DAO.RegresaConsultaSQL(vcSQL, DT)

            Return DT
        End Function

        Public Shared Function ObtenDatosPercepcionesNomina(ByVal prmID As String) As DataTable

            Dim vcSQL As String
            Dim DT As New DataTable
            Dim DAO As Sistema.DataAccessCls = Sistema.DataAccessCls.DevuelveInstancia


            vcSQL = "SELECT * FROM VW_CFDINOMINA_PERCEPCIONES(NOLOCK)" & vbCrLf
            vcSQL = vcSQL & "WHERE ID = " & prmID

            DAO.RegresaConsultaSQL(vcSQL, DT)

            Return DT
        End Function

        Public Shared Function ObtenDatosDeduccionesNomina(ByVal prmID As String) As DataTable

            Dim vcSQL As String
            Dim DT As New DataTable
            Dim DAO As Sistema.DataAccessCls = Sistema.DataAccessCls.DevuelveInstancia


            vcSQL = "SELECT * FROM VW_CFDINOMINA_DEDUCCIONES(NOLOCK)" & vbCrLf
            vcSQL = vcSQL & "WHERE ID = " & prmID

            DAO.RegresaConsultaSQL(vcSQL, DT)

            Return DT
        End Function




    End Class
End Namespace



