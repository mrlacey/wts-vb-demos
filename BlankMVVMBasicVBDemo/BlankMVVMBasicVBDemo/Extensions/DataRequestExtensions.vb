Imports BlankMVVMBasicVBDemo.Models

Imports Windows.ApplicationModel.DataTransfer
Imports Windows.Storage
Imports Windows.Storage.Streams

Namespace Extensions
    Module DataRequestExtensions
        <Extension>
        Sub SetData(ByVal dataRequest As DataRequest, ByVal config As ShareSource6Data)
            Dim deferral = dataRequest.GetDeferral()
            Try
                Dim requestData = dataRequest.Data
                requestData.Properties.Title = config.Title
                If Not String.IsNullOrEmpty(config.Description) Then
                    requestData.Properties.Description = config.Description
                End If

                Dim storageItems = New List(Of IStorageItem)()
                For Each dataItem In config.Items
                    Select Case dataItem.DataType
                        Case ShareSource6ItemType.Text
                            requestData.SetText(dataItem.Text)
                        Case ShareSource6ItemType.WebLink
                            requestData.SetWebLink(dataItem.WebLink)
                        Case ShareSource6ItemType.ApplicationLink
                            requestData.SetApplicationLink(dataItem.ApplicationLink)
                        Case ShareSource6ItemType.Html
                            Dim htmlFormat = HtmlFormatHelper.CreateHtmlFormat(dataItem.Html)
                            requestData.SetHtmlFormat(htmlFormat)
                        Case ShareSource6ItemType.Image
                            requestData.FillImage(dataItem.Image, storageItems)
                        Case ShareSource6ItemType.StorageItems
                            requestData.FillStorageItems(dataItem.StorageItems, storageItems)
                        Case ShareSource6ItemType.DeferredContent
                            requestData.FillDeferredContent(dataItem.DeferredDataFormatId, dataItem.GetDeferredDataAsyncFunc)
                    End Select
                Next

                If storageItems.Any() Then
                    requestData.SetStorageItems(storageItems)
                End If
            Finally
                deferral.Complete()
            End Try
        End Sub

        <Extension>
        Private Sub FillImage(ByVal requestData As DataPackage, ByVal image As StorageFile, ByVal storageItems As List(Of IStorageItem))
            storageItems.Add(image)
            Dim streamReference = RandomAccessStreamReference.CreateFromFile(image)
            requestData.Properties.Thumbnail = streamReference
            requestData.SetBitmap(streamReference)
        End Sub

        <Extension>
        Private Sub FillStorageItems(ByVal requestData As DataPackage, ByVal sourceItems As IEnumerable(Of IStorageItem), ByVal storageItems As List(Of IStorageItem))
            For Each item In sourceItems
                storageItems.Add(item)
            Next
        End Sub

        <Extension>
        Private Sub FillDeferredContent(ByVal requestData As DataPackage, ByVal deferredDataFormatId As String, ByVal getDeferredDataAsyncFunc As Func(Of Task(Of Object)))
            requestData.SetDataProvider(deferredDataFormatId, Async Sub(providerRequest)
                Dim deferral = providerRequest.GetDeferral()
                Try
                    Dim deferredData = Await getDeferredDataAsyncFunc()
                    providerRequest.SetData(deferredData)
                Finally
                    deferral.Complete()
                End Try
            End Sub)
        End Sub
    End Module
End Namespace
