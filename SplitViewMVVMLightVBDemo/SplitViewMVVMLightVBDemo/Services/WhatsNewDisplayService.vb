Imports Microsoft.Toolkit.Uwp.Helpers

Imports SplitViewMVVMLightVBDemo.Views

Namespace Services
    ' For instructions on testing this service see https://github.com/Microsoft/WindowsTemplateStudio/tree/master/docs/features/whats-new-prompt.md
    Public Module WhatsNewDisplayService
        Dim shown As Boolean = False

        Friend Async Function ShowIfAppropriateAsync() As Task
            If SystemInformation.IsAppUpdated AndAlso Not shown Then
                shown = True
                Dim dialog = New WhatsNewDialog()
                Await dialog.ShowAsync()
            End If
        End Function
    End Module
End Namespace
