Imports BlankMVVMLightVBDemo.ViewModels

Namespace Views
    Public NotInheritable Partial Class ImageGallery1Page
        Inherits Page
        Private ReadOnly Property ViewModel() As ImageGallery1ViewModel
          Get
            Return TryCast(DataContext, ImageGallery1ViewModel)
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
