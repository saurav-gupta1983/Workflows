namespace IQETools.UI.Forms
{
    partial class UploadTestCasesToJIRAFromExcel
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
            this.textBoxResults = new System.Windows.Forms.TextBox();
            this.labelFileName = new System.Windows.Forms.Label();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.textBoxExcelPath = new System.Windows.Forms.TextBox();
            this.labelExcelPath = new System.Windows.Forms.Label();
            this.labelMessage = new System.Windows.Forms.Label();
            this.textBoxTestCases = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxResults
            // 
            this.textBoxResults.Location = new System.Drawing.Point(435, 118);
            this.textBoxResults.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxResults.Name = "textBoxResults";
            this.textBoxResults.Size = new System.Drawing.Size(1104, 29);
            this.textBoxResults.TabIndex = 11;
            this.textBoxResults.Text = "C:\\Saurav\\IQE\\Photoshop\\PS Legacy Testcases\\TestCases\\JIRA_Testcases.xlsx";
            // 
            // labelFileName
            // 
            this.labelFileName.AutoSize = true;
            this.labelFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFileName.Location = new System.Drawing.Point(46, 114);
            this.labelFileName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(126, 32);
            this.labelFileName.TabIndex = 10;
            this.labelFileName.Text = "Results:";
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Location = new System.Drawing.Point(602, 688);
            this.buttonSubmit.Margin = new System.Windows.Forms.Padding(6);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(216, 42);
            this.buttonSubmit.TabIndex = 14;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.ButtonSubmit_Click);
            // 
            // textBoxExcelPath
            // 
            this.textBoxExcelPath.Location = new System.Drawing.Point(435, 52);
            this.textBoxExcelPath.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxExcelPath.Name = "textBoxExcelPath";
            this.textBoxExcelPath.Size = new System.Drawing.Size(1104, 29);
            this.textBoxExcelPath.TabIndex = 16;
            this.textBoxExcelPath.Text = "C:\\Saurav\\IQE\\Photoshop\\PS Legacy Testcases\\Converted\\Filter.xlsx";
            // 
            // labelExcelPath
            // 
            this.labelExcelPath.AutoSize = true;
            this.labelExcelPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelExcelPath.Location = new System.Drawing.Point(46, 52);
            this.labelExcelPath.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelExcelPath.Name = "labelExcelPath";
            this.labelExcelPath.Size = new System.Drawing.Size(170, 32);
            this.labelExcelPath.TabIndex = 15;
            this.labelExcelPath.Text = "Excel Path:";
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMessage.Location = new System.Drawing.Point(0, 749);
            this.labelMessage.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelMessage.MaximumSize = new System.Drawing.Size(1558, 0);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(1502, 58);
            this.labelMessage.TabIndex = 17;
            this.labelMessage.Text = "This tool allows you to generate the file compaitble with JIRA Import if you have" +
                " strings in defined format. For any issues, contact sauragup@adobe.com";
            this.labelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxTestCases
            // 
            this.textBoxTestCases.Location = new System.Drawing.Point(435, 186);
            this.textBoxTestCases.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxTestCases.Multiline = true;
            this.textBoxTestCases.Name = "textBoxTestCases";
            this.textBoxTestCases.Size = new System.Drawing.Size(1104, 473);
            this.textBoxTestCases.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 186);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 32);
            this.label1.TabIndex = 18;
            this.label1.Text = "Test Cases Path:";
            // 
            // UploadTestCasesToJIRAFromExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1564, 816);
            this.Controls.Add(this.textBoxTestCases);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.textBoxExcelPath);
            this.Controls.Add(this.labelExcelPath);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.textBoxResults);
            this.Controls.Add(this.labelFileName);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "UploadTestCasesToJIRAFromExcel";
            this.Text = "Generate JIRA Compatible Import File";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxResults;
        private System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.TextBox textBoxExcelPath;
        private System.Windows.Forms.Label labelExcelPath;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.TextBox textBoxTestCases;
        private System.Windows.Forms.Label label1;

    }
}