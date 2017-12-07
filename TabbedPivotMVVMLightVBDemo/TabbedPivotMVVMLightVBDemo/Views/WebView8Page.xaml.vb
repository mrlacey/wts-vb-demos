Imports TabbedPivotMVVMLightVBDemo.ViewModels

Namespace Views
    Public NotInheritable Partial Class WebView8Page
        Inherits Page
        Private ReadOnly Property ViewModel() As WebView8ViewModel
          Get
            Return TryCast(DataContext, WebView8ViewModel)
          End Get
        End Property


        Public Sub New()
            InitializeComponent()
            ViewModel.Initialize(webView)
        End Sub
    End Class
End Namespace
