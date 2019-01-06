Imports Access
Imports System.Data
Imports System.Windows.Forms
Imports Sistema.Comunes.Comun

Public Class ClsBaseComunConsultaMovimiento

    Private atrUnicoElemento As String = ""
    Private atrFiltro As String = ""
    Private atrFolio As String = ""
    Private atrCamposEleccionUsuario As String = ""
    Private atrTablaEleccionUsuario As String = ""

    Public ReadOnly Property ElementoSeleccionado() As String
        Get
            Return atrUnicoElemento
        End Get
    End Property

    Public Delegate Function ExisteMasDeUnMovimientoEventHandler(ByVal prmFiltro As String, ByRef prmUnicoMovimiento As String, ByRef prmHayPedidos As Boolean) As Boolean
    Public ExisteMasDeUnMovimiento As ExisteMasDeUnMovimientoEventHandler

    Public Sub New(ByVal prmFolio As String, ByVal prmCamposSelectEleccionUSuario As String, ByVal prmTablaEleccionUsuario As String, ByVal prmFiltro As String)
        atrFolio = prmFolio
        atrCamposEleccionUsuario = prmCamposSelectEleccionUSuario
        atrTablaEleccionUsuario = prmTablaEleccionUsuario
        atrFiltro = prmFiltro
    End Sub

    Public Function UsuarioCanceloManejaConsultaDeSolicitudPedidoConFolioCorto() As Boolean
        atrUnicoElemento = ""
        If MuestraAyuda_ExistenMovimientosConMismoFolio() Then
            Dim vcEleccion As String = ClsTools.RegresaValorEleccionUsuario(atrCamposEleccionUsuario, atrTablaEleccionUsuario, atrFiltro)
            If vcEleccion.Trim = "" OrElse vcEleccion.Trim = "*" Then
                Return True
            End If
            atrUnicoElemento = vcEleccion.Trim
            Return False
        End If
        Return False
        'ObtenerRow = getRow()
        'If ObtenerRow Is Nothing Then
        '    Return Nothing
        'End If
        'If Not Row Is Nothing Then
        '    OnObtenerRow = ObtenerRow.Invoke(Row, Me)
        'Else
        '    Return Nothing
        'End If
    End Function

    Private Function MuestraAyuda_ExistenMovimientosConMismoFolio() As Boolean
        Dim vbHayPedidos As Boolean = False
        If FlExisteMasDeUnPedidoParaFolio(vbHayPedidos) Then
            If vbHayPedidos Then
                Return True
            End If
            Return False
        Else
            Return False
        End If
    End Function
    Private Function FlExisteMasDeUnPedidoParaFolio(ByRef prmHayPedidos As Boolean) As Boolean
        prmHayPEdidos = False
        If atrFolio.Trim = "" Then Return False
        If atrFolio.Length >= 13 Then
            prmHayPedidos = True
            atrUnicoElemento = atrFolio.ToString.Trim
            Return False
        End If
        Dim vcFiltro As String = atrFiltro
        Return Not ExisteMasDeUnMovimiento(atrFiltro, atrUnicoElemento, prmHayPedidos)
        'Return Not Inventarios.FabricaInventarios.ExisteSoloUnPedido(vcFiltro, prmUnicoMovimiento, prmHayPedidos)
    End Function
End Class
