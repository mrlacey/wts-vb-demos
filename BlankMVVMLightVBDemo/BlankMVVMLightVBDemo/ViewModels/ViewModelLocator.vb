Imports BlankMVVMLightVBDemo.Services
Imports BlankMVVMLightVBDemo.Views

Imports GalaSoft.MvvmLight.Ioc

Imports Microsoft.Practices.ServiceLocation

Namespace ViewModels
    Public Class ViewModelLocator
        Public Sub New()
            ServiceLocator.SetLocatorProvider(Function() SimpleIoc.[Default])
            If SimpleIoc.[Default].IsRegistered(Of NavigationServiceEx)() Then
                Return
            End If

            SimpleIoc.[Default].Register(Function() New NavigationServiceEx())
            Register(Of MainViewModel, MainPage)()
            Register(Of Blank1ViewModel, Blank1Page)()
            Register(Of Camera1ViewModel, Camera1Page)()
            Register(Of Chart1ViewModel, Chart1Page)()
            Register(Of Grid1ViewModel, Grid1Page)()
            Register(Of ImageGallery1ViewModel, ImageGallery1Page)()
            Register(Of ImageGallery1DetailViewModel, ImageGallery1DetailPage)()
            Register(Of Map1ViewModel, Map1Page)()
            Register(Of MasterDetail1ViewModel, MasterDetail1Page)()
            Register(Of MediaPlayer1ViewModel, MediaPlayer1Page)()
            Register(Of Settings1ViewModel, Settings1Page)()
            Register(Of Tabbed1ViewModel, Tabbed1Page)()
            Register(Of WebView1ViewModel, WebView1Page)()
            Register(Of ShareTarget1ViewModel, ShareTarget1Page)()
            Register(Of UriScheme1ExampleViewModel, UriScheme1ExamplePage)()
        End Sub

        Public ReadOnly Property UriScheme1ExampleViewModel As UriScheme1ExampleViewModel
            Get
                Return ServiceLocator.Current.GetInstance(Of UriScheme1ExampleViewModel)
            End Get
        End Property

        Public ReadOnly Property ShareTarget1ViewModel() As ShareTarget1ViewModel
            Get
                Return ServiceLocator.Current.GetInstance(Of ShareTarget1ViewModel)()
            End Get
        End Property

        Public ReadOnly Property WebView1ViewModel() As WebView1ViewModel
          Get
            Return ServiceLocator.Current.GetInstance(Of WebView1ViewModel)()
          End Get
        End Property

        Public ReadOnly Property Tabbed1ViewModel() As Tabbed1ViewModel
          Get
            Return ServiceLocator.Current.GetInstance(Of Tabbed1ViewModel)()
          End Get
        End Property

        Public ReadOnly Property Settings1ViewModel() As Settings1ViewModel
          Get
            Return ServiceLocator.Current.GetInstance(Of Settings1ViewModel)()
          End Get
        End Property

        Public ReadOnly Property MediaPlayer1ViewModel() As MediaPlayer1ViewModel
          Get
            Return ServiceLocator.Current.GetInstance(Of MediaPlayer1ViewModel)()
          End Get
        End Property

        Public ReadOnly Property MasterDetail1ViewModel() As MasterDetail1ViewModel
          Get
            Return ServiceLocator.Current.GetInstance(Of MasterDetail1ViewModel)()
          End Get
        End Property

        Public ReadOnly Property Map1ViewModel() As Map1ViewModel
          Get
            Return ServiceLocator.Current.GetInstance(Of Map1ViewModel)()
          End Get
        End Property

        Public ReadOnly Property ItemNameDetailViewModel As ImageGallery1DetailViewModel
            Get
                Return ServiceLocator.Current.GetInstance(Of ImageGallery1DetailViewModel)()
            End Get
        End Property

        Public ReadOnly Property ImageGallery1ViewModel() As ImageGallery1ViewModel
          Get
            Return ServiceLocator.Current.GetInstance(Of ImageGallery1ViewModel)()
          End Get
        End Property

        Public ReadOnly Property Grid1ViewModel() As Grid1ViewModel
          Get
            Return ServiceLocator.Current.GetInstance(Of Grid1ViewModel)()
          End Get
        End Property

        Public ReadOnly Property Chart1ViewModel() As Chart1ViewModel
          Get
            Return ServiceLocator.Current.GetInstance(Of Chart1ViewModel)()
          End Get
        End Property

        Public ReadOnly Property Camera1ViewModel() As Camera1ViewModel
          Get
            Return ServiceLocator.Current.GetInstance(Of Camera1ViewModel)()
          End Get
        End Property

        Public ReadOnly Property Blank1ViewModel() As Blank1ViewModel
          Get
            Return ServiceLocator.Current.GetInstance(Of Blank1ViewModel)()
          End Get
        End Property

        Public ReadOnly Property MainViewModel() As MainViewModel
          Get
            Return ServiceLocator.Current.GetInstance(Of MainViewModel)()
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
