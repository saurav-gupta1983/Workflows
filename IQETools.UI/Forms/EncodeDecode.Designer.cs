namespace IQETools.UI.Forms
{
    partial class EncodeDecode
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
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.textBoxEncodingText = new System.Windows.Forms.TextBox();
            this.textBoxEncodedText = new System.Windows.Forms.TextBox();
            this.textBoxDecodingText = new System.Windows.Forms.TextBox();
            this.textBoxDecodedText = new System.Windows.Forms.TextBox();
            this.buttonBase64Encode = new System.Windows.Forms.Button();
            this.buttonBase64URLEncode = new System.Windows.Forms.Button();
            this.buttonBase64URLDecode = new System.Windows.Forms.Button();
            this.buttonBase64Decode = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // textBoxEncodingText
            // 
            this.textBoxEncodingText.Location = new System.Drawing.Point(15, 59);
            this.textBoxEncodingText.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxEncodingText.Multiline = true;
            this.textBoxEncodingText.Name = "textBoxEncodingText";
            this.textBoxEncodingText.Size = new System.Drawing.Size(621, 245);
            this.textBoxEncodingText.TabIndex = 7;
            this.textBoxEncodingText.Text = "EncodingText";
            // 
            // textBoxEncodedText
            // 
            this.textBoxEncodedText.Location = new System.Drawing.Point(858, 59);
            this.textBoxEncodedText.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxEncodedText.Multiline = true;
            this.textBoxEncodedText.Name = "textBoxEncodedText";
            this.textBoxEncodedText.Size = new System.Drawing.Size(621, 245);
            this.textBoxEncodedText.TabIndex = 8;
            this.textBoxEncodedText.Text = "EncodedText";
            // 
            // textBoxDecodingText
            // 
            this.textBoxDecodingText.Location = new System.Drawing.Point(15, 377);
            this.textBoxDecodingText.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxDecodingText.Multiline = true;
            this.textBoxDecodingText.Name = "textBoxDecodingText";
            this.textBoxDecodingText.Size = new System.Drawing.Size(621, 245);
            this.textBoxDecodingText.TabIndex = 9;
            this.textBoxDecodingText.Text = "DecodingText";
            // 
            // textBoxDecodedText
            // 
            this.textBoxDecodedText.Location = new System.Drawing.Point(858, 377);
            this.textBoxDecodedText.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxDecodedText.Multiline = true;
            this.textBoxDecodedText.Name = "textBoxDecodedText";
            this.textBoxDecodedText.Size = new System.Drawing.Size(621, 245);
            this.textBoxDecodedText.TabIndex = 10;
            this.textBoxDecodedText.Text = "DecodedText";
            // 
            // buttonBase64Encode
            // 
            this.buttonBase64Encode.Location = new System.Drawing.Point(648, 127);
            this.buttonBase64Encode.Margin = new System.Windows.Forms.Padding(6);
            this.buttonBase64Encode.Name = "buttonBase64Encode";
            this.buttonBase64Encode.Size = new System.Drawing.Size(182, 42);
            this.buttonBase64Encode.TabIndex = 12;
            this.buttonBase64Encode.Text = "Base64 Encode >";
            this.buttonBase64Encode.UseVisualStyleBackColor = true;
            this.buttonBase64Encode.Click += new System.EventHandler(this.buttonBase64Encode_Click);
            // 
            // buttonBase64URLEncode
            // 
            this.buttonBase64URLEncode.Location = new System.Drawing.Point(648, 198);
            this.buttonBase64URLEncode.Margin = new System.Windows.Forms.Padding(6);
            this.buttonBase64URLEncode.Name = "buttonBase64URLEncode";
            this.buttonBase64URLEncode.Size = new System.Drawing.Size(182, 66);
            this.buttonBase64URLEncode.TabIndex = 13;
            this.buttonBase64URLEncode.Text = "Base64URL Encode >";
            this.buttonBase64URLEncode.UseVisualStyleBackColor = true;
            this.buttonBase64URLEncode.Click += new System.EventHandler(this.buttonBase64URLEncode_Click);
            // 
            // buttonBase64URLDecode
            // 
            this.buttonBase64URLDecode.Location = new System.Drawing.Point(648, 505);
            this.buttonBase64URLDecode.Margin = new System.Windows.Forms.Padding(6);
            this.buttonBase64URLDecode.Name = "buttonBase64URLDecode";
            this.buttonBase64URLDecode.Size = new System.Drawing.Size(182, 66);
            this.buttonBase64URLDecode.TabIndex = 15;
            this.buttonBase64URLDecode.Text = "Base64URL Decode >";
            this.buttonBase64URLDecode.UseVisualStyleBackColor = true;
            this.buttonBase64URLDecode.Click += new System.EventHandler(this.buttonBase64URLDecode_Click);
            // 
            // buttonBase64Decode
            // 
            this.buttonBase64Decode.Location = new System.Drawing.Point(648, 434);
            this.buttonBase64Decode.Margin = new System.Windows.Forms.Padding(6);
            this.buttonBase64Decode.Name = "buttonBase64Decode";
            this.buttonBase64Decode.Size = new System.Drawing.Size(182, 42);
            this.buttonBase64Decode.TabIndex = 14;
            this.buttonBase64Decode.Text = "Base64 Decode >";
            this.buttonBase64Decode.UseVisualStyleBackColor = true;
            this.buttonBase64Decode.Click += new System.EventHandler(this.buttonBase64Decode_Click);
            // 
            // EncodeDecode
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1546, 659);
            this.Controls.Add(this.buttonBase64URLDecode);
            this.Controls.Add(this.buttonBase64Decode);
            this.Controls.Add(this.buttonBase64URLEncode);
            this.Controls.Add(this.buttonBase64Encode);
            this.Controls.Add(this.textBoxDecodedText);
            this.Controls.Add(this.textBoxDecodingText);
            this.Controls.Add(this.textBoxEncodedText);
            this.Controls.Add(this.textBoxEncodingText);
            this.MaximizeBox = false;
            this.Name = "EncodeDecode";
            this.Text = "Mogrts Formats";
            this.Load += new System.EventHandler(this.MogrtsFormats_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox textBoxEncodingText;
        private System.Windows.Forms.TextBox textBoxEncodedText;
        private System.Windows.Forms.TextBox textBoxDecodingText;
        private System.Windows.Forms.TextBox textBoxDecodedText;
        private System.Windows.Forms.Button buttonBase64Encode;
        private System.Windows.Forms.Button buttonBase64URLEncode;
        private System.Windows.Forms.Button buttonBase64URLDecode;
        private System.Windows.Forms.Button buttonBase64Decode;
    }
}