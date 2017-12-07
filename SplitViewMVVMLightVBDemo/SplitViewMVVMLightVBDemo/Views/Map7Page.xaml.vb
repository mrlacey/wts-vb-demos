Imports SplitViewMVVMLightVBDemo.ViewModels

Namespace Views
    Public NotInheritable Partial Class Map7Page
        Inherits Page
        Private ReadOnly Property ViewModel() As Map7ViewModel
          Get
            Return TryCast(DataContext, Map7ViewModel)
          End Get
        End Property


        Public Sub New()
            InitializeComponent()
        End Sub

        Protected Overrides Async Sub OnNavigatedTo(e As NavigationEventArgs)
            Await ViewModel.InitializeAsync(mapControl)
        End Sub

        Protected Overrides Sub OnNavigatedFrom(e As NavigationEventArgs)
            ViewModel.Cleanup()
        End Sub
    End Class
End Namespace
