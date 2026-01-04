using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PT_Piranha
{
	public partial class GradientDialog : Form
	{
		private Gradient gradient;
		public Gradient Gradient
		{
			get
			{
				return gradient;
			}
			set
			{
				if (value == null)
					throw new ArgumentNullException("Gradient in Gradient dialog cannot be null");

				gradient = value;
				UpdateBitmap();
				UpdateDataGridView();
			}
		}

		public Bitmap bitmap = null;

		public GradientDialog()
		{
			InitializeComponent();
		}

		private void UpdateBitmap()
		{
			if (bitmap == null)
			{
				bitmap = new Bitmap(gradientPictureBox.Width, gradientPictureBox.Height);
				gradientPictureBox.Image = bitmap;
			}

			for (int x = 0; x < bitmap.Width; ++x)
			{
				Color color = gradient.GetColor(x/(float)bitmap.Width);
				for (int y = 0; y < bitmap.Height; ++y)
				{
					bitmap.SetPixel(x, y, color);
				}
			}

			gradientPictureBox.Refresh();
		}

		private void UpdateDataGridView()
		{
			gradientDataGridView.Rows.Clear();

			foreach ((float weight, Color color) color in gradient.colors)
			{
				int row = gradientDataGridView.Rows.Add();
				gradientDataGridView.Rows[row].Cells[0].Value = color.weight.ToString();
				gradientDataGridView.Rows[row].Cells[1].Tag = color.color;
			}

			UpdateGradient();
			gradientDataGridView.Refresh();
		}

		private void PaintCell(object sender, DataGridViewCellPaintingEventArgs e)
		{
			if (e.RowIndex < 0 || e.ColumnIndex < 0)
				return;

			DataGridViewCell cell = gradientDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
			if (cell.OwningColumn != colorColumn)
				return;

			if (!(cell.Tag is Color))
				return;

			e.CellStyle.BackColor = (Color)cell.Tag;
		}

		private void ClickCell(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0 || e.ColumnIndex < 0)
				return;

			DataGridViewCell cell = gradientDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
			if (cell.OwningColumn != colorColumn)
				return;

			ColorDialog colorDialog = new ColorDialog();
			if (cell.Tag is Color)
				colorDialog.Color = (Color)cell.Tag;
			else
				colorDialog.Color = Color.White;

			if (colorDialog.ShowDialog() != DialogResult.OK)
				return;

			cell.Tag = colorDialog.Color;

			gradientDataGridView.Refresh();
			UpdateGradient();
		}

		private void UpdateGradient()
		{
			List<(float weight, Color color)> colors = new List<(float weight, Color color)>();

			foreach (DataGridViewRow row in gradientDataGridView.Rows)
			{
				float weight;
				if (!float.TryParse(row.Cells[0].Value as string, out weight) ||
					weight < 0 ||
					weight > 1)
					continue;
				if (!(row.Cells[1].Tag is Color))
					continue;
				Color color = (Color)row.Cells[1].Tag;

				colors.Add((weight, color));
			}

			if (colors.Count < 1) 
				return;

			gradient = new Gradient(colors);
			UpdateBitmap();
		}

		private void ChangeCellValue(object sender, DataGridViewCellEventArgs e)
		{
			UpdateGradient();
		}

		private void RemoveRow(object sender, DataGridViewRowsRemovedEventArgs e)
		{
			UpdateGradient();
		}
	}
}
