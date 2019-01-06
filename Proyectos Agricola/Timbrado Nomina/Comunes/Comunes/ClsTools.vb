
Imports System.Windows.Forms
Imports System.Drawing.Design
Imports System.Drawing
Imports Sistema
Imports System.Web
Imports System.IO
Imports Sistema.Comunes.Catalogos
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Imports Microsoft.VisualBasic


Namespace Comunes.Comun

    Public Class ClsTools
        Public Shared CerrarPantallaSinPreguntar As Boolean = False

        Public Shared RESALTARCOLOR As System.Drawing.Color = Color.Yellow
        Private Shared DESACTIVARCOLOR As System.Drawing.Color = System.Drawing.SystemColors.Control
        Public Shared ACTIVARCOLOR As System.Drawing.Color = System.Drawing.Color.Empty
        Private Shared TextoActivo As System.Drawing.Color = System.Drawing.SystemColors.WindowText
        Private Shared TextoInactivo As System.Drawing.Color = System.Drawing.SystemColors.GrayText
        Public Shared Motivo As String
        Private Shared archivoIni As Ini.IniFileController
        Private Shared DAO As DataAccessCls = DataAccessCls.DevuelveInstancia




        Public Shared GlobalSistemaDocumentoNoCorrespondeconTipoArticulo As String = "El folio del documento ya pertenece a otro tipo de artículo"
        Public Shared GlobalSistemaArticuloNoCorrespondeConTipoArticulo As String = "El artículo ya pertenece a otro tipo de artículo"

        Public Shared PrmIni_ContextoInicial As String = "CONTEXTOINICIAL"
        Public Shared PrmIni_ImpresoraTickets As String = "IMPRESORA_TICKETS"
        Public Shared PrmIni_AlmacenDefaultMovimiento As String = "ALMACEN"
        Public Shared PrmIni_CajaDefaultMovimiento As String = "CAJA"
        Public Shared PrmIni_AlmacenAlQueSePidePedido As String = "ALMACEN_AL_QUE_SE_PIDE_PEDIDO"
        Public Shared PrmIni_AlmacenAlQueSeSolicitaTraspaso As String = "ALMACEN_AL_QUE_SE_SOLICITA_TRASPASO"
        Public Shared PrmIni_AlmacenAlQueSeDevuelve As String = "ALMACEN_AL_QUE_SE_DEVUELVE"
        Public Shared PrmIni_AlmacenAlQueSeTraspasa As String = "ALMACEN_AL_QUE_SE_TRASPASA"
        Public Shared PrmIni_PermiteModificarAlmacenAlQueSeDevuelve As String = "MODIFICA_ALMACEN_AL_QUE_SE_DEVUELVE"
        Public Shared PrmIni_PermiteModificarAlmacenAlQueSePidePedido As String = "MODIFICA_ALMACEN_AL_QUE_SE_PIDE_PEDIDO"
        Public Shared PrmIni_PermiteModificarAlmacenDefaultMovimiento As String = "MODIFICA_ALMACEN"
        Public Shared PrmIni_PermiteModificarAlmacenAlQueSeSolicitaTraspaso As String = "MODIFICA_ALMACEN_AL_QUE_SE_SOLICITA_TRASPASO"
        Public Shared PrmIni_PermiteModificarAlmacenAlQueSeTraspasa As String = "MODIFICA_ALMACEN_AL_QUE_SE_TRASPASA"
        Public Shared PrmIni_PermiteModificarFechaMovimiento As String = "MODIFICA_FECHA_MOVIMIENTOS"
        Public Shared PrmIni_ImprimeComprobantes As String = "IMPRIME_COMPROBANTES"
        Public Shared PrmIni_ImprimePideConfirmacion As String = "IMPRIME_PIDE_CONFIRMACION"
        Public Shared PrmIni_ImprimePedido As String = "IMPRIME_PEDIDO"
        Public Shared PrmIni_ImprimeSurtido As String = "IMPRIME_SURTIDO"
        Public Shared PrmIni_ImprimeRecepcionSurtido As String = "IMPRIME_RECEPCION_SURTIDO"
        Public Shared PrmIni_ImprimeSolicitudTraspaso As String = "IMPRIME_SOLICITUD_TRASPASO"
        Public Shared PrmIni_ImprimeSalidaTraspaso As String = "IMPRIME_SALIDA_TRASPASO"
        Public Shared PrmIni_ImprimeEntradaTraspaso As String = "IMPRIME_ENTRADA_TRASPASO"
        Public Shared PrmIni_ImprimeSalidaDevolucion As String = "IMPRIME_SALIDA_DEVOLUCION"
        Public Shared PrmIni_ImprimeEntradaDevolucion As String = "IMPRIME_ENTRADA_DEVOLUCION"
        Public Shared PrmIni_ImprimeMovimientosGenerales As String = "IMPRIME_MOVIMIENTOS_GENERALES"
        Public Shared PrmIni_TouchScreen As String = "TOUCH_SCREEN"
        Public Shared PrmIni_Alertas As String = "FRECUENCIA_ALERTAS"
        Public Shared PrmIni_ActivarAlertas As String = "ACTIVAR_ALERTAS"
        Public Shared PrmIni_BloqueoInactividad As String = "BLOQUEO_INACTIVIDAD"
        Public Shared PrmIni_TiempoInactividad As String="TIEMPO_INACTIVIDAD"

        ' Parametros de producción
        Public Shared PrmIni_ProImpresoraTickets As String = "PRO_IMPRESORA_TICKETS"
        Public Shared PrmIni_ProAlmacenDefaultMovimiento As String = "PRO_ALMACEN_MOVIMIENTO"
        Public Shared PrmIni_ProAlmacenAlQueSePide As String = "PRO_ALMACEN_AL_QUE_SE_PIDE"
        Public Shared PrmIni_ProAlmacenAlQueSeSolicitaTraspaso As String = "PRO_ALMACEN_AL_QUE_SE_SOLICITA_TRASPASO"
        Public Shared PrmIni_ProAlmacenAlQueSeDevuelve As String = "PRO_ALMACEN_AL_QUE_SE_DEVUELVE"
        Public Shared PrmIni_ProAlmacenAlQueSeTraspasa As String = "PRO_ALMACEN_AL_QUE_SE_TRASPASA"
        Public Shared PrmIni_ProPermiteModificarAlmacenAlQueSeDevuelve As String = "PRO_MODIFICA_ALMACEN_AL_QUE_SE_DEVUELVE"
        Public Shared PrmIni_ProPermiteModificarAlmacenAlQueSePide As String = "PRO_MODIFICA_ALMACEN_AL_QUE_SE_PIDE"
        Public Shared PrmIni_ProPermiteModificarAlmacenDefaultMovimiento As String = "PRO_MODIFICA_ALMACEN"
        Public Shared PrmIni_ProPermiteModificarAlmacenAlQueSeSolicitaTraspaso As String = "PRO_MODIFICA_ALMACEN_AL_QUE_SE_SOLICITA_TRASPASO"
        Public Shared PrmIni_ProPermiteModificarAlmacenAlQueSeTraspasa As String = "PRO_MODIFICA_ALMACEN_AL_QUE_SE_TRASPASA"
        Public Shared PrmIni_ProPermiteModificarFechaMovimiento As String = "PRO_MODIFICA_FECHA_MOVIMIENTOS"
        Public Shared PrmIni_ProImprimeComprobantes As String = "PRO_IMPRIME_COMPROBANTES"
        Public Shared PrmIni_ProImprimePideConfirmacion As String = "PRO_IMPRIME_PIDE_CONFIRMACION"
        Public Shared PrmIni_ProImprimePedido As String = "PRO_IMPRIME_PEDIDO"
        Public Shared PrmIni_ProImprimeSuministro As String = "PRO_IMPRIME_SUMINISTRO"
        Public Shared PrmIni_ProImprimeRecepcionSuministro As String = "PRO_IMPRIME_RECEPCION_SUMINISTRO"
        Public Shared PrmIni_ProImprimeSolicitudTraspaso As String = "PRO_IMPRIME_SOLICITUD_TRASPASO"
        Public Shared PrmIni_ProImprimeSalidaTraspaso As String = "PRO_IMPRIME_SALIDA_TRASPASO"
        Public Shared PrmIni_ProImprimeEntradaTraspaso As String = "PRO_IMPRIME_ENTRADA_TRASPASO"
        Public Shared PrmIni_ProImprimeSalidaDevolucion As String = "PRO_IMPRIME_SALIDA_DEVOLUCION"
        Public Shared PrmIni_ProImprimeEntradaDevolucion As String = "PRO_IMPRIME_ENTRADA_DEVOLUCION"
        Public Shared PrmIni_ProImprimeMovimientosGenerales As String = "PRO_IMPRIME_MOVIMIENTOS_GENERALES"
        Public Shared PrmIni_ProImprimeSolicitudDevolucion As String = "PRO_IMPRIME_SOLICITUD_DEVOLUCION"
        Public Shared PrmIni_ProCodigoBarraNoValidadoAfectaCodigoGenerico As String = "CODIGOBARRA_NOVALIDADO_AFECTA_CODIGOGENERICO"
        Public Shared PrmIni_PermiteCapturaPedidoEspecialASIC As String = "PERMITE_CAPTURA_PEDIDO_ESPECIAL_ASIC"
        'Fin ParametrosProduccion

        Public Shared PrmIni_PermiteRegistroDocumentosContado As String = "PERMITE_REGISTRO_DOC_CONTADO"
        Public Shared PrmIni_PermiteRegistroDocumentoCreditoCompleto As String = "PERMITE_REGISTRO_DOC_CREDITO_COMPLETO"
        Public Shared PrmIni_PermiteRegistroDocumentoCredito As String = "PERMITE_REGISTRO_DOC_CREDITO"
        Public Shared PrmIni_ImpresoraTicketPlantillaExpress As String = "IMPRESORA_DEFAULT_TICKET_PLANTILLAEXPRESS"
        Public Shared PrmIni_NUMERO_COPIAS_TICKET_CONTRARECIBOS As String = "NUMERO_COPIAS_TICKET_CONTRARECIBOS"
        Public Shared PrmIni_NUMERO_COPIAS_TICKET_PRODUCCION_DISTRIBUCION As String = "NUMERO_COPIAS_TICKET_MODULO_PRODUCCION_DISTRIBUCION"

        Public Shared GlobalSistemaPagoProveedores As String = "BAN_CONCEPTOCHEQUE_PAGOPROVEEDORES"
        Public Shared GlobalSistemaChequeEmitidoTerceros As String = "BAN_CONCEPTOCHEQUE_CHEQUEEMITIDOTERCEROS"
        Public Shared GlobalSistemaGastosDeContado As String = "BAN_CONCEPTOCHEQUE_GASTOSCONTADO"
        Public Shared GlobalSistemaRegistroAnticipos As String = "BAN_CONCEPTOCHEQUE_REGISTROANTICIPO"
        Public Shared GlobalSistemaRegistroChequeCancelado As String = "BAN_TIPO_CHEQUECANCELADO"

        Private Shared atrDiferenciaMaximimaPermitida As Decimal = -1
        Public Shared ComboSeleccione As String = "<<SELECCIONE>>"
        Public Shared ComboTodos As String = "<<TODOS>>"
        Public Shared GlobalSistemaLineaCorporativoNO As String = "No hay línea al corporativo"
        Public Shared GlobalSistemaConfirmaCerrarVentana As String = "¿Desea cerrar la ventana?"
        Public Shared GlobalSistemaConfirmaImprimirTicket As String = "¿Imprimir Ticket?"
        Public Shared GlobalSistemaConfirmaImprimirEtiquetasCodigosBarraProductos As String = "¿Imprimir Etiquetas?"
        Public Shared GlobalSistemaconfirmaImprimir As String = "¿Desea imprimir la información?"
        Public Shared GlobalSistemaErrorDeAlmacen As String = "Esta opción no aplica para el almacén configurado"
        Public Shared GlobalSistemaCaption As String = "Sistema de Facturación Electrónica"
        Public Shared GlobalSistemaMultiplesElementosInvalidos As String = "Elementos Inválidos"
        Public Shared GlobalSistemaNoEsistenProductosAInventariar As String = "No existen productos en el almacén a inventariar"
        Public Shared GlobalSistemaCodigoNoExiste As String = "Código no existe"
        Public Shared GlobalSistemaFolioNoExiste As String = "Folio no existe"
        Public Shared GlobalSistemaErrorMismoAlmacen As String = "No puede hacer referencia al mismo almacén"
        Public Shared GlobalSistemaRegistrando As String = "REGISTRANDO"
        Public Shared GlobalSistemaConsultando As String = "CONSULTANDO"
        Public Shared GlobalSistemaReactivando As String = "REACTIVANDO"
        Public Shared GlobalSistemaEstatusActivo As String = "ACTIVO"
        Public Shared GlobalSistemaGuardarTiposDatos As String = "Teclea los datos de la celda que eliminaste "
        Public Shared GlobalSistemaDatosNoEncontrados As String = "No existen registros con los filtros proporcionados"

        Public Shared GlobalSistemaElValorDebeSerNumerico As String = "El valor ingresado debe ser numérico"

        Public Shared GlobalSistemaAlmacenNoConfiguradoParaOpcion As String = "El almacén no está configurado para ésta opción"

        Public Shared GlobalSistemaConfirmaReactivarConfiguracionesFiltrosPantalla As String = "¿Confirma reactivar configuraciones de filtros?"
        Public Shared GlobalSistemaConfirmacancelarConfiguracionesFiltrosPantalla As String = "¿Confirma cancelar configuraciones de filtros?"

        Public Shared GlobalSistemaFechaIncorrecta As String = " La fecha de registro debe de ser menor o igual a la fecha actual"
        Public Shared GlobalSistemaFechaRecepcionIncorrecta As String = " La fecha de Recepción debe de ser menor o igual a la fecha actual"
        Public Shared GlobalSistemaFechaProduccionIncorrecta As String = " La fecha de producción debe de ser menor o igual a la fecha actual"
        Public Shared GlobalSistemaFechaSuministroIncorrecta As String = " La fecha de entrega debe de ser mayor o igual a la fecha actual"
        Public Shared GlobalSistemaFechaIncorrectaRegistros As String = " La fecha inicio de registro debe de ser menor o igual a la fecha fin"
        Public Shared GlobalSistemaFechaIncorrectaMovimientos As String = " La fecha inicio de movimientos debe de ser menor o igual a la fecha fin"
        Public Shared GlobalSistemaFechaIncorrectaPeriodoInicio As String = " La fecha inicio de periodo debe de ser menor o igual a la fecha fin"
        Public Shared GlobalSistemaFechaIncorrectaPeriodoFin As String = " La fecha fin de periodo debe de ser mayor o igual a la fecha fin"
        Public Shared GlobalSistemaFechaIncorrectaDeRango As String = " La fecha inicio debe de ser menor o igual a la fecha fin"

        Public Shared GlobalSistemaFechaIncorrectaRecepcion As String = " La fecha de recepción inicio debe de ser menor o igual a la fecha fin"
        Public Shared GlobalSistemaSeleccionaEstatus As String = " Seleccione estatus"
        Public Shared GlobalSistemaErrorProgramacionAplicada As String = "No es posible modificar una programación ya aplicada"
        Public Shared GlobalSistemaErrorProgramacionCancelada As String = "No es posible modificar una programación cancelada"
        Public Shared GlobalSistemaAccesoNegado As String = "Imposible Cancelar un Anticipo debido a que existen facturas con anticipo aplicado"
        Public Shared GlobalSistemaEstatusCancelado As String = "CANCELADO"
        Public Shared GlobalSistemaInformacionAnticipo As String = "No hay información de Anticipos del Proveedor Seleccionado"
        Public Shared GlobalSistemaOrdenCerradaConExito As String = "La orden de compra fue cerrada con exito"
        Public Shared GlobalSistemaRegistroGuardadoExito As String = "Registro guardado con éxito"
        Public Shared GlobalSistemaCodigoRemplazadoConExito As String = "Código de barras reemplazado con éxito"
        Public Shared GlobalSistemaLimpiarPantalla As String = "¿Desea limpiar la pantalla?"
        Public Shared GlobalSistemaErrorGuardarDato As String = "Error al guardar el registro"
        Public Shared GlobalSistemaErrorGuardarimagen As String = "Las imagenes no pudieron ser actualizadas"
        Public Shared GlobalSistemaErrorActualizarDato As String = "Error al actualizar el registro"
        Public Shared GlobalSistemaErrorFaltanCampos As String = "Falta proporcionar: " & vbCrLf
        Public Shared GlobalSistemaConfirmaEliminarRenglon As String = "¿Seguro de eliminar el renglón"
        Public Shared GlobalSistemaFaltanDatosArticulos As String = "Datos de Artículo"
        Public Shared GlobalSistemaFaltanDatos As String = "Faltan Datos Por Capturar"
        Public Shared GlobalSistemaConfirmaGuardarDato As String = "¿Desea guardar la información?"
        Public Shared GlobalSistemaAccesonegadoDeActualizacionDeEntradas As String = "No se pueden modificar los movimientos de entrada ya registrados"
        Public Shared GlobalSistemaConfirmaCargarInformacion As String = "¿Desea cargar la información?"
        Public Shared GlobalSistemaConfirmaCancelarDato As String = "¿Desea cancelar este registro?"
        Public Shared GlobalSistemaConfirmaCancelarPresupuesto As String = "¿Desea cancelar el Presupuesto del registro?"
        Public Shared GlobalSistemaConfirmaActualizarInsumos As String = "Se actualizarán las cantidades de insumos de este producto"
        Public Shared GlobalSistemaConfirmaReactivarDato As String = "¿Desea reactivar este registro?"
        Public Shared GlobalSistemaDatoCancelado As String = "Registro cancelado con éxito"
        Public Shared GlobalSistemaDatoReactivado As String = "Registro reactivado con éxito"
        Public Shared GlobalsistemaErrorCancelarDato As String = "No es posible cancelar este registro, tiene registros que lo contemplan"
        Public Shared GlobalSistemaErrorConfiguracion As String = "No es posible realizar la operación"
        Public Shared GlobalSistemaErrorProporcionarSistema As String = "Falta proporcionar Sistema"
        Public Shared GlobalSistemaErrorPorcentaje As String = "El Porcentaje debe ser mayor a 0.00% y menor o igual a 100%"
        Public Shared GlobalSistemaErrorPorcentaje_MayorCero_MenorCien As String = " El porcentaje debe ser mayor a 0.00% y menor a 100%"
        Public Shared GlobalSistemaErrorPresentacionRepetida As String = "Ya existe este Producto con esta Presentación"
        Public Shared GlobalSistemaErrorProntoPagoRepetido As String = "Ya existe un Pronto Pago para esa cantidad de días"
        Public Shared GlobalSistemaErrorDescuentoCascada As String = "El Descuento en Cascada no puede ser mayor a 100%"
        Public Shared GlobalSistemaErrorCantidadConCargo As String = "No puede haber una cantidad sin cargo sin una con cargo"
        Public Shared GlobalSistemaErrorImporte As String = "Importe incorrecto, favor de Verificar"
        Public Shared GlobalSistemaNoExistenPolizas As String = "No Existe un Tipo de Póliza, Por favor agregue uno"
        Public Shared GlobalSistemaErrorOrdenNoValido As String = "El orden seleccionado, ya se encuentra en otro folio de Impuesto"
        Public Shared GlobalSistemaParidadIncorrecta As String = "La Paridad debe de ser mayor a 0.00 para la moneda seleccionada"
        Public Shared GlobalSistemaImporteAnticipo As String = "El Importe del anticipo deber ser menor o igual al importe de la factura,verifique"
        Public Shared GlobalSistemaImportePagoProveedor As String = "El Importe del Pago con su paridad deber ser menor o igual al Saldo del Adeudo,verifique"
        Public Shared GlobalSistemaAnticipoPendiente As String = "El proveedor tiene anticipos pendientes,está seguro que no desea aplicar anticipos al proveedor"
        Public Shared GlobalSistemaTotalesTasas As String = "Los totales del grid de tasas no corresponden al total de la cuenta por pagar capturada"
        Public Shared GlobalSistemaImportes As String = "Los Totales de la Distribución de Impuestos deben ser Igual al Importe del Documento,Verifique"
        Public Shared GlobalSistemaAnticipoMayor As String = "El total de Anticipos a aplicar es mayor al total del Importe del Documento"
        Public Shared GlobalSistemaDatosAnticipos As String = "No hay información de Anticipos del proveedor Seleccionado"
        Public Shared GlobalSistemaErrorSucursalNoProporcionada As String = "No se envio el Objeto Sucursal"
        Public Shared GlobalSistemaErrorMovimientoAdeudoNoProporcionado As String = "No se envio el Objeto Movimiento Adeudo"
        Public Shared GlobalSistemaErrorTipoMovimientoCXPNoProporcionado As String = "No se envio el Objeto Tipo Movimiento CXP"
        Public Shared GlobalSistemaErrorRegistroAnticipoNoProporcionado As String = "No se envio el Objeto Registro Anticipo"
        Public Shared GlobalSistemaErrorImporteIncorrecto As String = "No se envio un Importe correcto"
        Public Shared GlobalSistemaConfirmaAplicaSuministro As String = "¿Desea aplicar el suministro?"
        Public Shared GlobalSistemaAvisoParidadAnticipo As String = "No puede Seleccionar Anticipo sin Paridad al día"
        Public Shared GlobalSistemaParidadesDia As String = "Es necesario registrar las paridades del día"
        Public Shared GlobalSistemaProductoSinComposicion As String = "El producto elegido requiere composición"
        Public Shared GlobalSistemaInsumoDuplicadoComposicion As String = "Insumo duplicado en la composición"
        Public Shared GlobalSistemaInsumoDuplicadoconversion As String = "Producto duplicado para la conversión"
        Public Shared GlobalSistemaInsumoParaconversion As String = "El producto está seleccionado para la conversión"
        Public Shared GlobalSistemaInsumoCorrespondienteComposicion As String = "El insumo corresponde al producto elegido para la composición"
        Public Shared GlobalSistemaSeHanHechoCambios As String = "Se han realizado movimientos, desea continuar ?"
        Public Shared GlobalSistemaNoDatosGuardar As String = "No existen datos para guardar, favor de verificar"
        Public Shared GlobalSistemaImporteAplicadoMayor As String = "El Importe Aplicadoes mayor que el Importe del Presupuesto a registrar"
        Public Shared GlobalSistemaErrorFechas As String = "La fecha inicial debe ser menor o igual a la fecha final"
        Public Shared GlobalSistemaErrorNoExistenDatosFiltros As String = "No existen datos con los filtros específicados"
        Public Shared GlobalSistemaErrorSinDepositoInicial As String = "Es necesario capturar un Depósito Inicial"
        Public Shared GlobalSistemaErrorEliminandoMovimientoBancarioConciliado As String = "No se puede cancelar un Movimiento Bancario Conciliado"
        Public Shared GlobalSistemaErrorGuardarImporte As String = "Existen Diferencias en el importe Aplicado,Verifique"
        Public Shared GlobalSistemaErrorDocumentoYaExistente As String = "Documento ya existente"
        Public Shared GlobalSistemaErrorMovimientoConciliado As String = "No es posible Modificar un Movimiento ya conciliado"
        Public Shared GlobalSistemaErrorConversionSinCantidad As String = "No se ha especificado la cantidad de producto (s) a convertir"
        Public Shared GlobalSistemaErrorCantidadMayoraExistencia As String = "La cantidad a convertir es mayor a la existencia del producto"
        Public Shared GlobalSistemaErrorFaltanParametros As String = "Debe ingresar los parametros necesario para continuar"
        Public Shared GlobalSistemaEstatusConciliado As String = "CONCILIADO"
        Public Shared GlobalSistemaTieneAplicacionesAnticipo As String = "El anticipo ya tiene algunas aplicaciones"
        Public Shared GlobalSistemaErrorMovimientoCancelado As String = "Movimiento ya Cancelado"
        Public Shared GlobalSistemaErrorArchivoRutaNoExistente As String = "El archivo no existe en esa ruta o ha sido movido"
        Public Shared GlobalSistemaErrorFaltanCamposObligatorios As String = "Es necesario Capturar los Campos marcados"
        Public Shared GlobalSistemaSeleccioneElemento As String = "Seleccione al menos un elemento de la lista"
        Public Shared GlobalSistemaArchivoGenerado As String = "Archivo Generado con Éxito"
        Public Shared GlobalSinSeleccionConversion As String = "Proporcione al menos un producto para la conversión"
        Public Shared GlobalSistemaNoExistenDatos As String = "No existen datos con los filtros proporcionados"
        Public Shared GlobalSistemaSinCantidad As String = "Al menos debe haber un producto con cantidad"
        Public Shared GlobalSistemaCantidadCero As String = "Existen registros con cantidad en 0, ¿Desea continuar?"
        Public Shared GlobalSistemaPrecapturaNoExiste As String = "Precaptura no existe"
        Public Shared GlobalSistemaPrecapturaExiste As String = "Nombre de precaptura ya existente"
        Public Shared GlobalSistemaProductoSincantidad As String = "Existen productos con cantidad en 0"
        Public Shared GlobalSistemaCapturaFlujos As String = "Desea realizar la captura de flujos de Bancos de los movimientos registrados"
        Public Shared GlobalSistemaElementosNoSeleccionados As String = "seleccione al menos un elemento del listado"
        Public Shared GlobalSistemaExistenChequesEnRango As String = "Existen Cheques Registrados en El Rango especificado "
        Public Shared GlobalSistemaImporteMayorSaldo As String = "Abono mayor al saldo de la factura"
        Public Shared GlobalSistemaNoImporteSinSeleccion As String = "No puede capturar Importes a Elemento que no ha sido Seleccionado"
        Public Shared GlobalSistemaNoDetalleAdeudo As String = "La Factura debe ser de Compras para tener un detalle"
        Public Shared GlobalSistemaPerderRegistros As String = "Desea perder los registros modificados?"
        Public Shared GlobalSistemaNoTipoMovimientoPago As String = "Tipo de Movimiento no es Pago"
        Public Shared GlobalSistemaDiaNoCorrespondeaFecha As String = "El día de entrega no corresponde a la fecha indicada"
        Public Shared GlobalSistemaProductoDuplicadoPedido As String = "Producto duplicado en el pedido"
        Public Shared GlobalSistemaProductoDuplicadoComposicion As String = "Producto duplicado en la composición"
        Public Shared GlobalSistemaProductoComposicionPedido As String = "El producto elegido corresponde al producto pedido"
        Public Shared GlobalSistemaCuentaSinDepositoInicial As String = "La cuenta debe tener un Depósito Inicial"
        Public Shared GlobalSistemaReferenciaUtilizada As String = "Referencia ya ha sido Utilizada,verifique"
        Public Shared GlobalSistemaFolioInicialSinValor As String = "Especifique valor para el primer folio de Cheque"
        Public Shared GlobalSistemaNoCambioEstatusCompra As String = "No se realizó el Cambio el Estatus a Registrado,tiene movimientos aplicados desde otros Módulos"
        Public Shared GlobalSistemaPolizaExportada As String = "La Póliza asignada al Movimiento de CxP ha sido Exportada,desea Continuar?"
        Public Shared GlobalSistemaErrorFechasCancelar As String = "La fecha de Cancelación debe ser igual o mayor a la fecha de Registro del Anticipo"
        Public Shared GlobalSistemaNoGuardarCxPAutorizado As String = "El Movimiento Consultado debe ser desautorizado para se pueda Guardar"
        Public Shared GlobalSistemaCambioEnSaldoAnticipo As String = "Saldo de Anticipo seleccionado ha cambiado,no se puede continuar con la operación"
        Public Shared GlobalSistemaConfirmaCancelarAnticipos As String = "¿Desea Cancelar los Anticipos del Movimiento Consultado?"
        Public Shared GlobalSistemaNoRegistroAnticipos As String = "No tiene Registro de anticipos"
        Public Shared GlobalSistemaAnticiposCanceladosRealizado As String = "Anticipos Cancelados Exitosamente"
        Public Shared GlobalSistemaFacturaNoCero As String = "El No. de la factura no puede ser 0"
        Public Shared GlobalSistemaFechaIncorrectaVencimientoFactura = "La fecha de Vencimiento no puede ser menor a la fecha de factura"
        Public Shared GlobalSistemaFechaIncorrectaRecepcionMenorFactura = "La fecha de Recepción no puede ser menor a la fecha de factura"
        Public Shared GlobalSistemaFechaIncorrectaRecepcionMayorFactura = "La fecha de Recepción no puede ser Mayor a la fecha Actual"
        Public Shared GlobalSistemaMismoDocumento As String = "El Documento Ya Fue Registrado"
        Public Shared GlobalSistemaAnticipoNoCubreMinimo As String = "El anticipo ingresado no cubre el porcentaje minimo requerido"
        Public Shared GlobalSistemaAnticipoMayorImporte As String = "El anticipo ingresado es mayor al importe"
        Public Shared GlobalSistemaFechaEntregamenorFechaPedido As String = "La fecha de entrega debe ser mayor igual a la fecha del registro"
        Public Shared GlobalSistemaPrecioMenordeLista As String = "El precio indicado es menor al precio de lista"
        Public Shared GlobalSistemaAdeudoAnticiposRegistrados As String = "El movimiento de Adeudo tiene Anticipos registrados,desea cancelarlos"
        Public Shared GlobalSistemaAdeudoMovimientosAplicados As String = "El movimiento de Adeudo tiene movimientos aplicados,no se puede Cancelar"
        Public Shared GlobalSistemaMamixoPermitidoImporte As Decimal = 99999999999999.9
        Public Shared GlobalSistemaMaximoNumeroEnteroPositivoPermitido As Integer = 2147483647 'en Negativo es -2147483648
        Public Shared GlobalSistemaMaximoNumeroLargoPositivoPermitido As Long = 9223372036854775807 'en Negativo es -9223372036854775808
        Public Shared GlobalSistemaNoGuardarAdeudoConAnticipos As String = "No puede Guardar la CxP,Tiene movimientos de Anticipos"
        Public Shared GlobalSistemaDiasNoCero As String = "Indique No. de Días Mayores a 0 para los Rangos"
        Public Shared GlobalSistemaProductoRepetido As String = "Producto duplicado"
        Public Shared GlobalSistemaConfirmaImprimirCheque As String = "¿Desea imprimir el cheque?"
        Public Shared GlobalSistemaImpresoraLista As String = "Presione aceptar cuando la impresora este lista"
        Public Shared GlobalSistemaNoConciliacionCompra As String = "El registro no tiene asociado conciliación de Compra"
        Public Shared GlobalSistemaDesconciliarMovimiento As String = "El movimiento está conciliado,desea desconciliarlo?"
        Public Shared GlobalSistemaDesconciliarMovimientos As String = "Desea Desconciliar todos los Movimientos?"
        Public Shared GlobalSistemaDeseaContabilizar As String = "Desea contabilizar ?"
        Public Shared GlobalSistemaDigitosDecimales As Integer = 2
        Public Shared GlobalSistemaMaximoCaracteresObservacionCheques As Integer = 100
        Public Shared GlobalSistemaMaximoCaracteresReferenciaPolizas As Integer = 200
        Public Shared GlobalSistemaCancelaPoliza As String = "CANCELAR"
        Public Shared GlobalSistemaContraPoliza As String = "CONTRAPOLIZA"
        Public Shared GlobalSistemaParametroPlazaNoDefinido As String = "Parámetro administrado plaza no establecido"
        Public Shared GlobalSistemaPreguntaContabiliza As String = "BAN_CONSULTAPREGUNTAPOLIZA"
        Public Shared GlobalSistemaObligaCapturaFlujos As String = "BAN_OBLIGACAPTURARFLUJOS"
        Public Shared GlobalSistemaNoConfiguracionEstadoCuentaBancario As String = "No existe una configuración para el estado de cuenta establecida en la cuenta bancaria"
        Public Shared GlobalSistemaPreguntaEliminaRenglonGrid As String = "¿Seguro de eliminar el renglón?"
        Public Shared GlobalSistemaLongitudMaximaReferenciaPoliza As Integer = 17
        Public Shared GlobalSistemaEstadoRegistrado As String = "REGISTRADO"
        Public Shared GlobalSistemaEstadoRevisado As String = "REVISADO"
        Public Shared GlobalSistemaEstadoNoRevisado As String = "NO REVISADO"
        Public Shared GlobalSistemaEstadoPagoParcial As String = "CON PAGO PARCIAL"
        Public Shared GlobalSistemaEstadoPagado As String = "PAGADO"

        Public Shared GlobalSistemaCodigoBarraHaSidoRemplazadoPorOtroCodigo As String = "El código de barra proporcionado ha sido remplazado por otro código"

        'Mensajes globales modulo Caja
        Public Shared GlobalSistemaAperturaGuardada As String = "Apertura guardada con éxito"
        Public Shared GlobalSistemaErrorGuardarApertura As String = "Error al guardar la apertura"
        Public Shared GlobalSistemaNoExisteAperturaActiva As String = "No existe una apertura activa para esta caja"

        Public Const EfectoBancoIngreso As String = "I"
        Public Const EfectoBancoEgreso As String = "E"



        Public Enum EN_TiempoTranscurrido
            Años = 1
            Meses = 2
            Dias = 3
            Todos = 4
        End Enum


        Public Enum EN_FechaAplicacionPago
            Recepcion = 1
            Factura = 2
            Revision = 3
            Vencimiento = 4
            Programacion = 5
            PolizaDiario = 6
            ContraRecibo = 7
        End Enum

        Public Enum EN_EstatusOrdenServicio
            Registrado = 1
            Autorizada = 2
            NoAutorizada = 3
            Cancelado = 4
            Utilizada = 5
        End Enum

        Public Enum EN_MovimientosEnBancos
            Cheque = 1
            MovimientoGeneral = 2
            Traspaso = 3
            Transferencia = 4
        End Enum

        Public Enum EN_EstatusCheques
            Registrado = 1
            Transito = 2
            Conciliado = 3
            Retenido = 4
            Cancelado = 5
        End Enum

        Public Enum EN_EstatusEntregaCheques
            Entregado = 1
            Depositado = 2
            Enviado = 3
        End Enum

        Public Enum EN_InvolucradosPolizaMovtosGenerales
            Beneficiario = 1
            Proveedor = 2
            Empleado = 3
            Cliente = 4
        End Enum

        Public Enum EN_EfectosBancos
            Egreso = -1
            Ingreso = 1
        End Enum

        Public Enum EN_DocumentoSinCxp
            No_Revisado = 0
            Revisado = 1
        End Enum

        Public Enum FormatoFecha
            YMD = 0
            DMY = 1
        End Enum

        Public Enum EN_PreguntaPorPoliza
            Si = 1
            No = 0
        End Enum

        Public Enum EN_ObligaCapturaFlujos
            Si = 1
            No = 0
        End Enum

        Public Enum EN_CapturaFlujos
            Normal = 0
            Preview = 1
        End Enum

        Private Enum EN_EnvioExistenciasProductos
            NoValidaFecha = 0
            ValidaFecha = 1
        End Enum

        Public Enum CDT_TipoDeHojasDeImpresora
            CDT_TipoDeHojasDeImpresora_Blancas = 1
            CDT_TipoDeHojasDeImpresora_PreImpresas = 2
            CDT_TipoDeHojasDeImpresora_Ambas = 3
        End Enum

        Public Enum CDT_OrientacionDeHoja
            CDT_OrientacionDeHoja_Vertical = 1
            CDT_OrientacionDeHoja_Horizontal = 2
        End Enum

        Public Enum TipoVistaXtraGrid
            GridView = 0
            BandedGridView = 1
        End Enum

        Public Enum CancelacionPolizas
            MISMODIA = 1
            MISMOMES = 2
            DISTINTOMES = 3
            MISMODIAEXPORTADA = 4
            MISMOMESEXPORTADA = 5
            DISTINTOMESEXPORTADA = 6
        End Enum

        Public Enum PantallasDBF
            Pedido = 1
            Devoluciones = 2
            Inventarios = 3
        End Enum

        Public Enum TipoSucursal
            Restaurant = 1
            Pasteleria = 2
        End Enum

        
        'Public Shared Function ObtenReporteGuardado(ByVal prmReporte As Integer) As Comunes.Comun.ClsReporteGuarda
        '    'Obtiene reporte a partir del folio del mismo
        '    Dim DtReporte As New DataTable
        '    Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        '    Dim vlsql As String = ""

        '    vlsql = "SELECT * FROM ADSUM_ReporteExpressGuarda(NOLOCK)" & vbCr
        '    vlsql &= "WHERE bActivo=0 and nReporte=" & prmReporte.ToString.Trim

        '    DAO.RegresaConsultaSQL(vlsql, DtReporte)

        '    If DtReporte.Rows.Count = 0 Then
        '        Return Nothing
        '    End If

        '    Return ObtenReporteGuardado(DtReporte.Rows(0))
        'End Function

#Region "FORMATOS CANTIDADES E IMPORTES PARA MODULO PRODUCCION Y DISTRUBUCION DE PANAMA"
        Public Shared Function RegresaFormatoCantidadProduccion() As String
            Return "{0:N1}"
        End Function
#End Region

        Public Shared Function RegresaValorEleccionUsuario(ByVal prmCamposSelect As String, ByVal prmTabla As String, ByVal prmFiltro As String) As String
            Dim vcEleccion As String = ""
            If prmFiltro.Trim = "" Then prmFiltro = " 1 = 1 "
            vcEleccion = DAO.RegresaEleccionDeUsuarioSobreConsultaSQL("SELECT " & prmCamposSelect & " FROM " & prmTabla & " (NOLOCK) WHERE " & prmFiltro)
            If vcEleccion.Trim = "*" Then vcEleccion = ""
            Return vcEleccion
        End Function



        Public Shared Sub ExpanderContraerDetalleGrid(ByRef prmGridView As Object)
            If prmGridView.GetVisibleDetailView(prmGridView.FocusedRowHandle) Is Nothing Then
                prmGridView.ExpandMasterRow(prmGridView.FocusedRowHandle, 0)
            Else
                prmGridView.CollapseMasterRow(prmGridView.FocusedRowHandle, 0)
            End If
        End Sub


        Public Shared Sub GrabaMensajeLog(ByRef prmLog As EventLog, ByVal prmMensaje As String, ByVal prmTipoIcono As EventLogEntryType)
            Try
                prmLog.WriteEntry(prmMensaje, prmTipoIcono)
            Catch ex As Exception

            End Try
        End Sub

        Public Shared Function FGValidaCantidadEncabezado_VS_CantidadDetalle(ByRef prmMensajeErrorValidacion As String, ByRef prmDataTableEncabezado As DataTable, ByRef prmDataTableDetalle As DataTable, ByVal prmColumnaCodigoProductoEncabezado As String, ByVal prmColumnaCantidadEncabezado As String, ByVal prmColumnaFolioProductoEncabezado As String, ByVal prmColumnaCantidadDetalle As String, ByVal prmColumnaFolioProductoDetalle As String) As Boolean
            Dim vnCantidadEncabezado As Decimal = 0
            Dim vnCantidadDetalle As Decimal = 0
            Dim vcProductosInconsistencia As String = ""
            Dim vDRowDetalle As DataRow()

            For Each dr As DataRow In prmDataTableEncabezado.Rows
                vnCantidadEncabezado = ClsTools.IfNull(dr(prmColumnaCantidadEncabezado), 0)
                vnCantidadDetalle = ClsTools.IfNull(prmDataTableDetalle.Compute("SUM(" & prmColumnaCantidadDetalle & ")", prmColumnaFolioProductoDetalle & " = " & dr(prmColumnaFolioProductoEncabezado)), 0)
                vDRowDetalle = prmDataTableDetalle.Select(prmColumnaFolioProductoEncabezado & "=" & dr(prmColumnaFolioProductoEncabezado))
                If Not vnCantidadEncabezado = vnCantidadDetalle OrElse vDRowDetalle.Length = 0 Then
                    vcProductosInconsistencia &= dr(prmColumnaCodigoProductoEncabezado) & vbCr
                End If

            Next
            If Not vcProductosInconsistencia.Trim = "" Then
                prmMensajeErrorValidacion = "La cantidad del encabezado no coincide con la cantidad del detalle," & vbCr & "en los siguientes productos:" & vbCr & vcProductosInconsistencia
                'ClsTools.MuestraMensajeSistFact("La cantidad del encabezado no coincide con la cantidad del detalle," & vbCr & "en los siguientes productos:" & vbCr & vcProductosInconsistencia, MessageBoxIcon.Exclamation)
                Return False
            End If
            Return True
        End Function

        Public Shared Function fgEliminaTablaTemporal(ByVal prmNombreTabla As String) As Boolean
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim arg(0) As Object
            Dim DS As New DataSet

            If prmNombreTabla = "" Then Return False
            arg(0) = prmNombreTabla
            Return DAO.RegresaConsultaSQL("SP_EliminaTablaTemporal", DS, arg)

        End Function

        Public Shared Function RegresaNombreCamposDeTablaEnRenglones(ByVal prmTabla As String, Optional ByVal prmNombreCampo As String = "cCampo") As DataTable
            If prmTabla = Nothing OrElse prmTabla.Trim = "" Then Return Nothing
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vDt As New DataTable
            Dim vcSql As String = "SELECT * FROM " & prmTabla & " (NOLOCK) WHERE 1 = 0 "
            If Not DAO.RegresaConsultaSQL(vcSql, vDt) Then Return Nothing
            If vDt Is Nothing Then Return Nothing

            Dim vDtResultados As New DataTable
            Dim vDrow As DataRow
            vDtResultados.Columns.Add(prmNombreCampo, GetType(String))

            For Each dCol As DataColumn In vDt.Columns
                vDrow = vDtResultados.NewRow
                vDrow(prmNombreCampo) = dCol.ColumnName.Trim
                vDtResultados.Rows.Add(vDrow)
            Next

            vDtResultados.TableName = prmTabla.Trim

            Return vDtResultados
        End Function

        Public Shared Sub ActualizaAlmacenLocalEnBaseIni(ByVal prmAlmacen As String)
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vSql As String = ""
            vSql = "UPDATE ADSUM_ParametrosAdministrados SET cValor = '" & prmAlmacen & "' WHERE cContexto = 'PRO' AND cParametroAdministrado = 'ALMACENLOCAL'"
            DAO.EjecutaComandoSQL(vSql)
        End Sub

        Public Shared Function getSizeFileMB(ByRef prmArchivo() As Byte) As Decimal
            If prmArchivo Is Nothing OrElse prmArchivo.Length = 0 Then Return 0
            Dim vnTamañoKB As Decimal = getSizeFileKB(prmArchivo)
            Return vnTamañoKB / 1024
        End Function
        Public Shared Function getSizeFileKB(ByRef prmArchivo() As Byte) As Decimal
            If prmArchivo Is Nothing OrElse prmArchivo.Length = 0 Then Return 0
            Return prmArchivo.Length / 1024
        End Function

        Public Shared Sub AgregaEspaciosEnBlanco(ByRef prmCadena As String, ByVal prmTotalEspaciosEnBlanco As Int32)
            For i As Integer = 1 To prmTotalEspaciosEnBlanco
                prmCadena &= " "
            Next
        End Sub


        Public Shared Function ActualizaParametroAdministrado(ByVal prmContexto As String, ByVal prmParametro As String, ByVal prmValor As String)
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vSQL As String = ""

            vSQL = "Exec sp_ActualizaParametroAdministrado '" & prmContexto & "','" & prmParametro & "','" & prmValor & "'"

            Return DAO.EjecutaComandoSQL(vSQL)

        End Function
        Public Shared Function GlobalSistemaErrorEjercicioPeriodo(ByVal prmEjercicio As Integer, ByVal prmPeriodo As Integer) As String
            Return "Error no se puede trabajar con el período indicado." & vbCrLf & "Ejercicio " & prmEjercicio & " Período " & prmPeriodo & " cerrado contablemente, verifique."
        End Function

        ' ''Public Shared Function ExisteLineaAlCorporativo() As Boolean
        ' ''    'Que espere 5 segundos
        ' ''    DAO = DataAccessCls.DevuelveInstancia

        ' ''    DAO.ParametroAdministradoAgregar("PRM", "TIMEOUT_ValidaLineaCorporativo", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parametro que indica el tiempo de espera para identificar si hay linea a corporativo", 60)

        ' ''    Dim miTiempoEspera As Integer = DAO.ParametroAdministradoObtener("PRM", "TIMEOUT_ValidaLineaCorporativo")
        ' ''    Return Not (RegresaDatoSQLdeWebService("SELECT GETDATE()", "", miTiempoEspera).Trim = "")
        ' ''End Function

        ' ''Public Shared Function RegresaDatoSQLdeWebService(ByVal vlSQL As String, Optional ByRef vMensajeError As String = "", Optional ByVal TIEMPO_ESPERA As Integer = 0) As String
        ' ''    'Ricardo Torróntegui
        ' ''    'Sirve para ejecutar una consulta en el webservice y nos regresa un dato tipo object con el resultado de 
        ' ''    'RegresaDatoSQL

        ' ''    Dim ds As DataSet
        ' ''    Dim ws As New WsComun.Comun

        ' ''    Dim miParametrosSucursal As Comunes.Comun.Parametros.ClsParametrosSucursal
        ' ''    miParametrosSucursal = DAO.ParametrosSucursal

        ' ''    DAO.ParametroAdministradoAgregar("WS", "WS_TIEMPO_ESPERA_GENERAL", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parametro que determina cual sera el valor de tiempo", 60000)

        ' ''    Try
        ' ''        ws.Url = DAO.ParametroAdministradoObtener("PRM", "WSCORPORATIVO") & DAO.ParametroAdministradoObtener("PRM", "WSCOMUN")


        ' ''        If TIEMPO_ESPERA = 0 Then
        ' ''            ws.Timeout = DAO.ParametroAdministradoObtener("WS", "WS_TIEMPO_ESPERA_GENERAL")
        ' ''        Else
        ' ''            ws.Timeout = 10000 'TIEMPO_ESPERA
        ' ''        End If

        ' ''        'Se Serializó la consulta
        ' ''        ds = ClsTools.deserializaDS(ws.RegresaConsultaSQL_DataSet(vlSQL))

        ' ''    Catch ex As Exception
        ' ''        vMensajeError = ex.Message
        ' ''    End Try

        ' ''    If Not ds Is Nothing Then
        ' ''        Try
        ' ''            Return CStr(ds.Tables(0).Rows(0)(0))
        ' ''        Catch ex As Exception
        ' ''            Return ""
        ' ''        End Try
        ' ''    End If
        ' ''    Return ""
        ' ''End Function

        Public Shared Function CompararColumnas(ByVal Column1 As Object, ByVal Column2 As Object, ByVal Tipo As Type) As Boolean

            Dim bconfirmacion As Boolean

            bconfirmacion = True

            If Not Column1 Is System.DBNull.Value And Not Column2 Is System.DBNull.Value Then

                'Se identifica de que tipo es la columna que se desa comparar, para hacer el cast correspondiente y la comparacion correspondiente
                Select Case Tipo.FullName()

                    Case "System.String"
                        If Column1.ToString() <> Column2.ToString() Then
                            bconfirmacion = False
                        End If

                    Case "System.Int64"
                        If Convert.ToInt64(Column1) <> Convert.ToInt64(Column2) Then
                            bconfirmacion = False
                        End If

                    Case "System.Int32"
                        If Convert.ToInt32(Column1) <> Convert.ToInt32(Column2) Then
                            bconfirmacion = False
                        End If

                    Case "System.Int16"
                        If Convert.ToInt16(Column1) <> Convert.ToInt16(Column2) Then
                            bconfirmacion = False
                        End If

                    Case "System.Byte"
                        If Convert.ToInt16(Column1) <> Convert.ToInt16(Column2) Then
                            bconfirmacion = False
                        End If

                    Case "System.Boolean"
                        If Convert.ToBoolean(Column1) <> Convert.ToBoolean(Column2) Then
                            bconfirmacion = False
                        End If

                    Case "System.DateTime"
                        If Comunes.Comun.ClsTools.NumeroJuliano(Convert.ToDateTime(Column1)) <> Comunes.Comun.ClsTools.NumeroJuliano(Convert.ToDateTime(Column2)) Then
                            bconfirmacion = False
                        End If

                    Case "System.Double"
                        If Convert.ToDouble(Column1) <> Convert.ToDouble(Column2) Then
                            bconfirmacion = False
                        End If

                    Case "System.Decimal"
                        If Convert.ToDecimal(Column1) <> Convert.ToDecimal(Column2) Then
                            bconfirmacion = False
                        End If

                End Select

            Else

                If (Not Column1 Is System.DBNull.Value And Column2 Is System.DBNull.Value) Or (Column1 Is System.DBNull.Value And Not Column2 Is System.DBNull.Value) Then
                    bconfirmacion = False
                End If

            End If

            CompararColumnas = bconfirmacion

        End Function

        Public Shared Function ValidaDescuentoCascada(ByVal prmValorDescuento As String, ByRef prmRow As Object, ByVal prmColumna_cDescuentoNegociado As String, ByVal prmColumna_nDescuentoNegociado As String, ByRef prmMsgError As String) As Boolean
            If prmRow Is Nothing Then
                Return False
            End If

            Dim nDctoEnCascada As Decimal = 0

            prmRow(prmColumna_cDescuentoNegociado) = prmValorDescuento
            prmRow(prmColumna_nDescuentoNegociado) = CalculaDescuentoCascada(prmValorDescuento, prmMsgError)


            If IfNull(prmRow(prmColumna_nDescuentoNegociado), 0) > 100 Then
                MessageBox.Show(ClsTools.GlobalSistemaErrorDescuentoCascada, ClsTools.GlobalSistemaCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                prmRow(prmColumna_cDescuentoNegociado) = ""
                prmRow(prmColumna_nDescuentoNegociado) = 0.0
                Return False
            End If


            If Not prmMsgError.Trim = "" Then
                prmRow(prmColumna_cDescuentoNegociado) = ""
                prmRow(prmColumna_nDescuentoNegociado) = 0
                Return False
            End If

            If Not prmValorDescuento.Trim.Length > 0 Then
                Return True
            End If


            Return True

        End Function


        Public Shared Function RegresaValoresEnCadena(ByVal prmCatalogo As Catalogo, Optional ByVal prmAplicaValorCastInteger As Boolean = False) As String
            Dim vDt As New DataTable
            Dim vcSql As String = " SELECT " & prmCatalogo.MetaCatalogoBase.CampoPrimario & " FROM " & prmCatalogo.MetaCatalogoBase.SqlVistaCatalogo.Trim & " (NOLOCK) "
            vcSql &= " WHERE 1 = 1 "
            If Not prmCatalogo.FiltroExtendido.Trim = "" Then
                vcSql &= " AND " & prmCatalogo.FiltroExtendido.Trim
            End If
            DAO.RegresaConsultaSQL(vcSql, vDt)
            If vDt Is Nothing OrElse vDt.Rows.Count = 0 Then
                Return "0"
            End If
            Return ClsTools.RegresaValoresEnCadena(vDt, prmCatalogo.MetaCatalogoBase.CampoPrimario.Trim, , , prmAplicaValorCastInteger)
        End Function
        Public Shared Function RegresaValoresEnCadena(ByVal prmDataTable As DataTable, ByVal prmCampo As String, Optional ByVal prmFiltro As String = "", Optional ByVal prmDelimitador As String = ",", Optional ByVal prmAplicaValorCastInteger As Boolean = False) As String
            If prmDataTable Is Nothing Then Return ""
            Dim vcCadena As String = ""
            For Each dr As DataRow In prmDataTable.Select(prmFiltro)
                If vcCadena.Trim = "" Then
                    If prmAplicaValorCastInteger Then
                        vcCadena = CInt(dr(prmCampo))
                        Continue For
                    End If
                    vcCadena = dr(prmCampo)
                Else
                    If prmAplicaValorCastInteger Then
                        vcCadena &= "," & CInt(dr(prmCampo))
                        Continue For
                    End If
                    vcCadena &= "," & dr(prmCampo)
                End If
            Next
            Return vcCadena
        End Function


        Public Shared Function ObtenReporteGuardado(ByVal prmReporte As Integer) As ArrayList
            'Regresa una colección de Reportes Guardados
            'Obtiene reporte a partir del folio del mismo
            Dim DtReporte As New DataTable
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vlsql As String = ""
            Dim vRes As New ArrayList

            vlsql = "SELECT * FROM ADSUM_ReporteExpressGuarda(NOLOCK)" & vbCr
            vlsql &= "WHERE bActivo=1 and nReporte=" & prmReporte.ToString.Trim

            DAO.RegresaConsultaSQL(vlsql, DtReporte)

            If DtReporte.Rows.Count = 0 Then
                Return Nothing
            End If

            For Each vRowReporteGuardado As DataRow In DtReporte.Rows
                vRes.Add(ObtenReporteGuardado(vRowReporteGuardado))
            Next

            Return vRes
        End Function

        Public Shared Function FGTruncaNumeroDecimal(ByVal prmNumero As Decimal, ByVal prmTotalDecimales_a_Mostrar As Int32) As Decimal
            Dim cNumero As String = prmNumero.ToString
            Dim nPosicionPunto As Int32 = InStr(cNumero, ".")
            If nPosicionPunto = 0 Then Return prmNumero
            'Si trae Punto Decimal
            If (nPosicionPunto + prmTotalDecimales_a_Mostrar) > cNumero.Length - 1 Then Return prmNumero
            cNumero = cNumero.Substring(0, nPosicionPunto + prmTotalDecimales_a_Mostrar)
            Return CDec(cNumero)
        End Function

        Public Shared Function ObtenReporteGuardado(ByVal prmrow As DataRow) As Comunes.Comun.ClsReporteGuarda
            If prmrow Is Nothing Then
                Return Nothing
            End If

            Dim prmobj As New ClsReporteGuarda()
            prmobj.Folio = prmrow("nReporteGuarda")
            prmobj.Reporte = FabricaReportes.ObtenReportes(prmrow("nReporte"))
            prmobj.Descripcion = prmrow("cNombreReporte")
            prmobj.TituloReporte = prmrow("cTitutoReporte")
            Dim c As New IO.StringReader(prmrow("cconfiguracion"))
            prmobj.aDataset.ReadXml(c, XmlReadMode.Auto)
            If Not prmrow("ccamporelativo") Is DBNull.Value Then
                prmobj.CampoRelativo = prmrow("ccamporelativo")
            End If
            prmobj.Usuario = prmrow("cUsuario")
            prmobj.Fecha = prmrow("dFecha")
            prmobj.Publico = prmrow("bPublico")

            Return prmobj
        End Function

        Enum eTablasReporte
            '--------------------------------------------------
            'Este valor del enum está destinado para referirse a la configuración completa de un Batch (selección, agrupador, etc)
            ConfiguraciónCompletaBatch = -1
            '--------------------------------------------------
            CamposSeleccionBatch = 0
            CamposAgrupacionBatch = 1
            CamposOrdenacionBatch = 2
            CamposTotalesBatch = 3
            CamposTodosReporte = 4
            CamposFiltrosBatch = 5
        End Enum

        'Public Shared Function FGExisteColumnaEnTabla(ByVal prmReporte As Integer, ByRef PrmTablaValidar As Integer, ByRef prmReporteEnMemory As ClsReporteGuarda) As Boolean
        '    'Elaboró:     César Octavio Niebla Manjarrez 
        '    'Fecha:       14-Julio-2009
        '    'Que Hace:    Regresa un valor indicando si una columna se encuentra en  
        '    'Parámetros:  El parámetro PrmTablaValidar se refiere al tipo eTablasReporte
        '    '------------------------------------------------------------------------------
        '    'Objeto mediante el cual se obtiene el reporte con sus batch's correspondiente:
        '    Dim ObjReporteGuardado As Comunes.Comun.ClsReporteGuarda

        '    'Se obtiene el reporte solo en caso de no haberlo cargado previamente
        '    'Ya que esta función necesita ser invocada N Veces

        '    If prmReporteEnMemory Is Nothing Then
        '        ObjReporteGuardado = ObtenReporteGuardado(prmReporte)
        '    Else
        '        ObjReporteGuardado = prmReporteEnMemory
        '    End If

        '    If ObjReporteGuardado Is Nothing Then
        '        'El reporte no existe
        '        Return False
        '    End If


        '    'Realizamos la validación 

        '    'For Each vRow As DataRow In ObjReporteGuardado.aDataset.Tables(PrmTablaValidar)
        '    '    'For Each vCol As DataColumn  In 

        '    'Next



        '    'Asignamos la instancia al objeto recibido por referencia como parámetro, para futuras invocaciones
        '    prmReporteEnMemory = ObjReporteGuardado

        '    Return False
        'End Function

        Public Shared Function FGValidaColumnasDataSourceConReporteGuardado(ByRef PrmDataSource As System.Data.DataColumnCollection, ByRef prmReporte As Integer, ByVal PrmTablaValidar As Integer) As Boolean
            'Elaboró:     César Octavio Niebla Manjarrez 
            'Fecha:       14-Julio-2009
            'Que Hace:    Regresa un valor indicando si el origen de datos (DataSource) 
            '             contempla todas las columnas referenciadas en los reportes guardados(Batch's) 
            '             de un folio de reporte determinado
            'Parámetros:  PrmDataSource = Son las columnas que genera el origen de dato
            '             PrmnReporte = Folio del reporte con respecto al cual se validarán las columnas del PrmDataSource
            '             PrmTablaValidar = Se refiere al tipo eTablasReporte
            '------------------------------------------------------------------------------
            'Objeto mediante el cual se obtiene el reporte con sus batch's correspondiente:

            Dim objContieneReportesGuardados As New ArrayList

            objContieneReportesGuardados = ObtenReporteGuardado(prmReporte)

            If objContieneReportesGuardados Is Nothing Then
                'El reporte no tiene batchs guardados
                Return True
            End If

            Dim vbExiste As Boolean = False
            Dim vColumna As Integer = 0
            'Realizamos la validación  de las columnas de cada uno de los batch's (reportes guardados)
            If Not PrmTablaValidar = eTablasReporte.ConfiguraciónCompletaBatch Then
                '1.-Ciclo para recorrer cada uno de los Batch activos del reporte
                For Each ObjReporteGuardado As ClsReporteGuarda In objContieneReportesGuardados.ToArray
                    vColumna += 1
                    '2.-Ciclo para recorrer cada una de las columnas del batch en cuestión
                    For Each vRow As DataRow In ObjReporteGuardado.aDataset.Tables(PrmTablaValidar).Rows
                        vbExiste = False
                        For vnCol As Integer = 0 To PrmDataSource.Count - 1
                            If PrmDataSource.Item(vnCol).Caption.Trim.ToUpper = vRow.Item(0).ToString.Trim.ToUpper Then
                                'Si existe columna
                                vbExiste = True
                                Exit For
                            End If
                        Next

                        If Not vbExiste Then
                            Exit For
                        End If
                    Next
                    If Not vbExiste Then
                        Exit For
                    End If
                Next
            End If

            Return vbExiste
        End Function


        Public Shared Function ElementoValidoATX(ByVal prmObjeto As AccTextBoxAdvanced, Optional ByVal prmEsFolio As Boolean = False) As Boolean
            If prmObjeto.ValidayObtenDescripcion = "" And prmObjeto.Text.Trim <> "" Then
                MessageBox.Show(IIf(prmEsFolio, GlobalSistemaFolioNoExiste, GlobalSistemaCodigoNoExiste), GlobalSistemaCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                prmObjeto.Text = ""
                PonFoco(prmObjeto)
                Return False
            End If
            Return True
        End Function

        Public Shared Function SeparaCadenaConApostrofes(ByVal prmCadena As String) As String
            If prmCadena.Trim = "" Then Return ""
            Dim vResultado As String = ""
            For Each vstr As String In prmCadena.Split(",")
                vResultado &= "'" & vstr.Trim & "',"
            Next
            If vResultado.Trim = "" Then Return ""
            Return vResultado.Substring(0, vResultado.Length - 1)
        End Function



        Public Shared Function FGDevuelveFechaFormateada(ByVal prmFecha As Date, ByVal prmCaracterSeparacion As String, ByVal prmFormato As FormatoFecha) As String
            Dim vFecha As String = ""
            Select Case prmFormato
                Case FormatoFecha.YMD
                    vFecha &= Format(prmFecha.Year, "0000")
                    vFecha &= prmCaracterSeparacion.Trim
                    vFecha &= Format(prmFecha.Month, "00")
                    vFecha &= prmCaracterSeparacion.Trim
                    vFecha &= Format(prmFecha.Day, "00")
                Case FormatoFecha.DMY
                    vFecha &= Format(prmFecha.Day, "00")
                    vFecha &= prmCaracterSeparacion.Trim
                    vFecha &= Format(prmFecha.Month, "00")
                    vFecha &= prmCaracterSeparacion.Trim
                    vFecha &= Format(prmFecha.Year, "0000")
            End Select
            Return vFecha
        End Function

        Public Shared Function ObtenTiposArticulosPermitidos() As String
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Return DAO.RegresaDatoSQL("SELECT dbo.ObtenTiposArticulosPermitidos ('" & DAO.GetLoginUsuario & "')")
        End Function


        Public Shared Function ObtenFoliosClaves_ParaCadenaClavesProduccion(ByVal prmCadenaClaves As String) As String
            If prmCadenaClaves.Trim = "" Then Return ""
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vDt As New DataTable
            Dim vcSQL As String = "SELECT CP.nCodigo FROM CTL_CodigosProduccion CP (NOLOCK) " & vbCr
            vcSQL &= "  INNER JOIN dbo.ADSUM_StringEnRows('" & prmCadenaClaves & "') T ON T.cValor = CP.cDescripcion " & vbCr
            vcSQL &= " WHERE CP.bActivo = 1"
            If Not DAO.RegresaConsultaSQL(vcSQL, vDt) Then Return ""
            If vDt Is Nothing OrElse vDt.Rows.Count = 0 Then Return ""
            Return ClsTools.RegresaValoresEnCadena(vDt, "nCodigo")
        End Function
        Public Shared Function ObtenFoliosArticulos_ParaCadenaCodigosArticulos(ByVal prmCadena As String) As String
            If prmCadena.Trim = "" Then Return ""
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim ds As New DataSet
            Dim param(0) As Object
            param(0) = prmCadena
            DAO.RegresaConsultaSQL("SP_TransformaCadenaArticulos", ds, param)
            If ds Is Nothing OrElse ds.Tables.Count = 0 OrElse ds.Tables(0).Rows.Count = 0 Then
                Return ""
            End If
            Return ds.Tables(0).Rows(0)(0)
        End Function

        Public Shared Function ObtenCodigosArticulos_ParaCadenaCodigosArticulos(ByVal prmCadena As String) As String
            If prmCadena.Trim = "" Then Return ""
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim ds As New DataSet
            Dim param(0) As Object
            param(0) = prmCadena
            DAO.RegresaConsultaSQL("SP_TransformaFoliosACodigosArticulos", ds, param)
            If ds Is Nothing OrElse ds.Tables.Count = 0 OrElse ds.Tables(0).Rows.Count = 0 Then
                Return ""
            End If
            Return ds.Tables(0).Rows(0)(0)
        End Function

        Public Shared Function ObtenFoliosProductos_ParaCadenaCodigosProductos(ByVal prmCadena As String) As String
            If prmCadena.Trim = "" Then Return ""
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim ds As New DataSet
            Dim param(0) As Object
            param(0) = prmCadena
            DAO.RegresaConsultaSQL("SP_TransformaCadenaProductos", ds, param)
            If ds Is Nothing OrElse ds.Tables.Count = 0 OrElse ds.Tables(0).Rows.Count = 0 Then
                Return ""
            End If
            Return ds.Tables(0).Rows(0)(0)
        End Function

        Public Shared Function ObtenLoginEmpleado(ByVal prmEmpleado As Catalogos.ClsEmpleado) As String
            If prmEmpleado Is Nothing Then Return "1=0"
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vSql As String = ""
            Dim dt As New DataTable
            vSql = "SELECT TOP 1 cLogin FROM ADSUM_Usuarios (NOLOCK)" & vbCr
            vsql &= " WHERE npersonal = " & prmEmpleado.Folio
            DAO.RegresaConsultaSQL(vsql, dt)
            If dt Is Nothing OrElse dt.Rows.Count = 0 Then Return "1=0"
            If Not dt.Rows(0)("cLogin") Is DBNull.Value AndAlso Not dt.Rows(0)("cLogin") = "" Then
                Return dt.Rows(0)("cLogin")
            End If
            Return "1=0"
        End Function

        Public Shared Function ObtenEmpleadoParaLogin(ByVal prmLogin As String) As String
            If prmLogin.Trim = "" Then Return ""
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vSql As String = ""
            Dim dt As New DataTable
            vSql = "SELECT top 1 ltrim(rtrim(isnull(EMP.cNombre,''))) + ' ' + isnull(EMP.cApellidoPaterno,'') + ' ' + isnull(EMP.cApellidoMaterno,'') as cEmpleado" & vbCr
            vSql &= " FROM ADSUM_Usuarios AU (NOLOCK)" & vbCr
            vSql &= " INNER JOIN CTL_Empleados EMP (NOLOCK)" & vbCr
            vSql &= " ON EMP.nEmpleado = AU.nPersonal" & vbCr
            vSql &= " WHERE cLogin = '" & prmLogin.Trim & "'"
            DAO.RegresaConsultaSQL(vSql, dt)
            If dt Is Nothing OrElse dt.Rows.Count = 0 Then Return ""
            Return IfNull(dt.Rows(0)(0), "")
        End Function
        Public Shared Function ObtenEmpleadoParaLogin() As Int32
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vSql As String = ""
            vSql = "SELECT nPersonal " & vbCr
            vSql &= " FROM ADSUM_Usuarios AU (NOLOCK)" & vbCr
            vSql &= " WHERE cLogin = '" & DAO.GetLoginUsuario & "'"
            Return DAO.RegresaDatoSQL(vSql)
        End Function
        Public Shared Function ObtenNombreLogin(ByVal prmLogin As String) As String
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vSql As String = ""

            vSql = "SELECT cNombre " & vbCr
            vSql &= " FROM ADSUM_Usuarios AU (NOLOCK)" & vbCr
            vSql &= " WHERE cLogin = '" & prmLogin & "'"
            Return DAO.RegresaDatoSQL(vSql)
        End Function
        Public Shared Function ObtenLlavePrimariaDeTabla(ByVal cTabla As String) As DataTable
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vSql As String = ""
            Dim dt As New DataTable

            vSql = "SELECT C.Name AS cCampoLLave  FROM Sysobjects AS O(NOLOCK)" & vbCrLf
            vSql &= " INNER JOIN Syscolumns AS C(NOLOCK) ON (O.ID = C.ID AND O.id = OBJECT_ID('" & cTabla & "'))" & vbCrLf
            vSql &= " INNER JOIN SysTypes AS TIPOS(NOLOCK) ON (C.xType = TIPOS.xType)" & vbCrLf
            vSql &= "  INNER JOIN Sysindexes AS I(NOLOCK) ON (O.ID = I.ID AND " & vbCrLf
            vSql &= "(I.Status & 0x800) = 0x800) INNER JOIN Syscolumns AS C1(NOLOCK) " & vbCrLf
            vSql &= "ON (O.ID = C1.ID AND c.Name=Index_Col('" & cTabla & "',i.indid, c1.colid))ORDER BY C.Colid "

            DAO.RegresaConsultaSQL(vSql, dt)
            Return dt
        End Function
        'Public Shared Function Obten(ByVal cTabla As String) As DataTable
        '    Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        '    Dim vSql As String = ""
        '    Dim dt As New DataTable

        '    vSql = "SELECT C.Name AS cCampoLLave  FROM Sysobjects AS O(NOLOCK)" & vbCrLf
        '    vSql &= " INNER JOIN Syscolumns AS C(NOLOCK) ON (O.ID = C.ID AND O.id = OBJECT_ID(" & cTabla & "))" & vbCrLf
        '    vSql &= " INNER JOIN SysTypes AS TIPOS(NOLOCK) ON (C.xType = TIPOS.xType)" & vbCrLf
        '    vSql &= "  INNER JOIN Sysindexes AS I(NOLOCK) ON (O.ID = I.ID AND " & vbCrLf
        '    vSql &= "(I.Status & 0x800) = 0x800) INNER JOIN Syscolumns AS C1(NOLOCK) " & vbCrLf
        '    vSql &= "ON (O.ID = C1.ID AND c.Name=Index_Col(" & cTabla & ",i.indid, c1.colid))ORDER BY C.Colid "

        '    DAO.RegresaConsultaSQL(vSql, dt)
        '    Return dt
        'End Function
        ' ''Public Shared Function ObtenEmpleadoConLogin(ByVal prmLogin As String) As Catalogos.ClsEmpleado
        ' ''    If prmLogin.Trim = "" Then Return Nothing
        ' ''    Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''    Dim vSql As String = ""
        ' ''    Dim dt As New DataTable
        ' ''    Dim res As Catalogos.ClsEmpleado
        ' ''    vSql = "SELECT EMP.*" & vbCr
        ' ''    vSql &= " FROM ADSUM_Usuarios AU (NOLOCK)" & vbCr
        ' ''    vSql &= " INNER JOIN CTL_Empleados EMP (NOLOCK)" & vbCr
        ' ''    vSql &= " ON EMP.nEmpleado = AU.nPersonal" & vbCr
        ' ''    vSql &= " WHERE cLogin = '" & prmLogin.Trim & "'"
        ' ''    DAO.RegresaConsultaSQL(vSql, dt)
        ' ''    If dt Is Nothing OrElse dt.Rows.Count = 0 Then Return Nothing

        ' ''    res = Catalogos.FabricaCatalogos.ObtenEmpleado(dt.Rows(0).Item("nEmpleado"))

        ' ''    Return res
        ' ''End Function

        Public Shared Function fgRegresaFechaConHora(ByVal prmFecha As Date, Optional ByVal prmSegundo As Integer = 0) As Date
            Dim vFecha As Date
            vFecha = New Date(prmFecha.Year, prmFecha.Month, prmFecha.Day, FechaDelSistema.Hour, FechaDelSistema.Minute, FechaDelSistema.Second + prmSegundo)
            Return vFecha
        End Function

        Public Shared Function fgRegresaRutaImpresora(ByVal prmImpresora As Integer) As String

            Dim vRuta As String
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim DT As New DataTable
            Dim vSQL As String
            Dim vResultado As Boolean

            vRuta = ""

            vSQL = "Select cRuta From IMP_Impresoras(NoLock)"
            vSQL &= "Where nImpresora = " & prmImpresora

            vResultado = DAO.RegresaConsultaSQL(vSQL, DT)

            If Not DT Is Nothing Then
                If DT.Rows.Count > 0 Then
                    vRuta = DT.Rows(0).Item(0)
                End If
            End If

            Return vRuta

        End Function

        Public Shared Function fgTraeSecuenciasDeImpresora(ByVal prmImpresora As Integer, ByVal prmCPI As Integer, ByVal prmLPI As Integer, _
        ByVal prmOrientacion As CDT_OrientacionDeHoja, Optional ByRef prmTipoImpresora As Integer = 0, _
        Optional ByVal prmInicializa As Boolean = False, Optional ByRef prmSecuenciaHeight As Integer = 0) As String


            Dim DT As New DataTable
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vSQL As String
            Dim vResultado As Boolean
            Dim vSecuencia As String

            fgTraeSecuenciasDeImpresora = ""
            vSecuencia = ""


            vSQL = "Select I.*,T.*"
            vSQL &= vbCrLf & "From IMP_Impresoras I(NoLock)"
            vSQL &= vbCrLf & "Join IMP_TiposEmulacion T(NoLock) On T.nTipoEmulacion = I.nTipoEmulacion"
            vSQL &= vbCrLf & "Where I.nImpresora = " & prmImpresora

            vResultado = DAO.RegresaConsultaSQL(vSQL, DT)

            If Not DT Is Nothing Then
                If Not DT.Rows.Count = 0 Then
                    If prmInicializa Then
                        If Not DT.Rows(0).Item("cCaracterControlInicializar") Is DBNull.Value Then
                            vSecuencia &= fgCodesToChar(Trim(DT.Rows(0).Item("cCaracterControlInicializar")))
                        End If

                        If Not DT.Rows(0).Item("nTipoImpresora") Is DBNull.Value Then
                            prmTipoImpresora = DT.Rows(0).Item("nTipoImpresora")
                        End If
                    End If

                    Select Case prmCPI
                        Case 10
                            If Not DT.Rows(0).Item("cCpi10") Is DBNull.Value Then
                                vSecuencia &= fgCodesToChar(Trim(DT.Rows(0).Item("cCpi10")))
                            End If
                        Case 12
                            If Not DT.Rows(0).Item("cCpi12") Is DBNull.Value Then
                                vSecuencia &= fgCodesToChar(Trim(DT.Rows(0).Item("cCpi12")))
                            End If
                        Case 17
                            If Not DT.Rows(0).Item("cCpi17") Is DBNull.Value Then
                                vSecuencia &= fgCodesToChar(Trim(DT.Rows(0).Item("cCpi17")))
                            End If
                    End Select

                    Select Case prmLPI
                        Case 6
                            If Not DT.Rows(0).Item("cLpi6") Is DBNull.Value Then
                                vSecuencia &= fgCodesToChar(Trim(DT.Rows(0).Item("cLpi6")))
                            End If
                        Case 8
                            If Not DT.Rows(0).Item("cLpi8") Is DBNull.Value Then
                                vSecuencia &= fgCodesToChar(Trim(DT.Rows(0).Item("cLpi8")))
                            End If
                    End Select

                    If prmOrientacion <> 0 Then
                        Select Case True
                            Case prmOrientacion = CDT_OrientacionDeHoja.CDT_OrientacionDeHoja_Horizontal
                                If Not DT.Rows(0).Item("cOrientacionH") Is DBNull.Value Then
                                    vSecuencia &= fgCodesToChar(Trim(DT.Rows(0).Item("cOrientacionH")))
                                End If
                            Case prmOrientacion = CDT_OrientacionDeHoja.CDT_OrientacionDeHoja_Vertical
                                If Not DT.Rows(0).Item("cOrientacionV") Is DBNull.Value Then
                                    vSecuencia &= fgCodesToChar(Trim(DT.Rows(0).Item("cOrientacionV")))
                                End If
                        End Select
                    End If
                End If

            End If
            fgTraeSecuenciasDeImpresora = vSecuencia
            Return fgTraeSecuenciasDeImpresora
        End Function

        Public Shared Function fgCodesToChar(ByVal Codes As String) As String
            Dim SpacePos As Long
            Dim StartSearchAt As Long
            Dim LastSpacePos As Long
            Dim Converted As String

            SpacePos = 1
            StartSearchAt = 1
            LastSpacePos = 0
            Converted = ""
            Codes = Trim(Codes)

            Do
                SpacePos = InStr(StartSearchAt, Codes, " ", CompareMethod.Text)
                If SpacePos > 0 Then
                    Converted = Converted & Chr(Val(Mid(Codes, LastSpacePos + 1, SpacePos - (LastSpacePos + 1))))
                    LastSpacePos = SpacePos
                    StartSearchAt = SpacePos + 1
                Else
                    Converted = Converted & Chr(Val(Mid(Codes, StartSearchAt, Len(Codes) - StartSearchAt + 1)))
                End If
            Loop While SpacePos > 0

            fgCodesToChar = Converted
            Return fgCodesToChar
        End Function

        Public Shared Function ConvertDecimalSecuences(ByVal Codigo As String) As String
            'Elaboro CRESPO
            'Fecha: 31-may-2002
            Dim I As Integer

            For I = 1 To Len(Codigo)
                ConvertDecimalSecuences = ConvertDecimalSecuences & "0" & Asc(Mid(Codigo, I, 1)) & " "
            Next
            ConvertDecimalSecuences = Left(ConvertDecimalSecuences, Len(ConvertDecimalSecuences) - 1)

        End Function


        Public Shared Function ValidaATXCantidad(ByVal prmCantidad As String) As Boolean
            If prmCantidad.Trim = "" Then Return True
            prmCantidad = Replace(prmCantidad, ",", "")
            If Not IsNumeric(prmCantidad.Trim) Then Return False
            'SI EXISTE PUNTO DECIMAL, VALIDA QUE LOS ENTEROS SEAN MAXIMO 7
            If Not InStr(prmCantidad.Trim, ".") = 0 Then
                For i As Int32 = 0 To prmCantidad.Length - 1
                    If prmCantidad.Chars(i) = "." Then
                        If i > 7 Then
                            ClsTools.MuestraMensajeSistFact("El formato para la cantidad debe estar entre lo permitido 0,000,000.00", Windows.Forms.MessageBoxIcon.Exclamation)
                            Return False
                        End If
                    End If
                Next
                Dim j As Int32 = 0
                For i As Int32 = InStr(prmCantidad.Trim, ".") - 1 To prmCantidad.Trim.Length - 1
                    If j > 2 Then
                        ClsTools.MuestraMensajeSistFact("El formato para la cantidad debe estar entre lo permitido 0,000,000.00", Windows.Forms.MessageBoxIcon.Exclamation)
                        Return False
                    End If
                    j += 1
                Next
            End If

            'SI NO EXISTE PUNTO DECIMAL,VALIDA QUE LOS ENTEROS SEAN MAXIMO 7
            If InStr(prmCantidad.Trim, ".") = 0 Then
                For i As Int32 = 0 To prmCantidad.Trim.Length - 1
                    If i > 6 Then
                        ClsTools.MuestraMensajeSistFact("El formato para la cantidad debe estar entre lo permitido 0,000,000.00", Windows.Forms.MessageBoxIcon.Exclamation)
                        Return False
                    End If
                Next
            End If

            Return True
        End Function

        Public Shared Sub pgCreaDTEncabezadoPoliza(ByRef prmDataTable As DataTable)
            prmDataTable = Nothing
            prmDataTable = New DataTable
            With prmDataTable.Columns
                .Add("nPlaza", GetType(Integer))
                .Add("nTipoPoliza", GetType(Integer))
                .Add("dFecha", GetType(Date))
                .Add("nImporte", GetType(Decimal))
                .Add("cBeneficiario", GetType(String))
                .Add("cConcepto", GetType(String))
                .Add("cReferencia", GetType(String))
                .Add("cSistema", GetType(String))
            End With
        End Sub
        Public Shared Sub pgCreaDTDetallePoliza(ByRef prmDataTable As DataTable)
            prmDataTable = Nothing
            prmDataTable = New DataTable
            With prmDataTable.Columns
                .Add("nNivel1", GetType(Integer))
                .Add("nNivel2", GetType(Integer))
                .Add("nNivel3", GetType(Integer))
                .Add("nNivel4", GetType(Integer))
                .Add("nNivel5", GetType(Integer))
                .Add("cDesconcepto", GetType(String))
                .Add("nCargo", GetType(Decimal))
                .Add("nAbono", GetType(Decimal))
                .Add("cReferencia", GetType(String))
                .Add("nCuentaCnt", GetType(Long))
                .Add("nRenglon", GetType(Integer))
                .Add("cColor", GetType(String))
            End With
        End Sub
        Public Shared Function FGConvierteCadena_a_FoliosArticulos(ByVal prmCadenaCodigosArticulos As String) As String
            If prmCadenaCodigosArticulos.Trim = "" Then
                Return prmCadenaCodigosArticulos
            End If
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim Param(0) As Object
            Dim ds As New DataSet
            Param(0) = prmCadenaCodigosArticulos
            DAO.RegresaConsultaSQL("SP_TransformaCadenaArticulos", ds, Param)
            prmCadenaCodigosArticulos = ""
            If Not ds Is Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                prmCadenaCodigosArticulos = ds.Tables(0).Rows(0)(0)
            End If
            Return prmCadenaCodigosArticulos
        End Function


        '' Nota: La llave primaria de ser de un solo campo, y la tabla debe de tener el campo cDescripcion
        Public Shared Sub PgLlenaComboSelect(ByVal prmCombo As System.Windows.Forms.ComboBox, ByVal prmTabla As String)

            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vResultado As Boolean
            Dim DT As New DataTable
            Dim DTColumn() As DataColumn

            If prmTabla.Trim = "" Then
                Exit Sub
            End If

            DAO.RegresaEsquemaDeDatos(" Select * From " & prmTabla & " (NOLOCK) Where 1=0", DT)
            DTColumn = DT.PrimaryKey

            If DTColumn Is Nothing Then
                Exit Sub
            End If

            If DT.Columns.Count = 0 Then
                Exit Sub
            End If

            vResultado = DAO.RegresaConsultaSQL("Select cDescripcion," & DTColumn(0).ColumnName & " From " & prmTabla & "(NoLock) Where bActivo = 1", prmCombo)

        End Sub


        Public Shared Function FGConvierteCadena_a_FoliosProductos(ByVal prmCadenaCodigosProductos As String) As String
            If prmCadenaCodigosProductos.Trim = "" Then
                Return prmCadenaCodigosProductos
            End If
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim Param(0) As Object
            Dim ds As New DataSet
            Param(0) = prmCadenaCodigosProductos
            DAO.RegresaConsultaSQL("SP_TransformaCadenaProductos", ds, Param)
            prmCadenaCodigosProductos = ""
            If Not ds Is Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                prmCadenaCodigosProductos = ds.Tables(0).Rows(0)(0)
            End If
            Return prmCadenaCodigosProductos
        End Function


        Public Shared Sub MuestraMensajeSistFact(ByVal prmMensaje As String, ByVal prmIcono As System.Windows.Forms.MessageBoxIcon)
            MessageBox.Show(prmMensaje, GlobalSistemaCaption, MessageBoxButtons.OK, prmIcono)
        End Sub
        Public Shared Function MuestraMensajeSistFactConfirmacion(ByVal prmMensaje As String, Optional ByVal prmBotonYesDefault As Boolean = True) As Boolean
            If prmBotonYesDefault Then
                Return MessageBox.Show(prmMensaje, GlobalSistemaCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
            Else
                Return MessageBox.Show(prmMensaje, GlobalSistemaCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes
            End If
        End Function

        Public Shared Function ConfirmaLimpiarPantalla() As DialogResult
            Return MessageBox.Show(Comun.ClsTools.GlobalSistemaLimpiarPantalla, Comun.ClsTools.GlobalSistemaCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        End Function
        Public Shared Function ConfirmaCancelar() As DialogResult
            Return MessageBox.Show(Comun.ClsTools.GlobalSistemaConfirmaCancelarDato, Comun.ClsTools.GlobalSistemaCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        End Function
        Public Shared Function ConfirmaGuardar() As DialogResult
            Return MessageBox.Show(Comun.ClsTools.GlobalSistemaConfirmaGuardarDato, Comun.ClsTools.GlobalSistemaCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        End Function
        Public Shared Sub PGManejaLogisticaGrid(ByRef prmVistaGrid As Object, ByVal prmDataTale As DataTable, ByVal e As System.Windows.Forms.KeyEventArgs, ByRef prmColumnaAnterior As Object, ByRef prmControlAnteriorFoco As Object, ByRef prmColumnaSiguiente As Object, ByRef prmControlSiguienteFoco As Object)
            If prmVistaGrid.isfocusedview Then
                If prmDataTale.Rows.Count > 0 Then
                    If (e.KeyCode = Keys.Escape OrElse (e.Shift = True AndAlso e.KeyCode = Keys.Tab)) AndAlso prmVistaGrid.FocusedColumn Is prmColumnaAnterior Then
                        If prmVistaGrid.FocusedRowHandle = 0 Then
                            prmControlAnteriorFoco.Focus()
                        End If
                        Exit Sub
                    End If
                End If
            End If

            If prmVistaGrid.isfocusedview Then
                If prmDataTale.Rows.Count > 0 Then
                    If (e.KeyCode = Keys.Tab) AndAlso prmVistaGrid.FocusedColumn Is prmColumnaSiguiente Then
                        If prmVistaGrid.FocusedRowHandle = prmDataTale.Rows.Count - 1 Then
                            prmControlSiguienteFoco.Focus()
                        End If
                    End If
                End If
            End If

        End Sub
        Public Shared Sub PGCamposFaltantes(ByRef prmControl As Object, ByRef prmFaltanCampos As String, ByRef prmMandoFoco As Boolean, Optional ByVal prmPinta As Boolean = True)
            If prmControl.GetType.ToString = "Access.AccTextBoxAdvanced" Then
                If prmControl.Text.Trim = "" Then
                    prmFaltanCampos &= prmControl.Tag & vbCr
                    If prmPinta Then
                        prmControl.BackColor = Color.Yellow
                    End If
                    If Not prmMandoFoco Then
                        prmControl.Focus()
                        prmMandoFoco = True
                    End If
                End If
            End If
            If prmControl.GetType.ToString = "System.Windows.Forms.ComboBox" Then
                If prmControl.SelectedValue = 0 Then
                    prmFaltanCampos &= prmControl.Tag & vbCr
                    If prmPinta Then
                        prmControl.BackColor = Color.Yellow
                    End If
                    If Not prmMandoFoco Then
                        prmControl.Focus()
                        prmMandoFoco = True
                    End If
                End If
            End If
        End Sub

        Public Shared Function FGDameCodigosBarraRelacionados(ByVal prmnCodigoBarra As Long) As String
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim dt As New DataTable
            Dim vSql As String = ""
            vSql = "SELECT dbo.DameCodBarRelacionados(" & prmnCodigoBarra.ToString() & ")"
            DAO.RegresaConsultaSQL(vSql, dt)
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)(0)
            End If
            Return "IN (" & prmnCodigoBarra.ToString() & ")"
        End Function

        ' ''Public Shared Function PGMandaFocoControlCapturaProductos(ByRef prmControl As Produccion.Comun.AdsumCapturaProducto, ByVal e As System.Windows.Forms.KeyEventArgs) As Boolean
        ' ''    If e.KeyCode = Keys.F10 Then
        ' ''        If prmControl.Enabled Then
        ' ''            prmControl.Focus()
        ' ''            If prmControl.ManejaPedidoEspecial Then
        ' ''                If prmControl.AtxPedidoEspecialASIC.Visible Then
        ' ''                    prmControl.MandaFocoATXPedidoEspecialASIC()
        ' ''                Else
        ' ''                    prmControl.MandaFocoATXPedidoEspecial()
        ' ''                End If
        ' ''            Else
        ' ''                prmControl.MandaFocoATXCodigo()
        ' ''            End If
        ' ''        End If
        ' ''        SendKeys.Send("{ESC}")
        ' ''        SendKeys.Send("{TAB}")
        ' ''        Return True
        ' ''    End If
        ' ''    Return False
        ' ''End Function
        'Public Shared Function FGMandaFocoGrid(ByVal prmDataTable As DataTable) As Boolean
        '    Dim GrdControl As DevExpress.XtraGrid.GridControl
        '    Dim Column As Object
        '    For Each dr As DataRow In prmDataTable.Rows
        '        GrdControl = dr("GridControl")
        '        Column = dr("ColumnaDestino")
        '        If GrdControl.Enabled AndAlso Not GrdControl.Focused Then

        '        End If
        '    Next
        'End Function
        'Private Shared Function FGMandaFocoGrid_ObtieneEstructuraDataTable() As DataTable
        '    Dim dt As New DataTable
        '    dt.Columns.Add("GridControl", GetType(Object))
        '    dt.Columns.Add("ColumnaDestino", GetType(Object))
        '    Return dt
        'End Function



        Public Shared Function FGDamePrecio_COMPRA(ByVal prmDataTable As DataTable, ByVal prmPrecioNegociado As String, ByVal prmPrecioActual As String, ByVal prmPrecioLista As String, Optional ByVal prmSugerirPrecioActualAntesDePrecioLista As Boolean = False) As Decimal
            'Se agregó parámetro prmSugerirPrecioActualAntesDePrecioLista, para sugerir primero el precio actual, antes que el precio de lista
            'éste parámetro se usa, en la pantalla Orden de Compra, ya que se necesita sugerir primero el precio actual.

            Dim nPrecio As Decimal = 0

            If prmDataTable Is Nothing OrElse prmDataTable.Rows.Count = 0 Then
                Return nPrecio
            End If

            If prmDataTable.Rows.Count = 1 Then
                Dim prmRow As DataRow = prmDataTable.Rows(0)
                If Not prmRow(prmPrecioNegociado) Is DBNull.Value AndAlso nPrecio = 0 Then
                    nPrecio = prmRow(prmPrecioNegociado)
                End If
                Dim vcNombreCampoPrecio As String = prmPrecioLista
                If prmSugerirPrecioActualAntesDePrecioLista Then vcNombreCampoPrecio = prmPrecioActual
                If Not prmRow(vcNombreCampoPrecio) Is DBNull.Value AndAlso nPrecio = 0 Then
                    nPrecio = prmRow(vcNombreCampoPrecio)
                End If
                vcNombreCampoPrecio = prmPrecioActual
                If prmSugerirPrecioActualAntesDePrecioLista Then vcNombreCampoPrecio = prmPrecioLista
                If Not prmRow(vcNombreCampoPrecio) Is DBNull.Value AndAlso nPrecio = 0 Then
                    nPrecio = prmRow(vcNombreCampoPrecio)
                End If
                Return nPrecio
            End If

            If prmDataTable.Rows.Count > 1 Then
                Dim colRow() As DataRow
                colRow = prmDataTable.Select(prmPrecioNegociado & " IS NOT NULL")
                If colRow.Length > 0 Then
                    nPrecio = colRow(0)(prmPrecioNegociado)
                End If
                Dim vcNombreCampoPrecio As String = prmPrecioLista
                If prmSugerirPrecioActualAntesDePrecioLista Then vcNombreCampoPrecio = prmPrecioActual
                If nPrecio = 0 Then
                    colRow = prmDataTable.Select(vcNombreCampoPrecio & " IS NOT NULL")
                    If colRow.Length > 0 Then
                        nPrecio = colRow(0)(vcNombreCampoPrecio)
                    End If
                End If
                vcNombreCampoPrecio = prmPrecioActual
                If prmSugerirPrecioActualAntesDePrecioLista Then vcNombreCampoPrecio = prmPrecioLista
                If nPrecio = 0 Then
                    colRow = prmDataTable.Select(vcNombreCampoPrecio & " IS NOT NULL")
                    If colRow.Length > 0 Then
                        nPrecio = colRow(0)(vcNombreCampoPrecio)
                    End If
                End If
                Return nPrecio
            End If
        End Function

        Public Shared Function FGValidaUnicoElemento_en_ATXMultiple(ByVal prmCadena As String) As Boolean
            If prmCadena.Trim = "" OrElse prmCadena.Trim = "*" Then
                Return False
            End If
            Dim SoloUnArticulo As Int32 = 0
            SoloUnArticulo = InStr(prmCadena.Trim, ",")
            If SoloUnArticulo = 0 Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Enum TipoObjeto
            General = 0
            TipoMovimiento = 1
        End Enum


        Public Shared Function FGFiltrosCambiodeLinea(ByVal Filtros As String) As String

            Filtros = Filtros.ToUpper
            Dim nLongitudRenglon As Int32 = 160 'Se debería de usar un parametro admin. para este valor, así como conciderar la hoja horizontal o vertical
            If Filtros.Length > nLongitudRenglon Then
                Dim nRenglones As Int32
                nRenglones = Filtros.Length / nLongitudRenglon
                Dim i As Int32 = 1
                'No se está considerando si en la posicion en donde se concatenará el enter corta una palabra
                While i <= nRenglones
                    If Filtros.Chars(i) = "," Or Filtros.Chars(i) = ":" Or Filtros.Chars(i).ToString() = " " Then

                        If Filtros.Length > ((nLongitudRenglon * i) + 1) Then
                            Filtros = Filtros.Insert(nLongitudRenglon * i + 1, "-" & vbCrLf)
                        End If

                    Else
                        If Filtros.Length > ((nLongitudRenglon * i) + 1) Then
                            Filtros = Filtros.Insert(nLongitudRenglon * i + 1, " " & vbCrLf)
                        End If
                    End If


                    i = i + 1
                End While
            End If
            Return Filtros
        End Function


        ' ''Public Shared Function FGDevuelveObjetoCatalogo_Validado(ByVal prmObjeto As Object, ByVal prmValorRetorno As Object, ByVal prmTipoObjeto As TipoObjeto, Optional ByVal prmValidaCancelado As Boolean = True, Optional ByVal prmValidaTipoArticuloValido As Boolean = False, Optional ByVal prmTiposArticulosPermitidos As String = "", Optional ByVal prmEfecto As Inventarios.ClsTipoMovimiento.CDT_EfectoEntradaSalida = Inventarios.ClsTipoMovimiento.CDT_EfectoEntradaSalida.Entrada) As Object

        ' ''    'QUE HACE:
        ' ''    '   Realiza validaciones sobre un objeto, y en caso de no cumplir con alguna validacion, se retorna el valor que se haya indicado
        ' ''    'PARAMETROS:
        ' ''    '   prmObjeto:  Objeto de tipo catalogo
        ' ''    '   prmValorRetorno:    En caso de que el objeto no cumpla la validación, es el valor que se regresará
        ' ''    '   prmTipoObjeto:   Se especifica si es un objeto de tipo catalogo general o si es en especifico un objeto de tipo de movimiento
        ' ''    '   prmValidaCancelado: Parametro para saber si se validará si el objeto está cancelado
        ' ''    '   prmValidaTipoArticuloValido:    Parámetro para saber si se validará que el objeto sea un tipo de articulo válido 
        ' ''    '   prmTiposArticulosPermitidos:    Parámetro para conocer cuales son los tipos de articulos validos y validar el objeto sobre ellos.
        ' ''    '   prmEfecto:  Parámetro para saber el efecto a validar en el objeto tipo de movimiento
        ' ''    If prmObjeto Is Nothing Then
        ' ''        Return prmValorRetorno
        ' ''    End If
        ' ''    If prmValidaCancelado Then
        ' ''        If Not prmObjeto.Activo Then
        ' ''            Return prmValorRetorno
        ' ''        End If
        ' ''    End If
        ' ''    If prmTipoObjeto = TipoObjeto.TipoMovimiento Then
        ' ''        If Not prmObjeto.Efecto = prmEfecto Then
        ' ''            Return prmValorRetorno
        ' ''        End If
        ' ''    End If
        ' ''    Return prmObjeto
        ' ''End Function

        Public Shared Function ActualizaFechas_JOB_ROTACION(ByVal FechaInicio As Date, ByVal FechaFin As Date) As Boolean
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vSql As String

            vSql = "UPDATE ADSUM_ParametrosAdministrados SET cValor = '" & FechaInicio & "' WHERE cContexto = 'INV' AND cParametroAdministrado = 'FECHA_INICIO_JOB_ROTACION'" & vbCr
            vSql &= "UPDATE ADSUM_ParametrosAdministrados SET cValor = '" & FechaFin & "' WHERE cContexto = 'INV' AND cParametroAdministrado = 'FECHA_FIN_JOB_ROTACION'"

            If DAO.EjecutaComandoSQL(vSql) Then
                Return True
            Else
                Return False
            End If

        End Function

        Public Shared Function ExportaReporteCrystal(ByVal reporteCrystal As CrystalDecisions.CrystalReports.Engine.ReportDocument, ByVal miDataSet As System.Data.DataSet, ByVal formato As CrystalDecisions.Shared.ExportFormatType, ByVal Ruta As String, Optional ByVal nombresDeParametros As String = "", Optional ByVal valoresDeParametros As String = "")
            ExportaReporteCrystal = False
            If (reporteCrystal.DataSourceConnections.Count > 0) Then
                reporteCrystal.SetDataSource(miDataSet)
            End If
            For i As Integer = 0 To reporteCrystal.Subreports.Count - 1
                Dim miSubReporte As CrystalDecisions.CrystalReports.Engine.ReportDocument
                miSubReporte = reporteCrystal.Subreports(i)
                If (miSubReporte.DataSourceConnections.Count > 0) Then
                    miSubReporte.SetDataSource(miDataSet)
                End If
            Next
            reporteCrystal.Refresh()


            If Not nombresDeParametros.Trim = "" Then
                Dim atrParametros() As String = nombresDeParametros.Split(",")
                Dim atrValores() As String = valoresDeParametros.Split(";")
                For i As Integer = 0 To atrParametros.Length - 1
                    reporteCrystal.SetParameterValue(atrParametros(i), atrValores(i))
                Next
            End If


            reporteCrystal.ExportToDisk(formato, Ruta)
            Return True

            'Dim miFrmVisorCrystalReport As New FrmVisorCrystal
            'miFrmVisorCrystalReport.reporteCrystal = reporteCrystal

            'If (Not nombresDeParametros = "") Then
            '    Dim paramFields As New CrystalDecisions.Shared.ParameterFields()

            '    Dim arParametros() As String = nombresDeParametros.Split("'")
            '    Dim arRelacionDeValores() As String = valoresDeParametros.Split(";")

            '    For i As Integer = 0 To arParametros.GetUpperBound(0)
            '        Dim paramField As New CrystalDecisions.Shared.ParameterField()
            '        paramField.ParameterFieldName = arParametros(i)

            '        arRelacionDeValores(i) = arRelacionDeValores(i).Replace("{", "")
            '        arRelacionDeValores(i) = arRelacionDeValores(i).Replace("}", "")


            '        Dim arValores() As String = arRelacionDeValores(i).Split(",")


            '        For j As Integer = 0 To arValores.GetUpperBound(0)
            '            If (arValores(j).IndexOf("|") = -1) Then
            '                Dim discreteVal As New CrystalDecisions.Shared.ParameterDiscreteValue()
            '                discreteVal.Value = arValores(j)
            '                paramField.CurrentValues.Add(discreteVal)
            '                paramFields.Add(paramField)
            '            Else
            '                Dim arValoresDeRango() As String = arValores(j).Split(":")
            '                Dim rangeVal As New CrystalDecisions.Shared.ParameterRangeValue()
            '                rangeVal.StartValue = arValoresDeRango(0)
            '                rangeVal.EndValue = arValoresDeRango(1)
            '                paramField.CurrentValues.Add(rangeVal)
            '                arValoresDeRango = Nothing
            '            End If
            '        Next
            '        arValores = Nothing
            '    Next
            '    miFrmVisorCrystalReport.CrystalReportViewer1.ParameterFieldInfo = paramFields


            '    'NOTA: Solo funciona para un parámetro en el reporte... si tiene más no ... Falta ver como pasarle la colección de parámetros
            '    reporteCrystal.SetParameterValue(nombresDeParametros, valoresDeParametros)
            'End If





            'Return True
        End Function

        ' ''Public Shared Function MuestraReporteCrystal(ByVal reporteCrystal As CrystalDecisions.CrystalReports.Engine.ReportDocument, ByVal miDataSet As System.Data.DataSet, Optional ByVal nombresDeParametros As String = "", Optional ByVal valoresDeParametros As String = "")
        ' ''    If (reporteCrystal.DataSourceConnections.Count > 0) Then
        ' ''        reporteCrystal.SetDataSource(miDataSet)
        ' ''    End If
        ' ''    For i As Integer = 0 To reporteCrystal.Subreports.Count - 1
        ' ''        Dim miSubReporte As CrystalDecisions.CrystalReports.Engine.ReportDocument
        ' ''        miSubReporte = reporteCrystal.Subreports(i)
        ' ''        If (miSubReporte.DataSourceConnections.Count > 0) Then
        ' ''            miSubReporte.SetDataSource(miDataSet)
        ' ''        End If
        ' ''    Next
        ' ''    reporteCrystal.Refresh()


        ' ''    Dim miFrmVisorCrystalReport As New Comunes.Comun
        ' ''    miFrmVisorCrystalReport.reporteCrystal = reporteCrystal




        ' ''    If (Not nombresDeParametros = "") Then
        ' ''        Dim paramFields As New CrystalDecisions.Shared.ParameterFields()

        ' ''        Dim arParametros() As String = nombresDeParametros.Split("'")
        ' ''        Dim arRelacionDeValores() As String = valoresDeParametros.Split(";")

        ' ''        For i As Integer = 0 To arParametros.GetUpperBound(0)
        ' ''            Dim paramField As New CrystalDecisions.Shared.ParameterField()
        ' ''            paramField.ParameterFieldName = arParametros(i)

        ' ''            arRelacionDeValores(i) = arRelacionDeValores(i).Replace("{", "")
        ' ''            arRelacionDeValores(i) = arRelacionDeValores(i).Replace("}", "")


        ' ''            Dim arValores() As String = arRelacionDeValores(i).Split(",")


        ' ''            For j As Integer = 0 To arValores.GetUpperBound(0)
        ' ''                If (arValores(j).IndexOf("|") = -1) Then
        ' ''                    Dim discreteVal As New CrystalDecisions.Shared.ParameterDiscreteValue()
        ' ''                    discreteVal.Value = arValores(j)
        ' ''                    paramField.CurrentValues.Add(discreteVal)
        ' ''                    paramFields.Add(paramField)
        ' ''                Else
        ' ''                    Dim arValoresDeRango() As String = arValores(j).Split(":")
        ' ''                    Dim rangeVal As New CrystalDecisions.Shared.ParameterRangeValue()
        ' ''                    rangeVal.StartValue = arValoresDeRango(0)
        ' ''                    rangeVal.EndValue = arValoresDeRango(1)
        ' ''                    paramField.CurrentValues.Add(rangeVal)
        ' ''                    arValoresDeRango = Nothing
        ' ''                End If
        ' ''            Next
        ' ''            arValores = Nothing
        ' ''        Next
        ' ''        miFrmVisorCrystalReport.CrystalReportViewer1.ParameterFieldInfo = paramFields
        ' ''    End If


        ' ''    miFrmVisorCrystalReport.Show()

        ' ''End Function

        Public Shared Function ReporteCrystal_ImprimeDirecto(ByVal reporteCrystal As CrystalDecisions.CrystalReports.Engine.ReportDocument, ByVal miDataSet As System.Data.DataSet, Optional ByVal nombresDeParametros As String = "", Optional ByVal valoresDeParametros As String = "", Optional ByVal Impresora As String = "", Optional ByVal NumeroCopias As Integer = 1) As Boolean
            If (reporteCrystal.DataSourceConnections.Count > 0) Then
                reporteCrystal.SetDataSource(miDataSet)
            End If
            For i As Integer = 0 To reporteCrystal.Subreports.Count - 1
                Dim miSubReporte As CrystalDecisions.CrystalReports.Engine.ReportDocument
                miSubReporte = reporteCrystal.Subreports(i)
                If (miSubReporte.DataSourceConnections.Count > 0) Then
                    miSubReporte.SetDataSource(miDataSet)
                End If
            Next
            reporteCrystal.Refresh()


            If Not nombresDeParametros.Trim = "" Then
                Dim atrParametros() As String = nombresDeParametros.Split(",")
                Dim atrValores() As String = valoresDeParametros.Split(";")
                For i As Integer = 0 To atrParametros.Length - 1
                    reporteCrystal.SetParameterValue(atrParametros(i), atrValores(i))
                Next
            End If

            If Impresora.Trim <> "" Then
                reporteCrystal.PrintOptions.PrinterName = Impresora.Trim
            End If


            reporteCrystal.PrintToPrinter(NumeroCopias, True, 1, 10000)


            Return True

            'Dim miFrmVisorCrystalReport As New Adsum.FrmVisorCrystal
            'miFrmVisorCrystalReport.reporteCrystal = reporteCrystal




            'If (Not nombresDeParametros = "") Then
            '    Dim paramFields As New CrystalDecisions.Shared.ParameterFields()

            '    Dim arParametros() As String = nombresDeParametros.Split("'")
            '    Dim arRelacionDeValores() As String = valoresDeParametros.Split(";")

            '    For i As Integer = 0 To arParametros.GetUpperBound(0)
            '        Dim paramField As New CrystalDecisions.Shared.ParameterField()
            '        paramField.ParameterFieldName = arParametros(i)

            '        arRelacionDeValores(i) = arRelacionDeValores(i).Replace("{", "")
            '        arRelacionDeValores(i) = arRelacionDeValores(i).Replace("}", "")


            '        Dim arValores() As String = arRelacionDeValores(i).Split(",")


            '        For j As Integer = 0 To arValores.GetUpperBound(0)
            '            If (arValores(j).IndexOf("|") = -1) Then
            '                Dim discreteVal As New CrystalDecisions.Shared.ParameterDiscreteValue()
            '                discreteVal.Value = arValores(j)
            '                paramField.CurrentValues.Add(discreteVal)
            '                paramFields.Add(paramField)
            '            Else
            '                Dim arValoresDeRango() As String = arValores(j).Split(":")
            '                Dim rangeVal As New CrystalDecisions.Shared.ParameterRangeValue()
            '                rangeVal.StartValue = arValoresDeRango(0)
            '                rangeVal.EndValue = arValoresDeRango(1)
            '                paramField.CurrentValues.Add(rangeVal)
            '                arValoresDeRango = Nothing
            '            End If
            '        Next
            '        arValores = Nothing
            '    Next
            '    miFrmVisorCrystalReport.CrystalReportViewer1.ParameterFieldInfo = paramFields
            'End If

            'miFrmVisorCrystalReport.reporteCrystal.PrintToPrinter(1, True, 1, 10000)


        End Function

        ' ''Public Shared Function FgExisteLineaWebServiceCatalogos(Optional ByVal prmMuestraMsg As Boolean = True) As Boolean
        ' ''    If Not EsCorporativo() Then
        ' ''        Dim vcUrl As String = DAO.ParametroAdministradoObtener("PRM", "WSCORPORATIVO") & DAO.ParametroAdministradoObtener("PRM", "WSCATALOGOS")
        ' ''        If Not Comunes.Comun.ClsTools.fgExisteLineaWebService(vcUrl, "SELECT GETDATE()") Then
        ' ''            If prmMuestraMsg Then
        ' ''                MuestraMensajeSistFact(Comun.ClsTools.GlobalSistemaLineaCorporativoNO, MessageBoxIcon.Exclamation)
        ' ''            End If
        ' ''            Return False
        ' ''        End If
        ' ''    End If
        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function fgExisteLineaWebService(ByVal prmUrl As String, ByVal prmSQL As String, Optional ByVal TIEMPO_ESPERA As Integer = 0) As Boolean
        ' ''    Dim ds As DataSet
        ' ''    Dim ws As New WsComun.Comun
        ' ''    Dim vcTomaSolo() As String
        ' ''    Dim vcUrl As String

        ' ''    Try
        ' ''        DAO.ParametroAdministradoAgregar("WS", "WS_TIEMPO_ESPERA_GENERAL", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parametro que determina cual sera el valor de tiempo", 60000)

        ' ''        vcTomaSolo = prmUrl.Split("/")
        ' ''        vcUrl = vcTomaSolo(0) & "//"
        ' ''        vcUrl &= vcTomaSolo(2) & "/"
        ' ''        vcUrl &= DAO.ParametroAdministradoObtener("PRM", "WSCOMUN")
        ' ''        ws.Url = vcUrl
        ' ''        ws.Timeout = 16000 'TIEMPO_ESPERA

        ' ''        'Se Serializó la consulta
        ' ''        ds = ClsTools.deserializaDS(ws.RegresaConsultaSQL_DataSet(prmSQL))
        ' ''    Catch ex As Exception
        ' ''        Return False
        ' ''    End Try

        ' ''    If ds Is Nothing OrElse ds.Tables.Count = 0 OrElse ds.Tables(0).Rows.Count = 0 Then
        ' ''        Return False
        ' ''    End If

        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function fgRegresaDatosDeCorporativo(ByVal prmUrl As String, ByVal prmSQL As String, Optional ByVal TIEMPO_ESPERA As Integer = 0) As DataSet
        ' ''    Dim ds As DataSet
        ' ''    Dim ws As New WsComun.Comun
        ' ''    Dim vcTomaSolo() As String
        ' ''    Dim vcUrl As String

        ' ''    Try
        ' ''        DAO.ParametroAdministradoAgregar("WS", "WS_TIEMPO_ESPERA_GENERAL", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parametro que determina cual sera el valor de tiempo", 60000)

        ' ''        vcTomaSolo = prmUrl.Split("/")
        ' ''        vcUrl = vcTomaSolo(0) & "//"
        ' ''        vcUrl &= vcTomaSolo(2) & "/"
        ' ''        vcUrl &= DAO.ParametroAdministradoObtener("PRM", "WSCOMUN")
        ' ''        ws.Url = vcUrl
        ' ''        ws.Timeout = 16000 'TIEMPO_ESPERA

        ' ''        'Se Serializó la consulta
        ' ''        ds = ClsTools.deserializaDS(ws.RegresaConsultaSQL_DataSet(prmSQL))

        ' ''    Catch ex As Exception
        ' ''        Return Nothing
        ' ''    End Try

        ' ''    Return ds
        ' ''End Function

        ' ''Public Shared Function fgEnviaExistenciasSucursal() As Boolean
        ' ''    Dim vDSEnvio As New DataSet
        ' ''    Dim vWSEnvio As New WsProductos.Productos
        ' ''    Dim vcUrl As String
        ' ''    Dim vdFecha As Date = Nothing
        ' ''    Dim vArray(0) As Object
        ' ''    Dim vcError As String = ""

        ' ''    DAO.ParametroAdministradoAgregar("WS", "WSPRODUCTOS", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parametros del Ws Productos", "WSPanama/Productos.asmx")
        ' ''    DAO.ParametroAdministradoAgregar("PRM", "PRMVALIDAFECHAENVIO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parametro que determina si se validara la fecha de ultimo envio de las existencias ", 0)

        ' ''    'Try
        ' ''    DAO.ParametroAdministradoAgregar("WS", "WS_TIEMPO_ESPERA_GENERAL", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parametro que determina cual sera el valor de tiempo", 60000)
        ' ''    vcUrl = DAO.ParametroAdministradoObtener("PRM", "WSCORPORATIVO") & DAO.ParametroAdministradoObtener("WS", "WSPRODUCTOS")
        ' ''    If fgExisteLineaWebService(DAO.ParametroAdministradoObtener("PRM", "WSCORPORATIVO") & DAO.ParametroAdministradoObtener("PRM", "WSCOMUN"), "SELECT GETDATE()") Then
        ' ''        vWSEnvio.Url = vcUrl
        ' ''        vWSEnvio.Timeout = 0
        ' ''        vWSEnvio.Timeout = DAO.ParametroAdministradoObtener("WS", "WS_TIEMPO_ESPERA_GENERAL")

        ' ''        If vWSEnvio.Timeout = 0 Then
        ' ''            vWSEnvio.Timeout = 10000 'TIEMPO_ESPERA
        ' ''        End If

        ' ''        vdFecha = "01/01/1900"

        ' ''        If DAO.ParametroAdministradoObtener("WS", "WS_TIEMPO_ESPERA_GENERAL") = EN_EnvioExistenciasProductos.ValidaFecha Then
        ' ''            vdFecha = vWSEnvio.RegresaFechaUltimoEnvio_WS_Existencias(1)
        ' ''            If vdFecha = Nothing Then
        ' ''                vdFecha = "01/01/1900"
        ' ''            End If
        ' ''        End If
        ' ''        vArray(0) = NumeroJuliano(vdFecha)

        ' ''        DAO.RegresaConsultaSQL("SP_CNF_EnvioExistenciasProductos", vDSEnvio, vArray)
        ' ''        If Not vDSEnvio Is Nothing Then
        ' ''            If Not vDSEnvio.Tables(0) Is Nothing Then
        ' ''                vDSEnvio.Tables(0).TableName = "PRO_Existencias"
        ' ''                If vWSEnvio.Actualiza_WS_Existencias(Comunes.Comun.ClsTools.SerializaDS(vDSEnvio), vcError) Then
        ' ''                    Return True
        ' ''                End If
        ' ''            End If
        ' ''        End If
        ' ''    Else
        ' ''        Return False
        ' ''    End If
        ' ''    'Catch ex As Exception
        ' ''    ' Return False
        ' ''    ' End Try
        ' ''End Function

        Public Shared Function FgGuardaImagen(ByVal prmNombre As String, ByVal prmRuta As String, ByVal PrmImagenOrigen As String) As Boolean
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim dt As New DataTable
            Dim OfdFoto As New OpenFileDialog
            Dim cSql As String = ""
            Try
                If PrmImagenOrigen.ToUpper.Trim <> prmRuta.ToUpper.Trim & prmNombre.ToUpper.Trim Then
                    If Not IO.Directory.Exists(prmRuta) Then
                        IO.Directory.CreateDirectory(prmRuta)
                    End If
                    IO.File.Copy(PrmImagenOrigen, prmRuta & prmNombre, True)
                End If

                Return True

            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Shared Function FgGuardaImagen(ByVal prmNombre As String, ByVal prmRuta As String, ByVal PrmImagenOrigen As System.Drawing.Bitmap) As Boolean
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim dt As New DataTable
            Dim OfdFoto As New OpenFileDialog
            Dim cSql As String = ""
            Try
                PrmImagenOrigen.Save(prmRuta & prmNombre)
                'IO.File.Copy(Application.ExecutablePath & prmNombre, prmRuta & prmNombre, True)

                Return True

            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Shared Sub PgEliminaImagen(ByVal prmNombre As String, ByVal prmRuta As String)
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim dt As New DataTable
            Dim OfdFoto As New OpenFileDialog
            Dim cSql As String = ""
            Try
                'IO.File.GetAccessControl(prmRuta, System.Security.AccessControl.AccessControlSections.All)
                If IO.File.Exists(prmRuta & prmNombre) Then
                    IO.File.Delete(prmRuta & prmNombre)
                End If

            Catch ex As Exception

            End Try
        End Sub

        Public Shared Function FgCargaImagenExaminar(ByRef prmPictureBox As PictureBox) As Boolean
            Dim OfdFoto As New OpenFileDialog
            Dim ImageRespaldo As Image
            Try
                If OfdFoto.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    ImageRespaldo = System.Drawing.Image.FromFile(OfdFoto.FileName).Clone
                    prmPictureBox.Image = ImageRespaldo
                    prmPictureBox.ImageLocation = OfdFoto.FileName
                End If

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function


        Public Shared Function FgMuestraImagen(ByVal prmRuta As String, ByRef prmPictureBox As PictureBox) As Image

            Dim FileStream1 As System.IO.FileStream
            Dim MyImage As Image

            Try
                If IO.File.Exists(prmRuta) Then
                    FileStream1 = New System.IO.FileStream(prmRuta, IO.FileMode.Open, IO.FileAccess.Read, FileShare.Delete)
                    MyImage = Image.FromStream(FileStream1)
                    'ImageRespaldo = System.Drawing.Image.FromFile(prmRuta)
                    MyImage = MyImage.Clone
                    'prmPictureBox.Image = ImageRespaldo                    
                    FileStream1.Close()
                    Return MyImage
                End If



                Return Nothing
            Catch ex As Exception
                Return Nothing
            End Try
        End Function
        Public Shared Function ObtenImagenBitmap(ByVal prmUbicacion As String) As Image
            Dim bitImagen As Bitmap
            Dim Imagen As Image
            Try
                If Not IO.File.Exists(prmUbicacion) Then Return Nothing
                bitImagen = New Bitmap(prmUbicacion)
                Imagen = CType(bitImagen, Image)
                Return Imagen
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Public Shared Function ObtenImagenBitmap(ByVal prmImagen As Image) As Image
            Dim bitImagen As Bitmap
            Dim Imagen As Image
            Try
                bitImagen = New Bitmap(prmImagen)
                Imagen = CType(bitImagen, Image)
                Return Imagen
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Public Shared Function FgMuestraImagen(ByVal prmRuta As String) As Bitmap
            Dim OfdFoto As New OpenFileDialog
            Dim FileStream1 As System.IO.FileStream
            Dim MyImage As Bitmap

            Try
                If IO.File.Exists(prmRuta) Then
                    FileStream1 = New System.IO.FileStream(prmRuta, IO.FileMode.Open, IO.FileAccess.Read)
                    MyImage = Image.FromStream(FileStream1)
                    MyImage = MyImage.Clone
                    'ImageRespaldo = System.Drawing.Image.FromFile(prmRuta)
                    'ImageRespaldo = ImageRespaldo.Clone
                    'prmPictureBox.Image = ImageRespaldo
                    'FileStream1.Flush()
                    FileStream1.Close()
                    Return MyImage
                End If

                Return Nothing
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Public Shared Function FGConvierteBitMapToArray(ByVal prmRuta As String, ByRef prmNombraArchivo As String) As Byte()
            Dim prmData As Byte()
            Dim fInfo As New FileInfo(prmRuta)

            If Not fInfo.Exists Then Return Nothing

            'vlbitMap = System.Drawing.Image.FromFile(prmRuta)
            'vlbitMap = vlbitMap.Clone
            'IO.File.GetAccessControl(prmRuta, System.Security.AccessControl.AccessControlSections.All)
            Dim fStream = New FileStream(prmRuta, FileMode.Open, FileAccess.Read, FileShare.Delete)
            Dim numBytes As Long = fInfo.Length

            Dim br As New BinaryReader(fStream)

            prmData = br.ReadBytes(CType(numBytes, Integer))
            fStream.Close()
            br.Close()
            Return prmData
            'Return FGConvierteBitMapToArray(vlbitMap)
        End Function

        Public Shared Function FGConvierteBitMapToArray(ByVal prmFile As Bitmap) As Byte()
            Dim stream As System.IO.MemoryStream = New System.IO.MemoryStream
            Dim prmData As Byte()

            prmFile.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp)

            Dim br As New BinaryReader(stream)
            Dim numBytes As Long = br.BaseStream.Length 'prmFile.PropertyItems(0).Len
            prmData = br.ReadBytes(CType(numBytes, Integer))

            Return prmData
        End Function

        Public Shared Function ByteArrayToImages(ByVal br As Byte()) As Image

            Dim ms As MemoryStream
            If Not (br Is Nothing) Then
                'ms = New MemoryStream(br, 0, br.Length)
                'ms.Write(br, 0, br.Length)
                ms = New MemoryStream(br)
                Dim image As System.Drawing.Image = System.Drawing.Image.FromStream(ms)
                Return image.FromStream(ms)
            End If

            If Not (ms Is Nothing) Then
                Return Image.FromStream(ms)  '<------------------------Gives exception
            Else
                Return Nothing

            End If


        End Function


        Public Shared Function byteArrayToImage(ByVal byteArrayIn As Byte()) As Bitmap

            Try
                If (byteArrayIn.Length > 0) Then
                    Dim ms As MemoryStream = New MemoryStream(byteArrayIn)
                    Dim Origninal As Bitmap = New Bitmap(ms)

                    Dim returnBmp As Bitmap = New Bitmap(Origninal.Width, Origninal.Height)
                    Dim g As Graphics = Graphics.FromImage(returnBmp)
                    g.DrawImage(Origninal, 0, 0, Origninal.Width, Origninal.Height)
                    g.Dispose()
                    ms.Close()
                    Return returnBmp
                End If

                Return Nothing

            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        ' ''Public Shared Function FGValidaCantidad_VS_Existencia(ByRef prmDataTable As DataTable, ByVal prmNombreColumnaCANTIDAD As String, ByVal prmNombreColumnaExistencia As String, ByVal PrmInv_Generales As Inventarios.ClsParametrosInventario) As Boolean
        ' ''    Dim vCantidad As Decimal = 0
        ' ''    Dim vExistencia As Decimal = 0
        ' ''    For Each dRow As DataRow In prmDataTable.Rows
        ' ''        vCantidad = IfNull(dRow(prmNombreColumnaCANTIDAD), 0)
        ' ''        vExistencia = IfNull(dRow(prmNombreColumnaExistencia), 0)
        ' ''        If vCantidad > vExistencia Then
        ' ''            If ConfirmaGuardar_CantidadMayorExistencia(PrmInv_Generales) = Windows.Forms.DialogResult.Yes Then
        ' ''                Return True
        ' ''            Else
        ' ''                Return False
        ' ''            End If
        ' ''        End If
        ' ''    Next
        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function FGValidaCantidad_VS_Existencia(ByRef prmDataTable As DataTable, ByVal prmNombreColumnaCANTIDAD As String, ByVal prmNombreColumnaExistencia As String, ByVal PrmPro_Generales As Produccion.ClsParametrosInventarioProductos) As Boolean
        ' ''    Dim vCantidad As Decimal = 0
        ' ''    Dim vExistencia As Decimal = 0
        ' ''    For Each dRow As DataRow In prmDataTable.Rows
        ' ''        vCantidad = IfNull(dRow(prmNombreColumnaCANTIDAD), 0)
        ' ''        vExistencia = IfNull(dRow(prmNombreColumnaExistencia), 0)
        ' ''        If vCantidad > vExistencia Then
        ' ''            If ConfirmaGuardar_CantidadMayorExistencia(PrmPro_Generales) = Windows.Forms.DialogResult.Yes Then
        ' ''                Return True
        ' ''            Else
        ' ''                Return False
        ' ''            End If
        ' ''        End If
        ' ''    Next
        ' ''    Return True
        ' ''End Function

        ' ''Public Shared Function ConfirmaGuardar_CantidadMayorExistencia(ByVal PrmPro_Configuracion As Produccion.ClsParametrosInventarioProductos) As DialogResult
        ' ''    If PrmPro_Configuracion Is Nothing Then
        ' ''        MessageBox.Show("Hay partidas en las que la cantidad supera a la existencia," & vbCr & "revisar la configuración del almacén en cuestión para realizar esta operación", GlobalSistemaCaption, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
        ' ''        Return DialogResult.No
        ' ''    End If
        ' ''    If PrmPro_Configuracion.PermiteExistenciasNegativas And Not PrmPro_Configuracion.PermiteAplicarSalidasParciales Then
        ' ''        Return MessageBox.Show("Hay partidas en las que la cantidad supera a la existencia," & vbCr & "la existencia de estos artículos quedará negativa ¿Desea continuar?", GlobalSistemaCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        ' ''    End If
        ' ''    If PrmPro_Configuracion.PermiteAplicarSalidasParciales And Not PrmPro_Configuracion.PermiteExistenciasNegativas Then
        ' ''        Return MessageBox.Show("Hay partidas en las que la cantidad supera a la existencia," & vbCr & "la salida quedará parcialmente aplicada ¿Desea continuar?", GlobalSistemaCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        ' ''    End If
        ' ''    If Not PrmPro_Configuracion.PermiteExistenciasNegativas And Not PrmPro_Configuracion.PermiteAplicarSalidasParciales Then
        ' ''        MessageBox.Show("Hay partidas en las que la cantidad supera a la existencia," & vbCr & "el almacén no está configurado para realizar esta operación", GlobalSistemaCaption, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
        ' ''        Return DialogResult.No
        ' ''    End If
        ' ''    If PrmPro_Configuracion.PermiteExistenciasNegativas And PrmPro_Configuracion.PermiteAplicarSalidasParciales Then
        ' ''        MessageBox.Show("Hay partidas en las que la cantidad supera a la existencia," & vbCr & "revisar la configuración del almacén en cuestión para realizar esta operación", GlobalSistemaCaption, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
        ' ''        Return DialogResult.No
        ' ''    End If
        ' ''End Function

        ' ''Public Shared Function ConfirmaGuardar_CantidadMayorExistencia(ByVal prmInv_Configuracion As Inventarios.ClsParametrosInventario) As DialogResult
        ' ''    If prmInv_Configuracion Is Nothing Then
        ' ''        MessageBox.Show("Hay partidas en las que la cantidad supera a la existencia," & vbCr & "revisar la configuración del almacén en cuestión para realizar esta operación", GlobalSistemaCaption, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
        ' ''        Return DialogResult.No
        ' ''    End If
        ' ''    If prmInv_Configuracion.PermiteExistenciasNegativas And Not prmInv_Configuracion.PermiteAplicarSalidasParciales Then
        ' ''        Return MessageBox.Show("Hay partidas en las que la cantidad supera a la existencia," & vbCr & "la existencia de estos artículos quedará negativa ¿Desea continuar?", GlobalSistemaCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        ' ''    End If
        ' ''    If prmInv_Configuracion.PermiteAplicarSalidasParciales And Not prmInv_Configuracion.PermiteExistenciasNegativas Then
        ' ''        Return MessageBox.Show("Hay partidas en las que la cantidad supera a la existencia," & vbCr & "la salida quedará parcialmente aplicada ¿Desea continuar?", GlobalSistemaCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        ' ''    End If
        ' ''    If Not prmInv_Configuracion.PermiteExistenciasNegativas And Not prmInv_Configuracion.PermiteAplicarSalidasParciales Then
        ' ''        MessageBox.Show("Hay partidas en las que la cantidad supera a la existencia," & vbCr & "el almacén no está configurado para realizar esta operación", GlobalSistemaCaption, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
        ' ''        Return DialogResult.No
        ' ''    End If
        ' ''    If prmInv_Configuracion.PermiteExistenciasNegativas And prmInv_Configuracion.PermiteAplicarSalidasParciales Then
        ' ''        MessageBox.Show("Hay partidas en las que la cantidad supera a la existencia," & vbCr & "revisar la configuración del almacén en cuestión para realizar esta operación", GlobalSistemaCaption, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
        ' ''        Return DialogResult.No
        ' ''    End If
        ' ''End Function

        Public Shared Function MensajeConfirmaGuardar() As DialogResult
            Return MessageBox.Show(ClsTools.GlobalSistemaConfirmaGuardarDato, GlobalSistemaCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        End Function

        Public Shared Function MensajeConfirmaLimpiarPantalla() As DialogResult
            Return MessageBox.Show(ClsTools.GlobalSistemaLimpiarPantalla, GlobalSistemaCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        End Function


        Public Shared Function FGCalculaPrecioEnUnidadBaseNegociaciones(ByVal dRow As DataRow) As Decimal
            Dim CantidadCC As Decimal
            Dim CantidadSC As Decimal
            Dim Precio As Decimal = 0
            Dim Dctos As Decimal = 0
            Dim DctoImporte As Decimal = 0
            Dim Importe As Decimal
            Dim CantCCBase As Decimal
            Dim CantSCBase As Decimal
            CantidadCC = Comunes.Comun.ClsTools.IfNull(dRow("nCantidadConCargo"), 1)
            CantidadSC = Comunes.Comun.ClsTools.IfNull(dRow("nCantidadSinCargo"), 0)
            If Not dRow("nPrecioNegociado") Is DBNull.Value Then
                Precio = dRow("nPrecioNegociado")
            End If
            If Not dRow("nPrecioActual") Is DBNull.Value Then
                Precio = dRow("nPrecioActual")
            End If
            If Not dRow("nPrecioLista") Is DBNull.Value Then
                Precio = dRow("nPrecioLista")
            End If
            If Not dRow("nPorcentajeDescuento") Is DBNull.Value AndAlso Not dRow("nPorcentajeDescuento") = 0 Then
                Dctos = dRow("nPorcentajeDescuento")
            End If
            If Not Dctos = 0 Then
                Dctos = Dctos / 100
            End If
            DctoImporte = IfNull(dRow("nImporteDescuento"), 0)
            Precio = Precio - (Precio * Dctos)
            Precio = Precio - DctoImporte
            Importe = Precio * CantidadCC
            CantCCBase = CantidadCC * dRow("nEquivalencia")
            CantSCBase = CantidadSC * dRow("nEquivalencia")
            Return Importe / (CantCCBase + CantSCBase)
        End Function

        Public Shared Sub CalculaAcumuladoRelativo(ByVal prmdata As DataTable, ByVal prmCampoRel As String, ByVal prmCampoAcum As String)
            Dim acum As Decimal = 0
            For Each vrow As DataRow In prmdata.Rows
                acum += vrow(prmCampoRel)
                vrow(prmCampoAcum) = Math.Round(acum, 2)
            Next
        End Sub


        Public Shared Sub CalculaRelativo(ByVal prmdata As DataTable, ByVal prmCampoBase As String, ByVal prmCampoRel As String, Optional ByVal prmAgrupacion As String = "")
            If prmCampoBase.Trim = "" Then Return
            Dim Total As Decimal = IfNull(prmdata.Compute("sum([" & prmCampoBase & "])", ""), 0)


            For Each vrow As DataRow In prmdata.Rows
                If Total > 0 Then
                    vrow(prmCampoRel) = Math.Round((IfNull(vrow(prmCampoBase), 0) / Total) * 100, 2)
                Else
                    vrow(prmCampoRel) = 0
                End If
            Next
        End Sub
        Public Shared Sub PgDespintaAccTextBoxAdvanced(ByRef prmATX As AccTextBoxAdvanced, Optional ByVal prmString As String = "", Optional ByVal HabilitaControl As Boolean = True)
            prmATX.BackColor = Color.White
            prmATX.Enabled = True
            prmATX.SetTextBoxValue(prmString)
            prmATX.Enabled = HabilitaControl
        End Sub
        Public Shared Sub PgDespintaAccTextBoxAdvancedDescripciones(ByRef prmATX As AccTextBoxAdvanced, ByVal HabilitaControl As Boolean, Optional ByVal Limpiar As Boolean = False)
            prmATX.BackColor = Color.White
            prmATX.Enabled = True
            prmATX.Enabled = HabilitaControl
            If Limpiar Then
                prmATX.Text = ""
            End If
        End Sub
        Public Shared Sub PgPintaAccTextBoxAdvanced(ByRef prmATX As Object, Optional ByVal prmString As String = "")
            prmATX.SetTextBoxValue(prmString)
            prmATX.BackColor = Color.Yellow
        End Sub
        Public Shared Sub PgDespintaCombo(ByRef prmCombo As System.Windows.Forms.ComboBox, Optional ByVal prmIndex As Integer = 0, Optional ByVal HabilitaControl As Boolean = True)
            prmCombo.BackColor = Color.White
            prmCombo.Enabled = HabilitaControl
        End Sub

        Public Shared Function deserializaDS(ByVal datos() As Byte) As DataSet
            Dim ds As DataSet

            If Not datos Is Nothing Then
                ds = New DataSet
                Dim ms As New System.IO.MemoryStream(datos)
                ds.ReadXml(ms)
            End If

            Return ds
        End Function





        Public Shared Function SerializaDS(ByVal ds As DataSet) As Byte()
            If Not ds Is Nothing Then
                Dim ms As New System.IO.MemoryStream
                ds.WriteXml(ms, XmlWriteMode.WriteSchema)
                Return ms.ToArray
            Else
                Return Nothing
            End If

        End Function

        'public static byte[] SerializaDS(DataSet ds)
        '{
        '    //return AjustedeZonaHoraria(ds);
        '    if (ds != null)
        '    {
        '        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        '        ds.WriteXml(ms, XmlWriteMode.WriteSchema);
        '        return ms.ToArray();
        '    }
        '    else
        '    {
        '        return null;
        '    }
        '}
        Public Shared Function FGValidaATX(ByRef ATX As AccTextBoxAdvanced, ByRef e As SelectedElementArgs, Optional ByVal PermiteAvanceEnBlanco As Boolean = True, Optional ByRef prmObjeto As Object = Nothing, Optional ByVal prmEsFolio As Boolean = False) As Boolean
            If ATX.Text.Trim = "" Then
                prmObjeto = Nothing
                If PermiteAvanceEnBlanco Then
                    Return True
                Else
                    ATX.Focus()
                    Return False
                End If
            End If

            If Not e.Row Is Nothing Then
                Return True
            Else
                If Not prmEsFolio Then
                    MessageBox.Show(ClsTools.GlobalSistemaCodigoNoExiste, ClsTools.GlobalSistemaCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    MessageBox.Show(ClsTools.GlobalSistemaFolioNoExiste, ClsTools.GlobalSistemaCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
                prmObjeto = Nothing
                ATX.Text = ""
                ATX.Focus()
                Return False
            End If
        End Function
        Public Shared Function FGValidaATXFolio(ByRef ATX As AccTextBoxAdvanced, ByRef e As SelectedElementArgs, Optional ByVal PermiteAvanceEnBlanco As Boolean = True, Optional ByRef prmObjeto As Object = Nothing) As Boolean
            If ATX.Text.Trim = "" Then
                prmObjeto = Nothing
                If PermiteAvanceEnBlanco Then
                    Return True
                Else
                    ATX.Focus()
                    Return False
                End If
            End If

            If Not e.Row Is Nothing Then
                Return True
            Else
                MessageBox.Show(ClsTools.GlobalSistemaFolioNoExiste, ClsTools.GlobalSistemaCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                prmObjeto = Nothing
                ATX.Text = ""
                ATX.Focus()
                Return False
            End If
        End Function
        Public Shared Function FGValidaATXPrincipal(ByRef ATX As AccTextBoxAdvanced, ByRef e As SelectedElementArgs, Optional ByVal PermiteAvanceElementoInvalido As Boolean = False) As Boolean
            If ATX.Text.Trim = "" Then
                ATX.Text = "*"
                Return True
            End If

            If ATX.Text.Trim = "*" Then
                Return True
            End If

            If Not e.Row Is Nothing Then
                Return True
            Else
                If PermiteAvanceElementoInvalido Then Return True
                MessageBox.Show(ClsTools.GlobalSistemaFolioNoExiste, ClsTools.GlobalSistemaCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ATX.Text = ""
                ATX.Focus()
            End If

            Return False
        End Function

        Public Shared Function FGValidaATX_Validating(ByVal ATX As Object, ByVal e As System.ComponentModel.CancelEventArgs, ByRef prmObjeto As Object, Optional ByVal prmValidaObtenDescripcion As Boolean = False) As Boolean
            'Función que regresará VERDADERO solamente si el elemento es válido
            'Regresará FALSO si el elemento es inválido o el ATX es vacío
            If Not ATX.Text.Trim = "" Then
                If prmObjeto Is Nothing Then
                    ClsTools.MuestraMensajeSistFact(ClsTools.GlobalSistemaCodigoNoExiste, MessageBoxIcon.Exclamation)
                    ATX.Text = ""
                    e.Cancel = True
                    Return False
                End If
                If Not prmObjeto Is Nothing AndAlso prmValidaObtenDescripcion Then
                    If ATX.ValidayObtenDescripcion.ToString.Trim = "" Then
                        ClsTools.MuestraMensajeSistFact(ClsTools.GlobalSistemaCodigoNoExiste, MessageBoxIcon.Exclamation)
                        ATX.Text = ""
                        e.Cancel = True
                        Return False
                    End If
                End If
            End If
            If ATX.Text.Trim = "" Then
                prmObjeto = Nothing
                Return False
            End If
            Return True
        End Function
        Public Shared Function FGValidaATXPrincipal_Validating(ByVal ATX As Object, ByVal e As System.ComponentModel.CancelEventArgs, ByRef prmObjeto As Object) As Boolean
            If ATX.Text.Trim = "" Then
                prmObjeto = Nothing
                ATX.Text = "*"
                ATX.Enabled = False
                Return True
            End If
            If ATX.Text.Trim = "*" Then
                prmObjeto = Nothing
                Return True
            End If

            If Not prmObjeto Is Nothing Then
                Return True
            End If

            If prmObjeto Is Nothing Then
                MessageBox.Show(ClsTools.GlobalSistemaCodigoNoExiste, ClsTools.GlobalSistemaCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ATX.Text = ""
                e.Cancel = True
                Return False
            End If

            Return True
        End Function

        Public Shared Function FGValidaFechas(ByVal prmFechaInicio As Date, ByVal prmFechaFin As Date) As Boolean
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            If DAO.NumeroJuliano(prmFechaInicio) > DAO.NumeroJuliano(prmFechaFin) Then
                MuestraMensajeSistFact("La fecha final no puede ser menor a la fecha inicial", MessageBoxIcon.Exclamation)
                Return False
            End If
            Return True
        End Function

        Public Shared Function FgObtenTiposArticulosEmpleado() As String
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vsql As String = ""
            Dim filtro As String = ""
            Dim dt As New DataTable

            vsql = "select EMP.CTIPOARTICULO FROM CTL_EMPLEADOS EMP (NOLOCK) INNER JOIN ADSUM_USUARIOS USU (NOLOCK) ON NPERSONAL=NEMPLEADO WHERE CLOGIN = '" & DAO.GetLoginUsuario() & "'"

            DAO.RegresaConsultaSQL(vsql, dt)

            If dt.Rows.Count = 0 Then
                Return "0"
            End If

            If dt.Rows(0).Item(0) Is Nothing OrElse dt.Rows(0).Item(0) = "" Then
                filtro = "0"
                Return filtro
            ElseIf dt.Rows(0).Item(0) = "*" Then
                Return ""
            End If
            filtro = dt.Rows(0).Item(0).ToString
            Return filtro
        End Function

        Public Shared Function FgFormateaNumero(ByVal prmNumero As Decimal, ByVal prmTotalCerosDespuesDelPunto As Int32) As Decimal
            'DEVUELVE UN NUMERO FORMATEANDOLO PONIENDOLE CEROS DESPUES DEL PUNTO
            Dim strNum As String = CStr(prmNumero)
            Dim strNumDespuesPunto As String = ""
            Dim strNumAntesPunto As String = ""
            Dim blnTieneDecimal As Boolean = False
            For c As Integer = 0 To strNum.Length - 1
                strNumAntesPunto &= strNum.Chars(c)
                If strNum.Chars(c) = "." Then
                    blnTieneDecimal = True
                    For i As Integer = (c + 1) To strNum.Length - 1
                        strNumDespuesPunto &= strNum.Chars(i)
                    Next
                    Exit For
                End If
            Next
            Select Case blnTieneDecimal
                Case True
                    'Tiene punto decimal
                    If strNumDespuesPunto.Length < prmTotalCerosDespuesDelPunto Then
                        Dim totalCeros As Int32
                        totalCeros = prmTotalCerosDespuesDelPunto - strNumDespuesPunto.Length
                        For i As Integer = strNumDespuesPunto.Length To totalCeros
                            strNumDespuesPunto &= "0"
                        Next
                    Else
                        'EXCEDE LOS CEROS
                        Dim strNumTemp As String = strNumDespuesPunto
                        strNumDespuesPunto = ""
                        For i As Integer = 0 To prmTotalCerosDespuesDelPunto - 1
                            strNumDespuesPunto &= strNumTemp.Chars(i)
                        Next
                    End If
                    strNum = strNumAntesPunto & strNumDespuesPunto
                Case False
                    'no tiene punto decimal
                    strNum = strNumAntesPunto & ".000"
            End Select
            Return CDec(strNum)
        End Function
        Public Shared Function FgFormatoNumero(ByVal prmValor As String, ByVal prmDecimales As Short, Optional ByVal prmMostrarSignoMoneda As Boolean = False) As String
            If prmMostrarSignoMoneda Then
                Dim vFormato As New FarPoint.Win.Spread.CellType.CurrencyCellType
                vFormato.FixedPoint = True
                vFormato.DecimalPlaces = prmDecimales
                vFormato.Separator = ","
                vFormato.ShowSeparator = True
                Return vFormato.Format(prmValor)
            Else
                Dim vFormato As New FarPoint.Win.Spread.CellType.NumberCellType
                vFormato.FixedPoint = True
                vFormato.DecimalPlaces = prmDecimales
                vFormato.Separator = ","
                vFormato.ShowSeparator = True
                Return vFormato.Format(prmValor)
            End If
        End Function

        Public Shared Sub PgLlenaComboTiposDato(ByVal prmLlave As String, ByRef prmCombo As System.Windows.Forms.ComboBox, Optional ByVal prmAgregarElementoSeleccione As Boolean = True)
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim Vlsql As String

            Vlsql = "SELECT  CLATIPDATNOM,CLATIPDAT" & vbCr
            Vlsql &= "FROM ADT_TIPOSDATOSCHECKS(NOLOCK)" & vbCr
            Vlsql &= "WHERE TIPODATO = " & prmLlave.Trim

            If prmAgregarElementoSeleccione Then
                DAO.RegresaConsultaSQL(Vlsql, prmCombo, DataAccessCls.TipoElementoAdicionalDeLista.Seleccione)
            Else
                DAO.RegresaConsultaSQL(Vlsql, prmCombo)
            End If
            '  Dominio.Catalogos.FabricaCatalogos.PgLlenaComboXtraGrid_TiposDatos()
        End Sub

        Public Shared Sub PgLlenaComboGeneral(ByVal prmCampoLlave As String, ByVal prmCampoDesc As String, ByVal prmTabla As String, ByRef prmCombo As System.Windows.Forms.ComboBox)
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim Vlsql As String
            Try
                Vlsql = "SELECT  " & prmCampoDesc & "," & prmCampoLlave & vbCr
                Vlsql &= "FROM " & prmTabla & "(NOLOCK)" & vbCr
                DAO.RegresaConsultaSQL(Vlsql, prmCombo)
            Catch ex As Exception

            End Try
        End Sub


        Public Shared Sub PgLlenaComboTiposDatoOpcionTodos(ByVal prmLlave As String, ByRef prmCombo As System.Windows.Forms.ComboBox)
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim Vlsql As String

            Vlsql = "SELECT  cValor,nValor" & vbCr
            Vlsql &= "FROM ADSUM_TiposDatos(NOLOCK)" & vbCr
            Vlsql &= "WHERE cLlave='" & prmLlave.Trim & "'"

            DAO.RegresaConsultaSQL(Vlsql, prmCombo, DataAccessCls.TipoElementoAdicionalDeLista.Todos)

        End Sub

        Public Shared Sub PgLlenaComboPrintersPlantillaExpress(ByRef prmCombo As System.Windows.Forms.ComboBox)
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vSQL As String

            vSQL = "Select cDescripcion,nImpresora" & vbCr
            vSQL &= "From IMP_Impresoras(NOLOCK)"

            DAO.RegresaConsultaSQL(vSQL, prmCombo)
        End Sub

        Public Shared Sub PgLlenaComboDocumentosPlantillaExpress(ByRef prmCombo As System.Windows.Forms.ComboBox, ByVal prmEstilo As Integer)
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vSQL As String

            vSQL = "Select DOCUMENTO,DOCUMENTO" & vbCr
            vSQL &= "From PLT_DOCUMENTOS(NOLOCK)" & vbCr
            vSQL &= "Where ESTILO = " & prmEstilo

            DAO.RegresaConsultaSQL(vSQL, prmCombo, DataAccessCls.TipoElementoAdicionalDeLista.Seleccione)
        End Sub

        Public Shared Sub PgLlenaComboEjercicio(ByRef prmCombo As System.Windows.Forms.ComboBox, Optional ByVal prmAgregarElementoSeleccione As Boolean = True)
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vResultado As Boolean

            If prmAgregarElementoSeleccione Then
                vResultado = DAO.RegresaConsultaSQL("Select CONVERT(VARCHAR,nEjercicio) as cDescripcion,nEjercicio as nValor From EJERCICIOS(NoLock) ", prmCombo, DataAccessCls.TipoElementoAdicionalDeLista.Seleccione)
            Else
                vResultado = DAO.RegresaConsultaSQL("Select CONVERT(VARCHAR,nEjercicio) as cDescripcion,nEjercicio as nValor From EJERCICIOS(NoLock) ", prmCombo)
            End If
        End Sub
        Public Shared Sub PgLlenaComboPeriodoMes(ByRef prmCombo As System.Windows.Forms.ComboBox, Optional ByVal prmAgregarElementoSeleccione As Boolean = True)
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vResultado As Boolean

            If prmAgregarElementoSeleccione Then
                vResultado = DAO.RegresaConsultaSQL("select CLATIPDATNOM,CLATIPDAT from ADT_TIPOSDATOSCHECKS where TIPODATO = 14", prmCombo, DataAccessCls.TipoElementoAdicionalDeLista.Seleccione)
            Else
                vResultado = DAO.RegresaConsultaSQL("select CLATIPDATNOM,CLATIPDAT from ADT_TIPOSDATOSCHECKS where TIPODATO = 14", prmCombo)
            End If
        End Sub

        Public Shared Sub PgLlenaComboContribuyentes(ByRef prmCombo As System.Windows.Forms.ComboBox, Optional ByVal prmAgregarElementoSeleccione As Boolean = True)
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vResultado As Boolean

            If prmAgregarElementoSeleccione Then
                vResultado = DAO.RegresaConsultaSQL("select CRAZONSOCIAL,NRFCEMISOR from FAC_EMISORES ", prmCombo, DataAccessCls.TipoElementoAdicionalDeLista.Seleccione)
            Else
                vResultado = DAO.RegresaConsultaSQL("select CRAZONSOCIAL,NRFCEMISOR from FAC_EMISORES ", prmCombo)
            End If
        End Sub
        Public Shared Sub PgLlenaComboNiveles(ByRef prmCombo As System.Windows.Forms.ComboBox, Optional ByVal prmAgregarElementoSeleccione As Boolean = True)
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vResultado As Boolean

            If prmAgregarElementoSeleccione Then
                vResultado = DAO.RegresaConsultaSQL("select cValor,cValor from ADSUM_TiposDatos where cLLave='CNT_Niveles'", prmCombo, DataAccessCls.TipoElementoAdicionalDeLista.Seleccione)
            Else
                vResultado = DAO.RegresaConsultaSQL("select cValor,cValor from ADSUM_TiposDatos where cLLave='CNT_Niveles'", prmCombo)
            End If
        End Sub
        Public Shared Sub PgLlenaComboGrupoContable(ByRef prmCombo As System.Windows.Forms.ComboBox, Optional ByVal prmAgregarElementoSeleccione As Boolean = True)
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vResultado As Boolean

            If prmAgregarElementoSeleccione Then
                vResultado = DAO.RegresaConsultaSQL("Select cDescripcion,nGrupoContable as nValor From CTL_GruposContables(NOLOCK) Where bActivo = 1", prmCombo, DataAccessCls.TipoElementoAdicionalDeLista.Seleccione)
            Else
                vResultado = DAO.RegresaConsultaSQL("Select cDescripcion,nGrupoContable as nValor From CTL_GruposContables (NOLOCK) Where bActivo = 1", prmCombo)
            End If
        End Sub
        Public Shared Sub PgLlenaComboTiposPoliza(ByRef prmCombo As System.Windows.Forms.ComboBox, Optional ByVal prmAgregarElementoSeleccione As Boolean = True)
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vResultado As Boolean

            If prmAgregarElementoSeleccione Then
                vResultado = DAO.RegresaConsultaSQL("Select cDescripcion,nTipoPoliza as nValor From CTL_TiposPolizas(NOLOCK) ", prmCombo, DataAccessCls.TipoElementoAdicionalDeLista.Seleccione)
            Else
                vResultado = DAO.RegresaConsultaSQL("Select cDescripcion,nTipoPoliza as nValor From CTL_TiposPolizas(NOLOCK) ", prmCombo)
            End If
        End Sub
        Public Shared Sub PgLlenaComboTiposPolizaOpcionTodos(ByRef prmCombo As System.Windows.Forms.ComboBox)
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vResultado As Boolean

            vResultado = DAO.RegresaConsultaSQL("Select cDescripcion,nTipoPoliza as nValor From CTL_TiposPolizas(NOLOCK) ", prmCombo, DataAccessCls.TipoElementoAdicionalDeLista.Todos)

        End Sub

        Public Shared Sub pgCodigoNoValido()
            MuestraMensajeSistFact(GlobalSistemaCodigoNoExiste, MessageBoxIcon.Information)
        End Sub

        Public Shared Function CalculaDescuentoCascada(ByVal prmDescuento As String, Optional ByRef prmRegresaMensajeError As String = "") As Double
            Dim cascada() As String
            Dim Porcentaje As Double = 100
            cascada = prmDescuento.Split("+")
            For i As Integer = 0 To cascada.Length - 1
                If Not IsNumeric(cascada(i)) Then
                    Return 0
                End If
            Next
            For i As Integer = 0 To cascada.Length - 1
                Porcentaje = Porcentaje - ((Porcentaje * cascada(i)) / 100)
                If Porcentaje <= 0 AndAlso cascada.Length > 1 Then
                    prmRegresaMensajeError = "El Descuento en Cascada no puede ser mayor a 100%"
                    Return 0
                End If
            Next

            Return 100 - Porcentaje
        End Function

        Public Shared Function fgCalculaDescuentoCascada(ByVal prmDescuento As String, Optional ByRef prmRegresaMensajeError As String = "") As Double
            Dim vnPorc As Decimal = 0
            Dim vcCascada() As String
            Dim vnPorcSumar As Decimal = 0
            Dim vnResta As Decimal = 0

            vcCascada = prmDescuento.Split("+")

            For i As Integer = 0 To vcCascada.Length - 1
                If Not IsNumeric(vcCascada(i)) Then
                    Return 0
                End If
            Next

            For i As Integer = 0 To vcCascada.Length - 1
                If i = 0 Then
                    vnPorc = vcCascada(i)
                    vnResta = 100 - vnPorc
                Else
                    If vnPorc >= 100 And vcCascada(i) > 0 Then
                        prmRegresaMensajeError = "El Descuento en Cascada no puede ser mayor a 100%"
                        Return 0
                    End If
                    vnPorcSumar = (vnResta / 100) * vcCascada(i)
                    vnPorc += vnPorcSumar
                    vnResta = vnResta - vnPorcSumar
                End If
                If vnPorc > 100 Then
                    prmRegresaMensajeError = "El Descuento en Cascada no puede ser mayor a 100%"
                    Return 0
                End If
            Next

            Return vnPorc
        End Function

        Public Shared Function FgDameNombreDia(ByVal Fecha As Date) As String
            Dim strDia As String = ""
            Select Case Fecha.DayOfWeek
                Case DayOfWeek.Monday
                    strDia = "Lunes"
                Case DayOfWeek.Tuesday
                    strDia = "Martes"
                Case DayOfWeek.Wednesday
                    strDia = "Miercoles"
                Case DayOfWeek.Thursday
                    strDia = "Jueves"
                Case DayOfWeek.Friday
                    strDia = "Viernes"
                Case DayOfWeek.Saturday
                    strDia = "Sabado"
                Case DayOfWeek.Sunday
                    strDia = "Domingo"
            End Select
            Return strDia
        End Function

        Public Shared Function Copiacolumn(ByVal prmcol As DataColumn) As DataColumn
            Dim ret As New DataColumn(prmcol.ColumnName, prmcol.DataType)
            Return ret
        End Function

        Public Shared Function TiempoTranscurrido(ByVal prmFecha1 As Date, ByVal prmFecha2 As Date, Optional ByVal prmTipoTiempoTranscurrido As EN_TiempoTranscurrido = EN_TiempoTranscurrido.Años) As String
            Dim vSql As String
            Dim vTabla As New DataTable
            Dim vDato As String

            vSql = " set dateformat ymd select ano= dbo.Adsum_TiempoTranscurridoEntreDosFechas('yy', '" & ClsTools.FechaEnFormatoSqlString(prmFecha1) & "' , '" & ClsTools.FechaEnFormatoSqlString(prmFecha2) & "') "
            vSql &= " ,meses= dbo.Adsum_TiempoTranscurridoEntreDosFechas('mm', '" & ClsTools.FechaEnFormatoSqlString(prmFecha1) & "' , '" & ClsTools.FechaEnFormatoSqlString(prmFecha2) & "')  "
            vSql &= " ,dias= dbo.Adsum_TiempoTranscurridoEntreDosFechas('dd', '" & ClsTools.FechaEnFormatoSqlString(prmFecha1) & "' , '" & ClsTools.FechaEnFormatoSqlString(prmFecha2) & "') "

            If Not DAO.RegresaConsultaSQL(vSql, vTabla) Then Return ""

            Select Case prmTipoTiempoTranscurrido
                Case EN_TiempoTranscurrido.Años
                    vDato = vTabla.Rows(0)("ano")
                Case EN_TiempoTranscurrido.Dias
                    vDato = vTabla.Rows(0)("meses")
                Case EN_TiempoTranscurrido.Meses
                    vDato = vTabla.Rows(0)("dias")
                Case EN_TiempoTranscurrido.Todos
                    'vDato = vTabla.Rows(0)("ano")
                    vDato = (vTabla.Rows(0)("ano") & "," & vTabla.Rows(0)("meses") & "," & vTabla.Rows(0)("dias"))

            End Select

            Return vDato
        End Function

        Public Enum Reporte As Integer
            Empleados = 1
            Niveles = 2
            Gerencias = 3
            SubGerencias = 4
            Departamentos = 5
            Puestos = 6
            Oficinas = 7
            Denominaciones = 8
            DiasInhabiles = 9
            CuotasImss = 10
            CalculoISPT = 11
            MotivosPromocion = 12
            CreditoAlSalario = 13
            DescuentoInfonavit = 14
            TablaActuarial = 15
            FactorSDI = 16
            Vacaciones = 17
            DiasAguinaldo = 18
            TiposEmpleados = 19
            MovimientosNomina = 20
            FormasPago = 21
            TiposHorarios = 22
            ConfiguracionPrestamos = 23
            TipoJustificantes = 24
            Colonias = 25
            Juzgados = 26
            Uniformes = 27
            ConfiguracionCamiones = 28
            Prendas = 29
            ParametrosDiversos = 30
            TipoFaltas = 31
            Jubilados = 32
            TipoJubilados = 33
            JerarquiaDescuentos = 34
            CausaAmonestacion = 35
            TopePrestaciones = 36
            CuotaJubilados = 37
            PagosMensuales = 38
            Becados = 39
            CuotaBecados = 40
            ConceptosTalon = 41
            Clinicas = 43
            PremioPuntualidad = 44
            PersonalConRecibos = 45
            SubsidioAcreditable = 46
            IndicadoresBonos = 49
            CalificadoresDesempeño = 50
            TallasPrendas = 51
            MontoPresupuesto = 52
            PeriodosVacacionales = 53

        End Enum

        Public Enum Movimiento As Integer
            JustificantesDuplicados = 1
            HorasExtras = 2
            Faltas = 3
            AbarcaPeriodo = 4
            Subsecuente = 5
        End Enum

        Public Shared Sub desactivarControl(ByRef control As Control, Optional ByVal enablechange As Boolean = True)

            If Not TypeOf control Is Label Then
                control.Enabled = False
                If Not enablechange Then
                    control.ForeColor = TextoActivo
                Else
                    control.ForeColor = TextoInactivo
                End If
            End If

            If (TypeOf control Is RadioButton Or TypeOf control Is CheckBox) Then
                control.BackColor = ACTIVARCOLOR
                'ElseIf (TypeOf control Is ControlesSEN.CustomCheckBox Or TypeOf control Is ControlesSEN.CustomRadioButtom) Then
                '   control.BackColor = ACTIVARCOLOR
            ElseIf Not TypeOf control Is Button Then
                control.BackColor = DESACTIVARCOLOR
            End If


        End Sub

        Public Shared Sub activarControl(ByRef control As Control) ', Optional ByVal enablechange As Boolean = True)
            control.Enabled = True
            control.BackColor = ACTIVARCOLOR
            control.ForeColor = TextoActivo

            'If enablechange Then control.Enabled = True
        End Sub

        Private Shared Function RunMetodo(ByVal obj As Object, ByVal metodo As String, ByRef parametros() As Object) As Object
            Dim T As System.Type = obj.GetType
            Dim M As System.Reflection.MethodInfo = T.GetMethod(metodo)
            Return M.Invoke(obj, parametros)
        End Function

        Public Shared Function Nombre_Version_Programa() As String
            Dim vAplicacion As String = Application.ProductName
            If vAplicacion.Length > 7 Then vAplicacion = vAplicacion.Substring(0, 7)
            Return vAplicacion + " " + Application.ProductVersion.Trim
        End Function

        Public Shared Function NombreDelMes(ByVal prmMes As Integer) As String
            Select Case prmMes
                Case 1
                    Return "Enero"
                Case 2
                    Return "Febrero"
                Case 3
                    Return "Marzo"
                Case 4
                    Return "Abril"
                Case 5
                    Return "Mayo"
                Case 6
                    Return "Junio"
                Case 7
                    Return "Julio"
                Case 8
                    Return "Agosto"
                Case 9
                    Return "Septiembre"
                Case 10
                    Return "Octubre"
                Case 11
                    Return "Noviembre"
                Case 12
                    Return "Diciembre"
                Case Else
                    Return "Err"
            End Select
        End Function

        Public Shared Function RegresaDiasdelMes(ByVal nMes As Integer, ByVal nAño As Integer) As Integer
            Dim dFecha As Date, dFecha2 As Date
            Dim nDias As Integer
            dFecha = DateSerial(nAño, nMes, 1)
            dFecha2 = DateAdd(DateInterval.Month, 1, dFecha)
            nDias = DateDiff(DateInterval.Day, dFecha, dFecha2)

            Return nDias

        End Function

        Public Shared Function RegresaNombreMes(ByVal nMes As Integer) As String
            Select Case nMes
                Case 1
                    Return "Enero"
                Case 2
                    Return "Febrero"
                Case 3
                    Return "Marzo"
                Case 4
                    Return "Abril"
                Case 5
                    Return "Mayo"
                Case 6
                    Return "Junio"
                Case 7
                    Return "Julio"
                Case 8
                    Return "Agosto"
                Case 9
                    Return "Septiembre"
                Case 10
                    Return "Octubre"
                Case 11
                    Return "Noviembre"
                Case 12
                    Return "Diciembre"
                Case Else
                    Return "Err"
            End Select
        End Function

        Public Shared Function RegresaOtrocontrol(ByVal controlActual As Control, ByVal controlaBuscar As Control) As Control
            Dim ControlARegresar As Control
            ControlARegresar = Nothing
            For Each controles As Control In controlaBuscar.Controls
                If controles.Controls.Count > 0 Then
                    ControlARegresar = RegresaOtrocontrol(controlActual, controles)
                    If Not ControlARegresar Is Nothing Then
                        Return ControlARegresar
                    End If
                Else
                    If Not controlActual Is controles Then
                        If controles.Enabled Then
                            Select Case True
                                Case TypeOf controles Is AccTextBoxAdvanced

                                Case TypeOf controles Is Componentes.SeleccionesDeUsuario
                                Case TypeOf controles Is Windows.Forms.TextBox
                                Case TypeOf controles Is Windows.Forms.DateTimePicker
                                Case TypeOf controles Is Windows.Forms.ComboBox
                                Case TypeOf controles Is Windows.Forms.ComboBox
                                Case TypeOf controles Is Windows.Forms.RadioButton
                                Case Else
                                    ControlARegresar = controles
                            End Select

                            If ControlARegresar Is Nothing Then
                                Return controles
                            End If
                            ControlARegresar = Nothing
                        End If
                    End If
                End If
            Next
            Return Nothing
        End Function

        ' ''Public Shared Function EjecutaComandosSQL_En_WebService(ByVal SQLText As String, Optional ByRef vMensajeError As String = "", Optional ByVal prmUrl As String = "") As Boolean
        ' ''    Dim miTabla As New DataTable
        ' ''    miTabla.Columns.Add(New DataColumn("cSQLText", GetType(String)))
        ' ''    miTabla.Rows.Add(miTabla.NewRow())
        ' ''    miTabla.Rows(0)(0) = SQLText
        ' ''    Return EjecutaComandosSQL_En_WebService(miTabla, vMensajeError, prmUrl)
        ' ''End Function

        ' ''Public Shared Function EjecutaComandosSQL_En_WebService(ByVal vComandos As DataTable, Optional ByRef vMensajeError As String = "", Optional ByVal prmUrl As String = "") As Boolean
        ' ''    'Ricardo Torróntegui
        ' ''    'Sirve para ejecutar una consulta en el webservice y nos regresa un dato tipo object con el resultado de 
        ' ''    'RegresaDatoSQL
        ' ''    Dim ws As New WsComun.Comun
        ' ''    Dim Ds As New DataSet
        ' ''    Ds.Tables.Add(vComandos)



        ' ''    Try

        ' ''        If prmUrl <> "" Then
        ' ''            ws.Url = prmUrl
        ' ''        Else
        ' ''            ws.Url = DAO.ParametroAdministradoObtener("PRM", "WSCORPORATIVO") & DAO.ParametroAdministradoObtener("PRM", "WSCOMUN") 'DAO.ParametroAdministradoObtener("WS", "SERVIDOR_WS_EMPRESA_") & DAO.ParametroAdministradoObtener("WS", "WS_wsCXC")
        ' ''        End If

        ' ''        'ws.Url = "http://localhost/CXC/AplicaPagos.asmx"
        ' ''        'ws.Timeout = CInt(DAO.ParametroAdministradoObtener("WS", "WS_TIEMPO_ESPERA_GENERAL"))
        ' ''        If Not ws.EjecutaComandosSQLEnSecuencia(SerializaDS(Ds), vMensajeError) Then
        ' ''            Return False
        ' ''        End If
        ' ''    Catch ex As Exception
        ' ''        vMensajeError = ex.Message
        ' ''        Return False
        ' ''    End Try

        ' ''    Return True

        ' ''End Function


        'Public Shared Function ExisteLineaAlCorporativo() As Boolean
        '    Return Not (RegresaDatoSQLdeWebService("SELECT GETDATE()", "").Trim = "")
        'End Function

        'Public Shared Function BaseDeDatosCorporativoyLocalEsLaMisma() As Boolean
        '    Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        '    Return DAO.RegresaDatoSQL("SELECT @@SERVERNAME + '.' + DB_NAME()").ToString().Trim = RegresaDatoSQLdeWebService("SELECT @@SERVERNAME + '.' + DB_NAME()").Trim
        'End Function


        'Public Shared Function RegresaDatoSQLdeWebService(ByVal vlSQL As String, Optional ByRef vMensajeError As String = "") As String
        '    'Ricardo Torróntegui
        '    'Sirve para ejecutar una consulta en el webservice y nos regresa un dato tipo object con el resultado de 
        '    'RegresaDatoSQL

        '    Dim ds As DataSet
        '    Dim ws As New WsCXCReportesYConsultas.Reportes
        '    Dim vSqlEncriptado As Byte()

        '    vSqlEncriptado = ADSUM.Criptografo.Rijndael.Encriptar(vlSQL, atrLLave)
        '    Dim miParametrosSucursal As Comunes.Comun.Parametros.ClsParametrosSucursal
        '    miParametrosSucursal = DAO.ParametrosSucursal
        '    Dim miCanalDistribucion As Dominio.Catalogos.ClsCanalDistribucion = Dominio.Catalogos.FabricaCatalogos.ObtenCanalDistribucion(miParametrosSucursal.CanalDistribucion)

        '    Try
        '        ws.Url = DAO.ParametroAdministradoObtener("WS", "SERVIDOR_WS_EMPRESA_" & miCanalDistribucion.Empresa.Folio.ToString) & DAO.ParametroAdministradoObtener("WS", "WS_wsCXCReportes")
        '        'ws.Url = "http://localhost/CXC/Reportes.asmx"
        '        ws.Timeout = CInt(DAO.ParametroAdministradoObtener("WS", "WS_TIEMPO_ESPERA_GENERAL"))
        '        ds = ws.RegresaConsultaSQL_DataSet(vSqlEncriptado, vMensajeError)
        '    Catch ex As Exception
        '        vMensajeError = ex.Message
        '    End Try

        '    If Not ds Is Nothing Then
        '        Try
        '            Return CStr(ds.Tables(0).Rows(0)(0))
        '        Catch ex As Exception
        '            Return ""
        '        End Try
        '    End If
        '    Return ""
        'End Function

        'Public Shared Function RegresaDataSetWebService(ByVal secuenciasSQLText() As String, Optional ByRef mensajeError As String = "") As DataSet
        '    Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
        '    Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        '    Dim miCanalDistribucion As Dominio.Catalogos.ClsCanalDistribucion = Dominio.Catalogos.FabricaCatalogos.ObtenCanalDistribucion(ParamtetrosSucursal.CanalDistribucion)
        '    Dim ws As New WsCXCReportesYConsultas.Reportes
        '    Dim misSecuencias(secuenciasSQLText.Length - 1) As String
        '    For x As Integer = 0 To secuenciasSQLText.Length - 1
        '        misSecuencias(x) = ADSUM.Criptografo.EncriptaTexto(secuenciasSQLText(x), atrLLave)
        '    Next
        '    Try
        '        ws.Url = DAO.ParametroAdministradoObtener("WS", "SERVIDOR_WS_EMPRESA_" & miCanalDistribucion.Empresa.Folio.ToString) & DAO.ParametroAdministradoObtener("WS", "WS_wsCXCReportes")
        '        'ws.Url = "http://localhost/CXC/Reportes.asmx"
        '        ws.Timeout = CInt(DAO.ParametroAdministradoObtener("WS", "WS_TIEMPO_ESPERA_GENERAL"))
        '        RegresaDataSetWebService = ws.RegresaSecuenciasDeConsultaSQL_DataSet(misSecuencias, mensajeError)
        '    Catch ex As Exception
        '        mensajeError = ex.Message
        '    End Try

        '    Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
        'End Function


        ''Modificado por david
        'Public Shared Function RegresaConsultaDeWebService(ByVal vlSQL As String, Optional ByRef vMensajeDeError As String = "") As DataTable
        '    Dim miSecuencia(0) As String
        '    miSecuencia(0) = vlSQL
        '    Dim miDataSet As DataSet = RegresaDataSetWebService(miSecuencia, vMensajeDeError)
        '    If Not miDataSet Is Nothing Then
        '        RegresaConsultaDeWebService = miDataSet.Tables(0)
        '    End If
        'End Function

        ' ''Public Shared Function RegresaConsultaDeWebService(ByVal vlSQL As String, Optional ByRef vMensajeDeError As String = "") As DataTable
        ' ''    'Ricardo Torróntegui
        ' ''    'Sirve para ejecutar una consulta en el webservice y nos regresa un DataTable con el resultado de 
        ' ''    'la consulta

        ' ''    Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor

        ' ''    Dim ds As DataSet
        ' ''    Dim ws As New WsComun.Comun
        ' ''    'Dim ws As New localhost2.Reportes
        ' ''    Dim vSqlEncriptado As Byte()

        ' ''    vSqlEncriptado = ADSUM.Criptografo.Rijndael.Encriptar(vlSQL, atrLLave)
        ' ''    'Dim miParametrosSucursal As Comunes.Comun.Parametros.ClsParametrosSucursal
        ' ''    'miParametrosSucursal = DAO.ParametrosSucursal
        ' ''    'Dim miCanalDistribucion As Dominio.Catalogos.ClsCanalDistribucion = Dominio.Catalogos.FabricaCatalogos.ObtenCanalDistribucion(miParametrosSucursal.CanalDistribucion)

        ' ''    Try
        ' ''        ws.Url = DAO.ParametroAdministradoObtener("PRM", "WSCORPORATIVO") & DAO.ParametroAdministradoObtener("PRM", "WSCOMUN") ' DAO.ParametroAdministradoObtener("WS", "SERVIDOR_WS_EMPRESA_" & miCanalDistribucion.Empresa.Folio.ToString) & DAO.ParametroAdministradoObtener("WS", "WS_wsCXCReportes")
        ' ''        'ws.Url = "http://localhost/CXC/Reportes.asmx"
        ' ''        ws.Timeout = CInt(DAO.ParametroAdministradoObtener("WS", "WS_TIEMPO_ESPERA_GENERAL"))
        ' ''        'Se Serializó la consulta
        ' ''        ds = ClsTools.deserializaDS(ws.RegresaConsultaSQL_DataSet(vlSQL))
        ' ''    Catch ex As Exception
        ' ''        vMensajeDeError = ex.Message
        ' ''    End Try

        ' ''    Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default

        ' ''    If Not ds Is Nothing Then
        ' ''        Return ds.Tables(0)
        ' ''    End If
        ' ''    Return Nothing

        ' ''End Function

        Public Shared Function DameParteEnteraNumero(ByVal prmNumero As Decimal) As Integer
            Dim vnIndexPoint As Int32 = prmNumero.ToString.IndexOf(".")
            'Si no hay punto se regresa el número.
            If vnIndexPoint <= 0 Then Return prmNumero
            'Regresa solo la parte entera del número.
            Return prmNumero.ToString.Trim.Substring(0, vnIndexPoint)
        End Function
        Public Shared Function DameMesSiguiente(ByVal PrmFecha As Date) As Date
            Dim vRes As Date

            If PrmFecha.Month = 12 Then
                'En caso de que la fecha enviada como base sea el ultimo mes del año
                'Tomamos el primero de Enero del año siguiente
                vRes = New Date((PrmFecha.Year + 1), 1, 1)
                Return vRes
            End If

            'Regresamos como resultado el primer dia del mes siguiente
            vRes = New Date(PrmFecha.Year, (PrmFecha.Month + 1), 1)
            Return vRes
        End Function

        Public Shared Function DameUltimoDiaDelMes(ByVal PrmFecha As Date) As Date
            Dim vnFecha As Double

            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia

            vnFecha = NumeroJuliano(DameMesSiguiente(FechaEnFormatoSqlString(PrmFecha))) - 1
            'Regresamos como resultado el primer dia del mes siguiente            
            Return FechaJuliana(vnFecha)
        End Function

        Public Shared Function DamePrimerDiaDelMes(ByVal PrmFecha As Date) As Date
            Dim vRes As Date
            vRes = New Date((PrmFecha.Year), PrmFecha.Month, 1)
            Return vRes
        End Function

        Public Shared Sub BloqueaFlechas(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            'Bloquea las flechas up y Down. Se hizo especialmente por la Caja de Texto del Devexpress
            ' (TextEdit)
            If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
                e.Handled = True
            End If
        End Sub

        Public Shared Sub ValidaCajaNumerica(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
            If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar = Chr(Keys.Back) Or e.KeyChar = Chr(Keys.Delete)) Or e.KeyChar = "." Then
                e.Handled = True
            End If
        End Sub

        Public Shared Sub ValidaCajaNumerosTelefonicos(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
            If e.KeyChar.IsNumber(e.KeyChar) OrElse e.KeyChar = "-" OrElse e.KeyChar = Chr(Keys.Back) OrElse e.KeyChar = Chr(Keys.Delete) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End Sub


        Public Shared Sub ValidaCajaNumericaMultiple(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
            If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar = Chr(Keys.Back) Or e.KeyChar = Chr(Keys.Delete) Or e.KeyChar = ",") Then
                e.Handled = True
            End If
        End Sub

        Public Shared Sub ValidaCajaNumericaMultiple1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
            If e.KeyChar = "." Then
                e.Handled = True
            Else
                If (Char.IsNumber(e.KeyChar) Or e.KeyChar = Chr(Keys.Back) Or e.KeyChar = Chr(Keys.Delete) Or e.KeyChar = ",") Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
            End If
        End Sub

        Public Shared Sub ValidaCajaNumerosDecimales(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs, Optional ByVal prmAceptaNegativos As Boolean = False)
            If prmAceptaNegativos Then
                If e.KeyChar.IsNumber(e.KeyChar) OrElse e.KeyChar = "." OrElse Asc(e.KeyChar) = Keys.Back OrElse e.KeyChar = "-" Then
                    'aceptar caracter
                    If Not e.KeyChar = "." And Not e.KeyChar = "-" Then
                        e.Handled = False
                    Else

                        If e.KeyChar = "." Then
                            'Si fue punto, valida que no haya un punto en la cadena
                            'Dim strCadena As String = CType(sender, AccTextBoxAdvanced).Text.Trim
                            Dim strCadena As String = sender.Text.Trim
                            If Not strCadena.Length > 0 Then
                                e.Handled = False
                            Else
                                'RECORRE LA CADENA Y SI ENCUENTRA UN PUNTO CANCELA EL TECLASO
                                Dim i As Integer = 0
                                For i = 0 To strCadena.Length - 1
                                    If strCadena.Chars(i) = "." Then
                                        'CANCELA EL TECLASO
                                        e.Handled = True
                                        Exit Sub
                                    End If
                                Next
                                'ACEPTA EL TECLASO
                                e.Handled = False
                                Exit Sub
                            End If
                        Else
                            'Si fue signo de menos, valida que no haya uno ya en la cadena
                            'Dim strCadena As String = CType(sender, AccTextBoxAdvanced).Text.Trim
                            Dim strCadena As String = sender.Text.Trim
                            If Not strCadena.Length > 0 Then
                                e.Handled = False
                            Else
                                'RECORRE LA CADENA Y SI ENCUENTRA UN PUNTO CANCELA EL TECLASO
                                Dim i As Integer = 0
                                For i = 0 To strCadena.Length - 1
                                    If strCadena.Chars(i) = "-" Then
                                        'CANCELA EL TECLASO
                                        e.Handled = True
                                        Exit Sub
                                    End If
                                Next
                                'ACEPTA EL TECLASO
                                e.Handled = False
                                Exit Sub
                            End If
                        End If

                    End If
                Else
                    e.Handled = True
                End If
            Else
                If e.KeyChar.IsNumber(e.KeyChar) OrElse e.KeyChar = "." OrElse Asc(e.KeyChar) = Keys.Back Then
                    'aceptar caracter
                    If Not e.KeyChar = "." Then
                        e.Handled = False
                    Else
                        'If sender.SelectionLength() = sender.TextLength() Then
                        If sender.SelectionLength() = Len(sender.Text) Then
                            e.Handled = False
                            Exit Sub
                        End If

                        'Si fue punto, valida que no haya un punto en la cadena
                        'Dim strCadena As String = CType(sender, AccTextBoxAdvanced).Text.Trim
                        Dim strCadena As String = sender.Text.Trim
                        If Not strCadena.Length > 0 Then
                            e.Handled = False
                        Else
                            'RECORRE LA CADENA Y SI ENCUENTRA UN PUNTO CANCELA EL TECLASO
                            Dim i As Integer = 0
                            For i = 0 To strCadena.Length - 1
                                If strCadena.Chars(i) = "." Then
                                    'CANCELA EL TECLASO
                                    e.Handled = True
                                    Exit Sub
                                End If
                            Next
                            'ACEPTA EL TECLASO
                            e.Handled = False
                            Exit Sub
                        End If
                    End If
                Else
                    e.Handled = True
                End If
            End If
        End Sub

        Public Shared Sub ValidaCajaArticulo(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
            If Not Asc(e.KeyChar) = 39 And e.KeyChar.IsLetter(e.KeyChar) OrElse e.KeyChar.IsNumber(e.KeyChar) _
            OrElse Asc(e.KeyChar) = Keys.Back OrElse Asc(e.KeyChar) = 45 _
            OrElse Asc(e.KeyChar) = 95 OrElse Asc(e.KeyChar) = Keys.Space OrElse e.KeyChar = "/" OrElse e.KeyChar = "?" _
            OrElse e.KeyChar = "+" Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End Sub

        Public Shared Sub ValidaCajaArticuloMultiple(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
            If Not Asc(e.KeyChar) = 39 And e.KeyChar.IsLetter(e.KeyChar) OrElse e.KeyChar.IsNumber(e.KeyChar) _
            OrElse Asc(e.KeyChar) = Keys.Back OrElse Asc(e.KeyChar) = 45 _
            OrElse Asc(e.KeyChar) = 95 OrElse Asc(e.KeyChar) = Keys.Space OrElse e.KeyChar = "/" OrElse e.KeyChar = "?" _
            OrElse e.KeyChar = "," OrElse e.KeyChar = "+" Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End Sub

        Public Shared Sub ValidaCajaAlfaNumerica(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
            If e.KeyChar.IsLetterOrDigit(e.KeyChar) Or Asc(e.KeyChar) = Keys.Back Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End Sub
        Public Shared Sub ValidaCajaAlfaNumericaEspacios(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
            If e.KeyChar.IsLetterOrDigit(e.KeyChar) OrElse Asc(e.KeyChar) = Keys.Back OrElse Asc(e.KeyChar) = Keys.Space Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End Sub

        Public Shared Sub ValidaCajaAlfaNumerica_ConGuiones(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
            If e.KeyChar.IsLetterOrDigit(e.KeyChar) OrElse Asc(e.KeyChar) = Keys.Back OrElse e.KeyChar = "-" OrElse e.KeyChar = "_" Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End Sub

        Public Shared Sub ValidaCajaAlfaNumerica_Telefonos(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
            If e.KeyChar.IsLetterOrDigit(e.KeyChar) OrElse Asc(e.KeyChar) = Keys.Back OrElse e.KeyChar = "-" Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End Sub

        Public Shared Sub ValidaCajaFolioFacturaRemision(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
            If e.KeyChar.IsLetter(e.KeyChar) OrElse e.KeyChar.IsNumber(e.KeyChar) OrElse Asc(e.KeyChar) = Keys.Back OrElse e.KeyChar = "_" OrElse e.KeyChar = "-" Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End Sub
        Public Shared Sub ValidaElementoInvalidoBlancoEsValido(ByVal sender As Object, ByVal e As SelectedElementArgs)
            Dim miControl As Object = sender
            If miControl.Text <> "" AndAlso e.Row Is Nothing Then
                Dim miMensaje As String = "Código Invalido"
                If Not miControl.DescripcionElementoInvalido Is Nothing Then
                    miMensaje = miControl.DescripcionElementoInvalido
                End If
                MessageBox.Show(miMensaje, GlobalSistemaCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                miControl.Focus()
            End If
        End Sub

        Public Shared Sub ValidaCajaDescripciones(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
            If e.KeyChar.IsLetterOrDigit(e.KeyChar) OrElse Asc(e.KeyChar) = Keys.Space OrElse Asc(e.KeyChar) = Keys.Back _
            OrElse Asc(e.KeyChar) = 45 OrElse Asc(e.KeyChar) = 95 OrElse Asc(e.KeyChar) = 46 OrElse e.KeyChar = "(" _
            OrElse e.KeyChar = ")" OrElse e.KeyChar = "," OrElse Asc(e.KeyChar) = 37 OrElse e.KeyChar = "+" OrElse e.KeyChar = "/" _
            OrElse e.KeyChar = "*" OrElse e.KeyChar = "#" OrElse e.KeyChar = "'" Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End Sub
        Public Shared Sub ValidaCajaPedidoEspecialASIC(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

            If e.KeyChar.IsLetterOrDigit(e.KeyChar) OrElse Asc(e.KeyChar) = Keys.Space OrElse Asc(e.KeyChar) = Keys.Back _
            OrElse Asc(e.KeyChar) = 45 OrElse Asc(e.KeyChar) = 95 OrElse Asc(e.KeyChar) = 46 OrElse e.KeyChar = "(" _
            OrElse e.KeyChar = ")" OrElse e.KeyChar = "," OrElse Asc(e.KeyChar) = 37 OrElse e.KeyChar = "+" OrElse e.KeyChar = "/" _
            OrElse e.KeyChar = "*" OrElse e.KeyChar = "#" OrElse e.KeyChar = "'" Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End Sub

        Public Shared Sub ValidaCajaDescripcionesSinComilla(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
            If e.KeyChar.IsLetterOrDigit(e.KeyChar) OrElse Asc(e.KeyChar) = Keys.Space OrElse Asc(e.KeyChar) = Keys.Back _
            OrElse Asc(e.KeyChar) = 45 OrElse Asc(e.KeyChar) = 95 OrElse Asc(e.KeyChar) = 46 OrElse e.KeyChar = "(" _
            OrElse e.KeyChar = ")" OrElse e.KeyChar = "," OrElse Asc(e.KeyChar) = 37 OrElse e.KeyChar = "+" OrElse e.KeyChar = "/" _
            OrElse e.KeyChar = "*" OrElse e.KeyChar = "#" Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End Sub

        Public Shared Sub ValidaCajaDescripcionesConAmpersond(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
            If e.KeyChar.IsLetterOrDigit(e.KeyChar) OrElse Asc(e.KeyChar) = Keys.Space OrElse Asc(e.KeyChar) = Keys.Back _
            OrElse e.KeyChar = "&" Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End Sub



        Public Shared Sub ValidaCajaCorreoElectronico(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
            If e.KeyChar.IsLetterOrDigit(e.KeyChar) OrElse Asc(e.KeyChar) = Keys.Space OrElse Asc(e.KeyChar) = Keys.Back _
            OrElse Asc(e.KeyChar) = 45 OrElse Asc(e.KeyChar) = 95 OrElse Asc(e.KeyChar) = 46 OrElse e.KeyChar = "@" Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End Sub

        Public Shared Sub ValidaCajaLetras(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
            If e.KeyChar.IsLetter(e.KeyChar) OrElse Asc(e.KeyChar) = Keys.Space OrElse Asc(e.KeyChar) = Keys.Back OrElse Asc(e.KeyChar) = 46 Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End Sub

        'Public Shared Sub ValidaCajaAlfaNumerica(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        '    If e.KeyChar.IsLetter(e.KeyChar) OrElse e.KeyChar.IsNumber(e.KeyChar) OrElse e.KeyChar = "-" OrElse e.KeyChar = "_" Then
        '        e.Handled = False
        '    Else
        '        e.Handled = True
        '    End If
        'End Sub

        Public Shared Sub ValidaCajaDomicilio(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
            If e.KeyChar.IsLetterOrDigit(e.KeyChar) OrElse Asc(e.KeyChar) = Keys.Space OrElse Asc(e.KeyChar) = Keys.Back _
           OrElse Asc(e.KeyChar) = 45 OrElse Asc(e.KeyChar) = 95 OrElse Asc(e.KeyChar) = 35 _
           OrElse Asc(e.KeyChar) = 46 OrElse Asc(e.KeyChar) = 44 Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End Sub

        ' Nombre del Procedimiento: Validanumero Decimal
        ' Autor: De Anda Alcántara César Andrés
        ' Próposito: Validar que se esté esriba correctamente un Número Decimal
        ' Fecha de Creación: 4 de Julio del 2008
        Public Shared Sub ValidaNumeroDecimal(ByVal cajaTexto As System.Windows.Forms.TextBox, ByVal e As System.Windows.Forms.KeyPressEventArgs)

            ' Este Procedimiento verifica que el campo a llenar sea un valor decimal.
            Dim vTienePunto As Boolean

            ' Preguntar si en la primera posición se oprimió
            If cajaTexto.Text.Length = 0 Then
                If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar = Chr(Keys.Back) Or e.KeyChar = Chr(Keys.Delete) Or e.KeyChar = ".") Then
                    e.Handled = True
                    Exit Sub
                End If
            Else

                ' Encontrar donde se volvió a teclear otro punto
                For Each vCaracter As Char In cajaTexto.Text.Trim.ToCharArray

                    If vCaracter = "." Then
                        vTienePunto = True
                        Exit For
                    End If

                Next

                ' Pregunta si se oprimió un atecla distinta a la de un dígito o un punto,
                ' Tomando en cuenta si ya hubo otro punto anterior a éste
                If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar = Chr(Keys.Back) Or e.KeyChar = Chr(Keys.Delete)) Then
                    e.Handled = True
                ElseIf e.KeyChar = "." And vTienePunto Then
                    e.Handled = True
                End If

            End If

        End Sub

        Public Shared Sub InicializaCarpetas(ByVal prmControl As Control)
            ''Metodo para configurar los TabControls y Los TabPages
            ''Elaboro: L.I. Guadalupe Garcia Torres
            ''Fecha 13/02/2007
            ''Configura los tabcontrols del developer express para que se miren como los tab de windows
            ''y pone los colores de la forma

            'Dim Carpetas As DevExpress.XtraTab.XtraTabControl
            'Dim Carp As DevExpress.XtraTab.XtraTabPage
            'For Each controla As Control In prmControl.Controls
            '    If controla.GetType.Name = GetType(DevExpress.XtraTab.XtraTabControl).Name Then
            '        Carpetas = controla
            '        Carpetas.PaintStyleName = "Standard"
            '        Carpetas.Appearance.BackColor = prmControl.BackColor
            '        Carpetas.Appearance.Options.UseBackColor = True
            '        Carpetas.AppearancePage.Header.BackColor = prmControl.BackColor
            '        Carpetas.AppearancePage.Header.Options.UseBackColor = True
            '        Carpetas.AppearancePage.HeaderActive.BackColor = prmControl.BackColor
            '        Carpetas.AppearancePage.HeaderActive.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            '        Carpetas.AppearancePage.HeaderActive.Options.UseBackColor = True
            '        Carpetas.AppearancePage.HeaderActive.Options.UseFont = True
            '        Carpetas.PaintStyleName = "Standard"
            '    End If
            '    If controla.GetType.Name = GetType(DevExpress.XtraTab.XtraTabPage).Name Then
            '        Carp = controla
            '        controla.BackColor = prmControl.BackColor
            '    End If
            '    If controla.Controls.Count > 0 Then InicializaCarpetas(controla)
            'Next
        End Sub

        Public Shared Function CalculaPrecioNeto(ByVal Precio As Decimal, ByVal Descuento As Decimal, ByVal DescuentoImporte As Decimal, ByVal PrecioLista As Decimal) As Decimal
            Dim nPrecioNeto As Double = 0
            Dim nDescuento As Double = 0

            ' Calcular el Descuento
            nDescuento = (Precio * (Descuento / 100))

            nPrecioNeto = Precio - nDescuento

            Return nPrecioNeto - DescuentoImporte
        End Function

        Public Shared Function CalculaPrecioNeto(ByRef prmRow As Object, ByVal nomColPrecio As String, ByVal nomColDescuento As String, ByVal nomColPrecioLista As String, _
                                                 ByVal nomColCantidadCC As String, ByVal nomColCantidadSC As String, Optional ByVal nomColImporteDescuento As String = "") As Double

            Dim nPrecioObtenido, nDescuento, nPrecioNeto As Decimal
            Dim nCantidadConCargo, nCantidadSinCargo As Decimal
            Dim nPrecioNegociado, nPorcentajeDescuento As Decimal
            Dim nImporteDescuento As Decimal = 0
            Dim blnEsPrecioLista As Boolean

            ' Preguntar primero si hay un precio negociado
            If IfNull(prmRow(nomColPrecio), 0) = 0 Then
                nPrecioObtenido = IfNull(prmRow(nomColPrecioLista), 0)
                blnEsPrecioLista = True
            Else
                nPrecioObtenido = CDec(IfNull(prmRow(nomColPrecio), 0))
            End If

            ' Asignar a Memoria el resto de los parámetros
            nCantidadConCargo = CDec(IfNull(prmRow(nomColCantidadCC), 0))
            nCantidadSinCargo = CDec(IfNull(prmRow(nomColCantidadSC), 0))
            nPorcentajeDescuento = CDec(IfNull(prmRow(nomColDescuento), 0))
            nPrecioNegociado = CDec(IfNull(prmRow(nomColPrecio), 0))
            If Not nomColImporteDescuento Is Nothing AndAlso Not nomColImporteDescuento.Trim = "" Then
                nImporteDescuento = CDec(IfNull(prmRow(nomColImporteDescuento), 0))
            End If

            ' Calcular el Descuento
            nDescuento = Math.Round((nPrecioObtenido * (nPorcentajeDescuento / 100)), 2)

            ' Verificar que el Precio (ya sea uno Negociado o Precio de Lista)
            ' Sea un valor mayor a Cero.
            If IfNull(nPrecioObtenido, 0) <> 0 Then
                ' Calcular el Precio Neto.
                nPrecioNeto = nPrecioObtenido - nDescuento
            End If

            ' Devolver el valor del "Precio Neto"
            Return nPrecioNeto - nImporteDescuento
        End Function

        Public Shared Function FgCalculaPrecioNeto(ByVal PrmProcedencia As String, _
                                                   Optional ByRef PrmDataRowView As DataRowView = Nothing, _
                                                   Optional ByRef PrmDataRow As DataRow = Nothing, Optional ByVal colPrecio As String = "", _
                                                   Optional ByVal colDescuento As String = "", Optional ByVal colPrecioLista As String = "", _
                                                   Optional ByVal colCantCC As String = "", Optional ByVal colCantSC As String = "", Optional ByVal prmIgnoraImporteDescuentoNegociado As Boolean = False) As Double
            ' Elaboró:     L.I. César Andrés De Anda Alcántara
            ' Fecha:       25-Julio-2008
            ' Que Hace:    Obtiene el Precio Neto, a partir de cualquiera o todas las negociaciones por artículo;
            '              a saber las siguientes:
            '              1.- Por Cantidades (Cantidad Con Cargo y Cantidad Sin Cargo).
            '              2.- Por Precio (el cual es proporcionado por el proveedor).
            '              3.- Por Descuento (el cual es un descuento en cascada aplicado al precio proporcionado
            '                                 por el proveedor o al Precio de Lista que ya tiene el artículo mismo).
            ' Parámetros de Entrada: Pueden ser cualquiera de los siguientes ...
            '                        1. DataRow: El cual es utilizado para consulta.
            '                        2. DataRowView: El cual es utilizado para Guardar.

            Dim blnIgnoraImporteDescuentoNegociado As Boolean = False
            Dim vPrecioObtenido, vDescuento, vPrecioNeto As Decimal
            Dim vCantidadConCargo, vCantidadSinCargo As Decimal
            Dim vPrecioNegociado, vPorcentajeDescuento As Decimal
            Dim vImporteDescuento As Decimal = 0
            Dim vEsPrecioLista As Boolean
            Dim vNPrecioNegociado, vNDescuentoNegociado As String
            Dim vstrCantidadCC As String = "nCantidadConCargo"
            Dim vstrCantidadSC As String = "nCantidadSinCargo"
            Dim vStrPrecioLista As String = "nPrecioLista"
            Dim vStrImporteDescuento As String = ""

            ' Determinar de cuàl pantalla se mandò llamar esta funciòn
            If PrmProcedencia = "Negociaciones" Then
                vStrImporteDescuento = ""
                vNPrecioNegociado = "nPrecioNegociado"
                vNDescuentoNegociado = "nPorcentajeDescuento"

            ElseIf PrmProcedencia = "NegociacionesVigentes" Then
                vStrImporteDescuento = ""
                vNPrecioNegociado = "nPrecioNegociado"
                vNDescuentoNegociado = "nDescuentoNegociado"
            Else
                vStrImporteDescuento = "nImporteDescuentoNegociado"
                vNPrecioNegociado = "nPrecio"
                vNDescuentoNegociado = "nDescuentoNegociado"
                If Not colPrecio.Trim = "" Then
                    vNPrecioNegociado = colPrecio
                End If
                If Not colDescuento.Trim = "" Then
                    vNDescuentoNegociado = colDescuento
                End If
                If Not colPrecioLista.Trim = "" Then
                    vStrPrecioLista = colPrecioLista
                End If
                If Not colCantCC.Trim = "" Then
                    vstrCantidadCC = colCantCC
                End If
                If Not colCantSC.Trim = "" Then
                    vstrCantidadSC = colCantSC
                End If
            End If


            ' Evaluar que parametro de entrada fué el que se utilizó...
            ' DataRow o DataRowView.
            If PrmDataRowView IsNot Nothing Then

                ' Preguntar primero si hay un precio negociado
                If IfNull(PrmDataRowView(vNPrecioNegociado), 0) = 0 Then
                    vPrecioObtenido = IfNull(PrmDataRowView(vStrPrecioLista), 0)
                    vEsPrecioLista = True
                Else
                    vPrecioObtenido = CDec(IfNull(PrmDataRowView(vNPrecioNegociado), 0))
                End If

                ' Asignar a Memoria el resto de los parámetros
                vCantidadConCargo = CDec(IfNull(PrmDataRowView(vstrCantidadCC), 0))
                vCantidadSinCargo = CDec(IfNull(PrmDataRowView(vstrCantidadSC), 0))
                vPorcentajeDescuento = CDec(IfNull(PrmDataRowView(vNDescuentoNegociado), 0))
                vPrecioNegociado = CDec(IfNull(PrmDataRowView(vNPrecioNegociado), 0))
                If Not vStrImporteDescuento.Trim = "" Then
                    'fsdfd
                    If Not prmIgnoraImporteDescuentoNegociado Then
                        vImporteDescuento = CDec(IfNull(PrmDataRowView(vStrImporteDescuento), 0))
                    End If
                End If

                ' Calcular el Descuento
                vDescuento = Math.Round((vPrecioObtenido * (vPorcentajeDescuento / 100)), 2)

            Else

                ' Preguntar primero si hay un precio negociado
                If IfNull(PrmDataRow(vNPrecioNegociado), 0) = 0 Then
                    If 1 = 0 Then
                        vPrecioObtenido = Math.Round(IfNull(PrmDataRow(vStrPrecioLista), 0), 2)
                        vEsPrecioLista = True
                    End If

                Else
                    'TRONO AKI
                    vPrecioObtenido = Math.Round(IfNull(PrmDataRow(vNPrecioNegociado), 0), 2)
                End If

                ' Asignar a Memoria el resto de los parámetros
                vCantidadConCargo = Math.Round(IfNull(PrmDataRow(vstrCantidadCC), 0), 2)
                vCantidadSinCargo = Math.Round(IfNull(PrmDataRow(vstrCantidadSC), 0), 2)
                vPorcentajeDescuento = Math.Round(IfNull(PrmDataRow(vNDescuentoNegociado), 0), 2)
                vPrecioNegociado = Math.Round(IfNull(PrmDataRow(vNPrecioNegociado), 0), 2)

                ' Calcular el Descuento
                vDescuento = (vPrecioObtenido * (vPorcentajeDescuento / 100))

            End If

            ' Verificar que el Precio (ya sea uno Negociado o Precio de Lista)
            ' Sea un valor mayor a Cero.


            If IfNull(vPrecioObtenido, 0) <> 0 Then

                ' Calcular el Precio Neto.
                vPrecioNeto = vPrecioObtenido - vDescuento

            End If

            ' Devolver el valor del "Precio Neto"
            Return vPrecioNeto - vImporteDescuento

        End Function

        Public Shared Function FgValidaPorcentajeDescuento(ByVal PrmArreglo() As Char, ByRef vMensajeDescuentoIncorrecto As String) As Boolean

            Dim vEsSigno, vEsPunto, vHayDigitoAtras As Boolean

            For vContador = 0 To (PrmArreglo.Length - 1)

                ' Preguntar que el elemento de la posición actual no sea un espacio en blanco
                If PrmArreglo(vContador) = "" Then

                    ' Error en la cadena
                    vMensajeDescuentoIncorrecto = "El Descuento no puede tener espacios en blanco"
                    Return False

                End If

                ' Preguntar si se está en la primera o última posición de la cadena
                If vContador = 0 Or vContador = (PrmArreglo.Length - 1) Then

                    ' Preguntar si el caracter de dicha posición es un número
                    If Char.IsNumber(PrmArreglo(vContador)) = False Then

                        ' Error en la cadena
                        vMensajeDescuentoIncorrecto = "La primera y la última posición del Descuento deben ser números"
                        Return False

                    End If

                Else

                    ' En caso de que se trate de una posición intermedia;
                    ' Evaluar las siguientes condiciones

                    ' 1. Preguntar si el elemento de la posición actual,
                    '    es ún dígito
                    If Char.IsNumber(PrmArreglo(vContador)) = True Then
                        vEsSigno = False
                        vHayDigitoAtras = True
                        Continue For
                    End If

                    ' 2. Preguntar si el signo encontrado es de tipo "Suma" (+)
                    '    o Punto Decimal    
                    If Char.IsNumber(PrmArreglo(vContador)) = False Then

                        ' A) Preguntar si el elemento actual es otro signo de "suma",
                        '    Considerando que el elemento de la posición anterior,
                        '    fué un "Signo de suma".
                        If PrmArreglo(vContador) = "+" And _
                        vEsSigno = True Then
                            vMensajeDescuentoIncorrecto = "No puede haber un signo de suma seguido de otro signo de suma"
                            Return False
                        End If

                        ' B) Preguntar si el elemento actual es un "Punto Decimal",
                        '    Considerando que el elemento de la posición anterior,
                        '    fué un signo de "Suma".
                        If PrmArreglo(vContador) = "." And _
                        vEsSigno = True Then
                            vMensajeDescuentoIncorrecto = "No puede haber un punto decimal seguido de otro signo de suma"
                            Return False
                        End If

                        ' C) Preguntar si el elemento actual es otro signo de "suma",
                        '    Considerando que el elemento de la posición anterior,
                        '    fué un "punto decimal".
                        If PrmArreglo(vContador) = "+" And _
                        vEsPunto = True And _
                        vHayDigitoAtras = False Then
                            vMensajeDescuentoIncorrecto = "No puede haber un signo de suma seguido de un punto decimal"
                            Return False
                        End If

                        ' D) Preguntar si el elemento actual es un Punto Decimal,
                        '    Considerando que ya hay otro Punto Decimal dentro del operando
                        If PrmArreglo(vContador) = "." And _
                        vEsPunto = True Then
                            vMensajeDescuentoIncorrecto = "no puede haber un punto decimal seguido de otro punto decimal" & vbCrLf & _
                                             "ni ubicarse dentro del mismo operando"
                            Return False
                        End If

                        ' Preguntar si se trata de un signo "+".
                        ' para hacer entonces el cambio operando
                        If PrmArreglo(vContador) = "+" Then
                            vHayDigitoAtras = False
                            vEsSigno = True
                            vEsPunto = False
                            Continue For
                        ElseIf PrmArreglo(vContador) = "." Then
                            vHayDigitoAtras = False
                            vEsPunto = True
                            Continue For
                        Else
                            ' Error en la cadena
                            vMensajeDescuentoIncorrecto = "No debe haber valores dentro del Descuento, diferentes a un número o Signo de Suma"
                            Return False
                        End If

                    End If

                End If

            Next vContador

            ' En caso de que no se haya error alguno
            Return True

        End Function
        ' Nombre del Procedimiento: FgTransformaAValorDecimalObligatorio
        ' Autor:     Ruben Castro
        ' Propósito: Llenar el AccTextBoxAdvanced Obligatorio, con los Decimales que
        '            le hagan falta
        ' Fecha de Creación : 26 de Agosto del 2008
        Public Shared Function FgTransformaAValorDecimalObligatorio(ByRef PrmAccTextBoxAdvanced As AccTextBoxAdvanced) As String

            Dim strDespuesPunto As String = ""
            Dim blnEncontroPunto As Boolean = False
            If PrmAccTextBoxAdvanced.Text.Trim = "" Then

            Else
                For i As Integer = 0 To PrmAccTextBoxAdvanced.Text.Length - 1
                    If PrmAccTextBoxAdvanced.Text.Chars(i) = "." Then
                        blnEncontroPunto = True
                        Continue For
                    End If
                    If blnEncontroPunto Then
                        strDespuesPunto &= PrmAccTextBoxAdvanced.Text.Chars(i)
                    End If
                Next

                If strDespuesPunto.Length = 0 Then
                    PrmAccTextBoxAdvanced.Text = CInt(PrmAccTextBoxAdvanced.Text \ 1).ToString & ".00"
                ElseIf strDespuesPunto.Length = 1 Then
                    PrmAccTextBoxAdvanced.Text = PrmAccTextBoxAdvanced.Text & "0"
                End If

            End If

            Return PrmAccTextBoxAdvanced.Text

        End Function

        Public Shared Function FgTransformaAValorDecimal(ByRef PrmAccTextBoxAdvanced As AccTextBoxAdvanced, Optional ByVal prmBlancoMuestraFormato As Boolean = True) As String
            If Not prmBlancoMuestraFormato Then
                If PrmAccTextBoxAdvanced.Text.Trim = "" OrElse PrmAccTextBoxAdvanced.Text.Trim = "." Then
                    Return ""
                End If
            End If
            Dim strDespuesPunto As String = ""
            Dim blnEncontroPunto As Boolean = False
            If PrmAccTextBoxAdvanced.Text.Trim = "" Then
                PrmAccTextBoxAdvanced.Text = Format(PrmAccTextBoxAdvanced.Text, "0.00")
            Else
                For i As Integer = 0 To PrmAccTextBoxAdvanced.Text.Length - 1
                    If PrmAccTextBoxAdvanced.Text.Chars(i) = "." Then
                        blnEncontroPunto = True
                        Continue For
                    End If
                    If blnEncontroPunto Then
                        strDespuesPunto &= PrmAccTextBoxAdvanced.Text.Chars(i)
                    End If
                Next

                If strDespuesPunto.Length = 0 Then
                    PrmAccTextBoxAdvanced.Text = Format(CDec(PrmAccTextBoxAdvanced.Text.Trim), "##0.00")
                End If
                If strDespuesPunto.Length > 2 AndAlso Not strDespuesPunto.Length = 4 Then
                    PrmAccTextBoxAdvanced.Text = Format(CDec(PrmAccTextBoxAdvanced.Text.Trim), "##0.000")
                End If
                If strDespuesPunto.Length = 4 Then
                    PrmAccTextBoxAdvanced.Text = Format(CDec(PrmAccTextBoxAdvanced.Text.Trim), "##0.0000")
                End If
                If strDespuesPunto.Length > 0 And strDespuesPunto.Length <= 2 Then
                    PrmAccTextBoxAdvanced.Text = Format(CDec(PrmAccTextBoxAdvanced.Text.Trim), "##0.00")
                End If

                'If strDespuesPunto.Length = 0 Or strDespuesPunto.Length > 2 Then
                '    PrmAccTextBoxAdvanced.Text = CInt(PrmAccTextBoxAdvanced.Text \ 1).ToString & ".00"
                'ElseIf strDespuesPunto.Length = 1 Then
                '    PrmAccTextBoxAdvanced.Text = PrmAccTextBoxAdvanced.Text & "0"
                'End If

            End If

            Return PrmAccTextBoxAdvanced.Text

        End Function

        ' Nombre del Procedimiento: FgTransformaAValorDecimal(1ra. Sobrecarga)
        ' Autor:     De Anda Alcántara César Andrés
        ' Propósito: Llenar el Texto, con los Decimales que
        '            le hagan falta
        ' Fecha de Creación : 22 de Agosto del 2008
        Public Shared Function FgTransformaAValorDecimal(ByRef PrmTexto As String) As String

            Dim strDespuesPunto As String = ""
            Dim blnEncontroPunto As Boolean = False
            If PrmTexto.Trim = "" Then
                PrmTexto = Format(PrmTexto, "0.00")
            Else
                For i As Integer = 0 To PrmTexto.Length - 1
                    If PrmTexto.Chars(i) = "." Then
                        blnEncontroPunto = True
                        Continue For
                    End If
                    If blnEncontroPunto Then
                        strDespuesPunto &= PrmTexto.Chars(i)
                    End If
                Next

                If strDespuesPunto.Length = 0 Or strDespuesPunto.Length > 2 Then
                    PrmTexto = CDec(PrmTexto \ 1).ToString & ".00"
                ElseIf strDespuesPunto.Length = 1 Then
                    PrmTexto = PrmTexto & "0"
                End If

            End If

            Return PrmTexto

        End Function

        ' Nombre del Procedimiento: PgDecimalCorrecto
        ' Autores:  De Anda Alcántara César Andrés
        '           Zamora Angulo Jesus Fernando
        ' Propósito: Asegurar que el Número Decimal Ingresado cumpla con el formato
        '            De 3 Enteros, un Punto Decimal y dos Decimales (000.00)
        ' Fecha de Creación : 26 de Agosto del 2008
        Public Shared Sub PgDecimalCorrecto(ByRef PrmAccTextBoxAdvanced As AccTextBoxAdvanced)
            Dim strDespuesPunto As String = ""
            Dim blnEncontroPunto As Boolean = False
            For i As Integer = 0 To PrmAccTextBoxAdvanced.Text.Length - 1
                If PrmAccTextBoxAdvanced.Text.Chars(i) = "." Then
                    blnEncontroPunto = True
                    Continue For
                End If
                If blnEncontroPunto Then
                    strDespuesPunto &= PrmAccTextBoxAdvanced.Text.Chars(i)
                End If
            Next

            If strDespuesPunto.Length > 2 Then
                PrmAccTextBoxAdvanced.Text = PrmAccTextBoxAdvanced.Text.Trim.Substring(0, PrmAccTextBoxAdvanced.Text.Length - 1)
                PrmAccTextBoxAdvanced.Select(PrmAccTextBoxAdvanced.Text.Length, PrmAccTextBoxAdvanced.Text.Length)
            End If
        End Sub

#Region " ENTRADAS DEL INI "
        'Public Shared Function ParamtetrosTerminal() As Comunes.Comun.Parametros.ClsParametrosTerminal
        '    Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        '    ParamtetrosTerminal = DAO.ParametrosTerminal
        'End Function

        Public Shared Function ParamtetrosSucursal() As Comunes.Comun.Parametros.ClsParametrosSucursal
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            ParamtetrosSucursal = DAO.ParametrosSucursal
        End Function

        Public Shared Function EsCorporativoProduccion() As Boolean
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vcSQL As String = "SELECT ISNULL(bEsCorporativoProduccion,0) FROM CTL_Almacenes (NOLOCK) " & vbCr
            vcSQL &= " WHERE nAlmacen = " & DAO.ParametrosTerminal.ParametroAlmacen.Valor
            Return DAO.RegresaDatoSQL(vcSQL) = 1
        End Function

        Public Shared Function FgEsCorporativo() As Boolean
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vcSQL As String = "SELECT ISNULL(bEsCorporativo,0) FROM CTL_Almacenes (NOLOCK) " & vbCr
            vcSQL &= " WHERE nAlmacen = " & DAO.ParametrosTerminal.ParametroAlmacen.Valor
            Return DAO.RegresaDatoSQL(vcSQL)
        End Function

        ' ''Public Shared Function AlmacenControladorEsCorporativo() As Boolean
        ' ''    Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''    Dim Almacen As Dominio.Catalogos.ClsAlmacen = Dominio.Catalogos.FabricaCatalogos.ObtenAlmacen(DAO.ParametrosTerminal.parametroalmacen.valor)
        ' ''    ' Dim miCanal As Catalogos.ClsCanalDistribucion = Catalogos.FabricaCatalogos.ObtenCanalDistribucion(ParamtetrosSucursal.CanalDistribucion)
        ' ''    'Dim miTipoCorporativo As Integer = DAO.ParametroAdministradoObtener("CTL", "TIPOCANAL_CORPORATIVO")
        ' ''    'If miCanal.TipoCanal.Folio = miTipoCorporativo Then
        ' ''    '    Return True
        ' ''    'End If
        ' ''    Return Almacen.AlmacenControlador.EsCorporativo
        ' ''End Function

        'Public Shared Function ALMACEN() As String
        '    'Sistema       : Vizur
        '    'Modulo        : General
        '    'Procedimiento : ALMACEN
        '    'Desarrolo     : David Adan Velazquez Sanchez
        '    'Fecha         : 13 de Noviembre del 2006
        '    'Que hace      : Regresa El Folio del Almacen configurado en el ini
        '    Return Val(archivoIni.GetEntry("ALMACEN")).ToString
        'End Function
#End Region
#Region "Combos"

        Public Shared Sub ComboBox_AgregarSeleccion(ByRef MyCbo As ComboBox)
            MyCbo.Items.Insert(0, " << SELECCIONE >> ")
            MyCbo.SelectedIndex = 0
        End Sub
        Public Shared Sub ComboBox_ColocaIndiceDesdeTexto(ByRef MyCbo As ComboBox, ByVal prmCadena As String)
            'Coloca el indice en un combobox apartir de un texto
            'busca el texto enviado en los items del combo y deja el indice alli
            Dim pos As Integer
            pos = MyCbo.FindString(prmCadena)
            MyCbo.SelectedIndex = IIf(pos < 0, 0, pos)
        End Sub
        Public Shared Sub ComboBox_ColocaIndiceDesdeTexto(ByVal MyCbo As ComboBox, ByVal prmDato As Integer)
            Dim i As Integer
            For i = 0 To MyCbo.Items.Count - 1
                MyCbo.SelectedIndex = i
                If MyCbo.SelectedValue = prmDato Then
                    Exit For
                End If
            Next
        End Sub

        Public Shared Sub ComboBox_ColocaIndiceDesdeClase(ByVal MyCbo As ComboBox, ByVal prmClase As ClsBaseComun)
            For x As Integer = 0 To MyCbo.Items.Count - 1
                If TypeOf MyCbo.Items.Item(x) Is ClsBaseComun Then
                    If prmClase.Descripcion = CType(MyCbo.Items.Item(x), ClsBaseComun).Descripcion Then
                        MyCbo.SelectedIndex = x
                        Exit Sub
                    End If
                End If
            Next
        End Sub

#End Region

#Region "Formatos Para Numeros En Impresion"
        Public Enum FormatosNumeros
            Importes = 0
            ImportesFormateadosConComas
            Pesos
            Precios
            TipoCambio
            Piezas
            Factores
            Fechas
            PesoEtiqueta
        End Enum

        'Private Shared Sub InicializaGrid()
        '    MiGrid = New FarPoint.Win.Spread.FpSpread
        '    MiGrid.Sheets.Add(New FarPoint.Win.Spread.SheetView)
        '    MiGrid.ActiveSheet = MiGrid.Sheets(0)
        '    MiGrid.ActiveSheet.Columns.Add(0, 7)
        '    'Importes
        '    MiGrid.ActiveSheet.Columns(FormatosNumeros.Importes).CellType = New FarPoint.Win.Spread.CellType.NumberCellType
        '    CType(MiGrid.ActiveSheet.Columns(FormatosNumeros.Importes).CellType, FarPoint.Win.Spread.CellType.NumberCellType).DecimalPlaces = 2
        '    CType(MiGrid.ActiveSheet.Columns(FormatosNumeros.Importes).CellType, FarPoint.Win.Spread.CellType.NumberCellType).DecimalSeparator = "."
        '    CType(MiGrid.ActiveSheet.Columns(FormatosNumeros.Importes).CellType, FarPoint.Win.Spread.CellType.NumberCellType).FixedPoint = True
        '    'CType(MiGrid.ActiveSheet.Columns(FormatosNumeros.Importes).CellType, FarPoint.Win.Spread.CellType.NumberCellType).Separator = ","
        '    'CType(MiGrid.ActiveSheet.Columns(FormatosNumeros.Importes).CellType, FarPoint.Win.Spread.CellType.NumberCellType).ShowSeparator = True
        '    'ImportesFormateadosConComas
        '    MiGrid.ActiveSheet.Columns(FormatosNumeros.ImportesFormateadosConComas).CellType = New FarPoint.Win.Spread.CellType.NumberCellType
        '    CType(MiGrid.ActiveSheet.Columns(FormatosNumeros.ImportesFormateadosConComas).CellType, FarPoint.Win.Spread.CellType.NumberCellType).DecimalPlaces = 2
        '    CType(MiGrid.ActiveSheet.Columns(FormatosNumeros.ImportesFormateadosConComas).CellType, FarPoint.Win.Spread.CellType.NumberCellType).DecimalSeparator = "."
        '    CType(MiGrid.ActiveSheet.Columns(FormatosNumeros.ImportesFormateadosConComas).CellType, FarPoint.Win.Spread.CellType.NumberCellType).FixedPoint = True
        '    CType(MiGrid.ActiveSheet.Columns(FormatosNumeros.ImportesFormateadosConComas).CellType, FarPoint.Win.Spread.CellType.NumberCellType).Separator = ","
        '    CType(MiGrid.ActiveSheet.Columns(FormatosNumeros.ImportesFormateadosConComas).CellType, FarPoint.Win.Spread.CellType.NumberCellType).ShowSeparator = True
        '    'Pesos
        '    MiGrid.ActiveSheet.Columns(FormatosNumeros.Pesos).CellType = New FarPoint.Win.Spread.CellType.NumberCellType
        '    CType(MiGrid.ActiveSheet.Columns(FormatosNumeros.Pesos).CellType, FarPoint.Win.Spread.CellType.NumberCellType).DecimalPlaces = 3
        '    CType(MiGrid.ActiveSheet.Columns(FormatosNumeros.Pesos).CellType, FarPoint.Win.Spread.CellType.NumberCellType).DecimalSeparator = "."
        '    CType(MiGrid.ActiveSheet.Columns(FormatosNumeros.Pesos).CellType, FarPoint.Win.Spread.CellType.NumberCellType).FixedPoint = True
        '    'CType(MiGrid.ActiveSheet.Columns(FormatosNumeros.Pesos).CellType, FarPoint.Win.Spread.CellType.NumberCellType).Separator = ","
        '    'CType(MiGrid.ActiveSheet.Columns(FormatosNumeros.Pesos).CellType, FarPoint.Win.Spread.CellType.NumberCellType).ShowSeparator = True

        '    'Pesos Etiquetas
        '    MiGrid.ActiveSheet.Columns(FormatosNumeros.PesoEtiqueta).CellType = New FarPoint.Win.Spread.CellType.NumberCellType
        '    CType(MiGrid.ActiveSheet.Columns(FormatosNumeros.PesoEtiqueta).CellType, FarPoint.Win.Spread.CellType.NumberCellType).DecimalPlaces = 2
        '    CType(MiGrid.ActiveSheet.Columns(FormatosNumeros.PesoEtiqueta).CellType, FarPoint.Win.Spread.CellType.NumberCellType).DecimalSeparator = "."
        '    CType(MiGrid.ActiveSheet.Columns(FormatosNumeros.PesoEtiqueta).CellType, FarPoint.Win.Spread.CellType.NumberCellType).FixedPoint = True
        '    'Precios
        '    MiGrid.ActiveSheet.Columns(FormatosNumeros.Precios).CellType = New FarPoint.Win.Spread.CellType.NumberCellType
        '    CType(MiGrid.ActiveSheet.Columns(FormatosNumeros.Precios).CellType, FarPoint.Win.Spread.CellType.NumberCellType).DecimalPlaces = 4
        '    CType(MiGrid.ActiveSheet.Columns(FormatosNumeros.Precios).CellType, FarPoint.Win.Spread.CellType.NumberCellType).DecimalSeparator = "."
        '    CType(MiGrid.ActiveSheet.Columns(FormatosNumeros.Precios).CellType, FarPoint.Win.Spread.CellType.NumberCellType).FixedPoint = True
        '    'CType(MiGrid.ActiveSheet.Columns(FormatosNumeros.Precios).CellType, FarPoint.Win.Spread.CellType.NumberCellType).Separator = ","
        '    'CType(MiGrid.ActiveSheet.Columns(FormatosNumeros.Precios).CellType, FarPoint.Win.Spread.CellType.NumberCellType).ShowSeparator = True
        '    'TipoCambio
        '    MiGrid.ActiveSheet.Columns(FormatosNumeros.TipoCambio).CellType = New FarPoint.Win.Spread.CellType.NumberCellType
        '    CType(MiGrid.ActiveSheet.Columns(FormatosNumeros.TipoCambio).CellType, FarPoint.Win.Spread.CellType.NumberCellType).DecimalPlaces = 4
        '    CType(MiGrid.ActiveSheet.Columns(FormatosNumeros.TipoCambio).CellType, FarPoint.Win.Spread.CellType.NumberCellType).DecimalSeparator = "."
        '    CType(MiGrid.ActiveSheet.Columns(FormatosNumeros.TipoCambio).CellType, FarPoint.Win.Spread.CellType.NumberCellType).FixedPoint = True
        '    'CType(MiGrid.ActiveSheet.Columns(FormatosNumeros.TipoCambio).CellType, FarPoint.Win.Spread.CellType.NumberCellType).Separator = ","
        '    'CType(MiGrid.ActiveSheet.Columns(FormatosNumeros.TipoCambio).CellType, FarPoint.Win.Spread.CellType.NumberCellType).ShowSeparator = True
        '    'Piezas
        '    MiGrid.ActiveSheet.Columns(FormatosNumeros.Piezas).CellType = New FarPoint.Win.Spread.CellType.NumberCellType
        '    CType(MiGrid.ActiveSheet.Columns(FormatosNumeros.Piezas).CellType, FarPoint.Win.Spread.CellType.NumberCellType).DecimalPlaces = 0
        '    'Factores
        '    MiGrid.ActiveSheet.Columns(FormatosNumeros.Factores).CellType = New FarPoint.Win.Spread.CellType.NumberCellType
        '    CType(MiGrid.ActiveSheet.Columns(FormatosNumeros.Factores).CellType, FarPoint.Win.Spread.CellType.NumberCellType).DecimalPlaces = 4
        '    CType(MiGrid.ActiveSheet.Columns(FormatosNumeros.Factores).CellType, FarPoint.Win.Spread.CellType.NumberCellType).DecimalSeparator = "."
        '    CType(MiGrid.ActiveSheet.Columns(FormatosNumeros.Factores).CellType, FarPoint.Win.Spread.CellType.NumberCellType).FixedPoint = True
        '    'CType(MiGrid.ActiveSheet.Columns(FormatosNumeros.Factores).CellType, FarPoint.Win.Spread.CellType.NumberCellType).Separator = ","
        '    'CType(MiGrid.ActiveSheet.Columns(FormatosNumeros.Factores).CellType, FarPoint.Win.Spread.CellType.NumberCellType).ShowSeparator = True
        '    'Fechas
        '    MiGrid.ActiveSheet.Columns(FormatosNumeros.Fechas).CellType = New FarPoint.Win.Spread.CellType.DateTimeCellType
        '    CType(MiGrid.ActiveSheet.Columns(FormatosNumeros.Fechas).CellType, FarPoint.Win.Spread.CellType.DateTimeCellType).UserDefinedFormat = "dd/MM/yyyy"
        'End Sub
        'Public Shared Function ConvierteValorACadenaStringFormateada(ByVal prmExpresion As Object, ByVal prmFormato As FormatosNumeros) As String
        '    If MiGrid Is Nothing Then InicializaGrid()
        '    MiGrid.ActiveSheet.RowCount = 1
        '    MiGrid.ActiveSheet.Cells(0, prmFormato).Value = prmExpresion
        '    Return MiGrid.ActiveSheet.Cells(0, prmFormato).Text
        'End Function

#End Region




        'Public Shared Sub PgMuestraOcultaImagenComentario(ByRef PrmSheetView As FarPoint.Win.Spread.SheetView, ByVal prmRow As Integer, ByVal PrmColComentariosTexto As Integer, ByVal prmColComentariosImagen As Integer, ByVal prmImagen As System.Drawing.Image)
        'Elaboró:     L.I. César Octavio Niebla Manjarrez 
        'Fecha:       26-Enero-2007
        'Que Hace:    Muestra u Oculta Imagen indicadora ImportesFormateadosConComasde Comentario en celda de Grid
        '             Recibe:
        '             SheetView Por Referencia, 
        '             Row = Renglón de Sheetview, 
        '             PrmColComentariosTexto = Columna que contiene el texto de Comentario
        '             prmColComentariosImagen = Columna que inidica si contiene ó no texto de Comentario
        '             prmImagen de tipo System.Drawing.Image con la Imagen a Mostrar 
        '             la función Trabaja de la Siguiente Manera:
        '             -----------------------------------------------------------------------------------
        '                   Criterio                        Acción
        '             Columna de texto vacia              Se oculta Imágen
        '             Columna de texto No vacia           Se Muestra Imágen
        '             -----------------------------------------------------------------------------------

        '    With PrmSheetView
        'Dim vcelda As New FarPoint.Win.Spread.CellType.GeneralCellType

        '        If Not .Cells(prmRow, PrmColComentariosTexto).Text.Trim = "" Then 'Con Comentarios
        '            vcelda.BackgroundImage = New FarPoint.Win.Picture(prmImagen)
        '            .Cells(prmRow, prmColComentariosImagen).CellType = vcelda
        '        Else
        '            vcelda.BackgroundImage = Nothing                              'Sin Comentarios
        '            .Cells(prmRow, prmColComentariosImagen).CellType = vcelda
        '        End If
        '    End With
        'End Sub


        'Public Shared Function FgConviertePeso(ByVal PrmPeso As Decimal, ByVal PrmUnidad As Integer, ByVal PrmUnidadConversion As Integer) As Decimal
        '    'Elaboró:     L.I. César Octavio Niebla Manjarrez 
        '    'Fecha:       02-Marzo-2007
        '    'Modulo:      Inventario            
        '    'Que Hace:    Regresa Peso a unidad de conversión especificada
        '    'Parametros:  PrmPeso.- Valor de Peso en Tipo "PrmUnidad"
        '    '             PrmUnidad.- Unidad de peso del "PrmPeso"
        '    '             PrmUnidadConversion.-Unidad de peso a Convertir
        '    Dim oConversion As Dominio.Productos.ClsConversionUnidades
        '    Dim Unidad As Dominio.Productos.ClsUnidad = Dominio.Productos.FabricaProductos.ObtenUnidad(PrmUnidad)
        '    Dim UnidadConversion As Dominio.Productos.ClsUnidad = Dominio.Productos.FabricaProductos.ObtenUnidad(PrmUnidadConversion)

        '    oConversion = Dominio.Productos.FabricaProductos.ObtenUnidadConversion(Unidad, UnidadConversion)
        '    Return PrmPeso * oConversion.Equivalencia()
        'End Function

        ' ''Public Shared Function Validame(ByVal prmAgrupador As String, ByVal prmControlContenedor As Control, ByRef prmControlInvalido As Control, ByRef prmMensaje As String) As Boolean
        ' ''    Dim Mensaje As String
        ' ''    Dim vArray As ArrayList



        ' ''    For Each co As Control In prmControlContenedor.Controls
        ' ''        Dim tagCriterio As Validaciones
        ' ''        If co.Controls.Count > 0 Then
        ' ''            ClsTools.Validame(prmAgrupador, co, prmControlInvalido, prmMensaje)
        ' ''        Else
        ' ''            If Not co.Tag Is Nothing Then
        ' ''                Try
        ' ''                    tagCriterio = CType(co.Tag, Validaciones)
        ' ''                Catch ex As Exception
        ' ''                    tagCriterio = Nothing
        ' ''                End Try
        ' ''                If Not tagCriterio Is Nothing Then
        ' ''                    If tagCriterio.Agrupador = prmAgrupador.ToUpper Then
        ' ''                        If co.GetType.Name.ToUpper = "AccTextBoxAdvanced" Then
        ' ''                            If co.Text.Trim = "" Then 
        ' ''                                CType(co, AccTextBoxAdvanced).SetColorElementoInvalido()
        ' ''                                If prmControlInvalido Is Nothing Then
        ' ''                                    prmControlInvalido = co
        ' ''                                    prmMensaje = tagCriterio.Mensaje
        ' ''                                Else
        ' ''                                    If tagCriterio.Orden < CType(prmControlInvalido.Tag, Validaciones).Orden Then
        ' ''                                        prmControlInvalido = co
        ' ''                                        prmMensaje = tagCriterio.Mensaje
        ' ''                                    End If
        ' ''                                End If
        ' ''                            End If
        ' ''                            'If Mensaje Is Nothing Then Mensaje = tagCriterio.Mensaje
        ' ''                            'If prmControlInvalido Is Nothing Then prmControlInvalido = co
        ' ''                        End If
        ' ''                    End If
        ' ''                End If
        ' ''            End If
        ' ''        End If
        ' ''    Next
        ' ''    Return True
        ' ''End Function

        'Public Const TituloMessageBox As String = "Sistema Estratégico de Nómina"
        Public Const ErrorCodigo As String = "Clave incorrecta"
        Public Const ValorPorcentaje As String = "El valor del porcentaje no debe exceder el 100%"
        Public Const atrLLave As String = "kPensaranDeLosÑascosEnJapon"
        'Public Const NombreEmpresa As String = "SUKARNE S.A. DE C.V."
        Public Const TituloReferenciaCatalogo As String = "<F2 Ayuda> <Supr Baja Registro> <Enter/Doble Click Modificar Registro>"
        Public Const TituloReferenciaAyuda As String = "" 'ControlesSEN.JapacCustomForm.TituloReferenciaAyuda
        Public Const PaginaSig As String = "<Ctrl + Av. Pag.  Siguiente página>"
        Public Const PaginaAnt As String = "<Ctrl + Re. Pag.  Retrocede página>"
        Public Const Empresa As String = "Junta Municipal de Agua Potable y Alcantarillado"


        Public Shared Sub MuestraMensajeValidacion(ByVal prmMensaje As String, ByRef bLanzado As Boolean, Optional ByRef prmControl As Control = Nothing)
            If Not bLanzado Then
                MessageBox.Show(prmMensaje, Comun.ClsTools.GlobalSistemaCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                bLanzado = True
                If Not prmControl Is Nothing Then
                    prmControl.Focus()
                End If
            Else
                If Not prmControl Is Nothing Then
                    prmControl.BackColor = DevuelveColorDatosErroneos()
                End If
            End If
        End Sub


        Public Shared Function DevuelveColorDatosErroneos() As System.Drawing.Color
            Return System.Drawing.Color.Yellow
        End Function

        Public Shared Function Mensaje_ReactivarCodigo() As DialogResult
            Dim miMensaje As String = "Código dado de baja. ¿Desea reactivarlo?"
            Return MessageBox.Show(miMensaje, GlobalSistemaCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        End Function

        Public Enum PantallasMensajes
            CompraDirecta = 0
        End Enum

        Public Shared Function Mensaje_ConfirmacionBorrarGuardarProceso(ByVal prmTipo As ETipoMensaje, ByVal prmPantalla As PantallasMensajes) As DialogResult
            If prmTipo = ETipoMensaje.Borrar Then
                Select Case prmPantalla
                    Case PantallasMensajes.CompraDirecta
                        Return MessageBox.Show("¿Seguro de cancelar la entrada?", GlobalSistemaCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                End Select
            ElseIf prmTipo = ETipoMensaje.Guardar Then
                Return MessageBox.Show("¿Desea guardar los datos?", GlobalSistemaCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            End If
        End Function

        Public Shared Function Mensaje_ConfirmacionBorrarGuardar(ByVal prmTipo As ETipoMensaje) As DialogResult
            If prmTipo = ETipoMensaje.Borrar Then
                Return MessageBox.Show("¿Desea cancelar el registro?", GlobalSistemaCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            ElseIf prmTipo = ETipoMensaje.Guardar Then
                Return MessageBox.Show("¿Desea guardar los datos?", GlobalSistemaCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            ElseIf prmTipo = ETipoMensaje.BorrarRenglon Then
                Return MessageBox.Show("¿Desea eliminar el renglón?", GlobalSistemaCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            End If
        End Function

        'Mensajes Confirmaciones

        Public Shared Function MensajeVentanaNuevoConfirmacion() As DialogResult
            Return MessageBox.Show("¿Desea Limpiar la ventana?", GlobalSistemaCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        End Function

        Public Shared Function MensajeAbandonoVentanaConfirmacion() As DialogResult
            Return MessageBox.Show(GlobalSistemaConfirmaCerrarVentana, GlobalSistemaCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        End Function

        Public Shared Function MensajeImprimir(ByVal TipoFormato As String) As DialogResult
            Return MessageBox.Show("¿Desea Imprimir el formato de " & TipoFormato & "?", GlobalSistemaCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        End Function




        'Mensajes para Procesos

        Public Shared Function MensajeAbandonoVentanaProceso() As DialogResult
            Return MessageBox.Show("¿Desea cerrar la ventana?, si lo hace perderá los datos que no hayan sido guardados.", GlobalSistemaCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        End Function

        Public Shared Function MensajeVentanaNuevoProceso() As DialogResult
            Return MessageBox.Show("Existen datos modificados ¿Desea limpiar la pantalla?", GlobalSistemaCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        End Function

        Public Shared Function MensajeVentanaSalirProceso() As DialogResult
            Return MessageBox.Show("Existen datos modificados ¿Desea salir de la pantalla?", GlobalSistemaCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        End Function

        Public Shared Function MensajeAbandonoTab() As DialogResult
            Return MessageBox.Show("Desea abandonar pestaña activa, si lo hace perderá los datos que no hayan sido guardados.", GlobalSistemaCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        End Function

        'Consultas y procesos

        Public Shared Function MensajeGeneralNuevaConsulta() As DialogResult
            Return MessageBox.Show("¿Desea realizar una nueva consulta?," & vbCr & "si lo hace perderá los datos configurados actualmente.", GlobalSistemaCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        End Function

        Public Shared Function MensajeAbandonoVentanaEjecucionConsulta() As DialogResult
            Return MessageBox.Show("¿Desea cerrar la ventana sin haber ejecutado la consulta?.", GlobalSistemaCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        End Function

        Public Shared Function MensajeAbandonoVentanaImpresionReporte() As DialogResult
            Return MessageBox.Show("¿Desea cerrar la ventana sin haber impreso reporte?", GlobalSistemaCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        End Function

        Public Shared Function MensajeVentanaNuevoImpresionReporte() As DialogResult
            Return MessageBox.Show("Existe configurado criterios de impresión de reporte. ¿Desea crear nueva configuración?", GlobalSistemaCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        End Function

        'Mensajes para Catálogos
        Public Shared Function MensajeAbandonoVentana() As DialogResult
            Return MessageBox.Show("Existen datos modificados. ¿Desea actualizar los datos?", GlobalSistemaCaption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        End Function

        Public Shared Function MensajeVentanaNuevo() As DialogResult
            Return MessageBox.Show("Existen datos modificados. ¿Desea actualizar los datos?", GlobalSistemaCaption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        End Function

        Public Shared Function MensajePregunta(ByVal prmPregunta As String) As DialogResult

            If prmPregunta = "" Then
                Return DialogResult.No
            End If

            Return MessageBox.Show(prmPregunta, GlobalSistemaCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        End Function


        Public Shared Function MensajeFocoGrid() As DialogResult
            Return MessageBox.Show("Existen datos modificados. ¿Desea actualizar los datos?", GlobalSistemaCaption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        End Function

        Public Shared Sub MensajeExitoExportacion()
            MessageBox.Show("La exportación fué exitosa.", GlobalSistemaCaption, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub

        Public Shared Function MensajeExistemDatosRelacionados() As DialogResult
            Return MessageBox.Show("Existen registros relacionados. ¿Desea continuar?", GlobalSistemaCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        End Function



        Public Shared Function MensajeNoArrojoInformacion(Optional ByVal NombreReporte As String = "")
            Dim cCadena As String = ""
            If NombreReporte <> "" Then cCadena = " para el reporte de " & NombreReporte
            MessageBox.Show("No se encontraron registros" & cCadena, GlobalSistemaCaption, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Function

        Public Shared Sub MensajeNoHayInformacionaImprimir()
            MessageBox.Show("No hay datos a imprimir", GlobalSistemaCaption, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub

        Public Shared Sub Inicializar()

            CreaConfiguracionDeMaquina()
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia


            'CreaFoliosAdministrados()
            'CreaOperacionesSupervisadas()
            'CreaParametrosAdministrados()

            'If DAO.ParametroAdministradoObtener("PRM", "Crear_Administracion_Arquitectura_Referente_Operaciones_De_BaseDeDatos") = 1 Then
            '    CargaParametrosADDA()

            '    CreaParametrosAdministrados()
            '    'CreaFoliosAdministrados()
            '    CreaOperacionesSupervisadas()
            'Else
            CargaParametrosADDA()
            'End If
            'Call CreaServidoresAmigos()

        End Sub

        Public Shared Sub CreaConfiguracionDeMaquina()

            archivoIni = New Ini.IniFileController
            'archivoIni.OpenINIFile("C:\\AdSum\\AdSum.Ini")

            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            archivoIni.OpenINIFile(DAO.GetRutaArchivoIni)

            archivoIni.AddEntry("SERVIDOR", "ADSUM000\PROYECTOS")
            archivoIni.AddEntry("BASE_DE_DATOS", "FARMACON2")

            archivoIni.AddEntry("ALMACEN", "0")
            archivoIni.AddEntry("CAJA", "0")
            archivoIni.AddEntry("IMPRIMIRTICKET", "0")
            'archivoIni.AddEntry("CANALDEDISTRIBUCION", "0")


            'Dim misParametrosTerminal As New Parametros.ClsParametrosTerminal
            'misParametrosTerminal.ParametroAlmacen = New Comunes.Comun.ClsParametroIni("ALMACEN", False)
            'misParametrosTerminal.ParametroCaja = New Comunes.Comun.ClsParametroIni("CAJA", False)

            ' DAO.ParametrosTerminal = misParametrosTerminal

        End Sub

        Private Shared Sub CreaServidoresAmigos()
            'DAO.ServidorAmigo_Agregar("Admon", "Admon", "SC_Sukarne_des", "SA", "Adsum12")
            'DAO.ServidorAmigo_Agregar("Visur", "192.168.10.57\SQLEXPRESS", "SC_Sukarne_des", "SA", "Adsum12")
        End Sub

        Public Shared Sub CreaFoliosAdministradosClasificadores()
            Dim vTabla As New DataTable
            Dim vSql As String
            vSql = "SELECT nTipoClasificador FROM CTL_TipoClasificador(NOLOCK)"
            DAO.RegresaConsultaSQL(vSql, vTabla)
            For Each vRow As DataRow In vTabla.Rows
                DAO.FolioAdministradoAgregar("CTL_Clasificadores_" & vRow("nTipoClasificador"), "Folios Administrados logicos para los Clasificadores de clientes dependiendo del cliente" & vRow("nTipoClasificador"))
            Next
        End Sub

        'Public Shared Sub CreaFoliosAdministradosSucursalesClientes()
        '    Dim vTabla As New DataTable
        '    Dim vSql As String
        '    vSql = "SELECT nCliente FROM CTL_Clientes(NOLOCK)"
        '    DAO.RegresaConsultaSQL(vSql, vTabla)
        '    For Each vRow As DataRow In vTabla.Rows
        '        DAO.FolioAdministradoAgregar("CTL_SucursalesCliente_" & vRow("nCliente"), "Folios Administrados logicos para los sucursales de clientes dependiendo del cliente" & vRow("nCliente"))
        '    Next
        'End Sub

        Public Shared Sub CreaFoliosAdministradosEstadosCiudadesColonias()

            'Folios para los consecutivos de estados logicos por pais
            Dim vTabla As New DataTable
            Dim vSql As String
            vSql = "SELECT nIdPais FROM CTL_Paises(NOLOCK)"
            DAO.RegresaConsultaSQL(vSql, vTabla)
            For Each vRow As DataRow In vTabla.Rows
                DAO.FolioAdministradoAgregar("CTL_EstadosPaises_" & vRow("nIDPais"), "Folios Administrados logicos para los estados dependiendo de el pais al cual pertenecen PAIS:" & vRow("nIDPais"))
            Next

            'Folios para los consecutivos de Ciudades por Estados
            vSql = "SELECT nIdEstado FROM CTL_Estados(NOLOCK)"
            DAO.RegresaConsultaSQL(vSql, vTabla)
            For Each vRow As DataRow In vTabla.Rows
                DAO.FolioAdministradoAgregar("CTL_MunicpiosEstados_" & vRow("nIdEstado"), "Folios Administrados logicos para los Municipios dependiendo de el estado al cual pertenecen ESTADO:" & vRow("nIdEstado"))
            Next

            'Folios para los consecutivos de Colonias por Delegaciones
            'Cambio de delegaciones por municpios y este quedo a un nivel arriba de las ciudades que se manejaran como localidades
            vSql = "SELECT nIDMunicipio ,cDescripcion FROM CTL_Municipios(NOLOCK)"
            DAO.RegresaConsultaSQL(vSql, vTabla)
            For Each vRow As DataRow In vTabla.Rows
                DAO.FolioAdministradoAgregar("CTL_CiudadesMunicipios_" & vRow("nIDMunicipio"), "Folios Administrados logicos para las ciudades dependiendo de los municipios al cual pertenecen MUNICIPIO:" & vRow("cDescripcion"))
            Next

            'Folios para los consecutivos de Colonias por Ciudades
            vSql = "SELECT nIdCiudad ,cDescripcion FROM CTL_Ciudades(NOLOCK)"
            DAO.RegresaConsultaSQL(vSql, vTabla)
            For Each vRow As DataRow In vTabla.Rows
                DAO.FolioAdministradoAgregar("CTL_ColoniasCiudades_" & vRow("nIdCiudad"), "Folios Administrados logicos para las colonias dependiendo de la ciudades al cual pertenecen CIUDAD:" & vRow("cDescripcion"))
            Next
        End Sub

        Public Shared Sub CreaFoliosAdministrados()
            DAO = DataAccessCls.DevuelveInstancia
            'Folios Administrados de Catalogos Proyecto SIP

            DAO.FolioAdministradoAgregar("CTL_Proveedores", "Folio administrado para la tabla CTL_Proveedores")
            DAO.FolioAdministradoAgregar("CTL_ProveedoresCuentasBancarias", "Folio administrado para la tabla CTL_ProveedoresCuentasBancarias")
            DAO.FolioAdministradoAgregar("CTL_ProveedoresProntosPagos", "Folio administrado para la tabla CTL_ProveedoresProntosPagos")
            DAO.FolioAdministradoAgregar("CTL_ProveedoresContactos", "Folio administrado para la tabla CTL_ProveedoresContactos")
            DAO.FolioAdministradoAgregar("CTL_ProveedoresBitacoraObservaciones", "Folio administrado para la tabla CTL_ProveedoresBitacoraObservaciones")
            DAO.FolioAdministradoAgregar("CTL_ProveedoresClasificadores", "Folio administrado para la tabla CTL_ProveedoresClasificadores")
            DAO.FolioAdministradoAgregar("COM_ProveedoresNegociaciones", "Folio administrado para la tabla COM_ProveedoresNegociaciones")
            DAO.FolioAdministradoAgregar("CTL_Puestos", "Folio administrado para la tabla CTL_Puestos")
            DAO.FolioAdministradoAgregar("CTL_TiposArticulos", "Folio administrado para la tabla CTL_TiposArticulos")
            DAO.FolioAdministradoAgregar("CTL_Turnos", "Folio administrado para la tabla CTL_Turnos")
            DAO.FolioAdministradoAgregar("CTL_Departamentos", "Folio administrado para la tabla CTL_Departamentos")
            DAO.FolioAdministradoAgregar("CTL_Areas", "Folio administrado para la tabla CTL_Areas")
            DAO.FolioAdministradoAgregar("CTL_Involucrados", "Folio administrado para la tabla CTL_Involucrados")
            DAO.FolioAdministradoAgregar("CTL_Clientes", "Folio administrado para la tabla CTL_Clientes")
            DAO.FolioAdministradoAgregar("CTL_Bancos", "Folio administrado para la tabla CTL_Bancos")
            DAO.FolioAdministradoAgregar("CTL_Zonas", "Folio administrado para la tabla CTL_Zonas")
            DAO.FolioAdministradoAgregar("CTL_Involucrados", "Folio administrado para la tabla CTL_Involucrados")
            DAO.FolioAdministradoAgregar("CTL_Presentaciones", "Folio administrado para la tabla CTL_Presentaciones")

            'Inicia creación de folios para catálogos de geografias:
            DAO.FolioAdministradoAgregar("CTL_Estados", "Folio administrado para la tabla CTL_Estados")
            DAO.FolioAdministradoAgregar("CTL_Municipios", "Folio administrado para la tabla CTL_Municipios")
            DAO.FolioAdministradoAgregar("CTL_Ciudades", "Folio administrado para la tabla CTL_Ciudades")
            DAO.FolioAdministradoAgregar("CTL_Colonias", "Folio administrado para la tabla CTL_Colonias")

            DAO.FolioAdministradoAgregar("CTL_Estados_Logico", "Folio lógico administrado para la tabla CTL_Estados")
            DAO.FolioAdministradoAgregar("CTL_Municipios_Logico", "Folio lógico administrado para la tabla CTL_Municipios")
            DAO.FolioAdministradoAgregar("CTL_Ciudades_Logico", "Folio lógico administrado para la tabla CTL_Ciudades")
            DAO.FolioAdministradoAgregar("CTL_Colonias_Logico", "Folio lógico administrado para la tabla CTL_Colonias")
            'Termina creación de folios para catálogos de geografias

            DAO.FolioAdministradoAgregar("ADSUM_TiposDatos", "Folio administrado para la tabla ADSUM_TiposDatos")
            Dim param As Parametros.ClsParametrosTerminal = DAO.ParametrosTerminal
            DAO.FolioAdministradoAgregar("INV_ConfiguracionInventario_" & param.Almacen, "Folio administrado para la tabla INV_ConfiguracionInventario por almacen")
            DAO.FolioAdministradoAgregar("INV_InventarioFisico_" & param.Almacen, "Folio administrado para la tabla INV_InventarioFisico por almacen")
            DAO.FolioAdministradoAgregar("INV_InventarioFisicoCapturaConteos_" & param.Almacen, "Folio administrado para la tabla INV_InventarioFisicoCapturaConteos por almacen")
            DAO.FolioAdministradoAgregar("SemaforoActualizacionInventarioFisico_" & param.Almacen, "Folio que funciona como semaforo para la actualizacion de datos en el inventario fisico")


            ' Folios de Inventarios fisico de productos
            Dim paramP As Parametros.ClsParametrosTerminal = DAO.ParametrosTerminal
            DAO.FolioAdministradoAgregar("PRO_ConfiguracionInventario_" & paramP.Almacen, "Folio administrado para la tabla PRO_ConfiguracionInventario por almacen")
            DAO.FolioAdministradoAgregar("PRO_InventarioFisico_" & paramP.Almacen, "Folio administrado para la tabla PRO_InventarioFisico por almacen")
            DAO.FolioAdministradoAgregar("PRO_InventarioFisicoCapturaConteos_" & paramP.Almacen, "Folio administrado para la tabla PRO_InventarioFisicoCapturaConteos por almacen")
            DAO.FolioAdministradoAgregar("SemaforoActualizacionInventarioFisicoProductos_" & paramP.Almacen, "Folio que funciona como semaforo para la actualizacion de datos en el inventario fisico")

            'Folios Administrados Para Semaforos de almacenes
            'Dim DtSemaforo As DataTable
            'DtSemaforo = Dominio.Catalogos.FabricaCatalogos.ObtenAlmacenesParaCrearSemaforos()

            'For Each drSemaforo As DataRow In DtSemaforo.Rows
            '    DAO.FolioAdministradoAgregar("Semaforo_" & drSemaforo("nAlmacen"), "Folio administrado para semaforos de almacen")
            'Next

            DAO.FolioAdministradoAgregar("CTL_Causas", "Folio administrado para la tabla CTL_Causas")
        End Sub

        Public Shared Function RegresaParametroAdministrado(ByVal prmContexto As String, ByVal prmParametro As String) As String
            DAO = DataAccessCls.DevuelveInstancia
            Return DAO.ParametroAdministradoObtener(prmContexto, prmParametro)
        End Function

        Public Shared Sub CreaParametrosAdministrados()
            DAO = DataAccessCls.DevuelveInstancia

            DAO.ParametroAdministradoAgregar("PRM", "TAMAÑO_FUENTE_IMPRESION_XTRAGRID", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Tamaño de la fuente para la impresión de tipo XtraPrinting", 8.25)
            DAO.ParametroAdministradoAgregar("PRM", "Correo_Envio", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Correo con el que se mandan los correos", "josel@adsum.com.mx")
            DAO.ParametroAdministradoAgregar("PRM", "Correo_Password", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Correo Password de la cuenta con la que se envia correo", "123456")
            '-------------------------------Parámetros administrados del modulo de INVENTARIOS (INV)--------------------------------------

            'Parametros para los estatus de Negociaciones
            DAO.ParametroAdministradoAgregar("COM", "ESTATUS_NEGOCIACIONDESCRIPCION_CANCELADO", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parámetro administrado para conocer la descripción del estatus de cancelado para las negociaciones", "CANCELADO")
            DAO.ParametroAdministradoAgregar("COM", "ESTATUS_NEGOCIACIONDESCRIPCION_REGISTRADO", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parámetro administrado para conocer la descripción del estatus de registrado para las negociaciones", "REGISTRADO")
            DAO.ParametroAdministradoAgregar("COM", "ESTATUS_NEGOCIACIONDESCRIPCION_CADUCADO", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parámetro administrado para conocer la descripción del estatus de caducado para las negociaciones", "CADUCADO")

            'Parametros para los estatus de pedidos y solicitudes de traspasos
            DAO.ParametroAdministradoAgregar("INV", "ESTATUS_PEDIDO_CANCELADO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro administrado para conocer el estatus de cancelado para los pedidos y solicitudes de traspasos", 0)
            DAO.ParametroAdministradoAgregar("INV", "ESTATUS_PEDIDO_REGISTRADO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro administrado para conocer el estatus de registrado para los pedidos y solicitudes de traspasos", 1)
            DAO.ParametroAdministradoAgregar("INV", "ESTATUS_PEDIDO_SURTIDO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro administrado para conocer el estatus de surtido (total) para los pedidos y solicitudes de traspasos", 2)
            DAO.ParametroAdministradoAgregar("INV", "ESTATUS_PEDIDO_PARCIAL", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro administrado para conocer el estatus de surtido (parcial) para los pedidos y solicitudes de traspasos", 3)
            DAO.ParametroAdministradoAgregar("INV", "ESTATUS_PEDIDO_TERMINADO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro administrado para conocer el estatus de terminado para los pedidos y solicitudes de traspasos", 4)

            'Parametros para las descripciones de los estatus de pedidos y solicitudes de traspasos
            DAO.ParametroAdministradoAgregar("INV", "ESTATUS_PEDIDODESCRIPCION_CANCELADO", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parámetro administrado para conocer la descripción del estatus de cancelado para los pedidos y solicitudes de traspasos", "CANCELADO")
            DAO.ParametroAdministradoAgregar("INV", "ESTATUS_PEDIDODESCRIPCION_REGISTRADO", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parámetro administrado para conocer la descripción del estatus de registrado para los pedidos y solicitudes de traspasos", "REGISTRADO")
            DAO.ParametroAdministradoAgregar("INV", "ESTATUS_PEDIDODESCRIPCION_SURTIDO", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parámetro administrado para conocer la descripción del estatus de surtido (total) para los pedidos y solicitudes de traspasos", "SURTIDO")
            DAO.ParametroAdministradoAgregar("INV", "ESTATUS_PEDIDODESCRIPCION_PARCIAL", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parámetro administrado para conocer la descripción del estatus de surtido (parcial) para los pedidos y solicitudes de traspasos", "PARCIAL")
            DAO.ParametroAdministradoAgregar("INV", "ESTATUS_PEDIDODESCRIPCION_TERMINADO", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parámetro administrado para conocer la descripción del estatus de terminado para los pedidos y solicitudes de traspasos", "TERMINADO")

            DAO.ParametroAdministradoAgregar("INV", "PERMITE_SALIDAS_SIN_EXISTENCIA", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro administrado que permite configurar el sistema, para permitir ó impedir realizar salidas de almacén cuando no hay suficiente existencia", 1)



            'Parametros de Inventario para todos los tipos de movimientos
            'Parametros para los tipos de movimientos
            DAO.ParametroAdministradoAgregar("PRM_INV", "TIPOMOVIMIENTO_CANCELADO_ENTRADACOMPRACONTADO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parametro para saber el tipo de movimiento de la cancelacion de compra a contado", 33)
            DAO.ParametroAdministradoAgregar("PRM_INV", "TIPOMOVIMIENTO_CANCELADO_ENTRADACOMPRACREDITO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parametro para saber el tipo de movimiento de la cancelacion de compra a credito", 32)
            DAO.ParametroAdministradoAgregar("PRM_INV", "TIPOMOVIMIENTO_CANCELADO_ENTRADADEVOLUCION", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro administrado para conocer el tipo de movimiento de cancelación para la pantalla de entrada por devolución", 19)
            DAO.ParametroAdministradoAgregar("PRM_INV", "TIPOMOVIMIENTO_CANCELADO_ENTRADATRASPASO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro administrado para conocer el tipo de movimiento de cancelación para la pantalla de entrada por traspaso", 20)
            DAO.ParametroAdministradoAgregar("PRM_INV", "TIPOMOVIMIENTO_CANCELADO_RECEPCIONPEDIDO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro administrado para conocer el tipo de movimiento de cancelación para la pantalla de recepcion pedido", 21)
            DAO.ParametroAdministradoAgregar("PRM_INV", "TIPOMOVIMIENTO_CANCELADO_SALIDADEVOLUCION", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro administrado para conocer el tipo de movimiento de cancelación para la pantalla de salida por devolución", 16)
            DAO.ParametroAdministradoAgregar("PRM_INV", "TIPOMOVIMIENTO_CANCELADO_SALIDATRASPASO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro administrado para conocer el tipo de movimiento de cancelación para la pantalla de salida por traspaso", 17)
            DAO.ParametroAdministradoAgregar("PRM_INV", "TIPOMOVIMIENTO_CANCELADO_SURTIDOPEDIDO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro administrado para conocer el tipo de movimiento de cancelación para la pantalla de surtido de pedido", 18)
            DAO.ParametroAdministradoAgregar("PRM_INV", "TIPOMOVIMIENTO_ENTRADADEVOLUCION", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro administrado para concoer el tipo de movimiento de la pantalla entrada por devolución", 4)
            DAO.ParametroAdministradoAgregar("PRM_INV", "TIPOMOVIMIENTO_ENTRADAPORCOMPRA_CONTADO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro administrado para conocer el tipo de movimiento de Entrada Por Compra de Contado", 26)
            DAO.ParametroAdministradoAgregar("PRM_INV", "TIPOMOVIMIENTO_ENTRADAPORCONVERSION", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para conocer el tipo de movimiento de entradas por conversión en presentaciones", 24)
            DAO.ParametroAdministradoAgregar("PRM_INV", "TIPOMOVIMIENTO_ENTRADASCOMPRA", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro administrado para conocer el tipo de movimiento de entradas por compra", 7)
            DAO.ParametroAdministradoAgregar("PRM_INV", "TIPOMOVIMIENTO_ENTRADATRASPASO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro administrado para conocer el tipo de movimiento de la pantalla entrada por traspaso", 6)
            DAO.ParametroAdministradoAgregar("PRM_INV", "TIPOMOVIMIENTO_RECEPCIONSURTIDOPEDIDO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro administrado para conocer el tipo de movimiento de la pantalla recepción de surtido/pedido", 2)
            DAO.ParametroAdministradoAgregar("PRM_INV", "TIPOMOVIMIENTO_SALIDADEVOLUCION", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro administrado para conocer el tipo de movimiento de la pantalla salida por devolución", 3)
            DAO.ParametroAdministradoAgregar("PRM_INV", "TIPOMOVIMIENTO_SALIDAPORCONVERSION", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para conocer el tipo de movimiento de Salida por conversión en presentaciones", 23)
            DAO.ParametroAdministradoAgregar("PRM_INV", "TIPOMOVIMIENTO_SALIDATRASPASO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro administrado para conocer el tipo de movimiento de la pantalla salida por traspaso", 5)
            DAO.ParametroAdministradoAgregar("PRM_INV", "TIPOMOVIMIENTO_SURTIDOPEDIDO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro administrado para conocer el tipo de movimiento de la pantalla surtido de pedido", 1)
            DAO.ParametroAdministradoAgregar("PRM_INV", "TIPOMOVIMIENTO_SALIDA_POR_VENTA", DataAccessCls.TipoDeParametroAdministrado.Numero, "parametro administrado de inventarios para saber el tipo de movimiento Salida Por Venta", 8)
            DAO.ParametroAdministradoAgregar("PRM_INV", "TIPOMOVIMIENTO_CANCELACION_DE_ENTRADA", DataAccessCls.TipoDeParametroAdministrado.Numero, "parametro administrado de inventarios para saber el tipo de movimiento Cancelacion De Entrada", 9)
            DAO.ParametroAdministradoAgregar("PRM_INV", "TIPOMOVIMIENTO_CANCELACION_DE_SALIDA", DataAccessCls.TipoDeParametroAdministrado.Numero, "parametro administrado de inventarios para saber el tipo de movimiento Cancelacion De Salida", 10)
            DAO.ParametroAdministradoAgregar("PRM_INV", "TIPOMOVIMIENTO_SALIDA_POR_MERMA_CON_VALE", DataAccessCls.TipoDeParametroAdministrado.Numero, "parametro administrado de inventarios para saber el tipo de movimiento Salida Por Merma Con Vale", 11)
            DAO.ParametroAdministradoAgregar("PRM_INV", "TIPOMOVIMIENTO_SALIDA_POR_MERMA", DataAccessCls.TipoDeParametroAdministrado.Numero, "parametro administrado de inventarios para saber el tipo de movimiento Salida Por Merma", 12)
            DAO.ParametroAdministradoAgregar("PRM_INV", "TIPOMOVIMIENTO_ENTRADA_POR_PRESTAMO", DataAccessCls.TipoDeParametroAdministrado.Numero, "parametro administrado de inventarios para saber el tipo de movimiento Entrada Por Prestamo", 13)
            DAO.ParametroAdministradoAgregar("PRM_INV", "TIPOMOVIMIENTO_MOVIMIENTO_TRANSACCIONAL", DataAccessCls.TipoDeParametroAdministrado.Numero, "parametro administrado de inventarios para saber el tipo de movimiento Movimiento Transaccional", 14)
            DAO.ParametroAdministradoAgregar("PRM_INV", "TIPOMOVIMIENTO_ENTRADAS_POR_AJUSTE_INVENTARIO", DataAccessCls.TipoDeParametroAdministrado.Numero, "parametro administrado de inventarios para saber el tipo de movimiento Entradas Por Ajuste de Inventario", 30)
            DAO.ParametroAdministradoAgregar("PRM_INV", "TIPOMOVIMIENTO_SALIDAS_POR_AJUSTE_INVENTARIO", DataAccessCls.TipoDeParametroAdministrado.Numero, "parametro administrado de inventarios para saber el tipo de movimiento Salidas Por Ajuste de Inventario", 31)
            DAO.ParametroAdministradoAgregar("PRM_INV", "TIPOMOVIMIENTO_ENTRADA_INICIAL", DataAccessCls.TipoDeParametroAdministrado.Numero, "parametro administrado de inventarios para saber el tipo de movimiento de Entrada Inicial", 27)
            DAO.ParametroAdministradoAgregar("PRM_INV", "TIPOMOVIMIENTO_RECEPCION_POR_TRASPASO_PLAZAS", DataAccessCls.TipoDeParametroAdministrado.Numero, "parametro administrado de inventarios para saber el tipo de movimiento de recepcion de traspaso plazas", 28)
            DAO.ParametroAdministradoAgregar("PRM_INV", "TIPOMOVIMIENTO_SALIDA_POR_TRASPASO_PLAZAS", DataAccessCls.TipoDeParametroAdministrado.Numero, "parametro administrado de inventarios para saber el tipo de movimiento de recepcion de traspaso plazas", 29)

            ''
            'Parametro de Tipo de Documento
            DAO.ParametroAdministradoAgregar("COM", "ESTATUS_DOCUMENTO_REVISADO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para saber el estatus del documento", 3)
            DAO.ParametroAdministradoAgregar("COM", "ESTATUS_COMPRASGASTOSDESCRIPCION_REVISADO", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parámetro para saber el estatus del documento", "REVISADO")

            DAO.ParametroAdministradoAgregar("COM", "TIPO_DOCUMENTO_DESCRIPCION_FACTURA", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parámetro para obtener la descripcion  del tipo de documento", "FACTURA")
            DAO.ParametroAdministradoAgregar("COM", "TIPO_DOCUMENTO_DESCRIPCION_REMISION", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parámetro para obtener la descripcion  del tipo de documento", "REMISION")
            DAO.ParametroAdministradoAgregar("COM", "TIPO_DOCUMENTO_DESCRIPCION_REMISION_ABREV", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parámetro para obtener la abreviatura del tipo documento remision", "REM")
            DAO.ParametroAdministradoAgregar("COM", "TIPO_DOCUMENTO_DESCRIPCION_FACTURA_ABREV", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parámetro para obtener la abreviatura del tipo documento factura ", "FAC")

            ''Parametros de tipos de estatus de compra ABREVIADOS
            DAO.ParametroAdministradoAgregar("COM", "ESTATUS_COMPRASGASTOSDESCRIPCION_CANCELADO_ABREV", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parámetro para obtener la abreviatura de la descripcion  del tipo de documento", "CAN")
            DAO.ParametroAdministradoAgregar("COM", "ESTATUS_COMPRASGASTOSDESCRIPCION_CONCILIADO_ABREV", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parámetro para obtener la abreviatura de la descripcion  del tipo de documento", "CON")
            DAO.ParametroAdministradoAgregar("COM", "ESTATUS_COMPRASGASTOSDESCRIPCION_REGISTRADO_ABREV", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parámetro para obtener la abreviatura de la descripcion  del tipo de documento", "REG")
            DAO.ParametroAdministradoAgregar("COM", "ESTATUS_COMPRASGASTOSDESCRIPCION_REVISADO_ABREV", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parámetro para obtener la abreviatura de la descripcion  del tipo de documento", "REV")


            '        DAO.ParametroAdministradoAgregar("COM", "ESTATUS_ORDENCOMPRA_REGISTRADO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para saber que numero es el estatus cerrado para la orden de compra", 5)
            DAO.ParametroAdministradoAgregar("COM", "ESTATUS_ORDENCOMPRA_CERRADO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para saber que numero es el estatus cerrado para la orden de compra", 5)

            DAO.ParametroAdministradoAgregar("COM", "ESTADO_ARTICULO_MUESTRA", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para saber si es muestra un articulo", 1)
            DAO.ParametroAdministradoAgregar("COM", "ESTADO_ARTICULO_NO_ES_MUESTRA", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para saber si es muestra un articulo", 0)

            DAO.ParametroAdministradoAgregar("INV", "ESTATUS_INVENTARIO_ACTIVO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Estatus del Inventario Activo", 1)
            DAO.ParametroAdministradoAgregar("INV", "ESTATUS_INVENTARIO_CONTANDO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Estatus del Inventario que se encuentra en proceso de conteo", 2)
            DAO.ParametroAdministradoAgregar("INV", "ESTATUS_INVENTARIO_APLICANDO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Estatus del Inventario al cual se le ha aplicado parte de su detalle", 3)
            DAO.ParametroAdministradoAgregar("INV", "ESTATUS_INVENTARIO_APLICADO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Estatus del Inventario que se encuentra totalmente aplicado", 4)

            DAO.ParametroAdministradoAgregar("INV", "ESTATUS_INVENTARIO_ACTIVO_DESCRIPCION", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Estatus del Inventario Activo", "ACTIVO")
            DAO.ParametroAdministradoAgregar("INV", "ESTATUS_INVENTARIO_CONTANDO_DESCRIPCION", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Estatus del Inventario que se encuentra en proceso de conteo", "CONTANDO")
            DAO.ParametroAdministradoAgregar("INV", "ESTATUS_INVENTARIO_APLICANDO_DESCRIPCION", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Estatus del Inventario al cual se le ha aplicado parte de su detalle", "APLICANDO")
            DAO.ParametroAdministradoAgregar("INV", "ESTATUS_INVENTARIO_APLICADO_DESCRIPCION", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Estatus del Inventario que se encuentra totalmente aplicado", "APLICADO")


            DAO.ParametroAdministradoAgregar("PRMSUC", "PLAZA", DataAccessCls.TipoDeParametroAdministrado.Numero, "Plaza configurada al sistema", 1)

            'Parametros para tipo de tablero de conciliacion y revision de orrdenes de compras''
            DAO.ParametroAdministradoAgregar("COM", "TIPO_DE_TABLERO_CONCILIAR", DataAccessCls.TipoDeParametroAdministrado.Numero, "PARAMETRO PARA IDENTIFICAR EL TIPO DE MOVIMIENTO A REALIZAR EN EL TABLERO DE FACTURAS-REMISIONES", 0)
            DAO.ParametroAdministradoAgregar("COM", "TIPO_DE_TABLERO_REVIZAR", DataAccessCls.TipoDeParametroAdministrado.Numero, "PARAMETRO PARA IDENTIFICAR EL TIPO DE MOVIMIENTO A REALIZAR EN EL TABLERO DE FACTURAS-REMISIONES", 1)

            DAO.ParametroAdministradoAgregar("INV", "PRM_RutaArchivosFacturasCompras", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parámetro para administrar la ruta en donde se encuentran los Archivos planos que contiene las Facturas de Compra", "C:\")

            ' Parametros para Produccion
            DAO.ParametroAdministradoAgregar("CTL", "TIPOSMOVIMIENTO_CLIENTE", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para saber el valor del elemento cliente en el combo", 1)
            DAO.ParametroAdministradoAgregar("CTL", "TIPOSMOVIMIENTO_EMPLEADO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para saber el valor del elemento empleado en el combo", 2)
            DAO.ParametroAdministradoAgregar("CTL", "TIPOSMOVIMIENTO_INVOLUCRADO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para saber el valor del elemento involucrado en el combo", 3)
            DAO.ParametroAdministradoAgregar("CTL", "TIPOSMOVIMIENTO_PROVEEDOR", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para saber el valor del elemento proveedor en el combo", 4)
            DAO.ParametroAdministradoAgregar("INV", "TIPORESPONSABLE_EMPLEADO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para saber la clave del tipo de responsable empleado", 2)
            DAO.ParametroAdministradoAgregar("INV", "TIPORESPONSABLE_CLIENTE", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para saber la clave del tipo de responsable cliente", 1)
            DAO.ParametroAdministradoAgregar("INV", "TIPORESPONSABLE_INVOLUCRADO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para saber la clave del tipo de responsable involucrado", 3)
            DAO.ParametroAdministradoAgregar("INV", "TIPORESPONSABLE_PROVEEDOR", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para saber la clave del tipo de responsable proveedor", 4)


            'Parametro Para Tipos de movimientos Productos
            DAO.ParametroAdministradoAgregar("PRO", "TIPOMOVIMIENTO_ENTRADAPRODUCCION", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro administrado Para saber que tipo de movimiento es el que se genera", 2)
            DAO.ParametroAdministradoAgregar("PRO", "TIPOMOVIMIENTO_ENTRADAPRODUCCION_DESCRIPCION", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parámetro administrado Para saber que tipo de movimiento es el que se genera", "ENTRADA DE PRODUCCION")

            DAO.ParametroAdministradoAgregar("PRO", "TIPOMOVIMIENTO_SALIDAPRODUCCION", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro administrado Para saber que tipo de movimiento es el que se genera", 8)
            DAO.ParametroAdministradoAgregar("PRO", "TIPOMOVIMIENTO_SALIDAPRODUCCION_DESCRIPCION", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parámetro administrado Para saber que tipo de movimiento es el que se genera", "SALIDA PRODUCCION")

            DAO.ParametroAdministradoAgregar("PRO", "TIPOMOVIMIENTO_ENTRADAPORREMPLAZO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro administrado Para saber que tipo de movimiento  de entrada por remplazo de etiquetas", 22)
            DAO.ParametroAdministradoAgregar("PRO", "TIPOMOVIMIENTO_ENTRADAPORREMPLAZO_DESCRIPCION", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parámetro administrado Para saber que tipo de movimiento de entrada por remplazo de etiquetas", "ENTRADA POR REMPLAZO")
            DAO.ParametroAdministradoAgregar("PRO", "TIPOMOVIMIENTO_SALIDAPORREMPLAZO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro administrado Para saber que tipo de movimiento  de salida por remplazo de etiquetas", 23)
            DAO.ParametroAdministradoAgregar("PRO", "TIPOMOVIMIENTO_SALIDAPORREMPLAZO_DESCRIPCION", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parámetro administrado Para saber que tipo de movimiento de salida por remplazo de etiquetas", "SALIDA POR REMPLAZO")

            'Parametros para Movimientos de inventario
            DAO.ParametroAdministradoAgregar("PRO", "TIPOMOVIMIENTO_ENTRADAS_POR_AJUSTE_INVENTARIO_PRODUCTOS", DataAccessCls.TipoDeParametroAdministrado.Numero, "parametro administrado de inventarios para saber el tipo de movimiento Entradas Por Ajuste de Inventario", 29)
            DAO.ParametroAdministradoAgregar("PRO", "TIPOMOVIMIENTO_SALIDAS_POR_AJUSTE_INVENTARIO_PRODUCTOS", DataAccessCls.TipoDeParametroAdministrado.Numero, "parametro administrado de inventarios para saber el tipo de movimiento Salidas Por Ajuste de Inventario", 28)


            'Parametro Para Tipos de movimientos Articulos
            DAO.ParametroAdministradoAgregar("PRO", "TIPOMOVIMIENTO_ENTRADAPRODUCCIONARTICULOS", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro administrado Para saber que tipo de movimiento es el que se genera", 36)
            DAO.ParametroAdministradoAgregar("PRO", "TIPOMOVIMIENTO_ENTRADAPRODUCCIONARTICULOS_DESCRIPCION", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parámetro administrado Para saber que tipo de movimiento es el que se genera", "ENTRADA DE PRODUCCION")


            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_ENTRADAPRODUCCION_REGISTRADO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parametro para conocer el valor del estatus registrado para los movimientos generales", 1)
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_ENTRADAPRODUCCION_CANCELADO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parametro para conocer el valor del estatus Cancelado para los movimientos generales", 0)
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_ENTRADAPRODUCCION_DESCRIPCION_REGISTRADO", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parametro para conocer la descripción del estatus registrado para los movimientos generales", "REGISTRADO")
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_ENTRADAPRODUCCION_DESCRIPCION_CANCELADO", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parametro para conocer la descripción del estatus Cancelado para los movimientos generales", "CANCELADO")

            'Estatus Para el inventario fisico
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_INVENTARIO_ACTIVO_PRODUCTOS", DataAccessCls.TipoDeParametroAdministrado.Numero, "Estatus del Inventario Activo", 1)
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_INVENTARIO_CONTANDO_PRODUCTOS", DataAccessCls.TipoDeParametroAdministrado.Numero, "Estatus del Inventario que se encuentra en proceso de conteo", 2)
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_INVENTARIO_APLICANDO_PRODUCTOS", DataAccessCls.TipoDeParametroAdministrado.Numero, "Estatus del Inventario al cual se le ha aplicado parte de su detalle", 3)
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_INVENTARIO_APLICADO_PRODUCTOS", DataAccessCls.TipoDeParametroAdministrado.Numero, "Estatus del Inventario que se encuentra totalmente aplicado", 4)

            DAO.ParametroAdministradoAgregar("PRO", "DESCRIPCION_ESTATUS_INVENTARIO_ACTIVO_PRODUCTOS", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Estatus del Inventario Activo", "Activo")
            DAO.ParametroAdministradoAgregar("PRO", "DESCRIPCION_ESTATUS_INVENTARIO_CONTANDO_PRODUCTOS", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Estatus del Inventario que se encuentra en proceso de conteo", "Contando")
            DAO.ParametroAdministradoAgregar("PRO", "DESCRIPCION_ESTATUS_INVENTARIO_APLICANDO_PRODUCTOS", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Estatus del Inventario al cual se le ha aplicado parte de su detalle", "Aplicando")
            DAO.ParametroAdministradoAgregar("PRO", "DESCRIPCION_ESTATUS_INVENTARIO_APLICADO_PRODUCTOS", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Estatus del Inventario que se encuentra totalmente aplicado", "Aplicado")



            '****************************************************************************************************************************
            '                  PARAMETROS PARA PRODUCCION - PANTALLAS DE TRASPASOS, SUMINISTROS Y DEVOLUCIONES'
            '****************************************************************************************************************************
            'Crea Tipos Movimientos para Traspasos, Pedidos, Devoluciones
            DAO.ParametroAdministradoAgregar("PRO", "TIPOMOVIMIENTO_SALIDATRASPASO_PRODUCTOS", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para saber el tipo de movimiento de una salida por traspaso", 4)
            DAO.ParametroAdministradoAgregar("PRO", "TIPOMOVIMIENTO_ENTRADATRASPASO_PRODUCTOS", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para saber el tipo de movimiento de una entrada por traspaso", 5)
            DAO.ParametroAdministradoAgregar("PRO", "TIPOMOVIMIENTO_SALIDADEVOLUCION_PRODUCTOS", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para saber el tipo de movimiento de una salida por devolucion", 6)
            DAO.ParametroAdministradoAgregar("PRO", "TIPOMOVIMIENTO_ENTRADADEVOLUCION_PRODUCTOS", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para saber el tipo de movimiento de una entrada por devolucion", 7)
            DAO.ParametroAdministradoAgregar("PRO", "TIPOMOVIMIENTO_ENTRADASUMINISTRO_PRODUCTOS", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para saber el tipo de movimiento de una entrada por suministro", 9)
            'Crea Cancelaciones para Traspasos, Pedidos, DEvoluciones
            DAO.ParametroAdministradoAgregar("PRO", "TIPOMOVIMIENTO_CANCELACION_SALIDATRASPASO_PRODUCTOS", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para saber el tipo de movimiento de  cancelacion de una salida por traspaso", 10)
            DAO.ParametroAdministradoAgregar("PRO", "TIPOMOVIMIENTO_CANCELACION_ENTRADATRASPASO_PRODUCTOS", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para saber el tipo de movimiento de cancelacion de una entrada por traspaso", 11)
            DAO.ParametroAdministradoAgregar("PRO", "TIPOMOVIMIENTO_CANCELACION_SALIDADEVOLUCION_PRODUCTOS", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para saber el tipo de movimiento de cancelacion de una salida por devolucion", 12)
            DAO.ParametroAdministradoAgregar("PRO", "TIPOMOVIMIENTO_CANCELACION_ENTRADADEVOLUCION_PRODUCTOS", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para saber el tipo de movimiento de cancelacion de una entrada por devolucion", 13)
            DAO.ParametroAdministradoAgregar("PRO", "TIPOMOVIMIENTO_CANCELACION_SALIDASUMINISTRO_PRODUCTOS", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para saber el tipo de movimiento de cancelacion de una SAlida por suministro", 14)
            DAO.ParametroAdministradoAgregar("PRO", "TIPOMOVIMIENTO_CANCELACION_ENTRADASUMINISTRO_PRODUCTOS", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para saber el tipo de movimiento de cancelacion de una entrada por suministro", 15)
            'Crea Estatus para Salidas Por Traspasos
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_SALIDATRASPASOPRODUCTOS_CANCELADO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parametro para conocer el valor del estatus Cancelado para las salidas por traspaso de productos", 0)
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_SALIDATRASPASOPRODUCTOS_REGISTRADO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parametro para conocer el valor del estatus registrado para las salidas por traspaso de productos", 1)
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_SALIDATRASPASOPRODUCTOS_REGISTRADOCONCHOFER", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parametro para conocer el estatus CON CHOFER de una salida por traspaso", 2)
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_SALIDATRASPASOPRODUCTOS_TRANSITO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parametro para conocer el estatus TRANSITO de una salida por traspaso", 3)
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_SALIDATRASPASOPRODUCTOS_DESTINO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parametro para conocer el estatus DESTINO de una salida por traspaso", 4)
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_SALIDATRASPASOPRODUCTOS_RECIBIDO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parametro para conocer el estatus RECIBIDO de una salida por traspaso", 5)
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_SALIDATRASPASOPRODUCTOS_CERRADO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parametro para conocer el estatus CERRADO de de una salida por traspaso", 6)
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_SALIDATRASPASOPRODUCTOS_DESCRIPCION_CANCELADO", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parametro para conocer la descripción del estatus Cancelado para las salidas por traspaso de productos", "CANCELADO")
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_SALIDATRASPASOPRODUCTOS_DESCRIPCION_REGISTRADO", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parametro para conocer la descripción del estatus registrado sin chofer para las salidas por traspaso de productos", "REGISTRADO SIN CHOFER")
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_SALIDATRASPASOPRODUCTOS_DESCRIPCION_REGISTRADOCONCHOFER", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parametro para conocer la descripción del estatus registrado con chofer para las salidas por traspaso de productos", "REGISTRADO CON CHOFER")
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_SALIDATRASPASOPRODUCTOS_DESCRIPCION_TRANSITO", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parametro para conocer la descripción del estatus en Transito para las salidas por traspaso de productos", "TRANSITO")
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_SALIDATRASPASOPRODUCTOS_DESCRIPCION_DESTINO", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parametro para conocer la descripción del estatus Destino para las salidas por traspaso de productos", "DESTINO")
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_SALIDATRASPASOPRODUCTOS_DESCRIPCION_RECIBIDO", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parametro para conocer la descripción del estatus Recibido para las salidas por traspaso de productos", "RECIBIDO")
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_SALIDATRASPASOPRODUCTOS_DESCRIPCION_CERRADO", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parametro para conocer la descripción del estatus Cerrado para las salidas por traspaso de productos", "CERRADO")
            'Crea Estatus para Entradas Por Traspasos
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_ENTRADATRASPASOPRODUCTOS_REGISTRADO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parametro para conocer el valor del estatus registrado para las Entradas por traspaso de productos", 1)
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_ENTRADATRASPASOPRODUCTOS_CANCELADO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parametro para conocer el valor del estatus Cancelado para las Entradas por traspaso de productos", 0)
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_ENTRADATRASPASOPRODUCTOS_DESCRIPCION_REGISTRADO", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parametro para conocer la descripción del estatus registrado para las Entradas por traspaso de productos", "REGISTRADO")
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_ENTRADATRASPASOPRODUCTOS_DESCRIPCION_CANCELADO", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parametro para conocer la descripción del estatus Cancelado para las Entradas por traspaso de productos", "CANCELADO")
            'Crea Estatus para Salidas por Devolucion
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_SALIDADEVOLUCIONPRODUCTOS_CANCELADO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parametro para conocer el valor del estatus Cancelado para las salidas por DEVOLUCION de productos", 0)
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_SALIDADEVOLUCIONPRODUCTOS_REGISTRADO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parametro para conocer el valor del estatus registrado para las salidas por DEVOLUCION de productos", 1)
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_SALIDADEVOLUCIONPRODUCTOS_REGISTRADOCONCHOFER", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parametro para conocer el estatus CON CHOFER de una salida por DEVOLUCION", 2)
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_SALIDADEVOLUCIONPRODUCTOS_TRANSITO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parametro para conocer el estatus TRANSITO de una salida por DEVOLUCION", 3)
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_SALIDADEVOLUCIONPRODUCTOS_DESTINO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parametro para conocer el estatus DESTINO de una salida por DEVOLUCION", 4)
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_SALIDADEVOLUCIONPRODUCTOS_RECIBIDO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parametro para conocer el estatus RECIBIDO de una salida por DEVOLUCION", 5)
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_SALIDADEVOLUCIONPRODUCTOS_CERRADO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parametro para conocer el estatus CERRADO de de una salida por DEVOLUCION", 6)
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_SALIDADEVOLUCIONPRODUCTOS_DESCRIPCION_CANCELADO", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parametro para conocer la descripción del estatus Cancelado para las salidas por DEVOLUCION de productos", "CANCELADO")
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_SALIDADEVOLUCIONPRODUCTOS_DESCRIPCION_REGISTRADO", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parametro para conocer la descripción del estatus registrado para las salidas por DEVOLUCION de productos", "REGISTRADO")
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_SALIDADEVOLUCIONPRODUCTOS_DESCRIPCION_REGISTRADOCONCHOFER", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parametro para conocer la descripción del estatus registrado con chofer para las salidas por DEVOLUCION de productos", "REGISTRADO CON CHOFER")
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_SALIDADEVOLUCIONPRODUCTOS_DESCRIPCION_TRANSITO", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parametro para conocer la descripción del estatus en Transito para las salidas por DEVOLUCION de productos", "TRANSITO")
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_SALIDADEVOLUCIONPRODUCTOS_DESCRIPCION_DESTINO", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parametro para conocer la descripción del estatus Destino para las salidas por DEVOLUCION de productos", "DESTINO")
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_SALIDADEVOLUCIONPRODUCTOS_DESCRIPCION_RECIBIDO", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parametro para conocer la descripción del estatus Recibido para las salidas por DEVOLUCION de productos", "RECIBIDO")
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_SALIDADEVOLUCIONPRODUCTOS_DESCRIPCION_CERRADO", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parametro para conocer la descripción del estatus Cerrado para las salidas por DEVOLUCION de productos", "CERRADO")
            'Crea Estatus para Entradas por Devolucion
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_ENTRADADEVOLUCIONPRODUCTOS_REGISTRADO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parametro para conocer el valor del estatus registrado para las Entradas por DEVOLUCION de productos", 1)
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_ENTRADADEVOLUCIONPRODUCTOS_CANCELADO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parametro para conocer el valor del estatus Cancelado para las Entradas por DEVOLUCION de productos", 0)
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_ENTRADADEVOLUCIONPRODUCTOS_DESCRIPCION_REGISTRADO", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parametro para conocer la descripción del estatus registrado para las Entradas por DEVOLUCION de productos", "REGISTRADO")
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_ENTRADADEVOLUCIONPRODUCTOS_DESCRIPCION_CANCELADO", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parametro para conocer la descripción del estatus Cancelado para las Entradas por DEVOLUCION de productos", "CANCELADO")
            'Crea Estatus para Entradas por Suministro
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_ENTRADASUMINISTROPRODUCTOS_CANCELADO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parametro para conocer el valor del estatus Cancelado para las Entradas por SUMINISTRO de productos", 0)
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_ENTRADASUMINISTROPRODUCTOS_REGISTRADO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parametro para conocer el valor del estatus registrado para las Entradas por SUMINISTRO de productos", 1)
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_ENTRADASUMINISTROPRODUCTOS_DESCRIPCION_CANCELADO", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parametro para conocer la descripción del estatus Cancelado para las Entradas por SUMINISTRO de productos", "CANCELADO")
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_ENTRADASUMINISTROPRODUCTOS_DESCRIPCION_REGISTRADO", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parametro para conocer la descripción del estatus registrado para las Entradas por SUMINISTRO de productos", "REGISTRADO")

            '----- Cajas -----
            DAO.ParametroAdministradoAgregar("CJA", "TIPO_MOVIMIENTO_APERTURA_CAJA", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parametro de Tipo de Movimiento Apertura de Caja", 1)
            DAO.ParametroAdministradoAgregar("CJA", "TIPO_MOVIMIENTO_RETIRO_CAJA", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parametro de Tipo de Movimiento Retiro de Caja", 2)
            DAO.ParametroAdministradoAgregar("CJA", "TIPO_MOVIMIENTO_CORTE_CAJA", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parametro de Tipo de Movimiento Corte de Caja", 3)
            DAO.ParametroAdministradoAgregar("CJA", "TIPO_MOVIMIENTO_DOTACION", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parametro de Tipo de Movimiento Dotacion Extra", 4)
            DAO.ParametroAdministradoAgregar("CJA", "TIPO_MOVIMIENTO_PAGO_ESPECIAL", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parametro de Tipo de Movimiento Pago Especial", 5)
            DAO.ParametroAdministradoAgregar("CJA", "TIPO_MOVIMIENTO_PAGO_RESTAURAN", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parametro de Tipo de Movimiento Pago Restauran", 6)
            DAO.ParametroAdministradoAgregar("CJA", "TIPO_MOVIMIENTO_PAGO_PASTELERIA", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parametro de Tipo de Movimiento Pago Pasteleria", 7)



            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_MOVIMIENTOSGENERALES_REGISTRADO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parametro para conocer el valor del estatus registrado para los movimientos generales", 1)
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_MOVIMIENTOSGENERALES_CANCELADO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parametro para conocer el valor del estatus Cancelado para los movimientos generales", 0)
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_MOVIMIENTOSGENERALES_DESCRIPCION_REGISTRADO", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parametro para conocer la descripción del estatus registrado para los movimientos generales", "REGISTRADO")
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_MOVIMIENTOSGENERALES_DESCRIPCION_CANCELADO", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parametro para conocer la descripción del estatus Cancelado para los movimientos generales", "CANCELADO")


            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_PROGRAMACIONBATIDAS_DESCRIPCION_APLICADO", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parametro para conocer la descripción del estatus aplicado para la programacion de batidas", "APLICADO")
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_PROGRAMACIONBATIDAS_APLICADO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parametro para conocer el valor del estatus Aplicado para la programacion de batidas", 2)

            '********** Parametros Para Contabilidad
            DAO.ParametroAdministradoAgregar("CNT", "CNT_EstadoResultados", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parametro para el estado de resultados", 0)

            DAO.ParametroAdministradoAgregar("CNT", "CNT_FormatoColumnasNumerica_2_Decimales", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parametro para la configuracion de columnas de dinero con 2 decimales", "{0:C2}")

            DAO.ParametroAdministradoAgregar("CNT", "CNT_FormatoColumnasNumerica_4_Decimales", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parametro para la configuracion de columnas de dinero con 2 decimales", "{0:C4}")


            DAO.ParametroAdministradoAgregar("BAN", "TIPO_PERMISO_REPORTES_CONSULTAS_FINANZAS", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para saber el tipo de permiso que se dará en la opción de reportes y consultas para finanzas", 1)
            DAO.ParametroAdministradoAgregar("BAN", "TIPO_PERMISO_PROYECTOS", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para saber el tipo de permiso que se dará en la opción de Proyectos", 2)
            DAO.ParametroAdministradoAgregar("COM", "TIPO_PERMISO_TIPOARTICULO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para saber el tipo de permiso que se dará en la opcion de tablero de revision de compras sobre el Tipo de Artículo", 3)

            DAO.ParametroAdministradoAgregar("COM", "CALCULA_CXP_EN_BASE_TOTAL_DOCUMENTO_FISICO_EN_REGISTROFACTURAS", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para saber si la CXP se tiene que generar en base al total del documento fisico (Valor 1 en este caso) o en base a lo que se capturó en el grid (valor 0 en este caso)", 1)
            DAO.ParametroAdministradoAgregar("COM", "COM_DIFERENCIA_MAXIMA_PERMITIDA_IVA_CONCILIACION_PESOS", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para saber cuanto será la diferencia máxima permitida entre el iva calculado y el iva del documento", 2)
            DAO.ParametroAdministradoAgregar("COM", "PERMITE_GUARDAR_DOCUMENTO_IVA_EXISTE_EN_UNA_OPCION_Y_EN_OTRA_NO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para saber si se permitirá guardar una factura cuando existe iva calculado en el grid y no Iva de Documento fisico, o viceversa, cuando existe iva de documento fisico y no haya iva calculado en el grid", 0)

            DAO.ParametroAdministradoAgregar("INV", "MOSTRAR_EQUIVALENCIA_EN_PRSENTACION_TICKET", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para determinar si se mostrará la presentacion con todo y equivalencia en el ticket, ejemplo CJA 10, o CJA nada mas", 0)
            DAO.ParametroAdministradoAgregar("INV", "TICKET_LONGITUD_CANTIDAD", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parametro para conocer la longitud a mostrar para la cantidad", 8)
            DAO.ParametroAdministradoAgregar("INV", "TICKET_LONGITUD_ARTICULO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parametro para conocer la longitud a mostrar para la Artículo", 22)
            DAO.ParametroAdministradoAgregar("INV", "TICKET_LONGITUD_PRESENTACION", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parametro para conocer la longitud a mostrar para la Presentacion", 8)
            DAO.ParametroAdministradoAgregar("INV", "TICKET_ESPACIOSBLANCO_CANTIDAD_PRESENTACION", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parametro para conocer los espacios en blanco entre la cantidad y la presentacion", 1)
            DAO.ParametroAdministradoAgregar("INV", "TICKET_ESPACIOSBLANCO_ARTICULO_PRESENTACION", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parametro para conocer los espacios en blanco entra la presentacion y el artículo", 1)
            DAO.ParametroAdministradoAgregar("INV", "TICKET_PRES_CORTA_LONGITUD_CANTIDAD", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parametro para conocer la longitud a mostrar para la cantidad", 8)
            DAO.ParametroAdministradoAgregar("INV", "TICKET_PRES_CORTA_LONGITUD_ARTICULO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parametro para conocer la longitud a mostrar para la Artículo", 25)
            DAO.ParametroAdministradoAgregar("INV", "TICKET_PRES_CORTA_LONGITUD_PRESENTACION", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parametro para conocer la longitud a mostrar para la Presentacion", 3)
            DAO.ParametroAdministradoAgregar("INV", "TICKET_PRES_CORTA_ESPACIOSBLANCO_CANTIDAD_PRESENTACION", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parametro para conocer los espacios en blanco entre la cantidad y la presentacion", 2)
            DAO.ParametroAdministradoAgregar("INV", "TICKET_PRES_CORTA_ESPACIOSBLANCO_ARTICULO_PRESENTACION", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parametro para conocer los espacios en blanco entra la presentacion y el artículo", 2)

            DAO.ParametroAdministradoAgregar("PRO", "TIPOMOVIMIENTO_CANCELACION_SALIDACONVERSIONPRODUCTOS", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para conocer el tipo de movimiento de Cancelacion de Salida de Conversión de Productos", 30)
            DAO.ParametroAdministradoAgregar("PRO", "TIPOMOVIMIENTO_CANCELACION_ENTRADACONVERSIONPRODUCTOS", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para conocer el tipo de movimiento de Cancelacion de Entrada de Conversión de Productos", 31)

            Dim atrPlaza As Int32 = 0
            atrPlaza = DAO.ParametroAdministradoObtener("PRMSUC", "PLAZA")
            DAO.ParametroAdministradoAgregar("WS", "DEMONIO_CONCILIAENVIA_PERMITE_ENVIO_INFORMACION_" & atrPlaza, DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para saber si la plaza enviará información a las demás plazas", 1)
            DAO.ParametroAdministradoAgregar("WS", "DEMONIO_CONCILIAENVIA_PERMITE_PROCESAR_ARCHIVOS_" & atrPlaza, DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para saber si la plaza procesará archivos", 1)
            DAO.ParametroAdministradoAgregar("WS", "DEMONIO_CONCILIAENVIA_HORA_INICIO_ENVIO_INFORMACION_" & atrPlaza, DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para saber la hora en que se iniciará el envió de información", 24)
            DAO.ParametroAdministradoAgregar("WS", "DEMONIO_CONCILIAENVIA_HORA_INICIO_PROCESAR_ARCHIVOS_" & atrPlaza, DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para saber la hora en que se iniciará el proceso de archivos", 24)
            DAO.ParametroAdministradoAgregar("WS", "DEMONIO_CONCILIAENVIA_FRECUENCIA_ENVIO_INFORMACION_" & atrPlaza, DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para saber la frecuencia con que se enviará la información una vez iniciado en el demonio el proceso de envio de información", 2)
            DAO.ParametroAdministradoAgregar("WS", "DEMONIO_CONCILIAENVIA_FRECUENCIA_PROCESAR_ARCHIVOS_" & atrPlaza, DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para saber la frecuencia con que se procesarán los archivos una vez iniciado en el demonio el proceso de procesar archivos", 2)
            DAO.ParametroAdministradoAgregar("WS", "DEMONIO_CONCILIAENVIA_INICIA_EJECUCION_INMEDIATAMENTE_" & atrPlaza, DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para saber la frecuencia con que se procesarán los archivos una vez iniciado en el demonio el proceso de procesar archivos", 0)
            DAO.ParametroAdministradoAgregar("WS", "CONTEXTO_INTEGRA_PLAZAS_DEMONIO_CONCILIAENVIA", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parámetro para conocer el contexto de que tablas se va a llevar el proceso de integrar plazas", "INTEGRA_PLAZAS")

            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_CAPTURAREBANADOS_REGISTRADO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para obtener el estatus de registrado para una captura de rebanados", 1)
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUSDESCRIPCION_CAPTURAREBANADOS_REGISTRADO", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parámetro para obtener la descripción para el estatus de registrado de una captura de rebanados", "REGISTRADO")
            DAO.ParametroAdministradoAgregar("PRO", "TIPOMOVIMIENTO_CANCELACION_SALIDACAPTURAREBANADOS", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para conocer el tipo de movimiento de cancelación para el movimiento salida de captura de rebanados", 34)
            DAO.ParametroAdministradoAgregar("PRO", "TIPOMOVIMIENTO_CANCELACION_ENTRADACAPTURAREBANADOS", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para conocer el tipo de movimiento de cancelación para el movimiento Entrada de captura de rebanados", 35)

            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_CONVERSIONPRODUCTOS_REGISTRADO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para conocer el estatus registrado en la conversion de productos", 1)
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_CONVERSIONPRODUCTOS_CANCELADO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para conocer el estatus cancelado en la conversion de productos", 0)
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_CONVERSIONPRODUCTOS_DESCRIPCION_REGISTRADO", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parámetro para conocer la descripcion  del estatus registrado en la conversion de productos", "REGISTRADO")
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_CONVERSIONPRODUCTOS_DESCRIPCION_CANCELADO", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parámetro para conocer la descripcion del estatus cancelado en la conversion de productos", "CANCELADO")

            DAO.ParametroAdministradoAgregar("PRM_INV", "NUMERO_IMPRESIONES_TICKETS", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para determinar cuantas veces se mandará a imprimir el ticket", 2)
            DAO.ParametroAdministradoAgregar("COM", "REPORTE_ORDENCOMPRA_ENCARGADOCOMPRA_PLAZA_1", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parámetro para saber quien es el encargado de compras de la Plaza 1, para el reporte de orden de compra", "MA. ERIKA PAYÁN DELGADO")
            DAO.ParametroAdministradoAgregar("COM", "REPORTE_ORDENCOMPRA_ENCARGADOCOMPRA_PLAZA_2", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parámetro para saber quien es el encargado de compras de la Plaza 2, para el reporte de orden de compra", "LIC. HECTOR A. MARTINEZ F.")

            DAO.ParametroAdministradoAgregar("COM", "CTL_ARTICULOS_TIPOSMOVIMIENTOS_ENTRADA", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parámetro para saber los tipos de movimientos de entrada a considerar en las estadísticas de artículos", "7,26")
            DAO.ParametroAdministradoAgregar("COM", "CTL_ARTICULOS_TIPOSMOVIMIENTOS_SALIDA", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parámetro para saber los tipos de movimientos de entrada a considerar en las estadísticas de artículos", "1,25")


            '********************Parámetros para pantallas de Salida y Entrada por Traspaso de Producción y Distribución ********************
            DAO.ParametroAdministradoAgregar("PRO", "TIPOMOVIMIENTO_SALIDATRASPASO_PRODUCCIONDISTRIBUCION_PRODUCTOS", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para saber el tipo de movimiento de una salida por traspaso entre produccion y distribucion", 41)
            DAO.ParametroAdministradoAgregar("PRO", "TIPOMOVIMIENTO_ENTRADATRASPASO_PRODUCCIONDISTRIBUCION_PRODUCTOS", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para saber el tipo de movimiento de una entrada por traspaso entre produccion y distribucion", 42)
            DAO.ParametroAdministradoAgregar("PRO", "TIPOMOVIMIENTO_CANCELACION_SALIDATRASPASO_PRODUCCIONDISTRIBUCION_PRODUCTOS", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para saber el tipo de movimiento de una cancelación de salida por traspaso entre produccion y distribucion", 43)
            DAO.ParametroAdministradoAgregar("PRO", "TIPOMOVIMIENTO_CANCELACION_ENTRADATRASPASO_PRODUCCIONDISTRIBUCION_PRODUCTOS", DataAccessCls.TipoDeParametroAdministrado.Numero, "Parámetro para saber el tipo de movimiento de una cancelación de entrada por traspaso entre produccion y distribucion", 44)

            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_ENTRADATRASPASO_PROD_DIST_PRODUCTOS_REGISTRADO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Estatus Registrado ", 1)
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_ENTRADATRASPASO_PROD_DIST_PRODUCTOS_DESCRIPCION_REGISTRADO", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Descripcion Estatus Registrado ", "REGISTRADO")
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_ENTRADATRASPASO_PROD_DIST_PRODUCTOS_DESCRIPCION_CANCELADO", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Descripcion  Estatus Cancelado", "CANCELADO")

            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_SALIDATRASPASO_PROD_DIST_PRODUCTOS_REGISTRADO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Estatus Registrado Sin Chofer ", 1)
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_SALIDATRASPASO_PROD_DIST_PRODUCTOS_REGISTRADOCONCHOFER", DataAccessCls.TipoDeParametroAdministrado.Numero, "Estatus Registrado con Chofer ", 2)
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_SALIDATRASPASO_PROD_DIST_PRODUCTOS_TRANSITO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Estatus en tránsito", 3)
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_SALIDATRASPASO_PROD_DIST_PRODUCTOS_DESTINO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Estatus Destino", 4)
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_SALIDATRASPASO_PROD_DIST_PRODUCTOS_RECIBIDO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Estatus Recibido", 5)
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_SALIDATRASPASO_PROD_DIST_PRODUCTOS_CERRADO", DataAccessCls.TipoDeParametroAdministrado.Numero, "Estatus cerrado", 6)

            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_SALIDATRASPASO_PROD_DIST_PRODUCTOS_DESCRIPCION_REGISTRADO", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Descripción Estatus Registrado Sin Chofer ", "REGISTRADO SIN CHOFER")
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_SALIDATRASPASO_PROD_DIST_PRODUCTOS_DESCRIPCION_REGISTRADOCONCHOFER", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Descripción Estatus Registrado con Chofer ", "REGISTRADO CON CHOFER")
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_SALIDATRASPASO_PROD_DIST_PRODUCTOS_DESCRIPCION_TRANSITO", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Descripción Estatus en tránsito", "TRANSITO")
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_SALIDATRASPASO_PROD_DIST_PRODUCTOS_DESCRIPCION_DESTINO", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Descripción Estatus Destino", "DESTINO")
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_SALIDATRASPASO_PROD_DIST_PRODUCTOS_DESCRIPCION_RECIBIDO", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Descripción Estatus Recibido", "RECIBIDO")
            DAO.ParametroAdministradoAgregar("PRO", "ESTATUS_SALIDATRASPASO_PROD_DIST_PRODUCTOS_DESCRIPCION_CERRADO", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Descripción Estatus cerrado", "CERRADO")
            '**********************************************************************************************************************************
        End Sub

        Public Shared Function ValidaDirectorio(ByVal prmRuta As String) As Boolean

            If Not Directory.Exists(prmRuta) Then
                MessageBox.Show("La ruta '" & prmRuta & "' no existe, consulte al administrador del sistema", Comunes.Comun.ClsTools.GlobalSistemaCaption, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            Return True
        End Function

        Public Shared Sub PGMuestraMensajeInformacion(ByVal prmMsg As String)
            MessageBox.Show(prmMsg, ClsTools.GlobalSistemaCaption, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub

        Private Shared Sub CargaParametrosADDA()
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vIFCarchivoIni As New Ini.IniFileController
            Dim vcRutaIni As String

            'Dim misParametrosSucursal As New Comunes.Comun.Parametros.ClsParametrosSucursal
            'With misParametrosSucursal
            '        .ParametroCanalDistribucion = New ClsParametro("CanalDistribicion", New ClsParametroQuery("Select cValor From Adsum_ParametrosAdministrados(nolock) where cContexto='PRMSuc' and cParametroAdministrado='Canal_Distribucion'", False))
            '.ParametroMonedaOperacion = New ClsParametro("MonedaOperacion", New ClsParametroQuery("SELECT nMonedaBase FROM CTL_ConfiguracionCanalesDistribucion(NOLOCK) WHERE nCanalDistribucion = " & .CanalDistribucion, False))
            '.ParametroUnidadOperacion = New ClsParametro("UnidadOperacion", New ClsParametroQuery("SELECT nUnidadBase FROM CTL_ConfiguracionCanalesDistribucion(NOLOCK) WHERE nCanalDistribucion = " & .CanalDistribucion, False))
            '        .ParametroUnidadOperacionSecundaria = New ClsParametro("UnidadOperacionSecundaria", New ClsParametroQuery("SELECT nUnidadSecundaria FROM CTL_ConfiguracionCanalesDistribucion(NOLOCK) WHERE nCanalDistribucion = " & .CanalDistribucion, False))
            '        .ParametroIngresarSinConciliacion = New ClsParametro("IngresarSinConciliacion", New ClsParametroQuery("SELECT bIngresarSinConciliacion FROM CTL_ConfiguracionCanalesDistribucion(NOLOCK) WHERE nCanalDistribucion = " & .CanalDistribucion, True))
            '        .ParametroPorcentajePesoCaja = New ClsParametro("PorcentajePesoCaja", New ClsParametroQuery("Select cValor From Adsum_ParametrosAdministrados(nolock) where cContexto='PRMSuc' and cParametroAdministrado='PorcentajePesoCaja'", False))
            '        .ParametroMonedaOperacionSecundaria = New ClsParametro("MonedaOperacionSecundaria", New ClsParametroQuery("SELECT nMonedaSecundaria FROM CTL_ConfiguracionCanalesDistribucion(NOLOCK) WHERE nCanalDistribucion = " & .CanalDistribucion, True))
            '        .ParametroDiaEnQueEmpiezaLaSemana = New ClsParametro("DiaEnQueEmpiezaLaSemana", New ClsParametroQuery("Select cValor From Adsum_ParametrosAdministrados(nolock) where cContexto='PRMSuc' and cParametroAdministrado='Dia_En_Que_Empieza_La_Semana'", False))
            '        .ParametroMaximoVentasSuspendidas = New ClsParametro("MaximoVentasSuspendidas", New ClsParametroQuery("SELECT nMaximoVentasSuspendidas FROM CTL_ConfiguracionCanalesDistribucion(NOLOCK) WHERE nCanalDistribucion = " & .CanalDistribucion, False))
            '.ParametroIVA = New ClsParametro("IVA", New ClsParametroQuery("SELECT nIVA FROM CTL_ConfiguracionCanalesDistribucion(NOLOCK) WHERE nCanalDistribucion = " & .CanalDistribucion, False))
            '        .ParametroSerieFacturacion = New ClsParametro("SerieFacturacion", New ClsParametroQuery("SELECT cSerie FROM CTL_ConfiguracionCanalesDistribucion(NOLOCK) WHERE nCanalDistribucion = " & .CanalDistribucion, True))

            '        .ParametroIncluirCajasConCondicion = New ClsParametro("IncluirCajasConCondicion", New ClsParametroQuery("SELECT bIncluirCajasConCondicion FROM CTL_ConfiguracionCanalesDistribucion(NOLOCK) WHERE nCanalDistribucion = " & .CanalDistribucion, True))
            '        .ParametroPermiteApartarSinexistencias = New ClsParametro("PermiteApartarSinExistencias", New ClsParametroQuery("SELECT bPermiteApartarSinexistencias FROM CTL_ConfiguracionCanalesDistribucion(NOLOCK) WHERE nCanalDistribucion = " & .CanalDistribucion, True))
            '        .ParametroIncluirInvTtoComoDisponible = New ClsParametro("IncluirInvTtoComoDisponible", New ClsParametroQuery("SELECT bIncluirInvTtoComoDisponible FROM CTL_ConfiguracionCanalesDistribucion(NOLOCK) WHERE nCanalDistribucion = " & .CanalDistribucion, True))

            '        .ParametroPedidosTelemarketing = New ClsParametro("PedidosTelemarketing", New ClsParametroQuery("SELECT bPedidosTelemarketing FROM CTL_ConfiguracionCanalesDistribucion(NOLOCK) WHERE nCanalDistribucion = " & .CanalDistribucion, False))
            '        .ParametroCanalVirtual = New ClsParametro("CanalVirtual", New ClsParametroQuery("SELECT bVirtual FROM CTL_ConfiguracionCanalesDistribucion(NOLOCK) WHERE nCanalDistribucion = " & .CanalDistribucion, False))
            '        .ParametroDiasVigenciaVales = New ClsParametro("CanalVirtual", New ClsParametroQuery("SELECT nDiasVigenciaValesCaja FROM CTL_ConfiguracionCanalesDistribucion(NOLOCK) WHERE nCanalDistribucion = " & .CanalDistribucion, False))
            '        .ParametroCanalSurte = New ClsParametro("CanalVirtual", New ClsParametroQuery("SELECT nCanalSurte FROM CTL_ConfiguracionCanalesDistribucion(NOLOCK) WHERE nCanalDistribucion = " & .CanalDistribucion, False))
            '        .ParametroImprimeIva = New ClsParametro("ImprimeIva", New ClsParametroQuery("SELECT bImprimeIva FROM CTL_ConfiguracionCanalesDistribucion(NOLOCK) WHERE nCanalDistribucion = " & .CanalDistribucion, False))
            '        .ParametroImporteXPunto = New ClsParametro("ImportePuntos", New ClsParametroQuery("SELECT Top 1 nPesos FROM  COM_PuntosImporte(NOLOCK)", False))
            'End With
            'DAO.ParametrosSucursal = misParametrosSucursal

            Dim misParametrosTerminal As New Comunes.Comun.Parametros.ClsParametrosTerminal
            With misParametrosTerminal
                .ParametroAlmacen = New ClsParametroIni(PrmIni_AlmacenDefaultMovimiento, False)
                .ParametroCaja = New ClsParametroIni("CAJA", False)
                .ParametroAlmacenAlQueSePide = New ClsParametroIni(PrmIni_AlmacenAlQueSePidePedido, False)
                .ParametroAlmacenAlQueSePidePermiteModificar = New ClsParametroIni(PrmIni_PermiteModificarAlmacenAlQueSePidePedido, False)
                .ParametroPermiteImprimirPedido = New ClsParametroIni(PrmIni_ImprimePedido, False)
                .ParametroAlmacenAlQueSeSolicita = New ClsParametroIni(PrmIni_AlmacenAlQueSeSolicitaTraspaso, False)
                .ParametroAlmacenAlQueSeSolicitaPermiteModifcar = New ClsParametroIni(PrmIni_PermiteModificarAlmacenAlQueSeSolicitaTraspaso, False)
                .ParametroPermiteImprimirSolicitud = New ClsParametroIni(PrmIni_ImprimeSolicitudTraspaso, False)
                .ParametroAlmacenAlQueSeTraspasa = New ClsParametroIni(PrmIni_AlmacenAlQueSeTraspasa, False)
                .ParametroAlmacenAlQueSeTraspasaPermiteModificar = New ClsParametroIni(PrmIni_PermiteModificarAlmacenAlQueSeTraspasa, False)
                .ParametroPermiteImprimirSalidaPorTraspaso = New ClsParametroIni(PrmIni_ImprimeSalidaTraspaso, False)
                .ParametroPermiteImprimirSalidaPorDevolucion = New ClsParametroIni(PrmIni_ImprimeSalidaDevolucion, False)
                .ParametroPermiteImprimirSurtidoDePedido = New ClsParametroIni(PrmIni_ImprimeSurtido, False)
                .ParametroPermiteImprimirRecepcionDePedido = New ClsParametroIni(PrmIni_ImprimeRecepcionSurtido, False)
                .ParametroPermiteImprimirEntradaPorTraspaso = New ClsParametroIni(PrmIni_ImprimeEntradaTraspaso, False)
                .ParametroPermiteImprimirEntradaPorDevolucion = New ClsParametroIni(PrmIni_ImprimeEntradaDevolucion, False)
                .ParametroAlmacenAlQueSeDevuelve = New ClsParametroIni(PrmIni_AlmacenAlQueSeDevuelve, False)
                .ParametroAlmacenAlQueSeDevuelvePermiteModificar = New ClsParametroIni(PrmIni_PermiteModificarAlmacenAlQueSeDevuelve, False)
                .ParametroPermiteRegistroDocumentosContado = New ClsParametroIni(PrmIni_PermiteRegistroDocumentosContado, False)
                .ParametroPermiteRegistroDocumentosCredito = New ClsParametroIni(PrmIni_PermiteRegistroDocumentoCredito, False)
                .ParametroPermiteRegistroDocumentosCreditoCompleto = New ClsParametroIni(PrmIni_PermiteRegistroDocumentoCreditoCompleto, False)
                .ParametroIntervaloAlertas = New ClsParametroIni(PrmIni_Alertas, False)
                .ParametroBloqueoInactividad = New ClsParametroIni(PrmIni_TiempoInactividad, False)
                .ParametroAlmacenDefaulPermiteModificar = New ClsParametroIni(PrmIni_PermiteModificarAlmacenDefaultMovimiento, False)
                .ParametroContextoInicial = New ClsParametroIni(PrmIni_ContextoInicial, False)
                .ParametroProAlmacenMovimiento = New ClsParametroIni(PrmIni_ProAlmacenDefaultMovimiento, False)
                .ParametroProAlmacenAlQueDevuelve = New ClsParametroIni(PrmIni_ProAlmacenAlQueSeDevuelve, False)
                .ParametroProAlmacenAlQueDevuelvePermiteModificar = New ClsParametroIni(PrmIni_ProPermiteModificarAlmacenAlQueSeDevuelve, False)
                .ParametroProAlmacenAlQueSePide = New ClsParametroIni(PrmIni_ProAlmacenAlQueSePide, False)
                .ParametroProAlmacenAlQueSePidePermiteModificar = New ClsParametroIni(PrmIni_ProPermiteModificarAlmacenAlQueSePide, False)
                .ParametroProAlmacenAlQueSeSolicitaTraspaso = New ClsParametroIni(PrmIni_ProAlmacenAlQueSeSolicitaTraspaso, False)
                .ParametroProAlmacenAlQueSeSolicitaTraspasoPermiteModificar = New ClsParametroIni(PrmIni_ProPermiteModificarAlmacenAlQueSeSolicitaTraspaso, False)
                .ParametroProAlmacenAlQueSeTraspasa = New ClsParametroIni(PrmIni_ProAlmacenAlQueSeTraspasa, False)
                .ParametroProAlmacenAlQueSeTraspasaPermiteModificar = New ClsParametroIni(PrmIni_ProPermiteModificarAlmacenAlQueSeTraspasa, False)
                .ParametroProAlmacenDefaulMovimientoPermiteModificar = New ClsParametroIni(PrmIni_ProPermiteModificarAlmacenDefaultMovimiento, False)
                .ParametroProImpresoraTicket = New ClsParametroIni(PrmIni_ProImpresoraTickets, False)
                .ParametroProPermiteImprimirEntradaPorDevolucion = New ClsParametroIni(PrmIni_ProImprimeEntradaDevolucion, False)
                .ParametroProPermiteImprimirMovimientosGenerales = New ClsParametroIni(PrmIni_ProImprimeMovimientosGenerales, False)
                .ParametroProPermiteImprimirPedido = New ClsParametroIni(PrmIni_ProImprimePedido, False)
                .ParametroProPermiteImprimirRecepcionDeSuministro = New ClsParametroIni(PrmIni_ProImprimeRecepcionSuministro, False)
                .ParametroProPermiteImprimirSalidaPorTraspaso = New ClsParametroIni(PrmIni_ProImprimeSalidaTraspaso, False)
                .ParametroProPermiteImprimirSolicitudDeTraspaso = New ClsParametroIni(PrmIni_ProImprimeSolicitudTraspaso, False)
                .ParametroProPermiteImprimirSuministro = New ClsParametroIni(PrmIni_ProImprimeSuministro, False)
                .ParametroProPermiteModificarFechaMovimiento = New ClsParametroIni(PrmIni_ProPermiteModificarFechaMovimiento, False)
                .ParametroProImprimePideConfirmacion = New ClsParametroIni(PrmIni_ProImprimePideConfirmacion, False)
                .ParamtroProImprimeSolicitudDevolucion = New ClsParametroIni(PrmIni_ProImprimeSolicitudDevolucion, False)
                .ParametroImpresoraTicketPlantillaExpress = New ClsParametroIni(PrmIni_ImpresoraTicketPlantillaExpress, False)
                .ParametroNumeroCopiasTicketContrarecibos = New ClsParametroIni(PrmIni_NUMERO_COPIAS_TICKET_CONTRARECIBOS, False)
                .ParametroCodigoBarraNoValidadoAfectaGenerico = New ClsParametroIni(PrmIni_ProCodigoBarraNoValidadoAfectaCodigoGenerico, False)
                .ParametroPermiteCapturaCodigoEspecialASic = New ClsParametroIni(PrmIni_PermiteCapturaPedidoEspecialASIC, False)
                .ParametroNumeroCopiasTicketProduccionDistribucion = New ClsParametroIni(PrmIni_NUMERO_COPIAS_TICKET_PRODUCCION_DISTRIBUCION, False)
            End With

            'Dim miAlmacen As Dominio.Catalogos.ClsAlmacen = Dominio.Catalogos.FabricaCatalogos.ObtenAlmacen(misParametrosTerminal.Almacen)
            '    Dim miCanal As Dominio.Catalogos.ClsCanalDistribucion = Dominio.Catalogos.FabricaCatalogos.ObtenCanalDistribucion(misParametrosSucursal.CanalDistribucion)
            'If Not miAlmacen Is Nothing Then
            'If miAlmacen.CanalDistribucion.Folio <> miCanal.Folio Then
            'MessageBox.Show("El Almacen no pertenece al canal de distribucion especificado", GlobalSistemaCaption, MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End If
            'End If

            If FgParametroObtieneValor(PrmIni_PermiteCapturaPedidoEspecialASIC) = "" Then
                vcRutaIni = DAO.GetRutaArchivoIni
                vIFCarchivoIni.OpenINIFile(vcRutaIni)
                vIFCarchivoIni.SetEntry(PrmIni_PermiteCapturaPedidoEspecialASIC, "NO") 'Valor Default en 0
            End If
            'Agregar Parámetro INI de Impresora de Ticket de Plantilla Express
            If FgParametroObtieneValor(PrmIni_ImpresoraTicketPlantillaExpress) = "" Then
                vcRutaIni = DAO.GetRutaArchivoIni
                vIFCarchivoIni.OpenINIFile(vcRutaIni)
                vIFCarchivoIni.SetEntry(PrmIni_ImpresoraTicketPlantillaExpress, "0") 'Valor Default en 0
            End If

            If FgParametroObtieneValor(PrmIni_NUMERO_COPIAS_TICKET_CONTRARECIBOS) = "" Then
                vcRutaIni = DAO.GetRutaArchivoIni
                vIFCarchivoIni.OpenINIFile(vcRutaIni)
                vIFCarchivoIni.SetEntry(PrmIni_NUMERO_COPIAS_TICKET_CONTRARECIBOS, "1") 'Valor Default en 0
            End If

            If FgParametroObtieneValor(PrmIni_NUMERO_COPIAS_TICKET_PRODUCCION_DISTRIBUCION) = "" Then
                vcRutaIni = DAO.GetRutaArchivoIni
                vIFCarchivoIni.OpenINIFile(vcRutaIni)
                vIFCarchivoIni.SetEntry(PrmIni_NUMERO_COPIAS_TICKET_PRODUCCION_DISTRIBUCION, "1") 'Valor Default en 0
            End If

            If FgParametroObtieneValor(PrmIni_ProCodigoBarraNoValidadoAfectaCodigoGenerico) = "" Then
                vcRutaIni = DAO.GetRutaArchivoIni
                vIFCarchivoIni.OpenINIFile(vcRutaIni)
                vIFCarchivoIni.SetEntry(PrmIni_ProCodigoBarraNoValidadoAfectaCodigoGenerico, "NO") 'Valor Default en NO
            End If


            DAO.ParametrosTerminal = misParametrosTerminal

            '    Dim misParametrosCxc As New Dominio.clientes.Cxc.ClsParametrosCxC

            '    misParametrosCxc.TipoMovimiento_Anticipo = New ClsParametro("TM_Anticipo", New ClsParametroQuery("Select cValor From Adsum_ParametrosAdministrados where cContexto='CXC' and cParametroAdministrado='PRM_TipoMovimiento_Anticipo'", False))
            '    misParametrosCxc.TipoMovimiento_Provision = New ClsParametro("TM_Anticipo", New ClsParametroQuery("Select cValor From Adsum_ParametrosAdministrados where cContexto='CXC' and cParametroAdministrado='PRM_TipoMovimiento_Provision'", False))
            '    misParametrosCxc.Origen_de_Pago_Cartera = New ClsParametro("Origen_Pagos", New ClsParametroQuery("Select cValor From Adsum_ParametrosAdministrados where cContexto='CXC' and cParametroAdministrado='PRM_OrigenPago_Cartera'", False))
            '    ' DAO.ParametrosGenerales("CxC")=misParametrosCxc
        End Sub

        Private Shared misParametrosArchivoPlano As Comunes.Comun.Parametros.clsParametrosArchivoPlano


        Public Shared Function CargaParametrosArchivoPlano() As Comunes.Comun.Parametros.clsParametrosArchivoPlano
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            If misParametrosArchivoPlano Is Nothing Then
                misParametrosArchivoPlano = New Comunes.Comun.Parametros.clsParametrosArchivoPlano
                With misParametrosArchivoPlano
                    .RutaArchivosFacturasCompras = New ClsParametroValorPredefinido(DAO.ParametroAdministradoObtener("INV", "PRM_RutaArchivosFacturasCompras"))
                End With
            End If
            Return misParametrosArchivoPlano
        End Function

#Region "   WEB SERVICE  "


        Private Shared Sub CreaParametrosWebService()

            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia

            'Tiempo de espera General de WebServices
            DAO.ParametroAdministradoAgregar("WS", "WS_TIEMPO_ESPERA_GENERAL", DataAccessCls.TipoDeParametroAdministrado.Numero, "Define el tiempo de espera general para cualquier web service", "30000")

            Dim vTabla As New DataTable
            DAO.RegresaConsultaSQL("SELECT cDescripcion ,nEmpresa FROM CTL_Empresas(NOLOCK)", vTabla)
            For Each vRow As DataRow In vTabla.Rows
                DAO.ParametroAdministradoAgregar("WS", "SERVIDOR_WS_EMPRESA_" & vRow("nEmpresa"), DataAccessCls.TipoDeParametroAdministrado.Caracter, "Nombre del servidor de web service para la Empresa " & vRow("cDescripcion"), "http://192.168.10.57")
            Next


            'Web Service de Importacion de productos
            DAO.ParametroAdministradoAgregar("WS", "WS_wsImportacion", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Obtiene el url para conectarse al web service de obtener pedido de importacion", "/Comercial_WS/Importacion/wsImportacion.asmx")
            DAO.ParametroAdministradoAgregar("WS", "WS_TIEMPO_ESPERA_wsImportacion_getPedidoImportacion", DataAccessCls.TipoDeParametroAdministrado.Numero, "Define el tiempo de espera para el web service getPedidoImportacion", "3000")

            'Web Service de clientes Distinguidos
            DAO.ParametroAdministradoAgregar("WS", "WS_wsClienteDistinguido", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Obtiene el url para conectarse al web service de obtener pedido de importacion", "/Comercial_WS/ClienteDistinguido/wsClienteDistinguido.asmx")

            'Web Service de transferencias entre distribuidoras 'Remisiones'
            DAO.ParametroAdministradoAgregar("WS", "WS_wsRemisiones", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Obtiene el url para conectarse al web service de obtener pedido de importacion", "/Comercial_WS/Remisiones/wsRemisiones.asmx")

            'Web Service de pedidos entre distribuidoras
            DAO.ParametroAdministradoAgregar("WS", "WS_wsPedidos", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Obtiene el url para conectarse al web service de obtener pedido de importacion", "/Comercial_WS/Pedidos/wsPedidos.asmx")

            'Web Service de pedidos entre distribuidoras
            DAO.ParametroAdministradoAgregar("WS", "WS_wsDecomisos", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Obtiene el url para conectarse al web service de obtener decomisos", "/Comercial_WS/Decomisos/wsDecomisos.asmx")

            'Web Service de pedidos entre distribuidoras
            DAO.ParametroAdministradoAgregar("WS", "WS_wsCDT", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Obtiene el url para conectarse al web service correspondiente a compra directa en tienda", "/Comercial_WS/CDT/wsCDT.asmx")

            'Web Service de pedidos entre distribuidoras
            DAO.ParametroAdministradoAgregar("WS", "WS_wsCXC", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Obtiene el url para conectarse al web service correspondiente a CXC obtener Cargos y Pagos", "/Comercial_WS/CXC/AplicaPagos.asmx")

        End Sub


#End Region

        Public Shared Function SemanaDelAño(ByVal prmFecha As Date) As Short
            Dim vSemana As Short
            vSemana = (prmFecha.DayOfYear / 7)
            If vSemana Mod 2 <> 0 Or vSemana = 0 Then
                vSemana += 1
            End If
            Return vSemana
        End Function

        Public Shared Sub CreaOperacionesSupervisadas()
            DAO = DataAccessCls.DevuelveInstancia
            DAO.OperacionSupervisadaAgregar("PER_RestructuraPrestamo", "Pide autorización restructurar un prestamo")
            DAO.OperacionSupervisadaAgregar("PER_HorarioEspecial", "Pide autorización para un horario especial sin checar salida")
            DAO.OperacionSupervisadaAgregar("PER_Movimientos", "Pide autorización para modificar un registro validado")
            DAO.OperacionSupervisadaAgregar("CTL_Empleados", "Pide autorización para reactivar un empleado")
            DAO.OperacionSupervisadaAgregar("PER_Vacaciones", "Pide autorización para adelantar las vacaciones de un empleado por mas de 3 meses")
            DAO.OperacionSupervisadaAgregar("INV_InventarioFisico", "Pide autorización para aplicar un folio de inventario")

        End Sub

        'Public Shared Sub Spread_FormatoCuentaContable(ByVal prmGrid As FarPoint.Win.Spread.FpSpread, ByVal prmColInicial As Integer, ByVal prmColFinal As Integer)
        '    'Sistema       :Farmacon 
        '    'Modulo        :Compras
        '    'Procedimiento :Spread_FormatoCuentaContable
        '    'Desarrolo     :Lic. David Adan Velazquez Sanchez
        '    'Fecha         :1-Junio-2006
        '    'Que hace      :Aplica el Formato a la Columna o Rango de columnas especificado para las cuentas contables

        '    With prmGrid.ActiveSheet
        '        For x As Integer = prmColInicial To prmColFinal
        '            Dim vMask As New FarPoint.Win.Spread.CellType.MaskCellType
        '            vMask.Mask = "#### #### #### ####"
        '            vMask.MaskChar = "_"
        '            .Columns.Get(x).CellType = vMask
        '        Next
        '    End With
        'End Sub

        Public Shared Function CreaTablaDBF(ByVal prmNombreTabla As String, ByVal prmSqlCreate As String, ByVal prmRuta As String) As Boolean
            Dim vNombreCompleto As String = prmRuta & "\" & prmNombreTabla & ".dbf"
            Dim vFile As IO.File
            Try
                If vFile.Exists(vNombreCompleto) Then
                    vFile.Delete(vNombreCompleto)
                End If
            Catch ex As IO.IOException
                'MessageBox.Show("Ocurrió el Siguiente Error al Eliminar el Archivo DBF: " & ex.Message & "... Consulte al Administrador del Sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                If Not ClsTools.EjecutaComandoEnDBF("DELETE FROM " & prmNombreTabla, prmRuta) Then
                    MessageBox.Show("Error al Crear el Archivo DBF... Consulte al Administrador del Sistema", "Creación de Archivo DBF", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return False
                End If
                Return True
            Catch ex2 As Exception
                'MessageBox.Show("Ocurrió el Siguiente Error al Eliminar el Archivo DBF: " & ex2.Message & "... Consulte al Administrador del Sistema", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                If Not ClsTools.EjecutaComandoEnDBF("DELETE FROM " & prmNombreTabla, prmRuta) Then
                    MessageBox.Show("Error al Crear el Archivo DBF... Consulte al Administrador del Sistema", "Creación de Archivo DBF", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return False
                End If
                Return True
            End Try

            If Not ClsTools.EjecutaComandoEnDBF(prmSqlCreate, prmRuta) Then
                MessageBox.Show("Error al Crear el Archivo DBF... Consulte al Administrador del Sistema", "Creación de Archivo DBF", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End If

            Return True
        End Function

        Public Shared Function Es_RFC_Valido(ByVal prmRFC As String, Optional ByVal prmEsPersonaMoral As Boolean = True) As String
            'Sistema       : Farmacon
            'Modulo        : General
            'Procedimiento : Es_RFC_Valido
            'Desarrolo     : Oscar Cerrito Mantero As Em
            'Fecha         : 14-Dic-2005
            'Que hace      : Dada una Cadena(prmRFC) Valida Si Es RFC Dependiendo Del parametro: prmEsPersonaMoral.

            'Parametros:
            'prmRFC             : Cadena que representa el RFC a Validar.
            'prmEsPersonaMoral  : (True(Predeterminado).- Si Es persona Moral, False.- Persona Fisica)

            Dim vRFC As String = prmRFC.Trim.ToUpper
            Dim vMsg As String = "RFC incompleto"
            If vRFC = "" Then
                Return vMsg
            End If

            Dim vError As Boolean = False
            Dim vIncTempo As Byte = 0
            Dim vTotalPrimerasLetras As Int16
            'Validación Por Longitud de RFC dependiendo de Tipo de Persona
            If prmEsPersonaMoral Then
                vError = vRFC.Length <> 12
                vTotalPrimerasLetras = 3
            Else
                vError = vRFC.Length <> 13
                vIncTempo = 1
                vTotalPrimerasLetras = 4
            End If

            Dim vAbcdario As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
            Dim vCharsRFC As Char() = vRFC.ToCharArray

            Dim vIndice As Int16 = 0
            If vAbcdario.IndexOf(vCharsRFC(vIndice)) = -1 Then
                vMsg = "El primer carácter del RFC invalido, '" + vCharsRFC(vIndice) + "'"
                Return vMsg
            End If

            If vCharsRFC.Length < 2 Then Return vMsg

            vIndice += 1
            If vAbcdario.IndexOf(vCharsRFC(vIndice)) = -1 Then
                vMsg = "El segundo carácter del RFC invalido, '" + vCharsRFC(vIndice) + "'"
                Return vMsg
            End If

            If vCharsRFC.Length < 3 Then Return vMsg

            vIndice += 1
            If vAbcdario.IndexOf(vCharsRFC(vIndice)) = -1 Then
                vMsg = "El tercer carácter del RFC invalido, '" + vCharsRFC(vIndice) + "'"
                Return vMsg
            End If

            If Not prmEsPersonaMoral Then
                If vCharsRFC.Length < 4 Then Return vMsg

                vIndice += 1
                If vAbcdario.IndexOf(vCharsRFC(vIndice)) = -1 Then
                    vMsg = "El cuarto carácter del RFC invalido, '" + vCharsRFC(vIndice) + "'"
                    Return vMsg
                End If
            End If


            'Validacion Del Año
            vIndice += 1
            If vCharsRFC.Length < vIndice + 1 Then Return vMsg

            Dim vAño1 As Char = vCharsRFC(vIndice)
            If Not IsNumeric(vAño1) Then
                vMsg = "Especifique los caracteres que conforman el año"
                Return vMsg
            End If


            vIndice += 1
            If vCharsRFC.Length < vIndice + 1 Then Return vMsg

            Dim vAño2 As Char = vCharsRFC(vIndice)
            If Not IsNumeric(vAño2) Then
                vMsg = "Especifique los caracteres que conforman el año"
                Return vMsg
            End If

            Dim vAño As Int16 = Val(vAño1 & vAño2)
            If Not (vAño >= 0 AndAlso vAño <= 99) Then
                vMsg = "Especifique los caracteres que conforman el año"
                Return vMsg
            End If

            'Validacion Del Mes        
            vIndice += 1
            If vCharsRFC.Length < vIndice + 1 Then Return vMsg

            Dim vMes1 As Char = vCharsRFC(vIndice)
            If Not IsNumeric(vMes1) Then
                vMsg = "Número de conforma el mes invalido, '" + vCharsRFC(vIndice) + "'"
                Return vMsg
            End If

            vIndice += 1
            If vCharsRFC.Length < vIndice + 1 Then Return vMsg

            Dim vMes2 As Char = vCharsRFC(vIndice)
            If Not IsNumeric(vMes2) Then
                vMsg = "Número que conforma el mes invalido, '" + vMes2 + "'"
                Return vMsg
            End If

            Dim vMes As Int16 = Val(vMes1 + vMes2)
            If Not (vMes >= 1 AndAlso vMes <= 12) Then
                vMsg = "Número que conforma el mes invalido, '" + vMes.ToString + "'"
                Return vMsg
            End If

            'Validacion Del Dia
            vIndice += 1
            If vCharsRFC.Length < vIndice + 1 Then Return vMsg

            If Not IsNumeric(vCharsRFC(vIndice)) Then
                vMsg = "Número que conforma el día invalido, '" + vCharsRFC(vIndice) + "'"
                Return vMsg
            End If

            vIndice += 1
            If vCharsRFC.Length < vIndice + 1 Then Return vMsg

            If Not IsNumeric(vCharsRFC(vIndice)) Then
                vMsg = "Número que conforma el día invalido, '" + vCharsRFC(vIndice) + "'"
                Return vMsg
            End If

            vAño = IIf(vAño <= 50, vAño + 2000, vAño + 1900)
            If Not (Val(vCharsRFC(vIndice - 1) + vCharsRFC(vIndice)) >= 1 AndAlso Val(vCharsRFC(vIndice - 1) + vCharsRFC(vIndice)) <= Date.DaysInMonth(vAño, vMes)) Then
                vMsg = "Número que conforma el día invalido, '" + vCharsRFC(vIndice - 1) + vCharsRFC(vIndice) + "'"
                Return vMsg
            End If

            'Validación De Los Ultimos Tres Digitos
            vIndice += 1
            If vCharsRFC.Length < vIndice + 1 Then
                vMsg = "Homoclave incompleta"
                Return vMsg
            End If
            If vAbcdario.IndexOf(vCharsRFC(vIndice)) = -1 AndAlso OnlyIntNumers().IndexOf(vCharsRFC(vIndice)) = -1 Then
                vMsg = "El primer caracter de la homoclave invalido, '" + vCharsRFC(vIndice) + "'"
                Return vMsg
            End If

            vIndice += 1
            If vCharsRFC.Length < vIndice + 1 Then
                vMsg = "Homoclave incompleta"
                Return vMsg
            End If
            If vAbcdario.IndexOf(vCharsRFC(vIndice)) = -1 AndAlso OnlyIntNumers().IndexOf(vCharsRFC(vIndice)) = -1 Then
                vMsg += "El segundo caracter de la homoclave invalido, '" + vCharsRFC(vIndice) + "'"
                Return vMsg
            End If

            vIndice += 1
            If vCharsRFC.Length < vIndice + 1 Then
                vMsg = "Homoclave incompleta"
                Return vMsg
            End If
            If vAbcdario.IndexOf(vCharsRFC(vIndice)) = -1 AndAlso OnlyIntNumers().IndexOf(vCharsRFC(vIndice)) = -1 Then
                vMsg = "El segundo caracter de la homoclave invalido, '" + vCharsRFC(vIndice) + "'"
                Return vMsg
            End If

            If vCharsRFC.Length > vTotalPrimerasLetras + 9 Then
                vMsg = "Existes más caractes no correspondientes al RFC, " + vCharsRFC(vIndice + 1)
                Return vMsg
            End If

            Return ""
        End Function

#Region "Metodos del Grid"


        'Public Shared Function InsertaFormulaTotalGrid(ByRef prmGrid As FarPoint.Win.Spread.FpSpread, _
        'ByVal prmRenglonInicial As Integer, ByVal prmRenglonFinal As Integer, ByVal prmColumnaSumar As Integer, _
        'ByVal prmRenglonInsertaTotal As Integer, ByVal prmColumnaInsertaTotal As Integer)
        '    Dim vSuma As String
        '    With prmGrid.ActiveSheet
        '        .ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        '        vSuma = "sum(R" & prmRenglonInicial & "C" & prmColumnaSumar & ":R" & prmRenglonFinal & "C" & prmColumnaSumar & ")"
        '        .Cells(prmRenglonInsertaTotal, prmColumnaInsertaTotal).Formula = vSuma
        '    End With
        'End Function


        'Public Shared Function Spread_ConfiguraFormatoFechaDeColumna(ByVal prmGrid As FarPoint.Win.Spread.FpSpread, ByVal prmFormato As String, ByVal prmColumna As Integer, Optional ByVal prmRenglon As Integer = -1)
        '    'Sistema       :San Martin 
        '    'Modulo        :Ventas
        '    'Procedimiento :Spread_ConfiguraFormatoFechaDeColumna
        '    'Desarrolo     : O.C.M.As Em
        '    'Fecha         :11-Enero-2005
        '    'Que hace      :Configura una columna/celda a un formato definido por el usuario de tipo Fecha/Hora

        '    'Parametros:
        '    '   1. Grid de tipo FarPoint.Win.Spread.FpSpread
        '    '   2. Una cadena que define el formato. (Ej. "yyyy-MM-dd HH:mm:ss")
        '    '   3. Numero de Columna del grid a Formatear. Acepta valores > 0 (obligatoria)
        '    '   4. Numero de Renglon del grid a formatear en caso de querer formatear una celda en particular del grid. en caso que no se especifique obtendra valor de -1


        '    Dim vCelltype As New FarPoint.Win.Spread.CellType.DateTimeCellType
        '    vCelltype.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined
        '    vCelltype.UserDefinedFormat = prmFormato
        '    If prmRenglon > -1 Then
        '        prmGrid.ActiveSheet.Cells(prmRenglon, prmColumna).CellType = vCelltype
        '    Else
        '        prmGrid.ActiveSheet.Columns(prmColumna).CellType = vCelltype
        '    End If
        'End Function

        'Public Shared Sub Spread_ConfiguraFormatDateTime(ByVal prmGrid As FarPoint.Win.Spread.FpSpread, ByVal prmCol As Integer, ByVal prmRow As Integer)
        '    'Sistema       :San Martin 
        '    'Modulo        :Ventas
        '    'Procedimiento :Spread_ConfiguraFormatTimeOnly
        '    'Desarrolo     : O.C.M. AS Em
        '    'Fecha         :11-Enero-2005
        '    'Que hace      :Configura una columna/celda a un formato definido por el usuario de solo Hora

        '    'Parametros:
        '    '   1. Grid de tipo FarPoint.Win.Spread.FpSpread
        '    '   3. Numero de Columna del grid a Formatear. Acepta valores > 0 (obligatoria)
        '    '   4. Numero de Renglon del grid a formatear en caso de querer formatear una celda en particular del grid. en caso que no se especifique obtendra valor de -1
        '    Dim vCell As New FarPoint.Win.Spread.CellType.DateTimeCellType
        '    vCell.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined
        '    vCell.UserDefinedFormat = "yyyy-MM-dd HH:mm:ss tt"
        '    If prmRow > -1 Then
        '        prmGrid.ActiveSheet.Cells(prmRow, prmCol).CellType = vCell
        '    Else
        '        prmGrid.ActiveSheet.Columns(prmCol).CellType = vCell
        '    End If

        'End Sub

        'Public Shared Sub Spread_ConfiguraFormatDateTimeSuKarne(ByVal prmGrid As FarPoint.Win.Spread.FpSpread, ByVal prmCol As Integer)
        '    'Sistema       :San Martin 
        '    'Modulo        :Ventas
        '    'Procedimiento :Spread_ConfiguraFormatTimeOnly
        '    'Desarrolo     : O.C.M. AS Em
        '    'Fecha         :11-Enero-2005
        '    'Que hace      :Configura una columna/celda a un formato definido por el usuario de solo Hora

        '    'Parametros:
        '    '   1. Grid de tipo FarPoint.Win.Spread.FpSpread
        '    '   3. Numero de Columna del grid a Formatear. Acepta valores > 0 (obligatoria)
        '    '   4. Numero de Renglon del grid a formatear en caso de querer formatear una celda en particular del grid. en caso que no se especifique obtendra valor de -1
        '    Dim vCell As New FarPoint.Win.Spread.CellType.DateTimeCellType
        '    vCell.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.UserDefined
        '    vCell.UserDefinedFormat = "dd-MM-yyyy"
        '    prmGrid.ActiveSheet.Columns(prmCol).CellType = vCell
        'End Sub

        Public Shared Function Spread_BackGroud_Headers() As Color
            Return Color.DarkBlue
        End Function


        'Public Shared Sub Spread_ConfiguraFormatTimeOnly(ByVal prmGrid As FarPoint.Win.Spread.FpSpread, ByVal prmCol As Integer, ByVal prmRow As Integer)
        '    'Sistema       :San Martin 
        '    'Modulo        :Ventas
        '    'Procedimiento :Spread_ConfiguraFormatTimeOnly
        '    'Desarrolo     : O.C.M. AS Em
        '    'Fecha         :11-Enero-2005
        '    'Que hace      :Configura una columna/celda a un formato definido por el usuario de solo Hora

        '    'Parametros:
        '    '   1. Grid de tipo FarPoint.Win.Spread.FpSpread
        '    '   3. Numero de Columna del grid a Formatear. Acepta valores > 0 (obligatoria)
        '    '   4. Numero de Renglon del grid a formatear en caso de querer formatear una celda en particular del grid. en caso que no se especifique obtendra valor de -1
        '    Dim vCell As New FarPoint.Win.Spread.CellType.DateTimeCellType
        '    vCell.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.TimeOnly
        '    If prmRow > -1 Then
        '        prmGrid.ActiveSheet.Cells(prmRow, prmCol).CellType = vCell
        '    Else
        '        prmGrid.ActiveSheet.Columns(prmCol).CellType = vCell
        '    End If

        'End Sub

        'Public Shared Sub Spread_LockColumns(ByVal prmGrid As FarPoint.Win.Spread.FpSpread, ByVal prmColIni As Integer, ByVal prmColfin As Integer, ByVal prmBool As Boolean)
        '    For i As Integer = prmColIni To prmColfin
        '        With prmGrid.ActiveSheet
        '            .Columns(i).Locked = prmBool
        '        End With
        '    Next
        'End Sub

        'Public Shared Sub Spread_agregaRenglonDeTotales(ByVal prmGrid As FarPoint.Win.Spread.FpSpread, ByVal prmArColumnasConTotales As System.Collections.ArrayList, Optional ByVal prmbInsertarRenglonDeTotales As Boolean = True)
        '    'Sistema        :Grupo San Martin
        '    'Módulo         :Herramientas Generales
        '    'Procedimiento  :ClsTools.Spread_agregaRenglonDeTotales
        '    'Desarrolló     :Lic. César García  
        '    'Fecha          :18 de Marzo del 2005
        '    'Que Hace?      :1. Toma un grid de tipo Spread y configura el primer renglón como renglón de totales
        '    '                   agregándole total a las columnas enviadas en el arreglo enviado
        '    '                2. Si inserta el renglón de totales 
        '    '                   a. Lo colorea igual que los encabezados
        '    '                   b. Congela el renglón de totales para que nunca se pierda de la vista del usuario
        '    'Parámetros     :prmGrid                        (grid al que se desea agregar renglón de totales)
        '    '                prmArColumnasConTotales        (arreglo de valores tipo integer que contiene la lista de columnas a las que se desea agregar totales)
        '    '                prmbInsertarRenglonDeTotales   (bandera que le indica al procedimiento si es necesario agregar el renglón. Por default este valor es True)

        '    With prmGrid
        '        If .ActiveSheet.RowCount = 0 Then
        '            Exit Sub
        '        End If
        '        If prmbInsertarRenglonDeTotales Then 'Inserta el renglón de totales en el primer renglón
        '            .ActiveSheet.AddRows(0, 1)
        '            .ActiveSheet.Rows(0).BackColor = .ActiveSheet.ActiveSkin.HeaderBackColor
        '            .ActiveSheet.Rows(0).ForeColor = .ActiveSheet.ActiveSkin.HeaderForeColor
        '            If .ActiveSheet.FrozenRowCount < 1 Then .ActiveSheet.FrozenRowCount = 1
        '        End If
        '        prmGrid.ActiveSheet.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        '        For Each columnaConTotal As Integer In prmArColumnasConTotales.ToArray
        '            .ActiveSheet.Cells(0, columnaConTotal).Formula = "sum(R2C" + (columnaConTotal + 1).ToString.Trim + ":R" + .ActiveSheet.RowCount.ToString.Trim + "C" + (columnaConTotal + 1).ToString.Trim + ")"
        '        Next
        '    End With
        'End Sub

        'Public Shared Sub Spread_agregaRenglonDeTotalesAlFinal(ByVal prmGrid As FarPoint.Win.Spread.FpSpread, ByVal prmArColumnasConTotales As System.Collections.ArrayList, Optional ByVal prmbInsertarRenglonDeTotales As Boolean = True)
        '    'Sistema        :Grupo San Martin
        '    'Módulo         :Herramientas Generales
        '    'Procedimiento  :ClsTools.Spread_agregaRenglonDeTotales
        '    'Desarrolló     :Lic. César García  
        '    'Fecha          :18 de Marzo del 2005
        '    'Que Hace?      :1. Toma un grid de tipo Spread y configura el primer renglón como renglón de totales
        '    '                   agregándole total a las columnas enviadas en el arreglo enviado
        '    '                2. Si inserta el renglón de totales 
        '    '                   a. Lo colorea igual que los encabezados
        '    '                   b. Congela el renglón de totales para que nunca se pierda de la vista del usuario
        '    'Parámetros     :prmGrid                        (grid al que se desea agregar renglón de totales)
        '    '                prmArColumnasConTotales        (arreglo de valores tipo integer que contiene la lista de columnas a las que se desea agregar totales)
        '    '                prmbInsertarRenglonDeTotales   (bandera que le indica al procedimiento si es necesario agregar el renglón. Por default este valor es True)
        '    'Modificaciones :Lic. David Adan Velazquez Sanchez : Solo se hizo que el renglon de totales quedara al final para la exportacion a excel


        '    With prmGrid
        '        If .ActiveSheet.RowCount = 0 Then
        '            Exit Sub
        '        End If
        '        Dim miRow As Integer = .ActiveSheet.RowCount
        '        If prmbInsertarRenglonDeTotales Then 'Inserta el renglón de totales en el primer renglón
        '            .ActiveSheet.AddRows(miRow, 2)
        '            .ActiveSheet.Rows(miRow + 1).BackColor = .ActiveSheet.ActiveSkin.HeaderBackColor
        '            .ActiveSheet.Rows(miRow + 1).ForeColor = .ActiveSheet.ActiveSkin.HeaderForeColor
        '        End If
        '        prmGrid.ActiveSheet.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1
        '        For Each columnaConTotal As Integer In prmArColumnasConTotales.ToArray
        '            .ActiveSheet.Cells(miRow, columnaConTotal).Formula = "sum(R1C" + (columnaConTotal + 1).ToString.Trim + ":R" + (miRow - 1).ToString + "C" + (columnaConTotal + 1).ToString.Trim + ")"
        '        Next
        '        'Aqui agregaremos un nuevo renglon y quitaremos las formulas para que exporte bien a excel
        '        For x As Integer = 0 To .ActiveSheet.ColumnCount - 1
        '            .ActiveSheet.Cells(miRow + 1, x).Value = .ActiveSheet.Cells(miRow, x).Value
        '        Next
        '        .ActiveSheet.RemoveRows(miRow, 1)
        '    End With
        'End Sub


        'Public Shared Sub Spread_Selecciona_Renglon_Completo(ByVal prmGrid As FarPoint.Win.Spread.FpSpread, ByVal prmRow As Integer)
        '    'Sistema       :San Martin 
        '    'Modulo        :Ventas
        '    'Procedimiento :Spread_Selecciona_Renglon_Completo
        '    'Desarrolo     : 
        '    'Fecha         :17-Enero-2005
        '    'Que hace      :Selecciona un renglon completo

        '    'Parametros:
        '    '   1. Grid de tipo FarPoint.Win.Spread.FpSpread
        '    '   2. Numero de renglon a seleccionar
        '    prmGrid.ActiveSheet.ClearSelection()
        '    prmGrid.ActiveSheet.AddSelection(prmRow, 0, 1, prmGrid.ActiveSheet.Columns.Count - 1)
        '    prmGrid.ActiveSheet.ActiveRowIndex = prmRow
        'End Sub

        'Public Shared Sub Spread_Ocultar_Columnas(ByVal prmGrid As FarPoint.Win.Spread.FpSpread, ByVal prmColInicial As Integer, ByVal prmColFinal As Integer)
        '    'Sistema       :San Martin 
        '    'Modulo        :Ventas
        '    'Procedimiento :Spread_Ocultar_Columnas
        '    'Desarrolo     : O.C.M. AS Em
        '    'Fecha         :27-Enero-2005
        '    'Que hace      :Ouclta rango de columnas a partir de una columna inicial y una final

        '    'Parametros:
        '    '   1. Grid de tipo FarPoint.Win.Spread.FpSpread
        '    '   2. Numero de Coluna a partir de la cual se va a acultar el resto
        '    With prmGrid.ActiveSheet
        '        For i As Integer = prmColInicial To prmColFinal
        '            .SetColumnVisible(i, False)
        '        Next
        '    End With
        'End Sub

        'Public Shared Sub Spread_Ocultar_Ultimas_Columnas(ByVal prmGrid As FarPoint.Win.Spread.FpSpread, ByVal prmColInicial As Integer)
        '    'Sistema       :San Martin 
        '    'Modulo        :Ventas
        '    'Procedimiento :Spread_Ocultar_Ultimas_Columnas
        '    'Desarrolo     : O.C.M. AS Em
        '    'Fecha         :27-Enero-2005
        '    'Que hace      :Ouclta las ultimas colunas a partir de una columna inicial

        '    'Parametros:
        '    '   1. Grid de tipo FarPoint.Win.Spread.FpSpread
        '    '   2. Numero de Coluna a partir de la cual se va a acultar el resto
        '    With prmGrid.ActiveSheet
        '        For i As Integer = prmColInicial To .Columns.Count - 1
        '            .SetColumnVisible(i, False)
        '        Next
        '    End With
        'End Sub

        'Public Shared Function DatoUnico(ByVal prmManejador As ManejadorFpSpread, ByVal prmRow As Int16, ByVal prmCol As Int16) As Boolean
        '    Dim vBool As Boolean = True
        '    With prmManejador.Hoja
        '        For i As Int16 = 0 To .RowCount - 1
        '            If i <> prmRow Then
        '                If Val(.Cells(prmRow, prmCol).Text) = Val(.Cells(i, prmCol).Text) Then
        '                    vBool = False
        '                End If
        '            End If
        '        Next
        '    End With
        '    Return vBool
        'End Function

        'Public Shared Sub Spread_DesOcultar_Columnas(ByVal prmGrid As FarPoint.Win.Spread.FpSpread, ByVal prmColInicial As Integer, ByVal prmColFinal As Integer)
        '    'Sistema       :San Martin 
        '    'Modulo        :Ventas
        '    'Procedimiento :Spread_DesOcualtar_Columnas
        '    'Desarrolo     : O.C.M. AS Em
        '    'Fecha         :22-Agosto-2005
        '    'Que hace      :DesOuculta rango de columnas a partir de una columna inicial y una final

        '    'Parametros:
        '    '   1. Grid de tipo FarPoint.Win.Spread.FpSpread
        '    '   2. Numero de Coluna a partir de la cual se va a desocultar el resto
        '    With prmGrid.ActiveSheet
        '        For i As Integer = prmColInicial To prmColFinal
        '            .SetColumnVisible(i, True)
        '        Next
        '    End With
        'End Sub

        'Public Shared Sub Spread_DesOcultar_Ultimas_Columnas(ByVal prmGrid As FarPoint.Win.Spread.FpSpread, ByVal prmColInicial As Integer)
        '    'Sistema       :San Martin 
        '    'Modulo        :Ventas
        '    'Procedimiento :Spread_DesOcultar_Ultimas_Columnas
        '    'Desarrolo     : O.C.M. AS Em
        '    'Fecha         :27-Enero-2005
        '    'Que hace      :Ouclta las ultimas colunas a partir de una columna inicial

        '    'Parametros:
        '    '   1. Grid de tipo FarPoint.Win.Spread.FpSpread
        '    '   2. Numero de Coluna a partir de la cual se va a acultar el resto
        '    With prmGrid.ActiveSheet
        '        For i As Integer = prmColInicial To .Columns.Count - 1
        '            .SetColumnVisible(i, True)
        '        Next
        '    End With
        'End Sub

        ''Public Shared Sub Spread_CustomSkin(ByVal prmSkinDefault As FarPoint.Win.Spread.SheetSkin)
        ''    'Sistema       : Compras
        ''    'Modulo        : Ventas
        ''    'Procedimiento : Spread_CustomSkin
        ''    'Desarrolo     : O.C.M. AS Em
        ''    'Fecha         : 28-Marzo-2006
        ''    'Que hace      : Personaliza Un Skin Para Un Grid....

        ''    'Parametros:
        ''    With prmSkinDefault
        ''        Dim vSkin As New FarPoint.Win.Spread.SheetSkin("CustomSkin", .BackColor, _
        ''                .CellBackColor, .CellForeColor, .GridLineColor, .GridLines, _
        ''                ClsTools.Spread_BackGroud_Headers, .HeaderForeColor, .SelectionBackColor, .SelectionForeColor, Color.LightGray, Color.LightGray, .FlatColumnHeader, .FlatRowHeader, .HeaderFontBold, .ShowColumnHeader, .ShowRowHeader)
        ''    End With

        ''End Sub


        'Public Shared Sub Spread_LimpiarCeldas(ByVal prmGrd As FarPoint.Win.Spread.FpSpread, ByVal prmRow As Integer, ByVal prmColIni As Integer, ByVal prmColFin As Integer)
        '    With prmGrd.ActiveSheet
        '        For i As Integer = prmColIni To prmColFin
        '            .Cells(prmRow, i).Value = Nothing
        '        Next
        '    End With
        'End Sub

#End Region

#Region "Metodos del msp"

        'Private Shared Function CeldasIguales(ByVal prmManejadorFpSpread As ManejadorFpSpread, ByVal prmRow1 As Integer, ByVal prmRow2 As Integer, ByVal prmColumna As Integer) As Boolean
        '    With prmManejadorFpSpread.Hoja
        '        If IsNumeric(.Cells(prmRow1, prmColumna).Text) And IsNumeric(.Cells(prmRow2, prmColumna).Text) Then
        '            If Val(.Cells(prmRow1, prmColumna).Text) = Val(.Cells(prmRow2, prmColumna).Text) Then Return True
        '        Else
        '            If .Cells(prmRow1, prmColumna).Text = .Cells(prmRow2, prmColumna).Text Then Return True
        '        End If
        '    End With
        '    Return False
        'End Function

        'Public Shared Function msp_ArticuloEquivalenteUnico(ByVal prmManejador As ManejadorFpSpread, ByVal prmRow As Int16, Optional ByVal colArt As Int16 = 0, Optional ByVal colUni As Int16 = 2, Optional ByVal colEqu As Int16 = 4) As Boolean
        '    'Sistema       : FarmaCon
        '    'Modulo        : Compras
        '    'Procedimiento : msp_ArticuloEquivalenteUnico
        '    'Desarrolo     : O.C.M.As Em
        '    'Fecha         : 10-Sept-2005
        '    'Que hace      : Busca Un Articulo con Unidad y Equivalencia 

        '    'Parametros:

        '    With prmManejador.Hoja
        '        For vRow As Short = 0 To prmRow - 1
        '            If (vRow <> prmRow) Then
        '                If Val(.Cells(prmRow, colArt).Value) = Val(.Cells(vRow, colArt).Value) AndAlso Val(.Cells(prmRow, colUni).Value) = Val(.Cells(vRow, colUni).Value) AndAlso Val(.Cells(prmRow, colEqu).Value) = Val(.Cells(vRow, colEqu).Value) Then
        '                    Return False
        '                End If
        '            End If
        '        Next
        '    End With
        '    Return True
        'End Function

        'Public Shared Function msp_ArticuloEquivalenteUnicoRegresaRowRepetido(ByVal prmManejador As ManejadorFpSpread, ByVal prmRow As Int16, Optional ByVal colArt As Int16 = 0, Optional ByVal colUni As Int16 = 2, Optional ByVal colEqu As Int16 = 4) As Boolean
        '    'Sistema       : FarmaCon
        '    'Modulo        : Compras
        '    'Procedimiento : msp_ArticuloEquivalenteUnico
        '    'Desarrolo     : O.C.M.As Em
        '    'Fecha         : 10-Sept-2005
        '    'Que hace      : Busca Un Articulo con Unidad y Equivalencia 

        '    'Parametros:

        '    With prmManejador.Hoja
        '        For vRow As Int16 = 0 To .RowCount - 1
        '            If (vRow <> prmRow) Then
        '                If Val(.Cells(prmRow, colArt).Value) = Val(.Cells(vRow, colArt).Value) AndAlso Val(.Cells(prmRow, colUni).Value) = Val(.Cells(vRow, colUni).Value) AndAlso Val(.Cells(prmRow, colEqu).Value) = Val(.Cells(vRow, colEqu).Value) Then
        '                    Return vRow
        '                End If
        '            End If
        '        Next
        '    End With
        '    Return -1
        'End Function

        'Public Shared Function msp_RegresaRowRepetido(ByVal prmManejador As ManejadorFpSpread, ByVal prmRow As Int16, ByVal colValidar As Int16) As Integer
        '    'Sistema       : FarmaCon
        '    'Modulo        : Compras
        '    'Procedimiento : msp_ArticuloEquivalenteUnico
        '    'Desarrolo     : O.C.M.As Em
        '    'Fecha         : 10-Sept-2005
        '    'Que hace      : Busca Un Articulo con Unidad y Equivalencia 

        '    'Parametros:

        '    With prmManejador.Hoja
        '        For vRow As Int16 = 0 To .RowCount - 1
        '            If (vRow <> prmRow) Then
        '                If Val(.Cells(prmRow, colValidar).Value) = Val(.Cells(vRow, colValidar).Value) Then
        '                    Return vRow
        '                End If
        '            End If
        '        Next
        '    End With
        '    Return -1
        'End Function

        'Public Shared Function msp_CodigoDeBarrasUnico(ByVal prmManejador As ManejadorFpSpread, ByVal prmRow As Int16, ByVal prmCodigoDeBarras As String, Optional ByVal prmCol As Int16 = 0) As Boolean

        '    'Sistema       : FarmaCon
        '    'Modulo        : Compras
        '    'Procedimiento : msp_ArticuloEquivalenteUnico
        '    'Desarrolo     : O.C.M.As Em
        '    'Fecha         : 10-Sept-2005
        '    'Que hace      : Busca Un Articulo con Unidad y Equivalencia 

        '    With prmManejador.Hoja
        '        For vRow As Int16 = 0 To .RowCount - 1
        '            If (vRow <> prmRow) Then
        '                If .Cells(prmRow, prmCol).Text.Trim = .Cells(vRow, prmCol).Text.Trim Then
        '                    Return False
        '                End If
        '            End If
        '        Next
        '    End With
        '    Return True
        'End Function

        Public Shared Function msp_Color_Renglon_Invalido() As Color
            'Sistema       : FarmaCon
            'Modulo        : Compras
            'Procedimiento : msp_Color_Renglon_Invalido
            'Desarrolo     : O.C.M.As Em
            'Fecha         : 10-Sept-2005
            'Que hace      : Regresa el Color Con El que se Resaltara El Renglon Invalido

            Return Color.Navy
        End Function

        'Public Shared Function msp_Border_Ren_Invalido() As FarPoint.Win.RoundedLineBorder
        '    'Sistema       : FarmaCon
        '    'Modulo        : Compras
        '    'Procedimiento : msp_Color_Renglon_Invalido
        '    'Desarrolo     : O.C.M.As Em
        '    'Fecha         : 10-Sept-2005
        '    'Que hace      : Regresa el Border Con El que se Resaltara El Renglon Invalido
        '    Dim vBorder As FarPoint.Win.RoundedLineBorder = New FarPoint.Win.RoundedLineBorder(msp_Color_Renglon_Invalido)
        '    With vBorder
        '        'Set Properties
        '    End With

        '    Return vBorder
        'End Function


        'Public Shared Function msp_Border_Cell_Invalido() As FarPoint.Win.ComplexBorderSide
        '    'Sistema       : FarmaCon
        '    'Modulo        : Compras
        '    'Procedimiento : msp_Color_Renglon_Invalido
        '    'Desarrolo     : O.C.M.As Em
        '    'Fecha         : 10-Sept-2005
        '    'Que hace      : Regresa el Border Con El que se Resaltara El Renglon Invalido
        '    Dim vCustomBorder As New FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.DoubleLine, msp_Color_Renglon_Invalido)
        '    Return vCustomBorder
        'End Function

#End Region

        Public Shared Sub CentraControlEnForma(ByVal prmForma As Form, ByVal prmControl As Control)
            Dim vTop As Integer, vLeft As Integer
            vTop = (prmForma.Width / 2) - (prmControl.Width / 2)
            vLeft = (prmForma.Height / 2) - (prmControl.Height / 2)

            prmControl.Location = prmForma.PointToClient(New Point(vTop, vLeft))

        End Sub

        Public Shared Function Folio_Valido(ByVal Atx As AccTextBoxAdvanced, Optional ByVal prmValidarTiempoReal As Boolean = False) As Boolean

            If Not ((Not Atx.Text Is Nothing) AndAlso Atx.Text <> "" AndAlso IsNumeric(Atx.Text)) Then
                Return False
            End If

            Return IIf(prmValidarTiempoReal, Not Atx.CatalogoBase.ObtenElementoRow(Atx.Text) Is Nothing, Atx.ValorValido)

        End Function


        Public Shared Function String_Valido(ByVal Atx As AccTextBoxAdvanced) As Boolean
            Return (Not Atx.Text Is Nothing) AndAlso Atx.Text <> "" AndAlso (Not IsNumeric(Atx.Text)) AndAlso Atx.ValorValido
        End Function

        Public Shared Function Valida_Atx(ByVal Atx As AccTextBoxAdvanced, Optional ByVal prmDescripcion As String = "") As Boolean
            If Not (Atx.Text <> "" AndAlso Folio_Valido(Atx, True)) Then
                MessageBox.Show(prmDescripcion + " Invalido", Atx.FindForm.Text, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Atx.SetTextBoxValue("")
                Atx.Focus()
                SendKeys.Flush()
                Return False
            End If
            Return True
        End Function

        Public Shared Function Valida_AtxAdvanced(ByVal Atx As AccTextBoxAdvanced, Optional ByVal prmDescripcion As String = "") As Boolean
            If Not (Atx.Text <> "" AndAlso Folio_Valido(Atx, True)) Then
                MessageBox.Show(prmDescripcion + " Invalido", Atx.FindForm.Text, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Atx.SetTextBoxValue("")
                Atx.Focus()
                SendKeys.Flush()
                Return False
            End If
            Return True
        End Function

#Region "Función de Numeros a Letras"

        Public Shared numeros(103) As String
        Public Shared letras As String

        Public Shared Function AgregaSeparadorDeDirectorio(ByVal prmRuta As String) As String
            AgregaSeparadorDeDirectorio = prmRuta & IIf(prmRuta.EndsWith("\"), "", "\")
        End Function

        '<summary>
        ' Metodo para exportar los datos del Grid a un archivo de Excel.
        ' </summary>
        ' <returns>Informacion de exito o fracaso</returns>
        'Public Shared Function ExportaExcel(ByVal fpGrid As FarPoint.Win.Spread.FpSpread, Optional ByVal NombreArchivo As String = "") As Boolean
        '    Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        '    Dim miRuta As String = DAO.ParametroAdministradoObtener("PRM", "RUTA_REPORTES")
        '    If Not System.IO.Directory.Exists(miRuta) Then System.IO.Directory.CreateDirectory(miRuta)
        '    Dim SaveFile As New SaveFileDialog
        '    SaveFile.DefaultExt = "xls"
        '    SaveFile.Filter = "Excel | *.xls"
        '    SaveFile.Title = GlobalSistemaCaption
        '    SaveFile.AddExtension = True
        '    If NombreArchivo.Trim <> "" Then SaveFile.FileName = AgregaSeparadorDeDirectorio(miRuta) & NombreArchivo
        '    SaveFile.InitialDirectory = miRuta
        '    If SaveFile.ShowDialog = DialogResult.OK Then
        '        Try
        '            fpGrid.SaveExcel(SaveFile.FileName, FarPoint.Win.Spread.Model.IncludeHeaders.BothCustomOnly)
        '            Return True
        '        Catch ex As Exception
        '            MessageBox.Show("Error al intentar exportar a Excel :" & ex.Message, GlobalSistemaCaption, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        End Try
        '    End If
        '    Return False
        'End Function

        Public Shared Function Centenas(ByVal VCentena As Double) As String
            If VCentena = 1 Then
                Centenas = numeros(100)
            Else
                If VCentena = 5 Then
                    Centenas = numeros(101)
                Else
                    If VCentena = 7 Then
                        'Centenas = letras & numeros(102)
                        Centenas = numeros(102)
                    Else
                        If VCentena = 9 Then
                            'Centenas = letras & numeros(103)
                            Centenas = numeros(103)
                        Else
                            Centenas = numeros(VCentena)
                        End If
                    End If
                End If
            End If
        End Function

        Public Shared Function Unidades(ByVal VUnidad As Double) As String
            Unidades = numeros(VUnidad)
        End Function

        Public Shared Function Decenas(ByVal VDecena As Double) As String
            Decenas = numeros(VDecena)
        End Function

        Public Shared Sub inicializa()
            numeros(0) = "cero"
            numeros(1) = "un"
            numeros(2) = "dos"
            numeros(3) = "tres"
            numeros(4) = "cuatro"
            numeros(5) = "cinco"
            numeros(6) = "seis"
            numeros(7) = "siete"
            numeros(8) = "ocho"
            numeros(9) = "nueve"
            numeros(10) = "diez"
            numeros(11) = "once"
            numeros(12) = "doce"
            numeros(13) = "trece"
            numeros(14) = "catorce"
            numeros(15) = "quince"
            numeros(20) = "veinte"
            numeros(30) = "treinta"
            numeros(40) = "cuarenta"
            numeros(50) = "cincuenta"
            numeros(60) = "sesenta"
            numeros(70) = "setenta"
            numeros(80) = "ochenta"
            numeros(90) = "noventa"
            numeros(100) = "ciento"
            numeros(101) = "quinientos"
            numeros(102) = "setecientos"
            numeros(103) = "novecientos"
        End Sub

        Public Shared Function MesALetras(ByVal fecha As DateTime) As String
            Select Case fecha.Month
                Case 1
                    MesALetras = "Enero"
                Case 2
                    MesALetras = "Febreo"
                Case 3
                    MesALetras = "Marzo"
                Case 4
                    MesALetras = "Abril"
                Case 5
                    MesALetras = "Mayo"
                Case 6
                    MesALetras = "Junio"
                Case 7
                    MesALetras = "Julio"
                Case 8
                    MesALetras = "Agosto"
                Case 9
                    MesALetras = "Septiembre"
                Case 10
                    MesALetras = "Octubre"
                Case 11
                    MesALetras = "Noviembre"
                Case 12
                    MesALetras = "Diciembre"
                Case Else
                    MesALetras = "Err"
            End Select
        End Function

        Public Shared Function NumerosALetras(ByVal Numero As Double, ByVal Descripcion As String, ByVal abreviacion As String) As String

            Dim Decimales As Double

            Decimales = Numero - Int(Numero)
            Numero = Int(Numero)
            inicializa()

            letras = ""
            Do
                '*---> Validación si se pasa de 100 millones
                If Numero >= 1000000000 Then
                    letras = "Error en Conversión a Letras"
                    Numero = 0
                    Decimales = 0
                End If

                '*---> Centenas de Millón
                If (Numero < 1000000000) And (Numero >= 100000000) Then
                    If (Int(Numero / 100000000) = 1) And ((Numero - (Int(Numero / 100000000) * 100000000)) < 1000000) Then
                        letras = letras & "cien millones "
                    Else
                        letras = letras & Centenas(Int(Numero / 100000000))
                        If (Int(Numero / 100000000) <> 1) And (Int(Numero / 100000000) <> 5) And (Int(Numero / 100000000) <> 7) And (Int(Numero / 100000000) <> 9) Then
                            letras = letras & "cientos "
                        Else
                            letras = letras & " "
                        End If
                    End If
                    Numero = Numero - (Int(Numero / 100000000) * 100000000)
                End If

                '*---> Decenas de Millón
                If (Numero < 100000000) And (Numero >= 10000000) Then
                    If Int(Numero / 1000000) < 16 Then
                        letras = letras & Decenas(Int(Numero / 1000000))
                        letras = letras & " millones "
                        Numero = Numero - (Int(Numero / 1000000) * 1000000)
                    Else
                        letras = letras & Decenas(Int(Numero / 10000000) * 10)
                        Numero = Numero - (Int(Numero / 10000000) * 10000000)
                        If Numero > 1000000 Then
                            letras = letras & " y "
                        End If
                    End If
                End If

                '*---> Unidades de Millón
                If (Numero < 10000000) And (Numero >= 1000000) Then
                    If Int(Numero / 1000000) = 1 Then
                        letras = letras & " un millón "
                    Else
                        letras = letras & Unidades(Int(Numero / 1000000))
                        letras = letras & " millones "
                    End If
                    Numero = Numero - (Int(Numero / 1000000) * 1000000)
                End If

                '*---> Centenas de Millar
                If (Numero < 1000000) And (Numero >= 100000) Then
                    If (Int(Numero / 100000) = 1) And ((Numero - (Int(Numero / 100000) * 100000)) < 1000) Then
                        letras = letras & "cien mil "
                    Else
                        letras = letras & Centenas(Int(Numero / 100000))
                        If (Int(Numero / 100000) <> 1) And (Int(Numero / 100000) <> 5) And (Int(Numero / 100000) <> 7) And (Int(Numero / 100000) <> 9) Then
                            letras = letras & "cientos "
                        Else
                            letras = letras & " "
                        End If
                    End If
                    Numero = Numero - (Int(Numero / 100000) * 100000)
                End If

                '*---> Decenas de Millar
                If (Numero < 100000) And (Numero >= 10000) Then
                    If Int(Numero / 1000) < 16 Then
                        letras = letras & Decenas(Int(Numero / 1000))
                        letras = letras & " mil "
                        Numero = Numero - (Int(Numero / 1000) * 1000)
                    Else
                        letras = letras & Decenas(Int(Numero / 10000) * 10)
                        Numero = Numero - (Int((Numero / 10000)) * 10000)
                        If Numero > 1000 Then
                            letras = letras & " y "
                        Else
                            letras = letras & " mil "
                        End If
                    End If
                End If

                '*---> Unidades de Millar
                If (Numero < 10000) And (Numero >= 1000) Then
                    If Int(Numero / 1000) = 1 Then
                        letras = letras & "un"
                    Else
                        letras = letras & Unidades(Int(Numero / 1000))
                    End If
                    letras = letras & " mil "
                    Numero = Numero - (Int(Numero / 1000) * 1000)
                End If

                '*---> Centenas
                If (Numero < 1000) And (Numero > 99) Then
                    If (Int(Numero / 100) = 1) And ((Numero - (Int(Numero / 100) * 100)) < 1) Then
                        letras = letras & "cien "
                    Else
                        letras = letras & Centenas(Int(Numero / 100))
                        If (Int(Numero / 100) <> 1) And (Int(Numero / 100) <> 5) And (Int(Numero / 100) <> 7) And (Int(Numero / 100) <> 9) Then
                            letras = letras & "cientos "
                        Else
                            letras = letras & " "
                        End If
                    End If
                    Numero = Numero - (Int(Numero / 100) * 100)

                End If

                '*---> Decenas
                If (Numero < 100) And (Numero > 9) Then
                    If Numero < 16 Then
                        letras = letras & Decenas(Int(Numero))
                        Numero = Numero - Int(Numero)
                    Else
                        letras = letras & Decenas(Int((Numero / 10)) * 10)
                        Numero = Numero - (Int((Numero / 10)) * 10)
                        If Numero > 0.99 Then
                            letras = letras & " y "
                        End If
                    End If
                End If

                '*---> Unidades
                If (Numero < 10) And (Numero > 0.99) Then
                    letras = letras & Unidades(Int(Numero))
                    Numero = Numero - Int(Numero)
                End If
            Loop Until (Numero = 0)

            '*---> Decimales
            If (Decimales > 0) Then
                letras = letras & " " & Descripcion & " con "
                letras = letras & Format(Decimales * 100, "00") & "/100 " & abreviacion
            ElseIf (Decimales = 0) Then
                letras = letras & " " & Descripcion & " " & abreviacion
                'Else
                '    If (letras <> "Error en Conversión a Letras") And (Len(Trim(letras)) > 0) Then
                '        Select Case Valor1
                '            Case True
                '                letras = letras & " exactos"
                '        End Select
                '    End If
            End If
            NumerosALetras = letras.ToUpper
            'Select Case Valor2
            '    Case True
            '        NumerosALetras = UCase(Left(letras, 1)) & Right(letras, Len(letras) - 1)
            'End Select
        End Function

        Public Shared Function NumerosALetras(ByVal Numero As Double) As String

            Dim Decimales As Double

            Decimales = Numero - Int(Numero)
            Numero = Int(Numero)
            inicializa()

            letras = ""
            Do
                '*---> Validación si se pasa de 100 millones
                If Numero >= 1000000000 Then
                    letras = "Error en Conversión a Letras"
                    Numero = 0
                    Decimales = 0
                End If

                '*---> Centenas de Millón
                If (Numero < 1000000000) And (Numero >= 100000000) Then
                    If (Int(Numero / 100000000) = 1) And ((Numero - (Int(Numero / 100000000) * 100000000)) < 1000000) Then
                        letras = letras & "cien millones "
                    Else
                        letras = letras & Centenas(Int(Numero / 100000000))
                        If (Int(Numero / 100000000) <> 1) And (Int(Numero / 100000000) <> 5) And (Int(Numero / 100000000) <> 7) And (Int(Numero / 100000000) <> 9) Then
                            letras = letras & "cientos "
                        Else
                            letras = letras & " "
                        End If
                    End If
                    Numero = Numero - (Int(Numero / 100000000) * 100000000)
                End If

                '*---> Decenas de Millón
                If (Numero < 100000000) And (Numero >= 10000000) Then
                    If Int(Numero / 1000000) < 16 Then
                        letras = letras & Decenas(Int(Numero / 1000000))
                        letras = letras & " millones "
                        Numero = Numero - (Int(Numero / 1000000) * 1000000)
                    Else
                        letras = letras & Decenas(Int(Numero / 10000000) * 10)
                        Numero = Numero - (Int(Numero / 10000000) * 10000000)
                        If Numero > 1000000 Then
                            letras = letras & " y "
                        End If
                    End If
                End If

                '*---> Unidades de Millón
                If (Numero < 10000000) And (Numero >= 1000000) Then
                    If Int(Numero / 1000000) = 1 Then
                        letras = letras & " un millón "
                    Else
                        letras = letras & Unidades(Int(Numero / 1000000))
                        letras = letras & " millones "
                    End If
                    Numero = Numero - (Int(Numero / 1000000) * 1000000)
                End If

                '*---> Centenas de Millar
                If (Numero < 1000000) And (Numero >= 100000) Then
                    If (Int(Numero / 100000) = 1) And ((Numero - (Int(Numero / 100000) * 100000)) < 1000) Then
                        letras = letras & "cien mil "
                    Else
                        letras = letras & Centenas(Int(Numero / 100000))
                        If (Int(Numero / 100000) <> 1) And (Int(Numero / 100000) <> 5) And (Int(Numero / 100000) <> 7) And (Int(Numero / 100000) <> 9) Then
                            letras = letras & "cientos "
                        Else
                            letras = letras & " "
                        End If
                    End If
                    Numero = Numero - (Int(Numero / 100000) * 100000)
                End If

                '*---> Decenas de Millar
                If (Numero < 100000) And (Numero >= 10000) Then
                    If Int(Numero / 1000) < 16 Then
                        letras = letras & Decenas(Int(Numero / 1000))
                        letras = letras & " mil "
                        Numero = Numero - (Int(Numero / 1000) * 1000)
                    Else
                        letras = letras & Decenas(Int(Numero / 10000) * 10)
                        Numero = Numero - (Int((Numero / 10000)) * 10000)
                        If Numero > 1000 Then
                            letras = letras & " y "
                        Else
                            letras = letras & " mil "
                        End If
                    End If
                End If

                '*---> Unidades de Millar
                If (Numero < 10000) And (Numero >= 1000) Then
                    If Int(Numero / 1000) = 1 Then
                        letras = letras & "un"
                    Else
                        letras = letras & Unidades(Int(Numero / 1000))
                    End If
                    letras = letras & " mil "
                    Numero = Numero - (Int(Numero / 1000) * 1000)
                End If

                '*---> Centenas
                If (Numero < 1000) And (Numero > 99) Then
                    If (Int(Numero / 100) = 1) And ((Numero - (Int(Numero / 100) * 100)) < 1) Then
                        letras = letras & "cien "
                    Else
                        letras = letras & Centenas(Int(Numero / 100))
                        If (Int(Numero / 100) <> 1) And (Int(Numero / 100) <> 5) And (Int(Numero / 100) <> 7) And (Int(Numero / 100) <> 9) Then
                            letras = letras & "cientos "
                        Else
                            letras = letras & " "
                        End If
                    End If
                    Numero = Numero - (Int(Numero / 100) * 100)

                End If

                '*---> Decenas
                If (Numero < 100) And (Numero > 9) Then
                    If Numero < 16 Then
                        letras = letras & Decenas(Int(Numero))
                        Numero = Numero - Int(Numero)
                    Else
                        letras = letras & Decenas(Int((Numero / 10)) * 10)
                        Numero = Numero - (Int((Numero / 10)) * 10)
                        If Numero > 0.99 Then
                            letras = letras & " y "
                        End If
                    End If
                End If

                '*---> Unidades
                If (Numero < 10) And (Numero > 0.99) Then
                    letras = letras & Unidades(Int(Numero))
                    Numero = Numero - Int(Numero)
                End If
            Loop Until (Numero = 0)

            '*---> Decimales
            'If (Decimales > 0) Then
            '    letras = letras & " " & prmMoneda.Descripcion & " con "
            '    letras = letras & Format(Decimales * 100, "00") & "/100 " & prmMoneda.Abreviacion
            'ElseIf (Decimales = 0) Then
            '    letras = letras & " " & prmMoneda.Descripcion & " " & prmMoneda.Abreviacion
            '    'Else
            '    '    If (letras <> "Error en Conversión a Letras") And (Len(Trim(letras)) > 0) Then
            '    '        Select Case Valor1
            '    '            Case True
            '    '                letras = letras & " exactos"
            '    '        End Select
            '    '    End If
            'End If
            NumerosALetras = letras.ToUpper
            'Select Case Valor2
            '    Case True
            '        NumerosALetras = UCase(Left(letras, 1)) & Right(letras, Len(letras) - 1)
            'End Select
        End Function



        Public Shared Function NumerosALetras(ByVal Numero As Double, ByVal Valor1 As Boolean, ByVal Valor2 As Boolean) As String

            Dim Decimales As Double

            Decimales = Numero - Int(Numero)
            Numero = Int(Numero)
            Inicializar()

            letras = ""
            Do
                '*---> Validación si se pasa de 100 millones
                If Numero >= 1000000000 Then
                    letras = "Error en Conversión a Letras"
                    Numero = 0
                    Decimales = 0
                End If

                '*---> Centenas de Millón
                If (Numero < 1000000000) And (Numero >= 100000000) Then
                    If (Int(Numero / 100000000) = 1) And ((Numero - (Int(Numero / 100000000) * 100000000)) < 1000000) Then
                        letras = letras & "cien millones "
                    Else
                        letras = letras & Centenas(Int(Numero / 100000000))
                        If (Int(Numero / 100000000) <> 1) And (Int(Numero / 100000000) <> 5) And (Int(Numero / 100000000) <> 7) And (Int(Numero / 100000000) <> 9) Then
                            letras = letras & "cientos "
                        Else
                            letras = letras & " "
                        End If
                    End If
                    Numero = Numero - (Int(Numero / 100000000) * 100000000)
                End If

                '*---> Decenas de Millón
                If (Numero < 100000000) And (Numero >= 10000000) Then
                    If Int(Numero / 1000000) < 16 Then
                        letras = letras & Decenas(Int(Numero / 1000000))
                        letras = letras & " millones "
                        Numero = Numero - (Int(Numero / 1000000) * 1000000)
                    Else
                        letras = letras & Decenas(Int(Numero / 10000000) * 10)
                        Numero = Numero - (Int(Numero / 10000000) * 10000000)
                        If Numero > 1000000 Then
                            letras = letras & " y "
                        End If
                    End If
                End If

                '*---> Unidades de Millón
                If (Numero < 10000000) And (Numero >= 1000000) Then
                    If Int(Numero / 1000000) = 1 Then
                        letras = letras & " un millón "
                    Else
                        letras = letras & Unidades(Int(Numero / 1000000))
                        letras = letras & " millones "
                    End If
                    Numero = Numero - (Int(Numero / 1000000) * 1000000)
                End If

                '*---> Centenas de Millar
                If (Numero < 1000000) And (Numero >= 100000) Then
                    If (Int(Numero / 100000) = 1) And ((Numero - (Int(Numero / 100000) * 100000)) < 1000) Then
                        letras = letras & "cien mil "
                    Else
                        letras = letras & Centenas(Int(Numero / 100000))
                        If (Int(Numero / 100000) <> 1) And (Int(Numero / 100000) <> 5) And (Int(Numero / 100000) <> 7) And (Int(Numero / 100000) <> 9) Then
                            letras = letras & "cientos "
                        Else
                            letras = letras & " "
                        End If
                    End If
                    Numero = Numero - (Int(Numero / 100000) * 100000)
                End If

                '*---> Decenas de Millar
                If (Numero < 100000) And (Numero >= 10000) Then
                    If Int(Numero / 1000) < 16 Then
                        letras = letras & Decenas(Int(Numero / 1000))
                        letras = letras & " mil "
                        Numero = Numero - (Int(Numero / 1000) * 1000)
                    Else
                        letras = letras & Decenas(Int(Numero / 10000) * 10)
                        Numero = Numero - (Int((Numero / 10000)) * 10000)
                        If Numero > 1000 Then
                            letras = letras & " y "
                        Else
                            letras = letras & " mil "
                        End If
                    End If
                End If

                '*---> Unidades de Millar
                If (Numero < 10000) And (Numero >= 1000) Then
                    If Int(Numero / 1000) = 1 Then
                        letras = letras & "un"
                    Else
                        letras = letras & Unidades(Int(Numero / 1000))
                    End If
                    letras = letras & " mil "
                    Numero = Numero - (Int(Numero / 1000) * 1000)
                End If

                '*---> Centenas
                If (Numero < 1000) And (Numero > 99) Then
                    If (Int(Numero / 100) = 1) And ((Numero - (Int(Numero / 100) * 100)) < 1) Then
                        letras = letras & "cien "
                    Else
                        letras = letras & Centenas(Int(Numero / 100))
                        If (Int(Numero / 100) <> 1) And (Int(Numero / 100) <> 5) And (Int(Numero / 100) <> 7) And (Int(Numero / 100) <> 9) Then
                            letras = letras & "cientos "
                        Else
                            letras = letras & " "
                        End If
                    End If
                    Numero = Numero - (Int(Numero / 100) * 100)

                End If

                '*---> Decenas
                If (Numero < 100) And (Numero > 9) Then
                    If Numero < 16 Then
                        letras = letras & Decenas(Int(Numero))
                        Numero = Numero - Int(Numero)
                    Else
                        letras = letras & Decenas(Int((Numero / 10)) * 10)
                        Numero = Numero - (Int((Numero / 10)) * 10)
                        If Numero > 0.99 Then
                            letras = letras & " y "
                        End If
                    End If
                End If

                '*---> Unidades
                If (Numero < 10) And (Numero > 0.99) Then
                    letras = letras & Unidades(Int(Numero))
                    Numero = Numero - Int(Numero)
                End If
            Loop Until (Numero = 0)

            '*---> Decimales
            If (Decimales > 0) Then
                letras = letras & " Pesos con "
                letras = letras & Format(Decimales * 100, "00") & "/100" & " M.N. "
            ElseIf (Decimales = 0) Then
                letras = letras & " Pesos M.N."
            Else
                If (letras <> "Error en Conversión a Letras") And (Len(Trim(letras)) > 0) Then
                    Select Case Valor1
                        Case True
                            letras = letras & " exactos"
                    End Select
                End If
            End If
            NumerosALetras = letras
            Select Case Valor2
                Case True
                    NumerosALetras = UCase(Left(letras, 1)) & Right(letras, Len(letras) - 1)
            End Select
        End Function

#End Region

        Public Shared Sub CargarCursorArena(ByVal prmForma As System.Windows.Forms.Form)
            prmForma.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        End Sub

        Public Shared Sub QuitarCursorArena(ByVal prmForma As System.Windows.Forms.Form)
            prmForma.Cursor.Current = System.Windows.Forms.Cursors.Default
        End Sub

        Public Shared Sub Mensaje_DatosIncompletos(Optional ByVal prmMensaje As String = "")
            prmMensaje = "Falta proporcionar " & prmMensaje
            MessageBox.Show(prmMensaje, GlobalSistemaCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Sub

#Region " RFC "

        Public Shared Function ValidaFechaRFC(ByVal PrmStringFecha As String) As Boolean
            Dim vStringErrorMsg As String
            Dim vDia As Decimal = Decimal.Parse(PrmStringFecha.Substring(4, 2))
            If vDia = 0 Then vStringErrorMsg = "Los dígitos de DÍA deben estar entre 01 y 31"

            Dim vMes As Decimal = Decimal.Parse(PrmStringFecha.Substring(2, 2))
            If vMes < 1 Or vMes > 12 Then
                If Not IsNothing(vStringErrorMsg) Then
                    vStringErrorMsg = vStringErrorMsg & ", "
                Else
                    vStringErrorMsg = ""
                End If
                vStringErrorMsg = vStringErrorMsg & "Los dígitos de MES deben estar entre 01 y 12"
            End If

            If Not IsNothing(vStringErrorMsg) Then
                vStringErrorMsg = "Error de fecha en RFC: " & vStringErrorMsg
                System.Windows.Forms.MessageBox.Show(vStringErrorMsg, "FarmaCon")
                Return False
            End If

            'Evaluar si el mes es de 31 días
            If vMes > 7 Then vMes = vMes + 1
            '--> se incrementa la paridad de Agosto en adelante
            '    para que todos los de 31 días sean impares por igual

            If vMes Mod 2 Then 'quiere decir que es impar (residuo diferente de Cero)
                If vDia > 31 Then
                    vStringErrorMsg = "Los dígitos de DÍA deben estar entre 01 y 31"
                End If
            ElseIf vMes = 2 Then
                Dim vYear As Decimal = Decimal.Parse(PrmStringFecha.Substring(0, 2))

                If vYear Mod 4 Then 'NO es año bisiesto porque hay residuo sobre 4
                    If vDia > 28 Then vStringErrorMsg = vYear.ToString() & " NO es Año Bisiesto, Febrero no puede tener más de 28 días"
                Else
                    If vDia > 29 Then vStringErrorMsg = vYear.ToString() & " es Año Bisiesto, Febrero no puede tener más de 29 días"
                End If
            Else 'meses pares mayores que 2 (febrero)
                If vMes > 7 Then 'se reestablece el número de més correcto
                    vMes = vMes - 1
                End If
                If vDia > 30 Then vStringErrorMsg = "El mes número " & vMes.ToString() & " no puede tener más de 30 días"
            End If

            If Not IsNothing(vStringErrorMsg) Then
                vStringErrorMsg = "Error de fecha en RFC: " & vStringErrorMsg
                System.Windows.Forms.MessageBox.Show(vStringErrorMsg, "FarmaCon")
                Return False
            End If

            Return True

        End Function

#End Region

        Public Enum ETipoMensaje
            Guardar
            Borrar
            ErrorGuardar
            ErrorBorrar
            BorrarRenglon
        End Enum

        Public Shared Sub Mensaje_GuardarBorrar(ByVal Tipo As ETipoMensaje, Optional ByVal Folio As Integer = 0)
            Dim miMensaje As String
            Dim miIcono As MessageBoxIcon = MessageBoxIcon.Information
            Select Case Tipo
                Case ETipoMensaje.Borrar
                    miMensaje = "Registro cancelado exitosamente"
                Case ETipoMensaje.Guardar
                    miMensaje = "Datos guardados con éxito"
                    If Folio > 0 Then
                        miMensaje &= " con folio '" & Folio.ToString & "'"
                    End If
                Case ETipoMensaje.ErrorBorrar
                    miMensaje = "Error al intentar cancelar el registro! "
                Case ETipoMensaje.ErrorGuardar
                    miMensaje = "Error al intentar guardar el registro! "
            End Select
            MessageBox.Show(miMensaje, GlobalSistemaCaption, MessageBoxButtons.OK, miIcono)
        End Sub

        Public Enum ETipoErrorCatalogos
            ElementoInvalido
            DatosRelacionados
            CodigoInvalido
        End Enum

        Public Shared Sub Mensaje_ErrorCatalogos(ByVal Tipo As ETipoErrorCatalogos)
            Dim miMensaje As String
            Select Case Tipo
                Case ETipoErrorCatalogos.ElementoInvalido
                    miMensaje = "No se puede cancelar. Elemento no válido."
                Case ETipoErrorCatalogos.DatosRelacionados
                    miMensaje = "No se puede cancelar. Datos relacionados."
                Case ETipoErrorCatalogos.CodigoInvalido
                    miMensaje = "Código inválido."
            End Select
            MessageBox.Show(miMensaje, GlobalSistemaCaption, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Sub

        Public Shared Function DescripcionRepetida(ByRef prmDAO As DataAccessCls, ByVal prmNombreTabla As String, ByRef prmControlDescripcion As System.Windows.Forms.Control) As Boolean
            Dim vSql As String = "SELECT cDescripcion FROM " & prmNombreTabla & " (NoLock) WHERE RTrim(cDescripcion)='" & prmControlDescripcion.Text.Trim() & "'"
            Return prmDAO.ExistenDatosEnConsultaSQL(vSql)
        End Function

        Public Shared Function DescripcionRepetida(ByRef prmDAO As DataAccessCls, ByVal prmNombreTabla As String, ByVal prmNombre_ColumnaPadre As String, ByRef prmControlDescripcion As System.Windows.Forms.Control, ByRef prmControl_CvePadre As System.Windows.Forms.Control) As Boolean
            Dim dtTabla As New Data.DataTable
            Dim vQuery As String = _
                       "SELECT cDescripcion FROM " & prmNombreTabla _
                     & " WHERE " & prmNombre_ColumnaPadre & " = " _
                     & prmControl_CvePadre.Text.Trim() _
                     & " AND rtrim(cDescripcion)='" _
                     & prmControlDescripcion.Text.Trim() & "'"
            prmDAO.RegresaConsultaSQL(vQuery, dtTabla)

            If dtTabla.Rows.Count > 0 Then Return True
            Return False
        End Function

        'quita el signo y redondea a 2 decimales si es valor numérico
        'si no es valor numérico recupera el valor original de la cadena
        Public Shared Sub ValidaDescuento(ByRef prmStringDescuento As String, ByVal prmStringRecupera As String)
            ValidaPositivo(prmStringDescuento, prmStringRecupera, 2)
        End Sub
        Public Shared Sub ValidaPositivo(ByRef prmStringNumero As String, ByVal prmStringRecupera As String)
            ValidaPositivo(prmStringNumero, prmStringRecupera, 0)
        End Sub
        Public Shared Sub ValidaPositivo(ByRef prmStringNumero As String, ByVal prmStringRecupera As String, ByVal prmRound As Short)
            If IsNumeric(prmStringNumero) Then
                prmStringNumero = Math.Round(Math.Abs(Decimal.Parse(prmStringNumero)), prmRound)
            Else
                prmStringNumero = prmStringRecupera
            End If
        End Sub

        Public Shared Function ValorValido_Personalizado(ByRef prmAccTextBoxAdvanced As AccTextBoxAdvanced) As Boolean
            '-> El asterisco "*" y la cadena vacía "" se validan primero,
            '   porque el .ValorValido los acepta
            With prmAccTextBoxAdvanced
                If .Text.Trim() = "*" Or .Text.Trim() = "" Then Return False
                Return .ValorValido
            End With
        End Function
        Public Shared Function FiltroCorrecto(ByRef prmAccTextBoxAdvanced As AccTextBoxAdvanced) As Boolean
            '-> Para cuando se va a conctenar en un filtro de un Query
            '   el valor debe ser numérico o nada
            With prmAccTextBoxAdvanced
                If .Text.Trim() = "" Then Return True ' vacío es válido, NO HAY FILTRO
                If .Text.Trim() <> "*" Then Return .ValorValido
                Return False ' Todo lo demás no es válido en un Query
            End With
        End Function

        Public Shared Function OnlyIntNumers() As String
            Return "0123456789" + Chr(13) + Chr(8)
        End Function

        Public Shared Function OnlyFloatNumers() As String
            Return "." + OnlyIntNumers()
        End Function

        Public Shared Function OnlyChars() As String
            Return "ABCDEFGHIJKLMNOPQRSTUVWXYZ" + Chr(13) + Chr(8)
        End Function

        Public Shared Function OnlyAlphaNumeric() As String
            Return OnlyFloatNumers().ToCharArray + OnlyChars().ToCharArray
        End Function

        'Public Shared Function Configura_Grid_Descuentos_Proveedor(ByVal prmGrid As FarPoint.Win.Spread.FpSpread, ByVal prmProveedor As Int32, ByVal prmColInicial As Int16) As Int16
        '    'Sistema       :Farmcon
        '    'Modulo        :General
        '    'Procedimiento :Configura_Grid_Descuentos_Proveedor
        '    'Desarrolo     : O.C.M. AS Em
        '    'Fecha         :21-Ene-2006
        '    'Que hace      : Dado un grid, proveedor y columnas inicail y fina... 
        '    '                Se Insertan los descuentos que maneja proveedor Siendo El De Oferta Como Primero, Siguiendole El Financiero y asi consecutivamente los demas.


        '    Dim vSql As String
        '    Dim dtDescuentos As New DataTable

        '    vSql = "Select nProveedor, nDescuento, cDescripcion From Ctl_Proveedores_Descuentos (NoLock) Where nProveedor = " & prmProveedor.ToString + " Order By  nDescuento Asc"
        '    DAO.RegresaConsultaSQL(vSql, dtDescuentos)
        '    Dim vColumnaInicial As Int16

        '    'Se Configura Grid De Articulos Proveedor
        '    With prmGrid.ActiveSheet
        '        vColumnaInicial = prmColInicial + 1
        '        .ActiveColumnIndex = -1
        '        .Columns.Remove(vColumnaInicial, prmGrid.Tag)

        '        prmGrid.Tag = dtDescuentos.Rows.Count

        '        If dtDescuentos.Rows.Count > 0 Then

        '            .Columns.Add(vColumnaInicial, dtDescuentos.Rows.Count)
        '            Dim vSigColumna As Int16 = vColumnaInicial
        '            For Each drProvDesc As DataRow In dtDescuentos.Rows
        '                .ColumnHeader.Cells(1, vSigColumna).Note = drProvDesc("cDescripcion")
        '                .ColumnHeader.Cells(1, vSigColumna).Text = Microsoft.VisualBasic.Left(drProvDesc("cDescripcion"), 5) + "."
        '                Dim vCellPorcent As New FarPoint.Win.Spread.CellType.PercentCellType
        '                vCellPorcent.MinimumValue = 0
        '                vCellPorcent.MaximumValue = 1
        '                .Columns(vSigColumna).CellType = vCellPorcent
        '                vSigColumna += 1
        '            Next

        '            .ColumnHeader.Cells(0, vColumnaInicial).Text = "% De Desc. Normal"
        '            .ColumnHeader.Cells(0, vColumnaInicial).ColumnSpan = dtDescuentos.Rows.Count

        '        End If

        '        Return dtDescuentos.Rows.Count
        '    End With
        'End Function

        'Public Shared Function RegresaValoresDeTabla(ByVal prmTabla As DataTable, ByVal prmCampo As String) As String
        '    RegresaValoresDeTabla = ""
        '    Dim vDato As New ClsValidaDatoRepetidoGrid

        '    Dim bPrimeraIteracion As Boolean = True
        '    For Each vRow As DataRow In prmTabla.Rows

        '        If Not (vRow(prmCampo) Is DBNull.Value) Then
        '            If Not vDato.ExisteDato(vRow(prmCampo)) Then
        '                If bPrimeraIteracion Then
        '                    RegresaValoresDeTabla = vRow(prmCampo)
        '                    bPrimeraIteracion = False
        '                Else
        '                    RegresaValoresDeTabla &= "," & vRow(prmCampo)
        '                End If

        '                vDato.AgregaDato(vRow(prmCampo))
        '            End If
        '        End If
        '    Next

        '    Return RegresaValoresDeTabla
        'End Function

        'Public Shared Function RegresaValoresDeRows(ByVal prmRows() As DataRow, ByVal prmCampo As String) As String
        '    RegresaValoresDeRows = ""
        '    Dim vDato As New ClsValidaDatoRepetidoGrid
        '    Dim bPrimeraIteracion As Boolean = True
        '    For x As Integer = 0 To prmRows.Length - 1

        '        If Not (prmRows(x)(prmCampo) Is DBNull.Value) Then
        '            If Not vDato.ExisteDato(prmRows(x)(prmCampo)) Then
        '                If bPrimeraIteracion Then
        '                    RegresaValoresDeRows = prmRows(x)(prmCampo)
        '                    bPrimeraIteracion = False
        '                Else
        '                    RegresaValoresDeRows &= "," & prmRows(x)(prmCampo)
        '                End If

        '                vDato.AgregaDato(prmRows(x)(prmCampo))
        '            End If
        '        End If
        '    Next

        '    Return RegresaValoresDeRows
        'End Function

        Public Shared Function EjecutaComandoEnDBF(ByVal prmSQLText As String, ByVal prmPathDBF As String) As Boolean
            Dim vConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + prmPathDBF + ";Extended Properties=DBASE IV;"
            Dim vCnn As OleDb.OleDbConnection

            vCnn = New OleDb.OleDbConnection(vConnectionString)
            Try
                vCnn.Open()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                Return False
            End Try


            Dim vCommand As New OleDb.OleDbCommand(prmSQLText, vCnn)
            Try
                vCommand.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                vCnn.Close()
                vCnn.Dispose()
                vCommand.Dispose()
                Return False
            End Try

            vCnn.Close()
            vCnn.Dispose()
            vCommand.Dispose()

            Return True
        End Function

        Public Shared Function ValorBoleanoEnFormatoSQLString(ByVal prmValor As Boolean) As String
            If prmValor = True Then
                Return "1"
            Else
                Return "0"
            End If
        End Function

        Public Shared Function ComprimeListaArchivos(ByVal prmNombreArchivoComprimidoConRuta As String, ByVal prmNombreListaDeArchivosAComprimirConRuta As String) As Boolean
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vCompresor As String = DAO.ParametroAdministradoObtener("CMP", "Compresor")
            Dim vInstruccion As String = vCompresor & " a " & prmNombreArchivoComprimidoConRuta & " @" & prmNombreListaDeArchivosAComprimirConRuta
            Try
                Shell(vInstruccion)
            Catch ex As Exception
                System.Windows.Forms.MessageBox.Show(ex.Message, "Compresión de Archivos", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try

            Return True
        End Function

        Public Shared Function ComprimeArchivo(ByVal prmNombreArchivoComprimidoConRuta As String, ByVal prmNombreDeArchivosAComprimirConRuta As String) As Boolean
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vCompresor As String = DAO.ParametroAdministradoObtener("CMP", "Compresor")
            Dim vInstruccion As String = vCompresor & " a " & prmNombreArchivoComprimidoConRuta & " " & prmNombreDeArchivosAComprimirConRuta
            Try
                Shell(vInstruccion)
            Catch ex As Exception
                System.Windows.Forms.MessageBox.Show(ex.Message, "Compresión de Archivos", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try

            Return True
        End Function

        Public Shared Function DescomprimeArchivo(ByVal prmNombreArchivoConPath As String, Optional ByVal CREA_CARPETA As Boolean = False) As Boolean

            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vDesCompresor As String = DAO.ParametroAdministradoObtener("CMP", "DesCompresor")
            Dim vInstruccion As String = vDesCompresor & " e " & IIf(CREA_CARPETA, "-ad", "") & " -y " & prmNombreArchivoConPath & " " & ClsTools.ObtenPathArchivo(prmNombreArchivoConPath)
            Try
                Shell(vInstruccion)
            Catch ex As Exception
                System.Windows.Forms.MessageBox.Show(ex.Message, "Descompresión de Archivos", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try

            Return True
        End Function

        Public Shared Function ObtenPathArchivo(ByVal prmNombreArchivoConPath As String) As String
            Return (prmNombreArchivoConPath.Substring(0, prmNombreArchivoConPath.LastIndexOf("\") + 1))
        End Function

        Public Shared Function EjecutaBCP(ByVal prmQuery As String, ByVal prmNombreConRuta_ArchivoSalida As String, ByVal prmServidor As String, ByVal prmUsuario As String, ByVal prmContraseña As String) As Boolean
            Dim vInstruccion As String = "BCP " & prmQuery
            Try
                Shell(vInstruccion)
            Catch ex As Exception
                System.Windows.Forms.MessageBox.Show(ex.Message, "Compresión de Archivos", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try


        End Function

        Public Shared Function VPN_Primera(ByVal prmValor As String, ByVal Esprimera As Boolean) As String
            Return IIf(Esprimera, prmValor, " ," & prmValor)
        End Function

        Public Shared Function VPN_DefinicionCamposInsert(ByVal prmTabla As DataTable)
            Dim vCampos As String = "("
            Dim bPrimera As Boolean = True
            For Each vColumn As DataColumn In prmTabla.Columns
                vCampos &= VPN_Primera(vColumn.ColumnName, bPrimera)
                bPrimera = False
            Next
            vCampos &= ")"
            Return vCampos
        End Function

        Public Shared Function VPN_Regreasa_Valores_Insert(ByVal prmTabla As DataTable, ByVal prmRow As DataRow) As String
            Dim vValues As String = " VALUES ( "
            Dim bPrimeraIteracion As Boolean = True

            Dim bEsNull As Boolean

            For Each vColumn As DataColumn In prmTabla.Columns
                bEsNull = (prmRow(vColumn) Is DBNull.Value)

                If Not bEsNull Then
                    Select Case vColumn.DataType.ToString
                        Case "System.Boolean"
                            vValues &= VPN_Primera(ClsTools.ValorBoleanoEnFormatoSQLString(prmRow(vColumn)), bPrimeraIteracion)
                        Case "System.DateTime"
                            vValues &= VPN_Primera(("'" & ClsTools.FechaEnFormatoSqlString(prmRow(vColumn)) & "'"), bPrimeraIteracion)
                        Case "System.String"
                            vValues &= VPN_Primera(("'" & CStr(prmRow(vColumn)).Replace("'", "''") & "'"), bPrimeraIteracion)
                        Case Else
                            vValues &= VPN_Primera(prmRow(vColumn), bPrimeraIteracion)
                    End Select
                Else
                    vValues &= VPN_Primera("NULL", bPrimeraIteracion)
                End If

                bPrimeraIteracion = False


            Next
            vValues &= " )"
            Return vValues
        End Function


        Public Shared Sub VPN_RegresaHastaEncontrarArchivo(ByVal prmNombreArchivoConRutaYExtension As String)
            Dim bEncontrado As Boolean = False
            While Not bEncontrado
                Try
                    Dim TerminoComprimir As New IO.StreamReader(prmNombreArchivoConRutaYExtension)
                    bEncontrado = True
                    TerminoComprimir.Close()
                Catch ex As IO.IOException
                    bEncontrado = False
                End Try
            End While
        End Sub

        Public Shared Function TraduceTodasAsterisco(ByVal dtTodas As DataTable, ByVal prmPrimaryColumn As String) As String
            Dim vTodas As String = ""
            For Each drElemento As DataRow In dtTodas.Rows
                vTodas += (drElemento(prmPrimaryColumn) + ",")
            Next

            If vTodas <> "" Then
                vTodas = Microsoft.VisualBasic.Left(vTodas, vTodas.Length - 1)
            End If
            Return vTodas
        End Function

        'Public Shared Function Tamaño_CodigoDeBarras() As Short
        '    Return DAO.ParametroAdministradoObtener("INV", "NUMCHARMIN_CODIGOBARRAS")
        'End Function

        Public Shared Function FechaJuliana(ByVal prmNumeroJuliano As Integer) As Date
            Dim vFechaPivote As Date
            vFechaPivote = DateSerial(1900, 1, 1)
            Return DateAdd(DateInterval.Day, prmNumeroJuliano - 2415021, vFechaPivote)
        End Function

        Public Shared Function NumeroJuliano(ByVal prmFecha As Date) As Integer
            Dim vFechaPivote As Date
            vFechaPivote = DateSerial(1900, 1, 1)
            Dim vDiasTranscurridos As Integer
            vDiasTranscurridos = DateDiff(DateInterval.Day, vFechaPivote, prmFecha)
            Return 2415021 + vDiasTranscurridos
        End Function

        Public Shared Function NumeroJuliano_Panama_CodigosBarra(ByVal prmFecha As Date) As Integer
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            DAO.EjecutaComandoSQL("SET DATEFORMAT DMY")
            Dim vcSQL As String = "SET DATEFORMAT DMY " & vbCr
            vcSQL &= "SELECT dbo.ADSUM_NumeroJuliano_Panama_CodigosBarra(cast('" & prmFecha.Day & "-" & prmFecha.Month & "-" & prmFecha.Year & "' as varchar(10)))"
            Return DAO.RegresaDatoSQL(vcSQL)
            'Dim vDt As New DataTable
            'DAO.RegresaConsultaSQL(vcSQL, vDt)
            'If vDt Is Nothing OrElse vDt.Rows.Count = 0 Then Return 0
            'Return vDt.Rows(0)(0)
        End Function
        Public Shared Function FechaJuliana_Panama_CodigosBarra(ByVal prmFechaNumeroJuliano As Integer) As Date
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Return DAO.RegresaDatoSQL("SELECT dbo.ADSUM_FechaJuliana_Panama_CodigosBarra(" & prmFechaNumeroJuliano & ")")
        End Function

        Public Shared Function FechaSinHora(ByVal prmFecha As Date) As Date
            Dim vNumeroJuliano As Integer
            vNumeroJuliano = NumeroJuliano(prmFecha)
            Return FechaJuliana(vNumeroJuliano)
        End Function

        Public Shared Function FechaConHoraActual(ByVal prmFecha As Date) As Date
            Dim DAO As DataAccessCls, vdFecha As Date

            DAO = DataAccessCls.DevuelveInstancia
            vdFecha = DAO.RegresaFechaDelSistema
            Return CDate(FechaSinHora(prmFecha) & " " & fgPonceros(vdFecha.Hour, 2) & ":" & fgPonceros(vdFecha.Minute, 2) & ":" & fgPonceros(vdFecha.Second, 2) & "." & vdFecha.Millisecond)
        End Function

        Public Shared Function FechaEnFormatoSqlString(ByVal prmFecha As Date) As String
            Dim vFechaString As String
            vFechaString = Format(prmFecha, "yyyy-MM-dd")
            'vFechaString = Format(prmFecha, "dd-MM-yyyy")
            Return vFechaString
        End Function

        Public Shared Function FgDameHora(ByVal prmFecha As DateTime, Optional ByVal blnConAMPM As Boolean = False)
            Dim vStrFecha As String = ""
            If Not prmFecha = Nothing Then
                vStrFecha = prmFecha.Hour & ":" & IIf(prmFecha.Minute.ToString.Length = 1, "0" & prmFecha.Minute, prmFecha.Minute)
                If blnConAMPM Then
                    vStrFecha &= " " & prmFecha.ToString.Substring(prmFecha.ToString.Length - 4)
                End If
                Return vStrFecha
            Else
                Return vStrFecha
            End If
        End Function

        Public Shared Function FechaConHoraEnFormatoSqlString(ByVal prmFecha As Date) As String
            Dim vFechaString As String
            vFechaString = Format(prmFecha, "yyyy-MM-dd HH:mm:ss")
            Return vFechaString
        End Function

        Public Shared Function FechaSerialSqlString(ByVal prmFecha As Date) As String
            Dim vFechaString As String
            vFechaString = "dbo.Adsum_fechaSerial(" & prmFecha.Year.ToString.Trim & "," & prmFecha.Month.ToString.Trim & "," & prmFecha.Day.ToString.Trim & ")"
            vFechaString = Format(prmFecha, "dd-MM-yyyy HH:mm:ss")
            Return vFechaString
        End Function

        Public Shared Function BooleanToBitString(ByVal prmBoolean As Boolean) As String
            If prmBoolean Then
                Return "1"
            Else
                Return "0"
            End If
        End Function

        Public Shared Function HoraFormato24HR(ByVal prmFecha As Date) As String
            Dim vFechaString As String
            vFechaString = Format(prmFecha, "HH:mm:ss")
            Return vFechaString
        End Function

        Public Shared Function HoraFormato(ByVal prmFecha As Date) As String
            Dim vFechaString As String
            vFechaString = Format(prmFecha, "HH:mm tt")
            Return vFechaString
        End Function

        Public Shared Function HoraFormatoEntero(ByVal prmFecha As Date) As Integer
            Dim vFechaString As String

            vFechaString = Format(prmFecha, "HH:mm")
            vFechaString = Replace(vFechaString, ":", "")

            Return CInt(vFechaString)
        End Function

        Public Shared Function FechaNulla() As Date
            Dim vFechaNulla As Date = CDate("1900-01-01")
            Return vFechaNulla
        End Function

        Public Shared Function FechaEnFormaISO(ByVal prmFecha As Date) As String
            Return Format(prmFecha, "yyyyMMdd")
        End Function

        Public Shared Function FechaEnFormatoYYYYMMDD(ByVal prmFecha As Date) As String
            Return Format(prmFecha, "yyyy-MM-dd")
        End Function

        Public Shared Function FechaEnFormatoDDMMMYYYY(ByVal prmFecha As Date) As String
            Return Format(prmFecha, "dd/MMM/yyyy")
        End Function

        Public Shared Function FechaEnFormatoDDMMYYYY(ByVal prmFecha As Date) As String
            Return Format(prmFecha, "dd/MM/yyyy")
        End Function

        Public Shared Function FechaEnFormatoDDMMYY(ByVal prmFecha As Date) As String
            Return Format(prmFecha, "dd-MM-yy")
        End Function

        Public Shared Function FechaFormatoDDMMYYYY(ByVal prmFecha As Date) As String
            Return Format(prmFecha, "dd-MM-yyyy")
        End Function

        Public Shared Function fgFechaMediana(ByVal prmFecha As Date) As String
            Return Format(prmFecha, "dd-MMM-yy")
        End Function


        Public Shared Function FechaDeLaMaquina() As Date
            Return Date.Now
        End Function

        Public Shared Function FechaDelSistema() As Date
            'Dim DAO As DataAccessCls
            Dim vFechaDelSistema = DAO.RegresaFechaDelSistema
            Return vFechaDelSistema
        End Function

        Public Shared Function DiaSemana() As Integer
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim DiaEmpiezaSemana As Integer
            Dim dia As FirstDayOfWeek

            DiaEmpiezaSemana = DAO.ParametroAdministradoObtener("PRMSUC", "Dia_En_Que_Empieza_La_Semana")
            dia = DiaEmpiezaSemana
            Return DatePart(DateInterval.Weekday, FechaDelSistema, dia)
        End Function

        Public Shared Function NombreDiaSemana(ByVal prmFecha As Date) As String
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vnDia As Integer

            vnDia = DatePart(DateInterval.Weekday, prmFecha)
            Return DateAndTime.WeekdayName(vnDia)
        End Function

        Public Shared Function Semana_Actual(ByVal prmFecha As Date) As Integer
            'Regresa la semana del Año, dependiendo del parametro fecha
            Return DatePart(DateInterval.WeekOfYear, prmFecha)
        End Function

        Public Shared Function IfNull(ByVal prmValor As Object, ByVal prmValorOpcional As Object) As Object
            If prmValor Is DBNull.Value OrElse prmValor Is Nothing Then
                Return prmValorOpcional
            ElseIf prmValor.GetType Is GetType(Date) Then
                Return IIf(prmValor = Date.MinValue, prmValorOpcional, prmValor)
            Else
                Return prmValor
            End If

        End Function

        Public Shared Function IfVacio(ByVal prmValor As Object, ByVal prmValorOpcional As Object) As Object
            If prmValor Is Nothing Then Return prmValorOpcional
            If prmValor.ToString.Trim = "" Then
                Return prmValorOpcional
            End If
            Return prmValor
        End Function

        Private Shared atrNombreDeMaquina As String = Nothing
        Public Shared Function getNombreDeMaquina() As String
            If atrNombreDeMaquina Is Nothing Then
                Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
                atrNombreDeMaquina = DAO.RegresaDatoSQL("SELECT HOST_NAME()")
            End If
            Return atrNombreDeMaquina
        End Function

        Public Shared Function FormateaCadenaImprimir(ByVal prmCadena As String, ByVal prmEspacios As Integer) As String
            prmCadena = Microsoft.VisualBasic.Left(Microsoft.VisualBasic.RTrim(prmCadena), prmEspacios)
            prmCadena = prmCadena & Space(prmEspacios - Len(prmCadena))
            Return prmCadena
        End Function

        Public Shared Function FormateaNumeroImprimir(ByVal prmNumero As String, ByVal prmEspacios As Integer) As String
            Dim prmCadena As String
            prmCadena = Microsoft.VisualBasic.Right(Microsoft.VisualBasic.RTrim(prmNumero.ToString), prmEspacios)
            prmCadena = (Space(prmEspacios - Len(prmCadena)) & prmCadena)
            'prmCadena=
            Return prmCadena
        End Function

        Public Shared Sub pgBackColorAccTextBoxAdvanced(ByRef prmForma As AccessForm, ByVal prmColor As Color, Optional ByVal prmValidaTag As Boolean = False)

            For Each vControl As Control In prmForma.Controls
                If Not vControl.Name.Trim = "" Then
                    pgPintaBackControl(vControl, prmColor, prmValidaTag)
                End If
            Next
        End Sub

        Public Shared Sub pgPintaBackControl(ByRef prmControl As System.Windows.Forms.Control, ByVal prmColor As Color, ByRef prmValidaTag As Boolean)
            If (TypeOf prmControl Is AccTextBoxAdvanced) Or (TypeOf prmControl Is AccTextBoxAdvanced) Or (TypeOf prmControl Is System.Windows.Forms.TextBox) Then
                If prmValidaTag Then
                    If prmControl.Tag <> "" Then
                        prmControl.BackColor = prmColor
                    End If
                Else
                    prmControl.BackColor = prmColor
                End If
            Else
                If TypeOf prmControl Is System.Windows.Forms.GroupBox Then 'Recorremos Contenedor de controles
                    Dim vGroupBox As System.Windows.Forms.GroupBox = prmControl
                    For Each vControlInterno As System.Windows.Forms.Control In vGroupBox.Controls
                        pgPintaBackControl(vControlInterno, prmColor, prmValidaTag)
                    Next
                End If

                If TypeOf prmControl Is System.Windows.Forms.Panel Then 'Recorremos Contenedor de controles
                    Dim vPanel As System.Windows.Forms.Panel = prmControl
                    For Each vControlInterno As System.Windows.Forms.Control In vPanel.Controls
                        pgPintaBackControl(vControlInterno, prmColor, prmValidaTag)
                    Next
                End If
            End If
        End Sub

        Public Shared Sub pgTagEnBlanco(ByRef prmForma As AccessForm)
            For Each vControl As Control In prmForma.Controls
                If Not vControl.Name.Trim = "" Then
                    pgMarcaTagEnBlanco(vControl)
                End If
            Next
        End Sub

        Public Shared Sub pgMarcaTagEnBlanco(ByRef prmControl As System.Windows.Forms.Control)
            If (TypeOf prmControl Is AccTextBoxAdvanced) Or (TypeOf prmControl Is AccTextBoxAdvanced) Or (TypeOf prmControl Is System.Windows.Forms.TextBox) Then
                prmControl.Tag = ""
            Else
                If TypeOf prmControl Is System.Windows.Forms.GroupBox Then 'Recorremos Contenedor de controles
                    Dim vGroupBox As System.Windows.Forms.GroupBox = prmControl
                    For Each vControlInterno As System.Windows.Forms.Control In vGroupBox.Controls
                        pgMarcaTagEnBlanco(vControlInterno)
                    Next
                End If

                If TypeOf prmControl Is System.Windows.Forms.Panel Then 'Recorremos Contenedor de controles
                    Dim vPanel As System.Windows.Forms.Panel = prmControl
                    For Each vControlInterno As System.Windows.Forms.Control In vPanel.Controls
                        pgMarcaTagEnBlanco(vControlInterno)
                    Next
                End If
            End If
        End Sub


#Region "Limpia Formas"
        Public Shared Sub LimpiaForma(ByRef Forma As AccessForm)
            For Each cControl As Control In Forma.Controls
                If TypeOf cControl Is ComboBox Or TypeOf cControl Is TextBox Then
                    cControl.Text = ""
                End If
                If TypeOf cControl Is AccTextBoxAdvanced Then
                    CType(cControl, AccTextBoxAdvanced).SetTextBoxValue("")
                End If
                If TypeOf cControl Is CheckBox Then
                    CType(cControl, CheckBox).Checked = False
                End If
                If TypeOf cControl Is RadioButton Then
                    CType(cControl, RadioButton).Checked = False
                End If
                If TypeOf cControl Is GroupBox Then
                    ClsTools.LimpiaForma(CType(cControl, GroupBox))
                End If
                If TypeOf cControl Is Panel Then
                    ClsTools.LimpiaForma(CType(cControl, Panel))
                End If
                'If TypeOf cControl Is GzgControls.MyPanel Then
                '    ClsTools.LimpiaForma(CType(cControl, GzgControls.MyPanel))
                'End If
                If TypeOf cControl Is DateTimePicker Then
                    CType(cControl, DateTimePicker).MinDate = New DateTime(1800, 1, 1)
                    CType(cControl, DateTimePicker).MaxDate = DAO.RegresaFechaDelSistema.AddYears(100)
                    CType(cControl, DateTimePicker).Value = DAO.RegresaFechaDelSistema
                End If
                'If TypeOf cControl Is FarPoint.Win.Spread.FpSpread Then
                '    CType(cControl, FarPoint.Win.Spread.FpSpread).ActiveSheet.RowCount = 0
                'End If
                If TypeOf cControl Is CheckedListBox Then
                    For i As Integer = 0 To CType(cControl, CheckedListBox).Items.Count - 1
                        CType(cControl, CheckedListBox).SetItemChecked(i, False)
                    Next
                End If
                If TypeOf cControl Is TabControl Then
                    For Each vTab As TabPage In CType(cControl, TabControl).TabPages
                        ClsTools.LimpiaForma(vTab)
                    Next
                End If

            Next cControl
        End Sub
        Public Shared Sub LimpiaForma(ByRef Forma As GroupBox)
            For Each cControl As Control In Forma.Controls
                If TypeOf cControl Is ComboBox Or TypeOf cControl Is TextBox Then
                    cControl.Text = ""
                End If
                If TypeOf cControl Is AccTextBoxAdvanced Then
                    CType(cControl, AccTextBoxAdvanced).SetTextBoxValue("")
                End If
                If TypeOf cControl Is CheckBox Then
                    CType(cControl, CheckBox).Checked = False
                End If
                If TypeOf cControl Is RadioButton Then
                    CType(cControl, RadioButton).Checked = False
                End If
                If TypeOf cControl Is GroupBox Then
                    ClsTools.LimpiaForma(CType(cControl, GroupBox))
                End If
                If TypeOf cControl Is Panel Then
                    ClsTools.LimpiaForma(CType(cControl, Panel))
                End If
                'If TypeOf cControl Is GzgControls.MyPanel Then
                '    ClsTools.LimpiaForma(CType(cControl, GzgControls.MyPanel))
                'End If
                If TypeOf cControl Is DateTimePicker Then
                    CType(cControl, DateTimePicker).MinDate = New DateTime(1800, 1, 1)
                    CType(cControl, DateTimePicker).MaxDate = DAO.RegresaFechaDelSistema.AddYears(100)
                    CType(cControl, DateTimePicker).Value = DAO.RegresaFechaDelSistema
                End If
                'If TypeOf cControl Is FarPoint.Win.Spread.FpSpread Then
                '    CType(cControl, FarPoint.Win.Spread.FpSpread).ActiveSheet.RowCount = 0
                'End If
                If TypeOf cControl Is CheckedListBox Then
                    For i As Integer = 0 To CType(cControl, CheckedListBox).Items.Count - 1
                        CType(cControl, CheckedListBox).SetItemChecked(i, False)
                    Next
                End If

            Next cControl
        End Sub
        Public Shared Sub LimpiaForma(ByRef Forma As TabPage)
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            For Each cControl As Control In Forma.Controls
                If TypeOf cControl Is ComboBox Or TypeOf cControl Is TextBox Then
                    cControl.Text = ""
                End If
                If TypeOf cControl Is AccTextBoxAdvanced Then
                    CType(cControl, AccTextBoxAdvanced).SetTextBoxValue("")
                End If
                If TypeOf cControl Is CheckBox Then
                    CType(cControl, CheckBox).Checked = False
                End If
                If TypeOf cControl Is RadioButton Then
                    CType(cControl, RadioButton).Checked = False
                End If
                If TypeOf cControl Is GroupBox Then
                    ClsTools.LimpiaForma(CType(cControl, GroupBox))
                End If
                If TypeOf cControl Is Panel Then
                    ClsTools.LimpiaForma(CType(cControl, Panel))
                End If
                'If TypeOf cControl Is GzgControls.MyPanel Then
                '    ClsTools.LimpiaForma(CType(cControl, GzgControls.MyPanel))
                'End If
                If TypeOf cControl Is DateTimePicker Then
                    CType(cControl, DateTimePicker).MinDate = New DateTime(1800, 1, 1)
                    CType(cControl, DateTimePicker).MaxDate = DAO.RegresaFechaDelSistema.AddYears(100)
                    CType(cControl, DateTimePicker).Value = DAO.RegresaFechaDelSistema
                End If
                'If TypeOf cControl Is FarPoint.Win.Spread.FpSpread Then
                '    CType(cControl, FarPoint.Win.Spread.FpSpread).ActiveSheet.RowCount = 0
                'End If
                If TypeOf cControl Is CheckedListBox Then
                    For i As Integer = 0 To CType(cControl, CheckedListBox).Items.Count - 1
                        CType(cControl, CheckedListBox).SetItemChecked(i, False)
                    Next
                End If
                If TypeOf cControl Is TabControl Then
                    For Each vTab As TabPage In CType(cControl, TabControl).TabPages
                        ClsTools.LimpiaForma(vTab)
                    Next
                End If


            Next cControl
        End Sub
        Public Shared Sub LimpiaForma(ByRef Forma As Windows.Forms.Form)
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            For Each cControl As Control In Forma.Controls
                If TypeOf cControl Is ComboBox Or TypeOf cControl Is TextBox Then
                    cControl.Text = ""
                End If
                If TypeOf cControl Is AccTextBoxAdvanced Then
                    CType(cControl, AccTextBoxAdvanced).SetTextBoxValue("")
                End If
                If TypeOf cControl Is CheckBox Then
                    CType(cControl, CheckBox).Checked = False
                End If
                If TypeOf cControl Is RadioButton Then
                    CType(cControl, RadioButton).Checked = False
                End If
                If TypeOf cControl Is GroupBox Then
                    ClsTools.LimpiaForma(CType(cControl, GroupBox))
                End If
                If TypeOf cControl Is Panel Then
                    ClsTools.LimpiaForma(CType(cControl, Panel))
                End If
                'If TypeOf cControl Is GzgControls.MyPanel Then
                '    ClsTools.LimpiaForma(CType(cControl, GzgControls.MyPanel))
                'End If
                If TypeOf cControl Is DateTimePicker Then
                    CType(cControl, DateTimePicker).MinDate = New DateTime(1800, 1, 1)
                    CType(cControl, DateTimePicker).MaxDate = DAO.RegresaFechaDelSistema.AddYears(100)
                    CType(cControl, DateTimePicker).Value = DAO.RegresaFechaDelSistema
                End If
                'If TypeOf cControl Is FarPoint.Win.Spread.FpSpread Then
                '    CType(cControl, FarPoint.Win.Spread.FpSpread).ActiveSheet.RowCount = 0
                'End If
                If TypeOf cControl Is CheckedListBox Then
                    For i As Integer = 0 To CType(cControl, CheckedListBox).Items.Count - 1
                        CType(cControl, CheckedListBox).SetItemChecked(i, False)
                    Next
                End If
                If TypeOf cControl Is TabControl Then
                    For Each vTab As TabPage In CType(cControl, TabControl).TabPages
                        ClsTools.LimpiaForma(vTab)
                    Next
                End If


            Next cControl
        End Sub
        Public Shared Sub LimpiaForma(ByRef Forma As Panel)
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            For Each cControl As Control In Forma.Controls
                If TypeOf cControl Is ComboBox Or TypeOf cControl Is TextBox Then
                    cControl.Text = ""
                End If
                If TypeOf cControl Is AccTextBoxAdvanced Then
                    CType(cControl, AccTextBoxAdvanced).SetTextBoxValue("")
                End If
                If TypeOf cControl Is CheckBox Then
                    CType(cControl, CheckBox).Checked = False
                End If
                If TypeOf cControl Is RadioButton Then
                    CType(cControl, RadioButton).Checked = False
                End If
                If TypeOf cControl Is GroupBox Then
                    ClsTools.LimpiaForma(CType(cControl, GroupBox))
                End If
                'If TypeOf cControl Is GzgControls.MyPanel Then
                '    ClsTools.LimpiaForma(CType(cControl, GzgControls.MyPanel))
                'End If
                If TypeOf cControl Is DateTimePicker Then
                    CType(cControl, DateTimePicker).MinDate = New DateTime(1800, 1, 1)
                    CType(cControl, DateTimePicker).MaxDate = DAO.RegresaFechaDelSistema.AddYears(100)
                    CType(cControl, DateTimePicker).Value = DAO.RegresaFechaDelSistema
                End If
                'If TypeOf cControl Is FarPoint.Win.Spread.FpSpread Then
                '    CType(cControl, FarPoint.Win.Spread.FpSpread).ActiveSheet.RowCount = 0
                'End If
                If TypeOf cControl Is CheckedListBox Then
                    For i As Integer = 0 To CType(cControl, CheckedListBox).Items.Count - 1
                        CType(cControl, CheckedListBox).SetItemChecked(i, False)
                    Next
                End If
                If TypeOf cControl Is TabControl Then
                    For Each vTab As TabPage In CType(cControl, TabControl).TabPages
                        ClsTools.LimpiaForma(vTab)
                    Next
                End If


            Next cControl
        End Sub
        'Public Shared Sub LimpiaForma(ByRef Forma As GzgControls.MyPanel)
        '    Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        '    For Each cControl As Control In Forma.Controls
        '        If TypeOf cControl Is ComboBox Or TypeOf cControl Is TextBox Then
        '            cControl.Text = ""
        '        End If
        '        If TypeOf cControl Is AccTextBoxAdvanced Then
        '            CType(cControl, AccTextBoxAdvanced).SetTextBoxValue("")
        '        End If
        '        If TypeOf cControl Is CheckBox Then
        '            CType(cControl, CheckBox).Checked = False
        '        End If
        '        If TypeOf cControl Is RadioButton Then
        '            CType(cControl, RadioButton).Checked = False
        '        End If
        '        If TypeOf cControl Is GroupBox Then
        '            ClsTools.LimpiaForma(CType(cControl, GroupBox))
        '        End If
        '        If TypeOf cControl Is Panel Then
        '            ClsTools.LimpiaForma(CType(cControl, Panel))
        '        End If
        '        If TypeOf cControl Is DateTimePicker Then
        '            CType(cControl, DateTimePicker).MinDate = New DateTime(1800, 1, 1)
        '            CType(cControl, DateTimePicker).MaxDate = DAO.RegresaFechaDelSistema.AddYears(100)
        '            CType(cControl, DateTimePicker).Value = DAO.RegresaFechaDelSistema
        '        End If
        '        If TypeOf cControl Is FarPoint.Win.Spread.FpSpread Then
        '            CType(cControl, FarPoint.Win.Spread.FpSpread).ActiveSheet.RowCount = 0
        '        End If
        '        If TypeOf cControl Is CheckedListBox Then
        '            For i As Integer = 0 To CType(cControl, CheckedListBox).Items.Count - 1
        '                CType(cControl, CheckedListBox).SetItemChecked(i, False)
        '            Next
        '        End If
        '        If TypeOf cControl Is TabControl Then
        '            For Each vTab As TabPage In CType(cControl, TabControl).TabPages
        '                ClsTools.LimpiaForma(vTab)
        '            Next
        '        End If


        '    Next cControl
        'End Sub
#End Region

        Public Shared Sub copiaRows(ByVal r As DataRow, ByVal d As DataTable, ByVal reft As DataColumnCollection)
            d.Columns.Clear()
            For Each v As DataColumn In reft
                d.Columns.Add(v.ColumnName, v.DataType)
            Next
            d.BeginLoadData()
            d.LoadDataRow(r.ItemArray, False)
            d.EndLoadData()
        End Sub

        Public Shared Sub copiaRows(ByVal r As DataRow, ByVal d As DataTable)
            d.BeginLoadData()
            d.LoadDataRow(r.ItemArray, False)
            d.EndLoadData()
        End Sub

        Public Shared Sub copiaRows(ByVal r() As DataRow, ByVal d As DataTable)
            d.BeginLoadData()
            For Each v As DataRow In r
                d.LoadDataRow(v.ItemArray, False)
            Next
            d.EndLoadData()
        End Sub

        Public Shared Sub copiaRows(ByVal r() As DataRow, ByVal d As DataTable, ByVal reft As DataColumnCollection)
            d.Columns.Clear()
            For Each v As DataColumn In reft
                d.Columns.Add(v.ColumnName, v.DataType)
            Next
            d.BeginLoadData()
            For Each v As DataRow In r
                d.LoadDataRow(v.ItemArray, False)
            Next
            d.EndLoadData()
        End Sub

        Public Shared Function FlFormateaNumeroColor(ByVal prmNumero As Decimal) As String
            ''Es un número entero
            If prmNumero - CInt(prmNumero) = 0 Then
                Return CInt(prmNumero).ToString
            End If
            '********************************************************
            Dim vcNumero As String = prmNumero.ToString()
            Dim vnPosicionPunto As Integer = vcNumero.IndexOf(".")
            Dim vcParteEntera As String = vcNumero.Substring(0, vnPosicionPunto)
            Dim vcParteDecimal As String = vcNumero.Substring(vnPosicionPunto + 1)
            Dim vcNumeroDecimal As String = ""
            Dim i As Integer = vcParteDecimal.Length - 1
            While i >= 0
                If vcParteDecimal(i) > "0" Then Exit While
                i -= 1
            End While

            If i < 0 Then
                vcParteDecimal = ""
            End If

            If i >= 0 Then
                vcParteDecimal = vcParteDecimal.Trim.Substring(0, i + 1)
            End If

            If vcParteDecimal.Trim = "" Then Return vcParteEntera

            Return vcParteEntera & "." & vcParteDecimal
            ''Es un número entero
            'If prmNumero - CInt(prmNumero) = 0 Then
            '    Return CInt(prmNumero).ToString
            'End If

            ''No es un número entero
            'Dim vcNumero As String = prmNumero.ToString()
            'Dim vnPosicionPunto As Integer = vcNumero.IndexOf(".")
            'If vnPosicionPunto >= 0 Then
            '    Dim vnLongitud As Integer = vcNumero.Substring(vnPosicionPunto).Length
            '    Dim vcTemp As String = ""
            '    Dim i As Integer = vnLongitud
            '    While i > 0
            '        If vcNumero(i) > "0" Then Exit While
            '        i -= 1
            '    End While
            '    If i = 0 Then Return CInt(prmNumero).ToString
            '    If i > 0 Then
            '        vcTemp = vcNumero.Substring(0, i + 1)
            '        Return vcTemp
            '    End If
            'End If

        End Function
        '     Public Shared Function CopiaSkinDeGrid_YLoAplicaOtroGrid(ByVal prmGridConSkin As FarPoint.Win.Spread.FpSpread, _
        'ByVal prmGridAplicarselo As FarPoint.Win.Spread.FpSpread) As FarPoint.Win.Spread.FpSpread
        '         Dim vColor As Drawing.Color = prmGridAplicarselo.ActiveSheet.GrayAreaBackColor
        '         Dim Skin As FarPoint.Win.Spread.SheetSkin = prmGridConSkin.ActiveSheet.ActiveSkin
        '         Dim vskin As New FarPoint.Win.Spread.SheetSkin("TestSkin", Skin.BackColor, Skin.CellBackColor, Skin.CellForeColor, Skin.GridLineColor, _
        '          Skin.GridLines, Skin.HeaderBackColor, Skin.HeaderForeColor, Skin.SelectionBackColor, Skin.SelectionForeColor, Skin.EvenRowBackColor, Skin.OddRowBackColor, _
        '         False, False, True, True, True)
        '         vskin.Apply(prmGridAplicarselo)
        '         prmGridAplicarselo.ActiveSheet.GrayAreaBackColor = vColor
        '         Return prmGridAplicarselo
        '     End Function

        '     Public Shared Function CopiaSkinDeGrid_YLoAplicaOtroGrid(ByVal prmGridConSkin As FarPoint.Win.Spread.FpSpread, _
        'ByVal prmGridAplicarselo As FarPoint.Win.Spread.SheetView) As Boolean
        '         Dim vColor As Drawing.Color = prmGridAplicarselo.GrayAreaBackColor
        '         Dim Skin As FarPoint.Win.Spread.SheetSkin = prmGridConSkin.ActiveSheet.ActiveSkin
        '         Dim vskin As New FarPoint.Win.Spread.SheetSkin("TestSkin", Skin.BackColor, Skin.CellBackColor, Skin.CellForeColor, Skin.GridLineColor, _
        '          Skin.GridLines, Skin.HeaderBackColor, Skin.HeaderForeColor, Skin.SelectionBackColor, Skin.SelectionForeColor, Skin.EvenRowBackColor, Skin.OddRowBackColor, _
        '         False, False, True, True, True)
        '         vskin.Apply(prmGridAplicarselo)
        '         Return True
        '     End Function

        Public Shared Function DevuelveCuentaContableFormateada(ByVal prmValorCtaMayor As String, ByVal prmValorSubCta As String, ByVal prmValorSSubCta As String, ByVal prmValorSSSubCta As String, ByVal prmCuantosCtaMayor As Integer, ByVal prmCuantosSubCta As Integer, ByVal prmCuantosSSubCta As Integer, ByVal prmCuantosSSSubCta As Integer, ByVal prmLongitudCuenta As Integer) As String
            'Rellena de ceros la izquiereda na cadena
            Dim vValor1 As String = ""
            Dim vValor2 As String = ""
            Dim vValor3 As String = ""
            Dim vValor4 As String = ""
            Dim vValor As String = ""
            'Cuenta de Mayor
            vValor1 = RellenaConIzquierda(prmValorCtaMayor.ToString, prmCuantosCtaMayor, "0")
            If Val(vValor1) = 0 Then
                vValor1 = ""
            End If
            'SubCuenta
            vValor2 = RellenaConIzquierda(prmValorSubCta.ToString, prmCuantosSubCta, "0")
            If Val(vValor2) = 0 Then
                vValor2 = ""
            End If
            'SSubCuenta
            vValor3 = RellenaConIzquierda(prmValorSSubCta.ToString, prmCuantosSSubCta, "0")
            If Val(vValor3) = 0 Then
                vValor3 = ""
            End If
            'SSSubCuenta
            vValor4 = RellenaConIzquierda(prmValorSSSubCta.ToString, prmCuantosSSSubCta, "0")
            If Val(vValor4) = 0 Then
                vValor4 = ""
            End If

            vValor = vValor1.Trim + vValor2.Trim + vValor3.Trim + vValor4.Trim

            If Len(vValor) < prmLongitudCuenta Then
                vValor = RellenaConDerecha(vValor, prmLongitudCuenta, "0")
            End If

            Return vValor

        End Function

        Public Shared Function RellenaCeros(ByVal prmValor As Long, ByVal prmCuantos As Integer) As String
            'Rellena de ceros la izquiereda na cadena
            Dim vValor As String = ""
            For vCiclo As Integer = 0 To (prmCuantos - 1) - Len(prmValor.ToString)
                vValor &= "0"
            Next
            vValor &= Trim(Str(prmValor))
            If Val(vValor) = 0 Then
                vValor = ""
            End If
            Return vValor
        End Function

        Public Shared Function fgPonceros(ByVal prmValor As String, ByVal prmCuantos As Integer) As String
            'Rellena de ceros la izquiereda na cadena
            Dim vValor As String = ""
            For vCiclo As Integer = 0 To (prmCuantos - 1) - Len(prmValor.ToString)
                vValor &= "0"
            Next
            vValor &= Trim(prmValor.Trim)
            Return vValor
        End Function


        Public Shared Function RellenaConDerecha(ByVal prmValor As Object, ByVal prmNumeroCaracteres As Integer, ByVal prmRelleno As Char) As String
            RellenaConDerecha = Microsoft.VisualBasic.Left(prmValor & New String(prmRelleno, prmNumeroCaracteres), prmNumeroCaracteres)
        End Function
        Public Shared Function RellenaConIzquierda(ByVal prmValor As Object, ByVal prmNumeroCaracteres As Integer, ByVal prmRelleno As Char) As String
            RellenaConIzquierda = Microsoft.VisualBasic.Right(New String(prmRelleno, prmNumeroCaracteres) & prmValor, prmNumeroCaracteres)
        End Function
        Public Shared Function Redondear(ByVal prmValorARedondear As Double) As Double
            'Redondeo Desendente
            Return Math.Round(prmValorARedondear, 2)
        End Function
        Public Shared Function Redondear(ByVal prmValorARedondear As Double, ByVal prmACuantosDecimales As Integer) As Double
            'Redondeo Desendente
            Return Math.Round(prmValorARedondear, prmACuantosDecimales)
        End Function
        Public Shared Function Redondear(ByVal prmValorARedondear As Double, ByVal RedondeoBien As Boolean) As Double
            If RedondeoBien Then
                Return Math.Round(prmValorARedondear)
            Else
                Return IIf(prmValorARedondear Mod 1 > 0, CInt(prmValorARedondear) + 1, CInt(prmValorARedondear))
            End If

        End Function

        Public Shared Function ValidaControl(ByVal prmControl As Object, ByVal prmValorNumerico As Boolean, ByVal prmMensaje As String) As Boolean
            ValidaControl = True
            If prmControl.readonly Then Return ValidaControl

            'prmControl.backcolor = Color.White
            If prmValorNumerico Then
                If Val(prmControl.text) = 0 Then
                    '                    prmControl.backcolor = Color.Aqua
                    ValidaControl = False
                End If
            Else
                If Trim(prmControl.text) = "" Then
                    '                   prmControl.backcolor = Color.Aqua
                    ValidaControl = False
                End If
            End If

            If Not ValidaControl And prmMensaje.Trim <> "" Then MessageBox.Show(prmMensaje, "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Error)


            Return ValidaControl
        End Function


        'Public Shared Function FgValidaExistenciaProductoMarcaUnidadEnAlmacen(ByVal PrmClsProductoMarcaUnidad As Dominio.Productos.ClsProductoMarcaUnidad, ByVal PrmClsAlmacen As Dominio.Catalogos.ClsAlmacen, ByVal PrmCantidadSolicitada As Decimal, ByVal PrmCantidadPesoSolicitada As Decimal, Optional ByRef prmDisponibleUnidadBase As Decimal = -1) As Boolean
        '    'Elaboró:     L.I. César Octavio Niebla Manjarrez 
        '    'Fecha:       17-Enero-2007
        '    'Modulo:      Inventario            
        '    'Que Hace:    A partir de Un ProductoMarcaUnidad,Almacén,Cantidad y Peso, 
        '    '             Regresa Un valor Boleano Para inidicar Si Hay Suficiente Existencia ó no.
        '    '             Asi como tambien La Existencia Actual en Unidad Base prmDisponibleUnidadBase
        '    'Entrada:     Recibe 
        '    '               Objetos: ProductoMarcaUnidad y Almacén 
        '    '                        Cantidad y Peso
        '    'Salida:      Regresa Un valor Boleano Para inidicar Si Hay Suficiente Existencia ó no.
        '    '             Asi como tambien de Forma Opcional La Existencia Actual en Unidad Base prmDisponibleUnidadBase            

        '    Dim vlnValorAComparar As Decimal 'Este Valor Puede Ser tanto Peso Como Piezas...
        '    Dim vlnFactor As Decimal
        '    Dim VlnDisponibleUnidadBase As Decimal

        '    vlnFactor = PrmClsProductoMarcaUnidad.Equivalencia

        '    Dim ObjExistenciaProductoEnAlmacen As Dominio.Inventarios.ClsExistenciaProducto = Dominio.Inventarios.ClsFabricaInventarios.ObtenExistenciaProducto(PrmClsAlmacen, PrmClsProductoMarcaUnidad)

        '    'Piezas:
        '    If PrmClsProductoMarcaUnidad.Producto.TipoManejoInventario.EsPiezas Then
        '        vlnValorAComparar = PrmCantidadSolicitada * vlnFactor       ':Conversión a Unidad Base
        '    End If

        '    ''Peso/Peso y Piezas (no Estandar): checkamos por el peso

        '    'If PrmClsProductoMarcaUnidad.Producto.TipoManejoInventario.EsPeso Or PrmClsProductoMarcaUnidad.Producto.TipoManejoInventario.EsPesoYPiezas And Not PrmClsProductoMarcaUnidad.Producto.EsPesoEstandard Then
        '    '    vlnValorAComparar = PrmCantidadPesoSolicitada * vlnFactor   ':Conversión a Unidad Base
        '    'End If


        '    'Peso/Peso y Piezas (Estandar): Checkamos por las piezas y el peso 
        '    If PrmClsProductoMarcaUnidad.Producto.TipoManejoInventario.EsPeso Or PrmClsProductoMarcaUnidad.Producto.TipoManejoInventario.EsPesoYPiezas Then 'And PrmClsProductoMarcaUnidad.Producto.EsPesoEstandard Then
        '        'comparamos el peso

        '        VlnDisponibleUnidadBase = ObjExistenciaProductoEnAlmacen.Existencia

        '        vlnValorAComparar = PrmCantidadPesoSolicitada  ':Conversión a Unidad Base
        '        If VlnDisponibleUnidadBase < vlnValorAComparar Then ':Si lo Disponible es menor que lo Solicitado(vlnValorAComparar)
        '            prmDisponibleUnidadBase = VlnDisponibleUnidadBase
        '            Return False
        '        End If
        '        'comparamos las piezas
        '        VlnDisponibleUnidadBase = ObjExistenciaProductoEnAlmacen.Piezas

        '        vlnValorAComparar = PrmCantidadSolicitada * vlnFactor    ':Conversión a Unidad Base
        '        If VlnDisponibleUnidadBase < vlnValorAComparar Then ':Si lo Disponible es menor que lo Solicitado(vlnValorAComparar)
        '            prmDisponibleUnidadBase = VlnDisponibleUnidadBase
        '            Return False
        '        End If
        '        Return True
        '    End If


        '    VlnDisponibleUnidadBase = ObjExistenciaProductoEnAlmacen.Existencia


        '    If Not prmDisponibleUnidadBase = -1 Then
        '        prmDisponibleUnidadBase = VlnDisponibleUnidadBase
        '    End If

        '    If Int(vlnFactor) = 0 Then
        '        MsgBox("El factor de equivalencia del producto marca unidad es cero", MsgBoxStyle.Information, ClsTools.GlobalSistemaCaption)
        '        Return False
        '    End If

        '    If VlnDisponibleUnidadBase < vlnValorAComparar Then ':Si lo Disponible es menor que lo Solicitado(vlnValorAComparar)
        '        Return False
        '    End If

        '    Return True
        'End Function


        'Public Shared Function FgRegresa_ValorINVSETDB(ByVal prmProductoMarcaUnidad As Dominio.Productos.ClsProductoMarcaUnidad, ByVal prmCantidad As Double, ByVal prmPeso As Double, ByVal PrmRegresaPiezas As Boolean) As Double
        '    'Elaboró:     L.I. César Octavio Niebla Manjarrez 
        '    'Modulo:      Inventario
        '    'Nota:        Conversion para Almacenar en BD(SEGUN DEFINICION DE REGLAS DE DATOS A ALMACENAR PARA TABLAS DE MOVIMIENTOS)
        '    'Que Hace:    A partir de Un ProductoMarcaUnidad,Cantidad y Peso, Regresa Un valor Convertido 
        '    '             para Enviar como parametro a la clase ClsMovimientoInventarioDetalle(segun se especifique)
        '    '                                Atributo de ClsMovimientoInventarioDetalle          Indicador parametro Requerido
        '    '                                ------------------------------------------          -----------------------------
        '    '                               1.-atrPiezas                                         PrmRegresaPiezas=true
        '    '                               2.-atrCantidadEnUnidadDeMovimiento                   PrmRegresaPiezas=false

        '    'Entrada:     Recibe Un Objeto ProductoMarcaUnidad,Cantidad y Peso
        '    'Salida:      Regresa Valor Convertido para el parametro Requerido
        '    'Parametros:  prmProductoMarcaUnidad , prmCantidadUnidadMovimiento,prmCantidad,prmPeso asi como el inidicadores PrmRegresaPieza
        '    'BASADO EN LA DEFINICION DE REGLAS DE DATOS A ALMACENAR PARA TABLAS DE MOVIMIENTOS

        '    Dim vCantidadUnidadMovimiento As Double
        '    Dim vPiezas As Double

        '    If prmProductoMarcaUnidad.Producto.TipoManejoInventario.EsPeso Then             'Peso
        '        vCantidadUnidadMovimiento = prmPeso
        '        vPiezas = 0
        '    ElseIf prmProductoMarcaUnidad.Producto.TipoManejoInventario.EsPiezas Then       'Piezas
        '        vCantidadUnidadMovimiento = prmCantidad
        '        vPiezas = 0
        '    ElseIf prmProductoMarcaUnidad.Producto.TipoManejoInventario.EsPesoYPiezas Then
        '        If prmProductoMarcaUnidad.Producto.TipoInventario.EsSumarizado Then         'Peso Y Piezas
        '            'Esto aplica para los productos sumarizados ya que se tienen que verificar con el peso Estandard
        '            If prmProductoMarcaUnidad.Producto.EsPesoEstandard Then
        '                'vCantidadUnidadMovimiento = prmPeso
        '                'vPiezas = prmCantidad
        '                vCantidadUnidadMovimiento = prmCantidad
        '                vPiezas = prmCantidad * prmProductoMarcaUnidad.Equivalencia
        '            Else
        '                vCantidadUnidadMovimiento = prmPeso
        '                vPiezas = prmCantidad
        '            End If
        '        Else
        '            vCantidadUnidadMovimiento = prmPeso
        '            vPiezas = prmCantidad
        '        End If
        '    End If

        '    'Regresamos el Valor que se está solicitando
        '    If PrmRegresaPiezas Then
        '        Return vPiezas
        '    Else
        '        Return vCantidadUnidadMovimiento
        '    End If

        'End Function

        'Public Shared Function FgRegresa_ValorINVGETDB(ByVal prmProductoMarcaUnidad As Dominio.Productos.ClsProductoMarcaUnidad, ByVal prmCantidad As Double, ByVal prmPiezas As Double, ByVal PrmRegresaPiezas As Boolean) As Double
        '    'Elaboró:     L.I. César Octavio Niebla Manjarrez 
        '    'Modulo:      Inventario
        '    'Nota:        Conversion para Desplegar Datos a Usuario(YA QUE EL ALMACENAMIENTO DE DICHA INFORMACION SE HIZO SEGUN LA DEFINICION DE REGLAS DE DATOS A ALMACENAR PARA TABLAS DE MOVIMIENTOS)
        '    'Que Hace:    A partir de Un ProductoMarcaUnidad,Cantidad y Piezas, Regresa Un valor Convertido 
        '    '                                           Valor                           Indicador parametro Requerido
        '    '                       ------------------------------------------          -----------------------------
        '    '                       1.-Piezas                                              PrmRegresaPiezas=true
        '    '                       2.-Peso                                                PrmRegresaPiezas=False

        '    'Entrada:     Recibe Un Objeto ProductoMarcaUnidad,Cantidad y Piezas
        '    'Salida:      Regresa Valor Convertido para el Dato Requerido
        '    'Parametros:  prmProductoMarcaUnidad , prmCantidad,prmPiezas asi como el inidicadores PrmRegresaPieza
        '    'BASADO EN LA DEFINICION DE REGLAS DE DATOS A ALMACENAR PARA TABLAS DE MOVIMIENTOS

        '    Dim vCantidadBase As Double
        '    Dim vCantidad As Double
        '    Dim vFactor As Double = prmProductoMarcaUnidad.Equivalencia

        '    'Dim vCantidadUnidadMovimiento As Double
        '    Dim vlnPiezas As Double
        '    'Dim vPiezas As Double
        '    Dim vlnKilos As Double

        '    If prmProductoMarcaUnidad.Producto.TipoManejoInventario.EsPeso Then             'Peso
        '        vlnPiezas = 0
        '        vlnKilos = prmCantidad
        '    ElseIf prmProductoMarcaUnidad.Producto.TipoManejoInventario.EsPiezas Then       'Piezas
        '        vlnPiezas = prmCantidad
        '        vlnKilos = 0
        '    ElseIf prmProductoMarcaUnidad.Producto.TipoManejoInventario.EsPesoYPiezas Then
        '        If prmProductoMarcaUnidad.Producto.TipoInventario.EsSumarizado Then         'Peso Y Piezas
        '            'Esto aplica para los productos sumarizados ya que se tienen que verificar con el peso Estandard
        '            If prmProductoMarcaUnidad.Producto.EsPesoEstandard Then
        '                'vlnPiezas = prmCantidad
        '                'vlnKilos = prmPiezas / prmProductoMarcaUnidad.Equivalencia

        '                vlnPiezas = prmCantidad
        '                vlnKilos = prmPiezas * prmProductoMarcaUnidad.Producto.PesoPromedio
        '            Else
        '                vlnPiezas = prmPiezas
        '                vlnKilos = prmCantidad
        '            End If
        '        Else
        '            vlnPiezas = prmPiezas
        '            vlnKilos = prmCantidad
        '        End If
        '    End If

        '    'Regresamos el Valor que se está solicitando
        '    If PrmRegresaPiezas Then
        '        Return vlnPiezas
        '    Else
        '        Return vlnKilos
        '    End If

        'End Function


        'Public Shared Function Regresa_CantidadUnidadBase(ByVal prmProductoMarcaUnidad As Dominio.Productos.ClsProductoMarcaUnidad, ByVal prmCantidadUnidadMovimiento As Double) As Double
        '    'Elaboro:     L.I. Victor Vega
        '    'Modulo:      Inventario
        '    'Que Hace:    Convierte La CantidadEnUnidadMovimiento a CantidadEnUnidadBase de Un ProductoMarcaUnidad Determinado
        '    'Entrada:     Recibe Un Objeto ProductoMarcaUnidad y la Cantidad en Unidad de Movimiento
        '    'Salida:      Regresa La Cantidad En Unidad Base     
        '    'Parametros:  prmProductoMarcaUnidad , prmCantidadUnidadMovimiento

        '    'Se hace la conversion a la cantidad de unidad de movimiento a la base
        '    Dim vCantidadBase As Double
        '    Dim vCantidad As Double
        '    Dim vFactor As Double = prmProductoMarcaUnidad.Equivalencia

        '    If prmProductoMarcaUnidad.Producto.TipoManejoInventario.EsPeso Then             'Peso
        '        vCantidad = prmCantidadUnidadMovimiento
        '    ElseIf prmProductoMarcaUnidad.Producto.TipoManejoInventario.EsPiezas Then       'Piezas
        '        vCantidad = prmCantidadUnidadMovimiento
        '    ElseIf prmProductoMarcaUnidad.Producto.TipoManejoInventario.EsPesoYPiezas Then
        '        If prmProductoMarcaUnidad.Producto.TipoInventario.EsSumarizado Then         'Peso Y Piezas
        '            'Esto aplica para los productos sumarizados ya que se tienen que verificar con el peso Estandard
        '            If prmProductoMarcaUnidad.Producto.EsPesoEstandard Then
        '                vCantidad = prmCantidadUnidadMovimiento
        '                vFactor = prmProductoMarcaUnidad.Equivalencia * prmProductoMarcaUnidad.Producto.PesoPromedio
        '            Else
        '                vCantidad = prmCantidadUnidadMovimiento
        '            End If
        '        Else
        '            vCantidad = prmCantidadUnidadMovimiento
        '        End If
        '    End If

        '    vCantidadBase = vCantidad * vFactor

        '    Return vCantidadBase
        'End Function

        'Public Shared Function FgSumaColumnaGrid(ByRef e As Adsum.Adsum_Grid, ByVal pstrColumna As Integer) As Double
        '    'Elaboró:     L.I. César Octavio Niebla Manjarrez 
        '    'Que Hace:    Suma Los Valores de Una Columna determinada de Un objeto tipo ADSUM.Adsum_Grid


        '    Dim VlnRenglon As Integer
        '    Dim vlnAcumulador As Double

        '    vlnAcumulador = 0

        '    With e.ActiveSheet
        '        For VlnRenglon = 0 To .RowCount - 1
        '            vlnAcumulador = vlnAcumulador + Val(IIf(.Cells(VlnRenglon, pstrColumna).Text = "", 0, .Cells(VlnRenglon, pstrColumna).Value))
        '        Next
        '    End With

        '    Return vlnAcumulador
        'End Function


        'Solo aplica para clases que heredan de ClsBaseComun
        Public Shared Function ElementoInvalido_Activar(ByVal ATXControl As AccTextBoxAdvanced, Optional ByRef prmCodigoNoReactivado As Boolean = False) As Boolean
            'Obtenemos el AccTextBoxAdvanced
            Dim miATX As AccTextBoxAdvanced = ATXControl
            'Guardamos el filtro
            Dim miFiltro As String = miATX.CatalogoBase.FiltroExtendido
            miATX.CatalogoBase.FiltroExtendido = ""
            'Obtenemos el row sin filtrar
            Dim miRow As DataRow = miATX.CatalogoBase.ObtenElementoRow(ATXControl.Text)
            miATX.CatalogoBase.FiltroExtendido = miFiltro
            If Not miRow Is Nothing Then
                'Si el objetoactual es valido preguntamos si desea reactivarlo
                Dim miObjeto As Object = miATX.CatalogoBase.ObjetoActual
                If Not miObjeto Is Nothing Then
                    If Mensaje_ReactivarCodigo() = DialogResult.Yes Then
                        'Activamos el codigo y guardamos
                        Dim miBaseComun As ClsBaseComun = CType(miObjeto, ClsBaseComun)
                        miBaseComun.Activo = True
                        Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
                        DAO.AbreTransaccion()
                        If miBaseComun.Guardar Then
                            DAO.CierraTransaccion()
                            Return True
                        End If
                        If DAO.TieneTransaccionAbierta Then DAO.DeshaceTransaccion()
                    Else
                        prmCodigoNoReactivado = True
                        miATX.CatalogoBase.ObjetoActual = Nothing
                    End If
                End If
            End If
        End Function





        Public Shared Sub EventoLeave_Agregar(ByVal prmControles As Control.ControlCollection, ByVal prmDelegado As EventHandler)
            If prmControles Is Nothing Then Exit Sub
            For Each miControl As Control In prmControles
                EventoLeave_Agregar(miControl.Controls, prmDelegado)
                If TypeOf miControl Is ComboBox Then
                    AddHandler CType(miControl, ComboBox).Leave, prmDelegado
                End If
            Next
        End Sub

        Public Shared Sub EventoLeave_Remover(ByVal prmControles As Control.ControlCollection, ByVal prmDelegado As EventHandler)
            If prmControles Is Nothing Then Exit Sub
            For Each miControl As Control In prmControles
                EventoLeave_Remover(miControl.Controls, prmDelegado)
                If TypeOf miControl Is ComboBox Then
                    RemoveHandler CType(miControl, ComboBox).Leave, prmDelegado
                End If
            Next
        End Sub

        Public Shared Sub EventoTextChanged_Agregar(ByVal prmControles As Control.ControlCollection, ByVal prmDelegado As EventHandler)
            If prmControles Is Nothing Then Exit Sub
            For Each miControl As Control In prmControles
                EventoTextChanged_Agregar(miControl.Controls, prmDelegado)
                'AddHandler miControl.TextChanged, prmDelegado

                If TypeOf miControl Is TextBox OrElse TypeOf miControl Is AccTextBoxAdvanced Then
                    AddHandler CType(miControl, TextBox).TextChanged, prmDelegado
                End If

                If TypeOf miControl Is ComboBox Then
                    AddHandler CType(miControl, ComboBox).SelectedIndexChanged, prmDelegado
                End If

                If TypeOf miControl Is CheckBox OrElse TypeOf miControl Is Componentes.CheckBox Then
                    AddHandler CType(miControl, CheckBox).CheckedChanged, prmDelegado
                End If


                If TypeOf miControl Is RadioButton Then
                    AddHandler CType(miControl, RadioButton).CheckedChanged, prmDelegado
                End If

                If TypeOf miControl Is DateTimePicker Then
                    AddHandler CType(miControl, DateTimePicker).TextChanged, prmDelegado
                End If

            Next
        End Sub
        Public Shared Function FgPermiteImprimirTickets() As Boolean
            DAO = DataAccessCls.DevuelveInstancia
            archivoIni.OpenINIFile(DAO.GetRutaArchivoIni)
            If archivoIni.GetEntry(PrmIni_ImprimeComprobantes) = "SI" Then
                archivoIni.CloseINIFile()
                Return True
            End If
            archivoIni.CloseINIFile()
            Return False
        End Function
        Public Shared Function FgPideConfirmacionImprimirTickets() As Boolean
            DAO = DataAccessCls.DevuelveInstancia
            archivoIni.OpenINIFile(DAO.GetRutaArchivoIni)
            If archivoIni.GetEntry(PrmIni_ImprimePideConfirmacion) = "SI" Then
                archivoIni.CloseINIFile()
                Return True
            End If
            archivoIni.CloseINIFile()
            Return False
        End Function
        Public Shared Sub EventoTextChanged_Remover(ByVal prmControles As Control.ControlCollection, ByVal prmDelegado As EventHandler)
            If prmControles Is Nothing Then Exit Sub
            For Each miControl As Control In prmControles
                EventoTextChanged_Remover(miControl.Controls, prmDelegado)
                'RemoveHandler miControl.TextChanged, prmDelegado
                If TypeOf miControl Is TextBox OrElse TypeOf miControl Is AccTextBoxAdvanced Then
                    RemoveHandler CType(miControl, TextBox).TextChanged, prmDelegado
                End If

                If TypeOf miControl Is ComboBox Then
                    RemoveHandler CType(miControl, ComboBox).SelectedIndexChanged, prmDelegado
                End If

                If TypeOf miControl Is CheckBox OrElse TypeOf miControl Is Componentes.CheckBox Then
                    RemoveHandler CType(miControl, CheckBox).CheckedChanged, prmDelegado
                End If

                If TypeOf miControl Is RadioButton Then
                    RemoveHandler CType(miControl, RadioButton).CheckedChanged, prmDelegado
                End If

                If TypeOf miControl Is DateTimePicker Then
                    RemoveHandler CType(miControl, DateTimePicker).TextChanged, prmDelegado
                End If

            Next
        End Sub


        Public Shared Sub EventoGotFocus(ByVal prmDelegado As EventHandler, ByVal ParamArray Controles() As Object)
            Dim i As Integer

            For i = 0 To Controles.GetLongLength(0) - 1
                If TypeOf Controles(i) Is TextBox OrElse TypeOf Controles(i) Is AccTextBoxAdvanced Then
                    AddHandler CType(Controles(i), TextBox).GotFocus, prmDelegado
                End If

                If TypeOf Controles(i) Is ComboBox Then
                    AddHandler CType(Controles(i), ComboBox).GotFocus, prmDelegado
                End If

                If TypeOf Controles(i) Is CheckBox OrElse TypeOf Controles(i) Is Componentes.CheckBox Then
                    AddHandler CType(Controles(i), CheckBox).GotFocus, prmDelegado
                End If

                If TypeOf Controles(i) Is RadioButton Then
                    AddHandler CType(Controles(i), RadioButton).GotFocus, prmDelegado
                End If

            Next
        End Sub

        Public Shared Sub EventoGotFocus_Proceso(ByVal prmDelegado As EventHandler, ByVal ParamArray Controles() As Object)
            Dim i As Integer

            For i = 0 To Controles.GetLongLength(0) - 1
                If TypeOf Controles(i) Is TextBox OrElse TypeOf Controles(i) Is AccTextBoxAdvanced Then
                    AddHandler CType(Controles(i), TextBox).GotFocus, prmDelegado
                End If

                If TypeOf Controles(i) Is ComboBox Then
                    AddHandler CType(Controles(i), ComboBox).GotFocus, prmDelegado
                End If

                If TypeOf Controles(i) Is CheckBox OrElse TypeOf Controles(i) Is Componentes.CheckBox Then
                    AddHandler CType(Controles(i), CheckBox).GotFocus, prmDelegado
                End If

                If TypeOf Controles(i) Is RadioButton Then
                    AddHandler CType(Controles(i), RadioButton).GotFocus, prmDelegado
                End If


            Next
        End Sub

        Public Shared Sub GotFocus_Agregar(ByVal prmControles As Control.ControlCollection, ByVal prmDelegado As EventHandler)
            If prmControles Is Nothing Then Exit Sub
            For Each miControl As Control In prmControles
                GotFocus_Agregar(miControl.Controls, prmDelegado)
                If TypeOf miControl Is TextBox OrElse TypeOf miControl Is AccTextBoxAdvanced Then
                    AddHandler CType(miControl, TextBox).TextChanged, prmDelegado
                End If

                If TypeOf miControl Is ComboBox Then
                    AddHandler CType(miControl, ComboBox).SelectedIndexChanged, prmDelegado
                End If

                If TypeOf miControl Is CheckBox OrElse TypeOf miControl Is Componentes.CheckBox Then
                    AddHandler CType(miControl, CheckBox).CheckedChanged, prmDelegado
                End If

                If TypeOf miControl Is RadioButton Then
                    AddHandler CType(miControl, RadioButton).CheckedChanged, prmDelegado
                End If

                If TypeOf miControl Is DateTimePicker Then
                    AddHandler CType(miControl, DateTimePicker).TextChanged, prmDelegado
                End If

            Next
        End Sub


#Region "   MODULO 11  "

        Public Shared Function getModulo11_Int(ByVal prmCodigo As String) As Integer

            Dim vSuma As Integer = 0
            Dim vMultiplicador As Integer = 2
            Dim vChars() As Char = prmCodigo.ToCharArray

            For x As Integer = prmCodigo.Length - 1 To 0 Step -1
                Dim vValor As Integer = Asc(vChars(x)) - Asc("0")
                vSuma += vValor * vMultiplicador
                vMultiplicador += 1
                If vMultiplicador = 8 Then
                    vMultiplicador = 2
                End If
            Next

            vSuma = vSuma Mod 11
            If (vSuma <= 2) Then
                Return 0
            End If

            Return (11 - vSuma)


        End Function

        Public Shared Function getModulo11_String(ByVal prmCodigo As String) As String
            Return Chr(getModulo11_Int(prmCodigo) + 48)
        End Function

        Public Shared Function getModulo11_Concatenado(ByVal prmCodigo As String) As String
            Return prmCodigo & getModulo11_String(prmCodigo)
        End Function

        Public Shared Function Importacion_Ultimos6Digistos(ByVal cFactura As String, Optional ByVal RELLENO_CEROS As Boolean = False) As String
            Importacion_Ultimos6Digistos = ""
            Dim misCaracteres() As Char = cFactura.ToCharArray()
            'For x As Integer = misCaracteres.Length - 1 To 1 Step -1
            For x As Integer = misCaracteres.Length - 1 To 0 Step -1
                If "0123456789".IndexOf(misCaracteres(x)) >= 0 Then
                    Importacion_Ultimos6Digistos = misCaracteres(x) & Importacion_Ultimos6Digistos
                    If Importacion_Ultimos6Digistos.Length = 6 Then Exit For
                End If
            Next

            If RELLENO_CEROS Then
                Importacion_Ultimos6Digistos = Tool.RellenaCon(Importacion_Ultimos6Digistos, 6, "0")
            End If
        End Function

#End Region

#Region "MODULO 10"
        Public Shared Function getModulo10_Int(ByVal prmCodigo As String) As Integer

            Dim vPar As Integer = 0
            Dim vImpar As Integer = 0
            Dim i As Integer = 1

            If Len(prmCodigo) < 7 Then
                prmCodigo = Tool.RellenaCon("0000000" + prmCodigo, 7, "0000000")
            End If

            For x As Integer = 1 To Len(prmCodigo)
                i = Math.Abs(i - 1)
                If i = 1 Then
                    vPar = vPar + CInt(Microsoft.VisualBasic.Mid(prmCodigo, x, 1))
                Else
                    vImpar = vImpar + CInt(Microsoft.VisualBasic.Mid(prmCodigo, x, 1))
                End If
            Next x
            vPar = vPar * 3
            vPar = vPar + vImpar
            vPar = 10 - Val(Microsoft.VisualBasic.Right(LTrim(RTrim(vPar)), 1))

            If vPar = 10 Then
                vPar = 0
            End If
        End Function

#End Region

#Region "  WEB  "

        Public Shared Function EnviaMail(ByVal prmDestino As String, ByVal prmAsunto As String, ByVal prmTexto As String) As Boolean
            'Return True
            'Dim vMail As New ClsCorreoWeb(prmAsunto, prmDestino, prmTexto)
            'Try
            '    'vMail.From = "Sistema Comercial"
            '    'vMail.To = prmDestino
            '    'vMail.Subject = prmAsunto
            '    'vMail.Body = prmTexto
            '    'vMail.BodyFormat = Web.Mail.MailFormat.Text
            '    'vMail.UrlContentBase = "http://www.sukarne.com"
            '    'vMail.UrlContentLocation = "http://www.sukarne.com"
            '    'System.Web.Mail.SmtpMail.SmtpServer = "smtp.sukarne.com"

            '    'vMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0") '	//basic authentication
            '    ''vMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "maribel.lafarga@sukarne.com") ' //set your username here
            '    ''vMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "123456*") '	//set your password here

            '    'System.Web.Mail.SmtpMail.Send(vMail)
            '    If Not vMail.Send() Then
            '        'MessageBox.Show("Error al envial el mail: ", GlobalSistemaCaption, MessageBoxButtons.OK, MessageBoxIcon.Error)
            '        Return False
            '    Else
            '        Return True
            '    End If
            'Catch ex As Exception
            '    'MessageBox.Show("Error al envial el mail: " & ex.Message, GlobalSistemaCaption, MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    While Not ex.InnerException Is Nothing
            '        'MessageBox.Show("Error al envial el mail: " & ex.InnerException.ToString, GlobalSistemaCaption, MessageBoxButtons.OK, MessageBoxIcon.Error)
            '        ex = ex.InnerException
            '    End While
            '    Return False
            'End Try

        End Function

#End Region

#Region "   DAVID   "

        Public Shared Function ObtenValoresSeparadosPorComa(ByVal tabla As DataTable, ByVal nombreCampo As String) As String
            Dim misValores As String = ""
            For Each miRow As DataRow In tabla.Rows
                If Not miRow(nombreCampo) Is DBNull.Value Then
                    misValores &= CStr(miRow(nombreCampo)) & ","
                End If
            Next

            Return misValores.Substring(0, misValores.Length - 1)
        End Function

        Public Shared Sub CargaComboConObjetos(ByVal SQLText As String, ByVal Combo As ComboBox, ByVal prmDelegadoCreacion As Catalogo.ObtenerObjetoCatalogoEventHandler, Optional ByVal ElementoAdicional As DataAccessCls.TipoElementoAdicionalDeLista = DataAccessCls.TipoElementoAdicionalDeLista.Seleccione, Optional ByVal AGREGAR_ELMENTOS_ADICIONALES As Boolean = True)
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vTabla As New DataTable
            Combo.Items.Clear()
            If DAO.RegresaConsultaSQL(SQLText, vTabla) Then
                If AGREGAR_ELMENTOS_ADICIONALES Then
                    If ElementoAdicional = DataAccessCls.TipoElementoAdicionalDeLista.Seleccione Then
                        Combo.Items.Add(ComboSeleccione)
                    ElseIf ElementoAdicional = DataAccessCls.TipoElementoAdicionalDeLista.Todos Then
                        Combo.Items.Add(ComboTodos)
                    End If
                End If

                For Each vRow As DataRow In vTabla.Rows
                    Combo.Items.Add(prmDelegadoCreacion(vRow))
                Next
                Combo.SelectedIndex = 0
            End If
        End Sub

#End Region

        'Public Shared Sub INV_InsertaPesadaManual(ByVal producto As Productos.ClsProducto, ByVal pmu As Productos.ClsProductoMarcaUnidad, ByVal peso As Double, ByVal usuarioAutorizacion As String, ByVal NombreForma As String)
        '    DAO = DataAccessCls.DevuelveInstancia
        '    Dim miSqlText As String = "INSERT INV_PesadasManuales(nCanalDistribucion ,nProducto ,nProductoMarcaUnidad ,nPeso ,cUsuarioAprobacion ,cUsuarioRegistro ,cNombreForma)" & vbCr
        '    miSqlText &= "SELECT " & ParamtetrosSucursal.CanalDistribucion
        '    miSqlText &= " ," & producto.Folio.ToString
        '    If pmu Is Nothing Then
        '        miSqlText &= " ,NULL"
        '    Else
        '        miSqlText &= " ," & pmu.Folio.ToString
        '    End If
        '    miSqlText &= " ," & peso.ToString
        '    miSqlText &= " ,'" & usuarioAutorizacion.ToString & "'"
        '    miSqlText &= " ,'" & DAO.GetLoginUsuario.Trim & "'"
        '    miSqlText &= " ,'" & NombreForma & "'"
        '    DAO.EjecutaComandoSQL(miSqlText)
        'End Sub

        Public Shared Sub PonFoco(ByVal prmControl As Control, Optional ByVal prmFoco As Boolean = True)
            If Not prmControl.Enabled Then Return


            If TypeOf prmControl Is ComboBox Then
                prmControl.BackColor = Color.Yellow
            End If

            If TypeOf prmControl Is AccTextBoxAdvanced Then
                If Not CType(prmControl, AccTextBoxAdvanced).ReadOnly Then prmControl.BackColor = Color.Yellow
            End If
            If TypeOf prmControl Is AccTextBoxAdvanced Then
                If Not CType(prmControl, AccTextBoxAdvanced).ReadOnly Then prmControl.BackColor = Color.Yellow
            End If
            If TypeOf prmControl Is TextBox Then
                If Not CType(prmControl, TextBox).ReadOnly Then prmControl.BackColor = Color.Yellow
            End If
            If TypeOf prmControl Is Componentes.SeleccionesDeUsuario Then
                If Not CType(prmControl, Componentes.SeleccionesDeUsuario).ReadOnly Then prmControl.BackColor = Color.Yellow
            End If
            If TypeOf prmControl Is CheckBox Or TypeOf prmControl Is RadioButton Then
                prmControl.BackColor = Color.Yellow
            End If

            '            If TypeOf prmControl Is AccTextBoxAdvanced Or TypeOf prmControl Is AccTextBoxAdvancedValidador Or TypeOf prmControl Is TextBox Then
            '           prmControl.BackColor = Color.Yellow
            '          End If
            If prmFoco Then prmControl.Focus()

        End Sub


        Public Shared Sub QuitaFoco(ByVal prmControl As Control)
            If Not prmControl.Enabled Then Return

            If TypeOf prmControl Is ComboBox Then
                prmControl.BackColor = Nothing
            End If

            If TypeOf prmControl Is AccTextBoxAdvanced Then
                If Not CType(prmControl, AccTextBoxAdvanced).ReadOnly Then prmControl.BackColor = Nothing
            End If
            If TypeOf prmControl Is TextBox Then
                If Not CType(prmControl, TextBox).ReadOnly Then prmControl.BackColor = Nothing
            End If

            If TypeOf prmControl Is Componentes.SeleccionesDeUsuario Then
                If Not CType(prmControl, Componentes.SeleccionesDeUsuario).ReadOnly Then prmControl.BackColor = Nothing
            End If
            If TypeOf prmControl Is CheckBox Or TypeOf prmControl Is RadioButton Then
                prmControl.BackColor = Nothing
            End If

            '            If TypeOf prmControl Is AccTextBoxAdvanced Or TypeOf prmControl Is AccTextBoxAdvancedValidador Or TypeOf prmControl Is TextBox Then
            '           prmControl.BackColor = Color.Yellow
            '          End If
        End Sub

        Public Shared Sub PGCerrarPantalla(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs, Optional ByVal prmPreguntaSalirVentana As Boolean = True)
            If CerrarPantallaSinPreguntar Then Return

            If Not e.CloseReason = CloseReason.MdiFormClosing Then
                If Not prmPreguntaSalirVentana Then
                    e.Cancel = False
                    Exit Sub
                End If
                If MessageBox.Show(GlobalSistemaConfirmaCerrarVentana, GlobalSistemaCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    e.Cancel = False
                Else
                    e.Cancel = True
                End If
            End If
        End Sub

        'Public Shared Function PorUbicacion_RegresaConsultaSql(ByVal prmSql As String, ByRef dtRegresaConsulta As DataTable) As Boolean
        '    If ParametroEsCorporativo() Then
        '        If Not DAO.RegresaConsultaSQL(prmSql, dtRegresaConsulta) Then
        '            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
        '            Return False
        '        End If
        '    Else
        '        Dim vMessageError As String
        '        dtRegresaConsulta = Comun.ClsTools.RegresaConsultaDeWebService(prmSql, vMessageError)
        '        If vMessageError <> "" Then
        '            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
        '            MessageBox.Show("Error al obtener información del corporativo", GlobalSistemaCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
        '            Return False
        '        End If
        '    End If
        '    Return True
        'End Function

        'Public Shared Function PorUbicacion_EjecutaComandoSql(ByVal prmSql As String) As Boolean
        '    If ParametroEsCorporativo() Then
        '        If Not DAO.EjecutaComandoSQL(prmSql) Then
        '            If DAO.TieneTransaccionAbierta Then DAO.DeshaceTransaccion()
        '            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
        '            Return False
        '        End If
        '    Else
        '        Dim vMessageError As String = ""
        '        If (Not ClsTools.EjecutaComandosSQL_En_WebService(prmSql, vMessageError)) AndAlso vMessageError <> "" Then
        '            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
        '            MessageBox.Show("Error al actualizar información en corporativo", GlobalSistemaCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
        '            Return False
        '        End If
        '    End If
        '    Return True
        'End Function

        'Public Shared Function ObtenEjecutivo() As Dominio.Catalogos.ClsEmpleado
        '    Dim nIDPersonal As Integer = 0
        '    nIDPersonal = DAO.RegresaDatoSQL("select  isnull((select nPersonal from adsum_usuarios where cLogin=SYSTEM_USER),0) as nPersonal")

        '    Return Dominio.Catalogos.FabricaCatalogos.ObtenEmpleado(nIDPersonal, True)
        'End Function

        Private Shared Function ColumnEqual(ByVal A As Object, ByVal B As Object) As Boolean
            '
            ' Compares two values to determine if they are equal. Also compares DBNULL.Value.
            '
            ' NOTE: If your DataTable contains object fields, you must extend this
            ' function to handle the fields in a meaningful way if you intend to group on them.
            '
            If A Is DBNull.Value And B Is DBNull.Value Then Return True ' Both are DBNull.Value.
            If A Is DBNull.Value Or B Is DBNull.Value Then Return False ' Only one is DBNull.Value.
            Return A = B                                                ' Value type standard comparison
        End Function

        Public Shared Function SelectDistinct(ByVal TableName As String, _
                                       ByVal SourceTable As DataTable, _
                                       ByVal FieldName As String, Optional ByVal prmFiltro As String = "", Optional ByVal prmCampoOrdenar As String = "") As DataTable
            Dim dt As New DataTable(TableName)
            dt.Columns.Add(FieldName, SourceTable.Columns(FieldName).DataType)
            Dim dr As DataRow, LastValue As Object
            For Each dr In SourceTable.Select(prmFiltro, prmCampoOrdenar)
                If LastValue Is Nothing OrElse Not ColumnEqual(LastValue, dr(FieldName)) Then
                    LastValue = dr(FieldName)
                    dt.Rows.Add(New Object() {LastValue})
                End If
            Next
            Return dt
        End Function

        'Public Shared Function SelectDistinct(ByVal TableName As String, _
        '                       ByVal SourceTable As DataTable, _
        '                       ByVal FieldName As String, ByVal Filtro As String, Optional ByVal prmCampoOrdenacion As String = "") As DataTable
        '    Dim dt As New DataTable(TableName)
        '    dt.Columns.Add(FieldName, SourceTable.Columns(FieldName).DataType)
        '    Dim dr As DataRow, LastValue As Object
        '    For Each dr In SourceTable.Select(Filtro, FieldName)
        '        If LastValue Is Nothing OrElse Not ColumnEqual(LastValue, dr(FieldName)) Then
        '            LastValue = dr(FieldName)
        '            dt.Rows.Add(New Object() {LastValue})
        '        End If
        '    Next
        '    Return dt
        'End Function

        Public Shared Function SelectDistinctRows( _
                                       ByVal SourceTable As DataTable, _
                                       ByVal FieldName As String) As DataTable
            Dim dt As New DataTable()
            dt.TableName = SourceTable.TableName
            copiaRows(SourceTable.Select("1=0"), dt, SourceTable.Columns)
            Dim dr As DataRow, LastValue As Object
            For Each dr In SourceTable.Select("", FieldName)
                If LastValue Is Nothing OrElse Not ColumnEqual(LastValue, dr(FieldName)) Then
                    LastValue = dr(FieldName)
                    'dt.Rows.Add(New Object() {LastValue})
                    copiaRows(dr, dt)
                End If
            Next
            Return dt
        End Function

        Public Shared Sub PGMarcarSeleccion_PrimerClick(ByRef prmDataTable As DataTable, ByRef prmGridView As Object, ByRef prmColumna As Object, Optional ByRef prmRow As DataRowView = Nothing)
            If prmRow Is Nothing Then
                prmRow = prmGridView.GetRow(prmGridView.FocusedRowHandle)
            End If
            If prmGridView.FocusedColumn Is prmColumna Then
                If Not prmRow Is Nothing Then
                    If Not prmRow(prmColumna.FIELDNAME) Is DBNull.Value Then
                        prmRow(prmColumna.FIELDNAME) = Not prmRow(prmColumna.FIELDNAME)
                    Else
                        prmRow(prmColumna.FIELDNAME) = True
                    End If
                End If
                prmDataTable.AcceptChanges()
            End If
        End Sub

        Public Shared Function ObtenFormatos() As String
            Dim vlsql As String = ""
            Dim vRes As String = ""
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim dtRes As New DataTable

            vlsql = "SELECT * FROM Adsum_ReportesFormatosColumnas (NOLOCK)"
            DAO.RegresaConsultaSQL(vlsql, dtRes)
            For Each vRow As DataRow In dtRes.Rows
                vRes &= " " & vRow("cFormato")
            Next
            Return vRes
        End Function

        'Public Shared Sub FgConfiguraBandasManipulablesGrid(ByRef PrmGrid As DevExpress.XtraGrid.GridControl)
        '    ' If PrmGrid.
        '    'For Each vView As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView In PrmGrid.ViewCollection
        '    '    For Each miBanda As Object In vView.Bands
        '    '        miBanda.Tag = miBanda.VisibleIndex
        '    '    Next
        '    'Next
        'End Sub

        Public Shared Function FgValidaControlesObligatoriosAlGrabar(ByRef prmForma As AccessForm, Optional ByVal prmPinta As Boolean = True, Optional ByRef prmPrimerControlInvalido As Control = Nothing) As Boolean
            'Desarrolló: L.I. César Octavio Niebla Manjarrez
            'Fecha:      26/Enero/2007 
            'Que Hace? : -Valida Controles de una forma, segun el estandar de Proyecto VIZUR
            '            -Busca Controles vacios considerados como obligatorios al guardar
            '               La Función Trabaja de la siguiente Manera:
            '           -----------------------------------------------------------------------
            '               1.-Pinta ó Despinta todos los controles vacios considerados como obligatorios al guardar 
            '                  (Segun indique el parametro PrmPinta) 
            '                   True=Pinta false=Despinta
            '               2.-Despliega Mensaje para el Primer control No Acreditado en Validación (Se basa en TabIndex)
            '               3.-Devuelve Foco a Dicho Control (Primer control No Acreditado en Validación)
            '           -----------------------------------------------------------------------
            '      Nota:* Los Controles serán considerados como obligatorios cuando 
            '             su propiedad tag contenga diferente a Nothing 
            '           * La Función Asume que el valor Contenido en la Propiedad tag del control,
            '             se Trata de la descripción del dato que maneja el control obligatorio,
            '             la cual se tomará para Armar Mensaje desplegar a usuario.
            '           Ejemplo:
            '               Entrada
            '                   TxtnAlmacen.tag="ALMACÉN"        TxtnAlmacen.text=""
            '               Salida del FgValidaControlesObligatoriosAlGrabar():
            '                   FgValidaControlesObligatoriosAlGrabar=false
            '                   TxtnAlmacen.backcolor=Color.Yellow
            '                   MsgBox("Debe Ingresar " & TxtnAlmacen.tag & " Para Continuar..", "Atención")
            '                   TxtnAlmacen.focus()
            '                   Nota: Quedará a decisión del programador mandar parametro prmPrimerControlInvalido
            '                         recibido por referencia si considera necesario obtener dicho objeto.

            For Each vControl As Control In prmForma.Controls
                If Not vControl.Name.Trim = "" Then
                    PgValidaTipoControl(vControl, prmPinta, prmPrimerControlInvalido)
                End If
            Next

            If Not prmPrimerControlInvalido Is Nothing And prmPinta Then
                'MsgBox("Debe ingresar " & UCase(prmPrimerControlInvalido.Tag) & " para continuar..." & vbCr & "Verifique.", MsgBoxStyle.Information, ClsTools.MensajeGlobalSistema)
                prmPrimerControlInvalido.Focus()
                Return False
            End If

            Return True
        End Function


        Public Shared Sub PgValidaTipoControl(ByRef prmControl As System.Windows.Forms.Control, ByVal PrmPinta As Boolean, ByRef prmPrimerControlInvalido As System.Windows.Forms.Control)

            If (TypeOf prmControl Is AccTextBoxAdvanced) Or (TypeOf prmControl Is System.Windows.Forms.TextBox) Or (TypeOf prmControl Is System.Windows.Forms.RichTextBox) Then
                If Not (prmControl.Tag Is Nothing) Then
                    'If Not (prmControl.Tag Is Nothing And prmControl.Tag = "") Then
                    If Not prmControl.Tag = "" Then
                        If prmControl.Text = "" Or Not PrmPinta Then
                            prmPrimerControlInvalido = IIf(prmPrimerControlInvalido Is Nothing, prmControl, prmPrimerControlInvalido)
                            prmPrimerControlInvalido = IIf(prmControl.TabIndex < prmPrimerControlInvalido.TabIndex, prmControl, prmPrimerControlInvalido)
                            prmControl.BackColor = IIf(PrmPinta = True, Color.Yellow, Color.White)
                        End If

                        If prmControl.Text = "" Or Not PrmPinta Then
                            prmPrimerControlInvalido = IIf(prmPrimerControlInvalido Is Nothing, prmControl, prmPrimerControlInvalido)
                            prmPrimerControlInvalido = IIf(prmControl.TabIndex < prmPrimerControlInvalido.TabIndex, prmControl, prmPrimerControlInvalido)
                            prmControl.BackColor = IIf(PrmPinta = True, Color.Yellow, Color.White)
                        End If

                    End If
                End If
            End If

            If (TypeOf prmControl Is System.Windows.Forms.ComboBox) Then
                If Not (prmControl.Tag Is Nothing And prmControl.Tag = "") Then
                    If CType(prmControl, ComboBox).SelectedValue = 0 Or CType(prmControl, ComboBox).Text.Trim = "" Or Not PrmPinta Then 'vacio
                        prmPrimerControlInvalido = IIf(prmPrimerControlInvalido Is Nothing, prmControl, prmPrimerControlInvalido)
                        prmPrimerControlInvalido = IIf(prmControl.TabIndex < prmPrimerControlInvalido.TabIndex, prmControl, prmPrimerControlInvalido)
                        prmControl.BackColor = IIf(PrmPinta = True, Color.Yellow, Color.White)
                    End If
                End If
            End If


            If TypeOf prmControl Is System.Windows.Forms.TabPage Then 'Recorremos Contenedor de Controles
                Dim vTabPage As System.Windows.Forms.TabPage = prmControl
                For Each vControl As Control In vTabPage.Controls
                    PgValidaTipoControl(vControl, PrmPinta, prmPrimerControlInvalido)
                Next
            End If

            If TypeOf prmControl Is System.Windows.Forms.TabControl Then 'Recorremos Contenedor de tabPages
                Dim vTabControl As System.Windows.Forms.TabControl = prmControl
                For Each vControl As TabPage In vTabControl.TabPages
                    PgValidaTipoControl(vControl, PrmPinta, prmPrimerControlInvalido)
                Next
            End If


            If TypeOf prmControl Is System.Windows.Forms.GroupBox Then 'Recorremos Contenedor de controles
                Dim vGroupBox As System.Windows.Forms.GroupBox = prmControl
                For Each vControl As System.Windows.Forms.Control In vGroupBox.Controls
                    PgValidaTipoControl(vControl, PrmPinta, prmPrimerControlInvalido)
                Next
            End If


            If TypeOf prmControl Is System.Windows.Forms.Panel Then 'Recorremos Contenedor de controles
                Dim vPanel As System.Windows.Forms.Panel = prmControl
                For Each vControl As System.Windows.Forms.Control In vPanel.Controls
                    PgValidaTipoControl(vControl, PrmPinta, prmPrimerControlInvalido)
                Next
            End If
        End Sub

        Public Enum Pantallas
            Pedido
            Solicitud
            Surtido
            Recepcion
            Traspaso
            RecepcionTraspaso
            Devolucion
            RecepcionDevolucion
            Movimientos
        End Enum

        Public Shared Function FgHabilitaBotonImprimir(ByVal prmPantalla As Pantallas) As Boolean
            DAO = DataAccessCls.DevuelveInstancia
            archivoIni.OpenINIFile(DAO.GetRutaArchivoIni)
            If archivoIni.GetEntry(PrmIni_ImprimeComprobantes) = "SI" Then
                Select Case prmPantalla
                    Case Pantallas.Movimientos
                        If archivoIni.GetEntry(PrmIni_ImprimeMovimientosGenerales) = "SI" Then
                            archivoIni.CloseINIFile()
                            Return True
                        End If
                    Case Pantallas.Pedido
                        If archivoIni.GetEntry(PrmIni_ImprimePedido) = "SI" Then
                            archivoIni.CloseINIFile()
                            Return True
                        End If
                    Case Pantallas.Recepcion
                        If archivoIni.GetEntry(PrmIni_ImprimeRecepcionSurtido) = "SI" Then
                            archivoIni.CloseINIFile()
                            Return True
                        End If
                    Case Pantallas.RecepcionDevolucion
                        If archivoIni.GetEntry(PrmIni_ImprimeEntradaDevolucion) = "SI" Then
                            archivoIni.CloseINIFile()
                            Return True
                        End If
                    Case Pantallas.RecepcionTraspaso
                        If archivoIni.GetEntry(PrmIni_ImprimeEntradaTraspaso) = "SI" Then
                            archivoIni.CloseINIFile()
                            Return True
                        End If
                    Case Pantallas.Devolucion
                        If archivoIni.GetEntry(PrmIni_ImprimeSalidaDevolucion) = "SI" Then
                            archivoIni.CloseINIFile()
                            Return True
                        End If
                    Case Pantallas.Traspaso
                        If archivoIni.GetEntry(PrmIni_ImprimeSalidaTraspaso) = "SI" Then
                            archivoIni.CloseINIFile()
                            Return True
                        End If
                    Case Pantallas.Solicitud
                        If archivoIni.GetEntry(PrmIni_ImprimeSolicitudTraspaso) = "SI" Then
                            archivoIni.CloseINIFile()
                            Return True
                        End If
                    Case Pantallas.Surtido
                        If archivoIni.GetEntry(PrmIni_ImprimeSurtido) = "SI" Then
                            archivoIni.CloseINIFile()
                            Return True
                        End If
                End Select
            End If
            archivoIni.CloseINIFile()
            Return False
        End Function

        Public Shared Function FgPideConfirmacion(ByVal prmPantalla As Pantallas) As Boolean
            DAO = DataAccessCls.DevuelveInstancia
            archivoIni.OpenINIFile(DAO.GetRutaArchivoIni)
            If archivoIni.GetEntry(PrmIni_ImprimeComprobantes) = "SI" Then
                If archivoIni.GetEntry(PrmIni_ImprimePideConfirmacion) = "SI" Then
                    archivoIni.CloseINIFile()
                    Return True
                End If
            End If
            archivoIni.CloseINIFile()
            Return False
        End Function
        Public Shared Function FgParametroPermiteAccion(ByVal prmNombreParametroIni As String) As Boolean
            DAO = DataAccessCls.DevuelveInstancia
            archivoIni.OpenINIFile(DAO.GetRutaArchivoIni)
            If archivoIni.GetEntry(prmNombreParametroIni).ToString.ToUpper.Trim = "SI" Then
                archivoIni.CloseINIFile()
                Return True
            End If
            archivoIni.CloseINIFile()
            Return False
        End Function
        Public Shared Function FgParametroObtieneValor(ByVal prmNombreParametroIni As String) As Object
            DAO = DataAccessCls.DevuelveInstancia
            archivoIni.OpenINIFile(DAO.GetRutaArchivoIni)
            Dim vObjResultado As Object
            vObjResultado = archivoIni.GetEntry(prmNombreParametroIni.Trim)
            archivoIni.CloseINIFile()
            Return vObjResultado
        End Function

        Public Shared Sub PGLlenaComboImpresoraTicket(ByRef prmCombo As ComboBox)
            Dim prtdoc As New System.Drawing.Printing.PrintDocument()
            Dim strDefaultPrinter As String = prtdoc.PrinterSettings.PrinterName
            Dim strPrinter As [String]
            For Each strPrinter In System.Drawing.Printing.PrinterSettings.InstalledPrinters
                prmCombo.Items.Add(strPrinter)
                If strPrinter = strDefaultPrinter Then
                    prmCombo.SelectedIndex = prmCombo.Items.IndexOf(strPrinter)
                End If
            Next strPrinter
        End Sub


        Public Shared Function FgGeneraImagenBarCode(ByVal PrmCodigoBarra As String, ByVal prmHeader As String) As Bitmap
            'Que Hace:    A partir de una cadena recibida como parámetro genera una imagen con la representación
            '             de dicha cadena a Código de barras bajo el estandar cod128 asi como un texto como encabezado

            Dim bmp As Bitmap

            Dim W As Integer = Convert.ToInt32(170)
            Dim H As Integer = Convert.ToInt32(40)
            Dim b As BarcodeLib.Barcode = New BarcodeLib.Barcode()

            Dim type As BarcodeLib.TYPE = BarcodeLib.TYPE.UNSPECIFIED
            'Switch(cbEncodeType.SelectedItem.ToString().Trim())
            '    {
            '        case "UPC-A": type = BarcodeLib.TYPE.UPCA; break;
            '        case "UPC-E": type = BarcodeLib.TYPE.UPCE; break;
            '        case "UPC 2 Digit Ext.": type = BarcodeLib.TYPE.UPC_SUPPLEMENTAL_2DIGIT; break;
            '        case "UPC 5 Digit Ext.": type = BarcodeLib.TYPE.UPC_SUPPLEMENTAL_5DIGIT; break;
            '        case "EAN-13": type = BarcodeLib.TYPE.EAN13; break;
            '        case "JAN-13": type = BarcodeLib.TYPE.JAN13; break;
            '        case "EAN-8": type = BarcodeLib.TYPE.EAN8; break;
            '        case "ITF-14": type = BarcodeLib.TYPE.ITF14; break;
            '        case "Codabar": type = BarcodeLib.TYPE.Codabar; break;
            '        case "PostNet": type = BarcodeLib.TYPE.PostNet; break;
            '        case "Bookland/ISBN": type = BarcodeLib.TYPE.BOOKLAND; break;
            '        case "Code 11": type = BarcodeLib.TYPE.CODE11; break;
            '        case "Code 39": type = BarcodeLib.TYPE.CODE39; break;
            '        case "Code 39 Extended": type = BarcodeLib.TYPE.CODE39Extended; break;
            '        case "Code 93": type = BarcodeLib.TYPE.CODE93; break;
            '        case "LOGMARS": type = BarcodeLib.TYPE.LOGMARS; break;
            '        case "MSI": type = BarcodeLib.TYPE.MSI_Mod10; break;
            '        case "Interleaved 2 of 5": type = BarcodeLib.TYPE.Interleaved2of5; break;
            '        case "Standard 2 of 5": type = BarcodeLib.TYPE.Standard2of5; break;
            '        case "Code 128": type = BarcodeLib.TYPE.CODE128; break;
            '        case "Code 128-A": type = BarcodeLib.TYPE.CODE128A; break;
            '        case "Code 128-B": type = BarcodeLib.TYPE.CODE128B; break;
            '        case "Code 128-C": type = BarcodeLib.TYPE.CODE128C; break;
            '        default: MessageBox.Show("Please specify the encoding type."); break;
            '    }//switch


            type = BarcodeLib.TYPE.CODE128

            b.IncludeLabel = True

            bmp = b.Encode(type, PrmCodigoBarra.Trim(), System.Drawing.Color.Black, System.Drawing.Color.White, W, H)

            Return bmp
        End Function


        Public Shared Sub PgAbrirCajon()
            Dim DAO As DataAccessCls

            DAO = DataAccessCls.DevuelveInstancia

            'DAO.ParametroAdministradoAgregar("VTA", "VTA_SECUENCIA_CAJON", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parámetro para saber la secuencia para mandar a cajon", "Chr(7)")
            'vcCadena = "cmd /c echo  " & DAO.ParametroAdministradoObtener("VTA", "VTA_SECUENCIA_CAJON") & " > LPT1"
            'Shell(vcCadena, AppWinStyle.Hide)

            ''Mandar abrir el cajon
            Dim vcArchivo As String

            DAO.ParametroAdministradoAgregar("VTA", "RUTA_SECUENCIA_CAJON", DataAccessCls.TipoDeParametroAdministrado.Caracter, "Parámetro para saber la ruta para guardar secuencia para mandar a cajon", "C:\Adsum\")
            vcArchivo = DAO.ParametroAdministradoObtener("VTA", "RUTA_SECUENCIA_CAJON") & "escapes.txt"
            If IO.File.Exists(vcArchivo) Then
                IO.File.Delete(vcArchivo)
            End If

            Dim intFileNo As Integer = FreeFile()

            FileOpen(intFileNo, vcArchivo, OpenMode.Output)
            PrintLine(intFileNo, Chr(27) & "p" & Chr(0) & Chr(25) & Chr(250))
            FileClose(intFileNo)
            'Shell("print /d:lpt1 c:\escapes.txt", vbNormalFocus)
            Shell("print /d:lpt1 " & vcArchivo, AppWinStyle.Hide)
        End Sub

        Public Shared Function FgGeneraImagenBarCode(ByVal PrmCodigoBarra As String, ByVal PrmWidht As Integer, ByVal PrmHeight As Integer) As Bitmap
            'Elaboró:     César Octavio Niebla Manjarrez 
            'Fecha:       04-Septiembre-2009
            'Sistema:     SIP Panamá
            'Que Hace:    A partir de una cadena recibida como parámetro genera una imagen con la representación
            '             de dicha cadena a Código de barras bajo el estandar UPC-E


            'Dim Input As String = UCase(PrmCodigoBarra)
            'Dim footerFont As System.Drawing.Font = New System.Drawing.Font("Courier", 12, FontStyle.Bold)


            ''If Input = "" Then Input = "DRDIGIT.COM"
            'Dim ValidInput As String = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ-. $/+%*"
            'Dim ValidCodes As String = "4191459566472786097041902596264733841710595784729059950476626106644590602984801043246599624767444602600464775861090446866032248034439186013047842447705803036526582823575858090365863556658042365383495434978353624150635770"
            'Dim i As Integer
            'For i = 1 To Input.Length
            '    If InStr(1, ValidInput, Mid(Input, i, 1)) = 0 Then
            '        'Response.Write("Invalid input")                
            '    End If
            'Next

            'Input = UCase(IIf(Input.Substring(1) = "*", "", "*") & Input & IIf(Input.Substring(Input.Length - 1, 1) = "*", "", "*"))
            ''Dim bmp As Bitmap = New Bitmap(Input.Length * 16, 75)
            ''107 x 52
            'Dim bmp As Bitmap = New Bitmap(PrmWidht + 20, PrmHeight + 20)

            'Dim g As Graphics = Graphics.FromImage(bmp)
            'g.FillRectangle(New SolidBrush(Color.White), 0, 0, PrmWidht, PrmHeight)

            'Dim p As New Pen(Color.Black, 1)
            'Dim BarValue, BarX As Integer
            'Dim BarSlice As Short
            'For i = 1 To Input.Length
            '    Try
            '        BarValue = Val(Mid(ValidCodes, ((InStr(1, ValidInput, Mid(Input, i, 1)) - 1) * 5) + 1, 5))
            '        BarValue = IIf(BarValue = 0, 36538, BarValue)
            '        For BarSlice = 15 To 0 Step -1
            '            If BarValue >= 2 ^ BarSlice Then
            '                g.DrawLine(p, BarX, 0, BarX, 50)
            '                BarValue = BarValue - (2 ^ BarSlice)
            '            End If
            '            BarX += 1
            '        Next
            '    Catch
            '    End Try
            'Next

            'g.DrawString(PrmCodigoBarra, footerFont, Brushes.Black, PrmWidht, PrmHeight)

            ''bmp.Save("C:\codBar.gif")
            'g.Dispose()
            'Return bmp
            Dim Input As String = UCase(PrmCodigoBarra)
            Dim ValidInput As String = "0123456789"
            Dim ValidOdd As String = "0001101001100100100110111101010001101100010101111011101101101110001011"
            Dim ValidEven As String = "0100111011001100110110100001001110101110010000101001000100010010010111"
            Dim Parities As String = "EEEOOOEEOEOOEEOOEOEEOOOEEOEEOOEOOEEOEOOOEEEOEOEOEOEOOEEOOEOE"
            If Input.Length <> 7 Or Mid(Input, 1, 1) <> "0" Then
                ''Response.Write("Invalid input")
                ''Response.End()
            End If
            Dim Digit, i As Integer
            For i = 1 To Input.Length
                If InStr(1, ValidInput, Mid(Input, i, 1)) = 0 Then
                    'Response.Write("Invalid input")
                    'Response.End()
                End If
            Next
            Dim Parity As String = Mid(Parities, (Val(Mid(Input, 2, 1)) * 6) + 1, 6)
            Dim upca As String
            Select Case Val(Right(Input, 1))
                Case 0, 1, 2
                    upca = Mid(Input, 1, 3) & Mid(Input, 7, 1) & "0000" & Mid(Input, 4, 3)
                Case 3
                    upca = Mid(Input, 1, 4) & "00000" & Mid(Input, 5, 2)
                Case 4
                    upca = Mid(Input, 1, 5) & "00000" & Mid(Input, 6, 1)
                Case Else
                    upca = Mid(Input, 1, 6) & "0000" & Mid(Input, 7, 1)
            End Select
            For i = 1 To upca.Length Step 2
                Digit += (Val(Mid(upca, i, 1)) * 3)
            Next
            For i = 2 To upca.Length Step 2
                Digit += Val(Mid(upca, i, 1))
            Next
            Digit = Digit Mod 10
            If Digit > 0 Then Digit = 10 - Digit
            Input = Input & Digit.ToString()
            Dim bmp As Bitmap = New Bitmap((Input.Length * 20) + 20, 50)
            Dim g As Graphics = Graphics.FromImage(bmp)
            g.FillRectangle(New SolidBrush(Color.White), 0, 0, (Input.Length * 20) + 20, 50)
            Dim p As New Pen(Color.Black, 1)
            Dim BarValue As String
            Dim BarX As Integer
            Dim BarSlice As Short
            g.DrawLine(p, BarX, 0, BarX, 50)
            BarX += 2
            g.DrawLine(p, BarX, 0, BarX, 50)
            BarX += 2
            For i = 2 To 7
                If Mid(Parity, i - 1, 1) = "E" Then
                    BarValue = Mid(ValidEven, ((InStr(1, ValidInput, Mid(Input, i, 1)) - 1) * 7) + 1, 7)
                Else
                    BarValue = Mid(ValidOdd, ((InStr(1, ValidInput, Mid(Input, i, 1)) - 1) * 7) + 1, 7)
                End If
                For BarSlice = 1 To 7
                    If Mid(BarValue, BarSlice, 1) = "1" Then
                        g.DrawLine(p, BarX, 0, BarX, 40)
                    End If
                    BarX += 1
                Next
            Next
            BarX += 1
            g.DrawLine(p, BarX, 0, BarX, 50)
            BarX += 2
            g.DrawLine(p, BarX, 0, BarX, 50)
            BarX += 2
            g.DrawLine(p, BarX, 0, BarX, 50)

            bmp.Save("c:/imagenn.gif")
            Return bmp


            g.Dispose()
            bmp.Dispose()

        End Function

        Public Shared Function fgRegresaUsuarioMovimiento(ByVal prmObj As Object) As String
            If prmObj Is Nothing Then Return ""

            If Not prmObj.RegistroCancelacion Is Nothing AndAlso Not prmObj.RegistroCancelacion.Usuario = "" Then
                Return prmObj.RegistroCancelacion.Usuario
            Else
                If Not prmObj.RegistroUltimaModificacion Is Nothing AndAlso Not prmObj.RegistroUltimaModificacion.Usuario = "" Then
                    Return prmObj.RegistroUltimaModificacion.Usuario
                Else
                    If Not prmObj.RegistroAlta Is Nothing AndAlso Not prmObj.RegistroAlta.Usuario = "" Then
                        Return prmObj.RegistroAlta.Usuario
                    End If
                End If
            End If
            Return ""
        End Function

        Public Shared Function FgRegresaNumeroSinFormato(ByVal prmNumero As String) As Decimal
            prmNumero = Replace(prmNumero, ",", "")
            prmNumero = Replace(prmNumero, "$", "")
            If Not IsNumeric(prmNumero) OrElse prmNumero = "" OrElse prmNumero = "." Then
                Return 0
            Else
                Return CDec(prmNumero)
            End If
        End Function


        '*********************************************************** ********************
        '* FechaModificacion
        '* Fecha de ultima modificación del archivo pasado como parámetro
        '* Argumentos: strRuta => Ruta del archivo
        '* uso: FechaModificacion strRuta
        '*********************************************************** ********************


        Public Shared Function FgFechaModificacionArchivoWin(ByVal strRuta As String) As Date
            Dim fso, Archivo As Object


            fso = CreateObject("Scripting.FileSystemObject")
            Archivo = fso.GetFile(strRuta)


            FgFechaModificacionArchivoWin = Archivo.DateLastModified


            Archivo = Nothing
            fso = Nothing


        End Function ' FechaModificacion



        '*********************************************************** ********************
        '* FechaCreacion
        '* Fecha de Creación del archivo pasado como parámetro
        '* Argumentos: strRuta => Ruta del archivo
        '* uso: FechaCreacion strRuta
        '*********************************************************** ********************


        Public Shared Function FgFechaCreacionArchivoWin(ByVal strRuta As String) As Date
            Dim fso, Archivo As Object


            fso = CreateObject("Scripting.FileSystemObject")
            Archivo = fso.GetFile(strRuta)


            FgFechaCreacionArchivoWin = Archivo.DateCreated


            Archivo = Nothing
            fso = Nothing


        End Function ' FechaCreacion



        '*********************************************************** ********************
        '* FechaUltimoAcceso
        '* Fecha de ultimo acceso al archivo pasado como parámetro
        '* Argumentos: strRuta => Ruta del archivo
        '* uso: FechaUltimoAcceso strRuta
        '*********************************************************** ********************


        Public Shared Function FgFechaUltimoAccesoArchivoWin(ByVal strRuta As String) As Date
            Dim fso, Archivo As Object


            fso = CreateObject("Scripting.FileSystemObject")
            Archivo = fso.GetFile(strRuta)


            FgFechaUltimoAccesoArchivoWin = Archivo.DateLastAccessed

            Archivo = Nothing
            fso = Nothing

        End Function

        Public Shared Function fgCompruebaConexionInternet() As Boolean
            Dim Url As New System.Uri("http://www.google.com.mx")
            Dim peticion As System.Net.WebRequest
            Dim respuesta As System.Net.WebResponse
            Try
                'Creamos la peticion
                peticion = System.Net.WebRequest.Create(Url)
                'POnemos un tiempo limite
                peticion.Timeout = 5000
                'ejecutamos la peticion
                respuesta = peticion.GetResponse
                respuesta.Close()
                peticion = Nothing
                Return True
            Catch ex As Exception
                'si ocurre un error, devolvemos error
                peticion = Nothing
                Return False
            End Try
        End Function

        Public Shared Function fgObtenParametroFE(ByRef prmClavePar As String, ByVal prmSerie As Integer, ByVal prmRFCEmisor As Integer) As Object

            Dim DT As New DataTable
            Dim vcSQL As String
            Dim baseDatosAnterior = DAO.GetNombreBaseDeDatos
            DAO.SetNombreBaseDeDatos("EMPRESAS")

            fgObtenParametroFE = ""

            vcSQL = "SELECT CVALORPAR FROM FAC_PARAMETROS WHERE CCLAVEPAR = '" & prmClavePar & "' AND NRFCEMISOR = " & prmRFCEmisor & " AND NSERIE = " & prmSerie

            DAO.RegresaConsultaSQL(vcSQL, DT)

            If Not DT Is Nothing Then

                If DT.Rows.Count > 0 Then
                    fgObtenParametroFE = DT.Rows(0)("CVALORPAR")
                End If
            End If
            DAO.SetNombreBaseDeDatos(baseDatosAnterior)
            DT = Nothing

        End Function

        Public Shared Function fgTraeDigitoSerie(ByRef prmSerie As Integer) As String

            Dim DT As New DataTable
            Dim vcSQL As String

            fgTraeDigitoSerie = ""

            vcSQL = "SELECT cSerie FROM FAC_SERIES WHERE NSERIE = " & prmSerie

            DAO.RegresaConsultaSQL(vcSQL, DT)

            If Not DT Is Nothing Then
                If DT.Rows.Count > 0 Then
                    fgTraeDigitoSerie = IIf(DT.Rows(0)("cSerie") Is DBNull.Value, "", DT.Rows(0)("cSerie"))
                End If
            End If

            DT = Nothing

        End Function


        Public Shared Function fgFacturaExistente(ByVal prmSerie As Integer, ByVal prmFactura As Integer, ByVal prmRFCEmisor As Integer) As Boolean

            Dim DT As New DataTable
            Dim vcSQL As String

            fgFacturaExistente = False

            prmFactura = Strings.Right(Strings.StrDup(10, "0") & prmFactura, 10)
            vcSQL = "SELECT * FROM FAC_ENCFACTURAS WHERE nSerie = " & prmSerie & " AND nFolio = " & prmFactura & " AND nRFCEmisor = " & prmRFCEmisor

            DAO.RegresaConsultaSQL(vcSQL, DT)

            If Not DT Is Nothing AndAlso DT.Rows.Count > 0 Then Return True

        End Function

        Public Shared Sub PgLlenaComboImpuestos(ByRef prmCombo As DevExpress.XtraEditors.Repository.RepositoryItemComboBox)
            prmCombo.Items.Clear()

            Dim DT As New DataTable

            DAO.RegresaConsultaSQL("SELECT CDESCRIP FROM IMPUESTOS", DT)

            If Not DT Is Nothing AndAlso DT.Rows.Count > 0 Then

                Dim DRows() As DataRow
                Dim vRow As DataRow

                DRows = DT.Select

                For Each vRow In DRows
                    prmCombo.Items.Add(vRow("CDESCRIP"))
                Next

                DRows = Nothing
                vRow = Nothing
            End If

            DT = Nothing

        End Sub

        Public Shared Function fgObtenParametroNomina(ByVal prmParametro As String) As String

            Dim DT As New DataTable
            Dim vcSQL As String

            fgObtenParametroNomina = ""

            vcSQL = "SELECT " & prmParametro & " FROM NOM_PARAMETROS(NOLOCK)"

            Return DAO.RegresaDatoSQL(vcSQL)

        End Function

        Public Shared Sub pgEstableceFechas(ByVal prmTemporada As String, ByVal prmNomina As String, ByVal prmSemana As String, _
                                            ByRef prmControlIni As System.Windows.Forms.DateTimePicker, _
                                            ByRef prmControlFin As System.Windows.Forms.DateTimePicker)

            Dim DT As New DataTable
            Dim vcSQL As String

            vcSQL = "SELECT FECHAINI,FECHAFIN FROM VWSEMANAS(NOLOCK) WHERE TEMPORADA = '" & prmTemporada & "' AND CCVE_NOMINA = '" & prmNomina & "' AND CSEMANA = '" & prmSemana & "'"

            DAO.RegresaConsultaSQL(vcSQL, DT)

            If Not DT Is Nothing AndAlso DT.Rows.Count > 0 Then
                prmControlIni.Value = DT.Rows(0)("FECHAINI")
                prmControlFin.Value = DT.Rows(0)("FECHAFIN")
            End If

        End Sub



        Public Shared Function fgNumLetra(ByVal ACant As Double, ByVal moneda As String, ByVal Nomenclatura As String) As String
            Dim RNE(21), R100(9), R10(9), R1(9)
            Dim RLetra As String
            Dim s As Long
            Dim m As Long
            Dim A100 As Long
            Dim A10 As Long
            Dim A1 As Long
            Dim ANE As Long
            Dim Dec As Long

            RLetra = " "
            s = -1
            m = -1

            R100(1) = "CIENTO"
            R100(2) = "DOSCIENTOS"
            R100(3) = "TRESCIENTOS"
            R100(4) = "CUATROCIENTOS"
            R100(5) = "QUINIENTOS"
            R100(6) = "SEISCIENTOS"
            R100(7) = "SETECIENTOS"
            R100(8) = "OCHOCIENTOS"
            R100(9) = "NOVECIENTOS"

            R10(1) = "DIECI"
            R10(2) = "VEINTI"
            R10(3) = "TREINTA"
            R10(4) = "CUARENTA"
            R10(5) = "CINCUENTA"
            R10(6) = "SESENTA"
            R10(7) = "SETENTA"
            R10(8) = "OCHENTA"
            R10(9) = "NOVENTA"

            R1(1) = "UNO"
            R1(2) = "DOS"
            R1(3) = "TRES"
            R1(4) = "CUATRO"
            R1(5) = "CINCO"
            R1(6) = "SEIS"
            R1(7) = "SIETE"
            R1(8) = "OCHO"
            R1(9) = "NUEVE"

            RNE(10) = "DIEZ"
            RNE(11) = "ONCE"
            RNE(12) = "DOCE"
            RNE(13) = "TRECE"
            RNE(14) = "CATORCE"
            RNE(15) = "QUINCE"
            RNE(20) = "VEINTE"

            If ACant < 0 Then
                ACant = 0
            End If

            Dec = (ACant - Int(ACant)) * 100
            ACant = Int(ACant)

            Do While True

                If ACant > 999999 Then
                    m = (((ACant / 1000000) - Int(ACant / 1000000)) * 1000000)
                    ACant = Int(ACant / 1000000)
                ElseIf ACant > 999 Then
                    s = (((ACant / 1000) - Int(ACant / 1000)) * 1000)
                    ACant = Int(ACant / 1000)
                End If


                If ACant = 0 Then
                    RLetra = RLetra + "CERO"
                ElseIf ACant = 100 Then
                    RLetra = RLetra + "CIEN"
                Else

                    A100 = Int(ACant / 100)
                    ANE = ACant - (A100 * 100)
                    A10 = Int(ANE / 10)
                    A1 = ANE - (A10 * 10)
                    If A100 <> 0 Then
                        RLetra = RLetra + R100(A100)
                    End If

                    If ACant > 100 And (A10 > 0 Or A1 > 0) Then
                        RLetra = RLetra + " "
                    End If

                    If ANE > 9 And ANE < 16 Or ANE = 20 Then
                        RLetra = RLetra + RNE(ANE)
                    Else
                        If A10 <> 0 Then
                            RLetra = RLetra + R10(A10)
                        End If

                        If A1 > 0 Then
                            If A10 > 2 Then
                                RLetra = RLetra + " Y " + R1(A1)
                            Else
                                RLetra = RLetra + R1(A1)

                            End If
                        End If
                    End If
                End If

                If m <> -1 Then
                    If RLetra = " UNO" Then
                        RLetra = " UN MILLON "
                    Else
                        RLetra = RLetra & " MILLONES "
                    End If
                    ACant = m
                    If ACant = 0 Then
                        Exit Do
                    End If
                    m = -1

                ElseIf s <> -1 Then
                    If RLetra = " UNO" Then
                        RLetra = " UN"
                    End If
                    RLetra = RLetra & " MIL "
                    ACant = s
                    If ACant = 0 Then
                        Exit Do
                    End If
                    s = -1
                Else
                    Exit Do
                End If
            Loop
            'fgNumLetra = RLetra + " PESOS " + Format(Dec, "00") + "/100" + " M.N."
            fgNumLetra = RLetra + " " + moneda + " " + Format(Dec, "00") + "/100 " + Nomenclatura


        End Function

        Public Shared Sub PgLlenaComboUnidades(ByRef prmCombo As DevExpress.XtraEditors.Repository.RepositoryItemComboBox)
            prmCombo.Items.Clear()

            Dim DT As New DataTable

            DAO.RegresaConsultaSQL("SELECT CNOMBRE FROM CTL_UNIDADES", DT)

            If Not DT Is Nothing AndAlso DT.Rows.Count > 0 Then

                Dim DRows() As DataRow
                Dim vRow As DataRow

                DRows = DT.Select

                For Each vRow In DRows
                    prmCombo.Items.Add(vRow("CNOMBRE"))
                Next

                DRows = Nothing
                vRow = Nothing
            End If

            DT = Nothing

        End Sub

        Public Shared Function fgCreaVista(ByVal prmQuery As String, ByVal prmVista As String) As Boolean

            Dim vcSQL As String
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia

            vcSQL = "if exists(select name from sysobjects where name = '" & prmVista & "' and type = 'V')"
            vcSQL = vcSQL & vbCrLf & "DROP VIEW dbo." & prmVista

            If DAO.EjecutaComandoSQL(vcSQL) Then

                vcSQL = "CREATE VIEW dbo." & prmVista
                vcSQL = vcSQL & vbCrLf & " as "
                vcSQL = vcSQL & vbCrLf & prmQuery

                Return DAO.EjecutaComandoSQL(vcSQL)

            End If

            Return False

        End Function


        Public Shared Function fgRegresaRFCEmisor(ByVal prmSerie As Integer) As Integer

            Dim DT As New DataTable

            fgRegresaRFCEmisor = 0

            DAO.RegresaConsultaSQL("SELECT NRFCEMISOR FROM FAC_SERIES WHERE NSERIE = " & prmSerie, DT)

            If Not DT Is Nothing AndAlso DT.Rows.Count > 0 Then
                fgRegresaRFCEmisor = DT.Rows(0)("NRFCEMISOR")
            End If
            DT = Nothing

        End Function

        Public Shared Function fgRegresaImpuesto(ByVal prmDescImp As String) As Decimal

            Dim DT As New DataTable

            fgRegresaImpuesto = 0

            DAO.RegresaConsultaSQL("SELECT NIMPUESTO FROM IMPUESTOS WHERE CDESCRIP = '" & prmDescImp & "'", DT)

            If Not DT Is Nothing AndAlso DT.Rows.Count > 0 Then
                fgRegresaImpuesto = DT.Rows(0)("NIMPUESTO")
            End If
            DT = Nothing
        End Function


        Public Shared Function fgObtieneImpuestosTrasladados() As DataTable

            Dim DT As New DataTable
            DAO.RegresaConsultaSQL("SELECT cDescrip,nImpuesto FROM IMPUESTOS", DT)
            Return DT

        End Function

        Public Shared Function fgObtenFolioSerie(ByVal prmSerie As Integer) As Integer
            Dim DAO As Sistema.DataAccessCls = DataAccessCls.DevuelveInstancia
            Try
                fgObtenFolioSerie = DAO.RegresaDatoSQL("SELECT COALESCE(NFOLIOACTUAL,0) AS NFOLIO FROM FAC_SERIES WHERE NSERIE = " & prmSerie)
            Catch ex As Exception
                fgObtenFolioSerie = 0
            End Try
        End Function


        Public Shared Function fgObtenParametroGeneralRecepcionFacturacion(ByRef prmClavePar As String) As Object

            Dim DT As New DataTable
            Dim vcSQL As String

            fgObtenParametroGeneralRecepcionFacturacion = ""

            vcSQL = "SELECT CVALORPAR FROM FAC_PARRECFACT WHERE CCLAVEPAR = '" & prmClavePar & "'"

            DAO.RegresaConsultaSQL(vcSQL, DT)

            If Not DT Is Nothing Then

                If DT.Rows.Count > 0 Then
                    fgObtenParametroGeneralRecepcionFacturacion = DT.Rows(0)("CVALORPAR")
                End If
            End If

            DT = Nothing

        End Function


        Public Shared Function fgNumeroLetras(ByVal numero As String, ByVal moneda As String, ByVal Nomenclatura As String) As String



            '********Declara variables de tipo cadena************
            Dim palabras, entero, dec, flag As String
            palabras = ""
            entero = ""
            dec = ""
            flag = ""

            '********Declara variables de tipo entero***********
            Dim num, x, y As Integer

            flag = "N"

            '**********Número Negativo***********
            If Mid(numero, 1, 1) = "-" Then
                numero = Mid(numero, 2, numero.ToString.Length - 1).ToString
                palabras = "menos "
            End If

            '**********Si tiene ceros a la izquierda*************
            For x = 1 To numero.ToString.Length
                If Mid(numero, 1, 1) = "0" Then
                    numero = Trim(Mid(numero, 2, numero.ToString.Length).ToString)
                    If Trim(numero.ToString.Length) = 0 Then palabras = ""
                Else
                    Exit For
                End If
            Next

            '*********Dividir parte entera y decimal************
            For y = 1 To Len(numero)
                If Mid(numero, y, 1) = "." Then
                    flag = "S"
                Else
                    If flag = "N" Then
                        entero = entero + Mid(numero, y, 1)
                    Else
                        dec = dec + Mid(numero, y, 1)
                    End If
                End If
            Next y

            If Len(dec) = 1 Then dec = dec & "0"

            '**********proceso de conversión***********
            flag = "N"

            If Val(numero) <= 999999999 Then
                For y = Len(entero) To 1 Step -1
                    num = Len(entero) - (y - 1)
                    Select Case y
                        Case 3, 6, 9
                            '**********Asigna las palabras para las centenas***********
                            Select Case Mid(entero, num, 1)
                                Case "1"
                                    If Mid(entero, num + 1, 1) = "0" And Mid(entero, num + 2, 1) = "0" Then
                                        palabras = palabras & "cien "
                                    Else
                                        palabras = palabras & "ciento "
                                    End If
                                Case "2"
                                    palabras = palabras & "doscientos "
                                Case "3"
                                    palabras = palabras & "trescientos "
                                Case "4"
                                    palabras = palabras & "cuatrocientos "
                                Case "5"
                                    palabras = palabras & "quinientos "
                                Case "6"
                                    palabras = palabras & "seiscientos "
                                Case "7"
                                    palabras = palabras & "setecientos "
                                Case "8"
                                    palabras = palabras & "ochocientos "
                                Case "9"
                                    palabras = palabras & "novecientos "
                            End Select
                        Case 2, 5, 8
                            '*********Asigna las palabras para las decenas************
                            Select Case Mid(entero, num, 1)
                                Case "1"
                                    If Mid(entero, num + 1, 1) = "0" Then
                                        flag = "S"
                                        palabras = palabras & "diez "
                                    End If
                                    If Mid(entero, num + 1, 1) = "1" Then
                                        flag = "S"
                                        palabras = palabras & "once "
                                    End If
                                    If Mid(entero, num + 1, 1) = "2" Then
                                        flag = "S"
                                        palabras = palabras & "doce "
                                    End If
                                    If Mid(entero, num + 1, 1) = "3" Then
                                        flag = "S"
                                        palabras = palabras & "trece "
                                    End If
                                    If Mid(entero, num + 1, 1) = "4" Then
                                        flag = "S"
                                        palabras = palabras & "catorce "
                                    End If
                                    If Mid(entero, num + 1, 1) = "5" Then
                                        flag = "S"
                                        palabras = palabras & "quince "
                                    End If
                                    If Mid(entero, num + 1, 1) > "5" Then
                                        flag = "N"
                                        palabras = palabras & "dieci"
                                    End If
                                Case "2"
                                    If Mid(entero, num + 1, 1) = "0" Then
                                        palabras = palabras & "veinte "
                                        flag = "S"
                                    Else
                                        palabras = palabras & "veinti"
                                        flag = "N"
                                    End If
                                Case "3"
                                    If Mid(entero, num + 1, 1) = "0" Then
                                        palabras = palabras & "treinta "
                                        flag = "S"
                                    Else
                                        palabras = palabras & "treinta y "
                                        flag = "N"
                                    End If
                                Case "4"
                                    If Mid(entero, num + 1, 1) = "0" Then
                                        palabras = palabras & "cuarenta "
                                        flag = "S"
                                    Else
                                        palabras = palabras & "cuarenta y "
                                        flag = "N"
                                    End If
                                Case "5"
                                    If Mid(entero, num + 1, 1) = "0" Then
                                        palabras = palabras & "cincuenta "
                                        flag = "S"
                                    Else
                                        palabras = palabras & "cincuenta y "
                                        flag = "N"
                                    End If
                                Case "6"
                                    If Mid(entero, num + 1, 1) = "0" Then
                                        palabras = palabras & "sesenta "
                                        flag = "S"
                                    Else
                                        palabras = palabras & "sesenta y "
                                        flag = "N"
                                    End If
                                Case "7"
                                    If Mid(entero, num + 1, 1) = "0" Then
                                        palabras = palabras & "setenta "
                                        flag = "S"
                                    Else
                                        palabras = palabras & "setenta y "
                                        flag = "N"
                                    End If
                                Case "8"
                                    If Mid(entero, num + 1, 1) = "0" Then
                                        palabras = palabras & "ochenta "
                                        flag = "S"
                                    Else
                                        palabras = palabras & "ochenta y "
                                        flag = "N"
                                    End If
                                Case "9"
                                    If Mid(entero, num + 1, 1) = "0" Then
                                        palabras = palabras & "noventa "
                                        flag = "S"
                                    Else
                                        palabras = palabras & "noventa y "
                                        flag = "N"
                                    End If
                            End Select
                        Case 1, 4, 7
                            '*********Asigna las palabras para las unidades*********
                            Select Case Mid(entero, num, 1)
                                Case "1"
                                    If flag = "N" Then
                                        If y = 1 Then
                                            palabras = palabras & "uno "
                                        Else
                                            palabras = palabras & "un "
                                        End If
                                    End If
                                Case "2"
                                    If flag = "N" Then palabras = palabras & "dos "
                                Case "3"
                                    If flag = "N" Then palabras = palabras & "tres "
                                Case "4"
                                    If flag = "N" Then palabras = palabras & "cuatro "
                                Case "5"
                                    If flag = "N" Then palabras = palabras & "cinco "
                                Case "6"
                                    If flag = "N" Then palabras = palabras & "seis "
                                Case "7"
                                    If flag = "N" Then palabras = palabras & "siete "
                                Case "8"
                                    If flag = "N" Then palabras = palabras & "ocho "
                                Case "9"
                                    If flag = "N" Then palabras = palabras & "nueve "
                            End Select
                    End Select

                    '***********Asigna la palabra mil***************
                    If y = 4 Then
                        If Mid(entero, 6, 1) <> "0" Or Mid(entero, 5, 1) <> "0" Or Mid(entero, 4, 1) <> "0" Or _
                        (Mid(entero, 6, 1) = "0" And Mid(entero, 5, 1) = "0" And Mid(entero, 4, 1) = "0" And _
                        Len(entero) <= 6) Then palabras = palabras & "mil "
                    End If

                    '**********Asigna la palabra millón*************
                    If y = 7 Then
                        If Len(entero) = 7 And Mid(entero, 1, 1) = "1" Then
                            palabras = palabras & "millón "
                        Else
                            palabras = palabras & "millones "
                        End If
                    End If
                Next y

                '**********Une la parte entera y la parte decimal*************

                fgNumeroLetras = UCase(palabras) + IIf(Strings.Right(UCase(palabras), 7) = "MILLÓN ", "DE ", "") + UCase(moneda) + " " + IIf(dec.Trim = "" Or dec.Trim = "00", "00", " CON " & dec) + "/100 " + UCase(Nomenclatura)

                'If dec <> "" Then
                '    fgNumeroLetras = palabras & "con " & dec
                'Else
                '    fgNumeroLetras = palabras
                'End If
            Else
                fgNumeroLetras = ""
            End If
        End Function


#Region "Sistema Integral Panamá:"

        ' Descripción : Métodos para manipular los mensajes que utilizará el Sistema Integral Panamá"
        ' Fecha de Creación : Jueves, 26 de Junio del 2008

        ' <NombreDato> guardado con èxito
        ' Falta Proporcionar <Nombre del Dato>
        ' Donde <Nombre del Dato> deberà ser por ej: "Descripciòn", "Unidad Base", segùn sea el caso.
        Public Shared Function FgGetDatoGuardado(ByVal Clave As Object, ByVal EsCatalogo As Boolean) As String
            Dim strClave As String = "Folio: "
            If EsCatalogo Then
                strClave = "Código: "
            End If
            Return GlobalSistemaRegistroGuardadoExito & ": " & vbCrLf & strClave & CStr(Clave)
        End Function

        Public Shared Function FgGetDatoGuardado(ByVal Clave As Object) As String
            Dim strClave As String = "Precaptura: "
            Return GlobalSistemaRegistroGuardadoExito & ": " & vbCrLf & strClave & CStr(Clave)
        End Function
        Public Shared Function FgGetDatoGuardado(ByVal Clave As Object, ByVal prmDato As String) As String
            Return GlobalSistemaRegistroGuardadoExito & ": " & vbCrLf & prmDato & ": " & CStr(Clave)
        End Function

#End Region

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub
    End Class

    Public Class WebServiceGenerico_Actualizacion_Consultas
        Inherits WebServiceGenerico_Actualizacion


        Private atrResultSet As DataSet

        Public Sub New()
            MyBase.New()
        End Sub

        Public Property ResultSet() As DataSet
            Get
                Return atrResultSet
            End Get
            Set(ByVal Value As DataSet)
                atrResultSet = Value
            End Set
        End Property


        ''Agregado por Lic. David Adan Velazquez Sanchez 
        ''Al enviar el dataset por referencia, agregamos a esta la serie de consultas que le especifiquemos
        Public Sub AgregarConsulta(ByVal vComandoSQL As String)
            Dim nuevaencrip As String = ""
            Dim nuevaencrip2 As String = ""

            Dim vDataTable As New DataTable
            vDataTable.Columns.Add("Consulta".ToUpper())
            Dim vRow As DataRow = vDataTable.NewRow
            vRow("Consulta") = vComandoSQL
            vDataTable.Rows.Add(vRow)

            DataSet_Generico_Actualizacion.Tables.Add(vDataTable)
        End Sub

        'Public Overloads Function Ejecutar(ByRef vMensajeError As String) As Boolean
        '    If DataSet_Generico_Actualizacion.Tables.Count = 0 Then
        '        Return True
        '    End If
        '    Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        '    Dim d As New wsCXCPagos.AplicaPagos
        '    Dim param As Comun.Parametros.ClsParametrosSucursal = Comunes.Comun.ClsTools.ParamtetrosSucursal
        '    Dim miCanalDistribucion As Dominio.Catalogos.ClsCanalDistribucion = Dominio.Catalogos.FabricaCatalogos.ObtenCanalDistribucion(param.CanalDistribucion)


        '    d.Url = DAO.ParametroAdministradoObtener("WS", "SERVIDOR_WS_EMPRESA_" & miCanalDistribucion.Empresa.Folio.ToString) & DAO.ParametroAdministradoObtener("WS", "WS_wsCXC")

        '    Try
        '        atrResultSet = d.WebServiceGenerico_GrabaTablas_y_EjecutaComandos_ConConsultas(DataSet_Generico_Actualizacion, vMensajeError)
        '        If atrResultSet Is Nothing Then
        '            Return False
        '        End If
        '    Catch ex As Exception
        '        Return False
        '    End Try
        '    Return True
        'End Function

    End Class

    Public Class WebServiceGenerico_Actualizacion
        Inherits Comunes.Comun.Escribano

        Protected Shared DataSet_Generico_Actualizacion As New DataSet
        Protected Shared Adapter_Generico_Actualizacion As New ArrayList

        Public Sub New()
            DataSet_Generico_Actualizacion.Clear()
        End Sub
        Public Function Agregar(ByVal vTabla_de_Datos As DataTable, ByVal vAdaptador As SqlClient.SqlDataAdapter, ByVal vTableName As String) As Boolean
            Try

                Dim NombreTabla As String = ""
                For Each tabla As DataTable In DataSet_Generico_Actualizacion.Tables
                    If tabla.TableName = vTableName Then
                        NombreTabla = tabla.TableName
                    End If
                Next

                If NombreTabla = "" Then
                    vTabla_de_Datos.TableName = vTableName
                    DataSet_Generico_Actualizacion.Tables.Add(vTabla_de_Datos)
                    Adapter_Generico_Actualizacion.Add(vAdaptador)
                Else
                    Dim vDataRow As DataRow = vTabla_de_Datos.Rows(0)
                    vTabla_de_Datos.BeginLoadData()
                    DataSet_Generico_Actualizacion.Tables(NombreTabla).LoadDataRow(vDataRow.ItemArray, False)
                    vTabla_de_Datos.EndLoadData()
                End If
                Return True
            Catch ex As Exception
                Return False
            End Try

        End Function

        Public Sub Agregar(ByVal vComandoSQL As String)
            Dim nuevaencrip As String = ""
            Dim nuevaencrip2 As String = ""

            Dim vDataTable As New DataTable
            vDataTable.Columns.Add("Comando")
            Dim vRow As DataRow = vDataTable.NewRow
            vRow("Comando") = vComandoSQL
            vDataTable.Rows.Add(vRow)


            DataSet_Generico_Actualizacion.Tables.Add(vDataTable)
            Adapter_Generico_Actualizacion.Add("Comando")
        End Sub



        Public ReadOnly Property DataSet() As DataSet
            Get
                Return DataSet_Generico_Actualizacion
            End Get
        End Property

        'Public Shared Function Ejecutar(ByVal GrabaLocalEnCasodeFalla As Boolean, Optional ByRef vMensajeError As String = "") As Boolean
        '    If DataSet_Generico_Actualizacion.Tables.Count = 0 Then
        '        Return True
        '    End If
        '    Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        '    Dim d As New wsCXCPagos.AplicaPagos
        '    Dim param As Comun.Parametros.ClsParametrosSucursal = Comunes.Comun.ClsTools.ParamtetrosSucursal
        '    Dim miCanalDistribucion As Dominio.Catalogos.ClsCanalDistribucion = Dominio.Catalogos.FabricaCatalogos.ObtenCanalDistribucion(param.CanalDistribucion)


        '    d.Url = DAO.ParametroAdministradoObtener("WS", "SERVIDOR_WS_EMPRESA_" & miCanalDistribucion.Empresa.Folio.ToString) & DAO.ParametroAdministradoObtener("WS", "WS_wsCXC")
        '    'd.Url = "http://localhost/cxc/Reportes.asmx"

        '    Try
        '        DataSet_Generico_Actualizacion.AcceptChanges()
        '        If d.WebServiceGenerico_GrabaTablas_y_EjecutaComandos(DataSet_Generico_Actualizacion, vMensajeError) Then
        '            DataSet_Generico_Actualizacion.Clear()
        '            Adapter_Generico_Actualizacion.Clear()
        '            Return True
        '        Else
        '            DataSet_Generico_Actualizacion.Tables.Clear()
        '            Adapter_Generico_Actualizacion.Clear()
        '            Return False
        '        End If
        '    Catch ex As Exception
        '        If GrabaLocalEnCasodeFalla Then
        '            Dim vComando As String = ""
        '            For I As Integer = 0 To DataSet_Generico_Actualizacion.Tables.Count - 1
        '                If Adapter_Generico_Actualizacion(I).GetType Is vComando.GetType Then
        '                    If Not DAO.EjecutaComandoSQL(DataSet_Generico_Actualizacion.Tables(I).Rows(0)(0)) Then
        '                        DataSet_Generico_Actualizacion.Tables.Clear()
        '                        Adapter_Generico_Actualizacion.Clear()
        '                        Return False
        '                    End If

        '                Else
        '                    If Not GuardarGenerico(Adapter_Generico_Actualizacion(I), DataSet_Generico_Actualizacion.Tables(I), True, True) Then
        '                        DataSet_Generico_Actualizacion.Tables.Clear()
        '                        Adapter_Generico_Actualizacion.Clear()
        '                        Return False
        '                    End If
        '                End If
        '            Next
        '            DataSet_Generico_Actualizacion.Tables.Clear()
        '            Adapter_Generico_Actualizacion.Clear()
        '            Return True
        '        End If
        '        DataSet_Generico_Actualizacion.Tables.Clear()
        '        Adapter_Generico_Actualizacion.Clear()
        '        Return False
        '    End Try
        '    Return True
        'End Function

    End Class

    Public Class Validaciones
        Private atrAgrupador As String
        Private atrMensaje As String
        Private atrOrden As Integer
        Public Sub New(ByVal prmAgrupador As String, ByVal prmMensaje As String, ByVal prmOrden As Integer)
            atrAgrupador = prmAgrupador.ToUpper
            atrMensaje = prmMensaje
            atrOrden = prmOrden
        End Sub
        Public ReadOnly Property Agrupador() As String
            Get
                Return atrAgrupador
            End Get
        End Property
        Public ReadOnly Property Mensaje() As String
            Get
                Return atrMensaje
            End Get
        End Property
        Public ReadOnly Property Orden() As Integer
            Get
                Return atrOrden
            End Get
        End Property
    End Class

    Public Class MiClaseDeOrdenamiento
        Implements IComparer

        Public atrTipoComparacion As TiposComparacion
        Public Sub New(ByVal prmTipoCompracacion As TiposComparacion)
            atrTipoComparacion = prmTipoCompracacion
        End Sub

        Enum TiposComparacion As Integer
            VisibleIndex = 1
            GroupIndex = 2
        End Enum
        ' Calls CaseInsensitiveComparer.Compare with the parameters reversed.
        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer _
           Implements IComparer.Compare
            If atrTipoComparacion = TiposComparacion.VisibleIndex Then
                Return New CaseInsensitiveComparer().Compare(x.VisibleIndex, y.VisibleIndex)
            Else
                Return New CaseInsensitiveComparer().Compare(x.GroupIndex, y.GroupIndex)
            End If
        End Function 'IComparer.Compare



    End Class 'myReverserClass


End Namespace
