Imports BlankCodeBehindVBDemo.Helpers
Imports BlankCodeBehindVBDemo.Models
Imports BlankCodeBehindVBDemo.Services

Imports Windows.Storage
Imports Windows.UI.Xaml.Media.Animation

Namespace Views
    Public NotInheritable Partial Class ImageGallery4Page
        Inherits Page
        Implements INotifyPropertyChanged
        Public Const ImageGallery4SelectedImageId As String = "ImageGallery4SelectedImageId"
        Public Const ImageGallery4AnimationOpen As String = "ImageGallery4_AnimationOpen"
        Public Const ImageGallery4AnimationClose As String = "ImageGallery4_AnimationClose"

        Private _source As ObservableCollection(Of SampleImage)

        Public Property Source As ObservableCollection(Of SampleImage)
            Get
                Return _source
            End Get
            Set
                [Set](_source, value)
            End Set
        End Property

        Public Sub New()
            ' TODO WTS: Replace this with your actual data
            Source = SampleDataService.GetGallerySampleData()
            InitializeComponent()
        End Sub

        Private Sub ImagesGridView_ItemClick(sender As Object, e As ItemClickEventArgs)
            Dim selected = TryCast(e.ClickedItem, SampleImage)
            ImagesGridView.PrepareConnectedAnimation(ImageGallery4AnimationOpen, selected, "galleryImage")
            NavigationService.Navigate(Of ImageGallery4DetailPage)(e.ClickedItem)
        End Sub

        Private Async Sub ImagesGridView_Loaded(sender As Object, e As RoutedEventArgs)
            Dim selectedImageId = Await ApplicationData.Current.LocalSettings.ReadAsync(Of String)(ImageGallery4SelectedImageId)
            If Not String.IsNullOrEmpty(selectedImageId) Then
                Dim animation = ConnectedAnimationService.GetForCurrentView().GetAnimation(ImageGallery4AnimationClose)
                If animation IsNot Nothing Then
                    Dim item = ImagesGridView.Items.FirstOrDefault(Function(i) DirectCast(i, SampleImage).ID = selectedImageId)
                    ImagesGridView.ScrollIntoView(item)
                    Await ImagesGridView.TryStartConnectedAnimationAsync(animation, item, "galleryImage")
                End If

                ApplicationData.Current.LocalSettings.SaveString(ImageGallery4SelectedImageId, String.Empty)
            End If
        End Sub
        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

        Private Sub [Set](Of T)(ByRef storage As T, value As T, <CallerMemberName> Optional propertyName As String = Nothing)
            If Equals(storage, value) Then
                Return
            End If

            storage = value
            OnPropertyChanged(propertyName)
        End Sub

        Private Sub OnPropertyChanged(propertyName As String)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
        End Sub
    End Class
End Namespace
