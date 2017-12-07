Imports TabbedPivotMVVMLightVBDemo.ViewModels

Namespace Views
    Public NotInheritable Partial Class MasterDetail8Page
        Inherits Page
        Private ReadOnly Property ViewModel() As MasterDetail8ViewModel
          Get
            Return TryCast(DataContext, MasterDetail8ViewModel)
          End Get
        End Property

        Public Sub New()
            InitializeComponent()
            AddHandler Loaded, AddressOf MasterDetail8Page_Loaded
        End Sub

        Private Async Sub MasterDetail8Page_Loaded(sender As Object, e As RoutedEventArgs)
            Await ViewModel.LoadDataAsync(MasterDetailsViewControl.ViewState)
        End Sub
    End Class
End Namespace
