using System;
using System.Xml;
namespace TableauFileClass
{
	public class TableauWorkbookPreference
	{
		#region Tableau Preference Properties
		public string preferenceName { get; set; }
		public string preferenceValue { get; set; }
		#endregion

		#region Tableau Preference Constructors
		/// <summary>
		/// Create a Preference Section for a Tableau Workbook
		/// </summary>
		/// <param name="pname">The name of the preference</param>
		/// <param name="pvalue">The value of the preference</param>
		public TableauWorkbookPreference(string pname, string pvalue)
		{
			preferenceName = pname;
			preferenceValue = pvalue;
		}
		#endregion
	}
}
