using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;

namespace TableauFileClass
{
	public class TableauWorkbook
	{
		#region Basic Tableau Workbook Class Properties
		public string WorkbookName { get; set; }
		public string WorkbookPath { get; set; }
		public TableauVersion WorkbookVersion { get; set; }
		public TableauPlatform WorkbookPlatform { get; set; }
		#endregion

		#region Advanced Tableau Workbook Class Properties
		//Preferences section in Tableau Workbook
		private List<TableauWorkbookPreference> preferences = new List<TableauWorkbookPreference>() { new TableauWorkbookPreference("ui.encoding.shelf.height", "250"), new TableauWorkbookPreference("ui.shelf.height", "250") };
		public List<TableauDataSource> datasources = new List<TableauDataSource>();
		public List<TableauWorksheet> worksheets = new List<TableauWorksheet>();
		#endregion

		#region Tableau Workbook Constructors
		/// <summary>
		/// Create a default Tableau workbook with no name or file path, a default version of 8, and a default platform of Windows.
		/// </summary>
		public TableauWorkbook()
		{
			WorkbookVersion = TableauVersion.Tableau8;
			WorkbookPlatform = TableauPlatform.Windows;
		}

		/// <summary>
		/// Create a default Tableau workbook with a specified name, a default version of 8, and a default platform of Windows.
		/// </summary>
		/// <param name="workbookName">The specified name for your Tableau workbook</param>
		public TableauWorkbook(string workbookName)
		{
			WorkbookName = workbookName;
			WorkbookVersion = TableauVersion.Tableau8;
			WorkbookPlatform = TableauPlatform.Windows;
		}

		/// <summary>
		/// Create a default Tableau workbook with a specified name and file path, a default version of 8, and a default platform of Windows.
		/// </summary>
		/// <param name="workbookName">The specified name for your Tableau workbook</param>
		/// <param name="workbookPath">The specified file path for your Tableau workbook</param>
		public TableauWorkbook(string workbookName, string workbookPath)
		{
			WorkbookName = workbookName;
			WorkbookPath = workbookPath;
			WorkbookVersion = TableauVersion.Tableau8;
			WorkbookPlatform = TableauPlatform.Windows;
		}

		/// <summary>
		/// Create a default Tableau workbook with a specified name, file path, version, and a default platform of Windows.
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

		/// <summary>
		/// Create a default Tableau workbook with a specified name, file path, version, and platform.
		/// </summary>
		/// <param name="workbookName">The specified name for your Tableau workbook</param>
		/// <param name="workbookPath">The specified file path for your Tableau workbook</param>
		/// <param name="version">The specified Tableau version for your Tableau workbook</param>
		/// <param name="platform">The specified platform for your Tableau workbook</param>
		public TableauWorkbook(string workbookName, string workbookPath, TableauVersion version, TableauPlatform platform)
		{
			WorkbookName = workbookName;
			WorkbookPath = workbookPath;
			WorkbookVersion = version;
			WorkbookPlatform = platform;
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
			using (XmlWriter writer = XmlWriter.Create(WorkbookName + ".twb"))
			{
				//Start writing XML Document
				writer.WriteStartDocument();
				//Create the base node, which is our workbook node
				writer.WriteStartElement("workbook");
				//Define the Platform in our workbook node
				switch (WorkbookPlatform)
				{
					case TableauPlatform.Windows:
						writer.WriteAttributeString("source-platform", "win");
						break;
					case TableauPlatform.MacOS:
						writer.WriteAttributeString("source-platform", "mac");
						break;
				}
				//Define the Tableau version for our workbook
				writer.WriteAttributeString("version", "8.0");
				//Set up the user value under the xmlns namespace
				writer.WriteAttributeString("xmlns", "user", null, "http://www.tableausoftware.com/xml/user");

				//Write the preferences node to the workbook
				writer.WriteStartElement("preferences");
				//Write each preference in our list here
				foreach (TableauWorkbookPreference preference in preferences)
				{
					writer.WriteStartElement("preference");
					writer.WriteAttributeString("name", preference.preferenceName);
					writer.WriteAttributeString("value", preference.preferenceValue);
					writer.WriteEndElement();
				}
				//Close the preferences node
				writer.WriteEndElement();

				//Write the datasources node to the workbook
				writer.WriteStartElement("datasources");
				//Write each datasource in our list here
				foreach (TableauDataSource datasource in datasources)
				{
					writer.WriteStartElement("datasource");
					writer.WriteEndElement();
				}
				//Close the datasources node
				writer.WriteEndElement();

				//Write the worksheets node to the workbook
				writer.WriteStartElement("worksheets");
				//Write each worksheet in our list here
				foreach (TableauWorksheet worksheet in worksheets)
				{
					writer.WriteStartElement("worksheet");
					writer.WriteAttributeString("name", worksheet.WorksheetName);
					writer.WriteEndElement();
				}
				//Close the datasources node
				writer.WriteEndElement();

				//Close the workbook node
				writer.WriteEndElement();

				//End writing XML Document
				writer.WriteEndDocument();
			}
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
