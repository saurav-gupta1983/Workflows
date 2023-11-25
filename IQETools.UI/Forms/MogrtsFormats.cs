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
    public partial class MogrtsFormats : Form
    {
        #region Variables

        string error = "";
        #endregion

        #region Constructor

        /// <summary>
        /// MogrtsFormats
        /// </summary>
        public MogrtsFormats()
        {
            InitializeComponent();
        }

        /// <summary>
        /// MogrtsFormats_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MogrtsFormats_Load(object sender, EventArgs e)
        {
            string destinationFolder = @"C:\Saurav\Rush Graphic Templates_New";
            DirectoryInfo dir = new DirectoryInfo(@"C:\Saurav\Rush Graphic Templates");
            DirectoryInfo[] subdirectories = dir.GetDirectories();

            if (destinationFolder.Contains("Rush"))
            {
                FileInfo[] filesRush = dir.GetFiles();
                foreach (FileInfo file in filesRush)
                {
                    String fileTemp = file.Name.Replace(".mogrt", "");
                    String mogrtFolder = destinationFolder + "\\" + fileTemp;
                    Directory.CreateDirectory(mogrtFolder);
                    copyfile(@"C:\Saurav\Exported_Mogrt_Files\JPN\" + fileTemp + @"\ja.mogrt", mogrtFolder + "\\ja.mogrt");
                }
            }

            if (subdirectories.Length > 0)
            {
                foreach (DirectoryInfo subdir in subdirectories)
                {
                    String newDirectory = destinationFolder + "\\" + subdir.Name;
                    Directory.CreateDirectory(newDirectory);

                    FileInfo[] files = subdir.GetFiles();
                    foreach (FileInfo file in files)
                    {

                        String fileTemp = file.Name.Replace(".mogrt", "");
                        String mogrtFolder = newDirectory + "\\" + fileTemp;
                        Directory.CreateDirectory(mogrtFolder);

                        copyfile(file.FullName, mogrtFolder + "\\en.mogrt");
                        copyfile(@"C:\Saurav\Exported_Mogrt_Files\CHS\" + fileTemp + @"\chs.mogrt", mogrtFolder + "\\chs.mogrt");
                        copyfile(@"C:\Saurav\Exported_Mogrt_Files\JPN\" + fileTemp + @"\ja.mogrt", mogrtFolder + "\\ja.mogrt");
                        copyfile(@"C:\Saurav\Exported_Mogrt_Files\KOR\" + fileTemp + @"\kr.mogrt", mogrtFolder + "\\ko.mogrt");
                        copyfile(@"C:\Saurav\Exported_Mogrt_Files\RUS\" + fileTemp + @"\ru.mogrt", mogrtFolder + "\\ru.mogrt");

                    }
                }
            }

        }

        void copyfile(string source, string destination)
        {
            try
            {
                System.IO.File.Copy(source, destination, true);
            }
            catch (Exception)
            {
                if (File.Exists(source.Replace(" ", "_")))
                {
                    System.IO.File.Copy(source.Replace(" ", "_"), destination, true);
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(@"C:\Saurav\Essential Graphics_New\Error.txt"))
                        sw.WriteLine(source);
                }
                //error = error + "\n" + source;
            }
        }

        #endregion
    }
}
