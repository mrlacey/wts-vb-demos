Imports TabbedPivotMVVMBasicVBDemo.ViewModels

Namespace Views
    ' TODO WTS: Change the URL for your privacy policy in the Resource File, currently set to https://YourPrivacyUrlGoesHere
    Public NotInheritable Partial Class SettingsPage
        Inherits Page

        property ViewModel as SettingsViewModel = New SettingsViewModel

        Public Sub New()
            InitializeComponent()
            ViewModel.Initialize()
        End Sub
    End Class
End Namespace
