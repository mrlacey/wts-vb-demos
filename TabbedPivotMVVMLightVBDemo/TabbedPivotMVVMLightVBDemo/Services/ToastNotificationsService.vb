﻿Imports TabbedPivotMVVMLightVBDemo.Activation

Imports Windows.UI.Notifications

Namespace Services
    Friend Partial Class ToastNotificationsService
        Inherits ActivationHandler(Of ToastNotificationActivatedEventArgs)

        Public Sub ShowToastNotification(toastNotification As ToastNotification)
            ToastNotificationManager.CreateToastNotifier().Show(toastNotification)
        End Sub

        Protected Overrides Async Function HandleInternalAsync(args As ToastNotificationActivatedEventArgs) As Task
            ' TODO WTS: Handle activation from toast notification
            ' More details at https://blogs.msdn.microsoft.com/tiles_and_toasts/2015/07/08/quickstart-sending-a-local-toast-notification-and-handling-activations-from-it-windows-10/

            Await Task.CompletedTask
        End Function
    End Class
End Namespace
