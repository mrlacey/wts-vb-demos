﻿Imports GalaSoft.MvvmLight
Imports GalaSoft.MvvmLight.Command

Imports Windows.ApplicationModel.DataTransfer
Imports Windows.ApplicationModel.DataTransfer.ShareTarget

Namespace ViewModels
    Public Class ShareTarget7ViewModel
        Inherits ViewModelBase

        Private _shareOperation As ShareOperation

        Private _sharedData As SharedDataViewModelBase

        Public Property SharedData As SharedDataViewModelBase
            Get
                Return _sharedData
            End Get
            Set
                [Set](_sharedData, value)
            End Set
        End Property

        Private _completeCommand As ICommand

        Public ReadOnly Property CompleteCommand As ICommand
            Get
                If _completeCommand Is Nothing Then
                    _completeCommand = New RelayCommand(AddressOf OnComplete)
                End If
                Return _completeCommand
            End Get
        End Property

        Public Sub New()
        End Sub

        Public Async Function LoadAsync(shareOperation As ShareOperation) As Task
            ' TODO WTS: Configure your Share Target Declaration to allow other data formats.
            ' Share Target declarations are defined in Package.appxmanifest.
            ' Current declarations allow to share WebLink and image files with the app.
            ' ShareTarget can be tested sharing the WebLink from Microsoft Edge or sharing images from Windows Photos.

            ' TODO WTS: Customize SharedDataModelBase or derived classes adding properties for data that you need to extract from _shareOperation
            _shareOperation = shareOperation
            If shareOperation.Data.Contains(StandardDataFormats.StorageItems) Then
                SharedData = New SharedDataStorageItemsViewModel()
            End If

            If shareOperation.Data.Contains(StandardDataFormats.WebLink) Then
                SharedData = New SharedDataWebLinkViewModel()
            End If

            Await SharedData?.LoadDataAsync(_shareOperation)
        End Function

        Private Sub OnComplete()
            ' TODO WTS: Implement the actions you want to realize with the shared data before compleate the share operation.
            ' For further details check https://docs.microsoft.com/en-us/windows/uwp/app-to-app/receive-data
            _shareOperation.ReportCompleted()
        End Sub
    End Class
End Namespace
