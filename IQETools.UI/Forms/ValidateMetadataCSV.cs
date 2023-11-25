using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Configuration;

namespace IQETools.UI.Forms
{
    /// <summary>
    /// MetadataValidation
    /// </summary>
    public partial class ValidateMetadataCSV : Form
    {
        string prevFile;
        string extension = ConfigurationManager.AppSettings["Extension"].ToString();
        DataTable dtMetadata;
        int templCount;


        /// <summary>
        /// ValidateMetadataCSV
        /// </summary>
        public ValidateMetadataCSV()
        {
            InitializeComponent();
        }

        /// <summary>
        /// MetadataValidation_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MetadataValidation_Load(object sender, EventArgs e)
        {
            try
            {
                buttonSubmit_Click(null, null);
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message.ToString());
            }
        }

        /// <summary>
        /// buttonSubmit_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (prevFile != textBoxTemplateMetadata.Text)
            {
                templCount = 0;
                dtMetadata = ReadTemplatesMetadatafromCSV(textBoxTemplateMetadata.Text);
                prevFile = textBoxTemplateMetadata.Text;
            }

            if (templCount == dtMetadata.Rows.Count)
                templCount = 0;

            try
            {
                /* CSV Check */
                ShowMetadata(dtMetadata, templCount);
                ValidationCheck();
                templCount++;

            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message.ToString());
            }
            /* CSV Check */

        }

        /// <summary>
        /// ValidationCheck
        /// </summary>
        /// <param name="dtMetadata"></param>
        private void ValidationCheck()
        {
            try
            {
                labelIssues.Text = "";
                bool valFailed = false;

                if (labelFont.Text != "5")
                    labelFont.Text += " (Incorrect Font #s);";

                string[] csvSeparator = new string[] { "," };
                string[] keyList = labelkeywords.Text.Split(csvSeparator, StringSplitOptions.None);

                labelFont.Text += ", " + keyList.Length.ToString();

                if (keyList.Length < 5)
                    labelIssues.Text = "Less number of keywords;";

                foreach (string key in keyList)
                {
                    if (countOccurences(key, labelkeywords.Text) > 1)
                    {
                        labelIssues.Text = "Duplicate Keywords;";
                        break;
                    }
                }

                if (!valFailed)
                    labelIssues.Text = "None";
            }
            catch (Exception ex)
            {
                ShowMessage("Validation Check failed. " + ex.Message.ToString());
            }

        }

        /// <summary>
        /// countOccurences
        /// </summary>
        /// <param name="needle"></param>
        /// <param name="haystack"></param>
        /// <returns></returns>
        int countOccurences(string needle, string haystack)
        {
            return (haystack.Length - haystack.Replace(needle, "").Length) / needle.Length;
        }

        /// <summary>
        /// ShowMetadata
        /// </summary>
        /// <param name="dtMetadata"></param>
        private void ShowMetadata(DataTable dtMetadata, int row)
        {
            try
            {
                if (dtMetadata.Rows.Count > 0)
                {
                    string[] separator = new string[] { "#" };
                    string[] splitline = dtMetadata.Rows[row]["marketing_text"].ToString().Split(separator, StringSplitOptions.None);

                    labelFont.Text = (splitline.Length - 1).ToString();

                    labelzip_filename.Text = dtMetadata.Rows[row]["zip_filename"].ToString();
                    labeltemplate_filename.Text = dtMetadata.Rows[row]["template_filename"].ToString();
                    labeltitle.Text = dtMetadata.Rows[row]["title"].ToString();
                    labeltemplate_categories.Text = dtMetadata.Rows[row]["template_categories"].ToString();
                    labelkeywords.Text = dtMetadata.Rows[row]["keywords"].ToString();
                    labelmarketing_text.Text = dtMetadata.Rows[row]["marketing_text"].ToString().Replace("##### ", " ").Trim();
                    labelOthers.Text = dtMetadata.Rows[row]["language_id"].ToString() + " , " + dtMetadata.Rows[row]["premium_level_id"].ToString() + " , " + dtMetadata.Rows[row]["rating"].ToString();

                    labelTemplateValue.Text = (row + 1).ToString() + " of " + dtMetadata.Rows.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                ShowMessage("Validation Check failed. " + ex.Message.ToString());
            }
        }

        /// <summary>
        /// ReadTemplatesMetadatafromCSV
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public DataTable ReadTemplatesMetadatafromCSV(string filePath)
        {
            DataTable dtMetadata = new DataTable();

            try
            {
                dtMetadata.Columns.Add("zip_filename");
                dtMetadata.Columns.Add("template_filename");
                dtMetadata.Columns.Add("title");
                dtMetadata.Columns.Add("template_categories");
                dtMetadata.Columns.Add("keywords");
                dtMetadata.Columns.Add("marketing_text");
                dtMetadata.Columns.Add("language_id");
                dtMetadata.Columns.Add("premium_level_id");
                dtMetadata.Columns.Add("rating");

                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    StringBuilder tempLine = new StringBuilder();
                    string[] csvSeparator = new string[] { "," };
                    DataRow drMetadata = dtMetadata.NewRow();

                    ArrayList template = new ArrayList();
                    line = sr.ReadLine();
                    bool skipfirst = true;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Contains(".zip") && line.Contains(extension))
                        {
                            if (!skipfirst)
                                template.Add(tempLine.ToString());
                            tempLine = new StringBuilder();
                            tempLine.Append(line);
                            skipfirst = false;
                        }
                        else
                        {
                            tempLine.Append(Environment.NewLine);
                            tempLine.Append(line);
                        }
                    }
                    template.Add(tempLine.ToString());

                    string[] quoteSeparator = new string[] { "\"" };

                    foreach (string templateRow in template)
                    {
                        drMetadata = dtMetadata.NewRow();
                        string dataRow;
                        dataRow = templateRow.Replace(",\"", ",\"Q#Start").Replace("\",", "Q#End\",");
                        string[] quoteColumns = dataRow.Split(quoteSeparator, StringSplitOptions.None);
                        int lineCounter = 0;

                        foreach (string splitline in quoteColumns)
                        {
                            if (splitline.Contains("Q#Start") && splitline.Contains("Q#End"))
                            {
                                drMetadata[lineCounter] = splitline.Replace("Q#Start", "").Replace("Q#End", "");
                                lineCounter++;
                            }
                            else
                            {
                                string[] csvColumns = splitline.Split(csvSeparator, StringSplitOptions.None);

                                for (int splitCounter = 0; splitCounter < csvColumns.Length; splitCounter++)
                                {
                                    if (csvColumns[splitCounter].ToString() != "")
                                    {
                                        drMetadata[lineCounter] = csvColumns[splitCounter].ToString().Replace("Q#Start", "").Replace("Q#End", "");
                                        lineCounter++;
                                    }
                                }
                            }
                        }

                        dtMetadata.Rows.Add(drMetadata);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessage("Templates Metadata file read failed. " + ex.Message.ToString());
            }

            return dtMetadata;
        }

        /// <summary>
        /// ShowMessage
        /// </summary>
        /// <param name="message"></param>
        private void ShowMessage(string message)
        {
            MessageBox.Show("Error: " + message);
        }
    }

}
