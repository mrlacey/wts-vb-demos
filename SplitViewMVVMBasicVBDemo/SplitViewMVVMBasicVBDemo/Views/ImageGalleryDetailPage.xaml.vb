﻿Imports SplitViewMVVMBasicVBDemo.Models
Imports SplitViewMVVMBasicVBDemo.ViewModels

Namespace Views
    Public NotInheritable Partial Class ImageGalleryDetailPage
        Inherits Page
        Public ReadOnly Property ViewModel As ImageGalleryDetailViewModel = New ImageGalleryDetailViewModel()
        Public Sub New()
            InitializeComponent()
            ViewModel.SetImage(previewImage)
        End Sub

        Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
            MyBase.OnNavigatedTo(e)
            ViewModel.Initialize(TryCast(e.Parameter, SampleImage))
            showFlipView.Begin()
        End Sub

        Protected Overrides Sub OnNavigatingFrom(e As NavigatingCancelEventArgs)
            MyBase.OnNavigatingFrom(e)
            If e.NavigationMode = NavigationMode.Back Then
                previewImage.Visibility = Visibility.Visible
                ViewModel.SetAnimation()
            End If
        End Sub
    End Class
End Namespace
