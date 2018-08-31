using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AnswerBL
/// </summary>
public class AnswerBL
{
    private AnswerDTO Answer;
    private AnswerDAL AnswerDal;

	public AnswerBL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public long AddAnswer(AnswerDTO Answer)
    {
        AnswerDal = new AnswerDAL();
        return AnswerDal.AddAnswer(Answer);
    }

    public List<AnswerDTO> GetAnswer(int answerid)
    {
        AnswerDal = new AnswerDAL();
        return AnswerDal.getAnswer(answerid);
    }

    public int UpvoteAnswer(int AnswerId)
    {
        AnswerDal = new AnswerDAL();
        return AnswerDal.UpvoteAnswer(AnswerId);
    }

    public int DownvoteAnswer(int AnswerId)
    {
        AnswerDal = new AnswerDAL();
        return AnswerDal.DownvoteAnswer(AnswerId);
    }

    public List<QuestionDTO> GetUserAnsweredQuestion(long Userid, int PageNo, int PageSize)
    {
        AnswerDal = new AnswerDAL();
        return AnswerDal.GetUserAnsweredQuestion(Userid, PageNo, PageSize);
    }
}