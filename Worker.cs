using Archipelago.MultiClient.Net.Helpers;
using Archipelago.MultiClient.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PT_Piranha
{
	public static class Worker
	{
		private static Thread workerThread;

		private static bool initialized = false;

		private static ManualResetEvent resetEvent = new ManualResetEvent(false);

		private static bool needToConnectAllWorlds = false;

		private static bool needToRedraw = false;

		private static bool needToSetStatus = false;
		private static string currStatus = string.Empty;

		private static void Initialize()
		{
			workerThread = new Thread(WatchForWork);
			workerThread.IsBackground = true;
			workerThread.Start();
			initialized = true;
		}


		private static void WatchForWork()
		{
			while (true)
			{
				resetEvent.WaitOne();

				if (needToConnectAllWorlds)
				{
					needToConnectAllWorlds = false;
					DoConnectAllWorlds();
				}
				if (needToRedraw)
				{
					needToRedraw = false;
					DoRedraw();
				}
				if (needToSetStatus)
				{
					needToSetStatus = false;
					DoSetStatus();
				}
			}
		}

		public static void ConnectAllWorlds()
		{
			if (!initialized)
				Initialize();

			if (needToConnectAllWorlds)
				return;

			needToConnectAllWorlds = true;
			resetEvent.Set();
		}

		private static async void DoConnectAllWorlds()
		{
			foreach (World world in Main.instance.worlds)
				world.Connect();

			foreach (World world in Main.instance.worlds)
			{
				world.SetUpMaxLocations();

				//Calculate item totals by scouting.
				ILocationCheckHelper helper = world.session.Locations;
				Task<Dictionary<long, ScoutedItemInfo>> scout = helper.ScoutLocationsAsync(false, helper.AllLocations.ToArray());
				await scout.ConfigureAwait(false);
				Dictionary<long, ScoutedItemInfo> scoutResults = scout.Result;

				foreach (ScoutedItemInfo scoutedItemInfo in scoutResults.Values)
				{
					foreach (World receivingWorld in Main.instance.worlds)
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

		public static void Redraw()
		{
			if (!initialized)
				Initialize();

			if (needToRedraw)
				return;

			needToRedraw = true;
			resetEvent.Set();
		}

		private static void DoRedraw()
		{
			Main.instance.UpdatePicture();
		}

		public static void SetStatus(string status, bool quiet = false)
		{
			if (!initialized)
				Initialize();

			Main.instance.LogStatus(status);

			if (quiet)
				return;

			lock (currStatus)
			{
				currStatus = status;

				if (needToSetStatus)
					return;

				needToSetStatus = true;
				resetEvent.Set();
			}
		}

		private static void DoSetStatus()
		{
			lock (currStatus)
			{
				Main.instance.SetStatus(currStatus);
				currStatus = string.Empty;
			}
		}
	}
}
