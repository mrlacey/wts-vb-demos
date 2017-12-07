Imports BlankCodeBehindVBDemo.Services

Namespace Views
    Public NotInheritable Partial Class Settings4Page
        Inherits Page
        Implements INotifyPropertyChanged

        ' TODO WTS: Add other settings as necessary. For help see https://github.com/Microsoft/WindowsTemplateStudio/blob/master/docs/pages/settings-codebehind.md
        ' TODO WTS: Change the URL for your privacy policy in the Resource File, currently set to https://YourPrivacyUrlGoesHere
        Private _elementTheme As ElementTheme = ThemeSelectorService.Theme

        Public Property ElementTheme As ElementTheme
            Get
                Return _elementTheme
            End Get

            Set
                [Set](_elementTheme, value)
            End Set
        End Property

        Private _versionDescription As String

        Public Property VersionDescription As String
            Get
                Return _versionDescription
            End Get

            Set
                [Set](_versionDescription, value)
            End Set
        End Property

        Public Sub New()
            InitializeComponent()
        End Sub

        Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
            Initialize()
        End Sub

        Private Sub Initialize()
            VersionDescription = GetVersionDescription()

            If Microsoft.Services.Store.Engagement.StoreServicesFeedbackLauncher.IsSupported() Then
                FeedbackLink.Visibility = Visibility.Visible
            End If
        End Sub

        Private Function GetVersionDescription() As String
            Dim package = Windows.ApplicationModel.Package.Current
            Dim packageId = package.Id
            Dim version = packageId.Version

            Return $"{package.DisplayName} - {version.Major}.{version.Minor}.{version.Build}.{version.Revision}"
        End Function

        Private Async Sub ThemeChanged_CheckedAsync(sender As Object, e As RoutedEventArgs)
            Dim param = TryCast(sender, RadioButton)

            If param IsNot Nothing AndAlso param.CommandParameter IsNot Nothing Then
                Await ThemeSelectorService.SetThemeAsync(DirectCast(param.CommandParameter, ElementTheme))
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

        Private Async Sub FeedbackLink_Click(sender As Object, e As RoutedEventArgs)
            ' This launcher is part of the Store Services SDK https://docs.microsoft.com/en-us/windows/uwp/monetize/microsoft-store-services-sdk
            Dim launcher = Microsoft.Services.Store.Engagement.StoreServicesFeedbackLauncher.GetDefault()
            Await launcher.LaunchAsync()
        End Sub
    End Class
End Namespace
