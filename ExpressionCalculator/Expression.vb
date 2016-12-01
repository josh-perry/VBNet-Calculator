Public Class Expression
    Property Expression As String = String.Empty

    Sub New(exp As String)
        Expression = exp
    End Sub

    Public Function Calculate()
        Dim result As Integer = 10

        Return result
    End Function
End Class
