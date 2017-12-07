Imports GalaSoft.MvvmLight
Imports GalaSoft.MvvmLight.Command

Imports SplitViewMVVMLightVBDemo.Services

Namespace ViewModels
    Public Class Settings7ViewModel
        Inherits ViewModelBase
        Public ReadOnly Property FeedbackLinkVisibility() As Visibility
            Get
                Return If(Microsoft.Services.Store.Engagement.StoreServicesFeedbackLauncher.IsSupported(), Visibility.Visible, Visibility.Collapsed)
            End Get
        End Property

        Private _launchFeedbackHubCommand As ICommand

        Public ReadOnly Property LaunchFeedbackHubCommand() As ICommand
            Get
                If _launchFeedbackHubCommand Is Nothing Then
                    _launchFeedbackHubCommand = New RelayCommand(Async Sub() 
                            ' This launcher is part of the Store Services SDK https://docs.microsoft.com/en-us/windows/uwp/monetize/microsoft-store-services-sdk
                            Dim launcher = Microsoft.Services.Store.Engagement.StoreServicesFeedbackLauncher.GetDefault()
                            Await launcher.LaunchAsync()
                        End Sub)
                End If

                Return _launchFeedbackHubCommand
            End Get
        End Property


        ' TODO WTS: Add other settings as necessary. For help see https://github.com/Microsoft/WindowsTemplateStudio/blob/master/docs/pages/settings.md
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
                [Set](_versionDescription, newValue := value)
            End Set
        End Property

        Private _switchThemeCommand As ICommand

        Public ReadOnly Property SwitchThemeCommand() As ICommand
            Get
                If _switchThemeCommand Is Nothing Then
                    _switchThemeCommand = New RelayCommand(Of ElementTheme)(Async Sub(param) 
                        Await ThemeSelectorService.SetThemeAsync(param)
                    End Sub)
                End If

                Return _switchThemeCommand
            End Get
        End Property

        Public Sub New()
        End Sub

        Public Sub Initialize()
            VersionDescription = GetVersionDescription()
        End Sub

        Private Function GetVersionDescription() As String
            Dim package = Windows.ApplicationModel.Package.Current
            Dim packageId = package.Id
            Dim version = packageId.Version

            Return $"{package.DisplayName} - {version.Major}.{version.Minor}.{version.Build}.{version.Revision}"
        End Function
    End Class
End Namespace
