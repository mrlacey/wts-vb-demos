Imports BlankMVVMBasicVBDemo.Models
Imports BlankMVVMBasicVBDemo.ViewModels

Namespace Views
    Public NotInheritable Partial Class ImageGallery6DetailPage
        Inherits Page
        Public ReadOnly Property ViewModel As ImageGallery6DetailViewModel = New ImageGallery6DetailViewModel()
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
