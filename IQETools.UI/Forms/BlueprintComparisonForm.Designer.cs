namespace IQETools.UI.Forms
{
    partial class BlueprintComparisonForm
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
            this.ButtonVerifyBPBrowse = new System.Windows.Forms.Button();
            this.textBoxVerifyBP = new System.Windows.Forms.TextBox();
            this.labelVerifyBPPath = new System.Windows.Forms.Label();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.labelMessage = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.buttonVerifyAgainstBrowse = new System.Windows.Forms.Button();
            this.textBoxVerifyAgainstPath = new System.Windows.Forms.TextBox();
            this.labelVerifyagainstBP = new System.Windows.Forms.Label();
            this.buttonBPDiffBrowse = new System.Windows.Forms.Button();
            this.textBoxBPDiff = new System.Windows.Forms.TextBox();
            this.labelBPDiffPath = new System.Windows.Forms.Label();
            this.buttonEnglishRefBrowse = new System.Windows.Forms.Button();
            this.textBoxEnglishBPRef = new System.Windows.Forms.TextBox();
            this.labelEnglishReference = new System.Windows.Forms.Label();
            this.buttonBPResultsBrowse = new System.Windows.Forms.Button();
            this.textBoxBPResults = new System.Windows.Forms.TextBox();
            this.labelBPComparisonResults = new System.Windows.Forms.Label();
            this.radioButtonFolderFiles = new System.Windows.Forms.RadioButton();
            this.radioButtonXML = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // ButtonVerifyBPBrowse
            // 
            this.ButtonVerifyBPBrowse.Location = new System.Drawing.Point(1276, 42);
            this.ButtonVerifyBPBrowse.Margin = new System.Windows.Forms.Padding(6);
            this.ButtonVerifyBPBrowse.Name = "ButtonVerifyBPBrowse";
            this.ButtonVerifyBPBrowse.Size = new System.Drawing.Size(94, 42);
            this.ButtonVerifyBPBrowse.TabIndex = 7;
            this.ButtonVerifyBPBrowse.Text = "Browse";
            this.ButtonVerifyBPBrowse.UseVisualStyleBackColor = true;
            this.ButtonVerifyBPBrowse.Click += new System.EventHandler(this.BrowseFolder_Click);
            // 
            // textBoxVerifyBP
            // 
            this.textBoxVerifyBP.Location = new System.Drawing.Point(365, 42);
            this.textBoxVerifyBP.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxVerifyBP.Name = "textBoxVerifyBP";
            this.textBoxVerifyBP.Size = new System.Drawing.Size(873, 29);
            this.textBoxVerifyBP.TabIndex = 6;
            this.textBoxVerifyBP.Text = "C:\\Blueprints\\18.1.6\\win64\\HD\\20180625.r.34";
            // 
            // labelVerifyBPPath
            // 
            this.labelVerifyBPPath.AutoSize = true;
            this.labelVerifyBPPath.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVerifyBPPath.Location = new System.Drawing.Point(22, 42);
            this.labelVerifyBPPath.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelVerifyBPPath.Name = "labelVerifyBPPath";
            this.labelVerifyBPPath.Size = new System.Drawing.Size(274, 35);
            this.labelVerifyBPPath.TabIndex = 5;
            this.labelVerifyBPPath.Text = "Verify BP Folder Path*";
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Location = new System.Drawing.Point(545, 552);
            this.buttonGenerate.Margin = new System.Windows.Forms.Padding(6);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(378, 42);
            this.buttonGenerate.TabIndex = 11;
            this.buttonGenerate.Text = "Generate BP Difference";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMessage.Location = new System.Drawing.Point(24, 631);
            this.labelMessage.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(500, 29);
            this.labelMessage.TabIndex = 12;
            this.labelMessage.Text = "This tool allows you to do BP Comparison";
            this.labelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // buttonVerifyAgainstBrowse
            // 
            this.buttonVerifyAgainstBrowse.Location = new System.Drawing.Point(1276, 103);
            this.buttonVerifyAgainstBrowse.Margin = new System.Windows.Forms.Padding(6);
            this.buttonVerifyAgainstBrowse.Name = "buttonVerifyAgainstBrowse";
            this.buttonVerifyAgainstBrowse.Size = new System.Drawing.Size(94, 42);
            this.buttonVerifyAgainstBrowse.TabIndex = 15;
            this.buttonVerifyAgainstBrowse.Text = "Browse";
            this.buttonVerifyAgainstBrowse.UseVisualStyleBackColor = true;
            this.buttonVerifyAgainstBrowse.Click += new System.EventHandler(this.buttonVerifyAgainstBrowse_Click);
            // 
            // textBoxVerifyAgainstPath
            // 
            this.textBoxVerifyAgainstPath.Location = new System.Drawing.Point(365, 103);
            this.textBoxVerifyAgainstPath.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxVerifyAgainstPath.Name = "textBoxVerifyAgainstPath";
            this.textBoxVerifyAgainstPath.Size = new System.Drawing.Size(873, 29);
            this.textBoxVerifyAgainstPath.TabIndex = 14;
            this.textBoxVerifyAgainstPath.Text = "C:\\Blueprints\\18.1.5\\win64\\HD\\20180518.r.32";
            // 
            // labelVerifyagainstBP
            // 
            this.labelVerifyagainstBP.AutoSize = true;
            this.labelVerifyagainstBP.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVerifyagainstBP.Location = new System.Drawing.Point(22, 103);
            this.labelVerifyagainstBP.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelVerifyagainstBP.Name = "labelVerifyagainstBP";
            this.labelVerifyagainstBP.Size = new System.Drawing.Size(225, 35);
            this.labelVerifyagainstBP.TabIndex = 13;
            this.labelVerifyagainstBP.Text = "Verify against BP*";
            // 
            // buttonBPDiffBrowse
            // 
            this.buttonBPDiffBrowse.Location = new System.Drawing.Point(1276, 284);
            this.buttonBPDiffBrowse.Margin = new System.Windows.Forms.Padding(6);
            this.buttonBPDiffBrowse.Name = "buttonBPDiffBrowse";
            this.buttonBPDiffBrowse.Size = new System.Drawing.Size(94, 42);
            this.buttonBPDiffBrowse.TabIndex = 18;
            this.buttonBPDiffBrowse.Text = "Browse";
            this.buttonBPDiffBrowse.UseVisualStyleBackColor = true;
            this.buttonBPDiffBrowse.Click += new System.EventHandler(this.buttonBPDiffBrowse_Click);
            // 
            // textBoxBPDiff
            // 
            this.textBoxBPDiff.Location = new System.Drawing.Point(365, 284);
            this.textBoxBPDiff.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxBPDiff.Name = "textBoxBPDiff";
            this.textBoxBPDiff.Size = new System.Drawing.Size(873, 29);
            this.textBoxBPDiff.TabIndex = 17;
            this.textBoxBPDiff.Text = "C:\\Blueprints\\18.1.6\\win64\\HD\\20180625.r.34";
            // 
            // labelBPDiffPath
            // 
            this.labelBPDiffPath.AutoSize = true;
            this.labelBPDiffPath.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBPDiffPath.Location = new System.Drawing.Point(22, 284);
            this.labelBPDiffPath.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelBPDiffPath.Name = "labelBPDiffPath";
            this.labelBPDiffPath.Size = new System.Drawing.Size(153, 35);
            this.labelBPDiffPath.TabIndex = 16;
            this.labelBPDiffPath.Text = "BP Diff Path";
            // 
            // buttonEnglishRefBrowse
            // 
            this.buttonEnglishRefBrowse.Location = new System.Drawing.Point(1276, 168);
            this.buttonEnglishRefBrowse.Margin = new System.Windows.Forms.Padding(6);
            this.buttonEnglishRefBrowse.Name = "buttonEnglishRefBrowse";
            this.buttonEnglishRefBrowse.Size = new System.Drawing.Size(94, 42);
            this.buttonEnglishRefBrowse.TabIndex = 21;
            this.buttonEnglishRefBrowse.Text = "Browse";
            this.buttonEnglishRefBrowse.UseVisualStyleBackColor = true;
            this.buttonEnglishRefBrowse.Click += new System.EventHandler(this.buttonEnglishRefBrowse_Click);
            // 
            // textBoxEnglishBPRef
            // 
            this.textBoxEnglishBPRef.Location = new System.Drawing.Point(365, 168);
            this.textBoxEnglishBPRef.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxEnglishBPRef.Name = "textBoxEnglishBPRef";
            this.textBoxEnglishBPRef.Size = new System.Drawing.Size(873, 29);
            this.textBoxEnglishBPRef.TabIndex = 20;
            this.textBoxEnglishBPRef.Text = "C:\\Blueprints\\18.1.6\\win64\\HD\\20180625.r.34\\en_US.csv";
            // 
            // labelEnglishReference
            // 
            this.labelEnglishReference.AutoSize = true;
            this.labelEnglishReference.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEnglishReference.Location = new System.Drawing.Point(22, 168);
            this.labelEnglishReference.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelEnglishReference.Name = "labelEnglishReference";
            this.labelEnglishReference.Size = new System.Drawing.Size(179, 35);
            this.labelEnglishReference.TabIndex = 19;
            this.labelEnglishReference.Text = "English BP Ref";
            // 
            // buttonBPResultsBrowse
            // 
            this.buttonBPResultsBrowse.Location = new System.Drawing.Point(1276, 338);
            this.buttonBPResultsBrowse.Margin = new System.Windows.Forms.Padding(6);
            this.buttonBPResultsBrowse.Name = "buttonBPResultsBrowse";
            this.buttonBPResultsBrowse.Size = new System.Drawing.Size(94, 42);
            this.buttonBPResultsBrowse.TabIndex = 24;
            this.buttonBPResultsBrowse.Text = "Browse";
            this.buttonBPResultsBrowse.UseVisualStyleBackColor = true;
            this.buttonBPResultsBrowse.Click += new System.EventHandler(this.buttonBPResultsBrowse_Click);
            // 
            // textBoxBPResults
            // 
            this.textBoxBPResults.Location = new System.Drawing.Point(365, 338);
            this.textBoxBPResults.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxBPResults.Name = "textBoxBPResults";
            this.textBoxBPResults.Size = new System.Drawing.Size(873, 29);
            this.textBoxBPResults.TabIndex = 23;
            this.textBoxBPResults.Text = "C:\\Blueprints\\18.1.6\\win64\\HD\\20180625.r.34\\Results.csv";
            // 
            // labelBPComparisonResults
            // 
            this.labelBPComparisonResults.AutoSize = true;
            this.labelBPComparisonResults.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBPComparisonResults.Location = new System.Drawing.Point(22, 338);
            this.labelBPComparisonResults.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelBPComparisonResults.Name = "labelBPComparisonResults";
            this.labelBPComparisonResults.Size = new System.Drawing.Size(136, 35);
            this.labelBPComparisonResults.TabIndex = 22;
            this.labelBPComparisonResults.Text = "BP Results";
            // 
            // radioButtonFolderFiles
            // 
            this.radioButtonFolderFiles.AutoSize = true;
            this.radioButtonFolderFiles.Location = new System.Drawing.Point(365, 465);
            this.radioButtonFolderFiles.Margin = new System.Windows.Forms.Padding(6);
            this.radioButtonFolderFiles.Name = "radioButtonFolderFiles";
            this.radioButtonFolderFiles.Size = new System.Drawing.Size(149, 29);
            this.radioButtonFolderFiles.TabIndex = 25;
            this.radioButtonFolderFiles.Text = "Folder / Files";
            this.radioButtonFolderFiles.UseVisualStyleBackColor = true;
            this.radioButtonFolderFiles.CheckedChanged += new System.EventHandler(this.radioButtonFolderFiles_CheckedChanged);
            // 
            // radioButtonXML
            // 
            this.radioButtonXML.AutoSize = true;
            this.radioButtonXML.Checked = true;
            this.radioButtonXML.Location = new System.Drawing.Point(627, 465);
            this.radioButtonXML.Margin = new System.Windows.Forms.Padding(6);
            this.radioButtonXML.Name = "radioButtonXML";
            this.radioButtonXML.Size = new System.Drawing.Size(124, 29);
            this.radioButtonXML.TabIndex = 26;
            this.radioButtonXML.TabStop = true;
            this.radioButtonXML.Text = "XML Path";
            this.radioButtonXML.UseVisualStyleBackColor = true;
            this.radioButtonXML.CheckedChanged += new System.EventHandler(this.radioButtonXML_CheckedChanged);
            // 
            // BlueprintComparisonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1382, 678);
            this.Controls.Add(this.radioButtonXML);
            this.Controls.Add(this.radioButtonFolderFiles);
            this.Controls.Add(this.buttonBPResultsBrowse);
            this.Controls.Add(this.textBoxBPResults);
            this.Controls.Add(this.labelBPComparisonResults);
            this.Controls.Add(this.buttonEnglishRefBrowse);
            this.Controls.Add(this.textBoxEnglishBPRef);
            this.Controls.Add(this.labelEnglishReference);
            this.Controls.Add(this.buttonBPDiffBrowse);
            this.Controls.Add(this.textBoxBPDiff);
            this.Controls.Add(this.labelBPDiffPath);
            this.Controls.Add(this.buttonVerifyAgainstBrowse);
            this.Controls.Add(this.textBoxVerifyAgainstPath);
            this.Controls.Add(this.labelVerifyagainstBP);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.buttonGenerate);
            this.Controls.Add(this.ButtonVerifyBPBrowse);
            this.Controls.Add(this.textBoxVerifyBP);
            this.Controls.Add(this.labelVerifyBPPath);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "BlueprintComparisonForm";
            this.Text = "Blueprint Comparison";
            this.Load += new System.EventHandler(this.BlueprintComparisonForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonVerifyBPBrowse;
        private System.Windows.Forms.TextBox textBoxVerifyBP;
        private System.Windows.Forms.Label labelVerifyBPPath;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button buttonVerifyAgainstBrowse;
        private System.Windows.Forms.TextBox textBoxVerifyAgainstPath;
        private System.Windows.Forms.Label labelVerifyagainstBP;
        private System.Windows.Forms.Button buttonBPDiffBrowse;
        private System.Windows.Forms.TextBox textBoxBPDiff;
        private System.Windows.Forms.Label labelBPDiffPath;
        private System.Windows.Forms.Button buttonEnglishRefBrowse;
        private System.Windows.Forms.TextBox textBoxEnglishBPRef;
        private System.Windows.Forms.Label labelEnglishReference;
        private System.Windows.Forms.Button buttonBPResultsBrowse;
        private System.Windows.Forms.TextBox textBoxBPResults;
        private System.Windows.Forms.Label labelBPComparisonResults;
        private System.Windows.Forms.RadioButton radioButtonFolderFiles;
        private System.Windows.Forms.RadioButton radioButtonXML;
    }
}