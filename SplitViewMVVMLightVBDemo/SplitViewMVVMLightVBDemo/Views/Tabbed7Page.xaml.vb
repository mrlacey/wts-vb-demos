Imports SplitViewMVVMLightVBDemo.ViewModels

Namespace Views
    Public NotInheritable Partial Class Tabbed7Page
        Inherits Page
        Private ReadOnly Property ViewModel() As Tabbed7ViewModel
          Get
            Return TryCast(DataContext, Tabbed7ViewModel)
          End Get
        End Property

        Public Sub New()
            InitializeComponent()
        End Sub
    End Class
End Namespace
