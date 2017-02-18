using System;
using System.IO;
using System.Xml;

namespace TableauFileClass
{
	public class TableauWorkbook
	{
		#region Basic Tableau Workbook Class Properties
		public string WorkbookName { get; set; }
		public string WorkbookPath { get; set; }
		public TableauVersion WorkbookVersion { get; set; }
		#endregion

		#region Advanced Tableau Workbook Class Properties

		#endregion

		#region Class Construstors
		/// <summary>
		/// Create a default Tableau workbook with no name or file path, and a default version of 8.
		/// </summary>
		public TableauWorkbook()
		{
			WorkbookVersion = TableauVersion.Tableau8;
		}

		/// <summary>
		/// Create a default Tableau workbook with a specified name, and a default version of 8.
		/// </summary>
		/// <param name="workbookName">The specified name for your Tableau workbook</param>
		public TableauWorkbook(string workbookName)
		{
			WorkbookName = workbookName;
			WorkbookVersion = TableauVersion.Tableau8;
		}

		/// <summary>
		/// Create a default Tableau workbook with a specified name and file path, and a default version of 8.
		/// </summary>
		/// <param name="workbookName">The specified name for your Tableau workbook</param>
		/// <param name="workbookPath">The specified file path for your Tableau workbook</param>
		public TableauWorkbook(string workbookName, string workbookPath)
		{
			WorkbookName = workbookName;
			WorkbookPath = workbookPath;
			WorkbookVersion = TableauVersion.Tableau8;
		}

		/// <summary>
		/// Create a default Tableau workbook with a specified name, file path, and version.
		/// </summary>
		/// <param name="workbookName">The specified name for your Tableau workbook</param>
		/// <param name="workbookPath">The specified file path for your Tableau workbook</param>
		/// <param name="version">The specified Tableau version for your Tableau workbook</param>
		public TableauWorkbook(string workbookName, string workbookPath, TableauVersion version)
		{
			WorkbookName = workbookName;
			WorkbookPath = workbookPath;
			WorkbookVersion = version;
		}
		#endregion

		#region Save Functions
		/// <summary>
		/// Saves the Tableau Workbook with the specified name, file path, and version.
		/// If a file path has not been specified, then the workbook will be saved in the current folder.
		/// If a Tableau version has not been specified, then the workbook will be saved as a Tableau 8 workbook.
		/// </summary>
		/// <exception>
		/// Thrown if a name has not been defined for the workbook.
		/// </exception>
		public void SaveWorkbook()
		{
			if (!string.IsNullOrWhiteSpace(WorkbookName))
			{
				switch (WorkbookVersion)
				{
					case TableauVersion.Tableau8:
						SaveWorkbookTableau8();
						break;
					case TableauVersion.Tableau9:
						SaveWorkbookTableau9();
						break;
					case TableauVersion.Tableau10:
						SaveWorkbookTableau10();
						break;
					default:
						SaveWorkbookTableau8();
						break;
				}
			}
			else
			{
				throw new WorkbookNameNotDefinedException(this, String.Format("{0} does not have a Workbook Name defined", this));
			}
		}

		private void SaveWorkbookTableau8()
		{
		}

		private void SaveWorkbookTableau9()
		{
		}

		private void SaveWorkbookTableau10()
		{
		}
		#endregion
	}
}
