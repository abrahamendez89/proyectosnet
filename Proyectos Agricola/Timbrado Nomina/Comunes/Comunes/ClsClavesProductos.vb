Imports Access.Comunes.Comun
Imports Access.Comunes
Imports Access.Comunes.Comun.ClsTools
Imports Access
Namespace Comunes.Comun
    Public Class ClsClavesProductos

        Private DAO As DataAccessCls
        Private atrSPID As Int32
        Private atrDataTable As New DataTable
        Private vDRNew As DataRow

        Public Sub New()
            DAO = DataAccessCls.DevuelveInstancia
            atrSPID = DAO.RegresaDatoSQL("SELECT @@SPID")
            atrDataTable = New DataTable
            DAO.RegresaEsquemaDeDatos("SELECT * FROM PRO_Convierte_ProductosClaves (NOLOCK) WHERE 1 = 0", atrDataTable)
            atrDataTable.TableName = "PRO_Convierte_ProductosClaves"
            LimpiaTablaClavesBD()
        End Sub

        Public Sub AgregaRenglon_a_Tabla(ByVal prmAlmacen As Int32, ByVal prmProducto As Int32, ByVal prmClave As Int32, ByVal prmCantidad As Int32)
            vDRNew = atrDataTable.NewRow
            vDRNew("SPID") = atrSPID
            vDRNew("nAlmacen") = prmAlmacen
            vDRNew("nProducto") = prmProducto
            vDRNew("nClave") = prmClave
            If vDRNew("nClave") = 0 Then vDRNew("nClave") = DBNull.Value
            vDRNew("nCantidad") = prmCantidad
            atrDataTable.Rows.Add(vDRNew)
        End Sub

        Public Function InsertaDatosEnTablaBD() As Boolean
            Dim vbAbrioTransaccion As Boolean = False

            If Not DAO.TieneTransaccionAbierta Then
                DAO.AbreTransaccion()
                vbAbrioTransaccion = True
            End If

            If Not Tool.InsertaTablaDeBD(atrDataTable) Then
                If vbAbrioTransaccion Then
                    If DAO.TieneTransaccionAbierta Then DAO.DeshaceTransaccion()
                End If
                Return False
            End If

            If vbAbrioTransaccion Then
                If DAO.TieneTransaccionAbierta Then DAO.CierraTransaccion()
            End If

            Return True
        End Function

        Public Function ObtenClaves() As DataTable
            Dim vDt As New DataTable
            DAO.RegresaConsultaSQL("SELECT * FROM dbo.Tabla_ProductosClaves(" & atrSPID & ")", vDt)
            Return vDt
        End Function


        Public Sub LimpiaTablaClavesBD()
            DAO.EjecutaComandoSQL("SP_PRO_LimpiaTabla_PRO_Convierte_ProductosClaves " & atrSPID)
        End Sub
    End Class
End Namespace