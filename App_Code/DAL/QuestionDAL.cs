using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

/// <summary>
/// Summary description for QuestionDAL
/// </summary>
public class QuestionDAL
{
    private string connectionstring;
    private SqlConnection connection;
    private SqlCommand command;
    private SqlDataReader datareader;
    private QuestionDTO question;
    private List<QuestionDTO> Lstquestion;


	public QuestionDAL()
	{
        connectionstring = ConfigurationManager.ConnectionStrings["QAConnectionString"].ConnectionString.ToString();
        connection = new SqlConnection(connectionstring);
	}

    public long AddQuestion(QuestionDTO Question)
    {
        command = new SqlCommand(StoredProcedureName.Names.AddQuestion.ToString(), connection);
        command.CommandType = CommandType.StoredProcedure;

        command = new SqlCommand(StoredProcedureName.Names.AddQuestion.ToString(), connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add("@QuestionDesc", SqlDbType.VarChar);
        command.Parameters.Add("@QTitle", SqlDbType.VarChar, 500);
        command.Parameters.Add("@QRate", SqlDbType.Int);
        command.Parameters.Add("@QDate", SqlDbType.DateTime);
        command.Parameters.Add("@UserID", SqlDbType.Int);

        command.Parameters[0].Value = Question.QDesc;
        command.Parameters[1].Value = Question.QTitle;
        command.Parameters[2].Value = Question.Rate;
        command.Parameters[3].Value = Question.QDate;
        command.Parameters[4].Value = Question.UserId;

        long QuestionId = 0;

        connection.Open();
        QuestionId = Convert.ToInt32(command.ExecuteScalar());
        connection.Close();

        return QuestionId;
    }

    public QuestionDTO GetQuestion(long QuestionId)
    {
        command = new SqlCommand(StoredProcedureName.Names.GetQuestion.ToString(), connection);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.Add("@QuestionID", SqlDbType.BigInt);

        command.Parameters[0].Value = QuestionId;

        connection.Open();
        datareader = command.ExecuteReader();

        if (!datareader.HasRows)
            return null;
        while (datareader.Read())
        {
            question = new QuestionDTO();
            question.QDesc = datareader["QDesc"].ToString();
            question.QTitle = datareader["QTitle"].ToString();
            question.Rate = Convert.ToInt32(datareader["Rate"]);
            question.QDate = Convert.ToDateTime(datareader["AskedOn"]);
           
        }
        connection.Close();
        return question;
    }

    public int UpvoteQuestion(int QuestionId)
    {
        int rate = 1;

        command = new SqlCommand(StoredProcedureName.Names.upvoteQuestion.ToString(), connection);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.Add("@QuestionID", SqlDbType.BigInt);

        command.Parameters[0].Value = QuestionId;

        connection.Open();
        rate =  command.ExecuteNonQuery();
        connection.Close();

        return rate;
    }

    public int DownvoteQuestion(int QuestionId)
    {
        int rate = 1;

        command = new SqlCommand(StoredProcedureName.Names.downvoteQuestion.ToString(), connection);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.Add("@QuestionID", SqlDbType.BigInt);

        command.Parameters[0].Value = QuestionId;

        connection.Open();
        rate = command.ExecuteNonQuery();
        connection.Close();

        return rate;
    }

    public List<QuestionDTO> GetUserQuestion(int userid, int PageNo, int PageSize)
    {
        command = new SqlCommand(StoredProcedureName.Names.GetUserQuestion.ToString(), connection);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.Add("@UserID", SqlDbType.BigInt);
        command.Parameters.Add("@PageNo", SqlDbType.BigInt);
        command.Parameters.Add("@PageSize", SqlDbType.BigInt);

        command.Parameters[0].Value = userid;
        command.Parameters[1].Value = PageNo;
        command.Parameters[2].Value = PageSize;

        connection.Open();
        datareader = command.ExecuteReader();

        Lstquestion = new List<QuestionDTO>();

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
            Lstquestion.Add(question);
        }
        connection.Close();
        return Lstquestion;
    }

    public List<QuestionDTO> GetAllQuestion(int pageno, int pagesize)
    {
        command = new SqlCommand(StoredProcedureName.Names.GetAllQuestion.ToString(), connection);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.Add("@PageNo", SqlDbType.BigInt);
        command.Parameters.Add("@PageSize", SqlDbType.BigInt);

        command.Parameters[0].Value = pageno;
        command.Parameters[1].Value = pagesize;

        connection.Open();
        datareader = command.ExecuteReader();

        Lstquestion = new List<QuestionDTO>();

        if (!datareader.HasRows)
            return null;
        while (datareader.Read())
        {
            question = new QuestionDTO();
            question.QId = Convert.ToInt32(datareader["Qid"]);
            question.QTitle = datareader["QTitle"].ToString();
            question.Rate = Convert.ToInt32(datareader["Rate"]);
            question.QDate = Convert.ToDateTime(datareader["AskedOn"]);
            question.QDesc = datareader["QDesc"].ToString();
            question.TotalPage = Convert.ToInt32(datareader["TotalPage"].ToString());
            question.TotalRec = Convert.ToInt32(datareader["TotalRec"].ToString());

            Lstquestion.Add(question);
        }
        connection.Close();
        return Lstquestion;
    }

}