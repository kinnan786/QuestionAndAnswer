using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TagBL
/// </summary>
public class TagBL
{
    private TagDTO Tag;
    private TagDAL tagDAL;

	public TagBL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string[] GetTags(string prefixText, int count)
    {
        tagDAL = new TagDAL();
		string displayStr = "", dataStr="";
		Int16 i = 0;
		List<string> rtn = new List<string>();

		List<object> _dataSource = new List<object>();
        List<TagDTO> lst = tagDAL.GetTags(prefixText);//.GetCPTIntellisense(iPracid, CPTorName);

		if (count == 0 || count > lst.Count)
			count = lst.Count;

        for (i = 0; i < count; i++)
		{			
			displayStr = lst[i].Tname;
			dataStr = lst[i].TagId + "|" + lst[i].Tname;
			rtn.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(displayStr, dataStr));
		}
		return rtn.ToArray();
	}
}