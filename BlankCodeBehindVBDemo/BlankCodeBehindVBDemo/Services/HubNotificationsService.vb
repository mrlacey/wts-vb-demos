﻿Imports BlankCodeBehindVBDemo.Activation

Imports Microsoft.WindowsAzure.Messaging

Imports Windows.Networking.PushNotifications

Namespace Services
    ' More about adding push notifications to your Windows app at https://docs.microsoft.com/azure/app-service-mobile/app-service-mobile-windows-store-dotnet-get-started-push
    Friend Class HubNotificationsService
        Inherits ActivationHandler(Of ToastNotificationActivatedEventArgs)

        Public Async Function InitializeAsync() As Task
            ' TODO WTS: Set your Hub Name
            Dim hubName = String.Empty

            ' TODO WTS: Set your DefaultListenSharedAccessSignature
            Dim accessSignature = String.Empty

            Dim channel = Await PushNotificationChannelManager.CreatePushNotificationChannelForApplicationAsync()

            Dim hub = New NotificationHub(hubName, accessSignature)
            Dim result = Await hub.RegisterNativeAsync(channel.Uri)

            If result.RegistrationId IsNot Nothing Then
                    ' Registration was successful
            End If

            ' You can also send push notifications from Windows Developer Center targeting your app consumers
            ' More details at https://docs.microsoft.com/windows/uwp/publish/send-push-notifications-to-your-apps-customers
        End Function

        Protected Overrides Async Function HandleInternalAsync(args As ToastNotificationActivatedEventArgs) As Task
            ' TODO WTS: Handle activation from toast notification,
            ' Be sure to use the template 'ToastGeneric' in the toast notification configuration XML
            ' to ensure OnActivated is called when launching from a Toast Notification sent from Azure
            '
            ' More about handling activation at https://docs.microsoft.com/windows/uwp/design/shell/tiles-and-notifications/send-local-toast
            Await Task.CompletedTask
        End Function
    End Class
End Namespace
