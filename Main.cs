using Archipelago.MultiClient.Net;
using Archipelago.MultiClient.Net.Helpers;
using Archipelago.MultiClient.Net.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Color = System.Drawing.Color;

namespace PT_Piranha
{
	public partial class Main : Form
	{
		private List<World> worlds = new List<World>();
		public static Main instance { get; private set; }
		private PictureArrangmentMode pictureArrangmentMode = PictureArrangmentMode.FLUID;
		private Color fillerColor = Color.White;
		private Bitmap bmp = new Bitmap(1, 1);

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
			if (openFileDialog.ShowDialog() != DialogResult.OK)
			{
				SetStatus("Load Multiworld Tracker canceled.");
				return;
			}

			LoadGame(openFileDialog.FileName);
		}

		private void GenerateMWButton_Click(object sender, EventArgs e)
		{
			MWGEN mwGen = new MWGEN();
			mwGen.Show();
		}

		public async void LoadGame(string filepath)
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

						World world = new World(
							gameNode.Name,
							gameNode.Player + (worldIndex + 1).ToString(format),
							itemGroups);

						world.Connect();

						worlds.Add(world);
					}
				}

				foreach (World world in worlds)
				{
					world.SetUpMaxLocations();

					//Calculate item totals by scouting.
					ILocationCheckHelper helper = world.session.Locations;
					Task<Dictionary<long, ScoutedItemInfo>> scout = helper.ScoutLocationsAsync(false, helper.AllLocations.ToArray());
					await scout.ConfigureAwait(false);
					Dictionary<long, ScoutedItemInfo> scoutResults = scout.Result;

					foreach (ScoutedItemInfo scoutedItemInfo in scoutResults.Values)
					{
						foreach (World receivingWorld in worlds)
						{
							if (receivingWorld.player.Equals(scoutedItemInfo.Player.Name))
							{
								receivingWorld.ScoutReceivedItem(scoutedItemInfo);
								break;
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				statusLabel.Text = ex.Message;
			}
			finally
			{
				UpdatePicture();
			}
		}

		public void UpdatePicture()
		{
			if (InvokeRequired)
			{
				Invoke((MethodInvoker)delegate { UpdatePicture(); });
				return;
			}

			if (mainPictureBox.Image == null ||
				mainPictureBox.Width != mainPictureBox.Image.Width ||
				mainPictureBox.Height != mainPictureBox.Image.Height)
				mainPictureBox.Image = new Bitmap(mainPictureBox.Width, mainPictureBox.Height);

			switch (pictureArrangmentMode)
			{
				case PictureArrangmentMode.FLUID:
					UpdatePictureFluid();
					break;
				default:
					throw new NotImplementedException("Picture arrangment mode not implemented.");
			}

			mainPictureBox.Refresh();
		}

		private void UpdatePictureFluid()
		{
			List<ItemGroup> itemGroups = new List<ItemGroup>();
			foreach (World world in worlds)
				itemGroups.AddRange(world.itemGroups);

			Bitmap bmp = (Bitmap)mainPictureBox.Image;

			int columnCount = 1;
			float itemGroupSize = bmp.Width / (float)columnCount;
			int rowCount = (int)(bmp.Height / itemGroupSize);

			while (rowCount * columnCount < itemGroups.Count)
			{
				++columnCount;
				itemGroupSize = bmp.Width / (float)columnCount;
				rowCount = (int)(bmp.Height / itemGroupSize);
			}

			for (int y = 0; y < bmp.Height; ++y)
			{
				int rowID = y * rowCount / bmp.Height;

				for (int x = 0; x < bmp.Width; ++x)
				{
					int columnID = x * columnCount / bmp.Width;
					int ID = columnID + (rowID * columnCount);

					if (ID < itemGroups.Count)
						bmp.SetPixel(x, y, itemGroups[ID].GetColor());
					else
						bmp.SetPixel(x, y, fillerColor);
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

		public (string IP, int port) GetConnectString()
		{
			string IP = IPTextBox.Text;
			if (string.IsNullOrWhiteSpace(IP))
				throw new Exception("IP field is empty.");

			string portString = portTextBox.Text;
			if (string.IsNullOrWhiteSpace(portString))
				throw new Exception("Port field is empty.");
			if (!int.TryParse(portTextBox.Text, out int port))
				throw new Exception("Port is not an int");

			return (IP, port);
		}



		private void Main_ResizeEnd(object sender, EventArgs e)
		{
			UpdatePicture();
		}

		private void generateMWButton_Click(object sender, EventArgs e)
		{

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
