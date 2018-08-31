using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StoredProcedureNames
/// </summary>
public class StoredProcedureName
{
    public StoredProcedureName()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public enum Names
    {
        //Question
            AddQuestion,
            GetQuestion,
            upvoteQuestion,
            downvoteQuestion,
            GetUserQuestion,
        GetAllQuestion,

        //Answer
            AddAnswer,
            GetAnswer,
            downvoteAnswer,
            upvoteAnswer,
            GetUserAnsweredQuestion,

        //user
            AuthenticateUser,
            RegisterUser,
            updateuserinfo,
            GetUserInfo,

        //Tags 
        GetTag
    }
}