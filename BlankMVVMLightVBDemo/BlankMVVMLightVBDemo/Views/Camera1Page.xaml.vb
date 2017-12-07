Imports BlankMVVMLightVBDemo.ViewModels

Namespace Views
    Public NotInheritable Partial Class Camera1Page
        Inherits Page
        Private ReadOnly Property ViewModel() As Camera1ViewModel
          Get
            Return TryCast(DataContext, Camera1ViewModel)
          End Get
        End Property


        Public Sub New()
            InitializeComponent()
        End Sub
    End Class
End Namespace
