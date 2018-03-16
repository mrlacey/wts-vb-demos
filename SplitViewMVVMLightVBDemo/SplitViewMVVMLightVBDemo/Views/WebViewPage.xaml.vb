Imports SplitViewMVVMLightVBDemo.ViewModels

Namespace Views
    Public NotInheritable Partial Class WebViewPage
        Inherits Page

        Private ReadOnly Property ViewModel As WebViewViewModel
            Get
                Return TryCast(DataContext, WebViewViewModel)
            End Get
        End Property

        Public Sub New()
            InitializeComponent()
            ViewModel.Initialize(webView)
        End Sub
    End Class
End Namespace
