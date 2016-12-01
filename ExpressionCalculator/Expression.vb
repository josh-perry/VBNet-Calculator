Public Class Expression
    ''' <summary>
    ''' The original expression in string form
    ''' </summary>
    ''' <returns></returns>
    Property Expression As String = String.Empty

    ''' <summary>
    ''' Create a new expression from the provided string
    ''' </summary>
    ''' <param name="expressionStr">The string to create the expression from</param>
    Sub New(expressionStr As String)
        Expression = expressionStr
    End Sub

    ''' <summary>
    ''' Calculate the expression stored in Expression and return the result
    ''' </summary>
    ''' <returns>The result of the calculation</returns>
    Public Function Calculate()
        Dim result As Integer

        Dim scriptControl As New MSScriptControl.ScriptControl()
        scriptControl.Language = "VBScript"
        result = Convert.ToDouble(scriptControl.Eval(Expression))

        Return result
    End Function
End Class
