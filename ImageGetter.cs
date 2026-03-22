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

		/// <summary>
		/// Let the user select an image from their file explorer.<br/>
		/// Handles most file types using Image Sharp.
		/// </summary>
		/// <param name="image">The image the user selected as a PNG</param>
		/// <param name="filepath">The filepath to the image selected</param>
		/// <returns>If an image could be gotten</returns>
		public static bool TryGetImage(out IMG_DRAWING.Image? image, out string filepath)
		{
			image = null;
			filepath = string.Empty;

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

				filepath = openFileDialog.FileName;

				{
					using IMG_SHARP.Image loadedImage = IMG_SHARP.Image.Load(filepath);
					using MemoryStream ms = new();
					loadedImage.Save(ms, new PngEncoder());
					image = Image.FromStream(ms);
				}

				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Could not load the file: " +  filepath + "\r\n" + ex.Message);
				return false;
			}
		}

		/// <summary>
		/// Gets an image from a filepath.<br/>
		/// Handles most image types using Image Sharp.
		/// </summary>
		/// <param name="filepath">The filepath to the image</param>
		/// <param name="image">The image as a PNG</param>
		/// <returns>If an image could be gotten</returns>
		public static bool TryGetImage(string filepath, out System.Drawing.Image? image)
		{
			try
			{
				using IMG_SHARP.Image loadedImage = IMG_SHARP.Image.Load(filepath);
				using MemoryStream ms = new();
				loadedImage.Save(ms, new PngEncoder());
				image = Image.FromStream(ms);

				return true;
			}
			catch
			{
				image = null;

				return false;
			}
		}
	}
}
