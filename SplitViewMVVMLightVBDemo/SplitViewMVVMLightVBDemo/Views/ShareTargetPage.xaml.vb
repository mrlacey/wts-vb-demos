Imports SplitViewMVVMLightVBDemo.ViewModels

Imports Windows.ApplicationModel.DataTransfer.ShareTarget

Namespace Views
    ' TODO WTS: Remove this example page when/if it's not needed.
    ' This page is an example of how to handle data that is shared with your app.
    ' You can either change this page to meet your needs, or use another and delete this page.
    Public NotInheritable Partial Class ShareTargetPage
        Inherits Page

        Private ReadOnly Property ViewModel As ShareTargetViewModel
            Get
                Return TryCast(DataContext, ShareTargetViewModel)
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
