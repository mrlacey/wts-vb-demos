Imports SplitViewMVVMLightVBDemo.ViewModels

Namespace Views
    Public NotInheritable Partial Class Chart7Page
        Inherits Page
        Private ReadOnly Property ViewModel() As Chart7ViewModel
          Get
            Return TryCast(DataContext, Chart7ViewModel)
          End Get
        End Property

        ' TODO WTS: Change the chart as appropriate to your app.
        ' For help see http://docs.telerik.com/windows-universal/controls/radchart/getting-started
        Public Sub New()
            InitializeComponent()
        End Sub
    End Class
End Namespace
