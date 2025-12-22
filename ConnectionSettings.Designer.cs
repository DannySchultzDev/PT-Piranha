namespace PT_Piranha
{
	partial class ConnectionSettings
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
			this.mainTableLayout = new System.Windows.Forms.TableLayoutPanel();
			this.currentGroupBox = new System.Windows.Forms.GroupBox();
			this.currentTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.currentIPLabel = new System.Windows.Forms.Label();
			this.currentIPTextBox = new System.Windows.Forms.TextBox();
			this.currentPortLabel = new System.Windows.Forms.Label();
			this.currentPortTextBox = new System.Windows.Forms.TextBox();
			this.showConnectionSettingsCheckBox = new System.Windows.Forms.CheckBox();
			this.resetCurrentConnectionButton = new System.Windows.Forms.Button();
			this.defaultGroupBox = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.defaultIPLabel = new System.Windows.Forms.Label();
			this.defaultIPTextBox = new System.Windows.Forms.TextBox();
			this.defaultPortLabel = new System.Windows.Forms.Label();
			this.defaultPortTextBox = new System.Windows.Forms.TextBox();
			this.versionLabel = new System.Windows.Forms.Label();
			this.versionTextBox = new System.Windows.Forms.TextBox();
			this.saveButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.mainTableLayout.SuspendLayout();
			this.currentGroupBox.SuspendLayout();
			this.currentTableLayoutPanel.SuspendLayout();
			this.defaultGroupBox.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainTableLayout
			// 
			this.mainTableLayout.ColumnCount = 4;
			this.mainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
			this.mainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.mainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.mainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
			this.mainTableLayout.Controls.Add(this.currentGroupBox, 0, 0);
			this.mainTableLayout.Controls.Add(this.defaultGroupBox, 0, 1);
			this.mainTableLayout.Controls.Add(this.versionLabel, 0, 2);
			this.mainTableLayout.Controls.Add(this.versionTextBox, 1, 2);
			this.mainTableLayout.Controls.Add(this.saveButton, 0, 3);
			this.mainTableLayout.Controls.Add(this.cancelButton, 2, 3);
			this.mainTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainTableLayout.Location = new System.Drawing.Point(0, 0);
			this.mainTableLayout.Name = "mainTableLayout";
			this.mainTableLayout.RowCount = 5;
			this.mainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 210F));
			this.mainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
			this.mainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.mainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			this.mainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainTableLayout.Size = new System.Drawing.Size(478, 424);
			this.mainTableLayout.TabIndex = 0;
			// 
			// currentGroupBox
			// 
			this.mainTableLayout.SetColumnSpan(this.currentGroupBox, 4);
			this.currentGroupBox.Controls.Add(this.currentTableLayoutPanel);
			this.currentGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.currentGroupBox.Location = new System.Drawing.Point(3, 3);
			this.currentGroupBox.Name = "currentGroupBox";
			this.currentGroupBox.Size = new System.Drawing.Size(472, 204);
			this.currentGroupBox.TabIndex = 0;
			this.currentGroupBox.TabStop = false;
			this.currentGroupBox.Text = "Current Connection Settings";
			// 
			// currentTableLayoutPanel
			// 
			this.currentTableLayoutPanel.ColumnCount = 2;
			this.currentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
			this.currentTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.currentTableLayoutPanel.Controls.Add(this.currentIPLabel, 0, 0);
			this.currentTableLayoutPanel.Controls.Add(this.currentIPTextBox, 1, 0);
			this.currentTableLayoutPanel.Controls.Add(this.currentPortLabel, 0, 1);
			this.currentTableLayoutPanel.Controls.Add(this.currentPortTextBox, 1, 1);
			this.currentTableLayoutPanel.Controls.Add(this.showConnectionSettingsCheckBox, 0, 2);
			this.currentTableLayoutPanel.Controls.Add(this.resetCurrentConnectionButton, 0, 3);
			this.currentTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.currentTableLayoutPanel.Location = new System.Drawing.Point(3, 22);
			this.currentTableLayoutPanel.Name = "currentTableLayoutPanel";
			this.currentTableLayoutPanel.RowCount = 5;
			this.currentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.currentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.currentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.currentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			this.currentTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.currentTableLayoutPanel.Size = new System.Drawing.Size(466, 179);
			this.currentTableLayoutPanel.TabIndex = 0;
			// 
			// currentIPLabel
			// 
			this.currentIPLabel.AutoSize = true;
			this.currentIPLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.currentIPLabel.Location = new System.Drawing.Point(3, 0);
			this.currentIPLabel.Name = "currentIPLabel";
			this.currentIPLabel.Size = new System.Drawing.Size(94, 40);
			this.currentIPLabel.TabIndex = 0;
			this.currentIPLabel.Text = "IP:";
			this.currentIPLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// currentIPTextBox
			// 
			this.currentIPTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.currentIPTextBox.Location = new System.Drawing.Point(103, 3);
			this.currentIPTextBox.Name = "currentIPTextBox";
			this.currentIPTextBox.Size = new System.Drawing.Size(360, 26);
			this.currentIPTextBox.TabIndex = 1;
			this.currentIPTextBox.Validated += new System.EventHandler(this.CurrentIPChanged);
			// 
			// currentPortLabel
			// 
			this.currentPortLabel.AutoSize = true;
			this.currentPortLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.currentPortLabel.Location = new System.Drawing.Point(3, 40);
			this.currentPortLabel.Name = "currentPortLabel";
			this.currentPortLabel.Size = new System.Drawing.Size(94, 40);
			this.currentPortLabel.TabIndex = 2;
			this.currentPortLabel.Text = "Port:";
			this.currentPortLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// currentPortTextBox
			// 
			this.currentPortTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.currentPortTextBox.Location = new System.Drawing.Point(103, 43);
			this.currentPortTextBox.Name = "currentPortTextBox";
			this.currentPortTextBox.Size = new System.Drawing.Size(360, 26);
			this.currentPortTextBox.TabIndex = 3;
			this.currentPortTextBox.Validated += new System.EventHandler(this.CurrentPortChanged);
			// 
			// showConnectionSettingsCheckBox
			// 
			this.showConnectionSettingsCheckBox.AutoSize = true;
			this.currentTableLayoutPanel.SetColumnSpan(this.showConnectionSettingsCheckBox, 2);
			this.showConnectionSettingsCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.showConnectionSettingsCheckBox.Location = new System.Drawing.Point(3, 83);
			this.showConnectionSettingsCheckBox.Name = "showConnectionSettingsCheckBox";
			this.showConnectionSettingsCheckBox.Size = new System.Drawing.Size(460, 34);
			this.showConnectionSettingsCheckBox.TabIndex = 4;
			this.showConnectionSettingsCheckBox.Text = "Display current connection settings on menu bar";
			this.showConnectionSettingsCheckBox.UseVisualStyleBackColor = true;
			this.showConnectionSettingsCheckBox.CheckedChanged += new System.EventHandler(this.ShowConnectionSettingsChanged);
			// 
			// resetCurrentConnectionButton
			// 
			this.currentTableLayoutPanel.SetColumnSpan(this.resetCurrentConnectionButton, 2);
			this.resetCurrentConnectionButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.resetCurrentConnectionButton.Location = new System.Drawing.Point(3, 123);
			this.resetCurrentConnectionButton.Name = "resetCurrentConnectionButton";
			this.resetCurrentConnectionButton.Size = new System.Drawing.Size(460, 44);
			this.resetCurrentConnectionButton.TabIndex = 5;
			this.resetCurrentConnectionButton.Text = "Reset To Default";
			this.resetCurrentConnectionButton.UseVisualStyleBackColor = true;
			this.resetCurrentConnectionButton.Click += new System.EventHandler(this.ResetCurrentConnection);
			// 
			// defaultGroupBox
			// 
			this.mainTableLayout.SetColumnSpan(this.defaultGroupBox, 4);
			this.defaultGroupBox.Controls.Add(this.tableLayoutPanel1);
			this.defaultGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.defaultGroupBox.Location = new System.Drawing.Point(3, 213);
			this.defaultGroupBox.Name = "defaultGroupBox";
			this.defaultGroupBox.Size = new System.Drawing.Size(472, 114);
			this.defaultGroupBox.TabIndex = 1;
			this.defaultGroupBox.TabStop = false;
			this.defaultGroupBox.Text = "Default Connection Settings";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.defaultIPLabel, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.defaultIPTextBox, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.defaultPortLabel, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.defaultPortTextBox, 1, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 22);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(466, 89);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// defaultIPLabel
			// 
			this.defaultIPLabel.AutoSize = true;
			this.defaultIPLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.defaultIPLabel.Location = new System.Drawing.Point(3, 0);
			this.defaultIPLabel.Name = "defaultIPLabel";
			this.defaultIPLabel.Size = new System.Drawing.Size(94, 40);
			this.defaultIPLabel.TabIndex = 0;
			this.defaultIPLabel.Text = "IP:";
			this.defaultIPLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// defaultIPTextBox
			// 
			this.defaultIPTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.defaultIPTextBox.Location = new System.Drawing.Point(103, 3);
			this.defaultIPTextBox.Name = "defaultIPTextBox";
			this.defaultIPTextBox.Size = new System.Drawing.Size(360, 26);
			this.defaultIPTextBox.TabIndex = 1;
			this.defaultIPTextBox.Validated += new System.EventHandler(this.DefaultIPChanged);
			// 
			// defaultPortLabel
			// 
			this.defaultPortLabel.AutoSize = true;
			this.defaultPortLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.defaultPortLabel.Location = new System.Drawing.Point(3, 40);
			this.defaultPortLabel.Name = "defaultPortLabel";
			this.defaultPortLabel.Size = new System.Drawing.Size(94, 40);
			this.defaultPortLabel.TabIndex = 2;
			this.defaultPortLabel.Text = "Port:";
			this.defaultPortLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// defaultPortTextBox
			// 
			this.defaultPortTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.defaultPortTextBox.Location = new System.Drawing.Point(103, 43);
			this.defaultPortTextBox.Name = "defaultPortTextBox";
			this.defaultPortTextBox.Size = new System.Drawing.Size(360, 26);
			this.defaultPortTextBox.TabIndex = 3;
			this.defaultPortTextBox.Validated += new System.EventHandler(this.DefaultPortChanged);
			// 
			// versionLabel
			// 
			this.versionLabel.AutoSize = true;
			this.versionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.versionLabel.Location = new System.Drawing.Point(3, 330);
			this.versionLabel.Name = "versionLabel";
			this.versionLabel.Size = new System.Drawing.Size(164, 40);
			this.versionLabel.TabIndex = 2;
			this.versionLabel.Text = "Archipelago Version:";
			this.versionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// versionTextBox
			// 
			this.mainTableLayout.SetColumnSpan(this.versionTextBox, 3);
			this.versionTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.versionTextBox.Location = new System.Drawing.Point(173, 333);
			this.versionTextBox.Name = "versionTextBox";
			this.versionTextBox.Size = new System.Drawing.Size(302, 26);
			this.versionTextBox.TabIndex = 3;
			this.versionTextBox.Validated += new System.EventHandler(this.VersionChanged);
			// 
			// saveButton
			// 
			this.mainTableLayout.SetColumnSpan(this.saveButton, 2);
			this.saveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.saveButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.saveButton.Location = new System.Drawing.Point(3, 373);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(233, 44);
			this.saveButton.TabIndex = 4;
			this.saveButton.Text = "Save";
			this.saveButton.UseVisualStyleBackColor = true;
			// 
			// cancelButton
			// 
			this.mainTableLayout.SetColumnSpan(this.cancelButton, 2);
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cancelButton.Location = new System.Drawing.Point(242, 373);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(233, 44);
			this.cancelButton.TabIndex = 5;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// ConnectionSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(478, 424);
			this.Controls.Add(this.mainTableLayout);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ConnectionSettings";
			this.Text = "ConnectionSettings";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConnectionSettings_FormClosing);
			this.Load += new System.EventHandler(this.ConnectionSettings_Load);
			this.mainTableLayout.ResumeLayout(false);
			this.mainTableLayout.PerformLayout();
			this.currentGroupBox.ResumeLayout(false);
			this.currentTableLayoutPanel.ResumeLayout(false);
			this.currentTableLayoutPanel.PerformLayout();
			this.defaultGroupBox.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel mainTableLayout;
		private System.Windows.Forms.GroupBox currentGroupBox;
		private System.Windows.Forms.TableLayoutPanel currentTableLayoutPanel;
		private System.Windows.Forms.Label currentIPLabel;
		private System.Windows.Forms.TextBox currentIPTextBox;
		private System.Windows.Forms.Label currentPortLabel;
		private System.Windows.Forms.TextBox currentPortTextBox;
		private System.Windows.Forms.CheckBox showConnectionSettingsCheckBox;
		private System.Windows.Forms.Button resetCurrentConnectionButton;
		private System.Windows.Forms.GroupBox defaultGroupBox;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label defaultIPLabel;
		private System.Windows.Forms.TextBox defaultIPTextBox;
		private System.Windows.Forms.Label defaultPortLabel;
		private System.Windows.Forms.TextBox defaultPortTextBox;
		private System.Windows.Forms.Label versionLabel;
		private System.Windows.Forms.TextBox versionTextBox;
		private System.Windows.Forms.Button saveButton;
		private System.Windows.Forms.Button cancelButton;
	}
}