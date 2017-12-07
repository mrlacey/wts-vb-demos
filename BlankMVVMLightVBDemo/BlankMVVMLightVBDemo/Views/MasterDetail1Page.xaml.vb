Imports BlankMVVMLightVBDemo.ViewModels

Namespace Views
    Public NotInheritable Partial Class MasterDetail1Page
        Inherits Page
        Private ReadOnly Property ViewModel() As MasterDetail1ViewModel
          Get
            Return TryCast(DataContext, MasterDetail1ViewModel)
          End Get
        End Property

        Public Sub New()
            InitializeComponent()
            AddHandler Loaded, AddressOf MasterDetail1Page_Loaded
        End Sub

        Private Async Sub MasterDetail1Page_Loaded(sender As Object, e As RoutedEventArgs)
            Await ViewModel.LoadDataAsync(MasterDetailsViewControl.ViewState)
        End Sub
    End Class
End Namespace
