using System;
using System.Data.SqlClient;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Collections;
using System.IO;
using DTO = IQETools.Common.DataTransferObjects;

namespace IQETools.DataLayer
{
    public class IQEToolsDL
    {
        #region Variable Declaration

        private static string connectionString = string.Empty;
        private static DataSet returnDataSet;

        #endregion

        public static string GetConnectionString(string connectionType, string filePath)
        {
            StringBuilder sbConn = new StringBuilder();
            try
            {
                if (connectionType == ".xls")
                {
                    sbConn = new StringBuilder();
                    sbConn.Append(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=");
                    sbConn.Append(filePath);
                    sbConn.Append(";Extended Properties=");
                    sbConn.Append(Convert.ToChar(34));
                    sbConn.Append("Excel 8.0");
                    sbConn.Append(Convert.ToChar(34));
                    //;HDR=Yes;IMEX=2
                }
                if (connectionType == ".xlsx")
                {
                    sbConn = new StringBuilder();
                    sbConn.Append(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=");
                    sbConn.Append(filePath);
                    sbConn.Append(";Extended Properties='Excel 12.0;HDR=YES;IMEX=1;';");
                    //sbConn.Append(Convert.ToChar(34));
                    //sbConn.Append("Excel 12.0");
                    //sbConn.Append(Convert.ToChar(34));
                    //;HDR=Yes;IMEX=2

                    //return @"Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + filePath + ";" + "Extended Properties=" + "\"" + "Excel 12.0;HDR=YES;IMEX=1;" + "\"";

                    return "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + filePath + ";" + "Extended Properties=Excel 12.0 Xml";

                }
                return sbConn.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool SaveFeatureRequestToXLS(string filePath, string query)
        {
            connectionString = GetConnectionString("xls", filePath);
            returnDataSet = new DataSet();

            OleDbConnection oledbConn = new OleDbConnection(connectionString);
            try
            {
                // Open connection
                oledbConn.Open();
                OleDbCommand objCmd = new OleDbCommand(query, oledbConn);
                objCmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (oledbConn != null)
                {
                    oledbConn.Close();
                    oledbConn.Dispose();
                }
            }
        }

        public static bool SaveDataToXLS(string filePath, string query)
        {
            connectionString = GetConnectionString(Path.GetExtension(filePath), filePath);
            returnDataSet = new DataSet();

            OleDbConnection oledbConn = new OleDbConnection(connectionString);
            try
            {
                // Open connection
                oledbConn.Open();
                OleDbCommand objCmd = new OleDbCommand(query, oledbConn);
                objCmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (oledbConn != null)
                {
                    oledbConn.Close();
                    oledbConn.Dispose();
                }
            }
        }

        /// <summary>
        /// ExecuteQuery
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static DataSet ExecuteXLSQuery(string fileName, string query)
        {
            connectionString = GetConnectionString(Path.GetExtension(fileName), fileName);
            returnDataSet = new DataSet();

            OleDbConnection oledbConn = new OleDbConnection(connectionString);
            try
            {
                // Open connection
                oledbConn.Open();

                // Create OleDbCommand object and select data from worksheet Sheet1
                OleDbCommand cmd = new OleDbCommand(query, oledbConn);

                // Create new OleDbDataAdapter
                OleDbDataAdapter oleda = new OleDbDataAdapter();

                oleda.SelectCommand = cmd;

                // Fill the DataSet from the data extracted from the worksheet.
                oleda.Fill(returnDataSet, "Data");
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                // Close connection
                oledbConn.Close();
            }

            return returnDataSet;
        }

        public static string[] ReadMTDatafromCSV(string filePath, DTO.MTDataDTO data)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                // Read and display lines from the file until the end of 
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    string[] separator = new string[] { "," };
                    string[] splitline = line.Split(separator, StringSplitOptions.None);
                    if (splitline[0] == "Total")
                    {
                        return splitline;
                    }
                }
            }

            return null;

        }

        public static DataTable ReadZStringsfromCSV(string filePath)
        {
            DataTable data = new DataTable();

            data.Columns.Add("StringID");
            data.Columns.Add("Value");

            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                // Read and display lines from the file until the end of 
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    string[] separator = new string[] { "=" };
                    string[] splitline = line.Trim(new char[] { '"' }).Split(separator, StringSplitOptions.None);

                    DataRow dr = data.NewRow();

                    dr[0] = splitline[0].Trim();
                    dr[1] = splitline[1].Trim();

                    data.Rows.Add(dr);
                }
            }

            return data;
        }

        /// <summary>
        /// ReadExcludedZStringsfromCSV
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static DataTable ReadExcludedZStringsfromCSV(string filePath)
        {
            DataTable data = new DataTable();

            //data.Columns.Add("StringID");
            //data.Columns.Add("Value");
            data.Columns.Add("FileRelativePath");
            data.Columns.Add("FileSize");
            data.Columns.Add("ModifiedDate");
            data.Columns.Add("FilePermissions");
            data.Columns.Add("FileMD5Checksum");

            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                // Read and display lines from the file until the end of 
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    if (line != "")
                    {
                        string[] separator = new string[] { "," };
                        string[] splitline = line.Split(separator, StringSplitOptions.None);
                        //string temp = "";

                        if (splitline.Length > 4)
                        {
                            //if (splitline[0].Trim() != "" && splitline[splitline.Length - 3].Trim() != "" && splitline[splitline.Length - 2].Trim() != "" && splitline[splitline.Length - 1].Trim() != "")
                            if (splitline[0].Trim() != "" && splitline[splitline.Length - 4].Trim() != "" && splitline[splitline.Length - 1].Trim() != "")
                            {
                                DataRow dr = data.NewRow();


                                dr[1] = splitline[splitline.Length - 4].Trim();
                                dr[2] = splitline[splitline.Length - 3].Trim();
                                dr[3] = splitline[splitline.Length - 2].Trim();
                                dr[4] = splitline[splitline.Length - 1].Trim();

                                if (splitline.Length == 5)
                                {
                                    dr[0] = splitline[0].Trim();
                                }
                                else
                                {
                                    dr[0] = splitline[0];
                                    for (int counter = 1; counter < splitline.Length - 3; counter++)
                                    {
                                        dr[0] = dr[0] + "," + splitline[counter];
                                    }
                                    dr[0] = dr[0].ToString().Trim();
                                }

                                data.Rows.Add(dr);
                            }
                        }

                        //for (int count = 0; count < splitline.Length; count += 3)
                        //{
                        //    if (count == 0)
                        //    {
                        //        temp = splitline[count + 3].Substring(splitline[count + 3].IndexOf("|"));
                        //    }
                        //    else
                        //    {
                        //        DataRow dr = data.NewRow();

                        //        dr[0] = temp;
                        //        dr[1] = splitline[count + 1].Trim();
                        //        dr[2] = splitline[count + 2].Trim();
                        //        dr[3] = splitline[count + 3].Substring(0, splitline[count + 3].IndexOf("|"));
                        //        temp = splitline[count + 3].Substring(splitline[count + 3].IndexOf("|"));

                        //        data.Rows.Add(dr);
                        //    }
                        //}
                    }
                }
            }

            data.Rows.RemoveAt(0);
            return data;
        }

    }
}
