using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TagDTO
/// </summary>
public class TagDTO
{

    private int tagId;

    public int TagId
    {
        get { return tagId; }
        set { tagId = value; }
    }
    private string tname;

    public string Tname
    {
        get { return tname; }
        set { tname = value; }
    }
    private string tdesc;

    public string Tdesc
    {
        get { return tdesc; }
        set { tdesc = value; }
    }

	public TagDTO()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}