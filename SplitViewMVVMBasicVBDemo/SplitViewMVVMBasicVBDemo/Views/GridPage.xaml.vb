Imports SplitViewMVVMBasicVBDemo.ViewModels

Namespace Views
    Public NotInheritable Partial Class GridPage
        Inherits Page
            property ViewModel as GridViewModel = New GridViewModel

        ' TODO WTS: Change the grid as appropriate to your app.
        ' For help see http://docs.telerik.com/windows-universal/controls/raddatagrid/gettingstarted
        ' You may also want to extend the grid to work with the RadDataForm http://docs.telerik.com/windows-universal/controls/raddataform/dataform-gettingstarted
        Public Sub New()
            InitializeComponent()
        End Sub
    End Class
End Namespace
