using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

/// <summary>
/// Summary description for AnswerDAL
/// </summary>
public class AnswerDAL
{

    private string connectionstring;
    private SqlConnection connection;
    private SqlCommand command;
    private SqlDataReader datareader;
    private QuestionDTO question;
    private AnswerDTO answer;
    private List<AnswerDTO> LstAnswer;


	public AnswerDAL()
	{
        connectionstring = ConfigurationManager.ConnectionStrings["QAConnectionString"].ConnectionString.ToString();
        connection = new SqlConnection(connectionstring);
	}

    public long AddAnswer(AnswerDTO Answer)
    {
        command = new SqlCommand(StoredProcedureName.Names.AddAnswer.ToString(), connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add("@UserID", SqlDbType.Int);
        command.Parameters.Add("@QuestionID", SqlDbType.Int);
        command.Parameters.Add("@Answer", SqlDbType.VarChar);
        command.Parameters.Add("@rate", SqlDbType.Int);
        command.Parameters.Add("@MarkAnswer", SqlDbType.Bit);
        command.Parameters.Add("@Date", SqlDbType.Date);

        command.Parameters[0].Value = Answer.UserId;
        command.Parameters[1].Value = Answer.QuestionId;
        command.Parameters[2].Value = Answer.Answer;
        command.Parameters[3].Value = Answer.Rate;
        command.Parameters[4].Value = Answer.MarkAnswer;
        command.Parameters[5].Value = Answer.Date;

        long AnswerId = 0;

        connection.Open();
        AnswerId = command.ExecuteNonQuery();
        connection.Close();

        return AnswerId;
    }


    public List<AnswerDTO> getAnswer(long QuestionID)
    {
        LstAnswer = new List<AnswerDTO>();

        command = new SqlCommand(StoredProcedureName.Names.GetAnswer.ToString(), connection);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.Add("@QuestionID", SqlDbType.BigInt);

        command.Parameters[0].Value = QuestionID;

        connection.Open();
        datareader = command.ExecuteReader();

        if (!datareader.HasRows)
            return null;
        while (datareader.Read())
        {
            answer = new AnswerDTO();
            answer.Aid = Convert.ToInt32( datareader["Aid"].ToString());
            answer.Answer = datareader["answer"].ToString();
            answer.Date = Convert.ToDateTime(datareader["Date"]);
            answer.MarkAnswer = Convert.ToBoolean(datareader["Markanswer"]);
            answer.Rate = Convert.ToInt32(datareader["Rate"]);
            LstAnswer.Add(answer);
            
        }
        connection.Close();
        return LstAnswer;
    }

    public int DownvoteAnswer(int AnswerId)
    {
        int rate = 1;

        command = new SqlCommand(StoredProcedureName.Names.downvoteAnswer.ToString(), connection);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.Add("@AnswerID", SqlDbType.BigInt);

        command.Parameters[0].Value = AnswerId;

        connection.Open();
        rate = command.ExecuteNonQuery();
        connection.Close();

        return rate;
    }

    public int UpvoteAnswer(int AnswerId)
    {
        int rate = 1;

        command = new SqlCommand(StoredProcedureName.Names.upvoteAnswer.ToString(), connection);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.Add("@AnswerID", SqlDbType.BigInt);

        command.Parameters[0].Value = AnswerId;

        connection.Open();
        rate = command.ExecuteNonQuery();
        connection.Close();

        return rate;
    }

    public List<QuestionDTO> GetUserAnsweredQuestion(long Userid, int PageNo, int PageSize)
    {
        List<QuestionDTO> lstquestion = new List<QuestionDTO>();

        command = new SqlCommand(StoredProcedureName.Names.GetUserAnsweredQuestion.ToString(), connection);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.Add("@UserId", SqlDbType.BigInt);
        command.Parameters.Add("@PageNo", SqlDbType.BigInt);
        command.Parameters.Add("@PageSize", SqlDbType.BigInt);

        command.Parameters[0].Value = Userid;
        command.Parameters[1].Value = PageNo;
        command.Parameters[2].Value = PageSize;

        connection.Open();
        datareader = command.ExecuteReader();

        if (!datareader.HasRows)
            return null;
        while (datareader.Read())
        {
            question = new QuestionDTO();
            question.QId = Convert.ToInt32(datareader["Qid"]);
            question.QTitle = datareader["QTitle"].ToString();
            question.Rate = Convert.ToInt32(datareader["Rate"]);
            question.QDate = Convert.ToDateTime(datareader["AskedOn"]);
            question.TotalPage = Convert.ToInt32(datareader["TotalPage"].ToString());
            question.TotalRec = Convert.ToInt32(datareader["TotalRec"].ToString());
            lstquestion.Add(question);
        }
        connection.Close();
        return lstquestion;
    }

}