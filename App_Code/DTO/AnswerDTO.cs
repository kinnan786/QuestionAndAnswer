using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AnswerDTO
/// </summary>
public class AnswerDTO
{

    private string answer;

    public string Answer
    {
        get { return answer; }
        set { answer = value; }
    }
    private int rate;

    public int Rate
    {
        get { return rate; }
        set { rate = value; }
    }
    private bool markAnswer;

    public bool MarkAnswer
    {
        get { return markAnswer; }
        set { markAnswer = value; }
    }
    private DateTime date;

    public DateTime Date
    {
        get { return date; }
        set { date = value; }
    }

    private int userId;

    public int UserId
    {
        get { return userId; }
        set { userId = value; }
    }
    private int questionId;

    public int QuestionId
    {
        get { return questionId; }
        set { questionId = value; }
    }
    private int aid;

    public int Aid
    {
        get { return aid; }
        set { aid = value; }
    }

    private int totalPage;

    public int TotalPage
    {
        get { return totalPage; }
        set { totalPage = value; }
    }

    private int totalRec;

    public int TotalRec
    {
        get { return totalRec; }
        set { totalRec = value; }
    }


	public AnswerDTO()
	{
        Answer = "";
        markAnswer = false;
        date = Convert.ToDateTime("1753-01-01");
        rate = 0;
        UserId = 0;
        QuestionId = 0;
        aid = 0;
        totalPage = 0;
        totalRec = 0;
	}
}