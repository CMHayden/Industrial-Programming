using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

        /// <summary>
        /// Initializes components
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////
        //                                  On Load Methods                                            //
        /////////////////////////////////////////////////////////////////////////////////////////////////

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadFavourites();
            LoadHome();
            LoadHistory();
            url = home;
            getPage(home);
        }

        /// <summary>
        /// Loads favourites from text file.
        /// 
        /// Tries to load file into a var called array.
        /// loops through every second line in array
        ///     adds current line and next line as key and value to favourites dictionary
        ///  
        /// Catches error of not finding the specified txt file and displays a message box with an error message.
        /// </summary>
        public void LoadFavourites()
        {
            try
            {
                var array = File.ReadAllLines(".//favourites.txt");
                for (var i = 0; i < array.Length; i += 2)
                {
                    favourites.Add(array[i], array[i + 1]);
                }
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("No favourites to load. If you should have favourites, please check the directory is correct.");
            }

        }

        /// <summary>
        /// Loads home from text file.
        /// 
        /// Tries to load file into a var called array.
        /// sets first line as new home.
        ///  
        /// Catches error of not finding the specified txt file and displays a message box with an error message.
        /// </summary>
        public void LoadHome()
        {
            try
            {
                var array = File.ReadAllLines(".//home.txt");
                home = array[0];
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("No favourites to load. If you should have favourites, please check the directory is correct.");
            }

        }

        /// <summary>
        /// Loads history from a text file
        /// 
        /// Tries to load file into a var called array.
        /// loops through every second line in array
        ///     adds current line and next line as key and value to history dictionary
        ///  
        /// Catches error of not finding the specified txt file and displays a message box with an error message.
        /// </summary>
        public void LoadHistory()
        {
            try
            {
                var array = File.ReadAllLines(".//history.txt");
                for (var i = 0; i < array.Length; i += 2)
                {
                    history.Add(array[i], array[i + 1]);
                }
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("No history to load. If you should have history, please check the directory is correct.");
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////
        //                                  Event Listeners                                            //
        /////////////////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// Listens for the go button to be clicked, and calls the <c>goToURL()</c> method when pressed.
        /// </summary>
        /// <param name="sender">Reference to the go button.</param>
        /// <param name="e">Object of the event being handled, in this case, Click</param>
        private void buttonGo_Click(object sender, EventArgs e)
        {
            goToURL();
        }

        /// <summary>
        /// Listens for the back button to be clicked, and calls the <c>goBack()</c> method when pressed.
        /// </summary>
        /// <param name="sender">Reference to the back button.</param>
        /// <param name="e">Object of the event being handled, in this case, Click.</param>
        private void buttonBack_Click(object sender, EventArgs e)
        {
            goBack();
        }

        /// <summary>
        /// Listens for the forward button to be clicked, and calls the <c>goForward()</c> method when pressed.
        /// </summary>
        /// <param name="sender">Reference to the forward button.</param>
        /// <param name="e">Object of the event being handled, in this case, Click</param>
        private void buttonForward_Click(object sender, EventArgs e)
        {
            goForward();
        }

        /// <summary>
        /// Listens for the refresh button to be clicked, and calls the <c>refreshPage()</c> method when pressed.
        /// </summary>
        /// <param name="sender">Reference to the refresh button.</param>
        /// <param name="e">Object of the event being handled, in this case, Click</param>
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            refreshPage();
        }

        /// <summary>
        /// Listens for the history button to be clicked, and calls the <c>displayHistory()</c> method when pressed.
        /// </summary>
        /// <param name="sender">Reference to the history button.</param>
        /// <param name="e">Object of the event being handled, in this case, Click</param>
        private void buttonHistory_Click(object sender, EventArgs e)
        {
            displayHistory();
        }

        /// <summary>
        /// Listens for a list item in <c>listBoxHisFav</c> to be double clicked. When double clicked: 
        ///     calls <c>displayHTML()</c> with the prameter of the value of the elected element. In this case, the URL tied to the title.
        ///     sets the tet in <c>textBoxURL</c> which is the URL box, to the url of the selected value.
        /// </summary>
        /// <param name="sender">Reference to the item selected in the lit box</param>
        /// <param name="e">Object of the event being handled, in this case, Double Click</param>
        private void listBoxHisFav_DoubleClick(object sender, EventArgs e)
        {
            displayHTML(listBoxHisFav.GetItemText(listBoxHisFav.SelectedValue));
            textBoxURL.Text = listBoxHisFav.GetItemText(listBoxHisFav.SelectedValue);
        }

        /// <summary>
        /// Listens for the home button to be clicked. When clicked it:
        ///     clears <c>contextMenuStrip1</c> to create a blank menu.
        ///     adds 'go home' as an item to <c>contextMenuStrip1</c>
        ///     adds 'set home' as an item to <c>contextMenuStrip1</c>
        ///     shows <c>contextMenuStrip1</c> at a new location to the bottom of the home button
        /// </summary>
        /// <param name="sender">Reference to the home button.</param>
        /// <param name="e">Object of the event being handled, in this case, Click</param>
        private void buttonHome_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Items.Clear();
            contextMenuStrip1.Items.Add("Go home");
            contextMenuStrip1.Items.Add("Set home");
            contextMenuStrip1.Show(buttonHome, new Point(0, buttonHome.Height));
        }

        /// <summary>
        /// Listens for the favourites button to be clicked. When clicked it:
        ///     clears <c>contextMenuStrip1</c> of all items.
        ///     checks if current URL is already a favourite. If it isn't:
        ///         adds "Add to favourites" as a new item to <c>contextMenuStrip1</c>
        ///     if it is then instead it adds "remove from favourites" as a new item to <c>contextMenuStrip1</c>
        ///     checks that favourites isn't empty. If it isn't it adds "view favourites" to <c>contextMenuStrip1</c>
        ///     shows <c>contextMenuStrip1</c> at a new location to the bottom of the favourites button
        /// </summary>
        /// <param name="sender">Reference to the favourite button</param>
        /// <param name="e">Object of the event being handled, in this case, Click</param>
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

        /// <summary>
        /// Listens for an item in <c>listBoxFavs</c> to be clicked. When clicked it:
        ///     clears <c>contextMenuStrip1</c> to ensure it is empty of items.
        ///     Adds new items:
        ///         'Go to url'
        ///         'Rename favourite'
        ///         'Remove from favourites'
        ///     to the <c>contextMenuStrip1</c>
        ///     shows the menu at a new location inside <c>listBoxFavs</c>
        /// </summary>
        /// <param name="sender">Reference to the selected item from <c>listBoxFavs</c></param>
        /// <param name="e">Object of the event being handled, in this case, Click</param>
        private void listBoxFavs_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Items.Clear();
            contextMenuStrip1.Items.Add("Go to url");
            contextMenuStrip1.Items.Add("Rename favourite");
            contextMenuStrip1.Items.Add("Remove from favourites");
            contextMenuStrip1.Show(listBoxFavs, new Point(0, listBoxFavs.Top));
        }

        /// <summary>
        /// Allows for changing the name of a favourite.
        /// listens for <c>buttonRename</c> to be clicked. When clicked it
        ///     takes new name for favourite from <c>textBoxRename</c>
        ///     temporarily stores the url value associated with selected item
        ///     calls <c>removeFav()</c> with the selected value as a parameter
        ///     adds new record to <c>favourites</c> with parameters newName and oldURL
        ///     Enures <c>buttonRename</c>, <c>textBoxRename</c> and <c>labelRename</c> are disabled and not visible.
        /// </summary>
        /// <param name="sender">Reference to the <c>buttonRename</c></param>
        /// <param name="e">Object of the event being handled, in this case, Click</param>
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

        /// <summary>
        /// Listens for an item being clicked in the <c>contextMenuStrip1</c>. When an item is clicked, if the option clicked was:
        ///    "Go home" - Calls <c>goHome()</c> method.
        ///    "Set home" - sets the home variable to the current url.
        ///    "Add to favourites" - adds new element to the favourites dictionary. Uing title as key and url as value.
        ///    "View favourites" - calls <c>displayFavs()</c> method.
        ///    "Remove from favourites" - calls <c>removeFavs()</c> with the parameter of the value of the selected item from <c>listBoxFavs</c>
        ///    "Go to url":
        ///         Calls <c>addToBack()</c> method
        ///         calls <c>displayHTML()</c> method with <param>selected value from item from favourites list</param>
        ///         sets the <c>tetBoxURL</c> text to the value from the selected item, which is the URL.
        ///     "Rename favourite" - sets <c>buttonRename</c>, <c>textBoxRename</c>, <c>labelRename</c> to visible and enabled
        /// </summary>
        /// <param name="sender">Reference to the item clicked</param>
        /// <param name="e">Object of the event being handled, in this case, clicked</param>
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "Go home":
                    goHome();
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
                    addToBack();
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

        /// <summary>
        /// Handler for when a key is pressed within the url text box.
        /// 
        /// if the pressed key is enter calls <c>goToURL()</c> method.
        /// </summary>
        /// <param name="sender">Reference to the key being pressed</param>
        /// <param name="e">Object of the event being handled, ie, key down</param>
        private void textBoxURL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                goToURL();
            }
        }

        /// <summary>
        /// Handler for when a key is pressed anywhere in the application.
        /// 
        /// Checks if the ctrl key has been pressed if so then checks if h, f, i, or r has also been pressed.
        ///     h - displays history
        ///     f - displays favourites
        ///     i - goes home
        ///     r - refreshes page
        /// </summary>
        /// <param name="sender">Reference to the key being pressed down</param>
        /// <param name="e">Object of the event being handled, ie, keydown</param>
        private void form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.H:
                        displayHistory();
                        break;

                    case Keys.F:
                        displayFavs();
                        break;

                    case Keys.I:
                        goHome();
                        break;

                    case Keys.R:
                        refreshPage();
                        break;
                }
            }
        }


        /////////////////////////////////////////////////////////////////////////////////////////////////
        //                                 Functions and Methods                                       //
        /////////////////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// Goes forward in navigation.
        /// Pops from forward stack storing the return as <c>temp</c> which is then pushed to back.
        /// Checks if forward is empty, if so dissables the forward button.
        /// Enables back button.
        /// Calls <c>displayHTML</c> with the <para>temp</para>
        /// </summary>
        public void goForward()
        {
            string temp = forward.Pop().ToString();
            back.Push(temp);
            if (forward.Count == 0)
                buttonForward.Enabled = false;
            buttonBack.Enabled = true;
            displayHTML(temp);
        }

        /// <summary>
        /// Goes back to previous page.
        /// Pops from back stack and stores as temp.
        /// Checks if back is empty and if so dissables back button.
        /// Pushes temp to forward stack and enables forward button.
        /// calls <c>displayHTML</c> with <para>temp</para>
        /// </summary>
        public void goBack()
        {
            string temp = back.Pop().ToString();
            if (back.Count == 0)
                buttonBack.Enabled = false;
            forward.Push(temp);
            buttonForward.Enabled = true;
            displayHTML(temp);
        }

        /// <summary>
        /// Removes an element from favourites
        /// 
        /// Finds the record to be removed from dictionary which is the directory who's value matches the parameter val and stores it as remove.
        /// removes the key associated to remove.
        /// hides the favourites list box.
        /// </summary>
        /// <param name="val">URL of a title,url combo stored in favourites.</param>
        public void removeFav(string val)
        {
            var remove = favourites.First(kvp => kvp.Value == val);

            favourites.Remove(remove.Key);
            listBoxFavs.Visible = false;
            
        }

        /// <summary>
        /// Refreshes the current page.
        /// 
        /// Sets the <c>textBoxHtml</c> to empty
        /// calls <c>getPage</c> with parameter url which is the current pages url.
        /// </summary>
        public void refreshPage()
        {
            textBoxHtml.Text = string.Empty;
            getPage(url);
        }

        /// <summary>
        /// Goes to the page set as home.
        /// 
        /// calls <c>addToBack()</c> method to add current url to back stack.
        /// sets the <c>textBoxURL</c> text to show the home's URL.
        /// calls <c>displayHTML()</c> passing the home url as a parameter.
        /// </summary>
        public void goHome()
        {
            addToBack();
            textBoxURL.Text = home;
            displayHTML(home);
        }

        /// <summary>
        /// gets the URL of the page and tests to ensure it is valid
        /// 
        /// tries to create a <c>new Uri</c> of the url. If it fails it will throw an exception. 
        ///     displays the HTML of the given url
        /// 
        /// catches errors and displays an error in the <c>textBoxHTML</c>.
        /// </summary>
        /// <param name="url">URL of the page it is trying to get</param>
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

        /// <summary>
        /// Displays favourites
        /// 
        /// Ensures the history listbox <c>listBoxHisFav</c> is not visible.
        /// Ensures the favourites listbox <c>listBoxFavs</c> is visible.
        /// Refreshes the favourites listbox.
        /// checks if there are no favourites, in which case a message is displayed in the <c>textBoxStatus</c>
        /// 
        /// Sets the data soure for the favourites listbox to the favourites dictionary.
        /// Sets the display to be the key, and the value to the value of the favourites dictionary.
        /// Adds an event handler for clicking on favourites listbox elements.
        /// </summary>
        public void displayFavs()
        {
            listBoxHisFav.Visible = false;
            listBoxFavs.Visible = true;
            listBoxFavs.Refresh();
            if(favourites.Count == 0)
            {
                textBoxStatus.Text = "No favourites available. Please add to favs and try again";
                return;
            }
            listBoxFavs.DataSource = new BindingSource(favourites, null);
            listBoxFavs.DisplayMember = "key";
            listBoxFavs.ValueMember = "value";
            listBoxFavs.Click += new EventHandler(listBoxFavs_Click);
        }

        /// <summary>
        /// Displays the history listbox
        /// 
        /// Ensures the favourites listbox is not visible.
        /// Ensures the history listbox is visible
        /// Sets the data source of the listbox to the history dictionary with the key as the display member and the value as the value member
        /// Adds an event listener for double clicking on an item.
        /// </summary>
        public void displayHistory()
        {
            listBoxFavs.Visible = false;
            listBoxHisFav.Visible = true;
            listBoxHisFav.Refresh();
            listBoxHisFav.DataSource = new BindingSource(history, null);
            listBoxHisFav.DisplayMember = "key";
            listBoxHisFav.ValueMember = "value";
            listBoxHisFav.DoubleClick += new EventHandler(listBoxHisFav_DoubleClick);
        }

        /// <summary>
        /// Gets and displays the html of a given url.
        /// 
        /// Allows access to https urls with the security protocol types.
        /// Creates a new web request of the URL and tries:
        ///     get a response
        ///     store the response of the HTML code as html
        ///     uses regex to find the title from the title tags.
        ///     sets the top of the form to the title, the status text box to the status code and the html text box to the html.
        ///     Checks if the current page is in history and if it is not then it adds it to histry.
        ///     
        /// Catches web exceptions and displays the error codes in the status text box.
        /// </summary>
        /// <param name="url">URL of the page we want to get</param>
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

        /// <summary>
        /// adds a new url to back stack and enables back button
        /// </summary>
        public void addToBack()
        {
            back.Push(url);
            buttonBack.Enabled = true;
        }

        /// <summary>
        /// goes to a new url
        /// 
        /// calls <c>addToBack</c> to add current url to back, clears the forward stack and disables the foward button.
        /// gets new url from the url text box and gets the page associated with the given url
        /// </summary>
        public void goToURL()
        {
            addToBack();
            forward.Clear();
            buttonForward.Enabled = false;
            url = textBoxURL.Text;
            getPage(url);
        }
    } 
}
