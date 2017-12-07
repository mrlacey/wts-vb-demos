Imports SplitViewMVVMLightVBDemo.ViewModels

Namespace Views
    Public NotInheritable Partial Class Settings7Page
        Inherits Page
        Private ReadOnly Property ViewModel() As Settings7ViewModel
          Get
            Return TryCast(DataContext, Settings7ViewModel)
          End Get
        End Property

        ' TODO WTS: Change the URL for your privacy policy in the Resource File, currently set to https://YourPrivacyUrlGoesHere
        Public Sub New()
            InitializeComponent()
        End Sub

        Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
            ViewModel.Initialize()
        End Sub
    End Class
End Namespace
