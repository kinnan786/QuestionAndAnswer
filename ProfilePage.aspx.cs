using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProfilePage : System.Web.UI.Page
{
    private HttpCookie cookie;
    private QuestionBL questionbl;
    private QuestionDTO question;
    private AnswerBL answerbl;
    private UserBL userbl;
    private int userid;
    private List<QuestionDTO> questions;
    private UserDTO user;

    private int CurrentPage
    {
        get
        {
            object objPage = ViewState["_CurrentPage"];
            int _CurrentPage = 1;
            if (objPage == null)
            {
                _CurrentPage = 1;
            }
            else
            {
                _CurrentPage = (int)objPage;
            }
            return _CurrentPage;
        }
        set { ViewState["_CurrentPage"] = value; }
    }

    private int ACurrentPage
    {
        get
        {
            object AobjPage = ViewState["_ACurrentPage"];
            int _ACurrentPage = 1;
            if (AobjPage == null)
            {
                _ACurrentPage = 1;
            }
            else
            {
                _ACurrentPage = (int)AobjPage;
            }
            return _ACurrentPage;
        }
        set { ViewState["_ACurrentPage"] = value; }
    }

    private void BindItemsList()
    {
        questionbl = new QuestionBL();

        questions = questionbl.GetUserQuestion(userid, CurrentPage,5);

        if (questions != null)
        {
            ViewState["TotalPages"] = questions[1].TotalPage.ToString();

            DlstQuestion.DataSource = questions;
            DlstQuestion.DataBind();

            this.lblPageInfo.Text = "Page " + (CurrentPage) + " of " + questions[1].TotalPage.ToString();

            if (CurrentPage - 1 == 0)
                lbtnPrevious.Enabled = false;
            else
                lbtnPrevious.Enabled = true;

            if (CurrentPage == Convert.ToInt32(ViewState["TotalPages"]))
                lbtnNext.Enabled = false;
            else
                lbtnNext.Enabled = true;

            if (CurrentPage == 1)
                lbtnFirst.Enabled = false;
            else
                lbtnFirst.Enabled = true;

            if (CurrentPage == Convert.ToInt32(ViewState["TotalPages"]))
                lbtnLast.Enabled = false;
            else
                lbtnLast.Enabled = true;
        }
    }

    private void ABindItemsList()
    {
        answerbl = new AnswerBL();

        questions = answerbl.GetUserAnsweredQuestion(userid, ACurrentPage, 5);

        if (questions != null)
        {
            ViewState["ATotalPages"] = questions[1].TotalPage.ToString();

            datlstAnswer.DataSource = questions;
            datlstAnswer.DataBind();

            this.AlblPageInfo.Text = "Page " + (ACurrentPage) + " of " + questions[1].TotalPage.ToString();

            if (ACurrentPage - 1 == 0)
                AlbtnPrevious.Enabled = false;
            else
                AlbtnPrevious.Enabled = true;

            if (ACurrentPage == Convert.ToInt32(ViewState["ATotalPages"]))
                AlbtnNext.Enabled = false;
            else
                AlbtnNext.Enabled = true;

            if (CurrentPage == 1)
                AlbtnFirst.Enabled = false;
            else
                AlbtnFirst.Enabled = true;

            if (ACurrentPage == Convert.ToInt32(ViewState["ATotalPages"]))
                AlbtnLast.Enabled = false;
            else
                AlbtnLast.Enabled = true;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        GetCookie();
        if (!IsPostBack)
        {
            SetUserInfo();
            BindItemsList();
            ABindItemsList();
        }
    }

    private void SetUserInfo()
    {
        userbl = new UserBL();
        user = userbl.GetUserInfo(userid);
        lblname.Text = user.Fname + " " + user.Lname;
        lblemail.Text = user.Email.ToString();
        lblmale.Text = user.Sex.ToString();
        lblage.Text = user.DOB.ToString();
    }

    private void GetCookie()
    {
        cookie = this.Request.Cookies["QA"];

        if (cookie == null)
            Response.Redirect("~/Login.aspx");
        else
        {
            userid = Convert.ToInt32(cookie["Uid"].ToString());
        }
    }


    protected void DlstQuestion_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        question = (QuestionDTO)e.Item.DataItem;

        HyperLink projectlink = (HyperLink)e.Item.FindControl("lnkQuestionTitle");
        Label Askedon = (Label)e.Item.FindControl("LblAskedon");

        projectlink.Text = question.QTitle.ToString();
        projectlink.NavigateUrl = "~/ViewQuestion.aspx?questionid="+ question.QId.ToString();
        Askedon.Text = question.QDate.ToString();
    }

    protected void datlstAnswer_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        question = (QuestionDTO)e.Item.DataItem;

        HyperLink projectlink = (HyperLink)e.Item.FindControl("lnkQuestionTitle");
        Label Askedon = (Label)e.Item.FindControl("LblAskedon");

        projectlink.Text = question.QTitle.ToString();
        projectlink.NavigateUrl = "~/ViewQuestion.aspx?questionid=" + question.QId.ToString();
        Askedon.Text = question.QDate.ToString();
    }

    protected void lbtnNext_Click(object sender, EventArgs e)
    {
        CurrentPage += 1;
        this.BindItemsList();

    }
    protected void lbtnPrevious_Click(object sender, EventArgs e)
    {
        CurrentPage -= 1;
        this.BindItemsList();

    }

    protected void lbtnLast_Click(object sender, EventArgs e)
    {
        CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]));
        this.BindItemsList();

    }
    protected void lbtnFirst_Click(object sender, EventArgs e)
    {
        CurrentPage = 1;
        this.BindItemsList();
    }

    protected void AlbtnNext_Click(object sender, EventArgs e)
    {
        ACurrentPage += 1;
        this.ABindItemsList();
    }

    protected void AlbtnPrevious_Click(object sender, EventArgs e)
    {
        ACurrentPage -= 1;
        this.ABindItemsList();
    }

    protected void AlbtnLast_Click(object sender, EventArgs e)
    {
        ACurrentPage = (Convert.ToInt32(ViewState["ATotalPages"]));
        this.ABindItemsList();

    }
    protected void AlbtnFirst_Click(object sender, EventArgs e)
    {
        ACurrentPage = 1;
        this.ABindItemsList();
    }
}