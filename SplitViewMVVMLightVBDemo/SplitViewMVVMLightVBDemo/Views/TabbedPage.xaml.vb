Imports SplitViewMVVMLightVBDemo.ViewModels

Namespace Views
    Public NotInheritable Partial Class TabbedPage
        Inherits Page

        Private ReadOnly Property ViewModel As TabbedViewModel
            Get
                Return TryCast(DataContext, TabbedViewModel)
            End Get
        End Property

        Public Sub New()
            InitializeComponent()
        End Sub
    End Class
End Namespace
