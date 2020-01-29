namespace GrandLarcency
{
    public interface ISpawnLocationRepository
    {
        SpawnLocation GetRandomSpawnLocation(City city);
    }
}