namespace IQETools.UI.Forms
{
    partial class MetadataValidation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxFolderPath = new System.Windows.Forms.TextBox();
            this.labelFolderPath = new System.Windows.Forms.Label();
            this.labelTemplate = new System.Windows.Forms.Label();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.comboBoxTemplate = new System.Windows.Forms.ComboBox();
            this.labelTemplateDetails = new System.Windows.Forms.Label();
            this.labelTemplateValue = new System.Windows.Forms.Label();
            this.comboBoxLocale = new System.Windows.Forms.ComboBox();
            this.labelLocale = new System.Windows.Forms.Label();
            this.pictureBoxThumbnail = new System.Windows.Forms.PictureBox();
            this.labelNotFound = new System.Windows.Forms.Label();
            this.labelzip_filename = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labeltemplate_filename = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labeltemplate_categories = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelkeywords = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelOthers = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.labeltitle = new System.Windows.Forms.Label();
            this.labelmarketing_text = new System.Windows.Forms.Label();
            this.textBoxTemplateList = new System.Windows.Forms.TextBox();
            this.labelTemplateList = new System.Windows.Forms.Label();
            this.labelIssues = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelPreview = new System.Windows.Forms.Label();
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.labelFont = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxThumbnail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxFolderPath
            // 
            this.textBoxFolderPath.Location = new System.Drawing.Point(175, 38);
            this.textBoxFolderPath.Name = "textBoxFolderPath";
            this.textBoxFolderPath.Size = new System.Drawing.Size(465, 20);
            this.textBoxFolderPath.TabIndex = 13;
            this.textBoxFolderPath.Text = "\\\\sauragup\\Shared\\Templates\\InDesign";
            // 
            // labelFolderPath
            // 
            this.labelFolderPath.AutoSize = true;
            this.labelFolderPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFolderPath.Location = new System.Drawing.Point(25, 36);
            this.labelFolderPath.Name = "labelFolderPath";
            this.labelFolderPath.Size = new System.Drawing.Size(107, 20);
            this.labelFolderPath.TabIndex = 12;
            this.labelFolderPath.Text = "Folder Path:";
            // 
            // labelTemplate
            // 
            this.labelTemplate.AutoSize = true;
            this.labelTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTemplate.Location = new System.Drawing.Point(25, 92);
            this.labelTemplate.Name = "labelTemplate";
            this.labelTemplate.Size = new System.Drawing.Size(144, 20);
            this.labelTemplate.TabIndex = 10;
            this.labelTemplate.Text = "Select Template:";
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Location = new System.Drawing.Point(239, 159);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(118, 23);
            this.buttonSubmit.TabIndex = 14;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // comboBoxTemplate
            // 
            this.comboBoxTemplate.FormattingEnabled = true;
            this.comboBoxTemplate.Location = new System.Drawing.Point(175, 90);
            this.comboBoxTemplate.Name = "comboBoxTemplate";
            this.comboBoxTemplate.Size = new System.Drawing.Size(465, 21);
            this.comboBoxTemplate.TabIndex = 15;
            // 
            // labelTemplateDetails
            // 
            this.labelTemplateDetails.AutoSize = true;
            this.labelTemplateDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTemplateDetails.Location = new System.Drawing.Point(25, 200);
            this.labelTemplateDetails.Name = "labelTemplateDetails";
            this.labelTemplateDetails.Size = new System.Drawing.Size(149, 20);
            this.labelTemplateDetails.TabIndex = 16;
            this.labelTemplateDetails.Text = "Template Details:";
            // 
            // labelTemplateValue
            // 
            this.labelTemplateValue.AutoSize = true;
            this.labelTemplateValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTemplateValue.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelTemplateValue.Location = new System.Drawing.Point(180, 200);
            this.labelTemplateValue.Name = "labelTemplateValue";
            this.labelTemplateValue.Size = new System.Drawing.Size(121, 20);
            this.labelTemplateValue.TabIndex = 17;
            this.labelTemplateValue.Text = "Unable to Read";
            // 
            // comboBoxLocale
            // 
            this.comboBoxLocale.FormattingEnabled = true;
            this.comboBoxLocale.Location = new System.Drawing.Point(175, 117);
            this.comboBoxLocale.Name = "comboBoxLocale";
            this.comboBoxLocale.Size = new System.Drawing.Size(465, 21);
            this.comboBoxLocale.TabIndex = 19;
            // 
            // labelLocale
            // 
            this.labelLocale.AutoSize = true;
            this.labelLocale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLocale.Location = new System.Drawing.Point(25, 119);
            this.labelLocale.Name = "labelLocale";
            this.labelLocale.Size = new System.Drawing.Size(123, 20);
            this.labelLocale.TabIndex = 18;
            this.labelLocale.Text = "Select Locale:";
            // 
            // pictureBoxThumbnail
            // 
            this.pictureBoxThumbnail.Location = new System.Drawing.Point(29, 232);
            this.pictureBoxThumbnail.Name = "pictureBoxThumbnail";
            this.pictureBoxThumbnail.Size = new System.Drawing.Size(243, 237);
            this.pictureBoxThumbnail.TabIndex = 20;
            this.pictureBoxThumbnail.TabStop = false;
            // 
            // labelNotFound
            // 
            this.labelNotFound.AutoSize = true;
            this.labelNotFound.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNotFound.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelNotFound.Location = new System.Drawing.Point(51, 317);
            this.labelNotFound.Name = "labelNotFound";
            this.labelNotFound.Size = new System.Drawing.Size(207, 20);
            this.labelNotFound.TabIndex = 21;
            this.labelNotFound.Text = "Thumbnail File not found";
            // 
            // labelzip_filename
            // 
            this.labelzip_filename.AutoSize = true;
            this.labelzip_filename.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelzip_filename.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelzip_filename.Location = new System.Drawing.Point(225, 568);
            this.labelzip_filename.Name = "labelzip_filename";
            this.labelzip_filename.Size = new System.Drawing.Size(121, 20);
            this.labelzip_filename.TabIndex = 23;
            this.labelzip_filename.Text = "Unable to Read";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 568);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 20);
            this.label2.TabIndex = 22;
            this.label2.Text = "Zip Filename:";
            // 
            // labeltemplate_filename
            // 
            this.labeltemplate_filename.AutoSize = true;
            this.labeltemplate_filename.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeltemplate_filename.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labeltemplate_filename.Location = new System.Drawing.Point(225, 601);
            this.labeltemplate_filename.Name = "labeltemplate_filename";
            this.labeltemplate_filename.Size = new System.Drawing.Size(121, 20);
            this.labeltemplate_filename.TabIndex = 25;
            this.labeltemplate_filename.Text = "Unable to Read";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(31, 601);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 20);
            this.label4.TabIndex = 24;
            this.label4.Text = "Template Filename:";
            // 
            // labeltemplate_categories
            // 
            this.labeltemplate_categories.AutoSize = true;
            this.labeltemplate_categories.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeltemplate_categories.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labeltemplate_categories.Location = new System.Drawing.Point(225, 633);
            this.labeltemplate_categories.Name = "labeltemplate_categories";
            this.labeltemplate_categories.Size = new System.Drawing.Size(121, 20);
            this.labeltemplate_categories.TabIndex = 27;
            this.labeltemplate_categories.Text = "Unable to Read";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(31, 633);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(180, 20);
            this.label6.TabIndex = 26;
            this.label6.Text = "Template Categories:";
            // 
            // labelkeywords
            // 
            this.labelkeywords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelkeywords.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelkeywords.Location = new System.Drawing.Point(127, 698);
            this.labelkeywords.Name = "labelkeywords";
            this.labelkeywords.Size = new System.Drawing.Size(576, 122);
            this.labelkeywords.TabIndex = 29;
            this.labelkeywords.Text = "Unable to Read";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(31, 698);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 20);
            this.label8.TabIndex = 28;
            this.label8.Text = "Keywords:";
            // 
            // labelOthers
            // 
            this.labelOthers.AutoSize = true;
            this.labelOthers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOthers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelOthers.Location = new System.Drawing.Point(225, 663);
            this.labelOthers.Name = "labelOthers";
            this.labelOthers.Size = new System.Drawing.Size(121, 20);
            this.labelOthers.TabIndex = 31;
            this.labelOthers.Text = "Unable to Read";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(31, 663);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(199, 20);
            this.label10.TabIndex = 30;
            this.label10.Text = "Language,Level,Rating:";
            // 
            // labeltitle
            // 
            this.labeltitle.AutoSize = true;
            this.labeltitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeltitle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labeltitle.Location = new System.Drawing.Point(340, 232);
            this.labeltitle.Name = "labeltitle";
            this.labeltitle.Size = new System.Drawing.Size(179, 20);
            this.labeltitle.TabIndex = 32;
            this.labeltitle.Text = "Title: Unable to Read";
            // 
            // labelmarketing_text
            // 
            this.labelmarketing_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelmarketing_text.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelmarketing_text.Location = new System.Drawing.Point(278, 263);
            this.labelmarketing_text.Name = "labelmarketing_text";
            this.labelmarketing_text.Size = new System.Drawing.Size(438, 235);
            this.labelmarketing_text.TabIndex = 33;
            this.labelmarketing_text.Text = "Marketing Text: Unable to Read";
            // 
            // textBoxTemplateList
            // 
            this.textBoxTemplateList.Location = new System.Drawing.Point(175, 64);
            this.textBoxTemplateList.Name = "textBoxTemplateList";
            this.textBoxTemplateList.Size = new System.Drawing.Size(465, 20);
            this.textBoxTemplateList.TabIndex = 35;
            this.textBoxTemplateList.Text = "C:\\InDesignTemplatesList.csv";
            // 
            // labelTemplateList
            // 
            this.labelTemplateList.AutoSize = true;
            this.labelTemplateList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTemplateList.Location = new System.Drawing.Point(25, 62);
            this.labelTemplateList.Name = "labelTemplateList";
            this.labelTemplateList.Size = new System.Drawing.Size(122, 20);
            this.labelTemplateList.TabIndex = 34;
            this.labelTemplateList.Text = "Template List:";
            // 
            // labelIssues
            // 
            this.labelIssues.AutoSize = true;
            this.labelIssues.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIssues.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelIssues.Location = new System.Drawing.Point(225, 508);
            this.labelIssues.Name = "labelIssues";
            this.labelIssues.Size = new System.Drawing.Size(47, 20);
            this.labelIssues.TabIndex = 37;
            this.labelIssues.Text = "None";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 508);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.TabIndex = 36;
            this.label3.Text = "Issues:";
            // 
            // labelPreview
            // 
            this.labelPreview.AutoSize = true;
            this.labelPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPreview.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelPreview.Location = new System.Drawing.Point(898, 410);
            this.labelPreview.Name = "labelPreview";
            this.labelPreview.Size = new System.Drawing.Size(298, 20);
            this.labelPreview.TabIndex = 39;
            this.labelPreview.Text = "Preview file (Preview1.jpg) not found";
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.Location = new System.Drawing.Point(722, 12);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(760, 793);
            this.pictureBoxPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPreview.TabIndex = 40;
            this.pictureBoxPreview.TabStop = false;
            // 
            // labelFont
            // 
            this.labelFont.AutoSize = true;
            this.labelFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFont.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelFont.Location = new System.Drawing.Point(225, 538);
            this.labelFont.Name = "labelFont";
            this.labelFont.Size = new System.Drawing.Size(121, 20);
            this.labelFont.TabIndex = 42;
            this.labelFont.Text = "Unable to Read";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(31, 538);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 20);
            this.label5.TabIndex = 41;
            this.label5.Text = "Font #s , Keywords:";
            // 
            // MetadataValidation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1495, 817);
            this.Controls.Add(this.labelFont);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelPreview);
            this.Controls.Add(this.labelIssues);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxTemplateList);
            this.Controls.Add(this.labelTemplateList);
            this.Controls.Add(this.labelmarketing_text);
            this.Controls.Add(this.labeltitle);
            this.Controls.Add(this.labelOthers);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.labelkeywords);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.labeltemplate_categories);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labeltemplate_filename);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelzip_filename);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelNotFound);
            this.Controls.Add(this.pictureBoxThumbnail);
            this.Controls.Add(this.comboBoxLocale);
            this.Controls.Add(this.labelLocale);
            this.Controls.Add(this.labelTemplateValue);
            this.Controls.Add(this.labelTemplateDetails);
            this.Controls.Add(this.comboBoxTemplate);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.textBoxFolderPath);
            this.Controls.Add(this.labelFolderPath);
            this.Controls.Add(this.labelTemplate);
            this.Controls.Add(this.pictureBoxPreview);
            this.Name = "MetadataValidation";
            this.Text = "Metadata Validation";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MetadataValidation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxThumbnail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxFolderPath;
        private System.Windows.Forms.Label labelFolderPath;
        private System.Windows.Forms.Label labelTemplate;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.ComboBox comboBoxTemplate;
        private System.Windows.Forms.Label labelTemplateDetails;
        private System.Windows.Forms.Label labelTemplateValue;
        private System.Windows.Forms.ComboBox comboBoxLocale;
        private System.Windows.Forms.Label labelLocale;
        private System.Windows.Forms.PictureBox pictureBoxThumbnail;
        private System.Windows.Forms.Label labelNotFound;
        private System.Windows.Forms.Label labelzip_filename;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labeltemplate_filename;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labeltemplate_categories;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelkeywords;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelOthers;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labeltitle;
        private System.Windows.Forms.Label labelmarketing_text;
        private System.Windows.Forms.TextBox textBoxTemplateList;
        private System.Windows.Forms.Label labelTemplateList;
        private System.Windows.Forms.Label labelIssues;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelPreview;
        private System.Windows.Forms.PictureBox pictureBoxPreview;
        private System.Windows.Forms.Label labelFont;
        private System.Windows.Forms.Label label5;

    }
}