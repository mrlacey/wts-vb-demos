Imports GalaSoft.MvvmLight

Imports SplitViewMVVMLightVBDemo.Models
Imports SplitViewMVVMLightVBDemo.Services

Namespace ViewModels
    Public Class ChartViewModel
        Inherits ViewModelBase

        Public Sub New()
        End Sub

        Public ReadOnly Property Source As ObservableCollection(Of DataPoint)
            Get
                ' TODO WTS: Replace this with your actual data
                Return SampleDataService.GetChartSampleData()
            End Get
        End Property
    End Class
End Namespace
