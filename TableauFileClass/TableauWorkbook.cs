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
		private XmlWriter TableauFileWriter;
		#endregion

		#region Advanced Tableau Workbook Class Properties
		//Preferences section in Tableau Workbook
		private List<TableauWorkbookPreference> preferences = new List<TableauWorkbookPreference>() { new TableauWorkbookPreference("ui.encoding.shelf.height", "250"), new TableauWorkbookPreference("ui.shelf.height", "250") };
		public List<TableauDataSource> datasources = new List<TableauDataSource>();
		public List<TableauWorksheet> worksheets = new List<TableauWorksheet>();
		#endregion

		#region Tableau Workbook Functions
		/// <summary>
		/// Adds an Excel datasource to your Tableau file.
		/// </summary>
		/// <param name="filePath">File path to your Excel file.</param>
		/// <param name="dataSourceName">Data source name.</param>
		public void AddExcelTableDataSource(string filePath, string tableName, string dataSourceName)
		{
			FileInfo excelFile = new FileInfo(filePath);
			if (excelFile.Extension == ".xlsx")
			{
				TableauDataSource excelDataSource = new TableauDataSource(dataSourceName, WorkbookVersion);
				excelDataSource.AddAttribute("inline", "true");
				excelDataSource.DataConnection = new TableauDataConnection("excel-direct", excelFile.FullName);
				excelDataSource.DataConnection.AddAttribute("cleaning", "no");
				excelDataSource.DataConnection.AddAttribute("compat", "no");
				excelDataSource.DataConnection.AddAttribute("dataRefreshTime", "");
				excelDataSource.DataConnection.AddAttribute("validate", "no");
				excelDataSource.DataConnection.Relation = new TableauDataRelation(dataSourceName, "[" + tableName + "$]", "table");
				datasources.Add(excelDataSource);
			}
			else
			{
				throw new DataSourceNotCorrectTypeException(filePath, String.Format("{0} is not an Excel file.", filePath));
			}
		}
		/// <summary>
		/// Adds a parameters section to the Tableau Workbook.
		/// </summary>
		private void AddParametersSection()
		{
			TableauDataSource parameters = new TableauDataSource("Parameters", WorkbookVersion);
			parameters.AddAttribute("hasconnection", "false");
			parameters.AddAttribute("inline", "true");
			datasources.Add(parameters);
		}

		/// <summary>
		/// Adds a specified parameter to the parameters data source.
		/// </summary>
		/// <param name="parameterName">The name of the parameter that is being added</param>
		public void AddParameter(string parameterName)
		{
			if (datasources.Find(ds => ds.Name == "Parameters") == null)
			{
				AddParametersSection();
			}
		}
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
		/// Create a default <see cref="T:TableauFileClass.TableauWorkbook"/> with a specified name, a default version of 8, and a default platform of Windows.
		/// </summary>
		/// <param name="workbookName">The specified name for your Tableau workbook</param>
		public TableauWorkbook(string workbookName)
		{
			WorkbookName = workbookName;
			WorkbookVersion = TableauVersion.Tableau8;
			WorkbookPlatform = TableauPlatform.Windows;
		}

		/// <summary>
		/// Create a default <see cref="T:TableauFileClass.TableauWorkbook"/> with a specified name and file path, a default version of 8, and a default platform of Windows.
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
		/// Create a default <see cref="T:TableauFileClass.TableauWorkbook"/> with a specified name, file path, version, and a default platform of Windows.
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
		/// Create a default <see cref="T:TableauFileClass.TableauWorkbook"/> with a specified name, file path, version, and platform.
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
			using (XmlWriter TableauFileWriter = XmlWriter.Create(WorkbookName + ".twb"))
			{
				//Start writing XML Document
				TableauFileWriter.WriteStartDocument();
				//Create the base node, which is our workbook node
				TableauFileWriter.WriteStartElement("workbook");
				//Define the Platform in our workbook node
				switch (WorkbookPlatform)
				{
					case TableauPlatform.Windows:
						TableauFileWriter.WriteAttributeString("source-platform", "win");
						break;
					case TableauPlatform.MacOS:
						TableauFileWriter.WriteAttributeString("source-platform", "mac");
						break;
				}
				//Define the Tableau version for our workbook
				TableauFileWriter.WriteAttributeString("version", "8.0");
				//Set up the user value under the xmlns namespace
				TableauFileWriter.WriteAttributeString("xmlns", "user", null, "http://www.tableausoftware.com/xml/user");

				//Write the preferences node to the workbook
				TableauFileWriter.WriteStartElement("preferences");
				//Write each preference in our list here
				foreach (TableauWorkbookPreference preference in preferences)
				{
					TableauFileWriter.WriteStartElement("preference");
					TableauFileWriter.WriteAttributeString("name", preference.preferenceName);
					TableauFileWriter.WriteAttributeString("value", preference.preferenceValue);
					TableauFileWriter.WriteEndElement();
				}
				//Close the preferences node
				TableauFileWriter.WriteEndElement();

				//Write the datasources node to the workbook
				TableauFileWriter.WriteStartElement("datasources");
				//Write each datasource in our list here
				foreach (TableauDataSource datasource in datasources)
				{
					TableauFileWriter.WriteStartElement("datasource");
					TableauFileWriter.WriteAttributeString("name", datasource.Name);
					TableauFileWriter.WriteAttributeString("version", datasource.GetTableauVersion());
					foreach (string attr in datasource.GetAttributeNames())
					{
						TableauFileWriter.WriteAttributeString(attr, datasource.GetAttributeValue(attr));
					}
					TableauFileWriter.WriteEndElement();
				}
				//Close the datasources node
				TableauFileWriter.WriteEndElement();

				//Write the worksheets node to the workbook
				TableauFileWriter.WriteStartElement("worksheets");
				//Write each worksheet in our list here
				foreach (TableauWorksheet worksheet in worksheets)
				{
					TableauFileWriter.WriteStartElement("worksheet");
					TableauFileWriter.WriteAttributeString("name", worksheet.WorksheetName);
					TableauFileWriter.WriteEndElement();
				}
				//Close the datasources node
				TableauFileWriter.WriteEndElement();

				//Close the workbook node
				TableauFileWriter.WriteEndElement();

				//End writing XML Document
				TableauFileWriter.WriteEndDocument();
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
