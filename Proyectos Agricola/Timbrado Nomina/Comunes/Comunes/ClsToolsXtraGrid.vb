Imports System.Windows.Forms
Imports Access.Comunes.Comun
Imports Access

Namespace Comunes.Comun

    Public Class ClsToolsXtraGrid

        Public Shared DAO As DataAccessCls = DataAccessCls.DevuelveInstancia

        Public Shared Function XtraGridPermiteSalir_LogisticaSalirAbajo(ByVal prmView As Object, ByVal prmColumnaSalida As Object, ByVal e As System.Windows.Forms.KeyEventArgs) As Boolean
            If Not prmView.IsFocusedView Then Return False
            If (e.KeyCode = keys.tab) Then
                If (prmView.FocusedRowHandle = (CType(prmView.DataSource, System.Data.DataView).Table.Rows.Count - 1)) _
                    And (prmView.FocusedColumn.Name.ToUpper = prmColumnaSalida.Name.ToUpper) Then
                    Return True
                End If
            End If
            Return False
        End Function

        Public Shared Function XtraGridPermiteSalir_LogisticaSalirArriba(ByVal prmView As Object, ByVal prmColumnaSalida As Object, ByVal e As System.Windows.Forms.KeyEventArgs, Optional ByVal prmNombreColumnaAnteriorFoco As String = "") As Boolean
            If Not prmView.IsFocusedView Then Return False
            If e.Shift = True Then
                If e.KeyCode = Keys.Tab _
                And (prmView.FocusedRowHandle = 0) _
                And (prmView.FocusedColumn.Name.ToUpper = prmColumnaSalida.Name.ToUpper) Then
                    If prmNombreColumnaAnteriorFoco.Trim = "" Then Return True
                    If prmView.FocusedColumn.Name = prmNombreColumnaAnteriorFoco.Trim Then
                        Return True
                    End If
                End If
            End If

            If (e.KeyCode = Keys.Escape OrElse (e.Shift = True AndAlso e.KeyCode = Keys.Tab)) And prmView.FocusedRowHandle = 0 Then
                If prmView.FocusedColumn.Name.ToUpper = prmColumnaSalida.Name.ToUpper Then
                    If prmNombreColumnaAnteriorFoco.Trim = "" Then Return True
                    If prmView.FocusedColumn.Name = prmNombreColumnaAnteriorFoco.Trim Then
                        Return True
                    End If
                End If
            End If

            Return False
        End Function

    End Class
End Namespace