using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ExtractData.Common.InfrastructureServices
{
    /// <summary>
    /// ExceptionLogger
    /// </summary>
    public class ExceptionLogger
    {
        #region Variables

        string errorLogFile;

        #endregion

        #region Constructor

        /// <summary>
        /// ExceptionLogger
        /// </summary>
        public ExceptionLogger()
        {
            errorLogFile = System.Configuration.ConfigurationManager.AppSettings["ErrorLogFile"].ToString();
            string[] file = errorLogFile.Split(new char[] { '\\' });

            if (!Directory.Exists(errorLogFile.Replace(file[file.Length - 1], "")))
                Directory.CreateDirectory(errorLogFile.Replace(file[file.Length - 1], ""));

            if (!File.Exists(errorLogFile))
                File.Create(errorLogFile);
        }

        #endregion

        /// <summary>
        /// WriteToLog
        /// </summary>
        /// <param name="text"></param>
        public void WriteToLog(string text)
        {
            using (StreamWriter writer = new StreamWriter(errorLogFile, true))
            {
                writer.WriteLine(string.Format(text, DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")));
                writer.Close();
            }
        }

    }
}
