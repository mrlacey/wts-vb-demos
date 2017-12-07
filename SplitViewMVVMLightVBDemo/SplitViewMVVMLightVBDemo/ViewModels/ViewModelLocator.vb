Imports GalaSoft.MvvmLight.Ioc

Imports Microsoft.Practices.ServiceLocation

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
            Register(Of MainViewModel, MainPage)()
            Register(Of Blank7ViewModel, Blank7Page)()
            Register(Of Camera7ViewModel, Camera7Page)()
            Register(Of Chart7ViewModel, Chart7Page)()
            Register(Of Grid7ViewModel, Grid7Page)()
            Register(Of ImageGallery7ViewModel, ImageGallery7Page)()
            Register(Of ImageGallery7DetailViewModel, ImageGallery7DetailPage)()
            Register(Of Map7ViewModel, Map7Page)()
            Register(Of MasterDetail7ViewModel, MasterDetail7Page)()
            Register(Of MediaPlayer7ViewModel, MediaPlayer7Page)()
            Register(Of Settings7ViewModel, Settings7Page)()
            Register(Of Tabbed7ViewModel, Tabbed7Page)()
            Register(Of WebView7ViewModel, WebView7Page)()
            Register(Of ShareTarget7ViewModel, ShareTarget7Page)()
            Register(Of UriScheme7ExampleViewModel, UriScheme7ExamplePage)()
        End Sub

        Public ReadOnly Property UriScheme7ExampleViewModel As UriScheme7ExampleViewModel
            Get
                Return ServiceLocator.Current.GetInstance(Of UriScheme7ExampleViewModel)
            End Get
        End Property

        Public ReadOnly Property ShareTarget7ViewModel() As ShareTarget7ViewModel
            Get
                Return ServiceLocator.Current.GetInstance(Of ShareTarget7ViewModel)()
            End Get
        End Property

        Public ReadOnly Property WebView7ViewModel() As WebView7ViewModel
          Get
            Return ServiceLocator.Current.GetInstance(Of WebView7ViewModel)()
          End Get
        End Property

        Public ReadOnly Property Tabbed7ViewModel() As Tabbed7ViewModel
          Get
            Return ServiceLocator.Current.GetInstance(Of Tabbed7ViewModel)()
          End Get
        End Property

        Public ReadOnly Property Settings7ViewModel() As Settings7ViewModel
          Get
            Return ServiceLocator.Current.GetInstance(Of Settings7ViewModel)()
          End Get
        End Property

        Public ReadOnly Property MediaPlayer7ViewModel() As MediaPlayer7ViewModel
          Get
            Return ServiceLocator.Current.GetInstance(Of MediaPlayer7ViewModel)()
          End Get
        End Property

        Public ReadOnly Property MasterDetail7ViewModel() As MasterDetail7ViewModel
          Get
            Return ServiceLocator.Current.GetInstance(Of MasterDetail7ViewModel)()
          End Get
        End Property

        Public ReadOnly Property Map7ViewModel() As Map7ViewModel
          Get
            Return ServiceLocator.Current.GetInstance(Of Map7ViewModel)()
          End Get
        End Property

        Public ReadOnly Property ItemNameDetailViewModel As ImageGallery7DetailViewModel
            Get
                Return ServiceLocator.Current.GetInstance(Of ImageGallery7DetailViewModel)()
            End Get
        End Property

        Public ReadOnly Property ImageGallery7ViewModel() As ImageGallery7ViewModel
          Get
            Return ServiceLocator.Current.GetInstance(Of ImageGallery7ViewModel)()
          End Get
        End Property

        Public ReadOnly Property Grid7ViewModel() As Grid7ViewModel
          Get
            Return ServiceLocator.Current.GetInstance(Of Grid7ViewModel)()
          End Get
        End Property

        Public ReadOnly Property Chart7ViewModel() As Chart7ViewModel
          Get
            Return ServiceLocator.Current.GetInstance(Of Chart7ViewModel)()
          End Get
        End Property

        Public ReadOnly Property Camera7ViewModel() As Camera7ViewModel
          Get
            Return ServiceLocator.Current.GetInstance(Of Camera7ViewModel)()
          End Get
        End Property

        Public ReadOnly Property Blank7ViewModel() As Blank7ViewModel
          Get
            Return ServiceLocator.Current.GetInstance(Of Blank7ViewModel)()
          End Get
        End Property

        Public ReadOnly Property MainViewModel() As MainViewModel
          Get
            Return ServiceLocator.Current.GetInstance(Of MainViewModel)()
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
