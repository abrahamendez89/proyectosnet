Imports Access
Imports System.Data
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.IO

Namespace Comunes.Comun.ArchivoPlano
    Public Class ClsLeeFacturasCompras
        Inherits ClsArchivoPlanoBase
        Private atrUbicacionArchivo As String

        Public Property UbicacionArchivo() As String
            Get
                Return atrUbicacionArchivo
            End Get
            Set(ByVal Value As String)
                atrUbicacionArchivo = Value
            End Set
        End Property

        Public Sub New()
            MyBase.New()
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        End Sub

        Public Sub New(ByVal prmUbicacionArchivo)
            MyBase.New()
            atrUbicacionArchivo = prmUbicacionArchivo
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        End Sub

        Public Overrides Function getCaracterControlCamposAlphaNumericos() As String
            Return ""
        End Function

        Public Overrides Function getCaracterControlCamposNumericos() As String
            Return ""
        End Function

        Public Overrides Function getCaracterSeparadorCampos() As String
            Return ","
        End Function

        Public Overrides Function getFormatoTabla_O_TablaEscritura() As System.Data.DataTable
            getFormatoTabla_O_TablaEscritura = New DataTable("FACTURA_COMPRA")

            getFormatoTabla_O_TablaEscritura.Columns.Add(New DataColumn("cNumero", GetType(String)))
            getFormatoTabla_O_TablaEscritura.Columns.Add(New DataColumn("dFecha", GetType(String)))
            getFormatoTabla_O_TablaEscritura.Columns.Add(New DataColumn("cCodigo", GetType(String)))
            getFormatoTabla_O_TablaEscritura.Columns.Add(New DataColumn("cNombre", GetType(String)))

            getFormatoTabla_O_TablaEscritura.Columns.Add(New DataColumn("nCantidad", GetType(Decimal)))
            getFormatoTabla_O_TablaEscritura.Columns.Add(New DataColumn("nPrecio", GetType(Decimal)))
            getFormatoTabla_O_TablaEscritura.Columns.Add(New DataColumn("nTotal", GetType(Decimal)))
            getFormatoTabla_O_TablaEscritura.Columns.Add(New DataColumn("nIva", GetType(Decimal)))

            Return getFormatoTabla_O_TablaEscritura
        End Function

        Public Overrides Function getTerminadorRenglon() As String
            Return vbCrLf
        End Function

        Public Overrides Function getUbicacionArchivo() As String
            Return atrUbicacionArchivo
        End Function

        'Lee el archivo desde la ubicacion especificada por el parametro
        Public Function LeerArchivoFacturaCompra(ByVal prmUbicacionLecturaArchivo As String, ByVal prmUbicacionEscrituraArchivo As String) As DataTable
            Try
                Dim vReader As New StreamReader(prmUbicacionLecturaArchivo)
                'Dim vReaderEscritura As New StreamWriter(prmUbicacionEscrituraArchivo)
                Dim DtLeerArchivo As New DataTable

                LeerArchivoFacturaCompra = getFormatoTabla_O_TablaEscritura()
                DtLeerArchivo = LeerArchivo()

                If DtLeerArchivo Is Nothing Then Return Nothing

                Dim vLinea As String = vReader.ReadLine

                While Not vLinea Is Nothing AndAlso vLinea <> ""
                    Dim vRow As DataRow = LeerArchivo.NewRow
                    Dim vCampos() As String = vLinea.Split(getCaracterSeparadorCampos())
                    For x As Integer = 0 To vCampos.Length - 1
                        vRow(x) = DevuelveValorEnBaseTipo(DtLeerArchivo, vCampos(x), x)
                    Next
                    'LeerArchivo.Rows.Add(vRow)
                    'vReaderEscritura.WriteLine(vLinea)
                    vLinea = vReader.ReadLine
                End While

                vReader.Close()
                'vReaderEscritura.Close()

                Return LeerArchivo()
            Catch ex As Exception
                MessageBox.Show("Error de ArchivoPlano: " & ex.Message, "ArchivoPlano", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return Nothing
            End Try

        End Function


        Public Sub BorraArchivoMenosReciente()
            Dim misParametros As Comunes.Comun.Parametros.clsParametrosArchivoPlano = Comun.ClsTools.CargaParametrosArchivoPlano()

            Dim DtArchivosHistorico As New DataTable

            Dim nColArchivo As New DataColumn
            nColArchivo.ColumnName = "cArchivo"
            nColArchivo.DataType = GetType(System.String)
            DtArchivosHistorico.Columns.Add(nColArchivo)

            Dim nColFecha As New DataColumn
            nColFecha.ColumnName = "dFecha"
            nColFecha.DataType = GetType(System.String)
            DtArchivosHistorico.Columns.Add(nColFecha)

            Dim nColHora As New DataColumn
            nColHora.ColumnName = "nHora"
            nColHora.DataType = GetType(System.String)
            DtArchivosHistorico.Columns.Add(nColHora)

            Dim cRutaArchivo As New DataColumn
            cRutaArchivo.ColumnName = "cRutaArchivo"
            cRutaArchivo.DataType = GetType(System.String)
            DtArchivosHistorico.Columns.Add(cRutaArchivo)

            RegresaListadoArchivosEnDirectorio(misParametros.getRutaArchivosHistorialFacturasCompras_Value, DtArchivosHistorico, True, misParametros.getNombreNombreArchivoFacturasCompras)
            'Validamos si es necesario borrar el archivo menos reciente
            If Not DtArchivosHistorico.Select("cRutaArchivo<>'" & atrUbicacionArchivo.Trim & "'").Length <= DAO.ParametroAdministradoObtener("INV", "PRM_CantidadMaximaArchivosHistorialPedidos") Then
                For Each vrow As DataRow In DtArchivosHistorico.Select("cRutaArchivo<>'" & atrUbicacionArchivo.Trim & "'", "dFecha asc")
                    File.Delete(vrow("cRutaArchivo"))
                    Exit Sub
                Next
            End If
        End Sub


        Public Sub RegresaListadoArchivosEnDirectorio(ByVal prmRuta As String, ByRef prmDtArchivos As DataTable, Optional ByVal PrmRegresaFechaCompleta As Boolean = False, Optional ByVal PrmOmitirArchivoNombre As String = "")
            Dim vlArchivos As String()
            Dim vRow As DataRow
            Try

                Dim misParametros As Comunes.Comun.Parametros.clsParametrosArchivoPlano = Comun.ClsTools.CargaParametrosArchivoPlano()

                'vlArchivos = (Directory.GetFiles(prmRuta, "*.odb"))
                'Obtenemos solo los archivos que inicien con el siguiente nombre

                vlArchivos = (Directory.GetFiles(prmRuta, "*.asc"))


                For Each vRowNombreArchivo As String In vlArchivos
                    vRow = prmDtArchivos.NewRow()
                    vRow("cArchivo") = Replace(vRowNombreArchivo.Trim, prmRuta, "")

                    If Not PrmOmitirArchivoNombre.Trim = Trim(vRow("cArchivo")) And Not Trim(vRow("cArchivo")) = "" Then
                        If Not PrmRegresaFechaCompleta Then
                            vRow("dFecha") = File.GetCreationTime(prmRuta & vRow("cArchivo")).ToShortDateString
                        Else
                            vRow("dFecha") = File.GetCreationTime(prmRuta & vRow("cArchivo"))
                        End If

                        vRow("nHora") = File.GetCreationTime(prmRuta & vRow("cArchivo")).ToLongTimeString
                        vRow("cRutaArchivo") = vRowNombreArchivo.Trim
                        prmDtArchivos.Rows.Add(vRow)
                    End If
                Next


                Exit Sub

            Catch ex As Exception
                MessageBox.Show(ex.Message(), Comunes.Comun.ClsTools.GlobalSistemaCaption, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Sub

        Public Sub AbreArchivo(ByVal prmRutaArchivo As String)
            File.Open(prmRutaArchivo, FileMode.Open)
        End Sub


        Public Overloads Function LeerArchivo(ByVal prmNombreArchivo As String, ByVal prmRutaDentroWorkAbout As String, ByVal prmExtensionArchivoPlanoWorkAbout As String) As DataTable
            Dim miTabla As DataTable = LeerArchivo(prmNombreArchivo, prmRutaDentroWorkAbout, prmExtensionArchivoPlanoWorkAbout)
            Return miTabla
        End Function




    End Class
End Namespace

