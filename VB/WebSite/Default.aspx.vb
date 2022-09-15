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
		If Not IsPostBack Then
			Session.Clear()
		End If
	End Sub

	Protected Sub ASPxGridView1_CustomUnboundColumnData(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewColumnDataEventArgs)
		If e.IsGetData Then
			If FileList(e.ListSourceRowIndex).FileName <> String.Empty AndAlso FileList(e.ListSourceRowIndex).Url <> String.Empty Then
				Dim hl As ASPxHyperLink = TryCast(ASPxGridView1.FindRowCellTemplateControl(e.ListSourceRowIndex, CType(e.Column, GridViewDataColumn), "ASPxHyperLink"), ASPxHyperLink)
				hl.Text = FileList(e.ListSourceRowIndex).FileName
				hl.NavigateUrl = FileList(e.ListSourceRowIndex).Url
			End If
		End If
	End Sub

	Public ReadOnly Property FileList() As List(Of MySavedObjects)
		Get
			Dim list As List(Of MySavedObjects) = TryCast(Session("list"), List(Of MySavedObjects))
			If list Is Nothing Then
				list = New List(Of MySavedObjects)()
				For i As Integer = 0 To ASPxGridView1.VisibleRowCount - 1
					list.Add(New MySavedObjects() With {.RowNumber = i})
				Next i
				Session("list") = list
			End If
			Return list
		End Get
	End Property
	Protected Sub ASPxUploadControl1_FileUploadComplete(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxUploadControl.FileUploadCompleteEventArgs)
		If e.IsValid Then
			e.UploadedFile.SaveAs(Server.MapPath("~/Documents/" & e.UploadedFile.FileName), True)
			FileList(ASPxGridView1.EditingRowVisibleIndex).Url = Page.ResolveUrl("~/Documents/" & e.UploadedFile.FileName)
			FileList(ASPxGridView1.EditingRowVisibleIndex).FileName = e.UploadedFile.FileName
			Session("list") = FileList
		End If
	End Sub

	Protected Sub ASPxHyperLink_Load(ByVal sender As Object, ByVal e As EventArgs)
		Dim hpl As ASPxHyperLink = TryCast(sender, ASPxHyperLink)
		Dim c As GridViewDataItemTemplateContainer = TryCast(hpl.NamingContainer, GridViewDataItemTemplateContainer)
		If Not String.IsNullOrWhiteSpace(FileList(c.VisibleIndex).FileName) AndAlso Not String.IsNullOrWhiteSpace(FileList(c.VisibleIndex).Url) Then
			hpl.Text = FileList(c.VisibleIndex).FileName
			hpl.NavigateUrl = FileList(c.VisibleIndex).Url
		End If
	End Sub
	Protected Sub ASPxGridView1_RowUpdating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
		Throw New NotImplementedException("Data updates aren't allowed in online examples. Click the Cancel button to check how your file was uploaded.")
		' you can save files from an nbound column to a database here using e.NewValues 
	End Sub
End Class