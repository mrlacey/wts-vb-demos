Imports SplitViewMVVMLightVBDemo.ViewModels

Namespace Views
    Public NotInheritable Partial Class ImageGalleryPage
        Inherits Page

        Private ReadOnly Property ViewModel As ImageGalleryViewModel
            Get
                Return TryCast(DataContext, ImageGalleryViewModel)
            End Get
        End Property

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Async Sub GridView_Loaded(sender As Object, e As RoutedEventArgs)
            Dim gridView = TryCast(sender, GridView)
            Await ViewModel.LoadAnimationAsync(gridView)
        End Sub
    End Class
End Namespace
