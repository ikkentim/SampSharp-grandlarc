using System;
using System.Diagnostics;
using SampSharp.Entities;
using SampSharp.Entities.SAMP;
using SampSharp.Entities.SAMP.Commands;

namespace GrandLarcency
{
	public class ServerControlSystem : ISystem
	{
		[Event]
		public void OnGameModeInit(IServerService serverService, IWorldService worldService)
		{
			Console.WriteLine("---------------------------------------");
            Console.WriteLine("Running Grand Larceny - by the SA-MP team");
            Console.WriteLine("Converted to SampSharp");
            Console.WriteLine("---------------------------------------");

			serverService.SetGameModeText("Grand Larcency");
            serverService.ShowPlayerMarkers(PlayerMarkersMode.Global);
            serverService.ShowNameTags(true);
            serverService.SetNameTagDrawDistance(40.0f);
            serverService.EnableStuntBonus(false);
            serverService.DisableInteriorEnterExits();
            serverService.SetWorldTime(11);

            worldService.SetWeather(2);
        }

        [Event]
        public bool OnPlayerUpdate(Player player)
        {
            // Don't allow minigun
            if (player.Weapon == Weapon.Minigun)
            {
                player.Kick();
                return false;
            }

            return true;
        }
	}
}