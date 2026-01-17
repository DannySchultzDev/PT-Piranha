namespace PT_Piranha
{
	partial class MWGEN
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
			outerTableLayout = new TableLayoutPanel();
			outerSplitContainer = new SplitContainer();
			tableLayoutPanel1 = new TableLayoutPanel();
			gamesLabel = new Label();
			gamesDataGridView = new DataGridView();
			gameIndexColumn = new DataGridViewTextBoxColumn();
			gameNameColumn = new DataGridViewTextBoxColumn();
			playerNameColumn = new DataGridViewTextBoxColumn();
			worldCountColumn = new DataGridViewTextBoxColumn();
			innerSplitContainer = new SplitContainer();
			tableLayoutPanel2 = new TableLayoutPanel();
			itemGroupsLabel = new Label();
			itemGroupsDataGridView = new DataGridView();
			itemGroupIndexColumn = new DataGridViewTextBoxColumn();
			itemGroupNameColumn = new DataGridViewTextBoxColumn();
			gameColumn = new DataGridViewTextBoxColumn();
			itemGroupLocationColumn = new DataGridViewCheckBoxColumn();
			itemGroupGradientColumn = new ImageButtonColumn();
			itemGroupClearColorColumn = new DataGridViewButtonColumn();
			itemGroupOverlayColumn = new ImageButtonColumn();
			tableLayoutPanel3 = new TableLayoutPanel();
			itemGroupPartsLabel = new Label();
			itemGroupPartsDataGridView = new DataGridView();
			itemGroupPartIndexColumn = new DataGridViewTextBoxColumn();
			itemGroupPartNameColumn = new DataGridViewTextBoxColumn();
			itemGroupColumn = new DataGridViewTextBoxColumn();
			ItemGroupPartValueColumn = new DataGridViewTextBoxColumn();
			generateButton = new Button();
			addWorldButton = new Button();
			imageButtonColumn1 = new ImageButtonColumn();
			dataGridViewButtonColumn1 = new DataGridViewButtonColumn();
			imageButtonColumn2 = new ImageButtonColumn();
			dataGridViewButtonColumn2 = new DataGridViewButtonColumn();
			dataGridViewButtonColumn3 = new DataGridViewButtonColumn();
			outerTableLayout.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)outerSplitContainer).BeginInit();
			outerSplitContainer.Panel1.SuspendLayout();
			outerSplitContainer.Panel2.SuspendLayout();
			outerSplitContainer.SuspendLayout();
			tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)gamesDataGridView).BeginInit();
			((System.ComponentModel.ISupportInitialize)innerSplitContainer).BeginInit();
			innerSplitContainer.Panel1.SuspendLayout();
			innerSplitContainer.Panel2.SuspendLayout();
			innerSplitContainer.SuspendLayout();
			tableLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)itemGroupsDataGridView).BeginInit();
			tableLayoutPanel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)itemGroupPartsDataGridView).BeginInit();
			SuspendLayout();
			// 
			// outerTableLayout
			// 
			outerTableLayout.ColumnCount = 2;
			outerTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			outerTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			outerTableLayout.Controls.Add(outerSplitContainer, 0, 0);
			outerTableLayout.Controls.Add(generateButton, 0, 1);
			outerTableLayout.Controls.Add(addWorldButton, 1, 1);
			outerTableLayout.Dock = DockStyle.Fill;
			outerTableLayout.Location = new Point(0, 0);
			outerTableLayout.Margin = new Padding(3, 4, 3, 4);
			outerTableLayout.Name = "outerTableLayout";
			outerTableLayout.RowCount = 2;
			outerTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			outerTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
			outerTableLayout.Size = new Size(889, 822);
			outerTableLayout.TabIndex = 0;
			// 
			// outerSplitContainer
			// 
			outerTableLayout.SetColumnSpan(outerSplitContainer, 2);
			outerSplitContainer.Dock = DockStyle.Fill;
			outerSplitContainer.Location = new Point(3, 4);
			outerSplitContainer.Margin = new Padding(3, 4, 3, 4);
			outerSplitContainer.Name = "outerSplitContainer";
			outerSplitContainer.Orientation = Orientation.Horizontal;
			// 
			// outerSplitContainer.Panel1
			// 
			outerSplitContainer.Panel1.Controls.Add(tableLayoutPanel1);
			// 
			// outerSplitContainer.Panel2
			// 
			outerSplitContainer.Panel2.Controls.Add(innerSplitContainer);
			outerSplitContainer.Size = new Size(883, 752);
			outerSplitContainer.SplitterDistance = 100;
			outerSplitContainer.SplitterWidth = 5;
			outerSplitContainer.TabIndex = 0;
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 1;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel1.Controls.Add(gamesLabel, 0, 0);
			tableLayoutPanel1.Controls.Add(gamesDataGridView, 0, 1);
			tableLayoutPanel1.Dock = DockStyle.Fill;
			tableLayoutPanel1.Location = new Point(0, 0);
			tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 2;
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			tableLayoutPanel1.Size = new Size(883, 100);
			tableLayoutPanel1.TabIndex = 0;
			// 
			// gamesLabel
			// 
			gamesLabel.AutoSize = true;
			gamesLabel.Dock = DockStyle.Fill;
			gamesLabel.Location = new Point(3, 0);
			gamesLabel.Name = "gamesLabel";
			gamesLabel.Size = new Size(877, 38);
			gamesLabel.TabIndex = 0;
			gamesLabel.Text = "Games:";
			// 
			// gamesDataGridView
			// 
			gamesDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			gamesDataGridView.BackgroundColor = SystemColors.Control;
			gamesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			gamesDataGridView.Columns.AddRange(new DataGridViewColumn[] { gameIndexColumn, gameNameColumn, playerNameColumn, worldCountColumn });
			gamesDataGridView.Dock = DockStyle.Fill;
			gamesDataGridView.GridColor = SystemColors.Control;
			gamesDataGridView.Location = new Point(3, 42);
			gamesDataGridView.Margin = new Padding(3, 4, 3, 4);
			gamesDataGridView.Name = "gamesDataGridView";
			gamesDataGridView.RowHeadersWidth = 62;
			gamesDataGridView.RowTemplate.Height = 28;
			gamesDataGridView.Size = new Size(877, 54);
			gamesDataGridView.TabIndex = 1;
			gamesDataGridView.CellFormatting += FormatGameTable;
			gamesDataGridView.CellValidated += CellChanged;
			// 
			// gameIndexColumn
			// 
			gameIndexColumn.HeaderText = "ID";
			gameIndexColumn.MinimumWidth = 8;
			gameIndexColumn.Name = "gameIndexColumn";
			gameIndexColumn.ReadOnly = true;
			// 
			// gameNameColumn
			// 
			gameNameColumn.HeaderText = "Game Name";
			gameNameColumn.MinimumWidth = 8;
			gameNameColumn.Name = "gameNameColumn";
			// 
			// playerNameColumn
			// 
			playerNameColumn.HeaderText = "Player Name";
			playerNameColumn.MinimumWidth = 8;
			playerNameColumn.Name = "playerNameColumn";
			// 
			// worldCountColumn
			// 
			worldCountColumn.HeaderText = "Number of Worlds";
			worldCountColumn.MinimumWidth = 8;
			worldCountColumn.Name = "worldCountColumn";
			// 
			// innerSplitContainer
			// 
			innerSplitContainer.Dock = DockStyle.Fill;
			innerSplitContainer.Location = new Point(0, 0);
			innerSplitContainer.Margin = new Padding(3, 4, 3, 4);
			innerSplitContainer.Name = "innerSplitContainer";
			innerSplitContainer.Orientation = Orientation.Horizontal;
			// 
			// innerSplitContainer.Panel1
			// 
			innerSplitContainer.Panel1.Controls.Add(tableLayoutPanel2);
			// 
			// innerSplitContainer.Panel2
			// 
			innerSplitContainer.Panel2.Controls.Add(tableLayoutPanel3);
			innerSplitContainer.Size = new Size(883, 647);
			innerSplitContainer.SplitterDistance = 118;
			innerSplitContainer.SplitterWidth = 5;
			innerSplitContainer.TabIndex = 0;
			// 
			// tableLayoutPanel2
			// 
			tableLayoutPanel2.ColumnCount = 1;
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel2.Controls.Add(itemGroupsLabel, 0, 0);
			tableLayoutPanel2.Controls.Add(itemGroupsDataGridView, 0, 1);
			tableLayoutPanel2.Dock = DockStyle.Fill;
			tableLayoutPanel2.Location = new Point(0, 0);
			tableLayoutPanel2.Margin = new Padding(3, 4, 3, 4);
			tableLayoutPanel2.Name = "tableLayoutPanel2";
			tableLayoutPanel2.RowCount = 2;
			tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
			tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			tableLayoutPanel2.Size = new Size(883, 118);
			tableLayoutPanel2.TabIndex = 0;
			// 
			// itemGroupsLabel
			// 
			itemGroupsLabel.AutoSize = true;
			itemGroupsLabel.Dock = DockStyle.Fill;
			itemGroupsLabel.Location = new Point(3, 0);
			itemGroupsLabel.Name = "itemGroupsLabel";
			itemGroupsLabel.Size = new Size(877, 38);
			itemGroupsLabel.TabIndex = 0;
			itemGroupsLabel.Text = "Item Groups:";
			// 
			// itemGroupsDataGridView
			// 
			itemGroupsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			itemGroupsDataGridView.BackgroundColor = SystemColors.Control;
			itemGroupsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			itemGroupsDataGridView.Columns.AddRange(new DataGridViewColumn[] { itemGroupIndexColumn, itemGroupNameColumn, gameColumn, itemGroupLocationColumn, itemGroupGradientColumn, itemGroupClearColorColumn, itemGroupOverlayColumn });
			itemGroupsDataGridView.Dock = DockStyle.Fill;
			itemGroupsDataGridView.GridColor = SystemColors.Control;
			itemGroupsDataGridView.Location = new Point(3, 42);
			itemGroupsDataGridView.Margin = new Padding(3, 4, 3, 4);
			itemGroupsDataGridView.Name = "itemGroupsDataGridView";
			itemGroupsDataGridView.RowHeadersWidth = 62;
			itemGroupsDataGridView.RowTemplate.Height = 28;
			itemGroupsDataGridView.Size = new Size(877, 72);
			itemGroupsDataGridView.TabIndex = 1;
			itemGroupsDataGridView.CellContentClick += ClickItemGroupCell;
			itemGroupsDataGridView.CellFormatting += FormatItemGroupTable;
			itemGroupsDataGridView.CellPainting += PaintItemGroupCell;
			itemGroupsDataGridView.RowValidated += CellChanged;
			// 
			// itemGroupIndexColumn
			// 
			itemGroupIndexColumn.HeaderText = "ID";
			itemGroupIndexColumn.MinimumWidth = 8;
			itemGroupIndexColumn.Name = "itemGroupIndexColumn";
			itemGroupIndexColumn.ReadOnly = true;
			// 
			// itemGroupNameColumn
			// 
			itemGroupNameColumn.HeaderText = "Item Group Name";
			itemGroupNameColumn.MinimumWidth = 8;
			itemGroupNameColumn.Name = "itemGroupNameColumn";
			// 
			// gameColumn
			// 
			gameColumn.HeaderText = "Game ID";
			gameColumn.MinimumWidth = 8;
			gameColumn.Name = "gameColumn";
			// 
			// itemGroupLocationColumn
			// 
			itemGroupLocationColumn.HeaderText = "Is Location";
			itemGroupLocationColumn.MinimumWidth = 8;
			itemGroupLocationColumn.Name = "itemGroupLocationColumn";
			// 
			// itemGroupGradientColumn
			// 
			itemGroupGradientColumn.FlatStyle = FlatStyle.Flat;
			itemGroupGradientColumn.HeaderText = "Gradient";
			itemGroupGradientColumn.MinimumWidth = 8;
			itemGroupGradientColumn.Name = "itemGroupGradientColumn";
			itemGroupGradientColumn.Resizable = DataGridViewTriState.True;
			// 
			// itemGroupClearColorColumn
			// 
			itemGroupClearColorColumn.FlatStyle = FlatStyle.Flat;
			itemGroupClearColorColumn.HeaderText = "Clear Color";
			itemGroupClearColorColumn.MinimumWidth = 8;
			itemGroupClearColorColumn.Name = "itemGroupClearColorColumn";
			// 
			// itemGroupOverlayColumn
			// 
			itemGroupOverlayColumn.FlatStyle = FlatStyle.Flat;
			itemGroupOverlayColumn.HeaderText = "Image ";
			itemGroupOverlayColumn.MinimumWidth = 8;
			itemGroupOverlayColumn.Name = "itemGroupOverlayColumn";
			itemGroupOverlayColumn.Resizable = DataGridViewTriState.True;
			// 
			// tableLayoutPanel3
			// 
			tableLayoutPanel3.ColumnCount = 1;
			tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel3.Controls.Add(itemGroupPartsLabel, 0, 0);
			tableLayoutPanel3.Controls.Add(itemGroupPartsDataGridView, 0, 1);
			tableLayoutPanel3.Dock = DockStyle.Fill;
			tableLayoutPanel3.Location = new Point(0, 0);
			tableLayoutPanel3.Margin = new Padding(3, 4, 3, 4);
			tableLayoutPanel3.Name = "tableLayoutPanel3";
			tableLayoutPanel3.RowCount = 2;
			tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
			tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			tableLayoutPanel3.Size = new Size(883, 524);
			tableLayoutPanel3.TabIndex = 0;
			// 
			// itemGroupPartsLabel
			// 
			itemGroupPartsLabel.AutoSize = true;
			itemGroupPartsLabel.Dock = DockStyle.Fill;
			itemGroupPartsLabel.Location = new Point(3, 0);
			itemGroupPartsLabel.Name = "itemGroupPartsLabel";
			itemGroupPartsLabel.Size = new Size(877, 38);
			itemGroupPartsLabel.TabIndex = 0;
			itemGroupPartsLabel.Text = "Item Group Parts:";
			// 
			// itemGroupPartsDataGridView
			// 
			itemGroupPartsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			itemGroupPartsDataGridView.BackgroundColor = SystemColors.Control;
			itemGroupPartsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			itemGroupPartsDataGridView.Columns.AddRange(new DataGridViewColumn[] { itemGroupPartIndexColumn, itemGroupPartNameColumn, itemGroupColumn, ItemGroupPartValueColumn });
			itemGroupPartsDataGridView.Dock = DockStyle.Fill;
			itemGroupPartsDataGridView.GridColor = SystemColors.Control;
			itemGroupPartsDataGridView.Location = new Point(3, 42);
			itemGroupPartsDataGridView.Margin = new Padding(3, 4, 3, 4);
			itemGroupPartsDataGridView.Name = "itemGroupPartsDataGridView";
			itemGroupPartsDataGridView.RowHeadersWidth = 62;
			itemGroupPartsDataGridView.RowTemplate.Height = 28;
			itemGroupPartsDataGridView.Size = new Size(877, 478);
			itemGroupPartsDataGridView.TabIndex = 1;
			itemGroupPartsDataGridView.CellFormatting += FormatItemGroupPartTable;
			itemGroupPartsDataGridView.CellValidated += CellChanged;
			// 
			// itemGroupPartIndexColumn
			// 
			itemGroupPartIndexColumn.HeaderText = "ID";
			itemGroupPartIndexColumn.MinimumWidth = 8;
			itemGroupPartIndexColumn.Name = "itemGroupPartIndexColumn";
			itemGroupPartIndexColumn.ReadOnly = true;
			// 
			// itemGroupPartNameColumn
			// 
			itemGroupPartNameColumn.HeaderText = "Item Group Part Name";
			itemGroupPartNameColumn.MinimumWidth = 8;
			itemGroupPartNameColumn.Name = "itemGroupPartNameColumn";
			// 
			// itemGroupColumn
			// 
			itemGroupColumn.HeaderText = "Item Group ID";
			itemGroupColumn.MinimumWidth = 8;
			itemGroupColumn.Name = "itemGroupColumn";
			// 
			// ItemGroupPartValueColumn
			// 
			ItemGroupPartValueColumn.HeaderText = "Value";
			ItemGroupPartValueColumn.MinimumWidth = 8;
			ItemGroupPartValueColumn.Name = "ItemGroupPartValueColumn";
			// 
			// generateButton
			// 
			generateButton.Dock = DockStyle.Fill;
			generateButton.Location = new Point(3, 764);
			generateButton.Margin = new Padding(3, 4, 3, 4);
			generateButton.Name = "generateButton";
			generateButton.Size = new Size(438, 54);
			generateButton.TabIndex = 1;
			generateButton.Text = "Generate Multiworld Tracker";
			generateButton.UseVisualStyleBackColor = true;
			generateButton.Click += Generate;
			// 
			// addWorldButton
			// 
			addWorldButton.Dock = DockStyle.Fill;
			addWorldButton.Location = new Point(447, 764);
			addWorldButton.Margin = new Padding(3, 4, 3, 4);
			addWorldButton.Name = "addWorldButton";
			addWorldButton.Size = new Size(439, 54);
			addWorldButton.TabIndex = 2;
			addWorldButton.Text = "Add Existing Multiworld Tracker";
			addWorldButton.UseVisualStyleBackColor = true;
			addWorldButton.Click += AddMultiworldToTracker;
			// 
			// imageButtonColumn1
			// 
			imageButtonColumn1.HeaderText = "Gradient";
			imageButtonColumn1.MinimumWidth = 8;
			imageButtonColumn1.Name = "imageButtonColumn1";
			imageButtonColumn1.Resizable = DataGridViewTriState.True;
			imageButtonColumn1.Width = 103;
			// 
			// dataGridViewButtonColumn1
			// 
			dataGridViewButtonColumn1.FlatStyle = FlatStyle.Flat;
			dataGridViewButtonColumn1.HeaderText = "Start Color";
			dataGridViewButtonColumn1.MinimumWidth = 8;
			dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
			dataGridViewButtonColumn1.Width = 121;
			// 
			// imageButtonColumn2
			// 
			imageButtonColumn2.HeaderText = "Image ";
			imageButtonColumn2.MinimumWidth = 8;
			imageButtonColumn2.Name = "imageButtonColumn2";
			imageButtonColumn2.Resizable = DataGridViewTriState.True;
			imageButtonColumn2.Width = 103;
			// 
			// dataGridViewButtonColumn2
			// 
			dataGridViewButtonColumn2.FlatStyle = FlatStyle.Flat;
			dataGridViewButtonColumn2.HeaderText = "End Color";
			dataGridViewButtonColumn2.MinimumWidth = 8;
			dataGridViewButtonColumn2.Name = "dataGridViewButtonColumn2";
			dataGridViewButtonColumn2.Width = 120;
			// 
			// dataGridViewButtonColumn3
			// 
			dataGridViewButtonColumn3.FlatStyle = FlatStyle.Flat;
			dataGridViewButtonColumn3.HeaderText = "Clear Color";
			dataGridViewButtonColumn3.MinimumWidth = 8;
			dataGridViewButtonColumn3.Name = "dataGridViewButtonColumn3";
			dataGridViewButtonColumn3.Width = 121;
			// 
			// MWGEN
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(889, 822);
			Controls.Add(outerTableLayout);
			Margin = new Padding(3, 4, 3, 4);
			Name = "MWGEN";
			ShowIcon = false;
			Text = "Multiworld Tracker Generator";
			Load += MWGEN_Load;
			outerTableLayout.ResumeLayout(false);
			outerSplitContainer.Panel1.ResumeLayout(false);
			outerSplitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)outerSplitContainer).EndInit();
			outerSplitContainer.ResumeLayout(false);
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)gamesDataGridView).EndInit();
			innerSplitContainer.Panel1.ResumeLayout(false);
			innerSplitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)innerSplitContainer).EndInit();
			innerSplitContainer.ResumeLayout(false);
			tableLayoutPanel2.ResumeLayout(false);
			tableLayoutPanel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)itemGroupsDataGridView).EndInit();
			tableLayoutPanel3.ResumeLayout(false);
			tableLayoutPanel3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)itemGroupPartsDataGridView).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel outerTableLayout;
		private System.Windows.Forms.SplitContainer outerSplitContainer;
		private System.Windows.Forms.SplitContainer innerSplitContainer;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label gamesLabel;
		private System.Windows.Forms.DataGridView gamesDataGridView;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.Label itemGroupsLabel;
		private System.Windows.Forms.DataGridView itemGroupsDataGridView;
		private System.Windows.Forms.Label itemGroupPartsLabel;
		private System.Windows.Forms.DataGridView itemGroupPartsDataGridView;
		private System.Windows.Forms.Button generateButton;
		private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
		private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn2;
		private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn3;
		private System.Windows.Forms.DataGridViewTextBoxColumn gameIndexColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn gameNameColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn playerNameColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn worldCountColumn;
		private System.Windows.Forms.Button addWorldButton;
		private System.Windows.Forms.DataGridViewTextBoxColumn itemGroupIndexColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn itemGroupNameColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn gameColumn;
		private System.Windows.Forms.DataGridViewCheckBoxColumn itemGroupLocationColumn;
		private ImageButtonColumn itemGroupGradientColumn;
		private System.Windows.Forms.DataGridViewButtonColumn itemGroupClearColorColumn;
		private ImageButtonColumn itemGroupOverlayColumn;
		private ImageButtonColumn imageButtonColumn1;
		private ImageButtonColumn imageButtonColumn2;
		private DataGridViewTextBoxColumn itemGroupPartIndexColumn;
		private DataGridViewTextBoxColumn itemGroupPartNameColumn;
		private DataGridViewTextBoxColumn itemGroupColumn;
		private DataGridViewTextBoxColumn ItemGroupPartValueColumn;
	}
}