﻿Imports TabbedPivotMVVMBasicVBDemo.Models

Namespace Views
    Public NotInheritable Partial Class MasterDetail3DetailControl
        Inherits UserControl

        Public Property MasterMenuItem As SampleOrder
            Get
                Return TryCast(GetValue(MasterMenuItemProperty), SampleOrder)
            End Get
            Set
                SetValue(MasterMenuItemProperty, value)
            End Set
        End Property

        Public Shared ReadOnly MasterMenuItemProperty As DependencyProperty = DependencyProperty.Register("MasterMenuItem", GetType(SampleOrder), GetType(MasterDetail3DetailControl), New PropertyMetadata(Nothing, AddressOf OnMasterMenuItemPropertyChanged))

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Shared Sub OnMasterMenuItemPropertyChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
            Dim control = TryCast(d, MasterDetail3DetailControl)
            control.ForegroundElement.ChangeView(0, 0, 1)
        End Sub
    End Class
End Namespace
