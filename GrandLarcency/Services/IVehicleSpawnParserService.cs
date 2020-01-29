using System.Collections.Generic;
using System.IO;

namespace GrandLarcency
{
    public interface IVehicleSpawnParserService
    {
        IEnumerable<VehicleSpawn> Parse(Stream stream);
    }
}