using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IQETools.Common.DataTransferObjects
{
    public class BPComparisonDTO
    {
        #region Variables

        private string fileName;
        private string status;
        private string sizeDiff;
        private string filePermissions;
        private string md5Checksum;

        #endregion

        #region Public Properties

        /// <summary>
        /// fileName
        /// </summary>
        public string FileName
        {
            get
            {
                return fileName;
            }
            set
            {
                fileName = value;
            }
        }

        /// <summary>
        /// filePermissions
        /// </summary>
        public string FilePermissions
        {
            get
            {
                return filePermissions;
            }
            set
            {
                filePermissions = value;
            }
        }

        /// <summary>
        /// md5Checksum
        /// </summary>
        public string Md5Checksum
        {
            get
            {
                return md5Checksum;
            }
            set
            {
                md5Checksum = value;
            }
        }

        /// <summary>
        /// status
        /// </summary>
        public string Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }

        /// <summary>
        /// sizeDiff
        /// </summary>
        public string SizeDiff
        {
            get
            {
                return sizeDiff;
            }
            set
            {
                sizeDiff = value;
            }
        }

        #endregion
    }
}
