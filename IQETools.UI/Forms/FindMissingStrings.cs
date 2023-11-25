using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using ExtractData.Common.InfrastructureServices;

namespace IQETools.UI.Forms
{
    /// <summary>
    /// FindMissingStrings
    /// </summary>
    public partial class FindMissingStrings : Form
    {
        #region Variables

        private ExceptionLogger logger;
        private string interimFilePath;

        private const string START_COMMENT_SYMBOL = "/*";
        private const string END_COMMENT_SYMBOL = "*/";
        private const string SINGLE_COMMENT_SYMBOL = "//";
        private const string STRINGID_IDENTFIIER = "$$$/";

        #endregion

        #region Constructor

        /// <summary>
        /// CompileFolderInformationForm
        /// </summary>
        public FindMissingStrings()
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
                DataTable dtMissingStrings = GetMissingStringsDataTable(textBoxMissingStrings.Text);

                string[] file = textBoxResults.Text.Split(new char[] { '\\' });

                interimFilePath = textBoxResults.Text.Replace(file[file.Length - 1], "Interim.csv");

                using (StreamWriter sw = FileStreamInterim(interimFilePath))
                {
                    ReadFilesAndFindStringIDs(sw, textBoxFolderPath.Text);
                }

                WriteResults(FindStrings(interimFilePath, dtMissingStrings));
            }
            catch (Exception ex)
            {
                logger.WriteToLog("Exception@ {0}: " + ex);
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// GetMissingStringsList
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private DataTable GetMissingStringsDataTable(string filePath)
        {
            StreamReader reader = new StreamReader(File.OpenRead(filePath));

            DataTable dtStrings = new DataTable();
            dtStrings.Columns.Add("RecordLocator");
            dtStrings.Columns.Add("StringID");
            dtStrings.Columns.Add("CoreString");

            char listSeparator = CultureInfo.CurrentCulture.TextInfo.ListSeparator[0];
            String line = reader.ReadLine();

            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                String[] columns = line.Split(listSeparator);

                dtStrings.Rows.Add(columns[0], columns[1], columns[2]);
            }

            return dtStrings;
        }

        /// <summary>
        /// ReadFilesAndFindStringIDs
        /// </summary>
        /// <param name="sw"></param>
        /// <param name="folder"></param>
        private void ReadFilesAndFindStringIDs(StreamWriter sw, string folder)
        {
            DirectoryInfo dir = new DirectoryInfo(folder);
            DirectoryInfo[] subDirectories = null;
            FileInfo[] files = null;

            try
            {
                subDirectories = dir.GetDirectories();
                if (subDirectories != null)
                    foreach (DirectoryInfo directory in subDirectories)
                        ReadFilesAndFindStringIDs(sw, folder + @"\" + directory.Name);
            }
            catch (Exception ex)
            {
                logger.WriteToLog("Exception@ {0}: " + ex);
            }

            try
            {
                files = dir.GetFiles();

                if (files != null)
                    foreach (FileInfo file in files)
                    {
                        string path = folder + @"\" + file.Name;

                        if (textBoxIncludeFileTypes.Text != "")
                        {
                            if (!textBoxIncludeFileTypes.Text.Contains(file.Extension))
                                continue;
                        }
                        else if (textBoxExcludeFileTypes.Text != "")
                        {
                            if (textBoxExcludeFileTypes.Text.Contains(file.Extension))
                                continue;
                        }

                        using (StreamReader sr = file.OpenText())
                        {
                            string line = "";
                            bool commentStarted = false;
                            bool lineComment = false;

                            while ((line = sr.ReadLine()) != null)
                            {
                                if (line.Contains(START_COMMENT_SYMBOL))
                                    commentStarted = true;

                                int commentPos = 0;
                                int sepPos = 0;

                                if (line.Contains(STRINGID_IDENTFIIER))
                                {
                                    commentPos = line.IndexOf(SINGLE_COMMENT_SYMBOL);
                                    sepPos = line.IndexOf(STRINGID_IDENTFIIER);

                                    if (commentPos < sepPos && commentPos > -1)
                                        lineComment = true;

                                    WriteToInterimFile(sw, folder, file.Name, (commentStarted || lineComment).ToString(), line);

                                    lineComment = false;
                                }

                                if (line.Contains("*/"))
                                    commentStarted = false;

                                lineComment = false;
                            }
                        }

                    }
            }
            catch (Exception ex)
            {
                logger.WriteToLog("Exception@ {0}: " + ex);
            }

        }

        /// <summary>
        /// ReadAllStringsDetails
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private DataTable ReadAllStringsDetails(string logFilePath)
        {
            StreamReader reader = new StreamReader(File.OpenRead(logFilePath));

            DataTable dtStrings = new DataTable();
            dtStrings.Columns.Add("Path");
            dtStrings.Columns.Add("File");
            dtStrings.Columns.Add("Data");

            while (!reader.EndOfStream)
            {
                String line = reader.ReadLine();
                String[] columns = line.Split(CultureInfo.CurrentCulture.TextInfo.ListSeparator[0]);
                dtStrings.Rows.Add(columns[0], columns[1], line);
            }

            return dtStrings;
        }

        /// <summary>
        /// FileComparison
        /// </summary>
        /// <param name="logFilePath"></param>
        /// <param name="dtMissingStrings"></param>
        private DataTable FindStrings(string logFilePath, DataTable dtMissingStrings)
        {
            DataTable dtList = ReadAllStringsDetails(logFilePath);

            dtMissingStrings.Columns.Add("Path");
            dtMissingStrings.Columns.Add("File");
            dtMissingStrings.Columns.Add("Commented");
            dtMissingStrings.Columns.Add("Data");
            string lineFound = "";

            foreach (DataRow drMissing in dtMissingStrings.Rows)
            {
                foreach (DataRow drList in dtList.Rows)
                {
                    lineFound = drList[2].ToString();
                    if (lineFound.Contains(drMissing[1].ToString()))
                    {
                        drMissing["Path"] = drList[0].ToString();
                        drMissing["File"] = drList[1].ToString();
                        drMissing["Data"] = lineFound;

                        if (lineFound.Contains("TRUE"))
                            drMissing["Commented"] = "TRUE";
                        else
                            drMissing["Commented"] = "FALSE";
                        break;
                    }
                }

            }

            return dtMissingStrings;
        }

        /// <summary>
        /// WriteResults
        /// </summary>
        /// <param name="dtStrings"></param>
        private void WriteResults(DataTable dtList)
        {
            if (File.Exists(textBoxResults.Text))
                File.Delete(textBoxResults.Text);

            using (StreamWriter sw = FileStreamResults(textBoxResults.Text))
            {
                foreach (DataRow dr in dtList.Rows)
                    sw.WriteLine(string.Format("{0},{1},{2}", dr["RecordLocator"], dr["StringID"], dr["Data"]));
            }
        }

        /// <summary>
        /// FileStream
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        private StreamWriter FileStreamInterim(string filePath)
        {
            if (File.Exists(filePath))
                File.Delete(filePath);

            if (!File.Exists(filePath))
            {
                using (StreamWriter sw = File.CreateText(filePath))
                {
                    WriteToInterimFile(sw, "Folder", "File", "Commented", "Line");
                }
            }

            return File.AppendText(filePath);

        }

        /// <summary>
        /// FileStreamResults
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        private StreamWriter FileStreamResults(string filePath)
        {
            if (File.Exists(filePath))
                File.Delete(filePath);

            if (!File.Exists(filePath))
            {
                using (StreamWriter sw = File.CreateText(filePath))
                {
                    WriteToResultsFile(sw, "Record locator", "String ID", "File Path", "File", "Commented", "Data");
                }
            }

            return File.AppendText(filePath);

        }

        /// <summary>
        /// WriteToFile
        /// </summary>
        /// <param name="sw"></param>
        /// <param name="path"></param>
        /// <param name="file"></param>
        /// <param name="data"></param>
        /// <param name="commented"></param>
        private void WriteToInterimFile(StreamWriter sw, string path, string file, string commented, string data)
        {
            try
            {
                sw.WriteLine(string.Format("{0},{1},{2},{3}", path.Replace(textBoxFolderPath.Text + @"\", ""), file, commented, data));
            }
            catch (Exception ex)
            {
                logger.WriteToLog("Exception@ {0}: " + ex);
            }
        }

        /// <summary>
        /// WriteToFile
        /// </summary>
        /// <param name="sw"></param>
        /// <param name="path"></param>
        /// <param name="file"></param>
        /// <param name="data"></param>
        /// <param name="commented"></param>
        private void WriteToResultsFile(StreamWriter sw, string recordLocator, string stringID, string path, string file, string commented, string data)
        {
            try
            {
                sw.WriteLine(string.Format("{0},{1},{2},{3},{4},{5}", recordLocator, stringID, path.Replace(textBoxFolderPath.Text + @"\", ""), file, commented, data));
            }
            catch (Exception ex)
            {
                logger.WriteToLog("Exception@ {0}: " + ex);
            }
        }

        #endregion
    }
}
