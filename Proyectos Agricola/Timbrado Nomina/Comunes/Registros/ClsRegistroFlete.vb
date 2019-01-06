Namespace Comunes.Registros
    Public Class ClsRegistroFlete

        Private atrnFactura As Decimal
        Private atrnMovimientoFlete As Decimal
        Private atrcRuta As String
        Private atrcOrigenRemitente As String
        Private atrcDestinoDestinatario As String
        Private atrnKilos As Decimal
        Private atrdFechaCarga As DateTime
        Private atrdFechaEntrega As DateTime
        Private atrcDescripcionCarga As String
        Private atrcOperador As String
        Private atrcUnidad As String
        Private atrcPlacasUnidad As String
        Private atrcRemolque1 As String
        Private atrcPlacasRemolque1 As String
        Private atrcDolly As String
        Private atrcRemolque2 As String
        Private atrcPlacasRemolque2 As String
        Private atrcObservaciones As String
        Private atrbIVAFlete As Boolean
        Private atrbRETFlete As Boolean
        Private atrbIVAManiobras As Boolean
        Private atrbRETManiobras As Boolean
        Private atrbIVARepartos As Boolean
        Private atrbRETRepartos As Boolean
        Private atrbIVARecolectas As Boolean
        Private atrbRETRecolectas As Boolean
        Private atrbIVAAutopistas As Boolean
        Private atrbRETAutopistas As Boolean
        Private atrbIVADemoras As Boolean
        Private atrbRETDemoras As Boolean
        Private atrbIVAOtros As Boolean
        Private atrbRETOtros As Boolean
        Private atrbIVASeguros As Boolean
        Private atrbRETSeguros As Boolean
        Private atrbIVARentas As Boolean
        Private atrbRETRentas As Boolean
        Private atrnPorcentajeIVA As Decimal
        Private atrnPorcentajeRET As Decimal
        Private atrnFlete As Decimal
        Private atrnManiobras As Decimal
        Private atrnRepartos As Decimal
        Private atrnRecolectas As Decimal
        Private atrnAutopistas As Decimal
        Private atrnDemoras As Decimal
        Private atrnOtros As Decimal
        Private atrnSeguros As Decimal
        Private atrnRentas As Decimal
        Private atrnSubtotal As Decimal
        Private atrnIVA As Decimal
        Private atrnIVARet As Decimal
        Private atrnTotal As Decimal
        Private atrcStatus As String
        Private atrdFechaInserta As DateTime
        Private atrdFechaCancela As DateTime
        Private atrnBultos As Long
        Private atrcClasificacion As String


        Public Property Factura() As Decimal
            Get
                Return atrnFactura
            End Get
            Set(ByVal Value As Decimal)
                atrnFactura = Value
            End Set
        End Property


        Public Property MovimientoFlete() As Decimal
            Get
                Return atrnMovimientoFlete
            End Get
            Set(ByVal Value As Decimal)
                atrnMovimientoFlete = Value
            End Set
        End Property


        Public Property Ruta() As String
            Get
                Return atrcRuta
            End Get
            Set(ByVal Value As String)
                atrcRuta = Value
            End Set
        End Property


        Public Property OrigenRemitente() As String
            Get
                Return atrcOrigenRemitente
            End Get
            Set(ByVal Value As String)
                atrcOrigenRemitente = Value
            End Set
        End Property


        Public Property DestinoDestinatario() As String
            Get
                Return atrcDestinoDestinatario
            End Get
            Set(ByVal Value As String)
                atrcDestinoDestinatario = Value
            End Set
        End Property


        Public Property Kilos() As Decimal
            Get
                Return atrnKilos
            End Get
            Set(ByVal Value As Decimal)
                atrnKilos = Value
            End Set
        End Property


        Public Property FechaCarga() As DateTime
            Get
                Return atrdFechaCarga
            End Get
            Set(ByVal Value As DateTime)
                atrdFechaCarga = Value
            End Set
        End Property


        Public Property FechaEntrega() As DateTime
            Get
                Return atrdFechaEntrega
            End Get
            Set(ByVal Value As DateTime)
                atrdFechaEntrega = Value
            End Set
        End Property


        Public Property DescripcionCarga() As String
            Get
                Return atrcDescripcionCarga
            End Get
            Set(ByVal Value As String)
                atrcDescripcionCarga = Value
            End Set
        End Property


        Public Property Operador() As String
            Get
                Return atrcOperador
            End Get
            Set(ByVal Value As String)
                atrcOperador = Value
            End Set
        End Property


        Public Property Unidad() As String
            Get
                Return atrcUnidad
            End Get
            Set(ByVal Value As String)
                atrcUnidad = Value
            End Set
        End Property


        Public Property PlacasUnidad() As String
            Get
                Return atrcPlacasUnidad
            End Get
            Set(ByVal Value As String)
                atrcPlacasUnidad = Value
            End Set
        End Property


        Public Property Remolque1() As String
            Get
                Return atrcRemolque1
            End Get
            Set(ByVal Value As String)
                atrcRemolque1 = Value
            End Set
        End Property


        Public Property PlacasRemolque1() As String
            Get
                Return atrcPlacasRemolque1
            End Get
            Set(ByVal Value As String)
                atrcPlacasRemolque1 = Value
            End Set
        End Property


        Public Property Dolly() As String
            Get
                Return atrcDolly
            End Get
            Set(ByVal Value As String)
                atrcDolly = Value
            End Set
        End Property


        Public Property Remolque2() As String
            Get
                Return atrcRemolque2
            End Get
            Set(ByVal Value As String)
                atrcRemolque2 = Value
            End Set
        End Property


        Public Property PlacasRemolque2() As String
            Get
                Return atrcPlacasRemolque2
            End Get
            Set(ByVal Value As String)
                atrcPlacasRemolque2 = Value
            End Set
        End Property


        Public Property Observaciones() As String
            Get
                Return atrcObservaciones
            End Get
            Set(ByVal Value As String)
                atrcObservaciones = Value
            End Set
        End Property


        Public Property IVAFlete() As Boolean
            Get
                Return atrbIVAFlete
            End Get
            Set(ByVal Value As Boolean)
                atrbIVAFlete = Value
            End Set
        End Property


        Public Property RETFlete() As Boolean
            Get
                Return atrbRETFlete
            End Get
            Set(ByVal Value As Boolean)
                atrbRETFlete = Value
            End Set
        End Property


        Public Property IVAManiobras() As Boolean
            Get
                Return atrbIVAManiobras
            End Get
            Set(ByVal Value As Boolean)
                atrbIVAManiobras = Value
            End Set
        End Property


        Public Property RETManiobras() As Boolean
            Get
                Return atrbRETManiobras
            End Get
            Set(ByVal Value As Boolean)
                atrbRETManiobras = Value
            End Set
        End Property


        Public Property IVARepartos() As Boolean
            Get
                Return atrbIVARepartos
            End Get
            Set(ByVal Value As Boolean)
                atrbIVARepartos = Value
            End Set
        End Property


        Public Property RETRepartos() As Boolean
            Get
                Return atrbRETRepartos
            End Get
            Set(ByVal Value As Boolean)
                atrbRETRepartos = Value
            End Set
        End Property


        Public Property IVARecolectas() As Boolean
            Get
                Return atrbIVARecolectas
            End Get
            Set(ByVal Value As Boolean)
                atrbIVARecolectas = Value
            End Set
        End Property


        Public Property RETRecolectas() As Boolean
            Get
                Return atrbRETRecolectas
            End Get
            Set(ByVal Value As Boolean)
                atrbRETRecolectas = Value
            End Set
        End Property


        Public Property IVAAutopistas() As Boolean
            Get
                Return atrbIVAAutopistas
            End Get
            Set(ByVal Value As Boolean)
                atrbIVAAutopistas = Value
            End Set
        End Property


        Public Property RETAutopistas() As Boolean
            Get
                Return atrbRETAutopistas
            End Get
            Set(ByVal Value As Boolean)
                atrbRETAutopistas = Value
            End Set
        End Property


        Public Property IVADemoras() As Boolean
            Get
                Return atrbIVADemoras
            End Get
            Set(ByVal Value As Boolean)
                atrbIVADemoras = Value
            End Set
        End Property


        Public Property RETDemoras() As Boolean
            Get
                Return atrbRETDemoras
            End Get
            Set(ByVal Value As Boolean)
                atrbRETDemoras = Value
            End Set
        End Property


        Public Property IVAOtros() As Boolean
            Get
                Return atrbIVAOtros
            End Get
            Set(ByVal Value As Boolean)
                atrbIVAOtros = Value
            End Set
        End Property


        Public Property RETOtros() As Boolean
            Get
                Return atrbRETOtros
            End Get
            Set(ByVal Value As Boolean)
                atrbRETOtros = Value
            End Set
        End Property


        Public Property IVASeguros() As Boolean
            Get
                Return atrbIVASeguros
            End Get
            Set(ByVal Value As Boolean)
                atrbIVASeguros = Value
            End Set
        End Property


        Public Property RETSeguros() As Boolean
            Get
                Return atrbRETSeguros
            End Get
            Set(ByVal Value As Boolean)
                atrbRETSeguros = Value
            End Set
        End Property


        Public Property IVARentas() As Boolean
            Get
                Return atrbIVARentas
            End Get
            Set(ByVal Value As Boolean)
                atrbIVARentas = Value
            End Set
        End Property


        Public Property RETRentas() As Boolean
            Get
                Return atrbRETRentas
            End Get
            Set(ByVal Value As Boolean)
                atrbRETRentas = Value
            End Set
        End Property


        Public Property PorcentajeIVA() As Decimal
            Get
                Return atrnPorcentajeIVA
            End Get
            Set(ByVal Value As Decimal)
                atrnPorcentajeIVA = Value
            End Set
        End Property


        Public Property PorcentajeRET() As Decimal
            Get
                Return atrnPorcentajeRET
            End Get
            Set(ByVal Value As Decimal)
                atrnPorcentajeRET = Value
            End Set
        End Property


        Public Property Flete() As Decimal
            Get
                Return atrnFlete
            End Get
            Set(ByVal Value As Decimal)
                atrnFlete = Value
            End Set
        End Property


        Public Property Maniobras() As Decimal
            Get
                Return atrnManiobras
            End Get
            Set(ByVal Value As Decimal)
                atrnManiobras = Value
            End Set
        End Property


        Public Property Repartos() As Decimal
            Get
                Return atrnRepartos
            End Get
            Set(ByVal Value As Decimal)
                atrnRepartos = Value
            End Set
        End Property


        Public Property Recolectas() As Decimal
            Get
                Return atrnRecolectas
            End Get
            Set(ByVal Value As Decimal)
                atrnRecolectas = Value
            End Set
        End Property


        Public Property Autopistas() As Decimal
            Get
                Return atrnAutopistas
            End Get
            Set(ByVal Value As Decimal)
                atrnAutopistas = Value
            End Set
        End Property


        Public Property Demoras() As Decimal
            Get
                Return atrnDemoras
            End Get
            Set(ByVal Value As Decimal)
                atrnDemoras = Value
            End Set
        End Property


        Public Property Otros() As Decimal
            Get
                Return atrnOtros
            End Get
            Set(ByVal Value As Decimal)
                atrnOtros = Value
            End Set
        End Property


        Public Property Seguros() As Decimal
            Get
                Return atrnSeguros
            End Get
            Set(ByVal Value As Decimal)
                atrnSeguros = Value
            End Set
        End Property


        Public Property Rentas() As Decimal
            Get
                Return atrnRentas
            End Get
            Set(ByVal Value As Decimal)
                atrnRentas = Value
            End Set
        End Property


        Public Property Subtotal() As Decimal
            Get
                Return atrnSubtotal
            End Get
            Set(ByVal Value As Decimal)
                atrnSubtotal = Value
            End Set
        End Property


        Public Property IVA() As Decimal
            Get
                Return atrnIVA
            End Get
            Set(ByVal Value As Decimal)
                atrnIVA = Value
            End Set
        End Property


        Public Property IVARet() As Decimal
            Get
                Return atrnIVARet
            End Get
            Set(ByVal Value As Decimal)
                atrnIVARet = Value
            End Set
        End Property


        Public Property Total() As Decimal
            Get
                Return atrnTotal
            End Get
            Set(ByVal Value As Decimal)
                atrnTotal = Value
            End Set
        End Property


        Public Property Status() As String
            Get
                Return atrcStatus
            End Get
            Set(ByVal Value As String)
                atrcStatus = Value
            End Set
        End Property


        Public Property FechaInserta() As DateTime
            Get
                Return atrdFechaInserta
            End Get
            Set(ByVal Value As DateTime)
                atrdFechaInserta = Value
            End Set
        End Property

        Public Property FechaCancela() As DateTime
            Get
                Return atrdFechaCancela
            End Get
            Set(ByVal Value As DateTime)
                atrdFechaCancela = Value
            End Set
        End Property


        Public Property Bultos() As Long
            Get
                Return atrnBultos
            End Get
            Set(ByVal value As Long)
                atrnBultos = value
            End Set
        End Property

        Public Property Clasificacion() As String
            Get
                Return atrcClasificacion
            End Get
            Set(ByVal value As String)
                atrcClasificacion = value
            End Set
        End Property



        Public Sub New()
            MyBase.new()
        End Sub

        Public Function Guardar() As Boolean
            Return EscribanoRegistros.Guardar(Me)
        End Function

        Public Function Cancelar() As Boolean
            'Return EscribanoRegistros.Cancelar(Me)
        End Function


    End Class
End Namespace

