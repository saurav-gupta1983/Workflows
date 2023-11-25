namespace IQETools.UI.Forms
{
    partial class AboutUsForm
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
            this.LabelMessage = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // LabelMessage
            // 
            this.LabelMessage.AutoSize = true;
            this.LabelMessage.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelMessage.Location = new System.Drawing.Point(10, 30);
            this.LabelMessage.Name = "LabelMessage";
            this.LabelMessage.Size = new System.Drawing.Size(351, 18);
            this.LabelMessage.TabIndex = 1;
            this.LabelMessage.Text = "Please contact following to share feedback and to use it";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // AboutUsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(536, 176);
            this.Controls.Add(this.LabelMessage);
            this.MaximizeBox = false;
            this.Name = "AboutUsForm";
            this.Text = "About IQE";
            this.Load += new System.EventHandler(this.AboutUsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelMessage;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}