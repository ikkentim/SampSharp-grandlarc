using System;
using System.Threading.Tasks;
using SampSharp.Entities;
using SampSharp.Entities.SAMP;

namespace GrandLarcency.Systems
{
    /// <summary>
    /// Represents a system which provides real time to the player's game time.
    /// </summary>
    public class RealTimeSystem : ISystem
    {
        private readonly IEntityManager _entityManager;
        private readonly IServerService _serverService;

        private TextDraw _textDraw;

        public RealTimeSystem(IServerService serverService, IEntityManager entityManager)
        {
            _serverService = serverService;
            _entityManager = entityManager;
        }

        [Event]
        public void OnGameModeInit(IWorldService worldService)
        {
            // Create clock textdraw in the top-right corner of the screen
            _textDraw = worldService.CreateTextDraw(new Vector2(605, 25), "00:00");
            _textDraw.UseBox = false;
            _textDraw.Font = TextDrawFont.Pricedown;
            _textDraw.Shadow = 0;
            _textDraw.Outline = 2;
            _textDraw.BackColor = Color.Black;
            _textDraw.ForeColor = Color.White;
            _textDraw.Alignment = TextDrawAlignment.Right;
            _textDraw.LetterSize = new Vector2(0.5f, 1.5f);

            // Start updating the time
            UpdateTime();
        }

        private async void UpdateTime()
        {
            // Keep updating the time and weather every minute
            for (;;)
            {
                try
                {
                    var now = DateTime.Now;

                    // Update the textdraw and server time
                    _textDraw.Text = now.ToString("t");
                    _serverService.SetWorldTime(now.Hour);

                    // Get all players and update their time
                    var players = _entityManager.GetComponents<Player>();

                    foreach (var player in players)
                        player.SetTime(now.Hour, now.Minute);
                }
                catch (Exception e)
                {
                    // Would something go wrong, let the for loop continue and log the error!
                    Console.WriteLine($"Failed to update time and weather! {e}");
                }

                // Wait a minute...
                await Task.Delay(TimeSpan.FromMinutes(1));
            }
        }

        [Event]
        public void OnPlayerSpawn(Player player)
        {
            _textDraw.Show(player);

            var now = DateTime.Now;
            player.SetTime(now.Hour, now.Minute);
        }

        [Event]
        public void OnPlayerDeath(Player player, Player killer, Weapon reason)
        {
            _textDraw.Hide(player);
        }

        [Event]
        public void OnPlayerConnect(Player player)
        {
            var now = DateTime.Now;
            player.SetTime(now.Hour, now.Minute);
        }
    }
}