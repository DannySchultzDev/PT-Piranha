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
			this.mainTableLayoutPannel = new System.Windows.Forms.TableLayoutPanel();
			this.gradientPictureBox = new System.Windows.Forms.PictureBox();
			this.gradientDataGridView = new System.Windows.Forms.DataGridView();
			this.weightColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colorColumn = new System.Windows.Forms.DataGridViewButtonColumn();
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
			this.mainTableLayoutPannel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gradientPictureBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gradientDataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// mainTableLayoutPannel
			// 
			this.mainTableLayoutPannel.ColumnCount = 2;
			this.mainTableLayoutPannel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.mainTableLayoutPannel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.mainTableLayoutPannel.Controls.Add(this.gradientPictureBox, 0, 0);
			this.mainTableLayoutPannel.Controls.Add(this.gradientDataGridView, 0, 1);
			this.mainTableLayoutPannel.Controls.Add(this.okButton, 0, 2);
			this.mainTableLayoutPannel.Controls.Add(this.cancelButton, 1, 2);
			this.mainTableLayoutPannel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainTableLayoutPannel.Location = new System.Drawing.Point(0, 0);
			this.mainTableLayoutPannel.Name = "mainTableLayoutPannel";
			this.mainTableLayoutPannel.RowCount = 3;
			this.mainTableLayoutPannel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
			this.mainTableLayoutPannel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainTableLayoutPannel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			this.mainTableLayoutPannel.Size = new System.Drawing.Size(353, 450);
			this.mainTableLayoutPannel.TabIndex = 0;
			// 
			// gradientPictureBox
			// 
			this.mainTableLayoutPannel.SetColumnSpan(this.gradientPictureBox, 2);
			this.gradientPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gradientPictureBox.Location = new System.Drawing.Point(3, 3);
			this.gradientPictureBox.Name = "gradientPictureBox";
			this.gradientPictureBox.Size = new System.Drawing.Size(347, 94);
			this.gradientPictureBox.TabIndex = 0;
			this.gradientPictureBox.TabStop = false;
			// 
			// gradientDataGridView
			// 
			this.gradientDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gradientDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
			this.gradientDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gradientDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.weightColumn,
            this.colorColumn});
			this.mainTableLayoutPannel.SetColumnSpan(this.gradientDataGridView, 2);
			this.gradientDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gradientDataGridView.GridColor = System.Drawing.SystemColors.Control;
			this.gradientDataGridView.Location = new System.Drawing.Point(3, 103);
			this.gradientDataGridView.Name = "gradientDataGridView";
			this.gradientDataGridView.RowHeadersWidth = 62;
			this.gradientDataGridView.RowTemplate.Height = 28;
			this.gradientDataGridView.Size = new System.Drawing.Size(347, 294);
			this.gradientDataGridView.TabIndex = 1;
			this.gradientDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ClickCell);
			this.gradientDataGridView.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.PaintCell);
			this.gradientDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.ChangeCellValue);
			this.gradientDataGridView.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.RemoveRow);
			// 
			// weightColumn
			// 
			this.weightColumn.HeaderText = "Weight";
			this.weightColumn.MinimumWidth = 8;
			this.weightColumn.Name = "weightColumn";
			// 
			// colorColumn
			// 
			this.colorColumn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.colorColumn.HeaderText = "Color";
			this.colorColumn.MinimumWidth = 8;
			this.colorColumn.Name = "colorColumn";
			// 
			// okButton
			// 
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.okButton.Location = new System.Drawing.Point(3, 403);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(170, 44);
			this.okButton.TabIndex = 2;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cancelButton.Location = new System.Drawing.Point(179, 403);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(171, 44);
			this.cancelButton.TabIndex = 3;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// dataGridViewButtonColumn1
			// 
			this.dataGridViewButtonColumn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.dataGridViewButtonColumn1.HeaderText = "Color";
			this.dataGridViewButtonColumn1.MinimumWidth = 8;
			this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
			this.dataGridViewButtonColumn1.Width = 141;
			// 
			// GradientDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(353, 450);
			this.Controls.Add(this.mainTableLayoutPannel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "GradientDialog";
			this.ShowIcon = false;
			this.Text = "Gradient";
			this.mainTableLayoutPannel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gradientPictureBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gradientDataGridView)).EndInit();
			this.ResumeLayout(false);

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
	}
}