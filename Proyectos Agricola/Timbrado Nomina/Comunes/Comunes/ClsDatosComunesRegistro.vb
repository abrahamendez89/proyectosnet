
Imports Access
Namespace Comunes.Comun
    Public Class ClsDatosComunesRegistro


        Private atrUsuario As String
        Private atrFecha As DateTime
        Private atrMaquina As String
        Private atrInstanciaCorrecta As Boolean


        Public ReadOnly Property InstanciaCorrecta() As Boolean
            Get
                Return atrInstanciaCorrecta
            End Get
        End Property


        Public Property Usuario() As String
            Get
                Return atrUsuario
            End Get
            Set(ByVal Value As String)
                atrUsuario = Value
            End Set
        End Property

        Public Property Fecha() As DateTime
            Get
                Return atrFecha
            End Get
            Set(ByVal Value As DateTime)
                atrFecha = Value
            End Set
        End Property

        Public Property Maquina() As String
            Get
                Return atrMaquina
            End Get
            Set(ByVal Value As String)
                atrMaquina = Value
            End Set
        End Property

        Public Sub New()

        End Sub

        Public Sub New(ByVal prmUsuario As String, ByVal prmFecha As DateTime, ByVal prmMaquina As String, Optional ByVal INSTANCIA_CORRECTA As Boolean = True)
            atrUsuario = prmUsuario
            atrFecha = prmFecha
            atrMaquina = prmMaquina
            atrInstanciaCorrecta = INSTANCIA_CORRECTA
        End Sub

        Public Function TengoDatosValidos() As Boolean
            'Return atrUsuario.Trim <> "" AndAlso atrMaquina.Trim <> "" AndAlso ClsTools.NumeroJuliano(atrFecha) <> ClsTools.NumeroJuliano(ClsTools.FechaNulla)
        End Function

    End Class ' ClsDatosComunesRegistro

End Namespace ' Logical Model