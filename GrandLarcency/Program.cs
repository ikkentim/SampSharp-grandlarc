using SampSharp.Core;
using SampSharp.Core.Logging;
using SampSharp.Entities;

namespace GrandLarcency
{
	public class Program
	{
		static void Main(string[] args)
		{
            // This is the main entrypoint of this application.
            // Start SampSharp with the ECS configuration provided by th Startup class.
			new GameModeBuilder()
                .UseLogLevel(CoreLogLevel.Debug)
				.UseEcs<Startup>()
				.Run();
		}
	}
}
