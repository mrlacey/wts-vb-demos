Imports Windows.Storage

Namespace Models

    Friend Enum ShareSource1ItemType
        Text = 0
        WebLink = 1
        ApplicationLink = 2
        Html = 3
        Image = 4
        StorageItems = 5
        DeferredContent = 6
    End Enum

    Friend Class ShareSource1Item

        Public Property DataType As ShareSource1ItemType

        Public Property Text As String

        Public Property WebLink As Uri

        Public Property ApplicationLink As Uri

        Public Property Html As String

        Public Property Image As StorageFile

        Public Property StorageItems As IEnumerable(Of IStorageItem)

        Public Property DeferredDataFormatId As String

        Public Property GetDeferredDataAsyncFunc As Func(Of Task(Of Object))

        Private Sub New(ByVal dataType As ShareSource1ItemType)
            DataType = dataType
        End Sub

        Friend Shared Function FromText(ByVal text As String) As ShareSource1Item
            Return New ShareSource1Item(ShareSource1ItemType.Text) With {.Text = text}
        End Function

        Friend Shared Function FromWebLink(ByVal webLink As Uri) As ShareSource1Item
            Return New ShareSource1Item(ShareSource1ItemType.WebLink) With {.WebLink = webLink}
        End Function

        Friend Shared Function FromApplicationLink(ByVal applicationLink As Uri) As ShareSource1Item
            Return New ShareSource1Item(ShareSource1ItemType.ApplicationLink) With {.ApplicationLink = applicationLink}
        End Function

        Friend Shared Function FromHtml(ByVal html As String) As ShareSource1Item
            Return New ShareSource1Item(ShareSource1ItemType.Html) With {.Html = html}
        End Function

        Friend Shared Function FromImage(ByVal image As StorageFile) As ShareSource1Item
            Return New ShareSource1Item(ShareSource1ItemType.Image) With {.Image = image}
        End Function

        Friend Shared Function FromStorageItems(ByVal storageItems As IEnumerable(Of IStorageItem)) As ShareSource1Item
            Return New ShareSource1Item(ShareSource1ItemType.StorageItems) With {.StorageItems = storageItems}
        End Function

        Friend Shared Function FromDeferredContent(ByVal deferredDataFormatId As String, ByVal getDeferredDataAsyncFunc As Func(Of Task(Of Object))) As ShareSource1Item
            Return New ShareSource1Item(ShareSource1ItemType.DeferredContent) With {.DeferredDataFormatId = deferredDataFormatId, .GetDeferredDataAsyncFunc = getDeferredDataAsyncFunc}
        End Function
    End Class
End Namespace
