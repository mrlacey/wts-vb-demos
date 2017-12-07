Imports TabbedPivotMVVMBasicVBDemo.ViewModels

Namespace Views
    Public NotInheritable Partial Class MasterDetail3Page
        Inherits Page
            property ViewModel as MasterDetail3ViewModel = New MasterDetail3ViewModel
        Public Sub New()
            InitializeComponent()
            AddHandler Loaded, AddressOf MasterDetail3Page_Loaded
        End Sub

        Private Async Sub MasterDetail3Page_Loaded(sender As Object, e As RoutedEventArgs)
            Await ViewModel.LoadDataAsync(MasterDetailsViewControl.ViewState)
        End Sub
    End Class
End Namespace
