Imports Sistema.Comunes.Comun
Imports Sistema.Comunes.Registros.FabricaRegistros

Namespace Comunes.Registros

    Public Class EscribanoRegistros




        Public Shared Function Guardar(ByVal prmFacturas As ClsRegistroFactura) As Boolean

            Dim vParam(49) As Object
            Dim vDs As New DataSet
            Dim vParamDetalle(14) As Object
            Dim vParamTraslados(4) As Object
            Dim vParamRetenciones(4) As Object
            Dim vlSQL As String
            Dim vnRenglon As Integer
            Dim vFolio As String
            Dim DAO As Sistema.DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vFolioGeneralFactura As Integer

            vFolioGeneralFactura = fgObtenFolioGeneralFacturas()
            vFolio = fgObtenFolioSerie(prmFacturas.NSERIE)

            If vFolio = "" Then Return False


            prmFacturas.nFactura = vFolioGeneralFactura
            prmFacturas.FACTURA = vFolio

            vnRenglon = 0

            Try

                vParam(0) = prmFacturas.nFactura
                vParam(1) = prmFacturas.RFCEmisor
                vParam(2) = prmFacturas.SUCURSAL
                vParam(3) = prmFacturas.SERIE
                vParam(4) = prmFacturas.FACTURA
                vParam(5) = prmFacturas.NSERIE
                vParam(6) = prmFacturas.FECHA
                vParam(7) = prmFacturas.Cliente
                vParam(8) = prmFacturas.CCVE_COND
                vParam(9) = prmFacturas.SUBTOTAL
                vParam(10) = prmFacturas.DESCUENTO
                vParam(11) = prmFacturas.SUBTOTALDD
                vParam(12) = prmFacturas.IMPUESTOS
                vParam(13) = prmFacturas.IVARETENIDO
                vParam(14) = prmFacturas.ISRRETENIDO
                vParam(15) = prmFacturas.IMPORTE
                vParam(16) = prmFacturas.CSTATUS
                vParam(17) = prmFacturas.OBSERVACION
                vParam(18) = prmFacturas.CMONEDA
                vParam(19) = prmFacturas.PARIDAD
                vParam(20) = prmFacturas.CTIPODOCUMENTO
                vParam(21) = prmFacturas.CTIPOPAGO
                vParam(22) = prmFacturas.IMPORTECONLETRA
                vParam(23) = prmFacturas.REGIMEN
                vParam(24) = prmFacturas.LUGAREXPEDICION
                vParam(25) = prmFacturas.CCUENTA

                vParam(26) = prmFacturas.ClienteRFC
                vParam(27) = prmFacturas.ClienteDescripcion
                vParam(28) = prmFacturas.ClienteCalle
                vParam(29) = prmFacturas.ClienteNoInt
                vParam(30) = prmFacturas.ClienteNoExt
                vParam(31) = prmFacturas.ClienteColonia
                vParam(32) = prmFacturas.ClienteLocalidad
                vParam(33) = prmFacturas.Referencia1
                vParam(34) = prmFacturas.ClienteCiudad
                vParam(35) = prmFacturas.ClienteEstado
                vParam(36) = prmFacturas.ClientePais
                vParam(37) = prmFacturas.ClienteCodigoPostal
                vParam(38) = prmFacturas.NumeroAprobacion
                vParam(39) = prmFacturas.AnioAprobacion
                vParam(40) = prmFacturas.MetodoPago
                vParam(41) = prmFacturas.Referencia1
                vParam(42) = prmFacturas.Referencia2
                vParam(43) = prmFacturas.Referencia3


                vParam(44) = ""
                vParam(45) = ""
                vParam(46) = ""
                vParam(47) = ""
                vParam(48) = ""

                vParam(49) = prmFacturas.CERTIFICADO


                vlSQL = "Sp_MTTOFAC_ENC"

                If Not DAO.RegresaConsultaSQL(vlSQL, vDs, vParam) Then
                    Return False
                End If


                For Each vRow As DataRow In prmFacturas.DTDetalle.Rows

                    vnRenglon += 1

                    vParam(0) = prmFacturas.nFactura
                    vParam(1) = prmFacturas.RFCEmisor
                    vParam(2) = vnRenglon
                    vParam(3) = vRow("nConcepto")
                    vParam(4) = vRow("cDescripcion")
                    vParam(5) = vRow("nCantidad")
                    vParam(6) = vRow("nPrecio")
                    vParam(7) = vRow("nSubtotal")
                    vParam(8) = IIf(vRow("nDescuento") Is DBNull.Value, 0, vRow("nDescuento"))
                    vParam(9) = IIf(vRow("nSubtotal") Is DBNull.Value, 0, vRow("nSubtotal")) - IIf(vRow("nDescuento") Is DBNull.Value, 0, vRow("nDescuento"))
                    vParam(10) = IIf(vRow("nIVA") Is DBNull.Value, 0, vRow("nIVA"))
                    vParam(11) = IIf(vRow("nImpuestos") Is DBNull.Value, 0, vRow("nImpuestos"))
                    vParam(12) = vRow("nImporte")
                    vParam(13) = vRow("cUnidad")
                    vParam(14) = vRow("cNumeroPredial")

                    vlSQL = "Sp_MTTOFAC_DET"
                    If Not DAO.RegresaConsultaSQL(vlSQL, vDs, vParam) Then
                        Return False
                    End If

                Next

                If Not prmFacturas.DTTraslados Is Nothing AndAlso prmFacturas.DTTraslados.Rows.Count > 0 Then
                    For Each vRow As DataRow In prmFacturas.DTTraslados.Rows

                        vParamTraslados(0) = prmFacturas.nFactura
                        vParamTraslados(1) = prmFacturas.RFCEmisor
                        vParamTraslados(2) = vRow("nTasa")
                        vParamTraslados(3) = vRow("cImpuesto")
                        vParamTraslados(4) = vRow("nImporte")

                        vlSQL = "Sp_MTTOFAC_IMP"
                        If Not DAO.RegresaConsultaSQL(vlSQL, vDs, vParamTraslados) Then
                            Return False
                        End If

                    Next
                End If

                If Not prmFacturas.DTRetenciones Is Nothing AndAlso prmFacturas.DTRetenciones.Rows.Count > 0 Then
                    For Each vRow As DataRow In prmFacturas.DTRetenciones.Rows

                        vParamRetenciones(0) = prmFacturas.nFactura
                        vParamRetenciones(1) = prmFacturas.RFCEmisor
                        vParamRetenciones(2) = vRow("nTasa")
                        vParamRetenciones(3) = vRow("cImpuesto")
                        vParamRetenciones(4) = vRow("nImporte")

                        vlSQL = "Sp_MTTOFAC_RET"
                        If Not DAO.RegresaConsultaSQL(vlSQL, vDs, vParamRetenciones) Then
                            Return False
                        End If

                    Next

                End If




                If Not fgActualizaFolioSerie(prmFacturas.NSERIE) Then
                    Return False
                End If

                fgActualizaFacturaGeneral()


            Catch ex As Exception
                Return False
            End Try

            Return True

        End Function

        Public Shared Function Cancelar(ByVal prmFacturas As ClsRegistroFactura) As Boolean

            Dim vParam(0) As Object
            Dim vlSQL As String
            Dim DS As New DataSet
            Dim DAO As Sistema.DataAccessCls = DataAccessCls.DevuelveInstancia

            Try

                vParam(0) = prmFacturas.nFactura

                vlSQL = "Sp_MTTOFAC_ENC_CANCELA"

                If Not DAO.RegresaConsultaSQL(vlSQL, DS, vParam) Then
                    Return False
                End If

            Catch ex As Exception
                Return False
            End Try

            Return True

        End Function

        Public Shared Function ActualizaDatosTimbrado(ByVal prmFacturas As ClsRegistroFactura) As Boolean

            Dim vParam(3) As Object
            Dim vlSQL As String
            Dim vFolio As String
            Dim DS As New DataSet
            Dim DAO As Sistema.DataAccessCls = DataAccessCls.DevuelveInstancia


            vFolio = prmFacturas.FACTURA
            vFolio = Strings.Right(Strings.StrDup(10, "0") + vFolio, 10)

            Try

                vParam(0) = prmFacturas.nFactura
                vParam(1) = prmFacturas.RFCEmisor
                vParam(2) = prmFacturas.Cadena
                vParam(3) = prmFacturas.Sello

                vlSQL = "Sp_MTTOFAC_ENC_ACTUALIZADATOSTIMBRADO"

                If Not DAO.RegresaConsultaSQL(vlSQL, DS, vParam) Then
                    Return False
                End If

            Catch ex As Exception
                Return False
            End Try

            Return True

        End Function
        Public Shared Function Guardar(ByVal prmFlete As ClsRegistroFlete) As Boolean

            Dim vParam(52) As Object
            Dim vDs As New DataSet
            Dim vlSQL As String
            Dim DAO As Sistema.DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vbActualizaFolio As Boolean = False

            If prmFlete.MovimientoFlete = 0 Then
                prmFlete.MovimientoFlete = fgObtenFolioNuevoFlete()
            End If

            Try

                vParam(0) = prmFlete.Factura
                vParam(1) = prmFlete.MovimientoFlete
                vParam(2) = prmFlete.Ruta
                vParam(3) = prmFlete.OrigenRemitente
                vParam(4) = prmFlete.DestinoDestinatario
                vParam(5) = prmFlete.Kilos
                vParam(6) = prmFlete.FechaCarga
                vParam(7) = prmFlete.FechaEntrega
                vParam(8) = prmFlete.DescripcionCarga
                vParam(9) = prmFlete.Operador
                vParam(10) = prmFlete.Unidad
                vParam(11) = prmFlete.PlacasUnidad
                vParam(12) = prmFlete.Remolque1
                vParam(13) = prmFlete.PlacasRemolque1
                vParam(14) = prmFlete.Dolly
                vParam(15) = prmFlete.Remolque2
                vParam(16) = prmFlete.PlacasRemolque2
                vParam(17) = prmFlete.Observaciones
                vParam(18) = prmFlete.IVAFlete
                vParam(19) = prmFlete.RETFlete
                vParam(20) = prmFlete.IVAManiobras
                vParam(21) = prmFlete.RETManiobras
                vParam(22) = prmFlete.IVARepartos
                vParam(23) = prmFlete.RETRepartos
                vParam(24) = prmFlete.IVARecolectas
                vParam(25) = prmFlete.RETRecolectas
                vParam(26) = prmFlete.IVAAutopistas
                vParam(27) = prmFlete.RETAutopistas
                vParam(28) = prmFlete.IVADemoras
                vParam(29) = prmFlete.RETDemoras
                vParam(30) = prmFlete.IVAOtros
                vParam(31) = prmFlete.RETOtros
                vParam(32) = prmFlete.IVASeguros
                vParam(33) = prmFlete.RETSeguros
                vParam(34) = prmFlete.IVARentas
                vParam(35) = prmFlete.RETRentas
                vParam(36) = prmFlete.PorcentajeIVA
                vParam(37) = prmFlete.PorcentajeRET
                vParam(38) = prmFlete.Flete
                vParam(39) = prmFlete.Maniobras
                vParam(40) = prmFlete.Repartos
                vParam(41) = prmFlete.Recolectas
                vParam(42) = prmFlete.Autopistas
                vParam(43) = prmFlete.Demoras
                vParam(44) = prmFlete.Otros
                vParam(45) = prmFlete.Seguros
                vParam(46) = prmFlete.Rentas
                vParam(47) = prmFlete.Subtotal
                vParam(48) = prmFlete.IVA
                vParam(49) = prmFlete.IVARet
                vParam(50) = prmFlete.Total
                vParam(51) = prmFlete.Bultos
                vParam(52) = prmFlete.Clasificacion

                vlSQL = "SPREGISTRASPV_Fletes"

                If Not DAO.RegresaConsultaSQL(vlSQL, vDs, vParam) Then
                    Return False
                End If

            Catch ex As Exception
                Return False
            End Try

            Return True

        End Function

        Private Shared Function fgObtenFolioNuevoFlete() As Integer
            Dim DAO As Sistema.DataAccessCls = DataAccessCls.DevuelveInstancia
            Try
                fgObtenFolioNuevoFlete = DAO.RegresaDatoSQL("SELECT COALESCE(MAX(nMovimientoFlete),0)+1 AS NFOLIO FROM SPV_Fletes(NOLOCK)")
            Catch ex As Exception
                fgObtenFolioNuevoFlete = 0
            End Try
        End Function



        Public Shared Function ActualizaFechaCancelacion(ByVal prmFacturas As ClsRegistroFactura) As Boolean

            Dim vParam(1) As Object
            Dim vlSQL As String
            Dim DS As New DataSet
            Dim DAO As Sistema.DataAccessCls = DataAccessCls.DevuelveInstancia

            Try

                vParam(0) = prmFacturas.nFactura
                vParam(1) = prmFacturas.RFCEmisor

                vlSQL = "Sp_MTTOFAC_ENC_ACTUALIZACANCELACION"

                If Not DAO.RegresaConsultaSQL(vlSQL, DS, vParam) Then
                    Return False
                End If

            Catch ex As Exception
                Return False
            End Try

            Return True

        End Function


        Private Shared Function fgObtenFolioSerie(ByVal prmSerie As Integer) As Integer
            Dim DAO As Sistema.DataAccessCls = DataAccessCls.DevuelveInstancia
            Try
                fgObtenFolioSerie = DAO.RegresaDatoSQL("SELECT COALESCE(NFOLIOACTUAL,0) AS NFOLIO FROM FAC_SERIES WHERE NSERIE = " & prmSerie)
            Catch ex As Exception
                fgObtenFolioSerie = 0
            End Try
        End Function

        Private Shared Function fgObtenFolioGeneralFacturas() As Integer
            Dim DAO As Sistema.DataAccessCls = DataAccessCls.DevuelveInstancia
            Try
                fgObtenFolioGeneralFacturas = DAO.RegresaDatoSQL("SELECT COALESCE(NFOLIOCFD,0)+1 AS NFOLIO FROM FAC_FOLIOS(NOLOCK)")
            Catch ex As Exception
                fgObtenFolioGeneralFacturas = 0
            End Try
        End Function


        Public Shared Function fgObtenFolioActualSerie(ByVal prmSerie As Integer) As Integer
            Dim DAO As Sistema.DataAccessCls = DataAccessCls.DevuelveInstancia
            Try
                fgObtenFolioActualSerie = DAO.RegresaDatoSQL("SELECT NFOLIOACTUAL-1 FROM FAC_SERIES WHERE NSERIE = " & prmSerie)
            Catch ex As Exception
                fgObtenFolioActualSerie = 0
            End Try
        End Function

        Private Shared Function fgActualizaFolioSerie(ByVal prmSerie As Integer) As Boolean
            Dim DAO As Sistema.DataAccessCls = DataAccessCls.DevuelveInstancia
            Try
                fgActualizaFolioSerie = DAO.EjecutaComandoSQL("UPDATE FAC_SERIES SET NFOLIOACTUAL = NFOLIOACTUAL + 1 WHERE NSERIE = " & prmSerie)
            Catch ex As Exception
                fgActualizaFolioSerie = False
            End Try
        End Function

        Private Shared Function fgActualizaFacturaGeneral() As Boolean
            Dim DAO As Sistema.DataAccessCls = DataAccessCls.DevuelveInstancia
            Try
                fgActualizaFacturaGeneral = DAO.EjecutaComandoSQL("UPDATE FAC_FOLIOS SET NFOLIOCFD = NFOLIOCFD + 1")
            Catch ex As Exception
                fgActualizaFacturaGeneral = False
            End Try
        End Function

        Public Shared Function fgObtenUltimoFolio(ByVal prmSerie As Integer) As Integer
            Dim DAO As Sistema.DataAccessCls = DataAccessCls.DevuelveInstancia
            Try
                fgObtenUltimoFolio = DAO.RegresaDatoSQL("SELECT NFOLIOFINAL FROM FAC_SERIES WHERE NSERIE = " & prmSerie)
            Catch ex As Exception
                fgObtenUltimoFolio = 0
            End Try
        End Function

        Public Shared Function fgObtenParametrosGenerales(ByVal prmRFC As Integer, ByVal prmSERIE As Integer) As DataTable

            Dim DT As New DataTable
            Dim vcSQL As String
            Dim DAO As Sistema.DataAccessCls = DataAccessCls.DevuelveInstancia

            vcSQL = "SELECT cClavePar,cValorPar FROM FAC_PARAMETROS"
            vcSQL = vcSQL & vbCrLf & "WHERE NRFCEMISOR = " & prmRFC & " AND NSERIE = " & prmSERIE

            DAO.RegresaConsultaSQL(vcSQL, DT)
            Return DT

        End Function

        Public Shared Function fgGrabaParametrosGenerales(ByVal prmDataTable As DataTable, ByVal prmRFC As Integer, ByVal prmSERIE As Integer) As Boolean

            Dim DAO As Sistema.DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vcSQL As String
            Try


                If Not prmDataTable Is Nothing AndAlso prmDataTable.Rows.Count > 0 Then

                    For Each vRow As DataRow In prmDataTable.Rows

                        vcSQL = "UPDATE FAC_PARAMETROS SET CVALORPAR = '" & vRow("CVALORPAR") & "' WHERE CCLAVEPAR = '" & vRow("CCLAVEPAR") & "'"
                        vcSQL = vcSQL & vbCrLf & "AND NRFCEMISOR = " & prmRFC & " AND NSERIE = " & prmSERIE

                        DAO.EjecutaComandoSQL(vcSQL)
                    Next

                End If

                Return True
            Catch ex As Exception
                Return False
            End Try


        End Function

        Public Shared Function fgObtenReporteMensualSAT(ByVal prmRFC As Integer, ByVal prmEjercicio As Integer, ByVal prmPeriodo As Integer) As DataTable

            Dim DT As New DataTable
            Dim vcSQL As String
            Dim DAO As Sistema.DataAccessCls = DataAccessCls.DevuelveInstancia

            vcSQL = "SELECT REPLACE(REPLACE(FE.CRFCCLIENTE,' ',''),'-','') AS CRFCCLIENTE,FE.CSERIE AS CSERIEEMISOR,FE.NFOLIO AS NFACTURA,FO.NANIOAUTORIZACION AS NANIO,"
            vcSQL = vcSQL & vbCrLf & "FO.NNUMEROAUTORIZACION,FE.NIMPORTE AS NTOTAL,FE.NIMPUESTOS AS NIVA,FE.CSTATUS,"
            vcSQL = vcSQL & vbCrLf & "SUBSTRING(CONVERT(VARCHAR(10),FE.DFECHA,103),1,6) + CONVERT(CHAR(4),YEAR(FE.DFECHA)) + ' ' + CONVERT(VARCHAR(8),FE.DFECHA,108) AS FechaFormato,"
            vcSQL = vcSQL & vbCrLf & "CASE WHEN FE.CTIPODOCUMENTO = 'F' THEN 'I' ELSE 'E' END AS CEFECTO"
            vcSQL = vcSQL & vbCrLf & "FROM FAC_ENCFACTURAS FE(NOLOCK) "
            vcSQL = vcSQL & vbCrLf & "INNER JOIN FAC_EMISORES EM(Nolock) ON (FE.NRFCEMISOR = EM.NRFCEMISOR) "
            vcSQL = vcSQL & vbCrLf & "INNER JOIN FAC_SERIES FO(nolock) ON (FE.NRFCEMISOR = FO.NRFCEMISOR AND FE.NSERIE = FO.NSERIE) "
            vcSQL = vcSQL & vbCrLf & "WHERE FE.NRFCEMISOR = " & prmRFC & " AND YEAR(FE.DFECHA) = " & prmEjercicio & " AND MONTH(FE.DFECHA) = " & prmPeriodo

            DAO.RegresaConsultaSQL(vcSQL, DT)
            Return DT

        End Function




    End Class
End Namespace

