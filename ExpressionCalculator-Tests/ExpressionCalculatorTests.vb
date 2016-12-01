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

    <TestMethod()> Public Sub Test_SimpleAdditionWithSpaces()
        ' Arrange
        Dim expString As String = "2 + 2"
        Dim exp As ExpressionCalculator.Expression = New ExpressionCalculator.Expression(expString)

        ' Act
        Dim result = exp.Calculate()

        ' Assert
        Assert.AreEqual(result, 4)
    End Sub

    <TestMethod()> Public Sub Test_SimpleSubtraction()
        ' Arrange
        Dim expString As String = "2-2"
        Dim exp As ExpressionCalculator.Expression = New ExpressionCalculator.Expression(expString)

        ' Act
        Dim result = exp.Calculate()

        ' Assert
        Assert.AreEqual(result, 0)
    End Sub

    <TestMethod()> Public Sub Test_SimpleMultiplication()
        ' Arrange
        Dim expString As String = "3*3"
        Dim exp As ExpressionCalculator.Expression = New ExpressionCalculator.Expression(expString)

        ' Act
        Dim result = exp.Calculate()

        ' Assert
        Assert.AreEqual(result, 9)
    End Sub

    <TestMethod()> Public Sub Test_SimpleDivision()
        ' Arrange
        Dim expString As String = "9/3"
        Dim exp As ExpressionCalculator.Expression = New ExpressionCalculator.Expression(expString)

        ' Act
        Dim result = exp.Calculate()

        ' Assert
        Assert.AreEqual(result, 3)
    End Sub

    <TestMethod()> Public Sub Test_SimpleOrderOfOperations()
        ' Arrange
        Dim expString As String = "2 + 3 * 4"
        Dim exp As ExpressionCalculator.Expression = New ExpressionCalculator.Expression(expString)

        ' Act
        Dim result = exp.Calculate()

        ' Assert
        Assert.AreEqual(result, 14)
    End Sub

    <TestMethod()> Public Sub Test_Brackets()
        ' Arrange
        Dim expString As String = "(2 + 3) * 4"
        Dim exp As ExpressionCalculator.Expression = New ExpressionCalculator.Expression(expString)

        ' Act
        Dim result = exp.Calculate()

        ' Assert
        Assert.AreEqual(result, 20)
    End Sub
End Class