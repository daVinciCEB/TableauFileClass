using System;
namespace TableauFileClass
{
	public class TableauDataRelation
	{
		#region Tableau Data Relation Properties
		public string Name { get; set; }
		public string Table { get; set; }
		public string Type { get; set; }

		#endregion

		#region Tableau Data Relation Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="T:TableauFileClass.TableauDataRelation"/> class.
		/// </summary>
		/// <param name="relName">Data Relation Name.</param>
		/// <param name="relTable">Data Relation Table.</param>
		/// <param name="relType">Data Relation Type.</param>
		public TableauDataRelation(string relName, string relTable, string relType)
		{
			Name = relName;
			Table = relTable;
			Type = relType;
		}
		#endregion
	}
}
