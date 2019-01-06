Public Class RangoFechas

    Public Property Excluir() As Boolean
        Get
            Return False
        End Get
        Set(ByVal value As Boolean)

        End Set
    End Property

    Public Property Value1() As DateTime
        Get
            Return DateTimePicker1.Value
        End Get
        Set(ByVal value As DateTime)
            DateTimePicker1.Value = value
        End Set
    End Property

    Public Property Value2() As DateTime
        Get
            Return DateTimePicker2.Value
        End Get
        Set(ByVal value As DateTime)
            DateTimePicker2.Value = value
        End Set
    End Property


    Public Overrides Property Text() As String
        Get
            Return Label1.Text
        End Get
        Set(ByVal value As String)
            Label1.Text = value
        End Set
    End Property

    Private Sub RangoFechas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
