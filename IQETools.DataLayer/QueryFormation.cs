using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using DTO = IQETools.Common.DataTransferObjects;

namespace IQETools.DataLayer
{
    public class QueryFormation
    {

        public static string FeatureRequestQuery(string sheetName, DTO.FeatureRequestDTO featureReqDTO)
        {
            StringBuilder query = new StringBuilder("Insert Into [" + sheetName + "$] (Feature, [AI Version], [Requested By], Institution, [Requested On], Languages) Values(");

            query.Append("'" + featureReqDTO.Feedback + "',");
            query.Append("'" + featureReqDTO.ProductVersion + "',");
            query.Append("'" + featureReqDTO.Name + "',");
            query.Append("'" + featureReqDTO.Company + "',");
            query.Append("'" + featureReqDTO.RequestedDate + "',");
            query.Append("'" + featureReqDTO.ProductLanguage + "')");

            return query.ToString().Replace("\r\n\r\n", "\r\n").Replace("\r\n\r\n", "\r\n").Replace("\r\n\r\n", "\r\n").Replace("\r\n\r\n", "\r\n").Replace("\r\n;&nbsp", "");
        }

        public static string BugReportQuery(string sheetName, DTO.FeatureRequestDTO featureReqDTO)
        {
            StringBuilder query = new StringBuilder("Insert Into [" + sheetName + "$] (Bug, [AI Version], [Requested By], Institution, [Requested On], Languages, Platform, [Platform Version], [OS Language]) Values(");

            query.Append("'" + featureReqDTO.Feedback + "',");
            query.Append("'" + featureReqDTO.ProductVersion + "',");
            query.Append("'" + featureReqDTO.Name + "',");
            query.Append("'" + featureReqDTO.Company + "',");
            query.Append("'" + featureReqDTO.RequestedDate + "',");
            query.Append("'" + featureReqDTO.ProductLanguage + "',");
            query.Append("'" + featureReqDTO.Platform + "',");
            query.Append("'" + featureReqDTO.OSVersion + "',");
            query.Append("'" + featureReqDTO.OSLanguage + "')");

            return query.ToString().Replace("\r\n\r\n", "\r\n").Replace("\r\n\r\n", "\r\n").Replace("\r\n\r\n", "\r\n").Replace("\r\n\r\n", "\r\n").Replace("\r\n;&nbsp", "");
        }

        public static string MTDataQuery(string sheetName, DTO.BPComparisonDTO data)
        {
            StringBuilder query = new StringBuilder("Insert Into [" + sheetName + "$] (RelativeFilePath, Status, SizeDiff, FilePermissions, MD5CheckSum) Values(");

            query.Append("'" + data.FileName + "',");
            query.Append("'" + data.Status + "',");
            query.Append("'" + data.SizeDiff + "',");
            query.Append("'" + data.FilePermissions + "',");
            query.Append("'" + data.Md5Checksum + "')");

            return query.ToString();
        }

        public static string MTDataReadQuery(string sheetName)
        {
            StringBuilder query = new StringBuilder("SELECT * FROM [" + sheetName + "$]");

            return query.ToString();
        }

        public static string ExcelWriteDataQuery(string sheetName, DataRow dr, string cols)
        {
            StringBuilder query = new StringBuilder("Insert Into [" + sheetName + "$] (" + cols + ") Values(");

            for (int count = 0; count < dr.ItemArray.Length; count++)
                query.Append("'" + dr.ItemArray[count].ToString().Replace("'", "''") + "',");

            return query.ToString().TrimEnd(new char[] { ',' }) + ")";
        }
    }
}
