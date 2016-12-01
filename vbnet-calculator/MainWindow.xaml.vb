Class MainWindow
    Private View As CalculatorViewModel
    Private AcceptedKeys As Dictionary(Of String, String)

    Sub New()
        InitializeComponent()

        View = New CalculatorViewModel()
        DataContext = View

        AcceptedKeys = New Dictionary(Of String, String)
        For i As Integer = 0 To 9
            AcceptedKeys.Add(i.ToString, i.ToString)
        Next

        AcceptedKeys.Add("+", "+")
        AcceptedKeys.Add("−", "-")
        AcceptedKeys.Add("×", "*")
        AcceptedKeys.Add("÷", "/")
    End Sub

    Private Sub AddToExpression(add As String)
        ' Do logic for determining whether or not you can add this
        View.ExpressionTextProperty += add
    End Sub

    Private Sub CalculateExpression()
        ' Calculate expression and display result
        Try
            Dim result As Integer = New ExpressionCalculator.Expression(View.ExpressionTextProperty).Calculate()
            View.ResultTextProperty = result
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error")
        End Try
    End Sub

    Private Sub AddConvertedKeyToExpression(key As String)
        If AcceptedKeys.ContainsKey(key) Then
            AddToExpression(AcceptedKeys.Item(key))
        End If
    End Sub

#Region "Events"
    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        ' Get the button and text from it
        Dim s = DirectCast(sender, Button)
        Dim buttonText = s.Content

        ' Attempt to add to the current expression
        AddConvertedKeyToExpression(buttonText)
    End Sub

    Private Sub EqualsButton_Click(sender As Object, e As RoutedEventArgs)
        CalculateExpression()
    End Sub

    Private Sub ExpressionTextBox_KeyDown(sender As Object, e As KeyEventArgs)
        If e.Key = Key.Return Then
            e.Handled = True

            CalculateExpression()
            Return
        End If
    End Sub
#End Region
End Class
