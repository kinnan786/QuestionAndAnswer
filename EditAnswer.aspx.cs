using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditAnswer : System.Web.UI.Page
{
    HttpCookie cookie;

    protected void Page_Load(object sender, EventArgs e)
    {
        GetCookie();
    }

    private void GetCookie()
    {
        cookie = this.Request.Cookies["QA"];

        if (cookie == null)
            Response.Redirect("~/Login.aspx");

    }
}