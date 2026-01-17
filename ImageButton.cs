using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PT_Piranha
{
	public class ImageButton : DataGridViewButtonCell
	{
		public Image? image = null;
		public ImageButtonImageStretchMode imageStretchMode = ImageButtonImageStretchMode.STRETCH;
		private static readonly int padding = 2;

		protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates elementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
		{
			base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);

			if (image == null)
				return;

			Rectangle trueCellBounds = new(
				cellBounds.Left + padding,
				cellBounds.Top + padding,
				cellBounds.Width - (padding * 2),
				cellBounds.Height - (padding * 2));

			switch (imageStretchMode)
			{
				case ImageButtonImageStretchMode.STRETCH:

					graphics.DrawImage(image, trueCellBounds);

					break;
				case ImageButtonImageStretchMode.PAD:

					float imageRatio = image.Width / (float)image.Height;
					float cellRatio = trueCellBounds.Width / (float)trueCellBounds.Height;

					if (imageRatio == cellRatio)
						graphics.DrawImage(image, trueCellBounds);
					else if (imageRatio > cellRatio)
					{
						int imageHeight = (int)(trueCellBounds.Width / imageRatio);

						graphics.DrawImage(image, new Rectangle(
							trueCellBounds.Left,
							trueCellBounds.Top + ((trueCellBounds.Height - imageHeight) / 2),
							trueCellBounds.Width,
							imageHeight));
					}
					else
					{
						int imageWidth = (int)(trueCellBounds.Height * imageRatio);

						graphics.DrawImage(image, new Rectangle(
							trueCellBounds.Left + ((trueCellBounds.Width - imageWidth) / 2),
							trueCellBounds.Top,
							imageWidth,
							trueCellBounds.Height));
					}

					break;
			}
		}
	}

	[ToolboxItem(true)]
	[ToolboxBitmap(typeof(DataGridViewButtonColumn))]
	public class ImageButtonColumn : DataGridViewButtonColumn, ICloneable
	{
		public ImageButtonColumn()
		{
			CellTemplate = new ImageButton();
		}

		public override object Clone()
		{
			ImageButtonColumn imageButtonColumn = (ImageButtonColumn)base.Clone();
			return imageButtonColumn;
		}
	}

	public enum ImageButtonImageStretchMode
	{
		STRETCH,
		PAD
	}
}
