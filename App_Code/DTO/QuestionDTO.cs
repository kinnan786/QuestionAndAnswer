using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for QuestionDTO
/// </summary>
public class QuestionDTO
{

    private int? qId;

    public int? QId
    {
        get { return qId; }
        set { qId = value; }
    }
    private string qTitle;

    public string QTitle
    {
        get { return qTitle; }
        set { qTitle = value; }
    }
    private string qDesc;

    public string QDesc
    {
        get { return qDesc; }
        set { qDesc = value; }
    }
    private int? rate;

    public int? Rate
    {
        get { return rate; }
        set { rate = value; }
    }
    private DateTime? qDate;

    public DateTime? QDate
    {
        get { return qDate; }
        set { qDate = value; }
    }

    private int userId;

    public int UserId
    {
        get { return userId; }
        set { userId = value; }
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

	public QuestionDTO()
	{
        QId = 0;
        QDesc = "";
        QTitle = "";
        QDate = Convert.ToDateTime("1/1/1753");
        Rate = 0;
        UserId = 0;
        totalPage = 0;
        totalRec = 0;
	}
}