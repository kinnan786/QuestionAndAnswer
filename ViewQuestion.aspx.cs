using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.UI.HtmlControls;

public partial class ViewQuestion : System.Web.UI.Page
{
    private QuestionDTO Questiondto;
    private QuestionBL QuestionBl;
    private AnswerDTO Answerdto;
    private AnswerBL AnswerBl;
    private static int Questionid;
    private List<AnswerDTO> lstAnswer;
    private HttpCookie cookie;
    static private int userid = -1;

    protected void Page_Load(object sender, EventArgs e)
    {
        GetCookie();

        if (Request.QueryString["Questionid"] != null)
        {
            Questionid = Convert.ToInt32(Request.QueryString["Questionid"]);

            QuestionBl = new QuestionBL();
            Questiondto = new QuestionDTO();
            AnswerBl = new AnswerBL();
            lstAnswer = new List<AnswerDTO>();

            Questiondto = QuestionBl.GetQuestion(Questionid);

            LblQTitle.Text = Questiondto.QTitle.ToString();
            ltrldesc.Text = Questiondto.QDesc.ToString();
            LblQRate.Text = Questiondto.Rate.ToString();

            lstAnswer = AnswerBl.GetAnswer(Questionid);

            DatalistAnswer.DataSource = lstAnswer;
            DatalistAnswer.DataBind();
        }

        Questionid = Convert.ToInt32(Request.QueryString["Questionid"].ToString());
    }

    protected void btnPostAnswer_Click(object sender, EventArgs e)
    {
        if (cookie != null)
        {
            SetDTO();
            AnswerBl = new AnswerBL();
            AnswerBl.AddAnswer(Answerdto);
            TxtDesc.InnerText = "";
            Response.Redirect("~/ViewQuestion.aspx?questionid=" + Questionid.ToString());
        }
        else
            Response.Redirect("~/Login.aspx");
    }

    public void SetDTO()
    {
        Answerdto = new AnswerDTO();
        Answerdto.UserId = userid;
        Answerdto.MarkAnswer = false;
        Answerdto.Date = DateTime.Now;
        Answerdto.QuestionId = Questionid;
        Answerdto.Answer = TxtDesc.InnerText.ToString();
    }

    protected void DatalistAnswer_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        Answerdto = (AnswerDTO)e.Item.DataItem;

        Label rate = (Label)e.Item.FindControl("LblARate");
        Literal desc = (Literal)e.Item.FindControl("ltrlAnswer");
        ImageButton imgbtnup = (ImageButton)e.Item.FindControl("Aup");
        ImageButton imgbtndown = (ImageButton)e.Item.FindControl("Adown");

        imgbtnup.OnClientClick = "return upvoteanswer('" + Answerdto.Aid.ToString() + "')";
        imgbtndown.OnClientClick = "return downvoteanswer('" + Answerdto.Aid.ToString() + "')";

        rate.Text = Answerdto.Rate.ToString();  
        desc.Text = Answerdto.Answer.ToString();
    }

    [WebMethod(EnableSession = true)]
    public static int UpvoteQuestion()
    {
        if (userid != -1)
        {
            QuestionBL wQuestionBl = new QuestionBL();
            wQuestionBl.UpvoteQuestion(Questionid);
            return 1;
        }
        else
            return 0;

    }

    [WebMethod(EnableSession = true)]
    public static int DownvoteQuestion()
    {
        if (userid != -1)
        {
            QuestionBL wQuestionBl = new QuestionBL();
            wQuestionBl.DownvoteQuestion(Questionid);
            return 1;
        }
        else
            return 0;
    }

    [WebMethod(EnableSession = true)]
    public static int UpvoteAnswer(string answerid)
    {
        if (userid != -1)
        {
            AnswerBL wQuestionBl = new AnswerBL();
            wQuestionBl.UpvoteAnswer(Convert.ToInt32(answerid));
            return 1;
        }
        else
            return 0;
    }

    [WebMethod(EnableSession = true)]
    public static int DownvoteAnswer(int answerid)
    {
        if (userid != -1)
        {
            AnswerBL wQuestionBl = new AnswerBL();
            wQuestionBl.DownvoteAnswer(answerid);
            return 1;
        }
        else
            return 0;
    }

    private void GetCookie()
    {
        cookie = this.Request.Cookies["QA"];
        
        if(cookie != null)
            userid = Convert.ToInt32(cookie["Uid"]);
        
    }
}