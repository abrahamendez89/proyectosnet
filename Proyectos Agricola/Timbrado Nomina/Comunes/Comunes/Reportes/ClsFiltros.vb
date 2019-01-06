'
''
''  Filtros.vb
''  Implementation of the Class Filtros
''  Generated by Enterprise Architect
''  Created on:      23-Sep-2008 10:38:49 a.m.
''  Original author: 
''  
'
''  Modification history:
''  
''
'




Namespace Comunes.Comun
    Public Class ClsFiltros
        Inherits ClsBaseComun

        Private atrCampo As ClsCampos
        Private atrMetacatalogo As String
        Private atrObligatorio As Boolean
        Private atrTipoSeleccion As Integer
        Private atrAlias As String
        Private atrExclusion As Boolean
        Private atrTipoDefault As Integer
        Private atrValorDefault As String
        Private atrRenglon As Integer
        Private atrColumna As Integer


        Public Property Campo() As ClsCampos
            Get
                Return atrCampo
            End Get
            Set(ByVal value As ClsCampos)
                atrCampo = value
            End Set
        End Property


        Public Property Tipo() As String
            Get
                Return atrCampo.Tipo
            End Get
            Set(ByVal value As String)
                atrCampo.Tipo = value
            End Set
        End Property

        Public Property Obligatorio() As Boolean
            Get
                Return atrObligatorio
            End Get
            Set(ByVal value As Boolean)
                atrObligatorio = value
            End Set
        End Property


        Public Property Metacatalogo() As String
            Get
                Return atrMetacatalogo
            End Get
            Set(ByVal value As String)
                atrMetacatalogo = value
            End Set
        End Property


        Public Property Alia() As String
            Get
                Return atrAlias
            End Get
            Set(ByVal value As String)
                atrAlias = value
            End Set
        End Property


        Public Property TipoSeleccion() As Integer
            Get
                Return atrTipoSeleccion
            End Get
            Set(ByVal value As Integer)
                atrTipoSeleccion = value
            End Set
        End Property


        Public Property TipoDefault() As Integer
            Get
                Return atrTipoDefault
            End Get
            Set(ByVal value As Integer)
                atrTipoDefault = value
            End Set
        End Property

        Public Property ValorDefault() As String
            Get
                Return atrValorDefault
            End Get
            Set(ByVal value As String)
                atrValorDefault = value
            End Set
        End Property

        Public Property Renglon() As Integer
            Get
                Return atrRenglon
            End Get
            Set(ByVal value As Integer)
                atrRenglon = value
            End Set
        End Property


        Public Property Columna() As Integer
            Get
                Return atrColumna
            End Get
            Set(ByVal value As Integer)
                atrColumna = value
            End Set
        End Property





        Public Overrides Function FormatoFolio() As String
            Return ""
        End Function

        Public Overrides Function getNombreFolioAdministrado() As String
            Return ""
        End Function

        Public Overrides Function getRow() As ClsBaseComun.ObtenerRowEventHandler
            Return Nothing
        End Function
    End Class ' Filtros
End Namespace