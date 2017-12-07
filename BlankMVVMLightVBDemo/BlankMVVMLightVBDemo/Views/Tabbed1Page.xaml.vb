Imports BlankMVVMLightVBDemo.ViewModels

Namespace Views
    Public NotInheritable Partial Class Tabbed1Page
        Inherits Page
        Private ReadOnly Property ViewModel() As Tabbed1ViewModel
          Get
            Return TryCast(DataContext, Tabbed1ViewModel)
          End Get
        End Property

        Public Sub New()
            InitializeComponent()
        End Sub
    End Class
End Namespace
