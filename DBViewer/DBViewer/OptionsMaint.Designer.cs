namespace DBS
{
	partial class OptionsMaint
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtMapName = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.txtExpandedFieldName = new System.Windows.Forms.TextBox();
			this.chkMapC = new System.Windows.Forms.CheckBox();
			this.chkMapID = new System.Windows.Forms.CheckBox();
			this.chkDTTMDate = new System.Windows.Forms.CheckBox();
			this.chkDTTMTime = new System.Windows.Forms.CheckBox();
			this.chkDATETIMEDate = new System.Windows.Forms.CheckBox();
			this.chkDATETIMETime = new System.Windows.Forms.CheckBox();
			this.btnAccept = new System.Windows.Forms.Button();
			this.btnApply = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.chkIncludeNulls = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(171, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Clarity (r) Script Generation Options";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 255);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(282, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "For _C && _ID fields, the ApplyMap Table should be named:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(219, 274);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(214, 13);
			this.label3.TabIndex = 1;
			this.label3.Text = "(For example, SEX_C becomes SEX_CMap)";
			// 
			// label4
			// 
			this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label4.Location = new System.Drawing.Point(306, 251);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(74, 20);
			this.label4.TabIndex = 2;
			this.label4.Text = "<Field Name>";
			// 
			// txtMapName
			// 
			this.txtMapName.Location = new System.Drawing.Point(374, 251);
			this.txtMapName.Name = "txtMapName";
			this.txtMapName.Size = new System.Drawing.Size(59, 20);
			this.txtMapName.TabIndex = 7;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(16, 302);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(278, 13);
			this.label5.TabIndex = 1;
			this.label5.Text = "For _C && _ID fields, the Expanded Field should be named:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(219, 321);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(217, 13);
			this.label6.TabIndex = 1;
			this.label6.Text = "(For example, SEX_C becomes SEX_NAME)";
			// 
			// label7
			// 
			this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label7.Location = new System.Drawing.Point(306, 298);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(74, 20);
			this.label7.TabIndex = 2;
			this.label7.Text = "<Field Name>";
			// 
			// txtExpandedFieldName
			// 
			this.txtExpandedFieldName.Location = new System.Drawing.Point(374, 298);
			this.txtExpandedFieldName.Name = "txtExpandedFieldName";
			this.txtExpandedFieldName.Size = new System.Drawing.Size(59, 20);
			this.txtExpandedFieldName.TabIndex = 8;
			// 
			// chkMapC
			// 
			this.chkMapC.AutoSize = true;
			this.chkMapC.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.chkMapC.Location = new System.Drawing.Point(334, 55);
			this.chkMapC.Name = "chkMapC";
			this.chkMapC.Size = new System.Drawing.Size(99, 17);
			this.chkMapC.TabIndex = 0;
			this.chkMapC.Text = "Map _C Fields?";
			this.chkMapC.UseVisualStyleBackColor = true;
			// 
			// chkMapID
			// 
			this.chkMapID.AutoSize = true;
			this.chkMapID.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.chkMapID.Location = new System.Drawing.Point(330, 83);
			this.chkMapID.Name = "chkMapID";
			this.chkMapID.Size = new System.Drawing.Size(103, 17);
			this.chkMapID.TabIndex = 1;
			this.chkMapID.Text = "Map _ID Fields?";
			this.chkMapID.UseVisualStyleBackColor = true;
			// 
			// chkDTTMDate
			// 
			this.chkDTTMDate.AutoSize = true;
			this.chkDTTMDate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.chkDTTMDate.Location = new System.Drawing.Point(145, 111);
			this.chkDTTMDate.Name = "chkDTTMDate";
			this.chkDTTMDate.Size = new System.Drawing.Size(288, 17);
			this.chkDTTMDate.TabIndex = 2;
			this.chkDTTMDate.Text = "Create Date field from _DTTM fields using MakeDate()?";
			this.chkDTTMDate.UseVisualStyleBackColor = true;
			// 
			// chkDTTMTime
			// 
			this.chkDTTMTime.AutoSize = true;
			this.chkDTTMTime.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.chkDTTMTime.Location = new System.Drawing.Point(145, 139);
			this.chkDTTMTime.Name = "chkDTTMTime";
			this.chkDTTMTime.Size = new System.Drawing.Size(288, 17);
			this.chkDTTMTime.TabIndex = 3;
			this.chkDTTMTime.Text = "Create Time field from _DTTM fields using MakeTime()?";
			this.chkDTTMTime.UseVisualStyleBackColor = true;
			// 
			// chkDATETIMEDate
			// 
			this.chkDATETIMEDate.AutoSize = true;
			this.chkDATETIMEDate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.chkDATETIMEDate.Location = new System.Drawing.Point(121, 167);
			this.chkDATETIMEDate.Name = "chkDATETIMEDate";
			this.chkDATETIMEDate.Size = new System.Drawing.Size(312, 17);
			this.chkDATETIMEDate.TabIndex = 4;
			this.chkDATETIMEDate.Text = "Create Date field from _DATETIME fields using MakeDate()?";
			this.chkDATETIMEDate.UseVisualStyleBackColor = true;
			// 
			// chkDATETIMETime
			// 
			this.chkDATETIMETime.AutoSize = true;
			this.chkDATETIMETime.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.chkDATETIMETime.Location = new System.Drawing.Point(121, 195);
			this.chkDATETIMETime.Name = "chkDATETIMETime";
			this.chkDATETIMETime.Size = new System.Drawing.Size(312, 17);
			this.chkDATETIMETime.TabIndex = 5;
			this.chkDATETIMETime.Text = "Create Time field from _DATETIME fields using MakeTime()?";
			this.chkDATETIMETime.UseVisualStyleBackColor = true;
			// 
			// btnAccept
			// 
			this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAccept.Location = new System.Drawing.Point(235, 381);
			this.btnAccept.Name = "btnAccept";
			this.btnAccept.Size = new System.Drawing.Size(75, 23);
			this.btnAccept.TabIndex = 9;
			this.btnAccept.Text = "Accept";
			this.btnAccept.UseVisualStyleBackColor = true;
			this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
			// 
			// btnApply
			// 
			this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnApply.Location = new System.Drawing.Point(316, 381);
			this.btnApply.Name = "btnApply";
			this.btnApply.Size = new System.Drawing.Size(75, 23);
			this.btnApply.TabIndex = 10;
			this.btnApply.Text = "Apply";
			this.btnApply.UseVisualStyleBackColor = true;
			this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Location = new System.Drawing.Point(397, 381);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 11;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// chkIncludeNulls
			// 
			this.chkIncludeNulls.AutoSize = true;
			this.chkIncludeNulls.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.chkIncludeNulls.Location = new System.Drawing.Point(315, 223);
			this.chkIncludeNulls.Name = "chkIncludeNulls";
			this.chkIncludeNulls.Size = new System.Drawing.Size(118, 17);
			this.chkIncludeNulls.TabIndex = 6;
			this.chkIncludeNulls.Text = "Include Null Fields?";
			this.chkIncludeNulls.UseVisualStyleBackColor = true;
			// 
			// OptionsMaint
			// 
			this.AcceptButton = this.btnAccept;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(484, 416);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnApply);
			this.Controls.Add(this.btnAccept);
			this.Controls.Add(this.chkIncludeNulls);
			this.Controls.Add(this.chkDATETIMETime);
			this.Controls.Add(this.chkDATETIMEDate);
			this.Controls.Add(this.chkDTTMTime);
			this.Controls.Add(this.chkDTTMDate);
			this.Controls.Add(this.chkMapID);
			this.Controls.Add(this.chkMapC);
			this.Controls.Add(this.txtExpandedFieldName);
			this.Controls.Add(this.txtMapName);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OptionsMaint";
			this.Text = "Options";
			this.Load += new System.EventHandler(this.OptionsMaint_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtMapName;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtExpandedFieldName;
		private System.Windows.Forms.CheckBox chkMapC;
		private System.Windows.Forms.CheckBox chkMapID;
		private System.Windows.Forms.CheckBox chkDTTMDate;
		private System.Windows.Forms.CheckBox chkDTTMTime;
		private System.Windows.Forms.CheckBox chkDATETIMEDate;
		private System.Windows.Forms.CheckBox chkDATETIMETime;
		private System.Windows.Forms.Button btnAccept;
		private System.Windows.Forms.Button btnApply;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.CheckBox chkIncludeNulls;
	}
}