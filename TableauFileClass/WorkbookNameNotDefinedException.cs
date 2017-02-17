using System;
using System.Runtime.Serialization;

namespace TableauFileClass
{
	[Serializable()]
	public class WorkbookNameNotDefinedException : Exception
	{
		private TableauWorkbook UnNamedWorkbook;

		protected WorkbookNameNotDefinedException() : base()
		{
		}

		protected WorkbookNameNotDefinedException(TableauWorkbook workbook) :
		base(String.Format("{0} does not have a workbook name defined", workbook))
		{
			UnNamedWorkbook = workbook;
		}

		public WorkbookNameNotDefinedException(TableauWorkbook workbook, string message) : base(message)
		{
			UnNamedWorkbook = workbook;
		}

		public WorkbookNameNotDefinedException(TableauWorkbook workbook, string message, Exception innerException) :
		base(message, innerException)
		{
			UnNamedWorkbook = workbook;
		}

		protected WorkbookNameNotDefinedException(SerializationInfo info, StreamingContext context) :
		base(info, context)
		{
		}

		public TableauWorkbook NotNamedWorkbook { get { return UnNamedWorkbook; } }
	}
}