using System;
using System.Collections.Generic;
namespace TableauFileClass
{
	public class TableauDataSource
	{
		#region Tableau Datasource Properties
		public string Name { get; set; }
		public TableauVersion DataSourceVersion { get; set; }
		public List<KeyValuePair<string, string>> DataSourceAttributes { get; set; }
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
