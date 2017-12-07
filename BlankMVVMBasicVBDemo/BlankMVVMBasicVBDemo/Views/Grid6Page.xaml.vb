Imports BlankMVVMBasicVBDemo.ViewModels

Namespace Views
    Public NotInheritable Partial Class Grid6Page
        Inherits Page
            property ViewModel as Grid6ViewModel = New Grid6ViewModel

        ' TODO WTS: Change the grid as appropriate to your app.
        ' For help see http://docs.telerik.com/windows-universal/controls/raddatagrid/gettingstarted
        ' You may also want to extend the grid to work with the RadDataForm http://docs.telerik.com/windows-universal/controls/raddataform/dataform-gettingstarted
        Public Sub New()
            InitializeComponent()
        End Sub
    End Class
End Namespace
