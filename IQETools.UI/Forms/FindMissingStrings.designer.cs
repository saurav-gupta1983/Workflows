namespace IQETools.UI.Forms
{
    partial class FindMissingStrings
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
            this.textBoxResults = new System.Windows.Forms.TextBox();
            this.labelFileName = new System.Windows.Forms.Label();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.textBoxMissingStrings = new System.Windows.Forms.TextBox();
            this.labelMissingStrings = new System.Windows.Forms.Label();
            this.textBoxIncludeFileTypes = new System.Windows.Forms.TextBox();
            this.labelIncludeFileTypes = new System.Windows.Forms.Label();
            this.textBoxExcludeFileTypes = new System.Windows.Forms.TextBox();
            this.labelExcludeFileTypes = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxFolderPath
            // 
            this.textBoxFolderPath.Location = new System.Drawing.Point(182, 37);
            this.textBoxFolderPath.Name = "textBoxFolderPath";
            this.textBoxFolderPath.Size = new System.Drawing.Size(465, 20);
            this.textBoxFolderPath.TabIndex = 13;
            this.textBoxFolderPath.Text = "C:\\IQETools\\Data\\Code\\";
            // 
            // labelFolderPath
            // 
            this.labelFolderPath.AutoSize = true;
            this.labelFolderPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFolderPath.Location = new System.Drawing.Point(25, 35);
            this.labelFolderPath.Name = "labelFolderPath";
            this.labelFolderPath.Size = new System.Drawing.Size(98, 20);
            this.labelFolderPath.TabIndex = 12;
            this.labelFolderPath.Text = "Code Path:";
            // 
            // textBoxResults
            // 
            this.textBoxResults.Location = new System.Drawing.Point(182, 106);
            this.textBoxResults.Name = "textBoxResults";
            this.textBoxResults.Size = new System.Drawing.Size(465, 20);
            this.textBoxResults.TabIndex = 11;
            this.textBoxResults.Text = "C:\\IQETools\\Data\\Results.csv";
            // 
            // labelFileName
            // 
            this.labelFileName.AutoSize = true;
            this.labelFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFileName.Location = new System.Drawing.Point(25, 104);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(75, 20);
            this.labelFileName.TabIndex = 10;
            this.labelFileName.Text = "Results:";
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Location = new System.Drawing.Point(237, 214);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(118, 23);
            this.buttonSubmit.TabIndex = 14;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.ButtonSubmit_Click);
            // 
            // textBoxMissingStrings
            // 
            this.textBoxMissingStrings.Location = new System.Drawing.Point(182, 72);
            this.textBoxMissingStrings.Name = "textBoxMissingStrings";
            this.textBoxMissingStrings.Size = new System.Drawing.Size(465, 20);
            this.textBoxMissingStrings.TabIndex = 16;
            this.textBoxMissingStrings.Text = "C:\\IQETools\\Data\\Lr_Strings_Unidentified_Android (2).csv";
            // 
            // labelMissingStrings
            // 
            this.labelMissingStrings.AutoSize = true;
            this.labelMissingStrings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMissingStrings.Location = new System.Drawing.Point(25, 70);
            this.labelMissingStrings.Name = "labelMissingStrings";
            this.labelMissingStrings.Size = new System.Drawing.Size(136, 20);
            this.labelMissingStrings.TabIndex = 15;
            this.labelMissingStrings.Text = "Missing Strings:";
            // 
            // textBoxIncludeFileTypes
            // 
            this.textBoxIncludeFileTypes.Location = new System.Drawing.Point(182, 141);
            this.textBoxIncludeFileTypes.Name = "textBoxIncludeFileTypes";
            this.textBoxIncludeFileTypes.Size = new System.Drawing.Size(465, 20);
            this.textBoxIncludeFileTypes.TabIndex = 18;
            // 
            // labelIncludeFileTypes
            // 
            this.labelIncludeFileTypes.AutoSize = true;
            this.labelIncludeFileTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIncludeFileTypes.Location = new System.Drawing.Point(25, 139);
            this.labelIncludeFileTypes.Name = "labelIncludeFileTypes";
            this.labelIncludeFileTypes.Size = new System.Drawing.Size(95, 20);
            this.labelIncludeFileTypes.TabIndex = 17;
            this.labelIncludeFileTypes.Text = "File Types:";
            // 
            // textBoxExcludeFileTypes
            // 
            this.textBoxExcludeFileTypes.Location = new System.Drawing.Point(182, 175);
            this.textBoxExcludeFileTypes.Name = "textBoxExcludeFileTypes";
            this.textBoxExcludeFileTypes.Size = new System.Drawing.Size(465, 20);
            this.textBoxExcludeFileTypes.TabIndex = 20;
            this.textBoxExcludeFileTypes.Text = ".zstrings;.csv";
            // 
            // labelExcludeFileTypes
            // 
            this.labelExcludeFileTypes.AutoSize = true;
            this.labelExcludeFileTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelExcludeFileTypes.Location = new System.Drawing.Point(25, 173);
            this.labelExcludeFileTypes.Name = "labelExcludeFileTypes";
            this.labelExcludeFileTypes.Size = new System.Drawing.Size(153, 20);
            this.labelExcludeFileTypes.TabIndex = 19;
            this.labelExcludeFileTypes.Text = "ExcludeFileTypes:";
            // 
            // FindMissingStrings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 261);
            this.Controls.Add(this.textBoxExcludeFileTypes);
            this.Controls.Add(this.labelExcludeFileTypes);
            this.Controls.Add(this.textBoxIncludeFileTypes);
            this.Controls.Add(this.labelIncludeFileTypes);
            this.Controls.Add(this.textBoxMissingStrings);
            this.Controls.Add(this.labelMissingStrings);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.textBoxFolderPath);
            this.Controls.Add(this.labelFolderPath);
            this.Controls.Add(this.textBoxResults);
            this.Controls.Add(this.labelFileName);
            this.Name = "FindMissingStrings";
            this.Text = "Find Missing StringIDs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxFolderPath;
        private System.Windows.Forms.Label labelFolderPath;
        private System.Windows.Forms.TextBox textBoxResults;
        private System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.TextBox textBoxMissingStrings;
        private System.Windows.Forms.Label labelMissingStrings;
        private System.Windows.Forms.TextBox textBoxIncludeFileTypes;
        private System.Windows.Forms.Label labelIncludeFileTypes;
        private System.Windows.Forms.TextBox textBoxExcludeFileTypes;
        private System.Windows.Forms.Label labelExcludeFileTypes;

    }
}