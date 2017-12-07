Imports BlankMVVMBasicVBDemo.ViewModels

Namespace Views
    Public NotInheritable Partial Class MasterDetail6Page
        Inherits Page
            property ViewModel as MasterDetail6ViewModel = New MasterDetail6ViewModel
        Public Sub New()
            InitializeComponent()
            AddHandler Loaded, AddressOf MasterDetail6Page_Loaded
        End Sub

        Private Async Sub MasterDetail6Page_Loaded(sender As Object, e As RoutedEventArgs)
            Await ViewModel.LoadDataAsync(MasterDetailsViewControl.ViewState)
        End Sub
    End Class
End Namespace
