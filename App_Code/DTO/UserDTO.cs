using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserDTO
/// </summary>
public class UserDTO
{
    private string fname;

    public string Fname
    {
        get { return fname; }
        set { fname = value; }
    }
    private string lname;

    public string Lname
    {
        get { return lname; }
        set { lname = value; }
    }
    private string email;

    public string Email
    {
        get { return email; }
        set { email = value; }
    }
    private string password;

    public string Password
    {
        get { return password; }
        set { password = value; }
    }
    private DateTime dOB;

    public DateTime DOB
    {
        get { return dOB; }
        set { dOB = value; }
    }
    private string pic;

    public string Pic
    {
        get { return pic; }
        set { pic = value; }
    }
    private DateTime date;

    public DateTime Date
    {
        get { return date; }
        set { date = value; }
    }

    private string sex;

    public string Sex
    {
        get { return sex; }
        set { sex = value; }
    }

    private int userId;

    public int UserId
    {
        get { return userId; }
        set { userId = value; }
    }


	public UserDTO()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}