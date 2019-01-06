Imports Sistema.Comunes.Comun

Namespace Comunes.Registros

    Public Class FabricaRegistros
        Inherits Comunes.Comun.Fabrica

        Public Shared Function ObtenRegistroFactura(ByVal prmFactura As Integer, ByVal prmRFCEmisor As Integer) As ClsRegistroFactura

            Dim DT As New DataTable
            Dim DTDetalle As New DataTable
            Dim ret As New ClsRegistroFactura()
            Dim vcSQL As String
            Dim DAO As Sistema.DataAccessCls = DataAccessCls.DevuelveInstancia


            vcSQL = "SELECT * FROM FAC_ENCFACTURAS WHERE NFOLIO = " & prmFactura & " AND NRFCEMISOR = " & prmRFCEmisor

            DAO.RegresaConsultaSQL(vcSQL, DT)

            If Not DT Is Nothing AndAlso DT.Rows.Count > 0 Then

                Dim prmrow As DataRow
                prmrow = DT.Rows(0)

                ret.nFactura = prmrow("nFactura")
                ret.Cliente = prmrow("NCLIENTE")
                ret.NSERIE = prmrow("NSERIE")
                ret.SUBTOTAL = prmrow("NSUBTOTAL")
                ret.DESCUENTO = prmrow("NDESCUENTO")
                ret.IMPUESTOS = prmrow("NIMPUESTOS")
                ret.RFCEmisor = prmrow("NRFCEMISOR")
                ret.IVARETENIDO = prmrow("NIVARETENIDO")
                ret.ISRRETENIDO = prmrow("NISRRETENIDO")
                ret.IMPORTE = prmrow("NIMPORTE")
                ret.OBSERVACION = prmrow("COBSERVACION")
                ret.PARIDAD = prmrow("NPARIDAD")
                ret.CSTATUS = prmrow("CSTATUS")
                ret.FECHA = prmrow("DFECHA")
                ret.CCVE_COND = prmrow("CCONDICIONPAGO")
                ret.CMONEDA = prmrow("CMONEDA")
                ret.SUBTOTALDD = prmrow("NSUBTOTALDD")
                ret.FECHACAN = IIf(prmrow("DFECHACAN") Is DBNull.Value, DAO.RegresaFechaDelSistema, prmrow("DFECHACAN"))
                ret.CERTIFICADO = IIf(prmrow("CCERTIFICADO") Is DBNull.Value, "", prmrow("CCERTIFICADO"))
                ret.Sello = IIf(prmrow("CSELLO") Is DBNull.Value, "", prmrow("CSELLO"))
                ret.Cadena = IIf(prmrow("CCADENA") Is DBNull.Value, "", prmrow("CCADENA"))
                ret.IMPORTECONLETRA = prmrow("CIMPORTECONLETRA")
                ret.UID = IIf(prmrow("UUID") Is DBNull.Value, "", prmrow("UUID"))
                ret.FECHATIMBRADO = IIf(prmrow("DFECHATIMBRADO") Is DBNull.Value, DAO.RegresaFechaDelSistema, prmrow("DFECHATIMBRADO"))
                ret.SELLOSAT = IIf(prmrow("CSELLOSAT") Is DBNull.Value, "", prmrow("CSELLOSAT"))
                ret.REGIMEN = prmrow("CREGIMEN")
                ret.LUGAREXPEDICION = prmrow("CLUGAREXPEDICION")
                ret.CTIPOPAGO = prmrow("CTIPOPAGO")
                ret.CCUENTA = IIf(prmrow("CCUENTA") Is DBNull.Value, "", prmrow("CCUENTA"))
                ret.SUCURSAL = IIf(prmrow("NEMISORSUCURSAL") Is DBNull.Value, 0, prmrow("NEMISORSUCURSAL"))
                ret.SERIE = IIf(prmrow("CSERIE") Is DBNull.Value, "", prmrow("CSERIE"))
                ret.FACTURA = IIf(prmrow("NFOLIO") Is DBNull.Value, 0, prmrow("NFOLIO"))
                ret.Referencia1 = IIf(prmrow("CREFERENCIA1") Is DBNull.Value, "", prmrow("CREFERENCIA1"))
                ret.Referencia2 = IIf(prmrow("CREFERENCIA2") Is DBNull.Value, "", prmrow("CREFERENCIA2"))
                ret.Referencia3 = IIf(prmrow("CREFERENCIA3") Is DBNull.Value, "", prmrow("CREFERENCIA3"))
                ret.EsCFDI = IIf(prmrow("UUID") Is DBNull.Value, False, True)

                vcSQL = "SELECT COALESCE(nConcepto,0) AS nConcepto,COALESCE(CCONCEPTO,'') AS cDescripcion,NCANTIDAD AS nCantidad," & vbCrLf
                vcSQL = vcSQL & "NPRECIO AS nPrecio,NDESCUENTO AS nDescuento,NIMPUESTOS AS nImpuestos,NIMPORTE AS nImporte,NSUBTOTAL AS nSubtotal," & vbCrLf
                vcSQL = vcSQL & "NIVA AS nIVA,CUNIDAD AS cUnidad" & vbCrLf
                vcSQL = vcSQL & "FROM FAC_DETFACTURAS(NOLOCK)" & vbCrLf
                vcSQL = vcSQL & "WHERE nFactura = " & ret.nFactura & " AND NRFCEMISOR = " & prmRFCEmisor & vbCrLf
                vcSQL = vcSQL & "ORDER BY NRENGLON" & vbCrLf

                DAO.RegresaConsultaSQL(vcSQL, DTDetalle)

                If Not DTDetalle Is Nothing Then
                    ClsTools.copiaRows(DTDetalle.Select(""), ret.DTDetalle, DTDetalle.Columns)
                End If

            End If

            Return ret
        End Function

        Public Shared Function ObtenRegistroFlete(ByVal prmFactura As Long) As ClsRegistroFlete

            Dim DT As New DataTable
            Dim ret As New ClsRegistroFlete()
            Dim vcSQL As String
            Dim DAO As Sistema.DataAccessCls = DataAccessCls.DevuelveInstancia


            vcSQL = "SELECT * FROM SPV_Fletes WHERE nFactura = " & prmFactura

            DAO.RegresaConsultaSQL(vcSQL, DT)

            If Not DT Is Nothing AndAlso DT.Rows.Count > 0 Then

                Dim prmrow As DataRow
                prmrow = DT.Rows(0)

                ret.Factura = prmrow("nFactura")
                ret.MovimientoFlete = prmrow("nMovimientoFlete")
                ret.Ruta = prmrow("cRuta")
                ret.OrigenRemitente = prmrow("cOrigenRemitente")
                ret.DestinoDestinatario = prmrow("cDestinoDestinatario")
                ret.Kilos = prmrow("nKilos")
                ret.FechaCarga = prmrow("dFechaCarga")
                ret.FechaEntrega = prmrow("dFechaEntrega")
                ret.DescripcionCarga = prmrow("cDescripcionCarga")
                ret.Operador = prmrow("cOperador")
                ret.Unidad = prmrow("cUnidad")
                ret.PlacasUnidad = prmrow("cPlacasUnidad")
                ret.Remolque1 = prmrow("cRemolque1")
                ret.PlacasRemolque1 = prmrow("cPlacasRemolque1")
                ret.Dolly = prmrow("cDolly")
                ret.Remolque2 = prmrow("cRemolque2")
                ret.PlacasRemolque2 = prmrow("cPlacasRemolque2")
                ret.Observaciones = prmrow("cObservaciones")
                ret.IVAFlete = prmrow("bIVAFlete")
                ret.RETFlete = prmrow("bRETFlete")
                ret.IVAManiobras = prmrow("bIVAManiobras")
                ret.RETManiobras = prmrow("bRETManiobras")
                ret.IVARepartos = prmrow("bIVARepartos")
                ret.RETRepartos = prmrow("bRETRepartos")
                ret.IVARecolectas = prmrow("bIVARecolectas")
                ret.RETRecolectas = prmrow("bRETRecolectas")
                ret.IVAAutopistas = prmrow("bIVAAutopistas")
                ret.RETAutopistas = prmrow("bRETAutopistas")
                ret.IVADemoras = prmrow("bIVADemoras")
                ret.RETDemoras = prmrow("bRETDemoras")
                ret.IVAOtros = prmrow("bIVAOtros")
                ret.RETOtros = prmrow("bRETOtros")
                ret.IVASeguros = prmrow("bIVASeguros")
                ret.RETSeguros = prmrow("bRETSeguros")
                ret.IVARentas = prmrow("bIVARentas")
                ret.RETRentas = prmrow("bRETRentas")
                ret.PorcentajeIVA = prmrow("nPorcentajeIVA")
                ret.PorcentajeRET = prmrow("nPorcentajeRET")
                ret.Flete = prmrow("nFlete")
                ret.Maniobras = prmrow("nManiobras")
                ret.Repartos = prmrow("nRepartos")
                ret.Recolectas = prmrow("nRecolectas")
                ret.Autopistas = prmrow("nAutopistas")
                ret.Demoras = prmrow("nDemoras")
                ret.Otros = prmrow("nOtros")
                ret.Seguros = prmrow("nSeguros")
                ret.Rentas = prmrow("nRentas")
                ret.Subtotal = prmrow("nSubtotal")
                ret.IVA = prmrow("nIVA")
                ret.IVARet = prmrow("nIVARet")
                ret.Total = prmrow("nTotal")
                ret.Bultos = prmrow("nBultos")
                ret.Clasificacion = prmrow("cClasificacion")
            End If

            Return ret
        End Function


        Public Shared Function fgProcesaDatosNominaAdm(ByVal prmTemporada As String, ByVal prmSemana As String, ByVal prmNomina As String, ByVal prmFechaPago As Date) As Boolean

            Dim vParam(3) As Object
            Dim vlSQL As String
            Dim vDs As New DataSet
            Dim DAO As Sistema.DataAccessCls = DataAccessCls.DevuelveInstancia


            vlSQL = "SPINSERTACFDINOMINAADM"

            vParam(0) = prmTemporada
            vParam(1) = prmSemana
            vParam(2) = prmNomina
            vParam(3) = prmFechaPago

            If Not DAO.RegresaConsultaSQL(vlSQL, vDs, vParam) Then
                Return False
            End If

            Return True
        End Function

        Public Shared Function fgProcesaDatosNominaEve(ByVal prmTemporada As String, ByVal prmSemana As String, ByVal prmNomina As String, ByVal prmFechaPago As Date) As Boolean

            Dim vParam(3) As Object
            Dim vlSQL As String
            Dim vDs As New DataSet
            Dim DAO As Sistema.DataAccessCls = DataAccessCls.DevuelveInstancia


            vlSQL = "SPINSERTACFDINOMINAEVE"

            vParam(0) = prmTemporada
            vParam(1) = prmSemana
            vParam(2) = prmNomina
            vParam(3) = prmFechaPago

            If Not DAO.RegresaConsultaSQL(vlSQL, vDs, vParam) Then
                Return False
            End If

            Return True
        End Function

        Public Shared Function fgRegresaDatosNomina(ByVal prmTemporada As String, ByVal prmSemana As String, ByVal prmNomina As String) As DataTable

            Dim DTDetalle As New DataTable
            Dim vlSQL As String
            Dim vDs As New DataSet
            Dim DAO As Sistema.DataAccessCls = DataAccessCls.DevuelveInstancia


            vlSQL = "SELECT LEFT(fac.CCVE_EMPL,5) AS cCveEmpl,fac.cRazonSocialCliente AS cNombre,fac.nFactura, " & vbCrLf '=RTRIM(LTRIM(CONVERT(VARCHAR(20),NFACTURA)))+RTRIM(LTRIM(CONVERT(VARCHAR(20),NRFCEMISOR)))," & vbCrLf
            vlSQL = vlSQL & "CASE WHEN fac.UUID IS NOT NULL THEN 'Timbrado previamente' ELSE '' END AS cExitoError, fac.nfolio, fac.uuid, emi.crfc as cRFCEmisor," & vbCrLf
            vlSQL = vlSQL & "CONVERT(BIT,1) AS bSeleccion " & vbCrLf
            vlSQL = vlSQL & "FROM EMPRESAS..FAC_ENCFACTURASCFDINOM fac " & vbCrLf
            vlSQL = vlSQL & "inner join empresas..fac_emisores emi on fac.nRFCEmisor = emi.nRFCEmisor " & vbCrLf
            vlSQL = vlSQL & "WHERE CCVE_TEMPORADA = '" & prmTemporada & "' AND CSEMANA = '" & prmSemana & "' AND CCVE_NOMINA = '" & prmNomina & "'"
            vlSQL = vlSQL & "ORDER BY CCVE_EMPL" & vbCrLf

            DAO.RegresaConsultaSQL(vlSQL, DTDetalle)

            Return DTDetalle

        End Function




    End Class


End Namespace
