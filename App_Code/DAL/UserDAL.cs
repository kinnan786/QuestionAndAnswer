using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

/// <summary>
/// Summary description for User
/// </summary>
public class UserDAL
{
    private string connectionstring;
    private SqlConnection connection;
    private SqlCommand command;
    private SqlDataReader datareader;
    private UserDTO user;

	public UserDAL()
	{
        connectionstring = ConfigurationManager.ConnectionStrings["QAConnectionString"].ConnectionString.ToString();
        connection = new SqlConnection(connectionstring);
	}

    public int AuthenticateUser(string email, string pass)
    {
        int authenticate = 0;

        command = new SqlCommand(StoredProcedureName.Names.AuthenticateUser.ToString(), connection);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.Add("@Email", SqlDbType.VarChar);
        command.Parameters.Add("@Pass", SqlDbType.VarChar);

        command.Parameters[0].Value = email;
        command.Parameters[1].Value = pass;

        connection.Open();
        authenticate = Convert.ToInt32(command.ExecuteScalar());
        connection.Close();

        return authenticate;
    }

    public int RegisterUser(UserDTO user)
    {
        int userid = 0;

        command = new SqlCommand(StoredProcedureName.Names.RegisterUser.ToString(), connection);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.Add("@Fname", SqlDbType.VarChar);
        command.Parameters.Add("@Lname", SqlDbType.VarChar);
        command.Parameters.Add("@Email", SqlDbType.VarChar);
        command.Parameters.Add("@Password", SqlDbType.VarChar);
        command.Parameters.Add("@DOB", SqlDbType.DateTime);
        command.Parameters.Add("@Pic", SqlDbType.VarChar);
        command.Parameters.Add("@Date", SqlDbType.DateTime);
        command.Parameters.Add("@Sex", SqlDbType.VarChar);

        command.Parameters[0].Value = user.Fname;
        command.Parameters[1].Value = user.Lname;
        command.Parameters[2].Value = user.Email;
        command.Parameters[3].Value = user.Password;
        command.Parameters[4].Value = user.DOB;
        command.Parameters[5].Value = user.Pic;
        command.Parameters[6].Value = user.Date;
        command.Parameters[7].Value = user.Sex;


        connection.Open();
        userid = Convert.ToInt32(command.ExecuteScalar());
        connection.Close();

        return userid;
    }

    public void updateuserinfo(UserDTO user)
    {
        command = new SqlCommand(StoredProcedureName.Names.updateuserinfo.ToString(), connection);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.Add("@Fname", SqlDbType.VarChar);
        command.Parameters.Add("@Lname", SqlDbType.VarChar);
        command.Parameters.Add("@Email", SqlDbType.VarChar);
        command.Parameters.Add("@Password", SqlDbType.VarChar);
        command.Parameters.Add("@Sex", SqlDbType.VarChar);

        command.Parameters[0].Value = user.Fname;
        command.Parameters[1].Value = user.Lname;
        command.Parameters[2].Value = user.Email;
        command.Parameters[3].Value = user.Password;
        command.Parameters[4].Value = user.Sex;

        connection.Open();
        command.ExecuteScalar();
        connection.Close();
    }

    public UserDTO GetUserInfo(int  userid)
    {
        command = new SqlCommand(StoredProcedureName.Names.GetUserInfo.ToString(), connection);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.Add("@UserID", SqlDbType.BigInt);
        command.Parameters[0].Value = userid;

        connection.Open();
        datareader = command.ExecuteReader();

        user = new UserDTO();

        if (!datareader.HasRows)
            return null;
        while (datareader.Read())
        {
            user.Fname = datareader["Fname"].ToString();
            user.Lname = datareader["Lname"].ToString();
            user.Email = datareader["Email"].ToString();
            user.Password = datareader["Password"].ToString();
            user.Sex = datareader["sex"].ToString();
            user.DOB = Convert.ToDateTime(datareader["DOB"]);
        }
        connection.Close();
        return user;
    }
}