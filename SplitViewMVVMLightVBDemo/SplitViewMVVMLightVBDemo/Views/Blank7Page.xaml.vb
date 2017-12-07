Imports SplitViewMVVMLightVBDemo.ViewModels

Namespace Views
    Public NotInheritable Partial Class Blank7Page
        Inherits Page
        Private ReadOnly Property ViewModel() As Blank7ViewModel
          Get
            Return TryCast(DataContext, Blank7ViewModel)
          End Get
        End Property


    End Class
End Namespace
