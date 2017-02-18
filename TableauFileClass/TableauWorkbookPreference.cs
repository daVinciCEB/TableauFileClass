using System;
using System.Xml;
namespace TableauFileClass
{
	public class TableauWorkbookPreference
	{
		public string preferenceName { get; set; }
		public string preferenceValue { get; set; }

		public TableauWorkbookPreference()
		{

		}

		public TableauWorkbookPreference(string pname, string pvalue)
		{
			preferenceName = pname;
			preferenceValue = pvalue;
		}
	}
}
