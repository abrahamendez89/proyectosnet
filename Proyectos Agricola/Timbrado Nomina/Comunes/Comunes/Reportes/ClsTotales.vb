'
''
''  Totales.vb
''  Implementation of the Class Totales
''  Generated by Enterprise Architect
''  Created on:      23-Sep-2008 10:36:39 a.m.
''  Original author: 
''  
'
''  Modification history:
''  
''
'



Namespace Comunes.Comun
    Public Class ClsTotales


        Private atrCampo As ClsCampos
        Private atrOrden As Integer


        Public Property Campo() As ClsCampos
            Get
                Return atrCampo
            End Get
            Set(ByVal value As ClsCampos)
                atrCampo = value
            End Set
        End Property


        Public Property Orden() As Integer
            Get
                Return atrOrden
            End Get
            Set(ByVal value As Integer)
                atrOrden = value
            End Set
        End Property



    End Class ' Totales
End Namespace
