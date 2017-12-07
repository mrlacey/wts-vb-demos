Imports TabbedPivotMVVMLightVBDemo.ViewModels

Namespace Views
    Public NotInheritable Partial Class Settings8Page
        Inherits Page
        Private ReadOnly Property ViewModel() As Settings8ViewModel
          Get
            Return TryCast(DataContext, Settings8ViewModel)
          End Get
        End Property

        ' TODO WTS: Change the URL for your privacy policy in the Resource File, currently set to https://YourPrivacyUrlGoesHere
        Public Sub New()
            InitializeComponent()
            ViewModel.Initialize()
        End Sub
    End Class
End Namespace
