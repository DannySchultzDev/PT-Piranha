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
			tableLayoutPanel1 = new TableLayoutPanel();
			inputFileLabel = new Label();
			inputFileTextBox = new TextBox();
			inputFileButton = new Button();
			outputFolderLabel = new Label();
			outputFolderTextBox = new TextBox();
			outputFolderButton = new Button();
			playerLabel = new Label();
			playerTextBox = new TextBox();
			countLabel = new Label();
			countTextBox = new TextBox();
			generateButton = new Button();
			tableLayoutPanel1.SuspendLayout();
			SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 2;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
			tableLayoutPanel1.Controls.Add(inputFileLabel, 0, 0);
			tableLayoutPanel1.Controls.Add(inputFileTextBox, 0, 1);
			tableLayoutPanel1.Controls.Add(inputFileButton, 1, 1);
			tableLayoutPanel1.Controls.Add(outputFolderLabel, 0, 2);
			tableLayoutPanel1.Controls.Add(outputFolderTextBox, 0, 3);
			tableLayoutPanel1.Controls.Add(outputFolderButton, 1, 3);
			tableLayoutPanel1.Controls.Add(playerLabel, 0, 4);
			tableLayoutPanel1.Controls.Add(playerTextBox, 0, 5);
			tableLayoutPanel1.Controls.Add(countLabel, 0, 6);
			tableLayoutPanel1.Controls.Add(countTextBox, 0, 7);
			tableLayoutPanel1.Controls.Add(generateButton, 0, 8);
			tableLayoutPanel1.Dock = DockStyle.Fill;
			tableLayoutPanel1.Location = new Point(0, 0);
			tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 9;
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11111F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11111F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11111F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11111F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11111F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11111F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11111F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11111F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.11111F));
			tableLayoutPanel1.Size = new Size(571, 434);
			tableLayoutPanel1.TabIndex = 0;
			// 
			// inputFileLabel
			// 
			inputFileLabel.AutoSize = true;
			inputFileLabel.Dock = DockStyle.Fill;
			inputFileLabel.Location = new Point(3, 0);
			inputFileLabel.Name = "inputFileLabel";
			inputFileLabel.Size = new Size(450, 48);
			inputFileLabel.TabIndex = 0;
			inputFileLabel.Text = "Input File:";
			inputFileLabel.TextAlign = ContentAlignment.BottomLeft;
			// 
			// inputFileTextBox
			// 
			inputFileTextBox.Dock = DockStyle.Fill;
			inputFileTextBox.Location = new Point(3, 52);
			inputFileTextBox.Margin = new Padding(3, 4, 3, 4);
			inputFileTextBox.Name = "inputFileTextBox";
			inputFileTextBox.Size = new Size(450, 31);
			inputFileTextBox.TabIndex = 1;
			// 
			// inputFileButton
			// 
			inputFileButton.Dock = DockStyle.Fill;
			inputFileButton.Image = Properties.Resources.OpenfileDialog;
			inputFileButton.Location = new Point(459, 52);
			inputFileButton.Margin = new Padding(3, 4, 3, 4);
			inputFileButton.Name = "inputFileButton";
			inputFileButton.Size = new Size(109, 40);
			inputFileButton.TabIndex = 2;
			inputFileButton.UseVisualStyleBackColor = true;
			inputFileButton.Click += inputFileButton_Click;
			// 
			// outputFolderLabel
			// 
			outputFolderLabel.AutoSize = true;
			outputFolderLabel.Dock = DockStyle.Fill;
			outputFolderLabel.Location = new Point(3, 96);
			outputFolderLabel.Name = "outputFolderLabel";
			outputFolderLabel.Size = new Size(450, 48);
			outputFolderLabel.TabIndex = 3;
			outputFolderLabel.Text = "Output Folder:";
			outputFolderLabel.TextAlign = ContentAlignment.BottomLeft;
			// 
			// outputFolderTextBox
			// 
			outputFolderTextBox.Dock = DockStyle.Fill;
			outputFolderTextBox.Location = new Point(3, 148);
			outputFolderTextBox.Margin = new Padding(3, 4, 3, 4);
			outputFolderTextBox.Name = "outputFolderTextBox";
			outputFolderTextBox.Size = new Size(450, 31);
			outputFolderTextBox.TabIndex = 4;
			// 
			// outputFolderButton
			// 
			outputFolderButton.Dock = DockStyle.Fill;
			outputFolderButton.Image = Properties.Resources.OpenfileDialog;
			outputFolderButton.Location = new Point(459, 148);
			outputFolderButton.Margin = new Padding(3, 4, 3, 4);
			outputFolderButton.Name = "outputFolderButton";
			outputFolderButton.Size = new Size(109, 40);
			outputFolderButton.TabIndex = 5;
			outputFolderButton.UseVisualStyleBackColor = true;
			outputFolderButton.Click += outputFolderButton_Click;
			// 
			// playerLabel
			// 
			playerLabel.AutoSize = true;
			playerLabel.Dock = DockStyle.Fill;
			playerLabel.Location = new Point(3, 192);
			playerLabel.Name = "playerLabel";
			playerLabel.Size = new Size(450, 48);
			playerLabel.TabIndex = 6;
			playerLabel.Text = "Player Name:";
			playerLabel.TextAlign = ContentAlignment.BottomLeft;
			// 
			// playerTextBox
			// 
			tableLayoutPanel1.SetColumnSpan(playerTextBox, 2);
			playerTextBox.Dock = DockStyle.Fill;
			playerTextBox.Location = new Point(3, 244);
			playerTextBox.Margin = new Padding(3, 4, 3, 4);
			playerTextBox.Name = "playerTextBox";
			playerTextBox.Size = new Size(565, 31);
			playerTextBox.TabIndex = 7;
			// 
			// countLabel
			// 
			countLabel.AutoSize = true;
			countLabel.Dock = DockStyle.Fill;
			countLabel.Location = new Point(3, 288);
			countLabel.Name = "countLabel";
			countLabel.Size = new Size(450, 48);
			countLabel.TabIndex = 8;
			countLabel.Text = "World Count:";
			countLabel.TextAlign = ContentAlignment.BottomLeft;
			// 
			// countTextBox
			// 
			tableLayoutPanel1.SetColumnSpan(countTextBox, 2);
			countTextBox.Dock = DockStyle.Fill;
			countTextBox.Location = new Point(3, 340);
			countTextBox.Margin = new Padding(3, 4, 3, 4);
			countTextBox.Name = "countTextBox";
			countTextBox.Size = new Size(565, 31);
			countTextBox.TabIndex = 9;
			// 
			// generateButton
			// 
			tableLayoutPanel1.SetColumnSpan(generateButton, 2);
			generateButton.Dock = DockStyle.Fill;
			generateButton.Location = new Point(3, 388);
			generateButton.Margin = new Padding(3, 4, 3, 4);
			generateButton.Name = "generateButton";
			generateButton.Size = new Size(565, 42);
			generateButton.TabIndex = 10;
			generateButton.Text = "Generate YAMLs";
			generateButton.UseVisualStyleBackColor = true;
			generateButton.Click += generateButton_Click;
			// 
			// YAMLGEN
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(571, 434);
			Controls.Add(tableLayoutPanel1);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			Margin = new Padding(3, 4, 3, 4);
			MaximizeBox = false;
			Name = "YAMLGEN";
			Text = "YAML Generator";
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			ResumeLayout(false);
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

