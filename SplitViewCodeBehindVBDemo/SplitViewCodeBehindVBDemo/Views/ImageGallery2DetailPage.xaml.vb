Imports SplitViewCodeBehindVBDemo.Helpers
Imports SplitViewCodeBehindVBDemo.Models
Imports SplitViewCodeBehindVBDemo.Services

Imports Windows.Storage
Imports Windows.UI.Xaml.Media.Animation

Namespace Views
    Public NotInheritable Partial Class ImageGallery2DetailPage
        Inherits Page
        Implements INotifyPropertyChanged
        Private _timer As New DispatcherTimer() With {
             .Interval = TimeSpan.FromMilliseconds(500)
        }
        Private _selectedImage As Object
        Private _source As ObservableCollection(Of SampleImage)

        Public Property SelectedImage As Object
            Get
                Return _selectedImage
            End Get
            Set
                [Set](_selectedImage, value)
                ApplicationData.Current.LocalSettings.SaveString(ImageGallery2Page.ImageGallery2SelectedImageId, DirectCast(SelectedImage, SampleImage).ID)
            End Set
        End Property

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

        Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
            MyBase.OnNavigatedTo(e)
            Dim sampleImage = TryCast(e.Parameter, SampleImage)
            SelectedImage = Source.FirstOrDefault(Function(i) i.ID = sampleImage.ID)
            Dim animation = ConnectedAnimationService.GetForCurrentView().GetAnimation(ImageGallery2Page.ImageGallery2AnimationOpen)
            animation?.TryStart(previewImage)
            showFlipView.Begin()
        End Sub

        Protected Overrides Sub OnNavigatingFrom(e As NavigatingCancelEventArgs)
            MyBase.OnNavigatingFrom(e)
            If e.NavigationMode = NavigationMode.Back Then
                previewImage.Visibility = Visibility.Visible
                ConnectedAnimationService.GetForCurrentView()?.PrepareToAnimate(ImageGallery2Page.ImageGallery2AnimationClose, previewImage)
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
