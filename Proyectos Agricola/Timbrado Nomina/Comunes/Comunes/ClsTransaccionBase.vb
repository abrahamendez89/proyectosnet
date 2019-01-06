Imports Access.Comunes.Catalogos

Namespace Comunes.Comun
    ' <summary>
    ' este método cancelará la transacción actual y generará una contra transacción.
    ' Este método deberá sobre escribirse en cada tipo de transacción
    ' </summary>
    Public MustInherit Class ClsTransaccionBase
        Inherits ClsBaseComun


        Private atrAplicado As Boolean
        ' <summary>
        ' en el caso de las transacciones de tipo contramivimiento registra el folio de
        ' transaccion del mismo
        ' que esta cancelando
        ' </summary>
        Private atrFolioQueCancela As Long
        ' <summary>
        ' Fecha de transaccion
        ' </summary>
        Private atrdFecha As Date
        ' <summary>
        ' Moneda en que se registró la transacción
        ' </summary>
        Private atrMoneda As Catalogos.ClsMoneda
        ' <summary>
        ' Tipo de cambio con respecto a la moneda base vigente a la fecha de la
        ' transaccion
        ' </summary>
        Private atrTipoCambio As Double

        'Cada clase implementara su contenedor de objetos
        ' <summary>
        ' arreglo que almacenará el detalle de la transaccion
        ' </summary>
        Private atrDetalles As New Comun.ClsContenedor

        ' <summary>
        ' Observación de la transacción
        ' </summary>
        Private atrObservacion As String

        Private atrEstatus As String

        Public Property onObtenerTablaDetalle() As Comun.ClsContenedor.ObtenerTablaEventHandler
            Get
                Return atrDetalles.ObtenerTabla
            End Get
            Set(ByVal value As Comun.ClsContenedor.ObtenerTablaEventHandler)
                atrDetalles.ObtenerTabla = value
            End Set
        End Property

        Public Property OnObtenerClaseDetalle() As Comun.ClsContenedor.ObtenerObjetoEventHandler
            Get
                Return atrDetalles.ObtenerObjeto
            End Get
            Set(ByVal value As Comun.ClsContenedor.ObtenerObjetoEventHandler)
                atrDetalles.ObtenerObjeto = value
            End Set
        End Property

        Public Property OnObtenerRowDetalle() As Comun.ClsContenedor.ObtenerRowEventHandler
            Get
                Return atrDetalles.ObtenerRow
            End Get
            Set(ByVal value As Comun.ClsContenedor.ObtenerRowEventHandler)
                atrDetalles.ObtenerRow = value
            End Set
        End Property

        Public Property Estatus() As String
            Get
                Return atrEstatus
            End Get
            Set(ByVal value As String)
                atrEstatus = value
            End Set
        End Property


        Public Sub New(ByVal prmTransaccion As Long, ByVal prmFecha As DateTime _
                        , ByVal prmMoneda As Catalogos.ClsMoneda, ByVal prmTipoCambio As Double _
                        , ByVal prmAplicado As Boolean)
            MyBase.New(prmTransaccion)
            atrdFecha = prmFecha
            atrMoneda = prmMoneda
            atrTipoCambio = prmTipoCambio
            atrAplicado = prmAplicado


        End Sub

        Public Sub New(ByVal prmFecha As DateTime _
                        , ByVal prmMoneda As Catalogos.ClsMoneda, ByVal prmTipoCambio As Double)
            MyBase.New(0)
            atrdFecha = prmFecha
            atrMoneda = prmMoneda
            atrTipoCambio = prmTipoCambio
            atrAplicado = False
        End Sub

        Public Sub New(ByVal prmfolio As Integer)
            MyBase.New(prmfolio)
            atrDetalles = New ClsContenedor
        End Sub

        Public Property Aplicado() As Boolean
            Get
                Return atrAplicado
            End Get
            Set(ByVal Value As Boolean)
                atrAplicado = Value
            End Set
        End Property

        ' <summary>
        ' en el caso de las transacciones de tipo contramivimiento registra el folio de
        ' transaccion del mismo
        ' que esta cancelando
        ' </summary>
        Public Property FolioQueCancela() As Integer
            Get
                Return atrFolioQueCancela
            End Get
            Set(ByVal Value As Integer)
                atrFolioQueCancela = Value
            End Set
        End Property

        ' <summary>
        ' Fecha de transaccion
        ' </summary>
        Public Property Fecha() As Date
            Get
                Return atrdFecha
            End Get
            Set(ByVal Value As Date)
                atrdFecha = Value
            End Set
        End Property

        ' <summary>
        ' Moneda en que se registró la transacción
        ' </summary>
        Public Property Moneda() As Catalogos.ClsMoneda
            Get
                Return atrMoneda
            End Get
            Set(ByVal Value As Catalogos.ClsMoneda)
                atrMoneda = Value
            End Set
        End Property

        ' <summary>
        ' Tipo de cambio con respecto a la moneda base vigente a la fecha de la
        ' transaccion
        ' </summary>
        Public Property TipoCambio() As Double
            Get
                Return atrTipoCambio
            End Get
            Set(ByVal Value As Double)
                atrTipoCambio = Value
            End Set
        End Property
        ' <summary>
        ' Observación de la transacción
        ' </summary>
        Public Property Observacion() As String
            Get
                Return atrObservacion
            End Get
            Set(ByVal Value As String)
                atrObservacion = Value
            End Set
        End Property

        ' <summary>
        ' arreglo que almacenará el detalle de la transaccion
        ' </summary>
        Public Property Detalles() As ClsContenedor
            Get
                Return atrDetalles
            End Get
            Set(ByVal Value As ClsContenedor)
                atrDetalles = Value
            End Set
        End Property

        ' <summary>
        ' Recibe Un Objecto del tipo Detalle de la transacción en cuestión y lo inserta
        ' en el arreglo de detalles
        ' </summary>
        ' <param name="prmDetalle"></param>
        Public Sub AgregaDetalle(ByVal prmDetalle As IDetalleTransaccionBase)
            Dim vlDetalleRepetido As Boolean
            vlDetalleRepetido = False
            For Each miDetalle As IDetalleTransaccionBase In atrDetalles.Items()
                If prmDetalle.Renglon = miDetalle.Renglon Then vlDetalleRepetido = True
            Next
            If Not vlDetalleRepetido Then atrDetalles.Agregar(prmDetalle)
        End Sub


        ' <summary>
        ' Inicializa el Arreglo de Detalles de la transacción
        ' </summary>
        Public Sub InicializaDetalles()
            atrDetalles = Nothing
        End Sub

        ' <summary>
        ' hará un ciclo para guardar el detalle de la transaccion
        ' </summary>
        Protected Function GuardaDetalle(Optional ByVal PorClases As Boolean = True) As Boolean
            If atrDetalles.ArregloDT Is Nothing Then
                For Each miDetalle As Object In atrDetalles.Items
                    If Not miDetalle.Guardar() Then
                        Return False
                    End If
                Next
            Else
                Return atrDetalles.Guardar(PorClases)
            End If
            Return True
        End Function


        ' 
        ' <param name="prmdFecha"></param>
        Public Overridable Sub CancelaTransaccion(ByVal prmdFecha As Date)

        End Sub


        Public Overrides Function FormatoFolio() As String
            Return ""
        End Function

        Public Overrides Function getNombreFolioAdministrado() As String
            Return ""
        End Function
    End Class ' ClsTransaccionBase


    Public Interface IDetalleTransaccionBase
        Property Renglon() As Integer
    End Interface ' ClsDetalleTransaccionBase
End Namespace ' Comun