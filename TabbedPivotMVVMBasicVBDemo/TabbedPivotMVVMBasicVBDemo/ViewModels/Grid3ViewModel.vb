Imports TabbedPivotMVVMBasicVBDemo.Helpers
Imports TabbedPivotMVVMBasicVBDemo.Models
Imports TabbedPivotMVVMBasicVBDemo.Services

Namespace ViewModels
    Public Class Grid3ViewModel
        Inherits Observable
        Public ReadOnly Property Source() As ObservableCollection(Of SampleOrder)
            Get
                ' TODO WTS: Replace this with your actual data
                Return SampleDataService.GetGridSampleData()
            End Get
        End Property
    End Class
End Namespace
