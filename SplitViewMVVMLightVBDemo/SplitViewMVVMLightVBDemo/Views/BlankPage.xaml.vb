Imports SplitViewMVVMLightVBDemo.ViewModels

Namespace Views
    Public NotInheritable Partial Class BlankPage
        Inherits Page

        Private ReadOnly Property ViewModel As BlankViewModel
            Get
                Return TryCast(DataContext, BlankViewModel)
            End Get
        End Property

    End Class
End Namespace
