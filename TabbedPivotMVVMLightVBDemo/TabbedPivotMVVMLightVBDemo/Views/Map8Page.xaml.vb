Imports TabbedPivotMVVMLightVBDemo.ViewModels

Namespace Views
    Public NotInheritable Partial Class Map8Page
        Inherits Page
        Private ReadOnly Property ViewModel() As Map8ViewModel
          Get
            Return TryCast(DataContext, Map8ViewModel)
          End Get
        End Property


        Public Sub New()
            InitializeComponent()
            AddHandler Loaded, AddressOf Map8Page_Loaded
            AddHandler Unloaded, AddressOf Map8Page_Unloaded
        End Sub

        Private Async Sub Map8Page_Loaded(sender As Object, e As RoutedEventArgs)
            Await ViewModel.InitializeAsync(mapControl)
        End Sub

        Private Sub Map8Page_Unloaded(sender As Object, e As RoutedEventArgs)
            ViewModel.Cleanup()
        End Sub
    End Class
End Namespace
