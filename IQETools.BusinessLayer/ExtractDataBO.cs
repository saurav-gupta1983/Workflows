using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO = IQETools.Common.DataTransferObjects;
using DAO = IQETools.DataLayer;
using Excel = Microsoft.Office.Interop.Excel;

namespace IQETools.BusinessLayer
{
    public class IQEToolsBO
    {
        public static bool SaveFeatureRequestDataToXLS(string filePath, DTO.FeatureRequestDTO featureReqDTO)
        {
            if (featureReqDTO.RequestType == "Bug Report")
            {
                return DAO.IQEToolsDL.SaveFeatureRequestToXLS(filePath, DAO.QueryFormation.BugReportQuery("Users reported Bugs", featureReqDTO));
            }
            else
            {
                return DAO.IQEToolsDL.SaveFeatureRequestToXLS(filePath, DAO.QueryFormation.FeatureRequestQuery("Features Requested", featureReqDTO));
            }
        }

        public static bool SaveDataToXLS(string filePath, string sheet, DataRow dr, string cols)
        {
            return DAO.IQEToolsDL.SaveDataToXLS(filePath, DAO.QueryFormation.ExcelWriteDataQuery(sheet, dr, cols));
        }

        public static string[] ReadMTDatafromCSV(string filePath, DTO.MTDataDTO data)
        {
            return DAO.IQEToolsDL.ReadMTDatafromCSV(filePath, data);
        }

        public static DataTable ReadZStringsfromCSV(string filePath)
        {
            return DAO.IQEToolsDL.ReadZStringsfromCSV(filePath);
        }

        public static DataTable ReadExcludedZStringsfromCSV(string filePath)
        {
            return DAO.IQEToolsDL.ReadExcludedZStringsfromCSV(filePath);
        }

        public static DataTable ExecuteXLSQuery(string filePath, string sheetName)
        {
            return DAO.IQEToolsDL.ExecuteXLSQuery(filePath, DAO.QueryFormation.MTDataReadQuery(sheetName)).Tables[0];
        }

        public static bool CreateExcelFile(DataTable dtExcel, string filePath)
        {
            try
            {
                Excel.Application excel = new Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;

                Excel.Workbook workbook = excel.Workbooks.Add(Type.Missing);
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.ActiveSheet;
                worksheet.Name = dtExcel.TableName;

                //worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 8]].Merge();
                //worksheet.Cells[1, 1] = "Student Report Card";
                //worksheet.Cells.Font.Size = 15;

                for (int colCount = 1; colCount <= dtExcel.Columns.Count; colCount++)
                {
                    string colName = dtExcel.Columns[colCount - 1].ColumnName;
                    worksheet.Cells[1, colCount] = colName;
                    //worksheet.Cells.Font.Color = System.Drawing.Color.Black;

                    if (colName == "Name")
                        worksheet.Cells[1, colCount].ColumnWidth = 30;

                    if (colName == "JIRA Description" || colName == "JIRA Step" || colName == "JIRA Result" || colName == "Step" || colName == "Result")
                        worksheet.Cells[1, colCount].ColumnWidth = 50;
                }

                Excel.Range columnHeadingsRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, dtExcel.Columns.Count]];
                columnHeadingsRange.Interior.Color = System.Drawing.Color.SlateGray;
                columnHeadingsRange.Font.Color = System.Drawing.Color.Black;
                columnHeadingsRange.Font.Bold = true;

                int rowcount = 2;

                foreach (DataRow datarow in dtExcel.Rows)
                {
                    try
                    {
                        for (int i = 1; i <= dtExcel.Columns.Count; i++)
                            worksheet.Cells[rowcount, i] = datarow[i - 1].ToString();
                        Console.WriteLine(rowcount);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message.ToString());
                    }

                    rowcount++;
                }

                //worksheet.Cells.Rows.AutoFit();
                //worksheet.Cells.Columns.AutoFit();

                //Excel.Range cellRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[rowcount, dtExcel.Columns.Count]];
                //cellRange.EntireColumn.AutoFit();
                Excel.Borders border = worksheet.Cells.Borders;
                border.LineStyle = Excel.XlLineStyle.xlContinuous;
                border.Weight = 2d;

                //cellRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[2, dtExcel.Columns.Count]];

                workbook.SaveAs(filePath);
                workbook.Close();
                excel.Quit();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return true;
        }
    }
}
