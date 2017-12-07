Imports BlankMVVMBasicVBDemo.Helpers
Imports BlankMVVMBasicVBDemo.Models
Imports BlankMVVMBasicVBDemo.Services

Namespace ViewModels
    Public Class Chart6ViewModel
        Inherits Observable
        Public Sub New()
        End Sub

        Public ReadOnly Property Source() As ObservableCollection(Of DataPoint)
            Get
                ' TODO WTS: Replace this with your actual data
                Return SampleDataService.GetChartSampleData()
            End Get
        End Property
    End Class
End Namespace
