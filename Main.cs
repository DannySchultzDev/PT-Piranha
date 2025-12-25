using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
		private ItemGroup[,] pbn = new ItemGroup[1,1];

		ToolTip mainPictureBoxToolTip = new ToolTip();
		Point mainPictureBoxLastMousePoint = new Point(0, 0);

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

								ItemGroup itemGroup = new ItemGroup(
									itemGroupNode.Name, 
									itemGroupParts,
									itemGroupNode.IsLocation,
									new Gradient(itemGroupNode.ColorGradient),
									Color.FromArgb(
										itemGroupNode.ClearColor.Red,
										itemGroupNode.ClearColor.Green,
										itemGroupNode.ClearColor.Blue));

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
			DrawOverlays(bmp, pbn);

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
					if (pbn[i,j] == null)
						continue;
					bmp.SetPixel(i, j, pbn[i, j].GetColor());
				}
			}
		}

		private void DrawOverlays(Bitmap bmp, ItemGroup[,] pbn)
		{
			
		}

		private void UpdateProgressBar()
		{
			List<ItemGroup> itemGroups = new List<ItemGroup>();
			foreach (World world in worlds)
				itemGroups.AddRange(world.itemGroups);

			int currItems = 0;
			int totalItems = 0;

			foreach (ItemGroup itemGroup in itemGroups)
			{
				currItems += itemGroup.count;
				totalItems += itemGroup.maxCount;
			}

			if (currItems > totalItems)
				currItems = totalItems;

			statusPercentageBar.Maximum = totalItems;

			//Minimum set and unset to prevent the progress bar from glowing.
			statusPercentageBar.Minimum = currItems;
			statusPercentageBar.Value = currItems;
			statusPercentageBar.Minimum = 0;

			statusPercentageBar.ToolTipText = 
				currItems.ToString() + " items collected out of " + totalItems.ToString();
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
}
