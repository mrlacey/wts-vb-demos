Imports TabbedPivotMVVMBasicVBDemo.ViewModels

Namespace Views
    Public NotInheritable Partial Class Settings3Page
        Inherits Page
            property ViewModel as Settings3ViewModel = New Settings3ViewModel

        ' TODO WTS: Change the URL for your privacy policy in the Resource File, currently set to https://YourPrivacyUrlGoesHere
        Public Sub New()
            InitializeComponent()
            ViewModel.Initialize()
        End Sub
    End Class
End Namespace
