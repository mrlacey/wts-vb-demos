Imports BlankMVVMLightVBDemo.ViewModels

Namespace Views
    Public NotInheritable Partial Class Grid1Page
        Inherits Page
        Private ReadOnly Property ViewModel() As Grid1ViewModel
          Get
            Return TryCast(DataContext, Grid1ViewModel)
          End Get
        End Property

        ' TODO WTS: Change the grid as appropriate to your app.
        ' For help see http://docs.telerik.com/windows-universal/controls/raddatagrid/gettingstarted
        ' You may also want to extend the grid to work with the RadDataForm http://docs.telerik.com/windows-universal/controls/raddataform/dataform-gettingstarted
        Public Sub New()
            InitializeComponent()
        End Sub
    End Class
End Namespace
