﻿Imports SplitViewCodeBehindVBDemo.Helpers
Imports SplitViewCodeBehindVBDemo.Services

Imports Windows.Devices.Geolocation
Imports Windows.Foundation
Imports Windows.Storage.Streams
Imports Windows.UI.Xaml.Controls.Maps

Namespace Views
    Public NotInheritable Partial Class Map2Page
        Inherits Page
        Implements INotifyPropertyChanged
        ' TODO WTS: Set your preferred default zoom level
        Private Const DefaultZoomLevel As Double = 17

        Private ReadOnly locationService As LocationService

        ' TODO WTS: Set your preferred default location if a geolock can't be found.
        Private ReadOnly defaultPosition As New BasicGeoposition() With {
            .Latitude = 47.609425,
            .Longitude = -122.3417
        }

        Private _zoomLevel As Double

        Public Property ZoomLevel As Double
            Get
                Return _zoomLevel
            End Get
            Set
                [Set](_zoomLevel, value)
            End Set
        End Property

        Private _center As Geopoint

        Public Property Center As Geopoint
            Get
                Return _center
            End Get
            Set
                [Set](_center, value)
            End Set
        End Property

        Public Sub New()
            locationService = New LocationService()
            Center = New Geopoint(defaultPosition)
            ZoomLevel = DefaultZoomLevel
            InitializeComponent()
        End Sub

        Protected Overrides Async Sub OnNavigatedTo(e As NavigationEventArgs)
            Await InitializeAsync()
        End Sub

        Protected Overrides Sub OnNavigatedFrom(e As NavigationEventArgs)
            Cleanup()
        End Sub

        Public Async Function InitializeAsync() As Task
            If locationService IsNot Nothing Then
                AddHandler locationService.PositionChanged, AddressOf LocationService_PositionChanged

                Dim initializationSuccessful = Await locationService.InitializeAsync()

                If initializationSuccessful Then
                    Await locationService.StartListeningAsync()
                End If

                If initializationSuccessful AndAlso locationService.CurrentPosition IsNot Nothing Then
                    Center = locationService.CurrentPosition.Coordinate.Point
                Else
                    Center = New Geopoint(defaultPosition)
                End If
            End If

            If mapControl IsNot Nothing Then
                ' TODO WTS: Set your map service token. If you don't have one, request at https://www.bingmapsportal.com/
                mapControl.MapServiceToken = String.Empty

                AddMapIcon(Center, "Map_YourLocation".GetLocalized())
            End If
        End Function

        Public Sub Cleanup()
            If locationService IsNot Nothing Then
                RemoveHandler locationService.PositionChanged, AddressOf LocationService_PositionChanged
                locationService.StopListening()
            End If
        End Sub

        Private Sub LocationService_PositionChanged(sender As Object, geoposition As Geoposition)
            If geoposition IsNot Nothing Then
                Center = geoposition.Coordinate.Point
            End If
        End Sub

        Private Sub AddMapIcon(position As Geopoint, title As String)
            Dim mapIcon As New MapIcon() With {
                .Location = position,
                .NormalizedAnchorPoint = New Point(0.5, 1.0),
                .Title = title,
                .Image = RandomAccessStreamReference.CreateFromUri(New Uri("ms-appx:///Assets/map.png")),
                .ZIndex = 0
            }
            mapControl.MapElements.Add(mapIcon)
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
