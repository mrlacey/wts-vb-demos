Imports TabbedPivotMVVMBasicVBDemo.Helpers

Imports Windows.Storage

Namespace Models
    Public Class ShareSourceData

        Public Property Title As String

        Public Property Description As String

        Friend Property Items As List(Of ShareSourceItem)

        Public Sub New(title As String, Optional desciption As String = Nothing)
            If String.IsNullOrEmpty(title) Then
                Throw New ArgumentException("ExceptionShareSourceDataTitleIsNullOrEmpty".GetLocalized(), NameOf(title))
            End If

            Items = New List(Of ShareSourceItem)()
            Title = title
            Description = desciption
        End Sub

        Public Sub SetText(text As String)
            If String.IsNullOrEmpty(text) Then
                Throw New ArgumentException("ExceptionShareSourceDataTitleIsNullOrEmpty".GetLocalized(), nameof(text))
            End If

            Items.Add(ShareSourceItem.FromText(text))
        End Sub

        Public Sub SetWebLink(webLink As Uri)
            If webLink Is Nothing Then
                Throw New ArgumentNullException(NameOf(webLink))
            End If

            Items.Add(ShareSourceItem.FromWebLink(webLink))
        End Sub

        ' To share a link to your app you must first register it to handle URI activation
        ' More details at https://docs.microsoft.com/en-us/windows/uwp/launch-resume/handle-uri-activation
        Public Sub SetApplicationLink(applicationLink As Uri)
            If applicationLink Is Nothing Then
                Throw New ArgumentNullException(NameOf(applicationLink))
            End If

            Items.Add(ShareSourceItem.FromApplicationLink(applicationLink))
        End Sub

        Public Sub SetHtml(html As String)
            If String.IsNullOrEmpty(html) Then
                Throw New ArgumentException("ExceptionShareSourceDataHtmlIsNullOrEmpty".GetLocalized(), nameof(html))
            End If

            Items.Add(ShareSourceItem.FromHtml(html))
        End Sub

        Public Sub SetImage(image As StorageFile)
            If image Is Nothing Then
                Throw New ArgumentNullException(NameOf(image))
            End If

            Items.Add(ShareSourceItem.FromImage(image))
        End Sub

        Public Sub SetStorageItems(storageItems As IEnumerable(Of IStorageItem))
            If storageItems Is Nothing OrElse Not storageItems.Any() Then
                Throw New ArgumentException("ExceptionShareSourceDataStorageItemsIsNullOrEmpty".GetLocalized(), nameof(storageItems))
            End If

            Items.Add(ShareSourceItem.FromStorageItems(storageItems))
        End Sub

        ' Use this method to add content to share when you do not want to process the data until the target app actually requests it.
        ' The defferedDataFormatId parameter must be a const value from StandardDataFormats class.
        ' The getDeferredDataAsyncFunc parameter is the function that returns the object you want to share.
        Public Sub SetDeferredContent(deferredDataFormatId As String, getDeferredDataAsyncFunc As Func(Of Task(Of Object)))
            If String.IsNullOrEmpty(deferredDataFormatId) Then
                Throw New ArgumentException("ExceptionShareSourceDataDeferredDataFormatIdIsNullOrEmpty".GetLocalized(), nameof(deferredDataFormatId))
            End If

            Items.Add(ShareSourceItem.FromDeferredContent(deferredDataFormatId, getDeferredDataAsyncFunc))
        End Sub
    End Class
End Namespace
