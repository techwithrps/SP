
Partial Class UserControl_DateTimeTextBox
    Inherits System.Web.UI.UserControl
    Public Property Text() As String
        Get
            Return Me.textDateTime.Text.Trim

        End Get
        Set(ByVal value As String)
            Me.textDateTime.Text = value
        End Set
    End Property
    Public Property Enabled() As Boolean
        Get
            Return Me.textDateTime.Enabled
        End Get
        Set(ByVal value As Boolean)
            Me.textDateTime.Enabled = value
        End Set
    End Property
End Class
