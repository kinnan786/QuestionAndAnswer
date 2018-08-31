using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for QAWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class QAWebService : System.Web.Services.WebService {

    QuestionBL questionbl;
    AnswerBL answerbl;
    TagBL tagbl;

    public QAWebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }
   

    [WebMethod]
    public int UpvoteQuestion()
    {
        questionbl = new QuestionBL();
        return questionbl.UpvoteQuestion(1);
    }

    [WebMethod]
    public int DownvoteQuestion(int questionid)
    {
        questionbl = new QuestionBL();
        return questionbl.DownvoteQuestion(questionid);
    }

    [WebMethod]
    public int UpvoteAnswer(int AnswerId)
    {
        answerbl = new AnswerBL();
        return answerbl.UpvoteAnswer(AnswerId);
    }

    [WebMethod]
    public int DownvoteAnswer(int AnswerId)
    {
        answerbl = new AnswerBL();
        return answerbl.DownvoteAnswer(AnswerId);
    }

    [WebMethod(EnableSession = true)]
    public string[] GetTags(string prefixText, int count)
    {
        tagbl = new TagBL();
        return tagbl.GetTags(prefixText,count);
    }

}
