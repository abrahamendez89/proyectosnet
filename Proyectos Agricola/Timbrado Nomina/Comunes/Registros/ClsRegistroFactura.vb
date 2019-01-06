Namespace Comunes.Registros


    Public Class ClsRegistroFactura

        Private atrnFactura As Long
        Private artRFCEmisor As Integer
        Private atrSUCURSAL As Integer
        Private atrSERIE As String
        Private atrFACTURA As Integer
        Private atrDFECHA As DateTime
        Private atrCliente As Integer
        Private atrCCVE_COND As String
        Private atrNSUBTOTAL As Decimal
        Private atrNDESCUENTO As Decimal
        Private atrNSUBTOTALDD As Decimal
        Private atrNIMPUESTOS As Decimal
        Private atrNIVARETENIDO As Decimal
        Private atrNISRRETENIDO As Decimal
        Private atrNIMPORTE As Decimal
        Private atrCSTATUS As String
        Private atrCOBSERVACION As String
        Private atrCMONEDA As String
        Private atrNPARIDAD As Decimal
        Private atrCTIPODOCUMENTO As String
        Private atrCFACTURANC As String
        Private atrCTIPOPAGO As String
        Private atrDFECHACAN As DateTime
        Private atrCCERTIFICADO As String
        Private atrCSELLO As String
        Private atrCCADENA As String
        Private atrCIMPORTECONLETRA As String
        Private atrUUID As String
        Private atrDFECHATIMBRADO As String
        Private atrCSELLOSAT As String
        Private atrCREGIMEN As String
        Private atrCLUGAREXPEDICION As String
        Private atrDTDetalle As New DataTable
        Private atrCCUENTA As String
        Private atrnSerie As Integer

        Private atrReferencia1 As String
        Private atrReferencia2 As String
        Private atrReferencia3 As String

        Private atrNumeroAprobacion As String
        Private atrAnioAprobacion As String
        Private atrMetodoPago As String

        Private atrDTTraslados As New DataTable
        Private atrDTRetenciones As New DataTable
        Private atrCadena As String
        Private atrSello As String


        Private atrClienteRFC As String
        Private atrClienteDescripcion As String
        Private atrClienteCalle As String
        Private atrClienteNoInt As String
        Private atrClienteNoExt As String
        Private atrClienteColonia As String
        Private atrClienteLocalidad As String
        Private atrClienteCiudad As String
        Private atrClienteEstado As String
        Private atrClientePais As String
        Private atrClienteCodigoPostal As String

        Private atrEsCFDI As Boolean



        Public Property nFactura() As Long
            Get
                Return atrnFactura
            End Get
            Set(ByVal value As Long)
                atrnFactura = value
            End Set
        End Property

        Public Property RFCEmisor() As Integer
            Get
                Return artRFCEmisor
            End Get
            Set(ByVal value As Integer)
                artRFCEmisor = value
            End Set
        End Property

        Public Property SUCURSAL() As Integer
            Get
                Return atrSUCURSAL
            End Get
            Set(ByVal value As Integer)
                atrSUCURSAL = value
            End Set
        End Property

        Public Property SERIE() As String
            Get
                Return atrSERIE
            End Get
            Set(ByVal value As String)
                atrSERIE = value
            End Set
        End Property

        Public Property FACTURA() As Integer
            Get
                Return atrFACTURA
            End Get
            Set(ByVal value As Integer)
                atrFACTURA = value
            End Set
        End Property

        Public Property FECHA() As DateTime
            Get
                Return atrDFECHA
            End Get
            Set(ByVal Value As DateTime)
                atrDFECHA = Value
            End Set
        End Property

        Public Property Cliente() As Integer
            Get
                Return atrCliente
            End Get
            Set(ByVal value As Integer)
                atrCliente = value
            End Set
        End Property

        Public Property CCVE_COND() As String
            Get
                Return atrCCVE_COND
            End Get
            Set(ByVal value As String)
                atrCCVE_COND = value
            End Set
        End Property

        Public Property SUBTOTAL() As Decimal
            Get
                Return atrNSUBTOTAL
            End Get
            Set(ByVal Value As Decimal)
                atrNSUBTOTAL = Value
            End Set
        End Property


        Public Property DESCUENTO() As Decimal
            Get
                Return atrNDESCUENTO
            End Get
            Set(ByVal Value As Decimal)
                atrNDESCUENTO = Value
            End Set
        End Property


        Public Property IMPUESTOS() As Decimal
            Get
                Return atrNIMPUESTOS
            End Get
            Set(ByVal Value As Decimal)
                atrNIMPUESTOS = Value
            End Set
        End Property


        Public Property IVARETENIDO() As Decimal
            Get
                Return atrNIVARETENIDO
            End Get
            Set(ByVal Value As Decimal)
                atrNIVARETENIDO = Value
            End Set
        End Property


        Public Property ISRRETENIDO() As Decimal
            Get
                Return atrNISRRETENIDO
            End Get
            Set(ByVal Value As Decimal)
                atrNISRRETENIDO = Value
            End Set
        End Property


        Public Property IMPORTE() As Decimal
            Get
                Return atrNIMPORTE
            End Get
            Set(ByVal Value As Decimal)
                atrNIMPORTE = Value
            End Set
        End Property

        Public Property CSTATUS() As String
            Get
                Return atrCSTATUS
            End Get
            Set(ByVal value As String)
                atrCSTATUS = value
            End Set
        End Property

        Public Property OBSERVACION() As String
            Get
                Return atrCOBSERVACION
            End Get
            Set(ByVal Value As String)
                atrCOBSERVACION = Value
            End Set
        End Property

        Public Property CMONEDA() As String
            Get
                Return atrCMONEDA
            End Get
            Set(ByVal value As String)
                atrCMONEDA = value
            End Set
        End Property

        Public Property PARIDAD() As Decimal
            Get
                Return atrNPARIDAD
            End Get
            Set(ByVal Value As Decimal)
                atrNPARIDAD = Value
            End Set
        End Property

        Public Property CTIPODOCUMENTO() As String
            Get
                Return atrCTIPODOCUMENTO
            End Get
            Set(ByVal value As String)
                atrCTIPODOCUMENTO = value
            End Set
        End Property

        Public Property FACTURANC() As String
            Get
                Return atrCFACTURANC
            End Get
            Set(ByVal Value As String)
                atrCFACTURANC = Value
            End Set
        End Property

        Public Property CTIPOPAGO() As String
            Get
                Return atrCTIPOPAGO
            End Get
            Set(ByVal value As String)
                atrCTIPOPAGO = value
            End Set
        End Property

        Public Property IMPORTECONLETRA() As String
            Get
                Return atrCIMPORTECONLETRA
            End Get
            Set(ByVal Value As String)
                atrCIMPORTECONLETRA = Value
            End Set
        End Property


        Public Property SUBTOTALDD() As Decimal
            Get
                Return atrNSUBTOTALDD
            End Get
            Set(ByVal Value As Decimal)
                atrNSUBTOTALDD = Value
            End Set
        End Property

        Public Property FECHACAN() As DateTime
            Get
                Return atrDFECHACAN
            End Get
            Set(ByVal Value As DateTime)
                atrDFECHACAN = Value
            End Set
        End Property

        Public Property CERTIFICADO() As String
            Get
                Return atrCCERTIFICADO
            End Get
            Set(ByVal Value As String)
                atrCCERTIFICADO = Value
            End Set
        End Property

        Public Property UID() As String
            Get
                Return atrUUID
            End Get
            Set(ByVal Value As String)
                atrUUID = Value
            End Set
        End Property

        Public Property FECHATIMBRADO() As DateTime
            Get
                Return atrDFECHATIMBRADO
            End Get
            Set(ByVal Value As DateTime)
                atrDFECHATIMBRADO = Value
            End Set
        End Property

        Public Property SELLOSAT() As String
            Get
                Return atrCSELLOSAT
            End Get
            Set(ByVal Value As String)
                atrCSELLOSAT = Value
            End Set
        End Property

        Public Property REGIMEN() As String
            Get
                Return atrCREGIMEN
            End Get
            Set(ByVal Value As String)
                atrCREGIMEN = Value
            End Set
        End Property

        Public Property LUGAREXPEDICION() As String
            Get
                Return atrCLUGAREXPEDICION
            End Get
            Set(ByVal Value As String)
                atrCLUGAREXPEDICION = Value
            End Set
        End Property

        Public Property DTDetalle() As DataTable
            Get
                Return atrDTDetalle
            End Get
            Set(ByVal value As DataTable)
                atrDTDetalle = value
            End Set
        End Property

        Public Property DTTraslados() As DataTable
            Get
                Return atrDTTraslados
            End Get
            Set(ByVal value As DataTable)
                atrDTTraslados = value
            End Set
        End Property

        Public Property DTRetenciones() As DataTable
            Get
                Return atrDTRetenciones
            End Get
            Set(ByVal value As DataTable)
                atrDTRetenciones = value
            End Set
        End Property

        Public Property CCUENTA() As String
            Get
                Return atrCCUENTA
            End Get
            Set(ByVal value As String)
                atrCCUENTA = value
            End Set
        End Property

        Public Property Referencia1() As String
            Get
                Return atrReferencia1
            End Get
            Set(ByVal value As String)
                atrReferencia1 = value
            End Set
        End Property

        Public Property Referencia2() As String
            Get
                Return atrReferencia2
            End Get
            Set(ByVal value As String)
                atrReferencia2 = value
            End Set
        End Property

        Public Property Referencia3() As String
            Get
                Return atrReferencia3
            End Get
            Set(ByVal value As String)
                atrReferencia3 = value
            End Set
        End Property

        Public Property NSERIE() As Integer
            Get
                Return atrnSerie
            End Get
            Set(ByVal value As Integer)
                atrnSerie = value
            End Set
        End Property

        Public Property NumeroAprobacion() As String
            Get
                Return atrNumeroAprobacion
            End Get
            Set(ByVal value As String)
                atrNumeroAprobacion = value
            End Set
        End Property

        Public Property AnioAprobacion() As String
            Get
                Return atrAnioAprobacion
            End Get
            Set(ByVal value As String)
                atrAnioAprobacion = value
            End Set
        End Property

        Public Property MetodoPago() As String
            Get
                Return atrMetodoPago
            End Get
            Set(ByVal value As String)
                atrMetodoPago = value
            End Set
        End Property

        Public Property Cadena() As String
            Get
                Return atrCadena
            End Get
            Set(ByVal value As String)
                atrCadena = value
            End Set
        End Property

        Public Property Sello() As String
            Get
                Return atrSello
            End Get
            Set(ByVal value As String)
                atrSello = value
            End Set
        End Property

        Public Property ClienteRFC() As String
            Get
                Return atrClienteRFC
            End Get
            Set(ByVal value As String)
                atrClienteRFC = value
            End Set
        End Property

        Public Property ClienteDescripcion() As String
            Get
                Return atrClienteDescripcion
            End Get
            Set(ByVal value As String)
                atrClienteDescripcion = value
            End Set
        End Property

        Public Property ClienteCalle() As String
            Get
                Return atrClienteCalle
            End Get
            Set(ByVal value As String)
                atrClienteCalle = value
            End Set
        End Property

        Public Property ClienteNoInt() As String
            Get
                Return atrClienteNoInt
            End Get
            Set(ByVal value As String)
                atrClienteNoInt = value
            End Set
        End Property

        Public Property ClienteNoExt() As String
            Get
                Return atrClienteNoExt
            End Get
            Set(ByVal value As String)
                atrClienteNoExt = value
            End Set
        End Property

        Public Property ClienteColonia() As String
            Get
                Return atrClienteColonia
            End Get
            Set(ByVal value As String)
                atrClienteColonia = value
            End Set
        End Property

        Public Property ClienteLocalidad() As String
            Get
                Return atrClienteLocalidad
            End Get
            Set(ByVal value As String)
                atrClienteLocalidad = value
            End Set
        End Property

        Public Property ClienteCiudad() As String
            Get
                Return atrClienteCiudad
            End Get
            Set(ByVal value As String)
                atrClienteCiudad = value
            End Set
        End Property

        Public Property ClienteEstado() As String
            Get
                Return atrClienteEstado
            End Get
            Set(ByVal value As String)
                atrClienteEstado = value
            End Set
        End Property

        Public Property ClientePais() As String
            Get
                Return atrClientePais
            End Get
            Set(ByVal value As String)
                atrClientePais = value
            End Set
        End Property

        Public Property ClienteCodigoPostal() As String
            Get
                Return atrClienteCodigoPostal
            End Get
            Set(ByVal value As String)
                atrClienteCodigoPostal = value
            End Set
        End Property

        Public Property EsCFDI() As Boolean
            Get
                Return atrEsCFDI
            End Get
            Set(ByVal value As Boolean)
                atrEsCFDI = value
            End Set
        End Property

        Public Sub New()
            MyBase.new()
        End Sub

        Public Function Guardar() As Boolean
            Return EscribanoRegistros.Guardar(Me)
        End Function

        Public Function Cancelar() As Boolean
            Return EscribanoRegistros.Cancelar(Me)
        End Function

        Public Function ActualizaFechaCancelacion() As Boolean
            Return EscribanoRegistros.ActualizaFechaCancelacion(Me)
        End Function

        Public Function ActualizaDatosTimbrado() As Boolean
            Return EscribanoRegistros.ActualizaDatosTimbrado(Me)
        End Function



    End Class

End Namespace

