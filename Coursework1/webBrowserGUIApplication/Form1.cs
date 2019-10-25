using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;

namespace webBrowserGUIApplication
{
    public partial class Form1 : Form
    {

        public static Stack back = new Stack();
        public static Stack forward = new Stack();
        public static string home = "http://www.callumhayden.com";
        public static string url = home;
        public static string title;
        public static IDictionary<string, string> history = new Dictionary<string,string>();
        public static Dictionary<string, string> favourites = new Dictionary<string, string>();


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getPage(home);
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            back.Push(url);
            buttonBack.Enabled = true;
            url = textBoxURL.Text;
            getPage(url);
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            string temp = back.Pop().ToString();
            if (back.Count == 0)
                buttonBack.Enabled = false;
            forward.Push(temp);
            buttonForward.Enabled = true;
            displayHTML(temp);
        }

        private void buttonForward_Click(object sender, EventArgs e)
        {
            string temp = forward.Pop().ToString();
            back.Push(temp);
            if (forward.Count == 0)
                buttonForward.Enabled = false;
            buttonBack.Enabled = true;
            displayHTML(temp);
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            textBoxHtml.Text = string.Empty;
            getPage(url);
        }

        private void buttonHistory_Click(object sender, EventArgs e)
        {
            listBoxFavs.Visible = false;
            listBoxHisFav.Visible = true;
            displayHistory();
        }

        private void listBoxHisFav_DoubleClick(object sender, EventArgs e)
        {
            displayHTML(listBoxHisFav.GetItemText(listBoxHisFav.SelectedValue));
            textBoxURL.Text = listBoxHisFav.GetItemText(listBoxHisFav.SelectedValue);
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Items.Clear();
            contextMenuStrip1.Items.Add("Go home");
            contextMenuStrip1.Items.Add("Set home");
            contextMenuStrip1.Show(buttonHome, new Point(0, buttonHome.Height));
        }

        private void buttonFavourites_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Items.Clear();
            if (!favourites.ContainsValue(url))
            {
                contextMenuStrip1.Items.Add("Add to favourites");
            } else
            {
                contextMenuStrip1.Items.Add("Remove from favourites");
            }
            if(!(favourites.Count == 0))
                contextMenuStrip1.Items.Add("View favourites");
            contextMenuStrip1.Show(buttonFavourites, new Point(0, buttonHome.Height));
        }

        private void listBoxFavs_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Items.Clear();
            contextMenuStrip1.Items.Add("Go to url");
            contextMenuStrip1.Items.Add("Rename favourite");
            contextMenuStrip1.Items.Add("Remove from favourites");
            contextMenuStrip1.Show(listBoxFavs, new Point(0, listBoxFavs.Top));
        }

        private void buttonRename_Click(object sender, EventArgs e)
        {
            string newName = textBoxRename.Text;
            string oldUrl = listBoxFavs.GetItemText(listBoxFavs.SelectedValue);
            removeFav(listBoxFavs.GetItemText(listBoxFavs.SelectedValue));
            favourites.Add(newName, oldUrl);

            buttonRename.Enabled = false;
            buttonRename.Visible = false;
            textBoxRename.Enabled = false;
            textBoxRename.Visible = false;
            labelRename.Enabled = false;
            labelRename.Visible = false;



        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "Go home":
                    textBoxURL.Text = home;
                    displayHTML(home);
                    break;

                case "Set home":
                    home = url;
                    break;

                case "Add to favourites":
                    favourites.Add(title, url);
                    break;

                case "View favourites":
                    displayFavs();
                    break;

                case "Remove from favourites":

                    removeFav(listBoxFavs.GetItemText(listBoxFavs.SelectedValue));
                    break;

                case "Go to url":
                    displayHTML(listBoxFavs.GetItemText(listBoxFavs.SelectedValue));
                    textBoxURL.Text = listBoxFavs.GetItemText(listBoxFavs.SelectedValue);
                    break;

                case "Rename favourite":
                    buttonRename.Enabled = true;
                    buttonRename.Visible = true;
                    textBoxRename.Enabled = true;
                    textBoxRename.Visible = true;
                    labelRename.Enabled = true;
                    labelRename.Visible = true;
                    break;
            }
        }







        /*
         * Shit that does mad tingz blud
         */

        public void removeFav(string val)
        {
            var remove = favourites.First(kvp => kvp.Value == val);

            favourites.Remove(remove.Key);
            listBoxFavs.Visible = false;
            
        }

        public void getPage(string url)
        {
            try
            {
                new Uri(url);
                displayHTML(url);
            }
            catch
            {
                textBoxHtml.Text = "Error: invalid URL. Please ensure you use 'http://' at the start of your url";
            }

        }

        public void displayFavs()
        {
            listBoxHisFav.Visible = false;
            listBoxFavs.Visible = true;
            listBoxFavs.Refresh();
            listBoxFavs.DataSource = new BindingSource(favourites, null);
            listBoxFavs.DisplayMember = "key";
            listBoxFavs.ValueMember = "value";
            listBoxFavs.Click += new EventHandler(listBoxFavs_Click);
        }

        public void displayHistory()
        {
            listBoxHisFav.Refresh();
            listBoxHisFav.DataSource = new BindingSource(history, null);
            listBoxHisFav.DisplayMember = "key";
            listBoxHisFav.ValueMember = "value";
            listBoxHisFav.DoubleClick += new EventHandler(listBoxHisFav_DoubleClick);
        }

        public void displayHTML(string url)
        {
            string html = string.Empty;

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                   | SecurityProtocolType.Tls11
                   | SecurityProtocolType.Tls12
                   | SecurityProtocolType.Ssl3;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Console.WriteLine(response.StatusCode);
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                {
                    html = reader.ReadToEnd();
                }

                title = Regex.Match(html, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>",
                    RegexOptions.IgnoreCase).Groups["Title"].Value;

                Text = title;
                textBoxStatus.Text = response.StatusCode.ToString();
                textBoxHtml.Text = html.ToString();
                if (!history.ContainsKey(title))
                    history.Add(title, url);

            }
            catch (WebException e)
            {
                textBoxHtml.Text = String.Empty;
                textBoxStatus.Text = e.Message;
            }
        }
    }
    
}
