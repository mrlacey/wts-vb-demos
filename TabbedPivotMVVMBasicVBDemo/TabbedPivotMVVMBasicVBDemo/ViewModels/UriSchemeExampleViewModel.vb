﻿Imports TabbedPivotMVVMBasicVBDemo.Helpers

Namespace ViewModels
    ' TODO WTS: Remove this example page when/if it's not needed.
    ' This page is an example of how to launch a specific page in response to a protocol launch and pass it a value.
    ' It is expected that you will delete this page once you have changed the handling of a protocol launch to meet
    ' your needs and redirected to another of your pages.
    Public Class UriSchemeExampleViewModel
        Inherits Observable

        ' This property is just for displaying the passed in value
        Private _secret As String

        Public Property Secret As String
            Get
                Return _secret
            End Get

            Set
                [Set](_secret, Value)
            End Set
        End Property
    End Class
End Namespace
