Imports BlankMVVMBasicVBDemo.Helpers
Imports BlankMVVMBasicVBDemo.Models
Imports BlankMVVMBasicVBDemo.Services
Imports BlankMVVMBasicVBDemo.Views

Imports Windows.Storage
Imports Windows.UI.Xaml.Media.Animation

Namespace ViewModels
    Public Class ImageGallery6ViewModel
        Inherits Observable

        Public Const ImageGallery6SelectedImageId As String = "ImageGallery6SelectedImageId"
        Public Const ImageGallery6AnimationOpen As String = "ImageGallery6_AnimationOpen"
        Public Const ImageGallery6AnimationClose As String = "ImageGallery6_AnimationClose"

        Private _source As ObservableCollection(Of SampleImage)
        Private _imagesGridView As GridView

        Public Property Source As ObservableCollection(Of SampleImage)
            Get
                Return _source
            End Get
            Set
                [Set](_source, value)
            End Set
        End Property

        Public ReadOnly Property ItemSelectedCommand As ICommand = new RelayCommand(Of ItemClickEventArgs)(Sub(args) OnsItemSelected(args))

        Public Sub New()
            ' TODO WTS: Replace this with your actual data
            Source = SampleDataService.GetGallerySampleData()
        End Sub

        Public Async Function LoadAnimationAsync(imagesGridView As GridView) As Task
            _imagesGridView = imagesGridView
            Dim selectedImageId = Await ApplicationData.Current.LocalSettings.ReadAsync(Of String)(ImageGallery6SelectedImageId)
            If Not String.IsNullOrEmpty(selectedImageId) Then
                Dim animation = ConnectedAnimationService.GetForCurrentView().GetAnimation(ImageGallery6AnimationClose)
                If animation IsNot Nothing Then
                    Dim item = _imagesGridView.Items.FirstOrDefault(Function(i) DirectCast(i, SampleImage).ID = selectedImageId)
                    _imagesGridView.ScrollIntoView(item)
                    Await _imagesGridView.TryStartConnectedAnimationAsync(animation, item, "galleryImage")
                End If

                ApplicationData.Current.LocalSettings.SaveString(ImageGallery6SelectedImageId, String.Empty)
            End If
        End Function

        Private Sub OnsItemSelected(args As ItemClickEventArgs)
            Dim selected = TryCast(args.ClickedItem, SampleImage)
            _imagesGridView.PrepareConnectedAnimation(ImageGallery6AnimationOpen, selected, "galleryImage")
            NavigationService.Navigate(Of ImageGallery6DetailPage)(args.ClickedItem)
        End Sub
    End Class
End Namespace
