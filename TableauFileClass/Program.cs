using System;

namespace TableauFileClass
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			TableauWorkbook workbook = new TableauWorkbook();
			workbook.WorkbookName = "Base Workbook";
			workbook.AddExcelTableDataSource("C:/path/to/excel/file.xlsx", "Table", "My new Datasource");
			workbook.SaveWorkbook();
		}
	}
}