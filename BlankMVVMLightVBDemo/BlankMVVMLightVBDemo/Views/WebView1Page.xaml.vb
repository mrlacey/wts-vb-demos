Imports BlankMVVMLightVBDemo.ViewModels

Namespace Views
    Public NotInheritable Partial Class WebView1Page
        Inherits Page
        Private ReadOnly Property ViewModel() As WebView1ViewModel
          Get
            Return TryCast(DataContext, WebView1ViewModel)
          End Get
        End Property


        Public Sub New()
            InitializeComponent()
            ViewModel.Initialize(webView)
        End Sub
    End Class
End Namespace
