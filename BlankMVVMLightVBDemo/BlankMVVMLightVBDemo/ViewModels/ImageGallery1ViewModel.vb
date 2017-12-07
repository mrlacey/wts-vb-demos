Imports BlankMVVMLightVBDemo.Helpers
Imports BlankMVVMLightVBDemo.Models
Imports BlankMVVMLightVBDemo.Services

Imports GalaSoft.MvvmLight
Imports GalaSoft.MvvmLight.Command

Imports Windows.Storage
Imports Windows.UI.Xaml.Media.Animation

Namespace ViewModels
    Public Class ImageGallery1ViewModel
        Inherits ViewModelBase

        Public Const ImageGallery1SelectedImageId As String = "ImageGallery1SelectedImageId"
        Public Const ImageGallery1AnimationOpen As String = "ImageGallery1_AnimationOpen"
        Public Const ImageGallery1AnimationClose As String = "ImageGallery1_AnimationClose"

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
            Dim selectedImageId = Await ApplicationData.Current.LocalSettings.ReadAsync(Of String)(ImageGallery1SelectedImageId)
            If Not String.IsNullOrEmpty(selectedImageId) Then
                Dim animation = ConnectedAnimationService.GetForCurrentView().GetAnimation(ImageGallery1AnimationClose)
                If animation IsNot Nothing Then
                    Dim item = _imagesGridView.Items.FirstOrDefault(Function(i) DirectCast(i, SampleImage).ID = selectedImageId)
                    _imagesGridView.ScrollIntoView(item)
                    Await _imagesGridView.TryStartConnectedAnimationAsync(animation, item, "galleryImage")
                End If

                ApplicationData.Current.LocalSettings.SaveString(ImageGallery1SelectedImageId, String.Empty)
            End If
        End Function

        Public ReadOnly Property NavigationService() As NavigationServiceEx
            Get
                Return Microsoft.Practices.ServiceLocation.ServiceLocator.Current.GetInstance(Of NavigationServiceEx)()
            End Get
        End Property

        Private Sub OnsItemSelected(args As ItemClickEventArgs)
            Dim selected = TryCast(args.ClickedItem, SampleImage)
            _imagesGridView.PrepareConnectedAnimation(ImageGallery1AnimationOpen, selected, "galleryImage")
            NavigationService.Navigate(GetType(ImageGallery1DetailViewModel).FullName, args.ClickedItem)
        End Sub
    End Class
End Namespace
