using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            Session.Clear();
    }

    protected void ASPxGridView1_CustomUnboundColumnData(object sender, DevExpress.Web.ASPxGridViewColumnDataEventArgs e)
    {
        if (e.IsGetData)
        {
            if (FileList[e.ListSourceRowIndex].FileName != String.Empty && FileList[e.ListSourceRowIndex].Url != String.Empty)
            {
                ASPxHyperLink hl = ASPxGridView1.FindRowCellTemplateControl(e.ListSourceRowIndex, (GridViewDataColumn)e.Column, "ASPxHyperLink") as ASPxHyperLink;
                hl.Text = FileList[e.ListSourceRowIndex].FileName;
                hl.NavigateUrl = FileList[e.ListSourceRowIndex].Url;
            }
        }
    }

    public List<MySavedObjects> FileList
    {
        get
        {
            List<MySavedObjects> list = Session["list"] as List<MySavedObjects>;
            if (list == null)
            {
                list = new List<MySavedObjects>();
                for (int i = 0; i < ASPxGridView1.VisibleRowCount; i++)
                {
                    list.Add(new MySavedObjects() { RowNumber = i });
                }
                Session["list"] = list;
            }
            return list;
        }
    }
    protected void ASPxUploadControl1_FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
    {
        if (e.IsValid)
        {
            e.UploadedFile.SaveAs(Server.MapPath("~/Documents/" + e.UploadedFile.FileName), true);
            FileList[ASPxGridView1.EditingRowVisibleIndex].Url = Page.ResolveUrl("~/Documents/" + e.UploadedFile.FileName);
            FileList[ASPxGridView1.EditingRowVisibleIndex].FileName = e.UploadedFile.FileName;
            Session["list"] = FileList;
        }
    }

    protected void ASPxHyperLink_Load(object sender, EventArgs e)
    {
        ASPxHyperLink hpl = sender as ASPxHyperLink;
        GridViewDataItemTemplateContainer c = hpl.NamingContainer as GridViewDataItemTemplateContainer;
        if (!String.IsNullOrWhiteSpace(FileList[c.VisibleIndex].FileName) && !String.IsNullOrWhiteSpace(FileList[c.VisibleIndex].Url))
        {
            hpl.Text = FileList[c.VisibleIndex].FileName;
            hpl.NavigateUrl = FileList[c.VisibleIndex].Url;
        }
    }
    protected void ASPxGridView1_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
    {
        throw new CustomExceptions.MyException("Data updates aren't allowed in online examples. Click the Cancel button to check how your file was uploaded."); 
        // you can save files from an nbound column to a database here using e.NewValues 
    }
    protected void ASPxGridView1_CustomErrorText(object sender, ASPxGridViewCustomErrorTextEventArgs e)
    {
        if (e.Exception is CustomExceptions.MyException)
        {
            e.ErrorText = e.Exception.Message;
        }
    }
}