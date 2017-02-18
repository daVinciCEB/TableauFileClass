using System;
using System.Collections.Generic;
namespace TableauFileClass
{
	public class TableauDataSource
	{
		#region Tableau Datasource Properties
		public string Name { get; set; }
		public TableauVersion DataSourceVersion { get; set; }
		private Dictionary<string, string> DataSourceAttributes = new Dictionary<string, string>();
		#endregion

		#region Tableau Datasource Functions
		/// <summary>
		/// Gets the Tableau Version of the datasource.
		/// </summary>
		/// <returns>The Tableau Version of the data source</returns>
		public string GetTableauVersion()
		{
			switch (DataSourceVersion)
			{
				case TableauVersion.Tableau8:
					return "8.0";
				case TableauVersion.Tableau9:
					return "9.0";
				case TableauVersion.Tableau10:
					return "10.0";
				default:
					return "8.0";
			}
		}

		/// <summary>
		/// Add an attribute to the datasource.
		/// </summary>
		/// <param name="attrName">The specified name for the new datasource attribute</param>
		/// <param name="attrValue">The specified value for the new datasource attribute</param>
		public void AddAttribute(string attrName, string attrValue)
		{
			DataSourceAttributes.Add(attrName, attrValue);
		}

		/// <summary>
		/// Get the names of all the attributes of this datasource.
		/// </summary>
		public List<string> GetAttributeNames()
		{
			List<string> attributeNames = new List<string>();
			foreach (string attr in DataSourceAttributes.Keys)
			{
				attributeNames.Add(attr);
			}
			return attributeNames;
		}

		/// <summary>
		/// Get the value of a specified attribute.
		/// </summary>
		/// <param name="attrName">The specified name for the attribute whose value is being retrieved</param>
		public string GetAttributeValue(string attrName)
		{
			return DataSourceAttributes[attrName];
		}
		#endregion

		#region Tableau Datasource Constructors
		/// <summary>
		/// Create a Tableau Datasource with a specified datasource name and a default version of 8.
		/// </summary>
		/// <param name="datasourcename">The specified name for your Tableau Datasource</param>
		public TableauDataSource(string datasourcename)
		{
			Name = datasourcename;
			DataSourceVersion = TableauVersion.Tableau8;
		}

		/// <summary>
		/// Create a Tableau Datasource with a specified datasource name and version.
		/// </summary>
		/// <param name="datasourcename">The specified name for your Tableau Datasource</param>
		/// <param name="version">The specified Tableau version for your Tableau Datasource</param>
		public TableauDataSource(string datasourcename, TableauVersion version)
		{
			Name = datasourcename;
			DataSourceVersion = version;
		}
		#endregion
	}
}
