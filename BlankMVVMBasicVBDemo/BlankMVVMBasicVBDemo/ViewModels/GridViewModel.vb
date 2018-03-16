Imports BlankMVVMBasicVBDemo.Helpers
Imports BlankMVVMBasicVBDemo.Models
Imports BlankMVVMBasicVBDemo.Services

Namespace ViewModels
    Public Class GridViewModel
        Inherits Observable

        Public ReadOnly Property Source As ObservableCollection(Of SampleOrder)
            Get
                ' TODO WTS: Replace this with your actual data
                Return SampleDataService.GetGridSampleData()
            End Get
        End Property
    End Class
End Namespace
