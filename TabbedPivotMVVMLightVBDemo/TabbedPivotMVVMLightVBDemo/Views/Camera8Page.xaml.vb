Imports TabbedPivotMVVMLightVBDemo.ViewModels

Namespace Views
    Public NotInheritable Partial Class Camera8Page
        Inherits Page
        Private ReadOnly Property ViewModel() As Camera8ViewModel
          Get
            Return TryCast(DataContext, Camera8ViewModel)
          End Get
        End Property


        Public Sub New()
            InitializeComponent()
        End Sub
    End Class
End Namespace
