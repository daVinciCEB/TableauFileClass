using System;
namespace TableauFileClass
{
	public class TableauParameter
	{
		#region Tableau Parameter Class Properties
		public string Caption { get; set; }
		public string Name { get; set; }
		public string Role { get; set; }
		public string Type { get; set; }
		public TableauColumnDataType DataType { get; set; }
		public string parameterValue { get; set; }
		public TableauParameterDomainType paramDomainType { get; set; }
		private TableauCalculation calculation;
		#endregion

		#region Tableau Parameter Class Constructors
		/// <summary>
		/// Creates a new Tableau Parameter with the specified details.
		/// </summary>
		/// <param name="paramName">Parameter Name</param>
		/// <param name="paramRole">Parameter Role</param>
		/// <param name="paramType">Parameter Type</param>
		/// <param name="dataType">Parameter Data Type</param>
		/// <param name="domain">Parameter Domain Type</param>
		/// <param name="paramValue">Parameter Value</param>
		public TableauParameter(string paramName, string paramRole, string paramType, TableauColumnDataType dataType, TableauParameterDomainType domain, string paramValue)
		{
			Name = paramName;
			Role = paramRole;
			Type = paramType;
			DataType = dataType;
			parameterValue = paramValue;
			paramDomainType = domain;
			calculation = new TableauCalculation("tableau", parameterValue);
		}

		/// <summary>
		/// Creates a new Tableau Parameter with the specified details.
		/// </summary>
		/// <param name="paramCaption">Parameter Caption</param>
		/// <param name="paramName">Parameter Name</param>
		/// <param name="paramRole">Parameter Role</param>
		/// <param name="paramType">Parameter Type</param>
		/// <param name="dataType">Parameter Data Type</param>
		/// <param name="domain">Parameter Domain Type</param>
		/// <param name="paramValue">Parameter Value</param>
		public TableauParameter(string paramCaption, string paramName, string paramRole, string paramType, TableauColumnDataType dataType, TableauParameterDomainType domain, string paramValue)
		{
			Caption = paramCaption;
			Name = paramName;
			Role = paramRole;
			Type = paramType;
			DataType = dataType;
			parameterValue = paramValue;
			paramDomainType = domain;
			calculation = new TableauCalculation("tableau", parameterValue);
		}
		#endregion
	}
}
