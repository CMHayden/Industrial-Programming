namespace webBrowserGUIApplication
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBoxURL = new System.Windows.Forms.TextBox();
            this.textBoxHtml = new System.Windows.Forms.TextBox();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonForward = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonGo = new System.Windows.Forms.Button();
            this.buttonFavourites = new System.Windows.Forms.Button();
            this.buttonHistory = new System.Windows.Forms.Button();
            this.buttonHome = new System.Windows.Forms.Button();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.listBoxHisFav = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.goHomeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setHomeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBoxFavs = new System.Windows.Forms.ListBox();
            this.labelRename = new System.Windows.Forms.Label();
            this.textBoxRename = new System.Windows.Forms.TextBox();
            this.buttonRename = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxURL
            // 
            this.textBoxURL.Location = new System.Drawing.Point(156, 11);
            this.textBoxURL.Name = "textBoxURL";
            this.textBoxURL.Size = new System.Drawing.Size(808, 20);
            this.textBoxURL.TabIndex = 0;
            // 
            // textBoxHtml
            // 
            this.textBoxHtml.AccessibleName = "html";
            this.textBoxHtml.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxHtml.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBoxHtml.Location = new System.Drawing.Point(12, 38);
            this.textBoxHtml.Multiline = true;
            this.textBoxHtml.Name = "textBoxHtml";
            this.textBoxHtml.ReadOnly = true;
            this.textBoxHtml.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxHtml.Size = new System.Drawing.Size(1048, 680);
            this.textBoxHtml.TabIndex = 1;
            // 
            // buttonBack
            // 
            this.buttonBack.AccessibleName = "Back";
            this.buttonBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBack.Enabled = false;
            this.buttonBack.Location = new System.Drawing.Point(12, 9);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(42, 23);
            this.buttonBack.TabIndex = 2;
            this.buttonBack.Text = "←";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonForward
            // 
            this.buttonForward.AccessibleDescription = "";
            this.buttonForward.AccessibleName = "forward";
            this.buttonForward.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonForward.Enabled = false;
            this.buttonForward.Location = new System.Drawing.Point(60, 9);
            this.buttonForward.Name = "buttonForward";
            this.buttonForward.Size = new System.Drawing.Size(42, 23);
            this.buttonForward.TabIndex = 3;
            this.buttonForward.Text = "→\t";
            this.buttonForward.UseVisualStyleBackColor = true;
            this.buttonForward.Click += new System.EventHandler(this.buttonForward_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.AccessibleName = "refresh";
            this.buttonRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRefresh.Location = new System.Drawing.Point(108, 9);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(42, 23);
            this.buttonRefresh.TabIndex = 4;
            this.buttonRefresh.Text = "↻";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonGo
            // 
            this.buttonGo.AccessibleName = "go";
            this.buttonGo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonGo.Location = new System.Drawing.Point(970, 9);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(42, 23);
            this.buttonGo.TabIndex = 5;
            this.buttonGo.Text = "Go";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // buttonFavourites
            // 
            this.buttonFavourites.AccessibleName = "Favourites";
            this.buttonFavourites.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonFavourites.Location = new System.Drawing.Point(1114, 9);
            this.buttonFavourites.Name = "buttonFavourites";
            this.buttonFavourites.Size = new System.Drawing.Size(42, 23);
            this.buttonFavourites.TabIndex = 7;
            this.buttonFavourites.Text = "★";
            this.buttonFavourites.UseVisualStyleBackColor = true;
            this.buttonFavourites.Click += new System.EventHandler(this.buttonFavourites_Click);
            // 
            // buttonHistory
            // 
            this.buttonHistory.AccessibleName = "History";
            this.buttonHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonHistory.Location = new System.Drawing.Point(1162, 9);
            this.buttonHistory.Name = "buttonHistory";
            this.buttonHistory.Size = new System.Drawing.Size(42, 23);
            this.buttonHistory.TabIndex = 8;
            this.buttonHistory.Text = "⏰";
            this.buttonHistory.UseVisualStyleBackColor = true;
            this.buttonHistory.Click += new System.EventHandler(this.buttonHistory_Click);
            // 
            // buttonHome
            // 
            this.buttonHome.AccessibleName = "home";
            this.buttonHome.AllowDrop = true;
            this.buttonHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonHome.Location = new System.Drawing.Point(1018, 9);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(42, 23);
            this.buttonHome.TabIndex = 10;
            this.buttonHome.Text = "🏠";
            this.buttonHome.UseVisualStyleBackColor = true;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.AccessibleDescription = "status";
            this.textBoxStatus.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBoxStatus.Location = new System.Drawing.Point(12, 724);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.ReadOnly = true;
            this.textBoxStatus.Size = new System.Drawing.Size(1048, 20);
            this.textBoxStatus.TabIndex = 11;
            // 
            // listBoxHisFav
            // 
            this.listBoxHisFav.AccessibleDescription = "history and favs";
            this.listBoxHisFav.FormattingEnabled = true;
            this.listBoxHisFav.Location = new System.Drawing.Point(1114, 38);
            this.listBoxHisFav.Name = "listBoxHisFav";
            this.listBoxHisFav.Size = new System.Drawing.Size(263, 706);
            this.listBoxHisFav.TabIndex = 12;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.goHomeToolStripMenuItem,
            this.setHomeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(68, 48);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // goHomeToolStripMenuItem
            // 
            this.goHomeToolStripMenuItem.Name = "goHomeToolStripMenuItem";
            this.goHomeToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            // 
            // setHomeToolStripMenuItem
            // 
            this.setHomeToolStripMenuItem.Name = "setHomeToolStripMenuItem";
            this.setHomeToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            // 
            // listBoxFavs
            // 
            this.listBoxFavs.AccessibleDescription = "history and favs";
            this.listBoxFavs.FormattingEnabled = true;
            this.listBoxFavs.Location = new System.Drawing.Point(1114, 39);
            this.listBoxFavs.Name = "listBoxFavs";
            this.listBoxFavs.Size = new System.Drawing.Size(263, 706);
            this.listBoxFavs.TabIndex = 13;
            // 
            // labelRename
            // 
            this.labelRename.AutoSize = true;
            this.labelRename.Enabled = false;
            this.labelRename.Location = new System.Drawing.Point(1159, 138);
            this.labelRename.Name = "labelRename";
            this.labelRename.Size = new System.Drawing.Size(172, 13);
            this.labelRename.TabIndex = 14;
            this.labelRename.Text = "Edit the name in the text box below";
            this.labelRename.Visible = false;
            // 
            // textBoxRename
            // 
            this.textBoxRename.Enabled = false;
            this.textBoxRename.Location = new System.Drawing.Point(1162, 154);
            this.textBoxRename.Name = "textBoxRename";
            this.textBoxRename.Size = new System.Drawing.Size(169, 20);
            this.textBoxRename.TabIndex = 15;
            this.textBoxRename.Visible = false;
            // 
            // buttonRename
            // 
            this.buttonRename.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRename.Enabled = false;
            this.buttonRename.Location = new System.Drawing.Point(1209, 180);
            this.buttonRename.Name = "buttonRename";
            this.buttonRename.Size = new System.Drawing.Size(75, 23);
            this.buttonRename.TabIndex = 16;
            this.buttonRename.Text = "Rename";
            this.buttonRename.UseVisualStyleBackColor = true;
            this.buttonRename.Visible = false;
            this.buttonRename.Click += new System.EventHandler(this.buttonRename_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1389, 757);
            this.Controls.Add(this.buttonRename);
            this.Controls.Add(this.textBoxRename);
            this.Controls.Add(this.labelRename);
            this.Controls.Add(this.listBoxFavs);
            this.Controls.Add(this.listBoxHisFav);
            this.Controls.Add(this.textBoxStatus);
            this.Controls.Add(this.buttonHome);
            this.Controls.Add(this.buttonHistory);
            this.Controls.Add(this.buttonFavourites);
            this.Controls.Add(this.buttonGo);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonForward);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.textBoxHtml);
            this.Controls.Add(this.textBoxURL);
            this.Name = "Form1";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxURL;
        private System.Windows.Forms.TextBox textBoxHtml;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonForward;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.Button buttonFavourites;
        private System.Windows.Forms.Button buttonHistory;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.ListBox listBoxHisFav;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem goHomeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setHomeToolStripMenuItem;
        private System.Windows.Forms.ListBox listBoxFavs;
        private System.Windows.Forms.Label labelRename;
        private System.Windows.Forms.TextBox textBoxRename;
        private System.Windows.Forms.Button buttonRename;
    }
}

