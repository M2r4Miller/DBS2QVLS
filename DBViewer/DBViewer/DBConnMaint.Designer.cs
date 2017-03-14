namespace DBS
{
	partial class DBConnMaint
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBConnMaint));
			this.lstConnectionsList = new System.Windows.Forms.ListBox();
			this.txtCurrentConnection = new System.Windows.Forms.TextBox();
			this.btnBuildConnection = new System.Windows.Forms.Button();
			this.btnAddConnection = new System.Windows.Forms.Button();
			this.btnDeleteConnection = new System.Windows.Forms.Button();
			this.btnSaveConnections = new System.Windows.Forms.Button();
			this.btnCloseForm = new System.Windows.Forms.Button();
			this.UpdateLabel = new System.Windows.Forms.Label();
			this.btnUpdateConnection = new System.Windows.Forms.Button();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.SuspendLayout();
			// 
			// lstConnectionsList
			// 
			this.lstConnectionsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lstConnectionsList.FormattingEnabled = true;
			this.lstConnectionsList.Location = new System.Drawing.Point(13, 62);
			this.lstConnectionsList.Name = "lstConnectionsList";
			this.lstConnectionsList.Size = new System.Drawing.Size(660, 316);
			this.lstConnectionsList.TabIndex = 9;
			this.lstConnectionsList.SelectedIndexChanged += new System.EventHandler(this.ConnectionsList_SelectedIndexChanged);
			// 
			// txtCurrentConnection
			// 
			this.txtCurrentConnection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCurrentConnection.Location = new System.Drawing.Point(13, 38);
			this.txtCurrentConnection.Name = "txtCurrentConnection";
			this.txtCurrentConnection.Size = new System.Drawing.Size(578, 20);
			this.txtCurrentConnection.TabIndex = 7;
			this.toolTip1.SetToolTip(this.txtCurrentConnection, "Current Connection String");
			this.txtCurrentConnection.Enter += new System.EventHandler(this.CurrentConnection_Enter);
			this.txtCurrentConnection.Leave += new System.EventHandler(this.CurrentConnection_Leave);
			// 
			// btnBuildConnection
			// 
			this.btnBuildConnection.Location = new System.Drawing.Point(13, 9);
			this.btnBuildConnection.Name = "btnBuildConnection";
			this.btnBuildConnection.Size = new System.Drawing.Size(75, 23);
			this.btnBuildConnection.TabIndex = 2;
			this.btnBuildConnection.Text = "Builder";
			this.toolTip1.SetToolTip(this.btnBuildConnection, "Opens the SQL Server Connection String Builder");
			this.btnBuildConnection.UseVisualStyleBackColor = true;
			this.btnBuildConnection.Click += new System.EventHandler(this.BuildConnection_Click);
			// 
			// btnAddConnection
			// 
			this.btnAddConnection.Location = new System.Drawing.Point(95, 9);
			this.btnAddConnection.Name = "btnAddConnection";
			this.btnAddConnection.Size = new System.Drawing.Size(75, 23);
			this.btnAddConnection.TabIndex = 3;
			this.btnAddConnection.Text = "Add";
			this.toolTip1.SetToolTip(this.btnAddConnection, "Adds the current connection string to the list of connections");
			this.btnAddConnection.UseVisualStyleBackColor = true;
			this.btnAddConnection.Click += new System.EventHandler(this.AddConnection_Click);
			// 
			// btnDeleteConnection
			// 
			this.btnDeleteConnection.Location = new System.Drawing.Point(177, 9);
			this.btnDeleteConnection.Name = "btnDeleteConnection";
			this.btnDeleteConnection.Size = new System.Drawing.Size(75, 23);
			this.btnDeleteConnection.TabIndex = 4;
			this.btnDeleteConnection.Text = "Delete";
			this.toolTip1.SetToolTip(this.btnDeleteConnection, "Delete current connection string from list");
			this.btnDeleteConnection.UseVisualStyleBackColor = true;
			this.btnDeleteConnection.Click += new System.EventHandler(this.DeleteConnection_Click);
			// 
			// btnSaveConnections
			// 
			this.btnSaveConnections.Location = new System.Drawing.Point(259, 9);
			this.btnSaveConnections.Name = "btnSaveConnections";
			this.btnSaveConnections.Size = new System.Drawing.Size(75, 23);
			this.btnSaveConnections.TabIndex = 5;
			this.btnSaveConnections.Text = "Save";
			this.toolTip1.SetToolTip(this.btnSaveConnections, "Save all connection strings, encrypting them using the password provided");
			this.btnSaveConnections.UseVisualStyleBackColor = true;
			this.btnSaveConnections.Click += new System.EventHandler(this.SaveConnections_Click);
			// 
			// btnCloseForm
			// 
			this.btnCloseForm.Location = new System.Drawing.Point(341, 9);
			this.btnCloseForm.Name = "btnCloseForm";
			this.btnCloseForm.Size = new System.Drawing.Size(75, 23);
			this.btnCloseForm.TabIndex = 6;
			this.btnCloseForm.Text = "Close";
			this.toolTip1.SetToolTip(this.btnCloseForm, "Saves connections and closes the form");
			this.btnCloseForm.UseVisualStyleBackColor = true;
			this.btnCloseForm.Click += new System.EventHandler(this.CloseForm_Click);
			// 
			// UpdateLabel
			// 
			this.UpdateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.UpdateLabel.AutoSize = true;
			this.UpdateLabel.Location = new System.Drawing.Point(506, 6);
			this.UpdateLabel.Name = "UpdateLabel";
			this.UpdateLabel.Size = new System.Drawing.Size(167, 26);
			this.UpdateLabel.TabIndex = 10;
			this.UpdateLabel.Text = "Click Add Button to add new or\r\nUpdate Button to Change Existing";
			this.UpdateLabel.Visible = false;
			// 
			// btnUpdateConnection
			// 
			this.btnUpdateConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnUpdateConnection.Enabled = false;
			this.btnUpdateConnection.Location = new System.Drawing.Point(598, 35);
			this.btnUpdateConnection.Name = "btnUpdateConnection";
			this.btnUpdateConnection.Size = new System.Drawing.Size(75, 23);
			this.btnUpdateConnection.TabIndex = 8;
			this.btnUpdateConnection.Text = "Update";
			this.toolTip1.SetToolTip(this.btnUpdateConnection, "Update List of connection strings with what is in textbox to left");
			this.btnUpdateConnection.UseVisualStyleBackColor = true;
			this.btnUpdateConnection.Click += new System.EventHandler(this.UpdateConnection_Click);
			// 
			// DBConnMaint
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(685, 396);
			this.Controls.Add(this.UpdateLabel);
			this.Controls.Add(this.btnUpdateConnection);
			this.Controls.Add(this.btnCloseForm);
			this.Controls.Add(this.btnSaveConnections);
			this.Controls.Add(this.btnDeleteConnection);
			this.Controls.Add(this.btnAddConnection);
			this.Controls.Add(this.btnBuildConnection);
			this.Controls.Add(this.txtCurrentConnection);
			this.Controls.Add(this.lstConnectionsList);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "DBConnMaint";
			this.Text = "Database Connection Maintenance";
			this.Load += new System.EventHandler(this.DBConnMaint_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox lstConnectionsList;
		private System.Windows.Forms.TextBox txtCurrentConnection;
		private System.Windows.Forms.Button btnBuildConnection;
		private System.Windows.Forms.Button btnAddConnection;
		private System.Windows.Forms.Button btnDeleteConnection;
		private System.Windows.Forms.Button btnSaveConnections;
		private System.Windows.Forms.Button btnCloseForm;
		private System.Windows.Forms.Label UpdateLabel;
		private System.Windows.Forms.Button btnUpdateConnection;
		private System.Windows.Forms.ToolTip toolTip1;
	}
}