Imports BlankMVVMLightVBDemo.ViewModels

Namespace Views
    Public NotInheritable Partial Class Blank1Page
        Inherits Page
        Private ReadOnly Property ViewModel() As Blank1ViewModel
          Get
            Return TryCast(DataContext, Blank1ViewModel)
          End Get
        End Property


    End Class
End Namespace
