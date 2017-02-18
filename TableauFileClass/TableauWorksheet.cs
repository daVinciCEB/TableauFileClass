using System;
namespace TableauFileClass
{
	public class TableauWorksheet
	{
		#region Tableau Worksheet Class Properties
		public string WorksheetName { get; set; }
		#endregion

		#region Tableau Worksheet Class Constructors
		/// <summary>
		/// Create a Tableau Worksheet with a specified name.
		/// </summary>
		/// <param name="sheetname">The specified name for your Tableau worksheet</param>
		public TableauWorksheet(string sheetname)
		{
			WorksheetName = sheetname;
		}
		#endregion
	}
}
