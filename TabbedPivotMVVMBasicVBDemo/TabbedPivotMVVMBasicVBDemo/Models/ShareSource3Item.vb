Imports Windows.Storage

Namespace Models

    Friend Enum ShareSource3ItemType
        Text = 0
        WebLink = 1
        ApplicationLink = 2
        Html = 3
        Image = 4
        StorageItems = 5
        DeferredContent = 6
    End Enum

    Friend Class ShareSource3Item

        Public Property DataType As ShareSource3ItemType

        Public Property Text As String

        Public Property WebLink As Uri

        Public Property ApplicationLink As Uri

        Public Property Html As String

        Public Property Image As StorageFile

        Public Property StorageItems As IEnumerable(Of IStorageItem)

        Public Property DeferredDataFormatId As String

        Public Property GetDeferredDataAsyncFunc As Func(Of Task(Of Object))

        Private Sub New(ByVal dataType As ShareSource3ItemType)
            DataType = dataType
        End Sub

        Friend Shared Function FromText(ByVal text As String) As ShareSource3Item
            Return New ShareSource3Item(ShareSource3ItemType.Text) With {.Text = text}
        End Function

        Friend Shared Function FromWebLink(ByVal webLink As Uri) As ShareSource3Item
            Return New ShareSource3Item(ShareSource3ItemType.WebLink) With {.WebLink = webLink}
        End Function

        Friend Shared Function FromApplicationLink(ByVal applicationLink As Uri) As ShareSource3Item
            Return New ShareSource3Item(ShareSource3ItemType.ApplicationLink) With {.ApplicationLink = applicationLink}
        End Function

        Friend Shared Function FromHtml(ByVal html As String) As ShareSource3Item
            Return New ShareSource3Item(ShareSource3ItemType.Html) With {.Html = html}
        End Function

        Friend Shared Function FromImage(ByVal image As StorageFile) As ShareSource3Item
            Return New ShareSource3Item(ShareSource3ItemType.Image) With {.Image = image}
        End Function

        Friend Shared Function FromStorageItems(ByVal storageItems As IEnumerable(Of IStorageItem)) As ShareSource3Item
            Return New ShareSource3Item(ShareSource3ItemType.StorageItems) With {.StorageItems = storageItems}
        End Function

        Friend Shared Function FromDeferredContent(ByVal deferredDataFormatId As String, ByVal getDeferredDataAsyncFunc As Func(Of Task(Of Object))) As ShareSource3Item
            Return New ShareSource3Item(ShareSource3ItemType.DeferredContent) With {.DeferredDataFormatId = deferredDataFormatId, .GetDeferredDataAsyncFunc = getDeferredDataAsyncFunc}
        End Function
    End Class
End Namespace
