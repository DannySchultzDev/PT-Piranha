using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
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

			if ((!cell.OwningColumn.Equals(itemGroupStartColorColumn)) &&
				(!cell.OwningColumn.Equals(itemGroupEndColorColumn)) &&
				(!cell.OwningColumn.Equals(itemGroupClearColorColumn)))
				return;

			Color? cellColor = cell.Tag as Color?;
			if (cellColor == null)
			{
				if (cell.OwningColumn.Equals(itemGroupStartColorColumn))
					cell.Tag = Color.Red;
				else if (cell.OwningColumn.Equals(itemGroupEndColorColumn))
					cell.Tag = Color.Green;
				else if (cell.OwningColumn.Equals(itemGroupClearColorColumn))
					cell.Tag = Color.Yellow;
				else
					throw new NotImplementedException("Default cell color not set up.");

				cellColor = cell.Tag as Color?;
			}

			e.CellStyle.BackColor = (Color)cellColor;
		}

		private void ClickColorButtonCell(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex < 0 || e.RowIndex < 0)
				return;

			DataGridViewCell cell = itemGroupsDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
			if (cell == null || !(cell is DataGridViewButtonCell))
				return;

			DataGridViewButtonCell buttonCell = cell as DataGridViewButtonCell;

			ColorDialog colorDialog = new ColorDialog();
			colorDialog.Color = (Color)buttonCell.Tag;
			if (colorDialog.ShowDialog() != DialogResult.OK)
				return;

			buttonCell.Tag = colorDialog.Color;
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
					Color startColor, 
					Color endColor, 
					Color clearColor, 
					List<string> itemGroupParts)> itemGroups)> dict = 
					new Dictionary<uint, (
					string gameName,
					string playerName, 
					uint worldCount, 
					Dictionary<uint, (
					string itemGroupName,
					bool isLocation, 
					Color startColor, 
					Color endColor, 
					Color clearColor, 
					List<string> itemGroupParts)> itemGroups)>();

				Dictionary<uint, List<string>> itemGroupDict = 
					new Dictionary<uint, List<string>>();

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
						Color startColor, 
						Color endColor, 
						Color clearColor, 
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
					Color startColor = (Color)row.Cells[4].Tag;
					Color endColor = (Color)row.Cells[5].Tag;
					Color clearColor = (Color)row.Cells[6].Tag;

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

					List<string> itemGroupParts = new List<string>();

					dict[gameIndex].itemGroups.Add(index, (itemGroupName, isLocation, startColor, endColor, clearColor, itemGroupParts));
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
						ColorType startColorNode = new ColorType();
						startColorNode.Red = itemGroup.startColor.R;
						startColorNode.Green = itemGroup.startColor.G;
						startColorNode.Blue = itemGroup.startColor.B;
						startColorNode.Weight = 0.0f;
						colorNodes.Add(startColorNode);
						ColorType endColorNode = new ColorType();
						endColorNode.Red = itemGroup.endColor.R;
						endColorNode.Green = itemGroup.endColor.G;
						endColorNode.Blue = itemGroup.endColor.B;
						endColorNode.Weight = 1.0f;
						colorNodes.Add(endColorNode);
						gradientNode.Color = colorNodes.ToArray();
						gradientNode.GradientStyle = 1;
						itemGroupNode.ColorGradient = gradientNode;

						ColorType clearColorNode = new ColorType();
						clearColorNode.Red = itemGroup.clearColor.R;
						clearColorNode.Green = itemGroup.clearColor.G;
						clearColorNode.Blue = itemGroup.clearColor.B;
						clearColorNode.Weight = 1.0f;
						itemGroupNode.ClearColor = clearColorNode;

						List<ItemGroupPartType> itemGroupPartNodes = new List<ItemGroupPartType>();
						foreach (string itemGroupPart in itemGroup.itemGroupParts)
						{
							ItemGroupPartType itemGroupPartNode = new ItemGroupPartType();

							itemGroupPartNode.Name = itemGroupPart;

							itemGroupPartNodes.Add(itemGroupPartNode);
						}
						itemGroupNode.ItemGroupPart = itemGroupPartNodes.ToArray();

						itemGroupNodes.Add(itemGroupNode);
					}
					gameNode.ItemGroup = itemGroupNodes.ToArray();

					gameNodes.Add(gameNode);
				}
				root.Game = gameNodes.ToArray();

				SaveFileDialog saveFileDialog = new SaveFileDialog();
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

		private void AddMultiworldToTracker(object sender, EventArgs e)
		{
			try
			{
				OpenFileDialog openFileDialog = new OpenFileDialog();
				if (openFileDialog.ShowDialog() != DialogResult.OK)
					return;

				Root rootNode;
				XmlSerializer serializer = new XmlSerializer(typeof(Root));
				using (StreamReader stream = new StreamReader(openFileDialog.FileName))
				{
					rootNode = serializer.Deserialize(stream) as Root;
				}

				foreach (GameType gameNode in rootNode.Game)
				{
					gamesDataGridView.Rows.Add();
					DataGridViewRow gameRow = gamesDataGridView.Rows[gamesDataGridView.Rows.Count - 2];

					int gameIndex = int.Parse((string)gameRow.Cells[0].FormattedValue);

					gameRow.Cells[1].Value = gameNode.Name;
					gameRow.Cells[2].Value = gameNode.Player;
					gameRow.Cells[3].Value = gameNode.Count;

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

							Gradient gradient = new Gradient(itemGroupNode.ColorGradient);

							itemGroupRow.Cells[4].Tag = gradient.GetFirstColor();
							itemGroupRow.Cells[5].Tag = gradient.GetLastColor();

							itemGroupRow.Cells[6].Tag = Color.FromArgb(
								itemGroupNode.ClearColor.Red,
								itemGroupNode.ClearColor.Green,
								itemGroupNode.ClearColor.Blue);

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
