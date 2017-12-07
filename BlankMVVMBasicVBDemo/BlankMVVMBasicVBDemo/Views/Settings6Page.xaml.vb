Imports BlankMVVMBasicVBDemo.ViewModels

Namespace Views
    Public NotInheritable Partial Class Settings6Page
        Inherits Page
            property ViewModel as Settings6ViewModel = New Settings6ViewModel

        ' TODO WTS: Change the URL for your privacy policy in the Resource File, currently set to https://YourPrivacyUrlGoesHere
        Public Sub New()
            InitializeComponent()
        End Sub

        Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
            ViewModel.Initialize()
        End Sub
    End Class
End Namespace
