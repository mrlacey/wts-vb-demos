Imports GalaSoft.MvvmLight
Imports GalaSoft.MvvmLight.Command

Imports SplitViewMVVMLightVBDemo.Helpers
Imports SplitViewMVVMLightVBDemo.Models
Imports SplitViewMVVMLightVBDemo.Services

Imports Windows.Storage
Imports Windows.UI.Xaml.Media.Animation

Namespace ViewModels
    Public Class ImageGalleryViewModel
        Inherits ViewModelBase

        Public Const ImageGallerySelectedIdKey As String = "ImageGallerySelectedIdKey"
        Public Const ImageGalleryAnimationOpen As String = "ImageGallery_AnimationOpen"
        Public Const ImageGalleryAnimationClose As String = "ImageGallery_AnimationClose"

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
            Dim selectedImageId = Await ApplicationData.Current.LocalSettings.ReadAsync(Of String)(ImageGallerySelectedIdKey)
            If Not String.IsNullOrEmpty(selectedImageId) Then
                Dim animation = ConnectedAnimationService.GetForCurrentView().GetAnimation(ImageGalleryAnimationClose)
                If animation IsNot Nothing Then
                    Dim item = _imagesGridView.Items.FirstOrDefault(Function(i) DirectCast(i, SampleImage).ID = selectedImageId)
                    _imagesGridView.ScrollIntoView(item)
                    Await _imagesGridView.TryStartConnectedAnimationAsync(animation, item, "galleryImage")
                End If

                ApplicationData.Current.LocalSettings.SaveString(ImageGallerySelectedIdKey, String.Empty)
            End If
        End Function

        Public ReadOnly Property NavigationService As NavigationServiceEx
            Get
                Return CommonServiceLocator.ServiceLocator.Current.GetInstance(Of NavigationServiceEx)()
            End Get
        End Property

        Private Sub OnsItemSelected(args As ItemClickEventArgs)
            Dim selected = TryCast(args.ClickedItem, SampleImage)
            _imagesGridView.PrepareConnectedAnimation(ImageGalleryAnimationOpen, selected, "galleryImage")
            NavigationService.Navigate(GetType(ImageGalleryDetailViewModel).FullName, args.ClickedItem)
        End Sub
    End Class
End Namespace
