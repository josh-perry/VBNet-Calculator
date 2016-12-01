Imports System.ComponentModel

''' <summary>
''' View model for MainWindow.xaml
''' </summary>
Public Class CalculatorViewModel
    Implements INotifyPropertyChanged

    ''' <summary>
    ''' The text to show in the top textbox, showing the expression to calculate.
    ''' Bound two-way.
    ''' </summary>
    Private ExpressionText As String = String.Empty

    ''' <summary>
    ''' The text to show in the results textbox.
    ''' </summary>
    Private ResultText As String = String.Empty

    ''' <summary>
    ''' Property wrapper for ExpressionText.
    ''' Triggers INotifyPropertyChanged when set.
    ''' </summary>
    ''' <returns>ExpressionText</returns>
    Property ExpressionTextProperty() As String
        Get
            Return ExpressionText
        End Get

        Set(value As String)
            ExpressionText = value
            NotifyPropertyChanged("ExpressionTextProperty")
        End Set
    End Property

    ''' <summary>
    ''' Property wrapper for ResultText.
    ''' Triggers INotifyPropertyChanged when set.
    ''' </summary>
    ''' <returns>ResultText</returns>
    Property ResultTextProperty() As String
        Get
            Return ResultText
        End Get

        Set(value As String)
            ResultText = value
            NotifyPropertyChanged("ResultTextProperty")
        End Set
    End Property

    ''' <summary>
    ''' Property changed event for INotifyPropertyChanged
    ''' </summary>
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    ''' <summary>
    ''' Wrapper for PropertyChanged event raising.
    ''' </summary>
    ''' <param name="propertyName"></param>
    Private Sub NotifyPropertyChanged(ByVal propertyName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub
End Class