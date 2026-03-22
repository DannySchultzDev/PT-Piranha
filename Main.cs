using System.Xml.Serialization;
using Color = System.Drawing.Color;
using System.ComponentModel;
using Microsoft.Win32;
using System.Data;
using System.Numerics;

namespace PT_Piranha
{
	public partial class Main : Form
	{
		public List<World> worlds = new List<World>();
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public static Main? instance { get; private set; }

		private ItemGroupStyle itemGroupStyle = ItemGroupStyle.FLUID;
		public static ShowBackgroundImage showBackgroundImage = ShowBackgroundImage.EMPTY_CELLS_ONLY;
		public static readonly Color fillerColor = Color.White;
		private ItemGroup[,] pbn = new ItemGroup[1, 1];
		private OverlayStyle overlayStyle = OverlayStyle.IMAGE_OR_TEXT;
		private List<(Rectangle area, ItemGroup itemGroup)> overlays =
			new List<(Rectangle area, ItemGroup itemGroup)>();
		private static readonly Font overlayFont = new Font(DefaultFont.FontFamily, 30);
		private static readonly int overlayHorizontalOffset = 5;

		private static float brightBGThreshold = .7f;
		private static readonly Brush lightBrush = new SolidBrush(Color.White);
		private static readonly Brush darkbrush = new SolidBrush(Color.Black);

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public static ProgressBarStyle progressBarStyle = ProgressBarStyle.LOCATIONS;

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
								List<(string name, uint value)> itemGroupParts = new List<(string name, uint value)>();

								if (itemGroupNode.ItemGroupPart != null)
								{
									foreach (ItemGroupPartType itemGroupPartNode in itemGroupNode.ItemGroupPart)
									{
										if (itemGroupPartNode.ValueSpecified)
											itemGroupParts.Add((itemGroupPartNode.Name, itemGroupPartNode.Value));
										else
											itemGroupParts.Add((itemGroupPartNode.Name, 1));
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
			if (!Enum.TryParse(RegistryHelper.GetValue(RegistryName.SHOW_BACKGROUND_IMAGE, DesignSettings.showBackgroundImageTrueDefault), out showBackgroundImage))
			{
				if (!Enum.TryParse(DesignSettings.showBackgroundImageTrueDefault, out showBackgroundImage))
				{
					Worker.SetStatus("Could not parse show background image or its default.");
				}
				RegistryHelper.SetValue(RegistryName.SHOW_BACKGROUND_IMAGE, DesignSettings.showBackgroundImageTrueDefault);
			}

			if (!Enum.TryParse(RegistryHelper.GetValue(RegistryName.ITEM_GROUP_STYLE, DesignSettings.itemGroupStyleTrueDefault), out itemGroupStyle))
			{
				if (!Enum.TryParse(DesignSettings.itemGroupStyleTrueDefault, out itemGroupStyle))
				{
					Worker.SetStatus("Could not parse item group style or its default.");
				}
				RegistryHelper.SetValue(RegistryName.ITEM_GROUP_STYLE, DesignSettings.itemGroupStyleTrueDefault);
			}

			if (!Enum.TryParse(RegistryHelper.GetValue(RegistryName.PROGRESS_BAR_STYLE, DesignSettings.progressBarStyleTrueDefault), out progressBarStyle))
			{
				if (!Enum.TryParse(DesignSettings.progressBarStyleTrueDefault, out progressBarStyle))
				{
					Worker.SetStatus("Could not parse progress bar style or its default.");
				}
				RegistryHelper.SetValue(RegistryName.PROGRESS_BAR_STYLE, DesignSettings.progressBarStyleTrueDefault);
			}

			if (!Enum.TryParse(RegistryHelper.GetValue(RegistryName.OVERLAY_STYLE, DesignSettings.overlayStyleTrueDefault), out overlayStyle))
			{
				if (!Enum.TryParse(DesignSettings.overlayStyleTrueDefault, out overlayStyle))
				{
					Worker.SetStatus("Could not parse overlay style or its default.");
				}
				RegistryHelper.SetValue(RegistryName.OVERLAY_STYLE, DesignSettings.overlayStyleTrueDefault);
			}

			pbn = new ItemGroup[mainPictureBox.Width, mainPictureBox.Height];

			if (worlds.Count > 0)
			{
				switch (itemGroupStyle)
				{
					case ItemGroupStyle.SEPERATE_GAMES:
						UpdatePictureSeperateGames(pbn, overlays);
						break;
					case ItemGroupStyle.FLUID:
						UpdatePictureFluid(pbn, overlays);
						break;
					case ItemGroupStyle.JUMBLE:
						UpdatePictureJumble(pbn, overlays);
						break;
					case ItemGroupStyle.VORONOI:
						UpdatePictureVoronoi(pbn, overlays);
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

			if (pbn.GetLength(0) >= 1 &&
				pbn.GetLength(1) >= 1)
			{
				Bitmap bmp = new Bitmap(pbn.GetLength(0), pbn.GetLength(1));
				DrawBackground(bmp);
				DrawSegments(bmp, pbn);
				DrawOverlays(bmp, overlays);

				Image imgOld = mainPictureBox.Image;
				mainPictureBox.Image = bmp;
				if (imgOld != null)
					imgOld.Dispose();
			}

			UpdateProgressBar();

			mainPictureBox.Refresh();
		}

		private void DrawBackground(Bitmap bmp)
		{
			using Graphics graphics = Graphics.FromImage(bmp);

			Image? backgroundImage = null;
			try
			{
				ImageGetter.TryGetImage(RegistryHelper.GetValue(RegistryName.BACKGROUND_IMAGE, string.Empty), out backgroundImage);
			}
			catch (Exception ex)
			{
				Worker.SetStatus("Could not get background image: " + 
					RegistryHelper.GetValue(RegistryName.BACKGROUND_IMAGE, string.Empty) + 
					" because: " + ex.Message);
				return;
			}

			graphics.Clear(fillerColor);

			if (backgroundImage == null)
				return;

			if (!Enum.TryParse(RegistryHelper.GetValue(RegistryName.BACKGROUND_IMAGE_STYLE, DesignSettings.backgroundImageStyleTrueDefault), out BackgroundImageStyle backgroundImageStyle))
			{
				if (!Enum.TryParse(DesignSettings.backgroundImageStyleTrueDefault, out backgroundImageStyle))
				{
					Worker.SetStatus("Could not parse background image style or its default.");
					return;
				}
				RegistryHelper.SetValue(RegistryName.BACKGROUND_IMAGE_STYLE, DesignSettings.backgroundImageStyleTrueDefault);
			}

			switch (backgroundImageStyle)
			{
				case BackgroundImageStyle.TILE:
					for (int y = 0; y < bmp.Height; y += backgroundImage.Height)
					{
						for (int x = 0;  x < bmp.Width; x += backgroundImage.Width)
						{
							graphics.DrawImage(backgroundImage, new Rectangle(x, y, backgroundImage.Width, backgroundImage.Height));
						}
					}
					break;
				case BackgroundImageStyle.STRETCH:
					graphics.DrawImage(backgroundImage, new Rectangle(0, 0, bmp.Width, bmp.Height));
					break;
				case BackgroundImageStyle.CLIP:
					graphics.DrawImage(backgroundImage, new Rectangle(
						(bmp.Width / 2) - (backgroundImage.Width / 2),
						(bmp.Height / 2) - (backgroundImage.Height / 2),
						backgroundImage.Width,
						backgroundImage.Height));
					break;
				case BackgroundImageStyle.FIT:
					float bmpRatio = bmp.Width / (float)bmp.Height;
					float backgroundImageRatio = backgroundImage.Width / (float)backgroundImage.Height;
					if (bmpRatio >= backgroundImageRatio)
						graphics.DrawImage(backgroundImage, new Rectangle(
							(bmp.Width / 2) - (int)(backgroundImageRatio * bmp.Height / 2.0f),
							0,
							(int)(backgroundImageRatio * bmp.Height),
							bmp.Height));
					else
						graphics.DrawImage(backgroundImage, new Rectangle(
							0,
							(bmp.Height / 2) - (int)(backgroundImage.Height * bmp.Width / (float)backgroundImage.Width / 2),
							bmp.Width,
							(int)(backgroundImage.Height * bmp.Width / (float)backgroundImage.Width)));
					break;
				default:
					Worker.SetStatus("Background image style has not been implemented.");
					return;
			}

		}

		private void DrawSegments(Bitmap bmp, ItemGroup[,] pbn)
		{
			for (int i = 0; i < pbn.GetLength(0); ++i)
			{
				for (int j = 0; j < pbn.GetLength(1); ++j)
				{
					if (pbn[i, j] == null)
						continue;
					Color? color = pbn[i, j].GetColor();
					if ( color != null)
						bmp.SetPixel(i, j, (Color)color);
				}
			}
		}

		private void DrawOverlays(Bitmap bmp, List<(Rectangle area, ItemGroup itemGroup)> overlays)
		{
			using (Graphics graphics = Graphics.FromImage(bmp))
			{
				//Turn off anti aliasing for pixel art.
				//Overlay Interpolation originally saved an int to the registry.
				//If the user has an old registry value, update it.
				OverlayInterpolation overlayInterpolation;
				if (RegistryHelper.GetValueType(RegistryName.OVERLAY_INTERPOLATION) == RegistryValueKind.DWord)
				{
					overlayInterpolation = (OverlayInterpolation)RegistryHelper.GetValue(RegistryName.OVERLAY_INTERPOLATION, 0);
					RegistryHelper.SetValue(RegistryName.OVERLAY_INTERPOLATION, overlayInterpolation.ToString());
				}
				else
				{
					if (!Enum.TryParse(
						RegistryHelper.GetValue(RegistryName.OVERLAY_INTERPOLATION, DesignSettings.overlayInterpolationTrueDefault),
						out overlayInterpolation))
					{
						if (!Enum.TryParse(DesignSettings.overlayInterpolationTrueDefault,
							out overlayInterpolation))
							throw new Exception("Overlay interpolation and its default are invalid.");
						RegistryHelper.SetValue(RegistryName.OVERLAY_INTERPOLATION, DesignSettings.overlayInterpolationTrueDefault);
					}
				}
				if (overlayInterpolation == OverlayInterpolation.NONE)
				{
					graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
					graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.None;
				}

				foreach ((Rectangle area, ItemGroup itemGroup) overlay in overlays)
				{
					Image? overlayImage = GetImageFromOverlay(overlay.itemGroup, overlay.area, overlayStyle);
					if (overlayImage != null)
						graphics.DrawImage(overlayImage, overlay.area);
				}
			}
		}

		private void UpdateProgressBar()
		{
			List<ItemGroup> itemGroups = new List<ItemGroup>();

			int currItems = 0;
			int totalItems = 0;

			string progressBarToolTip = string.Empty;

			switch (progressBarStyle)
			{
				case ProgressBarStyle.LOCATIONS:
					foreach (World world in worlds)
					{
						currItems += (int)world.locationsChecked;
						totalItems += (int)world.locationsTotal;
					}

					progressBarToolTip =
						currItems.ToString() + " locations checked out of " + totalItems.ToString();

					break;
				case ProgressBarStyle.ITEM_GROUPS:
					foreach (World world in worlds)
						itemGroups.AddRange(world.itemGroups);

					foreach (ItemGroup itemGroup in itemGroups)
					{
						currItems += itemGroup.count;
						totalItems += itemGroup.maxCount;
					}

					progressBarToolTip =
						currItems.ToString() + " items collected out of " + totalItems.ToString();

					break;
				case ProgressBarStyle.ITEM_GROUPS_COMPLETED:
					foreach (World world in worlds)
						itemGroups.AddRange(world.itemGroups);

					foreach (ItemGroup itemGroup in itemGroups)
					{
						currItems += itemGroup.count >= itemGroup.maxCount ? 1 : 0;
						++totalItems;
					}

					progressBarToolTip =
						currItems.ToString() + " item groups completed out of " + totalItems.ToString();

					break;
				case ProgressBarStyle.GAME_PERCENTAGES:
					float gamePercentages = 0.0f;
					int games = 0;
					foreach (World world in worlds)
					{
						gamePercentages += world.locationsChecked / (float)world.locationsTotal;
						++games;
					}	

					if (games == 0)
					{
						currItems = 0;
						totalItems = 1;

						progressBarToolTip =
							"No games loaded";
					}
					else
					{
						gamePercentages /= games;
						gamePercentages *= 100;

						currItems = (int)gamePercentages;
						totalItems = 100;

						progressBarToolTip = 
							"Average game completion is " + gamePercentages.ToString("F2");
					}
					break;
				case ProgressBarStyle.GAMES_COMPLETED:
					foreach (World world in worlds)
					{
						currItems += world.hasGoaled ? 1 : 0;
						++totalItems;
					}

					progressBarToolTip = currItems + " games completed out of " + totalItems;

					break;
				default:
					Worker.SetStatus("Proggress bar style has not been implemented.");
					return;
			}

			if (currItems > totalItems)
				currItems = totalItems;

			statusPercentageBar.Maximum = totalItems;

			//Minimum set and unset to prevent the progress bar from glowing.
			statusPercentageBar.Minimum = currItems;
			statusPercentageBar.Value = currItems;
			statusPercentageBar.Minimum = 0;

			statusPercentageBar.ToolTipText = progressBarToolTip;
		}

		private void UpdatePictureSeperateGames(ItemGroup[,] pbn, List<(Rectangle area, ItemGroup itemGroup)> overlays)
		{
			int columnCount = 0;
			float itemGroupSize;
			int rowCount;

			bool itemSlotsContatined = false;

			do
			{
				++columnCount;
				itemGroupSize = pbn.GetLength(0) / (float)columnCount;
				rowCount = (int)(pbn.GetLength(1) / itemGroupSize);

				int rowsUsed = 0;

				foreach (World world in worlds)
				{
					int itemGroupsCount = world.itemGroups.Count;
					rowsUsed += (int)MathF.Ceiling(itemGroupsCount / (float)columnCount);
					if (rowsUsed > rowCount)
						break;
				}

				if (rowsUsed <= rowCount)
				{
					itemSlotsContatined = true;
					rowCount = rowsUsed;
				}

			} while (!itemSlotsContatined);

			overlays.Clear();

			int currRow = 0;
			int currColumn = 0;

			foreach (World world in worlds)
			{
				foreach (ItemGroup itemGroup in world.itemGroups)
				{
					if (currColumn >= columnCount)
					{
						currColumn = 0;
						++currRow;
					}

					Rectangle area = new Rectangle(
						currColumn * pbn.GetLength(0) / columnCount,
						currRow * pbn.GetLength(1) / rowCount,
						pbn.GetLength(0) / columnCount,
						pbn.GetLength(1) / rowCount);

					for (int y = 0; y < area.Height; ++y)
					{
						for (int x = 0; x < area.Width; ++x)
						{
							pbn[x + area.Left, y + area.Top] = itemGroup;
						}
					}

					overlays.Add((area, itemGroup));

					++currColumn;
				}

				currColumn = 0;
				++currRow;
			}
		}

		private void UpdatePictureFluid(ItemGroup[,] pbn, List<(Rectangle area, ItemGroup itemGroup)> overlays)
		{
			List<ItemGroup> itemGroups = new List<ItemGroup>();
			foreach (World world in worlds)
				itemGroups.AddRange(world.itemGroups);
			UpdatePictureFluid(pbn, overlays, itemGroups);
		}

		private void UpdatePictureJumble(ItemGroup[,] pbn, List<(Rectangle area, ItemGroup itemGroup)> overlays)
		{
			Random rand = new Random(0);

			List<ItemGroup> itemGroups = new List<ItemGroup>();
			foreach (World world in worlds)
			{
				foreach (ItemGroup itemGroup in world.itemGroups)
					itemGroups.Insert(rand.Next(itemGroups.Count + 1), itemGroup);
			}
			UpdatePictureFluid(pbn, overlays, itemGroups);
		}

		private void UpdatePictureFluid(ItemGroup[,] pbn, List<(Rectangle area, ItemGroup itemGroup)> overlays, List<ItemGroup> itemGroups)
		{
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

			overlays.Clear();

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

		private void UpdatePictureVoronoi(ItemGroup[,] pbn, List<(Rectangle area, ItemGroup itemGroup)> overlays)
		{
			List<ItemGroup> itemGroups = new List<ItemGroup>();
			foreach (World world in worlds)
				itemGroups.AddRange(world.itemGroups);

			overlays.Clear();

			//If the size of the picture box is too small, don't draw anything.
			if (pbn.GetLength(0) * pbn.GetLength(1) < itemGroups.Count)
				return;

			Dictionary<Point, ItemGroup> itemGroupPoints = new Dictionary<Point, ItemGroup>();

			Random rand = new Random(0);

			foreach(ItemGroup itemGroup in itemGroups)
			{
				Point point;
				
				do
				{
					point = new Point(
					rand.Next(int.MaxValue) % pbn.GetLength(0),
					rand.Next(int.MaxValue) % pbn.GetLength(1));
				} while (itemGroupPoints.ContainsKey(point));

				itemGroupPoints[point] = itemGroup;
			}

			Point[] points = itemGroupPoints.Keys.ToArray();

			for (int y = 0; y < pbn.GetLength(1); ++y)
			{
				for (int x = 0; x < pbn.GetLength(0); ++x)
				{
					Vector2 currPos = new Vector2(x, y);
					float closestDistSqrd = float.MaxValue;
					Point closestPoint = points[0];

					foreach (Point point in points)
					{
						float distSqrd = Vector2.DistanceSquared(currPos, new Vector2(point.X, point.Y));
						if (distSqrd < closestDistSqrd)
						{
							closestPoint = point;
							closestDistSqrd = distSqrd;
						}
					}

					pbn[x, y] = itemGroupPoints[closestPoint];
				}
			}

			foreach (Point point in points)
			{
				Point topLeft = point;
				while (
					topLeft.X > 0 &&
					topLeft.Y > 0 &&
					pbn[topLeft.X - 1, topLeft.Y - 1].Equals(itemGroupPoints[point]))
				{
					topLeft.Offset(-1, -1);
				}
				while (
					topLeft.X > 0 &&
					pbn[topLeft.X - 1, topLeft.Y].Equals(itemGroupPoints[point]))
				{
					topLeft.Offset(-1, 0);
				}
				while (
					topLeft.Y > 0 &&
					pbn[topLeft.X, topLeft.Y - 1].Equals(itemGroupPoints[point]))
				{
					topLeft.Offset(0, -1);
				}
				Point topRight = point;
				while (
					topRight.X < pbn.GetLength(0) - 1 &&
					topRight.Y > 0 &&
					pbn[topRight.X + 1, topRight.Y - 1].Equals(itemGroupPoints[point]))
				{
					topRight.Offset(1, -1);
				}
				while (
					topRight.X < pbn.GetLength(0) - 1 &&
					pbn[topRight.X + 1, topRight.Y].Equals(itemGroupPoints[point]))
				{
					topRight.Offset(1, 0);
				}
				while (
					topRight.Y > 0 &&
					pbn[topRight.X, topRight.Y - 1].Equals(itemGroupPoints[point]))
				{
					topRight.Offset(0, -1);
				}
				Point bottomLeft = point;
				while (
					bottomLeft.X > 0 &&
					bottomLeft.Y < pbn.GetLength(1) - 1 &&
					pbn[bottomLeft.X - 1, bottomLeft.Y + 1].Equals(itemGroupPoints[point]))
				{
					bottomLeft.Offset(-1, 1);
				}
				while (
					bottomLeft.X > 0 &&
					pbn[bottomLeft.X - 1, bottomLeft.Y].Equals(itemGroupPoints[point]))
				{
					bottomLeft.Offset(-1, 0);
				}
				while (
					bottomLeft.Y < pbn.GetLength(1) - 1 &&
					pbn[bottomLeft.X, bottomLeft.Y + 1].Equals(itemGroupPoints[point]))
				{
					bottomLeft.Offset(0, 1);
				}
				Point bottomRight = point;
				while (
					bottomRight.X < pbn.GetLength(0) - 1 &&
					bottomRight.Y < pbn.GetLength(1) - 1 &&
					pbn[bottomRight.X + 1, bottomRight.Y + 1].Equals(itemGroupPoints[point]))
				{
					bottomRight.Offset(1, 1);
				}
				while (
					bottomRight.X < pbn.GetLength(0) - 1 &&
					pbn[bottomRight.X + 1, bottomRight.Y].Equals(itemGroupPoints[point]))
				{
					bottomRight.Offset(1, 0);
				}
				while (
					bottomRight.Y < pbn.GetLength(1) - 1 &&
					pbn[bottomRight.X, bottomRight.Y + 1].Equals(itemGroupPoints[point]))
				{
					bottomRight.Offset(0, 1);
				}

				int left = Math.Max(topLeft.X, bottomLeft.X);
				int top = Math.Max(topLeft.Y, topRight.Y);

				overlays.Add((new Rectangle(
					left,
					top,
					Math.Min(topRight.X, bottomRight.X) - left,
					Math.Min(bottomLeft.Y, bottomRight.Y) - top),
					itemGroupPoints[point]));
			}
		}

		private Image? GetImageFromOverlay(ItemGroup itemGroup, Rectangle targetArea, OverlayStyle overlayStyle)
		{
			Image overlay = null;

			Color? itemGroupColor = itemGroup.GetColor();
			if (itemGroupColor == null)
				return null;

			switch (overlayStyle)
			{
				case OverlayStyle.IMAGE_OR_TEXT:
					if (itemGroup.overlay != null)
						overlay = itemGroup.overlay;
					else
						overlay = DrawTextToImage(itemGroup.ToString(), (Color)itemGroupColor);
					break;
				case OverlayStyle.COMBO:
					Image? imageOverlay = GetImageFromOverlay(itemGroup, new Rectangle(0, 0, targetArea.Width, (int)(targetArea.Height * 2 / 3.0f)), OverlayStyle.IMAGE_ONLY);
					if (imageOverlay == null)
						goto case OverlayStyle.TEXT_ONLY;

						Image? textOverlay = GetImageFromOverlay(itemGroup, new Rectangle(0, 0, targetArea.Width, (int)(targetArea.Height / 3.0f)), OverlayStyle.COMBO_STRING);
					if (textOverlay == null)
						goto case OverlayStyle.IMAGE_ONLY;

					overlay = new Bitmap(targetArea.Width, targetArea.Height);
					using (Graphics graphics = Graphics.FromImage(overlay))
					{
						graphics.DrawImage(imageOverlay, new Rectangle(0, 0, targetArea.Width, (int)(targetArea.Height * 2 / 3.0f)));
						graphics.DrawImage(textOverlay, new Rectangle(0, (int)(targetArea.Height * 2 / 3.0f), targetArea.Width, (int)(targetArea.Height / 3.0f)));
					}
					break;
				case OverlayStyle.TEXT_ONLY:
					overlay = DrawTextToImage(itemGroup.ToString(), (Color)itemGroupColor);
					break;
				case OverlayStyle.IMAGE_ONLY:
					if (itemGroup.overlay != null)
						overlay = itemGroup.overlay;
					else
						return null;
					break;
				case OverlayStyle.NONE:
					return null;
				case OverlayStyle.COMBO_STRING:
					overlay = DrawTextToImage(itemGroup.ToComboString(), (Color)itemGroupColor);
					break;
				default:
					throw new NotImplementedException("OverlayMode of: " + overlayStyle.ToString() + " not implemented.");
			}

			//Pad image so it has same aspect ratio as target area.
			Image extendedOverlay;
			float overlayRatio = overlay.Width / (float)overlay.Height;
			int areaHeight = targetArea.Height != 0 ? targetArea.Height : 1;
			float areaRatio = targetArea.Width / (float)areaHeight;
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
					Worker.SetStatus("Deleted old log: " + Path.GetFileName(file), true);
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

		private void designToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DesignSettings designSettings = new DesignSettings();
			if (designSettings.ShowDialog() == DialogResult.OK)
				Worker.CompleteRedraw();
		}
	}
}
