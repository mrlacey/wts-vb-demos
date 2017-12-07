Imports TabbedPivotMVVMBasicVBDemo.ViewModels

Namespace Views
    Public NotInheritable Partial Class Map3Page
        Inherits Page
            property ViewModel as Map3ViewModel = New Map3ViewModel

        Public Sub New()
            InitializeComponent()
            AddHandler Loaded, AddressOf Map3Page_Loaded
            AddHandler Unloaded, AddressOf Map3Page_Unloaded
        End Sub

        Private Async Sub Map3Page_Loaded(sender As Object, e As RoutedEventArgs)
            Await ViewModel.InitializeAsync(mapControl)
        End Sub

        Private Sub Map3Page_Unloaded(sender As Object, e As RoutedEventArgs)
            ViewModel.Cleanup()
        End Sub
    End Class
End Namespace
