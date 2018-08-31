using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    UserBL user;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnlogin_Click(object sender, EventArgs e)
    {
        int flag = 0;

        user = new UserBL();
        flag = user.AuthenticateUser(txtemail.Text.ToString(), txtpassword.Text.ToString());

        if (flag != 0)
        {
            HttpCookie cookie = new HttpCookie("QA");
            cookie.Values.Add("Uid", flag.ToString());
            cookie.Values.Add("UserName", txtemail.Text);
            Response.SetCookie(cookie);
            Response.Redirect("~/Home.aspx");
        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }
    }


}