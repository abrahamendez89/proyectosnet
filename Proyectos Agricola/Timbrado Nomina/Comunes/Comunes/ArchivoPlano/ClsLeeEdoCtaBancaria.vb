Imports Access
Imports System.Data
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.IO
Imports Access.Dominio.Bancos
Imports Sistema.Comunes.Catalogos.FabricaCatalogos
Imports Comunes.Comunes.Catalogos.Bancos
Imports Sistema.Comunes.Comun.ClsTools
Imports Sistema.Comunes.Catalogos

Namespace Comunes.Comun.ArchivoPlano
    Public Class ClsLeeEdoCtaBancaria
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
            Return ""
        End Function

        Public Overrides Function getFormatoTabla_O_TablaEscritura() As System.Data.DataTable
            getFormatoTabla_O_TablaEscritura = New DataTable("EDOCUENTA")

            getFormatoTabla_O_TablaEscritura.Columns.Add(New DataColumn("nBanco", GetType(Integer)))
            getFormatoTabla_O_TablaEscritura.Columns.Add(New DataColumn("nCuentaBancaria", GetType(Integer)))
            getFormatoTabla_O_TablaEscritura.Columns.Add(New DataColumn("nAno", GetType(Integer)))
            getFormatoTabla_O_TablaEscritura.Columns.Add(New DataColumn("nMes", GetType(Integer)))
            getFormatoTabla_O_TablaEscritura.Columns.Add(New DataColumn("cReferencia", GetType(String)))
            getFormatoTabla_O_TablaEscritura.Columns.Add(New DataColumn("cConcepto", GetType(String)))
            getFormatoTabla_O_TablaEscritura.Columns.Add(New DataColumn("nImporte", GetType(Decimal)))
            getFormatoTabla_O_TablaEscritura.Columns.Add(New DataColumn("bIntegrar", GetType(Boolean)))
            getFormatoTabla_O_TablaEscritura.Columns.Add(New DataColumn("bIntegrado", GetType(Boolean)))
            getFormatoTabla_O_TablaEscritura.Columns.Add(New DataColumn("nEfecto", GetType(Integer)))
            getFormatoTabla_O_TablaEscritura.Columns.Add(New DataColumn("nTipoMovimiento", GetType(Integer)))
            getFormatoTabla_O_TablaEscritura.Columns.Add(New DataColumn("cTipoMov", GetType(String)))
            getFormatoTabla_O_TablaEscritura.Columns.Add(New DataColumn("cNombreTipoMovimiento", GetType(String)))
            getFormatoTabla_O_TablaEscritura.Columns.Add(New DataColumn("dFecha", GetType(Date)))
            getFormatoTabla_O_TablaEscritura.Columns.Add(New DataColumn("nClaveMovimiento", GetType(Integer)))
            getFormatoTabla_O_TablaEscritura.Columns.Add(New DataColumn("bSeleccionado", GetType(Boolean)))
            getFormatoTabla_O_TablaEscritura.Columns.Add(New DataColumn("nRenglon", GetType(Integer)))
            getFormatoTabla_O_TablaEscritura.Columns.Add(New DataColumn("dFechaJuliana", GetType(Integer)))

            Return getFormatoTabla_O_TablaEscritura

        End Function

        Public Overrides Function getTerminadorRenglon() As String
            Return vbCrLf
        End Function

        Public Overrides Function getUbicacionArchivo() As String
            Return atrUbicacionArchivo
        End Function

        Public Overloads Function LeerArchivo(ByVal prmUbicacionLecturaArchivo As String, ByVal prmConfiguracion As Long, ByVal prmCuentaBancaria As Integer, ByVal prmBanco As Integer, Optional ByVal prmEfecto As Integer = 0) As DataTable

            Dim vContador As Integer
            Dim ObjConfiguracionEdoCtaBan As ClsConfiguracionEdoCtaBan

            Dim vFecha As Date
            Dim vEfecto As Integer
            Dim vObservacion As String
            Dim vReferencia As String
            Dim vImporte As Decimal
            Dim vSinPuntoDecimal As Boolean
            Dim vCuantosDecimales As Integer
            Dim vRenglon As Integer

            Dim vCampos() As String
            Dim vContradiccion As Boolean

            Dim vFormatoFecha As String
            Dim vAnio As Integer
            Dim vMes As Integer
            Dim vDia As Integer

            Dim vCampoFecha As String
            Dim vCampoIngresoEgreso As String
            Dim vCampoObservacion As String
            Dim vCampoReferencia As String
            Dim vCampoImporte As String
            Dim vCampoClave As String
            Dim vEntroEnDetalle As Boolean

            Try
                Dim vReader As New StreamReader(prmUbicacionLecturaArchivo)

                LeerArchivo = getFormatoTabla_O_TablaEscritura()
                If LeerArchivo Is Nothing Then Return Nothing

                ObjConfiguracionEdoCtaBan = ObtenConfiguracionEdoCtaBan(CType(prmConfiguracion, Integer))

                If ObjConfiguracionEdoCtaBan Is Nothing Then Return Nothing


                vContador = 0
                vRenglon = 0
                vEntroEnDetalle = False

                Dim vLinea As String
                While Not vReader.EndOfStream
                    vLinea = vReader.ReadLine

                    vCampoIngresoEgreso = ""
                    vCampoFecha = ""
                    vCampoObservacion = ""
                    vCampoReferencia = ""
                    vCampoImporte = ""
                    vCampoClave = ""

                    vObservacion = ""
                    vReferencia = ""
                    vImporte = 0
                    vSinPuntoDecimal = False
                    vCuantosDecimales = 0


                    vContador += 1

                    If vContador >= ObjConfiguracionEdoCtaBan.nLineaIniciaDetalle Then
                        If Not vLinea Is Nothing AndAlso vLinea <> "" Then

                            vEntroEnDetalle = True

                            If ObjConfiguracionEdoCtaBan.bImporteIngresoPorPosicion Then
                                vCampoIngresoEgreso = Mid(vLinea, ObjConfiguracionEdoCtaBan.nPosIniIngreso, ObjConfiguracionEdoCtaBan.nPosFinIngreso + 1 - ObjConfiguracionEdoCtaBan.nPosIniIngreso)
                            Else
                                vCampos = vLinea.Split(ObjConfiguracionEdoCtaBan.cSeparadorIngreso)
                                If vCampos.Length >= ObjConfiguracionEdoCtaBan.nPosicionIngresoConSeparador - 1 Then
                                    vCampoIngresoEgreso = vCampos(ObjConfiguracionEdoCtaBan.nPosicionIngresoConSeparador - 1)
                                End If
                            End If

                            vContradiccion = ObjConfiguracionEdoCtaBan.bDiferenteDeIngreso

                            If vContradiccion Then
                                If vCampoIngresoEgreso <> ObjConfiguracionEdoCtaBan.cValorIdentificaComoIngreso Then
                                    vEfecto = 1
                                Else
                                    vEfecto = -1
                                End If
                            Else
                                If vCampoIngresoEgreso = ObjConfiguracionEdoCtaBan.cValorIdentificaComoIngreso Then
                                    vEfecto = 1
                                Else
                                    vEfecto = -1
                                End If
                            End If

                            If vEfecto = 1 Then

                                '' Obtengo la Fecha si es un ingreso
                                If ObjConfiguracionEdoCtaBan.bEsFechaPorPosicionIngreso Then
                                    vCampoFecha = Mid(vLinea, ObjConfiguracionEdoCtaBan.nPosIniFechaIngreso, ObjConfiguracionEdoCtaBan.nPosFinFechaIngreso + 1 - ObjConfiguracionEdoCtaBan.nPosIniFechaIngreso)
                                Else
                                    vCampos = vLinea.Split(ObjConfiguracionEdoCtaBan.cSeparadorFechaIngreso)
                                    If vCampos.Length >= ObjConfiguracionEdoCtaBan.nPosicionFechaIngresoConSeparador - 1 Then
                                        vCampoFecha = vCampos(ObjConfiguracionEdoCtaBan.nPosicionFechaIngresoConSeparador - 1)
                                    End If
                                End If
                                vFormatoFecha = ObjConfiguracionEdoCtaBan.cFormatoFechaIngreso

                                '' Obtengo la Observacion de un ingreso

                                If ObjConfiguracionEdoCtaBan.bObservacionIngresoPorPosicion Then
                                    vCampoObservacion = Mid(vLinea, ObjConfiguracionEdoCtaBan.nPosIniObservacionIngreso, ObjConfiguracionEdoCtaBan.nPosFinObservacionIngreso + 1 - ObjConfiguracionEdoCtaBan.nPosIniObservacionIngreso)
                                Else
                                    vCampos = vLinea.Split(ObjConfiguracionEdoCtaBan.cSeparadorObservacionIngreso)
                                    If vCampos.Length >= ObjConfiguracionEdoCtaBan.nPosicionObservacionIngreso - 1 Then
                                        vCampoObservacion = vCampos(ObjConfiguracionEdoCtaBan.nPosicionObservacionIngreso - 1)
                                    End If
                                End If


                                '' Obtengo la Referencia de un ingreso

                                If ObjConfiguracionEdoCtaBan.bReferenciaIngresoPorPosicion Then
                                    vCampoReferencia = Mid(vLinea, ObjConfiguracionEdoCtaBan.nPosIniReferenciaIngreso, ObjConfiguracionEdoCtaBan.nPosFinReferenciaIngreso + 1 - ObjConfiguracionEdoCtaBan.nPosIniReferenciaIngreso)
                                Else
                                    vCampos = vLinea.Split(ObjConfiguracionEdoCtaBan.cSeparadorReferenciaIngreso)
                                    If vCampos.Length >= ObjConfiguracionEdoCtaBan.nPosicionReferenciaIngreso - 1 Then
                                        vCampoReferencia = vCampos(ObjConfiguracionEdoCtaBan.nPosicionReferenciaIngreso - 1)
                                    End If
                                End If


                                '' Obtengo el Importe de un ingreso

                                If ObjConfiguracionEdoCtaBan.bImporteIngresoPorPosicion Then
                                    vCampoImporte = Mid(vLinea, ObjConfiguracionEdoCtaBan.nPosIniImporteIngreso, ObjConfiguracionEdoCtaBan.nPosFinImporteIngreso + 1 - ObjConfiguracionEdoCtaBan.nPosIniImporteIngreso)
                                Else
                                    vCampos = vLinea.Split(ObjConfiguracionEdoCtaBan.cSeparadorImporteIngreso)
                                    If vCampos.Length >= ObjConfiguracionEdoCtaBan.nPosicionImporteIngreso - 1 Then
                                        vCampoImporte = vCampos(ObjConfiguracionEdoCtaBan.nPosicionImporteIngreso - 1)
                                    End If
                                End If

                                vSinPuntoDecimal = ObjConfiguracionEdoCtaBan.bSinPuntoDecimalImporteIngreso
                                vCuantosDecimales = ObjConfiguracionEdoCtaBan.nPosicionesDecimalImporteIngreso


                                '' Obtengo la Clave de un ingreso

                                If ObjConfiguracionEdoCtaBan.bReferenciaIngresoPorPosicion Then
                                    If ObjConfiguracionEdoCtaBan.nPosIniClaveIngreso <> 0 Or ObjConfiguracionEdoCtaBan.nPosFinClaveIngreso <> 0 Then
                                        vCampoClave = Mid(vLinea, ObjConfiguracionEdoCtaBan.nPosIniClaveIngreso, ObjConfiguracionEdoCtaBan.nPosFinClaveIngreso + 1 - ObjConfiguracionEdoCtaBan.nPosIniClaveIngreso)
                                    End If
                                Else
                                    vCampos = vLinea.Split(ObjConfiguracionEdoCtaBan.cSeparadorClaveIngreso)
                                    If vCampos.Length >= ObjConfiguracionEdoCtaBan.nPosicionClaveIngreso - 1 Then
                                        vCampoClave = vCampos(ObjConfiguracionEdoCtaBan.nPosicionClaveIngreso - 1)
                                    End If
                                End If

                            Else

                                '' Obtengo la Fecha si es un egreso
                                If ObjConfiguracionEdoCtaBan.bEsFechaPorPosicionEgreso Then
                                    vCampoFecha = Mid(vLinea, ObjConfiguracionEdoCtaBan.nPosIniFechaEgreso, ObjConfiguracionEdoCtaBan.nPosFinFechaEgreso + 1 - ObjConfiguracionEdoCtaBan.nPosIniFechaEgreso)
                                Else
                                    vCampos = vLinea.Split(ObjConfiguracionEdoCtaBan.cSeparadorFechaEgreso)

                                    If vCampos.Length >= ObjConfiguracionEdoCtaBan.nPosicionFechaEgresoConSeparador - 1 Then
                                        vCampoFecha = vCampos(ObjConfiguracionEdoCtaBan.nPosicionFechaEgresoConSeparador - 1)
                                    End If
                                End If
                                vFormatoFecha = ObjConfiguracionEdoCtaBan.cFormatoFechaEgreso

                                '' Obtengo la Observacion de un egreso

                                If ObjConfiguracionEdoCtaBan.bObservacionEgresoPorPosicion Then
                                    vCampoObservacion = Mid(vLinea, ObjConfiguracionEdoCtaBan.nPosIniObservacionEgreso, ObjConfiguracionEdoCtaBan.nPosFinObservacionEgreso + 1 - ObjConfiguracionEdoCtaBan.nPosIniObservacionEgreso)
                                Else
                                    vCampos = vLinea.Split(ObjConfiguracionEdoCtaBan.cSeparadorObservacionEgreso)
                                    If vCampos.Length >= ObjConfiguracionEdoCtaBan.nPosicionObservacionEgreso - 1 Then
                                        vCampoObservacion = vCampos(ObjConfiguracionEdoCtaBan.nPosicionObservacionEgreso - 1)
                                    End If
                                End If

                                '' Obtengo la Referencia de un egreso

                                If ObjConfiguracionEdoCtaBan.bReferenciaEgresoPorPosicion Then
                                    vCampoReferencia = Mid(vLinea, ObjConfiguracionEdoCtaBan.nPosIniReferenciaEgreso, ObjConfiguracionEdoCtaBan.nPosFinReferenciaEgreso + 1 - ObjConfiguracionEdoCtaBan.nPosIniReferenciaEgreso)
                                Else
                                    vCampos = vLinea.Split(ObjConfiguracionEdoCtaBan.cSeparadorReferenciaEgreso)
                                    If vCampos.Length >= ObjConfiguracionEdoCtaBan.nPosicionReferenciaEgreso - 1 Then
                                        vCampoReferencia = vCampos(ObjConfiguracionEdoCtaBan.nPosicionReferenciaEgreso - 1)
                                    End If
                                End If


                                '' Obtengo el Importe de un egreso

                                If ObjConfiguracionEdoCtaBan.bImporteEgresoPorPosicion Then
                                    vCampoImporte = Mid(vLinea, ObjConfiguracionEdoCtaBan.nPosIniImporteEgreso, ObjConfiguracionEdoCtaBan.nPosFinImporteEgreso + 1 - ObjConfiguracionEdoCtaBan.nPosIniImporteEgreso)
                                Else
                                    vCampos = vLinea.Split(ObjConfiguracionEdoCtaBan.cSeparadorImporteEgreso)
                                    If vCampos.Length >= ObjConfiguracionEdoCtaBan.nPosicionImporteEgreso - 1 Then
                                        vCampoImporte = vCampos(ObjConfiguracionEdoCtaBan.nPosicionImporteEgreso - 1)
                                    End If
                                End If

                                vSinPuntoDecimal = ObjConfiguracionEdoCtaBan.bSinPuntoDecimalImporteEgreso
                                vCuantosDecimales = ObjConfiguracionEdoCtaBan.nPosicionesDecimalImporteEgreso


                                '' Obtengo la Clave de un Egreso

                                If ObjConfiguracionEdoCtaBan.bReferenciaEgresoPorPosicion Then
                                    If ObjConfiguracionEdoCtaBan.nPosIniClaveEgreso <> 0 Then
                                        vCampoClave = Mid(vLinea, ObjConfiguracionEdoCtaBan.nPosIniClaveEgreso, ObjConfiguracionEdoCtaBan.nPosFinClaveEgreso + 1 - ObjConfiguracionEdoCtaBan.nPosIniClaveEgreso)
                                    End If
                                Else
                                    vCampos = vLinea.Split(ObjConfiguracionEdoCtaBan.cSeparadorClaveEgreso)
                                    If vCampos.Length >= ObjConfiguracionEdoCtaBan.nPosicionClaveEgreso - 1 Then
                                        vCampoClave = vCampos(ObjConfiguracionEdoCtaBan.nPosicionClaveEgreso - 1)
                                    End If
                                End If

                            End If


                            Select Case UCase(vFormatoFecha)

                                Case "DDMMYY"

                                    vAnio = (CType((Year(DAO.RegresaFechaDelSistema) / 1000), Integer) * 1000) + Mid(vCampoFecha, 5, 2)
                                    vMes = Mid(vCampoFecha, 3, 2)
                                    vDia = Mid(vCampoFecha, 1, 2)


                                Case "DD/MM/YYYY"

                                    vAnio = Mid(vCampoFecha, 7, 4)
                                    vMes = Mid(vCampoFecha, 4, 2)
                                    vDia = Mid(vCampoFecha, 1, 2)

                                Case "DD MMM YYYY"

                                    vAnio = Mid(vCampoFecha, 8, 4)

                                    Select Case Mid(vCampoFecha, 4, 3)
                                        Case "ENE", "JAN"
                                            vMes = 1
                                        Case "FEB"
                                            vMes = 2
                                        Case "MAR"
                                            vMes = 3
                                        Case "ABR", "APR"
                                            vMes = 4
                                        Case "MAY"
                                            vMes = 5
                                        Case "JUN"
                                            vMes = 6
                                        Case "JUL"
                                            vMes = 7
                                        Case "AGO", "AUG"
                                            vMes = 8
                                        Case "SEP"
                                            vMes = 9
                                        Case "OCT"
                                            vMes = 10
                                        Case "NOV"
                                            vMes = 11
                                        Case "DIC", "DEC"
                                            vMes = 12
                                    End Select

                                    vDia = Mid(vCampoFecha, 1, 2)

                                Case "YYYYMMDD"

                                    vAnio = Mid(vCampoFecha, 1, 4)
                                    vMes = Mid(vCampoFecha, 5, 2)
                                    vDia = Right(vCampoFecha, 2)

                                Case "DDMMYYYY"

                                    vAnio = Mid(vCampoFecha, 5, 4)
                                    vMes = Mid(vCampoFecha, 3, 2)
                                    vDia = Left(vCampoFecha, 2)

                                Case "YYYY/MM/DD"

                                    vAnio = Left(vCampoFecha, 4)
                                    vMes = Mid(vCampoFecha, 6, 2)
                                    vDia = Right(vCampoFecha, 2)

                                Case "YYYY/DD/MM"

                                    vAnio = Left(vCampoFecha, 4)
                                    vMes = Right(vCampoFecha, 2)
                                    vDia = Mid(vCampoFecha, 6, 2)

                                Case "DD-MM-YYYY"

                                    vAnio = Mid(vCampoFecha, 7, 4)
                                    vMes = Mid(vCampoFecha, 4, 2)
                                    vDia = Mid(vCampoFecha, 1, 2)


                                Case "YYYY-MM-DD"

                                    vAnio = Left(vCampoFecha, 4)
                                    vMes = Mid(vCampoFecha, 6, 2)
                                    vDia = Right(vCampoFecha, 2)


                                Case "YYYY-DD-MM"

                                    vAnio = Left(vCampoFecha, 4)
                                    vMes = Right(vCampoFecha, 2)
                                    vDia = Mid(vCampoFecha, 6, 2)

                            End Select

                            vFecha = New Date(vAnio, vMes, vDia)

                            vCampoImporte = Replace(vCampoImporte, ",", "")
                            vCampoImporte = Replace(vCampoImporte, "$", "")

                            If vSinPuntoDecimal Then
                                vImporte = CType(Left(vCampoImporte, vCampoImporte.Length - vCuantosDecimales) & "." & Right(vCampoImporte, vCuantosDecimales), Decimal)
                            Else
                                vImporte = CType(vCampoImporte, Decimal)
                            End If
                            If prmEfecto = 0 OrElse prmEfecto = vEfecto Then
                                If vImporte > 0 And IsDate(vFecha) Then
                                    Dim vRow As DataRow = LeerArchivo.NewRow

                                    vRenglon += 1

                                    vRow(0) = prmBanco
                                    vRow(1) = prmCuentaBancaria
                                    vRow(2) = vAnio
                                    vRow(3) = vMes
                                    vRow(4) = vCampoReferencia
                                    vRow(5) = vCampoObservacion
                                    vRow(6) = vImporte
                                    vRow(7) = True
                                    vRow(8) = False
                                    vRow(9) = vEfecto
                                    vRow(10) = 0
                                    vRow(11) = IIf(vEfecto = 1, "Ingreso", "Egreso")
                                    vRow(12) = ""
                                    vRow(13) = vFecha
                                    vRow(14) = IIf(vCampoClave = "", 0, vCampoClave)
                                    vRow(15) = False
                                    vRow(16) = vRenglon
                                    vRow(17) = NumeroJuliano(vFecha)

                                    LeerArchivo.Rows.Add(vRow)
                                End If
                            End If
                        End If
                    End If

                End While

                vReader.Close()
                Return LeerArchivo
            Catch ex As Exception
                MessageBox.Show("Error al leer archivo plano: " & ex.Message, "WorkAbout", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return Nothing
            End Try

        End Function

        Public Shared Function MuestraDialogo() As String

            Dim OpenFileDialog1 As New System.Windows.Forms.OpenFileDialog


            OpenFileDialog1.FileName = ""
            OpenFileDialog1.Filter = "Archivos Bancarios (*.*)|*.*"
            OpenFileDialog1.FilterIndex = 1

            OpenFileDialog1.ShowDialog()

            Return OpenFileDialog1.FileName
        End Function


    End Class

End Namespace
