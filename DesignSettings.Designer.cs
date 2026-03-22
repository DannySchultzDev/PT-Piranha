namespace PT_Piranha
{
	partial class DesignSettings
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
			mainTableLayoutPanel = new TableLayoutPanel();
			defaultGradientLabel = new Label();
			defaultGradientButton = new Button();
			defaultClearColorLabel = new Label();
			defaultClearColorButton = new Button();
			backgroundImageLabel = new Label();
			backgroundImageButton = new Button();
			backgroundImageClearButton = new Button();
			backgroundImageStyleLabel = new Label();
			backgroundImageStyleComboBox = new ComboBox();
			showBackgroundImageLabel = new Label();
			showBackgroundImageComboBox = new ComboBox();
			itemGroupStyleLabel = new Label();
			itemGroupStyleComboBox = new ComboBox();
			progressBarStyleLabel = new Label();
			progressBarStyleComboBox = new ComboBox();
			overlayStyleLabel = new Label();
			overlayStyleComboBox = new ComboBox();
			overlayInterpolationLabel = new Label();
			overlayInterpolationComboBox = new ComboBox();
			saveButton = new Button();
			cancelButton = new Button();
			mainTableLayoutPanel.SuspendLayout();
			SuspendLayout();
			// 
			// mainTableLayoutPanel
			// 
			mainTableLayoutPanel.ColumnCount = 5;
			mainTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 225F));
			mainTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			mainTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			mainTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 175F));
			mainTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
			mainTableLayoutPanel.Controls.Add(defaultGradientLabel, 0, 0);
			mainTableLayoutPanel.Controls.Add(defaultGradientButton, 1, 0);
			mainTableLayoutPanel.Controls.Add(defaultClearColorLabel, 0, 1);
			mainTableLayoutPanel.Controls.Add(defaultClearColorButton, 1, 1);
			mainTableLayoutPanel.Controls.Add(backgroundImageLabel, 0, 2);
			mainTableLayoutPanel.Controls.Add(backgroundImageButton, 1, 2);
			mainTableLayoutPanel.Controls.Add(backgroundImageClearButton, 4, 2);
			mainTableLayoutPanel.Controls.Add(backgroundImageStyleLabel, 0, 3);
			mainTableLayoutPanel.Controls.Add(backgroundImageStyleComboBox, 1, 3);
			mainTableLayoutPanel.Controls.Add(showBackgroundImageLabel, 0, 4);
			mainTableLayoutPanel.Controls.Add(showBackgroundImageComboBox, 1, 4);
			mainTableLayoutPanel.Controls.Add(itemGroupStyleLabel, 0, 5);
			mainTableLayoutPanel.Controls.Add(itemGroupStyleComboBox, 1, 5);
			mainTableLayoutPanel.Controls.Add(progressBarStyleLabel, 0, 6);
			mainTableLayoutPanel.Controls.Add(progressBarStyleComboBox, 1, 6);
			mainTableLayoutPanel.Controls.Add(overlayStyleLabel, 0, 7);
			mainTableLayoutPanel.Controls.Add(overlayStyleComboBox, 1, 7);
			mainTableLayoutPanel.Controls.Add(overlayInterpolationLabel, 0, 8);
			mainTableLayoutPanel.Controls.Add(overlayInterpolationComboBox, 1, 8);
			mainTableLayoutPanel.Controls.Add(saveButton, 0, 9);
			mainTableLayoutPanel.Controls.Add(cancelButton, 2, 9);
			mainTableLayoutPanel.Dock = DockStyle.Fill;
			mainTableLayoutPanel.Location = new Point(0, 0);
			mainTableLayoutPanel.Name = "mainTableLayoutPanel";
			mainTableLayoutPanel.RowCount = 10;
			mainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
			mainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
			mainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
			mainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
			mainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
			mainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
			mainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
			mainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
			mainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
			mainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
			mainTableLayoutPanel.Size = new Size(578, 444);
			mainTableLayoutPanel.TabIndex = 0;
			// 
			// defaultGradientLabel
			// 
			defaultGradientLabel.AutoSize = true;
			defaultGradientLabel.Dock = DockStyle.Fill;
			defaultGradientLabel.Location = new Point(3, 0);
			defaultGradientLabel.Name = "defaultGradientLabel";
			defaultGradientLabel.Size = new Size(219, 43);
			defaultGradientLabel.TabIndex = 0;
			defaultGradientLabel.Text = "Default Gradient:";
			// 
			// defaultGradientButton
			// 
			mainTableLayoutPanel.SetColumnSpan(defaultGradientButton, 4);
			defaultGradientButton.Dock = DockStyle.Fill;
			defaultGradientButton.FlatStyle = FlatStyle.Flat;
			defaultGradientButton.Location = new Point(228, 3);
			defaultGradientButton.Name = "defaultGradientButton";
			defaultGradientButton.Size = new Size(347, 37);
			defaultGradientButton.TabIndex = 1;
			defaultGradientButton.UseVisualStyleBackColor = true;
			defaultGradientButton.Click += defaultGradientButton_Click;
			defaultGradientButton.Paint += defaultGradientButton_Paint;
			// 
			// defaultClearColorLabel
			// 
			defaultClearColorLabel.AutoSize = true;
			defaultClearColorLabel.Dock = DockStyle.Fill;
			defaultClearColorLabel.Location = new Point(3, 43);
			defaultClearColorLabel.Name = "defaultClearColorLabel";
			defaultClearColorLabel.Size = new Size(219, 43);
			defaultClearColorLabel.TabIndex = 2;
			defaultClearColorLabel.Text = "Default Clear Color:";
			// 
			// defaultClearColorButton
			// 
			mainTableLayoutPanel.SetColumnSpan(defaultClearColorButton, 4);
			defaultClearColorButton.Dock = DockStyle.Fill;
			defaultClearColorButton.FlatStyle = FlatStyle.Flat;
			defaultClearColorButton.Location = new Point(228, 46);
			defaultClearColorButton.Name = "defaultClearColorButton";
			defaultClearColorButton.Size = new Size(347, 37);
			defaultClearColorButton.TabIndex = 3;
			defaultClearColorButton.UseVisualStyleBackColor = true;
			defaultClearColorButton.Click += defaultClearColorButton_Click;
			// 
			// backgroundImageLabel
			// 
			backgroundImageLabel.AutoSize = true;
			backgroundImageLabel.Dock = DockStyle.Fill;
			backgroundImageLabel.Location = new Point(3, 86);
			backgroundImageLabel.Name = "backgroundImageLabel";
			backgroundImageLabel.Size = new Size(219, 43);
			backgroundImageLabel.TabIndex = 4;
			backgroundImageLabel.Text = "Background Image:";
			// 
			// backgroundImageButton
			// 
			backgroundImageButton.BackgroundImageLayout = ImageLayout.Zoom;
			mainTableLayoutPanel.SetColumnSpan(backgroundImageButton, 3);
			backgroundImageButton.Dock = DockStyle.Fill;
			backgroundImageButton.FlatStyle = FlatStyle.Flat;
			backgroundImageButton.Location = new Point(228, 89);
			backgroundImageButton.Name = "backgroundImageButton";
			backgroundImageButton.Size = new Size(297, 37);
			backgroundImageButton.TabIndex = 5;
			backgroundImageButton.UseVisualStyleBackColor = true;
			backgroundImageButton.Click += backgroundImageButton_Click;
			// 
			// backgroundImageClearButton
			// 
			backgroundImageClearButton.Dock = DockStyle.Fill;
			backgroundImageClearButton.FlatStyle = FlatStyle.Flat;
			backgroundImageClearButton.Image = Properties.Resources.Trash;
			backgroundImageClearButton.Location = new Point(531, 89);
			backgroundImageClearButton.Name = "backgroundImageClearButton";
			backgroundImageClearButton.Size = new Size(44, 37);
			backgroundImageClearButton.TabIndex = 6;
			backgroundImageClearButton.UseVisualStyleBackColor = true;
			backgroundImageClearButton.Click += backgroundImageClearButton_Click;
			// 
			// backgroundImageStyleLabel
			// 
			backgroundImageStyleLabel.AutoSize = true;
			backgroundImageStyleLabel.Dock = DockStyle.Fill;
			backgroundImageStyleLabel.Location = new Point(3, 129);
			backgroundImageStyleLabel.Name = "backgroundImageStyleLabel";
			backgroundImageStyleLabel.Size = new Size(219, 43);
			backgroundImageStyleLabel.TabIndex = 7;
			backgroundImageStyleLabel.Text = "Background Image Style:";
			// 
			// backgroundImageStyleComboBox
			// 
			backgroundImageStyleComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			backgroundImageStyleComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
			mainTableLayoutPanel.SetColumnSpan(backgroundImageStyleComboBox, 4);
			backgroundImageStyleComboBox.Dock = DockStyle.Fill;
			backgroundImageStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			backgroundImageStyleComboBox.FormattingEnabled = true;
			backgroundImageStyleComboBox.Items.AddRange(new object[] { "Tile", "Stretch", "Clip", "Fit" });
			backgroundImageStyleComboBox.Location = new Point(228, 132);
			backgroundImageStyleComboBox.Name = "backgroundImageStyleComboBox";
			backgroundImageStyleComboBox.Size = new Size(347, 33);
			backgroundImageStyleComboBox.TabIndex = 8;
			// 
			// showBackgroundImageLabel
			// 
			showBackgroundImageLabel.AutoSize = true;
			showBackgroundImageLabel.Dock = DockStyle.Fill;
			showBackgroundImageLabel.Location = new Point(3, 172);
			showBackgroundImageLabel.Name = "showBackgroundImageLabel";
			showBackgroundImageLabel.Size = new Size(219, 43);
			showBackgroundImageLabel.TabIndex = 9;
			showBackgroundImageLabel.Text = "Show Background Image:";
			// 
			// showBackgroundImageComboBox
			// 
			showBackgroundImageComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			showBackgroundImageComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
			mainTableLayoutPanel.SetColumnSpan(showBackgroundImageComboBox, 4);
			showBackgroundImageComboBox.Dock = DockStyle.Fill;
			showBackgroundImageComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			showBackgroundImageComboBox.FormattingEnabled = true;
			showBackgroundImageComboBox.Items.AddRange(new object[] { "Empty Cells Only", "Completed Games", "Completed Item Groups" });
			showBackgroundImageComboBox.Location = new Point(228, 175);
			showBackgroundImageComboBox.Name = "showBackgroundImageComboBox";
			showBackgroundImageComboBox.Size = new Size(347, 33);
			showBackgroundImageComboBox.TabIndex = 10;
			// 
			// itemGroupStyleLabel
			// 
			itemGroupStyleLabel.AutoSize = true;
			itemGroupStyleLabel.Dock = DockStyle.Fill;
			itemGroupStyleLabel.Location = new Point(3, 215);
			itemGroupStyleLabel.Name = "itemGroupStyleLabel";
			itemGroupStyleLabel.Size = new Size(219, 43);
			itemGroupStyleLabel.TabIndex = 11;
			itemGroupStyleLabel.Text = "Item Group Style:";
			// 
			// itemGroupStyleComboBox
			// 
			itemGroupStyleComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			itemGroupStyleComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
			mainTableLayoutPanel.SetColumnSpan(itemGroupStyleComboBox, 4);
			itemGroupStyleComboBox.Dock = DockStyle.Fill;
			itemGroupStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			itemGroupStyleComboBox.FormattingEnabled = true;
			itemGroupStyleComboBox.Items.AddRange(new object[] { "Seperate Games", "Fluid", "Jumble", "Voronoi" });
			itemGroupStyleComboBox.Location = new Point(228, 218);
			itemGroupStyleComboBox.Name = "itemGroupStyleComboBox";
			itemGroupStyleComboBox.Size = new Size(347, 33);
			itemGroupStyleComboBox.TabIndex = 12;
			// 
			// progressBarStyleLabel
			// 
			progressBarStyleLabel.AutoSize = true;
			progressBarStyleLabel.Dock = DockStyle.Fill;
			progressBarStyleLabel.Location = new Point(3, 258);
			progressBarStyleLabel.Name = "progressBarStyleLabel";
			progressBarStyleLabel.Size = new Size(219, 43);
			progressBarStyleLabel.TabIndex = 13;
			progressBarStyleLabel.Text = "Progress Bar Style:";
			// 
			// progressBarStyleComboBox
			// 
			progressBarStyleComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			progressBarStyleComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
			mainTableLayoutPanel.SetColumnSpan(progressBarStyleComboBox, 4);
			progressBarStyleComboBox.Dock = DockStyle.Fill;
			progressBarStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			progressBarStyleComboBox.FormattingEnabled = true;
			progressBarStyleComboBox.Items.AddRange(new object[] { "Locations", "Item Groups", "Item Groups Completed", "Game Percentages", "Games Completed" });
			progressBarStyleComboBox.Location = new Point(228, 261);
			progressBarStyleComboBox.Name = "progressBarStyleComboBox";
			progressBarStyleComboBox.Size = new Size(347, 33);
			progressBarStyleComboBox.TabIndex = 14;
			// 
			// overlayStyleLabel
			// 
			overlayStyleLabel.AutoSize = true;
			overlayStyleLabel.Dock = DockStyle.Fill;
			overlayStyleLabel.Location = new Point(3, 301);
			overlayStyleLabel.Name = "overlayStyleLabel";
			overlayStyleLabel.Size = new Size(219, 43);
			overlayStyleLabel.TabIndex = 15;
			overlayStyleLabel.Text = "Overlay Style:";
			// 
			// overlayStyleComboBox
			// 
			overlayStyleComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			overlayStyleComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
			mainTableLayoutPanel.SetColumnSpan(overlayStyleComboBox, 4);
			overlayStyleComboBox.Dock = DockStyle.Fill;
			overlayStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			overlayStyleComboBox.FormattingEnabled = true;
			overlayStyleComboBox.Items.AddRange(new object[] { "Image Or Text", "Combo", "Text Only", "Image Only", "None" });
			overlayStyleComboBox.Location = new Point(228, 304);
			overlayStyleComboBox.Name = "overlayStyleComboBox";
			overlayStyleComboBox.Size = new Size(347, 33);
			overlayStyleComboBox.TabIndex = 16;
			// 
			// overlayInterpolationLabel
			// 
			overlayInterpolationLabel.AutoSize = true;
			overlayInterpolationLabel.Dock = DockStyle.Fill;
			overlayInterpolationLabel.Location = new Point(3, 344);
			overlayInterpolationLabel.Name = "overlayInterpolationLabel";
			overlayInterpolationLabel.Size = new Size(219, 43);
			overlayInterpolationLabel.TabIndex = 17;
			overlayInterpolationLabel.Text = "Overlay Interpolation:";
			// 
			// overlayInterpolationComboBox
			// 
			overlayInterpolationComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			overlayInterpolationComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
			mainTableLayoutPanel.SetColumnSpan(overlayInterpolationComboBox, 4);
			overlayInterpolationComboBox.Dock = DockStyle.Fill;
			overlayInterpolationComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			overlayInterpolationComboBox.FormattingEnabled = true;
			overlayInterpolationComboBox.Items.AddRange(new object[] { "None", "Default" });
			overlayInterpolationComboBox.Location = new Point(228, 347);
			overlayInterpolationComboBox.Name = "overlayInterpolationComboBox";
			overlayInterpolationComboBox.Size = new Size(347, 33);
			overlayInterpolationComboBox.TabIndex = 18;
			// 
			// saveButton
			// 
			mainTableLayoutPanel.SetColumnSpan(saveButton, 2);
			saveButton.DialogResult = DialogResult.OK;
			saveButton.Dock = DockStyle.Fill;
			saveButton.Location = new Point(3, 390);
			saveButton.Name = "saveButton";
			saveButton.Size = new Size(283, 51);
			saveButton.TabIndex = 19;
			saveButton.Text = "Save";
			saveButton.UseVisualStyleBackColor = true;
			saveButton.Click += saveButton_Click;
			// 
			// cancelButton
			// 
			mainTableLayoutPanel.SetColumnSpan(cancelButton, 3);
			cancelButton.DialogResult = DialogResult.Cancel;
			cancelButton.Dock = DockStyle.Fill;
			cancelButton.Location = new Point(292, 390);
			cancelButton.Name = "cancelButton";
			cancelButton.Size = new Size(283, 51);
			cancelButton.TabIndex = 20;
			cancelButton.Text = "Cancel";
			cancelButton.UseVisualStyleBackColor = true;
			// 
			// DesignSettings
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(578, 444);
			Controls.Add(mainTableLayoutPanel);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "DesignSettings";
			Text = "Design Settings";
			Load += DesignSettings_Load;
			mainTableLayoutPanel.ResumeLayout(false);
			mainTableLayoutPanel.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private TableLayoutPanel mainTableLayoutPanel;
		private Label defaultGradientLabel;
		private Button defaultGradientButton;
		private Label defaultClearColorLabel;
		private Button defaultClearColorButton;
		private Label backgroundImageLabel;
		private Button backgroundImageButton;
		private Button backgroundImageClearButton;
		private Label backgroundImageStyleLabel;
		private ComboBox backgroundImageStyleComboBox;
		private Label itemGroupStyleLabel;
		private ComboBox itemGroupStyleComboBox;
		private Label progressBarStyleLabel;
		private ComboBox progressBarStyleComboBox;
		private Label overlayStyleLabel;
		private ComboBox overlayStyleComboBox;
		private Label showBackgroundImageLabel;
		private ComboBox showBackgroundImageComboBox;
		private Button saveButton;
		private Button cancelButton;
		private Label overlayInterpolationLabel;
		private ComboBox overlayInterpolationComboBox;
	}
}