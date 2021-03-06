﻿Imports SplitViewCodeBehindVBDemo.EventHandlers

Namespace Views
    Public NotInheritable Partial Class CameraPage
        Inherits Page
        Implements INotifyPropertyChanged

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub CameraControl_PhotoTaken(sender As Object, e As CameraControlEventArgs)
            If Not String.IsNullOrEmpty(e.Photo) Then
                Photo.Source = New BitmapImage(New Uri(e.Photo))
            End If
        End Sub

        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

        Private Sub [Set](Of T)(ByRef storage As T, value As T, <CallerMemberName> Optional propertyName As String = Nothing)
            If Equals(storage, value) Then
                Return
            End If

            storage = value
            OnPropertyChanged(propertyName)
        End Sub

        Private Sub OnPropertyChanged(propertyName As String)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
        End Sub
    End Class
End Namespace
