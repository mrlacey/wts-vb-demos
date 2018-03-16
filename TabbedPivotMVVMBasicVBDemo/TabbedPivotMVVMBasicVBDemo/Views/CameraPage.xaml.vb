Imports TabbedPivotMVVMBasicVBDemo.ViewModels

Namespace Views
    Public NotInheritable Partial Class CameraPage
        Inherits Page

        property ViewModel as CameraViewModel = New CameraViewModel

        Public Sub New()
            InitializeComponent()
        End Sub
    End Class
End Namespace
