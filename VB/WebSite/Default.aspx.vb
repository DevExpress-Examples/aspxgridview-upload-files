' Developer Express Code Central Example:
' ASPxGridView - How to upload .pdf files in Edit mode and see them on a cell click in Browse mode
' 
' This example demonstrates how to implement a custom column with hyperlinks to
' different files. At first, links are empty. You can upload a file in Edit mode,
' and this row hyperlink will contain the URL to this file.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E4644

Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxGridView
Imports DevExpress.Web.ASPxUploadControl

Partial Public Class _Default
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub

	Protected Sub ASPxGridView1_CustomUnboundColumnData(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewColumnDataEventArgs)
		If e.IsGetData Then
			l = TryCast(Session("list"), List(Of MySavedObjects))
			If l IsNot Nothing Then
					If l(e.ListSourceRowIndex).FileName <> String.Empty AndAlso l(e.ListSourceRowIndex).Url <> String.Empty Then
						Dim hl As ASPxHyperLink = TryCast(ASPxGridView1.FindRowCellTemplateControl(e.ListSourceRowIndex, CType(e.Column, GridViewDataColumn), "ASPxHyperLink"), ASPxHyperLink)
						hl.Text = l(e.ListSourceRowIndex).FileName
						hl.NavigateUrl = l(e.ListSourceRowIndex).Url
					End If

			End If
		End If
	End Sub
	Private l As List(Of MySavedObjects)
	Protected Sub ASPxUploadControl1_FileUploadComplete(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxUploadControl.FileUploadCompleteEventArgs)
		If e.IsValid Then
			Dim upc As ASPxUploadControl = TryCast(sender, ASPxUploadControl)
			If e.UploadedFile IsNot Nothing Then
				e.UploadedFile.SaveAs(Server.MapPath("~/Documents/" & e.UploadedFile.FileName), True)
				If ASPxGridView1.IsEditing Then

					l = TryCast(Session("list"), List(Of MySavedObjects))
					If l IsNot Nothing Then
						l(ASPxGridView1.EditingRowVisibleIndex).Url = Page.ResolveUrl("~/Documents/" & e.UploadedFile.FileName)
						l(ASPxGridView1.EditingRowVisibleIndex).FileName = e.UploadedFile.FileName
						Session("list") = l
					End If
				End If
			End If
		End If
	End Sub
	Protected Sub ASPxGridView1_DataBound(ByVal sender As Object, ByVal e As EventArgs)
		If Not IsPostBack Then
			l = New List(Of MySavedObjects)()
			For i As Integer = 0 To ASPxGridView1.VisibleRowCount - 1
				l.Add(New MySavedObjects() With {.RowNumber = i})
			Next i
			Session("list") = l
		End If
	End Sub
	Protected Sub ASPxHyperLink_Load(ByVal sender As Object, ByVal e As EventArgs)
		Dim hpl As ASPxHyperLink = TryCast(sender, ASPxHyperLink)
		Dim c As GridViewDataItemTemplateContainer = TryCast(hpl.NamingContainer, GridViewDataItemTemplateContainer)
		l = TryCast(Session("list"), List(Of MySavedObjects))
		If l(c.VisibleIndex).FileName <> String.Empty AndAlso l(c.VisibleIndex).Url <> String.Empty Then
			hpl.Text = l(c.VisibleIndex).FileName
			hpl.NavigateUrl = l(c.VisibleIndex).Url
		End If

	End Sub
End Class
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