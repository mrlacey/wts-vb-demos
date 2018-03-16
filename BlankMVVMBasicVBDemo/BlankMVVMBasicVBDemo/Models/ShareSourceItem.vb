Imports Windows.Storage

Namespace Models

    Friend Enum ShareSourceItemType
        Text = 0
        WebLink = 1
        ApplicationLink = 2
        Html = 3
        Image = 4
        StorageItems = 5
        DeferredContent = 6
    End Enum

    Friend Class ShareSourceItem

        Public Property DataType As ShareSourceItemType

        Public Property Text As String

        Public Property WebLink As Uri

        Public Property ApplicationLink As Uri

        Public Property Html As String

        Public Property Image As StorageFile

        Public Property StorageItems As IEnumerable(Of IStorageItem)

        Public Property DeferredDataFormatId As String

        Public Property GetDeferredDataAsyncFunc As Func(Of Task(Of Object))

        Private Sub New(dataType As ShareSourceItemType)
            DataType = dataType
        End Sub

        Friend Shared Function FromText(text As String) As ShareSourceItem
            Return New ShareSourceItem(ShareSourceItemType.Text) With {.Text = text}
        End Function

        Friend Shared Function FromWebLink(webLink As Uri) As ShareSourceItem
            Return New ShareSourceItem(ShareSourceItemType.WebLink) With {.WebLink = webLink}
        End Function

        Friend Shared Function FromApplicationLink(applicationLink As Uri) As ShareSourceItem
            Return New ShareSourceItem(ShareSourceItemType.ApplicationLink) With {.ApplicationLink = applicationLink}
        End Function

        Friend Shared Function FromHtml(html As String) As ShareSourceItem
            Return New ShareSourceItem(ShareSourceItemType.Html) With {.Html = html}
        End Function

        Friend Shared Function FromImage(image As StorageFile) As ShareSourceItem
            Return New ShareSourceItem(ShareSourceItemType.Image) With {.Image = image}
        End Function

        Friend Shared Function FromStorageItems(storageItems As IEnumerable(Of IStorageItem)) As ShareSourceItem
            Return New ShareSourceItem(ShareSourceItemType.StorageItems) With {.StorageItems = storageItems}
        End Function

        Friend Shared Function FromDeferredContent(deferredDataFormatId As String, getDeferredDataAsyncFunc As Func(Of Task(Of Object))) As ShareSourceItem
            Return New ShareSourceItem(ShareSourceItemType.DeferredContent) With {.DeferredDataFormatId = deferredDataFormatId, .GetDeferredDataAsyncFunc = getDeferredDataAsyncFunc}
        End Function
    End Class
End Namespace
