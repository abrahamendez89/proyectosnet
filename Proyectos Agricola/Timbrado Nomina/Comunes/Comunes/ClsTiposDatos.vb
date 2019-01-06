Imports Sistema.Comunes.Catalogos
Imports Sistema.Comunes
Namespace Comunes.Comun

    Public Class ClsTiposDatos
        Inherits Comun.ClsBaseComun

#Region "Atributos"
        Private atrnTipoDato As Integer
        Private atrcLlave As String
        Private atrcValor As String
        Private atrnValor As Integer
#End Region

#Region "Propiedades"
        Public Property Llave() As String
            Get
                Return atrcLlave
            End Get
            Set(ByVal value As String)
                atrcLlave = value
            End Set
        End Property
        Public Property TipoDato() As Integer
            Get
                Return atrnTipoDato
            End Get
            Set(ByVal value As Integer)
                atrnTipoDato = value
            End Set
        End Property

        Public Property ValorDescripcion() As String
            Get
                Return atrcValor
            End Get
            Set(ByVal value As String)
                atrcValor = value
            End Set
        End Property

        Public Property Valor() As Integer
            Get
                Return atrnValor
            End Get
            Set(ByVal value As Integer)
                atrnValor = value
            End Set
        End Property
#End Region

        '    Public Overrides Function FormatoFolio() As String
        '        Return ""
        '    End Function

        '    Public Overrides Function getNombreFolioAdministrado() As String
        '        'Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        '        'DAO.FolioAdministradoAgregar("CTL_TIPOS", "Folio administrado para la tabla CTL_TIPOSPRODUCTOS")
        '        Return "ADSUM_TiposDatos"
        '    End Function

        '    Public Overrides Function getRow() As Comun.ClsBaseComun2.ObtenerRowEventHandler
        '        Return AddressOf FabricaCatalogos.ObtenTiposDatos
        '    End Function

        '    Public Sub New(ByVal prmfolio As Integer)
        '        MyBase.New(prmfolio)
        '        MyBase.EsCorporativo = AddressOf Comunes.Comun.ClsTools.EsCorporativo
        '        MyBase.atrCampoFolio = "nTipoDato"
        '    End Sub

        '    Public Sub New()
        '        MyBase.New()
        '        MyBase.EsCorporativo = AddressOf Comunes.Comun.ClsTools.EsCorporativo
        '        MyBase.atrCampoFolio = "nTipoDato"
        '    End Sub

        '    Public Overrides Function Guardar() As Boolean
        '        Return EscribanoCatalogos.Guardar(Me)
        '    End Function



#Region "Métodos"
        Public Overrides Function FormatoFolio() As String
            Return ""
        End Function

        Public Overrides Function getNombreFolioAdministrado() As String
            Return "ADSUM_TiposDatos"
        End Function

        Public Overrides Function getRow() As Comun.ClsBaseComun.ObtenerRowEventHandler
            Return AddressOf FabricaCatalogos.ObtenTiposDatos
        End Function

        Public Overrides Function Guardar() As Boolean
            Return EscribanoCatalogos.Guardar(Me)
        End Function
        Public Sub New()
            MyBase.New(0)
        End Sub


        Public Sub New(ByVal prmfolio As Integer)
            MyBase.New(prmfolio)
        End Sub
#End Region

    End Class

End Namespace