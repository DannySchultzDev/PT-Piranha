namespace PT_Piranha
{
	partial class Main
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
			mainToolStrip = new ToolStrip();
			resetButton = new ToolStripButton();
			portTextBox = new ToolStripTextBox();
			portLabel = new ToolStripLabel();
			IPTextBox = new ToolStripTextBox();
			IPLabel = new ToolStripLabel();
			fileDropDown = new ToolStripDropDownButton();
			generateYAMLsButton = new ToolStripMenuItem();
			fileSeparator = new ToolStripSeparator();
			generateMWButton = new ToolStripMenuItem();
			editMWButton = new ToolStripMenuItem();
			loadMWButton = new ToolStripMenuItem();
			settingsDropDown = new ToolStripDropDownButton();
			connectionButton = new ToolStripMenuItem();
			mainStatusStrip = new StatusStrip();
			statusPercentageBar = new ToolStripProgressBar();
			statusSpringLabel = new ToolStripStatusLabel();
			statusLabel = new ToolStripStatusLabel();
			mainToolStripContainer = new ToolStripContainer();
			mainPictureBox = new PictureBox();
			mainToolStrip.SuspendLayout();
			mainStatusStrip.SuspendLayout();
			mainToolStripContainer.BottomToolStripPanel.SuspendLayout();
			mainToolStripContainer.ContentPanel.SuspendLayout();
			mainToolStripContainer.TopToolStripPanel.SuspendLayout();
			mainToolStripContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)mainPictureBox).BeginInit();
			SuspendLayout();
			// 
			// mainToolStrip
			// 
			mainToolStrip.Dock = DockStyle.None;
			mainToolStrip.GripStyle = ToolStripGripStyle.Hidden;
			mainToolStrip.ImageScalingSize = new Size(24, 24);
			mainToolStrip.Items.AddRange(new ToolStripItem[] { resetButton, portTextBox, portLabel, IPTextBox, IPLabel, fileDropDown, settingsDropDown });
			mainToolStrip.Location = new Point(0, 0);
			mainToolStrip.Name = "mainToolStrip";
			mainToolStrip.Size = new Size(731, 34);
			mainToolStrip.Stretch = true;
			mainToolStrip.TabIndex = 0;
			mainToolStrip.Text = "toolStrip1";
			// 
			// resetButton
			// 
			resetButton.Alignment = ToolStripItemAlignment.Right;
			resetButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
			resetButton.Image = Properties.Resources.Restart;
			resetButton.ImageTransparentColor = Color.Magenta;
			resetButton.Name = "resetButton";
			resetButton.Overflow = ToolStripItemOverflow.Never;
			resetButton.Size = new Size(34, 29);
			resetButton.Text = "toolStripButton1";
			resetButton.ToolTipText = "Reset to defaults";
			resetButton.Click += ResetButton_Click;
			// 
			// portTextBox
			// 
			portTextBox.Alignment = ToolStripItemAlignment.Right;
			portTextBox.Name = "portTextBox";
			portTextBox.Overflow = ToolStripItemOverflow.Never;
			portTextBox.Size = new Size(100, 34);
			portTextBox.Validated += portTextBox_Validated;
			// 
			// portLabel
			// 
			portLabel.Alignment = ToolStripItemAlignment.Right;
			portLabel.Name = "portLabel";
			portLabel.Overflow = ToolStripItemOverflow.Never;
			portLabel.Size = new Size(48, 29);
			portLabel.Text = "Port:";
			// 
			// IPTextBox
			// 
			IPTextBox.Alignment = ToolStripItemAlignment.Right;
			IPTextBox.Name = "IPTextBox";
			IPTextBox.Overflow = ToolStripItemOverflow.Never;
			IPTextBox.Size = new Size(100, 34);
			IPTextBox.Validated += IPChanged;
			// 
			// IPLabel
			// 
			IPLabel.Alignment = ToolStripItemAlignment.Right;
			IPLabel.Name = "IPLabel";
			IPLabel.Overflow = ToolStripItemOverflow.Never;
			IPLabel.Size = new Size(31, 29);
			IPLabel.Text = "IP:";
			// 
			// fileDropDown
			// 
			fileDropDown.DisplayStyle = ToolStripItemDisplayStyle.Text;
			fileDropDown.DropDownItems.AddRange(new ToolStripItem[] { generateYAMLsButton, fileSeparator, generateMWButton, editMWButton, loadMWButton });
			fileDropDown.Image = (Image)resources.GetObject("fileDropDown.Image");
			fileDropDown.ImageTransparentColor = Color.Magenta;
			fileDropDown.Name = "fileDropDown";
			fileDropDown.Overflow = ToolStripItemOverflow.Never;
			fileDropDown.Size = new Size(56, 29);
			fileDropDown.Text = "File";
			// 
			// generateYAMLsButton
			// 
			generateYAMLsButton.Name = "generateYAMLsButton";
			generateYAMLsButton.Size = new Size(333, 34);
			generateYAMLsButton.Text = "Generate YAMLs";
			generateYAMLsButton.Click += GenerateYamlsButton_Click;
			// 
			// fileSeparator
			// 
			fileSeparator.Name = "fileSeparator";
			fileSeparator.Size = new Size(330, 6);
			// 
			// generateMWButton
			// 
			generateMWButton.Name = "generateMWButton";
			generateMWButton.Size = new Size(333, 34);
			generateMWButton.Text = "Generate Multiworld Tracker";
			generateMWButton.Click += GenerateMWButton_Click;
			// 
			// editMWButton
			// 
			editMWButton.Name = "editMWButton";
			editMWButton.Size = new Size(333, 34);
			editMWButton.Text = "Edit Multiworld Tracker";
			editMWButton.Click += EditMWButton_Click;
			// 
			// loadMWButton
			// 
			loadMWButton.Name = "loadMWButton";
			loadMWButton.Size = new Size(333, 34);
			loadMWButton.Text = "Load Multiworld Tracker";
			loadMWButton.Click += LoadGameButton_Click;
			// 
			// settingsDropDown
			// 
			settingsDropDown.DisplayStyle = ToolStripItemDisplayStyle.Text;
			settingsDropDown.DropDownItems.AddRange(new ToolStripItem[] { connectionButton });
			settingsDropDown.Image = (Image)resources.GetObject("settingsDropDown.Image");
			settingsDropDown.ImageTransparentColor = Color.Magenta;
			settingsDropDown.Name = "settingsDropDown";
			settingsDropDown.Overflow = ToolStripItemOverflow.Never;
			settingsDropDown.Size = new Size(94, 29);
			settingsDropDown.Text = "Settings";
			// 
			// connectionButton
			// 
			connectionButton.Name = "connectionButton";
			connectionButton.Size = new Size(204, 34);
			connectionButton.Text = "Connection";
			connectionButton.Click += ConnectionSettingsButton_Click;
			// 
			// mainStatusStrip
			// 
			mainStatusStrip.Dock = DockStyle.None;
			mainStatusStrip.ImageScalingSize = new Size(24, 24);
			mainStatusStrip.Items.AddRange(new ToolStripItem[] { statusPercentageBar, statusSpringLabel, statusLabel });
			mainStatusStrip.Location = new Point(0, 0);
			mainStatusStrip.Name = "mainStatusStrip";
			mainStatusStrip.ShowItemToolTips = true;
			mainStatusStrip.Size = new Size(731, 32);
			mainStatusStrip.SizingGrip = false;
			mainStatusStrip.TabIndex = 0;
			mainStatusStrip.Text = "statusStrip1";
			// 
			// statusPercentageBar
			// 
			statusPercentageBar.Name = "statusPercentageBar";
			statusPercentageBar.Size = new Size(300, 24);
			// 
			// statusSpringLabel
			// 
			statusSpringLabel.Name = "statusSpringLabel";
			statusSpringLabel.Size = new Size(289, 25);
			statusSpringLabel.Spring = true;
			// 
			// statusLabel
			// 
			statusLabel.Name = "statusLabel";
			statusLabel.Size = new Size(123, 25);
			statusLabel.Text = "Current Status";
			// 
			// mainToolStripContainer
			// 
			// 
			// mainToolStripContainer.BottomToolStripPanel
			// 
			mainToolStripContainer.BottomToolStripPanel.Controls.Add(mainStatusStrip);
			// 
			// mainToolStripContainer.ContentPanel
			// 
			mainToolStripContainer.ContentPanel.Controls.Add(mainPictureBox);
			mainToolStripContainer.ContentPanel.Margin = new Padding(3, 4, 3, 4);
			mainToolStripContainer.ContentPanel.Size = new Size(731, 489);
			mainToolStripContainer.Dock = DockStyle.Fill;
			mainToolStripContainer.LeftToolStripPanelVisible = false;
			mainToolStripContainer.Location = new Point(0, 0);
			mainToolStripContainer.Margin = new Padding(3, 4, 3, 4);
			mainToolStripContainer.Name = "mainToolStripContainer";
			mainToolStripContainer.RightToolStripPanelVisible = false;
			mainToolStripContainer.Size = new Size(731, 555);
			mainToolStripContainer.TabIndex = 2;
			mainToolStripContainer.Text = "toolStripContainer1";
			// 
			// mainToolStripContainer.TopToolStripPanel
			// 
			mainToolStripContainer.TopToolStripPanel.Controls.Add(mainToolStrip);
			// 
			// mainPictureBox
			// 
			mainPictureBox.Dock = DockStyle.Fill;
			mainPictureBox.Location = new Point(0, 0);
			mainPictureBox.Margin = new Padding(3, 4, 3, 4);
			mainPictureBox.Name = "mainPictureBox";
			mainPictureBox.Size = new Size(731, 489);
			mainPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
			mainPictureBox.TabIndex = 1;
			mainPictureBox.TabStop = false;
			mainPictureBox.MouseMove += mainPictureBox_MouseMove;
			// 
			// Main
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(731, 555);
			Controls.Add(mainToolStripContainer);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Margin = new Padding(3, 4, 3, 4);
			Name = "Main";
			Text = "PT Piranha";
			Load += Main_Load;
			ResizeEnd += Main_ResizeEnd;
			Resize += Main_Resize;
			mainToolStrip.ResumeLayout(false);
			mainToolStrip.PerformLayout();
			mainStatusStrip.ResumeLayout(false);
			mainStatusStrip.PerformLayout();
			mainToolStripContainer.BottomToolStripPanel.ResumeLayout(false);
			mainToolStripContainer.BottomToolStripPanel.PerformLayout();
			mainToolStripContainer.ContentPanel.ResumeLayout(false);
			mainToolStripContainer.TopToolStripPanel.ResumeLayout(false);
			mainToolStripContainer.TopToolStripPanel.PerformLayout();
			mainToolStripContainer.ResumeLayout(false);
			mainToolStripContainer.PerformLayout();
			((System.ComponentModel.ISupportInitialize)mainPictureBox).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private System.Windows.Forms.ToolStrip mainToolStrip;
		private System.Windows.Forms.StatusStrip mainStatusStrip;
		private System.Windows.Forms.ToolStripStatusLabel statusLabel;
		private System.Windows.Forms.PictureBox mainPictureBox;
		private System.Windows.Forms.ToolStripContainer mainToolStripContainer;
		private System.Windows.Forms.ToolStripTextBox IPTextBox;
		private System.Windows.Forms.ToolStripTextBox portTextBox;
		private System.Windows.Forms.ToolStripLabel portLabel;
		private System.Windows.Forms.ToolStripLabel IPLabel;
		private System.Windows.Forms.ToolStripDropDownButton fileDropDown;
		private System.Windows.Forms.ToolStripMenuItem generateYAMLsButton;
		private System.Windows.Forms.ToolStripSeparator fileSeparator;
		private System.Windows.Forms.ToolStripMenuItem generateMWButton;
		private System.Windows.Forms.ToolStripMenuItem loadMWButton;
		private System.Windows.Forms.ToolStripStatusLabel statusSpringLabel;
		private System.Windows.Forms.ToolStripProgressBar statusPercentageBar;
		private System.Windows.Forms.ToolStripMenuItem editMWButton;
		private System.Windows.Forms.ToolStripDropDownButton settingsDropDown;
		private System.Windows.Forms.ToolStripMenuItem connectionButton;
		private System.Windows.Forms.ToolStripButton resetButton;
	}
}