Imports BlankMVVMLightVBDemo.ViewModels

Namespace Views
    Public NotInheritable Partial Class MasterDetailPage
        Inherits Page

        Private ReadOnly Property ViewModel As MasterDetailViewModel
            Get
                Return TryCast(DataContext, MasterDetailViewModel)
            End Get
        End Property

        Public Sub New()
            InitializeComponent()
            AddHandler Loaded, AddressOf MasterDetailPage_Loaded
        End Sub

        Private Async Sub MasterDetailPage_Loaded(sender As Object, e As RoutedEventArgs)
            Await ViewModel.LoadDataAsync(MasterDetailsViewControl.ViewState)
        End Sub
    End Class
End Namespace
