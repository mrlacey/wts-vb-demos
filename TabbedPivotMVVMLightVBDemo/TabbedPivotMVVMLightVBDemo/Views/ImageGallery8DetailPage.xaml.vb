Imports TabbedPivotMVVMLightVBDemo.Models
Imports TabbedPivotMVVMLightVBDemo.ViewModels

Namespace Views
    Public NotInheritable Partial Class ImageGallery8DetailPage
        Inherits Page
        Private ReadOnly Property ViewModel() As ImageGallery8DetailViewModel
            Get
                Return TryCast(DataContext, ImageGallery8DetailViewModel)
            End Get
        End Property

        Public Sub New()
            InitializeComponent()
            ViewModel.SetImage(previewImage)
        End Sub

        Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
            MyBase.OnNavigatedTo(e)
            ViewModel.Initialize(TryCast(e.Parameter, SampleImage))
            showFlipView.Begin()
        End Sub

        Protected Overrides Sub OnNavigatingFrom(e As NavigatingCancelEventArgs)
            MyBase.OnNavigatingFrom(e)
            If e.NavigationMode = NavigationMode.Back Then
                previewImage.Visibility = Visibility.Visible
                ViewModel.SetAnimation()
            End If
        End Sub
    End Class
End Namespace
