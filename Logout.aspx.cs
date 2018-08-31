using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Logout : System.Web.UI.Page
{
    HttpCookie cookie;

    protected void Page_Load(object sender, EventArgs e)
    {
        DeleteCookie();
    }

    private void DeleteCookie()
    {
        cookie = this.Request.Cookies["QA"];
        cookie.Expires = DateTime.Now.AddYears(-10);
        Response.SetCookie(cookie);
        Response.Redirect("~/Default.aspx");
    }
}