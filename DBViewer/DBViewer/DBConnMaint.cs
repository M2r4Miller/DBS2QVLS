using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using XCrypt;

namespace DBS
{
	public partial class DBConnMaint : Form
	{
		public XCryptEngine XE { get; set; }

		//bool editExisting = false;

		public DBConnMaint()
		{
			InitializeComponent();
			//txtPassword.Text = "bubba";
		}

		private void DBConnMaint_Load(object sender, EventArgs e)
		{
			if(XE == null)
			{
				XE.InitializeEngine(XCryptEngine.AlgorithmType.TripleDES);
			}
			LoadConnections();
		}

		///// <summary>
		///// Very simple method of loading an un-encrypted Connections file
		///// You would uncomment and use this method only if you have an un-encrypted
		///// Connections.txt file you want to load.
		///// You would need to comment out the real LoadConnections_Click method as well, of course
		///// </summary>
		///// <param name="sender"></param>
		///// <param name="e"></param>
		//private void LoadConnections_Click(object sender, EventArgs e)
		//{
		//	string[] lines = File.ReadAllLines("Connections.txt");
		//	lstConnectionsList.Items.AddRange(lines);
		//	lstConnectionsList.Refresh();
		//}

		/// <summary>
		/// Very simple method of loading the encrypted Connections file
		/// Does trap CryptographicException which occurs if the file cannot be decrypted which 
		/// most likely is caused by a bad password, but could be due to a corrupted Connections file
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void LoadConnections()
		{
			lstConnectionsList.Items.Clear();
			if (!string.IsNullOrEmpty(XE.Key))
			{
				try
				{
					// Open file and read strings into array, decrypt them one by one
					string[] encConnections = File.ReadAllLines("Connections.txt");
					foreach (string item in encConnections)
					{
						lstConnectionsList.Items.Add(XE.Decrypt(item));
					}
				}
				catch (FileNotFoundException)
				{
					MessageBox.Show("Connections File Not Found!\n\nCreate one by adding connections and clicking Save button.", "Connection Loader", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				}
				catch (CryptographicException)
				{
					MessageBox.Show("Bad Password or corrupted Connections file!\n\nConnections NOT loaded!", "Connection Loader", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				}
			}
			lstConnectionsList.Refresh();
		}

		private void SaveConnections_Click(object sender, EventArgs e)
		{
			EncryptAndSaveConnections();
		}

		/// <summary>
		/// Encrypts and saves the connections from the ListBox into Connections.txt
		/// Very simple, rudimentary method, no error trapping... Hey, it runs on my machine! :)
		/// </summary>
		private void EncryptAndSaveConnections()
		{
			if (!string.IsNullOrEmpty(XE.Key))
			{
				// Open file and read strings into array, decrypt them one by one
				List<string> encConnections = new List<string>();
				foreach (string item in lstConnectionsList.Items)
				{
					encConnections.Add(XE.Encrypt(item));
				}
				File.WriteAllLines("Connections.txt", encConnections.ToArray());
			}
		}

		/// <summary>
		/// Populates the CurrentConnection TextBox with the currently selected connection in the ListBox
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ConnectionsList_SelectedIndexChanged(object sender, EventArgs e)
		{
			txtCurrentConnection.Text = (string) lstConnectionsList.SelectedItem;
		}

		/// <summary>
		/// Closes the form, encrypting and saving connections on the way out
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CloseForm_Click(object sender, EventArgs e)
		{
			EncryptAndSaveConnections();
			this.Close();
		}

		/// <summary>
		/// Toggles controls when the CurrentConnection TextBox is entered
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CurrentConnection_Enter(object sender, EventArgs e)
		{
			UpdateLabel.Visible = true;
			btnUpdateConnection.Enabled = true;
		}

		/// <summary>
		/// Toggles controls when the CurrentConnection TextBox is left
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CurrentConnection_Leave(object sender, EventArgs e)
		{
			UpdateLabel.Visible = false;
		}

		/// <summary>
		/// Displays the Connection Builder form as a modal dialog
		/// Populates the CurrentConnection TextBox with the built ConnectionString if any
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BuildConnection_Click(object sender, EventArgs e)
		{
			// Show the Connection Builder dialog
			ConnBuilder cb = new ConnBuilder();
			cb.ShowDialog();
			txtCurrentConnection.Text = cb.ConnectionString;
		}

		/// <summary>
		/// Adds the contents of CurrentConnection TextBox to the ListBox of Connections
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void AddConnection_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(txtCurrentConnection.Text))
			{
				lstConnectionsList.Items.Add(txtCurrentConnection.Text);
				lstConnectionsList.Refresh();
			}
		}

		/// <summary>
		/// Updates the ListBox with the CurrentConnection TextBox, effectively
		/// updates a single row in the ListBox
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void UpdateConnection_Click(object sender, EventArgs e)
		{
			string originalConnection = (string) lstConnectionsList.SelectedItem;
			string currentConnection = txtCurrentConnection.Text;
			if (!currentConnection.Equals(originalConnection))
			{
				for (int i = 0; i < lstConnectionsList.Items.Count; i++)
				{
					if (lstConnectionsList.Items[i].Equals(originalConnection))
					{
						lstConnectionsList.Items[i] = currentConnection;
						break;
					}
				}
				txtCurrentConnection.Clear();
				btnUpdateConnection.Enabled = false;
			}
		}

		/// <summary>
		/// Deletes the currently selected connection from the ListBox
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DeleteConnection_Click(object sender, EventArgs e)
		{
			lstConnectionsList.Items.Remove(lstConnectionsList.SelectedItem);
			lstConnectionsList.Refresh();
		}
	}
}
