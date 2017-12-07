Imports GalaSoft.MvvmLight.Ioc

Imports Microsoft.Practices.ServiceLocation

Imports TabbedPivotMVVMLightVBDemo.Services
Imports TabbedPivotMVVMLightVBDemo.Views

Namespace ViewModels
    Public Class ViewModelLocator
        Public Sub New()
            ServiceLocator.SetLocatorProvider(Function() SimpleIoc.[Default])
            If SimpleIoc.[Default].IsRegistered(Of NavigationServiceEx)() Then
                Return
            End If

            SimpleIoc.[Default].Register(Function() New NavigationServiceEx())
            Register(Of PivotViewModel, PivotPage)()
            Register(Of MainViewModel, MainPage)()
            Register(Of Blank8ViewModel, Blank8Page)()
            Register(Of Camera8ViewModel, Camera8Page)()
            Register(Of Chart8ViewModel, Chart8Page)()
            Register(Of Grid8ViewModel, Grid8Page)()
            Register(Of ImageGallery8ViewModel, ImageGallery8Page)()
            Register(Of ImageGallery8DetailViewModel, ImageGallery8DetailPage)()
            Register(Of Map8ViewModel, Map8Page)()
            Register(Of MasterDetail8ViewModel, MasterDetail8Page)()
            Register(Of MediaPlayer8ViewModel, MediaPlayer8Page)()
            Register(Of Settings8ViewModel, Settings8Page)()
            Register(Of Tabbed8ViewModel, Tabbed8Page)()
            Register(Of WebView8ViewModel, WebView8Page)()
            Register(Of ShareTarget8ViewModel, ShareTarget8Page)()
            Register(Of UriScheme8ExampleViewModel, UriScheme8ExamplePage)()
        End Sub

        Public ReadOnly Property UriScheme8ExampleViewModel As UriScheme8ExampleViewModel
            Get
                Return ServiceLocator.Current.GetInstance(Of UriScheme8ExampleViewModel)
            End Get
        End Property

        Public ReadOnly Property ShareTarget8ViewModel() As ShareTarget8ViewModel
            Get
                Return ServiceLocator.Current.GetInstance(Of ShareTarget8ViewModel)()
            End Get
        End Property

        Public ReadOnly Property WebView8ViewModel() As WebView8ViewModel
          Get
            Return ServiceLocator.Current.GetInstance(Of WebView8ViewModel)()
          End Get
        End Property

        Public ReadOnly Property Tabbed8ViewModel() As Tabbed8ViewModel
          Get
            Return ServiceLocator.Current.GetInstance(Of Tabbed8ViewModel)()
          End Get
        End Property

        Public ReadOnly Property Settings8ViewModel() As Settings8ViewModel
          Get
            Return ServiceLocator.Current.GetInstance(Of Settings8ViewModel)()
          End Get
        End Property

        Public ReadOnly Property MediaPlayer8ViewModel() As MediaPlayer8ViewModel
          Get
            Return ServiceLocator.Current.GetInstance(Of MediaPlayer8ViewModel)()
          End Get
        End Property

        Public ReadOnly Property MasterDetail8ViewModel() As MasterDetail8ViewModel
          Get
            Return ServiceLocator.Current.GetInstance(Of MasterDetail8ViewModel)()
          End Get
        End Property

        Public ReadOnly Property Map8ViewModel() As Map8ViewModel
          Get
            Return ServiceLocator.Current.GetInstance(Of Map8ViewModel)()
          End Get
        End Property

        Public ReadOnly Property ItemNameDetailViewModel As ImageGallery8DetailViewModel
            Get
                Return ServiceLocator.Current.GetInstance(Of ImageGallery8DetailViewModel)()
            End Get
        End Property

        Public ReadOnly Property ImageGallery8ViewModel() As ImageGallery8ViewModel
          Get
            Return ServiceLocator.Current.GetInstance(Of ImageGallery8ViewModel)()
          End Get
        End Property

        Public ReadOnly Property Grid8ViewModel() As Grid8ViewModel
          Get
            Return ServiceLocator.Current.GetInstance(Of Grid8ViewModel)()
          End Get
        End Property

        Public ReadOnly Property Chart8ViewModel() As Chart8ViewModel
          Get
            Return ServiceLocator.Current.GetInstance(Of Chart8ViewModel)()
          End Get
        End Property

        Public ReadOnly Property Camera8ViewModel() As Camera8ViewModel
          Get
            Return ServiceLocator.Current.GetInstance(Of Camera8ViewModel)()
          End Get
        End Property

        Public ReadOnly Property Blank8ViewModel() As Blank8ViewModel
          Get
            Return ServiceLocator.Current.GetInstance(Of Blank8ViewModel)()
          End Get
        End Property

        Public ReadOnly Property MainViewModel() As MainViewModel
          Get
            Return ServiceLocator.Current.GetInstance(Of MainViewModel)()
          End Get
        End Property
        Public ReadOnly Property PivotViewModel() As PivotViewModel
            Get
                Return ServiceLocator.Current.GetInstance(Of PivotViewModel)()
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
