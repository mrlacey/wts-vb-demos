﻿Imports TabbedPivotMVVMLightVBDemo.ViewModels

Imports Windows.ApplicationModel.DataTransfer.ShareTarget

Namespace Views
    ' TODO WTS: This page exists purely as an example of how to launch a specific page
    ' in response to a protocol launch and pass it a value. It is expected that you will
    ' delete this page once you have changed the handling of a protocol launch to meet your
    ' needs and redirected to another of your pages.
    Public NotInheritable Partial Class ShareTarget8Page
        Inherits Page

        Private ReadOnly Property ViewModel As ShareTarget8ViewModel
            Get
                Return TryCast(DataContext, ShareTarget8ViewModel)
            End Get
        End Property

        Public Sub New()
            InitializeComponent()
        End Sub

        Protected Overrides Async Sub OnNavigatedTo(e As NavigationEventArgs)
            MyBase.OnNavigatedTo(e)
            Await ViewModel.LoadAsync(TryCast(e.Parameter, ShareOperation))
        End Sub
    End Class
End Namespace
