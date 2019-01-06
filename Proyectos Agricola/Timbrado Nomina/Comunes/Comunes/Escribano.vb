Imports Access
Imports System.Data
Imports System.Data.SqlClient

Namespace Comunes.Comun

    Public Class Escribano

        Public Shared Function GuardarGenerico(ByVal prmSqlAdapter As SqlClient.SqlDataAdapter, ByVal prmTabla As DataTable, ByVal prmInserta As Boolean, ByVal prmActualiza As Boolean, Optional ByVal prmDAO As DataAccessCls = Nothing) As Boolean
            Dim vTablaTmp As DataTable
            Dim vRetorno As Boolean = True
            Dim DAO As DataAccessCls
            If prmDAO Is Nothing Then
                DAO = DataAccessCls.DevuelveInstancia
            Else
                DAO = prmDAO
            End If

            If prmInserta Then
                vTablaTmp = prmTabla.GetChanges(DataRowState.Added)
                If Not vTablaTmp Is Nothing Then
                    If DAO.InsertaDatosDeTablaSql(prmSqlAdapter, vTablaTmp) Then
                        vRetorno = True
                    Else
                        Return False
                    End If
                End If
            End If

            If prmActualiza Then
                vTablaTmp = prmTabla.GetChanges(DataRowState.Modified)
                If Not vTablaTmp Is Nothing Then
                    If DAO.ActualizaDatosDeTablaSql(prmSqlAdapter, vTablaTmp) Then
                        vRetorno = True
                    Else
                        Return False
                    End If
                End If
            End If


            Return vRetorno
        End Function

        Public Shared Function IFNullBase(ByVal miBase As ClsBaseComun, ByVal valorOpcional As Object) As Object
            If miBase Is Nothing Then
                Return valorOpcional
            End If
            Return miBase.Folio
        End Function

        Public Shared Function IFNullBase(ByVal miBase As ClsBaseComun) As Object
            Return IFNullBase(miBase, DBNull.Value)
        End Function

    End Class

End Namespace
