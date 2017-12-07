Imports BlankCodeBehindVBDemo.Views

Namespace Activation
    Friend Class ShareTarget4ActivationHandler
        Inherits ActivationHandler(Of ShareTargetActivatedEventArgs)

        Protected Overrides Async Function HandleInternalAsync(args As ShareTargetActivatedEventArgs) As Task
            ' Activation from ShareTarget opens the app as a new modal window which requires a new activation.
            Dim frame = New Frame()
            Window.Current.Content = frame
            frame.Navigate(GetType(ShareTarget4Page), args.ShareOperation)
            Window.Current.Activate()

            Await Task.CompletedTask
        End Function
    End Class
End Namespace
