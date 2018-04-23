Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Web

Public Class MySavedObjects
    Public Sub New()
        _FileName = String.Empty
        _Url = String.Empty
    End Sub
    ' Fields...
    Private _FileName As String
    Private _Url As String
    Private _RowNumber As Integer

    Public Property RowNumber() As Integer
        Get
            Return _RowNumber
        End Get
        Set(ByVal value As Integer)
            _RowNumber = value
        End Set
    End Property

    Public Property Url() As String
        Get
            Return _Url
        End Get
        Set(ByVal value As String)
            _Url = value
        End Set
    End Property

    Public Property FileName() As String
        Get
            Return _FileName
        End Get
        Set(ByVal value As String)
            _FileName = value
        End Set
    End Property
End Class