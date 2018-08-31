using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for QuestionBL
/// </summary>
public class QuestionBL
{
    private QuestionDTO Question;
    private QuestionDAL Questiondal;

	public QuestionBL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public long AddQuestion(QuestionDTO Question)
    {
        Questiondal = new QuestionDAL();
        return Questiondal.AddQuestion(Question);
    }

    public QuestionDTO GetQuestion(long Questionid)
    {
        Questiondal = new QuestionDAL();
        return Questiondal.GetQuestion(Questionid);
    }

    public int UpvoteQuestion(int QuestionId)
    {
        Questiondal = new QuestionDAL();
        return Questiondal.UpvoteQuestion(QuestionId);
    }

    public int DownvoteQuestion(int QuestionId)
    {
        Questiondal = new QuestionDAL();
        return Questiondal.DownvoteQuestion(QuestionId);
    }

    public List<QuestionDTO> GetUserQuestion(int userid, int PageNo, int PageSize)
    {
        Questiondal = new QuestionDAL();
        return Questiondal.GetUserQuestion(userid, PageNo, PageSize);
    }

    public List<QuestionDTO> GetAllQuestion(int pageno, int pagesize)
    {
        Questiondal = new QuestionDAL();
        return Questiondal.GetAllQuestion(pageno, pagesize);
    }
}
