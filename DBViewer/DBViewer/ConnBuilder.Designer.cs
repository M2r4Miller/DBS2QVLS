namespace DBS
{
	partial class ConnBuilder
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnBuilder));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtServer = new System.Windows.Forms.TextBox();
			this.txtDatabase = new System.Windows.Forms.TextBox();
			this.txtUserID = new System.Windows.Forms.TextBox();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.txtConnDisplay = new System.Windows.Forms.TextBox();
			this.btnTest = new System.Windows.Forms.Button();
			this.btnAccept = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.rdoTrustedYes = new System.Windows.Forms.RadioButton();
			this.rdoTrustedNo = new System.Windows.Forms.RadioButton();
			this.label6 = new System.Windows.Forms.Label();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.rdoClarityNo = new System.Windows.Forms.RadioButton();
			this.rdoClarityYes = new System.Windows.Forms.RadioButton();
			this.label7 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label8 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(71, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Server:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(56, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Database:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 110);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(103, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Trusted Connection:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(66, 140);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(46, 13);
			this.label4.TabIndex = 3;
			this.label4.Text = "User ID:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(56, 166);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(56, 13);
			this.label5.TabIndex = 4;
			this.label5.Text = "Password:";
			// 
			// txtServer
			// 
			this.txtServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtServer.Location = new System.Drawing.Point(119, 20);
			this.txtServer.Name = "txtServer";
			this.txtServer.Size = new System.Drawing.Size(215, 20);
			this.txtServer.TabIndex = 0;
			this.toolTip1.SetToolTip(this.txtServer, "Name of SQL server");
			// 
			// txtDatabase
			// 
			this.txtDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDatabase.Location = new System.Drawing.Point(119, 45);
			this.txtDatabase.Name = "txtDatabase";
			this.txtDatabase.Size = new System.Drawing.Size(215, 20);
			this.txtDatabase.TabIndex = 1;
			this.toolTip1.SetToolTip(this.txtDatabase, "Database to connect to");
			// 
			// txtUserID
			// 
			this.txtUserID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtUserID.Location = new System.Drawing.Point(119, 137);
			this.txtUserID.Name = "txtUserID";
			this.txtUserID.Size = new System.Drawing.Size(215, 20);
			this.txtUserID.TabIndex = 4;
			this.toolTip1.SetToolTip(this.txtUserID, "Enter User ID to connect to server and database");
			// 
			// txtPassword
			// 
			this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPassword.Location = new System.Drawing.Point(119, 163);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Size = new System.Drawing.Size(215, 20);
			this.txtPassword.TabIndex = 5;
			this.toolTip1.SetToolTip(this.txtPassword, "Enter Password to connect to server and database");
			this.txtPassword.UseSystemPasswordChar = true;
			this.txtPassword.Leave += new System.EventHandler(this.PasswordText_Leave);
			// 
			// txtConnDisplay
			// 
			this.txtConnDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtConnDisplay.Location = new System.Drawing.Point(13, 215);
			this.txtConnDisplay.Multiline = true;
			this.txtConnDisplay.Name = "txtConnDisplay";
			this.txtConnDisplay.ReadOnly = true;
			this.txtConnDisplay.Size = new System.Drawing.Size(320, 89);
			this.txtConnDisplay.TabIndex = 6;
			this.toolTip1.SetToolTip(this.txtConnDisplay, "This is the connection string built with this form - this will be passed back to " +
        "the parent form when Accept is clicked");
			// 
			// btnTest
			// 
			this.btnTest.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnTest.Location = new System.Drawing.Point(12, 310);
			this.btnTest.Name = "btnTest";
			this.btnTest.Size = new System.Drawing.Size(75, 23);
			this.btnTest.TabIndex = 7;
			this.btnTest.Text = "Test";
			this.toolTip1.SetToolTip(this.btnTest, "Test the connection string just built");
			this.btnTest.UseVisualStyleBackColor = true;
			this.btnTest.Click += new System.EventHandler(this.TestButton_Click);
			// 
			// btnAccept
			// 
			this.btnAccept.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnAccept.Location = new System.Drawing.Point(134, 310);
			this.btnAccept.Name = "btnAccept";
			this.btnAccept.Size = new System.Drawing.Size(75, 23);
			this.btnAccept.TabIndex = 8;
			this.btnAccept.Text = "Accept";
			this.toolTip1.SetToolTip(this.btnAccept, "Return the connection string to parent form and close the builder");
			this.btnAccept.UseVisualStyleBackColor = true;
			this.btnAccept.Click += new System.EventHandler(this.AcceptButton_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnCancel.Location = new System.Drawing.Point(257, 310);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 9;
			this.btnCancel.Text = "Cancel";
			this.toolTip1.SetToolTip(this.btnCancel, "Close the builder without doing anything");
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// rdoTrustedYes
			// 
			this.rdoTrustedYes.AutoSize = true;
			this.rdoTrustedYes.Location = new System.Drawing.Point(6, 10);
			this.rdoTrustedYes.Name = "rdoTrustedYes";
			this.rdoTrustedYes.Size = new System.Drawing.Size(43, 17);
			this.rdoTrustedYes.TabIndex = 0;
			this.rdoTrustedYes.TabStop = true;
			this.rdoTrustedYes.Text = "Yes";
			this.toolTip1.SetToolTip(this.rdoTrustedYes, "Choose if User/Password not required");
			this.rdoTrustedYes.UseVisualStyleBackColor = true;
			this.rdoTrustedYes.Leave += new System.EventHandler(this.TrustedYes_Leave);
			// 
			// rdoTrustedNo
			// 
			this.rdoTrustedNo.AutoSize = true;
			this.rdoTrustedNo.Checked = true;
			this.rdoTrustedNo.Location = new System.Drawing.Point(55, 10);
			this.rdoTrustedNo.Name = "rdoTrustedNo";
			this.rdoTrustedNo.Size = new System.Drawing.Size(39, 17);
			this.rdoTrustedNo.TabIndex = 1;
			this.rdoTrustedNo.TabStop = true;
			this.rdoTrustedNo.Text = "No";
			this.toolTip1.SetToolTip(this.rdoTrustedNo, "Choose if User/Password required (default)");
			this.rdoTrustedNo.UseVisualStyleBackColor = true;
			this.rdoTrustedNo.Leave += new System.EventHandler(this.TrustedNo_Leave);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(4, 4);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(108, 13);
			this.label6.TabIndex = 9;
			this.label6.Text = "MS SQL Server Only!";
			// 
			// rdoClarityNo
			// 
			this.rdoClarityNo.AutoSize = true;
			this.rdoClarityNo.Checked = true;
			this.rdoClarityNo.Location = new System.Drawing.Point(55, 11);
			this.rdoClarityNo.Name = "rdoClarityNo";
			this.rdoClarityNo.Size = new System.Drawing.Size(39, 17);
			this.rdoClarityNo.TabIndex = 1;
			this.rdoClarityNo.TabStop = true;
			this.rdoClarityNo.Text = "No";
			this.toolTip1.SetToolTip(this.rdoClarityNo, "Choose if User/Password required (default)");
			this.rdoClarityNo.UseVisualStyleBackColor = true;
			// 
			// rdoClarityYes
			// 
			this.rdoClarityYes.AutoSize = true;
			this.rdoClarityYes.Location = new System.Drawing.Point(6, 11);
			this.rdoClarityYes.Name = "rdoClarityYes";
			this.rdoClarityYes.Size = new System.Drawing.Size(43, 17);
			this.rdoClarityYes.TabIndex = 0;
			this.rdoClarityYes.TabStop = true;
			this.rdoClarityYes.Text = "Yes";
			this.toolTip1.SetToolTip(this.rdoClarityYes, "Choose if this is an Epic Clarity DB");
			this.rdoClarityYes.UseVisualStyleBackColor = true;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(26, 75);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(86, 13);
			this.label7.TabIndex = 11;
			this.label7.Text = "Epic Clarity DB?:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rdoClarityYes);
			this.groupBox1.Controls.Add(this.rdoClarityNo);
			this.groupBox1.Location = new System.Drawing.Point(118, 62);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(110, 35);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.rdoTrustedYes);
			this.groupBox2.Controls.Add(this.rdoTrustedNo);
			this.groupBox2.Location = new System.Drawing.Point(119, 96);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(110, 35);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(12, 186);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(234, 26);
			this.label8.TabIndex = 12;
			this.label8.Text = "Tab out of Trusted Connection Yes or Password\r\nfield to build the connection stri" +
    "ng";
			// 
			// ConnBuilder
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(345, 345);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnAccept);
			this.Controls.Add(this.btnTest);
			this.Controls.Add(this.txtConnDisplay);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.txtUserID);
			this.Controls.Add(this.txtDatabase);
			this.Controls.Add(this.txtServer);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ConnBuilder";
			this.Text = "ODBC Connection Builder";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtServer;
		private System.Windows.Forms.TextBox txtDatabase;
		private System.Windows.Forms.TextBox txtUserID;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.TextBox txtConnDisplay;
		private System.Windows.Forms.Button btnTest;
		private System.Windows.Forms.Button btnAccept;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.RadioButton rdoTrustedYes;
		private System.Windows.Forms.RadioButton rdoTrustedNo;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.RadioButton rdoClarityNo;
		private System.Windows.Forms.RadioButton rdoClarityYes;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label8;
	}
}