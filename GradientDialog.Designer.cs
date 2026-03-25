namespace PT_Piranha
{
	partial class GradientDialog
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
			mainTableLayoutPannel = new TableLayoutPanel();
			gradientPictureBox = new PictureBox();
			gradientDataGridView = new DataGridView();
			weightColumn = new DataGridViewTextBoxColumn();
			colorColumn = new DataGridViewButtonColumn();
			okButton = new Button();
			cancelButton = new Button();
			gradientStyleComboBox = new ComboBox();
			dataGridViewButtonColumn1 = new DataGridViewButtonColumn();
			mainTableLayoutPannel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)gradientPictureBox).BeginInit();
			((System.ComponentModel.ISupportInitialize)gradientDataGridView).BeginInit();
			SuspendLayout();
			// 
			// mainTableLayoutPannel
			// 
			mainTableLayoutPannel.ColumnCount = 2;
			mainTableLayoutPannel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			mainTableLayoutPannel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			mainTableLayoutPannel.Controls.Add(gradientPictureBox, 0, 0);
			mainTableLayoutPannel.Controls.Add(gradientDataGridView, 0, 2);
			mainTableLayoutPannel.Controls.Add(okButton, 0, 3);
			mainTableLayoutPannel.Controls.Add(cancelButton, 1, 3);
			mainTableLayoutPannel.Controls.Add(gradientStyleComboBox, 0, 1);
			mainTableLayoutPannel.Dock = DockStyle.Fill;
			mainTableLayoutPannel.Location = new Point(0, 0);
			mainTableLayoutPannel.Margin = new Padding(3, 4, 3, 4);
			mainTableLayoutPannel.Name = "mainTableLayoutPannel";
			mainTableLayoutPannel.RowCount = 4;
			mainTableLayoutPannel.RowStyles.Add(new RowStyle(SizeType.Absolute, 125F));
			mainTableLayoutPannel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
			mainTableLayoutPannel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
			mainTableLayoutPannel.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
			mainTableLayoutPannel.Size = new Size(392, 562);
			mainTableLayoutPannel.TabIndex = 0;
			// 
			// gradientPictureBox
			// 
			mainTableLayoutPannel.SetColumnSpan(gradientPictureBox, 2);
			gradientPictureBox.Dock = DockStyle.Fill;
			gradientPictureBox.Location = new Point(3, 4);
			gradientPictureBox.Margin = new Padding(3, 4, 3, 4);
			gradientPictureBox.Name = "gradientPictureBox";
			gradientPictureBox.Size = new Size(386, 117);
			gradientPictureBox.TabIndex = 0;
			gradientPictureBox.TabStop = false;
			// 
			// gradientDataGridView
			// 
			gradientDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			gradientDataGridView.BackgroundColor = SystemColors.Control;
			gradientDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			gradientDataGridView.Columns.AddRange(new DataGridViewColumn[] { weightColumn, colorColumn });
			mainTableLayoutPannel.SetColumnSpan(gradientDataGridView, 2);
			gradientDataGridView.Dock = DockStyle.Fill;
			gradientDataGridView.GridColor = SystemColors.Control;
			gradientDataGridView.Location = new Point(3, 179);
			gradientDataGridView.Margin = new Padding(3, 4, 3, 4);
			gradientDataGridView.Name = "gradientDataGridView";
			gradientDataGridView.RowHeadersWidth = 62;
			gradientDataGridView.RowTemplate.Height = 28;
			gradientDataGridView.Size = new Size(386, 319);
			gradientDataGridView.TabIndex = 1;
			gradientDataGridView.CellContentClick += ClickCell;
			gradientDataGridView.CellPainting += PaintCell;
			gradientDataGridView.CellValueChanged += ChangeCellValue;
			gradientDataGridView.RowsRemoved += RemoveRow;
			// 
			// weightColumn
			// 
			weightColumn.HeaderText = "Weight";
			weightColumn.MinimumWidth = 8;
			weightColumn.Name = "weightColumn";
			// 
			// colorColumn
			// 
			colorColumn.FlatStyle = FlatStyle.Flat;
			colorColumn.HeaderText = "Color";
			colorColumn.MinimumWidth = 8;
			colorColumn.Name = "colorColumn";
			// 
			// okButton
			// 
			okButton.DialogResult = DialogResult.OK;
			okButton.Dock = DockStyle.Fill;
			okButton.Location = new Point(3, 506);
			okButton.Margin = new Padding(3, 4, 3, 4);
			okButton.Name = "okButton";
			okButton.Size = new Size(190, 52);
			okButton.TabIndex = 2;
			okButton.Text = "OK";
			okButton.UseVisualStyleBackColor = true;
			// 
			// cancelButton
			// 
			cancelButton.DialogResult = DialogResult.Cancel;
			cancelButton.Dock = DockStyle.Fill;
			cancelButton.Location = new Point(199, 506);
			cancelButton.Margin = new Padding(3, 4, 3, 4);
			cancelButton.Name = "cancelButton";
			cancelButton.Size = new Size(190, 52);
			cancelButton.TabIndex = 3;
			cancelButton.Text = "Cancel";
			cancelButton.UseVisualStyleBackColor = true;
			// 
			// gradientStyleComboBox
			// 
			mainTableLayoutPannel.SetColumnSpan(gradientStyleComboBox, 2);
			gradientStyleComboBox.Dock = DockStyle.Fill;
			gradientStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			gradientStyleComboBox.FormattingEnabled = true;
			gradientStyleComboBox.Items.AddRange(new object[] { "Default Gradient", "Standard", "Raw", "Ceiling" });
			gradientStyleComboBox.Location = new Point(3, 128);
			gradientStyleComboBox.Name = "gradientStyleComboBox";
			gradientStyleComboBox.Size = new Size(386, 33);
			gradientStyleComboBox.TabIndex = 4;
			gradientStyleComboBox.SelectedIndexChanged += gradientStyleComboBox_SelectedIndexChanged;
			// 
			// dataGridViewButtonColumn1
			// 
			dataGridViewButtonColumn1.FlatStyle = FlatStyle.Flat;
			dataGridViewButtonColumn1.HeaderText = "Color";
			dataGridViewButtonColumn1.MinimumWidth = 8;
			dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
			dataGridViewButtonColumn1.Width = 141;
			// 
			// GradientDialog
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(392, 562);
			Controls.Add(mainTableLayoutPannel);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			Margin = new Padding(3, 4, 3, 4);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "GradientDialog";
			ShowIcon = false;
			Text = "Gradient";
			mainTableLayoutPannel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)gradientPictureBox).EndInit();
			((System.ComponentModel.ISupportInitialize)gradientDataGridView).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel mainTableLayoutPannel;
		private System.Windows.Forms.PictureBox gradientPictureBox;
		private System.Windows.Forms.DataGridView gradientDataGridView;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.DataGridViewTextBoxColumn weightColumn;
		private System.Windows.Forms.DataGridViewButtonColumn colorColumn;
		private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
		private ComboBox gradientStyleComboBox;
	}
}