Imports Microsoft.Toolkit.Uwp.UI.Extensions

Imports TabbedPivotMVVMBasicVBDemo.ViewModels

Imports Windows.Media.Playback
Imports Windows.System.Display
Imports Windows.UI.Core

Namespace Views
    Public NotInheritable Partial Class MediaPlayerPage
        Inherits Page

        property ViewModel as MediaPlayerViewModel = New MediaPlayerViewModel

        ' For more on the MediaPlayer and adjusting controls and behavior see https://docs.microsoft.com/en-us/windows/uwp/controls-and-patterns/media-playback
        ' The DisplayRequest is used to stop the screen dimming while watching for extended periods
        Private _displayRequest As New DisplayRequest()

        Private _isRequestActive As Boolean = False

        Public Sub New()
            AddHandler Loaded, AddressOf MediaPlayerPage_Loaded
            InitializeComponent()
        End Sub


        Private Sub MediaPlayerPage_Loaded(sender As Object, e As RoutedEventArgs)
            Dim element = TryCast(Me, FrameworkElement)
            Dim pivotPage = element.FindAscendant(Of Pivot)()
            If pivotPage IsNot Nothing Then
                AddHandler pivotPage.SelectionChanged, AddressOf PivotPage_SelectionChanged
            End If

            AddHandler mpe.MediaPlayer.PlaybackSession.PlaybackStateChanged, AddressOf PlaybackSession_PlaybackStateChanged
            mpe.MediaPlayer.Play()
        End Sub

        Private Sub PivotPage_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
            Dim navigatedTo As Boolean = e.AddedItems.Cast(Of PivotItem)().Any(Function(p) p.FindDescendant(Of MediaPlayerPage)() IsNot Nothing)
            Dim navigatedFrom As Boolean = e.RemovedItems.Cast(Of PivotItem)().Any(Function(p) p.FindDescendant(Of MediaPlayerPage)() IsNot Nothing)
            If navigatedTo Then
                AddHandler mpe.MediaPlayer.PlaybackSession.PlaybackStateChanged, AddressOf PlaybackSession_PlaybackStateChanged
            End If

            If navigatedFrom Then
                mpe.MediaPlayer.Pause()
                RemoveHandler mpe.MediaPlayer.PlaybackSession.PlaybackStateChanged, AddressOf PlaybackSession_PlaybackStateChanged
            End If
        End Sub

        Private Async Sub PlaybackSession_PlaybackStateChanged(sender As MediaPlaybackSession, args As Object)
            Dim playbackSession = TryCast(sender, MediaPlaybackSession)

            If playbackSession IsNot Nothing AndAlso playbackSession.NaturalVideoHeight <> 0 Then
                If playbackSession.PlaybackState = MediaPlaybackState.Playing Then
                    If Not _isRequestActive Then
                        Await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, Sub() 
                            _displayRequest.RequestActive()
                            _isRequestActive = True
                        End Sub)
                    End If
                Else
                    If _isRequestActive Then
                        Await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, Sub() 
                            _displayRequest.RequestRelease()
                            _isRequestActive = False
                        End Sub)
                    End If
                End If
            End If
        End Sub
    End Class
End Namespace
