Imports SplitViewMVVMBasicVBDemo.ViewModels

Namespace Views
    Public NotInheritable Partial Class TabbedPage
        Inherits Page

        property ViewModel as TabbedViewModel = New TabbedViewModel

        Public Sub New()
            InitializeComponent()
        End Sub
    End Class
End Namespace
