﻿Imports GalaSoft.MvvmLight

Imports SplitViewMVVMLightVBDemo.Helpers
Imports SplitViewMVVMLightVBDemo.Models
Imports SplitViewMVVMLightVBDemo.Services

Imports Windows.Storage
Imports Windows.UI.Xaml.Media.Animation

Namespace ViewModels
    Public Class ImageGallery7DetailViewModel
        Inherits ViewModelBase
        Private Shared _image As UIElement
        Private _selectedImage As Object
        Private _source As ObservableCollection(Of SampleImage)

        Public Property SelectedImage As Object
            Get
                Return _selectedImage
            End Get
            Set
                [Set](_selectedImage, value)
                ApplicationData.Current.LocalSettings.SaveString(ImageGallery7ViewModel.ImageGallery7SelectedImageId, DirectCast(SelectedImage, SampleImage).ID)
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
        End Sub

        Public Sub SetImage(image As UIElement)
            _image = image
        End Sub

        Public Sub Initialize(sampleImage As SampleImage)
            SelectedImage = Source.FirstOrDefault(Function(i) i.ID = sampleImage.ID)
            Dim animation = ConnectedAnimationService.GetForCurrentView().GetAnimation(ImageGallery7ViewModel.ImageGallery7AnimationOpen)
            animation?.TryStart(_image)
        End Sub

        Public Sub SetAnimation()
            ConnectedAnimationService.GetForCurrentView()?.PrepareToAnimate(ImageGallery7ViewModel.ImageGallery7AnimationClose, _image)
        End Sub
    End Class
End Namespace
