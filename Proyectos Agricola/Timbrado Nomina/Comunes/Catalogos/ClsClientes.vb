Namespace Comunes.Catalogos
    Public Class ClsClientes
        Inherits Comunes.Comun.ClsBaseComun2


        Private atrRFCEmisor As Integer
        Private atrCalle As String
        Private atrCiudad As String
        Private atrLocalidad As String
        Private atrRFC As String
        Private atrCodigoPostal As String
        Private atrNoExt As String
        Private atrNoInt As String
        Private atrEstado As String
        Private atrPais As String
        Private atrCuentaBan As String
        Private atrColonia As String
        Private atrEmail As String
        Private atrMetodoPago As String


        Public Property RFCEmisor() As Integer
            Get
                Return atrRFCEmisor
            End Get
            Set(ByVal value As Integer)
                atrRFCEmisor = value
            End Set
        End Property

        Public Property Calle() As String
            Get
                Return atrCalle
            End Get
            Set(ByVal value As String)
                atrCalle = value
            End Set
        End Property

        Public Property Ciudad() As String
            Get
                Return atrCiudad
            End Get
            Set(ByVal value As String)
                atrCiudad = value
            End Set
        End Property

        Public Property RFC() As String
            Get
                Return atrRFC
            End Get
            Set(ByVal value As String)
                atrRFC = value
            End Set
        End Property

        Public Property CodigoPostal() As String
            Get
                Return atrCodigoPostal
            End Get
            Set(ByVal value As String)
                atrCodigoPostal = value
            End Set
        End Property

        Public Property NoExt() As String
            Get
                Return atrNoExt
            End Get
            Set(ByVal value As String)
                atrNoExt = value
            End Set
        End Property

        Public Property NoInt() As String
            Get
                Return atrNoInt
            End Get
            Set(ByVal value As String)
                atrNoInt = value
            End Set
        End Property

        Public Property Estado() As String
            Get
                Return atrEstado
            End Get
            Set(ByVal value As String)
                atrEstado = value
            End Set
        End Property

        Public Property Pais() As String
            Get
                Return atrPais
            End Get
            Set(ByVal value As String)
                atrPais = value
            End Set
        End Property

        Public Property CuentaBan() As String
            Get
                Return atrCuentaBan
            End Get
            Set(ByVal value As String)
                atrCuentaBan = value
            End Set
        End Property

        Public Property Colonia() As String
            Get
                Return atrColonia
            End Get
            Set(ByVal value As String)
                atrColonia = value
            End Set
        End Property

        Public Property Email() As String
            Get
                Return atrEmail
            End Get
            Set(ByVal value As String)
                atrEmail = value
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

        Public Property Localidad() As String
            Get
                Return atrLocalidad
            End Get
            Set(ByVal value As String)
                atrLocalidad = value
            End Set
        End Property

        Public Overrides Function FormatoFolio() As String
            Return ""

        End Function

        Public Overrides Function getNombreFolioAdministrado() As String
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            DAO.FolioAdministradoAgregar("CTL_CLIENTES", "Folio administrado para la tabla CTL_CLIENTES")
            Return "CTL_CLIENTES"
        End Function

        Public Sub New(ByVal prmfolio As Integer)
            MyBase.New(prmfolio)
            MyBase.atrCampoFolio = "NCLIENTE"
        End Sub

        Public Sub New()
            MyBase.New(0)
            MyBase.atrCampoFolio = "NCLIENTE"
        End Sub

        Public Overrides Function Guardar() As Boolean
            Return EscribanoCatalogos.Guardar(Me)
        End Function

        Public Overrides Function getRow() As Comun.ClsBaseComun2.ObtenerRowEventHandler
            Return AddressOf FabricaCatalogos.ObtenCliente
        End Function
    End Class
End Namespace


