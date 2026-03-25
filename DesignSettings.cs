using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PT_Piranha
{
	public partial class DesignSettings : Form
	{
		public static readonly string
			gradientTrueDefault = "0|255|0|0\r\n1|0|255|0",
			clearColorTrueDefault = "255|255|0",
			backgroundImageTrueDefault = string.Empty,
			backgroundImageStyleTrueDefault = BackgroundImageStyle.FIT.ToString(),
			showBackgroundImageTrueDefault = ShowBackgroundImage.EMPTY_CELLS_ONLY.ToString(),
			itemGroupStyleTrueDefault = ItemGroupStyle.FLUID.ToString(),
			progressBarStyleTrueDefault = ProgressBarStyle.LOCATIONS.ToString(),
			overlayStyleTrueDefault = OverlayStyle.COMBO.ToString(),
			overlayInterpolationTrueDefault = OverlayInterpolation.DEFAULT.ToString();

		private static Gradient defaultGradient = null;
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public static Gradient DefaultGradient
		{
			get
			{
				if (defaultGradient != null)
				{
					return defaultGradient;
				}
				else
				{
					if (!Gradient.TryParse(RegistryHelper.GetValue(RegistryName.GRADIENT_DEFAULT, DesignSettings.gradientTrueDefault), out Gradient defaultGradient))
					{
						if (!Gradient.TryParse(DesignSettings.gradientTrueDefault, out defaultGradient))
							throw new Exception("Gradient's default and true default are invalid.");
						RegistryHelper.SetValue(RegistryName.GRADIENT_DEFAULT, DesignSettings.gradientTrueDefault);
					}
					DesignSettings.defaultGradient = defaultGradient;
					return defaultGradient;
				}
			}
			private set { }
		}

		public DesignSettings()
		{
			InitializeComponent();
		}

		private void DesignSettings_Load(object sender, EventArgs e)
		{
			try
			{
				{
					if (Gradient.TryParse(
						RegistryHelper.GetValue(
							RegistryName.GRADIENT_DEFAULT,
							gradientTrueDefault),
						out Gradient defaultGradient))
					{
						defaultGradientButton.Tag = defaultGradient;
					}
					else if (Gradient.TryParse(
						gradientTrueDefault,
						out defaultGradient))
					{
						defaultGradientButton.Tag = defaultGradient;
						RegistryHelper.SetValue(RegistryName.GRADIENT_DEFAULT, gradientTrueDefault);
					}
					else
					{
						throw new Exception("Gradient default and true default are invalid.");
					}
				}

				{
					string clearColorDefaultString =
						RegistryHelper.GetValue(
							RegistryName.CLEAR_COLOR_DEFAULT,
							clearColorTrueDefault);

					if (string.IsNullOrWhiteSpace(
						clearColorDefaultString))
					{
						RegistryHelper.SetValue(RegistryName.CLEAR_COLOR_DEFAULT, clearColorTrueDefault);
						clearColorDefaultString = clearColorTrueDefault;
					}

					if (!Gradient.TryParseColor(clearColorDefaultString, out Color clearColorDefault))
					{
						clearColorDefaultString = clearColorTrueDefault;
						RegistryHelper.SetValue(RegistryName.CLEAR_COLOR_DEFAULT, clearColorTrueDefault);
						if (!Gradient.TryParseColor(clearColorDefaultString, out clearColorDefault))
							throw new Exception("Clear color default and true default are invalid");
					}
					defaultClearColorButton.Tag = clearColorDefault;
					defaultClearColorButton.BackColor = clearColorDefault;
				}

				{
					backgroundImageButton.Tag =
						RegistryHelper.GetValue(RegistryName.BACKGROUND_IMAGE, backgroundImageTrueDefault);

					string? filepath = backgroundImageButton.Tag as string;
					if (filepath != null)
					{
						ImageGetter.TryGetImage(filepath, out Image? backgroundImage);
						if (backgroundImage != null)
							backgroundImageButton.BackgroundImage = backgroundImage;
					}
				}

				{
					if (!Enum.TryParse(
						RegistryHelper.GetValue(RegistryName.BACKGROUND_IMAGE_STYLE, backgroundImageStyleTrueDefault),
						out BackgroundImageStyle backgroundImageStyle))
					{
						if (!Enum.TryParse(backgroundImageStyleTrueDefault,
							out backgroundImageStyle))
							throw new Exception("Background image style and its default are invalid.");
						RegistryHelper.SetValue(RegistryName.BACKGROUND_IMAGE_STYLE, backgroundImageStyleTrueDefault);
					}

					backgroundImageStyleComboBox.SelectedIndex = (int)backgroundImageStyle;
				}

				{
					if (!Enum.TryParse(
						RegistryHelper.GetValue(RegistryName.SHOW_BACKGROUND_IMAGE, showBackgroundImageTrueDefault),
						out ShowBackgroundImage showBackgroundImage))
					{
						if (!Enum.TryParse(showBackgroundImageTrueDefault,
							out showBackgroundImage))
							throw new Exception("Show background image and its default are invalid.");
						RegistryHelper.SetValue(RegistryName.SHOW_BACKGROUND_IMAGE, showBackgroundImageTrueDefault);
					}

					showBackgroundImageComboBox.SelectedIndex = (int)showBackgroundImage;
				}

				{
					if (!Enum.TryParse(
						RegistryHelper.GetValue(RegistryName.ITEM_GROUP_STYLE, itemGroupStyleTrueDefault),
						out ItemGroupStyle itemGroupStyle))
					{
						if (!Enum.TryParse(itemGroupStyleTrueDefault,
							out itemGroupStyle))
							throw new Exception("Item group style and its default are invalid.");
						RegistryHelper.SetValue(RegistryName.ITEM_GROUP_STYLE, itemGroupStyleTrueDefault);
					}

					itemGroupStyleComboBox.SelectedIndex = (int)itemGroupStyle;
				}

				{
					if (!Enum.TryParse(
						RegistryHelper.GetValue(RegistryName.PROGRESS_BAR_STYLE, progressBarStyleTrueDefault),
						out ProgressBarStyle progressBarStyle))
					{
						if (!Enum.TryParse(progressBarStyleTrueDefault,
							out progressBarStyle))
							throw new Exception("Progress bar style and its default are invalid.");
						RegistryHelper.SetValue(RegistryName.PROGRESS_BAR_STYLE, progressBarStyleTrueDefault);
					}

					progressBarStyleComboBox.SelectedIndex = (int)progressBarStyle;
				}

				{
					if (!Enum.TryParse(
						RegistryHelper.GetValue(RegistryName.OVERLAY_STYLE, overlayStyleTrueDefault),
						out OverlayStyle overlayStyle))
					{
						if (!Enum.TryParse(overlayStyleTrueDefault,
							out overlayStyle))
							throw new Exception("Overlay style and its default are invalid.");
						RegistryHelper.SetValue(RegistryName.OVERLAY_STYLE, overlayStyleTrueDefault);
					}

					overlayStyleComboBox.SelectedIndex = (int)overlayStyle;
				}

				{
					OverlayInterpolation overlayInterpolation;

					//Overlay Interpolation originally saved an int to the registry.
					//If the user has an old registry value, update it.
					if (RegistryHelper.GetValueType(RegistryName.OVERLAY_INTERPOLATION) == RegistryValueKind.DWord)
					{
						overlayInterpolation = (OverlayInterpolation)RegistryHelper.GetValue(RegistryName.OVERLAY_INTERPOLATION, 0);
						RegistryHelper.SetValue(RegistryName.OVERLAY_INTERPOLATION, overlayInterpolation.ToString());
					}
					else
					{
						if (!Enum.TryParse(
							RegistryHelper.GetValue(RegistryName.OVERLAY_INTERPOLATION, overlayInterpolationTrueDefault),
							out overlayInterpolation))
						{
							if (!Enum.TryParse(overlayInterpolationTrueDefault,
								out overlayInterpolation))
								throw new Exception("Overlay interpolation and its default are invalid.");
							RegistryHelper.SetValue(RegistryName.OVERLAY_INTERPOLATION, overlayInterpolationTrueDefault);
						}
					}

					overlayInterpolationComboBox.SelectedIndex = (int)overlayInterpolation;
				}

				Refresh();
			}
			catch (Exception ex)
			{
				Worker.SetStatus("Could not open Design Settings: " + ex.Message, true);
				Close();
			}
		}

		private void defaultGradientButton_Paint(object sender, PaintEventArgs e)
		{
			Gradient? gradient = defaultGradientButton.Tag as Gradient;

			if (gradient == null)
				return;

			for (int x = 0; x < e.ClipRectangle.Width; ++x)
			{
				using Pen pen = new Pen(gradient.GetColor(x / (float)e.ClipRectangle.Width));
				Rectangle rect = new Rectangle(x, 0, 1, e.ClipRectangle.Height);
				e.Graphics.DrawRectangle(pen, rect);
			}
		}

		private void defaultGradientButton_Click(object sender, EventArgs e)
		{
			GradientDialog gradientDialog = new GradientDialog();
			Gradient? defaultGradient = defaultGradientButton.Tag as Gradient;
			if (defaultGradient != null)
				gradientDialog.Gradient = defaultGradient;
			if (gradientDialog.ShowDialog() == DialogResult.OK)
			{
				//Don't let the user create an infinite loop.
				if (gradientDialog.Gradient.gradientStyle == GradientStyle.DEFAULT_GRADIENT)
					gradientDialog.Gradient.gradientStyle = GradientStyle.STANDARD;
				defaultGradientButton.Tag = gradientDialog.Gradient;
				defaultGradientButton.Refresh();
			}
		}

		private void defaultClearColorButton_Click(object sender, EventArgs e)
		{
			ColorDialog colorDialog = new ColorDialog();
			colorDialog.Color = (Color)defaultClearColorButton.Tag;
			if (colorDialog.ShowDialog() != DialogResult.OK)
				return;

			defaultClearColorButton.Tag = colorDialog.Color;
			defaultClearColorButton.BackColor = colorDialog.Color;
			defaultClearColorButton.Refresh();
		}

		private void backgroundImageButton_Click(object sender, EventArgs e)
		{
			if (!ImageGetter.TryGetImage(out Image? image, out string filepath) ||
				image == null)
				return;

			backgroundImageButton.Tag = filepath;
			backgroundImageButton.BackgroundImage = image;
			backgroundImageButton.Refresh();
		}

		private void backgroundImageClearButton_Click(object sender, EventArgs e)
		{
			backgroundImageButton.Tag = string.Empty;
			backgroundImageButton.BackgroundImage = null;
			backgroundImageButton.Refresh();
		}

		private void saveButton_Click(object sender, EventArgs e)
		{
			DesignSettings.defaultGradient = null;
			Gradient? defaultGradient = defaultGradientButton.Tag as Gradient;
			string defaultGradientString;
			if (defaultGradient == null)
				defaultGradientString = gradientTrueDefault;
			else
				defaultGradientString = defaultGradient.ToString();
			RegistryHelper.SetValue(RegistryName.GRADIENT_DEFAULT, defaultGradientString);

			string defaultClearColorString;
			if (defaultClearColorButton.Tag is Color)
				defaultClearColorString = Gradient.GetStringFromColor((Color)defaultClearColorButton.Tag);
			else
				defaultClearColorString = clearColorTrueDefault;
			RegistryHelper.SetValue(RegistryName.CLEAR_COLOR_DEFAULT, defaultClearColorString);

			string backgroundImage = string.Empty;
			if (backgroundImageButton.Tag is string)
				backgroundImage = (string)backgroundImageButton.Tag;
			RegistryHelper.SetValue(RegistryName.BACKGROUND_IMAGE, backgroundImage);

			RegistryHelper.SetValue(RegistryName.BACKGROUND_IMAGE_STYLE,
				((BackgroundImageStyle)backgroundImageStyleComboBox.SelectedIndex).ToString());

			RegistryHelper.SetValue(RegistryName.SHOW_BACKGROUND_IMAGE,
				((ShowBackgroundImage)showBackgroundImageComboBox.SelectedIndex).ToString());

			RegistryHelper.SetValue(RegistryName.ITEM_GROUP_STYLE,
				((ItemGroupStyle)itemGroupStyleComboBox.SelectedIndex).ToString());

			RegistryHelper.SetValue(RegistryName.PROGRESS_BAR_STYLE,
				((ProgressBarStyle)progressBarStyleComboBox.SelectedIndex).ToString());

			RegistryHelper.SetValue(RegistryName.OVERLAY_STYLE,
				((OverlayStyle)overlayStyleComboBox.SelectedIndex).ToString());

			RegistryHelper.SetValue(RegistryName.OVERLAY_INTERPOLATION,
				((OverlayInterpolation)overlayInterpolationComboBox.SelectedIndex).ToString());
		}
	}

	public enum BackgroundImageStyle
	{
		/// <summary>
		/// Tile the image to fill the background.
		/// </summary>
		TILE = 0,
		/// <summary>
		/// Stretch the image so it fills the background.
		/// </summary>
		STRETCH = 1,
		/// <summary>
		/// Center the image and crop it if it goes out of bounds.
		/// </summary>
		CLIP = 2,
		/// <summary>
		/// Stretch the image so it fills the background, but don't change its aspect ratio.
		/// </summary>
		FIT = 3
	}

	public enum ShowBackgroundImage
	{
		/// <summary>
		/// Only show the background where there are no item groups.
		/// </summary>
		EMPTY_CELLS_ONLY = 0,
		/// <summary>
		/// Show the background where the item groups' games have finished.
		/// </summary>
		COMPLETED_GAMES = 1,
		/// <summary>
		/// Show the background where all items in an item group have been colected.
		/// </summary>
		COMPLETED_ITEM_GROUPS = 2
	}

	public enum ItemGroupStyle
	{
		/// <summary>
		/// Games are kept on seperate rows.
		/// </summary>
		SEPERATE_GAMES = 0,
		/// <summary>
		/// Games flow continuously.
		/// </summary>
		FLUID = 1,
		/// <summary>
		/// All item groups are shuffled on the board.
		/// </summary>
		JUMBLE = 2,
		/// <summary>
		/// All item groups are shuffled on the board by a voronoi diagram.
		/// </summary>
		VORONOI = 3
	}

	public enum ProgressBarStyle
	{
		/// <summary>
		/// Base progress bar percentage on the number of locations checked across all worlds.
		/// </summary>
		LOCATIONS = 0,
		/// <summary>
		/// Base progress bar percentage based on the sum of all items in item groups collected 
		/// divided by the sum of all items in item groups.<br/>
		///This is affected by item group part value.
		/// </summary>
		ITEM_GROUPS = 1,
		/// <summary>
		/// Base progress bar on the number of item groups that have been completed.
		/// </summary>
		ITEM_GROUPS_COMPLETED = 2,
		/// <summary>
		/// Base progress bar on the average locations checked per game.
		/// </summary>
		GAME_PERCENTAGES = 3,
		/// <summary>
		/// Base progress bar on the number of games that have all locations checked.
		/// </summary>
		GAMES_COMPLETED = 4
	}

	public enum OverlayStyle
	{
		/// <summary>
		/// If itemgroup has an image use that, otherwise use text.
		/// </summary>
		IMAGE_OR_TEXT = 0,
		/// <summary>
		/// If itemgroup has an image use that and append percent, otherwise use text.
		/// </summary>
		COMBO = 1,
		/// <summary>
		/// Show all itemgroups as text.
		/// </summary>
		TEXT_ONLY = 2,
		/// <summary>
		/// If itemgroup has an image use that, otherwise don't show overlay.
		/// </summary>
		IMAGE_ONLY = 3,
		/// <summary>
		/// Don't show overlay.
		/// </summary>
		NONE = 4,
		/// <summary>
		/// Count / Max Count Text.<br/>
		/// Primary use is with COMBO overlay.
		/// </summary>
		COMBO_STRING = 5
	}

	public enum OverlayInterpolation
	{
		/// <summary>
		/// Do not interpolate overlays.
		/// </summary>
		NONE = 0,
		/// <summary>
		/// Use system defaults.
		/// </summary>
		DEFAULT = 1,
	}
}
