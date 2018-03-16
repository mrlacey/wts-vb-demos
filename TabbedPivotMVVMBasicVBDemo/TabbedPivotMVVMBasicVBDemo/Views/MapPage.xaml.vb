Imports TabbedPivotMVVMBasicVBDemo.ViewModels

Namespace Views
    Public NotInheritable Partial Class MapPage
        Inherits Page

        property ViewModel as MapViewModel = New MapViewModel

        Public Sub New()
            InitializeComponent()
            AddHandler Loaded, AddressOf MapPage_Loaded
            AddHandler Unloaded, AddressOf MapPage_Unloaded
        End Sub

        Private Async Sub MapPage_Loaded(sender As Object, e As RoutedEventArgs)
            Await ViewModel.InitializeAsync(mapControl)
        End Sub

        Private Sub MapPage_Unloaded(sender As Object, e As RoutedEventArgs)
            ViewModel.Cleanup()
        End Sub
    End Class
End Namespace
