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
		public Image image = null;
		private static readonly int padding = 2;

		protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates elementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
		{
			base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);

			if (image == null)
				return;

			graphics.DrawImage(image, new Rectangle(
				cellBounds.Left + padding, 
				cellBounds.Top + padding, 
				cellBounds.Width - (padding * 2), 
				cellBounds.Height - (padding * 2)));
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

		public override DataGridViewCell CellTemplate 
		{ 
			get => base.CellTemplate;
			set
			{
				if (value != null && !(value is ImageButton))
				{
					throw new InvalidCastException("Cannot cast " + value.GetType().Name + " as an ImageButton.");
				}

				base.CellTemplate = value;
			}
		}
	}
}
