Namespace Comunes.Catalogos
    Public Class ClsEmpleado
        Inherits Comunes.Comun.ClsBaseComun2

        Private atrcNombre As String
        Private atrcApellidoPaterno As String
        Private atrcApellidoMaterno As String
        Private atrdFechaIngreso As Date
        Private atrdFechaNacimiento As Date
        Private atrcCodigoAux As String
        Private atrcTelefonoCasa As String
        Private atrcTelefonoCelular As String
        Private atrPais As String
        Private atrColonia As Integer
        Private atrDireccion As String
        Private atrPuesto As Integer
        Private atrTurno As Integer
        Private atrSucursal As Integer
        Private atrArea As Integer
        Private atrTipoArticulo As String
        Private atrCodigoGafete As String

        Public Property TipoArticulo() As String
            Get
                Return atrTipoArticulo
            End Get
            Set(ByVal value As String)
                atrTipoArticulo = value
            End Set
        End Property

        Public Property CodigoGafete() As String
            Get
                Return atrCodigoGafete
            End Get
            Set(ByVal value As String)
                atrCodigoGafete = value
            End Set
        End Property

        Public Property Direccion() As String
            Get
                Return atrDireccion
            End Get
            Set(ByVal value As String)
                atrDireccion = value
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

        Public Property TelefonoCasa() As String
            Get
                Return atrcTelefonoCasa
            End Get
            Set(ByVal value As String)
                atrcTelefonoCasa = value
            End Set
        End Property

        Public Property TelefonoCelular() As String
            Get
                Return atrcTelefonoCelular
            End Get
            Set(ByVal value As String)
                atrcTelefonoCelular = value
            End Set
        End Property

        Public Property Nombre() As String
            Get
                Return atrcNombre
            End Get
            Set(ByVal value As String)
                atrcNombre = value
            End Set
        End Property

        Public Property ApellidoPaterno() As String
            Get
                Return atrcApellidoPaterno
            End Get
            Set(ByVal value As String)
                atrcApellidoPaterno = value
            End Set
        End Property

        Public Property ApellidoMaterno() As String
            Get
                Return atrcApellidoMaterno
            End Get
            Set(ByVal value As String)
                atrcApellidoMaterno = value
            End Set
        End Property


        Public Property FechaIngreso() As Date
            Get
                Return atrdFechaIngreso
            End Get
            Set(ByVal value As Date)
                atrdFechaIngreso = value
            End Set
        End Property

        Public Property FechaNacimiento() As Date
            Get
                Return atrdFechaNacimiento
            End Get
            Set(ByVal value As Date)
                atrdFechaNacimiento = value
            End Set
        End Property

        Public Property CodigoAux() As String
            Get
                Return atrcCodigoAux
            End Get
            Set(ByVal value As String)
                atrcCodigoAux = value
            End Set
        End Property

        Public Property Puesto() As Integer
            Get
                Return atrPuesto
            End Get
            Set(ByVal value As Integer)
                atrPuesto = value
            End Set
        End Property

        Public Property Turno() As Integer
            Get
                Return atrTurno
            End Get
            Set(ByVal value As Integer)
                atrTurno = value
            End Set
        End Property

        Public Property Sucursal() As Integer
            Get
                Return atrSucursal
            End Get
            Set(ByVal value As Integer)
                atrSucursal = value
            End Set
        End Property

        Public Property Area() As Integer
            Get
                Return atrArea
            End Get
            Set(ByVal value As Integer)
                atrArea = value
            End Set
        End Property

        Public Property Colonia() As Integer
            Get
                Return atrColonia
            End Get
            Set(ByVal value As Integer)
                atrColonia = value
            End Set
        End Property

        Public ReadOnly Property NombreCompleto() As String
            Get
                Return Nombre & " " & ApellidoPaterno & " " & ApellidoMaterno
            End Get
        End Property


        Public Overrides Function FormatoFolio() As String
            Return ""
        End Function

        Public Overrides Function getNombreFolioAdministrado() As String
            Return "CTL_Empleados"
        End Function

        Public Sub New()
            MyBase.New(0)
            MyBase.atrCampoFolio = "nEmpleado"
        End Sub

        Public Sub New(ByVal prmfolio As Integer)
            MyBase.New(prmfolio)
            MyBase.atrCampoFolio = "nEmpleado"
        End Sub

        Public Overrides Function getRow() As Comunes.Comun.ClsBaseComun2.ObtenerRowEventHandler
            Return AddressOf FabricaCatalogos.ObtenEmpleado
        End Function

        Public Overrides Function Guardar() As Boolean
            Return EscribanoCatalogos.Guardar(Me)

        End Function
    End Class
End Namespace