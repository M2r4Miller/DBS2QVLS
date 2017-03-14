namespace DBS
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.label1 = new System.Windows.Forms.Label();
			this.btnOpenDatabase = new System.Windows.Forms.Button();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.btnSelectAllTables = new System.Windows.Forms.Button();
			this.txtSearchString = new System.Windows.Forms.TextBox();
			this.chkBuildQVLoad = new System.Windows.Forms.CheckBox();
			this.rdoNullSearch = new System.Windows.Forms.RadioButton();
			this.rdoStringSearch = new System.Windows.Forms.RadioButton();
			this.rdoNumericSearch = new System.Windows.Forms.RadioButton();
			this.chkRecordCountsOnly = new System.Windows.Forms.CheckBox();
			this.btnSearch = new System.Windows.Forms.Button();
			this.lblColumnName = new System.Windows.Forms.Label();
			this.lblTableName = new System.Windows.Forms.Label();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.TablesListBox = new System.Windows.Forms.ListBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtResults = new System.Windows.Forms.TextBox();
			this.ssStatus = new System.Windows.Forms.StatusStrip();
			this.tsStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.cboConnString = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.btnLoadConnections = new System.Windows.Forms.Button();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.connectionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.txtFilter = new System.Windows.Forms.TextBox();
			this.rdoStartsWith = new System.Windows.Forms.RadioButton();
			this.rdoContains = new System.Windows.Forms.RadioButton();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.ssStatus.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 61);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(91, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Connection String";
			// 
			// btnOpenDatabase
			// 
			this.btnOpenDatabase.Location = new System.Drawing.Point(698, 75);
			this.btnOpenDatabase.Name = "btnOpenDatabase";
			this.btnOpenDatabase.Size = new System.Drawing.Size(92, 23);
			this.btnOpenDatabase.TabIndex = 3;
			this.btnOpenDatabase.Text = "Open";
			this.toolTip1.SetToolTip(this.btnOpenDatabase, "Open Database, Load Tables and Columns");
			this.btnOpenDatabase.UseVisualStyleBackColor = true;
			this.btnOpenDatabase.Click += new System.EventHandler(this.btnOpenDatabase_Click);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer1.Location = new System.Drawing.Point(12, 104);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.btnSelectAllTables);
			this.splitContainer1.Panel1.Controls.Add(this.txtSearchString);
			this.splitContainer1.Panel1.Controls.Add(this.chkBuildQVLoad);
			this.splitContainer1.Panel1.Controls.Add(this.rdoNullSearch);
			this.splitContainer1.Panel1.Controls.Add(this.rdoStringSearch);
			this.splitContainer1.Panel1.Controls.Add(this.rdoNumericSearch);
			this.splitContainer1.Panel1.Controls.Add(this.chkRecordCountsOnly);
			this.splitContainer1.Panel1.Controls.Add(this.btnSearch);
			this.splitContainer1.Panel1.Controls.Add(this.lblColumnName);
			this.splitContainer1.Panel1.Controls.Add(this.lblTableName);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
			this.splitContainer1.Size = new System.Drawing.Size(778, 459);
			this.splitContainer1.SplitterDistance = 123;
			this.splitContainer1.TabIndex = 3;
			// 
			// btnSelectAllTables
			// 
			this.btnSelectAllTables.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnSelectAllTables.Enabled = false;
			this.btnSelectAllTables.Location = new System.Drawing.Point(3, 97);
			this.btnSelectAllTables.Name = "btnSelectAllTables";
			this.btnSelectAllTables.Size = new System.Drawing.Size(106, 23);
			this.btnSelectAllTables.TabIndex = 6;
			this.btnSelectAllTables.Text = "Selelect All Tables";
			this.toolTip1.SetToolTip(this.btnSelectAllTables, "Select all tables for searching");
			this.btnSelectAllTables.UseVisualStyleBackColor = true;
			this.btnSelectAllTables.Click += new System.EventHandler(this.btnSelectAllTables_Click);
			// 
			// txtSearchString
			// 
			this.txtSearchString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSearchString.Location = new System.Drawing.Point(3, 25);
			this.txtSearchString.Name = "txtSearchString";
			this.txtSearchString.Size = new System.Drawing.Size(774, 20);
			this.txtSearchString.TabIndex = 5;
			this.toolTip1.SetToolTip(this.txtSearchString, "Enter what to search for here");
			// 
			// chkBuildQVLoad
			// 
			this.chkBuildQVLoad.AutoSize = true;
			this.chkBuildQVLoad.Enabled = false;
			this.chkBuildQVLoad.Location = new System.Drawing.Point(419, 4);
			this.chkBuildQVLoad.Name = "chkBuildQVLoad";
			this.chkBuildQVLoad.Size = new System.Drawing.Size(145, 17);
			this.chkBuildQVLoad.TabIndex = 4;
			this.chkBuildQVLoad.Text = "Build QV Load Statement";
			this.toolTip1.SetToolTip(this.chkBuildQVLoad, "Choose to Build QlikView style load statements - only available if Null Search is" +
        " chosen first");
			this.chkBuildQVLoad.UseVisualStyleBackColor = true;
			// 
			// rdoNullSearch
			// 
			this.rdoNullSearch.AutoSize = true;
			this.rdoNullSearch.Location = new System.Drawing.Point(333, 3);
			this.rdoNullSearch.Name = "rdoNullSearch";
			this.rdoNullSearch.Size = new System.Drawing.Size(80, 17);
			this.rdoNullSearch.TabIndex = 3;
			this.rdoNullSearch.Text = "Null Search";
			this.toolTip1.SetToolTip(this.rdoNullSearch, "Choose to ignore columns that are ALWAYS null - required to build QV Load stateme" +
        "nts");
			this.rdoNullSearch.UseVisualStyleBackColor = true;
			this.rdoNullSearch.CheckedChanged += new System.EventHandler(this.rdoNullSearch_CheckedChanged);
			// 
			// rdoStringSearch
			// 
			this.rdoStringSearch.AutoSize = true;
			this.rdoStringSearch.Checked = true;
			this.rdoStringSearch.Location = new System.Drawing.Point(238, 3);
			this.rdoStringSearch.Name = "rdoStringSearch";
			this.rdoStringSearch.Size = new System.Drawing.Size(89, 17);
			this.rdoStringSearch.TabIndex = 2;
			this.rdoStringSearch.TabStop = true;
			this.rdoStringSearch.Text = "String Search";
			this.toolTip1.SetToolTip(this.rdoStringSearch, "Choose to search for strings (default)");
			this.rdoStringSearch.UseVisualStyleBackColor = true;
			// 
			// rdoNumericSearch
			// 
			this.rdoNumericSearch.AutoSize = true;
			this.rdoNumericSearch.Location = new System.Drawing.Point(131, 3);
			this.rdoNumericSearch.Name = "rdoNumericSearch";
			this.rdoNumericSearch.Size = new System.Drawing.Size(101, 17);
			this.rdoNumericSearch.TabIndex = 1;
			this.rdoNumericSearch.Text = "Numeric Search";
			this.toolTip1.SetToolTip(this.rdoNumericSearch, "Choose to search for numeric values");
			this.rdoNumericSearch.UseVisualStyleBackColor = true;
			// 
			// chkRecordCountsOnly
			// 
			this.chkRecordCountsOnly.AutoSize = true;
			this.chkRecordCountsOnly.Location = new System.Drawing.Point(3, 3);
			this.chkRecordCountsOnly.Name = "chkRecordCountsOnly";
			this.chkRecordCountsOnly.Size = new System.Drawing.Size(121, 17);
			this.chkRecordCountsOnly.TabIndex = 0;
			this.chkRecordCountsOnly.Text = "Record Counts Only";
			this.toolTip1.SetToolTip(this.chkRecordCountsOnly, "Check for Record Counts only to be returned.");
			this.chkRecordCountsOnly.UseVisualStyleBackColor = true;
			this.chkRecordCountsOnly.CheckedChanged += new System.EventHandler(this.chkRecordCountsOnly_CheckedChanged);
			// 
			// btnSearch
			// 
			this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSearch.Enabled = false;
			this.btnSearch.Location = new System.Drawing.Point(661, 97);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(116, 23);
			this.btnSearch.TabIndex = 7;
			this.btnSearch.Text = "Perform Search";
			this.toolTip1.SetToolTip(this.btnSearch, "Perform the search");
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// lblColumnName
			// 
			this.lblColumnName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblColumnName.Location = new System.Drawing.Point(5, 67);
			this.lblColumnName.Name = "lblColumnName";
			this.lblColumnName.Size = new System.Drawing.Size(772, 19);
			this.lblColumnName.TabIndex = 3;
			// 
			// lblTableName
			// 
			this.lblTableName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblTableName.Location = new System.Drawing.Point(5, 48);
			this.lblTableName.Name = "lblTableName";
			this.lblTableName.Size = new System.Drawing.Size(772, 19);
			this.lblTableName.TabIndex = 2;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.rdoContains);
			this.splitContainer2.Panel1.Controls.Add(this.rdoStartsWith);
			this.splitContainer2.Panel1.Controls.Add(this.txtFilter);
			this.splitContainer2.Panel1.Controls.Add(this.TablesListBox);
			this.splitContainer2.Panel1.Controls.Add(this.label2);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.txtResults);
			this.splitContainer2.Size = new System.Drawing.Size(778, 332);
			this.splitContainer2.SplitterDistance = 258;
			this.splitContainer2.TabIndex = 0;
			// 
			// TablesListBox
			// 
			this.TablesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TablesListBox.FormattingEnabled = true;
			this.TablesListBox.Location = new System.Drawing.Point(0, 24);
			this.TablesListBox.Name = "TablesListBox";
			this.TablesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.TablesListBox.Size = new System.Drawing.Size(258, 303);
			this.TablesListBox.Sorted = true;
			this.TablesListBox.TabIndex = 3;
			this.toolTip1.SetToolTip(this.TablesListBox, "Choose one or more tables to search");
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(19, 77);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(101, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "What to search for?";
			// 
			// txtResults
			// 
			this.txtResults.AcceptsReturn = true;
			this.txtResults.AcceptsTab = true;
			this.txtResults.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtResults.Location = new System.Drawing.Point(0, 0);
			this.txtResults.Multiline = true;
			this.txtResults.Name = "txtResults";
			this.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtResults.Size = new System.Drawing.Size(516, 332);
			this.txtResults.TabIndex = 0;
			this.txtResults.WordWrap = false;
			// 
			// ssStatus
			// 
			this.ssStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsStatusLabel});
			this.ssStatus.Location = new System.Drawing.Point(0, 566);
			this.ssStatus.Name = "ssStatus";
			this.ssStatus.Size = new System.Drawing.Size(802, 22);
			this.ssStatus.TabIndex = 4;
			this.ssStatus.Text = "statusStrip1";
			// 
			// tsStatusLabel
			// 
			this.tsStatusLabel.Name = "tsStatusLabel";
			this.tsStatusLabel.Size = new System.Drawing.Size(0, 17);
			// 
			// cboConnString
			// 
			this.cboConnString.FormattingEnabled = true;
			this.cboConnString.Location = new System.Drawing.Point(12, 77);
			this.cboConnString.Name = "cboConnString";
			this.cboConnString.Size = new System.Drawing.Size(680, 21);
			this.cboConnString.TabIndex = 2;
			this.toolTip1.SetToolTip(this.cboConnString, "Choose connection string to open Database");
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(5, 30);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 13);
			this.label3.TabIndex = 10;
			this.label3.Text = "Password:";
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(67, 27);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Size = new System.Drawing.Size(177, 20);
			this.txtPassword.TabIndex = 0;
			this.toolTip1.SetToolTip(this.txtPassword, "Enter password necessary to decrypt connection strings");
			this.txtPassword.UseSystemPasswordChar = true;
			// 
			// btnLoadConnections
			// 
			this.btnLoadConnections.Location = new System.Drawing.Point(250, 24);
			this.btnLoadConnections.Name = "btnLoadConnections";
			this.btnLoadConnections.Size = new System.Drawing.Size(113, 23);
			this.btnLoadConnections.TabIndex = 1;
			this.btnLoadConnections.Text = "Open Connections";
			this.toolTip1.SetToolTip(this.btnLoadConnections, "Click to load encrypted connection strings");
			this.btnLoadConnections.UseVisualStyleBackColor = true;
			this.btnLoadConnections.Click += new System.EventHandler(this.btnLoadConnections_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(802, 24);
			this.menuStrip1.TabIndex = 11;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
			this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.newToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.newToolStripMenuItem.Text = "&New";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
			this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.openToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.openToolStripMenuItem.Text = "&Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.btnLoadConnections_Click);
			// 
			// toolStripSeparator
			// 
			this.toolStripSeparator.Name = "toolStripSeparator";
			this.toolStripSeparator.Size = new System.Drawing.Size(143, 6);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
			this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.saveToolStripMenuItem.Text = "&Save";
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.saveAsToolStripMenuItem.Text = "Save &As";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(143, 6);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(143, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customizeToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.connectionsToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
			this.toolsToolStripMenuItem.Text = "&Tools";
			// 
			// customizeToolStripMenuItem
			// 
			this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
			this.customizeToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
			this.customizeToolStripMenuItem.Text = "&Exclusions...";
			this.customizeToolStripMenuItem.Click += new System.EventHandler(this.customizeToolStripMenuItem_Click);
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			this.optionsToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
			this.optionsToolStripMenuItem.Text = "&Options";
			this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
			// 
			// connectionsToolStripMenuItem
			// 
			this.connectionsToolStripMenuItem.Name = "connectionsToolStripMenuItem";
			this.connectionsToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
			this.connectionsToolStripMenuItem.Text = "Connections...";
			this.connectionsToolStripMenuItem.Click += new System.EventHandler(this.btnConnections_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator5,
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "&Help";
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(113, 6);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
			this.aboutToolStripMenuItem.Text = "&About...";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// txtFilter
			// 
			this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtFilter.Location = new System.Drawing.Point(1, 3);
			this.txtFilter.Name = "txtFilter";
			this.txtFilter.Size = new System.Drawing.Size(161, 20);
			this.txtFilter.TabIndex = 0;
			this.txtFilter.Text = "Filter...";
			this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
			this.txtFilter.Enter += new System.EventHandler(this.txtFilter_Enter);
			this.txtFilter.Leave += new System.EventHandler(this.txtFilter_Leave);
			// 
			// rdoStartsWith
			// 
			this.rdoStartsWith.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.rdoStartsWith.AutoSize = true;
			this.rdoStartsWith.Checked = true;
			this.rdoStartsWith.Location = new System.Drawing.Point(164, 5);
			this.rdoStartsWith.Name = "rdoStartsWith";
			this.rdoStartsWith.Size = new System.Drawing.Size(43, 17);
			this.rdoStartsWith.TabIndex = 1;
			this.rdoStartsWith.TabStop = true;
			this.rdoStartsWith.Text = "SW";
			this.rdoStartsWith.UseVisualStyleBackColor = true;
			// 
			// rdoContains
			// 
			this.rdoContains.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.rdoContains.AutoSize = true;
			this.rdoContains.Location = new System.Drawing.Point(212, 5);
			this.rdoContains.Name = "rdoContains";
			this.rdoContains.Size = new System.Drawing.Size(41, 17);
			this.rdoContains.TabIndex = 2;
			this.rdoContains.TabStop = true;
			this.rdoContains.Text = "Cnt";
			this.rdoContains.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(802, 588);
			this.Controls.Add(this.btnLoadConnections);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.cboConnString);
			this.Controls.Add(this.ssStatus);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.btnOpenDatabase);
			this.Controls.Add(this.label1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "Database Search / QV Load Script Utility";
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel1.PerformLayout();
			this.splitContainer2.Panel2.ResumeLayout(false);
			this.splitContainer2.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			this.ssStatus.ResumeLayout(false);
			this.ssStatus.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnOpenDatabase;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.StatusStrip ssStatus;
		private System.Windows.Forms.ToolStripStatusLabel tsStatusLabel;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.Label lblColumnName;
		private System.Windows.Forms.Label lblTableName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtResults;
		private System.Windows.Forms.CheckBox chkRecordCountsOnly;
		private System.Windows.Forms.RadioButton rdoStringSearch;
		private System.Windows.Forms.RadioButton rdoNumericSearch;
		private System.Windows.Forms.RadioButton rdoNullSearch;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.ListBox TablesListBox;
		private System.Windows.Forms.CheckBox chkBuildQVLoad;
		private System.Windows.Forms.TextBox txtSearchString;
		private System.Windows.Forms.Button btnSelectAllTables;
		private System.Windows.Forms.ComboBox cboConnString;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.Button btnLoadConnections;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem connectionsToolStripMenuItem;
		private System.Windows.Forms.TextBox txtFilter;
		private System.Windows.Forms.RadioButton rdoContains;
		private System.Windows.Forms.RadioButton rdoStartsWith;
	}
}

