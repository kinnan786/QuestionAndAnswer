using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    HttpCookie cookie;
    int userid = 0;

    public HyperLink Linklogin
    {
        get { return Lnklogin; }
        set { Lnklogin = value; }
    }

    public HyperLink Linkregister
    {
        get { return Lnkregister; }
        set { Lnkregister = value; }
    }

    //public HyperLink LinkHome
    //{
    //    get { return LnkHome; }
    //    set { LnkHome = value; }
    //}

    public HyperLink Linklogout
    {
        get { return Lnklogout; }
        set { Lnklogout = value; }
    }

    public HyperLink LinkAccount
    {
        get { return Lnkprofilepage; }
        set { Lnkprofilepage = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            UpdateMasterPage();
        }
    }

    public void UpdateMasterPage()
    {
        GetCookie();
        if (userid != 0)
        {
            Linklogin.Visible = false;
            Linkregister.Visible = false;
            LinkAccount.Visible = true;
            //LinkHome.Visible = true;
            Linklogout.Visible = true;
        }
        else
        {
            Linklogin.Visible = true;
            Linkregister.Visible = true;
            LinkAccount.Visible = false;
            //LinkHome.Visible = false;
            Linklogout.Visible = false;
        }
    }

    private void GetCookie()
    {
        cookie = this.Request.Cookies["QA"];

        if (cookie != null)
        {
            userid = Convert.ToInt32(cookie["Uid"]);
        }

    }
}
