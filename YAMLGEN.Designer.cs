namespace PT_Piranha
{
	partial class YAMLGEN
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.inputFileLabel = new System.Windows.Forms.Label();
			this.inputFileTextBox = new System.Windows.Forms.TextBox();
			this.inputFileButton = new System.Windows.Forms.Button();
			this.outputFolderLabel = new System.Windows.Forms.Label();
			this.outputFolderTextBox = new System.Windows.Forms.TextBox();
			this.outputFolderButton = new System.Windows.Forms.Button();
			this.playerLabel = new System.Windows.Forms.Label();
			this.playerTextBox = new System.Windows.Forms.TextBox();
			this.countLabel = new System.Windows.Forms.Label();
			this.countTextBox = new System.Windows.Forms.TextBox();
			this.generateButton = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.Controls.Add(this.inputFileLabel, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.inputFileTextBox, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.inputFileButton, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.outputFolderLabel, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.outputFolderTextBox, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.outputFolderButton, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.playerLabel, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.playerTextBox, 0, 5);
			this.tableLayoutPanel1.Controls.Add(this.countLabel, 0, 6);
			this.tableLayoutPanel1.Controls.Add(this.countTextBox, 0, 7);
			this.tableLayoutPanel1.Controls.Add(this.generateButton, 0, 8);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 9;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(514, 347);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// inputFileLabel
			// 
			this.inputFileLabel.AutoSize = true;
			this.inputFileLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.inputFileLabel.Location = new System.Drawing.Point(3, 0);
			this.inputFileLabel.Name = "inputFileLabel";
			this.inputFileLabel.Size = new System.Drawing.Size(405, 38);
			this.inputFileLabel.TabIndex = 0;
			this.inputFileLabel.Text = "Input File:";
			this.inputFileLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// inputFileTextBox
			// 
			this.inputFileTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.inputFileTextBox.Location = new System.Drawing.Point(3, 41);
			this.inputFileTextBox.Name = "inputFileTextBox";
			this.inputFileTextBox.Size = new System.Drawing.Size(405, 26);
			this.inputFileTextBox.TabIndex = 1;
			// 
			// inputFileButton
			// 
			this.inputFileButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.inputFileButton.Image = global::PT_Piranha.Properties.Resources.OpenfileDialog;
			this.inputFileButton.Location = new System.Drawing.Point(414, 41);
			this.inputFileButton.Name = "inputFileButton";
			this.inputFileButton.Size = new System.Drawing.Size(97, 32);
			this.inputFileButton.TabIndex = 2;
			this.inputFileButton.UseVisualStyleBackColor = true;
			this.inputFileButton.Click += new System.EventHandler(this.inputFileButton_Click);
			// 
			// outputFolderLabel
			// 
			this.outputFolderLabel.AutoSize = true;
			this.outputFolderLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.outputFolderLabel.Location = new System.Drawing.Point(3, 76);
			this.outputFolderLabel.Name = "outputFolderLabel";
			this.outputFolderLabel.Size = new System.Drawing.Size(405, 38);
			this.outputFolderLabel.TabIndex = 3;
			this.outputFolderLabel.Text = "Output Folder:";
			this.outputFolderLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// outputFolderTextBox
			// 
			this.outputFolderTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.outputFolderTextBox.Location = new System.Drawing.Point(3, 117);
			this.outputFolderTextBox.Name = "outputFolderTextBox";
			this.outputFolderTextBox.Size = new System.Drawing.Size(405, 26);
			this.outputFolderTextBox.TabIndex = 4;
			// 
			// outputFolderButton
			// 
			this.outputFolderButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.outputFolderButton.Image = global::PT_Piranha.Properties.Resources.OpenfileDialog;
			this.outputFolderButton.Location = new System.Drawing.Point(414, 117);
			this.outputFolderButton.Name = "outputFolderButton";
			this.outputFolderButton.Size = new System.Drawing.Size(97, 32);
			this.outputFolderButton.TabIndex = 5;
			this.outputFolderButton.UseVisualStyleBackColor = true;
			this.outputFolderButton.Click += new System.EventHandler(this.outputFolderButton_Click);
			// 
			// playerLabel
			// 
			this.playerLabel.AutoSize = true;
			this.playerLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.playerLabel.Location = new System.Drawing.Point(3, 152);
			this.playerLabel.Name = "playerLabel";
			this.playerLabel.Size = new System.Drawing.Size(405, 38);
			this.playerLabel.TabIndex = 6;
			this.playerLabel.Text = "Player Name:";
			this.playerLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// playerTextBox
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.playerTextBox, 2);
			this.playerTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.playerTextBox.Location = new System.Drawing.Point(3, 193);
			this.playerTextBox.Name = "playerTextBox";
			this.playerTextBox.Size = new System.Drawing.Size(508, 26);
			this.playerTextBox.TabIndex = 7;
			// 
			// countLabel
			// 
			this.countLabel.AutoSize = true;
			this.countLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.countLabel.Location = new System.Drawing.Point(3, 228);
			this.countLabel.Name = "countLabel";
			this.countLabel.Size = new System.Drawing.Size(405, 38);
			this.countLabel.TabIndex = 8;
			this.countLabel.Text = "World Count:";
			this.countLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// countTextBox
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.countTextBox, 2);
			this.countTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.countTextBox.Location = new System.Drawing.Point(3, 269);
			this.countTextBox.Name = "countTextBox";
			this.countTextBox.Size = new System.Drawing.Size(508, 26);
			this.countTextBox.TabIndex = 9;
			// 
			// generateButton
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.generateButton, 2);
			this.generateButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.generateButton.Location = new System.Drawing.Point(3, 307);
			this.generateButton.Name = "generateButton";
			this.generateButton.Size = new System.Drawing.Size(508, 37);
			this.generateButton.TabIndex = 10;
			this.generateButton.Text = "Generate YAMLs";
			this.generateButton.UseVisualStyleBackColor = true;
			this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
			// 
			// YAMLGEN
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(514, 347);
			this.Controls.Add(this.tableLayoutPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "YAMLGEN";
			this.Text = "YAML Generator";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label inputFileLabel;
		private System.Windows.Forms.TextBox inputFileTextBox;
		private System.Windows.Forms.Button inputFileButton;
		private System.Windows.Forms.Label outputFolderLabel;
		private System.Windows.Forms.TextBox outputFolderTextBox;
		private System.Windows.Forms.Button outputFolderButton;
		private System.Windows.Forms.Label playerLabel;
		private System.Windows.Forms.TextBox playerTextBox;
		private System.Windows.Forms.Label countLabel;
		private System.Windows.Forms.TextBox countTextBox;
		private System.Windows.Forms.Button generateButton;
	}
}

