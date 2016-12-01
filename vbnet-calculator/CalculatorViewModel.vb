Imports System.ComponentModel

' View model for MainWindow.xaml
Public Class CalculatorViewModel
    Implements INotifyPropertyChanged

    Private ExpressionText As String = String.Empty
    Private ResultText As String = String.Empty

    Public Sub New()
    End Sub

    Property ExpressionTextProperty() As String
        Get
            Return ExpressionText
        End Get

        Set(value As String)
            ExpressionText = value
            NotifyPropertyChanged("ExpressionTextProperty")
        End Set
    End Property

    Property ResultTextProperty() As String
        Get
            Return ResultText
        End Get

        Set(value As String)
            ResultText = value
            NotifyPropertyChanged("ResultTextProperty")
        End Set
    End Property

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Private Sub NotifyPropertyChanged(ByVal propertyName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub
End Class