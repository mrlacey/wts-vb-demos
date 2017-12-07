Imports GalaSoft.MvvmLight
Imports GalaSoft.MvvmLight.Command

Imports TabbedPivotMVVMLightVBDemo.Helpers
Imports TabbedPivotMVVMLightVBDemo.Models
Imports TabbedPivotMVVMLightVBDemo.Services

Imports Windows.Storage
Imports Windows.UI.Xaml.Media.Animation

Namespace ViewModels
    Public Class ImageGallery8ViewModel
        Inherits ViewModelBase

        Public Const ImageGallery8SelectedImageId As String = "ImageGallery8SelectedImageId"
        Public Const ImageGallery8AnimationOpen As String = "ImageGallery8_AnimationOpen"
        Public Const ImageGallery8AnimationClose As String = "ImageGallery8_AnimationClose"

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
            Dim selectedImageId = Await ApplicationData.Current.LocalSettings.ReadAsync(Of String)(ImageGallery8SelectedImageId)
            If Not String.IsNullOrEmpty(selectedImageId) Then
                Dim animation = ConnectedAnimationService.GetForCurrentView().GetAnimation(ImageGallery8AnimationClose)
                If animation IsNot Nothing Then
                    Dim item = _imagesGridView.Items.FirstOrDefault(Function(i) DirectCast(i, SampleImage).ID = selectedImageId)
                    _imagesGridView.ScrollIntoView(item)
                    Await _imagesGridView.TryStartConnectedAnimationAsync(animation, item, "galleryImage")
                End If

                ApplicationData.Current.LocalSettings.SaveString(ImageGallery8SelectedImageId, String.Empty)
            End If
        End Function

        Public ReadOnly Property NavigationService() As NavigationServiceEx
            Get
                Return Microsoft.Practices.ServiceLocation.ServiceLocator.Current.GetInstance(Of NavigationServiceEx)()
            End Get
        End Property

        Private Sub OnsItemSelected(args As ItemClickEventArgs)
            Dim selected = TryCast(args.ClickedItem, SampleImage)
            _imagesGridView.PrepareConnectedAnimation(ImageGallery8AnimationOpen, selected, "galleryImage")
            NavigationService.Navigate(GetType(ImageGallery8DetailViewModel).FullName, args.ClickedItem)
        End Sub
    End Class
End Namespace
