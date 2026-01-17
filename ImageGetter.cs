using IMG_SHARP = SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Bmp;
using IMG_DRAWING = System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System;
using SixLabors.ImageSharp.Formats.Png;

namespace PT_Piranha
{
	public static class ImageGetter
	{

		public static bool TryGetImage(out IMG_DRAWING.Image? image, out string fileName)
		{
			image = null;
			fileName = string.Empty;

			try
			{
				OpenFileDialog openFileDialog = new()
				{
					Filter =
					"Image Files|*.png;*.jpg;*.jpeg;*.webp;*.bmp;*.gif;*.tif;*.tiff;*.pbm;*.tga;*.qoi|" +
					"PNG (*.png)|*.png|" +
					"JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
					"WebP (*.webp)|*.webp|" +
					"Bitmap (*.bmp)|*.bmp|" +
					"GIF (*.gif)|*.gif|" +
					"TIFF (*.tif;*.tiff)|*.tif;*.tiff|" +
					"PBM (*.pbm)|*.pbm|" +
					"TGA (*.tga)|*.tga|" +
					"QOI (*.qoi)|*.qoi"
				};

				if (openFileDialog.ShowDialog() != DialogResult.OK)
					return false;

				fileName = openFileDialog.FileName;

				{
					using IMG_SHARP.Image loadedImage = IMG_SHARP.Image.Load(fileName);
					using MemoryStream ms = new();
					loadedImage.Save(ms, new PngEncoder());
					image = Image.FromStream(ms);
				}

				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Could not load the file: " +  fileName + "\r\n" + ex.Message);
				return false;
			}
		}
	}
}
