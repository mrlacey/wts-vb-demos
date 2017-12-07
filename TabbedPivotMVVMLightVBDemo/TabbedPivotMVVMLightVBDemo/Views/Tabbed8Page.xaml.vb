Imports TabbedPivotMVVMLightVBDemo.ViewModels

Namespace Views
    Public NotInheritable Partial Class Tabbed8Page
        Inherits Page
        Private ReadOnly Property ViewModel() As Tabbed8ViewModel
          Get
            Return TryCast(DataContext, Tabbed8ViewModel)
          End Get
        End Property

        Public Sub New()
            InitializeComponent()
        End Sub
    End Class
End Namespace
