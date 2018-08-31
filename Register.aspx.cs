using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    private UserDTO userdto;
    private UserBL userbl;

    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    protected void BtnRegister_Click(object sender, EventArgs e)
    {
        int userid = 0;

        userbl = new UserBL();
        setdto();
        
        userid = userbl.RegisterUser(userdto);

        if (userid == -1)
        {
            divmessage.Style["display"] = "block";
        }
        else
        {
            HttpCookie cookie = new HttpCookie("QA");
            cookie.Values.Add("Uid", userid.ToString());
            cookie.Values.Add("UserName", TxtEmail.Text);
            Response.SetCookie(cookie);
            Response.Redirect("~/Home.aspx");
        }
    }

    private void setdto()
    {
        userdto = new UserDTO();
        userdto.Fname = TxtFname.Text.ToString();
        userdto.Lname = TxtLname.Text.ToString();
        userdto.Email = TxtEmail.Text.ToString();
        userdto.Password = TxtPass.Text.ToString();
        userdto.DOB = GetDob();
        userdto.Date = DateTime.Now;
        userdto.Sex = drplstsex.SelectedItem.Text;
    }

    private DateTime GetDob()
    {
        int day, year, month;

        day = Convert.ToInt32(drplstday.SelectedItem.Text);
        year = Convert.ToInt32(drplstyear.SelectedItem.Text);
        month = Convert.ToInt32(drplstmonth.SelectedItem.Value);

        string dob = day.ToString() + "/" + month.ToString() + "/" + year.ToString();

        return Convert.ToDateTime(dob);
    }
}