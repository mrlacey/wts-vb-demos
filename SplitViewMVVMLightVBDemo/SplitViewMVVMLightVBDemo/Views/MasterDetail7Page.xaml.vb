Imports SplitViewMVVMLightVBDemo.ViewModels

Namespace Views
    Public NotInheritable Partial Class MasterDetail7Page
        Inherits Page
        Private ReadOnly Property ViewModel() As MasterDetail7ViewModel
          Get
            Return TryCast(DataContext, MasterDetail7ViewModel)
          End Get
        End Property

        Public Sub New()
            InitializeComponent()
            AddHandler Loaded, AddressOf MasterDetail7Page_Loaded
        End Sub

        Private Async Sub MasterDetail7Page_Loaded(sender As Object, e As RoutedEventArgs)
            Await ViewModel.LoadDataAsync(MasterDetailsViewControl.ViewState)
        End Sub
    End Class
End Namespace
