Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Web

Public Class MySavedObjects
    Public Sub New()
        FileName = String.Empty
        Url = String.Empty
    End Sub

    Public Property RowNumber() As Integer

    Public Property Url() As String

    Public Property FileName() As String
End Class