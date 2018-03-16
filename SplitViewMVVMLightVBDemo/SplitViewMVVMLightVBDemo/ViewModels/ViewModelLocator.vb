Imports CommonServiceLocator

Imports GalaSoft.MvvmLight.Ioc

Imports SplitViewMVVMLightVBDemo.Services
Imports SplitViewMVVMLightVBDemo.Views

Namespace ViewModels
    Public Class ViewModelLocator
        Public Sub New()
            ServiceLocator.SetLocatorProvider(Function() SimpleIoc.[Default])
            If SimpleIoc.[Default].IsRegistered(Of NavigationServiceEx)() Then
                Return
            End If

            SimpleIoc.[Default].Register(Function() New NavigationServiceEx())
            SimpleIoc.[Default].Register(Of ShellViewModel)()
            Register(Of BlankViewModel, BlankPage)()
            Register(Of SettingsViewModel, SettingsPage)()
            Register(Of Blank1ViewModel, Blank1Page)()
            Register(Of CameraViewModel, CameraPage)()
            Register(Of ChartViewModel, ChartPage)()
            Register(Of GridViewModel, GridPage)()
            Register(Of ImageGalleryViewModel, ImageGalleryPage)()
            Register(Of ImageGalleryDetailViewModel, ImageGalleryDetailPage)()
            Register(Of MapViewModel, MapPage)()
            Register(Of MasterDetailViewModel, MasterDetailPage)()
            Register(Of MediaPlayerViewModel, MediaPlayerPage)()
            Register(Of TabbedViewModel, TabbedPage)()
            Register(Of WebViewViewModel, WebViewPage)()
            Register(Of ShareTargetViewModel, ShareTargetPage)()
            Register(Of UriSchemeExampleViewModel, UriSchemeExamplePage)()
        End Sub


        Public ReadOnly Property UriSchemeExampleViewModel As UriSchemeExampleViewModel
            Get
                Return ServiceLocator.Current.GetInstance(Of UriSchemeExampleViewModel)
            End Get
        End Property


        Public ReadOnly Property ShareTargetViewModel As ShareTargetViewModel
            Get
                Return ServiceLocator.Current.GetInstance(Of ShareTargetViewModel)()
            End Get
        End Property


        Public ReadOnly Property WebViewViewModel As WebViewViewModel
            Get
                Return ServiceLocator.Current.GetInstance(Of WebViewViewModel)()
            End Get
        End Property


        Public ReadOnly Property TabbedViewModel As TabbedViewModel
            Get
                Return ServiceLocator.Current.GetInstance(Of TabbedViewModel)()
            End Get
        End Property


        Public ReadOnly Property MediaPlayerViewModel As MediaPlayerViewModel
            Get
                ' A Guid is generated as a unique key for each instance as reusing the same VM instance in multiple MediaPlayerElement instances can cause playback errors
                Return ServiceLocator.Current.GetInstance(Of MediaPlayerViewModel)(Guid.NewGuid().ToString())
            End Get
        End Property


        Public ReadOnly Property MasterDetailViewModel As MasterDetailViewModel
            Get
                Return ServiceLocator.Current.GetInstance(Of MasterDetailViewModel)()
            End Get
        End Property


        Public ReadOnly Property MapViewModel As MapViewModel
            Get
                Return ServiceLocator.Current.GetInstance(Of MapViewModel)()
            End Get
        End Property


        Public ReadOnly Property ImageGalleryDetailViewModel As ImageGalleryDetailViewModel
            Get
                Return ServiceLocator.Current.GetInstance(Of ImageGalleryDetailViewModel)()
            End Get
        End Property


        Public ReadOnly Property ImageGalleryViewModel As ImageGalleryViewModel
            Get
                Return ServiceLocator.Current.GetInstance(Of ImageGalleryViewModel)()
            End Get
        End Property


        Public ReadOnly Property GridViewModel As GridViewModel
            Get
                Return ServiceLocator.Current.GetInstance(Of GridViewModel)()
            End Get
        End Property


        Public ReadOnly Property ChartViewModel As ChartViewModel
            Get
                Return ServiceLocator.Current.GetInstance(Of ChartViewModel)()
            End Get
        End Property


        Public ReadOnly Property CameraViewModel As CameraViewModel
            Get
                Return ServiceLocator.Current.GetInstance(Of CameraViewModel)()
            End Get
        End Property


        Public ReadOnly Property Blank1ViewModel As Blank1ViewModel
            Get
                Return ServiceLocator.Current.GetInstance(Of Blank1ViewModel)()
            End Get
        End Property


        Public ReadOnly Property SettingsViewModel As SettingsViewModel
            Get
                Return ServiceLocator.Current.GetInstance(Of SettingsViewModel)()
            End Get
        End Property


        Public ReadOnly Property BlankViewModel As BlankViewModel
            Get
                Return ServiceLocator.Current.GetInstance(Of BlankViewModel)()
            End Get
        End Property

        Public ReadOnly Property ShellViewModel As ShellViewModel
            Get
                Return ServiceLocator.Current.GetInstance(Of ShellViewModel)()
            End Get
        End Property

        Public ReadOnly Property NavigationService As NavigationServiceEx
          Get
            Return ServiceLocator.Current.GetInstance(Of NavigationServiceEx)()
          End Get
        End Property

        Public Sub Register(Of VM As Class, V)()
            SimpleIoc.[Default].Register(Of VM)()
            NavigationService.Configure(GetType(VM).FullName, GetType(V))
        End Sub
    End Class
End Namespace
