Namespace Comunes.Comun.ConfiguracionPermisos
    Public Class ClsPermisoSistema

        'Atributos Permiso ADSUM_PermisosSistema
        Private atrTipoPermiso As Catalogos.ClsTipoPermiso
        Private atrUsuario As String
        Private atrPermiso As String = ""
        Private atrValorDefault As String = ""
        Private atrBloquearATX As Boolean = False

        Public Sub New(ByVal prmTipoPermiso As Catalogos.ClsTipoPermiso, ByVal prmUsuario As String, ByVal prmPermiso As String, ByVal prmBloquearATX As Boolean, ByVal prmValorDefault As String)
            atrTipoPermiso = prmTipoPermiso
            atrUsuario = prmUsuario
            atrPermiso = prmPermiso
            atrValorDefault = prmValorDefault
            atrBloquearATX = prmBloquearATX
        End Sub

        Public ReadOnly Property TipoPermiso() As Catalogos.ClsTipoPermiso
            Get
                Return atrTipoPermiso
            End Get
        End Property

        Public ReadOnly Property Usario() As String
            Get
                Return atrUsuario
            End Get
        End Property

        Public ReadOnly Property Permiso() As String
            Get
                Return atrPermiso
            End Get
        End Property

        Public ReadOnly Property BloqueaATX() As Boolean
            Get
                Return atrBloquearATX
            End Get
        End Property


        Public ReadOnly Property ValorDefault() As String
            Get
                Return atrValorDefault
            End Get
        End Property
    End Class



End Namespace
