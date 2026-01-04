using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace PT_Piranha
{
	public partial class MWGEN : Form
	{
		private Dictionary<string, Image> overlays = new Dictionary<string, Image>();

		public MWGEN()
		{
			InitializeComponent();
			var topLeftCell = gamesDataGridView.TopLeftHeaderCell;
			topLeftCell = itemGroupsDataGridView.TopLeftHeaderCell;
			topLeftCell = itemGroupPartsDataGridView.TopLeftHeaderCell;
		}

		private void FormatIndexColumn(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.ColumnIndex != 0 || e.RowIndex < 0)
				return;

			e.Value = (e.RowIndex + 1).ToString();
		}

		private void FormatAllIndexColumns(object sender, DataGridViewCellFormattingEventArgs e, DataGridViewColumn parentColumn)
		{
			FormatIndexColumn(sender, e);
			
			if (e.ColumnIndex < 0 ||
				parentColumn.DataGridView.Columns[e.ColumnIndex] != parentColumn || 
				e.RowIndex < 0)
				return;
			
			DataGridViewCell cell = parentColumn.DataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
			if (cell.Value != null)
				return;
			
			DataGridViewCell templateCell = parentColumn.DataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
			while (templateCell.Value == null && templateCell.RowIndex > 0)
				templateCell = parentColumn.DataGridView.Rows[templateCell.RowIndex - 1].Cells[e.ColumnIndex];
			
			if (templateCell.Value == null)
				return;
			
			e.Value = templateCell.Value;
		}

		private void FormatItemGroupTable(object sender, DataGridViewCellFormattingEventArgs e)
		{
			FormatAllIndexColumns(sender, e, gameColumn);
		}

		private void FormatItemGroupPartTable(object sender, DataGridViewCellFormattingEventArgs e)
		{
			FormatAllIndexColumns(sender, e, itemGroupColumn);
		}

		private void PaintItemGroupCell(object sender, DataGridViewCellPaintingEventArgs e)
		{
			if (e.ColumnIndex < 0 || e.RowIndex < 0)
				return;

			DataGridViewCell cell = itemGroupsDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];

			if (cell.OwningColumn.Equals(itemGroupGradientColumn))
			{
				ImageButton imageButton = cell as ImageButton;
				if (imageButton == null)
					return;

				Gradient gradient = imageButton.Tag as Gradient;
				if (gradient == null)
				{
					if (!Gradient.TryParse(
						RegistryHelper.GetValue(RegistryName.GRADIENT_DEFAULT,
						"0|255|0|0\r\n1|0|255|0"),
						out gradient))
						return;
				}

				imageButton.Tag = gradient;

				Bitmap bitmap = new Bitmap(256, 16);
				for (int x = 0; x < bitmap.Width; ++x)
				{
					Color color = gradient.GetColor(x/(float)bitmap.Width);
					for (int y = 0; y < bitmap.Height; ++y)
					{
						bitmap.SetPixel(x, y, color);
					}
				}

				imageButton.image = bitmap;
			}
			else if (cell.OwningColumn.Equals(itemGroupClearColorColumn))
			{
				Color? cellColor = cell.Tag as Color?;
				if (cellColor == null)
				{
					string colorString = RegistryHelper.GetValue(RegistryName.CLEAR_COLOR_DEFAULT, "255|255|0");
					string[] colorStringParts = colorString.Split('|');

					if (byte.TryParse(colorStringParts[0], out byte r) &&
						byte.TryParse(colorStringParts[1], out byte g) &&
						byte.TryParse(colorStringParts[2], out byte b))
						cell.Tag = Color.FromArgb(r, g, b);
					else
						return;

					cellColor = cell.Tag as Color?;
				}

				e.CellStyle.BackColor = (Color)cellColor;
			}
			else if (cell.OwningColumn.Equals(itemGroupOverlayColumn))
			{
				ImageButton imageButton = cell as ImageButton;
				if (imageButton == null)
					return;

				if (!(imageButton.Tag is string))
					return;
				Image image = overlays[(string)imageButton.Tag];
				imageButton.image = image;
			}
		}

		private void ClickItemGroupCell(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex < 0 || e.RowIndex < 0)
				return;

			DataGridViewCell cell = itemGroupsDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
			if (cell == null || !(cell is DataGridViewButtonCell))
				return;

			DataGridViewButtonCell buttonCell = cell as DataGridViewButtonCell;

			if (cell.OwningColumn.Equals(itemGroupGradientColumn))
			{ 
				GradientDialog gradientDialog = new GradientDialog();
				gradientDialog.Gradient = (Gradient)cell.Tag;
				if (gradientDialog.ShowDialog() != DialogResult.OK)
					return;

				buttonCell.Tag = gradientDialog.Gradient;
			}
			else if (cell.OwningColumn.Equals(itemGroupClearColorColumn))
			{
				ColorDialog colorDialog = new ColorDialog();
				colorDialog.Color = (Color)buttonCell.Tag;
				if (colorDialog.ShowDialog() != DialogResult.OK)
					return;

				buttonCell.Tag = colorDialog.Color;
			}
			else if (cell.OwningColumn.Equals(itemGroupOverlayColumn))
			{
				OpenFileDialog openFileDialog = new OpenFileDialog();
				openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp|PNG (*.png)|*.png|JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|Bitmap (*.bmp)|*.bmp|Gif (*.gif)|*.gif";
				if (openFileDialog.ShowDialog() != DialogResult.OK)
					return;

				if (!overlays.ContainsKey(openFileDialog.FileName))
					overlays.Add(openFileDialog.FileName, Image.FromFile(openFileDialog.FileName));

				buttonCell.Tag = openFileDialog.FileName;
			}

			itemGroupsDataGridView.Refresh();
		}

		private void Generate(object sender, EventArgs e)
		{
			try
			{
				Dictionary<uint, (
					string gameName,
					string playerName, 
					uint worldCount, 
					Dictionary<uint, (
					string itemGroupName,
					bool isLocation, 
					Gradient gradient, 
					Color clearColor,
					List<uint> overlays,
					List<string> itemGroupParts)> itemGroups)> dict = 
					new Dictionary<uint, (
					string gameName,
					string playerName, 
					uint worldCount, 
					Dictionary<uint, (
					string itemGroupName,
					bool isLocation, 
					Gradient gradient, 
					Color clearColor, 
					List<uint> overlays,
					List<string> itemGroupParts)> itemGroups)>();

				Dictionary<uint, List<string>> itemGroupDict = 
					new Dictionary<uint, List<string>>();

				Dictionary<string, uint> overlayIDs = new Dictionary<string, uint>();
				Dictionary<uint, Image> overlaysByIDs = new Dictionary<uint, Image>();
				{
					uint ID = 0;
					foreach (string key in overlays.Keys)
					{
						overlayIDs.Add(key, ID);
						overlaysByIDs.Add(ID, overlays[key]);
						++ID;
					}
				}


				foreach (DataGridViewRow row in gamesDataGridView.Rows)
				{
					string indexStr = row.Cells[0].FormattedValue as string;
					bool validIndex = uint.TryParse(indexStr, out uint index);
					string gameName = row.Cells[1].Value as string;
					string playerName = row.Cells[2].Value as string;
					string worldCountStr = row.Cells[3].Value as string;
					bool validWorldCount = uint.TryParse(worldCountStr, out uint worldCount);
					if (string.IsNullOrEmpty(gameName) &&
						string.IsNullOrEmpty(playerName) &&
						string.IsNullOrEmpty(worldCountStr))
						continue;
					else if (string.IsNullOrEmpty(indexStr))
						throw new Exception("Games table has a row with no ID.");
					else if (!validIndex)
						throw new Exception("Games table has an invalid ID: " + indexStr);
					else if (string.IsNullOrEmpty(gameName))
						throw new Exception("Game " + index + " is missing a game name.");
					else if (string.IsNullOrEmpty(playerName))
						throw new Exception("Game " + index + " is missing a player name.");
					else if (string.IsNullOrEmpty(worldCountStr))
						throw new Exception("Game " + index + " is missing a number of worlds.");
					else if (!validWorldCount)
						throw new Exception("Game " + index + " has an invalid number of worlds: " + worldCountStr);

					dict.Add(index, (
						gameName,
						playerName, 
						worldCount, 
						new Dictionary<uint, (
						string itemGroupName,
						bool isLocation, 
						Gradient gradients, 
						Color clearColor, 
						List<uint> overlays,
						List<string> itemGroupParts)>()));
				}

				foreach (DataGridViewRow row in itemGroupsDataGridView.Rows)
				{
					string indexStr = row.Cells[0].FormattedValue as string;
					bool validIndex = uint.TryParse(indexStr, out uint index);
					string itemGroupName = row.Cells[1].Value as string;
					string gameIndexStr = row.Cells[2].FormattedValue as string;
					bool validGameIndex = uint.TryParse(gameIndexStr, out uint gameIndex);
					bool isLocation = (bool)row.Cells[3].FormattedValue;
					Gradient gradient = row.Cells[4].Tag as Gradient;
					Color clearColor = Color.White;
					if (row.Cells[5].Tag is Color)
						clearColor = (Color)row.Cells[5].Tag;
					List<uint> itemGroupOverlays = new List<uint>();
					if (row.Cells[6].Tag is string &&
						overlays.ContainsKey((string)row.Cells[6].Tag) &&
						overlayIDs.TryGetValue((string)row.Cells[6].Tag, out uint ID))
						itemGroupOverlays.Add(ID);

					if (string.IsNullOrEmpty(itemGroupName))
						continue;
					else if (string.IsNullOrEmpty(indexStr))
						throw new Exception("Item Groups table has a row with no ID.");
					else if (!validIndex)
						throw new Exception("Item Groups table has an invalid ID: " + indexStr);
					else if (string.IsNullOrEmpty(gameIndexStr))
						throw new Exception("Item Group " + index + " is missing a game ID.");
					else if (!validGameIndex || !dict.ContainsKey(gameIndex))
						throw new Exception("Item Group " + index + " has an invalid game ID: " + gameIndexStr);
					else if (gradient == null)
						throw new Exception("Item Group " + index + " has an invalid Gradient.");

					List<string> itemGroupParts = new List<string>();

					dict[gameIndex].itemGroups.Add(index, (
						itemGroupName, 
						isLocation, 
						gradient, 
						clearColor, 
						itemGroupOverlays, 
						itemGroupParts));
					itemGroupDict.Add(index, itemGroupParts);
				}

				foreach (DataGridViewRow row in itemGroupPartsDataGridView.Rows)
				{
					string indexStr = row.Cells[0].FormattedValue as string;
					bool validIndex = uint.TryParse(indexStr, out uint index);
					string itemGroupPartName = row.Cells[1].Value as string;
					string itemGroupIndexStr = row.Cells[2].FormattedValue as string;
					bool validItemGroupIndex = uint.TryParse(itemGroupIndexStr, out uint itemGroupIndex);

					if (string.IsNullOrEmpty(itemGroupPartName))
						continue;
					else if (string.IsNullOrEmpty(indexStr))
						throw new Exception("Item Groups table has a row with no ID.");
					else if (!validIndex)
						throw new Exception("Item Groups table has an invalid ID: " + indexStr);
					else if (string.IsNullOrEmpty(itemGroupIndexStr))
						throw new Exception("Item Group Part " + index + " is missing an item group ID.");
					else if (!validItemGroupIndex || !itemGroupDict.ContainsKey(itemGroupIndex))
						throw new Exception("Item Group Part " + index + " has an invalid item group ID: " + itemGroupIndexStr);

					itemGroupDict[itemGroupIndex].Add(itemGroupPartName);
				}

				Root root = new Root();
				
				List<GameType> gameNodes = new List<GameType>();
				foreach (var game in dict.Values)
				{
					GameType gameNode = new GameType();

					gameNode.Name = game.gameName;
					gameNode.Player = game.playerName;
					gameNode.Count = game.worldCount;

					List<ItemGroupType> itemGroupNodes = new List<ItemGroupType>();
					foreach (var itemGroup in game.itemGroups.Values)
					{
						ItemGroupType itemGroupNode = new ItemGroupType();

						itemGroupNode.Name = itemGroup.itemGroupName;
						itemGroupNode.IsLocation = itemGroup.isLocation;

						GradientType gradientNode = new GradientType();
						List<ColorType> colorNodes = new List<ColorType>();
						foreach ((float weight, Color color) color in itemGroup.gradient.colors)
						{
							ColorType colorNode = new ColorType();
							colorNode.Weight = color.weight;
							colorNode.Red = color.color.R;
							colorNode.Green = color.color.G;
							colorNode.Blue = color.color.B;
							colorNodes.Add(colorNode);
						}
						gradientNode.Color = colorNodes.ToArray();
						gradientNode.GradientStyle = 1;
						itemGroupNode.ColorGradient = gradientNode;

						ColorType clearColorNode = new ColorType();
						clearColorNode.Red = itemGroup.clearColor.R;
						clearColorNode.Green = itemGroup.clearColor.G;
						clearColorNode.Blue = itemGroup.clearColor.B;
						clearColorNode.Weight = 1.0f;
						itemGroupNode.ClearColor = clearColorNode;

						List<OverlayIDType> overlayIDNodes = new List<OverlayIDType>();
						foreach (uint overlayID in itemGroup.overlays)
						{
							OverlayIDType overlayIDNode = new OverlayIDType();
							
							overlayIDNode.ID = overlayID;

							overlayIDNodes.Add(overlayIDNode);
						}
						itemGroupNode.OverlayID = overlayIDNodes.ToArray();

						List<ItemGroupPartType> itemGroupPartNodes = new List<ItemGroupPartType>();
						foreach (string itemGroupPart in itemGroup.itemGroupParts)
						{
							ItemGroupPartType itemGroupPartNode = new ItemGroupPartType();

							itemGroupPartNode.Name = itemGroupPart;
							itemGroupPartNode.Value = 1;
							itemGroupPartNode.ValueSpecified = true;

							itemGroupPartNodes.Add(itemGroupPartNode);
						}
						itemGroupNode.ItemGroupPart = itemGroupPartNodes.ToArray();

						itemGroupNodes.Add(itemGroupNode);
					}
					gameNode.ItemGroup = itemGroupNodes.ToArray();

					gameNodes.Add(gameNode);
				}
				root.Game = gameNodes.ToArray();

				List<OverlayType> overlayNodes = new List<OverlayType>();
				foreach (uint ID in overlaysByIDs.Keys)
				{
					OverlayType overlayNode = new OverlayType();

					overlayNode.ID = ID;
					
					using (MemoryStream ms = new MemoryStream())
					{
						overlaysByIDs[ID].Save(ms, overlaysByIDs[ID].RawFormat);
						overlayNode.Data = ms.ToArray();
					}

					overlayNodes.Add(overlayNode);
				}
				root.Overlay = overlayNodes.ToArray();

				SaveFileDialog saveFileDialog = new SaveFileDialog();
				saveFileDialog.Filter = "piranha files (*.piranha)|*.piranha|xml files (*.xml)|*.xml|All files (*.*)|*.*";
				if (saveFileDialog.ShowDialog() != DialogResult.OK)
					return;

				XmlSerializer serializer = new XmlSerializer(typeof(Root));
				using (StreamWriter stream = new StreamWriter(saveFileDialog.FileName))
				{
					serializer.Serialize(stream, root);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Could not Generate Multiworld Tracker: " + ex.Message);
			}
		}

		public void AddMultiworldToTracker(object sender, EventArgs e)
		{
			string filepath;
			try
			{
				OpenFileDialog openFileDialog = new OpenFileDialog();
				openFileDialog.Filter = "piranha files (*.piranha)|*.piranha|xml files (*.xml)|*.xml|All files (*.*)|*.*";
				if (openFileDialog.ShowDialog() != DialogResult.OK)
					return;

				filepath = openFileDialog.FileName;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Could not add Multiworld Tracker: " + ex.Message);
				return;
			}

			AddMultiworldToTracker(filepath);
		}

		public void AddMultiworldToTracker(string filepath)
		{
			try
			{
				Root rootNode;
				XmlSerializer serializer = new XmlSerializer(typeof(Root));
				using (StreamReader stream = new StreamReader(filepath))
				{
					rootNode = serializer.Deserialize(stream) as Root;
				}

				Dictionary<uint, string> overlayGuids = new Dictionary<uint, string>();
				if (rootNode.Overlay != null)
				{
					foreach (OverlayType overlayNode in rootNode.Overlay)
					{
						string guid = Guid.NewGuid().ToString();
						overlayGuids.Add(overlayNode.ID, guid);

						ImageConverter converter = new ImageConverter();
						overlays.Add(guid, (Image)converter.ConvertFrom(overlayNode.Data));
					}
				}

				foreach (GameType gameNode in rootNode.Game)
				{
					gamesDataGridView.Rows.Add();
					DataGridViewRow gameRow = gamesDataGridView.Rows[gamesDataGridView.Rows.Count - 2];

					int gameIndex = int.Parse((string)gameRow.Cells[0].FormattedValue);

					gameRow.Cells[1].Value = gameNode.Name;
					gameRow.Cells[2].Value = gameNode.Player;
					gameRow.Cells[3].Value = gameNode.Count.ToString();

					if (gameNode.ItemGroup != null)
					{
						foreach (ItemGroupType itemGroupNode in gameNode.ItemGroup)
						{
							itemGroupsDataGridView.Rows.Add();
							DataGridViewRow itemGroupRow = itemGroupsDataGridView.Rows[itemGroupsDataGridView.Rows.Count - 2];

							int itemGroupIndex = int.Parse((string)itemGroupRow.Cells[0].FormattedValue);

							itemGroupRow.Cells[1].Value = itemGroupNode.Name;
							itemGroupRow.Cells[2].Value = gameIndex.ToString();
							itemGroupRow.Cells[3].Value = itemGroupNode.IsLocation;

							itemGroupRow.Cells[4].Tag = new Gradient(itemGroupNode.ColorGradient);

							itemGroupRow.Cells[5].Tag = Color.FromArgb(
								itemGroupNode.ClearColor.Red,
								itemGroupNode.ClearColor.Green,
								itemGroupNode.ClearColor.Blue);

							if (itemGroupNode.OverlayID != null &&
								itemGroupNode.OverlayID.Length > 0)
								itemGroupRow.Cells[6].Tag = overlayGuids[itemGroupNode.OverlayID[0].ID];

							if (itemGroupNode.ItemGroupPart != null)
							{
								foreach (ItemGroupPartType itemGroupPartNode in itemGroupNode.ItemGroupPart)
								{
									itemGroupPartsDataGridView.Rows.Add();
									DataGridViewRow itemGroupPartRow = itemGroupPartsDataGridView.Rows[itemGroupPartsDataGridView.Rows.Count - 2];

									itemGroupPartRow.Cells[1].Value = itemGroupPartNode.Name;
									itemGroupPartRow.Cells[2].Value = itemGroupIndex.ToString();
								}
							}
						}
					}
				}

				itemGroupsDataGridView.Refresh();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Could not add Multiworld Tracker: " + ex.Message);
			}
		}
	}
}
