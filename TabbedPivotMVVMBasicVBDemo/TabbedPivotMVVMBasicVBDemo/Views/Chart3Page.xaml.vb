Imports TabbedPivotMVVMBasicVBDemo.ViewModels

Namespace Views
    Public NotInheritable Partial Class Chart3Page
        Inherits Page
            property ViewModel as Chart3ViewModel = New Chart3ViewModel

        ' TODO WTS: Change the chart as appropriate to your app.
        ' For help see http://docs.telerik.com/windows-universal/controls/radchart/getting-started
        Public Sub New()
            InitializeComponent()
        End Sub
    End Class
End Namespace
