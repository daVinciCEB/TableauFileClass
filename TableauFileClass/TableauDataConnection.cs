using System;
using System.Collections.Generic;

namespace TableauFileClass
{
	public class TableauDataConnection
	{
		#region Tableau Data Connection Class Properties
		public string ConnectionClass { get; set; }
		public string ConnectionFileName { get; set; }
		public TableauDataRelation Relation { get; set; }
		private Dictionary<string, string> DataConnectionAttributes = new Dictionary<string, string>();
		#endregion

		#region Tableau Data Connection Class Functions
		/// <summary>
		/// Add an attribute to the data source connection.
		/// </summary>
		/// <param name="attrName">The specified name for the new data source connection attribute</param>
		/// <param name="attrValue">The specified value for the new data source connection attribute</param>
		public void AddAttribute(string attrName, string attrValue)
		{
			DataConnectionAttributes.Add(attrName, attrValue);
		}

		/// <summary>
		/// Get the names of all the attributes of this data source connection.
		/// </summary>
		public List<string> GetAttributeNames()
		{
			List<string> attributeNames = new List<string>();
			foreach (string attr in DataConnectionAttributes.Keys)
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
			return DataConnectionAttributes[attrName];
		}

		#endregion

		#region Tableau Data Connection Class Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="T:TableauFileClass.TableauDataConnection"/> class.
		/// </summary>
		/// <param name="connClass">Connection class.</param>
		/// <param name="connFileName">Connection file name.</param>
		public TableauDataConnection(string connClass, string connFileName)
		{
			ConnectionClass = connClass;
			ConnectionFileName = connFileName;
		}
		#endregion
	}
}
