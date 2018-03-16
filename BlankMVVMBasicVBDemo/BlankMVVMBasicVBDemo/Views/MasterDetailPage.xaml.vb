Imports BlankMVVMBasicVBDemo.ViewModels

Namespace Views
    Public NotInheritable Partial Class MasterDetailPage
        Inherits Page

        property ViewModel as MasterDetailViewModel = New MasterDetailViewModel

        Public Sub New()
            InitializeComponent()
            AddHandler Loaded, AddressOf MasterDetailPage_Loaded
        End Sub

        Private Async Sub MasterDetailPage_Loaded(sender As Object, e As RoutedEventArgs)
            Await ViewModel.LoadDataAsync(MasterDetailsViewControl.ViewState)
        End Sub
    End Class
End Namespace
