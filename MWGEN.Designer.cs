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
			this.outerTableLayout = new System.Windows.Forms.TableLayoutPanel();
			this.outerSplitContainer = new System.Windows.Forms.SplitContainer();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.gamesLabel = new System.Windows.Forms.Label();
			this.gamesDataGridView = new System.Windows.Forms.DataGridView();
			this.gameIndexColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.gameNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.playerNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.worldCountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.innerSplitContainer = new System.Windows.Forms.SplitContainer();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.itemGroupsLabel = new System.Windows.Forms.Label();
			this.itemGroupsDataGridView = new System.Windows.Forms.DataGridView();
			this.itemGroupIndexColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.itemGroupNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.gameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.itemGroupLocationColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.itemGroupStartColorColumn = new System.Windows.Forms.DataGridViewButtonColumn();
			this.itemGroupEndColorColumn = new System.Windows.Forms.DataGridViewButtonColumn();
			this.itemGroupClearColorColumn = new System.Windows.Forms.DataGridViewButtonColumn();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.itemGroupPartsLabel = new System.Windows.Forms.Label();
			this.itemGroupPartsDataGridView = new System.Windows.Forms.DataGridView();
			this.itemGroupPartIndexColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.itemGroupPartNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.itemGroupColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.generateButton = new System.Windows.Forms.Button();
			this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
			this.dataGridViewButtonColumn2 = new System.Windows.Forms.DataGridViewButtonColumn();
			this.dataGridViewButtonColumn3 = new System.Windows.Forms.DataGridViewButtonColumn();
			this.outerTableLayout.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.outerSplitContainer)).BeginInit();
			this.outerSplitContainer.Panel1.SuspendLayout();
			this.outerSplitContainer.Panel2.SuspendLayout();
			this.outerSplitContainer.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gamesDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.innerSplitContainer)).BeginInit();
			this.innerSplitContainer.Panel1.SuspendLayout();
			this.innerSplitContainer.Panel2.SuspendLayout();
			this.innerSplitContainer.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.itemGroupsDataGridView)).BeginInit();
			this.tableLayoutPanel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.itemGroupPartsDataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// outerTableLayout
			// 
			this.outerTableLayout.ColumnCount = 1;
			this.outerTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.outerTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.outerTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.outerTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.outerTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.outerTableLayout.Controls.Add(this.outerSplitContainer, 0, 0);
			this.outerTableLayout.Controls.Add(this.generateButton, 0, 1);
			this.outerTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.outerTableLayout.Location = new System.Drawing.Point(0, 0);
			this.outerTableLayout.Name = "outerTableLayout";
			this.outerTableLayout.RowCount = 2;
			this.outerTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.outerTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			this.outerTableLayout.Size = new System.Drawing.Size(800, 658);
			this.outerTableLayout.TabIndex = 0;
			// 
			// outerSplitContainer
			// 
			this.outerSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.outerSplitContainer.Location = new System.Drawing.Point(3, 3);
			this.outerSplitContainer.Name = "outerSplitContainer";
			this.outerSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// outerSplitContainer.Panel1
			// 
			this.outerSplitContainer.Panel1.Controls.Add(this.tableLayoutPanel1);
			// 
			// outerSplitContainer.Panel2
			// 
			this.outerSplitContainer.Panel2.Controls.Add(this.innerSplitContainer);
			this.outerSplitContainer.Size = new System.Drawing.Size(794, 602);
			this.outerSplitContainer.SplitterDistance = 129;
			this.outerSplitContainer.TabIndex = 0;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.gamesLabel, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.gamesDataGridView, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(794, 129);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// gamesLabel
			// 
			this.gamesLabel.AutoSize = true;
			this.gamesLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gamesLabel.Location = new System.Drawing.Point(3, 0);
			this.gamesLabel.Name = "gamesLabel";
			this.gamesLabel.Size = new System.Drawing.Size(788, 30);
			this.gamesLabel.TabIndex = 0;
			this.gamesLabel.Text = "Games:";
			// 
			// gamesDataGridView
			// 
			this.gamesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gamesDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
			this.gamesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gamesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gameIndexColumn,
            this.gameNameColumn,
            this.playerNameColumn,
            this.worldCountColumn});
			this.gamesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gamesDataGridView.GridColor = System.Drawing.SystemColors.Control;
			this.gamesDataGridView.Location = new System.Drawing.Point(3, 33);
			this.gamesDataGridView.Name = "gamesDataGridView";
			this.gamesDataGridView.RowHeadersWidth = 62;
			this.gamesDataGridView.RowTemplate.Height = 28;
			this.gamesDataGridView.Size = new System.Drawing.Size(788, 93);
			this.gamesDataGridView.TabIndex = 1;
			this.gamesDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.FormatIndexColumn);
			// 
			// gameIndexColumn
			// 
			this.gameIndexColumn.HeaderText = "ID";
			this.gameIndexColumn.MinimumWidth = 8;
			this.gameIndexColumn.Name = "gameIndexColumn";
			this.gameIndexColumn.ReadOnly = true;
			// 
			// gameNameColumn
			// 
			this.gameNameColumn.HeaderText = "Game Name";
			this.gameNameColumn.MinimumWidth = 8;
			this.gameNameColumn.Name = "gameNameColumn";
			// 
			// playerNameColumn
			// 
			this.playerNameColumn.HeaderText = "Player Name";
			this.playerNameColumn.MinimumWidth = 8;
			this.playerNameColumn.Name = "playerNameColumn";
			// 
			// worldCountColumn
			// 
			this.worldCountColumn.HeaderText = "Number of Worlds";
			this.worldCountColumn.MinimumWidth = 8;
			this.worldCountColumn.Name = "worldCountColumn";
			// 
			// innerSplitContainer
			// 
			this.innerSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.innerSplitContainer.Location = new System.Drawing.Point(0, 0);
			this.innerSplitContainer.Name = "innerSplitContainer";
			this.innerSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// innerSplitContainer.Panel1
			// 
			this.innerSplitContainer.Panel1.Controls.Add(this.tableLayoutPanel2);
			// 
			// innerSplitContainer.Panel2
			// 
			this.innerSplitContainer.Panel2.Controls.Add(this.tableLayoutPanel3);
			this.innerSplitContainer.Size = new System.Drawing.Size(794, 469);
			this.innerSplitContainer.SplitterDistance = 90;
			this.innerSplitContainer.TabIndex = 0;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 1;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Controls.Add(this.itemGroupsLabel, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.itemGroupsDataGridView, 0, 1);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 2;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(794, 90);
			this.tableLayoutPanel2.TabIndex = 0;
			// 
			// itemGroupsLabel
			// 
			this.itemGroupsLabel.AutoSize = true;
			this.itemGroupsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.itemGroupsLabel.Location = new System.Drawing.Point(3, 0);
			this.itemGroupsLabel.Name = "itemGroupsLabel";
			this.itemGroupsLabel.Size = new System.Drawing.Size(788, 30);
			this.itemGroupsLabel.TabIndex = 0;
			this.itemGroupsLabel.Text = "Item Groups:";
			// 
			// itemGroupsDataGridView
			// 
			this.itemGroupsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.itemGroupsDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
			this.itemGroupsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.itemGroupsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemGroupIndexColumn,
            this.itemGroupNameColumn,
            this.gameColumn,
            this.itemGroupLocationColumn,
            this.itemGroupStartColorColumn,
            this.itemGroupEndColorColumn,
            this.itemGroupClearColorColumn});
			this.itemGroupsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.itemGroupsDataGridView.GridColor = System.Drawing.SystemColors.Control;
			this.itemGroupsDataGridView.Location = new System.Drawing.Point(3, 33);
			this.itemGroupsDataGridView.Name = "itemGroupsDataGridView";
			this.itemGroupsDataGridView.RowHeadersWidth = 62;
			this.itemGroupsDataGridView.RowTemplate.Height = 28;
			this.itemGroupsDataGridView.Size = new System.Drawing.Size(788, 54);
			this.itemGroupsDataGridView.TabIndex = 1;
			this.itemGroupsDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ClickColorButtonCell);
			this.itemGroupsDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.FormatItemGroupTable);
			this.itemGroupsDataGridView.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.PaintItemGroupCell);
			// 
			// itemGroupIndexColumn
			// 
			this.itemGroupIndexColumn.HeaderText = "ID";
			this.itemGroupIndexColumn.MinimumWidth = 8;
			this.itemGroupIndexColumn.Name = "itemGroupIndexColumn";
			this.itemGroupIndexColumn.ReadOnly = true;
			// 
			// itemGroupNameColumn
			// 
			this.itemGroupNameColumn.HeaderText = "Item Group Name";
			this.itemGroupNameColumn.MinimumWidth = 8;
			this.itemGroupNameColumn.Name = "itemGroupNameColumn";
			// 
			// gameColumn
			// 
			this.gameColumn.HeaderText = "Game ID";
			this.gameColumn.MinimumWidth = 8;
			this.gameColumn.Name = "gameColumn";
			// 
			// itemGroupLocationColumn
			// 
			this.itemGroupLocationColumn.HeaderText = "Is Location";
			this.itemGroupLocationColumn.MinimumWidth = 8;
			this.itemGroupLocationColumn.Name = "itemGroupLocationColumn";
			// 
			// itemGroupStartColorColumn
			// 
			this.itemGroupStartColorColumn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.itemGroupStartColorColumn.HeaderText = "Start Color";
			this.itemGroupStartColorColumn.MinimumWidth = 8;
			this.itemGroupStartColorColumn.Name = "itemGroupStartColorColumn";
			// 
			// itemGroupEndColorColumn
			// 
			this.itemGroupEndColorColumn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.itemGroupEndColorColumn.HeaderText = "End Color";
			this.itemGroupEndColorColumn.MinimumWidth = 8;
			this.itemGroupEndColorColumn.Name = "itemGroupEndColorColumn";
			// 
			// itemGroupClearColorColumn
			// 
			this.itemGroupClearColorColumn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.itemGroupClearColorColumn.HeaderText = "Clear Color";
			this.itemGroupClearColorColumn.MinimumWidth = 8;
			this.itemGroupClearColorColumn.Name = "itemGroupClearColorColumn";
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.ColumnCount = 1;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.Controls.Add(this.itemGroupPartsLabel, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.itemGroupPartsDataGridView, 0, 1);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 2;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(794, 375);
			this.tableLayoutPanel3.TabIndex = 0;
			// 
			// itemGroupPartsLabel
			// 
			this.itemGroupPartsLabel.AutoSize = true;
			this.itemGroupPartsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.itemGroupPartsLabel.Location = new System.Drawing.Point(3, 0);
			this.itemGroupPartsLabel.Name = "itemGroupPartsLabel";
			this.itemGroupPartsLabel.Size = new System.Drawing.Size(788, 30);
			this.itemGroupPartsLabel.TabIndex = 0;
			this.itemGroupPartsLabel.Text = "Item Group Parts:";
			// 
			// itemGroupPartsDataGridView
			// 
			this.itemGroupPartsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.itemGroupPartsDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
			this.itemGroupPartsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.itemGroupPartsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemGroupPartIndexColumn,
            this.itemGroupPartNameColumn,
            this.itemGroupColumn});
			this.itemGroupPartsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.itemGroupPartsDataGridView.GridColor = System.Drawing.SystemColors.Control;
			this.itemGroupPartsDataGridView.Location = new System.Drawing.Point(3, 33);
			this.itemGroupPartsDataGridView.Name = "itemGroupPartsDataGridView";
			this.itemGroupPartsDataGridView.RowHeadersWidth = 62;
			this.itemGroupPartsDataGridView.RowTemplate.Height = 28;
			this.itemGroupPartsDataGridView.Size = new System.Drawing.Size(788, 339);
			this.itemGroupPartsDataGridView.TabIndex = 1;
			this.itemGroupPartsDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.FormatItemGroupPartTable);
			// 
			// itemGroupPartIndexColumn
			// 
			this.itemGroupPartIndexColumn.HeaderText = "ID";
			this.itemGroupPartIndexColumn.MinimumWidth = 8;
			this.itemGroupPartIndexColumn.Name = "itemGroupPartIndexColumn";
			this.itemGroupPartIndexColumn.ReadOnly = true;
			// 
			// itemGroupPartNameColumn
			// 
			this.itemGroupPartNameColumn.HeaderText = "Item Group Part Name";
			this.itemGroupPartNameColumn.MinimumWidth = 8;
			this.itemGroupPartNameColumn.Name = "itemGroupPartNameColumn";
			// 
			// itemGroupColumn
			// 
			this.itemGroupColumn.HeaderText = "Item Group ID";
			this.itemGroupColumn.MinimumWidth = 8;
			this.itemGroupColumn.Name = "itemGroupColumn";
			// 
			// generateButton
			// 
			this.generateButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.generateButton.Location = new System.Drawing.Point(3, 611);
			this.generateButton.Name = "generateButton";
			this.generateButton.Size = new System.Drawing.Size(794, 44);
			this.generateButton.TabIndex = 1;
			this.generateButton.Text = "GENERATE";
			this.generateButton.UseVisualStyleBackColor = true;
			this.generateButton.Click += new System.EventHandler(this.Generate);
			// 
			// dataGridViewButtonColumn1
			// 
			this.dataGridViewButtonColumn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.dataGridViewButtonColumn1.HeaderText = "Start Color";
			this.dataGridViewButtonColumn1.MinimumWidth = 8;
			this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
			this.dataGridViewButtonColumn1.Width = 121;
			// 
			// dataGridViewButtonColumn2
			// 
			this.dataGridViewButtonColumn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.dataGridViewButtonColumn2.HeaderText = "End Color";
			this.dataGridViewButtonColumn2.MinimumWidth = 8;
			this.dataGridViewButtonColumn2.Name = "dataGridViewButtonColumn2";
			this.dataGridViewButtonColumn2.Width = 120;
			// 
			// dataGridViewButtonColumn3
			// 
			this.dataGridViewButtonColumn3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.dataGridViewButtonColumn3.HeaderText = "Clear Color";
			this.dataGridViewButtonColumn3.MinimumWidth = 8;
			this.dataGridViewButtonColumn3.Name = "dataGridViewButtonColumn3";
			this.dataGridViewButtonColumn3.Width = 121;
			// 
			// MWGEN
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 658);
			this.Controls.Add(this.outerTableLayout);
			this.Name = "MWGEN";
			this.ShowIcon = false;
			this.Text = "Multiworld Tracker Generator";
			this.outerTableLayout.ResumeLayout(false);
			this.outerSplitContainer.Panel1.ResumeLayout(false);
			this.outerSplitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.outerSplitContainer)).EndInit();
			this.outerSplitContainer.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.gamesDataGridView)).EndInit();
			this.innerSplitContainer.Panel1.ResumeLayout(false);
			this.innerSplitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.innerSplitContainer)).EndInit();
			this.innerSplitContainer.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.itemGroupsDataGridView)).EndInit();
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.itemGroupPartsDataGridView)).EndInit();
			this.ResumeLayout(false);

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
		private System.Windows.Forms.DataGridViewTextBoxColumn itemGroupIndexColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn itemGroupNameColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn gameColumn;
		private System.Windows.Forms.DataGridViewCheckBoxColumn itemGroupLocationColumn;
		private System.Windows.Forms.DataGridViewButtonColumn itemGroupStartColorColumn;
		private System.Windows.Forms.DataGridViewButtonColumn itemGroupEndColorColumn;
		private System.Windows.Forms.DataGridViewButtonColumn itemGroupClearColorColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn itemGroupPartIndexColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn itemGroupPartNameColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn itemGroupColumn;
	}
}