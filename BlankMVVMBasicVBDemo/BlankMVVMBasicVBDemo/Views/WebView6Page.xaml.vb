Imports BlankMVVMBasicVBDemo.ViewModels

Namespace Views
    Public NotInheritable Partial Class WebView6Page
        Inherits Page
            property ViewModel as WebView6ViewModel = New WebView6ViewModel

        Public Sub New()
            InitializeComponent()
            ViewModel.Initialize(webView)
        End Sub
    End Class
End Namespace
