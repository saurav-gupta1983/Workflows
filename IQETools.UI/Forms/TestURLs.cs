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
using System.Net;
using System.Drawing.Imaging;
using System.Threading;

namespace IQETools.UI.Forms
{
 
    public partial class TestURLs : Form
    {
        #region Variables

        string error = "";
        #endregion

        #region Constructor

        /// <summary>
        /// TestURLs
        /// </summary>
        public TestURLs()
        {
            InitializeComponent();
        }

#endregion

        #region Load Events

        /// <summary>
        /// TestURLs_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TestURLs_Load(object sender, EventArgs e)
        {
            DataTable dtRead = ReadURLs(@"C:\Users\sauragup\Desktop\test\CCHome_urls_cstr.csv");

            dtRead.Columns.Add("Redirected URL");
            dtRead.Columns.Add("Result");

            const string url = "http://www.bbc.co.uk/news";

            var device = Alx.Web.Devices.Desktop;
            var path = String.Format(@"C:\Temp\website-{0}.png", device);
            Alx.Web.Screenshot.Save(url, path, ImageFormat.Png, device);

            Console.WriteLine("Saved " + path);

            //device = Devices.TabletLandscape;
            //path = String.Format(@"C:\Temp\website-{0}.png", device);
            //Alx.Web.Screenshot.Save(url, path, ImageFormat.Png, device);

            //Console.WriteLine("Saved " + path);

            //device = Devices.PhonePortrait;
            //path = String.Format(@"C:\Temp\website-{0}.png", device);
            //Alx.Web.Screenshot.Save(url, path, ImageFormat.Png, device);

            Console.WriteLine("Saved " + path);

            Console.WriteLine("Press [Enter] to exit...");
            Console.ReadLine();

            //InBrowser(dtRead);


        }


                public static void InBrowser(DataTable dtRead)
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Users\sauragup\Desktop\test\CCHome_urls_cstr - results - Browser.csv"))
            {
                sw.WriteLine("JobID,Language,MockID,Product,EnglishURL,LOC URL,Redirected URL,Result");

                foreach (DataRow dr in dtRead.Rows)
                {

                    try
                    {
                        int width = 800;
                        int height = 600;

                        using (WebBrowser browser = new WebBrowser())
                        {
                            browser.Width = width;
                            browser.Height = height;
                            browser.ScrollBarsEnabled = true;

                            // This will be called when the page finishes loading
                            browser.DocumentCompleted += TestURLs.OnDocumentCompleted;

                            browser.Navigate(dr["LOC URL"].ToString());

                            // This prevents the application from exiting until
                            // Application.Exit is called
                            while (browser.ReadyState != WebBrowserReadyState.Complete)
                            {
                                System.Windows.Forms.Application.DoEvents();
                            }
                        }

                        //dr["Redirected URL"] = response.ResponseUri;
                        //dr["Result"] = response.StatusCode + ": " + response.StatusDescription;

                    }
                    catch (Exception ex)
                    {
                        dr["Redirected URL"] = "Error";
                        dr["Result"] = ex.Message.ToString();
                    }

                    sw.WriteLine(dr[0].ToString() + "," + dr[1].ToString() + "," + dr[2].ToString() + "," + dr[3].ToString() + "," + dr[4].ToString() + "," + dr[5].ToString() + "," + dr[6].ToString() + "," + dr[7].ToString());

                }
            }
        }

        public static void OnDocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // Now that the page is loaded, save it to a bitmap
            WebBrowser browser = (WebBrowser)sender;

            using (Graphics graphics = browser.CreateGraphics())
            using (Bitmap bitmap = new Bitmap(browser.Width, browser.Height, graphics))
            {
                Rectangle bounds = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
                browser.DrawToBitmap(bitmap, bounds);
                bitmap.Save("screenshot.bmp", ImageFormat.Bmp);
            }

            // Instruct the application to exit
            Application.Exit();
        }

        public static void WithoutBrowser(DataTable dtRead)
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Users\sauragup\Desktop\test\CCHome_urls_cstr - results.csv"))
            {
                sw.WriteLine("JobID,Language,MockID,Product,EnglishURL,LOC URL,Redirected URL,Result");

                foreach (DataRow dr in dtRead.Rows)
                {

                    try
                    {
                        HttpWebRequest request = WebRequest.Create(dr["LOC URL"].ToString()) as HttpWebRequest;
                        //optional

                        HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                        dr["Redirected URL"] = response.ResponseUri;
                        dr["Result"] = response.StatusCode + ": " + response.StatusDescription;
                        Stream stream = response.GetResponseStream();


                    }
                    catch (Exception ex)
                    {
                        dr["Redirected URL"] = "Error";
                        dr["Result"] = ex.Message.ToString();
                    }

                    sw.WriteLine(dr[0].ToString() + "," + dr[1].ToString() + "," + dr[2].ToString() + "," + dr[3].ToString() + "," + dr[4].ToString() + "," + dr[5].ToString() + "," + dr[6].ToString() + "," + dr[7].ToString());

                }
            }
        }

        public static DataTable ReadURLs(string filePath)
        {
            DataTable data = new DataTable();

            data.Columns.Add("JobID");
            data.Columns.Add("Language");
            data.Columns.Add("MockID");
            data.Columns.Add("Product");
            data.Columns.Add("EnglishURL");
            data.Columns.Add("LOC URL");


            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                // Read and display lines from the file until the end of 
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    if (line != "")
                    {
                        string[] separator = new string[] { "," };
                        string[] splitline = line.Split(separator, StringSplitOptions.None);
                        //string temp = "";

                        if (splitline.Length > 4)
                        {
                            //if (splitline[0].Trim() != "" && splitline[splitline.Length - 3].Trim() != "" && splitline[splitline.Length - 2].Trim() != "" && splitline[splitline.Length - 1].Trim() != "")
                            if (splitline[0].Trim() != "" && splitline[splitline.Length - 4].Trim() != "" && splitline[splitline.Length - 1].Trim() != "")
                            {
                                DataRow dr = data.NewRow();

                                dr[0] = splitline[0].Trim('"');
                                dr[1] = splitline[1].Trim('"');
                                dr[2] = splitline[2].Trim('"');
                                dr[3] = splitline[3].Trim('"');
                                dr[4] = splitline[4].Trim('"');
                                dr[5] = splitline[5].Trim('"');

                                //dr[1] = splitline[splitline.Length - 5].Trim();
                                //dr[2] = splitline[splitline.Length - 3].Trim();
                                //dr[3] = splitline[splitline.Length - 2].Trim();
                                //dr[4] = splitline[splitline.Length - 1].Trim();

                                //if (splitline.Length == 5)
                                //{
                                //    dr[0] = splitline[0].Trim();
                                //}
                                //else
                                //{
                                //    dr[0] = splitline[0];
                                //    for (int counter = 1; counter < splitline.Length - 3; counter++)
                                //    {
                                //        dr[0] = dr[0] + "," + splitline[counter];
                                //    }
                                //    dr[0] = dr[0].ToString().Trim();
                                //}

                                data.Rows.Add(dr);
                            }
                        }

                        //for (int count = 0; count < splitline.Length; count += 3)
                        //{
                        //    if (count == 0)
                        //    {
                        //        temp = splitline[count + 3].Substring(splitline[count + 3].IndexOf("|"));
                        //    }
                        //    else
                        //    {
                        //        DataRow dr = data.NewRow();

                        //        dr[0] = temp;
                        //        dr[1] = splitline[count + 1].Trim();
                        //        dr[2] = splitline[count + 2].Trim();
                        //        dr[3] = splitline[count + 3].Substring(0, splitline[count + 3].IndexOf("|"));
                        //        temp = splitline[count + 3].Substring(splitline[count + 3].IndexOf("|"));

                        //        data.Rows.Add(dr);
                        //    }
                        //}
                    }
                }
            }

            //data.Rows.RemoveAt(0);
            return data;
        }

        #endregion
    }
}
