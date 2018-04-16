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
        FileName = String.Empty;
        Url = String.Empty;
    }

    public int RowNumber {
        get; set;
    }

    public string Url {
        get; set;
    }

    public string FileName {
        get; set;
    }
}