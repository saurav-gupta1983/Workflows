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
//using Microsoft.IdentityModel.Tokens;

namespace IQETools.UI.Forms
{
    public partial class EncodeDecode : Form
    {
        #region Variables

        string error = "";
        #endregion

        #region Constructor

        /// <summary>
        /// MogrtsFormats
        /// </summary>
        public EncodeDecode()
        {
            InitializeComponent();
        }

        private void MogrtsFormats_Load(object sender, EventArgs e)
        {
        }

        private void buttonBase64Encode_Click(object sender, EventArgs e)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(textBoxEncodingText.Text);
            textBoxEncodedText.Text = System.Convert.ToBase64String(plainTextBytes);
            textBoxDecodingText.Text = textBoxEncodedText.Text;
        }

        private void buttonBase64URLEncode_Click(object sender, EventArgs e)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(textBoxEncodingText.Text);
            textBoxEncodedText.Text = Base64Url.Encode(plainTextBytes);
            //textBoxEncodedText.Text = Base64UrlEncoder.Encode(StringToEncode);
            textBoxDecodingText.Text = textBoxEncodedText.Text;
        }

        private void buttonBase64Decode_Click(object sender, EventArgs e)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(textBoxDecodingText.Text);
            textBoxDecodedText.Text = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        private void buttonBase64URLDecode_Click(object sender, EventArgs e)
        {
            var base64EncodedBytes = Base64Url.Decode(textBoxDecodingText.Text);
            textBoxDecodedText.Text = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        #endregion

    }

    public static class Base64Url
    {
        public static string Encode(byte[] input)
        {
            var output = Convert.ToBase64String(input);

            output = output.Split('=')[0]; // Remove any trailing '='s
            output = output.Replace('+', '-'); // 62nd char of encoding
            output = output.Replace('/', '_'); // 63rd char of encoding

            return output;
        }

        public static byte[] Decode(string input)
        {
            var output = input;

            output = output.Replace('-', '+'); // 62nd char of encoding
            output = output.Replace('_', '/'); // 63rd char of encoding

            switch (output.Length % 4) // Pad with trailing '='s
            {
                case 0:
                    break; // No pad chars in this case
                case 2:
                    output += "==";
                    break; // Two pad chars
                case 3:
                    output += "=";
                    break; // One pad char
                default:
                    throw new ArgumentOutOfRangeException(input, "Illegal base64url string!");
            }

            var converted = Convert.FromBase64String(output); // Standard base64 decoder

            return converted;
        }
    }

}
