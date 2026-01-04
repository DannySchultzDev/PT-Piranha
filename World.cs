using Archipelago.MultiClient.Net;
using Archipelago.MultiClient.Net.Helpers;
using Archipelago.MultiClient.Net.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Color = System.Drawing.Color;

namespace PT_Piranha
{
	public class World
	{
		public string game;
		public string player;

		public List<ItemGroup> itemGroups;

		public ArchipelagoSession session = null;

		public World(string game, string player, List<ItemGroup> itemGroups)
		{
			this.game = game;
			this.player = player;
			this.itemGroups = itemGroups;

			foreach (ItemGroup itemGroup in this.itemGroups)
				itemGroup.world = this;
		}

		public void Connect()
		{
			try
			{
				string IP = RegistryHelper.GetValue(RegistryName.IP_CURRENT,
					RegistryHelper.GetValue(RegistryName.IP_DEFAULT, "localhost"));
				int port = RegistryHelper.GetValue(RegistryName.PORT_CURRENT,
					RegistryHelper.GetValue(RegistryName.PORT_DEFAULT, 38281));
				session = ArchipelagoSessionFactory.CreateSession(IP, port);
				if (session == null)
					throw new Exception("Session created was null.");

				session.Items.ItemReceived += ReceivedItem;
				session.Locations.CheckedLocationsUpdated += LocationChecked;

				LoginResult loginResult = session.TryConnectAndLogin(
					game,
					player,
					Archipelago.MultiClient.Net.Enums.ItemsHandlingFlags.AllItems,
					new Version(
						RegistryHelper.GetValue(RegistryName.VERSION_MAJOR, 0), 
						RegistryHelper.GetValue(RegistryName.VERSION_MINOR, 6),
						RegistryHelper.GetValue(RegistryName.VERSION_BUILD, 5)),
					new string[] { "Tracker" });

				if (loginResult == null)
					throw new Exception("Login result was null.");

				LocationChecked(null);

				Worker.SetStatus("Login for " + player + " was " + (loginResult.Successful ? "" : "not ") + "successful.");
				if (loginResult.Successful == false)
				{
					StringBuilder errors = new StringBuilder();
					foreach (string error in (loginResult as LoginFailure).Errors)
						errors.AppendLine(error);
					Worker.SetStatus("Login failed: " + errors);
				}
			}
			catch (Exception ex)
			{
				Worker.SetStatus("Could not connect " + player + " to " + game + ": " + ex.Message);
			}
		}

		public void ReceivedItem(ReceivedItemsHelper helper)
		{
			ItemInfo itemInfo = helper.DequeueItem();
			while (itemInfo != null)
			{
				Worker.SetStatus(player + " received " + itemInfo.ItemName);
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

			Worker.Redraw();
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
				Worker.Redraw();
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

	public class ItemGroup
	{
		public World world = null;

		public string name;
		
		//What can the item go by?
		//For instance the Item "moves" may contain "jump" and "run"
		public List<string> targets = new List<string>();
		
		//How many locations are left to check can be tracked like an item.
		public bool isLocations;

		public Gradient gradient;
		public Color clearColor;

		public Image overlay;

		public int count = 0;

		//The number of instances in the game.
		public int maxCount = 0;

		private static long indexer = 0;
		public readonly long index = indexer++;

		public ItemGroup(string name, List<string> targets, bool isLocations, Gradient gradient, Color clearColor, Image overlay)
		{
			this.name = name;
			this.targets = targets;
			this.isLocations = isLocations;
			this.gradient = gradient;
			this.clearColor = clearColor;
			this.overlay = overlay;
		}

		public Color GetColor()
		{
			if (count >= maxCount)
				return clearColor;
			else
				return gradient.GetColor(count/(float)maxCount);
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			if (world != null)
			{
				sb.AppendLine(world.player);
				sb.AppendLine(world.game);
			}

			sb.AppendLine(name);
			sb.AppendLine(count + " / " + maxCount);

			return sb.ToString();
		}
	}

	public class Gradient
	{
		public List<(float weight, Color color)> colors;

		private (float weight, Color color) lastColor = (-1, Color.Black);

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
			if (weight == lastColor.weight)
				return lastColor.color;

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
			else if (endHue - startHue > 180)
			{
				lerpHue = ((endHue - (startHue + 360)) * lerpAmt) + startHue + 360;
				if (lerpHue > 360)
					lerpHue -= 360;
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

			Color returnColor;

			if (hi == 0)
				returnColor = Color.FromArgb(255, v, t, p);
			else if (hi == 1)
				returnColor = Color.FromArgb(255, q, v, p);
			else if (hi == 2)
				returnColor = Color.FromArgb(255, p, v, t);
			else if (hi == 3)
				returnColor = Color.FromArgb(255, p, q, v);
			else if (hi == 4)
				returnColor = Color.FromArgb(255, t, p, v);
			else
				returnColor = Color.FromArgb(255, v, p, q);

			lastColor = (weight, returnColor);
			return returnColor;
		}

		public Color GetFirstColor()
		{
			float lowestWeight = colors.First().weight;
			Color lowestColor = colors.First().color;

			foreach ((float weight, Color color) color in colors)
			{
				if (color.weight < lowestWeight)
				{
					lowestWeight = color.weight;
					lowestColor = color.color;
				}
			}

			return lowestColor;
		}

		public Color GetLastColor()
		{
			float heighestWeight = colors.Last().weight;
			Color heighestColor = colors.Last().color;

			foreach ((float weight, Color color) color in colors)
			{
				if (color.weight > heighestWeight)
				{
					heighestWeight = color.weight;
					heighestColor = color.color;
				}
			}

			return heighestColor;
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			foreach ((float weight, Color color) color in colors)
			{
				sb.AppendLine(
					color.weight.ToString(CultureInfo.InvariantCulture) + "|" +
					color.color.R.ToString() + "|" + 
					color.color.G.ToString() + "|" + 
					color.color.B.ToString());
			}
			return sb.ToString().TrimEnd();
		}

		public static bool TryParse(string str, out Gradient gradient)
		{
			if (string.IsNullOrWhiteSpace(str))
			{
				gradient = null;
				return false;
			}

			List<(float weight, Color color)> colors = new List<(float weight, Color color)>();

			foreach (string line in str.Split('\n'))
			{
				string[] parts = line.TrimEnd().Split('|');
				
				if (parts.Length != 4)
				{
					gradient = null;
					return false;
				}

				if (float.TryParse(parts[0], NumberStyles.Float, CultureInfo.InvariantCulture, out float weight) &&
					byte.TryParse(parts[1], out byte r) &&
					byte.TryParse(parts[2], out byte g) &&
					byte.TryParse(parts[3], out byte b))
					colors.Add((weight, Color.FromArgb(r, g, b)));
				else
				{
					gradient = null;
					return false;
				}
			}

			gradient = new Gradient(colors);
			return true;
		}
	}
}
