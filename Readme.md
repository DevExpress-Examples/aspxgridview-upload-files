<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128536085/15.1.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4644)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# GridView for Web Forms - How to upload files in Edit mode and see them on a click in Browse mode
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e4644/)**
<!-- run online end -->

In this example, the [ASPxGridView](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxGridView)'s [unbound column](https://docs.devexpress.com/AspNet/3732/components/grid-view/concepts/data-representation-basics/columns/unbound-columns) contains hyperlinks ([ASPxHyperLink](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxHyperLink) controls). 

```aspx
 <dx:GridViewDataTextColumn FieldName="Url" UnboundType="Object" VisibleIndex="6">
  <DataItemTemplate>
    <dx:ASPxHyperLink ID="ASPxHyperLink" OnLoad="ASPxHyperLink_Load" runat="server" Target="_blank" Text="No data uploaded">
    </dx:ASPxHyperLink>
  </DataItemTemplate>
  <%--...--%>
</dx:GridViewDataTextColumn>
```

The links are initially empty. The column's [EditItemTemplate](https://docs.devexpress.com/AspNet/DevExpress.Web.GridViewDataColumn.EditItemTemplate) contains [ASPxUploadControl](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxUploadControl), which allows users to upload files in edit mode. 

```aspx
 <dx:GridViewDataTextColumn FieldName="Url" UnboundType="Object" VisibleIndex="6">
  <%--...--%>
  <EditItemTemplate>
    <dx:ASPxUploadControl ID="ASPxUploadControl1" ShowProgressPanel="true" UploadMode="Auto" AutoStartUpload="true" FileUploadMode="OnPageLoad"
        OnFileUploadComplete="ASPxUploadControl1_FileUploadComplete" runat="server">
        <ValidationSettings MaxFileSize="4194304" MaxFileSizeErrorText="Size of the uploaded file exceeds maximum file size" AllowedFileExtensions=".jpg,.jpeg">
        </ValidationSettings>
        <ClientSideEvents FileUploadComplete="OnFileUploadComplete" />
    </dx:ASPxUploadControl>
    <%--...--%>
</EditItemTemplate>
</dx:GridViewDataTextColumn>
```

The link column displays the uploaded image names. Click a name to open the image.

![Grid View - Links in grid](unbound-column-with-links.png)
## Files to Look At
<!-- default file list -->
* [Default.aspx](./CS/Default.aspx) (VB: [Default.aspx](./VB/Default.aspx))
* [Default.aspx.cs](./CS/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/Default.aspx.vb))
<!-- default file list end -->

## Documentation

- [ASPxGridView](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxGridView)
- [Unbound Columns](https://docs.devexpress.com/AspNet/3732/components/grid-view/concepts/data-representation-basics/columns/unbound-columns)

## More Examples

- [GridView for Web Forms - How to upload files in Edit mode and save them in a binary column](https://github.com/DevExpress-Examples/aspxgridview-how-to-upload-files-in-edit-mode-and-save-them-in-a-binary-column-t285123)