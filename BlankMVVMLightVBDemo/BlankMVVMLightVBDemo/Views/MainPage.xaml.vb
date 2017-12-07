Imports BlankMVVMLightVBDemo.ViewModels

Namespace Views
    Public NotInheritable Partial Class MainPage
        Inherits Page
        Private ReadOnly Property ViewModel() As MainViewModel
          Get
            Return TryCast(DataContext, MainViewModel)
          End Get
        End Property


    End Class
End Namespace
