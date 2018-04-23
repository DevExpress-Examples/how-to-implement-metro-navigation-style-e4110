Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.Xpf.Core.MvvmSample
Imports DevExpress.Xpf.Core.MvvmSample.Helpers
Imports System.Windows.Input

Namespace MertopolisNavigationSample.ViewModel
    Public Class Main
        Inherits MainModule
#Region "Commands"
        Protected Overrides Sub InitializeCommands()
            MyBase.InitializeCommands()
            ShowMainCommand = CreateShowModuleCommand(Of Main)()
            ShowFirstViewCommand = CreateShowModuleCommand(Of First)()
            ShowSecondViewCommand = CreateShowModuleCommand(Of Second)()
        End Sub
        Private privateShowMainCommand As ICommand
        Public Property ShowMainCommand() As ICommand
            Get
                Return privateShowMainCommand
            End Get
            Private Set(ByVal value As ICommand)
                privateShowMainCommand = value
            End Set
        End Property
        Private privateShowFirstViewCommand As ICommand
        Public Property ShowFirstViewCommand() As ICommand
            Get
                Return privateShowFirstViewCommand
            End Get
            Private Set(ByVal value As ICommand)
                privateShowFirstViewCommand = value
            End Set
        End Property
        Private privateShowSecondViewCommand As ICommand
        Public Property ShowSecondViewCommand() As ICommand
            Get
                Return privateShowSecondViewCommand
            End Get
            Private Set(ByVal value As ICommand)
                privateShowSecondViewCommand = value
            End Set
        End Property
#End Region
    End Class
End Namespace
