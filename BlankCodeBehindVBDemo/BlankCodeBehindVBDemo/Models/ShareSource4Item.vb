Imports Windows.Storage

Namespace Models

    Friend Enum ShareSource4ItemType
        Text = 0
        WebLink = 1
        ApplicationLink = 2
        Html = 3
        Image = 4
        StorageItems = 5
        DeferredContent = 6
    End Enum

    Friend Class ShareSource4Item

        Public Property DataType As ShareSource4ItemType

        Public Property Text As String

        Public Property WebLink As Uri

        Public Property ApplicationLink As Uri

        Public Property Html As String

        Public Property Image As StorageFile

        Public Property StorageItems As IEnumerable(Of IStorageItem)

        Public Property DeferredDataFormatId As String

        Public Property GetDeferredDataAsyncFunc As Func(Of Task(Of Object))

        Private Sub New(ByVal dataType As ShareSource4ItemType)
            DataType = dataType
        End Sub

        Friend Shared Function FromText(ByVal text As String) As ShareSource4Item
            Return New ShareSource4Item(ShareSource4ItemType.Text) With {.Text = text}
        End Function

        Friend Shared Function FromWebLink(ByVal webLink As Uri) As ShareSource4Item
            Return New ShareSource4Item(ShareSource4ItemType.WebLink) With {.WebLink = webLink}
        End Function

        Friend Shared Function FromApplicationLink(ByVal applicationLink As Uri) As ShareSource4Item
            Return New ShareSource4Item(ShareSource4ItemType.ApplicationLink) With {.ApplicationLink = applicationLink}
        End Function

        Friend Shared Function FromHtml(ByVal html As String) As ShareSource4Item
            Return New ShareSource4Item(ShareSource4ItemType.Html) With {.Html = html}
        End Function

        Friend Shared Function FromImage(ByVal image As StorageFile) As ShareSource4Item
            Return New ShareSource4Item(ShareSource4ItemType.Image) With {.Image = image}
        End Function

        Friend Shared Function FromStorageItems(ByVal storageItems As IEnumerable(Of IStorageItem)) As ShareSource4Item
            Return New ShareSource4Item(ShareSource4ItemType.StorageItems) With {.StorageItems = storageItems}
        End Function

        Friend Shared Function FromDeferredContent(ByVal deferredDataFormatId As String, ByVal getDeferredDataAsyncFunc As Func(Of Task(Of Object))) As ShareSource4Item
            Return New ShareSource4Item(ShareSource4ItemType.DeferredContent) With {.DeferredDataFormatId = deferredDataFormatId, .GetDeferredDataAsyncFunc = getDeferredDataAsyncFunc}
        End Function
    End Class
End Namespace
