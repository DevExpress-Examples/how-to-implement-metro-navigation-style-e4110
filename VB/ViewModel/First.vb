Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.Xpf.Core.MvvmSample

Namespace MertopolisNavigationSample.ViewModel
    Public Class First
        Inherits DevExpress.Xpf.Core.MvvmSample.Module
        Public Sub New()
            IsPersistentModule = True
        End Sub
        Public ReadOnly Property FirstList() As IList(Of TestData)
            Get
                Return PopulateFistData.GetData()
            End Get
        End Property
    End Class

    Public NotInheritable Class PopulateFistData
        Private Sub New()
        End Sub
        Public Shared Function GetData() As IList(Of TestData)
            Dim list As IList(Of TestData) = New List(Of TestData)()
            list.Add(New TestData() With {.Name = "One", .Number = 1})
            list.Add(New TestData() With {.Name = "Two", .Number = 2})
            Return list
        End Function
    End Class

    Public Class TestData
        Private privateName As String
        Public Property Name() As String
            Get
                Return privateName
            End Get
            Set(ByVal value As String)
                privateName = value
            End Set
        End Property
        Private privateNumber As Integer
        Public Property Number() As Integer
            Get
                Return privateNumber
            End Get
            Set(ByVal value As Integer)
                privateNumber = value
            End Set
        End Property
    End Class
End Namespace
