Imports GalaSoft.MvvmLight

Imports TabbedPivotMVVMLightVBDemo.Models
Imports TabbedPivotMVVMLightVBDemo.Services

Namespace ViewModels
    Public Class Grid8ViewModel
        Inherits ViewModelBase
        Public ReadOnly Property Source() As ObservableCollection(Of SampleOrder)
            Get
                ' TODO WTS: Replace this with your actual data
                Return SampleDataService.GetGridSampleData()
            End Get
        End Property
    End Class
End Namespace
