Namespace Comunes.Comun.Parametros
    Public Class ClsParametrosSucursal
        Private atrParametroCanalDistribucion As Comunes.Comun.ClsParametro
        Private atrParametroMonedaOperacion As Comunes.Comun.ClsParametro
        Private atrParametroMonedaOperacionSecundaria As Comunes.Comun.ClsParametro
        Private atrParametroUnidadOperacion As Comunes.Comun.ClsParametro
        Private atrParametroUnidadOperacionSecundaria As Comunes.Comun.ClsParametro
        Private atrParametroPorcentajePesoCaja As Comunes.Comun.ClsParametro
        Private atrParametroDiaEnQueEmpiezaLaSemana As Comunes.Comun.ClsParametro
        Private atrParametroIngresarSinConciliacion As Comunes.Comun.ClsParametro
        Private atrParametroMaximoVentasSuspendidas As Comunes.Comun.ClsParametro
        Private atrParametroIVA As Comunes.Comun.ClsParametro
        Private atrParametroSerieFacturacion As Comunes.Comun.ClsParametro
        Private atrParametroIncluirCajasConCondicion As Comunes.Comun.ClsParametro
        Private atrParametroPermiteApartarSinExistencias As Comunes.Comun.ClsParametro
        Private atrParametroIncluirInvTtoComoDisponible As Comunes.Comun.ClsParametro
        Private atrParametroDiasVigenciaVales As Comunes.Comun.ClsParametro
        Private atrParametroImprimeIva As Comunes.Comun.ClsParametro

        Private atrParametroPedidosTelemarketing As Comunes.Comun.ClsParametro
        Private atrParametroCanalVirtual As Comunes.Comun.ClsParametro
        Private atrParametroCanalSurte As Comunes.Comun.ClsParametro

        Private atrParametroImporteXPunto As Comunes.Comun.ClsParametro

        Private atrPrecioProductosConIva As Comunes.Comun.ClsParametro
        Private atrPrecioServiciosConIva As Comunes.Comun.ClsParametro
        Private atrRutaArchivosTemporales As Comunes.Comun.ClsParametro

        Private atrRutaImpresoraFacturas As ImpresionReportes.ImpresionReportes.cls_Imp_Impresora
        Private atrRutaImpresoraTickets As ImpresionReportes.ImpresionReportes.cls_Imp_Impresora

        'Agrega ruta para imprimir facturas de SuKarne MM
        'LI. Aldo Manuel Sánz Castro 12/01/2008 10:36 a.m.
        Private atrRutaImpresoraFacturasMM As ImpresionReportes.ImpresionReportes.cls_Imp_Impresora

        Public Property ImpresoraFacturas() As ImpresionReportes.ImpresionReportes.cls_Imp_Impresora
            Get
                Return atrRutaImpresoraFacturas
            End Get
            Set(ByVal Value As ImpresionReportes.ImpresionReportes.cls_Imp_Impresora)
                atrRutaImpresoraFacturas = Value
            End Set
        End Property

        'Agrega ruta para imprimir facturas de SuKarne MM
        'LI. Aldo Manuel Sánz Castro 12/01/2008 10:36 a.m.
        Public Property ImpresoraFacturasMM() As ImpresionReportes.ImpresionReportes.cls_Imp_Impresora
            Get
                Return atrRutaImpresoraFacturasMM
            End Get
            Set(ByVal Value As ImpresionReportes.ImpresionReportes.cls_Imp_Impresora)
                atrRutaImpresoraFacturasMM = Value
            End Set
        End Property

        Public Property ImpresoraTickets() As ImpresionReportes.ImpresionReportes.cls_Imp_Impresora
            Get
                Return atrRutaImpresoraTickets
            End Get
            Set(ByVal Value As ImpresionReportes.ImpresionReportes.cls_Imp_Impresora)
                atrRutaImpresoraTickets = Value
            End Set
        End Property

        Public Property ParametroRutaArchivosTemporales() As Comunes.Comun.ClsParametro
            Get
                Return atrRutaArchivosTemporales
            End Get
            Set(ByVal Value As Comunes.Comun.ClsParametro)
                atrRutaArchivosTemporales = Value
            End Set
        End Property

        Public Property ParametroImporteXPunto() As Comunes.Comun.ClsParametro
            Get
                Return atrParametroImporteXPunto
            End Get
            Set(ByVal Value As Comunes.Comun.ClsParametro)
                atrParametroImporteXPunto = Value
            End Set
        End Property

        Public Property ParametroImprimeIva() As Comunes.Comun.ClsParametro
            Get
                Return atrParametroImprimeIva
            End Get
            Set(ByVal Value As Comunes.Comun.ClsParametro)
                atrParametroImprimeIva = Value
            End Set
        End Property

        Public Property ParametroDiasVigenciaVales() As Comunes.Comun.ClsParametro
            Get
                Return atrParametroDiasVigenciaVales
            End Get
            Set(ByVal Value As Comunes.Comun.ClsParametro)
                atrParametroDiasVigenciaVales = Value
            End Set
        End Property

        Public Property ParametroPedidosTelemarketing() As Comunes.Comun.ClsParametro
            Get
                Return atrParametroPedidosTelemarketing
            End Get
            Set(ByVal Value As Comunes.Comun.ClsParametro)
                atrParametroPedidosTelemarketing = Value
            End Set
        End Property

        Public Property ParametroCanalVirtual() As Comunes.Comun.ClsParametro
            Get
                Return atrParametroCanalVirtual
            End Get
            Set(ByVal Value As Comunes.Comun.ClsParametro)
                atrParametroCanalVirtual = Value
            End Set
        End Property

        Public Property ParametroCanalSurte() As Comunes.Comun.ClsParametro
            Get
                Return atrParametroCanalSurte
            End Get
            Set(ByVal Value As Comunes.Comun.ClsParametro)
                atrParametroCanalSurte = Value
            End Set
        End Property

        ''Este es porcentaje de  variacion  en el peso que se le asigna a una caja por canal de distribucion
        Public Property ParametroPorcentajePesoCaja() As Comunes.Comun.ClsParametro
            Get
                Return atrParametroPorcentajePesoCaja
            End Get
            Set(ByVal Value As Comunes.Comun.ClsParametro)
                atrParametroPorcentajePesoCaja = Value
            End Set
        End Property

        Public Property ParametroCanalDistribucion() As Comunes.Comun.ClsParametro
            Get
                Return atrParametroCanalDistribucion
            End Get
            Set(ByVal Value As Comunes.Comun.ClsParametro)
                atrParametroCanalDistribucion = Value
            End Set
        End Property

        Public Property ParametroMonedaOperacion() As Comunes.Comun.ClsParametro
            Get
                Return atrParametroMonedaOperacion
            End Get
            Set(ByVal Value As Comunes.Comun.ClsParametro)
                atrParametroMonedaOperacion = Value
            End Set
        End Property

        Public Property ParametroMonedaOperacionSecundaria() As Comunes.Comun.ClsParametro
            Get
                Return atrParametroMonedaOperacionSecundaria
            End Get
            Set(ByVal Value As Comunes.Comun.ClsParametro)
                atrParametroMonedaOperacionSecundaria = Value
            End Set
        End Property

        Public Property ParametroDiaEnQueEmpiezaLaSemana() As Comunes.Comun.ClsParametro
            Get
                Return atrParametroDiaEnQueEmpiezaLaSemana
            End Get
            Set(ByVal Value As Comunes.Comun.ClsParametro)
                atrParametroDiaEnQueEmpiezaLaSemana = Value
            End Set
        End Property

        Public Property ParametroUnidadOperacion() As Comunes.Comun.ClsParametro
            Get
                Return atrParametroUnidadOperacion
            End Get
            Set(ByVal Value As Comunes.Comun.ClsParametro)
                atrParametroUnidadOperacion = Value
            End Set
        End Property

        Public Property ParametroUnidadOperacionSecundaria() As Comunes.Comun.ClsParametro
            Get
                Return atrParametroUnidadOperacionSecundaria
            End Get
            Set(ByVal Value As Comunes.Comun.ClsParametro)
                atrParametroUnidadOperacionSecundaria = Value
            End Set
        End Property

        Public Property ParametroIngresarSinConciliacion() As Comunes.Comun.ClsParametro
            Get
                Return atrParametroIngresarSinConciliacion
            End Get
            Set(ByVal Value As Comunes.Comun.ClsParametro)
                atrParametroIngresarSinConciliacion = Value
            End Set
        End Property

        Public Property ParametroMaximoVentasSuspendidas() As Comunes.Comun.ClsParametro
            Get
                Return atrParametroMaximoVentasSuspendidas
            End Get
            Set(ByVal Value As Comunes.Comun.ClsParametro)
                atrParametroMaximoVentasSuspendidas = Value
            End Set
        End Property

        Public Property ParametroIVA() As Comunes.Comun.ClsParametro
            Get
                Return atrParametroIVA
            End Get
            Set(ByVal Value As Comunes.Comun.ClsParametro)
                atrParametroIVA = Value
            End Set
        End Property

        Public Property ParametroSerieFacturacion() As Comunes.Comun.ClsParametro
            Get
                Return atrParametroSerieFacturacion
            End Get
            Set(ByVal Value As Comunes.Comun.ClsParametro)
                atrParametroSerieFacturacion = Value
            End Set
        End Property

        Public Property ParametroIncluirCajasConCondicion() As Comunes.Comun.ClsParametro
            Get
                Return atrParametroIncluirCajasConCondicion
            End Get
            Set(ByVal Value As Comunes.Comun.ClsParametro)
                atrParametroIncluirCajasConCondicion = Value
            End Set
        End Property

        Public Property ParametroPermiteApartarSinexistencias() As Comunes.Comun.ClsParametro
            Get
                Return atrParametroPermiteApartarSinExistencias
            End Get
            Set(ByVal Value As Comunes.Comun.ClsParametro)
                atrParametroPermiteApartarSinExistencias = Value
            End Set
        End Property

        Public Property ParametroIncluirInvTtoComoDisponible() As Comunes.Comun.ClsParametro
            Get
                Return atrParametroIncluirInvTtoComoDisponible
            End Get
            Set(ByVal Value As Comunes.Comun.ClsParametro)
                atrParametroIncluirInvTtoComoDisponible = Value
            End Set
        End Property

        Public Property ParametroPrecioProductosConIva() As Comunes.Comun.ClsParametro
            Get
                Return atrPrecioProductosConIva
            End Get
            Set(ByVal Value As Comunes.Comun.ClsParametro)
                atrPrecioProductosConIva = Value
            End Set
        End Property

        Public Property ParametroPrecioServiciosConIva() As Comunes.Comun.ClsParametro
            Get
                Return atrPrecioServiciosConIva
            End Get
            Set(ByVal Value As Comunes.Comun.ClsParametro)
                atrPrecioServiciosConIva = Value
            End Set
        End Property


        Public Function RutaArchivosTemporales() As String
            Return atrRutaArchivosTemporales.Valor.ToString()
        End Function

        Public Function CanalParaTelemarketing() As Boolean
            Return atrParametroPedidosTelemarketing.Valor
        End Function

        Public Function Canal_Virtual() As Boolean
            Return atrParametroCanalVirtual.Valor
        End Function

        Public Function CanalSurte() As Int16
            Return atrParametroCanalSurte.Valor
        End Function

        Public Function SerieFacturacion() As String
            Return atrParametroSerieFacturacion.Valor.ToString()
        End Function

        Public Function IVA() As Integer
            Return CInt(atrParametroIVA.Valor)
        End Function

        Public Function MaximoVentasSuspendidas() As Integer
            Return CInt(atrParametroMaximoVentasSuspendidas.Valor)
        End Function

        Public Function CanalDistribucion() As Integer
            Return Val(atrParametroCanalDistribucion.Valor)
        End Function

        Public Function MonedaOperacion() As Integer
            Return atrParametroMonedaOperacion.Valor
        End Function

        Public Function MonedaOperacionSecundaria() As Integer
            Return ParametroMonedaOperacionSecundaria.Valor
        End Function

        Public Function ImporteXPunto() As Double
            Return Val(atrParametroImporteXPunto.Valor)
        End Function


        Public Function UnidadDeOperacion() As Integer
            Return atrParametroUnidadOperacion.Valor
        End Function

        Public Function UnidadDeOperacionSecundaria() As Integer
            Return atrParametroUnidadOperacionSecundaria.Valor
        End Function

        Public Function PorcentajePesoCaja() As Double
            Return atrParametroPorcentajePesoCaja.Valor
        End Function

        Public Function IngresarSinConciliacion() As Boolean
            Return atrParametroIngresarSinConciliacion.Valor
        End Function

        Public Function IncluirCajasConCondicion() As Boolean
            Return atrParametroIncluirCajasConCondicion.Valor
        End Function

        Public Function PermiteApartarSinexistencias() As Boolean
            Return atrParametroPermiteApartarSinExistencias.Valor
        End Function

        Public Function IncluirInvTtoComoDisponible() As Boolean
            Return atrParametroIncluirInvTtoComoDisponible.Valor
        End Function

        Public Function getDiasVigenciaVales_Value() As Integer
            getDiasVigenciaVales_Value = CInt(atrParametroDiasVigenciaVales.Valor)
        End Function

        Public Function getImprimeIva_Value() As Boolean
            getImprimeIva_Value = CBool(atrParametroImprimeIva.Valor)
        End Function

        Public Function PrecioProductosConIva() As Boolean
            Return CBool(atrPrecioProductosConIva.Valor)
        End Function

        Public Function PrecioServiciosConIva() As Boolean
            Return CBool(atrPrecioServiciosConIva.Valor)
        End Function



    End Class ' ClsParametrosSucursal

    Public Class clsParametrosArchivoPlano
        Private atrRutaArchivosFacturasCompras As Comunes.Comun.ClsParametroValorPredefinido
        Private atrNombreArchivoFacturasCompras As Comunes.Comun.ClsParametroValorPredefinido
        Private atrRutaArchivosHistorialFacturasCompras As Comunes.Comun.ClsParametroValorPredefinido


        Public Property RutaArchivosHistorialFacturasCompras() As Comunes.Comun.ClsParametroValorPredefinido
            Get
                Return atrRutaArchivosHistorialFacturasCompras
            End Get
            Set(ByVal Value As Comunes.Comun.ClsParametroValorPredefinido)
                atrRutaArchivosHistorialFacturasCompras = Value
            End Set
        End Property

        Public Property RutaArchivosFacturasCompras() As Comunes.Comun.ClsParametroValorPredefinido
            Get
                Return atrRutaArchivosFacturasCompras
            End Get
            Set(ByVal Value As Comunes.Comun.ClsParametroValorPredefinido)
                atrRutaArchivosFacturasCompras = Value
            End Set
        End Property

        Public Property NombreArchivoFacturasCompras() As Comunes.Comun.ClsParametroValorPredefinido
            Get
                Return atrNombreArchivoFacturasCompras
            End Get
            Set(ByVal Value As Comunes.Comun.ClsParametroValorPredefinido)
                atrNombreArchivoFacturasCompras = Value
            End Set
        End Property

        Public Function getNombreNombreArchivoFacturasCompras() As String
            getNombreNombreArchivoFacturasCompras = atrNombreArchivoFacturasCompras.Valor.ToString()
        End Function

        Public Function getRutaArchivosFacturasCompras_Value() As String
            getRutaArchivosFacturasCompras_Value = CStr(atrRutaArchivosFacturasCompras.Valor) & IIf(CStr(atrRutaArchivosFacturasCompras.Valor).EndsWith("\"), "", "\")
        End Function

        Public Function getRutaArchivosHistorialFacturasCompras_Value() As String
            getRutaArchivosHistorialFacturasCompras_Value = CStr(atrRutaArchivosHistorialFacturasCompras.Valor) & IIf(CStr(atrRutaArchivosHistorialFacturasCompras.Valor).EndsWith("\"), "", "\")
        End Function

#Region "Constructor"
        Public Sub New()
        End Sub
#End Region


    End Class  'ClsParametrosArchivoPlano

    Public Class ClsParametrosTerminal


        Private atrParametroAlmacen As ClsParametroIni
        Private atrParametroCaja As ClsParametroIni
        Private atrParametroImprimirTicket As ClsParametroIni
        Private atrParametroTipoRegistroCompraCredito As ClsParametroIni
        Private atrParametroAlmacenAlQueSePide As ClsParametroIni
        Private atrParametroAlmacenAlQueSePidePermiteModificar As ClsParametroIni
        Private atrParametroPermiteImprimirPedido As ClsParametroIni
        Private atrParametroAlmacenAlQueSeSolicita As ClsParametroIni
        Private atrParametroAlmacenAlQueSeSolicitaPermiteModificar As ClsParametroIni
        Private atrParametroPermiteImprimirSolicitud As ClsParametroIni
        Private atrParametroAlmacenAlQueSeTraspasa As ClsParametroIni
        Private atrParametroAlmacenAlQueSeTraspasaPermiteModificar As ClsParametroIni
        Private atrParametroPermiteImprimirSalidaPorTraspaso As ClsParametroIni
        Private atrParametroPermiteImprimirSurtidoDePedido As ClsParametroIni
        Private atrParametroPermiteImprimirSalidaPorDevolucion As ClsParametroIni
        Private atrParametroPermiteImprimirRecepcionDePedido As ClsParametroIni
        Private atrParametroPermiteImprimirEntradaPorTraspaso As ClsParametroIni
        Private atrParametroPermiteImprimirEntradaPorDevolucion As ClsParametroIni
        Private atrParametroAlmacenAlQueSeDevuelve As ClsParametroIni
        Private atrParametroAlmacenAlQueSeDevuelvePermiteModificar As ClsParametroIni
        Private atrParametroPermiteRegistroDocumentosContado As ClsParametroIni
        Private atrParametroPermiteRegistroDocumentosCredito As ClsParametroIni
        Private atrParametroPermiteRegistroDocumentosCreditoCompleto As ClsParametroIni
        Private atrParametroIntervaloAlertas As ClsParametroIni
        Private atrParametroBloqueoInactividad As ClsParametroIni
        Private atrParametroAlmacenDefaulPermiteModificar As ClsParametroIni
        Private atrParametroContextoInicial As ClsParametroIni

        'Parametros de produccion
        Private atrParametroProAlmacenMovimiento As ClsParametroIni
        Private atrParametroProAlmacenDefaulMovimientoPermiteModificar As ClsParametroIni
        Private atrParametroProAlmacenAlQueSePide As ClsParametroIni
        Private atrParametroProAlmacenAlQueSePidePermiteModificar As ClsParametroIni
        Private atrParametroProAlmacenAlQueSeSolicitaTraspaso As ClsParametroIni
        Private atrParametroProAlmacenAlQueSeSolicitaTraspasoPermiteModificar As ClsParametroIni
        Private atrParametroProAlmacenAlQueSeTraspasa As ClsParametroIni
        Private atrParametroProAlmacenAlQueSeTraspasaPermiteModificar As ClsParametroIni
        Private atrParametroProAlmacenAlQueDevuelve As ClsParametroIni
        Private atrParametroProAlmacenAlQueDevuelvePermiteModificar As ClsParametroIni
        Private atrParametroProPermiteModificarFechaMovimiento As ClsParametroIni
        Private atrParametroProPermiteImprimirPedido As ClsParametroIni
        Private atrParametroProPermiteImprimirSuministro As ClsParametroIni
        Private atrParametroProPermiteImprimirRecepcionDeSuministro As ClsParametroIni
        Private atrParametroProPermiteImprimirSolicitudDeTraspaso As ClsParametroIni
        Private atrParametroProPermiteImprimirSalidaPorTraspaso As ClsParametroIni
        Private atrParametroProPermiteImprimirSalidaPorDevolucion As ClsParametroIni
        Private atrParametroProPermiteImprimirEntradaPorTraspaso As ClsParametroIni
        Private atrParametroProPermiteImprimirEntradaPorDevolucion As ClsParametroIni
        Private atrParametroProPermiteImprimirMovimientosGenerales As ClsParametroIni
        Private atrParametroProImpresoraTicket As ClsParametroIni
        Private atrParametroProImprimePideConfirmacion As ClsParametroIni
        Private atrParamtroProImprimeSolicitudDevolucion As ClsParametroIni
        Private atrParametroImpresoraTicketPlantillaExpress As ClsParametroIni
        Private atrParametroNumeroCopiasTicketContrarecibos As ClsParametroIni
        Private atrParametroCodigoBarraIncorrectoAfectaGenerico As ClsParametroIni
        Private atrParametroPErmiteCapturaPedidoEspecialASIC As ClsParametroIni
        Private atrParametroNumeroCopiasTicketProduccionDistribucion As ClsParametroIni

        Public Property ParametroPermiteCapturaCodigoEspecialASic() As ClsParametroIni
            Get
                Return atrParametroPErmiteCapturaPedidoEspecialASIC
            End Get
            Set(ByVal value As ClsParametroIni)
                atrParametroPErmiteCapturaPedidoEspecialASIC = value
            End Set
        End Property
        Public Property ParametroCodigoBarraNoValidadoAfectaGenerico() As ClsParametroIni
            Get
                Return atrParametroCodigoBarraIncorrectoAfectaGenerico
            End Get
            Set(ByVal value As ClsParametroIni)
                atrParametroCodigoBarraIncorrectoAfectaGenerico = value
            End Set
        End Property
        Public Property ParametroNumeroCopiasTicketContrarecibos() As ClsParametroIni
            Get
                Return atrParametroNumeroCopiasTicketContrarecibos
            End Get
            Set(ByVal value As ClsParametroIni)
                atrParametroNumeroCopiasTicketContrarecibos = value
            End Set
        End Property

        Public Property ParametroNumeroCopiasTicketProduccionDistribucion() As ClsParametroIni
            Get
                Return atrParametroNumeroCopiasTicketProduccionDistribucion
            End Get
            Set(ByVal value As ClsParametroIni)
                atrParametroNumeroCopiasTicketProduccionDistribucion = value
            End Set
        End Property
        Public Property ParametroImpresoraTicketPlantillaExpress() As ClsParametroIni
            Get
                Return atrParametroImpresoraTicketPlantillaExpress
            End Get
            Set(ByVal value As ClsParametroIni)
                atrParametroImpresoraTicketPlantillaExpress = value
            End Set
        End Property

        Public Property ParamtroProImprimeSolicitudDevolucion() As ClsParametroIni
            Get
                Return atrParamtroProImprimeSolicitudDevolucion
            End Get
            Set(ByVal value As ClsParametroIni)
                atrParamtroProImprimeSolicitudDevolucion = value
            End Set
        End Property


        Public Property ParametroProImprimePideConfirmacion() As ClsParametroIni
            Get
                Return atrParametroProImprimePideConfirmacion
            End Get
            Set(ByVal value As ClsParametroIni)
                atrParametroProImprimePideConfirmacion = value
            End Set
        End Property

        Public Property ParametroProAlmacenMovimiento() As ClsParametroIni
            Get
                Return atrParametroProAlmacenMovimiento
            End Get
            Set(ByVal value As ClsParametroIni)
                atrParametroProAlmacenMovimiento = value
            End Set
        End Property

        Public Property ParametroProAlmacenDefaulMovimientoPermiteModificar() As ClsParametroIni
            Get
                Return atrParametroProAlmacenDefaulMovimientoPermiteModificar
            End Get
            Set(ByVal value As ClsParametroIni)
                atrParametroProAlmacenDefaulMovimientoPermiteModificar = value
            End Set
        End Property

        Public Property ParametroProAlmacenAlQueSePide() As ClsParametroIni
            Get
                Return atrParametroProAlmacenAlQueSePide
            End Get
            Set(ByVal value As ClsParametroIni)
                atrParametroProAlmacenAlQueSePide = value
            End Set
        End Property
        Public Property ParametroProAlmacenAlQueSePidePermiteModificar() As ClsParametroIni
            Get
                Return atrParametroProAlmacenAlQueSePidePermiteModificar
            End Get
            Set(ByVal value As ClsParametroIni)
                atrParametroProAlmacenAlQueSePidePermiteModificar = value
            End Set
        End Property
        Public Property ParametroProAlmacenAlQueSeSolicitaTraspaso() As ClsParametroIni
            Get
                Return atrParametroProAlmacenAlQueSeSolicitaTraspaso
            End Get
            Set(ByVal value As ClsParametroIni)
                atrParametroProAlmacenAlQueSeSolicitaTraspaso = value
            End Set
        End Property
        Public Property ParametroProAlmacenAlQueSeSolicitaTraspasoPermiteModificar() As ClsParametroIni
            Get
                Return atrParametroProAlmacenAlQueSeSolicitaTraspasoPermiteModificar
            End Get
            Set(ByVal value As ClsParametroIni)
                atrParametroProAlmacenAlQueSeSolicitaTraspasoPermiteModificar = value
            End Set
        End Property

        Public Property ParametroProAlmacenAlQueSeTraspasa() As ClsParametroIni
            Get
                Return atrParametroProAlmacenAlQueSeTraspasa
            End Get
            Set(ByVal value As ClsParametroIni)
                atrParametroProAlmacenAlQueSeTraspasa = value
            End Set
        End Property

        Public Property ParametroProAlmacenAlQueSeTraspasaPermiteModificar() As ClsParametroIni
            Get
                Return atrParametroProAlmacenAlQueSeTraspasaPermiteModificar
            End Get
            Set(ByVal value As ClsParametroIni)
                atrParametroProAlmacenAlQueSeTraspasaPermiteModificar = value
            End Set
        End Property

        Public Property ParametroProAlmacenAlQueDevuelve() As ClsParametroIni
            Get
                Return atrParametroProAlmacenAlQueDevuelve
            End Get
            Set(ByVal value As ClsParametroIni)
                atrParametroProAlmacenAlQueDevuelve = value
            End Set
        End Property

        Public Property ParametroProAlmacenAlQueDevuelvePermiteModificar() As ClsParametroIni
            Get
                Return atrParametroProAlmacenAlQueDevuelvePermiteModificar
            End Get
            Set(ByVal value As ClsParametroIni)
                atrParametroProAlmacenAlQueDevuelvePermiteModificar = value
            End Set
        End Property
        Public Property ParametroProPermiteModificarFechaMovimiento() As ClsParametroIni
            Get
                Return atrParametroProPermiteModificarFechaMovimiento
            End Get
            Set(ByVal value As ClsParametroIni)
                atrParametroProPermiteModificarFechaMovimiento = value
            End Set
        End Property

        Public Property ParametroProPermiteImprimirPedido() As ClsParametroIni
            Get
                Return atrParametroProPermiteImprimirPedido
            End Get
            Set(ByVal value As ClsParametroIni)
                atrParametroProPermiteImprimirPedido = value
            End Set
        End Property

        Public Property ParametroProPermiteImprimirSuministro() As ClsParametroIni
            Get
                Return atrParametroProPermiteImprimirSuministro
            End Get
            Set(ByVal value As ClsParametroIni)
                atrParametroProPermiteImprimirSuministro = value
            End Set
        End Property

        Public Property ParametroProPermiteImprimirRecepcionDeSuministro() As ClsParametroIni
            Get
                Return atrParametroProPermiteImprimirRecepcionDeSuministro
            End Get
            Set(ByVal value As ClsParametroIni)
                atrParametroProPermiteImprimirRecepcionDeSuministro = value
            End Set
        End Property


        Public Property ParametroProPermiteImprimirSolicitudDeTraspaso() As ClsParametroIni
            Get
                Return atrParametroProPermiteImprimirSolicitudDeTraspaso
            End Get
            Set(ByVal value As ClsParametroIni)
                atrParametroProPermiteImprimirSolicitudDeTraspaso = value
            End Set
        End Property


        Public Property ParametroProPermiteImprimirSalidaPorTraspaso() As ClsParametroIni
            Get
                Return atrParametroProPermiteImprimirSalidaPorTraspaso
            End Get
            Set(ByVal value As ClsParametroIni)
                atrParametroProPermiteImprimirSalidaPorTraspaso = value
            End Set
        End Property

        Public Property ParametroProPermiteImprimirEntradaPorDevolucion() As ClsParametroIni
            Get
                Return atrParametroProPermiteImprimirEntradaPorDevolucion
            End Get
            Set(ByVal value As ClsParametroIni)
                atrParametroProPermiteImprimirEntradaPorDevolucion = value
            End Set
        End Property
        Public Property ParametroProPermiteImprimirMovimientosGenerales() As ClsParametroIni
            Get
                Return atrParametroProPermiteImprimirMovimientosGenerales
            End Get
            Set(ByVal value As ClsParametroIni)
                atrParametroProPermiteImprimirMovimientosGenerales = value
            End Set
        End Property

        Public Property ParametroProImpresoraTicket() As ClsParametroIni
            Get
                Return atrParametroProImpresoraTicket
            End Get
            Set(ByVal value As ClsParametroIni)
                atrParametroProImpresoraTicket = value
            End Set
        End Property



        Public Property ParametroContextoInicial() As ClsParametroIni
            Get
                Return atrParametroContextoInicial
            End Get
            Set(ByVal value As ClsParametroIni)
                atrParametroContextoInicial = value
            End Set
        End Property

        Public Property ParametroAlmacenDefaulPermiteModificar() As ClsParametroIni
            Get
                Return atrParametroAlmacenDefaulPermiteModificar
            End Get
            Set(ByVal value As ClsParametroIni)
                atrParametroAlmacenDefaulPermiteModificar = value
            End Set
        End Property

        Public Property ParametroPermiteRegistroDocumentosContado() As ClsParametroIni
            Get
                Return atrParametroPermiteRegistroDocumentosContado
            End Get
            Set(ByVal value As ClsParametroIni)
                atrParametroPermiteRegistroDocumentosContado = value
            End Set
        End Property

        Public Property ParametroPermiteRegistroDocumentosCredito() As ClsParametroIni
            Get
                Return atrParametroPermiteRegistroDocumentosCredito
            End Get
            Set(ByVal value As ClsParametroIni)
                atrParametroPermiteRegistroDocumentosCredito = value
            End Set
        End Property

        Public Property ParametroPermiteRegistroDocumentosCreditoCompleto() As ClsParametroIni
            Get
                Return atrParametroPermiteRegistroDocumentosCreditoCompleto
            End Get
            Set(ByVal value As ClsParametroIni)
                atrParametroPermiteRegistroDocumentosCreditoCompleto = value
            End Set
        End Property

        Public Property ParametroCaja() As ClsParametroIni
            Get
                Return atrParametroCaja
            End Get
            Set(ByVal Value As ClsParametroIni)
                atrParametroCaja = Value
            End Set
        End Property

        Public Property ParametroAlmacen() As ClsParametroIni
            Get
                Return atrParametroAlmacen
            End Get
            Set(ByVal Value As ClsParametroIni)
                atrParametroAlmacen = Value
            End Set
        End Property

        Public Property ParametroTipoRegistroCompraCredito() As ClsParametroIni
            Get
                Return atrParametroTipoRegistroCompraCredito
            End Get
            Set(ByVal value As ClsParametroIni)
                atrParametroTipoRegistroCompraCredito = value
            End Set
        End Property

        Public Property ParametroImprimirTicket() As ClsParametroIni
            Get
                Return atrParametroImprimirTicket
            End Get
            Set(ByVal value As ClsParametroIni)
                atrParametroImprimirTicket = value
            End Set
        End Property

        Public Property ParametroAlmacenAlQueSePide() As ClsParametroIni
            Get
                Return atrParametroAlmacenAlQueSePide
            End Get
            Set(ByVal value As ClsParametroIni)
                atrParametroAlmacenAlQueSePide = value
            End Set
        End Property

        Public Property ParametroAlmacenAlQueSePidePermiteModificar() As ClsParametroIni
            Get
                Return atrParametroAlmacenAlQueSePidePermiteModificar
            End Get
            Set(ByVal value As ClsParametroIni)
                atrParametroAlmacenAlQueSePidePermiteModificar = value
            End Set
        End Property

        Public Property ParametroPermiteImprimirPedido() As ClsParametroIni
            Get
                Return atrParametroPermiteImprimirPedido
            End Get
            Set(ByVal value As ClsParametroIni)
                atrParametroPermiteImprimirPedido = value
            End Set
        End Property

        Public Property ParametroAlmacenAlQueSeSolicita() As ClsParametroIni
            Get
                Return atrParametroAlmacenAlQueSeSolicita
            End Get
            Set(ByVal value As ClsParametroIni)
                atrParametroAlmacenAlQueSeSolicita = value
            End Set
        End Property

        Public Property ParametroAlmacenAlQueSeSolicitaPermiteModifcar() As ClsParametroIni
            Get
                Return atrParametroAlmacenAlQueSeSolicitaPermiteModificar
            End Get
            Set(ByVal value As ClsParametroIni)
                atrParametroAlmacenAlQueSeSolicitaPermiteModificar = value
            End Set
        End Property

        Public Property ParametroPermiteImprimirSolicitud()
            Get
                Return atrParametroPermiteImprimirSolicitud
            End Get
            Set(ByVal value)
                atrParametroPermiteImprimirSolicitud = value
            End Set
        End Property

        Public Property ParametroAlmacenAlQueSeTraspasa() As ClsParametroIni
            Get
                Return atrParametroAlmacenAlQueSeTraspasa
            End Get
            Set(ByVal value As ClsParametroIni)
                atrParametroAlmacenAlQueSeTraspasa = value
            End Set
        End Property

        Public Property ParametroAlmacenAlQueSeTraspasaPermiteModificar() As ClsParametroIni
            Get
                Return atrParametroAlmacenAlQueSeTraspasaPermiteModificar
            End Get
            Set(ByVal value As ClsParametroIni)
                atrParametroAlmacenAlQueSeTraspasaPermiteModificar = value
            End Set
        End Property

        Public Property ParametroPermiteImprimirSalidaPorTraspaso() As ClsParametroIni
            Get
                Return atrParametroPermiteImprimirSalidaPorTraspaso
            End Get
            Set(ByVal value As ClsParametroIni)
                atrParametroPermiteImprimirSalidaPorTraspaso = value
            End Set
        End Property

        Public Property ParametroPermiteImprimirSurtidoDePedido() As ClsParametroIni
            Get
                Return atrParametroPermiteImprimirSurtidoDePedido
            End Get
            Set(ByVal value As ClsParametroIni)
                atrParametroPermiteImprimirSurtidoDePedido = value
            End Set
        End Property

        Public Property ParametroPermiteImprimirSalidaPorDevolucion() As ClsParametroIni
            Get
                Return atrParametroPermiteImprimirSalidaPorDevolucion
            End Get
            Set(ByVal value As ClsParametroIni)
                atrParametroPermiteImprimirSalidaPorDevolucion = value
            End Set
        End Property

        Public Property ParametroPermiteImprimirRecepcionDePedido() As ClsParametroIni
            Get
                Return atrParametroPermiteImprimirRecepcionDePedido
            End Get
            Set(ByVal value As ClsParametroIni)
                atrParametroPermiteImprimirRecepcionDePedido = value
            End Set
        End Property

        Public Property ParametroPermiteImprimirEntradaPorTraspaso() As ClsParametroIni
            Get
                Return atrParametroPermiteImprimirEntradaPorTraspaso
            End Get
            Set(ByVal value As ClsParametroIni)
                atrParametroPermiteImprimirEntradaPorTraspaso = value
            End Set
        End Property


        Public Property ParametroPermiteImprimirEntradaPorDevolucion() As ClsParametroIni
            Get
                Return atrParametroPermiteImprimirEntradaPorDevolucion
            End Get
            Set(ByVal value As ClsParametroIni)
                atrParametroPermiteImprimirEntradaPorDevolucion = value
            End Set
        End Property

        Public Property ParametroAlmacenAlQueSeDevuelve() As ClsParametroIni
            Get
                Return atrParametroAlmacenAlQueSeDevuelve
            End Get
            Set(ByVal value As ClsParametroIni)
                atrParametroAlmacenAlQueSeDevuelve = value
            End Set
        End Property

        Public Property ParametroAlmacenAlQueSeDevuelvePermiteModificar() As ClsParametroIni
            Get
                Return atrParametroAlmacenAlQueSeDevuelvePermiteModificar
            End Get
            Set(ByVal value As ClsParametroIni)
                atrParametroAlmacenAlQueSeDevuelvePermiteModificar = value
            End Set
        End Property
        Public Property ParametroIntervaloAlertas() As ClsParametroIni
            Get
                Return atrParametroIntervaloAlertas
            End Get
            Set(ByVal value As ClsParametroIni)
                atrParametroIntervaloAlertas = value
            End Set
        End Property
        Public Property ParametroBloqueoInactividad() As ClsParametroIni
            Get
                Return atrParametroBloqueoInactividad
            End Get
            Set(ByVal value As ClsParametroIni)
                atrParametroBloqueoInactividad = value
            End Set
        End Property


        Public Function Almacen() As Integer
            Return Val(atrParametroAlmacen.Valor)
        End Function

        Public Function Caja() As Integer
            Return Val(atrParametroCaja.Valor)
        End Function


    End Class ' ClsParametrosTerminal

End Namespace
