Imports TabbedPivotMVVMBasicVBDemo.Helpers
Imports TabbedPivotMVVMBasicVBDemo.Models
Imports TabbedPivotMVVMBasicVBDemo.Services
Imports TabbedPivotMVVMBasicVBDemo.Views

Imports Windows.Storage
Imports Windows.UI.Xaml.Media.Animation

Namespace ViewModels
    Public Class ImageGallery3ViewModel
        Inherits Observable

        Public Const ImageGallery3SelectedImageId As String = "ImageGallery3SelectedImageId"
        Public Const ImageGallery3AnimationOpen As String = "ImageGallery3_AnimationOpen"
        Public Const ImageGallery3AnimationClose As String = "ImageGallery3_AnimationClose"

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
            Dim selectedImageId = Await ApplicationData.Current.LocalSettings.ReadAsync(Of String)(ImageGallery3SelectedImageId)
            If Not String.IsNullOrEmpty(selectedImageId) Then
                Dim animation = ConnectedAnimationService.GetForCurrentView().GetAnimation(ImageGallery3AnimationClose)
                If animation IsNot Nothing Then
                    Dim item = _imagesGridView.Items.FirstOrDefault(Function(i) DirectCast(i, SampleImage).ID = selectedImageId)
                    _imagesGridView.ScrollIntoView(item)
                    Await _imagesGridView.TryStartConnectedAnimationAsync(animation, item, "galleryImage")
                End If

                ApplicationData.Current.LocalSettings.SaveString(ImageGallery3SelectedImageId, String.Empty)
            End If
        End Function

        Private Sub OnsItemSelected(args As ItemClickEventArgs)
            Dim selected = TryCast(args.ClickedItem, SampleImage)
            _imagesGridView.PrepareConnectedAnimation(ImageGallery3AnimationOpen, selected, "galleryImage")
            NavigationService.Navigate(Of ImageGallery3DetailPage)(args.ClickedItem)
        End Sub
    End Class
End Namespace
