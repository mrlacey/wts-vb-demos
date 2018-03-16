Imports SplitViewMVVMBasicVBDemo.ViewModels

Namespace Views
    Public NotInheritable Partial Class ChartPage
        Inherits Page

        property ViewModel as ChartViewModel = New ChartViewModel

        ' TODO WTS: Change the chart as appropriate to your app.
        ' For help see http://docs.telerik.com/windows-universal/controls/radchart/getting-started
        Public Sub New()
            InitializeComponent()
        End Sub
    End Class
End Namespace
