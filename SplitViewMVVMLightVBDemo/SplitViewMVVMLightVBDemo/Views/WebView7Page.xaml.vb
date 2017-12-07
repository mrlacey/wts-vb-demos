Imports SplitViewMVVMLightVBDemo.ViewModels

Namespace Views
    Public NotInheritable Partial Class WebView7Page
        Inherits Page
        Private ReadOnly Property ViewModel() As WebView7ViewModel
          Get
            Return TryCast(DataContext, WebView7ViewModel)
          End Get
        End Property


        Public Sub New()
            InitializeComponent()
            ViewModel.Initialize(webView)
        End Sub
    End Class
End Namespace
