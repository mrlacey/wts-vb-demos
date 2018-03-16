Imports SplitViewMVVMLightVBDemo.Views

Namespace Activation
    Friend Class ShareTargetActivationHandler
        Inherits ActivationHandler(Of ShareTargetActivatedEventArgs)

        Protected Overrides Async Function HandleInternalAsync(args As ShareTargetActivatedEventArgs) As Task
            ' Activation from ShareTarget opens the app as a new modal window which requires a new activation.
            Dim frame = New Frame()
            Window.Current.Content = frame
            frame.Navigate(GetType(ShareTargetPage), args.ShareOperation)
            Window.Current.Activate()

            Await Task.CompletedTask
        End Function
    End Class
End Namespace
