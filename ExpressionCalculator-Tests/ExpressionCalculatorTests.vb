<TestClass()> Public Class ExpressionCalculatorTests
    <TestMethod()> Public Sub Test_SimpleAddition()
        ' Arrange
        Dim expString As String = "2+2"
        Dim exp As ExpressionCalculator.Expression = New ExpressionCalculator.Expression(expString)

        ' Act
        Dim result = exp.Calculate()

        ' Assert
        Assert.AreEqual(result, 4)
    End Sub
End Class