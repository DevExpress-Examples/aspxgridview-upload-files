using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Web;
using System.IO;


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            Session.Clear();
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
            string fileName = ASPxGridView1.EditingRowVisibleIndex + e.UploadedFile.FileName;
            string path = "~/Documents/" + fileName;
            e.UploadedFile.SaveAs(Server.MapPath(path), true);
            FileList[ASPxGridView1.EditingRowVisibleIndex].Url = Page.ResolveUrl(path);
            FileList[ASPxGridView1.EditingRowVisibleIndex].FileName = fileName;
            Session["list"] = FileList;
            e.CallbackData = fileName;
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
    }
    protected void ASPxGridView1_CustomErrorText(object sender, ASPxGridViewCustomErrorTextEventArgs e)
    {
        if (e.Exception is CustomExceptions.MyException)
            e.ErrorText = e.Exception.Message;
    }
    protected void ASPxCallback1_Callback(object source, CallbackEventArgs e) {
        string fileName = e.Parameter;
        foreach (MySavedObjects myObj in FileList) {
            if (myObj.FileName == fileName)
                myObj.FileName = myObj.Url = string.Empty;
        }
        File.Delete(Server.MapPath("~/Documents/" + fileName));
        e.Result = "ok";
    }
}