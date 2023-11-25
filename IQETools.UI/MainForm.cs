using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IQETools.UI.Forms;

namespace IQETools.UI
{
    public partial class MainForm : Form
    {
        #region Constructor

        /// <summary>
        /// MainForm
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        #endregion

        #region ToolStripMenu Items

        /// <summary>
        /// blueprintComparisonToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void blueprintComparisonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BlueprintComparisonForm form = new BlueprintComparisonForm();
            form.MdiParent = this;
            form.Show();
        }

        /// <summary>
        /// aboutUsToolStripMenuItem1_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutUsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutUsForm form = new AboutUsForm();
            form.MdiParent = this;
            form.Show();
        }

        /// <summary>
        /// findMissingStringsIDsToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void findMissingStringsIDsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindMissingStrings form = new FindMissingStrings();
            form.MdiParent = this;
            form.Show();
        }

        /// <summary>
        /// fromExcelToJIRAToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fromExcelToJIRAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UploadTestCasesToJIRAFromExcel form = new UploadTestCasesToJIRAFromExcel();
            form.MdiParent = this;
            form.Show();
        }

        /// <summary>
        /// metadataValidationToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metadataValidationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MetadataValidation form = new MetadataValidation();
            form.MdiParent = this;
            form.Show();
        }

        /// <summary>
        /// validateMetadataCSVToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void validateMetadataCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ValidateMetadataCSV form = new ValidateMetadataCSV();
            form.MdiParent = this;
            form.Show();
        }

        #endregion

        private void mogrtsFormatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MogrtsFormats form = new MogrtsFormats();
            form.MdiParent = this;
            form.Show();
        }

        private void encodeDecodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EncodeDecode form = new EncodeDecode();
            form.MdiParent = this;
            form.Show();
        }

        private void testURLsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestURLs form = new TestURLs();
            form.MdiParent = this;
            form.Show();
        }
    }
}
