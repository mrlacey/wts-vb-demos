Imports TabbedPivotMVVMLightVBDemo.ViewModels

Namespace Views
    Public NotInheritable Partial Class Blank8Page
        Inherits Page
        Private ReadOnly Property ViewModel() As Blank8ViewModel
          Get
            Return TryCast(DataContext, Blank8ViewModel)
          End Get
        End Property


    End Class
End Namespace
