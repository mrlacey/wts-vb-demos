﻿Imports GalaSoft.MvvmLight

Imports Windows.ApplicationModel.DataTransfer.ShareTarget

Namespace ViewModels
    Public Class SharedDataViewModelBase
        Inherits ViewModelBase

        Private _dataFormat As String

        Public Property DataFormat As String
            Get
                Return _dataFormat
            End Get
            Set
                [Set](_dataFormat, value)
            End Set
        End Property

        Private _pageTitle As String

        Public Property PageTitle As String
            Get
                Return _pageTitle
            End Get
            Set
                [Set](_pageTitle, value)
            End Set
        End Property

        Private _title As String

        Public Property Title As String
            Get
                Return _title
            End Get
            Set
                [Set](_title, value)
            End Set
        End Property

        Public Sub New()
        End Sub

        Public Overridable Async Function LoadDataAsync(shareOperation As ShareOperation) As Task
            Title = shareOperation.Data.Properties.Title
            Await Task.CompletedTask
        End Function
    End Class
End Namespace
