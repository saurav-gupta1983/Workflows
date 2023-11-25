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
    public partial class MetadataValidation : Form
    {
        //private string logFilePath;
        private DataTable dtTemplate;
        string prevPath;
        string extension = ConfigurationManager.AppSettings["Extension"].ToString();

        /// <summary>
        /// CompileFolderInformationForm
        /// </summary>
        public MetadataValidation()
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
                labelTemplateValue.Text = "";
                prevPath = textBoxTemplateList.Text;
                BindComboBoxTemplate();
                BindComboBoxLocale();
                if (comboBoxTemplate.Items.Count > 0)
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
            if (prevPath != textBoxTemplateList.Text)
            {
                BindComboBoxTemplate();
                prevPath = textBoxTemplateList.Text;
            }
            try
            {
                bool found = false;
                int templCount = 0;
                for (; templCount < dtTemplate.Rows.Count; templCount++)
                    if (String.Equals(dtTemplate.Rows[templCount]["Template fileName"].ToString(), comboBoxTemplate.SelectedValue.ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        found = true;
                        break;
                    }

                labelTemplateValue.Text = comboBoxTemplate.SelectedValue.ToString();

                if (found)
                {
                    labelTemplateValue.Text = dtTemplate.Rows[templCount]["Vendor"].ToString() + " -> " + dtTemplate.Rows[templCount]["Typ"].ToString() + " -> " + dtTemplate.Rows[templCount]["Folder"].ToString();

                    string folder = dtTemplate.Rows[templCount]["Folder"].ToString().Replace("  ", "_").Replace(" ", "_") + "-" + comboBoxLocale.Text;
                    string path = textBoxFolderPath.Text + @"\" + comboBoxLocale.Text + @"\" + labelTemplateValue.Text.Replace(" -> ", @"\");

                    string templateFolder = comboBoxTemplate.SelectedValue.ToString().Replace(extension, "");
                    /* Image */
                    pictureBoxThumbnail.Visible = true;
                    labelNotFound.Visible = false;

                    if (System.IO.File.Exists(path + @"\" + "Thumbnail.jpg"))
                        pictureBoxThumbnail.ImageLocation = path + @"\" + "Thumbnail.jpg";
                    else if (System.IO.File.Exists(path + @"\" + templateFolder + @"\" + "Thumbnail.jpg"))
                        pictureBoxThumbnail.ImageLocation = path + @"\" + templateFolder + @"\" + "Thumbnail.jpg";
                    else if (System.IO.File.Exists(path + @"\" + templateFolder + @"\" + templateFolder + @"\" + "Thumbnail.jpg"))
                        pictureBoxThumbnail.ImageLocation = path + @"\" + templateFolder + @"\" + templateFolder + @"\" + "Thumbnail.jpg";
                    else
                    {
                        pictureBoxThumbnail.Visible = false;
                        labelNotFound.Visible = true;
                    }

                    pictureBoxThumbnail.SizeMode = PictureBoxSizeMode.StretchImage;

                    pictureBoxPreview.Visible = true;
                    labelPreview.Visible = false;

                    if (System.IO.File.Exists(path + @"\" + "Preview1.jpg"))
                        pictureBoxPreview.ImageLocation = path + @"\" + "Preview1.jpg";
                    else if (System.IO.File.Exists(path + @"\" + templateFolder + @"\" + "Preview1.jpg"))
                        pictureBoxPreview.ImageLocation = path + @"\" + templateFolder + @"\" + "Preview1.jpg";
                    else if (System.IO.File.Exists(path + @"\" + templateFolder + @"\" + templateFolder + @"\" + "Preview1.jpg"))
                        pictureBoxPreview.ImageLocation = path + @"\" + templateFolder + @"\" + templateFolder + @"\" + "Preview1.jpg";
                    else
                    {
                        pictureBoxPreview.Visible = false;
                        labelPreview.Visible = true;
                    }

                    //pictureBoxPreview.SizeMode = PictureBoxSizeMode.StretchImage;
                    //pictureBoxPreview.SizeMode = PictureBoxSizeMode.AutoSize;
                    /* Image */

                    /* CSV Check */
                    string vendor = dtTemplate.Rows[templCount]["Vendor"].ToString();
                    string csvFile = textBoxFolderPath.Text + @"\" + comboBoxLocale.Text + @"\" + vendor + @"\" + "AdobeTemplates_" + "ID_" + vendor.Replace(" ", "") + "_" + comboBoxLocale.SelectedValue + ".csv";
                    DataTable dtMetadata = ReadTemplatesMetadatafromCSV(csvFile, comboBoxTemplate.SelectedValue.ToString());

                    ShowMetadata(dtMetadata);
                    ValidationCheck();
                }
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
                labelFont.Text = "";
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
        /// 
        /// </summary>
        /// <param name="dtMetadata"></param>
        private void ShowMetadata(DataTable dtMetadata)
        {
            try
            {
                if (dtMetadata.Rows.Count > 0)
                {
                    string[] separator = new string[] { "#" };
                    string[] splitline = dtMetadata.Rows[0]["marketing_text"].ToString().Split(separator, StringSplitOptions.None);

                    labelFont.Text = (splitline.Length - 1).ToString();

                    labelzip_filename.Text = dtMetadata.Rows[0]["zip_filename"].ToString();
                    labeltemplate_filename.Text = dtMetadata.Rows[0]["template_filename"].ToString();
                    labeltitle.Text = dtMetadata.Rows[0]["title"].ToString();
                    labeltemplate_categories.Text = dtMetadata.Rows[0]["template_categories"].ToString();
                    labelkeywords.Text = dtMetadata.Rows[0]["keywords"].ToString();
                    labelmarketing_text.Text = dtMetadata.Rows[0]["marketing_text"].ToString().Replace("##### ", " ").Trim();
                    labelOthers.Text = dtMetadata.Rows[0]["language_id"].ToString() + " , " + dtMetadata.Rows[0]["premium_level_id"].ToString() + " , " + dtMetadata.Rows[0]["rating"].ToString();
                }
            }
            catch (Exception ex)
            {
                ShowMessage("Validation Check failed. " + ex.Message.ToString());
            }
        }

        /// <summary>
        /// ReadTemplatesfromCSV
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public DataTable ReadTemplatesfromCSV(string filePath, int columns)
        {
            DataTable data = new DataTable();

            try
            {

                data.Columns.Add("Vendor");
                data.Columns.Add("Typ");
                data.Columns.Add("Folder");
                data.Columns.Add("Template filename");

                if (columns == 6)
                    data.Columns.Add("Missing Names");

                data.Columns.Add("Notes");

                //PSTemplates -   Vendor	Typ	Folder	Template filename	Missing Names	Notes
                //Results     -   Vendor	Typ	Folder	Template filename	Notes
                //Moravia     -   Vendor	Typ	Folder	Template filename	Notes
                bool header = true;

                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (!header)
                        {
                            string[] separator = new string[] { "," };
                            string[] splitline = line.Trim(new char[] { '"' }).Split(separator, StringSplitOptions.None);

                            DataRow dr = data.NewRow();

                            for (int i = 0; i < splitline.Length; i++)
                                dr[i] = splitline[i].Trim();

                            data.Rows.Add(dr);
                        }
                        else
                            header = false;

                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessage("Templates file read failed. " + ex.Message.ToString());
            }
            return data;
        }

        /// <summary>
        /// ReadTemplatesMetadatafromCSV
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public DataTable ReadTemplatesMetadatafromCSV(string filePath, string templateName)
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
                        if (line.Contains("-" + comboBoxLocale.SelectedValue.ToString().ToLower() + ".zip"))
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
                        if (templateRow.Contains(comboBoxTemplate.SelectedValue.ToString().Replace(extension, "")))
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
                                            drMetadata[lineCounter] = csvColumns[splitCounter].ToString();
                                            lineCounter++;
                                        }
                                    }
                                }
                            }

                            dtMetadata.Rows.Add(drMetadata);
                        }

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
        /// BindComboBoxTemplate
        /// </summary>
        private void BindComboBoxTemplate()
        {
            try
            {
                dtTemplate = ReadTemplatesfromCSV(textBoxTemplateList.Text, 5);
                dtTemplate.DefaultView.Sort = "Template filename" + " " + "ASC";
                dtTemplate = dtTemplate.DefaultView.ToTable();

                comboBoxTemplate.DataSource = dtTemplate;
                comboBoxTemplate.DisplayMember = "Template filename";
                comboBoxTemplate.ValueMember = "Template filename";
            }
            catch (Exception ex)
            {
                ShowMessage("Templates Data not available. " + ex.Message.ToString());
            }
        }

        /// <summary>
        /// BindComboBoxLocale
        /// </summary>
        private void BindComboBoxLocale()
        {
            try
            {

                DataTable dtLocale = new DataTable();
                dtLocale.Columns.Add("Locale");
                dtLocale.Columns.Add("LocaleCode");

                dtLocale.Rows.Add("DE","de_DE");
                dtLocale.Rows.Add("ES","es_ES");
                dtLocale.Rows.Add("FR","fr_FR");
                dtLocale.Rows.Add("IT","it_IT");
                dtLocale.Rows.Add("JP","ja_JP");

                comboBoxLocale.DataSource = dtLocale;
                comboBoxLocale.DisplayMember = "LocaleCode";
                comboBoxLocale.ValueMember = "Locale";
            }
            catch (Exception ex)
            {
                ShowMessage("Locale Data not available. " + ex.Message.ToString());
            }

        }

        /// <summary>
        /// pictureBoxThumbnail_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxThumbnail_Click(object sender, EventArgs e)
        {

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
