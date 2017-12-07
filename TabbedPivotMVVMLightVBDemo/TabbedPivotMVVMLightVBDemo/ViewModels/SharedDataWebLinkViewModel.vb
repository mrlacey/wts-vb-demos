﻿Imports TabbedPivotMVVMLightVBDemo.Helpers

Imports Windows.ApplicationModel.DataTransfer
Imports Windows.ApplicationModel.DataTransfer.ShareTarget

Namespace ViewModels
    Public Class SharedDataWebLinkViewModel
        Inherits SharedDataViewModelBase
        Private _uri As Uri

        Public Property Uri() As Uri
            Get
                Return _uri
            End Get
            Set
                [Set](_uri, value)
            End Set
        End Property

        Public Sub New()
        End Sub

        Public Overrides Async Function LoadDataAsync(shareOperation As ShareOperation) As Task
            Await MyBase.LoadDataAsync(shareOperation)

            PageTitle = "ShareTarget8_WebLinkTitle".GetLocalized()
            DataFormat = StandardDataFormats.WebLink
            Uri = Await shareOperation.GetWebLinkAsync()
        End Function
    End Class
End Namespace
