namespace IQETools.UI
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adobeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blueprintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blueprintComparisonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findMissingStringsIDsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UploadTestCasesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromExcelToJIRAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metadataValidationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.validateMetadataCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mogrtsFormatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.encodeDecodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutUsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutUsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.testURLsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adobeToolStripMenuItem,
            this.aboutUsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(11, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(1652, 42);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adobeToolStripMenuItem
            // 
            this.adobeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blueprintToolStripMenuItem,
            this.findMissingStringsIDsToolStripMenuItem,
            this.UploadTestCasesToolStripMenuItem,
            this.metadataValidationToolStripMenuItem,
            this.validateMetadataCSVToolStripMenuItem,
            this.mogrtsFormatsToolStripMenuItem,
            this.encodeDecodeToolStripMenuItem,
            this.testURLsToolStripMenuItem});
            this.adobeToolStripMenuItem.Name = "adobeToolStripMenuItem";
            this.adobeToolStripMenuItem.Size = new System.Drawing.Size(151, 34);
            this.adobeToolStripMenuItem.Text = "Support Tools";
            // 
            // blueprintToolStripMenuItem
            // 
            this.blueprintToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blueprintComparisonToolStripMenuItem});
            this.blueprintToolStripMenuItem.Name = "blueprintToolStripMenuItem";
            this.blueprintToolStripMenuItem.Size = new System.Drawing.Size(300, 34);
            this.blueprintToolStripMenuItem.Text = "Blueprint";
            // 
            // blueprintComparisonToolStripMenuItem
            // 
            this.blueprintComparisonToolStripMenuItem.Name = "blueprintComparisonToolStripMenuItem";
            this.blueprintComparisonToolStripMenuItem.Size = new System.Drawing.Size(286, 34);
            this.blueprintComparisonToolStripMenuItem.Text = "Blueprint Comparison";
            this.blueprintComparisonToolStripMenuItem.Click += new System.EventHandler(this.blueprintComparisonToolStripMenuItem_Click);
            // 
            // findMissingStringsIDsToolStripMenuItem
            // 
            this.findMissingStringsIDsToolStripMenuItem.Enabled = false;
            this.findMissingStringsIDsToolStripMenuItem.Name = "findMissingStringsIDsToolStripMenuItem";
            this.findMissingStringsIDsToolStripMenuItem.Size = new System.Drawing.Size(300, 34);
            this.findMissingStringsIDsToolStripMenuItem.Text = "Find Missing StringsIDs";
            this.findMissingStringsIDsToolStripMenuItem.Click += new System.EventHandler(this.findMissingStringsIDsToolStripMenuItem_Click);
            // 
            // UploadTestCasesToolStripMenuItem
            // 
            this.UploadTestCasesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fromExcelToJIRAToolStripMenuItem});
            this.UploadTestCasesToolStripMenuItem.Name = "UploadTestCasesToolStripMenuItem";
            this.UploadTestCasesToolStripMenuItem.Size = new System.Drawing.Size(300, 34);
            this.UploadTestCasesToolStripMenuItem.Text = "Upload TestCases";
            // 
            // fromExcelToJIRAToolStripMenuItem
            // 
            this.fromExcelToJIRAToolStripMenuItem.Name = "fromExcelToJIRAToolStripMenuItem";
            this.fromExcelToJIRAToolStripMenuItem.Size = new System.Drawing.Size(258, 34);
            this.fromExcelToJIRAToolStripMenuItem.Text = "From Excel to JIRA";
            this.fromExcelToJIRAToolStripMenuItem.Click += new System.EventHandler(this.fromExcelToJIRAToolStripMenuItem_Click);
            // 
            // metadataValidationToolStripMenuItem
            // 
            this.metadataValidationToolStripMenuItem.Name = "metadataValidationToolStripMenuItem";
            this.metadataValidationToolStripMenuItem.Size = new System.Drawing.Size(300, 34);
            this.metadataValidationToolStripMenuItem.Text = "Metadata Validation";
            this.metadataValidationToolStripMenuItem.Click += new System.EventHandler(this.metadataValidationToolStripMenuItem_Click);
            // 
            // validateMetadataCSVToolStripMenuItem
            // 
            this.validateMetadataCSVToolStripMenuItem.Name = "validateMetadataCSVToolStripMenuItem";
            this.validateMetadataCSVToolStripMenuItem.Size = new System.Drawing.Size(300, 34);
            this.validateMetadataCSVToolStripMenuItem.Text = "Validate Metadata CSV";
            this.validateMetadataCSVToolStripMenuItem.Click += new System.EventHandler(this.validateMetadataCSVToolStripMenuItem_Click);
            // 
            // mogrtsFormatsToolStripMenuItem
            // 
            this.mogrtsFormatsToolStripMenuItem.Name = "mogrtsFormatsToolStripMenuItem";
            this.mogrtsFormatsToolStripMenuItem.Size = new System.Drawing.Size(300, 34);
            this.mogrtsFormatsToolStripMenuItem.Text = "Mogrts Formats";
            this.mogrtsFormatsToolStripMenuItem.Click += new System.EventHandler(this.mogrtsFormatsToolStripMenuItem_Click);
            // 
            // encodeDecodeToolStripMenuItem
            // 
            this.encodeDecodeToolStripMenuItem.Name = "encodeDecodeToolStripMenuItem";
            this.encodeDecodeToolStripMenuItem.Size = new System.Drawing.Size(300, 34);
            this.encodeDecodeToolStripMenuItem.Text = "EncodeDecode";
            this.encodeDecodeToolStripMenuItem.Click += new System.EventHandler(this.encodeDecodeToolStripMenuItem_Click);
            // 
            // aboutUsToolStripMenuItem
            // 
            this.aboutUsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutUsToolStripMenuItem1});
            this.aboutUsToolStripMenuItem.Name = "aboutUsToolStripMenuItem";
            this.aboutUsToolStripMenuItem.Size = new System.Drawing.Size(111, 34);
            this.aboutUsToolStripMenuItem.Text = "About Us";
            // 
            // aboutUsToolStripMenuItem1
            // 
            this.aboutUsToolStripMenuItem1.Name = "aboutUsToolStripMenuItem1";
            this.aboutUsToolStripMenuItem1.Size = new System.Drawing.Size(172, 34);
            this.aboutUsToolStripMenuItem1.Text = "About Us";
            this.aboutUsToolStripMenuItem1.Click += new System.EventHandler(this.aboutUsToolStripMenuItem1_Click);
            // 
            // testURLsToolStripMenuItem
            // 
            this.testURLsToolStripMenuItem.Name = "testURLsToolStripMenuItem";
            this.testURLsToolStripMenuItem.Size = new System.Drawing.Size(300, 34);
            this.testURLsToolStripMenuItem.Text = "Test URLs";
            this.testURLsToolStripMenuItem.Click += new System.EventHandler(this.testURLsToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1652, 1102);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "MainForm";
            this.Text = "Adobe - IQE Testing Support Tools";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adobeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blueprintToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blueprintComparisonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutUsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutUsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem findMissingStringsIDsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UploadTestCasesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromExcelToJIRAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem metadataValidationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem validateMetadataCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mogrtsFormatsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem encodeDecodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testURLsToolStripMenuItem;
    }
}