using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using ExtractData.Common.InfrastructureServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace IQETools.UI.Forms
{
    /// <summary>
    /// UploadTestCasesToJIRAFromExcel
    /// </summary>
    public partial class UploadTestCasesToJIRAFromExcel : Form
    {
        #region Variables

        private ExceptionLogger logger;

        private const string START_COMMENT_SYMBOL = "/*";
        private const string END_COMMENT_SYMBOL = "*/";
        private const string SINGLE_COMMENT_SYMBOL = "//";
        private const string STRINGID_IDENTFIIER = "$$$/";

        bool estTime = false;
        #endregion

        #region Constructor

        /// <summary>
        /// UploadTestCasesToJIRAFromExcel
        /// </summary>
        public UploadTestCasesToJIRAFromExcel()
        {
            InitializeComponent();

            logger = new ExceptionLogger();
        }

        #endregion

        #region Button Click

        /// <summary>
        /// ButtonSubmit_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                labelMessage.Text = "Processing File...";
                buttonSubmit.Enabled = false;
                DataTable dtExcelData;

                if (textBoxTestCases.Text.Trim() == "")
                {
                    dtExcelData = IQETools.BusinessLayer.IQEToolsBO.ExecuteXLSQuery(textBoxExcelPath.Text, "Sheet1");

                    //DataRow[] drTestCases = dtExcelData.Select("'Test Type'<>'" + "Internationalization" + "' AND Components='Type'");
                    //DataTable dtTestCases = ConverttoJIRACompatibleColumns(drTestCases.CopyToDataTable());

                    //DataTable dtTimeData = IQETools.BusinessLayer.IQEToolsBO.ExecuteXLSQuery(@"C:\Saurav\IQE\Photoshop\PS Legacy Testcases\Converted\Type_WithEstTime.xlsx", "Sheet1");
                    //DataRow[] drSelectTimeData = dtTimeData.Select("testareaCS5='Type'");
                    //dtTimeData = drSelectTimeData.CopyToDataTable();

                    //dtExcelData.Columns.Add("EstTime");
                    //foreach (DataRow drexcelData in dtExcelData.Rows)
                    //{
                    //    DataRow[] drSelectExcelData = dtTimeData.Select("testtitle='" + drexcelData["testtitle"].ToString() + "' AND RecNo='" + drexcelData["RecNo"].ToString() + "'");
                    //    if (drSelectExcelData.Length != 1)
                    //        drexcelData["EstTime"] = 1;
                    //    else
                    //        drexcelData["EstTime"] = drSelectExcelData[0]["EstTime"].ToString();
                    //}

                    DataTable dtTestCases = ConverttoJIRACompatibleColumns(dtExcelData);


                    DataView dvTestCases = new DataView(dtTestCases);
                    DataTable dtUsers = dvTestCases.ToTable(true, "Assignee");

                    foreach (DataRow drUser in dtUsers.Rows)
                    {

                        DataRow[] drSelectTestCases = dtTestCases.Select("Assignee='" + drUser[0].ToString() + "'");
                        DataTable dtSelectTestCases = drSelectTestCases.CopyToDataTable();

                        DataSet dsJIRAFile = GenerateJIRAFile(dtSelectTestCases);

                        labelMessage.Text = "Generating JIRA Compatible File...";
                        if (IQETools.BusinessLayer.IQEToolsBO.CreateExcelFile(dsJIRAFile.Tables[0], textBoxExcelPath.Text.Replace(".xlsx", "_JIRATC_" + drUser[0].ToString() + ".xlsx")))
                        {
                            labelMessage.Text = "JIRA compatible file Generated successfully.";

                            if (dsJIRAFile.Tables[1].Rows.Count > 0 && IQETools.BusinessLayer.IQEToolsBO.CreateExcelFile(dsJIRAFile.Tables[1], Path.GetDirectoryName(textBoxExcelPath.Text) + @"\Errors.xlsx"))
                                labelMessage.Text = "File Generated successfully but with few errors. For errors, Refer to Errors file at same location ";
                        }

                    }
                    //foreach (DataRow dr in dsJIRAFile.Tables[0].Rows)k
                    //{
                    //    IQETools.BusinessLayer.IQEToolsBO.SaveDataToXLS(, "Sheet1", dr, columns);
                    //}

                    //columns = "";
                    //foreach (DataColumn dc in dsJIRAFile.Tables[1].Columns)
                    //    columns = columns + dc.ColumnName + ", ";
                    //columns = columns.Trim().TrimEnd(new char[] { ',' });
                }
                else
                {
                    string subComponent = "Layers";
                    string user = "efloch";
                    dtExcelData = ConverttoJIRACompatibleColumns(textBoxTestCases.Text, subComponent, user);

                    labelMessage.Text = "Generating JIRA Compatible File...";
                    if (IQETools.BusinessLayer.IQEToolsBO.CreateExcelFile(dtExcelData, textBoxExcelPath.Text.Replace(".xlsx", subComponent + "_JIRATC_" + user + ".xlsx")))
                        labelMessage.Text = "JIRA compatible file Generated successfully.";
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error occurred while generating file: " + ex.ToString();
                logger.WriteToLog("Exception@ {0}: " + ex);
            }
            finally
            {
                buttonSubmit.Enabled = true;
            }
        }

        /// <summary>
        /// GenerateTestCasesFromText
        /// </summary>
        /// <param name="p"></param>
        /// <param name="p_2"></param>
        /// <returns></returns>
        private DataTable ConverttoJIRACompatibleColumns(string testCases, string subComponent, string assignee)
        {
            //string team = "Banana-Stand";
            //string priority = "Normal";
            //string automation = "None";
            //string epicLink = "Copy/Paste layers";
            //string[] testTypes = new String[] { "None", "Acceptance", "Functional", "Integration", "Performance", "Regression", "Security", "Smoke" };

            ////string mapColumn_SubComponent = "testareaCS5";
            //string mapColumn_SubComponent_Area = "subareaCS5";
            //string mapColumn_Summary = "testtitle";
            //string mapColumn_Description = "testtitle";
            //string mapColumn_Step = "test";
            //string mapColumn_Result = "expectedresult";
            //string mapColumn_ManualTestTime = "EstTime";
            //string mapColumn_TestType = "testType";

            DataTable dtJIRATestCases = new DataTable();
            dtJIRATestCases.TableName = "TestCases";
            dtJIRATestCases.Columns.Add("S.No.");
            dtJIRATestCases.Columns.Add("Summary");
            dtJIRATestCases.Columns.Add("Team");
            dtJIRATestCases.Columns.Add("Assignee");
            dtJIRATestCases.Columns.Add("SubComponent");
            dtJIRATestCases.Columns.Add("SubArea");
            dtJIRATestCases.Columns.Add("TestType");
            dtJIRATestCases.Columns.Add("Description");
            dtJIRATestCases.Columns.Add("ManualTestTime");
            dtJIRATestCases.Columns.Add("TestAutomationStatus");
            dtJIRATestCases.Columns.Add("Step");
            dtJIRATestCases.Columns.Add("Result");
            dtJIRATestCases.Columns.Add("Remarks");

            return dtJIRATestCases;
            //int counter = 1;

            //try
            //{
            //    foreach (DataRow drTestCase in dtTestCases.Rows)
            //    {
            //        if (!drTestCase[mapColumn_TestType].ToString().Contains("Internationalization"))
            //        {
            //            DataRow drJIRATestCase = dtJIRATestCases.NewRow();
            //            drJIRATestCase["S.No."] = counter.ToString();
            //            drJIRATestCase["Summary"] = drTestCase[mapColumn_Summary].ToString().Trim();
            //            drJIRATestCase["Team"] = team;
            //            drJIRATestCase["Assignee"] = assignee;
            //            drJIRATestCase["SubComponent"] = subComponent;
            //            drJIRATestCase["SubArea"] = drTestCase[mapColumn_SubComponent_Area].ToString().Trim();

            //            drJIRATestCase["TestType"] = testTypes[0];
            //        }
            //    }
            //}
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// ConverttoJIRACompatibleColumns
        /// </summary>
        /// <param name="excelPath"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        DataTable ConverttoJIRACompatibleColumns(DataTable dtTestCases)
        {
            string team = "";
            string assignee = "smao";
            string automation = "None";
            string subComponent = "Filters";
            string[] testTypes = new String[] { "None", "Acceptance", "Functional", "Integration", "Performance", "Regression", "Security", "Smoke" };
            estTime = false;

            //string mapColumn_SubComponent = "testareaCS5";
            string mapColumn_SubComponent_Area = "subareaCS5";
            string mapColumn_Summary = "testtitle";
            string mapColumn_Description = "testtitle";
            string mapColumn_Step = "test";
            string mapColumn_Result = "expectedresult";
            string mapColumn_ManualTestTime = "EstTime";
            string mapColumn_TestType = "testType";

            DataTable dtJIRATestCases = new DataTable();
            dtJIRATestCases.TableName = "TestCases";
            dtJIRATestCases.Columns.Add("S.No.");
            dtJIRATestCases.Columns.Add("Summary");
            dtJIRATestCases.Columns.Add("Team");
            dtJIRATestCases.Columns.Add("Assignee");
            dtJIRATestCases.Columns.Add("SubComponent");
            dtJIRATestCases.Columns.Add("SubArea");
            dtJIRATestCases.Columns.Add("TestType");
            dtJIRATestCases.Columns.Add("Description");
            //dtJIRATestCases.Columns.Add("EstTime");
            dtJIRATestCases.Columns.Add("ManualTestTime");
            dtJIRATestCases.Columns.Add("TestAutomationStatus");
            dtJIRATestCases.Columns.Add("Step");
            dtJIRATestCases.Columns.Add("Result");
            dtJIRATestCases.Columns.Add("Remarks");

            int counter = 1;

            try
            {
                foreach (DataRow drTestCase in dtTestCases.Rows)
                {
                    if (!drTestCase[mapColumn_TestType].ToString().Contains("Internationalization"))
                    {
                        DataRow drJIRATestCase = dtJIRATestCases.NewRow();
                        drJIRATestCase["S.No."] = counter.ToString();
                        drJIRATestCase["Summary"] = drTestCase[mapColumn_Summary].ToString().Trim();
                        drJIRATestCase["Team"] = team;
                        drJIRATestCase["Assignee"] = assignee;
                        drJIRATestCase["SubComponent"] = subComponent;
                        drJIRATestCase["SubArea"] = drTestCase[mapColumn_SubComponent_Area].ToString().Trim();

                        drJIRATestCase["TestType"] = testTypes[2];

                        foreach (String testType in testTypes)
                            if (drTestCase[mapColumn_TestType].ToString().Contains(testType))
                            {
                                drJIRATestCase["TestType"] = testType;
                                break;
                            }

                        if (drJIRATestCase["Summary"].ToString().Contains(testTypes[1]))
                            drJIRATestCase["TestType"] = testTypes[1];

                        drJIRATestCase["Description"] = drTestCase[mapColumn_Description].ToString().Trim();
                        //drJIRATestCase["EstTime"] = drTestCase[mapColumn_ManualTestTime].ToString();
                        drJIRATestCase["ManualTestTime"] = "0";

                        if (estTime)
                        {
                            if (!((drTestCase[mapColumn_ManualTestTime] == DBNull.Value) || (drTestCase[mapColumn_ManualTestTime].ToString() == "")))
                            {
                                Decimal testTime = Convert.ToDecimal(drTestCase[mapColumn_ManualTestTime].ToString()) * 100;
                                if (testTime < 100)
                                    drJIRATestCase["ManualTestTime"] = Convert.ToInt16(testTime);
                                else
                                    drJIRATestCase["ManualTestTime"] = Convert.ToInt16(testTime / 100) * 60 + (Convert.ToInt16(testTime) - (Convert.ToInt16(testTime / 100) * 100));

                            }
                        }

                        drJIRATestCase["TestAutomationStatus"] = automation;
                        drJIRATestCase["Step"] = drTestCase[mapColumn_Step].ToString().Trim();
                        drJIRATestCase["Result"] = drTestCase[mapColumn_Result].ToString().Trim();

                        dtJIRATestCases.Rows.Add(drJIRATestCase);
                    }
                    counter++;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            if (IQETools.BusinessLayer.IQEToolsBO.CreateExcelFile(dtJIRATestCases, textBoxExcelPath.Text.Replace(".xlsx", "_Interim.xlsx")))
                labelMessage.Text = "JIRA compatible Interim file Generated successfully.";

            return dtJIRATestCases;
            // S.No.,Remarks,Name,Step,Result,Test Data,Externalid,Components,Attributes,Priority,Assignee,Description,Test Type,Team,Test Automation Status
        }

        /// <summary>
        /// GenerateJIRAFile
        /// </summary>
        /// <param name="excelPath"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        DataSet GenerateJIRAFile(DataTable dtJIRAData)
        {
            DataSet ds = new DataSet();
            dtJIRAData.TableName = "JIRA Data";

            DataTable dtErrorRows = new DataTable();

            try
            {
                int ColumnStepOrdinal = dtJIRAData.Columns["Step"].Ordinal;
                int ColumnResultOrdinal = dtJIRAData.Columns["Result"].Ordinal;

                DataColumn ColDesc = dtJIRAData.Columns.Add("JIRA Description");
                ColDesc.SetOrdinal(ColumnStepOrdinal - 1);

                DataColumn ColJIRAStep = dtJIRAData.Columns.Add("JIRA Step");
                ColJIRAStep.SetOrdinal(ColumnStepOrdinal + 2);

                DataColumn ColJIRAResult = dtJIRAData.Columns.Add("JIRA Result");
                ColJIRAResult.SetOrdinal(ColumnResultOrdinal + 2);

                dtErrorRows = dtJIRAData.Clone();
                dtErrorRows.TableName = "Error Data";
                DataColumn error = dtErrorRows.Columns.Add("Error");

                for (int rowCount = 0; rowCount < dtJIRAData.Rows.Count; rowCount++)
                {

                    DataRow drData = dtJIRAData.Rows[rowCount];
                    try
                    {
                        if (drData["Remarks"].ToString() != "")
                        {
                            dtJIRAData.Rows.RemoveAt(rowCount);
                            rowCount--;
                            continue;
                        }

                        string step = drData["Step"].ToString();
                        //step = step.Replace("a)", "1)").Replace("b)", "2)").Replace("c)", "3.)").Replace("d)", "4.)").Replace("e)", "5.)");
                        //step = step.Replace("a.", "1.").Replace("b.", "2.").Replace("c.", "3.)").Replace("d.", "4.)").Replace("e.", "5.)");
                        string result = drData["Result"].ToString();
                        //result = result.Replace("Expected Result Step ", " ");
                        //result = result.Replace("a.", "1.").Replace("b.", "2.").Replace("c.", "3.)").Replace("d.", "4.)").Replace("e.", "5.)");
                        //result = result.Replace("a.)", "1.)").Replace("b.)", "2.)").Replace("c.)", "3.)").Replace("d.)", "4.)").Replace("e.)", "5.)");
                        //result = result.Replace("a)", "1)").Replace("b)", "2)").Replace("c)", "3.)").Replace("d)", "4.)").Replace("e)", "5.)");

                        String[] stepRows = step.Split(new string[] { "\n" }, StringSplitOptions.None);
                        String[] resultRows = result.Split(new string[] { "\n" }, StringSplitOptions.None);

                        DataTable dtStepSplit = new DataTable();
                        dtStepSplit.Columns.Add("Sequence", typeof(System.Int32));
                        dtStepSplit.Columns.Add("Step", typeof(System.String));
                        dtStepSplit.Columns.Add("Result", typeof(System.String));

                        DataRow newRow = dtStepSplit.NewRow();
                        newRow["Sequence"] = "0";
                        newRow["Step"] = "";
                        string seq = "";

                        foreach (string stepBreak in stepRows)
                        {
                            if (stepBreak.Trim() != "" && Char.IsDigit(stepBreak.Trim()[0]))
                            {
                                int digit = Int32.Parse(stepBreak.Trim()[0].ToString());
                                if (Char.IsDigit(stepBreak.Trim()[1]))
                                    digit = Int32.Parse(stepBreak.Trim()[0].ToString() + stepBreak.Trim()[1].ToString());

                                if (digit > Int32.Parse(newRow["Sequence"].ToString()))
                                {
                                    dtStepSplit.Rows.Add(newRow);
                                    newRow = dtStepSplit.NewRow();
                                    newRow["Step"] = "";
                                    seq = digit.ToString();
                                    newRow["Sequence"] = seq;
                                }
                                newRow["Step"] = newRow["Step"] + LineStartTrimming(stepBreak, seq) + Environment.NewLine;
                            }
                            else
                                newRow["Step"] = newRow["Step"] + stepBreak + Environment.NewLine;
                        }

                        dtStepSplit.Rows.Add(newRow);

                        int counter = 0;

                        if (dtStepSplit.Rows.Count == 1)
                        {
                            dtStepSplit.Rows[counter]["Result"] = result;

                            drData["JIRA Step"] = UppercaseFirst(drData["Step"].ToString());
                            drData["JIRA Result"] = UppercaseFirst(drData["Result"].ToString());
                            drData["Description"] = "";
                        }
                        else
                        {

                            foreach (string resultBreak in resultRows)
                            {
                                if (resultBreak.Trim() != "" && Char.IsDigit(resultBreak.Trim()[0]))
                                {
                                    int digit = Int32.Parse(resultBreak.Trim()[0].ToString());
                                    if (Char.IsDigit(resultBreak.Trim()[1]))
                                        digit = Int32.Parse(resultBreak.Trim()[0].ToString() + resultBreak.Trim()[1].ToString());

                                    while (!(Int32.Parse(dtStepSplit.Rows[counter]["Sequence"].ToString()) == digit))
                                    {
                                        counter++;
                                        if (counter > 100 || counter >= dtStepSplit.Rows.Count)
                                            break;
                                    }

                                    if (counter >= dtStepSplit.Rows.Count)
                                        break;

                                    dtStepSplit.Rows[counter]["Result"] = LineStartTrimming(resultBreak, dtStepSplit.Rows[counter]["Sequence"].ToString()) + Environment.NewLine;
                                }
                                else
                                    dtStepSplit.Rows[counter]["Result"] = dtStepSplit.Rows[counter]["Result"] + resultBreak + Environment.NewLine;
                            }

                            if (counter == 0)
                            {
                                dtStepSplit.Rows[dtStepSplit.Rows.Count - 1]["Result"] = dtStepSplit.Rows[0]["Result"];
                                dtStepSplit.Rows[0]["Result"] = "";
                            }

                            if (counter >= dtStepSplit.Rows.Count)
                            {
                                dtStepSplit.Rows[dtStepSplit.Rows.Count - 1]["Result"] = result;
                                for (int tempCounter = 0; tempCounter < dtStepSplit.Rows.Count - 1; tempCounter++)
                                    dtStepSplit.Rows[tempCounter]["Result"] = "";
                            }

                            drData["JIRA Description"] = UppercaseFirst(drData["Description"] + Environment.NewLine + dtStepSplit.Rows[0]["Step"]);

                            for (int stepCounter = 1; stepCounter < dtStepSplit.Rows.Count; stepCounter++)
                            {
                                if (stepCounter == 1)
                                {
                                    drData["JIRA Step"] = UppercaseFirst(TrimEnd(dtStepSplit.Rows[stepCounter]["Step"].ToString().Trim(), Environment.NewLine));
                                    drData["JIRA Result"] = UppercaseFirst(TrimEnd(dtStepSplit.Rows[stepCounter]["Result"].ToString().Trim(), Environment.NewLine));
                                }
                                else
                                {
                                    ++rowCount;
                                    DataRow newStepRow = dtJIRAData.NewRow();
                                    newStepRow["JIRA Step"] = UppercaseFirst(TrimEnd(dtStepSplit.Rows[stepCounter]["Step"].ToString().Trim(), Environment.NewLine));
                                    newStepRow["JIRA Result"] = UppercaseFirst(TrimEnd(dtStepSplit.Rows[stepCounter]["Result"].ToString().Trim(), Environment.NewLine));

                                    dtJIRAData.Rows.InsertAt(newStepRow, rowCount);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        dtErrorRows.Rows.Add(drData.ItemArray);
                        dtErrorRows.Rows[dtErrorRows.Rows.Count - 1]["Error"] = ex.ToString();

                        labelMessage.Text = "Process failed for few Test cases. Please check Error file.";
                    }
                }

                ds.Tables.Add(dtJIRAData.Copy());
                ds.Tables.Add(dtErrorRows.Copy());
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Unexpected Error Occurred: " + ex.ToString();
                throw (ex);
            }

            return ds;
            // S.No.,Remarks,Name,Step,Result,Test Data,Externalid,Components,Attributes,Priority,Assignee,Description,Test Type,Team,Test Automation Status
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        string UppercaseFirst(string s)
        {
            s = s.Trim(Environment.NewLine.ToCharArray());
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            char[] a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }

        /// <summary>
        /// LineStartTrimming
        /// </summary>
        /// <param name="data"></param>
        /// <param name="seq"></param>
        /// <returns></returns>
        string LineStartTrimming(string data, string seq)
        {
            return data.Trim().TrimStart(seq.ToCharArray()).Trim().TrimStart(new char[] { '.' }).TrimStart(new char[] { ')' }).TrimStart(new char[] { '-' });
        }

        /// <summary>
        /// TrimEnd
        /// </summary>
        /// <param name="input"></param>
        /// <param name="suffixToRemove"></param>
        /// <returns></returns>
        public static string TrimEnd(string input, string suffixToRemove)
        {
            if (input != null && suffixToRemove != null
              && input.EndsWith(suffixToRemove))
            {
                return input.Substring(0, input.Length - suffixToRemove.Length);
            }
            else return input;
        }

        #endregion
    }
}
