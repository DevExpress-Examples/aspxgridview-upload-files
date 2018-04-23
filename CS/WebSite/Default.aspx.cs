// Developer Express Code Central Example:
// ASPxGridView - How to upload .pdf files in Edit mode and see them on a cell click in Browse mode
// 
// This example demonstrates how to implement a custom column with hyperlinks to
// different files. At first, links are empty. You can upload a file in Edit mode,
// and this row hyperlink will contain the URL to this file.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E4644

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxUploadControl;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ASPxGridView1_CustomUnboundColumnData(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewColumnDataEventArgs e)
    {
        if (e.IsGetData)
        {
            l = Session["list"] as List<MySavedObjects>;
            if (l != null)
            {              
                    if (l[e.ListSourceRowIndex].FileName != String.Empty && l[e.ListSourceRowIndex].Url != String.Empty)
                    {
                        ASPxHyperLink hl = ASPxGridView1.FindRowCellTemplateControl(e.ListSourceRowIndex, (GridViewDataColumn)e.Column, "ASPxHyperLink") as ASPxHyperLink;
                        hl.Text = l[e.ListSourceRowIndex].FileName;
                        hl.NavigateUrl = l[e.ListSourceRowIndex].Url;
                    }
                           
            }
        }
    }
    List<MySavedObjects> l;
    protected void ASPxUploadControl1_FileUploadComplete(object sender, DevExpress.Web.ASPxUploadControl.FileUploadCompleteEventArgs e)
    {
        if (e.IsValid)
        {
            ASPxUploadControl upc = sender as ASPxUploadControl;
            if (e.UploadedFile != null)
            {
                e.UploadedFile.SaveAs(Server.MapPath("~/Documents/" + e.UploadedFile.FileName), true);
                if (ASPxGridView1.IsEditing)
                {

                    l = Session["list"] as List<MySavedObjects>;
                    if (l != null)
                    {
                        l[ASPxGridView1.EditingRowVisibleIndex].Url = Page.ResolveUrl("~/Documents/" + e.UploadedFile.FileName);
                        l[ASPxGridView1.EditingRowVisibleIndex].FileName = e.UploadedFile.FileName;
                        Session["list"] = l;
                    }
                }
            }
        }
    }
    protected void ASPxGridView1_DataBound(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            l = new List<MySavedObjects>();
            for (int i = 0; i < ASPxGridView1.VisibleRowCount; i++)
            {
                l.Add(new MySavedObjects() { RowNumber = i});
            }
            Session["list"] = l;
        }
    }
    protected void ASPxHyperLink_Load(object sender, EventArgs e)
    {
        ASPxHyperLink hpl = sender as ASPxHyperLink;
        GridViewDataItemTemplateContainer c = hpl.NamingContainer as GridViewDataItemTemplateContainer;
        l = Session["list"] as List<MySavedObjects>;
        if (l[c.VisibleIndex].FileName != String.Empty && l[c.VisibleIndex].Url != String.Empty)
        {
            hpl.Text = l[c.VisibleIndex].FileName;
            hpl.NavigateUrl = l[c.VisibleIndex].Url;
        }

    }
}
public class MySavedObjects{
    public MySavedObjects()
    {
        _FileName = String.Empty;
        _Url = String.Empty;
    }
    // Fields...
    private string _FileName;
    private string _Url;
    private int _RowNumber;

    public int RowNumber
    {
        get { return _RowNumber; }
        set { _RowNumber = value; }
    }

    public string Url
    {
        get { return _Url; }
        set { _Url = value; }
    }

    public string FileName
    {
        get { return _FileName; }
        set { _FileName = value; }
    }
}