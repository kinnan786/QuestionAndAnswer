using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

/// <summary>
/// Summary description for TagDAL
/// </summary>
public class TagDAL
{
    private string connectionstring;
    private SqlConnection connection;
    private SqlCommand command;
    private SqlDataReader datareader;
    private TagDTO tag;
    private List<TagDTO> Lsttag;


	public TagDAL()
	{
		connectionstring = ConfigurationManager.ConnectionStrings["QAConnectionString"].ConnectionString.ToString();
        connection = new SqlConnection(connectionstring);
	}


    public List<TagDTO> GetTags(string prefixText)
    {
        Lsttag = new List<TagDTO>();

        command = new SqlCommand(StoredProcedureName.Names.GetTag.ToString(), connection);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.Add("@prefixtext", SqlDbType.VarChar);

        command.Parameters[0].Value = prefixText;

        connection.Open();
        datareader = command.ExecuteReader();

        if (!datareader.HasRows)
            return null;
        while (datareader.Read())
        {
            tag = new TagDTO();
            tag.TagId = Convert.ToInt32(datareader["Tid"]);
            tag.Tname = datareader["Tname"].ToString();
            tag.Tdesc = datareader["Tdesc"].ToString();
            Lsttag.Add(tag);
        }
        connection.Close();
        return Lsttag;
    }
}