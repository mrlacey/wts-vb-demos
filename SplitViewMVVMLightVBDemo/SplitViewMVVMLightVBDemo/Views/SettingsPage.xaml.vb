﻿Imports SplitViewMVVMLightVBDemo.ViewModels

Namespace Views
    ' TODO WTS: Change the URL for your privacy policy in the Resource File, currently set to https://YourPrivacyUrlGoesHere
    Public NotInheritable Partial Class SettingsPage
        Inherits Page

        Private ReadOnly Property ViewModel As SettingsViewModel
            Get
                Return TryCast(DataContext, SettingsViewModel)
            End Get
        End Property

        Public Sub New()
            InitializeComponent()
        End Sub

        Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
            ViewModel.Initialize()
        End Sub
    End Class
End Namespace
