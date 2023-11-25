using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DTO = IQETools.Common.DataTransferObjects;
using BO = IQETools.BusinessLayer;
using System.Configuration;
using System.Xml;

namespace IQETools.UI.Forms
{
    public partial class AboutUsForm : Form
    {
        #region Variables

        #endregion

        #region Constructor

        /// <summary>
        /// AboutUsForm
        /// </summary>
        public AboutUsForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// AboutUsForm_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutUsForm_Load(object sender, EventArgs e)
        {
            StringBuilder message = new StringBuilder();

            message.Append("This tool is owned by Internationalization  Quality Team  (IQE).");
            message.Append("\r\n\r\n");
            message.Append("Please contact following to share your Suggestions and Feedback:");
            message.Append("\r\n");
            message.Append("Nandan Jha (nandan@adobe.com)");
            message.Append("\r\n");
            message.Append("Rakesh Lal (ralal@adobe.com)");
            message.Append("\r\n");
            message.Append("Saurav Gupta (sauragup@adobe.com)");
            message.Append("\r\n\r\n");
            LabelMessage.Text = message.ToString();
        }

        #endregion
    }
}
