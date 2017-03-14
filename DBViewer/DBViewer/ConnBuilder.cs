using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DBS
{
	public partial class ConnBuilder : Form
	{
		/// <summary>
		/// ConnectionString is populated and read by the caller so the caller can get the connection string
		/// built in this form
		/// </summary>
		public string ConnectionString { get; set; }

		/// <summary>
		/// Initialize the form - MS SQL Server is all that is supported!
		/// </summary>
		public ConnBuilder()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Build the connection when the Password TextBox is left
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PasswordText_Leave(object sender, EventArgs e)
		{
			BuildConn();
		}

		/// <summary>
		/// Assembles the various components and builds the connection string into the TextBox
		/// </summary>
		private void BuildConn()
		{
			string connection = string.Empty;
			if (rdoTrustedYes.Checked)
				connection = string.Format("Server={0}; Database={1}; Trusted_Connection=True;",
																					txtServer.Text, txtDatabase.Text);
			else
				connection = string.Format("Server={0}; Database={1}; UID={2}; PWD={3};",
																					txtServer.Text, txtDatabase.Text, txtUserID.Text, txtPassword.Text);

			/*
			 * If indicated, a "TAG" is added to the connection string - note this is NOT SUPPORTED by
			 * SQLConnection - it is only used in this application to determine if advanced QlikView
			 * script generation is supported on this database. Note the "TAG=Clarity;" portion is stripped
			 * off prior to the connection string actually being used
			 */
			if (rdoClarityYes.Checked)
				connection += "TAG=Clarity;";

			txtConnDisplay.Text = connection;
			txtConnDisplay.Refresh();
		}

		/// <summary>
		/// Toggles controls and possibly builds the connection string based on state of rdoTrustedYes RadioButton
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TrustedYes_Leave(object sender, EventArgs e)
		{
			if (rdoTrustedYes.Checked)
			{
				txtUserID.Enabled = false;
				txtPassword.Enabled = false;
				BuildConn();
			}
			else
			{
				txtUserID.Enabled = true;
				txtPassword.Enabled = true;
			}
		}

		/// <summary>
		/// Toggles controls based on state of rdoTrustedNo RadioButton
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TrustedNo_Leave(object sender, EventArgs e)
		{
			if(rdoTrustedNo.Checked)
			{
				txtUserID.Enabled = true;
				txtPassword.Enabled = true;
				txtUserID.Select();
			}
		}

		/// <summary>
		/// Copies the assembled connection string into Public ConnectionString property
		/// and closes the form
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void AcceptButton_Click(object sender, EventArgs e)
		{
			ConnectionString = txtConnDisplay.Text;
			this.Close();
		}

		/// <summary>
		/// Attempts to connect to SQL DB using the assembled connection string
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <exception cref="SqlException">Traps for and displays a message</exception>
		/// <exception cref="Exception">Traps for and displays a message</exception>
		private void TestButton_Click(object sender, EventArgs e)
		{
			// Attempt to connect to whatever is currently specified in ConnDisplay.Text
			try
			{
				using (SqlConnection connection = new SqlConnection(txtConnDisplay.Text.Replace("TAG=Clarity;", "")))
				{
					// Connect to the database to retrieve schema information
					connection.Open();
					MessageBox.Show("Connection Successful!");
					btnAccept.Select();
				}
			}
			catch (SqlException se)
			{
				MessageBox.Show(se.Message);
				return;
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message);
				Console.WriteLine("Generic Exception Handler: {0}", exc.ToString());
				return;
			}
		}

		/// <summary>
		/// Clears the Public ConnectionString property and closes the form
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CancelButton_Click(object sender, EventArgs e)
		{
			ConnectionString = string.Empty;
			this.Close();
		}
	}
}
