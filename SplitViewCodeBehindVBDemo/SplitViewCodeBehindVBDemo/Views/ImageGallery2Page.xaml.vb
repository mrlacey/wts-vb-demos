Imports SplitViewCodeBehindVBDemo.Helpers
Imports SplitViewCodeBehindVBDemo.Models
Imports SplitViewCodeBehindVBDemo.Services

Imports Windows.Storage
Imports Windows.UI.Xaml.Media.Animation

Namespace Views
    Public NotInheritable Partial Class ImageGallery2Page
        Inherits Page
        Implements INotifyPropertyChanged
        Public Const ImageGallery2SelectedImageId As String = "ImageGallery2SelectedImageId"
        Public Const ImageGallery2AnimationOpen As String = "ImageGallery2_AnimationOpen"
        Public Const ImageGallery2AnimationClose As String = "ImageGallery2_AnimationClose"

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
            ImagesGridView.PrepareConnectedAnimation(ImageGallery2AnimationOpen, selected, "galleryImage")
            NavigationService.Navigate(Of ImageGallery2DetailPage)(e.ClickedItem)
        End Sub

        Private Async Sub ImagesGridView_Loaded(sender As Object, e As RoutedEventArgs)
            Dim selectedImageId = Await ApplicationData.Current.LocalSettings.ReadAsync(Of String)(ImageGallery2SelectedImageId)
            If Not String.IsNullOrEmpty(selectedImageId) Then
                Dim animation = ConnectedAnimationService.GetForCurrentView().GetAnimation(ImageGallery2AnimationClose)
                If animation IsNot Nothing Then
                    Dim item = ImagesGridView.Items.FirstOrDefault(Function(i) DirectCast(i, SampleImage).ID = selectedImageId)
                    ImagesGridView.ScrollIntoView(item)
                    Await ImagesGridView.TryStartConnectedAnimationAsync(animation, item, "galleryImage")
                End If

                ApplicationData.Current.LocalSettings.SaveString(ImageGallery2SelectedImageId, String.Empty)
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
