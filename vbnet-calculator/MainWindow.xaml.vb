Class MainWindow
    ''' <summary>
    ''' View model to use.
    ''' </summary>
    Private View As CalculatorViewModel

    ''' <summary>
    ''' Converts the buttons to the formula friendly equivilants.
    ''' Allows all buttons to use the same event handler.
    ''' </summary>
    Private AcceptedKeys As Dictionary(Of String, String)

    ''' <summary>
    ''' Constructor, sets up AcceptedKeys and the DataContext.
    ''' Initializes the ViewModel.
    ''' </summary>
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

    ''' <summary>
    ''' Append the string to ExpressionTextProperty on the View.
    ''' </summary>
    ''' <param name="add"></param>
    Private Sub AddToExpression(add As String)
        View.ExpressionTextProperty += add
    End Sub

    ''' <summary>
    ''' Calculate expression and display result.
    ''' </summary>
    Private Sub CalculateExpression()
        Try
            Dim result As Integer = New ExpressionCalculator.Expression(View.ExpressionTextProperty).Calculate()
            View.ResultTextProperty = result
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error")
        End Try
    End Sub

    ''' <summary>
    ''' Converts the button text to the formula friendly equivilant.
    ''' </summary>
    ''' <param name="key"></param>
    Private Sub AddConvertedKeyToExpression(key As String)
        If AcceptedKeys.ContainsKey(key) Then
            AddToExpression(AcceptedKeys.Item(key))
        End If
    End Sub

#Region "Events"
    ''' <summary>
    ''' Handler for click event on all UI buttons that append to the expression box.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        ' Get the button and text from it
        Dim buttonText = DirectCast(sender, Button).Content

        ' Attempt to add to the current expression
        AddConvertedKeyToExpression(buttonText)
    End Sub

    ''' <summary>
    ''' Handler for click event on the EqualsButton.
    ''' Calculate the expression.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub EqualsButton_Click(sender As Object, e As RoutedEventArgs)
        CalculateExpression()
    End Sub

    ''' <summary>
    ''' Handler for KeyDown on the expression box.
    ''' If return is hit then calculate the expression.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ExpressionTextBox_KeyDown(sender As Object, e As KeyEventArgs)
        If e.Key = Key.Return Then
            e.Handled = True

            CalculateExpression()
            Return
        End If
    End Sub

    ''' <summary>
    ''' Handler for click backspace button.
    ''' Deletes the last character in the expression window.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub BackspaceButton_Click(sender As Object, e As RoutedEventArgs)
        If View.ExpressionTextProperty.Length <= 0 Then
            ' Return early if the expression isn't long enough
            Return
        End If

        ' Cut off last character
        View.ExpressionTextProperty = View.ExpressionTextProperty.Substring(0, View.ExpressionTextProperty.Length - 1)
    End Sub

    ''' <summary>
    ''' Handler for click event on clear button.
    ''' Clears the expression window and the results window.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ClearButton_Click(sender As Object, e As RoutedEventArgs)
        ' Clear expression
        View.ExpressionTextProperty = String.Empty

        ' Clear result
        View.ResultTextProperty = String.Empty
    End Sub
#End Region
End Class
