Imports TabbedPivotMVVMBasicVBDemo.ViewModels

Namespace Views
    Public NotInheritable Partial Class ImageGalleryPage
        Inherits Page

        property ViewModel as ImageGalleryViewModel = New ImageGalleryViewModel

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Async Sub GridView_Loaded(sender As Object, e As RoutedEventArgs)
            Dim gridView = TryCast(sender, GridView)
            Await ViewModel.LoadAnimationAsync(gridView)
        End Sub
    End Class
End Namespace
