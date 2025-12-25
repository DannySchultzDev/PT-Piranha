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
			this.mainToolStrip = new System.Windows.Forms.ToolStrip();
			this.resetButton = new System.Windows.Forms.ToolStripButton();
			this.portTextBox = new System.Windows.Forms.ToolStripTextBox();
			this.portLabel = new System.Windows.Forms.ToolStripLabel();
			this.IPTextBox = new System.Windows.Forms.ToolStripTextBox();
			this.IPLabel = new System.Windows.Forms.ToolStripLabel();
			this.fileDropDown = new System.Windows.Forms.ToolStripDropDownButton();
			this.generateYAMLsButton = new System.Windows.Forms.ToolStripMenuItem();
			this.fileSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.generateMWButton = new System.Windows.Forms.ToolStripMenuItem();
			this.editMWButton = new System.Windows.Forms.ToolStripMenuItem();
			this.loadMWButton = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsDropDown = new System.Windows.Forms.ToolStripDropDownButton();
			this.connectionButton = new System.Windows.Forms.ToolStripMenuItem();
			this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
			this.statusPercentageBar = new System.Windows.Forms.ToolStripProgressBar();
			this.statusSpringLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.mainToolStripContainer = new System.Windows.Forms.ToolStripContainer();
			this.mainPictureBox = new System.Windows.Forms.PictureBox();
			this.mainToolStrip.SuspendLayout();
			this.mainStatusStrip.SuspendLayout();
			this.mainToolStripContainer.BottomToolStripPanel.SuspendLayout();
			this.mainToolStripContainer.ContentPanel.SuspendLayout();
			this.mainToolStripContainer.TopToolStripPanel.SuspendLayout();
			this.mainToolStripContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// mainToolStrip
			// 
			this.mainToolStrip.Dock = System.Windows.Forms.DockStyle.None;
			this.mainToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.mainToolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetButton,
            this.portTextBox,
            this.portLabel,
            this.IPTextBox,
            this.IPLabel,
            this.fileDropDown,
            this.settingsDropDown});
			this.mainToolStrip.Location = new System.Drawing.Point(0, 0);
			this.mainToolStrip.Name = "mainToolStrip";
			this.mainToolStrip.Size = new System.Drawing.Size(658, 34);
			this.mainToolStrip.Stretch = true;
			this.mainToolStrip.TabIndex = 0;
			this.mainToolStrip.Text = "toolStrip1";
			// 
			// resetButton
			// 
			this.resetButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.resetButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.resetButton.Image = global::PT_Piranha.Properties.Resources.Restart;
			this.resetButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.resetButton.Name = "resetButton";
			this.resetButton.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
			this.resetButton.Size = new System.Drawing.Size(34, 29);
			this.resetButton.Text = "toolStripButton1";
			this.resetButton.ToolTipText = "Reset to defaults";
			this.resetButton.Click += new System.EventHandler(this.ResetButton_Click);
			// 
			// portTextBox
			// 
			this.portTextBox.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.portTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.portTextBox.Name = "portTextBox";
			this.portTextBox.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
			this.portTextBox.Size = new System.Drawing.Size(100, 34);
			this.portTextBox.Validated += new System.EventHandler(this.portTextBox_Validated);
			// 
			// portLabel
			// 
			this.portLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.portLabel.Name = "portLabel";
			this.portLabel.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
			this.portLabel.Size = new System.Drawing.Size(48, 29);
			this.portLabel.Text = "Port:";
			// 
			// IPTextBox
			// 
			this.IPTextBox.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.IPTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.IPTextBox.Name = "IPTextBox";
			this.IPTextBox.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
			this.IPTextBox.Size = new System.Drawing.Size(100, 34);
			this.IPTextBox.Validated += new System.EventHandler(this.IPChanged);
			// 
			// IPLabel
			// 
			this.IPLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.IPLabel.Name = "IPLabel";
			this.IPLabel.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
			this.IPLabel.Size = new System.Drawing.Size(31, 29);
			this.IPLabel.Text = "IP:";
			// 
			// fileDropDown
			// 
			this.fileDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.fileDropDown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateYAMLsButton,
            this.fileSeparator,
            this.generateMWButton,
            this.editMWButton,
            this.loadMWButton});
			this.fileDropDown.Image = ((System.Drawing.Image)(resources.GetObject("fileDropDown.Image")));
			this.fileDropDown.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.fileDropDown.Name = "fileDropDown";
			this.fileDropDown.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
			this.fileDropDown.Size = new System.Drawing.Size(56, 29);
			this.fileDropDown.Text = "File";
			// 
			// generateYAMLsButton
			// 
			this.generateYAMLsButton.Name = "generateYAMLsButton";
			this.generateYAMLsButton.Size = new System.Drawing.Size(333, 34);
			this.generateYAMLsButton.Text = "Generate YAMLs";
			this.generateYAMLsButton.Click += new System.EventHandler(this.GenerateYamlsButton_Click);
			// 
			// fileSeparator
			// 
			this.fileSeparator.Name = "fileSeparator";
			this.fileSeparator.Size = new System.Drawing.Size(330, 6);
			// 
			// generateMWButton
			// 
			this.generateMWButton.Name = "generateMWButton";
			this.generateMWButton.Size = new System.Drawing.Size(333, 34);
			this.generateMWButton.Text = "Generate Multiworld Tracker";
			this.generateMWButton.Click += new System.EventHandler(this.GenerateMWButton_Click);
			// 
			// editMWButton
			// 
			this.editMWButton.Name = "editMWButton";
			this.editMWButton.Size = new System.Drawing.Size(333, 34);
			this.editMWButton.Text = "Edit Multiworld Tracker";
			this.editMWButton.Click += new System.EventHandler(this.EditMWButton_Click);
			// 
			// loadMWButton
			// 
			this.loadMWButton.Name = "loadMWButton";
			this.loadMWButton.Size = new System.Drawing.Size(333, 34);
			this.loadMWButton.Text = "Load Multiworld Tracker";
			this.loadMWButton.Click += new System.EventHandler(this.LoadGameButton_Click);
			// 
			// settingsDropDown
			// 
			this.settingsDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.settingsDropDown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionButton});
			this.settingsDropDown.Image = ((System.Drawing.Image)(resources.GetObject("settingsDropDown.Image")));
			this.settingsDropDown.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.settingsDropDown.Name = "settingsDropDown";
			this.settingsDropDown.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
			this.settingsDropDown.Size = new System.Drawing.Size(94, 29);
			this.settingsDropDown.Text = "Settings";
			// 
			// connectionButton
			// 
			this.connectionButton.Name = "connectionButton";
			this.connectionButton.Size = new System.Drawing.Size(204, 34);
			this.connectionButton.Text = "Connection";
			this.connectionButton.Click += new System.EventHandler(this.ConnectionSettingsButton_Click);
			// 
			// mainStatusStrip
			// 
			this.mainStatusStrip.Dock = System.Windows.Forms.DockStyle.None;
			this.mainStatusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusPercentageBar,
            this.statusSpringLabel,
            this.statusLabel});
			this.mainStatusStrip.Location = new System.Drawing.Point(0, 0);
			this.mainStatusStrip.Name = "mainStatusStrip";
			this.mainStatusStrip.ShowItemToolTips = true;
			this.mainStatusStrip.Size = new System.Drawing.Size(658, 32);
			this.mainStatusStrip.SizingGrip = false;
			this.mainStatusStrip.TabIndex = 0;
			this.mainStatusStrip.Text = "statusStrip1";
			// 
			// statusPercentageBar
			// 
			this.statusPercentageBar.Name = "statusPercentageBar";
			this.statusPercentageBar.Size = new System.Drawing.Size(300, 24);
			// 
			// statusSpringLabel
			// 
			this.statusSpringLabel.Name = "statusSpringLabel";
			this.statusSpringLabel.Size = new System.Drawing.Size(216, 25);
			this.statusSpringLabel.Spring = true;
			// 
			// statusLabel
			// 
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(123, 25);
			this.statusLabel.Text = "Current Status";
			// 
			// mainToolStripContainer
			// 
			// 
			// mainToolStripContainer.BottomToolStripPanel
			// 
			this.mainToolStripContainer.BottomToolStripPanel.Controls.Add(this.mainStatusStrip);
			// 
			// mainToolStripContainer.ContentPanel
			// 
			this.mainToolStripContainer.ContentPanel.Controls.Add(this.mainPictureBox);
			this.mainToolStripContainer.ContentPanel.Size = new System.Drawing.Size(658, 378);
			this.mainToolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainToolStripContainer.LeftToolStripPanelVisible = false;
			this.mainToolStripContainer.Location = new System.Drawing.Point(0, 0);
			this.mainToolStripContainer.Name = "mainToolStripContainer";
			this.mainToolStripContainer.RightToolStripPanelVisible = false;
			this.mainToolStripContainer.Size = new System.Drawing.Size(658, 444);
			this.mainToolStripContainer.TabIndex = 2;
			this.mainToolStripContainer.Text = "toolStripContainer1";
			// 
			// mainToolStripContainer.TopToolStripPanel
			// 
			this.mainToolStripContainer.TopToolStripPanel.Controls.Add(this.mainToolStrip);
			// 
			// mainPictureBox
			// 
			this.mainPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainPictureBox.Location = new System.Drawing.Point(0, 0);
			this.mainPictureBox.Name = "mainPictureBox";
			this.mainPictureBox.Size = new System.Drawing.Size(658, 378);
			this.mainPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.mainPictureBox.TabIndex = 1;
			this.mainPictureBox.TabStop = false;
			this.mainPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainPictureBox_MouseMove);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(658, 444);
			this.Controls.Add(this.mainToolStripContainer);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Main";
			this.Text = "PT Piranha";
			this.Load += new System.EventHandler(this.Main_Load);
			this.ResizeEnd += new System.EventHandler(this.Main_ResizeEnd);
			this.mainToolStrip.ResumeLayout(false);
			this.mainToolStrip.PerformLayout();
			this.mainStatusStrip.ResumeLayout(false);
			this.mainStatusStrip.PerformLayout();
			this.mainToolStripContainer.BottomToolStripPanel.ResumeLayout(false);
			this.mainToolStripContainer.BottomToolStripPanel.PerformLayout();
			this.mainToolStripContainer.ContentPanel.ResumeLayout(false);
			this.mainToolStripContainer.TopToolStripPanel.ResumeLayout(false);
			this.mainToolStripContainer.TopToolStripPanel.PerformLayout();
			this.mainToolStripContainer.ResumeLayout(false);
			this.mainToolStripContainer.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).EndInit();
			this.ResumeLayout(false);

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