using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddQuestion : System.Web.UI.Page
{
    private QuestionDTO Questiondto;
    private QuestionBL QuestionBl;
    private int Questionid;
    private HttpCookie cookie;
    private int userid;

    protected void Page_Load(object sender, EventArgs e)
    {
        GetCookie();

        if (Request.QueryString["Questionid"] != null)
        {
            QuestionBl = new QuestionBL();
            Questiondto = new QuestionDTO();

            Questionid = Convert.ToInt32(Request.QueryString["Questionid"]);
            Questiondto = QuestionBl.GetQuestion(Questionid);

            TxtTitle.Text = Questiondto.QTitle.ToString();
            TxtDesc.InnerText = Questiondto.QDesc.ToString();
        }
    }

    protected void btnAddQuestion_Click(object sender, EventArgs e)
    {
        QuestionBl = new QuestionBL();
        SetDTO();
        Questionid = Convert.ToInt32( QuestionBl.AddQuestion(Questiondto));
        Response.Redirect("~/ViewQuestion.aspx?questionid="+ Questionid.ToString());
    }

    public void SetDTO()
    {
        Questiondto = new QuestionDTO();
        Questiondto.QTitle = TxtTitle.Text.ToString();
        Questiondto.QDesc = TxtDesc.InnerText.ToString();
        Questiondto.UserId = userid;
        Questiondto.QDate = DateTime.Now;
    }

    private void GetCookie()
    {
        cookie = this.Request.Cookies["QA"];

        if (cookie == null)
            Response.Redirect("~/Login.aspx");
        else
        {
            userid = Convert.ToInt32(cookie["Uid"]);   
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ProfilePage.aspx");
    }
}