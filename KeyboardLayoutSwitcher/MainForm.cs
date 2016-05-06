using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Configuration;

namespace KeyboardLayoutSwitcher
{
    public partial class MainForm : Form
    {
        public static readonly string METADATA_ENDPOINT = ConfigurationManager.AppSettings["metadata_endpoint"]; //"http://gw/skytap";
        public static readonly string REST_ENDPOINT = ConfigurationManager.AppSettings["rest_endpoint"]; //"http://172.16.150.1:3000/api/participant_preferences";
        public static readonly Dictionary<string, string> KEYBOARD_LAYOUTS = new Dictionary<string, string>
        {
            { "Dutch-Belgium", "nl-be" },
            { "English (US)", "us" },
            { "English (UK)", "uk" },
            { "Finnish", "fi" },
            { "French", "fr" },
            { "French-Belgium", "fr-be" },
            { "French-Switzerland", "fr-ch" },
            { "German", "de" },
            { "German-Switzerland", "de-ch" },
            { "Icelandic", "is" },
            { "Italian", "it" },
            { "Japanese", "jp" },
            { "Norwegian", "no" },
            { "Polish", "pt" },
            { "Spanish", "es" }
        };

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            keyboardLayoutCmb.Items.AddRange(KEYBOARD_LAYOUTS.Keys.ToArray());
        }

        private void setLayoutBtn_Click(object sender, EventArgs e)
        {
            Go();
        }

        private string GetKeyboardLayoutCode() 
        {
            object selectedItem = keyboardLayoutCmb.SelectedItem;

            return selectedItem == null ? null : KEYBOARD_LAYOUTS[selectedItem.ToString()];
        }

        private string GetMetadata()
        {
            System.Net.WebClient client = new System.Net.WebClient();
            client.Headers.Add("content-type", "application/json");
            return client.DownloadString(METADATA_ENDPOINT);
        }

        private string GetPublishedURLFromMetadata(string metadata)
        {
            Regex pattern = new Regex(@".*(?<publishedURL>https\:\/\/cloud\.skytap\.com\/vms\/[a-z0-9]+\/desktops)");
            Match match = pattern.Match(metadata);
            return match.Groups["publishedURL"].Value;
        }

        private string GetConfigIDFromMetadata(string metadata)
        {
            Regex pattern = new Regex(@".*https\:\/\/cloud\.skytap\.com\/configurations\/(?<configID>[0-9]+)\/");
            Match match = pattern.Match(metadata);
            return match.Groups["configID"].Value;
        }

        private void Go()
        {
            try
            {
                string metadata = GetMetadata();
                string pubURL = GetPublishedURLFromMetadata(metadata);
                string configID = GetConfigIDFromMetadata(metadata);
                string keyboardLayoutCode = GetKeyboardLayoutCode();

                if (String.IsNullOrEmpty(keyboardLayoutCode))
                {
                    return;
                }

                string requestBody = "{\"participant\":{\"keyboard_layout\":\"" +
                    keyboardLayoutCode +
                    "\", \"published_url\":\"" +
                    pubURL +
                    "\", \"skytap_configuration_skytap_id\":\"" +
                    configID + 
                    "\"}}";
                System.Net.WebClient client = new System.Net.WebClient();
                client.Headers.Add("content-type", "application/json");
                string s = Encoding.ASCII.GetString(
                    client.UploadData(
                        REST_ENDPOINT,
                        "PUT",
                        Encoding.Default.GetBytes(requestBody)
                    )
                );

                MessageBox.Show("The change has been submitted. Please stand by while your environment restarts.");
            }
            catch (Exception e)
            {
                MessageBox.Show("An error occurred: " + e.Message + "\n\n" + e.StackTrace);
            }
        }
    }
}