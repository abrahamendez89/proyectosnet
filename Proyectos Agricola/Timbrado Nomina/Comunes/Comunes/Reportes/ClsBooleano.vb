Public Class ClsBooleano

    Public Property Value() As Boolean
        Get
            Return CheckBox1.Checked
        End Get
        Set(ByVal value As Boolean)
            CheckBox1.Checked = value
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


    Private Sub ClsBooleano_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
