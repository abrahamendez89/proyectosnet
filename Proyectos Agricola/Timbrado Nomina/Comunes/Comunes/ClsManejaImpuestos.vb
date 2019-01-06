Imports Access.Dominio

Namespace Comunes.Comun
    Public Class ClsManejaImpuestos

        Public Shared Function DameCadenaArticulos(ByRef prmDt As DataTable, ByVal prmColumna_n_Articulo As String) As String
            Dim vcCadena As String = ""
            For Each dr As DataRow In prmDt.Rows
                If ClsTools.IfNull(dr(prmColumna_n_Articulo), 0) = 0 Then Continue For
                If vcCadena.Trim = "" Then
                    vcCadena = dr(prmColumna_n_Articulo)
                Else
                    vcCadena &= ", " & dr(prmColumna_n_Articulo)
                End If
            Next
            Return vcCadena
        End Function

    End Class
End Namespace