Imports SplitViewMVVMLightVBDemo.ViewModels

Namespace Views
    Public NotInheritable Partial Class Camera7Page
        Inherits Page
        Private ReadOnly Property ViewModel() As Camera7ViewModel
          Get
            Return TryCast(DataContext, Camera7ViewModel)
          End Get
        End Property


        Public Sub New()
            InitializeComponent()
        End Sub
    End Class
End Namespace
