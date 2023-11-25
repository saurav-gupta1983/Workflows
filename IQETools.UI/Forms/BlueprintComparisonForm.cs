using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DTO = IQETools.Common.DataTransferObjects;
using BO = IQETools.BusinessLayer;
using System.Configuration;
using System.Xml;

namespace IQETools.UI.Forms
{
    public partial class BlueprintComparisonForm : Form
    {
        #region Variables

        private bool IsVerifyBPFolder = false;
        private bool IsVerifyAgainstBPFolder = false;
        private bool IsEnglishRefRequired = false;
        private bool IsVerifyAgainstAnotherBP = false;
        private bool IsBPDiffFolder = false;

        private DataTable dtResults;

        #endregion

        #region Constructor

        /// <summary>
        /// BlueprintComparisonForm
        /// </summary>
        public BlueprintComparisonForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// BlueprintComparisonForm_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BlueprintComparisonForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToBoolean(ConfigurationManager.AppSettings["CheckXMLPath"]))
                {
                    radioButtonXML.Checked = true;
                }
                else
                {
                    radioButtonFolderFiles.Checked = true;
                }

                EnableXMLFileRadioButton(radioButtonXML.Checked);
                EnableFolderFilesRadioButton(radioButtonFolderFiles.Checked);

                //textBoxEnglishBPRef.Text = ConfigurationManager.AppSettings["EnglishBPRef"];
                textBoxBPDiff.Text = ConfigurationManager.AppSettings["BPDiffPath"];
                textBoxBPResults.Text = ConfigurationManager.AppSettings["BPResults"];
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error: " + ex.Message.ToString() + " has occurred.";
            }
        }

        #endregion

        #region Button Clicks

        /// <summary>
        /// BrowseFolder_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BrowseFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
            }
            textBoxVerifyBP.Text = folderBrowserDialog.SelectedPath; // <-- For debugging use only.
        }

        /// <summary>
        /// buttonVerifyAgainstBrowse_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonVerifyAgainstBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
            }
            textBoxVerifyAgainstPath.Text = folderBrowserDialog.SelectedPath; // <-- For debugging use only.

        }

        /// <summary>
        /// buttonBPDiffBrowse_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBPDiffBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
            }
            textBoxBPDiff.Text = folderBrowserDialog.SelectedPath; // <-- For debugging use only.
        }

        /// <summary>
        /// buttonEnglishRefBrowse_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEnglishRefBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
            }
            textBoxEnglishBPRef.Text = openFileDialog.FileName; // <-- For debugging use only.
        }

        /// <summary>
        /// buttonBPResultsBrowse_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBPResultsBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
            }
            textBoxBPResults.Text = openFileDialog.FileName; // <-- For debugging use only.
        }

        /// <summary>
        /// buttonSubmit_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                labelMessage.Text = "";
                IsVerifyBPFolder = false;
                IsVerifyAgainstBPFolder = false;
                IsEnglishRefRequired = false;
                IsVerifyAgainstAnotherBP = false;
                IsBPDiffFolder = false;
                dtResults = new DataTable();

                dtResults.Columns.Add("File1");
                dtResults.Columns.Add("File2");
                dtResults.Columns.Add("Modified");
                dtResults.Columns.Add("Added");
                dtResults.Columns.Add("Removed");
                dtResults.Columns.Add("NotChanged");
                dtResults.Columns.Add("DiffFile");

                if (!ValidateInputs(textBoxVerifyBP.Text, textBoxVerifyAgainstPath.Text, textBoxEnglishBPRef.Text))
                    return;

                if (!ValidateOutputs(textBoxBPDiff.Text, textBoxBPResults.Text))
                    return;

                labelMessage.Text = "BP Comparison Started...";

                if (radioButtonXML.Checked)
                {
                    XMLDataBPComparison(ConfigurationManager.AppSettings["XMLPath"], ConfigurationManager.AppSettings["VerifyBPBuildNo"], ConfigurationManager.AppSettings["VerifyAgainstBPBuildNo"], ConfigurationManager.AppSettings["EnglishRefBuildNo"]);
                }
                else
                {
                    FileandFoldersDataBPComparison();
                }

                labelMessage.Text = "BP Comparison File is generated successfully.";
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error: " + ex.Message.ToString() + " has occurred.";
            }
        }

        /// <summary>
        /// FileandFoldersDataBPComparison
        /// </summary>
        private void FileandFoldersDataBPComparison()
        {
            if (!IsVerifyBPFolder && !IsVerifyAgainstBPFolder)
            {
                BPComparison(textBoxVerifyBP.Text, textBoxVerifyAgainstPath.Text, textBoxEnglishBPRef.Text, textBoxBPDiff.Text);
            }
            else if (IsVerifyBPFolder)
            {
                DirectoryInfo dir = new DirectoryInfo(textBoxVerifyBP.Text);
                DirectoryInfo[] subdirectories = dir.GetDirectories();

                if (subdirectories.Length > 0)
                {
                    foreach (DirectoryInfo subdir in subdirectories)
                    {
                        FileInfo[] files = subdir.GetFiles();
                        foreach (FileInfo file in files)
                        {
                            if (IsFileCSV(file.Name))
                            {
                                if (IsVerifyAgainstBPFolder)
                                    BPComparison(textBoxVerifyBP.Text + "\\" + subdir.Name + "\\" + file.Name, textBoxVerifyAgainstPath.Text + "\\" + subdir.Name + "\\" + file.Name, textBoxEnglishBPRef.Text, textBoxBPDiff.Text + "\\" + subdir.Name + "_" + file.Name.Replace(".csv", "_Diff.csv"));
                                else
                                    BPComparison(textBoxVerifyBP.Text + "\\" + file.Name, textBoxVerifyAgainstPath.Text, textBoxEnglishBPRef.Text, textBoxBPDiff.Text + "\\" + file.Name.Replace(".csv", "_Diff.csv"));
                            }
                        }
                    }
                }
                else
                {
                    FileInfo[] files = dir.GetFiles();
                    foreach (FileInfo file in files)
                    {
                        if (IsFileCSV(file.Name))
                        {
                            if (IsVerifyAgainstBPFolder)
                                BPComparison(textBoxVerifyBP.Text + "\\" + file.Name, textBoxVerifyAgainstPath.Text + "\\" + file.Name, textBoxEnglishBPRef.Text, textBoxBPDiff.Text + "\\" + file.Name.Replace(".csv", "_Diff.csv"));
                            else
                                BPComparison(textBoxVerifyBP.Text + "\\" + file.Name, textBoxVerifyAgainstPath.Text, textBoxEnglishBPRef.Text, textBoxBPDiff.Text + "\\" + file.Name.Replace(".csv", "_Diff.csv"));
                        }
                    }
                }
            }
            else if (!IsVerifyBPFolder)
            {
                DirectoryInfo dir = new DirectoryInfo(textBoxVerifyAgainstPath.Text);
                FileInfo[] files = dir.GetFiles();

                foreach (FileInfo file in files)
                {
                    if (IsFileCSV(file.Name))
                    {
                        if (IsVerifyAgainstBPFolder)
                            BPComparison(textBoxVerifyBP.Text, textBoxVerifyAgainstPath.Text + "\\" + file.Name, textBoxEnglishBPRef.Text, textBoxBPDiff.Text + "\\" + file.Name.Replace(".csv", "_" + file.Name + "_Diff.csv"));
                    }
                }
            }

            #region Commented
            //if (textBoxVerifyBP.Text.Contains(".csv") && textBoxVerifyAgainstPath.Text.Contains(".csv"))
            //{
            //    #region Comparison of BP files only

            //    if (!textBoxBPDiff.Text.Contains(".csv"))
            //    {
            //        labelMessage.Text = "Export to csv file is only supported";
            //    }
            //    BPComparison(textBoxVerifyBP.Text, textBoxVerifyAgainstPath.Text, textBoxBPDiff.Text);

            //    #endregion
            //}
            //else if (textBoxVerifyBP.Text.Contains(".csv") && !textBoxVerifyAgainstPath.Text.Contains(".csv"))
            //{
            //    #region Comparison of BP files only

            //    if (!textBoxBPDiff.Text.Contains(".csv"))
            //    {
            //        labelMessage.Text = "Export to csv file is only supported";
            //    }
            //    BPComparison(textBoxVerifyBP.Text, textBoxVerifyAgainstPath.Text, textBoxBPDiff.Text);

            //    #endregion
            //}
            //else if (!textBoxVerifyBP.Text.Contains(".csv") && textBoxVerifyAgainstPath.Text.Contains(".csv"))
            //{
            //    #region Comparison of BP files only

            //    if (!textBoxBPDiff.Text.Contains(".csv"))
            //    {
            //        labelMessage.Text = "Export to csv file is only supported";
            //    }
            //    BPComparison(textBoxVerifyBP.Text, textBoxVerifyAgainstPath.Text, textBoxBPDiff.Text);

            //    #endregion
            //}
            //else
            //{
            //    #region Comparison of BP files only

            //    DirectoryInfo dir = new DirectoryInfo(textBoxVerifyBP.Text);
            //    FileInfo[] files = dir.GetFiles();

            //    foreach (FileInfo file in files)
            //    {
            //        if (file.Name.Contains(".csv"))
            //        {
            //            BPComparison(textBoxVerifyBP.Text + "\\" + file.Name, textBoxVerifyAgainstPath.Text + "\\" + file.Name, textBoxBPDiff.Text + "\\" + file.Name.Replace(".csv", "_Diff.csv"));
            //        }
            //    }

            //    #endregion
            //}
            #endregion
        }

        /// <summary>
        /// XMLDataBPComparison
        /// </summary>
        /// <param name="dataXml"></param>
        /// <param name="verifyBPBuildNo"></param>
        /// <param name="verifyAgainstBPBuildNo"></param>
        private void XMLDataBPComparison(string dataXml, string verifyBPBuildNo, string verifyAgainstBPBuildNo, string englishRefBuildNo)
        {
            DataTable dtXmlData = XMLDataTable(dataXml);
            //DataTable dtVerifyAgainstBP = XMLDataTable(dataXml, VerifyAgainstBPBuildNo);

            foreach (DataRow drXmlData in dtXmlData.Rows)
            {
                string verifyBPPath = drXmlData[0].ToString().Replace("Build_No", verifyBPBuildNo);
                string verifyAgainstBPPath = drXmlData[0].ToString().Replace("Build_No", verifyAgainstBPBuildNo);
                string bpDiffPath = textBoxBPDiff.Text + drXmlData[2].ToString();
                string englishBPRef = drXmlData[3].ToString().Replace("Build_No", englishRefBuildNo);

                if (IsFileCSV(verifyBPPath))
                {
                    BPComparison(verifyBPPath, verifyAgainstBPPath, englishBPRef, bpDiffPath + "_Diff.csv");
                }
                else
                {
                    if (IsDirExists(verifyBPPath))
                    //Directory.CreateDirectory(verifyBPPath);
                    {
                        if (!IsDirExists(bpDiffPath))
                            Directory.CreateDirectory(bpDiffPath);

                        DirectoryInfo dir = new DirectoryInfo(verifyBPPath);
                        FileInfo[] files = dir.GetFiles();

                        foreach (FileInfo file in files)
                        {
                            if (IsFileCSV(file.Name))
                            {
                                BPComparison(verifyBPPath + "\\" + file.Name, verifyAgainstBPPath + "\\" + file.Name, GetEnglishBPRefPath(englishBPRef, file.Name), bpDiffPath + "\\" + file.Name.Replace(".csv", "_Diff.csv"));
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// GetEnglishBPRefPath
        /// </summary>
        /// <param name="englishBPRef"></param>
        /// <param name="fileName"></param>
        /// <param name="fileFormat"></param>
        /// <returns></returns>
        private string GetEnglishBPRefPath(string englishBPRef, string fileName)
        {
            if (!IsFileCSV(englishBPRef))
            {
                StringBuilder path = new StringBuilder(englishBPRef + "\\");

                path.Append(fileName.Substring(0, fileName.Length - 9) + ConfigurationManager.AppSettings["EnglishRefLocale"].ToString() + ".csv");

                textBoxEnglishBPRef.Text = path.ToString();

                return path.ToString();
            }

            return englishBPRef;
        }

        /// <summary>
        /// XMLDataTable
        /// </summary>
        /// <param name="dataXml"></param>
        /// <param name="BuildNo"></param>
        /// <returns></returns>
        private DataTable XMLDataTable(string dataXml)
        {
            DataTable dtData = new DataTable();
            dtData.Columns.Add("Path");
            dtData.Columns.Add("FileFormat");
            dtData.Columns.Add("FolderStructure");
            dtData.Columns.Add("EnglishRef");

            DataTable dtTempPath = new DataTable();
            dtTempPath.Columns.Add("Location");

            DataTable dtTempFolderStructure = new DataTable();
            dtTempFolderStructure.Columns.Add("FolderStructure");

            int nodesAdded = 0;
            XmlTextReader xtReader = new XmlTextReader(dataXml);

            string fileType;
            string fileFormat = "";
            string englishRef = "";

            while (xtReader.Read())
            {
                switch (xtReader.NodeType)
                {
                    case XmlNodeType.Element:
                        nodesAdded++;

                        DataRow dr = dtTempPath.NewRow();
                        if (xtReader.Name == "server")
                        {
                            dr[0] = xtReader["Path"];

                            fileType = xtReader["FileType"];
                            fileFormat = xtReader["FileFormat"];

                            if (xtReader["EnglishRef"] != null && xtReader["EnglishRef"] != "")
                                englishRef = xtReader["EnglishRef"];
                        }
                        else
                        {
                            dr[0] = xtReader.Name;

                            if (xtReader.AttributeCount > 0)
                            {
                                if (Convert.ToBoolean(xtReader["CreateFolder"]))
                                {
                                    DataRow drFolderStructure = dtTempFolderStructure.NewRow();
                                    drFolderStructure[0] = dr[0];
                                    dtTempFolderStructure.Rows.Add(drFolderStructure); ;
                                }
                                englishRef = xtReader["EnglishRef"];
                            }
                        }

                        dtTempPath.Rows.Add(dr);

                        break;
                    //Display the end of the element.
                    case XmlNodeType.EndElement:

                        if (nodesAdded > 0)
                        {
                            StringBuilder path = new StringBuilder();
                            foreach (DataRow drPathRow in dtTempPath.Rows)
                            {
                                path.Append("\\" + drPathRow[0]);
                            }

                            DataRow drDataRow = dtData.NewRow();
                            drDataRow[0] = "";
                            drDataRow[0] = path.ToString().Substring(1, path.ToString().Length - 1);
                            drDataRow[1] = fileFormat;

                            foreach (DataRow drDirRow in dtTempFolderStructure.Rows)
                            {
                                drDataRow[2] = drDataRow[2] + "\\" + drDirRow[0];
                            }
                            drDataRow[3] = englishRef;
                            dtData.Rows.Add(drDataRow);
                        }
                        nodesAdded = 0;

                        if (dtTempFolderStructure.Rows.Count > 0 && xtReader.Name.ToString() == (dtTempFolderStructure.Rows[dtTempFolderStructure.Rows.Count - 1][0]).ToString())
                            dtTempFolderStructure.Rows.RemoveAt(dtTempFolderStructure.Rows.Count - 1);

                        dtTempPath.Rows.RemoveAt(dtTempPath.Rows.Count - 1);
                        break;

                    case XmlNodeType.Text:
                        //Response.Write(xtReader.Value);
                        DataRow drAddText = dtTempPath.Rows[dtTempPath.Rows.Count - 1];
                        drAddText[0] = drAddText[0].ToString().Replace("File", xtReader.Value.ToString().Replace("\r", "").Replace("\n", "").Replace(" ", ""));
                        break;

                    //case XmlNodeType.Attribute:
                    //    break;
                    //case XmlNodeType.CDATA:
                    //    break;
                    //case XmlNodeType.Comment:
                    //    break;
                    //case XmlNodeType.Document:
                    //    break;
                    //case XmlNodeType.DocumentFragment:
                    //    break;
                    //case XmlNodeType.DocumentType:
                    //    break;
                    //case XmlNodeType.EndEntity:
                    //    break;
                    //case XmlNodeType.Entity:
                    //    break;
                    //case XmlNodeType.EntityReference:
                    //    break;
                    //case XmlNodeType.None:
                    //    break;
                    //case XmlNodeType.Notation:
                    //    break;
                    //case XmlNodeType.ProcessingInstruction:
                    //    break;
                    //case XmlNodeType.SignificantWhitespace:
                    //    break;
                    //Display the text in each element.
                    default:
                        break;
                }

            }

            return dtData;
        }

        #endregion

        #region Private Functions - Validations

        /// <summary>
        /// ValidateInputs
        /// </summary>
        /// <param name="p"></param>
        /// <param name="p_2"></param>
        /// <param name="p_3"></param>
        /// <returns></returns>
        private bool ValidateInputs(string inputVerifyBP, string inputVerifyAgainstBP, string inputEngRef)
        {
            labelMessage.Text = "Validation Started...";

            if (radioButtonFolderFiles.Checked)
            {
                if (inputVerifyBP == "")
                {
                    labelMessage.Text = "Specify the File to be verified.";
                    return false;
                }

                if (inputVerifyAgainstBP == "" && inputEngRef == "")
                {
                    labelMessage.Text = "Specify atleast one file to be verified against.";
                    return false;
                }

                if (inputEngRef != "")
                    IsEnglishRefRequired = true;
                if (inputVerifyAgainstBP != "")
                    IsVerifyAgainstAnotherBP = true;

                if (!IsFileCSV(inputVerifyBP))
                    IsVerifyBPFolder = true;
                if (!IsFileCSV(inputVerifyAgainstBP))
                    IsVerifyAgainstBPFolder = true;

                if (IsVerifyBPFolder && !IsDirExists(inputVerifyBP))
                {
                    labelMessage.Text = "The directory doesn't exist for Verify BP Path or file is not .CSV";
                    return false;
                }

                if (IsVerifyAgainstBPFolder && !IsDirExists(inputVerifyAgainstBP))
                {
                    labelMessage.Text = "The directory doesn't exist for Verify Against BP Path or file is not .CSV";
                    return false;
                }

                if (inputEngRef != "" && !IsFileCSV(inputEngRef))
                {
                    labelMessage.Text = "The English Ref File must be a csv file"; ;
                    return false;
                }
            }

            return true;

        }

        /// <summary>
        /// ValidateOutputs
        /// </summary>
        /// <param name="inputVerifyBP"></param>
        /// <param name="outputBPDiff"></param>
        /// <param name="outputBPResults"></param>
        /// <returns></returns>
        private bool ValidateOutputs(string outputBPDiff, string outputBPResults)
        {
            if (outputBPDiff == "")
            {
                labelMessage.Text = "Specify the Output BP Diff File Path.";
                return false;
            }

            if (!IsFileCSV(outputBPResults))
            {
                labelMessage.Text = "The Output BP Results file must be .CSV";
                return false;
            }

            if (IsVerifyBPFolder || IsVerifyAgainstBPFolder || radioButtonXML.Checked)
            {
                if (IsDirExists(outputBPDiff))
                    IsBPDiffFolder = true;
                else
                {
                    labelMessage.Text = "The BF Diff Path must be a directory.";
                    return false;
                }
            }
            else
            {
                if (!IsFileCSV(outputBPDiff))
                {
                    labelMessage.Text = "The Output BP Diff file must be .CSV";
                    return false;
                }
            }

            if (!IsBPDiffFolder && !IsFileCSV(outputBPResults))
            {
                labelMessage.Text = "The directory doesn't exist for BP Diff Path or file is not .CSV";
                return false;
            }

            return true;
        }

        /// <summary>
        /// IsFileCSV
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private bool IsFileCSV(string fileName)
        {
            //return fileName.Contains(".csv");
            return (fileName.LastIndexOf(".csv") == fileName.Length - 4);
        }

        /// <summary>
        /// IsDirExists
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private bool IsDirExists(string directory)
        {
            return Directory.Exists(directory);
        }

        #endregion

        #region Private Functions - BP Comparison

        /// <summary>
        /// BPComparison
        /// </summary>
        /// <param name="fileNameVerifyBP"></param>
        /// <param name="fileNameVerifyAgainstBP"></param>
        /// <param name="fileNameBPDiff"></param>
        private void BPComparison(string fileNameVerifyBP, string fileNameVerifyAgainstBP, string fileNameEnglishBPRef, string fileNameBPDiff)
        {
            bool IsVerifyAgainstAnotherBP = true;

            DataRow dr = dtResults.NewRow();
            dr[0] = fileNameVerifyBP;

            DataTable dtVerifyBP = ReadBPFiles(fileNameVerifyBP);
            DataTable dtVerifyAgainstBP = null;

            if (IsVerifyAgainstAnotherBP)
                if (File.Exists(fileNameVerifyAgainstBP))
                    dtVerifyAgainstBP = ReadBPFiles(fileNameVerifyAgainstBP);
                else
                    IsVerifyAgainstAnotherBP = false;

            if (IsVerifyAgainstAnotherBP)
            {
                DataTable dtEnglishBPRef = null;
                if (File.Exists(fileNameEnglishBPRef))
                {
                    dtEnglishBPRef = ReadBPFiles(fileNameEnglishBPRef);
                    textBoxEnglishBPRef.Text = fileNameEnglishBPRef;
                }
                else
                {
                    if (textBoxEnglishBPRef.Text != "" && !textBoxEnglishBPRef.Text.Contains("English Ref File doesn't exist."))
                    {
                        textBoxEnglishBPRef.Text = "English Ref File doesn't exist. (" + textBoxEnglishBPRef.Text + ")";
                    }
                }

                DataTable dtBPDiff = PerformComparison(dtVerifyBP, dtVerifyAgainstBP, dtEnglishBPRef);

                WriteBPDiff(dtBPDiff, fileNameBPDiff);

                if (textBoxEnglishBPRef.Text == "")
                    dr[1] = fileNameVerifyAgainstBP;
                else
                    dr[1] = fileNameVerifyAgainstBP + " / " + textBoxEnglishBPRef.Text;

                dr[2] = dtBPDiff.Select("Status = 'Modified'").Length;
                dr[3] = dtBPDiff.Select("Status = 'Added'").Length;
                dr[4] = dtBPDiff.Select("Status = 'Removed'").Length;
                dr[5] = dtBPDiff.Select("Status = 'NoChange'").Length;
                //            dr[5] = dtBPDiff.Rows.Count - (Convert.ToInt32(dr[2].ToString()) + Convert.ToInt32(dr[3].ToString()) + Convert.ToInt32(dr[4].ToString()));
                dr[6] = fileNameBPDiff;
            }
            else
            {
                dr[1] = "The file doesn't exist in previous build";
            }

            dtResults.Rows.Add(dr);
            WriteBPResults(dtResults, textBoxBPResults.Text);
        }

        /// <summary>
        /// PerformComparison
        /// </summary>
        /// <param name="dtVerifyBP"></param>
        /// <param name="dtVerifyAgainstBP"></param>
        /// <returns></returns>
        private DataTable PerformComparison(DataTable dtVerifyBP, DataTable dtVerifyAgainstBP, DataTable dtEnglishBPRef)
        {
            DataTable data = null;

            if (dtVerifyAgainstBP == null)
                data = CreateDiffFile(dtVerifyBP, dtEnglishBPRef);
            else
            {
                data = CreateDiffFile(dtVerifyBP, dtVerifyAgainstBP);

                #region Find Files common in English

                if (dtEnglishBPRef != null)
                {
                    foreach (DataRow dr in data.Rows)
                    {
                        DataRow[] dataRow = dtEnglishBPRef.Select("FileRelativePath = '" + dr[0].ToString().Replace("'", "''") + "'");

                        if (dataRow.Length == 1)
                        {
                            DataRow drEnglishBPRef = dataRow[0];

                            if (dr["Status"].ToString() != "Removed")
                            {
                                if ((Convert.ToInt32(drEnglishBPRef["FileSize"].ToString()) == Convert.ToInt32(dr["NewFileSize"].ToString())) && (drEnglishBPRef["ModifiedDate"].ToString() == dr["ModifiedDate"].ToString()) && (drEnglishBPRef["FilePermissions"].ToString() == dr["NewFilePermissions"].ToString()) || (drEnglishBPRef["FileMD5Checksum"].ToString() == dr["NewFileMD5Checksum"].ToString()))
                                    dr[1] = "NoChange";
                                else
                                {
                                    dr[2] = (Convert.ToInt32(dr["NewFileSize"].ToString()) - Convert.ToInt32(drEnglishBPRef["FileSize"].ToString())).ToString();

                                    if (drEnglishBPRef["ModifiedDate"].ToString() == dr["ModifiedDate"].ToString())
                                        dr[3] = "Same as English";
                                    else
                                        dr[3] = "Diff from English";

                                    if (drEnglishBPRef["FilePermissions"].ToString() == dr["NewFilePermissions"].ToString())
                                        dr[4] = "Same as English";
                                    else
                                        dr[4] = "Diff from English";

                                    if (drEnglishBPRef["FileMD5Checksum"].ToString() == dr["NewFileMD5Checksum"].ToString())
                                        dr[5] = "Same as English";
                                    else
                                        dr[5] = "Diff from English";
                                }
                            }
                        }
                    }

                    /*
                    foreach (DataRow drEnglishBPRef in dtEnglishBPRef.Rows)
                    {
                        DataRow[] dataRow = data.Select("FileRelativePath = '" + drEnglishBPRef[0].ToString().Replace("'", "''") + "'");

                        if (dataRow.Length == 1)
                        {
                            DataRow dr = dataRow[0];

                            if (dr["Status"].ToString() != "Removed")
                            {
                                if ((Convert.ToInt32(drEnglishBPRef["FileSize"].ToString()) == Convert.ToInt32(dr["NewFileSize"].ToString())) && (drEnglishBPRef["ModifiedDate"].ToString() == dr["ModifiedDate"].ToString()) && (drEnglishBPRef["FilePermissions"].ToString() == dr["NewFilePermissions"].ToString()) || (drEnglishBPRef["FileMD5Checksum"].ToString() == dr["NewFileMD5Checksum"].ToString()))
                                    dr[1] = "NoChange";
                                else
                                {
                                    dr[2] = (Convert.ToInt32(dr["NewFileSize"].ToString()) - Convert.ToInt32(drEnglishBPRef["FileSize"].ToString())).ToString();

                                    if (drEnglishBPRef["ModifiedDate"].ToString() == dr["ModifiedDate"].ToString())
                                        dr[3] = "Same as English";
                                    else
                                        dr[3] = "Diff from English";

                                    if (drEnglishBPRef["FilePermissions"].ToString() == dr["NewFilePermissions"].ToString())
                                        dr[4] = "Same as English";
                                    else
                                        dr[4] = "Diff from English";

                                    if (drEnglishBPRef["FileMD5Checksum"].ToString() == dr["NewFileMD5Checksum"].ToString())
                                        dr[5] = "Same as English";
                                    else
                                        dr[5] = "Diff from English";
                                }
                            }
                        }
                    }*/
                }

                #endregion
            }

            return data;
        }

        /// <summary>
        /// CreateDiffFile
        /// </summary>
        /// <param name="dtVerifyBP"></param>
        /// <param name="dtVerifyAgainstBP"></param>
        /// <returns></returns>
        private DataTable CreateDiffFile(DataTable dtVerifyBP, DataTable dtVerifyAgainstBP)
        {
            DataTable data = new DataTable();

            data.Columns.Add("FileRelativePath");
            data.Columns.Add("Status");
            data.Columns.Add("DiffSize");
            data.Columns.Add("ModifiedDate");
            data.Columns.Add("FilePermissions");
            data.Columns.Add("FileMD5Checksum");
            data.Columns.Add("NewFileSize");
            data.Columns.Add("NewFileModifiedDate");
            data.Columns.Add("NewFilePermissions");
            data.Columns.Add("NewFileMD5Checksum");

            #region Find Modified/Added Files

            foreach (DataRow drVerifyBP in dtVerifyBP.Rows)
            {
                DataRow dr = data.NewRow();
                dr[0] = drVerifyBP[0].ToString();

                DataRow[] dataRow = dtVerifyAgainstBP.Select("FileRelativePath = '" + drVerifyBP[0].ToString().Replace("'", "''") + "'");

                if (dataRow.Length == 0)
                {
                    dr[1] = "Added";
                    dr[2] = drVerifyBP[1].ToString();
                    dr[3] = "NA";
                    dr[4] = "NA";
                    dr[5] = "NA";
                }
                else
                {
                    try
                    {
                        if ((Convert.ToInt32(drVerifyBP[1].ToString()) != Convert.ToInt32(dataRow[0][1].ToString())) || (drVerifyBP[2].ToString() != dataRow[0][2].ToString()) || (drVerifyBP[3].ToString() != dataRow[0][3].ToString()) || (drVerifyBP[4].ToString() != dataRow[0][4].ToString()))
                            dr[1] = "Modified";
                        else
                            dr[1] = "NoChange";

                        dr[2] = (Convert.ToInt32(drVerifyBP[1].ToString()) - Convert.ToInt32(dataRow[0][1].ToString())).ToString();

                        if (drVerifyBP[2].ToString() == dataRow[0][2].ToString())
                            dr[3] = "Same";
                        else
                            dr[3] = "Diff";

                        if (drVerifyBP[3].ToString() == dataRow[0][3].ToString())
                            dr[4] = "Same";
                        else
                            dr[4] = "Diff";

                        if (drVerifyBP[4].ToString() == dataRow[0][4].ToString())
                            dr[5] = "Same";
                        else
                            dr[5] = "Diff";
                    }
                    catch (Exception)
                    {

                    }
                }

                dr[6] = drVerifyBP[1].ToString();
                dr[7] = drVerifyBP[2].ToString();
                dr[8] = drVerifyBP[3].ToString();
                dr[9] = drVerifyBP[4].ToString();

                data.Rows.Add(dr);
            }

            #endregion

            #region Find Removed Files

            foreach (DataRow drVerifyAgainstBP in dtVerifyAgainstBP.Rows)
            {

                DataRow[] dataRow = dtVerifyBP.Select("FileRelativePath = '" + drVerifyAgainstBP[0].ToString().Replace("'", "''") + "'");

                if (dataRow.Length == 0)
                {
                    DataRow dr = data.NewRow();

                    dr[0] = drVerifyAgainstBP[0].ToString();
                    dr[1] = "Removed";
                    dr[2] = drVerifyAgainstBP[1].ToString();
                    dr[3] = "NA";
                    dr[4] = "NA";

                    data.Rows.Add(dr);
                }
            }

            #endregion

            return data;
        }

        /// <summary>
        /// ReadData
        /// </summary>
        /// <param name="fileNameVerifyBP"></param>
        /// <returns></returns>
        private DataTable ReadBPFiles(string file)
        {
            DataTable data = BO.IQEToolsBO.ReadExcludedZStringsfromCSV(file); ;
            return data;
        }

        /// <summary>
        /// WriteBPDiff
        /// </summary>
        /// <param name="dtBPDiff"></param>
        /// <param name="fileNameBPDiff"></param>
        private void WriteBPDiff(DataTable dtBPDiff, string fileNameBPDiff)
        {
            using (StreamWriter sw = new StreamWriter(fileNameBPDiff))
            {
                sw.WriteLine("RelativeFilePath,Status,SizeDiff,ModifiedDate,FilePermissions,MD5CheckSum,NewFileSize,NewModifiedDate,NewFilePermissions,NewFileMD5Checksum");
                foreach (DataRow dr in dtBPDiff.Rows)
                {
                    //if (Convert.ToBoolean(ConfigurationManager.AppSettings["ExcludeNotModified"]) )
                    //{
                    if (dr[1].ToString() != "NoChange")
                        sw.WriteLine(dr[0].ToString() + "," + dr[1].ToString() + "," + dr[2].ToString() + "," + dr[3].ToString() + "," + dr[4].ToString() + "," + dr[5].ToString() + "," + dr[6].ToString() + "," + dr[7].ToString() + "," + dr[8].ToString() + "," + dr[9].ToString());
                    //}
                }
            }

            labelMessage.Text = "BP Comparison File is generated successfully.";
        }

        /// <summary>
        /// fileNameBPResults
        /// </summary>
        /// <param name="dtResults"></param>
        /// <param name="fileNameBPResults"></param>
        private void WriteBPResults(DataTable dtResults, string fileNameBPResults)
        {
            using (StreamWriter sw = new StreamWriter(fileNameBPResults))
            {
                sw.WriteLine("File1,File2,Modified Count,Added Count,Removed Count,Not Changed,DiffFile");
                foreach (DataRow dr in dtResults.Rows)
                {
                    sw.WriteLine(dr[0].ToString() + "," + dr[1].ToString() + "," + dr[2].ToString() + "," + dr[3].ToString() + "," + dr[4].ToString() + "," + dr[5].ToString() + "," + dr[6].ToString());
                }
            }

        }

        #endregion

        #region Radio Buttons

        /// <summary>
        /// radioButtonFolderFiles_CheckedChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonFolderFiles_CheckedChanged(object sender, EventArgs e)
        {
            EnableFolderFilesRadioButton(radioButtonFolderFiles.Checked);
        }

        /// <summary>
        /// radioButtonXML_CheckedChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonXML_CheckedChanged(object sender, EventArgs e)
        {
            EnableXMLFileRadioButton(radioButtonXML.Checked);
        }

        /// <summary>
        /// EnableXMLFileRadioButton
        /// </summary>
        /// <param name="isEnabled"></param>
        private void EnableXMLFileRadioButton(bool isEnabled)
        {
            if (isEnabled)
            {
                radioButtonFolderFiles.Checked = false;
                textBoxVerifyAgainstPath.Enabled = false;
                textBoxVerifyBP.Enabled = false;
                textBoxEnglishBPRef.Enabled = false;
                ButtonVerifyBPBrowse.Enabled = false;
                buttonVerifyAgainstBrowse.Enabled = false;
                buttonEnglishRefBrowse.Enabled = false;

                textBoxVerifyBP.Text = "Build #" + ConfigurationManager.AppSettings["VerifyBPBuildNo"] + " [" + ConfigurationManager.AppSettings["XMLPath"] + "]";
                textBoxVerifyAgainstPath.Text = "Build #" + ConfigurationManager.AppSettings["VerifyAgainstBPBuildNo"] + " [" + ConfigurationManager.AppSettings["XMLPath"] + "]";
                //textBoxVerifyAgainstPath.Text = ConfigurationManager.AppSettings["XMLPath"] + " (Build #" + ConfigurationManager.AppSettings["VerifyAgainstBPBuildNo"] + ")";
                textBoxEnglishBPRef.Text = "Picked based on XML";
            }
        }

        /// <summary>
        /// EnableFolderFilesRadioButton
        /// </summary>
        /// <param name="isEnabled"></param>
        private void EnableFolderFilesRadioButton(bool isEnabled)
        {
            if (isEnabled)
            {
                radioButtonXML.Checked = false;
                textBoxVerifyAgainstPath.Enabled = true;
                textBoxVerifyBP.Enabled = true;
                textBoxEnglishBPRef.Enabled = true;
                ButtonVerifyBPBrowse.Enabled = true;
                buttonVerifyAgainstBrowse.Enabled = true;
                buttonEnglishRefBrowse.Enabled = true;

                textBoxVerifyBP.Text = ConfigurationManager.AppSettings["VerifyBP"];
                textBoxVerifyAgainstPath.Text = ConfigurationManager.AppSettings["VerifyAgainstBP"];
                textBoxEnglishBPRef.Text = ConfigurationManager.AppSettings["EnglishBPRef"];
            }
        }

        #endregion

    }
}
