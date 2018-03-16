Imports BlankMVVMBasicVBDemo.ViewModels

Namespace Views
    Public NotInheritable Partial Class MapPage
        Inherits Page

        property ViewModel as MapViewModel = New MapViewModel

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
