// GrandLarcency
// Copyright 2020 Tim Potze
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using SampSharp.Entities;
using SampSharp.Entities.SAMP;

namespace GrandLarcency
{
    /// <summary>
    /// Represents a system which handles basic player events.
    /// </summary>
    public class PlayerSystem : ISystem
    {
        [Event]
        public void OnPlayerConnect(Player player)
        {
            player.GameText("~w~Grand Larceny", 3000, 4);
            player.SendClientMessage("Welcome to {88AA88}G{FFFFFF}rand {88AA88}L{FFFFFF}arceny");
        }

        [Event]
        public void OnPlayerSpawn(CitizenComponent citizen, ISpawnLocationRepository spawnLocationRepository)
        {
            var player = citizen.GetComponent<Player>();

            player.Interior = 0;
            player.ToggleClock(false);
            player.Money = 30000;
            player.GiveWeapon(Weapon.Colt45, 100);

            var location = spawnLocationRepository.GetRandomSpawnLocation(citizen.City);

            player.Position = location.Position;
            player.Angle = location.Angle;
        }

        [Event]
        public void OnPlayerDeath(Player player, Player killer, Weapon reason)
        {
            if (killer == null)
            {
                // If the player killed itself, remove their money.
                player.ResetMoney();
            }
            else
            {
                // If the player was killed, give their money to the killer.
                var money = player.Money;
                if (money > 0)
                {
                    killer.GiveMoney(money);
                    player.ResetMoney();
                }
            }
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