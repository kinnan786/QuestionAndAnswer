using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditInfo : System.Web.UI.Page
{
    private UserDTO userdto;
    private UserBL userbl;
    private int userid;
    private HttpCookie cookie;

    protected void Page_Load(object sender, EventArgs e)
    {
        GetCookie();
        setValues();
    }

    private void setdto()
    {
        userdto = new UserDTO();
        userdto.Fname = TxtFname.Text.ToString();
        userdto.Lname = TxtLname.Text.ToString();
        userdto.Email = TxtEmail.Text.ToString();
        userdto.Password = TxtPass.Text.ToString();
    }

    private void setValues()
    {
        userdto = new UserDTO();
        userbl = new UserBL();

        userdto = userbl.GetUserInfo(userid);
        TxtFname.Text = userdto.Fname.ToString();
        TxtLname.Text = userdto.Lname.ToString();
        TxtEmail.Text = userdto.Email.ToString();
        drlstsex.SelectedValue = userdto.Sex;
    }

    private void GetCookie()
    {
        cookie = this.Request.Cookies["QA"];
        if (cookie != null)
            userid = Convert.ToInt32(cookie["Uid"]);
        else
            Response.Redirect("~/Login.aspx");
    }
}