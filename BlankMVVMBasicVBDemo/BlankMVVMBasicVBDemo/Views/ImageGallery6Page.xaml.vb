Imports BlankMVVMBasicVBDemo.ViewModels

Namespace Views
    Public NotInheritable Partial Class ImageGallery6Page
        Inherits Page
            property ViewModel as ImageGallery6ViewModel = New ImageGallery6ViewModel

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Async Sub GridView_Loaded(sender As Object, e As RoutedEventArgs)
            Dim gridView = TryCast(sender, GridView)
            Await ViewModel.LoadAnimationAsync(gridView)
        End Sub
    End Class
End Namespace
