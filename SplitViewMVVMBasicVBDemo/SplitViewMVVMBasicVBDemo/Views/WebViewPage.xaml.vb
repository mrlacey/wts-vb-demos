Imports SplitViewMVVMBasicVBDemo.ViewModels

Namespace Views
    Public NotInheritable Partial Class WebViewPage
        Inherits Page
            property ViewModel as WebViewViewModel = New WebViewViewModel

        Public Sub New()
            InitializeComponent()
            ViewModel.Initialize(webView)
        End Sub
    End Class
End Namespace
