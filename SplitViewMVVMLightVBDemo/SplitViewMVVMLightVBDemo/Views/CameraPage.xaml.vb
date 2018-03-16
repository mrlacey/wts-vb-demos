Imports SplitViewMVVMLightVBDemo.ViewModels

Namespace Views
    Public NotInheritable Partial Class CameraPage
        Inherits Page

        Private ReadOnly Property ViewModel As CameraViewModel
            Get
                Return TryCast(DataContext, CameraViewModel)
            End Get
        End Property

        Public Sub New()
            InitializeComponent()
        End Sub
    End Class
End Namespace
