Namespace Comunes.Catalogos
    Public Class ClsConfiguracionEdoCtaBan
        Inherits Comunes.Comun.ClsBaseComun2

        Private atrnLineaIniciaDetalle As Integer = 0

        Private atrbIngresoPorPosicion As Boolean = False
        Private atrnPosIniIngreso As Integer = 0
        Private atrnPosFinIngreso As Integer = 0
        Private atrcSeparadorIngreso As String = ""
        Private atrnPosicionIngresoConSeparador As Integer = 0
        Private atrcValorIdentificaComoIngreso As String = ""
        Private atrbDiferenteDeIngreso As Boolean = False

        Private atrbEgresoPorPosicion As Boolean = False
        Private atrnPosIniEgreso As Integer = 0
        Private atrnPosFinEgreso As Integer = 0
        Private atrcSeparadorEgreso As String = ""
        Private atrnPosicionEgresoConSeparador As Integer = 0
        Private atrcValorIdentificaComoEgreso As String = ""
        Private atrbDiferenteDeEgreso As Boolean = False

        Private atrbEsFechaPorPosicionIngreso As Boolean = False
        Private atrnPosIniFechaIngreso As Integer = 0
        Private atrnPosFinFechaIngreso As Integer = 0
        Private atrcSeparadorFechaIngreso As String = ""
        Private atrnPosicionFechaIngresoConSeparador As Integer = 0
        Private atrcFormatoFechaIngreso As String = ""
        Private atrbFormatoFechaEspanolIngreso As Boolean = False


        Private atrbEsFechaPorPosicionEgreso As Boolean = False
        Private atrnPosIniFechaEgreso As Integer = 0
        Private atrnPosFinFechaEgreso As Integer = 0
        Private atrcSeparadorFechaEgreso As String = ""
        Private atrnPosicionFechaEgresoConSeparador As Integer = 0
        Private atrcFormatoFechaEgreso As String = ""
        Private atrbFormatoFechaEspanolEgreso As Boolean = False

        Private atrbObservacionIngresoPorPosicion As Boolean
        Private atrnPosIniObservacionIngreso As Integer = 0
        Private atrnPosFinObservacionIngreso As Integer = 0
        Private atrcSeparadorObservacionIngreso As String = ""
        Private atrnPosicionObservacionIngreso As Integer = 0

        Private atrbObservacionEgresoPorPosicion As Boolean = False
        Private atrnPosIniObservacionEgreso As Integer = 0
        Private atrnPosFinObservacionEgreso As Integer = 0
        Private atrcSeparadorObservacionEgreso As String = ""
        Private atrnPosicionObservacionEgreso As Integer = 0

        Private atrbReferenciaIngresoPorPosicion As Boolean = False
        Private atrnPosIniReferenciaIngreso As Integer = 0
        Private atrnPosFinReferenciaIngreso As Integer = 0
        Private atrcSeparadorReferenciaIngreso As String = ""
        Private atrnPosicionReferenciaIngreso As Integer = 0

        Private atrbReferenciaEgresoPorPosicion As Boolean = False
        Private atrnPosIniReferenciaEgreso As Integer = 0
        Private atrnPosFinReferenciaEgreso As Integer = 0
        Private atrcSeparadorReferenciaEgreso As String = ""
        Private atrnPosicionReferenciaEgreso As Integer = 0

        Private atrbImporteIngresoPorPosicion As Boolean = False
        Private atrnPosIniImporteIngreso As Integer = 0
        Private atrnPosFinImporteIngreso As Integer = 0
        Private atrcSeparadorImporteIngreso As String = ""
        Private atrnPosicionImporteIngreso As Integer = 0
        Private atrbSinPuntoDecimalImporteIngreso As Boolean = False
        Private atrnPosicionesDecimalImporteIngreso As Integer = 0

        Private atrbImporteEgresoPorPosicion As Boolean = False
        Private atrnPosIniImporteEgreso As Integer = 0
        Private atrnPosFinImporteEgreso As Integer = 0
        Private atrcSeparadorImporteEgreso As String = ""
        Private atrnPosicionImporteEgreso As Integer = 0
        Private atrbSinPuntoDecimalImporteEgreso As Boolean = False
        Private atrnPosicionesDecimalImporteEgreso As Integer = 0

        Private atrbClaveIngresoPorPosicion As Boolean = False
        Private atrnPosIniClaveIngreso As Integer = 0
        Private atrnPosFinClaveIngreso As Integer = 0
        Private atrcSeparadorClaveIngreso As String = ""
        Private atrnPosicionClaveIngreso As Integer = 0

        Private atrbClaveEgresoPorPosicion As Boolean = False
        Private atrnPosIniClaveEgreso As Integer = 0
        Private atrnPosFinClaveEgreso As Integer = 0
        Private atrcSeparadorClaveEgreso As String = ""
        Private atrnPosicionClaveEgreso As Integer = 0


        Public Property nLineaIniciaDetalle() As Integer
            Get
                Return atrnLineaIniciaDetalle
            End Get
            Set(ByVal value As Integer)
                atrnLineaIniciaDetalle = value
            End Set
        End Property

        Public Property bIngresoPorPosicion() As Boolean
            Get
                Return atrbIngresoPorPosicion
            End Get
            Set(ByVal value As Boolean)
                atrbIngresoPorPosicion = value
            End Set
        End Property


        Public Property nPosIniIngreso() As Integer
            Get
                Return atrnPosIniIngreso
            End Get
            Set(ByVal value As Integer)
                atrnPosIniIngreso = value
            End Set
        End Property

        Public Property nPosFinIngreso() As Integer
            Get
                Return atrnPosFinIngreso
            End Get
            Set(ByVal value As Integer)
                atrnPosFinIngreso = value
            End Set
        End Property


        Public Property cSeparadorIngreso() As String
            Get
                Return atrcSeparadorIngreso
            End Get
            Set(ByVal value As String)
                atrcSeparadorIngreso = value
            End Set
        End Property

        Public Property nPosicionIngresoConSeparador() As Integer
            Get
                Return atrnPosicionIngresoConSeparador
            End Get
            Set(ByVal value As Integer)
                atrnPosicionIngresoConSeparador = value
            End Set
        End Property

        Public Property cValorIdentificaComoIngreso() As String
            Get
                Return atrcValorIdentificaComoIngreso
            End Get
            Set(ByVal value As String)
                atrcValorIdentificaComoIngreso = value
            End Set
        End Property

        Public Property bDiferenteDeIngreso() As Boolean
            Get
                Return atrbDiferenteDeIngreso
            End Get
            Set(ByVal value As Boolean)
                atrbDiferenteDeIngreso = value
            End Set
        End Property





        Public Property bEgresoPorPosicion() As Boolean
            Get
                Return atrbEgresoPorPosicion
            End Get
            Set(ByVal value As Boolean)
                atrbEgresoPorPosicion = value
            End Set
        End Property

        Public Property nPosIniEgreso() As Integer
            Get
                Return atrnPosIniEgreso
            End Get
            Set(ByVal value As Integer)
                atrnPosIniEgreso = value
            End Set
        End Property

        Public Property nPosFinEgreso() As Integer
            Get
                Return atrnPosFinEgreso
            End Get
            Set(ByVal value As Integer)
                atrnPosFinEgreso = value
            End Set
        End Property

        Public Property cSeparadorEgreso() As String
            Get
                Return atrcSeparadorEgreso
            End Get
            Set(ByVal value As String)
                atrcSeparadorEgreso = value
            End Set
        End Property

        Public Property nPosicionEgresoConSeparador() As Integer
            Get
                Return atrnPosicionEgresoConSeparador
            End Get
            Set(ByVal value As Integer)
                atrnPosicionEgresoConSeparador = value
            End Set
        End Property

        Public Property cValorIdentificaComoEgreso() As String
            Get
                Return atrcValorIdentificaComoEgreso
            End Get
            Set(ByVal value As String)
                atrcValorIdentificaComoEgreso = value
            End Set
        End Property

        Public Property bDiferenteDeEgreso() As Boolean
            Get
                Return atrbDiferenteDeEgreso
            End Get
            Set(ByVal value As Boolean)
                atrbDiferenteDeEgreso = value
            End Set
        End Property



        Public Property bEsFechaPorPosicionIngreso() As Boolean
            Get
                Return atrbEsFechaPorPosicionIngreso
            End Get
            Set(ByVal value As Boolean)
                atrbEsFechaPorPosicionIngreso = value
            End Set
        End Property

        Public Property nPosIniFechaIngreso() As Integer
            Get
                Return atrnPosIniFechaIngreso
            End Get
            Set(ByVal value As Integer)
                atrnPosIniFechaIngreso = value
            End Set
        End Property

        Public Property nPosFinFechaIngreso() As Integer
            Get
                Return atrnPosFinFechaIngreso
            End Get
            Set(ByVal value As Integer)
                atrnPosFinFechaIngreso = value
            End Set
        End Property

        Public Property cSeparadorFechaIngreso() As String
            Get
                Return atrcSeparadorFechaIngreso
            End Get
            Set(ByVal value As String)
                atrcSeparadorFechaIngreso = value
            End Set
        End Property

        Public Property nPosicionFechaIngresoConSeparador() As Integer
            Get
                Return atrnPosicionFechaIngresoConSeparador
            End Get
            Set(ByVal value As Integer)
                atrnPosicionFechaIngresoConSeparador = value
            End Set
        End Property

        Public Property cFormatoFechaIngreso() As String
            Get
                Return atrcFormatoFechaIngreso
            End Get
            Set(ByVal value As String)
                atrcFormatoFechaIngreso = value
            End Set
        End Property

        Public Property bFormatoFechaEspanolIngreso() As Boolean
            Get
                Return atrbFormatoFechaEspanolIngreso
            End Get
            Set(ByVal value As Boolean)
                atrbFormatoFechaEspanolIngreso = value
            End Set
        End Property


        Public Property bEsFechaPorPosicionEgreso() As Boolean
            Get
                Return atrbEsFechaPorPosicionEgreso
            End Get
            Set(ByVal value As Boolean)
                atrbEsFechaPorPosicionEgreso = value
            End Set
        End Property

        Public Property nPosIniFechaEgreso() As Integer
            Get
                Return atrnPosIniFechaEgreso
            End Get
            Set(ByVal value As Integer)
                atrnPosIniFechaEgreso = value
            End Set
        End Property

        Public Property nPosFinFechaEgreso() As Integer
            Get
                Return atrnPosFinFechaEgreso
            End Get
            Set(ByVal value As Integer)
                atrnPosFinFechaEgreso = value
            End Set
        End Property
        Public Property cSeparadorFechaEgreso() As String
            Get
                Return atrcSeparadorFechaEgreso
            End Get
            Set(ByVal value As String)
                atrcSeparadorFechaEgreso = value
            End Set
        End Property

        Public Property nPosicionFechaEgresoConSeparador() As Integer
            Get
                Return atrnPosicionFechaEgresoConSeparador
            End Get
            Set(ByVal value As Integer)
                atrnPosicionFechaEgresoConSeparador = value
            End Set
        End Property

        Public Property cFormatoFechaEgreso() As String
            Get
                Return atrcFormatoFechaEgreso
            End Get
            Set(ByVal value As String)
                atrcFormatoFechaEgreso = value
            End Set
        End Property

        Public Property bFormatoFechaEspanolEgreso() As Boolean
            Get
                Return atrbFormatoFechaEspanolEgreso
            End Get
            Set(ByVal value As Boolean)
                atrbFormatoFechaEspanolEgreso = value
            End Set
        End Property

        Public Property bObservacionIngresoPorPosicion() As Boolean
            Get
                Return atrbObservacionIngresoPorPosicion
            End Get
            Set(ByVal value As Boolean)
                atrbObservacionIngresoPorPosicion = value
            End Set
        End Property

        Public Property nPosIniObservacionIngreso() As Integer
            Get
                Return atrnPosIniObservacionIngreso
            End Get
            Set(ByVal value As Integer)
                atrnPosIniObservacionIngreso = value
            End Set
        End Property

        Public Property nPosFinObservacionIngreso() As Integer
            Get
                Return atrnPosFinObservacionIngreso
            End Get
            Set(ByVal value As Integer)
                atrnPosFinObservacionIngreso = value
            End Set
        End Property

        Public Property cSeparadorObservacionIngreso() As String
            Get
                Return atrcSeparadorObservacionIngreso
            End Get
            Set(ByVal value As String)
                atrcSeparadorObservacionIngreso = value
            End Set
        End Property

        Public Property nPosicionObservacionIngreso() As Integer
            Get
                Return atrnPosicionObservacionIngreso
            End Get
            Set(ByVal value As Integer)
                atrnPosicionObservacionIngreso = value
            End Set
        End Property

        Public Property bObservacionEgresoPorPosicion() As Boolean
            Get
                Return atrbObservacionEgresoPorPosicion
            End Get
            Set(ByVal value As Boolean)
                atrbObservacionEgresoPorPosicion = value
            End Set
        End Property

        Public Property nPosIniObservacionEgreso() As Integer
            Get
                Return atrnPosIniObservacionEgreso
            End Get
            Set(ByVal value As Integer)
                atrnPosIniObservacionEgreso = value
            End Set
        End Property

        Public Property nPosFinObservacionEgreso() As Integer
            Get
                Return atrnPosFinObservacionEgreso
            End Get
            Set(ByVal value As Integer)
                atrnPosFinObservacionEgreso = value
            End Set
        End Property

        Public Property cSeparadorObservacionEgreso() As String
            Get
                Return atrcSeparadorObservacionEgreso
            End Get
            Set(ByVal value As String)
                atrcSeparadorObservacionEgreso = value
            End Set
        End Property

        Public Property nPosicionObservacionEgreso() As Integer
            Get
                Return atrnPosicionObservacionEgreso
            End Get
            Set(ByVal value As Integer)
                atrnPosicionObservacionEgreso = value
            End Set
        End Property

        Public Property bReferenciaIngresoPorPosicion() As Boolean
            Get
                Return atrbReferenciaIngresoPorPosicion
            End Get
            Set(ByVal value As Boolean)
                atrbReferenciaIngresoPorPosicion = value
            End Set
        End Property

        Public Property nPosIniReferenciaIngreso() As Integer
            Get
                Return atrnPosIniReferenciaIngreso
            End Get
            Set(ByVal value As Integer)
                atrnPosIniReferenciaIngreso = value
            End Set
        End Property

        Public Property nPosFinReferenciaIngreso() As Integer
            Get
                Return atrnPosFinReferenciaIngreso
            End Get
            Set(ByVal value As Integer)
                atrnPosFinReferenciaIngreso = value
            End Set
        End Property

        Public Property cSeparadorReferenciaIngreso() As String
            Get
                Return atrcSeparadorReferenciaIngreso
            End Get
            Set(ByVal value As String)
                atrcSeparadorReferenciaIngreso = value
            End Set
        End Property

        Public Property nPosicionReferenciaIngreso() As Integer
            Get
                Return atrnPosicionReferenciaIngreso
            End Get
            Set(ByVal value As Integer)
                atrnPosicionReferenciaIngreso = value
            End Set
        End Property

        Public Property bReferenciaEgresoPorPosicion() As Boolean
            Get
                Return atrbReferenciaEgresoPorPosicion
            End Get
            Set(ByVal value As Boolean)
                atrbReferenciaEgresoPorPosicion = value
            End Set
        End Property

        Public Property nPosIniReferenciaEgreso() As Integer
            Get
                Return atrnPosIniReferenciaEgreso
            End Get
            Set(ByVal value As Integer)
                atrnPosIniReferenciaEgreso = value
            End Set
        End Property

        Public Property nPosFinReferenciaEgreso() As Integer
            Get
                Return atrnPosFinReferenciaEgreso
            End Get
            Set(ByVal value As Integer)
                atrnPosFinReferenciaEgreso = value
            End Set
        End Property

        Public Property cSeparadorReferenciaEgreso() As String
            Get
                Return atrcSeparadorReferenciaEgreso
            End Get
            Set(ByVal value As String)
                atrcSeparadorReferenciaEgreso = value
            End Set
        End Property

        Public Property nPosicionReferenciaEgreso() As Integer
            Get
                Return atrnPosicionReferenciaEgreso
            End Get
            Set(ByVal value As Integer)
                atrnPosicionReferenciaEgreso = value
            End Set
        End Property

        Public Property bImporteIngresoPorPosicion() As Boolean
            Get
                Return atrbImporteIngresoPorPosicion
            End Get
            Set(ByVal value As Boolean)
                atrbImporteIngresoPorPosicion = value
            End Set
        End Property

        Public Property nPosIniImporteIngreso() As Integer
            Get
                Return atrnPosIniImporteIngreso
            End Get
            Set(ByVal value As Integer)
                atrnPosIniImporteIngreso = value
            End Set
        End Property

        Public Property nPosFinImporteIngreso() As Integer
            Get
                Return atrnPosFinImporteIngreso
            End Get
            Set(ByVal value As Integer)
                atrnPosFinImporteIngreso = value
            End Set
        End Property

        Public Property cSeparadorImporteIngreso() As String
            Get
                Return atrcSeparadorImporteIngreso
            End Get
            Set(ByVal value As String)
                atrcSeparadorImporteIngreso = value
            End Set
        End Property

        Public Property nPosicionImporteIngreso() As Integer
            Get
                Return atrnPosicionImporteIngreso
            End Get
            Set(ByVal value As Integer)
                atrnPosicionImporteIngreso = value
            End Set
        End Property

        Public Property bSinPuntoDecimalImporteIngreso() As Boolean
            Get
                Return atrbSinPuntoDecimalImporteIngreso
            End Get
            Set(ByVal value As Boolean)
                atrbSinPuntoDecimalImporteIngreso = value
            End Set
        End Property

        Public Property nPosicionesDecimalImporteIngreso() As Integer
            Get
                Return atrnPosicionesDecimalImporteIngreso
            End Get
            Set(ByVal value As Integer)
                atrnPosicionesDecimalImporteIngreso = value
            End Set
        End Property



        Public Property bImporteEgresoPorPosicion() As Boolean
            Get
                Return atrbImporteEgresoPorPosicion
            End Get
            Set(ByVal value As Boolean)
                atrbImporteEgresoPorPosicion = value
            End Set
        End Property

        Public Property nPosIniImporteEgreso() As Integer
            Get
                Return atrnPosIniImporteEgreso
            End Get
            Set(ByVal value As Integer)
                atrnPosIniImporteEgreso = value
            End Set
        End Property

        Public Property nPosFinImporteEgreso() As Integer
            Get
                Return atrnPosFinImporteEgreso
            End Get
            Set(ByVal value As Integer)
                atrnPosFinImporteEgreso = value
            End Set
        End Property

        Public Property cSeparadorImporteEgreso() As String
            Get
                Return atrcSeparadorImporteEgreso
            End Get
            Set(ByVal value As String)
                atrcSeparadorImporteEgreso = value
            End Set
        End Property

        Public Property nPosicionImporteEgreso() As Integer
            Get
                Return atrnPosicionImporteEgreso
            End Get
            Set(ByVal value As Integer)
                atrnPosicionImporteEgreso = value
            End Set
        End Property

        Public Property bSinPuntoDecimalImporteEgreso() As Boolean
            Get
                Return atrbSinPuntoDecimalImporteEgreso
            End Get
            Set(ByVal value As Boolean)
                atrbSinPuntoDecimalImporteEgreso = value
            End Set
        End Property

        Public Property nPosicionesDecimalImporteEgreso() As Integer
            Get
                Return atrnPosicionesDecimalImporteEgreso
            End Get
            Set(ByVal value As Integer)
                atrnPosicionesDecimalImporteEgreso = value
            End Set
        End Property


        Public Property bClaveIngresoPorPosicion() As Boolean
            Get
                Return atrbClaveIngresoPorPosicion
            End Get
            Set(ByVal value As Boolean)
                atrbClaveIngresoPorPosicion = value
            End Set
        End Property

        Public Property nPosIniClaveIngreso() As Integer
            Get
                Return atrnPosIniClaveIngreso
            End Get
            Set(ByVal value As Integer)
                atrnPosIniClaveIngreso = value
            End Set
        End Property

        Public Property nPosFinClaveIngreso() As Integer
            Get
                Return atrnPosFinClaveIngreso
            End Get
            Set(ByVal value As Integer)
                atrnPosFinClaveIngreso = value
            End Set
        End Property

        Public Property cSeparadorClaveIngreso() As String
            Get
                Return atrcSeparadorClaveIngreso
            End Get
            Set(ByVal value As String)
                atrcSeparadorClaveIngreso = value
            End Set
        End Property

        Public Property nPosicionClaveIngreso() As Integer
            Get
                Return atrnPosicionClaveIngreso
            End Get
            Set(ByVal value As Integer)
                atrnPosicionClaveIngreso = value
            End Set
        End Property

        Public Property bClaveEgresoPorPosicion() As Boolean
            Get
                Return atrbClaveEgresoPorPosicion
            End Get
            Set(ByVal value As Boolean)
                atrbClaveEgresoPorPosicion = value
            End Set
        End Property

        Public Property nPosIniClaveEgreso() As Integer
            Get
                Return atrnPosIniClaveEgreso
            End Get
            Set(ByVal value As Integer)
                atrnPosIniClaveEgreso = value
            End Set
        End Property

        Public Property nPosFinClaveEgreso() As Integer
            Get
                Return atrnPosFinClaveEgreso
            End Get
            Set(ByVal value As Integer)
                atrnPosFinClaveEgreso = value
            End Set
        End Property

        Public Property cSeparadorClaveEgreso() As String
            Get
                Return atrcSeparadorClaveEgreso
            End Get
            Set(ByVal value As String)
                atrcSeparadorClaveEgreso = value
            End Set
        End Property

        Public Property nPosicionClaveEgreso() As Integer
            Get
                Return atrnPosicionClaveEgreso
            End Get
            Set(ByVal value As Integer)
                atrnPosicionClaveEgreso = value
            End Set
        End Property


        Public Sub New()
            MyBase.New(0)
            MyBase.atrCampoFolio = "nConsecutivo"
        End Sub

        Public Sub New(ByVal prmfolio As Integer)
            MyBase.New(prmfolio)
            MyBase.atrCampoFolio = "nConsecutivo"
        End Sub

        Public Overrides Function FormatoFolio() As String
            Return ""
        End Function

        Public Overrides Function getNombreFolioAdministrado() As String
            DAO.FolioAdministradoAgregar("BAN_ConfiguracionesEdoCtaBancaria", "Folio Administrado de los Movimientos de BAN_ConfiguracionesEdoCtaBancaria")
            Return "BAN_ConfiguracionesEdoCtaBancaria"
        End Function

        Public Overrides Function Guardar() As Boolean
            Return Comunes.Catalogos.EscribanoCatalogos.Guardar(Me)
        End Function

        Public Overrides Function getRow() As Comun.ClsBaseComun2.ObtenerRowEventHandler
            Return AddressOf FabricaCatalogos.ObtenConfiguracionEdoCtaBan
        End Function
    End Class

End Namespace

