using System;
namespace TableauFileClass
{
	public class TableauCalculation
	{
		#region Tableau Calculation Class Properties
		public string Class { get; set; }
		public string Formula { get; set; }
		#endregion

		#region Tableau Calculation Class Constructors
		public TableauCalculation(string calcClass, string calcFormula)
		{
			Class = calcClass;
			Formula = calcFormula;
		}
		#endregion
	}
}
