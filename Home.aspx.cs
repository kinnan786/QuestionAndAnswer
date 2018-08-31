using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
    QuestionBL questionbl;
    QuestionDTO question;
    List<QuestionDTO> questions;

    #region Private Properties
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

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
         BindItemsList();    
    }

    protected void DataListQuestion_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        question = (QuestionDTO)e.Item.DataItem;

        HyperLink Questionlink = (HyperLink)e.Item.FindControl("lnkQuestionTitle");
        //Label askedon = (Label)e.Item.FindControl("LblAskedon");
        Literal lbdesc = (Literal)e.Item.FindControl("ltrdesc");

        lbdesc.Text = question.QDesc.ToString();
        Questionlink.Text = question.QTitle.ToString();
        Questionlink.NavigateUrl = "~/ViewQuestion.aspx?questionid=" + question.QId.ToString();

        //askedon.Text = question.QTitle;

    }

    private void BindItemsList()
    {
        questionbl = new QuestionBL();
        questions = new List<QuestionDTO>();

        questions = questionbl.GetAllQuestion(CurrentPage, 20);

        if (questions != null)
        {
            ViewState["TotalPages"] = questions[1].TotalPage.ToString();
            
            DataListQuestion.DataSource = questions;
            DataListQuestion.DataBind();

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
}