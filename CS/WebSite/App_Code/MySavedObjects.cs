using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;

public class MySavedObjects
{
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