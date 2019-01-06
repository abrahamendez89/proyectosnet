Imports Access
Namespace Comunes.Comun
    Public Class EscribanoReportes
        Inherits Escribano

        Public Shared Function ReactivarReporte(ByVal prmReporte As ClsReporteGuarda) As Boolean
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia

            If DAO.EjecutaComandoSQL("update ADSUM_ReporteExpressGuarda set bactivo=1 where nreporteguarda=" & prmReporte.Folio) Then
                Return True
            End If

            Return False
        End Function


        Public Shared Function Guardar(ByVal prmReportes As ClsReportes) As Boolean
            prmReportes.atrNombreCampos = "nReporte,cReporte,cStore,cSqlSelect,cSqlFrom,cSqlWhere,cSqlGroup,cSqlOrder,cSqlHaving,bModificaColumna,bModificaAgrupacion,bModificaOrdenacion,bModificaTotales,bCalculaAcumulado,cCampoRelativo,cCampoAcumulado,bActivo,cClasificador,bOmitirAlias"
            prmReportes.atrNombreTabla = "ADSUM_ReportesExpress"

            If Not prmReportes.GuardarNuevo Then
                Return False
            End If

            For Each vrow As DataRow In prmReportes.CamposGlobal.ArregloDataTable.Rows
                vrow("nReporte") = prmReportes.Folio
            Next

            For Each vrow As DataRow In prmReportes.FiltrosGlobal.ArregloDataTable.Rows
                vrow("nReporte") = prmReportes.Folio
            Next

            If Not prmReportes.CamposGlobal.Guardar(False, True) Then
                Return False
            End If

            If Not prmReportes.FiltrosGlobal.Guardar(False, True) Then
                Return False
            End If

            Return True
        End Function

        Public Shared Function Guardar(ByVal prmReporteGuardar As ClsReporteGuarda) As Boolean
            prmReporteGuardar.atrNombreCampos = "nReporteGuarda,nReporte,ccamporelativo,cNombreReporte,cTitutoReporte,cConfiguracion,cUsuario,dfecha,bPublico,bActivo,bEliminaRegistros"
            prmReporteGuardar.atrNombreTabla = "ADSUM_ReporteExpressGuarda"

            If Not prmReporteGuardar.GuardarNuevo Then
                Return False
            End If

            Return True
        End Function

    End Class
End Namespace

