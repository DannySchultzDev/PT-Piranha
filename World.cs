using Archipelago.MultiClient.Net;
using Archipelago.MultiClient.Net.Helpers;
using Archipelago.MultiClient.Net.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Color = System.Drawing.Color;

namespace PT_Piranha
{
	internal class World
	{
		public string game;
		public string player;

		public List<ItemGroup> itemGroups;

		public ArchipelagoSession session = null;

		public World(string game, string player, List<ItemGroup> items)
		{
			this.game = game;
			this.player = player;
			this.itemGroups = items;
		}

		public void Connect()
		{
			try
			{
				(string IP, int port) connectString = Main.instance.GetConnectString();
				session = ArchipelagoSessionFactory.CreateSession(connectString.IP, connectString.port);
				if (session == null)
					throw new Exception("Session created was null.");

				LoginResult loginResult = session.TryConnectAndLogin(
					game,
					player,
					Archipelago.MultiClient.Net.Enums.ItemsHandlingFlags.AllItems,
					null,
					new string[] { "Tracker" });

				if (loginResult == null)
					throw new Exception("Login result was null.");

				session.Items.ItemReceived += ReceivedItem;
				session.Locations.CheckedLocationsUpdated += LocationChecked;

				Main.instance.SetStatus("Login for " + player + " was " + (loginResult.Successful ? "" : "not ") + "successful.");
			}
			catch (Exception ex)
			{
				Main.instance.SetStatus("Could not connect " + player + " to " + game + ": " + ex.Message);
			}
		}

		public void ReceivedItem(ReceivedItemsHelper helper)
		{
			{
				ItemInfo itemInfo = helper.DequeueItem();
				while (itemInfo != null)
				{
					Main.instance.SetStatus(player + " received " + itemInfo.ItemName);
					foreach (ItemGroup itemGroup in itemGroups)
					{
						if (itemGroup.isLocations)
							continue;


						if (itemInfo.ItemName.Equals(itemGroup.name))
						{
							++itemGroup.count;
						}
						else
						{
							foreach (string target in itemGroup.targets)
							{
								if (itemInfo.ItemName.Equals(target))
								{
									++itemGroup.count;
									break;
								}
							}
						}
					}
					itemInfo = helper.DequeueItem();
				}
			}

			Main.instance.UpdatePicture();
		}

		private void LocationChecked(System.Collections.ObjectModel.ReadOnlyCollection<long> newCheckedLocations)
		{
			bool needUpdate = false;
			foreach (ItemGroup itemGroup in itemGroups)
			{
				if (itemGroup.isLocations)
				{
					itemGroup.count = session.Locations.AllLocationsChecked.Count;
					needUpdate = true;
				}
			}
			if (needUpdate)
				Main.instance.UpdatePicture();
		}

		public void SetUpMaxLocations()
		{
			foreach (ItemGroup itemGroup in itemGroups)
				if (itemGroup.isLocations)
					itemGroup.maxCount = session.Locations.AllLocations.Count;
		}

		public void ScoutReceivedItem(ScoutedItemInfo itemInfo)
		{
			foreach (ItemGroup itemGroup in itemGroups)
			{
				if (itemGroup.isLocations)
					continue;

				if (itemInfo.ItemName.Equals(itemGroup.name))
				{
					++itemGroup.maxCount;
				}
				else
				{
					foreach (string target in itemGroup.targets)
					{
						if (itemInfo.ItemName.Equals(target))
						{
							++itemGroup.maxCount;
							break;
						}
					}
				}
			}
		}
	}

	internal class ItemGroup
	{
		public string name;
		
		//What can the item go by?
		//For instance the Item "moves" may contain "jump" and "run"
		public List<string> targets = new List<string>();
		
		//How many locations are left to check can be tracked like an item.
		public bool isLocations;

		public Gradient gradient;
		public Color clearColor;

		public int count = 0;

		//The number of instances in the game.
		public int maxCount = 0;

		private static long indexer = 0;
		public readonly long index = indexer++;

		public ItemGroup(string name, List<string> targets, bool isLocations, Gradient gradient, Color clearColor)
		{
			this.name = name;
			this.targets = targets;
			this.isLocations = isLocations;
			this.gradient = gradient;
			this.clearColor = clearColor;
		}

		public Color GetColor()
		{
			if (count >= maxCount)
				return clearColor;
			else
				return gradient.GetColor(count/(float)maxCount);
		}
	}

	public class Gradient
	{
		public List<(float weight, Color color)> colors;

		public Gradient(List<(float weight, Color color)> colors)
		{
			this.colors = colors;
		}

		public Gradient(GradientType gradient)
		{
			colors = new List<(float weight, Color color)>();
			foreach (ColorType color in gradient.Color)
				colors.Add((color.Weight, Color.FromArgb(color.Red, color.Green, color.Blue)));
		}

		public Color GetColor(float weight)
		{
			(float weight, Color color)? startColor = null;
			(float weight, Color color)? endColor = null;

			foreach ((float weight, Color color) color in colors)
			{
				if (color.weight == weight)
					return color.color;
				else if (color.weight < weight)
				{
					if (startColor == null)
						startColor = color;
					else if (color.weight > startColor.Value.weight)
						startColor = color;
				}
				else
				{
					if (endColor == null)
						endColor = color;
					else if (color.weight < endColor.Value.weight)
						endColor = color;
				}
			}

			if (startColor == null && endColor == null)
				throw new Exception("Gradient missing Color.");
			else if (startColor == null)
				return endColor.Value.color;
			else if (endColor == null)
				return startColor.Value.color;

			float lerpAmt = (weight - startColor.Value.weight) / (endColor.Value.weight - startColor.Value.weight);

			int max;
			int min;
			max = Math.Max(startColor.Value.color.R, Math.Max(startColor.Value.color.G, startColor.Value.color.B));
			min = Math.Min(startColor.Value.color.R, Math.Min(startColor.Value.color.G, startColor.Value.color.B));
			float startHue = startColor.Value.color.GetHue();
			float startSat = (max == 0) ? 0 : 1.0f - (min / (float)max);
			float startVal = max / 255.0f;
			max = Math.Max(endColor.Value.color.R, Math.Max(endColor.Value.color.G, endColor.Value.color.B));
			min = Math.Min(endColor.Value.color.R, Math.Min(endColor.Value.color.G, endColor.Value.color.B));
			float endHue = endColor.Value.color.GetHue();
			float endSat = (max == 0) ? 0 : 1.0f - (min / (float)max);
			float endVal = max / 255.0f;

			float lerpHue;
			if (endHue - startHue >= -180 && endHue - startHue <= 180)
			{
				lerpHue = ((endHue - startHue) * lerpAmt) + startHue;
			}
			else
			{
				lerpHue = ((endHue + 360 - startHue) * lerpAmt) + startHue;
				if (lerpHue > 360)
					lerpHue -= 360;
			}

			float lerpSat = ((endSat - startSat) * lerpAmt) + startSat;
			float lerpVal = ((endVal - startVal) * lerpAmt) + startVal;

			int hi = Convert.ToInt32(Math.Floor(lerpHue / 60)) % 6;
			double f = lerpHue / 60 - Math.Floor(lerpHue / 60);

			lerpVal = lerpVal * 255;
			int v = Convert.ToInt32(lerpVal);
			int p = Convert.ToInt32(lerpVal * (1 - lerpSat));
			int q = Convert.ToInt32(lerpVal * (1 - f * lerpSat));
			int t = Convert.ToInt32(lerpVal * (1 - (1 - f) * lerpSat));

			if (hi == 0)
				return Color.FromArgb(255, v, t, p);
			else if (hi == 1)
				return Color.FromArgb(255, q, v, p);
			else if (hi == 2)
				return Color.FromArgb(255, p, v, t);
			else if (hi == 3)
				return Color.FromArgb(255, p, q, v);
			else if (hi == 4)
				return Color.FromArgb(255, t, p, v);
			else
				return Color.FromArgb(255, v, p, q);
		}
	}
}
