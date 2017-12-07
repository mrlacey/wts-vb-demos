Imports BlankMVVMBasicVBDemo.Helpers
Imports BlankMVVMBasicVBDemo.Models
Imports BlankMVVMBasicVBDemo.Services

Imports Microsoft.Toolkit.Uwp.UI.Controls

Namespace ViewModels
    Public Class MasterDetail6ViewModel
        Inherits Observable

        Private _selected As SampleOrder

        Public Property Selected As SampleOrder
            Get
                Return _selected
            End Get
            Set
                [Set](_selected, value)
            End Set
        End Property

        Public Property SampleItems As ObservableCollection(Of SampleOrder) = new ObservableCollection(Of SampleOrder)

        Public Sub New()
        End Sub

        Public Async Function LoadDataAsync(viewState As MasterDetailsViewState) As Task
            SampleItems.Clear()

            Dim data = Await SampleDataService.GetSampleModelDataAsync()

            For Each item As SampleOrder In data
                SampleItems.Add(item)
            Next

            If viewState = MasterDetailsViewState.Both Then
                Selected = SampleItems.First()
            End If
        End Function
    End Class
End Namespace
