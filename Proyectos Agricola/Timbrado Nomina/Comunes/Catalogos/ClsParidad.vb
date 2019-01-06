Imports Access.Comunes.Catalogos

Namespace Comunes.Catalogos
    Public Class ClsParidad
        Inherits Comunes.Comun.ClsBaseComun2

        Private atrMoneda As ClsMoneda
        Private atrdFecha As Date
        Private atrnPrecioDeCompra As Decimal
        Private atrnPrecioDeVenta As Decimal
        Private atrnDiasVigencia As Integer
        Private atrDTParidades As ClsContieneParidades

        Public Overrides Function FormatoFolio() As String
            Return ""
        End Function

        Public Overrides Function getNombreFolioAdministrado() As String
            DAO.FolioAdministradoAgregar("CTL_ParidadesMoneda_" & Moneda.Folio, "CTL_ParidadesMoneda_" & Moneda.Folio)
            Return "CTL_ParidadesMoneda_" & Moneda.Folio
        End Function

        Public Sub New()
            MyBase.New(0)
            Me.atrDTParidades = New ClsContieneParidades()
            MyBase.atrCampoFolio = "nParidad"
        End Sub

        Public Sub New(ByVal prmfolio As Integer, ByVal prmParidad As Integer)
            Me.atrDTParidades = New ClsContieneParidades()
            MyBase.atrCampoFolio = "nParidad"
        End Sub

        Public Overrides Function getRow() As Comunes.Comun.ClsBaseComun2.ObtenerRowEventHandler
            Return AddressOf FabricaCatalogos.ObtenParidad
        End Function

        Public Shadows Function Guardar(Optional ByVal historico As Boolean = False) As Boolean
            Return EscribanoCatalogos.Guardar(Me, historico)
        End Function

        Public Property Moneda() As ClsMoneda
            Get
                Return atrMoneda
            End Get
            Set(ByVal value As ClsMoneda)
                atrMoneda = value
            End Set
        End Property

        Public Property Fecha() As Date
            Get
                Return atrdFecha
            End Get
            Set(ByVal value As Date)
                atrdFecha = value
            End Set
        End Property

        Public Property PrecioDeCompra() As Decimal
            Get
                Return atrnPrecioDeCompra
            End Get
            Set(ByVal value As Decimal)
                atrnPrecioDeCompra = value
            End Set
        End Property

        Public Property PrecioDeVenta() As Decimal
            Get
                Return atrnPrecioDeVenta
            End Get
            Set(ByVal value As Decimal)
                atrnPrecioDeVenta = value
            End Set
        End Property

        Public Property DiasVigencia() As Integer
            Get
                Return atrnDiasVigencia
            End Get

            Set(ByVal value As Integer)
                atrnDiasVigencia = value
            End Set
        End Property

        Public Sub GetParidadesHistorico(ByVal prmFechaInicio As Date, ByVal prmFechaFin As Date)
            Me.atrDTParidades.ArregloDT = FabricaCatalogos.ObtenContenedorParidades(Me.Moneda.Folio, prmFechaInicio, prmFechaFin)
        End Sub

        Public Property ParidadesHistorico() As ClsContieneParidades
            Get
                Return atrDTParidades
            End Get
            Set(ByVal value As ClsContieneParidades)
                atrDTParidades = value
            End Set
        End Property

    End Class
End Namespace