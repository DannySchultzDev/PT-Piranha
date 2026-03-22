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
			mainTableLayout = new TableLayoutPanel();
			currentGroupBox = new GroupBox();
			currentTableLayoutPanel = new TableLayoutPanel();
			currentIPLabel = new Label();
			currentIPTextBox = new TextBox();
			currentPortLabel = new Label();
			currentPortTextBox = new TextBox();
			showConnectionSettingsCheckBox = new CheckBox();
			resetCurrentConnectionButton = new Button();
			defaultGroupBox = new GroupBox();
			tableLayoutPanel1 = new TableLayoutPanel();
			defaultIPLabel = new Label();
			defaultIPTextBox = new TextBox();
			defaultPortLabel = new Label();
			defaultPortTextBox = new TextBox();
			versionLabel = new Label();
			versionTextBox = new TextBox();
			saveButton = new Button();
			cancelButton = new Button();
			mainTableLayout.SuspendLayout();
			currentGroupBox.SuspendLayout();
			currentTableLayoutPanel.SuspendLayout();
			defaultGroupBox.SuspendLayout();
			tableLayoutPanel1.SuspendLayout();
			SuspendLayout();
			// 
			// mainTableLayout
			// 
			mainTableLayout.ColumnCount = 4;
			mainTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 189F));
			mainTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			mainTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			mainTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 189F));
			mainTableLayout.Controls.Add(currentGroupBox, 0, 0);
			mainTableLayout.Controls.Add(defaultGroupBox, 0, 1);
			mainTableLayout.Controls.Add(versionLabel, 0, 2);
			mainTableLayout.Controls.Add(versionTextBox, 1, 2);
			mainTableLayout.Controls.Add(saveButton, 0, 3);
			mainTableLayout.Controls.Add(cancelButton, 2, 3);
			mainTableLayout.Dock = DockStyle.Fill;
			mainTableLayout.Location = new Point(0, 0);
			mainTableLayout.Margin = new Padding(3, 4, 3, 4);
			mainTableLayout.Name = "mainTableLayout";
			mainTableLayout.RowCount = 5;
			mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 262F));
			mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 150F));
			mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
			mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
			mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			mainTableLayout.Size = new Size(531, 530);
			mainTableLayout.TabIndex = 0;
			// 
			// currentGroupBox
			// 
			mainTableLayout.SetColumnSpan(currentGroupBox, 4);
			currentGroupBox.Controls.Add(currentTableLayoutPanel);
			currentGroupBox.Dock = DockStyle.Fill;
			currentGroupBox.Location = new Point(3, 4);
			currentGroupBox.Margin = new Padding(3, 4, 3, 4);
			currentGroupBox.Name = "currentGroupBox";
			currentGroupBox.Padding = new Padding(3, 4, 3, 4);
			currentGroupBox.Size = new Size(525, 254);
			currentGroupBox.TabIndex = 0;
			currentGroupBox.TabStop = false;
			currentGroupBox.Text = "Current Connection Settings";
			// 
			// currentTableLayoutPanel
			// 
			currentTableLayoutPanel.ColumnCount = 2;
			currentTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 111F));
			currentTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			currentTableLayoutPanel.Controls.Add(currentIPLabel, 0, 0);
			currentTableLayoutPanel.Controls.Add(currentIPTextBox, 1, 0);
			currentTableLayoutPanel.Controls.Add(currentPortLabel, 0, 1);
			currentTableLayoutPanel.Controls.Add(currentPortTextBox, 1, 1);
			currentTableLayoutPanel.Controls.Add(showConnectionSettingsCheckBox, 0, 2);
			currentTableLayoutPanel.Controls.Add(resetCurrentConnectionButton, 0, 3);
			currentTableLayoutPanel.Dock = DockStyle.Fill;
			currentTableLayoutPanel.Location = new Point(3, 28);
			currentTableLayoutPanel.Margin = new Padding(3, 4, 3, 4);
			currentTableLayoutPanel.Name = "currentTableLayoutPanel";
			currentTableLayoutPanel.RowCount = 5;
			currentTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
			currentTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
			currentTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
			currentTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
			currentTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			currentTableLayoutPanel.Size = new Size(519, 222);
			currentTableLayoutPanel.TabIndex = 0;
			// 
			// currentIPLabel
			// 
			currentIPLabel.AutoSize = true;
			currentIPLabel.Dock = DockStyle.Fill;
			currentIPLabel.Location = new Point(3, 0);
			currentIPLabel.Name = "currentIPLabel";
			currentIPLabel.Size = new Size(105, 50);
			currentIPLabel.TabIndex = 0;
			currentIPLabel.Text = "IP:";
			currentIPLabel.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// currentIPTextBox
			// 
			currentIPTextBox.Dock = DockStyle.Fill;
			currentIPTextBox.Location = new Point(114, 4);
			currentIPTextBox.Margin = new Padding(3, 4, 3, 4);
			currentIPTextBox.Name = "currentIPTextBox";
			currentIPTextBox.Size = new Size(402, 31);
			currentIPTextBox.TabIndex = 1;
			currentIPTextBox.Validated += CurrentIPChanged;
			// 
			// currentPortLabel
			// 
			currentPortLabel.AutoSize = true;
			currentPortLabel.Dock = DockStyle.Fill;
			currentPortLabel.Location = new Point(3, 50);
			currentPortLabel.Name = "currentPortLabel";
			currentPortLabel.Size = new Size(105, 50);
			currentPortLabel.TabIndex = 2;
			currentPortLabel.Text = "Port:";
			currentPortLabel.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// currentPortTextBox
			// 
			currentPortTextBox.Dock = DockStyle.Fill;
			currentPortTextBox.Location = new Point(114, 54);
			currentPortTextBox.Margin = new Padding(3, 4, 3, 4);
			currentPortTextBox.Name = "currentPortTextBox";
			currentPortTextBox.Size = new Size(402, 31);
			currentPortTextBox.TabIndex = 3;
			currentPortTextBox.Validated += CurrentPortChanged;
			// 
			// showConnectionSettingsCheckBox
			// 
			showConnectionSettingsCheckBox.AutoSize = true;
			currentTableLayoutPanel.SetColumnSpan(showConnectionSettingsCheckBox, 2);
			showConnectionSettingsCheckBox.Dock = DockStyle.Fill;
			showConnectionSettingsCheckBox.Location = new Point(3, 104);
			showConnectionSettingsCheckBox.Margin = new Padding(3, 4, 3, 4);
			showConnectionSettingsCheckBox.Name = "showConnectionSettingsCheckBox";
			showConnectionSettingsCheckBox.Size = new Size(513, 42);
			showConnectionSettingsCheckBox.TabIndex = 4;
			showConnectionSettingsCheckBox.Text = "Display current connection settings on menu bar";
			showConnectionSettingsCheckBox.UseVisualStyleBackColor = true;
			showConnectionSettingsCheckBox.CheckedChanged += ShowConnectionSettingsChanged;
			// 
			// resetCurrentConnectionButton
			// 
			currentTableLayoutPanel.SetColumnSpan(resetCurrentConnectionButton, 2);
			resetCurrentConnectionButton.Dock = DockStyle.Fill;
			resetCurrentConnectionButton.Location = new Point(3, 154);
			resetCurrentConnectionButton.Margin = new Padding(3, 4, 3, 4);
			resetCurrentConnectionButton.Name = "resetCurrentConnectionButton";
			resetCurrentConnectionButton.Size = new Size(513, 54);
			resetCurrentConnectionButton.TabIndex = 5;
			resetCurrentConnectionButton.Text = "Reset To Default";
			resetCurrentConnectionButton.UseVisualStyleBackColor = true;
			resetCurrentConnectionButton.Click += ResetCurrentConnection;
			// 
			// defaultGroupBox
			// 
			mainTableLayout.SetColumnSpan(defaultGroupBox, 4);
			defaultGroupBox.Controls.Add(tableLayoutPanel1);
			defaultGroupBox.Dock = DockStyle.Fill;
			defaultGroupBox.Location = new Point(3, 266);
			defaultGroupBox.Margin = new Padding(3, 4, 3, 4);
			defaultGroupBox.Name = "defaultGroupBox";
			defaultGroupBox.Padding = new Padding(3, 4, 3, 4);
			defaultGroupBox.Size = new Size(525, 142);
			defaultGroupBox.TabIndex = 1;
			defaultGroupBox.TabStop = false;
			defaultGroupBox.Text = "Default Connection Settings";
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 2;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 111F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			tableLayoutPanel1.Controls.Add(defaultIPLabel, 0, 0);
			tableLayoutPanel1.Controls.Add(defaultIPTextBox, 1, 0);
			tableLayoutPanel1.Controls.Add(defaultPortLabel, 0, 1);
			tableLayoutPanel1.Controls.Add(defaultPortTextBox, 1, 1);
			tableLayoutPanel1.Dock = DockStyle.Fill;
			tableLayoutPanel1.Location = new Point(3, 28);
			tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 3;
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			tableLayoutPanel1.Size = new Size(519, 110);
			tableLayoutPanel1.TabIndex = 0;
			// 
			// defaultIPLabel
			// 
			defaultIPLabel.AutoSize = true;
			defaultIPLabel.Dock = DockStyle.Fill;
			defaultIPLabel.Location = new Point(3, 0);
			defaultIPLabel.Name = "defaultIPLabel";
			defaultIPLabel.Size = new Size(105, 50);
			defaultIPLabel.TabIndex = 0;
			defaultIPLabel.Text = "IP:";
			defaultIPLabel.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// defaultIPTextBox
			// 
			defaultIPTextBox.Dock = DockStyle.Fill;
			defaultIPTextBox.Location = new Point(114, 4);
			defaultIPTextBox.Margin = new Padding(3, 4, 3, 4);
			defaultIPTextBox.Name = "defaultIPTextBox";
			defaultIPTextBox.Size = new Size(402, 31);
			defaultIPTextBox.TabIndex = 1;
			defaultIPTextBox.Validated += DefaultIPChanged;
			// 
			// defaultPortLabel
			// 
			defaultPortLabel.AutoSize = true;
			defaultPortLabel.Dock = DockStyle.Fill;
			defaultPortLabel.Location = new Point(3, 50);
			defaultPortLabel.Name = "defaultPortLabel";
			defaultPortLabel.Size = new Size(105, 50);
			defaultPortLabel.TabIndex = 2;
			defaultPortLabel.Text = "Port:";
			defaultPortLabel.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// defaultPortTextBox
			// 
			defaultPortTextBox.Dock = DockStyle.Fill;
			defaultPortTextBox.Location = new Point(114, 54);
			defaultPortTextBox.Margin = new Padding(3, 4, 3, 4);
			defaultPortTextBox.Name = "defaultPortTextBox";
			defaultPortTextBox.Size = new Size(402, 31);
			defaultPortTextBox.TabIndex = 3;
			defaultPortTextBox.Validated += DefaultPortChanged;
			// 
			// versionLabel
			// 
			versionLabel.AutoSize = true;
			versionLabel.Dock = DockStyle.Fill;
			versionLabel.Location = new Point(3, 412);
			versionLabel.Name = "versionLabel";
			versionLabel.Size = new Size(183, 50);
			versionLabel.TabIndex = 2;
			versionLabel.Text = "Archipelago Version:";
			versionLabel.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// versionTextBox
			// 
			mainTableLayout.SetColumnSpan(versionTextBox, 3);
			versionTextBox.Dock = DockStyle.Fill;
			versionTextBox.Location = new Point(192, 416);
			versionTextBox.Margin = new Padding(3, 4, 3, 4);
			versionTextBox.Name = "versionTextBox";
			versionTextBox.Size = new Size(336, 31);
			versionTextBox.TabIndex = 3;
			versionTextBox.Validated += VersionChanged;
			// 
			// saveButton
			// 
			mainTableLayout.SetColumnSpan(saveButton, 2);
			saveButton.DialogResult = DialogResult.OK;
			saveButton.Dock = DockStyle.Fill;
			saveButton.Location = new Point(3, 466);
			saveButton.Margin = new Padding(3, 4, 3, 4);
			saveButton.Name = "saveButton";
			saveButton.Size = new Size(259, 54);
			saveButton.TabIndex = 4;
			saveButton.Text = "Save";
			saveButton.UseVisualStyleBackColor = true;
			// 
			// cancelButton
			// 
			mainTableLayout.SetColumnSpan(cancelButton, 2);
			cancelButton.DialogResult = DialogResult.Cancel;
			cancelButton.Dock = DockStyle.Fill;
			cancelButton.Location = new Point(268, 466);
			cancelButton.Margin = new Padding(3, 4, 3, 4);
			cancelButton.Name = "cancelButton";
			cancelButton.Size = new Size(260, 54);
			cancelButton.TabIndex = 5;
			cancelButton.Text = "Cancel";
			cancelButton.UseVisualStyleBackColor = true;
			// 
			// ConnectionSettings
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(531, 530);
			Controls.Add(mainTableLayout);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			Margin = new Padding(3, 4, 3, 4);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "ConnectionSettings";
			Text = "Connection Settings";
			FormClosing += ConnectionSettings_FormClosing;
			Load += ConnectionSettings_Load;
			mainTableLayout.ResumeLayout(false);
			mainTableLayout.PerformLayout();
			currentGroupBox.ResumeLayout(false);
			currentTableLayoutPanel.ResumeLayout(false);
			currentTableLayoutPanel.PerformLayout();
			defaultGroupBox.ResumeLayout(false);
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			ResumeLayout(false);
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