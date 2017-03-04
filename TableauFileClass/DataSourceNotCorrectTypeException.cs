using System;
using System.Runtime.Serialization;
namespace TableauFileClass
{
	[Serializable()]
	public class DataSourceNotCorrectTypeException : Exception
	{
		private TableauDataSource incorrectDataSource;
		private string filePath;
		protected DataSourceNotCorrectTypeException() : base()
		{
		}

		protected DataSourceNotCorrectTypeException(TableauDataSource dataSource) :
		base(string.Format("{0} is not the type of datasource specified.", dataSource))
		{
			incorrectDataSource = dataSource;
		}

		public DataSourceNotCorrectTypeException(TableauDataSource dataSource, string message) : base(message)
		{
			incorrectDataSource = dataSource;
		}

		public DataSourceNotCorrectTypeException(string dataSourcePath, string message) : base(message)
		{
			filePath = dataSourcePath;
		}

		public DataSourceNotCorrectTypeException(TableauDataSource dataSource, string message, Exception innerException) :
		base(message, innerException)
		{
			incorrectDataSource = dataSource;
		}

		protected DataSourceNotCorrectTypeException(SerializationInfo info, StreamingContext context) :
		base(info, context)
		{
		}

		public TableauDataSource IncorrectDataSourceType { get { return incorrectDataSource; } }
		public string BadFilePath { get { return filePath; } }
	}
}
