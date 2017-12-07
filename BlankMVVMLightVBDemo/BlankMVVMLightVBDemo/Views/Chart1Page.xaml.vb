Imports BlankMVVMLightVBDemo.ViewModels

Namespace Views
    Public NotInheritable Partial Class Chart1Page
        Inherits Page
        Private ReadOnly Property ViewModel() As Chart1ViewModel
          Get
            Return TryCast(DataContext, Chart1ViewModel)
          End Get
        End Property

        ' TODO WTS: Change the chart as appropriate to your app.
        ' For help see http://docs.telerik.com/windows-universal/controls/radchart/getting-started
        Public Sub New()
            InitializeComponent()
        End Sub
    End Class
End Namespace
