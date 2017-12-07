﻿Namespace Views
    Public NotInheritable Partial Class WebView2Page
        Inherits Page
        Implements INotifyPropertyChanged
        ' TODO WTS: Set the URI of the page to show by default
        Private Const DefaultUrl As String = "https://developer.microsoft.com/en-us/windows/apps"

        Private _source As Uri

        Public Property Source As Uri
            Get
                Return _source
            End Get
            Set
                [Set](_source, value)
            End Set
        End Property

        Private _isLoading As Boolean

        Public Property IsLoading As Boolean
            Get
                Return _isLoading
            End Get

            Set
                If value Then
                    IsShowingFailedMessage = False
                End If

                [Set](_isLoading, value)
                IsLoadingVisibility = If(value, Visibility.Visible, Visibility.Collapsed)
            End Set
        End Property

        Private _isLoadingVisibility As Visibility

        Public Property IsLoadingVisibility As Visibility
            Get
                Return _isLoadingVisibility
            End Get
            Set
                [Set](_isLoadingVisibility, value)
            End Set
        End Property

        Private _isShowingFailedMessage As Boolean

        Public Property IsShowingFailedMessage As Boolean
            Get
                Return _isShowingFailedMessage
            End Get

            Set
                If value Then
                    IsLoading = False
                End If

                [Set](_isShowingFailedMessage, value)
                FailedMesageVisibility = If(value, Visibility.Visible, Visibility.Collapsed)
            End Set
        End Property

        Private _failedMesageVisibility As Visibility

        Public Property FailedMesageVisibility As Visibility
            Get
                Return _failedMesageVisibility
            End Get
            Set
                [Set](_failedMesageVisibility, value)
            End Set
        End Property

        Private Sub OnNavigationCompleted(sender As WebView, args As WebViewNavigationCompletedEventArgs)
            IsLoading = False
            OnPropertyChanged(nameof(IsBackEnabled))
            OnPropertyChanged(nameof(IsForwardEnabled))
        End Sub

        Private Sub OnNavigationFailed(sender As Object, e As WebViewNavigationFailedEventArgs)
            ' Use `e.WebErrorStatus` to vary the displayed message based on the error reason
            IsShowingFailedMessage = True
        End Sub

        Private Sub OnRetry(sender As Object, e As RoutedEventArgs)
            IsShowingFailedMessage = False
            IsLoading = True

            webView.Refresh()
        End Sub

        Public ReadOnly Property IsBackEnabled As Boolean
            Get
                Return webView.CanGoBack
            End Get
        End Property

        Public ReadOnly Property IsForwardEnabled As Boolean
            Get
                Return webView.CanGoForward
            End Get
        End Property

        Private Sub OnGoBack(sender As Object, e As RoutedEventArgs)
            webView.GoBack()
        End Sub

        Private Sub OnGoForward(sender As Object, e As RoutedEventArgs)
            webView.GoForward()
        End Sub

        Private Sub OnRefresh(sender As Object, e As RoutedEventArgs)
            webView.Refresh()
        End Sub

        Private Async Sub OnOpenInBrowser(sender As Object, e As RoutedEventArgs)
            Await Windows.System.Launcher.LaunchUriAsync(webView.Source)
        End Sub

        Public Sub New()
            Source = New Uri(DefaultUrl)
            InitializeComponent()
            IsLoading = True
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
