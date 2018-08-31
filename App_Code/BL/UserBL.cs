using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserBL
/// </summary>
public class UserBL
{
    private UserDAL userdal;

	public UserBL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int AuthenticateUser(string email, string pass)
    {
        userdal = new UserDAL();
        return userdal.AuthenticateUser(email, pass);
    }

    public int RegisterUser(UserDTO user)
    {
        userdal = new UserDAL();
        return userdal.RegisterUser(user);
    }

    public void updateuserinfo(UserDTO user)
    {
        userdal = new UserDAL();
        userdal.updateuserinfo(user);
    }

    public UserDTO GetUserInfo(int userid)
    {
        userdal = new UserDAL();
        return userdal.GetUserInfo(userid);
    }
}