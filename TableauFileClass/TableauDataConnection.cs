using System;
namespace TableauFileClass
{
	public class TableauDataConnection
	{
		#region Tableau Data Connection Class Properties
		public string ConnectionClass;
		public string ConnectionFileName;
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
