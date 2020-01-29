using Microsoft.Extensions.DependencyInjection;
using SampSharp.Entities;
using SampSharp.Entities.SAMP;

namespace GrandLarcency
{
	public class Startup : IStartup
	{
		public void Configure(IServiceCollection services)
        {
            services
                .AddTransient<ISpawnLocationRepository, SpawnLocationRepository>()
                .AddTransient<IScriptFilesService, ScriptFilesService>()
                .AddTransient<IVehicleSpawnParserService, VehicleSpawnParserService>()
                .AddSystemsInAssembly();
        }

		public void Configure(IEcsBuilder builder)
		{
			builder.EnableSampEvents()
				.EnablePlayerCommands()
				.EnableRconCommands();
		}
	}
}