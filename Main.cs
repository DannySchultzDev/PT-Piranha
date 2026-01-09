using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Xml.Serialization;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Color = System.Drawing.Color;

namespace PT_Piranha
{
	public partial class Main : Form
	{
		public List<World> worlds = new List<World>();
		public static Main instance { get; private set; }

		private PictureArrangmentMode pictureArrangmentMode = PictureArrangmentMode.FLUID;
		private Color fillerColor = Color.White;
		private ItemGroup[,] pbn = new ItemGroup[1, 1];
		private OverlayMode overlayMode = OverlayMode.NORMAL;
		private List<(Rectangle area, ItemGroup itemGroup)> overlays =
			new List<(Rectangle area, ItemGroup itemGroup)>();
		private static readonly Font overlayFont = new Font(DefaultFont.FontFamily, 30);
		private static readonly int overlayHorizontalOffset = 5;

		private static float brightBGThreshold = .7f;
		private static readonly Brush lightBrush = new SolidBrush(Color.White);
		private static readonly Brush darkbrush = new SolidBrush(Color.Black);

		public static ProgressBarMode progressBarMode { get; private set; } = ProgressBarMode.LOCATIONS;

		ToolTip mainPictureBoxToolTip = new ToolTip();
		Point mainPictureBoxLastMousePoint = new Point(0, 0);

		FormWindowState currentState = FormWindowState.Normal;

		private static readonly string logFolderpath = Path.Combine(
			Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
			"PT Piranha");

		private static readonly string logFilepath = Path.Combine(
			logFolderpath, Guid.NewGuid().ToString() + ".txt");

		public Main()
		{
			if (instance == null)
			{
				InitializeComponent();
				instance = this;
			}
		}

		private void GenerateYamlsButton_Click(object sender, EventArgs e)
		{
			YAMLGEN yamlGen = new YAMLGEN();
			yamlGen.Show();
		}

		private void LoadGameButton_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "piranha files (*.piranha)|*.piranha|xml files (*.xml)|*.xml|All files (*.*)|*.*";
			if (openFileDialog.ShowDialog() != DialogResult.OK)
			{
				Worker.SetStatus("Load Multiworld Tracker canceled.");
				return;
			}

			LoadGame(openFileDialog.FileName);
		}

		private void GenerateMWButton_Click(object sender, EventArgs e)
		{
			MWGEN mwGen = new MWGEN();
			mwGen.Show();
		}

		private void EditMWButton_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "piranha files (*.piranha)|*.piranha|xml files (*.xml)|*.xml|All files (*.*)|*.*";
			if (openFileDialog.ShowDialog() != DialogResult.OK)
			{
				Worker.SetStatus("Edit Multiworld Tracker canceled.");
				return;
			}

			MWGEN mwGEN = new MWGEN();
			mwGEN.AddMultiworldToTracker(openFileDialog.FileName);
			mwGEN.Show();
		}

		public void LoadGame(string filepath)
		{
			try
			{
				worlds.Clear();

				Root rootNode;
				XmlSerializer serializer = new XmlSerializer(typeof(Root));
				using (StreamReader stream = new StreamReader(filepath))
				{
					rootNode = serializer.Deserialize(stream) as Root;
				}

				Dictionary<uint, Image> overlays = new Dictionary<uint, Image>();
				if (rootNode.Overlay != null)
				{
					foreach (OverlayType overlayNode in rootNode.Overlay)
					{
						ImageConverter converter = new ImageConverter();
						overlays.Add(overlayNode.ID, (Image)converter.ConvertFrom(overlayNode.Data));
					}
				}

				foreach (GameType gameNode in rootNode.Game)
				{
					string format = "D" + (gameNode.Count + 1).ToString().Length.ToString();

					for (int worldIndex = 0; worldIndex < gameNode.Count; ++worldIndex)
					{
						List<ItemGroup> itemGroups = new List<ItemGroup>();

						if (gameNode.ItemGroup != null)
						{
							foreach (ItemGroupType itemGroupNode in gameNode.ItemGroup)
							{
								List<string> itemGroupParts = new List<string>();

								if (itemGroupNode.ItemGroupPart != null)
								{
									foreach (ItemGroupPartType itemGroupPartNode in itemGroupNode.ItemGroupPart)
									{
										itemGroupParts.Add(itemGroupPartNode.Name);
									}
								}

								Image image = null;
								if (itemGroupNode.OverlayID != null &&
									itemGroupNode.OverlayID.Length > 0)
									image = overlays[itemGroupNode.OverlayID[0].ID];

								ItemGroup itemGroup = new ItemGroup(
									itemGroupNode.Name,
									itemGroupParts,
									itemGroupNode.IsLocation,
									new Gradient(itemGroupNode.ColorGradient),
									Color.FromArgb(
										itemGroupNode.ClearColor.Red,
										itemGroupNode.ClearColor.Green,
										itemGroupNode.ClearColor.Blue),
									image);

								itemGroups.Add(itemGroup);
							}
						}

						string playerName;
						if (gameNode.Count > 1)
							playerName = gameNode.Player + (worldIndex + 1).ToString(format);
						else
							playerName = gameNode.Player;

						World world = new World(
							gameNode.Name,
							playerName,
							itemGroups);

						worlds.Add(world);
					}
				}

				Worker.ConnectAllWorlds();
			}
			catch (Exception ex)
			{
				Worker.SetStatus(ex.Message);
			}
			finally
			{
				Worker.CompleteRedraw();
			}
		}

		public void CompleteUpdatePicture()
		{
			pbn = new ItemGroup[mainPictureBox.Width, mainPictureBox.Height];
			overlays.Clear();

			if (worlds.Count > 0)
			{
				switch (pictureArrangmentMode)
				{
					case PictureArrangmentMode.FLUID:
						UpdatePictureFluid(pbn);
						break;
					default:
						throw new NotImplementedException("Picture arrangment mode not implemented.");
				}
			}

			UpdatePicture();
		}

		public void UpdatePicture()
		{
			if (InvokeRequired)
			{
				Invoke((MethodInvoker)delegate { UpdatePicture(); });
				return;
			}

			Bitmap bmp = new Bitmap(pbn.GetLength(0), pbn.GetLength(1));
			DrawBackground(bmp);
			DrawSegments(bmp, pbn);
			DrawOverlays(bmp, overlays);

			UpdateProgressBar();

			Image imgOld = mainPictureBox.Image;
			mainPictureBox.Image = bmp;
			if (imgOld != null)
				imgOld.Dispose();

			mainPictureBox.Refresh();
		}

		private void DrawBackground(Bitmap bmp)
		{
			using (Graphics g = Graphics.FromImage(bmp))
				g.Clear(fillerColor);
		}

		private void DrawSegments(Bitmap bmp, ItemGroup[,] pbn)
		{
			for (int i = 0; i < pbn.GetLength(0); ++i)
			{
				for (int j = 0; j < pbn.GetLength(1); ++j)
				{
					if (pbn[i, j] == null)
						continue;
					bmp.SetPixel(i, j, pbn[i, j].GetColor());
				}
			}
		}

		private void DrawOverlays(Bitmap bmp, List<(Rectangle area, ItemGroup itemGroup)> overlays)
		{
			using (Graphics graphics = Graphics.FromImage(bmp))
			{
				//Turn off anti aliasing for pixel art.
				if (RegistryHelper.GetValue(RegistryName.OVERLAY_INTERPOLATION, 1) == 0)
				{
					graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
					graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.None;
				}

				foreach ((Rectangle area, ItemGroup itemGroup) overlay in overlays)
				{
					graphics.DrawImage(GetImageFromOverlay(overlay.itemGroup, overlay.area), overlay.area);
				}
			}
		}

		private void UpdateProgressBar()
		{
			List<ItemGroup> itemGroups = new List<ItemGroup>();

			int currItems = 0;
			int totalItems = 0;

			switch (progressBarMode)
			{
				case ProgressBarMode.ITEM_GROUPDS:
					foreach (World world in worlds)
						itemGroups.AddRange(world.itemGroups);

					foreach (ItemGroup itemGroup in itemGroups)
					{
						currItems += itemGroup.count;
						totalItems += itemGroup.maxCount;
					}

					break;
				case ProgressBarMode.LOCATIONS:
					foreach (World world in worlds)
					{
						currItems += (int)world.locationsChecked;
						totalItems += (int)world.locationsTotal;
					}

					break;
			}

			if (currItems > totalItems)
				currItems = totalItems;

			statusPercentageBar.Maximum = totalItems;

			//Minimum set and unset to prevent the progress bar from glowing.
			statusPercentageBar.Minimum = currItems;
			statusPercentageBar.Value = currItems;
			statusPercentageBar.Minimum = 0;

			switch (progressBarMode)
			{
				case ProgressBarMode.ITEM_GROUPDS:
					statusPercentageBar.ToolTipText =
						currItems.ToString() + " items collected out of " + totalItems.ToString();
					break;
				case ProgressBarMode.LOCATIONS:
					statusPercentageBar.ToolTipText =
						currItems.ToString() + " locations checked out of " + totalItems.ToString();
					break;
			}
		}

		private void UpdatePictureFluid(ItemGroup[,] pbn)
		{
			List<ItemGroup> itemGroups = new List<ItemGroup>();
			foreach (World world in worlds)
				itemGroups.AddRange(world.itemGroups);

			int columnCount = 1;
			float itemGroupSize = pbn.GetLength(0) / (float)columnCount;
			int rowCount = (int)(pbn.GetLength(1) / itemGroupSize);

			while (rowCount * columnCount < itemGroups.Count)
			{
				++columnCount;
				itemGroupSize = pbn.GetLength(0) / (float)columnCount;
				rowCount = (int)(pbn.GetLength(1) / itemGroupSize);
			}

			while ((rowCount * columnCount) - columnCount >= itemGroups.Count)
				--rowCount;

			if (rowCount == 1)
				columnCount = itemGroups.Count;

			for (int rowID = 0; rowID < rowCount; ++rowID)
			{
				for (int columnID = 0; columnID < columnCount; ++columnID)
				{
					int ID = columnID + (rowID * columnCount);

					if (ID < itemGroups.Count)
						overlays.Add((new Rectangle(
							pbn.GetLength(0) * columnID / columnCount,
							pbn.GetLength(1) * rowID / rowCount,
							pbn.GetLength(0) / columnCount,
							pbn.GetLength(1) / rowCount),
							itemGroups[ID]));
				}
			}

			for (int y = 0; y < pbn.GetLength(1); ++y)
			{
				int rowID = y * rowCount / pbn.GetLength(1);

				for (int x = 0; x < pbn.GetLength(0); ++x)
				{
					int columnID = x * columnCount / pbn.GetLength(0);
					int ID = columnID + (rowID * columnCount);

					if (ID < itemGroups.Count)
						pbn[x, y] = itemGroups[ID];
				}
			}
		}

		private Image GetImageFromOverlay(ItemGroup itemGroup, Rectangle targetArea)
		{
			Image overlay = null;

			switch (overlayMode)
			{
				case OverlayMode.NORMAL:
					if (itemGroup.overlay != null)
						overlay = itemGroup.overlay;
					else
						overlay = DrawTextToImage(itemGroup.ToString(), itemGroup.GetColor());
					break;
				case OverlayMode.ALL_TEXT:
					overlay = DrawTextToImage(itemGroup.ToString(), itemGroup.GetColor());
					break;
				case OverlayMode.ONLY_IMAGE:
					if (itemGroup.overlay != null)
						overlay = itemGroup.overlay;
					else
						return null;
					break;
				case OverlayMode.NONE:
					return null;
				default:
					throw new NotImplementedException("OverlayMode of: " + overlayMode.ToString() + " not implemented.");
			}

			//Pad image so it has same aspect ratio as target area.
			Image extendedOverlay;
			float overlayRatio = overlay.Width / (float)overlay.Height;
			float areaRatio = targetArea.Width / (float)targetArea.Height;
			if (overlayRatio == areaRatio)
				extendedOverlay = overlay;
			else if (overlayRatio > areaRatio)
			{
				extendedOverlay = new Bitmap(overlay.Width, (int)(overlay.Width / areaRatio));
				
				using (Graphics graphics = Graphics.FromImage(extendedOverlay))
					graphics.DrawImage(overlay, new Rectangle(0, (extendedOverlay.Height / 2) - (overlay.Height / 2), extendedOverlay.Width, overlay.Height));
			}
			else
			{
				extendedOverlay = new Bitmap((int)(overlay.Height * areaRatio), overlay.Height);

				using (Graphics graphics = Graphics.FromImage(extendedOverlay))
					graphics.DrawImage(overlay, new Rectangle((extendedOverlay.Width / 2) - (overlay.Width / 2), 0, overlay.Width, extendedOverlay.Height));
			}

			return extendedOverlay;
		}

		private Image DrawTextToImage(string text, Color colorBG)
		{
			text = text.TrimEnd();

			Size s = TextRenderer.MeasureText(text, overlayFont);

			Bitmap bmp = new Bitmap(s.Width + overlayHorizontalOffset, s.Height);

			Brush brush = colorBG.GetBrightness() < brightBGThreshold ? lightBrush : darkbrush;

			using (Graphics graphics = Graphics.FromImage(bmp))
			{
				graphics.DrawString(text, overlayFont, brush, new PointF(0, 0));
			}

			return bmp;
		}

		public void SetStatus(string status)
		{
			if (InvokeRequired)
			{
				Invoke((MethodInvoker)delegate { SetStatus(status); });
				return;
			}

			statusLabel.Text = status;
		}

		public void LogStatus(string status)
		{
			lock (logFilepath)
			{
				if (!Directory.Exists(logFolderpath))
					Directory.CreateDirectory(logFolderpath);

				if (!File.Exists(logFilepath))
					File.Create(logFilepath).Close();

				File.AppendAllText(logFilepath, status + " " + DateTime.Now.ToString() + "\r\n");
			}
		}

		private void Main_ResizeEnd(object sender, EventArgs e)
		{
			Worker.CompleteRedraw();
		}

		private void Main_Load(object sender, EventArgs e)
		{
			Worker.SetStatus("PT Piranha started");

			//Delete old logs
			foreach (string file in Directory.GetFiles(logFolderpath))
			{
				if (DateTime.Now - File.GetLastWriteTime(file) > TimeSpan.FromDays(30))
				{
					File.Delete(file);
					Worker.SetStatus("Deleted old log: " + Path.GetFileName(file));
				}
			}

			SetConnectionFields();

			Worker.CompleteRedraw();
		}

		private void ConnectionSettingsButton_Click(object sender, EventArgs e)
		{
			ConnectionSettings connectionSettings = new ConnectionSettings();
			if (connectionSettings.ShowDialog() == DialogResult.OK)
				SetConnectionFields();
		}

		private void SetConnectionFields()
		{
			bool visible = RegistryHelper.GetValue(RegistryName.SHOW_CONNECTION_SETTINGS, 1) != 0;
			IPLabel.Visible = visible;
			IPTextBox.Visible = visible;
			portLabel.Visible = visible;
			portTextBox.Visible = visible;
			resetButton.Visible = visible;


			IPTextBox.Text = RegistryHelper.GetValue(RegistryName.IP_CURRENT,
				RegistryHelper.GetValue(RegistryName.IP_DEFAULT, "localhost"));
			portTextBox.Text = RegistryHelper.GetValue(RegistryName.PORT_CURRENT,
				RegistryHelper.GetValue(RegistryName.PORT_DEFAULT, 38281)).ToString();
		}

		private void IPChanged(object sender, EventArgs e)
		{
			RegistryHelper.SetValue(RegistryName.IP_CURRENT, IPTextBox.Text);
		}

		private void portTextBox_Validated(object sender, EventArgs e)
		{
			if (int.TryParse(portTextBox.Text, out int port))
				RegistryHelper.SetValue(RegistryName.PORT_CURRENT, port);
			else
			{
				portTextBox.Text = RegistryHelper.GetValue(RegistryName.PORT_CURRENT,
					RegistryHelper.GetValue(RegistryName.PORT_DEFAULT, 38281)).ToString();
			}
		}

		private void ResetButton_Click(object sender, EventArgs e)
		{
			RegistryHelper.SetValue(RegistryName.IP_CURRENT,
				RegistryHelper.GetValue(RegistryName.IP_DEFAULT, "localhost"));
			RegistryHelper.SetValue(RegistryName.PORT_CURRENT,
				RegistryHelper.GetValue(RegistryName.PORT_DEFAULT, 38281));

			SetConnectionFields();
		}

		private void mainPictureBox_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Location.Equals(mainPictureBoxLastMousePoint))
				return;

			mainPictureBoxLastMousePoint = e.Location;

			if (e.Location.X >= pbn.GetLength(0) ||
				e.Location.Y >= pbn.GetLength(1) ||
				pbn[e.Location.X, e.Location.Y] == null)
			{
				mainPictureBoxToolTip.Active = false;
				return;
			}

			mainPictureBoxToolTip.Active = true;
			mainPictureBoxToolTip.SetToolTip(mainPictureBox, pbn[e.Location.X, e.Location.Y].ToString());
		}

		private void Main_Resize(object sender, EventArgs e)
		{
			if (WindowState != currentState)
			{
				currentState = WindowState;
				Worker.CompleteRedraw();
			}
		}
	}

	public enum PictureArrangmentMode
	{ 
		/// <summary>
		/// Games are kept on seperate rows.
		/// </summary>
		SPACED,
		/// <summary>
		/// Games flow continuously.
		/// </summary>
		FLUID,
		/// <summary>
		/// All item groups are shuffled on the board.
		/// </summary>
		JUMBLE
	}

	public enum ProgressBarMode
	{
		/// <summary>
		/// Base progress bar percentage on the number of locations checked across all worlds.
		/// </summary>
		LOCATIONS,
		/// <summary>
		/// Base progress bar percentage on the sum of percentages of each item group of the multiworld tracker.
		/// </summary>
		ITEM_GROUPDS
	}

	public enum OverlayMode
	{
		/// <summary>
		/// If itemgroup has an image use that, otherwise use text.
		/// </summary>
		NORMAL,
		/// <summary>
		/// Show all itemgroups as text.
		/// </summary>
		ALL_TEXT,
		/// <summary>
		/// If itemgroup has an image use that, otherwise don't show overlay.
		/// </summary>
		ONLY_IMAGE,
		/// <summary>
		/// Don't show overlay.
		/// </summary>
		NONE
	}
}
