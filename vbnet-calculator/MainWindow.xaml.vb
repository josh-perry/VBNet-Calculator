Class MainWindow
    Private View As CalculatorViewModel

    Sub New()
        InitializeComponent()

        View = New CalculatorViewModel()
        DataContext = View
    End Sub

    Private Sub AddToExpression(add As String)
        ' Do logic for determining whether or not you can add this
        View.ExpressionTextProperty += add
    End Sub

    Private Sub NumberButton_Click(sender As Object, e As RoutedEventArgs)
        ' Get the button and text from it
        Dim s = DirectCast(sender, Button)
        Dim buttonText = s.Content

        ' Attempt to add to the current expression
        AddToExpression(buttonText)
    End Sub

    Private Sub EqualsButton_Click(sender As Object, e As RoutedEventArgs)
        ' Calculate expression and display result
        Dim result As Integer = New ExpressionCalculator.Expression(View.ExpressionTextProperty).Calculate()
        View.ResultTextProperty = result
    End Sub

    Private Sub PlusButton_Click(sender As Object, e As RoutedEventArgs)
        AddToExpression("+")
    End Sub

    Private Sub MinusButton_Click(sender As Object, e As RoutedEventArgs)
        AddToExpression("-")
    End Sub

    Private Sub MultiplyButton_Click(sender As Object, e As RoutedEventArgs)
        AddToExpression("*")
    End Sub

    Private Sub DivideButton_Click(sender As Object, e As RoutedEventArgs)
        AddToExpression("/")
    End Sub
End Class
